//
// 10.01.13

function Out=Ptne(varargin)
  global XMIN XMAX YMIN YMAX
  if length(varargin)==0
    Out=[XMAX,YMAX];
  else
    G=varargin(1);
    XM=max(G(:,1));
    YM=max(G(:,2));
    Out=[XM,YM];
  end;
endfunction
