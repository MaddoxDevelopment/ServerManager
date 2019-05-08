FROM microsoft/dotnet:2.2-aspnetcore-runtime
COPY ./publish /publish
WORKDIR /publish
EXPOSE 80
ENTRYPOINT ["dotnet", "ServerManager.dll"]
