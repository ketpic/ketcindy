// 08.09.09
// 08.09.10
// 08.09.24

function PlotL=Connectseg(varargin)
  Nargs=length(varargin);
  Pdata=varargin(1);
  Eps=10^(-5);
  if Nargs>=2
    Eps=varargin(2)
  end;
  if Mixtype(Pdata)~=1
    Tmp=Mixop(1,Pdata);
    Tmp=size(Tmp,2);
    Sep=%inf*ones(1,Tmp);
    Tmp=[];
    for I=1:Mixlength(Pdata)
      Tmp1=Mixop(I,Pdata);
      Tmp=[Tmp;Sep;Tmp1];
    end;
    Pdata=Tmp(2:size(Tmp,1),:);
  end;
  Din=Dataindex(Pdata);
  PlotL=[];
  Qd=Pdata(Din(1,1):Din(1,2),:);
  Din=Din(2:size(Din,1),:);
  N=size(Din,1);
  while N>0
    Ah=Qd(1,:);Ao=Qd(size(Qd,1),:);
    Flg=0;
    for J=1:N
      St=Din(J,1);
      En=Din(J,2);
      P=Pdata(St,:);
      Q=Pdata(En,:);
      if norm(P-Ao)<Eps
        Tmp=Pdata(St+1:En,:);
        Qd=[Qd;Tmp];
        Din=[Din(1:J-1,:);Din(J+1:N,:)];
        Flg=1;
        break;
      end;
      if norm(Q-Ao)<Eps
        Tmp=Pdata(En-1:-1:St,:);
        Qd=[Qd;Tmp];
        Din=[Din(1:J-1,:);Din(J+1:N,:)];
        Flg=1;
        break;
      end;
      if norm(P-Ah)<Eps
        Tmp=Pdata(En:-1:St+1,:);
        Qd=[Tmp;Qd];
        Din=[Din(1:J-1,:);Din(J+1:N,:)];
        Flg=1;
        break;
      end;
      if norm(Q-Ah)<Eps
        Tmp=Pdata(St:En-1,:);
        Qd=[Tmp;Qd];
        Din=[Din(1:J-1,:);Din(J+1:N,:)];
        Flg=1;
        break;
      end;
    end;
    if Flg==0
      PlotL=Mixadd(PlotL,Qd);
      Qd=Pdata(Din(1,1):Din(1,2),:);
      Din=Din(2:N,:);
    end;
    N=size(Din,1);
  end;
  if size(Qd,1)>0
    PlotL=Mixadd(PlotL,Qd);
  end;
endfunction

