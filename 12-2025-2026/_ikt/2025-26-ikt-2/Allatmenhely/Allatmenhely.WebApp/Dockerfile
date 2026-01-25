FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Allatmenhely.WebApp/Allatmenhely.WebApp.csproj", "Allatmenhely.WebApp/"]
RUN dotnet restore "Allatmenhely.WebApp/Allatmenhely.WebApp.csproj"
COPY . .
WORKDIR "/src/Allatmenhely.WebApp"
RUN dotnet build "Allatmenhely.WebApp.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Allatmenhely.WebApp.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY --from=build /src/Allatmenhely.WebApp/wwwroot ./wwwroot
ENTRYPOINT ["dotnet", "Allatmenhely.WebApp.dll"]
