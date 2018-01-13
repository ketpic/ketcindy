// 08.09.10

function FkL=Borderrawdata(varargin)
  Nall=length(varargin);
  FkL=varargin(1);
  FdL=Fullformfunc(varargin(2));
  Tmp1=Mixop(2,FdL);
  Tmp2=Mixop(3,FdL);
  Tmp3=Mixop(4,FdL);
  Xyzstr=[Tmp1,Tmp2,Tmp3];
  DrwS=Mixop(7,FdL);
  Tmp=Mixop(5,FdL);
  K=mtlb_findstr(Tmp,'=');
  Uname=part(Tmp,1:K-1);
  Urg=evstr(part(Tmp,K+1:length(Tmp)));
  Tmp=Mixop(6,FdL);
  K=mtlb_findstr(Tmp,'=');
  Vname=part(Tmp,1:K-1);
  Vrg=evstr(part(Tmp,K+1:length(Tmp)));
  Np=[50,50];
  if Nall>=3
    Np=varargin(3);
    if type(Np)==1 & length(Np)==1
      Np=[Np,Np];
    end;
  end;
  Um=Urg(1); UM=Urg(2);
  Vm=Vrg(1); VM=Vrg(2);
  EkL=[];
  Tmp=mtlb_findstr(DrwS,'e');
  if length(Tmp)~=0
    Tmp1=strsubst(Xyzstr,Uname,'('+string(UM)+')');
    Tmp2=Mixop(6,FdL);
    Tmp3='N='+string(Np(2));
    Tmp=Spacecurve(Tmp1,Tmp2,Tmp3);
    EkL=Mixadd(EkL,Tmp);
  end;
  Tmp=mtlb_findstr(DrwS,'n');
  if length(Tmp)~=0
    Tmp1=strsubst(Xyzstr,Vname,'('+string(VM)+')');
    Tmp2=Mixop(5,FdL);
    Tmp3='N='+string(Np(1));
    Tmp=Spacecurve(Tmp1,Tmp2,Tmp3);
    EkL=Mixadd(EkL,Tmp);
  end;
  Tmp=mtlb_findstr(DrwS,'w');
  if length(Tmp)~=0
    Tmp1=strsubst(Xyzstr,Uname,'('+string(Um)+')');
    Tmp2=Mixop(6,FdL);
    Tmp3='N='+string(Np(2));
    Tmp=Spacecurve(Tmp1,Tmp2,Tmp3);
    EkL=Mixadd(EkL,Tmp);
  end;
  Tmp=mtlb_findstr(DrwS,'s');
  if length(Tmp)~=0
    Tmp1=strsubst(Xyzstr,Vname,'('+string(Vm)+')');
    Tmp2=Mixop(5,FdL);
    Tmp3='N='+string(Np(1));
    Tmp=Spacecurve(Tmp1,Tmp2,Tmp3);
    EkL=Mixadd(EkL,Tmp);
  end;
  FkL=Mixjoin(FkL,EkL);
endfunction;

