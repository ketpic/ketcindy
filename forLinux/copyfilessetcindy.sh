#!/bin/sh
#      20181120

# Edit and uncomment the following 3 lines if necessary
texpath=/Applications/kettex/texlive
texbinpath=${texpath}/bin/x86_64-darwin
ketsrc=~/Desktop/ketcindyfolder

if [ ! -e $ketsrc ]; then
  ketsrc=/Volumes/ketcindyfolder
  if [ ! -e $ketsrc ]; then
    echo "Edit path of ketcindyfolder"
    sleep 5
    exit 0
  fi
fi
echo ketcindyfolder=${ketsrc}
echo 1. "/Applications/kettex/texlive".
echo 2. "/Applications/kettex.app/texlive"
echo 3. "/Library/TeX (TeXLive)"
echo 4. This sh file has been modified
read -p 'Choose path of TeX from the above (number) : ' ans
if [ ${ans} = "1" ]; then 
  texpath=/Applications/kettex/texlive
  texbinpath=${texpath}/bin/x86_64-darwin
fi
if [ ${ans} = "2" ]; then 
  texpath=/Applications/kettex.app/texlive
  texbinpath=${texpath}/bin/x86_64-darwin
fi
if [ ${ans} = "3" ]; then
  texpath=/Library/TeX/Root
  texbinpath=/Library/TeX/texbin
fi
echo texpath=${texpath}
echo texbinpath=${texbinpath}
ketcindyscripts=${texpath}/texmf-dist/scripts/ketcindy
read -p 'Do you really copy ketcindyscripts? (y,n): ' ans
if [ ${ans} = "y" ]; then
  echo copying scripts
  sudo cp -r -p ${ketsrc}/scripts/ ${ketcindyscripts}/
  if [ $? -gt 0 ]; then
    echo Error $?
    sleep 5
  else
    echo "scripts copied to "${ketcindyscripts}
  fi
fi
ketcindydoc=${texpath}/texmf-dist/doc/support/ketcindy
sudo cp -r -p ${ketsrc}/doc/ ${ketcindydoc}/
if [ $? -gt 0 ]; then
  echo Error $?
  sleep 5
else
  echo "doc copied to "${ketcindydoc}
fi
ketcindystyle=${texpath}/texmf-dist/tex/latex/ketcindy
sudo cp -r -p ${ketsrc}/style/ ${ketcindystyle}/
if [ $? -gt 0 ]; then
  echo Error $?
  sleep 5
else
  echo "styles copied to "${ketcindystyle}
  sudo ${texbinpath}/mktexlsr
fi

read -p 'Input path of Cinderella d(efault)=/Applications/Cinderella2.app : ' ans
if [ ${ans} = "d" ]; then
  cindyplug=/Applications/Cinderella2.app/Contents/PlugIns
else
  cindyplug=${ans}/Contents/PlugIns
fi
echo Cinderella Plugins=${cindyplug}
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