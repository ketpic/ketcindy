// 09.10.03

function Out=Assignadd(varargin)
  global ASSIGNLIST;
  Nargs=length(varargin);
  L=ASSIGNLIST;
  Is=length(L);
  for I=1:Nargs
    L(I+Is)=varargin(I);
  end;
  ASSIGNLIST=L;
  Out=L;
endfunction;

