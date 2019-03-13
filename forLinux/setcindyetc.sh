#!/bin/sh
#      20180313

#Edit followings if necessay
cindyinstall=~/
sudo apt install openjdk-8-jre
sudo update-alternatives --config java
sudo bash ${cindyinstall}Cinderella_unix_2_8.sh
sudo apt install r-base maxima
sudo apt install evince
sleep 1
exit 0