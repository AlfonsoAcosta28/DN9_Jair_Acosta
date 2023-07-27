#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["GymMananger.Web/GymManager.Web.csproj", "GymMananger.Web/"]
COPY ["GymManager.ApplicationServices/GymManager.ApplicationServices.csproj", "GymManager.ApplicationServices/"]
COPY ["GymManager.ApplicationServices.Shared/GymManager.ApplicationServices.Shared.csproj", "GymManager.ApplicationServices.Shared/"]
COPY ["GymManager.Core/GymManager.Core.csproj", "GymManager.Core/"]
COPY ["GymManager.DataAcces/GymManager.DataAcces.csproj", "GymManager.DataAcces/"]
RUN dotnet restore "GymMananger.Web/GymManager.Web.csproj"
COPY . .
WORKDIR "/src/GymMananger.Web"
RUN dotnet build "GymManager.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GymManager.Web.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GymManager.Web.dll"]