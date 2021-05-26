FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /source

COPY ShareOwnerControl/*.sln . 
COPY ShareOwnerControl/*.csproj .
RUN dotnet restore

COPY ShareOwnerControl/. ./ShareOwnerControl/
WORKDIR /source/ShareOwnerControl
RUN dotnet publish -c release -o /app

FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
COPY --from=build /app ./
EXPOSE 80
ENTRYPOINT ["dotnet", "ShareOwnerControl.dll"]