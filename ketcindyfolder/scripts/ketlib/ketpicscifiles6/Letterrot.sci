// 08.05.31
// 08.08.24
// 09.12.25

function Letterrot(varargin)
  global MEMORI;
  P=varargin(1);
  V=varargin(2); N=3;
  P=Doscaling(P);
  V=Doscaling(V);
  Tmov=0;
  Tmp=varargin(N);
  if type(Tmp)==1
    Tmov=Tmp; N=N+1;
  end
  Nmov=0;
  Tmp=varargin(N);
  if type(Tmp)==1 then
    Nmov=Tmp; N=N+1;
  end
  Mojiretu=varargin(N);
  Tv=1/Vecnagasa(V)*V;
  Nv=[-Tv(2),Tv(1)];
  P=P+MEMORI*Tmov*Tv+MEMORI*Nmov*Nv;
  Tmp=acos(V(1)/Vecnagasa(V));
  Theta=round(Tmp*180/%pi);
  if V(2)>=0
    Units='';
  else
    Units='units=-360,';
  end
  Tmp='\rotatebox['+Units+'origin=c]{'+string(Theta);
  Tmp=Tmp+'}{'+Mojiretu+'}';
  Letter(P,"c",Tmp);
endfunction

