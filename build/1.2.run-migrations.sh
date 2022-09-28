#! usr/bin/bash

# Go to root
source ./utils.sh
to-root 

# First build whole project
dotnet build

# First migrations
cd src/ApiDemo.DbMigrator
dotnet run

# # # Remove redundant files 
# cd -


# cd build


# rm tempkey.jwk
# rm -rfv Logs