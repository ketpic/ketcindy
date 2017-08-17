// 13.08.13

function Out=Cancoordpara(P)
  global PHI THETA;
  Xz=P(1); Yz=P(2); Zz=P(3);
  X=-Xz*sin(PHI)-Yz*cos(PHI)*cos(THETA)+Zz*cos(PHI)*sin(THETA);
  Y=Xz*cos(PHI)-Yz*sin(PHI)*cos(THETA)+Zz*sin(PHI)*sin(THETA);
  Z=Yz*sin(THETA)+Zz*cos(THETA);
  Out=[X,Y,Z];
endfunction

