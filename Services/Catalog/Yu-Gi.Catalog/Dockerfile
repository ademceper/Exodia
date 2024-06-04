FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Services/Catalog/Yu-Gi.Catalog/Yu-Gi.Catalog.csproj", "Services/Catalog/Yu-Gi.Catalog/"]
RUN dotnet restore "./Services/Catalog/Yu-Gi.Catalog/Yu-Gi.Catalog.csproj"
COPY . .
WORKDIR "/src/Services/Catalog/Yu-Gi.Catalog"
RUN dotnet build "./Yu-Gi.Catalog.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Yu-Gi.Catalog.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Yu-Gi.Catalog.dll"]