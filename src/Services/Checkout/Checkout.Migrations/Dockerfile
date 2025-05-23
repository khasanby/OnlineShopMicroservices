# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
USER $APP_UID
WORKDIR /app


# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Services/Checkout/Checkout.Migrations/Checkout.Migrations.csproj", "Services/Checkout/Checkout.Migrations/"]
COPY ["Services/Checkout/Checkout.Infrastructure/Checkout.Infrastructure.csproj", "Services/Checkout/Checkout.Infrastructure/"]
COPY ["Services/Checkout/Checkout.Domain/Checkout.Domain.csproj", "Services/Checkout/Checkout.Domain/"]
COPY ["BuildingBlocks/BuildingBlocks/BuildingBlocks.csproj", "BuildingBlocks/BuildingBlocks/"]
RUN dotnet restore "./Services/Checkout/Checkout.Migrations/Checkout.Migrations.csproj"
COPY . .
WORKDIR "/src/Services/Checkout/Checkout.Migrations"
RUN dotnet build "./Checkout.Migrations.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Checkout.Migrations.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Checkout.Migrations.dll"]