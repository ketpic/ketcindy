// 08.09.09
// 08.09.19
// 08.09.20
// 08.09.24
// 08.10.09
// 08.10.10
// 13.10.21 ( __ added to varibles )

function EkL__=Sfcutdata(varargin)
  Nargs__=length(varargin);
  Fd__=varargin(1);
  CutD__=varargin(2);
  Np__=[50,50];
  if Nargs__>=3
    Tmp__=varargin(3);
    if type(Tmp__)==1 & length(Tmp__)==1
      Np__=[Tmp__,Tmp__];
    end;
  end;
  Tmp__=Mixop(2,Fd__);
  K__=mtlb_findstr(Tmp__,'=');
  Xname__=part(Tmp__,1:K__-1);
  Tmp__=Mixop(3,Fd__);
  K__=mtlb_findstr(Tmp__,'=');
  Yname__=part(Tmp__,1:K__-1);
  Tmp__=Mixop(1,Fd__);
  K__=mtlb_findstr(Tmp__,'=');
  if K__~=[]
    Zname__=part(Tmp__,1:K__-1);
  else
    Tmp__=Mixop(4,Fd__);
    K__=mtlb_findstr(Tmp__,'=');
    Zname__=part(Tmp__,1:K__-1);
  end;
  Fd__L=Fullformfunc(Fd__);
  Xf__=Mixop(2,Fd__L);
  Yf__=Mixop(3,Fd__L);
  Zf__=Mixop(4,Fd__L);
  Tmp__=Mixop(5,Fd__L);
  K__=mtlb_findstr(Tmp__,'=');
  Uname__=part(Tmp__,1:K__-1);
  Urg__=evstr(part(Tmp__,K__+1:length(Tmp__)));
  Tmp__=Mixop(6,Fd__L);
  K__=mtlb_findstr(Tmp__,'=');
  Vname__=part(Tmp__,1:K__-1);
  Vrg__=evstr(part(Tmp__,K__+1:length(Tmp__)));
  Umin__=Urg__(1); Umax=Urg__(2);
  Vmin__=Vrg__(1); Vmax=Vrg__(2);
  if Mixtype(CutD__)~=1
    V1__=Mixop(1,CutD__);
    Tmp__=Mixop(2,CutD__);
    if length(Tmp__)>1
      D__=V1__(1)*Tmp__(1)+V1__(2)*Tmp__(2)+V1__(3)*Tmp__(3);
    else
      D__=Tmp__;
    end;
    Tmp__=string(V1__(1))+'*'+Xname__+'+';
    Tmp__=Tmp__+string(V1__(2))+'*'+Yname__+'+';
    Tmp__=Tmp__+string(V1__(3))+'*'+Zname__+'-';
    Eq__=Tmp__+string(D__);
  elseif type(CutD__)==1
    V1__=CutD__(1:3);
    D__=CutD__(4);
    Tmp__=string(V1__(1))+'*'+Xname__+'+';
    Tmp__=Tmp__+string(V1__(2))+'*'+Yname__+'+';
    Tmp__=Tmp__+string(V1__(3))+'*'+Zname__+'+';
    Eq__=Tmp__+string(D__);
  else
    K__=mtlb_findstr(CutD__,'=');
    if K__>0
      Tmp__1=part(CutD__,1:K__-1);
      Tmp__2=part(CutD__,K__+1:length(CutD__));
      Eq__=Tmp__1+'-('+Tmp__2+')';
    else
      Eq__=CutD__;
    end;
  end;
  Tmp__=strsubst(Eq__,Xname__,'('+Xf__+')');
  Tmp__=strsubst(Tmp__,Yname__,'('+Yf__+')');
  Uveq__=strsubst(Tmp__,Zname__,'('+Zf__+')');
  Tmp__1=Mixop(5,Fd__L);
  Tmp__2=Mixop(6,Fd__L);
  CutuvL__=Implicitplot(Uveq__,Tmp__1,Tmp__2,Np__);
  EkL__=[];
  for I__=1:Mixlength(CutuvL__)
    Out__1=Mixop(I__,CutuvL__);
    Out__2=[];
    for J__=1:size(Out__1,1)
      Tmp__1=Out__1(J__,1);
      Tmp__2=Out__1(J__,2); 
      Tmp__=strsubst(Xf__,Uname__,'('+string(Tmp__1)+')');
      Tmp__=strsubst(Tmp__,Vname__,'('+string(Tmp__2)+')');
      Xv__=evstr(Tmp__);
      Tmp__=strsubst(Yf__,Uname__,'('+string(Tmp__1)+')');
      Tmp__=strsubst(Tmp__,Vname__,'('+string(Tmp__2)+')');
      Yv__=evstr(Tmp__);
      Tmp__=strsubst(Zf__,Uname__,'('+string(Tmp__1)+')');
      Tmp__=strsubst(Tmp__,Vname__,'('+string(Tmp__2)+')');
      Zv__=evstr(Tmp__);
      Out__2=[Out__2,[Xv__,Yv__,Zv__]];
    end;
    Tmp__=Spaceline(Out__2);
    EkL__=Mixadd(EkL__,Tmp__);
  end;
endfunction;
