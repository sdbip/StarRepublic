#!/bin/bash
dotnet publish -o publish/ SpotifyRecommendations
pushd publish > /dev/null
dotnet SpotifyRecommendations.dll
popd > /dev/null
