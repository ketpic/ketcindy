// 08.07.11

function Z=Spaceline(varargin)
  Z=[];
  for I=1:length(varargin)
    Data=varargin(I);
    if Mixtype(Data)==1
      for J=1:3:size(Data,2)
        Tmp=Data(J:J+2);
        Z=[Z;Tmp];
      end;
      continue;
    end;
    if Mixtype(Data)==3
      Tmp=[];
      for I=1:Mixlength(Data);
        Tmp=Mixjoin(Tmp,Mixop(I,Data));
      end;
      Data=Tmp;
    end;
    for J=1:Mixlength(Data)
      Tmp=Mixop(J,Data);
      Z=[Z;Tmp];
    end;  
  end
endfunction

