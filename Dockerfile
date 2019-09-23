FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY . .
RUN dotnet restore "WorkbookTest/WorkbookTest.csproj"
WORKDIR /src/WorkbookTest
RUN dotnet build "WorkbookTest.csproj" -c Release -o /app

FROM build AS publish
RUN apt-get install curl && curl -sL https://deb.nodesource.com/setup_12.x | bash - && apt-get install && apt-get install nodejs
WORKDIR /src/WorkbookTest/ClientApp
RUN npm i
WORKDIR /src/WorkbookTest
RUN dotnet publish "WorkbookTest.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
COPY WorkbookTest/aspnetapp.pfx .

RUN apt-get update
# RUN apt-get install -y --allow-unauthenticated libgdiplus
RUN apt-get install -y libc6-dev libgdiplus

ENTRYPOINT ["dotnet", "WorkbookTest.dll"]
