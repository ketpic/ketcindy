// 08.10.10
// 08.10.12
// 08.10.15
// 08.10.26
// 09.06.05
// 09.09.10
// 09.10.12  debug
// 09.11.07  debugged
// 10.02.16 Eps__
// 13.10.22 ( __ added to variables )

function Out__=PthiddenQ(PtA__,Vec__,Fd__,Uveq__,Np__,EPS__)
//     Out__=1 : hidden
//     SL__ : List of segments near PtA__+Vec__
  Eps__0=10^(-4)*(Xmax()-Xmin())/10;
  Eps__=EPS__(1)*(Xmax()-Xmin())/10;   //
  Out__=0;
  Vec__1=1/norm(Vec__)*Vec__;
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
  FdL__=Fullformfunc(Fd__);
  Xf__=Mixop(2,FdL__);
  Yf__=Mixop(3,FdL__);
  Zf__=Mixop(4,FdL__);
  Tmp__=Mixop(5,FdL__);
  K__=mtlb_findstr(Tmp__,'=');
  Uname__=part(Tmp__,1:K__-1);
  Urg__=evstr(part(Tmp__,K__+1:length(Tmp__)));
  Tmp__=Mixop(6,FdL__);
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
  Urg__str=Mixop(5,FdL__);
  Vrg__str=Mixop(6,FdL__);
   if abs(Vec__(2))>Eps__0 | abs(Vec__(1))>Eps__0
    Eq__=V2__+'*'+Xstr__+'-'+V1__+'*'+Ystr__;
  else
    Eq__=Xstr__;
  end;
  MS__=Mix(Eq__,Urg__str,Vrg__str,Np__);
  [Zval__,Xval__,Yval__]=Makevaltable(MS__);
  SL__=[];
  for J__=1:length(Yval__)-1
    for I__=1:length(Xval__)-1
      a1__=Xval__(I__);b1__=Yval__(J__);c1__=Zval__(J__,I__);
      a2__=Xval__(I__+1);b2__=Yval__(J__);c2__=Zval__(J__,I__+1);
      a3__=Xval__(I__+1);b3__=Yval__(J__+1);c3__=Zval__(J__+1,I__+1);
      a4__=Xval__(I__);b4__=Yval__(J__+1);c4__=Zval__(J__+1,I__);
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
        Puv1__=QL__(1,:); Puv2=QL__(2,:);
        Tmp__1=Puv1__(1);
        Tmp__2=Puv1__(2);
        Tmp__=strsubst(Xf__,Uname__,'('+string(Tmp__1)+')');
        Tmp__=strsubst(Tmp__,Vname__,'('+string(Tmp__2)+')');
        Xv__=evstr(Tmp__);
        Tmp__=strsubst(Yf__,Uname__,'('+string(Tmp__1)+')');
        Tmp__=strsubst(Tmp__,Vname__,'('+string(Tmp__2)+')');
        Yv__=evstr(Tmp__);
        Tmp__=strsubst(Zf__,Uname__,'('+string(Tmp__1)+')');
        Tmp__=strsubst(Tmp__,Vname__,'('+string(Tmp__2)+')');
        Zv__=evstr(Tmp__);
        P1__=[Xv__,Yv__,Zv__];
        Tmp__1=Puv2(1);
        Tmp__2=Puv2(2);
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
        if norm(P1__-P2__)<Eps__0    // 09.11.07
          continue;
        end;                   //
        Tmp__1=norm(P1__-PtA__);
        Tmp__2=Naiseki(P1__-PtA__,Vec__1);
        Tmp__3=sqrt(abs(Tmp__1^2-Tmp__2^2));
        Tmp__4=norm(P2__-PtA__);
        Tmp__5=Naiseki(P2__-PtA__,Vec__1);
        Tmp__6=sqrt(abs(Tmp__4^2-Tmp__5^2));
        if Tmp__2<Tmp__5
          Tmp__=P1__; P1__=P2__; P2__=Tmp__;
          Tmp__=Tmp__2; Tmp__2=Tmp__5; Tmp__5=Tmp__;
          Tmp__=Tmp__3; Tmp__3=Tmp__6; Tmp__6=Tmp__;
        end;
        if Tmp__3<EPS__(2)*Eps__ & Tmp__6<EPS__(2)*Eps__   //
          if Tmp__2>-Eps__0
            if Tmp__5<-Eps__0
              SL__=[SL__;P1__,P2__,-1];
            else
              SL__=[SL__;P1__,P2__,1];
            end;
          end;
        end;
        V1__=Vec__1(1); V2__=Vec__1(2); V3__=Vec__1(3);
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
            Pt__=P1__; Ptuv__=Puv1__;
          else
            Pt__=P2__; Ptuv__=Puv2;
          end;
        else  
          Pt__=1/(M1__-M2__)*(-M2__*P1__+M1__*P2__);
          Ptuv__=1/(M1__-M2__)*(-M2__*Puv1__+M1__*Puv2);
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
        Tmp__1=Dotprod(Pt__-PtA__,Vec__1);
        Tmp__2=abs(Tmp__1);
        Tmp__3=Dotprod(P1__-P2__,Vec__1);
        Tmp__4=norm(P1__-P2__);
        Tmp__6=Tmp__3/Tmp__4;
        if Tmp__1>Eps__0
          if abs(Tmp__6)>0.75 // from
            PtL__=[PtL__;Pt__,P2__];
            continue;
          end;              // upto
          if Tmp__2>Eps__
            Out__=1;
            return
          end;
          if Tmp__2<2*Eps__
            continue;
          end;
        end;
      end;
    end;
  end;
  if PtL__==[]
    return;
  end;
  for I__=1:size(SL__,1)
    P2__=SL__(I__,4:6);
    Flg__=0;
    for J__=1:size(SL__,1)
      P=SL__(J__,1:3);
      if norm(P-P2__)<Eps__0
        SL__(I__,7)=J__;
        Flg__=1;
        break;
      end;
    end;
    if Flg__==0 & SL__(I__,7)>0
      SL__(I__,7)=-2;
    end;
  end;
  for I__=1:size(PtL__,1)
    P__=PtL__(I__,4:6);
    Flg__=0;
    for J__=1:size(SL__,1)
      P1__=SL__(J__,1:3);
      if norm(P1__-P__)<Eps__0
        Flg__=1;
        break;
      end;
    end;
    if Flg__==0
      Pt__=PtL__(I__,1:3);                // from
      Tmp__0=norm(P__-Pt__);
      Tmp__1=abs(Dotprod(P__-Pt__,Vec__1));
      Tmp__2=sqrt(abs(Tmp__0^2-Tmp__1^2));
      Tmp__3=Tmp__2*norm(Pt__-PtA__)/Tmp__0;   // should to be changed 10.02.16
      if Tmp__3>Eps__/5
        Out__=1;
        return;
      else
        continue;
      end;                          // upto
    end;
    Nxt__=SL__(J__,7);
    while Nxt__>0
      P__=SL__(Nxt__,4:6);
      Nxt__=SL__(Nxt__,7);
    end;
    if Nxt__==-2
      Out__=1;
      return;
    else
      Out__=0;
    end;
  end;
endfunction;

