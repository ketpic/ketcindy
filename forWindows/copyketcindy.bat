REM 2017.10.04
echo off
set xcp="\Windows\System32\xcopy"
set ketcin=%HOMEPATH%\Desktop\ketcindyfolder
set dist=%HOMEPATH%\ketcindy

set prgcin=C:\Program Files (x86)
if not exist "%prgcin%\Cinderella" (
  set prgcin=C:\Program Files
)
set dirhead=%prgcin%\Cinderella\Plugins\dirhead.txt
set prgR=C:\Program Files (x86)\R\R-3.2.2\bin
if not exist "%prgR%" (
  set prgR=C:\Program Files\R\R-3.2.2\bin
)
set prgsci5=C:\Program Files (x86)\scilab-5.5.2\bin\scilex.exe
if not exist "%prgsci5%" (
  set prgsci5=C:\Program Files\scilab-5.5.2\bin\scilex.exe
)
set prgsci6=C:\Program Files (x86)\scilab-6.0.0\bin\scilex.exe
if not exist "%prgsci6%" (
  set prgsci6=C:\Program Files\scilab-6.0.0\bin\scilex.exe
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

echo %dirhead%
set /P STR_INPUT="path of ketcindy? userhome(u) C:\(c) desktop(d):"
if "%STR_INPUT%" == "u" (
  if exist "%dirhead%" (
    del "%dirhead%"
  )
) else if "%STR_INPUT%" == "c" (
  set dist=C:\ketcindy
  if %admin% == "y" (
    echo Dirhead="C:\ketcindy"; > "%dirhead%"
  )
) else if "%STR_INPUT%" == "d" (
  set dist=%HOMEPATH%\Desktop\ketcindy
  if %admin% == "y" (
    echo Dirhead="%HOMEPATH%\Desktop\ketcindy"; > "%dirhead%"
  )
) else (
  set /P STR_INPUT_PATH="path to ketcindy (Desktop\work etc):"
  set dist="%HOMEPATH%\%STR_INPUT_PATH%\ketcindy"
)
set /P STR_INPUT="Do you really copy ketcindy? (y,n):"
if "%STR_INPUT%" == "y" (
  echo Deleting "%dist%"
  rd /s "%dist%"
  echo Copying ketcindy
  %xcp% /Y /Q /S /E /R "%ketcin%\ketcindy\*.*" "%dist%\"
)
cd "%ketcin%"
if %admin% == "y" (
  echo Copying KetCindyPlugin to Cinderella
  copy /Y "ketcindy\ketjava\KetCindyPlugin.jar" "%prgcin%\Cinderella\Plugins\"
)
echo Copying ketoutset.txt to %ketcin%
copy ketcindy\ketoutset.txt "%ketcin%\"
echo Adding Changes to ketcindyout.txt
echo // Changes for Windows >> ketoutset.txt
echo platex(p) uplatex(u) latex(l) xelatex(x) pdflatex(pd) lualatex(lu)
set /P STR_INPUT="Choose LaTeX from the above :"
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
if exist "C:\kettex\w32texb" (
  echo   PathT="C:\kettex\w32texb\bin\%tex%"; >> ketoutset.txt
) else (
  echo   PathT="C:\kettex\texlive\bin\win32\%tex%"; >> ketoutset.txt
)
cd "%dist%"
set /P STR_INPUT="Choose R(r) Scilab-5.5.2(5) Scilab-6.0.0(6) :"
if "%STR_INPUT%" == "r" (
  copy /Y setketcindyr.txt setketcindy.txt
  cd "%ketcin%"
  echo   PathR="%prgR%"; >> ketoutset.txt
)
if "%STR_INPUT%" == "5" (
  copy /Y setketcindysci.txt setketcindy.txt
  cd "%ketcin%"
  echo   PathS="%prgsci5%"; >> ketoutset.txt
)
if "%STR_INPUT%" == "6" (
  copy /Y setketcindysci.txt setketcindy.txt
  cd "%ketcin%"
  echo   PathS="%prgsci6%"; >> ketoutset.txt
)
set prg=C:\Program Files (x86)
if not exist "%prg%\SumatraPDF" (
  set prg=C:\Program Files
)
echo   Pathpdf="%prg%\SumatraPDF\SumatraPDF.exe"; >> ketoutset.txt
copy /Y ketoutset.txt "%dist%\ketoutset.txt"
del ketoutset.txt
pause
