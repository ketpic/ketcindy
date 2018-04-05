#!/bin/sh
#      20180405
ketfolder=/Volumes/ketcindyfolder
if [ ! -e $ketfolder ]; then
  ketfolder=~/Desktop/ketcindyfolder
fi
ketsrc=${ketfolder}/work
echo ${ketsrc} will be used
changesetting=/changesetting.txt
read -p 'Path of working folder : userhome(u) :' ans
if [ ${ans} = "u" ]; then
  dist=~/ketcindy
fi
cp -r -p ${ketsrc}/  ${dist}/
if [ $? -gt 0 ]; then
  echo Error:$?
  sleep 5
else
  echo "work folder copied to "${dist}
fi
read -p 'Choose platex(p),uplatex(u),latex(l),xelatex(x),pdflatex(pd),lualatex(lu):' tex
if [ ${tex} = "p" ]; then
  tex="platex"
fi
if [ ${tex} = "u" ]; then
  tex="uplatex"
fi
if [ ${tex} = "l" ]; then
  tex="latex"
fi
if [ ${tex} = "x" ]; then
  tex="xelatex"
fi
if [ ${tex} = "pd" ]; then
  tex="pdflatex"
fi
if [ ${tex} = "lu" ]; then
  tex="lualatex"
fi
echo  // Re-setting PathT,PathR,Pathpdf,PathM,PathAd >${dist}${changesetting}
echo  "PathT=PathThead+\"${tex}\";" >>${dist}${changesetting}
read -p 'Execute kc.sh with sh(s),open(o):' ans
if [ ${ans} = "o" ]; then
  echo  "Mackc=\"open\";" >>${dist}${changesetting}
else
  echo  "Mackc=\"sh\";" >>${dist}${changesetting}
fi
read -p 'Do you copy ketcindy manual? (y,n)' ans
if [ ${ans} = "y" ]; then
  cd ${ketfolder}/doc/ketmanual
  cp -p  KeTCindyReferenceJ.pdf ${dist}
fi
sleep 1
exit 0