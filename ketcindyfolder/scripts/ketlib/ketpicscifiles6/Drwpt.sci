//
// 08.05.31
// 09.12.25
// 10.01.01

function Drwpt(varargin)
  global Wfile FID TenSize TenSizeInit MilliIn;
  Nargs=length(varargin);
  if TenSize>TenSizeInit
    N=round(6*sqrt(TenSize/TenSizeInit));
  else
    N=4
  end
  Tmp=varargin(Nargs);
  if type(Tmp)==1
    if length(Tmp)>1
      Kosa=1; All=Nargs;
    else
      Kosa=Tmp; All=Nargs-1;
    end;
  elseif type(Tmp)==15
      Kosa=1; All=Nargs;
  end;
  CL=[];
  for J=0:N
    Tmp=TenSize*0.5*1000/2.54/MilliIn;
    Tmp=Tmp*[cos(%pi/4+J*2*%pi/N),sin(%pi/4+J*2*%pi/N)];
    CL=[CL;Tmp];
  end
  for II=1:All
    Tmp=varargin(II);
	MS=Flattenlist(Tmp);  // 11.05.29
    for I=1:length(MS);
      P=Op(I,MS);
      if InWindow(P)~='i'
        continue
      end
      P=Doscaling(P);
      PL=[];
      for J=0:N
        PL=[PL;P+CL(J+1,:)];
      end;
      Mojisu=0;
      for J=1:size(PL,1)
        Q=PL(J,:);
        X=string(round(MilliIn*Q(1)));
        Y=string(-round(MilliIn*Q(2)));
        Str='\special{pa '+X+' '+Y+'}'
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
      end;
      Str1='\special{sh '+string(Kosa)+'}';
      Str2='\special{fp}%';
      if Wfile=='default'
        mprintf('%s',Str1);
        mprintf('%s\n',Str2);
      else
        mfprintf(FID,'%s',Str1);
        mfprintf(FID,'%s\n',Str2);
      end
    end
  end
endfunction
