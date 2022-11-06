FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /source
COPY ["src/SimpleCRUD/SimpleCRUD.csproj", "src/SimpleCRUD/"]
RUN dotnet restore "src/SimpleCRUD/SimpleCRUD.csproj"
COPY . .
WORKDIR "/source/src/SimpleCRUD"
RUN dotnet build "SimpleCRUD.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SimpleCRUD.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SimpleCRUD.dll"]
