#! usr/bin/bash

# Go to root
source ./utils.sh
to-root 

# Redirect to HttpApi.Host folder
cd src/ApiDemo.HttpApi.Host

# Excute
dotnet add package Swashbuckle.AspNetCore.ReDoc --version 6.4.0