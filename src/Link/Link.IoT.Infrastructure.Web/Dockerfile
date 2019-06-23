FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["Link.IoT.Infrastructure.Web/Link.IoT.Infrastructure.Web.csproj", "Link.IoT.Infrastructure.Web/"]
RUN dotnet restore "Link.IoT.Infrastructure.Web/Link.IoT.Infrastructure.Web.csproj"
COPY . .
WORKDIR "/src/Link.IoT.Infrastructure.Web"
RUN dotnet build "Link.IoT.Infrastructure.Web.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Link.IoT.Infrastructure.Web.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Link.IoT.Infrastructure.Web.dll"]