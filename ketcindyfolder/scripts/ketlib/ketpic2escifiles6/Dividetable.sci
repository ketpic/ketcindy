// 13.05.03

function Out=Dividetable(Tb)
  G=Tb(1);
  Gw=G(1);
  Gt=Mixsub(Tb(2),G);
  Gy=Mixsub(Tb(3),G);
  Out=list(Gw,Gt,Gy)
endfunction;
