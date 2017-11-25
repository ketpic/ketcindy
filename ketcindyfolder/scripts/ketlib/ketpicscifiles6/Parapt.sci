// 08.07.11
// 10.01.02

function Out=Parapt(P)
  global PHI THETA
  x=P(1);
  y=P(2);
  z=P(3);
  Xz=-x*sin(PHI)+y*cos(PHI);
  Yz=-x*cos(PHI)*cos(THETA)-y*sin(PHI)*cos(THETA)+z*sin(THETA);
  Out=[Xz,Yz];
endfunction
