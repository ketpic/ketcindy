// 08.08.12
// 08.10.28

function CL=Projpers(varargin)
  Nargs=length(varargin);
  Flg=0;
  if Nargs==1 & Mixtype(varargin(1))==1
    Flg=1;
  end;
  CL=[];
  for N=1:Nargs
    Crv=varargin(N);
    if Mixtype(Crv)==1
      Tmp=CameraCurve(Crv);
      CL=Mixadd(CL,Tmp);
    else
      if Mixtype(Crv)==3
        ObjL=[];
        for I=1:Mixlength(Crv)
          Tmp1=Mixop(I,Crv);
          if Mixtype(Tmp1)==1
            ObjL=Mixadd(ObjL,Tmp1);
          else
            ObjL=Mixjoin(ObjL,Tmp1);
          end;
        end;
        Crv=ObjL;
      end;
      for J=1:Mixlength(Crv)
        Tmp=CameraCurve(Mixop(J,Crv));
        CL=Mixadd(CL,Tmp);
      end
    end
  end
  if Mixlength(CL)==1 & Flg==1
    CL=Mixop(1,CL);
  end  
endfunction

