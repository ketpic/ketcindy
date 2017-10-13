function CalcHeight(Hoko,Moji)
  global Wfile FID;
  D=0;
  Tmp=ascii(Hoko);
  H=char(Tmp(1));
  Str=['\settoheight{\Height}{'+Moji+'}'];
  Str=[Str,'\settodepth{\Depth}{'+Moji+'}'];
  if H=='n'
    Str=[Str,'\setlength{\Height}{\Depth}'];
  end
  if H=='s'
    Str=[Str,'\setlength{\Height}{-\Height}'];
  end
  if H=='c'
    Str=[Str,'\setlength{\Height}{-0.5\Height}'];
    Str=[Str,'\setlength{\Depth}{0.5\Depth}'];
    Str=[Str,'\addtolength{\Height}{\Depth}'];
  end
  if Wfile=='default'
    for I=1:size(Str,2)
      mprintf('%s',Str(I));
    end
    mprintf('%s\n','%');
  else
    for I=1:size(Str,2)
      mfprintf(FID,'%s',Str(I));
    end
    mfprintf(FID,'%s\n','%');
  end
endfunction

