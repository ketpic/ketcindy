// 08.09.16
// 08.10.11
// 08.10.15
// 10.02.16 Eps

function Out=Crv3onsfparadata(varargin)
  global PARTITIONPT HIDDENDATA CRV3ONSFHIDDENDATA
  Nargs=length(varargin);
  Fk=varargin(1);
  Fbdy=Projpara(varargin(2));
  Fd=varargin(3); N=4;
  FdL=Fullformfunc(Fd);
  Fxy=Mixop(1,FdL);
  Np=[50,50];
  if Nargs>=N
    Np=varargin(N); N=N+1;
    if type(Np)==1 & length(Np)==1
      Np=[Np,Np];
    end;
  end;
  Eps=[0.05,1]; //
  if Nargs>=N
    Eps=varargin(N);
  end;
  if length(Eps)==1  //
    Eps=[Eps,1];  //
  end;  //
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
  Fbdxy=Makexybdy(Fd,Np);
  Tmp=Projpara(Fk);
  Par=Partitionseg(Tmp,Fbdy,Eps(1),Eps2); //
  if Fxy=='p'
    Out=Nohiddenpara2(Par,Fk,Fd,1,Np,Eps);
  else
    Tmp=Mix(Fxy,Fbdxy,Xname,Yname);
    Out=Nohiddenpara(Par,Fk,Tmp);
  end;
  CRV3ONSFHIDDENDATA=HIDDENDATA;
endfunction;

