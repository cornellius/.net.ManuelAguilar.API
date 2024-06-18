FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
ENV DOTNET_URLS=http://+:80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["ManuelAguilar.API/ManuelAguilar.API.csproj", "ManuelAguilar.API/"]
RUN dotnet restore "ManuelAguilar.API/ManuelAguilar.API.csproj"
COPY . .
WORKDIR "/src/ManuelAguilar.API"
RUN dotnet build "ManuelAguilar.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "ManuelAguilar.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
EXPOSE 80
ENTRYPOINT ["dotnet", "ManuelAguilar.API.dll", "--server.urls", "http://+:80"]
