#!/bin/sh
# for texworks
pa="/Applications/kettex/texlive/bin/x86_64-darwin"
fname_ext=$1
fname="${fname_ext%.*}"
$pa/latex $fname.tex
$pa/dvipdfmx $fname.dvi
rm $fname.dvi
#open -a preview $fname.pdf
exit 0
