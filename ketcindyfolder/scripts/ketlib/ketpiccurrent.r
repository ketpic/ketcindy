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

ThisVersion<- "KeTpic for R  v5_2_4(20190127)" 

print(ThisVersion)

# 20190127
#   Mvprod added
# 20181231
#   Drwpt debugged/changed  ( grep removed, N=8 set )
# 20181230
#   Drwpt changed  ( Same, Incolor )
# 20181128
#   Objthicksurf debugged
# 20181031
#   space before # removed
# 20181024
#   Wireparadata debugged ( for DuL(DvL)=c(..) )
#   Nohiddenpara2 debugged  (for SeL=Null )
# 20181020
#   Setscaling changed  ( Setscaling(scalex,scaley) supported )
# 20181019
#   Arrowhead changed(debugged)  ( for basic1.cs )
# 20181017
#   Drwxy debugged  (Doscaling)
#   Arrowhead debugged (Unscaling removed)
#   Paramplot debugged  (Assign(fun,var,"t"))
# 20181015
#   Listplot debugged  ( Unscaling implemented )
# 20180929
#   Paramplot Plotdata, Spacecurve , Implicitplot changed 
#                                ( Dt,dx not divided by N)
#   Shade changed  (Kyoukai => Joincrvs)
# 20180928
# Paramplot changed ( case of stationary point)
# 20180901
# Objcurve debugged  ( Assign rewritten )
# 20180820,21
#  Drwxy changed  ( optional arguments added )
#  Setax changed  (ARROWSIZE removed )
# 20180812
#  Assign debugged ( case nchar(vname)>1)
# 20180808
#  Scalept3pt changed  (ratio)
# 20180807
#  Reflect3pt,Reflect3data,Scale3pt,Scale3data added
# 20180717
#  Hatchdata debugged  (width option)
#  Enclosing debugged  ( for closed curve )
# 20180713
#  Enclosing2 debugged  (for Lineplot: distance of pts added)
# 20180711
#  Enclosing2 debugged  (length => Length)
# 20180707
#  Enclosing2 debugged  (epspara)
# 20180706
#  Enclosing2 debugged  (crv => c)
#  Hatchdata changed ( Interval > *2 )
# 20180621
#  Kyoukai debugged  (1st point converted to matrix, length=>Length)
# 20180615
#  Assign changed (Replace function added)
# 20180603
#  Setcolor debugged (length(Iro))
#  Scaledata,Reflectdata,Rotatedata,Translatedata changed ( for point list)
# 20180602
#  Setcolor changed  (rgb supported)
# 20180523
#  Mkskeletondata debugged
# 20180517
#  Sfbdparadata debugged  ( tmp2[]=>tmp[2])
# 20180511
#  Arrowhead,Arrowheaddata debugged  ( for closed curve)
# 20180510
#  Plotdata,Paramplot changed  ( Assign added for KeTCindy )
#  Texsetctr debugged  (grep, fixed=T)
#   Anglemark debugged ( for PB,PA,angle)
# 20180509
#  Crvonsfparadata renamed to Crv2onsfparadata
#  Makecurves debugged  ( Looprange used )
# 20180506
#  Anglemark changed  ( PB,PA,angle) supported
# 20180501
#  Wireparadata changed and debugged ( is.numeric => length==1 )
# 20180402
#  Implicitplot largely changed
# 20180327
#  Kyoukai debugged
# 20180317
#  IntersectcurvesPp changed and debugged
#  Intersectpartseg changed  (Eps00 )
#  Collectsameseg added, Collectnear commented out
# 20180306
#  PthiddenQ,Meetpoints,Sfcutparadata changed (to avoid duplications )
#  Sfbdparadata changed ( for near points in Implicitdata )
#  Envelopedata, Evlpfun added
# 20180305
#  (for surface drwaings ) Eps => Eps1
# 2018.02.27
#  Nohiddenpara2,Crvsfparadara debugged  (Eps=>Eps0)
# 2018.02.26
#  Sfcutparadata changed
#  Partcrv3 debugged
#  Projcurve rewritten
#  Nohiddenparadata debugged 
#  PthiddenQ debugged
# 2018.02.24
#  Sfcutdata added ( for functions )
#  Meetpoints debugged  (case Norm(PtB-PtA)<Eps0)
# 2018.02.23
#  Makevaltable2 added ( for functions )
# 2018.02.23
#  Crvonsfparadata,Crv3onsfparadata added
#  Wireparadata added
# 2018.02.22
#  PthiddenQ,Nohiddenpara2 changed (Eps2)
# 2018.02.21
#  PthiddenQ,Meetpoints debugged
#  Crvsfparadata debugged (OTHERPARTITION)
#  Partitionseg debugged (for non-list) and changed (Ns=0)
#  Intersectcrvsf added
# 2018.02.19
#  Groupnearpt added
#  Collectnear debugged
#  Meetpoints,PthiddenQ debugged and changed (Groupnearpt used )
#  Parapt changed (for point list )
#  Partitionseg changed (remove close value )
#  Fullformfunc changed (Initialization of ADDPOINT)
#  Addpoints added
# 2018.02.18
#   Projpara debugged ( for empty data, Mix replace )
#   WriteOutData debugged (for emply data )
#   Sfbdparadata,Cuspparadata debugged 
#   Meetpoints replaced
# 2018.02.17
#   PthiddenQ replaced
# 2018.02.15
#   Cancoordpara debugged  (X=-... )
# 2018.02.14
#   Paramoncrv,Pointoncrv renamed to ...curve
# 2018.02.12
#   Nohiddenpara2 debugged  ( CUSPPT should be a list )
#   Dropnumlistcrv changed  (Eps)
# 2018.02.11
#   Paramocrv debugged ( case N=Length(PtL) )
#   Sfbdparadata, Borderparadata, Makexybdy, Partitionseg, 
#     Evlptablepara, Fullformfunc, Dropnumlistcrv, Cuspsplitpara,
#     PthiddenQ, Nohiddenpara2 added
#   Crvsfparadata, Meetpoints, Clipdomain added
# 2018.02.10
#   Partcrv3 debugged
# 2018.02.09
#   Ptstart,Ptend changed ( for the case fig is empty)
#   Norm changed  (Dotprod used )
# 2018.02.07
#   Collectnear debugged (Looprange )
#    Intersectcurves debugged (sum)
# 2018.02.06
#   Kukeiiwake debugged ( ParamonCurve -> Paramoncrv )
# 2018.02.05
#   Dotprod changed ( crossprod not used )
#   Intersectpartseg changed ( case of length of result =1)
# 2018.02.04
#   Diff added  ( func, withvar, (varnamevalue1,... ))
#   Funvalue added ( for an expression )
# 2018.02.02
#   Enclosing2 changed ( for distant curves, startpt option removed )
# 2018.02.01
#   Intersectline,Intersectseg,...,Intersectcuves added
#   Quicksort added
#   Enclosing2 added (incomplete)
# 2018.01.29
#   Length added
# 2017.12.24
#   Objpolyhedron added
# 2017.12.23
#   Objsymb, symb3data added
#   Objrecs, Objpolygon debugged
#   Objthicksurf added
# 2017.12.22
#   Openobj,Closeobj,Writeobjpoint,Printobjstr,Objname,Objsurf added
#   Crossprod added
#   Objjoin, Objcurve, Objrecs, Objpolygon, Objsymb added
#   Spacecurve  debugged
# 2017.12.17
#   Setunitlen debugged  ( MEMORI )
# 2017.12.13
#   ReadOutData debugged
# 2017.12.11
#   Enclosing debugged  ( appendrow -> Appendrow )
# 2017.11.29
#   Anglemark, Arrowhead, Ovaldata debugged ( Circldeta included )
# 2017.11.27
#   Anglemark changed ( Scilab 16.12.29)
#   Plotdata,Paramplot,Spacecurve changed ( Scilab 16.12.13)
#   Enclosing changed ( Scilab 16.10.09)
#   Arrowhead,Arrowline changed ( Scilab 15.06.11)
#   Definecolor added ( Scilab 15.05.04)
# 2017.11.26
#   Exprrot, Letterrot debugged  ( `)
# 2017.11.24
#  Deqplot debugged (Looprange)
# 2017.11.20
#  InWindow debugged (for length=1)
# 2017.10.28
#  Openfile changed (Creator)
# 2017.10.23
#  ReadOutData greatly changed
# 2017.10.11
#  Drwpt debugged  (Flattenlist )
# 2017.10.08
#  Bezier debugged  ( Num )
# 2017.10.07
#  ReadOutData debugged  ( for null data )
# 2017.10.06
#  Deqdata, Deqplot added
#  Connectseg  remade(bug)
# 2017.09.30
#  Bezierpt, Bezier added
# 2017.09.29
#  Ptcrv debugged
# 2017.09.28
#  Openfile changed
# 2017.09.24
#  Circledata debugged
#  Kyoukai changed (Eps)
#  Shade updated
# 2017.09.22
#  Setcolor changed
#  Plotdata,Paramplot,Spacecurve changed (N-1 -> N)
# 2017.09.21
#  Shade changed (Sci 17.01.09)
# 2017.09.17
#  Ovaldata,Assignadd changed
#  Dist added
#  Cicledata changed
#  Bowdata debugged  (Circledata,etc)

# 2015.11.05
#  WriteOutData changed

# 2015.10.29
#  WriteOutData changed  ( endmark //// )

# 2015.10.24
#  ReadOutData changed  ( in case of listlength=1 )

# 2014.12.23
#  ReadOutData added

# 2014.12.17
#  WriteOutData added

# 2014.0905
# Unscaling debugged  MARKLENI => MARKLEN
# 2014.03.31
# PhHiddenData added
# 2014.03.30
# Facesdata changed ( for Hiddendata )
# 2014.03.23
# MARKLEN separated, Rotate3data debugged

# 2013.12.19
# Openfile, Closefile, Bowname, Bownamerot

# 2013.11.13
#  Arrowhead, Arrowheaddata

# 2013.08.07
# Cancoordpara added

# 2013.08.07
# Integrate added

# 2013.05.20
# Openfile changed

# 2013.05.03
# Tabledata, Pointdata changed
# Dividetable, Partframe added

# 2013.02.10
# Ketinit added

# 2012.01.07
# Arrowline, Arrowhead  ( Cut implemented )

# 2011.12.18
# Framedata  ( compliant for list )

# 2011.12.12
# Skeletonparadata...   ( Flattellist used)

# 2011.11.27
# drwboxframe

# 2011.11.07
# metacommands added

# 2011.11.02
# Joingraphics ( for list structure )

# 2011.08.24
# Setcolor   ( c(1,0,0,0.5) etc )
# Rotate3data  ( Point is available )

# 2011.07.19
# Drwline, Letter, Expr
# Drwboxplot( etc ) min,max  => outliners
# Drwline  ( unfinished  in the case of "integer" )

# 2011.06.25
# joincrvs debugged

#  synchro  with ketpict2e

# 2011.06.01
#  Bowdata debugged

#2011.05.28
#  Ratiocmyk, Setcolor ( new )

#2011.04.28
# Htickmark, Vtickmark debugged 

#2011.03.08
# Drwboxframe debugged 
# Putrow, Putrowexpr debugged  (Dpos )

#2011.03.02
# Tabledata  ( index of hline ), PutcoL, PutcoLexpr ( "r",...) debugged
# Texcom changed  ( // => backslash )

#2011.01.07
# Dividegraphics, Splinedat are changed significantly
# Readtextdata is  changed 

#2011.01.04
# Derivative, Integrate are added

#2010.12.07
# Translatedata, Scaledata, Reflectdata changed  ( efficient for vector )
# Rotatedata changed  ( deg : logical )
# HIstplotdata, Drwhistplot   ( type => freq , fpplot (added) )

# 2010.12.04
# WindispT  changed  ( tickmark )
# Lineplot  changed  ( mag=> length )
# Plotdata debugged ( 'E=fun', 'D=')
# Enclosing changed  (return PD)

# 2010.12.02
# WindispT  changed
# Makecurves debugged  

# 2010.11.27
# Pointdata changed ( efficient for matrix and data.frame )
# WindispT
# Setwindow  ( decide from data )
# Assign debugged    ( strsplit => gsub(fixed=T))

# 2010.11.20
# Flattenlist, WindispT
# Splinedata  changed( efficient for data.frame )

#2010.08.19  ( Maybe not finished )
# Stripblanks
# Fullformfunc, Sf3data

#2010.08.17
# Phparadata, Phpersdata, Phspersdata, Phsparadata
# Facesdata, MakeveLfaceL, Menkakusi2
# Rotate3data
# Skeletonpersdata, Skeletonpers3data, Makeskeletonpersdata
# Embed

#2010.08.16
# Spacecurve  changed
# CameracoordCurve, Partcrv3, Projpers, CameraCurve,
# Perspt, Xyzaxpersname, Invperspt, Zparapt, Zperspt

# 2010.08.15
# Phcutoffdata added

# 2010.08.13
# Phcutdata, Spacecurve debugged
# Setangle changed

# 2010.08.09
# Spacecurve
# Rotate3data, Rotate3pt
# Phcutdata

# 2010.08.08
#        Implementing 3d
# Initangle, Setangle, Setpers, SetstereoL, SetstereoR
# Mixlength
# Spaceline, Projpara, ProjCurve, Parapt
# Xyzax3data, Xyzaxparaname
# Cancoordpers, Invparapt, ProjcoordCurve
# Skeletonparadata, Skeletonpara3data, Makeskeletondata, Kukannozoki

# 2010.07.25
# Rotatedata changed
# Drwline changed (list of list)

# 2010.04.09
# Stat package added

# 2010.04.02
# Putcolexpr, Putrowexpr

# 2010.04.02

# Windisp, Op  changed
# Execmd  added
# Texnewcmd, Texrenewcmd, Texend,
# Texctr, Texnewctr, Texsetctr
# Kyoukai debugged

# 2010.01.20
# Partcrv, Makeshasen  : debugged

# 2010.01.23
# Ovaldata, Ovalbox added

# 2010.01.27
# Readtextdata changed
# Putrow, PutcoL debugged  ( Putcol is OK)

# 2010.01.31
# Writetextdata added

# 2010.02.12
# Texvalctr, Texthectr added

# 2010.02.22
# Execmd changed

# 2010.02.23
# Op, Windisp changed

# 2010.02.24
# Execmd changed

# 2010.03.07
# Dotfilldata  (Kosa>1)

# 2010.03.21
# Mixjoin 
# Koutenlist  (bug)


# 2010.03.24
# Arrowhead  ( bug in the case of "l" )

# 2010.03.28
# Tabledata
# Diagcelldata ( New )

# 2010.03.30
# Tabledata

###########################################

XMIN<- -5
XMAX<- 5
YMIN<- -5 ; YMAX<- 5
ZIKU<- "l"
#ARROWSIZE<- 1
XNAME<- "$x$"
XPOS<- "e"
YNAME<- "$y$"
YPOS<- "n"
ONAME<- "O"
OPOS<- "sw"
ULEN<- "1cm"
MilliIn<- 1/2.54*1000
PenThick<- round(MilliIn*0.02)
PenThickInit<- PenThick
TenSizeInit<<- 0.02*2 #17.10.07
TenSize<- TenSizeInit
Wfile<-""
MEMORI<- 0.05
MEMORIInit<- MEMORI
MEMORINow<- MEMORI
MARKLEN<- 0.05
MARKLENInit<- MARKLEN
MARKLENNow<- MARKLEN
GENTEN<- c(0,0)
YaSize<- 1
YaAngle<- 18
YaPosition<- 1
YaThick<- 1
YaStyle<- "tf"
PHI<- 30*pi/180
THETA<- 60*pi/180
FocusPoint<- c(0,0,0)
EyePoint<- c(5,5,5)
ASSIGNLIST<- list("`","'")

SCALEX<- 1
SCALEY<- 1
LOGX<- 0
LOGY<- 0

TEXFORLEVEL<- 0
TEXFORLAST<- list()

#######################

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
PenThick<<- round(MilliIn*0.02)
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

#-------------------------------------------------------

Appendrow<- function(...)
{
  varargin<- list(...)
  Nargs<- length(varargin)
  Out<-c()
  Nc<- 0
  for (I in 1:Nargs)
  {
    Dt<- varargin[[I]]
    Nc<- max(Nc,Ncol(Dt))
    if(class(Dt)=="matrix") Dt<-as.numeric(t(Dt))
    Out<- c(Out,Dt)
  }
  if(Nc>0)
  {
    Out<-matrix(Out, nrow=Nc)
    Out<-t(Out)
  }
  else
  {
    Out<-c()
  }
  return(Out)
}

Datalength<-function(Data)
{
  if(length(Data)==0) return(0)
  if(mode(Data)=="numeric") return(Nrow(Data))
  if(mode(Data)=="character") return(nchar(Data))
  if(mode(Data)=="list") return(length(Data))
}

Crossprod<- function (a,b){ # 17.12.22
  if(length(a)==3){
    Tmp1=a[2]*b[3]-a[3]*b[2]
    Tmp2=a[3]*b[1]-a[1]*b[3]
    Tmp3=a[1]*b[2]-a[2]*b[1]
    Out=c(Tmp1,Tmp2,Tmp3)
  }else{
    Out=a[1]*b[2]-a[2]*b[1]
  }
  return(Out)
}

Dotprod<-function(a,b){ # 18.02.05
  nn=min(length(a),length(b))
  out=0
  for(jj in Looprange(1,nn)){
    out=out+a[jj]*b[jj]
  }
  return(out)
}

Mvprod<- function(...){ # 190127
  varargin<- list(...)
  mat=varargin[[1]]
  vec=varargin[[2]]
  if(length(varargin)>2){
    nn=varargin[[3]]
  }else{
    nn=1
  }
  mm=round(length(vec)/nn)
  mat=matrix(mat,ncol=mm,byrow=TRUE)
  vec=matrix(vec,nrow=nn,byrow=TRUE)
  out=c()
  for(jj in 1:nn){
    tmp=mat%*%Op(jj,vec)
    out=c(out,tmp)
  }
  if(nn>1){
    out=matrix(out,nrow=nn,byrow=TRUE)
  }
  return(out)
}

Dist<- function(...) # 17.09.17
{
  varargin<- list(...)
  a=varargin[[1]]
  if(length(varargin)==1){
    tmp=sqrt(Dotprod(a,a))
	return(as.vector(tmp))
  }
  else{
    b=varargin[[2]]
    tmp=sqrt(Dotprod(b-a,b-a))
    retun(as.vector(tmp))
  }
}

Member<-function(A,L)
{
  N<-length(L);
  if(length(N)==0) return(FALSE)
  for (I in 1:N)
  {
    if(class(L)=="list")
    {
      Tmp<-L[[I]]
    }
    else
    {
      Tmp<-L[I]
    }
    if(mode(A)=="numeric")
    {
      if(Norm(A-Tmp)==0) return(TRUE)
    }
    else
    {
      if(A==Tmp) return(TRUE)
    }
  }
  return(FALSE)
}

Norm<-function(V)
{
  Tmp=Dotprod(V,V) #18.02.09
#  Tmp<-as.vector(V);
#  Tmp<-crossprod(Tmp,Tmp)
  Tmp<-sqrt(Tmp)
#  as.numeric(Tmp)
}

Ncol<-function(P)
{
  if(class(P)=="matrix") return(ncol(P))
  else return(length(P))
}

Nrow<-function(P)
{
  if(length(P)==0) return(0)
  if(class(P)=="matrix") return(nrow(P))
  else return(1)
}

Looprange<- function(a,b)
{
if(a<=b) return(a:b)
return(c())
}

Stripblanks<- function(Ch){
  Tmp<- gsub(" ","",Ch,fixed=TRUE)
  return(Tmp)
}

Quicksort<- function(seqL,key){ #18.02.01
  if(length(seqL)<2){
    out=seqL
  }else{
    tmp1=Op(1,seqL)
    tmp2=Op(2,seqL)
    if(Op(key,tmp1)>=Op(key,tmp2)){
      pivot = tmp1
    }else{
      pivot=tmp2
    }
    left = list()
    right = list()
    for(ii in 1:length(seqL)){
      tmp=Op(ii,seqL)
      if(Op(key,tmp)< Op(key,pivot)){
        left=c(left,list(tmp))
      }else{
        right=c(right,list(tmp))
      }
    }
    left = Quicksort(left,key)
    right = Quicksort(right,key)
    out=c(left,right)
  }
  return(out)
}

Derivative<- function(...)
{
  varargin<- list(...)
  Nargs<- length(varargin)
  Fstr<- varargin[[1]]
  Vstr<- varargin[[2]]
  NvaL<- length(Vstr)
  Flg<- 0
  if(Nargs>=3){
    VaL<- varargin[[3]]
    Flg<- 1
  }
  Str<- paste("deriv(~",Fstr,",c('",Vstr[1],"'",sep="")
  for(J in Looprange(2,NvaL)){
    Str<- paste(Str,",'",Vstr[J],"'",sep="")
  }
  Str<- paste(Str,")",sep="")
  if(NvaL<=3){
    Str<- paste(Str,",func=TRUE)",sep="")
  }
  else{
    Str<- paste(Str,")",sep="")
  }  
  f<- eval(parse(text=Str))
  if(Flg==1){
    if(NvaL<=3){
      if(NvaL==1){V<- f(VaL[1])}
      if(NvaL==2){V<- f(VaL[1],VaL[2])}
      if(NvaL==3){V<- f(VaL[1],VaL[2],VaL[3])}
    }
    else{
      for(J in 1:NvaL){
        Tmp<- paste(Vstr[J],'<-',as.character(VaL[J]))
        eval(parse(text=Tmp))
      }
      V<- eval(f)
    }
    Out<- attr(V,'gradient')
    Out<- Out[1,]
  }
  else{
    Out<- f
  }
  return(Out)
}

Diff<- function(...){ #18.02.04
  varargin=list(...)
  Nargs=length(varargin)
  fun=varargin[[1]]
  withvar=varargin[[2]]
  tmp=paste("f<- expression(",fun,")",sep="")
  eval(parse(text=tmp))
  nn=nchar(withvar)
  for(jj in Looprange(1,nn)){
    tmp=substring(withvar,jj,jj)
    f=D(f,tmp)
  }
  var=c()
  val=""
  for(jj in Looprange(3,Nargs)){
    tmp=strsplit(varargin[[jj]],"=")
    var=c(var,tmp[[1]][1])
    val=paste(val,tmp[[1]][2],",",sep="")
  }
  if(Length(val)>1){
    val=substring(val,1,Length(val)-1)
    f=deriv(f,var,func=TRUE)
    tmp=paste("out=f(",val,")",sep="")
    out=eval(parse(text=tmp))
    return(out[1])
  }else{
    return(f)
  }
}

Funvalue<- function(...){
  varargin=list(...)
  Nargs=length(varargin)
  df=varargin[[1]]
  var=c()
  val=""
  for(jj in Looprange(2,Nargs)){
    tmp=strsplit(varargin[[jj]],"=")
    var=c(var,tmp[[1]][1])
    val=paste(val,tmp[[1]][2],",",sep="")
  }
  val=substring(val,1,Length(val)-1)
  dfun=deriv(df,var,func=TRUE)
  tmp=paste("out=dfun(",val,")",sep="")
  eval(parse(text=tmp))
  return(out[1])
}

Integrate<- function(...)
{
  varargin<- list(...)
  Nargs<- length(varargin)
  Fstr<- varargin[[1]]
  Vstr<- varargin[[2]]
  IntvL<- varargin[[3]]
  Str<- 'Tmpfun<- function('
  Str<- paste(Str,Vstr,'){',sep='')
  Str<- paste(Str,Fstr,'}',sep='')
  eval(parse(text=Str))
  Tmpfunv<- function(x){sapply(x,Tmpfun)}
  Out<- 0
  for (J in 1:(length(IntvL)-1)){  
    Tmp<- integrate(Tmpfunv,IntvL[J],IntvL[J+1])
    Out<- Out+Tmp[[1]]
  }
  return(Out)
}

#--------------------------------------

#########################
# 180506   (pB,pA,angle) supported

Anglemark<- function(...)
{
  varargin<- list(...) 
  Nargs<- length(varargin)
  Eps<- 10^(-3)
  PB<- varargin[[1]]
  PA<- varargin[[2]]
  PC=varargin[[3]]
  r <-  0.5
  if(Nargs>=4){
    r<-  varargin[[4]]*r  
  }
  Out=c()
  if(length(PC)>1){ #180506from
    Tmp=min(Norm(PB-PA),Norm(PC-PA))
  }else{
    Tmp=Norm(PB-PA)
  }
  if(r>Tmp){ #180506to
    return(Out)
  }
  Cir<- Circledata(c(PA,r)) #17.11.29
  Tmp<- IntersectcrvsPp(Cir,Listplot(PA,PB))
  P1<- Op(2,Op(1,Tmp))
  if(length(PC)>1){
    Tmp<- IntersectcrvsPp(Cir,Listplot(PA,PC))
    P2<- Op(2,Op(1,Tmp))
    if(abs(P1-P2)<Eps){
      Out<-c()
      return(Out)
    }
    if(P1<P2-Eps){
      Out<- Partcrv(P1,P2,Cir)
    }
    else{  
      Tmp<- Numptcrv(Cir)
      Tmp1<- Partcrv(P1,Tmp,Cir)
      Tmp2<- Partcrv(1,P2,Cir)
      Out<- Joincrvs(Tmp1,Tmp2)
    }
  }else{
    Tmp1=Pointoncurve(1,Cir)-PA
    Tmp2=Pointoncurve(2,Cir)-PA
    Tmp=Dotprod(Tmp1,Tmp2)/(Norm(Tmp1)*Norm(Tmp2))
	Tmp=PC/acos(Tmp)
    if(P1+Tmp<Length(Cir)){
      Out<- Partcrv(P1,P1+Tmp,Cir)
    }else{
      Tmp1= Partcrv(P1,Length(Cir),Cir)
      Tmp2= Partcrv(1,P1+Tmp-Length(Cir)+1,Cir)
      Out<- Joincrvs(Tmp1,Tmp2)
    }
  }
  Out
}

##############################################

Arrowdata<- function(...)
{
  varargin<- list(...)
  Nargs<- length(varargin)
  P<- varargin[[1]]
  Q<- varargin[[2]]
  R<- Q
  Futosa<- YaThick
  Ookisa<- YaSize
  Thickness<- 1
  Hiraki<- YaAngle
  Yapos<- YaPosition
  Position<- 1
  Str<- YaStyle
  Flg<- 0
  for (I in Looprange(3,Nargs)){
    Tmp<- varargin[[I]]
    if(mode(Tmp)=="numeric"){
      if(length(Tmp)>1){
        R<- Tmp
      }
      else{
        if(Flg==0){
          Ookisa<- Ookisa*Tmp
        }
        if(Flg==1){
          if(Tmp<5){ 
            Hiraki<- Tmp*Hiraki
          }
          else{
            Hiraki<- Tmp
          }
        }
        if(Flg==2){
          R<- P+Tmp*(Q-P)
        }
        else{
          R<- P+Yapos*(Q-P)
        }
        if(Flg==3){
          Futosa<- Tmp
        }
        Flg<- Flg+1
      }
    }
    if(mode(Tmp)=="character"){
      Tmp<- grep("=", Tmp)
      if(length(Tmp)>0){
        eval(parse(text=Tmp))
        Futosa<- Futosa*Thickness
        R<- P+Position*(Q-P)
      }
      else{
        Str<- Tmp
      }
    }
  }
  Tmp1<- Listplot(c(P,Q))
  Tmp2<- Arrowheaddata(R,Q-P,Ookisa,Hiraki,Futosa,Str)
  Out<- Joingraphics(Tmp1,Tmp2)
}

######################################

#  2018.10.19   for new basic1.cs
#  2013.11.13   No Intersect debugged

Arrowhead<-function(...){
## Scaling is implemented
## 12.01.08  Kirikomi 
  Eps=10^(-3)
  varargin<-list(...)
  Nargs<-length(varargin)
  P<-varargin[[1]]
  Houkou<-varargin[[2]]
  Ookisa<-0.2*YaSize
  Hiraki<-YaAngle
  Futosa<-0.5*YaThick
  Cut<- 0
  Str<-YaStyle
  Flg<- 0
  for (I in Looprange(3,Nargs)){
   Tmp<-varargin[[I]]
   if(is.character(Tmp)){ 
      Equal<- grep("=",Tmp,fixed=TRUE)  # 12.01.07 from
      if(length(Equal)>0){
        Tmp1<- strsplit(Tmp,"=",fixed=TRUE)
        Tmp2<- Tmp1[[1]]
        if(Tmp2[1]=="Cut" || Tmp2[1]=="cut"){
         Tmp<- paste("Cut=",Tmp2[2],sep="")
          eval(parse(text=Tmp))
       }
      }else{
        Str<- Tmp
      }  #  12.01.07 until
    }
    if(is.numeric(Tmp) && length(Tmp)==1){
      if(Flg==0) Ookisa<-Ookisa*Tmp
      if(Flg==1){
        if(Tmp<5) Hiraki<-Tmp*Hiraki
        else Hiraki<-Tmp
      }
      if(Flg==2) Futosa<-Tmp
      Flg<-Flg+1
    }
  }
  Ookisa<-1000/2.54/MilliIn*Ookisa
  Theta<-Hiraki*pi/180
  P<- Doscaling(P)
  Houkou<- Doscaling(Houkou)
  if(Nrow(Houkou)>1){
    Tmp<-Nearestpt(P,Houkou) #181019 (2lines)
    P<- Tmp[[1]]
    I<-floor(Tmp[[2]])
    if(I==1){# 180511
      if(Norm(Ptend(Houkou)-Ptstart(Houkou))<Eps){
        I=Numptcrv(Houkou)
      }
    }
    G<-Circledata(c(P,Ookisa*cos(Theta)),"Num=10") #181019(2lines)
    Flg<- 0  # 13.11.13
    JL<-seq(I,1,by=-1)
    for (J in JL){
      Tmp1=matrix(c(P,Op(J,Houkou)),ncol=2,byrow=TRUE) #181019
#      Tmp<-IntersectcurvesPp(Tmp1,G,0.001,0.01) 
      Tmp<-IntersectcrvsPp(Tmp1,G) 
      if(Length(Tmp)>0){
        Houkou<-P-Op(1,Tmp[[1]])
	    Flg<- 1
	    break
      }
    }
    if(Flg==0){ # 13.11.13
	   print("Arrowhead may be too large (no intersect)")
       return(P)
    }
  }
  Ev<--1/Norm(Houkou)*Houkou
  Nv<-c(-Ev[2],Ev[1])
  if(length(grep("c",Str))>0){
    P<- P-0.5*Ookisa*cos(Theta)*Ev
  }
  if(length(grep("b",Str))>0){
    P<- P-Ookisa*cos(Theta)*Ev
  }
  A<- P+Ookisa*cos(Theta)*Ev+Ookisa*sin(Theta)*Nv
  B<- P+Ookisa*cos(Theta)*Ev-Ookisa*sin(Theta)*Nv
  if(length(grep("l",Str,fixed=TRUE))>0){
    Tmp<- matrix(c(A,P,B),ncol=2,byrow=TRUE)#181019(2lines)
    Tmp1<- Unscaling(Tmp)  
    Drwline(Tmp1,Futosa)
  }
  else{
    C<- P+(1-Cut)*((A+B)/2-P) # 12.01.07
    Tmp<-  matrix(c(A,P,B,C,A),ncol=2,byrow=TRUE) #181019(2lines)
    Tmp1<- Unscaling(Tmp)
    Shade(Tmp1)
    Tmp= matrix(c(A,P,B,C,A,P),ncol=2,byrow=TRUE)#181019(2lines)
    Tmp1=Unscaling(Tmp)
    Drwline(Tmp1,0.1)  # 15.06.11, 15.06.14
  }
}

############################################

#  2013.11.13  No intersect debugged

Arrowheaddata<- function(...)
{  ## Scaling is implemented
  Eps=10^(-3)
  varargin<- list(...)
  Nargs<- length(varargin)
  P<- varargin[[1]]
  Houkou<- varargin[[2]]
  Ookisa<- 0.2*YaSize
  Hiraki<- YaAngle
  Futosa<- 0
  Thickness<- 1
  Str<- YaStyle
  Flg<- 0
  for (I in Looprange(3,Nargs)){
    Tmp<-varargin[[I]]
    if(mode(Tmp)=="character"){
      Tmp1<-grep("=",Tmp)
      if(length(Tmp1)>0){
        eval(parse(text=Tmp))
        Futosa<- Thickness
      }
      else{
        Str<- Tmp
      }
    }
    if(mode(Tmp)=="numeric" && length(Tmp)==1){
      if(Flg==0) Ookisa<-Ookisa*Tmp
      if(Flg==1){
        if(Tmp<5) Hiraki<-Tmp*Hiraki
        else Hiraki<-Tmp
      }
      if(Flg==2) Futosa<-Tmp
      Flg<-Flg+1
    }
  }
  Theta<- Hiraki*pi/180
  if(Nrow(Houkou)>1){
    P<- Doscaling(P)
    Houkou<- Doscaling(Houkou)
    Tmp<-Nearestpt(P,Houkou)
    A<-Tmp[[1]]
    I<-floor(Tmp[[2]])
    if(I==1){# 180511
      if(Norm(Ptend(Houkou)-Ptstart(Houkou))<Eps){
        I=Numptcrv(Houkou)
      }
    }
    G<-Circledata(c(P,Ookisa*cos(Theta)),N=10) #17.11.29
    Flg<- 0  # 13.11.13
    JL<-seq(I,1,by=-1)
    for (J in JL){
      B<- Ptcrv(J,Houkou)
      Tmp<- IntersectcrvsPp(Listplot(list(A,B)),G)
      if(length(Tmp)>0){
        Flg<- 1
        break
      }
      A<-B
    }
    if(Flg==0){ # 13.11.13
	   print("Arrowhead may be too large (no intersect)")
       return(P)
    }
    Houkou<-P-Op(1,Tmp[[1]])
    Houkou<- Unscaling(Houkou)
    P<- Unscaling(P)
  }
  P<- Doscaling(P)
  Houkou<- Doscaling(Houkou)  
  Ev<- -1/Norm(Houkou)*Houkou
  Nv<- c(-Ev[2],Ev[1])
  if(length(grep("c",Str))>0){
    P<-P-0.5*Ookisa*cos(Theta)*Ev
  }
  if(length(grep("b",Str))>0){
    P<-P-Ookisa*cos(Theta)*Ev
  }
  A<-P+Ookisa*cos(Theta)*Ev+Ookisa*sin(Theta)*Nv
  B<-P+Ookisa*cos(Theta)*Ev-Ookisa*sin(Theta)*Nv
  Tmp<- Listplot(A,P,B)
  Out<- Unscaling(Tmp)
  return(Out)
}

##########################################

Arrowline<- function(...)
{    # 12.01.07 kirikomi
  varargin<- list(...)
  Nargs<- length(varargin)
  P<- varargin[[1]]
  Q<- varargin[[2]]
  Futosa<- YaThick
  Ookisa<- YaSize
  Hiraki<- YaAngle
  Yapos<- YaPosition
  Cutstr<- "Cut=0"
  Str<- YaStyle
  Flg<- 0
  for (I in Looprange(3,Nargs)){
    Tmp<- varargin[[I]]
    if(is.character(Tmp)){
      Equal<- grep("=",Tmp,fixed=TRUE) # 12.01.07 from
      if(length(Equal)>0){
        Tmp1<- strsplit(Tmp,"=")
        Tmp2<- Tmp1[[1]]
        if(Tmp2[1]=="Cut" || Tmp2[1]=="cut"){
          Tmp<- paste("Cut=", Tmp2[2],sep="")
          Cutstr<- Tmp
        }
      }
      else{
        Str<- Tmp
      }  # 12.01.07 until
    }
    if(is.numeric(Tmp) && length(Tmp)==1){
      if(Flg==0) Ookisa<- Ookisa*Tmp
      if(Flg==1){
        if(Tmp<5) Hiraki<- Tmp*Hiraki
        else Hiraki<- Tmp
      }
      if(Flg==2) Yapos<- Tmp
      if(Flg==3) Futosa<- Tmp
      Flg<- Flg+1
    }
  }
  R<- P+Yapos*(Q-P)
  Tmp=Q-Unscaling(0.2*Ookisa/2*(Q-P)/Norm(Q-P)) # 15.10.24
  Drwline(Listplot(c(P,Tmp)),Futosa)
  Tmp=SCALEY
  Setscaling(1)
  Arrowhead(R,Q-P,Ookisa,Hiraki,Futosa,Cutstr,Str)
  Setscaling(Tmp)
}

#########################################

Assign<- function(...){
  Replace=function (vname,rep,str){#180615from
    opv=c("+","-","*","/","(",")","=","<",">",""," ",",") #180812
    out=""
    start=1
    Tmp=gregexpr(vname,str,fixed=TRUE)
    Vp=Op(1,Tmp)
    if(min(Vp)>0){
      for(j in Vp){
        if(j==1){bf=""}else{bf=substring(str,j-1,j-1)}
        Tmp=j+nchar(vname)-1 #180812(2lines)
        if(Tmp==nchar(str)){af=""}else{af=substring(str,Tmp+1,Tmp+1)}
        tmp1=length(intersect(bf,opv))
        tmp2=length(intersect(af,opv))
		tmp=substring(str,start,j+nchar(vname)-1) #180812
        if((tmp1>0)&&(tmp2>0)){
          tmp=gsub(vname,rep,tmp,fixed=TRUE)
        }
        out=paste(out,tmp,sep='')
        start=j+nchar(vname) #180812
      }
    }
    out=paste(out,substring(str,start,nchar(str)),sep='')
  }#180615to
  varargin<- list(...)
  Nargs<- length(varargin)
  if(Nargs==0){
    ASSIGNLIST<<- list("`",Prime())
    Out<- ASSIGNLIST
    return()
#    return("Assign reset done");
  }
  L<- list("`","'")
  if(Nargs%%2==0){
    L<- Mixjoin(L,varargin)
    ASSIGNLIST<<- L
    Out<- L
    return()
#    return("Assign set done");
  }
  if(Nargs==1){
    Fnstr<- varargin[[1]]
    if(nchar(Fnstr)==0){ # case of "" 
      L<- ASSIGNLIST
      Out<- c()
      for (I in seq(1,length(L),by=2)){
        Tmp1<- L[[I]]
        Tmp2<- L[[I+1]]
        if(length(Tmp2)==1){
          Tmp3<- as.character(Tmp2)
        }
        else{
          if(mode(Tmp2)=="character"){
            Tmp3<- Tmp2
          }
          else if(mode(Tmp2)=="list"){
            Tmp3<- makeliststr(Tmp2)
          }
          else if(mode(Tmp2)=="numeric"){
            Tmp3<- "c("
            for (J in Looprange(1,length(Tmp2))){
              Tmp3<- paste(Tmp3,as.character(Tmp2[J]),sep="")
              if(J<length(Tmp2)){
                Tmp3<- paste(Tmp3,",",sep="")
              }
            }
            Tmp3<- paste(Tmp3,")",sep="")
            if(class(Tmp2)=="matrix"){
              Nr<- as.character(nrow(Tmp2))
              Tmp3<- paste("matrix(",Tmp3,"nrow=",Nr,")",sep="")
            }
          }
        }
        Tmp<- paste(Tmp1,"=",Tmp3,sep="")
        Out<- c(Out,Tmp)
      }
      return(Out);
    }
    if(substr(Fnstr,1,1)=="?"){
      Fnstr<- substr(Fnstr,2,nchar(Fnstr))
      for (I in seq(1,length(ASSIGNLIST),by=2)){
        Tmp<- ASSIGNLIST[[I]]
        if(Tmp==Fnstr){
          Out<- Mixjoin(list(I),ASSIGNLIST[I+1])
          return(Out)
        }
      }
      Out<- "Not found"
      return(Out);
    }
    L<- ASSIGNLIST
  }
  else{
    if(mode(varargin[[2]])=="numeric"){
      Fnstr<- varargin[[Nargs]]
      for (I in Looprange(1,Nargs-1)){
        L[[I]]=varargin[[I]]
      }
    }
    else{
      Fnstr<- varargin[[1]]
      for (I in Looprange(2,Nargs)){
        L[[I-1]]<- varargin[[I]]
      }
    }
  }

FlagL<<- 0

  for (I in seq(1,length(L),by=2)){
    Vname<- L[[I]]
    Val<- L[[I+1]]
    if(mode(Val)=="numeric"){
      if(Nrow(Val)==1){
        for (K in Looprange(1,length(Val))){
          if(length(Val)==1){
           Tmp<- Vname
          }
          else{
            Tmp<- paste(Vname,"[", as.character(K),"]",sep="")
          }
          if(mode(Val[K])=="numeric"){
            Tmp1<- paste("(",as.character(Val[K]),")",sep="")
          }
          else{
            Tmp1<- Val[K]
          }
          Fnstr<- Replace(Tmp,Tmp1,Fnstr)#180615
        }
      }
      else{
        for (J in Looprange(1,Nrow(Val))){
          for (K in Looprange(1,Ncol(Val))){
            Tmp<- paste(Vname,"(",as.character(J),",",as.character(K),")",sep="")
            if(mode(Val[J,K])=="numeric"){
              Tmp1<- paste("(",as.character(Val[J,K]),")",sep="")
            }
            else{
              Tmp1<- Val[J,K]
            }
            Fnstr<- Replace(Tmp,Tmp1,Fnstr)#180615
          }
        }
      }
      if(length(Val)==1){
        Rep<- as.character(Val)
      }
      else{
        Rep<-""
        if(class(Val)=="matrix"){
          Rep<- "matrix("
        }
        Rep<- paste(Rep,"c(",sep="")
        for (J in Looprange(1,length(Val))){
          Rep<- paste(Rep,as.character(Val[J]),sep="")
          if(J<length(Val)){
            Rep<- paste(Rep,",",sep="")
          }
          else{
            Rep<- paste(Rep,")",sep="")
          }
        }
        if(class(Val)=="matrix"){
          Rep<- paste(Rep,",nrow=",as.character(nrow(Val)),")",sep="")
        }
      }
      Tmp1<- paste("(",Rep,")",sep="")
    }
    if(mode(Val)=="character"){
      Tmp1<- Val
    }
    if(mode(Val)=="list"){
      Tmp1<- Makeliststr(Val)
    }
	Fnstr<- Replace(Vname,Tmp1,Fnstr) #180615
  }
  return(Fnstr)
}

#########################################

Assignadd<- function(...) 
{
  varargin<- list(...)
  L<- ASSIGNLIST
  L<- Mixjoin(L,varargin)
  ASSIGNLIST<<- L
#  return("assign add done"); #17.09.17
}

#########################################

Assignrep<- function(...)
{
  varargin<- list(...)
  Nargs<- length(varargin)
  L<-  ASSIGNLIST
  for (I in seq(1,Nargs,by=2)){
    Vname<- varargin[[I]]
    Val<- varargin[[I+1]]
    Tmp1<- paste("?",Vname,sep="")
    Tmp<- Assign(Tmp)
    if(mode(Tmp)=="character"){
      next
    }
    I<- Tmp[[1]]
    L<- Mixjoin(L,list(Val))
  }
   ASSIGNLIST<<- L
}

#########################################

 Assignset<- function(...)
{
  Assign(...)
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
  if(ul!=""){
    ULEN<<-ul;
  }
  Is<-1;
  VL<-"";
  Ucode<-ULEN
  for (I in Looprange(1,nchar(Ucode))){
    C<-substring(Ucode,I,I);
    if(length(grep(C,SL))>0){
      if(length(grep(C,OL))>0){
        Tmp<-substring(Ucode,Is,I-1);
        Str<-paste(VL,Tmp,C,sep="")
        VL<-Str
        Is<-I+1;
      }
    }
    else{
      Unit<-substring(Ucode,I,I+1)
      Str<-substring(Ucode,Is,I-1)
      VL<-paste(VL,Str,sep="")
      break;
    }
  }
  Valu<-eval(parse(text=VL))
  Str<-as.character(Valu);
  ULEN<<- paste(Str,Unit,sep="")
  if(Unit=="cm") MilliIn<<-1000/2.54*Valu
  if(Unit=="mm") MilliIn<<-1000/2.54*Valu/10
  if(Unit=="in") MilliIn<<-1000*Valu
  if(Unit=="pt") MilliIn<<-1000/72.27*Valu
  if(Unit=="pc") MilliIn<<-1000/6.022*Valu 
  if(Unit=="bp") MilliIn<<-1000/72*Valu
  if(Unit=="dd2") MilliIn<<-1000/1238/1157/72.27*Valu
  if(Unit=="cc") MilliIn<<-1000/1238/1157/72.27*12*Valu;
  if(Unit=="sp") MilliIn<<-1000/72.27/65536*Valu/10
  MARKLEN<<- MARKLENNow*1000/2.54/MilliIn;
  Str<-paste("{\\unitlength=",ULEN,"%\n",sep="")
  cat(Str,file=Wfile,append=TRUE)
  cat("\\begin{picture}%\n",file=Wfile,append=TRUE)
  Str<-"("
  Tmp<-as.character(round(Dx,digits=6))
  Str<-paste(Str,Tmp,",",sep="")
  Tmp<-as.character(round(Dy,digits=6))
  Str<-paste(Str,Tmp,")(",sep="")
  Tmp<-as.character(round(Xm,digits=6))
  Str<-paste(Str,Tmp,",",sep="")
  Tmp<-as.character(round(Ym,digits=6))
  Str<-paste(Str,Tmp,")%\n",sep="")
  cat(Str,file=Wfile,append=TRUE)
  Str<-paste("\\special{pn ",as.character(PenThickInit),"}%\n",sep="")
  cat(Str,file=Wfile,append=TRUE)
  cat("%\n",file=Wfile,append=TRUE)
}

#################################################

Bowdata<- function(...)  #17.09.17
{       
 varargin <- list(...) 
 Nargs <- length(varargin)
 PA <- varargin[[1]]
 PB <- varargin[[2]]
 Cut <- 0
 D <- 1/2*Norm(PB-PA)  
 if(Nargs>=3) {
   H <- varargin[[3]]*D*0.2 
 }
 else {
   H <- D*0.2
 }
 H <- min(H,D)
 if(Nargs>=4){  
   Cut <- varargin[[4]]
 }
 Ydata <- MakeBowdata(PA,PB,H) 
 C <- Op(1,Ydata)  
 r <- Op(2,Ydata)  
 R1 <- Op(3,Ydata)  
 R2 <- Op(4,Ydata)  
 Rng <- paste("R=c(",as.character(R1),",",as.character(R2),")",sep="")  
 Theta <- (R1+R2)*0.5
 BOWMIDDLE <<- list(c(C[1]+r*cos(Theta),C[2]+r*sin(Theta)),Theta)  
 M <- Op(1,BOWMIDDLE)  
 ThetaM <- Op(2,BOWMIDDLE)  
 BOWSTART <<- PA  
 BOWEND <<- PB
 if(Cut==0){
   Pd<- Circledata(c(C,r),Rng)
 }
 else{
   Alpha <- R1; Beta <- ThetaM-Cut/(2*r)
   Rng <- paste("Rng=c(",as.character(Alpha),",",as.character(Beta),")",sep="") 
   Pd <- Circledata(c(C,r),Rng)
   Alpha <- ThetaM+Cut/(2*r); Beta <- R2
   Rng <- paste("R=c(",as.character(Alpha),",",as.character(Beta),")",sep="")  
   Tmp <- Circledata(c(C,r),Rng)
   Pd <- Appendrow(Pd,c(Inf,Inf),Tmp)  
 }
}

Bowmiddle <- function(...)
{
 varargin <- list(...)
 Nargs <- length(varargin)
 if( Nargs==0) {
   M <- BOWMIDDLE
   return(M)   
 }
 if(Nargs==1) {
   Bdata <- varargin[[1]]
   A <- Bdata[1,]  
   Dind <- Dataindex(Bdata)
   Dc <- Nrow(Dind)
   Tmp <- Dind[Dc,2]  
   B <- Bdata[Tmp,]  
   if(Dc==1) {
     Tmp1 <- round(Tmp/2)
   }
   else {
     Tmp1 <- Dind[1,2]  
   }
   D <- Bdata[Tmp1,]  
   B <- B-A
   D <- D-A
   Tmp1 <- B[1]*D[2]-D[1]*B[2]  
   Tmp2 <- (Norm(B)^2*D[2]-B[2]*Norm(D)^2)/2  
   Tmp3 <- -(Norm(B)^2*D[1]-B[1]*Norm(D)^2)/2  
   C <- c(Tmp2,Tmp3)/Tmp1+A
   R <- Norm(C-A)
   B <- B+A
   V <- (A+B)/2-C
   V <- V/Norm(V)
   M <- C+R*V
 }
 else {
   A <- varargin[[1]]; B <- varargin[[2]]
   D <- 1/2*Norm(B-A)
   H <- 0.2*D;
   if(length(varargin)>=3) {
     Tmp <- varargin[[3]]
     H <- Tmp*D*0.2
   }
   H <- min(H,D)
   Ydata <- MakeBowdata(A,B,H)
   C <- Op(1,Ydata)
   R <- Op(2,Ydata)
   T <- (Op(3,Ydata)+Op(4,Ydata))/2
   P <- C+R*c(cos(T),sin(T))  
   #M <- list(P,T)  
   M <- P  
 }
 return(M)
}

##########################
# 13.12.19  small movement supported

Bowname<- function(...)
{
  varargin <- list(...) 
  Nargs <- length(varargin)
  Siki <- varargin[[Nargs]]
  Nargs<- Nargs-1
  Dr<- "c"
  if(Nargs>=1){
    Tmp<- varargin[[Nargs]]
    if(is.character(Tmp)){
      Dr<- Tmp
      Nargs<- Nargs-1
    }
  }
  if(Nargs==0){
   Siki <- varargin[[1]]
   P <- Op(1,BOWMIDDLE)  
 }
 else if(Nargs==1){  
   Bdata <- varargin[[1]]
   P <- Bowmiddle(Bdata)
 }
 else{
   A <- varargin[[1]]; B <- varargin[[2]]
   D <- 1/2*Norm(B-A)  
   Tmp <- varargin[[3]]
   if(is.character(Tmp)){  
     H <- D*0.2
   }
   else {
     H <- Tmp*D*0.2
   }
   H <- min(H,D)
   Ydata <- MakeBowdata(A,B,H)
   Tmp <- Bowmiddle(Ydata)
   P <- Op(1,Tmp)  
 }
 Expr(P,Dr,Siki)
}

##########################
# 13.12.19  small movement supported
#                    A,B, ... no longer supported

Bownamerot <- function(...)
{
 varargin <- list(...)
 Nargs <- length(varargin)
 Eps <- 10^(-6)
 Flg <- 1
 Tmp <- varargin[[Nargs]]
 if(is.numeric(Tmp) && length(Tmp)==1 && Tmp<0){  
   Flg <- Tmp
   Nargs <- Nargs-1
 }
 Siki <- varargin[[Nargs]]
 Nargs<- Nargs-1
 Dr<- "c"
 if(Nargs>=1){
   Tmp<- varargin[[Nargs]]
   if(is.character(Tmp)){
     Dr<- Tmp
     Nargs<- Nargs-1
   }
 }
 if(Nargs==0) {
   P <- Op(1,BOWMIDDLE)
   A <- BOWSTART
   B <- BOWEND
 }
 else{
   Bdata<- varargin[[1]]
   P<- Bowmiddle(Bdata)
   A=Bdata[1,]
   B=Bdata[nrow(Bdata),]
   Tm<- 0; Tv<- 0
   if(Nargs>1){
     Tm<- varargin[[2]]
     if(Nargs>2){
       Tv<- varargin[[3]]
     }
   }
 }
# else if(Nargs==2) {  
#   Bdata <- varargin[[1]]
#  P <- Bowmiddle(Bdata)
#   A <- Bdata[1,]  
#   B <- Bdata[Nrow(Bdata),]  
#   Siki <- varargin[[2]]
# }
# else {
#   A <- varargin[[1]]; B <- varargin[[2]]
#   D <- 1/2*Norm(B-A)  
#   Tmp <- varargin[[3]]
#   if(mode(Tmp)=="character") {  
#     H <- 0.2*D; Siki <- Tmp
#   }
#   else {
#     H <- Tmp*D*0.2; Siki <- varargin[[4]]
#   }
#   H <- min(H,D)
#   Ydata <- MakeBowdata(A,B,H)
#   C <- Op(1,Ydata)
#   R <- Op(2,Ydata)
#   T <- (Op(3,Ydata)+Op(4,Ydata))/2
#   P <- C+R*c(cos(T),sin(T))
# }
 if(A[1]>B[1]+Eps){
   Tmp <- A
   A <- B
   B <- Tmp
 }
 if(Flg>0) {
   Tmp <- B-A
 }
 else{
   Tmp <- A-B
 }
 Exprrot(P,Tmp,Tm,Tv,Siki)
}

CalcHeight<-function(Hoko,Moji)
{
  D<-0
  H<-substring(Hoko,1,1)
  Tmp<-paste("\\settoheight{\\Height}{",Moji,"}",sep="")
  Str<-c(Tmp)
  Tmp=paste("\\settodepth{\\Depth}{",Moji,"}",sep="")
  Str<-c(Str,Tmp)
  if(H=="n") Str<-c(Str,"\\setlength{\\Height}{\\Depth}")
  if(H=="s") Str<-c(Str,"\\setlength{\\Height}{-\\Height}")
  if(H=="c")
  {
    Str<-c(Str,"\\setlength{\\Height}{-0.5\\Height}")
    Str<-c(Str,"\\setlength{\\Depth}{0.5\\Depth}")
    Str<-c(Str,"\\addtolength{\\Height}{\\Depth}")
  }
  for (I in 1:length(Str)) cat(Str[I],file=Wfile,append=TRUE)
  cat("%\n",file=Wfile,append=TRUE)
}

#########################

CalcWidth<-function(Hoko,Moji)
{
  D<-0;
  H<-substring(Hoko,2,2)
  if(H=="e") D<-0 
  if(H=="w") D<--1.0
  if(H=="c") D<--0.5
  Str1<-paste("\\settowidth{\\Width}{",Moji,"}",sep="")
  Tmp<-as.character(D)
  Str2<-paste("\\setlength{\\Width}{",Tmp,"\\Width}",sep="")
  cat(Str1,file=Wfile,append=TRUE)
  cat(Str2,file=Wfile,append=TRUE)
  cat("%\n",file=Wfile,append=TRUE)
}

#########################
# 17.09.17
# 17.09.24

Circledata<- function(...){
  varargin<- list(...)
  Nargs<- length(varargin)
  Cr<- varargin[[1]]
  C=Cr[1:2]
  if(length(Cr)==4){
    ra=Norm(C-Cr[3:4])
    Nop=2
  }
  else{
    ra=Cr[3]
    Nop=2
  }
  R=c(0,2*pi)
  N=50
  for (I in Looprange(Nop,Nargs)){
    Tmp<- varargin[[I]]
    if(is.character(Tmp)){
      Tmp1=regexpr("=",Tmp)  #17.09.24from
      Tmp2=substring(Tmp,Tmp1+1,nchar(Tmp))
      Tmp1=substring(Tmp,1,Tmp1)
      Tmp1=gsub("NUM", "N", toupper(Tmp1))
      Tmp1=gsub("RNG", "R", Tmp1)
      Tmp=paste(Tmp1,Tmp2,sep="") #17.09.24until
      eval(parse(text=Tmp))
    }
  }
  Dt<- (R[2]-R[1])/N
  T <- seq(R[1],R[2],by=Dt) 
  X <- C[1]+ra*cos(T)
  Y <- C[2]+ra*sin(T)
  XY<- c(X,Y)
  P<- matrix(XY,ncol=2)
  return(P) 
}

#########################
# 13.12.19

Closefile<-function(...)
{
  varargin<- list(...)
  if(length(varargin)>=1){
    Pa<- varargin[[1]]
    if(is.character(Pa)){
      if(Pa=="1") Endpicture(1)
      if(Pa=="0") Endpicture(0)
    }
  }
  Wfile<<-""
}

#########################

Closepar<- function()
{
  S<- "%\n\\end{minipage}"
  cat(S,file=Wfile,append=TRUE)
  Closephr()
}


####################################

Closephr<- function()
{
  cat("%\n}%\n",file=Wfile,append=TRUE)
}

#####################################

Dataindex<-function(P)
{
  #  Inf;Inf : Terminator
  Ndm<-c()
  if(length(P)==0) return(Ndm)
  N1<-1
  Flg<-0
  for (J in 1:Nrow(P))
  {
    if(P[J,1]==Inf)
    {
      Ndm<-Appendrow(Ndm,c(N1,J-1))
      N1<-J+1;
      if(P[N1,1]==Inf)
      {
        Flg<-1;
        break;
      }
    }
  }
  if(Flg==0)
  {
    Ndm<-Appendrow(Ndm,c(N1,Nrow(P)))
  }
  if(class(Ndm)=="numeric")
  {
    Tmp<-matrix(Ndm,nrow=1)
    Ndm<- Tmp
  }
  return(Ndm)
}

################################

Dashline<- function(...)
{
  varargin<- list(...)
  Nargs<- length(varargin)
  Nall<- Nargs; Sen<- 1 ; Gap<- 1
  Tmp<- varargin[[Nall]]
  if(mode(Tmp)=="numeric" && length(Tmp)==1 && Tmp>0){
    Tmp1<- varargin[[Nall-1]]
    if(mode(Tmp1)=="numeric" && length(Tmp1)==1 && Tmp1>0){
      Sen<- Tmp1; Gap<- Tmp
      Nall<- Nall-2
    }
    else{
       Sen<- Tmp; Gap<- Sen
       Nall<- Nall-1
    }
  }
  Sen<- 1000/2.54/MilliIn*Sen
  Gap<- 1000/2.54/MilliIn*Gap
  for (N in Looprange(1,Nall)){
    Pdata<- varargin[[N]]
    if(is.numeric(Pdata)==1){
      Pdata<- list(Pdata)
    }
    for (II in 1:length(Pdata)){
      Figdata<- Op(II,Pdata)
      Makehasen(Figdata,Sen,Gap,0)
    }
  }
}

##############################################
#  17.11.27

Definecolor<- function(Name,Data){
  Tmp1=length(Data)
  if((Tmp1<3) || (Tmp1>4)){
    cat("Size of data should be 3 or 4.")
    return()
  }
  if(Tmp1==4){
    Tp="cmyk"
  }else{
    Tp="rgb"
  }
  Tmp=""
  for(J in 1:Tmp1){
    Tmp=paste(Tmp, as.character(Data[J]),sep="")
    if(J<Tmp1){
      Tmp=paste(Tmp,",",sep="")
    }
  }
  Tmp=paste("\\definecolor{",Name,"}{",Tp,"}{",Tmp,"}",sep="")
  Texcom(Tmp)
}

##############################################

Diagcelldata<- function(Tb,Nc,Nr)
{
  Tmp<- Findcell(Tb,Nc,Nr)
  C<- Tmp[[1]]
  Dx<- Tmp[[2]]
  Dy<- Tmp[[3]]
  Pne<- C+c(Dx,Dy)
  Pnw<- C+c(-Dx,Dy)
  Psw<- C+c(-Dx,-Dy)
  Pse<- C+c(Dx,-Dy)
  Tmp1<- Listplot(Pnw,Pse)
  Tmp2<- Listplot(Pne,Psw)
  list(Tmp1,Tmp2)
}

##############################################
# 11.01.07

Dividegraphics<- function(Pd)
{
  if(length(Pd)==0){
    return(Pd)
  }
  DtL<- Flattenlist(Pd)
  OutL<- list()
  for (J in 1:length(DtL)){
    Dt<- as.matrix(DtL[[J]])
    Ndm<- Dataindex(Dt)    
    for (I in Looprange(1,Nrow(Ndm))){
      Fd<- Dt[Ndm[I,1]:Ndm[I,2],]
      OutL<- c(OutL,list(Fd))
    }
  }
  return(OutL)
}

##############################################
# 13.05.03

Dividetable<- function(Tb)
{
  G<- Tb[[1]]
  Gw<- G[[1]]
  Gt<- G[Tb[[2]]]
  Gy<- G[Tb[[3]]]
  list(Gw,Gt,Gy)
}

################################################

Doscaling<- function(G)
{
  GLg<- G
  if(class(GLg)=="numeric")
  {
    if(LOGX==1) GLg[1]<- log(G[1], base=10)
    if(LOGY==1) GLg[2]<- log(G[2], base=10)
    Tmp<-c(SCALEX*GLg[1],SCALEY*GLg[2])
    return(Tmp)
  }
  else
  {
    if(LOGX==1) GLg[,1]<- log(G[,1],base=10)
    if(LOGY==1) GLg[,2]<- log(G[,2],base=10)
    Tmp1<-matrix(c(SCALEX,0,0,SCALEY),nrow=2)
    Tmp<-GLg %*% Tmp1
    return(Tmp)
  }
}

########################################

Dotfilldata<- function(...)
{     ## Scaling is implemented
  varargin<- list(...)
  Nargs<- length(varargin)
  ShaL<- list()
  Eps<- 0.01
  Kakudo<- 45
  Kosa<- 0.5
  Tmp<- Doscaling(c(XMIN,YMIN))
  Xmn<- Tmp[1]; Ymn<- Tmp[2]
  Tmp<- Doscaling(c(XMAX,YMAX))
  Xmx<- Tmp[1]; Ymx<- Tmp[2]
  for (N in seq(Nargs,1,by=-1)){
    Tmp<- varargin[[N]]
    if(Mixtype(Tmp)!=1){
      break
    }
  }
  if(N<Nargs){
    Kosa<- varargin[[N+1]]
  }
#  Kosa<- min(Kosa,1)
  Tmp<- 1/(2*Kosa)
  Kankaku<- Tmp*0.100*1000/2.54/MilliIn
  NaitenL<- varargin[[1]]
  if(Mixtype(NaitenL)==1){
    NaitenL<- list(NaitenL)
  }
  Ns<- 2
  StartP<- Op(1,NaitenL)
  if(mode(StartP)=="character"){
    StartP<- c((Xmn+Xmx)/2,(Ymn+Ymx)/2)
  }
  else{
    StartP<- Doscaling(StartP)
  }
  Tmp<- varargin[[2]]
  if(Mixtype(Tmp)==1){
    StartP<- Doscaling(Tmp)
    Ns<- 3
  }
  Tmp<- list()
  for (I in Looprange(Ns,N)){
    Tmp<- Mixjoin(Tmp,list(varargin[[I]]))
  }
  Bdy<- Kyoukai(Tmp)
  Bdys<-list()
  for (I in 1:length(Bdy)){
    Tmp1<- Bdy[[I]]
    Tmp2<- Doscaling(Tmp1)
    Bdys<- Mixjoin(Bdys,list(Tmp2))
  }
  Bdy<- Bdys
  PtnL<- list()
  for (I in Looprange(1,length(NaitenL))){
    Tmp<- Op(I,NaitenL)
    if(mode(Tmp)=="numeric"){
      Tmp1<- Naigai(Tmp,Bdy)
      PtnL<- Mixjoin(PtnL,list(Tmp1))
    }
    else{
      if(mode(Tmp)!="character"){
        return("Mode Error")
      }
      Ptn<- c()
      for (J in Looprange(1,nchar(Tmp))){
        if(substr(Tmp,J,J)=="i"){
          Ptn<- c(Ptn,1)
        }
        else{
          Ptn<- c(Ptn,0)
        }
      }
      PtnL<- Mixjoin(PtnL,list(Ptn))
    }
  }
  Call<- length(Bdy)
  Ptn<- c(seq(0, 0, length=Call))
  if(Member(Ptn,PtnL)){
    Wn<- Doscaling(Framedata())
    Bdy<- Mixjoin(Bdy,list(Wn))
    Tmp<- list()
    for (I in Looprange(1,length(PtnL))){
      Tmp1<- c(Op(I,PtnL),1)
      Tmp<- Mixjoin(Tmp,list(Tmp1))
    }
    PtnL<- Tmp
  }
  V<- c(cos(Kakudo*pi/180),sin(Kakudo*pi/180))
  Vm<- c(-sin(Kakudo*pi/180),cos(Kakudo*pi/180))
  Tmp<- Op(1,NaitenL)
  if(mode(Tmp)=="numeric" && length(Tmp)==2){
    Tmp<- Doscaling(Tmp)
    Delta<- Tmp-StartP
    K<- trunc(Dotprod(Delta,Vm)/Kankaku)
    PA<- StartP+K*Kankaku*Vm
    P<- PA
    Sha<- Makeshasen(PtnL,P,V,Bdy)
    Sha<- Dividegraphics(Sha)
    I<- 1
    while (length(Sha)>0){
      for (J in Looprange(1,length(Sha))){
        Tmp<- Op(J,Sha)
        Q<- Tmp[1,]
        R<- Tmp[2,]
        Tmp<- Dotprod(Q-P,V)/Kankaku
        K1<- ceiling(Tmp)
        if(abs(K1-Tmp)<Eps) K1=K1+1
        Tmp<- Dotprod(R-P,V)/Kankaku
        K2<- floor(Tmp)
        if(abs(Tmp-K2)<Eps) K2=K2-1
        for (K in Looprange(K1,K2)){
          Tmp1<- Pointdata(P+K*Kankaku*V)
          ShaL<- Mixjoin(ShaL, list(Tmp1))
        }
      }
      P<- PA+I*Kankaku*Vm
      Sha<- Makeshasen(PtnL,P,V,Bdy)
      Sha<- Dividegraphics(Sha)
      I<- I+1
    }
    P<- PA-Kankaku*Vm
    Sha<- Makeshasen(PtnL,P,V,Bdy)
    I<- 2
    while (length(Sha)>0){
      for (J in 1:length(Sha)){
        Tmp<- Op(J,Sha)
        Q<- Tmp[1,]
        R<- Tmp[2,]
        Tmp<- Dotprod(Q-P,V)/Kankaku
        K1<- ceiling(Tmp)
        if(abs(K1-Tmp)<Eps) K1<- K1+1
        Tmp<- Dotprod(R-P,V)/Kankaku
        K2<- floor(Tmp)
        if(abs(Tmp-K2)<Eps) K2<- K2-1
        for (K in Looprange(K1,K2)){  
          Tmp1<- Pointdata(P+K*Kankaku*V)
          ShaL<- Mixjoin(ShaL, list(Tmp1))
        }
      }
      P<- PA-I*Kankaku*Vm
      Sha<- Makeshasen(PtnL,P,V,Bdy)
      I<- I+1
    }
  }
  else{
    Delta<- c(Xmn,Ymn)-StartP
    K1<- trunc(Dotprod(Delta,Vm)/Kankaku)
    Delta<- c(Xmx,Ymn)-StartP
    K2<- trunc(Dotprod(Delta,Vm)/Kankaku)
    Delta<- c(Xmx,Ymx)-StartP
    K3<- trunc(Dotprod(Delta,Vm)/Kankaku)
    Delta<- c(Xmn,Ymx)-StartP
    K4<- trunc(Dotprod(Delta,Vm)/Kankaku)
    IM<- max(K1,K2,K3,K4)
    Im<- min(K1,K2,K3,K4)
    for (I in Im:IM){
      P<- StartP+I*Kankaku*Vm
      Sha<- Makeshasen(PtnL,P,V,Bdy)
      Sha<- Dividegraphics(Sha)
      if(length(Sha)>0){
        for (J in 1:length(Sha)){
          Tmp<- Op(J,Sha)
          Q<- Tmp[1,]
          R<- Tmp[2,]
          Tmp<- Dotprod(Q-P,V)/Kankaku
          K1<- ceiling(Tmp)
          if(abs(K1-Tmp)<Eps) K1=K1+1
          Tmp<- Dotprod(R-P,V)/Kankaku
          K2<- floor(Tmp)
          if(abs(Tmp-K2)<Eps) K2=K2-1
          for (K in Looprange(K1,K2)){
            Tmp1<- Pointdata(P+K*Kankaku*V)
            ShaL<- Mixjoin(ShaL, list(Tmp1))
          }
        }
      }
    }
  }
  ShaLs<-list()
  for (I in Looprange(1,length(ShaL)))
  {
    Tmp<- ShaL[[I]]
    Tmp1<- Unscaling(Tmp)
    ShaLs<- Mixjoin(ShaLs,Tmp1)
  }
  ShaL<- ShaLs
  return(ShaL)
}

#############################################

Dottedline<- function(...)
{
  varargin <- list(...)     
  Nall <- length(varargin)
  Nagasa <- 0.1
  Ookisa <- PenThick
  I <- Nall
  Tmp <- varargin[[I]]
  while (mode(Tmp)=="numeric" && length(Tmp)==1 ) {
    I <- I-1
    Tmp <- varargin[[I]]
  }
  if(I==Nall-1) {
    Nagasa<-Nagasa*varargin[[Nall]]
    Nall <- Nall-1
  }
  if(I==Nall-2) {
    Nagasa <- Nagasa*varargin[[Nall-1]]
    Ookisa <- round(Ookisa*varargin[[Nall]])
    Nall <- Nall-2
  }
  Nagasa <- 1000/2.54/MilliIn*Nagasa
  for (N in 1:Nall) {
    Pdata <- varargin[[N]]
    if(mode(Pdata)=="numeric") {
      Pdata <- list(Pdata)             
    }
    for (II in 1:length(Pdata)) {  
      Clist <- MakeCurves(Op(II,Pdata))
      DinM <- Dataindex(Clist)
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
        if(Lenall==0) {
          next
        }
        Naga <- Nagasa
        Nten <- round(Lenall/Naga)+1
        if(Nten > 1) {
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
          if(I>0) {
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
          if(I==Nten-1) {
            if(Norm(P-Data[1,])<Eps) {         
              next
            }
          } 
        }
        Str<-paste("\\special{pn ", as.character(Ookisa),"}%\n",sep="")
        cat(Str,file=Wfile,append=TRUE)
        for (I in Looprange(1,Nrow(PPd))){
          P<- Op(I,PPd)
          if(Nrow(PPd)==1){
            V<- c(1,0)
          }
          else if(I==1){
            Tmp<- Op(I+1,PPd)-P
            V<- 1/Norm(Tmp)*Tmp
          }
          else if(I==Nrow(PPd)){
            Tmp<- P-Op(I-1,PPd)
            V<- 1/Norm(Tmp)*Tmp
          }
          else{
            Tmp1<- Op(I+1,PPd)-P
            Tmp2<- P-Op(I-1,PPd)
            Tmp3<-1/Norm(Tmp1)*Tmp1+1/Norm(Tmp2)*Tmp2
            V<- 1/Norm(Tmp3)*Tmp3
          }
          Tmp<- round(MilliIn*P[1]-1/2*Ookisa*V[1])
          X<- as.character(Tmp)
          Tmp<- -round(MilliIn*P[2]-1/2*Ookisa*V[2])
          Y<- as.character(Tmp)
          Str<-paste("\\special{pa ",X," ",Y,"}",sep="")
          cat(Str,file=Wfile,append=TRUE)
          Tmp<- round(MilliIn*P[1]+1/2*Ookisa*V[1])
          X<- as.character(Tmp)
          Tmp<- -round(MilliIn*P[2]+1/2*Ookisa*V[2])
          Y<- as.character(Tmp)
          Str<-paste("\\special{pa ",X," ",Y,"}",sep="")
          cat(Str,file=Wfile,append=TRUE)
          cat("\\special{fp}",file=Wfile,append=TRUE)
          if(I%%2==0){
            cat("%\n",file=Wfile,append=TRUE)
          }
        }
      }
    }
  }
  Tmp<-PenThick/PenThickInit
  Setpen(Tmp);
}

###########################################

Drwline<-function(...)
{
  varargin<-list(...)
  Nall<-length(varargin)
  Thick<-0
  Tmp<-varargin[[Nall]]
  if(mode(Tmp)=="numeric" && length(Tmp)==1){
    Thick<-round(Tmp*PenThickInit)
    Str<-paste("\\special{pn ", as.character(Thick),"}%\n",sep="")
    cat(Str,file=Wfile,append=TRUE)
    Nall<-Nall-1
  }
  for (N in 1:Nall){
    Pdata<-varargin[[N]]
    if(length(Pdata)==0) next
    if(mode(Pdata)!="list") Pdata<-list(Pdata)
    while(Mixtype(Pdata)==3){         # 10.07.25
      Tmp1<- list()
      for(II in Looprange(1,length(Pdata))){
        Tmp1<- Mixjoin(Tmp1,Pdata[[II]])
      }
      Pdata<- Tmp1
    }                                  # 10.07.25
    for (II in Looprange(1,length(Pdata))){
      Clist<-MakeCurves(Pdata[[II]])
      DinM<-Dataindex(Clist)
      for (n in Looprange(1,Nrow(DinM))){
        Tmp<-DinM[n,]
        Data<-Clist[Tmp[1]:Tmp[2],]
        Mojisu<-0
        for (I in Looprange(1,Nrow(Data))){
          Tmp<-Data[I,]
          X<- sprintf("%5.0f",MilliIn*Tmp[1])   # 11.07.19
          Y<- sprintf("%5.0f",-MilliIn*Tmp[2])   # 11.07.19
          Str<-paste("\\special{pa ",X," ",Y,"}",sep="")
          cat(Str,file=Wfile,append=TRUE)
          Mojisu<-Mojisu+nchar(Str)
          if(Mojisu>80){
            cat("%\n",file=Wfile,append=TRUE)
            Mojisu<-0
          }
        }
        if(Mojisu!=0){
           cat("%\n",file=Wfile,append=TRUE)
        }
        cat("\\special{fp}%\n",file=Wfile,append=TRUE)
      }
    }
  }
  Str<-"%"
  if(Thick>0){
    Tmp<-PenThick/PenThickInit
    Setpen(Tmp)
  }
}

###########################################

Drwpt<-function(...){
  varargin<-list(...)
  Nargs<-length(varargin)
  if(TenSize>TenSizeInit){
    N=round(10*sqrt(TenSize/TenSizeInit)) #181231
  }
  else{
    if(TenSize==TenSizeInit){  #181231from
      N=10
    }else{
      N=4
    }  #181231to
  }
  All=Nargs  #181230from
  Same="y"
  Incolor=""
  Tmp=varargin[[All]]
  if(is.numeric(Tmp)){
    if(length(Tmp)==3){Tmp=c(Tmp,1)} #181231
    if(length(Tmp)==4){
      if(Tmp[4]<0){  #181231from
        Same="nn"
      }else{
        Incolor=paste(" ",as.character(Tmp[4]),sep="")
      }  #181231to
    }else{
      Same="n"
      Incolor="{"
      for(J in 4:6){
        Incolor=paste(Incolor,as.character(Tmp[J]),sep="")
        if(J<6){
          Incolor=paste(Incolor,",",sep="")
        }
      }
      Incolor=paste(Incolor,"}",sep="")
    }
    All=Nargs-1 
  }#181230to
  CL<- c()
  for (J in 0:N){
    Tmp<- TenSize*0.5*1000/2.54/MilliIn
    Tmp<- Tmp*c(cos(pi/4+J*2*pi/N),sin(pi/4+J*2*pi/N))
    CL<- append(CL,Tmp)
  }
  CL<- matrix(CL,nrow=2)
  CL<- t(CL)
  for (II in Looprange(1,All)){
    MS<- varargin[[II]]
    MS=Flattenlist(MS) #17.10.11
    if(mode(MS)=="numeric"){
      MS<- list(MS)
    }
    for (I in Looprange(1,length(MS))){
      P<- MS[[I]]
      if(InWindow(P)!="i") next
      P<- Doscaling(P)
      PL<-c()
      for (J in 0:N){
        PL<- c(PL,P+CL[J+1,])
      }
      PL<- matrix(PL,nrow=2)
      PL<- t(PL)
      if(Same=="n"){ #181230from
        Str1<- paste("{\\special{pn 0}\\color[rgb]",Incolor,"%\n",sep="")
        cat(Str1,file=Wfile,append=TRUE)
        Mojisu<-0
        for (J in 1:Nrow(PL)){
          Q<- PL[J,]
          X<- as.character(round(MilliIn*Q[1]))
          Y<- as.character(-round(MilliIn*Q[2]))
          Str<- paste("\\special{pa ",X," ",Y,"}",sep="")
          cat(Str,file=Wfile,append=TRUE)
          Mojisu<- Mojisu+nchar(Str)
          if(Mojisu>80){
            cat("#\n",file=Wfile,append=TRUE)
          }
          Mojisu=0
        }
        Str1<- paste("\\special{sh}\\special{fp}}%\n",sep="")
        cat(Str1,file=Wfile,append=TRUE)
      }
      cat("\\special{pn 4}",file=Wfile,append=TRUE) #181231
      Mojisu=0
      for (J in 1:Nrow(PL)){
        Q<- PL[J,]
        X<- as.character(round(MilliIn*Q[1]))
        Y<- as.character(-round(MilliIn*Q[2]))
        Str<- paste("\\special{pa ",X," ",Y,"}",sep="")
        cat(Str,file=Wfile,append=TRUE)
        Mojisu<- Mojisu+nchar(Str)
        if(Mojisu>80){
          cat("#\n",file=Wfile,append=TRUE)
        }
        Mojisu=0
      }
      if(Same=="y"){
        Str1<- paste("\\special{sh",Incolor,"}\\special{fp}%\n",sep="")
      }else{
        Str1<- paste("\\special{fp}%\n",sep="")
      }
      cat(Str1,file=Wfile,append=TRUE) #181230to
    }
  }
}

######################################################

Drwxy<-function(...){ #180820
  varargin<-list(...)
  Nargs <- length(varargin)
  Origin=GENTEN
  Origins=Doscaling(Origin) #181016
  Xrng=c(XMIN,XMAX)
  Yrng=c(YMIN,YMAX)
  Tmp1=Doscaling(c(XMIN,YMIN)) #181017from
  Tmp2=Doscaling(c(XMAX,YMAX))
  Xrngs=c(Tmp1[1],Tmp2[1])
  Yrngs=c(Tmp1[2],Tmp2[2]) #181017from
  Ziku=ZIKU #180821from
  Xname=XNAME
  Xpos=XPOS
  Yname=YNAME
  Ypois=YPOS
  Oname=ONAME
  Opos=OPOS #180821to
  for(J in Looprange(1,Nargs)){
    Tmp=strsplit(varargin[[J]],"=")
    Tmp=Tmp[[1]]
    Tmp1=toupper(substring(Tmp[1],1,1))
    Tmp2=Tmp[2]
    if(Tmp1=="O"){
      Origin=eval(parse(text=Tmp2))
    }
    if(Tmp1=="X"){
      Xrng=eval(parse(text=Tmp2))
    }
    if(Tmp1=="Y"){
      Yrng=eval(parse(text=Tmp2))
    }
    if(Tmp1=="A"){ #180821from
      if(substring(Tmp2,1,1)=="c"){
        Tmp2=substring(Tmp2,3,nchar(Tmp2)-1)
      }
      Tmp2=gsub(",","','",Tmp2,fixed=TRUE)
      Tmp2=paste("'",Tmp2,"'",sep="")
      Tmp=paste("Setax(",Tmp2,")",sep="")
      eval(parse(text=Tmp)) #180821to
    }
  }
  Xrng=Xrng+Origin[1]
  Yrng=Yrng+Origin[2]
  Xrngs=Xrngs+Origins[1] #181016(2lines)
  Yrngs=Yrngs+Origins[2]
  Tmp<- substring(ZIKU,1,1) #180821
  if(Tmp=="a")
  {
    Tmp=substring(ZIKU,2,nchar(ZIKU))
    if(nchar(Tmp)==0){Tmp=1}else{Tmp=eval(parse(text=Tmp))}
    Arrowline(c(Xrngs[1],Origins[2]),c(Xrngs[2],Origins[2]),Tmp)#181016(2lines)
    Arrowline(c(Origins[1],Yrngs[1]),c(Origins[1],Yrngs[2]),Tmp)
  }
  else
  {
    Drwline(Listplot(c(Xrngs[1],Origins[2]),c(Xrngs[2],Origins[2])))#181016(2lines)
    Drwline(Listplot(c(Origins[1],Yrngs[1]),c(Origins[1],Yrngs[2])))
  }
  Letter(c(Xrng[2],Origin[2]),XPOS,XNAME)
  Letter(c(Origin[1],Yrng[2]),YPOS,YNAME)
  Letter(Origin,OPOS,ONAME)
  Setax(Ziku,Xname,Xpos,Yname,Ypois,Oname,Opos) #180821
}

##########################################
# 10.12.04

Enclosing<- function(...)
{
  Eps=10^(-7) # Scilab 16.12.05
  varargin<- list(...)
  Nargs<- length(varargin)
  P<- varargin[[1]]
  if(Mixtype(P)==2){
    Tmp<- Op(1,P)
    if(mode(Tmp)!="numeric" || length(Tmp)>1){
      AnsL<- EnclosingS(...)
	  AnsL<- Joincrvs(AnsL)  # 10.12.04
    }
  }
  Tmp1=Op(1,AnsL) # Scilab 16.12.05from
  Tmp2=Op(nrow(AnsL),AnsL)
  if(Norm(Tmp2-Tmp1)>Eps){
    AnsL=Appendrow(AnsL,Tmp1)
  }
  return(AnsL)
}

#########################################

EnclosingS<- function(...)
{
  varargin<- list(...)
  Nargs<- length(varargin)
  AnsL<- list()
  PdataL<- varargin[[1]]
  Nall<-length(PdataL)
  Eps<- 10^(-3)
  EEps<- 0.1
  S<- c()
  Flg<- 0
  for (I in Looprange(2,Nargs)){
    Tmp<- varargin[[I]]
    if(mode(Tmp)=="numeric" && Nrow(Tmp)==1 && length(Tmp)>1){
      S<- Tmp
    }
    if(mode(Tmp)=="numeric" && length(Tmp)==1){
      if(Flg==0){
        Eps<- Tmp
        Flg=Flg+1
      }
      else{
        EEps<- Tmp
      }
    }
  }
  F<- Op(1,PdataL); G<- Op(Nall,PdataL)
  KL<- IntersectcrvsPp(F,G)
  if(length(KL)==1){
    Tmp<- Op(1,KL)
    P<- Op(1,Tmp)
    T1<- Op(2,Tmp)
  }
  if(length(KL)==0){
    if(Numptcrv(F)>Numptcrv(G)){
      Tmp<- Nearestpt(F,G)
      P<- Op(1,Tmp)
      T1=Op(2,Tmp)
    }
    else{
      Tmp<- Nearestpt(G,F)
      P<- Op(3,Tmp)
      T1<- Op(4,Tmp)
    }
  }
  if(length(KL)>=2){
    if(length(S)==0){
      return("No Start Point")
    }
    Tmp<- Op(1,KL)
    P<- Op(1,Tmp)
    T1<- Op(2,Tmp)
    Tmp<- Norm(P-S)
    for (I in Looprange(2,length(KL))){
      Tmp1<- Op(1,Op(I,KL))
      Tmp2<- Norm(Tmp1-S)
      if(Tmp2<Tmp){
        P<- Tmp1
        T1<- Op(2,Op(I,KL))
        Tmp<- Tmp2
      }
    }
  }
  S<- P
  AnsL<- list()
  for (N in Looprange(1,Nall)){
    F<- Op(N,PdataL)
    if(N>1) P<- Q 
    if(N==Nall){
      Q=S
    }
    else{
      Flg<- 0
      G<- Op(N+1,PdataL)
      KL<- IntersectcrvsPp(G,F)
      if(length(KL)==1){
        Tmp<- Op(1,KL)
        Q<- Op(1,Tmp)
        T3<- Op(2,Tmp)
        Flg<- 10
      }
      if(length(KL)==0) Flg<- 1
      if(length(KL)>=2){ # Maple bug?
        Tmp1<- Op(1,Op(1,KL))
        Tmp2<- Op(1,Op(2,KL))
        Tmp<- Norm(Tmp1-Tmp2)
        if(Tmp<Eps*10) Flg<- 1 
      }
      if(Flg==1){
        if(Numptcrv(F)>Numptcrv(G)){
          Tmp<- Nearestpt(F,G)
          Q<- Op(1,Tmp)
          T3<- Op(4,Tmp)
          Flg<- 10
        }
        else{
          Tmp<- Nearestpt(G,F)
          Q<- Op(3,Tmp)
          T3<- Op(2,Tmp)
          Flg<- 10
        }
      }
      if(Flg<10){
        T2<- Inf
        for (I in Looprange(1,length(KL))){
          Dt<- Op(I,KL)
          Tmp1<- Op(1,Dt)
          Tmp<- Op(3,Dt)
          Tmp2<- Paramoncurve(Tmp1,Tmp,F)
          Tmp3<- Op(2,Dt)
          if(Tmp2>T1+Eps && Tmp2<T2-Eps){
            Q<- Tmp1
            T2<- Tmp2
            T3<- Tmp3
          }
        }
      }
    }
    Tmp<- Partcrv(P,Q,F)
    T1<- T3
    AnsL<- Mixjoin(AnsL,list(Tmp))
  }
  return(AnsL)
}

########################################

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
  cat("\\end{picture}}%",file=Wfile,append=TRUE)
#  MEMORI<<-MEMORINow*1000/2.54/MilliIn
  Setunitlen("1cm")
}

#########################################

Execmd<- function(StrL)
{
  if(mode(StrL)=="character" && length(StrL)==1){
    StrL<- list(StrL)
  }
  for (I in Looprange(1,length(StrL))){
    if(!is.na(Op(I,StrL)) && nchar(Op(I,StrL))>0){
      eval(parse(text=Op(I,StrL)))
    }
  }
}

#########################################

Expr<-function(...)
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
    Mojiretu<-paste("$",varargin[[I+2]],"$",sep="")
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
      if(length(grep(Tmp,Suu))>0)
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

##########################################

Exprrot<- function(...)
{
  varargin<- list(...)
  P<- varargin[[1]]
  V<- varargin[[2]]; N<- 3
  P<- Doscaling(P)
  V<- Doscaling(V)
  Tmov<- 0
  Tmp<- varargin[[N]]
  if(mode(Tmp)=="numeric"){
    Tmov<- Tmp; N<- N+1
  }
  Nmov<- 0
  Tmp<- varargin[[N]]
  if(mode(Tmp)=="numeric"){
    Nmov<- Tmp; N<- N+1
  }
  Mojiretu<- paste("$",Assign(varargin[[N]]),"$",sep="") # 2017.11.26
  Tv<- 1/Norm(V)*V
  Nv<- c(-Tv[2],Tv[1])
  P<- P+MEMORI*Tmov*Tv+MEMORI*Nmov*Nv
  Tmp<- acos(V[1]/Norm(V))
  Theta<- round(Tmp*180/pi)
  if(V[2]>=0){
    Units<- ""
  }
  else{
    Units<- "units=-360,"
  }
  Tmp<- paste("\\rotatebox[",Units,"origin=c]{",as.character(Theta),sep="")
  Tmp<- paste(Tmp,"}{",Mojiretu,"}",sep="")
  Letter(P,"c",Tmp)
}

######################################################

Findcell<- function(...)
{
  varargin<- list(...)
  Nargs<- length(varargin)
  TbL<- varargin[[1]]
  Ag<- varargin[[2]]
  Alpha<- "-ABCDEFGHIJKLMNOPQRSTUVWXYZ"
  if(mode(Ag)=="character"){
    Clm<- c()
    Rstr<- ""
    for (I in Looprange(1,nchar(Ag))){
      C<- substr(Ag,I,I)
      C<- toupper(C) 
      Tmp<- strsplit(Alpha,C)
      Tmp<- Tmp[[1]]
      if(length(Tmp)>1){
        Tmp1<- nchar(Tmp[1])
        Clm<- c(Clm,Tmp1)
      }
      else{
        Rstr<- paste(Rstr,C,sep="")
      }
    }
    Nrg<- 0
    for (I in seq(length(Clm),1,by=-1)){
      Tmp<- Clm[I]
      Tmp1<- length(Clm)-I
      Nrg<- Nrg+Tmp*26^Tmp1
    }
    Mrg<- eval(parse(text=Rstr))
    if(Nargs>=3){
      Ag<- varargin[[3]]
      Clm<- c()
      Rstr<- ""
      for (I in Looprange(1,nchar(Ag))){
        C<- substr(Ag,1,1)
        C<- toupper(C)
        Tmp<- strsplit(Alpha,C)
        if(length(Tmp)>1){
          Clm<- c(Clm,Tmp+1)
        }
        else{
          Rstr<- paste(Rstr,C,sep="")
        }
      }
      Nrg2<- 0
      for (I in seq(length(Clm),1,by=-1)){
        Tmp<- Clm[I]
        Tmp1<- length[Clm]-I
        Nrg2<- Nrg2+Tmp*26^Tmp1
      }
      Nrg<- c(Nrg,Nrg2)
      Tmp=eval(parse(text=Rstr))
      Mrg<- c(Mrg,Tmp)
    }
  }
  else{
    Nrg<- varargin[[2]]
    Mrg<- varargin[[3]]
  }
  if(length(Mrg)==1){
    m1<- Mrg; m2<- m1+1
  }
  else{
    m1<- Mrg[1]; m2<- Mrg[2]  # 10.12.12
  }
  if(length(Nrg)==1){
    n1<- Nrg; n2<- n1+1
  }
  else{
    n1<- Nrg[1]; n2<- Nrg[2]
  }
  n1<- n1+1; n2<- n2+1
  m1<- m1+1; m2<- m2+1
  Hind<- TbL[[2]]
  Vind<- TbL[[3]]
  Tmp<- TbL[[1]]
  HL<- Tmp[Hind]
  Tmp1<- Op(1,TbL[[4]])
  Tmp2<- Op(2,TbL[[4]])
  HL<- Mixjoin(list(Tmp1),HL,list(Tmp2))
  VL<- Tmp[Vind]
  Tmp1<- Op(1,TbL[[5]])
  Tmp2<- Op(2,TbL[[5]])
  VL<- Mixjoin(list(Tmp1),VL,list(Tmp2))
  Tmp<- TbL[[6]]
  Tmp1<- Listplot(c(Ptsw(Tmp),Ptnw(Tmp)))
  Tmp2<- Listplot(c(Ptse(Tmp),Ptne(Tmp)))
  HL<- Mixjoin(list(Tmp1),HL,list(Tmp2))
  Tmp1<- Listplot(c(Ptnw(Tmp),Ptne(Tmp)))
  Tmp2<- Listplot(c(Ptsw(Tmp),Ptse(Tmp)))  
  VL<- Mixjoin(list(Tmp1),VL,list(Tmp2))
  Tmp<- HL[[n1]]
  if(mode(Tmp)=="numeric"){
    H1<- Tmp[1,1]
  }
  else{
    Tmp1<- Tmp[[1]]
    H1<- Tmp1[1,1]
  }
  Tmp<- HL[[n2]]
  if(mode(Tmp)=="numeric"){
    H2<- Tmp[1,1]
  }
  else{
    Tmp1<- Tmp[[1]]
    H2<- Tmp1[1,1]
  }
  Tmp<- VL[[m1]]
  if(mode(Tmp)=="numeric"){
    V1<- Tmp[1,2]
  }
  else{
    Tmp1<- Tmp[[1]]
    V1<- Tmp1[1,2]
  }
  Tmp<- VL[[m2]]
  if(mode(Tmp)=="numeric"){
    V2<- Tmp[1,2]
  }
  else{
    Tmp1<- Tmp[[1]]
    V2<- Tmp1[1,2]
  }
  Pt<- c((H1+H2)/2,(V1+V2)/2)
  High<- (V1-V2)/2
  Wide<- (H2-H1)/2
  Out<- list(Pt,Wide,High)
  return(Out)
}

############################################

Flattenlist<- function(...){
  varargin<- list(...)
  Nargs<- length(varargin)
  Out<- list()
  for(N in Looprange(1,Nargs)){
    D<- varargin[[N]]
    if(is.data.frame(D) || !is.list(D)){  # modify
      Out<- c(Out,list(D))
    }
    else{
      for(I in Looprange(1,length(D))){
        Ds<- D[[I]]
        Tmp<- Flattenlist(Ds)
        Out<- c(Out,Tmp)
      }
    }
  }
  return(Out)
}

############################################

Fontsize<- function(Ookisa)
{
  Str<- "%"
  S<- substr(Ookisa,1,1)
  if(S=="n"){
    Str<- "\\normalsize%"
  }
  if(S=="s"){
    if(nchar(Ookisa)==1){
      Tmp<- "n"
    }
    else{
      Tmp<- substr(Ookisa,2,2)
    }
    if(Tmp=="s"){
      Str<- "\\scriptsize%"
    }
    else{
      Str<- "\\small%"
    }
  }
  if(S=="f"){
    Str<- "\\footnotesize%"
  }
  if(S=="t"){
    Str<- "\\tiny%"
  }
  if(S=="l"){
    Str<- "\\large%"
  }
  if(S=="L"){
    if(nchar(Ookisa)==1){
      Tmp<- "a"
    }
    else{
      Tmp<- substr(Ookisa,2,2)
    }
    if(Tmp=="a"){
      Str<- "\\Large%"
    }
    else{
      Str<- "\\LARGE%"
    }
  }
  if(S=="h"){
    Str<- "\\huge%"
  }
  if(S=="H"){
    Str<- "\\Huge%"
  }
  cat(Str,file=Wfile,append=TRUE)
  cat("\n",file=Wfile,append=TRUE)
}

##########################################

Fracform<- function(...)
{
  varargin<- list(...)
  Eps<- 10^(-10)
  Nmax<- 1/Eps
  Nargs<- length(varargin)
  X<- varargin[[1]]
  Nr<- Nrow(X)
  X<- as.matrix(X,nrow=Nr)
  for (I in Looprange(2,Nargs)){
    Tmp<- varargin[[I]]
    if(mode(Tmp)!="numeric"){
      next
    }
    if(Tmp>1){
      Nmax<- Tmp
    }
    else if(Tmp>0){
      Eps<- Tmp
    }
  }
  Tmp<- rep("",length(X))
  Out<- matrix(Tmp,nrow=nrow(X))
  for (I in Looprange(1,nrow(X))){
    for (J in Looprange(1,ncol(X))){
      Dt<- X[I,J]
      if(mode(Dt)=="character"){
        Dt<- eval(parse(text=Dt))
      }
      R<- 1
      N<- 0
      Rmin<- R
      Nr<- N
      while (R>Eps && N<Nmax){
        N<- N+1
        M<- round(Dt*N)
        R<- abs(Dt-M/N)
        if(R<Rmin){
          Rmin<- R
          Nr<- N
        }
      }
      if(N==Nmax){
        N<- Nr
        M<- round(Dt*N)
      }
      Tmp<- as.character(M)
      if(N!=1){
        Tmp<- paste(Tmp,"/",as.character(N),sep="")
      }
      Out[I,J]<- Tmp
    }
  }
  if(nrow(Out)==1){
    Out<- as.character(Out)
  }
  return(Out)
}

##############################################
#   2011.12.17 ( list )

Framedata<-function(...)
{
  varargin<- Flattenlist(list(...))
  N<-length(varargin)
  if(N<= 1){
    H<- 1.0*10^(-4);
    PA<-c(XMIN+H,YMIN+H)
    PB<-c(XMAX-H,YMIN+H)
    PC<-c(XMAX-H,YMAX-H)
    PD<-c(XMIN+H,YMAX-H)
  }
  else{
    Tmp<-varargin[[N]]
    if(is.numeric(Tmp) && length(Tmp)==1){
      Dy<-Tmp; Dx<-Dy
      Tmp<-varargin[[N-1]]
      if(is.numeric(Tmp) && length(Tmp)==1){
         Dx<-Tmp
      }
      Tmp<-varargin[[1]]
      X<-Tmp[1]; Y<-Tmp[2]
      X1<-X-Dx; X2<-X+Dx; Y1<-Y-Dy; Y2<-Y+Dy
    }
    else{
      Tmp<-varargin[[1]]
      X1<-Tmp[1]; X2<-Tmp[2]
      Tmp<-varargin[[2]]
      Y1<-Tmp[1]; Y2<-Tmp[2]
    }
    PA<-c(X1,Y1); PB<-c(X2,Y1)
    PC<-c(X2,Y2); PD<-c(X1,Y2)
  }
  Out<- Listplot(c(PA,PB,PC,PD,PA))
  return(Out)
}

###################################

Hatchdata<- function(...)
{      ## Scaling is implemented
  varargin<- list(...)
  ShaL<- list()
  Nargs<- length(varargin)
  Kakudo<- 45
#  Kankaku<- 0.125*1000/2.54/MilliIn
  Kankaku<- 0.25*1000/2.54/MilliIn #180706
  Tmp<- Doscaling(c(XMIN,YMIN))
  Xmn<- Tmp[1]; Ymn<- Tmp[2]
  Tmp<- Doscaling(c(XMAX,YMAX))
  Xmx<- Tmp[1]; Ymx<- Tmp[2]
  for (N in seq(Nargs,1, by=-1))
  {
    Tmp<- varargin[[N]]
    if(mode(Tmp)=="list")
    {
      break
    }
  }
  if(N<Nargs)
  {
    Kakudo<- varargin[[N+1]]
    if(N==Nargs-2)
    {
      Kankaku<- Kankaku*varargin[[Nargs]] #180716
    }
  }
  NaitenL<- varargin[[1]]
  if(mode(NaitenL)!="list")
  {
    NaitenL<- list(NaitenL)
  }
  Ns<- 2
  StartP<- Op(1,NaitenL)
  if(mode(StartP)=="character")
  {
    StartP<- c((Xmn+Xmx)/2, (Ymn+Ymx)/2)
  }
  if(mode(varargin[[2]])=="numeric")
  {
    StartP<- varargin[[2]]
    StartP<- Doscaling(StartP)
    Ns<- 3
  }
  Tmp<- list()
  for ( I in Looprange(Ns,N))
  {
    Tmp1<- list(varargin[[I]])
    Tmp2<- Mixjoin(Tmp, Tmp1)
    Tmp<- Tmp2
  }
  Bdy<- Kyoukai(Tmp)
  Bdys<-list()
  for (I in 1:length(Bdy))
  {
    Tmp1<- Bdy[[I]]
    Tmp2<- Doscaling(Tmp1)
    Bdys<- Mixjoin(Bdys,list(Tmp2))
  }
  Bdy<- Bdys
  PtnL<- list()
  for (I in Looprange(1,length(NaitenL)))
  {
    Tmp<- Op(I, NaitenL)
    if(mode(Tmp)=="numeric")
    {
      Tmp1<- Naigai(Tmp,Bdy)
      Tmp2<- Mixjoin(PtnL, list(Tmp1))
      PtnL<- Tmp2
    }
    else
    {
      if(mode(Tmp)!="character")
      {
        return("Mode Error")
      }
      Ptn<-c()
      for (J in 1:nchar(Tmp))
      {
       if(Op(J,Tmp)=="i")
        {
          Ptn<- c(Ptn,1)
        }
        else
        {
          Ptn<- c(Ptn,0)
        }
      }
      PtnL<- Mixjoin(PtnL, list(Ptn))
    }
  }
  Call<- length(Bdy)
  Ptn<- c(seq(0, 0, length=Call))
  if(Member(Ptn,PtnL))
  {
    Wn<- Doscaling(Framedata())
    Tmp<- Mixjoin(Bdy,list(Wn))
    Bdy<- Tmp
    Tmp<- list()
    for (I in Looprange(1, length(PtnL)))
    {
      Tmp1<- c(Op(I,PtnL),1)
      Tmp2<- Mixjoin(Tmp,list(Tmp1))
      Tmp<- Tmp2
    }
    PtnL<- Tmp
  }
  V<- c(cos(Kakudo*pi/180),sin(Kakudo*pi/180))
  Vm<- c(-sin(Kakudo*pi/180),cos(Kakudo*pi/180))
  Tmp<- Op(1,NaitenL)
  if(mode(Tmp)=="numeric" && length(Tmp)==2)
  {
    Tmp<- Doscaling(Tmp)
    Delta<- Tmp-StartP
    K<- trunc(Dotprod(Delta,Vm)/Kankaku)
    PA<- StartP+K*Kankaku*Vm
    Sha<- Makeshasen(PtnL,PA,V,Bdy)
    I <- 1
    while (length(Sha)>0)
    {
      Tmp<- Mixjoin(ShaL, list(Sha))
      ShaL <- Tmp
      Sha<- Makeshasen(PtnL,PA+I*Kankaku*Vm,V,Bdy)
      I <- I+1
    }
    Sha<- Makeshasen(PtnL,PA-Kankaku*Vm,V,Bdy)
    I<- 2
    while (length(Sha)>0)
    {
      for (J in 1:length(Sha))
      {
        Tmp<- Mixjoin(ShaL,list(Sha[[J]]))
        ShaL<- Tmp
      }
      Sha<- Makeshasen(PtnL,PA-I*Kankaku*Vm,V,Bdy)
      I<- I+1
    }
  }
  else
  {
    Delta<- c(Xmn,Ymn)-StartP
    K1<- trunc(Dotprod(Delta,Vm)/Kankaku)
    Delta<- c(Xmx,Ymn)-StartP
    K2<- trunc(Dotprod(Delta,Vm)/Kankaku)
    Delta<- c(Xmx,Ymx)-StartP
    K3<- trunc(Dotprod(Delta,Vm)/Kankaku)
    Delta<- c(Xmn,Ymx)-StartP
    K4<- trunc(Dotprod(Delta,Vm)/Kankaku)
    IM<- max(K1,K2,K3,K4)
    Im<- min(K1,K2,K3,K4)
    for (I in Im:IM)
    {
      Sha<- Makeshasen(PtnL,StartP+I*Kankaku*Vm,V,Bdy)
      for (J in Looprange(1,length(Sha)))
      {
        Tmp<- Mixjoin(ShaL, list(Sha[[J]]))
        ShaL<- Tmp
      }
    }
  }
  ShaLs<-list()
  for (I in Looprange(1,length(ShaL)))
  {
    Tmp<- ShaL[[I]]
    Tmp1<- Unscaling(Tmp)
    Tmp2<- Mixjoin(ShaLs, list(Tmp1))
    ShaLs<- Tmp2
  }
  ShaL<- ShaLs
  return(ShaL)
}

######################################

Htickmark<- function(...)
{  ## Scaling is implemented 
  varargin<- list(...)
  Nargs<- length(varargin)
  ArgsL<- varargin
  if(mode(ArgsL[[1]])=="character"){
    Str<- ArgsL[[1]]
    Tmp<- strsplit(Str,"m")
    Tmp<- Tmp[[1]]
    if(length(Tmp)>1){
      I<- nchar(Tmp[1])+1
    }
    else{
      I<- 0
    }
    Tmp<- strsplit(Str,"n")
    Tmp<- Tmp[[1]]
    if(length(Tmp)>1){
      J<- nchar(Tmp[1])+1
    }
    else{
      J<- 0
    }
    Tmp<- strsplit(Str,"r")
    Tmp<- Tmp[[1]]
    if(length(Tmp)>1){
      K=nchar(Tmp[1])+1
    }
    else{
      K<- 0
    }
    if(K>0){
      S<- substr(Str,K+1,nchar(Str))
      R<-  as.numeric(S)
      if(is.na(R)){
        R<- 1
      }
    }
    else{
      R<- 1
      K<- nchar(Str)+1
    }
    if(J>0){
      S<- substr(Str,J+1,K-1)
      Dn<-  as.numeric(S)
      if(is.na(Dn)){
        Dn<- 1
      }
    }
    else{
      Dn<- 1000
      J<- nchar(Str)+1
    }
    S<- substr(Str,I+1,J-1)
    Dm<- as.numeric(S)
    if(is.na(Dm)){
      Dm<- 1
    }
    ArgsL<- list()
    for (I in Looprange(1, floor((XMAX-GENTEN[1])/Dm))){
      ArgsL<- Mixjoin(ArgsL,I*Dm)
      if(I-floor(I/Dn)*Dn==0){
        Str<- as.character(I*Dm*R)
        ArgsL<- Mixjoin(ArgsL,Str)
      }
    }
    for (I in seq(-1,ceiling((XMIN-GENTEN[1])/Dm),by=-1)){
      ArgsL<- Mixjoin(ArgsL,I*Dm)
      if(I-floor(I/Dn)*Dn==0){
        Str<- as.character(I*Dm*R)
        ArgsL<- Mixjoin(ArgsL,Str)
      }
    }
  }
  MemoriList<- list()
  Memori<- list()
  for (N in 1:length(ArgsL)){
    Dt<- ArgsL[[N]]
    if(mode(Dt)=="numeric" && length(Dt)>1){
      if(length(Memori)>0){
        MemoriList<- Mixjoin(MemoriList,list(Memori))
      }
      Memori<- list(Dt[1],Dt[2])
      next
    }
    if(mode(Dt)=="character"){
      Memori<- Mixjoin(Memori,Dt)
    }
    else{
      if(length(Memori)>0){
        MemoriList<- Mixjoin(MemoriList,list(Memori))
      }
      Memori<- list(Dt,GENTEN[2])
    }
  }
  MemoriList<- Mixjoin(MemoriList,list(Memori))
  for (N in 1:length(MemoriList)){
    Dt<- MemoriList[[N]]
    Ndt<- length(Dt)
    X=Op(1,Dt)
    Y=Op(2,Dt)
    Tmp<-Doscaling(c(X,Y))
    X<- Tmp[1]
    Y<- Tmp[2]
    Moji<- Op(Ndt,Dt)
    Tmp1<- Unscaling(c(X,Y+MARKLEN))
    Tmp2<- Unscaling(c(X,Y-MARKLEN))
    Fd<- Listplot(c(Tmp1,Tmp2))
    Drwline(Fd)
    if(Ndt==3){
      Tmp<-Unscaling(c(X,Y-MARKLEN))
      Expr(Tmp,"s",Moji)
    }
    if(Ndt==4){
      Houkou<- Op(3,Dt)
      Tmp<-grep("s",Houkou)
      if(length(Tmp)>0){
        Tmp<-Unscaling(c(X,Y-MARKLEN))
        Expr(Tmp,Houkou,Moji)
      }
      else{
        Tmp<- Unscaling(c(X,Y+MARKLEN))
        Expr(Tmp,Houkou,Moji)
      }
    }
      cat("%\n",file=Wfile,append=TRUE)
  }
}

#############################################
#  2013.08.07

Integrate<- function(Fs,Vs, Intv){
  if(is.function(Fs)){
    Fn<- Fs
  }
  else{
    Str<- paste("Fn<- function(",Vs, ") ", Fs, sep="")
    eval(parse(text=Str))
  }
  Tmp<- integrate(Fn, Intv[[1]], Intv[[2]])
  Out<- Tmp[[1]]
  return(Out)
}

#############################################

Intersectcrvs<-function(...)
{
  varargin<-list(...)
  Nargs<-length(varargin)
  Eps<-10^(-4)
  Tmp<-varargin[[Nargs]]
  if(mode(Tmp)=="numeric" && length(Tmp)==1)
  {
    Eps<-Tmp
  }
  G1<-varargin[[1]]
  if(mode(G1)=="numeric")
  {
    G1<-list(G1)
  }
  G2<-varargin[[2]]
  if(mode(G2)=="numeric")
  {
    G2<-list(G2)
  }
  PL<-list()
  for (N in 1:length(G1))
  {
    for (M in 1:length(G2))
    {
      KL<-IntersectcrvsPp(G1[[N]],G2[[M]],Eps)
      for (I in Looprange(1,length(KL)))
      {
        Tmp<-KL[[I]]
        P<-Tmp[1]
        PL<-append(PL,P)
      }
    }
  }
  return(PL)
}

###########################################

IntersectcrvsPp<-function(...)
{
  varargin<-list(...)
  Nargs<-length(varargin)
  G1<-varargin[[1]]; G2<-varargin[[2]]
  Eps<- 10.0^(-4)
  if(Nargs>2) Eps<-varargin[[3]]
  SqEps<- 10.0^(-10)
  Eps2<- 0.1
  if(Nargs>3) Eps2<-varargin[[4]]
  Data1<-G1
  Data2<-G2
  if(Nrow(Data1)==Nrow(Data2))
  {
    Tmp<-seq(Nrow(Data2),1, by=-1)
    Tmp1<-Data2[Tmp,] 
    Eps0<-10^(-6)
    Tmp2<-Norm(Data1-Data2)
    Tmp3<-Norm(Data1-Tmp1)  
    if(Tmp2<Eps0||Tmp3<Eps0)
    {
      KL<-list()
      return(KL)
    }
  }
  KL1<-list()
  KL2<-list() 
  for (I in Looprange(1,Nrow(Data1)-1))
  { 
    A<-Data1[I,]
    B<-Data1[I+1,]
    for (J in Looprange(1,Nrow(Data2)-1))
    {
      P<-Data2[J,]; Q<-Data2[J+1,]
      Tmp<-Koutenseg(A,B,P,Q,Eps,Eps2)
      if(mode(Tmp)=="list")
      {
        if(Tmp[[3]]==0)
        {
          Tmp1<-list(Tmp[[1]],Tmp[[2]],I,J)
          KL1<-append(KL1,list(Tmp1))
        }
        else
        {
          Tmp2<-list(Tmp[[1]],Tmp[[2]],I,J)
          KL2<-append(KL2, list(Tmp2))
        }
      } 
    }
  }
  KL<-list()
  if(length(KL1)>0)
  {
    Tmp<-KL1[[1]]
    P<-Tmp[[1]]
    T<-Tmp[[2]]
    I<-Tmp[[3]]
    J<-Tmp[[4]]
    Tmp<-list(P,I+T,J)
    KL<-list(Tmp)
  }
  for (N in Looprange(2,length(KL1)))
  {
    Tmp<-KL1[[N]] 
    P<-Tmp[[1]]
    Flg<-0
    for (K in 1:length(KL))
    {
      if(1>length(KL)) break
      Tmp<-KL[[K]]
      if(Norm(P-Tmp[[1]])^2<SqEps)
      {
        Flg<-1
        break
      }
    }
    if(Flg==0)
    {
      Tmp<-KL1[[N]]
      T<-Tmp[[2]]
      I<-Tmp[[3]]
      J<-Tmp[[4]]
      Tmp<-list(P,I+T,J)
      KL<-append(KL,list(Tmp))
    }
  }
  for (N in Looprange(1,length(KL2)))
  {
    Tmp<-KL2[[N]]
    P<-Tmp[[1]] 
    Flg<-0
    for (K in Looprange(1,length(KL)))
    {
      Tmp<-KL[[K]]
      if(Norm(P-Tmp[[1]])^2<SqEps)
      {
        Flg<-1
        break
      }
    }
    if(Flg==0)
    {
      Tmp<-KL2[[N]]
      T<-Tmp[[2]]
      T<-min(max(T,0),1)
      I<-Tmp[[3]]
      J<-Tmp[[4]]
      Tmp<-list(P,I+T,J)
      KL<-append(KL,list(Tmp))
    }
  }
  return(KL)
}

###########################################
# 13.12.20  debugged

Invdashline<- function(...)
{
  varargin<- list(...)
  Nargs<- length(varargin)
  Nall<- Nargs; Sen<- 1 ; Gap<- 1
  Tmp<- varargin[[Nall]]
  if(is.numeric(Tmp) && length(Tmp)==1 && Tmp>0){ # 13.12.20
    Tmp1<- varargin[[Nall-1]]
    if(is.numeric(Tmp1) && length(Tmp1)==1 && Tmp1>0){ # 13.12.20
      Sen<- Tmp1; Gap<- Tmp
      Nall<- Nall-2
    }
    else{
       Sen<- Tmp; Gap<- Sen
       Nall<- Nall-1
    }
  }
  Sen<- 1000/2.54/MilliIn*Sen
  Gap<- 1000/2.54/MilliIn*Gap
  for (N in Looprange(1,Nall)){
    Figdata<- varargin[[N]]
    Makehasen(Figdata,Sen,Gap,1)
  }
}

#########################################

Invert<- function(Pd)
{
  OutL=Pd[nrow(Pd):1,]
  return(OutL)
}

############################################

InWindow<-function(PA)
{
  Eps<-10.0^(-6);
  if((length(PA)==2)&(is.numeric(PA))){ # 17.11.20
    X<-PA[1]; Y<-PA[2];
    if(X>XMIN-Eps && X<XMAX+Eps && Y>YMIN-Eps && Y<YMAX+Eps)
      Rx<-"i"
    else
      Rx<-"o"
    return(Rx)
  }else{
    return("o")
  }
}

#######################################

Joincrvs<- function(...)
{
  varargin<- list(...)
  Nall<- length(varargin)
  Eps<- 10^(-4)
  Tmp<- varargin[[Nall]]
  if(mode(Tmp)=="numeric" && length(Tmp)==1){
    Eps<- Tmp
    Nall<- Nall-1
  }
  QdL<- Flattenlist(varargin[1:Nall])  # 11.06.25
  if(length(QdL)==0){
    PtL<-c()
    return(PtL)
  }
  PtL<- Op(1,QdL)
  for (I in Looprange(2,length(QdL))){
    Qd<- Op(I,QdL)
    if(Numptcrv(Qd)<=1){next}  # 11.06.25
    P<- Ptend(PtL)
    S<- Ptstart(PtL)
    Q<- Ptstart(Qd)
    R<- Ptend(Qd)
    MN<- min(Norm(P-Q),Norm(P-R),Norm(S-Q),Norm(S-R))
    if(MN==Norm(P-R)){
      Qd<- Invert(Qd)
    }
    else if(MN==Norm(S-Q)){
      PtL=Invert(PtL)
    }
    else if(MN==Norm(S-R)){
      PtL<- Invert(PtL)
      Qd<- Invert(Qd)
    }
    if(MN>Eps){
      PtL<- Appendrow(PtL,Qd)
    }
    else{
      if(is.null(nrow(Qd))){ Qd<- as.matrix(Qd,nrow=1)}
      PtL<- Appendrow(PtL,Qd[2:nrow(Qd),])  # 11.06.25
    }
  }
  return(PtL)
}

########################################
# 2011.11.02

Joingraphics<- function(...)
{
  varargin<- list(...)
  Ls<- Flattenlist(varargin)
  N<- length(Ls)
  Tp<- Ls[[N]]
  Listflg<- 0
  if( is.character(Tp)){
    Tmp<- toupper(substr(Tp,1,1))
    if(Tmp=="L"){
      Listflg<- 1
    }
    N<- N-1
    Ls<- Ls[1:N]
  }
  if(Listflg==1){
    P<- Ls
  }
  else{
    P<- c()
    for (I in 1:N){
      Tmp<- Ls[[I]]
      P<- Appendrow(P,c(Inf,Inf))
      P<- Appendrow(P,Tmp)
    }
    P<- P[2:nrow(P),]
  }
  return(P)
}

########################################

Kouten<- function(PA,V,P,Q)
{
  Eps<- 10.0^(-6)
  A1<- PA[1]; A2<- PA[2]
  V1<- V[1]; V2<- V[2]
  P1<- P[1]; P2<- P[2]
  U1<- Q[1]-P1; U2<- Q[2]-P2
  Tmp<- Norm(P-Q)*Norm(V)
  if(Tmp==0)
  {
    Out<- list(Inf,-Inf)
    return(Out)
  }
  D<- U1*V2-U2*V1
  if(abs(D)/Tmp<Eps)
  {
    Out<- list(Inf,-Inf)
    return(Out)
  }
  S<- ((-A2+P2)*V1+(A1-P1)*V2)/D
  if(S>1+Eps || S<Eps)
  {
    Out<-list(Inf,-Inf)
    return(Out)
  }
  T<- ((-A2+P2)*U1+(A1-P1)*U2)/D
  Tmp<- PA+T*V
  Out<- list(T,Tmp,sign(D))
  return(Out)
}

##########################################

KoutenList<- function(PA,V,Bdy)
{
  Eps<-10.0^(-6)
  TenL<-list()
  for (N in 1:length(Bdy))
  {
    KL<- Op(N,Bdy)
    for (K in Looprange(1, Nrow(KL)-1))
    {
      P<- Op(K,KL); Q<- Op(K+1,KL)
      if(P!="/" && Q!="/")
      {
        Tmp<- Kouten(PA,V,P,Q);
        if(Tmp[[1]]!=Inf)
        {
          Ten<- append(Tmp,N)
          Flg<- 0
          NN<- length(TenL)
          I<- 1
          while (Flg==0 && I<=NN)
          {
            Tmp<- Op(I,TenL)
            if(Op(1,Ten)<Op(1,Tmp)-Eps)
            {
              Tmp1<- TenL[Looprange(1,I-1)]
              Tmp2<- TenL[Looprange(I,length(TenL))]
              TenL<- Mixjoin(Tmp1,list(Ten),Tmp2)
              Flg<-1
            }
            else
            if(Op(1,Ten)<Op(1,Tmp)+Eps)
            {
              if(Op(4,Ten)!=Op(4,Tmp))
              {
                Tmp1<- TenL[Looprange(1,I-1)]
                Tmp2<- TenL[Looprange(I,length(TenL))]
                TenL<- Mixjoin(Tmp1,list(Ten),Tmp2)
                Flg<-1
              }
              else
              if(Op(3,Ten)!=Op(3,Tmp))
              {
                Tmp1<- TenL[Looprange(I,I-1)]
                Tmp2<- TenL[Looprange(I+1,length(TenL))]
                TenL<- Mixjoin(Tmp1,Tmp2)
              }
              Flg<- 1
            }
            I<- I+1
          }
          if(Flg==0)
          {
            TenL<- Mixjoin(TenL,list(Ten))
          }
        }
      }
    }
  }
  return(TenL)
}

##########################################

Koutenseg<-function(...)
{
  #pointdata on AB at which AB intersects CD
  varargin<-list(...)
  Nargs<-length(varargin)
  Eps0 <- 10^(-4)
  A<-varargin[[1]]; V<-varargin[[2]]-A
  Sv2 <- V[1]^2+V[2]^2
  if(Sv2<10^(-6))
  {
    Out<-Inf
    return(Out)
  }    
  P<-varargin[[3]]-A; Q<-varargin[[4]]-A
  Eps <- 10.0^(-3)
  if(Nargs>=5)
  {
    Eps<-varargin[[5]]
  }
  Eps2 <- 0.2
  if(Nargs>=6)
  {
    Eps2<-varargin[[6]]
  }
  Eps<-min(Eps2,Eps/sqrt(Sv2))
  P1<-(P[1]*V[1]+P[2]*V[2])/Sv2
  P2<-(-P[1]*V[2]+P[2]*V[1])/Sv2
  Q1<-(Q[1]*V[1]+Q[2]*V[2])/Sv2
  Q2<-(-Q[1]*V[2]+Q[2]*V[1])/Sv2
  m1 <- -Eps; M1 <- 1+Eps
  m2 <- -Eps; M2 <- Eps
  if(max(P1,Q1)<m1 || min(P1,Q1)>M1)
  {
    Out<-Inf
    return(Out)
  }
  if(max(P2,Q2)<m2 || min(P2,Q2)>M2)
  {
    Out<-Inf
    return(Out)
  }
  if(P2*Q2<0)
  {
    T<- P1-(Q1-P1)/(Q2-P2)*P2
    if(T>m1 && T<M1)
    {
      if(T > -Eps0 && T<1+Eps0)
      {
        Tmp1<-A+T*V
        Tmp2<-min(max(T,0),1)
        Out<-list(Tmp1,Tmp2,0)
      }
      else
      {
        Tmp1<-A+T*V
        Tmp2<-min(max(T,0),1)
        Out<-list(Tmp1,Tmp2,1)
      }
      return(Out)
    }
    if(P1<m1 || P1>M1 || P2<m2 || P2>M2)
    {
      if(Q1<m1 || Q1>M1 || Q2<m2 || Q2>M2)
      {
        Out<-Inf
        return(Out)
      }
      T<-min(max(Q1,0),1)
      Tmp=A+T*V
      Out<-list(Tmp,T,1)
      return(Out)
    }
    T<-min(max(P1,0),1)
    Tmp<-A+T*V
    Out<-list(Tmp,T,1)
    return(Out)
  }
  if(P1> -Eps0 && P1<1+Eps0 && P2> -Eps0 && P2 < Eps0)
  {
    T<- P1
    Tmp<- A+T*V
    Out<- list(Tmp, T, 0)
    return(Out)
  }
  if(Q1> -Eps0 && Q1<1+Eps0 && Q2> -Eps0 && Q2<Eps0)
  {
     T<- Q1
     Tmp<-A+T*V
     Out<- list(Tmp,T,0)
     return(Out)
  }
  if(P1<m1 || P1>M1 || P2<m2 || P2>M2)
  {
    if(Q1<m1 || Q1>M1 || Q2<m2 || Q2>M2)
    {
      Out<-Inf      
      return(Out)
    }
    T<-min(max(Q1,0),1)
    Tmp<-A+T*V
    Out<-list(Tmp,T,1)
    return(Out)
  }
  if(Q1<m1 || Q1>M1 || Q2<m2 || Q2>M2)
  {
    T<-min(max(P1,0),1)
    Tmp<-A+T*V
    Out<-list(Tmp,T,1)
    return(Out)
  }
  if(abs(P2)<abs(Q2))
  {
    T<-min(max(P1,0),1)
  }
  else
  {
    T<-min(max(Q1,0),1)
  }
  Tmp<A+T*V
  Out<-list(Tmp,T,1)
  return(Out)
}

##########################################

Kukeiwake<- function(PL)
{
  Eps<-10.0^(-6)
  NW<- c(XMIN,YMAX); SW<-c(XMIN,YMIN)
  SE<- c(XMAX,YMIN); NE<-c(XMAX,YMAX)
  Tmp<-matrix(c(NW,SW,SE,NE,NW),nrow=2)  
  Sikaku<- t(Tmp)
  Kt<- IntersectcrvsPp(PL,Sikaku)
  if(length(Kt)!=2)
  {
    print("not two points")
    return(c())
  }
  Tmp<- Op(1,Kt)
  Pt1<- Op(1,Tmp)
  N1<- trunc(Op(2,Tmp))
  M1<- Op(3,Tmp)
  Tmp<- Op(2,Kt)
  Pt2<- Op(1,Tmp)
  N2<- trunc(Op(2,Tmp))
  M2<- Op(3,Tmp)
  T1<- Paramoncurve(Pt1,M1,Sikaku) #18.02.06
  T2<- Paramoncurve(Pt2,M2,Sikaku)
  QL<c()
  if(Norm(Pt1-Op(N1+1,PL))>Eps)
  {
    QL<-Pt1
  }
  Tmp<-Appendrow(QL,PL[(N1+1):N2,])
  QL<- Tmp
  if(Norm(Pt2-Op(N2,PL))>Eps)
  {
    Tmp<-Appendrow(QL,Pt2)
    QL<- Tmp
  }
  HidariL<- QL
  Ms<- M2+1; Me<- M1
  if(T1<T2+Eps) Me<- M1+4
  for (M in Looprange(Ms,Me))
  {
    Tmp<- Op(Nrow(HidariL),HidariL)
    P<-Op(((M-1) %% 4)+1,Sikaku)
    if(Norm(Tmp-P)>Eps)
    {
      Tmp<-Append(HidariL,P)
      HidariL<-Tmp
    }
  }
  Tmp<- Op(Nrow(HidariL),HidariL)
  if(Norm(Tmp-Pt1)>Eps)
  {
    Tmp<-Append(HidariL,Pt1)
    HidariL<-Tmp
  }
  MigiL<- QL
  Ms<- M2; Me<- M1+1
  if(T1>T2-Eps) Me<- Me-4
  for (Mm in Looprange(Me,Ms))
  {
    M<- Me+Ms-Mm
    Tmp<- Op(Nrow(MigiL),MigiL)
    P<- Op(((M-1) %% 4)+1,Sikaku)
    if(Norm(Tmp-P)>Eps)
    {
      Tmp<-Appendrow(MigiL,P)
      MigiL<-Tmp
    }
  }
  Tmp<- Op(Nrow(MigiL),MigiL)
  if(Norm(Tmp-Pt1)>Eps)
  {
    Tmp<-Appendrow(MigiL,Pt1)
    MigiL<-Tmp
  }
  Out<- list(HidariL,MigiL)
  return(Out)
}

###################################
#  17.09.24   Eps

Kyoukai<- function(...)
{
  varargin<- list(...)
  Nargs<- length(varargin)
  Eps0<- 10^(-7)
  DataL<-list()
  for (I in 1:Nargs){
    Tmp<- varargin[[I]]
    if(mode(Tmp)=="numeric"){
      DataL<- Mixjoin(DataL,list(list(Tmp)))
    }
    if(mode(Tmp)=="list"){
      if(mode(Tmp[[1]])!="list"){
        DataL<- Mixjoin(DataL, list(Tmp))
      }
      else{
        DataL<-Mixjoin(DataL,Tmp)
      }
    }
  }
  Eps<- 10.0^(-4)   #17.09.24
  PLall<- list()
  Sflg<- 0
  N<- Length(DataL)  #180621
  for (I in Looprange(1,N)){
    Data<- Op(I, DataL)
    Tmp<- Op(Length(Data),Data)
    if(mode(Tmp)=="numeric" && Nrow(Tmp)==1 && Length(Tmp)>1){ #180621
      Rg<-Tmp ; Nd<- Length(Data)-1 #180621
    }
    else{
      if(mode(Tmp)=="character"){
        Rg<- Tmp ; Nd<- Length(Data)-1 #180621
      }
      else{ 
        Rg<- "c" ; Nd<- Length(Data) #180621
      }
    }
    for (J in Looprange(1,Nd)){
      Tmp<- Op(J,Data)
      if(mode(Tmp)=="character"){
        Rg<- Tmp
        next
      }
      Points<- Tmp
      P1<- Ptstart(Points)
      P2<- Ptend(Points)
      if(J==1){
        PL<- Points
        Pfirst<- P1
        Plast<- P2
        if(Nd>=2){
          Tmp<- Op(2,Data)
          P<- Ptstart(Tmp)
          Q<- Ptend(Tmp)
          if(Norm(P2-P)>Eps && Norm(P2-Q)>Eps){
            Tmp< Length(PL) #180621
            PL<-PL[Tmp:1,]
            Pfirst<- Ptstart(PL)
            Plast<- Ptend(PL)
          }
        }
      }
      else{
        if(Norm(P1-Plast)<Eps){ 
          Stp<-1; Ks<-2; Ke=Length(Points) #180621
        }
        else{
          if(Norm(P2-Plast)<Eps) {
            Stp<- -1; Ks<-Length(Points)-1; Ke=1 #180621
          }
          else{
            Tmp<-Appendrow(PL,c(Inf,Inf))
            PL<- Appendrow(Tmp,Points)
            Sflg<- 1
            Pfirst<- P1
            Plast<- P2
            Stp<- 1; Ks<- Length(Points)-1; Ke<- 1 #180621
          }
        }
        for (K in seq(Ks,Ke, by=Stp)){
          Tmp<- Appendrow(PL,Op(K,Points))
          PL<-Tmp
        }
        Plast<- Op(Ke,Points)
      }
    }  
    if(Norm(Pfirst-Plast)>Eps){
      Np<- Length(PL) #180621
      if(Rg=="c"){
        Tmp<- Appendrow(PL,Pfirst)
        PL<- Tmp
      }
      else if(Rg=="s"){
        Tmp<- c(PL[1:Np,2],YMIN)
        Y<- min(Tmp)-1
        P<- c(Plast[1],Y); Q<- c(Pfirst[1],Y)
        Tmp<- Appendrow(PL,P)
        Tmp=Appendrow(Tmp,Q)
        PL=Appendrow(Tmp,Pfirst)
      }
      else if(Rg=="n"){
        Tmp<- c(PL[1:Np,2],YMAX)
        Y<-max(Tmp)+1
        P<- c(Plast[1],Y); Q<- c(Pfirst[1],Y)
        Tmp<- Appendrow(PL,P)
        Tmp<- Appendrow(Tmp,Q)
        PL<- Appendrow(Tmp,Pfirst)
      }
      else if(Rg=="w"){
        Tmp<- c(PL[1:Np,1],XMIN)
        X<- min(Tmp)-1
        P<- c(X,Plast[2]); Q<- c(X,Pfirst[2])
        Tmp<- Appendrow(PL,P)
        Tmp<- Appendrow(Tmp,Q)
        PL<- Appendrow(Tmp,Pfirst)
      }
      else if(Rg=="e"){
        Tmp<- c(PL[1:Np,1],XMAX)
        X<- max(Tmp)+1
        P<- c(X,Plast[2]); Q<- c(X,Pfirst[2])
        Tmp<- Appendrow(PL,P)
        Tmp<- Appendrow(Tmp,Q)
        PL<- Appendrow(Tmp,Pfirst)
      }
      else if(mode(Rg)=="numeric" && Nrow(Rg)==1 && Length(Rg)>1){ #180621
        Tmp<- Kukeiwake(PL)
        Tmp1<- Op(1,Tmp)
        Tmp2<- Naigai(Rg,list(Tmp1)) 
        if(Tmp2==c(1)){
          PL<-Op(1,Tmp)
        }
        else{
          PL<- Op(2,Tmp)
        }
      }
    }
    Tmp<- matrix(Ptstart(PL),nrow=1) #180621
	for (J in Looprange(2,Length(PL))){
      P<- Op(J,PL)
      Q<- Op(Length(Tmp),Tmp)
      if(Norm(P-Q)>Eps){
        Tmp1<-Appendrow(Tmp,P)
        Tmp<-Tmp1
      }
    }
    PL<-Tmp
    PLall<-c(PLall,list(PL))
  }
  if(Length(PLall)==1 && Sflg==0){
    Tmp<- Op(1,PLall)
#    Tmp<- Op(1,Tmp)
    if(Norm(Ptstart(Tmp)-Ptend(Tmp))>Eps0){
       Tmp1<- Appendrow(Tmp,Ptstart(Tmp))
       PLall<- list(Tmp1)
    }
  }
  return(PLall)
}

######################################

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

######################################################

Letterrot<- function(...)
{
  varargin<- list(...)
  P<- varargin[[1]]
  V<- varargin[[2]]; N<- 3
  P<- Doscaling(P)
  V<- Doscaling(V)
  Tmov<- 0
  Tmp<- varargin[[N]]
  if(mode(Tmp)=="numeric"){
    Tmov<- Tmp; N<- N+1
  }
  Nmov<- 0
  Tmp<- varargin[[N]]
  if(mode(Tmp)=="numeric"){
    Nmov<- Tmp; N<- N+1
  }
  Mojiretu<- Assign(varargin[[N]]) #2017.11.26
  Tv<- 1/Norm(V)*V
  Nv<- c(-Tv[2],Tv[1])
  P<- P+MEMORI*Tmov*Tv+MEMORI*Nmov*Nv
  Tmp<- acos(V[1]/Norm(V))
  Theta<- round(Tmp*180/pi)
  if(V[2]>=0){
    Units<- ""
  }
  else{
    Units<- "units=-360,"
  }
  Tmp<- paste("\\rotatebox[",Units,"origin=c]{",as.character(Theta),sep="")
  Tmp<- paste(Tmp,"}{",Mojiretu,"}",sep="")
  Letter(P,"c",Tmp)
}

###################################
#  10.12.04

Lineplot<-function(...)
{  
 varargin <- list(...)
 Nargs<-length(varargin)
 A<-varargin[[1]]
 if(is.numeric(A)) {           
   Tmp<-length(A)
   if(Tmp>3) { 
     B <- A[(Tmp/2+1):Tmp]      
     A <- A[1:(Tmp/2)]       
     Is <- 2
   }
   else {                 
     B<-varargin[[2]]
     Is <- 3
   }                   
 }
 else {                
   B<-A[[2]]
   A<-A[[1]]
   Is <- 2
 }    
 Mag <- 100 ; Semi <- ""    ## 10.12.04
 for (I in Looprange(Is,Nargs)) {       
   Tmp <- varargin[[I]]
   switch ( mode(Tmp),
     "numeric"= Mag <- Tmp,
     "character"= Semi <- Tmp
   )
 }
V<- Mag/Norm(B-A)*(B-A)      ## 10.12.04 from here
 if(Semi=="") {
   Out<- Listplot(c(A-V,A+V))
 }
 else if(Semi=="+") {
   Out<- Listplot(c(A,A+V))
 }
 else {
   Out<- Listplot(c(A-V,A))
 }                                                ## 10.12.04 to here
 return(Out)       
}

################################

Listplot<-function(...){
  varargin<-list(...);
  Z<-c();
  for (I in 1:length(varargin)){
    Data<-varargin[[I]];
    if(mode(Data)=="numeric"){
      if(class(Data)=="numeric"){
        Tmp<- matrix(Data,nrow=2);
        Tmp<- t(Tmp);
        Z<-Appendrow(Z,Unscaling(Tmp)) #181015
      }else{
        Z<-Appendrow(Z,Unscaling(Data)) #181015
      }
    }else{
      for (J in 1:length(Data)){
        Tmp<-Data[[J]];
        Z<-Appendrow(Z,Unscaling(Tmp)) #181015
      }
    }
  }  
  return(Z)
}

##############################

MakeBowdata <- function(PA,PB,H) 
{
 Eps <- 10^(-5)
 BOWSTART <<- PA  
 BOWEND <<- PB  
 D <- 1/2*Norm(PB-PA)  
 R <- (H^2+D^2)/(2*H)
 A1 <- PA[1]; A2<-PA[2]
 B1 <- PB[1]; B2<-PB[2]
 if(abs(A2-B2)>Eps){
#   x <- poly(0,"X")
#   y <- -(A1-B1)*x/(A2-B2)+(1/2)*(A1^2+A2^2-B1^2-B2^2)/(A2-B2)
#   Eq1 <- (A1-x)^2+(A2-y)^2-R^2
#   Tmp <- coeff(Eq1)
#   C0 <- Tmp[1]; C1<-Tm[2]; C2<-Tmp[3]
  C0<- A1^2+(A2-(1/2)*(A1^2+A2^2-B1^2-B2^2)/(A2-B2))^2-R^2  
  C1<- -(A1+B1)*(A2^2+B2^2-2*A2*B2-2*A1*B1+A1^2+B1^2)/(A2-B2)^2  
  C2<- 1+(A1-B1)^2/(A2-B2)^2  
  Det <- sqrt(C1^2-4*C0*C2)  
  Ansx1 <- (-C1+Det)/(2*C2)  
  Ansx2 <- (-C1-Det)/(2*C2)  
  Tmp <- -(A1-B1)*Ansx1/(A2-B2)+(1/2)*(A1^2+A2^2-B1^2-B2^2)/(A2-B2)
  PC <- c(Ansx1,Tmp)  
  Tmp <--(A1-B1)*Ansx2/(A2-B2)+(1/2)*(A1^2+A2^2-B1^2-B2^2)/(A2-B2)  
  PC2 <- c(Ansx2,Tmp)
 }
 else{
   Tmp <- 0.5*(PA+PB)
   PC <- Tmp+c(0,R-H)   # 11.06.02
   PC2 <- Tmp-c(0,R-H)
 }
 VA <- PA-PC
 VB <- PB-PC
 if(VA[1]*VB[2]-VA[2]*VB[1]<0) {  
   PC <- PC2
 }
 AngA <- acos((PA[1]-PC[1])/R)  
 if(PA[2]-PC[2]<0){  
   AngA <- -AngA
 }
 AngB <- acos((PB[1]-PC[1])/R)  
 if(PB[2]-PC[2]<0){  
   AngB <- -AngB
 }
 if(AngA>AngB) {
   AngB <- AngB+2*pi
 }
 Out <- list(PC,R,AngA,AngB)  
 return(Out)
}

####################################################

MakeCurves<-function(...){        ## Scaling is implemented
  varargin<-list(...)
  Figdata<-varargin[[1]]
  if(class(Figdata)=="numeric"){
    Figdata<-matrix(Figdata,nrow=1)
  } 
  Ptout<-1
  if(length(varargin)>=2) Ptout<-varargin[[2]]
  Eps<-10.0^(-6)
  IndM<-Dataindex(Figdata)
  Atos<-c()
  for (Nd in Looprange(1,Nrow(IndM))){  #180509
    Tmp<-IndM[Nd,]
    Motos<- Figdata[Tmp[1]:Tmp[2],]
    All<-Nrow(Motos)
    if(Nrow(Motos)==1){ 
      if(InWindow(Motos)=="o"){
        next
      }
      Tmp1<- as.numeric(Motos)
      if(Ptout==1){
        Drwpt(Tmp1)
      }
      else{
        Tmp1<- Doscaling(Tmp1)
        Atos<-Appendrow(Atos,c(Inf,Inf),Tmp1)
        next
      }
    }
   Crv<-c()
   for (I in Looprange(2,All)){
      P<- Op(I-1,Motos)
      Q<- Op(I,Motos)
      Snbn<-MeetWindow(P,Q)
      if(length(Snbn)==0){
        if(length(Crv)>0){
          Atos<-Appendrow(Atos,c(Inf,Inf),Doscaling(Crv))
          Crv<-c()
        }
      }
      else{
        if(Norm(Snbn[1,]-Snbn[2,])<Eps){ next}  # naosi 101202
        if(length(Crv)==0){
          Crv<-Snbn
        }
        else{
          Tmp<-Op(Nrow(Crv),Crv)
          if(Norm(Tmp-Op(1,Snbn))<Eps){
            Crv<-Appendrow(Crv,Op(2,Snbn))
          }
          else{
            Atos<-Appendrow(Atos,c(Inf,Inf),Doscaling(Crv))
            Crv<-Snbn
          }
        }
      }
   }
   if(Nrow(Crv)>=2)
   {
     Atos<-Appendrow(Atos,c(Inf,Inf),Doscaling(Crv))
   }
 }
  Outdata<-Atos[2:Nrow(Atos),]
  if(class(Outdata)=="numeric")
  {
    Outdata<-matrix(Outdata,nrow=1)
  }
  return(Outdata)
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
    if(Lenall==0){
      next
    }
    Kari<- (Sen+Gap)*0.1
    Naga<- Sen*0.1
    Tobi<- Gap*0.1
    if(Norm(Data[1,]-Data[Dtall,])<Eps){
      Nsen<- max(ceiling(Lenall/Kari),3)
      SegUnit<- Lenall/Nsen
      Naga<- SegUnit*Sen/(Sen+Gap)
      Tobi<- SegUnit*Gap/(Sen+Gap)
      SegList<- c(seq(0,(Nsen-1)*SegUnit,by=SegUnit))
    }
    else{
      if(Ptn==0){
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
        if(J==Dtall){
          break
        }
        J<- J+1
      }
      Hajime<- J-1
      J<- Hajime
      while (Len+Naga>Lenlist[J]-Eps){
        if(J==Dtall){
          break
        }
        J<- J+1
      }
      Owari<- J-1
      T<- (Len-Lenlist[Hajime])
      T<- T/(Lenlist[Hajime+1]-Lenlist[Hajime])
      P<- Data[Hajime,]+T*(Data[Hajime+1,]-Data[Hajime,])
      X<- as.character(round(MilliIn*P[1]))
      Y<- as.character(-round(MilliIn*P[2]))
      Str<- paste("\\special{pa ",X," ",Y,"}",sep="")
      cat(Str,file=Wfile,append=TRUE)
      Mojisu<- Mojisu+nchar(Str)
      for (J in Looprange(Hajime+1,Owari)){
        P<- Data[J,]
        X<- as.character(round(MilliIn*P[1]))
        Y<- as.character(-round(MilliIn*P[2]))
        Str<- paste("\\special{pa ",X," ",Y,"}",sep="")
        cat(Str,file=Wfile,append=TRUE)
        Mojisu<- Mojisu+nchar(Str)
      }
      T<- (Len+Naga-Lenlist[Owari])
      T<- T/(Lenlist[Owari+1]-Lenlist[Owari])
      P<- Data[Owari,]+T*(Data[Owari+1,]-Data[Owari,])
      X<- as.character(round(MilliIn*P[1]))
      Y<- as.character(-round(MilliIn*P[2]))
      Str1<- paste("\\special{pa ",X," ",Y,"}",sep="")
      Str2<- "\\special{fp}"
      cat(Str1,file=Wfile,append=TRUE)
      cat(Str2,file=Wfile,append=TRUE)
      Mojisu<- Mojisu+nchar(Str1)+nchar(Str2)
      if(Mojisu>80){
        cat("%\n",file=Wfile,append=TRUE)
        Mojisu<- 0
      }
    }
  }
  cat("%\n%\n",file=Wfile,append=TRUE);
}

######################################

Makeliststr<- function(L)
{
  Out="list("
  for (I in 1:length(L)){
    Dt<- L[[I]]
    if(mode(Dt)=="numeric"){
      if(length(Dt)==1){
        Dts<- as.character(Dt)
      }
      else{
        Dts<- "c("
        for (J in Looprange(1,Nrow(Dt))){
          for (K in 1:ncol(Dt)){
            Dts<- paste(Dts,as.character(Dt[J,K]),sep="")
            if(K< ncol(Dt)){
              Dts<- paste(Dts,",",sep="")
            }
          }
          if(J<Nrow(Dt)){
            Dts<- paste(Dts,";",sep="")
          }
          else{
            Dts<- paste(Dts,")",sep="")
          }
        }
      }
    }
    if(mode(Dt)=="character"){
      Dts<- paste(Prime(),Dt,Prime(),sep="")
    }
    if(mode(Dt)=="list"){
      Dts<- Makeliststr(Dt)
    }
    Out<- paste(Out,Dts,sep="")
    if(I<length(L)){
      Out<- paste(Out,",")
    }
    else{
      Out<- paste(Out,")",sep="")
    }
  }
  return(Out)
}

############################################

Makeshasen<- function(PtnL,PA,V,Bdy)
{
  Eps<- 10^(-6)
  TenL<- KoutenList(PA,V,Bdy)
  Nten<- length(TenL)
  Call<- length(Bdy)
  Ptn<- c(seq(0, 0, length=Call))
  Out<- list()
  GL<- c()
  Te<- -10^6
  for (I in Looprange(1,Nten-1)){
    TenP<- Op(I,TenL); TenQ<- Op(I+1,TenL)
    Ts<- Op(1,TenP)
    P<- Op(2,TenP); Q<- Op(2,TenQ)
    NC<- Op(4,TenP)
    Tmp<- (Op(NC,Ptn)+1) %% 2
    Ptn[NC]<- Tmp
    if(Op(1,TenQ)-Ts>Eps){
      if(Member(Ptn,PtnL)){
        if(abs(Te-Ts)>Eps){
          if(Nrow(GL)>0){
            Tmp<- Mixjoin(Out, list(GL))
            Out<- Tmp
          }
          GL<- Listplot(P,Q)
        }
        else{
          Tmp <- Appendrow(GL, Q)
          GL<- Tmp
        }
        Te<- Op(1,TenQ)
      }
    }
  }
  if(Nrow(GL)>0){
    Tmp<- Mixjoin(Out, list(GL))
    Out<- Tmp
  }
  return(Out)
}

#############################################

Mawarikomi<- function(...)
{
  varargin<- list(...)
  haba<- "10cm"
  Nargs<- length(varargin)
  if(Nargs>0){ 
    haba<- varargin[[1]]
  }
  cat("\\begin{mawarikomi}%\n",file="",append=TRUE)
  cat("%<1>[5](0,0)%\n",file="",append=TRUE)
  Str<- paste("{",haba,"}{%\n",sep="")
  cat(Str,file="",append=TRUE)
  cat("}%\n",file="",append=TRUE)
  cat("\\end{mawarikomi}",file="",append=TRUE)
}

##############################################

MeetWindow<-function(PA,PB)
{
  if(InWindow(PA)=="i" && InWindow(PB)=="i")
  {
    R<-Appendrow(PA,PB)
    return(R)
  };
  Horner<-function(n,t)
  {
    PT<-(1-t)*PA+t*PB;
    return(PT[n])
  }
  Eps<-10.0^(-6);
  Txm<-(-1); TxM<-(-1); Tym<-(-1); TyM<-(-1);
  if(PA[1]!=PB[1])
  {
    Txm<-(XMIN-PA[1])/(PB[1]-PA[1]);
    TxM<-(XMAX-PA[1])/(PB[1]-PA[1]);
  }
  if(PA[2]!=PB[2])
  {
    Tym<-(YMIN-PA[2])/(PB[2]-PA[2]);
    TyM<-(YMAX-PA[2])/(PB[2]-PA[2]);
  }
  Tmp<-Horner(2,Txm);
  if(Tmp<YMIN-Eps || Tmp>YMAX+Eps)
  {
    Txm<-(-1);
  }
 Tmp<-Horner(2,TxM); 
  if(Tmp<YMIN-Eps || Tmp>YMAX+Eps)
  {
    TxM<-(-1)
  }
  Tmp<-Horner(1,Tym);
  if(Tmp<XMIN-Eps || Tmp>XMAX+Eps)
  {
    Tym<--1
  }
  Tmp<-Horner(1,TyM);
  if(Tmp<XMIN-Eps || Tmp>XMAX+Eps)
  {
    TyM<--1
  }
  Tans<-sort(c(Txm,TxM,Tym,TyM));
  Tmp<-c();
  for (I in 1:length(Tans))
  {
    Tmp1<-Tans[I];
    if(Tmp1>-Eps && Tmp1<1+Eps)
    {
      if(length(Tmp)==0)
      {
        Tmp<-c(Tmp1);
      }
      else
      {
        if(abs(Tmp[length(Tmp)]-Tmp1)>Eps)
        {
          Tmp<-c(Tmp,Tmp1)
        }
      }
    }
  }
  Tans<-Tmp;
  if(length(Tans)==0)
  {
    R<-c();
    return(R);
  }
  if(length(Tans)==1)
  {
    Ten1<-Horner(1:2,Tans[1]);
    if(InWindow(PA)=="i")
    {
      R<-Appendrow(PA,Ten1)
      return(R)
    }
    else
    {
      R<-Appendrow(Ten1,PB)
      return(R)
    }
  }
  Ten1<-Horner(1:2,Tans[1])
  Ten2<-Horner(1:2,Tans[2])
  R<-Appendrow(Ten1,Ten2)
  return(R)
}

#########################################

# New  10.03.21

Mixjoin<-function(...)
{
  varargin<-list(...)
  Nargs<- length(varargin)
  M<- list()
  for (I in 1:Nargs)
  {
    Tmp<-varargin[[I]]
    if(length(Tmp)==0) next
    if(Mixtype(Tmp)==1)
    {
      Tmp<-list(Tmp)
    }
    if(length(M)==0){
      M <- Tmp 
    }
    else{
      M<- c(M,Tmp)
    }
  }
  return(M)
}

#################################

Mixlength<- function(PL){ 
  if(length(PL)==0){
    return(0)
  }
  if(Mixtype(PL)==1){
    Out<- Nrow(PL) 
  }
  else{
    Out<- length(PL)
  }
  return(Out)
}

###########################################

Mixtype<- function(D)
{
  if(mode(D)!="list") return(1)
  for (I in 1:length(D))
  {
    Tmp<- D[[I]]
    if(mode(Tmp)=="list") return(3)
  }
  return(2)
}

###########################################

Naigai<- function(A,Bdy)
{
  V<- c(1,1)
  Call<-length(Bdy)
  KL<- KoutenList(A,V,Bdy)
  Ptn<- seq(1,1,length=Call)
  for (K in Looprange(1,length(KL)))
  {
    Ten<- Op(K,KL)
    T<- Op(1,Ten); NC<- Op(4,Ten)
    if(T<0)
    {
      Tmp<- (Ptn[NC]+1) %% 2
      Ptn[NC]<- Tmp
    }
  }
  return(Ptn)
}

########################################

Nearestpt<- function(...){
  varargin<- list(...)
  Nargs<- length(varargin)
  PL1<- varargin[[1]]
  if(!is.matrix(PL1)){
    Tmp<- matrix(PL1);
    PL1<- t(Tmp)
  }
  if(Nrow(PL1)==1) Flg=0
  else Flg=1
  Eps<- 10.0^(-6)
  PL<- varargin[[2]]
  Ans<- list(PL1[1,],1,PL[1,],1,Norm(PL1[1,]-PL[1,]))
  for(N in Looprange(1,Nrow(PL1))){
    PA<- PL1[N,]
    Pm<- PL[1,]
    Im<- 1
    Sm<- Norm(Pm-PA)
    for(I in Looprange(1,Nrow(PL)-1)){
      A1<- PL[I,1]; A2<-PL[I,2]
      B1<- PL[I+1,1]; B2<-PL[I+1,2]
      V1<- B1-A1; V2<-B2-A2
      X1<- PA[1]; X2<-PA[2]
      Tmp<-V2^2+V1^2
      if(abs(Tmp)<Eps) next
      T<- (-A2*V2-V1*A1+V1*X1+X2*V2)/Tmp
      if(T< -Eps){
        P<- c(A1,A2)
      }else{
        if(T>1+Eps){
          P<- c(B1,B2)
        }else{
          P<- c(A1+T*V1,A2+T*V2)
        }
      }
      S<- Norm(P-PA)
      if(S<Sm-Eps){
        Tmp<- Paramoncurve(P,I,PL)
        Pm<- P; Im<- Tmp; Sm<- S
      }
    }
    if(Sm<Op(5,Ans)) Ans<- list(PA,N,Pm,Im,Sm)
    if(Flg==0){
      Ans<- Ans[3:5]
    }
  }
  return(Ans)
}

#########################################

Newlength<- function()
{
  Tmp1<- "\\newlength{\\Width}%\n"
  Tmp2<- "\\newlength{\\Height}%\n"
  Tmp3<- "\\newlength{\\Depth}%\n"
  cat(Tmp1,file="",append=TRUE); 
  cat(Tmp2,file="",append=TRUE); 
  cat(Tmp3,file="",append=TRUE); 
}

#########################################

Numptcrv<-function(Fig)
{
  return(Nrow(Fig))
}

# 2018.01.29
Length<- function(Data){
  if(is.matrix(Data)){return(nrow(Data))}
  if(is.character(Data)){return(nchar(Data))}
  return(length(Data))
}

#########################################

Op<-function(N,Data)
{
  C <- c()
  if(length(Data)==0) return(C)
  if(mode(Data)=="list"){
    if(class(Data)=="data.frame"){   # 10.02.23
      C<- Data[N,]
    }
    else{ 
      C<- Data[[N]]
    }
    return(C)
  }
  if(mode(Data)=="character"){
    if(length(Data)==1){
      C<- substring(Data,N,N)
    }
    else{
      C<- Data[N]
    }
    return(C)
  }
  if(mode(Data)=="numeric"){
    if(class(Data)=="matrix"){
      Din<- Dataindex(Data)
      if(nrow(Din)==1){
        C<- Data[N,]
      }
      else{
        Tmp1<- Din[N,1]
        Tmp2<- Din[N,2]
        C<- Data[Tmp1:Tmp2,]
      }
    }
    else{
      C=Data[N]
    }
  }
  return(C)
}

#########################################
#  2013.05.20  Changed  ( Creator recorded)
#  2013.12.18  Beginpicture inclued

Openfile<-function(...)
{
  varargin<- list(...) 
  File<- varargin[[1]]
  Bflg<- 0
  Wfile<<- File
  Creator<- ""
  Cflg<- 0
  Nargs<- length(varargin)
  for(N in Looprange(2,Nargs)){
    Tmp<- varargin[[N]]
    Tmp1<- strsplit(Tmp,"=",fixed=TRUE)
    Tmp1<- Tmp1[[1]]
    if(length(Tmp1)>1){
      Creator<- Tmp1[2]
      Cflg<- 1
    }
    else{
      Unitstr<- Tmp
      Bflg<- 1
    }
  }
  Recentf<- "" 
  Fv<- list.files()
  Nv<- grep("\\.r$", Fv)
  Rfiles<-  Fv[Nv]
  StrW<- paste("%%% ",File,sep="") #17.10.28
  StrC<- paste("%%% Generator=",Creator,sep="")
  if(Cflg==0){
  }	
  cat(StrW,"\n",file=Wfile)
  cat(StrC,"\n",file=Wfile,append=TRUE)
  if(Bflg==1){
    Beginpicture(Unitstr)
  }
}

#########################################

Openpar<- function(...)
{
  varargin<- list(...)
  Nargs<- length(varargin)
  Tmp<- varargin[[1]]
  Tmp1<- substr(Tmp,1,1)
  if(Tmp1=="\\"){
    Namestr<- Tmp
    N<- 2
  }
  else{
    Namestr<- "\\tmp"
    N<- 1
  }
  Habastr<- varargin[[N]]
  if(Nargs>N){
    Posstr<- paste("[",varargin[[N+1]],"]",sep="")
  }
  else{
    Posstr<- "[c]"
  }
  Openphr(Namestr)
  S<- paste("\\begin{minipage}",Posstr,"{",Habastr,"}%\n",sep="")
  cat(S,file=Wfile,append=TRUE)
}

###################################

Openphr<- function(Str)
{
  S<- paste("\\def",Str,"{%\n",sep="")
  cat(S,file=Wfile,append=TRUE)
}

#####################################

Ovalbox<- function(...)
{
  varargin<- list(...)
  Nargs<- length(varargin)
  Pos<- varargin[[1]]
  Dr<- varargin[[2]]
  StrV<- varargin[[3]]
  R<- 0.2
  NDflg<- 0
  for (I in Looprange(4,Nargs)){
    Tmp<- varargin[[I]]
    if(mode(Tmp)=="numeric"){
      R<- Tmp
    }
    else{
      if(substr(Tmp,1,1)=="-"){
        NDflg<- 1
        Tmp1<- substr(Tmp,2,nchar(Tmp))
        Cmdstr<- chartr("*","G",Tmp1)
      }
    }
  }
  Xr<- c(XMIN,XMAX)
  Yr<- c(YMIN,YMAX)
  Uv<- 0.6; Uh<- 0.8
  N<- nchar(StrV)
  W<- Uh;H<- Uv*N
  Setwindow(c(-W/2,W/2),c(-H,0))
  G<- Ovaldata(c(0,-H/2),W/2,H/2,R)
  Openphr("\\ketpictmp")
    Beginpicture("1cm")
    if(NDflg==0){
      Drwline(G)
    }
    else{
      eval(parse(text=Cmdstr))  
    }
    for (I in Looprange(1,N)){
      Letter(c(0,Uv/2-Uv*I),"c",Op(I,StrV))
    }
    Endpicture(0)
  Closephr()
  Setwindow(Xr,Yr)
  Letter(Pos,Dr,"\\ketpictmp")
}

##########################################

Ovaldata<- function(...) #17.09.11
{
  varargin<- list(...)
  Nargs<- length(varargin)
  if(Nargs==1){
    Eps<- 1.0*10^(-4)
    C<- c((XMIN+XMAX)/2,(YMIN+YMAX)/2)
    Dx<- XMAX-C(1)-Eps
    Dy<- YMAX-C(2)-Eps
    N<- 1
  }
  else{
    C<- varargin[[1]]
    Dx<- varargin[[2]]
    Dy<- varargin[[3]]
    N<- 4
  }
  Rc<- 0.2
  if(N<=Nargs){ #15.11.15
    Rc<- varargin[[N]]*Rc #15.11.15
  }
  Out<- c()
  P<- C+c(Dx-Rc,Dy-Rc)
  Tmp1<- Circledata(c(P,Rc),"R=c(0,pi/2)","N=10") #17.11.29
  Tmp2<- Listplot(C+c(Dx-Rc,Dy),C+c(0,Dy))
  Tmp3<- Listplot(C+c(Dx,0),C+c(Dx,Dy-Rc))
  G<- Joincrvs(Tmp3,Tmp1,Tmp2)
  Tmp<- Reflectdata(G,c(C,C+c(0,1)))
  G<- Joincrvs(G,Tmp)
  Tmp<- Reflectdata(G,c(C,C+c(1,0)))
  Out<- Joincrvs(G,Tmp)
}

#########################################

Paramark<- function(...)
{
  varargin<- list(...)
  Nargs<- length(varargin)
  PA<- varargin[[1]]
  PB<- varargin[[2]]
  PC<- varargin[[3]]
  R<- 0.5
  if(Nargs>=4){
    R<- varargin[[4]]*R
  }
  U<- R*(PA-PB)/Norm(PA-PB)
  V<- R*(PC-PB)/Norm(PC-PB)
  if(Crossprod(PA-PB,PC-PB)!=0){
    P<- Listplot(c(PB+U,PB+U+V,PB+V))
  }
  else{
    P<- c()
  }
}

###########################################

Paramoncurve<-function(...){
  varargin<-list(...)  
  Nargs<-length(varargin)
  Eps<-10^(-8)
  P<-varargin[[1]]
  Gdata<-varargin[[Nargs]]
  if(Nrow(P)>1){
    Tmp<-P; P<-Gdata; Gdata<-Tmp
  }
  if(Nargs==2){
    Tmp<-Nearestpt(P,Gdata)
    Out<-Tmp[[2]]
    return(Out)
  }
  N<-varargin[[2]]
  PtL<-Gdata
  N=min(N,Length(PtL)-1) #18.02.11from
  Pa<-Ptcrv(N,PtL)
  Pb<-Ptcrv(N+1,PtL)
  V<-Pb-Pa
  W<-P-Pa
  D2<-Norm(V)^2
  if(D2<Eps) return(0)
  S<-Dotprod(V,W)/D2
  S<-min(max(S,0),1)
  Out=N+S  #18.02.11until
  return(Out)
}

##############################################

Paramplot<- function(...)
{
  varargin<- list(...)
  Eps<- 10^(-5)
  Nargs<- length(varargin)
  Fnflg<- 0
  Fnstr<- varargin[[1]]; Is=2
  Rgstr<- varargin[[Is]]; Is<- Is+1
  Tmp=strsplit(Rgstr,"=") #181017from
  Var=Tmp[[1]][1]
  Fnstr=Assign(Fnstr,Var,"t")
  Rgstr=Assign(Rgstr,Var,"t")  #181017from
  Range<- c(0,2*pi)
  N<- 50      # Numpoints
  E<-c()       # Exclusions
  D<- Inf      # Discont
  for (I in Looprange(Is,Nargs))
  {
    Tmp<- varargin[[I]]
    Tmp<- strsplit(Tmp,"=")
    K<- Tmp[[1]]
    Tmp<- K[1]
    Lhs<-  substring(Tmp,1,1)
    Tmp1<- K[2]
    Str<-paste(Lhs,"=",Tmp1,sep="")
    eval(parse(text=Str))
  }
  Tmp<- strsplit(Rgstr,"=")
  K<-Tmp[[1]]
  if(length(K)>1)
  {
    Vname<- K[1]
    Tmp1<- K[2]
    Rng<- eval(parse(text=Tmp1))
  }
  else
  {
    Vname<- Rgstr
    Rng<- c(0,2*pi)
  }
  T1<- Rng[1]; T2<- Rng[2]
  Dt<- (T2-T1) #180929
   if(Fnflg==0)
  {
    Str<-  gsub(Vname,"t",Fnstr)
  }
  if(abs(Dt)<Eps){ # 16.12.13
    t=T1
    P=eval(parse(text=Str))
    return(P)
  }
  P<-c()
  if(length(E)>0)
  {
    E<-sort(E)
    E<E[length(E):1]
  }
  E<- c(E, Inf)
  Tmp<- sort(E)
  E<- E[length(Tmp):1]
  Ke<- 1
  for(jj in 1:(N+1)){
    t=T1+(jj-1)*Dt/N #180929
    Pa<- c()
    if(t-E[Ke]< Eps)
    {
      if(Fnflg==0)
      {
        Tmp<-eval(parse(text=Str))
        Pa<- Tmp
      }
      else
      {
      }
    }
    if(abs(t-E[Ke])<=Eps)
    {
      if(Nrow(P)>0 && Op(Nrow(P),P)!=c(Inf,Inf))
      {
        Pa<- c(Inf,Inf)
      }
    }
    if(t-E[Ke]>Eps)
    {
      if(Fnflg==0)
      {
        Tmp<- eval(parse(text=Str))
        Pa<- Tmp
      }
      else
      {
      }
      Ke<-Ke+1
    }
    if(length(Pa)>0){
      if(Pa[1]==Inf){
        Tmp<-Appendrow(P,Pa)
        P<-Tmp
      }else{
        if(Nrow(P)==0){
          Tmp<- Appendrow(P,Pa)
          P<-Tmp
        }else{
          Tmp<- Op(Nrow(P),P)
          if(Tmp[1]==Inf){
            Tmp<- Appendrow(P,Pa)
            P<- Tmp
          }else{
            if(Norm(Tmp-Pa)<D){
              if(Norm(Tmp-Pa)>Eps){ #180928
                Tmp<-Appendrow(P,Pa)
                P<-Tmp
              } #180928
            }else{
              Tmp<- Appendrow(P,c(Inf,Inf),Pa)
              P<- Tmp
            }
          }
        }
      }
    }
  }
  Tmp<- Nrow(P)
  Tmp1<- Op(Tmp,P)
  if(Tmp1[1]==Inf)
  {
    P<- P[1:(Tmp-1),]
  }
  return(P)
}

#####################################

Partcrv<- function(A,B,PkL)
{
  Eps<- 10.0^(-3)
  if(mode(A)=="numeric" && length(A)==1){
    if(A>B+Eps){
      Npt<- Numptcrv(PkL)
      Out1<- Partcrv(A,Npt,PkL)
      Out2<- Partcrv(1,B,PkL)
      Tmp<- Ptstart(PkL)-Ptend(PkL)
      if(Norm(Tmp)<Eps){
        Ans<- Joincrvs(Out1,Out2)
      }
      else{
        Ans<- list(Out1,Out2)
      }
      return(Ans)
    }
    Is<- ceiling(A)
    Ie<- floor(B)
    PL<- c()
    if(A<Is-Eps){
      P<- (Is-A)*PkL[Is-1,]+(1-Is+A)*PkL[Is,]
      PL<- c(P)
    }
    PL<- Appendrow(PL, PkL[Looprange(Is,Ie),])
    if(B>Ie+Eps){
      P<- (1-B+Ie)*PkL[Ie,]+(B-Ie)*PkL[Ie+1,]
      PL<- Appendrow(PL,P)
    }
    Ans<- PL
    return(Ans)
  }
  Tmp<- Nearestpt(A,PkL)
  Ta<- Op(2,Tmp)
  Tmp<- Nearestpt(B,PkL)
  Tb<- Op(2,Tmp)
  Ans<- Partcrv(Ta,Tb,PkL)
}

##########################################
#  13.05.03

Partframe<- function(Tb,St,Ed)
{
  G<- Dividetable(Tb)
  Gw<- G[[1]]
  Gt<- G[[2]]
  Gy<- G[[3]]
  Gwt<- Tb[[4]]
  Gwy<- Tb[[5]]
  Gat<- c(list(Gwt[[1]]),Gt,list(Gwt[[2]]))
  Gay<- c(list(Gwy[[1]]),Gy,list(Gwy[[2]]))
  Tmp1<- Ptstart(Gat[[St[1]]])
  Tmp2<- Ptstart(Gay[[St[2]]])
  Ps<- c(Tmp1[1],Tmp2[2])
  Tmp1<- Ptstart(Gat[[Ed[1]]])
  Tmp2<- Ptstart(Gay[[Ed[2]]])
  Pe<- c(Tmp1[1],Tmp2[2])
  Pars<- Paramoncurve(Ps,Gw)
  Pare<- Paramoncurve(Pe,Gw)
  if(Pars<Pare){
    Out<- Partcrv(Pars,Pare,Gw)
  }
  else{
    Tmp1<- Partcrv(Pars,Numptcrv(Gw),Gw)
    Tmp2<- Partcrv(1,Pare,Gw)
    Out<- Joincrvs(Tmp1,Tmp2)
  }
return(Out)
}


##########################################
# 10.12.04

Plotdata<- function(...)
{
  varargin<- list(...)
  Eps<- 10^(-5)
  Fnstr<- varargin[[1]]; Is<- 2
  Fnstr=Assign(Fnstr) #180510(for KeTCindy)
  Fnflg<- 0
  Rgstr<- varargin[[Is]]; Is<- Is+1
  Rgstr=Assign(Rgstr) #180510(for KeTCindy)
  Tmp<- strsplit(Rgstr,"=")
  K<-Tmp[[1]]
  if(length(K)>1){
    Vname<- K[1]
    Tmp1<- K[2]
    Rng<- eval(parse(text=Tmp1))
  }
  else{
    Vname<- Rgstr
    Rng<- c(XMIN,XMAX)
  }
  N<- 50      # Numpoints
  E<-c()       # Exclusions
  Exfun<- ""  # Exclusion function
  D<- Inf      # Discont
  for (I in Looprange(Is,length(varargin))){
    Tmp<- varargin[[I]]
    Lhs<- substring(Tmp,1,1)
    Tmp<- strsplit(Tmp,"=")
    K<- Tmp[[1]]
    Tmp1<- K[2]
    Tmp2<- grep(Vname,Tmp1,fixed=TRUE)   ## 10.12.04
    if(length(Tmp2)==0){
      Str<-paste(Lhs,"=",Tmp1,sep="")
      eval(parse(text=Str))
    }
    else{
      Exfun<-Tmp1
    }
  }
  X1<- Rng[1]; X2<- Rng[2]
  dx<- (X2-X1) #180929
  if(Fnflg==0){
    Str<-  gsub(Vname,"x",Fnstr,fixed=TRUE)
  }
  if(abs(dx/N)<Eps){  #180929
    x=X1
    P=c(X1,eval(parse(text=Str)))
    return(P)
  }
  Exfun<- gsub(Vname,"x",Exfun,fixed=TRUE)
  P<-c()
  if(length(E)>0){
    E<-sort(E)
    E<E[length(E):1]
  }
  E<- c(E, Inf)
  Tmp<- sort(E)
  E<- E[length(Tmp):1]
  Ke<- 1
#  for (x in seq(X1,X2,by=dx)){
  for (J in 0:N){ #180929
    x=X1+dx*J/N #180929
    if(nchar(Exfun)>0){
      Tmp<-eval(parse(text=Exfun))
      if(abs(Tmp)<Eps){
        P<- Appendrow(P,c(Inf,inf))
        next
      }
    }
    Pa<- c()
    if(x-E[Ke]< -Eps){     ## 10.12.04
      Tmp<-eval(parse(text=Str))
      Pa<- c(x,Tmp)
    }
    if(abs(x-E[Ke])<=Eps){
      if(Nrow(P)>0 && P[Nrow(P),]!=c(Inf,Inf)){
        Pa<- c(Inf,Inf)
      }
    }
    if(x-E[Ke]>Eps){
      Tmp<- eval(parse(text=Str))
       Pa<- c(x,Tmp)
       Ke<-Ke+1
    }
    if(length(Pa)>0){
      if(Pa[1]==Inf){
        Tmp<-Appendrow(P,Pa)
        P<-Tmp
      }
      else{
        if(Nrow(P)==0){
          Tmp<- Appendrow(P,Pa)
          P<-Tmp
        }          
        else{
          Tmp<- P[Nrow(P),]
          if(Tmp[1]==Inf){
            Tmp<- Appendrow(P,Pa)
            P<- Tmp
          }
          else{
            if(Norm(Tmp-Pa)<D){
              Tmp<-Appendrow(P,Pa)
              P<-Tmp
            }
            else{
              Tmp<- Appendrow(P,c(Inf,Inf),Pa)
              P<- Tmp
            }
          }
        }
      }
    }
  }
  Tmp<- Nrow(P)
  Tmp1<-P[Tmp,]
  if(Tmp1[1]==Inf)
  {
    P<- P[1:(Tmp-1),]
  }
  return(P)
}

######################################

Pointoncurve<-function(...)
{
  varargin<-list(...)
  Eps<-10^(-4)
  T<-varargin[[1]]
  Gdata<-varargin[[2]]
  if(Nrow(T)>1)
  {
    Tmp<-T; T<-Gdata; Gdata<-Tmp
  }
  PtL<-Gdata
  N<-trunc(T+Eps);
  S<-max(T-N,0);
  if(N==Nrow(PtL))
  {
    Out<-PtL[N,]
  }
  else
  {
    Pa<-PtL[N,]
    Pb<-PtL[N+1,]
    Out<-(1-S)*Pa+S*Pb
  }
  return(Out)
}

##############################################
#  10.11.20
#  13.05.03   Inf

Pointdata<-function(...)
{
  varargin<-list(...)
  Nargs<-length(varargin)
  PL<- list()
  for (I in Looprange(1,Nargs)){     # 10.11.20
    DL<-varargin[[I]]
	DL<- Flattenlist(DL)                    # 10.11.20  from here
	for (J in Looprange(1,length(DL))){
      Dt<- DL[[J]]
      if(is.matrix(Dt)|| is.data.frame(Dt)){
        for (K in 1:nrow(Dt)){
          Tmp<- as.numeric(Dt[K,])
          if(Tmp[1]<Inf){
            PL<- c(PL,list(Tmp))
          }
        }
      }
      else{
        PL<- c(PL,list(Dt))
      }
    }
  }                                                      # to here
  if(length(PL)==1)
  {
    PL<-PL[[1]]
  }
  return(PL)
}

##############################################

Prime<- function(...)
{
  varargin<- list(...)
  if(length(varargin)==0){
    Out="'"
  }
  else{
    Out<- paste(varargin[[1]],"'",sep="")
  }
  return(Out)
}

############################################
# 17.09.29

Ptcrv<-function(N,Fig)
{
  if(is.matrix(Fig)){
    return(Fig[N,])
  }
  else{
    return(Fig)
  }
}

#########################################

Ptend<-function(Fig)
{
  if(Length(Fig)>0){ #18.02.09
    return(Op(Length(Fig),Fig))
  }else{
    return(c())
  }
}

#########################################

Ptne<-function(...)
{
  varargin<- list(...)
  if(length(varargin)==0){
    Out<- c(XMAX,YMAX)
  }
  else{
    G<- varargin[[1]]
    XM<- max(G[,1])
    YM<- max(G[,2])
    Out<- c(XM,YM)
  }
  return(Out)
}

#########################################

Ptnw<-function(...)
{
  varargin<- list(...)
  if(length(varargin)==0){
    Out<- c(XMIN,YMAX)
  }
  else{
    G<- varargin[[1]]
    Xm<- min(G[,1])
    YM<- max(G[,2])
    Out<- c(Xm,YM)
  }
  return(Out)
}

#########################################

Ptse<-function(...)
{
  varargin<- list(...)
  if(length(varargin)==0){
    Out<- c(XMAX,YMIN)
  }
  else{
    G<- varargin[[1]]
    XM<- max(G[,1])
    Ym<- min(G[,2])
    Out<- c(XM,Ym)
  }
  return(Out)
}

#############################################

Ptstart<-function(Fig)
{
  if(Length(Fig)>0){ #18.02.09
    return(Op(1,Fig))
  }else{
    return(c())
  }
}

#########################################

Ptsw<-function(...)
{
  varargin<- list(...)
  if(length(varargin)==0){
    Out<- c(XMIN,YMAX)
  }
  else{
    G<- varargin[[1]]
    Xm<- min(G[,1])
    Ym<- min(G[,2])
    Out<- c(Xm,Ym)
  }
  return(Out)
}

##############################################

Putcell<- function(...)
{
  varargin<- list(...)
  Nargs<- length(varargin)
  TbL<- varargin[[1]]
  Str<- varargin[[Nargs]]
  if(mode(Str)=="numeric"){
    Str<- as.character(Str)
  }
  Pos<- varargin[[Nargs-1]]
  Nrg<- varargin[[2]]
  if(mode(Nrg)=="character"){
    if(Nargs==4){
      Cell<- Findcell(TbL,Nrg)
    }
    else{
      Mrg<- varargin[[3]]
      Cell<- Findcell(TbL,Nrg,Mrg)
    }
  }
  else{
    Mrg<- varargin[[3]]
    Cell<- Findcell(TbL,Nrg,Mrg)
  }
  Pt<- Cell[[1]]; Dr<- "c"
  Posh<- substr(Pos,1,1)
  Post<- substr(Pos,2,nchar(Pos))
  if(toupper(Posh)=="R"){
    Pt<- Pt+c(Cell[[2]],0)
    if(nchar(Post)==0){
      Dr<- "w1"
    }
    else{
      Dr<- paste("w",Post,sep="")
    }
  }
  if(toupper(Posh)=="L"){
    Pt=Pt-c(Cell[[2]],0)
    if(nchar(Post)==0){
      Dr<- "e1"
    }
    else{
      Dr<- paste("e",Post,sep="")
    }
  }
  if(toupper(Posh)=="U"){
    Pt<- Pt+c(0,Cell[[3]])
    if(nchar(Post)==0){
      Dr<- "s1"
    }
    else{
      Dr<- paste("s",Post,sep="")
    }
  }
  if(toupper(Posh)=="D"){
    Pt<- Pt-c(0,Cell[[3]])
    if(nchar(Post)==0){
      Dr<- "n1"
    }
    else{
      Dr<- paste("n",Post,sep="")
    }
  }
  if(toupper(Posh)=="B"){
    Pt<- Pt-c(0,Cell[[3]])
    if(nchar(Post)==0){
      Dr<- "n1"
    }
    else{
      Dr<- paste("n",Post,sep="")
    }
    Str<- paste("$\\mathstrut$",Str,sep="")
  }
  Letter(Pt,Dr,Str)
}

#############################################

PutcoL<- function(...)
{
  varargin<- list(...)
  Nargs<- length(varargin)
  TbL<- varargin[[1]]
  if(mode(TbL)!="list"){
    return("Tabledata missing")
  }
  Ag<- varargin[[2]]
  if(mode(Ag)=="numeric"){
    CoL<- Ag
  }
  else{    
    Alpha<- "-ABCDEFGHIJKLMNOPQRSTUVWXYZ"
    Clm<- c()
    for (I in Looprange(1,nchar(Ag))){
      C<- substr(Ag,I,I)
      C<- toupper(C) 
      Tmp<- strsplit(Alpha,C)
      Tmp<- Tmp[[1]]
      if(length(Tmp)>1){
        Tmp1<- nchar(Tmp[1])
        Clm<- c(Clm,Tmp1)
      }
    }
    Nrg<- 0
    for (I in seq(length(Clm),1,by=-1)){
      Tmp<- Clm[I]
      Tmp1<- length(Clm)-I
      Nrg<- Nrg+Tmp*26^Tmp1
    }
    CoL<- Nrg
  }
  Nc<- length(TbL[[3]])+1
  K<- 1
  Dpos<- varargin[[3]]
  for (I in Looprange(4,Nargs)){
    if(I-3>Nc){ 
      break
    }
    Dt<- varargin[[I]]
    if(mode(Dt)!="list"){
      Putcell(TbL,CoL,K,Dpos,Dt) #  2011.03.02
      K<- K+1
    }
    else{
      N<- length(Dt)
      Str<- Dt[[N]]
      Rrng<- c(K,K+1)
      Pos<- Dpos
      for (J in Looprange(1,N-1)){
        Tmp<- Dt[[J]]
        if(mode(Tmp)=="numeric"){
          Rrng<- c(K,K+Tmp)
        }
        if(mode(Tmp)=="character"){
          Pos<- Tmp
        }
      }
      Putcell(TbL,CoL,Rrng,Pos,Str)
      K<- Crng[2]
    }
  }
}

Putcol<- function(...)
{
 PutcoL(...)
}

PutcoLexpr<- function(...)
{
  varargin<- list(...)
  Nargs<- length(varargin)
  TbL<- varargin[[1]]
  if(mode(TbL)!="list"){
    return("Tabledata missing")
  }
  Ag<- varargin[[2]]
  if(mode(Ag)=="numeric"){
    CoL<- Ag
  }
  else{    
    Alpha<- "-ABCDEFGHIJKLMNOPQRSTUVWXYZ"
    Clm<- c()
    for (I in Looprange(1,nchar(Ag))){
      C<- substr(Ag,I,I)
      C<- toupper(C) 
      Tmp<- strsplit(Alpha,C)
      Tmp<- Tmp[[1]]
      if(length(Tmp)>1){
        Tmp1<- nchar(Tmp[1])
        Clm<- c(Clm,Tmp1)
      }
    }
    Nrg<- 0
    for (I in seq(length(Clm),1,by=-1)){
      Tmp<- Clm[I]
      Tmp1<- length(Clm)-I
      Nrg<- Nrg+Tmp*26^Tmp1
    }
    CoL<- Nrg
  }
  Nc<- length(TbL[[3]])+1
  K<- 1
  Dpos<- varargin[[3]]
  for (I in Looprange(4,Nargs)){
    if(I-3>Nc){ 
      break
    }
    Dt<- varargin[[I]]
    if(mode(Dt)!="list"){
      Dt<- paste("$",Dt,"$",sep="")
      Putcell(TbL,CoL,K,Dpos,Dt)  #  2011.03.02
      K<- K+1
    }
    else{
      N<- length(Dt)
      Str<- paste("$",Dt[[N]],"$",sep="")
      Rrng<- c(K,K+1)
      Pos<- Dpos
      for (J in Looprange(1,N-1)){
        Tmp<- Dt[[J]]
        if(mode(Tmp)=="numeric"){
          Rrng<- c(K,K+Tmp)
        }
        if(mode(Tmp)=="character"){
          Pos<- Tmp
        }
      }
      Putcell(TbL,CoL,Rrng,Pos,Str)
      K<- Crng[2]
    }
  }
}

Putcolexpr<- function(...)
{
 PutcoLexpr(...)
}

#####################################################

PutcoLstr<- function(...)
{
  varargin<- list(...)
  Nargs<- length(varargin)
  Tb<- varargin[[1]]
  Nr<- varargin[[2]]
  Pos<- varargin[[3]]
  Str<- varargin[[4]]
  Sep<- ""
  if(Nargs>4){
    Sep<- varargin[[5]]
  }
  if(nchar(Sep)==0){
    for (I in Looprange(1,nchar(Str))){
      Tmp<- substr(Str,I,I)
      Putcell(Tb,Nr,I,Pos,Tmp)
    }
  }
  else{
    Ltr<- ""
    K<- 1
    for (I in Looprange(1,length(Str))){
      Tmp<- substr(Str,I,I)
      if(Tmp==Sep){
        Putcell(Tb,Nr,K,Pos,Ltr)
        K<- K+1
        Ltr<- ""
      }
      else{
        Ltr<- paste(Ltr,Tmp,sep="")
      }
    }
    if(nchar(Ltr)>0){
      Putcell(Tb,Nr,K,Pos,Ltr)
    }
  }
}

#############################################

Putrow<- function(...)
{
  varargin<- list(...)
  Nargs<- length(varargin)
  TbL<- varargin[[1]]
  if(mode(TbL)!="list"){
    return("Tabledata missing")
  }
  Row<- varargin[[2]]
  Nr<- length(TbL[[2]])+1
  K<- 1
  Dpos<- varargin[[3]]
  for (I in Looprange(4,Nargs)){
    if(I-3>Nr){ 
      break;
    }
    Dt<- varargin[[I]]
    if(mode(Dt)!="list"){
      Putcell(TbL,K,Row,Dpos,Dt)  # 110308
      K<- K+1
    }
    else{
      N<- length(Dt)
      Str<- Dt[[N]]
      Crng<- c(K,K+1)
      Pos<- Dpos
      for (J in Looprange(1,N-1)){
        Tmp<- Dt[[J]]
        if(mode(Tmp)=="numeric"){
          Crng<- c(K,K+Tmp)
        }
        if(mode(Tmp)=="character"){
          Pos<- Tmp
        }
      }
      Putcell(TbL,Crng,Row,Pos,Str)
      K<- Crng[2]
    }
  }
}

Putrowexpr<- function(...)
{
  varargin<- list(...)
  Nargs<- length(varargin)
  TbL<- varargin[[1]]
  if(mode(TbL)!="list"){
    return("Tabledata missing")
  }
  Row<- varargin[[2]]
  Nr<- length(TbL[[2]])+1
  K<- 1
  Dpos<- varargin[[3]]
  for (I in Looprange(4,Nargs)){
    if(I-3>Nr){ 
      break;
    }
    Dt<- varargin[[I]]
    if(mode(Dt)!="list"){
      Dt<- paste("$",Dt,"$",sep="")
      Putcell(TbL,K,Row,Dpos,Dt)  #110308
      K<- K+1
    }
    else{
      N<- length(Dt)
      Str<- paste("$",Dt[[N]],"$",sep="")
      Crng<- c(K,K+1)
      Pos<- Dpos
      for (J in Looprange(1,N-1)){
        Tmp<- Dt[[J]]
        if(mode(Tmp)=="numeric"){
          Crng<- c(K,K+Tmp)
        }
        if(mode(Tmp)=="character"){
          Pos<- Tmp
        }
      }
      Putcell(TbL,Crng,Row,Pos,Str)
      K<- Crng[2]
    }
  }
}

####################################################

Putrowstr<- function(...)
{
  varargin<- list(...)
  Nargs<- length(varargin)
  Tb<- varargin[[1]]
  Nr<- varargin[[2]]
  Pos<- varargin[[3]]
  Str<- varargin[[4]]
  Sep<- ""
  if(Nargs>4){
    Sep<- varargin[[5]]
  }
  if(nchar(Sep)==0){
    for (I in Looprange(1,nchar(Str))){
      Tmp<- substr(Str,I,I)
      Putcell(Tb,I,Nr,Pos,Tmp)
    }
  }
  else{
    Ltr<- ""
    K<- 1
    for (I in Looprange(1,length(Str))){
      Tmp<- substr(Str,I,I)
      if(Tmp==Sep){
        Putcell(Tb,K,Nr,Pos,Ltr)
        K<- K+1
        Ltr<- ""
      }
      else{
        Ltr<- paste(Ltr,Tmp,sep="")
      }
    }
    if(nchar(Ltr)>0){
      Putcell(Tb,K,Nr,Pos,Ltr)
    }
  }
}

############################################
# 11.05.28

Ratiocmyk<- function(Color)
{
  if(is.numeric(Color)){
    return(Color)
  }
  R<- 
  switch(Color,
    greenyellow=c(0.15,0,0.69,0),
    yellow=c(0,0,1,0),
    goldenrod=c(0,0.1,0.84,0),
    dandelion=c(0,0.29,0.84,0),
    apricot=c(0,0.32,0.52,0),
    peach=c(0,0.5,0.7,0),
    melon=c(0,0.46,0.5,0),
    yelloworange=c(0,0.42,1,0),
    orange=c(0,0.61,0.87,0),
    burntorange=c(0,0.51,1,0),
    bittersweet=c(0,0.75,1,0.24),
    redorange=c(0,0.77,0.87,0),
    mahogany=c(0,0.85,0.87,0.35),
    maroon=c(0,0.87,0.68,0.32),
    brickred=c(0,0.89,0.94,0.28),
    red=c(0,1,1,0),
    orangered=c(0,1,0.5,0),
    rubinered=c(0,1,0.13,0),
    wildstrawberry=c(0,0.96,0.39,0),
    salmon=c(0,0.53,0.38,0),
    carnationpink=c(0,0.63,0,0),
    magenta=c(0,1,0,0),
    violetred=c(0,0.81,0,0),
    rhodamine=c(0,0.82,0,0),
    mulberry=c(0.34,0.9,0,0.02),
    redviolet=c(0.07,0.9,0,0.34),
    fuchsia=c(0.47,0.91,0,0.08),
    lavender=c(0,0.48,0,0),
    thistle=c(0.12,0.59,0,0),
    orchid=c(0.32,0.64,0,0),
    darkorchid=c(0.4,0.8,0.2,0),
    purple=c(0.45,0.86,0,0),
    plum=c(0.5,1,0,0),
    violet=c(0.79,0.88,0,0),
    royalpurple=c(0.75,0.9,0,0),
    blueviolet=c(0.86,0.91,0,0.04),
    periwinkle=c(0.57,0.55,0,0),
    cadetblue=c(0.62,0.57,0.23,0),
    cornflowerblue=c(0.65,0.13,0,0),
    midnightblue=c(0.98,0.13,0,0.43),
    navyblue=c(0.94,0.54,0,0),
    royalblue=c(1,0.5,0,0),
    blue=c(1,1,0,0),
    cerulean=c(0.94,0.11,0,0),
    cyan=c(1,0,0,0),
    processblue=c(0.96,0,0,0),
    skyblue=c(0.62,0,0.12,0),
    turquoise=c(0.85,0,0.2,0),
    tealblue=c(0.86,0,0.34,0.02),
    aquamarine=c(0.82,0,0.3,0),
    bluegreen=c(0.85,0,0.33,0),
    emerald=c(1,0,0.5,0),
    junglegreen=c(0.99,0,0.52,0),
    seagreen=c(0.69,0,0.5,0),
    green=c(1,0,1,0),
    forestgreen=c(0.91,0,0.88,0.12),
    pinegreen=c(0.92,0,0.59,0.25),
    limegreen=c(0.5,0,1,0),
    yellowgreen=c(0.44,0,0.74,0),
    springgreen=c(0.26,0,0.76,0),
    olivegreen=c(0.64,0,0.95,0.4),
    rawsienna=c(0,0.72,1,0.45),
    sepia=c(0,0.83,1,0.7),
    brown=c(0,0.81,1,0.6),
    tan=c(0.14,0.42,0.56,0),
    gray=c(0,0,0,0.5),
    black=c(0,0,0,1),
    white=c(0,0,0,0)
  )
  if(length(R)<4){
    print("No color")
    return(c())
  }
  return(R)
}

############################################
# 11.01.07

Readtextdata<- function(...)
{
  varargin<- list(...)
  OutL<- list()
  Nargs<- length(varargin)
  Fname<- varargin[[1]]
  Tmp<- readLines(Fname,n=1)
  if(length(grep("\t",Tmp))>0){
    Sep<- "\t"
  }
  else if(length(grep(",",Tmp))>0){
    Sep<- ","
  }
  else{
    Sep<- " "
  }
  Hajime<- c(1,1)
  Owari<- c(Inf,Inf)
  C<- Inf
  R<- Inf
  Rna<- FALSE
  Cna<- TRUE
  Mat<- FALSE
  Num<- TRUE
  D<- -Inf
  Flg<- 0
  for (I in Looprange(2,Nargs)){
    Tmp<- varargin[[I]]
    if(mode(Tmp)=="numeric"){
      if  (Flg==0){
        Hajime<- Tmp
        Flg<- 1
      }
      else{
        Owari<- Tmp
      }
    }
    else{
      eval(parse(text=Tmp))
    }
  }
  Tmp<- Hajime+c(R-1,C-1)
  Owari<- c(min(Owari[1],Tmp[1]),min(Owari[2],Tmp[2]))
  if(Cna){
    Df<- read.table(Fname,sep=Sep,header=TRUE,,stringsAsFactors=FALSE)
  }
  else{
    Df<- read.table(Fname,sep=Sep,header=FALSE,,stringsAsFactors=FALSE)
    Nv<- c(1:ncol(Df))
    colnames(Df)<- Nv
  }
  if(Rna){
    rownames(Df)<-Df[,1]
    Hajime<- Hajime+c(0,1)
  }
  if(Mat){
    M<- as.matrix(Df)
    Tmp1<- min(Owari[1],nrow(M))
    Tmp2<- min(Owari[2],ncol(M))
    Out<- as.matrix(M[Hajime[1]:Tmp1,Hajime[2]:Tmp2])
    if(Num){
      Tmp1<- as.numeric(Out)
      Out<- matrix(Tmp1,nrow=nrow(Out))
    }
  }
  else{
    Tmp1<- min(Owari[1],nrow(Df))
    Tmp2<- min(Owari[2],ncol(Df))
    Out<- Df[Hajime[1]:Tmp1,Hajime[2]:Tmp2]
  }
  if(D!=-Inf){  # 11.01.20 v2
    Tmp<- ncol(Out) # 11.01.07
    Tmp1<- rep(Inf,Tmp) 
    Out[Out[,1]<=D,]<- Tmp1 # 11.01.07
  }
  return(Out)
}

##################################

Reflectdata<- function(...)
{
  varargin<- list(...)
  Nargs<- length(varargin)    
  Eps<- 10^(-8)
  ML<- varargin[[1]]
  if(Mixtype(ML)==1){
    ML<- list(ML)
  }
  if(Nargs==1){
    PtA<- c(0,0); PtB<- PtA
  }
  else{
    Pts<- varargin[[2]]
    if(length(Pts)==2){
      PtA<- Pts; PtB<- PtA
    }
    else{
      PtA<- Pts[1:2]; PtB<- Pts[3:4]
    }
  }  
  ML=Flattenlist(ML) #180603
  OutL<- list()
  for (N in Looprange(1,Length(ML))){
    GL<- Op(N,ML)
    if(!is.matrix(GL)){GL=matrix(GL,ncol=2)} #180603
    Out<- c()
    for (I in Looprange(1,Length(GL))){
      Tmp<- GL[I,]
      X1<- Tmp[1]
      Y1<- Tmp[2]
      if(X1==Inf){
        X2<- X1
        Y2<- Y1
      }
      else{
        if(Norm(PtA-PtB)<Eps){
          X2<- 2*PtA[1]-X1
          Y2<- 2*PtA[2]-Y1
        }
        else{  
          U<- PtB[1]-PtA[1]
          V<- PtB[2]-PtA[2]
          A<- PtA[1]
          B<- PtA[2]
          X2<- (U^2-V^2)/(U^2+V^2)*X1+2*U*V/(U^2+V^2)*Y1
          X2<- X2-2*V*(U*B-V*A)/(U^2+V^2)
          Y2<- 2*U*V/(U^2+V^2)*X1-(U^2-V^2)/(U^2+V^2)*Y1
          Y2<- Y2+2*U*(U*B-V*A)/(U^2+V^2)
        }
      }
      Out<- Appendrow(Out,c(X2,Y2))
    }
    OutL<- Mixjoin(OutL,list(Out))
  }
  if(length(OutL)==1){
    OutL<- Op(1,OutL)
  }
  return(OutL)
}

##########################################

Writetextdata<- function(...)
{
  varargin<- list(...)
  OutL<- list()
  Nargs<- length(varargin)
  Data<- varargin[[1]]
  Fname<- varargin[[2]]
  Sep=","
  for (I in Looprange(3,Nargs)){
    Tmp<- varargin[[I]]
    eval(parse(text=Tmp))
  }
  write.table(Data,Fname,sep=Sep,row.names=FALSE,na="")
}

##########################################
#  2014.12.17
#  2015.10.29

WriteOutData<- function(...){
  varargin<- list(...)
  Nargs<- length(varargin)
#  if modulo(Nargs,2)==0 then
#    Fname=Fnameout;
#    Nst=1;
#  else
  Fname=varargin[[1]]
  Nst=2;
#  end;
  for(N in seq(Nst,Nargs,by=2)){
    Gname=varargin[[N]]
    Tmp=paste(Gname,"//",sep="")
    if(N==Nst){
      cat(Tmp,"\n",sep="",file=Fname)
    }
    else{
      cat(Tmp,"\n",sep="",file=Fname,append=TRUE)
    }
    Gdata=varargin[[N+1]]
    Gdata=Flattenlist(Gdata)
    if(!is.list(Gdata)){Gdata=list(Gdata)}
    for(K in Looprange(1,length(Gdata))){
      GL=Dividegraphics(Gdata[[K]])
#      for(J in seq(1,length(GL))){
      for(J in Looprange(1,length(GL))){
        cat("start//","\n",sep="",file=Fname,append=TRUE)
        Str=""
        Iend=Numptcrv(GL[[J]])
#        for(II in seq(1,Iend)){
        for(II in Looprange(1,Iend)){
          Pt=Ptcrv(II,GL[[J]])
          if(nchar(Str)>0){
            Str=paste(Str,",",sep="")
          }
          if(length(Pt)<3){
            Str=paste(Str,sprintf("[%5.5f,%5.5f]",Pt[1],Pt[2]),sep="")
          }
          else{
            Str=paste(Str,sprintf("[%5.5f,%5.5f,%5.5f]",Pt[1],Pt[2],Pt[3]),sep="")
          }
          if(nchar(Str)>80){
            cat("[",Str,"]//","\n",sep="",file=Fname,append=TRUE)
            Str=""
          }
        }
        if(nchar(Str)>0){
          cat("[",Str,"]//","\n",sep="",file=Fname,append=TRUE)
        }
        if((N==Nargs-1) & (K==length(Gdata)) & (J==length(GL))){
#          cat("end////","\n",sep="",file=Fname,append=TRUE)
          cat("end//","\n",sep="",file=Fname,append=TRUE)
        }
        else{
          cat("end//","\n",sep="",file=Fname,append=TRUE)
        }
      }
    }
  }
  cat("//","\n",sep="",file=Fname,append=TRUE) # 15.11.05
}

######  Old  ####################################
#  2015.10.23
ReadOutData<- function(...){
  varargin<- list(...)
  Nargs<- length(varargin)
  Fname=varargin[[1]]
  cmdall=readLines(Fname)
  cmdall=gsub("//","",cmdall,fixed=TRUE)
  varname=cmdall[1]
  outdt=list()
  varL=c()
  ptL=list()
  flg=0
  for(cmd in cmdall){
    if(nchar(cmd)>0){
      if((cmd=="start") | cmd=="end" | substring(cmd,1,1)=="["){
        if(cmd=="start"){
          pts=c()
        }
        if(cmd=="end"){
          ptL=c(ptL,list(pts))
        }
        if(substring(cmd,1,1)=="["){
          tmp1=paste(",",substring(cmd,2,nchar(cmd)-1),sep="")
          tmp1=strsplit(tmp1,"]",fixed=TRUE)
          tmp1=tmp1[[1]]
          tmp1=gsub(",[","c(",tmp1,fixed=TRUE)
		  for(st in tmp1){
            tmp=eval(parse(text=paste(st,")",sep="")))
            pts=rbind(pts,tmp)
          }
          row.names(pts)=1:nrow(pts)
        }
      }
      else{
        varname=cmd
        varL=c(varL,varname)
        if(flg==0){  # 17.10.07from
          flg=1
        }else{
          outdt=c(outdt,list(ptL))
        }  # 17.10.07until
        ptL=c()
      }
    }
  }
  outdt=c(outdt,list(ptL))  # 17.10.07
  names(outdt)=varL
  for(var in varL){
    tmp=paste(var,"<<- outdt$",var,sep="")
    eval(parse(text=tmp))
  }
#  print(varL)
  outdt
}

####################################################

ReadOutData<- function(...){ #2017.10.23
  varargin<- list(...)
  Nargs<- length(varargin)
  Fname=varargin[[1]]
  cmdall=readLines(Fname)
  cmdall=gsub("//","",cmdall,fixed=TRUE)
  varname=""#17.12.13 cmdall[1]
  outdt=list()
  varL=c()
  ptL=list()
  flg=0
  for(cmd in cmdall){
    if(nchar(cmd)>0){
      if((cmd=="start") | cmd=="end" | substring(cmd,1,1)=="["){
        if(cmd=="start"){
          tmp=paste(varname,"<<- c(",varname,",list(c()))",sep="")
          eval(parse(text=tmp))
          Ctr=Ctr+1
        }
        if(cmd=="end"){
        }
        if(substring(cmd,1,1)=="["){
          tmp1=paste(",",substring(cmd,2,nchar(cmd)-1),sep="")
          tmp1=strsplit(tmp1,"]",fixed=TRUE)
          tmp1=tmp1[[1]]
          tmp1=gsub(",[","c(",tmp1,fixed=TRUE)
		  for(st in tmp1){
            tmp=paste(varname,"[[",as.character(Ctr),"]]",sep="")
            tmp=paste(tmp,"<<- rbind(",tmp,",",st,"))",sep="")#
            eval(parse(text=tmp))
          }
        }
      }
      else{
          # 17.12.13from
          if(nchar(varname)>0){
            tmp=paste("if(length(",varname,")==1){",varname,"<<- ",varname,"[[1]]}",sep="")
            eval(parse(text=tmp))
          }
          # 17.12.13until
        varname=cmd
        tmp=paste(varname,"<<- list()",sep="")
        eval(parse(text=tmp))
        Ctr=0
        if(flg==0){  # 17.10.07from
          flg=1
        }else{
        }  # 17.10.07until
      }
    }
  }
  # 17.12.13from
  tmp=paste("if(length(",varname,")==1){",varname,"<<- ",varname,"[[1]]}",sep="")
  eval(parse(text=tmp))
  # 17.12.13until
}

####################################################

Rotatedata<- function(..., deg=FALSE)
{
  varargin<- list(...)
  Nargs<- length(varargin)
  Eps<- 10^(-8)
  ML<- varargin[[1]]
  if(Mixtype(ML)==1){
    ML<- list(ML)
  }
  Theta<- varargin[[2]]
  if(deg) Theta<- Theta*pi/180    # 10.12.07
  if(Nargs==2){
    Pt<- c(0,0)
  }
  else{ 
    Pt<- varargin[[3]]
  }
  ML=Flattenlist(ML) #180603
  Cx<- Pt[1]; Cy<- Pt[2]
  OutL<- c()
  for (N in Looprange(1,Length(ML))){
    GL<- Op(N,ML)
    if(!is.matrix(GL)){GL=matrix(GL,ncol=2)} #180603
    Out<- c()
    for (I in Looprange(1,Length(GL))){
      Tmp<- GL[I,]
      X1<- Tmp[1]         
      Y1<- Tmp[2]    
      if(X1==Inf){
        X2<- X1
        Y2<- Y1
      }
      else{
        X2<- Cx+(X1-Cx)*cos(Theta)-(Y1-Cy)*sin(Theta)
        Y2<- Cy+(X1-Cx)*sin(Theta)+(Y1-Cy)*cos(Theta)
      }
      Out<- Appendrow(Out,c(X2,Y2))
    }
    if(nrow(Out)==1){
      Out<- Out[1,]
    }
    OutL<- Mixjoin(OutL,list(Out))
  }
  if(length(OutL)==1){
    OutL<- Op(1,OutL)
  }
  return(OutL)
}

###############################################

Scaledata<- function(...)
{
  varargin<- list(...)
  Nargs<- length(varargin)    
  Eps<- 10^(-8)
  ML<- varargin[[1]]
  if(Mixtype(ML)==1){
    ML<- list(ML)
  }
  A<- varargin[[2]]
  B<- varargin[[3]]
  if(Nargs==3){
    Pt<- c(0,0)
  }
  else{
    Pt<- varargin[[4]]
  }
  ML=Flattenlist(ML) #180603
  OutL<- list()
  for (N in Looprange(1,Length(ML))){
    GL<- Op(N,ML)
    if(!is.matrix(GL)){GL=matrix(GL,ncol=2)} #180603
    Out<- c()
    for (I in Looprange(1,Length(GL))){
      Tmp<- GL[I,]
      X1<- Tmp[1]         
      Y1<- Tmp[2]    
      if(X1==Inf){
        X2<- X1
        Y2<-Y1
      }
      else{
        X2<- Pt[1]+A*(X1-Pt[1])
        Y2<- Pt[2]+B*(Y1-Pt[2])
      }
      Out<- Appendrow(Out,c(X2,Y2))
    }
    OutL<- Mixjoin(OutL,list(Out))
  }
  if(length(OutL)==1){
    OutL<- Op(1,OutL)
  }
  return(OutL)
}

################################

Setarrow<- function(...)
{
  varargin<- list(...)
  Nargs<- length(varargin)
  if(Nargs==0){
    Str<- paste("Size=",YaSize,",","Angle=",YaAngle,",",sep="")
    Str<- paste(Str,"Position=",YaThick,",","Style=",YaStyle,sep="")
    return(Str)
  }
  Flg<- 0
  for (I in 1:Nargs){
    Tmp<- varargin[[I]]
    if(mode(Tmp)=="numeric"){
      Flg<- Flg+1
      if(Flg==1) YaSize<<-Tmp
      if(Flg==2){
        if(Tmp<5){
          YaAngle<<- 18*Tmp
        }
        else{
          YaAngle<<- Tmp
        }
      }
      if(Flg==3) YaPosition<<- Tmp
      if(Flg==4) YaThick<<- Tmp
    }
    if(mode(Tmp)=="character"){
      YaStyle<<- Tmp
    }
  }
}

####################################

Setax<- function(...)
{
  varargin<- list(...)
  Nargs<- length(varargin)
  if(Nargs==0){ #180821(next 2 lines)
    Str<- paste(ZIKU,",",XNAME,",",XPOS,",",sep="")
    Str<- paste(Str,YNAME,",",YPOS,",",ONAME,",",OPOS,sep="")
    return(Str)
  }
  ArgL<- c()
  Tmp<- varargin[[1]]
  if(is.numeric(Tmp)){ #180821
    Is<- varargin[[1]]
    ArgL<- c()
    for (I in Looprange(1,Is-1)){
      ArgL<- c(ArgL,"")
    }
    for (I in Looprange(2,Nargs)){
      ArgL<- c(ArgL,varargin[[I]])
    }
  }
  else{ #180821from
    for (I in Looprange(1,Nargs)){
       ArgL<- c(ArgL,varargin[[I]])
    }
  }
  for (I in Looprange(length(ArgL)+1,7)){
    ArgL<- c(ArgL,"")
  } #180821to
  Xn<- ArgL[2]; Xp<- ArgL[3]
  Yn<- ArgL[4]; Yp<- ArgL[5]
  On<- ArgL[6]; Op<- ArgL[7]
  ZIKU<<- ArgL[1] #180821
  if(nchar(Xn)>0){
    XNAME<<- paste("$",Xn,"$",sep="")
  }
  if(nchar(Xp)>0){
    XPOS<<- Xp 
  }
  if(nchar(Yn)>0){
    YNAME<<- paste("$",Yn,"$",sep="")
  }
  if(nchar(Yp)>0){
    YPOS<<-Yp
  }
  if(nchar(On)>0){
    ONAME<<- On
  }
  if(nchar(Op)>0){
    OPOS<<- Op
  }
  Out<- "";
}

#################################
#  11.08.24

Setcolor<- function(...){
  varargin<- list(...)
  Color<- 'black'
  Kosa<- 1
  for(J in Looprange(1,length(varargin))){
    Tmp<- varargin[[J]]
    if(is.character(Tmp)) Color<- Tmp
    if(is.numeric(Tmp)){
      if(length(Tmp)==1){#  11.08.24
        Kosa<- Tmp
      }
      else{
        Color<- Tmp
      }
    }#  11.08.24
  }
  Iro<- Ratiocmyk(Color)
  if(length(Iro)==0) return(c())
  if(length(Iro)==4){ #180602from
    Str<- "\\color[cmyk]{"
  }else{
    Str<- "\\color[rgb]{"
  } #180602to
  for(J in 1:length(Iro)){
    Str<- paste(Str,as.character(Kosa*Iro[J]),sep="")
    if(J<length(Iro)){ #180603
      Str<- paste(Str,",",sep="")
    }
  }
  Str<- paste(Str,"}",sep="")
  Texcom(Str)
}

##################################

Setmarklen<- function(...)
{
  varargin<- list(...)
  Nargs<- length(varargin)
  if(Nargs==0){
    Tmp<- MARKLENNow/MARKLENInit
    Tmp=round(Tmp*100)/100
    return(Tmp)
  }
  Size<- varargin[[1]]
  MARKLENNow<<- MARKLENInit*Size
  MARKLEN<<- MARKLENNow*1000/2.54/MilliIn
}

###############################

Setorigin<- function(...)
{
  varargin<- list(...)
  Nargs<- length(varargin)
  if(Nargs==0){
    return(GENTEN)
  }
  Pt<- varargin[[1]]
  GENTEN<<- Pt;
}

################################

Setscaling<- function(...){
  varargin<- list(...)
  Nargs<- length(varargin)
  if(Nargs==0){
    return(c(SCALEX,SCALEY,LOGX,LOGY))
  }
  Tmp=varargin[[1]] #181020from
  if((Nargs==1)&&(is.numeric(Tmp))){
    SCALEY<<- Tmp
	return(invisible(c(SCALEX,SCALEY,LOGX,LOGY)))
  }
  nCtr=1 #181020to
  for (I in 1:Nargs){
    Tmp<- varargin[[I]]
    if(mode(Tmp)=="numeric"){
      if(nCtr==1)SCALEX<<- Tmp #181020(2llines)
      if(nCtr==2)SCALEY<<- Tmp
      nCtr=nCtr+1
    }
    if(mode(Tmp)=="character"){
      if(Tmp=="l"){
        LOGX<<- 0
        LOGY<<- 1
      }else if(Tmp=="ll"){
        LOGX<<- 1
        LOGY<<- 1
      }else{
        LOGX<<- 0
        LOGY<<- 0
      }
    }
  }
  Tmp<- c(SCALEX,SCALEY,LOGX,LOGY)
}

#########################################

Setpen<-function(Width)
{
  PenThick<<-round(PenThickInit*Width)
  Str=paste("\\special{pn ", as.character(PenThick),"}%\n",sep="")
  cat(Str,file=Wfile,append=TRUE)
}

##############################################

Setpt<- function(...)
{
  varargin<- list(...)
  Nargs<- length(varargin)
  if(Nargs==0)
  {
    Tmp<- TenSize/TenSizeInit
    Tmp<- round(Tmp*100)/100
    return(Tmp)
  }
  Size<- varargin[[1]]
  TenSize<<- TenSizeInit*Size;
}

##############################################

Setunitlen<-function(...)
{
  varargin<-list(...)
  if(length(varargin)==0){
    return(ULEN)
  }
  Ul=varargin[[1]]
  Dx<-XMAX-XMIN
  Dy<-YMAX-YMIN
  Sym<-".0123456789 +-*/"
  SL<-Sym
  OL<-"+-*/"
  if(nchar(Ul)>0){
    ULEN<<-Ul
  }
  Is<-1
  VL<-""
  Ucode<-ULEN
  for (I in 1:nchar(Ucode)){
    C<-substring(Ucode,I,I)
    if(length(grep(C,SL))>0){
      if(length(grep(C,OL))>0){
        Tmp<-substring(Ucode,Is,I-1)
        Str<-paste(VL,Tmp,C,sep="")
        VL<-Str
        Is<-I+1
      }
    }
    else{
      Unit<-substring(Ucode,I,I+1)
      Str<-substring(Ucode,Is,I-1)
      VL<-paste(VL,Str,sep="")
      break;
    }
  }
  Valu<-eval(parse(text=VL))
  Str<-as.character(Valu)
  ULEN<<-paste(Str,Unit,sep="");
  if(Unit=="cm") MilliIn<<-1000/2.54*Valu
  if(Unit=="mm") MilliIn<<-1000/2.54*Valu/10
  if(Unit=="in") MilliIn<<-1000*Valu
  if(Unit=="pt") MilliIn<<-1000/72.27*Valu
  if(Unit=="pc") MilliIn<<-1000/6.022*Valu 
  if(Unit=="bp") MilliIn<<-1000/72*Valu
  if(Unit=="dd2") MilliIn<<-1000/1238/1157/72.27*Valu
  if(Unit=="cc") MilliIn<<-1000/1238/1157/72.27*12*Valu
  if(Unit=="sp") MilliIn<<-1000/72.27/65536*Valu/10
  MARKLEN<<-MARKLENNow*1000/2.54/MilliIn
  MEMORI<<-MEMORINow*1000/2.54/MilliIn  #17.12.17
}

#########################################
# 10.11.20

Setwindow<-function(...)
{
  varargin<-list(...)
  Nargs<-length(varargin)
  if(Nargs==0){
    Out<-c(XMIN,XMAX,YMIN,YMAX)
    return(Out)
  }
  if(Nargs==1){
    Dt<- varargin[[1]]
    if(is.list(Dt) && !is.data.frame(Dt)){
      Tmp<- as.data.frame(Dt)
      Dt<- t(Tmp)
    }
    Xm<- min(Dt[,1])
    XM<- max(Dt[,1])
    Ym<- min(Dt[,2])
    YM<- max(Dt[,2])
	Str<- "Setwindow("
	Str<- paste(Str,"c(",as.character(Xm),",",as.character(XM),"),c(",sep="")
    Str<- paste(Str,as.character(Ym),",",as.character(YM),")",sep="")
	Str<- paste(Str,")",sep="")
    print(Str)
  }
  if(Nargs==2){
    RgX<-varargin[[1]]
    RgY<-varargin[[2]]
    XMIN<<-RgX[1]; XMAX<<-RgX[2]
    YMIN<<-RgY[1]; YMAX<<-RgY[2]
  }
  if(Nargs==4){
    XMIN<<-varargin[[1]]; XMAX<<-varargin[[2]]
    YMIN<<-varargin[[3]]; YMAX<<-varargin[[4]]
 }
 Out<- c(XMIN,XMAX,YMIN,YMAX);
}

#########################################

Shadeold<- function(...)
{           ##  Scaling is implemented
  varargin<- list(...)
  Nargs<- length(varargin)
  Iroflg=0
  Kosa=1
  if(Nargs>1){ 
    Iro=varargin[[Nargs]]
    if(is.character(Iro)){
      Iroflg=1
      if(length(grep("{",Iro))>0){
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
  Tmp=varargin[[1]]
  Data=Kyokai(Tmp)
  Data=list(Data) ####180327
  for (I in Looprange(1, length(Data))){
    PL<- Op(I,Data)
    Mojisu<- 0
    for (J in  1:Nrow(PL)){
      P<- Doscaling(Op(J,PL))
      X<- as.character(round(MilliIn*P[1]))
      Y<- as.character(-round(MilliIn*P[2]))
      Str<- paste("\\special{pa ",X," ",Y,"}",sep="")
      cat(Str,file=Wfile,append=TRUE)
      Mojisu<- Mojisu+nchar(Str)
      if(Mojisu>80){
        cat("%\n",file=Wfile,append=TRUE)
        Mojisu<- 0
      }
    }
    Str1<- paste("\\special{sh ",as.character(Kosa),"}",sep="")
    Str2<- paste("\\special{ip}%\n",sep="")
    cat(Str1,file=Wfile,append=TRUE)
    cat(Str2,file=Wfile,append=TRUE)
  }
  if(Iroflg==1){
    cat("}%\n",file=Wfile,append=TRUE)
  }
}

####### Shade new 17.09.24############

Shade<- function(...)
{           ##  Scaling is implemented
  varargin<- list(...)
  Nargs<- length(varargin)
  Iroflg<- 0
  Kosa<- 1
  if(Nargs>1){
    Iro<- varargin[[Nargs]]
    if(mode(Iro)=="character"){
      Iroflg<- 1
      if(length(grep(Iro,"{"))>0)
        Str<- paste("{\\color",Iro,sep="")
      else
        Str<- paste("{\\color{",Iro,"}",sep="")
    }
    else{
      if(length(Iro)==1)
        Kosa<- Iro
      else{
        Iroflg<- 1
        if(length(Iro)==4)
          Str<- paste("{\\color[cmyk]{",sep="")
        else
          if(length(Iro)==3)
            Str<- paste("{\\color[rgb]{",sep="")
        for (J in Looprange(1,length(Iro))){
          Str<- paste(Str,as.character(Iro[J]),sep="")
          if(J<length(Iro))
            Str<- paste(Str,",",sep="")
        }
        Str<- paste(Str,"}",sep="")
      }
    }
    if(Iroflg==1){
    }
  }
  Tmp<- varargin[[1]]
#  Data<- Kyoukai(Tmp)
  Data= Joincrvs(Tmp) #180929from
  Data=list(Data) #180929to
  for (I in Looprange(1, Length(Data))){ #180621
    PL<- Op(I,Data)
    PL=Appendrow(PL,Op(1,PL)) #180929
    Mojisu<- 0
    for (J in  Looprange(1,Length(PL))){
      P<- Doscaling(Op(J,PL))
      X<- as.character(round(MilliIn*P[1]))
      Y<- as.character(-round(MilliIn*P[2]))
      Str<- paste("\\special{pa ",X," ",Y,"}",sep="")
      cat(Str,file=Wfile,append=TRUE,sep="")
      Mojisu<- Mojisu+nchar(Str)
      if(Mojisu>80){
	    cat("%\n",file=Wfile,append=TRUE,sep="")
        Mojisu<- 0
      }
    }
    Str1<- paste("\\special{sh ",as.character(Kosa),"}",sep="")
    Str2<- paste("\\special{ip}%\n",sep="")
    cat(Str1,file=Wfile,append=TRUE,sep="")
    cat(Str2,file=Wfile,append=TRUE,sep="")
  }
  if(Iroflg==1){
    cat("}%\n",file=Wfile,append=TRUE,sep="")
  }
}

##############################################
# 11.01.07

Splinedata<- function(...)
{
  varargin<- list(...)
  Nargs<- length(varargin)
  Eps<- 10^(-3)
  PL<- varargin[[1]]
  if(mode(PL)=="character"){
    Fname<- PL
    PL<- Readtextdata(Fname)
  }
  else{
    PL<- as.matrix(PL)
    if(Nrow(PL)==1){
      PL<- matrix(PL, nrow=length(PL)/2)
      PL<- t(PL)
    }
  }
  if(ncol(PL)==3){
    Flg3<- 1
  }
  else{
    Flg3<- 0
  }
  PLL<- Dividegraphics(PL)
  N<- 50
  C<- c()
  for (I in Looprange(2,Nargs)){
    Tmp<- varargin[[I]]
    if(mode(Tmp)!="character") next
    if(length(grep("=",Tmp,fixed=TRUE))>0){
      eval(parse(text=Tmp))
    }
    else{
      Tmp1<- substr(Tmp,1,1)
      if(toupper(Tmp1)=="C"){
        C<- 1:length(PLL)
      }
    }
  }
  Cflg<- rep(0,length(PLL))
  for(J in Looprange(1,length(C))){
  	K<- C[J]
  	Cflg[K]<- 1
  }
  if(length(N)>1){
    Nj<- as.numeric(N)
  }
  else{
    Tmp<- lapply(PLL,nrow)
    Tmp1<- as.numeric(Tmp)
    MxP<- max(Tmp1)
    Nj<- c()
    for (J in 1:length(PLL)){
      Tmp<- nrow(PLL[[J]])
      Tmp1<- round(N/MxP*(Tmp-1))
      Nj<- c(Nj,Tmp1)
    }
  }
  OutL<- list()
  for(J in 1:length(PLL)){
    PL<- PLL[[J]]
    if(Cflg[J]==1){
      if(Norm(PL[1,]-PL[Nrow(PL),])>Eps){
        PL<-Appendrow(PL,PL[1,])
        Nj[J]=round(N/MxP*nrow(PL))
      }
      else{
        PL[Nrow(PL),]<- PL[1,]
      }
    }
    Tn<- 1:Nrow(PL)
    Xn<- PL[,1]
    Yn<- PL[,2]
    if(Flg3==1) Zn<- PL[,3]
    if(Cflg[J]==0){
      Dxn<- spline(Tn,Xn,n=Nj[J])
      Dyn<- spline(Tn,Yn,n=Nj[J])
      if(Flg3==1) Dzn<- spline(Tn,Zn,n=Nj[J])
    }
    else{
      Dxn<- spline(Tn,Xn,method="periodic")
      Dyn<- spline(Tn,Yn,method="periodic")
      if(Flg3==1) Dzn<- spline(Tn,Zn,method="periodic")
    }
    Tmp1<- Dxn$y
    Tmp2<- Dyn$y
    Tmp3<-c()
    if(Flg3==1) Tmp3<- Dzn$y
    Out<- matrix(c(Tmp1,Tmp2,Tmp3),nrow=length(Tmp1))
    OutL<- c(OutL,list(Out))
  }
  return(OutL)
}

############################################
#   2013.05.03  Domain is optional

Tabledata<- function(...){
  varargin<- list(...)
  Eps<- 0.001
  Tmp<- varargin[[1]]  # 130503 from
  if(is.numeric(Tmp)){
    Domain<- varargin[[1]]
    VL<- varargin[[2]]
    HL<- varargin[[3]]
  }
  else{
    Domain<- c(-1,-1)
    VL<- varargin[[1]]
    HL<- varargin[[2]]
  } # 130503 until
  Hsize<- Domain[1]
  SvL<- list(0)
  S<- 0
  for (I in Looprange(1,length(VL))){
    Tmp<- VL[[I]]
    S<- S+Tmp[1]
    Tmp[1]<- S
    SvL<- c(SvL,list(Tmp))
  }
  if(Hsize>S){
    SvL<- c(SvL,list(Hsize))
  }
  Hsize<- Op(1,SvL[[length(SvL)]])
  Vsize<- Domain[2]
  ShL<- list(0)
  S<- 0
  for (I in Looprange(1,length(HL))){
    Tmp<- HL[[I]]
    S<- S+Tmp[1]
    Tmp[1]<- S
    ShL<- c(ShL,list(Tmp))
  }
  if(Vsize>S){
    ShL<- c(ShL,list(Vsize))
  }
  Vsize<- Op(1,ShL[[length(ShL)]])
  Marw<- 0; Mare<- 0; Mars<- 0; Marn<- 0
  if(length(Domain)>2){
    Marw<- Domain[3]
    Mare<- Domain[4]
  }
  if(length(Domain)>4){
    Marn<- Domain[5]
    Mars<- Domain[6]
  }
  Setwindow(c(-Marw,Hsize+Mare),c(-Mars,Vsize+Marn))
  Tmp<- Framedata(c(Eps,Hsize-Eps),c(Eps,Vsize-Eps))
  Gdata<- list(Tmp)
  Tmp<- -Marw
  Hdata<- list(Listplot(c(c(Tmp,-Mars),c(Tmp,Vsize+Marn))))
  for (I in Looprange(1,length(SvL))){
    Data<- SvL[[I]]
    X<- Data[1]
    if(length(Data)==1){
      Y1<- 0
      Y2<- Vsize
      G<- Listplot(c(X,Y1),c(X,Y2))
    }
    else{
      G<- c()
      for (J in seq(2,length(Data),by=2)){
        Y1<- Vsize-Op(1,ShL[[Data[J]]])
        Y2<- Vsize-Op(1,ShL[[Data[J+1]]])
        Tmp<- Listplot(c(c(X,Y1),c(X,Y2)))
        Tmp1<- Appendrow(G,c(Inf,Inf))
        G<- Appendrow(Tmp1,Tmp)
      }
      G<- G[2:nrow(G),]
    }
    Hdata<- c(Hdata,list(G))
  }
  Tmp<- Hsize+Mare
  Tmp1<- Listplot(c(c(Tmp,-Mars),c(Tmp,Vsize+Marn)))
  Hdata<- c(Hdata,list(Tmp1))
  Tmp<- Vsize+Marn
  Vdata<- list(Listplot(c(c(-Marw,Tmp),c(Hsize+Mare,Tmp))))
  for (I in Looprange(1,length(ShL))){
    Data<- ShL[[I]]
    Y<- Vsize-Data[1]
    if(length(Data)==1){
      X1<- 0
      X2<- Hsize
      G<- Listplot(c(X1,Y),c(X2,Y))
    }
    else{
      G<- c()
      for (J in seq(2,length(Data),by=2)){
        X1<- Op(1,SvL[[Data[J]]])
        X2<- Op(1,SvL[[Data[J+1]]])
        Tmp<- Listplot(c(X1,Y),c(X2,Y))
        G<- Appendrow(G,c(Inf,Inf))
        G<- Appendrow(G,Tmp)
      }
      G<-G[2:nrow(G),]
    }
    Vdata<- c(Vdata,list(G))
  }
#  Tmp<- Listplot(c(c(0,0),c(Hsize,0)))  # 2011.03.02
#  Vdata<- Mixjoin(Vdata,list(Tmp))
  Tmp<- Listplot(c(c(-Marw,-Mars),c(Hsize+Mare,-Mars)))
  Vdata<- Mixjoin(Vdata,list(Tmp))
  Tmp1<- Hdata[Looprange(3,length(Hdata)-2)]
  Tmp2<- Vdata[Looprange(3,length(Vdata)-2)]
  Gdata<- Mixjoin(Gdata,Tmp1,Tmp2)
  Hind<- Looprange(2,1+length(Tmp1))
  Vind<- Looprange(2+length(Tmp1),1+length(Tmp1)+length(Tmp2))
  G=Gdata[[1]]
  P1<- Ptsw(G); P2<- Ptnw(G)
  Q1<- Ptse(G); Q2<- Ptne(G)
  Tmp1<- list(Listplot(c(P1,P2)),Listplot(c(Q1,Q2)))
  P1<- Ptnw(G); P2<- Ptne(G)
  Q1<- Ptsw(G); Q2<- Ptse(G)
  Tmp2<- list(Listplot(c(P1,P2)),Listplot(c(Q1,Q2))) 
  Tmp3<- Framedata()
  Out<- list(Gdata,Hind,Vind,Tmp1,Tmp2,Tmp3)
  return(Out)
}

################################

Texcom<- function(Meirei)
{
  if(Meirei=="\\thinlines"){
    Setpen(1);
    return();
  }
  if(Meirei=="\\thicklines"){
    Setpen(2);
    return()
  }
  if(Meirei=="\\Thicklines"){
    Setpen(3);
    return()
  }
  if(length(Meirei)==0){  # 09.12.07
    Tmp<- c()
  }
  else{
    Tmp<- grep("newline",Meirei) 
  }
  if(length(Tmp)>0){
    cat("\n",file=Wfile,append=TRUE);
  }
  else{
    Tmp<- paste(Meirei,"%\n",sep="")
	Tmp<- gsub("//","\\",Tmp,fixed=TRUE) # 11.03.02
    cat(Tmp,file=Wfile,append=TRUE);
  }
}

###############################################

Texctr<- function(N){
  if(is.numeric(N)){
    Alpha<- "abcdefghijklmnopqrstuvwxyz"
    Out<- paste("ketpicctr",substr(Alpha,N,N),sep="")
  }
  else{
    if(grep("\\",N,fixed=TRUE)>0){
      Out<- substr(N,2,nchar(N))
    }
	else{
      Out<- N
    }
  }
  return(Out)
}

###############################################

Texelse<- function (){
  Texcom("");
  Texcom("\\else")
}

###############################################

Texend<- function()
{
  Texcom("%\n}")
}

###############################################

Texendfor<- function(I){
  Last<- TEXFORLAST[[TEXFORLEVEL]]
  Texcom("")
  Tmp<- paste("\\ifnum",Texthectr(I),"<",Last,sep="")
  Texcom(Tmp)
  Texcom("\\repeat")
  Texcom("}")
  TEXFORLEVEL<<- TEXFORLEVEL-1
  TEXFORLAST<<- TEXFORLAST[1:(length(TEXFORLAST)-1)]
}

###############################################

Texendif<- function(){
  Texcom("")
  Texcom("\\fi")
  Texcom("}")
}

###############################################

Texfor<- function(I,First,Last){
  TEXFORLEVEL<<- TEXFORLEVEL+1;
  Texsetctr(I,"0")
  Texsetctr(I,paste(as.character(First),"-1",sep=""))
  Texcom("")
  Texcom("{")
  Texcom("\\loop")
  Texsetctr(I,"+1")
  TEXFORLAST<<- c(TEXFORLAST,as.character(Last))
}

###############################################

Texforinit<- function(){
  TEXFORLEVEL<<- 0
  TEXFORLAST<<- list()
}

###############################################

Texif<- function(...){
  varargin<- list(...)
  Condstr<- varargin[[1]]
  Tp<- 0
  if(length(varargin)>1){
    Tp<- varargin[[2]]
  }
  Texcom("")
  Texcom("{")
  if(Tp==0){
    Texcom("\\ifnum")
  }
  else{
    Texcom("\\ifdim ")
  }
  Texcom(paste(Condstr," ",sep=""))
}

######################################

Texletter<- function(...)
{
  varargin<- list(...)
  Nargs<- length(varargin)
  for (I in seq(1,Nargs,by=3)){
    P<- varargin[[I]]
    X<- P[1]
    if(mode(X)=="numeric"){
      X<- as.character(X)
    }
    Y<- P[2]
    if(mode(Y)=="numeric"){
      Y<- as.character(Y)
    }
    Houkou<- varargin[[I+1]]
    Mojiretu<- varargin[[I+2]]
    Hset<- Houkou
    Vhoko<- "c"
    if(length(grep("n",Hset))>0){
      Vhoko<- "n"
    }
    if(length(grep("s",Hset))>0){
      Vhoko<- "s"
    }
    Hhoko<- "c";
    if(length(grep("e",Hset))>0){
      Hhoko<- "e"
    }
    if(length(grep("w",Hset))>0){
      Hhoko<- "w"
    }
    Hoko<- paste(Vhoko,Hhoko,sep="")
    CalcWidth(Hoko,Mojiretu)
    CalcHeight(Hoko,Mojiretu)
    Tmp<- paste("\\put(",X,",",Y,"){\\hspace*{\\Width}",sep="")
    Str<- paste(Tmp,"\\raisebox{\\Height}{",Mojiretu,"}}%\n",sep="") 
    cat(Str,file=Wfile,append=TRUE)
  }
}

##################################################

Texnewcmd<- function(...)
{
  varargin<- list(...)
  Nargs<- length(varargin)
  Str<- varargin[[1]]    
  S<- paste("\\newcommand{",Str,"}",sep="")
  if(Nargs>1){
    Tmp<- as.character(varargin[[2]])
    S<- paste(S,"[",Tmp,"]",sep="")
  }
  if(Nargs>2){
    Tmp<- varargin[[3]]
    if(mode(Tmp)=="numeric"){
      Tmp<- as.character(Tmp)
    }
    S<- paste(S,"[",Tmp,"]",sep="")
  }
  S<- paste(S,"{",sep="")
  Texcom(S)
}

###############################################

Texnewctr<- function(N)
{
  if(mode(N)=="character"){
    Str<- paste("\\newcounter{",N,"}",sep="")
    Texcom(Str)
  }
  else{
    for (I in N){
      Str<- paste("\\newcounter{",Texctr(I),"}",sep="")
      Texcom(Str)
    }
  }
}
###############################################

Texrenewcmd<- function(...)
{
  varargin<- list(...)
  Nargs<- length(varargin)
  Str<- varargin[[1]]    
  S<- paste("\\renewcommand{",Str,"}",sep="")
  if(Nargs>1){
    Tmp<- as.character(varargin[[2]])
    S<- paste(S,"[",Tmp,"]",sep="")
  }
  if(Nargs>2){
    Tmp<- varargin[[3]]
    if(mode(Tmp)=="numeric"){
      Tmp<- as.character(Tmp)
    }
    S<- paste(S,"[",Tmp,"]",sep="")
  }
  S<- paste(S,"{",sep="")
  Texcom(S)
}

###############################################

Texsetctr<- function(Nctr,Opstr)
{
  Ctr<- Texctr(Nctr)
  Opstr<- paste(Opstr,"%",sep="")
  OperL<- "+-*/%"
  Oper<- ""
  Va<- ""
  Evflg<- 0
  Paflg<- 0
  for (I in Looprange(1,nchar(Opstr))){
    Tmp<- substring(Opstr,I,I)
    if(Tmp=="("){
      Paflg<- 1
      if(nchar(Va)>0){
        Evflg<- 1
        Va<- paste(Va,Tmp,sep="")
      }
      next
    }
    if(Tmp==")"){
      Paflg<- 0
      if(Evflg>0){
        Va<- paste(Va,Tmp,sep="")
      }
      next
    }
    if(Paflg>0){
      Va<- paste(Va,Tmp,sep="")
      next
    }
    if(length(grep(Tmp,OperL,fixed=TRUE))==0){ #180510
      Va<- paste(Va,Tmp,sep="")
    }
    else{
      if(Evflg>0){
        Tmp1<- eval(parse(text=Va))
        Va<- paste("\\value{",Tmp1,"}",sep="")
        Evflg<- 0
      }
      if(Oper==""){
        if(nchar(Va)>0){
          Str<- paste("\\setcounter{",Ctr,"}{",Va,"}",sep="")
          Texcom(Str)
        }
        Oper<- Tmp
        Va<-""      
      }
      else if(Oper=="+"){
        Str<- paste("\\addtocounter{",Ctr,"}{",Va,"}",sep="")
        Texcom(Str)
        Oper<- Tmp
        Va<-""
      }
      else if(Oper=="-"){
        Str<- paste("\\addtocounter{",Ctr,"}{-",Va,"}",sep="")
        Texcom(Str)      
        Oper<- Tmp
        Va<-""
      }
      else if(Oper=="*"){
        Str<- paste("\\multiply\\value{",Ctr,"} by ",Va,sep="")
        Texcom(Str)      
        Oper<- Tmp
        Va<-""      
      }
      else if(Oper=="/"){
        Str<- paste("\\divide\\value{",Ctr,"} by ",Va,sep="")
        Texcom(Str)      
        Oper<- Tmp
        Va<-"" 
      }
    }
  }
}

###############################################

Texthectr<- function(N)
{
  Out<- paste("\\the",Texctr(N),sep="")
  return(Out)
}

###############################################

Texvalctr<- function(N){
  Out<- paste("\\value{",Texctr(N),"}",sep="")
  return(Out)
}

###############################################

Texvctr<- function(N)
{
  Out<- paste("\\value{",Texctr(N),"}",sep="")
  return(Out)
}

###############################################

Tonumeric <- function(...)
{
  varargin<- list(...)
  Nargs<- length(varargin)
  Data<- varargin[[1]]
  Sp<- c(1,1)
  Ep<- c(Inf,Inf)
  if(Nargs>1){
    Sp<- varargin[[2]]
  }
  if(Nargs>2){
    Ep<- varargin[[3]]
  }
  Nrs<- Sp[1]
  Nre<- min(nrow(Data),Ep[1])
  Ncs<- Sp[2]
  Nce<- min(ncol(Data),Ep[2])
  Tmp1<- Data[Nrs:Nre, Ncs:Nce]
  Tmp2 <- as.numeric(Tmp1)
  Out <- matrix(Tmp2,nrow=nrow(Tmp1))
  Sp<- c()
  for (I in 1:nrow(Out)){
    for (J in 1:ncol(Out)){
      Tmp<- Out[I,J]
      if(!is.na(Tmp)){
        Sp<- c(I,J)
        break;
      }
    }
    if(length(Sp)>0) break
  }
  if(length(Sp)==0){
    return("Numeric data not found")
  }
  Ep<- c(nrow(Out),ncol(Out))
  for (I in Sp[1]:nrow(Out)){
    Tmp<- Out[I,Sp[2]]
    if(is.na(Tmp)){
      Ep[1]<- I-1
      break
    }
  }
  for (J in Sp[2]:ncol(Out)){
    Tmp<- Out[Sp[1],J]
    if(is.na(Tmp)){
      Ep[2]<- J-1
      break
    }
  }
  Out<- Out[Sp[1]:Ep[1], Sp[2]:Ep[2]]
  return(Out)
}

##################################################

Translatedata<- function(...)
{
  varargin<- list(...)
  Nargs<- length(varargin)    
  Eps<- 10^(-8)
  ML<- varargin[[1]]
  if(Mixtype(ML)==1){
    ML<- list(ML)
  }
  Tmp=varargin[[2]]
  if(mode(Tmp)=="numeric" && length(Tmp)>1){
    A<- Tmp[1]; B<- Tmp[2]
  }
  else{
    A<- Tmp
    if(Nargs>=3){
      B<- varargin[[3]]
    }
    else{
      B<- 0
    }
  }
  ML=Flattenlist(ML) #180603
  OutL<- list()
  for (N in Looprange(1,Length(ML))){
    GL<- Op(N,ML)
    if(!is.matrix(GL)){GL=matrix(GL,ncol=2)} #180603
    Out<- c()
    for (I in Looprange(1,Length(GL))){
      Tmp<- GL[I,] #180603
      X1<- Tmp[1]         
      Y1<- Tmp[2]    
      if(X1==Inf){
        X2<- X1
        Y2<-Y1
      }
      else{
        X2<- X1+A
        Y2<- Y1+B
      }
      Out<- Appendrow(Out,c(X2,Y2))
    }
    OutL<- Mixjoin(OutL,list(Out))
  }
  if(length(OutL)==1){
    OutL<- Op(1,OutL)
  }
  return(OutL)
}

#######################################

Unscaling<- function(G)
{
  GLg<- G
  if(class(GLg)=="numeric"){
    GLg<-c(G[1]/SCALEX, G[2]/SCALEY)
    Tmp<-GLg
    if(LOGX==1) Tmp[1]<- 10^(GLg[1])
    if(LOGY==1) Tmp[2]<- 10^(GLg[2])
    return(Tmp)
  }
  else{
    Tmp1<-matrix(c(1/SCALEX,0,0,1/SCALEY),nrow=2)
    GLg<-G %*% Tmp1
    Tmp<-GLg
    if(LOGX==1) Tmp[,1]<- 10^(G[,1])
    if(LOGY==1) Tmp[,2]<- 10^(G[,2])
    return(Tmp)
  }
}

#############################################

Vtickmark<- function(...)
{  ## Scaling is implemented 
  varargin<- list(...)
  Nargs<- length(varargin)
  ArgsL<- varargin
  if(mode(ArgsL[[1]])=="character"){
    Str<- ArgsL[[1]]
    Tmp<- strsplit(Str,"m")
    Tmp<- Tmp[[1]]
    if(length(Tmp)>1){
      I<- nchar(Tmp[1])+1
    }
    else{
      I<- 0
    }
    Tmp<- strsplit(Str,"n")
    Tmp<- Tmp[[1]]
    if(length(Tmp)>1){
      J<- nchar(Tmp[1])+1
    }
    else{
      J<- 0
    }
    Tmp<- strsplit(Str,"r")
    Tmp<- Tmp[[1]]
    if(length(Tmp)>1){
      K=nchar(Tmp[1])+1
    }
    else{
      K<- 0
    }
    if(K>0){
      S<- substr(Str,K+1,nchar(Str))
      R<-  as.numeric(S)
      if(is.na(R)){
        R<- 1
      }
    }
    else{
      R<- 1
      K<- nchar(Str)+1
    }
    if(J>0){
      S<- substr(Str,J+1,K-1)
      Dn<-  as.numeric(S)
      if(is.na(Dn)){
        Dn<- 1
      }
    }
    else{
      Dn<- 1000
      J<- nchar(Str)+1
    }
    S<- substr(Str,I+1,J-1)
    Dm<- as.numeric(S)
    if(is.na(Dm)){
      Dm<- 1
    }
    ArgsL<- list()
    for (I in 1:floor((YMAX-GENTEN[2])/Dm)){
      ArgsL<- Mixjoin(ArgsL,I*Dm)
      if(I-floor(I/Dn)*Dn==0){
        Str<- as.character(I*Dm*R)
        ArgsL<- Mixjoin(ArgsL,Str)
      }
    }
    for (I in seq(-1,ceiling((YMIN-GENTEN[2])/Dm))){
      ArgsL<- Mixjoin(ArgsL,I*Dm)
      if(I-floor(I/Dn)*Dn==0){
        Str<- as.character(I*Dm*R)
        ArgsL<- Mixjoin(ArgsL,Str)
      }
    }
  }
  MemoriList<- list()
  Memori<- list()
  for (N in 1:length(ArgsL)){
    Dt<- ArgsL[[N]]
    if(mode(Dt)=="numeric" && length(Dt)>1){
      if(length(Memori)>0){
        MemoriList<- Mixjoin(MemoriList,list(Memori))
      }
      Memori<- list(Dt[1],Dt[2])
      next
    }
    if(mode(Dt)=="character"){
      Memori<- Mixjoin(Memori,Dt)
    }
    else{
      if(length(Memori)>0){
        MemoriList<- Mixjoin(MemoriList,list(Memori))
      }
      Memori<- list(GENTEN[1],Dt)
    }
  }
  MemoriList<- Mixjoin(MemoriList,list(Memori))
  for (N in 1:length(MemoriList)){
    Dt<- MemoriList[[N]]
    Ndt<- length(Dt)
    X=Op(1,Dt)
    Y=Op(2,Dt)
    Tmp<-Doscaling(c(X,Y))
    X<- Tmp[1]
    Y<- Tmp[2]
    Moji<- Op(Ndt,Dt)
    Tmp1<- Unscaling(c(X+MARKLEN,Y))
    Tmp2<- Unscaling(c(X-MARKLEN,Y))
    Fd<- Listplot(c(Tmp1,Tmp2))
    Drwline(Fd)
    if(Ndt==3){
      Tmp<-Unscaling(c(X-MARKLEN,Y))
      Expr(Tmp,"w",Moji)
    }
    if(Ndt==4){
      Houkou<- Op(3,Dt)
      Tmp<-grep("w",Houkou)
      if(length(Tmp)>0){
        Tmp<-Unscaling(c(X-MARKLEN,Y))
        Expr(Tmp,Houkou,Moji)
      }
      else{
        Tmp<- Unscaling(c(X+MARKLEN,Y))
        Expr(Tmp,Houkou,Moji)
      }
    }
      cat("%\n",file=Wfile,append=TRUE)
  }
}

############################################

Windisp<-function(...){
  varargin<-list(...)
  Nargs<-length(varargin)
  Tmp<- Doscaling(c(XMIN,YMIN))
  Xmn<- Tmp[1]; Ymn<- Tmp[2]
  Tmp<- Doscaling(c(XMAX,YMAX))
  Xmx<- Tmp[1]; Ymx<- Tmp[2]
  plot(c(Xmn,Xmx),c(Ymn,Ymx),type="n",asp=1,axes=FALSE,xlab="",ylab="")
  Tmp<- Doscaling(Listplot(c(0,YMIN),c(0,YMAX)))
  axis(2,at=as.numeric(Tmp[,2]), labels=round(c(YMIN,YMAX),2))
  Tmp<- Doscaling(Listplot(c(XMIN,0),c(XMAX,0)))
  axis(1,at=as.numeric(Tmp[,1]), labels=round(c(XMIN,XMAX),2))
  Tmp1<- c(XMIN,GENTEN[2])
  Tmp2<- c(XMAX,GENTEN[2])
  Tmp3<- Listplot(Tmp1,Tmp2)
  Tmp<- MakeCurves(Tmp3,0)
  if(Datalength(Tmp)>0){
    lines(Tmp[,1],Tmp[,2],col="green")
  }
  Tmp1<- c(GENTEN[1],YMAX)
  Tmp2<- c(GENTEN[1],YMIN)
  Tmp3<- Listplot(Tmp1,Tmp2)
  Tmp<- MakeCurves(Tmp3,0)
  if(Datalength(Tmp)>0){
    lines(Tmp[,1],Tmp[,2],col="green")
  }
  Tmp<-Doscaling(Framedata())
  lines(Tmp[,1],Tmp[,2])
  for (I in Looprange(1,Nargs)){
    Pdata<-varargin[[I]]
    if(mode(Pdata)=="numeric"){
      Pdata<-list(Pdata)
    }
    while(Mixtype(Pdata)==3){         # 10.02.23
      Tmp1<- list()
      for(II in Looprange(1,length(Pdata))){
        Tmp1<- Mixjoin(Tmp1,Pdata[[II]])
      }
      Pdata<- Tmp1
    }                                                  # 10.02.23
    for (II in Looprange(1,length(Pdata))){
      Tmp<-Pdata[[II]]
      P<-MakeCurves(Tmp,0)
      Ndm<-Dataindex(P)
      for (J in Looprange(1,Nrow(Ndm))){
        Q<-P[Ndm[J,1]:Ndm[J,2],]
        if(Nrow(Q)==1){
          Tmp<-seq(1,Ncol(Q),by=2)
          for (K in Tmp){
            Pt<-Q[K:(K+1)]
            points(Pt[1],Pt[2])
          }
        }
        else{
          lines(Q[,1],Q[,2])
        }
      }
    }
  }
}

############################################

WindispT<-function(..., color="black",width=1,new=FALSE,htick=c(),vtick=c()){ # 10.12.04
  par(new=new)
  varargin<-list(...)
  Nargs<-length(varargin)
  if(!new)     # 10.12.04
  {
    Tmp<- Doscaling(c(XMIN,YMIN))
    Xmn<- Tmp[1]; Ymn<- Tmp[2]
    Tmp<- Doscaling(c(XMAX,YMAX))
    Xmx<- Tmp[1]; Ymx<- Tmp[2]
    plot(c(Xmn,Xmx),c(Ymn,Ymx),type="n",asp=1,axes=FALSE,xlab="",ylab="")
    Tick<- sort(c(YMIN,YMAX,vtick))                         #### 10.12.04  from here
    Tmp1<- matrix(c(rep(0,length(Tick)),Tick),ncol=2)
    Tmp<- Doscaling(Tmp1)
    axis(2,at=as.numeric(Tmp[,2]), labels=round(Tick,2))
    Tick<- sort(c(XMIN,XMAX,htick))
    Tmp1<- matrix(c(Tick,rep(0,length(Tick))),ncol=2)
    Tmp<- Doscaling(Tmp1)
    axis(1,at=as.numeric(Tmp[,1]), labels=round(Tick,2))  #### 10.12.04  to here
    Tmp1<- c(XMIN,GENTEN[2])
    Tmp2<- c(XMAX,GENTEN[2])
    Tmp3<- Listplot(Tmp1,Tmp2)
    Tmp<- MakeCurves(Tmp3,0)
    if(Datalength(Tmp)>0){
      lines(Tmp[,1],Tmp[,2],col="green")
    }
    Tmp1<- c(GENTEN[1],YMAX)
    Tmp2<- c(GENTEN[1],YMIN)
    Tmp3<- Listplot(Tmp1,Tmp2)
    Tmp<- MakeCurves(Tmp3,0)
    if(Datalength(Tmp)>0){
      lines(Tmp[,1],Tmp[,2],col="green")
    }
    Tmp<-Doscaling(Framedata())
    lines(Tmp[,1],Tmp[,2])
  }
  for (I in Looprange(1,Nargs)){
    Pdata<-Flattenlist(varargin[[I]])  # 101129  from here
	Cmd<- list()
	for (II in Looprange(1,length(Pdata))){
      Tmp<-Pdata[[II]]
	   if(length(Tmp)==1){
        Cmd<- c(Cmd,list(Tmp))
        next
      }
	  
      P<-MakeCurves(Tmp,0)
	  
      if(length(Cmd)>0){ 
        if(length(Cmd)>=3){
          polygon(P,col=Cmd[[1]],border=Cmd[[2]],density=Cmd[[3]])
        }
        else{
          polygon(P,col=Cmd[[1]],border=Cmd[[2]])
        }
        next
      }                                               # 101129  to here
      Ndm<-Dataindex(P)
      for (J in Looprange(1,Nrow(Ndm))){
        Q<-P[Ndm[J,1]:Ndm[J,2],]
        if(Nrow(Q)==1){
          Tmp<-seq(1,Ncol(Q),by=2)
          for (K in Tmp){
            Pt<-Q[K:(K+1)]
            points(Pt[1],Pt[2],col=color)#taka101111
          }
        }
        else{
          lines(Q[,1],Q[,2],col=color,lwd=width)#taka101111
        }
      }
    }
  }
  par(new=FALSE)
}

######################################

#  3D

#################################

# 10.08.16
CameracoordCurve<- function(Curve){
  Out<- c()
  for(J in Looprange(1,Nrow(Curve))){
    P<- Ptcrv(J,Curve) #P=Curve(J,:);
    Tmp<- P-FocusPoint
    X1<- Tmp[1]; Y1<- Tmp[2]; Z1<- Tmp[3]
    Tmp<- EyePoint-FocusPoint
    E1<- Tmp[1]; F1<- Tmp[2]; G1<- Tmp[3]
    Ca<- E1/sqrt(E1^2+F1^2)
    Sa<- F1/sqrt(E1^2+F1^2)
    X2<- X1*Ca+Y1*Sa; Y2<- -X1*Sa+Y1*Ca; Z2<- Z1
    E2<- E1*Ca+F1*Sa; F2<- -E1*Sa+F1*Ca; G2<- G1
    Cb<- E2/sqrt(E2^2+G2^2)
    Sb<- G2/sqrt(E2^2+G2^2)
    X3<- X2*Cb+Z2*Sb; Y3<- Y2; Z3<- -X2*Sb+Z2*Cb
    E3<- E2*Cb+G2*Sb; F3<- F2; G3<- -E2*Sb+G2*Cb
    Xz<- X3
    Yz<- E3/(E3-X3)*Y3
    Zz<- E3/(E3-X3)*Z3
    Out<- rbind(Out,c(Yz,Zz,Xz))
  }
  rownames(Out)<- 1:Nrow(Out)
  return(Out)
}

#########################################

#100815
CameraCurve<- function(Curve){
  Eps<- 10^(-6)
  for (I in Looprange(1,Nrow(Curve))){
    P<- Curve[I,]
    x<- P[1]; y<- P[2]; z<- P[3]
    if(x!=Inf){
      Tmp<- Perspt(P)
      if(I==1){
         AnsL<- rbind(c(),Tmp)
      }else{
        Tmp1<- AnsL[Nrow(AnsL),]
        if(Tmp1[1]==Inf || Norm(Tmp-Tmp1)>Eps){
          AnsL<- rbind(AnsL,Tmp)
        }
      }
    }else{
      AnsL<- rbind(AnsL,c(Inf,Inf))
    }
  }
  rownames(AnsL)<- 1:Nrow(AnsL)
  return(AnsL)
}

######################################

Cancoordpara<- function(P){   # 18.02.15
  Xz<- P[1]
  Yz<- P[2] 
  Zz<- P[3]
  X<- -Xz*sin(PHI)-Yz*cos(PHI)*cos(THETA)+Zz*cos(PHI)*sin(THETA)
  Y<- Xz*cos(PHI)-Yz*sin(PHI)*cos(THETA)+Zz*sin(PHI)*sin(THETA)
  Z<- Yz*sin(THETA)+Zz*cos(THETA)
  Out<- c(X,Y,Z)
  return(Out)
}

######################################

Cancoordpers<- function(P){
  Tmp<- EyePoint-FocusPoint
  E1<- Tmp[1]; F1<- Tmp[2]; G1<- Tmp[3]
  Ca<- E1/sqrt(E1^2+F1^2)
  Sa<- F1/sqrt(E1^2+F1^2)
  E2<- E1*Ca+F1*Sa; F2<- -E1*Sa+F1*Ca; G2<- G1
  Cb<- E2/sqrt(E2^2+G2^2)
  Sb<- G2/sqrt(E2^2+G2^2)
  E3<- E2*Cb+G2*Sb; F3<- F2; G3<- -E2*Sb+G2*Cb
  Xz<- P[3]; Yz<- P[1]; Zz<- P[2]
  X3<- Xz; Y3<- Yz*(E3-Xz)/E3; Z3<- Zz*(E3-Xz)/E3
  X2<- X3*Cb-Sb*Z3; Y2<- Y3; Z2<- Cb*Z3+Sb*X3
  X1<- X2*Ca-Sa*Y2; Y1<- Ca*Y2+Sa*X2; Z1<- Z2
  X<- X1+FocusPoint[1]
  Y<- Y1+FocusPoint[2]
  Z<- Z1+FocusPoint[3]
  Out<- c(X,Y,Z)
  return(Out)
}

#######################################

Embed<- function(...){
  varargin<- list(...)
  Nargs<- length(varargin)
  Pd3<- varargin[[1]]
  if(Mixtype(Pd3)==1){
    Pd3<- list(Pd3)
  }
  else if(Mixtype(Pd3)==3){
    Tmp<- list();
    for(I in Looprange(1,length(Pd3))){
      Tmp<- c(Tmp,Pd3[[I]])
    }
    Pd3<- Tmp
  }
  Tmpf=varargin[[2]]
  if(mode(Tmpf)=="character"){
    Tmp<- varargin[[3]]
    Tmp1<- gsub("c(","(",Tmp,fixed=TRUE)
    Vstr<- gsub(")",")",Tmp1,fixed=TRUE)
    Str<- paste("Tmpfn<- function",Vstr,"{",Tmpf,"}",sep="")
    eval(parse(text=Str))
  }
  else{
    Tmpfn<- Tmpf
  }
  Out<- list()
  for(I in Looprange(1,length(Pd3))){
     PD<- Pd3[[I]]
     Ans<- c()
     for(J in Looprange(1,Nrow(PD))){
       P<- PD[J,]
       Tmp<- Tmpfn(P[1],P[2])
       Ans<- rbind(Ans,Tmp)
     }
     Out<- c(Out, list(Ans))
  }
  if(length(Out)==1){
    Out<- Out[[1]]
  }
  return(Out)
}

#######################
# 10.08.17
# 14.03.30
Facesdata<- function(...){
  varargin<-list(...)
  Nargs<- length(varargin)
  FL<- varargin[[1]]
  PT<- varargin[[length(varargin)]]
  Tmp<-grep("para",PT,fixed=TRUE)
  if(length(Tmp)>0){
    Ptype<- 1
  }else{
    Ptype<- -1
  }
  if(Nargs==2){
    CLadd<- list()
  }else{
    CLadd<- varargin[[2]]
  }
  NohiddenL<- list()
  HiddenL<- list()
  Eps<- 10^(-4)
  if(length(CLadd)>0){
    if(mode(CLadd)=="numeric"){
      C<- list()
      if(Nrow(CLadd)>1){
        for (I in Looprange(1,Nrow(CLadd))){
           C<- c(C,list(CLadd[I,]))
        }
      }else{
        I<- 1
        while (I<=Ncol(CLadd)){
          C<- c(C,list(CLadd[1,I:(I+2)]))
          I<- I+3
        }
      }
      CrvL<- list(C)
    }else if(mode(CLadd[[1]])=="numeric"){
      CrvL<- list()
      for (J in Looprange(1,length(CL))){
        Ctmp<- CLadd[[J]]
        C<- list()
        if(Nrow(Ctmp)>1){
          for (I in Looprange(1,Nrow(Ctmp))){
            C<- c(C,list(Ctmp[I,]))
          }
        }else{
          I<- 1
          while(I<=Ncol(Ctmp)){
            C<- c(C,list(Ctmp[1,I:(I+2)]))
            I<- I+3
          }
        }
        CrvL<- c(CrvL,list(C))
      }
    }else{
      CrvL<- CLadd
    }
  }else{
    CrvL<- list()
  }
  Out<- MakeveLfaceL(FL)
  VELNO<<- Out[[1]]
  VELHI<<- list()
  for (I in Looprange(1,length(CrvL))){
    Tmp<- CrvL[[I]]
    for (J in Looprange(1,length(Tmp)-1)){
      Edge<- list(Tmp[J],Tmp[J+1])
      Ntmp<- length(VELNO)
      VELNO(Ntmp+1)<<- list(Edge,0,Ntmp+1)
    }
  }
  FaceL<- Out[[2]]
  Tmp<- grep("raw",PT,fixed=TRUE)
  if(length(Tmp)==0){
    for (Nf in Looprange(1,length(FaceL))){
      Face<- FaceL[[Nf]]
      Menkakusi2(Face,Nf,Ptype)
    }
  }
  for (I in Looprange(1,length(VELNO))){
    Edge<- Op(1,VELNO[[I]])
    if(Norm(Edge[[1]]-Edge[[2]])>Eps){
      NohiddenL<- c(NohiddenL,list(Spaceline(Edge)))
    }
  }
  EdgeL<- list()  # from 13.03.30
  for(K in Looprange(1,length(VELHI))){
    Edge<- Op(1,VELHI[[K]])
    P<- Edge[[1]]; Q<- Edge[[2]]
    if(Norm(P-Q)>Eps){
      EdgeL<- c(EdgeL,list(Edge))
    }
  }
  for(K in Looprange(1,length(EdgeL))){
    Edge<- EdgeL[[K]]
    P<- Edge[[1]]; Q<- Edge[[2]]
    Cflg<- 0
    for(J in Looprange(K+1,length(EdgeL))){
      Ej<- EdgeL[[J]]
      Pj<- Ej[[1]]; Qj<- Ej[[2]]
      if(Norm(Crossprod(Q-P,Qj-Pj))>Eps){
        next
      }
      if(Norm(Q-Pj)<Eps){
         EdgeL[[J]]<- list(P,Qj)
         Cflg<- 1
         break
      }
      if(Norm(P-Qj)<Eps){
        EdgeL[[J]]=list(Q,Pj)
        Cflg<- 1
        break
      }
    }
    if(Cflg==0){
      HiddenL<- c(HiddenL,list(Spaceline(Edge)))
   }
  }  # until 14.03.30
  PHHIDDENDATA<<- HiddenL
  return(NohiddenL)
}

##############################
# 2014.03.31

PhHiddenData<- function(){
  PHHIDDENDATA
}

########## Old Fullform ( Check the case of Polygon )####################

Fullformfunc<- function(FdL){# Out=Fullformfunc(FdL)
  Out<- list(Op(1,FdL))
  N<- Mixlength(FdL)
  for (Jrg in Looprange(1,N)){
    Tmp<- Stripblanks(Op(Jrg,FdL))
    Tmp1<- grep("=c(",Tmp,fixed=TRUE)
    if(length(Tmp1)>0){
      break
    }
  }
  Urg<- Stripblanks(Op(Jrg,FdL))
  StrV<- strsplit(Urg,"=",fixed=TRUE)[[1]]
  Uname<- StrV[1]
  Vrg<- Stripblanks(Op(Jrg+1,FdL))
  StrV<- strsplit(Vrg,"=",fixed=TRUE)[[1]]
  Vname<- StrV[1]
  if(Jrg==2){
    Tmp<- Stripblanks(Op(1,FdL))
    StrV<- strsplit(Tmp,"=",fixed=TRUE)[[1]]
    Zf<- StrV[2]
    Tmp<- list(Uname,Vname,Zf,Urg,Vrg)
    Out<- c(Out,Tmp)
  }else if(Jrg==4){
    Tmp<- Stripblanks(Op(1,FdL))
    StrV<- strsplit(Tmp,"=",fixed=TRUE)[[1]]
    Zf<- StrV[2]
    Tmp<- Stripblanks(Op(2,FdL))
    StrV<- strsplit(Tmp,"=",fixed=TRUE)[[1]]
	Xname<- StrV[1]
    Xf<- StrV[2]
    Tmp<- Stripblanks(Op(3,FdL))
    StrV<- strsplit(Tmp,"=",fixed=TRUE)[[1]]
    Yname<- StrV[1]
    Yf<- StrV[2]
    Tmp<- gsub(Xname,paste("(",Xf,")",sep=""),Zf,fixed=TRUE)
    Zf<- gsub(Yname,paste("(",Yf,")",sep=""),Tmp,fixed=TRUE)
    Tmp<- list(Xf,Yf,Zf,Urg,Vrg)
    Out<- c(Out,Tmp)
  }else{
    Tmp<- Stripblanks(Op(2,FdL))
    StrV<- strsplit(Tmp,"=",fixed=TRUE)[[1]]
    Xf<- StrV[2]
    Tmp<- Stripblanks(Op(3,FdL))
    StrV<- strsplit(Tmp,"=",fixed=TRUE)[[1]]
    Yf<- StrV[2]
    Tmp<- Stripblanks(Op(4,FdL))
    StrV<- strsplit(Tmp,"=",fixed=TRUE)[[1]]
    Zf<- StrV[2]
    Tmp<- list(Xf,Yf,Zf,Urg,Vrg)
    Out<- c(Out,Tmp)
  }
  DrwS<- "enws"
  BdyL<- c()
  for (I in Looprange(Jrg+2,Mixlength(FdL))){
    Tmp<- Op(I,FdL)
    if(mode(Tmp)=="character"){
      if(length(Tmp)==0){
        Tmp<- " "
      }
      DrwS<- Tmp
    }
    if(mode(Tmp)=="numeric" && Ncol(Tmp)>1){
      BdyL<- Tmp
    }
  }
  Tmp<- list(DrwS,BdyL)
  Out<- c(Out,Tmp)
  return(Out)
}

####################################

Initangle<- function (){
  PHI<<- 30*pi/180
  THETA<<- 60*pi/180
}

##########################

Invparapt<- function(...){
  varargin<- list(...)
  Eps<- 10^(-4)
  Fk<- varargin[[length(varargin)]]
  NFk<- Numptcrv(Fk)    
  Tmp<- varargin[[1]]
  if(mode(Tmp)=="numeric" && length(Tmp)==1){  # debug 
    Ph<- Tmp
    Fh<- varargin[[2]]
  }else{
    Fh<- Projpara(Fk)
    if(NFk>2){
      Tmp1<- Nearestpt(Tmp,Fh)
      Ph<- Tmp1[[2]]
    }else{
      Ah<- Ptcrv(1,Fh); Bh=Ptcrv(2,Fh)
      V1<- Tmp-Ah; V2<- Bh-Ah
      Tmp1<- Crossprod(V1,V2)
      if(abs(Tmp1)>Eps){
        print("Not on the line")
        return(c())
      }else{
        Ph<- Dotprod(V1,V2)/Norm(V2)^2+1
      }
    }
  }
  if(NFk>2){
    N<- trunc(Ph)
    S0<- Ph-N
    if(Ph>Numptcrv(Fh)-Eps){
      Out<- list(Ptend(Fk),Numptcrv(Fh))
      return(Out)
    }
  }else{
    N<- 1
    S0<- Ph-1
  }
  Ak<- Ptcrv(N,Fk); Bk=Ptcrv(N+1,Fk)
  Ah<- Ptcrv(N,Fh); Bh=Ptcrv(N+1,Fh)
  Ph<- (1-S0)*Ah+S0*Bh
  T2<- S0
  Pk<- (1-T2)*Ak+T2*Bk
  Out<- list(Pk,N+T2)
  return(Out)
}

#################################

#100815
Invperspt<- function(...){
  varargin<-list(...)
  Eps<- 10^(-4)
  Fk<- varargin[[length(varargin)]]
  NFk<- Numptcrv(Fk)     
  Tmp<- varargin[[1]]
  if(mode(Tmp)=="numeric" && length(Tmp)==1){
    Ph<- varargin[[1]]
    Fh<- varargin[[2]]
  }else{
    Fh<- Projpers(Fk)
    if(NFk>2){
      Tmp1<- Nearestpt(Tmp,Fh)
      Ph<- Tmp1[[2]]
    }else{
      Ah<- Ptcrv(1,Fh); Bh<- Ptcrv(2,Fh)
      V1<- Tmp-Ah; V2<- Bh-Ah
      Tmp1<- Crossprod(V1,V2)
      if(abs(Tmp1)>Eps){
        print("Not on the line")
        Out<- c()
        return(Out)
      }else{
        Ph<- Dotprod(V1,V2)/Norm(V2)^2+1# 09.11.12
      }
    }
  }
  if(NFk>2){
    N<- trunc(Ph)
    S0<- Ph-N
    if(Ph>Numptcrv(Fh)-Eps){
      Out<- list(Ptend(Fk),Numptcrv(Fh))
      return(Out)
    }
  }else{
    N<- 1
    S0<- Ph-1 # 09.11.12
  }
  Ak<- Ptcrv(N,Fk); Bk<- Ptcrv(N+1,Fk)
  Ah<- Ptcrv(N,Fh); Bh<- Ptcrv(N+1,Fh)
  Ph<- (1-S0)*Ah+S0*Bh
  Phc<- Cancoordpers(c(Ph,0))
  Ahc<- Cancoordpers(c(Ah,0))
  Bhc<- Cancoordpers(c(Bh,0))
  Vp<- Phc-EyePoint
  Va<- Ak-EyePoint
  AB<- Bk-Ak
  Cp<- Crossprod(Vp,AB)
  Nmr<- Crossprod(Va,Vp)
  Mx<- max(abs(Cp))
  if(abs(Cp[1])==Mx){
    T2<- Nmr[1]/Cp[1]
  }else if(abs(Cp[2])==Mx){
    T2<- Nmr[2]/Cp[2]
  }else{
    T2<- Nmr[3]/Cp[3]
  }
  Pk<- (1-T2)*Ak+T2*Bk
  Out<- list(Pk,N+T2)
  return(Out)
}

#########################

Kukannozoku<- function(Jokyo,KukanL){
  Eps<- 10^(-6)
  N<- Nrow(KukanL)
  T1<- Jokyo[1]; T2<- Jokyo[2]
  Tmp<- KukanL[1,]
  T1<- max(T1,Tmp[1])
  Tmp<- KukanL[N,]
  T2<- min(T2,Tmp[2])
  Res<- c()
  Flg<- 0
  for (I in Looprange(1,N)){
    Ku<- KukanL[I,]
    if(Flg==0){
      if(Ku[2]<T1){
        Res<- rbind(Res,Ku)
      }else{
        Flg<- 1
        if(Ku[1]<T1-Eps){
          Tmp<- c(Ku[1],T1)
          Res<- rbind(Res,Tmp)
        }
        if(Ku[2]>T2+Eps){
          Tmp<- c(T2,Ku[2])
          Res<- rbind(Res,Tmp)
        }
      }
    }else if(Flg==1){
      if(Ku[2]<T2){
        next
      }else{
        Flg<- 2
        if(Ku[1]<T2-Eps){
          Ku<- c(T2,Ku[2])
        }
        Res<- rbind(Res,Ku)
      }
    }else{
      Res<- rbind(Res,Ku)
    }
  }
  return(Res)
}

########################################

Makeskeletondata<- function(Obj2L,Plt2L,R0,Eps2){
 Eps<- 10.0^(-3)
  Dmat<- c()
  Dind<- c()
  for (I in Looprange(1,Mixlength(Plt2L))){
    Dt<- Op(I,Plt2L)
    N1<- Nrow(Dmat)+1
    if(Nrow(Dmat)==0){
      Dmat<- Dt
    }else{
      Dmat<- rbind(Dmat,Dt)
    }
    N2<- Nrow(Dmat)
    Dind<- c(Dind,N1,N2)
  }
  Dind<- matrix(Dind,ncol=2,byrow=TRUE)
  Nind<- Nrow(Dind)
  Allres<- list()
  for (Nobj in Looprange(1,Mixlength(Obj2L))){
    Plt2<- Op(Nobj,Obj2L)
    PhL<- Plt2[,1:2]
    ClipL<- c()
    for (Ns in Looprange(1,Nrow(PhL)-1)){
      P1<- PhL[Ns:(Ns+1),]
      for (I in Looprange(1,Nrow(Dind))){
        Tmp<- Dmat[Dind[I,1]:Dind[I,2],]
        P2<- Tmp[,1:2]
        KC<- IntersectcrvsPp(P1,P2)
        if(Mixlength(KC)>0){
          for (J in 1:Mixlength(KC)){
            P<- Op(1,Op(J,KC))
            Tmp<- Op(2,Op(J,KC))
            if(Tmp<1+Eps && Ns==1){
              next
            }    
            if(Tmp>Numptcrv(P1)-Eps && Ns==(Nrow(PhL)-1)){
              next
            }
            N1<- Ns
            N2<- Op(3,Op(J,KC))
            Pa<- Plt2[N1,1:2]
            Za<- Plt2[N1,3]
            Pb<- Plt2[N1+1,1:2]
            Zb<- Plt2[N1+1,3]
            if(Norm(Pa-Pb)<Eps){
              next
            }
            T1<- Norm(Pa-P)/Norm(Pa-Pb)
            Z1<- (1-T1)*Za+T1*Zb
            Tmp<- Dmat[Dind[I,1]:Dind[I,2],]
            Pa<- Tmp[N2,1:2]
            Za<- Tmp[N2,3]
            Pb<- Tmp[N2+1,1:2]
            Zb<- Tmp[N2+1,3]
            if((Norm(Pa-Pb)<Eps)){
              next
            }
            T2<- Norm(Pa-P)/Norm(Pa-Pb)
            Z2<- (1-T2)*Za+T2*Zb
            if(Z1<Z2-Eps2){
              if(Nrow(ClipL)==0){
                Tmp<- 1
              }else{
                Tmp1<- ClipL[,1]-P[1] 
                Tmp2<- ClipL[,2]-P[2]
                Tmp3<- Tmp1^2+Tmp2^2
                Tmp<- min(Tmp3)              
              }
              if(Tmp>Eps^2){
                Tmp1<- P1[2,]-P1[1,]
                Tmp2<- Pb-Pa
                Tmp3<- Dotprod(Tmp1,Tmp2)
                Tmp3<- Tmp3/Norm(Tmp1)/Norm(Tmp2)
                Tmp<- 1-0.5*Tmp3^2
                ClipL<- rbind(ClipL,c(P,N1,T1,R0/Tmp))
              }
            }
          }
        }
      }
    }
    Te<- Nrow(Plt2)
    KukanL<- rbind(c(),c(1.0,Te))
    P1<- PhL
    if(Nrow(ClipL)>0){
      for (I in 1:Nrow(ClipL)){
        P<- ClipL[I,1:2]
        NN<- ClipL[I,3]
        T<- NN+ClipL[I,4]
        R<- ClipL[I,5]
        Flg<- 0
        for (J in NN:1){
          Q<- Pointoncurve(J,P1)
          if(Norm(P-Q)<R){
            next
          }
          Flg<- 1
          break
        }
        if(Flg==0){
          T1<- 1
        }else{
          T1<- J; T2<- T
          H<- T2-T1
          for (N in 1:10){
            H<- H*0.5
            Q<- Pointoncurve(T1+H,P1)
            if(Norm(P-Q)<R){
              T2<- T2-H
            }else{
              T1<- T1+H
            }
          }
        }
        Ku<- c(T1)
        Flg<- 0
        for (J in Looprange(NN+1,Te)){
          Q<- Pointoncurve(J,P1)
          if(Norm(P-Q)<R){
            next
          }
          Flg<- 1
          break
        }
        if(Flg==0){
          T2<- Te
        }else{
          T1<- T; T2<- J
          H<- T2-T1
          for (N in 1:10){
            H<- H*0.5
            Q<- Pointoncurve(T1+H,P1)
            if(Norm(P-Q)<R){
              T1<- T1+H
            }else{
              T2<- T2-H
            }
          }
        }
        Ku<- c(Ku,T2)
        KukanL<- Kukannozoku(Ku,KukanL)
      }
    }
    Res<- list()
    for (I in Looprange(1,Nrow(KukanL))){
      T1<- KukanL[I,1]; N1<- trunc(T1)
      T2<- KukanL[I,2]; N2<- trunc(T2)
      PtL<- list()
      if(T1-N1<1-Eps){
        Tmp<- Pointoncurve(T1,P1)
        PtL<- list(Tmp)
      }
      for (J in Looprange(N1+1,N2)){
        Tmp<- Pointoncurve(J,P1)
        PtL<- c(PtL,list(Tmp))
      }
      if(T2-N2>Eps){
        Tmp<- Pointoncurve(T2,P1)
        PtL<- c(PtL,list(Tmp))
      }
      Res<- c(Res,list(Listplot(PtL)))
    }
    Allres<- c(Allres,Res)
  }
  return(Allres)
}

#########################

#100815
Makeskeletonpersdata<- function(Obj2L,Plt2L,R0,Eps2){
  Eps<- 10.0^(-3)
  Dmat<- c()
  Dind<- c()
  for (I in Looprange(1,Mixlength(Plt2L))){
    Dt<- Op(I,Plt2L)
    N1<- Nrow(Dmat)+1
    Dmat<- rbind(Dmat,Dt)
    N2<- Nrow(Dmat)
    Dind<- rbind(Dind,c(N1,N2))
  }
  Nind<- Nrow(Dind)
  Allres<- list()
  for (Nobj in Looprange(1,Mixlength(Obj2L))){
    Plt2<- Op(Nobj,Obj2L)
    PhL<- Plt2[,1:2]
    ClipL<- c()
    for (Ns in Looprange(1,Nrow(PhL)-1)){
      P1<- PhL[Ns:(Ns+1),]
      for (I in Looprange(1,Nrow(Dind))){
        Tmp<- Dmat[Dind[I,1]:Dind[I,2],]
        P2<- Tmp[,1:2]
        KC<- IntersectcrvsPp(P1,P2,Eps)
        if(Mixlength(KC)>0){
		  for (J in Looprange(1,Mixlength(KC))){#
            P<- Op(1,Op(J,KC))
            Tmp<- Op(2,Op(J,KC))
            if(Tmp<(1+Eps) && Ns==1){
              next
            }   
            if(Tmp>Numptcrv(P1)-Eps && Ns==(Nrow(PhL)-1)){
              next
            }
            N1<- Ns
            N2<- Op(3,Op(J,KC))
            Pa<- Plt2[N1,1:2]
            Za<- Plt2[N1,3]
            Pb<- Plt2[N1+1,1:2]
            Zb<- Plt2[N1+1,3]
            if(Norm(Pa-Pb)<Eps){
              next
            }
            T1<- Norm(Pa-P)/Norm(Pa-Pb)#norm(Pa-P)/norm(Pa-Pb)
            Pka<- Cancoordpers(c(Pa[1],Pa[2],Za))
            Pkb<- Cancoordpers(c(Pb[1],Pb[2],Zb))
            if(T1>1-Eps){
              Pk<- Pkb
            }else{
              Tmp1<- Listplot(c(Pa,Pb))
              Tmp2<- Spaceline(c(Pka,Pkb))
              Tmp<- Invperspt(1+T1,Tmp1,Tmp2)
              Pk<- Op(1,Tmp)
            }
            Z1<- Zperspt(Pk)
            Tmp<- Dmat[Dind[I,1]:Dind[I,2],]
            Pa<- Tmp[N2,1:2]
            Za<- Tmp[N2,3]
            Pb<- Tmp[N2+1,1:2]
            Zb<- Tmp[N2+1,3]
            if(Norm(Pa-Pb)<Eps){
              next
            }         
            T2<- Norm(Pa-P)/Norm(Pa-Pb)
            Pka<- Cancoordpers(c(Pa[1],Pa[2],Za))
            Pkb<- Cancoordpers(c(Pb[1],Pb[2],Zb))
            if(T2>(1-Eps)){
              Pk<- Pkb
            }else{
              Tmp1<- Listplot(c(Pa,Pb))
              Tmp2<- Spaceline(c(Pka,Pkb))
              Tmp<- Invperspt(1+T2,Tmp1,Tmp2)
              Pk<- Op(1,Tmp)
            }
            Z2<- Zperspt(Pk)
            if(Z1<(Z2-Eps2)){
              if(length(ClipL)==0){
                Tmp<- 1
              }else{
                Tmp1<- ClipL[,1]-P[1]
                Tmp2<- ClipL[,2]-P[2]
                Tmp3<- Tmp1^2+Tmp2^2
                Tmp<- min(Tmp3)              
              }
              if(Tmp>Eps^2){
                Tmp1<- P1[2,]-P1[1,]
                Tmp2<- Pb-Pa
                Tmp3<- Dotprod(Tmp1,Tmp2)
                Tmp3<- Tmp3/Norm(Tmp1)/Norm(Tmp2)
                Tmp<- 1-0.5*Tmp3^2
                ClipL<- rbind(ClipL,c(P,N1,T1,R0/Tmp))
              }
            }
          }
        }
      }
    }
    Te<- Nrow(Plt2)
    KukanL<- rbind(c(),c(1.0,Te))
    P1<- PhL
    if(Nrow(ClipL)>0){
      for (I in Looprange(1,Nrow(ClipL))){
        P<- ClipL[I,1:2]
        NN<- ClipL[I,3]
        T<- NN+ClipL[I,4]
        R<- ClipL[I,5] #added 10.08.17
        Flg<- 0
        for (J in NN:1){
          Q<- Pointoncurve(J,P1)
          if(Norm(P-Q)<R){#(norm(P-Q)<R)
            next
          }
          Flg<- 1
          break
        }
        if(Flg==0){
          T1<- 1
        }else{
          T1<- J; T2<- T
          H<- T2-T1
          for (N in 1:10){
            H<- H*0.5
            Q<- Pointoncurve(T1+H,P1)
            if(Norm(P-Q)<R){ # norm(P-Q)<R
              T2<- T2-H
            }else{
              T1<- T1+H
            }
          }
        }
        Ku<- c(T1)#Ku<- [T1]
        Flg<- 0
        for (J in Looprange(NN+1,Te)){
          Q<- Pointoncurve(J,P1)
          if(Norm(P-Q)<R){
            next#continue
          }
          Flg<- 1
          break
        }
        if(Flg==0){
          T2<- Te
        }else{
          T1<- T; T2<- J
          H<- T2-T1
          for (N in 1:10){
            H<- H*0.5
            Q<- Pointoncurve(T1+H,P1)
            if(Norm(P-Q)<R){
              T1<- T1+H
            }else{
              T2<- T2-H
            }
          }
        }
        Ku<- c(Ku,T2)#[Ku,T2]
        KukanL<- Kukannozoku(Ku,KukanL)
      }
    }
    Res<- list()#[]
    for (I in Looprange(1,Nrow(KukanL))){#(I=1:size(KukanL,1))
      T1<- KukanL[I,1]; N1<- trunc(T1)
      T2<- KukanL[I,2]; N2<- trunc(T2)
      PtL<- list()#[]
      if(T1-N1<1-Eps){
        Tmp<- Pointoncurve(T1,P1)
        PtL<- list(Tmp)#100816c(PtL,list(Tmp)) PtL<- MixS(Tmp)
      }
      for (J in Looprange(N1+1,N2)){
        Tmp<- Pointoncurve(J,P1)
        PtL<- c(PtL,list(Tmp))#Mixadd(PtL,Tmp)
      }
      if(T2-N2>Eps){
        Tmp<- Pointoncurve(T2,P1)
        PtL<- c(PtL,list(Tmp))#Mixadd(PtL,Tmp)
      }
      Res<- c(Res,list(Listplot(PtL)))#Res<- Mixadd(Res,Listplot(PtL))
    }
    Allres<- c(Allres,Res)#Allres<- Mixjoin(Allres,Res)
  }
  return(Allres)
}

##############################3

MakeveLfaceL<- function(VfL){
#  // Out format
#  //   VeL   Edge, Face num(as numlist), VeL num
#  //   FL    Face (Vertexs)
  Eps<- 10^(-4)
  Tmp<- VfL[[length(VfL)]]
  Tmp1<- Tmp[[1]]
  if(mode(Tmp1)=="numeric"){
    FvL<- list(VfL)
  }else{
    FvL<- VfL
  }
  EL<- list(); FL<- list()
  for (Nn in Looprange(1,length(FvL))){
    Tmp<- FvL[[Nn]]
    VL<- Tmp[[1]]
    if(length(VL)>0){
      FnL<- Tmp[[2]]
      FaceL<- list()
      for (I in Looprange(1,length(FnL))){
        Tmp1<- FnL[[I]]
        PtL<- list()
        for (J in Looprange(1,length(Tmp1))){
          Tmp2<- Tmp1[[J]]
          PtL[[J]]<- VL[[Tmp2]]
        }
        FaceL[[I]]<- PtL
      }
    }else{
      FaceL<- list(Tmp[[2]])
    }
    for (I in Looprange(1,length(FaceL))){
      Face<- FaceL[[I]]
      Face<- c(Face,list(Face[[1]]))
      FL<- c(FL,list(Face))
      for (J in Looprange(1,length(Face)-1)){
        Edge<- list(Face[[J]],Face[[J+1]])
        Flg<- 0
        for (K in Looprange(1,length(EL))){
          Tmp<- EL[[K]]
          Tmp1<- Tmp[[1]]
          Tmp2<- Norm(Edge[[1]]-Tmp1[[1]])+Norm(Edge[[2]]-Tmp1[[2]])
          Tmp3<- Norm(Edge[[1]]-Tmp1[[2]])+Norm(Edge[[2]]-Tmp1[[1]])
          if(Tmp2<Eps || Tmp3<Eps){#(
            Tmp<- EL[[K]]
            Tmp1<- Tmp[[1]]
            Tmp2<- c(Tmp[[2]],length(FL))
            EL[[K]]<- list(Tmp1,Tmp2,K)
            Flg<- 1
            break
          }
        }
        if(Flg==0){
          Ntmp<- length(EL)
          EL[[Ntmp+1]]<- list(Edge,c(length(FL)),Ntmp+1)
        }
      }
    }
  }
  Out<- list(EL,FL)
  return(Out)
}

###########################
# 09.10.29
# 09.11.15

Menkakusi2<- function(Face,Nf,Ptype){
#  global THETA PHI EyePoint FocusPoint VELNO VELHI
  Eps0<- 10^(-6)
  Eps<- 10^(-4)
  Tmp1<- Face[[1]]-Face[[2]]
  Tmp2<- Face[[3]]-Face[[2]]
   if(Norm(Tmp1)<Eps || Norm(Tmp2)<Eps){
    return()
  }  
  Vec<- 1/Norm(Tmp1)/Norm(Tmp2)*Crossprod(Tmp1,Tmp2)
  if(Norm(Vec)<Eps){
    return()
  }
  if(Ptype== -1){
    W<- EyePoint
    Tmp<- Dotprod(Vec,W-Face[[1]])
  }else{
    W<- c(sin(THETA)*cos(PHI),sin(THETA)*sin(PHI),cos(THETA))
    W<- 100*W
    Tmp<- Dotprod(Vec,W-Face[[1]])
  }
  if(abs(Tmp)<Eps){
    return()
  }
  if(Tmp<-Eps){
    Vec<- -Vec
  }
  if(Ptype==-1){
    G1<- Projpers(Spaceline(Face))
  }else{
    G1<- Projpara(Spaceline(Face))
  }
  VL<- list()
  for (I in Looprange(1,Numptcrv(G1))){
    VL[[I]]<- Ptcrv(I,G1)
  }
  Out1L<- list()
  Out2L<- VELHI
  for (N in Looprange(1,length(VELNO))){
    Out1<- list()
    Out2<- list()
    Tmp<- VELNO[[N]]
    Edge<- Tmp[[1]]
    Ne<- Tmp[[2]]
    NNe<- Tmp[[3]]
    if(Member(Nf,Ne)){
      Out1L<- c(Out1L, list(list(Edge,Ne,NNe)))
      next
    }
    if(Ptype==-1){
      PtA<- Perspt(Edge[[1]])
      PtB<- Perspt(Edge[[2]])
    }else{
      PtA<- Parapt(Edge[[1]])
      PtB<- Parapt(Edge[[2]])
    }
    if(Norm(PtA-PtB)<Eps){
      next
    }
    Bdy<- list(G1)
	V<- PtB-PtA
    TenL<- KoutenList(PtA,V,Bdy)
    Nten<- length(TenL)
    if(Nten==0){  # debug 10.08.17
      Out1L<- c(Out1L,list(list(Edge,Ne,NNe)))
      next
    }
	Te<- 0
    Pe3<- Edge[[1]]
    if(Ptype==-1){
      Tmp1<- Perspt(Pe3)
      Tmp<- Invperspt(Tmp1,Spaceline(Face))
    }else{
      Tmp1<- Parapt(Pe3)
      Tmp<- Invparapt(Tmp1,Spaceline(Face))
    }
    Qe3<- Tmp[[1]]
    Flg<- 0
    for (I in Looprange(1,Nten)){
      TenP<- TenL[[I]]
      Ts<- TenP[[1]]
      P<- TenP[[2]]
      if(Ts< -Eps){
        next
      }
      Eline<- Spaceline(Edge) 
      if(Ptype==-1){
        Tmp<- Invperspt(P,Eline)
        Tmp1<- Invperspt(P,Spaceline(Face))
      }else{
        Tmp<- Invparapt(P,Eline)
        Tmp1<- Invparapt(P,Spaceline(Face))
      }
      P3<- Tmp[[1]]; Q3<- Tmp1[[1]]
      if(Ts>1-Eps){#   P3, Q3 are necessary
        Flg<- I
        break
      }
      if(abs(Te-Ts)>Eps0){
        if((I%%2)==1){
          Out1<- c(Out1,list(list(Pe3,P3)))
        }else{
          if(length(Qe3)==0){
            Tmp<- Op(2,TenL[[I-1]])
            if(Ptype==-1){
              Tmp1<- Invperspt(Tmp,Spaceline(Face))
            }else{
              Tmp1<- Invparapt(Tmp,Spaceline(Face))
            }
            Qe3<- Tmp1[[1]]
          }
          PM<- 0.5*(Pe3+P3); QM<- 0.5*(Qe3+Q3)
          if(Ptype==-1){
            Z1<- Zperspt(PM); Z2<- Zperspt(QM)
          }else{
            Z1<- Zparapt(PM); Z2<- Zparapt(QM)
          }
          if(Z1>Z2){
            Out1<- c(Out1, list(list(Pe3,P3)))
          }else{
            Out2<- c(Out2, list(list(Pe3,P3)))
          }##
        }
      }
      Te<- Ts; Pe3<- P3; Qe3<- Q3
    }
    if(Flg==0){
      if(Norm(Pe3-Edge[[2]])>Eps0){
        Out1<- c(Out1, list(list(Pe3,Edge[[2]])))
      }
    }else{
      if((Flg%%2)==1){ 
        Out1<- c(Out1, list(list(Pe3,Edge[[2]])))
      }else{
        PM<- 0.5*(Pe3+P3); QM<- 0.5*(Qe3+Q3)
        if(Ptype==-1){
          Z1<- Zperspt(PM); Z2<- Zperspt(QM)
        }else{
          Z1<- Zparapt(PM); Z2<- Zparapt(QM)
        }
        if(Z1>Z2){
          Out1<- c(Out1, list(list(Pe3,Edge[[2]])))
        }else{
          Out2<- c(Out2, list(list(Pe3,Edge[[2]])))
        }       
      }
    }
    for (I in Looprange(1,length(Out1))){
      Tmp<- Out1[[I]]
      if(I==1){
        SeL<- Tmp
      }else{
        if(Norm(SeL[[2]]-Tmp[[1]])<Eps0){
          SeL[[2]]<- Tmp[[2]]
        }else{
          Out1L<- c(Out1L, list(list(SeL,Ne,NNe)))
          SeL<- Tmp
        }
      }
    }
    if(length(Out1)>0){
      Out1L<- c(Out1L, list(list(SeL,Ne,NNe)))
    }
    for (I in Looprange(1,length(Out2))){
      Tmp<- Out2[[I]]
      if(I==1){
        SeL<- Tmp
      }else{
        if(Norm(SeL[[2]]-Tmp[[1]])<Eps0){
          SeL[[2]]<- Tmp[[2]]
        }else{
          Out2L<- c(Out2L, list(list(SeL,Ne,NNe)))
          SeL<- Tmp
        }
      }
    }
    if(length(Out2)>0){
      Out2L<- c(Out2L, list(list(SeL,Ne,NNe)))
    }
  }
  VELNO<<- Out1L
  VELHI<<- Out2L
}

###################################

Parapt<- function(Plist){  # 18.02.19 changed (for point list)
  if(!is.list(Plist)){Plist=list(Plist)}
  Out=list()
  for(jj in 1:length(Plist)){
    P=Op(jj,Plist)
    x<- P[1]
    y<- P[2]
    z<- P[3]
    Xz<- -x*sin(PHI)+y*cos(PHI)
    Yz<- -x*cos(PHI)*cos(THETA)-y*sin(PHI)*cos(THETA)+z*sin(THETA)
    Out<- c(Out,list(c(Xz,Yz)))
  }
  if(length(Out)==1){Out=Op(1,Out)}
  return(Out)
}

###################################

Partcrv3<- function(T1,T2,Fk){
  Eps0=10^(-4)
# Tmp=Mixop(1,Fk)
# new part from
  if(T1>(T2+Eps0)){
    Npt<- Nrow(Fk)
    Out1<- Partcrv3(T1,Npt,Fk)
    Out2<- Partcrv3(1,T2,Fk)
    Tmp<- Fk[1,]-Fk[Npt,]
    if(Norm(Tmp)<Eps0){
      PL<- Joincrvs(Out1,Out2) 
    }else{
      PL<- list(Out1,Out2)
    }
    rownames(PL)<- 1:Nrow(PL)
    return(PL)
  }
  if(floor(T1)==floor(T2)){ #18.02.26from
    Tmp=floor(T1)
    p1=Op(Tmp,Fk); p2=Op(Tmp+1,Fk)
    PL=c(p1+(T1-Tmp)*(p2-p1)) 
    PL=Appendrow(PL, p1+(T2-Tmp)*(p2-p1)) #18.02.26until
  }else{
    Is<- ceiling(T1)
    Ie<- floor(T2)
    PL<- c()
    if(T1<Is-Eps0){
      P<- (Is-T1)*Fk[Is-1,]+(1-Is+T1)*Fk[Is,]  
      PL<- Appendrow(PL, P)  #18.02.10(bug)
    }
    PL<- Appendrow(PL,Fk[Is:Ie,])
    if(T2>(Ie+Eps0)){
      P<- (1-T2+Ie)*Fk[Ie,]+(T2-Ie)*Fk[Ie+1,] 
      PL<- Appendrow(PL,P)
    }
  }
  return(PL)
}

###################################

#100815
Perspt<- function(P){
  Tmp<- P-FocusPoint
  X1<- Tmp[1]; Y1<- Tmp[2]; Z1<- Tmp[3]
  Tmp<- EyePoint-FocusPoint
  E1<- Tmp[1];F1<- Tmp[2];G1<- Tmp[3]
  Ca<- E1/sqrt(E1^2+F1^2)
  Sa<- F1/sqrt(E1^2+F1^2)
  X2<- X1*Ca+Y1*Sa; Y2<- -X1*Sa+Y1*Ca; Z2<- Z1
  E2<- E1*Ca+F1*Sa; F2<- -E1*Sa+F1*Ca; G2<- G1
  Cb<- E2/sqrt(E2^2+G2^2)
  Sb<- G2/sqrt(E2^2+G2^2)
  X3<- X2*Cb+Z2*Sb; Y3<- Y2; Z3<- -X2*Sb+Z2*Cb
  E3<- E2*Cb+G2*Sb; F3<- F2; G3<- -E2*Sb+G2*Cb
  Yz<- E3/(E3-X3)*Y3
  Zz<- E3/(E3-X3)*Z3
  Out<- c(Yz,Zz)
  return(Out)
}


#################################

Phcutdata<- function(VL,FaceL,PlaneD){
  Out<- list()
  EL<- list()
  Eps<- 10^(-4)
  for (I in Looprange(1,Mixlength(FaceL))){
    Face<- Op(I,FaceL)
    for (J in Looprange(1,length(Face))){
      Nj<- J+1
      if(J==length(Face)){
        Nj<- 1
      }
      N1<- Face[J]; N2<- Face[Nj]
      Tmp<- c(N1,N2)
      Flg<- 0
      for (K in Looprange(1,Mixlength(EL))){
        Tmp1<- Op(K,EL)
        Tmp2<- Tmp1[2:1]
        if(all(Tmp==Tmp1) || all(Tmp==Tmp2)){
          Flg<- 1
          break
        }
      }
      if(Flg==0){
        EL<- c(EL,list(Tmp))
      }
    }
  }
  Out0<- list()
  for (I in Looprange(1,Mixlength(EL))){
    Tmp<- Op(I,EL)
    Tmp1<- Op(Tmp[1],VL)
    Tmp2<- Op(Tmp[2],VL)
    Out0<- c(Out0, list(Spaceline(Tmp1,Tmp2)))
  }
  if(Mixtype(PlaneD)!=1){
    V1<- Op(1,PlaneD)
    Tmp<- Op(2,PlaneD)
    if(length(Tmp)>1){
      d<- V1[1]*Tmp[1]+V1[2]*Tmp[2]+V1[3]*Tmp[3]
    }else{
      d<- Tmp
    }
  }else if(mode(PlaneD)=="numeric"){
    V1<- PlaneD[1:3]
    d<- PlaneD[4]
  }else{
    StrV<- strsplit(PlaneD,"=",fixed=TRUE)
	StrV<- StrV[[1]]
	if(length(StrV)>1){
	  Tmp1<- StrV[1] 
	  Tmp2<- StrV[2]
      PlaneD<- paste(Tmp1,"-(",Tmp2,")",sep="")
    }
    x<- 0; y<- 0; z<- 0
    d<- -eval(parse(text=PlaneD))
    x<- 1; y<- 0; z<- 0;
    Tmp1<- eval(parse(text=PlaneD))+d
    x<- 0; y<- 1; z<- 0
    Tmp2<- eval(parse(text=PlaneD))+d
    x<- 0; y<- 0; z<- 1
    Tmp3<- eval(parse(text=PlaneD))+d
    V1<- c(Tmp1,Tmp2,Tmp3)
  }
  if(all(V1==c(0,0,0))){
    return(Out0)
  }
  V3<- c(1,0,0)
  Out1<- Rotate3data(Out0,V1,V3)
  Tmp2<- Rotate3pt(c(1,0,0),V3,V1)
  Tmp<- V1[1]*Tmp2[1]+V1[2]*Tmp2[2]+V1[3]*Tmp2[3]
  x0<- d/Tmp
  PtL<- list()
  for (I in Looprange(1,Mixlength(Out1))){
    Tmp<- Op(I,Out1)
    Tmp1<- Tmp[1,]; Tmp2<- Tmp[2,]
    P<- list(Tmp1,Tmp2-Tmp1)
    Tmp<- list(Tmp1[1],Tmp2[1]-Tmp1[1])
    if(abs(Tmp[[2]]) < Eps){
      Tmp<- c()
    }else{
      Tmp1<- Tmp[[2]]
      Tmp2<- x0-Tmp[[1]]
      Tmp<- c(Tmp2/Tmp1)
    }
    if(length(Tmp)>0){
      Tmp<- Tmp[1]
      if(Tmp>-Eps && Tmp<(1+Eps)){
        Tmp3<- P[[1]]+Tmp*P[[2]]
        Tmp3<- Rotate3pt(Tmp3,V3,V1)
        if(Tmp<Eps){
          Tmp1<- Op(I,EL)
          Tmp1<- Tmp1[1]
          Tmp4<- list(c(Tmp1,Tmp1),Tmp3)
        }else{
          if(Tmp>1-Eps){
            Tmp1<- Op(I,EL)
            Tmp1<- Tmp1[2]
            Tmp4<- list(c(Tmp1,Tmp1),Tmp3)
          }else{
            Tmp4<- list(Op(I,EL),Tmp3)
          }
        }
        Flg<- 0
        for (J in Looprange(1,Mixlength(PtL))){
          Tmp<- Op(J,PtL)
          Tmp<- Op(2,Tmp)
          if(Norm(Tmp3-Tmp)<Eps){
            Flg<- 1
            break
          }
        }
        if(Flg==0){
          PtL<- c(PtL,list(Tmp4))
        }
      }
    }
  }
  if(Mixlength(PtL)==0){
    return(Out0)
  }
  PL<- list(Op(1,PtL))
  QL<- PtL[2:Mixlength(PtL)]
  N<- Mixlength(QL)
  for (I in Looprange(2,N+1)){
    Tmp1<- Op(Mixlength(PL),PL)
    Tmp1<- Op(1,Tmp1)
    for (J in Looprange(1,Mixlength(QL))){
      Tmp2<- Op(J,QL)
      Tmp2<- Op(1,Tmp2)
      Flg<- 0
      for (K in Looprange(1,Mixlength(FaceL))){
        Tmp3<- Op(K,FaceL);
        if(Member(Tmp1[1],Tmp3) &&
             Member(Tmp1[2],Tmp3) && 
             Member(Tmp2[1],Tmp3) && 
             Member(Tmp2[2],Tmp3)){
          Flg<- 1
          break
        }
      }
      if(Flg==1){
        break
      }
    }
    J<- min(J, Mixlength(QL))
    PL<- c(PL,list(Op(J,QL)))
    Tmp1<- QL[Looprange(1,J-1)]
    Tmp2<- QL[Looprange(J+1,Mixlength(QL))]
    QL<- c(Tmp1,Tmp2)
    if(Mixlength(QL)==0){
      break
    }
  }
  PHCUTPOINTL<<- PL
  Tmp<- list()
  for (J in Looprange(1,Mixlength(PL))){
    Tmp1<- Op(J,PL)
    Tmp1<- Op(2,Tmp1)
    Tmp<- c(Tmp,list(Tmp1))
  }
  Tmp1<- Op(1,PL)
  Tmp1<- Op(2,Tmp1)
  Tmp<- c(Tmp,list(Tmp1))
  Out2<- Spaceline(Tmp)
  Out<- c(Out0,list(Out2))
}

#########################################

Phcutoffdata<- function(...){
  varargin<-list(...)
  Eps<- 10^(-4)
  Out2<- list()
  VL<- varargin[[1]]
  FaceL<- varargin[[2]]
  PlaneD<- varargin[[3]]
  Sgnstr<- varargin[[4]]
  Fugou<- 1
  if(Sgnstr=="-" || Sgnstr=="n"){
    Fugou<- -1
  }
  Out0<- Phcutdata(VL,FaceL,PlaneD)
  PtL<- PHCUTPOINTL
  PHVERTEXL<<- VL
  PHFACEL<<- FaceL
  if(length(PtL)==0){
	Out2<- Out0
    return(Out2)
  }
  N1<- Mixlength(VL)
  Face<- c()
  for (I in Looprange(1,Mixlength(PtL))){
    Tmp<- Op(I,PtL)
    Tmp3<- Op(1,Tmp) 
    Tmp1<- Tmp3[[1]]; Tmp2<- Tmp3[[2]] # debugged 10.08.14
	if(Tmp1!=Tmp2){ 	
      VL<- c(VL,list(Op(2,Tmp)))
      N1<- N1+1
      Tmp1<- N1
    }
    Face<- c(Face,Tmp1)
    PtL[[I]]<- list(Op(1,Tmp),Tmp1)
  }
  OutfL<- list(Face)
  if(Mixtype(PlaneD)!=1){
    V1<- Op(1,PlaneD)
    Tmp<- Op(2,PlaneD)
    if(length(Tmp)>1){
      d<- V1[1]*Tmp[1]+V1[2]*Tmp[2]+V1[3]*Tmp[3]
    }else{
      d<- Tmp
    }
  }else if(mode(PlaneD)=="numeric"){
    V1<- PlaneD[1:3]
    d<- PlaneD[4]
  }else{
    StrV<- strsplit(PlaneD,"=",fixed=TRUE)
    StrV<- StrV[[1]]
    if(length(StrV)>1){
	  Tmp1<- StrV[1]
	  Tmp2<- StrV[2]
      PlaneD<- paste(Tmp1,"-(",Tmp2,")",sep="")
    }
    x<- 0; y<- 0; z<- 0
    d<- -eval(parse(text=PlaneD))
    x<- 1; y<- 0; z<- 0
    Tmp1<- eval(parse(text=PlaneD))+d
    x<- 0; y<- 1; z<- 0
    Tmp2<- eval(parse(text=PlaneD))+d
    x<- 0; y<- 0; z<- 1
    Tmp3<- eval(parse(text=PlaneD))+d
    V1<- c(Tmp1,Tmp2,Tmp3)
  }
  for (I in Looprange(1,Mixlength(FaceL))){
    Face<- Op(I,FaceL)
    TmpL<- list()
    for (J in Looprange(1,length(Face))){
      N1<- Face[J]
      if(J==length(Face)){
        N2<- Face[1]
      }else{
        N2<- Face[J+1]
      }
      for (K in Looprange(1,Mixlength(PtL))){
        Pd<- Op(K,PtL)
        Tmp<- Op(1,Pd)
        if(Tmp[1]==Tmp[2]){
          if(Tmp[1]==N1){
            TmpL<- c(TmpL,list(list(J,c(N1,N2),Op(2,Pd)))) 
          }
        }else{
          if(all(Tmp==c(N1,N2)) || all(Tmp==c(N2,N1))){
            TmpL<- c(TmpL,list(list(J,c(N1,N2),Op(2,Pd))))
          }
        }
      }
    }
    if(Mixlength(TmpL)<2){
	  Flg<- 0
      for (J in Looprange(1,length(Face))){
        Tmp<- Op(Face[J],VL)
       Tmp1<- Fugou*(Dotprod(V1,Tmp)-d)
        if(Tmp1< -Eps){
          Flg<- 1
          break
        }
      }
	  if(Flg==0){
        OutfL<- c(OutfL,list(Face))
	  }
      next
    }
	Pd<- Op(1,TmpL)
    Qd<- Op(2,TmpL)
    Outf1<- c(Op(3,Pd))
    Nf<- Op(1,Pd)+1
    Tmp<- Op(2,Pd)
    JJ<- 0
    while (!all(Tmp==Op(2,Qd))){
      JJ<- JJ+1
      if(JJ>20){
        print("bug")
        return()
      }
      Tmp1<- Tmp[2]
      if(Outf1[length(Outf1)]!=Tmp1){
        Outf1<- c(Outf1,Tmp1)
      }
      Tmp<- c(Face[Nf])
      Nf<- Nf+1
      if(Nf>length(Face)){
		Nf<- 1
      }
      Tmp<- c(Tmp,Face[Nf])
    }
    Tmp1<- Op(3,Qd)
    if(Outf1[length(Outf1)]!=Tmp1){
      Outf1<- c(Outf1,Tmp1)
    }
    Outf2<- c(Op(3,Pd))
    Nf<- Op(1,Pd)
    Tmp<- Op(2,Pd)
    JJ<- 0
    while (!all(Tmp==Op(2,Qd))){
      JJ<- JJ+1
      if(JJ>20){
        print("bug")
        return()
      }
      Tmp1<- Tmp[1]
      if(Outf2[length(Outf2)]!=Tmp1){
        Outf2<- c(Outf2,Tmp1)
      }
      Tmp<- c(Face[Nf])
      Nf<- Nf-1
      if(Nf<1){
        Nf<- length(Face)
      }
      Tmp<- c(Face[Nf],Tmp)
    }
    Tmp1<- Op(3,Qd)
    if(Outf2[length(Outf2)]!=Tmp1){
      Outf2<- c(Outf2,Tmp1)
    }
    if(length(Outf1)<3 || length(Outf2)<3){
      Face<- Outf1
      if(length(Outf1)<length(Outf2)){ 
        Face<- Outf2
      }
      Flg<- 0
      for (J in Looprange(1,length(Face))){
        Tmp<- Op(Face(J),VL)
        Tmp1<- Fugou*(Dotprod(V1,Tmp)-d)
        if(Tmp1<-Eps){
          Flg<- 1
          break
        }
      }
      if(Flg==0){
        OutfL<- c(OutfL,list(Face))
      }
    }else{
      Tmp<- Op(Outf1[2],VL)
      Tmp1<- Outf1
      Tmp2<- Fugou*(Dotprod(V1,Tmp)-d)   
      if(Tmp2<0){
        Tmp1<- Outf2
      }
      OutfL<- c(OutfL,list(Tmp1))
    }
  }
  PHVERTEXL<<- VL
  PHFACEL<<- OutfL
  Out2<- Phcutdata(VL,OutfL,c(0,0,0,0))
  return(Out2)
}

#######################

Phparadata<- function(VL,FaceL){
 Out<- Facesdata(list(VL,FaceL),"para")
 return(Out)
}

####################################

Phpersdata<- function(VL,FaceL){
 Out<- Facesdata(list(VL,FaceL),"pers")
 return(Out)
}

####################################

Phspersdata<- function(Fdata){ 
 Out<- Facesdata(Fdata,"pers")
 return(Out)
}

####################################

Phsparadata<- function(Fdata){
 Out<- Facesdata(Fdata,"para")
 return(Out)
}

#########################

#100816
Projpers<- function(...){
  varargin<- list(...)
  Nargs<- length(varargin)
  Flg<- 0
  if(Nargs==1 && Mixtype(varargin[[1]])==1){
    Flg<- 1
  }
  CL<- list()
  for (N in Looprange(1,Nargs)){
    Crv<- varargin[[N]]
    if(Mixtype(Crv)==1){
      Tmp<- CameraCurve(Crv)
      CL<- c(CL,list(Tmp))
    }else{
      if(Mixtype(Crv)==3){
        ObjL<- list()
        for (I in Looprange(1,Mixlength(Crv))){
          Tmp1<- Op(I,Crv)
          if(Mixtype(Tmp1)==1){
            ObjL<- c(ObjL,list(Tmp1))
          }else{
            ObjL<- c(ObjL,Tmp1)
          }
        }
        Crv<- ObjL
      }
      for (J in Looprange(1,Mixlength(Crv))){
        Tmp<- CameraCurve(Op(J,Crv))
        CL<- c(CL,list(Tmp))
      }
    }
  }
  if(Mixlength(CL)==1 && Flg==1){
    CL<- Op(1,CL)
  }  
  return(CL)      
}

###################################

ProjcoordCurve<- function(Curve){
  SP<- sin(PHI); CP<- cos(PHI)
  ST<- sin(THETA); CT<- cos(THETA)
  Out<- c()
  for (J in Looprange(1,Nrow(Curve))){
    P<- Ptcrv(J,Curve)
    x<- P[1]; y<- P[2]; z<- P[3]
    Xz<- -x*SP+y*CP
    Yz<- -x*CP*CT-y*SP*CT+z*ST
    Zz<- x*CP*ST+y*SP*ST+z*CT
    Out<- c(Out,Xz,Yz,Zz)
  }
  Out<- matrix(Out,ncol=3,byrow=TRUE)
  return(Out) 
}

#################################

ProjCurve<- function(Curve){  # 2018.02.26 rewritten
  AnsL= c()
  SP=sin(PHI); CP=cos(PHI)
  ST=sin(THETA); CT=cos(THETA)
  for(I in Looprange(1,Length(Curve)) ){
    P=Op(I,Curve)
    x=P[1]; y=P[2]; z=P[3]
    if(x!=Inf){
      Xz=-x*SP+y*CP
      Yz= -x*CP*CT-y*SP*CT+z*ST
      AnsL=Appendrow(AnsL,c(Xz,Yz))
      Tmp= c(Xz,Yz) 
    }else{
      AnsL=Appendrow(AnsL,c(Inf,Inf)) 
    }
  }
  return(AnsL)                      
}

####################################

Projpara<- function(...){
  varargin<-list(...)
  Nargs<- length(varargin)
  Flg<- 0
  if((Nargs==1)&&(is.numeric(varargin[[1]]))){
    Flg<- 1
  }
  CL<- list()
  for (N in Looprange(1,Nargs)){
    Crv<- varargin[[N]]
    if(is.numeric(Crv)){
      Tmp<- ProjCurve(Crv)
      CL<- c(CL,list(Tmp))
    }
    else{
      if(is.list(Crv)){
        ObjL<- list()
        for (I in Looprange(1,Mixlength(Crv))){
          Tmp1<- Op(I,Crv)
          if(is.numeric(Tmp1)){
            ObjL<- c(ObjL,list(Tmp1))
          }
          else{
            ObjL<-  c(ObjL,Tmp1)
          }
        }
        Crv<- ObjL
      }
      for (J in Looprange(1,length(Crv))){
        Tmp<- ProjCurve(Op(J,Crv))
        CL<- c(CL,list(Tmp))
      }
    }
  }
  if((length(CL)==1)&&(Flg==1)){
    CL<- Op(1,CL)
  }
  return(CL)
}

#########################

#100816
Projpers<- function(...){
  varargin<- list(...)
  Nargs<- length(varargin)
  Flg<- 0
  if(Nargs==1 && Mixtype(varargin[[1]])==1){
    Flg<- 1
  }
  CL<- list()
  for (N in Looprange(1,Nargs)){
    Crv<- varargin[[N]]
    if(Mixtype(Crv)==1){
      Tmp<- CameraCurve(Crv)
      CL<- c(CL,list(Tmp))
    }else{
      if(Mixtype(Crv)==3){
        ObjL<- list()
        for (I in Looprange(1,Mixlength(Crv))){
          Tmp1<- Op(I,Crv)
          if(Mixtype(Tmp1)==1){
            ObjL<- c(ObjL,list(Tmp1))
          }else{
            ObjL<- c(ObjL,Tmp1)
          }
        }
        Crv<- ObjL
      }
      for (J in Looprange(1,Mixlength(Crv))){
        Tmp<- CameraCurve(Op(J,Crv))
        CL<- c(CL,list(Tmp))
      }
    }
  }
  if(Mixlength(CL)==1 && Flg==1){
    CL<- Op(1,CL)
  }  
  return(CL)      
}

#########################################
# 180807

Reflect3data<- function(...){
  varargin<-list(...)
  Nargs<- length(varargin)
  Pd3<- varargin[[1]]
  VL<- varargin[[2]]
  if(Mixtype(Pd3)==1){
    Pd3<- list(Pd3)
  } else if(Mixtype(Pd3)==3){
    Tmp<- list()
    for (I in Looprange(1,Length(Pd3))){
      Tmp<- c(Tmp,Op(I,Pd3))
    }
    Pd3<- Tmp
  }
  Out<- list() 
  for (I in Looprange(1,Length(Pd3))){
     PD<- Op(I,Pd3)
     Ans<- c() 
     for (J in Looprange(1,Nrow(PD))){
      if(is.matrix(PD)){
        P<- PD[J,]
      }
      else{
        P<- PD
      } 
      Tmp<- Reflect3pt(P,VL)
      Ans<- rbind(Ans,Tmp)
    }
    rownames(Ans)<- 1:Nrow(Ans)
    Out<- c(Out,list(Ans))
   }
   if(Length(Out)==1){
     Out<- Op(1,Out)
  }
  return(Out)
}

#######################################

Reflect3pt<- function(...){
  varargin<-list(...)
  Nargs<-length(varargin)
  P<- varargin[[1]]
  VL<- varargin[[2]]
  if(Length(VL)==1){
    Ans=2*Op(1,VL)-P
  }
  if(Length(VL)==2){
    V1=Op(1,VL)
    V2=Op(2,VL)
    V3=(V2-V1)/Norm(V2-V1)
    Tmp=V1+Dotprod(P-V1,V3)*V3
    Ans=2*Tmp-P
  }
  if(Length(VL)==3){
    V1=Op(1,VL)
    V2=Op(2,VL)
    V3=Op(3,VL)
    Tmp=Crossprod(V2-V1,V3-V1)
    Tmp1=P-Dotprod(Tmp, P-V1)/Norm(Tmp)^2*Tmp
    Ans=2*Tmp1-P
  }
  return(Ans)
}

#########################################
# 180807

Scale3data<- function(...){
  varargin<-list(...)
  Nargs<- length(varargin)
  Pd3<- varargin[[1]]
  R<- varargin[[2]]
  C<- varargin[[3]]
  C<- c(0,0,0)
  if(Nargs>=3){
    C<- varargin[[3]]
  }
  if(Mixtype(Pd3)==1){
    Pd3<- list(Pd3)
  } else if(Mixtype(Pd3)==3){
    Tmp<- list()
    for (I in Looprange(1,Length(Pd3))){
      Tmp<- c(Tmp,Op(I,Pd3))
    }
    Pd3<- Tmp
  }
  Out<- list() 
  for (I in Looprange(1,Length(Pd3))){
    PD<- Op(I,Pd3)
    Ans<- c() 
    for (J in Looprange(1,Nrow(PD))){
      if(is.matrix(PD)){
        P<- PD[J,]
      }
      else{
        P<- PD
      } 
      Tmp<- Scale3pt(P,R,C)
      Ans<- rbind(Ans,Tmp)
    }
    rownames(Ans)<- 1:Nrow(Ans)
    Out<- c(Out,list(Ans))
  }
  if(Length(Out)==1){
    Out<- Op(1,Out)
  }
  return(Out)
}

#######################################

Scale3pt<- function(...){
  varargin<-list(...)
  Nargs<-length(varargin)
  P<- varargin[[1]]
  R<- varargin[[2]]
  if(length(R)==1){ #180808from
    R=c(R,R,R)
  } #180808to
  C<- c(0,0,0)
  if(Nargs>=3){
    C<- varargin[[3]]
  }
  X1=P[1]; Y1=P[2];  Z1=P[3]
  Cx=C[1]; Cy=C[2]; Cz=C[3]
  X2=Cx+R[1]*(X1-Cx)
  Y2=Cy+R[2]*(Y1-Cy)
  Z2=Cz+R[3]*(Z1-Cz)
  Ans=c(X2,Y2,Z2)
  return(Ans)
}

#########################################
# 11.08.27
# 14.03.23   Debugged "center"

Rotate3data<- function(...){
#Eps=10^(-4)
  varargin<-list(...)
  Nargs<- length(varargin)
  Pd3<- varargin[[1]]
  W1<- varargin[[2]]
  W2<- varargin[[3]]
  C<- c(0,0,0)
  if(Nargs>=4){
    C<- varargin[[4]]
  }
  if(Mixtype(Pd3)==1){
    Pd3<- list(Pd3)
  } else if(Mixtype(Pd3)==3){
    Tmp<- list()
    for (I in Looprange(1,Mixlength(Pd3))){
      Tmp<- c(Tmp,Op(I,Pd3))
    }
    Pd3<- Tmp
  }
  Out<- list() 
  for (I in Looprange(1,Mixlength(Pd3))){
     PD<- Op(I,Pd3)
     Ans<- c() 
     for (J in Looprange(1,Nrow(PD))){
      if(is.matrix(PD)){ # 11.08.27
        P<- PD[J,]
      }
      else{
        P<- PD
      }
       Tmp<- Rotate3pt(P,W1,W2,C) # 14.03.23
       Ans<- rbind(Ans,Tmp)
     } # 11.08.27
    rownames(Ans)<- 1:Nrow(Ans) #10.08.16
     Out<- c(Out,list(Ans))
   }
   if(Mixlength(Out)==1){
     Out<- Op(1,Out)
  }
  return(Out)
}

#######################################

Rotate3pt<- function(...){
  varargin<-list(...)
  Eps<-10^(-4)
  Nargs<-length(varargin)
  P<- varargin[[1]]
  W1<- varargin[[2]]
  W2<- varargin[[3]]
  C<- c(0,0,0)
  if(Nargs>=4){
    C<- varargin[[4]]
  }
  if(mode(W2)=="numeric" && length(W2)==1){
    Ct<- cos(W2)
    St<- sin(W2)
    V3<- 1/Norm(W1)*W1
    if(V3[1]==0){
      Tmp<- c(1,0,0) 
    }else{
      Tmp<- c(0,1,0)
    }
    W1<- c(Tmp[2]*V3[3]-Tmp[3]*V3[2],
         Tmp[3]*V3[1]-Tmp[1]*V3[3],
         Tmp[1]*V3[2]-Tmp[2]*V3[1])
    V1<- 1/Norm(W1)*W1
    V2<- c(V3[2]*V1[3]-V3[3]*V1[2],
         V3[3]*V1[1]-V3[1]*V1[3],
         V3[1]*V1[2]-V3[2]*V1[1])
  }else{
    Tmp<- c(W1[2]*W2[3]-W1[3]*W2[2],
          W1[3]*W2[1]-W1[1]*W2[3],
          W1[1]*W2[2]-W1[2]*W2[1])
    if(Norm(Tmp)<Eps){ 
      Ans<- P
      return(Ans)
    }
    V1<- 1/Norm(W1)*W1 
    Ns<- V1[1]*W2[1]+V1[2]*W2[2]+V1[3]*W2[3]
    Tmp<- W2-Ns*V1
    V2<- 1/Norm(Tmp)*Tmp 
    Tmp<- c(V1[2]*V2[3]-V1[3]*V2[2],
         V1[3]*V2[1]-V1[1]*V2[3],
         V1[1]*V2[2]-V1[2]*V2[1])
    V3<- 1/Norm(Tmp)*Tmp 
    Ct<- Ns/Norm(W2)
    St<- sqrt(1-Ct^2)
  }
  if(Norm(Tmp)<Eps){
    Ans<- P
    return(Ans)
  }
  V1x<- V1[1]; V1y<- V1[2]; V1z<- V1[3]
  V2x<- V2[1]; V2y<- V2[2]; V2z<- V2[3]
  V3x<- V3[1]; V3y<- V3[2]; V3z<- V3[3]
  if(Mixtype(P)!=1){
    PtL<- P
  }else{
    PtL<- list(P)
  }
  Ans<- list() 
  for (N in Looprange(1,Mixlength(PtL))){
    P<- Op(N,PtL)
    if(P[1]==Inf){
      Ans<- c(Ans,list(c(Inf,Inf,Inf)))
      next
    }
    x<- P[1]-C[1]; y=P[2]-C[2]; z=P[3]-C[3] 
	Tmp1<-  ((V1x*Ct+V2x*St)*V1x+(-V1x*St+V2x*Ct)*V2x+V3x^2)*x
	Tmp2<- ((V1x*Ct+V2x*St)*V1y+(-V1x*St+V2x*Ct)*V2y+V3x*V3y)*y
	Tmp3<- ((V1x*Ct+V2x*St)*V1z+(-V1x*St+V2x*Ct)*V2z+V3x*V3z)*z
	X<- Tmp1+Tmp2+Tmp3
    Tmp1<-  ((V1y*Ct+V2y*St)*V1x+(-V1y*St+V2y*Ct)*V2x+V3x*V3y)*x
    Tmp2<- ((V1y*Ct+V2y*St)*V1y+(-V1y*St+V2y*Ct)*V2y+V3y^2)*y
    Tmp3<- ((V1y*Ct+V2y*St)*V1z+(-V1y*St+V2y*Ct)*V2z+V3y*V3z)*z
	Y<- Tmp1+Tmp2+Tmp3
    Tmp1<-  ((V1z*Ct+V2z*St)*V1x+(-V1z*St+V2z*Ct)*V2x+V3x*V3z)*x
    Tmp2<- ((V1z*Ct+V2z*St)*V1y+(-V1z*St+V2z*Ct)*V2y+V3y*V3z)*y
    Tmp3<- ((V1z*Ct+V2z*St)*V1z+(-V1z*St+V2z*Ct)*V2z+V3z^2)*z
	Z<- Tmp1+Tmp2+Tmp3
     Ans<- c(Ans,list(C+c(X,Y,Z))) 
  }
  if(Mixlength(Ans)==1){
    Ans<- Op(1,Ans)
  }
 return(Ans)
}

#################################

Translate3data<- function(...){
  varargin<- list(...)
  Nargs<- length(varargin)
  Pd3<- varargin[[1]]
  Mv<- varargin[[2]]
  if(mode(Mv)=="numerice" && length(Mv)==1){
    Mv<- c(varargin[[2]],varargin[[3]],varargin[[4]])
  }
  if(Mixtype(Pd3)==1){
    Pd3<- list(Pd3)
  }
  else if(Mixtype(Pd3)==3){
    Tmp<-list()
    for(I in Looprange(1,Mixlength(Pd3))){
      Tmp<- c(Tmp, Op(I,Pd3))
    }
    Pd3<- Tmp
  }
  Out<- list()
  for(I in Looprange(1,Mixlength(Pd3))){
    PD<- Op(I,Pd3)
    PD<- rbind(c(),PD)
    Ans<- c()
    for(J in Looprange(1,Nrow(PD))){
      P<- PD[J,]
      Tmp<- P+Mv
      Ans<- rbind(Ans,Tmp)
    }
    rownames(Ans)<- 1:Nrow(Ans)
    Out<- c(Out,list(Ans))
  }
  if(Mixlength(Out)==1){
    Out<- Op(1,Out)
  }
  return(Out)
}

######################################

Setangle<- function(...){
  Eps<- 10^(-6)
  varargin<-list(...)
  Nargs<-length(varargin)
  if(Nargs==0) {   
  }
  else if(Nargs==1){
    V<- varargin[[1]]
    V<- V/Norm(V)
    THETA<<- acos(V[3])
    if(abs(sin(THETA))<Eps){
      PHI<<- 0
    }
    else{
      PHI<<- acos(V[1]/sin(THETA))
      if(V[2]< -Eps) PHI<<- -PHI
    }	
  }
  else{
    PHI<<- varargin[[2]]*pi/180
    THETA<<- varargin[[1]]*pi/180
  }
  Out<- paste("theta=",as.character(THETA*180/pi)," phi=",
      as.character(PHI*180/pi),sep="")
  return (Out)  
}

#################################

Setpers<- function(...){
  varargin<- list(...)
  Nargs<- length(varargin)
  if(Nargs==0){
  }
  else{
    FocusPoint<<- varargin[[1]]
    EyePoint<<- varargin[[2]]
  }
  F<- as.character(FocusPoint)
  E<- as.character(EyePoint)
  Out<- paste("Focus = c(",F[1],",",F[2],",",F[3],") , ",
     " Eye = c(", E[1],",",E[2],",",E[3],") ",sep="")
  return (Out)  
}

#################################

SetstereoL<- function(R,T,P,H){
  X<- R*sin(T*pi/180)*cos(P*pi/180)
  Y<- R*sin(T*pi/180)*sin(P*pi/180)
  Z<- R*cos(T*pi/180)
  Eye<- c(X+H/2*Y/(X^2+Y^2),Y-H/2*X/(X^2+Y^2),Z)
  Out<- Setpers(c(0,0,0),Eye)
  return(Out)
}

#################################

SetstereoR<- function(R,T,P,H){
  X<- R*sin(T*pi/180)*cos(P*pi/180)
  Y<- R*sin(T*pi/180)*sin(P*pi/180)
  Z<- R*cos(T*pi/180)
  Eye<- c(X-H/2*Y/(X^2+Y^2),Y+H/2*X/(X^2+Y^2),Z)
  Out<- Setpers(c(0,0,0),Eye)
  return(Out)
}

###############################

Sf3data<- function(...){
  varargin<-list(...)
  Nargs<- length(varargin)
  FdL<- Fullformfunc(varargin[[1]])
  F<- Op(1,FdL)
  Xf<- Op(2,FdL)
  Yf<- Op(3,FdL)
  Zf<- Op(4,FdL)
  Urg<- Op(5,FdL)
  Vrg<- Op(6,FdL)
  Str<- strsplit(Urg,"=",fixed=TRUE)[[1]]
  U<- Str[1]
  Tmp<- Str[2]
  Tmp<- eval(parse(text=Tmp))
  Umin<- Tmp[1]; Umax<- Tmp[2]
  Str<- strsplit(Vrg,"=",fixed=TRUE)[[1]]
  V<- Str[1]
  Tmp<- Str[2]
  Tmp<- eval(parse(text=Tmp))
  Vmin<- Tmp[1]; Vmax<- Tmp[2]
  Ndu<- 25 ; Ndv<- 25; Np<- c(50,50)
  if(Nargs>=3){
    Ndu<- varargin[[2]]
    Ndv<- varargin[[3]]
  }
  if(Nargs>=4){
    Np<- varargin[[4]]
    if(mode(Np)=="numeric" && length(Np)==1){
      Np<- c(Np,Np)
    }
  }
  Du<- (Umax-Umin)/Ndu
  Dv<- (Vmax-Vmin)/Ndv
  PL <-  c()#PL <-  []
  Assign("Vmin",Vmin,"Vmax",Vmax)
  Trgstr<- Assign("t=c(Vmin,Vmax)") 
  PL <-  list()
  for (I in Looprange(0,Ndu)){
    U0 <- paste("(",as.character(Umin+I*Du),")",sep="")
    Tmp<- gsub(U,U0,Xf,fixed=TRUE)
    Tmp1<- gsub(V,"t",Tmp,fixed=TRUE)
    Tmp<- gsub(U,U0,Yf,fixed=TRUE)
    Tmp2<- gsub(V,"t",Tmp,fixed=TRUE)
    Tmp<- gsub(U,U0,Zf,fixed=TRUE)
    Tmp3<- gsub(V,"t",Tmp,fixed=TRUE)
    Tmp<- paste("c(",Tmp1,",",Tmp2,",",Tmp3,")",sep="")
    PD<- Spacecurve(Tmp,Trgstr,paste("N=",as.character(Np[2])))
    PL<- c(PL,list(PD))
  }
  Assign("Umin",Umin,"Umax",Umax)
  Trgstr<- Assign("t=c(Umin,Umax)")
  for (J in Looprange(0,Ndv)){
    V0<- paste("(",as.character(Vmin+J*Dv),")",sep="")
    Tmp<- gsub(V,V0,Xf,fixed=TRUE)
    Tmp1<- gsub(U,"t",Tmp,fixed=TRUE)
    Tmp<- gsub(V,V0,Yf,fixed=TRUE)
    Tmp2<- gsub(U,"t",Tmp,fixed=TRUE)
    Tmp<- gsub(V,V0,Zf,fixed=TRUE)
    Tmp3<- gsub(U,"t",Tmp,fixed=TRUE)
    Tmp<- paste("c(",Tmp1,",",Tmp2,",",Tmp3,")")
    PD<- Spacecurve(Tmp,Trgstr,paste("N=",as.character(Np[1])))
    PL<- c(PL,list(PD))
  }
  return(PL)
}

###################################

Skeletonparadata<- function(...){
  varargin<-list(...)
  Nargs<- length(varargin)
  Out<- list()
  ObjL<- Flattenlist(varargin[[1]])
  Plt3L<- Flattenlist(varargin[[2]])
  R<- 0.075*1000/2.54/MilliIn
  if(Nargs>2){
    R<- R*varargin[[3]]
  }
  Eps2<- 0.05
  if(Nargs>3){
    Eps2<- varargin[[4]]
  }
  Obj2L<- list()
  for (I in Looprange(1,Mixlength(ObjL))){
    Tmp<- ProjcoordCurve(Op(I,ObjL))
    Obj2L<- c(Obj2L,list(Tmp))
  }
  Plt2L<- list()
  for (I in  Looprange(1,Mixlength(Plt3L))){
    Tmp<- ProjcoordCurve(Op(I,Plt3L))
    Plt2L<- c(Plt2L,list(Tmp))
  }
  Out<- Makeskeletondata(Obj2L,Plt2L,R,Eps2)
  return(Out)
}

################################

Skeletonpara3data<- function(...){
  varargin<-list(...)
  Nargs<- length(varargin)
  ObjL<- Flattenlist(varargin[[1]])
  Plt3L<- Flattenlist(varargin[[2]])
  R<- 0.075*1000/2.54/MilliIn
  if(Nargs>2){
    R=R*varargin[[3]]
  }
  Eps2<- 0.05
  if(Nargs>3){
    Eps2<- varargin[[4]]
  }
  Plt2L<- list()
  for (I in Looprange(1,Mixlength(Plt3L))){
    Tmp<- ProjcoordCurve(Op(I,Plt3L))
    Plt2L<- c(Plt2L,list(Tmp))
  }
  Out<- list()
  for (I in Looprange(1,Mixlength(ObjL))){
    Obj3<- Op(I,ObjL)
    Tmp<- ProjcoordCurve(Obj3)
    Data<- Makeskeletondata(list(Tmp),Plt2L,R,Eps2)
    for (J in Looprange(1,Mixlength(Data))){
      Gd<- Op(J,Data)
      PtD<- c()
      for (J in Looprange(1,Nrow(Gd))){
        Tmp<- Ptcrv(J,Gd)
        Tmp1<- Invparapt(Tmp,Obj3)
        Tmp1<- Op(1,Tmp1)
        PtD<- c(PtD,Tmp1)
      }
      PtD<- matrix(PtD,ncol=3,byrow=TRUE)
      Out<- c(Out,list(PtD))
    }
  }
  return(Out)
}

#################################

#100815
Skeletonpersdata<- function(...){
  varargin<-list(...)
  Nargs<- length(varargin)
  Out<- list() 
  ObjL<- Flattenlist(varargin[[1]])
  Plt3L<- Flattenlist(varargin[[2]])
  R<- 0.075*1000/2.54/MilliIn
  if(Nargs>2){
    R<- R*varargin[[3]]
  }
  Eps2<- 0.05
  if(Nargs>3){
    Eps2<- varargin[[4]]
  }
  Obj2L<- list() 
  for (I in Looprange(1,Mixlength(ObjL))){
    Tmp<- CameracoordCurve(Op(I,ObjL))
    Obj2L<- c(Obj2L,list(Tmp))
  }
  Plt2L<- list()
  for (I in Looprange(1,Mixlength(Plt3L))){
    Tmp<- CameracoordCurve(Op(I,Plt3L))
    Plt2L<- c(Plt2L,list(Tmp))
  }
  Out<- Makeskeletonpersdata(Obj2L,Plt2L,R,Eps2)
  return(Out)
}

#####################
#100815
Skeletonpers3data<- function(...){
  varargin<-list(...)
  Nargs<- length(varargin)
  Out<- list()
  ObjL<- Flattenlist(varargin[[1]])
  Plt3L<- Flattenlist(varargin[[2]])
  R<- 0.075*1000/2.54/MilliIn
  if(Nargs>2){
    R<- R*varargin[[3]]
  }
  Eps2<- 0.05
  if(Nargs>3){
    Eps2<- varargin[[4]]
  }
  Plt2L<- list()
  for (I in Looprange(1,Mixlength(Plt3L))){
    Tmp<- CameracoordCurve(Op(I,Plt3L))
    Plt2L<- c(Plt2L,list(Tmp))
  }
  Out<- list()
  for (I in Looprange(1,Mixlength(ObjL))){
    Obj3<- Op(I,ObjL)
    Tmp<- CameracoordCurve(Obj3)
    Data<- Makeskeletonpersdata(list(Tmp),Plt2L,R,Eps2)
    for (J in Looprange(1,Mixlength(Data))){
      Gd<- Op(J,Data)
      PtD<- c()
      for (J in Looprange(1,Nrow(Gd))){
        Tmp<- Gd[J,]
        Tmp1<- Invperspt(Tmp,Obj3)
        Tmp1<- Op(1,Tmp1)
        PtD<- rbind(PtD,Tmp1)
      }
      Out<- c(Out,list(PtD))
    }
  }
  return(Out)
}

#################################

Spacecurve<- function(...){
  Eps<- 10^(-5)
  varargin<-list(...)
  Nargs<- length(varargin)
  Fnstr<- varargin[[1]]
  Rgstr<- varargin[[2]]
  Range<- c(0,2*pi)
  N<- 50                 #Numpoints
  E<- c()                #Exclusions
  D<- Inf                #Discont  (Changed)
  for(I in Looprange(3,Nargs)){
    Tmp<- varargin[[I]]
    StrV<-  strsplit(Tmp,"=",fixed=TRUE)
    StrV<- StrV[[1]]
    Tmp1<- toupper(StrV[1])
    Lhs<- substr(Tmp1,1,1) 
    Str<- paste(Lhs,"=",StrV[2],sep="") 
    eval(parse(text=Str)) 
  }
  StrV<-  strsplit(Rgstr,"=",fixed=TRUE)
  StrV<- StrV[[1]]
  if(length(StrV)>1){
    Vname<- StrV[1]
    Rng<- eval(parse(text=StrV[2]))
  }
  else{
    Vname<- Rgstr
    Rng<- c(XMIN,XMAX)
  }
  T1<- Rng[1]; T2<- Rng[2]
  Dt<- (T2-T1) #180929
  Str<- gsub(Vname,"t",Fnstr)
  Str=gsub("[","c(",Str,fixed=TRUE) #17.12.22(2lines)
  Str=gsub("]",")",Str,fixed=TRUE)
  if(abs(Dt/N)<Eps){ #180929
    t=T1
    P=eval(parse(text=Str))
    return(P)
  }
  P<- c()
#  E<- sort(E,decreasing=FALSE)
  E<- c(E,Inf)
  E<- sort(E,decreasing=FALSE)
  Ke<- 1
  for(jj in 1:(N+1)){
    t=T1+(jj-1)*Dt/N #180929
    Pa<- c()
    if(t-E[Ke]< Eps){
	  Pa<-  eval(parse(text=Str))
    }
    if(abs(t-E[Ke])<=Eps){
      if(length(P)>0 && P[Nrow(P),1]!=Inf){ 
        Pa<- c(Inf,Inf,Inf)
      }
    }
    if(t-E[Ke]>Eps){
      Pa<- eval(parse(text=Str))
      Ke<- Ke+1
    }
    if(length(Pa)>0){
      if(Pa[1]==Inf){
        P<- rbind(P,Pa)
      }else if(length(P)==0){
        P<- rbind(c(),c(Pa))
      }
      else{
        Tmp<- P[Nrow(P),]
        if(Tmp[1]==Inf){
          P<- rbind(P,Pa)
        }
        else if( Norm(Tmp-Pa)<D){
          P<- rbind(P,Pa)
        }
        else{
          P<- rbind(P,c(Inf,Inf,Inf))
		  P<- rbind(P,Pa)
        }
      }
    }
  }
  rownames(P)<- 1:Nrow(P) # 10.08.16
  return(P)
}

########################################

Spaceline<- function(...){
  varargin<- list(...)
  Z<- c()                 
  for(I in 1:length(varargin)){  
    Data<- varargin[[I]]   
    if(Mixtype(Data)==1){
      J<- 1
      while (J<=Ncol(Data)){ 
        Tmp<- Data[J:(J+2)] 
        Z<-c(Z,Tmp)
        J<- J+3
      }
      next
    }
    if(Mixtype(Data)==3){  
      Tmp<- list() 
      for(I in 1:Mixlength(Data)){
        Tmp<- c(Tmp,Op(I,Data))
      }
      Data<- Tmp
    }
    for(J in 1:Mixlength(Data)){
      Tmp<- Op(J,Data)  
      Z<- c(Z,Tmp)
    }
  }
  Z<- matrix(Z,ncol=3,byrow=TRUE)                
  return(Z)
}

###############################################

Xyzax3data<- function(Xrange,Yrange,Zrange){
  StrV<-strsplit(Xrange,"=",fixed=TRUE)
  StrV<- StrV[[1]]
  if(length(StrV)>1) StrV<- StrV[2]
  Tmp<- eval(parse(text=StrV)) 
  Px<- c(Tmp[1],0,0) 
  Qx<- c(Tmp[2],0,0)
  StrV<-strsplit(Yrange,"=",fixed=TRUE)
  StrV<- StrV[[1]]
  if(length(StrV)>1) StrV<- StrV[2]
  Tmp<- eval(parse(text=StrV)) 
  Py<- c(0,Tmp[1],0) 
  Qy<- c(0,Tmp[2],0)
  StrV<-strsplit(Zrange,"=",fixed=TRUE)
  StrV<- StrV[[1]]
  if(length(StrV)>1) StrV<- StrV[2]
  Tmp<- eval(parse(text=StrV)) 
  Pz<- c(0,0,Tmp[1])
  Qz<- c(0,0,Tmp[2])
  Out<- list(Spaceline(Px,Qx),Spaceline(Py,Qy),Spaceline(Pz,Qz))
  return(Out)
}

###################################

Xyzaxparaname<- function(...){
  varargin<- list(...)
  Nargs<- length(varargin)
  Eps<- 10.0^(-6)
  Dr<- 0.19*1000/2.54/MilliIn
  Tmp<- varargin[[Nargs]]
  if(Nargs>1 && is.numeric(Tmp)){
    Dr<- Dr*Tmp
    Nargs<- Nargs-1
  }
  if(mode(varargin[[1]])=="character"){
    Xname<- "x"
	Yname<- "y"
	Zname<- "z"
    Xrange<- varargin[[1]]
    Yrange<- varargin[[2]]
    Zrange<- varargin[[3]]
    StrV<-strsplit(Xrange,"=",fixed=TRUE)
    StrV<- StrV[[1]]
    if(length(StrV)>1){
	  Xname<- StrV[1]
	  StrV<- StrV[2]
	}
    Tmp<- eval(parse(text=StrV)) 
    Px<- c(Tmp[1],0,0) 
    Qx<- c(Tmp[2],0,0)
    StrV<-strsplit(Yrange,"=",fixed=TRUE)
    StrV<- StrV[[1]]
    if(length(StrV)>1){
	  Yname<- StrV[1]
	  StrV<- StrV[2]
	}
    Tmp<- eval(parse(text=StrV)) 
    Py<- c(0,Tmp[1],0) 
    Qy<- c(0,Tmp[2],0)
    StrV<-strsplit(Zrange,"=",fixed=TRUE)
    StrV<- StrV[[1]]
    if(length(StrV)>1){
	  Zname<- StrV[1]
	  StrV<- StrV[2]
	}
    Tmp<- eval(parse(text=StrV)) 
    Pz<- c(0,0,Tmp[1])         
    Qz<- c(0,0,Tmp[2])
  }else{
    Data<- varargin[[1]]
    Xname<- "x"; Yname<- "y"; Zname<- "z"   
    if(Nargs>1){
      if(varargin[[2]]!=""){
        Xname<- varargin[[2]]
      }
      if(varargin[[3]]!=""){
        Yname<- varargin[[3]]
      }
      if(varargin[[4]]!=""){
        Zname<- varargin[[4]]
      }
    }
    Tmp<- Op(1,Data)
    Px<- Tmp[1,]; Qx<- Tmp[2,]
    Tmp<- Op(2,Data)
    Py<- Tmp[1,]
    Qy<- Tmp[2,]
    Tmp<- Op(3,Data)
    Pz<- Tmp[1,]
    Qz<- Tmp[2,]
  }
  Ph<- Parapt(Px); Qh<- Parapt(Qx); R<-Norm(Ph-Qh)
  Kekka<- list()                  
  if(R>Eps){
    Ch<- Qh+Dr/R*(Qh-Ph)
    Kekka<- c(Kekka,list(Pointdata(Ch)))
    Expr(Ch,"c",Xname)           
  }
  Ph<- Parapt(Py); Qh<- Parapt(Qy); R<- Norm(Ph-Qh)
  if(R>Eps){
    Ch<- Qh+Dr/R*(Qh-Ph)
    Kekka<- c(Kekka,list(Pointdata(Ch)))
    Expr(Ch,"c",Yname)
  }
  Ph<- Parapt(Pz); Qh<- Parapt(Qz); R<- Norm(Ph-Qh)
  if(R>Eps){
    Ch<- Qh+Dr/R*(Qh-Ph)
    Kekka<- c(Kekka,list(Pointdata(Ch)))
    Expr(Ch,"c",Zname)
  }
#  return(Kekka)
}

###################################

Xyzaxpersname<- function(...){
  varargin<- list(...)
  Eps<- 10.0^(-6)
  Nargs<- length(varargin)
  Dr<- 0.19*1000/2.54/MilliIn
  Tmp<- varargin[[Nargs]]
  if(Nargs>1 && mode(Tmp)=="numeric"){
    Dr<- Dr*Tmp
    Nargs<- Nargs-1
  }
  if(mode(varargin[[1]])=="character"){
    Xname<- "x"
	Yname<- "y"
	Zname<- "z"
    Xrange<- varargin[[1]]
    Yrange<- varargin[[2]]
    Zrange<- varargin[[3]]
    StrV<-strsplit(Xrange,"=",fixed=TRUE)
    StrV<- StrV[[1]]
    if(length(StrV)>1){
	  Xname<- StrV[1]
	  StrV<- StrV[2]
	}
    Tmp<- eval(parse(text=StrV)) 
    Px<- c(Tmp[1],0,0)
    Qx<- c(Tmp[2],0,0)
    StrV<-strsplit(Yrange,"=",fixed=TRUE)
    StrV<- StrV[[1]]
    if(length(StrV)>1){
	  Yname<- StrV[1]
	  StrV<- StrV[2]
	}
    Tmp<- eval(parse(text=StrV)) 
    Py<- c(0,Tmp[1],0)
    Qy<- c(0,Tmp[2],0)
    StrV<-strsplit(Zrange,"=",fixed=TRUE)
    StrV<- StrV[[1]]
    if(length(StrV)>1){
	  Zname<- StrV[1]
	  StrV<- StrV[2]
	}
    Tmp<- eval(parse(text=StrV))
    Pz<- c(0,0,Tmp[1]) 
    Qz<- c(0,0,Tmp[2])
  }else{
    Data<- varargin[[1]]
    Xname<- "x"; Yname<- "y"; Zname<- "z"
    if(Nargs>1){
      if(varargin[[2]]!=""){
        Xname<- varargin[[2]]
      }
      if(varargin[[3]]!=""){
        Yname<- varargin[[3]]
      }
      if(varargin[[4]]!=""){
        Zname<- varargin[[4]]
      }
    }
    Tmp<- Op(1,Data)
    Px<- Tmp[1,]; Qx<- Tmp[2,]
    Tmp<- Op(2,Data)
    Py<- Tmp[1,]
    Qy<- Tmp[2,]
    Tmp<- Op(3,Data)
    Pz<- Tmp[1,]
    Qz<- Tmp[2,]
  }
  Ph<- Perspt(Px)
  Qh<- Perspt(Qx)
  R<- Norm(Ph-Qh)
  Kekka<- list()
  if(R>Eps){
    Ch<- Qh+Dr/R*(Qh-Ph)
    Kekka<- c(Kekka,list(Pointdata(Ch)))
    Expr(Ch,"c",Xname)
  }
  Ph<- Perspt(Py)
  Qh<- Perspt(Qy)
  R<- Norm(Ph-Qh) 
  if(R>Eps){
    Ch<- Qh+Dr/R*(Qh-Ph)
    Kekka<- c(Kekka,list(Pointdata(Ch)))
    Expr(Ch,"c",Yname)
  }
  Ph<- Perspt(Pz)
  Qh<- Perspt(Qz)
  R<- Norm(Ph-Qh) 
  if(R>Eps){
    Ch<- Qh+Dr/R*(Qh-Ph)
    Kekka<- c(Kekka,list(Pointdata(Ch)))
    Expr(Ch,"c",Zname)
  }
#  return(Kekka)
}

#########################
#100815
Zparapt<- function(P){
  x<- P[1]; y<- P[2]; z<- P[3]
  Out<- x*cos(PHI)*sin(THETA)+y*sin(PHI)*sin(THETA)+z*cos(THETA)
  return(Out)
}

#########################
#100815
Zperspt<- function(P){
  Tmp<- P-FocusPoint
  X1<- Tmp[1]; Y1<- Tmp[2]; Z1<- Tmp[3]
  Tmp<- EyePoint-FocusPoint
  E1<- Tmp[1]; F1<- Tmp[2]; G1<- Tmp[3]
  Ca<- E1/sqrt(E1^2+F1^2)
  Sa<- F1/sqrt(E1^2+F1^2)
  X2<- X1*Ca+Y1*Sa; Y2<- -X1*Sa+Y1*Ca; Z2<- Z1
  E2<- E1*Ca+F1*Sa; F2<- -E1*Sa+F1*Ca; G2<- G1
  Cb<- E2/sqrt(E2^2+G2^2)
  Sb<- G2/sqrt(E2^2+G2^2)
  X3<- X2*Cb+Z2*Sb
  return(X3)
}

##########################################



##########################################

# Stat Package

##########################################

# 2010.04.12

# new

# Htickmarklower, Vtickmarkleft, HtickmarklowerV
# VtickmarkleftV, Insertcom, Replacecom
# Maketexfile, Formatting
# Drwhistframe, Histplotdata, Drwhistplot

Htickmarklower<- function(...)
{  ## Scaling is implemented 
  varargin<- list(...)
  Nargs<- length(varargin)
  ArgsL<- varargin
  if(mode(ArgsL[[1]])=="character"){
    Str<- ArgsL[[1]]
    Tmp<- strsplit(Str,"m")
    Tmp<- Tmp[[1]]
    if(length(Tmp)>1){
      I<- nchar(Tmp[1])+1
    }
    else{
      I<- 0
    }
    Tmp<- strsplit(Str,"n")
    Tmp<- Tmp[[1]]
    if(length(Tmp)>1){
      J<- nchar(Tmp[1])+1
    }
    else{
      J<- 0
    }
    Tmp<- strsplit(Str,"r")
    Tmp<- Tmp[[1]]
    if(length(Tmp)>1){
      K=nchar(Tmp[1])+1
    }
    else{
      K<- 0
    }
    if(K>0){
      S<- substr(Str,K+1,nchar(Str))
      R<-  as.numeric(S)
      if(is.na(R)){
        R<- 1
      }
    }
    else{
      R<- 1
      K<- nchar(Str)+1
    }
    if(J>0){
      S<- substr(Str,J+1,K-1)
      Dn<-  as.numeric(S)
      if(is.na(Dn)){
        Dn<- 1
      }
    }
    else{
      Dn<- 1000
      J<- nchar(Str)+1
    }
    S<- substr(Str,I+1,J-1)
    Dm<- as.numeric(S)
    if(is.na(Dm)){
      Dm<- 1
    }
    ArgsL<- list()
    for (I in Looprange(1, floor((XMAX-GENTEN[1])/Dm))){
      ArgsL<- Mixjoin(ArgsL,I*Dm)
      if(I-floor(I/Dn)*Dn==0){
        Str<- as.character(I*Dm*R)
        ArgsL<- Mixjoin(ArgsL,Str)
      }
    }
    for (I in seq(-1,ceiling((XMIN-GENTEN[1])/Dm),by=-1)){
      ArgsL<- Mixjoin(ArgsL,I*Dm)
      if(I-floor(I/Dn)*Dn==0){
        Str<- as.character(I*Dm*R)
        ArgsL<- Mixjoin(ArgsL,Str)
      }
    }
  }
  MemoriList<- list()
  Memori<- list()
  for (N in 1:length(ArgsL)){
    Dt<- ArgsL[[N]]
    if(mode(Dt)=="numeric" && length(Dt)>1){
      if(length(Memori)>0){
        MemoriList<- Mixjoin(MemoriList,list(Memori))
      }
      Memori<- list(Dt)
      next
    }
    if(mode(Dt)=="character"){
      Memori<- Mixjoin(Memori,Dt)
    }
    else{
      if(length(Memori)>0){
        MemoriList<- Mixjoin(MemoriList,list(Memori))
      }
      Memori<- list(Dt,GENTEN[2])
    }
  }
  MemoriList<- Mixjoin(MemoriList,list(Memori))
  for (N in 1:length(MemoriList)){
    Dt<- MemoriList[[N]]
    Ndt<- length(Dt)
    X=Op(1,Dt)
    Y=Op(2,Dt)
    Tmp<-Doscaling(c(X,Y))
    X<- Tmp[1]
    Y<- Tmp[2]
    Moji<- Op(Ndt,Dt)
    Tmp1<- Unscaling(c(X,Y))
    Tmp2<- Unscaling(c(X,Y-2*MARKLEN))
    Fd<- Listplot(c(Tmp1,Tmp2))
    Drwline(Fd)
    if(Ndt==3){
      Tmp<-Unscaling(c(X,Y-2*MARKLEN))
      Expr(Tmp,"s",Moji)
    }
    if(Ndt==4){
      Houkou<- Op(3,Dt)
      Tmp<-grep("s",Houkou)
      if(length(Tmp)>0){
        Tmp<-Unscaling(c(X,Y-2*MARKLEN))
        Expr(Tmp,Houkou,Moji)
      }
      else{
        Tmp<- Unscaling(c(X,Y))
        Expr(Tmp,Houkou,Moji)
      }
    }
      cat("%\n",file=Wfile,append=TRUE)
  }
}

Vtickmarkleft<- function(...)
{  ## Scaling is implemented 
  varargin<- list(...)
  Nargs<- length(varargin)
  ArgsL<- varargin
  if(mode(ArgsL[[1]])=="character"){
    Str<- ArgsL[[1]]
    Tmp<- strsplit(Str,"m")
    Tmp<- Tmp[[1]]
    if(length(Tmp)>1){
      I<- nchar(Tmp[1])+1
    }
    else{
      I<- 0
    }
    Tmp<- strsplit(Str,"n")
    Tmp<- Tmp[[1]]
    if(length(Tmp)>1){
      J<- nchar(Tmp[1])+1
    }
    else{
      J<- 0
    }
    Tmp<- strsplit(Str,"r")
    Tmp<- Tmp[[1]]
    if(length(Tmp)>1){
      K=nchar(Tmp[1])+1
    }
    else{
      K<- 0
    }
    if(K>0){
      S<- substr(Str,K+1,nchar(Str))
      R<-  as.numeric(S)
      if(is.na(R)){
        R<- 1
      }
    }
    else{
      R<- 1
      K<- nchar(Str)+1
    }
    if(J>0){
      S<- substr(Str,J+1,K-1)
      Dn<-  as.numeric(S)
      if(is.na(Dn)){
        Dn<- 1
      }
    }
    else{
      Dn<- 1000
      J<- nchar(Str)+1
    }
    S<- substr(Str,I+1,J-1)
    Dm<- as.numeric(S)
    if(is.na(Dm)){
      Dm<- 1
    }
    ArgsL<- list()
    for (I in 1:floor((YMAX-GENTEN[2])/Dm)){
      ArgsL<- Mixjoin(ArgsL,I*Dm)
      if(I-floor(I/Dn)*Dn==0){
        Str<- as.character(I*Dm*R)
        ArgsL<- Mixjoin(ArgsL,Str)
      }
    }
    for (I in seq(-1,ceiling((YMIN-GENTEN[2])/Dm))){
      ArgsL<- Mixjoin(ArgsL,I*Dm)
      if(I-floor(I/Dn)*Dn==0){
        Str<- as.character(I*Dm*R)
        ArgsL<- Mixjoin(ArgsL,Str)
      }
    }
  }
  MemoriList<- list()
  Memori<- list()
  for (N in 1:length(ArgsL)){
    Dt<- ArgsL[[N]]
    if(mode(Dt)=="numeric" && length(Dt)>1){
      if(length(Memori)>0){
        MemoriList<- Mixjoin(MemoriList,list(Memori))
      }
      Memori<- list(Dt)
      next
    }
    if(mode(Dt)=="character"){
      Memori<- Mixjoin(Memori,Dt)
    }
    else{
      if(length(Memori)>0){
        MemoriList<- Mixjoin(MemoriList,list(Memori))
      }
      Memori<- list(GENTEN[1],Dt)
    }
  }
  MemoriList<- Mixjoin(MemoriList,list(Memori))
  for (N in 1:length(MemoriList)){
    Dt<- MemoriList[[N]]
    Ndt<- length(Dt)
    X=Op(1,Dt)
    Y=Op(2,Dt)
    Tmp<-Doscaling(c(X,Y))
    X<- Tmp[1]
    Y<- Tmp[2]
    Moji<- Op(Ndt,Dt)
    Tmp1<- Unscaling(c(X,Y))
    Tmp2<- Unscaling(c(X-2*MARKLEN,Y))
    Fd<- Listplot(c(Tmp1,Tmp2))
    Drwline(Fd)
    if(Ndt==3){
      Tmp<-Unscaling(c(X-2*MARKLEN,Y))
      Expr(Tmp,"w",Moji)
    }
    if(Ndt==4){
      Houkou<- Op(3,Dt)
      Tmp<-grep("w",Houkou)
      if(length(Tmp)>0){
        Tmp<-Unscaling(c(X-2*MARKLEN,Y))
        Expr(Tmp,Houkou,Moji)
      }
      else{
        Tmp<- Unscaling(c(X,Y))
        Expr(Tmp,Houkou,Moji)
      }
    }
      cat("%\n",file=Wfile,append=TRUE)
  }
}

HtickmarklowerV<- function(Vec,digits=2,nsmall=2)
{
  for (I in 1:length(Vec)){
    Tmp<- Vec[I]
    Htickmarklower(Tmp, Formatting(Tmp,digits,nsmall))
  }
}

HtickLV<- function(...)
{
  HtickmarklowerV(...)
}

VtickmarkleftV<- function(Vec,digits=2,nsmall=2)
{
  for (I in 1:length(Vec)){
    Tmp<- Vec[I]
    Vtickmarkleft(Tmp, Formatting(Tmp,digits,nsmall))
  }
}

VtickLV<- function(...)
{
  VtickmarkleftV(...)
}

Insertcom<- function(CmdM,Npos,Str)
{
  if(is.matrix(CmdM)){
    Cmd<- CmdM
  }
  else{
    C<- paste("Cmd<- ",CmdM)
    eval(parse(text=C))
  }
  Out<- Cmd[Looprange(1,Npos-1),]
  Out<- c(Out,Str)
  Tmp<- Cmd[Looprange(Npos,nrow(Cmd)),]
  Out<- c(Out,Tmp)
  Out<- matrix(Out)
  if(!is.matrix(CmdM)){
    C<- paste(CmdM,"<<- Out")
    eval(parse(text=C))
  }
  return(Out)
}

Replacecom<- function(CmdM,Npos,Str)
{
  if(is.matrix(CmdM)){
    Cmd<- CmdM
  }
  else{
    C<- paste("Cmd<- ",CmdM)
    eval(parse(text=C))
  }
  Out<- Cmd[Looprange(1,Npos-1),]
  Out<- c(Out,Str)
  Tmp<- Cmd[Looprange(Npos+1,nrow(Cmd)),]
  Out<- c(Out,Tmp)
  Out<- matrix(Out)
  if(!is.matrix(CmdM)){
    C<- paste(CmdM,"<<- Out")
    eval(parse(text=C))
  }
  return(Out)
}

Deletecom<- function(CmdM,Npos)
{
  if(is.matrix(CmdM)){
    Cmd<- CmdM
  }
  else{
    C<- paste("Cmd<- ",CmdM)
    eval(parse(text=C))
  }
  Out<- Cmd[Looprange(1,Npos-1),]
  Tmp<- Cmd[Looprange(Npos+1,nrow(Cmd)),]
  Out<- c(Out,Tmp)
  Out<- matrix(Out)
  if(!is.matrix(CmdM)){
    C<- paste(CmdM,"<<- Out")
    eval(parse(text=C))
  }
  return(Out)
}

Maketexfile<- function(commands="",texfile="")
{
  Openfile(texfile)
  Execmd(commands)
  Closefile()
}

Formatting<- function(X,D=2,N=2)
{
  if(D>0){
    Xs <- format(X,digits=D,nsmall=N)
  }
  else{
    Xs<- as.character(X)
  }
  return(Xs)
}

################################

Boxplotdata1 <-function(DataF1,CenterX,Width,...)
{
  Xr <- Width
  Temp <- boxplot(DataF1[1],plot=FALSE)
  Stats <- Temp$stats     
  rownames(Stats) <- c("Lhige","Q1","Q2","Q3","Uhige")
  Out <- Temp$out
  Lhige <- Stats["Lhige",1]
  Uhige <- Stats["Uhige",1]
  Q1 <- Stats["Q1",1]
  Q2 <- Stats["Q2",1]
  Q3 <- Stats["Q3",1]
  CenterY <- (Q1+Q3)/2
  C <- c(CenterX,CenterY)
  V <- c(0,(Q3-Q1)/2)
  G1 <- Framedata(C,Xr/2,V[2]) # box
  Temp1 <- c(0,Q1-Lhige)
  Temp2 <- c(0,Uhige-Q3)
  G2 <- Listplot(C-V,C-V-Temp1) #
  G3 <- Listplot(C+V,C+V+Temp2) #
  Temp3 <- c(Xr/4,0)
  G4 <- Listplot(C-V-Temp1-Temp3,C-V-Temp1+Temp3) #
  G5 <- Listplot(C+V+Temp2-Temp3,C+V+Temp2+Temp3) #
  Temp4 <- c(0,Q3-Q2)
  Temp5 <- c(Xr/2,0)
  G6 <- Listplot(C+V-Temp4-Temp5,C+V-Temp4+Temp5) #
  G7 <- list()
  for(j in Looprange(1,length(Out))){
    G7 <- c(G7,list(c(CenterX, Out[j])))
  }
  G7 <- G7[order(Out,decreasing=TRUE)]
  list(median=G6,box=G1,uwhisker=G2,lwhisker=G3,lwp=G4,uwp=G5,outliers=G7)
}

Boxplotdata2 <- function(Data,Ratio, ...)
{
  DataF<- Flattenlist(Data)  # 11.07.21(from)
  ymin<- Inf
  ymax<- -Inf
  for(J in 1:length(DataF)){
    Tmp<- DataF[[J]]
    ymin<- min(ymin, min(Tmp))
    ymax<- max(ymax,max(Tmp))
  }                                           # 11.07.21(until)
  dy <- ymax-ymin
  Setwindow(c(0,XMAX-XMIN),c(ymin-0.1*dy,ymax+0.1*dy))
  R1<- (YMAX-YMIN)/(XMAX-XMIN)
  R<- Ratio/R1
  Setscaling(R)
  Delta <- XMAX/length(DataF)
  W <- 0.6*Delta
  PdL <- list()
  for(i in 1:length(DataF)){  # 11.07.21
    X <- (0.5+i-1)*Delta
    G <- Boxplotdata1(DataF[i],X,W,...)
    PdL <- c(PdL,list(G))
  }
  G <- Framedata()
  Tmp<- list(frame=G)  
  PdL <-c(PdL,list(Tmp))  
  Epsi <-0
  Setwindow(c(XMIN-Epsi,XMAX+Epsi),c(YMIN-Epsi,YMAX+Epsi))
  return(PdL)
}

Drwboxframe<-function(BoxDataL)
{
  Setorigin(c(XMIN,YMIN))
  Tmp<- Unscaling(c(0.2,0.2))
  Setwindow(c(XMIN-0.2,XMAX),c(YMIN-Tmp[2],YMAX))
  Hako<- BoxDataL$plotdata
  title<- BoxDataL$title
  cap<- BoxDataL$cap
  ylab<- BoxDataL$ylab
  if(mode(title)!="list") title<- list(title)
  if(mode(cap)!="list") cap<- list(cap)
  if(mode(ylab)!="list") ylab<- list(ylab)
  if(length(title)==0) title<- list("")
  if(length(title)==1) title<- c(title, list("n"))
  if(length(title)==2) title<- c(title, list(""))
  if(length(cap)==0) cap<- list("")
  if(length(cap)==1) cap<- c(cap, list("n"),0)  # 11.11.27
  if(length(cap)==2) cap<- c(cap, 0)  # 11.11.27
  if(length(ylab)==0) ylab<- list("")
  if(length(ylab)==1) ylab <- c(ylab, list("n"))
  if(length(ylab)==2) ylab<- c(ylab, list(""))
  Temp <- Hako[[length(Hako)]]
  Drwline(Temp$frame)       
  Fontsize(cap[[2]])
  for(i in Looprange(1,length(Hako)-1)){
    Temp <- Hako[[i]]
    attach(Temp)   
      Dashline(uwhisker,lwhisker)   
      Drwline(median,2)    
      Drwline(box,lwp,uwp)    
      Drwpt(outliers,0)         
      X <- uwhisker[1,1]
    detach(Temp)   
    Htickmarklower(X)
    if(nchar(cap[[1]])<1) next  # 2011.03.08
    if(length(cap)==2 || cap[[3]]==0){
      pos<- 1
      if(length(cap)>=4) pos<- cap[[4]]
      Tmp<- paste("s",as.character(pos),sep="")
      Letter(c(X,YMIN),Tmp, Op(i,cap[[1]]))
    }
    else{
      rotate<- cap[[3]] 
      if(length(cap)==3){
        pos<- 0
      }
      else{
        pos<- cap[[4]]
      }
      Temp1 <- rotate*pi/180
      Temp <- c(cos(Temp1),sin(Temp1))
      Letterrot(c(X,YMIN-pos),Temp,Op(i,cap[[1]]))
    }
  }
  if(nchar(ylab[[1]])>0){
    Fontsize(ylab[[2]])
	Tmp1<- ylab[[1]]
	Tmp3<- ylab[[3]]
	if(nchar(Tmp3)>0){
      Tmp1<- paste("{\\",Tmp3," ",Tmp1,"}",sep="")
    }
    Letter(c(XMIN, YMAX),"n2",Tmp1)
    Fontsize("n")
  }
  if(nchar(title[[1]])>0){
    Fontsize(title[[2]])
	Tmp1<- title[[1]]
	Tmp3<- title[[3]]
	if(nchar(Tmp3)>0){
      Tmp1<- paste("{\\",Tmp3," ",Tmp1,"}",sep="")
    }
    Letter(c((XMIN+XMAX)/2,YMAX),"n2",Tmp1)
  }
  Fontsize("n")
}

Drwboxplot<- function(dataf,var,size,
           title=list(""), cap=list(colnames(dataf)),
           ylab=list(""), ptsize=5,plot=TRUE,...)
           #Return : title,cap,ylab,commands,plotdata,info
{
  Tmp <- boxplot(dataf, plot=FALSE, ...)
  Stats <- Tmp$stats 
  DataF<- Flattenlist(dataf)  # 11.07.21(from)
  ymin<- Inf
  ymax<- -Inf
  for(J in 1:length(DataF)){
    Tmp<- DataF[[J]]
    ymin<- min(ymin, min(Tmp))
    ymax<- max(ymax,max(Tmp))
  }                                           # 11.07.21(until)
  Hako<- Boxplotdata2(dataf, size[2]/size[1], ...)
  if(plot){
    Windisp(Hako)
  }
  Tmp<- Formatting(size[1]/(XMAX-XMIN),5,5)
  unit<- paste(Tmp,"cm",sep="")
  Setunitlen(unit)
  Exstr<- c(
    "","",
    paste("Beginpicture(","'",unit,"')",sep=""),
    paste("Setpt(",as.character(ptsize),")",sep=""),
    "","",     
    paste("Drwboxframe(",var,")",sep=""),
    paste("VtickLV(c(",as.character(ymin),",", as.character(ymax),"),0,0)",sep=""),
    "","","","",
    "Setpt(1)",    
    "Endpicture(0)"
  )
  Exstr<- matrix(Exstr)
  Xpos<- c()
  for(i in Looprange(1,length(Hako)-1)){
    Temp <- Hako[[i]]
    Temp1 <- Temp[[5]]
    Xpos <- c(Xpos,Temp1[1,1])
  }
  Info<- list(stats=Stats,window=matrix(c(XMIN,XMAX,YMIN,YMAX),nrow=2),xpos=Xpos)
  Tmp<- paste(var,"<<- ",
                 "list(title=title,cap=cap,ylab=ylab,",
                 "commands=Exstr,plotdata=Hako,info=Info)",sep="")
  eval(parse(text=Tmp)) 
}


###########################################

Histplotdata <- function(DataV,Ratio,freq=TRUE,densplot=FALSE,...)
# 10.12.07  freq
{
  Temp <- hist(DataV,plot=FALSE,...)
  Breaks <- Temp$breaks
  Counts <- Temp$counts
  Density <- Temp$density
  Mids  <- Temp$mids
  if(!freq){
     Data<- Density
  }
  else{
    Data<- Counts
  }  
  Ghist <- list()
  for(i in Looprange(1,length(Breaks)-1)){
    Tmp1 <- c(Breaks[i],Breaks[i+1])
    Tmp2 <- c(0,Data[i])
    G1 <- Framedata(Tmp1,Tmp2) #bar
    Ghist <- c(Ghist,list(G1))
  }
  Bin <- Breaks[2]-Breaks[1]
  Eps <- 0.7*Bin # 0.7 times Bin
  Temp1 <- c(min(Breaks)-Eps,max(Breaks)+Eps)  # Put Eps at both sides
  Temp2 <- c(0,max(Data)*1.02)
  Setwindow(Temp1,Temp2)
  Setorigin(c(Temp1[1],0))
  R1<- (YMAX-YMIN)/(XMAX-XMIN)
  R<- Ratio/R1
  Setscaling(R)
  VEps <- 0.05*(XMAX-XMIN)/5
  Temp1<- Temp1-c(VEps,0)
  Temp2<-  Temp2-1/R*c(VEps,0)
  Setwindow(Temp1,Temp2)
  Fpt <- c(Mids[1]-Bin,0)
  Lpt <- c(Mids[length(Mids)]+Bin,0)
  Fp <- matrix(Fpt,nrow=1)
  for(i in Looprange(1,length(Mids))){
    Tmp <- c(Mids[i],Data[i])
    Fp <- rbind(Fp,Tmp)
  }
  Fp <- rbind(Fp,Lpt)
  rownames(Fp)<- c(1:nrow(Fp))
  if(densplot){
    Temp <- density(DataV)
    X <- matrix(Temp$x)     
    Y <- matrix(Temp$y)     
    Gdens <- cbind(X,Y)
  }
  else{
    Gdens <- list()
  } 
  list(plotdata=list(histplot=Ghist,fpplot=list(Fp),densityplot=list(Gdens)),
       breaks=Breaks,counts=Counts,density=Density,mids=Mids)
}

Drwhistframe<-function(HistDataL)
{
  title<- HistDataL$title
  xlab<- HistDataL$xlab
  ylab<- HistDataL$ylab
  if(mode(title)!="list") title<- list(title)
  if(mode(xlab)!="list") cap<- list(xlab)
  if(mode(ylab)!="list") cap<- list(ylab)
  if(length(title)==0) title<- list("")
  if(length(title)==1) title<- c(title, list("n"))
  if(length(title)==2) title<- c(title, list(""))
  if(length(xlab)==0) xlab<- list("")
  if(length(xlab)==1) xlab<- c(xlab, list("n"))
  if(length(xlab)==2) xlab<- c(xlab, list(""))
  if(length(xlab)==3) xlab<- c(xlab, list(8))
  if(length(ylab)==0) ylab<- list("")
  if(length(ylab)==1) ylab<- c(ylab, list("n"))
  if(length(ylab)==2) ylab<- c(ylab, list(""))
  if(nchar(title[[1]])>0){
    Fontsize(title[[2]])
	Tmp1<- title[[1]]
	Tmp3<- title[[3]]
	if(nchar(Tmp3)>0){
      Tmp1<- paste("{\\",Tmp3," ",Tmp1,"}",sep="")
    }
    Letter(c((XMIN+XMAX)/2,YMAX),"n2",Tmp1)
    Fontsize("n")
  }
  if(nchar(xlab[[1]])>0){
    Fontsize(xlab[[2]])
	Tmp1<- xlab[[1]]
	Tmp3<- xlab[[3]]
	if(nchar(Tmp3)>0){
      Tmp1<- paste("{\\",Tmp3," ",Tmp1,"}",sep="")
    }
	Tmp4<- paste("s",as.character(xlab[[4]]),sep="")
    Letter(c((XMIN+XMAX)/2,YMIN),Tmp4,Tmp1)
    Fontsize("n")
  }
  if(nchar(ylab[[1]])>0){
    Fontsize(ylab[[2]])
	Tmp1<- ylab[[1]]
	Tmp3<- ylab[[3]]
	if(nchar(Tmp3)>0){
      Tmp1<- paste("{\\",Tmp3," ",Tmp1,"}",sep="")
    }
	Tmp<- Setorigin()
    Letter(c(Tmp[1], YMAX),"n2",Tmp1)
    Fontsize("n")
  }
  
  Setax(2," ")
  Setax(4," ")
  Setax(6," ")
}

Drwhistplot<- function(datav,var,size,freq=TRUE,
           title=list(""), xlab=list(""), ylab=list(""),
           plot=TRUE,densplot=FALSE,fpplot=TRUE,...)
           #Output : title,xlab,ylab,commands,plotdata,info
{
  H <- Histplotdata(datav, size[2]/size[1], freq=freq,densplot=densplot,...)
  Pd<- H$plotdata
  Ghist <- list(histplot=Pd$histplot,densityplot=Pd$densityplot)  # 10.12.07
  if(fpplot){
    Ghist<- c(Ghist,list(fpplot=Pd$fpplot))
  }
  if(plot){  
    Windisp(Ghist)
  }
  Tmp<- Formatting(size[1]/(XMAX-XMIN),5,5)
  unit<- paste(Tmp,"cm",sep="")
  Setunitlen(unit)
  Infostr<- paste(var,"$info",sep="")
  Brkstr<- paste(Infostr,"$breaks",sep="")
  Midstr<- paste(Infostr,"$mids",sep="")
  if(!freq){
    Digits<- ",2,2"
    Denstr<- paste(Infostr,"$density",sep="")
  }
  else{
    Digits<- ",0,0"
    Denstr<- paste(Infostr,"$counts",sep="")
  }
  
  if(fpplot) Prefp<- "" else Prefp<- "#"
  Exstr<- c(
    "","",
    paste("Beginpicture(","'",unit,"')",sep=""),
    "","",     
    paste("Drwhistframe(",var,")",sep=""),
	paste("HtickLV(",Midstr,",1,1)",sep=""),
	paste("VtickLV(max(",Denstr,")",Digits,")",sep=""),
    paste("Drwline(",var,"[['plotdata']]","$histplot)",sep=""),
    paste(Prefp,"Dashline(",var,"[['plotdata']]","$fpplot)",sep=""),
    paste("#Drwline(",var,"[['plotdata']]","$densityplot,2)",sep=""),
    "","","","",
    "Endpicture(1)"
  )
  Exstr<- matrix(Exstr)
  Info<- list(breaks=H$breaks,counts=H$counts,density=H$density,mids=H$mids,
              window=matrix(c(XMIN,XMAX,YMIN,YMAX),nrow=2))
  Tmp<- paste(var,"<<- ",
              "list(title=title,xlab=xlab,ylab=ylab,",
              "commands=Exstr,plotdata=Ghist,info=Info)",sep="")
  eval(parse(text=Tmp)) 
}

##########################
#17.09.30

Bezierpt<- function(t,Ptlist,Ctrlist){
  if(length(Ptlist)==6){
    P0=Ptlist[1:3]
    P3=Ptlist[4:6]
    P1=Ctrlist[1:3]
    if(length(Ctrlist)==3){
      P2=P3
      flg3=0
    }else{
      P2=Ctrlist[4:6]
      flg3=1
    }
  }else{
    P0=Ptlist[1:2]
    P3=Ptlist[3:4]
    P1=Ctrlist[1:2]
    if(length(Ctrlist)==2){
      P2=P3
      flg3=0
    }else{
      P2=Ctrlist[3:4]
      flg3=1
    }
  }
  P4=(1-t)*P0+t*P1
  P5=(1-t)*P1+t*P2
  P6=(1-t)*P2+t*P3
  P7=(1-t)*P4+t*P5
  P8=(1-t)*P5+t*P6
  P9=(1-t)*P7+t*P8
  if(flg3==0){
    Out=P7
  }else{
    Out=P9
  }
  return(Out)
}

Bezier<- function(...){
  varargin<- list(...)
  Nargs=length(varargin)
  Ptlist=varargin[[1]]
  Ctrlist=varargin[[2]]
  Num=10
  for(J in Looprange(3,Nargs)){
    Tmp=varargin[[J]]
    K=strsplit(Tmp,'=',fixe=TRUE)
    K=K[[1]]
    Tmp1=substring(K[1],1,1)
    Lhs=toupper(Tmp1)
    if(Lhs=="N"){
       Num=eval(parse(text=K[2]))
    }
  }
  if(length(Num)==1){
    Num=rep(Num,length(Ctrlist)) #17.10.08
  }
  Out=c()
  for(ii in Looprange(1,length(Ctrlist))){
    Tmp1=c(Ptlist[[ii]],Ptlist[[ii+1]])
    Tmp2=Ctrlist[[ii]]
    if(ii==1){
      St=0
    }else{
      St=1
    }
    for(J in Looprange(St,Num[ii])){
      Tmp=Bezierpt(J/Num[ii],Tmp1,Tmp2)
      Out=Appendrow(Out,Tmp)
    }
  }
  return(Out)
}

#######################
#  17.10.02

Connectseg<- function(...){
  varargin=list(...)
  Nargs=length(varargin)
  Pdata=varargin[[1]]
  Eps=10^(-4)
  if(Nargs>=2){
    Eps=varargin[[2]]
  }
  if(is.matrix(Pdata)){
    Din=Dataindex(Pdata)
    tmp1=list()
    for(J in 1:nrow(Din)){
      tmp=Pdata[Din[J,1]:Din[J,2],]
      tmp1=c(tmp1,list(tmp))
    }
    Pdata=tmp1
  }
  PlotL=list(Op(1,Pdata))
  VI=Looprange(2,length(Pdata))
  while(length(VI)>0){
	Qd=Op(Length(PlotL),PlotL)
    Ah=Op(1,Qd); Ao=Op(Length(Qd),Qd)
    Flg=0
    for(J in 1:length(VI)){
      Tmp1=Op(VI[J],Pdata)
      P=Op(1,Tmp1); Q=Op(Length(Tmp1),Tmp1)
      if(Norm(P-Ao)<Eps){
		Tmp=Tmp1[Looprange(2,Length(Tmp1)),]
         if(Length(Tmp)>0){
          Qd=Appendrow(Qd,Tmp)
        }
        PlotL[[length(PlotL)]]=Qd
        VI=VI[-J]
        Flg=1
        break
      }
      if(Norm(Q-Ao)<Eps){
        Tmp=Tmp1[(nrow(Tmp1)-1):1,]
        Qd=Appendrow(Qd,Tmp)
        PlotL[[length(PlotL)]]=Qd
        VI=VI[-J]
        Flg=1
        break
      }
      if(Norm(P-Ah)<Eps){
        Tmp=Tmp1[2:nrow(Tmp1),]
        Qd=Appendrow(Tmp,Qd)
        PlotL[[length(PlotL)]]=Qd
        VI=VI[-J]
        Flg=1
        break
      }
      if(Norm(Q-Ah)<Eps){
        Tmp=Tmp1[(nrow(Tmp1)-1):1,]
        Qd=Appendrow(Tmp,Qd)
        PlotL[[length(PlotL)]]=Qd
        VI=VI[-J]
        Flg=1
        break
      }
    }
    if(Flg==0){
      PlotL=c(PlotL,Pdata[VI[1]])
      VI=VI[-1]
    }
  }
  return(PlotL)
}

Implicitplot<- function(...){ #180402
  varargin=list(...)
  Eps=10^(-4)
  Nargs=length(varargin)
  Func=varargin[[1]]
  Xrng=varargin[[2]]
  Yrng=varargin[[3]]
  Mdv=50;Ndv=50
  for (I in Looprange(4,length(varargin))){
    Str= varargin[[I]]
    Tmp=strsplit(Str,"=",fixed=TRUE)
    Tmp=Tmp[[1]]
	Tmp1=toupper(Tmp[1])
    if(substring(Tmp1,1,1)=="N"){
      Mdv=eval(parse(text=Tmp[2]))
      if(length(Mdv)==1){
        Ndv=Mdv
      }else{
        Ndv=Mdv[2]
        Mdv=Mdv[1]
      }
    }
  }
  Tmp=strsplit(Func,"=",fixed=TRUE)
  Tmp=Tmp[[1]]
  if(length(Tmp)==1){
    Fn=Func
  }else{
    Fn=paste(Tmp[1],"-(",Tmp[2],")",sep="")
  }
  Tmp=strsplit(Xrng,"=",fixed=TRUE)
  Tmp=Tmp[[1]]
  Varx=Tmp[1]
  Rngx=eval(parse(text=Tmp[2]))
  Tmp=strsplit(Yrng,"=",fixed=TRUE)
  Tmp=Tmp[[1]]
  Vary=Tmp[1]
  Rngy=eval(parse(text=Tmp[2]))
  Tmp=paste("Impfun<- function(",Varx,",",Vary,"){",Fn,"}",sep="")
  eval(parse(text=Tmp))
  dx=(Rngx[2]-Rngx[1]) #180929
  dy=(Rngy[2]-Rngy[1]) #180929
  out=list()  
  for(jj in 1:Ndv){
    yval1=Rngy[1]+(jj-1)*dy/Ndv #180929
    yval2=Rngy[1]+jj*dy/Ndv #180929
    xval1=Rngx[1]
    eval11=Impfun(xval1,yval1)
    eval12=Impfun(xval1,yval2)
    for(ii in 1:Mdv){
      xval2=Rngx[1]+ii*dx/Mdv #180929
      eval21=Impfun(xval2,yval1)
      eval22=Impfun(xval2,yval2)
      pL=list(c(xval1,yval1));vL=c(eval11)
      pL=c(pL,list(c(xval2,yval1)));vL=c(vL,eval21)
      pL=c(pL,list(c(xval2,yval2)));vL=c(vL,eval22)
      pL=c(pL,list(c(xval1,yval2)));vL=c(vL,eval12)
      pL=c(pL,list(c(xval1,yval1)));vL=c(vL,eval11)
      qL=c()
      for(kk in 1:4){
        if(abs(vL[kk])<=Eps){
          qL=Appendrow(qL,pL[[kk]])
        }else{
          if(vL[kk]>Eps){
            if(vL[kk+1]< -Eps){
              tmp=1/(vL[kk]-vL[kk+1])*
                    (-vL[kk+1]*pL[[kk]]+vL[kk]*pL[[kk+1]])
              qL=Appendrow(qL,tmp)
			}
          }else{
            if(vL[kk+1]>Eps){
              tmp=1/(-vL[kk]+vL[kk+1])*
                    (vL[kk+1]*pL[[kk]]-vL[kk]*pL[[kk+1]])
              qL=Appendrow(qL,tmp)
			}
          }
        }
      }
      xval1=xval2
      eval11=eval21
      eval12=eval22
	  if(Length(qL)==2){
        out=c(out,list(qL))
      }
    }
  }
  if(length(out)>0){
    out=Connectseg(out)
  }
  if(length(out)==1){
    out=out[[1]]
  }
  return(out)
}

#########################
# 17.10.06

Deqdata=function(deq,rng,initt,initf,Num){
  Eps=10^(-3)
  inf=10^3
  tmp=strsplit(deq,"=")[[1]]
  tmp1=gsub("`","",tmp[1],fixed=TRUE)
  tmp1=substring(tmp1,3,nchar(tmp1)-1)
  Xname=strsplit(tmp1,",")[[1]]
  func=tmp[2]
  for(J in 1:(length(Xname))){
    tmp1=paste("X[",as.character(J),"]",sep="")
    func=gsub(Xname[J],tmp1,func,fixed=TRUE)
  }
  tmp=strsplit(rng,"=")[[1]]
  tname=tmp[1]
  tmp=eval(parse(text=tmp[2]))
  t1=tmp[1]
  t2=tmp[2]
  tmp=paste("function(",tname,",X){",func,"}",sep="")
  funP=eval(parse(text=tmp))
  tmp=paste("function(",tname,",X){-",func,"}",sep="")
  funN=eval(parse(text=tmp))
  dt=(t2-t1)/Num
  tt=initt
  X0=initf
  pdL=c(tt,X0)
  for(J in Looprange(1,floor((t2-initt)/dt))){
    kl1=dt*funP(tt,X0)
    kl2=dt*funP(tt+dt/2,X0+kl1/2)
    kl3=dt*funP(tt+dt/2,X0+kl2/2)
    kl4=dt*funP(tt+dt,X0+kl3)
    X0=X0+(kl1+2*kl2+2*kl3+kl4)/6
    tt=initt+J*dt
    tmp=c(tt,X0)
    if(Norm(tmp)>inf){break}
    pdL=Appendrow(pdL,tmp)
  }
  tt=initt
  X0=initf
  for(J in Looprange(1,floor((initt-t1)/dt))){
    kl1=dt*funN(tt,X0)
    kl2=dt*funN(tt+dt/2,X0+kl1/2)
    kl3=dt*funN(tt+dt/2,X0+kl2/2)
    kl4=dt*funN(tt+dt,X0+kl3)
    X0=X0+(kl1+2*kl2+2*kl3+kl4)/6
    tt=initt-J*dt
    tmp=c(tt,X0)
    if(Norm(tmp)>inf){break}
    pdL=Appendrow(tmp,pdL)
  }
  pdL
}

Deqplot=function(...){
  varargin=list(...)
  deq=varargin[[1]]
  rng=varargin[[2]]
  initt=varargin[[3]]
  initf=varargin[[4]]
  Num=50
  Sel=c(1,2)
  for(J in Looprange(5,length(varargin))){
    tmp1=varargin[[J]]
    if(is.character(tmp1)){
      tmp=strsplit(tmp1,"=")[[1]]
      Num=eval(parse(text=tmp[2]))
    }else{
      SeL=tmp1
    }
  }
  pdL=Deqdata(deq,rng,initt,initf,Num)
  pdL=pdL[,SeL]
}


############## obj ###############

Openobj<- function(Fnm){
  OBJFMT<<- "%7.4f"
  NPOINT<<- 0
  NNORM<<- 0
  OBJSCALE<<- 1
  OBJFIGNO<<- 0
  OBJJOIN<<- 0
  Wfile<<- Fnm
  Tmp=grep(".obj",Fnm,fixed=TRUE)
  if(length(Tmp)==0){
    if(nchar(Fnm)>0){
      Wfile<<- paste(Fnm,".obj",sep="")
    }
  }
  cat("",file=Wfile,sep="")
  Wfile
}

Closeobj<- function(){
  Wfile=""
}

Writeobjpoint<- function(P){
  X=sprintf(OBJFMT,P[1]*OBJSCALE)
  Y=sprintf(OBJFMT,P[2]*OBJSCALE)
  Z=sprintf(OBJFMT,P[3]*OBJSCALE)
  Str=paste("v",X,Y,Z,sep=" ")
  Printobjstr(Str)
  NPOINT<<- NPOINT+1
  return(NPOINT)
}

Printobjstr<- function(Str){
  cat(Str,"\n",sep="",file=Wfile,append=TRUE)
}

Objname<- function(){
  if(OBJJOIN==0){
    OBJFIGNO<<- OBJFIGNO+1
    Gname=paste("ketfig",as.character(OBJFIGNO),sep="")
    Printobjstr(paste("# ",Gname,sep=""))
    Printobjstr(paste("g ",Gname,sep=""))
  }
}

Objjoin<- function(...){
  varargin=list()
  if(length(varargin)>0){
    OBJJOIN<<- abs(sign(varargin[[1]]))
  }
  OBJJOIN
}

Objsurf<- function(...){ #17.12.18
  Args<- list(...)
  Nargs<- length(Args)
  Sel=Args[[Nargs]]; Nargs=Nargs-1
  Rf=Args[[1]]
  N=2
  Mg=0; Ng=0
  if(is.numeric(Args[[N]])){
    if(length(Args[[N]])>2){
      U=Args[[N]]
      Mg=length(U)-1
      N=N+1
    }else if(length(Args[[N]])==2){
      Intab=Args[[N]]
      Ag=Intab[1]; Bg=Intab[2]
      N=N+1
    }else{
      Ag=Args[N]; Bg=Args[N+1]
      N=N+2
   }
  }else{
    Tmp0=Args[[N]]
    Tmp=grep("=",Tmp0,fixed=TRUE)
    if(length(Tmp)>0){
      Tmp1=strsplit(Tmp0,"=")
      Tmp0=Tmp1[[1]][2]
    }
    Intab=eval(parse(text=Tmp0))
    Ag=Intab[1]; Bg=Intab[2]
    N=N+1
  }
  if(is.numeric(Args[[N]])){
    if(length(Args[[N]])>2){
      V=Args[[N]]
      Ng=length(V)-1
      N=N+1
    }else if(length(Args[[N]])==2){
      Intab=Args[[N]]
      Cg=Intab[1]; Dg=Intab[2]
      N=N+1
    }else{
      Cg=Args[[N]]; Dg=Args[[N+1]]
      N=N+2
    }
  }else{ # the case of is.character(Args[[N]])
    Tmp0=Args[[N]]
    Tmp=grep("=",Tmp0,fixed=TRUE)
    if(length(Tmp)>0){
      Tmp2=strsplit(Tmp0,"=")
      Tmp0=Tmp2[[1]][2]
    }
    Intab=eval(parse(text=Tmp0))
    Cg=Intab[1]; Dg=Intab[2]
    N=N+1
  }  
  if(Mg==0){
    Mg=Args[[N]]
    N=N+1
	U=c()
    for(J in Looprange(1,Mg+1)){
      U=c(U,Ag+(J-1)/Mg*(Bg-Ag))
    }
  }
  if(Ng==0){
    Ng=Args[[N]]
    V=c()
    for(K in Looprange(1,Ng+1)){
      V=c(V,Cg+(K-1)/Ng*(Dg-Cg))
    }
  }
  Objname()
  PL=list()
  for(J in Looprange(1,Mg+1)){
    for(K in Looprange(1,Ng+1)){
      P=Rf(U[J],V[K])
      Np=Writeobjpoint(P)
      PL=c(PL,list(c(P,Np)))
    }
  }
  Idx=1+(Ng+1)*(0:Mg)
  Pus=PL[Idx]
  Idx=(Ng+1)*(1:(Mg+1))
  Pue=PL[Idx]
  Idx=1:(Ng+1)
  Pvs=PL[Idx]
  Idx=((Ng+1)*Mg+1):((Ng+1)*(Mg+1))
  Pve=PL[Idx]
  Printobjstr("vt 0 0")
  Printobjstr("vt 1 0")
  Printobjstr("vt 1 1")
  Printobjstr("vt 0 1")
  for(J in Looprange(1,Mg)){
    for(K in Looprange(1,Ng)){
      P1=sprintf("%1d",Op(4,PL[[(Ng+1)*(J-1)+K]]))
      P2=sprintf("%1d",Op(4,PL[[(Ng+1)*J+K]]))
      P3=sprintf("%1d",Op(4,PL[[(Ng+1)*J+K+1]]))
      P4=sprintf("%1d",Op(4,PL[[(Ng+1)*(J-1)+K+1]]))
      N1=""; N2=""; N3=""; N4=""
      if(Sel=="+"){
        Str=paste("f ",P1,"/1/",N1," ",P2,"/2/",N2," ",sep="")
        Str=paste(Str,P3,"/3/",N3," ",P4,"/4/",N4,sep="")
      }else{
        Str=paste("f ",P1,"/1/",N1," ",P4,"/4/",N4," ",sep="")
        Str=paste(Str,P3,"/3/",N3," ",P2,"/2/",N2,sep="")
      }
      Printobjstr(Str)
    }
  }
  list(U,V,Pus,Pue,Pvs,Pve)
}

Objthicksurf<- function(...){
  Args=list(...)
  Nargs=length(Args)
  Sel=Args[[Nargs]]; Nargs=Nargs-1 #181128from
  Selsurf=substring(Sel,1,1)
  Selside=c("0","0","0","0")
  Tmp=strsplit(Sel,"w");Tmp=Tmp[[1]]
  if(length(Tmp)==2){
    Selside[[1]]=substr(Tmp[2],1,1)
  }
  Tmp=strsplit(Sel,"e");Tmp=Tmp[[1]]
  if(length(Tmp)==2){
    Selside[[2]]=substr(Tmp[2],1,1)
  }
  Tmp=strsplit(Sel,"s");Tmp=Tmp[[1]]
  if(length(Tmp)==2){
    Selside[[3]]=substr(Tmp[2],1,1)
  }
  Tmp=strsplit(Sel,"n");Tmp=Tmp[[1]]
  if(length(Tmp)==2){
    Selside[[4]]=substr(Tmp[2],1,1)
  } #181128to
  Nfth=Args[[Nargs-2]]
  Thick1=Args[[Nargs-1]]
  Thick2=Args[[Nargs]]
  Nargs=Nargs-3
  Rfth=Args[[1]]
  N=2
  Mg=0; Ng=0
  if(is.numeric(Args[[N]])){
    if(length(Args[[N]])>2){
      U=Args[[N]]
      Mg=length(U)-1
      N=N+1
    }else if(length(Args[[N]])==2){
      Intab=Args[[N]]
      Ag=Intab[1]; Bg=Intab[2]
      N=N+1
    }else{
      Ag=Args[[N]]; Bg=Args[[N+1]]
      N=N+2
    }
  }else{
    Tmp0=Args[[N]]
    Tmp=strsplit(Tmp0,"=",fixe=TRUE)
    if(length(Tmp)>0){
      Tmp0=Tmp[[1]][2]
    }
    Intab=eval(parse(text=Tmp0))
    Ag=Intab[1]; Bg=Intab[2]
    N=N+1
  }
  if(is.numeric(Args[[N]])){
    if(length(Args[[N]])>2){
      V=Args[[N]]
      Ng=length(V)-1
      N=N+1
    }else if(length(Args[[N]])==2){
      Intab=Args[[N]]
      Cg=Intab[1]; Dg=Intab[2]
      N=N+1
    }else{
      Cg=Args[[N]]; Dg=Args[[N+1]]
      N=N+2
    }
  }else{
    Tmp0=Args[[N]]
    Tmp=strsplit(Tmp0,"=",fixed=TRUE)
    if(length(Tmp)>0){
      Tmp0=Tmp[[1]][2]
    }
    Intab=eval(parse(text=Tmp0))
    Cg=Intab[1]; Dg=Intab[2]
    N=N+1
  }
  if(Mg==0){
    Mg=Args[[N]]
    N=N+1
	U=c()
    for(J in Looprange(1,Mg+1)){
      U=c(U,Ag+(J-1)/Mg*(Bg-Ag))
    }
  }
  if(Ng==0){
    Ng=Args[[N]]
    V=c()
    for(K in Looprange(1,Ng+1)){
      V=c(V,Cg+(K-1)/Ng*(Dg-Cg))
    }
  }
  Objname()
  Join=OBJJOIN
  OBJJOIN<<- 1
  F1=function(u,v){
    Rfth(u,v)+Thick1*Nfth(u,v)
  }
  F2=function(u,v){
    Rfth(u,v)+Thick2*Nfth(u,v)
  }
  Dt1=Objsurf(F1,U,V,Selsurf)
  if(Selsurf=="+"){
    Tmp="-"
  }else{
    Tmp="+"
  }
  Dt2=Objsurf(F2,U,V,Tmp);
  Out=list(Dt1,Dt2);
  if(Selside[[1]]!="0"){
    Dt=Objrecs(Op(3,Dt1),Op(3,Dt2),Selside[[1]])
    Out=c(Out,list(Dt))
  }
  if(Selside[[2]]!="0"){
    Dt=Objrecs(Op(4,Dt1),Op(4,Dt2),Selside[[2]])
    Out=c(Out,list(Dt))
  }
  if(Selside[[3]]!="0"){
    Dt=Objrecs(Op(5,Dt1),Op(5,Dt2),Selside[[3]])
    Out=c(Out,list(Dt))
  }
  if(Selside[[4]]!="0"){
    Dt=Objrecs(Op(6,Dt1),Op(6,Dt2),Selside[[4]])
    Out=c(Out,list(Dt))
  }
  OBJJOIN<<- Join
}

Objrecs<- function(...){
  Eps=10^(-6)
  Args=list(...)
  Nargs=length(Args)
  Tmp=Args[[1]]
  PtL=Flattenlist(Tmp)
  for(J in Looprange(1,length(PtL))){ #17.12.23from
    Tmp=PtL[[J]]
    if(!is.matrix(Tmp)){ 
      PtL[[J]]=matrix(Tmp,nrow=1)
    }
  }  #17.12.23until
  PL1=list()
  for(J in Looprange(1,length(PtL))){
    Tmp=PtL[[J]]
    for(K in Looprange(1,nrow(Tmp))){
      PL1=c(PL1,list(Tmp[K,]))
    }
  }
  Sel=Args[[Nargs]]; Nargs=Nargs-1
  Objname()
  for(J in Looprange(1,length(PL1))){
    P=PL1[[J]]
    if((length(P)<4) || (P[4]==0)){
      Np=Writeobjpoint(P)
      PL1[[J]]=c(P[1:3],Np)
    }
  }
  Tmp=Args[[2]]
  if((is.numeric(Tmp)) && (length(Tmp)==1)){
    Drv=Tmp
    Len=Norm(Drv)
    PL2=list()
    for(J in Looprange(1,length(PL1))){
      Tmp=PL1[[J]]
      P=Tmp[1:3]+Drv
      Np=Writeobjpoint(P)
      PL2=c(PL2,list(c(P[1:3],Np)))
      if(J<length(PL1)){
        Vec=PL1[[J+1]]-PL1[[J]]
        if(Norm(Vec)>Eps){
          Tmp1=Crossprod(Drv,Vec)
          Tmp2=Crossprod(Tmp1,Vec)
          Tmp3=Dotprod(Tmp2,Drv)
          if(Tmp3<-Eps){
            Tmp2=-Tmp2
          }
          Drv=Len/Norm(Tmp2)*Tmp2
        }
      }
    }
  }else{
    PtL=Flattenlist(Tmp)
    for(J in Looprange(1,length(PtL))){ #17.12.23from
      Tmp=PtL[[J]]
      if(!is.matrix(Tmp)){ 
        PtL[[J]]=matrix(Tmp,nrow=1)
      }
    }  #17.12.23until
    PL2=list()
    for(J in Looprange(1,length(PtL))){
      Tmp=PtL[[J]]
      for(K in Looprange(1,nrow(Tmp))){
          PL2=c(PL2,list(Tmp[K,]))
      }
    }
    for(J in Looprange(1,length(PL2))){
      P=PL2[[J]]
      if((length(P)<4) || (P[4]==0)){
         Np=Writeobjpoint(P)
         PL2[[J]]=c(P[1:3],Np)
      }
    }
  }
  Printobjstr("vt 0 0")
  Printobjstr("vt 1 0")
  Printobjstr("vt 1 1")
  Printobjstr("vt 0 1")
  for(J in Looprange(2,length(PL1))){
    P1=sprintf("%1d",Op(4,PL1[[J-1]]))
    P2=sprintf("%1d",Op(4,PL2[[J-1]]))
    P3=sprintf("%1d",Op(4,PL2[[J]]))
    P4=sprintf("%1d",Op(4,PL1[[J]]))
    N1=""; N2=""; N3=""; N4=""
	if(Sel=="+"){
      Str=paste("f ",P1,"/1/",N1," ",P2,"/2/",N2," ",sep="")
      Str=paste(Str,P3,"/3/",N3," ",P4,"/4/",N4,sep="")
    }else{
      Str=paste("f ",P1,"/1/",N1," ",P4,"/4/",N4," ",sep="")
      Str=paste(Str,P3,"/3/",N3," ",P2,"/2/",N2,sep="")
    }
    Printobjstr(Str)
  }
  list(PL1,PL2)
}

Objpolygon<- function(...){
  Eps=10^(-6)
  Args=list(...)
  Nargs=length(Args)
  Tmp=Args[[1]]
  PtL=Flattenlist(Tmp)
  for(J in Looprange(1,length(PtL))){ #17.12.23from
    Tmp=PtL[[J]]
    if(!is.matrix(Tmp)){ 
      PtL[[J]]=matrix(Tmp,nrow=1)
    }
  }  #17.12.23until
  PL=list()
  for(J in Looprange(1,length(PtL))){
    Tmp=PtL[[J]]
    for(K in Looprange(1,nrow(Tmp))){
       PL=c(PL,list(Tmp[K,]))
    }
  }
  Sel=Args[[Nargs]]; Nargs=Nargs-1
  Objname()
  for(J in Looprange(1,length(PL))){
    P=PL[[J]]
    if((length(P)<4) || (P(4)==0)){
       Np=Writeobjpoint(P)
       PL[[J]]=c(P[1:3],Np)
    }
  }
  if(Nargs==1){
    Tmp=PL[[1]]
    Cen=Tmp[1:3]
	Nc=Tmp[4]
  }else{
    Tmp=Args[[2]]
    if(length(Tmp)==1){
      Tmp1=PL[[Tmp]]
      Cen=Tmp1[1:3]
      Nc=Tmp[4]
    }else{
      Cen=Tmp
      Nc=Writeobjpoint(Cen)
    }
  }
  for(J in Looprange(1,length(PL))){
    if(J<length(PL)){
     Je=J+1
    }else{
      Je=1
    }
    Pt1=Cen
    PLj=PL[[J]]; PLje=PL[[Je]]
    Pt2=PLj[1:3]; Pt3=PLje[1:3]
    if(Norm(Crossprod(Pt2-Pt1,Pt3-Pt1))<Eps){
     next
    }
    P1=sprintf("%1d",Nc)
    P2=sprintf("%1d",PLj[4])
    P3=sprintf("%1d",PLje[4])
	if(Sel=="+"){
      Str=paste("f",P1,P2,P3,"",sep=" ")
    }else{
      Str=paste("f",P1,P3,P2,"",sep=" ")
    }
    Printobjstr(Str)
  }
  PL
}

Objpolyhedron<- function(Vertex,Face){
  OBJFIGNO<<- OBJFIGNO+1
  Ninit=NPOINT
  Objname()
  for(N in Looprange(1,length(Vertex))){
    P=Vertex[[N]]
    Np=Writeobjpoint(P)
    Vertex[[N]]=c(P[1:3],Np)
  }
  for(N in Looprange(1,length(Face))){
    F=Face[[N]]+Ninit
    Face[[N]]=F
    Str="f"
    for(J in Looprange(1,length(F))){
      P=sprintf("%1d",F[J])
      Str=paste(Str,P,sep=" ")
    }
    Printobjstr(Str)
  }
  list(Vertex,Face)
}

Objcurve<- function(...){
  Eps=10^(-6)
  Args=list(...)
  Nargs=length(Args)
  Tmp=Args[[1]]
  PtL=Flattenlist(Tmp)
  for(J in Looprange(1,length(PtL))){ #17.12.23from
    Tmp=PtL[[J]]
    if(!is.matrix(Tmp)){ 
      PtL[[J]]=matrix(Tmp,nrow=1)
    }
  }  #17.12.23until
  PL=list()
  for(J in Looprange(1,length(PtL))){
    Tmp=PtL[[J]]
    for(K in Looprange(1,nrow(Tmp))){
       PL=c(PL,list(Tmp[K,]))
    }
  }
  Closed=Norm(PL[[length(PL)]]-PL[[1]])<Eps
  Pstr="xy"
  Tmp=Args[[Nargs]]
  if(is.character(Tmp)){
    Pstr=Tmp
    Nargs=Nargs-1
  }
  Sz=0.1
  Np=4
  if(Nargs>=2){
    Sz=Args[[2]]
  }
  if(Nargs>=3){
    Np=Args[[3]]
  }
#  Assignadd("Sz",Sz) #180901
  if(Pstr=="xy"){
    Vz=c(0,0,1)
    Fs=Assign("c(Sz*cos(t),Sz*sin(t),0)","Sz",Sz) #180901
  }
  if(Pstr=="yz"){
    Vz=c(1,0,0)
    Fs=Assign("c(0,Sz*cos(t),Sz*sin(t))","Sz",Sz) #180901
  }
  if(Pstr=="zx"){
    Vz=c(0,1,0)
    Fs=Assign("c(Sz*sin(t),0,Sz*cos(t))","Sz",Sz) #180901
  }
  Gc0=Spacecurve(Fs,"t=c(0,2*pi)",paste("Num=",as.character(Np),sep=""))
  P=PL[[1]]; Q=PL[[2]]; R=PL[[length(PL)-1]]
  PQ1=Q-P
  if(!Closed){
    PQ2=PQ1
  }else{ 
    PQ2=P-R
  }
  Vp=PQ1/Norm(PQ1)+PQ2/Norm(PQ2)
  Vp1=Vp/Norm(Vp)
  Theta=acos(min(Dotprod(Vz,Vp1),1));
  Vj=Crossprod(Vz,Vp1)
  if(Norm(Vj)<Eps){
    Vj=Vz
  }
  Gc1=Rotate3data(Gc0,Vj,Theta)
  CL=list(Translate3data(Gc1,P))
  for(J in Looprange(2,length(PL)-1)){
    P=PL[[J]]; Q=PL[[J+1]]
    PQ2=Q-P
    if(Norm(PQ2)<Eps){
      next
    }
    Vp=PQ1/Norm(PQ1)+PQ2/Norm(PQ2)
    Vp2=Vp/Norm(Vp)
    Theta=acos(min(Dotprod(Vp1,Vp2),1))
    Vj=Crossprod(Vp1,Vp2)
    if(Norm(Vj)<Eps){
      Vj=Vp1
    }
    Gc2=Rotate3data(Gc1,Vj,Theta)
    CL=c(CL,list(Translate3data(Gc2,P)))
    PQ1=PQ2
    Vp1=Vp2
    Gc1=Gc2
  }
  if(!Closed){
    Vp2=(Q-P)/Norm(Q-P)
    Theta=acos(min(Dotprod(Vp1,Vp2),1))
    Vj=Crossprod(Vp1,Vp2)
    if(Norm(Vj)<Eps){
      Vj=Vp1
    }
    Gc3=Rotate3data(Gc1,Vj,Theta)
    CL=c(CL,list(Translate3data(Gc3,Q)))
  }
  Objname()
  Join=Objjoin();
  Objjoin(1)
  GL1=CL[[1]]
  for(J in Looprange(2,length(CL))){
    GL2=CL[[J]]
    Dt=Objrecs(GL1,GL2,"-")
    GL1=Dt[[2]]
    if(J==2){
      GL0=Dt[[1]]
    }
  }
  if(!Closed){
    Objpolygon(CL[[1]],"-")
    N=length(CL)
    Objpolygon(CL[[N]],"+")
  }else{
     Objrecs(GL1,GL0,"-")
  }
  Out=CL
  OBJJOIN<<- Join
}

Objsymb<- function(Symb,Thick,Face,Dir){
  for(J in Looprange(1,Length(Symb))){
    Objcurve(Op(J,Symb),Thick,Face,Dir)
  }
}

Symb3data<- function(Moji,Size,Kaiten,NV,Pos){
  if(is.character(Moji)){
    #Tmp=Symbdata(Moji)
    #    GY1=Tmp(2)
  }else{
      GY1=Moji
  }
  GY1=Scaledata(GY1,Size,Size)
  GY1=Rotatedata(GY1,Kaiten*pi/180)
  A=NV[1]; B=NV[2]; C=NV[3]
  if(A^2+B^2==0){
    E1=c(1,0,0)
    E2=c(0,1,0)
  }else{
    E1=c(B,-A,0)
    E2=c(-A*C,-B*C,A^2+B^2)
    Tmp=matrix(c(E1,E2,NV),3,3)
    D=det(Tmp)
    if(D<0){
      E1=-E1
    }
    E1=E1/Norm(E1)
    E2=E2/Norm(E2)
  }
  Em<- function(X,Y){
    c(E1[1]*X+E2[1]*Y,E1[2]*X+E2[2]*Y,E1[3]*X+E2[3]*Y)
  }
  GY1=Embed(GY1,Em)
  GY1=Translate3data(GY1,Pos)
  Flattenlist(GY1)
}

############## New Intersect 18.02.01 #############

Intersectline<- function(p1,v1,p2,v2){
  Eps0=10^(-5)
  tmp=Dotprod(v1,v2)
  tmp1=c(tmp,Norm(v1)^2)
  tmp2=c(-Norm(v2)^2,-tmp)
  tmp3=c(Dotprod(p2-p1,v2),Dotprod(p2-p1,v1))
  d=Crossprod(tmp1,tmp2)
  tmp=abs(Crossprod(v1,v2))
  if(tmp>Eps0){
    dt=Crossprod(tmp3,tmp2)
    ds=Crossprod(tmp1,tmp3)
    t=dt/d
    s=ds/d
    pt=p1+v1*t
    out=list(pt,t,s)
  }else{
    tmp1=Crossprod(p2-p1,v1)/Norm(v1)
    out=list(abs(tmp1))
  }
  return(out)
}

Intersectseg<- function(...){
  varargin=list(...)
  Nargs=length(varargin)
  Eps0=10^(-4)
  Eps1=0.01
  seg1=varargin[[1]]
  seg2=varargin[[2]]
  if(Nargs>2){Eps1=varargin[[3]]}
  p1=Op(1,seg1); q1=Op(2,seg1)
  p2=Op(1,seg2); q2=Op(2,seg2)
  if((Norm(q1-p1)<Eps0)||(Norm(q2-p2)<Eps0)){
    out=list(-1)
  }else{
    tmp=Intersectline(p1,q1-p1,p2,q2-p2)
    if(length(Op(1,tmp))>1){
      pt=Op(1,tmp); t=Op(2,tmp); s=Op(3,tmp)
      if((t*(t-1)<Eps0)&&(s*(s-1)<Eps0)){
        out=list(0,pt,t,s)
      }else{
        t=min(max(t,0),1)
        s=min(max(s,0),1)
        tmp3=c(Norm(p1-p2),Norm(p1-q2),Norm(q1-p2),Norm(q1-q2)) #180317
        tmp1=c(Op(2,q2-p2),-Op(1,q2-p2))
        tmp=Intersectline(p1,tmp1,p2,q2-p2)
        if(length(Op(1,tmp))>1){
          if(Op(3,tmp)*(Op(3,tmp)-1)<Eps0){
            tmp3=c(tmp3,Norm(Op(1,tmp)-p1))
          }
        }
        tmp=Intersectline(q1,tmp1,p2,q2-p2)
        if(length(Op(1,tmp))>1){
          if(Op(3,tmp)*(Op(3,tmp)-1)<Eps0){
            tmp3=c(tmp3,Norm(Op(1,tmp)-q1))
          }
        }
        tmp1=c(Op(2,q1-p1),-Op(1,q1-p1))
        tmp=Intersectline(p2,tmp1,p1,q1-p1);
        if(length(Op(1,tmp))>1){
          if(Op(3,tmp)*(Op(3,tmp)-1)<Eps0){
            tmp3=c(tmp3,Norm(Op(1,tmp)-p2))
          }
        }
        tmp=Intersectline(q2,tmp1,p1,q1-p1); #180322
        if(length(Op(1,tmp))>1){
          if(Op(3,tmp)*(Op(3,tmp)-1)<Eps0){
            tmp3=c(tmp3,Norm(Op(1,tmp)-q2))
          }
        }
        out=list(min(tmp3),pt,t,s)
      }
    }else{
      dist=tmp[[1]]
      tmp1=q1-p1
      n=c(tmp1[2],-tmp1[1])/Norm(tmp1)
      pts=list()
      tmp=Intersectline(p1,n,p2,q2-p2)
      if((length(tmp)>1)&&(tmp[[3]]*(tmp[[3]]-1)<Eps0)){
        tmp1=(1-tmp[[3]])*p2+tmp[[3]]*q2
        pts=c(pts,list(list(tmp1,0,tmp[[3]])))
      }
      tmp=Intersectline(q1,n,p2,q2-p2)
      if((length(tmp)>1)&&(tmp[[3]]*(tmp[[3]]-1)<Eps0)){
        tmp1=(1-tmp[[3]])*p2+tmp[[3]]*q2
        pts=c(pts,list(list(tmp1,1,tmp[[3]])))
      }
      tmp=Intersectline(p2,n,p1,q1-p1)
      if((length(tmp)>1)&&(tmp[[3]]*(tmp[[3]]-1)<Eps0)){
        tmp1=(1-tmp[[3]])*p1+tmp[[3]]*q1
        pts=c(pts,list(list(tmp1,tmp[[3]],0)))
      }
      if((length(tmp)>1)&&(tmp[[3]]*(tmp[[3]]-1)<Eps0)){
        tmp1=(1-tmp[[3]])*p1+tmp[[3]]*q1
        pts=c(pts,list(list(tmp1,tmp[[3]],2)))
      }
      if(length(pts)==0){
        tmp1=min(Norm(p2-p1),Norm(q2-p1),Norm(p2-q1),Norm(q2-q1))
        out=list(tmp1)
      }else{
        if(dist>Eps1){
          out=list(dist)
        }else{
          tmp=c();
          for(j in 1:length(pts)){
            tmp=Appendrow(tmp,Op(1,pts[[j]]))
          }
          tmp1=sum(tmp[,1])/(length(pts))
          tmp2=sum(tmp[,2])/(length(pts))
          tmp3=c(tmp1,tmp2)
          tmp=Nearestpt(tmp3,seg1)
          tmp1=tmp[[2]]
          tmp=Nearestpt(tmp3,seg2)
          tmp2=tmp[[2]]
          out=list(dist,tmp3,tmp1,tmp2)
        }
      }
    }
  }
  return(out)
}

Osplineseg<- function(...){
  varargin=list(...)
  Nargs=length(varargin)
  Eps=10^(-2)
  Eps0=10^(-6)
  Ptlist=varargin[[1]]
  Numstr="Num=20"
  if(Nargs>1){
    Numstr=varargin[[2]]
  }
  p0=Op(1,Ptlist); p1=Op(2,Ptlist); p2=Op(3,Ptlist); p3=Op(4,Ptlist)
  tmp=Norm(p2-p0)*Norm(p3-p1)
  tmp=1+sqrt((1+Dotprod(p2-p0,p3-p1)/tmp)/2)
  cc=4*Norm(p2-p1)/3/(Norm(p2-p0)+Norm(p3-p1))/tmp
  pQ=p1+cc*(p2-p0)
  pR=p2+cc*(p1-p3)
  ctrL=list(c(pQ,pR))
  out=Bezier(list(p1,p2),ctrL,Numstr)
  return(out)
}

Intersectpartseg<- function(...){
  varargin=list(...)
  Nargs=length(varargin)
  crv1=varargin[[1]]
  crv2=varargin[[2]]
  ii=varargin[[3]]
  jj=varargin[[4]]
  Eps1=varargin[[5]]
  Eps2=varargin[[6]]
  Dist=10*Eps2
  if(Nargs>6){Dist=varargin[[7]]}
  Eps00=10^(-8)
  Eps0=10^(-4)
  out=list()
  seg1=Listplot(Op(ii,crv1),Op(ii+1,crv1))
  seg2=Listplot(Op(jj,crv2),Op(jj+1,crv2))
  tmp1=Op(2,seg1)-Op(1,seg1)
  tmp2=Op(2,seg2)-Op(1,seg2)
  snang=abs(Crossprod(tmp1,tmp2))/(Norm(tmp1)*Norm(tmp2))
  tmp=Intersectseg(seg1,seg2,Eps1)
  dst=Op(1,tmp)
  if(dst<Eps0){
    out=list(Op(2,tmp),ii+Op(3,tmp),jj+Op(4,tmp),dst,snang)
  }else{
    if(dst<Eps2){
      if((Length(crv1)==2)||(Norm(Op(2,seg1)-Op(1,seg1))>Dist-Eps0)){
        os1=seg1
      }else{
        p1=Op(1,seg1); p2=Op(2,seg1)
        if(ii==1){
          p3=Op(3,crv1)
          tmp=p2-p1
          tmp=(p1+p2)/2+c(Op(2,tmp),-Op(1,tmp))
          p0=Reflectdata(p3,c((p1+p2)/2,tmp))
        }else{
          if(ii==Length(crv1)-1){
            p0=Op(ii-1,crv1)
            tmp=p2-p1
            tmp=(p1+p2)/2+c(Op(2,tmp),-Op(1,tmp))
            p3=Reflectdata(p0,c((p1+p2)/2,tmp))
          }else{
            p0=Op(ii-1,crv1); p3=Op(ii+2,crv1)
          }
        }
        os1=Osplineseg(list(p0,p1,p2,p3))
      }
	  if((Length(crv2)==2)||(Norm(Op(2,seg2)-Op(1,seg2))>Dist-Eps0)){
        os2=seg2
      }else{
        p1=Op(1,seg2); p2=Op(2,seg2)
        if(jj==1){
          p3=Op(3,crv2)
          tmp=p2-p1
          tmp=(p1+p2)/2+c(Op(2,tmp),-Op(1,tmp))
          p0=Reflectdata(p3,c((p1+p2)/2,tmp))
        }else{
          if(jj==Length(crv2)-1){
            p0=Op(jj-1,crv2)
            tmp=p2-p1
            tmp=(p1+p2)/2+c(Op(2,tmp),-Op(1,tmp))
            p3=Reflectdata(p0,c((p1+p2)/2,tmp))
          }else{
            p0=Op(jj-1,crv2); p3=Op(jj+2,crv2)
          }
        }
        os2=Osplineseg(list(p0,p1,p2,p3))
      }
	  tmp2=list()
      for(kk in Looprange(1,Length(os1)-1)){
        for(ll in Looprange(1,Length(os2)-1)){
          seg1=Listplot(Op(kk,os1),Op(kk+1,os1))
          seg2=Listplot(Op(ll,os2),Op(ll+1,os2))
          tmp=Intersectseg(seg1,seg2,Eps1)
          if((Op(1,tmp)<Eps1)&&(length(tmp)>1)){ #18.02.05
            if(Op(1,tmp)<dst+Eps00){
              dst=Op(1,tmp)
              tmp3=list()
              for( nn in Looprange(1,length(tmp2))){
                if(Op(1,tmp2[[nn]])<dst){
                  tmp3=c(tmp3,list(tmp2[[nn]]))
                }
              }
              tmp2=c(tmp3,list(list(dst,Op(2,tmp))))
            }
          }
        }
      }
      if(length(tmp2)>0){
        tmp1=c()
        for(nn in Looprange(1,length(tmp2))){
          tmp1=Appendrow(tmp1,Op(2,tmp2[[nn]]))
        }
        tmp=sum(tmp1[,1])/length(tmp2)
        tmp=c(tmp,sum(tmp1[,2])/length(tmp2))
        out=list(tmp)
        p1=Op(ii,crv1); p2=Op(ii+1,crv1)
        tmp=c(Op(2,p2-p1),-Op(1,p2-p1))
        tmp=Intersectline(Op(1,out),tmp,p1,p2-p1)
        tmp=min(max(Op(3,tmp),0),1)
        out=c(out,list(ii+tmp))
        p1=Op(jj,crv2); p2=Op(jj+1,crv2)
        tmp=c(Op(2,p2-p1),-Op(1,p2-p1))
        tmp=Intersectline(Op(1,out),tmp,p1,p2-p1)
        tmp=min(max(Op(3,tmp),0),1)
        out=c(out,list(jj+tmp,dst,snang))
      }
    }
  }
  return(out)
}

if(1==0){ #start of skip

Collectnear<- function(ptdL,Eps2){
  gL=list(Op(1,ptdL))
  rL=ptdL[Looprange(2,length(ptdL))] #18.02.07
  for( ii in Looprange(1,length(ptdL)-1)){
    numL=c()
    for(jj in Looprange(1,length(rL))){
      tmp1=100
      for(kk in Looprange(1,length(gL))){
        tmp=Norm(Op(1,gL[[kk]])-Op(1,rL[[jj]]))
        if(tmp<tmp1){tmp1=tmp}
      }
      if(tmp1<Eps2){numL=c(numL,jj)}
    }
    if(length(numL)==0){
      break
    }else{
      gL=c(gL,rL[numL]) #18.02.05
      tmp=setdiff(1:(length(rL)),numL)
      rL=rL[tmp]
    }
  }
  return(list(gL,rL))
}

}# end of skip

Collectsameseg<- function(ptdL){
  Eps00=10^(-8)
  if(length(ptdL)==0){
    gL=list();rL=list()
  }else{
    tmp1md=ptdL[1]
    rL=ptdL[Looprange(2,length(ptdL))]
    tmp1=tmp1md[[1]]
    kk=floor(Op(2,tmp1))
    if(Op(2,tmp1)<kk+Eps00){
      s1=kk-1-Eps00; e1=s1+2+2*Eps00
    }else{
      s1=kk-Eps00; e1=s1+1+2*Eps00
    }
    kk=floor(Op(3,tmp1))
    if(Op(3,tmp1)<kk+Eps00){
      s2=kk-1-Eps00; e2=s2+2+2*Eps00
    }else{
      s2=kk-Eps00; e2=s2+1+2*Eps00
    }
    diffL=c()
    for(ii in Looprange(1,length(rL))){
      tmp=rL[[ii]]
      tmp1=Op(2,tmp);tmp2=Op(3,tmp)
      if((tmp1>s1)&&(tmp1<e1)&&(tmp2>s2)&&(tmp2<e2)){
        tmp1md=c(tmp1md,list(tmp))
      }else{
        diffL=c(diffL,ii)
      }
    }
    tmp=c()
    for(ii in Looprange(1,length(tmp1md))){
      tmp=c(tmp,Op(4,tmp1md[[ii]]))
    }
	dst=min(tmp)
    gL=list()
    for(ii in Looprange(1,length(tmp1md))){
      tmp=tmp1md[[ii]]
      if(Op(4,tmp)<dst+Eps00){
        gL=c(gL,list(tmp))
      }
    }
    tmp1=rL
    rL=rL[diffL]
  }
  return(list(gL,rL))
}

Groupnearpt<- function(...){
  varargin=list(...)
  Nargs=length(varargin)
  Eps1=varargin[[Nargs]]
  plist=varargin[[1]]
  qlist=varargin[[2]]
  if(!is.list(qlist)){
    qlist=plist
    plist=list()
  }
  if(length(qlist)==0){
    return(plist)
  }
  pt=qlist[[1]]
  qlist=qlist[Looprange(2,length(qlist))]
  if(length(plist)==0){
    plist=list(matrix(pt,nrow=1))
  }else{
    flg=0
    for(ii in Looprange(1,length(plist))){
      gL=plist[[ii]]
      for(jj in Looprange(1,Length(gL))){
        if(Norm(Op(jj,gL)-pt)<Eps1){
          flg=1
          break
        }
      }
      if(flg==1){
        plist[[ii]]=Appendrow(gL,pt)
        break
      }
    }
    if(flg==0){
      plist=c(plist,list(matrix(pt,nrow=1)))
    }
  }
  out=Groupnearpt(plist,qlist,Eps1)
  return(out)
}

IntersectcurvesPp<- function(...){
  varargin=list(...)
  Nargs=length(varargin)
  Eps0=10^(-4)
  Eps1=0.01
#  Eps2=0.05
  Eps2=0.1
  Dist=10*Eps2
  if(Nargs>2){Eps1=varargin[[3]]}
  if(Nargs>3){Eps2=varargin[[4]]}
  if(Nargs>4){Dist=varargin[[5]]}  
  tmp1=varargin[[1]]
  crv1=matrix(Op(1,tmp1),nrow=1)
  for(ii in Looprange(2,Length(tmp1))){
    tmp=Op(Length(crv1),crv1)
    if(Norm(tmp-Op(ii,tmp1))>Eps0){
      crv1=Appendrow(crv1,Op(ii,tmp1))
    }
  }
  tmp2=varargin[[2]]
  crv2=matrix(Op(1,tmp2),nrow=1)
  for(ii in Looprange(2,Length(tmp2))){
    tmp=Op(Length(crv2),crv2)
    if(Norm(tmp-Op(ii,tmp2))>Eps0){
      crv2=Appendrow(crv2,Op(ii,tmp2))
    }
  }
  if(Length(crv1)!=Length(crv2)){
    self=0
  }else{
    self=1
    for(ii in Looprange(1,Length(crv1))){
      if(Norm(Op(ii,crv1)-Op(ii,crv2))>0){
        self=0
        break
      }
    }
  }
  out=list()
  for(ii in Looprange(1,Length(crv1)-1)){
    if(self==0){
      loopL=Looprange(1,Length(crv2)-1)
    }else{
      loopL=Looprange(ii+2,Length(crv2)-1)
    }
    for(jj in loopL){
      tmp=Intersectpartseg(crv1,crv2,ii,jj,Eps1,Eps2,Dist)
      if(length(tmp)>1){ #18.02.05
        if(length(out)==0){
          out=list(tmp)
        }else{
          tmp1=Op(length(out),out)
          if(Norm(Op(1,tmp1)-Op(1,tmp))>Eps1){
            out=c(out,list(tmp))
          }
        }
        if(self==1){
          tmp=list(Op(1,tmp),Op(3,tmp),Op(2,tmp),Op(4,tmp),Op(5,tmp))
          out=c(out,list(tmp))
        }
      }
    }
  }
  tmp2=out
  out=list()
  tmp1=tmp2
  for(ii in Looprange(1,length(tmp2))){
    tmp=Collectsameseg(tmp1)
    out=c(out,list(Op(1,tmp)))
    if(length(Op(2,tmp))==0){
      break
    }else{
      tmp1=Op(2,tmp)
    }
  }
  for(ii in Looprange(1,length(out))){
    tmp1=Op(ii,out)
    if(length(tmp1)==1){
      out[[ii]]=Op(1,tmp1)
    }else{
      tmp=c()
      for(jj in Looprange(1,length(tmp1))){
        tmp=c(tmp,Op(4,tmp1[[jj]]))
      }
      dst=min(tmp)
      tmp=c()
      for(jj in Looprange(1,length(tmp1))){
        if(Op(4,tmp1[[jj]])<dst+Eps0){
          tmp=c(tmp,Op(1,tmp1[[jj]]))
        }
      }
      tmp=matrix(tmp,ncol=2,byrow=TRUE)
      tmp=c(sum(tmp[,1]),sum(tmp[,2]))/Length(tmp)
      tmp2=list(tmp)
      tmp=Nearestpt(Op(1,tmp2),crv1)
      tmp2=c(tmp2,list(Op(2,tmp)))
      tmp=Nearestpt(Op(1,tmp2),crv2)
      tmp2=c(tmp2,list(Op(2,tmp)))
      tmp2=c(tmp2,list(list(dst,Op(5,tmp1[[1]]))))
      out[[ii]]=tmp2
    }
  }
  return(out)
}

Intersectcurves<- function(...){
  dtL=IntersectcurvesPp(...)
  out=list()
  for(jj in Looprange(1,length(dtL))){
    out=c(out,list(Op(1,dtL[[jj]])))
  }
  return(out)
}

############## end of New Intersect  #############

############## New Enclosing2 #############

Enclosing2<- function(...){
  varargin=list(...)
  Nargs=length(varargin)
  plist=varargin[[1]]
  Eps0=10^(-5)
  epspara=1; #180707
  Eps1=0.01
  Eps2=0.1
  Start=c()
  flg=0
  for(ii in Looprange(2,Nargs)){
    tmp=varargin[[ii]]
    if(length(tmp)>1){
      Start=tmp
    }else{
     if(flg==0){epspara=tmp}
     if(flg==1){Eps1=tmp}
     if(flg==2){Eps2=tmp}
     flg=flg+1
    }
  }
  flg=0
  AnsL=c()
  if(length(plist)==1){
    Fdata=plist[[1]]
    tmp1=Op(1,Fdata)
    tmp2=Op(Length(Fdata),Fdata)
    if(Norm(tmp1-tmp2)<Eps0){
      AnsL=Fdata
    }else{
      AnsL=Appendrow(Fdata,tmp1)
    }
    flg=1
  }
  if(flg==0){
    Fdata=Op(1,plist)
    Gdata=Op(length(plist),plist)
    KL=IntersectcurvesPp(Fdata,Gdata)
    if(length(KL)==0){
      tmp1=Op(Length(Gdata),Gdata)
      tmp2=Op(1,Fdata)
      tmp=Listplot(tmp1,tmp2)
      plist=c(plist,list(tmp))
      Start=tmp2
      tst=1
    }else{
      if(length(KL)==1){
        tmp=Op(1,KL)
        tst=Op(2,tmp)
        Start=Op(1,tmp) #180706
      }
      if(length(KL)>1){
        KL=Quicksort(KL,2) #180706from
        if(length(Start)==0){
          tmp=Op(1,KL)
          tst=Op(2,tmp)
          Start=Op(1,tmp)
        }else{
          tmp=c()
          tmp1=list()
          for(ii in Looprange(1,length(KL))){
            tmp2=Op(1,KL[[ii]])
            flgsame=0 #180717from
            for(jj in Looprange(1,length(tmp1))){
              if(Norm(tmp2-Op(jj,tmp1))<Eps1){
                flgsame=1
                break
              }
            }
            if(flgsame==0){
              tmp=c(tmp,Norm(Op(1,KL[[ii]])-Start))
              tmp1=c(tmp1,list(tmp2))
            } #180717to
          }
          tmp=order(tmp)
          tmp=Op(tmp[1],KL)
          tst=Op(2,tmp)
          Start=Op(1,tmp)#180706to
        }
      }
    }
  }
  if(flg==0){
    t1=tst
    p1=Pointoncurve(t1,Fdata)#180713
    for(nn in Looprange(1,length(plist))){
      Fdata=Op(nn,plist)
      if(nn==length(plist)){
        nxtno=1
      }else{
        nxtno=nn+1
      }
      Gdata=Op(nxtno,plist)
      KL=IntersectcurvesPp(Fdata,Gdata)
      if(length(KL)==0){
        tmp=matrix(Op(Length(Fdata),Fdata),nrow=1) #18.02.02from
        Gdata=Appendrow(tmp,Gdata)
        plist[[nxtno]]=Gdata
        t2=Length(Fdata)
        ss=1 #18.02.02to
      }else{
#        KL=Quicksort(KL,2); #180706from
#        for(j in Looprange(1,length(KL))){
#          tmp1=t1+epspara/50*Length(Fdata)#180713(2lines)
#          tmp2=Op(2,KL[[j]])
#          if((tmp2>tmp1)||((tmp2>t1)&&(Norm(Op(3,KL[[j]])-p1)>Eps1))){
#            break
#          } #180711,16
#        }
#        t2=Op(2,KL[[j]])
#        p2=Pointoncurve(t2,Fdata)#180713
#        ss=Op(3,KL[[j]])# 180706to
		tmp=c()  #180711from
        for(j in Looprange(1,length(KL))){
          tmp=c(tmp,Op(2,KL[[j]]))
        }
        tmp1=order(tmp)
        tmp2=KL
        KL=list()
        for(j in tmp1){
          tmp=tmp2[[j]]
          tmp3=t1+epspara/50*Length(Fdata)
          tmp4=Op(2,tmp)
          if((tmp4>tmp3)||((tmp4>t1)&&(Norm(Op(1,tmp)-p1)>Eps1))){
            KL=c(KL,list(tmp))
          }
        }
        t2=Op(2,KL[[1]])
        ss=Op(3,KL[[1]])  #180711from
        if(abs(t2-t1)<Eps0){
          if(length(KL)>1){
            tmp=Op(2,KL)
            t2=Op(2,tmp)
            ss=Op(3,tmp)
          }else{
          }
        }
      }
      if(flg==0){
        tmp=Partcrv(t1,t2,Fdata)
        if(nn==1){
          AnsL=tmp
        }else{
          tmp=tmp[2:Length(tmp),]
          AnsL=Appendrow(AnsL,tmp)
        }
      }
      t1=ss
      p1=Pointoncurve(t1,Gdata)#180713
    }
  }
  return(AnsL)
}

############## end of Enclosing2 #############

############## start of surface drawing #############

Fullformfunc<- function(FdL){
  ADDPOINT<<- list() #18.02.19
  Out=list(Op(1,FdL))
  N=length(FdL)
  for(Jrg in Looprange(1,N)){
    Tmp=grep("c(",Op(Jrg,FdL),fixed=TRUE)
    if(length(Tmp)>0){
      break
    }
  }
  Urg=Stripblanks(Op(Jrg,FdL))
  Tmp=strsplit(Urg,"=",fixed=TRUE)
  UNAME<<- Tmp[[1]][1]
  URNG<<- eval(parse(text=Tmp[[1]][2]))
  Urg=paste(UNAME,"=c(",sprintf("%6.7f",URNG[1]),",",
               sprintf("%6.7f",URNG[2]),")",sep="")
  Vrg=Stripblanks(Op(Jrg+1,FdL))
  Tmp=strsplit(Vrg,"=",fixed=TRUE)
  VNAME<<- Tmp[[1]][1]
  VRNG<<- eval(parse(text=Tmp[[1]][2]))
  Vrg=paste(VNAME,"=c(",sprintf("%6.7f",VRNG[1]),",",
               sprintf("%6.7f",VRNG[2]),")",sep="")
  if(Jrg==2){
    Xf=UNAME
    Yf=VNAME
    Tmp=Stripblanks(Op(1,FdL))
    Tmp=strsplit(Tmp,"=",fixed=TRUE)
    Zf=Tmp[[1]][2]
    Tmp=list(UNAME,VNAME,Zf,Urg,Vrg)
    Out=c(Out,Tmp)
  }else if(Jrg==4){
    Tmp=Stripblanks(Op(1,FdL))
    Tmp=strsplit(Tmp,"=",fixed=TRUE)
    Zf=Tmp[[1]][2]
    Tmp=Stripblanks(Op(2,FdL))
    Tmp=strsplit(Tmp,"=",fixed=TRUE)
    Xname=Tmp[[1]][1]
    Xf=Tmp[[1]][2]
    Tmp=Stripblanks(Op(3,FdL))
    Tmp=strsplit(Tmp,"=",fixed=TRUE)
    Yname=Tmp[[1]][1]
    Yf=Tmp[[1]][2]
    Tmp=gsub(Xname,paste("(",Xf,")",sep=""),Zf,fixed=TRUE)
    Zf=gsub(Yname,paste("(",Yf,")",sep=""),Tmp,fixed=TRUE)
    Tmp=list(Xf,Yf,Zf,Urg,Vrg)
    Out=c(Out,Tmp)
  }else{
    Tmp=Stripblanks(Op(2,FdL))
    Tmp=strsplit(Tmp,"=",fixed=TRUE)
    Xf=Tmp[[1]][2]
    Tmp=Stripblanks(Op(3,FdL))
    Tmp=strsplit(Tmp,"=",fixed=TRUE)
    Yf=Tmp[[1]][2]
    Tmp=Stripblanks(Op(4,FdL))
    Tmp=strsplit(Tmp,"=",fixed=TRUE)
    Zf=Tmp[[1]][2]
    Tmp=list(Xf,Yf,Zf,Urg,Vrg)
    Out=c(Out,Tmp)
  }
  tmp=paste("Xfunc<<- function(",UNAME,",",VNAME,"){",Xf,"}",sep='')
  eval(parse(text=tmp))
  tmp=paste("Yfunc<<- function(",UNAME,",",VNAME,"){",Yf,"}",sep='')
  eval(parse(text=tmp))
  tmp=paste("Zfunc<<- function(",UNAME,",",VNAME,"){",Zf,"}",sep='')
  eval(parse(text=tmp)) 
  tmp=paste("XYZfunc<<- function(",UNAME,",",VNAME,"){",sep='')
  tmp=paste(tmp,"c(",Xf,",",Yf,",",Zf,")}",sep='')
  eval(parse(text=tmp)) 
  XYZstr<<- c(Xf,Yf,Zf)
  DRWS<<- "enws"
  BdyL=list()
  for(I in Looprange(Jrg+2,length(FdL))){
    Tmp=Op(I,FdL)
    if(is.character(Tmp)){
      if(nchar(Tmp)==0){
        Tmp=" "
      }
      DRWS<<- list(Tmp)
    }
    if((is.numeric(Tmp))&&(Length(Tmp)>1)){
      BdyL=list(Tmp)
    }
  }
  BDYL<<- BdyL
  Tmp=c(DRWS,BDYL)
  Out=c(Out,Tmp)
  return(Out)
}

Addpoints<- function(ptlist){
  ADDPOINT<<- ptlist
}

Makexybdy<- function(Np){
  Eps0=10^(-4)
  Xystr=XYZstr[1:2]
  Umin=URNG[1]; Umax=URNG[2]
  Vmin=VRNG[1]; Vmax=VRNG[2]
  Cflg=0
  EhL=list()
  Tmp=grep("e",DRWS,fixed=TRUE)
  if(length(Tmp)>0){
    Tmp1="c("
    for(jj in 1:2){
      Tmp=gsub(UNAME,paste("(",sprintf("%7.7f",Umax),")",sep=""),Xystr[jj])
      Tmp1=paste(Tmp1,Tmp,",",sep="")
    }
    Tmp=substring(Tmp1,1,Length(Tmp1)-1)
    Tmp1=paste(Tmp,")",sep="")
    Tmp=sprintf("%6.6f",VRNG)
    Tmp2=paste(VNAME,"=c(",Tmp[1],",",Tmp[2],")",sep='')
    Tmp3=paste('N=',as.character(Np[2]))
    Tmp=Paramplot(Tmp1,Tmp2,Tmp3)
    if(Norm(Op(1,Tmp)-Op(Length(Tmp),Tmp))<Eps0){
      Cflg=1
      Tmp[Length(Tmp),]=Tmp[1,]
    }
    EhL=c(EhL,list(Tmp))
  }
  Tmp=grep("n",DRWS,fixed=TRUE)
  if(length(Tmp)>0){
    Tmp1="c("
    for(jj in 1:2){
      Tmp=gsub(VNAME,paste("(",sprintf("%7.7f",Vmax),")",sep=""),Xystr[jj])
      Tmp1=paste(Tmp1,Tmp,",",sep="")
    }
    Tmp=substring(Tmp1,1,Length(Tmp1)-1)
    Tmp1=paste(Tmp,")",sep="")
    Tmp=sprintf("%6.6f",URNG)
    Tmp2=paste(UNAME,"=c(",Tmp[1],",",Tmp[2],")",sep='')
    Tmp3=paste('N=',as.character(Np[1]))
    Tmp=Paramplot(Tmp1,Tmp2,Tmp3)
    if(Cflg>0){ 
      Tmp1=Op(length(EhL),EhL)
      Tmp=Joincrvs(Tmp1,Tmp)
      if(Norm(Op(1,Tmp)-Op(Length(Tmp),Tmp))<Eps0){
        Cflg=1
        Tmp[Length(Tmp),]=Tmp[1,]
      }
      Tmp1=EhL[Looprange(1,length(EhL)-1)]
      EhL=c(Tmp1,Tmp)
    }else{
      Cflg=0
      if(Norm(Op(1,Tmp)-Op(Length(Tmp),Tmp))<Eps0){
        Cflg=1
        Tmp[Length(Tmp),]=Tmp[1,]
      }
      EhL=c(EhL,list(Tmp))
    }
  }
  Tmp=grep("w",DRWS,fixed=TRUE)
  if(length(Tmp)>0){
    Tmp1="c("
    for(jj in 1:2){
      Tmp=gsub(UNAME,paste("(",sprintf("%7.7f",Umin),")",sep=""),Xystr[jj])
      Tmp1=paste(Tmp1,Tmp,",",sep="")
    }
    Tmp=substring(Tmp1,1,Length(Tmp1)-1)
    Tmp1=paste(Tmp,")",sep="")
    Tmp=sprintf("%6.6f",VRNG)
    Tmp2=paste(VNAME,"=c(",Tmp[1],",",Tmp[2],")",sep='')
    Tmp3=paste('N=',as.character(Np[2]))
    Tmp=Paramplot(Tmp1,Tmp2,Tmp3)
    if(Cflg>0){
      Tmp1=Op(length(EhL),EhL)
	  Tmp=Joincrvs(Tmp1,Tmp)
      if(Norm(Op(1,Tmp)-Op(Length(Tmp),Tmp))<Eps0){
        Cflg=1
        Tmp[Length(Tmp),]=Tmp[1,]
      }
      Tmp1=EhL[Looprange(1,length(EhL)-1)]
      EhL=c(Tmp1,list(Tmp))
    }else{
      Cflg=0
      if(Norm(Op(1,Tmp)-Op(Length(Tmp),Tmp))<Eps0){
        Cflg=1
        Tmp[Length(Tmp),]=Tmp[1,]
      }
      EhL=c(EhL,list(Tmp))
    }
  }
  Tmp=grep("s",DRWS,fixed=TRUE)
  if(length(Tmp)>0){
    Tmp1="c("
    for(jj in 1:2){
      Tmp=gsub(VNAME,paste("(",sprintf("%7.7f",Vmin),")",sep=""),Xystr[jj])
      Tmp1=paste(Tmp1,Tmp,",",sep="")
    }
    Tmp=substring(Tmp1,1,Length(Tmp1)-1)
    Tmp1=paste(Tmp,")",sep="")
    Tmp=sprintf("%6.6f",URNG)
    Tmp2=paste(UNAME,"=c(",Tmp[1],",",Tmp[2],")",sep='')
    Tmp3=paste('N=',as.character(Np[1]))
    Tmp=Paramplot(Tmp1,Tmp2,Tmp3)
    if(Cflg>0){
      Tmp1=Op(length(EhL),EhL)
      Tmp=Joincrvs(Tmp1,Tmp)
      if(Norm(Op(1,Tmp)-Op(Length(Tmp),Tmp))<Eps0){
        Cflg=1
        Tmp1=EhL[Looprange(1,length(EhL)-1)]
      }
      Tmp1=EhL[Looprange(1,length(EhL)-1)]
      EhL=c(Tmp1,list(Tmp))
    }else{
      Cflg=0
      if(Norm(Op(1,Tmp)-Op(Length(Tmp),Tmp))<Eps0){
        Cflg=1
        Tmp[Length(Tmp),]=Tmp[1,]
      }
      EhL=c(EhL,list(Tmp))
    }
  }
  return(EhL)
}

Partitionseg<- function(...){
  varargin=list(...)
  Nargs=length(varargin)
  Fig=varargin[[1]]
  GL=varargin[[2]]; N=3
  if(!is.list(GL)){GL=list(GL)} #18.02.21
  Eps0=10^(-4)
  Eps1=0.01
  if(Nargs>2){
    Eps1=varargin[[3]]
  }
  Eps2=0.1
  if(Nargs>3){
    Eps2=varargin[[4]]
  }
  if(Nargs>4){
    Ns=varargin[[5]]
    if(Ns>0){#18.02.21from
      Other=Op(Ns,OTHERPARTITION)
    }else{
      Other=c()
    }#18.02.21until
  }else{
    Ns=1
    Other=c()
  }
  Npt=Length(Fig)
  ParL=c(1,Npt,Other)
  for(N in Looprange(max(1,Ns),Length(GL))){ #18.02.21
	G=Op(N,GL)
    KouL=IntersectcurvesPp(Fig,G,Eps1,Eps2)
    Tmp1=c(); Tmp2=c()
    for(jj in Looprange(1,length(KouL))){
      tmp=Op(2,KouL[[jj]])
      if((tmp>1+Eps0)&&(tmp<Npt-Eps0)){
        Tmp1=c(Tmp1,tmp)
      }
      tmp=Op(3,KouL[[jj]])
      if((tmp>1+Eps0)&&(tmp<Length(G)-Eps0)){
        Tmp2=c(Tmp2,tmp)
      }
    }
    ParL=c(ParL,Tmp1)
    if((Ns>0)&&(N>Ns)&&(length(Tmp2)>0)){ #18.02.21
      tmp=OTHERPARTITION[[N]]
      OTHERPARTITION[[N]]<<- c(tmp,Tmp2)
    }
  }
  tmp1=sort(ParL)
  ParL=c()
  tmp2=-1
  for(jj in Looprange(1,length(tmp1))){
    tmp=Op(jj,tmp1)
    if(abs(tmp-tmp2)>Eps1){
      ParL=c(ParL,tmp)
      tmp2=tmp
    }
  }
  return(ParL)
}

Evlptablepara<- function(...){
  varargin=list(...)
  Nargs=length(varargin)
  Tmp=varargin[[1]]
  Mdv=50
  Ndv=50
  if(Nargs>=2){
    Tmp=varargin[[2]]
    if(is.list(Tmp)){Tmp=Op(1,Tmp)}
    if(length(Tmp)>1){
      Mdv=Tmp[1]
      Ndv=Tmp[2]
    }else{
      Mdv=Tmp
      if(Nargs==2){
        Ndv=Mdv
      }else{
        Tmp1=varargin[[3]]
        if((is.numeric(Tmp1)) && (length(Tmp1)==1)){
          Ndv=Tmp1
        }else{
          Ndv=Mdv
        }
      }
    }
  }
  U1=URNG[1]; U2=URNG[2]
  V1=VRNG[1]; V2=VRNG[2]
  Du=(U2-U1)/(Mdv)
  Dv=(V2-V1)/(Ndv)
  sph=sprintf("%7.7f",sin(PHI))
  cph=sprintf("%7.7f",cos(PHI))
  sth=sprintf("%7.7f",sin(THETA))
  cth=sprintf("%7.7f",cos(THETA))
  xstr=paste("-(",XYZstr[1],")*(",sph,")+(",XYZstr[2],")*(",cph,")",sep="")
  tmp=paste("-(",XYZstr[1],")*(",cph,")*(",cth,")-(",XYZstr[2],")*(",sph,")*(",cth,")",sep="")
  ystr=paste(tmp,"+(",XYZstr[3],")*(",sth,")",sep="")
  dxu=Diff(xstr,UNAME)
  dxv=Diff(xstr,VNAME)
  dyu=Diff(ystr,UNAME)
  dyv=Diff(ystr,VNAME)
  I=1
  Zval=c()
  for(jj in 1:(Ndv+1)){
    v=V1+(jj-1)*Dv
    ZuL=c()
    for(ii in 1:(Mdv+1)){
      u=U1+(ii-1)*Du
      tmp1=paste(UNAME,"=(",sprintf("%7.7f",u),")",sep="")
      tmp2=paste(VNAME,"=(",sprintf("%7.7f",v),")",sep="")
      Dxu=Funvalue(dxu,tmp1,tmp2)
      Dxv=Funvalue(dxv,tmp1,tmp2)
      Dyu=Funvalue(dyu,tmp1,tmp2)
      Dyv=Funvalue(dyv,tmp1,tmp2)
      Tmp=Dxu*Dyv-Dxv*Dyu
      ZuL=c(ZuL,Tmp)
    }
    Zval=Appendrow(Zval,ZuL)
  }
  Yval=c()
  for(jj in 1:(Ndv+1)){
    v=V1+(jj-1)*Dv
    Yval=c(Yval,v)
  }
  Xval=c()
  for(ii in 1:(Mdv+1)){
    u=U1+(ii-1)*Du
    Xval=c(Xval,u)
  }
  return(list(Zval,Xval,Yval))
}

Evlpfun<- function(u,v){
  tmp1=paste(UNAME,"=(",sprintf("%7.7f",u),")",sep="")
  tmp2=paste(VNAME,"=(",sprintf("%7.7f",v),")",sep="")
  Dxu=Funvalue(dxu,tmp1,tmp2)
  Dxv=Funvalue(dxv,tmp1,tmp2)
  Dyu=Funvalue(dyu,tmp1,tmp2)
  Dyv=Funvalue(dyv,tmp1,tmp2)
  Tmp=Dxu*Dyv-Dxv*Dyu
  return(Tmp)
}

Envelopedata<- function(...){
  varargin=list(...)
  Eps0=10^(-4)
  Nargs=length(varargin)
  Fd=varargin[[1]]
  Fullformfunc(Fd)
  Mdv=50
  Ndv=50
  if(Nargs>=2){
    Tmp=varargin[[2]]
    if(is.list(Tmp)){Tmp=Op(1,Tmp)}
    if(length(Tmp)>1){
      Mdv=Tmp[1]
      Ndv=Tmp[2]
    }else{
      Mdv=Tmp
      if(Nargs==2){
        Ndv=Mdv
      }else{
        Tmp1=varargin[[3]]
        if((is.numeric(Tmp1)) && (length(Tmp1)==1)){
          Ndv=Tmp1
        }else{
          Ndv=Mdv
        }
      }
    }
  }
  sph=sprintf("%7.7f",sin(PHI))
  cph=sprintf("%7.7f",cos(PHI))
  sth=sprintf("%7.7f",sin(THETA))
  cth=sprintf("%7.7f",cos(THETA))
  xstr=paste("-(",XYZstr[1],")*(",sph,")+(",XYZstr[2],")*(",cph,")",sep="")
  tmp=paste("-(",XYZstr[1],")*(",cph,")*(",cth,")-(",XYZstr[2],")*(",sph,")*(",cth,")",sep="")
  ystr=paste(tmp,"+(",XYZstr[3],")*(",sth,")",sep="")
  dxu<<- Diff(xstr,UNAME)
  dxv<<- Diff(xstr,VNAME)
  dyu<<- Diff(ystr,UNAME)
  dyv<<- Diff(ystr,VNAME)
  U1=URNG[1]; U2=URNG[2]
  V1=VRNG[1]; V2=VRNG[2]
  Du=(U2-U1)/Mdv
  Dv=(V2-V1)/Ndv
  Out=c()
  for(J in 1:(Ndv)){
    Vval1=VRNG[1]+(J-1)*Dv
    Vval2=VRNG[1]+J*Dv
    Uval1=URNG[1]
    Eval11=Evlpfun(Uval1,Vval1)
    Eval12=Evlpfun(Uval1,Vval2)
    for(I in 1:(Mdv)){
      Uval2=URNG[1]+I*Du
      Eval21=Evlpfun(Uval2,Vval1)
      Eval22=Evlpfun(Uval2,Vval2)
      a1=Uval1;b1=Vval1;c1=Eval11
      a2=Uval2;b2=Vval1;c2=Eval21
      a3=Uval2;b3=Vval2;c3=Eval22
      a4=Uval1;b4=Vval2;c4=Eval12
      PL=matrix(c(a1,b1,a2,b2,a3,b3,a4,b4,a1,b1),ncol=2,byrow=TRUE)
      VL=c(c1,c2,c3,c4,c1)
      QL=c()
      for(K in 1:4){
        if(abs(VL[K])<=Eps0){
          QL=Appendrow(QL,PL[K,])
        }else if(VL[K]>Eps0){
          if(VL[K+1]< -Eps0){
            Tmp=1/(VL[K]-VL[K+1])*(-VL[K+1]*PL[K,]+VL[K]*PL[K+1,])
            QL=Appendrow(QL,Tmp)
          }
        }else{
          if(VL[K+1]>Eps0){
            Tmp=1/(-VL[K]+VL[K+1])*(VL[K+1]*PL[K,]-VL[K]*PL[K+1,])
            QL=Appendrow(QL,Tmp)
          }
        }
      }
      Uval1=Uval2
      Eval11=Eval21
      Eval12=Eval22
	  if(Length(QL)==2){
        Out=Appendrow(Out,c(Inf,Inf))
        Out=Appendrow(Out,QL)
      }
    }
  }
  Out=Out[2:nrow(Out),]
  if(Length(Out)>0){
    Out=Connectseg(Out)
  }else{
    Out=c()
  }
  return(Out)
}

Dropnumlistcrv<- function(QdL,Eps1){
  Eps0=10^(-4)
  if(!is.list(QdL)){
    PdL=list(QdL)
  }else{
    PdL=QdL
  }
  OutL=list()
  for(I in Looprange(1,length(PdL))){
    Pd=Op(I,PdL)
    PtL=c(1)
    P=Op(1,Pd)
    for(K in Looprange(2,Length(Pd)-1)){
      if(Norm(P-Op(K,Pd))>Eps1){
        PtL=c(PtL,K)
        P=Op(K,Pd)
      }
    }
    K=Length(Pd)
    if(Norm(P-Op(K,Pd))>Eps1){ #18.02.12 eps
      PtL=c(PtL,K)
    }
    OutL=c(OutL,list(PtL))
  }
  return(OutL)
}

Cuspsplitpara<- function(...){
  varargin=list(...)
  Nargs=length(varargin);
  Gdxy=varargin[[1]]
  if(!is.list(Gdxy)){
    Gdxy=list(Gdxy)
  }
  Eps0=10^(-4)
  Eps1=0.01
  if(Nargs>2){Eps1=varargin[[2]]}
  N=2
  CUSPSPLITPT<<- list()
  OutkL=list()
  for(Ng in Looprange(1,length(Gdxy))){
    PtxyL=Op(Ng,Gdxy)
    PtkL=c()
    PthL=c()
    for(I in Looprange(1,Length(PtxyL))){
      Tmp=Op(I,PtxyL)
      Tmp1=paste(UNAME,'=',sprintf("%7.7f",Tmp[1]),sep="")
      eval(parse(text=Tmp1))
      Tmp1=paste(VNAME,'=',sprintf("%7.7f",Tmp[2]),sep="")
      eval(parse(text=Tmp1))
      Tmp2=c(eval(parse(text=XYZstr[1])))
      Tmp2=c(Tmp2,eval(parse(text=XYZstr[2])))
      Tmp2=c(Tmp2,eval(parse(text=XYZstr[3])))
      Tmp3=Parapt(Tmp2)
      if(I==1){
        PtkL=matrix(Tmp2,nrow=1)
        PthL=matrix(Tmp3,nrow=1)
      }else{
        Tmp4=Op(Length(PthL),PthL)
        if(Norm(Tmp3-Tmp4)>Eps0){
          PtkL=Appendrow(PtkL,Tmp2)
          PthL=Appendrow(PthL,Tmp3)
        }
      }
    }
    if(Length(PthL)==0){
      return(list())
    }
    Ps=Op(1,PthL); Pe=Op(Length(PthL),PthL)
    Cflg=0
    if(Norm(Ps-Pe)<Eps1){Cflg=1}
    CuspL=c()
    Cva=cos(10*pi/180)
    for(I in Looprange(1,Length(PthL)-1)){
      if(Length(PthL)==2){break}
      Tmp=Op(I,PthL)
      if(I==1){
        if(Cflg==0){next}
        Tmp1=Op(Length(PthL)-1,PthL)
      }else{
        Tmp1=Op(I-1,PthL)
      }
      Tmp2=Op(I+1,PthL)
      V1=Tmp-Tmp1
      V2=Tmp2-Tmp
      Tmp3=Dotprod(V1,V2)/(Norm(V1)*Norm(V2))
      Cuspflg=0
      if(Tmp3<Cva){
        P=Op(I,PthL)
        Kaku=acos(Tmp3)*180/pi
        if(Crossprod(V1,V2)<0){
          Kaku=-Kaku 
        }
		Cuspflg=0
        for(J in Looprange(I+1,Length(PthL)-1)){
          if(abs(Kaku)>90){
            Cuspflg=1
            break
          }
          Q=Op(J,PthL)
          if(Norm(P-Q)>Eps1){
            break
          }
          V1=Q-Op(J-1,PthL)
          V2=Op(J+1,PthL)-Q
          Tmp3=Dotprod(V1,V2)/(norm(V1)*norm(V2))
          Tmp=acos(Tmp3)*180/pi
          if(Crossprod(V1,V2)<0){
            Tmp=-Tmp 
          }
          Kaku=Kaku+Tmp
        }
        if(Cuspflg==1){
          Tmp=trunc((I+J)*0.5)
          I=J
          if(length(CuspL)==0){
            CuspL=c(Tmp)
          }else{
            CuspL=c(CuspL,Tmp)
          }
        }
      }
    }
    if(Cflg==0){
      CuspL=c(1,CuspL,Length(PthL))
    }else if(length(CuspL)==0){
      CuspL=c(1,Length(PthL))
    }else if(Op(1,CuspL)==1){
      CuspL=c(CuspL,Length(PthL))
    }else{
      Tmp=Op(1,CuspL)
      Tmp1=PthL[Tmp:Length(PthL),]
      Tmp2=PthL[2:Tmp,]
      PthL=Appendrow(Tmp1,Tmp2)
      Tmp1=PtkL[Tmp:Length(PthL),]
      Tmp2=PtkL[2:Tmp,]
      PtkL=Appendrow(Tmp1,Tmp2)
      CuspL=CuspL-Tmp+1
      CuspL=c(CuspL,Length(PthL))
    }
    if(length(CuspL)==2){
      Tmp4=PthL[Length(PthL),]
      if(Length(PtkL)>=2){
        CUSPSPLITPT<<- c(CUSPSPLITPT,list(Tmp4))
        OutkL=c(OutkL,list(PtkL))
      }
      next
    }
    Outk=list()
    Is=1
    for(I in Looprange(1,length(CuspL)-1)){
      Tmp1=CuspL[Is]; Tmp2=CuspL[I+1]
      Tmp3=Op(Tmp1,PthL); Tmp4=Op(Tmp2,PthL)
      if(Norm(Tmp3-Tmp4)>Eps1){
        Tmpk=PtkL[Tmp1:Tmp2,]
        Outk=c(Outk,list(Tmpk))
        CUSPSPLITPT<<- c(CUSPSPLITPT,list(Tmp4))
        Is=I+1
      }
    }
    OutkL=c(OutkL,Outk)
  }
  Tmp1=Dropnumlistcrv(Projpara(OutkL),Eps1*0.5)
  Tmp=list()
  for(I in Looprange(1,length(OutkL))){
    Tmp2=Op(I,OutkL)
    Tmp3=Op(I,Tmp1)
    Tmp4=c()
    for(J in Looprange(1,Length(Tmp3))){
      Tmp5=Op(Tmp3[J],Tmp2)
      Tmp4=Appendrow(Tmp4,Tmp5)
    }
    if(Length(Tmp4)>0){
      Tmp=c(Tmp,list(Tmp4))
    }
  }
  return(Tmp)
}

PthiddenQ<- function(PtA,Vec,Uveq,Np,Eps1,Eps2){
  Eps0=10^(-4)
  Out=c()
  Vec=1/Norm(Vec)*Vec
  if(length(Np)==1){
    Np=c(Np,Np)
  }
  Tmp=paste("Eqfun<- function(U,V){",sep='')
  if((abs(Vec[2])>Eps0) || (abs(Vec[1])>Eps0)){
    Vstr=sprintf("%6.6f",Vec)
    Pstr=sprintf("%6.6f",PtA)
    Tmp=paste(Tmp,"(",Vstr[2],")*(Xfunc(U,V)-(",Pstr[1],"))",sep='')
    Tmp=paste(Tmp,"-(",Vstr[1],")*(Yfunc(U,V)-(",Pstr[2],"))}",sep='')
  }else{
    Tmp=paste(Tmp,"Xfunc(U,V)}",sep='')
  }
  eval(parse(text=Tmp))
  Dx=(URNG[2]-URNG[1])/Np[1]
  Dy=(VRNG[2]-VRNG[1])/Np[2]
  for(J in Looprange(1,Np[2])){ #180227
    Vval1=VRNG[1]+(J-1)*Dy
    Vval2=VRNG[1]+J*Dy
    Uval1=URNG[1] #180306(3lines)
    Eval11=Eqfun(Uval1,Vval1)
    Eval12=Eqfun(Uval1,Vval2)
    for(I in Looprange(1,Np[1])){ #180227
      Uval2=URNG[1]+I*Dx
      Eval21=Eqfun(Uval2,Vval1)
      Eval22=Eqfun(Uval2,Vval2)
      a1=Uval1;b1=Vval1;c1=Eval11
      a2=Uval2;b2=Vval1;c2=Eval21
      a3=Uval2;b3=Vval2;c3=Eval22
      a4=Uval1;b4=Vval2;c4=Eval12
      PL=matrix(c(a1,b1,a2,b2,a3,b3,a4,b4,a1,b1),ncol=2,byrow=TRUE)
      VL=c(c1,c2,c3,c4,c1)
      QL=c()
      for(K in 1:4){
        P1=Op(K,PL); P2=Op(K+1,PL)
        M1=Op(K,VL); M2=Op(K+1,VL)
        if(abs(M1)<Eps0){
          QL=Appendrow(QL,P1)
          next
        }
        if(abs(M2)<Eps0){
          next
        }
        if((M1> 0) && (M2> 0)){
          next
        }
        if((M1< 0) && (M2< 0)){
          next
        }
        Tmp=1/(M1-M2)*(-M2*P1+M1*P2)
        QL=Appendrow(QL,Tmp)
      }
      Uval1=Uval2 #180306(3lines)
      Eval11=Eval21
      Eval12=Eval22
      if(Length(QL)==2){
        Puv1=Op(1,QL); Puv2=Op(2,QL)
        Tmp1=Op(1,Puv1)
        Tmp2=Op(2,Puv1)
        Xv=Xfunc(Tmp1,Tmp2)
        Yv=Yfunc(Tmp1,Tmp2)
        Zv=Zfunc(Tmp1,Tmp2)
        P1=c(Xv,Yv,Zv)
        Tmp1=Op(1,Puv2)
        Tmp2=Op(2,Puv2)
        Xv=Xfunc(Tmp1,Tmp2)
        Yv=Yfunc(Tmp1,Tmp2)
        Zv=Zfunc(Tmp1,Tmp2)
        P2=c(Xv,Yv,Zv)
        V1=Vec[1]; V2=Vec[2]; V3=Vec[3]
        if(abs(V1)>Eps0){
          M1=PtA[3]+V3/V1*(P1[1]-PtA[1])-P1[3]
          M2=PtA[3]+V3/V1*(P2[1]-PtA[1])-P2[3]
        }else if(abs(V2)>Eps0){
          M1=PtA[3]+V3/V2*(P1[2]-PtA[2])-P1[3]
          M2=PtA[3]+V3/V2*(P2[2]-PtA[2])-P2[3]
        }else{
          M1=PtA[2]-P1[2]
          M2=PtA[2]-P2[2]
        }
        if(M1*M2>= 0){
          if(((M1>0) && (M2>0)) || ((M1< 0) && (M2< 0))){
            next
          }
          if(M1==0){
            Pt=P1; Ptuv=Puv1
          }else{
            Pt=P2; Ptuv=Puv2
          }
        }else{  
          Pt=1/(M1-M2)*(-M2*P1+M1*P2)
          Ptuv=1/(M1-M2)*(-M2*Puv1+M1*Puv2)
        }
        if(is.character(Uveq)){		
          Tmp1=paste('(',sprintf("%6.6f",Ptuv[1]),')',sep='')
          Tmp2=paste('('+sprintf("%6.6f",Ptuv[2]),')',sep='')
          Tmp=gsub(UNAME,Tmp1,Uveq,fixed=TRUE)
          Tmp=gsub(VNAME,Tmp2,Tmp,fixed=TRUE)
          Tmp=eval(parse(text=Tmp))
          if(Tmp< -Eps0){
            next
          }
        }
        Tmp1=Crossprod(Pt-PtA,Vec)
       if(Norm(Tmp1)<Eps1){ #18.02.19
		  if(Zparapt(Pt)>Zparapt(PtA)+Eps2){
            return(list(1,Pt,Zparapt(Pt),Zparapt(PtA)))
          }else{
            Out=Appendrow(Out,Pt)
          }
        }
      }
    }
  }
  if(Length(Out)==0){
    return(list(0,c()))
  }
  return(c(list(0,Out)))
}

Nohiddenpara2<- function (Par,Fk,Uveq,Np,Eps1,Eps2){
  Eps0=10^(-4)
  Fh=Projpara(Fk)
  P1=Ptstart(Fh)
  P2=Ptend(Fh)
  Csp=CUSPPT
  if(!is.list(Csp)){Csp=list(Csp)}
  Cspflg=1
  for(I in Looprange(1,length(Csp))){
    Tmp=Op(I,Csp)
    if(Norm(Tmp-P1)<Eps0){
      if(Cspflg==1){Cspflg=2}
      if(Cspflg==3){Cspflg=6}
      next
    }
    if(Norm(Tmp-P2)<Eps0){
      if(Cspflg==1){Cspflg=3}
      if(Cspflg==2){Cspflg=6}
      next
    }
  }
  PaL=c()
  tmp2=-1
  for(jj in Looprange(1,length(Par)-1)){
    tmp1=Op(jj,Par)
    if(abs(tmp1-tmp2)>Eps0){ #180227
      PaL=c(PaL,tmp1)
      tmp2=tmp1
    }
  }
  tmp1=PaL[length(PaL)] #18.02.26from
  tmp2=Par[length(Par)]
  if(abs(tmp1-tmp2)<Eps0){ #180227
    PaL[length(PaL)]=tmp2
  }else{
    PaL=c(PaL,tmp2)
  } #18.02.26to
  SeL=c()
  for(N in Looprange(1,length(PaL)-1)){
    S=(PaL[N]+PaL[N+1])/2
    Tmp=Invparapt(S,Fh,Fk)
    PtA=Op(1,Tmp)
    PtAp=Parapt(PtA)
    Vec=c(sin(THETA)*cos(PHI),sin(THETA)*sin(PHI),cos(THETA))
    Flg=PthiddenQ(PtA,Vec,Uveq,Np,Eps1,Eps2)
    if(Flg[[1]]==0){
      SeL=c(SeL,N)
    }
  }
  FigL=list()
  FigkL=list()
  for(I in Looprange(1,length(SeL))){
    Tmp1=Pointoncurve(PaL[SeL[I]],Fh)
    Tmp2=Pointoncurve(PaL[SeL[I]+1],Fh)
    if(I==1){
      P=Tmp1; SP=PaL[SeL[I]]
      Q=Tmp2; SQ=PaL[SeL[I]+1]
    }else{
      if(Member(SeL[I]-1,SeL)){
        Q=Tmp2; SQ=PaL[SeL[I]+1]
      }else{
        FigL=c(FigL,list(Partcrv(SP,SQ,Fh)))
        Tmp3=Invparapt(SP,Fh,Fk)
        TP=Op(2,Tmp3)
        Tmp3=Invparapt(SQ,Fh,Fk)
        TQ=Op(2,Tmp3)
        Tmp4=Partcrv3(TP,TQ,Fk)
        FigkL=c(FigkL,list(Tmp4))
        P=Tmp1; SP=PaL[SeL[I]]
        Q=Tmp2; SQ=PaL[SeL[I]+1]
      }
    }
  }
  if(length(SeL)>0){
    if(Norm(P-Q)>Eps0){ #18.02.14
      FigL=c(FigL,list(Partcrv(P,Q,Fh)))
      Tmp3=Invparapt(SP,Fh,Fk)
      TP=Op(2,Tmp3)
      Tmp3=Invparapt(SQ,Fh,Fk)
      TQ=Op(2,Tmp3)
      FigkL=c(FigkL,list(Partcrv3(TP,TQ,Fk)))
    }else{
      FigL=c(FigL,list(Fh))
      FigkL=c(FigkL,list(Fk))
    }
  }
  if(length(SeL)==0){#181024from
    Tmp=Looprange(1,length(PaL)-1) 
  }else{ #181024to
    Tmp=c()
    for(I in Looprange(1,length(PaL)-1)){
      if(!Member(I,SeL)){
        Tmp=c(Tmp,I)
      }
    }
  }
  SeL=Tmp
  HIDDENDATA<<- list()
  for(I in Looprange(1,length(SeL))){
    Tmp=PaL[SeL[I]]
    Tmp1=Pointoncurve(Tmp,Fh)
    Tmp=PaL[SeL[I]+1]
    Tmp2=Pointoncurve(Tmp,Fh)
    if(I==1){
      P=Tmp1; SP=PaL[SeL[I]]
      Q=Tmp2; SQ=PaL[SeL[I]+1]
    }else{
      if(Member(SeL[I]-1,SeL)){
        Q=Tmp2; SQ=PaL[SeL[I]+1]
      }else{
        Tmp=Invparapt(SP,Fh,Fk)
        TP=Op(2,Tmp)
        Tmp=Invparapt(SQ,Fh,Fk)
        TQ=Op(2,Tmp)
        HIDDENDATA<<- c(HIDDENDATA,list(Partcrv3(TP,TQ,Fk)))
        P=Tmp1; SP=PaL[SeL[I]]
        Q=Tmp2; SQ=PaL[SeL[I]+1]
      }
    }
  }
  if(length(SeL)>0){
    if(Norm(P-Q)>Eps0){ #18.02.14
      Tmp=Invparapt(SP,Fh,Fk)
      TP=Op(2,Tmp)
      Tmp=Invparapt(SQ,Fh,Fk)
      TQ=Op(2,Tmp)
      HIDDENDATA<<- c(HIDDENDATA,list(Partcrv3(TP,TQ,Fk)))
    }else{
      HIDDENDATA<<- c(HIDDENDATA,list(Fk))
    }
  }
  return(FigkL)
}

Borderparadata<- function(...){
  varargin=list(...)
  Nargs=length(varargin)
  FkL=varargin[[1]]
  Np=c(50,50)
  Eps1=0.01
  Eps2=0.05
  ctr=0
  for(jj in Looprange(2,Nargs)){
    tmp=varargin[[jj]]
    if((length(tmp)>1)||(tmp>1)){
      Np=tmp
      if(length(Np)==1){
        Np=c(Np,Np)
      }
    }else{
      ctr=ctr+1
      if(ctr==1){Eps1=tmp}
      if(ctr==2){Eps2=tmp}
    }
  }
  Umin=URNG[1]; Umax=URNG[2]
  Vmin=VRNG[1]; Vmax=VRNG[2]
  EkL=list()
  Tmp=grep("e",DRWS,fixed=TRUE)
  if(length(Tmp)>0){
    Tmp1="c("
    for(jj in 1:3){
      Tmp=gsub(UNAME,paste("(",sprintf("%7.7f",Umax),")",sep=""),XYZstr[jj])
      Tmp1=paste(Tmp1,Tmp,",",sep="")
    }
    Tmp=substring(Tmp1,1,Length(Tmp1)-1)
    Tmp1=paste(Tmp,")",sep="")
    Tmp=sprintf("%6.6f",VRNG)
    Tmp2=paste(VNAME,"=c(",Tmp[1],",",Tmp[2],")",sep='')
    Tmp3=paste('N=',as.character(Np[2]),sep="")
    Tmp=Spacecurve(Tmp1,Tmp2,Tmp3)
    EkL=c(EkL,list(Tmp))
  }
  Tmp=grep("n",DRWS,fixed=TRUE)
  if(length(Tmp)>0){
    Tmp1="c("
    for(jj in 1:3){
      Tmp=gsub(VNAME,paste("(",sprintf("%7.7f",Vmax),")",sep=""),XYZstr[jj])
      Tmp1=paste(Tmp1,Tmp,",",sep="")
    }
    Tmp=substring(Tmp1,1,Length(Tmp1)-1)
    Tmp1=paste(Tmp,")",sep="")
    Tmp=sprintf("%6.6f",URNG)
    Tmp2=paste(UNAME,"=c(",Tmp[1],",",Tmp[2],")",sep='')
    Tmp3=paste('N=',as.character(Np[1]),sep="")
    Tmp=Spacecurve(Tmp1,Tmp2,Tmp3)
    EkL=c(EkL,list(Tmp))
  }
  Tmp=grep("w",DRWS,fixed=TRUE)
  if(length(Tmp)>0){
    Tmp1="c("
    for(jj in 1:3){
      Tmp=gsub(UNAME,paste("(",sprintf("%7.7f",Umin),")",sep=""),XYZstr[jj])
      Tmp1=paste(Tmp1,Tmp,",",sep="")
    }
    Tmp=substring(Tmp1,1,Length(Tmp1)-1)
    Tmp1=paste(Tmp,")",sep="")
    Tmp=sprintf("%6.6f",VRNG)
    Tmp2=paste(VNAME,"=c(",Tmp[1],",",Tmp[2],")",sep='')
    Tmp3=paste('N=',as.character(Np[2]))
    Tmp=Spacecurve(Tmp1,Tmp2,Tmp3)
    EkL=c(EkL,list(Tmp))
  }
  Tmp=grep("s",DRWS,fixed=TRUE)
  if(length(Tmp)>0){
    Tmp1="c("
    for(jj in 1:3){
      Tmp=gsub(VNAME,paste("(",sprintf("%7.7f",Vmin),")",sep=""),XYZstr[jj])
      Tmp1=paste(Tmp1,Tmp,",",sep="")
    }
    Tmp=substring(Tmp1,1,Length(Tmp1)-1)
    Tmp1=paste(Tmp,")",sep="")
    Tmp=sprintf("%6.6f",URNG)
    Tmp2=paste(UNAME,"=c(",Tmp[1],",",Tmp[2],")",sep='')
    Tmp3=paste('N=',as.character(Np[1]))
    Tmp=Spacecurve(Tmp1,Tmp2,Tmp3)
    EkL=c(EkL,list(Tmp))
  }
  if(length(EkL)>0){
    FkL=c(FkL,EkL)
  }
  Fall=Projpara(FkL)
  if(is.numeric(Fall)){
    Fall=list(Fall)
  }
  Fbdxy=Makexybdy(Np)
  BORDERPT<<- list()
  Tmp1=list()
  for(I in Looprange(1,length(Fall))){
    Tmp1=c(Tmp1,list(c()))
  }
  OTHERPARTITION<<- Tmp1
  FsL=list()
  BORDERHIDDENDATA<<- list()
  starttime=proc.time()
  for(I in Looprange(1,length(FkL))){
    Tmp=Op(I,FkL)
    Tmp=Projpara(Tmp)
    Par=Partitionseg(Tmp,Fall,Eps1,Eps2,I)
    Tmp1=Op(I,FkL)
    Tmp=Nohiddenpara2(Par,Tmp1,1,Np,Eps1,Eps2)
	if(length(HIDDENDATA)>0){
      BORDERHIDDENDATA<<- c(BORDERHIDDENDATA,HIDDENDATA)
    }
    if(length(Tmp)>0){
      FsL=c(FsL,Tmp)
    }
    Tmp=paste('Border',formatC(I,width=2,flag="0"),'/',sep='')
    Tmp=paste(Tmp,as.character(length(FkL)),' obtained  : Time =',sep='')
    Tmp1=proc.time()-starttime
    print(paste(Tmp,sprintf("%6.3f",Tmp1[1]),sep=''))
  }
  return(FsL)
}

Sfbdparadata<- function(...){
  varargin=list(...)
  Nargs=length(varargin)
  Fd=varargin[[1]]
  FdL=Fullformfunc(Fd)
  Np=c(50,50)
  Eps0=10^(-4)
  Eps1=0.01
  Eps2=0.05
  ctr=0
  for(jj in Looprange(2,Nargs)){
    tmp=varargin[[jj]]
    if((length(tmp)>1)||(tmp>1)){
      Np=tmp
      if(length(Np)==1){
        Np=c(Np,Np)
      }
    }else{
      ctr=ctr+1
      if(ctr==1){Eps1=tmp}
      if(ctr==2){Eps2=tmp}
    }
  }
  starttime=proc.time()
  Out3=Envelopedata(Fd) #180306
  tmp3=list()
  pts=list() #180306
  for(jj in Looprange(1,length(Out3))){
    tmp1=Op(jj,Out3)
    tmp2=c()
    for(kk in Looprange(1,Length(tmp1))){
      tmp=Op(kk,tmp1)
      tmp2=Appendrow(tmp2,XYZfunc(tmp[1],tmp[2]))
    }
    Nlist=Dropnumlistcrv(tmp2,Eps1)
    Nlist=Nlist[[1]]
    if(Length(Nlist)==1){ #180306from
      tmp=Op(1,Nlist)
      tmp=Op(tmp,tmp1)
      pts=c(pts,list(tmp))
    }else{      
      tmp=c()
      for(kk in Looprange(1,length(Nlist))){
        tmp=Appendrow(tmp,Op(Nlist[kk],tmp1)) #18.02.18
      }
      if(Length(tmp)>0){
        tmp3=c(tmp3,list(tmp))
      }
    }
  }
  Out3=tmp3
  tmp3=pts #180306from
  pts=list()
  for(ii in Looprange(1,length(tmp3))){
    tmp=Op(ii,tmp3)
    tmp1=XYZfunc(tmp[1],tmp[2])
    flg=0
    for(jj in Looprange(1,length(pts))){
      tmp=Op(jj,pts)
      tmp2=XYZfunc(tmp[1],tmp[2]) #180517
      if(Norm(tmp1-tmp2)<Eps1){
        flg=1; break
      }
    }
    if(flg==0){pts=c(pts,list(Op(ii,tmp3)))}
  }
  for(ii in Looprange(1,length(pts))){
    tmp=Op(ii,pts)
    tmp1=XYZfunc(tmp[1],tmp[2])
    for(jj in Looprange(1,length(Out3))){
      tmp2=Op(jj,Out3)
      eps=1
      for(kk in Looprange(1,Length(tmp2)-1)){
        tmp=Op(kk,tmp2)
        tmp1=XYZfunc(tmp[1],tmp[2])
        tmp=Op(kk+1,tmp2)
        tmp=XYZfunc(tmp[1],tmp[2])
        eps=min(c(eps,Norm(tmp1-tmp)))
      }
      tmp=Ptstart(tmp2)
      if(Norm(tmp1-XYZfunc(tmp[1],tmp[2]))<eps+Eps0){
        Out3[[jj]]=Appendrow(Op(ii,pts),tmp2)
        next
      }
      tmp=Ptend(tmp2)
      if(Norm(tmp1-XYZfunc(tmp[1],tmp[2]))<eps+Eps0){
        Out3[[jj]]=Appendrow(tmp2,Op(ii,pts))
        next
      }
    }
  } #180306to
  IMPLICITDATA<<- Out3
  Tmp=proc.time()-starttime
  print(paste('ImplicitData obtained : Time =',sprintf("%6.3f",Tmp[1]),sep=''))
  starttime=proc.time()
  Out4=Cuspsplitpara(Out3,Eps1)
  CUSPDATA<<- Out4
  CUSPPT<<- CUSPSPLITPT
  Tmp=proc.time()-starttime
  print(paste('CuspData obtained     : Time =',sprintf("%6.3f",Tmp[1]),sep=''))
  Out5=Borderparadata(Out4,Np,Eps1,Eps2)
  return(Out5)
}

Meetpoints<- function(PtA,PtB,Uveq,Np,Eps1){
  Eps0=10^(-4)
  Vec=PtB-PtA
  if(Norm(Vec)<Eps0){return(list())} #18.02.24
  Out=list()
  Vec=1/Norm(Vec)*Vec
  if(length(Np)==1){
    Np=c(Np,Np)
  }
  Tmp=paste("Eqfun<- function(U,V){",sep='')
  if((abs(Vec[2])>Eps0) || (abs(Vec[1])>Eps0)){
    Vstr=sprintf("%6.6f",Vec)
    Pstr=sprintf("%6.6f",PtA)
    Tmp=paste(Tmp,"(",Vstr[2],")*(Xfunc(U,V)-(",Pstr[1],"))",sep='')
    Tmp=paste(Tmp,"-(",Vstr[1],")*(Yfunc(U,V)-(",Pstr[2],"))}",sep='')
  }else{
    Tmp=paste(Tmp,"Xfunc(U,V)}",sep='')
  }
  eval(parse(text=Tmp))
  Dx=(URNG[2]-URNG[1])/Np[1]
  Dy=(VRNG[2]-VRNG[1])/Np[2]
  for(J in Looprange(1,Np[2])){ 
    Vval1=VRNG[1]+(J-1)*Dy
    Vval2=VRNG[1]+J*Dy
    Uval1=URNG[1]  #180305(3lines)
    Eval11=Eqfun(Uval1,Vval1)
    Eval12=Eqfun(Uval1,Vval2)
    for(I in Looprange(1,Np[1])){ 
      Uval2=URNG[1]+I*Dx
      Eval21=Eqfun(Uval2,Vval1)
      Eval22=Eqfun(Uval2,Vval2)
      a1=Uval1;b1=Vval1;c1=Eval11
      a2=Uval2;b2=Vval1;c2=Eval21
      a3=Uval2;b3=Vval2;c3=Eval22
      a4=Uval1;b4=Vval2;c4=Eval12
      PL=matrix(c(a1,b1,a2,b2,a3,b3,a4,b4,a1,b1),ncol=2,byrow=TRUE)
      VL=c(c1,c2,c3,c4,c1)
      QL=c()
      for(K in 1:4){
        P1=Op(K,PL); P2=Op(K+1,PL)
        M1=Op(K,VL); M2=Op(K+1,VL)
        if(abs(M1)<Eps0){
          QL=Appendrow(QL,P1)
          next
        }
        if(abs(M2)<Eps0){
          next
        }
        if((M1> 0) && (M2> 0)){
          next
        }
        if((M1< 0) && (M2< 0)){
          next
        }
        Tmp=1/(M1-M2)*(-M2*P1+M1*P2)
        QL=Appendrow(QL,Tmp)
      }
      Uval1=Uval2 #180306(3lines)
      Eval11=Eval21
      Eval12=Eval22
      if(Length(QL)==2){
        Puv1=Op(1,QL); Puv2=Op(2,QL)
        Tmp1=Op(1,Puv1)
        Tmp2=Op(2,Puv1)
        Xv=Xfunc(Tmp1,Tmp2)
        Yv=Yfunc(Tmp1,Tmp2)
        Zv=Zfunc(Tmp1,Tmp2)
        P1=c(Xv,Yv,Zv)
        Tmp1=Op(1,Puv2)
        Tmp2=Op(2,Puv2)
        Xv=Xfunc(Tmp1,Tmp2)
        Yv=Yfunc(Tmp1,Tmp2)
        Zv=Zfunc(Tmp1,Tmp2)
        P2=c(Xv,Yv,Zv)
        V1=Vec[1]; V2=Vec[2]; V3=Vec[3]
        if(abs(V1)>Eps0){
          M1=PtA[3]+V3/V1*(P1[1]-PtA[1])-P1[3]
          M2=PtA[3]+V3/V1*(P2[1]-PtA[1])-P2[3]
        }else if(abs(V2)>Eps0){
          M1=PtA[3]+V3/V2*(P1[2]-PtA[2])-P1[3]
          M2=PtA[3]+V3/V2*(P2[2]-PtA[2])-P2[3]
        }else{
          M1=PtA[2]-P1[2]
          M2=PtA[2]-P2[2]
        }
        if(M1*M2>= 0){ #18.02.21
          if(((M1>0) && (M2>0)) || ((M1< 0) && (M2< 0))){
            next
          }
          if(M1==0){
            Pt=P1; Ptuv=Puv1
          }else{
            Pt=P2; Ptuv=Puv2
          }
        }else{  
          Pt=1/(M1-M2)*(-M2*P1+M1*P2)
          Ptuv=1/(M1-M2)*(-M2*Puv1+M1*Puv2)
        }
        if(is.character(Uveq)){
          Tmp1=paste('(',sprintf("%6.6f",Ptuv[1]),')',sep='')
          Tmp2=paste('('+sprintf("%6.6f",Ptuv[2]),')',sep='')
          Tmp=gsub(UNAME,Tmp1,Uveq,fixed=TRUE)
          Tmp=gsub(VNAME,Tmp2,Tmp,fixed=TRUE)
          Tmp=eval(parse(text=Tmp))
          if(Tmp< -Eps0){
            next
          }
        }
        Tmp1=Crossprod(Pt-PtA,Vec)
        if(Norm(Tmp1)<Eps1){ #18.02.19
          Tmp1=Dotprod(Pt-PtA,Vec) #18.02.21
          if((Tmp1>-Eps0)&&(Norm(Pt-PtA)<Norm(PtB-PtA)+Eps0)){#180429
            Out=c(Out,list(Pt))
          }
        }
      }
    }
  }
  tmp1=Groupnearpt(Out,Eps1)
  Out=list()
  for(jj in Looprange(1,length(tmp1))){
    tmp=Op(jj,tmp1)
    tmp=c(sum(tmp[,1]),sum(tmp[,2]),sum(tmp[,3]))/Length(tmp)
    Out=c(Out,list(tmp))
  }
  return(Out)
}

Clipindomain<- function(ObjL,FigL){
  Eps0=10^(-4)
  Eps1=0.01
  Eps2=0.05
  Bdy=Kyoukai(FigL)
  if(length(Bdy)>=2){
     Fbdy=Joincrvs(FigL)
  }else{
     Fbdy=Op(1,FigL)
  }
  if(!is.list(ObjL)){
    ObjL=list(ObjL)
  }
  if(!is.list(FigL)){
    FigL=list(FigL)
  }
  OutL=list()
  for(Nobj in Looprange(1,length(ObjL))){
    Obj=Op(Nobj,ObjL)
    ParL=c(1,Length(Obj))
    Tmp=IntersectcurvesPp(Obj,Fbdy,Eps1,Eps2)
    for(J in Looprange(1,length(Tmp))){
      Tmp1=Op(J,Tmp)
      ParL=c(ParL,Op(2,Tmp1))
    }
    ParL=sort(ParL)
    Tmp=c(1)
    for(I in Looprange(1,length(ParL))){
      Tmp1=Op(length(Tmp),Tmp)
      Tmp2=ParL[I]
      if(Tmp2-Tmp1>Eps0){
        Tmp=c(Tmp,Tmp2)
      }
    }
    ParL=Tmp
    Tmp1=Op(length(ParL),ParL)
    Tmp2=Length(Obj)
    if(abs(Tmp1-Tmp2)<Eps1){
      ParL=c(ParL[Looprange(1,length(ParL)-1)],Tmp2)
    }
    Fig=list()
    for(N in Looprange(1,length(ParL)-1)){
      Tmp=(ParL[N]+ParL[N+1])*0.5
      Tmp=Pointoncurve(Tmp,Obj)
      Tmp=Naigai(Tmp,Bdy)
      Tmp1=sum(Tmp)%%2
      if(Tmp1==0){
        next
      }
      Fig=c(Fig,list(Partcrv(ParL[N],ParL[N+1],Obj)))
    }
    OutL=c(OutL,Fig)
  }
  return(OutL)
}

Crvsfparadata<- function(...){
  starttime=proc.time()
  varargin=list(...)
  Nargs=length(varargin)
  Sepflg=0
  Tmp=varargin[[Nargs]]
  if((is.numeric(Tmp))&&(Tmp<=0)){
    Sepflg=1
    Nargs=Nargs-1
  }
  Fk=varargin[[1]]
  if(!is.list(Fk)){
    FkL=list(Fk)
  }else{
    FkL=Fk
  }
  Fbdy=Projpara(varargin[[2]])
  Fd=varargin[[3]]; 
  Fullformfunc(Fd) #18.02.17
  Np=c(50,50)
  Eps0=10^(-4)
  Eps1=0.01
  Eps2=0.05
  ctr=0
  for(jj in Looprange(4,Nargs)){
    tmp=varargin[[jj]]
    if((length(tmp)>1)||(tmp>1)){
      Np=tmp
      if(length(Np)==1){
        Np=c(Np,Np)
      }
    }else{
      ctr=ctr+1
      if(ctr==1){Eps1=tmp}
      if(ctr==2){Eps2=tmp}
    }
  }
  Out=list()
  CRVSFHIDDENDATA<<- list()
  for(Nn in Looprange(1,length(FkL))){
    Fk=Op(Nn,FkL)
    Tmp=Projpara(Fk)
    Par=Partitionseg(Tmp,Fbdy,Eps1,Eps2,0)
    if(Sepflg==0){
      for(I in Looprange(1,Length(Fk)-1)){
        Pa=Op(I,Fk)
        Pb=Op(I+1,Fk)
        PtL=Meetpoints(Pa,Pb,1,Np,Eps1)
        for(J in Looprange(1,Length(PtL))){
          Tmp=Op(J,PtL)
          Tmp=Parapt(Tmp)
          Tmp1=Paramoncurve(Tmp,I,Projpara(Fk))
          Tmp2=min(abs(Par-Tmp1))
          if(Tmp2*Norm(Parapt(Pb-Pa))>Eps0) { #180227
            Par=c(Par,Tmp1)
          }
        }
        Par=sort(Par)
      }
    }
    for(jj in Looprange(1,length(ADDPOINT))){ #18.02.19from
      tmp=Parapt(Op(jj,ADDPOINT))
      tmp=Nearestpt(tmp,Projpara(Fk))
      if(tmp[[3]]<Eps1){
        Par=c(Par,tmp[[2]])
      }
    } #18.02.19until
    tmp1=sort(Par)
    Par=c()
    tmp2=-1
    for(jj in Looprange(1,length(tmp1))){
      tmp=Op(jj,tmp1)
      if(abs(tmp-tmp2)>Eps0){ #180227
        Par=c(Par,tmp)
        tmp2=tmp
      }
    }
    Tmp1=Nohiddenpara2(Par,Fk,1,Np,Eps1,Eps2)
    Out=c(Out,Tmp1)
    CRVSFHIDDENDATA<<- c(CRVSFHIDDENDATA,HIDDENDATA)
    Tmp=paste('Crvsfdata',formatC(Nn,width=2,flag="0"),'/',sep='')
    Tmp=paste(Tmp,as.character(length(FkL)),' obtained  : Time =',sep='')
    Tmp1=proc.time()-starttime
    print(paste(Tmp,sprintf("%6.3f",Tmp1[1]),sep=''))
  }
  return(Out)
}

Crv3onsfparadata<- function(...){
  starttime=proc.time()
  varargin=list(...)
  Nargs=length(varargin)
  Fk=varargin[[1]]
  if(!is.list(Fk)){
    FkL=list(Fk)
  }else{
    FkL=Fk
  }
  Fbdy=Projpara(varargin[[2]])
  Fd=varargin[[3]]
  Fullformfunc(Fd) #18.02.17
  Np=c(50,50)
  Eps1=0.01
  Eps2=0.05
  ctr=0
  for(jj in Looprange(4,Nargs)){
    tmp=varargin[[jj]]
    if((length(tmp)>1)||(tmp>1)){
      Np=tmp
      if(length(Np)==1){
        Np=c(Np,Np)
      }
    }else{
      ctr=ctr+1
      if(ctr==1){Eps1=tmp}
      if(ctr==2){Eps2=tmp}
    }
  }
  Out=list()
  CRVONSFHIDDENDATA<<- list()
  for(Nn in Looprange(1,length(FkL))){
    Fk=Op(Nn,FkL)
    Tmp=Projpara(Fk)
    Par=Partitionseg(Tmp,Fbdy,Eps1,Eps2,0)
    for(jj in Looprange(1,length(ADDPOINT))){
      tmp=Parapt(Op(jj,ADDPOINT))
      tmp=Nearestpt(tmp,Projpara(Fk))
      if(tmp[[3]]<Eps1){
        Par=c(Par,tmp[[2]])
      }
    }
    Par=sort(Par)
    Tmp1=Nohiddenpara2(Par,Fk,1,Np,Eps1,Eps2)
    Out=c(Out,Tmp1)
    CRVONSFHIDDENDATA<<- c(CRVONSFHIDDENDATA,HIDDENDATA)
    Tmp=paste('Crvonsfdata',formatC(Nn,width=2,flag="0"),'/',sep='')
    Tmp=paste(Tmp,as.character(length(FkL)),' obtained  : Time =',sep='')
    Tmp1=proc.time()-starttime
    print(paste(Tmp,sprintf("%6.3f",Tmp1[1]),sep=''))
  }
  return(Out)
}

Crv2onsfparadata<- function(...){
  starttime=proc.time()
  varargin=list(...)
  Nargs=length(varargin)
  Fuv=varargin[[1]]
  Fbdy3=varargin[[2]]
  Fd=varargin[[3]]
  Fullformfunc(Fd) 
  if(!is.list(Fuv)){
    Fuv=list(Fuv)
  }
  FkL=list()
  for(jj in Looprange(1,length(Fuv))){
    tmp1=Op(jj,Fuv)
    tmp2=c()
    for(kk in Looprange(1,Length(tmp1))){
      tmp=Op(kk,tmp1)
      tmp2=Appendrow(tmp2,XYZfunc(tmp[1],tmp[2]))
    }
    FkL=c(FkL,list(tmp2))
  }
  Np=c(50,50)
  Eps1=0.01
  Eps2=0.05
  ctr=0
  for(jj in Looprange(4,Nargs)){
    tmp=varargin[[jj]]
    if((length(tmp)>1)||(tmp>1)){
      Np=tmp
      if(length(Np)==1){
        Np=c(Np,Np)
      }
    }else{
      ctr=ctr+1
      if(ctr==1){Eps1=tmp}
      if(ctr==2){Eps2=tmp}
    }
  }
  Out=Crv3onsfparadata(FkL,Fbdy3,Fd,Np,Eps1,Eps2)
  return(Out)
}

Wireparadata<- function(...){
  starttime=proc.time()
  varargin=list(...)
  Nargs=length(varargin)
  Fbdy3=varargin[[1]]
  Fd=varargin[[2]]
  FdL=Fullformfunc(Fd) 
  DuL=varargin[[3]]
  DvL=varargin[[4]]
  Np=c(50,50)
  Eps1=0.01
  Eps2=0.1
  ctr=0
  for(jj in Looprange(5,Nargs)){
    tmp=varargin[[jj]]
    if((length(tmp)>1)||(tmp>1)){
      Np=tmp
      if(length(Np)==1){
        Np=c(Np,Np)
      }
    }else{
      ctr=ctr+1
      if(ctr==1){Eps1=tmp}
      if(ctr==2){Eps2=tmp}
    }
  }
  if(!is.list(DuL)){ #181024
    tmp1=DuL
    DuL=list()
    for(jj in Looprange(1,tmp1)){
      tmp=jj*(URNG[2]-URNG[1])/(tmp1+1)
      DuL=c(DuL,list(tmp))
    }
  }
  if(!is.list(DvL)){ #181024
    tmp1=DvL
    DvL=list()
    for(jj in Looprange(1,tmp1)){
      tmp=jj*(VRNG[2]-VRNG[1])/(tmp1+1)
      DvL=c(DvL,list(tmp))
    }
  }
  Fuv=list()
  for(jj in Looprange(1,length(DuL))){
    tmp1=paste("c(",as.character(Op(jj,DuL)),",",VNAME,")",sep="")
    tmp2=paste("N=",as.character(Np[2]),sep="")
    tmp1=Paramplot(tmp1,Op(6,FdL),tmp2)
    tmp2=c()
    for(kk in Looprange(1,Length(tmp1))){
      tmp=Op(kk,tmp1)
      tmp2=Appendrow(tmp2,tmp)
    }
    Fuv=c(Fuv,list(tmp2))
  }
  FkL=list()
  for(jj in Looprange(1,length(Fuv))){
    tmp1=Op(jj,Fuv)
    tmp2=c()
    for(kk in Looprange(1,Length(tmp1))){
      tmp=Op(kk,tmp1)
      tmp2=Appendrow(tmp2,XYZfunc(tmp[1],tmp[2]))
    }
    FkL=c(FkL,list(tmp2))
  }
  Tmp1=proc.time()-starttime
  cat(UNAME,"direction started","\n")
  Out1=Crv3onsfparadata(FkL,Fbdy3,Fd,Np,Eps1,Eps2)
  WIREHIDDENDATA<<- CRVONSFHIDDENDATA
  Fuv=list()
  for(jj in Looprange(1,length(DvL))){
    tmp1=paste("c(",UNAME,",",as.character(Op(jj,DvL)),")",sep="")
    tmp2=paste("N=",as.character(Np[2]),sep="")
    tmp1=Paramplot(tmp1,Op(5,FdL),tmp2)
    tmp2=c()
    for(kk in Looprange(1,Length(tmp1))){
      tmp=Op(kk,tmp1)
      tmp2=Appendrow(tmp2,tmp)
    }
    Fuv=c(Fuv,list(tmp2))
  }
  FkL=list()
  for(jj in Looprange(1,length(Fuv))){
    tmp1=Op(jj,Fuv)
    tmp2=c()
    for(kk in Looprange(1,Length(tmp1))){
      tmp=Op(kk,tmp1)
      tmp2=Appendrow(tmp2,XYZfunc(tmp[1],tmp[2]))
    }
    FkL=c(FkL,list(tmp2))
  }
  cat(VNAME,"direction started","\n")
  Out2=Crv3onsfparadata(FkL,Fbdy3,Fd,Np,Eps1,Eps2)
  WIREHIDDENDATA<<- c(WIREHIDDENDATA, CRVONSFHIDDENDATA)
  Out=c(Out1,Out2)
  return(Out)
}

Intersectcrvsf<- function(...){
  # bdyeq is the equation of boundary f(x,y,z) =0
  starttime=proc.time()
  varargin=list(...)
  Nargs=length(varargin)
  crv=varargin[[1]]
  Fd=varargin[[2]]
  Fullformfunc(Fd) 
  bdyflg=0
  bdyeq=varargin[[Nargs]]
  if(is.character(bdyeq)){
    Nargs=Nargs-1
    bdyflg=1
    tmp=strsplit(bdyeq,"=",fixed=TRUE)
    tmp=tmp[[1]]
    if(length(tmp)>1){
      bdyeq=paste("(",tmp[1],")-(",tmp[2],")",sep="")
    }
    tmp=paste("bdyeq<- function(P){x=P[1];y=P[2];z=P[3];",bdyeq,"}",sep="")
    eval(parse(text=tmp))
  }
  Eps0=10^(-4)
  Np=c(50,50)
  Eps1=0.01
  Eps2=0.05
  ctr=0
  for(jj in Looprange(3,Nargs)){
    tmp=varargin[[jj]]
    if((length(tmp)>1)||(tmp>1)){
      Np=tmp
      if(length(Np)==1){
        Np=c(Np,Np)
      }
    }else{
      ctr=ctr+1
      if(ctr==1){Eps1=tmp}
      if(ctr==2){Eps2=tmp}
    }
  }
  PtL=list()
  for(I in Looprange(1,Length(crv)-1)){
    Pa=Op(I,crv)
    Pb=Op(I+1,crv)
    if(bdyflg==0){
      tmp=Meetpoints(Pa,Pb,1,Np,Eps1)
    }else{
      M1=bdyeq(Pa); M2=bdyeq(Pb)
      if(M1*M2>= 0){ #18.02.21
        if(((M1>0) && (M2>0)) || ((M1< 0) && (M2< 0))){
          next
        }
        if(M1==0){
          tmp=list(Pa)
        }else{
          tmp=list(Pb)
        }
      }else{
        while(Norm(Pb-Pa)>Eps0){
          if(bdyeq(Pa)==0){
            tmp=list(Pa)
            break
          }
          if(bdyeq(Pa)*bdyeq((Pa+Pb)/2)>0){
            Pa=(Pa+Pb)/2
          }else{
            Pb=(Pa+Pb)/2
          }
        }
        tmp=list(1/(M1-M2)*(-M2*Pa+M1*Pb))
      }
    }
    PtL=c(PtL,tmp)
  }
  Tmp=paste('Intersectcrvsf obtained  : Time =',sep='')
  Tmp1=proc.time()-starttime
  print(paste(Tmp,sprintf("%6.3f",Tmp1[1]),sep=''))
  return(PtL)
}

Sfcutparadata<- function(...){
  varargin=list(...)
  Nargs=length(varargin)
  CutD=varargin[[1]]
  Fbdy3=varargin[[2]]
  Fd=varargin[[3]]
  FdL=Fullformfunc(Fd)
  Np=c(50,50)
  Eps0=10^(-4)
  Eps1=0.01
  Eps2=0.05
  ctr=0
  for(jj in Looprange(4,Nargs)){
    Tmp=varargin[[jj]]
    if((length(Tmp)>1)||(Tmp>1)){
      Np=Tmp
      if(length(Np)==1){
        Np=c(Np,Np)
      }
    }else{
      ctr=ctr+1
      if(ctr==1){Eps1=Tmp}
      if(ctr==2){Eps2=Tmp}
    }
  }
  starttime=proc.time()
  Tmp=strsplit(CutD,'=')
  Tmp=Tmp[[1]]
  if(length(Tmp)==1){
    Eq=CutD
  }else{
    Eq=paste("(",Tmp[1],")-(",Tmp[2],")",sep="")
  }
  Eq=gsub("x","Xfunc(U,V)",Eq,fixed=TRUE)
  Eq=gsub("y","Yfunc(U,V)",Eq,fixed=TRUE)
  Eq=gsub("z","Zfunc(U,V)",Eq,fixed=TRUE)
  Tmp=paste("Eqfun<<- function(U,V){",Eq,"}",sep="") 
  eval(parse(text=Tmp))
  Du=(URNG[2]-URNG[1])/Np[1]
  Dv=(VRNG[2]-VRNG[1])/Np[2]
  Out=list();Out2=list()
  for(J in Looprange(1,Np[2])){
    Vval1=VRNG[1]+(J-1)*Dv
    Vval2=VRNG[1]+J*Dv
    Uval1=URNG[1]  #180305(3lines)
    Eval11=Eqfun(Uval1,Vval1)
    Eval12=Eqfun(Uval1,Vval2)
    for(I in Looprange(1,Np[1])){
      Uval2=URNG[1]+I*Du
      Eval21=Eqfun(Uval2,Vval1)
      Eval22=Eqfun(Uval2,Vval2)
      a1=Uval1;b1=Vval1;c1=Eval11
      a2=Uval2;b2=Vval1;c2=Eval21
      a3=Uval2;b3=Vval2;c3=Eval22
      a4=Uval1;b4=Vval2;c4=Eval12
      PL=matrix(c(a1,b1,a2,b2,a3,b3,a4,b4,a1,b1),ncol=2,byrow=TRUE)
      VL=c(c1,c2,c3,c4,c1)
      QL=c()
      for(K in 1:4){
        P1=Op(K,PL); P2=Op(K+1,PL)
        M1=Op(K,VL); M2=Op(K+1,VL)
        if(abs(M1)<Eps0){
          QL=Appendrow(QL,P1)
          next
        }
        if(abs(M2)<Eps0){
          next
        }
        if((M1> 0) && (M2> 0)){
          next
        }
        if((M1< 0) && (M2< 0)){
          next
        }
        Tmp=1/(M1-M2)*(-M2*P1+M1*P2)
        QL=Appendrow(QL,Tmp)
      }
      Uval1=Uval2 #180306(3lines)
      Eval11=Eval21
      Eval12=Eval22
      if(Length(QL)==2){
        q11=QL[1,1];q12=QL[1,2];q21=QL[2,1];q22=QL[2,2]
        if(((q11==a1)&&(q21==a1))||((q11==a3)&&(q21==a3))){
          if(((q21==b1)&&(q22==b1))||((q21==b3)&&(q22==b3))){
            Out2=c(Out2,list(QL))
          }else{
            Out=c(Out,list(QL))
          }
          next
        }
        if(((q12==b1)&&(q22==b1))||((q12==b3)&&(q22==b3))){
          if(((q11==a1)&&(q21==a1))||((q11==a3)&&(q21==a3))){
            Out2=c(Out2,list(QL))
          }else{
            Out=c(Out,list(QL))
          }
          next
        }
        Out=c(Out,list(QL))
      }
    }
  }
  while(length(Out2)>0){
    tmp1=Out2[[1]]
    Out=c(Out,list(tmp1))
    Out2=Out2[-1]
    rmv=c()
    for(jj in Looprange(1,length(Out2))){
      tmp2=Out2[[jj]]
      diff1=Norm(tmp2[1,]-tmp1[1,])+Norm(tmp2[2,]-tmp1[2,])
      diff2=Norm(tmp2[1,]-tmp1[2,])+Norm(tmp2[2,]-tmp1[1,])
      if((diff1<Eps0)||(diff2<Eps0)){
        rmv=c(rmv,jj)
        next
      }
    }
    Out2=Out2[-rmv]
  }
  Out=Connectseg(Out,Eps1)
  Tmp1=Out
  Out=list()
  for(ii in Looprange(1,length(Tmp1))){
    Tmp2=Op(ii,Tmp1)
    Tmp3=c()
    for(jj in Looprange(1,Length(Tmp2))){
      Tmp=Op(jj,Tmp2)
      Tmp=XYZfunc(Tmp[1],Tmp[2])
      if(Length(Tmp3)>0){
        if(Norm(Op(Length(Tmp3),Tmp3)-Tmp)<Eps1){next}
      }
      Tmp3=Appendrow(Tmp3,Tmp)
    }
    Out=c(Out,list(Tmp3))
  }
  Out=Crv3onsfparadata(Out,Fbdy3,Fd,Np,Eps1,Eps2)
  return(Out)
}
