#! usr/bin/bash
dotnet run --project ../src/ApiDemo.DbMigrator
rm tempkey.jwk
rm -rfv Logs