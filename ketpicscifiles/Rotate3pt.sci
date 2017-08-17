// 08.08.15

function Ans=Rotate3pt(varargin)
  Eps=10^(-4);
  Nargs=length(varargin);
  P=varargin(1);
  W1=varargin(2);
  W2=varargin(3);
  C=[0,0,0];
  if Nargs>=4
    C=varargin(4);
  end;
  if type(W2)==1 & length(W2)==1
    Ct=cos(W2);
    St=sin(W2);
    V3=1/norm(W1)*W1;
    if V3(1)==0
      Tmp=[1,0,0];
    else
      Tmp=[0,1,0];
    end;
    W1=[Tmp(2)*V3(3)-Tmp(3)*V3(2),...
         Tmp(3)*V3(1)-Tmp(1)*V3(3),...
         Tmp(1)*V3(2)-Tmp(2)*V3(1)];
    V1=1/norm(W1)*W1;
    V2=[V3(2)*V1(3)-V3(3)*V1(2),...
         V3(3)*V1(1)-V3(1)*V1(3),...
         V3(1)*V1(2)-V3(2)*V1(1)];
  else
    Tmp=[W1(2)*W2(3)-W1(3)*W2(2),...
          W1(3)*W2(1)-W1(1)*W2(3),...
          W1(1)*W2(2)-W1(2)*W2(1)];
    if norm(Tmp)<Eps
      Ans=P;
      return;
    end;
    V1=1/norm(W1)*W1;
    Ns=V1(1)*W2(1)+V1(2)*W2(2)+V1(3)*W2(3);
    Tmp=W2-Ns*V1;
    V2=1/norm(Tmp)*Tmp;
    Tmp=[V1(2)*V2(3)-V1(3)*V2(2),...
         V1(3)*V2(1)-V1(1)*V2(3),...
         V1(1)*V2(2)-V1(2)*V2(1)];
    V3=1/norm(Tmp)*Tmp;
    Ct=Ns/norm(W2);
    St=sqrt(1-Ct^2);
  end;
  if norm(Tmp)<Eps
    Ans=P;
    return;
  end;
  V1x=V1(1); V1y=V1(2); V1z=V1(3);
  V2x=V2(1); V2y=V2(2); V2z=V2(3);
  V3x=V3(1); V3y=V3(2); V3z=V3(3);
  if Mixtype(P)~=1
    PtL=P;
  else
    PtL=MixS(P);
  end;
  Ans=[];
  for N=1:Mixlength(PtL)
    P=Mixop(N,PtL);
    if P(1)==%inf
      Ans=Mixadd(Ans,[%inf,%inf,%inf]);
      continue;
    end;
    x=P(1)-C(1); y=P(2)-C(2); z=P(3)-C(3);
    X=((V1x*Ct+V2x*St)*V1x+(-V1x*St+V2x*Ct)*V2x+V3x^2)*x...
      +((V1x*Ct+V2x*St)*V1y+(-V1x*St+V2x*Ct)*V2y+V3x*V3y)*y...
      +((V1x*Ct+V2x*St)*V1z+(-V1x*St+V2x*Ct)*V2z+V3x*V3z)*z; 
    Y=((V1y*Ct+V2y*St)*V1x+(-V1y*St+V2y*Ct)*V2x+V3x*V3y)*x...
      +((V1y*Ct+V2y*St)*V1y+(-V1y*St+V2y*Ct)*V2y+V3y^2)*y...
      +((V1y*Ct+V2y*St)*V1z+(-V1y*St+V2y*Ct)*V2z+V3y*V3z)*z;
    Z=((V1z*Ct+V2z*St)*V1x+(-V1z*St+V2z*Ct)*V2x+V3x*V3z)*x...
      +((V1z*Ct+V2z*St)*V1y+(-V1z*St+V2z*Ct)*V2y+V3y*V3z)*y...
      +((V1z*Ct+V2z*St)*V1z+(-V1z*St+V2z*Ct)*V2z+V3z^2)*z;
    Ans=Mixadd(Ans,C+[X,Y,Z]);
  end;
  if Mixlength(Ans)==1
    Ans=Mixop(1,Ans);
  end;
endfunction

