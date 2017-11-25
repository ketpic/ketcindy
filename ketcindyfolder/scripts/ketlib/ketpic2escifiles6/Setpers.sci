// 08.08.12
// 08.08.15

function Setpers(varargin)
  global FocusPoint EyePoint;
  Nargs=length(varargin);
  if Nargs==0
    Mixdisp(Mix('FocusPoints=',FocusPoint));
    Mixdisp(Mix('EyePoint=',EyePoint));
    return;
  else
    FocusPoint=varargin(1);
    EyePoint=varargin(2);
  end;
endfunction

