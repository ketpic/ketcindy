function Mawarikomi(varargin)
  FL='default';
  haba='10cm';
  Nargs=length(varargin);
  if Nargs>0 
    haba=varargin(1);
    if Nargs>=2
      FL=varargin(2);
      if FL==''
        FL='tmp.tex'
      end
    end
  end
  StrM=[
        '\begin{mawarikomi}%',...
        '%<1>[5](0,0)%',...
        '{'+haba+'}{%',...
        '',...
        '}',...
        '',...
        '',...
        '\end{mawarikomi}'...
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
    mclose(Fid);
  end
endfunction

