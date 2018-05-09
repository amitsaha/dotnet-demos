# https://hub.docker.com/r/msimons/dotnet-framework-build/
#https://alastaircrabtree.com/microsoft-webapplication-targets-was-not-found-again/  

FROM microsoft/dotnet-framework:4.7.2-sdk AS build-env
WORKDIR /app
COPY . .
RUN nuget restore
RUN msbuild ASPNETFramework_API.sln /p:DeployOnBuild=true /p:PublishProfile=FolderProfile /p:Configuration=Release /p:VisualStudioVersion=17.0

FROM microsoft/aspnet:4.7.1-windowsservercore-1709
COPY --from=build-env /app/ASPNETFramework_API/bin/Release/PublishOutput /inetpub/wwwroot
WORKDIR /inetpub/wwwroot