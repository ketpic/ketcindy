function Out=Setscaling(varargin)
  global LOGX LOGY SCALEX SCALEY;
  Nargs= length(varargin)
  if Nargs==0
    Out=[SCALEY,LOGX,LOGY];
    return;
  end;
  for I=1:Nargs
    Tmp=varargin(I);
    if type(Tmp)==1
      SCALEY=Tmp;
    end;
    if type(Tmp)==10
      if Tmp=="l"
        LOGX=0;
        LOGY=1;
      elseif Tmp=="ll"
        LOGX=1
        LOGY=1
      else
        LOGX=0
        LOGY=0
      end;
    end;
  end;
  Out=[SCALEY,LOGX,LOGY];
endfunction;

