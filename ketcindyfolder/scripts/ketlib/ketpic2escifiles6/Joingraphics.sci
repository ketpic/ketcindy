//  11.11.02  (for list structure)

function P=Joingraphics(varargin)
  Ls=Flattenlist(varargin);
  N=length(Ls);
  Tp=Ls(N);
  Listflg=0;
  if type(Tp)==10
    Tmp=part(Tp,1);
    if Tmp=="L"|Tmp=="l"
      Listflg=1
    end;
    N=N-1;
    Ls=Mixsub(1:N,Ls);
  end;
  if Listflg==1
    P=Ls
  else
    P=[];
    for I=1:N
      Tmp=Ls(I);
      P=[P;%inf,%inf;Tmp];
    end;
    P=P(2:size(P,1),:)
  end
endfunction
