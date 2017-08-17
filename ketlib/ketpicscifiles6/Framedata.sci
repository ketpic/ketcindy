// 2011.12.18   ( available for list )

function P=Framedata(varargin)
  global XMIN XMAX YMIN YMAX
  VaL=Flattenlist(varargin);
  N=length(VaL);
  if N<=1
    H=1.0*10^(-4);
    PA=[XMIN+H,YMIN+H];
    PB=[XMAX-H,YMIN+H];
    PC=[XMAX-H,YMAX-H];
    PD=[XMIN+H,YMAX-H];
  else
    Tmp=VaL(N);
    if type(Tmp)==1 & length(Tmp)==1
      Dy=Tmp;
      Dx=Dy;
      Tmp=VaL(N-1);
      if type(Tmp)==1 & length(Tmp)==1
        Dx=Tmp;
      end;
      Tmp=VaL(1);
      X=Tmp(1); Y=Tmp(2);
      X1=X-Dx; X2=X+Dx;
      Y1=Y-Dy; Y2=Y+Dy;
    else
      Tmp=VaL(1);
      X1=Tmp(1); X2=Tmp(2);
      Tmp=VaL(2);
      Y1=Tmp(1); Y2=Tmp(2);
    end;
    PA=[X1,Y1]; PB=[X2,Y1];
    PC=[X2,Y2]; PD=[X1,Y2];
  end;
  P=Listplot(PA,PB,PC,PD,PA)
endfunction
