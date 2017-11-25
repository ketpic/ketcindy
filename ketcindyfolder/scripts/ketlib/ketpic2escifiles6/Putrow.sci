// 09.12.06
// 10.01.26

function Putrow(varargin)
  Nargs=length(varargin);
  TbL=varargin(1);
  if type(TbL)~=15
    disp('Tabledata missing')
    return;
  end;
  Row=varargin(2);
  Nr=length(TbL(2))+1;
  K=1;
  Dpos=varargin(3);
  for I=4:Nargs
    if I-3>Nr 
      break;
    end;
    Dt=varargin(I);
    if type(Dt)~=15
      Putcell(TbL,K,Row,Dpos,Dt);
      K=K+1;
    else
      N=length(Dt);
      Str=Dt(N);
      Crng=[K,K+1];
      Pos=Dpos;
      for J=1:(N-1)
        Tmp=Dt(J);
        if type(Tmp)==1
          Crng=[K,K+Tmp];
        end;
        if type(Tmp)==10
          Pos=Tmp;
        end;
      end;
      Putcell(TbL,Crng,Row,Pos,Str)
      K=Crng(2);
    end;
  end;
endfunction;
