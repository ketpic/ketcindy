#  Copyright (C)  2014  Setsuo Takato, KETCindy Japan project team
#
#This program is free software: you can redistribute it and/or modify
# it under the terms of the GNU General Public License as published by
# the Free Software Foundation; either version 3 of the License, or
# (at your option) any later version.
# 
# This program is distributed in the hope that it will be useful,
# but WITHOUT ANY WARRANTY; without even the implied warranty of
# MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
# GNU General Public License for more details.
# 
# You should have received a copy of the GNU General Public License
# along with this program.  If not, see <http://www.gnu.org/licenses/>


#########################################

ThisVersion<- "2ev5_2_4(180930)"

# 20180930
#   Drwpt debugged ( the last newline added)
# 20180929
#   Shade changed  (Kyoukai => Joincrvs)
# 2017.10.28
#    Drwpt debugged  ( Flattenlist )
# 2017.10.07
#   Dottedline,Drwline,Drwpt,Makehasen,Beginpicture,Setpen,Shade

#############################################

Dottedline<- function(...)
{
  varargin <- list(...)     
  Nall <- length(varargin)
  Nagasa <- 0.1
  Ookisa <- PenThick*2 #17.10.07
  I <- Nall
  Tmp <- varargin[[I]]
  while (mode(Tmp)=="numeric" && length(Tmp)==1 ) {
    I <- I-1
    Tmp <- varargin[[I]]
  }
  if (I==Nall-1) {
    Nagasa<-Nagasa*varargin[[Nall]]
    Nall <- Nall-1
  }
  if (I==Nall-2) {
    Nagasa <- Nagasa*varargin[[Nall-1]]
    Ookisa <- round(Ookisa*varargin[[Nall]])
    Nall <- Nall-2
  }
  Nagasa <- 1000/2.54/MilliIn*Nagasa
  Ra=Ookisa/MilliIn
  for (N in 1:Nall) {
    Pdata <- varargin[[N]]
    if (mode(Pdata)=="numeric") {
      Pdata <- list(Pdata)             
    }
    for (II in 1:length(Pdata)) {  
      Clist <- MakeCurves(Op(II,Pdata))
      DinM <- Dataindex(Clist)
      Mojisu=0
      for (n in Looprange(1,Nrow(DinM))) {    
        Tmp <- DinM[n,] 
        Data <- Clist[Tmp[1]:Tmp[2],]
        Len <- 0
        Lenlist <- c(0)                    
        for (I in Looprange(2,Nrow(Data))) {       
          Len <- Len+Norm(Data[I,]-Data[I-1,])  
          Lenlist <- c(Lenlist,Len)      
        }
        Lenall <- Lenlist[length(Lenlist)]    
        if (Lenall==0) {
          next
        }
        Naga <- Nagasa
        Nten <- round(Lenall/Naga)+1
        if (Nten > 1) {
          Seg <- Lenall/(Nten-1)
        }              
        else {
          Seg <- Lenall
        }
        Eps <- 10^(-6)*Seg
        PPd<-c()
        Hajime <- 1
        for (I in Looprange(0,Nten-1)) {     
          Len <- Seg*I
          if (I>0) {
            J <- Hajime
            while( Len>=Lenlist[J]+Eps) {     
              J <- J+1
            }
            Hajime <- J-1
          }
          T <- (Len-Lenlist[Hajime])/     
                           (Lenlist[Hajime+1]-Lenlist[Hajime])   
          P <- Data[Hajime,]+T*(Data[Hajime+1,]-Data[Hajime,]) 
          PPd<-Appendrow(PPd,P)
          if (I==Nten-1) {
            if (Norm(P-Data[1,])<Eps) {         
              next
            }
          } 
        }
        for (I in Looprange(1,Nrow(PPd))){
          P<- Op(I,PPd)
          if (Nrow(PPd)==1){
            V<- c(1,0)
          }
          else if (I==1){
            Tmp<- Op(I+1,PPd)-P
            V<- 1/Norm(Tmp)*Tmp
          }
          else if (I==Nrow(PPd)){
            Tmp<- P-Op(I-1,PPd)
            V<- 1/Norm(Tmp)*Tmp
          }
          else{
            Tmp1<- Op(I+1,PPd)-P
            Tmp2<- P-Op(I-1,PPd)
            Tmp3<-1/Norm(Tmp1)*Tmp1+1/Norm(Tmp2)*Tmp2
            V<- 1/Norm(Tmp3)*Tmp3
          }
          X=sprintf('%5.5f',P[1])
          Y=sprintf('%5.5f',P[2])
          Str=paste('\\put(',X,',',Y,'){\\circle*{',sprintf('%6.6f',Ra),'}}',sep="")
          cat(Str,file=Wfile,append=TRUE)
          Mojisu=Mojisu+nchar(Str)
          if(Mojisu>80){
            cat("\n",file=Wfile,append=TRUE)
            Mojisu=0
          }
        }
      }
    }
	if(Mojisu>0){
      cat("\n",file=Wfile,append=TRUE)
    }
  }
  Tmp<-PenThick/PenThickInit
  Setpen(Tmp)
}


###########################################

Drwline<-function(...)
{
  varargin<-list(...)
  Nall<-length(varargin)
  Thick<-0
  Tmp<-varargin[[Nall]]
  if (mode(Tmp)=="numeric" && length(Tmp)==1){
    Setpen(Tmp)
    Nall<-Nall-1
  }
  for (N in 1:Nall){
    Pdata<-varargin[[N]]
    if (length(Pdata)==0) next
    if (mode(Pdata)!="list") Pdata<-list(Pdata)
    while(Mixtype(Pdata)==3){ 
      Tmp1<- list()
      for(II in Looprange(1,length(Pdata))){
        Tmp1<- Mixjoin(Tmp1,Pdata[[II]])
      }
      Pdata<- Tmp1
    } 
    for (II in Looprange(1,length(Pdata))){
      Clist<-MakeCurves(Pdata[[II]])
      DinM<-Dataindex(Clist)
      for (n in Looprange(1,Nrow(DinM))){
        Tmp<-DinM[n,]
        Data<-Clist[Tmp[1]:Tmp[2],]
        Mojisu<-0
        for (I in Looprange(1,Nrow(Data))){
          Tmp<-Data[I,]
          X=sprintf('%5.5f',Tmp[1])
          Y=sprintf('%5.5f',Tmp[2])
          Pt=paste('(',X,',',Y,')',sep="")
          if(I==1){
            Str=paste('\\polyline',Pt,sep="")
          }else{
            Str=Pt  
          }
          cat(Str,file=Wfile,append=TRUE)
          Mojisu<-Mojisu+nchar(Str)
          if (Mojisu>80){
            cat("%\n",file=Wfile,append=TRUE)
            Mojisu<-0
          }
        }
        if (Mojisu!=0){
           cat("%\n",file=Wfile,append=TRUE)
        }
        cat("%\n",file=Wfile,append=TRUE)
      }
    }
  }
  if (Thick>0){
    Tmp<-PenThick/PenThickInit
    Setpen(Tmp)
  }
}

###########################################

Drwpt<-function(...)
{
  varargin<-list(...)
  Nargs<-length(varargin)
  All=Nargs
  if (TenSize>TenSizeInit){
    N<- round(6*sqrt(TenSize/TenSizeInit))
  }
  else{
    N<-4
  }
  Tmp<- varargin[[All]]
  Iro=c(0,0,0,1)
  Iroflg=0
  if(is.character(Tmp)){
    Iro=Ratiocmyk(Tmp)
    Iroflg=1
    All=All-1
  }
  Tmp<- varargin[[All]]
  if (mode(Tmp)=="numeric"){
    if (length(Tmp)>1){
      Kosa<- 1; All<- Nargs
    }
    else{
      Kosa<- Tmp; All<- All-1
    }
  }
  else if (mode(Tmp)=="list"){
      Kosa<- 1; All<- Nargs
  }
  Ra=TenSize*1000/2.54/MilliIn
  if(Iroflg>0){
    Str='{\\color[cmyk]{'
    for(J in 1:4){
      Str=paste(Str,as.character(Kosa*Iro[J]),sep="")
      if(J<4){
        Str=paste(Str,',',sep="")
      }
    }
    Str=paste(Str,'}%',sep="")
    cat(Str,file=Wfile,append=TRUE)
  }

#  CL<-c()
#  for (J in 0:N){
#    Tmp<- TenSize*0.5*1000/2.54/MilliIn
#    Tmp<- Tmp*c(cos(pi/4+J*2*pi/N),sin(pi/4+J*2*pi/N))
#    CL<- append(CL,Tmp)
#  }
#  CL<- matrix(CL,nrow=2)
#  CL<- t(CL)
  Mojisu=0
  for (II in Looprange(1,All)){
    MS<- varargin[[II]]
    MS=Flattenlist(MS) #17.10.28
    if (mode(MS)=="numeric"){
      MS<- list(MS)
    }
    for (I in Looprange(1,length(MS))){
      P<- MS[[I]]
      if (InWindow(P)!="i") next
      P<- Doscaling(P)
      X=sprintf('%5.5f',P[1])
      Y=sprintf('%5.5f',P[2])
      Str=paste('\\put(',X,',',Y,'){\\circle*{',sprintf('%6.6f',Ra),'}}',sep="")
      cat(Str,file=Wfile,append=TRUE)
      Mojisu=Mojisu+nchar(Str)
      if(Mojisu>80){
        cat("\n",file=Wfile,append=TRUE)
        Mojisu=0
      }
    }
  }
  Str="%"
  if(Iroflg>0){
    Str='}%'
  }
  if(Mojisu>0){
    Str=paste('\n',Str,'\n',sep="")
  }else{
    Fmt=paste(Str,'\n',sep="")
  }
  cat(Str,file=Wfile,append=TRUE)
  cat("\n",file=Wfile,append=TRUE) #180930
}


######################################

Makehasen<- function(Figdata,Sen,Gap,Ptn)
{
  Eps<- 10.0^(-6)
  Clist<- MakeCurves(Figdata)
  DinM<- Dataindex(Clist)
  for (N in Looprange(1,Nrow(DinM))){
    Tmp<- DinM[N,]
    Data<- Clist[Tmp[1]:Tmp[2],]
    Dtall<- Nrow(Data)
    Len<- 0
    Lenlist<- c(0)
    for (I in Looprange(2,Dtall)){
      Len<- Len+Norm(Data[I,]-Data[I-1,])
      Lenlist<- c(Lenlist,Len)
    }
    Lenall<- Lenlist[Dtall]
    if (Lenall==0){
      next
    }
    Kari<- (Sen+Gap)*0.1
    Naga<- Sen*0.1
    Tobi<- Gap*0.1
    if (Norm(Data[1,]-Data[Dtall,])<Eps){
      Nsen<- max(ceiling(Lenall/Kari),3)
      SegUnit<- Lenall/Nsen
      Naga<- SegUnit*Sen/(Sen+Gap)
      Tobi<- SegUnit*Gap/(Sen+Gap)
      SegList<- c(seq(0,(Nsen-1)*SegUnit,by=SegUnit))
    }
    else{
      if (Ptn==0){
        Nsen<- max(ceiling((Lenall+Tobi)/Kari),3)
        SegUnit<- Lenall*(Sen+Gap)/(Nsen*Sen+(Nsen-1)*Gap)
        Naga<- SegUnit*Sen/(Sen+Gap)
        Tobi<- SegUnit*Gap/(Sen+Gap)
        SegList<- c(seq(0,(Nsen-1)*SegUnit,by=SegUnit))
      }
      else{
        Nsen<- max(ceiling((Lenall+Naga)/Kari),3)
        SegUnit<- Lenall*(Sen+Gap)/((Nsen-1)*Sen+Nsen*Gap)
        Naga<- SegUnit*Sen/(Sen+Gap)
        Tobi<- SegUnit*Gap/(Sen+Gap)
        SegList<- c(seq(Tobi,Tobi+(Nsen-2)*SegUnit,by=SegUnit))
      }
    }
    Hajime<- 1; Owari<- 1
    Mojisu<- 0
    for (I in Looprange(1,length(SegList))){
      Len<- SegList[I]
      J<- Owari
      while (Len>=Lenlist[J]-Eps){
        if (J==Dtall){
          break
        }
        J<- J+1
      }
      Hajime<- J-1
      J<- Hajime
      while (Len+Naga>Lenlist[J]-Eps){
        if (J==Dtall){
          break
        }
        J<- J+1
      }
      Owari<- J-1
      T<- (Len-Lenlist[Hajime])
      T<- T/(Lenlist[Hajime+1]-Lenlist[Hajime])
      P<- Data[Hajime,]+T*(Data[Hajime+1,]-Data[Hajime,])
      X0=sprintf('%5.5f',P[1])
      Y0=sprintf('%5.5f',P[2])
      Pt0=paste('(',X0,',',Y0,')',sep="")
      Str=paste('\\polyline',Pt0,sep="")
      cat(Str,file=Wfile,append=TRUE)
      Mojisu<- Mojisu+nchar(Str)
      for (J in Looprange(Hajime+1,Owari)){
        P=Data[J,]
        X=sprintf('%5.5f',P[1])
        Y=sprintf('%5.5f',P[2])
        Pt=paste('(',X,',',Y,')',sep="")
        Str=Pt
        cat(Str,file=Wfile,append=TRUE)
        Pt0=Pt
        Mojisu=Mojisu+nchar(Str)
      }
      T<- (Len+Naga-Lenlist[Owari])
      T<- T/(Lenlist[Owari+1]-Lenlist[Owari])
      P<- Data[Owari,]+T*(Data[Owari+1,]-Data[Owari,])
      X=sprintf('%5.5f',P[1])
      Y=sprintf('%5.5f',P[2])
      Pt=paste('(',X,',',Y,')',sep="")
      Str=Pt
      cat(Str,file=Wfile,append=TRUE)
      Mojisu<- Mojisu+nchar(Str)
      if (Mojisu>80){
        cat("%\n",file=Wfile,append=TRUE)
        Mojisu<- 0
      }
    }
  }
  cat("%\n%\n",file=Wfile,append=TRUE);
}

#########################################

Beginpicture<-function(ul)
{    ## Scaling is implemented
  Tmp<- Doscaling(c(XMIN,YMIN))
  Xm<- Tmp[1]
  Ym<- Tmp[2]
  Tmp<- Doscaling(c(XMAX,YMAX))
  XM<- Tmp[1]
  YM<- Tmp[2]
  Dx<- XM-Xm
  Dy<- YM-Ym
  Sym<-".0123456789 +-*/"
  SL<-Sym
  OL<-"+-*/"
  if (ul!=""){
    ULEN<<-ul;
  }
  Is<-1;
  VL<-"";
  Ucode<-ULEN
  for (I in Looprange(1,nchar(Ucode))){
    C<-substring(Ucode,I,I);
    if (length(grep(C,SL,fixed=TRUE))>0){
      if (length(grep(C,OL,fixed=TRUE))>0){
        Tmp<-substring(Ucode,Is,I-1);
        Str<-paste(VL,Tmp,C,sep="")
        VL<-Str
        Is<-I+1;
      }
    }
    else{
      Unit<-substring(Ucode,I,I+1);
      Str<-substring(Ucode,Is,I-1);
      VL<-paste(VL,Str,sep="")
      break;
    }
  }
  Valu<-eval(parse(text=VL));
  Str<-as.character(Valu);
  ULEN<<- paste(Str,Unit,sep="");
  if (Unit=="cm") MilliIn<<-1000/2.54*Valu
  if (Unit=="mm") MilliIn<<-1000/2.54*Valu/10
  if (Unit=="in") MilliIn<<-1000*Valu
  if (Unit=="pt") MilliIn<<-1000/72.27*Valu
  if (Unit=="pc") MilliIn<<-1000/6.022*Valu 
  if (Unit=="bp") MilliIn<<-1000/72*Valu
  if (Unit=="dd2") MilliIn<<-1000/1238/1157/72.27*Valu
  if (Unit=="cc") MilliIn<<-1000/1238/1157/72.27*12*Valu;
  if (Unit=="sp") MilliIn<<-1000/72.27/65536*Valu/10
  MARKLEN<<- MARKLENNow*1000/2.54/MilliIn;
  Str<-paste("{\\unitlength=",ULEN,"%\n",sep="");
  cat(Str,file=Wfile,append=TRUE);
  cat("\\begin{picture}%\n",file=Wfile,append=TRUE);
  Str<-"(";
  Tmp<-as.character(round(Dx,digits=6));
  Str<-paste(Str,Tmp,",",sep="");
  Tmp<-as.character(round(Dy,digits=6));
  Str<-paste(Str,Tmp,")(",sep="");
  Tmp<-as.character(round(Xm,digits=6));
  Str<-paste(Str,Tmp,",",sep="");
  Tmp<-as.character(round(Ym,digits=6));
  Str<-paste(Str,Tmp,")%\n",sep="");
  cat(Str,file=Wfile,append=TRUE);
  Str=paste('\\linethickness{',as.character(PenThickInit/1000),'in}%',sep="")
  cat(Str,file=Wfile,append=TRUE)
  cat("%\n",file=Wfile,append=TRUE)
}

#########################################

Setpen<-function(Width)
{
  PenThick<<-round(PenThickInit*Width)
  Str=paste('\\linethickness{',as.character(PenThick/1000),'in}%',sep="")
  cat(Str,file=Wfile,append=TRUE)
  cat("%\n",file=Wfile,append=TRUE)
}

#########################################

Shade<- function(...)
{           ##  Scaling is implemented
  varargin<- list(...)
  Nargs<- length(varargin)
  Iroflg=0
  if(Nargs>1){ 
    Iro=varargin[[Nargs]]
    if(is.character(Iro)){
      Iroflg=1
      if(length(grep("{",Iro,fixed=TRUE))>0){
        Str=paste("{\\color",Iro,sep="")
      }
      else{
        Str=paste("{\\color{",Iro,"}",sep="")
      }
    }
    else{
      if(length(Iro)==1){
        Kosa=Iro
      }
      else{
        Iroflg=1
        if(length(Iro)==4){
          Str="{\\color[cmyk]{"
        }
        else{
          if(length(Iro)==3){
            Str="{\\color[rgb]{"
          }
        }
        for(J in 1:length(Iro)){
          Str=paste(Str,as.character(Iro[J]),sep="")
          if(J<length(Iro)){
            Str=paste(Str,",")
          }
        }
        Str=paste(Str,"}")
      }
    }
    if(Iroflg==1){
      Str=paste(Str,"%\n",sep="")
      cat(Str,file=Wfile,append=TRUE)
    }
  }
  Mojisu=0
  Tmp=varargin[[1]]
#  Data=Kyoukai(Tmp)
  Data= Joincrvs(Tmp) #180929from
  Data=list(Data) #180929to
  for (I in Looprange(1, length(Data))){
    PL<- Op(I,Data)
    PL=Appendrow(PL,Op(1,PL)) #180929
    Mojisu<- 0
    for (J in  1:Nrow(PL)){
      P<- Doscaling(Op(J,PL))
      X=sprintf('%5.5f',P[1])
      Y=sprintf('%5.5f',P[2])
      Pt=paste('(',X,',',Y,')',sep="")
      if(J==1){
        Str=paste('\\polygon*',Pt,sep="")
      }else{
        Str=Pt  
      }
      cat(Str,file=Wfile,append=TRUE)
      Mojisu<- Mojisu+nchar(Str)
      if (Mojisu>80){
        cat("%\n",file=Wfile,append=TRUE)
        Mojisu<- 0
      }
    }
  }
  if(Iroflg==1){
    Str='}%'
    if(Mojisu>0){
      Str=paste('\n',Str,'\n',sep="")
    }else{
      Str=paste(Str,'\n')
    }
    cat(Str,file=Wfile,append=TRUE)
  }
}
