#!/bin/sh
cd "/Users/takatoosetsuo/ketcindy/ketsample/samples/s07slides"
"/Applications/kettex/texlive/bin/x86_64-darwin/uplatex" s0704para.tex
"/Applications/kettex/texlive/bin/x86_64-darwin/dvipdfmx" s0704para.dvi
rm s0704para.dvi
open -a "skim" s0704para.pdf
exit 0
