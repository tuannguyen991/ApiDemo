Prerequisite:
- Dotnet: https://dotnet.microsoft.com/en-us/download/dotnet/thank-you/sdk-6.0.401-windows-x64-installer
- Visual Studio 2022: https://visualstudio.microsoft.com/fr/thank-you-downloading-visual-studio/?sku=Community&channel=Release&version=VS2022&source=VSLandingPage&cid=2030&passive=false
- To install ABP CLI, run command in terminal: dotnet tool install -g Volo.Abp.Cli
- Download Docker: https://docs.docker.com/desktop/install/windows-install/
- Download MSSM Studio 18 (optional): https://aka.ms/ssmsfullsetup
- To install tye, run command in terminal: dotnet tool install -g Microsoft.Tye --version "0.11.0-alpha.22111.1"

Perform the following steps to run the application:
- In directory root, run: dotnet build
- In directory build/docker-dev, run: docker compose up -d
- In directory src/ApiDemo.DbMigrator, run: dotnet run
- In direcotry build/tye, run: tye run --watch