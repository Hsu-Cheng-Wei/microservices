#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["GeekTime.Ordering.API/GeekTime.Ordering.API.csproj", "GeekTime.Ordering.API/"]
COPY ["GeekTime.Ordering.Infrastructure/GeekTime.Ordering.Infrastructure.csproj", "GeekTime.Ordering.Infrastructure/"]
COPY ["GeekTime.Orders.Domain/GeekTime.Ordering.Domain.csproj", "GeekTime.Orders.Domain/"]
COPY ["GeekTime.Domain.Abstractions/GeekTime.Domain.Abstractions.csproj", "GeekTime.Domain.Abstractions/"]
COPY ["GeekTime.Infrastructure.Core/GeekTime.Infrastructure.Core.csproj", "GeekTime.Infrastructure.Core/"]
RUN dotnet restore "GeekTime.Ordering.API/GeekTime.Ordering.API.csproj"
COPY . .
WORKDIR "/src/GeekTime.Ordering.API"
RUN dotnet build "GeekTime.Ordering.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GeekTime.Ordering.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GeekTime.Ordering.API.dll"]
