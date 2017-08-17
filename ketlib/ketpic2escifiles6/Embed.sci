// 09.09.25
// 09.11.21
// 09.11.26

function Out=Embed(varargin)
  Nargs=length(varargin);
  Pd3=varargin(1);
  if Mixtype(Pd3)==1
    Pd3=list(Pd3);
  elseif Mixtype(Pd3)==3
    Tmp=list();
    for I=1:length(Pd3)
      Tmp=Mixjoin(Tmp,Pd3(I));
    end;
    Pd3=Tmp;
  end;
  Tmpf=varargin(2);
  if type(Tmpf)==10
    Tmp=varargin(3);
    Tmp1=strsubst(Tmp,'[','(');
    Vstr=strsubst(Tmp1,']',')');
    deff('Z=Tmpfn'+Vstr,'Z='+Tmpf);
  else
    Tmpfn=Tmpf;
  end;
  Out=list();
  for I=1:length(Pd3)
     PD=Pd3(I);
     Ans=[];
     for J=1:size(PD,1)
       P=PD(J,:);
       Tmp=Tmpfn(P(1),P(2));
       Ans=[Ans;Tmp];
     end;
     Out($+1)=Ans;
   end;
   if length(Out)==1
     Out=Out(1);
   end;
endfunction;

