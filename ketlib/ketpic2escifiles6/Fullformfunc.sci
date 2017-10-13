// 08.08.16
// 08.09.16
// 09.11.14
// 10.08.19
// 13.10.22 ( __ added to varibles )

function Out__=Fullformfunc(FdL__)
  Out__=MixS(Mixop(1,FdL__));
  N__=Mixlength(FdL__);
  for Jrg__=1:N__
    Tmp__=Mixop(Jrg__,FdL__);
    if part(Tmp__,length(Tmp__))==']'
      break
    end;
  end;
  Urg__=Mixop(Jrg__,FdL__);
  K__=mtlb_findstr(Urg__,'=');
  Uname__=stripblanks(part(Urg__,1:K__-1));
  Tmp__=part(Urg__,K__+1:length(Urg__));  // 2013.10.22
  Tmp1__=evstr(Tmp__);
  Urg__=Uname__+"=["+string(Tmp1__(1))+","+string(Tmp1__(2))+"]";
  Vrg__=Mixop(Jrg__+1,FdL__);
  K__=mtlb_findstr(Vrg__,'=');
  Vname__=stripblanks(part(Vrg__,1:K__-1));
  Tmp__=part(Vrg__,K__+1:length(Vrg__));
  Tmp1__=evstr(Tmp__);
  Vrg__=Vname__+"=["+string(Tmp1__(1))+","+string(Tmp1__(2))+"]"; //
  if Jrg__==2
    Tmp__=Mixop(1,FdL__);
    K__=mtlb_findstr(Tmp__,'=');
    Zf__=part(Tmp__,K__+1:length(Tmp__));
    Tmp__=MixS(Uname__,Vname__,Zf__,Urg__,Vrg__);
    Out__=Mixjoin(Out__,Tmp__);
  elseif Jrg__==4
    Tmp__=Mixop(1,FdL__);
    K__=mtlb_findstr(Tmp__,'=');
    Zf__=part(Tmp__,K__+1:length(Tmp__));
    Tmp__=Mixop(2,FdL__);
    K__=mtlb_findstr(Tmp__,'=');
    Xname__=stripblanks(part(Tmp__,1:K__-1));
    Xf__=part(Tmp__,K__+1:length(Tmp__));
    Tmp__=Mixop(3,FdL__);
    K__=mtlb_findstr(Tmp__,'=');
    Yname__=stripblanks(part(Tmp__,1:K__-1));
    Yf__=part(Tmp__,K__+1:length(Tmp__));
    Tmp__=strsubst(Zf__,Xname__,'('+Xf__+')');
    Zf__=strsubst(Tmp__,Yname__,'('+Yf__+')');
    Tmp__=MixS(Xf__,Yf__,Zf__,Urg__,Vrg__);
    Out__=Mixjoin(Out__,Tmp__);
  else
    Tmp__=Mixop(2,FdL__);
    K__=mtlb_findstr(Tmp__,'=');
    Xf__=part(Tmp__,K__+1:length(Tmp__));
    Tmp__=Mixop(3,FdL__);
    K__=mtlb_findstr(Tmp__,'=');
    Yf__=part(Tmp__,K__+1:length(Tmp__));
    Tmp__=Mixop(4,FdL__);
    K__=mtlb_findstr(Tmp__,'=');
    Zf__=part(Tmp__,K__+1:length(Tmp__));
    Tmp__=MixS(Xf__,Yf__,Zf__,Urg__,Vrg__);
    Out__=Mixjoin(Out__,Tmp__);
  end;
  DrwS__='enws';
  BdyL__=[];
  for I__=Jrg__+2:Mixlength(FdL__) 
    Tmp__=Mixop(I__,FdL__);
    if type(Tmp__)==10
      if length(Tmp__)==0  //
        Tmp__=' ';
      end;
      DrwS__=Tmp__;
    end;
    if type(Tmp__)==1 & size(Tmp__,2)>1
      BdyL__=Tmp__;
    end;
  end;
  Tmp__=MixS(DrwS__,BdyL__);
  Out__=Mixjoin(Out__,Tmp__);
endfunction
