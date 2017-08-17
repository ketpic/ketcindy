// 09.11.26
// 09.12.06
// 09.12.25
// 10.01.12
// 10.01.13
// 10.03.28
// 10.03.30
// 13.05.03  Domain can be omitted

function Out=Tabledata(varargin)
// 2013.05.01   Domain is optional.
  Eps=0.001;
  Tmp=varargin(1); // 130502 from
  if type(Tmp)==1
    Domain=varargin(1);
    VL=varargin(2);
    HL=varargin(3);
  else
    Domain=[-1,-1];
    VL=varargin(1);
    HL=varargin(2);
  end; // 130502 upto
  Hsize=Domain(1);
  SvL=list(0);
  S=0;
  for I=1:length(VL)
    Tmp=VL(I);
    S=S+Tmp(1);
    Tmp(1)=S;
    SvL($+1)=Tmp;
  end;
  if Hsize>S
    SvL($+1)=Hsize;
  end;
  Hsize=Op(1,SvL(length(SvL)));
  Vsize=Domain(2);
  ShL=list(0);
  S=0;
  for I=1:length(HL)
    Tmp=HL(I);
    S=S+Tmp(1);
    Tmp(1)=S;
    ShL($+1)=Tmp;
  end;
  if Vsize>S
    ShL($+1)=Vsize;
  end;
  Vsize=Op(1,ShL(length(ShL)));
  Marw=0; Mare=0; Mars=0; Marn=0;
  if length(Domain)>2
    Marw=Domain(3);
    Mare=Domain(4);
  end;
  if length(Domain)>4
    Marn=Domain(5);
    Mars=Domain(6);
  end;
  Setwindow([-Marw,Hsize+Mare],[-Mars,Vsize+Marn]);
  Tmp=Framedata([Eps,Hsize-Eps],[Eps,Vsize-Eps]);
  Gdata=list(Tmp);
  Tmp=-Marw;
  Hdata=list(Listplot([[Tmp,-Mars],[Tmp,Vsize+Marn]]));
  for I=1:length(SvL) // 10.03.30
    Data=SvL(I);
    X=Data(1);
    if length(Data)==1
      Y1=0;
      Y2=Vsize;
      G=Listplot([X,Y1],[X,Y2]);
    else
      G=[];
      for J=2:2:length(Data)
        Y1=Vsize-Op(1,ShL(Data(J)));  // 10.03.30
        Y2=Vsize-Op(1,ShL(Data(J+1)));
        Tmp=Listplot([[X,Y1],[X,Y2]]);
        G=[G;%inf,%inf;Tmp];
      end;
      G=G(2:size(G,1),:);
    end;
    Hdata($+1)=G;
  end;
  Tmp=Hsize+Mare;
  Tmp1=Listplot([[Tmp,-Mars],[Tmp,Vsize+Marn]]);
  Hdata($+1)=Tmp1;
  Tmp=Vsize+Marn;
  Vdata=list(Listplot([[-Marw,Tmp],[Hsize+Mare,Tmp]]));
  for I=1:length(ShL)
    Data=ShL(I);
    Y=Vsize-Data(1);
    if length(Data)==1
      X1=0;
      X2=Hsize;
      G=Listplot([X1,Y],[X2,Y]);
    else
      G=[];
      for J=2:2:length(Data)
        X1=Op(1,SvL(Data(J)));  // 10.03.30
        X2=Op(1,SvL(Data(J+1)));
        Tmp=Listplot([X1,Y],[X2,Y]);
        G=[G;%inf,%inf;Tmp];
      end;
      G=G(2:size(G,1),:);
    end;
    Vdata($+1)=G;
  end;
  Tmp=Listplot([[-Marw,-Mars],[Hsize+Mare,-Mars]]);
  Vdata($+1)=Tmp;
  Tmp1=Mixsub(3:(length(Hdata)-2),Hdata);
  Tmp2=Mixsub(3:(length(Vdata)-2),Vdata);
  Gdata=Mixjoin(Gdata,Tmp1,Tmp2);
  Hind=2:(1+length(Tmp1));
  Vind=(2+length(Tmp1)):(1+length(Tmp1)+length(Tmp2));
  G=Gdata(1);
  P1=Ptsw(G); P2=Ptnw(G);
  Q1=Ptse(G); Q2=Ptne(G);
  Tmp1=list(Listplot([P1,P2]),Listplot([Q1,Q2]));
   P1=Ptnw(G); P2=Ptne(G);
  Q1=Ptsw(G); Q2=Ptse(G);
  Tmp2=list(Listplot([P1,P2]),Listplot([Q1,Q2])); 
  Tmp3=Framedata();
  Out=list(Gdata,Hind,Vind,Tmp1,Tmp2,Tmp3);
endfunction;

function Out=Dividetable(Tb)
  G=Tb(1);
  Gw=G(1);
  Gt=Mixsub(Tb(2),G);
  Gy=Mixsub(Tb(3),G);
  Out=list(Gw,Gt,Gy)
endfunction;
