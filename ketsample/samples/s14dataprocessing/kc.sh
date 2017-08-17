#!/bin/sh
cd "/Users/takatoosetsuo/ketcindy/ketsample/samples/s14dataprocessing"
R  --vanilla --slave < s1401csvprocessingsep.r >& errormessageR.txt
exit 0
