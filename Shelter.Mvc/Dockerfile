FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS build-env
WORKDIR /app

COPY . ./
RUN dotnet publish Shelter.mvc -c Release -o out

FROM mcr.microsoft.com/dotnet/core/aspnet:2.2
WORKDIR /app
COPY --from=build-env /app/Shelter.mvc/out .

ENTRYPOINT ["dotnet", "Shelter.mvc.dll"]