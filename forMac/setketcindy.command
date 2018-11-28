#!/bin/sh
#      20181129

# Edit and uncomment the following lines if necessary
#texpath=/Applications/kettex/texlive
#texbinpath=${texpath}/bin/x86_64-darwin
#ketcindyscripts=${texpath}/texmf-dist/scripts/ketcindy
#ketcindydoc=${texpath}/texmf-dist/doc/support/ketcindy
#ketcindystyle=${texpath}/texmf-dist/tex/latex/ketcindy

cindyplug=/Applications/Cinderella2.app/Contents/PlugIns
homehead=/Users

cd `dirname $0`
echo `pwd ` will be used
echo 1. "/Applications/kettex/texlive".
echo 2. "/Applications/kettex.app/texlive"
echo 3. "/Library/TeX (TeXLive)"
echo 4. Modification of this file is finished
read -p 'Choose path of TeX from the above (number) : ' ans
if [ ${ans} = "1" ]; then 
  texpath=/Applications/kettex/texlive
  texbinpath=${texpath}/bin/x86_64-darwin
  ketcindyscripts=${texpath}/texmf-dist/scripts/ketcindy
  ketcindydoc=${texpath}/texmf-dist/doc/support/ketcindy
  ketcindystyle=${texpath}/texmf-dist/tex/latex/ketcindy
fi
if [ ${ans} = "2" ]; then 
  texpath=/Applications/kettex.app/texlive
  texbinpath=${texpath}/bin/x86_64-darwin
  ketcindyscripts=${texpath}/texmf-dist/scripts/ketcindy
  ketcindydoc=${texpath}/texmf-dist/doc/support/ketcindy
  ketcindystyle=${texpath}/texmf-dist/tex/latex/ketcindy
fi
if [ ${ans} = "3" ]; then
  texpath=/Library/TeX/Root
  texbinpath=/Library/TeX/texbin
  ketcindyscripts=${texpath}/texmf-dist/scripts/ketcindy
  ketcindydoc=${texpath}/texmf-dist/doc/support/ketcindy
  ketcindystyle=${texpath}/texmf-dist/tex/latex/ketcindy
fi
echo texpath=${texpath}
echo texbinpath=${texbinpath}
#read -p 'Do you really copy ketcindyscripts? (y,n): ' ans
#if [ ${ans} = "y" ]; then
  echo copying scripts
  sudo cp -r -p scripts/ ${ketcindyscripts}/
  if [ $? -gt 0 ]; then
    echo Error $?
    sleep 5
  else
    echo "scripts copied to "${ketcindyscripts}
  fi
#fi
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

read -p 'Plugins d(efault)='${cindyplug}' : ' ans
if [ ${ans} != "d" ]; then
  cindyplug=${ans}
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