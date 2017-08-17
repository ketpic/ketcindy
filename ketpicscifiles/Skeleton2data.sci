// 08.08.14
// 08.10.16
// 09.06.13

function Out=Skeleton2data(varargin)
  global MilliIn;
  Nargs=length(varargin);
  Out=[];
  Tmp=varargin(1);
  if Mixtype(Tmp)==1
    ObjL=MixS(Tmp);
  elseif Mixtype(Tmp)==2
    ObjL=Tmp;
  else
    ObjL=[];
    for I=1:Mixlength(Tmp)
      Tmp1=Mixop(I,Tmp);
      if Mixtype(Tmp1)==1
        ObjL=Mixadd(ObjL,Tmp1);
      else
        ObjL=Mixjoin(ObjL,Tmp1);
      end;
    end;
  end;
  Tmp=varargin(2);
  if Mixtype(Tmp)==1
    PltL=MixS(Tmp);
  elseif Mixtype(Tmp)==2
    PltL=Tmp
  else
    PltL=[];
    for I=1:Mixlength(Tmp)
      Tmp1=Mixop(I,Tmp);
      if Mixtype(Tmp1)==1
        PltL=Mixadd(PltL,Tmp1);
      else
        PltL=Mixjoin(PltL,Tmp1);
      end;
    end;
  end; 
  R=0.075*1000/2.54/MilliIn;
  if Nargs>2
    R=R*varargin(3);
  end;
  Eps2=0.01;
  if Nargs>3
    Eps2=varargin(4);
  end;
  Obj2L=[];
  for I=1:Mixlength(ObjL)
    Curve=Mixop(I,ObjL);
    Obj2=[];
    for J=1:size(Curve,1)
      P=Curve(J,:);
      Obj2=[Obj2;P,-1];
    end;
    Obj2L=Mixadd(Obj2L,Obj2);
  end;
  Plt2L=[]
  for I=1:Mixlength(PltL)
    Curve=Mixop(I,PltL);
    Plt2=[];
    for J=1:size(Curve,1)
      P=Curve(J,:);
      Plt2=[Plt2;P,0];
    end;
    Plt2L=Mixadd(Plt2L,Plt2);
  end;
  Out=Makeskeletondata(Obj2L,Plt2L,R,Eps2);
endfunction

