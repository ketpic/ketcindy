// 08.07.11

function Out=Xyzax3data(Xrange,Yrange,Zrange)
  J=mtlb_findstr(Xrange,'=');
  Tmp=evstr(part(Xrange,J+1:length(Xrange)));
  Px=[Tmp(1),0,0]; Qx=[Tmp(2),0,0];
  J=mtlb_findstr(Yrange,'=');
  Tmp=evstr(part(Yrange,J+1:length(Yrange)));
  Py=[0,Tmp(1),0]; Qy=[0,Tmp(2),0];
  J=mtlb_findstr(Zrange,'=');
  Tmp=evstr(part(Zrange,J+1:length(Zrange)));
  Pz=[0,0,Tmp(1)]; Qz=[0,0,Tmp(2)];
  Out=MixS(Spaceline([Px,Qx]),Spaceline([Py,Qy]),Spaceline([Pz,Qz]));
endfunction
