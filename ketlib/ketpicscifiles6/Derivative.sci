// 09.10.04
// 09.10.05
// 09.10.06
// 14.10.24  numderivative used after 5.5

function Out=Derivative(varargin)
  Nargs=length(varargin);
  Out=[];
  Fs=varargin(1);
  Vv=varargin(2);
  Np=3;
  if type(Vv)==10
    Prstr=strsubst(Vv,'[','(');
    Prstr=strsubst(Prstr,']',')');
    Tmp=part(Prstr,1);
    if Tmp~='('
      Prstr='('+Prstr+')';
    end;
    deff('Out=Tmpfun'+Prstr,'Out='+Fs);
    Fs='Tmpfun'+Prstr;
    Vv=varargin(Np);
    Np=Np+1;
  end;
  Nd=[];
  if Np<=Nargs
    Nd=varargin(Np);
  end;
  Js=mtlb_findstr(Fs,'(');
  JL=mtlb_findstr(Fs,',');
  Je=mtlb_findstr(Fs,')');
  Sep=[Js(1),JL,Je];
  Fse=Fs;
  for I=1:length(Vv)
    J1=Sep(I)+1;
    J2=Sep(I+1)-1;
    Tmp1=part(Fs,J1:J2);
    Tmp2='X_'+string(I);
    Fse=strsubst(Fse,Tmp1,Tmp2);
  end;
  function Ans=Tmpf(W)
    X1=W(1);
    if length(W)>1
      X2=W(2);
    else;
      X2=%inf;
    end;
    if length(W)>2
      X3=W(3);
    else
      X3=%inf;
    end;
    Tmp=Assign(Fse,'X_1',X1,'X_2',X2,'X_3',X3);
    Ans=evstr(Tmp)';
  endfunction;
  Tmp1=getversion("scilab");
  if Tmp1(1)*10+Tmp1(2)>=55 then
    Out=numderivative(Tmpf,Vv')';
  else
    Out=derivative(Tmpf,Vv')';
  end
  if Nd~=[]
    Out=Out(Nd,:)
  end;
endfunction;
