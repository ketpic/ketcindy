#!/bin/bash
#
# export the ketcindy git to a texmf tree

set -e

if [ -d texmf ] ; then
  echo "directory texmf already present, not exporting to it!" >&2
  exit 1
fi

mkdir texmf
git archive --format=tar --prefix=ketcindy/ HEAD | (cd texmf && tar xf -)
mkdir -p texmf/doc/support/ketcindy/
mkdir -p texmf/scripts/ketcindy/
mkdir -p texmf/tex/latex/ketcindy/

cd texmf

# tex hierarchy
mv ketcindy/ketcindyfolder/style/* tex/latex/ketcindy/
rmdir ketcindy/ketcindyfolder/style

# scripts
# thinks that we should not have in the scripts folder in texlive
mv ketcindy/ketcindyfolder/scripts/ketcindyjs doc/support/ketcindy/
# this is already in the root folder, so no need to have it two times
rm ketcindy/ketcindyfolder/scripts/LICENSE.txt
mv ketcindy/ketcindyfolder/scripts/* scripts/ketcindy/
rmdir ketcindy/ketcindyfolder/scripts

mv ketcindy/tl-integration/ketcindy.sh scripts/ketcindy/
chmod 0755 scripts/ketcindy/ketcindy.sh

# doc
mv ketcindy/ketcindyfolder/doc/* doc/support/ketcindy/
for i in LICENSE README tl-integration/README.TeXLive ; do
  if [ -r ketcindy/$i ] ; then
    mv ketcindy/$i doc/support/ketcindy
  fi
done
rmdir ketcindy/ketcindyfolder/doc

# work stuff
mv ketcindy/ketcindyfolder/work/samples doc/support/ketcindy/
mv ketcindy/ketcindyfolder/work/template1basic.cdy scripts/ketcindy/
mv ketcindy/ketcindyfolder/work/template2advanced.cdy scripts/ketcindy/
for i in Scriptfigure.txt Scriptketlibsci.txt Scriptkelib.txt ScriptKeytyped.txt ; do
#         template1basic template2advanced Makefile \
  mv ketcindy/ketcindyfolder/work/$i doc/support/ketcindy/
done
#for i in template1basic template2advanced Makefile ; do
#  mv ketcindy/ketcindyfolder/work/$i doc/support/ketcindy/
#done
rmdir ketcindy/ketcindyfolder/work

# now the ketcindyfolder dir should be empty
rmdir ketcindy/ketcindyfolder

# use our TeX Live ketcindy.ini
mv ketcindy/tl-integration/ketcindy.ini scripts/ketcindy/

# the rest should be files that can be removed:
rm ketcindy/tl-integration/update-permissions.sh
rm ketcindy/tl-integration/export-to-texmf.sh
rm ketcindy/.gitignore
rm ketcindy/.gitattributes
# now the scripts dir should be empty
rmdir ketcindy/tl-integration

# dropped unpacked files
rm -rf ketcindy/forLinux ketcindy/forMac ketcindy/forWindows

# now all should be gone
rmdir ketcindy

