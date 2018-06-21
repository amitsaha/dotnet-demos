## Copy files and directories from Docker containers

Specify a single file:

```
$ dotnet run -- 8a8d6e9211f9 C:\app\Scripts\File.sql
```

Or a directory:

```
$ dotnet run -- 8a8d6e9211f9 C:\app\Scripts
```

Script0304 - RemoveSourcesAndUses.sql

## TODO:

[] Write as a proper console app (https://samyn.co/post/creating-neat-net-core-console-apps/)
[] Test on Linux/OS X/Windows Server
[] Extract the tar contents?
[] Option for specifying docker socket (with some default guesses for OS)
