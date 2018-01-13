function Setpen(Width)
  global Wfile FID PenThick PenThickInit;
  PenThick=round(PenThickInit*Width);
  Str='\special{pn '+string(PenThick)+'}%';
  if Wfile=='default'
    mprintf('%s\n',Str);
  else
    mfprintf(FID,'%s\n',Str);
  end
endfunction

