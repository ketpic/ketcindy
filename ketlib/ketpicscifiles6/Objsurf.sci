// s : 2014.06.22
// e : 2014.07.18
//   Objsurf, Objthicksurf : Range argments changed
// 2014.09.07 Objjoin added

function Out=Objsurf(varargin)
  global OBJFIGNO OBJJOIN
  Args=varargin;
  Nargs=length(Args);
   Sel=Args(Nargs); Nargs=Nargs-1;
  Rf=Args(1);
  N=2;
  Mg=0; Ng=0;
  if type(Args(N))==1 then
    if length(Args(N))>2 then
      U=Args(N);
      Mg=length(U)-1;
      N=N+1;
    elseif length(Args(N))==2 then
      Intab=Args(N);
      Ag=Intab(1); Bg=Intab(2);
      N=N+1;
    else
      Ag=Args(N); Bg=Args(N+1);
      N=N+2;
    end;
  else // when type(Args(N))==10
    Tmp0=Args(N);
    Tmp=mtlb_findstr("=",Tmp0);
    if length(Tmp)>0 then
      Tmp0=part(Tmp0,(Tmp+1):length(Tmp0));
    end;
    Intab=evstr(Tmp0);
    Ag=Intab(1); Bg=Intab(2);
    N=N+1;
  end;
  if type(Args(N))==1 then
    if length(Args(N))>2 then
      V=Args(N);
      Ng=length(V)-1;
      N=N+1;
    elseif length(Args(N))==2 then
      Intab=Args(N);
      Cg=Intab(1); Dg=Intab(2);
      N=N+1;
    else
      Cg=Args(N); Dg=Args(N+1);
      N=N+2;
    end;
  else // when type(Args(N))==10
    Tmp0=Args(N);
    Tmp=mtlb_findstr("=",Tmp0);
    if length(Tmp)>0 then
      Tmp0=part(Tmp0,(Tmp+1):length(Tmp0));
    end;
    Intab=evstr(Tmp0);
    Cg=Intab(1); Dg=Intab(2);
    N=N+1;
  end;  
  if Mg==0 then
    Mg=Args(N);
    N=N+1;
	U=[];
    for J=1:(Mg+1)
      U=[U,Ag+(J-1)/Mg*(Bg-Ag)];
    end;
  end;
  if Ng==0 then
    Ng=Args(N);
    V=[];
    for K=1:(Ng+1)
      V=[V,Cg+(K-1)/Ng*(Dg-Cg)];
    end;
  end;
  Objname();  // // 140907
  PL=list();
  for J=1:(Mg+1)
    for K=1:(Ng+1)
      P=Rf(U(J),V(K));
      Np=Writeobjpoint(P)
      PL=lstcat(PL,list([P,Np]));
    end;
  end;
  Idx=1:(Ng+1):(Ng+1)*Mg+1;
  Pus=Mixsub(Idx,PL);
  Idx=(Ng+1):(Ng+1):(Ng+1)*(Mg+1);
  Pue=Mixsub(Idx,PL);
  Idx=1:1:Ng+1;
  Pvs=Mixsub(Idx,PL);
  Idx=(Ng+1)*Mg+1:1:(Ng+1)*(Mg+1);
  Pve=Mixsub(Idx,PL);
  Printobjstr("vt 0 0");
  Printobjstr("vt 1 0");
  Printobjstr("vt 1 1");
  Printobjstr("vt 0 1");
  for J=1:Mg
    for K=1:Ng
      P1=sprintf("%1d",Op(4,PL((Ng+1)*(J-1)+K)))
      P2=sprintf("%1d",Op(4,PL((Ng+1)*J+K)))
      P3=sprintf("%1d",Op(4,PL((Ng+1)*J+K+1)))
      P4=sprintf("%1d",Op(4,PL((Ng+1)*(J-1)+K+1)))
      N1=""; N2=""; N3=""; N4="";
      if Sel=="+" then // 6.22
        Str="f "+P1+"/1/"+N1+" "+P2+"/2/"+N2+" ";
        Str=Str+P3+"/3/"+N3+" "+P4+"/4/"+N4;
      else
        Str="f "+P1+"/1/"+N1+" "+P4+"/4/"+N4+" ";
        Str=Str+P3+"/3/"+N3+" "+P2+"/2/",N2;
      end;
      Printobjstr(Str)
    end;
  end;
  Out=list(U,V,Pus,Pue,Pvs,Pve)
endfunction
