// 08.05.19

// Structure changed
// 09.10.11

function M=MixL(varargin)
  Nargs=length(varargin);
  M=list();
  for I=1:Nargs
    Da=varargin(I);
    M(I)=Da;
  end
endfunction

