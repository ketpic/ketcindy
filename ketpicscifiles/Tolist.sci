// 10.01.02

function Out=Tolist(LG)
  Out=list();
  for I=1:length(LG)
    Out($+1)=LG(I);
  end;
endfunction;
