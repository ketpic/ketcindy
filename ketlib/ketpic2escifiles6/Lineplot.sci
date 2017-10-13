// 09.10.09
// 09.10.12
// 09.11.01
// 09.11.12
// 09.12.06
// 10.12.04

function Out=Lineplot(varargin)
  Nargs=length(varargin);
  A=varargin(1);
  if type(A)==1        //  09.11.12 from
    Tmp=length(A);
    if Tmp>3
      B=A(Tmp/2+1:Tmp);
      A=A(1:Tmp/2);
      Is=2;
    else
      B=varargin(2);
      Is=3;
    end;
  else
    B=A(2);
    A=A(1);
    Is=2;
  end;                 // upto
  Mag=100; Semi='';
  for I=Is:Nargs
    Tmp=varargin(I);
    select type(Tmp)
      case  1
        Mag=Tmp;
      case 10
        Semi=Tmp;
    end;
  end;
  V= Mag/norm(B-A)*(B-A)      // 10.12.04 from here
 if Semi=="" 
   Out=Listplot(A-V,A+V)
 elseif Semi=="+"
   Out=Listplot(A,A+V)
 else
   Out=Listplot(A-V,A)
 end                                              //  10.12.04 to here
endfunction;
