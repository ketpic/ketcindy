#!/bin/sh
#      20180310

# Edit and uncomment the following lines if necessary
texpath=/usr/share/texlive
texbinpath=/usr/bin

kettex=0
if [ ${kettex} -eq 0 ]; then
  texpath=/opt/kettex/texlive
  texbinpath=/opt/kettex/texlive/bin/x86_64-linux
fi

#ketsrc=~/Desktop/ketcindyfolder
cindyplug=/usr/local/cinderella/Plugins
homehead=/home

ketcindyscripts=${texpath}/texmf-dist/scripts/ketcindy
ketcindydoc=${texpath}/texmf-dist/doc/support/ketcindy
ketcindystyle=${texpath}/texmf-dist/tex/latex/ketcindy

cd `dirname $0`
if [ -e ../ketcindyfolder ]; then
  cd ../ketcindyfolder
fi

echo texpath=${texpath}
echo texbinpath=${texbinpath}
echo cinderella plugin=${cindyplug}
echo home=${homehead}
read -p 'Are the above paths OK? (y/n) : ' ans
if [ ${ans} = "n" ]; then 
  echo Edit paths
  sleep 2
  exit 0
fi

echo copying scripts
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
cd ${cindyplug}
if [ -e KetCindyPlugin.jar ]; then
  sudo rm ${cindyplug}/KetCindyPlugin.jar
fi
if [ -e ketcindy.ini ]; then
  sudo rm ${cindyplug}/ketcindy.ini
fi
cd ${ketcindyscripts}
cp -p ketjava/KetCindyPlugin.jar ${cindyplug}
echo "PathThead=\"${texbinpath}/\";"  > ${cindyplug}/ketcindy.ini
echo "Dirhead=\"${ketcindyscripts}\";"  >> ${cindyplug}/ketcindy.ini
echo "Homehead=\"${homehead}\";"  >> ${cindyplug}/ketcindy.ini
echo "setdirectory(Dirhead);"  >> ${cindyplug}/ketcindy.ini
echo "import(\"setketcindy.txt\");"  >> ${cindyplug}/ketcindy.ini
echo "import(\"ketoutset.txt\");"  >> ${cindyplug}/ketcindy.ini
echo "KetCindyPlugin and others copied to Cinderella"
sleep 1
exit 0
