#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Test-api-ns/Test-api-ns.csproj", "Test-api-ns/"]
RUN dotnet restore "Test-api-ns/Test-api-ns.csproj"
COPY . .
WORKDIR "/src/Test-api-ns"
RUN dotnet build "Test-api-ns.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Test-api-ns.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
# ENTRYPOINT ["dotnet", "Test-api-ns.dll"]
CMD ASPNETCORE_URLS=http://*:$PORT dotnet Test-api-ns.dll