// 08.05.28
// 08.05.29
// 09.06.13
// 10.04.24
// 10.04.25
// 11.01.07 ( major changed )

function OutL=Splinedata(varargin)
  global SplinePt;
  Nargs=length(varargin);
  Eps=10^(-3);
  PL=varargin(1);
  if type(PL)==10  // 100425
    Fname=PL;
    PL=Readtextdata(Fname);
  else
    if size(PL,1)==1
      PL=matrix(PL,2,length(PL)/2);
      PL=PL';
    end;
  end;
  if size(PL,2)==3
    Flg3=1;
  else
    Flg3=0;
  end;
  PLL=Dividegraphics(PL);  
  N=50;
  C=[];
  for I=2:Nargs
    Tmp=varargin(I);
    if type(Tmp)~=10 continue; end
    if mtlb_findstr(Tmp,'=')~=[]
      execstr(Tmp);
    else
      Tmp1=Strop(1,Tmp);
      if Tmp1=='C' | Tmp1=='c'
        C=1:length(PLL);
      end;
    end;
  end;
  Cflg=zeros(1,length(PLL));
  for J=1:length(C)
    K=C(J);
    Cflg(K)=1;
  end;
  if length(N)>1
    if type(Nj)==1
      Nj=N;
    else
      Nj=[];
      for J=1:length(N)
        Nj(J)=N(J);
      end;
    end;
  else
    Tmp1=[];
    for J=1:length(PLL)
      Tmp1(J)=size(PLL(J),1);
    end;
    MxP=max(Tmp1);
    Nj=[];
    for J=1:length(PLL)
      Tmp=size(PLL(J),1);
      Tmp1=round(N/MxP*(Tmp-1));
      Nj(J)=Tmp1;
    end;
  end;
  OutL=list();
  for J=1:length(PLL) //
    PL=PLL(J);
    if Cflg(J)==1
      if norm(PL(1,:)-PL(size(PL,1),:))>Eps
        PL=[PL;PL(1,:)];
        Nj(J)=round(N/MxP*size(PL,1));
      else
        PL(size(PL,1),:)=PL(1,:);
      end
    end;
    SplinePt=PL;
    Tn=1:size(PL,1);
    Xn=PL(:,1)';
    Yn=PL(:,2)';
    if Flg3==1 Zn=PL(:,3)';end;
    if Cflg(J)==0
      Dxn=splin(Tn,Xn);
      Dyn=splin(Tn,Yn);
      if Flg3==1 Dzn=splin(Tn,Zn); end;
    else
      Dxn=splin(Tn,Xn,'periodic');
      Dyn=splin(Tn,Yn,'periodic');
      if Flg3==1 Dzn=splin(Tn,Zn,'periodic'); end;
    end
    T=linspace(1,size(PL,1),Nj(J));
    X=interp(T,Tn,Xn,Dxn);
    Y=interp(T,Tn,Yn,Dyn);
    if Flg3==1 Z=interp(T,Tn,Zn,Dzn); end;  
    if Flg3==1
      Out=[X',Y',Z'];
    else
      Out=[X',Y'];
    end;
    OutL($+1)=Out;
  end;
  if length(OutL)==1
    OutL=OutL(1);
  end;
endfunction;
