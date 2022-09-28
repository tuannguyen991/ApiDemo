#! usr/bin/bash

# Go to root
source ./utils.sh
to-root 

# Redirect to tye folder
pwd
cd src/ApiDemo.HttpApi.Host
pwd

# Excute
dotnet add package Swashbuckle.AspNetCore.ReDoc --version 6.4.0