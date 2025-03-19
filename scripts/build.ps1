#!/bin/bash

Set-Location -Path ..\

Write-Host "Building Docker image..."

$VERSION = if ($args.Count -gt 0) { $args[0] } else { "1.0.0-1" }

# Build the Docker image
docker build --no-cache -t OpenSettings/open-settings:$VERSION .

# Tagging the image as "latest"
docker tag OpenSettings/open-settings:$VERSION OpenSettings/open-settings:latest

Write-Host "Docker image built successfully!"

Set-Location -Path .\scripts\