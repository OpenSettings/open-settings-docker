#Requires -Version 5.0

Set-Location -Path ..\

$VERSION = if ($args.Count -gt 0) { $args[0] } else { "V1_0" }
$providers = @("MySql", "Oracle", "PostgreSql", "Sqlite", "SqlServer")

# Starting Db Containers
Write-Host "Starting Db containers..."
docker-compose -f .\docker-compose.migrations.yml up  -d

# Waiting for services to be ready
Write-Host "Waiting Db containers to be ready..."
Start-Sleep -Seconds 15

Write-Host "Adding Migration..."

foreach ($provider in $providers) {
    $projectPath = "src\OpenSettings.Migrations.$provider"
    $outputPath = "Data/Migrations/OpenSettings/OpenSettingsDb"

    Write-Host "Running migration for $provider..."
    dotnet ef migrations add OpenSettingsDbMigration_$VERSION `
        --project $projectPath `
        --startup-project src\OpenSettings.Api `
        -c OpenSettingsDbContext `
        -o $outputPath `
        -v
}

Write-Host "Migrations added successfully!"

docker-compose -f .\docker-compose.migrations.yml down

Set-Location -Path .\scripts\