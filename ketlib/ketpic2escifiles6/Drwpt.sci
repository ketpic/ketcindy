//
// 08.05.31
// 09.12.25
// 10.01.01
// 11.05.26  (for pdflatex)

function Drwpt(varargin)
  global Wfile FID TenSize TenSizeInit MilliIn;
  Nargs=length(varargin);
  All=Nargs;
  Tmp=varargin(All);
  Iro=[0,0,0,1];
  Iroflg=0;
  if type(Tmp)==10 then
    Iro=Ratiocmyk(Tmp);
    Iroflg=1;
    All=All-1;
  end
  Tmp=varargin(All);
  Kosa=1;
  if type(Tmp)==1 & length(Tmp)==1
    Kosa=Tmp; All=All-1;
  end;
  Ra=TenSize*1000/2.54/MilliIn;
  if Iroflg>0
    Str='{\color[cmyk]{';
    for J=1:4
      Str=Str+string(Kosa*Iro(J));
      if J<4 then
        Str=Str+',';
      end
    end
    Str=Str+'}%';
    if Wfile=='default'
      mprintf('%s\n',Str);
    else
      mfprintf(FID,'%s\n',Str);
    end
  end;
  Mojisu=0;
  for II=1:All
    Tmp=varargin(II);
	MS=Flattenlist(Tmp);  // 11.05.29
    for I=1:length(MS);
      P=Op(I,MS);
      if InWindow(P)~='i'
        continue
      end
      P=Doscaling(P);
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
          mprintf('%s\n','%');
        else
          mfprintf(FID,'%s\n','%');
        end
        Mojisu=0;
      end
    end
  end;
  Str="";
  if Iroflg>0
    Str='}';
  end;
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
  Mojisu=0;
  if Iroflg>0
    Str='{\color[cmyk]{';
    for J=1:4
      Str=Str+string(Iro(J));
      if J<4 then
        Str=Str+',';
      end
    end
    Str=Str+'}%';
    if Wfile=='default'
      mprintf('%s\n',Str);
    else
      mfprintf(FID,'%s\n',Str);
    end;
    Mojisu=0;
  end;
  for II=1:All
    Tmp=varargin(II);
	MS=Flattenlist(Tmp);  // 11.05.29
    for I=1:length(MS);
      P=Op(I,MS);
      if InWindow(P)~='i'
        continue
      end
      P=Doscaling(P);
      X=sprintf('%5.5f',P(1));
      Y=sprintf('%5.5f',P(2));
      Str='\put('+X+','+Y+'){\circle{'+sprintf('%6.6f',Ra)+'}}';
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
  end
  Str="%";
  if Iroflg>0
    Str='}%';
  end;
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
endfunction
