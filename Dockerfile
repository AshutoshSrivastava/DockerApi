# Get base image from Microsoft
FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
WORKDIR /app

# Copy the csproj file and retore any dependencies (via NUGET)
COPY *.csproj ./
RUN dotnet restore

# Copy the project files and build our release
COPY . ./
RUN dotnet publish -c Release -o out

# Generate runtime image
FROM mcr.microsoft.com/dotnet/core/sdk:3.1
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "DockerApi.dll"]
# EXPOSE 80

# docker build -t erashu/dockerapi .
# docker run -d -p 8080:80 --name dockerapi erashu/dockerapi
# 
# docker start containerId
# docker stop containerId