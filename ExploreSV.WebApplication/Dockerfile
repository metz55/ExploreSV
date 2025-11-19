# Imagen base de aspnet
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080

# Imagen para compilar
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copiar csproj
COPY ["ExploreSV.WebApplication/ExploreSV.WebApplication.csproj", "ExploreSV.WebApplication/"]
COPY ["ExploreSV.BusinessLogic/ExploreSV.BusinessLogic.csproj", "ExploreSV.BusinessLogic/"]
COPY ["ExploreSV.DataAccess/ExploreSV.DataAccess.csproj", "ExploreSV.DataAccess/"]
COPY ["ExploreSV.Entities/ExploreSV.Entities.csproj", "ExploreSV.Entities/"]

RUN dotnet restore "./ExploreSV.WebApplication/ExploreSV.WebApplication.csproj"

# Copiar todo el código
COPY . .



# Forzar copia de wwwroot (si Render la ignora)
COPY ExploreSV.WebApplication/wwwroot /src/ExploreSV.WebApplication/wwwroot

WORKDIR "/src/ExploreSV.WebApplication"
RUN dotnet build "./ExploreSV.WebApplication.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Publicar
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./ExploreSV.WebApplication.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Fase final
FROM base AS final
WORKDIR /app

COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "ExploreSV.WebApplication.dll"]
