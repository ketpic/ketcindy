REM 20200505
echo off
set xcp="\Windows\System32\xcopy"

NET SESSION > NUL 2>&1
if %ERRORLEVEL% == 0 (
  echo Running as administator
  set admin="y"
) else (
  echo Not running as administator, so will quit
  echo Right-click and rerun as adminstrator
  set admin="n"
  pause
  exit
)

cd %~dp0
if not exist "ketcindyfolder" (
  cd ../ketcindyfolder
)
echo ketcindyfolder is
cd

echo 1. "kettex"
echo 2. "texlive"
echo 3. "w32j"
set /P STR_INPUT="---- Choose no : "
if "%STR_INPUT%" == "1" (
  set pathT=C:\kettex\
  set add=texlive
  set bin=\bin\win32
  set scripts=\texmf-dist\scripts\ketcindy
  set style=\texmf-dist\tex\latex\ketcindy
  set doc=\texmf-dist\doc\support\ketcindy
 )
if "%STR_INPUT%" == "2" (
  set pathT=C:\kettex\texlive\
  set /P add="Year of TeXLive (ex)2020: "
  set bin=\bin\win32
  set scripts=\texmf-dist\scripts\ketcindy
  set style=\texmf-dist\tex\latex\ketcindy
  set doc=\texmf-dist\doc\support\ketcindy
)
if "%STR_INPUT%" == "3" (
  set pathT=C:\
  set add=w32tex
  set bin=\bin
  set scripts=\share\texmf-dist\scripts\ketcindy
  set style=\share\texmf-dist\tex\latex\ketcindy
  set doc=\share\texmf-dist\doc\support\ketcindy
)

echo Copying ketcindy to "%pathT%%add%%scripts%"
%xcp% /Y /Q /S /E /R "scripts\*.*" "%pathT%%add%%scripts%\"
echo Copying doc to "%pathT%%add%%doc%"
set docsrc=doc
%xcp% /Y /Q /S /E /R "%docsrc%\*.*" "%pathT%%add%%doc%\"
echo Copying ketcindy styles to "%pathT%%add%%style%"
set stylesrc=style
%xcp% /Y /Q /S /E /R "%stylesrc%\*.*" "%pathT%%add%%style%\"
"%pathT%%add%%bin%\mktexlsr"

pause
