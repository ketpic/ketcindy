// 08.07.13
// 08.10.16

function Res=Kukannozoku(Jokyo,KukanL)
  Eps=10^(-6);
  N=size(KukanL,1);
  T1=Jokyo(1); T2=Jokyo(2);
  Tmp=KukanL(1,:);
  T1=max(T1,Tmp(1));
  Tmp=KukanL(N,:);
  T2=min(T2,Tmp(2));
  Res=[];
  Flg=0;
  for I=1:N
    Ku=KukanL(I,:);
    if Flg==0
      if Ku(2)<T1
        Res=[Res;Ku];
      else
        Flg=1;
        if Ku(1)<T1-Eps 
          Tmp=[Ku(1),T1];
          Res=[Res;Tmp];
        end;
        if Ku(2)>T2+Eps
          Tmp=[T2,Ku(2)];
          Res=[Res;Tmp];
        end;
      end;
    elseif Flg==1
      if Ku(2)<T2
        continue;
      else
        Flg=2;
        if Ku(1)<T2-Eps
          Ku=[T2,Ku(2)];
        end;
        Res=[Res;Ku];
      end;
    else
      Res=[Res;Ku];
    end;
  end;
endfunction;

