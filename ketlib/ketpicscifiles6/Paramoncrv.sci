// 09.10.03

function Out=Paramoncrv(varargin)
  Eps=10^(-8);
  Nargs=length(varargin);
  P=varargin(1);
  Gdata=varargin(Nargs);
  if size(P,1)>1
    Tmp=P; P=Gdata; Gdata=Tmp;
  end;
  if Nargs==2
    Tmp=Nearestpt(P,Gdata);
    Out=Mixop(2,Tmp);
    return;
  end;
  N=varargin(2);
  PtL=Gdata;
  if N==size(PtL,1)
    Out=N;
  else
    Pa=PtL(N,:);
    Pb=PtL(N+1,:);
    V=Pb-Pa;
    W=P-Pa;
    D2=norm(V)^2;
    if D2<Eps
      Out=0;
      return;
    end;
    S=Dotprod(V,W)/D2;
    S=min(max(S,0),1);
    Out=N+S;
  end
endfunction

