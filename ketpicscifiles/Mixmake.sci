// 08.05.19

// Structure changed
// 09.10.11

function PL=Mixmake(varargin)
  PL=list();
  for I=1:length(varargin)
    Tmp=varargin(I);
    PL=Mixadd(PL,Tmp);
  end
endfunction


