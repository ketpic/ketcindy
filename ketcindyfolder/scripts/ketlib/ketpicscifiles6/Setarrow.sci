// 08.05.31
// 09.02.27

function Setarrow(varargin)
  global YaSize YaAngle YaPosition YaThick YaStyle;
  Nargs=length(varargin);
  if Nargs==0
    Mixdisp(Mix('Size=',YaSize));
    Mixdisp(Mix('Angle=',YaAngle));
    Mixdisp(Mix('Position=',YaThick));
    Mixdisp(Mix('Style=',YaStyle));
    return;
  end;
  Flg=0;
  for I=1:Nargs
    Tmp=varargin(I);
    if type(Tmp)==1
      Flg=Flg+1;
      if Flg==1 YaSize=Tmp; end
      if Flg==2
        if Tmp<5
          YaAngle=18*Tmp;
        else
          YaAngle=Tmp;
        end
      end
      if Flg==3 YaPosition=Tmp; end
      if Flg==4 YaThick=Tmp; end
    end
    if type(Tmp)==10
      YaStyle=Tmp
    end
  end
endfunction;

