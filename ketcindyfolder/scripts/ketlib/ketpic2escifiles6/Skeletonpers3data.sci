// 09.09.25
// 11.12.12

function Out=Skeletonpers3data(varargin)
  global MilliIn;
  Nargs=length(varargin);
  Out=[];
  ObjL=Flattenlist(varargin(1));
  Plt3L=Flattenlist(varargin(2));
  R=0.075*1000/2.54/MilliIn;
  if Nargs>2
    R=R*varargin(3);
  end;
  Eps2=0.05;  // changed at 08.10.16
  if Nargs>3
    Eps2=varargin(4);
  end;
  Plt2L=[];
  for I=1:Mixlength(Plt3L)
    Tmp=CameracoordCurve(Mixop(I,Plt3L));
    Plt2L=Mixadd(Plt2L,Tmp);
  end;
  Out=list();
  for I=1:length(ObjL)
    Obj3=ObjL(I);
    Tmp=CameracoordCurve(Obj3);
    Data=Makeskeletonpersdata(Mix(Tmp),Plt2L,R,Eps2);
    for J=1:length(Data)
      Gd=Data(J);
      PtD=[];
      for J=1:size(Gd,1)
        Tmp=Gd(J,:);
        Tmp1=Invperspt(Tmp,Obj3);
        Tmp1=Mixop(1,Tmp1);
        PtD=[PtD;Tmp1];
      end;
      Out($+1)=PtD;
    end;
  end;
endfunction

