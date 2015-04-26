!include MUI2.nsh
!addplugindir .\setups

!getdllversion "miniConf\bin\Release\miniConf.exe" progv_
  !define PROG_NAME "miniConf"
  !define VERSION "${progv_1}.${progv_2}.${progv_3}"

!define /date DATE "%Y-%m-%d %H:%M:%S"
!define /date VERDATE "%Y.%m%d.%H%M.%S"

Function LicensePageShow

FindWindow $R1 `#32770` `` $HWNDPARENT
GetDlgItem $R0 $R1 1000
System::Call 'USER32::SetWindowPos(i,i,i,i,i,i,i) b ($R0,0,0,0,410,225,0)'

GetDlgItem $R0 $R1 1006
ShowWindow $R0 ${SW_HIDE}
GetDlgItem $R0 $R1 1040
ShowWindow $R0 ${SW_HIDE}

FunctionEnd

Name "miniConf"
OutFile "setups\miniconf-${VERSION}.exe"

  VIProductVersion "${VERSION}.0" 
  VIFileVersion "${VERSION}.0" 
  VIAddVersionKey "ProductVersion" "${VERSION}.0"
  VIAddVersionKey "FileVersion" "${VERSION}.0"
  VIAddVersionKey "ProductName" "${PROG_NAME}"
  VIAddVersionKey "FileDescription" "Setup für ${PROG_NAME}"
  VIAddVersionKey "LegalCopyright" "Copyright (c) 2015 Max Weller"
  VIAddVersionKey "Comments" "${DATE}"
  VIAddVersionKey "OriginalFilename" "miniconf-${VERSION}.exe"
  VIAddVersionKey "LegalTrademarks" "Build time: ${DATE}"

InstallDir "$PROGRAMFILES\miniConf"
InstallDirRegKey HKCU "Software\miniConf" "NSISInstallDir"
RequestExecutionLevel admin

ShowInstDetails show

  !define MUI_PAGE_HEADER_TEXT "Welcome to the miniConf ${VERSION} installer"
  !define MUI_PAGE_HEADER_SUBTEXT "Please take note of the below readme file and license information"
  !define MUI_LICENSEPAGE_TEXT_TOP ""
  !define MUI_LICENSEPAGE_TEXT_BOTTOM "-	"
  !define MUI_LICENSEPAGE_BUTTON "Next"
  !define MUI_PAGE_CUSTOMFUNCTION_SHOW LicensePageShow
!insertmacro MUI_PAGE_LICENSE "InstallerReadme.txt"

!insertmacro MUI_PAGE_COMPONENTS
!insertmacro MUI_PAGE_INSTFILES

  !insertmacro MUI_UNPAGE_CONFIRM
  !insertmacro MUI_UNPAGE_INSTFILES
  
  !insertmacro MUI_LANGUAGE "English"


Section "Program Files" SecProgFiles 
  SectionIn RO

  SetOutPath "$INSTDIR"
  ExecWait "taskkill.exe /im miniConf.exe /f"
  Sleep 500

  File "miniConf\bin\Release\miniConf.exe"
  File "miniConf\bin\Release\*.dll"
  File "miniConf\bin\Release\*.txt"
  
  SetOutPath "$INSTDIR\Themes"
  File "miniConf\themes\*.txt"

  SetOutPath "$INSTDIR\Sounds"
  File "miniConf\Sounds\*.wav"

  SetOutPath "$INSTDIR\Source"
  File "miniConf\*.cs"
  File "miniConf\*.csproj"
  File "miniConf\*.resx"
  File "miniConf\Properties\*.cs"
  File "miniConf\Properties\*.resx"
  File "miniConf\Properties\*.settings"
  

  SetOutPath "$INSTDIR\Emoticons\Pidgin"
  File "Emoticons\Pidgin\*"

  CreateShortcut "$DESKTOP\miniConf.lnk" "$INSTDIR\miniConf.exe"
  CreateShortcut "$SMPROGRAMS\miniConf.lnk" "$INSTDIR\miniConf.exe"
  WriteUninstaller "$INSTDIR\Uninstall.exe"
  
  ; delete old autorun keys
  DeleteRegKey HKCU "Software\miniConf"
  DeleteRegValue HKEY_CURRENT_USER "Software\Microsoft\Windows\CurrentVersion\Run" "miniConf"

  WriteRegStr HKEY_LOCAL_MACHINE "Software\Microsoft\Windows\CurrentVersion\Run" "miniConf" "$INSTDIR\miniConf.exe /autostart"

  DetailPrint "Starting miniConf ..."
  ShellExecAsUser::ShellExecAsUser "open" '$INSTDIR\miniConf.exe' 
SectionEnd

Section "Uninstall"
  
  Delete "$INSTDIR\*.exe"
  Delete "$INSTDIR\*.dll"
  Delete "$INSTDIR\*.txt"
  RMDir "$INSTDIR"
  Delete "$DESKTOP\miniConf.lnk"
  Delete "$SMPROGRAMS\miniConf.lnk"
  
  DeleteRegKey HKLM "Software\miniConf"
  DeleteRegValue HKEY_LOCAL_MACHINE "Software\Microsoft\Windows\CurrentVersion\Run" "miniConf"

  DeleteRegKey HKCU "Software\miniConf"
  DeleteRegValue HKEY_CURRENT_USER "Software\Microsoft\Windows\CurrentVersion\Run" "miniConf"

SectionEnd




