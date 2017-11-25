// s:2014.10.10
// e:2014.12.14  ( for 3d )
// e:2015.10.29  ( endmark //// )

function WriteOutData(varargin)
  global Fnameout
  Nargs=length(varargin);
  if modulo(Nargs,2)==0 then
    Fname=Fnameout;
    Nst=1;
  else
    Fname=varargin(1);
    Nst=2;
  end;
  Fid=mopen(Fname,'w');
  for N=Nst:2:Nargs
    Gname=varargin(N);
    mfprintf(Fid,'%s\n',Gname+"//");
    Gdata=varargin(N+1);
    Gdata=Flattenlist(Gdata);
    for K=1:length(Gdata)
      GL=Dividegraphics(Gdata(K));
      for J=1:length(GL)
        mfprintf(Fid,'%s\n',"start//");
        Str="";
        for I=1:Numptcrv(GL(J))
          Pt=Ptcrv(I,GL(J));
          if length(Str)>0 then
            Str=Str+","
          end;
          if length(Pt)<3   //  2014.12.14
            Str=Str+msprintf("[%5.4f,%5.4f]",Pt(1),Pt(2));
          else
            Str=Str+msprintf("[%5.4f,%5.4f,%5.4f]",Pt(1),Pt(2),Pt(3));
          end;
          if length(Str)>80 then
            mfprintf(Fid,'%s\n',"["+Str+"]//");
            Str="";
          end
        end
        if length(Str)>0 then
          mfprintf(Fid,'%s\n',"["+Str+"]//");
        end
        if N==Nargs-1 & K==length(Gdata) & J==length(GL) then  // 15.10.29
//          mfprintf(Fid,'%s\n',"end////");
          mfprintf(Fid,'%s\n',"end//");
        else
          mfprintf(Fid,'%s\n',"end//");
        end;
      end
    end
  end
  mfprintf(Fid,'%s\n',"//");
  mclose(Fid);
endfunction;
