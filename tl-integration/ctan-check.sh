#!/bin/bash

set -e

export PATH=/usr/share/fslint/fslint:$PATH

if [ ! -r "$1" ] ; then
  echo "Need .zip file as first argument!" >&2
  exit 1
fi

ROOT=`mktemp -d`
unzip -q -d $ROOT "$1"

exitcode=0

cd $ROOT

# check for files with executable permissions
bla=$(find . -type f -a -executable | grep -v '\.\(sh\|pl\)$' || true)
if [ -n "$bla" ] ; then
  echo "Found files with executable permission"
  echo "--------------------------------------"
  echo "$bla"
  echo
  exitcode=1
fi

# check for CRLF line endings
bla=$(find . -type f -exec file '{}' \; | grep "CRLF line" || true)
if [ -n "$bla" ] ; then
  echo "Found files with CRLF line endings"
  echo "----------------------------------"
  echo "$bla"
  echo
  exitcode=1
fi

# check for duplicate files
bla=$(findup -t .)
if [ -n "$bla" ] ; then
  echo "Found duplicate file *contents*"
  echo "-------------------------------"
  echo "$bla"
  echo
  exitcode=1
fi

# check for duplicate file names
bla=$(findsn .)
if [ -n "$bla" ] ; then
  echo "Found duplicate file *names*"
  echo "----------------------------"
  echo "$bla"
  echo
  exitcode=1
fi

# check for spaces in file or directory names
bla=$(find . | grep ' ' || true)
if [ -n "$bla" ] ; then
  echo "Found files/dirs with spaces in the name"
  echo "----------------------------------------"
  echo "$bla"
  echo
  exitcode=1
fi

cd /tmp
rm -rf $ROOT

exit $exitcode

