//
// 12.01.07   kirikomi(Cut)
// 12.08.26 debugged
// 15.06.11 debugged
// 15.10.24 debugged

function Arrowline(varargin)
  global YaSize YaAngle YaPosition YaThick YaStyle Kirikomi;
  Nargs=length(varargin)
  P=varargin(1);
  Q=varargin(2);
  Futosa=YaThick;
  Ookisa=YaSize;
  Hiraki=YaAngle;
  Yapos=YaPosition;
  Cutstr="Cut=0";
  Str=YaStyle;
  Flg=0;
  for I=3:Nargs
    Tmp=varargin(I);
    if type(Tmp)==10
      Equal=mtlb_findstr(Tmp,'='); // 12.01.07 from
      if length(Equal)>0
        Tmp2=strsplit(Tmp,Equal-1);
        if (Tmp2(1)=="Cut") | (Tmp2(1)=="cut")
          Tmp="Cut"+Tmp2(2);
          Cutstr=Tmp;
        end
      else
        Str=Tmp; // 12.01.07 upto (debugged on 12.08.26)
      end;
    end;
    if (type(Tmp)==1) & (length(Tmp)==1)
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
        Yapos=Tmp;
      end
      if Flg==3 
        Futosa=Tmp;
      end
      Flg=Flg+1;
    end
  end
  R=P+Yapos*(Q-P);
  Tmp=Q-Unscaling(0.2*Ookisa/2*(Q-P)/norm(Q-P));   // 15.10.24
  Drwline(Listplot([P,Tmp]),Futosa);
  Arrowhead(R,Q-P,Ookisa,Hiraki,Futosa,Cutstr,Str);  // 12.01.07
endfunction
