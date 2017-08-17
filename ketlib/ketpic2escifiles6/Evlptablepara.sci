// 08.09.10
// 13.10.21 ( __ added to varibles )
// 17.05.21 Mdv, Ndv changed to division number

function [Zval__,Xval__,Yval__]=Evlptablepara(MS__)
  Nargs__=Mixlength(MS__);
  Eps__=10^(-3);
  Tmp__=Mixop(1,MS__);
  FdL__=Fullformfunc(Tmp__);
  Mdv=50;
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
        Tmp1__=Mixop(3,MS__);
        if type(Tmp1__)==1 & length(Tmp1__)==1
          Ndv__=Tmp1__;
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
  Du__=(U2__-U1__)/(Mdv__); //17.05.21
  Dv__=(V2__-V1__)/(Ndv__); //17.05.21
  Xyzstr__=[Mixop(2,FdL__),Mixop(3,FdL__),Mixop(4,FdL__)];
  I__=1;
  Zval__=[];
  for v__=V1__:Dv__:V2__
    v1__=v__-Eps__/2; v2__=v__+Eps__/2;
    ZuL__=[];
    for u__=U1__:Du__:U2__;
      u1__=u__-Eps__/2; u2__=u__+Eps__/2;
      Tmpv__=strsubst(Xyzstr__,Vname__,'v__');
      Tmp__=strsubst(Tmpv__,Uname__,'u1__');
      P1__=evstr(Tmp__);
      Tmp__=strsubst(Tmpv__,Uname__,'u2__');
      P2__=evstr(Tmp__);
      Tmp1__=Parapt(P1__);
      Tmp2__=Parapt(P2__);
      Dxu__=(Tmp2__(1)-Tmp1__(1))/Eps__;
      Dyu__=(Tmp2__(2)-Tmp1__(2))/Eps__;
      u1__=u__-Eps__/2; u2__=u__+Eps__/2;
      Tmpu__=strsubst(Xyzstr__,Uname__,'u__');
      Tmp__=strsubst(Tmpu__,Vname__,'v1__');
      P1__=evstr(Tmp__);
      Tmp__=strsubst(Tmpu__,Vname__,'v2__');
      P2__=evstr(Tmp__);
      Tmp1__=Parapt(P1__);
      Tmp2__=Parapt(P2__);
      Dxv__=(Tmp2__(1)-Tmp1__(1))/Eps__;
      Dyv__=(Tmp2__(2)-Tmp1__(2))/Eps__;
      Tmp__=Dxu__*Dyv__-Dxv__*Dyu__;
      ZuL__=[ZuL__,Tmp__];
    end;
    Zval__=[Zval__;ZuL__];
  end;
  Yval__=V1__:Dv__:V2__;
  Xval__=U1__:Du__:U2__;
endfunction;

