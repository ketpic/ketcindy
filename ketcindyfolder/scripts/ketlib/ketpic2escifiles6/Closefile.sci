//
// 13.05.19  openfile error tackled
// 13.11.01  Endpicture joined optionally
// 13.11.05  debugged

function Closefile(varargin)
  global Wfile FID;
  if length(varargin)>=1 then
    Pa=varargin(1);
    if type(Pa)==10 then
      if Pa=="1" then  // 2013.11.05
        Endpicture(1)
      end;
      if Pa=="0" then
        Endpicture(0)
      end  //
    end
  end
  if Wfile~='default' then
    mclose(FID);
    FID=[]; // 2013.05.19
  end
  Wfile='default';
endfunction
