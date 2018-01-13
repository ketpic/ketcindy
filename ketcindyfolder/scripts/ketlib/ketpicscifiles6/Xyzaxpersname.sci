// 08.08.14
// 08.08.15
// 09.09.18

function Kekka=Xyzaxpersname(varargin)
  global MilliIn;
  Eps=10.0^(-6);
  Nargs=length(varargin);
  Dr=0.19*1000/2.54/MilliIn;
  Tmp=varargin(Nargs);
  if Nargs>1 & type(Tmp)==1
    Dr=Dr*Tmp;
    Nargs=Nargs-1;
  end;
  if type(varargin(1))==10
    Xrange=varargin(1); Yrange=varargin(2); Zrange=varargin(3);
    J=mtlb_findstr(Xrange,'=');
    Xname=part(Xrange,1:J-1);
    Tmp=evstr(part(Xrange,J+1:length(Xrange)));
    Px=[Tmp(1),0,0]; Qx=[Tmp(2),0,0];
    J=mtlb_findstr(Yrange,'=');
    Yname=part(Yrange,1:J-1);
    Tmp=evstr(part(Yrange,J+1:length(Yrange)));
    Py=[0,Tmp(1),0]; Qy=[0,Tmp(2),0];
    J=mtlb_findstr(Zrange,'=');
    Zname=part(Zrange,1:J-1);
    Tmp=evstr(part(Zrange,J+1:length(Zrange)));
    Pz=[0,0,Tmp(1)]; Qz=[0,0,Tmp(2)];
  else
    Data=varargin(1);
    Xname='x'; Yname='y'; Zname='z';
    if Nargs>1
      if varargin(2)~=''
        Xname=varargin(2);
      end;
      if varargin(3)~=''
        Yname=varargin(3);
      end;
      if varargin(4)~=''
        Zname=varargin(4);
      end;
    end;
    Tmp=Mixop(1,Data);
    Px=Tmp(1,:); Qx=Tmp(2,:);
    Tmp=Mixop(2,Data);
    Py=Tmp(1,:) ;
    Qy=Tmp(2,:);
    Tmp=Mixop(3,Data);
    Pz=Tmp(1,:);
    Qz=Tmp(2,:);
  end;
  Ph=Perspt(Px); Qh=Perspt(Qx); R=Vecnagasa(Ph,Qh);
  Kekka=[];
  if R>Eps
    Ch=Qh+Dr/R*(Qh-Ph);
    Kekka=Mixadd(Kekka,Pointdata(Ch));
    Expr(Ch,'c',Xname);
  end
  Ph=Perspt(Py); Qh=Perspt(Qy); R=Vecnagasa(Ph,Qh);
  if R>Eps
    Ch=Qh+Dr/R*(Qh-Ph);
    Kekka=Mixadd(Kekka,Pointdata(Ch));
    Expr(Ch,'c',Yname);
  end;
  Ph=Perspt(Pz); Qh=Perspt(Qz); R=Vecnagasa(Ph,Qh);
  if R>Eps
    Ch=Qh+Dr/R*(Qh-Ph);
    Kekka=Mixadd(Kekka,Pointdata(Ch));
    Expr(Ch,'c',Zname);
  end;
endfunction

