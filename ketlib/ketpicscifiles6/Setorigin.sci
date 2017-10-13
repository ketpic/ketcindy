// 
// 09.02.27

function Setorigin(varargin)
  global GENTEN;
  Nargs=length(varargin);
  if Nargs==0
    disp(GENTEN);
    return;
  end;
  Pt=varargin(1);
  GENTEN=Pt;
endfunction

