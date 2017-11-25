// 08.05.18
// 08.05.19 Changed
// 08.08.15

// Structure changed
// 09.10.11

function M=Mixjoin(varargin)
  Nargs=length(varargin);
  M=list();
  for I=1:Nargs
    Tmp=varargin(I);
    if length(Tmp)==0
      continue;
    end;
    if Mixtype(Tmp)==1
      Tmp=list(Tmp);
    end;
    if length(M)==0
      M=Tmp;
    else
      M=lstcat(M,Tmp);
    end;
  end;
  if length(M)==0
    M=[];
  end;
endfunction;

