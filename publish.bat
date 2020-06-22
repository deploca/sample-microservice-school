:: Build all projects
rmdir /s /q _publish
mkdir _publish

:: Copy Deploca folder contents
xcopy .deploy _publish /E

:: Publish Students Api
pushd SampleMicroserviceSchool.Students.Api
dotnet publish -c Release -o ..\_publish\student --self-contained false --no-restore
popd

:: Publish Income Api
pushd SampleMicroserviceSchool.Income.Api
dotnet publish -c Release -o ..\_publish\income --self-contained false --no-restore
popd

:: Publish UI
pushd SampleMicroserviceSchool.UI
npm run build
popd

ECHO Publish finished successfully