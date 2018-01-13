// 08.05.23   Koshikawa
// 08.09.20
// 15.04.12

function OutL=Rotatedata(varargin)
  Nargs=length(varargin);
  ML=varargin(1);
  ML=Flattenlist(ML);
  Theta=varargin(2);
  if Nargs==2,
    Pt=[0,0]
  else 
    Pt=varargin(3);
  end
  Cx=Pt(1);Cy=Pt(2);
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
        X2=Cx+(X1-Cx)*cos(Theta)-(Y1-Cy)*sin(Theta);
        Y2=Cy+(X1-Cx)*sin(Theta)+(Y1-Cy)*cos(Theta); 
      end;
      Out=[Out;X2,Y2];
    end;
    OutL=Mixadd(OutL,Out);
  end;
  if length(OutL)==1
    OutL=Op(1,OutL);
  end;
endfunction

