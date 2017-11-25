// 08.10.24
// 08.10.25
// 08.10.26
// 09.12.31 (gsort)
// 13.10.22 ( __ added to varibles )
// 13.12.02  debugged

function PtL__=Meetpoints(PtA__,PtB__,Fd__,Uveq__,Np__,Eps__)
  Eps__0=10^(-4);
  Vec__=PtB__-PtA__;
  Out__=[];
  PtL__=[];
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
  Umin__=Urg__(1); UMax__=Urg__(2);
  Vmin__=Vrg__(1); VMax__=Vrg__(2);
  V1__='('+string(Vec__(1))+')';
  V2__='('+string(Vec__(2))+')';
  V3__='('+string(Vec__(3))+')';
  Xstr__='(('+Xf__+')-('+string(PtA__(1))+'))';
  Ystr__='(('+Yf__+')-('+string(PtA__(2))+'))';
  Zstr__='(('+Zf__+')-('+string(PtA__(3))+'))';
  Urg__str=Mixop(5,Fd__L);
  Vrg__str=Mixop(6,Fd__L);
  if abs(Vec__(2))>Eps__0 | abs(Vec__(1))>Eps__0
    Eq__=V2__+'*'+Xstr__+'-'+V1__+'*'+Ystr__;
  else
    Eq__=Xstr__;
  end;
  MS__=Mix(Eq__,Urg__str,Vrg__str,Np__);
  [Zval__,Xval__,Yval__]=Makevaltable(MS__);
  for J=1:length(Yval__)-1
    for I=1:length(Xval__)-1
      a1__=Xval__(I);b1__=Yval__(J);c1__=Zval__(J,I);
      a2__=Xval__(I+1);b2__=Yval__(J);c2__=Zval__(J,I+1);
      a3__=Xval__(I+1);b3__=Yval__(J+1);c3__=Zval__(J+1,I+1);
      a4__=Xval__(I);b4__=Yval__(J+1);c4__=Zval__(J+1,I);
      PL__=[a1__,b1__;a2__,b2__;a3__,b3__;a4__,b4__;a1__,b1__];
      VL__=[c1__,c2__,c3__,c4__,c1__];
      QL__=[];
      for K__=1:4
        P1__=PL__(K__,:); P2__=PL__(K__+1,:);
        M1__=VL__(K__); M2__=VL__(K__+1);
        if M1__>=Eps__0 & M2__>=Eps__0
          continue;
        end;
        if M1__<=-Eps__0 & M2__<=-Eps__0
          continue;
        end;
        if abs(M1__)<Eps__0
          Tmp__=P1__;
        elseif abs(M2__)<Eps__0
          continue;
        else
          Tmp__=1/(M1__-M2__)*(-M2__*P1__+M1__*P2__);
        end;
        QL__=[QL__;Tmp__];
      end;
      if size(QL__,1)==2
        Puv__1=QL__(1,:); Puv__2=QL__(2,:);
        Tmp__1=Puv__1(1);
        Tmp__2=Puv__1(2);
        Tmp__=strsubst(Xf__,Uname__,'('+string(Tmp__1)+')');
        Tmp__=strsubst(Tmp__,Vname__,'('+string(Tmp__2)+')');
        Xv__=evstr(Tmp__);
        Tmp__=strsubst(Yf__,Uname__,'('+string(Tmp__1)+')');
        Tmp__=strsubst(Tmp__,Vname__,'('+string(Tmp__2)+')');
        Yv__=evstr(Tmp__); // 13.12.02
        Tmp__=strsubst(Zf__,Uname__,'('+string(Tmp__1)+')');
        Tmp__=strsubst(Tmp__,Vname__,'('+string(Tmp__2)+')');
        Zv__=evstr(Tmp__);
        P1__=[Xv__,Yv__,Zv__];
        Tmp__1=Puv__2(1);
        Tmp__2=Puv__2(2);
        Tmp__=strsubst(Xf__,Uname__,'('+string(Tmp__1)+')');
        Tmp__=strsubst(Tmp__,Vname__,'('+string(Tmp__2)+')');
        Xv__=evstr(Tmp__);
        Tmp__=strsubst(Yf__,Uname__,'('+string(Tmp__1)+')');
        Tmp__=strsubst(Tmp__,Vname__,'('+string(Tmp__2)+')');
        Yv__=evstr(Tmp__);
        Tmp__=strsubst(Zf__,Uname__,'('+string(Tmp__1)+')');
        Tmp__=strsubst(Tmp__,Vname__,'('+string(Tmp__2)+')');
        Zv__=evstr(Tmp__);
        P2__=[Xv__,Yv__,Zv__];
        V1__=Vec__(1); V2__=Vec__(2); V3__=Vec__(3);
        if abs(V1__)>Eps__0
          M1__=PtA__(3)+V3__/V1__*(P1__(1)-PtA__(1))-P1__(3);
          M2__=PtA__(3)+V3__/V1__*(P2__(1)-PtA__(1))-P2__(3);
        elseif abs(V2__)>Eps__0
          M1__=PtA__(3)+V3__/V2__*(P1__(2)-PtA__(2))-P1__(3);
          M2__=PtA__(3)+V3__/V2__*(P2__(2)-PtA__(2))-P2__(3);
        else
          M1__=PtA__(2)-P1__(2);
          M2__=PtA__(2)-P2__(2);
        end;
        if M1__*M2__>=0
          if (M1__>Eps__0 & M2__>Eps__0) | (M1__<-Eps__0 & M2__<-Eps__0)
            continue;
          end;
          if abs(M1__)<=Eps__0
            Pt__=P1__; Ptuv__=Puv__1;
          else
            Pt__=P2__; Ptuv__=Puv__2;
          end;
        else  
          Pt__=1/(M1__-M2__)*(-M2__*P1__+M1__*P2__);
          Ptuv__=1/(M1__-M2__)*(-M2__*Puv__1+M1__*Puv__2);
        end;
        if type(Uveq__)==10
          Tmp__1='('+string(Ptuv__(1))+')';
          Tmp__2='('+string(Ptuv__(2))+')';
          Tmp__=strsubst(Uveq__,Uname__,Tmp__1);
          Tmp__=strsubst(Tmp__,Vname__,Tmp__2);
          Tmp__=evstr(Tmp__);
          if Tmp__<-Eps__0
            continue;
          end;
        end;
        Tmp__1=Naiseki(Pt__-PtA__,Vec__);
        Tmp__1=Tmp__1/norm(Vec__)^2;
        if Tmp__1>-Eps__0 & Tmp__1<1+Eps__0
          Out__=[Out__,Tmp__1];
        end;
      end;
    end;
  end;
  if length(Out__)>0
    Out__=gsort(Out__);
    Out__=Out__(length(Out__):-1:1);
    Tmp__=[Out__(1)];
    for I__=2:length(Out__)
      Tmp__1=(Out__(I__)-Tmp__(length(Tmp__)))*Vec__;
      Tmp__1=norm(Tmp__1);
      if Tmp__1>Eps__
        Tmp__=[Tmp__,Out__(I__)];
      end;
    end;
    Out__=Tmp__;
    for I__=1:length(Out__)
      Tmp__=PtA__+Out__(I__)*Vec__;
      PtL__=Mixadd(PtL__,Tmp__);
    end;
  end;
endfunction;
