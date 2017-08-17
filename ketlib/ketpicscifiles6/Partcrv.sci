// 08.05.31
// 09.03.06

function Ans=Partcrv(A,B,PkL)
  Eps=10.0^(-3);
  if type(A)==1 & length(A)==1
    // new part from
    if A>B+Eps
      Npt=Numptcrv(PkL);
      Out1=Partcrv(A,Npt,PkL);
      Out2=Partcrv(1,B,PkL);
      Tmp=Ptstart(PkL)-Ptend(PkL);
      if norm(Tmp)<Eps
        Ans=Joincrvs(Out1,Out2);
      else
        Ans=Mix(Out1,Out2);
      end;
      return;
    end;
    // to here
    Is=ceil(A);
    Ie=floor(B);
    PL=[];
    if A<Is-Eps
      P=(Is-A)*PkL(Is-1,:)+(1-Is+A)*PkL(Is,:);
      PL=[P];
    end
    PL=[PL;PkL(Is:Ie,:)];
    if B>Ie+Eps
      P=(1-B+Ie)*PkL(Ie,:)+(B-Ie)*PkL(Ie+1,:);
      PL=[PL;P]
    end
    Ans=PL;
    return
  end;
  Tmp=Nearestpt(A,PkL);//
  Ta=Op(2,Tmp);//
  Tmp=Nearestpt(B,PkL);//
  Tb=Op(2,Tmp);//
  Ans=Partcrv(Ta,Tb,PkL);//
endfunction;

