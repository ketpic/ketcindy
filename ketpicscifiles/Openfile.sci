
// 
// 10.01.10  filename written
// 13.05.20  openfile error tackled
//           creator and date recorded
// 13.11.01  Beginpicture joined optionally

function Openfile(varargin)
  global Wfile FID;

  function Out=Datecount(F)
    Tmp1=fileinfo(F);
    Tmp=getdate(Tmp1(7));
    Year=Tmp(1);
    Sec=((Tmp(4)-1)*24+Tmp(7))*3600+Tmp(8)*60+Tmp(9);
    Out=[Year,Sec];
  endfunction

  function Out=Datestr(F)
    if F~="" then
      Tmp1=fileinfo(F);
      Tmp=getdate(Tmp1(7));
    else
      Tmp=getdate();
    end;
    Year=Tmp(1);
    Month=Tmp(2);
    Day=Tmp(6);
    Hour=Tmp(7);
    Min=Tmp(8);
    D=string(Year)+"-"+string(Month)+"-"+string(Day);
    T=string(Hour)+":"+string(Min);
    Out=D+" "+T;
  endfunction

  File=varargin(1);
  Bflg=0;
  Creator='';
  Cflg=0;
  Nargs=length(varargin);
  for N=2:Nargs
    Tmp=varargin(N);
    K=mtlb_findstr(Tmp,"=");
    if length(K)>0 then
      Creator=part(Tmp,(K+1):length(Tmp));
	  Cflg=1;
    else
      Bflg=1;
      Unitstr=Tmp
    end
  end;
  Recentf='';
  Tmp1=dir("*.sce");
  Files=Tmp1(2);
  if size(Files,1)>0 then
    Recentf=Files(1,:);
    Dt=Datecount(Recentf);
    for J=2:size(Files,1)
      F=Files(J,:);
      D=Datecount(F);
      if D(1)~=Dt(1) then
        if D(1)>Dt(1) then
          Recentf=F;
          Dt=D;
        end
        continue 
      end
      if D(2)>Dt(2) then
        Recentf=F;
        Dt=D;
      end
    end;
  end;
  StrW="%%% "+File+" "+Datestr("")
  StrC="%%% "+Creator;
  if Cflg==0 then
    if Recentf~="" then
      StrC=StrC+Recentf+" "+Datestr(Recentf);
 	end
  end
  if File =='' then
    Wfile='default';
  else
    errcatch(4,"continue"); // 2013.05.19 from
    Tmp=FID;
    if iserror(4) then
      FID=[];
      errclear(4);
    end;
    if FID~=[] then
      mclose(FID);
      FID=[];
    end
    errcatch(4,"kill"); // 2013.05.19 upto
    FID=mopen(File,'w');
    Wfile=File;
  end
  if Wfile=='default'    
    mprintf('%s\n%s\n',StrW,StrC);
  else
    mfprintf(FID,'%s\n%s\n',StrW,StrC);
  end
  if Bflg==1 then
    Beginpicture(Unitstr)
  end
endfunction
