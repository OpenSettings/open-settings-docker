FROM mcr.microsoft.com/dotnet/sdk:8.0-alpine AS build
WORKDIR /app

COPY ./src/OpenSettings.Api/OpenSettings.Api.csproj ./src/OpenSettings.Api/
RUN dotnet restore ./src/OpenSettings.Api/OpenSettings.Api.csproj

COPY ./src/OpenSettings.Api/ ./src/OpenSettings.Api/
WORKDIR /app/src/OpenSettings.Api
RUN dotnet publish -c Release -o /out --no-restore -v diag

FROM mcr.microsoft.com/dotnet/aspnet:8.0-alpine AS runtime
WORKDIR /app

COPY --from=build /out .

EXPOSE 5000

ENTRYPOINT ["dotnet", "OpenSettings.Api.dll"]