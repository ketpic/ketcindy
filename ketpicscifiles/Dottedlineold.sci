// 08.05.21
// 08.11.26

function Dottedline(varargin)
  global Wfile FID MilliIn;
  Nall=length(varargin);
  Nagasa=0.1;
  Ookisa=0.02*0.5;
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
  Ookisa=1000/2.54/MilliIn*Ookisa;
  CL=[];
  Nk=4;
  Tmp=Framedata([0,0],Ookisa/2);
  CL=Tmp;
  for N=1:Nall
    Pdata=varargin(N);
    if Mixtype(Pdata)==1
      Pdata=MixS(Pdata);
    end
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
          if I==Nten-1
            if Vecnagasa(P-Data(1,:))<Eps
              continue
            end
          end
          PL=[];
          for J=1:size(CL,1)
            PL=[PL;P+CL(J,:)];
          end
          Mojisu=0;
          for J=1:size(PL,1)
            Q=PL(J,:);
            X=round(MilliIn*Q(1));
            X=string(X);
            Y=-round(MilliIn*Q(2));
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
          Str='\special{sh 1}'+'\special{fp}%'
          if Wfile=='default'
            mprintf('%s\n',Str);
          else
            mfprintf(FID,'%s\n',Str);
          end
        end
      end
    end
  end
endfunction
