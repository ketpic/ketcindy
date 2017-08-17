// 14.10.10
// 14.12.14  for 3d
// 15.01.03 changed ("start","end")
// 15.10.24 in case of list-length==1

function Out=ReadOutData(varargin)
  global Fnameout
  if length(varargin)==0 then
    Fname=Rnameout;
  else
    Fname=varargin(1);
  end
  Fid=mopen(Fname,"rb");
  Gstr=[];
  Str="";
  Flg=1;
  Tmp=mgetstr(1,Fid);
  while 1==1
    if Tmp=="" then
      break;
    end;
    C=ascii(Tmp);
    if Tmp=="/"|C==13|C==10 then// / CR,LF
      if Flg==1 then
        if part(Str,1:5)=="start" then
          Str="Tmp=[];";
        else
          if part(Str,1:3)=="end" then
            if Flg3d==0 then // 2014.12.14
              Str=Varname+"($+1)=Listplot(Tmp);";
            else
              Str=Varname+"($+1)=Spaceline(Tmp);";
            end
          else
            if part(Str,1:2)=="[[" then 
              Str="Tmp=[Tmp,"+Str+"];";
            else
              Varname=Str;
              Str=Varname+"=list();"
              Flg3d=-1;
            end;
          end;
        end;
        if Flg3d==-1 then // 2014.12.14
          Tmp1=mtlb_findstr(Str,"[[");
          if length(Tmp1)>0 then
            Tmp2=mtlb_findstr(Str,"]");
            Tmp3=part(Str,Tmp1:Tmp2(1));
            Tmp4=mtlb_findstr(Tmp3,",")
            if length(Tmp4)==2 then
              Flg3d=1;
            else
              Flg3d=0;
            end
          end
        end
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
  Out=[];  // 15.10.24 from
  Var="";
  Ctr=0;
  for J=1:size(Gstr,1)
    St=Gstr(J,1);
    Out=[Out;St];
    Tmp=strsplit(St,"=");
    Tmp1=Tmp(1,1);
    Tmp2=Tmp(2,1);
    if grep(Tmp2,"list()") then
      if Ctr==1 then
        Out=[Out;Var+"="+Var+"(1)"];
      end;
      Var=Tmp1;
      Ctr=0;
    end;
    if grep(Tmp1,"$") then
      Ctr=Ctr+1;
    end;
  end
  if Ctr==1 then
    Out=[Out;Var+"="+Var+"(1)"];
  end; // 15.10.24 upto
  Out;
endfunction;
