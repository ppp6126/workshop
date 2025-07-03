# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# คัดลอกไฟล์ csproj แล้ว restore dependencies
COPY *.csproj ./
RUN dotnet restore

# คัดลอกไฟล์ทั้งหมดและ build
COPY . ./
RUN dotnet publish -c Release -o /app/publish /p:UseAppHost=false

# Stage 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app

# คัดลอกไฟล์ที่ build มาใน stage ก่อนหน้า
COPY --from=build /app/publish .

# เปิดพอร์ต 80 (Azure App Service จะใช้พอร์ตนี้โดยดีฟอลต์)
EXPOSE 80

# คำสั่งรันแอป
ENTRYPOINT ["dotnet", "WebApplication1.dll"]
