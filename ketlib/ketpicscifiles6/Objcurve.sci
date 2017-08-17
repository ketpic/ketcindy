// s : 2014.06.22
// 2014.08.26  debugged 1,-1 => "+","-"
// 2014.09.07  Objjoin added
// 2016.10.09  Np in Spacecurve changed

function Out=Objcurve(varargin)
  global OBJFIGNO OBJJOIN
  Eps=10^(-6);
  Args=varargin;
  Nargs=length(Args)
  Tmp=Args(1);
  PtL=Flattenlist(Tmp);
  PL=list();
  for J=1:length(PtL)
    Tmp=PtL(J);
    for K=1:size(Tmp,1)
       PL=lstcat(PL,list(Tmp(K,:)))
    end;
  end;
  Closed=norm(PL(length(PL))-PL(1))<Eps
  Pstr="xy";
  Tmp=Args(Nargs)
  if type(Tmp)==10 then
    Pstr=Tmp;
    Nargs=Nargs-1
  end;
  Sz=0.1;
  Np=4;
  if Nargs>=2 then
    Sz=Args(2)
  end;
  if Nargs>=3 then
    Np=Args(3)
  end;
  Assign("Sz",Sz)
  if Pstr=="xy" then
    Vz=[0,0,1];
    Fs=Assign("[Sz*cos(t),Sz*sin(t),0]")
  end;
  if Pstr=="yz" then
    Vz=[1,0,0];
    Fs=Assign("[0,Sz*cos(t),Sz*sin(t)]")
  end;
  if Pstr=="zx" then
    Vz=[0,1,0];
    Fs=Assign("[Sz*sin(t),0,Sz*cos(t)]")
  end;
  Gc0=Spacecurve(Fs,"t=[0,2*%pi]","N="+string(Np));//16.10.09
  P=PL(1); Q=PL(2); R=PL(length(PL)-1);
  PQ1=Q-P;
  if ~Closed then
    PQ2=PQ1
  else 
    PQ2=P-R
  end;
  Vp=PQ1/norm(PQ1)+PQ2/norm(PQ2);
  Vp1=Vp/norm(Vp);
  Theta=acos(min(Dotprod(Vz,Vp1),1));
  Vj=Crossprod(Vz,Vp1);
  if norm(Vj)<Eps then
    Vj=Vz
  end;
  Gc1=Rotate3data(Gc0,Vj,Theta);
  CL=list(Translate3data(Gc1,P));
  for J=2:(length(PL)-1)
    P=PL(J); Q=PL(J+1);
    PQ2=Q-P;
    if norm(PQ2)<Eps then
      continue
    end;
    Vp=PQ1/norm(PQ1)+PQ2/norm(PQ2);
    Vp2=Vp/norm(Vp);
    Theta=acos(min(Dotprod(Vp1,Vp2),1));
    Vj=Crossprod(Vp1,Vp2);
    if norm(Vj)<Eps then
      Vj=Vp1
    end;
    Gc2=Rotate3data(Gc1,Vj,Theta);
    CL=lstcat(CL,list(Translate3data(Gc2,P)));
    PQ1=PQ2;
    Vp1=Vp2;
    Gc1=Gc2;
  end;
  if ~Closed then
    Vp2=(Q-P)/norm(Q-P);
    Theta=acos(min(Dotprod(Vp1,Vp2),1));
    Vj=Crossprod(Vp1,Vp2);
    if norm(Vj)<Eps then
      Vj=Vp1
    end;
    Gc3=Rotate3data(Gc1,Vj,Theta);
    CL=lstcat(CL,list(Translate3data(Gc3,Q)))
  end;
  Objname(); // from 140907
  Join=Objjoin();
  Objjoin(1); // upto
  GL1=CL(1);
  for J=2:length(CL)
    GL2=CL(J);
    Dt=Objrecs(GL1,GL2,"-");
    GL1=Dt(2);
    if J==2 then
      GL0=Dt(1)
    end;
  end;
  if ~Closed then
    Objpolygon(CL(1),"-");
    N=length(CL);
    Objpolygon(CL(N),"+")
  else
     Objrecs(GL1,GL0,"-")
  end;
  Out=CL
  OBJJOIN=Join;  // 140907
endfunction
