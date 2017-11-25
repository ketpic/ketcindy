// s : 2014.06.22

function Setobjdecimals(n)
  global OBJFMT;
  s1=string(n);
  s2=string(n+3);
  OBJFMT="%"+s2+"."+s1+"f";
endfunction
