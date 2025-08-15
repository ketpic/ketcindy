#!/bin/sh
cd "/Users/takatoosetsuo/ketcindy.git/doc/ketslideLua/fig"
"/Applications/KeTTeX.app/texlive/bin/universal-darwin/lualatex" "slide0main.tex"
open -a "preview" "slide0main.pdf"
exit 0
