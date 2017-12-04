REM 2017.11.18
echo off
set xcp="\Windows\System32\xcopy"
set ketsrc=%HOMEPATH%\Desktop\ketcindyfolder
NET SESSION > NUL 2>&1
if %ERRORLEVEL% == 0 (
  echo Running as administator
  set admin="y"
) else (
  echo Running as non-administator
  echo If you are an administrator, rerun as adminstrator
  set admin="n"
)
echo 1. C:\kettex\texlive (default)
echo 2. C:\texlive
echo 3. C:\w32tex
echo 4. other path of texlive
echo 5. other path of w32tex
set /P ans="Choose path of TeX (number): "
if "%ans%" == "1" (
  set pathT=C:\kettex
  set kind=\texlive
)
if "%ans%" == "2" (
  set pathT=C:
  set kind=\texlive
)
if "%ans%" == "3" (
  set pathT=C:
  set kind=\w32tex
)
if "%ans%" == "4" (
  set /P pathT="Input the path (ex) C:\tex: "
  set kind=\texlive
)
if "%ans%" == "5" (
  set /P pathT="Input the path (ex) C:\tex: "
  set kind=\w32tex
)
if "%kind%" == "\texlive" (
  set bin=\bin\win32
  set scripts=\texmf-dist\scripts\ketcindy
  set styles=\texmf-dist\tex\latex\ketcindy
) else (
  set bin=\bin
  set scripts=\share\texmf-dist\scripts\ketcindy
  set styles=\share\texmf-dist\tex\latex\ketcindy
)
set /P STR_INPUT="Do you really copy ketcindy? (y,n):"
if "%STR_INPUT%" == "y" (
  if exist "%pathT%%kind%%scripts%\." (
    echo Deleting "%pathT%%kind%%scripts%"
    rd /s "%pathT%%kind%%scripts%"
  )
  echo Copying ketcindy
  %xcp% /Y /Q /S /E /R "%ketsrc%\scripts\*.*" "%pathT%%kind%%scripts%\"
)
set stylesrc=misc\ketpicstyle\ketcindy
set /P STR_INPUT="Do you copy ketcindystyle? (y,n):"
if "%STR_INPUT%" == "y" (
  if exist "%pathT%%kind%%styles%\." (
    echo Deleting "%pathT%%kind%%styles%"
    rd /s "%pathT%%kind%%styles%"
  )
  echo Copying ketcindy styles
  %xcp% /Y /Q /S /E /R "%ketsrc%\%stylesrc%\*.*" "%pathT%%kind%%styles%\"
  "%pathT%\%kind%%bin%\mktexlsr"
)
pause
