// 08.06.18  (N)
// 08.12.18
// 09.03.12
// 09.12.31 (gsort)
// 13.10.19 ( __ added to variables )
// 14.10.24   N,D,E => N__, etc
// 14.12.11   Assign used
// 15.11.16 N changed to number of intervals
// 16.12.13  in case of T1=T2

function P__=Paramplot(varargin)
  Eps__=10^(-5);
  Nargs__=length(varargin);
  if type(varargin(1))==13
    Fnflg__=1;
    Fnx__=varargin(1);
    Fny__=varargin(2); Is__=3;
    if type(varargin(Is__))==13
      Fnflg__=Fnflg__+1;
      Fnargx__=varargin(Is__);
      Fnargy__=varargin(Is__+1);
      Is__=Is__+2;
    end;
  else
    Fnflg__=0;
    Fnstr__=varargin(1); Is__=2;
  end;
  Rgstr__=varargin(Is__); Is__=Is__+1;
  Range__=[0,2*%pi];
  N__=50; // Numpoints
  E__=[]; // Exclusions
  D__=%inf;  // Discont
  for I__=Is__:Nargs__
    Tmp__=varargin(I__);
    K__=mtlb_findstr(Tmp__,'=');
    Tmp1__=strsplit(Tmp__,[K__-1,K__]);
    Tmp2__=ascii(Tmp1__(1,1));
    Lhs__=char(Tmp2__(1));
    Str__=Lhs__+'__='+Tmp1__(3,1);
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
//  Dt__=(T2__-T1__)/(N__-1);
  Dt__=(T2__-T1__)/(N__); // 15.11.16
  if Fnflg__==0
    Str__=Assign(Fnstr__,Vname__,'t__');
  end;
  if abs(Dt__)<Eps__ then // 16.12.13
    t__=T1__;
    P__=evstr(Str__);
    return;
  end;
  P__=[];
  E__=gsort(E__);
  E__=E__(length(E__):-1:1);
  E__=[E__,%inf];
  Tmp__=gsort(E__);
  E__=Tmp__(length(Tmp__):-1:1);
  Ke__=1;
  for t__=T1__:Dt__:T2__
    Pa__=[];
    if t__-E__(Ke__)<-Eps__
      if Fnflg__==0
        Pa__=evstr(Str__);
      else
        if Fnflg__==1
          Pa__=[Fnx__(t__),Fny__(t__)];
        else
          if type(Fnargx__)==1
            Tmp1__=Fnx__(t__);
          else
            Tmp1__=Fnx__(Fnargx__,t__);
          end;
          if type(Fnargy__)==1
            Tmp2__=Fny__(t__);
          else
            Tmp2__=Fny__(Fnargy__,t__);
          end;
          Pa__=[Tmp1__,Tmp2__];
        end;
      end;
    end
    if abs(t__-E__(Ke__))<=Eps__
      if P__~=[] & P__(size(P__,1),:)~=[%inf,%inf]
        Pa__=[%inf,%inf];
      end
    end
    if t__-E__(Ke__)>Eps__
      if Fnflg__==0
        Pa__=evstr(Str__);
      else
        if Fnflg__==1
          Pa__=[Fnx__(t__),Fny__(t__)];
        else
          if type(Fnargx__)==1
            Tmp1__=Fnx__(t__);
          else
            Tmp1__=Fnx__(Fnargx__,t__);
          end;
          if type(Fnargy__)==1
            Tmp2__=Fny__(t__);
          else
            Tmp2__=Fny__(Fnargy__,t__);
          end;
          Pa__=[Tmp1__,Tmp2__];
        end;
      end;
      Ke__=Ke__+1;
    end
    if Pa__~=[]
      if Pa__(1)==%inf
        P__=[P__; Pa__]
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
