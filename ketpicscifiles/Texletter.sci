// 10.01.07

function Texletter(varargin)
  global Wfile FID MEMORI;
  Nargs=length(varargin);
  for I=1:3:Nargs
    P=varargin(I);
    X=P(1);
    if type(X)==1
      X=string(X);
    end;
    Y=P(2);
    if type(Y)==1
      Y=string(Y);
    end;
    Houkou=varargin(I+1);
    Mojiretu=varargin(I+2);
    Hset=Houkou;
    Vhoko='c';
    if mtlb_findstr(Hset,'n')~=[]
      Vhoko='n';
    end
    if mtlb_findstr(Hset,'s')~=[]
      Vhoko='s';
    end
    Hhoko='c';
    if mtlb_findstr(Hset,'e')~=[]
      Hhoko='e';
    end
    if mtlb_findstr(Hset,'w')~=[]
      Hhoko='w';
    end
    Hoko=Vhoko+Hhoko;
    CalcWidth(Hoko,Mojiretu);
    CalcHeight(Hoko,Mojiretu);
    Tmp='\put('+X+','+Y+'){\hspace*{\Width}';
    Str=Tmp+'\raisebox{\Height}{'+Mojiretu+'}}%';      
    if Wfile=='default'
      mprintf('%s\n',Str);
    else    
      mfprintf(FID,'%s\n',Str);
    end
  end
endfunction
