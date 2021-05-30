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

println("ketcindylibforjs[20210518] loaded");
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
  rep1L=["(sp)","(cross)","(cdot)","(deg)","(neq)",
         "(geq)","(leq)","(pm)","(mp)"];
  rep2L=["\;","\times ","\cdot ","^{\circ} ","\neq ",
         "\geq ","\leq ","\pm ","\mp "];
  out=str;
  forall(1..(length(rep1L)),nn,
    out=replace(out,rep1L_nn,rep2L_nn);
  );
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
  regional(str,out,flg,err,tmp,tmp1,tmp2);
  str=Addat(strorg);
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
      tmp=Addasterisk(tmp);
      tmp1=Totexform(tmp);
      tmp1=replace(tmp1,"c i r c","\circ");
      tmp1=replace(tmp1,"\frac","\dfrac");
      tmp1=Greekletter(tmp1); //210514[3lines]
      tmp1=Capitalletter(tmp1);
      tmp1=Boldletter(tmp1);
      strt=strt+"$"+tmp1+"$";
    );
  );
  strt;
);

Dispposition(posline,npos,str):=(
  regional(tmp,tmp1,tmp2,dp,p1,p2);
  dp=[0,1];
  p1=posline+dp;  p2=posline-dp;
  Listplot("disp1",[p1,p2],["Color=blue"]);
  tmp=[0.2,0];
  p1=posline+dp+tmp;  p2=posline-dp+tmp;
  Listplot("disp1",[p1,p2],["Color=blue"]);
  if(length(str)>0,
    if(npos==0,tmp1="";tmp2=str_1);
    if(npos>0,
      tmp1=str_(npos); tmp2="";
      if(npos<length(str),
        tmp2=str_(npos+1);
      );
    );
    dp=0.5*dp;
    p1=posline-dp-[1.1,0];
    p2=posline-dp+[0.5,0];
    Drwletter(p1,tmp1,24);
    Drwletter(p2,tmp2,24);
  );
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

Keytable(nx,dx,ny,dy,plb,clr):=(
  regional(xL,yL,plt,prt,prb);
  xL=apply(0..nx,#/10*dx);
  yL=apply(0..ny,#/10*dy);
  plt=plb+[0,yL_(-1)]; prt=plt+[xL_(-1),0]; prb=prt-[0,yL_(-1)];
  fillpoly([plb,plt,prt,prb,plb],color->clr);
  forall(xL,draw([plb_1+#,plb_2],[plb_1+#,plt_2],color->[0,0,0]));
  forall(yL,draw([plb_1,plb_2+#],[prb_1,plb_2+#],color->[0,0,0]));
);

Allclear():=(
  StrL_ch="";
  strnow="";
  npos=0;
  Subsedit(BoxL_ch,"");
  funflg=0;
);

Delete():=(
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
Alltextkey(make):=( //no ketjs on
//help:Alltexkey(1);
  regional(fname,txtkey,keyL,key,tmp,tmp1,tmp2,tmp3,fid);
  fname="keylist";
  txtkey=remove(allelements(),allpoints());
//  tmp=concat(1..5,[21,22]);
//  tmp=apply(tmp,parse("Text"+text(#)));
//  txtkey=remove(txtkey,tmp);
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
    keyL=concat(keyL,[tmp1++tmp2++tmp3]);
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
  regional(keyL,button,key,tmp);
  println(fname+".csv");
  if(!isexists(Dircdy,fname+".csv"),
    println("  File not found");
  ,
    Setdirectory(Dircdy);
    keyL=Readlines(Dircdy,fname+".csv");
    button=Readlines(Dircdy,fname+"b.txt");    
    forall(keyL,
      key=Strsplit(#,",");
      tmp=substring(key_3,1,length(key_3)-1);
      inspect(parse(key_2),"text.text",tmp);
      inspect(parse(key_2),"textsize",key_4);
      inspect(parse(key_2),"colorfill",key_5);
      inspect(parse(key_2),"fillalpha",key_6);
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
);  //no ketjs off
////%Setkeystyle end////

