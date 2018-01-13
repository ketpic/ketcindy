// 08.05.19
// 08.05.20 debugged
// 08.06.02

// Structure changed
// 09.10.11

function M=Mixsub(Rg,PL)
  M=list();
  N=Mixlength(PL);
  for I=Rg
    if I>N
      return;
    end;
    M($+1)=PL(I);
  end;
endfunction

