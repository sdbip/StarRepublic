# Work Sample for StarRepublic

This is a React.js application hosted by ASP .Net Core.
Developed on a Mac, but is expected to work equally well on Windows and Linux.

Tested in the following environment:

- Node.js version: 6.10.0
- Framework version: .Net Core 3.1.100 (full SDK)
- OS: macOS Catalina 10.15.2
  - (GitHub builds the application on Ubuntu Linux, but runs no tests.

## Launch instructions

From Visual Studio:

- Download [the .Net Core 3.1 runtime or SDK](https://dotnet.microsoft.com/download/dotnet-core/3.1) if you don't already have it.
- Open the .sln file in Visual Studio.
- Set SpotifyRecommendations as Startup Project.
- Start the debugger (or use the Start Without Debugging menu item).

From a Bash (Borne Again SHell) prompt if you want to avoid Visual Studio:

- Download [the .Net Core 3.1 runtime or SDK](https://dotnet.microsoft.com/download/dotnet-core/3.1) if you don't already have it.
- Open a Bash prompt in the repository root folder.
- Run `./launch.sh` It's a self-executable script.
