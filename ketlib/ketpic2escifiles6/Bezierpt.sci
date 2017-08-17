// 15.01.01
// 15.02.08   for 3d

function Out=Bezierpt(t,Ptlist,Ctrlist)
  if length(Ptlist)==6 then // 3d 15.02.08
    P0=Ptlist(1:3);
    P3=Ptlist(4:6);
    P1=Ctrlist(1:3);
    if length(Ctrlist)==3 then
      P2=P3;
      flg3=0;
    else
      P2=Ctrlist(4:6);
      flg3=1;
    end;
  else
    P0=Ptlist(1:2);
    P3=Ptlist(3:4);
    P1=Ctrlist(1:2);
    if length(Ctrlist)==2 then
      P2=P3;
      flg3=0;
    else
      P2=Ctrlist(3:4);
      flg3=1;
    end;
  end;
  P4=(1-t)*P0+t*P1;
  P5=(1-t)*P1+t*P2;
  P6=(1-t)*P2+t*P3;
  P7=(1-t)*P4+t*P5;
  P8=(1-t)*P5+t*P6;
  P9=(1-t)*P7+t*P8;
  if flg3==0 then
    Out=P7;
  else
    Out=P9;
  end;
endfunction;
