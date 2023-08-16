FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Services/Services.PlayerRating/Services.PlayerRating.csproj", "Services.PlayerRating/"]
COPY ["Services/Services.PlayerRating.BLL/Services.PlayerRating.BLL.csproj", "Services.PlayerRating.BLL/"]
COPY ["Services/Services.PlayerRating.DAL.Interfaces/Services.PlayerRating.DAL.Interfaces.csproj", "Services.PlayerRating.DAL.Interfaces/"]
COPY ["Services/Services.PlayerRating.BLL.Interfaces/Services.PlayerRating.BLL.Interfaces.csproj", "Services.PlayerRating.BLL.Interfaces/"]
RUN dotnet restore "Services/Services.PlayerRating/Services.PlayerRating.csproj"
COPY . .
WORKDIR "/src/Services.PlayerRating"
RUN dotnet build "Services.PlayerRating.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Services.PlayerRating.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Services.PlayerRating.dll"]
