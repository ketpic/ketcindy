// 08.05.31
// 10.01.01
// 10.03.07  (Kosa )

function ShaL=Dotfilldata(varargin)
  global XMIN XMAX YMIN YMAX MilliIn;
  Nargs=length(varargin);
  ShaL=[];
  Eps=0.01;
  Kakudo=45;
  Kosa=0.5;
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
    Kosa=varargin(N+1);
  end
//  Kosa=min(Kosa,1);  // 100307
  Tmp=1/(2*Kosa);
  Kankaku=Tmp*0.100*1000/2.54/MilliIn;
  NaitenL=varargin(1);
  if Mixtype(NaitenL)==1
    NaitenL=list(NaitenL);
  end
  Ns=2;
  StartP=Op(1,NaitenL);
  if type(StartP)==10
    StartP=[(XMIN+XMAX)/2,(YMIN+YMAX)/2];
  else
    StartP=Doscaling(StartP);
  end;
  Tmp=varargin(2);
  if Mixtype(Tmp)==1
    StartP=Doscaling(Tmp);
    Ns=3;
  end
  Tmp=[];
    for I=Ns:N
    Tmp=Mixjoin(Tmp,list(varargin(I)));
  end
  Bdy=Kyoukai(Tmp);
  Bdys=list();
  for I=1:length(Bdy)
    Tmp1=Bdy(I);
    Tmp2=Doscaling(Tmp1);
    Bdys=Mixjoin(Bdys,list(Tmp2))
  end;
  Bdy=Bdys;
  PtnL=[];
  for I=1:length(NaitenL)
    Tmp=Op(I,NaitenL);
    if type(Tmp)==1
      Tmp1=Naigai(Tmp,Bdy)
      PtnL=Mixjoin(PtnL,list(Tmp1));
    else
      if type(Tmp)~=10
        disp('Type Error');
        return;
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
    Tmp=[];
    for I=1:Mixlength(PtnL)
      Tmp1=[Op(I,PtnL),1];
      Tmp=Mixjoin(Tmp,list(Tmp1));
    end
    PtnL=Tmp;
  end
  V=[cos(Kakudo*%pi/180),sin(Kakudo*%pi/180)];
  Vm=[-sin(Kakudo*%pi/180),cos(Kakudo*%pi/180)];
  Tmp=Op(1,NaitenL);
  if type(Tmp)==1 & size(Tmp,2)>1
    Delta=Tmp-StartP;
    K=Trunc(Dotprod(Delta,Vm)/Kankaku);
    PA=StartP+K*Kankaku*Vm;
    P=PA;
    Sha=Makeshasen(PtnL,P,V,Bdy);
    Sha=Dividegraphics(Sha);
    I=1;
    while length(Sha)~=0
      for J=1:length(Sha)
        Tmp=Op(J,Sha);
        Q=Tmp(1,:);
        R=Tmp(2,:);
        Tmp=Dotprod(Q-P,V)/Kankaku;
        K1=ceil(Tmp);
        if abs(K1-Tmp)<Eps K1=K1+1; end
        Tmp=Dotprod(R-P,V)/Kankaku;
        K2=floor(Tmp);
        if abs(Tmp-K2)<Eps K2=K2-1; end
        for K=K1:K2
          Tmp1=Pointdata(P+K*Kankaku*V)
          ShaL=Mixjoin(ShaL,list(Tmp1));
        end
      end
      P=PA+I*Kankaku*Vm;
      Sha=Makeshasen(PtnL,P,V,Bdy);
      Sha=Dividegraphics(Sha);
      I=I+1;
    end
    P=PA-Kankaku*Vm;
    Sha=Makeshasen(PtnL,P,V,Bdy);
    I=2;
    while length(Sha)~=0
      for J=1:length(Sha)
        Tmp=Op(J,Sha);
        Q=Tmp(1,:);
        R=Tmp(2,:);
        Tmp=Dotprod(Q-P,V)/Kankaku;
        K1=ceil(Tmp);
        if abs(K1-Tmp)<Eps K1=K1+1; end
        Tmp=Dotprod(R-P,V)/Kankaku;
        K2=floor(Tmp);
        if abs(Tmp-K2)<Eps K2=K2-1; end
        for K=K1:K2
          Tmp1=Pointdata(P+K*Kankaku*V)
          ShaL=Mixjoin(ShaL,list(Tmp1));
        end
      end
      P=PA-I*Kankaku*Vm;
      Sha=Makeshasen(PtnL,P,V,Bdy);
      I=I+1;
    end
  else
    Delta=[Xmn,Ymn]-StartP;
    K1=Trunc(Dotprod(Delta,Vm)/Kankaku);
    Delta=[Xmx,Ymn]-StartP;
    K2=Trunc(Dotprod(Delta,Vm)/Kankaku);
    Delta=[Xmx,Ymx]-StartP;
    K3=Trunc(Dotprod(Delta,Vm)/Kankaku);
    Delta=[Xmn,Ymx]-StartP;
    K4=Trunc(Dotprod(Delta,Vm)/Kankaku);
    IM=max(K1,K2,K3,K4);
    Im=min(K1,K2,K3,K4);
    for I=Im:IM
      P=StartP+I*Kankaku*Vm;
      Sha=Makeshasen(PtnL,P,V,Bdy);
      Sha=Dividegraphics(Sha);
      if length(Sha)>0
        for J=1:length(Sha)
          Tmp=Op(J,Sha);
          Q=Tmp(1,:);
          R=Tmp(2,:);
          Tmp=Dotprod(Q-P,V)/Kankaku;
          K1=ceil(Tmp);
          if abs(K1-Tmp)<Eps K1=K1+1; end
          Tmp=Dotprod(R-P,V)/Kankaku;
          K2=floor(Tmp);
          if abs(Tmp-K2)<Eps K2=K2-1; end
          for K=K1:K2
            Tmp1=Pointdata(P+K*Kankaku*V)
            ShaL=Mixjoin(ShaL,list(Tmp1));
          end
        end
      end
    end
  end
  ShaLs=list();
  for I=1:length(ShaL)
    Tmp=ShaL(I);
    Tmp1=Unscaling(Tmp);
    ShaLs=Mixjoin(ShaLs,Tmp1);
  end;
  ShaL=ShaLs
endfunction
