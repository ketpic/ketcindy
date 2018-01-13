// 08.05.16  Point style
// 08.05.17  MixL
// 08.05.19  Changed
// 08.05.21  Eps=0.1
// 08.08.16  square
// 09.11.04  window option
// 09.11.07  gcf used
// 09.12.25
// 10.01.01
// 10.01.09  ' '
// 10.01.10  drw one by one
// 10.02.08  revised for the case "a"
// 10.02.13  square debugged
// 10.02.21  square debugged (2)
// 10.02.23  case of mixlength=3
// 10.04.10  Origin bug
// 11.05.29  Flattenlist used

function Windisp(varargin)
  global XMIN XMAX YMIN YMAX GENTEN
  Nargs=length(varargin);
  Tp=varargin(Nargs);
  Ch='';
  if type(Tp)~=10
    scf();
  else
    Ch=part(Tp,1);
    Nargs=Nargs-1;
    select Ch;
     case 'N' then scf();
     case 'n' then scf();
     case 'C' then Tmp=gcf();clf('clear');
     case 'c' then Tmp=gcf();clf('clear');
     case 'A' then Tmp=gcf();
     case 'a' then Tmp=gcf();
     else
       Tmp1=part(Tp,length(Tp));
       Tmp2=part(Tp,1:length(Tp)-1);
       Tmp3=evstr(Tmp2);
       scf(Tmp3);
       if Tmp1=='C'|Tmp1=='c'
         clf('clear');
       end;
    end;
  end;
  Eps=0.1;
  Tmp=Doscaling([XMIN,YMIN]);
  Xm=Tmp(1); Ym=Tmp(2);
  Tmp=Doscaling([XMAX,YMAX]);
  XM=Tmp(1); YM=Tmp(2);
  C=[(Xm+XM)/2,(Ym+YM)/2];
  H=max(XM-Xm,YM-Ym)/2;
  R1=C-H; R2=C+H;
  R1=Unscaling(R1);
  R2=Unscaling(R2);
  if (Ch~='A')&(Ch~='a')
    Tmp1=R1(1);
    Tmp2=R2(1);
    Tmp3=R1(2);
    Tmp4=R2(2);
    square(Tmp1,Tmp3,Tmp2,Tmp4);//
    P=Framedata([XMIN,XMAX],[YMIN,YMAX]);
    Tmp1=P(:,1)';
    Tmp2=P(:,2)';
    plot2d(Tmp1,Tmp2);
    PtO=GENTEN;   // 10.04.10
    if (PtO(2)>=YMIN) & (PtO(2)<=YMAX)  //
      P=Listplot([XMIN,PtO(2)],[XMAX,PtO(2)]);
      Tmp1=P(:,1)';
      Tmp2=P(:,2)';
      plot2d(Tmp1,Tmp2,style=[3]);
    end;
    if (PtO(1)>=XMIN) & (PtO(1)<=XMAX)
      P=Listplot([PtO(1),YMIN],[PtO(1),YMAX]);
      Tmp1=P(:,1)';
      Tmp2=P(:,2)';
      plot2d(Tmp1,Tmp2,style=[3]);
    end;
  end;
  for I=1:Nargs
    Tmp=varargin(I);
	Pdata=Flattenlist(Tmp); //
    for II=1:length(Pdata)
      Tmp=Op(II,Pdata);
      P=MakeCurves(Tmp,0);
      P=Unscaling(P);
      Ndm=Dataindex(P);
      for J=1:size(Ndm,1)
        Q=P(Ndm(J,1):Ndm(J,2),:)
        if size(Q,1)==1
          for K=1:2:length(Q)
            plot2d(Q(K),Q(K+1),style=[-3]);
          end
        else
          Tmp1=Q(:,1)';
          Tmp2=Q(:,2)';
          plot2d(Tmp1,Tmp2);
        end
      end
    end
//    for II=2:length(Pdata)
//      Tmp=Op(II,Pdata);
//      Windisp(Tmp,'a');
//    end;
  end
  for I=2:Nargs
    Pdata=varargin(I);
    Windisp(Pdata,'a');
  end;
endfunction;
