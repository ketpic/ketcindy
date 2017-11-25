//
// 08.08.24
// 10.01.02

function Out=MakeBowdata(PA,PB,H)
  global BOWSTART BOWEND
  BOWSTART=PA;
  BOWEND=PB;
  Eps=10^(-5);
  D=1/2*Vecnagasa(PB-PA);
  R=(H^2+D^2)/(2*H);
  A1=PA(1); A2=PA(2);
  B1=PB(1); B2=PB(2);
  if abs(A2-B2)>Eps
    x=poly(0,'X');
    y=-(A1-B1)*x/(A2-B2)+(1/2)*(A1^2+A2^2-B1^2-B2^2)/(A2-B2);
    Eq1=(A1-x)^2+(A2-y)^2-R^2;
    Tmp=coeff(Eq1);
    C0=Tmp(1); C1=Tmp(2); C2=Tmp(3);
    Det=sqrt(C1^2-4*C0*C2);
    Ansx1=(-C1+Det)/(2*C2);
    Ansx2=(-C1-Det)/(2*C2);
    Tmp=horner(y,Ansx1);
    PC=[Ansx1,Tmp];
    Tmp=horner(y,Ansx2);
    PC2=[Ansx2,Tmp];
  else
    Tmp=0.5*(PA+PB);
    PC=Tmp+[0,R-H];
    PC2=Tmp-[0,R-H];
  end;
  VA=PA-PC;
  VB=PB-PC;
  if VA(1)*VB(2)-VA(2)*VB(1)<0
    PC=PC2;
  end
  AngA=acos((PA(1)-PC(1))/R);
  if PA(2)-PC(2)<0
    AngA=-AngA;
  end
  AngB=acos((PB(1)-PC(1))/R);
  if PB(2)-PC(2)<0
    AngB=-AngB;
  end
  if AngA>AngB
    AngB=AngB+2*%pi;
  end
  Out=Mixmake(PC,R,AngA,AngB);
endfunction
