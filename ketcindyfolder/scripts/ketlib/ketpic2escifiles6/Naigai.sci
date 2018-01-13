// 08.05.18
// 08.05.20

function Ptn=Naigai(A,Bdy)
  V=[1,1];
  Call=Mixlength(Bdy);
  KL=KoutenList(A,V,Bdy);
  Ptn=zeros(1,Call);
  for K=1:Mixlength(KL)
    Ten=Op(K,KL);
    T=Op(1,Ten); NC=Op(4,Ten);
    if T<0
      Tmp=modulo(Ptn(NC)+1,2);
      Ptn(1,NC)=Tmp;
    end
  end
endfunction

