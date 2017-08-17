// 08.05.21
// 08.11.26
// 09.12.24 (Revised)
// 09.12.29
// 10.01.02
// 11.05.27

function Dottedline(varargin)
  global Wfile FID MilliIn PenThick PenThickInit
  Nall=length(varargin);
  Nagasa=0.1;
  Ookisa=PenThick;
  I=Nall;
  Tmp=varargin(I);
  while type(Tmp)==1 & length(Tmp)==1
    I=I-1;
    Tmp=varargin(I);
  end
  if I==Nall-1
    Nagasa=Nagasa*varargin(Nall);
    Nall=Nall-1;
  end
  if I==Nall-2
    Nagasa=Nagasa*varargin(Nall-1);
    Ookisa=Ookisa*varargin(Nall);
    Nall=Nall-2;
  end
  Nagasa=1000/2.54/MilliIn*Nagasa;
  Ra=Ookisa/MilliIn;
  for N=1:Nall
    Tmp=varargin(N);
	Pdata=Flattenlist(Tmp); //
    for II=1:length(Pdata)
      Clist=MakeCurves(Op(II,Pdata));
      DinM=Dataindex(Clist);
      Mojisu=0;
      for n=1:size(DinM,1)
        Tmp=DinM(n,:);
        Data=Clist(Tmp(1):Tmp(2),:);
        Len=0;
        Lenlist=[0];
        for I=2:size(Data,1)
          Len=Len+Vecnagasa(Data(I,:)-Data(I-1,:));
          Lenlist=[Lenlist,Len];
        end
        Lenall=Lenlist(length(Lenlist));
        if Lenall==0
          continue
        end
        Naga=Nagasa;
        Nten=round(Lenall/Naga)+1;
        if Nten>1
          Seg=Lenall/(Nten-1);
        else
          Seg=Lenall;
        end
        Eps=10^(-6)*Seg;
        PPd=[];
        Hajime=1;
        for I=0:Nten-1
          Len=Seg*I;
          if I>0
            J=Hajime;
            while Len>=Lenlist(J)+Eps
              J=J+1;
            end
            Hajime=J-1;
          end
          T=(Len-Lenlist(Hajime))...
            /(Lenlist(Hajime+1)-Lenlist(Hajime));
          P=Data(Hajime,:)+T*(Data(Hajime+1,:)...
            -Data(Hajime,:));
          PPd=[PPd;P];
          if I==Nten-1
            if norm(P-Data(1,:))<Eps
              continue
            end
          end
        end
        for I=1:size(PPd,1)
          P=PPd(I,:);
          if size(PPd,1)==1
            V=[1,0];
          elseif I==1
            Tmp=PPd(I+1,:)-P;
            V=1/norm(Tmp)*Tmp;
          elseif I==size(PPd,1)
            Tmp= P-PPd(I-1,:);
            V=1/norm(Tmp)*Tmp;
          else
            Tmp1=PPd(I+1,:)-P;
            Tmp2=P-PPd(I-1,:);
            Tmp3=1/norm(Tmp1)*Tmp1+1/norm(Tmp2)*Tmp2;
            V=1/norm(Tmp3)*Tmp3;
          end;
          X=sprintf('%5.5f',P(1));
          Y=sprintf('%5.5f',P(2));
          Str='\put('+X+','+Y+'){\circle*{'+sprintf('%6.6f',Ra)+'}}';
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
      end
    end;
	if Mojisu>0
      if Wfile=='default'
        mprintf('%c\n','%');
      else
        mfprintf(FID,'%c\n','%');
      end:
    end;
  end;
endfunction;
