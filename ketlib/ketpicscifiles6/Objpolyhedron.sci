// s : 2014.06.22
// 14.09.07 Objjoin added

function Out=Objpolyhedron(Vertex,Face)
  global NPOINT OBJFIGNO;
  OBJFIGNO=OBJFIGNO+1;
  Ninit=NPOINT;
  Objname(); // 140907
  for N=1:length(Vertex)
    P=Vertex(N);
    Np=Writeobjpoint(P);
    Vertex(N)=[P(1:3),Np]
  end;
  for N=1:length(Face)
    F=Face(N)+Ninit;
    Face(N)=F;
    Str="f"
    for J=1:length(F)
      P=sprintf("%1d",F(J));
      Str=Str+" "+P
    end;
    Printobjstr(Str)
  end;
  Out=list(Vertex,Face)
endfunction
