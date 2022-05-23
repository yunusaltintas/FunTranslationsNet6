FROM mcr.microsoft.com/dotnet/sdk:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["./Presentation/FunTranslation.Presentation/FunTranslation.Presentation.csproj", "Presentation/FunTranslation.Presentation/"]
COPY ["./Infrastructure/FunTranslation.Persistence/FunTranslation.Persistence.csproj", "Infrastructure/FunTranslation.Persistence/"]
COPY ["./Infrastructure/FunTranslation.Infrastructure/FunTranslation.Infrastructure.csproj", "Infrastructure/FunTranslation.Infrastructure/"]
COPY ["./Core/FunTranslation.Domain/FunTranslation.Domain.csproj", "Core/FunTranslation.Domain/"]
COPY ["./Core/FunTranslation.Application/FunTranslation.Application.csproj", "Core/FunTranslation.Application/"]

RUN dotnet restore "./Presentation/FunTranslation.Presentation/FunTranslation.Presentation.csproj"

COPY . .
WORKDIR "/src/Presentation/FunTranslation.Presentation"
RUN dotnet build "FunTranslation.Presentation.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FunTranslation.Presentation.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
CMD ASPNETCORE_URLS=http://*:$PORT dotnet FunTranslation.Presentation.dll
