// 08.05.08

function Out=Arrowdata(varargin)
  global YaSize YaAngle YaPosition YaThick YaStyle;
  Nargs=length(varargin);
  P=varargin(1);
  Q=varargin(2);
  R=Q;
  Futosa=YaThick;
  Ookisa=YaSize;
  Thickness=1;
  Hiraki=YaAngle;
  Yapos=YaPosition;
  Position=1;
  Str=YaStyle;
  Flg=0;
  for I=3:Nargs
    Tmp=varargin(I);
    if type(Tmp)==1
      if length(Tmp)>1
        R=Tmp
      else
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
        if Flg==2
          R=P+Tmp*(Q-P);
        else
          R=P+Yapos*(Q-P);
        end
        if Flg==3
          Futosa=Tmp
        end
        Flg=Flg+1;
      end
    end
    if type(Tmp)==10
      if mtlb_findstr(Tmp,'=')~=[]
        execstr(Tmp);
        Futosa=Futosa*Thickness;
        R=P+Position*(Q-P);
      else
        Str=Tmp
      end
    end
  end
  Tmp1=Listplot([P,Q]);
  Tmp2=Arrowheaddata(R,Q-P,Ookisa,Hiraki,Futosa,Str);
  Out=Joingraphics(Tmp1,Tmp2);
endfunction

