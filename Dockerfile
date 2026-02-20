
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080

FROM base AS final
WORKDIR /app
COPY . .
ENTRYPOINT ["dotnet", "asp.net core 8.0 web api.dll"]
