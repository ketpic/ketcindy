set dr=%1
set fL=%2
cd %dr%
rem "c:\Program Files\nkf32" -s --overwrite  %fL%.tex
"c:\kettex\w32texb\bin\latex" %fL%.tex
"c:\kettex\w32texb\bin\dvipdfmx" %fL%.dvi
del %fL%.dvi
"C:\Program Files\SumatraPDF\SumatraPDF.exe" %fL%.pdf
rem "C:\Program Files\Adobe Reader\Adobe Reader.exe" %fL%.pdf
