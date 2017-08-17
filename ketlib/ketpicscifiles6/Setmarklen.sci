// 
// 09.02.27
// 14.03.05 MARKLEN

function Setmarklen(varargin)
  global MARKLEN MARKLENInit MARKLENNow;
  Nargs=length(varargin);
  if Nargs==0
    Tmp=MARKLEN/MARKLENInit;
    Tmp=round(Tmp*100)/100;
    disp(Tmp);
    return;
  end;
  Size=varargin(1);
  MARKLEN=MARKLENInit*Size;
  MARKLENNow=MARKLEN;
endfunction
