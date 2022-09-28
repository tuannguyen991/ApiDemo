#! usr/bin/bash

# Redirect to ApiDemo.EntityFrameworkCore project
cd ../src/ApiDemo.EntityFrameworkCore

# Add migration name passed through bash cmd
dotnet ef migrations add $1

# Update database with created migration
dotnet ef database update