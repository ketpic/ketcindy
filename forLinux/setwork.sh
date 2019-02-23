#!/bin/sh
#      20190223

# Edit and uncomment the following line if necessary
pathpdf=evince
home=~
dist=${home}/ketcindywork # work folder of ketcindy


cd `dirname $0`
if [ -e ../ketcindyfolder ]; then
  cd ../ketcindyfolder
fi
echo `pwd`/work will be copied
changesetting=/.ketcindy.conf #181017
cp -r -p work/  ${dist}/
if [ $? -gt 0 ]; then
  echo Error:$?
  sleep 5
else
  echo Workfolder has been generated as ${dist}
  echo "This folder can be moved to any place" ##180913
fi
cd doc/ketmanual
read -p 'Choose platex(p),uplatex(u),latex(l),xelatex(x),pdflatex(pd),lualatex(lu):' tex
if [ ${tex} = "p" ]; then
  tex="platex"
  cp -p  KeTCindyReferenceJ.pdf ${dist}
  cp -p  KeTCindyGuideJ.pdf ${dist}
  cp -p  KeTPicStyleJ.pdf ${dist}
fi
if [ ${tex} = "u" ]; then
  tex="uplatex"
  cp -p  KeTCindyReferenceJ.pdf ${dist}
  cp -p  KeTCindyGuideJ.pdf ${dist}
  cp -p  KeTPicStyleJ.pdf ${dist}
fi
if [ ${tex} = "l" ]; then
  tex="latex"
  cp -p  KeTCindyReferenceE.pdf ${dist}
  cp -p  KeTCindyGuideE.pdf ${dist}
  cp -p  KeTPicStyleE.pdf ${dist}
fi
if [ ${tex} = "x" ]; then
  tex="xelatex"
  cp -p  KeTCindyReferenceE.pdf ${dist}
  cp -p  KeTCindyGuideE.pdf ${dist}
  cp -p  KeTPicStyleE.pdf ${dist}
fi
if [ ${tex} = "pd" ]; then
  tex="pdflatex"
  cp -p  KeTCindyReferenceE.pdf ${dist}
  cp -p  KeTCindyGuideE.pdf ${dist}
  cp -p  KeTPicStyleE.pdf ${dist}
fi
if [ ${tex} = "lu" ]; then
  tex="lualatex"
  cp -p  KeTCindyReferenceE.pdf ${dist}
  cp -p  KeTCindyGuideE.pdf ${dist}
  cp -p  KeTPicStyleE.pdf ${dist}
fi
echo  generating ${home}/${changesetting}
echo  // Re-setting PathT,PathR,Pathpdf,PathM,PathAd >${home}${changesetting}
echo  "PathT=PathThead+\"${tex}\";" >>${home}${changesetting}
echo  "Pathpdf=\"${pathpdf}\";" >> ${home}${changesetting}
echo  "Mackc=\"bash\";" >>${home}${changesetting}
sleep 1
exit 0