#!/bin/sh
#      20190413

# Edit and uncomment the following lines if necessary
#texpath=/Applications/kettex/texlive
#texbinpath=${texpath}/bin/x86_64-darwin
#ketcindyscripts=${texpath}/texmf-dist/scripts/ketcindy
#ketcindydoc=${texpath}/texmf-dist/doc/support/ketcindy
#ketcindystyle=${texpath}/texmf-dist/tex/latex/ketcindy
homehead=/Users
cindyplug=/Applications/Cinderella2.app/Contents/PlugIns

echo Plugins of Cinderella
read -p '    '${cindyplug}?' (y/n): ' ans
if [ ${ans} != "y" ]; then
  echo Edit cindyplug in this file
  sleep 2
  exit 0
fi
echo Cinderella Plugins=${cindyplug}

cd `dirname $0`
if [ -e ../ketcindyfolder ]; then
  cd ../ketcindyfolder
fi

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

cd ${ketcindyscripts}
cp -p ketjava/KetCindyPlugin.jar ${cindyplug}
echo "PathThead=\"${texbinpath}/\";"  > ${cindyplug}/ketcindy.ini
echo "Dirhead=\"${ketcindyscripts}\";"  >> ${cindyplug}/ketcindy.ini
echo "Homehead=\"${homehead}\";"  >> ${cindyplug}/ketcindy.ini
echo "setdirectory(Dirhead);"  >> ${cindyplug}/ketcindy.ini
echo "import(\"setketcindy.txt\");"  >> ${cindyplug}/ketcindy.ini
echo "import(\"ketoutset.txt\");"  >> ${cindyplug}/ketcindy.ini

echo "Choose TeX with the 1st(+2nd) character"
read -p 'p=platex, u=uplatex, l=latex, x=xelatex, pd=pdflatex, lu=lualatex:' tex
if [ ${tex} = "p" ]; then
  tex="platex"
fi
if [ ${tex} = "u" ]; then
  tex="uplatex"
fi
if [ ${tex} = "l" ]; then
  tex="latex"
fi
if [ ${tex} = "x" ]; then
  tex="xelatex"
fi
if [ ${tex} = "pd" ]; then
  tex="pdflatex"
fi
if [ ${tex} = "lu" ]; then
  tex="lualatex"
fi
echo  "PathT=PathThead+\"${tex}\";" >> ${cindyplug}/ketcindy.ini
echo  "Pathpdf=\"preview\";" >> ${cindyplug}/ketcindy.ini

pathM="/Applications/Maxima.app/Contents/Resources/maxima.sh"
pathMn="/Applications/Maxima.app/Contents/Resources/opt/bin/maxima"
find -f ${pathM}
if [ $? -gt 0 ]; then
  echo  "PathM=\"${pathMn}\";" >> ${cindyplug}/ketcindy.ini
else
  echo  "PathM=\"${pathM}\";" >> ${cindyplug}/ketcindy.ini
fi
echo  "Mackc=\"open\";" >> ${cindyplug}/ketcindy.ini

echo "KetCindyPlugin and others copied to Cinderella"
sleep 1
exit 0