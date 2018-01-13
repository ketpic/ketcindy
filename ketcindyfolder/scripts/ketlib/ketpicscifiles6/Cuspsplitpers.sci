// 08.09.21
// 08.10.10
// 10.02.16  Eps__ 
// 13.11.01 ( __ added to varibles )
// 14.06.28  debug in the case of no cusp

function OutkL__=Cuspsplitpers(varargin);
  global CUSPSPLITPT;
  Nargs__=length(varargin);
  Gdxy__=varargin(1);
  if Mixtype(Gdxy__)==1
    Gdxy__=Mix(Gdxy__);
  end;
  Fd__=varargin(2);
  FdL__=Fullformfunc(Fd__);
  Eps__0=10^(-5);
  Eps__=0.05;
  if Nargs__>2 Eps__=varargin(3); end;
  if length(Eps__)>1 //
    Eps__=Eps__(1);
  end;  //
  Fxy__=Mixop(1,FdL__); N=2;
  Tmp__1=Mixop(2,FdL__);
  Tmp__2=Mixop(3,FdL__);
  Tmp__3=Mixop(4,FdL__);
  Xyzstr__=[Tmp__1,Tmp__2,Tmp__3];
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
      Tmp__1=Uname__+'='+string(Tmp__(1));
      execstr(Tmp__1);
      Tmp__1=Vname__+'='+string(Tmp__(2))
      execstr(Tmp__1);
      Tmp__2=evstr(Xyzstr__);
      Tmp__3=Perspt(Tmp__2);
      if I__==1
        PtkL__=[Tmp__2];
        PthL__=[Tmp__3];
      else
        Tmp__4=PthL__(size(PthL__,1),:);
        if norm(Tmp__3-Tmp__4)>Eps__0
          PtkL__=[PtkL__;Tmp__2];
          PthL__=[PthL__;Tmp__3]
        end;
      end;
    end;
    if size(PthL__,1)==0 then // from 20140628
      OutkL__=[];
      return;
    end;           // upto 20140628
    Ps__=PthL__(1,:); Pe=PthL__(size(PthL__,1),:);
    Cflg__=0;
    if norm(Ps__-Pe)<Eps__ Cflg__=1; end;
    CuspL__=[];
    Cva__=cos(10*%pi/180);
    for I__=1:size(PthL__,1)-1
      if size(PthL__,1)==2 break; end;
      Tmp__=PthL__(I__,:);
      if I__==1
        if Cflg__==0 continue; end;
        Tmp__1=PthL__(size(PthL__,1)-1,:);
      else
        Tmp__1=PthL__(I__-1,:);
      end;
      Tmp__2=PthL__(I__+1,:);
      V1__=Tmp__-Tmp__1;
      V2__=Tmp__2-Tmp__;
      Tmp__3=V1__(1)*V2__(1)+V1__(2)*V2__(2);
      Tmp__3=Tmp__3/(norm(V1__)*norm(V2__));
      Cuspflg__=0;
      if Tmp__3<Cva__
        P__=PthL__(I__,:);
        Kaku__=acos(Tmp__3)*180/%pi;
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
          Tmp__3=V1__(1)*V2__(1)+V1__(2)*V2__(2);
          Tmp__3=Tmp__3/(norm(V1__)*norm(V2__));
          Tmp__=acos(Tmp__3)*180/%pi;
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
      Tmp__1=size(PthL__,1);
      PthL__=[PthL__(Tmp__:Tmp__1,:);PthL__(2:Tmp__,:)];
      PtkL__=[PtkL__(Tmp__:Tmp__1,:);PtkL__(2:Tmp__,:)];
      CuspL__=CuspL__-Tmp__+1;
      CuspL__=[CuspL__,size(PthL__,1)];
    end;
    if length(CuspL__)==2
      //Outh__=[plot(PthL__)];
      Tmp__4=PthL__(size(PthL__,1),:);
      if size(PtkL__,1)>=2
        CUSPSPLITPT=Mixadd(CUSPSPLITPT,Tmp__4);
        OutkL__=Mixadd(OutkL__,PtkL__);
      end;
      continue
    end;
    //Outh__=[];
    Outk__=[];
    Is__=1;
    for I__=1:length(CuspL__)-1
      Tmp__1=CuspL__(Is__); Tmp__2=CuspL__(I__+1);
      Tmp__3=PthL__(Tmp__1,:); Tmp__4=PthL__(Tmp__2,:);
      if norm(Tmp__3-Tmp__4)>Eps__
        //Tmp__h=[op(Tmp__1..Tmp__2,PthL__)];
        Tmp__k=PtkL__(Tmp__1:Tmp__2,:);
        //Outh__=[op(Outh__),plot(Tmp__h)];
        Outk__=Mixadd(Outk__,Tmp__k);
        CUSPSPLITPT=Mixadd(CUSPSPLITPT,Tmp__4);
        Is__=I__+1;
      end;
    end;
    OutkL__=Mixjoin(OutkL__,Outk__);
  end;
  Tmp__1=Dropnumlistcrv(Projpers(OutkL__),Eps__*0.5);
  Tmp__=[];
  for I__=1:Mixlength(OutkL__)
    Tmp__2=Mixop(I__,OutkL__);
    Tmp__3=Mixop(I__,Tmp__1);
    Tmp__4=[];
    for J__=1:length(Tmp__3)
      Tmp__5=Tmp__2(Tmp__3(J__),:);
      Tmp__4=[Tmp__4;Tmp__5];
    end;
    if Tmp__4~=[]
      Tmp__=Mixadd(Tmp__,Tmp__4);
    end;
  end;
  OutkL__=Tmp__;
endfunction;
