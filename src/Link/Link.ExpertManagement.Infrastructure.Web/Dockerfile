#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM microsoft/dotnet:2.2-aspnetcore-runtime-nanoserver-1803 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk-nanoserver-1803 AS build
WORKDIR /src
COPY ["Link.ExpertManagement.Infrastructure.Web/Link.ExpertManagement.Infrastructure.Web.csproj", "Link.ExpertManagement.Infrastructure.Web/"]
RUN dotnet restore "Link.ExpertManagement.Infrastructure.Web/Link.ExpertManagement.Infrastructure.Web.csproj"
COPY . .
WORKDIR "/src/Link.ExpertManagement.Infrastructure.Web"
RUN dotnet build "Link.ExpertManagement.Infrastructure.Web.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Link.ExpertManagement.Infrastructure.Web.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Link.ExpertManagement.Infrastructure.Web.dll"]