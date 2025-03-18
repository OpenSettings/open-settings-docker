# Use the official .NET SDK for building the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy everything and restore dependencies
COPY ./src/OpenSettings.Api/OpenSettings.Api.csproj ./src/OpenSettings.Api/
RUN dotnet restore ./src/OpenSettings.Api/OpenSettings.Api.csproj

# Copy the rest of the source and build the app
COPY ./src/OpenSettings.Api/ ./src/OpenSettings.Api/
WORKDIR /app/src/OpenSettings.Api
RUN dotnet publish -c Release -o /out --no-restore

# Use the official ASP.NET Core runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /out .

# Expose the API port and run the app
EXPOSE 5000
ENTRYPOINT ["dotnet", "OpenSettings.Api.dll"]
