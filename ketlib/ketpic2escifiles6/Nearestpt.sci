// 08.05.31
// 08.06.03
// 08.10.07

function Ans=Nearestpt(varargin)
  Nargs=length(varargin);
  PL1=varargin(1);
  if size(PL1,1)==1
    Flg=0;
  else
    Flg=1
  end
  Eps=10.0^(-6);
//  Fig=varargin(2);
  PL=varargin(2);
  Ans=MixS(PL1(1,:),1,PL(1,:),1,norm(PL1(1,:)-PL(1,:)));
  for N=1:size(PL1,1)
    PA=PL1(N,:);
    Pm=PL(1,:);
    Im=1;
    Sm=norm(Pm-PA);
    for I=1:size(PL,1)-1
      A1=PL(I,1); A2=PL(I,2);
      B1=PL(I+1,1); B2=PL(I+1,2);
      V1=B1-A1; V2=B2-A2;
      X1=PA(1); X2=PA(2);
      Tmp=V2^2+V1^2;
      if abs(Tmp)<Eps
        continue;
      end;
      T=(-A2*V2-V1*A1+V1*X1+X2*V2)/Tmp;
      if T<-Eps
        P=[A1,A2];
      elseif T>1+Eps
        P=[B1,B2];
      else
        P=[A1+T*V1,A2+T*V2];
      end
      S=norm(P-PA);
      if S<Sm-Eps
        Tmp=ParamonCurve(P,I,PL);
        Pm=P; Im=Tmp; Sm=S;
      end
    end
    if Sm<Op(5,Ans)
      Ans=MixS(PA,N,Pm,Im,Sm);
    end
  end
  if Flg==0
    Ans=Mixsub(3:5,Ans);
  end
endfunction;

