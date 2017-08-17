//
// 08.05.22
// 09.12.25
// 11.05.27 (for pdflatex )

function Shade(varargin)
  global Wfile FID MilliIn;
  Nargs=length(varargin);
  N=Nargs;
  Tmp=varargin(N);
  Iro=[0,0,0,1];
  Iroflg=0;
  if type(Tmp)==10 then
    Iro=Ratiocmyk(Tmp);
    Iroflg=1;
    N=N-1;
  end
  Tmp=varargin(N);
  Kosa=1;
  if type(Tmp)==1 & length(Tmp)==1
    Kosa=Tmp;
    N=N-1;
  end;
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
  if Iroflg>0
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
