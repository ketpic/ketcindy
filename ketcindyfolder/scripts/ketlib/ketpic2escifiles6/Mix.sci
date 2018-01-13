// 08.05.20
// 08.08.08

// Structure changed
// 09.10.11

function M=Mix(varargin)
  Nargs=length(varargin);
  M=list();
  for I=1:Nargs
    Da=varargin(I);
    M(I)=Da;
  end
endfunction

