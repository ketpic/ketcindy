// s : 2014.06.22
// e : 14.09.07

function Out=Openobj(Fnm)
  global OBJFMT NPOINT NNORM OBJSCALE OBJFIGNO Wfile FID OBJJOIN
  OBJFMT= "%7.4f";
  NPOINT= 0;
  NNORM=0;
  OBJSCALE=1;
  OBJFIGNO=0;
  OBJJOIN=0;   // 140906
  if Fnm =='' then
    Wfile='default';
  else
    errcatch(4,"continue"); 
    Tmp=FID;
    if iserror(4) then
      FID=[];
      errclear(4);
    end;
    if FID~=[] then
      mclose(FID);
      FID=[];
    end
    errcatch(4,"kill"); 
    if length(mtlb_findstr(Fnm,".obj"))==0
      Fnm=Fnm+".obj";
    end;
    FID=mopen(Fnm,'w');
    Wfile=Fnm;
    Out=Wfile;
  end
endfunction
