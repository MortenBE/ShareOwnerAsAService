FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /source

COPY TraderService/*.sln . 
COPY TraderService/*.csproj .
RUN dotnet restore

COPY TraderService/. ./TraderService/
WORKDIR /source/TraderService
RUN dotnet publish -c release -o /app

FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
COPY --from=build /app ./
EXPOSE 80
ENTRYPOINT ["dotnet", "TraderService.dll"]