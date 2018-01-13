//
// 08.12.17
// 09.02.20
// 10.04.12

function Closepicture(varargin)
  global Wfile FID MEMORI MEMORINow ULEN MilliIn;
  Nargs=length(varargin);
  if Nargs==0
    Drwxy();
  elseif varargin(1)==1
    Drwxy();
  end
  if Wfile=='default'
    mprintf('%s','\end{picture}}%'); 
  else
    mfprintf(FID,'%s','\end{picture}}%');
  end
//  MEMORI=MEMORINow*1000/2.54/MilliIn;
  Setunitlen('1cm');
endfunction;

