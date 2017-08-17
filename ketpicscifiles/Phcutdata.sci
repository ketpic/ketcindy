// 08.08.17
// 08.09.16
// 10.01.02
// 13.10.21 ( __ added to varibles )
// 14.06.09 ( debugged -- the cause unknown )

function Out__=Phcutdata(VL__,FaceL__,PlaneD__)
  global PHCUTPOINTL
  Out__=[];
  EL__=[];
  Eps__=10^(-4);
  for I__=1:Mixlength(FaceL__)
    Face__=Mixop(I__,FaceL__);
    for J__=1:length(Face__)
      Nj__=J__+1;
      if J__==length(Face__)
        Nj__=1;
      end;
      N1__=Face__(J__); N2__=Face__(Nj__);
      Tmp__=[N1__,N2__];
      Flg__=0;
      for K__=1:Mixlength(EL__)
        Tmp1__=Mixop(K__,EL__);
        Tmp2__=[Tmp1__(2),Tmp1__(1)];
        if Tmp__==Tmp1__ | Tmp__==Tmp2__
          Flg__=1;
          break;
        end
      end;
      if Flg__==0
        EL__=Mixadd(EL__,Tmp__);
      end;
    end;
  end;
  Out0__=[];
  for I__=1:Mixlength(EL__)
    Tmp__=Mixop(I__,EL__);
    Tmp1__=Mixop(Tmp__(1),VL__);
    Tmp2__=Mixop(Tmp__(2),VL__);
    Out0__=Mixadd(Out0__, Spaceline([Tmp1__,Tmp2__]));
  end;
  if Mixtype(PlaneD__)~=1
    V1__=Mixop(1,PlaneD__);
    Tmp__=Mixop(2,PlaneD__);
    if length(Tmp__)>1
      d__=V1__(1)*Tmp__(1)+V1__(2)*Tmp__(2)+V1__(3)*Tmp__(3);
    else
      d__=Tmp__;
    end;
  elseif type(PlaneD__)==1
    V1__=PlaneD__(1:3);
    d__=PlaneD__(4);
  else
    K__=mtlb_findstr(PlaneD__,'=');
    if K__>0
      Tmp1__=part(PlaneD__,1:K__-1);
      Tmp2__=part(PlaneD__,K__+1:length(PlaneD__));
      PlaneD__=Tmp1__+'-('+Tmp2__+')';
    end;
    x=0; y=0; z=0;
    d__=-evstr(PlaneD__);
    x=1; y=0; z=0;
    Tmp1__=evstr(PlaneD__)+d__;
    x=0; y=1; z=0;
    Tmp2__=evstr(PlaneD__)+d__;
    x=0; y=0; z=1;
    Tmp3__=evstr(PlaneD__)+d__;
    V1__=[Tmp1__,Tmp2__,Tmp3__];
  end;
  if V1__==[0,0,0]
    Out__=Out0__;
    return;
  end;
  V3__=[1,0,0];
  Out1__=Rotate3data(Out0__,V1__,V3__);
//  x=poly(0,'X');
  Tmp2__=Rotate3pt([1,0,0],V3__,V1__);
  Tmp__=V1__(1)*Tmp2__(1)+V1__(2)*Tmp2__(2)+V1__(3)*Tmp2__(3);
  x0__=d__/Tmp__;
  t__=poly(0,'T');
  PtL__ =[];
  for I__=1:Mixlength(Out1__)
    Tmp__=Mixop(I__,Out1__);
    Tmp1__=Tmp__(1,:); Tmp2__=Tmp__(2,:);
    P__=Tmp1__+t__*(Tmp2__-Tmp1__);
    Tmp__=Tmp1__(1)+t__*(Tmp2__(1)-Tmp1__(1));
    if abs(coeff(Tmp__,1))<Eps__
      Tmp__=[];
    else
      Tmp1__=coeff(Tmp__,1);
      Tmp2__=x0__-coeff(Tmp__,0);
      Tmp__=[Tmp2__/Tmp1__];
    end;
    if length(Tmp__)>0
      Tmp__=Tmp__(1);
      if (Tmp__>-Eps__) & (Tmp__<1+Eps__)
        Tmp3__=horner(P__,Tmp__);
        Tmp3__=Rotate3pt(Tmp3__,V3__,V1__);
        if Tmp__<Eps__
          Tmp1__=Mixop(I__,EL__);
          Tmp1__=Tmp1__(1);
          Tmp4__=MixS([Tmp1__,Tmp1__],Tmp3__);
        else
          if Tmp__>1-Eps__ then
            Tmp1__=Mixop(I__,EL__);
            Tmp1__=Tmp1__(2);
            Tmp4__=MixS([Tmp1__,Tmp1__],Tmp3__);
          else
            Tmp4__=MixS(Mixop(I__,EL__),Tmp3__);
          end;
        end;
        Flg__=0;
        for J__=1:Mixlength(PtL__)
          Tmp__=Mixop(J__,PtL__);
          Tmp__=Mixop(2,Tmp__);
          if norm(Tmp3__-Tmp__)<Eps__ then
            Flg__=1;
            break;
          end;
        end;
        if Flg__==0
          PtL__=Mixadd(PtL__,Tmp4__);
        end;
      end;
    end;
  end;
  if Mixlength(PtL__)==0
    Out__=Out0__;
    return
  end;
  PL__=Mix(Mixop(1,PtL__));
  QL__=Mixsub(2:Mixlength(PtL__),PtL__);
  N__=Mixlength(QL__);
  for I__=2:N__+1
    Tmp1__=Mixop(Mixlength(PL__),PL__);
    Tmp1__=Mixop(1,Tmp1__);
    for J__=1:Mixlength(QL__)
      Tmp2__=Mixop(J__,QL__);
      Tmp2__=Mixop(1,Tmp2__);
      Flg__=0;
      for K__=1:Mixlength(FaceL__)
        Tmp3__=Mixop(K__,FaceL__);
        if Member(Tmp1__(1),Tmp3__) & ...
             Member(Tmp1__(2),Tmp3__) & ...
             Member(Tmp2__(1),Tmp3__) & ...
             Member(Tmp2__(2),Tmp3__)
          Flg__=1;
          break;
        end;
      end;
      if Flg__==1
        break;
      end;
    end;
    J__=min(J__, Mixlength(QL__));
    PL__=Mixadd(PL__,Mixop(J__,QL__));
    Tmp1__=Mixsub(1:J__-1,QL__);
    Tmp2__=Mixsub(J__+1:Mixlength(QL__),QL__);
    QL__=Mixjoin(Tmp1__,Tmp2__);
    if Mixlength(QL__)==0
      break;
    end;
  end;
  PHCUTPOINTL=PL__;
  Tmp__=[];
  for J__=1:Mixlength(PL__);
    Tmp1__=Mixop(J__,PL__);
    Tmp1__=Mixop(2,Tmp1__);
    Tmp__=Mixadd(Tmp__,Tmp1__);
  end;
  Tmp1__=Mixop(1,PL__);
  Tmp1__=Mixop(2,Tmp1__);
  Tmp__=Mixadd(Tmp__,Tmp1__);
  Out2__=Spaceline(Tmp__);
  Out__=Mixadd(Out0__,Out2__);
endfunction
