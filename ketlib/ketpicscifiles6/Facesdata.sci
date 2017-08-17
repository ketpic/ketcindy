/////////
// 09.10.29
// 11.01.13  (HiddenL) remodified 110122
// 13.03.30  (HiddenL) debugged 140330

function NohiddenL=Facesdata(varargin)
  global PHHIDDENDATA VELNO VELHI;
  Nargs=length(varargin);
  FL=varargin(1);
  PT=varargin($);
  if mtlb_findstr(PT,'para')~=[]
    Ptype=1;  //para
  else
    Ptype=-1;   //pers
  end;
  if Nargs==2
    CLadd=list();
  else
    CLadd=varargin(2);
  end;
  NohiddenL=list();
  HiddenL=list();
  Eps=10^(-4);
  if length(CLadd)>0
    if type(CLadd)==1
      C=list();
      if size(CLadd,1)>1
        for I=1:size(CLadd,1)
          C($+1)=CLadd(I,:);
        end;
      else
        for I=1:3:size(CLadd,2)
          C($+1)=CLadd(1,I:I+2);
        end;
      end;
      CrvL=list(C);
    elseif type(CLadd(1))==1
      CrvL=list();
      for J=1:length(CL)
        Ctmp=CLadd(J);
        C=list();
        if size(Ctmp,1)>1
          for I=1:size(Ctmp,1)
            C($+1)=Ctmp(I,:);
          end;
        else
          for I=1:3:size(Ctmp,2)
            C($+1)=Ctmp(1,I:I+2);
          end;
        end;
        CrvL($+1)=C;
      end;
    else
      CrvL=CLadd;
    end;
  else
    CrvL=list();
  end;
  Out=MakeveLfaceL(FL);
  VELNO=Out(1);
  VELHI=list();
  for I=1:length(CrvL)
    Tmp=CrvL(I);
    for J=1:length(Tmp)-1
      Edge=list(Tmp(J),Tmp(J+1));
      Ntmp=length(VELNO);                //
      VELNO(Ntmp+1)=list(Edge,0,Ntmp+1); //
    end;
  end;
  FaceL=Out(2);  
  if mtlb_findstr(PT,'raw')==[]
    for Nf=1:length(FaceL)
      Face=FaceL(Nf);
      Menkakusi2(Face,Nf,Ptype);
    end;
  end;
  for I=1:length(VELNO)
    Edge=Op(1,VELNO(I));
    if norm(Edge(1)-Edge(2))>Eps
      NohiddenL($+1)=Spaceline(Edge);
    end;
  end;
  EdgeL=list();  // from 13.03.30
  for K=1:length(VELHI)
    Edge=Op(1,VELHI(K));
    P=Edge(1); Q=Edge(2);
    if norm(P-Q)>Eps then
      EdgeL($+1)=Edge;
    end
  end
  for K=1:length(EdgeL)
    Edge=EdgeL(K); //
    P=Edge(1); Q=Edge(2);
    Cflg=0;
    for J=K+1:length(EdgeL)
      Ej=EdgeL(J); //
      Pj=Ej(1); Qj=Ej(2);
      if norm(Crossprod(Q-P,Qj-Pj))>Eps then
        continue
      end
      if norm(Q-Pj)<Eps then
         EdgeL(J)=list(P,Qj);
         Cflg=1;
         break;
      end
      if norm(P-Qj)<Eps then
        EdgeL(J)=list(Q,Pj)
        Cflg=1;
        break;
      end;
    end
    if Cflg==0 then
      HiddenL($+1)=Spaceline(Edge);
    end;
  end;  // upto 14.03.30
  
//  L=1:length(VELHI); // from  11.01.13
//  while length(L)>0 
//    Lr=[];
//    Edge=Op(1,VELHI(L(1))); //
//    P=Edge(1);
//    Q=Edge(2);
//    
//    disp([293,P,Q])
//    
//    if norm(P-Q)>Eps
//      for J=2:length(L)
//        Rflg=0;
//        Ej=Op(1,VELHI(L(J))); //
//        Pj=Ej(1);
//        Qj=Ej(2);
//        if norm(Crossprod(Q-P,Qj-Pj))>Eps
//          Lr=[Lr,J];
//          continue;
//        end;
//        if norm(Q-Pj)<Eps
//          Edge(2)=Qj;
//          Rflg=1;
//        elseif norm(P-Qj)<Eps
//          Edge(1)=Pj;
//          Rflg=1;
//        end;
//        if Rflg==0
//          Lr=[Lr,J];
//        end;
//      end;
//    else
//      Lr=L(2:length(L));
//    end;
//    L=Lr;  // upto 11.01.13
//    HiddenL($+1)=Spaceline(Edge);
//  end;
  PHHIDDENDATA=HiddenL;
endfunction
