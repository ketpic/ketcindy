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

println("ketcindylibout[20190301] loaded");

//help:start();

////%WritetoS start////
WritetoS(fname,cmdL):=(
// help:WritetoS("outdata",cmdL);
  regional(tmp,tmp1,tmp2,filename);
  if(indexof(fname,".")==0,
    filename=fname+".sce";
  ,
    filename=fname;
  );
  SCEOUTPUT = openfile(filename);
  tmp="cd('"+Dirwork+"');//";
  println(SCEOUTPUT,tmp);
//  tmp1=replace(Dirlib,"\","/");
  tmp="Ketlib=lib("+Dq+LibnameS+Dq+");//"; //17.09.29
  println(SCEOUTPUT,tmp);
  tmp="Ketinit();//";
  println(SCEOUTPUT,tmp);
  tmp="Setwindow([XMIN,XMAX],[YMIN,YMAX]);"; // 16.06.26from
  tmp=Assign(tmp,["XMIN",XMIN,"XMAX",XMAX,"YMIN",YMIN,"YMAX",YMAX]);
  println(SCEOUTPUT,tmp); // 16.06.26until
  if(iswindows(),  // 17.01.11from
      println(SCEOUTPUT,"setlanguage('en')");
  );  // 17.01.11until
  tmp="pi=%pi;////";
  println(SCEOUTPUT,tmp);
  forall(cmdL,
    println(SCEOUTPUT,#+"//");
  );
 closefile(SCEOUTPUT);
);
////%WritetoS end////

////%kcS start////
kcS(path,fname):=kcS(path,fname,[]);
kcS(path,fname,optionorg):=(
//help:kcS(PathS,"boxdata");
//help:kcS(options=["r/m"]);
  regional(options,tmp,tmp1,tmp2,eqL,strL,filename,flg);
  if(indexof(fname,".")==0,
    filename=fname+".sce";
  ,
    filename=fname;
  );
  options=optionorg;
  tmp=Divoptions(options);
  eqL=tmp_5;
  strL=tmp_7;
  forall(eqL,
    tmp=indexof(#,"=");
    tmp1=substring(#,0,tmp-1);
    tmp2=substring(#,tmp,length(#));
  ); 
  flg=0;
  forall(strL,
    if(Toupper(substring(#,0,1))=="R",
      flg=0;
      options=remove(options,[#]);
    );
    if(Toupper(substring(#,0,1))=="M",
      flg=1;
    );
  );
  if(flg==0,
    tmp2=replace(filename,".sce",".txt");
    tmp1=load(tmp2);
    if(length(tmp1)==0,
      flg=1;
    ); 
  );
  if(flg==1,
    tmp1="";     // 15.10.08 from
    if(iswindows(),
      tmp2=Batparent;
    ,
      tmp2=Shellparent;
    );
    flg=0;
    forall(reverse(1..length(tmp2)),
      if(flg==0,
        tmp=substring(tmp2,#-1,#);
        if(tmp=="/" % tmp=="\",  // 14.01.15
          tmp1=substring(tmp2,0,#-1);
          tmp2=substring(tmp2,#,length(tmp2));
          flg=1;
        );
      );
    );
    if(length(tmp1)>0,
      setdirectory(tmp1);
    );      // 15.10.08 to
    if(iswindows(),
      SCEOUTPUT = openfile("kc.bat");
      println(SCEOUTPUT,"cd "+Dq+Dirwork+Dq);
      tmp=Dq+path+Dq+" -nb -nwni -f  "+filename;
      println(SCEOUTPUT,tmp); 
      println(SCEOUTPUT,"exit");
      closefile(SCEOUTPUT);
      println(kc(Dirwork+Batparent,Dirlib,Fnametex));// 16.05.29, 0605
    ,
      if(ismacosx(), //181125from
        SCEOUTPUT = openfile("kc.command");
      ,
        SCEOUTPUT = openfile("kc.sh");
      ); //181125to
      println(SCEOUTPUT,"#!/bin/sh");
      println(SCEOUTPUT,"cd "+Dq+Dirwork+Dq);
      tmp=Dq+path+Dq+" -nwni -f "+filename;
      println(SCEOUTPUT,tmp); 
      println(SCEOUTPUT,"exit 0");
      closefile(SCEOUTPUT);
      println(kc(Dirwork+Shellparent,Mackc+Dirlib,Fnametex));// 16.05.29
    );
    wait(WaitUnit);
    setdirectory(Dirwork);
  );
);
////%kcS end////

////%SetpathS start////
SetpathS():=(
  regional(tmp,tmp1);
  if(!isstring(PathS),  // 15.12.11
    Setdirectory(Dirbin);  // 15.12.07
    tmp=load(Shellfile);
    if(iswindows(),
      tmp=tokenize(tmp," -nb");
      PathS=tmp_1;
    ,
      tmp=tokenize(tmp," -nwni");
      tmp=tokenize(tmp_1,"/Applications/sci");
      PathS="/Applications/sci"+tmp_2;
    );
    setdirectory(Dirwork);
  );
  PathS;
);
////%SetpathS end////

////%ErrhandleS start////
ErrhandleS(fname):=(  // 2016.02.28
  regional(str); //17.04.14
  if(indexof(PathS,"-6.")==0,
    str=["if iserror(-1) then","  error=lasterror()+'????';"];
    str=append(str,"  errclear(-1);"); // 16.03.14
    str=append(str,"  Fd=mopen("+Dq+wfile+Dq+",'wt');");
    str=append(str,"  mfprintf(Fd,'%s','Error: '+error);");
    str=append(str,"  mclose(Fd);");
    str=append(str,"  quit();");
    str=append(str,"end;");
    str;
  ,
    str=[]; //17.04.14
  );
);
////%ErrhandleS end////

////%Testfunstr start////
Testfunstr(funstr,varx,vary):=(
  regional(var,val,fun,tmp,tmp1,tmp2);
  fun=replace(funstr,".x","(1)"); // 16.05.19
  fun=replace(fun,".y","(2)"); // 16.05.19
  tmp=indexof(varx,"=");
  var=substring(varx,0,tmp-1);
  val=substring(varx,tmp+1,length(varx));
  tmp=indexof(val,",");
  val=substring(val,0,tmp-1);
  tmp1=replace(fun,var,"("+val+")");
  tmp=indexof(vary,"=");
  var=substring(vary,0,tmp-1);
  val=substring(vary,tmp+1,length(vary));
  tmp=indexof(val,",");
  val=substring(val,0,tmp-1);
  tmp1=replace(tmp1,var,"("+val+")");
  tmp1;
);
////%Testfunstr end////

////%CalcbyS start////
CalcbyS(name,cmd):=CalcbyS(name,SetpathS(),cmd,[]);
CalcbyS(name,Arg1,Arg2):=(
  if(isstring(Arg1),
    CalcbyS(name,Arg1,Arg2,[]);
  ,
    CalcbyS(name,SetpathS(),Arg1,Arg2);
  );
);
CalcbyS(name,path,cmd,optionorg):=(
//help:CalcbyS("a",cmd);
//help:CalcbyS(options= ["m/r","Wait=10","Cat=middle"]]);
//help:CalcbyS(options1= ["Ncol=2","File=result","Dig=5"]]);
  regional(options,tmp,tmp1,tmp2,tmp3,tmp4,realL,strL,eqL,
      ncoL,cat,dig,flg,wflg,file,nc,arg,cmdS,cmdlist,wfile,ext,
      waiting, errcheck);
  options=optionorg;
  tmp=divoptions(options);
  eqL=tmp_5;
  realL=tmp_6;
  strL=tmp_7;
  cat="M";//16.11.24
  ncoL=2;
  ext=".txt";
  waiting=10;
  dig=5;
  wfile="";
  forall(eqL,
    tmp=indexof(#,"=");
    tmp1=Toupper(substring(#,0,1));
    tmp2=substring(#,tmp,length(#));
    if(tmp1=="C",
      cat=Toupper(substring(tmp2,0,1));// 16.11.24
      options=remove(options,[#]);
    );
    if(tmp1=="N",
      ncoL=parse(tmp2);
      options=remove(options,[#]);
    );
    if(tmp1=="E",
      if(indexof(tmp2,".")==0,ext="."+tmp2,ext=tmp2);
      options=remove(options,[#]);
    );
    if(tmp1=="W",
      waiting=parse(tmp2);
      options=remove(options,[#]);
    );
    if(tmp1=="D",
      dig=parse(tmp2);
      options=remove(options,[#]);
    );
    if(tmp1=="F",  // 16.06.26from
      wfile=tmp2;
      options=remove(options,[#]);
    ); // 16.06.26until
  );
  if(wfile=="",
    if(cat=="Y",
      wfile=Fhead+name;
    ,
      wfile="resultS";
    );
  );
  if(indexof(wfile,".")==0,// 16.06.26from
    wfile=wfile+ext; 
  ); // 16.06.26until
  wflg=0;
  forall(strL,
    tmp=Toupper(substring(#,0,1));
    if(tmp=="M",
      wflg=1;
      options=remove(options,[#]);
    );
    if(tmp=="R",
      wflg=-1;
      options=remove(options,[#]);
    );
  );
  if(CONTINUED==0,
    if((wflg==0) & (cat=="Y"), // 16.11.24
      tmp=load(wfile);
      if(length(tmp)==0,wflg=1);
    );
  );
  file=Fhead+name;
  cmdS=cmd;
  cmdlist=[];
  forall(1..floor(length(cmdS)/2),nc, //17.05.18
    tmp1=cmdS_(2*nc-1);
    tmp1=replace(tmp1,LFmark,""); // 16.06.12
    tmp1=replace(tmp1,CRmark,""); // 16.12.13
    if(nc==length(cmdR)/2, //16.10.23from
      if(indexof(tmp1,"=")==0,tmp1="="+tmp1);
    ); //16.10.23from
    if(substring(tmp1,0,1)=="=",
//      tmp1=name+tmp1; // 16.12.20
    );
    tmp2=cmdS_(2*nc);  // list of argments
    tmp3="";
    tmp4="";
    errcheck=0;
    forall(tmp2,arg,
      if(isstring(arg),
        if(Toupper(arg)=="ERROR",
          errcheck=1;
        ,
          tmp3=tmp3+replace(arg,"'",Dq)+",";
        );
      ,
        if(!islist(arg),
          tmp3=tmp3+textformat(arg,dig)+",";
        ,
          tmp=select(arg,isstring(#) % islist(#));
          if(length(tmp)>0,
            tmp3=tmp3+"list(";
            tmp4=")";
          ,
            tmp3=tmp3+"[";
            tmp4="]";
          );
          forall(arg,
            if(isstring(#),
              tmp3=tmp3+replace(#,"'",Dq)+",";
            ,
              if(!islist(#),   // 15.11.01 from
                tmp3=tmp3+textformat(#,dig)+",";
              ,
                tmp=textformat(#,dig);
                tmp=replace(tmp,"],[","];[");
                tmp3=tmp3+tmp+",";
              ); // 15.11.01 until
            );
          );
          tmp3=substring(tmp3,0,length(tmp3)-1)+tmp4+",";
        );
      );
    );
    if(length(tmp3)>0,
      tmp3=substring(tmp3,0,length(tmp3)-1);
      tmp1=tmp1+"("+tmp3+");";
    );
    if(errcheck==1,
      if(indexof(Dirlib,"sciL5")>0, // 17.03.20
        cmdlist=append(cmdlist,"errcatch(-1,'continue','nomessage');");
      ); // 17.03.20
    );
    cmdlist=append(cmdlist,tmp1);
    if(errcheck==1,
      tmp=ErrhandleS(wfile);
      cmdlist=concat(cmdlist,tmp);
    );
  );
  if(CONTINUED==1,
    ComOutList=concat(ComOutList,cmdlist);
  ,
    if(cat=="Y",
      tmp=[];
      tmp=append(tmp,"Fd=mopen("+Dq+file+".txt"+Dq+",'wt');");
      // 16.03.11 from
      tmp=append(tmp,"mfprintf(Fd,'%s',"+name+");");
      tmp=append(tmp,"mclose(Fd);");
      cmdlist=concat(cmdlist,tmp);
//      tmp="fprintfMat("+Dq+file+".txt"+Dq+","+name+")";
//      cmdlist=append(cmdlist,tmp);  // 16.03.11 until
    ,
//      tmp="mputl(['????'],"+Dq+file+".txt"+Dq+");";  // 16.06.2 from
//      cmdlist=concat(cmdlist,[tmp]); // 16.06.2 until
    );
    if(cat!="Y",   // 16.12.18
      cmdlist=append(cmdlist,"mputl('||||','"+wfile+"')");
    );
    cmdlist=append(cmdlist,"quit()");
    if(wflg==0,
      tmp1=load(file+".sce");
      if(length(tmp1)==0,
        wflg=1;
      ,
        tmp1=tokenize(tmp1,"////"); 
        tmp1=tokenize(tmp1_2,"//");
        tmp1=tmp1_(1..(length(tmp1)-1));
        if(length(tmp1)!=length(cmdlist),
          wflg=1;
        ,
          tmp=select(1..length(tmp1),tmp1_#!=cmdlist_#);
		  if(length(tmp)>0, wflg=1);
        );
      );
    ); 
    if(wflg==0,wflg=-1); // 15.10.16
    if(wflg==1,
      if(length(wfile)>0,   // 15.10.05
        SCEOUTPUT=openfile(wfile);
        println(SCEOUTPUT,"");
        closefile(SCEOUTPUT);
      );
      WritetoS(file+".sce",cmdlist);
      kcS(path,file,concat(options,["m"])); // 15.09.25
    );
    flg=0;
    tmp1=floor(waiting*1000/WaitUnit);
    repeat(tmp1,
      if(flg==0,
        tmp=load(wfile);
        if(length(tmp)>=4,
          tmp2=substring(tmp,length(tmp)-4,length(tmp));
		  if(tmp2=="////" % tmp2=="||||" % tmp2=="????", // 16.08.09
            if(indexof(Toupper(tmp),"ERROR")>0,
              println(tmp);
              flg=2;
            ,
              flg=1;
            );
          );
          tmp2=#*WaitUnit/1000;
        ,
          if(wflg==-1,
            flg=-1;
          ,
            wait(WaitUnit);
          );
        );
      );
    );
    if(flg<=0,
      ErrFlag=1;
      if(flg==-1,
        println(wfile+" does not exist");
      ,
        tmp="("+text(waiting)+" s )";
        println(wfile+" not generated "+tmp);
      );
    ,
      if(flg==1,
        println("      CalcbyS succeeded "+name+"("+text(tmp2)+" sec)"); //16.06.03
      ,
        ErrFlag=1;
      );
    );
  );
  if(wflg>-1,
//    wait(WaitUnit);
  );
);
////%CalcbyS end////

////%Scifun start////
Scifun(name,fun,argL):=Scifun(name,fun,argL,[]);//16.10.22
Scifun(name,fun,argL,optionorg):=(
//help:Scifun("1","date()",[]);
//help:Scifun(options=["Disp=y"]);
  regional(nm,options,eqL,disp,cmdL,fname,
     tmp,tmp1,tmp2);
  nm="sc"+name;
  fname=Fhead+nm+".txt";
  options=optionorg;
  tmp=divoptions(options);
  precise=6;
  disp=1;
  pack=[];
  set=[];
  add="";
  eqL=tmp_5;
  forall(eqL,
    tmp=indexof(#,"=");
    tmp1=Toupper(substring(#,0,1)); //181111
    tmp2=substring(#,tmp,length(#));
    if(tmp1=="D" ,
      tmp=Toupper(substring(tmp2,0,1));
      if((tmp=="F") % (tmp=="N"),
        disp=0;
      );
      options=remove(options,[#]);
    );
  );
  cmdL=[];
  cmdL=concat(cmdL,[
    nm+"="+fun,argL,
    "Fd=mopen",[Dq+fname+Dq,Dq+"wt"+Dq],
    "Sla=char(47)+char(47);",[],
    "mputl",["string("+nm+")+Sla","Fd"],
    "mputl",["Sla","Fd"],
    "mclose",["Fd"]
  ]);
  options=append(options,"Wait=2");
  CalcbyS(nm,cmdL,options);
  if(ErrFlag==0,
    tmp=load(fname);
    tmp=replace(tmp,"////","");
    tmp=tokenize(tmp,"//");
    tmp=apply(tmp,if(!isstring(#),textformat(#,6),Dq+#+Dq));
    if(length(tmp)==1,
      tmp=tmp_1;
    );
    tmp=nm+"="+text(tmp);
    parse(tmp);
    if(disp==1, // 15.11.24
      println(nm+" is : ");
      println(parse(nm));
    );
  );
  parse(nm);
);
////%Scifun end////

////%WritetoR start////
WritetoR(fname,cmdL):=WritetoR(fname,cmdL,[]);
WritetoR(fname,cmdL,options):=(
// help:WritetoR("outdata",cmdL);
  regional(eqL,tmp,tmp1,tmp2,filename,waiting);
  if(indexof(fname,".")==0,
    filename=fname+".r";
  ,
    filename=fname;
  );
  tmp=divoptions(options);
  eqL=tmp_5;
  waiting=5;
  forall(eqL,
    tmp=indexof(#,"=");
    tmp1=substring(#,0,tmp-1);
    tmp2=substring(#,tmp,length(#));
    if(Toupper(substring(tmp1,0,1))=="W",
      waiting=parse(tmp2);
    );
  );
  SCEOUTPUT = openfile(filename);
  tmp1=replace(Dirwork,"\","/");
  tmp="setwd("+Dq+tmp1+Dq+")##";
  println(SCEOUTPUT,tmp);
  tmp1=replace(Libname,"\","/"); // 17.09.24from
//  tmp="load('"+tmp1+".Rdata')"; # 17.10.12
  tmp="source('"+tmp1+".r')##"; // 17.09.24temporarily
  println(SCEOUTPUT,tmp);
  println(SCEOUTPUT,"Ketinit()##"); // 16.07.07
  tmp="Setwindow(c(XMIN,XMAX),c(YMIN,YMAX))####"; // 16.06.26from
  tmp=Assign(tmp,["XMIN",XMIN,"XMAX",XMAX,"YMIN",YMIN,"YMAX",YMAX]);
  println(SCEOUTPUT,tmp);
  forall(cmdL,
    println(SCEOUTPUT,#+"##");
  );
  closefile(SCEOUTPUT);
//  flg=0;
//  tmp1=floor(waiting*1000/WaitUnit);
//  repeat(tmp1,
//    if(flg==0,
//      tmp=load(filename);
//      if(length(tmp)>0,
//        flg=1;
//      ,
//        wait(WaitUnit);
//      );
//    );
//  );
);
////%WritetoR end////

////%kcR start////
kcR(path,fname):=kcR(path,fname,[]);
kcR(path,fname,optionorg):=(
//help:kcR(PathR,"boxdata");
//help:kcR(options=["m/r","Wait=10"]);
  regional(options,tmp,tmp1,tmp2,eqL,strL,filename,ferr,flg);
  if(indexof(fname,".")==0,
    filename=fname+".r";
  ,
    filename=fname;
  );
  options=optionorg;
  tmp=Divoptions(options);
  eqL=tmp_5;
  strL=tmp_7;
  forall(eqL,
    tmp=indexof(#,"=");
    tmp1=substring(#,0,tmp-1);
    tmp2=substring(#,tmp,length(#));
  );  
  flg=0;
  forall(strL,
    if(Toupper(substring(#,0,1))=="R",
      flg=0;
      options=remove(options,[#]);
    );
    if(Toupper(substring(#,0,1))=="M",
      flg=1;
      options=remove(options,[#]);
    );
  );
  if(flg==0,
    tmp2=replace(filename,".r",".txt");
    tmp1=load(tmp2);
    if(length(tmp1)==0,
      flg=1;
    ); 
  );
  if(flg==1,
    tmp1="";     // 15.10.08 from
    if(iswindows(),
      tmp2=Batparent;
    ,
      tmp2=Shellparent;
    );
    flg=0;
    forall(reverse(1..length(tmp2)),
      if(flg==0,
        tmp=substring(tmp2,#-1,#);
        if(tmp=="/" % tmp=="\",  // 14.01.15
          tmp1=substring(tmp2,0,#-1);
          tmp2=substring(tmp2,#,length(tmp2));
          flg=1;
        );
      );
    );
    if(length(tmp1)>0,
      setdirectory(tmp1);
    );      // 15.10.08 to
    ferr="errormessageR.txt";//16.10.22from
    SCEOUTPUT=openfile(ferr);
    closefile(SCEOUTPUT);//16.10.22uptp
    if(iswindows(),
      SCEOUTPUT = openfile("kc.bat");
      println(SCEOUTPUT,"cd "+Dq+Dirwork+Dq);
      tmp=Dq+path+"\R"+Dq+" --vanilla --slave < "+filename+" 2> "+ferr;
      //16.10.22
      println(SCEOUTPUT,tmp); 
      println(SCEOUTPUT,"exit");
      closefile(SCEOUTPUT);
      println(kc(Dirwork+Batparent,Dirlib,Fnametex));// 16.05.29,06.05
    ,
      if(ismacosx(), //181125from
        SCEOUTPUT = openfile("kc.command");
      ,
        SCEOUTPUT = openfile("kc.sh");
      ); //181125to
      println(SCEOUTPUT,"#!/bin/sh");
      println(SCEOUTPUT,"cd "+Dq+Dirwork+Dq);
      if(PathR=="",tmp="R",tmp=PathR);//16.10.20
      tmp=tmp+"  --vanilla --slave < "+filename+" 2> "+ferr;//17.10.12
      println(SCEOUTPUT,tmp); 
      println(SCEOUTPUT,"exit 0");
      closefile(SCEOUTPUT);
      println(kc(Dirwork+Shellparent,Mackc+Dirlib,Fnametex));// 16.05.29,06.05
    );
    wait(WaitUnit);
    setdirectory(Dirwork);
  );
);
////%kcR end////

////%Dataframe start////
Dataframe(nmL,dL):=Dataframe(nmL,dL,[]);
Dataframe(nmL,dL,options):=(
//help:Dataframe(["name","no1","no2"],dtL);
//help:Dataframe(options=["Dig=5"]);
  regional(dig,tmp,tmp1,tmp2,out);
  dig=5;
  tmp=Divoptions(options);
  tmp=tmp_5;
  forall(tmp,
    tmp1=Toupper(substring(#,0,1));
    tmp2=indexof(#,"=");
    tmp2=substring(#,tmp2,length(#));
    if(tmp1=="D",
      dig=parse(tmp2);
    );
  );
  out="data.frame(";
  forall(1..(length(nmL)),
    tmp1=nmL_#;
    tmp2=column(dL,#);
    tmp2=apply(tmp2,if(isstring(#),Dq+#+Dq,format(#,dig)));
    tmp=tmp1+"="+tmp2+",";
    out=out+tmp;
  );
  out=substring(out,0,length(out)-1)+")";
  out=replace(out,"[","c(");
  out=replace(out,"]",")");
);
////%Dataframe end////

////%MkprecommandR start////
MkprecommandR():=MkprecommandR(6,"PVOFG");  //180508(9lines)
MkprecommandR(Arg):=(
  regional(out,tmp1);
  if(isstring(Arg),
    MkprecommandR(6,Arg);
  ,
    if(islist(Arg),
      out=[];
      forall(Arg,
        tmp1=Rform(#); 
        out=concat(out,[tmp1,[]]); 
      );
      out;
    ,
      MkprecommandR(Arg,"PVOFG");
    );
  );
);
MkprecommandR(prec,chstr):=(
  regional(cmdL,Plist,tmp,tmp1,tmp2);
  cmdL=[];
  cmdL=concat(cmdL,["arccos=acos; arcsin=asin; arctan=atan",[]]); //181209
  if(indexof(chstr,"P")>0,
    Plist=[];
    forall(remove(allpoints(),[SW,NE]),
      tmp=textformat(re(Lcrd(#)),prec);
      tmp=RSform(tmp);
      tmp1=#.name;
      tmp1=tmp1+"="+tmp+";Assignadd('"+tmp1+"',"+tmp1+")";
      Plist=append(Plist,tmp1);
    );
    forall(1..(length(Plist)),
      cmdL=concat(cmdL,[Plist_#,[]]);
    );
  );
  if(indexof(chstr,"V")>0,
    tmp2=sort(apply(VLIST,#_1)); // 16.02.03 from
    tmp=apply(allpoints(),text(#));//18.02.11
    tmp2=remove(tmp2,tmp);
    tmp1=[];
    forall(tmp2,tmp,
      tmp1=concat(tmp1,select(VLIST,#_1==tmp));
    );
    VLIST=tmp1;// 17.09.24from
    forall(VLIST,  
      tmp=#_1;
      tmp1=#_2;
      if(!isstring(tmp1), 
        if(islist(tmp1),
          tmp2="[";
          forall(tmp1,
            tmp2=tmp2+textformat(#,prec)+",";
          );
          tmp1=substring(tmp2,0,length(tmp2)-1)+"]";
        ,
          tmp1=format(tmp1,prec);
        );
      ); 
      tmp1=RSform(tmp1);
      tmp1=tmp+"="+tmp1+";";
      tmp1=tmp1+"Assignadd('"+tmp+"',"+tmp+")";
      cmdL=concat(cmdL,[tmp1,[]]);//17.09.24until
    );
  );
  if(indexof(chstr,"O")>0,
    forall(OutFileList,
      cmdL=concat(cmdL,["tmp=ReadOutData",[Dq+#+Dq]]);
    );
  );
  if(indexof(chstr,"F")>0,
    forall(FUNLIST,  
      cmdL=concat(cmdL,[#,[]]);
    );
  );
  if(indexof(chstr,"G")>0,
    forall(GLIST,
      if(indexof(#,"ReadOutData")==0, //18.02.12
        tmp1=Rform(#); 
        cmdL=concat(cmdL,[tmp1,[]]); 
      );
    );
  );
  cmdL;
);
////%MkprecommandR end////

////%CalcbyR start////
CalcbyR(name,cmd):=CalcbyR(name,PathR,cmd,[]);
CalcbyR(name,Arg1,Arg2):=(
  if(isstring(Arg1),
    CalcbyR(name,Arg1,Arg2,[]);
  ,
    CalcbyR(name,PathR,Arg1,Arg2);
  );
);
CalcbyR(name,path,cmd,optionorg):=(
//help:CalcbyR(name,cmd);
//help:CalcbyR(options=["m/r","Wait=2","Out=y/n","Pre=PVFG"]);
//help:CalcbyR(options2=["Pre=!G" ]);
  regional(options,tmp,tmp1,tmp2,tmp3,realL,strL,eqL,
       cat,dig,prestr,flg,wflg,file,nc,arg,cmdR,cmdlist,wfile,waiting);
  options=optionorg;
  tmp=divoptions(options);
  eqL=tmp_5;
  realL=tmp_6;
  strL=tmp_7;
  dig=5;
  tmp=cmd_(length(cmd)-1); //181130from
  if(!isstring(tmp),tmp=text(tmp)); //190109
  if(indexof(tmp,"=")+indexof(tmp,"::")>0,
    cat="Y";
  ,
    tmp=cmd_(length(cmd));
    if(length(tmp)>0,
      cat="Y";
    ,
      cat="N";
    );
  ); //181130to
  wfile="";
  prestr="VF"; //180508,190224
  waiting=30; //180608
  nopoint="n"; //190222
  forall(eqL,
    tmp=Strsplit(#,"=");
    tmp1=Toupper(substring(tmp_1,0,1));
    tmp2=tmp_2;
    if((tmp1=="C")%(tmp1=="O"),
      cat=Toupper(substring(tmp2,0,1));
      options=remove(options,[#]);
    );
    if(tmp1=="W",
      waiting=parse(tmp2);
      options=remove(options,[#]);
    );
    if(tmp1=="P", //180508from
      tmp2=Toupper(tmp2);
      if(substring(tmp2,0,1)!="!",
        prestr=tmp2;
      ,
        tmp2=substring(tmp2,1,length(tmp2));
        forall(1..(length(tmp2)),
          prestr=replace(prestr,substring(tmp2,#-1,#),"");
        );
      );//180508to
      options=remove(options,[#]);
    );
    if(tmp1=="D",
      dig=parse(tmp2);
      options=remove(options,[#]);
    );
    if(tmp1=="F",
      wfile=tmp2; //18.02.27
      options=remove(options,[#]);
    );
    if(tmp1=="R",
      wfile=tmp2; //180227
      options=remove(options,[#]);
    );
  );
  if(wfile=="",
    if(cat=="Y",
      wfile=Fhead+name+".txt";
    ,
      wfile="resultR.txt";
    );
  );
  wflg=0;
  forall(strL,
    tmp=Toupper(substring(#,0,1));
    if(tmp=="M",
      wflg=1;
      options=remove(options,[#]);
    );
    if(tmp=="R",
      wflg=-1;
      options=remove(options,[#]);
    );
  );
  if(CONTINUED==0,
    if((wflg==0) & (cat!="N"), // 16.11.13
      tmp=load(wfile);
      if(length(tmp)==0,wflg=1);
    );
  );
  if(length(name)>0,//180412from
    file=Fhead+name;
  ,
    file=Cindyname();
  );//180412to
  cmdR=[];
  cmdR=MkprecommandR(6,prestr);
  cmdR=concat(cmdR,cmd); //18.01.27to
  cmdlist=[];
  if(dig>5, //16.10.28from
    cmdlist=append(cmdlist,"options(digits="+text(dig+2)+");");
  ); //16.10.28until
  forall(1..floor(length(cmdR)/2),nc, //17.05.18
    tmp1=cmdR_(2*nc-1);
    tmp1=replace(tmp1,LFmark,""); // 16.06.12
//    if(nc==length(cmdR)/2, //16.10.23from
//      if(indexof(tmp1,"=")==0,tmp1="="+tmp1);//16.12.20
//    ); //16.10.23uptp
    if(substring(tmp1,0,1)=="=",
      tmp1=name+tmp1;
    );
    tmp2=cmdR_(2*nc);  // list of argments
    tmp3="";
    forall(tmp2,arg,
      if(isstring(arg),
        tmp3=tmp3+replace(arg,"'",Dq)+",";
      ,
        if(length(arg)==1,
          tmp3=tmp3+textformat(arg,dig)+",";
        ,
          tmp3=tmp3+"c(";
          forall(arg,
            tmp3=tmp3+textformat(#,dig)+",";
          );
          tmp3=substring(tmp3,0,length(tmp3)-1)+")"+",";
        );
      );
    );
    if(length(tmp3)>0,
      tmp3=substring(tmp3,0,length(tmp3)-1);
      tmp1=tmp1+"("+tmp3+")";
    );
    cmdlist=append(cmdlist,tmp1);
  );
  tmp1=cmdlist_(length(cmdlist));
  if(indexof(tmp1,"=")==0,
    if(length(name)>0, //180412
      tmp1=tokenize(tmp1,"::");
      if(length(tmp1)==1,
        if(indexof(tmp1_1,"(")==0, //180510from
          tmp2=name+"="+tmp1_1;
        ,
          tmp2=tmp1_1;
        ); //180510to
      ,
        tmp2=name+"=list(";
        forall(tmp1,
          tmp2=tmp2+#+",";
        );
        tmp2=substring(tmp2,0,length(tmp2)-1)+")"; //180510(moved)
      );
      cmdlist_(length(cmdlist))=tmp2;
    );
  );
  if(CONTINUED==1,
    ComOutList=concat(ComOutList,cmdlist);
  ,
    if(cat=="Y", //16.10.23from
      tmp="sharp=rawToChar(as.raw(35))";
      cmdlist=append(cmdlist,tmp);
      tmp="sharps=paste(sharp,sharp,'\n',sep='')";
      cmdlist=append(cmdlist,tmp);
      tmp="if(Length("+name+")==0){"+name+"='nodata'}"; //18.01.29
      cmdlist=append(cmdlist,tmp);
      cmdlist=append(cmdlist,"if(is.matrix("+name+")){");
      cmdlist=append(cmdlist,"  tmp=list()");//18.02.01from
      cmdlist=append(cmdlist,"  for(ii in 1:Length("+name+")){");
      cmdlist=append(cmdlist,"    tmp=c(tmp,list(Op(ii,"+name+")))");
      cmdlist=append(cmdlist,"  }");
      cmdlist=append(cmdlist,"  "+name+"=tmp");
      cmdlist=append(cmdlist,"}");//18.02.01until
      cmdlist=append(cmdlist,"if(is.list("+name+")){");
//      tmp="  cat(names("+name+"),file='"+wfile+"',sep=',')"; //18.01.27deleted
//      cmdlist=append(cmdlist,tmp);
//      tmp="  cat(sharps,file='"+wfile+"',append=TRUE)";
//      cmdlist=append(cmdlist,tmp);
      cmdlist=append(cmdlist,"  for(ii in Looprange(1,length("+name+"))){");
      cmdlist=append(cmdlist,"    if(is.list("+name+"[[ii]])){");
      tmp="      cat('[',file='"+wfile+"',sep='',append=TRUE)";
      cmdlist=append(cmdlist,tmp);
      tmp="      cat(sharps,file='"+wfile+"',sep='',append=TRUE)";
      cmdlist=append(cmdlist,tmp);
      tmp="      for(jj in Looprange(1,length("+name+"[[ii]]))){";
      cmdlist=append(cmdlist,tmp);
      tmp="        cat("+name+"[[ii]][[jj]],file='"+wfile+"',sep=',',append=TRUE)";
      cmdlist=append(cmdlist,tmp);
      tmp="        cat(sharps,file='"+wfile+"',append=TRUE)";
      cmdlist=append(cmdlist,tmp);
      cmdlsit=append(cmdlist,"      }");
      cmdlist=append(cmdlist,"      }");
      tmp="      cat(']',file='"+wfile+"',sep=',',append=TRUE)";
      cmdlist=append(cmdlist,tmp);
      tmp="      cat(sharps,file='"+wfile+"',append=TRUE)";
      cmdlist=append(cmdlist,tmp);
      cmdlist=append(cmdlist,"    }else{");
      tmp="      cat("+name+"[[ii]],file='"+wfile+"',";
      tmp=tmp+"sep=',',append=TRUE)";
      cmdlist=append(cmdlist,tmp);
      tmp="      cat(sharps,file='"+wfile+"',append=TRUE)";
      cmdlist=append(cmdlist,tmp);
      cmdlist=append(cmdlist,"    }");
      cmdlist=append(cmdlist,"  }");
      cmdlist=append(cmdlist,"}else{");
      tmp="  cat("+name+",file='"+wfile+"',sep=',')";
      cmdlist=append(cmdlist,tmp);
      tmp="  cat(sharps,file='"+wfile+"',append=TRUE)";
      cmdlist=append(cmdlist,tmp);
      cmdlist=append(cmdlist,"}");
      tmp="cat('////',file='"+wfile+"',sep=',',append=TRUE)";
      cmdlist=append(cmdlist,tmp);
    ); //16.10.23until
    if(cat!="Y",   // 16.12.18
      cmdlist=append(cmdlist,"cat('////',file='"+wfile+"',sep='')");
    );
    cmdlist=append(cmdlist,"quit()");
    if(wflg==0,
      tmp1=load(file+".r");
      if(length(tmp1)==0,
        wflg=1;
      ,
        tmp1=tokenize(tmp1,"####");  // 15.09.25 from
        tmp1=tokenize(tmp1_2,"##");
        tmp1=tmp1_(1..(length(tmp1)-1));
        if(length(tmp1)!=length(cmdlist),
          wflg=1;
        ,
          tmp=select(1..length(tmp1),tmp1_#!=cmdlist_#);
          if(length(tmp)>0, wflg=1);
        );
      ); // 15.09.25 to
    );
    if(wflg==0,wflg=-1); // 15.10.16
    if(wflg==1,
      if(length(wfile)>0,   // 15.10.05
        SCEOUTPUT=openfile(wfile);
        println(SCEOUTPUT,"");
        closefile(SCEOUTPUT);
      );
      WritetoR(file+".r",cmdlist); //17.10.08
      SCEOUTPUT=openfile("errormessageR.txt");//18.02.20from
      println(SCEOUTPUT,"");
      closefile(SCEOUTPUT);//18.02.20until
      kcR(PathR,file,concat(options,["m"])); // 15.09.25
    );
    flg=0;
    tmp1=floor(waiting*1000/WaitUnit);
    repeat(tmp1,
      if(flg==0,
        tmp=load(wfile);
        if(length(tmp)>=4,
          tmp2=substring(tmp,length(tmp)-4,length(tmp));
          if(tmp2=="////",
            tmp=substring(tmp,0,length(tmp)-4);
            flg=1;
            tmp2=#*WaitUnit/1000;
          );
        ,
          if(wflg==-1,
            flg=-1;
          ,
            wait(WaitUnit);
            tmp=load("errormessageR.txt");//18.02.20
            if(length(tmp)>1,
              println(tmp);
              flg=-2;
            );//18.02.20
          );
        );
      );
    );
    if(flg<=0,
      ErrFlag=1;
      if(flg==-1,
        println(wfile+" does not exist");
      ,
        if(flg==0,
          tmp="("+text(waiting)+" s )";
          println(wfile+" not generated "+tmp);
        );
      );
    ,
      println("      CalcbyR succeeded "+name+" ("+text(tmp2)+" sec)");
      if(cat=="Y", // 16.10.29,11.25
        tmp1=tokenize(tmp,"##"); //16.10.23from
        tmp1=tmp1_(1..(length(tmp1)-1));
        tmp2=[];
        forall(tmp1,tmp3,
          if(!isstring(tmp3),
            tmp=format(tmp3,dig);
          ,
            if(indexof(tmp3,",")==0,
              tmp=Dqq(tmp3); //180227
            ,
             tmp=tmp3;
             if(substring(tmp3,0,2)=="c(",
               tmp=substring(tmp3,2,length(tmp3)-1);
             );
			 tmp=tokenize(tmp,",");
             tmp=textformat(tmp,dig);
            );
          );
          tmp2=append(tmp2,tmp);
        );
        if(length(tmp2)==1,
          tmp2=tmp2_1;
          if(length(tmp2)==1,tmp2=tmp2_1);
          if(isstring(tmp2),
            if(indexof(tmp2,"nodata")>0,tmp2="[]"); //180227from
            tmp2=parse(tmp2);
          );
          tmp3=textformat(tmp2,dig);//180227until
        ,
          tmp3="";
          forall(tmp2,
            if(length(#)==0,
              tmp3=tmp3+"[],";
            ,
              tmp3=tmp3+#+",";
            );
          );
          tmp3="["+substring(tmp3,0,length(tmp3)-1)+"]";
          tmp3=replace(tmp3,"[,","[");
          tmp3=replace(tmp3,",]","]");
        );
        tmp=name+"="+tmp3;//180227
        parse(tmp);
      );
    );
  );
);
////%CalcbyR end////

////%Rfun start////
Rfun(name,fun,argL):=Rfun(name,fun,argL,[]);//16.10.22
Rfun(name,fun,argL,optionorg):=(
//help:Rfun("1","rnorm",[10]);
//help:Rfun(options=["Disp=y(n)","Pre="]);
  regional(nm,options,eqL,disp,cmdL,
     tmp,tmp1,tmp2);
  nm="R"+name;
  options=optionorg;
  tmp=divoptions(options);
  precise=6;
  disp=1;
  pack=[];
  set=[];
  add="";
  eqL=tmp_5;
  forall(eqL,
    tmp=indexof(#,"=");
    tmp1=Toupper(substring(#,0,1)); //181111
    tmp2=substring(#,tmp,length(#));
    if(tmp1=="D",
      tmp=Toupper(substring(tmp2,0,1));
      if((tmp=="F") % (tmp=="N"),
        disp=0;
      );
      options=remove(options,[#]);
    );
  );
  cmdL=[];
  cmdL=concat(cmdL,[
    nm+"="+fun,argL,
  ]);
//  options=concat(options,["Wait=2"]); 
  options=concat(options,["Wait=2","Cat=y"]); //190109
  CalcbyR(nm,cmdL,options);
  if(ErrFlag==0,
    if(disp==1, // 15.11.24
      println(nm+" is : ");
      println(parse(nm));
    );
  );
  parse(nm);
);
////%Rfun end////

////%Readcsv start////
Readcsv(file):=Readcsv(Dirwork,file,[]);
Readcsv(Arg1,Arg2):=(
  if(isstring(Arg2),
    Readcsv(Arg1,Arg2,[]);
  ,
    Readcsv(Dirwork,Arg1,Arg2);
  );
);
Readcsv(pathorg,file,optionorg):=(
// help:Readcsv("ex.csv");
// help:Readcsv(directory,"ex.csv");
// help:Readcsv(options=["Head=yes","Sep=-999","Flat=no","Use=R"]);
  regional(path,fname,fout,options,eqL,header,cmdL,sep,
        dt,nrow,tmp,tmp1,tmp2,csv,use,flat);
  options=optionorg;
  tmp=divoptions(options);
  eqL=tmp_5;
  header=1;
  sep="-999";
  csv="Y"; // 16.12.12
  use="R";
  flat="N";
  forall(eqL,
    tmp=indexof(#,"=");
    tmp1=substring(#,0,tmp-1);
    tmp2=substring(#,tmp,length(#));
    tmp=Toupper(substring(tmp1,0,1)); //181111
    if(tmp=="H",
      tmp=Toupper(substring(tmp2,0,1));
      if(tmp=="F" % tmp=="N",
        header=0;
        options=remove(options,[#]);
      );
    );
    if(tmp=="S",
      sep=tmp2;
      options=remove(options,[#]);
    );
    if(tmp=="C",
      csv=Toupper(substring(tmp2,0,1));
      options=remove(options,[#]);
    );
    if(tmp=="U",
      use=Toupper(substring(tmp2,0,1));
      options=remove(options,[#]);
    );
    if(tmp=="F",
      flat=Toupper(substring(tmp2,0,1));
      options=remove(options,[#]);
    );
  );
  if(flat=="Y",csv="N");
  sep=","+sep;
  tmp=indexof(file,".");
  if(tmp==0, 
    fname=file+".csv";
    fout=file+"sep.csv";
  ,
    fname=file;
    tmp1=substring(file,0,tmp-1);
    tmp2=substring(file,tmp-1,length(file));
    fout=tmp1+"sep"+tmp2;
  );
  path=pathorg;
  if(!isexists(path,fname),
    println(path+" "+fname+" not found");
  ,
    path=replace(path,"\","/");
    if(use=="S",
      cmdL=[  // 16.12.20from
        "cd('"+path+"')",[],
        "Dt=mgetl('"+fname+"');",[],
        "cd('"+Dirwork+"')",[],
        "Dt2=[]",[],
        "for I=1:size(Dt,1),
           Tmp=Dt(I,:)+'"+sep+"';
           Dt2=[Dt2;Tmp];
         end",[],
        "mputl(Dt2,'"+fout+"')",[]
      ];
      CalcbyS("sep",cmdL,options);
    ,
      cmdL=[
        "setwd",[Dq+path+Dq],
        "tmp1=readLines",[Dq+fname+Dq,"warn=FALSE"],
        "fun=function(s) paste(s,"+Dq+sep+Dq+",sep="+Dq+Dq+")",[], 
        "tmp2=sapply(tmp1,fun)",[],
        "writeLines",["tmp2",Dq+fout+Dq]
      ];
      CalcbyR("sep",cmdL,concat(options,["Cat=n"])); 
    ); // 16.12.20until
    if(ErrFlag==1,
      println("Readcsv  not completed");
    ,
      dt=load(fout);
      dt=tokenize(dt,sep);
      dt=dt_(1..(length(dt)-1));//16.12.20
      if(isstring(dt_1),// 17.02.10from
        if(indexof(dt_1,",")==0,csv="N");
      ,
        csv="N";
      );// 17.02.10until
      if(csv=="Y",
        dt=apply(dt,tokenize(#,","));
      ,
        dt=apply(dt,[#]);
      );
      forall(1..(length(dt)),nrow,
        tmp1=dt_nrow;
        tmp2=[];
        forall(tmp1,
          if(!isstring(#),
            tmp=#;
          ,
            if(substring(#,0,1)==Dq,
              tmp=parse(#);
            ,
              tmp=#;
            );
          );
          tmp2=append(tmp2,tmp);
        );
        dt_nrow=tmp2;
      );
      if(header==0,dt=dt_(2..(length(dt))));
      if(length(dt)==1,
        dt=dt_1
      ,
        if(length(dt_1)==1,
          dt=apply(dt,#_1);
        );
      );
      dt;
    );
  );
);
// New readcsv [181125] 
Readcsv(file):=Readcsv(Dirwork,file);
Readcsv(Arg1,Arg2):=(  //190301from
  if(islist(Arg2),
    Readcsv(Dirwork,Arg1,Arg2);
  ,
    Readcsv(path,file,[]);
  );
); //190301from
Readcsv(path,file,options):=(
//help:Readcsv("ex.csv");
//help:Readcsv(directory,"ex.csv");
//help:Readcsv(options=["Head=no"]);
  regional(dt,eqL,head,from,end,tmp);
  tmp=Divoptions(options);
  eqL=tmp_5;
  head="n"; from=1; //190125from
  forall(eqL,
    tmp=Strsplit(#,"=");
    if(Toupper(substring(tmp_1,0,1))=="H",
      head=substring(tmp_2,0,1);
    );
  );
  if(Toupper(head)=="Y",
    from=2;
  ); //190125to
  tmp=file;
  if(indexof(tmp,".csv")==0,tmp=tmp+".csv"); //190301
  dt=readfile2str(path,tmp);
  dt=tokenize(dt,"/LF/");
  end=length(dt);
  if(dt_(length(dt))=="",
    end=end-1;
    dt=dt_(from..end); //190125
  );
  dt=apply(dt,tokenize(#,","));
  if(length(dt)==1, dt=dt_1);  //190125
  dt;
);
////%Readcsv end////

////%Writecsv start////
Writecsv(nmL,data,file):=Writecsv(nmL,data,file,[]);
Writecsv(nmL,dataorg,file,optionorg):=(
//help:Writecsv([],data,"ex.csv");
//help:Writecsv(["a","b"],data,"ex.csv");
//help:Writecsv(optins=["Col=1"]);
  regional(nameL,data,eqL,strL,ncol,nrow,fname,dig,tmp,tmp1,tmp2);
  ncol=0; // 17.02.09from
  dig=5;
  if(isstring(dataorg),data=parse(dataorg),data=dataorg);
  if(islist(data_1),
    ncol=length(data_1);
    data=flatten(data);
  ); // 17.02.09until
  options=optionorg;
  tmp=divoptions(options);
  eqL=tmp_5;
  forall(eqL,
    tmp=indexof(#,"=");
    tmp1=substring(#,0,tmp-1);
    tmp2=substring(#,tmp,length(#));
    if(Toupper(substring(tmp1,0,1))=="C",
      ncol=parse(tmp2);
      options=remove(options,[#]);
    );
  );
  if(indexof(file,".")==0,fname=file+".csv",fname=file);
  if(ncol==0,ncol=max(1,length(nmL)));
  tmp1=mod(length(data),ncol);
  if(tmp1>0,
    tmp=apply(1..(ncol-tmp1),-1);
    data=concat(data,tmp);
  );
  nrow=length(data)/ncol;
  if(length(nmL)<ncol,
    nameL=apply(1..ncol,"c"+text(#));
//    tmp=nameL_length(nameL)+"##";//17.02.09
    tmp=nameL_(length(nameL));//17.02.09
    nameL_(length(nameL))=tmp;
  ,
    nameL=nmL;
  );
  SCEOUTPUT=openfile(fname);
  tmp=text(nameL);
  println(SCEOUTPUT,substring(tmp,1,length(tmp)-1)); 
  forall(1..nrow,
    tmp1=data_(((#-1)*ncol+1)..(#*ncol));
    tmp2="";
    forall(tmp1,
      tmp2=tmp2+textformat(#,5)+",";
    );
    tmp2=substring(tmp2,0,length(tmp2)-1);
    println(SCEOUTPUT,tmp2);
  );
  closefile(SCEOUTPUT);
);
////%Writecsv end////

////%HatchdataR start////
HatchdataR(nm,iostr,pltlist):=HatchdataR(nm,iostr,pltlist,[]);
HatchdataR(nm,iostr,pltlist,optionorg):=( //17.09.18
//help:HatchdataR("1","ii",[["gr1"],["gr2","n"]]);
//help:HatchdataR(options=["Wait=5"]);
  regional(options,name,eqL,reL,strL,
     plt,fname,options,tmp,tmp1,tmp2,tmp3,flg,wflg,waiting);
  name="ha"+nm;
  fname=Fhead+name+".txt";
  options=optionorg;
  tmp=Divoptions(options);
  eqL=tmp_5;
  reL=tmp_6;
  strL=tmp_7;
  waiting=5;
  forall(eqL,
    tmp=indexof(#,"=");
    tmp1=Toupper(substring(#,0,1));
    tmp2=substring(#,tmp,length(#));
    if(tmp1=="W",
      waiting=parse(tmp2);
      options=remove(options,[#]);
    );
  );
  wflg=0;
  forall(strL,
    tmp=Toupper(substring(#,0,1));
    if(length(#)==0,
      options=remove(options,[#]);
    );
    if(tmp=="M",
      wflg=1;
      options=remove(options,[#]);
    );
    if(tmp=="R",
      wflg=-1;
      options=remove(options,[#]);
    );
  );
  if(islist(iostr),
    tmp1=text(apply(iostr,Dq+#+Dq));
    tmp1=replace(tmp1,"[","list(");  //16.02.14
    tmp1=replace(tmp1,"]",")"); //16.02.14
  ,
    tmp1=Dq+iostr+Dq;
  );
  if(!islist(pltlist_1),
    tmp2=apply(pltlist,if(length(#)==1,Dq+#+Dq,Chunderscore(#)));
    tmp2=text(tmp2);
    tmp2="list("+substring(tmp2,1,length(tmp2)-1)+"),";
  ,
    tmp2="";
    forall(pltlist,plt,
      tmp=apply(plt,if(length(#)==1,Dq+#+Dq,Chunderscore(#))); // 16.04.06
      tmp=text(tmp);
      tmp="list("+substring(tmp,1,length(tmp)-1)+")";
      tmp2=tmp2+tmp+",";
    );
  );
  cmdL=MkprecommandR();
  tmp2=substring(tmp2,0,length(tmp2)-1);
  tmp=[tmp1,tmp2];
  tmp=concat(tmp,reL);
  cmdL=concat(cmdL,[
    "Setscaling",[SCALEX,SCALEY], //181020
    "Setunitlen",[Dq+ULEN+Dq],
    name+"=Hatchdata",tmp, //16.12.23
    "WriteOutData",[Dq+fname+Dq,Dq+name+Dq,name]
  ]);
  options=append(options,"Wait="+text(waiting));
  if(wflg==1,options=concat(options,["m"]));
  if(wflg==-1,options=concat(options,["r"]));
  options=append(options,"Cat=no");
  if(ErrFlag==0,
    CalcbyR(name,cmdL,options);
  );
  if(ErrFlag==1,
    err("Hatchdata not completed");
  ,
    if(ErrFlag==0,
      ReadOutData(fname);
      Extractdata(name,options);
    );
  );
);
////%HatchdataR end////

////%PlotdataR start////
PlotdataR(name1,func,var):=PlotdataR(name1,PathR,func,var);
PlotdataR(name1,Arg1,Arg2,Arg3):=(
  if(islist(Arg3),
    PlotdataR(name1,PathR,Arg1,Arg2,Arg3);
  ,
    PlotdataR(name1,Arg1,Arg2,Arg3,[]);
  );
);
PlotdataR(name1,path,func,variable,optionorg):=(
//help:PlotdataR("1","dnorm(x)","x");
//help:PlotdataR(options=["m/r","Num=50","Wait=10"]);
  regional(options,tmp,tmp1,tmp2,tmp3,name,varstr,flg,Num,
         Ltype,Noflg,eqL,strL,flg,outreg,filename,wfile,cmdL,waiting);
  name="grR"+name1;
  options=optionorg;
  tmp=Divoptions(options);
  eqL=tmp_5;
  strL=tmp_7;
  Num=50;
  waiting=5;
  outreg=0;
  flg=0;
  forall(eqL,
    tmp=indexof(#,"=");
    tmp1=substring(#,tmp,length(#));
    if(Toupper(substring(#,0,1))=="N",
      Num=parse(tmp1);
      options=remove(options,[#]);
    );
    if(Toupper(substring(#,0,1))=="W",
      waiting=parse(tmp1);
      options=remove(options,[#]);
    );
    if(Toupper(substring(#,0,1))=="O",
      tmp=Toupper(substring(tmp1,0,1));
      if(tmp=="T" % tmp=="Y", outreg=1);
      options=remove(options,[#]);
    );
  );
  tmp=indexof(variable,"=");
  if(tmp>0,
    varstr=variable;
  ,
    varstr=variable+"="+textformat([XMIN,XMAX],5);
  );
  varstr=replace(varstr,"[","c(");
  varstr=replace(varstr,"]",")");
  filename=Fhead+name+".r";
  wfile=Fhead+name+".txt";
  cmdL=MkprecommandR();
  cmdL=concat(cmdL,[
    name+"=Plotdata",[Dq+func+Dq,Dq+varstr+Dq,Dq+"Num="+text(Num)+Dq],
    "WriteOutData",[Dq+wfile+Dq,Dq+name+Dq,name]
  ]);
  if(ErrFlag==0,
    CalcbyR(name,cmdL,concat(options,["Cat=middle","Wait="+text(waiting)]));
  );
  if(ErrFlag==1,
    println("PlotdataR not completed");
  ,
    if(outreg==1,
      OutFileList=remove(OutFileList,[wfile]);
      OutFileList=append(OutFileList,wfile);
    );
    ReadOutData(wfile);
    Extractdata(name,options);
    tmp=parse(name);
    tmp1=name+"="+textformat(tmp,5);
    parse(tmp1);
    tmp2=apply(tmp,Lcrd(#));
    tmp2;
  );
);
////%PlotdataR end////

////%PlotdiscR start////
PlotdiscR(nm,fun,varrng):=PlotdiscR(nm,fun,varrng,[]);
PlotdiscR(nm,fun,varrng,options):=(
//help:PlotdiscR("1","dbinom(k,10,0.4)","k=[0,10]");
  regional(name,pb,cmdL,var,range,tmp,tmp1,tmp2,wfile);
  name="grd"+nm;
  tmp=indexof(varrng,"=");
  var=substring(varrng,0,tmp-1);
  range=parse(substring(varrng,tmp,length(varrng)));
  if(length(range)==2,
    range=(range_1)..(range_2);
  );
  cmdL=[
    "fnb=function("+var+") "+fun,[],
    name+"=sapply",[range,"fnb"]
  ];
  wfile=Fhead+name+".txt";
  if(ErrFlag==0,
    CalcbyR(name,cmdL,options);
  );
  if(ErrFlag==1,
    println("PlotdiscR not completed");
  ,
    tmp1=load(wfile);
    tmp1=substring(tmp1,0,length(tmp1)-4);
    tmp1=replace(tmp1,"##","");
    pb=tokenize(tmp1,",");
    tmp=apply(range,[#,pb_(#+1)]);
    Listplot(name,tmp,options);
  );
);
////%PlotdiscR end////

////%Boxplot start////
Boxplot(nm,dataorg,ypos,dy):=Boxplot(nm,dataorg,ypos,dy,[]);
Boxplot(nm,dataorg,ypos,dy,optionorg):=(
//help:Boxplot("1",dt,2,1/2,[""]);
  regional(options,name,data,bp,cmdL,waiting,tmp,tmp1,tmp2,tmp3,tmp4,
    out,eqL,strL,pstr,ext,file,flg,wrflg);
  name="bp"+nm;
  options=optionorg;
  tmp=divoptions(options);
  eqL=tmp_5;
  strL=tmp_7;
  waiting=10;
  wrflg=0;
  forall(eqL,
    tmp=indexof(#,"=");
    tmp1=substring(#,0,tmp-1);
    tmp2=substring(#,tmp,length(#));
    if(Toupper(substring(tmp1,0,1))=="W",
      waiting=parse(tmp2);
      options=remove(options,[#]);
    );
  );
  forall(strL,
    tmp=Toupper(substring(#,0,1));
    if(tmp=="R",
      wrflg=-1;
      options=remove(options,[#]);
    );
    if(tmp=="M",
      wrflg=1;
      options=remove(options,[#]);
    );
  );
  data=dataorg;
  if(isstring(data),
    if(indexof(data,".")==0,data=data+".dat"); 
    if(iswindows(),  // 15.11.10
      data=replace(data,"/","\");
      flg="\";
    ,
      data=replace(data,"\","/");
      flg="/";
    );
    forall(reverse(1..length(data)),
      if(length(flg)>0,
        tmp=substring(data,#-1,#);
        if(tmp==flg,  
          tmp3=substring(data,0,#-1);
          tmp4=substring(data,#,length(data));
          if(indexof(tmp3,":")==0,  // 11.11.10
            tmp=substring(tmp3,0,1);
            if(tmp!=flg,
              tmp3=Dirwork+flg+tmp3;
            );
          );
          flg="";
        );
      );
    );
    if(length(flg)>0,
      tmp3=Dirwork;  //15.11.10
      tmp4=data;
    );
    setdirectory(tmp3);
    tmp=load(tmp4);
    if(length(tmp)==0, ErrFlag=2); // 15.11.07 until
    setdirectory(Dirwork);
  ,
    file=Fhead+name+".dat";
    tmp=load(file);
    if(length(tmp)>0,
      tmp1=tokenize(tmp,",");
      tmp1=tmp1_(1..(length(tmp1)-1));
    ,
       tmp1=[];
    );
	flg=0;
	if(length(tmp1)==length(data),
      tmp=tmp1-data;
      tmp=select(tmp,#!=0);
      if(length(tmp)>0,flg=1);
    ,
      flg=1;
    );
    if(flg==1,
	  SCEOUTPUT=openfile(file);
      forall(data,
        print(SCEOUTPUT,textformat(#,5)+",");
      );
      println(SCEOUTPUT,"////");
      closefile(SCEOUTPUT);
//      wait(WaitUnit);
    );
    data=file;
  );
  data=replace(data,"\","/");
  cmdL=[
    "tmp=readLines",[Dq+data+Dq, "warn=FALSE"],
    "tmp=substring",["tmp",1,"nchar(tmp)-4"],
    "data=strsplit",["tmp",Dq+","+Dq,"fix=TRUE"],
    "data=data[[1]]",[],
    "fun=function(s) eval(parse(text=s))",[],
    "data=sapply",["data","fun"],
    "data=data[!is.na(data)]",[],
    "tmp=boxplot",["data","plot=FALSE"],
    "tmp1=tmp$stat",[],
    "tmp2=tmp$out",[],
    name+"=c(tmp1,tmp2)",[]
  ];
  file=Fhead+name+".txt";
  options=append(options,"Wait="+text(waiting));
  if(wrflg==1,options=append(options,"m"));
  if(wrflg==-1,options=append(options,"r"));
  if(ErrFlag==0,
    CalcbyR(name,cmdL,options);
  );
  if(ErrFlag>0,
    if(ErrFlag==1,println("Boxplot not completed"));
    if(ErrFlag==2,println(Dq+data+Dq+" not found"));
  ,
    bp=parse(name);
    pstr="[";
    tmp1=[bp_1,ypos-dy/2];
    tmp2=[bp_1,ypos+dy/2];
    Listplot(name+text(1),[tmp1,tmp2],concat(options,["Msg=no"]));
    pstr=pstr+Dq+"sg"+name+text(1)+Dq+",";
    tmp1=[bp_2,ypos-dy];
    tmp2=[bp_2,ypos+dy];
    tmp3=[bp_4,ypos+dy];
    tmp4=[bp_4,ypos-dy];
    Listplot(name+text(2),[tmp1,tmp2,tmp3,tmp4,tmp1],append(options,"Msg=no"));
    pstr=pstr+Dq+"sg"+name+text(2)+Dq+",";
    tmp1=[bp_5,ypos-dy/2];
    tmp2=[bp_5,ypos+dy/2];
    Listplot(name+text(3),[tmp1,tmp2],append(options,"Msg=no"));
    pstr=pstr+Dq+"sg"+name+text(3)+Dq+",";
    tmp1=[bp_3,ypos-dy];
    tmp2=[bp_3,ypos+dy];
    Listplot(name+text(4),[tmp1,tmp2],concat(options,["dr,2","Msg=no"]));
    pstr=pstr+Dq+"sg"+name+text(4)+Dq+",";
    tmp1=[bp_1,ypos];
    tmp2=[bp_2,ypos];
    Listplot(name+text(5),[tmp1,tmp2],concat(options,["da","Msg=no"]));
    pstr=pstr+Dq+"sg"+name+text(5)+Dq+",";
    tmp1=[bp_4,ypos];
    tmp2=[bp_5,ypos];
    Listplot(name+text(6),[tmp1,tmp2],concat(options,["da","Msg=no"]));
    pstr=pstr+Dq+"sg"+name+text(6)+Dq+",";
    out=bp_(6..length(bp));
    if(length(out)>0,
      out=apply(out,[#,ypos]);
      Pointdata(name+text(1),out,concat(options,[0,"Size=2","Inside=white"])); //190125
    );
    pstr=substring(pstr,0,length(pstr)-1)+"]";
    println("generate totally "+name);
    tmp=name+"="+pstr;
    [bp_(1..5),out];
  );
);
////%Boxplot end////

////%Histplot start//
Histplot(nm,dataorg):=Histplot(nm,dataorg,[]);
Histplot(nm,dataorg,optionorg):=(
//help:Histplot("1",data(fillename));
//help:Histplot(options=["Breaks=","Den=no","Rel=no"]);
  regional(options,name,data,waiting,hp,cmdL,tmp,tmp1,tmp2,tmp3,tmp4,
    out,eqL,strL,breaks,bdata,cdata,pstr,file,flg,rwflg,density,relative);
  name="hp"+nm;
  options=optionorg;
  tmp=divoptions(options);
  eqL=tmp_5;
  strL=tmp_7;
  breaks = "breaks="+Dq+"Sturges"+Dq;
  density=0;
  relative=0;
  waiting=10; //190125
  forall(eqL,
    tmp=Strsplit(#,"=");
    tmp1=Toupper(substring(tmp_1,0,1));
    if(tmp1=="B",
      if(substring(tmp_2,0,1)=="[", // 190226from
        tmp1=RSform(tmp_2);
      ,
        tmp1=tmp_2;
      );// 190226to
      breaks="breaks="+tmp1;
      options=remove(options,[#]);
    );
    if(Toupper(substring(#,0,1))=="D",
      tmp2=Toupper(substring(tmp1,0,1));
      if(tmp2=="T" % tmp2=="Y",
        density=1;
      );
      options=remove(options,[#]);
    );
    if(Toupper(substring(#,0,1))=="R",
      tmp2=Toupper(substring(tmp1,0,1));
      if(tmp2=="T" % tmp2=="Y",
        relative=1;
      );
      options=remove(options,[#]);
    );
    if(Toupper(substring(#,0,1))=="W",
      waiting=parse(tmp1);
      options=remove(options,[#]);
    );
  );
  wrflg=0;
  forall(strL,
    tmp=Toupper(substring(#,0,1));
    if(tmp=="R",
      wrflg=-1;
      options=remove(options,[#]);
    );
    if(tmp=="M",
      wrflg=1;
      options=remove(options,[#]);
    );
  );
  data=dataorg;
  if(isstring(data),
    if(indexof(data,".")==0,data=data+".csv");
    if(iswindows(),  // 15.11.10
      data=replace(data,"/","\");
      flg="\";
    ,
      data=replace(data,"\","/");
      flg="/";
    );
    forall(reverse(1..length(data)),
      if(length(flg)>0,
        tmp=substring(data,#-1,#);
        if(tmp==flg,  
          tmp3=substring(data,0,#-1);
          tmp4=substring(data,#,length(data));
          if(indexof(tmp3,":")==0,  // 11.11.10
            tmp=substring(tmp3,0,1);
            if(tmp!=flg,
              tmp3=Dirwork+flg+tmp3;
            );
          );
          flg="";
        );
      );
    );
    if(length(flg)>0,
      tmp3=Dirwork;  //15.11.10
      tmp4=data;
    );
    setdirectory(tmp3);
    tmp=load(tmp4);
    if(length(tmp)==0, ErrFlag=2); // 15.11.07 until
    setdirectory(Dirwork);
  ,
    file=Fhead+name+".dat";
    tmp=load(file);
    if(length(tmp)>0,
      tmp1=tokenize(tmp,",");
      tmp1=tmp1_(1..(length(tmp1)-1));
    ,
       tmp1=[];
    );
	flg=0;
	if(length(tmp1)==length(data),
      tmp=tmp1-data;
      tmp=select(tmp,#!=0);
      if(length(tmp)>0,flg=1);
    ,
      flg=1;
    );
    if(flg==1,
	  SCEOUTPUT=openfile(file);
      forall(data,
        print(SCEOUTPUT,textformat(#,5)+",");
      );
      println(SCEOUTPUT,"////");
      closefile(SCEOUTPUT);
//	  wait(WaitUnit);
    );
    data=file;
  );
  data=replace(data,"\","/");
  cmdL=[
    "tmp=readLines",[Dq+data+Dq, "warn=FALSE"],
    "tmp=substring",["tmp",1,"nchar(tmp)-4"],
    "data=strsplit",["tmp",Dq+","+Dq,"fix=TRUE"],
    "data=data[[1]]",[],
    "fun=function(s) eval(parse(text=s))",[],
    "data=sapply",["data","fun"],
    "data=data[!is.na(data)]",[],
	"tmp=hist",["data","plot=FALSE",breaks],
    "tmp1=tmp$breaks",[],
    "tmp2=tmp$count",[],
    "tmp3=tmp$density",[],
    name+"=c(tmp1,tmp2,tmp3)",[]
  ];
  file=Fhead+name+".txt";
  options=append(options,"Wait="+text(waiting));
  if(wrflg==1,options=append(options,"m"));
  if(wrflg==-1,options=append(options,"r"));
  if(ErrFlag==0,
    CalcbyR(name,cmdL,options);
  );
  if(ErrFlag>0,
    if(ErrFlag==1,println("Histplot not completed"));
    if(ErrFlag==2,println(Dq+data+Dq+" not found"));
  ,
//    tmp=load(file);
//    tmp=replace(tmp,"/","");
//    tmp=tokenize(tmp,",");
//	tmp=name+"="+textformat(tmp,5);
//  parse(tmp);
    hp=parse(name);
    tmp1=(length(hp)-1)/3+1;
    tmp2=tmp1+(length(hp)-1)/3;
    bdata=hp_(1..tmp1);
    if(density==0,
      cdata=hp_((tmp1+1)..tmp2);
    ,
      cdata=hp_((tmp2+1)..length(hp));
    );
    if(relative==1,
      cdata=cdata/sum(cdata);
    );
    options=append(options,"Msg=no"); // 15.10.03
    pstr="[";
    forall(1..length(cdata),
      tmp1=[bdata_#,0];
      tmp2=[bdata_#,cdata_#];
      tmp3=[bdata_(#+1),cdata_#];
      tmp4=[bdata_(#+1),0];
      Listplot(name+text(#),[tmp1,tmp2,tmp3,tmp4,tmp1],options);
      pstr=pstr+Dq+"sg"+name+text(#)+Dq+",";
    );
    pstr=substring(pstr,0,length(pstr)-1)+"]";
    println("generate totally "+name); 
    tmp=name+"="+pstr;
    parse(tmp);
    [bdata,cdata];
  );
);
////%Histplot end//

////%Scatterplot start////
Scatterplot(nm,file):=Scatterplot(nm,file,[],[]);
Scatterplot(nm,file,options):=Scatterplot(nm,file,options,[]);
Scatterplot(nm,file,optionorg,optionsreg):=(
//help:Scatterplot("1",(path+)filename);
//help:Scatterplot("2",ptlist,["Size=2"],["da","Color=blue"]);
//help:Scatterplot("3",ptlist,["Reg=n"]);
//help:Scatterplot(options=["Reg=n","Size=3","Color="]);
//help:Scatterplot(options1=["Reg=y(n)",pointstyle]);
//help:Scatterplot(options2=[position([]), linestyle]);
  regional(tmp,tmp1,tmp2,fname,name,reg,eqL,strL,cdysize,
    options,dtx,dty,nn,mx,my,sx,sy,sxy,rr,aa,bb,size,pos);
  name="sc"+nm;
  options=optionorg;
  tmp=divoptions(options);
  eqL=tmp_5;
  options=remove(options,tmp_6);
  strL=tmp_7; //181013(2lines)
  options=remove(options,strL);
  size=3;
  reg="y";
  forall(eqL,
    tmp=indexof(#,"=");
    tmp1=Toupper(substring(#,0,1));
    tmp2=substring(#,tmp,length(#));
    if(tmp1=="R",
      reg=substring(tmp2,0,1);
      options=remove(options,[#]);
    );
    if(tmp1=="S",
      size=parse(tmp2);
      options=remove(options,[#]);
      options=append(options,"Size="+text(size));//181013
    );
  );
  if(isstring(file), //181013
    if(indexof(file,".")==0,
       fname=file+".csv";
    ,
      fname=file;
    );
    tmp=Readcsv(fname,strL);//181013from
  ,
    tmp=file;
  );
  parse("rc"+nm+"="+tmp); //181013to
  Pointdata(name,parse("rc"+nm),options);
  tmp=parse("rc"+nm);
  dtx=apply(tmp,#_1);
  dty=apply(tmp,#_2);
  nn=length(dtx);
  mx=sum(dtx)/nn;
  my=sum(dty)/nn;
  sx=sqrt(dtx*dtx/nn-mx^2);
  sy=sqrt(dty*dty/nn-my^2);
  sxy=dtx*dty/nn-mx*my;
  rr=sxy/sx/sy;
  aa=sxy/sx^2;
  bb=my-aa*mx;
  tmp1=optionsreg;
  tmp=divoptions(tmp1);
  reL=tmp_6; //181013(2lines)
  tmp1=remove(tmp1,reL);
  tmp1=append(tmp1,"Num=1");
  pos=[];
  if(length(reL)>0,
    pos=reL_1;
  );
  tmp=Assign("a*x+b",["a",aa,"b",bb]);
  if(reg!="n",
    Plotdata(name,tmp,"x",tmp1);
  );
  if(length(pos)>0, //181013from
    tmp="r="+textformat(rr,3)+",\ y=";
    tmp=tmp+textformat(aa,3)+"x";
    if(bb>0,tmp=tmp+"+",tmp=tmp+"-");
    tmp=tmp+textformat(abs(bb),3);
    Expr([pos,"e",tmp]); //181013to
  );
  [mx,my,sx,sy,sxy,rr,bb,aa];
);
////%Scatterplot end////

////%Rulerscale start////
Rulerscale(pt,hscale,vscale):=Rulerscale(pt,hscale,vscale,0.1,[]);//180722from
Rulerscale(Arg1,Arg2,Arg3,Arg4):=(
  if(!islist(Arg4),
    Rulerscale(Arg1,Arg2,Arg3,Arg4,[]);
  ,
    Rulerscale(Arg1,Arg2,Arg3,0.2,Arg4);
  );
);//180722to
Rulerscale(pt,hscale,vscale,tick,options):=(//180722
//help:Rulerscale(A,["r",0,5,1],["s2",0,2,4]);
//help:Rulerscale(A,["r",0,5,1],["f",10,"a",20,"w2","b"]);
//help:Rulerscale(A,["r",0,5,1],["r",0,10,1],0.2);
  regional(pA,pos,mrk,dir,mag,tmp,tmp1,tmp2,tmp3);
  pA=Lcrd(pt);
  if(length(hscale)>0,
    pos=[]; mrk=[]; dir=[];
    tmp=Toupper(substring(hscale_1,0,1));
    if(tmp=="R" % tmp=="F",
      if(tmp=="R",
        dir="s2";
        tmp1=hscale_2;
        tmp2=hscale_3;
        tmp3=hscale_4;
        if(length(hscale)>4,mag=hscale_5,mag=1); //181014
        tmp=floor((tmp2-tmp1)/tmp3);
        pos=apply(0..tmp,tmp1+#*tmp3);//181014
        mrk=apply(pos,text(#*mag));
        dir=apply(1..length(pos),"s2");
      ,
        forall(2..(length(hscale)-2),
          tmp1=hscale_(#);
          tmp2=hscale_(#+1);
          tmp3=hscale_(#+2);
          if(isreal(tmp1),
            pos=append(pos,tmp1);
            if(isstring(tmp3),
              dir=append(dir,tmp2);
              mrk=append(mrk,tmp3);
            ,
              dir=append(dir,"s2");
              mrk=append(mrk,tmp2);
            );
          );
        );
        if(isreal(tmp2),
          pos=append(pos,tmp2);
          dir=append(dir,"s2");
          mrk=append(mrk,tmp3);
        );        
      );
    ,
      pos=hscale_(2..length(hscale));
      dir=apply(pos,"s2");
      mrk=apply(pos,text(#));
    );
    pos=apply(pos,[#,pA_2]);
    forall(1..length(pos),
      Expr([pos_#,dir_#,mrk_#],options);
      tmp1=pos_#;
      tmp2=pos_#-Unscaling([0,tick]); //181017
      Listplot("rsh"+text(#),[tmp1,tmp2],concat(options,["Msg=no"]));
    );
  );
  if(length(vscale)>0,
    pos=[]; mrk=[]; dir=[];
    tmp=Toupper(substring(vscale_1,0,1));
    if(tmp=="R" % tmp=="F",
      if(tmp=="R",
        dir="w2";
        tmp1=vscale_2;
        tmp2=vscale_3;
        tmp3=vscale_4;
        if(length(vscale)>4,mag=vscale_5,mag=1); //181014
        tmp=floor((tmp2-tmp1)/tmp3);
        pos=apply(0..tmp,tmp1+#*tmp3);
        mrk=apply(pos,text(#*mag)); //181014
        dir=apply(1..length(pos),"w2");
      ,
        forall(2..(length(vscale)-2),
          tmp1=vscale_(#);
          tmp2=vscale_(#+1);
          tmp3=vscale_(#+2);
          if(isreal(tmp1),
            pos=append(pos,tmp1);
            if(isstring(tmp3),
              dir=append(dir,tmp2);
              mrk=append(mrk,tmp3);
            ,
              dir=append(dir,"w2");
              mrk=append(mrk,tmp2);
            );
          );
        );
        if(isreal(tmp2),
          pos=append(pos,tmp2);
          dir=append(dir,"w2");
          mrk=append(mrk,tmp3);
        );        
      );
    ,
      pos=vscale_(2..length(vscale));
      dir=apply(pos,"w1");
      mrk=apply(pos,text(#));
    );
    pos=apply(pos,[pA_1,#]);
    forall(1..length(pos),
      Expr([pos_#,dir_#,mrk_#],options);
      tmp1=pos_#;
      tmp2=pos_#-Unscaling([tick,0]); //181017
      Listplot("rsv"+text(#),[tmp1,tmp2],concat(options,["Msg=no"]));
    );
  );
);
////%Rulerscale end////

MkprecommandS():=MkprecommandS(6);
MkprecommandS(prec):=(
  regional(cmdL,Plist,Pnamelist,Pvaluelist,tmp,tmp1,tmp2);
  cmdL=[];
  Plist=[];
  Pnamelist=[];
  Pvaluelist=[];
  forall(remove(allpoints(),[SW,NE]),
    tmp=Lcrd(#);
    tmp1=format(re(tmp_1),prec);// 15.02.05
    tmp2=format(re(tmp_2),prec);
    tmp="["+tmp1+","+tmp2+"]"; 
    Plist=append(Plist,#.name+"="+tmp);
    Pnamelist=append(Pnamelist,#.name);
    Pvaluelist=append(Pvaluelist,tmp);
  );
  forall(1..length(Plist),
    cmdL=concat(cmdL,[Plist_#,[]]);
    cmdL=concat(cmdL,["Assignrep('"+Pnamelist_#+"',"+Pvaluelist_#+")",[]]);
  );
  tmp2=sort(apply(VLIST,#_1)); // 16.02.03 from
  tmp1=[];
  forall(tmp2,tmp,
    tmp1=concat(tmp1,select(VLIST,#_1==tmp));
  );
  VLIST=tmp1;// 16.02.03 until
  forall(VLIST,
    tmp=Sciform(#_1);
    tmp1=#_2; // 15.02.06
    if(!isstring(tmp1), 
      if(islist(tmp1),
        if(!isstring(tmp1_1),  // 16.11.14
          tmp2="[";
          forall(tmp1,
            if(abs(#)<10^(-prec),  // 16.01.30
              tmp2=tmp2+"0,";
            ,
              tmp2=tmp2+format(#,prec)+",";
            );
          );
          tmp1=substring(tmp2,0,length(tmp2)-1)+"]";
        ,
          tmp2="list(";  // 16.11.14from
          forall(tmp1,
             tmp2=tmp2+#+",";
          );
          tmp1=substring(tmp2,0,length(tmp2)-1)+")";
        ); // 16.11.14until
      ,
        tmp1=format(tmp1,prec);
      );
    );
    cmdL=concat(cmdL,[tmp+"evstr('"+tmp1+"')",[]]);
	tmp=substring(tmp,0,length(tmp)-1);
    cmdL=concat(cmdL,["Assignrep('"+tmp+"',"+tmp1+")",[]]); // 15.01.27
  );
  forall(OutFileList,
    tmp=["tmp=ReadOutData",[Dq+#+Dq],
    "if length(tmp(1))>8,execstr(tmp),end",[]];
    cmdL=concat(cmdL,tmp);
  );
  forall(FUNLIST,  // 16.02.17 from
    cmdL=concat(cmdL,[#,[]]);
  );  // 16.02.17 until
  forall(GLIST,
    tmp1=Sciform(#);
    cmdL=concat(cmdL,[tmp1,[]]);
  );
  cmdL;
);

PlotdataS(name1,func,var):=PlotdataS(name1,func,var,[]);
PlotdataS(nm,fun,variable,optionorg):=(
// help:PlotdataS("1","besselj(1,x)","x");
// help:PlotdataS(options=["m/r","Num=50","Wait=5","Mx=no"]);
  regional(options,name,varstr,Num,waiting,mxcheck,outreg,
         eqL,strL,fname,tmp,tmp1,tmp2,tmp3,cmdL,flg,wflg);
  name="grsc"+nm;
  fname=Fhead+name+".txt";
  options=optionorg;
  tmp=Divoptions(options);
  eqL=tmp_5;
  strL=tmp_7;
  Num=50;
  waiting=5;
  mxcheck=0; // 16.03.02
  outreg=0;
  flg=0;
  forall(eqL,
    tmp=indexof(#,"=");
    tmp1=Toupper(substring(#,0,1));
    tmp2=substring(#,tmp,length(#));
    if(tmp1=="N",
      Num=parse(tmp2);
      options=remove(options,[#]);
    );
    if(tmp1=="W",
      waiting=parse(tmp2);
      options=remove(options,[#]);
    );
    if(tmp1=="O",
      tmp=Toupper(substring(tmp2,0,1));
      if(tmp=="T" % tmp=="Y", outreg=1);
      options=remove(options,[#]);
    );
    if(tmp1=="M",
      tmp=Toupper(substring(tmp2,0,1));
      if(tmp=="T" % tmp=="Y", mxcheck=1);
      options=remove(options,[#]);
    );
  );
  wflg=0;
  forall(strL,
    tmp=Toupper(substring(#,0,1));
    if(length(#)==0,
      options=remove(options,[#]);
    );
    if(tmp=="M",
      wflg=1;
      options=remove(options,[#]);
    );
    if(tmp=="R",
      wflg=-1;
      options=remove(options,[#]);
    );
  );
  tmp=indexof(variable,"=");
  if(tmp>0,
    varstr=variable;
  ,
    varstr=variable+"="+textformat([XMIN,XMAX],5);
  );
  cmdL=MkprecommandS();
  cmdL=concat(cmdL,[
    name+"=Plotdata",[Dq+fun+Dq,Dq+varstr+Dq,Dq+"Num="+text(Num)+Dq],
    "WriteOutData",[Dq+fname+Dq,Dq+name+Dq,name]
  ]);
  ErrFlag=0;   // 16.03.02 from
  if(mxcheck==1, 
    Mxfun(name,fun,[],["Disp=n"]);
    tmp=parse("mx"+name);
    if(!isstring(tmp),ErrFlag=1);
  ); 
  options=append(options,"Wait="+text(waiting));
  if(wflg==1,options=append(options,"m"));
  if(wflg==-1,options=append(options,"r"));// 16.03.02 until
  if(ErrFlag==0,
    CalcbyS(name,cmdL,concat(options,["cat=middle","Wait="+text(waiting)]));
  );
  if(ErrFlag==1,
    println("    PlotdataS not completed");
  ,
    if(outreg==1,    // 2016.03.02  ( // )
      OutFileList=remove(OutFileList,[wfile]);
      OutFileList=append(OutFileList,wfile);
    );
    ReadOutData(fname);  
    Extractdata(name,options);
    tmp=parse(name);
    tmp1=name+"="+textformat(tmp,5);
    parse(tmp1);
//    Addgraph(name);  // 16.04.04
    tmp2=apply(tmp,Lcrd(#));
    tmp2;
  );
);

Dotfilldata(nm,iostr,pltlist):=
  Dotfilldata(nm,iostr,pltlist,[]);
Dotfilldata(nm,iostr,pltlist,optionorg):=(
//help:Dotfilldata("1","ii",[["sg1"],["sg2"]]);
//help:Dotfilldata(options=[0.3,"Wait=5"]);
  regional(options,name,fun,eqL,reL,strL,outreg,
     plt,fname,options,tmp,tmp1,tmp2,tmp3,flg,
     wflg,waiting,dense);
  name="df"+nm;
  fname=Fhead+name+".txt";
  fun=fnorg;
  tmp=indexof(fun,"=");
  if(tmp>0,
    tmp1=substring(fun,0,tmp-1);
    tmp2=substring(fun,tmp,length(fun));
    fun=tmp1+"-("+tmp2+")";
  );
  options=optionorg;
  tmp=Divoptions(options);
  eqL=tmp_5;
  reL=tmp_6;
  strL=tmp_7;
  dense=0.3;
  waiting=5;
  outreg=0;
  forall(reL,
    dense=#;
  );
  forall(eqL,
    tmp=indexof(#,"=");
    tmp1=Toupper(substring(#,0,1));
    tmp2=substring(#,tmp,length(#));
    if(tmp1=="W",
      waiting=parse(tmp2);
      options=remove(options,[#]);
    );
    if(tmp1=="O",
      tmp=Toupper(substring(tmp2,0,1));
      if(tmp=="T" % tmp=="Y", outreg=1);
      options=remove(options,[#]);
    );
  );
  wflg=0;
  forall(strL,
    tmp=Toupper(substring(#,0,1));
    if(length(#)==0,
      options=remove(options,[#]);
    );
    if(tmp=="M",
      wflg=1;
      options=remove(options,[#]);
    );
    if(tmp=="R",
      wflg=-1;
      options=remove(options,[#]);
    );
  );
  if(islist(iostr),
    tmp1=text(apply(iostr,Dq+#+Dq));
    tmp1=replace(tmp1,"[","list(");  //16.02.14
    tmp1=replace(tmp1,"]",")"); //16.02.14
  ,
    tmp1=Dq+iostr+Dq;
  );
  if(!islist(pltlist_1),
    tmp2=apply(pltlist,if(length(#)==1,Dq+#+Dq,#));
    tmp2=text(tmp2);
    tmp2="list("+substring(tmp2,1,length(tmp2)-1)+"),";
  ,
    tmp2="";
    forall(pltlist,plt,
      tmp=apply(plt,if(length(#)==1,Dq+#+Dq,#));
      tmp=text(tmp);
      tmp="list("+substring(tmp,1,length(tmp)-1)+")";
      tmp2=tmp2+tmp+",";
    );
  );
  cmdL=MkprecommandR(); //17.09.29
  tmp2=substring(tmp2,0,length(tmp2)-1);
  tmp=[tmp1,tmp2];
  tmp=concat(tmp,dense);
  cmdL=concat(cmdL,[
    "Setscaling",[SCALEX,SCALEY], //181020
    "Setunitlen",[Dq+ULEN+Dq],
    name+"=Dotfilldata",tmp,
    "WriteOutData",[Dq+fname+Dq,Dq+name+Dq,name],
  ]);
  options=append(options,"Wait="+text(waiting));
  if(wflg==1,options=concat(options,["m"]));
  if(wflg==-1,options=concat(options,["r"]));
  options=append(options,"Cat=n");
  if(ErrFlag==0,
    CalcbyR(name,cmdL,options); //17.09.29
  );
  if(ErrFlag==1,
    println("Dotfilldata not completed");
  ,
    if(outreg==1,
      OutFileList=remove(OutFileList,[fname]);
      OutFileList=append(OutFileList,fname);
    );
    if(ErrFlag==0,
      ReadOutData(fname);
      tmp1=parse(name);
      forall(tmp1,
        tmp=#_1;
        draw(tmp,pointsize->1);
      );
      Com2nd("tmp=ReadOutData("+Dq+fname+Dq+")");
      Com2nd("Drwpt("+name+")");
    );
  );
);

WritetoA(fname,cmdL):=(
// help:WritetoA("outdata",cmdL);
  regional(tmp,tmp1,tmp2,filename,wfilename,endmark);
  if(indexof(fname,".")==0,
    filename=fname+".rr";
  ,
    filename=fname;
  );
  wfilename=replace(filename,".rr",".txt");
  SCEOUTPUT = openfile(filename);
//  tmp=replace(Dirlib,"\","/");
//  tmp="load("+Dq+tmp+"/oshima/os_muldif.rr"+Dq+")$/*####*/";
  tmp="/*####*/"; // 16.03.11
  println(SCEOUTPUT,tmp);  
  tmp="output("+Dq+wfilename+Dq+")$/*##*/"; // 16.05.18from
  println(SCEOUTPUT,tmp); // 16.05.18until
  forall(1..(length(cmdL)),
    tmp1=cmdL_#;
    tmp=indexof(tmp1,";"); // 16.05.18from
    if(tmp>0,endmark=";",endmark="$");
    tmp1=replace(tmp1,";",""); // 16.05.18until
    if(#==length(cmdL)-1,
      println(SCEOUTPUT,tmp1+";/*##*/");
   ,
      println(SCEOUTPUT,tmp1+endmark+"/*##*/");//16.05.18
   );
  );
  closefile(SCEOUTPUT);
);

////%kcA start////
kcA(fname):=kcA(fname,[]);
kcA(fname,optionorg):=(
//help:kcA("boxdata");
//help:kcA(options=["r/m"]);
  regional(options,tmp,tmp1,tmp2,eqL,strL,filename,flg);
  if(indexof(fname,".")==0,
    filename=fname+".rr";
  ,
    filename=fname;
  );
  options=optionorg;
  tmp=Divoptions(options);
  eqL=tmp_5;
  strL=tmp_7;
  forall(eqL,
    tmp=indexof(#,"=");
    tmp1=substring(#,0,tmp-1);
    tmp2=substring(#,tmp,length(#));
  ); 
  flg=0;
  forall(strL,
    if(Toupper(substring(#,0,1))=="R",
      flg=0;
      options=remove(options,[#]);
    );
    if(Toupper(substring(#,0,1))=="M",
      flg=1;
    );
  );
  if(flg==0,
    tmp2=replace(filename,".rr",".txt");
    tmp1=load(tmp2);
    if(length(tmp1)==0,
      flg=1;
    ); 
  );
  if(flg==1,
    tmp1=""; 
    if(iswindows(),
      tmp2=Batparent;
    ,
      tmp2=Shellparent;
    );
    flg=0;
    forall(reverse(1..length(tmp2)),
      if(flg==0,
        tmp=substring(tmp2,#-1,#);
        if(tmp=="/" % tmp=="\",  // 14.01.15
          tmp1=substring(tmp2,0,#-1);
          tmp2=substring(tmp2,#,length(tmp2));
          flg=1;
        );
      );
    );
    if(length(tmp1)>0,
      setdirectory(tmp1);
    ); 
    if(iswindows(),
      SCEOUTPUT = openfile("kc.bat");
      println(SCEOUTPUT,"cd "+Dq+Dirwork+Dq);
      tmp="del "+replace(filename,".rr",".txt");
      println(SCEOUTPUT,tmp);
      tmp=Dq+PathA+Dq+" -quiet -f "+Dq+filename+Dq;
      println(SCEOUTPUT,tmp); 
      println(SCEOUTPUT,"exit");
      closefile(SCEOUTPUT);
      tmp=replace(filename,".rr",".txt");
      println(kc(Dirwork+Batparent,Dirlib,tmp)); // 16.05.29,06.05
    ,
      if(ismacosx(), //181125from
        SCEOUTPUT = openfile("kc.command");
      ,
        SCEOUTPUT = openfile("kc.sh");
      ); //181125to
      println(SCEOUTPUT,"#!/bin/sh");
      println(SCEOUTPUT,"cd "+Dq+Dirwork+Dq);
      tmp="rm "+replace(filename,".rr",".txt");
      println(SCEOUTPUT,tmp);
      tmp=Dq+PathA+Dq+" -quiet -f "+Dq+filename+Dq;
      println(SCEOUTPUT,tmp); 
      println(SCEOUTPUT,"exit 0");
      closefile(SCEOUTPUT);
      tmp=replace(filename,".rr",".txt");
      println(kc(Dirwork+Shellparent,Mackc+Dirlib,tmp));// 16.05.29,06.05

    );
//    wait(WaitUnit);
    setdirectory(Dirwork);
  );
);
////%kcA end////

////%CalcbyA start////
CalcbyA(name,cmd):=CalcbyA(name,cmd,[]);
CalcbyA(name,cmd,optionorg):=(
//help:CalcbyA("a",cmd);
//help:CalcbyA(options= ["m/r","Wait=10","Ext=txt","Dig=16"]]);
  regional(options,tmp,tmp1,tmp2,tmp3,tmp4,realL,strL,eqL,
      dig,flg,wflg,file,nc,arg,cmdA,cmdlist,wfile,ext,waiting,num,st);
  options=optionorg;
  tmp=divoptions(options);
  eqL=tmp_5;
  realL=tmp_6;
  strL=tmp_7;
  wfile="";
  ext=".txt";
  waiting=2;
  dig=6;
  forall(eqL,
    tmp=indexof(#,"=");
    tmp1=Toupper(substring(#,0,1));
    tmp2=substring(#,tmp,length(#));
    if(tmp1=="E",
      if(indexof(tmp2,".")==0,ext="."+tmp2,ext=tmp2);
      options=remove(options,[#]);
    );
    if(tmp1=="W",
      waiting=parse(tmp2);
      options=remove(options,[#]);
    );
    if(tmp1=="D",
      dig=parse(tmp2);
      options=remove(options,[#]);
    );
  );
  wfile=Fhead+name+ext;
  wflg=0;
  forall(strL,
    tmp=Toupper(substring(#,0,1));
    if(tmp=="M",
      wflg=1;
      options=remove(options,[#]);
    );
    if(tmp=="R",
      wflg=-1;
      options=remove(options,[#]);
    );
  );
  file=Fhead+name;
  cmdA=cmd;
  cmdlist=[];
  forall(1..floor(length(cmdA)/2),nc, //17.5.18
    tmp1=cmdA_(2*nc-1);
    tmp1=replace(tmp1,LFmark,""); // 16.06.12
    if(nc==length(cmdA)/2,
      tmp=indexof(tmp1,"=");
      tmp1=substring(tmp1,tmp,length(tmp1));
      if(substring(tmp1,0,1)=="[",
        tmp=substring(tmp1,0,length(tmp1)-1);
      ,
        tmp="["+Dq+"/start/"+Dq+","+tmp1; // 16.05.18
      );
      tmp=replace(tmp,"::",","+Dq+"//"+Dq+",");
      tmp1=tmp+","+Dq+"////"+Dq+"]";
    );
    tmp2=cmdA_(2*nc);  // list of argments
    tmp3="";
    tmp4="";
    forall(tmp2,arg,
      if(isstring(arg),
        tmp3=tmp3+replace(arg,"'",Dq)+",";
//        tmp3=tmp3+arg; 
      ,
        if(!islist(arg),
          tmp3=tmp3+textformat(arg,dig)+",";
        ,
          tmp3=tmp3+"[";
          tmp4="]";
          forall(arg,
            if(isstring(#),
//              tmp3=tmp3+Dq+#+Dq+",";
              tmp=replace(#,"'",Dq); 
//              tmp=#;// 2016.03.03
              tmp3=tmp3+tmp+",";
            ,
              if(!islist(#),  
                tmp3=tmp3+textformat(#,dig)+",";
              ,
                tmp=textformat(#,dig);
                tmp=replace(tmp,"],[","];[");
                tmp3=tmp3+tmp+",";
              );
            );
          );
          tmp3=substring(tmp3,0,length(tmp3)-1)+tmp4+",";
        );
      );
    );
    if(length(tmp3)>0,
      tmp3=substring(tmp3,0,length(tmp3)-1);
      tmp1=tmp1+"("+tmp3+")";
    );
    cmdlist=append(cmdlist,tmp1);
  );
  cmdlist=append(cmdlist,"quit");
  if(wflg==0,
    tmp1=load(file+".rr");
    if((length(tmp1)==0) % (indexof(tmp1,"/*####*/")==0), //15.11.26
      wflg=1;
    ,
      tmp1=tokenize(tmp1,"/*####*/"); 
      tmp1=tokenize(tmp1_2,"/*##*/");
      tmp1=tmp1_(1..(length(tmp1)-1));
      tmp=select(tmp1,indexof(#,"output")>0);
      tmp1=remove(tmp1,tmp);
      tmp1=apply(tmp1,substring(#,0,length(#)-1));
      if(length(tmp1)!=length(cmdlist),  // 15.12.06
        wflg=1;
      ,
        tmp=select(1..length(tmp1),tmp1_#!=cmdlist_#);
        if(length(tmp)>0, wflg=1);
      );
    );
  ); 
  if(wflg==0,wflg=-1); // 15.10.16
  if(wflg==1,
    if(length(wfile)>0,   // 15.10.05
      SCEOUTPUT=openfile(wfile);
      println(SCEOUTPUT,"");
      closefile(SCEOUTPUT);
    );
    WritetoA(file+".rr",cmdlist);
    kcA(file,concat(options,["m"]));
  );
  flg=0;
  tmp1=floor(waiting*1000/WaitUnit);
  repeat(tmp1,
    if(flg==0,
      tmp=load(wfile);
      if(length(tmp)>=4,
        tmp2=substring(tmp,length(tmp)-5,length(tmp));
        if(tmp2=="////]",
          tmp=substring(tmp,1,length(tmp)-6);
          num="1234567890+-.";
          tmp1=tokenize(","+tmp,",//");
          tmp3=apply(tmp1,substring(#,1,length(#)));
          tmp1="[";
          forall(tmp3,st,
            tmp=select(1..length(st),indexof(num,substring(st,#-1,#))==0);
            if((length(tmp)==0) & (length(st)<4), // 16.05.10 16=>4
              tmp1=tmp1+st+",";
            ,
              tmp1=tmp1+Dq+st+Dq+",";
            );
          );
          tmp=Indexof(tmp1,"/start/,"); // 16.05.18from
          tmp1="["+Dq+substring(tmp1,tmp+7,length(tmp1)-1)+"]";
            // 16.05.18until
//		  tmp1=substring(tmp1,0,length(tmp1)-1)+"]";
          parse(name+"="+tmp1);
          tmp=parse(name);
          if(length(tmp)==1,
            tmp1=substring(tmp1,1,length(tmp1)-1);
            parse(name+"="+tmp1);
          );
          flg=1;
          tmp2=#*WaitUnit/1000;
        );
      ,
        if(wflg==-1,
          flg=-1;
        ,
          wait(WaitUnit);
        );
      );
    );
  );
  if(flg<=0,
    ErrFlag=1;
    if(flg==-1,
      println(wfile+" does not exist");
    ,
      tmp="("+text(waiting)+" s )";
      println(wfile+" not generated "+tmp);
    );
  ,
    println("      CalcbyA succeeded "+name+" ("+text(tmp2)+" sec)");
  );
);
////%CalcbyA end////

AsfunO(name,fun,argL):=AsirfunO(name,fun,argL); // 16.02.03
AsfunO(name,fun,argL,options):=AsirfunO(name,fun,argL,options);
Asfun(name,fun,argL):=Asirfun(name,fun,argL);
Asfun(name,fun,argL,optionorg):=Asirfun(name,fun,argL,optionorg);
AsirfunO(name,fun,argL):=AsirfunO(name,fun,argL,[]);
AsirfunO(name,fun,argLorg,options):=(
//help:AsirfunO("an1","fint",["1/(x^2+1)",32,"['-','+']"]);
  regional(argL,tmp,tmp1,tmp2,eqL);// 16.05.26from
  tmp=divoptions(options);
  eqL=tmp_5;
  argL=argLorg;
  forall(eqL,
    tmp=indexof(#,"=");
    tmp1=Toupper(substring(#,0,1));
    tmp2=substring(#,tmp,length(#));
    if(tmp1=="P",  // 16.05.26from
      tmp=Toupper(substring(tmp2,0,1));
      if((tmp=="T") % (tmp=="Y"),
        tmp1=argL_(length(argL));
        tmp=indexof(tmp1,"|");
        if(tmp==0,
          argL_(length(argL))=tmp1+"|dumb=-1,dviout=-2";
        );
      );
    );
  ); // 16.05.26until
  Asirfun(name,"os_md."+fun,argL,options);
);
Asirfun(name,fun,argL):=Asirfun(name,fun,argL,[]);
Asirfun(name,fun,argL,optionorg):=(
//help:Asirfun("al1","2*(3+5^4)",[],[""]);
  regional(nm,options,eqL,precise,disp,process,
       cmdL,tmp,tmp1,tmp2,tmp3,tmp4,out,out2);
  nm="as"+name;
  options=optionorg;
  tmp=divoptions(options);
  precise=6;
  disp=1;
  process=0;
  eqL=tmp_5;
  forall(eqL,
    tmp=indexof(#,"=");
    tmp1=Toupper(substring(#,0,1)); //181111
    tmp2=substring(#,tmp,length(#));
    if(tmp1=="P",
      precise=parse(tmp2);
      options=remove(options,[#]);
    );
    if(tmp1=="D",
      tmp=Toupper(substring(tmp2,0,1));
      if((tmp=="F") % (tmp=="N"),
        disp=0;
      );
      options=remove(options,[#]);
    );
    if(tmp1=="PRO",  // 16.05.26from
      tmp=Toupper(substring(tmp2,0,1));
      if((tmp=="T") % (tmp=="Y"),
        process=1;
      );
      options=remove(options,[#]);
    );  // 16.05.26upt
  );
  tmp=replace(Dirlib,"\","/");
  cmdL=[
    "load",[Dq+tmp+"/oshima/os_muldif.rr"+Dq], // 16.03.11
    "ctrl",[Dq+"real_digit"+Dq,precise],
    "A="+fun,argL,  // 16.05.26from
    "A",[]
  ];
  CalcbyA(nm,cmdL,options);
  out=parse(nm);  //16.05.26from
  if(process==1,
    tmp1=Bracket(out,"[]");
    tmp2=select(tmp1,abs(#_2)==2);
    tmp2=apply(tmp2,#_1);
    out=[];
    forall(1..length(tmp2)/2,
      tmp3=tmp2_(2*#-1);
      tmp4=tmp2_(2*#);
      tmp=substring(as1,tmp3+1,tmp4-2);
      tmp=tokenize(tmp,"],[");
      out=append(out,tmp);
    );
    out2=[];
    forall(out,tmp2,
      tmp4="";
      forall(tmp2,tmp3,
        tmp1=tokenize(tmp3,",");
        if(tmp1_1==0,
          tmp4=tmp4+tmp1_2+"="+tmp1_3+"+";
        ,
          if(tmp1_1==1,
            tmp4=tmp4+tmp1_2+"+";
          ,
            tmp="'integrate(";
            forall(2..length(tmp1),
              tmp=tmp+tmp1_#+"+";
            );
            tmp=substring(tmp,0,length(tmp)-1);
            tmp=tmp+","+tmp1_1+")";
            tmp4=tmp4+tmp+"+";
          );
        );
      );
      tmp4=substring(tmp4,0,length(tmp4)-1);
      out2=append(out2,tmp4);
    );
    out=out2;
    tmp=apply(out,Dq+#+Dq);
    parse(nm+"="+tmp);
  );
  if(ErrFlag==0,
    if(disp==1, // 15.11.24
      println(nm+" is : ");
      println(parse(nm));
    );
  );
  out;  //16.05.26until
);

WritetoM(fname,cmdL,allflg):=(
// help:WritetoM("outdata",cmdL);
  regional(tmp,tmp1,tmp2,filename,wfilename,outflg);
  if(indexof(fname,".")==0,
    filename=fname+".max";
  ,
    filename=fname;
  );
  wfilename=replace(filename,".max",".txt");
  SCEOUTPUT = openfile(filename);
  outflg=0;
  forall(1..(length(cmdL)),
    tmp1=cmdL_#;

    if(allflg==1,  // 2016.02.23 from
      if(#==1,
        tmp="writefile("+Dq+Dirwork+"/"+wfilename+Dq+")$/*##*/";
        tmp=replace(tmp,"\","/");
        println(SCEOUTPUT,tmp);
        outflg=1;
        println(SCEOUTPUT,tmp1+"$/*##*/");
      ,
        println(SCEOUTPUT,tmp1+"$/*##*/");
      );
    ,
      if((indexof(tmp1,"disp(")>0) & (outflg==0),
        tmp="writefile("+Dq+Dirwork+"/"+wfilename+Dq+")$/*##*/";
        tmp=replace(tmp,"\","/");
        println(SCEOUTPUT,tmp);
        outflg=1;
        println(SCEOUTPUT,tmp1+"$/*##*/");
      ,
        println(SCEOUTPUT,tmp1+"$/*##*/");
      );
    );
  );
  closefile(SCEOUTPUT);
);

////%kcM start////
kcM(fname):=kcM(fname,[]);
kcM(fname,optionorg):=(
//help:kcM("boxdata");
//help:kcM(options=["r/m"]);
  regional(options,tmp,tmp1,tmp2,eqL,strL,filename,flg);
  if(indexof(fname,".")==0,
    filename=fname+".max";
  ,
    filename=fname;
  );
  options=optionorg;
  tmp=Divoptions(options);
  eqL=tmp_5;
  strL=tmp_7;
  forall(eqL,
    tmp=indexof(#,"=");
    tmp1=substring(#,0,tmp-1);
    tmp2=substring(#,tmp,length(#));
  ); 
  flg=0;
  forall(strL,
    if(Toupper(substring(#,0,1))=="R",
      flg=0;
      options=remove(options,[#]);
    );
    if(Toupper(substring(#,0,1))=="M",
      flg=1;
    );
  );
  if(flg==0,
    tmp2=replace(filename,".max",".txt");
    tmp1=load(tmp2);
    if(length(tmp1)==0,
      flg=1;
    ); 
  );
  if(flg==1,
    tmp1=""; 
    if(iswindows(),
      tmp2=Batparent;
    ,
      tmp2=Shellparent;
    );
    flg=0;
    forall(reverse(1..length(tmp2)),
      if(flg==0,
        tmp=substring(tmp2,#-1,#);
        if(tmp=="/" % tmp=="\",  // 14.01.15
          tmp1=substring(tmp2,0,#-1);
          tmp2=substring(tmp2,#,length(tmp2));
          flg=1;
        );
      );
    );
    if(length(tmp1)>0,
      setdirectory(tmp1);
    ); 
    if(iswindows(),
      SCEOUTPUT=openfile(replace(filename,".max",".txt"));
      println(SCEOUTPUT,"");
      closefile(SCEOUTPUT);
      SCEOUTPUT = openfile("kc.bat");
      println(SCEOUTPUT,"cd "+Dq+Dirwork+Dq);
//      tmp="del "+replace(filename,".max",".txt");
//      println(SCEOUTPUT,tmp);
      tmp=Indexall(PathM,".");
      tmp=substring(PathM,tmp_1,tmp_2-1);
      tmp=parse(tmp);
      if(tmp<39,
        tmp="call "+Dq+Dq+PathM+Dq+Dq+" -b "+Dq+filename+Dq;
      ,
        tmp="call "+Dq+PathM+Dq+" -b "+Dq+filename+Dq;
      );
//      tmp="cmd/c "+Dq+PathM+" -b "+filename+Dq;
      println(SCEOUTPUT,tmp); 
      println(SCEOUTPUT,"exit");
      closefile(SCEOUTPUT);
      tmp=replace(filename,".max",".txt");
      println(kc(Dirwork+Batparent,Mackc+Dirlib,tmp));// 16.05.29,06.05
    ,
      if(ismacosx(), //181125from
        SCEOUTPUT = openfile("kc.command");
      ,
        SCEOUTPUT = openfile("kc.sh");
      ); //181125to
      println(SCEOUTPUT,"#!/bin/sh");
      println(SCEOUTPUT,"cd "+Dq+Dirwork+Dq);
      tmp="rm "+replace(filename,".max",".txt");
      println(SCEOUTPUT,tmp);
      tmp=Dq+PathM+Dq+" -b "+Dq+filename+Dq;
      println(SCEOUTPUT,tmp); 
      println(SCEOUTPUT,"exit 0");
      closefile(SCEOUTPUT);
      tmp=replace(filename,".max",".txt");
      println(kc(Dirwork+Shellparent,Mackc+Dirlib,tmp));// 16.05.29,06.05
    );
//    wait(WaitUnit);
    setdirectory(Dirwork);
  );
);
////%kcM end////

////%CalcbyM start////
CalcbyM(name,cmd):=CalcbyM(name,cmd,[]);
CalcbyM(name,cmd,optionorg):=(
//help:CalcbyM("a",cmdL);
//help:CalcbyM(options1= ["m/r","Wait=5","Ext=txt","Dig=6","Pow=no","All=y"]);
//help:CalcbyM(options2= ["line=1000"]);
  regional(options,tmp,tmp0,tmp1,tmp2,tmp3,tmp4,realL,strL,eqL,allflg,indL,line,
      dig,flg,wflg,file,nc,arg,add,powerd,cmdM,cmdlist,wfile,ext,waiting,num,st);
  options=optionorg;
  tmp=divoptions(options);
  eqL=tmp_5;
  realL=tmp_6;
  strL=tmp_7;
  wfile="";
  ext=".txt";
  waiting=5;
  dig=6;
  allflg=1;
  powerd="false";
  line=1000; // 16.06.13
  forall(eqL,
    tmp=indexof(#,"=");
    tmp1=Toupper(substring(#,0,1));
    tmp2=substring(#,tmp,length(#));
    if(tmp1=="E",
      if(indexof(tmp2,".")==0,ext="."+tmp2,ext=tmp2);
      options=remove(options,[#]);
    );
    if(tmp1=="W",
      waiting=parse(tmp2);
      options=remove(options,[#]);
    );
    if(tmp1=="D",
      dig=parse(tmp2);
      options=remove(options,[#]);
    );
    if(tmp1=="L",  // 16.06.13
      line=parse(tmp2);
      options=remove(options,[#]);
    );
    if(tmp1=="P",
      tmp=Toupper(substring(tmp2,0,1));
      if((tmp=="y") % (tmp=="F"),powerd="true");
      options=remove(options,[#]);
    );
    if(tmp1=="A", // 2016.02.23
      tmp=Toupper(substring(tmp2,0,1));
      if((tmp=="N") % (tmp=="F"),allflg=0);
      options=remove(options,[#]);
    );
  );
  wfile=Fhead+name+ext;
  wflg=0;
  forall(strL,
    tmp=Toupper(substring(#,0,1));
    if(tmp=="M",
      wflg=1;
      options=remove(options,[#]);
    );
    if(tmp=="R",
      wflg=-1;
      options=remove(options,[#]);
    );
  );
  file=Fhead+name;
  cmdM=cmd;
  cmdlist=[
    "powerdisp:"+powerd,"display2d:false","linel:"+text(line)  //15.11.25,16.06.13
  ];
  forall(1..floor(length(cmdM)/2),nc, //17.5.18
    tmp1=replace(cmdM_(2*nc-1),"`","'");//2016.02.23
    tmp1=replace(tmp1,LFmark,""); // 16.06.12
    if(nc==length(cmdM)/2,
      tmp=indexof(tmp1,"=");
      tmp1=substring(tmp1,tmp,length(tmp1));
      if(substring(tmp1,0,1)=="[",
        tmp=substring(tmp1,0,length(tmp1)-1);
      ,
        tmp="["+tmp1;
      );
      tmp2="";
      forall(1..length(tmp1),
         if(substring(tmp1,#-1,#+1)=="::",
         if(substring(tmp2,0,1)==":", tmp2=substring(tmp2,1,length(tmp2)));
           cmdlist=append(cmdlist,"disp("+tmp2+")");
           tmp2="";
         ,
            tmp2=tmp2+substring(tmp1,#-1,#);
         );
      );
      if(length(tmp2)>0,
         if(substring(tmp2,0,1)==":", tmp2=substring(tmp2,1,length(tmp2)));
         cmdlist=append(cmdlist,"disp("+tmp2+")");
      );
    ,
      tmp2=cmdM_(2*nc);  // list of argments
      tmp3="";
      tmp4="";
      add="";
      forall(tmp2,arg,
        if(isstring(arg),
          if(substring(arg,0,1)!=",",
//            tmp=replace(arg,"'",Dq);  // 16.03.03
            tmp=arg;   // 16.03.03
            tmp=replace(tmp,"`","'");// 2016.02.23
            tmp3=tmp3+tmp+",";
          ,
            add=add+arg; 
          );
        ,
          if(!islist(arg),
            tmp3=tmp3+textformat(arg,dig)+",";
          ,
            tmp3=tmp3+"[";
            tmp4="]";
            forall(arg,
              if(isstring(#),
//                tmp3=tmp3+Dq+#+Dq+",";
                tmp=replace(#,"'",Dq);
                tmp3=tmp3+tmp+",";
              ,
                if(!islist(#),  
                  tmp3=tmp3+textformat(#,dig)+",";
                ,
                  tmp=textformat(#,dig);
                  tmp=replace(tmp,"],[","];[");
                  tmp3=tmp3+tmp+",";
                );
              );
            );
            tmp3=substring(tmp3,0,length(tmp3)-1)+tmp4+",";
          );
        );
      );
      if(length(tmp3)>0,
        tmp3=substring(tmp3,0,length(tmp3)-1);
        tmp1=tmp1+"("+tmp3+")"+add;
      );
      cmdlist=append(cmdlist,tmp1);
    );
  );
  cmdlist=append(cmdlist,"closefile()");
  cmdlist=append(cmdlist,"quit()");
  if(wflg==0,
    tmp1=load(file+".max");
    if(length(tmp1)==0,
      wflg=1;
    ,
      if(indexof(tmp1,"/*##*/")==0,  // 15.11.26
        wflg=1;
      ,
        tmp1=tokenize(tmp1,"/*##*/");
        tmp1=tmp1_(1..(length(tmp1)-1));
        tmp=select(tmp1,indexof(#,"writefile")>0);
        tmp1=remove(tmp1,tmp);
        tmp1=apply(tmp1,substring(#,0,length(#)-1));
        if(length(tmp1)!=length(cmdlist),  // 15.12.07
          wflg=1;
        ,
          tmp=select(1..length(tmp1),tmp1_#!=cmdlist_#);
          if(length(tmp)>0, wflg=1);
        );
      );
    );
  ); 
  if(wflg==0,wflg=-1); // 15.10.16
  if(wflg==1,
    if(length(wfile)>0,   // 15.10.05
      SCEOUTPUT=openfile(wfile);
      println(SCEOUTPUT,"");
      closefile(SCEOUTPUT);
    );
    WritetoM(file+".max",cmdlist,allflg); // 2016.02.23
    kcM(file,concat(options,["m"]));
  );
  flg=0;
  tmp1=floor(waiting*1000/WaitUnit);
  repeat(tmp1,
    if(flg==0,
      tmp1=load(wfile);
      if(wflg==1,wait(WaitUnit)); // 2016.02.23
      if(length(tmp1)>0,
        tmp=indexof(tmp1,"error")+indexof(tmp1,"syntax"); //2016.02.23
        if(tmp>0,
          println("Some error(s) occurred"); //2016.02.24 from
          tmp2=tokenize(tmp1,"(%");
          forall(4..length(tmp2),println(tmp2_#)); //2016.02.24 until
          flg=2;  //2016.02.23
        ,
          if(indexof(tmp1,"closefile()")>0,  // 15.11.24
            tmp=tokenize(tmp1,"disp(");
            tmp1=tmp_(2..length(tmp));
            tmp4=[];
            forall(tmp1,tmp2,
              tmp=indexof(tmp2,")");
              tmp3=substring(tmp2,tmp,length(tmp2));
              indL=Indexall(tmp3,"(%i"); // 16.04.26from
              tmp0=0;
              forall(indL,
                if(tmp0==0,
                  tmp=substring(tmp3,#+2,#+3);
                  if(indexof("0123456789",tmp)>0,//16.04.25?
                    tmp3=removespace(substring(tmp3,0,#-1));
                    tmp4=append(tmp4,tmp3);
                    tmp0=1;
                  );
                );// 16.04.26until
              );
            );
            num="1234567890+-.";
            tmp1="[";
            forall(tmp4,st,
              tmp=select(1..length(st),indexof(num,substring(st,#-1,#))==0);
              if((length(tmp)==0) & (length(st)<4), // 16.05.10 16=>4
                tmp1=tmp1+st+",";
              ,
                tmp1=tmp1+Dq+st+Dq+",";
              );
            );
            tmp1=substring(tmp1,0,length(tmp1)-1)+"]";
            tmp1=replace(tmp1,".d+0",""); // 15.11.23
            parse(name+"="+tmp1);
            tmp=parse(name);
            if(length(tmp)==1,
              tmp1=substring(tmp1,1,length(tmp1)-1);
              parse(name+"="+tmp1);
            );
            flg=1;
            tmp2=#*WaitUnit/1000;
          );
        );
      ,
        if(wflg==-1,
          flg=-1;
        ,
          wait(WaitUnit);
        );
      );
    );
  );
  if(flg<=0,
    ErrFlag=1;
    if(flg==-1,
      println(wfile+" does not exist");
    ,
      tmp="("+text(waiting)+" s )";
      tmp1=load(wfile);
      if(length(tmp1)>0,
        println(wfile+" incomplete"+tmp); // 2016.02.24
      ,
        println(wfile+" not generated "+tmp);
      );
    );
  ,
    if(flg==1,  // 2016.02.23
      println("      CalcbyM succeeded "+name+" ("+text(tmp2)+" sec)");
    );
  );
);
////%CalcbyM end////

////%Mxfun start////
Mxfun(name,fun,argL):=Mxfun(name,fun,argL,[]);
Mxfun(name,fun,argL,optionorg):=(
//help:Mxfun("ca1","diff",["sin(x)^3","x"],[""]);
//help:Mxfun(options=["Pre=6","Disp=y","Load= :: ","Set=::","Add="]);
  regional(nm,options,eqL,precise,disp,pack,set,add,cmdL,tmp,tmp1,tmp2);
  nm="mx"+name;
  options=optionorg;
  tmp=divoptions(options);
  precise=6;
  disp=1;
  pack=[];
  set=[];
  add="";
  eqL=tmp_5;
  forall(eqL,
    tmp=indexof(#,"=");
    tmp1=Toupper(substring(#,0,1));
    tmp2=substring(#,tmp,length(#));
    if(tmp1=="P",
      precise=parse(tmp2);
      options=remove(options,[#]);
    );
    if(tmp1=="DIS" ,
      tmp=Toupper(substring(tmp2,0,1));
      if((tmp=="F") % (tmp=="N"),
        disp=0;
      );
      options=remove(options,[#]);
    );
    if((tmp1=="PAC") % (tmp1=="LOA"), // 16.02.08
      pack=tokenize(tmp2,"::");
      options=remove(options,[#]);
    );
    if(tmp1=="SET",
      set=tokenize(tmp2,"::");
      options=remove(options,[#]);
    );
    if(tmp1=="ADD",
      add=","+tmp2;
      options=remove(options,[#]);
    );
  );
  cmdL=[];
  forall(pack,
    cmdL=concat(cmdL,["load",[#]]);
  );
  forall(set,
    cmdL=concat(cmdL,[#,[]]);
  );
  if(length(add)>0,
    tmp=append(argL,add);
  ,
    tmp=argL;
  );
  cmdL=concat(cmdL,[
    "ans"+":"+fun,tmp,
    "ans",[]
  ]);
  CalcbyM(nm,cmdL,options);
  if(ErrFlag==0,
    if(disp==1, // 15.11.24
      println(nm+" is : ");
      println(parse(nm));
    );
  );
  parse(nm);
);
////%Mxfun end////

////%Mxtex start////
Mxtex(nm,ex):=Mxtex(nm,ex,[]);
Mxtex(nm,ex,optionorg):=(
//help:Mxtex("1","sin(x)/x");
//help:Mxtex(options=["Disp=y"]);
  regional(name,cmdL,eqL,options,tx,disp,out,set,
     tmp,tmp1,tmp2); // 16.01.25
  name="tx"+nm;
  options=optionorg;
  tmp=divoptions(options);
  eqL=tmp_5;
  disp=1;
  set=[];
  forall(eqL,
    tmp=indexof(#,"=");
    tmp1=Toupper(substring(#,0,1));
    tmp2=substring(#,tmp,length(#));
	if(tmp1=="D" ,
      tmp=Toupper(substring(tmp2,0,1));
      if((tmp=="F") % (tmp=="N"),
        disp=0;
      );
      options=remove(options,[#]);
    );
    if(tmp1=="SET",  // 16.03.01
      set=tokenize(tmp2,"::");
      options=remove(options,[#]);
    );
    if(tmp1=="ORD",  // 16.03.01
      tmp="ordergreat("+tmp2+")";
      set=append(set,tmp);
      options=remove(options,[#]);
    );
  );
  cmdL=[
    "load",[Dq+"mactex-utilities.lisp"+Dq]];  // 16.03.03
  forall(set,  // 16.03.01
    cmdL=concat(cmdL,[#,[]]);
  );
  cmdL=concat(cmdL,[
    name+":disp(tex("+ex+"))",[], // 16.01.18
    name,[]  // 16.01.18
  ]);
  CalcbyM(name,cmdL,options); // 16.02.19
  tx=parse(name);
  if(islist(tx),  // 16.01.10
    out=tx_1;
  ,
    out=tx;
  );
  tmp=indexof(out,"$$")+1;
  out=substring(out,tmp,length(out));
  tmp=indexof(out,"$$")-1;
  out=substring(out,0,tmp);
  if(disp==1,  //  16.01.10
    println(name+" is:");
    println(out);
  );
  tmp=name+"="+Dq+out+Dq; //16.01.10
  parse(tmp);
  out;
);
////%Mxtex end////

////%MxtexL start////
MxtexL(nm,exlist):=MxtexL(nm,exlist,[]);  // 16.05.27
MxtexL(nm,exlist,options):=(
  regional(out,tmp,tmp1);
  out=[];
  forall(1..length(exlist),
    tmp=Mxtex(nm+"n"+text(#),exlist_#,["Disp=n"]);
    out=append(out,Dq+tmp+Dq);
  );
  tmp="tx"+nm+"="+out;
  parse(tmp);
  println("tx"+nm+"is:");
  apply(out,println(#));
  out;
);

Mxbatch(file):=(
//help:Mxbatch(["matoperation.max"]);
  regional(figL,out,path,tmp,tmp1,tmp2);
  if(!islist(file),figL=[file],figL=file);
  path=replace(Dirlib+"/maximaL/","\","/");
  out=[];
  forall(figL,
    if(indexof(#,".")==0,tmp1=#+".max",tmp1=#);
    tmp1=Dq+path+tmp1+Dq;
    tmp2=["batch",[tmp1]];
    out=concat(out,tmp2);
  );
  out;
);
////%MxtexL end////

////%Mxload start////
Mxload(file):=( //17.06.16
//help:Mxload(["rkfun.lispp"]);
  regional(figL,out,path,tmp,tmp1,tmp2);
  if(!islist(file),figL=[file],figL=file);
  path=replace(Dirlib+"/maximaL/","\","/");
  out=[];
  forall(figL,
    if(indexof(#,".")==0,tmp1=#+".lisp",tmp1=#);
    tmp1=Dq+path+tmp1+Dq;
    tmp2=["load",[tmp1]];
    out=concat(out,tmp2);
  );
  out;
);
////%Mxload end////

////%Maxima2Cindydata start////
Maxima2Cindydata(str):=( //17.10.24
  regional(out,numstr,eL,nn,ne,flg,tmp);
  numstr="-0123456789";
  eL=Indexall(str,"e");
  if(length(eL)==0,
    out=str;
  ,
    out=substring(str,0,eL_1-1);
    forall(1..(length(eL)),nn,
      ne=eL_nn;
      flg=0;
      forall(1..5,
        if(flg==0,
          tmp=substring(str,ne+#-1,ne+#);
          if(indexof(numstr,tmp)==0,
            flg=#;
            tmp=substring(str,ne,ne+flg-1);
            out=out+"*10^("+tmp+")";
          );
        );
      );
      if(nn<length(eL),
        out=out+substring(str,ne+flg-1,eL_(nn+1)-1);
      ,
        out=out+substring(str,ne+flg-1,length(str));
      );
    );
  );
  parse(out);
);
////%Maxima2Cindydata end////

////%kcV3 start////
kcV3(fname):=kcV3(Dirwork,fname);
kcV3(path,fname):=(
//help:kcV3(path,"ex.obj");
  regional(tmp,tmp1,tmp2,eqL,strL,filename,flg);
  if(indexof(fname,".")==0,
    filename=fname+".obj";
  ,
    filename=fname;
  );
  flg=1;
  if(flg==1,
    tmp1="";     // 15.10.08 from
	if(iswindows(),
      tmp2=Batparent;
    ,
      tmp2=Shellparent;
    );
    tmp=replace(path,"\","/");
    tmp=substring(tmp,length(tmp)-1,length(tmp));
    if(tmp=="/" % tmp=="\", tmp1=path, tmp1=path+"/");
    if(iswindows(),
      SCEOUTPUT = openfile("kc.bat");
      println(SCEOUTPUT,"cd "+Dq+Dirwork+Dq);
      tmp=Dqq(PathV3)+" "+Dqq(tmp1+filename); 
      println(SCEOUTPUT,tmp); 
      println(SCEOUTPUT,"exit");
      closefile(SCEOUTPUT);
      println(kc(Dirwork+Batparent,Dirlib,Fnametex));// 16.05.29,06.05
    ,
      if(ismacosx(), //181125from
        SCEOUTPUT = openfile("kc.command");
      ,
        SCEOUTPUT = openfile("kc.sh");
      ); //181125to
      println(SCEOUTPUT,"#!/bin/sh");
      println(SCEOUTPUT,"cd "+Dq+Dirwork+Dq);
      if(PathV3=="preview", //181202from
         tmp="open -a "+Dqq("preview");
     ,
        tmp=Dqq(PathV3);
      );
      tmp=tmp+" "+Dqq(tmp1+filename); //181202to
      println(SCEOUTPUT,tmp); 
      println(SCEOUTPUT,"exit 0");
      closefile(SCEOUTPUT);
      println(kc(Dirwork+Shellparent,Mackc+Dirlib,Fnametex));// 16.05.29,06.05
    );
    wait(WaitUnit);
  );
  if(fig==2,
    println("Obj file not exist / imperfect");
  );
);

////%Changeobjscale start////
Changeobjscale(fname):=(
  regional(fout);
  fout=replace(fname,".obj","");
  fout=fout+"out.obj";
  Changeobjscale(ULEN,fname,fout,[]);
);
Changeobjscale(fname,Arg):=(
  regional(fout);
  if(islist(Arg),
    fout=replace(fname,".obj","");
    fout=fout+"out.obj";
    Changeobjscale(ULEN,fname,fout,Arg);
  ,
    Changeobjscale(ULEN,fname,Arg,[]);
  );
);
Changeobjscale(Arg1,Arg2,Arg3):=(
  if(islist(Arg3),
    Changeobjscale(ULEN,Arg1,Arg2,Arg3);
  ,
    Changeobjscale(Arg1,Arg2,Arg3,[]);
  );
);
Changeobjscale(unitlen,fnameorg,foutorg,optionorg):=(
//help:Changeobjscale("20mm",fname,fnameout);
//help:Changeobjscale(options=["Unit=mm",[0,0,0]]);
  regional(fname,fout,fmd,unit,val,options,eqL,reL,
      origin,outunit,sc,stL,nn,tmp,tmp1,tmp2);
  options=optionorg;
  tmp=Divoptions(options);
  eqL=tmp_5;
  reL=tmp_6;
  outunit="IN";
  forall(eqL,
    tmp=indexof(#,"=");
    tmp1=Toupper(substring(#,0,1));
    tmp2=Toupper(substring(#,tmp,length(#)));
    if(tmp1=="O" % tmp1=="U",
      outunit=tmp2;
      options=remove(options,[#]);
    );
  );
  options=remove(options,reL);
  origin=[0,0,0];
  forall(reL,
    if(islist(#),origin=#);
  );
  options=remove(options,reL);
  tmp1=".0123456789+-*/";
  unit="";
  val=1;
  tmp2=0;
  forall(reverse(1..length(unitlen)),
    tmp=substring(unitlen,#-1,#);
    if(tmp2==0,
      if(indexof(tmp1,tmp)>0,
        tmp2=#;
      );
    );
    unit=substring(unitlen,tmp2,length(unitlen));
    unit=removespace(unit);
    val=parse(substring(unitlen,0,tmp2));
  );
  sc=1;
  if(unit=="cm",sc=1);
  if(unit=="mm",sc=0.1);
  if(unit=="in",sc=2.54);
  sc=sc*val;
  if(outunit=="IN",sc=sc/2.54);
  if(outunit=="MM",sc=sc*10);
  fname=fnameorg;
  if(indexof(fname,".")==0,fname=fname+".obj");
  fmd=replace(fname,".obj",".txt");
  fout=foutorg;
  if(indexof(fout,".")==0,fout=fout+".obj");
  tmp1=Textformat(origin,4);
  tmp1=RSform(tmp1);
  cmdL=[
    "Origin="+tmp1,[],
    "Sc="+format(sc,6),[],
    "Stv=readLines",[Dq+fname+Dq],
    "cat('',file="+Dq+fout+Dq+")",[],
    "for(nn in Looprange(1,length(Stv))){",[],
    "  if(substring(Stv[nn],1,2)=='v '){",[],
    "    Tmp1=paste('c(',substring(Stv[nn],3),')',sep='')",[],
    "    Tmp1=gsub(' ',',',Tmp1,fixed=TRUE)",[],
    "    Tmp1=gsub(',,',',',Tmp1,fixed=TRUE)",[],
    "    Tmp1=gsub('(,','(',Tmp1,fixed=TRUE)",[],
    "    Tmp=eval(parse(text=Tmp1))",[],
    "    Tmp=Origin+Sc*(Tmp-Origin)",[],
    "    Stv[nn]=paste('v ',sprintf('%8.5f %8.5f %8.5f',Tmp[1],Tmp[2],Tmp[3]),sep='')",[],
    "  }",[],
    "  cat(Stv[nn],'\n',sep='',file="+Dq+fout+Dq+",append=TRUE)",[],
    "}",[]
  ];
  options=concat(["Wait=3","Cat=n","File="+fmd],options); // 16.06.26
  CalcbyR("cs",cmdL,options);
  println("Scale of "+fname+" changed");
);
////%Changeobjscale end////

////%Setobj start////
//Objname(str):=Objname(str,["m","v"]); //180906from
//Objname(str,options):=Setobj(str,options);
Setobj():=Setobj(Fhead,["m","v"]); //180901
Setobj(Arg1):=(
  if(isstring(Arg1),
    Setobj(Arg1,["m","v"]); //17.01.12
  ,
    Setobj(Fhead,Arg1); //180902
  );
);
Setobj(str,optionsorg):=( //180906to
//help:Setobj();
//help:Setobj(["v"]);
//help:Setobj(options=["m","v","preview","Zax=y(/n)"]);
  regional(options,tmp,strL);
  options=select(optionsorg,length(#)>0); //17.12.23from
  tmp=Divoptions(options); //181203from
  strL=tmp_7;
  forall(strL,
    if(Toupper(substring(#,0,1))=="P",
      PathV3="preview";
      options=remove(options,[#]);
    );
  ); //181203to
  if(length(str)>0,
    OCNAME=str;
  );
  if(length(options)>0,
    OCOPTION=options;
  ,
    OCOPTION=["m","v"];
  ); //17.12.23until
  println("generate OBJCMD. name="+OCNAME+", option="+OCOPTION);
);
////%Setobj end////

////%Mkviewobj start////
Mkviewobj():=Mkviewobj(OCNAME,OBJCMD,OCOPTION); //181209
Mkviewobj(fname,cmdL):=Mkviewobj(Dirwork,fname,cmdL,[]);
Mkviewobj(Arg1,Arg2,Arg3):=(
  if(!isstring(OCNAME), //17.04.13from
    drawtext(mouse().xy,"Mkobjcmd not defined",
        size->24,color->[1,0,0]);
  , //17.04.13until
    if(islist(Arg2),
      Mkviewobj(Dirwork,Arg1,Arg2,Arg3);
    ,
      Mkviewobj(Arg1,Arg2,Arg3,[]);
    );
  );
);
Mkviewobj(pathorg,fnameorg,cmdLorg,optionorg):=(
//help:Mkviewobj();
  regional(path,cmdL,eqL,strL,flg,fname,options,make,view,cmdlist,
      vtx,face,unit,tmp,tmp1,tmp2,store,dt,nn,zax);
  store=Fillblack(); //181128
println([3647,store]);
  path=replace(pathorg,"\","/");
  if(substring(path,length(path)-1,length(path))!="/",path=path+"/");
  fname=fnameorg;
  if(indexof(fname,".")==0,fname=fname+".obj");
  cmdL=cmdLorg;
  options=optionorg;
  tmp=divoptions(options);
  eqL=tmp_5;
  strL=tmp_7;
  make=-1;
  view=0;
  unit="";
  zax="Y";
  forall(eqL,
    tmp=Strsplit(#,"=");
    tmp1=Toupper(substring(tmp_1,0,1));
    if(tmp1=="U", // 16.06.30from
      unit=tmp2;
      options=remove(options,[#]);
    ); // 16.06.30to
    if(tmp1=="Z", // 16.06.30from
      zax=Toupper(substring(tmp_2,0,1));
      options=remove(options,[#]);
    ); // 16.06.30to
  );
  forall(strL,
    tmp=Toupper(substring(#,0,1));
    if(tmp=="M",
      make=1;
//      options=remove(options,[#]); //181203
    );
    if(tmp=="R",
      make=0;
//      options=remove(options,[#]); //181203
    );
    if(tmp=="V",
      view=1;
      options=remove(options,[#]);
    );
  );
  if(islist(cmdL),
    if(length(cmdL)==0,
      make=0;
      println("Command sequence not defnamed");
    );
  ,
    make=0;
    println("Command sequence not defined");
  );
  if(make==-1,
    setdirectory(pathorg);
    tmp1=load(fname);
    if(length(tmp1)==0,make=1,make=0);
    setdirectory(Dirwork);
  );
  if(make==1,
    if(isstring(cmdL_1),
      cmdlist=MkprecommandR();
      cmdlist=concat(cmdlist,["Openobj",[Dq+path+fname+Dq]]);
      cmdlist=concat(cmdlist,cmdL);
      tmp=["Closeobj()",[]];//181130
      cmdlist=concat(cmdlist,tmp);
      tmp1=apply(options,Toupper(substring(#,0,1))); // 16.04.23from
      tmp1=select(tmp1,#=="W");
      if(length(tmp1)==0,
        tmp=append(tmp,"Wait=10");
      );// 16.04.23to
      CalcbyR("",cmdlist,tmp); //180902
      wait(WaitUnit*100); // 16.03.18
    ,
      vtx=cmdL_1;
      face=cmdL_2;
      setdirectory(pathorg);
      SCEOUTPUT = openfile(fname);
      forall(vtx,tmp1,
        tmp2=tmp1;
        if(ispoint(tmp1),
          tmp2=parse(text(tmp1)+"3d");
        );
        tmp2=apply(tmp2,format(#,5));
        tmp="v "+tmp2_1+" "+tmp2_2+" "+tmp2_3;
        println(SCEOUTPUT,tmp);
      );
      forall(face,tmp1,
        tmp="f";
        forall(tmp1,
          tmp=tmp+" "+text(#);
        );
        println(SCEOUTPUT,tmp);
      );
      closefile(SCEOUTPUT);  
      setdirectory(Dirwork);
    );
  );
  if(length(unit)>0, // 16.06.30from
    Changeobjscale(fname,["Unit="+unit]);//16.10.04 
  );  // 16.06.30until
  if(view==1,
    if((PathV3=="preview")%(zax=="Y"), //181209
      dt=Readlines(fname);
      forall(1..(length(dt)),nn,
        tmp1=dt_nn;
        if(substring(tmp1,0,2)=="v ",
        tmp=replace(tmp1,"  "," ");
        tmp=tokenize(tmp," ");
        tmp=Sprintf(tmp_(2..4),4);
        tmp2="v "+tmp_2+" "+tmp_3+" "+tmp_1;
        dt_nn=tmp2;
        );
      );
      fname=replace(fname,".","prv.");
      SCEOUTPUT = openfile(fname);
      forall(dt,
        println(SCEOUTPUT,#);
      );
      closefile(SCEOUTPUT);
    );
    kcV3(path,fname);
  );
  Fillrestore(store); //181128
);
////%Mkviewobj end////

////%Mkobjcmd start////
Mkobjcmd(nm,fd):=Mkobjcmd(nm,fd,[40,40,"+"]);
Mkobjcmd(nm,fd,options):=(
//help:Mkobjcmd("1",fd,[40,40,"+"]);
  regional(ffd,cmd,out,div1,div2,side,
    reL,stL,tmp,tmp1,tmp2,tmp3,tmp4);
  div1=40;
  div2=40;
  side="+";
  tmp=Divoptions(options);
  reL=tmp_6;
  stL=select(tmp_7,length(#)>0);
  forall(1..length(reL),
    if(#==1,
      div1=reL_1;
      div2=div1;
    ,
      div2=reL_2;
    );
  );
  forall(stL,
    side=#;
  );
  side="'"+side+"'";
  ffd=Fullformfunc(fd);
  tmp=indexof(ffd_5,"=");
  tmp1=RSform(substring(ffd_5,0,tmp-1));
  tmp2=RSform(substring(ffd_5,tmp,length(ffd_5)));
  tmp=indexof(ffd_6,"=");
  tmp3=RSform(substring(ffd_6,0,tmp-1));
  tmp4=RSform(substring(ffd_6,tmp,length(ffd_6)));
  out=["Fun"+nm+"<- function("+tmp1+","+tmp3+"){",[]];
  tmp="  Out=c("+ffd_2+","+ffd_3+","+ffd_4+")";
  out=concat(out,[tmp,[]]);
  out=concat(out,["}",[]]);
  tmp1=["Objsurf",
     ["Fun"+nm,tmp2,tmp4,div1,div2,side]];
  out=concat(out,tmp1);
  tmp2=[]; // 16.06.10from
  forall(out,tmp1,
    if(islist(tmp1),
      tmp=apply(tmp1,if(isstring(#),Dq+#+Dq,Textformat(#,5)));
    ,
      if(isstring(tmp1),tmp=Dq+tmp1+Dq,tmp=Textformat(#,5));
    );
    tmp2=append(tmp2,tmp);
  );
  parse("oc"+nm+"="+tmp2);
  println("cmd seq oc"+nm+" generated"); // 16.06.10until
  OBJCMD=concat(OBJCMD,out);//16.11.29
  out;
);
////%Mkobjcmd end////

////%Mkobjnrm start////
Mkobjnrm(nm,fd):=Mkobjnrm(nm,fd,[]);
Mkobjnrm(nm,fd,optionorg):=(
//help:Mkobjnrm("1",fd1,["Disp=y"]);
//help:Mkobjnrm("1","[x,y,x*y/(x^2+y^2)],x,y");
  regional(name,options,stL,eqL,disp,ffd,fst,xst,yst,cmdL,
    precmd,out,tmp,tmp1,tmp2,tmp3);
  name="nrm"+nm;
  options=select(optionorg,length(#)>0);
  tmp=Divoptions(options);
  eqL=tmp_5;
  stL=tmp_7;
  precmd=[];
  disp="N";
  forall(eqL,  // 16.05.02
    tmp1=Toupper(substring(#,0,1));
    tmp=indexof(#,"=");
    tmp2=Toupper(substring(#,tmp,tmp+1));
    if(tmp1=="D",
      if(tmp2=="Y" % tmp2=="T",
        disp="Y";
        options=remove(options,[#]);
      );
    );
  );
  forall(stL,
    if(indexof(#,"+")+indexof(#,"-")==0,
      precmd=concat(precmd,[#,[]]);
      options=remove(options,[#]);
    );
  );
  if(isstring(fd),
    tmp=Indexall(fd,",");
    fst=[
      substring(fd,1,tmp_1-1),
      substring(fd,tmp_1,tmp_2-1),
      substring(fd,tmp_2,tmp_3-2)
    ];
    xst=substring(fd,tmp_3,tmp_4-1);
    yst=substring(fd,tmp_4,length(fd));
  ,
    ffd=Fullformfunc(fd);
    fst=text(ffd_(2..4));
    tmp=indexof(ffd_5,"=");
    xst=substring(ffd_5,0,tmp-1);
    tmp=indexof(ffd_6,"=");
    yst=substring(ffd_6,0,tmp-1);
  );
  cmdL=precmd;
  cmdL=concat(cmdL,[
    "fx:diff",[fst,xst],
    "fy:diff",[fst,yst],
    "nx:fx[2]*fy[3]-fx[3]*fy[2]",[],
    "ny:fx[3]*fy[1]-fx[1]*fy[3]",[],
    "nz:fx[1]*fy[2]-fx[2]*fy[1]",[],
    "nn:factor(nx^2+ny^2+nz^2)",[], // 16.04.21
    "nn:sqrt(nn)",[], // 16.04.20
    "nx:nx/nn",[],
    "ny:ny/nn",[],
    "nz:nz/nn",[],
    "n:[nx,ny,nz]",[], // 16.04.21from
    "n:ratsimp(n)",[], 
    "n:trigsimp(n)",[],
    "n:factor(n)",[], // 16.04.21until
    "n",[]
  ]);
  CalcbyM(name,cmdL,options); // 16.05.12
  tmp1=parse(name); // 16.05.12
  out=[tmp1];  // 15.04.21b from
  tmp2=[];
  forall(1..3,
    tmp=indexof(tmp1,",");
    if(tmp==0,
      tmp=indexof(tmp1,"]");
    );
    tmp3=substring(tmp1,0,tmp-1);
    tmp1=substring(tmp1,tmp,length(tmp1));
    tmp=indexof(tmp3,"/");
    if(tmp>0,
      tmp3=substring(tmp3,tmp,length(tmp3));
      tmp2=append(tmp2,tmp3);
    ,
      tmp2=append(tmp2,"1");
    ); 
  );
//  out=append(out,tmp2);
  out=out_1; // 16.05.02from
  println("calculate "+name+":"); // 16.05.12
  if(disp=="Y", // 16.05.02
    println(out);
    //  println(out_2); 
  ); // 16.05.02until
  out;
);
////%Mkobjnrm end////

////%Mkobjthickcmd start////
Mkobjthickcmd(nm,fd):=Mkobjthickcmd(nm,fd,"",[40,40,"+"]);
Mkobjthickcmd(nm,fd,Arg):=(
  if(islist(Arg),
    Mkobjthickcmd(nm,fd,"",Arg);
  ,
    Mkobjthickcmd(nm,fd,Arg,[]);
  );
);
Mkobjthickcmd(nm,fd,fnrm,optionorg):=(
//help:Mkobjthickcmd("1",fd,["assume(R>0)"]);
//help:Mkobjthickcmd("1",fd,fnorm);
//help:Mkobjthickcmd(options1=[40,40,0.05,-0.05,"+n+s+e+w+"]);
//help:Mkobjthickcmd(options2=["ratsimp","trigsimp"]);
  regional(options,ffd,cmd,out,div1,div2,thick1,thick2,side,
     reL,stL,addcmd,fst,xst,yst,tmp,tmp1,tmp2,tmp3,tmp4);
  div1=40;
  div2=40;
  thick1=0.05;
  thick2=-0.05;
  side="+n+s+e+w+";
  options=select(optionorg,length(#)>0);
  tmp=Divoptions(options);
  reL=tmp_6;
  stL=tmp_7;
  tmp1=1;  // 16.04.21from
  tmp2=1;
  forall(1..length(reL),
    tmp=reL_#;
    if(tmp>1,
      if(tmp1==1,
        div1=tmp;
        div2=tmp;
      ,
        div2=tmp;
      );
      tmp1=tmp1+1;
    ,
      if(tmp2==1,
        thick1=tmp;
        thick2=-tmp;
      ,
        thick2=tmp;
      );
      tmp2=tmp2+1;
    );
  );  // 16.04.21until
  options=remove(options,reL);
  forall(stL,
    if(length(#)>0,
      tmp=indexof(#,"+")+indexof(#,"-");
      if(tmp>0,
        side=#;
        options=remove(options,[#]);
      );
    );
  );
  side="'"+side+"'";
  ffd=Fullformfunc(fd);
  tmp=indexof(ffd_5,"=");
  tmp1=substring(ffd_5,0,tmp-1);
  tmp2=RSform(substring(ffd_5,tmp,length(ffd_5)));
  tmp=indexof(ffd_6,"=");
  tmp3=substring(ffd_6,0,tmp-1);
  tmp4=RSform(substring(ffd_6,tmp,length(ffd_6)));
  fst=text(ffd_(2..4));
  tmp=indexof(ffd_5,"=");
  xst=substring(ffd_5,0,tmp-1);
  tmp=indexof(ffd_6,"=");
  yst=substring(ffd_6,0,tmp-1);
  out=["Fun"+nm+"<- function("+tmp1+","+tmp3+"){",[]];
  tmp="  c("+ffd_2+","+ffd_3+","+ffd_4+")";
  out=concat(out,[tmp,[]]);
  out=concat(out,["}",[]]);
  tmp=["Fnrm"+nm+"<- function("+xst+","+yst+"){",[]];
  out=concat(out,tmp);
  if(fnrm=="",
    tmp=Mkobjnrm(nm,fd,options);
    tmp1=RSform(tmp);
    tmp="Fnrmden"+nm+"("+xst+","+yst+"):="+tmp_2;
    parse(tmp);
  ,
    tmp1=RSform(fnrm);
//    if(indexof(tmp1,"Out=")==0,  // 16.05.09from
//      tmp1="Out="+tmp1;
//    ); // 16.05.09until
  );
  out=concat(out,[tmp1,[]]);
  out=concat(out,["}",[]]);
  tmp1=["Objthicksurf",
     ["Fun"+nm,tmp2,tmp4,div1,div2,"Fnrm"+nm,thick1,thick2,side]];
  out=concat(out,tmp1);
  tmp2=[]; // 16.06.10from
  forall(out,tmp1,
    if(islist(tmp1),
      tmp=apply(tmp1,if(isstring(#),Dq+#+Dq,Textformat(#,5)));
    ,
      if(isstring(tmp1),tmp=Dq+tmp1+Dq,tmp=Textformat(#,5));
    );
    tmp2=append(tmp2,tmp);
  );
  parse("oc"+nm+"="+tmp2);
  println("cmd seq oc"+nm+" generated"); // 16.06.10until
  OBJCMD=concat(OBJCMD,out);//16.11.29
  out;
);
////%Mkobjthickcmd end////


////%Mkobjpolycmd start////
Mkobjpolycmd(nm,pd):=Mkobjpolycmd(nm,pd,[]);
Mkobjpolycmd(nm,pd,optionorg):=(
//help:Mkobjpolycmd("1",pd);
//help:Mkobjpolycmd(options1=[internal([0,0,0])]);
  regional(options,cmd,out,thick1,thick2,origin,
     reL,stL,vtx,face,pt1,pt2,pt3,tmp,tmp1,tmp2);
  thick1=0;
  thick2=-0;
  origin=[0,0,0];
  options=select(optionorg,length(#)>0);
  tmp=Divoptions(options);
  reL=tmp_6;
  stL=tmp_7;
  tmp1=1;
  forall(1..length(reL),
    tmp=reL_#;
    if(islist(tmp),
      origin=tmp;
    ,
      if(tmp1==1,
        thick1=tmp;
        thick2=-tmp;
      ,
        thick2=tmp;
      );
      tmp1=tmp1+1; // 16.07.08
    );
  );
  options=remove(options,reL);
  forall(stL,
    tmp=indexof(#,"+")+indexof(#,"-");
    if(tmp>0,
      side=#;
      options=remove(options,[#]);
    );
  );
  vtx=pd_1; //16.04.23from
  if(length(pd)==2,face=pd_2,face=pd_3);
  if(isstring(vtx),vtx=parse(vtx));
  vtx=apply(vtx,if(isstring(#),parse(#),#)); // 16.06.18
  if(isstring(face),face=parse(face));
  forall(1..length(face),
    tmp=face_#;
    pt1=vtx_(tmp_1);// 16.06.18
    pt2=vtx_(tmp_2);// 16.06.18
    pt3=vtx_(tmp_(length(tmp)));// 16.06.18
    tmp1=Crossprod(pt2-pt1,pt3-pt1);
    tmp2=Dotprod(tmp1,pt1-origin);
    if(tmp2<0,
      face_#=reverse(face_#);
    );
  );
  tmp1=RSform(textformat(vtx,5),2);//17.12.24from
  tmp2=RSform(textformat(face,5),2);
  out=["Objpolyhedron",[tmp1,tmp2]];//17.12.24until
  tmp2=[]; // 16.06.10from
  forall(out,tmp1,
    if(islist(tmp1),
      tmp=apply(tmp1,if(isstring(#),Dq+#+Dq,Textformat(#,5)));
    ,
      if(isstring(tmp1),tmp=Dq+tmp1+Dq,tmp=Textformat(#,5));
    );
    tmp2=append(tmp2,tmp);
  );
  parse("oc"+nm+"="+tmp2);
  println("cmd seq oc"+nm+" generated"); // 16.06.10until
  OBJCMD=concat(OBJCMD,out);//16.11.29
  out;
);
////%Mkobjpolycmd end////

////%Mkobjplatecmd start////
Mkobjplatecmd(nm,pd):=Mkobjplatecmd(nm,pd,[]);
Mkobjplatecmd(nm,pdorg,optionorg):=( // 16.06.18
//help:Mkobjplatecmd("1",pd);
//help:Mkobjplatecmd("1",vtxlist);
//help:Mkobjplatecmd(options1=[0.05,-0.05]);
  regional(pd,options,cmd,out,thick1,thick2,nn,pdn,
     reL,vtx,face,nv,npttmp,tmp1,tmp2,tmp3,tmp4);
  pd=pdorg;
  if(Measuredepth(pd)==1,pd=[pd]);
  if(Measuredepth(pd)==2,pd=[pd]);//16.10.04from
  forall(1..length(pd),nn, // 16.06.19from
    pdn=pd_nn;
    vtx=pdn_1;
    if(length(pdn)==1,face=[1..(length(vtx))],face=pdn_2);
    vtx=apply(vtx,if(isstring(#),parse(#),#)); 
    vtx=apply(vtx,if(ispoint(#),parse(text(#)+"3d"),#));
    pd_nn=[vtx,face];//16.10.04until
  ); // 16.06.19until
  thick1=0.05;
  thick2=-0.05;
  options=select(optionorg,length(#)>0);
  tmp=Divoptions(options);
  reL=tmp_6;
  tmp1=1;
  forall(1..length(reL),
    tmp=reL_#;
    if(tmp1==1,
      thick1=tmp;
      thick2=-tmp;
    ,
      thick2=tmp;
    );
    tmp1=tmp1+1;// 16.07.08
  );
  options=remove(options,reL);
  out=[];
  forall(1..length(pd),npd,
    forall(pd_npd_2,face,
      vtx=apply(face,pd_npd_1_#);
      npt=length(vtx);
      tmp1=vtx_1;
      tmp2=vtx_2;
      tmp3=vtx_npt;
      tmp=Crossprod(tmp2-tmp1,tmp3-tmp1);
      nv=tmp/Dist3d(tmp);
      tmp1=apply(vtx,#+thick1*nv);
      tmp2=apply(vtx,#+thick2*nv);
      vtx=concat(tmp1,tmp2);
      tmp=apply(1..npt,#+npt);
      tmp2=[1..npt,reverse(tmp)];
      tmp=apply(1..(npt-1),[#,#+npt,#+npt+1,#+1]);
      tmp2=concat(tmp2,tmp);
      tmp=[npt,npt+npt,1+npt,1];
      tmp2=append(tmp2,tmp);
      tmp3=RSform(textformat(vtx,5),2);//17.12.24from
      tmp4=RSform(textformat(tmp2,5),2);
      out=concat(out,["Objpolyhedron",[tmp3,tmp4]]);//17.12.24until
    );
  );
  tmp3="["; // 16.06.10from
  forall(out,tmp1,
    tmp2="";
    if(isstring(tmp1),
      tmp2=tmp2+Dq+tmp1+Dq+",[";
    ,
      tmp2=tmp2+Textformat(tmp1_1,5)+",";
      tmp2=tmp2+Textformat(tmp1_2,5)+"],";
    );
    tmp3=tmp3+tmp2;
  );
  tmp3=substring(tmp3,0,length(tmp3)-1)+"]";
  parse("oc"+nm+"="+tmp3);
  println("cmd seq oc"+nm+" generated");
  OBJCMD=concat(OBJCMD,out);//16.11.29
  out;
);
////%Mkobjplatecmd end////

////%Mkobjcrvcmd start////
Mkobjcrvcmd(nm,pst):=Mkobjcrvcmd(nm,pst,[]);
Mkobjcrvcmd(nm,pstorg,options):=(
//help:Mkobjcrvcmd("1","sc3d1",[0.02,6,"xy"]);
  regional(cmd,out,thick,poly,dir,phead,pst,
    reL,stL,tmp,tmp1,tmp2,tmp3,tmp4,flg);
  thick=0.02;
  poly=6;
  dir="xy";
  tmp=Divoptions(options);
  reL=tmp_6;
  stL=select(tmp_7,length(#)>0);
  forall(1..length(reL),
    if(#==1,
      thick=reL_1;
    ,
      poly=reL_2;
    );
  );
  forall(stL,
    dir=#;
  );
  dir="'"+dir+"'";
  tmp=indexof(pstorg,"_");
  if(tmp==0,
    phead=pstorg;
  ,
    phead=substring(pstorg,0,tmp-1);
  );
  pst=pstorg;
  out=[];
  tmp1=select(GLIST,indexof(#,phead+"=")>0);
  if(length(tmp1)==0, println(phead+" incorrect"));
//  out=[tmp1_1,[]];
  out=[];
  tmp1=parse(pst);
  flg=0;  // 16.04.23from
  if(Measuredepth(tmp1)==2,flg=1);
  if(Measuredepth(tmp1)==0,
    if(islist(tmp1),flg=1);
  );
  if(flg==1,  // 16.04.23until
    if(!isstring(tmp1_1),
      forall(1..length(tmp1),
        tmp=["Objcurve",[pst+"[["+text(#)+"]]",thick,poly,dir]];//17.12.22
        out=concat(out,tmp);
       );
    ,
      forall(1..length(tmp1), // 16.11.14from
        tmp=["Objcurve",[tmp1_#,thick,poly,dir]];
        out=concat(out,tmp); 
       );// 16.11.14until
    );
  ,
    tmp1=Chunderscore(pst);
    tmp=["Objcurve",[tmp1,thick,poly,dir]];
    out=concat(out,tmp);
  );
  tmp2=[]; // 16.06.10from
  forall(out,tmp1,
    if(islist(tmp1),
      tmp=apply(tmp1,if(isstring(#),Dq+#+Dq,Textformat(#,5)));
    ,
      if(isstring(tmp1),tmp=Dq+tmp1+Dq,tmp=Textformat(#,5));
    );
    tmp2=append(tmp2,tmp);
  );
  parse("oc"+nm+"="+tmp2);
  println("cmd seq oc"+nm+" generated"); // 16.06.10until
  OBJCMD=concat(OBJCMD,out);//16.11.29
  out;
);
////%Mkobjcrvcmd end////

////%Mkobjsymbcmd start////
Mkobjsymbcmd(symb,size,rot,dir,pos):=
  Mkobjsymbcmd("",symb,size,rot,dir,pos,[]);
Mkobjsymbcmd(Ar1,Ar2,Ar3,Ar4,Ar5,Ar6):=(
  if(isstring(Ar2),
    Mkobjsymbcmd(Ar1,Ar2,Ar3,Ar4,Ar5,Ar6,[]);
  ,
    Mkobjsymbcmd("",Ar1,Ar2,Ar3,Ar4,Ar5,Ar6);
  );
);
Mkobjsymbcmd(path,symborg,size,rot,dir,pos,optionorg):=(
//help:Mkobjsymbcmd("x",0.5,0,V3d,A3d);
//help:Mkobjsymbcmd("P",0.5,0,V3d,A3d);
//help:Mkobjsymbcmd(options=[0.05,4,"'yz'"]);
  regional(symb,options,opbez,eqL,reL,stL,dtLstr,dtL,dt,
      alpha,Alpha,out,mx,Mx,my,My,center,tmp,tmp1,tmp2);
  alpha="abcdefghijklmnopqrstuvwxyz";
  Alpha=Toupper(alpha);
  symb=symborg;
  options=optionorg;
  opbez=["nodisp"];
  tmp=Divoptions(options);
  eqL=tmp_5;
  reL=tmp_6;
  stL=tmp_7;
  opbez=concat(opbez,eqL);
  options=remove(options,eqL);
  tmp1=[0.05,4,"'yz'"];
  if(length(reL)==0,
    options=concat(options,tmp1_(1..2));
  );
  if(length(reL)==1,  // debugged 16.06.18
    options=concat(options,[tmp1_2]);
  );
  if(length(stL)==0,
    options=concat(options,[tmp1_3]);
  );
  out=[];
  tmp=parse(symb);
  if((islist(symb)) % (islist(tmp)), //17.12.24from
    if(islist(tmp),
      dtL=[symb];
    ,
      dtL=symb;
    ); //17.12.24until
  ,
    tmp=substring(symb,0,1);
    if(tmp>="a" & tmp<="z",tmp1=tmp+"s");
    if(tmp>="A" & tmp<="Z",
      tmp=indexof(Alpha,tmp);
      tmp=substring(alpha,tmp-1,tmp);
      tmp1=tmp+"c";
    );
    if(length(symb)==1,
      if(symb>"Z",
        symb=tmp1+"i";
      ,
        symb=tmp1+"r";
      );
    );
    if(length(symb)==2,symb=tmp1+substring(symb,1,2));
    if(length(path)>0,  // 16.04.23from
      setdirectory(path);
    ,
      tmp=Dirhead+"/data/fontF";  // 16.05.10
      setdirectory(tmp);
    ); // 16.04.23until
    dtL=Readbezier(symb,opbez);
    dtLstr=dtL; //17.12.23
	setdirectory(Dirwork);
    forall(dtL,dt,
      tmp=dt+"=";
      tmp1=select(GLIST,indexof(#,tmp)>0);
      if(length(tmp1)>0,//17.12.23from
        tmp1=tmp1_1;
        out=concat(out,[tmp1,[]]);
      ); //17.12.23until  
    );
    mx=100;Mx=-100;my=100;My=-100;
    forall(dtL,dt,
      tmp=apply(parse(dt),#_1);
      mx=min(append(tmp,mx));
      Mx=max(append(tmp,Mx));
      tmp=apply(parse(dt),#_2);
      my=min(append(tmp,my));
      My=max(append(tmp,My));
    );
    center=[(mx+Mx)/2,(my+My)/2];
    tmp1=[];
    forall(dtL,dt,
      Rotatedata(dt,dt,rot,[center,"nodisp"]);
      Translatedata(dt,"rt"+dt,-center,["nodisp"]);
      tmp1=append(tmp1,"tr"+dt);
    );
    dtL=tmp1;
    forall(dtL,dt,
      tmp=dt+"=";
      tmp1=select(GLIST,indexof(#,tmp)>0);
      if(length(tmp1)>0,  //17.12.23from
        tmp1=tmp1_1;
        out=concat(out,[tmp1,[]]);
      ); //17.12.23until
    );
  );
  tmp1=text(options);
  tmp1=substring(tmp1,1,length(tmp1)-1);
  tmp2=""; //17.12.23from
  forall(dtL,
    tmp2=tmp2+","+#;
  );
  tmp2="list("+substring(tmp2,1,length(tmp2))+")"; //17.12.23until
  out=concat(out,[
    "Sd=Symb3data",[tmp2,size,0,dir,pos], //17.12.23
    "Objsymb(Sd,"+tmp1+")",[]
  ]);
  tmp2=[]; // 16.06.10from
  forall(out,tmp1,
    if(islist(tmp1),
      tmp=apply(tmp1,if(isstring(#),Dq+#+Dq,Textformat(#,5)));
    ,
      if(isstring(tmp1),tmp=Dq+tmp1+Dq,tmp=Textformat(#,5));
    );
    tmp2=append(tmp2,tmp);
  );
  parse("oc"+symborg+"="+tmp2);
//  println("cmd seq oc"+symborg+" generated"); // 16.06.10until
  OBJCMD=concat(OBJCMD,out);//16.11.29
  out;
);
////%Mkobjsymbcmd end////

////%Concatcmd start////
Concatcmd(cmdlist):=(
//help:Concatcmd([cmdL1,cmdL2]);
  regional(out);
  out=[];
  forall(cmdlist,
    out=concat(out,#);
  );
  out;
);
////%Concatcmd end////

WritetoF(fname,cmdL):=(
// help:WritetoF("outdata",cmdL);
  regional(tmp,tmp1,tmp2,filename,wfilename);
  if(indexof(fname,".")==0,
    filename=fname+".input";
  ,
    filename=fname;
  );
  wfilename=replace(filename,".input",".txt");
  SCEOUTPUT = openfile(filename);
  forall(1..(length(cmdL)),
    tmp1=cmdL_#;
	if(substring(tmp1,0,1)=="[",
      tmp1=tmp1+" --##";
      println(SCEOUTPUT,tmp1);
    ,
      println(SCEOUTPUT,tmp1);
      println(SCEOUTPUT," --##");
    );
  );
  closefile(SCEOUTPUT);
);

kcF(fname):=kcF(fname,[]);
kcF(fname,optionorg):=(
  regional(options,tmp,tmp1,tmp2,eqL,strL,
    filename,wfile,flg);
  if(indexof(fname,".")==0,
    filename=fname+".input";
  ,
    filename=fname;
  );
  wfile=replace(filename,".input",".sfort");
  options=optionorg;
  tmp=Divoptions(options);
  eqL=tmp_5;
  strL=tmp_7;
  forall(eqL,
    tmp=indexof(#,"=");
    tmp1=substring(#,0,tmp-1);
    tmp2=substring(#,tmp,length(#));
  ); 
  flg=0;
  forall(strL,
    if(Toupper(substring(#,0,1))=="R",
      flg=0;
      options=remove(options,[#]);
    );
    if(Toupper(substring(#,0,1))=="M",
      flg=1;
    );
  );
  if(flg==0,
    tmp2=replace(filename,".input",".sfort");
    tmp1=load(tmp2);
    if(length(tmp1)==0,
      flg=1;
    ); 
  );
  if(flg==1,
    tmp1=""; 
    if(iswindows(),
      tmp2=Batparent;
    ,
      tmp2=Shellparent;
    );
    flg=0;
    forall(reverse(1..length(tmp2)),
      if(flg==0,
        tmp=substring(tmp2,#-1,#);
        if(tmp=="/" % tmp=="\",  // 14.01.15
          tmp1=substring(tmp2,0,#-1);
          tmp2=substring(tmp2,#,length(tmp2));
          flg=1;
        );
      );
    );
    if(length(tmp1)>0,
      setdirectory(tmp1);
    ); 
    if(iswindows(),
//      SCEOUTPUT=openfile(wfile);
//      println(SCEOUTPUT,"");
//      closefile(SCEOUTPUT);
      SCEOUTPUT = openfile("kc.bat");
      tmp=Dq+PathF+"\bash"+Dq+" --login -i -c "+Dq+"/cygdrive/";
      tmp1=replace(Dirwork,"\","/");
      if(indexof(tmp1,":")==0,
        tmp=tmp+"c/"+tmp1+"/kc.sh"+Dq;
      ,
        tmp1=replace(tmp1,":","");
        tmp=tmp+tmp1+"/kc.sh"+Dq;
      );
      println(SCEOUTPUT,tmp);
      println(SCEOUTPUT,"exit 0");
      closefile(SCEOUTPUT);
    ,
      if(ismacosx(), //181125from
        SCEOUTPUT = openfile("kc.command");
      ,
        SCEOUTPUT = openfile("kc.sh");
      ); //181125to
      Lf=unicode("10",base->10);
      print(SCEOUTPUT,"#!/bin/sh"+Lf);
      tmp1=replace(Dirwork,"\","/");
      if(indexof(tmp1,":")==0,
        tmp="cd "+Dq+"/cygdrive/c/"+tmp1+Dq;
      ,
        tmp1=replace(tmp1,":","");
        tmp="cd "+Dq+"/cygdrive/"+tmp1+Dq;
      );
      print(SCEOUTPUT,tmp+Lf);
      tmp=Dq+"/opt/fricas/bin/fricas";
      tmp=tmp+Dq+"  -nox -eval ";
      tmp=tmp+Dq+")read "+filename+Dq;
//      tmp=tmp+" > "+Dq+wfile+Dq;
      print(SCEOUTPUT,tmp+Lf); 
      print(SCEOUTPUT,"exit 0"+Lf);
      closefile(SCEOUTPUT);
      println(kc(Dirwork+Batparent,Dirlib,Fnametex));// 16.05.29,06.05
    ,
      if(ismacosx(), //181125from
        SCEOUTPUT = openfile("kc.command");
      ,
        SCEOUTPUT = openfile("kc.sh");
      ); //181125to
      println(SCEOUTPUT,"#!/bin/sh");
      println(SCEOUTPUT,"cd "+Dq+Dirwork+Dq);
      tmp=Dq+PathF+Dq+"  -nox -eval "+Dq+")read "+filename+Dq;
//      tmp=tmp+" > "+wfile;
      println(SCEOUTPUT,tmp); 
      println(SCEOUTPUT,"exit 0");
      closefile(SCEOUTPUT);
      println(kc(Dirwork+Shellparent,Mackc+Dirlib,Fnametex));// 16.05.29,06.05
    );
    setdirectory(Dirwork);
  );
);

CalcbyF(name,cmd):=CalcbyM(name,cmd,[]);
CalcbyF(name,cmd,optionorg):=(
//help:CalcbyF("a",cmdL);
//help:CalcbyF(options= ["m/r","Wait=5"]]);
  regional(options,tmp,tmp1,tmp2,tmp3,tmp4,strL,eqL,
      flg,wflg,file,nc,arg,cmdF,cmdlist,wfile,Alpha,
      waiting,num,dig,varlist);
  options=optionorg;
  tmp=divoptions(options);
  eqL=tmp_5;
  strL=tmp_7;
  waiting=5;
  dig=5;
  forall(eqL,
    tmp=indexof(#,"=");
    tmp1=Toupper(substring(#,0,1));
    tmp2=substring(#,tmp,length(#));
    if(tmp1=="W",
      waiting=parse(tmp2);
      options=remove(options,[#]);
    );
  );
  file=Fhead+name+".input";
  wfile=Fhead+name+".sfort";
  wflg=0;
  forall(strL,
    tmp=Toupper(substring(#,0,1));
    if(tmp=="M",
      wflg=1;
      options=remove(options,[#]);
    );
    if(tmp=="R",
      wflg=-1;
      options=remove(options,[#]);
    );
  );
  cmdF=cmd;
  tmp1=")set breakmode quit";
  tmp2=")set output fortran on";
  tmp3=")set fortran precision single";
  cmdlist=[tmp1,tmp2,tmp3];
  tmp=")set output fortran "+wfile;
  cmdlist=append(cmdlist,tmp);
  forall(1..floor(length(cmdF)/2),nc, //17.5.18
    tmp1=cmdF_(2*nc-1);
    tmp1=replace(tmp1,LFmark,""); // 16.06.12
    tmp2=cmdF_(2*nc);  // list of argments
    if(nc<length(cmdF)/2,
      tmp3="";
      forall(tmp2,arg,
        if(isstring(arg),
          tmp3=tmp3+arg+",";
        ,
          tmp3=tmp3+textformat(arg,dig)+",";
        );
      );
      if(length(tmp3)>0,
        tmp3=tmp1+
           "("+substring(tmp3,0,length(tmp3)-1)+")";
      ,
        tmp3=tmp1;
      );
      cmdlist=append(cmdlist,tmp3);
    ,
      if(indexof(tmp1,"::")==0,
        varlist=[tmp1];
      ,
        varlist=tokenize(tmp1,"::");
      );
      forall(varlist,
        cmdlist=append(cmdlist,"["+#+"]");
      );
    );
  );
  cmdlist=concat(cmdlist,["111111*1",")quit"]);
  if(wflg==0,
    tmp1=load(file);
    if(length(tmp1)==0,
      wflg=1;
    ,
      if(indexof(tmp1," --##")==0,  // 15.11.26
        wflg=1;
      ,
        tmp1=tokenize(tmp1," --##");
        tmp1=tmp1_(1..(length(tmp1)-1));
        if(length(tmp1)!=length(cmdlist),
          wflg=1;
        ,
          tmp=select(1..length(tmp1),tmp1_#!=cmdlist_#);
          if(length(tmp)>0, wflg=1);
        );
      );
    );
  );
  if(wflg==0,wflg=-1);
  if(wflg==1,
    if(length(wfile)>0,
      SCEOUTPUT=openfile(wfile);
      println(SCEOUTPUT,"");
      closefile(SCEOUTPUT);
    );
    WritetoF(file,cmdlist);
    kcF(file,concat(options,["m"]));
  );
  Alpha="ABCDEFGHIJKLMNOPQRSTUVWXYZ";
  flg=0;
  tmp1=floor(waiting*1000/WaitUnit);
  repeat(tmp1,
    if(flg==0,
      tmp1=load(wfile);
      if(wflg==1,wait(WaitUnit));
      tmp=indexof(tmp1,"Error")+indexof(tmp1,"find");
      if(tmp>0,
          println("Some error(s) occurred");
          tmp=tokenize(tmp1," --##");
          forall(tmp,
            if(indexof(#,"Error")+indexof(#,"find")>0,
              println(tmp_(length(tmp)));
            );
          );
          flg=2;
      );
      if(indexof(tmp1,"111111")>0,
        tmp1=replace(tmp1,"     &","");
        tmp3="[";
        forall(1..length(varlist),
          tmp=indexof(tmp1,"["+varlist_#+"]");
          tmp1=substring(tmp1,tmp,length(tmp1));
          tmp=indexof(tmp1,"(1)=");
          tmp1=substring(tmp1,tmp+3,length(tmp1));
          tmp=indexof(tmp1," ");
          tmp3=tmp3+Dq+substring(tmp1,0,tmp-1)+Dq+",";
        );
        tmp3=replace(tmp3,"**","^");
        tmp3=replace(tmp3,".0","");
        tmp4="";
        forall(1..length(tmp3),
          tmp=substring(tmp3,#-1,#);
          tmp1=indexof(Alpha,tmp);
          if(tmp1>0,
            tmp4=tmp4+unicode(text(tmp1+96),base->10);
          ,
            if(tmp==" " % tmp=="&",
            ,
              tmp4=tmp4+tmp;
            );
          );
        );
        tmp=name+"="+substring(tmp4,0,length(tmp4)-1)+"]";
        parse(tmp);
        tmp=parse(name);
        if(length(tmp)==1,
          tmp1=substring(tmp4,1,length(tmp3)-1);
          parse(name+"="+tmp1);
        );
        flg=1;
        tmp2=#*WaitUnit/1000;
      ,
        if(wflg==-1,
          flg=-1;
        ,
          wait(WaitUnit);
        );
      );     
    );
  );
  if(flg<=0,
    if(flg==-1,
      println(wfile+" does not exist");
    ,
      tmp="("+text(waiting)+" s )";
      tmp1=load(wfile);
      if(length(tmp1)>0,
        println(wfile+" incomplete"+tmp); // 2016.02.24
      ,
        println(wfile+" not generated "+tmp);
      );
    );
  ,
    if(flg==1,
      println("      Succeeded "+name+" ("+text(tmp2)+" sec)");
    );
  );
);

Frfun(name,fun,argL):=Frifun(name,fun,argL,[]);
Frfun(name,fun,argL,optionorg):=Frifun(name,fun,argL,optionorg);
Frifun(name,fun,argL):=Frifun(name,fun,argL,[]);
Frifun(name,fun,argL,optionorg):=(
//help:Frfun("1","integrate",["sin(x)^3","x"],[""]);
//help:Mxfun(options=["Disp=y"]);
  regional(nm,options,eqL,disp,cmdL,tmp,tmp1,tmp2);
  nm="fri"+name;
  options=optionorg;
  tmp=divoptions(options);
  disp=1;
  eqL=tmp_5;
  forall(eqL,
    tmp=indexof(#,"=");
    tmp1=Toupper(substring(#,0,1));
    tmp2=substring(#,tmp,length(#));
    if(tmp1=="D" ,
      tmp=Toupper(substring(tmp2,0,1));
      if((tmp=="F") % (tmp=="N"),
        disp=0;
      );
      options=remove(options,[#]);
    );
  );
  cmdL=[];
  cmdL=concat(cmdL,[
    "ans"+":="+fun,argL,
    "ans",[]
  ]);
  CalcbyF(nm,cmdL,options);
  if(disp==1, // 15.11.24
    println(nm+" is : ");
    println(parse(nm));
  );
  parse(nm);
);

///////////////// C function //////////////////

Cformold(strorg):=(
//help:Cform(str);
  regional(str,ter,out,hat,pare,ns,ne,nn,jj,flg,flg2,
    lv,str1,str2,tmp,tmp1,tmp2);
  ter=["+","-","*","/","(",")","="]; //180517
  str=replace(strorg,"pi","M_PI");
  hat=Indexall(str,"^");
  pare=Bracket(str,"()");
  out="";
  ns=0;
  forall(hat,nn,
    tmp=substring(str,nn-2,nn-1);
    if(tmp==")",
      tmp1=substring(str,ns,nn-1);
      tmp2=Parlevel(tmp1);
	  tmp=tmp2_(length(tmp2))_2;
      lv=select(tmp2,#_2==-tmp);
      tmp=lv_1_1;
      out=out+substring(str,ns,ns+tmp-1);
      str1=substring(str,ns+tmp,nn-2);
    ,
      tmp=0;//180517
      flg=0;
      tmp2=reverse(ns..(nn-1));
      forall(tmp2,jj,
        if(flg==0,
          tmp1=substring(str,jj-1,jj);
		  if(contains(ter,tmp1),
            tmp=jj;
            flg=1;
          );
        );
      );
      tmp1=substring(str,ns,tmp);
      out=out+tmp1;
      str1=substring(str,tmp,nn-1);
    );
    tmp=substring(str,nn,nn+1);
    if(tmp=="(",
      tmp1=substring(str,nn,length(str));
      tmp2=Parlevel(tmp1);
      lv=select(tmp2,#_2==-1);
      tmp=lv_1_1;
      str2=substring(tmp1,1,tmp-1);
      ns=nn+tmp;
    ,
      flg=0;tmp=0;
      forall(nn..(length(str)),jj,
        if(flg==0,
          tmp1=substring(str,jj,jj+1);
          if((length(tmp1)==0)%(contains(ter,tmp1)),
            tmp=jj;
            flg=1;
          );
        );
      );
      str2=substring(str,nn,tmp);
      ns=nn+1;
    );
    out=out+"pow("+str1+","+str2+")";
  );
  str=out+substring(str,ns,length(str));
  str=str+"#";
  ter=apply(0..9,text(#));
  ter=append(ter,".");
  out="";
  tmp=substring(str,0,1);
  if(contains(ter,tmp),
    flg=1;out="";tmp1=tmp;
  ,
    flg=0;out=tmp;tmp1="";
  );
  forall(2..(length(str)),
    tmp=substring(str,#-1,#);
    if(contains(ter,tmp),
      if(flg==1,
        tmp1=tmp1+tmp;
      ,
        tmp1=tmp;
      );
      flg=1;
    ,
      if(flg==1,
        if(indexof(tmp1,".")==0,
          tmp1=tmp1+".0";
        );
        out=out+tmp1+tmp;
      ,
        out=out+tmp;
      );
      tmp1="";flg=0;
    );
  );
  out=substring(out,0,length(out)-1);
  out;
);

////%Cform start////
Cform(strorg):=( //181106
//help:Cform(str);
  regional(str,str2,out,ter,num,hat,pare,jj,ns,ne,nsa,nea,flg,flg2,tmp,tmp1,tmp2);
  ter=["+","-","*","/","(",")","="]; //180517
  str=replace(strorg,"pi","M_PI");
  num=apply(0..9,text(#));  //181107from
  num=append(num,".");
  flg=0;
  tmp1=str+"/";
  tmp2="";
  str="";
  forall(1..(length(tmp1)),
    tmp=substring(tmp1,#-1,#);
    if(contains(num,tmp),
      if(flg==0,
        tmp2=tmp;
        flg=1;
      ,
        tmp2=tmp2+tmp;
      );
    ,
      if(flg==1,
        if(indexof(tmp2,".")==0, tmp2=tmp2+".0");
        str=str+tmp2+tmp;
        flg=0;
      ,
        str=str+tmp;
      );      
    );
  );
  str=substring(str,0,length(str)-1); //181107to
  out="";
  flg=0;
  forall(1..100,jj,
    if(flg==0,
      hat=indexof(str,"^");
      if(hat==0,
        out=out+str;
        flg=1;
      ,
        ne=hat-1;
        if(substring(str,ne-1,ne)==")",
          ne=ne-1;
          pare=Bracket(str,"()");
          tmp=select(pare,#_1==hat-1);
          tmp=tmp_1_2;
          tmp1=select(pare,(#_1<hat)&(#_2==-tmp));
          ns=tmp1_(length(tmp1))_1+1;
          nsa=ns-1;
       ,
          flg2=0;
          forall(reverse(1..ne),
            if(flg2==0,
              if(contains(ter,substring(str,#-1,#)),
                ns=#+1;
                flg2=1;
              );
            );
          );
          if(flg2==0,ns=1);
          nsa=ns;
        );
        str2="pow("+substring(str,ns-1,ne)+",";
        ns=hat;
        if(substring(str,ns,ns+1)=="(",
          ns=ns+2;
          pare=Bracket(str,"()");
          tmp=select(pare,#_1==hat+1);
          tmp=tmp_1_2;
          tmp1=select(pare,(#_1>hat)&(#_2==-tmp));
          ne=tmp1_1_1-1;
          nea=ne+1;
        ,
          ns=ns+1;
          flg2=0;
          forall(ns..(length(str)),
            if(flg2==0,
              if(contains(ter,substring(str,#-1,#)),
                ne=#-1;
                flg2=1;
              );
            );
          );
          if(flg2==0,ne=length(str));
          nea=ne;
        );
        str2=str2+substring(str,ns-1,ne)+")";
        out=out+substring(str,0,nsa-1)+str2;
        str=substring(str,nea,length(str));
      );
    );
  );
  out;
);
////%Cform end////

////%ConvertFdtoC start////
ConvertFdtoC(Fd):=ConvertFdtoC(Fd,["x","y","z"]);
ConvertFdtoC(Fd,name):=(
//help:ConvertFd(Fd);
  regional(FdL,FdC,uvar,vvar,tmp,tmp1);
  FdL=Fullformfunc(Fd);
  tmp=indexof(FdL_5,"="); //180303from
  uvar=substring(FdL_5,0,tmp-1);
  tmp=indexof(FdL_6,"=");
  vvar=substring(FdL_6,0,tmp-1);
  tmp1=apply(2..6,Assign(FdL_#,uvar,"u"));
  tmp1=apply(tmp1,Assign(#,vvar,"v"));
  tmp1=concat(tmp1,FdL_(7..8));
  FdC=apply(1..3,name_#+"="+Cform(tmp1_#)); 
  FdC=concat(FdC,[Cform(tmp1_4),Cform(tmp1_5)]);
  FdC=concat(FdC,[tmp1_6]); 
);
////%ConvertFdtoC end////

////%Startsurf start////
Startsurf():=StartsurfC();
Startsurf(Arg):=StartsurfC(Arg);
Startsurf(Nplist,Dsizelist,Epslist):=StartsurfC("",Nplist,Dsizelist,Epslist); //181116
Startsurf(restr,Nplist,Dsizelist,Epslist):=StartsurfC(restr,Nplist,Dsizelist,Epslist);
StartsurfC():=StartsurfC("",[50,50],[1500,500,200],[0.01,0.1]);//180611renewed
StartsurfC(Arg):=(
  regional(tmp);
  if(isstring(Arg),
    StartsurfC(Toupper(Arg),[50,50],[1500,500,200],[0.01,0.1]);
  ,
    tmp=max(Arg);
    if(tmp>=500,
      StartsurfC("",[50,50],Arg,[0.01,0.1]);
    ,
      if(tmp>1,
        StartsurfC("",Arg,[1500,500,200],[0.01,0.1]);
      ,
        StartsurfC("",[50,50],[1500,500,200],Arg);
      );
    );
  );
);
StartsurfC(restr,Nplist,Dsizelist,Epslist):=(//180501
//help:Startsurf();
//help:Startsurf("reset");
//help::Startsurf([0.01,0.1]);
//help:Startsurf([50,50],[1500,500,200],[0.01,0.1]);
//help:Startsurf([50],[1500,500],[0.01,0.1]);
  regional(divL,sizeL,epsL);
  StyleListC=[]; //181107
  CommandListC=[];//180608(2lines)
  FuncListC=[];
  if(substring(restr,0,1)=="R", //180611(3lines)
    GLIST=[];
  );
  divL=Nplist; sizeL=Dsizelist; epsL=Epslist;
  if(length(divL)==0,divL=[50]);
  if(length(divL)==1,divL=append(divL,divL_1));
  if(length(sizeL)==0,sizeL=[1500]); //180610from
  if(length(sizeL)==1,sizeL=append(sizeL,500));
  if(length(sizeL)==2,sizeL=append(sizeL,200));
  sizeL=prepend(5000,sizeL); //180610to
  if(length(epsL)==0,epsL=[0.01]);
  if(length(epsL)==1,epsL=append(epsL,0.1));
  epsL=prepend(0.00001,epsL);
  ConstantListC=[divL,sizeL,epsL];
);
////%Startsurf end////

////%Contsurf start////
Contsurf():=ContsurfC("");
Contsurf(restr):=ContsurfC(restr);
ContsurfC(restr):=(//181101
//help:Contsurf();
  regional(cL,tmp,tmp1,tmp2);
  if(substring(restr,0,1)=="R",
    GLIST=[];
  );
  cL=CommandListC;
  cL=cL_(1..(length(cL)-1));
  CommandListC=cL;
);
////%Contsurf end////

////%kcC start////
kcC():=kcC(FheadC);
kcC(cname):=(
  regional(tmp, tmp1,flg,rfile);
  rfile=cname+"end.txt"; //180517
  if(iswindows(),
    SCEOUTPUT = openfile("kc.bat");
    println(SCEOUTPUT,"set path="+Dirwork);
    tmp=Indexall(PathC,"\");
    if(length(tmp)==0, tmp=ndexall(PathC,"/"));
    tmp1=substring(PathC,0,tmp_(length(tmp))-1);
    println(SCEOUTPUT,"cd "+tmp1);
    tmp=PathC+" %path%\"+cname+".c";
    tmp=tmp+" -o %path%\main.exe"; 
    println(SCEOUTPUT,tmp);
    println(SCEOUTPUT,"cd "+Dq+Dirwork+Dq);
    println(SCEOUTPUT,"%path%\main.exe");
    println(SCEOUTPUT,"echo ////> %path%\"+rfile);
    println(SCEOUTPUT,"exit");
    closefile(SCEOUTPUT);
    tmp=cname+".txt";
    println(kc(Dirwork+Batparent,Mackc+Dirlib,tmp));
  ,
    if(ismacosx(), //181125from
      SCEOUTPUT = openfile("kc.command");
    ,
      SCEOUTPUT = openfile("kc.sh");
    ); //181125to
    println(SCEOUTPUT,"#!/bin/sh");
    println(SCEOUTPUT,"cd "+Dq+Dirwork+Dq);
    tmp=PathC+" "+cname+".c -o main.out -lm"; //190123
    println(SCEOUTPUT,tmp);
    println(SCEOUTPUT,"./main.out");
    println(SCEOUTPUT,"echo ////>"+rfile);
    println(SCEOUTPUT,"exit 0");
    closefile(SCEOUTPUT);
    tmp=cname+".txt";
    println(kc(Dirwork+Shellparent,Mackc+Dirlib,tmp));
  );
  SCEOUTPUT=openfile(wfile);
  println(SCEOUTPUT,"");
  closefile(SCEOUTPUT);
  flg=0;
  repeat(floor(10*10000/WaitUnit), //180615
    if(flg==0,
      tmp1=load(wfile);
	  if(substring(tmp1,0,4)=="////",
        flg=1;
      );
      wait(WaitUnit);
    );
  );
  if(flg==0,
    println("kcC not completed");
  ,
    println("kcC succeeded");
  );
);
////%kcC end////

ReaddataCold(var, fname):=ReaddataC(var, fname,[]);
ReaddataC(var, fname,options):=(
  regional(file,dt,name,str,tmp,tmp1,opstr,gout, out3,out2);
  if(indexof(fname,".")==0,
    file=fname+".txt";
    name=fname;
  ,
    file=fname;
    tmp=indexof(fname,".");
    name=substring(fname,0,tmp-1);
  );
  tmp=Divoptions(options);
  opstr=tmp_(length(tmp)-1);
  gout=ReadOutData(file);
  GLIST=Append(GLIST,"Tmpstr=ReadOutData("+Dq+file+Dq+")");
  if(substring(var,length(var)-1,length(var))!="h",
    if(length(parse(gout_1))>0,
      Projpara(var+"3d",options); 
    );
  ,
    if(length(parse(gout_2))>0,
      Projpara(var+"3d",options);
    );
  );//17.06.16until
);

////%ReaddataC start////
ReaddataC(fnameorg):=(
  regional(tmp,tmp1,fname,data,out);
  fname=fnameorg;
  if(indexof(fname,".")==0, fname=fname+".txt");
  data=load(fname);
  data=tokenize(data," -99999");
  out=[];
  tmp1=[];
  forall(1..(length(data)-1),
    tmp=replace(data_#," ",",");
    if(indexof(tmp,"99999.")==0,
      tmp="["+replace(data_#," ",",")+"]";
      tmp=parse(tmp);
      tmp1=append(tmp1,tmp);      
    ,
      out=append(out,tmp1);
      tmp1=[];
    );
  );
  if(length(tmp1)>0,out=append(out,tmp1));
  out;
);
////%ReaddataC end////

////%WritedataC start////
WritedataC(fnameorg,dataorg):=(
//help:WritedataC(filename, 3ddata);
  regional(tmp,fname,data,kk,nn,pt);
  data=dataorg;
  if(isstring(data),data=parse(data));
  if(Measuredepth(data)==1,data=[data]);
  fname=fnameorg;
  if(indexof(fname,".")==0, fname=fname+".txt");
  SCEOUTPUT=openfile(fname);
  forall(1..(length(data)),kk,
    forall(1..(length(data_kk)),nn,
      pt=apply(1..3,Sprintf(data_kk_nn_#,5));
      tmp=pt_1+" "+pt_2+" "+pt_3+" -99999";
      print(SCEOUTPUT,tmp);
      if(nn<length(data_kk), //180426from
        println(SCEOUTPUT,"");
      );//180426to
    );
    if(kk<length(data),
      println(SCEOUTPUT,"");//180426
      println(SCEOUTPUT,"99999.00000 2.00000 0.00000 -99999");
    );
  );
  closefile(SCEOUTPUT);
);
////%WritedataC end////

DisplayC():=DisplayC(DispC);
DisplayC(name,options):=DisplayC([name,options]);
DisplayC(dispc):=(
//help:DisplayC("out",["Color=[1,0,0]");
//help:DispC(options=["dr", "Color=[0,0,0]"])
  regional(tmp,tmp1,cflg,var, file,options,eqL,opcindy,color);
  forall(1..(floor(length(dispc)/2)), //17.05.18
    var=dispc_(2*#-1); // 17.05.24
    if(substring(var,length(var)-1,length(var))!="h",//17.06.09(5lines)
      file=FheadC+var+".txt";
    ,
      file=FheadC+substring(var,0,length(var)-1)+".txt";
    );
    options=dispc_(2*#);
    cflg=0;
    tmp=Divoptions(options);//17.06.18from
    eqL=tmp_5;
    opcindy=tmp_(length(tmp));
    forall(eqL,
      if(Toupper(substring(#,0,1))=="C",
        tmp=indexof(#,"=");
        color=substring(#,tmp,length(#));
        if(substring(color,0,1)=="[",
          color=parse(color);
          if(length(color)==3,
            tmp1="color->"+text(color);
          ,
            tmp=Colorcode("rgb","cmyk",color);
            tmp1="color->"+text(tmp);
          );
          options=append(options,tmp1);
        );
        options=remove(options,[#]);
        cflg=1;
      );
    ); 
    if(cflg==1,
      Texcom("{");
      Setcolor(color);
    );
    ReaddataC(var,file,options);// 17.05.24
    if(cflg==1,
      Texcom("}");
    );
  );
);

////%Cheadsurf start////
Cheadsurf():=(
  regional(cmd,jj,divL,sizeL,epsL,nf,var1,var2,tmp,tmp1,tmp2);
  divL=ConstantListC_1;
  sizeL=ConstantListC_2;
  epsL=ConstantListC_3;
  cmd=[];
  tmp="const double XMIN="+Sprintf(XMIN,6);
  tmp=tmp+",XMAX="+Sprintf(XMAX,6)+";";
  cmd=append(cmd,tmp);
  tmp="const double THETA="+Sprintf(THETA,6);
  tmp=tmp+",PHI="+Sprintf(PHI,6)+";";
  cmd=append(cmd,tmp);
  tmp="  //THETA:"+Sprintf(THETA*180/pi,2);
  tmp=tmp+", PHI:"+Sprintf(PHI*180/pi,2)+";";
  cmd=append(cmd,tmp);
  tmp1=apply(divL,text(#));
  tmp="const int Mdv="+tmp1_1+",Ndv="+tmp1_2+";";
  cmd=append(cmd,tmp);
  tmp1=apply(sizeL,text(#));
  tmp="#define DsizeLL "+tmp1_1;
  cmd=append(cmd,tmp);
  tmp="#define DsizeL "+tmp1_2;
  cmd=append(cmd,tmp);
  tmp="#define DsizeM "+tmp1_3;
  cmd=append(cmd,tmp);
  tmp="#define DsizeS "+tmp1_4;
  cmd=append(cmd,tmp);
  tmp1=apply(epsL,format(#,7));
  tmp="const double Eps="+tmp1_1;
  tmp=tmp+", Eps1="+tmp1_2;
  tmp=tmp+", Eps2="+tmp1_3+";";
  cmd=append(cmd,tmp);
  tmp=replace(Dirwork,"\","/"); //180523(2lines)
  tmp="const char Dirname[]="+Dq+tmp+"/"+Dq+";";
  cmd=append(cmd,tmp);
  cmd=append(cmd,"double Urng[2],Vrng[2];");
  cmd=append(cmd,  "int DrawE,DrawW,DrawS,DrawN;");
  cmd=append(cmd,"void rangeUV(short ch){");
  cmd=append(cmd,"  switch(ch){");
  forall(1..(length(FuncListC)),nf,
    tmp2="    case "+text(nf)+" : ";
    forall(4..5,
      tmp1=FuncListC_nf_#; tmp=indexof(tmp1,"=");
      tmp1=substring(tmp1,tmp+1,length(tmp1)-1);
      tmp1=tokenize(tmp1,",");
      if(#==4,tmp="Urng",tmp="Vrng");
      tmp2=tmp2+tmp+"[0]="+tmp1_1+";"+tmp+"[1]="+tmp1_2+";";
    );
    tmp2=tmp2+"break;"; //180523
    cmd=append(cmd,tmp2);
  );
  cmd=append(cmd,"  }");
  cmd=append(cmd, "}");
  cmd=append(cmd,"void boundary(short ch){");
  cmd=append(cmd,"  switch(ch){");
  forall(1..(length(FuncListC)),nf,
    tmp2="    case "+text(nf)+" : ";
    tmp=FuncListC_nf_6;
    tmp2=tmp2+"DrawE=";
    if(indexof(tmp,"e")>0,tmp2=tmp2+"1;",tmp2=tmp2+"0;");
    tmp2=tmp2+"DrawW=";
    if(indexof(tmp,"w")>0,tmp2=tmp2+"1;",tmp2=tmp2+"0;");
    tmp2=tmp2+"DrawS=";
    if(indexof(tmp,"s")>0,tmp2=tmp2+"1;",tmp2=tmp2+"0;");
    tmp2=tmp2+"DrawN=";
    if(indexof(tmp,"n")>0,tmp2=tmp2+"1;",tmp2=tmp2+"0;");
    tmp2=tmp2+"break;"; //180523
    cmd=append(cmd,tmp2);
  );   
  cmd=append(cmd,"  }");
  cmd=append(cmd,"}");
  tmp="void surffun(short ch,double u, double v, double p[3]){";
  cmd=append(cmd,tmp);
  cmd=append(cmd,"  switch(ch){");
  forall(1..(length(FuncListC)),nf,
    tmp2="    case "+text(nf)+" : ";
    forall(1..3,
      tmp1=FuncListC_nf_#; tmp=indexof(tmp1,"=");
      tmp1=substring(tmp1,tmp,length(tmp1));
      tmp2=tmp2+"p["+text(#-1)+"]="+tmp1+";";
    );
    tmp2=tmp2+"break;"; //180523
    cmd=append(cmd,tmp2);
  );
  cmd=append(cmd,"  }");
  cmd=append(cmd,"}");
  cmd;
);
////%Cheadsurf end////

////%Ctopsurf start////
Ctopsurf(name):=Ctopsurf(name,CutFunList);
Ctopsurf(name,cutfunLorg):=(
  regional(cutfunL,path,cmd,tmp,tmp1,tmp2);
  cutfunL=cutfunLorg; //180601from
  if(length(cutfunL)==0,
    cutfunL=["1"];
  );//180601to
  path=DirlibC+"/";
  path=replace(path,"\","/");
  cmd=[
    "#include <stdio.h>","#include <math.h>",
    "#include <stdlib.h>","#include <string.h>", //180530
    "#include "+Dqq(Fhead+name+"header.h"),
    "#include "+Dqq(path+"ketcommonhead.h"),
    "#include "+Dqq(path+"ketcommon.h"),
	"#include "+Dq+path+"surflibhead.h"+Dq,
    "#include "+Dq+path+"surflib.h"+Dq,
    "double cutfun(short chfd, short chcut, double u, double v){",
    "  double p[3],val;",
    "  surffun(chfd,u,v,p);",
    "  switch(chcut){"
  ];
  tmp1=[];
  forall(1..(length(cutfunL)),
    tmp2=replace(cutfunL_#,"x","p[0]");
    tmp2=replace(tmp2,"y","p[1]");
    tmp2=replace(tmp2,"z","p[2]");
    tmp2="    case "+text(#)+": val="+tmp2+";";
    tmp2=tmp2+"break;"; //180523
    tmp1=append(tmp1,tmp2);
  );
  cmd=concat(cmd,tmp1);
  cmd=concat(cmd,[
    "  }",
    "  return val;",
    "}",
    "int main(void){",
    "  double data[DsizeL][3],sfbd[DsizeL][3],out[DsizeL][3];", //180601
    "  int i, j, nall;",
    "  char dirfname[256] = {'\0'};"
  ]);
  cmd;
);
////%Ctopsurf end////

////%WritetoC start////
WritetoC(nm,header,main):=(
  regional(hfile,mfile,top,body,tmp,tmp1,tmp2);
  hfile=Fhead+nm+"header.h";
  mfile=Fhead+nm+".c";
  top=main_1;
  body=main_2;
  SCEOUTPUT=openfile(hfile);
  forall(header,
    println(SCEOUTPUT,#+"/**/");
  );
  closefile(SCEOUTPUT);  
  SCEOUTPUT=openfile(mfile);
  forall(top,
    println(SCEOUTPUT,#);
  );
  println(SCEOUTPUT,"/**/");
  forall(body,
    println(SCEOUTPUT,#+"/**/");
  );
  println(SCEOUTPUT,"  return 0;");
  println(SCEOUTPUT,"}");
  closefile(SCEOUTPUT);  
);
////%WritetoC end////

////%CalcbyC start////
CalcbyC(name,cmd):=CalcbyC(name,PathC,cmd,[]);
CalcbyC(name,Arg1,Arg2):=(
  if(isstring(Arg1),
    CalcbyC(name,Arg1,Arg2,[]);
  ,
    CalcbyC(name,PathC,Arg1,Arg2);
  );
);
CalcbyC(name,path,cmd,optionorg):=(
  regional(options,eqL,strL,waiting,wflg,header,top,body,
       wfile,hfile,mfile,flg,tmp,tmp1,tmp2,tmp3);
  header=cmd_1;
  top=cmd_2;
  body=cmd_3;
  options=optionorg;
  tmp=divoptions(options);
  eqL=tmp_5;
  strL=tmp_7;
  waiting=40;
  wfile=Fhead+name+"end.txt"; //180517
  hfile=Fhead+name+"header.h";
  mfile=Fhead+name+".c";
  wflg=0;
  forall(eqL,
    tmp=Strsplit(#,"=");
    tmp1=Toupper(substring(tmp_1,0,1));
    if(tmp1=="W",
      waiting=parse(tmp_2);
      options=remove(options,[#]);
    );
  );
  forall(strL,
    tmp=Toupper(substring(#,0,1));
    if(tmp=="M",
      wflg=1;
      options=remove(options,[#]);
    );
    if(tmp=="R",
      wflg=-1;
      options=remove(options,[#]);
    );
  );
  if(wflg==0,
    tmp1=header;
    if(!isexists(Dirwork,hfile),wflg=1);
    if(wflg==0,
      tmp2=load(hfile);
      tmp2=tokenize(tmp2,"/**/");
      tmp2=tmp2_(1..(length(tmp2)-1));
      if(length(tmp1)!=length(tmp2),wflg=1);
    );
    if(wflg==0,
      forall(1..(length(tmp1)),
        if(tmp1_#!=tmp2_#,wflg=1);
      );
    );
    if(wflg==0,
      tmp1=body;
      if(!isexists(Dirwork+"/",mfile),wflg=1);
      if(wflg==0,
        tmp2=load(mfile);
        tmp2=tokenize(tmp2,"/**/");
        tmp2=tmp2_(2..(length(tmp2)-1));
        if(length(tmp1)!=length(tmp2),wflg=1);
      );
      if(wflg==0,
        forall(1..(length(tmp1)),
          if(tmp1_#!=tmp2_#,wflg=1);
        );
      );
    );
    if(wflg==0,wflg=-1);
  );
  if(wflg==1,
    WritetoC(name,header,[top,body]);
    SCEOUTPUT=openfile(wfile);
    println(SCEOUTPUT,"");
    closefile(SCEOUTPUT);
	kcC(Fhead+name); 
  );
  flg=0;
  tmp1=floor(waiting*1000/WaitUnit);
  repeat(tmp1,
    if(flg==0,
      tmp=load(wfile);
      if(indexof(tmp,"////")>0, //180523from
        flg=1;
        tmp2=#*WaitUnit/1000;//180523to
      ,
        if(wflg==-1,
          flg=-1;
        ,
          wait(WaitUnit);
        );
      );
    );
  );
  if(flg<=0, //180615from
    ErrFlag=1;
    if(flg==-1,
      println(wfile+" does not exist");
    ,
      if(flg==0,
        tmp="("+text(waiting)+" s )";
        println(wfile+" not generated "+tmp);
      );
    );
  );//180615to
  wflg; //181101
);
////%CalcbyC end////

////%Gccexists start////
Gccexists():=( //190124
  regional(out);
  if(iswindows(),
    out=isexists("",PathC);
  ,
    if(indexof(PathC,"/")==0, //190127from
      out=isexists("/usr/bin",PathC);
    ,
      out=isexists("",PathC);
    );
  ); //190127to
  out;
);
////%Gccexists end////

////%ExeccmdC start////
ExeccmdC(nm):=ExeccmdC(nm,[],["do"]);  //180531
ExeccmdC(nm,options):=ExeccmdC(nm,options,["do"]);
ExeccmdC(nm,optionorg,optionhorg):=( 
//help:ExeccmdC("1",options1,options2);
//help:ExeccmdC(options1=["dr(/da/do)","m/r","Wait=30"]);
//help:ExeccmdC(options2=["do(/nodisp/da/do)"]);
  regional(options,optionsh,name2,name3,waiting,dirbkup,
     eqL,reL,strL,fname,cL,tmp,tmp1,tmp2,flg,wflg,varL);
  fname=Fhead+nm+".txt";
  options=optionorg;
  optionsh=optionhorg;
  optionsh=select(optionsh,length(#)>0);
  if(length(optionsh)==0,optionsh=["do"]);
  tmp=Divoptions(options);
  eqL=tmp_5;
  reL=tmp_6;
  strL=tmp_7;
  waiting=30;
  wflg=0;
  cmdflg=0;
  forall(strL,
    tmp=Toupper(substring(#,0,1));
    if(tmp=="M",
      wflg=1;
      options=remove(options,[#]);
    );
    if(tmp=="R",
      wflg=-1;
      options=remove(options,[#]);
    );
  );
  forall(eqL,
    tmp=Strsplit(#,"=");
    tmp1=Toupper(substring(tmp_1,0,1)); //181111
    if(tmp1=="W",
      waiting=parse(tmp_2);
      options=remove(options,[#]);
    );
  );
  options=remove(options,reL);
  options=select(options,length(#)>0);
  if(CommonMake==1,//180609from
    tmp1=append(options,"m");
    wflg=0;
  );
  if(CommonMake==-1,
    tmp1=append(options,"r");
    wflg=0;
   );//180609to
  if(wflg==1,tmp1=append(options,"m"));
  if(wflg==-1,tmp1=append(options,"r"));
  tmp1=append(tmp1,"Wait="+text(waiting));
  tmp1=append(tmp1,"Disp=n"); //181024
  cL=CommandListC; //181101from
  tmp2="  char fnameall[]="+Dqq(fname)+";";
  tmp=select(1..(length(cL)),indexof(cL_#,"char fnameall[]=")>0); 
  if(length(tmp)==0,
    CommandListC=prepend(tmp2,CommandListC);
  ,
    tmp=tmp_1;
    CommandListC_tmp=tmp2;
  );
  cL=CommandListC;
  tmp2="  printf("+Dqq("%s\n")+","+Dqq("Execcmd "+nm)+");";
  tmp=select(1..(length(cL)),indexof(cL_#,"printf("+Dqq("%s\n")+","+Dq+"Execcmd ")>0); 
  if(length(tmp)==0,
    CommandListC=prepend(tmp2,CommandListC);
  ,
    tmp=tmp_1;
    CommandListC_tmp=tmp2;
  ); //181101to
  tmp=select(CommandListC,indexof(#,"outputend")>0);
  if(length(tmp)==0,
    CommandListC=append(CommandListC,"  outputend(dirfname);");
  );
  if(length(CommandListC)<=2,ErrFlag=1);
  if(ErrFlag==0,
    CalcbyC(nm,[Cheadsurf(),Ctopsurf(nm),CommandListC],tmp1);
  );
  if(ErrFlag==1,
    err("CommandListC is empty or execcmd is not completed");
  ,
    varL=ReadOutData(fname,["Disp=n"]); //181029
    GLIST=append(GLIST,"ReadOutData("+Dqq(fname)+")");
    tmp1=select(varL,indexof(#,"h3d")==0);
    tmp2=remove(varL,tmp1);
    tmp1=select(tmp1,indexof(#,"3d")>0);
    tmp="";
    if(length(options)>0,
      forall(options,
        tmp=tmp+Dqq(#)+",";
      );
      tmp=substring(tmp,0,length(tmp)-1);
    );
    if(length(tmp)>0,tmp=tmp+","); //180602
    tmp=tmp+Dqq("Msg=no"); //180602
    tmp1=apply(tmp1,replace(#,"3d","2d")+"=Projpara("+Dqq(#)+",["+tmp+"]);");
	forall(tmp1,parse(#));
    tmp="";
    if(length(optionsh)>0,
      forall(optionsh,
        tmp=tmp+Dqq(#)+",";
      );
      tmp=substring(tmp,0,length(tmp)-1);
    );
    tmp2=apply(tmp2,replace(#,"3d","2d")+"=Projpara("+Dqq(#)+",["+tmp+"]);");
    forall(tmp2,parse(#));
    Changestyle3d(EraseList,["nodisp"]);//180601
  );
  varL=select(varL,length(parse(#))>0);
  if(length(addpath)>0,Changework(dirbkup,["Sub=n"])); //180605
  if(SUBSCR==1, //  15.02.11
    forall(varL, //181106from
      Subgraph(#,"");
    );
  ); //181106to
  tmp=StyleListC; //181107from
  tmp1=apply(1..(length(tmp)/2),[tmp_(2*#-1),tmp_(2*#)]);
  forall(tmp1,tmp2,
    strL=select(varL,indexof(#,tmp2_1)>0); //181114from
    forall(strL,
      if((length(parse(#))>0)&(length(tmp2_2))>0,
        Changestyle3d(#,tmp2_2);
      );
    ); //181114to
  ); //181107to
  varL;
);
////%ExeccmdC end////

////%Sfbdparadata start////
Sfbdparadata(nm,fd):=SfbdparadataC(nm,fd);
Sfbdparadata(nm,fd,options):=SfbdparadataC(nm,fd,options);
Sfbdparadata(nm,fdorg,optionorg,optionsh):=SfbdparadataC(nm,fdorg,optionorg,optionsh);
SfbdparadataC(nm,fd):=(
   SfbdparadataC(nm,fd,[],["do"]);
);
SfbdparadataC(nm,fd,options):=
    SfbdparadataC(nm,fd,options,["do"]);
SfbdparadataC(nm,fdorg,optionorg,optionshorg):=(
//help:Sfbdparadata("1",Fd,nohiddenoptions,hiddenoptions);
  regional(funnm,fd,options,optionsh,name2,name3,name2h,name3h,waiting,
     eqL,reL,strL,fname,tmp,tmp1,tmp2,flg,wflg,cmdflg);
  if(ChNumber==0,ChNumber=Ch);
  fd=ConvertFdtoC(fdorg);
  tmp1=0; //180606from
  forall(1..(length(FuncListC)),
    if(FuncListC_#==fd,
      funnm=#;
      tmp1=1;
    );
  );
  if(tmp1==0,
    FuncListC=append(FuncListC,fd);
    funnm=text(length(FuncListC));
  ); //180606to
  name2="sfbd2d"+nm;
  name3="sfbd3d"+nm;
  name2h="sfbdh2d"+nm;
  name3h="sfbdh3d"+nm;
  fname=Fhead+"sfbd"+nm+".txt";
  options=select(optionorg,length(#)>0); //190123from
  tmp=Divoptions(options);
  if(length(tmp_7)==0,options=append(options,"dr"));
  optionsh=select(optionshorg,length(#)>0);
  tmp=Divoptions(optionsh);
  if(length(tmp_7)==0,optionsh=append(optionsh,"do")); //190123to
  tmp=Divoptions(options);
  eqL=tmp_5;
  reL=tmp_6;
  strL=tmp_7;
  waiting=60;
  wflg=0;
  cmdflg=1;
  forall(strL,
    tmp=Toupper(substring(#,0,1));
    if(tmp=="M",
      cmdflg=0;
      wflg=1;
      options=remove(options,[#]);
    );
    if(tmp=="R",
      cmdflg=0;
      wflg=-1;
      options=remove(options,[#]);
    );
    if(tmp=="C", //180531
      cmdflg=1;
      options=remove(options,[#]);
    );
  );
  options=remove(options,reL);
  options=select(options,length(#)>0);
  tmp1=select(options,
      (indexof(#,"=")>0)&(Toupper(substring(#,0,1))=="C")); //181114from
  if(length(tmp1)>0,
    tmp1=tmp1_1;
    tmp2=select(optionsh,
      (indexof(#,"=")>0)&(Toupper(substring(#,0,1))=="C")); 
    if(length(tmp2)==0,
      if(length(optionsh)==0,
        optionsh=["do",tmp1];        
      ,
        optionsh=append(optionsh,tmp1);
      );
    );
  );  //181114to
  StyleListC=concat(StyleListC,[name3,options,name3h,optionsh]); //181107
  options=remove(options,eqL);
  cmdL=[
	"  char fname"+nm+"[]="+Dqq(fname)+";",
    "  rangeUV("+funnm+");",
    "  boundary("+funnm+");",
    "  sfbdparadata("+funnm+",sfbd);",
    "  sprintf(dirfname,"+Dqq("%s%s")+",Dirname,fname"+nm+");",
    "  output3h("+Dqq("w")+","+Dqq("sfbd3d"+nm)+","+Dqq("sfbdh3d"+nm)+",dirfname,sfbd);",
    "  outputend(dirfname);"
  ];
  if(cmdflg==1, //180531from
    println("  ExeccmdC will generate "+ name3+","+name3h);
    tmp=replace(cmdL_5,"fname"+nm,"fnameall");cmdL_5=tmp; //181217
    tmp=select(CommandListC,indexof(#,"output3")>0); //180601from
    if(length(tmp)>0,
      tmp=replace(cmdL_6,Dqq("w"),Dqq("a"));cmdL_6=tmp;
    ); //180601from
    cmdL=cmdL_(2..(length(cmdL)-1)); //181113
    CommandListC=concat(CommandListC,cmdL); //180531to
  ,
    if(wflg==1,tmp1=append(options,"m"));
    if(wflg==-1,tmp1=append(options,"r"));
    if(ErrFlag==0,
      tmp="sfbd"+nm;
      CalcbyC(tmp,[Cheadsurf(),Ctopsurf(tmp),cmdL],tmp1);
    );
    if(ErrFlag==1,
      err("Sfbdparadata not completed");
    ,
      ReadOutData(fname,["Disp=n"]); //181029
      GLIST=append(GLIST,"ReadOutData("+Dqq(fname)+")");
      if(islist(parse(name3)),
        tmp1=name2+"=Projpara("+Dqq(name3)+",[";
        tmp2="";
        if(length(options)>0,
          forall(options,
            tmp2=tmp2+Dqq(#)+",";
          );
          tmp2=substring(tmp2,0,length(tmp2)-1);
        );
        tmp1=tmp1+tmp2+"]);";
        parse(tmp1);
        tmp2=select(optionsh,length(#)>0); //180517(2lines)
        if(length(tmp2)==0,tmp2=["nodisp"]);
        tmp1=name2h+"=Projpara("+Dqq(name3h)+",[";
        forall(tmp2,
          tmp1=tmp1+Dqq(#)+",";
        );
        tmp1=substring(tmp1,0,length(tmp1)-1)+"]);";
        parse(tmp1);
      ,
        ErrFlag=1;
      );
    );
  );
);
////%Sfbdparadata end////

////%Crvsfparadata start////
Crvsfparadata(nm,fk,sfbd,fd):=CrvsfparadataC(nm,fk,sfbd,fd);
Crvsfparadata(nm,fk,sfbd,fd,options):=CrvsfparadataC(nm,fk,sfbd,fd,options);
Crvsfparadata(nm,Fk,sfbdorg,fdorg,optionorg,optionsh):=
   CrvsfparadataC(nm,Fk,sfbdorg,fdorg,optionorg,optionsh);
CrvsfparadataC(nm,fk,sfbd,fd):=
   CrvsfparadataC(nm,fk,sfbd,fd,[],["do"]);
CrvsfparadataC(nm,fk,sfbd,fd,options):=
    CrvsfparadataC(nm,fk,sfbd,fd,options,["do"]);
CrvsfparadataC(nm,Fk,sfbdorg,fdorg,optionorg,optionshorg):=(
//help:Crvsfparadata("1","ax3d","sfbd3d1",Fd,,nohiddenoptions,hiddenoptions);
  regional(funnm,sfbd,fd,options,optionsh,name2,name3,name2h,name3h,waiting,
     eqL,reL,strL,fname,tmp,tmp1,tmp2,flg,wflg,useflg,cmdlfg,ii,jj,eps);
  eps=10^(-5);
  sfbd=replace(sfbdorg,"bdy","sfbd");
  fd=ConvertFdtoC(fdorg);
  tmp=select(1..(length(FuncListC)),FuncListC_#==fd);
  funnm=text(tmp_1); //180426
  name2="crvsf2d"+nm;
  name3="crvsf3d"+nm;
  name2h="crvsfh2d"+nm;
  name3h="crvsfh3d"+nm;
  fname=Fhead+"crvsf"+nm+".txt";
   options=select(optionorg,length(#)>0); //190123from
  tmp=Divoptions(options);
  if(length(tmp_7)==0,options=append(options,"dr"));
  optionsh=select(optionshorg,length(#)>0);
  tmp=Divoptions(optionsh);
  if(length(tmp_7)==0,optionsh=append(optionsh,"do")); //190123to
  tmp=Divoptions(options);
  eqL=tmp_5;
  reL=tmp_6;
  strL=tmp_7;
  waiting=60;
  wflg=0;
  cmdflg=1;
  forall(strL,
    tmp=Toupper(substring(#,0,1));
    if(tmp=="M",
      cmdflg=0;
      wflg=1;
      options=remove(options,[#]);
    );
    if(tmp=="R",
      cmdflg=0;
      wflg=-1;
      options=remove(options,[#]);
    );
    if(tmp=="C", //180531
      cmdflg=1;
      options=remove(options,[#]);
    );
  );
  useflg="N"; //181105from
  forall(eqL,
    tmp=Strsplit(#,"=");
    tmp1=Toupper(substring(tmp_1,0,1));
    if(tmp1=="U",
      useflg=Toupper(substring(tmp_2,0,1));
    );
  ); //181105to
  options=remove(options,reL);
  options=select(options,length(#)>0);
  tmp1=select(options,
      (indexof(#,"=")>0)&(Toupper(substring(#,0,1))=="C")); //181114from
  if(length(tmp1)>0,
    tmp1=tmp1_1;
    tmp2=select(optionsh,
      (indexof(#,"=")>0)&(Toupper(substring(#,0,1))=="C")); 
    if(length(tmp2)==0,
      if(length(optionsh)==0,
        optionsh=["do",tmp1];        
      ,
        optionsh=append(optionsh,tmp1);
      );
    );
  );  //181114to
  StyleListC=concat(StyleListC,[name3,options,name3h,optionsh]); //181107
  options=remove(options,eqL);
  if(useflg=="N",
//    flg=0;
//    tmp=Fhead+Fk+".dat";
//    if(!isexists(Dirwork,tmp),flg=1);
//    if(flg==0,
//      tmp1=ReaddataC(tmp);
//      tmp2=parse(Fk);
//      if(length(tmp1)==length(tmp2),
//        forall(1..(length(tmp1)),ii,
//          if(length(tmp1_ii)!=length(tmp2_ii),flg=1);
//          forall(1..(length(tmp1_ii)),jj,
//            if(flg==0,
//              if(Norm(tmp1_ii_jj-tmp2_ii_jj)>eps,flg=1);
//            );
//          );
//        );
//      );
//    );
//    if(flg==1,
      if((islist(parse(Fk))),
        tmp=Fhead+Fk+".dat";
        WritedataC(tmp,Fk);
      ,
        useflg="Y";
      );
//    );
  ); //181105to
  if(cmdflg==1,
    EraseList=append(EraseList,Fk);
  ,
    Changestyle3d(Fk,["nodisp"]);
  );
  cmdL=[
    "  char fname"+nm+"[]="+Dqq(fname)+";",
    "  rangeUV("+funnm+");",
    "  boundary("+funnm+");"
  ];
  if(useflg=="N", //181105from
    cmdL=concat(cmdL,[
       "  readdataC("+Dqq(Fhead+Fk+".dat")+",data);"
    ]);
  ,
    cmdL=concat(cmdL,[
       "  readoutdata3(dirfname,"+Dqq(Fk)+",data);"
    ]);
  );
  cmdL=concat(cmdL,[
    "  readoutdata3("+Dqq(Fhead+replace(sfbd,"3d","")+".txt")+","+Dqq(sfbd)+",sfbd);",
    "  crvsfparadata("+funnm+",data,sfbd, 0, out);",
    "  sprintf(dirfname,"+Dqq("%s%s")+",Dirname,fname"+nm+");",
    "  output3h("+Dqq("w")+","+Dqq("crvsf3d"+nm)+","+Dqq("crvsfh3d"+nm)+",dirfname,out);",
    "  outputend(dirfname);"
  ]); //181105to
  if(cmdflg==1,//180531from
    println("  ExeccmdC will generate "+ name3+","+name3h);
	cmdL_(length(cmdL)-4)="  readoutdata3(fnameall,"+Dqq(sfbd)+",sfbd);";  //181105(2lines)
    cmdL_(length(cmdL)-2)="  sprintf(dirfname,"+Dqq("%s%s")+",Dirname,fnameall);"; 
    tmp=replace(cmdL_(length(cmdL)-1),Dqq("w"),Dqq("a")); cmdL_(length(cmdL)-1)=tmp;
    cmdL=cmdL_(1..(length(cmdL)-1)); //181113
    CommandListC=concat(CommandListC,cmdL); //180531to
  ,
    if(wflg==1,tmp1=append(options,"m"));
    if(wflg==-1,tmp1=append(options,"r"));
    if(ErrFlag==0,
      tmp="crvsf"+nm;
      CalcbyC(tmp,[Cheadsurf(),Ctopsurf(tmp),cmdL],tmp1);
    );
    if(ErrFlag==1,
      err("Crvsfparadata not completed");
    ,
      ReadOutData(fname,["Disp=n"]); //181029
      GLIST=append(GLIST,"ReadOutData("+Dqq(fname)+")");
      if(islist(parse(name3)),
        tmp1=name2+"=Projpara("+Dqq(name3)+",[";
        tmp2="";
        if(length(options)>0,
          forall(options,
            tmp2=tmp2+Dqq(#)+",";
          );
          tmp2=substring(tmp2,0,length(tmp2)-1);
        );
        tmp1=tmp1+tmp2+"]);";
        parse(tmp1);
        tmp2=select(optionsh,length(#)>0); //180517(2lines)
        if(length(tmp2)==0,tmp2=["nodisp"]);
        tmp1=name2h+"=Projpara("+Dqq(name3h)+",[";
        forall(tmp2,
          tmp1=tmp1+Dqq(#)+",";
        );
        tmp1=substring(tmp1,0,length(tmp1)-1)+"]);";
        parse(tmp1);
      ,
        ErrFlag=1;
      );
    );
  );
);
////%Crvsfparadata end////

////%Crv3onsfparadata start////
Crv3onsfparadata(nm,crv3d,sfbd,fd):=Crv3onsfparadataC(nm,crv3d,sfbd,fd);
Crv3onsfparadata(nm,crv3d,sfbd,fd,options):=Crv3onsfparadataC(nm,crv3d,sfbd,fd,options);
Crv3onsfparadata(nm,crv3d,sfbdorg,fdorg,optionorg,optionsh):=
  Crv3onsfparadataC(nm,crv3d,sfbdorg,fdorg,optionorg,optionsh);
Crv3onsfparadataC(nm,crv3d,sfbd,fd):=
  Crv3onsfparadataC(nm,crv3d,sfbd,fd,[],["do"]);
Crv3onsfparadataC(nm,crv3d,sfbd,fd,options):=
   Crv3onsfparadataC(nm,crv3d,sfbd,fd,options,["do"]);
Crv3onsfparadataC(nm,crv3d,sfbdorg,fdorg,optionorg,optionshorg):=(
//help:Crv3onsfparadata("1","sc3","sfbd3d1",fd,,nohiddenoptions,hiddenoptions);
  regional(funnm,sfbd,fd,options,optionsh,name3,name3h,name2,name2h,waiting,
     eqL,reL,strL,fname,tmp,tmp1,tmp2,flg,wflg,flg,ii,jj,eps,cmdflg);
  tmp1=replace(crv3d,"3d","2d");
  tmp=apply(GCLIST,#_1);
  if(contains(tmp,tmp1),
    if(cmdflg==1,
      EraseList=append(EraseList,tmp1);
    ,
      Changestyle3d(tmp1,["nodisp"]);//180428
    );
  );
  eps=10^(-5);
  sfbd=replace(sfbdorg,"bdy","sfbd");
  fd=ConvertFdtoC(fdorg);
  tmp=select(1..(length(FuncListC)),FuncListC_#==fd);
  funnm=text(tmp_1); //180426
  name3="crv3onsf3d"+nm;
  name3h="crv3onsfh3d"+nm;
  name2=replace(name3,"3d","2d");
  name2h=replace(name3h,"3d","2d");
  fname=Fhead+"crv3onsf"+nm+".txt";
  tmp=apply(fdorg,if(isstring(#),Dqq(#),#));
  tmp=text(tmp);
  options=optionorg;
  optionsh=select(optionshorg,length(#)>0); //181107
  tmp=Divoptions(options);
  eqL=tmp_5;
  reL=tmp_6;
  strL=tmp_7;
  waiting=60;
  wflg=0;
  cmdflg=1;
  forall(strL,
    tmp=Toupper(substring(#,0,1));
    if(tmp=="M",
      cmdflg=0;
      wflg=1;
      options=remove(options,[#]);
    );
    if(tmp=="R",
      cmdflg=0;
      wflg=-1;
      options=remove(options,[#]);
    );
    if(tmp=="C", //180531
      cmdflg=1;
      options=remove(options,[#]);
    );
  );
  options=remove(options,reL);
  options=select(options,length(#)>0);
  tmp1=select(options,
      (indexof(#,"=")>0)&(Toupper(substring(#,0,1))=="C")); //181114from
  if(length(tmp1)>0,
    tmp1=tmp1_1;
    tmp2=select(optionsh,
      (indexof(#,"=")>0)&(Toupper(substring(#,0,1))=="C")); 
    if(length(tmp2)==0,
      if(length(optionsh)==0,
        optionsh=["do",tmp1];        
      ,
        optionsh=append(optionsh,tmp1);
      );
    );
  );  //181114to
  StyleListC=concat(StyleListC,[name3,options,name3h,optionsh]); //181107
  options=remove(options,eqL);
  tmp2=parse(crv3d);
  flg=0;
  tmp=Fhead+crv3d+".dat";
  if(!isexists(Dirwork,tmp),flg=1);
  if(flg==0,
    tmp1=ReaddataC(tmp);
    if(length(tmp1)!=length(tmp2),flg=1);
    if(flg==0,
      forall(1..(length(tmp1)),ii,
        if(length(tmp1_ii)!=length(tmp2_ii),flg=1);
        forall(1..(length(tmp1_ii)),jj,
          if(flg==0,
            if(Norm(tmp1_ii_jj-tmp2_ii_jj)>eps,flg=1);
          );
        );
      );
    );
  ); 
  if(flg==1,WritedataC(tmp,crv3d));
  cmdL=[
    "  char fname"+nm+"[]="+Dqq(fname)+";",
    "  rangeUV("+funnm+");",
    "  boundary("+funnm+");",
    "  readdataC("+Dqq(Fhead+crv3d+".dat")+",data);",
    "  readoutdata3("+Dqq(Fhead+replace(sfbd,"3d","")+".txt")+","+Dqq(sfbd)+",sfbd);", //180531
    "  crv3onsfparadata("+funnm+",data,sfbd,out);",
    "  sprintf(dirfname,"+Dqq("%s%s")+",Dirname,fname"+nm+");",
    "  output3h("+Dqq("w")+","+Dqq("crv3onsf3d"+nm)+","+Dqq("crv3onsfh3d"+nm)+",dirfname,out);",
    "  outputend(dirfname);"
  ];
  if(cmdflg==1,//180531from
    println("  ExeccmdC will generate "+ name3+","+name3h);
    cmdL_7="  sprintf(dirfname,"+Dqq("%s%s")+",Dirname,fnameall);"; //180607
    tmp=replace(cmdL_(length(cmdL)-1),Dqq("w"),Dqq("a")); cmdL_(length(cmdL)-1)=tmp;
	cmdL_5="  readoutdata3(fnameall,"+Dqq(sfbd)+",sfbd);";
    cmdL=cmdL_(2..(length(cmdL)-1)); //181113
//    cmdL=remove(cmdL,[cmdL_1,cmdL_(length(cmdL))]);
    CommandListC=concat(CommandListC,cmdL); //180531to
  ,
    if(wflg==1,tmp1=append(options,"m"));
    if(wflg==-1,tmp1=append(options,"r"));
    if(ErrFlag==0,
      tmp="crv3onsf"+nm;
      CalcbyC(tmp,[Cheadsurf(),Ctopsurf(tmp),cmdL],tmp1);
    );
    if(ErrFlag==1,
      err("Crvonsfparadata not completed");
    ,
      ReadOutData(fname,["Disp=n"]);
      GLIST=append(GLIST,"ReadOutData("+Dqq(fname)+")");
      if(islist(parse(name3)),
        tmp1=name2+"=Projpara("+Dqq(name3)+",[";
        tmp2="";
        if(length(options)>0,
          forall(options,
            tmp2=tmp2+Dqq(#)+",";
          );
          tmp2=substring(tmp2,0,length(tmp2)-1);
        );
        tmp1=tmp1+tmp2+"]);";
        parse(tmp1);
        tmp2=select(optionsh,length(#)>0); //180517(2lines)
        if(length(tmp2)==0,tmp2=["nodisp"]);
        tmp1=name2h+"=Projpara("+Dqq(name3h)+",[";
        forall(tmp2,
          tmp1=tmp1+Dqq(#)+",";
        );
        tmp1=substring(tmp1,0,length(tmp1)-1)+"]);";
        parse(tmp1);
      ,
        ErrFlag=1;
      );
    );
  );
);
////%Crv3onsfparadata end////

////%Crv2onsfparadata start////
Crv2onsfparadata(nm,crv2d,sfbd,fd):=Crv2onsfparadataC(nm,crv2d,sfbd,fd);
Crv2onsfparadata(nm,crv2d,sfbd,fd,options):=Crv2onsfparadataC(nm,crv2d,sfbd,fd,options);
Crv2onsfparadata(nm,crv2d,sfbd,fdorg,options,optionsh):=
  Crv2onsfparadataC(nm,crv2d,sfbd,fdorg,options,optionsh);
Crv2onsfparadataC(nm,crv2d,sfbd,fd):=
  Crv2onsfparadataC(nm,crv2d,sfbd,fd,["c"],["do"]);
Crv2onsfparadataC(nm,crv2d,sfbd,fd,options):=
   Crv2onsfparadataC(nm,crv2d,sfbd,fd,options,["do"]);
Crv2onsfparadataC(nm,crv2d,sfbd,fdorg,options,optionsh):=(
//help:Crv2onsfparadata("1","gp1","sfbd3d1",fd,nohiddenoptions,hiddenoptions);
  regional(fd,uname,vname,str,tmpfun,ii,jj,crv3d,tmp,tmp1,tmp2);
  Changestyle3d(crv2d,["nodisp"]);
  crv3d=crv2d+"3d";
  fd=Fullformfunc(fdorg);
  tmp=Strsplit(fd_5,"=");
  uname=tmp_1;
  tmp=Strsplit(fd_6,"=");
  vname=tmp_1;
  str="["+fd_2+","+fd_3+","+fd_4+"]";
  tmp="tmpfun("+uname+","+vname+"):="+str+";";
  parse(tmp);
  tmp1=parse(crv2d);
  tmp2=[];
  forall(tmp1,
    tmp2=append(tmp2,tmpfun(#_1,#_2));
  );
  tmp=crv3d+"="+textformat(tmp2,6);
  parse(tmp);
  Crv3onsfparadataC(nm,crv3d,sfbd,fdorg,options,optionsh);
);
////%Crv2onsfparadata end////

////%Wireparadata start////
Wireparadata(nm,sfbd,fd,wr1,wr2):=WireparadataC(nm,sfbd,fd,wr1,wr2);
Wireparadata(nm,sfbd,fd,wr1,wr2,options):=WireparadataC(nm,sfbd,fd,wr1,wr2,options);
Wireparadata(nm,sfbd,fdorg,wr1,wr2,optionorg,optionsh):=
  WireparadataC(nm,sfbd,fdorg,wr1,wr2,optionorg,optionsh);
WireparadataC(nm,sfbd,fd,wr1,wr2):=
  WireparadataC(nm,sfbd,fd,wr1,wr2,[],["do"]);
WireparadataC(nm,sfbd,fd,wr1,wr2,options):=
   WireparadataC(nm,sfbd,fd,wr1,wr2,options,["do"]);
WireparadataC(nm,sfbd,fdorg,wr1,wr2,optionorg,optionshorg):=(
//help:Wireparadata("1","sfbd3d1",fd,5,5,nohiddenoptions,hiddenoptions);
  regional(funnm,fd,options,optionsh,name2,name3,name2h,name3h,waiting,
     eqL,reL,strL,fname,fnameh,tmp,tmp1,tmp2,flg,wflg,flg,ii,jj,eps,udata,vdata,cmdflg);
  eps=10^(-5);
  fd=ConvertFdtoC(fdorg);
  tmp=select(1..(length(FuncListC)),FuncListC_#==fd);
  funnm=text(tmp_1); 
  name2="wire2d"+nm;
  name3="wire3d"+nm;
  name2h="wireh2d"+nm;
  name3h="wireh3d"+nm;
  fname=Fhead+"wire"+nm+".txt";
  fnameh=replace(fname,".txt","h.txt");
  options=select(optionorg,length(#)>0); //190123from
  tmp=Divoptions(options);
  if(length(tmp_7)==0,options=append(options,"dr"));
  optionsh=select(optionshorg,length(#)>0);
  tmp=Divoptions(optionsh);
  if(length(tmp_7)==0,optionsh=append(optionsh,"do")); //190123to
  tmp=Divoptions(options);
  eqL=tmp_5;
  reL=tmp_6;
  strL=tmp_7;
  waiting=60;
  wflg=0;
  options=remove(options,reL);
  wflg=0;
  cmdflg=1;
  forall(strL,
    tmp=Toupper(substring(#,0,1));
    if(tmp=="M",
      cmdflg=0;
      wflg=1;
      options=remove(options,[#]);
    );
    if(tmp=="R",
      cmdflg=0;
      wflg=-1;
      options=remove(options,[#]);
    );
    if(tmp=="C", //180531
      cmdflg=1;
      options=remove(options,[#]);
    );
  );
  options=remove(options,reL);
  options=select(options,length(#)>0);
  tmp1=select(options,
      (indexof(#,"=")>0)&(Toupper(substring(#,0,1))=="C")); //181114from
  if(length(tmp1)>0,
    tmp1=tmp1_1;
    tmp2=select(optionsh,
      (indexof(#,"=")>0)&(Toupper(substring(#,0,1))=="C")); 
    if(length(tmp2)==0,
      if(length(optionsh)==0,
        optionsh=["do",tmp1];        
      ,
        optionsh=append(optionsh,tmp1);
      );
    );
  );  //181114to
  StyleListC=concat(StyleListC,[name3,options,name3h,optionsh]); //181107
  options=remove(options,eqL);
  if(islist(wr1),
    udata=prepend(length(wr1),wr1);
  ,
    tmp=Fullformfunc(fdorg);
    tmp1=tmp_5;
    tmp=indexof(tmp1,"=");
    tmp=substring(tmp1,tmp,length(tmp1));
    tmp=parse(tmp);
    tmp1=tmp_1; tmp2=tmp_2;
    udata=apply(1..wr1,tmp1+#*(tmp2-tmp1)/(wr1+1));
    udata=prepend(wr1,udata);
  );
  udata=textformat(udata,6);
  udata=substring(udata,1,length(udata)-1);
  if(islist(wr2),
    vdata=prepend(length(wr2),wr2);
  ,
    tmp=Fullformfunc(fdorg);
    tmp1=tmp_6;
    tmp=indexof(tmp1,"=");
    tmp=substring(tmp1,tmp,length(tmp1));
    tmp=parse(tmp);
    tmp1=tmp_1; tmp2=tmp_2;
    vdata=apply(1..wr2,tmp1+#*(tmp2-tmp1)/(wr2+1));
    vdata=prepend(wr2,vdata);
  );
  vdata=textformat(vdata,6);
  vdata=substring(vdata,1,length(vdata)-1);
  cmdL=[
    "  double wireu[]={"+udata+"};",
    "  double wirev[]={"+vdata+"};",
    "  char fname[]="+Dqq(fname)+";",
    "  char fnameh[]="+Dqq(fnameh)+";",
    "  rangeUV("+funnm+");",
    "  boundary("+funnm+");",
    "  readoutdata3("+Dqq(Fhead+replace(sfbd,"3d","")+".txt")+","+Dqq(sfbd)+",sfbd);", //180531
    "  wireparadata("+funnm+",sfbd,wireu,wirev,fname,fnameh);"
  ];
  if(cmdflg==1,//180531from
    println("  ExeccmdC will generate "+ name3+","+name3h);
    tmp=replace(cmdL_8,"fnameh",Dqq(""));
    tmp=replace(tmp,"fname","fnameall");  cmdL_8=tmp;
	cmdL_7="  readoutdata3(fnameall,"+Dqq(sfbd)+",sfbd);";
    cmdL=append(cmdL,"  outputend(dirfname);");
    tmp=remove(1..(length(cmdL)),[3,4]); //181113(2lines)
    cmdL=cmdL_tmp;
//    cmdL=remove(cmdL,[cmdL_3,cmdL_4]); //180827
    CommandListC=concat(CommandListC,cmdL); //180531to
  ,
    if(wflg==1,tmp1=append(options,"m"));
    if(wflg==-1,tmp1=append(options,"r"));
    if(ErrFlag==0,
      tmp="wire"+nm;
      CalcbyC(tmp,[Cheadsurf(),Ctopsurf(tmp),cmdL],tmp1);
    );
    if(ErrFlag==1,
      err("Wireparadata not completed");
    ,
      ReadOutData(fname,["Disp=n"]);
      GLIST=append(GLIST,"ReadOutData("+Dqq(fname)+")");
      ReadOutData(fnameh);
      GLIST=append(GLIST,"ReadOutData("+Dqq(fnameh)+")");
      if(islist(parse(name3)),
        tmp1=name2+"=Projpara("+Dqq(name3)+",[";
        tmp2="";
        if(length(options)>0,
          forall(options,
            tmp2=tmp2+Dqq(#)+",";
          );
          tmp2=substring(tmp2,0,length(tmp2)-1);
        );
        tmp1=tmp1+tmp2+"]);";
        parse(tmp1);
        tmp2=select(optionsh,length(#)>0); //180517(2lines)
        if(length(tmp2)==0,tmp2=["nodisp"]);
        tmp1=name2h+"=Projpara("+Dqq(name3h)+",[";
        forall(tmp2,
          tmp1=tmp1+Dqq(#)+",";
        );
        tmp1=substring(tmp1,0,length(tmp1)-1)+"]);";
        parse(tmp1);
      ,
        ErrFlag=1;
      );
    );
  );
);
////%Wireparadata end////

////%Intersectcrvsf start////
Intersectcrvsf(nm,crv,fd):=IntersectcrvsfC(nm,crv,fd);
Intersectcrvsf(nm,crv,fd,Arg):=IntersectcrvsfC(nm,crv,fd,Arg);
Intersectcrvsf(nm,crv3d,fdorg,bdyeq,optionorg):=
  IntersectcrvsfC(nm,crv3d,fdorg,bdyeq,optionorg);
IntersectcrvsfC(nm,crv,fd):=IntersectcrvsfC(nm,crv,fd,"",[]);
IntersectcrvsfC(nm,crv,fd,Arg):=(
  if(isstring(Arg),
    IntersectcrvsfC(nm,crv,fd,Arg,[]);
  ,
    IntersectcrvsfC(nm,crv,fd,"",Arg);
  );
);
IntersectcrvsfC(nm,crv3d,fdorg,bdyeq,optionorg):=(
//help:Intersectcrvsf("1",curve,fd);
  regional(fd,funnm,name,crv,fd,options,reL,fname,crvfname,argR,
     waiting,tmp,tmp1,tmp2,flg,wflg,pts,cmdflg);
  fd=ConvertFdtoC(fdorg);
  tmp=select(1..(length(FuncListC)),FuncListC_#==fd);
  funnm=text(tmp_1); //180426
  name="intercrvsf"+nm;
  fname=Fhead+name+".txt";
  crvfname=Fhead+"crv"+nm+".txt";
  fd=apply(fdorg,if(isstring(#),Dqq(#),#));
  options=optionorg;
  tmp=Divoptions(options);
  eqL=tmp_5;
  reL=tmp_6;
  strL=tmp_7;
  waiting=60;
  wflg=0;
  cmdflg=1;
  forall(strL,
    tmp=Toupper(substring(#,0,1));
    if(tmp=="M",
      cmdflg=0;
      wflg=1;
      options=remove(options,[#]);
    );
    if(tmp=="R",
      cmdflg=0;
      wflg=-1;
      options=remove(options,[#]);
    );
    if(tmp=="C", //180531
      cmdflg=1;
      options=remove(options,[#]);
    );
  );
  options=remove(options,eqL);
  options=remove(options,reL);
  options=select(options,length(#)>0);
  tmp2=parse(crv3d);
  flg=0;
  tmp=Fhead+crv3d+".dat";
  if(!isexists(Dirwork,tmp),flg=1);
  if(flg==0,
    tmp1=ReaddataC(tmp);
    if(length(tmp1)!=length(tmp2),flg=1);
    if(flg==0,
      forall(1..(length(tmp1)),ii,
        if(length(tmp1_ii)!=length(tmp2_ii),flg=1);
        forall(1..(length(tmp1_ii)),jj,
          if(flg==0,
            if(Norm(tmp1_ii_jj-tmp2_ii_jj)>eps,flg=1);
          );
        );
      );
    );
  ); 
  if(flg==1,WritedataC(tmp,crv3d));
  cmdL=[
    "  double crv3d[DsizeL][3];",
    "  char fname"+nm+"[]="+Dqq(fname)+";",
    "  rangeUV("+funnm+");",
    "  boundary("+funnm+");",
    "  readdataC("+Dqq(Fhead+crv3d+".dat")+",crv3d);",
    "  intersectcrvsf("+Dqq("w")+","+funnm+",crv3d,"+Dqq(fname)+");",
    "  sprintf(dirfname,"+Dqq("%s%s")+",Dirname,fname"+nm+");"
  ];
  if(cmdflg==1,//180531from
    cmdL_6="  intersectcrvsf("+Dqq("a")+","+funnm+",crv3d,fnameall);";
    tmp=remove(1..(length(cmdL)),[2,length(cmdL)]); //181113(2lines)
    cmdL=cmdL_tmp;
//    cmdL=remove(cmdL,[cmdL_2]);
//    cmdL=remove(cmdL,[cmdL_(length(cmdL))]);
    CommandListC=concat(CommandListC,cmdL); //180531to
  ,
    if(wflg==1,tmp1=append(options,"m"));
    if(wflg==-1,tmp1=append(options,"r"));
    if(ErrFlag==0,
      tmp="crv3onsf"+nm;
      CalcbyC(tmp,[Cheadsurf(),Ctopsurf(tmp),cmdL],tmp1);
    );
    if(ErrFlag==1,
   	  err("Intersectcrvsf not completed");
    ,
      ReadOutData(fname,["Disp=n"]); //181029
    );
    println("generate "+name);
    parse(name);
  );
);
////%Intersectcrvsf end////

////%Sfcutparadatacdy start//// 181112
Sfcutparadatacdy(nm,cutfun,fd):=
   Sfcutparadatacdy(nm,cutfun,fd,[]);
Sfcutparadatacdy(nm,cutfun,fd,options):=(
//help:Sfcutparadatacdy("1","2*x+3*y+z=1","sfbd3d",fd,options);
  regional(out3,out2,name3,name2,eps,fdL,rep,jj,pL,vn1,vn2,
       tmp,tmp1,tmp2);
  eps=10^(-5);
  name2="sfcc2d"+nm;
  name3="sfcc3d"+nm;
  fdL=Fullformfunc(fd);
  tmp=Strsplit(fdL_5,"=");
  vn1=tmp_1;
  tmp=Strsplit(fdL_6,"=");
  vn2=tmp_1;
  rep=["x",fdL_2,"y",fdL_3,"z",fdL_4];
  tmp=Assign(cutfun,rep);
  Implicitplot("sfc"+nm,tmp,fd_5,fd_6,["Msg=n","nodisp"]);
  out3=[]; out2=[];
  tmp1=parse("impsfc"+nm);
  if(Measuredepth(tmp1)==1,tmp1=[tmp1]);
  forall(1..(length(tmp1)),jj,
    pL=tmp1_jj;
    tmp2=[];
    forall(pL,
      tmp=Assign("[x,y,z]",rep);
      tmp=Assign(tmp,[vn1,#_1,vn2,#_2]);
      tmp=parse(tmp);
      tmp2=append(tmp2,tmp);
    );
    Spaceline("-sfc"+nm+"n"+text(jj),tmp2,append(options,"Msg=n"));
    out3=append(out3,tmp2);
    tmp=Projcurve(tmp2);
    out2=append(out2,tmp);
  );
  tmp=name3+"=["; tmp1=name3+"=[";
  forall(1..(length(out3)),
    tmp=tmp+"sfc"+nm+"n"+text(#)+"3d"+",";
    tmp1=tmp1+Dqq("sfc"+nm+"n"+text(#)+"3d")+",";
  );
  tmp=substring(tmp,0,length(tmp)-1)+"]";
  parse(tmp);
  tmp1=substring(tmp1,0,length(tmp1)-1)+"]";
  println("generate sfcutparadata "+tmp1);
  tmp=name2+"="+Textformat(out2,6);
  parse(tmp);
  out3;
);
////%Sfcutparadatacdy end////

////%Sfcutparadata start////
Sfcutparadata(nm,cutfunL,sfbd,fd):=SfcutparadataC(nm,cutfunL,sfbd,fd);
Sfcutparadata(nm,cutfunL,sfbd,fd,options):=SfcutparadataC(nm,cutfunL,sfbd,fd,options);
Sfcutparadata(nm,cutfunLorg,sfbd,fdorg,optionorg,optionsh):=
      SfcutparadataC(nm,cutfunLorg,sfbd,fdorg,optionorg,optionsh);
SfcutparadataC(nm,cutfunL,sfbd,fd):=(//180505
  SfcutparadataC(nm,cutfunL,sfbd,fd,[],["do"]);
);
SfcutparadataC(nm,cutfunL,sfbd,fd,options):=
   SfcutparadataC(nm,cutfunL,sfbd,fd,options,[]);
SfcutparadataC(nm,cutfunLorg,sfbd,fdorg,optionorg,optionshorg):=(
//help:Sfcutparadata("1","2*x+3*y+z=1","sfbd3d",fd,nohiddenoptions,hiddenoptions);
  regional(funnm,cutfunL,fd,options,optionsh,name2,name3,name2h,name3h,
     waiting,eqL,reL,strL,fname,fnameh,tmp,tmp1,tmp2,flg,wflg,flg,ii,jj,eps,cmdflg);
  eps=10^(-5);
  fd=ConvertFdtoC(fdorg);
  tmp=select(1..(length(FuncListC)),FuncListC_#==fd);
  funnm=text(tmp_1); 
  cutfunL=cutfunLorg;
  if(!islist(cutfunL),cutfunL=[cutfunL]);
  forall(1..(length(cutfunL)),
    tmp1=Strsplit(cutfunL_#,"=");
    if(length(tmp1)>1,
      tmp2=tmp1_1+"-("+tmp1_2+")"; //180516
      cutfunL_#=Cform(tmp2);
    );
  );
  CutFunList=cutfunL; //180601
  name2="sfcut2d"+nm;
  name3="sfcut3d"+nm;
  name2h="sfcuth2d"+nm;
  name3h="sfcuth3d"+nm;
  fname=Fhead+"sfcut"+nm+".txt";
  fnameh=replace(fname,".txt","h.txt");
  options=optionorg;
  optionsh=select(optionshorg,length(#)>0); //181107
  tmp=Divoptions(options);
  eqL=tmp_5;
  reL=tmp_6;
  strL=tmp_7;
  waiting=60;
  wflg=0;
  options=remove(options,reL);
  wflg=0;
  cmdflg=1;
  forall(strL,
    tmp=Toupper(substring(#,0,1));
    if(tmp=="M",
      cmdflg=0;
      wflg=1;
      options=remove(options,[#]);
    );
    if(tmp=="R",
      cmdflg=0;
      wflg=-1;
      options=remove(options,[#]);
    );
    if(tmp=="C", //180531
      cmdflg=1;
      options=remove(options,[#]);
    );
  );
  options=select(optionorg,length(#)>0); //190123from
  tmp=Divoptions(options);
  if(length(tmp_7)==0,options=append(options,"dr"));
  optionsh=select(optionshorg,length(#)>0);
  tmp=Divoptions(optionsh);
  if(length(tmp_7)==0,optionsh=append(optionsh,"do")); //190123to
  tmp1=select(options,
      (indexof(#,"=")>0)&(Toupper(substring(#,0,1))=="C")); //181114from
  if(length(tmp1)>0,
    tmp1=tmp1_1;
    tmp2=select(optionsh,
      (indexof(#,"=")>0)&(Toupper(substring(#,0,1))=="C")); 
    if(length(tmp2)==0,
      if(length(optionsh)==0,
        optionsh=["do",tmp1];        
      ,
        optionsh=append(optionsh,tmp1);
      );
    );
  );  //181114to
  StyleListC=concat(StyleListC,[name3,options,name3h,optionsh]); //181107
  options=remove(options,eqL);
  tmp1=text(length(cutfunL));
  cmdL=[
    "  char fname[]="+Dqq(fname)+";",
    "  char fnameh[]="+Dqq(fnameh)+";",
    "  rangeUV("+funnm+");",
    "  boundary("+funnm+");",
    "  readoutdata3("+Dqq(Fhead+replace(sfbd,"3d","")+".txt")+","+Dqq(sfbd)+",sfbd);", //180531
    "  sfcutparadata("+funnm+","+tmp1+",sfbd,fname,fnameh);"
  ];
  if(cmdflg==1,//180531from
    println("  ExeccmdC will generate "+ name3+","+name3h);
    tmp=replace(cmdL_6,"fnameh",Dqq(""));
    tmp=replace(tmp,"fname","fnameall");  cmdL_6=tmp;
	cmdL_5="  readoutdata3(fnameall,"+Dqq(sfbd)+",sfbd);";
    cmdL=append(cmdL,"  outputend(dirfname);");
    cmdL=cmdL_(3..(length(cmdL))); //181113
//    cmdL=remove(cmdL,[cmdL_1,cmdL_2]); //180827
    CommandListC=concat(CommandListC,cmdL); //180531to
  ,
    if(wflg==1,tmp1=append(options,"m"));
    if(wflg==-1,tmp1=append(options,"r"));
    if(ErrFlag==0,
      tmp="sfcut"+nm;
      CalcbyC(tmp,[Cheadsurf(),Ctopsurf(tmp),cmdL],tmp1); //180601
    );
    if(ErrFlag==1,
      err("Sfcutparadata not completed");
    ,
      ReadOutData(fname,["Disp=n"]); //1810209
      GLIST=append(GLIST,"ReadOutData("+Dqq(fname)+")");
      ReadOutData(fnameh);
      GLIST=append(GLIST,"ReadOutData("+Dqq(fnameh)+")");
      if(islist(parse(name3)),
        tmp1=name2+"=Projpara("+Dqq(name3)+",[";
        tmp2="";
        if(length(options)>0,
          forall(options,
            tmp2=tmp2+Dqq(#)+",";
          );
          tmp2=substring(tmp2,0,length(tmp2)-1);
        );
        tmp1=tmp1+tmp2+"]);";
        parse(tmp1);
        tmp2=select(optionsh,length(#)>0); //180517(2lines)
        if(length(tmp2)==0,tmp2=["nodisp"]);
        tmp1=name2h+"=Projpara("+Dqq(name3h)+",[";
        forall(tmp2,
          tmp1=tmp1+Dqq(#)+",";
        );
        tmp1=substring(tmp1,0,length(tmp1)-1)+"]);";
        parse(tmp1);
      ,
        ErrFlag=1;
      );
    );
  );
);
////%Sfcutparadata end////

//help:end();

