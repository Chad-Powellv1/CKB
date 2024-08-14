FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["CKB.Api/CKB.Api.csproj", "CKB.Api/"]
COPY ["CKB.Application/CKB.Application.csproj", "CKB.Application/"]
COPY ["CKB.Domain/CKB.Domain.csproj", "CKB.Domain/"]
COPY ["CKB.Infrastructure/CKB.Infrastructure.csproj", "CKB.Infrastructure/"]

RUN dotnet restore "CKB.Api/CKB.Api.csproj"
COPY . .
WORKDIR "/src/CKB.Api"
RUN dotnet build "CKB.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CKB.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENV ASPNETCORE_FORWARDERHEADERS_ENABLED=true
ENTRYPOINT [ "dotnet", "CKB.Api.dll" ]