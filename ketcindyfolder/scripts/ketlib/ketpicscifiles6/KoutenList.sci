// 08.05.18
// 08.05.20
// 08.06.02

function TenL=KoutenList(PA,V,Bdy)
  Eps=10.0^(-6);
  TenL=[];
  for N=1:Mixlength(Bdy)
    KL=Op(N,Bdy);
    for K=1:size(KL,1)-1
      P=KL(K,:); Q=KL(K+1,:);
      if P~='/' & Q~='/'
        Tmp=Kouten(PA,V,P,Q);
        if Tmp~=[%inf,-%inf]
          Ten=Mixadd(Tmp,N);
          Flg=0;
          NN=Mixlength(TenL);
          I=1;
          while Flg==0 & I<=NN
            Tmp=Op(I,TenL);
            if Op(1,Ten)<Op(1,Tmp)-Eps
              Tmp=Mixsub(1:I-1,TenL);
              Tmp1=Mixadd(Tmp,Ten);
              Tmp2=Mixsub(I:Mixlength(TenL),TenL);
              TenL=Mixjoin(Tmp1,Tmp2);
              Flg=1;
            elseif Op(1,Ten)<Op(1,Tmp)+Eps
              if Op(4,Ten)~=Op(4,Tmp)
                Tmp=Mixsub(1:I-1,TenL);
                Tmp1=Mixadd(Tmp,Ten);
                Tmp2=Mixsub(I:Mixlength(TenL),TenL);
                TenL=Mixjoin(Tmp1,Tmp2);
                Flg=1;
              elseif Op(3,Ten)~=Op(3,Tmp)
                Tmp1=Mixsub(1:I-1,TenL);
                Tmp2=Mixsub(I+1:Mixlength(TenL),TenL);
                TenL=Mixjoin(Tmp1,Tmp2);
              end
              Flg=1;
            end
            I=I+1;
          end
          if Flg==0
            TenL=Mixadd(TenL,Ten);
          end
        end
      end
    end
  end
endfunction

