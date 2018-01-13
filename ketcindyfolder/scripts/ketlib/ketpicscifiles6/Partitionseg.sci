// 08.09.13
// 08.10.17
// 09.05.27
// 09.12.31 (gsort)

function Out=Partitionseg(varargin)
  global PARTITIONPT OTHERPARTITION;
  Nargs=length(varargin);
  Fig=varargin(1);
  GL=varargin(2); N=3;
  Eps0=10^(-5);
  Eps=0.05;
  if Nargs>2
    Eps=varargin(3);
  end;
  Eps2=0.2;
  if Nargs>3
    Eps2=varargin(4);
  end;
  if Nargs>4
    Ns=varargin(5);
    Other=Mixop(Ns,OTHERPARTITION);
  else
    Ns=1;
    Other=[];
    OTHERPARTITION=[];
    for N=1:Mixlength(GL)
      OTHERPARTITION=Mixadd(OTHERPARTITION,[]);
    end;
  end;
  Npt=size(Fig,1);
  ParL=[1,Npt,Other];
  for N=Ns:Mixlength(GL)
    G=Mixop(N,GL);
    if Fig==G
      KouL=IntersectselfPp(Fig,Eps,Eps2);
    else
      KouL=IntersectcrvsPp(Fig,G,Eps,Eps2);
      Tmp=Nearestpt(Ptstart(Fig),G);
      Tmp1=Mixop(1,Tmp);
      Tmp2=Mixop(2,Tmp);
      Tmp3=Mixop(3,Tmp);
      if Tmp3>Eps0 & Tmp3<Eps
        Tmp1=Mix(Tmp1,1,floor(Tmp2));
        KouL=Mixadd(KouL,Tmp1); 
      end;
      Tmp=Nearestpt(Ptend(Fig),G);
      Tmp1=Mixop(1,Tmp);
      Tmp2=Mixop(2,Tmp);
      Tmp3=Mixop(3,Tmp);
      if Tmp3>Eps0 & Tmp3<Eps
        Tmp1=Mix(Tmp1,Numptcrv(Fig),floor(Tmp2));
        KouL=Mixadd(KouL,Tmp1); 
      end;
    end;
    for I=1:Mixlength(KouL)
      Tmp=Mixop(I,KouL);
      P=Mixop(1,Tmp);
      S=Mixop(2,Tmp);
      ParL=[ParL,S];
      K=Mixop(3,Tmp);
      S=ParamonCurve(P,K,G);
      Tmp=Mixop(N,OTHERPARTITION);
      Tmp1=gsort([Tmp,S]);
      Tmp1=Tmp1(length(Tmp1):-1:1);
      Tmp2=[];
      for J=1:Mixlength(OTHERPARTITION)
        Tmp3=Mixop(J,OTHERPARTITION);
        if J~=N
          Tmp2=Mixadd(Tmp2,Tmp3);
        else
          Tmp2=Mixadd(Tmp2,Tmp1);
        end;
      end;
      OTHERPARTITION=Tmp2;
    end;
  end;
  ParL=gsort(ParL);
  ParL=ParL(length(ParL):-1:1);
  ParL(1)=1;
  Out=[ParL(1)];
  P=PointonCurve(ParL(1),Fig);
  PARTITIONPT=Mix(P);
  for I=1:length(ParL)
    Tmp=ParL(I);
    P=PointonCurve(Tmp,Fig);
    Tmp1=Out(length(Out));
    Q=PointonCurve(Tmp1,Fig);
    if norm(P-Q)>Eps
      Out=[Out,Tmp];
//    P=PointonCurve(Tmp,Fig);
      PARTITIONPT=Mixadd(PARTITIONPT,P);
    end;
  end;
  if Out(length(Out))~=Npt
    Out=[Out(1:length(Out)-1),Npt];
  end;
  if length(Out)==1 Out=[1,Npt]; end;
endfunction;

