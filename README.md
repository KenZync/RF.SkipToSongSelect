# RF.SkipToSongSelect
 A BepInEx mod for RF that skips the Main Menu and sends you directly to Song Select.
 
 <a href="taikomodmanager:https://github.com/KenZync/RF.SkipToSongSelect"> <img src="Resources/InstallButton.png" alt="One-click Install using the Taiko Mod Manager" width="256"/> </a>
 
# Requirements
 Visual Studio 2022 or newer\
 Taiko: RF

# Build
 Install [BepInEx 6.0.0-pre.2](https://github.com/BepInEx/BepInEx/releases/tag/v6.0.0-pre.2) into your RF directory and launch the game.\
 This will generate all the dummy dlls in the interop folder that will be used as references.\
 Make sure you install the Unity.IL2CPP-win-x64 version.\
 Newer versions of BepInEx could have breaking API changes until the first stable v6 release, so those are not recommended at this time.
 
 Attempt to build the project, or copy the .csproj.user file from the Resources file to the same directory as the .csproj file.\
 Edit the .csproj.user file and place your RF file location in the "GameDir" variable.\
 Download or build the [SaveProfileManager](https://github.com/Deathbloodjr/RF.SaveProfileManager) mod, and place that dll full path in SaveProfileManagerPath.

Add BepInEx as a nuget package source (https://nuget.bepinex.dev/v3/index.json)