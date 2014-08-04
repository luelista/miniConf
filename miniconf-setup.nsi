!include MUI2.nsh

Name "miniConf"
OutFile "setups\miniconf-1.0.exe"
InstallDir "$PROGRAMFILES\miniConf"
InstallDirRegKey HKCU "Software\miniConf" "NSISInstallDir"
RequestExecutionLevel admin

ShowInstDetails show

!insertmacro MUI_PAGE_LICENSE "InstallerReadme.txt"
!insertmacro MUI_PAGE_COMPONENTS
!insertmacro MUI_PAGE_INSTFILES

  !insertmacro MUI_UNPAGE_CONFIRM
  !insertmacro MUI_UNPAGE_INSTFILES
  
  !insertmacro MUI_LANGUAGE "English"

Section "Program Files" SecProgFiles
  SetOutPath "$INSTDIR"
  
  File "miniConf\bin\Release\miniConf.exe"
  File "miniConf\bin\Release\*.dll"
  File "miniConf\bin\Release\*.txt"
  
  CreateShortcut "$DESKTOP\miniConf.lnk" "$INSTDIR\miniConf.exe"
  CreateShortcut "$SMPROGRAMS\miniConf.lnk" "$INSTDIR\miniConf.exe"
  WriteUninstaller "$INSTDIR\Uninstall.exe"
  
  WriteRegStr HKEY_CURRENT_USER "Software\Microsoft\Windows\CurrentVersion\Run" "miniConf" "$INSTDIR\miniConf.exe"
SectionEnd

Section "Uninstall"
  
  Delete "$INSTDIR\*.exe"
  Delete "$INSTDIR\*.dll"
  Delete "$INSTDIR\*.txt"
  RMDir "$INSTDIR"
  Delete "$DESKTOP\miniConf.lnk"
  Delete "$SMPROGRAMS\miniConf.lnk"
  
  DeleteRegKey HKCU "Software\miniConf"
  DeleteRegValue HKEY_CURRENT_USER "Software\Microsoft\Windows\CurrentVersion\Run" "miniConf"

SectionEnd




