FROM microsoft/aspnetcore

ADD app /app

WORKDIR /app

ENTRYPOINT ["dotnet", "DzStudentPartners.Api.dll"]