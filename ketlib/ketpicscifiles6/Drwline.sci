// 08.05.21

function Drwline(varargin)
  global Wfile FID MilliIn PenThick PenThickInit;
  Nall=length(varargin);
  Thick=0;
  Tmp=varargin(Nall);
  if type(Tmp)==1 & length(Tmp)==1
    Thick=round(varargin(Nall)*PenThickInit);
    Str='\special{pn '+string(Thick)+'}%';
    if Wfile=='default'
      mprintf('%s\n',Str);
    else 
      mfprintf(FID,'%s\n',Str);
    end
    Nall=Nall-1;
  end
  for N=1:Nall 
    Tmp=varargin(N);
	Pdata=Flattenlist(Tmp);
    for II=1:length(Pdata)
      Clist=MakeCurves(Op(II,Pdata));
      DinM=Dataindex(Clist);
      for n=1:size(DinM,1)
        Tmp=DinM(n,:);
        Data=Clist(Tmp(1):Tmp(2),:);
        Mojisu=0;
        for I=1:size(Data,1)
          Tmp=Data(I,:);
          X=round(MilliIn*Tmp(1));
          X=string(X);
          Y=-round(MilliIn*Tmp(2));
          Y=string(Y);
          Str='\special{pa '+X+" "+Y+'}';
          if Wfile=='default'    
            mprintf('%s',Str);
          else
            mfprintf(FID,'%s',Str);
          end
          Mojisu=Mojisu+length(Str);
          if Mojisu>80
            if Wfile=='default'
              mprintf('%c\n','%');
            else
              mfprintf(FID,'%c\n','%');
            end
            Mojisu=0;
          end
        end
        if Mojisu~=0
          if Wfile=='default'
            mprintf('%s\n','%');
          else
            mfprintf(FID,'%s\n','%');
          end
        end;
        if Wfile=='default'
          mprintf('%s\n','\special{fp}%');
        else
          mfprintf(FID,'%s\n','\special{fp}%');
        end
      end
    end
  end;
  Str='%';
  if Thick>0
    Tmp=PenThick/PenThickInit; // modified
    Setpen(Tmp);
   end
endfunction

