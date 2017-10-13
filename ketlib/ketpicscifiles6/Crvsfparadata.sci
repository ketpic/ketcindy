// 08.10.24
// 08.10.25
// 08.10.26
// 08.10.27
// 09.06.02
// 09.12.31 (gsort)
// 10.02.16

function Out=Crvsfparadata(varargin)
  global PARTITIONPT HIDDENDATA CRVSFHIDDENDATA
  Nargs=length(varargin);
  Sepflg=0;
  Tmp=varargin(Nargs);
  if type(Tmp)==1 & Tmp<=0
    Sepflg=1;
    Nargs=Nargs-1;
  end;
  Fk=varargin(1);
  if Mixtype(Fk)==1
    FkL=Mix(Fk);
  else
    FkL=Fk;
  end;
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
  Eps=[0.05,1];  //
  if Nargs>=N
    Eps=varargin(N);
  end;
  if length(Eps)==1 //
    Eps=[Eps,1]; //
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
  Out=[];
  CRVSFHIDDENDATA=[];
  for Nn=1:Mixlength(FkL)
    Fk=Mixop(Nn,FkL);
    Tmp=Projpara(Fk);
    Par=Partitionseg(Tmp,Fbdy,Eps(1),Eps2); //
    if Sepflg==0
      for I=1:Numptcrv(Fk)-1
        Pa=Ptcrv(I,Fk);
        Pb=Ptcrv(I+1,Fk);
        PtL=Meetpoints(Pa,Pb,Fd,1,Np,Eps(1));  //
        for J=1:Mixlength(PtL)
          Tmp=Mixop(J,PtL);
          Tmp=Parapt(Tmp);
          Tmp1=ParamonCurve(Tmp,I,Projpara(Fk));
          Tmp2=min(abs(Par-Tmp1));
          if Tmp2*norm(Parapt(Pb-Pa))>Eps (1)  // 
            Par=[Par,Tmp1];
          end;
        end;
        Par=gsort(Par);
        Par=Par(length(Par):-1:1);
      end;
    end;
    Tmp1=Nohiddenpara2(Par,Fk,Fd,1,Np,Eps);
    Out=Mixjoin(Out,Tmp1);
    CRVSFHIDDENDATA=Mixjoin(CRVSFHIDDENDATA,HIDDENDATA);
  end;
endfunction;

