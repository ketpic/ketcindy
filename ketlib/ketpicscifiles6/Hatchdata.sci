// 08.05.21
// 09.10.05
// 09.12.25
// 10.01.20
// 10.02.01
// 10.11.04  ( debugged 83 )

function ShaLs=Hatchdata(varargin)
  global XMIN XMAX YMIN YMAX MilliIn;
  ShaL=[];
  Nargs=length(varargin);
  Kakudo=45;
  Kankaku=0.125*1000/2.54/MilliIn;
  Tmp=Doscaling([XMIN,YMIN]);
  Xmn=Tmp(1); Ymn=Tmp(2);
  Tmp=Doscaling([XMAX,YMAX]);
  Xmx=Tmp(1); Ymx=Tmp(2);
  for N=Nargs:-1:1
    Tmp=varargin(N);
    if Mixtype(Tmp)~=1
      break
    end
  end
  if N<Nargs
    Kakudo=varargin(N+1);
    if N==Nargs-2
      Kankaku=0.125*varargin(Nargs);
    end
  end
  NaitenL=varargin(1);
  if Mixtype(NaitenL)==1
    NaitenL=list(NaitenL);
  end
  Ns=2;
  StartP=Op(1,NaitenL);
  if type(StartP)==10
    StartP=[(Xmn+Xmx)/2,(Ymn+Ymx)/2];
  end
  if Mixtype(varargin(2))==1
    StartP=varargin(2);
    StartP=Doscaling(StartP);
    Ns=3;
  end
  Tmp=list();
  for I=Ns:N
    Tmp1=list(varargin(I));
    Tmp=Mixjoin(Tmp,Tmp1);
  end
  Bdy=Kyoukai(Tmp);
  Bdys=list();
  for I=1:length(Bdy)
    Tmp1=Bdy(I);
    Tmp2=Doscaling(Tmp1);
    Bdys=Mixjoin(Bdys,list(Tmp2));
  end;
  Bdy=Bdys;
  PtnL=list();
  for I=1:length(NaitenL)
    Tmp=Op(I,NaitenL);
    if type(Tmp)==1
      Tmp1=Naigai(Tmp,Bdy);
      PtnL=Mixjoin(PtnL,list(Tmp1));
    else
      if type(Tmp)~=10
        disp('Type Error');
        return
      end
      Ptn=[];
      for J=1:length(Tmp)
        if Op(J,Tmp)=='i'
          Ptn=[Ptn,1];
        else
          Ptn=[Ptn,0];
        end
      end
      PtnL=Mixjoin(PtnL,list(Ptn));
    end
  end
  Call=length(Bdy);
  Ptn=zeros(1,Call);
  if Member(Ptn,PtnL)
    Wn=Doscaling(Framedata());
    Bdy=Mixjoin(Bdy,list(Wn));
    Tmp=list();
    for I=1:length(PtnL)
      Tmp1=[Op(I,PtnL),1];
      Tmp=Mixjoin(Tmp,Tmp1); // 10.11.04
    end
    PtnL=Tmp;
  end
  V=[cos(Kakudo*%pi/180),sin(Kakudo*%pi/180)];
  Vm=[-sin(Kakudo*%pi/180),cos(Kakudo*%pi/180)];
  Tmp=Op(1,NaitenL);
  if type(Tmp)==1 & size(Tmp,2)==2
    Tmp=Doscaling(Tmp);
    Delta=Tmp-StartP;
    K=Trunc((Delta(1)*Vm(1)+Delta(2)*Vm(2))/Kankaku);
    PA=StartP+K*Kankaku*Vm;
    Sha=Makeshasen(PtnL,PA,V,Bdy);
    I=1;
    while length(Sha)~=0
      for J=1:length(Sha)
        ShaL=Mixadd(ShaL,Sha(J));
      end;
      Sha=Makeshasen(PtnL,PA+I*Kankaku*Vm,V,Bdy);
      I=I+1;
    end
    Sha=Makeshasen(PtnL,PA-Kankaku*Vm,V,Bdy);
    I=2;
    while length(Sha)~=0
      for J=1:length(Sha)
        ShaL=Mixjoin(ShaL,list(Sha(J)));
      end;
      Sha=Makeshasen(PtnL,PA-I*Kankaku*Vm,V,Bdy);
      I=I+1;
    end
  else
    Delta=[Xmn,Ymn]-StartP;
    K1=Trunc((Delta(1)*Vm(1)+Delta(2)*Vm(2))/Kankaku);
    Delta=[Xmx,Ymn]-StartP;
    K2=Trunc((Delta(1)*Vm(1)+Delta(2)*Vm(2))/Kankaku);
    Delta=[Xmx,Ymx]-StartP;
    K3=Trunc((Delta(1)*Vm(1)+Delta(2)*Vm(2))/Kankaku);
    Delta=[Xmn,Ymx]-StartP;
    K4=Trunc((Delta(1)*Vm(1)+Delta(2)*Vm(2))/Kankaku);
    IM=max(K1,K2,K3,K4);
    Im=min(K1,K2,K3,K4);
    for I=Im:IM
      Sha=Makeshasen(PtnL,StartP+I*Kankaku*Vm,V,Bdy);
      for J=1:length(Sha)
        ShaL=Mixjoin(ShaL,list(Sha(J)));
      end
    end
  end
  ShaLs=list();
  for I=1:length(ShaL)
    Tmp=ShaL(I);
    Tmp1=Unscaling(Tmp);
    ShaLs=Mixjoin(ShaLs,list(Tmp1));
  end;
endfunction;
