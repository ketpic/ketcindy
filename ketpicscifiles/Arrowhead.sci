//
// 08.06.01
// 09.12.25
// 12.01.07   kirikomi(Cut)
// 12.04.16 debugged
// 13.05.17 debugged
// 13.11.13 debugged
// 15.06.11 debugged
// 15.06.14 debugged
// 15.06.15 improved

function Arrowhead(varargin)
  global Wfile FID MilliIn YaSize ...
         YaAngle YaPosition YaThick YaStyle;
  Nargs=length(varargin);
  P=varargin(1);
  Houkou=varargin(2);
  Ookisa=0.2*YaSize;
  Hiraki=YaAngle;
  Futosa=0.5*YaThick;
  Cut=0;
  Str=YaStyle;
  Flg=0;
  for I=3:Nargs
    Tmp=varargin(I);
    if type(Tmp)==10
      Equal=mtlb_findstr(Tmp,'='); // 12.01.07 from
      if length(Equal)>0
        Tmp2=strsplit(Tmp,Equal-1);
         if Tmp2(1)=="Cut" | Tmp2(1)=="cut"
           Tmp="Cut"+Tmp2(2);
           execstr(Tmp);
      end;
      else
        Str=Tmp;
      end; // 12.01.07 upto
    end;
    if type(Tmp)==1 & length(Tmp)==1
      if Flg==0
        Ookisa=Ookisa*Tmp;
      end
      if Flg==1
        if Tmp<5 
          Hiraki=Tmp*Hiraki
        else
          Hiraki=Tmp
        end
      end
      if Flg==2
        Futosa=Tmp
      end
      Flg=Flg+1;
    end
  end;
  Ookisa=1000/2.54/MilliIn*Ookisa;
  Theta=Hiraki*%pi/180;
  if size(Houkou,1)>1
    P=Doscaling(P);
    Houkou=Doscaling(Houkou);
    Tmp=Nearestpt(P,Houkou);
    A=Op(1,Tmp);
    I=floor(Op(2,Tmp));
    G=Circledata(P,Ookisa*cos(Theta),'N=10');
    Flg=0;  // 13.11.13
    for J=I:-1:1
      B=Ptcrv(J,Houkou);
      Tmp=IntersectcrvsPp(Listplot([A,B]),G);
      if Mixlength(Tmp)>0
        Flg=1;
        break
      end
      A=B
    end
    if Flg==0 // 13.11.13
      disp('Arrowhead may be too large (no intersect)');
      return
    end
    Houkou=P-Op(1,Op(1,Tmp));
    Houkou=Unscaling(Houkou);
    P=Unscaling(P);
  end;
  P=Doscaling(P);
  Houkou=Doscaling(Houkou);
  Ev=-1/Vecnagasa(Houkou)*Houkou;
  Nv=[-Ev(2),Ev(1)];
  if mtlb_findstr(Str,'c')~=[]
    P=P-0.5*Ookisa*cos(Theta)*Ev
  end;
  if mtlb_findstr(Str,'b')~=[]
    P=P-Ookisa*cos(Theta)*Ev
  end;
  A=P+Ookisa*cos(Theta)*Ev+Ookisa*sin(Theta)*Nv;
  B=P+Ookisa*cos(Theta)*Ev-Ookisa*sin(Theta)*Nv;
  if mtlb_findstr(Str,'l')~=[]
    Tmp=Listplot([A,P,B]);
    Tmp1=Unscaling(Tmp); // 13.05.17
    Drwline(Tmp1,Futosa);
  else
    C=P+(1-Cut)*((A+B)/2-P);  // 12.01.05
    Tmp=Listplot([A,P,B,C,A]);  // 12.01.05
    Tmp1=Unscaling(Tmp);
    Shade(Tmp1);
    Tmp=Listplot([A,P,B,C,A,P]);  // 15.6.20
    Tmp1=Unscaling(Tmp);
    Drwline(Tmp1,0.1);  // 15.06.11, 15.06.14
  end
endfunction
