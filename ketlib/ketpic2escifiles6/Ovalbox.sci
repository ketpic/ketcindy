function Ovalbox(varargin)
  global XMIN XMAX YMIN YMAX
  Nargs=length(varargin);
  Pos=varargin(1);
  Dr=varargin(2);
  StrV=varargin(3);
  R=0.2;
  NDflg=0;
  for I=4:Nargs
    Tmp=varargin(I);
    if type(Tmp)==1
      R=Tmp;
    else
      if part(Tmp,1)=='-'
        NDflg=1;
        Tmp1=part(Tmp,2:length(Tmp));
        Cmdstr=strsubst(Tmp1,'*','G1');
      end;
    end;
  end;
  Xr=[XMIN,XMAX];
  Yr=[YMIN,YMAX];
  Uv=0.6; Uh=0.8;
  N=length(StrV);
  W=Uh; H=Uv*N;
  Setwindow([-W/2,W/2],[-H,0]);
  G1=Ovaldata([0,-H/2],W/2,H/2,R);
  Openphr('\ketpictmp');
    Beginpicture('1cm');
    if NDflg==0
      Drwline(G1);
    else
      execstr(Cmdstr);  
    end;  
    for I=1:N
      Letter([0,Uv/2-Uv*I],'c',Op(I,StrV))
    end;
    Endpicture(0);
  Closephr();
  Setwindow(Xr,Yr);
  Letter(Pos,Dr,'\ketpictmp');
endfunction;