function Makehasen(Figdata,Sen,Gap,Ptn)
  global Wfile FID;
  Eps=10.0^(-6);
  Clist=MakeCurves(Figdata);
  DinM=Dataindex(Clist);
  for N=1:size(DinM,1)
    Tmp=DinM(N,:);
    Data=Clist(Tmp(1):Tmp(2),:);
    Dtall=size(Data,1);
    Len=0;
    Lenlist=[0];
    for I=2:Dtall
      Len=Len+Vecnagasa(Data(I,:)-Data(I-1,:));
      Lenlist=[Lenlist,Len];
    end
    Lenall=Lenlist(Dtall);
    if Lenall==0
      continue
    end
    Kari=(Sen+Gap)*0.1;
    Naga=Sen*0.1;
    Tobi=Gap*0.1;
    if Vecnagasa(Data(1,:)-Data(Dtall,:))<Eps
      Nsen=max(ceil(Lenall/Kari),3);
      SegUnit=Lenall/Nsen;
      Naga=SegUnit*Sen/(Sen+Gap);
      Tobi=SegUnit*Gap/(Sen+Gap);
      SegList=[0:SegUnit:(Nsen-1)*SegUnit];
    else
      if Ptn==0
        Nsen=max(ceil((Lenall+Tobi)/Kari),3);
        SegUnit=Lenall*(Sen+Gap)/(Nsen*Sen+(Nsen-1)*Gap);
        Naga=SegUnit*Sen/(Sen+Gap);
        Tobi=SegUnit*Gap/(Sen+Gap);
        SegList=[0:SegUnit:(Nsen-1)*SegUnit];
      else
        Nsen=max(ceil((Lenall+Naga)/Kari),3);
        SegUnit=Lenall*(Sen+Gap)/((Nsen-1)*Sen+Nsen*Gap);
        Naga=SegUnit*Sen/(Sen+Gap);
        Tobi=SegUnit*Gap/(Sen+Gap);
        SegList=[Tobi:SegUnit:Tobi+(Nsen-2)*SegUnit];
      end
    end
    Hajime=1; Owari=1;
    Mojisu=0;
    for I=1:length(SegList)
      Len=SegList(I);
      J=Owari;
      while Len>=Lenlist(J)-Eps
        if J==Dtall
          break
        end
        J=J+1;
      end
      Hajime=J-1;
      J=Hajime;
      while Len+Naga>Lenlist(J)-Eps
        if J==Dtall
          break
        end
        J=J+1
      end
      Owari=J-1;
      T=(Len-Lenlist(Hajime))...
          /(Lenlist(Hajime+1)-Lenlist(Hajime));
      P=Data(Hajime,:)+T*(Data(Hajime+1,:)-Data(Hajime,:));
      X=string(round(MilliIn*P(1)));
      Y=string(-round(MilliIn*P(2)));
      Str='\special{pa '+X+' '+Y+'}';
      if Wfile=='default'
        mprintf('%s',Str);
      else
        mfprintf(FID,'%s',Str);
      end;
      Mojisu=Mojisu+length(Str);
      for J=Hajime+1:Owari
        P=Data(J,:);
        X=string(round(MilliIn*P(1)));
        Y=string(-round(MilliIn*P(2)));
        Str='\special{pa '+X+' '+Y+'}';
        if Wfile=='default'
          mprintf('%s',Str);
        else
          mfprintf(FID,'%s',Str);
        end;
        Mojisu=Mojisu+length(Str);
      end
      T=(Len+Naga-Lenlist(Owari))...
          /(Lenlist(Owari+1)-Lenlist(Owari));
      P=Data(Owari,:)+T*(Data(Owari+1,:)-Data(Owari,:));
      X=string(round(MilliIn*P(1)));
      Y=string(-round(MilliIn*P(2)));
      Str1='\special{pa '+X+' '+Y+'}';
      Str2='\special{fp}';
      if Wfile=='default'
        mprintf('%s',Str1);
        mprintf('%s',Str2);        
      else
        mfprintf(FID,'%s',Str1);
        mfprintf(FID,'%s',Str2);
      end;
      Mojisu=Mojisu+length(Str1)+length(Str2);
      if Mojisu>80
        if Wfile=='default'
          mprintf('%s\n','%');
        else
          mfprintf(FID,'%s\n','%');
        end;
        Mojisu=0;
      end
    end
  end
  if Wfile=='default'
    mprintf('%s\n%s\n','%','%');
  else
    mfprintf(FID,'%s\n%s\n','%','%');
  end;
endfunction

