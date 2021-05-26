FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /source

COPY ApiProxyService/*.sln . 
COPY ApiProxyService/*.csproj .
RUN dotnet restore

COPY ApiProxyService/. ./ApiProxyService/
WORKDIR /source/ApiProxyService
RUN dotnet publish -c release -o /app

FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
COPY --from=build /app ./
EXPOSE 80
ENTRYPOINT ["dotnet", "ApiProxyService.dll"]