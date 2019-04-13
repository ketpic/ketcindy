REM 20190413
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

set /P STR_INPUT="Language (j/e) :"
if("%STR_INPUT%" == "e" (
  copy /Y "doc\ketmanual\KeTCindyReferenceE.pdf" "%dist%\"
  copy /Y "doc\ketmanual\KeTCindyGuideE.pdf" "%dist%\"
  copy /Y "doc\ketmanual\KeTpicStyleE.pdf" "%dist%\"
) else (
  copy /Y "doc\ketmanual\KeTCindyReferenceJ.pdf" "%dist%\"
  copy /Y "doc\ketmanual\KeTCindyGuideJ.pdf" "%dist%\"
  copy /Y "doc\ketmanual\KeTpicStyleJ.pdf" "%dist%\"
)

set dist=%HOMEPATH%
set prg=C:\Program Files
echo  generating %dist%\%changesetting%
echo // Re-setting PathT,Pathpdf,PathAd > "%dist%%change%"
echo //PathT=PathThead+"uplatex"; >> "%dist%%change%"
echo //Pathpdf="%prg%\SumatraPDF\SumatraPDF.exe"; >> "%dist%%change%"
echo //PathR="%prg%\R\R-xxxx\bin"; >> "%dist%%change%"
echo //PathM="C:\maxima-x.xx.x\bin\maxima.bat"; >> "%dist%%change%"

pause
