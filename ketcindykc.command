#!/bin/sh
#      20200504

#sudo spctl --master-enable

cd `dirname $0`
#if [ -e ../ketcindyfolder ]; then
#  cd ../ketcindyfolder
#fi
mkdir fig
cd fig
echo >kc.command
chmod 777 kc.command
sleep 1
exit 0