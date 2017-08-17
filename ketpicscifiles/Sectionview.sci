// 09.09.10
// 09.10.12 remove:Uveq, add:Glist

function Out=Sectionview(PtA,Vec,Fd,Glist,Np,Eps)
  Uv=1/norm(Vec)*Vec;
  Nv=[Uv(2),-Uv(1),0];
  G1=Sfcutdata(Fd,Mix(Nv,PtA),Np);
  G2=Spaceline([PtA,PtA+10*Uv]);
  Tmp=Mixjoin(G1,G2,Glist);
  Tmp1=Viewfrom(Nv,Tmp);
  Out=Tmp;
endfunction;


