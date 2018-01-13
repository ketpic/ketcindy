function C=Strop(Num,Str)
  N=length(Num);
  L=ascii(Str);
  C='';
  for I=1:N
    K=Num(I);
    Tmp=char(L(K));
    C=C+Tmp;
  end
endfunction

