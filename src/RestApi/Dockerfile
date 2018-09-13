FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 53987
EXPOSE 44329

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["src/RestApi/RestApi.csproj", "src/RestApi/"]
RUN dotnet restore "src/RestApi/RestApi.csproj"
COPY . .
WORKDIR "/src/src/RestApi"
RUN dotnet build "RestApi.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "RestApi.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "RestApi.dll"]