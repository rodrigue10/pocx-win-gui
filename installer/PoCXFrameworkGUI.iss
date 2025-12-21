; PoCX Framework Windows GUI - Inno Setup Script
; Installer for PoCX Miner GUI and Plotter GUI

#define MyAppVersion "1.0.0"
#define MyAppPublisher "Proof of Capacity Consortium"
#define MyAppName "PoCX Framework Windows GUI"
#define MyAppURL "https://github.com/PoC-Consortium/pocx"

#define MinerSource "..\PoCXMinerGUI\bin\Release\net10.0-windows\win-x64\publish"
#define PlotterSource "..\PoCXPlotterGUI\bin\Release\net10.0-windows\win-x64\publish"
#define CommonSource "..\PoCX.Common\bin\Release\net10.0"

[Setup]
; Unique application identifier
AppId={{7B8C9D0E-1F2A-3B4C-5D6E-7F8A9B0C1D2E}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
AppPublisher={#MyAppPublisher}
AppPublisherURL={#MyAppURL}
AppSupportURL={#MyAppURL}
AppUpdatesURL={#MyAppURL}/releases
DefaultDirName={autopf}\PoCX Framework
DefaultGroupName=PoCX Framework
AllowNoIcons=yes
OutputDir=output
OutputBaseFilename=PoCXFrameworkGUI-{#MyAppVersion}-Setup
SetupIconFile=..\pocx_icon.ico
Compression=lzma2
SolidCompression=yes
PrivilegesRequired=admin
WizardStyle=modern
UninstallDisplayIcon={app}\PoCXMinerGUI.exe
UsePreviousAppDir=yes

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked

[Files]
; Miner GUI
Source: "{#MinerSource}\PoCXMinerGUI.exe"; DestDir: "{app}"; Flags: ignoreversion
;Source: "{#MinerSource}\PoCXMinerGUI.exe.config"; DestDir: "{app}"; Flags: ignoreversion
; Note: miner config is downloaded from GitHub release to %LOCALAPPDATA%\PoCX

; Plotter GUI
Source: "{#PlotterSource}\PoCXPlotterGUI.exe"; DestDir: "{app}"; Flags: ignoreversion
;Source: "{#PlotterSource}\PoCXPlotterGUI.exe.config"; DestDir: "{app}"; Flags: ignoreversion

; Shared library
Source: "{#CommonSource}\PoCX.Common.dll"; DestDir: "{app}"; Flags: ignoreversion

; NuGet dependencies (from Miner as it has the most)
;Source: "{#MinerSource}\NBitcoin.dll"; DestDir: "{app}"; Flags: ignoreversion
;Source: "{#MinerSource}\Octokit.dll"; DestDir: "{app}"; Flags: ignoreversion
;Source: "{#MinerSource}\YamlDotNet.dll"; DestDir: "{app}"; Flags: ignoreversion

; Plotter-specific dependencies
;Source: "{#PlotterSource}\OpenCL.Net.dll"; DestDir: "{app}"; Flags: ignoreversion skipifsourcedoesntexist

; Icon
Source: "..\pocx_icon.ico"; DestDir: "{app}"; Flags: ignoreversion

[Icons]
Name: "{group}\PoCX Miner"; Filename: "{app}\PoCXMinerGUI.exe"; IconFilename: "{app}\pocx_icon.ico"
Name: "{group}\PoCX Plotter"; Filename: "{app}\PoCXPlotterGUI.exe"; IconFilename: "{app}\pocx_icon.ico"
Name: "{group}\{cm:UninstallProgram,{#MyAppName}}"; Filename: "{uninstallexe}"
Name: "{autodesktop}\PoCX Miner"; Filename: "{app}\PoCXMinerGUI.exe"; IconFilename: "{app}\pocx_icon.ico"; Tasks: desktopicon
Name: "{autodesktop}\PoCX Plotter"; Filename: "{app}\PoCXPlotterGUI.exe"; IconFilename: "{app}\pocx_icon.ico"; Tasks: desktopicon

; [Run] section removed - no launch options at end of installation

[Code]
{ Note: Config backup during install is not needed since configs are stored in
  %LOCALAPPDATA%\PoCX and the update manager handles backups when updating executables. }

procedure DeleteMatchingFolders(BaseDir, Pattern: string);
var
  FindRec: TFindRec;
  FolderPath: string;
begin
  if FindFirst(BaseDir + '\' + Pattern, FindRec) then
  begin
    try
      repeat
        if (FindRec.Attributes and FILE_ATTRIBUTE_DIRECTORY) <> 0 then
        begin
          if (FindRec.Name <> '.') and (FindRec.Name <> '..') then
          begin
            FolderPath := BaseDir + '\' + FindRec.Name;
            DelTree(FolderPath, True, True, True);
          end;
        end;
      until not FindNext(FindRec);
    finally
      FindClose(FindRec);
    end;
  end;
end;

procedure CurUninstallStepChanged(CurUninstallStep: TUninstallStep);
var
  LocalAppData: string;
begin
  if CurUninstallStep = usPostUninstall then
  begin
    LocalAppData := ExpandConstant('{localappdata}');

    // Remove downloaded executables and configs from %LOCALAPPDATA%\PoCX
    if DirExists(LocalAppData + '\PoCX') then
    begin
      DelTree(LocalAppData + '\PoCX', True, True, True);
    end;

    // Remove .NET user settings folders for both apps (direct in LocalAppData)
    DeleteMatchingFolders(LocalAppData, 'PoCXMinerGUI*');
    DeleteMatchingFolders(LocalAppData, 'PoCXPlotterGUI*');

    // Also clean up settings under Microsoft folder (legacy location)
    if DirExists(LocalAppData + '\Microsoft') then
    begin
      DeleteMatchingFolders(LocalAppData + '\Microsoft', 'PoCXMinerGUI*');
      DeleteMatchingFolders(LocalAppData + '\Microsoft', 'PoCXPlotterGUI*');
    end;

    // Clean up settings under Proof of Capacity Consortium folder (new location)
    if DirExists(LocalAppData + '\Proof of Capacity Consortium') then
    begin
      DelTree(LocalAppData + '\Proof of Capacity Consortium', True, True, True);
    end;
  end;
end;
