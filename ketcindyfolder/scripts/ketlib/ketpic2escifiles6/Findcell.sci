// 09.11.26
// 09.12.06
// 09.12.14
// 10.01.12
// 10.01.13
// 10.01.14

function Out=Findcell(varargin)//TbL,Nrg,Mrg
  Nargs=length(varargin);
  TbL=varargin(1);
  Ag=varargin(2);
  Alpha='-ABCDEFGHIJKLMNOPQRSTUVWXYZ';
  if type(Ag)==10
    Clm=[];
    Rstr='';
    for I=1:length(Ag)
      C=part(Ag,I:I); 
      Tmp=ascii(C);
      if Tmp>=96
        C=char(Tmp-32);
      end;
      Tmp=mtlb_findstr(C,Alpha)
      if length(Tmp)>0
        Clm=[Clm,Tmp-1];
      else
        Rstr=Rstr+C;
      end;
    end;
    Nrg=0;
    for I=length(Clm):-1:1
      Tmp=Clm(I);
      Tmp1=length(Clm)-I;
      Nrg=Nrg+Tmp*26^Tmp1;
    end;
    Mrg=eval(Rstr);
    if Nargs>=3
      Ag=varargin(3);
      Clm=[];
      Rstr='';
      for I=1:length(Ag)
        C=part(Ag,I:I); 
        Tmp=ascii(C);
        if Tmp>=96
          C=char(Tmp-32);
        end;
        Tmp=mtlb_findstr(C,Alpha)
        if length(Tmp)>0
          Clm=[Clm,Tmp];
        else
          Rstr=Rstr+C;
        end;
      end;
      Nrg2=0;
      for I=length(Clm):-1:1
        Tmp=Clm(I);
        Tmp1=length(Clm)-I;
        Nrg2=Nrg2+Tmp*26^Tmp1;
      end;
      Nrg=[Nrg,Nrg2];
      Mrg=[Mrg,eval(Rstr)];
    end;
  else
    Nrg=varargin(2);
    Mrg=varargin(3);
  end;
  if length(Mrg)==1
    m1=Mrg; m2=m1+1;
  else
    m1=Mrg(1); m2=Mrg(2);
  end;
  if length(Nrg)==1
    n1=Nrg; n2=n1+1;
  else
    n1=Nrg(1); n2=Nrg(2);
  end;
  n1=n1+1; n2=n2+1;
  m1=m1+1; m2=m2+1;
  Hind=TbL(2);
  Vind=TbL(3);
  HL=Mixsub(TbL(2),TbL(1));
  Tmp1=Op(1,TbL(4));
  Tmp2=Op(2,TbL(4));
  HL=Mixjoin(list(Tmp1),HL,list(Tmp2));
  VL=Mixsub(TbL(3),TbL(1));
  Tmp1=Op(1,TbL(5));
  Tmp2=Op(2,TbL(5));
  VL=Mixjoin(list(Tmp1),VL,list(Tmp2));
  Tmp=TbL(6);
  Tmp1=Listplot([Ptsw(Tmp),Ptnw(Tmp)]);
  Tmp2=Listplot([Ptse(Tmp),Ptne(Tmp)]);
  HL=Mixjoin(list(Tmp1),HL,list(Tmp2));
  Tmp1=Listplot([Ptnw(Tmp),Ptne(Tmp)]);
  Tmp2=Listplot([Ptsw(Tmp),Ptse(Tmp)]);  
  VL=Mixjoin(list(Tmp1),VL,list(Tmp2));
  Tmp=HL(n1);
  if type(Tmp)==1
    H1=Tmp(1,1);
  else
    Tmp1=Tmp(1);
    H1=Tmp1(1,1);
  end;
  Tmp=HL(n2);
  if type(Tmp)==1
    H2=Tmp(1,1);
  else
    Tmp1=Tmp(1);
    H2=Tmp1(1,1);
  end;
  Tmp=VL(m1);
  if type(Tmp)==1
    V1=Tmp(1,2);
  else
    Tmp1=Tmp(1);
    V1=Tmp1(1,2);
  end;
  Tmp=VL(m2);
  if type(Tmp)==1
    V2=Tmp(1,2);
  else
    Tmp1=Tmp(1);
    V2=Tmp1(1,2);
  end;
  Pt=[(H1+H2)/2,(V1+V2)/2];
  High=(V1-V2)/2;
  Wide=(H2-H1)/2;
  Out=list(Pt,Wide,High);
endfunction;
