// s:2008,05.12
// e:2014.09.08  [A,B] supported
// e:2014.10.24  N,R => N__, ...

function P=Circledata(varargin)
  Nargs=length(varargin);
  C=varargin(1);
  if length(C)==4 then
    ra=norm(C(1:2)-C(3:4));
    C=C(1:2);
    Nop=2;
  else
    ra=varargin(2);
    Nop=3;
  end;
  R__=[0,2*%pi];
  N__=50; // Numpoints
  for I=Nop:Nargs
    Tmp=varargin(I);
    K=mtlb_findstr(Tmp,'=');
    Tmp1=strsplit(Tmp,[K-1,K]);
    Tmp2=ascii(Tmp1(1,1));
    Lhs=char(Tmp2(1));
    Str=Lhs+'__='+Tmp1(3,1);
    execstr(Str);
  end;
  Dt=(R__(2)-R__(1))/N__;
  T=R__(1):Dt:R__(2);
  X=C(1)+ra*cos(T);
  Y=C(2)+ra*sin(T);
  P=[X',Y'];
endfunction
