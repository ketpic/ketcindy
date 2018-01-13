// 08.05.21
// 11.05.25

function Drwline(varargin)
  global Wfile FID MilliIn PenThick PenThickInit;
  Nall=length(varargin);
  Thick=PenThick;
  Tmp=varargin(Nall);
  if type(Tmp)==1 & length(Tmp)==1
    Setpen(Tmp);
    Nall=Nall-1;
  end;
  for N=1:Nall 
    Tmp=varargin(N);
	Pdata=Flattenlist(Tmp);
    for II=1:length(Pdata)  //11.05.25
      Clist=MakeCurves(Op(II,Pdata));
      DinM=Dataindex(Clist);
      for n=1:size(DinM,1)
        Tmp=DinM(n,:);
        Data=Clist(Tmp(1):Tmp(2),:);
        Mojisu=0;
        Tmp=Data(1,:);
        for I=1:size(Data,1)
          Tmp=Data(I,:);
          X=sprintf('%5.5f',Tmp(1));
          Y=sprintf('%5.5f',Tmp(2));
          Pt='('+X+','+Y+')';
          if I==1 then
            Str='\polyline'+Pt;
          else
            Str=Pt;  
          end
          if Wfile=='default'    
            mprintf('%s',Str);
          else
            mfprintf(FID,'%s',Str);
          end;
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
      end;
    end;
    if Wfile=='default'
      mprintf('%c\n','%');
    else
      mfprintf(FID,'%c\n','%');
    end;
  end;
  Setpen(Thick/PenThickInit);
endfunction

