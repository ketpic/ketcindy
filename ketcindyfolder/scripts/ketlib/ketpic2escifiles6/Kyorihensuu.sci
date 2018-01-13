function Kyorihensuu(varargin)
  if length(varargin)==0
    FL='default';
  else
    FL=varargin(1);
    if FL==''
      FL='tmp.tex'
    end   
  end
  StrM=[...
    '\newlength{\Width}%',...
    '\newlength{\Height}%',...
    '\newlength{\Depth}%'...
    ];
  if FL~='default'
    Fid=mopen(FL,'w');
    mprintf('%s\n\n','Writing to '+FL);
  end;
  for I=1:size(StrM,2)
    Str=StrM(I);
    mprintf('%s\n',Str);
    if FL~='default'
      mfprintf(Fid,'%s\n',Str);
    end
  end
  if FL~='default'
    mclose(Fid)
  end
endfunction

