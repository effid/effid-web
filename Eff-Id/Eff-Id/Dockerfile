FROM microsoft/dotnet:2.0-sdk as builder
ENV DOTNET_CLI_TELEMETRY_OPTOUT 1

WORKDIR /app

COPY . ./

RUN dotnet restore ./Effid.csproj

RUN dotnet publish -c release -o published -r linux-arm

FROM microsoft/dotnet:2.0.0-runtime-stretch-arm32v7
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "Effid.dll"]
