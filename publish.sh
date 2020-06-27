#!/bin/bash

# Copy deploy folder contents
mkdir ./_publish
cp -r ./.deploy/* ./_publish/

# Publish Students Api
cd SampleMicroserviceSchool.Students.Api
dotnet publish -c Release -o ../_publish/student --self-contained false
cd ..

# Publish Income Api
cd SampleMicroserviceSchool.Income.Api
dotnet publish -c Release -o ../_publish/income --self-contained false
cd ..

# Publish UI
cd SampleMicroserviceSchool.UI
npm install
npm run build
cd ..

# compress publishes
#zip -r /tmp/publish/deploy.zip /tmp/publish

echo Publish finished successfully
