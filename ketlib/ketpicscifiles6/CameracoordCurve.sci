// 08.08.14
// 08.10.16
// 09.09.25

function Out=CameracoordCurve(Curve)
  global FocusPoint EyePoint;
  Out=[]; // 09.09.25
  for J=1:size(Curve,1)
    P=Curve(J,:);
    Tmp=P-FocusPoint;
    X1=Tmp(1); Y1=Tmp(2); Z1=Tmp(3);
    Tmp=EyePoint-FocusPoint;
    E1=Tmp(1); F1=Tmp(2); G1=Tmp(3);
    Ca=E1/sqrt(E1^2+F1^2);
    Sa=F1/sqrt(E1^2+F1^2);
    X2=X1*Ca+Y1*Sa; Y2=-X1*Sa+Y1*Ca; Z2=Z1;
    E2=E1*Ca+F1*Sa; F2=-E1*Sa+F1*Ca; G2=G1;
    Cb=E2/sqrt(E2^2+G2^2);
    Sb=G2/sqrt(E2^2+G2^2);
    X3=X2*Cb+Z2*Sb; Y3=Y2; Z3=-X2*Sb+Z2*Cb;
    E3=E2*Cb+G2*Sb; F3=F2; G3=-E2*Sb+G2*Cb;
    Xz=X3;
    Yz=E3/(E3-X3)*Y3;
    Zz=E3/(E3-X3)*Z3;
    Out=[Out;Yz,Zz,Xz];
  end;
endfunction

