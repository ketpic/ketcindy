// 08.09.15
// 08.10.10
// 08.10.11
// 08.10.15
// 08.10.21
// 08.10.25
// 09.09.10
// 10.02.16  Eps
// 17.05.07  Eps changed

function FsL=Wireparadata(varargin)
  global WIREPT PARTITIONPT HIDDENDATA HIDDENWIREDATA
  timer();
  Nargs=length(varargin);
  Fbdy=Projpara(varargin(1));
  Fd=varargin(2); N=3;
  FdL=Fullformfunc(Fd);
  Fxy=Mixop(1,FdL);
  Tmp=Mixop(5,FdL);
  K=mtlb_findstr(Tmp,'=');
  Uname=part(Tmp,1:K-1);
  Urg=evstr(part(Tmp,K+1:length(Tmp)));
  Tmp=Mixop(6,FdL);
  K=mtlb_findstr(Tmp,'=');
  Vname=part(Tmp,1:K-1);
  Vrg=evstr(part(Tmp,K+1:length(Tmp)));
  DuL=varargin(N);
  DvL=varargin(N+1);
  N=N+2;
  Np=[50,50];
  if Nargs>=N
    Np=varargin(N);
    if type(Np)==1 & length(Np)==1
      Np=[Np,Np];
    end;
  end
  Eps=[0.05,1];  //
  if Nargs>=N+1
    Eps=varargin(N+1);
  end;
  Eps2=0.2;
  if Nargs>=N+2
    Eps2=varargin(N+2);
  end;
  Tmp=Mixop(2,Fd);
  K=mtlb_findstr(Tmp,'=');
  Xname=part(Tmp,1:K-1);
  Tmp=Mixop(3,Fd);
  K=mtlb_findstr(Tmp,'=');
  Yname=part(Tmp,1:K-1);
  Umin=Urg(1); Umax=Urg(2);
  Vmin=Vrg(1); Vmax=Vrg(2);
  if type(DuL)==10
    DuL=evstr(DuL);
  elseif length(DuL)==1
    Tmp=(Umax-Umin)/(DuL+1);
    Tmp1=Umin+Tmp;
    Tmp2=Umin+DuL*Tmp
    DuL=[Tmp1:Tmp:Tmp2];
  end;
  if type(DvL)==10
    DvL=evstr(DvL);
  elseif length(DvL)==1
    Tmp=(Vmax-Vmin)/(DvL+1);
    Tmp1=Vmin+Tmp;
    Tmp2=Vmin+DvL*Tmp
    DvL=[Tmp1:Tmp:Tmp2];
  end;
  Fbdxy=Makexybdy(Fd,Np);
  WIREPT=[];
  HIDDENWIREDATA=[];
  FsL=[];
  for I=1:length(DuL)
    U=DuL(I);
    Tmp=Paramplot('[U,V]','V=[Vmin,Vmax]','N=Np(2)');//17.05.07
    FkL=Cuspsplitpara(Tmp,Fd,Eps(1));  // 
    for J=1:Mixlength(FkL)
      Fk=Mixop(J,FkL);
      Tmp=Projpara(Fk);
      Par=Partitionseg(Tmp,Fbdy,Eps(1),Eps2);  //
      if Mixlength(PARTITIONPT)>2
        for K=2:Mixlength(PARTITIONPT)
          Tmp1=Mixop(K,PARTITIONPT);
          WIREPT=Mixadd(WIREPT,Tmp1);
        end;
      end;
      Fs=Nohiddenpara2(Par,Fk,Fd,1,Np,Eps);
      HIDDENWIREDATA=Mixjoin(HIDDENWIREDATA,HIDDENDATA);
      FsL=Mixjoin(FsL,Fs);
    end;
  end;
  Nx=Mixlength(FsL);
  if Nx>0
    Mixdisp(Mix(Uname,'-data=',1,':',Nx,'  Time=',timer()));
  end;
  for I=1:length(DvL)
    V=DvL(I);
    Tmp=Paramplot('[U,V]','U=[Umin,Umax]','N=Np(1)');//17.05.07
    FkL=Cuspsplitpara(Tmp,Fd,Eps(1));  //
    for J=1:Mixlength(FkL)
      Fk=Mixop(J,FkL);
      Tmp=Projpara(Fk);
      Par=Partitionseg(Tmp,Fbdy,Eps(1),Eps2); //
      if Mixlength(PARTITIONPT)>2
        for K=2:Mixlength(PARTITIONPT)
          Tmp1=Mixop(K,PARTITIONPT);
          WIREPT=Mixadd(WIREPT,Tmp1);
        end;
      end;
      Fs=Nohiddenpara2(Par,Fk,Fd,1,Np,Eps);
      HIDDENWIREDATA=Mixjoin(HIDDENWIREDATA,HIDDENDATA);
      FsL=Mixjoin(FsL,Fs);
    end;
  end;
  Ny=Mixlength(FsL)-Nx;
  if Ny>0
    Mixdisp(Mix(Vname,'-data=',Nx+1,':',Nx+Ny,'  Time=',timer()));
  end;
endfunction;

