# FROM microsoft/dotnet-nightly:2.1-sdk AS build-env
FROM microsoft/dotnet:2.0-sdk AS build-env
WORKDIR /app

COPY *.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out

# Build runtime image
# FROM microsoft/dotnet-nightly:2.1-runtime-alpine
FROM microsoft/dotnet:2.0.0-runtime-stretch-arm32v7
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "Effid.dll"]
