FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /source

COPY ProviderService/*.sln . 
COPY ProviderService/*.csproj .
RUN dotnet restore

COPY ProviderService/. ./ProviderService/
WORKDIR /source/ProviderService
RUN dotnet publish -c release -o /app

FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
COPY --from=build /app ./
EXPOSE 80
ENTRYPOINT ["dotnet", "ProviderService.dll"]