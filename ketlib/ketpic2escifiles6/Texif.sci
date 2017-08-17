// 10.04.16
// 10.04.18
// 10.05.03

function Texif(varargin)
  Condstr=varargin(1);
  Tp=0;
  if length(varargin)>1
    Tp=varargin(2);
  end;
  Texcom('');
  Texcom('{');
  if Tp==0
    Texcom('\ifnum ');
  else
    Texcom('\ifdim ');
  end;
  Texcom(Condstr+' ');
endfunction;
