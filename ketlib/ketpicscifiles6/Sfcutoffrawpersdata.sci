// 08.09.21
// 10.02.17

function Out=Sfcutoffrawpersdata(varargin)
  Ms=list('raw','pers');
  for I=1:length(varargin)
    Tmp=varargin(I);
    Ms=Mixjoin(Ms,list(Tmp));
  end;
  Out=Makesfcutoffdata(Ms);
endfunction;

