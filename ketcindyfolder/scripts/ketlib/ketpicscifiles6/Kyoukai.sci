// 08.05.18
// 08.05.19
// 08.05.20
// 08.05.30
// 08.09.19
// 08.10.26
// 09.01.15  "e"
// 09.05.18
// 09.12.05
// 16.11.03 Eps=10^(-5)
// 16.12.05 Eps=10^(-7)

function PLall=Kyoukai(varargin)
  global XMIN XMAX YMIN YMAX
  Nargs=length(varargin);
  Eps0=10^(-7);
  DataL=[];
  for I=1:Nargs
    Tmp=varargin(I);
    if Mixtype(Tmp)==1
      Tmp1=MixS(Tmp);
      DataL=Mixadd(DataL,Tmp1);
    end
    if Mixtype(Tmp)==2
      DataL=Mixadd(DataL,Tmp);
    end
    if Mixtype(Tmp)==3
      DataL=Mixjoin(DataL,Tmp);
    end
  end;
  Eps=10.0^(-4);
  PLall=[];
  Sflg=0;
  N=Mixlength(DataL);
  for I=1:N
    Data=Op(I,DataL);
    Tmp=Op(Mixlength(Data),Data);
    if type(Tmp)==1 & size(Tmp,1)==1 & size(Tmp,2)>1
      Rg=Tmp ; Nd=Mixlength(Data)-1;
    elseif type(Tmp)==10
      Rg=Tmp ; Nd=Mixlength(Data)-1;
    else 
      Rg='c' ; Nd=Mixlength(Data);
    end;
    for J=1:Nd
      Tmp=Op(J,Data);
      if type(Tmp)==10
        Rg=Tmp;
        continue
      end
      Points=Tmp;
      P1=Ptstart(Points);
      P2=Ptend(Points);
      if J==1
        PL=Points;
        Pfirst=P1;
        Plast=P2;
        if Nd>=2
          Tmp=Op(2,Data);
          P=Ptstart(Tmp);
          Q=Ptend(Tmp);
          if norm(P2-P)>Eps & norm(P2-Q)>Eps
            Tmp=size(PL,1);
            PL=PL(Tmp:-1:1,:);
            Pfirst=Ptstart(PL);
            Plast=Ptend(PL);
          end;
        end
      else
        if norm(P1-Plast)<Eps 
          Stp=1; Ks=2; Ke=size(Points,1);
        elseif norm(P2-Plast)<Eps 
          Stp=-1; Ks=size(Points,1)-1; Ke=1;
        else
          PL=[PL;%inf,%inf;Points];
          Sflg=1;
          Pfirst=P1;
          Plast=P2;
          Stp=1; Ks=size(Points,1)-1; Ke=1;
        end
        for K=Ks:Stp:Ke
          PL=[PL;Points(K,:)];
        end
        Plast=Points(Ke,:);
      end
    end  
    if norm(Pfirst-Plast)>Eps
      Np=size(PL,1);
      if Rg=='c'
        PL=[PL;Pfirst];
      elseif Rg=='s'
        Tmp=[PL(1:Np,2);YMIN];
        Y=min(Tmp)-1;
        P=[Plast(1),Y]; Q=[Pfirst(1),Y];
        PL=[PL;P;Q;Pfirst];
      elseif Rg=='n'
        Tmp=[PL(1:Np,2);YMAX];
        Y=max(Tmp)+1;
        P=[Plast(1),Y]; Q=[Pfirst(1),Y];
        PL=[PL;P;Q;Pfirst];
      elseif Rg=='w'
        Tmp=[PL(1:Np,1);XMIN];
        X=min(Tmp)-1;
        P=[X,Plast(2)]; Q=[X,Pfirst(2)];
        PL=[PL;P;Q;Pfirst];
      elseif Rg=='e'
        Tmp=[PL(1:Np,1);XMAX];
        X=max(Tmp)+1;
        P=[X,Plast(2)]; Q=[X,Pfirst(2)];
        PL=[PL;P;Q;Pfirst];
      elseif type(Rg)==1 & size(Rg,1)==1 & size(Rg,2)>1
        Tmp=Kukeiwake(PL);  //Modified from here
        Tmp1=Op(1,Tmp);
        Tmp2=Naigai(Rg,Mix(Tmp1)); 
        if Tmp2==[1]
          PL=Op(1,Tmp);
        else
          PL=Op(2,Tmp);       // to here
        end
      end
    end
    Tmp=[Ptstart(PL)];
    for J=2:size(PL,1)
      P=PL(J,:);
      Q=Tmp(size(Tmp,1),:);
      if norm(P-Q)>Eps then
        Tmp=[Tmp;P];
      end
    end
    PL=Tmp;
    PLall=Mixadd(PLall,PL);
  end
  if Mixlength(PLall)==1 & Sflg==0
    Tmp=Op(1,PLall);
//    Tmp=Op(1,Tmp);
    if norm(Ptstart(Tmp)-Ptend(Tmp))>Eps0
       Tmp=[Tmp;Ptstart(Tmp)];
       PLall=MixS(Tmp);
    end
  end;
endfunction;



