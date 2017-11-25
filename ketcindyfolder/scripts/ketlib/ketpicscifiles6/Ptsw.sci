// 10.01.13

function Out=Ptsw(varargin)
  global XMIN XMAX YMIN YMAX
  if length(varargin)==0
    Out=[XMIN,YMIN];
  else
    G=varargin(1);
    Xm=min(G(:,1));
    Ym=min(G(:,2));
    Out=[Xm,Ym];
  end;
endfunction