FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Services/Words.Game.Service/Words.Game.Service.csproj", "Words.Game.Service/"]
RUN dotnet restore "Services/Words.Game.Service/Words.Game.Service.csproj"
COPY . .
WORKDIR "/src/Words.Game.Service"
RUN dotnet build "Words.Game.Service.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Words.Game.Service.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Words.Game.Service.dll"]
