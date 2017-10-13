// 05.14 Data Structure
// 05.16 List of MixList
// 05.19 use:MixS, MixL, Mixtype
// 08.08.17

// Structure changed
// 09.10.11

function M=Mixadd(varargin)
  Nargs=length(varargin);
  M=list();
  Tmp=varargin(1);
  if length(Tmp)==0
    M(1)=varargin(2);
  else
    M=Tmp;
    M($+1)=varargin(2);
  end;
  for I=3:Nargs
    M($+1)=varargin(I);
  end;
endfunction

