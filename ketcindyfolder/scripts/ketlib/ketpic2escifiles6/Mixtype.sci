// 08.05.19

// Structure changed
// 09.10.11

function T=Mixtype(D)
  if type(D)~=15
    T=1;
    return;
  end;
  for I=1:length(D)
    if type(D(I))==15
      T=3;
      return;
    end;
  end;
  T=2;
endfunction

