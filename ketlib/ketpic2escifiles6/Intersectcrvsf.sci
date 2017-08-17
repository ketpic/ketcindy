// 08.10.26
// 10.02.16

function Out=Intersectcrvsf(varargin)
  Nargs=length(varargin);
  Eps0=10^(-4);
  Crv=varargin(1);
  Fd=varargin(2);
  N=3;Uveq=1;
  if Nargs>=3
    Tmp=varargin(3);
    if type(Tmp)==10
      Uveq=Tmp;
      N=4;
    end;
  end;
  Np=[50,50];
  if Nargs>=N
    Np=varargin(N);
    if length(Np)==1
      Np=[Np,Np];
    end;
  end;
  Eps=[0.05,1]; //
  if Nargs>=N+1
    Eps=varargin(N+1);
  end;
  if length(Eps)==1 //
    Eps=[Eps,1]; //
  end; //
  Out=[];
  for I=1:Numptcrv(Crv)-1
    PtA=Ptcrv(I,Crv);
    PtB=Ptcrv(I+1,Crv);
    if norm(PtB-PtA)<Eps0
      continue;
    end;
    PL=Meetpoints(PtA,PtB,Fd,Uveq,Np,Eps(1));
    for J=1:Mixlength(PL)
      Pt=Mixop(J,PL);
      Tmp=norm(Pt-PtA)/norm(PtB-PtA);
      Tmp=min(max(Tmp,0),1);
      Out=Mixadd(Out,[Pt,I+Tmp]);
    end;
  end;
endfunction;

