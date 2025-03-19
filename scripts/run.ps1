#!/bin/bash

cd ..\

echo "Running Docker container locally..."

VERSION=${1:-1.0.0-1}

# Run the Docker container in the background
docker run -d -p 5388:5000 --name open-settings-container OpenSettings/open-settings:$VERSION

echo "Docker container is running locally!"
echo "Access the application at:"
echo "  - HTTP: http://localhost:5000"

docker logs container-open-settings