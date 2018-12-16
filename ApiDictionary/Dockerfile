FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["ApiDictionary/ApiDictionary.csproj", "ApiDictionary/"]
RUN dotnet restore "ApiDictionary/ApiDictionary.csproj"
COPY . .
WORKDIR "/src/ApiDictionary"
RUN dotnet build "ApiDictionary.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "ApiDictionary.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "ApiDictionary.dll"]