// -----------------------------------------------------------
// Dependency Injection - Service Registration
// -----------------------------------------------------------

using Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        // Services
        services.AddScoped<ITaskService, TaskService>();
        services.AddScoped<IAuthService, AuthService>();

        // Validators (auto-register from assembly)
        services.AddValidatorsFromAssemblyContaining<CreateTaskRequestValidator>();

        return services;
    }

    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        // Database
        services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("Database")));

        // Caching
        services.AddStackExchangeRedisCache(options =>
        {
            options.Configuration = configuration.GetConnectionString("Redis");
            options.InstanceName = "TaskFlow_";
        });

        // Options pattern - strongly typed configuration
        services.Configure<JwtOptions>(configuration.GetSection("Jwt"));
        services.Configure<CacheOptions>(configuration.GetSection("Cache"));

        // Health checks
        services.AddHealthChecks()
            .AddNpgSql(configuration.GetConnectionString("Database")!)
            .AddRedis(configuration.GetConnectionString("Redis")!);

        return services;
    }
}

// -----------------------------------------------------------
// Options classes - strongly typed configuration
// -----------------------------------------------------------

public class JwtOptions
{
    public string Issuer { get; set; } = string.Empty;
    public string Audience { get; set; } = string.Empty;
    public string Key { get; set; } = string.Empty;
    public int ExpirationInMinutes { get; set; } = 60;
}

public class CacheOptions
{
    public int DefaultExpirationInMinutes { get; set; } = 5;
    public int LongExpirationInMinutes { get; set; } = 30;
}
