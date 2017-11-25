// 09.10.11
// 09.10.12

function Out=Intersectlines(L1,L2)
  Eps0=10^(-6);
  P=Ptstart(L1);
  a1=P(1); a2=P(2);
  V=Ptend(L1)-P;
  b1=V(1); b2=V(2);
  P=Ptstart(L2);
  c1=P(1); c2=P(2);
  V=Ptend(L2)-P;
  d1=V(1); d2=V(2);  
  Den=b1*d2-d1*b2;
  if abs(Den)<Eps0
    Out=[];
    return;
  end;
  x=-(d1*b2*a1-c1*b1*d2-d1*a2*b1+d1*b1*c2)/Den;
  y=-(-a2*b1*d2+b2*a1*d2-b2*c1*d2+c2*d1*b2)/Den;
  Out=[x,y];
endfunction;
