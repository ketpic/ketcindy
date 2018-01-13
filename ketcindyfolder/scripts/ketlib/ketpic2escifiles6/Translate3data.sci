// 08.08.15
// 15.04.12

function Out=Translate3data(varargin)
  Nargs=length(varargin);
  Pd3=varargin(1);
  Pd3=Flattenlist(Pd3);  // 15.04.12
  Mv=varargin(2);
  if type(Mv)==1 & length(Mv)==1
    Mv=[varargin(2),varargin(3),varargin(4)];
  end;
//  if Mixtype(Pd3)==1  // 15.04.12 from
//    Pd3=MixS(Pd3);
//  elseif Mixtype(Pd3)==3
//    Tmp=[];
//    for I=1:Mixlength(Pd3)
//      Tmp=Mixjoin(Tmp,Mixop(I,Pd3));
//    end;
//    Pd3=Tmp;
//  end;
  Out=[];
  for I=1:length(Pd3)
     PD=Op(I,Pd3);
     Ans=[];
     for J=1:size(PD,1)
       P=PD(J,:);
       Tmp=P+Mv;;
       Ans=[Ans;Tmp];
     end;
     Out=Mixadd(Out,Ans);
   end;
   if length(Out)==1
     Out=Op(1,Out);
   end;
endfunction

