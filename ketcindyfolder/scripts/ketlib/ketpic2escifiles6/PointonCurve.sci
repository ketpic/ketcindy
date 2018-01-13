// 08.05.30

function Out=PointonCurve(T,PtL)
  Eps=10^(-4);
  N=Trunc(T+Eps);
  S=max(T-N,0);
//  PtL=Plt;
  if N==size(PtL,1)
    Out=PtL(N,:);
  else
    Pa=PtL(N,:);;
    Pb=PtL(N+1,:);
    Out=(1-S)*Pa+S*Pb;
  end
endfunction
