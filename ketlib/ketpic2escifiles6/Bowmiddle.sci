//
// 08.05.22
// 08.05.31
// 09.08.12

function M=Bowmiddle(varargin)
  global BOWMIDDLE;
  Nargs=length(varargin);
  if Nargs==0
    M=BOWMIDDLE;
    return;
  end;
  if Nargs==1
    Bdata=varargin(1);
    A=Bdata(1,:);
    Dind=Dataindex(Bdata);
    Dc=size(Dind,1);
    Tmp=Dind(Dc,2);
    B=Bdata(Tmp,:);
    if Dc==1
      Tmp1=round(Tmp/2);
    else
      Tmp1=Dind(1,2);
    end;
    D=Bdata(Tmp1,:);
    B=B-A;
    D=D-A;
    Tmp1=B(1)*D(2)-D(1)*B(2);
    Tmp2=((B(1)^2+B(2)^2)*D(2)-B(2)*(D(1)^2+D(2)^2))/2;
    Tmp3=-((B(1)^2+B(2)^2)*D(1)-B(1)*(D(1)^2+D(2)^2))/2;
    C=[Tmp2,Tmp3]/Tmp1+A;
    R=norm(C-A);
    B=B+A;
    V=(A+B)/2-C;
    V=V/norm(V);
    M=C+R*V;
  else
    A=varargin(1); B=varargin(2);
    D=1/2*Vecnagasa(B-A);
    H=0.2*D;
    if length(varargin)>=3
      Tmp=varargin(3);
      H=Tmp*D*0.2;
    end
    H=min(H,D);
    Ydata=MakeBowdata(A,B,H);
    C=Op(1,Ydata);
    R=Op(2,Ydata);
    T=(Op(3,Ydata)+Op(4,Ydata))/2;
    P=C+R*[cos(T),sin(T)];
    M=MixS(P,T);
  end
endfunction
