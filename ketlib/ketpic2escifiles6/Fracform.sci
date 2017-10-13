// 09.08.23

function Out=Fracform(X)
  [N,D]=rat(X);
  Out=[];
  for I=1:size(X,1)
    for J=1:size(X,2)
      Tmp1=N(I,J);
      Tmp2=D(I,J);
      if Tmp2==1
        Out(I,J)=string(Tmp1);
      else
        Out(I,J)=string(Tmp1)+'/'+string(Tmp2);
      end;
    end;
  end;
endfunction;

