// 08.05.30
// 08.05.31
// 08.06.03
// 13.10.21 (__ added to variables )

function PL__=Sumfun(varargin)
  global XMIN XMAX YMIN YMAX
  Nargs__=length(varargin);
  Const__=0;
  Addstr__='A__=0';
  J__=1;
  Tmp__=varargin(1);
  if type(Tmp__)==1
    Const__=Tmp__;
    J__=J__+1;
  end
  if type(Tmp__)==10
    Tmp1__=Strop(length(Tmp__),Tmp__);
    if Tmp1__=='+'
      Addstr__='A__='+Strop(1:length(Tmp__)-1,Tmp__);
      J__=J__+1
    end
  end
  Fnstr__=varargin(J__);
  Krange__=varargin(J__+1);
  Xrange__=varargin(J__+2);
  N=50;
  for I__=J__+3:Nargs__
    Tmp__=varargin(I__);
    execstr(Tmp__);
  end
  Tmp__=mtlb_findstr(Krange__,'=');
  Kname__=Strop(1:Tmp__-1,Krange__);
  Tmp1__=Strop(Tmp__+1:length(Krange__),Krange__);
  Tmp1__='Krg__='+Tmp1__;
  execstr(Tmp1__);
  Tmp__=mtlb_findstr(Xrange__,'=');
  if Tmp__==[]
    Xname__=Xrange__;
    Xrg__=[XMIN,XMAX];
  else
    Xname__=Strop(1:Tmp__-1,Xrange__);
    Tmp1__=Strop(Tmp__+1:length(Xrange__),Xrange__);
    Tmp1__='Xrg__='+Tmp1__;
    execstr(Tmp1__);
  end
  Dx__=(Xrg__(2)-Xrg__(1))/N;
  PL__=[];
  I__=0;
  while I__<=N
    Tmp__=Xname__+'=Xrg__(1)+I__*Dx__';
    execstr(Tmp__);
    J__=Krg__(1);
    execstr(Addstr__);
    Y__=Const__+A__;
    while J__<=Krg__(length(Krg__))
      Tmp__=Kname__+'=J__';
      execstr(Tmp__);
      execstr('Y__=Y__+'+Fnstr__);
      J__=J__+1;
    end
    PL__=[PL__;Xrg__(1)+I__*Dx__,Y__];
    I__=I__+1;
  end
endfunction
