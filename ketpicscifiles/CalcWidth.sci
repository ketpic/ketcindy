function CalcWidth(Hoko,Moji)
  global Wfile FID
  D=0;
  Tmp=ascii(Hoko);
  H=char(Tmp(2));
  if H=='e'
    D=0; 
  end
  if H=='w'
    D=-1.0;
  end
  if H=='c'
    D=-0.5;
  end
  Str1='\settowidth{\Width}{'+Moji+'}';
  Tmp=string(D);
  Str2='\setlength{\Width}{'+Tmp+'\Width}';
  if Wfile=='default'
    mprintf('%s',Str1);
    mprintf('%s%s\n",Str2,'%');
  else
    mfprintf(FID,'%s',Str1);
    mfprintf(FID,'%s%s\n",Str2,'%');
  end
endfunction

