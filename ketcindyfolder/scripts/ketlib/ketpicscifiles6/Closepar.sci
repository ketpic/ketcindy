// 08.05.31

function Closepar()
  global Wfile FID
  S='\end{minipage}'
  if Wfile=='default'
    mprintf('%s\n','%');
    mprintf('%s',S);    
  else
    mfprintf(FID,'%s\n','%');
    mfprintf(FID,'%s',S);    
  end
  Closephr();
endfunction

