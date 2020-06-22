#!/bin/bash

# Copy deploy folder contents
mkdir /tmp/Publish
cp -r .deploy/* /tmp/publish/

# Publish Students Api
cd SampleMicroserviceSchool.Students.Api
dotnet publish -c Release -o /tmp/publish/student --self-contained false --no-restore
cd ..

# Publish Income Api
cd SampleMicroserviceSchool.Income.Api
dotnet publish -c Release -o /tmp/publish/income --self-contained false --no-restore
cd ..

# Publish UI
cd SampleMicroserviceSchool.UI
npm run build
cd ..

# compress publishes
zip -r /tmp/publish/deploy.zip /tmp/publish

echo Publish finished successfully