// 08.09.19
// 08.10.15
// 08.12.21

function AnsL=MakecutbycrvL(Out1,CutuvL,Uveqstr,Uname,Vname,Eps)
  if CutuvL==[]
    if Mixtype(Out1)==1
      AnsL=Mix(Out1);
    else
      AnsL=Out1;
    end;
    return;
  end;
  AnsL=[];
  ParL=Partitionseg(Out1,CutuvL,Eps);
  Flg=0;
  for J=1:length(ParL)-1
    Tmp=(ParL(J)+ParL(J+1))*0.5;
    Tmp=PointonCurve(Tmp,Out1);
    Tmp1='('+string(Tmp(1))+')';
    Tmp2='('+string(Tmp(2))+')';
    Tmp=strsubst(Uveqstr,Uname,Tmp1);
    Tmp=strsubst(Tmp,Vname,Tmp2);
    Tmp=evstr(Tmp);
    if Tmp>0
      if Flg==0
        P1=ParL(J);
      end;
      Flg=1
    else
      if Flg==1
        P2=ParL(J);
        Tmp=Partcrv(P1,P2,Out1);
        AnsL=Mixadd(AnsL,Tmp);
      end;
      Flg=0
    end;
  end;
  if Flg==1
    P2=ParL(length(ParL));
    Tmp=Partcrv(P1,P2,Out1);
    AnsL=Mixadd(AnsL,Tmp);
  end;
endfunction;

