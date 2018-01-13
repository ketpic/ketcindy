// 08.09.21
// 08.10.11
// 08.10.15
// 10.02.16  Eps

function OutL=Crvonsfpersdata(varargin)
  global PARTITIONPT HIDDENDATA CRVONSFHIDDENDATA
  Nargs=length(varargin);
  Eps0=10^(-4);
  Figuv=varargin(1);
  Fbdy=Projpers(varargin(2));
  Fd=varargin(3); N=4;
  FdL=Fullformfunc(Fd);
  Fxy=Mixop(1,FdL);
  Xf=Mixop(2,FdL);
  Yf=Mixop(3,FdL);
  Zf=Mixop(4,FdL);
  Np=[50,50];
  if Nargs>=N
    Np=varargin(N); N=N+1;
    if type(Np)==1 & length(Np)==1
      Np=[Np,Np];
    end;
  end;
  Eps=[0.05,1];  //
  if Nargs>=N
    Eps=varargin(N);
  end;
  if length(Eps)==1
    Eps=[Eps,1];
  end;
  Eps2=0.2;
  if Nargs>=N+1
    Eps2=varargin(N+1);
  end;
  Tmp=Mixop(2,Fd);
  K=mtlb_findstr(Tmp,'=');
  Xname=part(Tmp,1:K-1);
  Tmp=Mixop(3,Fd);
  K=mtlb_findstr(Tmp,'=');
  Yname=part(Tmp,1:K-1);
  Tmp=Mixop(5,FdL);
  K=mtlb_findstr(Tmp,'=');
  Uname=part(Tmp,1:K-1);
  Urg=evstr(part(Tmp,K+1:length(Tmp)));
  Tmp=Mixop(6,FdL);
  K=mtlb_findstr(Tmp,'=');
  Vname=part(Tmp,1:K-1);
  Vrg=evstr(part(Tmp,K+1:length(Tmp)));    
  Fbdxy=Makexybdy(Fd,Np);
  Fbdyuv=Mixop(8,FdL);
  if Fbdyuv==[]    
    Fbdyuv=Mix(Framedata(Urg,Vrg));
  end;
  FigL=Clipindomain(Figuv,Fbdyuv);
  CRVONSFHIDDENDATA=[];
  OutL=[];
  for N=1:Mixlength(FigL)
    PtL=Mixop(N,FigL);
    Tmp=[];
    for I=1:size(PtL,1)
      P=PtL(I,:);
      Tmp1=strsubst(Xf,Uname,'('+string(P(1))+')');
      Tmp1=strsubst(Tmp1,Vname,'('+string(P(2))+')');
      Tmp1=evstr(Tmp1);
      Tmp2=strsubst(Yf,Uname,'('+string(P(1))+')');
      Tmp2=strsubst(Tmp2,Vname,'('+string(P(2))+')');
      Tmp2=evstr(Tmp2);
      Tmp3=strsubst(Zf,Uname,'('+string(P(1))+')');
      Tmp3=strsubst(Tmp3,Vname,'('+string(P(2))+')');
      Tmp3=evstr(Tmp3);
      Tmp=[Tmp,[Tmp1,Tmp2,Tmp3]];
    end;
    Fk=Spaceline(Tmp);
    Par=Partitionseg(Projpers(Fk),Fbdy,Eps(1),Eps2); //
    if Fxy=='p'
      Tmp=Nohiddenpers2(Par,Fk,Fd,1,Np,Eps);
    else
      Tmp1=Mix(Fxy,Fbdxy,Xname,Yname);
      Tmp=Nohiddenpers(Par,Fk,Tmp1);
    end;
    OutL=Mixjoin(OutL,Tmp);
    CRVONSFHIDDENDATA=Mixjoin(CRVONSFHIDDENDATA,HIDDENDATA);
  end;
endfunction;

