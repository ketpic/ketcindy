//
// 08.05.22
// 09.12.25

function Shade(varargin)
  global Wfile FID MilliIn;
  Nargs=length(varargin);
  Kosa=1;
  N=Nargs;
  Tmp=varargin(N);
  if (type(Tmp)==10)|(type(Tmp)==1 & length(Tmp)==1) // 10.04.29
    Kosa=Tmp;
    N=N-1;
  end
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
endfunction
