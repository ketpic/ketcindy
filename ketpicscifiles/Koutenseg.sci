//
// 08.05.19
// 09.12.05

function  Out=Koutenseg(varargin)
   //pointdata on AB at which AB intersects CD
   Nargs=length(varargin);
   Eps0=10^(-4);
   A=varargin(1); V=varargin(2)-A;
   Sv2=V(1)^2+V(2)^2;
   if Sv2<10^(-6)
     Out=[%inf,-%inf];
     return
   end    
   P=varargin(3)-A; Q=varargin(4)-A;
   Eps=10.0^(-3);
   if Nargs>=5
     Eps=varargin(5);
   end
   Eps2=0.2;
   if Nargs>=6
     Eps2=varargin(6);
   end
   Eps=min(Eps2,Eps/sqrt(Sv2));
   P1=(P(1)*V(1)+P(2)*V(2))/Sv2;
   P2=(-P(1)*V(2)+P(2)*V(1))/Sv2;
   Q1=(Q(1)*V(1)+Q(2)*V(2))/Sv2;
   Q2=(-Q(1)*V(2)+Q(2)*V(1))/Sv2;
   m1=-Eps; M1=1+Eps;
   m2=-Eps; M2=Eps;
   if (max(P1,Q1)<m1) | (min(P1,Q1)>M1)
     Out=[%inf,-%inf];
     return
   end
   if (max(P2,Q2)<m2) | (min(P2,Q2)>M2)
     Out=[%inf,-%inf];
     return
   end
   if P2*Q2<0
     T=P1-(Q1-P1)/(Q2-P2)*P2;
     if (T>m1) & (T<M1)
       if (T>-Eps0) & (T<1+Eps0)
         Tmp1=A+T*V;
         Tmp2=min(max(T,0),1);
         Out=MixS(Tmp1,Tmp2,0);
       else
         Tmp1=A+T*V;
         Tmp2=min(max(T,0),1);
         Out=MixS(Tmp1,Tmp2,1);
       end
       return
     end
     if P1<m1 | P1>M1...
           | P2<m2 | P2>M2
       if Q1<m1 | Q1>M1...
             | Q2<m2 | Q2>M2
         Out=[%inf,-%inf];
         return
       end
       T=min(max(Q1,0),1);
       Tmp=A+T*V;
       Out=MixS(Tmp,T,1);
       return
     end
     T=min(max(P1,0),1);
     Tmp=A+T*V;
     Out=MixS(Tmp,T,1);
     return
   end
   if P1 > -Eps0 & P1 < 1 + Eps0...
        & P2 > -Eps0 & P2 < Eps0
     T= P1;
     Tmp=A+T*V;
     Out= MixS(Tmp, T, 0);
     return
   end
   if Q1 > -Eps0 & Q1 < 1 + Eps0...
        & Q2 > -Eps0 & Q2 < Eps0
     T= Q1;
     Tmp=A+T*V;
     Out=MixS(Tmp,T,0);
     return
   end
   if P1<m1 | P1>M1... 
         | P2<m2 | P2>M2
     if Q1<m1 | Q1>M1...
           | Q2<m2 | Q2>M2
       Out=[%inf,-%inf];      
       return
     end
     T=min(max(Q1,0),1);
     Tmp=A+T*V;
     Out=MixS(Tmp,T,1);
     return
   end
   if Q1<m1 | Q1>M1... 
           | Q2<m2 | Q2>M2
     T=min(max(P1,0),1);
     Tmp=A+T*V;
     Out=MixS(Tmp,T,1);
     return
   end
   if abs(P2)<abs(Q2)
       T=min(max(P1,0),1);
   else
       T=min(max(Q1,0),1);
   end
   Tmp=A+T*V;
   Out=MixS(Tmp,T,1);
endfunction


