FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /source

COPY TobinTaxService/*.sln . 
COPY TobinTaxService/*.csproj .
RUN dotnet restore

COPY TobinTaxService/. ./TobinTaxService/
WORKDIR /source/TobinTaxService
RUN dotnet publish -c release -o /app

FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
COPY --from=build /app ./
EXPOSE 80
ENTRYPOINT ["dotnet", "TobinTaxService.dll"]