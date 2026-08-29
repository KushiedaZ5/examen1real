# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

COPY ["TecnoGasPortal.csproj", "./"]
RUN dotnet restore "./TecnoGasPortal.csproj"

COPY . .
RUN dotnet publish "./TecnoGasPortal.csproj" -c Release -o /app/publish --no-restore

# Stage 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app

# Install SQLite tools
RUN apt-get update && apt-get install -y sqlite3 && rm -rf /var/lib/apt/lists/*

COPY --from=build /app/publish .

# Expose port 8080 (Render uses this)
ENV ASPNETCORE_URLS=http://+:8080
ENV ASPNETCORE_ENVIRONMENT=Production
ENV DOTNET_USE_POLLING_FILE_WATCHER=true
ENV DOTNET_HOSTBUILDER__RELOADCONFIGONCHANGE=false

EXPOSE 8080

ENTRYPOINT ["dotnet", "TecnoGasPortal.dll"]
