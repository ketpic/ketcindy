REM 20181207
echo off

rem Edit the followings if necessary
set pathT=C:\kettex\texlive
set bin=\bin\win32
set scripts=\texmf-dist\scripts\ketcindy
set style=\texmf-dist\tex\latex\ketcindy
set doc=\texmf-dist\doc\support\ketcindy
set homehead=C:\Users

set prgcin=C:\Program Files (x86)
set xcp="\Windows\System32\xcopy"
if not exist "%prgcin%\Cinderella" (
  set prgcin=C:\Program Files
)
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
echo Path of TeX  ; %pathT%
echo     bin      : %bin%
echo     scripts  : %scripts%
echo     style    : %style%
echo     doc      : %doc%
echo Head of home : %homehead%
set /P ans="Are the above paths OK (y/n): "
if "%ans%" == "n" (
  echo Edit paths
  pause
  exit
)

cd %~dp0
if not exist "ketcindyfolder" (
  cd ../ketcindyfolder
)
echo ketcindyfolder is
cd

if exist "%pathT%%scripts%\." (
  echo Deleting "%pathT%%scripts%"
  rd /s "%pathT%%scripts%"
)
echo Copying ketcindy to "%pathT%%scripts%"
%xcp% /Y /Q /S /E /R "scripts\*.*" "%pathT%%scripts%\"
if exist "%pathT%%doc%\." (
  echo Deleting docs to "%pathT%%doc%"
  rd /s "%pathT%%doc%"
)
echo Copying doc to "%pathT%%doc%"
set docsrc=doc
%xcp% /Y /Q /S /E /R "%docsrc%\*.*" "%pathT%%doc%\"
if exist "%pathT%%style%\." (
  echo Deleting "%pathT%%style%"
  rd /s "%pathT%%style%"
)
echo Copying ketcindy styles to "%pathT%%style%"
set stylesrc=style
%xcp% /Y /Q /S /E /R "%stylesrc%\*.*" "%pathT%%style%\"
"%pathT%%bin%\mktexlsr"

set cindyplug=%prgcin%\Cinderella\Plugins
echo Setting of "%cindyplug%\"
cd "%pathT%%scripts%"
copy /Y "ketjava\KetCindyPlugin.jar" "%cindyplug%\"
cd "%cindyplug%"
echo PathThead="%pathT%%bin%\"; > ketcindy.ini
echo Homehead="%homehead%"; >> ketcindy.ini
echo Dirhead="%pathT%%scripts%"; >> ketcindy.ini
echo setdirectory(Dirhead); >> ketcindy.ini
echo import("setketcindy.txt"); >> ketcindy.ini
echo import("ketoutset.txt"); >> ketcindy.ini
echo "Plugins of Cindy has been set"
pause
