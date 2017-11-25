// 09.09.25
// 11.12.12
// 15.06.14
// 15.10.19

function Out=Skeletonpara3data(varargin)
  global MilliIn;
  Eps=10^(-4);  // 15.06.14
  Nargs=length(varargin);
  Out=[];
  ObjL=Flattenlist(varargin(1));
  Plt3L=Flattenlist(varargin(2));
  R=0.075*1000/2.54/MilliIn;
  if Nargs>2
    R=R*varargin(3);
  end;
  Eps2=0.05; // changed at 08.10.16
  if Nargs>3
    Eps2=varargin(4);
  end;
  Plt2L=list();
  for I=1:Mixlength(Plt3L)
    Plt2L($+1)=ProjcoordCurve(Plt3L(I));
  end;
  Out=list();
  for I=1:length(ObjL)
    Obj3=ObjL(I);
    Tmp=ProjcoordCurve(Obj3);
    Data=Makeskeletondata(Mix(Tmp),Plt2L,R,Eps2);
    for J=1:length(Data)
      Gd=Data(J);
      if size(Gd,1)==1    // 15.10.19
          continue;
      end;
      if norm(Ptcrv(1,Gd)-Ptcrv(2,Gd))<Eps  // 15.06.14
        continue
      end;
      PtD=[];
      for J=1:size(Gd,1)
        Tmp=Gd(J,:);
        Tmp1=Invparapt(Tmp,Obj3);
        Tmp1=Mixop(1,Tmp1);
        PtD=[PtD;Tmp1];
      end;
      Out($+1)=PtD;
    end;
  end;
endfunction
