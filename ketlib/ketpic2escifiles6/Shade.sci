// 08.05.22
// 09.12.25
// 11.05.27 (for pdflatex )
// 17.01.09 (shade, thickness )

function Shade(varargin)
  global Wfile FID MilliIn;
  // 2nd arg is a color name or '[..]{  }' 
  Nargs=length(varargin);
  Iroflg=0;
  if Nargs>1 
    Iroflg=1;
    Iro=varargin(Nargs);
    if type(Iro)==10 then
      if length(strchr(Iro,"{"))>0
        Str="{\color"+Iro;
      else
        Str="{\color{"+Iro+"}";
      end;
    else
      if length(Iro)==4
        Str='{\color[cmyk]{';
      else
        Str='{\color[rgb]{';
      end;
      for J=1:length(Iro)
        Str=Str+string(Iro(J));
        if J<length(Iro) then
          Str=Str+',';
        end
      end
      Str=Str+'}';
    end;
    if Wfile=='default'
      mprintf('%s\n',Str+'%');
    else
      mfprintf(FID,'%s\n',Str);
    end;
  end;
  Mojisu=0; //
  Tmp=varargin(1);
  Data=Kyoukai(Tmp);
  for I=1:length(Data)
    PL=Op(I,Data);
    for J=1:size(PL,1)
      P=Doscaling(PL(J,:));
      X=sprintf('%5.5f',P(1));
      Y=sprintf('%5.5f',P(2));
      Pt='('+X+','+Y+')';
      if J==1 then
        Str='\polygon*'+Pt;
      else
        Str=Pt;  
      end
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
      end;
    end;
  end;
  if Iroflg==1
    Str='}%';
    if Mojisu>0
      Fmt='\n%s\n';
    else
      Fmt='%s\n';
    end;
    if Wfile=='default'
      mprintf(Fmt,Str);
    else
      mfprintf(FID,Fmt,Str);
    end;
  end;
endfunction
