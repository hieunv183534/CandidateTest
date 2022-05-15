#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.
# Dockerfile

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["CandidateTest.Api/CandidateTest.Api.csproj", "CandidateTest.Api/"]
COPY ["CandidateTest.Core/CandidateTest.Core.csproj", "CandidateTest.Core/"]
COPY ["CandidateTest.Infrastructure/CandidateTest.Infrastructure.csproj", "CandidateTest.Infrastructure/"]
RUN dotnet restore "CandidateTest.Api/CandidateTest.Api.csproj"
COPY . .
WORKDIR "/src/CandidateTest.Api"
RUN dotnet build "CandidateTest.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CandidateTest.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CandidateTest.Api.dll"]