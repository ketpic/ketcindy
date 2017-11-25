// 08.09.19
// 10.02.17

function Out=Sfcutoffrawparadata(varargin)
  Ms=list('raw','para');
  for I=1:length(varargin)
    Tmp=varargin(I);
    Ms=Mixjoin(Ms,list(Tmp));
  end;
  Out=Makesfcutoffdata(Ms);
endfunction;

