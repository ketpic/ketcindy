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

ThisVersion<- "tikzv1_1_1(191126)"

# 20191126
#    Drwpt debugged/changed
# 20191104
#    Dotteline changed (Ookisa 2->1/0.075)
# 2019.04.05 Drwpt  ( Incolor, Takato)
# 2019.04.02 Beginpicture  ( Unitlen, Takato)
# 2019.04.02 Drwline  ( Sepen restore when finished, Takato)
# 2019.03.17 from 20190207
#   Ketinit, Beginpicture, Endpicture, Drwline, Setpen, Dottedline, Makehasen, Drwpt, Shade, Letter #from 20190317  

########### Ketinit ############

Ketinit<- function(){
XMIN<<- -5
XMAX<<- 5
YMIN<<- -5 ; YMAX<<- 5
ZIKU<<- "l"
#ARROWSIZE<<- 1
XNAME<<- "$x$"
XPOS<<- "e"
YNAME<<- "$y$"
YPOS<<- "n"
ONAME<<- "O"
OPOS<<- "sw"
ULEN<<- "1cm"
MilliIn<<- 1/2.54*1000
PenThick<<- round(MilliIn*0.02)*0.075 #from 20190317
PenThickInit<<- PenThick
TenSizeInit<<- 0.02*2 #17.10.07
TenSize<<- TenSizeInit
Wfile<<-""
MEMORI<<- 0.05
MEMORIInit<<- MEMORI
MEMORINow<<- MEMORI
MARKLEN<<- 0.05
MARKLENInit<<- MARKLEN
MARKLENNow<<- MARKLEN
GENTEN<<- c(0,0)
YaSize<<- 1
YaAngle<<- 18
YaPosition<<- 1
YaThick<<- 1
YaStyle<<- "tf"
PHI<<- 30*pi/180
THETA<<- 60*pi/180
FocusPoint<<- c(0,0,0)
EyePoint<<- c(5,5,5)
ASSIGNLIST<<- list("`","'")

SCALEX<<- 1
SCALEY<<- 1
LOGX<<- 0
LOGY<<- 0

TEXFORLEVEL<<- 0
TEXFORLAST<<- list()
}

################### Beginpicture ######################

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
  cat("\\begin{tikzpicture}[x=",ULEN,",y=",ULEN,"]%\n",file=Wfile,append=TRUE);#190404
  Str<-"\\clip (";
  Tmp<-as.character(round(Xm,digits=6));
  Str<-paste(Str,Tmp,",",sep="");
  Tmp<-as.character(round(Ym,digits=6));
  Str<-paste(Str,Tmp,") rectangle (",sep="");
  Tmp<-as.character(round(XM,digits=6)+0.5);
  Str<-paste(Str,Tmp,",",sep="");
  Tmp<-as.character(round(YM,digits=6)+0.5);
  Str<-paste(Str,Tmp,");%\n",sep="");
  cat(Str,file=Wfile,append=TRUE);
#  Str=paste('\\linethickness{',as.character(PenThickInit/1000),'in}%',sep="") #20190207
#  cat(Str,file=Wfile,append=TRUE)
#  cat("%\n",file=Wfile,append=TRUE)
}

################### Endpicture #####################

Endpicture<-function(...)
{
  varargin<-list(...)
  Nargs<-length(varargin)
  if(Nargs==0)
  {
    Drwxy()
  }
  else
  {
  if(varargin[[1]]==1) Drwxy()
  }
  cat("\\end{tikzpicture}}%",file=Wfile,append=TRUE)
  MEMORI<<-MEMORINow*1000/2.54/MilliIn
  Setunitlen("1cm")
}

##################### Drwline ######################

Drwline<-function(...)
{
  varargin<-list(...)
  Nall <- length(varargin)
  Tmp <- varargin[[Nall]]
  Width <- PenThick/PenThickInit
  Thick <- 1
  if (mode(Tmp)=="numeric" && length(Tmp)==1){
    Thick <- Tmp
    Setpen(Width*Thick)
    Nall <- Nall-1
  }else{
    Setpen(Width)
  }
  for (N in 1:Nall){
    Pdata <- varargin[[N]]
    if (length(Pdata)==0) next
    if (mode(Pdata)!="list") Pdata<-list(Pdata)
    while(Mixtype(Pdata)==3){ 
      Tmp1 <- list()
      for(II in Looprange(1,length(Pdata))){
        Tmp1 <- Mixjoin(Tmp1,Pdata[[II]])
      }
      Pdata <- Tmp1
    } 
    for (II in Looprange(1,length(Pdata))){
      Clist <- MakeCurves(Pdata[[II]])
      DinM <- Dataindex(Clist)
      for (n in Looprange(1,Nrow(DinM))){
        Tmp <- DinM[n,]
        Data <- Clist[Tmp[1]:Tmp[2],]
#        Mojisu <- 0 #from 20190317
        for (I in Looprange(1,Nrow(Data))){
          Tmp <- Data[I,]
          X=sprintf('%5.5f',Tmp[1])
          Y=sprintf('%5.5f',Tmp[2])
          Pt=paste('(',X,',',Y,')',sep="")
          if (I==1){
#		    if (Width>1){  #from 20190317
		      Str=paste('\\draw [line width=',round(PenThick,digit=6),']',Pt,sep="")
#			}else{
#			  if (Thick>1){
#		    	Str=paste('\\draw [line width=',round(PenThick,digit=6),']',Pt,sep="")
#			  }else{
#                Str=paste('\\draw [line width=',round(PenThick,digit=6),']',Pt,sep="")
#			  }
#            }
		  }else{
            Str=paste('--',Pt,sep="")  
          }
          cat(Str,file=Wfile,append=TRUE)
#          Mojisu <- Mojisu+nchar(Str)
#          if (Mojisu>80){
#            cat(";%\n",file=Wfile,append=TRUE)
#            Mojisu <- 0
#          }
        }
#        if (Mojisu!=0){
#           cat(";%\n",file=Wfile,append=TRUE)
#        }
        cat(";%\n",file=Wfile,append=TRUE)
      }
    }
  }
  if (Thick!=1){  #from 20190402
    Setpen(Width)
  }
}

################### Setpen ######################

Setpen<-function(Width)
{
  PenThick <<- PenThickInit*Width  #from 20190317
#  Str=paste('\\linethickness{',as.character(PenThick/1000),'in}%',sep="")
#  cat(Str,file=Wfile,append=TRUE)
#  cat("%\n",file=Wfile,append=TRUE)
}

##################### Dottedline ########################

Dottedline<- function(...)
{
  varargin <- list(...)     
  Nall <- length(varargin)
  Nagasa <- 0.1
  Ookisa <- PenThick*1/0.075 #2 #171007,191104(1/0.075)
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

################### Makehasen ###################

Makehasen<- function(Figdata,Sen,Gap,Ptn)
{
  Width <- PenThick/PenThickInit #from 20190317
  Setpen(Width) #from 20190317
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
	Com=paste0('%%%%% start dashline, Senlength=',Sen,', Gaplength=',Gap,' %%%%%%') #from 20190317
    cat(Com,file=Wfile,append=TRUE)
    cat(";%\n%\n",file=Wfile,append=TRUE);
    Hajime<- 1; Owari<- 1
#    Mojisu<- 0
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
      Str=paste('\\draw [line width=',round(PenThick,digits=6),']',Pt0,sep="") #from 20190317
      cat(Str,file=Wfile,append=TRUE)
#      Mojisu<- Mojisu+nchar(Str)
      for (J in Looprange(Hajime+1,Owari)){
        P=Data[J,]
        X=sprintf('%5.5f',P[1])
        Y=sprintf('%5.5f',P[2])
        Pt=paste(' -- (',X,',',Y,')',sep="")
        Str=Pt
        cat(Str,file=Wfile,append=TRUE)
#        Pt0=Pt
#        Mojisu=Mojisu+nchar(Str)
      }
      T<- (Len+Naga-Lenlist[Owari])
      T<- T/(Lenlist[Owari+1]-Lenlist[Owari])
      P<- Data[Owari,]+T*(Data[Owari+1,]-Data[Owari,])
      X=sprintf('%5.5f',P[1])
      Y=sprintf('%5.5f',P[2])
      Pt=paste(' -- (',X,',',Y,')',sep="")
      Str=Pt
      cat(Str,file=Wfile,append=TRUE)
      cat(";%\n",file=Wfile,append=TRUE); #190412
#      Mojisu<- Mojisu+nchar(Str)
#      if (Mojisu>80){
#        cat("%\n",file=Wfile,append=TRUE)
#        Mojisu<- 0
#      }
    }
	Com=paste0('%%%%%% finish dashline, Senlength=',Sen,', Gaplength=',Gap,' %%%%%%') #from 20190317
    cat(Com,file=Wfile,append=TRUE)
    cat(";%\n%\n",file=Wfile,append=TRUE);
  }
#  cat("%\n%\n",file=Wfile,append=TRUE);
}

##################### Drwpt ######################

Drwpt<-function(...) #181230
{
  varargin<-list(...)
  Nargs<-length(varargin)
  All=Nargs
  Same="y"
  Incolor=""
  Tmp=varargin[[All]]
  if((is.numeric(Tmp))&&(length(Tmp)>2)){ #190405from
    if(Tmp[1]==-1){
      Same="no"
    }else{
      Tmp1=sapply(Tmp,as.character)
      Incolor=paste("{",Tmp1[1],",",Tmp1[2],",",Tmp1[3],"}",sep="")
      Same="n"
    }
    All=All-1
  }#190405to
  Ra=TenSize*1000/2.54/MilliIn
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
      Str1<- paste("{\\color[rgb]",Incolor,"%\n",sep="")
      cat(Str1,file=Wfile,append=TRUE)
      Str=paste('\\fill (',X,',',Y,') circle [radius=',sprintf('%6.6f',Ra/2),'];%\n',sep="") 
          #191126
      cat(Str,file=Wfile,append=TRUE)
      cat("}%\n",file=Wfile,append=TRUE)
      Str=paste('\\draw [line width=','0.008','in]',sep="")
      for(J in 0:24){
        Tmp1=sprintf('%6.6f',P[1]+Ra/2*cos(J*2*pi/24))
        Tmp2=sprintf('%6.6f',P[2]+Ra/2*sin(J*2*pi/24))
        Str=paste(Str,"(",Tmp1,",",Tmp2,")",sep="");
        if(J<24){
          Str=paste(Str,"--",sep="")
        }else{
          Str=paste(Str,";%\n",sep="")
        }
      }
      cat(Str,file=Wfile,append=TRUE)
    }
  } # 190405to
  cat("\n",file=Wfile,append=TRUE)
}

#################### Shade #####################

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
#  Mojisu=0
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
        Str=paste('\\fill',Pt,sep="")
      }else{
        Str=paste('--',Pt,sep="")
      }
      cat(Str,file=Wfile,append=TRUE)
#      Mojisu<- Mojisu+nchar(Str)
#      if (Mojisu>80){
#        cat("%\n",file=Wfile,append=TRUE)
#        Mojisu<- 0
#      }
    }
    cat(";%\n",file=Wfile,append=TRUE)
  }
#  if(Iroflg==1){
#    Str='}%\n'
#    if(Mojisu>0){
#      Str=paste('\n',Str,'\n',sep="")
#    }else{
#      Str=paste(Str,'\n')
#    }
#    cat(Str,file=Wfile,append=TRUE)
#  }
}

################## Letter ####################

Letter<-function(...)
{     ## Scaling is implemented
  varargin<-list(...)
  Nargs<-length(varargin)
  Irng<-c(seq(from=1,to=Nargs,by=3))
  for (I in Irng)
  {
    Tmp<-varargin[[I]] 
    P<- Doscaling(Tmp)
    X<-P[1]
    Y<-P[2]
    Houkou<-varargin[[I+1]]
    Mojiretu<-varargin[[I+2]]
	if(length(grep("\\$",Mojiretu))>0) #from 20190317
	{
      Mojiretu <- Mojiretu
	}
	else
	{
	  Mojiretu <- paste0("$\\mathrm{",Mojiretu,"}$")
	}
    Hset<-Houkou
    Vhoko<-"c"
    if(length(grep("n",Hset))>0)
    {
      Vhoko<-"n"; Y<-Y+MEMORI
    }
    if(length(grep("s",Hset))>0)
    {
      Vhoko<-"s"; Y<-Y-MEMORI
    }
    Hhoko<-"c"
    if(length(grep("e",Hset))>0)
    {
      Hhoko<-"e"; X<-X+MEMORI
    }
    if(length(grep("w",Hset))>0)
    {
      Hhoko<-"w"; X<-X-MEMORI
    }
    Hoko<-paste(Vhoko,Hhoko,sep="")
    Suu<-"+-.0123456789"
    SuuL<-Suu
    J<-1; Dstr<-""
    while (J<=nchar(Houkou))
    {
      Tmp<-substring(Houkou,J,J)
      if(length(grep(Tmp,SuuL))>0)
      {
        if(Dstr=="") Hk<-substring(Houkou,J-1,J-1)
        Dstr<-paste(Dstr,Tmp,sep="")
      }
      else
      {
        if(Dstr!="")
        {
          Nmbr<-as.numeric(Dstr)
          D<-Nmbr*MEMORI
          if(Hk=="n") Y<-Y+D
          if(Hk=="s") Y<-Y-D
          if(Hk=="e") X<-X+D
          if(Hk=="w") X<-X-D
          Dstr<-""
        }
      }
      J<-J+1
    }
    if(Dstr!="")
    {
      Nmbr<-as.numeric(Dstr)
      D<-Nmbr*MEMORI;
      if(Hk=="n") Y<-Y+D
      if(Hk=="s") Y<-Y-D
      if(Hk=="e") X<-X+D
      if(Hk=="w") X<-X-D
    }
    CalcWidth(Hoko,Mojiretu)
    CalcHeight(Hoko,Mojiretu)
    cat("\\put(",file=Wfile,append=TRUE)
    Tmp1<- sprintf("%7.7f",X)  # 11.07.19
    Tmp2<- sprintf("%7.7f",Y)  # 11.07.19
    Str<-paste(Tmp1,",",Tmp2,sep="")
    cat(Str,file=Wfile,append=TRUE)
    Tmp<-"){\\hspace*{\\Width}"
    Str<-paste(Tmp,"\\raisebox{\\Height}{",Mojiretu,"}}%\n",sep="") 
    cat(Str,file=Wfile,append=TRUE)
    cat("%\n",file=Wfile,append=TRUE)
  }
}
