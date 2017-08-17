// 09.10.09
// 09.10.21  Es, Er

function Out=Integrate(varargin);
  Nargs=length(varargin);
  Fs=varargin(1);
  Vs=varargin(2);
  Itv=varargin(3);
  Es=1d-10;
  if Nargs>3
    Es=varargin(4);
  end;
  Er=1d-8;
  if Nargs>4
    Er=varargin(5);
  end;
  Out=0;
  Na=1;
  while Na<length(Itv)
    A=Itv(Na); B=Itv(Na+1);
    Out=Out+integrate(Fs,Vs,A,B,Es,Er);
    Na=Na+1;
  end;
endfunction;

