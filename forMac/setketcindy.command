#!/bin/sh
#      20190613

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

# 20190613from
cd ${cindyplug}
remake="y"
if [ -e ketcindy.ini ]; then
  echo "Contentes of ketcindy.ini : " 
  echo ""
  cat ketcindy.ini
  echo ""
  read -p 'Do you want to remake ketcindy.ini? (y/n) : ' remake
fi
if [ ! ${remake} = "y" ]; then
  echo "finished"
  sleep 1
  exit 0
fi
# 20190613to

echo "PathThead=\"${texbinpath}/\";"  > ketcindy.ini
echo "Dirhead=\"${ketcindyscripts}\";"  >> ketcindy.ini
echo "Homehead=\"${homehead}\";"  >> ketcindy.ini
echo "setdirectory(Dirhead);"  >> ketcindy.ini
echo "import(\"setketcindy.txt\");"  >> ketcindy.ini
echo "import(\"ketoutset.txt\");"  >> ketcindy.ini

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
echo  "PathT=PathThead+\"${tex}\";" >> ketcindy.ini
echo  "Pathpdf=\"preview\";" >> ketcindy.ini

pathM="/Applications/Maxima.app/Contents/Resources/maxima.sh"
pathMn="/Applications/Maxima.app/Contents/Resources/opt/bin/maxima"
find -f ${pathM}
if [ $? -gt 0 ]; then
  echo  "PathM=\"${pathMn}\";" >> ketcindy.ini
else
  echo  "PathM=\"${pathM}\";" >> ketcindy.ini
fi
echo  "Mackc=\"open\";" >> ketcindy.ini

echo "ketcindy.ini generated(updated)"
sleep 1
exit 0