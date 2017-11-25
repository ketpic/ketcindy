#!/bin/sh
#      2017.11.17
cindyplug=/Applications/Cinderella2.app/Contents/PlugIns
#read -p 'Input path of Cinderella d(efault)=/Applications/Cinderella2 : ' ans
#if [ ${ans} != "d" ]; then
# cindyplug=${ans}.app/Contents/PlugIns
#fi
echo Cinderella Plugins=${cindyplug}
echo 1. "/Applications/KeTTeX/texlive  (default)"
echo 2. "/Library/TeX  (TeXLive)"
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
fi
echo texpath=${texpath}
echo texbinpath=${texbinpath}
ketcindyscripts=${texpath}/texmf-dist/scripts/ketcindy
cd ${ketcindyscripts}
cp -p ketjava/KetCindyPlugin.jar ${cindyplug}
echo "PathThead=\"${texbinpath}/\";"  > ${cindyplug}/dirhead.txt
homehead=/Users
read -p 'Input head of user home d(efault)=/Users : ' ans
echo $ans
if [ ${ans} != "d" ]; then
  homehead=$ans
fi
echo "Homehead=\"${homehead}\";"  >> ${cindyplug}/dirhead.txt
#ihome=~
#echo "Homepath=\"${home}\";"  >> ${cindyplug}/dirhead.txt
echo "Dirhead=\"${ketcindyscripts}\";"  >> ${cindyplug}/dirhead.txt
echo "setdirectory(Dirhead);"  >> ${cindyplug}/dirhead.txt
echo "import(\"setketcindy.txt\");"  >> ${cindyplug}/dirhead.txt
echo "import(\"ketoutset.txt\");"  >> ${cindyplug}/dirhead.txt
read -p 'Choose pdfviewer from preview(p),skim(s):' ans
if [ ${ans} = "s" ]; then
  echo  "Pathpdf=\"skim\";" >> ${cindyplug}/dirhead.txt
else
  echo  "Pathpdf=\"preview\";" >> ${cindyplug}/dirhead.txt
fi
echo "KetCindyPlugin and others copied to Cinderella"
sleep 1
exit 0