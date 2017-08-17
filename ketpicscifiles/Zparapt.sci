// 08.07.11

function Out=Zparapt(P)
  global PHI THETA;
  x=P(1); y=P(2); z=P(3);
  Out=x*cos(PHI)*sin(THETA)+y*sin(PHI)*sin(THETA)+z*cos(THETA);
endfunction

