// 08.09.10
// 08.09.13
// 08.09.15
// 08.10.10
// 10.02.16  Eps 
// 13.10.21 ( __ added to varibles )
// 14.06.28  debug in the case of no cusp

function OutkL__=Cuspsplitpara(varargin);
  global CUSPSPLITPT;
  Nargs__=length(varargin);
  Gdxy__=varargin(1);
  if Mixtype(Gdxy__)==1
    Gdxy__=Mix(Gdxy__);
  end;
  Fd__=varargin(2);
  FdL__=Fullformfunc(Fd__);
  Eps0__=10^(-5);
  Eps__=0.05;
  if Nargs__>2 Eps__=varargin(3); end;
  if length(Eps__)>1 //
    Eps__=Eps__(1);
  end;	  //
  Fxy__=Mixop(1,FdL__); N__=2;
  Tmp1__=Mixop(2,FdL__);
  Tmp2__=Mixop(3,FdL__);
  Tmp3__=Mixop(4,FdL__);
  Xyzstr__=[Tmp1__,Tmp2__,Tmp3__];
  Tmp__=Mixop(5,FdL__);
  K__=mtlb_findstr(Tmp__,'=');
  Uname__=part(Tmp__,1:K__-1);
  Urg__=evstr(part(Tmp__,K__+1:length(Tmp__)));
  Tmp__=Mixop(6,FdL__);
  K__=mtlb_findstr(Tmp__,'=');
  Vname__=part(Tmp__,1:K__-1);
  Vrg__=evstr(part(Tmp__,K__+1:length(Tmp__)));
  CUSPSPLITPT=[];
  OutkL__=[];
  for Ng__=1:Mixlength(Gdxy__)
    PtxyL__=Mixop(Ng__,Gdxy__);
    PtkL__=[];
    PthL__=[];
    for I__=1:size(PtxyL__,1)
      Tmp__=PtxyL__(I__,:);
      Tmp1__=Uname__+'='+string(Tmp__(1));
      execstr(Tmp1__);
      Tmp1__=Vname__+'='+string(Tmp__(2))
      execstr(Tmp1__);
      Tmp2__=evstr(Xyzstr__);
      Tmp3__=Parapt(Tmp2__);
      if I__==1
        PtkL__=[Tmp2__];
        PthL__=[Tmp3__];
      else
        Tmp4__=PthL__(size(PthL__,1),:);
        if norm(Tmp3__-Tmp4__)>Eps0__
          PtkL__=[PtkL__;Tmp2__];
          PthL__=[PthL__;Tmp3__]
        end;
      end;
    end;
    if size(PthL__,1)==0 then // from 20140628
      OutkL__=[];
      return;
    end;           // upto 20140628
    Ps__=PthL__(1,:); Pe__=PthL__(size(PthL__,1),:);
    Cflg__=0;
    if norm(Ps__-Pe__)<Eps__ Cflg__=1; end;
    CuspL__=[];
    Cva__=cos(10*%pi/180);
    for I__=1:size(PthL__,1)-1
      if size(PthL__,1)==2 break; end;
      Tmp__=PthL__(I__,:);
      if I__==1
        if Cflg__==0 continue; end;
        Tmp1__=PthL__(size(PthL__,1)-1,:);
      else
        Tmp1__=PthL__(I__-1,:);
      end;
      Tmp2__=PthL__(I__+1,:);
      V1__=Tmp__-Tmp1__;
      V2__=Tmp2__-Tmp__;
      Tmp3__=V1__(1)*V2__(1)+V1__(2)*V2__(2);
      Tmp3__=Tmp3__/(norm(V1__)*norm(V2__));
      Cuspflg__=0;
      if Tmp3__<Cva__
        P__=PthL__(I__,:);
        Kaku__=acos(Tmp3__)*180/%pi;
        if V1__(1)*V2__(2)-V1__(2)*V2__(1)<0
          Kaku__=-Kaku__ 
        end;
        Cuspflg__=0;
        for J__=I__+1:size(PthL__,1)-1
          if abs(Kaku__)>90
            Cuspflg__=1;
            break
          end;
          Q__=PthL__(J__,:);
          if norm(P__-Q__)>Eps__
            break
          end;
          V1__=Q__-PthL__(J__-1,:);
          V2__=PthL__(J__+1,:)-Q__;
          Tmp3__=V1__(1)*V2__(1)+V1__(2)*V2__(2);
          Tmp3__=Tmp3__/(norm(V1__)*norm(V2__));
          Tmp__=acos(Tmp3__)*180/%pi;
          if V1__(1)*V2__(2)-V1__(2)*V2__(1)<0
            Tmp__=-Tmp__ 
          end;
          Kaku__=Kaku__+Tmp__
        end;
        if Cuspflg__==1
          Tmp__=Trunc((I__+J__)*0.5);
          I__=J__;
          if length(CuspL__)==0
            CuspL__=[Tmp__]
          else
           CuspL__=[CuspL__,Tmp__];
          end;
        end;
      end;
    end;
    if Cflg__==0
      CuspL__=[1,CuspL__,size(PthL__,1)];
    elseif length(CuspL__)==0
      CuspL__=[1,size(PthL__,1)];
    elseif CuspL__(1)==1
      CuspL__=[CuspL__,size(PthL__,1)];
    else
      Tmp__=CuspL__(1);
      Tmp1__=size(PthL__,1);
      PthL__=[PthL__(Tmp__:Tmp1__,:);PthL__(2:Tmp__,:)];
      PtkL__=[PtkL__(Tmp__:Tmp1__,:);PtkL__(2:Tmp__,:)];
      CuspL__=CuspL__-Tmp__+1;
      CuspL__=[CuspL__,size(PthL__,1)];
    end;
    if length(CuspL__)==2
      //Outh=[plot(PthL__)];
      Tmp4__=PthL__(size(PthL__,1),:);
      if size(PtkL__,1)>=2
        CUSPSPLITPT=Mixadd(CUSPSPLITPT,Tmp4__);
        OutkL__=Mixadd(OutkL__,PtkL__);
      end;
      continue
    end;
    //Outh=[];
    Outk__=[];
    Is__=1;
    for I__=1:length(CuspL__)-1
      Tmp1__=CuspL__(Is__); Tmp2__=CuspL__(I__+1);
      Tmp3__=PthL__(Tmp1__,:); Tmp4__=PthL__(Tmp2__,:);
      if norm(Tmp3__-Tmp4__)>Eps__
        //Tmph__=[op(Tmp1__..Tmp2__,PthL__)];
        Tmpk__=PtkL__(Tmp1__:Tmp2__,:);
        //Outh=[op(Outh),plot(Tmph__)];
        Outk__=Mixadd(Outk__,Tmpk__);
        CUSPSPLITPT=Mixadd(CUSPSPLITPT,Tmp4__);
        Is__=I__+1;
      end;
    end;
    OutkL__=Mixjoin(OutkL__,Outk__);
  end;
  Tmp1__=Dropnumlistcrv(Projpara(OutkL__),Eps__*0.5);
  Tmp__=[];
  for I__=1:Mixlength(OutkL__)
    Tmp2__=Mixop(I__,OutkL__);
    Tmp3__=Mixop(I__,Tmp1__);
    Tmp4__=[];
    for J__=1:length(Tmp3__)
      Tmp5__=Tmp2__(Tmp3__(J__),:);
      Tmp4__=[Tmp4__;Tmp5__];
    end;
    if Tmp4__~=[]
      Tmp__=Mixadd(Tmp__,Tmp4__);
    end;
  end;
  OutkL__=Tmp__;
endfunction;

