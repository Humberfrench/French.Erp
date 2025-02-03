# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081


# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["French.Erp.Web/French.Erp.Web.csproj", "French.Erp.Web/"]
COPY ["French.Erp.Application/French.Erp.Application.csproj", "French.Erp.Application/"]
COPY ["French.Erp.Domain/French.Erp.Domain.csproj", "French.Erp.Domain/"]
COPY ["French.Erp.Ioc/French.Erp.Ioc.csproj", "French.Erp.Ioc/"]
COPY ["French.Erp.Repository/French.Erp.Repository.csproj", "French.Erp.Repository/"]
COPY ["French.Erp.Services/French.Erp.Services.csproj", "French.Erp.Services/"]
RUN dotnet restore "./French.Erp.Web/French.Erp.Web.csproj"
COPY . .
WORKDIR "/src/French.Erp.Web"
RUN dotnet build "./French.Erp.Web.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./French.Erp.Web.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "French.Erp.Web.dll"]