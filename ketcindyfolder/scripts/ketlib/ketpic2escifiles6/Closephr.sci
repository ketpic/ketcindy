// 08.05.31

function Closephr()
  global Wfile FID;
  if Wfile=='default'
    mprintf('%s\n','%');
    mprintf('%s\n','}%');
  else
    mfprintf(FID,'%s\n','%');
    mfprintf(FID,'%s\n','}%');
  end
endfunction

