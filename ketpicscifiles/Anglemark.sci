// 08.06.05

function Out=Anglemark(varargin) 
  Nargs=length(varargin);
  Eps=10^(-3);
  PA=varargin(1); PB=varargin(2); PC=varargin(3);
  r = 0.5;
  if Nargs>=4
    r = varargin(4)*r;  
  end
  Cir=Circledata(PB,r);
  Tmp=IntersectcrvsPp(Cir,Listplot(PA,PB));
  P1=Op(2,Op(1,Tmp));
  Tmp=IntersectcrvsPp(Cir,Listplot(PC,PB));
  P2=Op(2,Mixop(1,Tmp));
  if abs(P1-P2)<Eps
    Out=[];
    return;
  end
  if P1<P2-Eps
    Out=Partcrv(P1,P2,Cir);
  else  
    Tmp=Numptcrv(Cir);
    Tmp1=Partcrv(P1,Tmp,Cir);
    Tmp2=Partcrv(1,P2,Cir);
    Out=Joincrvs(Tmp1,Tmp2);
  end
endfunction
