REM 20181212
echo off

REM Edit the followings if necessary.
set verR=3.4.2
set verM=5.37.3

cd %~dp0
if not exist "ketcindyfolder" (
  cd ../ketcindyfolder
)
echo ketcindyfolder is
cd

set xcp="\Windows\System32\xcopy"

set change=\.ketcindy.conf
set dist=%HOMEPATH%\ketcindy
if exist "%dist%\." (
  echo Deleting "%dist%"
  rd /s "%dist%"
)
%xcp% /Y /Q /S /E /R "work\*.*" "%dist%\"
echo Workfolder has been generated as %dist%
echo This folder can be moved to any place
echo p=platex u=uplatex l=latex x=xelatex pd=pdflatex lu=lualatex
set /P STR_INPUT="---- Choose TeX from above with 1st(+2nd) character :"
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
set /P STR_INPUT="Input version of R (ex)%verR% :"
if not "%STR_INPUT:~0,1%" == "d" (
  set verR=%STR_INPUT%
)
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
set /P STR_INPUT="Input version of Maxima (ex)%verM% :"
if not "%STR_INPUT:~0,1%" == "d" (
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
