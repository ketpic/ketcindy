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

println("ketcindyout(2018.02.22) loaded");

//help:start();

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
  println(SCEOUTPUT,tmp); // 16.06.26upto
  if(iswindows(),  // 17.01.11from
      println(SCEOUTPUT,"setlanguage('en')");
  );  // 17.01.11upto
  tmp="pi=%pi;////";
  println(SCEOUTPUT,tmp);
  forall(cmdL,
    println(SCEOUTPUT,#+"//");
  );
 closefile(SCEOUTPUT);
);

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
      SCEOUTPUT = openfile("kc.sh");
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
    tmp1=Toupper(substring(#,0,2));
    tmp2=substring(#,tmp,length(#));
    if(tmp1=="CA",
      cat=Toupper(substring(tmp2,0,1));// 16.11.24
      options=remove(options,[#]);
    );
    if(tmp1=="NC",
      ncoL=parse(tmp2);
      options=remove(options,[#]);
    );
    if(tmp1=="EX",
      if(indexof(tmp2,".")==0,ext="."+tmp2,ext=tmp2);
      options=remove(options,[#]);
    );
    if(tmp1=="WA",
      waiting=parse(tmp2);
      options=remove(options,[#]);
    );
    if(tmp1=="DI",
      dig=parse(tmp2);
      options=remove(options,[#]);
    );
    if(tmp1=="FI",  // 16.06.26from
      wfile=tmp2;
      options=remove(options,[#]);
    ); // 16.06.26upto
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
  ); // 16.06.26upto
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
              ); // 15.11.01 upto
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
//      cmdlist=append(cmdlist,tmp);  // 16.03.11 upto
    ,
//      tmp="mputl(['????'],"+Dq+file+".txt"+Dq+");";  // 16.06.2 from
//      cmdlist=concat(cmdlist,[tmp]); // 16.06.2 upto
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
    tmp1=Toupper(substring(#,0,3));
    tmp2=substring(#,tmp,length(#));
    if((tmp1=="DIS") % (tmp1=="DSP") ,
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
      SCEOUTPUT = openfile("kc.sh");
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
//help:CalcbyR(options=["m/r","Wait=2","Out=yes","Pre=yes","Res=" ]);
  regional(options,tmp,tmp1,tmp2,tmp3,realL,strL,eqL,
       cat,dig,preflg,flg,wflg,file,nc,arg,cmdR,cmdlist,wfile,waiting);
  options=optionorg;
  tmp=divoptions(options);
  eqL=tmp_5;
  realL=tmp_6;
  strL=tmp_7;
  dig=5;
  cat="Y";
  wfile="";
  preflg=1;
  waiting=5;
  forall(eqL,
    tmp=indexof(#,"=");
    tmp1=Toupper(substring(#,0,1));
    tmp2=substring(#,tmp,length(#));
    if((tmp1=="C")%(tmp1=="O"),
      cat=Toupper(substring(tmp2,0,1));
      options=remove(options,[#]);
    );
    if(tmp1=="W",
      waiting=parse(tmp2);
      options=remove(options,[#]);
    );
    if(tmp1=="P", //18.01.27
      tmp2=substring(Toupper(tmp2),0,1);
      if(tmp2=="Y",preflg=1);
      if(tmp2=="N",preflg=0);
      options=remove(options,[#]);
    );
    if(tmp1=="D",
      dig=parse(tmp2);
      options=remove(options,[#]);
    );
    if(tmp1=="F",
      wfile=tmp2+".txt"; //18.02.22
      options=remove(options,[#]);
    );
    if(tmp1=="R",
      wfile="result"+tmp2+".txt"; //18.02.22
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
  file=Fhead+name;
  cmdR=[];
  if(preflg==1, //18.01.27from
    cmdR=MkprecommandR();
  );
  cmdR=concat(cmdR,cmd); //18.01.27upto
  cmdlist=[];
  if(dig>5, //16.10.28from
    cmdlist=append(cmdlist,"options(digits="+text(dig+2)+");");
  ); //16.10.28upto
  forall(1..floor(length(cmdR)/2),nc, //17.05.18
    tmp1=cmdR_(2*nc-1);
    tmp1=replace(tmp1,LFmark,""); // 16.06.12
    if(nc==length(cmdR)/2, //16.10.23from
//      if(indexof(tmp1,"=")==0,tmp1="="+tmp1);//16.12.20
    ); //16.10.23uptp
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
    tmp1=tokenize(tmp1,"::");
    if(length(tmp1)==1,
      tmp2=name+"="+tmp1_1;
    ,
      tmp2=name+"=list(";
      forall(tmp1,
        tmp2=tmp2+#+",";
      );
      tmp2=substring(tmp2,0,length(tmp2)-1)+")";
    );
    cmdlist_(length(cmdlist))=tmp2;
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
      cmdlist=append(cmdlist,"}");//18.02.01upto
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
    ); //16.10.23upto
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
      closefile(SCEOUTPUT);//18.02.20upto
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
              tmp=tmp3;
            ,
             tmp=tokenize(tmp3,",");
             tmp=textformat(tmp,dig);
            );
          );
          tmp2=append(tmp2,tmp);
        );
        if(length(tmp2)==1,
          tmp2=tmp2_1;
          if(length(tmp2)==1,tmp2=tmp2_1);
          if(isstring(tmp2),
            if(indexof(tmp2,"nodata")>0,tmp2=[]);
          );
          tmp=name+"="+textformat(tmp2,dig);
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
        tmp=name+"="+tmp3;
        parse(tmp);
      );
    );
  );
);

Rfun(name,fun,argL):=Rfun(name,fun,argL,[]);//16.10.22
Rfun(name,fun,argL,optionorg):=(
//help:Rfun("1","rnorm",[10]);
//help:Rfun(options=["Disp=y"]);
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
    tmp1=Toupper(substring(#,0,3));
    tmp2=substring(#,tmp,length(#));
    if((tmp1=="DIS") % (tmp1=="DSP") ,
      tmp=Toupper(substring(tmp2,0,1));
      if((tmp=="F") % (tmp=="N"),
        disp=0;
      );
      options=remove(options,[#]);
    );
  );
  cmdL=[];
  cmdL=concat(cmdL,[
    nm+"="+fun,argL
  ]);
  options=concat(options,["Wait=2"]);
  CalcbyR(nm,cmdL,options);
  if(ErrFlag==0,
    if(disp==1, // 15.11.24
      println(nm+" is : ");
      println(parse(nm));
    );
  );
  parse(nm);
);

Readcsv(file):=Readcsv(Dirwork,file,[]);
Readcsv(Arg1,Arg2):=(
  if(isstring(Arg2),
    Readcsv(Arg1,Arg2,[]);
  ,
    Readcsv(Dirwork,Arg1,Arg2);
  );
);
Readcsv(pathorg,file,optionorg):=(
//help:Readcsv("ex.csv");
//help:Readcsv(directory,"ex.csv");
//help:Readcsv(options=["Head=yes","Sep=-999","Flat=no","Use=R"]);
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
    tmp=Toupper(substring(tmp1,0,2));
    if(tmp=="HE",
      tmp=Toupper(substring(tmp2,0,1));
      if(tmp=="F" % tmp=="N",
        header=0;
        options=remove(options,[#]);
      );
    );
//    if(tmp=="WA",  // removed:17.02.19
//      waiting=parse(tmp2);
//      options=remove(options,[#]);
//    );
    if(tmp=="SE",
      sep=tmp2;
      options=remove(options,[#]);
    );
    if(tmp=="CS",
      csv=Toupper(substring(tmp2,0,1));
      options=remove(options,[#]);
    );
    if(tmp=="US",
      use=Toupper(substring(tmp2,0,1));
      options=remove(options,[#]);
    );
    if(tmp=="FL",
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
    ); // 16.12.20upto
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
      );// 17.02.10upto
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
  ); // 17.02.09upto
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

Hatchdata(nm,iostr,pltlist):=Hatchdata(nm,iostr,pltlist,[]);
Hatchdata(nm,iostr,pltlist,optionorg):=( //17.09.18
//help:Hatchdata("1","ii",[["gr1"],["gr2","n"]]);
//help:Hatchdata(options=["Wait=5"]);
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
    "Setscaling",[SCALEY],
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
  waiting=3;
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
    if(length(tmp)==0, ErrFlag=2); // 15.11.07 upto
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
    Listplot(name+text(1),[tmp1,tmp2],["Msg=no"]);
    pstr=pstr+Dq+"sg"+name+text(1)+Dq+",";
    tmp1=[bp_2,ypos-dy];
    tmp2=[bp_2,ypos+dy];
    tmp3=[bp_4,ypos+dy];
    tmp4=[bp_4,ypos-dy];
    Listplot(name+text(2),[tmp1,tmp2,tmp3,tmp4,tmp1],["Msg=no"]);
    pstr=pstr+Dq+"sg"+name+text(2)+Dq+",";
    tmp1=[bp_5,ypos-dy/2];
    tmp2=[bp_5,ypos+dy/2];
    Listplot(name+text(3),[tmp1,tmp2],["Msg=no"]);
    pstr=pstr+Dq+"sg"+name+text(3)+Dq+",";
    tmp1=[bp_3,ypos-dy];
    tmp2=[bp_3,ypos+dy];
    Listplot(name+text(4),[tmp1,tmp2],["dr,2","Msg=no"]);
    pstr=pstr+Dq+"sg"+name+text(4)+Dq+",";
    tmp1=[bp_1,ypos];
    tmp2=[bp_2,ypos];
    Listplot(name+text(5),[tmp1,tmp2],["da","Msg=no"]);
    pstr=pstr+Dq+"sg"+name+text(5)+Dq+",";
    tmp1=[bp_4,ypos];
    tmp2=[bp_5,ypos];
    Listplot(name+text(6),[tmp1,tmp2],["da","Msg=no"]);
    pstr=pstr+Dq+"sg"+name+text(6)+Dq+",";
    out=bp_(6..length(bp));
    if(length(out)>0,
      out=apply(out,[#,ypos]);
      Pointdata(name+text(1),out,[0,"Size=4"]);
    );
    pstr=substring(pstr,0,length(pstr)-1)+"]";
    println("generate totally "+name);
    tmp=name+"="+pstr;
    [bp_(1..5),out];
  );
);

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
  waiting=3;
  forall(eqL,
    tmp=indexof(#,"=");
    tmp1=substring(#,tmp,length(#));
    if(Toupper(substring(#,0,1))=="B",
      if(substring(tmp1,0,1)=="[",
        tmp1="c("+substring(tmp1,1,length(tmp1)-1)+")";
      );
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
    if(length(tmp)==0, ErrFlag=2); // 15.11.07 upto
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

Scatterplot(nm,file):=Scatterplot(nm,file,[]);
Scatterplot(nm,file,optionorg):=(
//help:Scatterplot("1",path+filename);
//help:Scatterplot(options=["Reg=yes",A,B,C,"Size"=4"]);
  regional(tmp,tmp1,tmp2,fname,name,reg,eqL,reL,cdysize,
    options,dtx,dty,nn,mx,my,sx,sy,sxy,rr,aa,bb,size);
  name="sc"+nm;
  options=optionorg;
  tmp=divoptions(options);
  eqL=tmp_5;
  reL=tmp_6;
  options=remove(options,reL);
  cdysize=select(options,indexof(#,"size->")>0);
  options=remove(options,cdysize);
  size=4;
  reg="yes";
  forall(eqL,
    tmp=indexof(#,"=");
    tmp1=Toupper(substring(#,0,1));
    tmp2=substring(#,tmp,length(#));
    if(tmp1=="R",
      reg=tmp2;
      options=remove(options,[#]);
    );
    if(tmp1=="S",
      size=parse(tmp2);
      options=remove(options,[#]);
    );
  );
  if(indexof(file,".")==0,
     fname=file+".csv";
  ,
    fname=file;
  );
  Readcsv(nm,fname);
  tmp=concat(options,cdysize);
  Pointdata(name,parse("rc"+nm),append(tmp,"Size="+text(size)));
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
  tmp=Assign("a*x+b",["a",aa,"b",bb]);
  if(reg!="no",
    Plotdata(name,tmp,"x",append(options,"Num=2"));
  );
  if(length(reL)>=2,
    Framedata2(name,[reL_1,reL_2]);
    if(length(reL)>2,
      tmp="r="+textformat(rr,3)+",\ y=";
      tmp=tmp+textformat(aa,3)+"x";
      if(bb>0,tmp=tmp+"+",tmp=tmp+"-");
      tmp=tmp+textformat(abs(bb),3);
      Expr([reL_3,"e",tmp]);
    );
  );
  [mx,my,sx,sy,sxy,rr,bb,aa];
);

Rulerscale(pt,hscale,vscale):=Rulerscale(pt,hscale,vscale,0.1);
Rulerscale(pt,hscale,vscale,tick):=(
//help:Rulerscale(A,["r",0,5,1],["s2",0,2,4]);
//help:Rulerscale(A,["r",0,5,1],["f",10,"a",20,"w2","b"]);
//help:Rulerscale(A,["r",0,5,1],["r",0,10,1],0.2);
  regional(pA,pos,mrk,dir,tmp,tmp1,tmp2,tmp3);
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
        tmp=floor((tmp2-tmp1)/tmp3);
        pos=apply(0..tmp,tmp1+#*tmp3);
        mrk=apply(pos,text(#));
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
      Expr([pos_#,dir_#,mrk_#]);
      tmp1=pos_#;
      tmp2=pos_#-[0,tick/SCALEY];
      Listplot("rsh"+text(#),[tmp1,tmp2],["Msg=no"]);
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
        tmp=floor((tmp2-tmp1)/tmp3);
        pos=apply(0..tmp,tmp1+#*tmp3);
        mrk=apply(pos,text(#));
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
      Expr([pos_#,dir_#,mrk_#]);
      tmp1=pos_#;
      tmp2=pos_#-[tick/SCALEX,0];
      Listplot("rsv"+text(#),[tmp1,tmp2],["Msg=no"]);
    );
  );
);

MkprecommandR():=MkprecommandR(6); 
MkprecommandR(prec):=(
  regional(cmdL,Plist,tmp,tmp1,tmp2);
  Plist=[];
  Pnamelist=[];
  Pvaluelist=[];
  forall(remove(allpoints(),[SW,NE]),
    tmp=textformat(re(Lcrd(#)),prec);
    tmp=RSform(tmp);
    tmp1=#.name;
    tmp1=tmp1+"="+tmp+";Assignadd('"+tmp1+"',"+tmp1+")";
    Plist=append(Plist,tmp1);
  );
  cmdL=[];
  forall(1..(length(Plist)),
    cmdL=concat(cmdL,[Plist_#,[]]);
  );
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
          tmp2=tmp2+textformat(#,6)+",";
        );
        tmp1=substring(tmp2,0,length(tmp2)-1)+"]";
      ,
        tmp1=format(tmp1,6);
      );
    ); 
    tmp1=RSform(tmp1);
    tmp1=tmp+"="+tmp1+";";
    tmp1=tmp1+"Assignadd('"+tmp+"',"+tmp+")";
    cmdL=concat(cmdL,[tmp1,[]]);//17.09.24upto
  );
  forall(OutFileList,
    cmdL=concat(cmdL,["tmp=ReadOutData",[Dq+#+Dq]]);
  );
  forall(FUNLIST,  
    cmdL=concat(cmdL,[#,[]]);
  ); 
  forall(GLIST,
    if(indexof(#,"ReadOutData")==0, //18.02.12
      tmp1=Rform(#); 
      cmdL=concat(cmdL,[tmp1,[]]); 
    );
  );
  cmdL;
);


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
  VLIST=tmp1;// 16.02.03 upto
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
        ); // 16.11.14upto
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
  );  // 16.02.17 upto
  forall(GLIST,
    tmp1=Sciform(#);
    cmdL=concat(cmdL,[tmp1,[]]);
  );
  cmdL;
);

PlotdataS(name1,func,var):=PlotdataS(name1,func,var,[]);
PlotdataS(nm,fun,variable,optionorg):=(
//help:PlotdataS("1","besselj(1,x)","x");
//help:PlotdataS(options=["m/r","Num=50","Wait=5","Mx=no"]);
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
  if(wflg==-1,options=append(options,"r"));// 16.03.02 upto
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
    "Setscaling",[SCALEY],
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
  println(SCEOUTPUT,tmp); // 16.05.18upto
  forall(1..(length(cmdL)),
    tmp1=cmdL_#;
    tmp=indexof(tmp1,";"); // 16.05.18from
    if(tmp>0,endmark=";",endmark="$");
    tmp1=replace(tmp1,";",""); // 16.05.18upto
    if(#==length(cmdL)-1,
      println(SCEOUTPUT,tmp1+";/*##*/");
   ,
      println(SCEOUTPUT,tmp1+endmark+"/*##*/");//16.05.18
   );
  );
  closefile(SCEOUTPUT);
);

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
      SCEOUTPUT = openfile("kc.sh");
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
            // 16.05.18upto
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
    tmp1=Toupper(substring(#,0,3));
    tmp2=substring(#,tmp,length(#));
    if(tmp1=="PRO",  // 16.05.26from
      tmp=Toupper(substring(tmp2,0,1));
      if((tmp=="T") % (tmp=="Y"),
        tmp1=argL_(length(argL));
        tmp=indexof(tmp1,"|");
        if(tmp==0,
          argL_(length(argL))=tmp1+"|dumb=-1,dviout=-2";
        );
      );
    );
  ); // 16.05.26upto
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
    tmp1=Toupper(substring(#,0,3));
    tmp2=substring(#,tmp,length(#));
    if(tmp1=="PRE",
      precise=parse(tmp2);
      options=remove(options,[#]);
    );
    if((tmp1=="DIS") % (tmp1=="DSP"),
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
  out;  //16.05.26upto
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
      SCEOUTPUT = openfile("kc.sh");
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
          forall(4..length(tmp2),println(tmp2_#)); //2016.02.24 upto
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
                );// 16.04.26upto
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
    tmp1=Toupper(substring(#,0,3));
    tmp2=substring(#,tmp,length(#));
    if(tmp1=="PRE",
      precise=parse(tmp2);
      options=remove(options,[#]);
    );
    if((tmp1=="DIS") % (tmp1=="DSP") ,
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
    tmp1=Toupper(substring(#,0,3));
    tmp2=substring(#,tmp,length(#));
	if((tmp1=="DIS") % (tmp1=="DSP") ,
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
      tmp=Dq+PathV3+Dq+" "+tmp1+filename;
      println(SCEOUTPUT,tmp); 
      println(SCEOUTPUT,"exit");
      closefile(SCEOUTPUT);
      println(kc(Dirwork+Batparent,Dirlib,Fnametex));// 16.05.29,06.05
    ,
      SCEOUTPUT = openfile("kc.sh");
      println(SCEOUTPUT,"#!/bin/sh");
      println(SCEOUTPUT,"cd "+Dq+Dirwork+Dq);
      tmp=Dq+PathV3+Dq+" "+tmp1+filename;
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

Mkviewobj(fname,cmdL):=Mkviewobj(Dirwork,fname,cmdL,[]);
Mkviewobj(Arg1,Arg2,Arg3):=(
  if(!isstring(OCNAME), //17.04.13from
    drawtext(mouse().xy,"Mkobjcmd not defined",
        size->24,color->[1,0,0]);
  , //17.04.13upto
    if(islist(Arg2),
      Mkviewobj(Dirwork,Arg1,Arg2,Arg3);
    ,
      Mkviewobj(Arg1,Arg2,Arg3,[]);
    );
  );
);
Mkviewobj(pathorg,fnameorg,cmdLorg,optionorg):=(
//help:Mkviewobj(fname,cmdlist);
//help:Mkviewobj(fname,[]);
//help:Mkviewobj(path,fname,cmdlist);
//help:Mkviewobj(options=["M/R","V","Unit=in","Wait=5"]);
  regional(path,cmdL,eqL,strL,flg,fname,options,make,view,cmdlist,
      vtx,face,unit,tmp,tmp1,tmp2);
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
  forall(eqL,
    tmp=indexof(#,"=");
    tmp1=Toupper(substring(#,0,1));
    tmp2=substring(#,tmp,length(#));
    if(tmp1=="M",
      tmp2=Toupper(substring(tmp2,0,1));     
      if(tmp2=="N" % tmp2=="F",
        make=0;
      );
      options=remove(options,[#]);
    );
    if(tmp1=="V",
      tmp2=Toupper(substring(tmp2,0,1));     
      if(tmp2=="N" % tmp2=="F",
        view=0;
      );
      options=remove(options,[#]);
    );
    if(tmp1=="U", // 16.06.30from
        unit=tmp2;
      options=remove(options,[#]);
    ); // 16.06.30upto
  );
  forall(strL,
    tmp=Toupper(substring(#,0,1));
    if(tmp=="M",
      make=1;
      options=remove(options,[#]);
    );
    if(tmp=="R",
      make=0;
      options=remove(options,[#]);
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
      tmp=["Closeobj()",[],"ans="+Dq+"||||"+Dq,[]];//16.12.26
      cmdlist=concat(cmdlist,tmp);
      tmp=append(options,"Cat=y");
      tmp1=apply(tmp,Toupper(substring(#,0,1))); // 16.04.23from
      tmp1=select(tmp1,#=="W");
      if(length(tmp1)==0,
        tmp=append(tmp,"Wait=5");
      );// 16.04.23upto
      CalcbyR("ans",cmdlist,tmp);
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
  );  // 16.06.30upto
  if(view==1,
    flg=0;  // 16.03.14 from
    if(isstring(ViewFile),
      if(ViewFile==fname,flg=1);
    );
    if(flg==0,
      kcV3(path,fname);
      ViewFile=fname;
    );  // 16.03.14 upto
  );
);

SetObj(str):=Objname(str,["m","v"]); //17.01.12
SetObj(str,options):=Objname(str,options); //17.01.12
Objnameoptions(str,options):=Objname(str,options);// 16.11.29
Objname(str):=Objname(str,["m","v"]); // 16.11.29
Objname(str,optionsorg):=(
//help:Objname("sample");
//help:Objname(options=["m","v"]);
//help:Setobj("sample");
//help:Setobj(options=["m","v"]);
  regional(options);
  if(length(str)>0,
    OCNAME=str;
  );
  options=select(optionsorg,length(#)>0); //17.12.23from
  if(length(options)>0,
    OCOPTION=options;
  ,
    OCOPTION=["m","v"];
  ); //17.12.23upto
  println([OCNAME,OCOPTION]);
);

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
  println("cmd seq oc"+nm+" generated"); // 16.06.10upto
  OBJCMD=concat(OBJCMD,out);//16.11.29
  out;
);

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
    "n:factor(n)",[], // 16.04.21upto
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
  ); // 16.05.02upto
  out;
);

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
  );  // 16.04.21upto
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
//    ); // 16.05.09upto
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
  println("cmd seq oc"+nm+" generated"); // 16.06.10upto
  OBJCMD=concat(OBJCMD,out);//16.11.29
  out;
);

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
  out=["Objpolyhedron",[tmp1,tmp2]];//17.12.24upto
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
  println("cmd seq oc"+nm+" generated"); // 16.06.10upto
  OBJCMD=concat(OBJCMD,out);//16.11.29
  out;
);

Mkobjplatecmd(nm,pd):=Mkobjplatecmd(nm,pd,[]);
Mkobjplatecmd(nm,pdorg,optionorg):=( // 16.06.18
//help:Mkobjplatecmd("1",pd);
//help:Mkobjplatecmd("1",vtxlist);
//help:Mkobjplatecmd(options1=[0.05,-0.05]);
  regional(pd,options,cmd,out,thick1,thick2,nn,pdn,
     reL,vtx,face,nv,npttmp,tmp1,tmp2,tmp3,tmp4);
  pd=pdorg;
  if(MeasureDepth(pd)==1,pd=[pd]);
  if(MeasureDepth(pd)==2,pd=[pd]);//16.10.04from
  forall(1..length(pd),nn, // 16.06.19from
    pdn=pd_nn;
    vtx=pdn_1;
    if(length(pdn)==1,face=[1..(length(vtx))],face=pdn_2);
    vtx=apply(vtx,if(isstring(#),parse(#),#)); 
    vtx=apply(vtx,if(ispoint(#),parse(text(#)+"3d"),#));
    pd_nn=[vtx,face];//16.10.04upto
  ); // 16.06.19upto
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
      out=concat(out,["Objpolyhedron",[tmp3,tmp4]]);//17.12.24upto
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
  if(MeasureDepth(tmp1)==2,flg=1);
  if(MeasureDepth(tmp1)==0,
    if(islist(tmp1),flg=1);
  );
  if(flg==1,  // 16.04.23upto
    if(!isstring(tmp1_1),
      forall(1..length(tmp1),
        tmp=["Objcurve",[pst+"[["+text(#)+"]]",thick,poly,dir]];//17.12.22
        out=concat(out,tmp);
       );
    ,
      forall(1..length(tmp1), // 16.11.14from
        tmp=["Objcurve",[tmp1_#,thick,poly,dir]];
        out=concat(out,tmp); 
       );// 16.11.14upto
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
  println("cmd seq oc"+nm+" generated"); // 16.06.10upto
  OBJCMD=concat(OBJCMD,out);//16.11.29
  out;
);

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
    ); //17.12.24upto
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
    ); // 16.04.23upto
    dtL=Readbezier(symb,opbez);
    dtLstr=dtL; //17.12.23
	setdirectory(Dirwork);
    forall(dtL,dt,
      tmp=dt+"=";
      tmp1=select(GLIST,indexof(#,tmp)>0);
      if(length(tmp1)>0,//17.12.23from
        tmp1=tmp1_1;
        out=concat(out,[tmp1,[]]);
      ); //17.12.23upto  
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
      ); //17.12.23upto
    );
  );
  tmp1=text(options);
  tmp1=substring(tmp1,1,length(tmp1)-1);
  tmp2=""; //17.12.23from
  forall(dtL,
    tmp2=tmp2+","+#;
  );
  tmp2="list("+substring(tmp2,1,length(tmp2))+")"; //17.12.23upto
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
  println("cmd seq oc"+symborg+" generated"); // 16.06.10upto
  OBJCMD=concat(OBJCMD,out);//16.11.29
  out;
);

Concatcmd(cmdlist):=(
//help:Concatcmd([cmdL1,cmdL2]);
  regional(out);
  out=[];
  forall(cmdlist,
    out=concat(out,#);
  );
  out;
);

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
      SCEOUTPUT = openfile("kc.sh");
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
      SCEOUTPUT = openfile("kc.sh");
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
    tmp1=Toupper(substring(#,0,3));
    tmp2=substring(#,tmp,length(#));
    if((tmp1=="DIS") % (tmp1=="DSP") ,
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

Mkketcindyjs():=Mkketcindyjs("ketcindylib"); 
Mkketcindyjs(Arg):=(
  if(isstring(Arg),
    Mkketcindyjs(Arg,[])
  ,
    Mkketcindyjs("ketcindylib",Arg)
  );
);
Mkketcindyjs(libname,options):=( //17.11.18
//help:Mkketcindyjs();
//help:Mkketcindyjs(options="Tex=y","Net=y"]);
  regional(texflg,netflg,tmp,tmp1,tmp2);
  texflg="Y";
  netflg="Y";
  forall(options,
    tmp1=Toupper(#);
    if(indexof(tmp1,"TEX")>0,
      tmp=indexof(tmp1,"=");
      texflg=Toupper(substring(tmp1,tmp,tmp+1));
    );
    if(indexof(tmp1,"NET")>0,
      tmp=indexof(tmp1,"=");
      netflg=Toupper(substring(tmp1,tmp,tmp+1));
    );
  );
  if(isexists(Dirwork,Fhead+".html"),
    SCEOUTPUT = openfile(Fhead+".r");
    println(SCEOUTPUT,"Looprange<- function(a,b){");
    println(SCEOUTPUT,"  if (a<=b) return(a:b)");
    println(SCEOUTPUT,"  return(c())");
    println(SCEOUTPUT,"}");
    println(SCEOUTPUT,"setwd('"+Dirfile+"/CindyJS')");
    println(SCEOUTPUT,"Dtket=readLines('"+libname+".txt')");
    println(SCEOUTPUT,"setwd('"+Dirwork+"')");
    println(SCEOUTPUT,"Dtjs=readLines('"+Fhead+".html')");
    println(SCEOUTPUT,"Qt=rawToChar(as.raw(34))");
    println(SCEOUTPUT,
     "Dtinit=c(paste('<script id=',Qt,'csinit',Qt,' type=',Qt,'text/x-cindyscript',Qt,'>',sep=''))");
    println(SCEOUTPUT,"Dtinit=c(Dtinit,Dtket,'</script>')");
    println(SCEOUTPUT,"Dthead=c()");
    println(SCEOUTPUT,"for(I in Looprange(1,length(Dtjs))){");
    println(SCEOUTPUT,"  if(length(grep('<script id=',Dtjs[I],fixed=TRUE))==0){");
    println(SCEOUTPUT,"    Tmp=Dtjs[I]");
    if(netflg=="N",
      println(SCEOUTPUT,
        "    if(length(grep('link rel=',Tmp,fixed=TRUE))>0){");
      println(SCEOUTPUT,
        "      Tmp1='file:///"+Dirfile+"/CindyJS/CindyJS.css'");
      println(SCEOUTPUT,
        "      Tmp=paste('    <link rel=',Qt,'stylesheet',Qt,' href=',Qt,Tmp1,Qt,'>',sep='')");
      println(SCEOUTPUT,
        "    }");
      println(SCEOUTPUT,
        "    Tmp1=length(grep('script type=',Tmp,fixed=TRUE))");
      println(SCEOUTPUT,
        "    Tmp1=Tmp1*length(grep('Cindy.js',Tmp,fixed=TRUE))");
      println(SCEOUTPUT,
        "    if(Tmp1>0){");
      println(SCEOUTPUT,
        "      Tmp1='file:///"+Dirfile+"/CindyJS/Cindy.js'");
      println(SCEOUTPUT,
        "      Tmp=paste('    <script type=',Qt,'text/javascript',Qt,' src=',Qt,Tmp1,Qt,'>',sep='')");
      println(SCEOUTPUT,
        "      Tmp=paste(Tmp,'</script>',sep='')");
      println(SCEOUTPUT,
        "    }");
    );
    println(SCEOUTPUT,
      "    Dthead=c(Dthead,Tmp)");
    println(SCEOUTPUT,
      "  }else{");
    println(SCEOUTPUT,
      "     Is=I; break");
    println(SCEOUTPUT,
      "  }");
    println(SCEOUTPUT,
        "}");
    println(SCEOUTPUT,"Dt=c()");
    println(SCEOUTPUT,"for(I in Looprange(Is,length(Dtjs))){");
    println(SCEOUTPUT,"  Dt=c(Dt,Dtjs[I])");
    println(SCEOUTPUT,"  if(length(grep('</script>',Dtjs[I],fixed=TRUE))>0){");
    println(SCEOUTPUT,"    if(length(grep('draw',Dt[1],fixed=TRUE))>0){Dtdraw=Dt}");
    println(SCEOUTPUT,"    if(length(grep('keytyped',Dt[1],fixed=TRUE))>0){Dtkey=Dt}");
    println(SCEOUTPUT,"    Dt=c()");
    println(SCEOUTPUT,"    if(length(grep('<script id=',Dtjs[I+1],fixed=TRUE))==0){");
    println(SCEOUTPUT,"      Ie=I+1;break");
    println(SCEOUTPUT,"    }");
    println(SCEOUTPUT,"  }");
    println(SCEOUTPUT,"}");
    println(SCEOUTPUT,"Dt=c(Dthead,Dtdraw,Dtkey,Dtinit)");
    println(SCEOUTPUT,"for(I in Looprange(Ie,length(Dtjs))){");
    println(SCEOUTPUT,
       "  if(length(grep('Button',Dtjs[I],fixed=TRUE))>0){");
    println(SCEOUTPUT,
       "    if(length(grep(paste(Qt,'Figure',sep=''),Dtjs[I],fixed=TRUE))>0){next}");
    println(SCEOUTPUT,
       "    if(length(grep(paste(Qt,'Exekc',sep=''),Dtjs[I],fixed=TRUE))>0){next}");
    println(SCEOUTPUT,
       "    if(length(grep(paste(Qt,'Parent',sep=''),Dtjs[I],fixed=TRUE))>0){next}");
    println(SCEOUTPUT,
       "    if(length(grep(paste(Qt,'KeTJS',sep=''),Dtjs[I],fixed=TRUE))>0){next}");
  println(SCEOUTPUT,
         "  }");
    println(SCEOUTPUT,"  Dt=c(Dt,Dtjs[I])");
    if(texflg=="Y",
      println(SCEOUTPUT,
        "  if(length(grep(paste(Qt,'cs*',Qt,sep=''),Dtjs[I],fixed=TRUE))>0){");
      println(SCEOUTPUT,
        "    Dt=c(Dt,paste('  use: [',Qt,'katex',Qt,'],',sep=''))");
      println(SCEOUTPUT,
        "  }");
    );
    println(SCEOUTPUT,"}");
    println(SCEOUTPUT,"writeLines(Dt,'"+Fhead+"ketcindy.html',sep='\n')");
    println(SCEOUTPUT,"quit()");
    closefile(SCEOUTPUT);
    kcR(PathR,Fhead+".r",["m"]);
  ,
    drawtext(mouse().xy-[0,1],"First export to CindyJS",size->24,color->[1,0,0]);
    wait(3000);
  );
);

Cheader():=Cheader(FdC,FheadC+"header.h");
Cheader(fdc,fname):=(
  regional(tmp,tmp1,tmp2,j, dW,dE,dS,dN,dstr,
      DsizeLL,DsizeL,DsizeM,DsizeS,Eps,Eps1,Eps2,Eps3);
  Mdv=50; Ndv=50; 
  DsizeLL=15000; DsizeL=1500; DsizeM=500; DsizeS=200;
  Eps=0.00001; Eps1=0.05; Eps2=0.2; Eps3=1;
  SCEOUTPUT = openfile(fname);
  tmp=indexof(fdc_2,"=");
  tmp1=substring(fdc_2,tmp,length(fdc_2));
  tmp1=replace(tmp1,"[","{");
  tmp1=replace(tmp1,"]","}");
  tmp=indexof(fdc_3,"=");
  tmp2=substring(fdc_3,tmp,length(fdc_3));
  tmp2=replace(tmp2,"[","{");
  tmp2=replace(tmp2,"]","}");
  tmp="const double Urng[2]="+tmp1+", Vrng[2]="+tmp2;
  println(SCEOUTPUT,tmp+";");
  tmp="const double XMIN="+Sprintf(XMIN,6);
  tmp=tmp+",XMAX="+Sprintf(XMAX,6);
  println(SCEOUTPUT,tmp+";");
  tmp="const double THETA="+Sprintf(THETA,6);
  tmp=tmp+",PHI="+Sprintf(PHI,6);
  println(SCEOUTPUT,tmp+";");
  tmp="  //THETA:"+Sprintf(THETA*180/pi,2);
  tmp=tmp+", PHI:"+Sprintf(PHI*180/pi,2);
  println(SCEOUTPUT,tmp+";");
  dstr=fdc_4;
  if(indexof(dstr,"w")>0,dW=1,dW=0);
  if(indexof(dstr,"e")>0,dE=1,dE=0);
  if(indexof(dstr,"s")>0,dS=1,dS=0);
  if(indexof(dstr,"n")>0,dN=1,dN=0);
  tmp="const int DrawW="+text(dW)+", DrawE="+text(dE);
  tmp=tmp+", DrawS="+text(dS)+", DrawN="+text(dN);
  println(SCEOUTPUT,tmp+";");
  forall(j=5..(length(fdc)),
    tmp=fdc_#; //17.05.21from
    if(length(tmp)==2,
       if(tmp_1>1, //17.05.24from
         Mdv=tmp_1; Ndv=tmp_2;
       ,
         if(length(tmp_1)>0, Eps1=tmp_1);
         if(length(tmp_1)>0, Eps2=tmp_2);	
       );	 //17.05.24upto
    );
    if(length(tmp)==3,
      if(length(tmp_1)>0, DsizeLL=tmp_1);//17.06.09(3lines)
      if(length(tmp_2)>0, DsizeL=tmp_2);
      if(length(tmp_3)>0, DsizeM=tmp_3);
    );
    if(length(tmp)==4,
      if(min(tmp)<1,
        if(length(tmp_1)>0, Eps=tmp_1);
        if(length(tmp_2)>0, Eps1=tmp_2);
        if(length(tmp_3)>0, Eps2=tmp_3);
        if(length(tmp_4)>0, Eps3=tmp_4);
      ,
        if(length(tmp_1)>0, DsizeLL=tmp_1);
        if(length(tmp_2)>0, DsizeL=tmp_2);
        if(length(tmp_3)>0, DsizeM=tmp_3);
        if(length(tmp_4)>0, DsizeS=tmp_4);
      )  
    );//17.05.21upto
  );
  tmp1=text(fdc_5_1);
  tmp2=text(fdc_5_2);
  tmp="const int Mdv="+text(Mdv)+", Ndv="+text(Ndv);
  println(SCEOUTPUT,tmp+";");
  tmp="#define DsizeLL "+text(DsizeLL);//17.05.21
  println(SCEOUTPUT,tmp);
  tmp="#define DsizeL "+text(DsizeL);
  println(SCEOUTPUT,tmp);
  tmp="#define DsizeM "+text(DsizeM);
  println(SCEOUTPUT,tmp);
  tmp="#define DsizeS "+text(DsizeS);
  println(SCEOUTPUT,tmp);
  tmp="const double Eps="+format(Eps,7);
  tmp=tmp+", Eps1="+format(Eps1,7);
  tmp=tmp+", Eps2="+format(Eps2,7);
  tmp=tmp+", Eps3= "+format(Eps3,7);
  println(SCEOUTPUT,tmp+";");
  tmp="void surffun(double u, double v, double pt[3]){";
  println(SCEOUTPUT,tmp);
  forall(fdc_1,
    tmp1=replace(#,"x=","pt[0]=");
    tmp1=replace(tmp1,"y=","pt[1]=");
    tmp1=replace(tmp1,"z=","pt[2]=");
    println(SCEOUTPUT,"  "+tmp1+";");
  );
  println(SCEOUTPUT,"}");
  closefile(SCEOUTPUT);
);

Cmain():=Cmain(FheadC+".c",MainC);
Cmain(fname,cmdLorg):=(
//help:MainC(writesfbd("sfbd");)
//help:MainC(writeax("ax");)
//help:MainC(writewire("wire" (,2), [10,10]);)
//help:MainC(writewire("wire", [[0.5,1],[0,1,2]]]);)
//help:MainC(writecut("sfcut","x+y+2*z-4");)
//help:MainC(writesc("sl3d1");)
//help:MainC(skeleton("sk",[objlist],[pltlist] (,width));)
//help:MainC(writewire ptincrease (=2)  are optional);)
  regional(cmdL, tmp,tmp1,tmp2,tmp3,tmp4,nL, nn,kk,jj, num, en,cmd, 
                 ax1,ax2,ax3,path, var,varh,file,fileh, flg, cutctr);
  path=Dirwork+"/";  //17.05.29from
  path=replace(path,"\","/");
  cmdL=cmdLorg;// 17.05.26from
  nL=select(1..(length(cmdL)),cmdL_#=="writeax");
  cmd=[];
  if(length(nL)>0,tmp3=cmdL_(1..(nL_1-1)),tmp3=[]);
  forall(1..(length(nL)),
    tmp2=cmdL_(nL_#+1);
    if(length(tmp2)==1,tmp2=append(tmp2,"Surf"));
    tmp=tmp2_1; // 17.06.08(5lines)
    if(substring(tmp,length(tmp)-2,length(tmp))!="3d",
      tmp=tmp+"3d";
    );
    tmp1=parse(tmp);
    tmp="axx="+textformat(tmp1_1,5);
    parse(tmp);
    tmp="axy="+textformat(tmp1_2,5);
    parse(tmp);
    tmp="axz="+textformat(tmp1_3,5);
    parse(tmp);
    tmp3=concat(tmp3,[
      "double "+tmp2_1+"[DsizeL][3];",[], //17.06.07(2lines)
      "double axx[3][3], axy[3][3], axz[3][3];",[],
      "spaceline",["axx"],
      "spaceline",["axy"],
      "spaceline",["axz"],
       tmp2_1+"[0][0]=0;",[],
      "appendd3(2,1,2,axx,"+tmp2_1+");",[],
      "appendd3(2,1,2,axy,"+tmp2_1+");",[],
      "appendd3(2,1,2,axz,"+tmp2_1+");",[],
      "writecrv",[tmp2_1,tmp2_2] //17.06.07
    ]);
	cmd=concat(cmd,tmp3);
      if(#<length(nL),
      tmp3=cmdL_((nL_#+2)..(nL_(#+1)-1));
    ,
      tmp3=cmdL_((nL_#+2)..(length(cmdL)));
      cmdL=concat(cmd,tmp3);
    );
  );
  nL=select(1..(length(cmdL)),cmdL_#=="writesc");
  cmd=[];
  if(length(nL)>0,tmp3=cmdL_(1..(nL_1-1)),tmp3=[]);
  forall(1..(length(nL)),
    tmp2=cmdL_(nL_#+1);
    if(length(tmp2)==1,
      tmp2=[tmp2_1,"Surf"];
    );
    tmp3=concat(tmp3,[
      "double "+tmp2_1+"[DsizeL][3];",[], //17.06.07(2lines)
      "double "+tmp2_1+"h[DsizeL][3];",[],
      "spaceline",[tmp2_1],
      "writecrv",[tmp2_1,tmp2_2] //17.06.07
    ]);
    cmd=concat(cmd,tmp3);
    if(#<length(nL),
      tmp3=cmdL_((nL_#+2)..(nL_(#+1)-1));
    ,
      tmp3=cmdL_((nL_#+2)..(length(cmdL)));
      cmdL=concat(cmd,tmp3);
    );
  );
  nL=select(1..(length(cmdL)),cmdL_#=="writesfbd");
  cmd=[];
  if(length(nL)>0,tmp3=cmdL_(1..(nL_1-1)),tmp3=[]);
  forall(1..(length(nL)),
    tmp2=cmdL_(nL_#+1);
    if(length(tmp2)==1,tmp2=append(tmp2,"Surf"));
    var=Dq+tmp2_1+"3d"+Dq;
    varh=Dq+tmp2_1+"h3d"+Dq;
    file=Dq+path+FheadC+tmp2_1+".txt"+Dq; 
    fileh=Dq+path+FheadC+tmp2_1+"h.txt"+Dq; 
    tmp="Borderhiddendata";
    tmp3=concat(tmp3,[
      "double "+tmp2_1+"[DsizeL][3];",[], //17.06.09(6lines)
     "sfbdparadata",[tmp2_1],
     "output3h",[var, varh,file,tmp2_1],
     "dataindexd3",[3,tmp2_1,"din"],
     tmp2_2+"[0][0]=0;",[],
     "appendd3",[2,"din[1][0]","din[1][1]",tmp2_1,tmp2_2]
     ]);
    cmd=concat(cmd,tmp3);
    if(#<length(nL),
      tmp3=cmdL_((nL_#+2)..(nL_(#+1)-1));
    ,
      tmp3=cmdL_((nL_#+2)..(length(cmdL)));
      cmdL=concat(cmd,tmp3);
    );
  );
  nL=select(1..(length(cmdL)),cmdL_#=="writecrv");
  cmd=[];
  if(length(nL)>0,tmp3=cmdL_(1..(nL_1-1)),tmp3=[]);
  forall(1..(length(nL)),
	tmp2=cmdL_(nL_#+1);
    if(length(tmp2)==1,tmp2=append(tmp2,"Surf"));
    var=Dq+tmp2_1+"3d"+Dq;
    varh=Dq+tmp2_1+"h3d"+Dq;
    file=Dq+path+FheadC+tmp2_1+".txt"+Dq; 
    tmp3=concat(tmp3,[
      "crvsfparadata",[tmp2_1,tmp2_2,1,"Crvdata"],
       tmp2_1+"[0][0]=0;",[], //17.06.09(3lines)
      "appendd3",[0,1,"length3(Crvdata)","Crvdata",tmp2_1],
      "output3h",[var,  varh, file,tmp2_1]
    ]);
    cmd=concat(cmd,tmp3);
    if(#<length(nL),
      tmp3=cmdL_((nL_#+2)..(nL_(#+1)-1));
    ,
      tmp3=cmdL_((nL_#+2)..(length(cmdL)));
      cmdL=concat(cmd,tmp3);
    );
  );
  nL=select(1..(length(cmdL)),cmdL_#=="writescrvonsf");
  cmd=[];
  if(length(nL)>0,tmp3=cmdL_(1..(nL_1-1)),tmp3=[]);
  forall(1..(length(nL)),
    tmp2=cmdL_(nL_#+1);
    if(length(tmp2)==1,tmp2=append(tmp2,"Surf"));
    var=Dq+tmp2_1+"3d"+Dq;
    varh=Dq+tmp2_1+"h3d"+Dq; //17.06.09(8lines)
    file=Dq+path+FheadC+tmp2_1+".txt"+Dq; 
    tmp3=concat(tmp3,[
      "double "+tmp2_1+"[DsizeL][3];",[], 
      " crv3onsfparadata",[tmp2_1,tmp2_2,1,"Crvdata"],
      tmp2_1+"[0][0]=0;",[],
      "appendd3",[0,1,"length3(Crvdata)","Crvdata",tmp2_1],
      "output3h",[var,varh, file ,tmp2_1]
    ]);
    cmd=concat(cmd,tmp3);
    if(#<length(nL),
      tmp3=cmdL_((nL_#+2)..(nL_(#+1)-1));
    ,
      tmp3=cmdL_((nL_#+2)..(length(cmdL)));
      cmdL=concat(cmd,tmp3);
    );
  );
  nL=select(1..(length(cmdL)),cmdL_#=="writecut");
  cmd=[];
  if(length(nL)>0,tmp3=cmdL_(1..(nL_1-1)),tmp3=[]);
  cutctr=0;
  forall(1..(length(nL)),
    cutctr=#;
    tmp2=cmdL_(nL_#+1);
    if(length(tmp2)==2,
      tmp2=[tmp2_1,"Surf",tmp2_2];
    );
    var=Dq+tmp2_1+"3d"+Dq;
    varh=Dq+tmp2_1+"h3d"+Dq; //17.06.09(10lines)
    file=Dq+path+FheadC+tmp2_1+".txt"+Dq; 
    tmp3=concat(tmp3,[
      "cutfun",[tmp2_3], 
      "double "+tmp2_1+"[DsizeL][3];",[], 
      "sfcutdata",[text(cutctr),"out"], //17.06.02
      "crv3onsfparadata",["out",tmp2_2,"Crvdata"],
       tmp2_1+"[0][0]=0;",[], 
      "appendd3",[0,1,"length3(Crvdata)","Crvdata",tmp2_1],
      "output3h",[var, varh, file, tmp2_1]
    ]);
    cmd=concat(cmd,tmp3);
    if(#<length(nL),
      tmp3=cmdL_((nL_#+2)..(nL_(#+1)-1));
    ,
      tmp3=cmdL_((nL_#+2)..(length(cmdL)));
      cmdL=concat(cmd,tmp3);
    );
  );
  nL=select(1..(length(cmdL)),cmdL_#=="writewire");
  cmd=[];
  if(length(nL)>0,tmp3=cmdL_(1..(nL_1-1)),tmp3=[]);
  forall(1..(length(nL)),
    tmp2=cmdL_(nL_#+1);
    if(!isstring(tmp2_2),
      tmp2=[tmp2_1,"Surf",tmp2_2,tmp2_3];
    );
    var=Dq+tmp2_1+"3d"+Dq;
    varh=Dq+tmp2_1+"h3d"+Dq; //17.06.09
    file=Dq+path+FheadC+tmp2_1+".txt"+Dq; 
    tmp4=tmp2_(length(tmp2)); num=2;
    if(!islist(tmp4),
      num=tmp4; tmp4=tmp2_(length(tmp2)-1);
    );
    if(!islist(tmp4_1),
      tmp3=concat(tmp3,[
         "double udv[2]={-1,"+text(tmp4_1)+"};",[]
      ]);
    ,
      len=length(tmp4_1);
      tmp="double udv["+text(len+1)+"]={"+text(len)+",";
      forall(tmp4_1,
        tmp=tmp+format(#,5)+",";
      );
      tmp=substring(tmp,0,length(tmp)-1)+"};";
      tmp3=concat(tmp3,[tmp,[]]);
    );
    if(!islist(tmp4_2),
      tmp3=concat(tmp3,[
         "double vdv[2]={-1,"+text(tmp4_2)+"};",[]
      ]);
    ,
	  len=length(tmp4_2);
      tmp="double vdv["+text(len+1)+"]={"+text(len)+",";
      forall(tmp4_2,
        tmp=tmp+format(#,5)+",";
      );
      tmp=substring(tmp,0,length(tmp)-1)+"};";
      tmp3=concat(tmp3,[tmp,[]]);
    );
    tmp3=concat(tmp3,[
      "double "+tmp2_1+"[DsizeLL][3];",[],  //17.06.09(5lines)
      "wireparadata",["Surf", "udv","vdv", num, "Wiredata"],
       tmp2_1+"[0][0]=0;",[],
      "appendd3",[0,1,"length3(Wiredata)","Wiredata",tmp2_1],
      "output3h",[var, varh, file, tmp2_1]
    ]);
    cmd=concat(cmd,tmp3);
    if(#<length(nL),
      tmp3=cmdL_((nL_#+2)..(tmp_(#+1)-1));
    ,
      tmp3=cmdL_((nL_#+2)..(length(cmdL)));
      cmdL=concat(cmd,tmp3);
    );
  );// 17.05.29upto
  nL=select(1..(length(cmdL)),cmdL_#=="skeleton");// 17.06.05from
  cmd=[];
  if(length(nL)>0,
    tmp3=cmdL_(1..(nL_1-1));
    tmp3=concat(tmp3,["double sk[DsizeLL][3];",[]]);//17.06.13
  ,
    tmp3=[];
  );
  forall(1..(length(nL)),nn,
    tmp2=cmdL_(nL_nn+1);
    var=Dq+tmp2_1+"3d"+Dq;
    file=Dq+path+FheadC+tmp2_1+".txt"+Dq; 
    tmp3=concat(tmp3,[ //17.06.08from
      "data[0][0]=0;",[]
    ]);
    forall(tmp2_2, 
      if(substring(#,length(#)-1,length(#))!="h", 
        tmp1=#;
        tmp=[0,"din[1][0]","din[1][1]",tmp1,"data"];
      ,
        tmp1=substring(#,0,length(#)-1);
        tmp=[0,"din[2][0]","din[2][1]",tmp1,"data"];
      );
      tmp3=concat(tmp3,[ 
      "dataindexd3",[3,tmp1,"din"],
      "appendd3",tmp
      ]);
    );
    forall(1..(length(tmp2_3)),
      if(substring(tmp2_3_#,length(tmp2_3_#)-1,length(tmp2_3_#))!="h", 
        tmp1=tmp2_3_#;
        tmp=[0,"din[1][0]","din[1][1]",tmp1,"data"];
      ,
        tmp1=substring(tmp2_3_#,0,length(tmp2_3_#)-1);
        tmp=[0,"din[2][0]","din[2][1]",tmp1,"data"];
      );
      tmp3=concat(tmp3,[
      "push3",["Inf",3,0,"data"],
      "dataindexd3",[3,tmp1,"din"],
      "appendd3",tmp
      ]);
    );
    if(length(tmp2)<=3,tmp=1,tmp=tmp2_4);
    tmp3=concat(tmp3,[
      "skeletondata3",["data", tmp, "Eps1","Eps2","sk"],//17.06.13
      "output3",[var, file, 2, "sk"]
    ]);
    cmd=concat(cmd,tmp3);
    if(nn<length(nL),
      tmp3=cmdL_((nL_nn+2)..(nL_(nn+1)-1));
    ,
      tmp3=cmdL_((nL_nn+2)..(length(cmdL)));
      cmdL=concat(cmd,tmp3);
    );//17.06.08upto
  );// 17.06.05upto
  path=DirlibC+"/";
  path=replace(path,"\","/");
  cmd=[
    "#include <stdio.h>", "#include <math.h>",
    "#include "+Dq+FheadC+"header.h"+Dq,
    "#include "+Dq+path+"ketcommon.h"+Dq,
    "#include "+Dq+path+"surflibhead.h"+Dq,
    "#include "+Dq+path+"surflib.h"+Dq,
    "int main(void){",
    "  double out[DsizeL][3], data[DsizeLL][3];", //17.06.10
    "  int i, j, nall, din[DsizeS][2];" //17.06.09
  ];
//  tmp=select(cmdL,#=="cutfun");
//  if(length(tmp)==0,
  if(cutctr==0, //17.06.02
    cmdL=prepend(["1"],cmdL);
    cmdL=prepend("cutfun",cmdL);
  );// 17.05.26upto
  cutctr=0;
  forall(1..(floor(length(cmdL))/2),nn,
    tmp1=cmdL_(2*nn-1); tmp2=cmdL_(2*nn);
    flg=0; // 17.05.26from
    if(tmp1=="cutfun",
       cutctr=cutctr+1;
       tmp=select(1..(length(cmd)), indexof(cmd_#,"main")>0);
       tmp3=cmd_((tmp_1)..(length(cmd)));
       cmd=cmd_(1..(tmp_1-1));
       cmd=append(cmd,"double cutfun"+text(cutctr)+"(double u, double v){");
       cmd=append(cmd,"  double p[3],val;");
       cmd=append(cmd,"  surffun(u,v,p);");
       tmp="  val="+assign(tmp2_1,["x","p[0]","y","p[1]","z","p[2]"])+";";
       cmd=concat(cmd, [tmp,"  return val;", "}"]);
       cmd=concat(cmd, tmp3);
       flg=1;
    );
    if(tmp1=="xyzax3data",
      tmp="  "+tmp1+"(";
      tmp=tmp+textformat(tmp2_1_1_1_1,5)+",";
      tmp=tmp+textformat(tmp2_1_1_2_1,5)+",";
      tmp=tmp+textformat(tmp2_1_2_1_2,5)+",";
      tmp=tmp+textformat(tmp2_1_2_2_2,5)+",";
      tmp=tmp+textformat(tmp2_1_3_1_3,5)+",";
      tmp=tmp+textformat(tmp2_1_3_2_3,5)+",";
      tmp=tmp+tmp2_2+");";
      cmd=append(cmd,tmp);
      flg=1;
    );
    if(tmp1=="spaceline",
      if(!isstring(tmp2_1),
        println(tmp2_1+" should be assgined as a string");
      ,
        tmp3=parse(tmp2_1);
        tmp=text(length(tmp3)+1);
//        cmd=append(cmd, "  double "+tmp2_1+"["+tmp+"][3];");
        tmp=text(length(tmp3));
        cmd=append(cmd, "  "+tmp2_1+"[0][0]="+tmp+";");
        forall(1..(length(tmp3)),
          tmp="  "+tmp2_1+"["+text(#)+"][0]="+textformat(tmp3_#_1,5)+",";
          tmp=tmp+tmp2_1+"["+text(#)+"][1]="+textformat(tmp3_#_2,5)+",";
          tmp=tmp+tmp2_1+"["+text(#)+"][2]="+textformat(tmp3_#_3,5)+";";
          cmd=append(cmd,tmp);
        );
      );
      flg=1;
    );
	if(flg==0,
      tmp="  "+tmp1;
      if(length(tmp2)>0,
        tmp=tmp+"(";
        forall(1..length(tmp2),kk,
          if(isstring(tmp2_kk),
            if((kk==1)&(substring(tmp1,0,5)=="write"),
              file=path+FheadC+tmp2_kk+".txt"; 
              fileh=path+FheadC+tmp2_kk+"h.txt"; 
              tmp=tmp+Dq+tmp2_kk+Dq+","+Dq+file+Dq+","+Dq+fileh+Dq; 
            ,
              tmp=tmp+tmp2_kk;
            );
          ,
            if(!islist(tmp2_kk),
              tmp=tmp+textformat(tmp2_kk,5);
            , 
            );
          );
          if(kk<length(tmp2),
            tmp=tmp+",";
          ,
            tmp=tmp+");";
          );
        );
      );
	  cmd=append(cmd, tmp);// 17.05.26upto
	);
  );
  tmp=select(1..(length(cmd)), indexof(cmd_#,"main")>0);//17.06.02from
  tmp3=cmd_((tmp_1)..(length(cmd)));
  cmd=cmd_(1..(tmp_1-1));
  cmd=append(cmd,"double cutfun(int ch, double u, double v){");
  cmd=append(cmd,"  double val;");
  forall(1..cutctr,
    tmp=text(#);
    cmd=append(cmd,"  if(ch=="+tmp+"){val=cutfun"+tmp+"(u,v);}");
  );
  cmd=concat(cmd,["  return val;", "}"]);
  cmd=concat(cmd, tmp3);//17.06.02upto
  cmd=concat(cmd, ["  return 0;", "}"]);
  SCEOUTPUT = openfile(fname);
  forall(cmd,
    println(SCEOUTPUT,#);
  );
  closefile(SCEOUTPUT);
  tmp=fileslist(Dirwork); // 17.05.20from
  tmp=tokenize(tmp,",");
  tmp=select(tmp,indexof(#,".txt")>0);
  tmp=select(tmp,indexof(#,FheadC)>0);
  forall(tmp, 
     SCEOUTPUT = openfile(#);
     println(SCEOUTPUT,"");
     closefile(SCEOUTPUT);
  ); // 17.05.20upto
);

kcC():=kcC(FheadC);
kcC(cname):=(
  regional(tmp, tmp1, flg);
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
    println(SCEOUTPUT,"%path%\main.exe");
    println(SCEOUTPUT,"echo //// > %path%\resultC.txt");
    println(SCEOUTPUT,"exit");
    closefile(SCEOUTPUT);
    tmp=cname+".txt";
    println(kc(Dirwork+Batparent,Mackc+Dirlib,tmp));
  ,
    SCEOUTPUT = openfile("kc.sh");
    println(SCEOUTPUT,"#!/bin/sh");
    println(SCEOUTPUT,"cd "+Dq+Dirwork+Dq);
    tmp=PathC+" "+cname+".c -o main.out";
    println(SCEOUTPUT,tmp);
    println(SCEOUTPUT,"./main.out");
    println(SCEOUTPUT,"echo //// > resultC.txt");
    println(SCEOUTPUT,"exit 0");
    closefile(SCEOUTPUT);
    tmp=cname+".txt";
    println(kc(Dirwork+Shellparent,Mackc+Dirlib,tmp));
  );
  SCEOUTPUT=openfile("resultC.txt");
  println(SCEOUTPUT,"");
  closefile(SCEOUTPUT);
  flg=0;
  repeat(floor(10*1000/WaitUnit),
    if(flg==0,
      tmp1=load("resultC.txt");
	  if(substring(tmp1,0,4)=="////",
        flg=1;
      );
      wait(WaitUnit);
    );
  );
  if(flg==0,
    println("Ckc not completed");
  ,
    println("Ckc succeeded");
  );
);

ReadCdata(var, fname):=ReadCdata(var, fname,[]);
ReadCdata(var, fname,options):=(
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
  opstr=tmp_8;
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
  );//17.06.16upto
);

WriteCdata(fnameorg,dataorg):=(
//help:WriteCdata(filename, 3ddata);
  regional(tmp,fname,data,kk,nn,pt);
  data=dataorg;
  if(isstring(data),data=parse(data));
  if(MeasureDepth(data)==1,data=[data]);
  fname=fnameorg;
  if(indexof(fname,".")==0, fname=fname+".txt");
  SCEOUTPUT=openfile(fname);
  forall(1..(length(data)),kk,
    forall(1..(length(data_kk)),nn,
      pt=apply(1..3,Sprintf(data_kk_nn_#,5));
      tmp=pt_1+" "+pt_2+" "+pt_3;
      println(SCEOUTPUT,tmp);
    );
    if(kk<length(data),
      println(SCEOUTPUT,"99999.00000 2.00000 0.00000");
    );
  );
  closefile(SCEOUTPUT);
);

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
    opcindy=tmp_9;
    forall(eqL,
      if(Toupper(substring(#,0,2))=="CO",
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
    ReadCdata(var,file,options);// 17.05.24
    if(cflg==1,
      Texcom("}");
    );
  );
);

//help:end();

