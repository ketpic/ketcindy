// 08.05.18

// Structure changed
// 09.10.11

function TF=Member(A,L)
  if Mixtype(L)>1
    N=Mixlength(L);
  else
    N=length(L);
  end
  for I=1:N
    Tmp=Op(I,L);
    if A==Tmp
      TF=%t
      return
    end
  end
  TF=%f
endfunction

