REM 20181207
echo off
set xcp="\Windows\System32\xcopy"
rem set ketsrc=%HOMEPATH%\Desktop\ketcindyfolder

cd %~dp0
if not exist "ketcindyfolder" (
  cd ../ketcindyfolder
)
echo ketcindyfolder is
cd

set change=\.ketcindy.conf
set dist=%HOMEPATH%\ketcindy
if exist "%dist%\." (
  echo Deleting "%dist%"
  rd /s "%dist%"
)
%xcp% /Y /Q /S /E /R "work\*.*" "%dist%\"
echo Workfolder has been generated as %dist%
echo This folder can be moved to any place
echo platex(p) uplatex(u) latex(l) xelatex(x) pdflatex(pd) lualatex(lu)
set /P STR_INPUT="Choose LaTeX from the above :"
if "%STR_INPUT%" == "p" (
  set tex=platex
  copy /Y "doc\ketmanual\KeTCindyReferenceJ.pdf" "%dist%\"
  copy /Y "doc\ketmanual\KeTCindyGuideJ.pdf" "%dist%\"
  copy /Y "doc\ketmanual\KeTpicStyleJ.pdf" "%dist%\"
)
if "%STR_INPUT%" == "u" (
  set tex=uplatex
  copy /Y "doc\ketmanual\KeTCindyReferenceJ.pdf" "%dist%\"
  copy /Y "doc\ketmanual\KeTCindyGuideJ.pdf" "%dist%\"
  copy /Y "doc\ketmanual\KeTpicStyleJ.pdf" "%dist%\"
)
if "%STR_INPUT%" == "l" (
  set tex=latex
  copy /Y "doc\ketmanual\KeTCindyReferenceE.pdf" "%dist%\"
  copy /Y "doc\ketmanual\KeTCindyGuideE.pdf" "%dist%\"
  copy /Y "doc\ketmanual\KeTpicStyleE.pdf" "%dist%\"
)
if "%STR_INPUT%" == "x" (
  set tex=xelatex
  copy /Y "doc\ketmanual\KeTCindyReferenceE.pdf" "%dist%\"
  copy /Y "doc\ketmanual\KeTCindyGuideE.pdf" "%dist%\"
  copy /Y "doc\ketmanual\KeTpicStyleE.pdf" "%dist%\"
)
if "%STR_INPUT%" == "pd" (
  set tex=pdflatex
  copy /Y "doc\ketmanual\KeTCindyReferenceE.pdf" "%dist%\"
  copy /Y "doc\ketmanual\KeTCindyGuideE.pdf" "%dist%\"
  copy /Y "doc\ketmanual\KeTpicStyleE.pdf" "%dist%\"
)
if "%STR_INPUT%" == "lu" (
  set tex=lualatex
  copy /Y "doc\ketmanual\KeTCindyReferenceE.pdf" "%dist%\"
  copy /Y "doc\ketmanual\KeTCindyGuideE.pdf" "%dist%\"
  copy /Y "doc\ketmanual\KeTpicStyleE.pdf" "%dist%\"
)
set dist=%HOMEPATH%
echo  generating %dist%\%changesetting%
echo  // Re-setting PathT,Pathpdf,PathAd > "%dist%%change%"
echo PathT=PathThead+"%tex%"; >> "%dist%%change%"
set prgSm=C:\Program Files (x86)\SumatraPDF\SumatraPDF.exe
if not exist "%prgSm%" (
  set prgSm=C:\Program Files\SumatraPDF\SumatraPDF.exe
)
echo Pathpdf="%prgSm%"; >> "%dist%%change%"
set /P STR_INPUT="Input version of R d(efault)=3.4.2 :"
if "%STR_INPUT:~0,1%" == "d" (
  set verR=3.4.2
) else (
  set verR=%STR_INPUT%
)
echo %verR%
set prg=C:\Program Files
if exist "%prg%\R\R-%verR%\bin\" (
  echo PathR="%prg%\R\R-%verR%\bin"; >> "%dist%%change%"
) else (
  if exist "%prg% (x86)\R\R-%verR%\bin\" (
    echo "%prg% (x86)\R\R-%verR%\bin"; >> "%dist%%change%"
  ) else (
    echo "R-%verR% not found"
  )
)
set /P STR_INPUT="Input version of Maxima d(efault)=5.37.3 :"
if "%STR_INPUT:~0,1%" == "d" (
  set verM=5.37.3
) else (
  set verM=%STR_INPUT%
)
echo %verM%
set prg=C:\maxima-%verM%\bin\maxima.bat
if exist "%prg%" (
  echo PathM="%prg%"; >> "%dist%%change%"
) else (
  echo "Maxima-%verM% not found"
  )
)
pause
