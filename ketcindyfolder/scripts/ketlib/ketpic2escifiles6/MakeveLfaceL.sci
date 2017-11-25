// 08.08.22
// 09.10.25
// 09.10.26
// 09.10.27
// 09.10.29

function Out=MakeveLfaceL(VfL)
  // Out format
  //   VeL   Edge, Face num(as numlist), VeL num
  //   FL    Face (Vertexs)
  Eps=10^(-4);
  Tmp=VfL($);
  Tmp1=Tmp(1);
  if type(Tmp1)==1
    FvL=list(VfL);
  else
    FvL=VfL;
  end;
  EL=list(); FL=list();
  for Nn=1:length(FvL)
    Tmp=FvL(Nn);
    VL=Tmp(1);
    if length(VL)>0
      FnL=Tmp(2);
      FaceL=list();
      for I=1:length(FnL)
        Tmp1=FnL(I);
        PtL=list();
        for J=1:length(Tmp1)
          Tmp2=Tmp1(J);
          PtL(J)=VL(Tmp2);
        end;
        FaceL(I)=PtL;
      end;
    else
      FaceL=list(Tmp(2));
    end;
    for I=1:length(FaceL)
      Face=FaceL(I);
      Face($+1)=Face(1);
      FL($+1)=Face;
      for J=1:length(Face)-1
        Edge=list(Face(J),Face(J+1));
        Flg=0;
        for K=1:length(EL)
          Tmp=EL(K);
          Tmp1=Tmp(1);
          Tmp2=norm(Edge(1)-Tmp1(1))+norm(Edge(2)-Tmp1(2));
          Tmp3=norm(Edge(1)-Tmp1(2))+norm(Edge(2)-Tmp1(1));
          if Tmp2<Eps | Tmp3<Eps
            Tmp=EL(K);
            Tmp1=Tmp(1);
            Tmp2=[Tmp(2),length(FL)];
            EL(K)=list(Tmp1,Tmp2,K);
            Flg=1;
            break;
          end;
        end;
        if Flg==0
          Ntmp=length(EL);
          EL(Ntmp+1)=list(Edge,[length(FL)],Ntmp+1);
        end;
      end;
    end;
  end;
  Out=list(EL,FL);
endfunction

