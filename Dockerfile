# Build stage
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copiar los csproj (rutas relativas desde la raíz del contexto de build)
COPY HelloWorld/HelloWorld.csproj HelloWorld/
COPY HelloWorld.Core.Application/HelloWorld.Core.Application.csproj HelloWorld.Core.Application/

RUN dotnet restore HelloWorld/HelloWorld.csproj

# Copiar todo y publicar
COPY . .
RUN dotnet publish HelloWorld/HelloWorld.csproj -c Release -o /app/publish

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .
ENV ASPNETCORE_URLS=http://+:80
EXPOSE 80
ENTRYPOINT ["dotnet", "HelloWorld.dll"]