//
// 08.05.30  debugged
// 08.08.14   (horner)
// 09.12.31  (gsort)
// 15.10.23  ( horner not used )
// 16.12.29  (msprintf("%3.10f",..) used )

function R=MeetWindow(PA,PB)
  global XMIN XMAX YMIN YMAX
  if InWindow(PA)=='i' & InWindow(PB)=='i'
    R=[PA;PB];
    return
  end;
  Eps=10.0^(-6);
  t=poly(0,'T');
  PT="(1-(t))*PA+(t)*PB";
  Txm=-1; TxM=-1; Tym=-1; TyM=-1;
  if PA(1)~=PB(1)
    Txm=(XMIN-PA(1))/(PB(1)-PA(1));
    TxM=(XMAX-PA(1))/(PB(1)-PA(1));
  end
  if PA(2)~=PB(2)
    Tym=(YMIN-PA(2))/(PB(2)-PA(2));
    TyM=(YMAX-PA(2))/(PB(2)-PA(2));
  end;
//  Tmp=horner(PT(2),Txm);  
  Tmp1=strsubst(PT,"t",msprintf("%3.10f",Txm));
  Tmp1=evstr(Tmp1)
  Tmp=Tmp1(2);
  if Tmp<YMIN-Eps | Tmp>YMAX+Eps
    Txm=-1;
  end
//  Tmp=horner(PT(2),TxM); 
  Tmp1=strsubst(PT,"t",msprintf("%3.10f",TxM));
  Tmp1=evstr(Tmp1)
  Tmp=Tmp1(2);
  if Tmp<YMIN-Eps | Tmp>YMAX+Eps
    TxM=-1
  end
//  Tmp=horner(PT(1),Tym);
  Tmp1=strsubst(PT,"t",msprintf("%3.10f",Tym));
  Tmp1=evstr(Tmp1)
  Tmp=Tmp1(1);
  if Tmp<XMIN-Eps | Tmp>XMAX+Eps
    Tym=-1
  end
//  Tmp=horner(PT(1),TyM);
  Tmp1=strsubst(PT,"t",msprintf("%3.10f",TyM));
  Tmp1=evstr(Tmp1)
  Tmp=Tmp1(1);
  if Tmp<XMIN-Eps | Tmp>XMAX+Eps
    TyM=-1
  end
  Tmp=gsort([Txm,TxM,Tym,TyM]);
  Tans=Tmp(length(Tmp):-1:1);
  Tmp=[];
  for I=1:length(Tans)
    Tmp1=Tans(I);
    if Tmp1>-Eps & Tmp1<1+Eps
      if length(Tmp)==0
        Tmp=[Tmp1];
      elseif abs(Tmp(length(Tmp))-Tmp1)>Eps
          Tmp=[Tmp,Tmp1]
      end
    end
  end
  Tans=Tmp;
  if length(Tans)==0
    R=[];
    return;
  end
  if length(Tans)==1
//    Ten1=horner(PT,Tans(1));
    Tmp1=strsubst(PT,"t",string(Tans(1)));
    Ten1=evstr(Tmp1)
    if InWindow(PA)=='i'
      R=[PA;Ten1];
      return;
    else
      R=[Ten1;PB];
      return
    end
  end
//  Ten1=horner(PT,Tans(1));
  Tmp1=strsubst(PT,"t",string(Tans(1)));
  Ten1=evstr(Tmp1)
//  Ten2=horner(PT,Tans(2));
  Tmp1=strsubst(PT,"t",string(Tans(2)));
  Ten2=evstr(Tmp1)
  R=[Ten1;Ten2];
endfunction
