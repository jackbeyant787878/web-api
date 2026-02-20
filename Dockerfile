# 构建阶段：使用 SDK 镜像编译项目
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# 复制项目文件并还原依赖（利用 Docker 缓存）
COPY ["asp.net core 8.0 web api.csproj", "."]
RUN dotnet restore
# 复制所有源代码并发布
COPY . .
RUN dotnet publish -c Release -o /app/publish
# 运行时阶段：使用 ASP.NET 运行时镜像
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
EXPOSE 8080

# 从构建阶段复制发布好的文件
COPY --from=build /app/publish .
# 启动应用（注意 DLL 名称与项目名一致）
ENTRYPOINT ["dotnet", "asp.net core 8.0 web api.dll"]