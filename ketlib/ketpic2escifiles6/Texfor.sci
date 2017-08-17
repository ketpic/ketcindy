//  10.04.16
//  10.05.12
//  10.10.20 ( available for numeric )

function Texfor(I,First,Last)
  global TEXFORLEVEL TEXFORLAST
  TEXFORLEVEL=TEXFORLEVEL+1;
  Texsetctr(I,'0');
  Texsetctr(I,string(First)+'-1');
  Texcom('');
  Texcom('{');
  Texcom('\loop');
  Texsetctr(I,'+1');
  TEXFORLAST($+1)=string(Last);
endfunction;
