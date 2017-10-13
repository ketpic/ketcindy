//
// 09.12.25
// 10.01.01
// 10.12.02  ( debugged for norm()==0 )

function Outdata=MakeCurves(varargin)
  Figdata=varargin(1);
  Ptout=1;
  if length(varargin)>=2
    Ptout=varargin(2);
  end
  Eps=10.0^(-6);
  IndM=Dataindex(Figdata);
  Atos=[];
  for Nd=1:size(IndM,1)
    Tmp=IndM(Nd,:);
    Motos=Figdata(Tmp(1):Tmp(2),:);
    All=size(Motos,1);
    if size(Motos,1)==1
      if InWindow(Motos)=='o'
        continue;
      end;
      if Ptout==1
        Drwpt(Motos(1,:));
      else
        Atos=[Atos;%inf,%inf;Doscaling(Motos)];
      end
      continue
    end
    Crv=[];
    for I=2:All
      P=Motos(I-1,:);
      Q=Motos(I,:);
      Snbn=MeetWindow(P,Q);
      if Snbn==[]
        if Crv~=[]
          Atos=[Atos;%inf,%inf;Doscaling(Crv)];
          Crv=[];
        end
      else
        if norm(Snbn(1,:)-Snbn(2,:))<Eps   // 10.12.02
          continue;
        end;
        if Crv==[]
          Crv=Snbn
        else
          Tmp=Crv(size(Crv,1),:);
          if norm(Tmp-Snbn(1,:))<Eps
            Crv=[Crv;Snbn(2,:)];
          else
            Atos=[Atos;%inf,%inf;Doscaling(Crv)];
            Crv=Snbn;
          end
        end
      end
    end
    if size(Crv,1)>=2
      Atos=[Atos;%inf,%inf;Doscaling(Crv)];
    end
  end
  Outdata=Atos(2:size(Atos,1),:); 
endfunction;
