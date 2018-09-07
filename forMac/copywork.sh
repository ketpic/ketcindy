#!/bin/sh
#      20180907
ketfolder=/Volumes/ketcindyfolder
if [ ! -e $ketfolder ]; then
  ketfolder=~/Desktop/ketcindyfolder
fi
ketsrc=${ketfolder}/work
echo ${ketsrc} will be used
changesetting=/changesetting.txt
# read -p 'Path of working folder : userhome(u) desktop(d) :' ans
# if [ ${ans} = "u" ]; then
  dist=~/ketcindy
# fi
# if [ ${ans} = "d" ]; then
#   dist=~/Desktop/ketcindy
# fi
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
  cd ${ketfolder}/doc/ketmanual
  cp -p  KeTCindyReferenceJ.pdf ${dist}
  cp -p  KeTCindyGuideJ.pdf ${dist}
  cp -p  KeTpicStyleJ.pdf ${dist}
fi
if [ ${tex} = "u" ]; then
  tex="uplatex"
  cd ${ketfolder}/doc/ketmanual
  cp -p  KeTCindyReferenceJ.pdf ${dist}
  cp -p  KeTCindyGuideJ.pdf ${dist}
  cp -p  KeTpicStyleJ.pdf ${dist}
fi
if [ ${tex} = "l" ]; then
  tex="latex"
  cd ${ketfolder}/doc/ketmanual
  cp -p  KeTCindyReferenceE.pdf ${dist}
  cp -p  KeTCindyGuideE.pdf ${dist}
  cp -p  KeTpicStyleE.pdf ${dist}
fi
if [ ${tex} = "x" ]; then
  tex="xelatex"
  cd ${ketfolder}/doc/ketmanual
  cp -p  KeTCindyReferenceE.pdf ${dist}
  cp -p  KeTCindyGuideE.pdf ${dist}
  cp -p  KeTpicStyleE.pdf ${dist}
fi
if [ ${tex} = "pd" ]; then
  tex="pdflatex"
  cd ${ketfolder}/doc/ketmanual
  cp -p  KeTCindyReferenceE.pdf ${dist}
  cp -p  KeTCindyGuideE.pdf ${dist}
  cp -p  KeTpicStyleE.pdf ${dist}
fi
if [ ${tex} = "lu" ]; then
  tex="lualatex"
  cd ${ketfolder}/doc/ketmanual
  cp -p  KeTCindyReferenceE.pdf ${dist}
  cp -p  KeTCindyGuideE.pdf ${dist}
  cp -p  KeTpicStyleE.pdf ${dist}
fi
echo  // Re-setting PathT,PathR,Pathpdf,PathM,PathAd >${dist}${changesetting}
echo  "PathT=PathThead+\"${tex}\";" >>${dist}${changesetting}
read -p 'Choose pdfviewer from preview(p),skim(s): ' ans
if [ ${ans} = "s" ]; then
  echo  "Pathpdf=\"skim\";" >> ${dist}${changesetting}
else
  echo  "Pathpdf=\"preview\";" >> ${dist}${changesetting}
fi
read -p 'Execute kc.sh with sh(s),open(o):' ans
if [ ${ans} = "o" ]; then
  echo  "Mackc=\"open\";" >>${dist}${changesetting}
else
  echo  "Mackc=\"sh\";" >>${dist}${changesetting}
fi
sleep 1
exit 0