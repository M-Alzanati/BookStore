FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS build-env
WORKDIR ./src


COPY *.csproj ./
RUN dotnet restore


COPY . ./
RUN dotnet publish -c Release -o out


FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /src
COPY --from=build-env /src/out .
ENTRYPOINT ["dotnet", "aspnetapp.dll"]
