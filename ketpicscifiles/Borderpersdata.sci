// 08.09.21
// 08.10.10
// 08.10.11
// 08.10.28
// 09.03.09
// 09.05.27
// 09.06.03
// 10.02.16 Eps__
// 13.11.01 ( __ added to varibles )

function FsL__=Borderpersdata(varargin)
  global BORDERPT OTHERPARTITION HIDDENDATA BORDERHIDDENDATA ...
         PARTITIONPT
  Nargs__=length(varargin);
  FkL__=varargin(1);
  Fd__=varargin(2); N=3;
  FdL__=Fullformfunc(Fd__);
  Fxy__=Mixop(1,FdL__);
  Tmp__1=Mixop(2,FdL__);
  Tmp__2=Mixop(3,FdL__);
  Tmp__3=Mixop(4,FdL__);
  Xyzstr__=[Tmp__1,Tmp__2,Tmp__3];
  DrwS__=Mixop(7,FdL__);
  Tmp__=Mixop(5,FdL__);
  K__=mtlb_findstr(Tmp__,'=');
  Uname__=part(Tmp__,1:K__-1);
  Urg__=evstr(part(Tmp__,K__+1:length(Tmp__)));
  Tmp__=Mixop(6,FdL__);
  K__=mtlb_findstr(Tmp__,'=');
  Vname__=part(Tmp__,1:K__-1);
  Vrg__=evstr(part(Tmp__,K__+1:length(Tmp__)));
  Np__=[50,50];
  if Nargs__>=3
    Np__=varargin(3); N=4;
    if type(Np__)==1 & length(Np__)==1
      Np__=[Np__,Np__];
    end;
  end;
  Eps__=0.05;
  Eps__=[0.05,1];  //
  if Nargs__>=N Eps__=varargin(N); end;
  Eps__2=0.2;
  if Nargs__>=N+1 Eps__2=varargin(N+1); end;
  Umin__=Urg__(1); Umax__=Urg__(2);
  Vmin__=Vrg__(1); Vmax__=Vrg__(2);
  EkL__=[];
  Tmp__=mtlb_findstr(DrwS__,'e');
  if length(Tmp__)~=0
    Tmp__1=strsubst(Xyzstr__,Uname__,'('+string(Umax__)+')');
    Tmp__2=Mixop(6,FdL__);
    Tmp__3='N='+string(Np__(2));
    Tmp__=Spacecurve(Tmp__1,Tmp__2,Tmp__3);
    EkL__=Mixadd(EkL__,Tmp__);
  end;
  Tmp__=mtlb_findstr(DrwS__,'n');
  if length(Tmp__)~=0
    Tmp__1=strsubst(Xyzstr__,Vname__,'('+string(Vmax__)+')');
    Tmp__2=Mixop(5,FdL__);
    Tmp__3='N='+string(Np__(1));
    Tmp__=Spacecurve(Tmp__1,Tmp__2,Tmp__3);
    EkL__=Mixadd(EkL__,Tmp__);
  end;
  Tmp__=mtlb_findstr(DrwS__,'w');
  if length(Tmp__)~=0
    Tmp__1=strsubst(Xyzstr__,Uname__,'('+string(Umin__)+')');
    Tmp__2=Mixop(6,FdL__);
    Tmp__3='N='+string(Np__(2));
    Tmp__=Spacecurve(Tmp__1,Tmp__2,Tmp__3);
    EkL__=Mixadd(EkL__,Tmp__);
  end;
  Tmp__=mtlb_findstr(DrwS__,'s');
  if length(Tmp__)~=0
    Tmp__1=strsubst(Xyzstr__,Vname__,'('+string(Vmin__)+')');
    Tmp__2=Mixop(5,FdL__);
    Tmp__3='N='+string(Np__(1));
    Tmp__=Spacecurve(Tmp__1,Tmp__2,Tmp__3);
    EkL__=Mixadd(EkL__,Tmp__);
  end;
  if Mixlength(EkL__)>0
    FkL__=Mixjoin(FkL__,EkL__);
  end;
  Fall__=Projpers(FkL__);
  if Mixtype(Fall__)==1
    Fall__=Mix(Fall__);
  end;
  Fbdxy__=Makexybdy(Fd__,Np__);
  Tmp__=Mixop(2,Fd__);
  K__=mtlb_findstr(Tmp__,'=');
  Xname__=part(Tmp__,1:K__-1);
  Tmp__=Mixop(3,Fd__);
  K__=mtlb_findstr(Tmp__,'=');
  Yname__=part(Tmp__,1:K__-1);
  BORDERPT=[];
  Tmp__=[];
  for I__=1:Mixlength(Fall__)
    Tmp__=Mixadd(Tmp__,[]);
  end;
  OTHERPARTITION=Tmp__;
  FsL__=[];
  BORDERHIDDENDATA=[];
  for I__=1:Mixlength(Fall__)
    Tmp__=Mixop(I__,FkL__);
    Tmp__=Projpers(Tmp__);
    Par__=Partitionseg(Tmp__,Fall__,Eps__(1),Eps__2,I__);
    if Mixlength(PARTITIONPT)>2
      Tmp__=Mixlength(PARTITIONPT)-1;
      Tmp__1=Mixsub(2:Tmp__,PARTITIONPT);
      BORDERPT=Mixjoin(BORDERPT,Tmp__1);
    end;
    Tmp__1=Mixop(I__,FkL__);
    Tmp__=Nohiddenpers2(Par__,Tmp__1,Fd__,1,Np__,Eps__);
    if Mixlength(HIDDENDATA)>0
      BORDERHIDDENDATA=Mixjoin(BORDERHIDDENDATA,HIDDENDATA);
    end;
    if Mixlength(Tmp__)>0
      FsL__=Mixjoin(FsL__,Tmp__);
    end;
  end;
endfunction;

