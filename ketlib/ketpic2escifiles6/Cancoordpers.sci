// 08.08.12

function Out=Cancoordpers(P)
  global EyePoint FocusPoint;
  Tmp=EyePoint-FocusPoint;
  E1=Tmp(1); F1=Tmp(2); G1=Tmp(3);
  Ca=E1/sqrt(E1^2+F1^2);
  Sa=F1/sqrt(E1^2+F1^2);
  E2=E1*Ca+F1*Sa; F2=-E1*Sa+F1*Ca; G2=G1;
  Cb=E2/sqrt(E2^2+G2^2);
  Sb=G2/sqrt(E2^2+G2^2);
  E3=E2*Cb+G2*Sb; F3=F2; G3=-E2*Sb+G2*Cb;
  Xz=P(3); Yz=P(1); Zz=P(2);
  X3=Xz; Y3=Yz*(E3-Xz)/E3; Z3=Zz*(E3-Xz)/E3;
  X2=X3*Cb-Sb*Z3; Y2=Y3; Z2=Cb*Z3+Sb*X3;
  X1=X2*Ca-Sa*Y2; Y1=Ca*Y2+Sa*X2; Z1=Z2;
  X=X1+FocusPoint(1);
  Y=Y1+FocusPoint(2);
  Z=Z1+FocusPoint(3);
  Out=[X,Y,Z];
endfunction

