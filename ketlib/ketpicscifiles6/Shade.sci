//
// 08.05.22
// 09.12.25
// 17.01.09 (available colorname or colorcode as 2nd arg)

function Shade(varargin)
  global Wfile FID MilliIn;
  Nargs=length(varargin);
  Iroflg=0;
  Kosa=1;
  if Nargs>1 
    Iro=varargin(Nargs);
    if type(Iro)==10
      Iroflg=1;
      if length(strchr(Iro,"{"))>0
        Str="{\color"+Iro;
      else
        Str="{\color{"+Iro+"}";
      end;
    else
      if length(Iro)==1
        Kosa=Iro;
      else
        Iroflg=1;
        if length(Iro)==4
          Str='{\color[cmyk]{';
        else
          if length(Iro)==3
            Str='{\color[rgb]{';
          end;
        end;
        for J=1:length(Iro)
          Str=Str+string(Iro(J));
          if J<length(Iro)
            Str=Str+',';
          end
        end
        Str=Str+'}';
      end;
    end;
    if Iroflg==1
      if Wfile=='default'
        mprintf('%s\n',Str+'%');
      else
        mfprintf(FID,'%s\n',Str+'%');
      end;
    end;
  end;
  Tmp=varargin(1);
  Data=Kyoukai(Tmp);
  for I=1:length(Data)
    PL=Op(I,Data);
    Mojisu=0;
    for J=1:size(PL,1)
      P=Doscaling(PL(J,:));
      X=string(round(MilliIn*P(1)));
      Y=string(-round(MilliIn*P(2)));
      Str='\special{pa '+X+' '+Y+'}';
      if Wfile=='default'
        mprintf('%s',Str);
      else
        mfprintf(FID,'%s',Str);
      end
      Mojisu=Mojisu+length(Str);
      if Mojisu>80
        if Wfile=='default'
          mprintf('%s\n','%');
        else
          mfprintf(FID,'%s\n','%');
        end
        Mojisu=0;
      end
    end
    Str1='\special{sh '+string(Kosa)+'}';
    Str2='\special{ip}%';
    if Wfile=='default'
      mprintf('%s',Str1);
      mprintf('%s\n',Str2);
    else
      mfprintf(FID,'%s',Str1);
      mfprintf(FID,'%s\n',Str2);
    end
  end
  if Iroflg==1
    Str='}%';
    Fmt='%s\n';
     if Wfile=='default'
      mprintf(Fmt,Str);
    else
      mfprintf(FID,Fmt,Str);
    end;
  end;
endfunction
