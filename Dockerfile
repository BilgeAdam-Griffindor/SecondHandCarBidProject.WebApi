#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["SecondHandCarBidProject.WebApi/SecondHandCarBidProject.WebApi.csproj", "SecondHandCarBidProject.WebApi/"]
COPY ["SecondHandCarBidProject.Business/SecondHandCarBidProject.Business.csproj", "SecondHandCarBidProject.Business/"]
COPY ["SecondHandCarBidProject.DataAccess/SecondHandCarBidProject.DataAccess.csproj", "SecondHandCarBidProject.DataAccess/"]
COPY ["SecondHandCarBidProject.Common/SecondHandCarBidProject.Common.csproj", "SecondHandCarBidProject.Common/"]
COPY ["SecondHandCarBidProject.Logs/SecondHandCarBidProject.Logs.csproj", "SecondHandCarBidProject.Logs/"]
RUN dotnet restore "SecondHandCarBidProject.WebApi/SecondHandCarBidProject.WebApi.csproj"
COPY . .
WORKDIR "/src/SecondHandCarBidProject.WebApi"
RUN dotnet build "SecondHandCarBidProject.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SecondHandCarBidProject.WebApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SecondHandCarBidProject.WebApi.dll"]