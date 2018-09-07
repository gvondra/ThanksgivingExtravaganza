FROM microsoft/aspnetcore:2.0 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0 AS build
WORKDIR /src
COPY ExtravaganzaAPI/ExtravaganzaAPI.csproj ExtravaganzaAPI/
COPY BusinessTier/Core/Core.csproj BusinessTier/Core/
COPY BusinessTier/Framework/Framework.csproj BusinessTier/Framework/
COPY DataTier/DataTier.Models/DataTier.Models.csproj DataTier/DataTier.Models/
COPY DataTier/DataTier.Client/DataTier.Client.csproj DataTier/DataTier.Client/
COPY BusinessTier/BusinessTier.Common/BusinessTier.Common.csproj BusinessTier/BusinessTier.Common/
RUN dotnet restore ExtravaganzaAPI/ExtravaganzaAPI.csproj
COPY . .
WORKDIR /src/ExtravaganzaAPI
RUN dotnet build ExtravaganzaAPI.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish ExtravaganzaAPI.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "ExtravaganzaAPI.dll"]
