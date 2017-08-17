// 09.10.17
// 09.12.05
// 09.12.29
// 14.09.30  addition supported

function Assignrep(varargin)
  global ASSIGNLIST;
  Nargs=length(varargin);
  for I=1:2:Nargs
    Vname=varargin(I);
    Val=varargin(I+1);
    Tmp=Assign('?'+Vname);
    if Tmp=='Not found'
      Tmp=length(ASSIGNLIST);
      ASSIGNLIST(Tmp+1)=Vname;
      ASSIGNLIST(Tmp+2)=Val;
    else
      I=Tmp(1);
      ASSIGNLIST(I+1)=Val;
    end;
  end
endfunction;