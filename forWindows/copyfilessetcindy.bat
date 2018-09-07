REM 20180907
echo off
set xcp="\Windows\System32\xcopy"
rem set ketsrc=%HOMEPATH%\Desktop\ketcindyfolder
set ketsrc=%~dp0
set prgcin=C:\Program Files (x86)
if not exist "%prgcin%\Cinderella" (
  set prgcin=C:\Program Files
)
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
echo 2. Other texlive
echo If other, install manually
set /P ans="Choose path of TeX (number): "
if "%ans%" == "1" (
  set kind=\texlive
  set pathT=C:\kettex\texlive
)
if "%ans%" == "2" (
  set kind=\texlive
  set /P pathT="Full path (ex)C:\texlive\2017: "
)
echo Path of TeX is %pathT%
if "%kind%" == "\texlive" (
  set bin=\bin\win32
  set scripts=\texmf-dist\scripts\ketcindy
  set styles=\texmf-dist\tex\latex\ketcindy
  set doc=\texmf-dist\doc\support\ketcindy
) else (
  set bin=\bin
  set scripts=\share\texmf-dist\scripts\ketcindy
  set styles=\share\texmf-dist\tex\latex\ketcindy
  set doc=\share\texmf-dist\doc\support\ketcindy
)
set /P STR_INPUT="Do you really copy ketcindy? (y,n):"
if "%STR_INPUT%" == "y" (
  if exist "%pathT%%kind%%scripts%\." (
    echo Deleting "%pathT%%scripts%"
    rd /s "%pathT%%scripts%"
  )
  echo Copying ketcindy to "%pathT%%scripts%"
  %xcp% /Y /Q /S /E /R "%ketsrc%\scripts\*.*" "%pathT%%scripts%\"
)
set docsrc=doc
if exist "%pathT%%doc%\." (
  echo Deleting docs to "%pathT%%doc%"
  rd /s "%pathT%%doc%"
)
echo Copying doc to "%pathT%%doc%"
%xcp% /Y /Q /S /E /R "%ketsrc%\%docsrc%\*.*" "%pathT%%doc%\"
set stylesrc=style
if exist "%pathT%%styles%\." (
  echo Deleting "%pathT%%styles%"
  rd /s "%pathT%%styles%"
)
echo Copying ketcindy styles to "%pathT%%styles%
%xcp% /Y /Q /S /E /R "%ketsrc%\%stylesrc%\*.*" "%pathT%%styles%\"
"%pathT%%bin%\mktexlsr"

set cindyplug=%prgcin%\Cinderella\Plugins
echo Setting of "%cindyplug%\"
cd "%pathT%%scripts%"
copy /Y "ketjava\KetCindyPlugin.jar" "%cindyplug%\"
cd "%cindyplug%"
set homehead=C:\Users
set /P STR_INPUT="Input head of user home d(efault)=C:\Users :"
if not "%STR_INPUT%" == "d" (
  set homehead=%STR_INPUT%
)
echo %homehead%
echo PathThead="%pathT%%bin%\"; > ketcindy.ini
echo Homehead="%homehead%"; >> ketcindy.ini
echo Dirhead="%pathT%%scripts%"; >> ketcindy.ini
echo setdirectory(Dirhead); >> ketcindy.ini
echo import("setketcindy.txt"); >> ketcindy.ini
echo import("ketoutset.txt"); >> ketcindy.ini
echo "Plugins of Cindy has been set"
pause
