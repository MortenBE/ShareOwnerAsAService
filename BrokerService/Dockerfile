FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /source

COPY BrokerService/*.sln . 
COPY BrokerService/*.csproj .
RUN dotnet restore

COPY BrokerService/. ./BrokerService/
WORKDIR /source/BrokerService
RUN dotnet publish -c release -o /app

FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
COPY --from=build /app ./
EXPOSE 80
ENTRYPOINT ["dotnet", "BrokerService.dll"]