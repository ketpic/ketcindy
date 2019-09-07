REM 20190904
echo off

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

set /P pathT="Path of TeX (ex) C:\texlive\2019: "
set /P bin="Path of bin (ex) bin\win32: "
set /P texmf="Path of scripts/doc/style (ex) texmf-dist: "
set /P homehead="Path of home head (ex) C:\Users: "

echo Path of TeX  ; %pathT%
echo     bin      : %bin%
echo     scripts  : %texmf%\scripts\ketcindy
echo     style    : %texmf%\tex\latex\ketcindy
echo     doc      : %texmf%\doc\support\ketcindy
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

if exist "%pathT%\%texmf%\scripts\ketcindy\." (
  echo Deleting "%pathT%\%texmf%\scripts\ketcindy"
  rd /s "%pathT%\%texmf%\scripts\ketcindy"
)
echo Copying ketcindy to "%pathT%\%texmf%\scripts\ketcindy"
%xcp% /Y /Q /S /E /R "scripts\*.*" "%pathT%\%texmf%\scripts\ketcindy\"
if exist "%pathT%\%texmf%\doc\support\ketcindy\." (
  echo Deleting docs to "%pathT%\%texmf%\doc\support\ketcindy"
  rd /s "%pathT%\%texmf%\doc\support\ketcindy"
)
echo Copying doc to "%pathT%\%texmf%\doc\support\ketcindy"
set docsrc=doc
%xcp% /Y /Q /S /E /R "%docsrc%\*.*" "%pathT%\%texmf%\doc\support\ketcindy\"
if exist "%pathT%\tex\latex\ketcind\." (
  echo Deleting "%pathT%\tex\latex\ketcindy"
  rd /s "%pathT%\tex\latex\ketcindy"
)
echo Copying ketcindy styles to "%pathT%\tex\latex\ketcindy"
set stylesrc=style
%xcp% /Y /Q /S /E /R "%stylesrc%\*.*" "%pathT%\tex\latex\ketcindy\"

rem "%pathT%%bin%\mktexlsr"
set cindyplug=%prgcin%\Cinderella\Plugins
echo Setting of "%cindyplug%\"
cd "%pathT%%scripts%"
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

echo PathThead="%pathT%\%bin%\"; > ketcindy.ini
echo Homehead="%homehead%"; >> ketcindy.ini
echo Dirhead="%pathT%\%texmf%\scripts\ketcindy"; >> ketcindy.ini
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