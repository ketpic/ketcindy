//  08.09.09
//  08.10.08
//  08.12.06
//  08.12.30
//  09.06.03
// 13.10.19 ( __ added to variables )

function [Zval__,Xval__,Yval__]=Makevaltable(MS__)
  Eps__=10^(-6);
  Nargs__=Mixlength(MS__);
  Fstr__=Mixop(1,MS__);
  Tmp__=Mixop(2,MS__);
  Tmp1__=mtlb_findstr(Tmp__,'=');
  Xname__=part(Tmp__,Tmp1__-1);
  Xrange__=evstr(part(Tmp__,Tmp1__+1:length(Tmp__)));
  Tmp__=Mixop(3,MS__);
  Tmp1__=mtlb_findstr(Tmp__,'=');
  Yname__=part(Tmp__,Tmp1__-1);
  Yrange__=evstr(part(Tmp__,Tmp1__+1:length(Tmp__)));
  Tmp__=strsubst(Fstr__,Xname__,'x');
  Fstr__=strsubst(Tmp__,Yname__,'y');
  Tmp__=mtlb_findstr(Fstr__,Xname__);
  if length(Tmp__)==0
    Fstr__=Fstr__+'+0*x';
  end;
  Mdv__=50;
  Ndv__=50;
  if Nargs__>=4
    Tmp__=Mixop(4,MS__);
    if length(Tmp__)>1
      Mdv__=Tmp__(1,1);
      Ndv__=Tmp__(1,2);
    else
      Mdv__=Tmp__
      if Nargs__==4
        Ndv__=Mdv__
      else
        Tmp1__=Mixop(5,MS__);
        if type(Tmp1__)==1 & length(Tmp1__)==1
          Ndv__=Tmp1__;
        else
          Ndv__=Mdv__;
        end
      end
    end
  end
  X1__=Xrange__(1); X2__=Xrange__(2);
  Y1__=Yrange__(1); Y2__=Yrange__(2);
  Dx__=(X2__-X1__)/(Mdv__-1);
  Dy__=(Y2__-Y1__)/(Ndv__-1);
  Xval__=[];  
  Tmp__=X1__;
  while Tmp__<X2__+Eps__
    Xval__=[Xval__,Tmp__];
    Tmp__=Tmp__+Dx__;
  end;
  Yval__=[];
  Tmp__=Y1__;
  while Tmp__<Y2__+Eps__
    Yval__=[Yval__,Tmp__];
    Tmp__=Tmp__+Dy__;
  end;
  I__=1;
//  x=Xval;
//  for y=Yval
//    Tmp=evstr(Fstr);
//    Zval(I,:)=Tmp;
//    I=I+1;
//  end;
  for y=Yval__
    J__=1;
    for x=Xval__
      Zval__(I__,J__)=evstr(Fstr__);
      J__=J__+1;
    end;
    I__=I__+1;
  end;
endfunction;

