//  Copyright (C)  2021  Setsuo Takato, KETCindy Japan project team
//
//This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation; either version 3 of the License, or
// (at your option) any later version.
// 
// This is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see <http://www.gnu.org/licenses/>
//

println("ketcindylibkey[20230406 loaded"); // no ketjs

// 230406 Errorcheckstr dbg &changed  (flg returned as list )
// 230406 Replacedot changed  (cdot in other case )
// 230406 Keytable changed  ( no painting when clr==0 )
// 230402 Errorcheckstr added
// 230227 Keytable changed (sz)
// 220819 Replacedot addded, and added to Morefunction
// 220731 All Strsplit changed to Strsplit
// 220523 Gettexform  (frac x=>x dfrac 
// 220424 Setkeypos():=
// 211111 Setkeystyle changed ( keyposition, only for exiisting text )
// 211111 Alltextkey changed ( fname option )
// 211109 Dispposition changed (length of seg, nonascii)
// 211022 List2line, Line2list added
// 211012 Keytable changed ( for (0,xL,0,yL,... ) )
// 210917 Setkeypos added, Alltextkey changed (position)
// 210706 Modifyfortex changed (\, removed)
// 210629 Addasterisk debugged ( for e^ )
//              Keytable changed
// 210615 Keytalble changed ( name added )
// 210612 Replacefun debugged
// 210606 Replacematdet,Extractvar added
// 210604 Replacefun, Morefunctions added
//              Modifyfortex changed ( (inf) added )
// 210515 start

ch=0;
funflg=0;
texflg=0;
capflg=0;
initflg=1;
initpos=4;
StrL=apply(1..8,"");
BoxL=apply(1..8,#);
strnow="";
npos=0;

Modifyfortex(str):=(
  regional(rep1L,rep2L,nn,tmp,tmp1,out);
  rep1L=["(sp)","(cross)","(cdot)","(deg)","(circ)","(neq)",
         "(geq)","(leq)","(pm)","(mp)","(inf)"];
  rep2L=["\;","{\times}","{\cdot}","^{\circ}","\circ","{\neq}",
         "{\geq}","{\leq}","{\pm}","{\mp}","{\infty}"];
  out=str;
  forall(1..(length(rep1L)),nn,
    out=replace(out,rep1L_nn,rep2L_nn);
  );
  out;
);

Extractvar(strorg):=Extractvar(strorg,",");
Extractvar(strorg,mark):=(
  regional(out,parL,str,cma,nc,first,last,
     tmp,tmp1,tmp2);
  str=strorg;
  out=[];
  first=0; last=0;
  parL=Bracket(str,"()");
  tmp1=select(parL,#_2==1);
  tmp2=select(parL,#_2==-1);
  if(length(tmp1)*length(tmp2)>0,
    first=tmp1_1_1;
    last=tmp2_1_1;
    str=substring(str,0,last);
    cma=Indexall(str,mark);
    parL=select(parL,#_1<=last);
    if(length(cma)==0,
      out=[substring(str,first,last-1)];
    ,
      tmp1=first;
      forall(1..(length(cma)),nc,
        tmp=select(parL,#_1<cma_nc);
        tmp=tmp_(-1)_2;
        if(tmp>0,tmp=tmp,tmp=-tmp-1);
        if(tmp==1,
          tmp2=cma_(nc)-1;
          out=append(out,substring(str,tmp1,tmp2));
          tmp1=tmp2+1;
          if(nc==length(cma),
            out=append(out,substring(str,tmp1,length(str)-1));
          );
        );
      );
    );
  );
  [first,last,out];
);

Replacematdet(str):=(
  regional(sym,out,rest,ctr,eL,np,nc,tmp,tmp1,tmp2,tmp3);
  out=str;
  forall(["mat(","det(","case("],sym,  //210902 case
    tmp=indexof(out,sym);
    ctr=0;
    while((tmp>0)&(ctr<20),
      rest=substring(out,tmp-1,length(out));
      out=substring(out,0,tmp-1);
      tmp1=Bracket(rest,"()");
      tmp1=select(tmp1,#_2==-1);
      if(length(tmp1)>0,tmp1=tmp1_1_1,tmp1=length(rest));
      tmp2=substring(rest,0,tmp1);
      rest=substring(rest,tmp1,length(rest));
      eL=Extractvar(tmp2,";");
      tmp3=eL_3;
      forall(1..(length(tmp3)),np,
        tmp=tmp3_np;
        tmp1=Getlevel(tmp);
        tmp1=select(tmp1,#_2==0);
        tmp1=apply(tmp1,#_1);
        nc=length(tmp1)+1;
        forall(tmp1,
          tmp_#="&";
        );
        tmp3_np=tmp;
      );
      tmp2="\begin{array}{";
      forall(1..nc,tmp2=tmp2+"c");
      tmp2=tmp2+"}";
      forall(tmp3,tmp2=tmp2+#+"\\");
      tmp2=substring(tmp2,0,length(tmp2)-2);
      tmp2=tmp2+"\end{array}";
      if(sym=="mat(",
        tmp2="\left("+tmp2+"\right)";
      );
      if(sym=="det(",
        tmp2="\left|"+tmp2+"\right|";
      );
      if(sym=="case(", //210902from
        tmp2="\left\{"+tmp2+"\right.";
      );

      out=out+tmp2+rest;
      tmp=indexof(out,sym);
      ctr=ctr+1;      
    );
  );
  out;
);

Replacedot(str):=(  //220819
  regional(out,rest,flg,tmp,tmp1,tmp2);
  out=str;
  tmp1=indexof(out,"dot(");
  while(tmp1>0,
    tmp=Indexall(out,")");
    tmp=select(tmp,#>tmp1);
    if(length(tmp)>0,
      tmp2=tmp_1;
    ,
      tmp2=length(out);
    );
    rest=substring(out,tmp2,length(out));
    tmp=substring(out,tmp1+3,tmp2-1);
    tmp=Removespace(tmp);
    out=substring(out,0,tmp1-1);
    flg=0;
    if((tmp=="")%(tmp=="1"),tmp2="{\cdot}";flg=1);
    if((tmp=="3")%(tmp=="s"),tmp2="{\cdots}";flg=1);
    if(tmp=="d",tmp2="{\ddots}";flg=1);
    if(tmp=="l",tmp2="{\ldots}";flg=1);
    if(tmp=="v",tmp2="{\vdots}";flg=1);
    if(flg==0,tmp2="{\cdot}");
    out=out+tmp2+rest;
    tmp1=indexof(out,"dot(");
  );
  out;
);

Replacefun(str,name,repL):=(  //new 210604
  regional(out,sub,rest,pre,post,comL,ctr,lev,nn,
     tmp,tmp1,tmp2);
  out="";
  pre=""; post=str; sub="";
  tmp=indexof(post,name);
  ctr=1;
  while((tmp>0)&(ctr<50),
    pre=substring(post,0,tmp-1);
    sub=substring(post,tmp+length(name)-2,length(post));
    tmp1=Bracket(sub,"()");
    tmp1=select(tmp1,#_2==-1);
    tmp1=tmp1_1_1;
    post=substring(sub,tmp1,length(sub));
    sub=substring(sub,0,tmp1);
    tmp1=Bracket(sub,"()");
    tmp2=Getlevel(sub,",");
    if(length(tmp2)==0,
      if(name=="int(",
        pre=pre+"\displaystyle\int\,";
      );
    ,
      tmp2=select(tmp2,#_2==1);
      tmp2=apply(tmp2,#_1);
      tmp2=prepend(1,tmp2);
      tmp2=append(tmp2,length(sub));
      if(length(tmp2)==length(repL),
        forall(1..(length(tmp2)-1),
          tmp=substring(sub,tmp2_#,tmp2_(#+1)-1);
          if(!contains(["e^("],name),
            if(indexof(tmp,"-")+indexof(tmp,"+")>0,tmp="("+tmp+")");
          );
          pre=pre+repL_#+tmp;
//        if(#<length(tmp2)-1,pre=pre+","); //210617removed
        );
        pre=pre+repL_(length(tmp2));
      );
    );
    out=out+pre;
    tmp=indexof(post,name);
    ctr=ctr+1;
  );
  out=out+post;
  out;
);

Morefunction(str):=( //new 210604
  regional(out,name,repL);
  out=str;
//  out=Replacefun(out,"tfr(",["\tfrac{","}{","}"]); //210831
//  out=Replacefun(out,"lim(",["\displaystyle\lim_{","\to\,","}"]); //210617from
//  out=Replacefun(out,"int(",["\displaystyle\int_{","}^{","}"]);
//  out=Replacefun(out,"sum(",["\displaystyle\sum_{","}^{","}"]); //210617to
//  out=Replacefun(out,"e^(",["\exp{","}"]); //210612
  out=Replacematdet(out); //210606
  out=Replacedot(out); //220819
  out;
);

Togreek(str):=(
  regional(chr,alph,Alph,grk,Grk,out,flg,tmp);
  alph="abgdezhtiklmnxprstufcqov";
  grk=["alpha","beta","gamma","delta","epsilon","zeta",
       "eta","theta","iota","kappa","lambda","mu","nu",
       "xi","pi","rho","sigma","tau","upsilon",
       "phi","chi","psi","omega","varphi"];
  Alph="GDTLPSFQO";
  Grk=["Gamma","Delta","Theta","Lambda","Pi",
       "Sigma","Phi","Psi","Omega"];
  out="";
  forall(1..(length(str)),
    chr=str_#;
    flg=0;
    tmp=indexof(alph,chr);
    if(tmp>0,
      out=out+"\"+grk_(tmp)+" ";
      flg=1;
    );
    if(flg==0,
      tmp=indexof(Alph,chr);
      if(tmp>0,
        out=out+"\"+Grk_(tmp)+" ";
        flg=1;
      );
    );
    if(flg==0,out=out+chr);
  );
  out;
);

Noascii(str):=(
  regional(ascii,out,tmp,tmp1);
  ascii=apply(32..126,unicode(text(#),base->10));
  out="";
  forall(1..(length(str)),
    tmp=Op(#,str);
    if(!contains(ascii,tmp),
      out=out+tmp;
    );
  );
  out;
);

//tmp1=32..126;
//tmp=(65..90)++(97..122);
//tmp1=remove(tmp1,tmp);
//alpha=apply(tmp,unicode(text(#),base->10));
//tmp=[46]++(48..57);
//tmp1=remove(tmp1,tmp);
//numer=apply(tmp,unicode(text(#),base->10));

Charstyle(str):=(
  regional(ctr,tmp,tmp1,tmp2,tmp3,out);
  out=str;
  tmp=indexof(out,"{C}");
  ctr=0;
  while((tmp>0)&(ctr<20),
    tmp3=substring(out,tmp+2,tmp+3);
    tmp3=Toupper(tmp3);
    tmp3=substring(out,0,tmp-1)+tmp3;
    out=tmp3+substring(out,tmp+3,length(out));
    tmp=indexof(out,"{C}");
    ctr=ctr+1;
  );
  tmp=indexof(out,"{G}");
  ctr=0;
  while((tmp>0)&(ctr<20),
    tmp3=substring(out,tmp+2,tmp+3);
    tmp3=Togreek(tmp3);
    tmp3=substring(out,0,tmp-1)+tmp3;
    out=tmp3+substring(out,tmp+3,length(out));
    tmp=indexof(out,"{G}");
    ctr=ctr+1;
  );
  tmp=indexof(out,"{B}");
  ctr=0;
  while((tmp>0)&(ctr<20),
    tmp3=substring(out,tmp+2,tmp+3);
    tmp3="\mathbf{"+tmp3+"}";
    tmp3=substring(out,0,tmp-1)+tmp3;
    out=tmp3+substring(out,tmp+3,length(out));
    tmp=indexof(out,"{B}");
    ctr=ctr+1;
  );
  out;
);

Addat(str):=(
  regional(ascii,out,flg,tmp);
  ascii=apply(32..126,unicode(text(#),base->10));
  ascii=remove(ascii,["@"]);
  out="";
  flg=0;
  forall(1..(length(str)),
    tmp=str_#;
    if(tmp=="@",
      flg=1-flg
    ,
      if(!contains(ascii,tmp),
        if(flg==0,
          tmp="@"+tmp+"@";
        );
      );
    );
    out=out+tmp;
  );
  out=replace(out,"@@","");
  out;
);

Sepchar(strorg):=(
  regional(str,out,flg,sharp,tctr,err,tmp,tmp1,tmp2);
  tmp1=strorg; //210907from
  str="";
  tctr=0;
  sharp=[];
  tmp=indexof(tmp1,"tx(");
  while(tmp>0,
    tctr=tctr+1;
    tmp2=substring(tmp1,0,tmp+1);
    tmp1=substring(tmp1,tmp+1,length(tmp1));
    str=str+tmp2+"(#"+text(tctr)+")";
    tmp=indexof(tmp1,")");
    tmp2=substring(tmp1,1,tmp-1);
    sharp=append(sharp,tmp2);
    tmp1=substring(tmp1,tmp,length(tmp1));
    tmp=indexof(tmp1,"tx(");
  );
  str=str+tmp1; //210907to
  str=Addat(str); 
  err="";
  out=[];
  tmp1=Indexall(str,"@");
  tmp=length(tmp1);
  if((length(str)==0)%(tmp==0)%(mod(tmp,2)==1),
    if((length(str)==0)%(tmp==0),
      if(length(str)==0,out=[],out=[str]);
    ,
      err="@の数";
    );
  ,
    tmp=tmp1_1;
    if(tmp>1,
      out=[substring(str,0,tmp-1)];
    );
    start=tmp;
    flg=1;
    forall(2..(length(tmp1)),
      if(flg==1,
        tmp2=substring(str,start-1,tmp1_#-1);
      ,
        tmp2=substring(str,start,tmp1_#-1);
      );
      out=append(out,tmp2);
      start=tmp1_#;
      flg=1-flg;
    );
    if(start<length(str),
      tmp2=substring(str,start,length(str));
      out=append(out,tmp2);
    );
  );
  forall(1..(length(sharp)),tmp,  //210907from
    out=apply(out,replace(#,"#"+tmp,sharp_tmp));
  ); //210907to
  [out,err];
);

Instr(key):=(
  regional(out,tmp,tmp1);
  if(length(key)==1,out=key);
  if(length(key)==2,
    tmp=substring(key,0,1);
    tmp1=substring(key,1,2);
    if((tmp=="L")%(tmp=="n"),
      out=tmp1;
      if(capflg==1,
        if((out>="a")&(out<="z"),
          out=Toupper(out);
        );
        capflg=0;
      );
    ,
      out=key;
    );
  );
  if(length(key)>=3,
    out=key;
    if(indexof(key,"()")>0,
      if(indexof(key,"Delete")>0,out="";Delete());
      if(indexof(key,"Allclear")>0,out="";Allclear());
    );
  );
  out;
);

Greekletter(str):=(
  regional(tmp,tmp1,tmp2,tmp3,tmp4,out,ctr);
  out=replace(str,"g r(","gr(");
  tmp2=indexof(out,"gr(");
  ctr=1;
  while((tmp2>0)&(ctr<100),
    tmp=Bracket(out,"()");
    tmp=select(tmp,(tmp2<#_1)&(#_2<0));
    tmp3=tmp_1_1;
    tmp=substring(out,tmp2+2,tmp3-1);
    tmp4=Togreek(tmp);
    tmp=substring(out,0,tmp2-1)+tmp4;
    out=tmp+substring(out,tmp3,length(out));
    tmp2=indexof(out,"gr(");
    ctr=ctr+1;
  );
  out;
);

Capitalletter(str):=(
  regional(tmp,tmp1,tmp2,tmp3,tmp4,out,ctr);
  out=replace(str,"c a(","ca(");
  tmp2=indexof(out,"ca(");
  ctr=1;
  while((tmp2>0)&(ctr<100),
    tmp=Bracket(out,"()");
    tmp=select(tmp,(tmp2<#_1)&(#_2<0));
    tmp3=tmp_1_1;
    tmp=substring(out,tmp2+2,tmp3-1);
    tmp4=Toupper(tmp);
    tmp=substring(out,0,tmp2-1)+tmp4;
    out=tmp+substring(out,tmp3,length(out));
    tmp2=indexof(out,"ca(");
    ctr=ctr+1;
  );
  out;
);

Boldletter(str):=(
  regional(tmp,tmp1,tmp2,tmp3,tmp4,out,ctr);
  out=replace(str,"b o(","bo(");
  tmp2=indexof(out,"bo(");
  ctr=1;
  while((tmp2>0)&(ctr<100),
    tmp=Bracket(out,"()");
    tmp=select(tmp,(tmp2<#_1)&(#_2<0));
    tmp3=tmp_1_1;
    tmp=substring(out,tmp2+2,tmp3-1);
    tmp4="\mathbf{"+tmp+"}";
    tmp=substring(out,0,tmp2-1)+tmp4;
    out=tmp+substring(out,tmp3,length(out));
    tmp2=indexof(out,"bo(");
    ctr=ctr+1;
  );
  out;
);

Gettexform(str):=(
  regional(err,subL,strt,tmp,tmp1,tmp2,tmp3,tmp4);
  err="";
  tmp=Sepchar(str);
  subL=tmp_1;
  err=tmp_2;
  strt="";
  forall(subL,
    if(substring(#,0,1)=="@",
      strt=strt+substring(#,1,length(#));
    ,
      tmp=#;
      tmp=replace(#," ","(sp)");
      tmp=Modifyfortex(tmp);
      tmp=Morefunction(tmp);
      tmp1=Totexform(tmp);
//      tmp=Addasterisk(tmp);
//      tmp=replace(tmp,"\exp(","e^(");
//      tmp1=Totexform(tmp);
      tmp1=replace(tmp1,"a r r a y","array"); //210606[2lines]
      repeat(5,tmp1=replace(tmp1,"c c","cc"));
      tmp1=replace(tmp1,"c i r c","\circ");
//      tmp1=replace(tmp1,"\frac","\dfrac"); //220523(//)
      tmp1=Greekletter(tmp1); //210514[3lines]
      tmp1=Capitalletter(tmp1);
      tmp1=Boldletter(tmp1);
      strt=strt+"$"+tmp1+"$";
    );
  );
  strt;
);

Dispposition(pos,npos,str):=Dispposition(pos,3,npos,str);
Dispposition(pos,len,npos,str):=(
  regional(ascii,tmp,tmp1,tmp2,dp,p1,p2,p3,p4,n,ctr);
  ascii=apply(32..126,unicode(text(#),base->10));
  dp=[0,len];
  tmp=[0.1,0];
  p1=pos-tmp;  p2=pos+tmp;
  p3=p1+dp; p4=p2+dp;
  Listplot("-disp",[p1,p2,p4,p3,p1],["nodisp","Msg=n"]);
  Shade(["disp"],["Color=red"]);
  if(length(str)>0, //211109from
    n=npos;
    ctr=0;
    while((n>0)&(ctr<4),
      tmp=substring(str,n-1,n);
      if(contains(ascii,tmp),ctr=ctr+1,ctr=ctr+2);
      n=n-1;
    ); 
    tmp1=substring(str,n,npos);
    n=npos+1;
    ctr=0;
    while((n<=length(str))&(ctr<4),
      tmp=substring(str,n-1,n);
      if(contains(ascii,tmp),ctr=ctr+1,ctr=ctr+2);
      n=n+1;
    );  
    tmp2=substring(str,npos,n-1);
    p1=pos+1/3*dp;
    drawtext(p1,tmp1,size->22,align->"right");
    drawtext(p1,tmp2,size->22,align->"left");
  ); //211109to
);

Addfunstr(name,npos,strnow):=(
  regional(str,tmp,out);
  str=Instr(name);
  tmp="";
  tmp=substring(strnow,0,npos)+str;
  tmp=tmp+substring(strnow,npos,length(strnow));
  out=[tmp,npos+length(str)];
  funflg=0;
  out;
);

////%Keytable start////
Keytable(nx,dx,ny,dy,plb,clr):=Keytable(nx,dx,ny,dy,plb,clr,[],0,22,1); //210629
Keytable(nx,dx,ny,dy,plb,clr,nameL,nmove,sz):=( //230406
  // Keytable(5,20,3,10,....)
  // Keytable(0,dxL,0,dyL,...)
  regional(xL,yL,plt,prt,prb,row,col,name,tmp,tmp2,pos);
  if(nx>0,  //211012from
    xL=apply(0..nx,#/10*dx+plb_1);
  ,
    xL=[plb_1];
    forall(dx,
      tmp=xL_(-1)+#/10;
      xL=append(xL,tmp);
    );
  );
  if(ny>0,
    yL=apply(0..ny,(ny-#)/10*dy+plb_2);
  ,
    yL=[plb_2];
    forall(dy,
      tmp=yL_(-1)+#/10;
      yL=append(yL,tmp);
    );
  );  //211012to
  plt=[xL_1,yL_1]; prt=[xL_(-1),yL_1]; prb=[xL_(-1),yL_(-1)];
  if(clr!=0,//shade==1, 230406
    fillpoly([plb,plt,prt,prb,plb],color->clr);
  );
  forall(xL,draw([#,plb_2],[#,plt_2],color->[0,0,0]));
  forall(yL,draw([plb_1,#],[prb_1,#],color->[0,0,0]));
  if(length(nameL)>0,
    forall(1..(length(yL)-1),row,
      tmp1=yL_row;
      tmp2=yL_(row+1);
      pos=[0,(tmp1+tmp2)/2];
      forall(1..(length(xL)-1),col,
        name=nameL_row_col;
        tmp1=xL_col;
        tmp2=xL_(col+1);
        pos_1=(tmp1+tmp2)/2;
        tmp=indexof(name,",");
       drawtext(pos+nmove,name,align->"mid",size->sz);
      );
    );
  );
);
////%Keytable end////

Allclear():=(
  StrL_ch="";
  strnow="";
  npos=0;
  Subsedit(BoxL_ch,"");
  funflg=0;
);

Deletekey():=(
  regional(tmp1,tmp2);
  if(npos>0,
    tmp1=substring(strnow,0,npos-1);
    tmp2=substring(strnow,npos,length(strnow));
    StrL_ch=tmp1+tmp2;
    strnow=StrL_ch;
    Subsedit(BoxL_ch,strnow);
    npos=npos-1;
    funflg=0;
  );
);

LFmark=unicode("000a");
CRmark=unicode("000d");
Dq=unicode("0022");
Dqq(str):=(
  unicode("0022")+str+unicode("0022");
);

////%Alltextkey start////
Alltextkey(make):=Alltextkey(make,"keylist");  //no ketjs on
Alltextkey(make,fname):=(
//help:Alltexkey(1);
  regional(txtkey,keyL,key,tmp,tmp1,tmp2,tmp3,tmp4,fid);
  txtkey=remove(allelements(),allpoints());
//  tmp=concat(1..5,[21,22]);
//  tmp=apply(tmp,parse("Text"+text(#)));
//  txtkey=remove(txtkey,tmp);
  println(fname+".csv");
  keyL=[];
  forall(txtkey,key,
     tmp=replace(key.name,"Text","");
    tmp=replace(tmp,"''",".2");
    tmp=replace(tmp,"'",".1");
    tmp=parse(tmp);
    tmp1=[tmp,key.name];
    tmp=inspect(key,"text.text");
    tmp2=[Dqq(tmp),inspect(key,"textsize")];
    tmp3=[inspect(key,"colorfill"),inspect(key,"fillalpha")];
    tmp4=key.xy; //210917[2lines]
    keyL=concat(keyL,[tmp1++tmp2++tmp3++tmp4]);
  );
  keyL=sort(keyL,[#_1]);
  if(make==0,
    apply(keyL,println(#));
  );
  if(make==1,
    setdirectory(Dircdy);
    tmp=fname+".csv";
    fid=openfile(tmp);
    forall(keyL,key,
      print(fid,text(key_1)+",");
      forall(2..(length(key)),
        tmp=key_#;
        if(!isstring(tmp),tmp=text(tmp));
        print(fid,tmp);
        if(#<length(key),
          print(fid,",");
        ,
          println(fid,"");
        );
      );
    );
    closefile(fid);
    tmp=fname+"b.txt";
    fid=openfile(tmp);
    forall(keyL,key,
      tmp=key_2;
      println(fid,tmp);
      tmp=parse(tmp);
      tmp1=inspect(tmp,"button.script");
      println(fid,tmp1);
    );
    closefile(fid);
  );
  keyL;
);  //no ketjs off
////%Alltextkey end////

////%Setkeystyle start////
Setkeystyle():=Setkeystyle("keylist");  //no ketjs on
Setkeystyle(fname):=(
//help:Setkeystyle();
  regional(keyL,button,key,tmp,tmp1,txtkey);
  tmp=remove(allelements(),allpoints());
  txtkey=apply(tmp,#.name);
  println(fname+".csv");
  if(!isexists(Dircdy,fname+".csv"),
    println("  File not found");
  ,
//    Setdirectory(Dircdy);
    keyL=Readlines(Dircdy,fname+".csv");
    button=Readlines(Dircdy,fname+"b.txt");    
    forall(keyL,
      key=Strsplit(#,",");
      if((contains(txtkey,key_2))&(key_3!=Dqq("")),
        tmp=substring(key_3,1,length(key_3)-1);
        inspect(parse(key_2),"text.text",tmp);
        inspect(parse(key_2),"textsize",key_4);
        inspect(parse(key_2),"colorfill",key_5);
        inspect(parse(key_2),"fillalpha",key_6);
        if(!contains([key_7,key_8],"NaN"), //211112from
          tmp=key_2+".xy=["+key_7+","+key_8+"];";
          parse(tmp);
        ); //211112from
        tmp=select(1..(length(button)),indexof(button_#,key_2)>0);
        tmp1=tmp_1+1;
        tmp2="";
        while(tmp1<=length(button),
          if(indexof(button_tmp1,"Text")==0,
            tmp2=tmp2+button_tmp1;
          ,
            tmp1=length(button);
          );
          tmp1=tmp1+1;
        );
        inspect(parse(key_2),"button.script",tmp2);
      );
    );
  );
);  //no ketjs off
////%Setkeystyle end////

////%Setkeypos start////
Setkeypos():=Setkeypos("keylist");  //no ketjs on
Setkeypos(fname):=(
  regional(keyL,key,tmp,tmp1);
  keyL=Readlines(Dircdy,fname+".csv");
  keyL=apply(keyL,Strsplit(#,","));
  forall(keyL,key,
    tmp1=key_3;
    tmp=key_2+".xy=["+key_7+","+key_8+"];";
    parse(tmp);
  );
); //no ketjs off
////%Setkeypos end////

////%List2line start////
List2line(stLL):=(
  regional(tab,nn,nc,tmp,str,st,out);
  tab=unicode("0009");
  out="";
  forall(1..(length(stLL)),nn,
    st=stLL_nn;
    str="";
    forall(1..(length(st)),
      tmp=st_#;
      if(!isstring(tmp),tmp=format(tmp,10));
      str=str+tmp+tab;
    );
    str=substring(str,0,length(str)-1);
    out=out+str;
    if(nn<length(stLL),out=out+"CR");
  );
  out;  
);
////%List2line endt////

////%Line2list start////
Line2list(strorg):=(
  regional(tab,stL,st,nn,tL,mx,flg,tmp);
  tab=unicode("0009");
  str=replace(strorg,";;",tab);
  flg=indexof(str,"::");
   tL=[];
  if(indexof(str,"CR")>0,
    stL=Strsplit(str,"CR");
    forall(1..(length(stL)),nn,
      st=stL_nn;
      if(!isstring(st),st=format(st,10));
      stL_nn=Strsplit(st,tab);
    );
  ,
    stL=Strsplit(str,tab);
    forall(1..(length(stL)),
      tmp=stL_#;
      if(indexof(tmp,"::")>0,tmp=Strsplit(tmp,"::"));
      stL_#=tmp;
    );
  );
  stL;
);
////%Line2list end////


Errorcheckstr(str):=(
  regional(flg,tmp,tmp1,tmp2,tmp3);
  flg=[0,[]];
  if(length(str)==0,flg=3);
  if(flg_1==0,
    tmp3=Indexall(str,"^");
    tmp2=[];
    forall(tmp3,
      if(#==1,
        tmp2=append(tmp2,#);
      ,
        if(str_(#-1)=="(",
          tmp2=append(tmp2,#);
        ,
          if(#>=4,
            tmp=substring(str,#-4,#-1);
            println(tmp);
            
            if(contains(["sin","cos","tan"],tmp),
              tmp2=append(tmp2,#);
            );
          );    
        );
        if(length(tmp2)>0,
          flg=[2,tmp2]; // pos of hats different
        );
      );
    );
  );
  if(flg_1==0,
    if(indexof(str,"(")>0,
      tmp2=Bracket(str);
      tmp=tmp2_(-1);
      if(tmp_2!=-1, // brackets mismach
        tmp2=select(tmp2,abs(#_2)==1);
        tmp2=apply(tmp2,#_1);
        flg=[1,tmp2]; 
      );
    );
  ); 
  flg;
);
