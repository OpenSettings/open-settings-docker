#!/bin/bash

Set-Location -Path ..\

Write-Host "Running Docker container locally..."

$VERSION = if ($args.Count -gt 0) { $args[0] } else { "1.0.0-1" }

# Run the Docker container in the background
docker run -d -p 5388:8080 --name container-open-settings OpenSettings/open-settings:$VERSION

Write-Host "Docker container is running locally!"
Write-Host "Access the application at:"
Write-Host "  - HTTP: http://localhost:5388"

docker logs container-open-settings

Set-Location -Path .\scripts\