// 08.09.09
// 08.09.20
// 13.10.19 ( __ added to variables )

function Out__=Implicitplot(varargin)
  Eps__=10^(-4);
  Nargs__=length(varargin);
  Fstr__=varargin(1);
  if Mixtype(Fstr__)~=1
    MS__=Fstr__;
    [Zval__,Xval__,Yval__]=Makevaltable(MS__);
  elseif type(Fstr__)==10
    MS__=[];
    for I__=1:Nargs__
      MS__=Mixadd(MS__,varargin(I__));
    end;
    [Zval__,Xval__,Yval__]=Makevaltable(MS__);
  else
    Zval__=varargin(1);
    Xval__=varargin(2);
    Yval__=varargin(3);
  end;
  Out__=[];
  for J__=1:length(Yval__)-1
    for I__=1:length(Xval__)-1
      a1__=Xval__(I__);b1__=Yval__(J__);c1__=Zval__(J__,I__);
      a2__=Xval__(I__+1);b2__=Yval__(J__);c2__=Zval__(J__,I__+1);
      a3__=Xval__(I__+1);b3__=Yval__(J__+1);c3__=Zval__(J__+1,I__+1);
      a4__=Xval__(I__);b4__=Yval__(J__+1);c4__=Zval__(J__+1,I__);
      PL__=[a1__,b1__;a2__,b2__;a3__,b3__;a4__,b4__;a1__,b1__];
      VL__=[c1__,c2__,c3__,c4__,c1__];
      QL__=[];
      for K__=1:4
        if abs(VL__(K__))<=Eps__
          QL__=[QL__;PL__(K__,:)];
        elseif VL__(K__)>Eps__
          if VL__(K__+1)<-Eps__
            Tmp__=1/(VL__(K__)-VL__(K__+1))*(-VL__(K__+1)*PL__(K__,:)...
                  + VL__(K__)*PL__(K__+1,:));
            QL__=[QL__;Tmp__];
          end
        else
          if VL__(K__+1)>Eps__
            Tmp__=1/(-VL__(K__)+VL__(K__+1))*(VL__(K__+1)*PL__(K__,:)...
                  - VL__(K__)*PL__(K__+1,:));
            QL__=[QL__;Tmp__];
          end;
        end;
      end;
      if size(QL__,1)==2
        Out__=[Out__;%inf,%inf;QL__(1,:);QL__(2,:)];
      end;
    end;
  end;
  Out__=Out__(2:size(Out__,1),:);
  if size(Out__,1)>0
    Out__=Connectseg(Out__);
  else
    Out__=[];
  end;
endfunction;
