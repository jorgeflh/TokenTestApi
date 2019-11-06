FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["TokenTestApi/TokenTestApi.csproj", "TokenTestApi/"]
RUN dotnet restore "TokenTestApi/TokenTestApi.csproj"
COPY . .
WORKDIR "/src/TokenTestApi"
RUN dotnet build "TokenTestApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TokenTestApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TokenTestApi.dll"]