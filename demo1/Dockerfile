FROM microsoft/dotnet-framework:4.7.2-sdk AS build-env
WORKDIR /app
COPY . .
RUN nuget restore
# VisualStudioVersion=17.0 needed as per 
# https://alastaircrabtree.com/microsoft-webapplication-targets-was-not-found-again/  
# FIXME:
# The folder publishing doesn't work from inside the container, even though it works
# on a Win 10 host + VS 2017
RUN msbuild ASPNETFramework_API.sln /p:DeployOnBuild=true /p:PublishProfile=FolderProfile /p:Configuration=Release /p:VisualStudioVersion=17.0

FROM microsoft/aspnet:4.7.1-windowsservercore-1709
# Once the above folder profile works, we will copy only
# the PublishOutput contents
# Manual
# COPY --from=build-env /app/ASPNETFramework_API /inetpub/wwwroot
# Use PowerShell IIS admin to configure site
# Learn more: https://octopus.com/blog/iis-powershell
COPY --from=build-env /app/ASPNETFramework_API C:/site
RUN New-IISSite -Name 'DemoAPI' -PhysicalPath c:\site -BindingInformation "*:8000:"

WORKDIR /inetpub/wwwroot