FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 8004

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["nlp.finance.vanguard/nlp.finance.vanguard.csproj", "nlp.finance.vanguard/"]
COPY ["nlp.finance.vanguard.data/nlp.finance.vanguard.data.csproj", "nlp.finance.vanguard.data/"]
COPY ["nlp.finance.vanguard.services/nlp.finance.vanguard.services.csproj", "nlp.finance.vanguard.services/"]
RUN dotnet restore "nlp.finance.vanguard/nlp.finance.vanguard.csproj"
COPY . .
WORKDIR "/src/nlp.finance.vanguard"
RUN dotnet build "nlp.finance.vanguard.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "nlp.finance.vanguard.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "nlp.finance.vanguard.dll"]