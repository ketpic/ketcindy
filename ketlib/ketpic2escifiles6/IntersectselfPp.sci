// 09.05.27
// 09.06.03
// 09.06.05

function KL=IntersectselfPp(varargin) 
  Nargs=length(varargin);
  G1=varargin(1);
  Eps=10.0^(-4);
  if Nargs>1
    Eps=varargin(2)
  end
  Eps0=10.0^(-5);
  Eps2=0.01;
//  if Nargs>2
//    Eps2=varargin(3)
//  end;
  Data1=G1;
  KL1=[];
  KL2=[];
  for I=1:size(Data1,1)-2 
    A=Data1(I,:);
    B=Data1(I+1,:);
    Is=I+2;
    Tmp=Data1(Is,:);
    while norm(Tmp-B)<Eps & Is<size(Data1,1);
      Is=Is+1;
      Tmp=Data1(Is,:);
    end;
    for J=Is:size(Data1,1)-1
      P=Data1(J,:); Q=Data1(J+1,:);
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
    S=ParamonCurve(P,J,Data1);
    Tmp=MixS(P,I+T,J);
    Tmp2=MixS(P,S,I);
    KL=MixL(Tmp);
    KL=Mixadd(KL,Tmp2);
  end;
  for N=2:Mixlength(KL1) 
    Tmp=Op(N,KL1); 
    P=Op(1,Tmp);
    T=Op(2,Tmp);
    I=Op(3,Tmp);
    J=Op(4,Tmp);
    S=ParamonCurve(P,J,Data1);
    Tmp=MixS(P,I+T,J);
    Tmp1=MixS(P,S,I);
    KL=Mixadd(KL,Tmp);
    KL=Mixadd(KL,Tmp1);
  end
  for N=1:Mixlength(KL2)
    Tmp=Op(N,KL2);
    P=Op(1,Tmp); 
    T=Op(2,Tmp);
    T=min(max(T,0),1);
    I=Op(3,Tmp);
    J=Op(4,Tmp);
    S=ParamonCurve(P,J,Data1);
    Flg=0;
    for K=1:Mixlength(KL)
      Tmp=Op(K,KL);
      if norm(P-Op(1,Tmp))<Eps
        Tmp1=Op(2,Tmp);
        if abs(I+T-Tmp1)<Eps
          Flg=1;
          break;
        end;
      end;
    end;
    if Flg==0
      Tmp=MixS(P,I+T,J);
      Tmp1=MixS(P,S,I);
      KL=Mixadd(KL,Tmp);
      KL=Mixadd(KL,Tmp1);
    end;
  end;
endfunction;

