// s : 2014.06.22
// e : 2014.07.18
//   Objsurf, Objthicksurf : Range argments changed
// 14.09.07 Objjoin added

function Out=Objthicksurf(varargin)
  global OBJJOIN
  Args=varargin;
  Nargs=length(Args)
  Sel=Args(Nargs); Nargs=Nargs-1;
  Selsurf=part(Sel,1);  // from 6.22
  Selside=["0","0","0","0"]; // wesn
  Tmp=mtlb_findstr(Sel,"w");
  if length(Tmp)>0 then
    Selside(1)=part(Sel,Tmp+1)
  end;
  Tmp=mtlb_findstr(Sel,"e");
  if length(Tmp)>0 then
    Selside(2)=part(Sel,Tmp+1)
  end;
  Tmp=mtlb_findstr(Sel,"s");
  if length(Tmp)>0 then
    Selside(3)=part(Sel,Tmp+1)
  end;
  Tmp=mtlb_findstr(Sel,"n");
  if length(Tmp)>0 then
    Selside(4)=part(Sel,Tmp+1)
  end;
  Nfth=Args(Nargs-2);
  Thick1=Args(Nargs-1);
  Thick2=Args(Nargs);
  Nargs=Nargs-3;   // upto 6.22
  Rfth=Args(1); // 6.22
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
  Objname();  // 140907 from
  Join=OBJJOIN;
  OBJJOIN=1; // upto
  deff("Out=F1(u,v)","Out=Rfth(u,v)+Thick1*Nfth(u,v)");
  deff("Out=F2(u,v)","Out=Rfth(u,v)+Thick2*Nfth(u,v)");
  Dt1=Objsurf(F1,U,V,Selsurf);
  if Selsurf=="+" then Tmp="-"; else Tmp="+"; end;
  Dt2=Objsurf(F2,U,V,Tmp);
  Out=list(Dt1,Dt2);  //from 06.22
  if Selside(1)~="0" then
    Dt=Objrecs(Dt1(3),Dt2(3),Selside(1));
    Out=lstcat(Out,list(Dt));
  end
  if Selside(2)~="0" then
    Dt=Objrecs(Dt1(4),Dt2(4),Selside(2));
    Out=lstcat(Out,list(Dt));
  end
  if Selside(3)~="0" then
    Dt=Objrecs(Dt1(5),Dt2(5),Selside(3));
    Out=lstcat(Out,list(Dt));
  end
  if Selside(4)~="0" then
    Dt=Objrecs(Dt1(6),Dt2(6),Selside(4));
    Out=lstcat(Out,list(Dt));
  end;  // upto 6.22
  OBJJOIN=Join  // 140907
endfunction
