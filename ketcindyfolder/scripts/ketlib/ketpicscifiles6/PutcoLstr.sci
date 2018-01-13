// 10.01.02 for v5

function PutcoLstr(varargin)
  Tb=varargin(1);
  Nr=varargin(2);
  Pos=varargin(3);
  Str=varargin(4);
  Sep='';
  if length(varargin)>4
    Sep=varargin(5);
  end;
  if Sep==''
    for I=1:length(Str)
      Tmp=part(Str,I);
      Putcell(Tb,Nr,I,Pos,Tmp);
    end;
  else
    Ltr='';
    K=1;
    for I=1:length(Str)
      Tmp=part(Str,I);
      if Tmp==Sep
        Putcell(Tb,Nr,K,Pos,Ltr);
        K=K+1;
        Ltr='';
      else
        Ltr=Ltr+Tmp;
      end;
    end;
    if Ltr~=''
      Putcell(Tb,Nr,K,Pos,Ltr);
    end;
  end;
endfunction;