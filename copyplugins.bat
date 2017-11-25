REM 2017.11.18
echo off
set ketsrc=%HOMEPATH%\Desktop\ketcindyfolder
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
echo 2. C:\texlive
echo 3. C:\w32tex
echo 4. other path of texlive
echo 5. other path of w32tex
set /P ans="Choose path of TeX (number): "
if "%ans%" == "1" (
  set pathT=C:\kettex
  set kind=\texlive
)
if "%ans%" == "2" (
  set pathT=C:
  set kind=\texlive
)
if "%ans%" == "3" (
  set pathT=C:
  set kind=\w32tex
)
if "%ans%" == "4" (
  set /P pathT="Input the path (ex) C:\tex: "
  set kind=\texlive
)
if "%ans%" == "5" (
  set /P pathT="Input the path (ex) C:\tex: "
  set kind=\w32tex
)
if "%kind%" == "\texlive" (
  set bin=\bin\win32
  set scripts=\texmf-dist\scripts\ketcindy
  set styles=\texmf-dist\tex\latex\ketcindy
) else (
  set bin=\bin
  set scripts=\share\texmf-dist\scripts\ketcindy
  set styles=\share\texmf-dist\tex\latex\ketcindy
)
set cindyplug=%prgcin%\Cinderella\Plugins
echo Files will be copied to "%cindyplug%\"
cd "%pathT%%kind%%scripts%"
copy /Y "ketjava\KetCindyPlugin.jar" "%cindyplug%\"
cd "%cindyplug%"
echo PathThead="%pathT%%kind%%bin%\"; > dirhead.txt
set homehead=C:\Users
set /P STR_INPUT="Input head of user home d(efault)=C:\Users :"
if not "%STR_INPUT%" == "d" (
  homehead=%STR_INPUT%
)
echo %homehead%
echo Homehead="%homehead%"; >> dirhead.txt
echo Dirhead="%pathT%%kind%%scripts%"; >> dirhead.txt
echo setdirectory(Dirhead); >> dirhead.txt
echo import("setketcindy.txt"); >> dirhead.txt
echo import("ketoutset.txt"); >> dirhead.txt
set /P STR_INPUT="Input version of R d(efault)=3.4.2 :"
if "%STR_INPUT:~0,1%" == "d" (
  set verR=3.4.2
) else (
  set verR=%STR_INPUT%
)
echo %verR%
set prg=C:\Program Files
if exist "%prg%\R\R-%verR%\bin\" (
  echo PathR="%prg%\R\R-%verR%\bin"; >> dirhead.txt
) else (
  if exist "%prg% (x86)\R\R-%verR%\bin\" (
    echo "%prg% (x86)\R\R-%verR%\bin"; >> dirhead.txt
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
  echo PathM="%prg%"; >> dirhead.txt
) else (
  echo "Maxima-%verM% not found"
  )
)
set prgSm=C:\Program Files (x86)\SumatraPDF\SumatraPDF.exe
if not exist "%prgSm%" (
  set prgSm=C:\Program Files\SumatraPDF\SumatraPDF.exe
)
echo Pathpdf="%prgSm%"; >> dirhead.txt
echo "KetCindyPlugin and others have been copied"
pause
