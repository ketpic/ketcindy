// 
// 09.02.27
// 10.04.25

function Out=Setwindow(varargin)
  global XMIN XMAX YMIN YMAX
  Nargs=length(varargin);
  if Nargs==0
    Out=[XMIN,XMAX,YMIN,YMAX];
    disp(Out);
    return;
  end;
  if Nargs==1
    Dt=varargin(1);
    if type(Dt)==1
      Dt=list(Dt);
    end;
    Xm=%inf; XM=-%inf;
    Ym=%inf; YM=-%inf;
    for I=1:length(Dt)
      GL=Dividegraphics(Dt(I));
      for J=1:length(GL)
        G=GL(J); 
        Tmp=min(G(:,1)); Xm=min(Xm,Tmp);
        Tmp=max(G(:,1)); XM=max(XM,Tmp);
        Tmp=min(G(:,2)); Ym=min(Ym,Tmp);
        Tmp=max(G(:,2)); YM=max(YM,Tmp);
      end;
    end;
    XMIN=Xm; XMAX=XM;
    YMIN=Ym; YMAX=YM;
  end;
  if Nargs==2
    RgX=varargin(1);
    RgY=varargin(2);
    XMIN=RgX(1); XMAX=RgX(2);
    YMIN=RgY(1); YMAX=RgY(2);
  end
  if Nargs==4
    XMIN=varargin(1); XMAX=varargin(2);
    YMIN=varargin(3); YMAX=varargin(4);
  end;
  Out=[XMIN,XMAX,YMIN,YMAX];
endfunction;
