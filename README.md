Install mssql server https://www.microsoft.com/en-us/sql-server/sql-server-downloads
Install node https://nodejs.org/en/

From GlowingSystem.Backend run:
dotnet restore
dotnet build
cd .\GlowingSystem\
dotnet run


From GlowingSystem.Frontend run:
npm install
npm run dev