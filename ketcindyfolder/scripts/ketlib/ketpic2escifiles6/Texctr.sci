//
// 2010.05.15

function Out=Texctr(N)
  if type(N)==1
    Alpha='abcdefghijklmnopqrstuvwxyz';
    Out='ketpicctr'+part(Alpha,N);
  else
    if part(N,1)=='\'
      Out=part(N,2:length(N));
    else
      Out=N;
    end;
  end;
endfunction
