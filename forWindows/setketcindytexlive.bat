REM 20181222
echo off

rem Edit the followings if necessary
set pathT=C:\texlive
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

set /P year="Year of TeXLive (YYYY): "

echo Path of TeX  ; %pathT%\%year%
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

if exist "%pathT%\%year%%scripts%\." (
  echo Deleting "%pathT%\%year%%scripts%"
  rd /s "%pathT%\%year%%scripts%"
)
echo Copying ketcindy to "%pathT%\%year%%scripts%"
%xcp% /Y /Q /S /E /R "scripts\*.*" "%pathT%\%year%%scripts%\"
if exist "%pathT%\%year%%doc%\." (
  echo Deleting docs to "%pathT%\%year%%doc%"
  rd /s "%pathT%\%year%%doc%"
)
echo Copying doc to "%pathT%\%year%%doc%"
set docsrc=doc
%xcp% /Y /Q /S /E /R "%docsrc%\*.*" "%pathT%\%year%%doc%\"
if exist "%pathT%\%year%%style%\." (
  echo Deleting "%pathT%\%year%%style%"
  rd /s "%pathT%\%year%%style%"
)
echo Copying ketcindy styles to "%pathT%\%year%%style%"
set stylesrc=style
%xcp% /Y /Q /S /E /R "%stylesrc%\*.*" "%pathT%\%year%%style%\"
"%pathT%\%year%%bin%\mktexlsr"

set cindyplug=%prgcin%\Cinderella\Plugins
echo Setting of "%cindyplug%\"
cd "%pathT%\%year%%scripts%"
copy /Y "ketjava\KetCindyPlugin.jar" "%cindyplug%\"
cd "%cindyplug%"
echo PathThead="%pathT%\%year%%bin%\"; > ketcindy.ini
echo Homehead="%homehead%"; >> ketcindy.ini
echo Dirhead="%pathT%\%year%%scripts%"; >> ketcindy.ini
echo setdirectory(Dirhead); >> ketcindy.ini
echo import("setketcindy.txt"); >> ketcindy.ini
echo import("ketoutset.txt"); >> ketcindy.ini
echo "Plugins of Cindy has been set"
pause
