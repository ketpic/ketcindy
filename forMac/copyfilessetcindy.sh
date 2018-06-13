#!/bin/sh
#      20180607
ketsrc=/Volumes/ketcindyfolder
if [ ! -e $ketsrc ]; then
  ketsrc=~/Desktop/ketcindyfolder
fi
echo ${ketsrc} will be used
echo 1. "/Applications/kettex/texlive (default)"
echo 2. "/Applications/kettex.app/texlive"
echo 3. "/Library/TeX (TeXLive)"
echo 4. other
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
if [ ${ans} = "4" ]; then
  read -p 'Path of TeX (ex)/Applications/UpTeX.app/teTex/share : ' ans
  texpath=${ans}
  read -p 'Path of texbin (ex)/Applications/UpTeX.app/teTex/bin : ' ans
  texbinpath=${ans}
  echo texpath=${texpath}
  echo texbinpath=${texbinpath}
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

cindyplug=/Applications/Cinderella2.app/Contents/PlugIns
read -p 'Input path of Cinderella d(efault)=/Applications/Cinderella2 : ' ans
if [ ${ans} != "d" ]; then
 cindyplug=${ans}.app/Contents/PlugIns
fi
echo Cinderella Plugins=${cindyplug}
cd ${ketcindyscripts}
cp -p ketjava/KetCindyPlugin.jar ${cindyplug}
homehead=/Users
#read -p 'Head to user home d(efault)=/Users : ' ans
#echo $ans
#if [ ${ans} != "d" ]; then
#  homehead=$ans
#fi
echo "PathThead=\"${texbinpath}/\";"  > ${cindyplug}/ketcindy.ini
echo "Dirhead=\"${ketcindyscripts}\";"  >> ${cindyplug}/ketcindy.ini
echo "Homehead=\"${homehead}\";"  >> ${cindyplug}/ketcindy.ini
echo "setdirectory(Dirhead);"  >> ${cindyplug}/ketcindy.ini
echo "import(\"setketcindy.txt\");"  >> ${cindyplug}/ketcindy.ini
echo "import(\"ketoutset.txt\");"  >> ${cindyplug}/ketcindy.ini
read -p 'Choose pdfviewer from preview(p),skim(s): ' ans
if [ ${ans} = "s" ]; then
  echo  "Pathpdf=\"skim\";" >> ${cindyplug}/ketcindy.ini
else
  echo  "Pathpdf=\"preview\";" >> ${cindyplug}/ketcindy.ini
fi
echo "KetCindyPlugin and others copied to Cinderella"
sleep 1
exit 0