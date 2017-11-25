// 08.10.07
// 08.10.27
// 09.06.02

function AnsL=Droppoint(varargin)
  Nargs=length(varargin);
  Curve=varargin(1);
  Eps=0.02;
  if Nargs>=2
    Eps=varargin(2);
  end;
  AnsL=[%inf,%inf];
  for I=1:size(Curve,1)
    P=Curve(I,:);
    if P(1)~=%inf
      Tmp=AnsL(size(AnsL,1),:);
      if norm(P-Tmp)>Eps
        AnsL=[AnsL;P];
      end;
    else
      AnsL=[AnsL;%inf,%inf];
    end;
  end;
  AnsL=AnsL(2:size(AnsL,1),:);
  Tmp=Ptend(Curve);
  AnsL=[AnsL(1:size(AnsL,1)-1,:);Tmp];
endfunction;

