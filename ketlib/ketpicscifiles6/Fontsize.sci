function Fontsize(Ookisa)
  global Wfile FID;
  Str='%';
  Ucode=ascii(Ookisa);
  S=char(Ucode(1));
  if S=='n'
    Str='\normalsize%';
  end
  if S=='s'
    if length(Ucode)==1
      Tmp='';
    else
      Tmp=char(Ucode(2));
    end
    if Tmp=='s'
      Str='\scriptsize%';
    else
      Str='\small%';
    end
  end
  if S=='f'
    Str='\footnotesize%';
  end
  if S=='t'
    Str='\tiny%';
  end
  if S=='l'
    Str='\large%';
  end
  if S=='L'
    if length(Ucode)==1
      Tmp='a';
    else
      Tmp=char(Ucode(2));
    end
    if Tmp=='a'
      Str='\Large%';
    else
      Str='\LARGE%';
    end
  end
  if S=='h'
    Str='\huge%';
  end
  if S=='H'
    Str='\Huge%';
  end
  if Wfile=='default'
    mprintf('%s\n',Str);
  else
    mfprintf(FID,'%s\n',Str);
  end
endfunction

