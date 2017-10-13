set fL="%~n1"
"c:\kettex\w32texb\bin\platex" %fL%.tex
"c:\kettex\w32texb\bin\dvipdfmx" %fL%.dvi
del %fL%.dvi
