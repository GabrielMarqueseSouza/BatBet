#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /app
COPY ["src/BatBetService/BatBetServiceAPI.csproj", "src/BatBetService/"]
COPY ["src/BatBetInfrastructure/BatBetInfrastructure.csproj", "src/BatBetInfrastructure/"]
COPY ["src/BatBetDomain/BatBetDomain.csproj", "src/BatBetDomain/"]
COPY ["src/Contracts/Contracts.csproj", "src/Contracts/"]
RUN dotnet restore "./src/BatBetService/BatBetServiceAPI.csproj"
COPY . .
WORKDIR "/app/src/BatBetService"
RUN dotnet build "./BatBetServiceAPI.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./BatBetServiceAPI.csproj" -c $BUILD_CONFIGURATION -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish/ .
ENTRYPOINT ["dotnet", "BatBetServiceAPI.dll"]