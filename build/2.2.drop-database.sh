#! usr/bin/bash

# Go to root
source ./utils.sh
to-root 

# Redirect to ApiDemo.EntityFrameworkCore project
cd src/ApiDemo.EntityFrameworkCore

# Excute
dotnet ef database drop