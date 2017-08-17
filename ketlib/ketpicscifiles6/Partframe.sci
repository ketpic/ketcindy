// 13.05.03

function Out=Partframe(Tb,St,Ed)
  G=Dividetable(Tb);
  Gw=G(1);
  Gt=G(2);
  Gy=G(3);
  Gwt=Tb(4);
  Gwy=Tb(5);
  Gat=lstcat(list(Gwt(1)),Gt,list(Gwt(2)));
  Gay=lstcat(list(Gwy(1)),Gy,list(Gwy(2)));
  Tmp1=Ptstart(Gat(St(1)));
  Tmp2=Ptstart(Gay(St(2)));
  Ps=[Tmp1(1),Tmp2(2)];
  Tmp1=Ptstart(Gat(Ed(1)));
  Tmp2=Ptstart(Gay(Ed(2)));
  Pe=[Tmp1(1),Tmp2(2)];
  Pars=Paramoncrv(Ps,Gw);
  Pare=Paramoncrv(Pe,Gw);
  if Pars<Pare then
    Out=Partcrv(Pars,Pare,Gw);
  else
    Tmp1=Partcrv(Pars,Numptcrv(Gw),Gw);
    Tmp2=Partcrv(1,Pare,Gw);
    Out=Joincrvs(Tmp1,Tmp2);
  end
endfunction;
