#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["CalculoMonetarioApi/CalculoMonetarioApi.csproj", "CalculoMonetarioApi/"]
COPY ["CalculoMonetarioApi.Infraestrutura/CalculoMonetarioApi.Infraestrutura.csproj", "CalculoMonetarioApi.Infraestrutura/"]
COPY ["CaulculoMonetarioApi.Negocio/CaulculoMonetarioApi.Negocio.csproj", "CaulculoMonetarioApi.Negocio/"]
RUN dotnet restore "CalculoMonetarioApi/CalculoMonetarioApi.csproj"
COPY . .
WORKDIR "/src/CalculoMonetarioApi"
RUN dotnet build "CalculoMonetarioApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CalculoMonetarioApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CalculoMonetarioApi.dll"]