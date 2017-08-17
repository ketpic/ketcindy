// s:2014.09.16

function WritetoCindy(varargin)
  global Fnametxt
  GnameV=list();
  for J=1:length(varargin)
    Tmp=varargin(J);
    for K=1:size(Tmp,2)
      GnameV($+1)=Tmp(1,K);
    end
  end;
  Fid=mopen(Fnametxt,'w');
  for Nv=1:length(GnameV)
    Gname=GnameV(Nv);
    Tmp=evstr(Gname);
    GL=Dividegraphics(Tmp);
    Lnst="";
    for J=1:length(GL)
      G=GL(J);
      Gn=Gname+"No"+string(J);
      mfprintf(Fid,'%s\n',Gn+"=[];//");
      for K=1:Numptcrv(G)
        Pt=Ptcrv(K,G);
        if length(Lnst)==0
          Lnst=Gn+"=concat("+Gn+",[";
        end;
        Tmp=msprintf("[%6.4f,%6.4f]",Pt(1),Pt(2));
        Lnst=Lnst+Tmp;
        if length(Lnst)>80 | K==Numptcrv(G) 
          Lnst=Lnst+"]);//";
          mfprintf(Fid,'%s\n',Lnst);
          Lnst="";
        else
          Lnst=Lnst+","; 
        end; 
      end;
      Str="Goutdatalist=Append(Goutdatalist,"+Gn+");//";
      mfprintf(Fid,'%s\n',Str);
    end;
  end;
  mclose(Fid);
endfunction:
