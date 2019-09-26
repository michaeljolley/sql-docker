FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["SQLDocker.Web/SQLDocker.Web.csproj", "SQLDocker.Web/"]
COPY ["SQLDocker.Data/SQLDocker.Data.csproj", "SQLDocker.Data/"]
RUN dotnet restore "SQLDocker.Web/SQLDocker.Web.csproj"
COPY . .
WORKDIR "/src/SQLDocker.Web"
RUN dotnet build "SQLDocker.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SQLDocker.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SQLDocker.Web.dll"]
