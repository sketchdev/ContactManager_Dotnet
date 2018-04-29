Download and install dotnet SDK/CLI
https://www.microsoft.com/net/download/windows

cd into the directory you want to work from.

git clone https://github.com/sketchdev/TMD_ContactManager_Dotnet .
(note the trailing period)

dotnet restore
dotnet build
dotnet test ContactManager_Tests
