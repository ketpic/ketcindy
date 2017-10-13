// 09.03.12

function Out=Powersum(varargin)
  Nargs=length(varargin);
  COEFF=varargin(1);
  x=varargin(2);
  if Nargs>2
    x=x-varargin(3);
  end;
  NL=Mixop(1,COEFF);
  A=Mixop(2,COEFF);
  Upto=min(size(NL,2),size(A,2));
  NL=NL(1:Upto);
  A=A(1:Upto);
  Out=sum(A.*x^NL);
endfunction;

