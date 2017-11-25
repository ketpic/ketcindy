// 08.05.26 Debugged
// 09.12.25
// 11.04.13 debugged ( [a,b] )
// 14.03.05 MARKLEN

function Vtickmark(varargin)
  global Wfile FID MARKLEN GENTEN YMIN YMAX;
  Nargs=length(varargin);
  ArgsL=list(varargin(1:Nargs));
  if type(Op(1,ArgsL))==10
    Str=Op(1,ArgsL);
    Tmp=mtlb_findstr(Str,'m');
    if Tmp~=[]
      I=Tmp(1);
    else
      I=0;
    end
    Tmp=mtlb_findstr(Str,'n');
    if Tmp~=[]
      J=Tmp(1);
    else
      J=0;
    end
    Tmp=mtlb_findstr(Str,'r');
    if Tmp~=[]
      K=Tmp(1);
    else
      K=0;
    end;
    if K>0
      Tmp=ascii(Str);
      S=char(Tmp(K+1:length(Tmp)));
      R=msscanf(S,'%f');
      if length(R)==0
        R=1;
      end
    else
      R=1;
      K=length(Str)+1;
    end
    if J>0 then
      Tmp=ascii(Str);
      S=char(Tmp(J+1:K-1));
      if S==[]
        S='';
      end;
      Dn=msscanf(S,'%d');
      if length(Dn)==0
        Dn=1;
      end
    else
      Dn=1000;
      J=length(Str)+1;
    end
    Tmp=ascii(Str);
    S=char(Tmp(I+1:J-1));
    if S==[]
      S='';
    end
    Dm=msscanf(S,'%f');
    if length(Dm)==0
      Dm=1;
    end
    ArgsL=list();
    for I=1:floor((YMAX-GENTEN(2))/Dm)
      ArgsL($+1)=I*Dm;
      if I-floor(I/Dn)*Dn==0
        Str=string(I*Dm*R);
        K=length(Str);
        Tmp=ascii(Str);
        if char(Tmp(K))=='.'
          Str=char(Tmp(1:k-1));
        end
        ArgsL($+1)=Str;
      end
    end
    for I=-1:-1:ceil((YMIN-GENTEN(2))/Dm)
      ArgsL($+1)=I*Dm;
      if I-floor(I/Dn)*Dn==0
        Str=string(I*Dm*R);
        K=length(Str);
        Tmp=ascii(Str);
        if char(Tmp(K))=='.'
          Str=char(1:K-1);
        end
        ArgsL($+1)=Str;
      end
    end
  end
  MemoriList=list();
  Memori=list();
  for N=1:length(ArgsL)
    Dt=Op(N,ArgsL);
    if type(Dt)==1 & length(Dt)>1
      if length(Memori)>0
        MemoriList($+1)=Memori;
      end
      Memori=list(Dt(1),Dt(2));
      continue
    end
    if type(Dt)==10
      Memori($+1)=Dt;
    else
      if length(Memori)>0
        MemoriList($+1)=Memori;
      end
      Memori=list(GENTEN(1),Dt);
    end
  end
  MemoriList($+1)=Memori;
  for N=1:length(MemoriList)
    Dt=MemoriList(N);
    Ndt=length(Dt);
    X=Op(1,Dt);
    Y=Op(2,Dt);
    Tmp=Doscaling([X,Y]);
    X=Tmp(1);
    Y=Tmp(2);
    Moji=Op(Ndt,Dt);
    Tmp1=Unscaling([X+MARKLEN,Y]);
    Tmp2=Unscaling([X-MARKLEN,Y]);
    Fd=Listplot([Tmp1,Tmp2]);    
    Drwline(Fd);
    if Ndt==3
      Tmp=Unscaling([X-MARKLEN,Y]);
      Expr(Tmp,'w',Moji);
    end
    if Ndt==4
      Houkou=Op(3,Dt);
      if mtlb_findstr(Houkou,'w')~=[]
        Tmp=Unscaling([X-MARKLEN,Y]);
        Expr(Tmp,Houkou,Moji);
      else
        Tmp=Unscaling([X+MARKLEN,Y]);
        Expr(Tmp,Houkou,Moji);
      end
    end
    if Wfile=='default'
      mprintf('%s\n','%');
    else
      mfprintf(FID,'%s\n','%');
    end
  end
endfunction;
