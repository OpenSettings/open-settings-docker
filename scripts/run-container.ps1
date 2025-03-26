#Requires -Version 5.0

Set-Location -Path ..\

Write-Host "Running container locally..."

$VERSION = if ($args.Count -gt 0) { $args[0] } else { "1.0.1-1" }

docker run -d -p 5388:8080 --name container-open-settings opensettings/open-settings:$VERSION

Write-Host "Container is running locally!"
Write-Host "Access the application at: - HTTP: http://localhost:5388"

docker logs container-open-settings

Set-Location -Path .\scripts\