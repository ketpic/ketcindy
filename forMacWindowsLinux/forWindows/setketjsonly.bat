REM 20200112
echo off

rem Edit the followings if necessary
set pathT=C:\ketjs\texlive
set scripts=\texmf-dist\scripts\ketcindy
set style=\texmf-dist\tex\latex\ketcindy
set doc=\texmf-dist\doc\support\ketcindy

if not exist "%PathT%" (
  mkdir "%PathT%
  cd "%PathT%
  mkdir "%scripts%"
  mkdir "%style%"
  mkdir "%doc%"
)

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

cd %~dp0
if not exist "ketcindyfolder" (
  cd ../ketcindyfolder
)
echo ketcindyfolder is
cd

if exist "%pathT%%scripts%\." (
  echo Deleting "%pathT%%scripts%"
  rd /s/q "%pathT%%scripts%"
)
echo Copying ketcindy to "%pathT%%scripts%"
%xcp% /Y /Q /S /E /R "scripts\*.*" "%pathT%%scripts%\"
if exist "%pathT%%doc%\." (
  echo Deleting docs to "%pathT%%doc%"
  rd /s/q "%pathT%%doc%"
)
echo Copying doc to "%pathT%%doc%"
set docsrc=doc
%xcp% /Y /Q /S /E /R "%docsrc%\*.*" "%pathT%%doc%\"
if exist "%pathT%%style%\." (
  echo Deleting "%pathT%%style%"
  rd /s/q "%pathT%%style%"
)
echo Copying ketcindy styles to "%pathT%%style%"
set stylesrc=style
%xcp% /Y /Q /S /E /R "%stylesrc%\*.*" "%pathT%%style%\"

set cindyplug=%prgcin%\Cinderella\Plugins
echo Setting of "%cindyplug%\"
cd "%pathT%%scripts%"
copy /Y "ketjava\KetCindyPlugin.jar" "%cindyplug%\"
cd "%cindyplug%"

set newfile=y
if exist ketcindy.ini (
  set newfile=n
  echo.
  echo Contents of ketcindy.ini : 
  echo.
  type ketcindy.ini
  echo.
  set /P remake="Do you want to remake ketindy.ini? (y/n): "
)
if "%newfile%"=="y" (
  set remake=y
)
if "%remake%"=="y" (
  echo ketcindy.ini will be made/remade
) else (
    echo "Finished"
    pause
    exit
)

echo PathThead="%pathT%%bin%\"; > ketcindy.ini
echo Homehead="%homehead%"; >> ketcindy.ini
echo Dirhead="%pathT%%scripts%"; >> ketcindy.ini
echo setdirectory(Dirhead); >> ketcindy.ini
echo import("setketcindy.txt"); >> ketcindy.ini

set /P STR_INPUT="Language for Help (j/e) :"
echo Langhelp="%STR_INPUT%"; >> ketcindy.ini
echo import("ketoutset.txt"); >> ketcindy.ini

set /P STR_INPUT="Version of Maxima (ex)5.39.0  (0 for skip) :"
set verM=%STR_INPUT%
if not "%verM%"=="" (
  if not "%verM:~0,1%"=="0" (
    echo %verM%
    set prg=C:\maxima-%verM%\bin\maxima.bat
    if exist "%prg%" (
      echo PathM="%prg%"; >> ketcindy.ini
    ) else (
      echo "Maxima-%verM% not found"
      set prg=C:\maxima-x.xx.x\bin\maxima.bat
      echo // PathM="%prg%"; >> ketcindy.ini
    )
  )
)

echo "Plugins of Cindy has been set for ketcindyjs"
pause
