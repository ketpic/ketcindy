// s : 2014.06.22
// 2014.09.07 Objjoin added

function Out=Objrecs(varargin)
  global OBJFIGNO OBJJOIN
  Eps=10^(-6);
  Args=varargin;
  Nargs=length(Args);
  Tmp=Args(1);
  PtL=Flattenlist(Tmp);
  PL1=list();
  for J=1:length(PtL)
    Tmp=PtL(J);
    for K=1:size(Tmp,1)
      PL1=lstcat(PL1,list(Tmp(K,:)))
    end;
  end;
  Sel=Args(Nargs); Nargs=Nargs-1;
  Objname();  // // 140907
  for J=1:length(PL1)
    P=PL1(J)
    if (length(P)<4) | (P(4)==0) then
      Np=Writeobjpoint(P);
      PL1(J)=[P(1:3),Np];
    end;
  end;
  Tmp=Args(2);
  if (type(Tmp)==1) & (size(Tmp,1)==1) then
    Drv=Tmp;
    Len=norm(Drv);
    PL2=list();
    for J=1:length(PL1)
      Tmp=PL1(J);
      P=Tmp(1:3)+Drv;
      Np=Writeobjpoint(P);
      PL2=lstcat(PL2,list([P(1:3),Np]));
      if J<length(PL1) then
        Vec=PL1(J+1)-PL1(J);
        if norm(Vec)>Eps then
          Tmp1=Crossprod(Drv,Vec);
          Tmp2=Crossprod(Tmp1,Vec);
          Tmp3=Dotprod(Tmp2,Drv);
          if Tmp3<-Eps then
            Tmp2=-Tmp2
          end;
          Drv=Len/norm(Tmp2)*Tmp2
        end
      end
    end
  else
    PtL=Flattenlist(Tmp);
    PL2=list();
    for J=1:length(PtL)
      Tmp=PtL(J);
      for K=1:size(Tmp,1)
          PL2=lstcat(PL2,list(Tmp(K,:)))
      end;
    end;
    for J=1:length(PL2)
      P=PL2(J);
      if (length(P)<4) | (P(4)==0) then
         Np=Writeobjpoint(P);
         PL2(J)=[P(1:3),Np]
      end;
    end;
  end;
  Printobjstr("vt 0 0");
  Printobjstr("vt 1 0");
  Printobjstr("vt 1 1");
  Printobjstr("vt 0 1");
  for J=2:length(PL1)
    P1=sprintf("%1d",Op(4,PL1(J-1)));
    P2=sprintf("%1d",Op(4,PL2(J-1)));
    P3=sprintf("%1d",Op(4,PL2(J)));
    P4=sprintf("%1d",Op(4,PL1(J)));
    N1=""; N2=""; N3=""; N4="";
	if Sel=="+" then // 6.22
      Str="f "+P1+"/1/"+N1+" "+P2+"/2/"+N2+" ";
      Str=Str+P3+"/3/"+N3+" "+P4+"/4/"+N4;
    else
      Str="f "+P1+"/1/"+N1+" "+P4+"/4/"+N4+" ";
      Str=Str+P3+"/3/"+N3+" "+P2+"/2/"+N2;
    end;
    Printobjstr(Str)
  end;
  Out=list(PL1,PL2)
endfunction
