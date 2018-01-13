// 09.12.25

function Out=Doscaling(G)
  global LOGX LOGY SCALEX SCALEY;
  GLg=G;
  if LOGX==1
    GLg=[log10(G(:,1)),GLg(:,2)];
  end;
  if LOGY==1
    GLg=[GLg(:,1),log10(G(:,2))];
  end;
  Out=[SCALEX*GLg(:,1),SCALEY*GLg(:,2)];
endfunction

