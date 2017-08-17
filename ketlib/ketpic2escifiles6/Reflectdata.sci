// 08.05.25 Koshikawa
// 08.09.20
// 15.04.12

function OutL=Reflectdata(varargin)
  Nargs=length(varargin)    
  ML=varargin(1);
  ML=Flattenlist(ML);
  if Nargs==1
    PtA=[0,0];PtB=PtA;
  else
    Pts=varargin(2);
    if length(Pts)==2
      PtA=Pts; PtB=PtA;
    else
      PtA=Pts(1,1:2); PtB=Pts(1,3:4);
    end
  end  
  OutL=[];
  for N=1:length(ML)
    GL=Op(N,ML);
    Out=[];
    for I=1:size(GL,1)
      Tmp=GL(I,:);
      X1=Tmp(1);
      Y1=Tmp(2);
      if Tmp==[%inf,%inf]
        X2=X1;
        Y2=Y1;
      else
        if PtA==PtB
          X2=2*PtA(1)-X1;
          Y2=2*PtA(2)-Y1;
        else  
          U=PtB(1)-PtA(1);
          V=PtB(2)-PtA(2);
          A=PtA(1);
          B=PtA(2);
          X2=(U^2-V^2)/(U^2+V^2)*X1+2*U*V/(U^2+V^2)*Y1-2*V*(U*B-V*A)/(U^2+V^2);
          Y2=2*U*V/(U^2+V^2)*X1-(U^2-V^2)/(U^2+V^2)*Y1+2*U*(U*B-V*A)/(U^2+V^2);
        end
      end
      Out=[Out;X2,Y2];
    end;
    OutL=Mixadd(OutL,Out);
  end;
  if length(OutL)==1
    OutL=Op(1,OutL);
  end;
endfunction;

