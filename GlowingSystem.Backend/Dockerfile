FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /home/app
COPY ./*.sln ./
COPY ./*/*.csproj ./
RUN for file in $(ls *.csproj); do mkdir -p ./${file%.*}/ && mv $file ./${file%.*}/; done
RUN dotnet restore
COPY . .
# RUN dotnet test ./GlowingSystem.IntegrationTests/GlowingSystem.IntegrationTests.csproj
RUN dotnet publish ./GlowingSystem/GlowingSystem.csproj -o /publish
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /publish
COPY --from=build /publish ./
ENV ASPNETCORE_URLS=http://0.0.0.0:5000
ENTRYPOINT [ "dotnet", "GlowingSystem.dll" ]