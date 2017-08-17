// 08.09.19
// 08.09.24
// 08.10.09
// 08.10.10
// 08.10.15
// 08.12.06
// 08.12.21
// 08.12.31
// 10.02.16 Eps__  ( And Mislength, Mixop replaced )
// 13.10.21 ( __ added to varibles )

function FsL__=Makesfcutoffdata(MS__)
  global IMPLICITDATA CUSPDATA CUSPPT CUSPSPLITPT ...
         BORDERPT OTHERPARTITION PARTITIONPT ...
         HIDDENDATA BORDERHIDDENDATA;
  timer();
  Nargs__=length(MS__);
  HT__=Op(1,MS__);
  PT__=Op(2,MS__);
  Fd__=Op(3,MS__);
  CutD__=Op(4,MS__);
  Np__=[50,50];
  Eps__=[0.05,1];  // 
  Eps__2=0.2;
  Sgnstr__='+';
  K__=0;
  for I__=5:Nargs__
    Tmp__=Op(I__,MS__);
    if type(Tmp__)==10
      Sgnstr__=Tmp__;
    end; 
	if type(Tmp__)==1  // from
      K__=K__+1;
      if K__==1
        Np__=Tmp__;
        if length(Np__)==1
          Np__=[Np__,Np__];
        end;
      end;
      if K__==2
        Eps__=Tmp__;
        if length(Eps__)==1
          Eps__=[Eps__,1];
        end;
      end;
      if K__==3
        Eps__2=Tmp__;
      end;
    end;  // upto 
  end;
  Tmp__=Op(2,Fd__);
  K__=mtlb_findstr(Tmp__,'=');
  Xname__=part(Tmp__,1:K__-1);
  Tmp__=Op(3,Fd__);
  K__=mtlb_findstr(Tmp__,'=');
  Yname__=part(Tmp__,1:K__-1);
  Tmp__=Op(1,Fd__);
  K__=mtlb_findstr(Tmp__,'=');
  if K__~=[]
    Zname__=part(Tmp__,1:K__-1);
  else
    Tmp__=Op(4,Fd__);
    K__=mtlb_findstr(Tmp__,'=');
    Zname__=part(Tmp__,1:K__-1);
  end;
  Fd__L=Fullformfunc(Fd__);
  Fxy__=Op(1,Fd__L);
  Xf__=Op(2,Fd__L);
  Yf__=Op(3,Fd__L);
  Zf__=Op(4,Fd__L);
  DrwS__=Op(7,Fd__L);
  Tmp__=Op(5,Fd__L);
  K__=mtlb_findstr(Tmp__,'=');
  Uname__=part(Tmp__,1:K__-1);
  Urg__=evstr(part(Tmp__,K__+1:length(Tmp__)));
  Tmp__=Op(6,Fd__L);
  K__=mtlb_findstr(Tmp__,'=');
  Vname__=part(Tmp__,1:K__-1);
  Vrg__=evstr(part(Tmp__,K__+1:length(Tmp__)));
  Umin__=Urg__(1); Umax__=Urg__(2);
  Vmin__=Vrg__(1); Vmax__=Vrg__(2);
  Fugou__=1;
  if Sgnstr__=='-' | Sgnstr__=='n'
    Fugou__=-1;
  end;
  if Mixtype(CutD__)~=1
    V1__=Op(1,CutD__);
    Tmp__=Op(2,CutD__);
    if length(Tmp__)>1
      D__=V1__(1)*Tmp__(1)+V1__(2)*Tmp__(2)+V1__(3)*Tmp__(3);
    else
      D__=Tmp__;
    end;
    Tmp__=string(V1__(1))+'*'+Xname__+'+';
    Tmp__=Tmp__+string(V1__(2))+'*'+Yname__+'+';
    Tmp__=Tmp__+string(V1__(3))+'*'+Zname__+'-';
    Eq__=Tmp__+string(D__);
  elseif type(CutD__)==1
    V1__=CutD__(1:3);
    D__=CutD__(4);
    Tmp__=string(V1__(1))+'*'+Xname__+'+';
    Tmp__=Tmp__+string(V1__(2))+'*'+Yname__+'+';
    Tmp__=Tmp__+string(V1__(3))+'*'+Zname__+'+';
    Eq__=Tmp__+string(D__);
  else
    K__=mtlb_findstr(CutD__,'=');
    if K__>0
      Tmp__1=part(CutD__,1:K__-1);
      Tmp__2=part(CutD__,K__+1:length(CutD__));
      Eq__=Tmp__1+'-('+Tmp__2+')';
    else
      Eq__=CutD__;
    end;
  end;
  Eq__='('+string(Fugou__)+')*('+Eq__+')';
  Tmp__=strsubst(Eq__,Xname__,'('+Xf__+')');
  Tmp__=strsubst(Tmp__,Yname__,'('+Yf__+')');
  Uveq__=strsubst(Tmp__,Zname__,'('+Zf__+')');
  Tmp__1=Op(5,Fd__L);
  Tmp__2=Op(6,Fd__L);
  CutuvL__=Implicitplot(Uveq__,Tmp__1,Tmp__2,Np__);
  EkL__=[];
  for I__=1:length(CutuvL__)
    Out__1=Op(I__,CutuvL__);
    Out__2=[];
    for J__=1:size(Out__1,1)
      Tmp__1=Out__1(J__,1);
      Tmp__2=Out__1(J__,2); 
      Tmp__=strsubst(Xf__,Uname__,'('+string(Tmp__1)+')');
      Tmp__=strsubst(Tmp__,Vname__,'('+string(Tmp__2)+')');
      Xv__=evstr(Tmp__);
      Tmp__=strsubst(Yf__,Uname__,'('+string(Tmp__1)+')');
      Tmp__=strsubst(Tmp__,Vname__,'('+string(Tmp__2)+')');
      Yv__=evstr(Tmp__);
      Tmp__=strsubst(Zf__,Uname__,'('+string(Tmp__1)+')');
      Tmp__=strsubst(Tmp__,Vname__,'('+string(Tmp__2)+')');
      Zv__=evstr(Tmp__);
      Out__2=[Out__2,[Xv__,Yv__,Zv__]];
    end;
    Tmp__=Spaceline(Out__2);
    EkL__=Mixjoin(EkL__,list(Tmp__));
  end;
  Tmp__=mtlb_findstr(DrwS__,'e');
  if length(Tmp__)~=0
    Tmp__=Paramplot('[Umax__,T]','T=[Vmin__,Vmax__]','N='+string(Np__(2)));
    Tmp__L=MakecutbycrvL(Tmp__,CutuvL__,Uveq__,Uname__,Vname__,Eps__(1));
    for I__=1:length(Tmp__L)
      Out__1=Op(I__,Tmp__L);
      Out__2=[];
      for J__=1:size(Out__1,1)
        Tmp__1=Out__1(J__,1);
        Tmp__2=Out__1(J__,2);
        Tmp__=strsubst(Xf__,Uname__,'('+string(Tmp__1)+')');
        Tmp__=strsubst(Tmp__,Vname__,'('+string(Tmp__2)+')');
        Xv__=evstr(Tmp__);
        Tmp__=strsubst(Yf__,Uname__,'('+string(Tmp__1)+')');
        Tmp__=strsubst(Tmp__,Vname__,'('+string(Tmp__2)+')');
        Yv__=evstr(Tmp__);
        Tmp__=strsubst(Zf__,Uname__,'('+string(Tmp__1)+')');
        Tmp__=strsubst(Tmp__,Vname__,'('+string(Tmp__2)+')');
        Zv__=evstr(Tmp__);
        Out__2=[Out__2,[Xv__,Yv__,Zv__]];
      end;
      Tmp__=Spaceline(Out__2);
      EkL__=Mixjoin(EkL__,list(Tmp__));
    end
  end;
  Tmp__=mtlb_findstr(DrwS__,'n');
  if length(Tmp__)~=0
    Tmp__=Paramplot('[T,Vmax__]','T=[Umin__,Umax__]','N='+string(Np__(1)));
    Tmp__L=MakecutbycrvL(Tmp__,CutuvL__,Uveq__,Uname__,Vname__,Eps__(1));
    for I__=1:length(Tmp__L)
      Out__1=Op(I__,Tmp__L);
      Out__2=[];
      for J__=1:size(Out__1,1)
        Tmp__1=Out__1(J__,1);
        Tmp__2=Out__1(J__,2);
        Tmp__=strsubst(Xf__,Uname__,'('+string(Tmp__1)+')');
        Tmp__=strsubst(Tmp__,Vname__,'('+string(Tmp__2)+')');
        Xv__=evstr(Tmp__);
        Tmp__=strsubst(Yf__,Uname__,'('+string(Tmp__1)+')');
        Tmp__=strsubst(Tmp__,Vname__,'('+string(Tmp__2)+')');
        Yv__=evstr(Tmp__);
        Tmp__=strsubst(Zf__,Uname__,'('+string(Tmp__1)+')');
        Tmp__=strsubst(Tmp__,Vname__,'('+string(Tmp__2)+')');
        Zv__=evstr(Tmp__);
        Out__2=[Out__2,[Xv__,Yv__,Zv__]];
      end;
      Tmp__=Spaceline(Out__2);
      EkL__=Mixjoin(EkL__,list(Tmp__));
    end
  end;
  Tmp__=mtlb_findstr(DrwS__,'w');
  if length(Tmp__)~=0
    Tmp__=Paramplot('[Umin__,T]','T=[Vmin__,Vmax__]','N='+string(Np__(2)));
    Tmp__L=MakecutbycrvL(Tmp__,CutuvL__,Uveq__,Uname__,Vname__,Eps__(1));
    for I__=1:length(Tmp__L)
      Out__1=Op(I__,Tmp__L);
      Out__2=[];
      for J__=1:size(Out__1,1)
        Tmp__1=Out__1(J__,1);
        Tmp__2=Out__1(J__,2);
        Tmp__=strsubst(Xf__,Uname__,'('+string(Tmp__1)+')');
        Tmp__=strsubst(Tmp__,Vname__,'('+string(Tmp__2)+')');
        Xv__=evstr(Tmp__);
        Tmp__=strsubst(Yf__,Uname__,'('+string(Tmp__1)+')');
        Tmp__=strsubst(Tmp__,Vname__,'('+string(Tmp__2)+')');
        Yv__=evstr(Tmp__);
        Tmp__=strsubst(Zf__,Uname__,'('+string(Tmp__1)+')');
        Tmp__=strsubst(Tmp__,Vname__,'('+string(Tmp__2)+')');
        Zv__=evstr(Tmp__);
        Out__2=[Out__2,[Xv__,Yv__,Zv__]];
      end;
      Tmp__=Spaceline(Out__2);
      EkL__=Mixjoin(EkL__,list(Tmp__));
    end
  end;
  Tmp__=mtlb_findstr(DrwS__,'s');
  if length(Tmp__)~=0
    Tmp__=Paramplot('[T,Vmin__]','T=[Umin__,Umax__]','N='+string(Np__(1)));
    Tmp__L=MakecutbycrvL(Tmp__,CutuvL__,Uveq__,Uname__,Vname__,Eps__(1));
    for I__=1:length(Tmp__L)
      Out__1=Op(I__,Tmp__L);
      Out__2=[];
      for J__=1:size(Out__1,1)
        Tmp__1=Out__1(J__,1);
        Tmp__2=Out__1(J__,2);
        Tmp__=strsubst(Xf__,Uname__,'('+string(Tmp__1)+')');
        Tmp__=strsubst(Tmp__,Vname__,'('+string(Tmp__2)+')');
        Xv__=evstr(Tmp__);
        Tmp__=strsubst(Yf__,Uname__,'('+string(Tmp__1)+')');
        Tmp__=strsubst(Tmp__,Vname__,'('+string(Tmp__2)+')');
        Yv__=evstr(Tmp__);
        Tmp__=strsubst(Zf__,Uname__,'('+string(Tmp__1)+')');
        Tmp__=strsubst(Tmp__,Vname__,'('+string(Tmp__2)+')');
        Zv__=evstr(Tmp__);
        Out__2=[Out__2,[Xv__,Yv__,Zv__]];
      end;
      Tmp__=Spaceline(Out__2);
      EkL__=Mixjoin(EkL__,list(Tmp__));
    end
  end;
  Fbdxy__=[];
  for I__=1:length(EkL__)
    Out__1=Op(I__,EkL__);
    Out__2=[];
    for J__=1:size(Out__1,1)
      Tmp__=Out__1(J__,1:2);
      Out__2=[Out__2,Tmp__];
    end;
    Tmp__=Listplot(Out__2);
    Fbdxy__=Mixjoin(Fbdxy__,list(Tmp__));
  end;
  if PT__=='pers'
    [Zval__,Xval__,Yval__]=Evlptablepers(Mix(Fd__,Np__));
  end;
  if PT__=='para'
    [Zval__,Xval__,Yval__]=Evlptablepara(Mix(Fd__,Np__));
  end;
  Mixdisp(Mix('Ridge Equation obtained ',timer()));
  Out__2=Implicitplot(Zval__,Xval__,Yval__);
  IMPLICITDATA=Out__2;
  Tmp__L=[];
  for I__=1:length(Out__2)
    Tmp__1=Op(I__,Out__2);
    Tmp__=MakecutbycrvL(Tmp__1,CutuvL__,Uveq__,Uname__,Vname__,Eps__(1));
    for J__=1:length(Tmp__)
      Tmp__L=Mixjoin(Tmp__L,Op(J__,Tmp__));
    end;
  end;
  Out__3=Tmp__L;
  IMPLICITDATA=Out__3;
  Mixdisp(Mix('ImplicitData obtained ',timer()));
  if PT__=='pers'
    Out__4=Cuspsplitpers(Out__3,Fd__,Eps__(1));
  end;
  if PT__=='para' 
    Out__4=Cuspsplitpara(Out__3,Fd__,Eps__(1));
  end;
  CUSPDATA=Out__4;
  CUSPT=CUSPSPLITPT;
  Mixdisp(Mix('CuspData obtained ',timer()));
  FkL__=Mixjoin(EkL__,Out__4);
  if PT__=='pers'
    Fall__=Projpers(FkL__);
  end;
  if PT__=='para'
    Fall__=Projpara(FkL__);
  end;
  if HT__=='raw'
    Mixdisp(Mix('BorderData obtained ',timer()));
    FsL__=FkL__;
    return;
  end;
  BORDERPT=[];
  Tmp__=[];
  for I__=1:length(Fall__)
    Tmp__=Mixjoin(Tmp__,list([]));
  end;
  OTHERPARTITION=Tmp__;
  FsL__=[];
  BORDERHIDDENDATA=[];
  for I__=1:length(Fall__)
    if PT__=='pers'
      Tmp__=Projpers(Op(I__,FkL__));
    end;
    if PT__=='para'
      Tmp__=Projpara(Op(I__,FkL__));
    end;
    ParL__=Partitionseg(Tmp__,Fall__,Eps__(1),Eps__2,I__);
    if length(PARTITIONPT)>2
      Tmp__=length(PARTITIONPT)-1;
      Tmp__1=BORDERPT;
      for J__=2:Tmp__
        Tmp__2=Op(J__,PARTITIONPT);
        Tmp__1=Mixjoin(Tmp__1,list(Tmp__2));
      end;
      BORDERPT=Tmp__1;
    end;
    if PT__=='pers'
      if Fxy__=='p'
        Tmp__1=Op(I__,FkL__);
        Tmp__=Nohiddenpers2(ParL__,Tmp__1,Fd__,Uveq__,Np__,Eps__);
      else
        Tmp__1=Op(I__,FkL__);
        Tmp__=Nohiddenpers2(ParL__,Tmp__1,Fd__,Uveq__,Np__,Eps__);
//        Tmp__2=Mix(Fxy__,Fbdxy__,Xname__,Yname__);
//        Tmp__=Nohiddenpers(ParL__,Tmp__1,Tmp__2);
      end;
    else
      if Fxy__=='p'
        Tmp__1=Op(I__,FkL__);
        Tmp__=Nohiddenpara2(ParL__,Tmp__1,Fd__,Uveq__,Np__,Eps__);
      else
        Tmp__1=Op(I__,FkL__);
        Tmp__=Nohiddenpara2(ParL__,Tmp__1,Fd__,Uveq__,Np__,Eps__);
//        Tmp__2=Mix(Fxy__,Fbdxy__,Xname__,Yname__);
//        Tmp__=Nohiddenpara(ParL__,Tmp__1,Tmp__2);
      end;
    end;
    BORDERHIDDENDATA=Mixjoin(BORDERHIDDENDATA,HIDDENDATA);
    FsL__=Mixjoin(FsL__,Tmp__);
  end;
  Mixdisp(Mix('BorderData obtained ',timer()));
endfunction;
