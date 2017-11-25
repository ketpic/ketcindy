function L=Vecnagasa(varargin)
  PA=varargin(1);
  if length(varargin)>1
    PB=varargin(2);
  else
    PB=zeros(1,length(PA));
  end
  Tmp=PB-PA;
  L=sqrt(Tmp*Tmp');
endfunction

