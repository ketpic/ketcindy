set dr=%1
set fL=%2
cd %dr%
rem "c:\Program Files\nkf32" -s --overwrite  %fL%.tex
"c:\kettex\w32texb\bin\pdflatex" %fL%.tex
"C:\Program Files\SumatraPDF\SumatraPDF.exe" %fL%.pdf
rem "C:\Program Files\Adobe Reader\Adobe Reader.exe" %fL%.pdf
