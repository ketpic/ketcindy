// 08.09.16
// 08.10.11
// 08.10.15
// 10.02.16  Eps
// 13.10.22 ( __ added to varibles )

function OutL__=Crvonsfparadata(varargin)
  global PARTITIONPT HIDDENDATA CRVONSFHIDDENDATA
  Nargs__=length(varargin);
  Eps__0=10^(-4);
  Figuv__=varargin(1);
  Fbdy__=Projpara(varargin(2));
  Fd__=varargin(3); N__=4;
  Fd__L=Fullformfunc(Fd__);
  Fxy__=Mixop(1,Fd__L);
  Xf__=Mixop(2,Fd__L);
  Yf__=Mixop(3,Fd__L);
  Zf__=Mixop(4,Fd__L);
  Np__=[50,50];
  if Nargs__>=N__
    Np__=varargin(N__); N__=N__+1;
    if type(Np__)==1 & length(Np__)==1
      Np__=[Np__,Np__];
    end;
  end;
  Eps__=[0.05,1];  //
  if Nargs__>=N__
    Eps__=varargin(N__);
  end;
  if length(Eps__)==1
    Eps__=[Eps__,1];
  end;
  Eps__2=0.2;
  if Nargs__>=N__+1
    Eps__2=varargin(N__+1);
  end;
  Tmp__=Mixop(2,Fd__);
  K__=mtlb_findstr(Tmp__,'=');
  Xname__=part(Tmp__,1:K__-1);
  Tmp__=Mixop(3,Fd__);
  K__=mtlb_findstr(Tmp__,'=');
  Yname__=part(Tmp__,1:K__-1);
  Tmp__=Mixop(5,Fd__L);
  K__=mtlb_findstr(Tmp__,'=');
  Uname__=part(Tmp__,1:K__-1);
  Urg__=evstr(part(Tmp__,K__+1:length(Tmp__)));
  Tmp__=Mixop(6,Fd__L);
  K__=mtlb_findstr(Tmp__,'=');
  Vname__=part(Tmp__,1:K__-1);
  Vrg__=evstr(part(Tmp__,K__+1:length(Tmp__)));    
  Fbdxy__=Makexybdy(Fd__,Np__);
  Fbdy__uv=Mixop(8,Fd__L);
  if Fbdy__uv==[]    
    Fbdy__uv=Mix(Framedata(Urg__,Vrg__));
  end;
  FigL__=Clipindomain(Figuv__,Fbdy__uv);
  CRVONSFHIDDENDATA=[];
  OutL__=[];
  for N__=1:Mixlength(FigL__)
    PtL__=Mixop(N__,FigL__);
    Tmp__=[];
    for I__=1:size(PtL__,1)
      P__=PtL__(I__,:);
      Tmp__1=strsubst(Xf__,Uname__,'('+string(P__(1))+')');
      Tmp__1=strsubst(Tmp__1,Vname__,'('+string(P__(2))+')');
      Tmp__1=evstr(Tmp__1);
      Tmp__2=strsubst(Yf__,Uname__,'('+string(P__(1))+')');
      Tmp__2=strsubst(Tmp__2,Vname__,'('+string(P__(2))+')');
      Tmp__2=evstr(Tmp__2);
      Tmp__3=strsubst(Zf__,Uname__,'('+string(P__(1))+')');
      Tmp__3=strsubst(Tmp__3,Vname__,'('+string(P__(2))+')');
      Tmp__3=evstr(Tmp__3);
      Tmp__=[Tmp__,[Tmp__1,Tmp__2,Tmp__3]];
    end;
    Fk__=Spaceline(Tmp__);
    Par__=Partitionseg(Projpara(Fk__),Fbdy__,Eps__(1),Eps__2); //
    if Fxy__=='p'
      Tmp__=Nohiddenpara2(Par__,Fk__,Fd__,1,Np__,Eps__);
    else
      Tmp__1=Mix(Fxy__,Fbdxy__,Xname__,Yname__);
      Tmp__=Nohiddenpara(Par__,Fk__,Tmp__1);
    end;
    if Tmp__~=[]
      OutL__=Mixjoin(OutL__,Tmp__);
    end;
    if HIDDENDATA~=[]
      CRVONSFHIDDENDATA=Mixjoin(CRVONSFHIDDENDATA,HIDDENDATA);
    end;
  end;
endfunction;
