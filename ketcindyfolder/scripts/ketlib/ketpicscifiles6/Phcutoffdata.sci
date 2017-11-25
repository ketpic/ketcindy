// 08.08.17
// 10.08.15  near line 25 or so
// 13.10.21 ( __ added to varibles )

function Out2__=Phcutoffdata(varargin)
  global PHCUTPOINTL PHVERTEXL PHFACEL;
  Eps__=10^(-4);
  Out2__=[];
  VL__=varargin(1);
  FaceL__=varargin(2);
  PlaneD__=varargin(3);
  Sgnstr__=varargin(4);
  Fugou__=1;
  if Sgnstr__=='-' | Sgnstr__=='n'  Fugou__=-1; end;
  Out0__=Phcutdata(VL__,FaceL__,PlaneD__);
  PtL__=PHCUTPOINTL;
  PHVERTEXL=VL__;
  PHFACEL=FaceL__;
  if PtL__==[]
    Out2__=Out0__;
    return;
  end;
  N1__=Mixlength(VL__);
  Face__=[];
  for I__=1:Mixlength(PtL__);
    Tmp__=Mixop(I__,PtL__);
    Tmp3__=Mixop(1,Tmp__); // 2010.08.15
    Tmp1__=Tmp3__(1); Tmp2__=Tmp3__(2); // 2010.08.15
    if Tmp1__~=Tmp2__
      VL__=Mixadd(VL__,Mixop(2,Tmp__));
      N1__=N1__+1;
      Tmp1__=N1__;
    end;
    Face__=[Face__,Tmp1__];
    PtL__(I__)=list(Mixop(1,Tmp__),Tmp1__); // 2010.08.15
//    Tmp2__=Mixsub(1:I__-1,PtL__);
//    Tmp2__=Mixadd(Tmp2__,Mix(Mixop(1,Tmp__),Tmp1__));
//    Tmp3__=Mixsub(I__+1:Mixlength(PtL__),PtL__);
//    PtL__=Mixjoin(Tmp2__,Tmp3__);
  end;
  OutfL__=MixS(Face__);
  if Mixtype(PlaneD__)~=1
    V1__=Mixop(1,PlaneD__);
    Tmp__=Mixop(2,PlaneD__);
    if length(Tmp__)>1
      d__=V1__(1)*Tmp__(1)+V1__(2)*Tmp__(2)+V1__(3)*Tmp__(3);
    else
      d__=Tmp__;
    end;
  elseif type(PlaneD__)==1
    V1__=PlaneD__(1:3);
    d__=PlaneD__(4);
  else
    K__=mtlb_findstr(PlaneD__,'=');
    if K__>0
      Tmp1__=part(PlaneD__,1:K__-1);
      Tmp2__=part(PlaneD__,K__+1:length(PlaneD__));
      PlaneD__=Tmp1__+'-('+Tmp2__+')';
    end;
    x=0; y=0; z=0;
    d__=-evstr(PlaneD__);
    x=1; y=0; z=0;
    Tmp1__=evstr(PlaneD__)+d__;
    x=0; y=1; z=0;
    Tmp2__=evstr(PlaneD__)+d__;
    x=0; y=0; z=1;
    Tmp3__=evstr(PlaneD__)+d__;
    V1__=[Tmp1__,Tmp2__,Tmp3__];
  end;
  for I__=1:Mixlength(FaceL__)
    Face__=Mixop(I__,FaceL__);
    TmpL__=[];
    for J__=1:length(Face__)
      N1__=Face__(J__);
      if J__==length(Face__)
        N2__=Face__(1);
      else
        N2__=Face__(J__+1);
      end;
      for K__=1:Mixlength(PtL__)
        Pd__=Mixop(K__,PtL__);
        Tmp__=Mixop(1,Pd__);
        if Tmp__(1)==Tmp__(2)
          if Tmp__(1)==N1__
            TmpL__=Mixadd(TmpL__,Mix(J__,[N1__,N2__],Mixop(2,Pd__)));
          end
        else
          if Tmp__==[N1__,N2__] | Tmp__==[N2__,N1__]
            TmpL__=Mixadd(TmpL__,Mix(J__,[N1__,N2__],Mixop(2,Pd__)));
          end;
        end;
      end;
    end;
    if Mixlength(TmpL__)<2
      Flg__=0;
      for J__=1:length(Face__)
        Tmp__=Mixop(Face__(J__),VL__);
        Tmp1__=Fugou__*(Naiseki(V1__,Tmp__)-d__);
        if Tmp1__<-Eps__
          Flg__=1;
          break;
        end;
      end;
      if Flg__==0
        OutfL__=Mixadd(OutfL__,Face__);
      end;
      continue;
    end;
    Pd__=Mixop(1,TmpL__);
    Qd__=Mixop(2,TmpL__);
    Outf1__=[Mixop(3,Pd__)];
    Nf__=Mixop(1,Pd__)+1;
    Tmp__=Mixop(2,Pd__);
    JJ__=0;
    while Tmp__~=Mixop(2,Qd__)
      JJ__=JJ__+1;
      if JJ__>20
        disp('bug');
        return;
      end;
      Tmp1__=Tmp__(2);
      if Outf1__(length(Outf1__))~=Tmp1__
        Outf1__=[Outf1__,Tmp1__];
      end;
      Tmp__=[Face__(Nf__)];
      Nf__=Nf__+1;
      if Nf__>length(Face__) Nf__=1; end;
      Tmp__=[Tmp__,Face__(Nf__)];
    end;
    Tmp1__=Mixop(3,Qd__);
    if Outf1__(length(Outf1__))~=Tmp1__
      Outf1__=[Outf1__,Tmp1__];
    end;
    Outf2__=[Mixop(3,Pd__)];
    Nf__=Mixop(1,Pd__);
    Tmp__=Mixop(2,Pd__);
    JJ__=0;
    while Tmp__~=Mixop(2,Qd__)
      JJ__=JJ__+1;
      if JJ__>20
        disp('bug');
        return;
      end;
      Tmp1__=Tmp__(1);
      if Outf2__(length(Outf2__))~=Tmp1__
        Outf2__=[Outf2__,Tmp1__]
      end;
      Tmp__=[Face__(Nf__)];
      Nf__=Nf__-1;
      if Nf__<1 Nf__=length(Face__); end;
      Tmp__=[Face__(Nf__),Tmp__];
    end;
    Tmp1__=Mixop(3,Qd__);
    if Outf2__(length(Outf2__))~=Tmp1__
      Outf2__=[Outf2__,Tmp1__]
    end;
    if length(Outf1__)<3 | length(Outf2__)<3
      Face__=Outf1__;
      if length(Outf1__)<length(Outf2__) Face__=Outf2__; end;
      Flg__=0;
      for J__=1:length(Face__)
        Tmp__=Mixop(Face__(J__),VL__);
        Tmp1__=Fugou__*(Naiseki(V1__,Tmp__)-d__);
        if Tmp1__<-Eps__
          Flg__=1;
          break;
        end;
      end;
      if Flg__==0
        OutfL__=Mixadd(OutfL__,Face__);
      end;
    else
      Tmp__=Mixop(Outf1__(2),VL__);
      Tmp1__=Outf1__;
      Tmp2__=Fugou__*(Naiseki(V1__,Tmp__)-d__);      
      if Tmp2__<0 Tmp1__=Outf2__; end;
      OutfL__=Mixadd(OutfL__,Tmp1__);
    end;
  end;
  PHVERTEXL=VL__;
  PHFACEL=OutfL__;
  Out2__=Phcutdata(VL__,OutfL__,[0,0,0,0]);
endfunction

