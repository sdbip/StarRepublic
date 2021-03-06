﻿# Work Sample for StarRepublic

This is a React.js application hosted by ASP .Net Core.
Developed on a Mac, but is expected to work equally well on Windows and Linux.

Tested in the following environment:

- Node.js version: 6.10.0
- Framework version: .Net Core 3.1.100 (full SDK)
- OS: macOS Catalina 10.15.2
  - (GitHub builds the application on Ubuntu Linux, but runs no tests.

## Launch Instructions

From Visual Studio:

- Download [the .Net Core 3.1 runtime or SDK](https://dotnet.microsoft.com/download/dotnet-core/3.1) if you don't already have it.
- Open the .sln file in Visual Studio.
- Set SpotifyRecommendations as Startup Project.
- Start the debugger (or use the Start Without Debugging menu item).
- Open a browser to https://localhost:5001.

From a Bash (Borne Again SHell) prompt if you want to avoid Visual Studio:

- Download [the .Net Core 3.1 runtime or SDK](https://dotnet.microsoft.com/download/dotnet-core/3.1) if you don't already have it.
- Open a Bash prompt in the repository root folder.
- Run `./launch.sh` It's a self-executable script.
- Open a browser to https://localhost:5001.

## Usage Instructions

The UI is rather simple. It has three pages: the search page, the recommendations page and the about page. The about page is self explanatory. The recommendations page allows you to view recommended tracks, and to click on a track for further recommendations. The search page is more interesting.

There is a drop-down with some preset searches. When you select one, it poulates the search text field, so that you can see the format of the search string. You can then click the search button to see a list of matching artists or tracks. When you click an item in that list, you are redirected to the recommendations page. Other similar tracks.

You can also type in your own search. You can type in an artist name directly or on the format "artist: name". You can also type in "track: name" to search for a song.
