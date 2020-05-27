#!/bin/sh
cd "/ketcindy.git/ketcindyfolder/work/samples/s02graph/fig"
"/Library/Frameworks/R.framework/Versions/Current/Resources/bin/R" --vanilla --slave < "s0214inputvalue.r"
"/Applications/kettex/texlive/bin/x86_64-darwin/uplatex" "s0214inputvaluemain.tex"
"/Applications/kettex/texlive/bin/x86_64-darwin/dvipdfmx" "s0214inputvaluemain.dvi"
rm "s0214inputvaluemain.dvi"
open -a "preview" "s0214inputvaluemain.pdf"
exit 0
