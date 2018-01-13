// 08.09.10
// 08.09.16
// 09.12.31 (gsort)

function OutL=Clipindomain(ObjL,FigL)
  EEps=10^(-4);
  Eps=0.01;
  Eps2=0.2;
  Bdy=Kyoukai(FigL);
  if Mixlength(Bdy)>=2
     Fbdy=Joincrvs(FigL)
  else
     Fbdy=Mixop(1,FigL);
  end;
  if Mixtype(ObjL)==1
    ObjL=Mix(ObjL)
  end;
  if Mixtype(FigL)==1
    FigL=Mix(FigL)
  end;
  OutL=[];
  for Nobj=1:Mixlength(ObjL);
    Obj=Mixop(Nobj,ObjL);
    ParL=[1,Numptcrv(Obj)];
    Tmp=IntersectcrvsPp(Obj,Fbdy,Eps,Eps2);
    for J=1:Mixlength(Tmp)
      Tmp1=Mixop(J,Tmp);
      ParL=[ParL,Mixop(2,Tmp1)];
    end;
    ParL=gsort(ParL);
    ParL=ParL(length(ParL):-1:1);
    Tmp=[1];
    for I=1:length(ParL)
      Tmp1=Tmp(length(Tmp));
      Tmp2=ParL(I);
      if Tmp2-Tmp1>EEps
        Tmp=[Tmp,Tmp2];
      end;
    end;
    ParL=Tmp;
    Tmp1=ParL(length(ParL));
    Tmp2=Numptcrv(Obj);
    if abs(Tmp1-Tmp2)<Eps
      ParL=[ParL(1:length(ParL)-1),Tmp2];
    end;
    Fig=[];
    for N=1:length(ParL)-1
      Tmp=(ParL(N)+ParL(N+1))*0.5;
      Tmp=PointonCurve(Tmp,Obj);
      Tmp=Naigai(Tmp,Bdy);
      Tmp1=modulo(sum(Tmp),2);
      if Tmp1==0 continue; end;
      Fig=Mixadd(Fig,Partcrv(ParL(N),ParL(N+1),Obj));
    end;
    OutL=Mixjoin(OutL,Fig);
  end;
endfunction;

