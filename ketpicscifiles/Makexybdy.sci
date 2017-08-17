// 08.09.13
// 08.09.16
// 08.10.11
// 08.10.27
// 14.07.07 debug ( Kitahara )

function EhL=Makexybdy(Fd,Np)
  Eps0=10^(-4);
  FdL=Fullformfunc(Fd);
  Tmp1=Mixop(2,FdL);
  Tmp2=Mixop(3,FdL);
  Xystr=[Tmp1,Tmp2];
  Tmp=Mixop(5,FdL);
  K=mtlb_findstr(Tmp,'=');
  Uname=part(Tmp,1:K-1);
  Urg=evstr(part(Tmp,K+1:length(Tmp)));
  Tmp=Mixop(6,FdL);
  K=mtlb_findstr(Tmp,'=');
  Vname=part(Tmp,1:K-1);
  Vrg=evstr(part(Tmp,K+1:length(Tmp)));
  Umin=Urg(1); Umax=Urg(2);
  Vmin=Vrg(1); Vmax=Vrg(2);
  DrwS=Mixop(7,FdL);
  Cflg=0;
  EhL=[];
  Tmp=mtlb_findstr(DrwS,'e');
  if length(Tmp)~=0
    Tmp1=strsubst(Xystr,Uname,'('+string(Umax)+')');
    Tmp2=Mixop(6,FdL);
    Tmp3='N='+string(Np(2));
    Tmp=Paramplot(Tmp1,Tmp2,Tmp3);
    if norm(Ptstart(Tmp)-Ptend(Tmp))<Eps0
      Cflg=1;
      Tmp(size(Tmp,1),:)=Tmp(1,:);
    end;
    EhL=Mixadd(EhL,Tmp);
  end;
  Tmp=mtlb_findstr(DrwS,'n');
  if length(Tmp)~=0
    Tmp1=strsubst(Xystr,Vname,'('+string(Vmax)+')');
    Tmp2=Mixop(5,FdL);
    Tmp3='N='+string(Np(1));
    Tmp=Paramplot(Tmp1,Tmp2,Tmp3);
    if Cflg~=0 // 140707 Kitahara
      Tmp1=Mixop(Mixlength(EhL),EhL);
      Tmp=Joincrvs(Tmp1,Tmp);
      if norm(Ptstart(Tmp)-Ptend(Tmp))<Eps0
        Cflg=1;
        Tmp(size(Tmp,1),:)=Tmp(1,:);
      end;
      Tmp1=Mixsub(1:Mixlength(EhL)-1,EhL);
      EhL=Mixadd(Tmp1,Tmp);
    else
      Cflg=0;
      if norm(Ptstart(Tmp)-Ptend(Tmp))<Eps0
        Cflg=1;
        Tmp(size(Tmp,1),:)=Tmp(1,:);
      end;
      EhL=Mixadd(EhL,Tmp);
    end;
  end;
  Tmp=mtlb_findstr(DrwS,'w');
  if length(Tmp)~=0
    Tmp1=strsubst(Xystr,Uname,'('+string(Umin)+')');
    Tmp2=Mixop(6,FdL);
    Tmp3='N='+string(Np(2));
    Tmp=Paramplot(Tmp1,Tmp2,Tmp3);
    if Cflg~=0 //if Cflg==0
      Tmp1=Mixop(Mixlength(EhL),EhL);
      Tmp=Joincrvs(Tmp1,Tmp);
      if norm(Ptstart(Tmp)-Ptend(Tmp))<Eps0
        Cflg=1;
        Tmp(size(Tmp,1),:)=Tmp(1,:);
      end;
      Tmp1=Mixsub(1:Mixlength(EhL)-1,EhL);
      EhL=Mixadd(Tmp1,Tmp);
    else
      Cflg=0;
      if norm(Ptstart(Tmp)-Ptend(Tmp))<Eps0
        Cflg=1;
        Tmp(size(Tmp,1),:)=Tmp(1,:);
      end;
      EhL=Mixadd(EhL,Tmp);
    end;  
  end;
  Tmp=mtlb_findstr(DrwS,'s');
  if length(Tmp)~=0
    Tmp1=strsubst(Xystr,Vname,'('+string(Vmin)+')');
    Tmp2=Mixop(5,FdL);
    Tmp3='N='+string(Np(1));
    Tmp=Paramplot(Tmp1,Tmp2,Tmp3);
    if Cflg~=0 //if Cflg==0
      Tmp1=Mixop(Mixlength(EhL),EhL);
      Tmp=Joincrvs(Tmp1,Tmp);
      if norm(Ptstart(Tmp)-Ptend(Tmp))<Eps0
        Cflg=1;
        Tmp(size(Tmp,1),:)=Tmp(1,:);
      end;
      Tmp1=Mixsub(1:Mixlength(EhL)-1,EhL);
      EhL=Mixadd(Tmp1,Tmp);
    else
      Cflg=0;
      if norm(Ptstart(Tmp)-Ptend(Tmp))<Eps0
        Cflg=1;
        Tmp(size(Tmp,1),:)=Tmp(1,:);
      end;
      EhL=Mixadd(EhL,Tmp);
    end;  
  end;
endfunction;

