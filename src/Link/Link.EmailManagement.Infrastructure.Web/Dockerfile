FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["Link.EmailManagement.Infrastructure.Web/Link.EmailManagement.Infrastructure.Web.csproj", "Link.EmailManagement.Infrastructure.Web/"]
RUN dotnet restore "Link.EmailManagement.Infrastructure.Web/Link.EmailManagement.Infrastructure.Web.csproj"
COPY . .
WORKDIR "/src/Link.EmailManagement.Infrastructure.Web"
RUN dotnet build "Link.EmailManagement.Infrastructure.Web.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Link.EmailManagement.Infrastructure.Web.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Link.EmailManagement.Infrastructure.Web.dll"]