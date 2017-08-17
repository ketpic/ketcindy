// 08.05.19

// Structure changed
// 09.10.11
// 10.01.10  available for plotdata
// 10.01.12  available for Dataindexed
// 10.01.16

function C=Op(N,Data)
  C=[];
  if Mixtype(Data)>1
    C=Mixop(N,Data);
    return;
  end;
  if type(Data)==10
    if size(Data,2)==1
      C=part(Data,N:N);
    else
      C=Data(N)
    end;
    return;
  end;
  if type(Data)==1
    if size(Data,1)==1
      C=Data(N);
    else
      Din=Dataindex(Data);
      if size(Din,1)==1
        C=Data(N,:);
      else
        C=Data(Din(N,1):Din(N,2),:);
      end;
    end;
  end
endfunction
