#Requires -Version 5.0

Set-Location -Path ..\

Write-Host "Building container image..."

$VERSION = if ($args.Count -gt 0) { $args[0] } else { "1.0.1-1" }

# Build the container image
docker build --no-cache -t OpenSettings/open-settings:$VERSION .

# Tagging the image as
docker tag OpenSettings/open-settings:$VERSION OpenSettings/open-settings:latest

Write-Host "Container image built successfully!"

Set-Location -Path .\scripts\