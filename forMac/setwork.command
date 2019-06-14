#!/bin/sh
#      20190614
cd `dirname $0`
if [ -e ../ketcindyfolder ]; then
  cd ../ketcindyfolder
fi
echo Files will be copied from
echo "    "`pwd`/work
changesetting=/.ketcindy.conf #181017
home=~
dist=${home}/ketcindy #180913
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

echo  Generating ${home}/${changesetting}
echo // Re-setting PathT,PathR,Pathpdf,PathM,PathAd,Mackc >${home}${changesetting}
echo "// PathT=PathThead+\"platex\";" >>${home}${changesetting}
echo "// Pathpdf=\"skim\";" >> ${home}${changesetting}
pathM="/Applications/Maxima.app/Contents/Resources/maxima.sh"
pathMn="/Applications/Maxima.app/Contents/Resources/opt/bin/maxima"
echo "// PathM=\"${pathM}\";" >> ${home}${changesetting}
echo "// PathM=\"${pathMn}\";" >> ${home}${changesetting}
echo "// Mackc=\"open\";" >>${home}${changesetting}

sleep 1
exit 0