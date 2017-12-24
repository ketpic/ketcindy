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

println("KETCindy V.3.1.4(2017.12.24");
println(ketjavaversion());//17.06.05
println("ketcindylibbasic1(2017.12.03) loaded");

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

Ketinit():=Ketinit(1);
//help:Ketinit();
Ketinit(sy):=Ketinit(sy,[-5,5],[-5,5]);
Ketinit(sy,rangex,rangey):=(
  regional(pt,tmp,tmp1,tmp2,letterc,boxc,shadowc,mboxc);
  PenThickInit=8;
  ULEN="1cm";
  MARKLEN=0.2; //16.11.01
  KETPICLAYER=20;
  MilliIn=1/2.54*1000;
  PenThick=round(MilliIn*0.02);
  PenThickInit=PenThick;
  TenSizeInit=0.02;
  TenSize=TenSizeInit;
  YaSize=1; YaAngle=18; YaPosition=1;
  YaThick=1; YaStyle='tf';
  KETPICCOUNT=1;
  KCOLOR=[0,0,0];
  GLIST=[];
  GCLIST=[];
//  GDATALIST=[];
  GOUTLIST=[];
  POUTLIST=[];
  VLIST=[];
  FUNLIST=[];
  LETTERlist=[];
  COM0thlist=[];
  COM1stlist=[];
  COM2ndlist=[];
  ADDAXES="1";
  LFmark=unicode("000a");
  CRmark=unicode("000d");//16.12.13
  Dq=unicode("0022");
  WaitUnit=10;
  CONTINUED=0;
  OutComList=[];
  OutFileLIst=[];   // 15.10.22
  FigPdfList=[];  // 16.04.08
  ADDPACK=[]; // 16.05.16
  ErrFlag=0;
  setdirectory(Dirwork);
  if(!isstring(Fhead),  // 17.10.13from, 17.11.12
    Fhead=text(curkernel());
    Fhead=replace(Fhead,".cdy","");
    Slidename=Fhead; //17.10.24
  );//17.11.12
  if(isstring(Dircdy) & iswindows(),  //17.12.01
    Dircdy=replace(Dircdy,"/",pathsep());
    if(substring(Dircdy,0,1)==pathsep(),
      Dircdy=substring(Dircdy,1,length(Dircdy));
    );
  );
  Fnametex=Fhead+".tex";
  FnameR=Fhead+".r";
  FnamebodyR=Fhead+"body.r";
  Fnameout=Fhead+".txt";  // 17.10.13upto
  if(!isstring(Mackc),// 16.06.07
    Mackc="sh"; 
  );
  if(iswindows(),
    Batparent="\kc.bat";
  ,
    Shellparent="/kc.sh";
    if(!isexists(Dirwork,""),
      println(Dirwork+" not exist");
    ,
      if(!iskcexists(Dirwork),
        setdirectory(Dirwork);
        SCEOUTPUT = openfile(Shellparent);
        closefile(SCEOUTPUT);
        println(Shellparent+" generated");
      );
      println(setexec(Dirwork,Shellparent));
    );
  );
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
  // for Presentation
  letterc=[0.98,0.13,0,0.43]; boxc=[0,0.32,0.52,0];
  shadowc=[0,0,0,0.5]; mboxc="yellow"; //17.03.02 regional debugged
  SlideColorList=[letterc,boxc,boxc,boxc,shadowc,shadowc,6,1.3,
                letterc,mboxc,mboxc,mboxc,62,2,letterc];
  ThinDense=0.1;//17.01.08
  if(indexof(PathS,"-5.")>0,//17.12.03from
    LibnameS=Dirlib+pathsep()+"ketpicsciL5";
  ,
    LibnameS=Dirlib+pathsep()+"ketpicscifiles6";
  );
  if(indexof(PathT,"pdflatex")+indexof(PathT,"lualatex")>0,
    LibnameS=replace(LibnameS,"ketpic","ketpic2e");
  );//17.12.03upto
);

Getcdyname():=( //17.11.27
//help:Getcdyname();
text(curkernel());
);

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
  Putpoint("SW",Pcrd([XMIN,YMIN]));//17.05.30
  Putpoint("NE",Pcrd([XMAX,YMAX]));//17.05.30
//  Ketinit();
);

Setfiles(file):=( // 17.01.16
//help:Setfiles(file);
    Fhead=file;
    Fnametex=Fhead+".tex";
    FnameR=Fhead+".r"; //17.10.14
    FnamebodyR=Fhead+"body.sce";
    Fnameout=Fhead+".txt";
);

Setparent(file):=( // 17.11.27
//help:Setparent(file);
    Texparent=file;
);

Setcindyname():=Setcindyname("");//16.12.25
Setcindyname(file):=(
//help:Setcindyname("Fhead");
//help:Setcindyname(<only when on the terminal "ketcindy/cindy.sh "+file>);
  regional(tmp,tmp1,tmp2);
  setdirectory(Dirhead);
  CindyPathName="";
  CindyFileName="";
  CindyPathName=load("cindypath.txt");
  tmp2=load("cindyfile.txt");
  tmp2=replace(tmp2,".cdy","");
  if(length(tmp2)>0,
    CindyFileName=tmp2;
    if(length(file)>0,
      tmp=file+"="+DqDq(tmp2);
      parse(tmp);
      println(file+" set to "+DqDq(tmp2));
    );
  ,
    println("set "+file+" manually");
  );
  setdirectory(Dirwork);
  CindyFileName;
);

Cindypath():=( // 16.12.26
//help:Cindypath();
  regional(out);
  CindyPathName="";
  setdirectory(Dirhead);
  CindyPathName=load("cindypath.txt");
  setdirectory(Dirwork);
  if(length(CindyPathName)==0,
    out=Dirwork;
  ,
    out=CindyPathName;
  );
  println("  path name="+out);
  out;
);

Cindyfile():=( // 16.12.26
//help:Cindyfile();
  regional(out);
  CindyFileName="";
  setdirectory(Dirhead);
  out=load("cindyfile.txt");
  out=replace(out,".cdy","");
  setdirectory(Dirwork);
  CindyFileName=out;
  println("  file name="+out);
  out;
);

DqDq(str):=unicode("0022")+str+unicode("0022");

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
      if(indexof(tmp1,tmp)>0,rep=parse(tmp2),rep=tmp2);  // 16.09.28upto
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
    ); // 16.09.05upto
  );
  dtstr=dtstrorg;// 16.09.19from
  tmp=substring(dtstr,length( dtstr)-1,length(dtstr)); 
  if(tmp!=lfm,
    dtstr=dtstr+first;
  );// 16.09.19upto
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

Columnlist(dt,list):=( // 16.09.04
//help:Columnlist(dt,1..3);
  apply(dt,#_list);
);

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

factorial(n):=(
//help:factorial(5);
  regional(out);
  out=1;
  forall(1..n,
    out=out*#;
  );
  out;
);

norm(v1):=(  // 16.09.01
//help:norm([2,1,3]);
  regional(out,tmp,tmp1,tmp2);
  out=0;
  forall(1..(length(v1)),
    out=out+(v1_#)^2;
  );
  out=sqrt(out);
  out;
);
norm(v1,v2):=(
  norm(v2-v1);
);

// 16.03.28
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

Parlevel(str):=Bracket(str); // 16.05.22from 
Bracket(str):=Bracket(str,"()");
Bracket(str,br):=(
//help:Bracket(string,"()");
  regional(ph,pt,out,noL,ncL,nall,level,tmp);
  ph=substring(br,0,1);
  pt=substring(br,1,2);
  noL=Indexall(str,ph);
  ncL=Indexall(str,pt); // 16.05.22upto
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

Changelib(path):=(
  Dirlib=path;
  setdirectory(Dirlib);
  import("ketcindyset.txt");
  setdirectory(Dirwork); // 16.04.23
);

Changework(dirorg):=( //16.10.21
//help:Changework(directory);
  regional(dir,subdir,tmp);
  dir=replace(dirorg,"/",pathsep());//17.11.20from
  dir=replace(dir,"\",pathsep());
  dir=replace(dir,pathsep()+pathsep(),pathsep());//17.11.24
  tmp=length(dir);
  if(substring(dir,tmp-1,tmp)==pathsep(),
    dir=substring(dir,0,tmp-1);
  );//17.11.20upto
  tmp=Indexall(dir,pathsep()); //17.11.24from
  subdir="";
  if(length(tmp)>0,
    tmp=tmp_(length(tmp));
    subdir=substring(dir,tmp,length(dir));
    dir=substring(dir,0,tmp-1);
  ); //17.11.24upto
  if(dir=="" % !isexists(dir,""),
    println("Directory "+dir+" not exist, so set to "+Dirwork);
    ErrFlag=-1;
  ,
    if(length(subdir)>0, //17.11.24from
      println(makedir(dir,subdir));
      Dirwork=dir+pathsep()+subdir;
    ,
      Dirwork=dir;
    ); //17.11.24upto
    setdirectory(Dirwork);
    if(!iswindows(), //17.04.11
      if(!iskcexists(Dirwork),
        SCEOUTPUT = openfile("/kc.sh");
        closefile(SCEOUTPUT);
        println(setexec(Dirwork,"/kc.sh"));
      );
    );
  );
);

Changestyle(nameL,style):=(
//help:Changestyle(["sgAB"],["da"]);
  regional(nmL,name,Ltype,Ltypeorg,Noflg,opcindy,tmp);
  tmp=Divoptions(style);
  Ltypeorg=tmp_1;
  Noflg=tmp_2;
  opcindy=tmp_(length(tmp));
  if(islist(nameL),nmL=nameL,nmL=[nameL]);
  forall(nmL,name,
    Ltype=Ltypeorg;
    GCLIST=select(GCLIST,#_1!=name);
    COM2ndlist=select(COM2ndlist,
      (indexof(#,"("+name)==0)%(indexof(#,"Shade")>0)); // 15.05.23,16.12.13
    if(Noflg<2,
      if(isstring(Ltype),
        Ltype=GetLinestyle(text(Noflg)+Ltype,name);
      ,
        if(Noflg==1,Ltype=0);
      );
      GCLIST=append(GCLIST,[name,Ltype,opcindy]);
    );
  );
);

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

Workprocess():=Workprocess(300);
Workprocess(nn):=Drawprocess(nn);
Drawprocess():=Drawprocess(300);
Drawprocess(nn):=(
//help:Workprocess();
  regional(All,added,remain,out,flg,tmp,tmp1,tmp2);
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
  println("Process of drawing");
  forall(out,
    println(Dependgeo(parse(#)));
  );
  out;
);

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

Textformat(value,dig):=(
//help:Textformat(2/3,4);
//help:Textformat([gr1,gr2],5);
  regional(vv,tmp,tmp1);
  if(islist(value),
    tmp1="[";
    forall(value,
      tmp1=tmp1+Textformat(#,dig)+",";
    );
    tmp1=substring(tmp1,0,length(tmp1)-1)+"]";
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

Assign(str):=(  //  old
  regional(out);
  out=str;
  forall(VLIST,
    tmp=substring(#_1,0,length(#_1)-1);
    out=replace(out,tmp,"("+#_2+")");
  );
  out;
);

Assign(funstr,vrL):=(
  regional(nn,out,tmp,tmp1);
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

MeasureDepth(list):=(
  regional(tmp,tmp1,Depth,Flg);
  Flg=0;
  Depth=0;
  if(ispoint(list),  // 15.01.22
    Depth=0;
    Flg=1;
  ,
    tmp1=select(1..(length(list)),length(list_#)>0);//17.05.21from
    tmp=list_(tmp1_1);//17.05.21upto
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
  Depth;
);

Flattenlist(pltlist):=(
//help:Flattenlist([[2,3],[[1,2],[5,6]]]);
  regional(Out,nn,Dt,ii,tmp,flg);
  Out=[];
  if(MeasureDepth(pltlist)==1,
    Out=[pltlist];
  ,
    forall(1..(length(pltlist)),nn,
      Dt=pltlist_nn;
      if(MeasureDepth(Dt)<2,
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

Divoptions(options):=(
//help:Divoptions(options);
  regional(Ltype,Noflg,Inflg,Outflg,eqL,realL,strL,opstr,opcindy,flg,tmp,tmp1);
  Ltype="dr";  // 2015.01.13
  Noflg=0;
  Inflg=0;
  Outflg=0;
  eqL=[];
  realL=[];
  strL=[];
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
        eqL=append(eqL,#);
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
        strL=append(strL,#);
        opstr=opstr+","+Dq+#+Dq;
      );
    );
  );
  if(indexof(opcindy,"color->")==0,// 16.10.07from
    opcindy=opcindy+",color->[0,0,0]";
  );
  [Ltype,Noflg,Inflg,Outflg,eqL,realL,strL,opstr,opcindy];
);

Dotprod(vec1,vec2):=(
//help:Dotprod(vec1,vec2);
  regional(v1,v2,tmp);
  if(ispoint(vec1),v1=vec1.xy,v1=vec1);
  if(ispoint(vec2),v2=vec2.xy,v2=vec2);
  v1*v2;
);

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

Ptstart(Fig):=(
//help:Ptstart("gr1");
  regional(tmp);
  if(isstring(Fig),tmp=parse(Fig),tmp=Fig);  // 16.01.21
  tmp_1;
);

Ptend(Fig):=(
//help:Ptend("gr1");
  regional(tmp);
  if(isstring(Fig),tmp=parse(Fig),tmp=Fig);
  tmp_(length(tmp)); // 15.04.12
);

Numptcrv(Fig):=(
//help:Numptcrv("gr1");
  regional(tmp);
  if(isstring(Fig),tmp=parse(Fig),tmp=Fig);  // 15.12.23
  length(tmp);
);

Ptcrv(Num,Fig):=(
//help:Ptcrv(10,"gr1");
  regional(tmp);
  if(isstring(Fig),tmp=parse(Fig),tmp=Fig);
  tmp_Num;
);

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
);// upto 16.01.27

Paramoncrv(pP,Gdata):=(
  regional(Tmp,PtL);
//  Eps=10^(-8);
  if(isstring(Gdata),PtL=parse(Gdata),PtL=Gdata);
  Tmp=Nearestpt(pP,PtL);
  Tmp_2;
);

ParamonCurve(pP,nN,plist):=(
//help:ParamonCurve(A,10,"gr1");
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

Pointoncrv(tT,PtL):=PointonCurve(tT,PtL);
PointonCurve(tT,Gdata):=(
//help:PointonCurve(20.5,"gr1");
  regional(Out,Eps,nN,sS,Pa,Pb,PtL);
  if(isstring(Gdata),PtL=parse(Gdata),PtL=Gdata);
  if(length(PtL)==1,PtL=PtL_1);
  Eps=10^(-4);
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
  if(MeasureDepth(Data1)==2,Data1=Data1_1);
  if(MeasureDepth(Data2)==2,Data2=Data2_1);
  Data1=apply(Data1,LLcrd(#));
  Data2=apply(Data2,LLcrd(#));
  if(length(Data1)==length(Data2),
    Tmp1=Reverse(Data2); 
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
  ); // 15.04.06 upto
  Out;
);

Intersectcrvs(Gr1,Gr2):=Intersectcrvs(Gr1,Gr2,[]);
//help:Intersectcrvs("gr1","pa1");
Intersectcrvs(Gr1,Gr2,options):=(
  regional(tmp,tmp1,tmp2);
  tmp1=IntersectcrvsPp(Gr1,Gr2,options);
  apply(tmp1,#_1);
);

NearestptcrvPhy(point,PL):=(
  regional(tmp,pP,plist);
  pP=Pcrd(point);
  if(isstring(PL),plist=parse(PL),plist=PL);
  if(MeasureDepth(plist)==2,plist=plist_1);
  plist=apply(plist,#);  // 14.12.18
  tmp=Nearestpt(pP,plist);
  tmp=tmp_1;
  [tmp_1/SCALEX,tmp_2/SCALEY];
);

Nearestptcrv(point,plist):=(
//help:Nearestptcrv(A,"gr1");
  regional(tmp);
  tmp=Nearestpt(point,plist);
  tmp_1;
);

Nearestpt(point,PL2):=(
  regional(PL1,PL,Ans,Flg,Eps,pA,Pm,Im,Sm,Nn,Ni,
      a1,b1,a2,b2,v1,v2,x1,x2,Tmp,rT,pP,sS,Lm,Pm,Sm,Flg);
//help:Nearestpt("gr1","gr2");
  if(isstring(point),PL1=parse(point),PL1=point);
  if(MeasureDepth(PL1)==2,PL1=PL1_1);
  if(!islist(PL1_1),
    PL1=[PL1];
    Flg=0;
  ,
    Flg=1;
  );
  if(isstring(PL2),PL=parse(PL2),PL=PL2);
  if(MeasureDepth(PL)==2,PL=PL_1);
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
          Tmp=ParamonCurve(pP,Ni,PL);
          Pm=pP; Lm=Tmp; Sm=sS;
        );
      );
      if(Sm<Ans_5,  // 16.05.03from
        Ans=[pA,Nn,Pm,Lm,Sm];
      );
    );  // 16.05.03upto
  );
  if(Flg==0,
    Ans=Ans_(3..5);
  );
  Ans;
);

Derivative(fun,var,value):=(
//help:Derivative("x^3","x",2);
  regional(str,tmp);
  str="d(";
  str=str+replace(fun,var,"#")+",";
  str=str+value+")";
  tmp=Pcrd([1,parse(str)]);  // 14.11.08
  tmp_2;
);

Integrate(pltdata,range):=Integrate(pltdata,range,[]);
Intergrate(Arg1,Arg2,Arg3):=(
  regional(pltdata,range,options,fnstr,vartr);
  if(islist(Arg2),
    pltdata=Arg1;
    range=Arg2;
    options=Arg3;
    Integrate(pltdata,range,options);
  ,
    fnstr=Arg1;
    vastr=Arg2;
    range=Arg3;
    Integrate(fnstr,vastr,range,[]);    
  );
);

Integrate(pltdata,range,options):=(
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
    if(MeasureDepth(pdata)==2,pdata=pdata_1);
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

Integrate(fnstr,vastr,range,options):=(
//help:Integrate("sin(x)","x",[0,pi],["Num=100","Rule=s"]);
  regional(tmp,tmp1,Sm,Lx,Rx,va1,va2,Num,Waysx,ex,dx,xn,yn,x0,x1,x2,y0,y1,y2);
  Num=100;
  Way="t";
  forall(options,
    if(indexof(#,"=")>0,
      if(indexof(#,"N=")>0,
        Num=parse(substring(#,indexof(#,"="),length(#)));
      );
      if(indexof(#,"Num=")>0,
        Num=parse(substring(#,indexof(#,"="),length(#)));
      );
      if(Toupper(substring(#,0,1))=="R",
        tmp=indexof(#,"=");
        Way=substring(#,tmp,tmp+1);
      );
	);
  );
  Sm=0;
  if(Way=="t",
    forall(1..Num,
      Lx=range_1+(range_2-range_1)*(#-1)/Num;
      Rx=range_1+(range_2-range_1)*#/Num;
      va1=parse(replace(fnstr,vastr,textformat(Lx,5)));
      va2=parse(replace(fnstr,vastr,textformat(Rx,5)));
      Sm=Sm+(va1+va2)*(Rx-Lx)/2;
    );
  ,
    sx=range_1;
    ex=range_2;
    dx=(ex-sx)/Num;
    xn=apply(0..Num,sx+#*dx);
    yn=apply(xn,parse(replace(fnstr,vastr,textformat(#,5))));
    dx=dx/2;
    repeat(Num,s,
      x0=xn_s;
      x1=(xn_s+xn_(s+1))/2;
      x2=xn_(s+1);
      y0=yn_s;
      y1=parse(replace(fnstr,vastr,textformat(x1,5)));
      y2=yn_(s+1);
      Sm=Sm+dx*(y0+4*y1+y2)/3;
    ); 
  );
  Sm;
);

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
  if(MeasureDepth(pdata)==2,pdata=pdata_1);
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

Findarea(pdstr):=(
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

Findarea(pdstr):=(  // 15.11.27
//help:Findarea("cr1");
  regional(pd,p0,p1,p2,p3,s,tmp);
  if(isstring(pdstr),pd=parse(pdstr),pd=pdstr);
  s=0;
  forall(1..(length(pd)-1),
    p1=pd_#;
    p2=pd_(#+1);
    if(#==1,p0=pd_(length(pd)-1),p0=pd_(#-1));
    if(#==length(pd)-1,p3=pd_2,p3=pd_(#+2));
    tmp=IntegrateO(p0,p1,p2,p3);
    s=s+tmp;
  );
  if(s<0,s=-s);
  s;
);

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

Inversefun(fnstr,rngstr,value):=(
  regional(tmp,varstr,range,x1,x2,x3,va1,va2);
  tmp=indexof(rngstr,"=");
  varstr=substring(rngstr,0,tmp-1);
  range=parse(substring(rngstr,tmp,length(rngstr)));
  x1=range_1; x2=range_2;
  repeat(15,
    x3=(x1+x2)/2;
    va1=parse(replace(fnstr,varstr,textformat(x1,5)));
    va2=parse(replace(fnstr,varstr,textformat(x3,5)));
    if((va1>value & va2>value) % (va1<value & va2<value),
      x1=x3;
    ,
      x2=x3;
    );
  );
  va1=parse(replace(fnstr,varstr,textformat(x1,5)))-value;
  va2=parse(replace(fnstr,varstr,textformat(x2,5)))-value;
  if(x1==range_1 % x2==range_2, 
    println("not found in ("+textformat(range_1,5)
	     +","+textformat(range_2,5)+")");
  );
  if(abs(va1)<=abs(va2),x1,x2);
);

Com0th(String):=(
    regional(str);
    str=replace(String,LFmark,"");
    COM0thlist=append(COM0thlist,str);
);

Com1st(String):=(
    regional(str);
    str=replace(String,LFmark,"");
    GLIST=append(GLIST,str);  // 15.05.27
//    COM1stlist=append(COM1stlist,str);
);

Com2nd(String):=(
// help:Com2nd("");
    regional(str);
    str=replace(String,LFmark,"");
    COM2ndlist=append(COM2ndlist,str);
);

Com2ndpre(String):=(
    regional(str);
    str=replace(String,LFmark,"");
    COM2ndlist=prepend(str,COM2ndlist);
);

Texcom(strorg):=(  //17.09.22
//help:Texcom("\color[cmyk]{0,0,0,0.5}");
  regional(str);
  str=replace(strorg,"\","\\");
  str=replace(str,"\\\\","\\");
  str="Texcom("+Dq+str+Dq+")";
  Com2nd(str);
);

Ketcindylogo():=(
//help:Ketcindylogo();
  Com2nd("Texcom("+Dq+"\def\ketcindy{{K\kern-.20em
          \lower.5ex\hbox{E}\kern-.125em{TCindy}}}"+Dq+")");
);

Drwline():=Drwline(textformat(GrL,5));
Drwline(gstr):=(
  Com2nd("Drwline("+gstr+")");
);

Dashline(gstr):=(
  Com2nd("Dashline("+gstr+")");
);

Invdashline(gstr):=(
  Com2nd("Invdashline("+gstr+")");
);

Dottedline(gstr):=(
 Com2nd("Dottedline("+gstr+")");
);

SetEnglish():=(
//help:SetEnglish();
  Com0th("setlanguage('en')");
);

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

Setunitlen(string):=(
//help:Setunitlen("5mm");
  ULEN=string;
  GLIST=append(GLIST,"Setunitlen("+Dq+string+Dq+")");
);

Setmarklen(ratio):=(
//help:Setmarklen(0.2);
  MARKLEN=ratio*0.2;//16.11.01
  Com2nd("Setmarklen("+textformat(ratio,5)+")");
);

Setorigin(point):=(
//help:Setorigin([1,2]);
  Com2nd("Setorigin("+textformat(point,5)+")");
);

Fontsize(sizestr):=(
//help:Fontsize("s");
  Com2nd("Fontsize('"+sizestr+"')");
);

Setpen(width):=(
//help:Setpen(2);
  PenThick=PenThickInit*width; // 16.04.09
  Com2nd("Setpen("+text(width)+")");
);

Lcrd(pt):=(
  regional(tmp);
  if(ispoint(pt),
    tmp=[pt.x/SCALEX,pt.y/SCALEY];
  ,
    tmp=pt;
  );
  tmp;
);

Pcrd(pt):=(
  regional(tmp);
  if(ispoint(pt),
    tmp=re(pt.xy); // 15.07.24
  ,
    tmp=[pt_1*SCALEX,pt_2*SCALEY];
  );
 tmp;
);

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

Setpt(n):=Ptsize(n);
//help:Setpt(5);
Ptsize(n):=(
  println("Setpt("+text(n)+")");
  TenSize=TenSizeInit*n;
  Com2nd("Setpt("+text(n)+")"); // 14.01.19
);

Definecolor(name,data):=(
//help:Definecolor("mycolor",[1,1,1,0]);
  regional(type,tmp);
  if(length(data)>3,type="cmyk",type="rgb");  
  tmp=text(data);
  tmp=substring(tmp,1,length(tmp)-1);
  tmp="\definecolor{"+name+"}{"+type+"}{"+tmp+"}";
  Texcom(tmp);
);

Setcolor(Par):=(
//help:Setcolor([1,0,0,1]);
//help:Setcolor([1,1,0]);
  if(islist(Par),
    if(length(Par)==3,
      Setcolorrgb(Par);  // 2015.04.28
//      KCOLOR=Par;  
    );
    if(length(Par)==4,
      Setcolor(Par,[]);
    );
  ,
    Setcolor(Par,[]);
  );
);

Setcolor(colorname,options):=(
//help:Setcolor("greenyellow",0.3);
  regional(tmp);
  if(isstring(colorname),
    tmp="Setcolor("+Dq+colorname+Dq;
    if(length(options)>0,
      tmp=tmp+","+text(options_1);
    );
    Com2nd(tmp+")");
  );
  if(islist(colorname),
    tmp=text(colorname);
    tmp=substring(tmp,1,length(tmp)-1);
    Texcom("\color[cmyk]{"+tmp+"}"); //17.09.22
  );
);

Setcolorrgb(colorlist):=(
// help:Setcolorrgb([0.5,0.3,0.4]);
  regional(tmp);
  tmp=text(colorlist);
  tmp=substring(tmp,1,length(tmp)-1);
  tmp="Texcom("+Dq+"\\color[rgb]{"+tmp+"}"+Dq+")"; //17.10.07
  Com2nd(tmp);
);

ColorRgb2Cmyk(clr):=(
// help:ColorRgb([0.2,0.5,0.1]);
  regional(clrnew,tmp,black);
  tmp=apply(clr,1-#);
  black=min(tmp);
  tmp=apply(clr,(1-#-black)/(1-black));
  clrnew=append(tmp,black);
  clrnew;
);

ColorCmyk2Rgb(clr):=(
// help:ColorRgb([0.2,0.5,0.1,0.2]);
  regional(clrnew,tmp,black);
  black=clr_4;
  tmp=apply(clr,1-min(1,#*(1-black)+black));
  clrnew=tmp_(1..3);
  clrnew;
);

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
    rr = hue2rgb( var1, var2, hh + ( 1.0 / 3.0 ) );
    gg = hue2rgb( var1, var2, hh );
    bb = hue2rgb( var1, var2, hh - ( 1.0 / 3.0 ) );
  );
  [rr,gg,bb];
);

hue2rgb(vv1,vv2,vh):=(
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

Colorrgbhwb(sL):=(
  regional(dl1,dl2,dl3);
  dl1 = Colorrgbhsl(sL)_1;//Colorcode("rgb","hsl",sL)_1;
  dl2 =  min(sL);
  dl3 = 1 -  max(sL);
  dL= [dl1, dl2 , dl3 ];
);

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

Colorhslhsv(sL):=(
  regional(dl1,dl2,dl3,dL);
  dl1=sL_1;
  if(sL_3 == 0,
    // no need to do calc on black
    // also avoids divide by 0 error
    dL= [0, 0, 0];
  ,
  sL_3 = sL_3 * 2;
  if(sL_3 <= 1,sL_2 = sL_2 * sL_3,sL_2 = sL_2 * (2 - sL_3));
  dl3 = (sL_3 + sL_2) / 2;
  dl2 = (2 * sL_2) / (sL_3 + sL_2);
  dL = [dl1, dl2, dl3];
  );
  dL;
);

Colorcode(src,dest,sL):=(
//help:Colorcode("rgb","cmyk",[1,0.5,0]);
  regional(tmp,tmp1,tmp2,tmp3,mn,mx,delta,black,dL,flg);
  regional(dl1,dl2,dl3);
  if(src=="rgb" & dest=="hsv", dL=Colorrgbhsv(sL));
  if(src=="hsv" & dest=="rgb", dL=Colorhsvrgb(sL));
  if(src=="rgb" & dest=="hsl", dL=Colorrgbhsl(sL));
  if(src=="hsl" & dest=="rgb", dL=Colorhslrgb(sL));
  if(src=="rgb" & dest=="hwb", dL=Colorrgbhwb(sL));
  if(src=="hwb" & dest=="rgb", dL=Colorhwbrgb(sL));
  if(src=="hsl" & dest=="hsv", dL=Colorhslhsv(sL));
  if(src=="hsv" & dest=="hsl",
    dl1 = sL_1; 
    dl3 = (2 - sL_2) * sL_3;
    dl2 = sL_2 * sL_3;
    if(dl3 <= 1,dl2 = dl2/dl3,dl2=dl2/(2 - dl3));
    dl3 =d l3/ 2;
    dL = [dl1, dl2 , dl3 ];
  );

  if(src=="rgb" & dest=="cmyk",
    tmp=apply(sL,1-#);
    black=min(tmp);
    tmp=apply(sL,(1-#-black)/(1-black));
    dL=append(tmp,black);
  );
  if(src=="cmyk" & dest=="rgb",
    black=sL_4;
    tmp=apply(sL,1-min(1,#*(1-black)+black));
    dL=tmp_(1..3);
  );
  if(src=="hsv" & dest=="cmyk",
    tmp=Colorcode("hsv","rgb",sL);
    dL=Colorcode("rgb","cmyk",tmp);
  );
  if(src=="cmyk" & dest=="hsv",
    tmp=Colorcode("cmyk","rgb",sL);
    dL=Colorcode("rgb","hsv",tmp);
  );

  if(src=="hsv" & dest=="hwb",
    tmp = Colorcode("hsv","rgb",sL);
    dL = Colorcode("rgb","hwb",tmp);
  );
  if(src=="hwb" & dest=="hsv",
    tmp = Colorcode("hwb","rgb",sL);
    dL = Colorcode("rgb","hsv",tmp);
  );
  if(src=="hsl" & dest=="hwb",
    tmp = Colorcode("hsl","rgb",sL);
    dL = Colorcode("rgb","hwb",tmp);
  );
  if(src=="hwb" & dest=="hsl",
    tmp = Colorcode("hwb","rgb",sL);
    dL = Colorcode("rgb","hsl",tmp);
  );
  if(src=="hsl" & dest=="cmyk",
    tmp = Colorcode("hsl","rgb",sL);
    dL = Colorcode("rgb","cmyk",tmp);
  );
  if(src=="hwb" & dest=="cmyk",
    tmp = Colorcode("hwb","rgb",sL);
    dL = Colorcode("rgb","cmyk",tmp);
  );
  if(src=="cmyk" & dest=="hsl",
    tmp = Colorcode("cmyk","rgb",sL);
    dL = Colorcode("rgb","hsl",tmp);
  );
  if(src=="cmyk" & dest=="hwb",
    tmp = Colorcode("cmyk","rgb",sL);
    dL = Colorcode("rgb","hwb",tmp);
  );
  if(src=="hsb" & dest=="rgb",dL=Colorcode("hsv","rgb",sL));
  if(src=="rgb" & dest=="hsb",dL=Colorcode("rgb","hsv",sL));

  if(src=="hsb" & dest=="hsl",dL=Colorcode("hsv","hsl",sL));
  if(src=="hsl" & dest=="hsb",dL=Colorcode("hsl","hsv",sL));

  if(src=="hsb" & dest=="hwb",dL=Colorcode("hsv","hwb",sL));
  if(src=="hwb" & dest=="hsb",dL=Colorcode("hwb","hsv",sL));

  if(src=="hsb" & dest=="cmyk",dL=Colorcode("hsv","cmyk",sL));
  if(src=="cmyk" & dest=="hsb",dL=Colorcode("cmyk","hsv",sL));

  dL;
);

Addcolor(cmdorg,list):=(
//help:Addcolor("Plotdata('1','x^2','x',[])",[1,1,0]);
  regional(rgb,cmyk,cmd,tmp,tmp1,tmp2,tmp3,tmp4);
  cmd=replace(cmdorg,"'",Dq);
  if(length(list)==3,
    rgb=list;
    cmyk=Colorcode("rgb","cmyk",list);
  ,
    cmyk=list;
    rgb=Colorcode("cmyk","rgb",list);
  );
  tmp1="color->"+text(rgb);
  tmp2="Setcolor("+text(cmyk)+");";
  tmp3=substring(cmd,0,length(cmd)-2);
  tmp=substring(tmp3,length(tmp3)-1,length(tmp3));
  if(tmp!="[",
    tmp3=tmp3+",";
  );
  tmp3=tmp3+Dq+tmp1+Dq+"])";
  parse(tmp2);
  parse(tmp3);
  Setcolor("black");
);

Colorinfile(filename,clrf,clrt):=(
  regional(tmp,tmp1,tmp2,head,cstrL,chstrL,head,body);
  if(length(clrf_1)==3,
    head="[rgb]{";
  ,
    head="[cmyk]{";
  );
  tmp=apply(clrf,text(#));
  cstrL=apply(tmp,head+substring(#,1,length(#)-1)+"}");
  if(length(clrt_1)==3,
    head="[rgb]{";
  ,
    head="[cmyk]{";
  );
  tmp=apply(clrt,text(#));
  chstrL=apply(tmp,head+substring(#,1,length(#)-1)+"}");
  tmp1=load(filename);
  tmp=tokenize(tmp1,"{\unitlength");
  head=tokenize(tmp_1,"%%%");
  head=head_(2..(length(head)));
  head=apply(head,"%%%"+#);
  tmp2=tmp_2;
  forall(1..5,
    tmp2=replace(tmp2,cstrL_#,chstrL_#);
  );
  body=tokenize(tmp2,"%");
  body_1="{\unitlength"+body_1;
  body=apply(body,#+"%");
  body=body_(1..(length(body)-1));
  tmp=replace(filename,".tex","new.tex");
  SCEOUT=openfile(tmp);
  forall(head,
    println(SCEOUT,#);
  );
  forall(1..(length(body)),
    tmp=body_#;
    if(#<length(body),
      println(SCEOUT,tmp);
    ,
      print(SCEOUT,tmp)
    );
  );
  closefile(SCEOUT);
);

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
  if(tmp1=="dr" % tmp1=="Dr",
    Ltype=0;
    if(noflg==0 & subflg==0, // 16.02.29
      Drwline(name+Dop);
    );
  );
  if(tmp1=="da" % tmp1=="Da",
    Ltype=1;
    if(noflg==0 & subflg==0, // 16.02.29
      Dashline(name+Dop);
    );
  );
  if(tmp1=="id" % tmp1=="Id",
    Ltype=2;  // 15.11.09
    if(noflg==0 & subflg==0, // 16.02.29
      Invdashline(name+Dop);
    );
  );
  if(tmp1=="do" % tmp1=="Do",
    Ltype=3;
    if(noflg==0 & subflg==0, // 16.02.29
      Dottedline(name+Dop);
    );
  );
  if(tmp1=="dp" % tmp1=="Dp",
    Ltype=0;
    tmp1=parse(name);
    tmp2="";
    forall(tmp1,
      tmp2=tmp2+textformat(#_1,5)+",";
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
    tmp1=replace(tmp1,"[","list(");
  ,
    tmp1=substring(tmp1,0,length(tmp1)-1);
  );
  tmp1;
);

//AddGraph(pltdata):=AddGraph("-"+pltdata,pltdata,[]);
AddGraph(nm,pltdata):=AddGraph(nm,pltdata,[]);
//  if(isstring(Arg2),
//    AddGraph(Arg1,Arg2,[]);
//  ,
//    if(MeasureDepth(Arg2)>0,
//      Addgraph(Arg1,Arg2,[]);
//    ,
//      Addgraph("-"+Arg1,Arg1,Arg2);
//    );
//  );
//);
AddGraph(nm,pltdata,options):=(
//help:AddGraph("1","imp1"); // 16.04.04
//help:Addgraph("1",["[pt1]","gr1"],["nodisp"]);
  regional(name,Ltype,Noflg,opcindy,pdata,fname,flg,
    tmp,tmp1,tmp2,tmp3);
  if(substring(nm,0,1)=="-",
    name=substring(nm,1,length(nm));
  ,
    name="ad"+nm;
  );
  tmp=Divoptions(options);
  Ltype=tmp_1;
  Noflg=tmp_2;
  opcindy=tmp_9;
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
    tmp=name+"="+textformat(pdata,5);
    parse(tmp);
    if(isstring(pltdata), // 16.04.04 from
      if(indexof(pltdata,"]")>0,
        tmp1="list(Listplot("+substring(pltdata,1,length(pltdata));
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
      GLIST=append(GLIST,name+"="+tmp1);
    ,
      if(MeasureDepth(pdata)==1,
        tmp1=name+"=Listplot("+textformat(pdata,5)+")";
      ,
        tmp1="list(";
        forall(1..(length(pdata)),
          tmp=name+"p"+textformat(#,5)+"=";
          if(length(pdata_#)>1,  // 15.01.22
            tmp=tmp+"Listplot("+textformat(pdata_#,5)+")";
          ,
            tmp=tmp+"Pointdata("+textformat(pdata_#_1,5)+")";
          );
          GLIST=append(GLIST,tmp);
          tmp1=tmp1+name+"p"+textformat(#,5)+",";
        );
        tmp1=name+"="+substring(tmp1,0,length(tmp1)-1)+")";
      );
      GLIST=append(GLIST,tmp1);
    );
  );  // 16.04.04 upto
  if(Noflg<2,
    if(isstring(Ltype),
      Ltype=GetLinestyle(text(Noflg)+Ltype,name);
    ,
      if(Noflg==1,Ltype=0);
    );
    GCLIST=append(GCLIST,[name,Ltype,opcindy]);
  );
);

Joincrvs(nm,plotstrL):=Joincrvs(nm,plotstrL,[]);
Joincrvs(nm,plotstrL,options):=(
//help:Joincrvs("1",["sgAB","sgDCB"]);
  regional(plotlist,PtL,Eps,QdL,Flg,Ni,Qd,pP,pS,pQ,pR,rMN,
        opcindy,tmp,tmp1,tmp2,str,name,Ltype,Noflg);
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
    tmp=name+"="+textformat(tmp1,5);
    parse(tmp);
    tmp1="";
    forall(plotstrL,
        tmp1=tmp1+#+",";
    );
    tmp1=substring(tmp1,0,length(tmp1)-1);
    GLIST=append(GLIST,name+"=Joincrvs("+tmp1+")");
  );
  if(Noflg<2,
    if(isstring(Ltype),
      Ltype=GetLinestyle(text(Noflg)+Ltype,name);
    ,
      if(Noflg==1,Ltype=0);
    );
    GCLIST=append(GCLIST,[name,Ltype,opcindy]);
  );
  PtL;
);

Partcrv(nm,pA,pB,PkLstr):=Partcrv(nm,pA,pB,PkLstr,[]);
Partcrv(nm,pA,pB,PkLstr,options):=(
//help:Partcrv("1",A,B,"sgABC");
//help:Partcrv("1",1.3,2.5,"sgABC");
  regional(PkL,Ans,Eps,Npt,Out1,Out2,tmp,tmp1,Flg,nS,nE,PPL,pP,
        opcindy,Ta,Tb,name,Ltype,Noflg,DepthFlg);
  name="part"+nm;
  if(isstring(PkLstr),PkL=parse(PkLstr),PkL=PkLstr);
  DepthFlg=0;
  if(MeasureDepth(PkL)==2,
    PkL=PkL_1;
    DepthFlg=1;
  );
  PkL=apply(PkL,LLcrd(#));
  tmp=Divoptions(options);
  Ltype=tmp_1;
  Noflg=tmp_2;
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
    tmp=name+"="+textformat(tmp1,5);
    parse(tmp);
//    GLIST=append(GLIST,  // 16.04.03
    if(DepthFlg==0,
      tmp=PkLstr;
    ,
      tmp=PkLstr+"(1)";
    );
    tmp1=name+"=Partcrv("+textformat(Lcrd(pA),5)
	     +","+textformat(Lcrd(pB),5)+","+tmp+")"; // 16.04.03
    GLIST=append(GLIST,tmp1);
  );
  if(Noflg<2,
    if(isstring(Ltype),
      Ltype=GetLinestyle(text(Noflg)+Ltype,name);
    ,
      if(Noflg==1,Ltype=0);
    );
    GCLIST=append(GCLIST,[name,Ltype,opcindy]);
  );
  Ans;
);

Opcrvs(num,Fig):=Opcrvs(num,Fig,["nodisp"]);
Opcrvs(num,Fig,options):=(
  //help:Subgraph(2,"grfs");
  regional(name,tmp,tmp1);
  name="-"+Fig+text(num);
  tmp=Fig+"_"+text(num);
  tmp1=parse(tmp);
  Listplot(name,tmp1,options);
);


Pointdata(nm,list):=Pointdata(nm,list,[]);
Pointdata(nm,listorg,options):=(
//help:Pointdata("1",[2,4],["Size=5"]);
//help:Pointdata("2",[[2,3],[4,1]]);
  regional(list,name,nameL,ptlist,opstr,opcindy,
      eqL,size,thick,tmp,tmp1,tmp2,tmp3,Ltype,Noflg);
  name="pt"+nm;
  nameL=name+"L";
  println("generate pointdata "+name);
  tmp=Divoptions(options);
  Ltype=tmp_1;
  Noflg=tmp_2;
  opcindy=tmp_(length(tmp));
  opstr=tmp_(length(tmp)-1);
  size="";
  eqL=tmp_5;
  if(length(eqL)>0,
    forall(eqL,
      tmp=substring(#,0,1);
      if(tmp=="s" % tmp=="S",
        tmp=indexof(#,"=");
        size=substring(#,tmp,length(#));
      );
    );
  );
  if(isstring(listorg),list=parse(listorg),list=listorg); //17.10.23
  tmp=MeasureDepth(list);
  if(tmp>0,  // 2015.02.21
    if(tmp==1,ptlist=list,ptlist=list_1);
    tmp=apply(ptlist,[textformat(Pcrd(#),5)]);
    tmp1=text(tmp);
    tmp2=substring(tmp1,1,length(tmp1)-1);
    tmp3=tmp1;
  ,
    ptlist=list;
    tmp1=textformat(Pcrd(ptlist),5);
    tmp2=tmp1;
    tmp3="["+tmp1+"]";
  );
  tmp=name+"="+tmp1;
  parse(tmp);
  tmp=nameL+"="+tmp3;
  parse(tmp);
  if(Noflg<3,
    if(isstring(listorg), //17.10.23
      tmp2=listorg;
    ,
      tmp2="list("; //17.10.10from
      forall(list,
        if(isstring(#),
          tmp=#;
        ,
          if(ispoint(#),tmp=text(#),tmp=textformat(#,6));
        );
        tmp2=tmp2+tmp+",";
      );
      tmp2=substring(tmp2,0,length(tmp2)-1)+")"; //17.10.10upto
    );
    GLIST=append(GLIST,name+"=Pointdata("+tmp2+")");
  );
  if(Noflg<2,
    tmp=[nameL,0,opcindy];
    GCLIST=append(GCLIST,tmp);
    if(Noflg==0,
      if(length(size)>0,
        Com2nd("Setpt("+size+")");
      );
      thick=PenThick/PenThickInit;  // 16.04.09 from
      if(length(size)>0,tmp1=parse(size),tmp1=1);
      tmp1=max(tmp1,1)/8; 
      Setpen(tmp1); // 16.04.09 upto
      Com2nd("Drwpt(list("+name+")"+opstr+")");
      Setpen(thick); // 16.04.09
      if(length(size)>0,
        Com2nd("Setpt("+textformat(TenSize/TenSizeInit,1)+")");
      );
    );
  );
  ptlist;
);

Listplot(nm,list,options):=(
//help:Listplot([A,B]);
// help:Listplot(["A","B"]);
//help:Listplot("1",[[2,1],[3,3]]);
//help:Listplot(options2=["Msg=yes"]);
  regional(name,tmp,tmp1,ptlist,Ltype,opcindy,Noflg,eqL,Msg);
  if(substring(nm,0,1)=="-",  // 16.01.27 from
    name=substring(nm,1,length(nm));
  ,
    name="sg"+nm;
  ); // upto
  tmp=Divoptions(options);
  Ltype=tmp_1;
  Noflg=tmp_2;
  eqL=tmp_5;
  opcindy=tmp_(length(tmp));
  Msg=1;  // 15.09.17
  forall(eqL,
    tmp=substring(#,0,1);
    if(Toupper(tmp)=="M",
      tmp=indexof(#,"=");
      tmp1=substring(#,tmp,tmp+1); // 16.06.28
      if(Toupper(tmp1)=="N", // 16.06.28
        Msg=0;
      );
    );
  );
  if(Noflg<3,
    if(Msg==1,
      println("generate Listplot "+name);
    );
    if(isstring(list_1),tmp=apply(list,parse(#)),tmp=list); // 15.03.24
    ptlist=apply(tmp,Pcrd(#));
    tmp=name+"="+textformat(ptlist,5);
    parse(tmp);
    GLIST=append(GLIST,name+"=Listplot("+textformat(list,5)+")"); // 15.12.23
  );
  if(Noflg<2,
    if(isstring(Ltype),
      Ltype=GetLinestyle(text(Noflg)+Ltype,name);
    ,
      if(Noflg==1,Ltype=0);
    );
    GCLIST=append(GCLIST,[name,Ltype,opcindy]);
  );
  tmp1=apply(list,Lcrd(#));
  tmp1;
);
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
    );// 16.10.07upto
    Listplot(name,list,options);
  );
);
Listplot(list):=Listplot(list,[]);

Lineplot(nm,list,options):=(
//help:Lineplot([A,B]);
//help:Lineplot("1",[[2,1],[3,3]]);
  regional(name,Out,tmp,tmp1,opstr,opcindy,Mag,Semi,
      Vec,pA,pB,Ltype,Noflg);
  name="ln"+nm;
  Mag=100;
  Semi="";
  tmp=Divoptions(options);
  Ltype=tmp_1;
  Noflg=tmp_2;
  opcindy=tmp_(length(tmp));
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
    println("generate Lineplot "+name);
    tmp1=apply(Out,Pcrd(#));
    tmp=name+"="+textformat(tmp1,5);
    parse(tmp);
    GLIST=append(GLIST,name+"=Lineplot("+textformat(list,5)+opstr+")");
  );
  if(Noflg<2,
    if(isstring(Ltype),
      Ltype=GetLinestyle(text(Noflg)+Ltype,name);
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
    );// 16.10.07upto
    Lineplot(name,list,options);
  );
);
Lineplot(list):=Lineplot(list,[]);

Plotdata(name1,func,variable):=Plotdata(name1,func,variable,[]);
Plotdata(name1,func,variable,options):=(
//help:Plotdata("1","sin(x)","x",["Num=100"]);
//help:Plotdata("2","x^2","x=[-1,1]");
//help:Plotdata("3","Fout(x)","x",["out"]);
  regional(Fn,Va,tmp,tmp1,tmp2,eqL,name,Vname,x1,x2,dx,
         PdL,QdL,Num,Ec,Dc,Fun,Exfun,x,Ke,Eps,Pa,
         Ltype,Noflg,Inflg,Outflg,opstr,opcindy);
  name="gr"+name1;
  tmp=Divoptions(options);
  Ltype=tmp_1;
  Noflg=tmp_2;
  Inflg=tmp_3;
  Outflg=tmp_4;
  opstr=tmp_(length(tmp)-1);
  opcindy=tmp_(length(tmp));
  eqL=tmp_5;
  Num=50;
  Ec=[];
  Exfun="";
  Dc=1000;
  forall(eqL,
    tmp=indexof(#,"=");
    tmp1=substring(#,tmp,length(#));
    opstr=opstr+",'"+#+"'";
    if(substring(#,0,1)=="N",
      Num=parse(tmp1);
    );
    if(substring(#,0,1)=="E",
      if(substring(tmp1,0,1)=="[",
        Ec=parse(tmp1);
      ,
        Exfun=tmp1;
      );
    );
    if(substring(#,0,1)=="D",
      Dc=parse(tmp1);
    );
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
      xx=x1+#*(x2-x1)/Num; // differs from Scilab ( / Num-1)
      if(length(Exfun)>0,
        tmp=parse(Exfun);
        if(abs(tmp)<Eps,
          if(length(Pdt)>0,
            PdL=concat(PdL,["inf"]);
          );
        );
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
      println("generate Plotdata "+name);
      if(MeasureDepth(PdL)==1,
        tmp1=apply(PdL,Pcrd(#));
      ,
        tmp1=[];
        forall(PdL,tmp2,
          tmp1=append(tmp1,apply(tmp2,Pcrd(#)));
        );
      );
      tmp=name+"="+textformat(tmp1,5);
      parse(tmp);
      tmp1=replace(func,LFmark,"");
      tmp2=replace(variable,LFmark,"");
      tmp=name+"=Plotdata('"+tmp1+"','"+tmp2+"'"+opstr+")";
      GLIST=append(GLIST,tmp);
    );
    if(Noflg<2,
      if(isstring(Ltype),
        Ltype=GetLinestyle(text(Noflg)+Ltype,name);
      ,
        if(Noflg==1,Ltype=0);
      );
      GCLIST=append(GCLIST,[name,Ltype,opcindy]);
    );
    PdL;
  , 
    if(Noflg<2,
      if(isstring(Ltype),
        Ltype=GetLinestyle(text(Noflg)+Ltype,name);
      ,
        if(Noflg==1,Ltype=0);
      );
      if(Inflg==1,
        GCLIST=append(GCLIST,[name,Ltype,opcindy]);
      );
    );
  );
);

Paramplot(name1,funstr,variable):=Paramplot(name1,funstr,variable,[]);
Paramplot(name1,funstr,variable,options):=(
//help:Paramplot("1","[2*cos(t),sin(t)]","t=[0,2*pi]");
  regional(name,Out,tmp,tmp1,tmp2,vname,func,str,Rng,Num,
        Ec,Exfun,Dc,eqL,Fntmp,Vatmp,t1,t2,dt,tt,pa,ke,
        Ltype,Noflg,Inflg,Outflg,opstr,opcindy);
  name="gp"+name1; 
  Eps=10^(-4);
  tmp=Divoptions(options);
  Ltype=tmp_1;
  Noflg=tmp_2;
  Inflg=tmp_3;
  Outflg=tmp_4;
  opstr=tmp_(length(tmp)-1);
  opcindy=tmp_(length(tmp));
  eqL=tmp_5;
  Num=50;
  Ec=[];
  Exfun="";
  Dc=1000;
  forall(eqL,
    tmp=indexof(#,"=");
    tmp1=substring(#,tmp,length(#));
    opstr=opstr+",'"+#+"'";
    if(substring(#,0,1)=="N",
      Num=parse(tmp1);
    );
    if(substring(#,0,1)=="E",
      if(substring(tmp1,0,1)=="[",
        Ec=parse(tmp1);
      ,
        Exfun=tmp1;
      );
    );
    if(substring(#,0,1)=="D",
      Dc=parse(tmp1);
    );
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
                Out=append(Out,pa);
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
      println("generate Paramplot "+name);
      if(MeasureDepth(Out)==1,
        tmp1=apply(Out,Pcrd(#));
      ,
        tmp1=[];
        forall(Out,tmp2,
          tmp1=append(tmp1,apply(tmp2,Pcrd(#)));
        );
      );
      tmp=name+"="+textformat(tmp1,5);
      parse(tmp);
      tmp1=replace(funstr,LFmark,"");  // 15.11.13
      tmp2=replace(variable,LFmark,"");
      tmp=name+"=Paramplot('"+tmp1+"','"+tmp2+"'"+opstr+")";
      GLIST=append(GLIST,tmp);
    );
    if(Noflg<2,
      if(isstring(Ltype),
        Ltype=GetLinestyle(text(Noflg)+Ltype,name);
      ,
        if(Noflg==1,Ltype=0);
      );
      GCLIST=append(GCLIST,[name,Ltype,opcindy]);
    );
    Out;
  , 
    if(Noflg<2,
      if(isstring(Ltype),
        Ltype=GetLinestyle(text(Noflg)+Ltype,name);
      ,
        if(Noflg==1,Ltype=0);
      );
      if(Inflg==1,
        GCLIST=append(GCLIST,[name,Ltype,opcindy]);
      );
    );
  );
);

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
    );// 16.10.07upto
  );
  Circledata(name,cenrad,options);
);
Circledata(nm,cenrad,options):=(
  regional(name,Out,Ctr,Ptcir,ra,Num,Rg,opstr,opcindy,
      tmp,tmp1,tmp1,Th,Ltype,Noflg,eqL,pA,pB,pC,d1,d2,Eps);  
  name="cr"+nm;
  tmp=Divoptions(options);
  Ltype=tmp_1;
  Noflg=tmp_2;
  opstr=tmp_(length(tmp)-1);
  opcindy=tmp_(length(tmp));
  eqL=tmp_5;
  Num=50;
  Rg=[0,2*pi];
  forall(eqL,
    tmp=indexof(#,"=");
    tmp1=substring(#,tmp,length(#));
    opstr=opstr+",'"+#+"'";
    if(substring(#,0,1)=="N",
      Num=parse(tmp1);
    );
    if(substring(#,0,1)=="R",
      Rg=parse(tmp1);
    );
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
    println("generate Circledata "+name);
    tmp1=apply(Out,Pcrd(#));
    tmp=name+"="+textformat(tmp1,5);
    parse(tmp);
    if(length(cenrad)==2,
      tmp=name+"=Circledata("+cenrad+opstr+")";
    ,
      if(ra>0,
        tmp=name+"=Circledata(["+Ctr+","+cenrad_1+"]"+opstr+")";
      ,
        tmp=name+"=Lineplot("+cenrad_1+","+cenrad_2+")";
      );
    );
    GLIST=append(GLIST,tmp);
  );
  if(Noflg<2,
    if(isstring(Ltype),
      Ltype=GetLinestyle(text(Noflg)+Ltype,name);
    ,
      if(Noflg==1,Ltype=0);
    );
    GCLIST=append(GCLIST,[name,Ltype,opcindy]);
  );
  Out;
);

Framedata():=Framedata(["dr"]);//16.10.29from
Framedata(list):=(
  regional(pA,pB);
  if(MeasureDepth(list)==0,
    pA=LLcrd((SW+NE)/2); // 15.09.17
    pB=LLcrd(NE);
    Framedata("win",[pA,pB],list);
  ,
    Framedata(list,[]);
  );
);//16.10.29upto
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
    );// 16.10.07upto
    Framedata(name,list,options);
  );
);
Framedata(nm,list,options):=(
//help:Framedata();
//help:Framedata([C,A]);
//help:Framedata("1",[C,A]);
//help:Framedata("1",[C,dx,dy]);
  regional(name,Out,tmp,tmp1,pB,x1,x2,y1,y2,dx,dy,
      opcindy,Ltype,Noflg,cent,dx,dy);
  name="fr"+nm;
  tmp=Divoptions(options);
  Ltype=tmp_1;
  Noflg=tmp_2;
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
    tmp=name+"="+textformat(tmp1,5);
    parse(tmp);
    GLIST=append(GLIST,name+"=Framedata("+pA+","+dx+","+dy+")");
  );
  if(Noflg<2,
    if(isstring(Ltype),
      Ltype=GetLinestyle(text(Noflg)+Ltype,name);
    ,
      if(Noflg==1,Ltype=0);
    );
    GCLIST=append(GCLIST,[name,Ltype,opcindy]);
  );
  Out;
);
Framedata(nm,cent,dx,dy):=Framedata(nm,cent,dx,dy,[]);
Framedata(nm,cent,dx,dy,options):=(
  regional(name,Out,tmp,tmp1,x1,y1,x2,y2,Ltype,opcindy,Noflg);
  name="fr"+nm;
  tmp=Divoptions(options);
  Ltype=tmp_1;
  Noflg=tmp_2;
  opcindy=tmp_(length(tmp));
  x1=cent.x-dx; x2=cent.x+dx;
  y1=cent.y-dy; y2=cent.y+dy;
  Out=[[x1,y1],[x2,y1],[x2,y2],[x1,y2],[x1,y1]];
  if(Noflg<3,
    println("generate Framedata "+name);
    tmp1=apply(Out,Pcrd(#));
    tmp=name+"="+textformat(tmp1,5);
    parse(tmp);
    GLIST=append(GLIST,name+"=Framedata("+cent.xy+","+dx+","+dy+")");
  );
  if(Noflg<2,
    if(isstring(Ltype),
      Ltype=GetLinestyle(text(Noflg)+Ltype,name);
    ,
      if(Noflg==1,Ltype=0);
    );
    GCLIST=append(GCLIST,[name,Ltype,opcindy]);
  );
  Out;
);

Framedata2(nm,list):=Framedata2(nm,list,[]);
Framedata2(nm,list,options):=(
//help:Framedata2("1",[A,B]);
  regional(tmp,tmp1,pC,pB);
  pC=(Lcrd(list_1)+Lcrd(list_2))/2;
  pB=Lcrd(list_2);
  Framedata(nm,[pC,pB],options);
);

Ovaldata(nm,Pdata):=Ovaldata(nm,Pdata,[]);
Ovaldata(nm,Pdata,options):=(
//help:Ovaldata("1",[A,B]);
//help:Ovaldata(optios=[size]);
  regional(name,Graph,Ctr,Dx,Dy,Rc,Out,Point,Graph,
      opstr,opcindy,tmp,tmp1,tmp2,tmp3,Ltype,Noflg);  
  name="ov"+nm;
  tmp=Divoptions(options);
  Ltype=tmp_1;
  Noflg=tmp_2;
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
  tmp1=Circledata("1",[Point,Point+[Rc,0]],
     ["Rng=[0,pi/2]","Num=10","nodata"]);
  tmp2=Listplot("1",[Ctr+[Dx-Rc,Dy],Ctr+[0,Dy]],
     ["nodata"]);
  tmp3=Listplot("2",[Ctr+[Dx,0],Ctr+[Dx,Dy-Rc]],
     ["nodata"]);
  Graph=Joincrvs("1",[tmp3,tmp1,tmp2],["nodata"]);
  tmp1=Reflectdata("1",[Graph],[Ctr,Ctr+[0,1]],["nodata"]);
  Graph=Joincrvs("1",[Graph,tmp1],["nodata"]);
  tmp2=Reflectdata("2",[Graph],[Ctr,Ctr+[1,0]],
     ["nodata"]);
  Graph=Joincrvs("2",[Graph,tmp2],["nodata"]);
  if(Noflg<3,
    println("generate Ovaldata "+name);
    tmp1=apply(Graph,Pcrd(#));
    tmp=name+"="+textformat(tmp1,5);
    parse(tmp);
    GLIST=append(GLIST,
	  name+"=Ovaldata("+Ctr+","+Dx+","+Dy+opstr+")");//16.01.30
  );
  if(Noflg<2,
    if(isstring(Ltype),
      Ltype=GetLinestyle(text(Noflg)+Ltype,name);
    ,
      if(Noflg==1,Ltype=0);
    );
    GCLIST=append(GCLIST,[name,Ltype,opcindy]);
    tmp1=apply(Graph,Pcrd(#));
    tmp=name+"="+textformat(tmp1,5);
    parse(tmp);
    tmp=textformat(Ctr,5)+","+textformat(Dx,5)+","+textformat(Dy,5);
  );
  Graph;
);

Segmark(nm,ptlist):=Segmark(nm,ptlist,[]);
Segmark(nm,ptlist,options):=Drawsegmark(nm,ptlist,options);
Drawsegmark(nm,ptlist):=Drawsegmark(nm,ptlist,[]);
Drawsegmark(nm,ptlist,options):=(
//help:Segmark("1",[A,B]);
//help:Segmark(options=["Type=1","Width=1","Size=1"]);
  regional(name,pA,pB,wid,mid,size,tp,dir,nor,eqL,
      tmp,tmp1,tmp2);
  name="mrk"+nm;
  pA=ptlist_1;
  pB=ptlist_2;
  size=0.15;
  wid=0.05;
  tp=1;
  tmp1=Divoptions(options);
  eqL=tmp1_5;
  forall(eqL,
    tmp=indexof(#,"=");
    tmp1=substring(#,tmp,length(#));
    tmp1=parse(tmp1);
    tmp=substring(#,0,1);
    if(tmp=="S" % tmp=="s",
      size=size*tmp1;
    );
    if(tmp=="W" % tmp=="w",
      wid=wid*tmp1;
    );
    if(tmp=="T" % tmp=="t",
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
    Listplot(name,[tmp1,tmp2]);
  );
  if(tp==2,
    tmp1=mid+wid*dir+size*nor;
    tmp2=mid+wid*dir-size*nor;
    Listplot(name+"r",[tmp1,tmp2]);
    tmp1=mid-wid*dir+size*nor;
    tmp2=mid-wid*dir-size*nor;
    Listplot(name+"l",[tmp1,tmp2]);
  );
  if(tp==3,
    tmp1=mid;
    tmp2=mid+size*dir;
    Circledata(name,[tmp1,tmp2]);
  );
  if(tp==4,
    tmp=mid+size*2/sqrt(3)*nor;
    tmp1=mid+size*dir-size/sqrt(3)*nor;
    tmp2=mid-size*dir-size/sqrt(3)*nor;
    Listplot(name,[tmp,tmp1,tmp2,tmp]);
  );
);

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
  tmp2="x="+textformat(tmp1,5);
  Plotdata(nm+"para",tmp,tmp2,append(options,"nodisp"));
  Rotatedata(nm+"para","gr"+nm+"para",angle,append(options,pB));
);

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
  tmp=["gp"+nm+"hyp1","gp"+nm+"hyp2"];
  Rotatedata(nm+"hyp",tmp,angle,append(options,pA));
  if(length(opasy)>0,
    Lineplot(nm+"asy1",[pM+[a,b],pM+[-a,-b]],["nodisp"]);
    Lineplot(nm+"asy2",[pM+[-a,b],pM+[a,-b]],["nodisp"]);
    tmp=["ln"+nm+"asy1","ln"+nm+"asy2"];
    Rotatedata(nm+"asy",tmp,angle,append(opasy,pA));
  );
);

Polygonplot(nm,ptlist,number):=Polygonplot(nm,ptlist,number,[]);
Polygonplot(nm,ptlist,number,options):=(
//help:Polygonplot("1",[A,B],12);
  regional(rr,pA,pB,ptL,angle,tmp,tmp1,tmp2);
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
     Putpoint((ptlist_2).name+text(#),tmp1);//16.10.07
     //Pointdata(nm,ptL);
    );
    tmp2=tmp1;
    ptL=append(ptL,tmp1);
  );
  Listplot(nm+"ply",ptL,options);
);

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

Arrowheaddata(point,direction):=Arrowheaddata(point,direction,[]);
Arrowheaddata(point,direction,options):=(
//help:Arrowheaddata(A,B);
  regional(list,Ookisa,Hiraki,Futosa,Houkou,Str,Flg,tmp,Ev,Nv,pA,pB,
       pP,rF,gG,Flg,Nj,Eps,tmp1,scx,scy);
  Eps=10^(-3);
  pP=point;
  Ookisa=0.2*YaSize;
  Hiraki=YaAngle;
  Futosa=0;
  Str=YaStyle;
  tmp=Divoptions(options);
  tmp1=tmp_6;
  if(length(tmp1)>0,Ookisa=Ookisa*tmp1_1);
  if(length(tmp1)>1,
    tmp=tmp1_2;
    if(tmp<5, 
      Hiraki=Hiraki*tmp;
    ,
      Hiraki=tmp;
    );
  );
  Flg=0;
  Hiraki=Hiraki*pi/180;
  if(isstring(direction),Houkou=parse(direction),Houkou=direction);
  if(MeasureDepth(Houkou)==2,Houkou=Houkou_1);
  if(islist(Houkou_1),
//    pP=Lcrd(pP);
//    pP=Doscaling(pP);
//    Houkou=Dosscaling(Houkou);
    pP=Pcrd(pP);
	scy=SCALEY;
    SCALEY=1;
    tmp=Nearestpt(pP,Houkou);
    pA=tmp_1;
    rF=floor(tmp_2);
    if(rF==1,
      if(|Ptend(Houkou)-Ptstart(Houkou)|<Eps,
        rF=Numptcrv(Houkou);
      );
    );
    gG=apply(0..10,pP+Ookisa*cos(Hiraki)*[cos(2*pi/10*#),sin(2*pi/10*#)]);
	Flg=0; 
    forall(1..rF,Nj,
      if(Flg==0,
        pB=Ptcrv(rF+1-Nj,Houkou);
        tmp=IntersectcrvsPp([pA,pB],gG);
        if(length(tmp)>0,
          Houkou=pP-tmp_1_1;
          Flg=1;
        );
        pA=pB;
      );
    );
	SCALEY=scy;
    if(Flg==0,
      println("Arrowhead may be too large (no intersect)");
      Flg=2;
    );
    if(Flg==1,
      Houkou=Unscaling(Houkou);
      pP=Unscaling(pP);
    );
  );
  if(Flg<2,
//    pP=Doscaling(pP);
//    Houkou=Doscaling(Houkou);
    pP=Pcrd(pP);
    if(!ispoint(point),
      Houkou=Pcrd(Houkou);
    );
//    if(MeasureDepth(Houkou)==0,Houkou=Pcrd(Houkou));
    Ev=-1/|Houkou|*Houkou;
    Ev=Lcrd(Ev);
    Nv=[-Ev_2, Ev_1];
    if(indexof(Str,"c")>0,
      pP=pP-0.5*Ookisa*cos(Hiraki)*Ev;
    );
    if(indexof(Str,"b")>0,
      pP=pP-Ookisa*cos(Hiraki)*Ev;
    );
    pA=pP+Ookisa*cos(Hiraki)*Ev+Ookisa*sin(Hiraki)*Nv;
    pB=pP+Ookisa*cos(Hiraki)*Ev-Ookisa*sin(Hiraki)*Nv;
    list=[pA,pP,pB];
    list=apply(list,LLcrd(#));
//  Out=Unscaling(Out);
    list;
  );
);

Arrowhead(point,Houkou):=Arrowhead(point,Houkou,[]);
Arrowhead(point,Houkou,options):=(
//help:Arrowhead(B,B-A,[1.5,30]);
//help:Arrowhead(A,"gr1");
  // global ArrowheadNumber
  regional(name,Ltype,Noflg,reL,opstr,opcindy,ptstr,hostr,tmp,tmp1,list);
  name="arh"+text(ArrowheadNumber);
  ArrowheadNumber=ArrowheadNumber+1;
  ptstr=textformat(point,5);
  if(isstring(Houkou),  // 15.01.11
    tmp=parse(Houkou);
    if(MeasureDepth(tmp)<2,
      hostr=Houkou;
    ,
      hostr=Houkou+"(1)";
    );
  ,
    if(ispoint(point),
      hostr=textformat(LLcrd(Houkou),5);
    ,
      hostr=textformat(Houkou,5);
    );
  );
  tmp=Divoptions(options);
  Ltype=tmp_1;
  Noflg=tmp_2;
  reL=tmp_6;
  opstr=tmp_(length(tmp)-1);
  opcindy=tmp_(length(tmp));
  list=Arrowheaddata(point,Houkou,options);
  if(Noflg<3,
//    println("generate Arrowhead "+name);
    tmp1=apply(list,Pcrd(#));
    tmp=name+"="+textformat(tmp1,5);
    parse(tmp);
//	  GLIST=append(GLIST,name+"=Listplot("+list+")");
  );
  if(Noflg<2,
    if(isstring(Ltype),
      Ltype=GetLinestyle(text(1)+Ltype,name);
    ,
//	  if(Noflg==1,Ltype=0);
      Ltype=0;
    );
    GCLIST=append(GCLIST,[name,Ltype,opcindy]);
  );
  if(Noflg==0,
    if(length(reL)<3,  // 16.04.09 from
      forall(1..(2-length(reL)),
        opstr=opstr+",1";
      );
      tmp=PenThick/PenThickInit;
      opstr=opstr+","+text(tmp);
    );  // 16.04.09 upto
	Com2nd("Arrowhead("+ptstr+","+hostr+opstr+")");   
  );
);

Arrowdata(ptlist):=Arrowdata(ptlist,[]);
Arrowdata(Arg1,Arg2):=(
  regional(tmp,nm,ptlist,flg,pA,pB,options);
  flg=0;
  if(isstring(Arg1),
    nm=Arg1;
    ptlist=Arg2;
    Arrowdata(nm,ptlist,[]);
    flg=1;
  );
  if(flg==0,
    tmp=MeasureDepth(Arg1);
    if(tmp==0,
      pA=Arg1;
      pB=Arg2;
      Arrowdata(pA,pB,[]);
    ,
      ptlist=Arg1;
      options=Arg2;
      nm=text(ArrowlineNumber);
      ArrowlineNumber=ArrowlineNumber+1;
      Arrowdata(nm,ptlist,options);
    );
  );
);
Arrowdata(Arg1,Arg2,options):=(
//help:Arrowdata([A,B],[2,10]);
  regional(Retflg,nm,ptlist,name,opstr,opcindy,realL,strL,size,
      flg,Ltype,Noflg,lineflg,tmp,tmp1,tmp2,pA,pB,segpos);
  Retflg=0;
  Noflg=0;
  Ltype=0;
  if(!isstring(Arg1),
    pA=Arg1;
    pB=Arg2;
    Arrowdata(pA,pB,options,"old");
    Retflg=1;
    ptlist=[pA,pB];
  );
  if(Retflg==0,
    nm=Arg1;
    ptlist=Arg2;
    name="ar"+nm;
    tmp=Divoptions(options);
    Ltype=tmp_1;
    Noflg=tmp_2;
    realL=tmp_6;
    strL=tmp_7;
    opstr=tmp_(length(tmp)-1);
    opcindy=tmp_(length(tmp));
    size=1;  // 15.06.11
    if(length(realL)>0,
      size=realL_1;
    );
    tmp2=select(strL,indexof(#,"l")>0); // 16.04.09
    if(length(tmp2)>0,lineflg=1,lineflg=0); // 16.04.09
    segpos=1;
    tmp1=tmp_5;
    if(length(tmp1)>2,
      segpos=tmp1_3;
    );
    if(Noflg<3,
//      println("generate Arrowdata "+name);
      tmp1=apply(ptlist,Pcrd(#));
      tmp=name+"="+textformat(tmp1,5);
      parse(tmp);
      tmp1=Pcrd(ptlist_1);//16.10.20
      tmp2=Pcrd(ptlist_2);//16.10.20
      if(lineflg==0, // 16.04.09 from
        tmp=tmp2-0.2*size/2*(tmp2-tmp1)/|tmp2-tmp1|;   // 15.06.11
      ,
        tmp=tmp2;
      );  // 16.04.09 upto
      tmp=[LLcrd(tmp1),LLcrd(tmp)];//16.10.20
      GLIST=append(GLIST,name+"=Listplot("+textformat(tmp,5)+")");
    );
    if(Noflg<2,
      if(isstring(Ltype),
        Ltype=GetLinestyle(text(Noflg)+Ltype,name);
      ,
        if(Noflg==1,Ltype=0);
      );
      tmp=textformat(ptlist,5);
      tmp=substring(tmp,1,length(tmp)-1);
      tmp1=indexof(tmp,"],[");
      if(tmp1>0,
        pA=substring(tmp,0,tmp1);
        pB=substring(tmp,tmp1+1,length(tmp));
      ,
        tmp1=indexof(tmp,",");
        pA=substring(tmp,0,tmp1-1);
        pB=substring(tmp,tmp1,length(tmp));
      );
      tmp1="Lcrd("+pA+")+"
	      +textformat(segpos,5)+"*(Lcrd("+pB+")-"+"Lcrd("+pA+"))";
      tmp1=parse(tmp1);
      tmp2="Lcrd("+pB+")-Lcrd("+pA+")";
      tmp2=parse(tmp2);
	  Arrowhead(tmp1,tmp2,options);
      GCLIST=append(GCLIST,[name,Ltype,opcindy]);
    );
  );
  ptlist;
);
Arrowdata(pA,pB,options,str):=(
  regional(ptA,ptB,opstr,Astr,Bstr,name,tmp,opcindy);
  Astr=textformat(pA,5);
  Bstr=textformat(pB,5);  
  name="ar"+pA.name+pB.name;
  println("generate Arrow "+name);
  opstr="";
  opcindy="";
  forall(options,
    if(isstring(#),
      if(indexof(#,"->")>0,
        opcindy=opcindy+","+#;
      ,
        tmp="'"+#+"'";
      );
    ,
      tmp=text(#);
    );
    opstr=opstr+","+tmp;
  );
  ptA=Lcrd(pA);
  ptB=Lcrd(pB);
  Arrowheaddata(ptB,ptB-ptA,options);
  tmp="connect("+textformat([ptA,ptB],5)
     +",linecolor->"+text(KCOLOR)+opcindy+");";
  parse(tmp);  // 14.11.17
  Com2nd("Arrowline("+Astr+","+Bstr+opstr+")"); // 14.10.04
);

Anglemark(plist):=Anglemark(plist,[]);
Anglemark(Arg1,Arg2):=(           // 2015.04.28 from
  regional(nm,plist,options,tmp);
  if(isstring(Arg1),
    nm=Arg1;
    plist=Arg2;
    Anglemark(nm,plist,[]);
  ,
    plist=Arg1;
    options=Arg2;
    tmp=textformat(plist,5);
    tmp=replace(tmp,",","");
    nm=substring(tmp,1,length(tmp)-1);
    Anglemark(nm,plist,options);
  );
);                    // upto
Anglemark(nm,plist,options):=(
//help:Anglemark([A,B,C],["E=\theta",2]);
//help:Anglemark("1",[A,B,C],["E=1.2,\theta",2]);
//help:Anglemark(options=["E/L=(sep,)letter",size]);
  regional(name,Out,pB,pA,pC,Ctr,ra,sab,sac,ratio,opstr,Bname,Bpos,
       Brat,tmp,tmp1,tmp2,Num,opcindy,Ltype,eqL,realL,Rg,Th,Noflg);
  name="ag"+nm;
  Bpos="md"+name;
  ra=0.5;
  tmp=Divoptions(options);
  Ltype=tmp_1;
  Noflg=tmp_2;
  opstr=tmp_(length(tmp)-1);
  opcindy=tmp_(length(tmp));
  eqL=tmp_5;
  realL=tmp_6;
  Bname="";
  Brat=1.5;
  Num=20;
  if(length(realL)>0,
    ra=realL_1*ra;
    opstr=opstr+","+text(realL_1);
  );
  forall(eqL,
    if(substring(#,0,1)=="L",Bname="Letter(");
    if(substring(#,0,1)=="E",Bname="Expr(");
    Bname=Bname+Bpos+","+Dq+"c"+Dq+","+Dq;//16.10.29
    tmp=substring(#,indexof(#,"="),length(#));
    tmp1=indexof(tmp,",");
    Bname=Bname+substring(tmp,tmp1,length(tmp))+Dq+")";
    if(tmp1>0,
      Brat=parse(substring(tmp,0,tmp1-1));
    );
  );
  pB=Lcrd(plist_1); pA=Lcrd(plist_2); pC=Lcrd(plist_3);
  Ctr=Lcrd(pA);
  sab=pB-pA;
  sac=pC-pA;
  Rg=[arctan2(sab)+0,arctan2(sac)+0];
  if(Rg_2<Rg_1,Rg_2=Rg_2+2*pi);
  Out=[];
  if(ra>min(|sab|,|sac|),  // 16.12.29
    println("  segments too short");
  ,
    forall(0..Num,
      Th=Rg_1+#*(Rg_2-Rg_1)/Num;
      Out=append(Out,Ctr+ra*[cos(Th),sin(Th)]);
    );
    Th=(Rg_1+Rg_2)/2; //16.10.31from(moved)
    tmp1=Ctr+Brat*ra*[cos(Th),sin(Th)];
    tmp="Defvar("+Dq+Bpos+"=";
    tmp=tmp+textformat(tmp1,5)+Dq+");";
    parse(tmp);//16.10.31upto(moved)
    if(length(Bname)>0,
      parse(Bname);
    );
    if(Noflg<3,
      println("generate anglemark "+name+" and "+Bpos);
      tmp1=apply(Out,Pcrd(#));
      tmp=name+"="+textformat(tmp1,5);
      parse(tmp);
      tmp=textformat(plist,5);
      tmp1=substring(tmp,1,length(tmp)-1);
      tmp=name+"=Anglemark("+tmp1+opstr+")";
      GLIST=append(GLIST,tmp);
    );
    if(Noflg<2,
      if(isstring(Ltype),
        Ltype=GetLinestyle(text(Noflg)+Ltype,name);
      ,
        if(Noflg==1,Ltype=0);
      );
      GCLIST=append(GCLIST,[name,Ltype,opcindy]);
    );
  );
  Out;
);

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
    tmp=textformat(plist,5);
    tmp=replace(tmp,",","");
    nm=substring(tmp,1,length(tmp)-1);
    Paramark(nm,plist,options);
  );
);// upto
Paramark(nm,plist,options):=(
//help:Paramark([A,B,C],["E=\theta"]);
//help:Paramark("1",[p1,p2,p3],["E=\theta"]);
  regional(name,Out,pB,pA,pC,ra,sab,sac,ratio,opstr,Bname,Bpos,
         Brat,tmp,tmp1,tmp2,Ltype,Noflg,eqL,realL,opcindy);
  name="pm"+nm;
  tmp=Divoptions(options);
  Ltype=tmp_1;
  Noflg=tmp_2;
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
    Bname=Bname+Dq+Bpos+Dq+","+Dq+"c"+Dq+","+Dq;
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
    tmp="Defvar("+Dq+Bpos+"="+textformat(tmp1,5)+Dq+");";
    parse(tmp);
	parse(Bname);
  );
  if(Noflg<3,
    println("generate paramark "+name);
    tmp1=apply(Out,Pcrd(#));
    tmp=name+"="+textformat(tmp1,5);
    parse(tmp);
    tmp1=substring(textformat(plist,5),1,length(textformat(plist,5))-1);
    tmp=name+"=Paramark("+tmp1+opstr+")";
    GLIST=append(GLIST,tmp);
  );
  if(Noflg<2,
    if(isstring(Ltype),
      Ltype=GetLinestyle(text(Noflg)+Ltype,name);
    ,
      if(Noflg==1,Ltype=0);
    );
    GCLIST=append(GCLIST,[name,Ltype,opcindy]);
  );
  Out;
);

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

Bowdata(plist):=Bowdata(plist,[]);
Bowdata(plist,options):=(
  regional(nm,tmp);
  if(islist(plist), // 16.12.04from
    tmp=textformat(plist,5);
    tmp=replace(tmp,",","");
    nm=substring(tmp,1,length(tmp)-1);
    Bowdata(nm,plist,options);
  ,
    nm=plist;
    tmp=options;
    Bowdata(nm,tmp,[]);
  ); // 16.12.04upto
);
Bowdata(nm,plist,options):=(
//help:Bowdata([C,A],[2,1.2,"Expr=10","da"]);
//help:Bowdata([A,B],["Expr=t0n3,a"]);
//help:Bowdata([A,B],["Exprrot=t0n2r,a"]);
  regional(name,Out,pB,pA,pC,ra,tmp,tmp1,tmp2,Ltype,eqL,realL,
    Bname,Bpos,Th,Cut,Num,Hgt,opstr,opcindy,Ydata,pC,
    Th1,Th2,Noflg,Bops,Bmov,Tmov,Nmov,rev);
  name="bw"+nm;
  tmp=Divoptions(options);
  Ltype=tmp_1;
  Noflg=tmp_2;
  opstr=tmp_(length(tmp)-1);
  opcindy=tmp_(length(tmp));
  eqL=tmp_5;
  realL=tmp_6;
  pA=Lcrd(plist_1); pB=Lcrd(plist_2);
  Hgt=1/2*|pB-pA|*0.2;
  Cut=0;
  Num=24;
  Bname="";
  Tmov=0;//16.11.01from
  Nmov=0;
  Bmov="";
  rev=0;//16.11.01upto
  if(length(realL)>0,
    Hgt=realL_1*Hgt; // 15.04.12
    if(length(realL)>1,Cut=realL_2);
  );
  forall(eqL,
    tmp=substring(#,0,1);
    if(tmp=="L" % tmp=="l",
      if(indexof(#,"rot")>0,
        Bname="Letterrot(";
      ,
        Bname="Letter(";
      );
    );
    if(tmp=="E" % tmp=="e",
      if(indexof(#,"rot")>0,
        Bname="Exprrot(";
      ,
        Bname="Expr(";
      );
    );
    tmp=indexof(#,"=");
    Bops=substring(#,tmp,length(#)); // 16.11.01
  );
  Ydata=MakeBowdata(pA,pB,Hgt); 
  pC=Ydata_1;
  ra=Ydata_2;
  Th=(Ydata_3+Ydata_4)*0.5;
  BOWMIDDLE=[pC_1+ra*cos(Th),pC_2+ra*sin(Th)];
  Bpos="md"+name; // 16.10.31from(moved)
  tmp="Defvar("+Dq+Bpos+"="+textformat(BOWMIDDLE,5)+Dq+");";
  parse(tmp);// 16.10.31upto(moved)
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
      tmp1=1/norm(tmp)*tmp;
      tmp2=[-tmp1_2,tmp1_1];
      tmp=MARKLEN*(Tmov*tmp1+Nmov*tmp2);
      tmp=LLcrd(tmp);
      Bname=Bname+"+"+text(tmp);
    );
    Bname=Bname+",";
    if(indexof(Bname,"rot")>0,
      if(rev==1,tmp=pB-pA,tmp=pA-pB);
      Bname=Bname+textformat(tmp,5)+",";
    ,
      Bname=Bname+Dq+"c"+Dq+",";
    );
    Bname=Bname+Dq+Bops+Dq+")";
    parse(Bname);
  );//16.11.01upto
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
    println("generate bowdata "+name+" and "+Bpos);//16.10.31
    if(MeasureDepth(Out)==1,Out=[Out]);
	tmp1=[];
    forall(Out,tmp2,
      tmp=apply(tmp2,Pcrd(#));
      tmp1=append(tmp1,tmp);
    );
    tmp=name+"="+textformat(tmp1,5);
    parse(tmp);
    tmp1=substring(textformat(plist,5),1,length(textformat(plist,5))-1);
    tmp=name+"=Bowdata("+tmp1+opstr+")";
    GLIST=append(GLIST,tmp);
  );
  if(Noflg<2,
    if(isstring(Ltype),
      Ltype=GetLinestyle(text(Noflg)+Ltype,name);
    ,
      if(Noflg==1,Ltype=0);
    );
    GCLIST=append(GCLIST,[name,Ltype,opcindy]);
  );
);

Bowname(str):=Bowname("c",str);
Bowname(dir,str):=(
  Expr([BOWMIDDLE,dir,str]);
);

Bownamerot(bwdata,str):=Bownamerot(bwdata,0,0,str,1);
Bownamerot(bwdata,str,updown):=Bownamerot(bwdata,0,0,str,updown);
Bownamerot(bwdata,tmov,nmov,str):=Bownamerot(bwdata,tmov,nmov,str,1);
Bownamerot(bwdata,tmov,nmov,str,updown):=(
  regional(bdata,tmp);
  tmp=MeasureDepth(bwdata);
  if(tmp==1,bdata=[bwdata],bdata=bwdata);
  if(length(bdata)>1,
    tmp=Ptend(bdata_2)-Ptstart(bdata_1);
  ,
    tmp=Ptend(bdata_1)-Ptstart(bdata_1);
  );
  if(updown<0,tmp=-tmp);
  Exprrot(BOWMIDDLE,tmp,tmov,nmov,str);
);

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
//help:Deqplot("2","y`=y*(1-y)","x",0, 0.5,["Num=100"]);
//help:Deqplot("1","y``=-y","x",0, [1,0]);
//help:Deqplot("3","[x,y]`=[x*(1-y),0.3*y*(x-1)]","t=[0,20]",0,[1,0.5]);
  regional(deq,rng,Ltype,Noflg,eqL,opcindy,Num,name,nn,pdL,phase,
                  sel,tmp,tmp1,tmp2);
  name="de"+nm;
  tmp=Divoptions(options);
  Ltype=tmp_1;
  Noflg=tmp_2;
  eqL=tmp_5;
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
    rng=rng+"="+textformat([XMIN,XMAX],6);
  );
  deq=deqorg;
  tmp=indexof(deq,"=");
  tmp1=substring(deq,0,tmp-1);
  if(indexof(tmp1,"[")==0,
    phase=0;
    sel=[1,2];
  ,
    phase=1;
    sel=[2,3];
  );
  tmp2=substring(deq,tmp,length(deq));
  nn=length(Indexall(tmp1,"`"));
  if(nn==1,
    if(indexof(tmp1,"[")==0,
      tmp1="["+replace(tmp1,"`","]`");
      deq=tmp1+"="+tmp2;
    );
  ,
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
  if(Noflg<3,
    pdL=deqdata(deq,rng,initt,initf,Num);
    if(phase==1,
      pdL=apply(pdL,#_(2..3));
    );
    tmp1=apply(pdL,Pcrd(#));
    tmp=name+"="+textformat(tmp1,5);
    parse(tmp);
  );
  if(Noflg<1,
    tmp=Assign(deq);
    tmp=replace(deq,"'","`");
    tmp=name+"=Deqplot('"+tmp+"','"+rng+"',";
    tmp=tmp+format(initt,6)+","+textformat(initf,6);
    tmp=tmp+","+text(sel)+",'Num="+text(Num)+"')";
    tmp=RSform(tmp);
    GLIST=append(GLIST,tmp);
  );
  if(Noflg<2,
    if(isstring(Ltype),
      Ltype=GetLinestyle(text(Noflg)+Ltype,name);
    ,
      if(Noflg==1,Ltype=0);
    );
    GCLIST=append(GCLIST,[name,Ltype,opcindy]);
  );
);

Enclosing(nm,plist):=EnclosingS(nm,plist);
Enclosing(nm,plist,options):=EnclosingS(nm,plist,options);
EnclosingS(nm,plist):=EnclosingS(nm,plist,[]);
EnclosingS(nm,plist,options):=(
//help:Enclosing("1",["sc2","crAB","sc2","Invert(sc1)"],[pt,"dr"]);
  regional(name,AnsL,Start,Eps,EEps,S,Flg,Fdata,Gdata,KL,pt,qt,
      t1,t2,t3,ii,nn,tmp,tmp1,tmp2,Ltype,Noflg,realL,eqL,opstr,opcindy);
  name="en"+nm;
  tmp=Divoptions(options);
  Ltype=tmp_1;
  Noflg=tmp_2;
  eqL=tmp_5;
  realL=tmp_6;
  opstr=tmp_(length(tmp)-1);
  opcindy=tmp_(length(tmp));
  Eps=10^(-5); // 16.12.05
  EEps=0.05;
  Start=[];
  Flg=0;
  forall(realL,
    if(isList(#) % ispoint(#),
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
      tmp=|pt-Start|;
      forall(2..(length(KL)),ii, // 15.04.20
        tmp1=KL_ii_1;
        tmp2=|tmp1-Start|; // 15.04.20
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
          tmp2=ParamonCurve(tmp1,tmp,Fdata);
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
    tmp=name+"="+textformat(AnsL,5);
    parse(tmp);
    tmp=name+"=Enclosing(";//16.11.07from
    tmp1="list(";
    forall(plist,
      tmp1=tmp1+#+",";
    );
    tmp=tmp+substring(tmp1,0,length(tmp1)-1)+")"+opstr+")";
    GLIST=append(GLIST,tmp);//16.11.07upto
	//    GLIST=append(GLIST,"Tmp=[]"); // 16.11.05from
//    nn=floor(length(AnsL)/20);
//    forall(1..nn,ii,
//      tmp=AnsL_(((ii-1)*20+1)..(ii*20));
//      tmp=apply(tmp,LLcrd(#));
//      tmp="Tmp=[Tmp,"+textformat(tmp,5)+"]";
//      GLIST=append(GLIST,tmp);
//    );
//    if(length(AnsL)>nn*20,
//      tmp=AnsL_((nn*20+1)..(length(AnsL)));
//      tmp=apply(tmp,LLcrd(#));
//      tmp="Tmp=[Tmp,"+textformat(tmp,5)+"]";
//      GLIST=append(GLIST,tmp);
//    );
//    GLIST=append(GLIST,name+"=Listplot(Tmp)"); // 16.11.05upto
  );
  if(Noflg<2,
    if(isstring(Ltype),
      Ltype=GetLinestyle(text(Noflg)+Ltype,name);
    ,
      if(Noflg==1,Ltype=0);
    );
    GCLIST=append(GCLIST,[name,Ltype,opcindy]);
  );
  tmp=apply(AnsL,LLcrd(#));//16.10.20
  tmp;
);

Shade(plist):=Shade(plist,[]);
Shade(plist,options):=(
//help:Shade(["gr2","sg1"],[0.5]);
//help:Shade(["gr2","sg1"],["red" /pict2e]);
//help:Shade(["gr2","sg1"],[[0,0,0,0.5] /pict2e]);
//help:Shade(["gr2","sg1"],[[1,0,0] /pict2e]);
//help:Shade([pointlist]);
  regional(tmp,tmp1,tmp2,opstr,opcindy,Str,G2,flg);
  if(isstring(plist_1), // 16.01.24
    println("output Shade of "+plist);
  ,
    println("output Shade of lists");
  );
  tmp=Divoptions(options);
  opstr=tmp_(length(tmp)-1);
  opcindy=tmp_(length(tmp));
  flg=0;
  forall(plist,
    if(flg==0,
      if(isstring(#),tmp=parse(#),tmp=#); // from 16.01.24
      if(!islist(tmp),flg=1);  upto
    );
  );
  if(flg==1,
//    err("some data not defined yet");
  ,
    G2=Joincrvs("1",plist,["nodata"]);
    G2=apply(G2,Pcrd(#));
    tmp1="fillpoly("+textformat(G2,5)+opcindy+");";
    parse(tmp1);
  );
  Str="Shade(";
  tmp1="list(";
  forall(plist,
    if(isstring(#),  // from 16.01.24
      if(length(#)>1,
        tmp1=tmp1+#+",";
      ,
        tmp1=tmp1+Dq+#+Dq+",";
      );
    ,
       tmp1=tmp1+"Listplot("+textformat(#,5)+"),";
    ); // upto 16.01.24
  );
  Str=Str+substring(tmp1,0,length(tmp1)-1)+")"+opstr+")";
  Com2nd(Str);
);

//help:end();

