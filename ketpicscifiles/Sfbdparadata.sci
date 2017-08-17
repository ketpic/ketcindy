// 08.09.13
// 10.02.16  Eps => [Eps, Epsmag]

function Out5=Sfbdparadata(varargin)
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
  Eps=[0.05,1];  //
  if Nargs>=3
    Eps=varargin(3);
  end;
  if length(Eps)==1  //
    Eps=[Eps,1];  //
  end;  //
  Eps2=0.2;
  if Nargs>=4
    Eps2=varargin(4);
  end;
  Ts=timer();
  [Zval,Xval,Yval]=Evlptablepara(Mix(Fd,Np));
  Out3=Implicitplot(Zval,Xval,Yval);
  IMPLICITDATA=Out3;
  Mixdisp(Mix('ImplicitData obtained ',timer()));
  Out4=Cuspsplitpara(Out3,Fd,Eps(1));  //
  CUSPDATA=Out4;
  CUSPPT=CUSPSPLITPT;
  Mixdisp(Mix('CuspData obtained ',timer()));
  Out5=Borderparadata(Out4,Fd,Np,Eps,Eps2);
  Mixdisp(Mix('BorderData obtained ',timer()));
endfunction;

