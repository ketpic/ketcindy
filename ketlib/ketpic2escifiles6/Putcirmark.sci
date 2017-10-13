// 09.11.26

function Putcirmark(TbL,Nrg,Mrg,Dt)
  if type(Dt)==10
    N=1; Pos=Dt; Str='';
  else
    N=length(Dt); Pos='l'; Str='\hspace*{2mm}';
  end;  
  for I=1:N
    Tmp1=Dt(I);
    Str=Str+'\cirmark';
    if I<N
      Str=Str+'\hspace{3mm}';
    end;
  end;
  Putcell(TbL,Nrg,Mrg,Pos,Str);
endfunction;

