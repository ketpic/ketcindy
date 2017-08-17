// s: 2014.09.07

function Out=Objjoin(varargin)
  global OBJJOIN
  if length(varargin)>0
    OBJJOIN=abs(sign(varargin(1)))
  end;
  Out=OBJJOIN
endfunction
