// 08.05.31
// 08.08.22
// 08.09.14
// 08.09.20
// 08.10.27
// 11.06.25

function PtL=Joincrvs(varargin)
  Nall=length(varargin);
  Eps=10^(-4);
  Tmp=varargin(Nall);
  if type(Tmp)==1 & length(Tmp)==1
    Eps=Tmp;
    Nall=Nall-1;
  end;
  QdL=list();
  for I=1:Nall
    QdL($+1)=varargin(I); // 11.06.25
  end;
  QdL=Flattenlist(QdL);  // 11.06.25
  if length(QdL)==0
    PtL=[];
    return;
  end;
  PtL=[Mixop(1,QdL)];
  for I=2:Mixlength(QdL)
    Qd=QdL(I);
    if Numptcrv(Qd)<=1 // 11.06.25
      continue;
    end;
    P=Ptend(PtL)
    S=Ptstart(PtL);
    Q=Ptstart(Qd);
    R=Ptend(Qd);
    MN=min(norm(P-Q),norm(P-R),norm(S-Q),norm(S-R));
    if MN==norm(P-R)
      Qd=Invert(Qd);
    elseif MN==norm(S-Q)
      PtL=Invert(PtL);
    elseif MN==norm(S-R);
      PtL=Invert(PtL);
      Qd=Invert(Qd);
    end;
    if MN>Eps
      PtL=[PtL;Qd];
    else
      PtL=[PtL;Qd(2:size(Qd,1),:)];
    end;
  end;
endfunction;

