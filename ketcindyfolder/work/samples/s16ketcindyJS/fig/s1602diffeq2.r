Looprange<- function(a,b){
  if (a<=b) return(a:b)
  return(c())
}
setwd('/Applications/KeTTeX.app/texlive/texmf-dist/scripts/ketcindy/ketcindyjs')
Dtket=readLines('ketcindylib.txt')
setwd('/Users/takatoosetsuo/ketcindy/samples/s16ketcindyJS')
Dtjs=readLines('s1602diffeq2.html')
Qt=rawToChar(as.raw(34))
Dtinit=c(paste('<script id=',Qt,'csinit',Qt,' type=',Qt,'text/x-cindyscript',Qt,'>',sep=''))
Dtinit=c(Dtinit,Dtket,'</script>')
Dthead=c()
for(I in Looprange(1,length(Dtjs))){
  if(length(grep('<script id=',Dtjs[I],fixed=TRUE))==0){
    Tmp=Dtjs[I]
    if(length(grep('link rel=',Tmp,fixed=TRUE))>0){
      Tmp1='file:////Applications/KeTTeX.app/texlive/texmf-dist/scripts/ketcindy/ketcindyjs/CindyJS.css'
      Tmp=paste('    <link rel=',Qt,'stylesheet',Qt,' href=',Qt,Tmp1,Qt,'>',sep='')
    }
    Tmp1=length(grep('script type=',Tmp,fixed=TRUE))
    Tmp1=Tmp1*length(grep('Cindy.js',Tmp,fixed=TRUE))
    if(Tmp1>0){
      Tmp1='file:////Applications/KeTTeX.app/texlive/texmf-dist/scripts/ketcindy/ketcindyjs/Cindy.js'
      Tmp=paste('    <script type=',Qt,'text/javascript',Qt,' src=',Qt,Tmp1,Qt,'>',sep='')
      Tmp=paste(Tmp,'</script>',sep='')
    }
    Dthead=c(Dthead,Tmp)
  }else{
     Is=I; break
  }
}
Dt=c()
for(I in Looprange(Is,length(Dtjs))){
  Dt=c(Dt,Dtjs[I])
  if(length(grep('</script>',Dtjs[I],fixed=TRUE))>0){
    if(length(grep('draw',Dt[1],fixed=TRUE))>0){Dtdraw=Dt}
    if(length(grep('keytyped',Dt[1],fixed=TRUE))>0){Dtkey=Dt}
    Dt=c()
    if(length(grep('<script id=',Dtjs[I+1],fixed=TRUE))==0){
      Ie=I+1;break
    }
  }
}
Dt=c(Dthead,Dtdraw,Dtkey,Dtinit)
for(I in Looprange(Ie,length(Dtjs))){
  if(length(grep('Button',Dtjs[I],fixed=TRUE))>0){
    if(length(grep(paste(Qt,'Figure',sep=''),Dtjs[I],fixed=TRUE))>0){next}
    if(length(grep(paste(Qt,'Exekc',sep=''),Dtjs[I],fixed=TRUE))>0){next}
    if(length(grep(paste(Qt,'Parent',sep=''),Dtjs[I],fixed=TRUE))>0){next}
    if(length(grep(paste(Qt,'KeTJS',sep=''),Dtjs[I],fixed=TRUE))>0){next}
  }
  Dt=c(Dt,Dtjs[I])
}
setwd('/Users/takatoosetsuo/ketcindy/samples/s16ketcindyJS')
writeLines(Dt,'s1602diffeq2ketcindy.html',sep='\n')
quit()
