FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build

ARG BUILDCONFIG=Release
ARG VERSION=1.0.0

COPY ./Shelter.mvc/Shelter.mvc.csproj ./build/Shelter.mvc/
COPY ./Shelter.shared/Shelter.shared.csproj ./build/Shelter.shared/

RUN dotnet restore ./build/Shelter.mvc/Shelter.mvc.csproj

COPY . ./build/
WORKDIR /build/

RUN dotnet publish ./Shelter.mvc/Shelter.mvc.csproj -c ${BUILDCONFIG} -o out

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app

COPY --from=build /build/out .

ENTRYPOINT ["dotnet", "Shelter.mvc.dll"]