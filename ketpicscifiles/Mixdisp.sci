// 08.05.19

// Structure changed
// 09.10.11
// 10.01.02

function Mixdisp(L)
  if Mixtype(L)==1
    disp(L)
    return;
  end;
  Str=Makeliststr(L);
  disp(Str)
endfunction
