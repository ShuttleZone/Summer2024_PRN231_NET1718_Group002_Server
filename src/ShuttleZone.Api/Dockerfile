FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

RUN apt-get update && apt-get install -y libkrb5-3

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["Directory.Build.props", "Directory.Build.props"]
COPY ["Directory.Packages.props", "Directory.Packages.props"]
COPY ["src/ShuttleZone.Api/ShuttleZone.Api.csproj", "src/ShuttleZone.Api/"]
COPY ["src/ShuttleZone.Application/ShuttleZone.Application.csproj", "src/ShuttleZone.Application/"]
COPY ["src/ShuttleZone.DAL/ShuttleZone.DAL.csproj", "src/ShuttleZone.DAL/"]
COPY ["src/ShuttleZone.Common/ShuttleZone.Common.csproj", "src/ShuttleZone.Common/"]
COPY ["src/ShuttleZone.Infrastructure/ShuttleZone.Infrastructure.csproj", "src/ShuttleZone.Infrastructure/"]
COPY ["src/ShuttleZone.Domain/ShuttleZone.Domain.csproj", "src/ShuttleZone.Domain/"]
RUN dotnet restore "src/ShuttleZone.Api/ShuttleZone.Api.csproj"
COPY . .
WORKDIR "/src/src/ShuttleZone.Api"
RUN dotnet build "ShuttleZone.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ShuttleZone.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ShuttleZone.Api.dll"]
