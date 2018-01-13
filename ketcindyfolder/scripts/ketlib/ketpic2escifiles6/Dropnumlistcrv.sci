// 08.09.10
// 08.09.15
// 08.10.10
// 10.09.03

function OutL=Dropnumlistcrv(QdL,Eps)
  Eps0=10^(-6);  //
  if Mixtype(QdL)==1
    PdL=list(QdL);
  else
    PdL=QdL;
  end;
  OutL=[];
  for I=1:Mixlength(PdL)
    Pd=Op(I,PdL);
    PtL=[1];
    P=Pd(1,:);
    for K=2:size(Pd,1)-1 //
      if norm(P-Pd(K,:))>Eps
        PtL=[PtL,K];
        P=Pd(K,:);
      end;
    end;
    //    PtL=[PtL,size(Pd,1)];
    K=size(Pd,1) //
    if norm(P-Pd(K,:))>Eps0 //
      PtL=[PtL,K];  //
    end; //
    if length(PtL)==1
      PtL=[];
    end;
    OutL=Mixadd(OutL,PtL);
  end;
endfunction
