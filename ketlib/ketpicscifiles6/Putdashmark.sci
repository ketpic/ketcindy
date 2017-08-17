// 09.11.26

function Putdashmark(TbL,Nrg,Mrg,Dt)
  N=length(Dt);
  Str='\hspace*{2mm}';
  for I=1:N
    Tmp1=Dt(I);
    if type(Tmp1)==1
      Tmp1=string(Tmp1);
    end;
    Str=Str+'\dashmark{'+Tmp1+'}';
    if I<N
      Str=Str+'\hspace{3mm}';
    end;
  end;
  Putcell(TbL,Nrg,Mrg,'l',Str);
endfunction;

