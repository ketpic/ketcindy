function L=Vecnagasa2(varargin)
  PA=varargin(1);
  if length(varargin)>1
    PB=varargin(2);
  else
    PB=[0,0];
  end
  Tmp=PB-PA;
  L=Tmp*Tmp';
endfunction

