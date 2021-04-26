FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /source

COPY DelProjekt1_Disp_Backend/*.sln . 
COPY DelProjekt1_Disp_Backend/*.csproj ./DelProjekt1_Disp_Backend/
RUN dotnet restore

COPY DelProjekt1_Disp_Backend/. ./DelProjekt1_Disp_Backend/
WORKDIR /source/DelProjekt1_Disp_Backend
RUN dotnet publish -c release -o /app --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
COPY --from=build /app ./
ENTRYPOINT ["dotnet", "DelProjekt1_Disp_Backend.dll"]