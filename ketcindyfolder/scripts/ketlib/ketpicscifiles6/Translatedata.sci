// 08.05.25 Koshikawa
// 08.09.20
// 15.04.12

function OutL=Translatedata(varargin)
  Nargs=length(varargin);
  ML=varargin(1);
  ML=Flattenlist(ML);
  Tmp=varargin(2);
  if type(Tmp)==1 & length(Tmp)>1
    A=Tmp(1); B=Tmp(2);
  else
    A=Tmp;
    if Nargs>=3
      B=varargin(3);
    else
      B=0;
    end;
  end;
  OutL=[];
  for N=1:length(ML)
    GL=Op(N,ML);
    Out=[];
    for I=1:size(GL,1)
      Tmp=GL(I,:);
      X1=Tmp(1);
      Y1=Tmp(2);
      if Tmp==[%inf,%inf]
        X2=X1;
        Y2=Y1;
      else
        X2=X1+A;
        Y2=Y1+B;
      end
      Out=[Out;X2,Y2];
    end;
    OutL=Mixadd(OutL,Out);
  end;
  if length(OutL)==1
    OutL=Op(1,OutL);
  end;
endfunction
