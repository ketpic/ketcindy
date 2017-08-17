// 08.09.21
// 13.11.01 ( __ added to varibles )

function [Zval__,Xval__,Yval__]=Evlptablepers(MS__)
  Nargs__=Mixlength(MS__);
  Eps__=10^(-3);
  Tmp__=Mixop(1,MS__);
  FdL__=Fullformfunc(Tmp__);
  Mdv__=50;
  Ndv__=50;
  if Nargs__>=2
    Tmp__=Mixop(2,MS__);
    if Mixtype(Tmp__)~=1 Tmp__=Mixop(1,Tmp__); end;
    if length(Tmp__)>1
      Mdv__=Tmp__(1,1);
      Ndv__=Tmp__(1,2);
    else
      Mdv__=Tmp__
      if Nargs__==2
        Ndv__=Mdv__
      else
        Tmp__1=Mixop(3,MS__);
        if type(Tmp__1)==1 & length(Tmp__1)==1
          Ndv__=Tmp__1;
        else
          Ndv__=Mdv__;
        end
      end
    end
  end;
  Tmp__=Mixop(5,FdL__);
  K__=mtlb_findstr(Tmp__,'=');
  Uname__=part(Tmp__,1:K__-1);
  Urange__=evstr(part(Tmp__,K__+1:length(Tmp__)));
  Tmp__=Mixop(6,FdL__);
  K__=mtlb_findstr(Tmp__,'=');
  Vname__=part(Tmp__,1:K__-1);
  Vrange__=evstr(part(Tmp__,K__+1:length(Tmp__)));
  U1__=Urange__(1); U2__=Urange__(2);
  V1__=Vrange__(1); V2__=Vrange__(2);
  Du__=(U2__-U1__)/(Mdv__-1);
  Dv__=(V2__-V1__)/(Ndv__-1);
  Xyzstr__=[Mixop(2,FdL__),Mixop(3,FdL__),Mixop(4,FdL__)];
  I__=1;
  Zval__=[];
  for v__=V1__:Dv__:V2__
    v__1=v__-Eps__/2; v__2=v__+Eps__/2;
    ZuL__=[];
    for u__=U1__:Du__:U2__;
      u__1=u__-Eps__/2; u__2=u__+Eps__/2;
      Tmp__v=strsubst(Xyzstr__,Vname__,'v__');
      Tmp__=strsubst(Tmp__v,Uname__,'u__1');
      P1__=evstr(Tmp__);
      Tmp__=strsubst(Tmp__v,Uname__,'u__2');
      P2__=evstr(Tmp__);
      Tmp__1=Perspt(P1__);
      Tmp__2=Perspt(P2__);
      Dxu__=(Tmp__2(1)-Tmp__1(1))/Eps__;
      Dyu__=(Tmp__2(2)-Tmp__1(2))/Eps__;
      u__1=u__-Eps__/2; u__2=u__+Eps__/2;
      Tmp__u=strsubst(Xyzstr__,Uname__,'u__');
      Tmp__=strsubst(Tmp__u,Vname__,'v__1');
      P1__=evstr(Tmp__);
      Tmp__=strsubst(Tmp__u,Vname__,'v__2');
      P2__=evstr(Tmp__);
      Tmp__1=Perspt(P1__);
      Tmp__2=Perspt(P2__);
      Dxv__=(Tmp__2(1)-Tmp__1(1))/Eps__;
      Dyv__=(Tmp__2(2)-Tmp__1(2))/Eps__;
      Tmp__=Dxu__*Dyv__-Dxv__*Dyu__;
      ZuL__=[ZuL__,Tmp__];
    end;
    Zval__=[Zval__;ZuL__];
  end;
  Yval__=V1__:Dv__:V2__;
  Xval__=U1__:Du__:U2__;
endfunction;
