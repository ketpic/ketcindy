#!/bin/sh
#      2017.11.17
ketsrc=/Volumes/ketcindyfolder
if [ ! -e $ketsrc ]; then
  ketsrc=~/Desktop/ketcindyfolder
fi
echo ${ketsrc} will be used
echo 1. "/Applications/KeTTeX/texlive (default)"
echo 2. "/Library/TeX (TeXLive)"
#echo 3. "/Applications/KeTTeX.app/texlive"
echo 3. other
read -p 'Choose path of TeX from the above (number) : ' ans
if [ ${ans} = "1" ]; then 
  texpath=/Applications/KeTTeX/texlive
  texbinpath=${texpath}/bin/x86_64-darwin
fi
if [ ${ans} = "2" ]; then
  texpath=/Library/TeX/Root
  texbinpath=/Library/TeX/texbin
fi
#if [ ${ans} = "3" ]; then 
#  texpath=/Applications/KeTTeX.app/texlive
#fi
if [ ${ans} = "3" ]; then
  read -p 'Input path of TeX (ex)/Applications/UpTeX.app/teTex/share : ' ans
  texpath=${ans}
  read -p 'Input path of texbin (ex)/Applications/UpTeX.app/teTex/bin : ' ans
  texbinpath=${ans}
  echo texpath=${texpath}
  echo texbinpath=${texbinpath}
fi
echo texpath=${texpath}
echo texbinpath=${texbinpath}
ketcindyscripts=${texpath}/texmf-dist/scripts/ketcindy
read -p 'Do you really copy ketcindyscripts? (y,n):' ans
if [ ${ans} = "y" ]; then
  echo copying scripts
  sudo cp -r -p ${ketsrc}/scripts/ ${ketcindyscripts}/
  if [ $? -gt 0 ]; then
    echo Error $?
    sleep 5
  fi
else
  echo "scripts copied to "${ketcindyscripts}
fi
ketcindystyle=${texpath}/texmf-dist/tex/latex/ketcindy
read -p 'Do you copy ketcindy styles? (y,n):' ans
if [ ${ans} = "y" ]; then
  sudo cp -r -p ${ketsrc}/misc/ketpicstyle/ketcindy/ ${ketcindystyle}/
  if [ $? -gt 0 ]; then
    echo Error $?
    sleep 5
  else
    sudo ${texbinpath}/mktexlsr
    echo "styles copied to "${ketcindystyle}
  fi
fi
sleep 1
exit 0