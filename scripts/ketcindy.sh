#!/bin/sh
#
# KETCindy starter script
#
# (C) 2017 Norbert Preining
# Licensed under the same license terms as ketpic itself, that is GPLv3+
#

BinaryName=Cinderella2
TemplateFile=template.cdy

if [ "$1" = "-c" ]
then
  shift
  cinderella="$1"
else
  cinderella=`which $BinaryName 2>/dev/null`
fi

if [ -z "$cinderella" ]
then
  echo "Cannot find $BinaryName!" >&2
  exit 1
fi

if [ ! -x "$cinderella" ] ; then
  echo "Program $cinderella is not executable!" >&2
  exit 1
fi

# search for template.cdy
TempCdy=`kpsewhich -format=texmfscripts $TemplateFile`

if [ -z "$TempCdy" ]
then
  echo "Cannot find $TemplateFile via kpsewhich, is ketpic installed?" >&2
  exit 1
fi

exec "$cinderella" "$TempCdy"

