// 08.05.14 Data Structure
// 08.05.23 Debugged

// Structure changed
// 09.10.11

function Out=Mixlength(PL)
  if PL==[]
    Out=0;
    return
  end
  if Mixtype(PL)==1
    Out=size(PL,1);
  else
    Out=length(PL);
  end;
endfunction

