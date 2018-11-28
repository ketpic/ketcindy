#!/bin/sh
#      20181129
cd `dirname $0`
echo `pwd`/work will be used
changesetting=/.ketcindy.conf #181017
dist=~/ketcindy #180913
cp -r -p work/  ${dist}/
if [ $? -gt 0 ]; then
  echo Error:$?
  sleep 5
else
  echo Workfolder will be generated as ${dist}
  echo This folder ketcindy can be moved to any place ##180913
fi
read -p 'Choose platex(p),uplatex(u),latex(l),xelatex(x),pdflatex(pd),lualatex(lu):' tex
if [ ${tex} = "p" ]; then
  tex="platex"
  cd doc/ketmanual
  cp -p  KeTCindyReferenceJ.pdf ${dist}
  cp -p  KeTCindyGuideJ.pdf ${dist}
  cp -p  KeTpicStyleJ.pdf ${dist}
fi
if [ ${tex} = "u" ]; then
  tex="uplatex"
  cd doc/ketmanual
  cp -p  KeTCindyReferenceJ.pdf ${dist}
  cp -p  KeTCindyGuideJ.pdf ${dist}
  cp -p  KeTpicStyleJ.pdf ${dist}
fi
if [ ${tex} = "l" ]; then
  tex="latex"
  cd doc/ketmanual
  cp -p  KeTCindyReferenceE.pdf ${dist}
  cp -p  KeTCindyGuideE.pdf ${dist}
  cp -p  KeTpicStyleE.pdf ${dist}
fi
if [ ${tex} = "x" ]; then
  tex="xelatex"
  cd ketmanual
  cp -p  KeTCindyReferenceE.pdf ${dist}
  cp -p  KeTCindyGuideE.pdf ${dist}
  cp -p  KeTpicStyleE.pdf ${dist}
fi
if [ ${tex} = "pd" ]; then
  tex="pdflatex"
  cd doc/ketmanual
  cp -p  KeTCindyReferenceE.pdf ${dist}
  cp -p  KeTCindyGuideE.pdf ${dist}
  cp -p  KeTpicStyleE.pdf ${dist}
fi
if [ ${tex} = "lu" ]; then
  tex="lualatex"
  cd doc/ketmanual
  cp -p  KeTCindyReferenceE.pdf ${dist}
  cp -p  KeTCindyGuideE.pdf ${dist}
  cp -p  KeTpicStyleE.pdf ${dist}
fi
dist=~ #180913
echo  generating ${dist}/${changesetting}
echo  // Re-setting PathT,PathR,Pathpdf,PathM,PathAd,Mackc >${dist}${changesetting}
echo  "PathT=PathThead+\"${tex}\";" >>${dist}${changesetting}
read -p 'Choose pdfviewer from preview(p),skim(s): ' ans
if [ ${ans} = "s" ]; then
  echo  "Pathpdf=\"skim\";" >> ${dist}${changesetting}
else
  echo  "Pathpdf=\"preview\";" >> ${dist}${changesetting}
fi
#read -p 'Execute kc.sh with sh(s),open(o):' ans
#if [ ${ans} = "o" ]; then
  echo  "Mackc=\"open\";" >>${dist}${changesetting}
#else
#  echo  "Mackc=\"sh\";" >>${dist}${changesetting}
#fi
sleep 1
exit 0