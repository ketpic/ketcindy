REM 20190616
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

rem 20190616from
set newfile=y
if exist ketcindy.ini (
  set newfile=n
  echo Contentes of ketcindy.ini : 
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
rem 20190616to

echo PathThead="%pathT%\%year%%bin%\"; > ketcindy.ini
echo Homehead="%homehead%"; >> ketcindy.ini
echo Dirhead="%pathT%\%year%%scripts%"; >> ketcindy.ini
echo setdirectory(Dirhead); >> ketcindy.ini
echo import("setketcindy.txt"); >> ketcindy.ini
echo import("ketoutset.txt"); >> ketcindy.ini

echo Setting of TeX, R, Maxima
echo p=platex u=uplatex l=latex x=xelatex pd=pdflatex lu=lualatex
set /P STR_INPUT="---- Choose TeX from above with 1st(+2nd) character :"
if "%STR_INPUT%" == "p" (
  set tex=platex
)
if "%STR_INPUT%" == "u" (
  set tex=uplatex
)
if "%STR_INPUT%" == "l" (
  set tex=latex
)
if "%STR_INPUT%" == "x" (
  set tex=xelatex
)
if "%STR_INPUT%" == "pd" (
  set tex=pdflatex
)
if "%STR_INPUT%" == "lu" (
  set tex=lualatex
)
echo PathT=PathThead+"%tex%"; >> ketcindy.ini

set prgSm=C:\Program Files (x86)\SumatraPDF\SumatraPDF.exe
if not exist "%prgSm%" (
  set prgSm=C:\Program Files\SumatraPDF\SumatraPDF.exe
)
echo Pathpdf="%prgSm%"; >>  ketcindy.ini

set /P STR_INPUT="Input version of R (ex)3.5.0 :"
set verR=%STR_INPUT%
set prg=C:\Program Files
if exist "%prg%\R\R-%verR%\bin\" (
  echo PathR="%prg%\R\R-%verR%\bin"; >>  ketcindy.ini
) else (
  if exist "%prg% (x86)\R\R-%verR%\bin\" (
    echo "%prg% (x86)\R\R-%verR%\bin"; >> ketcindy.ini
  ) else (
    echo "R-%verR% not found"
  )
)

set /P STR_INPUT="Input version of Maxima (ex)5.39.0 :"
set verM=%STR_INPUT%
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

echo "Plugins of Cindy has been set"
pause
