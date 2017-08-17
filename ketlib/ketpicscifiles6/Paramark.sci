// 08.06.18

function P=Paramark(varargin)
  Nargs=length(varargin);
  PA=varargin(1);
  PB=varargin(2);
  PC=varargin(3);
  R=0.5;
  if Nargs>=4
    R=varargin(4)*R;
  end
  U=R*(PA-PB)/Vecnagasa(PA,PB);
  V=R*(PC-PB)/Vecnagasa(PC,PB);
  if Gaiseki(PA-PB,PC-PB)~=0
    P=Listplot([PB+U,PB+U+V,PB+V]);
  else
    P=[];
  end
endfunction

