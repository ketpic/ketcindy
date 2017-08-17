// 
// 09.02.27

function Setpt(varargin)
  global TenSize TenSizeInit;
   Nargs=length(varargin);
   if Nargs==0
     Tmp=TenSize/TenSizeInit;
     Tmp=round(Tmp*100)/100;
     disp(Tmp);
     return;
   end;
   Size=varargin(1);
  TenSize=TenSizeInit*Size;
endfunction;

