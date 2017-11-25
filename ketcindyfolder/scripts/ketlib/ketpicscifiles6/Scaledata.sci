// 08.05.25 Koshikawa
// 08.09.20
// 15.04.12

function OutL=Scaledata(varargin)
  Nargs=length(varargin);    
  ML=varargin(1);
  ML=Flattenlist(ML);
  A=varargin(2);
  B=varargin(3);
  if Nargs==3
    Pt=[0,0];
  else
    Pt=varargin(4);
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
        X2=Pt(1)+A*(X1-Pt(1));
        Y2=Pt(2)+B*(Y1-Pt(2));
      end
      Out=[Out;X2,Y2];
    end;
    OutL=Mixadd(OutL,Out);
  end;
  if length(OutL)==1
    OutL=Op(1,OutL);
  end;
endfunction

