// 08.07.11
// 08.08.12
// 09.02.27

function Setangle(varargin)
  global PHI THETA;
  Nargs=length(varargin);
  if Nargs<2
    Mixdisp(Mix('theta=',THETA*180/%pi));
    Mixdisp(Mix('phi=',PHI*180/%pi));
    return;
  else
    PHI=varargin(2)*%pi/180;
    THETA=varargin(1)*%pi/180;
  end
endfunction;

