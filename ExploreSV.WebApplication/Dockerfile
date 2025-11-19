# https://aka.ms/customizecontainer

# Fase base
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# Fase build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

COPY ["ExploreSV.WebApplication/ExploreSV.WebApplication.csproj", "ExploreSV.WebApplication/"]
COPY ["ExploreSV.BusinessLogic/ExploreSV.BusinessLogic.csproj", "ExploreSV.BusinessLogic/"]
COPY ["ExploreSV.DataAccess/ExploreSV.DataAccess.csproj", "ExploreSV.DataAccess/"]
COPY ["ExploreSV.Entities/ExploreSV.Entities.csproj", "ExploreSV.Entities/"]

RUN dotnet restore "./ExploreSV.WebApplication/ExploreSV.WebApplication.csproj"


# Copiar todo el código, incluyendo wwwroot
COPY . .

WORKDIR "/src/ExploreSV.WebApplication"
RUN dotnet build "./ExploreSV.WebApplication.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Fase publish
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./ExploreSV.WebApplication.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Fase final
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ExploreSV.WebApplication.dll"]
