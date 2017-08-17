// 09.10.03

function Out=Pointoncrv(varargin)
  Eps=10^(-4);
  T=varargin(1);
  Gdata=varargin(2);
  if size(T,1)>1
    Tmp=T; T=Gdata; Gdata=Tmp;
  end;
  PtL=Gdata;
  N=Trunc(T+Eps);
  S=max(T-N,0);
  if N==size(PtL,1)
    Out=PtL(N,:);
  else
    Pa=PtL(N,:);;
    Pb=PtL(N+1,:);
    Out=(1-S)*Pa+S*Pb;
  end
endfunction;

