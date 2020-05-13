setwd("/ketcindy.git/ketcindyfolder/work/samples/s08R/fig")##
source('/Applications/kettex/texlive/texmf-dist/scripts/ketcindy/ketlib/ketpiccurrent.r')##
Ketinit()##
Setwindow(c((-5),(5)),c((-5),(5)))####
options(digits=10);##
arccos=acos; arcsin=asin; arctan=atan##
R1=rnorm(10)##
sharp=rawToChar(as.raw(35))##
sharps=paste(sharp,sharp,'\n',sep='')##
if(Length(R1)==0){R1='nodata'}##
if(is.matrix(R1)){##
  tmp=list()##
  for(ii in 1:Length(R1)){##
    tmp=c(tmp,list(Op(ii,R1)))##
  }##
  R1=tmp##
}##
if(is.list(R1)){##
  for(ii in Looprange(1,length(R1))){##
    if(is.list(R1[[ii]])){##
      cat('[',file='s0806randomR1.txt',sep='',append=TRUE)##
      cat(sharps,file='s0806randomR1.txt',sep='',append=TRUE)##
      for(jj in Looprange(1,length(R1[[ii]]))){##
        cat(R1[[ii]][[jj]],file='s0806randomR1.txt',sep=',',append=TRUE)##
        cat(sharps,file='s0806randomR1.txt',append=TRUE)##
      }##
      cat(']',file='s0806randomR1.txt',sep=',',append=TRUE)##
      cat(sharps,file='s0806randomR1.txt',append=TRUE)##
    }else{##
      cat(R1[[ii]],file='s0806randomR1.txt',sep=',',append=TRUE)##
      cat(sharps,file='s0806randomR1.txt',append=TRUE)##
    }##
  }##
}else{##
  cat(R1,file='s0806randomR1.txt',sep=',')##
  cat(sharps,file='s0806randomR1.txt',append=TRUE)##
}##
cat('////',file='s0806randomR1.txt',sep=',',append=TRUE)##
quit()##
