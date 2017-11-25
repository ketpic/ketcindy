// 09.11.26
// 09.12.06
// 09.12.25
// 09.12.29

function Putcell(varargin)
  Nargs=length(varargin);
  TbL=varargin(1);
  Str=varargin(Nargs);
  if type(Str)==1
    Str=string(Str);
  end;
  Pos=varargin(Nargs-1);
  Nrg=varargin(2);
  if type(Nrg)==10
    if Nargs==4
      Cell=Findcell(TbL,Nrg);
    else
      Mrg=varargin(3);
      Cell=Findcell(TbL,Nrg,Mrg);
    end;
  else
    Mrg=varargin(3);
    Cell=Findcell(TbL,Nrg,Mrg);
  end;
  Pt=Cell(1); Dr='c';
  Posh=part(Pos,1);
  Post=part(Pos,2:length(Pos));
  if (Posh=='r')|(Posh=='R')
    Pt=Pt+[Cell(2),0];
    if length(Post)==0
      Dr='w1';
    else
      Dr='w'+Post;
    end;
  end;
  if (Posh=='l')|(Posh=='L')
    Pt=Pt-[Cell(2),0];
    if length(Post)==0
      Dr='e1';
    else
      Dr='e'+Post;
    end;
  end;
  if (Posh=='u')|(Posh=='U')
    Pt=Pt+[0,Cell(3)];
    if length(Post)==0
      Dr='s1';
    else
      Dr='s'+Post;
    end;
  end;
  if (Posh=='d')|(Posh=='D')
    Pt=Pt-[0,Cell(3)];
    if length(Post)==0
      Dr='n1';
    else
      Dr='n'+Post;
    end;
  end;
  if (Posh=='b')|(Posh=='B')
    Pt=Pt-[0,Cell(3)];
    if length(Post)==0
      Dr='n1';
    else
      Dr='n'+Post;
    end;
    Str='$\mathstrut$'+Str;
  end;
  Letter(Pt,Dr,Str);
endfunction;

