// 08.05.18
// 08.05.19
// 09.06.01    (same as 05.19)

function Out=Kouten(PA,V,P,Q);
  Eps=10.0^(-6);
  A1=PA(1); A2=PA(2);
  V1=V(1); V2=V(2);
  P1=P(1); P2=P(2);
  U1=Q(1)-P1; U2=Q(2)-P2;
  Tmp=norm(P-Q)*norm(V);
  if Tmp==0
    Out=[%inf,-%inf];
    return
  end
  D=U1*V2-U2*V1;
  if abs(D)/Tmp<Eps
    Out=[%inf,-%inf];
    return
  end
  S=((-A2+P2)*V1+(A1-P1)*V2)/D;
  if S>1+Eps | S<-Eps
    Out=[%inf,-%inf];
    return
  end
  T=((-A2+P2)*U1+(A1-P1)*U2)/D;
  Tmp=PA+T*V;
  Out=MixS(T,Tmp,sign(D));
endfunction


