// 08.05.14 Data Structure
// 08.04.15 List ex  N=1:3
// 08.05.16 List of MixL
// 08.05.18 Debugged
// 08.05.19 Changed
// 08.08.17

// Structure changed
// 09.10.11

function D=Mixop(N,PL)
  D=[];
  if Mixtype(PL)==1
    D=PL;
    return;
  end;
  if type(N)~=1 | length(N)>1 | N>Mixlength(PL)
    return
  end;
  D=PL(N);
endfunction

