#!/bin/sh
cd "/Users/takatoosetsuo/ketcindy/ketsample/samples/s07slides"
"/Library/TeX/texbin/platex" s0706animate.tex
"/Library/TeX/texbin/dvipdfmx" s0706animate.dvi
rm s0706animate.dvi
"/Applications/Adobe Acrobat Reader DC.app/Contents/MacOS/AdobeReader" s0706animate.pdf
exit 0
