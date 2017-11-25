REM 2017.11.09
echo off
set xcp="\Windows\System32\xcopy"
set ketsrc=%HOMEPATH%\Desktop\ketcindyfolder
set ketcindyhead=%HOMEPATH%\ketcidyhead.txt
set /P STR_INPUT="ketcindy folder d(efault)=ketcindy :"
if "%STR_INPUT%" == "d" (
  set folder=ketcindy
) else (
  set folder=%STR_INPUT%
)
set /P STR_INPUT="path of the folder? userhome(u) C:\(c) desktop(d) other(o) :"
if "%STR_INPUT%" == "u" (
  set dist=%HOMEPATH%\%folder%
  echo Dirfile="%HOMEPATH%\%folder%"; > "%ketcindyhead%"
)
if "%STR_INPUT%" == "c" (
  set dist=C:\%folder%
  echo Dirfile="C:\%folder%"; > "%ketcindyhead%"
)
if "%STR_INPUT%" == "d" (
  set dist=%HOMEPATH%\Desktop\%folder%
  echo Dirfile="%HOMEPATH%\Desktop\%folder%"; > "%ketcindyhead%"
)
if "%STR_INPUT%" == "o" (
  set /P STR_INPUT_PATH="Input path (Desktop\work etc):"
  set dist=%HOMEPATH%\%STR_INPUT_PATH%\%folder%
  echo Dirfile="%HOMEPATH%\%STR_INPUT_PATH%\%folder%"; > "%ketcindyhead%"
)
if exist "%dist%\." (
  echo Deleting "%dist%"
  rd /s "%dist%"
)
echo Copying work to %dist%
%xcp% /Y /Q /S /E /R "%ketsrc%\work\*.*" "%dist%\"
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
echo PathT=PathThead+"%tex%"; >> %ketcindyhead%
pause
