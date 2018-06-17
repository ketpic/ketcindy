#!/usr/bin/env perl
#
# KETCindy starter script
#
# (C) 2017-2018 Norbert Preining
# Licensed under the same license terms as ketpic itself, that is GPLv3+
#

use strict;
$^W = 1;

my $BinaryName = "Cinderella2";
my $TemplateFile = "template1basic.cdy";
my $systype = `uname`;
my $devnull = "/dev/null";
if ($^O =~ /^MSWin/i) {
  $systype = "windows";
  $devnull = "nul";
} else {
  $systype = `uname`;
  chomp($systype);
}
my $HOME = ($systype eq "windows") ? $ENV{'USERPROFILE'} : $ENV{'HOME'};
my $workdir ="$HOME/ketcindy";

my $cinderella;
if ($#ARGV >= 0) {
  if ($ARGV[0] eq '-c') {
    $cinderella = ($ARGV[1] ? $ARGV[1] : "");
  }
} else {
  # TODO which is not available on Windows!
  chomp($cinderella = `which $BinaryName 2>$devnull`);
}

if (-z "$cinderella") {
  if ($systype eq 'Darwin') {
    if (-r '/Applications/Cinderella2.app/Contents/MacOS/Cinderella2') {
      $cinderella = '/Applications/Cinderella2.app/Contents/MacOS/Cinderella2';
    } else {
      die "Cannot find $BinaryName!";
    }
  } else {
    # TODO need to check special location on Windows!
    die "Cannot find $BinaryName!";
  }
}

if ( ! -x "$cinderella" ) {
  die "Program $cinderella is not executable!";
}

# find real path
# TODO convert to perl internal code as this does not work on Windows!!!
chomp( my $realcind = `realpath "$cinderella"`);
chomp( my $cinddir  = `dirname "$realcind"`);

my $plugindir;
# TODO check for Windows location
if ($systype eq 'Darwin') {
  $plugindir = "$cinddir/../PlugIns";
} else {
  $plugindir = "$cinddir/Plugins";
}

my $plugin = "$plugindir/KetCindyPlugin.jar";
my $dirheadplugin = "$plugindir/ketcindy.ini";

# find Jar
chomp(my $KetCdyJar = `kpsewhich -format=texmfscripts KetCindyPlugin.jar`);
# search for template.cdy
chomp(my $TempCdy = `kpsewhich -format=texmfscripts $TemplateFile`);
chomp(my $DirHead=`kpsewhich -format=texmfscripts ketcindy.ini`);

if (-z "$TempCdy" || -z "$KetCdyJar") {
  die "Cannot find $TemplateFile via kpsewhich, is ketpic installed?";
}


if ( ! -r "$plugin" || ! -r "$dirheadplugin" ) {
  print "Cinderella is *NOT* set up for KETCindy!"
  print "You need to copy"
  print "   $KetCdyJar"
  print "   $DirHead"
  print "into"
  print "   $plugindir"
  print ""
  exit(1);
}

# check whether the .jar md5sum is fine, but don't make this an error
my $__md5sum;
if ($systype eq 'Darwin') {
  $__md5sum = "md5";
} else {
  $__md5sum = "md5sum";
}

chomp(my $myjarmd = `cat "$KetCdyJar" | $__md5sum`);
chomp(my $sysjarmd = `cat "$plugin" | $__md5sum`);

if ( ! "$myjarmd" eq "$sysjarmd" ) {
  print "The installed version of the plugin in"
  print "  $plugin"
  print "differs from the version shipped in"
  print "  $KetCdyJar"
  print "You might need to update the former one with the later one!"
}


# TODO convert to perl internal!
`mkdir -p "$workdir"`;
`cp "$TempCdy" "$workdir"`;

exec ($cinderella, "$workdir/$TemplateFile");

