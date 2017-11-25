// 08.05.21
// 08.11.26
// 09.12.24 (Revised)
// 09.12.29
// 10.01.02

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
    Ookisa=round(Ookisa*varargin(Nall));
    Nall=Nall-2;
  end
  Nagasa=1000/2.54/MilliIn*Nagasa;
  for N=1:Nall
    Tmp=varargin(N);
	Pdata=Flattenlist(Tmp); //
    for II=1:Mixlength(Pdata)
      Clist=MakeCurves(Op(II,Pdata));
      DinM=Dataindex(Clist);
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
        Str='\special{pn '+string(Ookisa)+'}%';
        if Wfile=='default'    
          mprintf('%s\n',Str);
        else
          mfprintf(FID,'%s\n',Str);
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
          Tmp=round(MilliIn*P(1)-1/2*Ookisa*V(1));
          X=string(Tmp);
          Tmp=-round(MilliIn*P(2)-1/2*Ookisa*V(2));
          Y=string(Tmp);
          Str='\special{pa '+X+' '+Y+'}';
          if Wfile=='default'    
            mprintf('%s',Str);
          else
            mfprintf(FID,'%s',Str);
          end
          Tmp=round(MilliIn*P(1)+1/2*Ookisa*V(1));
          X=string(Tmp);
          Tmp=-round(MilliIn*P(2)+1/2*Ookisa*V(2));
          Y=string(Tmp);
          Str='\special{pa '+X+' '+Y+'}';
          if Wfile=='default'    
            mprintf('%s',Str);
            mprintf('%s','\special{fp}');
            if modulo(I,2)==0
              mprintf('%s\n','%');
            end;
          else
            mfprintf(FID,'%s',Str);
            mfprintf(FID,'%s','\special{fp}');
            if modulo(I,2)==0
              mfprintf(FID,'%s\n','%');
            end;
          end
        end
      end
    end;
  end;
  Tmp=PenThick/PenThickInit;
  Setpen(Tmp);
endfunction;
