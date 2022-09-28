#! usr/bin/bash

# First build whole project
dotnet build ..

# First migrations
dotnet run --project ../src/ApiDemo.DbMigrator
rm tempkey.jwk
rm -rfv Logs