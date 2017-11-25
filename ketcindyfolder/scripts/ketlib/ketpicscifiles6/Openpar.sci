// 08.05.31

function Openpar(varargin)
  global Wfile FID;
  Nargs=length(varargin);
  Tmp=varargin(1);
  Tmp1=Strop(1,Tmp);
  if Tmp1=='\' | Tmp1=='¥' 
    Namestr=Tmp;
    N=2;
  else
    Namestr='\tmp';
    N=1;
  end
  Habastr=varargin(N);
  if Nargs>N
    Posstr='['+varargin(N+1)+']';
  else
    Posstr='[c]'
  end
  Openphr(Namestr);
  S='\begin{minipage}'+Posstr+'{'+Habastr+'}%';
  if Wfile=='default'
    mprintf('%s\n',S);
  else
    mfprintf(FID,'%s\n',S);
  end
endfunction

