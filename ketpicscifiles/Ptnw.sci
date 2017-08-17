//
// 10.01.13

function Out=Ptnw(varargin)
  global XMIN XMAX YMIN YMAX
  if length(varargin)==0
    Out=[XMIN,YMAX];
  else
    G=varargin(1);
    Xm=min(G(:,1));
    YM=max(G(:,2));
    Out=[Xm,YM];
  end;
 endfunction
