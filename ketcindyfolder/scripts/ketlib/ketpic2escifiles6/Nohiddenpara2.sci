// 08.10.10
// 08.10.15
// 09.06.24
// 10.02.16  Eps

function FigkL=Nohiddenpara2(PaL,Fk,Fd,Uveq,Np,Eps)
  global HIDDENDATA THETA PHI TMP;
  Eps0=10^(-5);
  Fh=Projpara(Fk);
  P1=Ptstart(Fh);
  P2=Ptend(Fh);
  Csp=CuspPt();
  Cspflg=1;
  for I=1:Mixlength(Csp)
    Tmp=Mixop(I,Csp);
    if norm(Tmp-P1)<Eps0
      select Cspflg,
        case 1 then Cspflg=2,
        case 3 then Cspflg=6;
      end;
      continue;
    end;
    if norm(Tmp-P2)<Eps0
      select Cspflg,
        case 1 then Cspflg=3,
        case 2 then Cspflg=6;
      end;
      continue;
    end;
  end;
  SeL=[];
  for N=1:length(PaL)-1
    S=(PaL(N)+PaL(N+1))/2;
    Tmp=Invparapt(S,Fh,Fk);
    PtA=Mixop(1,Tmp);
    PtAp=Parapt(PtA);
    Vec=[sin(THETA)*cos(PHI),sin(THETA)*sin(PHI),cos(THETA)];
    Epstmp=Eps;
    if N==1 & modulo(Cspflg,2)==0
      Tmp=min(Eps(1)*norm(PtAp-Ptstart(Fh)),Eps(1));  //
	  Epstmp=[Tmp,Eps(2)];  //
    end;
    if N==length(PaL)-1 & modulo(Cspflg,3)==0
      Tmp=min(Eps(1)*norm(PtAp-Ptend(Fh)),Eps(1));  //
	  Epstmp=[Tmp,Eps(2)];  //
    end;
    Flg=PthiddenQ(PtA,Vec,Fd,Uveq,Np,Epstmp);
    if Flg==0
      SeL=[SeL,N];
    end;
  end;
  FigL=[];
  FigkL=[];
  for I=1:length(SeL)
    Tmp1=PointonCurve(PaL(SeL(I)),Fh);
    Tmp2=PointonCurve(PaL(SeL(I)+1),Fh);
    if I==1
      P=Tmp1; SP=PaL(SeL(I));
      Q=Tmp2; SQ=PaL(SeL(I)+1);
    else
      if Member(SeL(I)-1,SeL)
        Q=Tmp2; SQ=PaL(SeL(I)+1);
      else
        FigL=Mixadd(FigL,Partcrv(SP,SQ,Fh));
        Tmp3=Invparapt(SP,Fh,Fk);
        TP=Mixop(2,Tmp3);
        Tmp3=Invparapt(SQ,Fh,Fk);
        TQ=Mixop(2,Tmp3);
        Tmp4=Partcrv3(TP,TQ,Fk)
        FigkL=Mixadd(FigkL,Tmp4);
        P=Tmp1; SP=PaL(SeL(I));
        Q=Tmp2; SQ=PaL(SeL(I)+1);
      end;
    end;
  end;
  if length(SeL)>0
    if norm(P-Q)>Eps(1)  //
      FigL=Mixadd(FigL,Partcrv(P,Q,Fh));
      Tmp3=Invparapt(SP,Fh,Fk);
      TP=Mixop(2,Tmp3);
      Tmp3=Invparapt(SQ,Fh,Fk);
      TQ=Mixop(2,Tmp3);
      FigkL=Mixadd(FigkL,Partcrv3(TP,TQ,Fk));
    else
      FigL=Mixadd(FigL,Fh);
      FigkL=Mixadd(FigkL,Fk);
    end;
  end;
  Tmp=[];
  for I=1:length(PaL)-1
    if ~Member(I,SeL)
      Tmp=[Tmp,I];
    end;
  end;
  SeL=Tmp;
  HIDDENDATA=[];
  for I=1:length(SeL)
    Tmp=PaL(SeL(I));
    Tmp1=PointonCurve(Tmp,Fh);
    Tmp=PaL(SeL(I)+1);
    Tmp2=PointonCurve(Tmp,Fh);
    if I==1
      P=Tmp1; SP=PaL(SeL(I));
      Q=Tmp2; SQ=PaL(SeL(I)+1);
    else
      if Member(SeL(I)-1,SeL)
        Q=Tmp2; SQ=PaL(SeL(I)+1);
      else
        Tmp=Invparapt(SP,Fh,Fk);
        TP=Mixop(2,Tmp);
        Tmp=Invparapt(SQ,Fh,Fk);
        TQ=Mixop(2,Tmp);
        HIDDENDATA=Mixadd(HIDDENDATA,Partcrv3(TP,TQ,Fk));
        P=Tmp1; SP=PaL(SeL(I));
        Q=Tmp2; SQ=PaL(SeL(I)+1);
      end;
    end;
  end;
  if length(SeL)>0
    if norm(P-Q)>Eps(1)  //
      Tmp=Invparapt(SP,Fh,Fk);
      TP=Mixop(2,Tmp);
      Tmp=Invparapt(SQ,Fh,Fk);
      TQ=Mixop(2,Tmp);
      HIDDENDATA=Mixadd(HIDDENDATA,Partcrv3(TP,TQ,Fk));
    else
      HIDDENDATA=Mixadd(HIDDENDATA,Fk);
    end;
  end;
endfunction;

