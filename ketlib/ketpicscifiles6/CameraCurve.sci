// 08.08.12
// 08.10.07
// 09.06.02

function AnsL=CameraCurve(Curve)
  Eps=10^(-6);
  for I=1:size(Curve,1)
    P=Curve(I,:);
    x=P(1); y=P(2); z=P(3);
    if x~=%inf
      Tmp=Perspt(P);
       if I==1
         AnsL=[Tmp];
      else
        Tmp1=AnsL(size(AnsL,1),:);
        if Tmp1(1)==%inf | norm(Tmp-Tmp1)>Eps
          AnsL=[AnsL;Tmp];
        end;
      end;
    else
      AnsL=[AnsL;%inf,%inf];
    end;
  end;
endfunction
