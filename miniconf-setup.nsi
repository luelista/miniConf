!include MUI2.nsh
!addplugindir .\setups

!define VERSION "1.5"

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

  File "miniConf\bin\Release\miniConf.exe"
  File "miniConf\bin\Release\*.dll"
  File "miniConf\bin\Release\*.txt"
  
  CreateShortcut "$DESKTOP\miniConf.lnk" "$INSTDIR\miniConf.exe"
  CreateShortcut "$SMPROGRAMS\miniConf.lnk" "$INSTDIR\miniConf.exe"
  WriteUninstaller "$INSTDIR\Uninstall.exe"
  
  WriteRegStr HKEY_CURRENT_USER "Software\Microsoft\Windows\CurrentVersion\Run" "miniConf" "$INSTDIR\miniConf.exe /autostart"

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
  
  DeleteRegKey HKCU "Software\miniConf"
  DeleteRegValue HKEY_CURRENT_USER "Software\Microsoft\Windows\CurrentVersion\Run" "miniConf"

SectionEnd




