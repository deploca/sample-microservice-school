FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
COPY . /app
WORKDIR /app
EXPOSE 80
ENTRYPOINT ["dotnet", "SampleMicroserviceSchool.Students.Api.dll"]