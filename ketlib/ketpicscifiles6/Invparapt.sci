// 08.07.11
// 08.08.17
// 09.10.31
// 09.11.12

function Out=Invparapt(varargin)
  Eps=10^(-4);
  Fk=varargin($);
  NFk=Numptcrv(Fk)    
  Tmp=varargin(1);
  if type(Tmp)==1 & size(Tmp)==1
    Ph=Tmp;
    Fh=varargin(2);
  else
    Fh=Projpara(Fk);
    if NFk>2
      Tmp1=Nearestpt(Tmp,Fh);
      Ph=Tmp1(2);
    else
      Ah=Ptcrv(1,Fh); Bh=Ptcrv(2,Fh);
      V1=Tmp-Ah; V2=Bh-Ah;
      Tmp1=Crossprod(V1,V2);
      if abs(Tmp1)>Eps
        disp('Not on the line');
        Out=[];
        return;
      else
        Ph=Dotprod(V1,V2)/norm(V2)^2+1;  // 09.11.12
      end;
    end;
  end;
  if NFk>2
    N=Trunc(Ph);
    S0=Ph-N;
    if Ph>Numptcrv(Fh)-Eps
      Out=list(Ptend(Fk),Numptcrv(Fh));
      return;
    end;
  else
    N=1;
    S0=Ph-1;  // 09.11.12
  end;
  Ak=Ptcrv(N,Fk); Bk=Ptcrv(N+1,Fk);
  Ah=Ptcrv(N,Fh); Bh=Ptcrv(N+1,Fh);
  Ph=(1-S0)*Ah+S0*Bh;
  T2=S0;
  Pk=(1-T2)*Ak+T2*Bk;
  Out=list(Pk,N+T2);
endfunction

