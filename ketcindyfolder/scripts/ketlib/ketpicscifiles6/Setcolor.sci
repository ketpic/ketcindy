// 11.05.28
// 11.08.24
// 15.05.03

function Setcolor(varargin)
  global Wfile FID;
  Nargs=length(varargin);
  Color='black';
  Kosa=1;
  Color=varargin(1);
  if length(varargin)>1
    Kosa=varargin(2);
  end;
  Iro=Ratiocmyk(Color);
  if type(Iro)==10
    Str='\color{'+Iro+"}%";
  else
    if size(Iro,2)>3
      Str='\color[cmyk]{';
    else
      Str='\color[rgb]{';
    end;
    for J=1:size(Iro,2)
      Str=Str+string(Kosa*Iro(J));
      if J<size(Iro,2)
        Str=Str+',';
      end;
    end;
    Str=Str+'}%';
  end;
  if Wfile=='default'
    mprintf('%s\n',Str);
  else
     mfprintf(FID,'%s\n',Str);
  end
endfunction
