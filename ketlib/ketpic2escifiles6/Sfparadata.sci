// 08.08.16

function Out=Sfparadata(varargin)
  Nargs=length(varargin);
  Fd=varargin(1);
  Ndu=25 ; Ndv=25; Np=[50,50];
  if Nargs>=3
    Ndu=varargin(2);
    Ndv=varargin(3);
  end;
  if Nargs>=4
    Np=varargin(4);
  end;
  Tmp=Sf3data(Fd,Ndu,Ndv,Np);
  Out=Projpara(Tmp);
endfunction

