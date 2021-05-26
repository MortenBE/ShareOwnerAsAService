FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /source

COPY StockTraderBroker/*.sln . 
COPY StockTraderBroker/*.csproj .
RUN dotnet restore

COPY StockTraderBroker/. ./StockTraderBroker/
WORKDIR /source/StockTraderBroker
RUN dotnet publish -c release -o /app

FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
COPY --from=build /app ./
EXPOSE 80
ENTRYPOINT ["dotnet", "StockTraderBroker.dll"]