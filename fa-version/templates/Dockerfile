# -----------------------------------------------------------
# Multi-stage Dockerfile for .NET 9 API
# -----------------------------------------------------------
# Stage 1: Build
# Stage 2: Publish
# Stage 3: Runtime (minimal image)
# -----------------------------------------------------------

# Build stage
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copy csproj first for layer caching
COPY ["src/TaskFlow.Api/TaskFlow.Api.csproj", "src/TaskFlow.Api/"]
RUN dotnet restore "src/TaskFlow.Api/TaskFlow.Api.csproj"

# Copy everything else
COPY . .

# Build
WORKDIR "/src/src/TaskFlow.Api"
RUN dotnet build "TaskFlow.Api.csproj" -c Release -o /app/build

# Publish stage
FROM build AS publish
RUN dotnet publish "TaskFlow.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Runtime stage - use the smallest possible image
FROM mcr.microsoft.com/dotnet/aspnet:9.0-alpine AS runtime
WORKDIR /app

# Security: run as non-root user
RUN addgroup -S appgroup && adduser -S appuser -G appgroup
USER appuser

# Copy published output
COPY --from=publish /app/publish .

# Expose port
EXPOSE 8080

# Health check
HEALTHCHECK --interval=30s --timeout=5s --start-period=10s --retries=3 \
    CMD wget --no-verbose --tries=1 --spider http://localhost:8080/health || exit 1

# Entry point
ENTRYPOINT ["dotnet", "TaskFlow.Api.dll"]
