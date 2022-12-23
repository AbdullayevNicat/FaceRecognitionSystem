#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["SchoolFaceRecognition.API/SchoolFaceRecognition.API.csproj", "SchoolFaceRecognition.API/"]
COPY ["SchoolFaceRecognition.BL/SchoolFaceRecognition.BL.csproj", "SchoolFaceRecognition.BL/"]
COPY ["SchoolFaceRecognition.Core/SchoolFaceRecognition.Core.csproj", "SchoolFaceRecognition.Core/"]
COPY ["SchoolFaceRecognition.SharedLibrary/SchoolFaceRecognition.SharedLibrary.csproj", "SchoolFaceRecognition.SharedLibrary/"]
COPY ["SchoolFaceRecognition.DAL/SchoolFaceRecognition.DAL.csproj", "SchoolFaceRecognition.DAL/"]
RUN dotnet restore "SchoolFaceRecognition.API/SchoolFaceRecognition.API.csproj"
COPY . .
WORKDIR "/src/SchoolFaceRecognition.API"
RUN dotnet build "SchoolFaceRecognition.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SchoolFaceRecognition.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SchoolFaceRecognition.API.dll"]