# 🔧 ขั้นตอนที่ 1: Build .NET
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

COPY *.csproj ./
RUN dotnet restore

COPY . ./
RUN dotnet publish -c Release -o out

# 🔥 ขั้นตอนที่ 2: รันจริงด้วย ASP.NET Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

COPY --from=build /app/out ./
ENTRYPOINT ["dotnet", "PersonalFinanceProjects.API.dll", "--urls", "http://0.0.0.0:80"]

ENV ASPNETCORE_URLS=http://0.0.0.0:80