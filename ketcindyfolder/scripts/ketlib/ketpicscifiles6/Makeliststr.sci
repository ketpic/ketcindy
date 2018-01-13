// 09.10.21

function Out=Makeliststr(L)
  Out='list(';
  for I=1:length(L)
    Dt=L(I);
    if type(Dt)==1
      if length(Dt)==1
        Dts=string(Dt);
      else
        Dts='[';
        for J=1:size(Dt,1)
          for K=1:size(Dt,2)
            Dts=Dts+string(Dt(J,K));
            if K<size(Dt,2)
              Dts=Dts+',';
            end;
          end;
          if J<size(Dt,1)
            Dts=Dts+';';
          else
            Dts=Dts+']';
          end;
        end;
      end;
    end;
    if type(Dt)==10
      Dts=Prime()+Dt+Prime();
    end;
    if type(Dt)==15
      Dts=Makeliststr(Dt);
    end;
    Out=Out+Dts;
    if I<length(L)
      Out=Out+',';
    else
      Out=Out+')';
    end;
  end;
endfunction;

