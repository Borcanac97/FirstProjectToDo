FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443


FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Web/PD.Workademy.ToDo.Web/PD.Workademy.ToDo.Web.csproj", "PD.Workademy.ToDo.Web"]
COPY ["src/Application/PD.Workademy.ToDo.Application/PD.Workademy.ToDo.Application.csproj", "PD.Workademy.ToDo.Application"]
COPY ["src/Domain/PD.Workademy.ToDo.Domain/PD.Workademy.ToDo.Domain.csproj","PD.Workademy.ToDo.Domain"]
COPY ["src/Infrastructure/PD.Workademy.ToDo.Infrastructure/PD.Workademy.ToDo.Infrastructure.csproj", "PD.Workademy.ToDo.Infrastructure"]
   

RUN dotnet restore "PD.Workademy.ToDo.Web"
COPY . .
WORKDIR src/Web/PD.Workademy.ToDo.Web
RUN dotnet build "PD.Workademy.ToDo.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PD.Workademy.ToDo.Web.csproj" -c Release -o /app/publish 

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PD.Workademy.ToDo.Web.dll"]