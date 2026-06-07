FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

COPY API/ChickenFarm.Api/*.csproj API/ChickenFarm.Api/
COPY API/ChickenFarm.Application/*.csproj API/ChickenFarm.Application/
COPY API/ChickenFarm.Domain/*.csproj API/ChickenFarm.Domain/
COPY API/ChickenFarm.Infrastructure/*.csproj API/ChickenFarm.Infrastructure/

RUN dotnet restore API/ChickenFarm.Api/ChickenFarm.Api.csproj

COPY . .
RUN dotnet publish API/ChickenFarm.Api/ChickenFarm.Api.csproj -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080
ENV ASPNETCORE_ENVIRONMENT=Production

ENTRYPOINT ["dotnet", "ChickenFarm.Api.dll"]