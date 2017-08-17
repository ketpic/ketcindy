// s : 2014.06.22

function Closeobj()
  global Wfile FID;
  if Wfile~='default' then
    mclose(FID);
    FID=[]; 
  end;
  Wfile='default';
endfunction
