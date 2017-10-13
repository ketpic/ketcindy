// 
// 08.07.13
// 09.06.13

function Z=Listplot(varargin)
  Z=[];
  for I=1:length(varargin)
    Data=varargin(I);
    if Mixtype(Data)==1
      if size(Data,1)==1
        Tmp=matrix(Data,2,size(Data,2)/2);
        Z=[Z;Tmp'];
      else
        Z=[Z;Data];
      end;
    else
      for J=1:Mixlength(Data)
        Tmp=Mixop(J,Data);
        Z=[Z;Tmp];
      end
    end
  end
endfunction

