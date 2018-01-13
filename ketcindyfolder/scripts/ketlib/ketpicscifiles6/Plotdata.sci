//
// 08.06.18 (N)
// 08.08.24
// 08.10.05
// 08.12.18
// 09.03.12
// 09.12.31 (gsort)
// 13.10.19 (__ added to variables)
// 14.10.24  N,D,E => N__ ,...
// 14.12.11  Assign used, and debugged (Exfun )
// 15.11.16  N changed to number of intervals
// 16.12.13  in case of X1=X2

function P__=Plotdata(varargin)
  global XMIN XMAX YMIN YMAX
  Eps__=10^(-5);
  Fnstr__=varargin(1); Is__=2;
  if type(Fnstr__)==13
    Fnflg__=1;
    Fnarg__=varargin(Is__);
    if type(Fnarg__)==13
      Fnflg__=Fnflg__+1;
      Is__=Is__+1;
    end;
  else
    Fnflg__=0;
  end;
  Rgstr__=varargin(Is__); Is__=Is__+1;
  K__=mtlb_findstr(Rgstr__,'=');
  if length(K__)>0
    Tmp__=strsplit(Rgstr__,[K__-1,K__]);
    Vname__=Tmp__(1,1);
    Rng__=evstr(Tmp__(3,1));
  else
    Vname__=Rgstr__;
    Rng__=[XMIN,XMAX];
  end;
  N__=50;   // Numpoints
  E__=[];   // Exclusions
  Exfun__=''; // Exclusion function
  D__=%inf; // Discont
  for I__=Is__:length(varargin)
    Tmp__=varargin(I__);
    Lhs__=part(Tmp__,1);
    K__=mtlb_findstr(Tmp__,'=');
    Tmp1__=part(Tmp__,K__+1:length(Tmp__));
    if mtlb_findstr(Tmp__,Vname__)==[]
      Str__=Lhs__+'__='+Tmp1__;
      execstr(Str__);
    else
      Exfun__=Tmp1__;
    end;
  end;
  X1__=Rng__(1); X2__=Rng__(2);
//  dx__=(X2__-X1__)/(N__-1);
  dx__=(X2__-X1__)/(N__); // 15.11.16
  if Fnflg__==0
    Str__=Assign(Fnstr__,Vname__,'x__');
  end;
  if abs(dx__)<Eps__ then // 16.12.13
    x__=X1__;
    P__=[X1__,evstr(Str__)];
    return;
  end;
  Exfun__=Assign(Exfun__,Vname__,'x__');
  if length(Exfun__)>0 then  // 14.12.11
    Tmp__=mtlb_findstr(Exfun__,"x__");
    if length(Tmp__)==0 then
      E__=evstr(Exfun__);
      Exfun__="";
    end
  end
  P__=[];
  E__=gsort(E__);
  E__=E__(length(E__):-1:1);
  E__=[E__,%inf];
  Tmp__=gsort(E__);
  E__=Tmp__(length(Tmp__):-1:1);
  Ke__=1;
  for x__=X1__:dx__:X2__
    if Exfun__~=''
      Tmp__=evstr(Exfun__);
      if abs(Tmp__)<Eps__
        P__=[P__;%inf,%inf];
        continue;
      end;
    end;
    Pa__=[];
    if x__-E__(Ke__)<-Eps__
      if Fnflg__==0
        Pa__=[x__,evstr(Str__)];
      else
        if Fnflg__==1
          Pa__=[x__,Fnstr__(x__)];
        else
          Pa__=[x__,Fnstr__(Fnarg__,x__)];
        end;
      end;
    end;
    if abs(x__-E__(Ke__))<=Eps__
      if P__~=[] & P__(size(P__,1),:)~=[%inf,%inf]
        Pa__=[%inf,%inf];
      end
    end
    if x__-E__(Ke__)>Eps__
      if Fnflg__==0
        Pa__=[x__,evstr(Str__)];
      else
        if Fnflg__==1
          Pa__=[x__,Fnstr(x__)];
        else
          Pa__=[x__,Fnstr__(Fnarg__,x__)];
        end;
      end;
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
        elseif norm(Tmp__-Pa__)<D__
          P__=[P__;Pa__];
        else
          P__=[P__;%inf,%inf;Pa__];
        end
      end
    end
  end;
  Tmp__=size(P__,1);
  if P__(Tmp__,1)==%inf
    P__=P__(1:Tmp__-1,:);
  end;
endfunction;
