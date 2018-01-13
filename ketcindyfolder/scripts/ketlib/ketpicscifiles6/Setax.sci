// 08.08.08
// 09,02.27

function Out=Setax(varargin)
  global ZIKU XNAME XPOS YNAME YPOS ONAME OPOS ARROWSIZE;
  Nargs=length(varargin);
  if Nargs==0  
    if ZIKU=='line'
      Tmp=','
    else
      Tmp='(Arrowsize='+string(ARROWSIZE)+'),'
    end;
    Str=...
       ZIKU+Tmp+...
       XNAME+','+XPOS+','+YNAME+','+...
       YPOS+','+ONAME+','+OPOS;
    Out=Str;
    disp(Str);
    return;
  end;
  ArgL=[];
  Is=1;
  Tmp=varargin(1);
  if type(Tmp)==1 & length(Tmp)==1
    Is=varargin(1);
    ArgL=[];
    for I=1:Is-1
      ArgL=[ArgL,''];
    end
    for I=2:Nargs
      ArgL=[ArgL,varargin(I)];
    end
  else
    if Nargs==1 
      ArgL=[varargin(1)];
    else
      Tmp=varargin(2);
      if type(Tmp)==1 & length(Tmp)==1
        ARROWSIZE=Tmp;
        ArgL=[varargin(1)];
        for I=3:Nargs
          ArgL=[ArgL,varargin(I)];
        end;
      else
        ArgL=[];
        for I=1:Nargs
          ArgL=[ArgL,varargin(I)];
        end;
      end
    end
  end
  for I=size(ArgL,2)+1:7
    ArgL=[ArgL,''];
  end
  Zk=ArgL(1);
  if Zk~='' 
    ZL=msscanf(Zk,'%c%f');
    Zk=ZL(1);
    if length(ZL)>1   // modified at 080807
      ARROWSIZE=ZL(2);
    end
  end
  Xn=ArgL(2); Xp=ArgL(3);
  Yn=ArgL(4); Yp=ArgL(5);
  Genn=ArgL(6); Genp=ArgL(7);
  if Zk~='' 
    C=Zk;
    if C=='a' 
      ZIKU='arrow';
    else
      ZIKU='line'; 
    end
  end
  if Xn~=''
    XNAME='$'+Xn+'$'
  end
  if Xp~=''  
    XPOS=Xp 
  end
  if Yn~=''
    YNAME='$'+Yn+'$'
  end
  if Yp~=''
    YPOS=Yp
  end
  if Genn~=''
    ONAME=Genn
  end
  if Genp~=''
    OPOS=Genp
  end
  if ZIKU=='line'
    Tmp=','
  else
    Tmp='(Arrowsize='+string(ARROWSIZE)+'),'
  end;
  Str=...
     ZIKU+Tmp+...
     XNAME+','+XPOS+','+YNAME+','+...
     YPOS+','+ONAME+','+OPOS;
  Out=Str;
endfunction;
