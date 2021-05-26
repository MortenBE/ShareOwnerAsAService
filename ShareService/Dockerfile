FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /source

COPY ShareService/*.sln . 
COPY ShareService/*.csproj .
RUN dotnet restore

COPY ShareService/. ./ShareService/
WORKDIR /source/ShareService
RUN dotnet publish -c release -o /app

FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
COPY --from=build /app ./
EXPOSE 80
ENTRYPOINT ["dotnet", "ShareService.dll"]