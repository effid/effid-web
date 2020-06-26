FROM mcr.microsoft.com/dotnet/core/sdk:2.1-stretch-arm32v7 as builder
ENV DOTNET_CLI_TELEMETRY_OPTOUT 1

WORKDIR /app

COPY . ./

RUN dotnet restore ./*.csproj

RUN dotnet publish -c release -o published -r linux-arm

FROM mcr.microsoft.com/dotnet/core/runtime:2.1-stretch-slim-arm32v7

WORKDIR /app
# COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "Effid.dll"]
