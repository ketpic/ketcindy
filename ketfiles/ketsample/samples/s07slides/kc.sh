#!/bin/sh
cd "/Users/takatoosetsuo/ketcindy/ketfiles/ketsample/samples/s07slides"
"/Applications/kettex/texlive/bin/x86_64-darwin/uplatex" animatesinemove.tex
"/Applications/kettex/texlive/bin/x86_64-darwin/uplatex" animatesinemove.tex
"/Applications/kettex/texlive/bin/x86_64-darwin/dvipdfmx" animatesinemove.dvi
rm animatesinemove.dvi
"/Applications/Adobe Acrobat Reader DC.app/Contents/MacOS/AdobeReader" animatesinemove.pdf
exit 0
