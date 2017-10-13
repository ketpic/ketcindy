// 10.03.28

function Out=Diagcelldata(Tb,Nc,Nr)
  Tmp=Findcell(Tb,Nc,Nr);
  C=Tmp(1);
  Dx=Tmp(2);
  Dy=Tmp(3);
  Pne=C+[Dx,Dy];
  Pnw=C+[-Dx,Dy];
  Psw=C+[-Dx,-Dy];
  Pse=C+[Dx,-Dy];
  Tmp1=Listplot(Pnw,Pse);
  Tmp2=Listplot(Pne,Psw);
  Out=list(Tmp1,Tmp2);
endfunction;