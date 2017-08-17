// 09.10.0

function Out=Crossprod(a,b)
  if length(a)==3
    Tmp1=a(2)*b(3)-a(3)*b(2);
    Tmp2=a(3)*b(1)-a(1)*b(3);
    Tmp3=a(1)*b(2)-a(2)*b(1);
    Out=[Tmp1,Tmp2,Tmp3];
  else
    Out=a(1)*b(2)-a(2)*b(1);
  end;
endfunction

