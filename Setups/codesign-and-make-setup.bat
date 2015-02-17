@echo off
setlocal EnableDelayedExpansion
for /F "tokens=1,2 delims=#" %%a in ('"prompt #$H#$E# & echo on & for %%b in (1) do rem"') do (
  set "DEL=%%a"
)

for /f "tokens=*" %%a in ('sigcheck.exe /accepteula /q /n ..\miniConf\bin\Release\miniConf.exe') do (
	set VERSION=%%a
)
set SHORTVER=%VERSION:~0,-2%
set INSTALLER=miniconf-%SHORTVER%.exe

echo.
echo Step 1 - Version Number
echo.
call :color 2f "Version:         %VERSION%"
echo.
echo Installer EXE:   %INSTALLER%
echo.
echo Is this the correct version number? Please double-check...
if exist "%INSTALLER%" (
    echo.
    call :color 4f "WARNING: An installer with this name does already exist, "
    echo.
    call :color 4f " it will be overwritten       "
    echo.
    echo.
)
echo.
pause

echo.
echo Step 2 - Code Signing...
CALL codesign-dragdrop.bat ..\miniConf\bin\Release\miniConf.exe

echo.
echo Step 3 - Making Installer...
"C:\Program Files (x86)\NSIS\Bin\makensis.exe" ..\miniconf-setup.nsi

echo.
echo Step 4 - Code Sign Installer...
CALL codesign-dragdrop.bat %INSTALLER%


echo.
echo Step 4 - Uploading as minefield...
"C:\Program Files (x86)\Git\bin\scp.exe" %INSTALLER% maxweller@cherry.luelista.net:/srv/hosts/luelista.net/downloads.luelista.net/miniconf/miniconf-minefield-setup.exe



echo.
echo Done.
echo.
pause

exit /b

:color
rem Prepare a file "X" with only one dot
<nul > X set /p ".=."
set "param=^%~2" !
set "param=!param:"=\"!"
findstr /p /A:%1 "." "!param!\..\X" nul
<nul set /p ".=%DEL%%DEL%%DEL%%DEL%%DEL%%DEL%%DEL%"
del X
exit /b