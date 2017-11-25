//  09.09.10

function Setcounter(varargin)
  global GCOUNTER;
  Nargs=length(varargin);
  if Nargs==0
    N=1;
  else
    N=varargin(1);
  end;
  GCOUNTER=N;
endfunction;

