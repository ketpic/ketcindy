// 08.10.11
// 08.10.12
// 08.10.15
// 09.06.24
// 10.02.16  Eps
// 11.04.12 Eps0 (bug)
// 13.11.02 bug

function FigkL=Nohiddenpers2(PaL,Fk,Fd,Uveq,Np,Eps)
  global EyePoint FocusPoint HIDDENDATA;  
  Eps0=10^(-5);  // 11.04.12
  Fh=Projpers(Fk);
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
    Tmp=Invperspt(S,Fh,Fk)
    PtA=Mixop(1,Tmp);
    PtAp=Perspt(PtA);
//    Vec=EyePoint-FocusPoint;
    Vec=EyePoint-PtA;  // 2013.11.02
    Epstmp=Eps;  //  2011.04.12
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
        Tmp3=Invperspt(SP,Fh,Fk);
        TP=Mixop(2,Tmp3);
        Tmp3=Invperspt(SQ,Fh,Fk);
        TQ=Mixop(2,Tmp3);
        Tmp4=Partcrv3(TP,TQ,Fk)
        FigkL=Mixadd(FigkL,Tmp4);
        P=Tmp1; SP=PaL(SeL(I));
        Q=Tmp2; SQ=PaL(SeL(I)+1);
      end;
    end;
  end;
  if length(SeL)>0
    if norm(P-Q)>Eps(1) //
      FigL=Mixadd(FigL,Partcrv(P,Q,Fh));
      Tmp3=Invperspt(SP,Fh,Fk);
      TP=Mixop(2,Tmp3);
      Tmp3=Invperspt(SQ,Fh,Fk);
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
        Tmp=Invperspt(SP,Fh,Fk);
        TP=Mixop(2,Tmp);
        Tmp=Invperspt(SQ,Fh,Fk);
        TQ=Mixop(2,Tmp);
        HIDDENDATA=Mixadd(HIDDENDATA,Partcrv3(TP,TQ,Fk));
        P=Tmp1; SP=PaL(SeL(I));
        Q=Tmp2; SQ=PaL(SeL(I)+1);
      end;
    end;
  end;
  if length(SeL)>0
    if norm(P-Q)>Eps(1) //
      Tmp=Invperspt(SP,Fh,Fk);
      TP=Mixop(2,Tmp);
      Tmp=Invperspt(SQ,Fh,Fk);
      TQ=Mixop(2,Tmp);
      HIDDENDATA=Mixadd(HIDDENDATA,Partcrv3(TP,TQ,Fk));
    else
      HIDDENDATA=Mixadd(HIDDENDATA,Fk);
    end;
  end;
endfunction;
