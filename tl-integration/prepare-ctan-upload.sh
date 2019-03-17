#!/bin/bash
#
# prepare a CTAN upload package

set -e

export PATH=/usr/share/fslint/fslint:$PATH

forceIt=false

if [ "$1" = "-force" ] ; then
  forceIt=true
  shift
fi

if [ -z "$1" ] ; then
  echo "need version number for CTAN upload preparation" >&2
  exit 1
fi

VER=$1
TMP=`mktemp -d`
GITREPO=`pwd`

PKGDIR=$TMP/ketcindy-$VER

mkdir $PKGDIR

#
# update README
sed -e "s/^Version: .*$/Version: $VER/" README > README.new

echo "Is the following change in README ok?"
diff -u README README.new || true    # diff returns 1 for different files
echo -n "Ok? (y/N) "
read yn
if [ "$yn" != "y" ] ; then
  echo "Ok, giving up!"
  exit 1
fi
mv README.new README
git add README
git commit -m "update README" || true

# we export the stuff two times, once for the normal
# upload and once for reshuffling in the TDS tree
# this is the first export, which we than check for
# various problems
git archive --format=tar HEAD | (cd $PKGDIR && tar xf -)

cd $PKGDIR

error=false

# check for files with executable permissions
bla=$(find . -type f -a -executable | grep -v '\(\./forMac/.*\.command\|\.\(sh\|pl\)\)$' || true)
if [ -n "$bla" ] ; then
  echo "Found files with executable permission"
  echo "--------------------------------------"
  echo "$bla"
  echo
  error=true
fi

# check for CRLF line endings
bla=$(find . -type f -exec file '{}' \; | grep "CRLF line" || true)
if [ -n "$bla" ] ; then
  echo "Found files with CRLF line endings"
  echo "----------------------------------"
  echo "$bla"
  echo
  error=true
fi

# check for duplicate files
# ignore
# ketcindyfolder/scripts/ketlib/ketcindylibmvhelpE.txt
# ketcindyfolder/scripts/ketlib/ketcindylibmvhelpJ.txt
bla=$(findup -t . \( ! -path './ketcindyfolder/scripts/ketlib/ketcindylibmvhelpE.txt' \))
if [ -n "$bla" ] ; then
  echo "Found duplicate file *contents*"
  echo "-------------------------------"
  echo "$bla"
  echo
  error=true
fi

# check for duplicate file names
bla="$(findsn . \( ! -path './tl-integration/ketcindy.ini' \))"
if [ -n "$bla" ] ; then
  echo "Found duplicate file *names*"
  echo "----------------------------"
  echo "$bla"
  echo
  error=true
fi

# check for spaces in file or directory names
bla=$(find . | grep ' ' || true)
if [ -n "$bla" ] ; then
  echo "Found files/dirs with spaces in the name"
  echo "----------------------------------------"
  echo "$bla"
  echo
  error=true
fi


if $error ; then
  if $forceIt ; then
	echo "Forcing packaging creation despite of above errors!"
  else
	echo "Errors found, exiting (override with -force)"
    cd "$GITREPO"
    rm -rf $TMP
    exit 1
  fi
fi

# go back to main git
cd "$GITREPO"
mkdir $PKGDIR/TDS
# export a second time to TDS and do reshuffling
git archive --format=tar --prefix=ketcindy/ HEAD | (cd $PKGDIR/TDS && tar xf -)

cd $PKGDIR/TDS

mkdir -p doc/support/ketcindy/
mkdir -p scripts/ketcindy/
mkdir -p tex/latex/ketcindy/

# tex hierarchy
mv ketcindy/ketcindyfolder/style/* tex/latex/ketcindy/
rmdir ketcindy/ketcindyfolder/style

# scripts
# thinks that we should not have in the scripts folder in texlive
mv ketcindy/ketcindyfolder/scripts/ketcindyjs doc/support/ketcindy/
mv ketcindy/ketcindyfolder/scripts/* scripts/ketcindy/
chmod 0755 scripts/ketcindy/ketcindy.sh
rmdir ketcindy/ketcindyfolder/scripts

# doc
mv ketcindy/ketcindyfolder/doc/* doc/support/ketcindy/
for i in LICENSE README tl-integration/README.TeXLive ; do
  if [ -r ketcindy/$i ] ; then
    mv ketcindy/$i doc/support/ketcindy
  fi
done
mv ketcindy/HowToInstallE.pdf doc/support/ketcindy
mv ketcindy/HowToInstallJ.pdf doc/support/ketcindy
rmdir ketcindy/ketcindyfolder/doc

# work stuff
mv ketcindy/ketcindyfolder/work/samples doc/support/ketcindy/
mv ketcindy/ketcindyfolder/work/allbuttons.cdy scripts/ketcindy/
mv ketcindy/ketcindyfolder/work/template0.cdy scripts/ketcindy/
mv ketcindy/ketcindyfolder/work/template1basic.cdy scripts/ketcindy/
mv ketcindy/ketcindyfolder/work/template2slide.cdy scripts/ketcindy/
mv ketcindy/ketcindyfolder/work/template3Dfigure.cdy scripts/ketcindy/
mv ketcindy/ketcindyfolder/work/template4ketcindyjs.cdy scripts/ketcindy/
mv ketcindy/ketcindyfolder/work/ketcindy.conf scripts/ketcindy/
mv ketcindy/ketcindyfolder/work/Scriptkelib.txt doc/support/ketcindy/
rmdir ketcindy/ketcindyfolder/work

# now the ketcindyfolder dir should be empty
rmdir ketcindy/ketcindyfolder

# use our TeX Live ketcindy.ini
mv ketcindy/tl-integration/ketcindy.ini scripts/ketcindy/

# the rest should be files that can be removed:
rm ketcindy/tl-integration/*
# remove if these files are available
rm -f ketcindy/.gitignore
rm -f ketcindy/.gitattributes
# now the scripts dir should be empty
rmdir ketcindy/tl-integration

# dropped unpacked files
rm -rf ketcindy/forLinux ketcindy/forMac ketcindy/forWindows

# now all should be gone
rmdir ketcindy

# Now the TDS directory should contain a proper TDS path, package it up
zip -r $TMP/ketcindy.tds.zip *
cd ..
rm -rf TDS

# Finally, package up everyting!
cd $TMP
zip -r "$GITREPO/ketcindy-ctan-upload-$VER.zip" ketcindy-$VER ketcindy.tds.zip
echo "upload ready file is in"
echo " $GITREPO/ketcindy-ctan-upload-$VER.zip"
echo
cd $GITREPO

rm -rf $TMP

# end

