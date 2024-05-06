#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /app

COPY ["src/BatBetService/BatBetServiceAPI.csproj", "src/BatBetService/BatBetServiceAPI.csproj"]
COPY ["src/BetSearchService/BetSearchServiceAPI.csproj", "src/BetSearchService/BetSearchServiceAPI.csproj"]
COPY ["src/BatBetDomain/BatBetDomain.csproj", "src/BatBetDomain/BatBetDomain.csproj"]
COPY ["src/BatBetInfrastructure/BatBetInfrastructure.csproj", "src/BatBetInfrastructure/BatBetInfrastructure.csproj"]
COPY ["src/Contracts/Contracts.csproj", "src/Contracts/Contracts.csproj"]
COPY ["src/GatewayService/GatewayService.csproj", "src/GatewayService/GatewayService.csproj"]
COPY ["src/IdentityService/IdentityService.csproj", "src/IdentityService/IdentityService.csproj"]

RUN dotnet restore "./src/BatBetService/./BatBetServiceAPI.csproj"
COPY . .
WORKDIR "/app/src/BatBetService"
RUN dotnet build "./BatBetServiceAPI.csproj" -c $BUILD_CONFIGURATION -o /app/src/out

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./BatBetServiceAPI.csproj" -c $BUILD_CONFIGURATION -o /app/src/out

FROM base AS final
WORKDIR /app
COPY --from=publish /app/src/out .
ENTRYPOINT ["dotnet", "BatBetServiceAPI.dll"]