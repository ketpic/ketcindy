//
// 09.12.25

function Expr(varargin)
  global Wfile FID MEMORI;
  Nargs=length(varargin);
  for I=1:3:Nargs
    Tmp=varargin(I);
    P=Doscaling(Tmp);
    X=P(1);
    Y=P(2);
    Houkou=varargin(I+1);
    Mojiretu='$'+varargin(I+2)+'$';
    Hset=Houkou;
    Vhoko='c';
    if mtlb_findstr(Hset,'n')~=[]
      Vhoko='n'; Y=Y+MEMORI;
    end
    if mtlb_findstr(Hset,'s')~=[]
      Vhoko='s'; Y=Y-MEMORI;
    end
    Hhoko='c';
    if mtlb_findstr(Hset,'e')~=[]
      Hhoko='e'; X=X+MEMORI;
    end
    if mtlb_findstr(Hset,'w')~=[]
      Hhoko='w'; X=X-MEMORI;
    end
    Hoko=Vhoko+Hhoko;
    Suu='+-.0123456789';
    SuuL=Suu;
    Hcode=ascii(Houkou);
    J=1; Dstr='';
    while J<=length(Houkou)
      Tmp=char(Hcode(J));
      if mtlb_findstr(SuuL,Tmp)~=[]
        if Dstr=='' 
          Hk=char(Hcode(J-1));
        end
        Dstr=Dstr+Tmp;
      else
        if Dstr~=''
          Nmbr=msscanf(Dstr,'%f');
          D=Nmbr*MEMORI;
          if Hk=='n'
            Y=Y+D;
          end
          if Hk=='s'
            Y=Y-D;
          end
          if Hk=='e'
            X=X+D;
          end
          if Hk=='w'
            X=X-D;
          end
          Dstr='';
        end
      end
      J=J+1;
    end
    if Dstr~=''
      Nmbr=msscanf(Dstr,'%f');
      D=Nmbr*MEMORI;
      if Hk=='n'
        Y=Y+D;
      end
      if Hk=='s'
        Y=Y-D;
      end
      if Hk=='e'
        X=X+D;
      end
      if Hk=='w'
        X=X-D;
      end
    end
    CalcWidth(Hoko,Mojiretu);
    CalcHeight(Hoko,Mojiretu);
    Tmp='){\hspace*{\Width}';
    Str=Tmp+'\raisebox{\Height}{'+Mojiretu+'}}';      
    if Wfile=='default'
      mprintf('%s','\put(');
      mprintf('%6.4f%s%6.4f',X,',',Y);
      mprintf('%s%s\n',Str,'%');
      mprintf('%s\n','%');
    else    
      mfprintf(FID,'%s','\put(');
      mfprintf(FID,'%6.4f%s%6.4f',X,',',Y);
      mfprintf(FID,'%s%s\n',Str,'%');
      mfprintf(FID,'%s\n','%');   
    end
    if Wfile=='default'
      mprintf('%s\n','%');
    else    
      mfprintf(FID,'%s\n','%');   
    end
  end
endfunction

