// 10.01.21

function Texsetctr(Nctr,Opstr)
  Ctr=Texctr(Nctr);
  Opstr=Opstr+'%';
  OperL='+-*/%';
  Oper='';
  Va='';
  Evflg=0;
  Paflg=0;
  for I=1:length(Opstr)
    Tmp=part(Opstr,I);
    if Tmp=='('
      Paflg=1;
      if length(Va)>0
        Evflg=1;
        Va=Va+Tmp;
      end;
      continue;
    end;
    if Tmp==')'
      Paflg=0;
      if Evflg>0
        Va=Va+Tmp;
      end;
      continue;
    end;
    if Paflg>0
      Va=Va+Tmp;
      continue;
    end;
    if length(mtlb_findstr(Tmp,OperL))==0
      Va=Va+Tmp;
    else
      if Evflg>0
        Tmp1=evstr(Va);
        Va='\value{'+Tmp1+'}';
        Evflg=0;
      end;
      if Oper==''
        if length(Va)>0
          Str='\setcounter{'+Ctr+'}{'+Va+'}';
          Texcom(Str);
        end;
        Oper=Tmp;
        Va='';      
      elseif Oper=='+'
        Str='\addtocounter{'+Ctr+'}{'+Va+'}';
        Texcom(Str);
        Oper=Tmp;
        Va='';
      elseif Oper=='-'
        Str='\addtocounter{'+Ctr+'}{-'+Va+'}';
        Texcom(Str);
        Oper=Tmp;
        Va='';
      elseif Oper=='*'
        Str='\multiply\value{'+Ctr+'} by '+Va;
        Texcom(Str);
        Oper=Tmp;
        Va='';      
      elseif Oper=='/'
        Str='\divide\value{'+Ctr+'} by '+Va;
        Texcom(Str);
        Oper=Tmp;
        Va='' 
      end;
    end;
  end;
endfunction;
