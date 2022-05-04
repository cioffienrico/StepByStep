#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["StepByStep.WebApi/StepByStep.WebApi.csproj", "StepByStep.WebApi/"]
COPY ["StepByStep.Application/StepByStep.Application.csproj", "StepByStep.Application/"]
COPY ["StepByStep.Domain/StepByStep.Domain.csproj", "StepByStep.Domain/"]
COPY ["StepByStep.Infrastructure/StepByStep.Infrastructure.csproj", "StepByStep.Infrastructure/"]
RUN dotnet restore "StepByStep.WebApi/StepByStep.WebApi.csproj"
COPY . .
WORKDIR "/src/StepByStep.WebApi"
RUN dotnet build "StepByStep.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "StepByStep.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "StepByStep.WebApi.dll"]