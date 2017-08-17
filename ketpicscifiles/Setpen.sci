function Setpen(Width)
  global Wfile FID PenThick PenThickInit;
  PenThick=round(PenThickInit*Width);
  Str='\linethickness{'+string(PenThick/1000)+'in}%';
  if Wfile=='default'
    mprintf('%s\n',Str);
  else
    mfprintf(FID,'%s\n',Str);
  end
endfunction

