#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Locaserv.Bdv.Api.csproj", "."]
RUN dotnet restore "./Locaserv.Bdv.Api.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "Locaserv.Bdv.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Locaserv.Bdv.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "Locaserv.Bdv.Api.dll"]
CMD ASPNETCORE_URLS=http://*:$PORT dotnet Locaserv.Bdv.Api.dll