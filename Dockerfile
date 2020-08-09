FROM mcr.microsoft.com/dotnet/core/aspnet:2.1 AS base
WORKDIR /app
EXPOSE 5051
FROM mcr.microsoft.com/dotnet/core/sdk:2.1 AS build
WORKDIR /src

COPY *.csproj ./
RUN dotnet restore "Effid.csproj"
WORKDIR "/src/effid"
COPY . .
WORKDIR "/src/effid"
RUN dotnet build "Effid.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Effid.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .

ENTRYPOINT ["dotnet", "Effid.dll"]
