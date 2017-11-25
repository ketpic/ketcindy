// 10.04.16

function Texendfor(I)
  global TEXFORLEVEL TEXFORLAST
  Last=TEXFORLAST(TEXFORLEVEL);
  Texcom('');
  Texcom('\ifnum'+Texthectr(I)+'<'+Last);
  Texcom('\repeat');
  Texcom('}');
  TEXFORLEVEL=TEXFORLEVEL-1;
  TEXFORLAST=Mixsub(1:(length(TEXFORLAST)-1),TEXFORLAST);
endfunction;
