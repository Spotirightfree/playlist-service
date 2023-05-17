#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 5049

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["playlist-service.csproj", "."]
RUN dotnet restore "playlist-service.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "playlist-service.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "playlist-service.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
ENV ASPNETCORE_URLS=http://+:5049
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "playlist-service.dll"]