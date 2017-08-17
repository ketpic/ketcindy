// 08.09.26
// 09.09.21
// 09.09.26
// 09.10.01
// 09.10.03
// 09.10.05
// 09.10.08
// 09.10.09  ( format=20)
// 09.10.15  ( added Assign('') : reset
// 09.10.17  ( Matrix added, ? -> number returned)
// 09.10.21  ( list supported with Makeliststr )
// 14.10.04  format=12
// 14.12.11  only replaced when variable name
// 14.12.28  debugged  ( tmp2, ` )
// 15.02.18  debugged  ( for list of string )
// 15.02.19  debugged
// 15.04.18  debugged

function Out=Assign(varargin)
  global ASSIGNLIST;
  Curfmt=format();
  format(12);  // 14.10.04
  Nargs=length(varargin);
  if Nargs==0
    ASSIGNLIST=list('`',Prime());
    Out=ASSIGNLIST;
    format(Curfmt(2));
    return;
  end;
  L=list('`',char(39));
  NL=length(L);
  if modulo(Nargs,2)==0
    for I=1:Nargs
      L(I+NL)=varargin(I);
    end;
    ASSIGNLIST=L;
    Out=L;
    format(Curfmt(2));
    return;
  end;
  if Nargs==1
    Fnstr=varargin(1);
    if Fnstr==''
      L=ASSIGNLIST;
      Out=[];
      for I=1:2:length(L)
        Tmp1=L(I);
        Tmp2=L(I+1);
        if length(Tmp2)==1
          Tmp3=string(Tmp2);
        else
          Tmp3='[';
          for J=1:length(Tmp2)
            Tmp3=Tmp3+string(Tmp2(J));
            if J<length(Tmp2)
              Tmp3=Tmp3+',';
            end;
          end;
          Tmp3=Tmp3+']';
        end;
        Out=[Out,Tmp1+'='+Tmp3];
      end;
      format(Curfmt(2));
      return;
    end;
    if part(Fnstr,1)=='?'
      Tmp=strsplit(Fnstr,1);
      Fnstr=Tmp(2);
      for I=1:2:length(ASSIGNLIST)
        Tmp=ASSIGNLIST(I);
        if Tmp==Fnstr
          Out=Mixjoin(I,ASSIGNLIST(I+1));
          format(Curfmt(2));
          return;
        end;
      end;
      Out='Not found';
      format(Curfmt(2));
      return;
    end;                          //
    L=ASSIGNLIST;
  else
    if type(varargin(2))==1
      Fnstr=varargin(Nargs);
      for I=1:Nargs-1
        L(I)=varargin(I);
      end;
    else
      Fnstr=varargin(1);
      for I=2:Nargs
        L(I-1)=varargin(I);
      end;
    end;
  end;
  Tmp3=Fnstr; // 15.04.18
  for I=1:2:length(L)
    Vname=L(I);
    Val=L(I+1);
    if Vname=="`"    // 14.12.28
      Tmp3=strsubst(Tmp3,Vname,Val);
      continue
    end;
    if type(Val)==1
      if size(Val,1)==1 & size(Val,2)>1 // 15.04.18
        for K=1:length(Val)
          Tmp=Vname+'('+string(K)+')';
          if mtlb_findstr(Tmp3,Tmp)~=[]
            if type(Val(K))==1
              Tmp1='('+string(Val(K))+')';
            else
              Tmp1=Val(K);
            end;
            Tmp3=strsubst(Tmp3,Tmp,Tmp1);
          end;
        end;
      else
        for J=1:size(Val,1)
          for K=1:size(Val,2)
            Tmp=Vname+'('+string(J)+','+string(K)+')';
            if mtlb_findstr(Tmp3,Tmp)~=[]
              if type(Val(J,K))==1
                Tmp1='('+string(Val(J,K))+')';
              else
                Tmp1=Val(J,K);
              end;
              Tmp3=strsubst(Tmp3,Tmp,Tmp1);
            end;
          end;
        end;
      end;
      if length(Val)==1
        Rep=string(Val);
      else
        Rep='[';
        for J=1:size(Val,1)
          for K=1:size(Val,2)
            Rep=Rep+string(Val(J,K));
            if K<size(Val,2)
              Rep=Rep+',';
            end;
          end;
          if J<size(Val,1)
            Rep=Rep+';';
          else
            Rep=Rep+']';
          end;
        end;
      end;
      Tmp1='('+Rep+')';
    end;
    if type(Val)==10
      Tmp1=Val;
    end;
    if type(Val)==15
      Tmp1=Makeliststr(Val);
    end;
    Notvar=[48:57,65:90,97:122];
    for K=1:size(Tmp3,2)
      Tmp2=Tmp3(K);
      if length(Tmp2)>0 then
        Flist=mtlb_findstr(Tmp2,Vname);
      else
        Flist=[];
      end
      if length(Flist)==0 then
        Tmp3(K)=Tmp2;  // 15.04.18
        continue
      end
      Str=part(Tmp2,1:(Flist(1)-1));
      for I=1:length(Flist)
        Flg=0;
        J=Flist(I);
        if J>1 then
          Tmp=ascii(part(Tmp2,J-1));
          if Member(Tmp,Notvar) then
            Flg=1;
          end;
        end
        if J+length(Vname)-1<length(Tmp2) then  //  15.04.18
          Tmp=ascii(part(Tmp2,J+length(Vname))); // 15.04.18
          if Member(Tmp,Notvar) then
            Flg=1;
          end;
        end;
        if Flg==0 then
          Str=Str+Tmp1;
        else
          Str=Str+Vname;
        end;
        if I<length(Flist) then
          Tmp=Flist(I+1)-1;
        else
          Tmp=length(Tmp2);
        end;
        Str=Str+part(Tmp2,(J+length(Vname)):Tmp);
        Tmp3(K)=Str; // 15.04.18
      end;
    end;
  end;
  Out=Tmp3; // 15.02.18 upto
  format(Curfmt(2));
endfunction;
