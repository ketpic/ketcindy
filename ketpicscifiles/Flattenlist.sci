//  10.11.13

function Out=Flattenlist(varargin)
  Out=list();
  for N=1:length(varargin)
    D=varargin(N);
    if type(D)~=15
      Out($+1)=D;
    else
      for I=1:length(D)
        Ds=D(I);
        Tmp=Flattenlist(Ds);
        Out=lstcat(Out,Tmp);
      end;
    end;
  end;
endfunction;
