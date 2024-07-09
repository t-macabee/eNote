FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
EXPOSE 5256
ENV ASPNETCORE_URLS=http://+:5256

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY . .

FROM build AS publish
RUN dotnet publish "eNote.API/eNote.API.csproj" -c Release -o /app

FROM base as final
WORKDIR /app
COPY --from=publish /app .

ENTRYPOINT ["dotnet", "eNote.API.dll"]