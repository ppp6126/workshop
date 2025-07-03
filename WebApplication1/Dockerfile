# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# คัดลอกไฟล์โปรเจกต์จาก subfolder
COPY WebApplication1/*.csproj ./ 

# Restore dependencies
RUN dotnet restore

# คัดลอกไฟล์ทั้งหมดจาก subfolder
COPY WebApplication1/. ./

# Build และ publish
RUN dotnet publish -c Release -o /app/publish /p:UseAppHost=false

# Stage 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app

# คัดลอกไฟล์จาก stage ก่อนหน้า
COPY --from=build /app/publish .

# เปิดพอร์ต 80
EXPOSE 80

# รันแอป
ENTRYPOINT ["dotnet", "WebApplication1.dll"]
