// 08.10.26

function Out=Viewfrom(varargin)
  global THETA PHI
  Nargs=length(varargin);
  Nvec=varargin(1);
  GL=varargin(2);
  Flg=1;
  if Nargs>=3
    Flg=varargin(3);
  end;
  Theta=THETA; Phi=PHI;
  Tmp=Rotate3data(GL,Nvec,[-1,0,0]);
  THETA=%pi/2; PHI=0;
  Out=Projpara(Tmp);
  if Flg==1
    Windisp(Out);
  end;
  THETA=Theta; PHI=Phi;
endfunction;

