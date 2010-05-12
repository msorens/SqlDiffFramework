; Script generated by the Inno Setup Script Wizard.
; $Id: SqlDiffFramework.iss 922 2010-04-28 03:40:45Z ww $
; SEE THE DOCUMENTATION FOR DETAILS ON CREATING INNO SETUP SCRIPT FILES!

#define MyAppName "SqlDiffFramework"
#define VSDir "C:\usr\ms\devel\Visual Studio 2008"
#define ProjectDir AddBackslash(VSDir) + AddBackslash("Projects") + MyAppName
#define LibraryDir AddBackslash(VSDir) + AddBackslash("Projects") + "CleanCode"
#define BinDir AddBackslash(ProjectDir) + AddBackslash(MyAppName) + "bin\Release"
#define InstallDir SourcePath
#define ChameleonRichTextBoxControlsDir AddBackslash(LibraryDir) + "ChameleonRichTextBoxControls"
#define DatabaseControlsDir AddBackslash(LibraryDir) + "DatabaseControls"
#define MyAppVersion GetFileVersion(AddBackslash(BinDir) + MyAppName + ".exe")
#define HomePage "http://SqlDiffFramework.codeplex.com/"

[Setup]
; NOTE: The value of AppId uniquely identifies this application.
; Do not use the same AppId value in installers for other applications.
; (To generate a new GUID, click Tools | Generate GUID inside the IDE.)
AppId={{19FA713B-2304-4E27-AF5D-E0B88981299A}
AppName={#MyAppName}
AppVerName={#MyAppName} {#MyAppVersion}
AppPublisher=CleanCode
AppPublisherURL={#HomePage}
AppSupportURL={#HomePage}Thread/List.aspx
AppUpdatesURL={#HomePage}releases
DefaultDirName={pf}\{#MyAppName}
DefaultGroupName={#MyAppName}
AllowNoIcons=true
LicenseFile={#InstallDir}\license.txt
InfoAfterFile={#InstallDir}\post-install.txt
OutputDir={#InstallDir}
OutputBaseFilename={#MyAppName} setup {#MyAppVersion}
Compression=lzma
SolidCompression=true
SourceDir={#BinDir}
VersionInfoVersion={#MyAppVersion}
VersionInfoCompany=CleanCode
VersionInfoDescription=Installer for {#MyAppName}
OutputManifestFile={#InstallDir}\{#MyAppName} manifest.txt
VersionInfoCopyright=(C) 2009-2010 Michael Sorens
AppCopyright=Copyright � 2009-2010 Michael Sorens
AppVersion={#MyAppVersion}

[Languages]
Name: english; MessagesFile: compiler:Default.isl

[Types]
Name: standard; Description: Install standard version
Name: large; Description: Install large address space version (option useful for WinXP only)

[Components]
Name: main; Description: Common Files; Types: standard large; Flags: fixed
Name: standardExe; Description: SqlDiffFramework standard version executable; Types: standard; Flags: fixed
Name: largeExe; Description: SqlDiffFramework large address space version executable; Types: large; Flags: fixed

[Tasks]
Name: desktopicon; Description: {cm:CreateDesktopIcon}; GroupDescription: {cm:AdditionalIcons}; Flags: unchecked
Name: quicklaunchicon; Description: {cm:CreateQuickLaunchIcon}; GroupDescription: {cm:AdditionalIcons}; Flags: unchecked

[Files]
Source: {#MyAppName}_LARGE.exe; DestDir: {app}; DestName: {#MyAppName}.exe; Components: largeExe; Flags: ignoreversion
Source: {#MyAppName}.exe; DestDir: {app}; Components: standardExe; Flags: ignoreversion
Source: {#MyAppName}.exe.config; DestDir: {app}; Flags: ignoreversion
Source: CleanCode.dll; DestDir: {app}; Flags: ignoreversion
Source: CleanCode.ChameleonRichTextBoxControls.dll; DestDir: {app}; Flags: ignoreversion
Source: CleanCode.CsvProcessing.dll; DestDir: {app}; Flags: ignoreversion
Source: CleanCode.DatabaseControls.dll; DestDir: {app}; Flags: ignoreversion
Source: CleanCode.DataGridViewControls.dll; DestDir: {app}; Flags: ignoreversion
Source: CleanCode.GeneralComponents.dll; DestDir: {app}; Flags: ignoreversion
Source: CleanCode.SqlEditorControls.dll; DestDir: {app}; Flags: ignoreversion
Source: Diff.dll; DestDir: {app}; Flags: ignoreversion
Source: Dpapi.dll; DestDir: {app}; Flags: ignoreversion
Source: HertelDifferenceEngine.dll; DestDir: {app}; Flags: ignoreversion
Source: LinqBridge.dll; DestDir: {app}; Flags: ignoreversion
Source: LumenWorks.Framework.IO.dll; DestDir: {app}; Flags: ignoreversion
Source: MySql.Data.dll; DestDir: {app}; Flags: ignoreversion
Source: OptionsLib.dll; DestDir: {app}; Flags: ignoreversion
Source: PotterDifferenceEngine.dll; DestDir: {app}; Flags: ignoreversion
Source: SearchableControls.dll; DestDir: {app}; Flags: ignoreversion
Source: SyntaxHighlightingTextBox.dll; DestDir: {app}; Flags: ignoreversion
; Source: System.Data.OracleClient.dll; DestDir: {app}; Flags: ignoreversion
Source: VDialog.dll; DestDir: {app}; Flags: ignoreversion
; NOTE: Don't use "Flags: ignoreversion" on any shared system files
Source: {#SourcePath}\license.txt; DestDir: {app}; Flags: ignoreversion
Source: {#DatabaseControlsDir}\Support\QueryLibrary.xsd; DestDir: {app}\XML Schema; Flags: ignoreversion
Source: {#ChameleonRichTextBoxControlsDir }\ResourceFiles\ContextDefinition.xsd; DestDir: {app}\XML Schema; Flags: ignoreversion

[Icons]
Name: {group}\{#MyAppName}; Filename: {app}\{#MyAppName}.exe
Name: {group}\{cm:ProgramOnTheWeb,{#MyAppName}}; Filename: {#HomePage}
Name: {group}\{cm:UninstallProgram,{#MyAppName}}; Filename: {uninstallexe}
Name: {commondesktop}\{#MyAppName}; Filename: {app}\{#MyAppName}.exe; Tasks: desktopicon
Name: {userappdata}\Microsoft\Internet Explorer\Quick Launch\{#MyAppName}; Filename: {app}\{#MyAppName}.exe; Tasks: quicklaunchicon

[Run]
Filename: {app}\{#MyAppName}.exe; Description: {cm:LaunchProgram,{#MyAppName}}; Flags: nowait postinstall skipifsilent