#! usr/bin/bash

# Go to root
source ./utils.sh
to-root 

# Go to docker-dev folder
cd build/docker-dev

# Excute
docker compose up -d