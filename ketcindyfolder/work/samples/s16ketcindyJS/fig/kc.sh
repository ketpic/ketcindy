#!/bin/sh
cd "/Users/takatoosetsuo/ketcindy/samples/s16ketcindyJS/fig"
/Library/Frameworks/R.framework/Versions/Current/Resources/bin/R  --vanilla --slave < s1602diffeq2.r 2> errormessageR.txt
exit 0
