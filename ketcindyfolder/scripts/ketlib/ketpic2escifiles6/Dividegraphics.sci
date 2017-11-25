// 08.05.31
// 10.01.01
// 11.01.07

function OutL=Dividegraphics(Pd)
  if length(Pd)==0
    OutL=Pd;
    return;
  end;
  DtL=Flattenlist(Pd);
  OutL=list();
  for J=1:length(DtL)
    Dt= DtL(J);
    Ndm=Dataindex(Dt);
    for I=1:size(Ndm,1)
      Fd=Dt(Ndm(I,1):Ndm(I,2),:);
      OutL($+1)=Fd;
    end;
  end;
endfunction;
