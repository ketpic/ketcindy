// 09.09.10

function Addcounter(varargin)
  global GCOUNTER;
  if Nargs==0
    N=1;
  else
    N=varargin(1);
    GCOUNTER=GCOUNTER+N;
  end;
endfunction;

