#!/bin/sh
cd "/Users/takatoosetsuo/ketcindy/ketsample/samples/s06animation/fig"
"/Applications/KeTTeX.app/texlive/bin/x86_64-darwin/uplatex" flipanimeenvelope.tex
"/Applications/KeTTeX.app/texlive/bin/x86_64-darwin/dvipdfmx" flipanimeenvelope.dvi
rm flipanimeenvelope.dvi
open -a "skim" flipanimeenvelope.pdf
exit 0
