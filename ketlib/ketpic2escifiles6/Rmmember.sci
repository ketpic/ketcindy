// 11.01.14   New

function Out=Rmmember(L,Rm)
  if type(L)==1
    Out=[];
  end;
  if type(L)==15
    Out=list();
  end;
  for J=1:length(L)
    Tmp=L(J);
    if ~Member(Tmp,Rm)
      Out($+1)=Tmp;
    end;
  end;
  if type(L)==1 & size(L,1)==1
    Out=Out';
  end;
endfunction;

