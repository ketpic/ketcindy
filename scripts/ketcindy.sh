#!/bin/sh
#
# KETCindy starter script
#
# (C) 2017 Norbert Preining
# Licensed under the same license terms as ketpic itself, that is GPLv3+
#

BinaryName=Cinderella2
TemplateFile=template.cdy
systype=`uname`

if [ "$1" = "-c" ]
then
  shift
  cinderella="$1"
else
  cinderella=`which $BinaryName 2>/dev/null`
fi

if [ -z "$cinderella" ]
then
  case $systype in
    Darwin)
      if [ -r /Applications/Cinderella2.app/Contents/MacOS/Cinderella2 ]
      then
        cinderella=/Applications/Cinderella2.app/Contents/MacOS/Cinderella2
      else
        echo "Cannot find $BinaryName!" >&2
        exit 1
      fi
    *)
      echo "Cannot find $BinaryName!" >&2
      exit 1
fi

if [ ! -x "$cinderella" ] ; then
  echo "Program $cinderella is not executable!" >&2
  exit 1
fi
# find real path
realcind=`realpath "$cinderella"`
cinddir=`dirname "$realcind"`
case $systype in
  Darwin)
    plugindir="$cinddir/../PlugIns";;
  *)
    plugindir="$cinddir/Plugins";;
esac

plugin="$plugindir/KetCindyPlugin.jar"

# find Jar
KetCdyJar=`kpsewhich -format=texmfscripts KetCindyPlugin.jar`
# search for template.cdy
TempCdy=`kpsewhich -format=texmfscripts $TemplateFile`

if [ -z "$TempCdy" -o -z "$KetCdyJar" ]
then
  echo "Cannot find $TemplateFile via kpsewhich, is ketpic installed?" >&2
  exit 1
fi


if [ ! -r "$plugin" ] ; then
  echo "Cinderella is *NOT* set up for KETCindy!"
  echo "You need to copy"
  echo "   $KetCdyJar"
  echo "into"
  echo "   $plugindir"
  echo ""
  exit 1
fi

# check whether the .jar md5sum is fine, but don't make this an error
case $systype in
  Darwin)
    __md5sum=md5;;
  *)
    __md5sum=md5sum;;
esac
myjarmd=`cat "$KetCdyJar" | $__md5sum`
sysjarmd=`cat "$plugin" | $__md5sum`
if [ ! "$myjarmd" = "$sysjarmd" ]
then
  echo "The installed version of the plugin in"
  echo "  $plugin"
  echo "differs from the version shipped in"
  echo "  $KetCdyJar"
  echo "You might need to update the former one with the later one!"
fi


mkdir -p ~/ketcindy

exec "$cinderella" "$TempCdy"

