// 10.04.01

function PutcoLexpr(varargin)
  Nargs=length(varargin);
  TbL=varargin(1);
  if type(TbL)~=15
    disp('Tabledata missing')
    return;
  end;
  Ag=varargin(2);
  if type(Ag)==1
    CoL=Ag;
  else    
    Alpha='-ABCDEFGHIJKLMNOPQRSTUVWXYZ';
    Clm=[];
    for I=1:length(Ag)
      C=part(Ag,I:I); 
      Tmp=ascii(C);
      if Tmp>=96
        C=char(Tmp-32);
      end;
      Tmp=mtlb_findstr(C,Alpha)
      if length(Tmp)>0
        Clm=[Clm,Tmp-1];
      end;
    end;
    Nrg=0;
    for I=length(Clm):-1:1
      Tmp=Clm(I);
      Tmp1=length(Clm)-I;
      Nrg=Nrg+Tmp*26^Tmp1;
    end;
    CoL=Nrg;
  end;
  Nr=length(TbL(3))+1;
  K=1;
  Dpos=varargin(3);
  for I=4:Nargs
    if I-3>Nr 
      break;
    end;
    Dt=varargin(I);
    if type(Dt)~=15
      Dt='$'+Dt+'$';
      Putcell(TbL,CoL,K,Dpos,Dt);
      K=K+1;
    else
      N=length(Dt);
      Str='$'+Dt(N)+'$';
      Rrng=[K,K+1];
      Pos=Dpos;
      for J=1:(N-1)
        Tmp=Dt(J);
        if type(Tmp)==1
          Rrng=[K,K+Tmp];
        end;
        if type(Tmp)==10
          Pos=Tmp;
        end;
      end;
      Putcell(TbL,CoL,Rrng,Pos,Str)
      K=Rrng(2);
    end;
  end;
endfunction;
