# Acesse https://aka.ms/customizecontainer para saber como personalizar seu contêiner de depuração e como o Visual Studio usa este Dockerfile para criar suas imagens para uma depuração mais rápida.
# Base: runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8000
EXPOSE 8081
ENV ASPNETCORE_URLS=http://+:8000;http://+:8081;
ENV ASPNETCORE_ENVIRONMENT=Development

# Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["CadastroCliente.API/CadastroCliente.API.csproj", "CadastroCliente.API/"]
COPY ["CadastroCliente.Application/CadastroCliente.Application.csproj", "CadastroCliente.Application/"]
COPY ["CadastroCliente.Domain/CadastroCliente.Domain.csproj", "CadastroCliente.Domain/"]
COPY ["CadastroCliente.Infrastructure/CadastroCliente.Infrastructure.csproj", "CadastroCliente.Infrastructure/"]
RUN dotnet restore "./CadastroCliente.API/CadastroCliente.API.csproj"
COPY . .
WORKDIR "/src/CadastroCliente.API"
RUN dotnet build "./CadastroCliente.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Publish
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./CadastroCliente.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Final image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CadastroCliente.API.dll"]
