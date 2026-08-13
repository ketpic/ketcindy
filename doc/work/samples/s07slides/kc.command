#!/bin/sh
cd "/Users/takatoosetsuo/ketcindy.git/doc/work/samples/s07slides"
"/Applications/KeTTeX.app/texlive/bin/universal-darwin/lualatex" "slideluamanualJ.tex"
open -a "preview" "slideluamanualJ.pdf"
exit 0
