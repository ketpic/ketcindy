// 08.05.30

function PL=Calcfun(Siki,Namae,Atai)
  execstr(Namae+'=Atai');
  Tmp='XY='+Siki;
  execstr(Tmp);
  PL=[Atai(:,1),XY(:,2)];  
endfunction

