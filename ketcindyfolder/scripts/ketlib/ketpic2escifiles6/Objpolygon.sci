// s : 2014.06.22
// 14.09.07 Objjoin added

function Out=Objpolygon(varargin)
  global OBJFIGNO OBJJOIN
  Eps=10^(-6);
  Args=varargin;
  Nargs=length(Args);
  Tmp=Args(1);
  PtL=Flattenlist(Tmp);
  PL=list();
  for J=1:length(PtL)
    Tmp=PtL(J);
    for K=1:size(Tmp,1)
       PL=lstcat(PL,list(Tmp(K,:)))
    end;
  end;
  Sel=Args(Nargs); Nargs=Nargs-1;
  Objname(); // 140907
  for J=1:length(PL)
    P=PL(J);
    if (length(P)<4) | (P(4)==0) then
       Np=Writeobjpoint(P);
       PL(J)=[P(1:3),Np]
    end;
  end;
  if Nargs==1 then
    Tmp=PL(1);
    Cen=Tmp(1:3);
	Nc=Tmp(4)
  else
    Tmp=Args(2);
    if length(Tmp)==1 then
      Tmp1=PL(Tmp);
      Cen=Tmp1(1:3);
      Nc=Tmp(4)
    else
      Cen=Tmp;
      Nc=Writeobjpoint(Cen)
    end;
  end;
  for J=1:length(PL)
    if J<length(PL) then
     Je=J+1
    else
      Je=1
    end;
    Pt1=Cen;
    PLj=PL(J); PLje=PL(Je);
    Pt2=PLj(1:3); Pt3=PLje(1:3);
    if norm(Crossprod(Pt2-Pt1,Pt3-Pt1))<Eps then
     continue
    end;
    P1=sprintf("%1d",Nc);
    P2=sprintf("%1d",PLj(4))
    P3=sprintf("%1d",PLje(4))
	if Sel=="+" then // 6.22
      Str="f "+P1+" "+P2+" "+P3+" "
    else
      Str="f "+P1+" "+P3+" "+P2+" "
    end;
    Printobjstr(Str)
  end;
  Out=PL
endfunction
