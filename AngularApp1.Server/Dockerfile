FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src
COPY ["AngularApp1.Server/AngularApp1.Server.csproj", "AngularApp1.Server/"]
COPY ["Repository/Repository.csproj", "Repository/"]
RUN dotnet restore AngularApp1.Server/AngularApp1.Server.csproj
RUN dotnet restore Repository/Repository.csproj

COPY . .
WORKDIR /src/AngularApp1.Server
RUN dotnet build AngularApp1.Server.csproj -c Release -o /app/build

# Run Test To Be Add


FROM build as publish
RUN dotnet publish "AngularApp1.Server.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base as final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AngularApp1.Server.dll"]
