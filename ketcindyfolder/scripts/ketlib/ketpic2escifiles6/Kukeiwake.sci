// 08.05.30

function Out=Kukeiwake(PL)
  global XMIN XMAX YMIN YMAX;
  Eps=10.0^(-6);
  NW=[XMIN,YMAX]; SW=[XMIN,YMIN];
  SE=[XMAX,YMIN]; NE=[XMAX,YMAX];
  Sikaku=[NW;SW;SE;NE;NW];
  Kt=IntersectcrvsPp(PL,Sikaku);
  if Mixlength(Kt)~=2
    disp('not two points')
    return
  end
  Tmp=Op(1,Kt);
  Pt1=Op(1,Tmp);
  N1=Trunc(Op(2,Tmp));
  M1=Op(3,Tmp);
  Tmp=Op(2,Kt);
  Pt2=Op(1,Tmp);
  N2=Trunc(Op(2,Tmp));
  M2=Op(3,Tmp);
  T1=ParamonCurve(Pt1,M1,Sikaku);
  T2=ParamonCurve(Pt2,M2,Sikaku);
  QL=[];
  if Vecnagasa(Pt1,PL(N1+1,:))>Eps
    QL=[Pt1];
  end
  QL=[QL;PL(N1+1:N2,:)];
  if Vecnagasa(Pt2,PL(N2,:))>Eps
    QL=[QL;Pt2];
  end
  HidariL=QL;
  Ms=M2+1; Me=M1;
  if T1<T2+Eps Me=M1+4; end
  for M=Ms:Me
    Tmp=HidariL(size(HidariL,1),:);
    P=Sikaku(modulo(M-1,4)+1,:);
    if Vecnagasa(Tmp,P)>Eps
      HidariL=[HidariL;P];
    end
  end
  Tmp=HidariL(size(HidariL,1),:);
  if Vecnagasa(Tmp,Pt1)>Eps
    HidariL=[HidariL;Pt1];
  end
  MigiL=QL;
  Ms=M2; Me=M1+1;
  if T1>T2-Eps Me=Me-4; end;
  for M=Ms:-1:Me
    Tmp=MigiL(size(MigiL,1),:);
    P=Sikaku(modulo(M-1,4)+1,:);
    if Vecnagasa(Tmp,P)>Eps
      MigiL=[MigiL;P]
    end
  end
  Tmp=MigiL(size(MigiL,1),:);
  if Vecnagasa(Tmp,Pt1)>Eps
    MigiL=[MigiL;Pt1];
  end
  Out=MixS(HidariL,MigiL);
endfunction

