// 08.05.31
// 08.08.24
// 09.08.12
// 09.08.13
// 13.12.15  tiny move supported
//           A,B type no longer supported

function Bownamerot(varargin)
  global Wfile FID BOWMIDDLE BOWSTART BOWEND;
  Nargs=length(varargin);
  Eps=10^(-6);
  Flg=1;
  Tmp=varargin(Nargs);
  if type(Tmp)==1 & length(Tmp)==1 & Tmp<0
    Flg=Tmp;
    Nargs=Nargs-1;
  end;
  Siki=varargin(Nargs);
  Nargs=Nargs-1;
  Dr="c";
  if Nargs>=1 then
    Tmp=varargin(Nargs);
    if type(Tmp)==10
      Dr=Tmp;
      Nargs=Nargs-1;
    end
  end
  if Nargs==0
    P=Mixop(1,BOWMIDDLE);
    A=BOWSTART;
    B=BOWEND;
  else
    Bdata=varargin(1);
    P=Bowmiddle(Bdata);
    A=Bdata(1,:);
    B=Bdata(size(Bdata,1),:);
    Tm=0; Tv=0;
    if Nargs>1 then  // 13.12.15
      Tm=varargin(2);
      if Nargs>2 then
        Tv=varargin(3);
      end
    end
  end;
//  elseif Nargs==1
//    Bdata=varargin(1);
//    P=Bowmiddle(Bdata);
//    A=Bdata(1,:);
//    B=Bdata(size(Bdata,1),:);
//  else
//    A=varargin(1); B=varargin(2);
//    D=1/2*Vecnagasa(B-A);
//    Tmp=varargin(3);
//    if type(Tmp)==10
//      H=0.2*D; Siki=Tmp;
//    else
//      H=Tmp*D*0.2; Siki=varargin(4);
//    end
//    H=min(H,D);
//    Ydata=MakeBowdata(A,B,H);
//    C=Op(1,Ydata);
//    R=Op(2,Ydata);
//    T=(Op(3,Ydata)+Op(4,Ydata))/2;
//    P=C+R*[cos(T),sin(T)];
//  end;
  if A(1)>B(1)+Eps
    Tmp=A;
    A=B;
    B=Tmp;
  end;
  if Flg>0
    Tmp=B-A;
  else
    Tmp=A-B;
  end;
  Exprrot(P,Tmp,Tm,Tv,Siki);
endfunction
