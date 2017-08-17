// 09.03.13

function Out=Fouriercoeff(Fn,T,Ch,K)
  Eps=10^(-5);
  L=T/2;
  Tmp1='Out=FUNC(x)';
  if Ch=='c'
    Tmp2='Out=Fn(10*L*x)*cos('+string(K)+'*%pi*x*10)';
  else
    Tmp2='Out=Fn(10*L*x)*sin('+string(K)+'*%pi*x*10)';
  end;    
  deff(Tmp1,Tmp2);
  Out=10*intg(-0.1,0.1,FUNC);
  if K==0
    Out=Out/2;
  end;
  if abs(Out)<Eps
    Out=0;
  end;
endfunction;

