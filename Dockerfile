FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build-env
WORKDIR /

COPY / ./
RUN dotnet restore

COPY / ./
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /
COPY --from=build-env /out .
ENTRYPOINT ["dotnet", "BookStore.API.dll"]
