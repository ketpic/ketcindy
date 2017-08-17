// 08.05.31
// 08.11.12
// 09.10.12
// 09.10.14
// 15.04.10

function AnsL=EnclosingS(varargin)
  global MilliIn;
  Nargs=length(varargin);
  AnsL=[];
  PdataL=varargin(1);
  Nall=length(PdataL);
  Eps=10^(-3);
  EEps=0.1;
  S=[];
  Flg=0;
  for I=2:Nargs
    Tmp=varargin(I);
    if type(Tmp)==1 & size(Tmp,1)==1 & size(Tmp,2)>1
      S=Tmp;
    end
    if type(Tmp)==1 & length(Tmp)==1
      if Flg==0
        Eps=Tmp;
        Flg=Flg+1
      else
        EEps=Tmp
      end
    end
  end
  F=Op(1,PdataL); G=Op(Nall,PdataL);
  KL=IntersectcrvsPp(F,G);
  if length(KL)==1
    Tmp=Op(1,KL);
    P=Op(1,Tmp);
    T1=Op(2,Tmp);
  end
  if length(KL)==0
    if Numptcrv(F)>Numptcrv(G)
      Tmp=Nearestpt(F,G);
      P=Op(1,Tmp);
      T1=Op(2,Tmp);
    else
      Tmp=Nearestpt(G,F);
      P=Op(3,Tmp);
      T1=Op(4,Tmp);
    end
  end
  if length(KL)>1 // 15.04.10
    if S==[]
      disp('No Start Point');
      return
    end;
    Tmp=Op(1,KL);
    P=Op(1,Tmp);
    T1=Op(2,Tmp);
    Tmp=norm(P-S);
    for I=2:length(KL)
      Tmp1=Op(1,Op(I,KL));
      Tmp2=norm(Tmp1-S);
      if Tmp2<Tmp
        P=Tmp1;
        T1=Op(2,Op(I,KL));
        Tmp=Tmp2;
      end
    end
  end
  S=P;
  AnsL=[];
  for N=1:Nall
    F=Op(N,PdataL);
    if N>1 P=Q;end 
    if N==Nall
      Q=S;
    else
      Flg=0;
      G=Op(N+1,PdataL);
      KL=IntersectcrvsPp(G,F);
      if length(KL)==1
        Tmp=Op(1,KL);
        Q=Op(1,Tmp);
        T3=Op(2,Tmp);
        Flg=10;
      end
      if length(KL)==0 Flg=1; end
      if length(KL)>=2 // Maple bug?
        Tmp1=Op(1,Op(1,KL));
        Tmp2=Op(1,Op(2,KL));
        Tmp=norm(Tmp1-Tmp2);
        if Tmp<Eps*10 Flg=1; end 
      end
      if Flg==1
        if Numptcrv(F)>Numptcrv(G)
          Tmp=Nearestpt(F,G);
          Q=Op(1,Tmp);
          T3=Op(4,Tmp);
          Flg=10;
        else
          Tmp=Nearestpt(G,F);
          Q=Op(3,Tmp);
          T3=Op(2,Tmp);
          Flg=10;
        end
      end
      if Flg<10
        T2=%inf;
        for I=1:length(KL)
          Dt=Op(I,KL);
          Tmp1=Op(1,Dt);
          Tmp=Op(3,Dt);
          Tmp2=Paramoncrv(Tmp1,Tmp,F);
          Tmp3=Op(2,Dt);
          if (Tmp2>T1+Eps) & (Tmp2<T2+Eps)
            Q=Tmp1;
            T2=Tmp2;
            T3=Tmp3;
          end
        end
      end
    end
    Tmp=Partcrv(P,Q,F);
    T1=T3;
    AnsL=Mixadd(AnsL,Tmp);
  end
endfunction

