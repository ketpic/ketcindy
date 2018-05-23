#!/bin/sh
cd "/Users/takatoosetsuo/ketcindy/ketsample/samples/s03table/fig"
"/Library/Frameworks/R.framework/Versions/Current/Resources/bin/R" --vanilla --slave < s0305incanddec.r
"/Applications/KeTTeX.app/texlive/bin/x86_64-darwin/uplatex" s0305incanddecmain.tex
"/Applications/KeTTeX.app/texlive/bin/x86_64-darwin/dvipdfmx" s0305incanddecmain.dvi
rm s0305incanddecmain.dvi
open -a "skim" s0305incanddecmain.pdf
exit 0
