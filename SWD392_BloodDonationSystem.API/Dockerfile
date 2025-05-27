FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["SWD392_BloodDonationSystem.API/SWD392_BloodDonationSystem.API.csproj", "SWD392_BloodDonationSystem.API/"]
COPY ["SWD392_BloodDonationSystem.BLL/SWD392_BloodDonationSystem.BLL.csproj", "SWD392_BloodDonationSystem.BLL/"]
COPY ["SWD392_BloodDonationSystem.DAL/SWD392_BloodDonationSystem.DAL.csproj", "SWD392_BloodDonationSystem.DAL/"]
RUN dotnet restore "SWD392_BloodDonationSystem.API/SWD392_BloodDonationSystem.API.csproj"
COPY . .
WORKDIR "/src/SWD392_BloodDonationSystem.API"
RUN dotnet build "SWD392_BloodDonationSystem.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "SWD392_BloodDonationSystem.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SWD392_BloodDonationSystem.API.dll"]
