//
// 08.05.23
// 09.09.18
// 13.05.03  list of points is outputted

function PL=Pointdata(varargin)
  Nargs=length(varargin);
  PL=list();
  for I=1:Nargs
    DL=varargin(I);
    DL=Flattenlist(DL);
    for K=1:length(DL);
      Dt=DL(K);
      for J=1:size(Dt,1)
        Tmp=Dt(J,:);
        if Tmp(1)~=%inf then
          PL($+1)=Tmp;
        end
      end
    end;
  end;
  if length(PL)==1
    PL=PL(1);
  end;
endfunction
