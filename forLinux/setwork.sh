#!/bin/sh
#      20190614

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

echo  generating ${home}/${changesetting}
echo  // Re-setting PathT,PathR,Pathpdf,PathM,PathAd >${home}${changesetting}
echo  "PathT=PathThead+\"${tex}\";" >>${home}${changesetting}
echo  "Pathpdf=\"${pathpdf}\";" >> ${home}${changesetting}
echo  "Mackc=\"bash\";" >>${home}${changesetting}
sleep 1
exit 0