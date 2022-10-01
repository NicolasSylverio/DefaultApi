#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/DefaultPoc.Api/DefaultPoc.Api.csproj", "src/DefaultPoc.Api/"]
COPY ["src/DefaultPoc.Application/DefaultPoc.Application.csproj", "src/DefaultPoc.Application/"]
COPY ["src/DefaultPoc.Domain/DefaultPoc.Domain.csproj", "src/DefaultPoc.Domain/"]
COPY ["src/DefaultPoc.Infrastructure/DefaultPoc.Infrastructure.csproj", "src/DefaultPoc.Infrastructure/"]
RUN dotnet restore "src/DefaultPoc.Api/DefaultPoc.Api.csproj"
COPY . .
WORKDIR "/src/src/DefaultPoc.Api"
RUN dotnet build "DefaultPoc.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DefaultPoc.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DefaultPoc.Api.dll"]