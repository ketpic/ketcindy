// 15.05.04

function Definecolor(Name,Data)
  Tmp1=size(Data,2);
  if Tmp1<3 | Tmp1>4
    disp("Size of data should be 3 or 4.");
    return;
  end;
  if Tmp1==4
    Tp="cmyk"
  else
    Tp="rgb"
  end;
  Tmp="";
  for J=1:Tmp1
    Tmp=Tmp+string(Data(J));
    if J<Tmp1
      Tmp=Tmp+",";
    end;
  end
  Tmp="\definecolor{"+Name+"}{"+Tp+"}{"+Tmp+"}";
  Texcom(Tmp);
endfunction;
