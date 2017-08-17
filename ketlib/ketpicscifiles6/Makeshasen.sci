// 08.05.20
// 09.10.05
// 10.01.20
// 10.02.01

function Out=Makeshasen(PtnL,PA,V,Bdy)
  Eps=10.0^(-6);
  TenL=KoutenList(PA,V,Bdy);
  Nten=length(TenL);
  Call=length(Bdy);
  Ptn=zeros(1,Call);
  Out=list();
  GL=[]
  Te=-10.0^6;
  for I=1:Nten-1
    TenP=Op(I,TenL); TenQ=Op(I+1,TenL);
    Ts=Op(1,TenP);
    P=Op(2,TenP); Q=Op(2,TenQ);
    NC=Op(4,TenP);
    Tmp=modulo(Ptn(NC)+1,2);
    Ptn(1,NC)=Tmp;
    if Op(1,TenQ)-Ts>Eps
      if Member(Ptn,PtnL)
        if abs(Te-Ts)>Eps
          if GL~=[]
            J=length(Out);
            Out(J+1)=GL;
          end;
          Tmp=Listplot(P,Q);
          GL=Tmp;
        else
          GL=[GL;Q];
        end
        Te=Op(1,TenQ);
      end
    end
  end
  if size(GL,1)>0
    Out=Mixjoin(Out,list(GL))
  end;  
endfunction
