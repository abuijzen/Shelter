FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY ./Shelter.Mvc/Shelter.Mvc.csproj ./Shelter.Mvc/
COPY ./Shelter.Shared/Shelter.Shared.csproj ./Shelter.Shared/
RUN dotnet restore ~/Shelter.Mvc
RUN dotnet restore ~/Shelter.Shared

# Copy everything else and build
COPY ./Shelter.Mvc ./Shelter.Mvc
COPY ./Shelter.Shared ./Shelter.Shared
COPY ./Shelter.UnitTests ./Shelter.UnitTests
RUN dotnet publish ~/Shelter.Mvc -c Release -o out
RUN dotnet publish ~/Shelter.Shared -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:2.2
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "aspnetcoreapp.dll"]