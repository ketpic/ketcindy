#!/bin/sh
#      20200112

homehead=/Users
cindyplug=/Applications/Cinderella2.app/Contents/PlugIns
texpath=/Applications/kejs/texlive

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
texbinpath=${texpath}/bin/x86_64-darwin
ketcindyscripts=${texpath}/texmf-dist/scripts/ketcindy
ketcindydoc=${texpath}/texmf-dist/doc/support/ketcindy
ketcindystyle=${texpath}/texmf-dist/tex/latex/ketcindy

echo texpath=${texpath}
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

cd ${ketcindyscripts}
cp -p ketjava/KetCindyPlugin.jar ${cindyplug}

cd ${cindyplug}
remake="y"
if [ -e ketcindy.ini ]; then
  echo "Contentes of ketcindy.ini : " 
  echo ""
  cat ketcindy.ini
  echo ""
  read -p 'Do you want to remake ketcindy.ini? (y/n) : ' remake
fi
if [ ${remake} = "y" ]; then
  echo "ketcindy.ini will be made"
else
  echo "finished"
  sleep 1
  exit 0
fi

echo "PathThead=\"${texbinpath}/\";"  > ketcindy.ini
echo "Dirhead=\"${ketcindyscripts}\";"  >> ketcindy.ini
echo "Homehead=\"${homehead}\";"  >> ketcindy.ini
echo "setdirectory(Dirhead);"  >> ketcindy.ini
echo "import(\"setketcindy.txt\");"  >> ketcindy.ini

#191224from
read -p 'Language for Help (j/e) : ' lang
echo  "Langhelp=\"${lang}\";" >> ketcindy.ini
#191224upto

echo "import(\"ketoutset.txt\");"  >> ketcindy.ini

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