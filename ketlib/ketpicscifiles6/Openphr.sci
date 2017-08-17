// 08.05.31

function Openphr(Str)
  global Wfile FID
  S='\def'+Str+'{%';
  if Wfile=='default'
    mprintf('%s\n',S);
  else
    mfprintf(FID,'%s\n',S);
  end
endfunction

