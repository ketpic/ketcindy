// 
// 09,12.05
// 09.12.06
// 09.12.07
// 09.12.20

function Texcom(Meirei)
  global Wfile FID;
  if Meirei=='\thinlines'
    Setpen(1);
    return
  end
  if Meirei=='\thicklines'
    Setpen(2);
    return
  end
  if Meirei=='\Thicklines'
    Setpen(3);
    return
  end;

  if Meirei==''  // 09.12.07
    Tmp=[];
  else
    Tmp=mtlb_findstr(Meirei,'newline');
  end;
  if length(Tmp)>0
    if Wfile=='default'
      mprintf('%s\n','');
    else
      mfprintf(FID,'%s\n','');
    end;
    return;
  end;
  if Wfile=='default'
    mprintf('%s%s\n',Meirei,'%');
  else
    mfprintf(FID,'%s%s\n',Meirei,'%');
  end
endfunction

