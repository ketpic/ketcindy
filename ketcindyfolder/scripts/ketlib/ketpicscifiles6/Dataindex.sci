//
// 08.05.31

function Ndm=Dataindex(P)
  //  %inf;%inf  -> end
  Ndm=[];
  if P==[] return; end
  N1=1;
  Flg=0;
  for J=1:size(P,1)
    if P(J,1)==%inf
      Ndm=[Ndm;N1,J-1];
      N1=J+1;
      if P(N1,1)==%inf
        Flg=1;
        break;
      end
    end
  end
  if Flg==0
    Ndm=[Ndm;N1,size(P,1)];
  end
endfunction

