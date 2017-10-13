// 08.05.18 Koshikawa
// 08.05.19 Changed
// 08.00.04
// 09.11.07 for the same curve

function KL=IntersectcrvsPp(varargin) // Modified
  Nargs=length(varargin);
  G1=varargin(1); G2=varargin(2);
  Eps=10.0^(-4);
  if Nargs>2
    Eps=varargin(3)
  end
  SqEps=10.0^(-10);
  Eps2=0.1;
  if Nargs>3
    Eps2=varargin(4)
  end
  Data1=G1;
  Data2=G2;
  if size(Data1,1)==size(Data2,1)
    Tmp1=Data2(size(Data2,1):-1:1,:);  // 09.11.07
    Eps0=10^(-6);
    Tmp2=norm(Data1-Data2);
    Tmp3=norm(Data1-Tmp1);  
    if Tmp2<Eps0|Tmp3<Eps0
      KL=list();
      return;
    end;                       //
  end;
  KL1=[];
  KL2=[];
  for I=1:size(Data1,1)-1 
    A=Data1(I,:);
    B=Data1(I+1,:);
    for J=1:size(Data2,1)-1
      P=Data2(J,:); Q=Data2(J+1,:);
      Tmp=Koutenseg(A,B,P,Q,Eps,Eps2);
      if Tmp~=[%inf,-%inf]
        if Op(3,Tmp)==0
          Tmp1=MixS(Op(1,Tmp),Op(2,Tmp),I,J);
          KL1=Mixadd(KL1,Tmp1);
        else
          Tmp2=MixS(Op(1,Tmp),Op(2,Tmp),I,J);
          KL2=Mixadd(KL2,Tmp2);
        end
      end
    end
  end
  KL=[];
  if Mixlength(KL1)>0
    Tmp=Op(1,KL1);
    P=Op(1,Tmp);
    T=Op(2,Tmp);
    I=Op(3,Tmp);
    J=Op(4,Tmp);
    Tmp=MixS(P,I+T,J);
    KL=MixL(Tmp);
  end
  for N=2:Mixlength(KL1) 
    Tmp=Op(N,KL1); 
    P=Op(1,Tmp);
    Flg=0;
    for K=1:Mixlength(KL)
      Tmp=Op(K,KL);
      if Vecnagasa2(P-Op(1,Tmp))<SqEps
        Flg=1;
        break
      end
    end
    if Flg==0
      Tmp=Op(N,KL1);
      T=Op(2,Tmp);
      I=Op(3,Tmp);
      J=Op(4,Tmp);
      Tmp=MixS(P,I+T,J);
      KL=Mixadd(KL,Tmp);
    end
  end
  for N=1:Mixlength(KL2)
    Tmp=Op(N,KL2);
    P=Op(1,Tmp); 
    Flg=0;
    for K=1:Mixlength(KL)
      Tmp=Op(K,KL);
      if Vecnagasa2(P-Op(1,Tmp))<SqEps
        Flg=1;
        break
      end
    end
    if Flg==0
      Tmp=Op(N,KL2);
      T=Op(2,Tmp);
      T=min(max(T,0),1);
      I=Op(3,Tmp);
      J=Op(4,Tmp);
      Tmp=MixS(P,I+T,J);
      KL=Mixadd(KL,Tmp);
    end
  end
endfunction

