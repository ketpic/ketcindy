// 08.05.30

function Out=ParamonCurve(P,N,PtL)
//  PtL=Plt;
  if N==size(PtL,1)
    Out=N;
  else
    Pa=PtL(N,:);
    Pb=PtL(N+1,:);
    V=Pb-Pa;
    W=P-Pa;
    D2=V(1)^2+V(2)^2;
    S=(V(1)*W(1)+V(2)*W(2))/D2;
    S=min(max(S,0),1);
    Out=N+S;
  end
endfunction

