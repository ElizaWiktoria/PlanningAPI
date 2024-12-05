FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS buildbase
WORKDIR /src

COPY ["PlanningApi/PlanningApi.csproj", "PlanningApi/"]
RUN dotnet restore "PlanningApi/PlanningApi.csproj"
COPY . .
WORKDIR "/src/PlanningApi"

FROM buildbase as migrations
RUN dotnet tool install --version 8.0.8 --global dotnet-ef
ENV PATH="$PATH:/root/.dotnet/tools"
RUN dotnet-ef database update

FROM buildbase AS publish
RUN dotnet publish "PlanningApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app

COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PlanningApi.dll"]