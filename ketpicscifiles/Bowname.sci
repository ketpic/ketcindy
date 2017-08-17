//
// 08.08.24
// 09.08.12
// 09.08.13
// 13.11.30  Directon supported

function Bowname(varargin)
  global BOWMIDDLE;
  Nargs=length(varargin);
  Siki=varargin(Nargs);
  Nargs=Nargs-1; // 13.11.30
  Dr="c";
  if Nargs>=1 then
    Tmp=varargin(Nargs);
    if type(Tmp)==10
      Dr=Tmp;
      Nargs=Nargs-1;
    end
  end
  if Nargs==0  // 13.11.30
    P=Mixop(1,BOWMIDDLE);
  elseif Nargs==1 // 13.11.30
    Bdata=varargin(1);
    P=Bowmiddle(Bdata);
  else
    A=varargin(1); B=varargin(2);
    D=1/2*Vecnagasa(B-A);
    Tmp=varargin(3);
    if type(Tmp)==10
      H=D*0.2;
    else
      H=Tmp*D*0.2;
    end;
    H=min(H,D);
    Ydata=MakeBowdata(A,B,H);
    Tmp=Bowmiddle(Ydata);
    P=Mixop(1,Tmp);
  end
  Expr(P,Dr,Siki); //13.11.30
endfunction
