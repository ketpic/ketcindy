#!/bin/sh
#      20200504

cd `dirname $0`
if [ -e ../ketcindyfolder ]; then
  cd ../ketcindyfolder
fi

echo `pwd ` will be used
sudo spctl --master-enable

echo 1. "/Applications/kettex"
echo 2. "TeXLive"
echo 3. Other
read -p 'Choose number from the above (number) : ' ans
if [ ${ans} = "1" ]; then 
  texpath=/Applications/kettex/texlive
  texbinpath=${texpath}/bin/x86_64-darwin
fi
if [ ${ans} = "2" ]; then
  texpath=/Library/TeX/Root
  texbinpath=/Library/TeX/texbin
fi
if [ ${ans} = "3" ]; then
  read -p ' Input texpath (/Library/TeX/Root) : ' texpath
  read -p ' Input texbinpath ((/Library/TeX/texbin) : ' texbinpath
fi
ketcindyscripts=${texpath}/texmf-dist/scripts/ketcindy
ketcindydoc=${texpath}/texmf-dist/doc/support/ketcindy
ketcindystyle=${texpath}/texmf-dist/tex/latex/ketcindy

echo texpath=${texpath}
echo texbinpath=${texbinpath}
echo Copying scripts
sudo cp -r -p scripts/ ${ketcindyscripts}/
if [ $? -gt 0 ]; then
  echo Error $?
  sleep 5
else
  echo "scripts copied to "${ketcindyscripts}
fi
sudo cp -r -p doc/ ${ketcindydoc}/
if [ $? -gt 0 ]; then
  echo Error $?
  sleep 5
else
  echo "doc copied to "${ketcindydoc}
fi
sudo cp -r -p style/ ${ketcindystyle}/
if [ $? -gt 0 ]; then
  echo Error $?
  sleep 5
else
  echo "styles copied to "${ketcindystyle}
  sudo ${texbinpath}/mktexlsr
fi
sleep 1
exit 0