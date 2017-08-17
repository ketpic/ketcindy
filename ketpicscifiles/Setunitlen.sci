// 08.12.06
// 08.12.18
// 09.02.20
// 09.02.27
// 14.03.05 MARKLEN

function Out=Setunitlen(varargin)
    global FID XMIN XMAX YMIN YMAX ULEN ...
         MilliIn MARKLEN MARKLENNow PenThickInit;
  if length(varargin)==0
    Out=ULEN;
    disp(ULEN);
    return;
  end;
  Ul=varargin(1);
  Dx=XMAX-XMIN;
  Dy=YMAX-YMIN;
  Sym='.0123456789 +-*/';
  Tmp=ascii(Sym);
  SL=Sym;
  OL='+-*/';
  if Ul~=''
    ULEN=Ul;
  end;
  Out=ULEN;
  Is=1;
  VL=[];
  Ucode=ascii(ULEN);
  for I=1:length(Ucode)
    C=char(Ucode(I));
    if mtlb_findstr(SL,C)~=[]
      if mtlb_findstr(OL,C)
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
  Out=ULEN;
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
endfunction;

