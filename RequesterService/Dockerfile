FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /source

COPY RequesterService/*.sln . 
COPY RequesterService/*.csproj .
RUN dotnet restore

COPY RequesterService/. ./RequesterService/
WORKDIR /source/RequesterService
RUN dotnet publish -c release -o /app

FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
COPY --from=build /app ./
EXPOSE 80
ENTRYPOINT ["dotnet", "RequesterService.dll"]