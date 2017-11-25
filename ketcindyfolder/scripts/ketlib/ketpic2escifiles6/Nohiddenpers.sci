// 08.09.21
// 09.12.31 (gsort)

function FigkL=Nohiddenpers(varargin)
  global EyePoint FocusPoint HIDDENDATA;
  Eps=0.001;
  PaL=varargin(1);
  Fk=varargin(2);
  FuncdL=varargin(3);
  Tmp=Mixop(1,FuncdL);
  Fxy=Mixop(1,Tmp);
  K=mtlb_findstr(Fxy,'=');
  Fxy=part(Fxy,K+1:length(Fxy));
  Fbdxy=Mixop(2,FuncdL);
  Tmp=Mixop(3,FuncdL);
  Xname=Mixop(1,Tmp);
  Tmp=Mixop(4,FuncdL);
  Yname=Mixop(1,Tmp);
  FigkL=[];
  if Fbdxy==[]
    return;
  end;
  Bdy=Kyoukai(Fbdxy);
  Ptn=0;
  Fh=Projpers(Fk);
  SeL=[];
  for N=1:length(PaL)-1
    S=(PaL(N)+PaL(N+1))/2;
    P=PointonCurve(S,Fh);
    Tmp=Invperspt(S,Fh,Fk)
    Pk=Mixop(1,Tmp);
    Flg=zeros(1,Mixlength(Fbdxy));
    for I=1:1000
      Tmp=Pk+I*(EyePoint-Pk);
      Tmp1=Naigai(Tmp(1:2),Bdy);
      if Tmp1==Flg
        Flg=1;
        Qk=Tmp;
        break;
      end;
    end;
    if Flg~=1
      disp('Bad EyePoint');
      return;
    end;
    T=poly(0,'t');
    P0=(1-T)*Pk+T*Qk;
    X0str='('+pol2str(P0(1))+')';
    Y0str='('+pol2str(P0(2))+')';
    Z0str='('+pol2str(P0(3))+')';
    Tmp=strsubst(Fxy,Xname,X0str);
    Tmp=strsubst(Tmp,Yname,Y0str);
    Efn=Z0str+'-('+Tmp+')';
    t=0;
    Tmp=evstr(Efn);
    Eps=max(Eps,abs(Tmp));
    Tmp1=evstr([X0str,Y0str]);
    t=1;
    Tmp2=evstr([X0str,Y0str]);
    Seg=Listplot([Tmp1,Tmp2]);
    Tmp=[];
    for I=1:Mixlength(Fbdxy)
      Tmp2=Mixop(I,Fbdxy);
      Tmp1=IntersectcrvsPp(Seg,Tmp2,Eps);
      if Mixlength(Tmp1)>0
        Tmp2=[];
        for J=1:Mixlength(Tmp1)
          Tmp3=Mixop(J,Tmp1);
          Tmp3=Mixop(2,Tmp3)-1;
          Tmp2=[Tmp2,Tmp3];
        end;
        Tmp=[Tmp,Tmp2];
      else
        Tmp2=Mixop(I,Fbdxy);
        Tmp1=Nearestpt(Tmp2,Seg);
        Tmp3=Mixop(5,Tmp1);
        if Tmp3<Eps
          Tmp4=Mixop(4,Tmp1);
          Tmp=[Tmp,Tmp4-1];
        end;
      end;
    end;
    if length(Tmp)==0
      SeL=[SeL,N];
      continue;
    end;
    Tmp=gsort(Tmp);
    Tmp=Tmp(length(Tmp):-1:1);
    ParamL=[0];
    for I=1:length(Tmp)
      Tmp1=Tmp(I);
      Tmp2=ParamL(length(ParamL));
      if Tmp1-Tmp2>Eps
        ParamL=[ParamL,Tmp1];
      end;
    end;
    Nhdflg=0;
    for M=1:length(ParamL)-1
      TL=[ParamL(M),ParamL(M+1)];
      t=TL(1);
      Tmp1=evstr([X0str,Y0str]);
      t=TL(2);
      Tmp2=evstr([X0str,Y0str]);
      Tmp=Naigai(0.5*(Tmp1+Tmp2),Bdy);
      Tmp=modulo(sum(Tmp),2);
      if Tmp==Ptn continue; end;
      Ik=max(ceil(log((TL(2)-TL(1))/Eps)/log(2)),6);
      t=TL(1);
      Tmp1=evstr(Efn);
      t=TL(2);
      Tmp2=evstr(Efn);
      if abs(Tmp1)<=Eps
        if M>1
          Nhdflg=-10;
          break;
        end;
      end;
      if abs(Tmp2)<=Eps
        Nhdflg=-10;
        break;
      end;
      if Tmp2>Eps
        if Tmp1<-Eps
          Nhdflg=-10;
          break;
        end;
        for I=1:Ik
          AddL=[];
          VL=[];
          for J=1:length(TL)-1
            Tmp=(TL(J)+TL(J+1))*0.5;
            AddL=[AddL,Tmp];
            t=Tmp;
            Tmp1=evstr(Efn);
            VL=[VL,Tmp1];
          end;
          Tmp1=min(VL);
          if Tmp1<=-Eps*2
            Nhdflg=-10;
            break;
          end;
          TL=gsort([TL,AddL]);
        end;
        if Nhdflg~=0 break; end;
      else
        if Tmp1<-Eps
          Nhdflg=-10;
          break;
        end;
        for I=1:Ik
          AddL=[];
          VL=[];
          for J=1:length(TL)-1
            Tmp=(TL(J)+TL(J+1))*0.5;
            AddL=[AddL,Tmp];
            t=Tmp;
            Tmp1=evstr(Efn);
            VL=[VL,Tmp1];
          end;
          Tmp1=max(VL);
          if Tmp1>Eps*2
            Nhdflg=-10;
            break;
          end;
          TL=gsort([TL,AddL]);
        end;
        if Nhdflg~=0 break; end;
      end;
    end;
    if Nhdflg==0
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
    if norm(P-Q)>Eps
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
    if norm(P-Q)>Eps
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

