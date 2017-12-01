#!/bin/sh
#      2017.11.30
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
homehead=/Users
read -p 'Input head of user home d(efault)=/Users : ' ans
echo $ans
if [ ${ans} != "d" ]; then
  homehead=$ans
fi
echo "PathThead=\"${texbinpath}/\";"  > ${cindyplug}/dirhead.txt
echo "Homehead=\"${homehead}\";"  >> ${cindyplug}/dirhead.txt
echo "Dirhead=\"${ketcindyscripts}\";"  >> ${cindyplug}/dirhead.txt
echo "setdirectory(Dirhead);"  >> ${cindyplug}/dirhead.txt
echo "import(\"setketcindy.txt\");"  >> ${cindyplug}/dirhead.txt
echo "import(\"ketoutset.txt\");"  >> ${cindyplug}/dirhead.txt

# for Scilab from
echo "PathThead=\"${texbinpath}/\";"  > ${cindyplug}/dirheadsci.txt
echo "Homehead=\"${homehead}\";"  >> ${cindyplug}/dirheadsci.txt
echo "Dirhead=\"${ketcindyscripts}\";"  >> ${cindyplug}/dirheadsci.txt
echo "setdirectory(Dirhead);"  >> ${cindyplug}/dirheadsci.txt
echo "import(\"setketcindysci.txt\");"  >> ${cindyplug}/dirheadsci.txt
echo "import(\"ketoutset.txt\");"  >> ${cindyplug}/dirheadsci.txt
# for Scilab upto

read -p 'Choose pdfviewer from preview(p),skim(s):' ans
if [ ${ans} = "s" ]; then
  echo  "Pathpdf=\"skim\";" >> ${cindyplug}/dirhead.txt
else
  echo  "Pathpdf=\"preview\";" >> ${cindyplug}/dirhead.txt
fi

# for Scilab from
if [ ${ans} = "s" ]; then
  echo  "Pathpdf=\"skim\";" >> ${cindyplug}/dirheadsci.txt
else
  echo  "Pathpdf=\"preview\";" >> ${cindyplug}/dirheadsci.txt
fi
# for Scilab upto

echo "KetCindyPlugin and others copied to Cinderella"
sleep 1
exit 0