﻿FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["MVC/MVC.csproj", "MVC/"]
RUN dotnet restore "MVC/MVC.csproj"
COPY . .
WORKDIR "/src/MVC"
RUN dotnet build "MVC.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MVC.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MVC.dll"]
