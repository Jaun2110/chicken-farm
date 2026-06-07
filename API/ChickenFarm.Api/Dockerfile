FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copy csproj files and restore
COPY ChickenFarm.Api/*.csproj ChickenFarm.Api/
COPY ChickenFarm.Application/*.csproj ChickenFarm.Application/
COPY ChickenFarm.Domain/*.csproj ChickenFarm.Domain/
COPY ChickenFarm.Infrastructure/*.csproj ChickenFarm.Infrastructure/

RUN dotnet restore ChickenFarm.Api/ChickenFarm.Api.csproj

# Copy everything and build
COPY . .
RUN dotnet publish ChickenFarm.Api/ChickenFarm.Api.csproj -c Release -o /app/publish

# Runtime image
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080
ENV ASPNETCORE_ENVIRONMENT=Production

ENTRYPOINT ["dotnet", "ChickenFarm.Api.dll"]