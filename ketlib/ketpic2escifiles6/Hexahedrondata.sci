// s : 2014.06.22

function Out=Hexahedrondata(A,V1,V2,V3)
  Tmp=det([V1;V2;V3]);
  if Tmp<0 then
    Tmp1=V1;
    V1=V2;
    V2=Tmp1
  end
  B=A+V1; C=A+V1+V2; D=A+V2;
  E=A+V3; F=B+V3; G=C+V3; H=D+V3;
  VL=list(A,B,C,D,E,F,G,H);
  FL=list([1,4,3,2],[5,6,7,8],[1,2,6,5],[2,3,7,6],[3,4,8,7],[1,5,8,4]);
  Out=list(VL,FL)
endfunction
