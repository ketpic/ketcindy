#!/bin/sh
#      2017.11.17
ketsrc=/Volumes/ketcindyfolder
if [ ! -e $ketsrc ]; then
  ketsrc=~/Desktop/ketcindyfolder
fi
ketsrc=${ketsrc}/work
echo ${ketsrc} will be used
ketcindyhead=~/ketcidyhead.txt
folder=ketcindy
read -p 'Name of working folder d(efault)=ketcindy :' ans
if [ ${ans} != "d" ]; then
  folder=${ans}
fi
read -p 'Path of working folder : userhome(u) desktop(d) other(o) ' ans
if [ ${ans} = "u" ]; then
  dist=~/${folder}
  echo "Dirfile=gethome()+\"/${folder}\";" > ${ketcindyhead}
fi
if [ ${ans} = "d" ]; then
  dist=~/Desktop/${folder}
  echo "Dirfile=gethome()+\"/Desktop/${folder}\";"  > ${ketcindyhead}
fi
if [ ${ans} = "o" ]; then 
  read -p 'pathname in user home (ex. work for ~/work):' ans
  dist=~/${ans}/${folder}
  echo "Dirfile=gethome()+\"/${ans}/${folder}\";" > ${ketcindyhead}
fi
cp -r -p ${ketsrc}/  ${dist}/
if [ $? -gt 0 ]; then
  echo Error:$?
  sleep 5
else
  echo "work folder copied to "${dist}
fi
read -p 'Choose platex(p),uplatex(u),latex(l),xelatex(x),pdflatex(pd),lualatex(lu):' tex
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
echo  "PathT=PathThead+\"${tex}\";" >>${ketcindyhead}
read -p 'Execute kc.sh with sh(s),open(o):' ans
if [ ${ans} = "o" ]; then
  echo  "Mackc=\"open\";" >>${ketcindyhead}
else
  echo  "Mackc=\"sh\";" >>${ketcindyhead}
fi
read -p 'Do you copy ketcindy manual? (y,n)' ans
if [ ${ans} = "y" ]; then
  cd ${ketsrc}/misc/ketmanual
  cp -p  KeTCindyReferenceJ.pdf ${dist}/ketcindy
fi
sleep 1
exit 0