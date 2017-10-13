// 10.01.21

function Texrenewcmd(varargin)
  Nargs=length(varargin);
  Str=varargin(1);
  S='\renewcommand{'+Str+'}';
  if Nargs>1
    Tmp=string(varargin(2));
    S=S+'['+Tmp+']';
  end;
  if Nargs>2
    Tmp=varargin(3);
    if type(Tmp)==1
      Tmp=string(Tmp);
    end;
    S=S+'['+Tmp+']';
  end;
  S=S+'{';
  Texcom(S);
endfunction
