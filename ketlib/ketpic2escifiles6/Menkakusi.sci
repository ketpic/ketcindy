// 08.08.21
// 09.10.24
// 09.10.26

function Menkakusi(Face,Nf,Ptype)
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
    Tmp=VELNO(N);
    Edge=Tmp(1);
    Ne=Tmp(2);
    Nenm=Tmp(3);
    if Member(Nf,Ne)
      Out1L($+1)=list(Edge,Ne,Nenm);
      continue;
    end;
    if Ptype==-1
      P=Perspt(Edge(1));
      Q=Perspt(Edge(2));
    else
      P=Parapt(Edge(1));
      Q=Parapt(Edge(2));
    end;
    if norm(P-Q)<Eps 
      continue; 
    end;
    Tmp=Kyoukai(Mix(G1));
    Tmp1=Naigai(P,Tmp);
    Ng1=Tmp1(1);
    Tmp1=Naigai(Q,Tmp);
    Ng2=Tmp1(1);
    KL=IntersectcrvsPp(Listplot([P,Q]),G1);
    if Mixlength(KL)==0
      if Ng1==0
        Out1L($+1)=list(Edge,Ne,Nenm);
      else
        Tmp1=(Edge(1)+Edge(2))*0.5-Face(1);
        Tmp=Dotprod(Tmp1,Vec)/norm(Tmp1);
        if Tmp>-Eps
          Out1L($+1)=list(Edge,Ne,Nenm);
        else
          Out2L($+1)=list(Edge,Ne,Nenm);
        end;
      end;
      continue;
    end;
    Flg=0;
    for I=1:Mixlength(VL)-1
      Tmp=VL(I+1)-VL(I);
      if norm(Tmp)<Eps continue; end;
      Tmp1=Crossprod(Tmp,Q-P)/norm(Tmp)/norm(Q-P);
      if abs(Tmp1)<Eps
        Flg=1;
        break;
      end;
    end;
    if Flg==1
      Tmp=Mixop(I,VL)-P;
      if norm(Tmp)<Eps
        Tmp1=0;
      else
        Tmp1=Crossprod(Tmp,Q-P)/norm(Tmp)/norm(Q-P);
      end;
      if abs(Tmp1)<Eps then
        Out1L($+1)=list(Edge,Ne,Nenm);
        continue;
      end;
    end;
    if Mixlength(KL)==1
      Tmp=KL(1);
      Tmp=Tmp(2)-1;
      if Tmp<Eps
        if Ng2==0
          Out1L($+1)=list(Edge,Ne,Nenm);
        else
          Tmp1=Edge(2)-Face(1);
          Tmp1=Dotprod(Tmp1,Vec);
          if Tmp1>-Eps
            Out1L($+1)=list(Edge,Ne,Nenm);
          else
            Out2L($+1)=list(Edge,Ne,Nenm);
          end;
        end;
        continue;
      end;
      if Tmp>1-Eps
        if Ng1==0
          Out1L($+1)=list(Edge,Ne,Nenm);
        else
          Tmp1=Edge(1)-Face(1);
          Tmp1=Dotprod(Tmp1,Vec);
          if Tmp1>-Eps
            Out1L($+1)=list(Edge,Ne,Nenm);
          else
            Out2L($+1)=list(Edge,Ne,Nenm);
          end;
        end;
        continue;
      end;
      if Ng1==0 & Ng2==0
        Out1L($+1)=list(Edge,Ne,Nenm);
      else
        Tmp1=KL(1);
        Tmp1=Tmp1(1);
        if Ptype==-1
          Tmp=Invperspt(Tmp1,Spaceline(Edge));
        else
          Tmp=Invparapt(Tmp1,Spaceline(Edge))
        end;
        Ak=Tmp(1);
        if Ng1==1
          Tmp1=Edge(1)-Face(1);
          Tmp1=Dotprod(Tmp1,Vec);
          if Tmp1>-Eps
            Out1L($+1)=list(Edge,Ne,Nenm);
          else
            Tmp2=list(Ak,Edge(2));
            Out1L($+1)=list(Tmp2,Ne,Nenm);
            Tmp2=list(Edge(1),Ak);
            Out2L($+1)=list(Tmp2,Ne,Nenm);
          end;
        end;
        if Ng2==1
          Tmp1=Edge(2)-Face(1);
          Tmp1=Dotprod(Tmp1,Vec);
          if Tmp1>-Eps
            Out1L($+1)=list(Edge,Ne,Nenm);
          else
            Tmp2=list(Edge(1),Ak);
            Out1L($+1)=list(Tmp2,Ne,Nenm);
            Tmp2=list(Ak,Edge(2));
            Out2L($+1)=list(Tmp2,Ne,Nenm);
          end;
        end;
      end;
    end;
    if Mixlength(KL)==2
      Tmp1=KL(1);
      Tmp1=Tmp1(2);
      Tmp2=KL(2);
      Tmp2=Tmp2(2);
      if Tmp1>Tmp2
        KL=list(KL(2),KL(1));
      end;
      Tmp=Spaceline(Edge);
      Tmp1=KL(1);
      Tmp1=Tmp1(1);
      Tmp2=KL(2);
      Tmp2=Tmp2(1);
      if Ptype==-1
        Ak=Mixop(1,Invperspt(Tmp1,Tmp));
        Bk=Mixop(1,Invperspt(Tmp2,Tmp))
      else
        Ak=Mixop(1,Invparapt(Tmp1,Tmp));
        Bk=Mixop(1,Invparapt(Tmp2,Tmp))
      end;
      Tmp1=(Ak+Bk)*0.5-Face(1);
      Tmp=Dotprod(Tmp1,Vec);
      if Tmp>-Eps
        Out1L($+1)=list(Edge,Ne,Nenm);
      else
        Out1L($+1)=list(list(Edge(1),Ak),Ne,Nenm);
        Out1L($+1)=list(list(Bk,Edge(2)),Ne,Nenm);
        Out2L($+1)=list(list(Ak,Bk),Ne,Nenm);
      end;
    end;
  end;
  VELNO=Out1L;
  VELHI=Out2L;
endfunction

