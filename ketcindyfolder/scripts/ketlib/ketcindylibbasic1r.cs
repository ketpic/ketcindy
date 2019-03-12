//  Copyright (C)  2014  Setsuo Takato, KETCindy Japan project team
//
//This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation; either version 3 of the License, or
// (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see <http://www.gnu.org/licenses/>
//

println("KeTCindy V.3.2.5");
println(ketjavaversion());
println("ketcindylibbasic1[20190311] loaded");

//help:start();

//help:drawimage([0,0],"picture.png",scale->2,alpha->0.4);
//help:drawtext((2,1),"Text",size->2);
//help:system(list=append(list,"a"););
//help:system(list=concat(list,["a","b"]););
//help:system(arccos,arcsin,arctan);
//help:system(abs,round,floor,ceil);

//help:Option1(["dr","dr,2","da","da,2,1","do","do,1,2"]);
//help:Option2(["notex","nodisp","nodata"]);

//help:getdirhead();
//help:gedirhead("/Applications");
//help:gedirhead("C:\Users\(username)");
//help:setpath();

Ch=[0]; ChNum=1;

////%Ketinit start////
Ketinit():=Ketinit("fig",1,[-5,5],[-5,5]); //181001
Ketinit(Arg):=(//181001from
  if(isstring(Arg),
     Ketinit(Arg,1,[-5,5],[-5,5]);
  ,
    Ketinit("fig",Arg,[-5,5],[-5,5]);
  );
);
Ketinit(work,sy,rangex,rangey):=(//181001to
 //help:Ketinit();
 //help:Ketinit("");
 regional(pt,tmp,tmp1,tmp2,letterc,boxc,shadowc,mboxc);
  PenThickInit=8;
  ULEN="1cm";
  MEMORI=0.05;//18.01.15from
  MEMORIInit=MEMORI;
  MEMORINow=MEMORI;
  MARKLEN=0.05;
  MARKLENInit=MARKLEN; //180504
  MARKLENNow= MARKLEN;
  GENTEN=[0,0];//18.01.15until
  KETPICLAYER=20;
  MilliIn=1/2.54*1000;
  PenThick=round(MilliIn*0.02);
  PenThickInit=PenThick;
  TenSizeInit=0.02;
  TenSize=TenSizeInit;
  YaSize=1; YaAngle=18; YaPosition=1;
  YaCut=0; YasenStyle="dr,1"; Yajiristyle="tf";
  KETPICCOUNT=1;
  KCOLOR=[0,0,0];
  GLIST=[];
  GCLIST=[];
//  GDATALIST=[]; //no ketjs
  GOUTLIST=[];
  POUTLIST=[];
  VLIST=[];
  FUNLIST=[];
  LETTERlist=[];
  COM0thlist=[];
  COM1stlist=[];
  COM2ndlist=[];
 // COM2ndlistb=[]; //180612
  ADDAXES="1";
  AXSTYLE=["l","x","e","y","n","O","sw","","",""]; //181216
  AXCOUNT=1; //181215
  SHADECTR=1; //190222
  LFmark=unicode("000a");
  CRmark=unicode("000d");//16.12.13
  Dq=unicode("0022");
  CommonMake=0;//180610
  WaitUnit=10;
  CONTINUED=0;
  OutComList=[];
  OutFileLIst=[];   // 15.10.22
  FigPdfList=[];  // 16.04.08
  Fillstore(); //181212
  ADDPACK=[]; // 16.05.16
  GPACK="tpic"; //180817
  ErrFlag=0;
  KETJSOP=[]; //190129
  // no ketjs on 190122
//  setdirectory(Dirwork);
  if(!isstring(Fhead),  // 17.10.13from, 17.11.12
    Fhead=text(curkernel());
    Fhead=replace(Fhead,".cdy","");
    Slidename=Fhead; //17.10.24
  );//17.11.12
  Dircdy=replace(Dircdy,"%E3%80%80","　");//180405
  Namecdy=Cindyname();//180608
  tmp1=Indexall(Dircdy,"%"); //180329from
  if(length(tmp1)>0,
    tmp1=append(tmp1,length(Dircdy));
    tmp2=substring(Dircdy,0,tmp1_1-1);
    forall(1..(length(tmp1)-1),
      tmp=substring(Dircdy,tmp1_#,tmp1_#+2);
      tmp2=tmp2+unicode(tmp);
      tmp2=tmp2+substring(Dircdy,tmp1_#+2,tmp1_(#+1)-1);
    );
    Dircdy=tmp2;
  ); //180329to
  if(iswindows(),  //17.12.01
    Dircdy=replace(Dircdy,"/",pathsep());
    if(substring(Dircdy,0,1)==pathsep(),
      Dircdy=substring(Dircdy,1,length(Dircdy));
    );
  );
  Userhome=Homehead+pathsep()+getname(); //190128
  if(iswindows(),
    Batparent="\kc.bat";
  ,
    if(ismacosx(), //181125from
      Shellparent="/kc.command"; 
      Mackc="open"; //190222
    ,
      Shellparent="/kc.sh"; 
      Mackc="bash"; //190222
    );  //181125to
  );
  Changesetting(); //190128
  Changework(Dircdy+pathsep()+work); //180329to,181001
  Fnametex=Fhead+".tex";
  FnameR=Fhead+".r";
  FnamebodyR=Fhead+"body.r";
  Fnameout=Fhead+".txt";  // 17.10.13to
// no ketjs off 190122
  ArrowlineNumber=1;  // 15.01.05
  ArrowheadNumber=1;
  BezierNumber=1; //15.01.03
  SCALEX=1;
  SCALEY=sy;
//  Setscaling(sy);
  XMIN=rangex_1/SCALEX;
  XMAX=rangex_2/SCALEX;
  YMIN=rangey_1/SCALEY;
  YMAX=rangey_2/SCALEY;
  Setwindow("Msg=n"); // 16.05.31
// no ketjs on 190122
  // for Presentation
  letterc=[0.98,0.13,0,0.43]; boxc=[0.2,0,0,0];//190307 [0,0.32,0.52,0];
  shadowc=[0,0,0,0.5]; mboxc="yellow"; //17.03.02 regional debugged
  SlideColorList=[letterc,boxc,boxc,boxc,shadowc,shadowc,6,1.3,
                letterc,mboxc,mboxc,mboxc,62,2,letterc];
  SlideMargin=[0,0]; //180908
  ThinDense=0.1;//17.01.08
  if(indexof(PathT,"pdflatex")+indexof(PathT,"lualatex")>0,
    LibnameS=replace(LibnameS,"ketpic","ketpic2e");
  );//17.12.03until
// no ketjs off 190122
);
////%Ketinit end////

////%Fillstore start////
Fillstore():=(
  regional(tmp,tmp1,out,dtL,txtL,clrL,txt,clr,nn,jj);
  dtL=[  //181209from
    ["Figure",[1,0.29,0.29]],["Parent",[1,1,0]],
    ["ParaF",[0,1,1]],["Flip",[0,0,1]],["Anime",[0.51,0.95,1]],
    ["Title",[0,1,0]],["Slide",[0.47,0,0.72]],["Digest",[1,0.74,0.47]],
    ["KeTJS",[0,1,1]],["KeTJSoff",[0,1,1]],
    ["Objview",[0,1,0]]
  ];
  txtL=apply(dtL,#_1);
  clrL=apply(dtL,#_2);
  tmp1=allelements();
  tmp1=select(tmp1,indexof(#.name,"Text")>0);
  out=[];
  forall(1..(length(tmp1)),nn,
    tmp=tmp1_nn;
    txt=tmp.text;
    tmp=select(1..(length(txtL)),txtL_#==txt);
    if(length(tmp)>0,
      jj=tmp_1;
      clr=clrL_jj;
      tmp=tmp1_nn;
      tmp.fillcolor=clr;
    ,
      tmp=tmp1_nn;
      clr=tmp.fillcolor;
    );
    out=append(out,[tmp.name,clr,tmp.text]);
  ); //181209to
  out;
);
////%Fillstore end////

////%Fillblack start////
Fillblack():=Fillblack("Running");
Fillblack(str):=(
  regional(tmp,tmp1,store);
  store=Fillstore(); //181209
  tmp=select(tmp1,#.name=="Text0");
  if(length(tmp)==0,
    forall(store,
      tmp=parse(#_1);
      tmp.fillcolor=[0,0,0];
    );
  ,
    Text0.text=str;
  );
  store;
);
////%Fillblack end////

////%Fillrestore start////
Fillrestore(store):=(
  regional(tmp);
  tmp=select(store,#_1=="Text0");
  if(length(tmp)==0,
    forall(store,
      tmp=parse(#_1);
      tmp.fillcolor=#_2;
    );
  ,
    tmp=tmp_1;
    Text0.text=tmp_3;
  );
);
////%Fillrestore end////

////%Readlines start////
Readlines(file):=Readlines(Dirwork,file); //181126
Readlines(path,file):=(
//help:Readlines(path,file);
  regional(tmp,out);
  out=readfile2str(path,file);
  out=tokenize(out,"/L"+"F/"); //190129
  tmp=out_(length(out));
  if(length(tmp)==0,
    out=out_(1..(length(out)-1));
  );
  out;
);
////%Readlines end////

////%Changesetting start////
Changesetting():=( //190128
  regional(dir,fname);
  dir=Homehead+pathsep()+getname();
  fname=".ketcindy.conf"; 
  if(isexists(dir,fname),
    println("read "+fname+" in "+dir);
    setdirectory(dir);
    import(fname);
  );
  dir=Dircdy; fname="ketcindy.conf"; 
  if(isexists(dir,fname),
    println("read "+fname+" in "+dir);
    setdirectory(dir);
    import(fname);
  );
);
////%Changesetting end////

////%Cindyname start////
Cindyname():=Getcdyname();
Cdyname():=Getcdyname();
Getcdyname():=( //17.12.27
//help:Cindyname();
  regional(out);
  out=text(curkernel());
  out=replace(out,".cdy","");
);
////%Cindyname end////

////%Setwindow start////
Setwindow():=Setwindow("Msg=yes");
Setwindow(str):=(
  regional(tmp,tmp1,tmp2,msg);
  msg="y";
  tmp=indexof(str,"="); // 16.02.10
  tmp1=Toupper(substring(str,tmp,tmp+1));
  if(tmp1=="N",msg="n");
  if((ispoint(SW) & ispoint(NE)),
    tmp1=Lcrd(SW);
    tmp2=Lcrd(NE);
    XMIN=tmp1_1; XMAX=tmp2_1;
    YMIN=tmp1_2; YMAX=tmp2_2;
  ,
//    XMIN=-5; XMAX=5;
//    YMIN=Lcrdy(-5); YMAX=Lcrdy(5);
//    createpoint("SW",Pcrd([XMIN,YMIN]));
//    createpoint("NE", Pcrd([XMAX,YMAX]));
    Putpoint("SW",Pcrd([XMIN,YMIN]));
    Putpoint("NE", Pcrd([XMAX,YMAX])); 
  );
  if(msg=="y",
    println("Setwindow(["+XMIN+","+XMAX+"],["+YMIN+","+YMAX+"])");
  );
  layer(KETPICLAYER);
  autoclearlayer(KETPICLAYER,true);
  drawpoly([Pcrd([XMIN,YMIN]), Pcrd([XMAX,YMIN]),
        Pcrd([XMAX,YMAX]),Pcrd([XMIN,YMAX])],color->[1,1,1]);
);
Setwindow(xrange,yrange):=(
//help:Setwindow([2,3],[-1,1]);
  XMIN=xrange_1;
  XMAX=xrange_2;
  YMIN=yrange_1;
  YMAX=yrange_2;
  Putpoint("SW",[XMIN,YMIN]);//181016
  Putpoint("NE",[XMAX,YMAX]);//181016
//  Ketinit();
);
////%Setwindow end////

////%Setfiles start////
Setfiles():=Setfiles(""); //180618
Setfiles(file):=( // 17.01.16
//help:Setfiles(file);
  if(length(file)>0, //180618
    Fhead=file;
    Fnametex=Fhead+".tex";
    FnameR=Fhead+".r"; //17.10.14
    FnamebodyR=Fhead+"body.sce";
    Fnameout=Fhead+".txt";
    OCNAME=Fhead; //180714 for obj
  ,
    println("Fhead="+Dqq(Fhead)); //180618
  );
);
////%Setfiles end////

////%Setparent start////
Setparent():=Setparent("");
Setparent(file):=( // 17.11.27
//help:Setparent(file);
  if(length(file)>0, //180618
    Texparent=file;
  ,
    if(isstring(Texparent), //180618from
      println("Texparent="+Dqq(Texparent));
    ,
      println("Texparent not defined");
    );
  ); //180618to
);
////%Setparent end////

////%Dqq start////
Dqq(str):=DqDq(str); //18.02.11
////%Dqq end////
////%DqDq start////
DqDq(str):=(
//help(Dqq("ab"); => Dq+"ab"+Dq)
  unicode("0022")+str+unicode("0022");
);
////%DqDq end////

////%PPa start//// 190111
PPa():=PPa(""); 
PPa(str):="("+str+")"; 
////%PPa end////

////%PaO start//// 190111
PaO():=PaO("");
PaO(Arg):=(
  regional(out);
  if(isstring(Arg),
    out="("+Arg;
  ,
    out="";
    repeat(Arg,
      out=out+"(";
    );
  );
  out;
);
////%PaO end////

////%PaC start//// 190111
PaC():=PaC("");
PaC(Arg):=(
  regional(out);
  if(isstring(Arg),
    out=Arg+")";
  ,
    out="";
    repeat(Arg,
      out=out+")";
    );
  );
  out;
);
////%PaC end////

////%PPa start//// 190111
PPa(str):="("+str+")"; 
////%PPa end////

////%Tab2list start////
Tab2list(dtstr):=Tab2list(dtstr,[]);
Tab2list(dtstrorg,options):=(
//help:Tab2list(datastr);
//help:Tab2list(options=["Blank=(null)","Sep=tab"]);
  regional(dtstr,dtall,dt,rep,out,crm,lfm,htm,first,eqL,sep,
      tmp,tmp1,tmp2);
  crm=unicode("000d");
  lfm=unicode("000a");
  htm=unicode("0009");
  tmp=Divoptions(options);
  eqL=tmp_5;
  rep="";
  sep=htm;
  forall(eqL,
    tmp=indexof(#,"=");
    tmp1=Toupper(substring(#,0,1));
    tmp2=substring(#,tmp,length(#));
    if(tmp1=="B",
      tmp1="0123456789+-.";  // 16.09.28from
      tmp=substring(tmp2,0,1);
      if(indexof(tmp1,tmp)>0,rep=parse(tmp2),rep=tmp2);  // 16.09.28until
    );
    if(tmp1=="S", // 16.12.04
      if(tmp2!="tab",sep=tmp2);
    );
  );
  first=lfm; // 16.09.05from
  if(indexof(dtstr,crm)>0,
    first=crm;
    if(indexof(dtstr,crm+lfm)>0,
      first=first+lfm;
    ); // 16.09.05until
  );
  dtstr=dtstrorg;// 16.09.19from
  tmp=substring(dtstr,length( dtstr)-1,length(dtstr)); 
  if(tmp!=lfm,
    dtstr=dtstr+first;
  );// 16.09.19until
  tmp1=Indexall(dtstr,first);
  tmp1=prepend(0,tmp1);
  tmp1=append(tmp1,length(dtstr));
  dtall=[];
  forall(1..(length(tmp1)-1),
    tmp=substring(dtstr,tmp1_#,tmp1_(#+1)-1);
    if(length(tmp)>0,
      dtall=append(dtall,tmp);
    );
  );
  out=[];
  forall(dtall,dt,
    tmp1=tokenize(dt,sep); //16.12.04
    tmp2=[];
    forall(tmp1,
      if(isstring(#),tmp=parse(#),tmp=#);
      if(!isreal(tmp),
        if(length(#)>0,tmp=#,tmp=rep);
      );
      tmp2=append(tmp2,tmp);
    );
    out=append(out,tmp2);
  );
  out;
);
////%Tab2list end////

////%Columnlist start////
Columnlist(dt,list):=( // 16.09.04
//help:Columnlist(dt,1..3);
  apply(dt,#_list);
);
////%Columnlist end////

////%Dispmat start////
Dispmat(dt):=( // 16.09.16
//help:Dispmat(dt);
  regional(htm,crm,lfm,row,tmp,tmp1,tmp2);
  htm=unicode("0009");
  crm=unicode("000d");
  lfm=unicode("000a");
  tmp2="";
  forall(dt,row,
    tmp1="";
    forall(row,
      if(isstring(#),
        tmp1=tmp1+#+htm;
      ,
        tmp1=tmp1+text(#)+htm;
      );
    );
    tmp1=substring(tmp1,0,length(tmp1)-1);
    tmp1=tmp1+lfm;
    tmp2=tmp2+tmp1;
  );
  print(tmp2);
  println();
);
////%Dispmat end////

////%Sep1000 start////
Sep1000(va):=( //17.07.18
//help:Sep1000(1344555);
//help:Sep1000([12456,55567]);
  regional(str,nall,out);
  if(islist(va),
    out=apply(va,Sep1000(#));
  ,
    str=text(va);
    nall=length(str);
    out="";
    forall(1..nall,
      out=str_(nall+1-#)+out;
      if((#<nall)&(mod(#,3)==0),
        out=","+out;
      );
    );
  );
  out;
);
////%Sep1000 end////

////%Acos start////
Acos(x):=(
//help:Acos(1.000001);
  re(arccos(x));
);
////%Acos end////

////%Asin start////
Asin(x):=(
//help:Asin(1.000001);
  re(arcsin(x));
);
////%Asin end////

////%Atan start////
Atan(x):=(
//help:Atan(1);
  re(arctan(x));
);
////%Atan end////

////%Sqr start////
Sqr(x):=(
//help:Sqr(-0.00001);
  if(x<0,0,sqrt(x));
);
////%Sqr end////

////%Factorial start////
Factorial(n):=(
//help:Factorial(5);
  regional(out);
  out=1;
  forall(1..n,
    out=out*#;
  );
  out;
);
////%Factorial end////

////%Norm start////
Norm(v1):=(  // 16.09.01
//help:Norm([2,1,3]);
  regional(out,tmp,tmp1,tmp2);
  out=0;
  forall(1..(length(v1)),
    out=out+(v1_#)^2;
  );
  out=sqrt(out);
  out;
);
Norm(v1,v2):=(
  Norm(v2-v1);
);
////%Norm end////

// 16.03.28
////%Removespace start////
Removespace(str):=(
//help:Removespace(" a b c  ");
  regional(tmp,flg,out);
  tmp=length(str)+1;
  flg=0;
  forall(1..(length(str)),
    if(flg==0,
      if((str_#)!=" ",
        tmp=#;
        flg=1;
      );
    );
  );
  out=substring(str,tmp-1,length(str));
  flg=0;
  tmp=0;
  forall(reverse(1..(length(out))),
    if(flg==0,
      if((out_#)!=" ",
        tmp=#;
        flg=1;
      );
    );
  );
  out=substring(out,0,tmp);
);
////%Removespace end////

////%Indexall start////
Indexall(str,key):=(
  regional(rest,out,flg,tmp,tmp1,);
  out=[];
  rest=str;
  flg=0;
  forall(1..(length(str)),
    if(flg==0,
      tmp=indexof(rest,key);
      if(tmp>0,
        tmp1=tmp+length(str)-length(rest);
        out=append(out,tmp1);
        rest=substring(rest,tmp,length(rest));
      ,
        flg=1;
      );
    );
  );
  out;
);
////%Indexall end////

////%Strsplit start////
Strsplit(str,key):=( //180505
//help:Strsplit(string,"=");
  regional(start,out,tmp1,tmp2);
  tmp1=Indexall(str,key);
  out=[]; start=0;
  forall(tmp1,
    out=append(out,substring(str,start,#-1));
    start=#;
  );
  out=append(out,substring(str,start,length(str)));
  out;
);
////%Strsplit end////

////%Parlevel start////
Parlevel(str):=Bracket(str); // 16.05.22from 
////%Parlevel end////
////%Bracket start////
Bracket(str):=Bracket(str,"()");
Bracket(str,br):=(
//help:Bracket(string,"()");
  regional(ph,pt,out,noL,ncL,nall,level,tmp);
  ph=substring(br,0,1);
  pt=substring(br,1,2);
  noL=Indexall(str,ph);
  ncL=Indexall(str,pt); // 16.05.22until
  nall=sort(concat(noL,ncL));
  level=0;
  out=[];
  forall(nall,
    if(contains(noL,#),
      level=level+1;
      tmp=[#,level];
    ,
      tmp=[#,-level];
      level=level-1;
    );
    out=append(out,tmp);
  );
  out;
);
////%Bracket end////

////%Pardiagram start////
Pardiagram(str):=Pardiagram(str,[20]);
Pardiagram(str,options):=(
//help:Pardiagram(exprstr);
//help:Pardiagram(options=[20,"Disp=y","Fig=y"]);
  regional(reL,eqL,len,disp,scheme,bra,nn,sta,out,
     opos,cpos,all,dx,dh,mxh,start,nn,p1,p2,p3,p4,tmp,tmp1,tmp2,tmp3);
  len=20;
  disp=1;
  scheme=1;
  tmp=Divoptions(options);
  eqL=tmp_5;
  reL=tmp_6;
  forall(eqL,
    tmp=indexof(#,"=");
    tmp1=Toupper(substring(#,0,1));
    tmp2=Toupper(substring(#,tmp,tmp+1));
    if(tmp1=="D",
      if(tmp2=="N" % tmp2=="F",disp=0);
    );
    if(tmp1=="F",
      if(tmp2=="N" % tmp2=="F",scheme=0);
    );
  );
  forall(reL,
    len=#;
  );
  bra=Bracket(str);
  tmp1=select(bra,#_2>0);
  tmp2=select(bra,#_2<0);
  out=[];
  forall(1..(length(tmp1)),nn,
    sta=tmp1_nn;
    tmp=select(tmp2,#_2==-sta_2 & #_1>sta_1);
    tmp=tmp_1;
    out=append(out, [substring(str,sta_1-1,tmp_1),
      nn,sta_2,sta_1,tmp_1,
      substring(str,sta_1-1,sta_1+len-1),
      substring(str,tmp_1-len,tmp_1)] );
  );
  if(disp==1,
    println("Printing from 2 to 7. (Extract full string using _1)");
    apply(out,println(#_(2..7)));
  );
  if(scheme==1,
    opos=sort(apply(out,#_4));
    cpos=sort(apply(out,#_5));
    tmp=concat(opos,cpos);
    all=sort(tmp);
    mxh=max(apply(out,#_3));
    dx=1;
    dh=1;
    start=[-5,5];
    forall(1..(length(all)),nn,
       tmp=select(out,#_4==all_nn);
      if(length(tmp)>0,
        tmp1=tmp_1_3;
        tmp2=tmp_1_4;
        tmp3=tmp_1_5;
        tmp=select(1..(length(all)),all_#==tmp3);
        tmp4=tmp_1;
        p1=start+[(nn-1)*dx,-0.5];
        p2=p1+[0,(tmp1-mxh-1)*dh];
        p3=p2+[(tmp4-nn)*dx,0];
        p4=p3+[0,(mxh+1-tmp1)*dh];
        Listplot("ch"+text(nn),[p1,p2,p3,p4],["Message=n"]);
        Letter([p2,"s",text(tmp2),p3,"s",text(tmp3)]);
        tmp=select(1..(length(opos)),opos_#==tmp2);
        tmp=tmp_1;
        if(tmp==1,
          tmp=substring(str,tmp2-1,tmp2);
        ,
          if(opos_(tmp-1)==opos_tmp-1,
            tmp=substring(str,tmp2-1,tmp2);
          ,
            tmp=substring(str,tmp2-2,tmp2);
          );
        );
        tmp=replace(tmp,"^","**");
        Expr(p1,"n",tmp);
        tmp=select(1..(length(cpos)),cpos_#==tmp3);
        tmp=tmp_1;
        if(tmp==length(cpos),
          tmp=substring(str,tmp3-1,tmp3);
        ,
          if(cpos_(tmp+1)==cpos_tmp+1,
            tmp=substring(str,tmp3-1,tmp3);
          ,
            tmp=substring(str,tmp3-1,tmp3+1);
          );
        );
        tmp=replace(tmp,"^","**");
        Expr(p4,"n",tmp);
      );  
    );
  );
  out;
);
////%Pardiagram end////

////%Changework start////
Changework():=Changework(""); //180618
Changework(dirorg):=Changework(dirorg,["Sub=y"]);
Changework(dirorg,options):=( //16.10.21
//help:Changework(directory);
//help:Changework(Dircdy+"fig");
//help:Changework(options=["Sub=n"(not to make folder fig]);
  regional(dir,subdir,tmp,,eqL,makesub);
  tmp=Divoptions(options);
  eqL=tmp_5;  //180605from
  makesub=1;
  forall(eqL,
    tmp=Strsplit(#,"=");
    tmp1=Toupper(substring(#,0,1)); //181111
    if(tmp1=="S",
      tmp=Toupper(tmp_2);
      if(substring(tmp,0,1)=="N",
        makesub=0;
      );
    );
  ); //180605to
  dir=replace(dirorg,"/",pathsep());//17.11.20from
  dir=replace(dir,"\",pathsep());
  dir=replace(dir,pathsep()+pathsep(),pathsep());//17.11.24
  tmp=length(dir);
  if(substring(dir,tmp-1,tmp)==pathsep(),
    dir=substring(dir,0,tmp-1);
  );//17.11.20until
  tmp=Indexall(dir,pathsep()); //17.11.24from
  subdir="";
  if(length(tmp)>0,
    tmp=tmp_(length(tmp));
    subdir=substring(dir,tmp,length(dir));
    dir=substring(dir,0,tmp-1);
  ); //17.11.24until
  if(dir=="" % !isexists(dir,""),
    if(dir=="", //180618from
      println("Dirwork="+Dqq(Dirwork));
    ,
      println("Directory "+dir+" not exist, so "+Dqq(Dirwork)+" not changed"); 
    ); //180618to
  ,
    if(length(subdir)>0,  //180605
      if(makesub==1,//180606from
        println(makedir(dir,subdir));
      );//180606
      Dirwork=dir+pathsep()+subdir;
    ,
      Dirwork=dir;
    ); //17.11.24until
    setdirectory(Dirwork);
    if(!iswindows(), //17.04.11
      if(!iskcexists(Dirwork),
        SCEOUTPUT = openfile(Shellparent); //190221
        closefile(SCEOUTPUT);
        println(setexec(Dirwork,Shellparent)); //190221
      );
    );
  );
);
////%Changework end////

////%Changestyle start////
Changestyle(nameL,style):=(
//help:Changestyle(["sgAB"],["da"]);
  regional(nmL,name,Ltype,Ltypeorg,Noflg,color,opcindy,tmp);
  tmp=Divoptions(style);
  Ltypeorg=tmp_1;
  Noflg=tmp_2;
  color=tmp_(length(tmp)-2);
  opcindy=tmp_(length(tmp));
  if(islist(nameL),nmL=nameL,nmL=[nameL]);
  forall(nmL,name,
    tmp=select(GCLIST,#_1==name);
    if(length(tmp)>0,
      Ltype=Ltypeorg;
      GCLIST=select(GCLIST,#_1!=name);
      COM2ndlist=select(COM2ndlist, //no ketjs
        (indexof(#,"("+name)==0)%(indexof(#,"Shade")>0)); // 15.05.23,16.12.13 //no ketjs
      if(Noflg<2,
        if(isstring(Ltype),
          if((Noflg==0)&(color!=KCOLOR), //180904 //no ketjs on
            Texcom("{");Com2nd("Setcolor("+color+")");//180722
          ); //no ketjs off
          Ltype=GetLinestyle(text(Noflg)+Ltype,name);
          if((Noflg==0)&(color!=KCOLOR), //180904 //no ketjs on
            Texcom("}");//180722
          ); //no ketjs off
        ,
          if(Noflg==1,Ltype=0);
        );
        GCLIST=append(GCLIST,[name,Ltype,opcindy]);
      );
    );
  );
);
////%Changestyle end////

////%Op start////
Op(n,object):=( //  16.05.25
//help:Op(4,[1,2,3,4]);
//help:Op(3,"abcd");
  regional(out);
  if(islist(object),
    out=object_n;
  ,
    if(isstring(object),
      out=substring(object,n-1,n);
    );
  );
  out;
);
////%Op end////

////%Ptselected start////
Ptselected():=Isptselected(allpoints());//180711[2lines] 
Ptselected(ptlist):=Isptselected(ptlist);
Isptselected():=Isptselected(allpoints()); //180706
Isptselected(ptlist):=(
//help:Ptselected();
//help:Isptselected();
 regional(flg);
 flg=0;
 forall(ptlist,
  if(flg==0,
    if(isselected(#),flg=1);
  );
 );
 if(flg==0,false,true);
);
////%Ptselected end////

////%Finddef start////
Finddef(G):=(
  regional(def,tmp,tmp1,tmp2,tmp3);
  if(isstring(G),tmp=parse(G),tmp=G);
  def=text(inspect(tmp,"definition"));
  tmp1=indexof(def,"(");
  tmp2=indexof(def,";");
  tmp3=indexof(def,")");
  tmp=[substring(def,0,tmp1-1)];
  if(tmp2>0,
    tmp=append(tmp,substring(def,tmp1,tmp2-1));
    if(indexof(def,")",tmp3+1)==0,
      tmp=append(tmp,substring(def,tmp2,tmp3-1));
    ,
      tmp=append(tmp,substring(def,tmp2,tmp3));
    );
  ,
    tmp=append(tmp,substring(def,tmp1-1,tmp3));
  );
  tmp;
);
////%Finddef end////

////%Findgeoinfo start////
Findgeoinfo(geo):=(
  regional(out,tmp,tmp1,tmp2);
  tmp=Finddef(geo);
  if(ispoint(parse(tmp_2)),
    out=[tmp_2,tmp_3];
  ,
    tmp1=Findgeoinfo(parse(tmp_2));
    if(ispoint(parse(tmp1_1)),
      out=[tmp1_1,tmp1_2];
    ,
      tmp2=Findgeoinfo(parse(tmp1_2));
      out=[tmp2_1,tmp2_2];
    );
  );
  if(ispoint(geo),
    if(!ispoint(parse(tmp_2)),
      tmp1=Finddef(parse(tmp_2));
    ,
      tmp1=tmp;
    );
    out=append(out,tmp1_3);
  ,
    out=append(out,tmp_3);
  );
  out;
);
////%Findgeoinfo end////

////%Dependgeo start////
Dependgeo(geo):=(
  regional(tmp,tmp1,tmp2,out);
  tmp=Finddef(geo);
  if(!iscircle(geo),
    out=[text(geo)];
  ,
    out=[geo];
  );
  if(length(tmp)<3,
    out=concat(out,[tmp_1,[]]);
  ,
    out=concat(out,[tmp_1]);
    tmp1=[tmp_2,tmp_3];
    tmp=parse(tmp1_2);
    if(islist(tmp) % isreal(tmp),
      tmp1=[tmp1_1];
    );
    out=append(out,tmp1);
  );
  out;
);
////%Dependgeo end////

////%Workprocess start////
Workprocess():=Drawprocess(300,["Disp=n"]); //181030
Workprocess(nn):=(
//help:Workprocess();
  Drawprocess(nn,["Disp=n"]); 
);
////%Workprocess end////
////%Drawprocess start////
Drawprocess():=Drawprocess(300,["Disp=y"]);
Drawprocess(nn):=Drawprocess(nn,["Disp=y"]);
Drawprocess(nn,options):=(
//help:Workprocess();
  regional(All,added,remain,out,flg,dispflg,eqL,tmp,tmp1,tmp2);
  tmp=Divoptions(options); //181030from
  eqL=tmp_5;
  dispflg="Y";
  forall(eqL,
    tmp=Strsplit(#,"=");
    tmp1=Toupper(substring(tmp_1,0,1));
    tmp2=Toupper(substring(tmp_2,0,1));
    if(tmp1=="D",dispflg=tmp2);
  ); //181030to
  tmp=remove(allpoints(),[NE,SW,TH,FI]);
  tmp1=select(tmp,
    substring(text(#),length(text(#))-1,length(text(#)))!="z");
  tmp1=concat(tmp1,alllines());
//  tmp1=concat(tmp1,allcircles());
  All=apply(tmp1,Dependgeo(#));
  added=select(All,length(#_3)==0);
  out=sort(apply(added,#_1));
  remain=remove(All,added);
  flg=0;
  repeat(nn,
    if(flg==0,
      tmp1=select(remain,remove(#_3,out)==[]);
      tmp2=sort(apply(tmp1,#_1));
      out=concat(out,tmp2);
      remain=remove(remain,tmp1);
      if(length(remain)==0,flg=1);
    );
  );
  if(dispflg=="Y",
    println("Process of drawing");
  );
  tmp1=[];//181030from
  forall(out,
    tmp=Dependgeo(parse(#));
    tmp1=append(tmp1,tmp);
    if(dispflg=="Y",
      println(Dependgeo(parse(#)));
    );
  );
  tmp1;//181030to
);
////%Drawprocess end////

////%Sortpointlist start////
Sortpointlist(list):=(
  regional(plist,ilist,jj,kk,flg,p1,p2,in1,in2,
    tmp,tmp1,tmp2,out);
  out=list;
  plist=list_1;
  ilist=list_2;
  flg=0;
  forall(1..(length(plist)),jj,
    p1=plist_jj;
    in1=ilist_jj;
    forall((jj+1)..(length(plist)),kk,
      if(flg==0,
        p2=plist_kk;
        in2=ilist_kk;
        if(contains(in1,p2),
          tmp1=plist_(1..(jj-1));
          tmp1=append(tmp1,p2);
          tmp1=concat(tmp1,plist_((jj+1)..(kk-1)));
          tmp1=append(tmp1,p1);
          tmp1=concat(tmp1,plist_((kk+1)..(length(plist))));
          tmp2=ilist_(1..(jj-1));
          tmp2=append(tmp2,in2);
          tmp2=concat(tmp2,ilist_((jj+1)..(kk-1)));
          tmp2=append(tmp2,in1);
          tmp2=concat(tmp2,ilist_((kk+1)..(length(plist))));
          out=Sortpointlist([tmp1,tmp2]);
          flg=1;
        );
      );
    );
  );
  out;
);
////%Sortpointlist end////

////%Toupper start////
Toupper(str):=(
//help:Toupper("Abc");
  regional(alphabet,out,tmp,tmp1);
  alphabet="abcdefghijklmnopqrstuvwxyz";
  out="";
  forall(1..(length(str)),
    tmp=substring(str,#-1,#);
    tmp1=indexof(alphabet,tmp);
    if(tmp1>0,
      out=out+unicode(text(tmp1+64),base->10);
    ,
      out=out+tmp;
    );
  );
  out;
);
////%Toupper end////

////%Textformat start////
Textformat(value,dig):=(
//help:Textformat(2/3,4);
//help:Textformat([gr1,gr2],5);
  regional(vv,tmp,tmp1);
  if(islist(value),
    tmp1="[";
    forall(value,
      tmp1=tmp1+Textformat(#,dig)+",";
    );
    if(length(tmp1)>1, //18.01.29from
      tmp1=substring(tmp1,0,length(tmp1)-1);
    );
    tmp1=tmp1+"]"; //18.01.29until
  ,
    if(ispoint(value) % isstring(value),
//      vv=Lcrd(value);
//      tmp1=Textformat(vv,dig);
//      tmp1=text(value);  // 15.04.07
      if(isstring(value),tmp1=Dq+value+Dq,tmp1=text(value)); // 15.10.02
    ,
      tmp1=format(value,dig);
    );
  );
  tmp1;
);
////%Textformat end////

////%Sprintf start////
Sprintf(value,dig):=(
//help:Sprintf(5.1,4);
  regional(vv,tmp,tmp1);
  if(!islist(value),  // 17.03.12from
    if(isstring(value),
      vv=value;
    ,
      vv=Textformat(value,dig);
    );  // 17.03.12from
    if(indexof(vv,".")==0,vv=vv+".");
    vv=vv+"0000000000000000";
    tmp=indexof(vv,".")+dig;
    vv=substring(vv,0,tmp);
  ,
    vv=apply(value,Sprintf(#,dig));
  );
  vv;
);
////%Sprintf end////

////%Assign start////
Assign(str):=( //190125from
  regional(tmp);
  tmp=[];
  forall(VLIST,tmp=concat(tmp,[#_1,#_2]));
  Assign(str,tmp);
); //190125to
Assign(funstr,vrL):=(
  regional(nn,out);
  nn=length(vrL)/2;
  out=funstr;
  forall(1..nn,
    out=Assign(out,vrL_(2*#-1),vrL_(2*#));
  );
  out;
);
Assign(funstr,varname,rep):=(
//help:Assign("x^2+a*x","a",1.3);
//help:Assign("a*x^2+b*x",["a",1,"b",2]);
  regional(repstr,ii,jj,tmp,tmp1,tmp2,Notvar,Flg);
  if(isstring(rep),repstr=rep,repstr="("+Textformat(rep,6)+")");
        // 15.02.09, 07.06,17.08.24
  tmp=[46];  // 12.20
  tmp=concat(tmp,48..57);
  tmp=concat(tmp,65..90);
  tmp=concat(tmp,97..122);
  Notvar=apply(tmp,unicode(text(#),base->10));
  tmp2="";
  forall(1..100,
    ii=indexof(funstr,varname);
    if(ii>0,
      Flg=0;
      if(ii>1,
        tmp=substring(funstr,ii-2,ii-1);
        if(contains(Notvar,tmp),
          tmp2=tmp2+substring(funstr,0,ii);
          funstr=substring(funstr,ii,length(funstr));
          Flg=1;
        );
      );
      if(Flg==0,
        jj=ii-1+length(varname);
        if(jj<length(funstr),
          tmp=substring(funstr,jj,jj+1));
          if(contains(Notvar,tmp),
          tmp2=tmp2+substring(funstr,0,jj);
          funstr=substring(funstr,jj,length(funstr));
          Flg=1;
        );
      );
      if(Flg==0,
        tmp2=tmp2+substring(funstr,0,ii-1)+repstr;
        funstr=substring(funstr,jj,length(funstr));
      );
    );
  );
  funstr=tmp2+funstr;
  funstr;
);
////%Assign end////

////%Measuredepth start////
Measuredepth(list):=(
  regional(tmp,tmp1,Depth,Flg);
  Flg=0;
  Depth=0;
  if(length(list)>0, //180501
    if(ispoint(list), 
      Depth=0;
      Flg=1;
    ,
      tmp1=select(1..(length(list)),length(list_#)>0);//17.05.21from
      tmp=list_(tmp1_1);//17.05.21until
    );
    repeat(4,
      if(Flg==0,
        if(islist(tmp),
          tmp=tmp_1;
          Depth=Depth+1;
        ,
          if(ispoint(tmp),Depth=Depth+1);
          Flg=1;
        );
      );
    );
  );//180501
  Depth;
);
////%Measuredepth end////

////%Flattenlist start////
Flattenlist(pltlist):=(
//help:Flattenlist([[2,3],[[1,2],[5,6]]]);
  regional(Out,nn,Dt,ii,tmp,flg);
  Out=[];
  if(Measuredepth(pltlist)==1,
    Out=[pltlist];
  ,
    forall(1..(length(pltlist)),nn,
      Dt=pltlist_nn;
      if(Measuredepth(Dt)<2,
        Out=append(Out,Dt);
      ,
        forall(1..(length(Dt)),ii,
          tmp=Flattenlist(Dt_ii);
          Out=concat(Out,tmp);
        );
      );
    );
  );
  Out;
);
////%Flattenlist end////

////%Divoptions start////
Divoptions(options):=(
//help:Divoptions(options);
  regional(Ltype,Noflg,Inflg,Outflg,eqL,realL,strL,color,opstr,opcindy,flg,
       tmp,tmp1,tmp2);
  Ltype="dr";  // 2015.01.13
  Noflg=0;
  Inflg=0;
  Outflg=0;
  eqL=[];
  realL=[];
  strL=[];
  color=KCOLOR; //180603
  opstr="";
  opcindy="";
  forall(options,
    flg=0;
    if(flg==0,
      if(isreal(#) % ispoint(#) % islist(#),
        realL=append(realL,#);
        opstr=opstr+","+text(#);
        flg=1;
      );
    );
    if(flg==0,
      if(indexof(#,"=")>0,
        tmp=Strsplit(#,"="); //180602from
        tmp1=Toupper(tmp_1);
        tmp2=tmp_2;
        if(tmp1=="COLOR",
          if(indexof(tmp2,"[")>0, //180928
            tmp1=parse(tmp2);
            color=tmp1;
            if(length(tmp1)==4,
              tmp1=Colorcmyk2rgb(tmp1);
            );
          ,
            tmp1=Colorname2rgb(tmp2); color=tmp1; //181212
         );
          tmp="color->"+text(tmp1);
          opcindy=opcindy+","+tmp;
        ,
          eqL=append(eqL,#);
        );//180602to
        flg=1; 
      );
    );
    if(flg==0,
      if(indexof(#,"no")+indexof(#,"No")>0,
        if(indexof(#,"tex")>0,Noflg=1);
        if(indexof(#,"disp")>0,Noflg=2);
        if(indexof(#,"data")>0,Noflg=3);
        flg=1;
      );
    );
    if(flg==0,
      if(indexof(#,"->")>0,
        opcindy=opcindy+","+#;
        flg=1; 
      );
    );
    if(flg==0,
      if(indexof(#,"out")+indexof(#,"Out")>0,
        if(indexof(#,"-")==0,
          Outflg=1;
        ,
          Outflg=2;
        );
        flg=1;
      );
    );
    if(flg==0,
      if(indexof(#,"in")+indexof(#,"In")>0,
        if(indexof(#,"-")==0,
          Inflg=1;
        ,
          Inflg=2;
        );
        flg=1;
      );
    );
    if(flg==0,
      tmp=substring(#,0,2);
      tmp1=indexof(tmp,"dr")+indexof(tmp,"Dr");
      tmp1=tmp1+indexof(tmp,"da")+indexof(tmp,"Da");
      tmp1=tmp1+indexof(tmp,"id")+indexof(tmp,"Id");
      tmp1=tmp1+indexof(tmp,"do")+indexof(tmp,"Do");
      tmp1=tmp1+indexof(tmp,"dp")+indexof(tmp,"Dp");
      if(tmp1>0,
        Ltype=#;
        flg=1;
      );
      if(flg==0,
        if(length(#)>0, //180408
          strL=append(strL,#);
          opstr=opstr+","+Dq+#+Dq;
        );
      );
    );
  );
  if(indexof(opcindy,"color->")==0,// 16.10.07from
    opcindy=opcindy+",color->"+text(KCOLOR);
  );
  [Ltype,Noflg,Inflg,Outflg,eqL,realL,strL,color,opstr,opcindy];
);
////%Divoptions end////

////%Dotprod start////
Dotprod(vec1,vec2):=(
//help:Dotprod(vec1,vec2);
  regional(v1,v2,tmp);
  if(ispoint(vec1),v1=vec1.xy,v1=vec1);
  if(ispoint(vec2),v2=vec2.xy,v2=vec2);
  v1*v2;
);
////%Dotprod end////

////%Crossprod start////
Crossprod(a,b):=(
//help:Crossprod(vec1,vec2);
  regional(tmp1,tmp2,tmp3,Out);
  if(length(a)==3,
    tmp1=a_2*b_3-a_3*b_2;
    tmp2=a_3*b_1-a_1*b_3;
    tmp3=a_1*b_2-a_2*b_1;
    Out=[tmp1,tmp2,tmp3];
  ,
    Out=a_1*b_2-a_2*b_1;
  );
  Out;
);
////%Crossprod end////

////%Mvprod start////
Mvprod(mat,vec):=( //190127
  regional(vecL);
  if(Measuredepth(vec)==0,vecL=[vec],vecL=vec);
  Mvprod(mat,vecL,length(vecL));
);
Mvprod(mat,vecL,nn):=(
//help:Mvprod(mat,vec(list));
  regional(tmp,out);
  if(nn==1,
    out=mat*vecL_1;
  ,
    out=[];
    forall(1..nn,
      tmp=mat*vecL_#;
      out=append(out,tmp);
    );
  );
  out;
);
////%Mvprod end////

////%Ptstart start////
Ptstart(Fig):=(
//help:Ptstart("gr1");
  regional(tmp);
  if(isstring(Fig),tmp=parse(Fig),tmp=Fig);  // 16.01.21
  tmp_1;
);
////%Ptstart end////

////%Ptend start////
Ptend(Fig):=(
//help:Ptend("gr1");
  regional(tmp);
  if(isstring(Fig),tmp=parse(Fig),tmp=Fig);
  tmp_(length(tmp)); // 15.04.12
);
////%Ptend end////

////%Numptcrv start////
Numptcrv(Fig):=(
//help:Numptcrv("gr1");
  regional(tmp);
  if(isstring(Fig),tmp=parse(Fig),tmp=Fig);  // 15.12.23
  length(tmp);
);
////%Numptcrv end////

////%Ptcrv start////
Ptcrv(Num,Fig):=(
//help:Ptcrv(10,"gr1");
  regional(tmp);
  if(isstring(Fig),tmp=parse(Fig),tmp=Fig);
  tmp_Num;
);
////%Ptcrv end////

////%Invert start////
Invert(Fig):=(
//help:Invert("gr1");
  regional(tmp);
  if(isstring(Fig),tmp=parse(Fig),tmp=Fig); // 16.01.27
  reverse(tmp);
);
Invert(nm,Fig):=Invert(nm,Fig,["nodisp"]);  // from 16.01.27
Invert(nm,Fig,options):=(
//help:Invert("1","gr1");
  regional(name,tmp);
  name="-inv"+nm;
  tmp=Invert(Fig);
  Listplot(name,tmp,options);
);// until 16.01.27
////%Invert end////

////%Paramoncrv start////
Paramoncrv(pP,Gdata):=Paramoncurve(pP,Gdata);//180723
////%Paramoncrv end////
////%Paramoncurve start////
Paramoncurve(point,Gdata):=(
//help:Paramoncurve(A,"gr1");//180723[3lines]
  regional(Tmp,PtL,pP);
  if(ispoint(point),pP=point.xy,pP=point);
//  Eps=10^(-8);
  if(isstring(Gdata),PtL=parse(Gdata),PtL=Gdata);
  Tmp=Nearestpt(pP,PtL);
  Tmp_2;
);
Paramoncurve(pP,nN,plist):=(
//help:Paramoncurve(A,10,"gr1");
  regional(PtL,Out,Pa,Pb,vV,vW,sS);
  if(isstring(plist),PtL=parse(plist),PtL=plist);
  PtL=apply(PtL,LLcrd(#));//16.10.16
  if(nN==length(PtL),
    Out=nN;
  ,
    Pa=PtL_nN;
    Pb=PtL_(nN+1);
    vV=Pb-Pa;
    vW=pP-Pa;
    sS=vV*vW/|vV|^2;
    sS=min([max([sS,0]),1]);
    Out=nN+sS;
  );
  Out;
);
////%Paramoncurve end////

////%Pointoncrv start////
Pointoncrv(tT,PtL):=Pointoncurve(tT,PtL);
////%Pointoncrv end////
////%Pointoncurve start////
Pointoncurve(tTorg,Gdata):=(
//help:Pointoncurve(20.5,"gr1");
  regional(tT,Out,Eps,nN,sS,Pa,Pb,PtL);
  if(isstring(Gdata),PtL=parse(Gdata),PtL=Gdata);
  if(length(PtL)==1,PtL=PtL_1);
  tT=max([tTorg,1]); //18.01.04
  tT=min([tT,length(PtL)]); //18.01.04
  Eps=10^(-5); //18.01.04
  nN=floor(tT+Eps);
  sS=max([tT-nN,0]);
  if(nN==length(PtL),
    Out=PtL_nN;
  ,
    Pa=PtL_nN;
    Pb=PtL_(nN+1);
    Out=(1-sS)*Pa+sS*Pb;
  );
  Out;
);
////%Pointoncurve end////

////%Koutenseg start////
Koutenseg(pA,pB,pC,pD):=Koutenseg(pA,pB,pC,pD,[]);
Koutenseg(pA,pB,pC,pD,options):=(
  regional(Eps0,Eps,Eps2,pV,Sv2,Out,pP,pQ,Flg,p1,p2,q1,q2,
          em1,eM1,em2,eM2,rT,Tmp1,Tmp2);
  Eps0=10^(-4);
  pV=pB-pA;
  Sv2=|pV|;
  pP=pC-pA; pQ=pD-pA;
  Eps=10^(-3);
  Eps2=0.2;
  Tmp1=0;
  forall(options,
    if(Tmp1==0,
      Eps=#;
      Tmp1=1;
    ,
      Eps2=#;
    );
  );
  Flg=0;
  if(Sv2<10^(-3),
     Out=["inf","inf"];
     Flg=1;
  );
  if(Flg==0,
    Eps=min([Eps2,Eps/Sv2]);
    p1=pP*pV/Sv2^2;
    p2=[pP_2,-pP_1]*pV/Sv2^2;
    q1=pQ*pV/Sv2^2;
    q2=[pQ_2,-pQ_1]*pV/Sv2^2;
    em1=-Eps; eM1=1+Eps;
    em2=-Eps; eM2=Eps;
    if(max([p1,q1])<em1 % min([p1,q1])>eM1,
      Out=["inf","inf"];
      Flg=1;
    );
    if(max([p2,q2])<em2 % min([p2,q2])>eM2,
      Out=["inf","inf"];
      Flg=1;
    );
  );
  if(Flg==0 & p2*q2<0,
    rT=p1-(q1-p1)/(q2-p2)*p2;
    if(rT>em1 & rT<eM1,
      if(rT>-Eps0 & rT<1+Eps0,
        Tmp1=pA+rT*pV;
        Tmp2=min([max([rT,0]),1]);
        Out=[Tmp1,Tmp2,0];
      ,
        Tmp1=pA+rT*pV;
        Tmp2=min([max([rT,0]),1]);
        Out=[Tmp1,Tmp2,1];
      );
      Flg=1;
    );
    if(Flg==0 & (p1<em1 % p1>eM1 % p2<em2 % p2>eM2),
      if(q1<em1 % q1>eM1 % q2<em2 % q2>eM2,
         Out=["inf","inf"];
         Flg=1;
      );
      if(Flg==0,
        rT=min([max([p1,0]),1]);
        Tmp1=pA+rT*pV;
        Out=[Tmp1,rT,1];
        Flg=1;
      );
    );
  );
  if(Flg==0 & (p1 > -Eps0 & p1 < 1 + Eps0 & p2 > -Eps0 & p2 < Eps0),
    rT= p1;
    Tmp1=pA+rT*pV;
    Out= [Tmp1, rT, 0];
    Flg=1;
  );
  if(Flg==0 & (q1 > -Eps0 & q1 < 1 + Eps0 & q2 > -Eps0 & q2 < Eps0),
    rT= q1;
    Tmp1=pA+rT*pV;
    Out=[Tmp1,rT,0];
    Flg=1;
  );
  if(Flg==0 & (p1<em1 %  p1>eM1 % p2<em2 % p2>eM2),
    if(q1<em1 % q1>eM1 % q2<em2 % q2>eM2,
      Out=["inf","inf"];      
      Flg=1;
    );
    if(Flg==0,
      rT=min([max([q1,0]),1]);
      Tmp1=pA+rT*pV;
      Out=[Tmp1,rT,1];
      Flg=1;
    );
  );
  if(Flg==0 & (q1<em1 %  q1>eM1% q2<em2 % q2>eM2),
    rT=min([max([p1,0]),1]);
    Tmp1=pA+rT*pV;
    Out=[Tmp1,rT,1];
    Flg=1;
  );
  if(Flg==0,
    if(abs(p2)<abs(q2),
      rT=min([max([p1,0]),1]);
    ,
      rT=min([max([q1,0]),1]);
    );
    Tmp1=pA+rT*pV;
    Out=[Tmp1,rT,1];
  );
 Out;
);
////%Koutenseg end////

///////// Start of old Intersect ////////////

////%IntersectcrvsPp start////
IntersectcrvsPp(Gr1,Gr2):=IntersectcrvsPp(Gr1,Gr2,[]);
IntersectcrvsPp(Gr1,Gr2,options):=(
//help:IntersectcrvsPp("gr1","pa1");
//help:IntersectcrvsPp(options=[Eps2(0.1),"Dif=0.05"]);
  regional(Out,Eps,Eps2,Eps0,Flg,Data1,Data2,
    Tmp1,Tmp2,Tmp3,Tmp,KL1,KL2,pA,pB,Ni,Nj,
    pP,pQ,rT,Flg,eqL,realL,opstr,Dif);
  Eps=10^(-4);
  Eps2=0.1;
  Dif=0.05; // 2015.05.31
  Flg=0;
  Tmp1=Divoptions(options); // 
  eqL=Tmp1_5;
  realL=Tmp1_6;
  opstr=Tmp1_(length(Tmp1));
  forall(eqL,
    if(substring(#,0,1)=="D",
      Tmp1=indexof(#,"=");
      Dif=parse(substring(#,Tmp1,length(#)));
    );
  );
  Tmp1=length(realL);
  if(Tmp1>0,
    Eps=realL_1;
    if(Tmp1>1,
      Eps2=realL_2;
    );
  );
  Flg=0;
  if(isstring(Gr1),Data1=parse(Gr1),Data1=Gr1);
  if(isstring(Gr2),Data2=parse(Gr2),Data2=Gr2);
  if(Measuredepth(Data1)==2,Data1=Data1_1);
  if(Measuredepth(Data2)==2,Data2=Data2_1);
  Data1=apply(Data1,LLcrd(#));
  Data2=apply(Data2,LLcrd(#));
  if(length(Data1)==length(Data2),
    Tmp1=reverse(Data2); 
    Eps0=10^(-6);
    Tmp2=0;
    forall(1..(length(Data1)),
      Tmp2=Tmp2+abs(Data1_#-Data2_#);
    );
    Tmp3=0;
    forall(1..(length(Data1)),
      Tmp3=Tmp3+abs(Data1_#-Tmp1_#);
    );
    if(Tmp2<Eps0 % Tmp3<Eps0,
      Out=[];
      Flg=1;
    );
  );
  if(Flg==0,
    KL1=[];
    KL2=[];
    forall(1..(length(Data1)-1),Ni,
      pA=Data1_Ni;
      pB=Data1_(Ni+1);
      forall(1..(length(Data2)-1),
        pP=Data2_#; pQ=Data2_(#+1);
        Tmp=Koutenseg(pA,pB,pP,pQ,[Eps,Eps2]);
        if(Tmp!=["inf","inf"],
          if(Tmp_3==0,
            Tmp1=[Tmp_1,Tmp_2,Ni,#];
            KL1=concat(KL1,[Tmp1]);
          ,
            Tmp2=[Tmp_1,Tmp_2,Ni,#];
            KL2=concat(KL2,[Tmp2]);
          );
        );
      );
    );
    Out=[];
    if(length(KL1)>0,
      Tmp=KL1_1;
      pP=Tmp_1;
      rT=Tmp_2;
      Ni=Tmp_3;
      Nj=Tmp_4;
      Tmp=[pP,Ni+rT,Nj];
      Out=[Tmp];
    );
    forall(2..(length(KL1)),Ni, 
      Tmp=KL1_Ni; 
      pP=Tmp_1;
      Tmp2=0;
      Flg=0;
      forall(1..(length(Out)),Nj,
        if(Flg==0,
          Tmp=Out_Nj;
          if(|pP-Tmp_1|<Eps,
            Tmp2=1;
            Flg=1;
          );
        );
      );
      if(Tmp2==0,
        Tmp=KL1_Ni; 
        pP=Tmp_1;
        rT=Tmp_2;
        Tmp1=Tmp_3;
        Tmp2=Tmp_4;
        Tmp=[pP,Tmp1+rT,Tmp2];
        Out=concat(Out,[Tmp]);
      );
    );
    forall(1..(length(KL2)),Ni,
      Tmp=KL2_Ni;  // 15.11.21 Usui
      pP=Tmp_1; 
      Tmp2=0;
      Flg=0;
      forall(1..(length(Out)),Nj,
        if(Flg==0,
          Tmp=Out_Nj;
          if(|pP-Tmp_1|<Eps,
            Tmp2=1;
            Flg=1;
          );
        );
      );
      if(Tmp2==0,
        Tmp=KL2_Ni;
        rT=Tmp_2;
        rT=min([max([rT,0]),1]);  // 15.11.21 Usui
        Tmp=[pP,Tmp_3+rT,Tmp_4];
        Out=concat(Out,[Tmp]);
      );
    );
  );
  Tmp1=Out;  // 15.04.06 from
  Out=[];
  forall(Tmp1,Tmp2,
    Tmp3=select(1..(length(Out)),//16.11.27,
        |Out_#_1-Tmp2_1|<Dif & |Out_#_2-Tmp2_2|<=1& |Out_#_3-Tmp2_3|<=1);
                 //17.04.13
    if(length(Tmp3)==0,
      Out=append(Out,Tmp2);
    ,
      forall(Tmp3, //16.11.27
        Out_#_1=(Out_#_1+Tmp2_1)/2;//17.04.14
      );
    );
  ); // 15.04.06 until
  Out;
);
////%IntersectcrvsPp end////

////%Intersectcrvs start////
Intersectcrvs(Gr1,Gr2):=Intersectcrvs(Gr1,Gr2,[]);
//help:Intersectcrvs("gr1","pa1");
Intersectcrvs(Gr1,Gr2,options):=(
  regional(tmp,tmp1,tmp2);
  tmp1=IntersectcrvsPp(Gr1,Gr2,options);
  apply(tmp1,#_1);
);
////%Intersectcrvs end////

///////// End of old Intersect ////////////

/////////// Start of new Intersect //////////////

////%Intersectline start////
Intersectline(p1,v1,p2,v2):=(
  regional(Eps,d,dt,ds,t,s,pt,out,tmp,tmp1,tmp2,tmp3);
  Eps=10^(-5);
  out=[];
  tmp=Dotprod(v1,v2);
  tmp1=[tmp,|v1|^2];
  tmp2=[-|v2|^2,-tmp];
  tmp3=[Dotprod(p2-p1,v2),Dotprod(p2-p1,v1)];
  d=Crossprod(tmp1,tmp2);
  tmp=abs(Crossprod(v1,v2));
  if(tmp>Eps,
    dt=Crossprod(tmp3,tmp2);
    ds=Crossprod(tmp1,tmp3);
    t=dt/d;
    s=ds/d;
    pt=p1+v1*t;
    out=[pt,t,s];
  ,
    tmp1=Crossprod(p2-p1,v1)/|v1|; //18.01.05
    out=[abs(tmp1)]; //18.01.05
  );
  out;
);
////%Intersectline end////

////%Intersectseg start////
Intersectseg(seg1,seg2):=Intersectseg(seg1,seg2,0.01);
Intersectseg(seg1org,seg2org,Eps1):=(
  regional(Eps,seg1,seg2,p1,p2,q1,q2,t,s,pt,n,pts,out,dist,
    tmp,tmp1,tmp2,tmp3);
  Eps=10^(-4);
  //Eps1=0.01;
  seg1=seg1org;
  seg2=seg2org;
  if(isstring(seg1),seg1=parse(seg1));
  if(isstring(seg2),seg2=parse(seg2));
  out=[];
  p1=seg1_1; q1=seg1_2;
  p2=seg2_1; q2=seg2_2;
  if((|q1-p1|<Eps)%(|q2-p2|<Eps),
    out=[-1];
  ,
    tmp=Intersectline(p1,q1-p1,p2,q2-p2);
    if(islist(tmp_1),
      pt=tmp_1; t=tmp_2; s=tmp_3;
      if((t*(t-1)<Eps)&(s*(s-1)<Eps),
        out=[0,pt,t,s];
      ,
        t=min([max([t,0]),1]);
        s=min([max([s,0]),1]);
        tmp3=[|p1-p2|,|p1-q2|,|q1-p2|,|q1-q2|]; //18.01.30from
        tmp1=[Op(2,q2-p2),-Op(1,q2-p2)];
        tmp=Intersectline(p1,tmp1,p2,q2-p2);
        if(islist(tmp_1),
          if(tmp_3*(tmp_3-1)<Eps,
            tmp3=append(tmp3,|tmp_1-p1|);
          );
        );
        tmp=Intersectline(q1,tmp1,p2,q2-p2);
        if(islist(tmp_1),
          if(tmp_3*(tmp_3-1)<Eps,
            tmp3=append(tmp3,|tmp_1-q1|);
          );
        );
        tmp1=[Op(2,q1-p1),-Op(1,q1-p1)];
        tmp=Intersectline(p2,tmp1,p1,q1-p1);
        if(islist(tmp_1),
          if(tmp_3*(tmp_3-1)<Eps,
            tmp3=append(tmp3,|tmp_1-p2|);
          );
        );
        tmp=Intersectline(q2,tmp1,p1,q1-p1);
        if(islist(tmp_1),
          if(tmp_3*(tmp_3-1)<Eps,
            tmp3=append(tmp3,|tmp_1-q2|);
          );
        );
        out=[min(tmp3),pt,t,s]; //18.01.30until
      );
    ,
      dist=tmp_1;
      tmp1=q1-p1;      
      n=[tmp1_2,-tmp1_1]/|tmp1|;
      pts=[];
      tmp=Intersectline(p1,n,p2,q2-p2);
      if(tmp_3*(tmp_3-1)<Eps,
        tmp1=(1-tmp_3)*p2+tmp_3*q2;
        pts=append(pts,[tmp1,0,tmp_3]);
      );
      tmp=Intersectline(q1,n,p2,q2-p2);
      if(tmp_3*(tmp_3-1)<Eps,
        tmp1=(1-tmp_3)*p2+tmp_3*q2;
        pts=append(pts,[tmp1,1,tmp_3]);
      );
      tmp=Intersectline(p2,n,p1,q1-p1);
      if(tmp_3*(tmp_3-1)<Eps,
        tmp1=(1-tmp_3)*p1+tmp_3*q1;
        pts=append(pts,[tmp1,tmp_3,0]);
      );
      tmp=Intersectline(q2,n,p1,q1-p1);
      if(tmp_3*(tmp_3-1)<Eps,
        tmp1=(1-tmp_3)*p1+tmp_3*q1;
        pts=append(pts,[tmp1,tmp_3,2]);
      );
      if(length(pts)==0,
        tmp1=min([|p2-p1|,|q2-p1|,|p2-q1|,|q2-q1|]);
        out=[tmp1];
      ,
        if(dist>Eps1,
          out=[dist];
        ,
          tmp=apply(pts,#_1_1);
          tmp1=sum(tmp)/(length(pts));
          tmp=apply(pts,#_1_2);
          tmp2=sum(tmp)/(length(pts));
          tmp3=[tmp1,tmp2];
          tmp=Nearestpt(tmp3,seg1);
          tmp1=tmp_2;
          tmp=Nearestpt(tmp3,seg2);
          tmp2=tmp_2;
          out=[dist,tmp3,tmp1,tmp2];
        );
      );
    );
  );
  out;
);
////%Intersectseg end////

////%Osplineseg start////
Osplineseg(list):=Osplineseg(list,[]);
Osplineseg(ptlist,optionsorg):=(
  regional(tmp,tmp1,tmp2,list,ptL,ctrL,Eps,Eps0,
      p0,p1,p2,p3,pQ,pR,cc,p01,p02,p11,p12,p21,p22,p31,p32,out);
  Eps=10^(-2);
  Eps0=10^(-6);
  if(isstring(ptlist),list=parse(ptlist),list=ptlist);
  p0=list_1; p1=list_2; p2=list_3; p3=list_4;
  tmp=1+sqrt((1+Dotprod(p2-p0,p3-p1)/|p2-p0|/|p3-p1|)/2);
  cc=4*|p2-p1|/3/(|p2-p0|+|p3-p1|)/tmp;
  pQ=p1+cc*(p2-p0); // 15.09.21  // 16.08.16
  pR=p2+cc*(p1-p3);  // 16.08.16
  ctrL=[pQ,pR];
  options=optionorg;
  options=concat(options,["Num=20","nodata"]);
  out=Bezier("",[p1,p2],ctrL,options);
  out;
);
////%Osplineseg end////

////%Intersectpartseg start////
Intersectpartseg(crv1,crv2,ii,jj,Eps1,Eps2):=(
  Intersectpartseg(crv1,crv2,ii,jj,Eps1,Eps2,10*Eps2);
);
Intersectpartseg(crv1org,crv2org,ii,jj,Eps1,Eps2,Dist):=(
  regional(crv1,crv2,Eps,dst,kk,ll,seg1,seg2,snang,
     p0,p1,p2,p3,os1,os2,out,tmp,tmp1,tmp2,flg);
  crv1=crv1org; crv2=crv2org;
  if(isstring(crv1),crv1=parse(crv1));
  if(isstring(crv2),crv2=parse(crv2));
  Eps=10^(-4);
//  Eps1=0.01;
//  Eps2=0.1;
//  Dist=10*Eps2;
  out=[];
  seg1=[crv1_ii,crv1_(ii+1)];
  seg2=[crv2_jj,crv2_(jj+1)];
  tmp1=seg1_2-seg1_1;
  tmp2=seg2_2-seg2_1;
  snang=abs(Crossprod(tmp1,tmp2))/(Norm(tmp1)*Norm(tmp2));
  tmp=Intersectseg(seg1,seg2,Eps1);
  dst=tmp_1;
  if(dst<Eps,
    out=[tmp_2,ii+tmp_3,jj+tmp_4,dst,snang];
  ,
    if(dst<Eps2,
      if((length(crv1)==2)%(|seg1_2-seg1_1|>Dist-Eps),
        os1=seg1;
      ,
        p1=seg1_1; p2=seg1_2;
        if(ii==1,
          p3=crv1_3;
          tmp=p2-p1;
          tmp=(p1+p2)/2+[tmp_2,-tmp_1];
          p0=Reflectpoint(p3,[(p1+p2)/2,tmp]);
        ,
          if(ii==length(crv1)-1,
            p0=crv1_(ii-1);
            tmp=p2-p1;
            tmp=(p1+p2)/2+[tmp_2,-tmp_1];
            p3=Reflectpoint(p0,[(p1+p2)/2,tmp]);
          ,
            p0=crv1_(ii-1); p3=crv1_(ii+2);
          );
        );
        os1=Osplineseg([p0,p1,p2,p3]);
      );
      if((length(crv2)==2)%(|seg2_2-seg2_1|>Dist-Eps), //18.01.05
        os2=seg2;
      ,
        p1=seg2_1; p2=seg2_2;
        if(jj==1,
          p3=crv2_3;
          tmp=p2-p1;
          tmp=(p1+p2)/2+[tmp_2,-tmp_1];
          p0=Reflectpoint(p3,[(p1+p2)/2,tmp]);
        ,
          if(jj==length(crv2)-1,
            p0=crv2_(jj-1);
            tmp=p2-p1;
            tmp=(p1+p2)/2+[tmp_2,-tmp_1];
            p3=Reflectpoint(p0,[(p1+p2)/2,tmp]);
          ,
            p0=crv2_(jj-1); p3=crv2_(jj+2);
          );
        );
        os2=Osplineseg([p0,p1,p2,p3]);
      );
      tmp2=[];
      forall(1..(length(os1)-1),kk,
        forall(1..(length(os2)-1),ll,
          seg1=[os1_kk,os1_(kk+1)];
          seg2=[os2_ll,os2_(ll+1)];
          tmp=Intersectseg(seg1,seg2,Eps1);
          if((tmp_1<Eps1)&(length(tmp)>1), //18.02.06
            if(tmp_1<dst+Eps,
              dst=tmp_1;
              tmp2=select(tmp2,#_1<dst);
              tmp2=append(tmp2,[dst,tmp_2]);
            );
          );
        );
      );
      if(length(tmp2)>0,
        tmp=apply(tmp2,#_2_1);
        tmp1=[sum(tmp)/length(tmp2)];
        tmp=apply(tmp2,#_2_2);
        tmp1=append(tmp1,sum(tmp)/length(tmp2));
        out=[tmp1];
        p1=crv1_ii; p2=crv1_(ii+1);
        tmp=[Op(2,p2-p1),-Op(1,p2-p1)];
        tmp=Intersectline(out_1,tmp,p1,p2-p1);
        tmp=min([max([tmp_3,0]),1]);
        out=[tmp1,ii+tmp];
        p1=crv2_jj; p2=crv2_(jj+1);
        tmp=[Op(2,p2-p1),-Op(1,p2-p1)];
        tmp=Intersectline(out_1,tmp,p1,p2-p1);
        tmp=min([max([tmp_3,0]),1]);
        out=concat(out,[jj+tmp,dst,snang]);
      );
    );
  );
  out;
);
////%Intersectpartseg end////

////%Collectsameseg start////
Collectsameseg(ptdL):=(
  regional(Eps,gL,rL,numL,ii,jj,flg,tmp,tmp1,tmp2,tmp1md,
       dst,kk,s1,e1,s2,e2);
  Eps00=10^(-8);
  if(length(ptdL)==0,
    gL=[];rL=[];
  ,
    tmp1md=[ptdL_1];
    rL=ptdL_(2..(length(ptdL)));
    tmp1=tmp1md_1;
    kk=floor(tmp1_2);
    if(tmp1_2<kk+Eps00,
      s1=kk-1-Eps00; e1=s1+2+2*Eps00;
    ,
      s1=kk-Eps00; e1=s1+1+2*Eps00;
    );
    kk=floor(tmp1_3);
    if(tmp1_3<kk+Eps00,
      s2=kk-1-Eps00; e2=s2+2+2*Eps00;
    ,
      s2=kk-Eps00; e2=s2+1+2*Eps00;
    );
    numL=[];
    forall(1..(length(rL)),ii,
      tmp=rL_ii;
      tmp1=tmp_2;tmp2=tmp_3;
      if((tmp1>s1)&(tmp1<e1)&(tmp2>s2)&(tmp2<e2),
        tmp1md=append(tmp1md,tmp);
        numL=append(numL,ii);
      );
    );
    gL=[];
    tmp=apply(tmp1md,#_4);
    dst=min(tmp);
    forall(tmp1md,
      if(#_4<dst+Eps00,
        gL=append(gL,#);
      );
    ); 
    rL=remove(rL,rL_(numL));
  );
  [gL,rL];
);
////%Collectsameseg end////

////%IntersectcurvesPp start////
IntersectcurvesPp(crv1org,crv2org):=IntersectcurvesPp(crv1org,crv2org,[]);
IntersectcurvesPp(crv1org,crv2org,options):=(
//help:IntersectcurvesPp(crv1,crv2);
//help:IntersectcurvesPp(options=[Eps1(0.01),Eps2(0.1),Dist(2)])
  regional(Eps,Eps1,Eps2,Dist,crv1,crv2,ii,jj,seg1,seg2,self,loopL,out,
          flg,tmp,tmp1,tmp2);
  Eps=10^(-4);
  Eps1=0.01;
  Eps2=0.1;
  Dist=10*Eps2;
  if(length(options)>0,
    Eps1=options_1;
    if(length(options)>1,
      Eps2=options_2;
      Dist=10*Eps2;
      if(length(options)>2,
        Dist=options_3;
      );
    );
  );
  if(isstring(crv1org),tmp1=parse(crv1org),tmp1=crv1org);//18.01.05from
  if(isstring(crv2org),tmp2=parse(crv2org),tmp2=crv2org);
  tmp1=apply(tmp1,LLcrd(#));
  tmp2=apply(tmp2,LLcrd(#));
  crv1=[tmp1_1];
  forall(tmp1,
    tmp=crv1_(length(crv1));
    if(|tmp-#|>Eps,
      crv1=append(crv1,#);
    );
  );
  crv2=[tmp2_1];
  forall(tmp2,
    tmp=crv2_(length(crv2));
    if(|tmp-#|>Eps,
      crv2=append(crv2,#);
    );
  );//18.01.05until
  if(crv1==crv2,
    self=1;
  ,
    self=0;
  );
  out=[];
  forall(1..(length(crv1)-1),ii,
    if(self==0,
      loopL=1..(length(crv2)-1);
    ,
      loopL=(ii+2)..(length(crv2)-1);
    );
    forall(loopL,jj,
      tmp=Intersectpartseg(crv1,crv2,ii,jj,Eps1,Eps2,Dist);
      if(length(tmp)>0,
        if(length(out)==0,
          out=[tmp];
        ,
          tmp1=out_(length(out));
          if(|tmp1_1-tmp_1|>Eps1,
            out=append(out,tmp);
          );
        );
        if(self==1,
          tmp=[tmp_1,tmp_3,tmp_2,tmp_4,tmp_5];
          out=append(out,tmp);
        );
      );
    );
  );
  tmp2=out;
  out=[];
  tmp1=tmp2;
  flg=0;
  forall(1..(length(tmp2)),
    if(flg==0,
      tmp=Collectsameseg(tmp1);
      out=append(out,tmp_1);
      if(length(tmp_2)==0,
        flg=1;
      ,
        tmp1=tmp_2;
      );
    );
  );
  forall(1..(length(out)),ii,
    tmp1=out_ii;
    if(length(tmp1)==1,
      out_ii=tmp1_1;
    ,
      tmp=apply(tmp1,#_4);
      dst=min(tmp);
      tmp1=select(tmp1,#_4<dst+Eps);
      tmp=apply(tmp1,#_1);
      tmp=sum(tmp)/length(tmp);
      tmp2=[tmp];
      tmp=Nearestpt(tmp2_1,crv1org);
      tmp2=append(tmp2,tmp_2);
      tmp=Nearestpt(tmp2_1,crv2org);
      tmp2=append(tmp2,tmp_2);
      tmp2=concat(tmp2,[dst,tmp1_1_5]);
      out_ii=tmp2;
    );
  );
  if(length(out)>0,  //190221from
    out=sort(out,[#_2]);
  );  //190221to
  out;
);
////%IntersectcurvesPp end////

////%Intersectcurves start////
Intersectcurves(crv1org,crv2org):=Intersectcurves(crv1org,crv2org,[]);
Intersectcurves(crv1org,crv2org,options):=(
//help:Intersectcurves(crv1,crv2);
//help:Intersectcurves(options=[Eps1(0.1),Dist(2)])
  regional(tmp);
  tmp=IntersectcurvesPp(crv1org,crv2org,options);
  tmp=apply(tmp,#_1);
);
////%Intersectcurves end////

///////////End of new Intersect //////////////

////%NearestptcrvPhy start////
NearestptcrvPhy(point,PL):=(
  regional(tmp,pP,plist);
  pP=Pcrd(point);
  if(isstring(PL),plist=parse(PL),plist=PL);
  if(Measuredepth(plist)==2,plist=plist_1);
  plist=apply(plist,#);  // 14.12.18
  tmp=Nearestpt(pP,plist);
  tmp=tmp_1;
  [tmp_1/SCALEX,tmp_2/SCALEY];
);
////%NearestptcrvPhy end////

////%Nearestptcrv start////
Nearestptcrv(point,plist):=(
//help:Nearestptcrv(A,"gr1");
  regional(tmp,pt);//180723[3lines]
  if(ispoint(point),pt=point.xy,pt=point);
  tmp=Nearestpt(pt,plist);
  tmp_1;
);
////%Nearestptcrv end////

////%Nearestpt start////
Nearestpt(point,PL2):=(
  regional(PL1,PL,Ans,Flg,Eps,pA,Pm,Im,Sm,Nn,Ni,
      a1,b1,a2,b2,v1,v2,x1,x2,Tmp,rT,pP,sS,Lm,Pm,Sm,Flg);
//help:Nearestpt("gr1","gr2");
  if(isstring(point),PL1=parse(point),PL1=point);
  if(Measuredepth(PL1)==2,PL1=PL1_1);
  if(!islist(PL1_1),
    PL1=[PL1];
    Flg=0;
  ,
    Flg=1;
  );
  if(isstring(PL2),PL=parse(PL2),PL=PL2);
  if(Measuredepth(PL)==2,PL=PL_1);
  Eps=10^(-6);
  Ans=[PL1_1,1,PL_1,1,|PL1_1-PL_1|];
  forall(1..(length(PL1)),Nn, // 16.05.04
    pA=PL1_Nn;
    Pm=PL_1;
    Im=1;
    Sm=|Pm-pA|;
    forall(1..(length(PL)-1),Ni,
      a1=PL_Ni_1; a2=PL_Ni_2;
      b1=PL_(Ni+1)_1; b2=PL_(Ni+1)_2;
      v1=b1-a1; v2=b2-a2;
      x1=pA_1; x2=pA_2;
      Tmp=v2^2+v1^2;
      if(abs(Tmp)>Eps,
        rT=(-a2*v2-v1*a1+v1*x1+x2*v2)/Tmp;
        if(rT<-Eps,
          pP=[a1,a2];
        ,
          if(rT>1+Eps,
            pP=[b1,b2];
          ,
            pP=[a1+rT*v1,a2+rT*v2];
          );
        );
        sS=|pP-pA|;
        if(sS<Sm-Eps,
          Tmp=Paramoncurve(pP,Ni,PL);
          Pm=pP; Lm=Tmp; Sm=sS;
        );
      );
      if(Sm<Ans_5,  // 16.05.03from
        Ans=[pA,Nn,Pm,Lm,Sm];
      );
    );  // 16.05.03until
  );
  if(Flg==0,
    Ans=Ans_(3..5);
  );
  Ans;
);
////%Nearestpt end////

////%Derivative start////
Derivative(pdstr,ptinfo):=Derivative(pdstr,ptinfo,[]);//180719
Derivative(Arg1,Arg2,Arg3):=(//1807120
//help:Derivative(plotdata,"x=2");
//help:Derivative(plotdata,"y=1");
  regional(pdstr,ptinfo,options,name,v,pt,par,p0,p1,p2,p3,
     pQ,pR,cc,m1,m2,out,tmp,tmp1,reL,ch,flg);
  if(!islist(Arg3),
    Derivative(Arg1,Arg2,Arg3,[]);
  ,
    pdstr=Arg1; ptinfo=Arg2; options=Arg3;
    tmp=Divoptions(options);
    reL=tmp_5;
    ch=1;
    if(length(reL)>0,
      ch=reL_1;
      options=remove(options,reL);
    );
    flg=0;//1807120
    name="";
    if(isstring(ptinfo),
      tmp=Strsplit(ptinfo,"=");
      name=Toupper(substring(tmp_1,0,1));
      v=parse(tmp_2);
      if(name=="X",
        tmp1=Lineplot("",[[v,0],[v,1]],["nodata"]);
      ,
        tmp1=Lineplot("",[[0,v],[1,v]],["nodata"]);
      );
      tmp=IntersectcurvesPp(pdstr,tmp1);
      if(length(tmp)==0,
         println("    Derivative cannot be found");
         out="";
         flg=1;
      ,
        tmp=sort(tmp,[#_3]);
        pt=tmp_ch_1;
        par=tmp_ch_2;
      );
    ,
      pt=ptinfo_1;
      par=ptinfo_2;
    );
    if(flg==0,
      p0=Pointoncurve(par-1,pdstr);
      p1=pt;
      p2=Pointoncurve(par+1,pdstr);
      p3=Pointoncurve(par+2,pdstr);
      tmp=1+sqrt((1+Dotprod(p2-p0,p3-p1)/|p2-p0|/|p3-p1|)/2);
      cc=4*|p2-p1|/3/(|p2-p0|+|p3-p1|)/tmp;
      pQ=p1+cc*(p2-p0);
      pR=p2+cc*(p1-p3);
      m1=-p1_1+pQ_1;
      m2=-p1_2+pQ_2;
      if(name=="",out=[m1,m2]);
      if(name=="X",out=m2/m1);
      if(name=="Y",out=m1/m2);
    );
    out;
  );
);//180720to
Derivative(fun,var,value,options):=(
//help:Derivative("x^3","x",2);
  regional(eqL,method,eps,str,x1,x2,y1,y2,tmp,tmp1,tmp2);
  method="N";
  tmp=Divoptions(options);
  eqL=tmp_5;
  forall(eqL,
    tmp=substring(#,"=");
    tmp1=Toupper(substring(#,0,1));
    tmp2=substring(#,tmp,tmp+1);
    if(tmp1=="M",
      method=Toupper(tmp2);
    );
  );
  if(method=="D",
    str="d"+PaO();
    str=str+replace(fun,var,"#")+",";
    str=str+value+")";
    tmp=Pcrd([1,parse(str)]);  // 14.11.08
    tmp_2;
  );
  if(method=="N",
    eps=10^(-6);
    x1=max(XMIN,value-eps);
    x2=min(XMAX,value+eps);
    tmp=Assign(fun,[var,"("+format(x1,6)+")"]);//180408
    y1=parse(tmp);
    tmp=Assign(fun,[var,"("+format(x2,6)+")"]);//180408
    y2=parse(tmp);
    (y2-y1)/(x2-x1);
  );
);
////%Derivative end////

////%Tangentplot start////
Tangentplot(nm,pdstr,ptinfo):=Tangentplot(nm,pdstr,ptinfo,[]); //180720
Tangentplot(nm,pdstr,ptinfo,optionsorg):=(
//help:Tangentplot("1",pdstr,"x=2");
//help:Tangentplot("1",pdstr,"y=3");
//help:Tangentplot("1",pdstr,[[1,2],20.5]);
//help:Tangentplot(Options2=[choice(1)]);
  regional(name,v,pt,par,options,reL,ch,tmp,flg);
  options=optionsorg; //1807120from
  tmp=Divoptions(options);
  reL=tmp_6;
  ch=1;
  if(length(reL)>0,
    ch=reL_1;
    options=remove(options,reL);
  );
  flg=0;//1807120to
  name="";
  if(isstring(ptinfo),
    tmp=Strsplit(ptinfo,"=");
    name=Toupper(substring(tmp_1,0,1));
    v=parse(tmp_2);
    if(name=="X",
      tmp1=Lineplot("",[[v,0],[v,1]],["nodata"]);
    ,
      tmp1=Lineplot("",[[0,v],[1,v]],["nodata"]);
    );
    tmp=IntersectcurvesPp(pdstr,tmp1);
    if(length(tmp)==0,//1807120
      println("   Derivative cannot be calculated");
      flg=1;
    ,
      tmp=sort(tmp,[#_3]);//1807120[3lines]
      pt=tmp_ch_1;
      par=tmp_ch_2;
    );
  ,
    pt=ptinfo_1;
    par=ptinfo_2;
  );
  if(flg==0,
    tmp=Derivative(pdstr,[pt,par]);
    if(vname=="X",
      Lineplot("tn"+nm,[pt,pt+tmp],options);
    ,
      Lineplot("tn"+nm,[pt,pt+tmp],options);
    );
  );
);
////%Tangentplot end////

////%Integrate start////
Integrate(Arg1,Arg2):=( //180708from
  if(isstring(Arg2),
    Integratefn(Arg1,Arg2,[]);
  ,
    Integratedt(Arg1,Arg2,[]);
  );
);
Integrate(Arg1,Arg2,options):=(
  if(isstring(Arg2),
    Integratefn(Arg1,Arg2,options);
  ,
    Integratedt(Arg1,Arg2,options);
  );
);//180708to
////%Integrate end////

////%Integratedt start////
Integratedt(pltdata,range,options):=(
//help:Integrate("gr1",[1,3]);
//help:Integrate(options=["Rule=o"]);
  regional(tmp,tmp1,eqL,Rule,pdata,Sm,ptP,ptQ,list,va1,va2);
  tmp=Divoptions(options);
  eqL=tmp_5;
  Rule="o";
  forall(eqL,
    if(Toupper(substring(#,0,1))=="R",
      tmp=indexof(#,"=");
      Rule=substring(#,tmp,tmp+1); 
    );
  );
  if(Rule=="o",
    Sm= IntegrateO(pltdata,range);
  ,
    if(isstring(pltdata),pdata=parse(pltdata),pdata=pltdata);
    if(Measuredepth(pdata)==2,pdata=pdata_1);
    va1=MeetCurve(pdata,range_1,0);
    va2=MeetCurve(pdata,range_2,0);
    list=select(pdata,(#_1>range_1 & #_1<range_2));
    list=apply(list,LLcrd(#));  // 15.09.14
    list=concat([va1],list);
    list=concat(list,[va2]);
    Sm=0;
    forall(1..(length(list)-1),
      ptP=list_#;           // 15.09.14
      ptQ=list_(#+1);
      Sm=Sm+(ptP_2+ptQ_2)*(ptQ_1-ptP_1)/2;
    );
    Sm;
  );
);
////%Integratedt end////

////%Integratefn start////
Integratefn(fnstr,rngstr,options):=( //180708from
//help:Integrate("sin(x)","x=[0,pi]",["Num=100","Rule=o"]);
  regional(Sm,Lx,Rx,va1,va2,Num,Way,sx,ex,dx,xn,yn,
     x0,x1,x2,y0,y1,y2,tmp,tmp1,tmp2,eqL,var,range,plt);
  Num=100;
  Way="o";
  tmp=Divoptions(options);
  eqL=tmp_5;
  forall(eqL,
    tmp=Strsplit(#,"=");
    tmp1=Toupper(substring(tmp_1,0,1));
    tmp2=tmp_2;
    if(tmp1=="N",
      Num=parse(tmp2);
    );
    if(tmp1=="R",
      tmp2=substring(tmp2,0,1);
    );
  );
  tmp=Strsplit(rngstr,"=");
  var=tmp_1;
  range=parse(tmp_2);
  if(Way=="o",
    sx=range_1;
    ex=range_2;
    dx=(ex-sx)/Num;
    xn=apply(0..Num,sx+#*dx);
    yn=apply(xn,parse(Assign(fnstr,[var,#]))); //181230
    plt=apply(1..(Num+1),[xn_#,yn_#]);
    Sm=IntegrateO(plt,range);
  );//180708to
  if(Way=="t",
    Sm=0;
    forall(1..Num,
      Lx=range_1+(range_2-range_1)*(#-1)/Num;
      Rx=range_1+(range_2-range_1)*#/Num;
      va1=parse(replace(fnstr,vastr,Textformat(Lx,5)));
      va2=parse(replace(fnstr,vastr,Textformat(Rx,5)));
      Sm=Sm+(va1+va2)*(Rx-Lx)/2;
    );
  );
  if(Way=="s",
    Sm=0;
    sx=range_1;
    ex=range_2;
    dx=(ex-sx)/Num;
    xn=apply(0..Num,sx+#*dx);
    yn=apply(xn,parse(replace(fnstr,vastr,Textformat(#,5))));
    dx=dx/2;
    repeat(Num,s,
      x0=xn_s;
      x1=(xn_s+xn_(s+1))/2;
      x2=xn_(s+1);
      y0=yn_s;
      y1=parse(replace(fnstr,vastr,Textformat(x1,5)));
      y2=yn_(s+1);
      Sm=Sm+dx*(y0+4*y1+y2)/3;
    ); 
  );
  Sm;
);
////%Integratefn end////

////%IntegrateO start////
IntegrateO(p0org,p1org,p2org,p3org):=(
  regional(p0,p1,p2,p3,pQ,pR,cc,p01,p02,
     p11,p12,p21,p22,p31,p32, tmp);
  if(ispoint(p0org),p0=p0org.xy,p0=p0org);  // 16.03.10
  if(ispoint(p1org),p1=p1org.xy,p1=p1org); // 16.03.16
  if(ispoint(p2org),p2=p2org.xy,p2=p2org);
  if(ispoint(p3org),p3=p3org.xy,p3=p3org);
  tmp=1+sqrt((1+Dotprod(p2-p0,p3-p1)/|p2-p0|/|p3-p1|)/2);
  cc=4*|p2-p1|/3/(|p2-p0|+|p3-p1|)/tmp;
  pQ=p1+cc*(p2-p0);
  pR=p2+cc*(p1-p3);
  p01=p1_1; p02=p1_2;
  p31=p2_1; p32=p2_2;
  p11=pQ_1; p12=pQ_2;
  p21=pR_1; p22=pR_2;
  tmp=-6*p12*p01+3*p12*p21+3*p12*p31+6*p02*p11-
         10*p02*p01+3*p02*p21+p02*p31-3*p22*p11-
         3*p22*p01+6*p22*p31-3*p32*p11-p32*p01-
         6*p32*p21+10*p32*p31;
  tmp=tmp/20;
);
IntegrateO(pltdata,rangeorg):=(
//help:IntegrateO("gr1",[0,2]);
  regional(tmp,tmp1,tmp2,pdata,va1,va2,list,Bzk,Bzc,range,pmflg,
    Sm,p0,p1,p2,p3,pQ,pR,cc,p01,p02,p11,p12,p21,p22,p31,p32);
  if(isstring(pltdata),
    pdata=parse(pltdata);
  ,
    pdata=pltdata;
  );
  if(Measuredepth(pdata)==2,pdata=pdata_1);
  range=rangeorg;
  pmflg=1;
  if(range_2<range_1,
    range=reverse(range);
    pmflg=-1;
  );
  va1=MeetCurve(pdata,range_1,0);
  va2=MeetCurve(pdata,range_2,0);
  list=select(pdata,(#_1>range_1 & #_1<range_2));
  if(length(list)>0,  // 16.09.25
    if(list_1_1>list_(length(list))_1, //16.11.03
      list=reverse(list);
//      pmflg=pmflg*(-1);
    );
  );
  list=apply(list,LLcrd(#)); 
  list=concat([va1],list);
  list=concat(list,[va2]);
  Sm=0;
  forall(1..(length(list)-1),
    p1=list_#;
    p2=list_(#+1);
    if(#==1 % #==length(list)-1,
      tmp1=(p1_2+p2_2)*(p2_1-p1_1)/2;
      Sm=Sm+tmp1;
    ,
      p0=list_(#-1);
      p3=list_(#+2);
      tmp=1+sqrt((1+Dotprod(p2-p0,p3-p1)/|p2-p0|/|p3-p1|)/2);
      cc=4*|p2-p1|/3/(|p2-p0|+|p3-p1|)/tmp;
      pQ=p1+cc*(p2-p0);
      pR=p2+cc*(p1-p3);
      p01=p1_1; p02=p1_2;
      p31=p2_1; p32=p2_2;
      p11=pQ_1; p12=pQ_2;
      p21=pR_1; p22=pR_2;
      tmp1=-6*p12*p01+3*p12*p21+3*p12*p31+6*p02*p11-
         10*p02*p01+3*p02*p21+p02*p31-3*p22*p11-
         3*p22*p01+6*p22*p31-3*p32*p11-p32*p01-
         6*p32*p21+10*p32*p31;
      tmp1=tmp1/20;
      Sm=Sm+tmp1;
    );
  );
  if(pmflg==-1,
    Sm=-Sm;
  );
  Sm;
);
////%IntegrateO end////

////%FindareaP start////
FindareaP(pdstr):=( //180722
//help:Findarea("sgABCA");
  regional(pd,p1,p2,s,tmp);
  if(isstring(pdstr),pd=parse(pdstr),pd=pdstr);
  s=0;
  forall(1..(length(pd)-1),
    p1=Lcrd(pd_#);
    p2=Lcrd(pd_(#+1));
    tmp=(p1_2+p2_2)*(p2_1-p1_1)/2;
    s=s+tmp;
  );
  if(s<0,s=-s);
  s;
);
////%FindareaP end////

////%FindareaO start////
FindareaO(pdstr,len):=(  // 18.10,13
  regional(pd,p0,p1,p2,p3,s,tmp,Lflg);
  if(isstring(pdstr),pd=parse(pdstr),pd=pdstr);
  Lflg=0;
  s=0;
  forall(1..(length(pd)-1),
    p1=pd_#;
    p2=pd_(#+1);
    if(Dist(p1,p2)<len,
      if(#==1,p0=pd_(length(pd)-1),p0=pd_(#-1));
      if(Dist(p0,p1)>len,p0=2*p1-p2);
      if(#==length(pd)-1,p3=pd_2,p3=pd_(#+2));
      if(Dist(p2,p3)>len,p3=2*p2-p1);
      tmp=IntegrateO(p0,p1,p2,p3);
    ,
      tmp=(p1_2+p2_2)*(p2_1-p1_1)/2;
    );
    s=s+tmp;
  );
  if(s<0,s=-s);
  s;
);
////%FindareaO end////

////%Findarea start////
Findarea(pdstr):=Findarea(pdstr,[]);//180722from
Findarea(pdstr,options):=(
//help:Findarea("cr1");
//help:Findarea(options=["Len=1"]);
  regional(tmp,tmp1,tmp2,eqL,way,len,out);
  tmp=Divoptions(options);
  eqL=tmp_5;
  way="O";
  len=1;
  forall(eqL,
    tmp=Strsplit(#,"=");
    tmp1=Toupper(substring(tmp_1,0,1));
    tmp2=tmp_2;
    if(tmp1=="W",
      way=Toupper(substring(tmp2,0,1));
    );
    if(tmp1=="L",//181013from
      len=parse(tmp2);
    );//181013to
  );
  if(way=="O",
    out=FindareaO(pdstr,len);//181013
  ,
    out=FindareaP(pdstr);
  );
  out;
);//180722to
////%Findarea end////

////%Findlength start////
Findlength(pdstr):=(
//help:Findlength("gr1");
  regional(pd,p1,p2,s,tmp);
  if(isstring(pdstr),pd=parse(pdstr),pd=pdstr);
  s=0;
  forall(1..(length(pd)-1),
    p1=Lcrd(pd_#);
    p2=Lcrd(pd_(#+1));
    tmp=|p2-p1|;
    s=s+tmp;
  );
  s;
);
////%Findlength end////

////%Inversefun start////
Inversefun(fnstr,rngstr,value):=(
  regional(tmp,varstr,range,x1,x2,x3,va1,va2);
  tmp=indexof(rngstr,"=");
  varstr=substring(rngstr,0,tmp-1);
  range=parse(substring(rngstr,tmp,length(rngstr)));
  x1=range_1; x2=range_2;
  repeat(15,
    x3=(x1+x2)/2;
    va1=parse(replace(fnstr,varstr,Textformat(x1,5)));
    va2=parse(replace(fnstr,varstr,Textformat(x3,5)));
    if((va1>value & va2>value) % (va1<value & va2<value),
      x1=x3;
    ,
      x2=x3;
    );
  );
  va1=parse(replace(fnstr,varstr,Textformat(x1,5)))-value;
  va2=parse(replace(fnstr,varstr,Textformat(x2,5)))-value;
  if(x1==range_1 % x2==range_2, 
    println("not found in ("+Textformat(range_1,5)
         +","+Textformat(range_2,5)+")");
  );
  if(abs(va1)<=abs(va2),x1,x2);
);
////%Inversefun end////

////%Com0th start////
Com0th(String):=(
    regional(str);
    str=replace(String,LFmark,"");
    COM0thlist=append(COM0thlist,str);
);
////%Com0th end////

////%Com1st start////
Com1st(String):=(
    regional(str);
    str=replace(String,LFmark,"");
    GLIST=append(GLIST,str);  // 15.05.27
//    COM1stlist=append(COM1stlist,str);
);
////%Com1st end////

////%Com2nd start////
Com2nd(String):=(
// help:Com2nd(str);
  regional(str,tmp);
  str=replace(String,LFmark,"");
  COM2ndlist=append(COM2ndlist,str);
);
////%Com2nd end////

////%Com2ndpre start////
Com2ndpre(String):=(
    regional(str);
    str=replace(String,LFmark,"");
    COM2ndlist=prepend(str,COM2ndlist);
);
////%Com2ndpre end////

////%Texcom start////
Texcom(strorg):=(  //17.09.22
//help:Texcom("\color[cmyk]{0,0,0,0.5}");
  regional(str);
  str=replace(strorg,"\","\\");
  str=replace(str,"\\\\","\\");
  str="Texcom("+Dq+str+Dq+")";
  Com2nd(str);
);
////%Texcom end////

////%Ketcindylogo start////
Ketcindylogo():=(
//help:Ketcindylogo();
  Com2nd("Texcom("+Dq+"\def\ketcindy{{K\kern-.20em
          \lower.5ex\hbox{E}\kern-.125em{TCindy}}}"+Dq+")");
);
////%Ketcindylogo end////

////%Drwline start////
Drwline():=Drwline(Textformat(GrL,5));
Drwline(gstr):=(
  Com2nd("Drwline("+gstr+")");
);
////%Drwline end////


////%Dashline start////
Dashline(gstr):=(
  Com2nd("Dashline("+gstr+")");
);
////%Dashline end////

////%Invdashline start////
Invdashline(gstr):=(
  Com2nd("Invdashline("+gstr+")");
);
////%Invdashline end////

////%Dottedline start////
Dottedline(gstr):=(
 Com2nd("Dottedline("+gstr+")");
);
////%Dottedline end////

////%SetEnglish start////
SetEnglish():=(
//help:SetEnglish();
  Com0th("setlanguage('en')");
);
////%SetEnglish end////

////%Drawlinetype start////
Drawlinetype(name,type):=(
//help:Drawlinetype("gr1","da,1");
  regional(Dop,tmp,tmp1,tmp2);
  Dop="";
  tmp1=indexof(type,",");
  if(tmp1>0,
    Dop=","+substring(type,tmp1,length(type));
  );
  tmp1=Toupper(substring(type,0,3));
  if(tmp1=="DR",
    Drwline(name+Dop);
  );
  if(tmp1=="DA",
    Dashline(name+Dop);
  );
  if(tmp1=="ID",
    Invdashline(name+Dop);
  );
  if(tmp1=="DO",
    Dottedline(name+Dop);
  );
);
////%Drawlinetype end////

////%Setunitlen start////
Setunitlen():=(
  println(ULEN);
); 
Setunitlen(UI):=(
//help:Setunitlen("1.5cm");
  regional(Dx,Dy,Sym,SL,OL,Is,VL,Ucode,ii,cha,
     str,Unit,Valu,flg,tmp);
  Dx=XMAX-XMIN;
  Dy=YMAX-YMIN;
  Sym=".0123456789 +-*/";
  SL=Sym;
  OL="+-*/";
  if(length(UI)>0,
    ULEN=UI;
    GLIST=append(GLIST,"Setunitlen("+Dq+UI+Dq+")");//180513 //no ketjs
  );
  Is=1;
  VL="";
  Ucode=ULEN;
  flg=0;
  forall(1..(length(Ucode)),ii,
    if(flg==0,
      cha=substring(Ucode,ii-1,ii);
      if(indexof(SL,cha)>0,
        if(indexof(OL,cha)>0,
          tmp=substring(Ucode,Is-1,ii);
          str=VL+tmp+cha;
          VL=str;
          Is=ii+1;
        );
      ,
        Unit=substring(Ucode,ii-1,ii+1);
        str=substring(Ucode,Is-1,ii-1);
        VL=VL+str;
        flg=1;
      );
    );
  );
  Valu=parse(VL);
  str=format(Valu,6);
  ULEN=str+Unit;
  if(Unit=="cm",MilliIn=1000/2.54*Valu);
  if(Unit=="mm",MilliIn=1000/2.54*Valu/10);
  if(Unit=="in",MilliIn=1000*Valu);
  if(Unit=="pt",MilliIn=1000/72.27*Valu);
  if(Unit=="pc",MilliIn=000/6.022*Valu);
  if(Unit=="bp",MilliIn=1000/72*Valu);
  if(Unit=="dd2",MilliIn=1000/1238/1157/72.27*Valu);
  if(Unit=="cc",MilliIn=1000/1238/1157/72.27*12*Valu);
  if(Unit=="sp",MilliIn=1000/72.27/65536*Valu/10);
  MARKLEN=MARKLENNow*1000/2.54/MilliIn;
  MEMORI=MEMORINow*1000/2.54/MilliIn;
);
////%Setunitlen end////

////%Setmarklen start////
Setmarklen(ratio):=(
//help:Setmarklen(0.2);
  MARKLEN=ratio*0.2;//16.11.01
  Com2nd("Setmarklen("+Textformat(ratio,5)+")");
);
////%Setmarklen end////

////%Setorigin start////
Setorigin(point):=(
//help:Setorigin([1,2]);
  GENTEN=point; //181231
  Com2nd("Setorigin("+Textformat(point,5)+")");
);
////%Setorigin end////

////%Fontsize start////
Fontsize(sizestr):=(
//help:Fontsize("s");
  Com2nd("Fontsize('"+sizestr+"')");
);
////%Fontsize end////

////%Setpen start////
Setpen(width):=(
//help:Setpen(2);
  PenThick=PenThickInit*width; // 16.04.09
  Com2nd("Setpen("+text(width)+")");
);
////%Setpen end////

////%Setscaling start////
Setscaling(sc):=(
//help:Setscaling(3);
  regional(tmp);
  tmp=format(sc,5);
  if(!islist(sc),
    SCALEX=1;
    SCALEY=sc;
    Com0th("Setscaling("+tmp+")");
  ,
    SCALEX=sc_1;
    SCALEY=sc_2;
    Com0th("Setscaling("+tmp_1+","+tmp_2+")");
  );
  Setwindow("Msg=no");
);
////%Setscaling end////

////%Lcrd start////
Lcrd(pt):=(
  regional(tmp);
  if(ispoint(pt),
    tmp=[pt.x/SCALEX,pt.y/SCALEY];
  ,
    tmp=pt;
  );
  tmp;
);
////%Lcrd end////

////%Pcrd start////
Pcrd(pt):=(
  regional(tmp);
  if(ispoint(pt),
    tmp=re(pt.xy); // 15.07.24
  ,
    tmp=[pt_1*SCALEX,pt_2*SCALEY];
  );
 tmp;
);
////%Pcrd end////

////%LLcrd start////
LLcrd(pt):=(
  regional(tmp);
  if(ispoint(pt),
    tmp=pt.xy
  ,
    tmp=pt;
  );
  tmp=[tmp_1/SCALEX,tmp_2/SCALEY];
  tmp;
);
////%LLcrd end////

////%Doscaling start////
Doscaling(pltdata):=(
  regional(Level,Out,gL,gr,tmp);
  if(ispoint(pltdata) % isreal(pltdata_1),
    gL=[[pltdata]];
    Level=0;
  ,
    if(ispoint(pltdata_1) % isreal(pltdata_1_1),
      gL=[pltdata];
      Level=1;
    ,
      gL=pltdata;
      Level=2;
    );
  );
  Out=[];
  forall(gL,gr,
    tmp=apply(gr,Lcrd(#));
    tmp=apply(tmp,LLcrd(#));
    Out=concat(Out,[tmp]);
  );
  if(Level==0,
    Out=Out_1_1;
  );
  if(Level==1,
    Out=Out_1;
  );
  Out;
);
////%Doscaling end////

////%Unscaling start////
Unscaling(pltdata):=(
  regional(Level,Out,gL,gr,tmp);
   if(ispoint(pltdata) % isreal(pltdata_1),
    gL=[[pltdata]];
    Level=0;
  ,
    if(ispoint(pltdata_1) % isreal(pltdata_1_1),
      gL=[pltdata];
      Level=1;
    ,
      gL=pltdata;
      Level=2;
    );
  );
  Out=[];
  forall(gL,gr,
    tmp=apply(gr,Lcrd(#));
    tmp=apply(tmp,LLcrd(#));
    Out=concat(Out,[tmp]);
  );
  if(Level==0,
    Out=Out_1_1;
  );
  if(Level==1,
    Out=Out_1;
  );
  Out;
);
////%Unscaling end////

////%Setpt start////
Setpt(n):=Ptsize(n);
//help:Setpt(5);
Ptsize(n):=(
  println("Setpt("+text(n)+")");
  TenSize=TenSizeInit*n;
  Com2nd("Setpt("+text(n)+")"); // 14.01.19
);
////%Setpt end////

////%Definecolor start////
Definecolor(name,data):=(
//help:Definecolor("mycolor",[1,1,1,0]);
  regional(type,tmp);
  if(length(data)>3,type="cmyk",type="rgb");  
  tmp=text(data);
  tmp=substring(tmp,1,length(tmp)-1);
  tmp="\definecolor{"+name+"}{"+type+"}{"+tmp+"}";
  Texcom(tmp);
);
////%Definecolor end////

////%Setcolor start////
Setcolor(parorg):=(  //180603renew
//help:Setcolor([1,0,0,1]);
//help:Setcolor([1,1,0]);
  regional(par,cstr,tmp,tmp1);
  par=parorg;
  if(isstring(par),
    if(par=="black",par=[0,0,0]);
    if(par=="white",par=[1,1,1]);
    if(par=="red",par=[1,0,0]);
    if(par=="green",par=[0,1,0]);
    if(par=="blue",par=[0,0,1]);
    if(par=="cyan",par=[0,1,1]);
    if(par=="magenta",par=[1,0,1]);
    if(par=="yellow",par=[1,1,0]);
  );
  cstr=text(par);
  cstr=substring(cstr,1,length(cstr)-1);
  if(length(par)==3,
    cstr="Texcom('\\color[rgb]{"+cstr+"}')"; //no ketjs
    KCOLOR=par;  
  );
  if(length(par)==4,
    cstr="Texcom('\\color[cmyk]{"+cstr+"}')"; //no ketjs
    tmp=Colorcmyk2rgb(par);
    KCOLOR=tmp;
  );
  Com2nd(cstr); //no ketjs
);
////%Setcolor end////

////%Colorrgb2cmyk start////
Colorrgb2cmyk(clr):=(
// help:ColorRgb([0.2,0.5,0.1]);
  regional(clrnew,tmp,black);
  tmp=apply(clr,1-#);
  black=min(tmp);
  if(black!=1, //181112from
    tmp=apply(clr,(1-#-black)/(1-black));
    clrnew=append(tmp,black);
  ,
    clrnew=[0,0,0,1];
  ); //181112to
  clrnew;
);
////%Colorrgb2cmyk end////

////%Colorcmyk2rgb start////
Colorcmyk2rgb(clr):=(
// help:ColorRgb([0.2,0.5,0.1,0.2]);
  regional(clrnew,tmp,black);
  black=clr_4;
  tmp=apply(clr,1-min(1,#*(1-black)+black));
  clrnew=tmp_(1..3);
  clrnew;
);
////%Colorcmyk2rgb end////

////%Colorrgbhsv start////
Colorrgbhsv(rgb):=(
  regional(varR,varG,varB,varMin,varMax,delMax,hh,ss,vv,delR,delG,delB);
  varR = rgb_1;
  varG = rgb_2;
  varB = rgb_3;
  varMin = min( [varR, varG, varB] );
  varMax = max( [varR, varG, varB] );
  delMax = varMax - varMin ;
  vv = varMax;
  if ( delMax == 0 , 
    hh = 0 ; 
    ss = 0 ;
  ,
    ss = delMax / varMax;
    delR = ( ( ( varMax - varR ) / 6 ) + ( delMax / 2 ) ) / delMax;
    delG = ( ( ( varMax - varG ) / 6 ) + ( delMax / 2 ) ) / delMax;
    delB = ( ( ( varMax - varB ) / 6 ) + ( delMax / 2 ) ) / delMax;
    if( varR == varMax ,
      hh = delB - delG;
    , 
      if ( varG == varMax, 
        hh = ( 1 / 3 ) + delR - delB;
      , 
        if ( varB == varMax ,
          hh = ( 2 / 3 ) + delG - delR;
        );
      );
    );
    if ( hh < 0 ,hh = hh+1);
    if ( hh > 1 ,hh = hh-1);
  );
  [hh*360,ss,vv]; 
);
////%Colorrgbhsv end////

////%Colorhsvrgb start////
Colorhsvrgb(sL):=(
  regional(tmp,tmp1,tmp2,tmp3,hi,ff,dL);
  tmp=[sL_1/60,sL_2,sL_3];
  hi=mod(floor(tmp_1),6);
  ff=tmp_1-floor(tmp_1);
  tmp2=tmp_3*[1-tmp_2,1-tmp_2*ff,1-tmp_2*(1-ff)];
  tmp2=append(tmp2,tmp_3);
  if(hi==0,dL=tmp2_[4,3,1]);
  if(hi==1,dL=tmp2_[2,4,1]);
  if(hi==2,dL=tmp2_[1,4,3]);
  if(hi==3,dL=tmp2_[1,2,4]);
  if(hi==4,dL=tmp2_[3,1,4]);
  if(hi==5,dL=tmp2_[4,1,2]);
  dL;
);
////%Colorhsvrgb end////

////%Colorrgbhsl start////
Colorrgbhsl(rgb):=(
  regional(rr,gg,bb,mn,mx,delta,deltaR,deltaG,deltaB,hh,ss,ll);
  rr = rgb_1 ;
  gg = rgb_2 ;
  bb = rgb_3 ;
  mn = min([rr, gg, bb]);
  mx = max([rr, gg, bb]);
  delta = mx - mn;
  ll = (mx + mn) / 2;  
  if (delta ==  0,
    hh=0; 
    ss=0; 
  ,
    if (ll < 0.5,
      ss = delta/ (mx + mn);
    ,
      ss = delta / (2 - mx - mn);
    );
    deltaR = (((mx - rr) / 6) + (delta / 2)) / delta;
    deltaG = (((mx - gg) / 6) + (delta / 2)) / delta;
    deltaB = (((mx - bb) / 6) + (delta / 2)) / delta;
    if (rr == mx,
       hh = deltaB - deltaG;
    , 
      if (gg == mx,
        hh = (1 / 3) + deltaR - deltaB;
      , 
        if (bb == mx,
          hh = (2 / 3) + deltaG - deltaR;
        );
      );
    );
    if ( hh < 0, hh = hh+1);
    if ( hh > 1, hh = hh-1);
  );
  [hh*360,ss,ll];
);
////%Colorrgbhsl end////

////%Colorhslrgb start////
Colorhslrgb(hsl):=(
  regional(hh,ss,ll,rr,gg,bb,var1,var2);
  hh=hsl_1/360;
  ss=hsl_2;
  ll=hsl_3;
  if ( ss == 0.0,
    rr = ll ;
    gg = ll ;
    bb = ll ;
  ,
    if ( ll < 0.5 ,
      var2 = ll * ( 1.0 + ss );
    ,
      var2 = ( ll + ss ) - ( ss * ll );
    );
    var1 = 2.0 * ll - var2;
    rr = Hue2rgb( var1, var2, hh + ( 1.0 / 3.0 ) );
    gg = Hue2rgb( var1, var2, hh );
    bb = Hue2rgb( var1, var2, hh - ( 1.0 / 3.0 ) );
  );
  [rr,gg,bb];
);
////%Colorhslrgb end////

////%Hue2rgb start////
Hue2rgb(vv1,vv2,vh):=(
  regional(out);
  if ( vh < 0.0 ,vh =vh+1);
  if ( vh > 1.0 ,vh =vh-1);
  if ( 6.0*vh  < 1.0 ,
    out = vv1 + ( vv2 - vv1 ) * 6.0 * vh ;
  ,
    if( 2.0*vh  < 1.0 ,
      out = vv2;
    ,
      if ( 3.0*vh  < 2.0 ,
        out = vv1 + ( vv2 - vv1 ) * ( ( 2.0 / 3.0 ) - vh ) * 6.0 ;
      ,
      out= vv1 ;
      );
    );
  );
  out;
);
////%Hue2rgb end////

////%Colorrgbhwb start////
Colorrgbhwb(sL):=(
  regional(dl1,dl2,dl3);
  dl1 = Colorrgbhsl(sL)_1;//Colorcode("rgb","hsl",sL)_1;
  dl2 =  min(sL);
  dl3 = 1 -  max(sL);
  dL= [dl1, dl2 , dl3 ];
);
////%Colorrgbhwb end////

////%Colorhwbrgb start////
Colorhwbrgb(sLorg):=(
  regional(sL,tmp,tmp1,tmp2,tmp3,ratio,ff,ii,vv,nn,dL,flg);
  sL=sLorg;
  sL=[sL_1/360,sL_2,sL_3];
  ratio = sL_2 + sL_3;
  // sL_2 + sL_3 cant be > 1
  if (ratio > 1.,
    sL_2 =sL_2 / ratio;
    sL_3 = sL_3 / ratio;
  );
  ii = floor(6 * sL_1);
  vv = 1 - sL_3;
  ff = 6 * sL_1 - ii;
  if(mod(ii,2)==1,ff = 1 - ff); 
  nn = sL_2 + ff * (vv - sL_2); // linear interpolation
  tmp=[[vv,nn,sL_2],[nn,vv,sL_2],[sL_2,vv,nn],
       [sL_2,nn,vv],[nn,sL_2,vv],[vv,sL_2,nn],[vv,nn,sL_2]];
  flg=0;
  forall(0..6,
    if(flg==0 & ii == # ,
      dL=tmp_(#+1);
      flg=1;
    );
  );
 dL;
);
////%Colorhwbrgb end////

////%Colorcode start////
Colorcode(src,dest,sL):=( // 181212 some colorchange deleted
//help:Colorcode("rgb","cmyk",[1,0.5,0]);
  regional(tmp,tmp1,tmp2,tmp3,mn,mx,delta,black,dL,flg);
  regional(dl1,dl2,dl3);
  if(src=="rgb" & dest=="cmyk",dL=Colorrgb2cmyk(sL));
  if(src=="cmyk" & dest=="rgb",dL=Colorcmyk2rgb(sL));
  if(src=="rgb" & dest=="hsv", dL=Colorrgbhsv(sL));
  if(src=="rgb" & dest=="hsl", dL=Colorrgbhsl(sL));
  if(src=="rgb" & dest=="hwb", dL=Colorrgbhwb(sL));
  if(src=="hsv" & dest=="rgb", dL=Colorhsvrgb(sL));
  if(src=="hsl" & dest=="rgb", dL=Colorhslrgb(sL));
  if(src=="hwb" & dest=="rgb", dL=Colorhwbrgb(sL));
  dL;
);
////%Colorcode end////

////%Colorname2rgb start////
Colorname2rgb(name):=( //181212
//help:Colorname2rgb("sepia");
  regional(dL,nameL,codeL,tmp);
  dL=[
    ["greenyellow",[0.15,0,0.69,0]],["yellow",[0,0,1,0]],
    ["goldenrod",[0,0.1,0.84,0]],["dandelion",[0,0.29,0.84,0]],
    ["apricot",[0,0.32,0.52,0]],["peach",[0,0.5,0.7,0]],
    ["melon",[0,0.46,0.5,0]],["yelloworange",[0,0.42,1,0]],
    ["orange",[0,0.61,0.87,0]],["burntorange",[0,0.51,1,0]],
    ["bittersweet",[0,0.75,1,0.24]],["redorange",[0,0.77,0.87,0]],
    ["mahogany",[0,0.85,0.87,0.35]],["maroon",[0,0.87,0.68,0.32]],
    ["brickred",[0,0.89,0.94,0.28]],["red",[0,1,1,0]],
    ["orangered",[0,1,0.5,0]],["rubinered",[0,1,0.13,0]],
    ["wildstrawberry",[0,0.96,0.39,0]],["salmon",[0,0.53,0.38,0]],
    ["carnationpink",[0,0.63,0,0]],["magenta",[0,1,0,0]],
    ["violetred",[0,0.81,0,0]],["rhodamine",[0,0.82,0,0]],
    ["mulberry",[0.34,0.9,0,0.02]],["redviolet",[0.07,0.9,0,0.34]],
    ["fuchsia",[0.47,0.91,0,0.08]],["lavender",[0,0.48,0,0]],
    ["thistle",[0.12,0.59,0,0]],["orchid",[0.32,0.64,0,0]],
    ["darkorchid",[0.4,0.8,0.2,0]],["purple",[0.45,0.86,0,0]],
    ["plum",[0.5,1,0,0]],["violet",[0.79,0.88,0,0]],
    ["royalpurple",[0.75,0.9,0,0]],["blueviolet",[0.86,0.91,0,0.04]],
    ["periwinkle",[0.57,0.55,0,0]], ["cadetblue",[0.62,0.57,0.23,0]],
    ["cornflowerblue",[0.65,0.13,0,0]],["midnightblue",[0.98,0.13,0,0.43]],
    ["navyblue",[0.94,0.54,0,0]],["royalblue",[1,0.5,0,0]],
    ["blue",[1,1,0,0]],["cerulean",[0.94,0.11,0,0]],
    ["cyan",[1,0,0,0]],["processblue",[0.96,0,0,0]],
    ["skyblue",[0.62,0,0.12,0]],["turquoise",[0.85,0,0.2,0]],
    ["tealblue",[0.86,0,0.34,0.02]],["aquamarine",[0.82,0,0.3,0]],
    ["bluegreen",[0.85,0,0.33,0]],["emerald",[1,0,0.5,0]],
    ["junglegreen",[0.99,0,0.52,0]],["seagreen",[0.69,0,0.5,0]],
    ["green",[1,0,1,0]],["forestgreen",[0.91,0,0.88,0.12]],
    ["pinegreen",[0.92,0,0.59,0.25]],["limegreen",[0.5,0,1,0]],
    ["yellowgreen",[0.44,0,0.74,0]],["springgreen",[0.26,0,0.76,0]],
    ["olivegreen",[0.64,0,0.95,0.4]],["rawsienna",[0,0.72,1,0.45]],
    ["sepia",[0,0.83,1,0.7]],["brown",[0,0.81,1,0.6]],
    ["tan",[0.14,0.42,0.56,0]],["gray",[0,0,0,0.5]],
    ["black",[0,0,0,1]],["white",[0,0,0,0]]
  ];
  tmp=select(dL,#_1==name);
  if(length(tmp)>0,
    tmp=tmp_1;
    code=tmp_2;
    code=Colorcmyk2rgb(code);
  ,
    println("    "+name+" not found");
    code=[0,0,0];
  );
);
////%Colorname2rgb end////

////%GetLinestyle start////
GetLinestyle(str,name):=(
  regional(noflg,tmp,tmp1,tmp2,Dop,Ltype,subflg);
  Ltype=-1;
  Dop="";
  tmp1=indexof(str,",");
  if(tmp1>0,
    Dop=","+substring(str,tmp1,length(str));
  );
  noflg=parse(substring(str,0,1));
  if(substring(name,0,3)=="sub",subflg=1,subflg=0);  // 16.02.29
  tmp1=substring(str,1,3);
  tmp2=""; //190119from
  tmp=indexof(str,",");
  if(tmp>0,
    tmp2=substring(str,tmp,length(str));
  ); //190119to
  if(tmp1=="dr" % tmp1=="Dr",
//    Ltype=0;
    if(length(tmp2)==0,tmp2="1"); //190125
    Ltype=[0,tmp2];  //190119
    if(noflg==0 & subflg==0, // 16.02.29
      Drwline(name+Dop);
    );
  );
  if(tmp1=="da" % tmp1=="Da",
//    Ltype=1;
    if(length(tmp2)==0,tmp2="1,1"); //190125
    Ltype=[1,tmp2];  //190119
    if(noflg==0 & subflg==0, // 16.02.29
      Dashline(name+Dop);
    );
  );
  if(tmp1=="id" % tmp1=="Id",
//    Ltype=2;  // 15.11.09
     if(length(tmp2)==0,tmp2="1,1"); //190125
   Ltype=[2,tmp2];  //190119
    if(noflg==0 & subflg==0, // 16.02.29
      Invdashline(name+Dop);
    );
  );
  if(tmp1=="do" % tmp1=="Do",
//    Ltype=3;
    if(length(tmp2)==0,tmp2="1,1"); //190125
    Ltype=[3,tmp2];  //190119
    if(noflg==0 & subflg==0, // 16.02.29
      Dottedline(name+Dop);
    );
  );
  if(tmp1=="dp" % tmp1=="Dp",
//    Ltype=0;
    if(length(tmp2)==0,tmp2="1"); //190125
    Ltype=[0,tmp2];  //190119
    tmp1=parse(name);
    tmp2="";
    forall(tmp1,
      tmp2=tmp2+Textformat(#_1,5)+",";
    );
    tmp2=substring(tmp2,0,length(tmp2)-1);
    if(noflg==0,
      Drwpt(tmp2+Dop);
    );
  );
  if(tmp1=="no" % tmp1=="No",
    Ltype=10;
  );
  Ltype;
);
////%GetLinestyle end////

////%Chunderscore start////
Chunderscore(str):=(
  regional(flg,tmp,tmp1,tmp2,tmp3);
  if(indexof(str,"]")>0,
    tmp1=replace(str,"]",",]");
  ,
    tmp1=str+",";
  );
  flg=0;
  tmp2=[];
  tmp3=0;
  forall(1..(length(tmp1)),
    if(flg==0,
      tmp=substring(tmp1,tmp3,length(tmp1));
      tmp=indexof(tmp,"_");
      if(tmp==0,
        flg=1;
      ,
        tmp3=tmp3+tmp;
        tmp=substring(tmp1,tmp3,length(tmp1));
        tmp=indexof(tmp,",")-1;
        tmp=substring(tmp1,tmp3,tmp3+tmp);
        tmp2=append(tmp2,tmp);
      );
    );        
  );
  forall(tmp2,
    tmp1=replace(tmp1,"_"+#,"("+#+")");
  );
  if(indexof(str,"]")>0,
    tmp1=replace(tmp1,",]",")");
    tmp1=replace(tmp1,"[","list"+PaO());
  ,
    tmp1=substring(tmp1,0,length(tmp1)-1);
  );
  tmp1;
);
////%Chunderscore end////

////%AddGraph start////
AddGraph(nm,pltdata):=AddGraph(nm,pltdata,[]);
AddGraph(nm,pltdata,options):=(
//help:AddGraph("1","imp1"); // 16.04.04
//help:Addgraph("1",["[pt1]","gr1"],["nodisp"]);
  regional(name,Ltype,Noflg,opcindy,pdata,fname,flg,
    tmp,tmp1,tmp2,tmp3,color);
  if(substring(nm,0,1)=="-",
    name=substring(nm,1,length(nm));
  ,
    name="ad"+nm;
  );
  tmp=Divoptions(options);
  Ltype=tmp_1;
  Noflg=tmp_2;
  color=tmp_(length(tmp)-2);
  opcindy=tmp_(length(tmp));
  if(isstring(pltdata),
    pdata=parse(pltdata)
  ,
    if(!islist(pltdata),pdata=[pltdata],pdata=pltdata);
    pdata=apply(pdata,parse(#));
  ); // 15.01.22
  pdata=Flattenlist(pdata);
  tmp1=[];
  forall(pdata,tmp2,
    tmp=apply(tmp2,Pcrd(#));
    tmp1=append(tmp1,tmp);
  );
  if(length(tmp1)==1,tmp1=tmp1_1);
  pdata=tmp1;
  if(Noflg<3,
    println("generate addgraph "+name);
    tmp=name+"="+Textformat(pdata,5);
    parse(tmp);
    if(isstring(pltdata), // 16.04.04 from
      if(indexof(pltdata,"]")>0,
        tmp1="list"+PaO()+"Listplot"+PaO()+substring(pltdata,1,length(pltdata));
        tmp1=replace(tmp1,"]",",]");
      ,
        tmp1="Listplot("+substring(pltdata,0,length(pltdata))+",]";
      );
      flg=0;
      tmp2=[];
      tmp3=0;
      forall(1..(length(tmp1)),
        if(flg==0,
          tmp=indexof(substring(tmp1,tmp3,length(tmp1)),"_");
          if(tmp==0,
            flg=1;
          ,
            tmp3=tmp3+tmp;
            tmp=indexof(substring(tmp1,tmp3,length(tmp1)),",")-1;
            tmp=substring(tmp1,tmp3,tmp3+tmp);
            tmp2=append(tmp2,tmp);
          );
        );        
      );
      forall(tmp2,
        tmp1=replace(tmp1,"_"+#,"("+#+")");
      );
      tmp1=replace(tmp1,",]",")");
      tmp1=replace(tmp1,",","),Listplot(");
      if(indexof(pltdata,"[")>0,
        tmp1=tmp1+")";
      );
      GLIST=append(GLIST,name+"="+tmp1); //no ketjs
    ,
      if(Measuredepth(pdata)==1,
        tmp1=name+"=Listplot("+Textformat(pdata,5)+")";
      ,
        tmp1="list"+PaO();
        forall(1..(length(pdata)),
          tmp=name+"p"+Textformat(#,5)+"=";
          if(length(pdata_#)>1,  // 15.01.22
            tmp=tmp+"Listplot("+Textformat(pdata_#,5)+")";
          ,
            tmp=tmp+"Pointdata("+Textformat(pdata_#_1,5)+")";
          );
          GLIST=append(GLIST,tmp); //no ketjs
          tmp1=tmp1+name+"p"+Textformat(#,5)+",";
        );
        tmp1=name+"="+substring(tmp1,0,length(tmp1)-1)+")";
      );
      GLIST=append(GLIST,tmp1); //no ketjs
    );
  );  // 16.04.04 until
  if(Noflg<2,
    if(isstring(Ltype),
      if((Noflg==0)&(color!=KCOLOR), //181020 //no ketjs on
        Texcom("{");Com2nd("Setcolor("+color+")");//180722
      ); //no ketjs off
      Ltype=GetLinestyle(text(Noflg)+Ltype,name);
      if((Noflg==0)&(color!=KCOLOR), //181020 //no ketjs on
        Texcom("}");//180722
      ); //no ketjs off
    ,
      if(Noflg==1,Ltype=0);
    );
    GCLIST=append(GCLIST,[name,Ltype,opcindy]);
  );
);
////%AddGraph end////

////%Joincrvs start////
Joincrvs(nm,plotstrL):=Joincrvs(nm,plotstrL,[]);
Joincrvs(nm,plotstrL,options):=(
//help:Joincrvs("1",["sgAB","sgDCB"]);
  regional(plotlist,PtL,Eps,QdL,Flg,Ni,Qd,pP,pS,pQ,pR,rMN,
        opcindy,tmp,tmp1,tmp2,str,name,Ltype,Noflg,color);
  name="join"+nm;
  plotlist=[];
  forall(plotstrL,str,
    if(isstring(str),
      tmp=parse(str);
      tmp=apply(tmp,LLcrd(#));
    ,
      tmp=str;
    );
    plotlist=append(plotlist,tmp);
  );
  Eps=10^(-4);
  tmp=Divoptions(options);
  Ltype=tmp_1;
  Noflg=tmp_2;
  color=tmp_(length(tmp)-2);
  opcindy=tmp_(length(tmp));
  tmp1=tmp_6;
  if(length(tmp1)>0,Eps=tmp1_1);
  QdL=[];
  forall(plotlist,Qd,
    if(ispoint(Qd_1) % !islist(Qd_1_1),
      QdL=concat(QdL,[Qd]);
    ,
      forall(Qd,
        QdL=concat(QdL,[#]);
      );
    );
  );
  Flg=0;
  if(length(QdL)==0,
    PtL=[];
    Flg=1;
  );
  if(Flg==0,
    PtL=QdL_1;
    forall(2..(length(QdL)),Ni,
      Qd=QdL_Ni;
      if(Numptcrv(Qd)>1,
        pP=Ptend(PtL);
        pS=Ptstart(PtL);
        pQ=Ptstart(Qd);
        pR=Ptend(Qd);
        rMN=min([|pP-pQ|,|pP-pR|,|pS-pQ|,|pS-pR|]);
        if(rMN==|pP-pR|,
          Qd=reverse(Qd);
        ,
          if(rMN==|pS-pQ|,
            PtL=reverse(PtL);
          ,
            if(rMN==|pS-pR|,
              PtL=reverse(PtL);
              Qd=reverse(Qd);
            );
          );
        );
      );
      if(rMN>Eps,
        PtL=concat(PtL,Qd);
      ,
        PtL=concat(PtL,Qd_(2..(length(Qd))));
      );
    );
  );
  if(Noflg<3,
    println("generate joincurve "+name);
    tmp1=apply(PtL,Pcrd(#));
    tmp=name+"="+Textformat(tmp1,5);
    parse(tmp);
    tmp1="";
    forall(plotstrL,
        tmp1=tmp1+#+",";
    );
    tmp1=substring(tmp1,0,length(tmp1)-1);
    GLIST=append(GLIST,name+"=Joincrvs("+tmp1+")"); //no ketjs
  );
  if(Noflg<2,
    if(isstring(Ltype),
      if((Noflg==0)&(color!=KCOLOR), //181020 //no ketjs on
        Texcom("{");Com2nd("Setcolor("+color+")");//180722
      ); //no ketjs off
      Ltype=GetLinestyle(text(Noflg)+Ltype,name);
      if((Noflg==0)&(color!=KCOLOR), //181020 //no ketjs on
        Texcom("}");//180722
      ); //no ketjs off
    ,
      if(Noflg==1,Ltype=0);
    );
    GCLIST=append(GCLIST,[name,Ltype,opcindy]);
  );
  PtL;
);
////%Joincrvs end////

////%Partcrv start////
Partcrv(nm,pA,pB,PkLstr):=Partcrv(nm,pA,pB,PkLstr,[]);
Partcrv(nm,pA,pB,PkLstr,options):=(
//help:Partcrv("1",A,B,"sgABC");
//help:Partcrv("1",1.3,2.5,"sgABC");
  regional(PkL,Ans,Eps,Npt,Out1,Out2,tmp,tmp1,Flg,nS,nE,PPL,pP,
        opcindy,Ta,Tb,name,Ltype,Noflg,DepthFlg,color);
  name="part"+nm;
  if(isstring(PkLstr),PkL=parse(PkLstr),PkL=PkLstr);
  DepthFlg=0;
  if(Measuredepth(PkL)==2,
    PkL=PkL_1;
    DepthFlg=1;
  );
  PkL=apply(PkL,LLcrd(#));
  tmp=Divoptions(options);
  Ltype=tmp_1;
  Noflg=tmp_2;
  color=tmp_(length(tmp)-2);
  opcindy=tmp_(length(tmp));
  Eps=10^(-3);
  Flg=0;
  if(isreal(pA),
    if(pA>pB+Eps,
      Npt=Numptcrv(PkL);
      Out1=Partcrv("",pA,Npt,PkLstr,["nodata"]);
      Out2=Partcrv("",1,pB,PkLstr,["nodata"]);
      tmp=Ptstart(PkL)-Ptend(PkL);
      if(|tmp|<Eps,
        Ans=Joincrvs("",[Out1,Out2],["nodata"]);
      ,
        Ans=[apply(Out1,Pcrd(#)),apply(Out2,Pcrd(#))];
      );
      Flg=1;
    );
    if(Flg==0,
      nS=ceil(pA);
      nE=floor(pB);
      PPL=[];
      if(pA<nS-Eps,
        pP=(nS-pA)*PkL_(nS-1)+(1-nS+pA)*PkL_nS;
        PPL=[pP];
      );
      PPL=concat(PPL,PkL_(nS..nE));
      if(pB>nE+Eps,
        pP=(1-pB+nE)*PkL_nE+(pB-nE)*PkL_(nE+1);
        PPL=concat(PPL,[pP]);
      );
      Ans=PPL;
      Flg=1;
    );
  );
  if(Flg==0,
    tmp=Nearestpt(LLcrd(Pcrd(pA)),PkL);
    Ta=tmp_2;
    tmp=Nearestpt(LLcrd(Pcrd(pB)),PkL); // 15.09.12
    Tb=tmp_2;
    Ans=Partcrv("",Ta,Tb,PkL,["nodata"] );
    Ans=apply(Ans,Pcrd(#));
  );
  if(Noflg<3,
    println("generate partcrv "+name);
    tmp1=apply(Ans,Pcrd(#));
    tmp=name+"="+Textformat(tmp1,5);
    parse(tmp);
//    GLIST=append(GLIST,  // 16.04.03
    if(DepthFlg==0,
      tmp=PkLstr;
    ,
      tmp=PkLstr+"(1)";
    );
    tmp1=name+"=Partcrv("+Textformat(Lcrd(pA),5)
         +","+Textformat(Lcrd(pB),5)+","+tmp+")"; // 16.04.03
    GLIST=append(GLIST,tmp1); //no ketjs
  );
  if(Noflg<2,
    if(isstring(Ltype),
      if((Noflg==0)&(color!=KCOLOR), //181020 //no ketjs on
        Texcom("{");Com2nd("Setcolor("+color+")");//180722
      ); //no ketjs off
      Ltype=GetLinestyle(text(Noflg)+Ltype,name);
      if((Noflg==0)&(color!=KCOLOR), //181020 //no ketjs on
        Texcom("}");//180722
      ); //no ketjs off
    ,
      if(Noflg==1,Ltype=0);
    );
    GCLIST=append(GCLIST,[name,Ltype,opcindy]);
  );
  Ans;
);
////%Partcrv end////

////%Opcrvs start////
Opcrvs(num,Fig):=Opcrvs(num,Fig,["nodisp"]);
Opcrvs(num,Fig,options):=(
  //help:Subgraph(2,"grfs");
  regional(name,tmp,tmp1);
  name="-"+Fig+text(num);
  tmp=Fig+"_"+text(num);
  tmp1=parse(tmp);
  Listplot(name,tmp1,options);
);
////%Opcrvs end////

////%Pointdata start////
Pointdata(nm,list):=Pointdata(nm,list,[]);
Pointdata(nm,listorg,options):=(
//help:Pointdata("1",[2,4],["Size=5"]);
//help:Pointdata("2",[[2,3],[4,1]]);
//help:Pointdata(options=["Size=(1)","Disp=(y)","Inside="]);
//help:Pointdata("Inside=1(def)/ratio/rgblist/colorname/-1"]);
  regional(list,name,nameL,ptlist,opstr,opcindy,Msg,
      eqL,dispflg,size,thick,tmp,tmp1,tmp2,tmp3,
      Ltype,Noflg,color,inside);
  name="pt"+nm;
  nameL=name+"L";
  tmp=Divoptions(options);
  Ltype=tmp_1;
  Noflg=tmp_2;
  eqL=tmp_5;
  opcindy=tmp_(length(tmp));
//  opstr=tmp_(length(tmp)-1);
  color=tmp_(length(tmp)-2);
  size="";
  dispflg="Y";
  inside=color;
  Msg="Y";
  forall(eqL,
    tmp=Strsplit(#,"=");
    tmp1=Toupper(substring(tmp_1,0,1));
    if(tmp1=="S",
      size=Toupper(substring(tmp_2,0,1));;
      opcindy=opcindy+",size->"+text(size); //181013
    );
    if(tmp1=="D", //181030from
      dispflg=Toupper(substring(tmp_2,0,1));
    );
    if(tmp1=="I", //181229from
      if(contains(["","no"],tmp_2),
        if(tmp_2=="no",inside=append(inside,-1));
      ,
        tmp2=substring(tmp_2,0,1);
        if(contains(["-","0","1",".","["],tmp2),
          tmp=parse(tmp_2);
          if(length(tmp)==4,tmp=Colorcmyk2rgb(tmp)); //190115
          if(!isstring(tmp),tmp=[tmp]);
        ,
          tmp=Colorname2rgb(tmp_2);
        );
        inside=concat(inside,tmp);
      );
    ); //181229to
    if(tmp1=="M", //190206from
      Msg=Toupper(substring(tmp_2,0,1));
    ); //190206to
  );
  if(dispflg=="Y", 
    if(Msg=="Y", //190206
      println("generate pointdata "+name);
    );
  ); //181030to
  if(isstring(listorg),
    list=parse(listorg)
  ,
    list=listorg
  ); //17.10.23
  if(Measuredepth(list)==0,list=[list]);//180530
  tmp=Measuredepth(list);
  if(tmp==1,ptlist=list,ptlist=list_1); //190126from
  tmp=apply(ptlist,[Textformat(Pcrd(#),5)]);
  tmp1=text(tmp);
  tmp2=substring(tmp1,1,length(tmp1)-1);
  tmp3=tmp1;
  tmp=parse(tmp1);
  if(length(tmp)==1, //190301from
    tmp1=Textformat(tmp_1,5);
  ); //190301to
  tmp=name+"="+tmp1;
  parse(tmp);
  tmp=nameL+"="+tmp3;
  parse(tmp); //190126to
  if(Noflg<3,
    if(isstring(listorg), //17.10.23
      tmp2=listorg;
    ,
      tmp2="list"+PaO(); //17.10.10from
      forall(list,
        if(isstring(#),
          tmp=#;
        ,
          if(ispoint(#),
            tmp=text(#);
          ,
            tmp=Textformat(#,6);
          );
        );
        tmp2=tmp2+tmp+",";
      );
      tmp2=substring(tmp2,0,length(tmp2)-1)+")";
      //17.10.10until
    );
    GLIST=append(GLIST,name+"=Pointdata("+tmp2+")"); //no ketjs
  );
  if(Noflg<2,
    tmp=[nameL,[0,1],opcindy];  //190126
    GCLIST=append(GCLIST,tmp);
    if(Noflg==0,
      if(length(size)>0,
        Com2nd("Setpt("+size+")");
      );
      thick=PenThick/PenThickInit;  // 16.04.09 from
      if(length(size)>0,tmp1=parse(size),tmp1=1);
      tmp1=max(tmp1,1)/8; 
      Setpen(tmp1); // 16.04.09 until
      if((Noflg==0)&(color!=KCOLOR), //181020 //no ketjs on
        Texcom("{");
        Com2nd("Setcolor("+color+")");//180711
      ); //no ketjs off
      opstr=","+Textformat(inside,2);
      Com2nd("Drwpt"+PaO()+"list"+PaO()+name+")"+opstr+")");
      if((Noflg==0)&(color!=KCOLOR), //181020 //no ketjs on
        Texcom("}");//180711
      ); //no ketjs off
      Setpen(thick); // 16.04.09
      if(length(size)>0, //no ketjs on
        tmp=Textformat(TenSize/TenSizeInit,1);
        Com2nd("Setpt("+tmp+")");
      ); //no ketjs off
    );
  );
  ptlist;
);
////%Pointdata end////

////%Listplot start////
Listplot(list):=Listplot(list,[]);
Listplot(Arg1,Arg2):=(
  regional(name,list,options,str);
  if(isstring(Arg1),
    name=Arg1;
    list=Arg2;
    Listplot(name,list,[]);
  ,
    list=Arg1;
    options=Arg2;
    name="";
    forall(list, // 16.10.07from
       name=name+#.name;
    );// 16.10.07until
    Listplot(name,list,options);
  );
);
Listplot(nm,list,options):=(
//help:Listplot([A,B]);
// help:Listplot(["A","B"]);
//help:Listplot("1",[[2,1],[3,3]]);
//help:Listplot(options2=["Msg=y","Cutend=n"]);//180719
  regional(name,cutend,tmp,tmp1,tmp2,ptlist,Ltype,opcindy,Noflg,eqL,Msg,color);
  if(substring(nm,0,1)=="-",  // 16.01.27 from
    name=substring(nm,1,length(nm));
  ,
    name="sg"+nm;
  ); // upto
  tmp=Divoptions(options);
  Ltype=tmp_1;
  Noflg=tmp_2;
  eqL=tmp_5;
  color=tmp_(length(tmp)-2);
  opcindy=tmp_(length(tmp));
  Msg="Y";  //190206
  cutend=[0,0];//180719
  forall(eqL,
    tmp=Strsplit(#,"=");
    tmp1=Toupper(substring(tmp_1,0,1));
    if(tmp1=="M",
      Msg=Toupper(substring(tmp_2,0,1));
    );
    if(tmp1=="C",//180719from
      tmp2=replace(tmp_2,"[","");
      tmp2=replace(tmp2,"]","");
      cutend=tokenize(tmp2,",");
      if(length(cutend)==1,cutend=[cutend_1,cutend_1]);     
    );//180719to
  );
  if(Noflg<3,
    if(Msg=="Y", //190206
      println("generate Listplot "+name);
    );
    if(isstring(list_1),tmp=apply(list,parse(#)),tmp=list); // 15.03.24
    ptlist=apply(tmp,Pcrd(#));
    if(|cutend|>0,//180719from
      tmp=ptlist_(length(ptlist))-ptlist_1;
      tmp=tmp/|tmp|;
      ptlist_1=ptlist_1+tmp*cutend_1;
      ptlist_(length(ptlist))=ptlist_(length(ptlist))-tmp*cutend_2;
    );//180719to
    tmp=name+"="+Textformat(ptlist,5);
    parse(tmp);
    GLIST=append(GLIST,name+"=Listplot("+Textformat(ptlist,5)+")"); // 180719 //no ketjs
  );
  if(Noflg<2,
    if(isstring(Ltype),
      if((Noflg==0)&(color!=KCOLOR), //181020 //no ketjs on
        Texcom("{");Com2nd("Setcolor("+color+")");//180711
     ); //no ketjs off
      Ltype=GetLinestyle(text(Noflg)+Ltype,name);
      if((Noflg==0)&(color!=KCOLOR), //181020 //no ketjs on
        Texcom("}");//180711
      ); //no ketjs off
    ,
      if(Noflg==1,Ltype=0);
    );
    GCLIST=append(GCLIST,[name,Ltype,opcindy]);
  );
  tmp1=apply(list,Lcrd(#));
  tmp1;
);
////%Listplot end////

////%Lineplot start////
Lineplot(nm,list,optionorg):=(
//help:Lineplot([A,B]);
//help:Lineplot("1",[[2,1],[3,3]]);
  regional(name,Out,tmp,tmp1,tmp2,opstr,opcindy,Mag,Semi,
      Vec,pA,pB,options,Ltype,Noflg,color,Msg,eqL);
  name="ln"+nm;
  options=optionorg;
  Mag=100;
  Semi="";
  Msg="Y";
  tmp=Divoptions(options);
  Ltype=tmp_1;
  Noflg=tmp_2;
  color=tmp_(length(tmp)-2);
  opcindy=tmp_(length(tmp));
  opstr=tmp_(length(tmp)-1);
  eqL=tmp_5;
  forall(eqL,
    tmp=Strsplit(#,"=");
    tmp1=Toupper(substring(tmp_1,0,1));
    if(tmp1=="M", //190206from
      Msg=Toupper(substring(tmp_2,0,1));
      options=remove(options,[#]);
    ); //190206to
  );
  tmp=Divoptions(options);
  opstr=tmp_(length(tmp)-1);
  tmp1=tmp_6;
  if(length(tmp1)>0,Mag=tmp1_1);
  tmp1=tmp_7;
  if(length(tmp1)>0,Semi=tmp1_1);
  pA=Lcrd(list_1); pB=Lcrd(list_2);
  Vec= Mag/dist(pA,pB)*(pB-pA);
  if(length(Semi)==0,
    Out=[pA-Vec,pA+Vec];
  ,
    if(Semi=="+",   
      Out=[pA,pA+Vec];
    ,
      Out=[pA-Vec,pA];
    );
  );
  if(Noflg<3,
    if(Msg=="Y", //190206
      println("generate Lineplot "+name);
    );
    tmp1=apply(Out,Pcrd(#));
    tmp=name+"="+Textformat(tmp1,5);
    parse(tmp);
    GLIST=append(GLIST,name+"=Lineplot("+Textformat(list,5)+opstr+")"); //no ketjs
  );
  if(Noflg<2,
    if(isstring(Ltype),
      if((Noflg==0)&(color!=KCOLOR), //181020 //no ketjs on
        Texcom("{");Com2nd("Setcolor("+color+")");//180722
      ); //no ketjs off
      Ltype=GetLinestyle(text(Noflg)+Ltype,name);
      if((Noflg==0)&(color!=KCOLOR), //181020 //no ketjs on
        Texcom("}");//180722
      ); //no ketjs off
    ,
      if(Noflg==1,Ltype=0);
    );
    GCLIST=append(GCLIST,[name,Ltype,opcindy]);
  );
  Out;
);
Lineplot(Arg1,Arg2):=(
  regional(name,list,options,str);
  if(isstring(Arg1),
    name=Arg1;
    list=Arg2;
    Lineplot(name,list,[]);
  ,
    list=Arg1;
    options=Arg2;
    name="";
    forall(list, // 16.10.07from
       name=name+#.name;
    );// 16.10.07until
    Lineplot(name,list,options);
  );
);
Lineplot(list):=Lineplot(list,[]);
////%Lineplot end////

////%Plotdata start////
Plotdata(name1,func,variable):=Plotdata(name1,func,variable,[]);
Plotdata(name1,func,variable,options):=(
//help:Plotdata("1","sin(x)","x",["Num=100"]);
//help:Plotdata("2","x^2","x=[-1,1]");
//help:Plotdata("3","Fout(x)","x",["out"]);
  regional(Fn,Va,tmp,tmp1,tmp2,eqL,name,Vname,x1,x2,dx,
         PdL,Num,Ec,Dc,Fun,Exfun,x,Ke,Eps,Pa,Msg,
         Ltype,Noflg,Inflg,Outflg,opstr,opcindy,color);
  name="gr"+name1;
  tmp=Divoptions(options);
  Ltype=tmp_1;
  Noflg=tmp_2;
  Inflg=tmp_3;
  Outflg=tmp_4;
  opstr=tmp_(length(tmp)-1);
  color=tmp_(length(tmp)-2);
  opcindy=tmp_(length(tmp));
  eqL=tmp_5;
  Num=50;
  Ec=[];
  Exfun="";
  Dc=1000;
  Msg="Y";
  forall(eqL,
    tmp=Strsplit(#,"=");
    tmp1=Toupper(substring(#,0,1));
    if(tmp1=="N",
      Num=parse(tmp_2);
      opstr=opstr+","+Dqq(#);
    );
    if(tmp1=="E",
      if(substring(tmp_2,0,1)=="[", //180817from
        Ec=parse(tmp_2);
        tmp1=replace(tmp_2,"[","c"+PaO());
        tmp1=replace(tmp1,",",".0,");
        tmp1=replace(tmp1,"]",".0)");
        opstr=opstr+","+Dqq("Exc="+tmp1); //180817to
      ,
        Exfun=tmp1;
        opstr=opstr+","+Dqq(#);
      );
    );
    if(substring(#,0,1)=="D",
      Dc=parse(tmp_2);
      opstr=opstr+","+Dqq(#);
    );
    if(tmp1=="M", //190206from
      Msg=Toupper(substring(tmp_2,0,1));
    ); //190206to
  );
  if(Inflg==0 & Outflg==0,
    Eps=10^(-3);
    tmp=replace(func,LFmark,"");
    tmp=tokenize(variable,"=");
    Vname=tmp_1;
    if(length(tmp)>1,
      tmp=tmp_2;
      tmp=parse(tmp);
      x1=tmp_1;
      x2=tmp_2;
      ,
      x1=XMIN;
      x2=XMAX;
    );
  //  dx=(x2-x2)/Num;  
    Ec=append(sort(Ec),10000);
    Fun=Assign(func,Vname, "xx");
    Exfun=Assign(Exfun,Vname, "xx");
    PdL=[];
    Ke=1;
    forall(0..Num, 
      xx=x1+#*(x2-x1)/Num; // differs from Scilab [ / Num-1]
      if(length(Exfun)>0,
        tmp=parse(Exfun);
        if(abs(tmp)<Eps,
          if(length(PdL)>0, //180817from
            PdL=concat(PdL,["inf"]);
          );
        ,
          tmp=[xx,parse(Fun)];
          if(length(PdL)>0,
            tmp1=PdL_(length(PdL));
            if(Norm(tmp,tmp1)<Dc,
              PdL=append(PdL,tmp);
            ,
              if(tmp1=="inf",
                PdL=append(PdL,tmp);
              ,
                PdL=concat(PdL,[["inf"],tmp]);
              );
          );
          ,
            PdL=[tmp];
          );
        ); //180817to
      ,
        Pa=[];
        if(xx-Ec_Ke<-Eps,
          Pa=[xx,parse(Fun)];
        );
        if(abs(xx-Ec_Ke)<=Eps,
          if(length(PdL)>0,
            if(PdL_(length(PdL))_1!="inf",
              Pa=["inf"];
            );
          );
        );
        if(xx-Ec_Ke>Eps,
          Pa=[xx,parse(Fun)];
          Ke=Ke+1;
        );
        if(length(Pa)>0,
          if(Pa_1=="inf",
            PdL=concat(PdL,[Pa]);
          ,
            if(length(PdL)==0,
              PdL=[Pa];
            ,
              tmp=PdL_(length(PdL));
              if(tmp_1=="inf",
                PdL=concat(PdL,[Pa]);
              ,
                if(dist(tmp,Pa)<Dc,
                  PdL=concat(PdL,[Pa]);
                ,
                  PdL=concat(PdL,[["inf"],Pa]);
                );
              );
            );
          );
        );
      );
    );
    tmp1=[];
    tmp2=select(1..(length(PdL)),PdL_#==["inf"]);
    tmp=1;
    forall(tmp2,
      if(#>tmp,
        tmp1=concat(tmp1,[PdL_(tmp..(#-1))])
      );
      tmp=#+1;
    );
    if(tmp<length(PdL),
      tmp1=concat(tmp1,[PdL_(tmp..(length(PdL)))]);
    );
    PdL=tmp1;
    if(length(PdL)==1,
      PdL=PdL_1;
    );
    if(Noflg<3,
      if(Msg=="Y", //190206
        println("generate Plotdata "+name);
      );
      if(Measuredepth(PdL)==1,
        tmp1=apply(PdL,Pcrd(#));
      ,
        tmp1=[];
        forall(PdL,tmp2,
          tmp1=append(tmp1,apply(tmp2,Pcrd(#)));
        );
      );
      tmp=name+"="+Textformat(tmp1,5);
      parse(tmp);
      tmp1=replace(func,LFmark,""); //no ketjs on
      tmp2=replace(variable,LFmark,"");
      tmp=name+"=Plotdata('"+tmp1+"','"+tmp2+"'"+opstr+")";
      GLIST=append(GLIST,tmp); //no ketjs off
    );
    if(Noflg<2,
      if(isstring(Ltype),
        if((Noflg==0)&(color!=KCOLOR), //181020 //no ketjs on
          Texcom("{");Com2nd("Setcolor("+color+")");//180722
        ); //no ketjs off
        Ltype=GetLinestyle(text(Noflg)+Ltype,name);
        if((Noflg==0)&(color!=KCOLOR), //181020 //no ketjs on
          Texcom("}");//180722
        ); //no ketjs off
     ,
        if(Noflg==1,Ltype=0);
      );
      GCLIST=append(GCLIST,[name,Ltype,opcindy]);
    );
    PdL;
  , 
    if(Noflg<2,
      if(isstring(Ltype),
        if((Noflg==0)&(color!=KCOLOR), //181020 //no ketjs on
          Texcom("{");Com2nd("Setcolor("+color+")");//180722
        ); //no ketjs off
        Ltype=GetLinestyle(text(Noflg)+Ltype,name);
        if((Noflg==0)&(color!=KCOLOR), //181020 //no ketjs on
          Texcom("}");//180722
        ); //no ketjs off
      ,
        if(Noflg==1,Ltype=0);
      );
      if(Inflg==1,
        GCLIST=append(GCLIST,[name,Ltype,opcindy]);
      );
    );
  );
);
////%Plotdata end////

////%Paramplot start////
Paramplot(nm,funstr,variable):=Paramplot(nm,funstr,variable,[]);
Paramplot(nm,funstr,variable,options):=(
//help:Paramplot("1","[2*cos(t),sin(t)]","t=[0,2*pi]");
  regional(name,Out,tmp,tmp1,tmp2,vname,func,str,Rng,Num,Msg,
        Ec,Exfun,Dc,eqL,Fntmp,Vatmp,t1,t2,dt,tt,pa,ke, pt, //190103
        Ltype,Noflg,Inflg,Outflg,opstr,opcindy,color);
  if(substring(nm,0,1)=="-",  // 180928from
    name=substring(nm,1,length(nm));
  ,
    name="gp"+nm;
  ); //180929to
  Eps=10^(-4);
  tmp=Divoptions(options);
  Ltype=tmp_1;
  Noflg=tmp_2;
  Inflg=tmp_3;
  Outflg=tmp_4;
  color=tmp_(length(tmp)-2);
  opstr=tmp_(length(tmp)-1);
  opcindy=tmp_(length(tmp));
  eqL=tmp_5;
  Num=50;
  Ec=[];
  Exfun="";
  Dc=1000;
  forall(eqL,
    tmp=Strsplit(#,"=");
    tmp1=Toupper(substring(tmp_1,0,1));
    if(tmp1=="N",
      Num=parse(tmp_2);
      opstr=opstr+","+Dqq(#);
    );
    if(tmp1=="E",
      if(substring(tmp_2,0,1)=="[", //180817from
        Ec=parse(tmp_2);
        tmp1=replace(tmp_2,"[","c"+PaO());
        tmp1=replace(tmp1,",",".0,");
        tmp1=replace(tmp1,"]",".0)");
        opstr=opstr+","+Dqq("Exc="+tmp1); //180817to
      ,
        Exfun=tmp1;
        opstr=opstr+","+Dqq(#);
      );
    );
    if(substring(#,0,1)=="D",
      Dc=parse(tmp_2);
      opstr=opstr+","+Dqq(#);
    );
    if(tmp1=="M", //190206from
      Msg=Toupper(substring(tmp_2,0,1));
    ); //190206to
  );
  if(Inflg==0 & Outflg==0,
    tmp=indexof(variable,"=");
    vname=substring(variable,0,tmp-1);
    str=substring(variable,tmp,length(variable));
    Rng=parse(str);
    t1=Rng_1; t2=Rng_2;
    dt=(t2-t1)/Num;// differs from Scilab ( / Num-1)
    func=Assign(funstr,vname,"tt");
    Out=[];
    Ec=append(sort(Ec),10000);
    ke=1;
    forall(0..Num, 
      pt=[];
      tt=Rng_1+#*dt;
      if(tt-Ec_ke<-Eps,
        pa=parse(func);
      );
      if(abs(tt-Ec_ke)<=Eps,
        if(length(Out)>0,
          if(Out_(length(Out))_1!="inf",
            pa=["inf"];
          );
        );
      );
      if(tt-Ec_ke>Eps,
        pa=parse(func);
        ke=ke+1;
      );
      if(length(pa)>0,
        if(pa_1=="inf",
          Out=append(Out,pa);
        ,
          if(length(Out)==0,
            Out=[pa];
          ,
            tmp=Out_(length(Out));
            if(tmp_1=="inf",
              Out=append(Out,pa);
            ,
              if(|tmp-pa|<Dc,
                if(|tmp-pa|>Eps, //180928from
                  Out=append(Out,pa);
                );  //180928to
              ,
                Out=concat(Out,[["inf"],pa]);
              );
            );
          );
        );
      );
    );
    tmp1=[];
    tmp2=select(1..(length(Out)),Out_#==["inf"]);
    tmp=1;
    forall(tmp2,
      if(#>tmp,
        tmp1=concat(tmp1,[Out_(tmp..(#-1))])
      );
      tmp=#+1;
    );
    if(tmp<length(Out),
      tmp1=concat(tmp1,[Out_(tmp..(length(Out)))]);
    );
    Out=tmp1;
    if(length(Out)==1,
      Out=Out_1;
    );
    if(Noflg<3,
      if(Msg=="Y", //190206
        println("generate Paramplot "+name);
      );
      if(Measuredepth(Out)==1,
        tmp1=apply(Out,Pcrd(#));
      ,
        tmp1=[];
        forall(Out,tmp2,
          tmp1=append(tmp1,apply(tmp2,Pcrd(#)));
        );
      );
      tmp=name+"="+Textformat(tmp1,5);
      parse(tmp);
      tmp1=replace(funstr,LFmark,"");  // 15.11.13 //no ketjs on
      tmp2=replace(variable,LFmark,"");
      tmp=name+"=Paramplot('"+tmp1+"','"+tmp2+"'"+opstr+")";
      GLIST=append(GLIST,tmp); //no ketjs off
    );
    if(Noflg<2,
      if(isstring(Ltype),
        if((Noflg==0)&(color!=KCOLOR), //181020 //no ketjs on
          Texcom("{");Com2nd("Setcolor("+color+")");//180722
        ); //no ketjs off
        Ltype=GetLinestyle(text(Noflg)+Ltype,name);
        if((Noflg==0)&(color!=KCOLOR), //181020 //no ketjs on
          Texcom("}");//180722
        ); //no ketjs off
      ,
        if(Noflg==1,Ltype=0);
      );
      GCLIST=append(GCLIST,[name,Ltype,opcindy]);
    );
    Out;
  , 
    if(Noflg<2,
      if(isstring(Ltype),
        if((Noflg==0)&(color!=KCOLOR), //181020 //no ketjs on
          Texcom("{");Com2nd("Setcolor("+color+")");//180722
        ); //no ketjs off
        Ltype=GetLinestyle(text(Noflg)+Ltype,name);
        if((Noflg==0)&(color!=KCOLOR), //181020 //no ketjs on
          Texcom("}");//180722
        ); //no ketjs off
      ,
        if(Noflg==1,Ltype=0);
      );
      if(Inflg==1,
        GCLIST=append(GCLIST,[name,Ltype,opcindy]);
      );
    );
  );
);
////%Paramplot end////

////%Polarplot start////
// 180928
Polarplot(name,radstr,varrng):=Polarplot(name,radstr,varrng,[]);
Polarplot(name,radstr,varrng,option):=(
//help:Polarplot("1","cos(t)","t=[0,2*pi]");
  regional(tmp,var);
  tmp=Strsplit(varrng,"=");
  var=tmp_1;
  tmp="("+radstr+")*[cos("+var+"),sin("+var+")]";
  Paramplot("-polar"+name,tmp,varrng,option);
);
////%Polarplot end////

////%Connectseg start////
Connectseg(Pdata):=(
  regional(Eps,PlotL,vL,ctr,qd,ah,ao,flg,jj,
      pp,qq,tmp,tmp1,tmp2);
  Eps=10^(-4);
  PlotL=[Pdata_1];
  vL=2..(length(Pdata));
  ctr=0;
  while((length(vL)>0)&(ctr<1000),
    ctr=ctr+1;
    qd=PlotL_(length(PlotL));
    ah=qd_1; ao=qd_(length(qd));
    flg=0;
    forall(1..(length(vL)),jj,
      if(flg==0,
        tmp1=Pdata_(vL_jj);
        pp=tmp1_1; qq=tmp1_(length(tmp1));
        if(Norm(pp-ao)<Eps,
          tmp=tmp1_(2..(length(tmp1)));
           if(length(tmp)>0,
            qd=concat(qd,tmp);
          );
          PlotL_(length(PlotL))=qd;
          vL=remove(vL,[vL_jj]);
          flg=1;
        );
      );
      if(flg==0,
        if(Norm(qq-ao)<Eps,
          tmp=tmp1_(1..(length(tmp1)-1));
          tmp=reverse(tmp);
          qd=concat(qd,tmp);
          PlotL_(length(PlotL))=qd;
          vL=remove(vL,[vL_jj]);
          flg=1;
        );
      );
      if(flg==0,
        if(Norm(pp-ah)<Eps,
          tmp=tmp1_(2..(length(tmp1)));
          qd=concat(tmp,qd);
          PlotL_(length(PlotL))=qd;
          vL=remove(vL,[vL_jj]);
         flg=1;
        );
      );
      if(flg==0,
        if(Norm(qq-ah)<Eps,
          tmp=tmp1_(1..(length(tmp1)-1));
          tmp=reverse(tmp);
          qd=concat(tmp,qd);
          PlotL_(length(PlotL))=qd;
          vL=remove(vL,[vL_jj]);
          flg=1;
        );
      );
    );
    if(flg==0,
      PlotL=concat(PlotL,[Pdata_(vL_1)]); //181112
      vL=remove(vL,[vL_1]);
    );
  );
  PlotL;
);
////%Connectseg end////

////%Implicitplot start////
Implicitplot(name1,func,xrng,yrng):=Implicitplot(name1,func,xrng,yrng,[]);
Implicitplot(name1,func,xrng,yrng,optionsorg):=(
//help:Implicitplot("1","x^2+x*y+y^2=1","x=[-3,3]","y=[-3,3]");
//help:Implicitplot(options=["Num=[50,50]","Msg=y(n)"]);
  regional(name,options,Fn,varx,vary,rngx,rngy,Mdv,Ndv,tmp,tmp1,tmp2,
      Eps,Ltype,Noflg,eqL,color,opsr,opcindy,dx,dy,out,jj,ii,kk,msg,
      yval1,yval2,xval1,xval2,eval11,eva12,eval21,eval22,pL,vL,qL);
  name="imp"+name1;
  Eps=10^(-4);
  options=optionsorg;
  tmp=Divoptions(options);
  Ltype=tmp_1;
  Noflg=tmp_2;
  eqL=tmp_5;
  color=tmp_(length(tmp)-2);
  opcindy=tmp_(length(tmp));
  Mdv=50;Ndv=50;
  msg="Y";
  forall(eqL,
    tmp=Strsplit(#,"=");
    tmp1=Toupper(substring(tmp_1,0,1));
    tmp2=tmp_2;
    if(substring(#,0,1)=="N",
      Mdv=parse(tmp2);
      if(!islist(Mdv),
        Ndv=Mdv;
      ,
        Ndv=Mdv_2;
        Mdv=Mdv_1;
      );
      opstr=",'"+#+"'";
    );
    if(substring(#,0,1)=="M", //181112from
      msg=Toupper(substring(tmp2,0,1));
      options=remove(options,[#]);
    ); //181112to
  );
  tmp=indexof(func,"=");
  if(tmp==0,
    Fn=func;
  ,
    tmp1=substring(func,0,tmp-1);
    tmp2=substring(func,tmp,length(func));
    Fn=tmp1+"-("+tmp2+")";
  );
  tmp=indexof(xrng,"=");
  varx=substring(xrng,0,tmp-1);
  rngx=parse(substring(xrng,tmp,length(xrng)));
  tmp=indexof(yrng,"=");
  vary=substring(yrng,0,tmp-1);
  rngy=parse(substring(yrng,tmp,length(yrng)));
  tmp="Impfun("+varx+","+vary+"):="+Fn;
  parse(tmp);
  dx=(rngx_2-rngx_1)/Mdv;
  dy=(rngy_2-rngy_1)/Ndv;
  out=[];  
  forall(1..Ndv,jj,
    yval1=rngy_1+(jj-1)*dy;
    yval2=rngy_1+jj*dy;
    xval1=rngx_1;
    eval11=Impfun(xval1,yval1);
    eval12=Impfun(xval1,yval2);
    forall(1..Mdv,ii,
      xval2=rngx_1+ii*dx;
      eval21=Impfun(xval2,yval1);
      eval22=Impfun(xval2,yval2);
      pL=[[xval1,yval1]];vL=[eval11];
      pL=append(pL,[xval2,yval1]);vL=append(vL,eval21);
      pL=append(pL,[xval2,yval2]);vL=append(vL,eval22);
      pL=append(pL,[xval1,yval2]);vL=append(vL,eval12);
      pL=append(pL,[xval1,yval1]);vL=append(vL,eval11);
      qL=[];
      forall(1..4,kk,
        if(abs(vL_kk)<=Eps,
          qL=append(qL,pL_kk);
        ,
          if(vL_kk>Eps,
            if(vL_(kk+1)< -Eps,
              tmp=1/(vL_kk-vL_(kk+1))*
                    (-vL_(kk+1)*pL_kk+vL_kk*pL_(kk+1));
              qL=append(qL,tmp);
            );
          ,
            if(vL_(kk+1)>Eps,
              tmp=1/(-vL_kk+vL_(kk+1))*
                    (vL_(kk+1)*pL_kk-vL_kk*pL_(kk+1));
              qL=append(qL,tmp);
            );
          );
        );
      );
      xval1=xval2;
      eval11=eval21;
      eval12=eval22;
      if(length(qL)==2,
        out=append(out,qL);
      );
    );
  );
  if(length(out)>0,
    out=Connectseg(out);
  );
  if(length(out)==1,
    out=out_1;
  );
  if(Noflg<3,
    if(msg=="Y", //181112
      println("generate Implicitplotdata "+name);
    );
    if(Measuredepth(out)==1,
      tmp1=apply(out,Pcrd(#));
    ,
      tmp1=[];
      forall(out,tmp2,
        tmp1=append(tmp1,apply(tmp2,Pcrd(#)));
      );
    );
    tmp=name+"="+Textformat(tmp1,5);
    parse(tmp);
    tmp=name+"=Implicitplot('"+func+"','"+xrng+"','"+yrng+"'"+opstr+")"; //no ketjs
    GLIST=append(GLIST,tmp); //no ketjs
  );
  if(Noflg<2,
    if(isstring(Ltype),
     if((Noflg==0)&(color!=KCOLOR), //181020 //no ketjs on
        Texcom("{");Com2nd("Setcolor("+color+")");//180722
      ); //no ketjs off
      Ltype=GetLinestyle(text(Noflg)+Ltype,name);
      if((Noflg==0)&(color!=KCOLOR), //181020 //no ketjs on
        Texcom("}");//180722
      ); //no ketjs off
    ,
      if(Noflg==1,Ltype=0);
    );
    GCLIST=append(GCLIST,[name,Ltype,opcindy]);
  );
  out;
);
////%Implicitplot end////

////%Circledata start////
Circledata(cenrad):=Circledata(cenrad,[]);
Circledata(para1,para2):=(
//help:Circledata([A,B],["Rng=[0,pi/2]"]);
//help:Circledata([A,B,C]);
  regional(name,cenrad,options,str,n); 
  if(isstring(para1), 
    name=para1;
    cenrad=para2;
    options=[];
    ,
    cenrad=para1;
    options=para2;
    name="";// 16.10.07from
    forall(cenrad, 
       name=name+#.name;
    );// 16.10.07until
  );
  Circledata(name,cenrad,options);
);
Circledata(nm,cenrad,options):=(
  regional(name,Out,Ctr,Ptcir,ra,Num,Rg,opstr,opcindy,color,Msg,
      tmp,tmp1,tmp2,Th,Ltype,Noflg,eqL,pA,pB,pC,d1,d2,Eps);  
  name="cr"+nm;
  tmp=Divoptions(options);
  Ltype=tmp_1;
  Noflg=tmp_2;
  eqL=tmp_5;
  color=tmp_(length(tmp)-2);
  opstr=tmp_(length(tmp)-1);
  opcindy=tmp_(length(tmp));
  Num=50;
  Rg=[0,2*pi];
  Msg="Y";
  forall(eqL,
    tmp=Strsplit(#,"=");
    tmp1=Toupper(substring(tmp_1,0,1));
    if(substring(#,0,1)=="N",
      Num=parse(tmp_2);
     opstr=opstr+",'"+#+"'";
    );
    if(substring(#,0,1)=="R",
      Rg=parse(tmp_2);
      opstr=opstr+",'"+#+"'";
    );
    if(tmp1=="M", //190206from
      Msg=Toupper(substring(tmp_2,0,1));
    ); //190206to
  );
  if(length(cenrad)==2,
    Ctr=Lcrd(cenrad_1);
    Ptcir=Lcrd(cenrad_2);
    ra=dist(Ctr,Ptcir);
  ,
    Eps=10^(-1);
    pA=Lcrd(cenrad_1);
    pB=Lcrd(cenrad_2);
    pC=Lcrd(cenrad_3);
    tmp=pB-pA;
    tmp1=(tmp_2,-tmp_1);
    tmp=pC-pB;
    tmp2=(tmp_2,-tmp_1);
    d1=det([tmp1,tmp2]);
    d2=det([pC-pA,tmp2]);
    if(abs(d1)<Eps & abs(d2)>10*Eps,
      println("points are in a line");
      ra=0;
    ,
      Ctr=1/2*(pA+pB)+1/2*d2/d1*tmp1;
      ra=|pA-Ctr|;
      tmp=name+"center="+Ctr;
      parse(tmp);
      Defvar(name+"center",Ctr);
    );
  );
  if(ra>0,
    Out=[];
    forall(0..Num,
      Th=Rg_1+#*(Rg_2-Rg_1)/Num;
      Out=append(Out,Ctr+ra*[cos(Th),sin(Th)]);
    );
  ,
    Out=Lineplot("1",[pA,pB],["nodata"]);
  );
  if(Noflg<3,
    if(Msg=="Y", //190206
      println("generate Circledata "+name);
    );
    tmp1=apply(Out,Pcrd(#));
    tmp=name+"="+Textformat(tmp1,5);
    parse(tmp);
    if(length(cenrad)==2, //no ketjs on
      tmp=name+"=Circledata("+cenrad+opstr+")";
    ,
      if(ra>0,
        tmp=name+"=Circledata(["+Ctr+","+cenrad_1+"]"+opstr+")";
      ,
        tmp=name+"=Lineplot("+cenrad_1+","+cenrad_2+")";
      );
    );
    GLIST=append(GLIST,tmp);  //no ketjs off
  );
  if(Noflg<2,
    if(isstring(Ltype),
      if((Noflg==0)&(color!=KCOLOR), //181020 //no ketjs on
        Texcom("{");Com2nd("Setcolor("+color+")");//180722
      ); //no ketjs off
      Ltype=GetLinestyle(text(Noflg)+Ltype,name);
      if((Noflg==0)&(color!=KCOLOR), //181020 //no ketjs on
        Texcom("}");//180722
      ); //no ketjs off
    ,
      if(Noflg==1,Ltype=0);
    );
    GCLIST=append(GCLIST,[name,Ltype,opcindy]);
  );
  Out;
);
////%Circledata end////

////%Framedata start////
Framedata():=Framedata(["dr"]);//16.10.29from
Framedata(list):=(
  regional(pA,pB);
  if(Measuredepth(list)==0,
    pA=LLcrd((SW+NE)/2); // 15.09.17
    pB=LLcrd(NE);
    Framedata("win",[pA,pB],list);
  ,
    Framedata(list,[]);
  );
);//16.10.29until
Framedata(Arg1,Arg2):=(
  regional(name,list,options,str);
  if(isstring(Arg1),
    name=Arg1;
    list=Arg2;
    Framedata(name,list,[]);
  ,
    list=Arg1;
    options=Arg2;
    name="";// 16.10.07from
    forall(list, 
       name=name+#.name;
    );// 16.10.07until
    Framedata(name,list,options);
  );
);
Framedata(nm,list,optionsorg):=(
//help:Framedata();
//help:Framedata([C,A]);
//help:Framedata("1",[C,A]);
//help:Framedata("1",[A,B],["corner"]);
//help:Framedata("1",[C,dx,dy]);
  regional(name,options,Out,tmp,tmp1,pB,x1,x2,y1,y2,dx,dy,
      opcindy,Ltype,Noflg,strL,type,cent,dx,dy,color);
  name="fr"+nm;
  options=optionsorg;
  tmp=Divoptions(options);
  Ltype=tmp_1;
  Noflg=tmp_2;
  strL=tmp_7; //180801from
  type="center";
  forall(strL,
    if(Toupper(#)=="CORNER",
      type="corner";
      options=remove(options,[#]);
    );
    if(Toupper(#)=="CENTER",
      type="center";
      options=remove(options,[#]);
    );
  );
  if(type=="corner",
    Out=Framedata2(nm,list,options);
  ,  //180801to
    color=tmp_(length(tmp)-2);
    opcindy=tmp_(length(tmp));
    if(length(list)==2,  // 15.05.12
      pA=Lcrd(list_1); pB=Lcrd(list_2);
      dx=abs(pB_1-pA_1); dy=abs(pB_2-pA_2);
    ,
      pA=Lcrd(list_1);
      dx=list_2; dy=list_3;
    );
    x1=pA_1-dx; x2=pA_1+dx;
    y1=pA_2-dy; y2=pA_2+dy;
    Out=[[x1,y1],[x2,y1],[x2,y2],[x1,y2],[x1,y1]];
    if(Noflg<3,
      println("generate Framedata "+name);
      tmp1=apply(Out,Pcrd(#));
      tmp=name+"="+Textformat(tmp1,5);
      parse(tmp);
      GLIST=append(GLIST,name+"=Framedata("+pA+","+dx+","+dy+")"); //no ketjs
    );
    if(Noflg<2,
      if(isstring(Ltype),
        if((Noflg==0)&(color!=KCOLOR), //181020 //no ketjs on
          Texcom("{");Com2nd("Setcolor("+color+")");//180722
        ); //no ketjs off
        Ltype=GetLinestyle(text(Noflg)+Ltype,name);
        if((Noflg==0)&(color!=KCOLOR), //181020 //no ketjs on
          Texcom("}");//180722
        ); //no ketjs off
      ,
        if(Noflg==1,Ltype=0);
      );
      GCLIST=append(GCLIST,[name,Ltype,opcindy]);
    );
  );
  Out;
);
Framedata(nm,cent,dx,dy):=Framedata(nm,cent,dx,dy,[]);
Framedata(nm,cent,dx,dy,options):=(
  regional(name,Out,tmp,tmp1,x1,y1,x2,y2,Ltype,opcindy,Noflg,color);
  name="fr"+nm;
  tmp=Divoptions(options);
  Ltype=tmp_1;
  Noflg=tmp_2;
  color=tmp_(length(tmp)-2);
  opcindy=tmp_(length(tmp));
  x1=cent.x-dx; x2=cent.x+dx;
  y1=cent.y-dy; y2=cent.y+dy;
  Out=[[x1,y1],[x2,y1],[x2,y2],[x1,y2],[x1,y1]];
  if(Noflg<3,
    println("generate Framedata "+name);
    tmp1=apply(Out,Pcrd(#));
    tmp=name+"="+Textformat(tmp1,5);
    parse(tmp);
    GLIST=append(GLIST,name+"=Framedata("+cent.xy+","+dx+","+dy+")"); //no ketjs
  );
  if(Noflg<2,
    if(isstring(Ltype),
      if((Noflg==0)&(color!=KCOLOR), //180904 //no ketjs on
        Texcom("{");Com2nd("Setcolor("+color+")");//180722
      ); //no ketjs off
      Ltype=GetLinestyle(text(Noflg)+Ltype,name);
      if((Noflg==0)&(color!=KCOLOR), //180904 //no ketjs on
        Texcom("}");//180722
      ); //no ketjs off
    ,
      if(Noflg==1,Ltype=0);
    );
    GCLIST=append(GCLIST,[name,Ltype,opcindy]);
  );
  Out;
);
////%Framedata end////

////%Framedata2 start////
Framedata2(nm,list):=Framedata2(nm,list,[]);
Framedata2(nm,list,options):=(
//help:Framedata2("1",[A,B]);
  regional(tmp,tmp1,pC,pB);
  pC=(Lcrd(list_1)+Lcrd(list_2))/2;
  pB=Lcrd(list_2);
  Framedata(nm,[pC,pB],options);
);
////%Framedata2 end////

////%Ovaldata start////
Ovaldata(nm,Pdata):=Ovaldata(nm,Pdata,[]);
Ovaldata(nm,Pdata,options):=(
//help:Ovaldata("1",[A,B]);
//help:Ovaldata(optios=[size]);
  regional(name,Graph,Ctr,Dx,Dy,Rc,Out,Point,Graph,
      opstr,opcindy,tmp,tmp1,tmp2,tmp3,Ltype,Noflg,color);  
  name="ov"+nm;
  tmp=Divoptions(options);
  Ltype=tmp_1;
  Noflg=tmp_2;
  color=tmp_(length(tmp)-2);
  opcindy=tmp_(length(tmp));
  opstr=tmp_(length(tmp)-1);
  Rc=0.2;
  tmp1=tmp_6;
  if(length(tmp1)>0,Rc=tmp1_1*Rc);
//  if(length(tmp1)>0,Rc=tmp1_1);  //15.11.15
  Ctr=Lcrd(Pdata_1);
  if(ispoint(Pdata_2) % islist(Pdata_2),
    tmp1=Lcrd(Pdata_2);
    Dx=abs(tmp1_1-Ctr_1);
    Dy=abs(tmp1_2-Ctr_2);
  ,
    Dx=Pdata_2;
    Dy=Pdata_3;
  );
  Point=Ctr+[Dx-Rc,Dy-Rc];
  tmp2=Listplot("1",[Ctr+[Dx-Rc,Dy],Ctr+[0,Dy]],
     ["nodata"]);
  tmp3=Listplot("2",[Ctr+[Dx,0],Ctr+[Dx,Dy-Rc]],
     ["nodata"]);
  if(Rc>0, //180624from
    tmp1=Circledata("1",[Point,Point+[Rc,0]],
       ["Rng=[0,pi/2]","Num=10","nodata"]);
    Graph=Joincrvs("1",[tmp3,tmp1,tmp2],["nodata"]);
  ,
    Graph=Joincrvs("1",[tmp3,tmp2],["nodata"]);
  ); //180624to
  tmp1=Reflectdata("1",[Graph],[Ctr,Ctr+[0,1]],["nodata"]);
  Graph=Joincrvs("1",[Graph,tmp1],["nodata"]);
  tmp2=Reflectdata("2",[Graph],[Ctr,Ctr+[1,0]],
     ["nodata"]);
  Graph=Joincrvs("2",[Graph,tmp2],["nodata"]);
  if(Noflg<3,
    println("generate Ovaldata "+name);
    tmp1=apply(Graph,Pcrd(#));
    tmp=name+"="+Textformat(tmp1,5);
    parse(tmp);
    GLIST=append(GLIST, //no ketjs
      name+"=Ovaldata("+Ctr+","+Dx+","+Dy+opstr+")");//16.01.30 //no ketjs
  );
  if(Noflg<2,
    if(isstring(Ltype),
      if((Noflg==0)&(color!=KCOLOR), //180904 //no ketjs on
        Texcom("{");Com2nd("Setcolor("+color+")");//180722
      ); //no ketjs off
      Ltype=GetLinestyle(text(Noflg)+Ltype,name);
      if((Noflg==0)&(color!=KCOLOR), //180904 //no ketjs on
        Texcom("}");//180722
      ); //no ketjs off
    ,
      if(Noflg==1,Ltype=0);
    );
    GCLIST=append(GCLIST,[name,Ltype,opcindy]);
    tmp1=apply(Graph,Pcrd(#));
    tmp=name+"="+Textformat(tmp1,5);
    parse(tmp);
    tmp=Textformat(Ctr,5)+","+Textformat(Dx,5)+","+Textformat(Dy,5);
  );
  Graph;
);
////%Ovaldata end////

////%Segmark start////
Segmark(nm,ptlist):=Drawsegmark(nm,ptlist,[]);
Segmark(nm,ptlist,options):=Drawsegmark(nm,ptlist,options);//180704
Drawsegmark(nm,ptlist):=Drawsegmark(nm,ptlist,[]);
Drawsegmark(nm,ptlist,options):=(
//help:Segmark("1",[A,B]);
//help:Segmark(options=["Type=1","Width=1","Size=1"]);
  regional(name,pA,pB,wid,mid,size,tp,dir,nor,eqL,color, //180704
      tmp,tmp1,tmp2);
  name="mrk"+nm;
  pA=ptlist_1;
  pB=ptlist_2;
  size=0.15;
  wid=0.05;
  tp=1;
  tmp1=Divoptions(options);
  eqL=tmp1_5;
  color=tmp1_(length(tmp1)-2);//180704
  forall(eqL,
    tmp=indexof(#,"=");
    tmp1=substring(#,tmp,length(#));
    tmp1=parse(tmp1);
    tmp=Toupper(substring(#,0,1));
    if(tmp=="S",
      size=size*tmp1;
    );
    if(tmp=="W",
      wid=wid*tmp1;
    );
    if(tmp=="T",
      tp=tmp1;
    );
  );
  mid=(pA+pB)/2;
  dir=(pB-pA)/|pB-pA|;
  nor=[-dir_2,dir_1];
//  nor=nor/|nor|;
  if(tp==1,
    tmp1=mid+size*nor;
    tmp2=mid-size*nor;
    Listplot(name,[tmp1,tmp2],["Color="+text(color)]);//180704
  );
  if(tp==2,
    tmp1=mid+wid*dir+size*nor;
    tmp2=mid+wid*dir-size*nor;
    Listplot(name+"r",[tmp1,tmp2],["Color="+text(color)]);//180704
    tmp1=mid-wid*dir+size*nor;
    tmp2=mid-wid*dir-size*nor;
    Listplot(name+"l",[tmp1,tmp2],["Color="+text(color)]);//180704
  );
  if(tp==3,
    tmp1=mid;
    tmp2=mid+size*dir;
    Circledata(name,[tmp1,tmp2],["Color="+text(color)]);//180704
  );
  if(tp==4,
    tmp=mid+size*2/sqrt(3)*nor;
    tmp1=mid+size*dir-size/sqrt(3)*nor;
    tmp2=mid-size*dir-size/sqrt(3)*nor;
    Listplot(name,[tmp,tmp1,tmp2,tmp],["Color="+text(color)]);//180704
  );
);
////%Segmark end////

////%Parabolaplot start////
Parabolaplot(nm,ptlist):=Parabolaplot(nm,ptlist,"[-5,5]",[]);
Parabolaplot(nm,ptlist,Arg):=(
  regional(rng,options);
  if(isstring(Arg),
    rng=Arg;
    options=[];
  ,
    rng="[-5,5]";
    options=Arg;
  );
  Parabolaplot(nm,ptlist,rng,options);
);
Parabolaplot(nm,ptlist,rng,options):=(
//help:Parabolaplot("1",[A,B,C]):
//help:Parabolaplot("1",[A,B,C],"[-5,5]");
  regional(pA,pB,pC,angle,tmp,tmp1,tmp2);
  tmp1=Lcrd(ptlist_1);
  tmp2=Lcrd(ptlist_3);
  pB=Lcrd(ptlist_2);
  tmp=(tmp2-pB)/|tmp2-pB|;
  if(tmp_2>=0,
    angle=arccos(tmp_1);
  ,
    if(tmp_1>=0,
      angle=arcsin(tmp_2);
    ,
      angle=-arccos(tmp_1);
    );
  );
  pA=Rotatepoint(tmp1,-angle,pB);
  pC=Rotatepoint(tmp2,-angle,pB);
  tmp1=1/(2*(pA_2-pB_2));
  tmp2=1/2*(pA_2+pB_2);
  tmp="("+format(tmp1,5)+")*(x-("+format(pA_1,5)+"))^2";
  tmp=tmp+"+("+format(tmp2,5)+")";
  tmp1=parse(rng);
  tmp1=[pA_1-(tmp1_2-tmp1_1)/2,pA_1+(tmp1_2-tmp1_1)/2];
  tmp2="x="+Textformat(tmp1,5);
  Plotdata(nm+"para",tmp,tmp2,append(options,"nodisp"));
  Rotatedata(nm+"para","gr"+nm+"para",angle,append(options,pB));
);
////%Parabolaplot end////

////%Ellipseplot start////
Ellipseplot(nm,ptlist):=Ellipseplot(nm,ptlist,"[0,2*pi]",[]);
Ellipseplot(nm,ptlist,Arg):=(
  regional(rng,options);
  if(isstring(Arg),
    rng=Arg;
    options=[];
  ,
    rng="[0,2*pi]";
    options=Arg;
  );
  Ellipseplot(nm,ptlist,rng,options);
);
Ellipseplot(nm,ptlist,rng,options):=(
//help:Ellipseplot("1",[A,B,3]);
//help:Ellipseplot("1",[A,B,C],"[0,pi]",[options]);
  regional(pA,pB,d,angle,f,a,b,pM,tmp,tmp1,tmp2);
  pA=Lcrd(ptlist_1);
  tmp1=Lcrd(ptlist_2);
  if(ispoint(ptlist_3),
    tmp2=Lcrd(ptlist_3);
    d=|tmp2-pA|+|tmp2-tmp1|;
  ,
    d=ptlist_3;
  );
  tmp=(tmp1-pA)/|tmp1-pA|;
  if(tmp_2>=0,
    angle=arccos(tmp_1);
  ,
    if(tmp_1>=0,
      angle=arcsin(tmp_2);
    ,
      angle=-arccos(tmp_1);
    );
  );
  pB=Rotatepoint(tmp1,-angle,pA);
  f=|pB_1-pA_1|/2;
  a=d/2;
  b=sqrt(d^2/4-f^2);
  pM=(pA+pB)/2;
  tmp="["+format(pM_1,5)+","+format(pM_2,5)+"]";
  tmp=tmp+"+["+format(a,5)+"*cos(t),"+format(b,5)+"*sin(t)]";
  Paramplot(nm+"elp",tmp,"t="+rng,append(options,"nodisp"));
  Rotatedata(nm+"elp","gp"+nm+"elp",angle,append(options,pA));
);
////%Ellipseplot end////

////%Hyperbolaplot start////
Hyperbolaplot(nm,ptlist):=Hyperbolaplot(nm,ptlist,"[-5/2,5/2]",[]);
Hyperbolaplot(nm,ptlist,Arg):=(
  regional(rng,options);
  if(isstring(Arg),
    rng=Arg;
    options=[];
  ,
    rng="[-5/2,5/2]";
    options=Arg;
  );
  Hyperbolaplot(nm,ptlist,rng,options);
);
Hyperbolaplot(nm,ptlist,rng,optionsorg):=(
//help:Hyperbolaplot("1",[A,B,C],["Num=200"]):
//help:Hyperbolaplot("1",[A,B,C],"[-5,5]",["Asy=do"]);
  regional(pA,pB,d,angle,f,a,b,pM,eqL,options,opasy,tmp,tmp1,tmp2);
  tmp=Divoptions(optionsorg);
  eqL=tmp_5;
  options=optionsorg;
  opasy=[];
  forall(eqL,
    if(Toupper(substring(#,0,1))=="A",
      tmp=indexof(#,"=");
      opasy=[substring(#,tmp,length(#))];
      options=remove(options,[#]);
    );
  );
  pA=Lcrd(ptlist_1);
  tmp1=Lcrd(ptlist_2);
  if(ispoint(ptlist_3),
    tmp2=Lcrd(ptlist_3);
    d=abs(|tmp2-pA|-|tmp2-tmp1|);
  ,
    d=ptlist_3;
  );
  tmp=(tmp1-pA)/|tmp1-pA|;
  if(tmp_2>=0,
    angle=arccos(tmp_1);
  ,
    if(tmp_1>=0,
      angle=arcsin(tmp_2);
    ,
      angle=-arccos(tmp_1);
    );
  );
  pB=Rotatepoint(tmp1,-angle,pA);
  f=|pB_1-pA_1|/2;
  a=d/2;
  b=sqrt(f^2-d^2/4);
  pM=(pA+pB)/2;
  tmp="["+format(pM_1,5)+"+"+format(a,5)+"*(exp(t)+exp(-t))/2,";
  tmp=tmp+format(pM_2,5)+"+"+format(b,5)+"*(exp(t)-exp(-t))/2]";
  Paramplot(nm+"hyp1",tmp,"t="+rng,append(options,"nodisp"));
  tmp="["+format(pM_1,5)+"-"+format(a,5)+"*(exp(t)+exp(-t))/2,";
  tmp=tmp+format(pM_2,5)+"+"+format(b,5)+"*(exp(t)-exp(-t))/2]";
  Paramplot(nm+"hyp2",tmp,"t="+rng,append(options,"nodisp"));
  Rotatedata(nm+"hyp1","gp"+nm+"hyp1",angle,append(options,pA));//180408
  Rotatedata(nm+"hyp2","gp"+nm+"hyp2",angle,append(options,pA));//180408
  if(length(opasy)>0,
    Lineplot(nm+"asy1",[pM+[a,b],pM+[-a,-b]],["nodisp"]);
    Lineplot(nm+"asy2",[pM+[-a,b],pM+[a,-b]],["nodisp"]);
    Rotatedata(nm+"asy1","ln"+nm+"asy1",angle,append(opasy,pA));//180408
    Rotatedata(nm+"asy2","ln"+nm+"asy2",angle,append(opasy,pA));//180408
  );
);
////%Hyperbolaplot end////

////%Polygonplot start////
Polygonplot(nm,ptlist,number):=Polygonplot(nm,ptlist,number,[]);
Polygonplot(nm,ptlist,number,optionorg):=(
//help:Polygonplot("1",[A,B],12);
//help:Polygonplot("1",[A,B],12,["Geo=n"]);
  regional(options,eqL,geo,rr,pA,pB,ptL,angle,tmp,tmp1,tmp2);
println([4573,ptlist]);
  geo="N"; //180708from
  options=optionorg;
  tmp=Divoptions(options);
  eqL=tmp_5;
  forall(eqL,
    tmp=Strsplit(#,"=");
    tmp1=Toupper(substring(tmp_1,0,1));
    tmp2=tmp_2;
    if(tmp1=="G",
      geo=Toupper(substring(tmp2,0,1));
      options=remove(options,[#]);
    );
  ); //180708to
  pA=Lcrd(ptlist_1);
  pB=Lcrd(ptlist_2);
  rr=|pB-pA|;
  tmp=(pB-pA)/rr;
  if(tmp_2>=0,
    angle=arccos(tmp_1);
  ,
    if(tmp_1>=0,
      angle=arcsin(tmp_2);
    ,
      angle=-arccos(tmp_1);
    );
  );
  ptL=[];
  forall(0..number,
    tmp=angle+#*2*pi/number;
    tmp1=pA+rr*[cos(tmp),sin(tmp)];
    if(#>0 & #<number,
      if((ispoint(ptlist_2))&(geo=="Y"),  //180708[3lines]
        Putpoint((ptlist_2).name+text(#),tmp1);//16.10.07
      );
     //Pointdata(nm,ptL);
    );
    tmp2=tmp1;
    ptL=append(ptL,tmp1);
  );
  Listplot(nm+"ply",ptL,options);
);
////%Polygonplot end////

////%Putintersect start////
Putintersect(nm,pdata1,pdata2):=(
//help:Putintersect("Q","gr1","gr2");
  regional(pd1,pd2,tmp);
  if(isstring(pdata1),pd1=parse(pdata1),pd1=pdata1);
  if(isstring(pdata2),pd2=parse(pdata2),pd2=pdata2);
  tmp=Intersectcrvs(pd1,pd2);
  if(length(tmp)==1,
    Putpoint(nm,tmp_1);
  ,
    if(length(tmp)==0,
      err("No intersect point");
    ,
      err("Multiple intersect points");
      println(tmp);
      err("Choose point number");
    );
  );
);
Putintersect(nm,pdata1,pdata2,ptno):=(
  regional(pd1,pd2,tmp);
  if(isstring(pdata1),pd1=parse(pdata1),pd1=pdata1);
  if(isstring(pdata2),pd2=parse(pdata2),pd2=pdata2);
  tmp=Intersectcrvs(pd1,pd2);
  if(length(tmp)>0,
    Putpoint(nm,tmp_ptno);
  ,
    err("No intersect point");
  );
);
////%Putintersect end////

////%Setarrow start////
Setarrow():=Setarrow([]);
Setarrow(arglist):=(
//help:Setarrow([-1,-1,-1,1,0.3]);
//help:Setarrow([size(1),angle(18),position(1),cut(0),segstyle("dr,1")]);
  regional(tmp);
  tmp=select(arglist,isreal(#));
  if(length(tmp)==0,
    println([YaSize,YaAngle,YaPosition,YaCut,YasenStyle]);
  );
  if(length(tmp)>=1,
    if((tmp_1>0),YaSize=tmp_1);
  );
  if(length(tmp)>=2,
    if((tmp_2>0)&(tmp_2<90),YaAngle=tmp_2);
   );
  if(length(tmp)>=3,
     if((tmp_3>=0)&(tmp_3<=1),YaPosition=tmp_3);
  );
  if(length(tmp)>=4,
    if((tmp_4>=0)&(tmp_4<1),YaCut=tmp_4);
  );
  tmp=select(arglist,isstring(#));
  if(length(tmp)>0,
    YasenStyle=tmp_1;
  );
  [YaSize,YaAngle,YaPosition,YaCut,YasenStyle];
);
////%Setarrow end////


////%Arrowheaddata start////
Arrowheaddata(point,direction):=Arrowheaddata(point,direction,[]);
Arrowheaddata(point,direction,options):=(
// help:Arrowheaddata(A,B);
// help:Arrowheaddata(options=[size(1),angle(18), "Coord=phy"]);
  regional(list,ookisa,hiraki,Houkou,Str,Flg,Ev,Nv,pA,pB,
       reL,eqL,coord,pP,rF,gG,Flg,Nj,Eps,scx,scy,tmp,tmp1,tmp2);
  Eps=10^(-3);
  coord="P";
  ookisa=0.2*YaSize;
  hiraki=YaAngle;
  iti=1;
  kiri=0;
  Futosa=0;
  Str=YaStyle;
  tmp=Divoptions(options);
  eqL=tmp_5; //181018from
  reL=tmp_6;
  forall(eqL,
     tmp=Strsplit(#,"=");
     tmp1=substring(tmp_1,0,1);
     tmp2=substring(tmp_2,0,1);
     if(Toupper(tmp1)=="C",
       coord=Touppera(tmp2);
     );
  ); //181018to
  forall(1..(length(reL)), //181110from
    tmp=reL_#;
    if(#==1,ookisa=ookisa*tmp);
    if(#==2,
      if(tmp<5, 
        hiraki=hiraki*tmp;
      ,
        hiraki=tmp;
      );
    );
  ); //181110to
  Flg=0;
  hiraki=hiraki*pi/180;
  if(ispoint(direction),Houkou=direction.xy); //181018
  if(isstring(direction),Houkou=parse(direction),Houkou=direction);
  if(Measuredepth(Houkou)==2,Houkou=Houkou_1);
  if(coord=="P",//181018from
    if(ispoint(point),pP=point.xy,pP=point);
  ,
    pP=Pcrd(point);
    if(!islist(Houkou_1),
      Houkou=Pcrd(Houkou);
    ,
      Houkou=apply(Houkou,Pcrd(#)); 
    );
  );//181018to
  if(islist(Houkou_1),
    tmp=Nearestpt(pP,Houkou);
    pP=tmp_1;
    rF=floor(tmp_2);
    if(rF==1,
      if(|Ptend(Houkou)-Ptstart(Houkou)|<Eps,
        rF=Numptcrv(Houkou);
      );
    );
    gG=apply(0..10,pP+ookisa*cos(hiraki)*[cos(2*pi/10*#),sin(2*pi/10*#)]);
    Flg=0; 
    forall(1..rF,Nj,
      if(Flg==0,
        pB=Ptcrv(rF+1-Nj,Houkou);
        tmp1=apply([pP,pB],LLcrd(#));
        tmp2=apply(gG,LLcrd(#));
        tmp=IntersectcrvsPp([pP,pB],gG);
        if(length(tmp)>0,
          Houkou=pP-Pcrd(tmp_1_1);
          Flg=1;
        );
      );
    );
    if(Flg==0,
      println("Arrowhead may be too large (no intersect)");
      Flg=2;
    );
  );
  if(Flg<2,
    Ev=-1/|Houkou|*Houkou;
    Nv=[-Ev_2, Ev_1];
    if(indexof(Str,"c")>0,
      pP=pP-0.5*ookisa*cos(hiraki)*Ev;
    );
    if(indexof(Str,"b")>0,
      pP=pP-ookisa*cos(hiraki)*Ev;
    );
    pA=pP+ookisa*cos(hiraki)*Ev+ookisa*sin(hiraki)*Nv;
    pB=pP+ookisa*cos(hiraki)*Ev-ookisa*sin(hiraki)*Nv;
    list=[pA,pP,pB];
    list;
  );
);
////%Arrowheaddata end////

////%Arrowhead start////
Arrowhead(point,Houkou):=Arrowhead(point,Houkou,[]); //181018from
Arrowhead(Arg1,Arg2,Arg3):=(
  if(isstring(Arg1),
    Arrowhead(Arg1,Arg2,Arg3,[]);
  ,
    Arrowhead(text(ArrowheadNumber),Arg1,Arg2,Arg3);
  );
);
Arrowhead(nm,point,direction,optionsorg):=(//181018from
//help:Arrowhead("1",B,B-A);
//help:Arrowhead(options=[size(1),angle(18),position(1),cut(0),"Coord=P(L)"]);
//help:Arrowhead(the default is -1 for numeric option);
//help:Arrowhead(A,"gr1");
   regional(name,Ltype,Noflg,reL,opstr,opcindy,color,eqL,coord,
         options,cut,pP,Houkou,ptstr,hostr,tmp,tmp1,tmp2,list);
  name="arh"+nm; //181018
  ArrowheadNumber=ArrowheadNumber+1;
  options=optionsorg;
  tmp=Divoptions(options);
  Ltype=tmp_1;
  Noflg=tmp_2;
  reL=tmp_6;
  color=tmp_(length(tmp)-2);
  eqL=tmp_5;
  coord="P";
  forall(eqL,
     tmp=Strsplit(#,"=");
     tmp1=substring(tmp_1,0,1);
     tmp2=substring(tmp_2,0,1);
     if(Toupper(tmp1)=="C",
       coord=Toupper(tmp2);
       options=remove(options,[#]);
     );
  ); //181018to
  tmp1=[YaSize,YaAngle,YaPosition,YaCut]; //181214from
  forall(1..(length(reL)),
    if(reL_#<0, reL_#=tmp1_#);
  );  
  forall((length(reL)+1)..4,
    reL=append(reL,tmp1_#);
  );
  cut=reL_4;
  tmp=reL_(1..3);
  options=select(options,!isreal(#));
  options=concat(options,tmp); //181214to
  if(ispoint(direction),Houkou=direction.xy); //181018
  if(isstring(direction),Houkou=parse(direction),Houkou=direction);
  if(Measuredepth(Houkou)==2,Houkou=Houkou_1);
  if(coord=="P",//181018from
    if(ispoint(point),pP=point.xy,pP=point);
  ,
    pP=Pcrd(point);
    if(!islist(Houkou_1),
      Houkou=Pcrd(Houkou);
    ,
      Houkou=apply(Houkou,Pcrd(#)); 
    );
  );//181018to
  list=Arrowheaddata(pP,Houkou,options);
  if(!Inwindow(LLcrd(pP)),Noflg=2);//181018
  if(Noflg<3,
    tmp1=apply(list,LLcrd(#));
    tmp=name+"="+Textformat(tmp1,5);
    parse(tmp);
  );
  if(Noflg<2,
    if(isstring(Ltype),
      Listplot("-arh"+nm,apply(list,LLcrd(#)),concat(options,["notex","Msg=n"]));
    );
  );
  if(Noflg==0,
    tmp=Divoptions(options);
    opstr=tmp_(length(tmp)-1);
    opstr=opstr+","+Dqq("Cut="+format(cut,5));
    ptstr=Textformat(LLcrd(pP),5);
    if(isstring(direction),  //181019
      hostr=direction;
    ,
      if(!islist(Houkou_1),
        hostr=format(LLcrd(Houkou),5);
      ,
        hostr=format(apply(Houkou,LLcrd(#)),5);
      );
    );
    if((Noflg==0)&(color!=KCOLOR), //180904 //no ketjs on
      Texcom("{");Com2nd("Setcolor("+color+")");//180722
    ); //no ketjs off
    Com2nd("Arrowhead("+ptstr+","+hostr+opstr+")");
    if((Noflg==0)&(color!=KCOLOR), //180904 //no ketjs on
      Texcom("}");//180722
    ); //no ketjs off
  );
);
////%Arrowhead end////

////%Arrowdata start////
Arrowdata(ptlist):=Arrowdata(ptlist,[]); //181110from
Arrowdata(Arg1,Arg2):=(
  regional(name);
  if(isstring(Arg1),
    Arrowdata(Arg1,Arg2,[]);
  ,
    name="";
    forall(Arg1,
      if(ispoint(#),
        name=name+text(#);
      );
    );
    Arrowdata(name,Arg1,Arg2);
  );
);  //181110from
Arrowdata(nm,ptlist,optionsorg):=(
//help:Arrowdata("1",[A,B]);
//help:Arrowdata("1",[pt1,pt2]);
//help:Arrowdata(options=[size(1),angle(18),pos(1),cut(0),"Cutend=0,0","Coord=p/l"]);
//help:Arrowdata(optionsadded=["line"]);
  regional(options,Ltype,Noflg,name,opstr,opcindy,eqL,reL,strL,color,size,coord,
      flg,lineflg,cutend,tmp,tmp1,tmp2,pA,pB,angle,segpos,cut);
  name="ar"+nm;
  options=optionsorg;
  tmp=select(options,isstring(#)); //181214from
  tmp1=select(tmp,contains(["dr","da","do","id"],substring(#,0,2)));
  if(length(tmp1)==0,options=append(options,YasenStyle)); //181214to
  tmp=Divoptions(options);
  Ltype=tmp_1;
  Noflg=tmp_2;
  eqL=tmp_5;
  reL=tmp_6;
  strL=tmp_7;
  color=tmp_(length(tmp)-2);
  opstr=tmp_(length(tmp)-1);
  opcindy=tmp_(length(tmp));
  tmp1=[YaSize,YaAngle,YaPosition,YaCut]; //181214from
  forall(1..(length(reL)),
    if(reL_#<0, reL_#=tmp1_#);
  ); 
  forall((length(reL)+1)..4,
    reL=append(reL,tmp1_#);
  );
  size=reL_1;
  angle=reL_2;
  segpos=reL_3;
  cut=reL_4;
  lineflg=0;
  if(contains(strL,"l")%contains(strL,"L"),
    lineflg=1;
  );//181018from
  options=remove(options,strL);
  cutend=[0,0];//180719
  coord="P";//181018
  forall(eqL,
    tmp=Strsplit(#,"=");
    tmp1=Toupper(substring(tmp_1,0,2));
    tmp2=tmp_2;
    if(tmp1=="CU",//180719from
      tmp2=replace(tmp2,"[","");
      tmp2=replace(tmp2,"]","");
      cutend=tokenize(tmp2,",");
      if(length(cutend)==1,cutend=[cutend_1,cutend_1]);
      options=remove(options,[#]);
    );
    if(tmp1=="CO",//181018from
      coord=Toupper(substring(tmp2,0,1));
      options=remove(options,[#]);
    );
  );
  if(|cutend|>0,//181110from
    tmp=ptlist_2-ptlist_1;
    tmp=tmp/|tmp|;
    ptlist_1=ptlist_1+tmp*cutend_1;
    ptlist_2=ptlist_2-tmp*cutend_2;
  );//181110to
  if(coord=="P",
    pA=ptlist_1; pB=ptlist_2;
    if(ispoint(pA),pA=pA.xy);
    if(ispoint(pB),pB=pB.xy);
  ,
    pA=Pcrd(ptlist_1); pB=Pcrd(ptlist_2);
  );//181018to
  if(Noflg<3,
    println("generate Arrowdata "+name);
    tmp=name+"="+Textformat([pA,pB],5);
    parse(tmp);
    if(lineflg==0, // 16.04.09 from
      tmp=pA-0.2*size/2*(pB-pA)/|pB-pA|;   // 15.06.11
    ,
      tmp=pB;
    );  // 16.04.09 until
    tmp=format([LLcrd(pA),LLcrd(tmp)],6);
  );
  if(Noflg<2,
    if(isstring(Ltype),
      Listplot("-ar"+nm,[LLcrd(pA),LLcrd(pB)],append(options,"Msg=n"));
      Arrowhead(nm,pA+segpos*(pB-pA),pB-pA,options); //181110
    ,
      if(Noflg==1,Ltype=0);
    );
  );
  [Lcrd(pA),Lcrd(pB)];
);
////%Arrowdata end////

////%Anglemark start////
Anglemark(plist):=Anglemark(plist,[]);
Anglemark(Arg1,Arg2):=( // 2015.04.28 from
  regional(nm,plist,options,tmp);
  if(isstring(Arg1),
    nm=Arg1;
    plist=Arg2;
    Anglemark(nm,plist,[]);
  ,
    plist=Arg1;
    options=Arg2;
    tmp=Textformat(plist,5);
    tmp=replace(tmp,",","");
    nm=substring(tmp,1,length(tmp)-1);
    Anglemark(nm,plist,options);
  );
);                    // to
Anglemark(nm,plist,options):=(
//help([A,B,C],["E=\theta",2]);
//help:Anglemark("1",[A,B,C],["E=1.2,\theta",2]);
// help:Anglemark("1",[A,B,2*pi]);
//help:Anglemark(options=[size,"E/L=(sep,)letter"]);
  regional(name,Out,pB,pA,pC,Ctr,ra,sab,sac,ratio,opstr,Bname,Bpos,color,
       Brat,tmp,tmp1,tmp2,Num,opcindy,Ltype,eqL,realL,Rg,Th,Noflg,Msg);
  name="ag"+nm;
  Bpos="md"+name;
  ra=0.5;
  tmp=Divoptions(options);
  Ltype=tmp_1;
  Noflg=tmp_2;
  color=tmp_(length(tmp)-2);
  opcindy=tmp_(length(tmp));
  eqL=tmp_5;
  realL=tmp_6;
  Bname="";
  Brat=1.2; //180530
  Num=20;
  Msg="Y";
  opstr="";
  if(length(realL)>0,
    ra=realL_1*ra;
    opstr=","+text(realL_1);//180530
  );
  forall(eqL,
    tmp=Strsplit(#,"=");
    tmp1=Toupper(substring(tmp_1,0,1));
    if((tmp1=="L")%(tmp1=="E"),
      if(tmp1=="L",Bname="Letter(");
      if(tmp1=="E",Bname="Expr(");
      Bname=Bname+Bpos+","+Dq+"c"+Dq+","+Dq;//16.10.29
      tmp1=indexof(tmp_2,",");
      Bname=Bname+substring(tmp_2,tmp1,length(tmp_2))+Dq+")"; //190219
      if(tmp1>0,
        Brat=parse(substring(tmp_2,0,tmp1-1));
      );
    );
    if(tmp1=="M", //190206from
      Msg=Toupper(substring(tmp_2,0,1));
    ); //190206to
  );
  pB=Lcrd(plist_1); pA=Lcrd(plist_2); sab=pB-pA;
  Ctr=pA;
  if((length(plist_3)>1)%(ispoint(plist_3)), //180506from
    pC=Lcrd(plist_3);
    sac=pC-pA;
    Rg=[arctan2(sab)+0,arctan2(sac)+0];
  ,
    sac=pB-pA;
    Rg=[arctan2(sab)+0,arctan2(sab)+plist_3];   
  ); //180506to
  if(Rg_2<Rg_1,Rg_2=Rg_2+2*pi);
  Out=[];
  if(ra>min(|sab|,|sac|),  // 16.12.29
    println("  segments too short");
  ,
    forall(0..Num,
      Th=Rg_1+#*(Rg_2-Rg_1)/Num;
      Out=append(Out,Ctr+ra*[cos(Th),sin(Th)]);
    );
    Th=(Rg_1+Rg_2)/2; //16.10.31from[moved]
    tmp1=Ctr+Brat*ra*[cos(Th),sin(Th)];
    tmp="Defvar("+Dq+Bpos+"=";
    tmp=tmp+Textformat(tmp1,5)+Dq+");";
    parse(tmp);//16.10.31to[moved]
    if(length(Bname)>0,
      parse(Bname);
    );
    if(Noflg<3,
      if(Msg=="Y", //190206
        println("generate anglemark "+name+" and "+Bpos);
      );
      tmp1=apply(Out,Pcrd(#));
      tmp=name+"="+Textformat(tmp1,5);
      parse(tmp);
      tmp=Textformat(plist,5); //no ketjs on
      tmp1=substring(tmp,1,length(tmp)-1);
      tmp=name+"=Anglemark("+tmp1+opstr+")";
      GLIST=append(GLIST,tmp); //no ketjs off
    );
    if(Noflg<2,
      if(isstring(Ltype),
        if((Noflg==0)&(color!=KCOLOR), //180904 //no ketjs on
          Texcom("{");Com2nd("Setcolor("+color+")");//180722
        ); //no ketjs off
        Ltype=GetLinestyle(text(Noflg)+Ltype,name);
        if((Noflg==0)&(color!=KCOLOR), //180904 //no ketjs on
          Texcom("}");//180722
        ); //no ketjs off
      ,
        if(Noflg==1,Ltype=0);
      );
      GCLIST=append(GCLIST,[name,Ltype,opcindy]);
    );
  );
  Out;
);
////%Anglemark end////

////%Paramark start////
Paramark(plist):=Paramark(plist,[]);
Paramark(Arg1,Arg2):=( // 17.03.27 from
  regional(nm,plist,options,tmp);
  if(isstring(Arg1),
    nm=Arg1;
    plist=Arg2;
    Paramark(nm,plist,[]);
  ,
    plist=Arg1;
    options=Arg2;
    tmp=Textformat(plist,5);
    tmp=replace(tmp,",","");
    nm=substring(tmp,1,length(tmp)-1);
    Paramark(nm,plist,options);
  );
);// to
Paramark(nm,plist,options):=(
//help:Paramark([A,B,C],["E=\theta"]);
//help:Paramark("1",[p1,p2,p3],["E=\theta"]);
  regional(name,Out,pB,pA,pC,ra,sab,sac,ratio,opstr,Bname,Bpos,
         Brat,tmp,tmp1,tmp2,Ltype,Noflg,eqL,realL,opcindy,color);
  name="pm"+nm;
  tmp=Divoptions(options);
  Ltype=tmp_1;
  Noflg=tmp_2;
  color=tmp_(length(tmp)-2);
  opstr=tmp_(length(tmp)-1);
  opcindy=tmp_(length(tmp));
  eqL=tmp_5;
  realL=tmp_6;
  ra=0.5;
  Bname="";
  Brat=1.2;
  if(length(realL)>0,
    tmp=realL_1;
    ra=tmp*ra;
    opstr=opstr+","+text(tmp);
  );
  forall(eqL,
    if(substring(#,0,1)=="L",Bname="Letter(");
    if(substring(#,0,1)=="E",Bname="Expr(");
    Bpos="md"+name;
    Bname=Bname+Bpos+","+Dq+"c"+Dq+","+Dq; //180705
    tmp=substring(#,indexof(#,"="),length(#));
    tmp1=indexof(tmp,",");
    Bname=Bname+substring(tmp,tmp1,length(tmp))+Dq+")";
    if(tmp1>0,
      Brat=parse(substring(tmp,0,tmp1-1));
    );
  );
  pB=Lcrd(plist_1); pA=Lcrd(plist_2); pC=Lcrd(plist_3);
  Ctr=Lcrd(pA);
  Out=[];
  Out=append(Out,pA+ra*(pB-pA)/|pB-pA|);
  Out=append(Out,pA+ra*(pB-pA)/|pB-pA|+ra*(pC-pA)/|pC-pA|);
  Out=append(Out,pA+ra*(pC-pA)/|pC-pA|);
  if(length(Bname)>0,
    tmp1=pA+Brat*ra*(pB-pA)/|pB-pA|+Brat*ra*(pC-pA)/|pC-pA|;
    tmp="Defvar("+Dq+Bpos+"="+Textformat(tmp1,5)+Dq+");";
    parse(tmp);
    parse(Bname);
  );
  if(Noflg<3,
    println("generate paramark "+name);
    tmp1=apply(Out,Pcrd(#));
    tmp=name+"="+Textformat(tmp1,5);
    parse(tmp);
    tmp1=substring(Textformat(plist,5),1,length(Textformat(plist,5))-1); //no ketjs on
    tmp=name+"=Paramark("+tmp1+opstr+")";
    GLIST=append(GLIST,tmp); //no ketjs off
  );
  if(Noflg<2,
    if(isstring(Ltype),
      if((Noflg==0)&(color!=KCOLOR), //180904 //no ketjs on
        Texcom("{");Com2nd("Setcolor("+color+")");//180722
      ); //no ketjs off
      Ltype=GetLinestyle(text(Noflg)+Ltype,name);
      if((Noflg==0)&(color!=KCOLOR), //180904 //no ketjs on
        Texcom("}");//180722
      ); //no ketjs off
    ,
      if(Noflg==1,Ltype=0);
    );
    GCLIST=append(GCLIST,[name,Ltype,opcindy]);
  );
  Out;
);
////%Paramark end////

////%MakeBowdata start////
MakeBowdata(pA,pB,Hgt):=(
  regional(angle,pB2,pH2,pC2,pC,tmp,Th1,Th2,ra,dMA);
  angle=arctan2(pB-pA)+0;
  pB2=Rotatepoint(pB,-angle,pA);
  tmp=Lcrd(pA);
  pH2=[(tmp_1+pB2_1)/2,tmp_2-Hgt];
  dMA=|tmp-pB2|/2;
  ra=(dMA^2+Hgt^2)/(2*Hgt);
  pC2=[pH2_1,pB2_2+(ra-Hgt)];
  pC=Rotatepoint(pC2,angle,pA);
  Th1=arctan2(pA-pC2)+angle;
  Th2=arctan2(pB2-pC2)+angle;
  [pC,ra,Th1,Th2];
);
////%MakeBowdata end////

////%Bowdata start////
Bowdata(plist):=Bowdata(plist,[]);
Bowdata(plist,options):=(
  regional(nm,tmp);
  if(islist(plist), // 16.12.04from
    tmp=Textformat(plist,5);
    tmp=replace(tmp,",","");
    nm=substring(tmp,1,length(tmp)-1);
    Bowdata(nm,plist,options);
  ,
    nm=plist;
    tmp=options;
    Bowdata(nm,tmp,[]);
  ); // 16.12.04until
);
Bowdata(nm,plist,options):=(
//help:Bowdata([C,A],[2,1.2,"Expr=10","da"]);
//help:Bowdata([A,B],["Expr=t0n3,a"]);
//help:Bowdata([A,B],["Exprrot=t0n2r,a"]);
  regional(name,Out,pB,pA,pC,ra,tmp,tmp1,tmp2,Ltype,eqL,realL,
    Bname,Bpos,Th,Cut,Num,Hgt,opstr,opcindy,Ydata,pC,Msg,
    Th1,Th2,Noflg,Bops,Bmov,Tmov,Nmov,rev,color);
  name="bw"+nm;
  tmp=Divoptions(options);
  Ltype=tmp_1;
  Noflg=tmp_2;
  color=tmp_(length(tmp)-2);
  opstr=tmp_(length(tmp)-1);
  opcindy=tmp_(length(tmp));
  eqL=tmp_5;
  realL=tmp_6;
  pA=Lcrd(plist_1); pB=Lcrd(plist_2);
  Hgt=1/2*|pB-pA|*0.2;
  Cut=0;
  Num=24;
  Bname="";
  Msg="Y";  //190206
  Tmov=0;//16.11.01from
  Nmov=0;
  Bmov="";
  rev=0;//16.11.01until
  if(length(realL)>0,
    Hgt=realL_1*Hgt; // 15.04.12
    if(length(realL)>1,Cut=realL_2);
  );
  forall(eqL,
    tmp=Strsplit(#,"=");
    tmp1=Toupper(substring(tmp_1,0,1));
    if(tmp1=="L",
      if(indexof(#,"rot")>0,
        Bname="Letterrot(";
      ,
        Bname="Letter(";
      );
      Bops=tmp_2;
    );
    if(tmp1=="E",
      if(indexof(#,"rot")>0,
        Bname="Exprrot(";
      ,
        Bname="Expr(";
      );
      Bops=tmp_2;
    );
    if(tmp1=="M", //190206from
      Msg=Toupper(substring(tmp_2,0,1));
    ); //190206to
  );
  Ydata=MakeBowdata(pA,pB,Hgt); 
  pC=Ydata_1;
  ra=Ydata_2;
  Th=(Ydata_3+Ydata_4)*0.5;
  BOWMIDDLE=[pC_1+ra*cos(Th),pC_2+ra*sin(Th)];
  Bpos="md"+name; // 16.10.31from[moved]
  tmp="Defvar("+Dq+Bpos+"="+Textformat(BOWMIDDLE,5)+Dq+");";
  parse(tmp);// 16.10.31to[moved]
  if(length(Bname)>0,  //16.11.01from
    tmp=indexof(Bops,",");
    if(tmp>0,
      tmp1=substring(Bops,0,tmp-1);
      if(length(tmp1)>=4 & substring(tmp1,0,1)=="t" & indexof(tmp1,"n")>0,
        Bmov=tmp1;
        Bops=substring(Bops,tmp,length(Bops));
      );
    );
    if(length(Bmov)>0,
      tmp=indexof(Bmov,"t");
      if(tmp>0,
        tmp1=indexof(Bmov,"n");
        Tmov=parse(substring(Bmov,tmp,tmp1-1));
        tmp=indexof(Bmov,"r");
        if(tmp>0,
          Nmov=parse(substring(Bmov,tmp1,tmp-1));
          rev=1;
        ,
          Nmov=parse(substring(Bmov,tmp1,length(Bmov)));
        );
      );
    );
    Bname=Bname+Bpos;//16.11.01
    if(abs(Tmov)+abs(Nmov)>0,
      tmp=Pcrd(pA)-Pcrd(pB);
      tmp1=1/Norm(tmp)*tmp;
      tmp2=[-tmp1_2,tmp1_1];
      tmp=MARKLEN*(Tmov*tmp1+Nmov*tmp2);
      tmp=LLcrd(tmp);
      Bname=Bname+"+"+text(tmp);
    );
    Bname=Bname+",";
    if(indexof(Bname,"rot")>0,
      if(rev==1,tmp=pB-pA,tmp=pA-pB);
      Bname=Bname+Textformat(tmp,5)+",";
    ,
      Bname=Bname+Dq+"c"+Dq+",";
    );
    Bname=Bname+Dq+Bops+Dq+")";
    parse(Bname);
  );//16.11.01until
  if(Cut==0,
    Th1=Ydata_3;
    Th2=Ydata_4;
    Out=[];
    forall(0..Num,
      tmp=Th1+#*(Th2-Th1)/Num;
      Out=append(Out,pC+ra*[cos(tmp),sin(tmp)]);
    );
  ,
    Th1=Ydata_3;
    Th2=Th-Cut/(2*ra);
    tmp1=[];
    forall(0..Num/2,
      tmp=Th1+#*(Th2-Th1)/(Num/2);
      tmp1=append(tmp1,pC+ra*[cos(tmp),sin(tmp)]);
    );
    Th1=Th+Cut/(2*ra);
    Th2=Ydata_4;
    tmp2=[];
    forall(0..Num/2,
      tmp=Th1+#*(Th2-Th1)/(Num/2);
      tmp2=append(tmp2,pC+ra*[cos(tmp),sin(tmp)]);
    );
    Out=[tmp1,tmp2];
  );
  if(Noflg<3,
    if(Msg=="Y", //190206
      println("generate bowdata "+name+" and "+Bpos);//16.10.31
    );
    if(Measuredepth(Out)==1,Out=[Out]);
    tmp1=[];
    forall(Out,tmp2,
      tmp=apply(tmp2,Pcrd(#));
      tmp1=append(tmp1,tmp);
    );
    tmp=name+"="+Textformat(tmp1,5);
    parse(tmp);
    tmp1=substring(Textformat(plist,5),1,length(Textformat(plist,5))-1); //no ketjs on
    tmp=name+"=Bowdata("+tmp1+opstr+")";
    GLIST=append(GLIST,tmp); //no ketjs off
  );
  if(Noflg<2,
    if(isstring(Ltype),
      if((Noflg==0)&(color!=KCOLOR), //180904 //no ketjs on
        Texcom("{");Com2nd("Setcolor("+color+")");//180722
      ); //no ketjs off
      Ltype=GetLinestyle(text(Noflg)+Ltype,name);
      if((Noflg==0)&(color!=KCOLOR), //180904 //no ketjs on
        Texcom("}");//180722 
      ); //no ketjs off
    ,
      if(Noflg==1,Ltype=0);
    );
    GCLIST=append(GCLIST,[name,Ltype,opcindy]);
  );
);
////%Bowdata end////

////%Bowname start////
Bowname(str):=Bowname("c",str);
Bowname(dir,str):=(
  Expr([BOWMIDDLE,dir,str]);
);
////%Bowname end////

////%Bownamerot start////
Bownamerot(bwdata,str):=Bownamerot(bwdata,0,0,str,1);
Bownamerot(bwdata,str,updown):=Bownamerot(bwdata,0,0,str,updown);
Bownamerot(bwdata,tmov,nmov,str):=Bownamerot(bwdata,tmov,nmov,str,1);
Bownamerot(bwdata,tmov,nmov,str,updown):=(
  regional(bdata,tmp);
  tmp=Measuredepth(bwdata);
  if(tmp==1,bdata=[bwdata],bdata=bwdata);
  if(length(bdata)>1,
    tmp=Ptend(bdata_2)-Ptstart(bdata_1);
  ,
    tmp=Ptend(bdata_1)-Ptstart(bdata_1);
  );
  if(updown<0,tmp=-tmp);
  Exprrot(BOWMIDDLE,tmp,tmov,nmov,str);
);
////%Bownamerot end////

////%Deqdata start////
Deqdata(deq,rng,initt,initf,Num):=( //17.10.04
//  Deqdata("[x1,...xn]`=[f1,...fn]","t=[0,20]",0,[...],50);
  regional(Eps,Inf,tname,Xname,func,t1,t2,dt,tt,X0,flg,
                 kl1,kl2,kl3,kl4,pdL,tmp,tmp1,tmp2);
  Eps=10^(-3);
  Inf=10^3;
  tmp=tokenize(deq,"=");
  tmp1=replace(tmp_1,"`","");
  tmp1=substring(tmp1,1,length(tmp1)-1);
  Xname=tokenize(tmp1,",");
  func=tmp_2;
  forall(1..(length(Xname)),
    func=replace(func,Xname_#,"X_"+text(#));
  );
  tmp=tokenize(rng,"=");
  tname=tmp_1;
  tmp=parse(tmp_2);
  t1=tmp_1;
  t2=tmp_2;
  tmp="funP("+tname+",X):="+func+";";
  parse(tmp);
  tmp="funN("+tname+",X):=-"+func+";";
  parse(tmp);
  dt=(t2-t1)/Num;
  tt=initt;
  X0=Lcrd(initf);
  pdL=[flatten([tt,X0])];
  flg=0;
  forall(1..floor((t2-initt)/dt),
    if(flg==0,
      kl1=dt*funP(tt,X0);
      kl2=dt*funP(tt+dt/2,X0+kl1/2);
      kl3=dt*funP(tt+dt/2,X0+kl2/2);
      kl4=dt*funP(tt+dt,X0+kl3);
      X0=X0+(kl1+2*kl2+2*kl3+kl4)/6;
      tt=initt+#*dt;
      tmp=flatten([tt,X0]);
      pdL=append(pdL,tmp);
      if(|tmp|>Inf,flg=1);
    );
  );
  tt=initt;
  X0=Lcrd(initf);
  flg=0;
  forall(1..floor((initt-t1)/dt),
    if(flg==0,
      kl1=dt*funN(tt,X0);
      kl2=dt*funN(tt+dt/2,X0+kl1/2);
      kl3=dt*funN(tt+dt/2,X0+kl2/2);
      kl4=dt*funN(tt+dt,X0+kl3);
      X0=X0+(kl1+2*kl2+2*kl3+kl4)/6;
      tt=initt-#*dt;
      tmp=flatten([tt,X0]);
      pdL=prepend(tmp,pdL);
      if(|tmp1|>Inf,flg=1);
    );
  );
  pdL;
);
////%Deqdata end////

////%Deqplot start////
Deqplot(nm,deq,rng,initf):=Deqplot(nm,deq,rng,Lcrd(initf)_1,initf,[]);
Deqplot(nm,deq,rng,Arg1,Arg2):=(
  regional(initt,initf,options);
  if(isreal(Arg1) & !islist(Arg1),
    initt=Arg1;
    initf=Arg2;
    options=[];
  ,
    initf=Lcrd(Arg1);
    initt=initf_1;
    options=Arg2;
  );
  Deqplot(nm,deq,rng,initt,initf,options);
);
Deqplot(nm,deqorg,rngorg,initt,initf,options):=( //17.10.06
//help:Deqplot("2","y'=y*(1-y)","x",0, 0.5,["Num=100"]);
//help:Deqplot("1","y''=-y","x",0, [1,0]);
//help:Deqplot("3","[x,y]'=[x*(1-y),0.3*y*(x-1)]","t=[0,20]",0,[1,0.5]);
  regional(deq,rng,Ltype,Noflg,eqL,opcindy,Num,name,nn,pdL,phase,
                  sel,tmp,tmp1,tmp2,tmp3,color);
  name="de"+nm;
  tmp=Divoptions(options);
  Ltype=tmp_1;
  Noflg=tmp_2;
  eqL=tmp_5;
  color=tmp_(length(tmp)-2);
  opcindy=tmp_(length(tmp));
  Num=50;
  forall(eqL,
    tmp=indexof(#,"=");
    tmp2=substring(#,0,1);
    tmp2=Toupper(tmp2);
    tmp1=substring(#,tmp,length(#));
    if(Toupper(substring(#,0,1))=="N",
      Num=parse(tmp1);
    );
  );
  rng=rngorg;
  if(indexof(rng,"=")==0,
    rng=rng+"="+Textformat([XMIN,XMAX],6);
  );
  deq=replace(deqorg,"‘","`"); //190206
  deq=replace(deq,"'","`"); //180527
  tmp3=indexof(deq,"=");
  tmp1=substring(deq,0,tmp3-1);
  tmp2=substring(deq,tmp3,length(deq));
  if(indexof(tmp1,"[")==0,
    phase=0;
    sel=[1,2];
  ,
    phase=1;
    sel=[2,3];
  );
  nn=length(Indexall(tmp1,"`"));
  if(nn==0, //190211from
    println("    Lhs of equation has no single/back quotation "+tmp1);
  );
  if(nn>0,
    tmp=Indexall(tmp1,"`");
    if(tmp_(length(tmp))!=tmp3-1,
      nn=0;
    ,
      forall(reverse(2..(length(tmp))),
        if((nn>0)&(!contains(tmp,tmp_#-1)),
          nn=0;
        );
      );
    ); 
    if(nn==0,
      println("    Lhs of equation is not correct");
    );
  ); //190211to
  if(nn==1,
    if(indexof(tmp1,"[")==0,
      tmp1="["+replace(tmp1,"`","]`");
      deq=tmp1+"="+tmp2;
    );
  );
  if(nn>1,
    tmp=indexof(tmp1,"`");
    tmp1=substring(tmp1,0,tmp-1);
    deq="[";
    forall(1..nn,
      deq=deq+tmp1+"N"+text(#)+",";
    );
    deq=substring(deq,0,length(deq)-1)+"]`=[";
    forall(1..(nn-1),
      deq=deq+tmp1+"N"+text(#+1)+",";
    );
    forall(reverse(1..(nn)),jj,
      tmp=tmp1;
      forall(1..jj,
        tmp=tmp+"`";
        tmp2=replace(tmp2,tmp,tmp1+"N"+text(#+1));
      );
    );
    tmp2=tmp2+"]";
    forall(1..(length(tmp2)-1),
      tmp=substring(tmp2,#-1,#);
      if(tmp!=tmp1,
        deq=deq+tmp;
      ,
        tmp=substring(tmp2,#,#+1);
        if(tmp=="N",
          deq=deq+tmp1;
        ,
          deq=deq+tmp1+"N1"
        );
      );
    );
    deq=deq+"]";
  );
  if((nn>0)&(Noflg<3), //190211
    pdL=Deqdata(deq,rng,initt,initf,Num);
    if(phase==1,
      pdL=apply(pdL,#_(2..3));
    );
    tmp1=apply(pdL,Pcrd(#));
    tmp=name+"="+Textformat(tmp1,5);
    parse(tmp);
  );
  if((nn>0)&(Noflg<1), //190211 //no ketjs on
    tmp=Assign(deq);
    tmp=replace(deq,"'","`");
    tmp=name+"=Deqplot('"+tmp+"','"+rng+"',";
    tmp=tmp+format(initt,6)+","+Textformat(initf,6);
    tmp=tmp+","+text(sel)+",'Num="+text(Num)+"')";
    tmp=RSform(tmp);
    GLIST=append(GLIST,tmp);
  ); //no ketjs off
  if((nn>0)&(Noflg<2), //190211
    if(isstring(Ltype),
      if((Noflg==0)&(color!=KCOLOR), //180904 //no ketjs on
        Texcom("{");Com2nd("Setcolor("+color+")");//180722
      ); //no ketjs off
      Ltype=GetLinestyle(text(Noflg)+Ltype,name);
      if((Noflg==0)&(color!=KCOLOR), //180904 //no ketjs on
        Texcom("}");//180722
      ); //no ketjs off
    ,
      if(Noflg==1,Ltype=0);
    );
    GCLIST=append(GCLIST,[name,Ltype,opcindy]);
  );
);
////%Deqplot end////

////////// old enclosing ///////////////

Enclosing(nm,plist):=EnclosingS(nm,plist);
Enclosing(nm,plist,options):=EnclosingS(nm,plist,options);
EnclosingS(nm,plist):=EnclosingS(nm,plist,[]);
EnclosingS(nm,plist,options):=(
// help:Enclosing("1",["sc2","crAB","sc2","Invert(sc1)"],[pt,"dr"]);
  regional(name,AnsL,Start,Eps,EEps,S,Flg,Fdata,Gdata,KL,pt,qt,color
      t1,t2,t3,ii,nn,tmp,tmp1,tmp2,Ltype,Noflg,realL,eqL,opstr,opcindy);
  name="en"+nm;
  tmp=Divoptions(options);
  Ltype=tmp_1;
  Noflg=tmp_2;
  eqL=tmp_5;
  realL=tmp_6;
  color=tmp_(length(tmp)-2);
  opstr=tmp_(length(tmp)-1);
  opcindy=tmp_(length(tmp));
  Eps=10^(-5); // 16.12.05
  EEps=0.05;
  Start=[];
  Flg=0;
  forall(realL,
    if(islist(#) % ispoint(#),
      Start=Lcrd(#); // 15.09.12
    ,
      Flg=Flg+1;
      if(Flg==1,Eps=#);
      if(Flg==2,EEps=#);
    );
  );
//  tmp1=concat([Eps,EEps],eqL); // 15.04.06
  Fdata=plist_1;
  Gdata=plist_(length(plist));
  KL=IntersectcrvsPp(Fdata,Gdata);
  if(length(KL)==1,
    pt=KL_1_1;
    t1=KL_1_2;
  );
  if(length(KL)==0,
    if(Numptcrv(Fdata)>Numptcrv(Gdata),
      tmp=Nearestpt(Fdata,Gdata);
      pt=tmp_1;
      t1=tmp_2;
    ,
      tmp=Nearestpt(Gdata,Fdata);
      pt=tmp_3;
      t1=tmp_4;
    );
  );
  if(length(KL)>1,
    if(Start==[],
      err("No Start Point");
    ,
      pt=KL_1_1;
      t1=KL_1_2;
      tmp=Norm(pt-Start);
      forall(2..(length(KL)),ii, // 15.04.20
        tmp1=KL_ii_1;
        tmp2=Norm(tmp1-Start); // 15.04.20
        if(tmp2<tmp,
          pt=tmp1;
          t1=KL_ii_2;
          tmp=tmp2;
        );
      );
    );
  );
//  pt=Pcrd(pt);  // 15.09.12
  Start=pt;
  AnsL=[];
  forall(1..(length(plist)),nn,
    Fdata=plist_nn;
    if(nn>1, pt=qt); 
    if(nn==length(plist),
      qt=Start;
    ,
      Flg=0;
      Gdata=plist_(nn+1);
//      tmp1=concat([Eps,EEps],eqL); // 15.04.06
      KL=IntersectcrvsPp(Gdata,Fdata);
      if(length(KL)==1,
        tmp=KL_1;
        qt=KL_1_1;
        t3=KL_1_2;
        Flg=10;
      );
      if(length(KL)==0,Flg=1);
      if(length(KL)>1, 
        tmp1=KL_1_1;
        tmp2=KL_2_1;
        tmp=|tmp1-tmp2|;
        if(tmp<Eps*10, Flg=1); 
      );
      if(Flg==1,
        if(Numptcrv(Fdata)>Numptcrv(Gdata),
          tmp=Nearestpt(Fdata,Gdata);
          qt=tmp_1;
          t3=tmp_4;
          Flg=10;
        ,
          tmp=Nearestpt(Gdata,Fdata);
          qt=tmp_3;
          t3=tmp_2;
          Flg=10;
        );
      );
      if(Flg<10,
        t2=10^6; //%inf;
        forall(1..(length(KL)),ii,
          tmp1=KL_ii_1;
          tmp=KL_ii_3;
          tmp2=Paramoncurve(tmp1,tmp,Fdata);
          tmp3=KL_ii_2;
          if(tmp2>t1+Eps & tmp2<t2+Eps,
            qt=tmp1;
            t2=tmp2;
            t3=tmp3;
          );
        );
      );
    );
    tmp=Partcrv("",pt,qt,Fdata,["nodata"]);
    t1=t3;
    if(nn==1,
      AnsL=tmp;
    ,
      AnsL=concat(AnsL,tmp_(2..(length(tmp))));
    );
  );
  AnsL=apply(AnsL,Pcrd(#));  // 15.09.12
  AnsL_(length(AnsL))=AnsL_1;//16.10.20
  if(Noflg<3,
    println("generate Enclosing "+name);
    tmp=name+"="+Textformat(AnsL,5);
    parse(tmp);
    tmp=name+"=Enclosing(";//16.11.07from //no ketjs on
    tmp1="list"+PaO();
    forall(plist,
      tmp1=tmp1+#+",";
    );
    tmp=tmp+substring(tmp1,0,length(tmp1)-1)+")"+opstr+")";
    GLIST=append(GLIST,tmp);//16.11.07to //no ketjs off
  );
  if(Noflg<2,
    if(isstring(Ltype),
      if((Noflg==0)&(color!=KCOLOR), //180904 //no ketjs on
        Texcom("{");Com2nd("Setcolor("+color+")");//180722
      ); //no ketjs off
      Ltype=GetLinestyle(text(Noflg)+Ltype,name);
      if((Noflg==0)&(color!=KCOLOR), //180904 //no ketjs on
        Texcom("}");//180722
      ); //no ketjs off
    ,
      if(Noflg==1,Ltype=0);
    );
    GCLIST=append(GCLIST,[name,Ltype,opcindy]);
  );
  tmp=apply(AnsL,LLcrd(#));//16.10.20
  tmp;
);

/////////// new enclosing ///////////

////%Enclosing start////
Enclosing(nm,plist):=Enclosing2(nm,plist,[]);//180706[2lines]
Enclosing(nm,plistorg,options):=Enclosing2(nm,plistorg,options);
Enclosing2(nm,plist):=Enclosing2(nm,plist,[]);
Enclosing2(nm,plistorg,options):=(
//help:Enclosing("1",["sg2","gr1","Invert(sg2)"]);
//help:Enclosing(options=[startpoint,epspara(1)]);
  regional(name,plist,AnsL,Start,Eps,Eps1,Eps2,flg,Fdata,Gdata,KL,
      t1,t2,tst,ss,ii,nn,nxtno,Ltype,Noflg,realL,eqL,opstr,opcindy,
      tmp,tmp1,tmp2,color,epspara,p1,p2);
  name="en"+nm;
  plist=plistorg;
  tmp=Divoptions(options);
  Ltype=tmp_1;
  Noflg=tmp_2;
  eqL=tmp_5;
  realL=tmp_6;
  color=tmp_(length(tmp)-2);
  opstr=tmp_(length(tmp)-1);
  opcindy=tmp_(length(tmp));
  Eps=10^(-5); // 16.12.05
  epspara=1; //180707
  Eps1=0.01;
  Eps2=0.1;
  Start=[];
  flg=0;
  forall(realL,
    if(isList(#) % ispoint(#),
      Start=Lcrd(#); // 18.02.02
    ,
      if(flg==0,epspara=#);//180707
      if(flg==1,Eps1=#);
      if(flg==2,Eps2=#);
      flg=flg+1;
    );
  );
  flg=0;
  AnsL=[];
  if(length(plist)==1,
    Fdata=parse(plist_1);
    tmp1=Fdata_1;
    tmp2=Fdata_(length(Fdata));
    if(|tmp1-tmp2|<Eps,
      AnsL=Fdata;
    ,
      AnsL=append(Fdata,tmp1);
    );
    flg=1;
  );
  if(flg==0,
    Fdata=plist_1;
    Gdata=plist_(length(plist));
    KL=IntersectcurvesPp(Fdata,Gdata);
    if(length(KL)==0,
      tmp=parse(Gdata);
      tmp1=LLcrd(Op(length(tmp),tmp)); //18.02.02from
      tmp=parse(Fdata);
      tmp2=LLcrd(Op(1,tmp));
      tmp=Listplot(name,[tmp1,tmp2],["nodisp"]);
      plist=append(plist,"sg"+name);
      Start=tmp2;
      tst=1; //18.02.02to
      p1=Start;
    ,
      if(length(KL)==1,
        tst=KL_1_2;
        Start=Pointoncurve(tst,Fdata);
      );
      if(length(KL)>1,
        KL=sort(KL,[#_2]);
        if(Start==[],
          tst=KL_1_2;
          Start=Pointoncurve(tst,Fdata);
        ,
          tmp=apply(KL,|#_1-Start|);
          tmp=min(tmp);
          tmp1=select(KL,|#_1-Start|<tmp+Eps1);//180718
          tst=tmp1_1_2;
          Start=Pointoncurve(tst,Fdata);
        );
      );
    );
  );
  if(flg==0,
    t1=tst;
    p1=Pointoncurve(t1,Fdata); //180713
    println("Start point of enclosing is "+text(Start));
    forall(1..(length(plist)),nn,
      Fdata=plist_nn;
      if(nn==length(plist),nxtno=1,nxtno=nn+1);
      Gdata=plist_nxtno;
      KL=IntersectcurvesPp(Fdata,Gdata);
      if(length(KL)==0,
        tmp1=parse(Fdata); //18.02.02from
        tmp2=parse(Gdata); 
        tmp2=Prepend(Op(length(tmp1),tmp),tmp2);
        Gdata=replace(Gdata,"(","");
        Gdata=replace(Gdata,")","");
        tmp=Gdata+"="+Textformat(tmp2,6);
        parse(tmp);
        plist_nxtno=Gdata;
        t2=Length(tmp1);
        p2=Pointoncurve(t2,Fdata); //180713
        ss=1; //18.02.02to
      ,
        KL=sort(KL,[#_2]);//180706
        tmp=parse(Fdata);
        tmp1=t1+epspara/50*length(tmp);
//        KL=select(KL,#_2>t1+epspara/50*length(tmp)); //180707
        KL=select(KL,(#_2>tmp1)%((#_2>t1)&(|#_1-p1|>Eps1))); //180713,16
        t2=KL_1_2;
        ss=KL_1_3;
        if(abs(t2-t1)<Eps,//180707
          if(length(KL)>1,
            t2=KL_2_2;
            ss=KL_2_3;
          ,
            println(text(nn)+" and "+text(nxtno)+" not intersect");
            flg=1;
          );
        );
      );
      if(flg==0,
        tmp=Partcrv("",t1,t2,Fdata,["nodata"]);
        if(nn==1,
          AnsL=tmp;
        ,
          AnsL=concat(AnsL,tmp_(2..(length(tmp))));
        );
      );
      t1=ss;//180706
      p1=Pointoncurve(t1,Gdata); //180713
    );
  );
  if(flg==0,
    AnsL=apply(AnsL,Pcrd(#));
  );
  if(Noflg<3,
    println("generate Enclosing "+name);
    tmp=name+"="+Textformat(AnsL,5);
    parse(tmp);
    tmp=name+"=Enclosing2(";//16.11.07from
    tmp1="list"+PaO();
    forall(plistorg, //18.02.02
      tmp1=tmp1+#+",";
    );
    tmp=tmp+substring(tmp1,0,length(tmp1)-1)+")";//18.0706from //no ketjs on
    if(length(Start)>0,tmp=tmp+","+Textformat(Start,6));
    tmp=tmp+","+text(epspara)+")";//18.0706to,180707
    GLIST=append(GLIST,tmp);//16.11.07to //no ketjs off
  );
  if(Noflg<2,
    if(isstring(Ltype),
      if((Noflg==0)&(color!=KCOLOR), //180904 //no ketjs on
        Texcom("{");Com2nd("Setcolor("+color+")");//180722
      ); //no ketjs off
      Ltype=GetLinestyle(text(Noflg)+Ltype,name);
      if((Noflg==0)&(color!=KCOLOR), //180904 //no ketjs on
        Texcom("}");//180722
      ); //no ketjs off
    ,
      if(Noflg==1,Ltype=0);
    );
    GCLIST=append(GCLIST,[name,Ltype,opcindy]);
  );
  tmp=apply(AnsL,LLcrd(#));//16.10.20
  tmp;
);
////%Enclosing end////

/////////// end of new enclosing ///////////

/////////// new Hatchdata(cindy) ///////////

////%Makehatch start////
Makehatch(iolistorg,pt,vec,bdylist):=(
  regional(Eps,iolist,sg,bdy,out,nb,tenL,ns,ne,ioL,
         ii,jj,kk,nvec,nbdy,sgn1,sgn2,flg,rmL,p0,p1,p2,pL,
         Scalebkup,tmp,tmp1,tmp2);
  Eps=10^(-5);
  nvec=[-vec_2,vec_1];
  nvec=nvec/|nvec|;
  if(!islist(iolistorg),iolist=[iolistorg],iolist=iolistorg);
  forall(1..(length(iolist)),
    tmp=replace(iolist_#,"i","1,");
    tmp=replace(tmp,"o","0,");
    tmp="["+substring(tmp,0,length(tmp)-1)+"]";
    iolist_#=parse(tmp);
  );
  Scalebkup=[SCALEX,SCALEY];//181020[2lines]
  SCALEX=1;
  SCALEY=1;
  sg=Lineplot("",[pt,pt+vec],["nodata"]);
  nb=length(bdylist);
  if(nb>0,
    tenL=[];
    forall(1..nb,ii,
      rmL=[];
      bdy=bdylist_ii;
      nbdy=length(bdy)-1;
      pL=[];
      forall(1..nbdy,jj,
        p1=bdy_jj;
        p2=bdy_(mod(jj+1-1,nbdy)+1);
        tmp=Intersectseg(sg,[p1,p2],Eps);
        if(abs(tmp_1)<Eps, //18.02.01
          p0=tmp_2; t=tmp_3; s=tmp_4;
          flg=0; //181003from
          forall(pL,
            if(flg==0,
              if(Norm(#_1-p0)<Eps,
                flg=1;
              );
            );
          );
          if(flg==0,
            pL=append(pL,[p0,t,s,ii]);
          ); //181003to
        );
      );
      if(length(pL)>0,
        pL=sort(pL,[#_2]);
        pL=apply(1..(length(pL)),append(pL_#,mod(#,2)));
        tenL=concat(tenL,pL);
      );
    );
    tenL=sort(tenL,[#_2]);
    if(length(tenL)>0, //180619from
      tmp1=tenL; tenL=[tmp1_1];
      forall(2..(length(tmp1)),ii, //180717from
        tmp=tmp1_ii;
        flg=0;
        forall(tenL,
          if((Norm(tmp_1-#_1)<Eps1)&(tmp_4==#_4),
            flg=1;
          );
        );
        if(flg==0,
          tenL=append(tenL,tmp);
        );
      );//180717to
    ); //180619to
    ioL=apply(1..nb,0);
    ns=1;
    ne=length(tenL);
    if(ne>0,tmp=tenL_1_1,tmp=sg_2);
    if(|sg_1-tmp|>Eps,
      tmp=[sg_1,-1,1,ioL];
      tenL=prepend(tmp,tenL);
      ns=ns+1;
      ne=ne+1;
    );
    if(|sg_2-tenL_(length(tenL))_1|>Eps,
      tmp=[sg_2,-1,2,ioL];
      tenL=append(tenL,tmp);
    );
    forall(ns..(ne-1),ii, //180619  ne=>ne-1
      tmp=tenL_ii;
      tmp1=tmp_4;
      tmp2=tmp_5;
      ioL_tmp1=tmp2;
      tmp=[tmp_1,tmp_2,tmp_4,ioL];
      tenL_ii=tmp;
    );
    out=[];
    forall(1..(length(tenL)-1),ii,
      tmp1=tenL_ii;
      if(contains(iolist,tmp1_4),
        tmp2=tenL_(ii+1);
        tmp=Listplot("",[tmp1_1,tmp2_1],["nodata"]);
        out=append(out,tmp);  
      );
    );
  );
  SCALEX=Scalebkup_1; //181020
  SCALEY=Scalebkup_2;
  out;
);
////%Makehatch end////

////%Anyselected start////
Anyselected(ptL):=(
  regional(tmp,out);
  out=false;
  forall(ptL,
    if(isstring(#),tmp=parse(#),tmp=#);
    out=(out)%(isselected(tmp));
  );
  out;
);
////%Anyselected end////

////%Hatchdata start////
Hatchdata(nm,iostr,bdylist):=Hatchdatacindy(nm,iostr,bdylist,[]);//180619
Hatchdata(nm,iostr,bdylist,optionsorg):=( //181003from
  regional(options,tmp,tmp1,tmp2,eqL,strL,chkL,outflg);
  options=optionsorg;
  tmp=Divoptions(options);
  eqL=tmp_5;
  strL=tmp_7;
  outflg=0;
  forall(eqL,
    tmp=Strsplit(#,"=");
    tmp1=Toupper(tmp_1);
    if(substring(tmp1,0,1)=="O",
      tmp2=tmp_2;
      if(tmp2!="n",
        outflg=1;
        option=remove(options,[#]);
        if((tmp2=="m")%(tmp2=="r"),
          options=append(options,tmp2);;
        );
      );
    );
  );
  if(outflg==0,
    options=remove(options,strL);
    Hatchdatacindy(nm,iostr,bdylist,options);
  ,
    HatchdataR(nm,iostr,bdylist,options); 
  );
); //181003to
Hatchdatacindy(nm,iostr,bdylist):=Hatchdata(nm,iostr,bdylist,[]);
Hatchdatacindy(nm,iostr,bdylistorg,optionsorg):=(
 //help:Hatchdata("1",["ii"],[["ln1","Invert(gr1)"],["gr2","n"]]);
//help:Hatchdata(options=["Not=pointlist","File=y(/m/n)","Max=50","Check=",angle,width]);
  regional(name,bdylist,bdynameL,bname,Ltype,Noflg,opstr,opcindy,reL,
    options,eqL,maxnum,startP,angle,interval,vec,nvec,ctr,pt,kk,delta,sha,AnsL,
    color,tmp,tmp1,tmp2,tmp3,namep,x1,y1,x2,y2,p1,p2, //180717
    fname,fileflg,mkflg,vaL,pL,nL,nn,str,is,ie); //181102
  name="ha"+nm;
  fname=Fhead+name+".txt";
  bdylist=[]; 
  bdynameL=[];
  forall(1..(length(bdylistorg)),kk,
    tmp1=bdylistorg_kk;
    if(length(tmp1)==1,
      bname=tmp1_1;
    ,
      tmp=tmp1_(length(tmp1));
      if(contains(["n","s","e","w"],tmp),
        namep=tmp1_1;//180717from
        tmp2=parse(namep);
        if(substring(namep,0,2)=="ln", //180717from
          if(contains(["n","s"],tmp),
             x1=tmp2_1_1; y1=tmp2_1_2; x2=tmp2_2_1; y2=tmp2_2_2;
             p1=[NE.x,(y2-y1)/(x2-x1)*(NE.x-x1)+y1];
             p2=[SW.x,(y2-y1)/(x2-x1)*(SW.x-x1)+y1];
             Listplot(name+text(kk),[p1,p2],["nodisp"]);
             namep="sg"+name+text(kk);
             tmp2=parse(namep);
          );
          if(contains(["e","w"],tmp),
             x1=tmp2_1_1; y1=tmp2_1_2; x2=tmp2_2_1; y2=tmp2_2_2;
             p1=[(x2-x1)/(y2-y1)*(NE.y-y1)+x1,NE.y];
             p2=[(x2-x1)/(y2-y1)*(SW.y-y1)+x1,SW.y];
             Listplot(name+text(kk),[p1,p2],["nodisp"]);
             namep="sg"+name+text(kk);
             tmp2=parse(namep);
          );
        );//180717to
        if(tmp=="s",
          Listplot(name,[LLcrd(tmp2_1),[tmp2_1_1,2*YMIN-YMAX], //180717[2lines]
                 [tmp2_(length(tmp2))_1,2*YMIN-YMAX],LLcrd(tmp2_(length(tmp2)))],
                 ["nodisp"]);
          Joincrvs(text(kk)+name,[namep,"sg"+name],["nodisp"]);//180717
          bname="join"+text(kk)+name;
        );
        if(tmp=="n",
          Listplot(name,[LLcrd(tmp2_1),[tmp2_1_1,2*YMAX-YMIN], //180717[2lines]
              [tmp2_(length(tmp2))_1,2*YMAX-YMIN],LLcrd(tmp2_(length(tmp2)))],
              ["nodisp"]);
          Joincrvs(text(kk)+name,[namep,"sg"+name],["nodisp"]);
          bname="join"+text(kk)+name;
        );
        if(tmp=="e",
          Listplot(name,apply([tmp2_1,[XMAX,tmp2_1_2],
                      [XMAX,tmp2_(length(tmp2))_2],tmp2_(length(tmp2))],LLcrd(#)),["nodisp"]);
          Joincrvs(text(kk)+name,[namep,"sg"+name],["nodisp"]);//180717
          bname="join"+text(kk)+name;
        );
        if(tmp=="w",
          Listplot(name,apply( [tmp2_1,[XMIN,tmp2_1_2],
                      [XMIN,tmp2_(length(tmp2))_2],tmp2_(length(tmp2))],LLcrd(#)),["nodisp"]);
          Joincrvs(text(kk)+name,[namep,"sg"+name],["nodisp"]);//180717
          bname="join"+text(kk)+name;
        );
      ,
        Enclosing2(text(kk)+name,tmp,["nodisp"]);//180619[2lines]
        bname="en"+text(kk)+name;
      );
    );
    bdylist=append(bdylist,parse(bname));
    bdynameL=append(bdynameL,bname);
  );
  options=optionsorg;
  tmp=Divoptions(options);
  Ltype=tmp_1;
  Noflg=tmp_2;
  eqL=tmp_5;
  reL=tmp_6;
  color=tmp_(length(tmp)-2);
  opstr=tmp_(length(tmp)-1);
  opcindy=tmp_(length(tmp));
  angle=45;
//  interval=0.125*1000/2.54/MilliIn;
  interval=0.25*1000/2.54/MilliIn; //180706
  startP=[(XMIN+XMAX)/2, (YMIN+YMAX)/2];
  maxnum=[50,0]; //181109changed [first,second]
  fileflg="N";//181102from
  mkflg=1;
  chkL=[]; //181109
  forall(eqL,
    tmp=Strsplit(#,"=");
    tmp1=Toupper(substring(tmp_1,0,1));
    if(tmp1=="M",
      maxnum=parse(tmp_2);
      if(!islist(maxnum),
        maxnum=[maxnum,0];
      );
      options=remove(options,[#]);
    );
    if(tmp1=="F", //181102from
      fileflg=Toupper(substring(tmp_2,0,1));
      options=remove(options,[#]);
    ); //181102to
    if(tmp1=="N", //181103from
      tmp=parse(tmp_2);
      if(Anyselected(tmp),
        mkflg=-1;
      );
      options=remove(options,[#]);
    );
    if(tmp1=="C",
      chkL=parse(tmp_2);
      options=remove(options,[#]);
    );
  );//181102,03to
  tmp1=1;
  forall(reL,
    if(islist(#),
      startP=#;
    ,
      if(tmp1==1,
        angle=#;
        tmp1=tmp1+1;
      ,
        interval= interval*#;
      );
    );
  );
  if((fileflg=="Y")%(fileflg=="M")&(mkflg>-1), //181102from
    wflg=1;
    varL=flatten(bdylistorg);
    varL=select(varL,length(#)>1);
    varL=sort(varL);
    pL=[];
    forall(1..(length(varL)),nn,
      tmp1=varL_nn;
      tmp=select(GLIST,substring(#,0,length(tmp1))==tmp1);
      str=tmp_1;
      varL_nn=str;
      tmp1=Bracket(str,"()");
      tmp2=max(apply(tmp1,#_2));
      nL=select(1..(length(tmp1)),tmp1_#_2==tmp2);
      forall(nL,nn,
        is=tmp1_nn_1; ie=tmp1_(nn+1)_1;
        tmp=substring(str,is,ie-1);
        tmp=replace(tmp,"'",Dq);
        tmp=parse("["+tmp+"]");
        tmp2=flatten(tmp);
        tmp2=flatten(tmp2);
        tmp2=flatten(tmp2);
        forall(tmp2,
          if(ispoint(#),
            if(!contains(pL,text(#)),
              pL=append(pL,text(#));
            );
          );
        );
      );
    );
    forall(chkL,
      if(!contains(pL,#),pL=append(pL,#));
    );
    forall(pL,
      tmp=#+"="+Textformat(parse(#+".xy"),5);
      varL=append(varL,tmp);
    );
    tmp="reL="+Textformat(reL,5);
    varL=append(varL,tmp);
    if(fileflg=="M",
      fileflg="Y";
    ,
      tmp1="hatch"+nm+".txt";
      if(isexists(Dirwork,tmp1),
        tmp2=load(tmp1);
        tmp2=tokenize(tmp2,"//");
        tmp2=tmp2_(1..(length(tmp2)-1));
        if(tmp2==varL,
          wflg=0;
          if(isexists(Dirwork,fname),
            mkflg=0;
            ReadOutData(fname);
            tmp=name+"="+Textformat(parse(name),5);
            parse(tmp);
          );
        );
      );
    );
  );
  if(mkflg==1, //181102to
    angle=angle*pi/180;
    vec=[cos(angle),sin(angle)];
    nvec=[-sin(angle),cos(angle)];
    AnsL=[]; 
    ctr=0;//181005[2lines]
    forall(0..(maxnum_1), kk,
      pt=startP+kk*interval*nvec;
      sha=Makehatch(iostr,pt,vec,bdylist);
      if((sha!=-1)&(length(sha)>0),
        AnsL=concat(AnsL,sha);
        ctr=ctr+1; //181005
      );
    );
    maxnum_2=maxnum_2+(maxnum_1-ctr); //181005
    forall(1..(maxnum_2),kk, //181005
      pt=startP-kk*interval*nvec;
      sha=Makehatch(iostr,pt,vec,bdylist);
      if((sha!=-1)&(length(sha)>0),
        AnsL=concat(AnsL,sha);
      );
    );
    tmp1=apply(AnsL,Textformat(#,5));
    tmp=name+"="+tmp1;
    parse(tmp);
  );
  if((Noflg<3)&(mkflg>-1),
    if(fileflg!="Y", //181102
      println("generate Hatchdata "+name);
      tmp=name+"="+Textformat(AnsL,5);
      parse(tmp);
      if(!islist(iostr),tmp1=[iostr],tmp1=iostr); //no ketjs on
      tmp="c"+PaO();
      forall(tmp1,
        tmp=tmp+Dq+#+Dq+",";
      );
      tmp=substring(tmp,0,length(tmp)-1)+")";
      tmp2=name+"=Hatchdata("+tmp;
      forall(bdynameL,
        tmp2=tmp2+",list"+PaO()+#+")";
      );
      tmp2=tmp2+opstr+")";
      GLIST=append(GLIST,tmp2); //no ketjs off
    ,
      GLIST=append(GLIST,"ReadOutData("+Dq+fname+Dq+")");//181102 //no ketjs
    );
  );
  if((Noflg<2)&(mkflg>-1),
    if(isstring(Ltype),
      if((Noflg==0)&(color!=KCOLOR), //180904 //no ketjs on
        Texcom("{");Com2nd("Setcolor("+color+")");//180722
      ); //no ketjs off
      Ltype=GetLinestyle(text(Noflg)+Ltype,name);
      if((Noflg==0)&(color!=KCOLOR), //180904 //no ketjs on
        Texcom("}");//180722
      ); //no ketjs off
    ,
      if(Noflg==1,Ltype=0);
    );
    GCLIST=append(GCLIST,[name,Ltype,opcindy]);
  );
  if(mkflg>-1,
    if((fileflg=="Y")&(wflg==1), //181102from
      tmp1="hatch"+nm+".txt";
      SCEOUTPUT = openfile(tmp1);
      forall(varL,
        println(SCEOUTPUT,#+"//");
      );
      closefile(SCEOUTPUT);
      WriteOutData(fname,[name,parse(name)]);
    );  //181102to
    tmp2=[];
    forall(AnsL,tmp1,
      tmp=apply(tmp1,LLcrd(#));
      tmp2=append(tmp2,tmp);
    );
    tmp2;
  );
);
////%Hatchdata end////

////%Shadein start////
Shadein(pstrorg):=( //190220
  regional(pstr,ptL,pL,crv,nn,
      tmp,tmp1,tmp2,pm1,pm2,p1,p2,flg);
  if(islist(pstrorg),pstr=pstrorg_1,pstr=pstrorg);
  crv=[];
  Framedata(["nodisp"]);
  ptL=IntersectcurvesPp(pstr,frwin);
  if(length(ptL)>0,
    pL=apply(ptL,#_2);
    forall(1..(length(pL)),nn,
      if(nn<length(pL),
       tmp1=pL_nn;
       tmp2=pL_(nn+1);
       tmp=Pointoncrv((tmp1+tmp2)/2,pstr);
      ,
        tmp1=pL_nn;
        tmp2=pL_1;
        tmp=parse(pstr);
        if(pL_nn==length(tmp),
          tmp=tmp_1;
        ,
          tmp=tmp_(length(tmp));
        );
      );
      if(Inwindow(tmp),
        tmp=Partcrv("",tmp1,tmp2,pstr,["nodata"]);
      ,
        tmp1=Pointoncrv(tmp1,pstr);
        tmp2=Pointoncrv(tmp2,pstr);
        pm1=Paramoncrv(tmp1,frwin);
        pm2=Paramoncrv(tmp2,frwin);
        if(floor(pm1)==floor(pm2),
          tmp=Listplot("",[tmp1,tmp2],["nodata"]);
        ,
          tmp=floor(pm1);
          p1=Pointoncrv(tmp,"frwin");
          p2=Pointoncrv(mod(tmp,4)+1,"frwin");
          tmp=p1-10*(p2-p1);
          Listplot("frwin",[p1,tmp],["nodisp","Msg=n"]);
          tmp=IntersectcurvesPp("sgfrwin",pstr);
          if(mod(length(tmp),2)==0, //190223from
            if(pm2<pm1,pm2=pm2+4); 
            tmp=[tmp1];
            pm1=floor(pm1)+1;
            flg=0;
            forall(1..3,
              if(flg==0,
                if(pm1<pm2,
                  p1=Pointoncrv(mod(pm1-1,4)+1,"frwin");
                  tmp=append(tmp,p1);
                  pm1=pm1+1;
                ,
                  flg=1;
                );
              );
            );
            if(pm1-1<pm2,tmp=append(tmp,tmp2));
          ,
            if(pm2>pm1,pm2=pm2-4);
            tmp=[tmp1];
            pm1=floor(pm1);
            flg=0;
            forall(1..3,
              if(flg==0,
                if(pm1>pm2,
                  p1=Pointoncrv(mod(pm1-1,4)+1,"frwin");
                  tmp=append(tmp,p1);
                  pm1=pm1-1;
                ,
                  flg=1;
                );
              );
            );
            if(pm1+1>pm2,tmp=append(tmp,tmp2));
          ); //190223to
        );
      );
      if(length(crv)==0,
        crv=tmp;
      ,
        crv=Joincrvs("",[crv,tmp],["nodata"]);
      );
    );
  ,
    if(Inwindow(parse(pstr+"_1")),crv=pstr,crv=frwin);
  );
  crv;
);
////%Shadein end////

////%Shade start////
Shade(plist):=Shade(plist,[]); 
Shade(Arg1,Arg2):=(
  if(!isstring(Arg1),
    Shade(text(SHADECTR),Arg1,Arg2); //190222
  ,
    Shade(Arg1,Arg2,[]);
  );
);
Shade(nm,plistorg,options):=(
//help:Shade(["gr1"],[0.5]);
//help:Shade(["gr1"],["Color=red"]);
//help:Shade(["gr1"],["Trim=y(n)"]); //190224
// help:Shade(["gr1","sg1"],["Color=[1,0,0]"]);
// help:Shade([[A,B,C,A]]);
//help:Shade(["gr2","Invert(sg1)"],["Enc=y",(Startpoint)]);
  regional(name,plist,jj,nn,trim,tmp,tmp1,tmp2,
     opstr,opcindy,eqL,reL,Str,G2,flg,encflg,startpt,color,ctr);
  name="shade"+nm;
  plist=plistorg;
  if(isstring(plist_1), // 16.01.24
    println("output Shade of "+plist);
  ,
    println("output Shade of lists");
  );
  tmp=Divoptions(options);
  eqL=tmp_5; 
  reL=tmp_6;
  color=tmp_(length(tmp)-2);
  opstr=tmp_(length(tmp)-1);
  opcindy=tmp_(length(tmp));
  tmp=select(plist,indexof(#,"Invert")>0); //180929from
  if(length(tmp)>0,encflg=1,encflg=0);
  trim="N";
  forall(eqL,
    tmp=Strsplit(#,"=");
    tmp1=Toupper(tmp_1);
    tmp2=Toupper(tmp_2);
    if(substring(tmp1,0,1)=="E",
      if(substring(tmp2,0,1)=="Y",
        encflg=1;
      );
      if(substring(tmp2,0,1)=="N",
        encflg=0;
      );
    );
    if(substring(tmp1,0,1)=="T",
      trim=substring(tmp2,0,1);
    );
  );
  startpt=[];
  forall(reL,
    if(islist(#),
      startpt=#;
    );
  ); //180929to
  if(length(color)==4, //180602from
    tmp=Colorcmyk2rgb(color);
  );
  flg=0; ctr=1;
  if(encflg==1, //180929from
    if(length(startpt)==2,
      Enclosing(nm,plist,[startpt,"nodisp"]);
    ,
      Enclosing(nm,plist,["nodisp"]);
    );
    plist=["en"+nm];
  ); //180929to
  if((length(plist)==1)&(trim=="Y"), //190220from,109224
    plist=[Shadein(plist)];
  ); //190220to
  forall(1..(length(plist)),jj, //180613from
    if(flg==0,
      tmp1=plist_jj;
      if(isstring(tmp1),tmp=parse(tmp1),tmp=tmp1);
      if(!islist(tmp),
         flg=1;
      ,
        if(!isstring(tmp1),
          tmp2=[];
          forall(tmp1,if(ispoint(#),tmp=#.xy,tmp=#);
            tmp2=append(tmp2,tmp);
          );
          tmp1=Dqq("-"+name+text(ctr));
          tmp2=Textformat(tmp2,6)+",["+Dqq("nodisp")+"]";
          tmp=name+text(ctr)+"=Listplot("+tmp1+","+tmp2+")";
          parse(tmp);
          plist_jj=name+text(ctr);
          ctr=ctr+1;
        );
      ); 
    );
  );//180613to
  if(flg==1,
    println("    some data not defined properly");
 ,
    G2=Joincrvs("1",plist,["nodata"]);
    G2=apply(G2,Pcrd(#));
    tmp1="fillpoly("+Textformat(G2,5)+opcindy+");";
    parse(tmp1);
  );
  Str="Shade("; //no ketjs on
  tmp1="list"+PaO();
  forall(plist,
    if(isstring(#),  // from 16.01.24
      if(length(#)>1,
        tmp1=tmp1+#+",";
      ,
        tmp1=tmp1+Dq+#+Dq+",";
      );
    ,
       tmp1=tmp1+"Listplot("+Textformat(#,5)+"),";
    ); //16.01.24to
  );
  Str=Str+substring(tmp1,0,length(tmp1)-1)+")"+")"; //180929 
  nn=length(COM2ndlist); //190311from
  jj=nn;
  forall(plist,tmp1,
    tmp=select(1..nn,indexof(COM2ndlist_#,tmp1)>0);
    jj=min(append(tmp,jj));
  );
  tmp1=["Texcom("+Dqq("{")+")","Setcolor("+color+")",Str,"Texcom("+Dqq("}")+")"];
  tmp2=COM2ndlist_(1..(jj-1));
  tmp=COM2ndlist_(jj..(length(COM2ndlist)));
  if(!islist(tmp),tmp=[tmp]);
  COM2ndlist=concat(tmp2,tmp1);
  COM2ndlist=concat(COM2ndlist,tmp); //190311to
  //no ketjs off
  SHADECTR=SHADECTR+1;
);
////%Shade end////

/////////// end of new Hatchdata(cindy) ///////////




//help:end();

