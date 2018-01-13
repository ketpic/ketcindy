// 08.07.13
// 08.08.08
// 08.10.16
// 11.12.12  (Flattenlist)

function Out=Skeletonparadata(varargin)
  global MilliIn;
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
  Obj2L=list();
  for I=1:length(ObjL)
    Obj2L($+1)=ProjcoordCurve(ObjL(I));
  end;
  Plt2L=list();
  for I=1:length(Plt3L)
    Plt2L($+1)=ProjcoordCurve(Plt3L(I));
  end;
  Out=Makeskeletondata(Obj2L,Plt2L,R,Eps2);
endfunction
