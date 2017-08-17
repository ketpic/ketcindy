// e : 2015.11.15
function Out=Ovaldata(varargin)
  global XMIN XMAX YMIN YMAX
  Nargs=length(varargin);
  if Nargs<=1
    Eps=1.0*10^(-4);
    C=[(XMIN+XMAX)/2,(YMIN+YMAX)/2];
    Dx=XMAX-C(1)-Eps;
    Dy=YMAX-C(2)-Eps;
    N=1;
  else
    C=varargin(1);
    Dx=varargin(2);
    Dy=varargin(3);
    N=4;
  end;
  Rc=0.2;
  if N<=Nargs
    Rc=varargin(N)*Rc; // 15.11.15
  end;
  Out=[];
  P=C+[Dx-Rc,Dy-Rc];
  Tmp1=Circledata(P,Rc,'R=[0,%pi/2]','N=10');
  Tmp2=Listplot(C+[Dx-Rc,Dy],C+[0,Dy]);
  Tmp3=Listplot(C+[Dx,0],C+[Dx,Dy-Rc]);
  G=Joincrvs(Tmp3,Tmp1,Tmp2);
  Tmp=Reflectdata(G,[C,C+[0,1]]);
  G=Joincrvs(G,Tmp);
  Tmp=Reflectdata(G,[C,C+[1,0]]);
  Out=Joincrvs(G,Tmp);
endfunction;
