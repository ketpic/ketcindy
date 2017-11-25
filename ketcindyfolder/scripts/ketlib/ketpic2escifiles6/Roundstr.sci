//  10.11.04

function Out=Roundstr(X,Ni,Nf)
  Na=Ni+1+Nf;
  Fmt='%'+string(Na)+'.'+string(Nf)+'f';
  Out=sprintf(Fmt,X);
endfunction;
