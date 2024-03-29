Prerequisite:
- Dotnet: https://dotnet.microsoft.com/en-us/download/dotnet/thank-you/sdk-6.0.401-windows-x64-installer
- Visual Studio 2022: https://visualstudio.microsoft.com/fr/thank-you-downloading-visual-studio/?sku=Community&channel=Release&version=VS2022&source=VSLandingPage&cid=2030&passive=false
- To install ABP CLI, run command in terminal: dotnet tool install -g Volo.Abp.Cli
- Download Docker: https://docs.docker.com/desktop/install/windows-install/
- To install tye, run command in terminal: dotnet tool install -g Microsoft.Tye --version "0.11.0-alpha.22111.1"
- Git bash: https://github.com/git-for-windows/git/releases/download/v2.37.3.windows.1/Git-2.37.3-64-bit.exe
- ngrok (for development): https://ngrok.com/download

Perform the following steps to run the application:
- Open git bash at directory build
- Run: bash 1.1.run-docker-infrastructure.sh (create an instance of PosgreSQL)
- Run: bash 1.2.run-migrations.sh (build whole solution, create database in PosgreSQL and seed initial data)
- Run: bash 1.3.run-tye.sh (run solution)

Note: Just run files 1.1 and 1.2 the first time to configure the base of the application. From the 2nd time onwards, to run the application just run 1.3

To forward to an https server: 
- Type command: ngrok http https://localhost:44393