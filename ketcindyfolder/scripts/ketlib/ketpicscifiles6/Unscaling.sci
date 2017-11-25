function Out=Unscaling(G)
  global LOGX LOGY SCALEX SCALEY;
  GLg=[G(:,1)/SCALEX,G(:,2)/SCALEY];
  Out=GLg;
  if LOGX==1
    Out=[10^(GLg(:,1)),GLg(:,2)];
  end;
  if LOGY==1
    Out=[GLg(:,1),10^(GLg(:,2))];
  end;
endfunction;

