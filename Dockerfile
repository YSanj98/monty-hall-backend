# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

WORKDIR /src
COPY *.sln .
COPY MontyHallApi/*.csproj ./MontyHallApi/
RUN dotnet restore

COPY MontyHallApi/. ./MontyHallApi/
WORKDIR /src/MontyHallApi
RUN dotnet publish -c Release -o /app/publish

# Stage 2: Run
FROM mcr.microsoft.com/dotnet/aspnet:6.0

WORKDIR /app
COPY --from=build /app/publish .

EXPOSE 5000

ENV ASPNETCORE_URLS=http://+:5000

ENTRYPOINT ["dotnet", "MontyHallApi.dll"]
