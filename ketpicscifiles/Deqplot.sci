
// 08.09.22
// 09.03.10
// 09.10.09  ( ` and order )
// 09.10.09b  ( system )
// 09.11.12  ( debug for x<0 )
// 13.10.19 ( __ added to variables )
// 15.11.16  N changed to number of intervals
// 15.12.08  bug of optiion ( __ ) fixed

function P__=Deqplot(varargin)
  global XMIN XMAX YMIN YMAX
  Nargs__=length(varargin);
  Eps__=10^(-5);
  Fnstr__=varargin(1);
  Fnstr__=strsubst(Fnstr__,Prime(),'`');
  K__=mtlb_findstr(Fnstr__,'=');
  Str__=part(Fnstr__,1:(K__-1));
  Fnstr__=part(Fnstr__,(K__+1):length(Fnstr__));
  JL__=mtlb_findstr(Str__,'`');
  Yname__=part(Str__,1:(JL__(1)-1));
  Yname__=strsubst(Yname__,',',';');
  Tmp__=mtlb_findstr(Yname__,';');
  if length(Tmp__)>0
    Dim__=length(Tmp__)+1;
    Order__=1;
    Fnstr__=strsubst(Fnstr__,',',';');
  else
    Dim__=1;
    Order__=length(JL__);
  end;
  Rgstr__=varargin(2);
  K__=mtlb_findstr(Rgstr__,'=');
  if K__~=[]
    Xname__=part(Rgstr__,1:K__-1);
    Rng__=evstr(part(Rgstr__,K__+1:length(Rgstr__)));
  else
    Xname__=Rgstr__;
    Rng__=[XMIN,XMAX];
  end;
  X0__=varargin(3);
  Y0__=varargin(4);
  if size(Y0__,2)>1
    Y0__=Y0__';
  end;
  N__=50;
  if Nargs__>=5
    Tmp__=varargin(5);
    Tmp__=strsubst(Tmp__,"=","__=");   // 15.12.08
    Tmp__=strsubst(Tmp__,"____","__");
    execstr(Tmp__);
  end;
  X1__=Rng__(1); X2__=Rng__(2);
  dX__=(X2__-X1__)/(N__-1);
  dX__=(X2__-X1__)/(N__); // 15.11.16
  if Dim__>1
    Tmp__=mtlb_findstr(Yname__,'[');
    Data__=part(Yname__,Tmp__+1:length(Yname__));
    Tmp__=mtlb_findstr(Data__,']');
    Data__=part(Data__,1:Tmp__-1);
    Data__=';'+Data__+';';
    NL__=mtlb_findstr(Data__,';');
    NameL__=list();
    for I__=1:length(NL__)-1
      Tmp__=part(Data__,NL__(I__)+1:NL__(I__+1)-1);
      NameL__(I__)=Tmp__;
    end;
    Fnrep__=Fnstr__;
    for I__=1:length(NameL__)
      Tmp__=NameL__(I__);
      Fnrep__=strsubst(Fnrep__,Tmp__,'Pt('+string(I__)+')');
    end:
    Tmp1__='Outf=Dfp__('+Xname__+',Pt)';
    Tmp2__='Outf='+Fnrep__;
    deff(Tmp1__,Tmp2__);
    Y0p__=Y0__;
    Tmp1__='Outf=Dfn__('+Xname__+',Pt)';
    Tmp2__='Outf=-('+Fnrep__+')';
    deff(Tmp1__,Tmp2__);
    Y0n__=Y0__;
  else
    YL__=mtlb_findstr(Fnstr__,Yname__);
    Fnrep__=part(Fnstr__,1:YL__(1)-1);
    for I__=1:length(YL__)
      Py__=YL__(I__);
      J__=1;
      K__=Py__+1;
      while part(Fnstr__,K__:K__)=='`'
        J__=J__+1; K__=K__+1;
      end;
      Fnrep__=Fnrep__+Yname__+'('+string(J__)+')';
      if I__==length(YL__)
        Fnrep__=Fnrep__+part(Fnstr__,K__:length(Fnstr__));
      else
        J__=YL__(I__+1)-1;
        if J__>=K__
          Fnrep__=Fnrep__+part(Fnstr__,K__:J__);
        end;
      end;
    end;
    Eqvec__='[';
    for I__=1:Order__-1
      Eqvec__=Eqvec__+Yname__+'('+string(I__+1)+');';
    end;
    Eqvec__=Eqvec__+Fnrep__+']';
    Tmp1__='Outf=Dfp__('+Xname__+','+Yname__+')';
    Tmp2__='Outf='+Eqvec__;
    deff(Tmp1__,Tmp2__);
    Y0p__=Y0__;
    YL__=mtlb_findstr(Fnstr__,Yname__);
    Fnrep__=part(Fnstr__,1:YL__(1)-1);
    for I__=1:length(YL__)
      Py__=YL__(I__);
      J__=1;
      K__=Py__+1;
      while part(Fnstr__,K__:K__)=='`'
        J__=J__+1; K__=K__+1;
      end;
      if modulo(J__,2)==1
        Fnrep__=Fnrep__+Yname__+'('+string(J__)+')';
      else
        Fnrep__=Fnrep__+'(-'+Yname__+'('+string(J__)+'))';
      end;
      if I__==length(YL__)
        Fnrep__=Fnrep__+part(Fnstr__,K__:length(Fnstr__));
      else
        J__=YL__(I__+1)-1;
        if J__>=K__
          Fnrep__=Fnrep__+part(Fnstr__,K__:J__);
        end;
      end;
    end;
    if modulo(Order__,2)==1
      Fnrep__='-('+Fnrep__+')';
    end;
    Fnrep__=strsubst(Fnrep__,Xname__,'(-'+Xname__+')');  // 09.11.12
    Eqvec__='[';
    for I__=1:Order__-1
      Eqvec__=Eqvec__+Yname__+'('+string(I__+1)+');';
    end;
    Eqvec__=Eqvec__+Fnrep__+']';
    Tmp1__='Outf=Dfn__('+Xname__+','+Yname__+')';
    Tmp2__='Outf='+Eqvec__;
    deff(Tmp1__,Tmp2__);
    Y0n__=[];
    for I__=1:size(Y0__,1)
      Y0n__=[Y0n__;(-1)^(I__-1)*Y0__(I__)];
    end;
  end;
  if X0__<=X1__
    X__=X1__:dX__:X2__;
    Y__=ode(Y0p__,X0__,X__,Dfp__);
    M__=min(size(X__,2),size(Y__,2));
    if Dim__>1
      PL__=Y__';
      P__=PL__(1:M__,:);
    else
      P__=[X__(:,1:M__);Y__(1,1:M__)]';
    end;
    return;
  end;
  if X2__<=X0__
    X__=(-X2__):dX__:(-X1__);
    Y__=ode(Y0n__,-X0__,X__,Dfn__);
    X__=-X__;
    M__=min(size(X__,2),size(Y__,2));
    if Dim__>1
      PL__=Y__';
      P__=PL__(1:M__,:);
    else
      P__=[X__(:,1:M__);Y__(1,1:M__)]';
    end;
    return;
  end;
  XP__=X0__:dX__:X2__;
  YP__=ode(Y0p__,X0__,XP__,Dfp__);
  M__=min(size(XP__,2),size(YP__,2));
  XP__=XP__(:,1:M__);
  YP__=YP__(:,1:M__);
  XN__=(-X0__)+dX__:dX__:(-X1__);
  YN__=ode(Y0n__,-X0__,XN__,Dfn__);
  M__=min(size(XN__,2),size(YN__,2));
  XN__=XN__(:,1:M__);
  YN__=YN__(:,1:M__);
  XN__=-XN__;
  XN__=XN__(length(XN__):-1:1);
  YN__=YN__(:,size(YN__,2):-1:1);
  if Dim__>1
    P__=[YN__';YP__']
  else
    X__=[XN__,XP__];
    Y__=[YN__(1,:),YP__(1,:)];
    P__=[X__;Y__]';
  end;
endfunction;
