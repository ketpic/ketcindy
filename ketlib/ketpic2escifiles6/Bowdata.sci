//
// 08.05.22
// 08.08.24

function Pd=Bowdata(varargin)
  global BOWMIDDLE BOWSTART BOWEND
  Nargs=length(varargin);
  PA=varargin(1);
  PB=varargin(2);
  Cut=0;
  D=1/2*Vecnagasa(PB-PA);
  if Nargs>=3
    H=varargin(3)*D*0.2; 
  else
    H=D*0.2;
  end
  H=min(H,D);
  if Nargs>=4
    Cut=varargin(4);
  end
  Ydata=MakeBowdata(PA,PB,H); 
  C=Mixop(1,Ydata);
  r=Mixop(2,Ydata);
  R1=Mixop(3,Ydata);
  R2=Mixop(4,Ydata);
  Rng='R=['+string(R1)+','+string(R2)+']';
  Theta=(R1+R2)*0.5;
  BOWMIDDLE=MixS([C(1)+r*cos(Theta),C(2)+r*sin(Theta)],Theta);
  M=Mixop(1,BOWMIDDLE);
  ThetaM=Mixop(2,BOWMIDDLE);
  BOWSTART=PA;
  BOWEND=PB;
  if Cut==0
    Pd=Circledata(C,r,Rng);
  else
    Alpha=R1; Beta=ThetaM-Cut/(2*r);
    Rng='R=['+string(Alpha)+','+string(Beta)+']';
    Pd=Circledata(C,r,Rng);
    Alpha=ThetaM+Cut/(2*r); Beta=R2;
    Rng='R=['+string(Alpha)+','+string(Beta)+']';
    Tmp=Circledata(C,r,Rng);
    Pd=[Pd;%inf,%inf;Tmp];
  end
endfunction

