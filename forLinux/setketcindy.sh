#!/bin/sh
#      20181006

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
sudo cp -r -p scripts/* ${ketcindyscripts}/
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
  sudo rm KetCindyPlugin.jar
fi
cd ${ketcindyscripts}
cp -p ketjava/KetCindyPlugin.jar ${cindyplug}
echo "KetCindyPlugin.jar copied to Cinderella"

# 20190616from
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
  echo  "ketcindy.ini will be made"
else
  echo "finished"
  sleep 1
  exit 0
fi
# 20190616to

if [ -e ketcindy.ini ]; then
    sudo rm ketcindy.ini
fi
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

read -p 'Number of default graphics (1=tpic, 2=pict2e, 3=tikz) : ' num
if [ ${num} = "1" ]; then
  gc="tpic"
fi
if [ ${num} = "2" ]; then
  gc="pict2e"
fi
if [ ${num} = "3" ]; then
  gc="tikz"
fi
echo  "Usegraphics(\"${gc}\");" >> ketcindy.ini

read -p 'PDF viewer (ex) evince : ' pathpdf
echo  "Pathpdf=\"${pathpdf}\";" >> ketcindy.ini

echo  "Mackc=\"bash\";" >> ketcindy.ini

echo "ketcindy.ini generated(updated)"
sleep 1
exit 0
