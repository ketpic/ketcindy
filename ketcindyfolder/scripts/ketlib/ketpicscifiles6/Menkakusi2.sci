// 09.10.29
// 09.11.15
// 10.08.17 debug  (line 66)

function Menkakusi2(Face,Nf,Ptype)
  global THETA PHI EyePoint FocusPoint VELNO VELHI;
  Eps0=10^(-6);
  Eps=10^(-4);
  Tmp1=Face(1)-Face(2);
  Tmp2=Face(3)-Face(2);
  if norm(Tmp1)<Eps | norm(Tmp2)<Eps
    return;
  end;
  Vec=1/norm(Tmp1)/norm(Tmp2)*Crossprod(Tmp1,Tmp2);
  if norm(Vec)<Eps
    return;
  end;
  if Ptype==-1
    W=EyePoint;
    Tmp=Dotprod(Vec,W-Face(1));
  else
    W=[sin(THETA)*cos(PHI),sin(THETA)*sin(PHI),cos(THETA)];
    W=100*W;
    Tmp=Dotprod(Vec,W-Face(1));
  end;
  if abs(Tmp)<Eps
    return;
  end;
  if Tmp<-Eps
    Vec=-Vec;
  end;
  if Ptype==-1
    G1=Projpers(Spaceline(Face));
  else
    G1=Projpara(Spaceline(Face))
  end;
  VL=list();
  for I=1:Numptcrv(G1)
    VL(I)=Ptcrv(I,G1);
  end;
  Out1L=list();
  Out2L=VELHI;
  for N=1:length(VELNO)
    Out1=list();
    Out2=list();
    Tmp=VELNO(N);
    Edge=Tmp(1);
    Ne=Tmp(2);
    NNe=Tmp(3);
    if Member(Nf,Ne)
      Out1L($+1)=list(Edge,Ne,NNe);
      continue;
    end;
    if Ptype==-1
      PtA=Perspt(Edge(1));
      PtB=Perspt(Edge(2));
    else
      PtA=Parapt(Edge(1));
      PtB=Parapt(Edge(2));
    end;
    if norm(PtA-PtB)<Eps continue; end;
    Bdy=list(G1);
    V=PtB-PtA;
    TenL=KoutenList(PtA,V,Bdy);
    Nten=length(TenL);
    if Nten==0  // 10.08.17
      Out1L($+1)=list(Edge,Ne,NNe);
      continue;
    end;
    Te=0;
    Pe3=Edge(1);
    if Ptype==-1
      Tmp1=Perspt(Pe3);
      Tmp=Invperspt(Tmp1,Spaceline(Face));
    else
      Tmp1=Parapt(Pe3);
      Tmp=Invparapt(Tmp1,Spaceline(Face));
    end;
    Qe3=Tmp(1);
    Flg=0;
    for I=1:Nten
      TenP=TenL(I);
      Ts=TenP(1);
      P=TenP(2);
      if Ts<-Eps
        continue;
      end;
      Eline=Spaceline(Edge); 
      if Ptype==-1
        Tmp=Invperspt(P,Eline);
        Tmp1=Invperspt(P,Spaceline(Face));
      else
        Tmp=Invparapt(P,Eline)
        Tmp1=Invparapt(P,Spaceline(Face));
      end;
      P3=Tmp(1); Q3=Tmp1(1);
      if Ts>1-Eps  // P3, Q3 are necessary
        Flg=I;
        break;
      end;
      if abs(Te-Ts)>Eps0  //
        if modulo(I,2)==1
          Out1($+1)=list(Pe3,P3);
        else
          if Qe3==[]
            Tmp=Op(2,TenL(I-1));
            if Ptype==-1
              Tmp1=Invperspt(Tmp,Spaceline(Face));
            else
              Tmp1=Invparapt(Tmp,Spaceline(Face));
            end;
            Qe3=Tmp1(1);
          end;
          PM=0.5*(Pe3+P3); QM=0.5*(Qe3+Q3);
          if Ptype==-1
            Z1=Zperspt(PM); Z2=Zperspt(QM);
          else
            Z1=Zparapt(PM); Z2=Zparapt(QM);
          end;
          if Z1>Z2
            Out1($+1)=list(Pe3,P3);
          else
            Out2($+1)=list(Pe3,P3);
           end;
        end;
      end;
      Te=Ts; Pe3=P3; Qe3=Q3;
    end;
    if Flg==0
      if norm(Pe3-Edge(2))>Eps0
        Out1($+1)=list(Pe3,Edge(2));
      end;
    else
      if modulo(Flg,2)==1
        Out1($+1)=list(Pe3,Edge(2));
      else
        PM=0.5*(Pe3+P3); QM=0.5*(Qe3+Q3);
        if Ptype==-1
          Z1=Zperspt(PM); Z2=Zperspt(QM);
        else
          Z1=Zparapt(PM); Z2=Zparapt(QM);
        end;
        if Z1>Z2
          Out1($+1)=list(Pe3,Edge(2));
        else
          Out2($+1)=list(Pe3,Edge(2));
        end;        
      end;
    end;
    for I=1:length(Out1)
      Tmp=Out1(I);
      if I==1
        SeL=Tmp;
      else
        if norm(SeL(2)-Tmp(1))<Eps0
          SeL(2)=Tmp(2);
        else
          Out1L($+1)=list(SeL,Ne,NNe);
          SeL=Tmp;
        end;
      end;
    end;
    if length(Out1)>0
      Out1L($+1)=list(SeL,Ne,NNe);
    end;
    for I=1:length(Out2)
      Tmp=Out2(I);
      if I==1
        SeL=Tmp;
      else
        if norm(SeL(2)-Tmp(1))<Eps0
          SeL(2)=Tmp(2);
        else
          Out2L($+1)=list(SeL,Ne,NNe);
          SeL=Tmp;
        end;
      end;
    end;
    if length(Out2)>0
      Out2L($+1)=list(SeL,Ne,NNe);
    end;
  end;
  VELNO=Out1L;
  VELHI=Out2L;
endfunction

