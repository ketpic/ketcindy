// 09.03.12

function Out=FouriercoeffL(Fn,T,Upto)
  Out=Mix(Fouriercoeff(Fn,T,'c',0));
  CL=[];
  for K=1:Upto
    Tmp=Fouriercoeff(Fn,T,'c',K);
    CL=[CL,Tmp];
  end;
  Out=Mixadd(Out,CL);
  CL=[];
  for K=1:Upto
    Tmp=Fouriercoeff(Fn,T,'s',K);
    CL=[CL,Tmp];
  end;
  Out=Mixadd(Out,CL);
  Out=Mixadd(Out,T);
endfunction;
