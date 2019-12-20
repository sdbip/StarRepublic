#!/bin/bash
dotnet publish -o publish/ SpotifyRecommendations
pushd publish > /dev/null
./SpotifyRecommendations
popd > /dev/null
