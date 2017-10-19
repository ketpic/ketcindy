#!/bin/bash
#
# export the ketcindy git to a texmf tree

set -e

if [ -d texmf ] ; then
  echo "directory texmf already present, not exporting to it!\n" >&2
  exit 1
fi

mkdir texmf
git archive --format=tar --prefix=ketcindy/ HEAD | (cd texmf && tar xf -)
mkdir -p texmf/doc/support/ketcindy
mkdir -p texmf/scripts/ketcindy/ketfiles
mkdir -p texmf/tex/latex/ketcindy

cd texmf

# tex hierarchy
mv ketcindy/ketpicstyle/*.sty tex/latex/ketcindy
rmdir ketcindy/ketpicstyle

# scripts
mv ketcindy/ketlib ketcindy/ketlibC ketcindy/ketoutset.txt ketcindy/setketcindy.txt \
   ketcindy/data ketcindy/scripts/ketcindy.sh ketcindy/ketjava \
   scripts/ketcindy
mv ketcindy/ketfiles/allbuttons.cdy ketcindy/ketfiles/template.cdy scripts/ketcindy/ketfiles
chmod 0755 scripts/ketcindy/ketcindy.sh

# doc
mv ketcindy/CindyJS ketcindy/ketmanual ketcindy/ketfiles/ketsample \
   ketcindy/LICENSE ketcindy/source \
   ketcindy/ketfiles/ScriptDraw.txt ketcindy/ketfiles/ScriptInitialization.txt \
   ketcindy/ketfiles/ScriptKeytyped.txt \
   doc/support/ketcindy
if [ -r TODO ] ; then
   mv TODO doc/support/ketcindy
fi

# the rest should be files that can be removed:
rm ketcindy/scripts/update-permissions.sh
rm ketcindy/scripts/export-to-texmf.sh
# now the scripts dir should be empty
rmdir ketcindy/scripts

# now the ketfiles dir should be empty
rmdir ketcindy/ketfiles

rm ketcindy/setketcindyr.txt
rm ketcindy/setketcindysci.txt

# now all should be gone
rmdir ketcindy


