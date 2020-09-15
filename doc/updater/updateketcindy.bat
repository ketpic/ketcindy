REM 20200915
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
cd ..\..
set scripts=\scripts\ketcindy
set style=\tex\latex\ketcindy
set doc=\doc\support\ketcindy

echo 1. kettex
echo 2. texlive
echo 3. w32j
set /P STR_INPUT="---- Choose no : "
if "%STR_INPUT%" == "1" (
  set pathT=C:\kettex\
  set add=texlive
  set bin=\bin\win32
  set dist=\texmf-dist
 )
if "%STR_INPUT%" == "2" (
  set pathT=C:\texlive\
  set /P add="Year of TeXLive (ex)2020: "
  set bin=\bin\win32
  set dist=\texmf-dist
)
if "%STR_INPUT%" == "3" (
  set pathT=C:\
  set add=w32tex
  set bin=\bin
  set dist=\share\texmf-dist
)

echo Copying ketcindy to "%pathT%%add%%dist%%scripts%"
%xcp% /Y /Q /S /E /R "scripts\*.*" "%pathT%%add%%dist%%scripts%\"
echo Copying doc to "%pathT%%add%%dist%%doc%"
set docsrc=doc
%xcp% /Y /Q /S /E /R "%docsrc%\*.*" "%pathT%%add%%dist%%doc%\"
echo Copying ketcindy styles to "%pathT%%add%%dist%%style%"
set stylesrc=style
%xcp% /Y /Q /S /E /R "%stylesrc%\*.*" "%pathT%%add%%dist%%style%\"
"%pathT%%add%%bin%\mktexlsr"

pause
