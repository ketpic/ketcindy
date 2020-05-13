setwd("/ketcindy.git/ketcindyfolder/work/samples/s08R/fig")##
source('/Applications/kettex/texlive/texmf-dist/scripts/ketcindy/ketlib/ketpiccurrent.r')##
Ketinit()##
Setwindow(c((-5),(6.5)),c((-0.5),(4.5)))####
options(digits=10);##
arccos=acos; arcsin=asin; arctan=atan##
data=c(-0.896489,0.213914,0.611672,-0.829216,0.163577,-0.344577,0.724359,-0.787316,2.742074,0.465812,0.141275,0.093541,0.758989,0.529063,-0.771094,-1.004052,0.07981,2.008811,-0.341652,3.005078,0.987661,-1.290364,0.266854,0.008037,-0.65279,-3.640849,-0.353408,0.920326,1.583251,-2.148308,1.456526,-0.486306,-0.845869,-1.258261,1.046438,-1.822213,-0.094713,0.780994,-1.739366,-1.238682,-0.635211,2.850993,-0.104053,1.336856,-0.222425,-0.881514,-0.418255,2.614002,0.552396,0.266785,-0.881116,-0.498631,1.897238,-0.763577,-2.115599,1.611835,1.266468,-0.899913,0.609144,-1.222532,0.390531,0.415915,-0.761348,-1.082418,-1.206979,0.3412,0.456714,-0.826989,0.982411,0.179447,0.779783,-1.436821,0.899648,0.412802,0.14848,0.427693,-0.502957,-0.157306,-0.988349,1.796502,-0.030085,-1.123606,0.02547,0.234559,-0.793252,0.633715,-1.535706,-0.637244,0.351021,-0.589253,-4.550738,-2.051286,-0.432295,0.501282,0.510032,0.089367,-0.734189,-0.407159,0.676697,-3.364281)##
tmp=boxplot(data,plot=FALSE)##
tmp1=tmp$stat##
tmp2=tmp$out##
bp1=c(tmp1,tmp2)##
sharp=rawToChar(as.raw(35))##
sharps=paste(sharp,sharp,'\n',sep='')##
if(Length(bp1)==0){bp1='nodata'}##
if(is.matrix(bp1)){##
  tmp=list()##
  for(ii in 1:Length(bp1)){##
    tmp=c(tmp,list(Op(ii,bp1)))##
  }##
  bp1=tmp##
}##
if(is.list(bp1)){##
  for(ii in Looprange(1,length(bp1))){##
    if(is.list(bp1[[ii]])){##
      cat('[',file='s0804boxplotbp1.txt',sep='',append=TRUE)##
      cat(sharps,file='s0804boxplotbp1.txt',sep='',append=TRUE)##
      for(jj in Looprange(1,length(bp1[[ii]]))){##
        cat(bp1[[ii]][[jj]],file='s0804boxplotbp1.txt',sep=',',append=TRUE)##
        cat(sharps,file='s0804boxplotbp1.txt',append=TRUE)##
      }##
      cat(']',file='s0804boxplotbp1.txt',sep=',',append=TRUE)##
      cat(sharps,file='s0804boxplotbp1.txt',append=TRUE)##
    }else{##
      cat(bp1[[ii]],file='s0804boxplotbp1.txt',sep=',',append=TRUE)##
      cat(sharps,file='s0804boxplotbp1.txt',append=TRUE)##
    }##
  }##
}else{##
  cat(bp1,file='s0804boxplotbp1.txt',sep=',')##
  cat(sharps,file='s0804boxplotbp1.txt',append=TRUE)##
}##
cat('////',file='s0804boxplotbp1.txt',sep=',',append=TRUE)##
quit()##
