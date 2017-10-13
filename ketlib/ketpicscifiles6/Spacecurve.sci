// 08.07.11
// 09.05.27
// 09.06.02
// 09.12.31  (gsort)
// 13.10.21 ( __ added to varibles )
// 16.08.20  (N changed to devided number )
// 16.12.13  ( in case of T1=T2)

function P__=Spacecurve(varargin)
  Eps__=10^(-5);
  Nargs__=length(varargin);
  Fnstr__=varargin(1);
  Rgstr__=varargin(2);
  Range__=[0,2*%pi];
  N=50; // Numpoints
  E=[]; // Exclusions
  D=%inf;  // Discont  (Changed)
  for I__=3:Nargs__
    Tmp__=varargin(I__);
    K__=mtlb_findstr(Tmp__,'=');
    Tmp1__=strsplit(Tmp__,[K__-1,K__]);
    Tmp2__=ascii(Tmp1__(1,1));
    Lhs__=char(Tmp2__(1));
    Str__=Lhs__+'='+Tmp1__(3,1);
    execstr(Str__);
  end;
  K__=mtlb_findstr(Rgstr__,'=');
  if K__~=[]
    Tmp__=strsplit(Rgstr__,[K__-1,K__]);
    Vname__=Tmp__(1,1);
    Rng__=evstr(Tmp__(3,1));
  else
    Vname__=Rgstr__;
    Rng__=[XMIN,XMAX];
  end
  T1__=Rng__(1); T2__=Rng__(2);
  Dt__=(T2__-T1__)/N; // 16.08.20
  Str__=mtlb_strrep(Fnstr__,Vname__,'t__');
  if abs(Dt__)<Eps__ then // 16.12.13
    t__=T1__;
    P__=evstr(Str__);
    return;
  end;
  P__=[];
  E=gsort(E);
  E=E(length(E):-1:1);
  E=[E,%inf];
  Tmp__=gsort(E);
  E=Tmp__(length(Tmp__):-1:1);
  Ke__=1;
  for t__=T1__:Dt__:T2__
    Pa__=[];
    if t__-E(Ke__)<-Eps__
      Pa__=evstr(Str__);
    end
    if abs(t__-E(Ke__))<=Eps__
      if P__~=[] & P__(size(P__,1),:)~=[%inf,%inf,%inf]
        Pa__=[%inf,%inf,%inf];
      end
    end
    if t__-E(Ke__)>Eps__
      Pa__=evstr(Str__);
      Ke__=Ke__+1;
    end
    if Pa__~=[]
      if Pa__(1)==%inf
        P__=[P__;Pa__]
      elseif P__==[]
        P__=[Pa__];
      else
        Tmp__=P__(size(P__,1),:);
        if Tmp__(1)==%inf
          P__=[P__;Pa__];
        elseif norm(Tmp__-Pa__)<D
          P__=[P__;Pa__];
        else
          P__=[P__;%inf,%inf,%inf;Pa__];
        end
      end
    end
  end
endfunction

