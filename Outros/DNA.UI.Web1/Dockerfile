FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["DNA.UI.Web/DNA.UI.Web.csproj", "DNA.UI.Web/"]
RUN dotnet restore "DNA.UI.Web/DNA.UI.Web.csproj"
COPY . .
WORKDIR "/src/DNA.UI.Web"
RUN dotnet build "DNA.UI.Web.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "DNA.UI.Web.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "DNA.UI.Web.dll"]