// 09.11.26

function Putrecmark(TbL,Nrg,Mrg,Dt)
  if type(Dt)==10
    N=1; Pos=Dt; Str='';
  else
    N=length(Dt); Pos='l'; Str='\hspace*{2mm}';
  end;  
  for I=1:N
    Str=Str+'\recmark';
    if I<N
      Str=Str+'\hspace{3mm}';
    end;
  end;
  Putcell(TbL,Nrg,Mrg,Pos,Str);
endfunction;

