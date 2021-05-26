FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /source

COPY RequestService/*.sln . 
COPY RequestService/*.csproj .
RUN dotnet restore

COPY RequestService/. ./RequestService/
WORKDIR /source/RequestService
RUN dotnet publish -c release -o /app

FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
COPY --from=build /app ./
EXPOSE 80
ENTRYPOINT ["dotnet", "RequestService.dll"]