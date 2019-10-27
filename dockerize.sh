#!/bin/bash
export VERSION=$(git tag --sort=-version:refname | head -1)
docker build --no-cache -f ./Source/Head/Dockerfile -t dolittle/timeseries-upstreamer . --build-arg CONFIGURATION="Release"
docker tag dolittle/timeseries-upstreamer dolittle/upstreamer:$VERSION
docker push dolittle/timeseries-upstreamer
docker push dolittle/timeseries-upstreamer:$VERSION