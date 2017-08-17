// 08.08.16
// 08.10.10
// 13.10.21 ( __ added to varibles )

function PL__=Sf3data(varargin)
  Nargs__=length(varargin);
  FdL__=Fullformfunc(varargin(1));
  F__=Mixop(1,FdL__);
  Xf__=Mixop(2,FdL__);
  Yf__=Mixop(3,FdL__);
  Zf__=Mixop(4,FdL__);
  Urg__=Mixop(5,FdL__);
  Vrg__=Mixop(6,FdL__);
  K__=mtlb_findstr(Urg__,'=');
  U__=part(Urg__,1:K__-1);
  Tmp__=part(Urg__,K__+1:length(Urg__));
  Tmp__=evstr(Tmp__);
  Umin__=Tmp__(1); Umax__=Tmp__(2);
  K__=mtlb_findstr(Vrg__,'=');
  V__=part(Vrg__,1:K__-1);
  Tmp__=part(Vrg__,K__+1:length(Vrg__));
  Tmp__=evstr(Tmp__);
  Vmin__=Tmp__(1); Vmax__=Tmp__(2);
  Ndu__=25 ; Ndv__=25; Np__=[50,50];
  if Nargs__>=3
    Ndu__=varargin(2);
    Ndv__=varargin(3);
  end;
  if Nargs__>=4
    Np__=varargin(4);
    if type(Np__)==1 & length(Np__)==1
      Np__=[Np__,Np__];
    end;
  end;
  Du__=(Umax__-Umin__)/Ndu__;
  Dv__=(Vmax__-Vmin__)/Ndv__;
  PL__ = [];
  for I__=0:Ndu__
    U0__ ='('+string(Umin__+I__*Du__)+')';
    Tmp__=strsubst(Xf__,U__,U0__);
    Tmp1__=strsubst(Tmp__,V__,'t');
    Tmp__=strsubst(Yf__,U__,U0__);
    Tmp2__=strsubst(Tmp__,V__,'t');
    Tmp__=strsubst(Zf__,U__,U0__);
    Tmp3__=strsubst(Tmp__,V__,'t');
    Tmp__='['+Tmp1__+','+Tmp2__+','+Tmp3__+']';
    PD__=Spacecurve(Tmp__,'t=[Vmin__,Vmax__]','N='+string(Np__(2)));
    PL__=Mixadd(PL__,PD__);
  end;
  for J__=0:Ndv__
    V0__='('+string(Vmin__+J__*Dv__)+')';
    Tmp__=strsubst(Xf__,V__,V0__);
    Tmp1__=strsubst(Tmp__,U__,'t');
    Tmp__=strsubst(Yf__,V__,V0__);
    Tmp2__=strsubst(Tmp__,U__,'t');
    Tmp__=strsubst(Zf__,V__,V0__);
    Tmp3__=strsubst(Tmp__,U__,'t');
    Tmp__='['+Tmp1__+','+Tmp2__+','+Tmp3__+']';
    PD__=Spacecurve(Tmp__,'t=[Umin__,Umax__]','N='+string(Np__(1)));
    PL__=Mixadd(PL__,PD__);
  end;
endfunction;
