FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["Link.UserManagement.Infrastructure.Web/Link.UserManagement.Infrastructure.Web.csproj", "Link.UserManagement.Infrastructure.Web/"]
RUN dotnet restore "Link.UserManagement.Infrastructure.Web/Link.UserManagement.Infrastructure.Web.csproj"
COPY . .
WORKDIR "/src/Link.UserManagement.Infrastructure.Web"
RUN dotnet build "Link.UserManagement.Infrastructure.Web.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Link.UserManagement.Infrastructure.Web.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Link.UserManagement.Infrastructure.Web.dll"]