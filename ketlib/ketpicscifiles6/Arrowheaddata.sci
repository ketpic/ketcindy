// 08.05.31
// 09.12.25
// 13.11.13  debugged
// 14.11.02  debugged

function Out=Arrowheaddata(varargin)
  global YaSize YaAngle YaPosition YaThick YaStyle;
  Eps=10^(-3);
  Nargs=length(varargin);
  Out=[];
  P=varargin(1);
  Houkou=varargin(2);
  Ookisa=0.2*YaSize;
  Hiraki=YaAngle;
  Futosa=0;
  Thickness=1;
  Str=YaStyle;
  Flg=0;
  for I=3:Nargs
    Tmp=varargin(I);
    if type(Tmp)==10
      if mtlb_findstr(Tmp,'=')~=[]
        execstr(Tmp);
        Futosa=Thickness;
      else
        Str=Tmp;
      end
    end
    if type(Tmp)==1 & length(Tmp)==1
      if Flg==0
        Ookisa=Ookisa*Tmp;
      end
      if Flg==1
        if Tmp<5 
          Hiraki=Tmp*Hiraki;
        else
          Hiraki=Tmp;
        end
      end
      Flg=Flg+1;
    end
  end
  Theta=Hiraki*%pi/180;
  if size(Houkou,1)>1
    P=Doscaling(P);
    Houkou=Doscaling(Houkou);
    Tmp=Nearestpt(P,Houkou);
    A=Op(1,Tmp);
    I=floor(Op(2,Tmp));
    if I==1 // 14.11.02
      if norm(Ptend(Houkou)-Ptstart(Houkou))<Eps
        l=Numptcrv(Houkou);
      end;
    end;
    G=Circledata(P,Ookisa*cos(Theta),'N=10');
    Flg=0; // 13.11.13
    for J=I:-1:1
      B=Ptcrv(J,Houkou);
      Tmp=IntersectcrvsPp(Listplot([A,B]),G);
      if Mixlength(Tmp)>0
        Flg=1;
        break
      end
      A=B
    end
    if Flg==0  // 13.11.13
      disp('Arrowhead may be too large (no intersect)');
      return
    end
    Houkou=P-Op(1,Op(1,Tmp));
    Houkou=Unscaling(Houkou);
    P=Unscaling(P);
  end
  P=Doscaling(P);
  Houkou=Doscaling(Houkou);
  E=-1/Vecnagasa(Houkou)*Houkou;
  N=[-E(2),E(1)];
  if mtlb_findstr(Str,'c')~=[]
    P=P-0.5*Ookisa*cos(Theta)*E;
  end
  if mtlb_findstr(Str,'b')~=[]
    P=P-Ookisa*cos(Theta)*E
  end
  A=P+Ookisa*cos(Theta)*E+Ookisa*sin(Theta)*N;
  B=P+Ookisa*cos(Theta)*E-Ookisa*sin(Theta)*N;
  Out=Listplot([A,P,B]);
  Out=Unscaling(Out);
endfunction

