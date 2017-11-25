// s : 2014.06.22

function Out=Writeobjpoint(P)
  global OBJFMT OBJSCALE NPOINT;
  X=sprintf(OBJFMT,P(1)*OBJSCALE);
  Y=sprintf(OBJFMT,P(2)*OBJSCALE);
  Z=sprintf(OBJFMT,P(3)*OBJSCALE);
  Str="v "+X+" "+Y+" "+Z;
  Printobjstr(Str)
  NPOINT=NPOINT+1
  Out=NPOINT;
endfunction
