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
bla=$(find . -type f -a -executable | grep -v '\(\./forMac/.*\.command\|\./forWindows/.*\.bat\|\.\(sh\|pl\)\)$' || true)
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
# ketcindyfolder/scripts/ketlib/ketcindylibmvhelpJ.txt
# scripts/ketlib/ketcindylibmvhelpE.txt
# scripts/ketlib/ketcindylibmvhelpJ.txt
bla=$(findup -t . \( ! -path './scripts/ketlib/ketcindylibmvhelpE.txt' \))
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

# check for 0 byte files
bla="$(find . -type f -a -size 0)"
if [ -n "$bla" ] ; then
  echo "Found files with 0 size"
  echo "-----------------------"
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
mv ketcindy/style/* tex/latex/ketcindy/
rmdir ketcindy/style

# scripts
# loads of stuff in upstream scripts move them to more appropriate places
mv ketcindy/scripts/ketcindyjs doc/support/ketcindy/
mv ketcindy/scripts/* scripts/ketcindy/
chmod 0755 scripts/ketcindy/ketcindy.sh
rmdir ketcindy/scripts

# doc
mv ketcindy/doc/* doc/support/ketcindy/
mv ketcindy/LICENSE doc/support/ketcindy
mv ketcindy/README doc/support/ketcindy
mv ketcindy/tl-integration/README.TeXLive doc/support/ketcindy
mv ketcindy/HowToUseE.pdf doc/support/ketcindy
mv ketcindy/HowToUseJ.pdf doc/support/ketcindy

# CTAN doesn't like it if files are not in TDS that are in
# the uploaded zip, so move them somewhere into the doc hierarchy
#rm -rf ketcindy/forLinux ketcindy/forMac ketcindy/forWindows
#mv ketcindy/forLinux ketcindy/forMac ketcindy/forWindows doc/support/ketcindy/


# work stuff
#mv ketcindy/ketcindyfolder/work/allbuttons.cdy scripts/ketcindy/
#mv ketcindy/ketcindyfolder/work/template0.cdy scripts/ketcindy/
#mv ketcindy/ketcindyfolder/work/template1basic.cdy scripts/ketcindy/
#mv ketcindy/ketcindyfolder/work/template3Dfigure.cdy scripts/ketcindy/
#mv ketcindy/ketcindyfolder/work/template4ketcindyjs.cdy scripts/ketcindy/
#mv ketcindy/ketcindyfolder/work/Scriptkelib.txt doc/support/ketcindy/
#rmdir ketcindy/ketcindyfolder/work

# use our TeX Live ketcindy.ini
mv ketcindy/tl-integration/ketcindy.ini scripts/ketcindy/

# the rest should be files that can be removed:
# there should nothing be there anymore, files are not exported!
# rm ketcindy/tl-integration/*
# remove if these files are available
rm -f ketcindy/.gitignore
rm -f ketcindy/.gitattributes
# now the scripts dir should be empty
rmdir ketcindy/tl-integration

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

