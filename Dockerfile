FROM mcr.microsoft.com/dotnet/sdk:9.0-alpine AS build
WORKDIR /app

COPY ./src/OpenSettings.Api/OpenSettings.Api.csproj ./src/OpenSettings.Api/
COPY ./src/OpenSettings.Migrations.MySql/OpenSettings.Migrations.MySql.csproj ./src/OpenSettings.Migrations.MySql/
COPY ./src/OpenSettings.Migrations.Oracle/OpenSettings.Migrations.Oracle.csproj ./src/OpenSettings.Migrations.Oracle/
COPY ./src/OpenSettings.Migrations.PostgreSql/OpenSettings.Migrations.PostgreSql.csproj ./src/OpenSettings.Migrations.PostgreSql/
COPY ./src/OpenSettings.Migrations.Shared/OpenSettings.Migrations.Shared.csproj ./src/OpenSettings.Migrations.Shared/
COPY ./src/OpenSettings.Migrations.Sqlite/OpenSettings.Migrations.Sqlite.csproj ./src/OpenSettings.Migrations.Sqlite/
COPY ./src/OpenSettings.Migrations.SqlServer/OpenSettings.Migrations.SqlServer.csproj ./src/OpenSettings.Migrations.SqlServer/
RUN dotnet restore ./src/OpenSettings.Api/OpenSettings.Api.csproj

COPY ./src ./src

WORKDIR /app/src/OpenSettings.Api
RUN dotnet publish -c Release -o /out --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:9.0-alpine AS runtime
WORKDIR /app

RUN apk add --no-cache icu-libs

ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false

COPY --from=build /out .

EXPOSE 5000 5001

ENTRYPOINT ["dotnet", "OpenSettings.Api.dll"]