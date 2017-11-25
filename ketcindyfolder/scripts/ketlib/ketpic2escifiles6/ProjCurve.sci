// 08.07.11
// 08.10.07
// 09.06.02
// 09.08.23

function AnsL=ProjCurve(Curve)
  global PHI THETA;
  Eps=10^(-6);
  AnsL=[]; // Added
  SP=sin(PHI); CP=cos(PHI);
  ST=sin(THETA); CT=cos(THETA);
  for I=1:size(Curve,1)
    P=Curve(I,:);
    x=P(1); y=P(2); z=P(3);
    if x~=%inf
      Xz=-x*SP+y*CP;
      Yz=-x*CP*CT-y*SP*CT+z*ST;
      Tmp=[Xz,Yz];
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

