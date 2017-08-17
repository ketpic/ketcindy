// 08.05.22
// 08.05.23
// 08.05.26
// 08.05.28
// 10.04.25
// 11.01.05
// 13.10.06  format, debug
// 14.01.20  debugged  (Big data)

function OutL=Readtextdata(varargin)
  OutL=[];
  Nargs=length(varargin);
  Fname=varargin(1);
  Suuji='0123456789.+-';
  Sep='';
  Hajime=[1,1];
  N=%inf;
  R=%inf;
  D=-%inf;  //  11.01.04
  Fmt="%lf";   // 13.10.06
  Flg=0;
  for I=2:Nargs
    Tmp=varargin(I);
    if type(Tmp)==1
      if  Flg==0
        Hajime=Tmp;
        Flg=1
      else
        Owari=Tmp;
      end
    elseif mtlb_findstr(Tmp,'=')~=[]
      execstr(Tmp);
    else
      if part(Tmp,1)=="%"  // 13.10.06
        Fmt=Tmp
      else
        Sep=Tmp;
        if Tmp=='s' Sep=' '; end
        if Tmp==',' Sep=','; end
        if Tmp=='t' Sep=char(9); end
      end
    end
  end
  Owari=Hajime+[N-1,R-1];
  Fid=mopen(Fname,'rb');
  SL=[];
  S='';
  Lsp=0;
  Flg=1;
  Tmp=mgetstr(1,Fid);
  while 1==1 // 2014.01.20
    if Tmp=='' break; end
    C=ascii(Tmp);
    if C>=32 | C==9
      if C==32
        if Flg==1
          Tmp='';
        end
        Flg=1
      else
        Flg=0;
      end
      S=S+Tmp;
      Tmp=mgetstr(1,Fid);
    else
      SL=[SL;S];
      S='';
      Flg=1;
      Tmp=mgetstr(1,Fid);
      if Lsp==0
        if C==10  // LF
          Lsp=1;
        elseif C==13
          if ascii(Tmp)==10
            Lsp=3;  // CR LF
            Tmp=mgetstr(1,Fid);
          else
            Lsp=2;  // CR
          end
        else
          break;
        end
      else 
        if C==10 | C==13
          if Lsp==3
            Tmp=mgetstr(1,Fid);
          end
        else
          break
        end
      end
    end
  end
  mclose(Fid);
  if length(S)>0 then   // 2013.10.06
    SL=[SL;S]
  end
  for I=1:size(SL,1)
    S=SL(I,1);
    if S=='' continue; end
    if mtlb_findstr(Suuji,Strop(1,S))~=[]
      break
    end
  end
  Hajime(1,1)=max(Hajime(1,1),I);
  S=SL(Hajime(1),1);
  if Sep==''
    if length(mtlb_findstr(S,char(9)))~=0
      Sep=char(9);
    elseif length(mtlb_findstr(S,','))~=0
      Sep=',';
    else
      Sep=' ';
    end
  end
  Tmp=mtlb_findstr(S,Sep);
  J=length(Tmp);
  if Tmp(J)~=length(S)
    J=J+1;
  end
  Owari(1,1)=min(size(SL,1),Owari(1));
  Owari(1,2)=min(J,Owari(2));
  S=SL(Owari(1),1);
  while S==''
    Owari(1,1)=Owari(1,1)-1;
    S=SL(Owari(1),1);
  end
  OutL=[];
  for J=Hajime(1):Owari(1)
    S=SL(J,1);
    if S==''
      Tmp=%inf*ones(1,Owari(2)-Hajime(2)+1);
      OutL=[OutL;Tmp];
      continue
    end
    Tmp=Strop(1,S);
    if mtlb_findstr(Suuji+Sep,Tmp)==[]
      continue
    end
    SpL=[0,mtlb_findstr(S,Sep),length(S)+1];
    Data=[];
    for K=Hajime(2):Owari(2)
      Tmp=Strop(SpL(K)+1:SpL(K+1)-1,S);
      Tmp1=msscanf(Tmp,Fmt);  // 13.10.06
      Data=[Data,Tmp1];
    end
    OutL=[OutL;Data];
  end;  
  if D~=-%inf  // 11.01.04
    Data=[];
    for I=1:size(OutL,1)
      Tmp=OutL(I,:);
      if Tmp(1)<=D  // 11.01.04
        Tmp=[%inf,%inf];
      end;
      Data=[Data;Tmp];
    end;
    OutL=Data;
  end;  //
endfunction;
