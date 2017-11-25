// 
// 09.12.25
// 11.05.25
// 14.03.05 MARKLEN
// 17.03.19  VL=[] => VL="";

function Openpicture(ul)
  global Wfile FID XMIN XMAX YMIN YMAX ULEN
  global MilliIn MARKLEN MARKLENNow PenThickInit;
  Tmp=Doscaling([XMIN,YMIN]);
  Xm=Tmp(1);
  Ym=Tmp(2);
  Tmp=Doscaling([XMAX,YMAX]);
  XM=Tmp(1);
  YM=Tmp(2);  
  Dx=XM-Xm;
  Dy=YM-Ym;
  Sym='.0123456789 +-*/';
  Tmp=ascii(Sym);
  SL=Sym;
  OL='+-*/';
  if ul~=''
    ULEN=ul;
  end
  Is=1;
  VL=""; // 17.03.19
  Ucode=ascii(ULEN);
  for I=1:length(Ucode)
    C=char(Ucode(I));
    if mtlb_findstr(SL,C)~=[]
      if mtlb_findstr(OL,C)~=[]
        Str=char(Ucode(Is:(I-1)));
        VL=VL+Str+C;
        Is=I+1;
      end
    else
      Unit=char(Ucode(I:(I+1)));
      Str=char(Ucode(Is:(I-1)));
      VL=VL+Str;
      break;
    end;
  end;
  Valu=evstr(VL);
  Str=string(Valu);
  ULEN=Str+Unit;
  if Unit=='cm'
    MilliIn=1000/2.54*Valu;
  end
  if Unit=='mm'
    MilliIn=1000/2.54*Valu/10;
  end
  if Unit=='in'
    MilliIn=1000*Valu;
  end
  if Unit=='pt'
    MilliIn=1000/72.27*Valu;
  end
  if Unit=='pc'
    MilliIn=1000/6.022*Valu;
  end 
  if Unit=='bp'
    MilliIn=1000/72*Valu;
  end 
  if Unit=='dd'
    MilliIn=1000/1238/1157/72.27*Valu;
  end 
  if Unit=='cc'
    MilliIn=1000/1238/1157/72.27*12*Valu;p
  end
  if Unit=='sp'
    MilliIn=1000/72.27/65536*Valu/10;
  end
  MARKLEN=MARKLENNow*1000/2.54/MilliIn;
  if Wfile=='default'
    mprintf('%s%s%s\n','{\unitlength=',ULEN,'%');
    mprintf('%s\n','\begin{picture}%');
    mprintf('%c%10.5f%c%10.5f%2s%10.5f%c%10.5f%2s\n',...
            '(',Dx,',',Dy,')(',Xm,',',Ym,')%');
    Str='\special{pn '+string(PenThickInit)+'}%';
    mprintf('%s\n',Str);
    mprintf('%s\n','%');
  else
    mfprintf(FID,'%s%s%s\n','{\unitlength=',ULEN,'%');
    mfprintf(FID,'%s\n','\begin{picture}%');
    mfprintf(FID,'%c%10.5f%c%10.5f%2s%10.5f%c%10.5f%2s\n',...
            '(',Dx,',',Dy,')(',Xm,',',Ym,')%');  //11.05.25
    Str='\special{pn '+string(PenThickInit)+'}%';
    mfprintf(FID,'%s\n',Str);
    mfprintf(FID,'%s\n','%');
  end
endfunction

