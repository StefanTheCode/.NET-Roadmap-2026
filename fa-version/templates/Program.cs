using Serilog;

var builder = WebApplication.CreateBuilder(args);

// -----------------------------------------------------------
// Logging - Serilog with structured logging
// -----------------------------------------------------------
builder.Host.UseSerilog((context, config) =>
    config.ReadFrom.Configuration(context.Configuration));

// -----------------------------------------------------------
// Services
// -----------------------------------------------------------
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddProblemDetails();

builder.Services.AddHealthChecks()
    .AddNpgSql(builder.Configuration.GetConnectionString("Database")!);

// Register application services
builder.Services.AddScoped<ITaskService, TaskService>();

// Register DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("Database")));

// Register FluentValidation
builder.Services.AddValidatorsFromAssemblyContaining<Program>();

// Authentication
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!))
        };
    });
builder.Services.AddAuthorization();

// Output caching
builder.Services.AddOutputCache(options =>
{
    options.AddBasePolicy(policy => policy.Expire(TimeSpan.FromMinutes(5)));
    options.AddPolicy("NoCache", policy => policy.NoCache());
});

// Rate limiting
builder.Services.AddRateLimiter(options =>
{
    options.RejectionStatusCode = StatusCodes.Status429TooManyRequests;
    options.AddFixedWindowLimiter("fixed", limiter =>
    {
        limiter.PermitLimit = 60;
        limiter.Window = TimeSpan.FromMinutes(1);
    });
});

var app = builder.Build();

// -----------------------------------------------------------
// Middleware Pipeline - ORDER MATTERS
// -----------------------------------------------------------

// 1. Exception handling (outermost)
app.UseExceptionHandler();
app.UseStatusCodePages();

// 2. HTTPS redirection
app.UseHttpsRedirection();

// 3. Serilog request logging
app.UseSerilogRequestLogging();

// 4. Rate limiting
app.UseRateLimiter();

// 5. Authentication & Authorization
app.UseAuthentication();
app.UseAuthorization();

// 6. Output caching
app.UseOutputCache();

// 7. Swagger (development only)
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// -----------------------------------------------------------
// Endpoints
// -----------------------------------------------------------

// Health check
app.MapHealthChecks("/health");

// API endpoints
app.MapTaskEndpoints();

app.Run();

// Make Program accessible for integration tests
public partial class Program { }
