// 08.09.10
// 08.09.13

function Out5=Sfbdrawparadata(varargin)
  global IMPLICITDATA CUSPDATA CUSPPT CUSPSPLITPT;
  Nargs=length(varargin);
  Fd=varargin(1);
  FdL=Fullformfunc(Fd);
  Np=[50,50];
  if Nargs>=2
    Np=varargin(2);
    if type(Np)==1 & length(Np)==1
      Np=[Np,Np];
    end;
  end;
  Eps=0.05;
  if Nargs>=3
    Eps=varargin(3);
  end;
  Ts=timer();
  [Zval,Xval,Yval]=Evlptablepara(Mix(Fd,Np));
  Out3=Implicitplot(Zval,Xval,Yval);
  BdyL=Mixop(8,FdL);
  if BdyL~=[]
    Out3=Clipindomain(Out3,BdyL)
  end;
  IMPLICITDATA=Out3;
  Out4=Cuspsplitpara(Out3,Fd,Eps);
  CUSPDATA=Out4;
  CCUSPPT=CUSPSPLITPT;
  Out5=Borderrawdata(Out4,Fd,Np,Eps);
endfunction;

