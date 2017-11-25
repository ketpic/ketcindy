// s:2014,09.08
// e:2014.09.26
// e:2014.10.07  debugged, code changed
// e:2014.10.08  CR | LF

function Out=ReadfromCindy(Fname)
  Fid=mopen(Fname,"rb");
  Gline=list();
  Gpt=list();
  Gstr=[];
  Str="";
  Flg=1;
  Tmp=mgetstr(1,Fid);
  while 1==1
    if Tmp=="" then
      if Flg==1 then
        Gstr=[Gstr;Str];
        Str="";
        Flg=1;
      end;
      break;
    end
    C=ascii(Tmp);
    if C==13|C==10 then// CR,LF
      if Flg==1 then
        Gstr=[Gstr;Str];
        Str="";
        Flg=0;
      end;
    else
      Str=Str+Tmp;
      Flg=1;
    end;
    Tmp=mgetstr(1,Fid);
  end;
  mclose(Fid);
  Out=Gstr;
endfunction;
