// 15.01.01

function Out=Bezier(varargin)
  Nargs=length(varargin);
  Ptlist=varargin(1);
  Ctrlist=varargin(2);
  Num=10;
  for J=3:Nargs
    Tmp=varargin(J);
    K=mtlb_findstr(Tmp,'=');
    Tmp1=strsplit(Tmp,[K-1,K]);
    Tmp2=ascii(Tmp1(1,1));
    Lhs=char(Tmp2(1));
    if Lhs=="N" then
       Num=evstr(Tmp1(3,1));
    end;
  end;
  if length(Num)==1
    Num=Num*ones(1:length(Ctrlist))
  end;
  Out=[];
  for ii=1:length(Ctrlist)
    Tmp1=[Ptlist(ii),Ptlist(ii+1)];
    Tmp2=Ctrlist(ii);
    if ii==1 then
      St=0
    else
      St=1
    end;
    for J=St:Num(ii)
      Tmp=Bezierpt(J/Num(ii),Tmp1,Tmp2);
      Out=[Out;Tmp];
    end;
  end;
endfunction;
