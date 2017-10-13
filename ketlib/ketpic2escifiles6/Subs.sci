//
// 08.06.04

function V=Subs(SbstrL,StrF)
  Str=StrF;
  if type(StrF)==2
    Str=pol2str(StrF);
  end
  V=StrF;
  for N=1:size(SbstrL,2)
    Sbstr=SbstrL(1,N);
    I=mtlb_findstr(Sbstr,'=');
    Tmp=strsplit(Sbstr,I);
    SbA=Tmp(1);
    SbA=Op(1:length(SbA)-1,SbA);
    SbB=Tmp(2);
    V=strsubst(V,SbA,SbB);
  end
  V=evstr(V);
endfunction

