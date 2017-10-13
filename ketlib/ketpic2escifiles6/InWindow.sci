function Rx=InWindow(PA)
  global XMIN XMAX YMIN YMAX
  Eps=10.0^(-6);
  X=PA(1); Y=PA(2);
  if X>XMIN-Eps & X<XMAX+Eps & Y>YMIN-Eps & Y<YMAX+Eps
    Rx='i'
  else
    Rx='o'
  end
endfunction

