// s : 2014.06.22

function Printobjstr(Str)
  global Wfile FID;
  if Wfile=='default' then
    mprintf('%s\n',Str);
  else
    mfprintf(FID,'%s\n',Str);
  end
endfunction
