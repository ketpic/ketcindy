//  08.05.21
//  08.07.14
//  10.01.02 bin remade
//  10.11.13 Flattenlist used

function Dashline(varargin)
  global MilliIn
  Nargs=length(varargin);
  Nall=Nargs; Sen=1 ; Gap=1;
  Tmp=varargin(Nall);
  if type(Tmp)==1 & length(Tmp)==1 & Tmp>0
    Tmp1=varargin(Nall-1);
    if type(Tmp1)==1 & length(Tmp1)==1 & Tmp1>0
       Sen=Tmp1; Gap=Tmp;
       Nall=Nall-2;
    else
       Sen=Tmp; Gap=Sen;
       Nall=Nall-1;
    end
  end
  Sen=1000/2.54/MilliIn*Sen;
  Gap=1000/2.54/MilliIn*Gap;
  for N=1:Nall
    Tmp=varargin(N);
    Fdata=Flattenlist(Tmp);
    for I=1:length(Fdata);
      Figdata=Fdata(I);
      Makehasen(Figdata,Sen,Gap,0);
    end;
  end;
endfunction
