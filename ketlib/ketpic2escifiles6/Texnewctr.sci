// 10.01.21

function Texnewctr(N)
  if type(N)==10
    Str='\newcounter{'+N+'}';
    Texcom(Str);
  else
    for I=N
      Str='\newcounter{'+Texctr(I)+'}';
      Texcom(Str);
    end;
  end;
endfunction;
