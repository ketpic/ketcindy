// 08.05.31
// 10.12.04
// 16.12.05 to make it a closed curve

function AnsL=Enclosing(varargin)
  global MilliIn;
  Eps=10^(-7); // 12.05
  Nargs=length(varargin);
  P=varargin(1);
  if Mixtype(P)==2
    Tmp=Op(1,P);
    if type(Tmp)~=1 | length(Tmp)~=1
      AnsL=EnclosingS(P,varargin(2:Nargs));
	  AnsL=Joincrvs(AnsL) // 10.12.04
    end
  end;
  Tmp1=Op(1,AnsL);
  Tmp2=Op(size(AnsL,1),AnsL);
  if norm(Tmp2-Tmp1)>Eps then // 12.05
    AnsL=[AnsL;Tmp1];
  end;
endfunction

