// 08.10.15

function Out=Cutsf2d(Nvec,GL,Flg)
  global THETA PHI
  Theta=THETA; Phi=PHI;
  Tmp=Rotate3data(GL,Nvec,[-1,0,0]);
  THETA=%pi/2; PHI=0;
  Out=Projpara(Tmp);
  if Flg==1
    Windisp(Out);
  end;
  THETA=Theta; PHI=Phi;
endfunction;

