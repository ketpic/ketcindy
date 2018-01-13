// 2010.04.27

function Writetextdata(varargin)
  Fname=varargin(1);
  Mt=varargin(2);
  D=-1;
  for I=3:length(varargin)
    Tmp=varargin(I);
    if mtlb_findstr(Tmp,'=')~=[]
      execstr(Tmp);
    end;
  end;  
  Str='';
  for J=1:size(Mt,2)
    Str=Str+'x'+string(J);
    if J<size(Mt,2)
      Str=Str+',';
    end;
  end;
  if Fname~=''
    Fid=mopen(Fname,'w');
    mfprintf(Fid,'%s\n',Str);
  else
    mprintf('%s\n',Str);
  end;
  for I=1:size(Mt,1)
    Str='';
    for J=1:size(Mt,2)
      Dt=Mt(I,J);
      if Dt==%inf
        Dt=D;
      end;
      Str=Str+string(Dt);
      if J<size(Mt,2)
        Str=Str+',';
      end;
    end;
    if Fname~=''
      mfprintf(Fid,'%s\n',Str);
    else
      mprintf('%s\n',Str);
    end; 
  end;
  if Fname~=''
    mclose(Fid);
  end;
endfunction;
