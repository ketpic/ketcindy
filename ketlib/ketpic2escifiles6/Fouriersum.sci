// 09.03.12

function Out=Fouriersum(COEFF,x)
  C=Mixop(1,COEFF);
  A=Mixop(2,COEFF);
  B=Mixop(3,COEFF);
  T=Mixop(4,COEFF);
  Upto=size(A,2);
  L=T/2;
  K=1:Upto;
  Tmp1=sum(A(K).*cos(K*%pi*x/L));
  Tmp2=sum(B(K).*sin(K*%pi*x/L));
  Out=C+Tmp1+Tmp2;
endfunction;

