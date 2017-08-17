// 08.07.11
// 08.10.16

function Out=ProjcoordCurve(Curve)
  global PHI THETA;
  SP=sin(PHI); CP=cos(PHI);
  ST=sin(THETA); CT=cos(THETA);
  Out=[];
  for J=1:size(Curve,1)
    P=Curve(J,:);
    x=P(1); y=P(2); z=P(3);
    Xz=-x*SP+y*CP;
    Yz=-x*CP*CT-y*SP*CT+z*ST;
    Zz=x*CP*ST+y*SP*ST+z*CT;
    Out=[Out;Xz,Yz,Zz];
  end;
endfunction;

