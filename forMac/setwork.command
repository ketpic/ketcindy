#!/bin/sh
#      20190413
cd `dirname $0`
if [ -e ../ketcindyfolder ]; then
  cd ../ketcindyfolder
fi
echo Files will be copied from
echo "    "`pwd`/work
changesetting=/.ketcindy.conf #181017
dist=~/ketcindy #180913
cp -r -p work/  ${dist}/
if [ $? -gt 0 ]; then
  echo Error:$?
  sleep 5
else
  echo Workfolder has been generated as ${dist}
  echo "    "This folder can be moved to any place ##180913
fi
read -p 'Language (j/e) : ' lang
cd doc/ketmanual
if [ ${lang} = "e" ]; then
  cp -p  KeTCindyReferenceE.pdf ${dist}
  cp -p  KeTCindyGuideE.pdf ${dist}
  cp -p  KeTpicStyleE.pdf ${dist}
else
  cp -p  KeTCindyReferenceJ.pdf ${dist}
  cp -p  KeTCindyGuideJ.pdf ${dist}
  cp -p  KeTpicStyleJ.pdf ${dist}
fi

dist=~ 
echo  Generating ${dist}/${changesetting}
echo // Re-setting PathT,PathR,Pathpdf,PathM,PathAd,Mackc >${dist}${changesetting}
echo "// PathT=PathThead+\"platex\";" >>${dist}${changesetting}
echo "// Pathpdf=\"skim\";" >> ${dist}${changesetting}
pathM="/Applications/Maxima.app/Contents/Resources/maxima.sh"
pathMn="/Applications/Maxima.app/Contents/Resources/opt/bin/maxima"
echo "// PathM=\"${pathM}\";" >> ${dist}${changesetting}
echo "// PathM=\"${pathMn}\";" >> ${dist}${changesetting}
echo "// Mackc=\"open\";" >>${dist}${changesetting}

sleep 1
exit 0