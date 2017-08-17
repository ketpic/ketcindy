// s: 2014.09.07

function Objname()
  global OBJFIGNO  OBJJOIN
  if OBJJOIN==0 then
    OBJFIGNO=OBJFIGNO+1;
    Gname="ketfig"+string(OBJFIGNO);
    Printobjstr("# "+Gname);
    Printobjstr("g "+Gname);
  end;
endfunction
