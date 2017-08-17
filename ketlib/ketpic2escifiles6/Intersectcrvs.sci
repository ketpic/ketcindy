//  08.05.18 Koshikawa
// 08.05.19 Changed
// 08.06.03
// 09.11.12
// 09.11.14  debug

function PL=Intersectcrvs(varargin)
  Nargs=length(varargin);
  Eps=10^(-4);
  Tmp=varargin(Nargs);
  if type(Tmp)==1 & length(Tmp)==1
    Eps=Tmp;
  end
  G1=varargin(1);
  if Mixtype(G1)==1
    G1=list(G1);
  end;
  G2=varargin(2);
  if Mixtype(G2)==1
    G2=list(G2);  //
  end;
  PL=list();
  for N=1:length(G1)
    for M=1:length(G2)
      KL=IntersectcrvsPp(G1(N),G2(M),Eps);
      for I=1:length(KL)
        Tmp=KL(I);;
        P=Tmp(1);
        PL($+1)=P;
      end;
    end;
  end;
endfunction

