FROM mcr.microsoft.com/dotnet/aspnet:6.0-focal AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0-focal AS build
WORKDIR /src
COPY ["src/WyrApi/WyrApi.csproj", "."]
RUN dotnet restore "WyrApi.csproj"
COPY src/WyrApi .
RUN dotnet build "WyrApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WyrApi.csproj" -c Release -o /app/publish /p:GenerateDocumentationFile=true

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "WyrApi.dll"]