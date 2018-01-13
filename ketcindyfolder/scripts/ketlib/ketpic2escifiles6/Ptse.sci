// 
// 10.01.13

function Out=Ptse(varargin)
  global XMIN XMAX YMIN YMAX
  if length(varargin)==0
    Out=[XMAX,YMIN];
  else
    G=varargin(1);
    XM=max(G(:,1));
    Ym=min(G(:,2));
    Out=[XM,Ym];
  end;
endfunction
