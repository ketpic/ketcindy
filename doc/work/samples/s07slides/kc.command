#!/bin/sh
cd "/Users/takatoosetsuo/ketcindy.git/doc/work/samples/s07slides"
"/Applications/KeTTeX.app/texlive/bin/universal-darwin/platex" "s0707addtext.tex"
"/Applications/KeTTeX.app/texlive/bin/universal-darwin/dvipdfmx" "s0707addtext.dvi"
rm "s0707addtext.dvi"
open -a "preview" "s0707addtext.pdf"
exit 0
