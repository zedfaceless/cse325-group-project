# 1. Compilation stage
FROM ://microsoft.com AS build
WORKDIR /src
COPY . .
RUN dotnet restore
RUN dotnet publish -c Release -o /app/publish

# 2. Execution stage
FROM ://microsoft.com AS final
WORKDIR /app
COPY --from=build /app/publish .

# Port 10000 required
ENV ASPNETCORE_URLS=http://+:10000
EXPOSE 10000

ENTRYPOINT ["dotnet", "cse325-group-project.dll"]
