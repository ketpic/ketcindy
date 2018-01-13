// 08.09.13
// 09.03.06

function PL=Partcrv3(T1,T2,Fk)
  Eps=10^(-4);
//  Tmp=Mixop(1,Fk);
  // new part from
  if T1>T2+Eps
    Npt=size(Fk,1);
    Out1=Partcrv3(T1,Npt,Fk);
    Out2=Partcrv3(1,T2,Fk);
    Tmp=Fk(1,:)-Fk(Npt,:);
    if norm(Tmp)<Eps
      PL=Joincrvs(Out1,Out2);
    else
      PL=Mix(Out1,Out2);
    end;
    return;
  end;
  // to here
  Is=ceil(T1);
  Ie=floor(T2);
  PL=[];
  if T1<Is-Eps
    P=(Is-T1)*Fk(Is-1,:)+(1-Is+T1)*Fk(Is,:);
    PL=[P]
  end;
  PL=[PL;Fk(Is:Ie,:)];
  if T2>Ie+Eps
    P=(1-T2+Ie)*Fk(Ie,:)+(T2-Ie)*Fk(Ie+1,:);
    PL=[PL;P]
  end;
endfunction;

