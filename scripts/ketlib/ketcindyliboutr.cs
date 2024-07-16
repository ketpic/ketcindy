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

println("ketcindylibout[20240502] loaded");

//help:start();

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
    tmp1=Readlines(tmp2); //200509
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
    MkprecommandR(8,Arg); //190921
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
MkprecommandR(dig,chstr):=( //190921 pre->dig
  regional(cmdL,Plist,tmp,tmp1,tmp2);
  cmdL=[];
  cmdL=concat(cmdL,["arccos=acos; arcsin=asin; arctan=atan",[]]); //181209
  if(indexof(chstr,"P")>0,
    Plist=[];
    forall(remove(allpoints(),[SW,NE]),
      tmp=textformat(re(Lcrd(#)),dig);
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
            tmp2=tmp2+textformat(#,dig)+",";
          );
          tmp1=substring(tmp2,0,length(tmp2)-1)+"]";
        ,
          tmp1=format(tmp1,dig);
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
//help:CalcbyR(options1=["m/r","Wait=2","Out=y/n","Dig=8","Pre=PVFG"]);
//help:CalcbyR(options2=["Pre=!G" ]);
  regional(options,tmp,tmp1,tmp2,tmp3,realL,strL,eqL,
       cat,dig,prestr,flg,wflg,file,nc,arg,cmdR,cmdlist,wfile,waiting);
  options=optionorg;
  tmp=divoptions(options);
  eqL=tmp_5;
  realL=tmp_6;
  strL=tmp_7;
  dig=8; //190921
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
      tmp=Readlines(wfile); //200509
      if(length(tmp)==0,wflg=1);
    );
  );
  if(length(name)>0,//180412from
    file=Fhead+name;
  ,
    file=Cindyname();
  );//180412to
  cmdR=[];
  cmdR=MkprecommandR(dig,prestr); //190921
  cmdR=concat(cmdR,cmd); //18.01.27to
  cmdlist=[];
  if(dig>5, //16.10.28from
    cmdlist=append(cmdlist,"options(digits="+text(dig+2)+");");
  ); //16.10.28until
  forall(1..floor(length(cmdR)/2),nc, //17.05.18
    tmp1=cmdR_(2*nc-1);
    tmp1=replace(tmp1,LFmark,""); // 16.06.12
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
      tmp=file+".r"; //210216from
      if(!isexists(Dirwork,tmp),
        tmp1=""
      ,
        tmp1=Readlines(tmp);
      ); //210216to
      if(length(tmp1)==0,
        wflg=1;
      );
    );
    if(wflg==0, //110621from
      forall(1..(length(cmdlist)),nc, 
        tmp=cmdlist_nc;
        tmp=replace(tmp,"-0.","mzp");
        tmp=replace(tmp,"-0","0");
        tmp=replace(tmp,"mzp","-0.");
        cmdlist_nc=tmp;
      );
      tmp1=Readlines(Dirwork,Cdyname()+name+".r"); 
      tmp=select(1..(length(tmp1)),indexof(tmp1_#,"window")>0);
      tmp1=tmp1_((tmp_1+1)..(length(tmp1)));
      tmp1=apply(tmp1,replace(#,"##",""));    
      forall(1..(length(tmp1)),nc,
        tmp=tmp1_nc;
        tmp=replace(tmp,"-0.","mzp");
        tmp=replace(tmp,"-0","0");
        tmp=replace(tmp,"mzp","-0.");
        tmp1_nc=tmp;
      );
      tmp2=select(1..(length(tmp1)),cmdlist_#!=tmp1_#);
      if(tmp1==cmdlist,wflg=0,wflg=1);
    ); // 220621to
    if(wflg==0,wflg=-1);
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
      if(flg==0, //200610from
        tmp=load("errormessageR.txt");
        if(length(tmp)>0,
          println("Error in R");
          println(tmp);
          flg=-2;
        );
      ); //200610to
      if(flg==0,
        tmp=Readlines(wfile); //200509from
        if(wflg==1,wait(Waitunit));
        if(length(tmp)>0,
          tmp2=tmp_(length(tmp));
          if(tmp2=="////",
            tmp=tmp_(1..(length(tmp)-1)); //200509to
            flg=1;
            tmp2=#*WaitUnit/1000;
          );
        ,
          if(wflg==-1,
            flg=-1;
          );
        );
      );
    );
    if(flg<=0,
      ErrFlag=1;
      if(flg==-1,
        println(wfile+" does not exist");
        ErrFlag=-1; //200610
      ); //200610from
      if(flg==-2,
        ErrFlag=-1; //200610
      );
      if(flg==0,
        tmp="("+text(waiting)+" s )";
        println(wfile+" not generated "+tmp);
      ); //200610to
    ,
      println("      CalcbyR succeeded "+name+" ("+text(tmp2)+" sec)");
      if(cat=="Y", // 16.10.29,11.25
        tmp1=apply(tmp,replace(#,"##","")); //200509from
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
        tmp=name+"="+tmp3+";";//180227//190415
        parse(tmp);
      );
    );
  );
  flg; //210827
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
//help:PlotdataR(options=["Num=50","Pre=PVF","Wait=10"]); //191020
  regional(options,tmp,tmp1,tmp2,tmp3,name,varstr,flg,Num,pre,
         Ltype,Noflg,eqL,strL,flg,outreg,filename,wfile,cmdL,waiting);
  name="grR"+name1;
  options=optionorg;
  tmp=Divoptions(options);
  eqL=tmp_5;
  strL=tmp_7;
  Num=50;
  waiting=5;
  outreg=0;
  pre="PVF";
  flg=0;
  forall(eqL,
    tmp=Strsplit(#,"=");
    tmp1=Toupper(substring(tmp_1,0,1));
    if(tmp1=="N",
      Num=parse(tmp_2);
      options=remove(options,[#]);
    );
    if(tmp1=="W",
      waiting=parse(tmp_2);
      options=remove(options,[#]);
    );
    if(tmp1=="O",
      tmp2=Toupper(substring(tmp_2,0,1));
      if(tmp2=="T" % tmp2=="Y", outreg=1);
      options=remove(options,[#]);
    );
    if(tmp1=="P", //191020from
      pre=tmp_2;
      options=remove(options,[#]);
    ); //191020to
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
  cmdL=MkprecommandR(pre); //191020
  cmdL=concat(cmdL,[
    name+"=Plotdata",[Dqq(func),Dqq(varstr),Dqq("Num="+text(Num))],
    "WriteOutData",[Dqq(wfile),Dqq(name),name]
  ]);
  if(ErrFlag==0,
    tmp=["Cat=middle","Wait="+text(waiting)];  //191020[2lines]
    CalcbyR(name,cmdL,concat(options,tmp));
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
    tmp1=name+"="+textformat(tmp,5)+";";
    parse(tmp1);
    tmp2=apply(tmp,Lcrd(#));
    tmp2;
  );
);
////%PlotdataR end////

////%PlotdiscR start////
PlotdiscR(nm,fun,varrng):=PlotdiscR(nm,fun,varrng,[]);
PlotdiscR(nm,fun,varrng,optionorg):=(
//help:PlotdiscR("1","dbinom(k,10,0.4)","k=[0,10]");
//help:PlotdiscR(options=["Pre=PVF","Wait=10"]); //191020
  regional(name,pb,cmdL,var,range,tmp,tmp1,tmp2,
         pre,waiting,options,wfile,eqL);
  name="grd"+nm;
  options=optionorg; //191020from
  options=select(options,length(#)>0);
  tmp=Divoptions(options);
  eqL=tmp_5;
  waiting=5;
  pre="VF";  //200509
  forall(eqL,
    tmp=Strsplit(#,"=");
    tmp1=Toupper(substring(tmp_1,0,1));
    if(tmp1=="W",
      waiting=parse(tmp_2);
      options=remove(options,[#]);
    );
    if(tmp1=="P", //191020from
      pre=tmp_2;
      options=remove(options,[#]);
    );
  ); //191020
  tmp=indexof(varrng,"=");
  var=substring(varrng,0,tmp-1);
  range=parse(substring(varrng,tmp,length(varrng)));
  if(length(range)==2,
    range=(range_1)..(range_2);
  );
  wfile=Fhead+name+".txt";
  cmdL=MkprecommandR(pre); //191020from
  cmdL=concat(cmdL,[
    "fnb=function("+var+") "+fun,[],
    name+"=sapply",[range,"fnb"]
  ]);  //191020to
  if(ErrFlag==0,
    tmp=["Wait="+text(waiting)]; //191020[2lines]
    CalcbyR(name,cmdL,concat(options,tmp));
  );
  if(ErrFlag==1,
    println("PlotdiscR not completed");
  ,
    tmp1=Readlines(wfile); //200509from
    tmp1=replace(tmp1_1,"##",""); //200509to
    pb=tokenize(tmp1,",");
    tmp=apply(range,[#,pb_(#+1)]);
    Listplot("-"+name,tmp,options); //190424
  );
);
////%PlotdiscR end////

////%Boxplot start////
Boxplot(nm,dataorg,ypos,dy):=Boxplot(nm,dataorg,ypos,dy,[]);
Boxplot(nm,dataorg,ypos,dy,optionorg):=(
//help:Boxplot("1",dt(or file), 2(ypos), 1/2(dy),[""]);
  regional(options,name,data,cmdL,
      bp,pstr,out,flg,tmp,tmp1,tmp2,tmp3,tmp4,);
  name="bp"+nm;
  options=optionorg;
  data=dataorg;
  if(isstring(data), //200510from
    if(indexof(data,".")==0,
      tmp=parse(data);
      data=Textformat(tmp,6);
    ,
      data=replace(data,"\","/");
      tmp=Indexall(data,"/");
      if(length(tmp)>0,
        tmp=tmp_(length(tmp));
        tmp1=substring(data,0,tmp-1);
        tmp2=substring(data,tmp,length(data));
        data=Readlines(tmp1,tmp2);
      ,
        data=Readlines(data);
      );
      if(length(data)>0,
        data=data_1;
      );
      data=replace(data,"##","");
      if(substring(data,0,1)!="[",data="["+data+"]");
    );
  ,
    data=Textformat(data,6);
  );
  data=RSform(data);
  cmdL=[
    "data="+data,[],
    "tmp=boxplot",["data","plot=FALSE"],
    "tmp1=tmp$stat",[],
    "tmp2=tmp$out",[],
    name+"=c(tmp1,tmp2)",[]
  ];
  CalcbyR(name,cmdL,options); //200510to
  bp=parse(name);
  pstr="[";
  tmp1=[bp_1,ypos-dy/2];
  tmp2=[bp_1,ypos+dy/2];
  Listplot("-"+name+"L",[tmp1,tmp2],[]);
  pstr=pstr+Dq+"sg"+name+text(1)+Dq+",";
  tmp1=[bp_2,ypos-dy];
  tmp2=[bp_2,ypos+dy];
  tmp3=[bp_4,ypos+dy];
  tmp4=[bp_4,ypos-dy];
  Listplot("-"+name+"B",[tmp1,tmp2,tmp3,tmp4,tmp1],[]);
  pstr=pstr+Dq+"sg"+name+text(2)+Dq+",";
  tmp1=[bp_5,ypos-dy/2];
  tmp2=[bp_5,ypos+dy/2];
  Listplot("-"+name+"R",[tmp1,tmp2],[]);
  pstr=pstr+Dq+"sg"+name+text(3)+Dq+",";
  tmp1=[bp_3,ypos-dy];
  tmp2=[bp_3,ypos+dy];
  Listplot("-"+name+"C",[tmp1,tmp2],["dr,2"]);
  pstr=pstr+Dq+"sg"+name+text(4)+Dq+",";
  tmp1=[bp_1,ypos];
  tmp2=[bp_2,ypos];
  Listplot("-"+name+"HL",[tmp1,tmp2],["da"]);
  pstr=pstr+Dq+"sg"+name+text(5)+Dq+",";
  tmp1=[bp_4,ypos];
  tmp2=[bp_5,ypos];
  Listplot("-"+name+"HR",[tmp1,tmp2],["da"]);
  pstr=pstr+Dq+"sg"+name+text(6)+Dq+",";
  out=bp_(6..length(bp));
  if(length(out)>0,
    out=apply(out,[#,ypos]);
    Pointdata(name,out,["Color=green","Size=2","Inside=white"]); //190125
  );
  pstr=substring(pstr,0,length(pstr)-1)+"]";
  println("generate data "+name);
  tmp=name+"="+pstr;
  [bp_(1..5),[out]];
);
////%Boxplot end////

////%Histplot start//
Histplot(nm,dataorg):=Histplot(nm,dataorg,[]);
Histplot(nm,dataorg,optionorg):=(
//help:Histplot("1",data (fillename));
//help:Histplot(options=["Breaks=","Den=no","Rel=no"]);
  regional(options,name,data,hp,cmdL,tmp,tmp1,tmp2,tmp3,tmp4,
    out,eqL,breaks,right,bdata,cdata,pstr,flg,density,relative);
  name="hp"+nm;
  options=optionorg;
  tmp=divoptions(options);
  eqL=tmp_5;
  breaks = "breaks="+Dq+"Sturges"+Dq;
  right="right=TRUE"; //201105
  density=0;
  relative=0;
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
    if(tmp1=="R", //201105from
      tmp2=Toupper(substring(tmp_2,0,1));
      if(tmp2=="F",right="right=FALSE");
      options=remove(options,[#]);
    ); //201105to
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
  );
  data=dataorg;
  if(isstring(data), //200510from
    if(indexof(data,".")==0,
      tmp=parse(data);
      data=Textformat(tmp,6);
    ,
      data=replace(data,"\","/");
      tmp=Indexall(data,"/");
      if(length(tmp)>0,
        tmp=tmp_(length(tmp));
        tmp1=substring(data,0,tmp-1);
        tmp2=substring(data,tmp,length(data));
        data=Readlines(tmp1,tmp2);
      ,
        data=Readlines(data);
      );
      if(length(data)>0,
        data=data_1;
      );
      data=replace(data,"##","");
      if(substring(data,0,1)!="[",data="["+data+"]");
    );
  ,
    data=Textformat(data,6);
  );
  data=RSform(data);
  cmdL=[
    "data="+data,[],
	"tmp=hist",["data","plot=FALSE",breaks,right], //201105
    "tmp1=tmp$breaks",[],
    "tmp2=tmp$count",[],
    "tmp3=tmp$density",[],
    name+"=c(tmp1,tmp2,tmp3)",[]
  ];
  CalcbyR(name,cmdL,options); //200510to
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
    Listplot("-"+name+text(#),[tmp1,tmp2,tmp3,tmp4,tmp1],options);
    pstr=pstr+Dq+name+text(#)+Dq+",";  //201105
  );
  pstr=substring(pstr,0,length(pstr)-1)+"]";
  println("generate totally "+name); 
  tmp=name+"="+pstr+";"; //190415
  parse(tmp);
  [bdata,cdata];
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
  parse("rc"+nm+"="+Textformat(tmp,5)+";"); //181013to //190415
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

////%Dotfilldata start////
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
////%Dotfilldata end////

////////Asir//////////

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
    tmp1=Readlines(tmp2); //200514
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
    tmp1=Readlines(file+".rr"); //200514from
    if(length(tmp1)==0,
      wflg=1;
    ,
      tmp=select(1..(length(tmp1)),indexof(tmp1_#,"/*####*/")>0);
      tmp1=tmp1_((tmp_1+1)..(length(tmp1)));
      tmp1=apply(tmp1,replace(#,"/*##*/","")); //200514to
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
      tmp=Readlines(wfile); //200514from
      if(length(tmp)>0,
        if(tmp_(length(tmp))=="////]",
          tmp=tmp_(1..(length(tmp)-1));
          num="1234567890+-.";
          tmp3=apply(tmp,replace(#,"//","")); //200514to
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
//		  tmp1=substring(tmp1,0,length(tmp1)-1)+"];"; //190415
          parse(name+"="+tmp1);
          tmp=parse(name);
          if(length(tmp)==1,
            tmp1=substring(tmp1,1,length(tmp1)-1);
            parse(name+"="+tmp1+";"); //190415
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

////%AsfunO start////
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
    parse(nm+"="+tmp+";"); //190415
  );
  if(ErrFlag==0,
    if(disp==1, // 15.11.24
      println(nm+" is : ");
      println(parse(nm));
    );
  );
  out;  //16.05.26until
);
////%AsfunO end////

////////Maxima//////////

////%WritetoM start////
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
        if(length(tmp1)>0, //240501from
          tmp=substring(tmp1,length(tmp1)-1,length(tmp1));
          if(!contains(["(",","],tmp),
            tmp1=tmp1+"$/*##*/";
          ,
            tmp1=replace(tmp1,",,","");
          );//240501to
          println(SCEOUTPUT,tmp1);
        );//240501to
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
////%WritetoM end////

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
    tmp1=Readlines(tmp2); //200514
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

////%CalcbyM start//// 231217
CalcbyM(name,cmd):=CalcbyM(name,cmd,[]);
CalcbyM(name,cmdorg,optionorg):=(
//help:CalcbyM("a",cmdL);
//help:CalcbyM(options1= ["m/r","Wait=5","Errchk=y(/n)","Dig=6","Pow=no","All=y"]);
//help:CalcbyM(options2= ["line=1000"]);
  regional(options,tmp,tmp0,tmp1,tmp2,tmp3,tmp4,realL,strL,eqL,
      allflg,indL,line,dig,flg,wflg,file,nc,arg,add,powerd,
      cmdM,cmd.cmdlist,wfile,errchk,waiting,num,st);
  cmd=[]; //231217from
  forall(1..(length(cmdorg)),
    tmp1=cmdorg_#;
    if(#<length(cmdorg),
	    tmp2=cmdorg_(#+1);
	  ,
	    tmp2="";
	  );
    cmd=append(cmd,tmp1);
    if(isstring(tmp1),
      if(isstring(tmp2),
        cmd=append(cmd,[]);
      );
    );
  ); //231217to
  ErrFlag=0;
  options=optionorg;
  tmp=divoptions(options);
  eqL=tmp_5;
  realL=tmp_6;
  strL=tmp_7;
  wfile="";
  errchk="Y"; //190411
  waiting=5;
  dig=6;
  allflg=1;
  powerd="false";
  line=1000; // 16.06.13
  forall(eqL,
    tmp=Strsplit(#,"=");
    tmp1=Toupper(substring(tmp_1,0,1));
    tmp2=tmp_2;
    if(tmp1=="E",
      errchk=Toupper(substring(tmp_1,0,1)); //190411
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
  wfile=Fhead+name+".txt"; //190411
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
      forall(1..(length(tmp1)),
        if(substring(tmp1,#-1,#+1)=="::",
          if(substring(tmp2,0,1)==":",
            tmp2=substring(tmp2,1,length(tmp2))
          );
          cmdlist=append(cmdlist,"disp("+tmp2+")");
          tmp2="";
        ,
          tmp2=tmp2+substring(tmp1,#-1,#);
        );
      );
      if(length(tmp2)>0,
         if(substring(tmp2,0,1)==":",
           tmp2=substring(tmp2,1,length(tmp2))
         );
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
    tmp=file+".max"; //210216from
    if(!isexists(Dirwork,tmp),
      tmp1=""
    ,
      tmp1=Readlines(tmp);
    );  //210216to
    if(length(tmp1)==0,
      wflg=1;
    ,
      tmp1=apply(tmp1,replace(#,"/*##*/","")); //200509
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
  if(wflg==0,wflg=-1); // 15.10.16
  if(wflg==1,
    if(length(wfile)>0,   // 15.10.05
      SCEOUTPUT=openfile(wfile);
      println(SCEOUTPUT,"");
      closefile(SCEOUTPUT);
    );
    WritetoM(file+".max",cmdlist,allflg); // 20160223
    kcM(file,concat(options,["m"]));
  );
  flg=0;
  tmp1=floor(waiting*1000/WaitUnit);
  repeat(tmp1,
    if(flg==0,
      if(isexists(Dirwork,wfile), //201015from
        tmp1=Readlines(wfile);
      ,
        tmp1=[];
      ); //201015to
      if(wflg==1,wait(WaitUnit)); // 20160223
      if(length(tmp1)>0,
        tmp=select(tmp1,(indexof(#,"error")>0)%(indexof(#,"syntax")>0));
        if((length(tmp)>0)&(errchk=="Y"), //190411
          println("Some error(s) occurred"); //2016.02.24 from
          forall(1..length(tmp1),println(tmp1_#)); //2016.02.24 until
          flg=2;  //20160223
        ,
          tmp2=select(1..(length(tmp1)), //240117from
                indexof(tmp1_#,"disp(")>0);
		  if(length(tmp2)==0,
		    tmp3=[]; //240120
		  ,
		    tmp=select(1..(length(tmp1)),
			      indexof(tmp1_#,"closefile")>0);
			tmp2=append(tmp2,tmp_1);
		    tmp3=[]; //240120
			forall(1..(length(tmp2)-1),nc,
			  tmp="";
			  forall((tmp2_(nc)+1)..(tmp2_(nc+1)-1),
			    tmp=tmp+Removespace(tmp1_#);
			  );
			  tmp3=append(tmp3,tmp); //240120
			);//240117to
            tmp3=apply(tmp3,replace(#,".d+0","")); //240120
            if(length(tmp3)==1,//240121from
              parse(name+"="+Dqq(tmp3_1)+";");
            ,
              tmp="";
              forall(1..(length(tmp3)),
                tmp=tmp+Dqq(tmp3_#)+",";
              );
              tmp="["+substring(tmp,0,length(tmp)-1)+"]";
              parse(name+"="+tmp+";");
            ); //240121to
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
      tmp1=Readlines(wfile); //200514
      if(length(tmp1)>0,
        println(wfile+" incomplete"+tmp); // 2016.02.24
      ,
        println(wfile+" not generated "+tmp);
      );
    );
  ,
    if(flg==1,  // 20160223
      println("      CalcbyM succeeded "+name+" ("+text(tmp2)+" sec)");
    );
  );
  flg;
);
////%CalcbyM end////

////%CalcbyMset start////
CalcbyMset(var,ans,cmdL):=
 CalcbyMset(var,ans,cmdL,["Wait=10"]);
CalcbyMset(var,ans,cmdL,oporg):=(
//help:CalcMset(var1,"ans1",cmdL1,[""]);
 regional(op,tmp,tmp1,flg,ctr);
 op=oporg;
 tmp=select(op,indexof(#,"W")>0);
 if(length(tmp)==0,
  op=append(op,"Wait=10");
 );
 ctr=1;
 flg=-1;
 while((flg<1)&(ctr<10), //240212from
  flg=CalcbyM(ans,append(cmdL,var),op);
  ctr=ctr+1;
 );
 if(flg==1,
   Mxsetvar(var,parse(ans),"n");
 ,
   println("CalcbyM failed");
 ); //240212to
 flg;
);
////%CalcbyMset end////

////%CalcbyMsetdisp start////240226
CalcbyMsetdisp(var,ans,cmdL,oporg):=(
//help:CalcMsetdisp(var1,"ans1",cmdL1,[""]);
//help:CalcMsetdisp(var1,"ans1",cmdL1,[[1,,0.5],""]);
 regional(op,varL,bwL,flg,tmp,tmp1);
//global Pos,Dy,Size
//help:CalcMset(var1,"ans1",cmdL1,[""]);
 op=oporg;
 varL=Strsplit(var,"::");
 bwL=[];
 tmp=select(op,islist(#));
 if(length(tmp)>0,
   bwL=tmp_1;
   op=remove(op,tmp);
 );
 flg=CalcbyMset(var,ans,cmdL,op);
 if(flg==1,
   forall(1..(length(varL)),
     if(#<=length(bwL),
       if(length(bwL_#)>0,
          Disptex(varL_#,bwL_#);
	   ,
	      Disptex(varL_#);
       );
	 ,
	   Disptex(varL_#);
     );
   );
 );
);
////%CalcbyMsetdisp end////

////%Mxdata start////
Mxdata(fname):=Mxdata(fname,"");
Mxdata(fname,rmv):=
    Mxdata(Dircdy+"/fig",fname,rmv);
Mxdata(dir,fnameorg,rmv):=(
 regional(var,fname,data,tmp,tmp1,tmp2,tmp3,nc,name);
 fname=Cdyname()+fnameorg;
 fname=replace(fname,rmv,"")+".txt";
 var=[];
 data=Readlines(dir,fname);
 tmp2=select(1..(length(data)),
         indexof(data_#,"disp(")>0);
 var=[];
 forall(1..(length(tmp2)),nc,
   tmp=tmp2_nc;
   tmp3=data_tmp;
   tmp=indexof(tmp3,"disp(");
   tmp3=substring(tmp3,tmp,length(tmp3));
   tmp=indexof(tmp3,"(");
   tmp3=substring(tmp3,tmp,length(tmp3)-1);
   var=append(var,tmp3);
 );
 tmp=select(1..(length(data)),
			   indexof(data_#,"closefile")>0);
 tmp2=append(tmp2,tmp_1);
 tmp3=[];
 forall(1..(length(tmp2)-1),nc,
   tmp="";
   forall((tmp2_(nc)+1)..(tmp2_(nc+1)-1),
     tmp=tmp+Removespace(data_#);
   );
   tmp3=append(tmp3,tmp);
 );
 tmp3=apply(tmp3,replace(#,".d+0",""));
 forall(1..(length(var)),nc,
   tmp1=var_nc;
   tmp2=Dqq(tmp3_nc);
   parse(tmp1+"="+tmp2+";");
 );
 tmp=var;
 var="";
 forall(tmp,
  var=var+#+"::";
 );
 var=substring(var,0,length(var)-2);
 var;
);
////%Mxdata end////

////%Parsel start////
ParseL(strL):=(
//help:ParseL(strlist);
 regional(sL,out,tmp);
 sL=strL;
 out=[];
 forall(sL,
   tmp=#;
   if(isstring(tmp),tmp=parse(tmp));
   out=append(out,tmp);
 );
);
////%Parsel end////

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
    tmp=Strsplit(#,"=");
    tmp1=Toupper(substring(tmp_1,0,1)); //190424
    tmp2=tmp_2;
    if(tmp1=="P",
      precise=parse(tmp2);
      options=remove(options,[#]);
    );
    if(tmp1=="D" ,  //190327(to 1 char)
      tmp=Toupper(substring(tmp2,0,1));
      if((tmp=="F") % (tmp=="N"),
        disp=0;
      );
      options=remove(options,[#]);
    );
    if((tmp1=="P") % (tmp1=="L"),  //190327(to 1 char)
      pack=tokenize(tmp2,"::");
      options=remove(options,[#]);
    );
    if(tmp1=="S",  //190327(to 1 char)
      set=tokenize(tmp2,"::");
      options=remove(options,[#]);
    );
    if(tmp1=="A",  //190327(to 1 char)
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
    "ans"
  ]);
  CalcbyM(nm,cmdL,options);
  if(ErrFlag==0,
    if(disp==1, //240120from
      println(nm+" is : ");
      println(parse(nm));
    ); //240120to
  );
  nm; //240120to
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
  tmp=name+"="+Dq+out+Dq+";"; //16.01.10//190415
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
  tmp="tx"+nm+"="+out+";"; //190415
  parse(tmp);
  println("tx"+nm+"is:");
  apply(out,println(#));
  out;
);
////%MxtexL end////

////%Mxbatch start////  //20231204
Mxbatch(file):=Mxbatch(Dirlib+"/maximaL/",file);
Mxbatch(dir,file):=(
//help:Mxbatch(["matoperation.max"]);
//help:Mxbatch(Dircdy,["matoperation.max"]);
  regional(figL,out,path,tmp,tmp1,tmp2);
  if(!islist(file),figL=[file],figL=file);
  path=replace(dir,"\","/");
  out=[];
  forall(figL,
    if(indexof(#,".")==0,tmp1=#+".max",tmp1=#);
    tmp1=Dq+path+tmp1+Dq;
    tmp2=["batch",[tmp1]];
    out=concat(out,tmp2);
  );
  out;
);
////%Mxbatch end////

////%Mxsetvar start//// 231212
Mxsetvar(var,ansorg):=Mxsetvar(var,ansorg,"p");
Mxsetvar(var,ansorg,parflg):=(
//help:Mxsetvar("A::B",ans);
//help:Mxsetvar(["p1","p2"],ans,"p");
//help:Mxsetvar(["eq1","eq2"],ans,"n");
 regional(tmp,vst,ans);
 vst=var;
 if(isstring(var),
   tmp=Strsplit(var,"::");
   vst=apply(tmp,#);
 );
 ans=ansorg;
 if(!islist(ans),ans=[ans]);
 forall(1..(length(vst)),
   if(contains(["p","1"],parflg),
     tmp=vst_#+"="+ans_#+";";
   ,
     tmp=vst_#+"="+Dqq(ans_#)+";";
   );
   parse(tmp);
 );
);
////%Mxsetvar end////

////%Mxfactor start////
Mxfactor(str,norg):=(
//help:Mxfactor("(a+b)*(c+d)",-1);
  regional(n,tmp,tmp1,tmp,out);
  out=str;
  n=norg;
  tmp=Bracket(str);
  tmp1=select(tmp,#_2>0); //240116
  if(length(tmp1)>0,
    if(n<0,n=length(tmp1)-(-n-1)); //240116from
    tmp1=tmp1_n;
    tmp2=select(tmp,(#_1>tmp1_1)&(#_2==-tmp1_2));
   tmp1=tmp1_1; //240116to
    tmp2=tmp2_1_1;
    out=substring(str,tmp1,tmp2-1);
  );
  out;
);
////%Mxfactor end////

////%Dispexpr start//// 240220
Dispe(name):=Dispexpr(0,name,0,[]);
Dispe(Arg1,Arg2):=(
  if(isstring(Arg1),
    if(islist(Arg2),
	  Dispexpr(0,Arg1,0,Arg2);
	,
      Dispexpr(0,Arg1,Arg2,[]);
	);
  ,
    Dispexpr(Arg1,Arg2,0,[]);
  );
);
Dispe(Arg1,Arg2,Arg3):=(
  if(isstring(Arg1),
    Dispexpr(0,Arg1,Arg2,Arg3);
  ,
    if(islist(Arg3),
      Dispexpr(Arg1,Arg2,0,Arg3);
	,
	  Dispexpr(Arg1,Arg2,Arg3,[]);
	);
  );
);  
Dispexpr(lineorg,name,vsp,op):=(
//help:Dispexpr("pA");
//help:Dispexpr(3,"pA");
//help:Dispexpr(0,"pA",["Size=1.2"]);
//help:Dispexpr(0,"pA",0.5);
 regional(line,tmp);
// global Pos, Dy
 line=lineorg;
 if(line==0,line="");
 tmp=parse(name);
 if(!isstring(tmp),tmp=format(tmp,12));
 if(isreal(line),
   Expr(Pos,"e",line+"\;\;"+name+"="+tmp,op);
 ,
   Expr(Pos+[0.3,0],"e",name+"="+tmp,op);
 );
 Pos_2=Pos_2-vsp-Dy;
);
////%Dispexpr end////

////%Disptexexpr start//// 231222
Disptex(name):=Disptexexpr(0,name,0,[]);
Disptex(Arg1,Arg2):=(
  if(isstring(Arg1),
    if(islist(Arg2),
	  Disptexexpr(0,Arg1,0,Arg2);
	,
      Disptexexpr(0,Arg1,Arg2,[]);
	);
  ,
    Disptexexpr(Arg1,Arg2,0,[]);
  );
);
Disptex(Arg1,Arg2,Arg3):=(
  if(isstring(Arg1),
    Disptexexpr(0,Arg1,Arg2,Arg3);
  ,
    if(islist(Arg3),
      Disptexexpr(Arg1,Arg2,0,Arg3);
	,
	  Disptexexpr(Arg1,Arg2,Arg3,[]);
	);
  );
);  
Disptexexpr(lineorg,name,vsp,op):=(
//help:Disptexexpr(0,"pA");
//help:Disptexexpr(3,"pA");
//help:Disptexexpr("","pA",["Size=1.2"]);
//help:Disptexexpr("","pA",0.5);
 regional(line,tmp);
// global Pos, Dy
 line=lineorg;
 if(line==0,line="");
 tmp=Totexform(parse(name));
 if(!isstring(tmp),tmp=format(tmp,12));
 if(isreal(line),
   Expr(Pos,"e",line+"\;\:"+name+"="+tmp,op);
 ,
   Expr(Pos+[0.3,0],"e",name+"="+tmp,op);
 );
 Pos_2=Pos_2-vsp-Dy;
);
////%Disptexexpr end////

////%Vspace start//// 231226
Vspace(dy):=(
  //global Pos
  Pos_2=Pos_2-dy;
);
////%Vspace end//// 231226

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


////////V3//////////

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
    tmp1=Readlines(fname); //200515
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
  parse("oc"+nm+"="+tmp2+";"); //190415
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
    tmp="Fnrmden"+nm+"("+xst+","+yst+"):="+tmp_2+";"; //190415
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
  parse("oc"+nm+"="+tmp2+";"); //190415
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
  parse("oc"+nm+"="+tmp2+";"); //190415
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
  parse("oc"+nm+"="+tmp3+";"); //190415
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
  parse("oc"+nm+"="+tmp2+";"); //190415
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
    tmp=Dirhead+"/data/fontF";  // 16.05.10
    dtL=Readbezier(tmp,symb,opbez);
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
  parse("oc"+symborg+"="+tmp2+";"); //190415
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

////////F//////////

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
    tmp1=Readlines(tmp2); //200515
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

////%CalcbyF start ////
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
    tmp1=Readlines(file); //200515from
    if(length(tmp1)==0,
      wflg=1;
    ,
      tmp1=select(tmp1,indexof(#," --##")>0);
      if(length(tmp1)==0,   //200515to
        wflg=1;
      ,
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
      tmp1=Readlines(wfile); //200515
      if(wflg==1,wait(WaitUnit));
      tmp=select(tmp1,(indexof(#,"Error")>0)%(indexof(tmp1,"find")>0));
      if(length(tmp)>0,
          println("Some error(s) occurred");
          tmp1=apply(tmp1,replace(#," --##",""));
          forall(tmp1,
            if(indexof(#,"Error")+indexof(#,"find")>0,
              println(#);
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
        tmp=name+"="+substring(tmp4,0,length(tmp4)-1)+"];"; //190415
        parse(tmp);
        tmp=parse(name);
        if(length(tmp)==1,
          tmp1=substring(tmp4,1,length(tmp3)-1);
          parse(name+"="+tmp1+";"); //190415
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
      tmp1=Readlines(wfile); //200515
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
////%CalcbyF end ////


////%Frfun start ////
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

/////////////////C//////////////////

////%Readexecdata start//// 220114 added
Readexecdata(nm):=(
//help:Readexecmd("1");
  regional(varL,fname);
  if(indexof(nm,".txt")==0,
    fname=Cdyname()+nm+".txt";
  ,
    fname=nm;
  );
  varL=Readoutdata(fname,["Msg=n"]);
  varL
);
////%Readexecdata end////

////%Usedata3d start//// 220127
Usedata3d(nm,var):=Usedata3d(nm,var,[]);
Usedata3d(nm,var,optionsorg):=(
//help:Usedata3d("1","sfbd3d1");
//help:Usedata3d("1","sfbd3d1",["Color=red"]);
//help:Usedata3d("1","sfbdh3d",[],[]);
  regional(n,options,fname,name3,name2,okflg,tmp,tmp1,tmp2,tmp3);
  //global UseListC, StyleListC
  options=optionsorg;
  fname=Cdyname()+nm+".txt";
  tmp="ReadOutData("+Dqq(fname)+")";
  if(!contains(GLIST,tmp),GLIST=append(GLIST,tmp));
  name3=var;
  if(indexof(name3,"3d")==0,name3=name3+"3d");
  name2=replace(named3,"3d","2d");
  okflg=0;
  if(islist(parse(name3)),
    okflg=1;
  ,
    tmp=Readexecdata(nm);
    if(contains(tmp,name3),
      okflg=1;
    ,
      println("  "+name3+" is not found");
    );  
  );
  if(okflg==1,
  //  tmp1=name2+"=Projpara("+Dqq(name3)+",[";
  //  tmp2="";
  //  if(length(options)>0,
  //    forall(options,
  //      tmp2=tmp2+Dqq(#)+",";
  //    );
  //    tmp2=substring(tmp2,0,length(tmp2)-1);
  //  );
  //  tmp1=tmp1+tmp2+","+Dqq("Msg=n")+"]);";
  //  parse(tmp1);
    UseListC=concat(UseListC,[
      "  sprintf(dirfnameread,"+Dqq("%s%s")+",Dirname,"+Dqq(fname)+");", //220127[3lines]
      "  readoutdata3(dirfnameread,"+Dqq(var)+",out);",
      "  output3(1,"+Dqq("a")+","+Dqq(var)+",dirfname,out);"
    ]); 
  );
  StyleListC=concat(StyleListC,[name3,options]); //220204
);
Usedata3d(nm,var,options,optionsh):=( //220127from
  regional(tmp,tmp1,tmp2,flg);
  tmp2=optionsh;
  flg=1;
  forall(tmp2,
    if(substring(#,0,1)=="d",flg=0);
    if(substring(#,0,2)=="id",flg=0);
  );
  if(flg==1,tmp2=append(tmp2,"do"));
  tmp1=select(options,(indexof(#,"=")>0)&(Toupper(#,0,2)=="CO"));
  if(length(tmp1)>0,
    tmp2=append(tmp2,tmp1_1);
  );
  Usedata3d(nm,var,options);
  tmp=replace(var,"3d","h3d");
  Usedata3d(nm,tmp,tmp2);
);  //220127to
////%Usedata3d end////

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

////%Addsurf start////  220112
Addsurf(fdLorg):=(
//help:Addsurf([fd1,fd2]);
  regional(fdL,tmp);
  //global FuncListC
  fdL=fdLorg;
  if(Measuredepth(fdL)==0,fdL=[fdL]);
  forall(fdL,
    tmp=ConvertFdtoC(#);
    FuncListC=append(FuncListC,tmp);
    tmp=Fullformfunc(#);
    SurfList=append(SurfList,tmp); //220128
  );
  LenAddSurf=length(fdL); //220202
);
////%Addsurf end////

////%Addnodisp start////  220128
Addnodisp(fdLorg):=(
//help:Addnodisp(["ax3d"]);
  regional(fdL);
  //global Nodisplist
  fdL=fdLorg;
  if(!islist(fdL),fdL=[fdL]);
  NodispList=concat(NodispList,fdL);
);
////%Addnodisp end////

////%Cform start////
Cform(strorg):=( //181106,211105
//help:Cform(str);
  regional(str,str1,str2,ter,num,hatLht,pare,flg,
         pmx,sub,sub1,sub2,ns,nsL,ne,ht,kk,
        tmp,tmp1,tmp2,tmp3,tmp4);
  ter=["+","-","*","/","(",")","=","[","]"]; //180517
  str=replace(strorg,"pi","M_PI");
  num=apply(0..9,text(#));  //181107from
  num=append(num,".");
  tmp1=str+"/";
  tmp2="";
  str="";
  flg=0;
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
  str=substring(str,0,length(str)-1);
  str="("+str+")";
  pare=Bracket(str,"()");
  tmp=apply(pare,#_2);
  pmx=max(tmp);
  while(pmx>0,
    tmp=select(pare,#_2==pmx);
    while(length(tmp)>0,
      ns=tmp_1_1;
      tmp=select(pare,(#_2==-pmx)&(#_1>ns));
      ne=tmp_1_1;
      sub=substring(str,ns-1,ne);
      sub=replace(sub,"(","[");
      sub=replace(sub,")","]");
      str1=substring(str,0,ns-1);
      str2=substring(str,ne,length(str));
      ht=indexof(sub,"^");
      while(ht>0,
        tmp1=substring(sub,0,ht-1);
        tmp2=substring(sub,ht,length(sub));
        sub1=""; sub2="";
        tmp=tmp1_(-1);
        if((tmp==")")%(tmp=="]"),
          if(tmp==")",
            tmp3=Bracket(tmp1,"()");
          ,
            tmp3=Bracket(tmp1,"[]");
          );
          tmp=tmp3_(-1)_2;
          tmp=select(tmp3,#_2==-tmp);
          tmp=tmp_(-1)_1;
          sub1=sub1+substring(tmp1,0,tmp-1);
          tmp1=substring(tmp1,tmp-1,length(tmp1));
        ,
          kk=length(tmp1);
          while(kk>0,
            tmp=tmp1_(kk);
            if(contains(ter,tmp),
              sub1=sub1+substring(tmp1,0,kk);
              tmp1=substring(tmp1,kk,length(tmp1));
              kk=0;
            ,
              kk=kk-1;
            );
          );
        );
        tmp=tmp2_(1);
        if((tmp=="(")%(tmp=="["),
          if(tmp=="(",
            tmp3=Bracket(tmp1,"()");
          ,
            tmp3=Bracket(tmp1,"[]");
          );
          tmp=tmp3_(1)_2;
          tmp=select(tmp3,#_2==-tmp);
          tmp=tmp_(1)_1;
          sub2=substring(tmp2,tmp,length(tmp2))+sub2;
          tmp2=substring(tmp2,0,tmp);
        ,
          kk=1;
          while(kk<length(tmp2),
            tmp=tmp2_(kk);
            if(contains(ter,tmp),
              tmp=length(tmp2);
              sub2=substring(tmp2,kk-1,length(tmp2))+sub2;
              tmp2=substring(tmp2,0,kk-1);
              kk=tmp;
            ,
              kk=kk+1;
            );
          );
        );
        sub=sub1+"pow["+tmp1+","+tmp2+"]"+sub2;
        ht=indexof(sub,"^");
      );
      str=str1+sub+str2;
      pare=Bracket(str,"()");
      tmp=[];
      if(length(pare)>0,
        tmp=select(pare,#_2==pmx);
      );
    );
    pare=Bracket(str,"()");
    pmx=pmx-1;
  );
  str=replace(str,"[","(");
  str=replace(str,"]",")");
  str=substring(str,1,length(str)-1);
  str;
);
////%Cform end/////

////%ConvertFdtoC start//// 211105
ConvertFdtoC(Fd):=ConvertFdtoC(Fd,["x","y","z"]);
ConvertFdtoC(Fd,name):=(
//help:ConvertFd(Fd);
  regional(FdL,FdC,uvar,vvar,tmp,tmp1,str,par,n);
  if(islist(Fd_(-1)), //220129from
    FdL=Fd;
  ,
    FdL=Fullformfunc(Fd);
  ); //220129to
  tmp=indexof(FdL_5,"="); //180303from
  uvar=substring(FdL_5,0,tmp-1);
  tmp=indexof(FdL_6,"=");
  vvar=substring(FdL_6,0,tmp-1);
  tmp1=apply(2..6,Assign(FdL_#,uvar,"u"));
  tmp1=apply(tmp1,Assign(#,vvar,"v"));
  tmp1=concat(tmp1,FdL_(7..8));
  FdC=apply(1..3,name_#+"="+Cform(tmp1_#)); 
  str=[Cform(tmp1_4),Cform(tmp1_5)]; //211211from
  forall(1..2,n,
    par=Bracket(str_n,"()");
    tmp=select(par,#_2==1); tmp=tmp_1;
    str_n_tmp="[";
    tmp=select(par,#_2==-1); tmp=tmp_1;
    str_n_tmp="]";
  );
  FdC=concat(FdC,str); //211211to
  FdC=concat(FdC,[tmp1_6]); 
);
////%ConvertFdtoC end////

////%Startsurf start//// //220208major change
Startsurf():=Startsurf("",[50,50],[1500,500,200],[0.01,0.1]);
Startsurf(Arg):=(
  if(isstring(Arg),
    Startsurf(Arg,[50,50],[1500,500,200],[0.01,0.1]);
  ,
    Starsurf("",Arg);
  );
);
Startsurf(Arg1,Arg2):=(
  regional(tmp);
  if(isstring(Arg1),
    tmp=max(Arg2);
    if(tmp>=500,
      Startsurf(Arg1,[50,50],Arg2,[0.01,0.1]);
    ,
      if(tmp>1,
        Startsurf(Arg1,Arg2,[1500,500,200],[0.01,0.1]);
      ,
        Startsurf(Arg1,[50,50],[1500,500,200],Arg2);
      );
    );
  );
);
Startsurf(Arg1,Arg2,Arg3):=(
  regional(tmp2,tmp3,a1,a2,a3);
  if(isstring(Arg1),
    tmp2=max(Arg2);
    tmp3=max(Arg3);
    if((tmp2<1)%(tmp3<1),
      if(tmp2<1,a3=Arg2,a3=Arg3);
    ,
      if(tmp2<tmp3,
        a1=tmp2; a2=tmp3;
      ,
        a1=tmp3; a2=tmp2;
      );
      Startsurf(Arg1,a1,a2,a3);
    );
  ,
    Startsurf("",Arg1,Arg2,Arg3);
  );
);
Startsurf(nm,Nplist,Dsizelist,Epslist):=(
// help:Startsurf();
//help:Startsurf("1");
// help:Startsurf("reset");
//help:Startsurf("1",[0.01,0.1]);
//help:Startsurf("1",[50,50],[1500,500,200],[0.01,0.1]);
//help:Startsurf([50],[1500,500],[0.01,0.1]);
  regional(divL,sizeL,epsL);
  // global ExecName
  StyleListC=[]; //181107
  ReadListC=[]; //220114
  WriteFlag=0; //220126
  ExecName="1"; //220203from
  if(substring(Toupper(nm),0,1)=="R",
    GLIST=[];
  ,
    ExecName=nm;
  ); //220203to
  NodispList=[]; //220126
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
  UseListC=[]; //2201122
  CommandListC=[ //220121from
    "  char dirfname[256] = {'\0'};",
    "  char dirfnameread[256] = {'\0'};", //220124
    "  char fnameall[256] = {'\0'};",
    "  char fnameread[256] = {'\0'};",
    "  short chfd[2];", //220203
    "  /* starsurfend */"
  ]; //220121to
);
////%Startsurf end////

////%kcC start////
kcC():=kcC(FheadC);
kcC(cname):=(
  regional(tmp, tmp1,flg,rfile);
  rfile=cname+"end.txt"; //180517
  if(iswindows(),
    SCEOUTPUT = openfile("kc.bat");
    println(SCEOUTPUT,"set path="+Dqq(Dirwork)); //210311
    tmp1=replace(PathC,"/","\"); // 20200914from
    tmp=Indexall(tmp1,"\");
    tmp1=substring(tmp1,0,tmp_(length(tmp))-1); // 20200914from
    println(SCEOUTPUT,"cd "+tmp1);
    tmp=Dqq(PathC)+" %path%\"+cname+".c"; //210516
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
      tmp1=Readlines(wfile); //200514[2Lines]
 	  if(tmp1_1=="////",
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

////%ReaddataC start////
ReaddataC(fnameorg):=(
  regional(tmp,tmp1,fname,data,out);
  fname=fnameorg;
  if(indexof(fname,".")==0, fname=fname+".txt");
  data=Readlines(fname); //200515[2lines]
  data=apply(data,replace(#," -99999",""));
  out=[];
  tmp1=[];
  forall(1..(length(data)),
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

////%DisplayC start////
DisplayC():=DisplayC(DispC);
DisplayC(name,options):=DisplayC([name,options]);
DisplayC(dispc):=(
//help:DisplayC("out",["Color=[1,0,0]");
//help:DispC(options=["dr", "Color=[0,0,0]"]);
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
////%DisplayC end////

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
  cmd=append(cmd,"/* cheadsurfend */"); //220123
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
    "  int i, j, nall;"
  ]);
  cmd=append(cmd,"/* ctopsurfend */"); //220123
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
  // global ErrFlag
  ErrFlag=0; //211227
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
      tmp2=Readlines(hfile);
      tmp2=apply(tmp2,replace(#,"/**/",""));
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
        tmp2=Readlines(mfile);
        tmp2=select(tmp2,indexof(#,"/**/")>0); //200514
        tmp2=tmp2_(2..(length(tmp2)));
        tmp2=apply(tmp2,replace(#,"/**/",""));
        if(length(tmp1)!=length(tmp2),wflg=1);
      );
      if(wflg==0,
        forall(1..(length(tmp1)),
          if(tmp1_#!=tmp2_#,wflg=1);
        );
      );
    );
    if(wflg==0,wflg=-1); //210324,211226
  );
  WriteFlag=wflg; //210320
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
      tmp=Readlines(wfile);
      if(indexof(tmp_1,"////")>0, //180523from
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
  wflg; //181101, 210827,211226
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

////%ExeccmdC start//// //220203(major change, ExecName used)
ExeccmdC():=ExeccmdC(ExecName,[],["do"]); 
ExeccmdC(Arg):=(
  if(isstring(Arg),
    ExeccmdC(Arg,[],["do"]);
  ,
    ExeccmdC(ExecName,Arg,["do"]);
  );
);
ExeccmdC(Arg1,Arg2):=(
  if(isstring(Arg1), //230319
    ExeccmdC(Arg1,Arg2,["do"]);
  ,
    ExeccmdC(ExecName,Arg1,Arg2);
  );
);
ExeccmdC(nm,optionorg,optionhorg):=( 
//help:ExeccmdC("1",options1,options2);
//help:ExeccmdC(options1=["dr(/da/do)","m/r","Wait=30"]);
//help:ExeccmdC(options2=["do(/nodisp/da/do)"]);
  regional(options,optionsh,name2,name3,waiting,dirbkup,eqL,reL,ctr,
     strL,fname,wfile,cL,tmp,tmp1,tmp2,tmp3,tmp4,flg,wflg,va,varL,nn,mm);
  //global WriteFlag, CommandListC, UseListC, NodispList
  fname=Fhead+nm+".txt";
  wfile=Fhead+nm+"end.txt";  //211108[2lines]
  options=optionorg;
  optionsh=optionhorg;
  optionsh=select(optionsh,length(#)>0);
//  if(length(optionsh)==0,optionsh=["do"]); //201230[comment]
  tmp=Divoptions(options);
  eqL=tmp_5;
  reL=tmp_6;
  strL=tmp_7;
  waiting=30;
  cmdflg=0;
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
  tmp1=options; //211226
  if(wflg<1, //211108from
    if(!isexists(Dirwork,wfile),
      wflg=1;  //220113
    ,
      tmp=Readlines(Dirwork,wfile);
      if(length(tmp)>0, //211226
        tmp=replace(tmp_1,"////","");
        tmp=parse(tmp);
        if(|tmp-[THETA,PHI]|>10^(-4),wflg=1);
      ); //211226
    );
  ); //211108to
  if(wflg==1, //220126from
    options=append(options,"m");
  ); //220126to
  if(wflg==-1,options=append(options,"r"));
  options=append(options,"Wait="+text(waiting));
  options=append(options,"Msg=n"); //220122to
  tmp3=[
    "  sprintf(fnameall,"+Dqq("%s")+","+Dqq(fname)+");",
    "  sprintf(dirfname,"+Dqq("%s%s")+",Dirname,fnameall);",
    "  printf("+Dqq("%s\n")+","+Dqq("Execcmd "+nm)+");",
    "  j=remove(dirfname);",
    "  printf("+Dqq("file remove=%d\n")+",j);",
    "  /* execcmdcheadend  */"
  ];
  forall(UseListC,
    tmp3=append(tmp3,#);
  );
  tmp3=append(tmp3,"  /* usedata3dend  */");
  tmp2=CommandListC; //220122from
  tmp=select(1..(length(tmp2)),indexof(tmp2_#,"starsurfend")>0);
  tmp1=tmp2_(1..(tmp_1));
  tmp2=tmp2_((tmp_1+1)..(length(tmp2)));
  CommandListC=concat(tmp1,tmp3);
  CommandListC=concat(CommandListC,tmp2); //220122to
  tmp=select(CommandListC,indexof(#,"outputend")>0);
  if(length(tmp)==0,
    CommandListC=append(CommandListC,"  outputend(dirfname);");
  );
  if(wflg==0,//211229from
    tmp=replace(fname,".txt","header.h"); //220123from
    tmp1=Readlines(Dirwork,tmp);
    tmp1=apply(tmp1,replace(#,"/**/",""));
    tmp2=Cheadsurf();
    if(length(tmp1)!=length(tmp2),
      wflg=1;
    ,
      ctr=2; //// ignore the1st line [XMIN,...]
      while((wflg==0)&(ctr<=length(tmp1)),
        if(tmp1_ctr!=tmp2_ctr, wflg=1,ctr=ctr+1);
      );
    );
    if(wflg==1,options=append(options,"m"));
  );
  if(wflg==0,//211229from
    tmp=replace(fname,".txt",".c"); //220123from
    tmp1=Readlines(Dirwork,tmp);
    tmp1=apply(tmp1,replace(#,"/**/",""));
    tmp=select(1..(length(tmp1)),indexof(tmp1_#,"ctopsurfend")>0);
    tmp3=tmp1_((tmp_1+1)..(length(tmp1)));
    tmp1=tmp1_(1..(tmp_1));
    tmp2=Ctopsurf(nm);
    if(length(tmp1)!=length(tmp2),
      wflg=1;
    ,
      ctr=1;
      while((wflg==0)&(ctr<=length(tmp1)),
        if(tmp1_ctr!=tmp2_ctr, wflg=1,ctr=ctr+1);
      );
    );
    if(wflg==1,options=append(options,"m"));
  ); //211229to
  if(wflg==0,
    tmp3=select(tmp3,length(#)>0);
    tmp=select(1..(length(tmp3)),indexof(tmp3_#,"return 0;")>0);
    tmp=tmp_(-1);
    tmp1=tmp3_(1..(tmp-1));
    tmp2=CommandListC;
    if(length(tmp1)!=length(tmp2),
      wflg=1;
    ,
      ctr=1;
      while((wflg==0)&(ctr<=length(tmp1)),
        if(tmp1_ctr!=tmp2_ctr, wflg=1,ctr=ctr+1);
      );
    );
    if(WriteFlag==1,wflg=1);
    if(wflg==0,wflg=-1);
    if(wflg==1,options=append(options,"m"));
    if(wflg==-1,options=append(options,"r"));
  );
  if(wflg==1,
    tmp1=[]; //220125from
    if(length(tmp1)>0, //220125[3lines]
      Writeoutdata(fname,tmp1);
    );
    wait(100);
    CalcbyC(nm,[Cheadsurf(),Ctopsurf(nm),CommandListC],options);
    wait(100);
    Skeleton=1; //210325
  );
  if(isexists(Dirwork,fname),
    varL=ReadOutData(fname,["Msg=n"]);
    GLIST=append(GLIST,"ReadOutData("+Dqq(fname)+")");
    forall(varL,va, //220128from
      if(length(parse(va))>0, 
        if(indexof(va,"wire")>0,  //220207from
          tmp=indexof(va,"3d");
          tmp1=substring(va,0,tmp+1);
        ,
          tmp1=va;
        );
        tmp=select(1..(length(StyleListC)),StyleListC_#==tmp1); //220207to
        if(length(tmp)>0,
          tmp2=StyleListC_(tmp_1+1);
        ,
          tmp2=["nodisp"];
        );        
        Projpara(va,append(tmp2,"Msg=n"));
        if(SUBSCR==1, //  15.02.11
          Subgraph(va,"");
        );
      ); 
    ); //220128to
  );
  tmp1=select(NodispList,indexof(#,"3d")==0); //220207from
  Changestyle(tmp1,["nodisp"]);
  NodispList,=remove(NodispList,tmp1); //220207to
  Changestyle3d(NodispList,["nodisp"]);
  SurfList=SurfList_(1..LenAddSurf); //220208[2lines]
  FuncListC=FuncListC_(1..LenAddSurf); 
  varL;
);
////%ExeccmdC end////

////%ReadoutC start//// 211230 added
ReadoutC(frname):=(
//help:ReadoutC(readfile);
  regional(f,var,cmdL,wa,va,tmp);
  f=frname+".txt";
  var=Readoutdata(frname,["Msg=n"]);
  cmdL=["  sprintf(dirfnamer,"+Dqq("%s%s")+",Dirname,"+Dqq(f)+");"];
  wa="w";
  forall(var,va,
    tmp=["  readoutdata3(dirfname,"+Dqq(va)+",data);",
             "  output3(1,"+Dqq(wa)+","+Dqq(va)+",dirfname,data);"];
    cmdL=concat(cmdL,tmp);
    wa="a";
  );
  CommandListC=concat(CommandListC,cmdL);
  cmdL;
);
////%ReadoutC end////

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
//help:Sfbdparadata("1",Fd,[],[]);
//help:Sfbdparadata("1",1,["Color=red"],["do,1,1.5"]);
//help:Sfbdparadata("1",1,["m","Color=black"],["Color=red"]);
  regional(funnm,fd,options,optionsh,name2,name3,name2h,name3h,waiting,
     eqL,reL,strL,tmp,tmp1,tmp2,flg,wflg);
  if(ChNumber==0,ChNumber=Ch);
  fd=fdorg; //220126from
  if(islist(fd),
    tmp1=Fullformfunc(fd);
    tmp=select(1..(length(SurfList)),SurfList_#==tmp1);
    if(length(tmp)>0,
      funnm=tmp_1;
    ,
      SurfList=append(SurfList,tmp1);
      tmp=ConvertFdtoC(fd);
      FuncListC=append(FuncListC,tmp);
      funnm=length(SurfList);
    );
  ,
    funnm=fd;
    if(funnm>length(SurfList),
      println("   num set to the last");  //220602
      funnm=length(SurfList);
      fd=SurfList_funnm;
    );
  ); //220126to
  name2="sfbd2d"+nm;
  name3="sfbd3d"+nm;
  name2h="sfbdh2d"+nm;
  name3h="sfbdh3d"+nm;
  fname=Fhead+ExecName+".txt"; //220203
  options=select(optionorg,length(#)>0); //190123from
//  tmp=Divoptions(options); //191006[2lines]
//  if(length(tmp_7)==0,options=append(options,"dr"));
  optionsh=select(optionshorg,length(#)>0);
//  tmp=Divoptions(optionsh); //191006[2lines]
//  if(length(tmp_7)==0,optionsh=append(optionsh,"do")); //190123to
  tmp=Divoptions(options);
  eqL=tmp_5;
  reL=tmp_6;
  strL=tmp_7;
  waiting=60;
  wflg=0;
  forall(strL,
    tmp=Toupper(substring(#,0,1));
    if(tmp=="M",
      wflg=1;
      WriteFlag=1; //220126
      options=remove(options,[#]);
    );
    if(tmp=="R",
      wflg=-1;
      options=remove(options,[#]);
    );
    if(tmp=="C", //180531
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
    "  rangeUV("+funnm+");",
    "  boundary("+funnm+");",
    "  sfbdparadata("+funnm+",sfbd);",
    "  output3h("+Dqq("a")+","+Dqq(name3)+","+Dqq(name3h)+",dirfname,sfbd);",
    "  /* sfbdparadataend */"
  ];
  CommandListC=concat(CommandListC,cmdL); //180531to
  flg=0;
  if(isexists(Dirwork,fname),
    tmp1=Readoutdata(fname,["Msg=n"]);
    if((contains(tmp1,name3))&(contains(tmp1,name3h)),flg=1);
  );
  if(flg==0,
    println("  ExeccmdC will generate "+ name3+","+name3h);
  ,
    println("  "+name3+","+name3h+" are found in "+fname);
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
  regional(funnmL,sfbd,fd,options,optionsh,name2,name3,name2h,name3h,waiting,
     errflg,eqL,reL,strL,fname,cfname,tmp,tmp1,tmp2,flg,ii,jj,eps);
  // global WriteFlag
  eps=10^(-5);
  sfbd=replace(sfbdorg,"bdy","sfbd");
  funnmL=[];
  fd=fdorg; //220126from
  if(islist(fd),
    tmp1=Fullformfunc(fd);
    tmp=select(1..(length(SurfList)),SurfList_#==tmp1);
    if(length(tmp)>0,
      funnmL=[tmp_1];
    ,
      SurfList=append(SurfList,tmp1);
      tmp=ConvertFdtoC(fd);
      FuncListC=append(FuncListC,tmp);
      funnmL=[length(SurfList)];
    );
  ,
    if(fd>length(SurfList),
      printlln("   num set to the last");
      funnmL=[length(SurfList)];
    ,
      funnmL=[fd];
    );
  ); //220126to
  tmp1=FuncListC_(funnmL_1);
  tmp=Strsplit(tmp1_3,"=");
  tmp2="y="+tmp_2;
  tmp=Strsplit(tmp1_2,"=");
  tmp1_3="z="+tmp_2;
  tmp1_2=tmp2;
  FuncListC=append(FuncListC,tmp1);
  funnmL=append(funnmL,length(FuncListC));
  name2="crvsf2d"+nm; name3="crvsf3d"+nm;
  name2h="crvsfh2d"+nm; name3h="crvsfh3d"+nm;
  fname=Fhead+ExecName+".txt"; //220203
  cfname=Fhead+Fk+".dat"; //220126
  options=select(optionorg,length(#)>0); 
  optionsh=select(optionshorg,length(#)>0); //220103to
  tmp=Divoptions(options);
  eqL=tmp_5;
  reL=tmp_6;
  strL=tmp_7;
  waiting=60;
  forall(strL,
    tmp=Toupper(substring(#,0,1));
    if(tmp=="M",
      WriteFlag=1;
      options=remove(options,[#]);
    );
    if(tmp=="R",
      options=remove(options,[#]);
    );
    if(tmp=="C", //180531
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
  if(!isexists(Dirwork,cfname), //220203from
    WriteFlag=1;
  ,
    tmp1=ReaddataC(cfname);
    tmp2=parse(Fk);
    if(Measuredepth(tmp2)==1,tmp2=[tmp2]);
    tmp1=Textformat(tmp1,3);
    tmp2=Textformat(tmp2,3);
    if(tmp1!=tmp2,WriteFlag=1);
  ); //220203to
  if(WriteFlag==1,
    WritedataC(cfname,Fk);
  );
  NodispList=append(NodispList,Fk);
  cmdL=[
    "  chfd[0]="+funnmL_1+";", //220203from
    "  chfd[1]="+funnmL_2+";",
    "  rangeUV("+funnmL_1+");",
    "  boundary("+funnmL_1+");",  //220203to
    "  readdataC("+Dqq(cfname)+",data);",
    "  readoutdata3(dirfname,"+Dqq(sfbd)+",sfbd);",
    "  crvsfparadata(chfd,data,sfbd,0,out);",  //220203
    "  output3h("+Dqq("a")+","+Dqq(name3)+","+Dqq(name3h)+",dirfname,out);",
    "  /* crvsfparadataend */"
  ];
  CommandListC=concat(CommandListC,cmdL);
  flg=0;
  if(isexists(Dirwork,fname),
    tmp1=Readoutdata(fname,["Msg=n"]);
    if((contains(tmp1,name3))&(contains(tmp1,name3h)),flg=1);
  );
  if(flg==0,
    println("  ExeccmdC will generate "+ name3+","+name3h);
  ,
    println("  "+name3+","+name3h+" are found in "+fname);
  );
);
////%Crvsfparadata end////

////%Crv3onsfparadata start//// old version
Crv3onsfparadata(nm,crv3d,sfbd,fd):=Crv3onsfparadataC(nm,crv3d,sfbd,fd);
Crv3onsfparadata(nm,crv3d,sfbd,fd,options):=Crv3onsfparadataC(nm,crv3d,sfbd,fd,options);
Crv3onsfparadata(nm,crv3d,sfbdorg,fdorg,optionorg,optionsh):=
  Crv3onsfparadataC(nm,crv3d,sfbdorg,fdorg,optionorg,optionsh);
Crv3onsfparadataC(nm,crv3d,sfbd,fd):=
  Crv3onsfparadataC(nm,crv3d,sfbd,fd,[],["do"]);
Crv3onsfparadataC(nm,crv3d,sfbd,fd,options):=
   Crv3onsfparadataC(nm,crv3d,sfbd,fd,options,["do"]);
Crv3onsfparadataC(nm,crv3d,sfbdorg,fdorg,optionorg,optionshorg):=(
//help:Crv3onsfparadata("1","sc3","sfbd3d1",fd,nohiddenoptions,hiddenoptions);
//help:Crv3onsfparadata(options=["m/r"]);
  regional(funnm,sfbd,fd,options,optionsh,name3,name3h,name2,name2h,
     eqL,reL,strL,fname,cfname,tmp,tmp1,tmp2,flg,msg);
  sfbd=replace(sfbdorg,"bdy","sfbd");
  fd=fdorg; //220126from
  if(islist(fd),
    tmp1=Fullformfunc(fd);
    tmp=select(1..(length(SurfList)),SurfList_#==tmp1);
    if(length(tmp)>0,
      funnm=tmp_1;
    ,
      SurfList=append(SurfList,tmp1);
      tmp=ConvertFdtoC(fd);
      FuncListC=append(FuncListC,tmp);
      funnm=length(SurfList);
    );
  ,
    funnm=fd;
    if(funnm>length(SurfList),
      printlln("   num set to the last");
      funnm=length(SurfList);
    );
  ); //220126to
  fd=SurfList_funnm;
  if(indexof(nm,"wire")>0,
    name3=nm+"3d";
  ,
    name3="crv3onsf3d"+nm;
  );
  name3h=replace(name3,"3d","h3d");
  name2=replace(name3,"3d","2d");
  name2h=replace(name3h,"3d","2d");
  fname=Fhead+ExecName+".txt"; //220203
  cfname=Fhead+ExecName+crv3d+".dat"; //220204
  options=select(optionorg,length(#)>0);
  optionsh=select(optionshorg,length(#)>0); //181107
  tmp=Divoptions(options);
  eqL=tmp_5;
  reL=tmp_6;
  strL=tmp_7;
  forall(strL,
    tmp=Toupper(substring(#,0,1));
    if(tmp=="M",
      WriteFlag=1;
      options=remove(options,[#]);
    );
    if(tmp=="R",
      options=remove(options,[#]);
    );
    if(tmp=="C", //180531
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
  if(!isexists(Dirwork,cfname), //220203from
    WriteFlag=1;
  ,
    tmp1=ReaddataC(cfname);
    tmp2=parse(crv3d);
    if(Measuredepth(tmp2)==1,tmp2=[tmp2]);
    tmp1=Textformat(tmp1,3);
    tmp2=Textformat(tmp2,3);
    if(tmp1!=tmp2,WriteFlag=1);
  ); //220203to
  if(WriteFlag==1,
    WritedataC(cfname,crv3d);
  );
  if(indexof(crv3d,"wire")==0, //220207
    NodispList=append(NodispList,crv3d);
  );
  if(indexof(nm,"wire")>0, //220207from
    tmp1=replace(name3,"3d","");
  ,
    tmp1="crv3onsf";
  ); //220207to
  cmdL=[
    "  rangeUV("+funnm+");",
    "  boundary("+funnm+");",
    "  sprintf(dirfnameread,"+Dqq("%s%s")+",Dirname,"+Dqq(cfname)+");",
    "  readdataC(dirfnameread,data);",
    "  readoutdata3(dirfname,"+Dqq(sfbd)+",sfbd);", //180531
    "  crv3onsfparadata("+funnm+","+Dqq(tmp1)+",data,sfbd,dirfname,out);",
    "  /* crv3onsfparadataend */"
  ];
  CommandListC=concat(CommandListC,cmdL);
  flg=0;
  if(isexists(Dirwork,fname),
    tmp1=Readoutdata(fname,["Msg=n"]);
    if((contains(tmp1,name3))&(contains(tmp1,name3h)),flg=1);
  );
  if(flg==0,
    println("  ExeccmdC will generate "+ name3+","+name3h);
  ,
    println("  "+name3+","+name3h+" are found in "+fname);
  );
);
////%Crv3onsfparadata end////

////%Crv3onsfparadata start//// new version 230318
Crv3onsfparadata(nm,crv3d,sfbd,fd):=CrvsfparadataC(nm,crv3d,sfbd,fd);
Crv3onsfparadata(nm,crv3d,sfbd,fd,options):=CrvsfparadataC(nm,crv3d,sfbd,fd,options);
Crv3onsfparadata(nm,crv3d,sfbdorg,fdorg,optionorg,optionsh):=
  CrvsfparadataC(nm,crv3d,sfbdorg,fdorg,optionorg,optionsh);
Crv3onsfparadataC(nm,crv3d,sfbd,fd):=
  CrvsfparadataC(nm,crv3d,sfbd,fd,[],["do"]);
Crv3onsfparadataC(nm,crv3d,sfbd,fd,options):=
   CrvsfparadataC(nm,crv3d,sfbd,fd,options,["do"]);
Crv3onsfparadataC(nm,crv3d,sfbdorg,fdorg,optionorg,optionshorg):=
  CrvsfparadataC(nm,crv3d,sfbdorg,fdorg,optionorg,optionshorg);

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
//help:Crv2onsfparadata("1","gp1","sfbd3d1",nohiddenoptions,hiddenoptions);
  regional(fd,funnm,uname,vname,str,tmpfun,ii,jj,crv3d,cr,tmp,tmp1,tmp2,tmp3);
  Changestyle3d(crv2d,["nodisp"]);
  if(indexof(crv2d,"2d")>0,
    crv3d=replace(crv2d,"2d","3d");
  ,
    crv3d=crv2d+"3d";
  );
  fd=fdorg; //220204from
  if(islist(fd),
    tmp1=Fullformfunc(fd);
    tmp=select(1..(length(SurfList)),SurfList_#==tmp1);
    if(length(tmp)>0,
      funnm=tmp_1;
    ,
      SurfList=append(SurfList,tmp1);
      tmp=ConvertFdtoC(fd);
      FuncListC=append(FuncListC,tmp);
      funnm=length(SurfList);
    );
  ,
    funnm=fd;
    if(funnm>length(SurfList),
      printlln("   num set to the last");
      funnm=length(SurfList);
    );
  ); //220204to
  fd=SurfList_funnm;
  tmp=Strsplit(fd_5,"=");
  uname=tmp_1;
  tmp=Strsplit(fd_6,"=");
  vname=tmp_1;
  str="["+fd_2+","+fd_3+","+fd_4+"]";
  tmp="tmpfun("+uname+","+vname+"):="+str+";";
  parse(tmp);
  tmp1=parse(crv2d);
  if(Measuredepth(tmp1)==1,tmp1=[tmp1]); //220204from
  tmp2=[];
  forall(tmp1,cr,
    tmp=apply(cr,tmpfun(#_1,#_2));
    tmp2=append(tmp2,tmp);
  );
  if(length(tmp2)==1,tmp2=tmp2_1);  //22020to
  tmp=crv3d+"="+Textformat(tmp2,5)+";"; //190415  
  parse(tmp);
  Crv3onsfparadataC(nm,crv3d,sfbd,funnm,options,optionsh);
);
////%Crv2onsfparadata end////

////%Wireparadata start//// 229\0102 major change
Wireparadata(nm,sfbd,fd,wr1,wr2):=WireparadataC(nm,sfbd,fd,wr1,wr2);
Wireparadata(nm,sfbd,fd,wr1,wr2,options):=WireparadataC(nm,sfbd,fd,wr1,wr2,options);
Wireparadata(nm,sfbd,fd,wr1,wr2,optionorg,optionsh):=
  WireparadataC(nm,sfbd,fd,wr1,wr2,optionorg,optionsh);
WireparadataC(nm,sfbd,fd,wr1,wr2):=
  WireparadataC(nm,sfbd,fd,wr1,wr2,[],["do"]);
WireparadataC(nm,sfbd,fd,wr1,wr2,options):=
   WireparadataC(nm,sfbd,fd,wr1,wr2,options,["do"]);
WireparadataC(nm,sfbd,fdorg,wr1,wr2,optionorg,optionshorg):=(
//help:Wireparadata("1","sfbd3d1",fd,5,5,nohiddenoptions,hiddenoptions);
  regional(fd,options,optionsh,name2,name3,name2h,name3h,
     varu,rngu,varv,rngv,data2dL,flg,
     eqL,reL,strL,fname,cfname,tmp,tmp1,tmp2,udata,vdata);
  fd=fdorg; //220204from
  if(islist(fd),
    tmp1=Fullformfunc(fd);
    tmp=select(1..(length(SurfList)),SurfList_#==tmp1);
    if(length(tmp)>0,
      funnm=tmp_1;
    ,
      SurfList=append(SurfList,tmp1);
      tmp=ConvertFdtoC(fd);
      FuncListC=append(FuncListC,tmp);
      funnm=length(SurfList);
    );
  ,
    funnm=fd;
    if(funnm>length(SurfList),
      printlln("   num set to the last");
      funnm=length(SurfList);
    );
  ); //220204to
  fd=SurfList_funnm;
  tmp1=Strsplit(fd_5,"=");
  varu=tmp1_1; rngu=tmp1_2;
  tmp1=Strsplit(fd_6,"=");
  varv=tmp1_1; rngv=tmp1_2; //220102to
  name2="wire"+nm+"2d";
  name3="wire"+nm+"3d";
  name2h=replace(name2,"2d","h2d");
  name3h=replace(name3,"3d","h3d");
  fname=Fhead+ExecName+".txt"; //220203
  cfname=Fhead+ExecName+"wire"+nm+".dat"; //220204
  options=select(optionorg,length(#)>0); //190123from
  optionsh=select(optionshorg,length(#)>0);
  if(islist(wr1),
    udata=prepend(length(wr1),wr1);
  ,
    tmp=parse(rngu);
    tmp1=tmp_1; tmp2=tmp_2;
    udata=apply(1..wr1,tmp1+#*(tmp2-tmp1)/(wr1+1));
    udata=prepend(wr1,udata);
  );
  udata=udata_(2..(length(udata))); 
  if(islist(wr2),
    vdata=prepend(length(wr2),wr2);
  ,
    tmp=parse(rngv);
    tmp1=tmp_1; tmp2=tmp_2;
    vdata=apply(1..wr2,tmp1+#*(tmp2-tmp1)/(wr2+1));
    vdata=prepend(wr2,vdata);
  );
  vdata=vdata_(2..(length(vdata)));
  data2dL=[];
  forall(1..(length(udata)),
    tmp=Assign("[u,v]",["u",udata_#,"v",varv]);
    tmp1=Textformat(parse(rngv),6);
    tmp2=Paramplot("",tmp,varv+"="+tmp1,append(options,"nodata")); //220204
    data2dL=append(data2dL,tmp2);
  );
  forall(1..(length(vdata)),
    tmp=Assign("[u,v]",["u",varu,"v",vdata_#]);
    tmp1=Textformat(parse(rngu),6);
    tmp2=Paramplot("",tmp,varu+"="+tmp1,append(options,"nodata")); //220204
    data2dL=append(data2dL,tmp2);
  );
  options=select(options,indexof(#,"Num=")==0);  
  flg=1; //220205from
  forall(optionsh,
    if(substring(#,0,1)=="d",flg=0);
    if(substring(#,0,2)=="id",flg=0);
  );
  if(flg==1,optionsh=append(optionsh,"do"));
  tmp1=select(options,(indexof(#,"=")>0)&(Toupper(substring(#,0,2))=="CO"));
  if(length(tmp1)>0,
    optionsh=append(optionsh,tmp1_1);
  ); //220205to
  options=select(options,indexof(#,"Num=")==0);
//  options=append(options,"Style=n"); //220205
//  forall(1..(length(data2dL)), //220205from
//    StyleListC=concat(StyleListC,[name3+#,options]);
//    StyleListC=concat(StyleListC,[name3h+#,optionsh]);
//  );
  tmp=name2+"="+Textformat(data2dL,5)+";";
  parse(tmp);
  Crv2onsfparadata("wire"+nm,name2,sfbd,funnm,options,optionsh);
);
////%Wireparadata end////

////%Intersectcrvsf start//// //220202(major change)
Intersectcrvsf(nm,crv,fd):=IntersectcrvsfC(nm,crv,fd,[]);
Intersectcrvsf(nm,crv3d,fd,options):=IntersectcrvsfC(nm,crv3d,fd,options);
IntersectcrvsfC(nm,crv3d,fdorg,optionsorg):=(
//help:Intersectcrvsf("1",curve,fd);
  regional(fd,funnmL,name,fname,cfname,flg,cmdlist,
     tmp,tmp1,tmp2,msgflg,out,options,crv,rflg);
  //global WriteFlag
  options=optionsorg;
  tmp=select(options,#=="m"); //220201from
  if(length(tmp)>0,WriteFlag=1);
  rflg=0;
  tmp=select(options,substring(#,0,3)=="y-z"); //220201[2lines]
  if(length(tmp)>0,rflg=1;); //220201to
  crv=parse(crv3d);
  out=[];
  funnmL=[];
  fd=fdorg; //220126from
  if(islist(fd),
    tmp=select(1..(length(SurfList)),SurfList_#==Fullformfunc(fd));
    if(length(tmp)>0,
      funnmL=[tmp_1];
    ,
      SurfList=append(SurfList,fd);
      tmp=ConvertFdtoC(fd);
      FuncListC=append(FuncListC,tmp);
      funnmL=[length(SurfList)];
    );
  ,
    if(fd>length(SurfList),
      println("   num set to the last");
      funnmL=[length(SurfList)];
    ,
      funnmL=[fd];
    );
  ); //220126to 
  tmp1=FuncListC_(funnmL_1);
  tmp=Strsplit(tmp1_3,"=");
  tmp2="y="+tmp_2;
  tmp=Strsplit(tmp1_2,"=");
  tmp1_3="z="+tmp_2;
  tmp1_2=tmp2;
  FuncListC=append(FuncListC,tmp1);
  funnmL=append(funnmL,length(FuncListC));
  name="intersect"+nm;
  fname=Fhead+name+".txt";
  cfname=replace(fname,".txt",".dat");
  flg=0;
  if(!isexists(Dirwork,cfname),
    flg=1;
  ,
    tmp1=Readdatac(cfname);
    if(length(tmp1)==0,
      flg=1;
    ,
      tmp1=Textformat(tmp1,5);
      tmp2=crv;
      if(Measuredepth(tmp2)==1,tmp2=[tmp2]);
      if(tmp1!=Textformat(tmp2,5),flg=1);
    );
  );
  if(flg==1,WritedataC(cfname,crv));
  CommandListC=concat(CommandListC,[
    "  chfd[0]="+funnmL_1+";", //220202[2lines]
    "  chfd[1]="+funnmL_2+";",
    "  rangeUV("+funnmL_1+");", //220116[2lines]
    "  boundary("+funnmL_1+");",
    "  readdataC("+Dqq(cfname)+",data);",
    "  intersectcrvsf(chfd,data,out);",  //220116
    "  printf("+Dqq("%s\n")+",dirfname);", //220116
    "  output3(1,"+Dqq("a")+","+Dqq(name)+", dirfname,out);",
    "  /* intersectcrvsfend */"
  ]);
  out=[];
  if(isexists(Dirwork,fname),
    tmp1=Readoutdata(fname,["Msg=n"]);
    println(5545);
  );
  out; 
);
////%Intersectcrvsf end////

////%Sfcutparadatacdy start//// 181112,211106
Sfcutparadatacdy(nm,cutfun,fd):=
   Sfcutparadatacdy(nm,cutfun,fd,[]);
Sfcutparadatacdy(nm,cutfun,fdorg,optionorg):=(
//help:Sfcutparadatacdy("1","2*x+3*y+z=1",1,options);
//help:Sfcutparadatacdy(options=["Color=red","Num=[100,100]"]);
  regional(fd,funnm,options,eqL,out3,out2,name3,name2,eps,rep,jj,pL,vn1,vn2,
       tmp,tmp1,tmp2);
  eps=10^(-5);
  fd=fdorg; //220204from
  if(islist(fd),
    tmp1=Fullformfunc(fd);
    tmp=select(1..(length(SurfList)),SurfList_#==tmp1);
    if(length(tmp)>0,
      funnm=tmp_1;
    ,
      SurfList=append(SurfList,tmp1);
//      tmp=ConvertFdtoC(fd);
//      FuncListC=append(FuncListC,tmp);
      funnm=length(SurfList);
    );
  ,
    funnm=fd;
    if(funnm>length(SurfList),
      printlln("   num set to the last");
      funnm=length(SurfList);
    );
    fd=SurfList_funnm;
  ); //220204to
  name2="sfcc2d"+nm;
  name3="sfcc3d"+nm;
  options=optionorg;  //211106from
  tmp=Divoptions(options);
  eqL=tmp_5;
  options=remove(options,eqL); //211106to
//  fdL=Fullformfunc(fd);
  tmp=Strsplit(fd_5,"=");
  vn1=tmp_1;
  tmp=Strsplit(fd_6,"=");
  vn2=tmp_1;
  rep=["x",fd_2,"y",fd_3,"z",fd_4];
  tmp=Assign(cutfun,rep);  
  Implicitplot("sfc"+nm,tmp,fd_5,fd_6,
      concat(eqL,["Msg=n","nodisp"])); //211106
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
    tmp=tmp+"sfc"+nm+"3d"+text(#)+",";
    tmp1=tmp1+Dqq("sfc"+nm+"3d"+text(#))+",";
  );
  tmp=substring(tmp,0,length(tmp)-1)+"];"; //190415
  parse(tmp);
  tmp1=substring(tmp1,0,length(tmp1)-1)+"]";
  println("generate sfcutparadata "+tmp1);
  tmp=name2+"="+Textformat(out2,6)+";"; //190415
  parse(tmp);
  out3;
);
////%Sfcutparadatacdy end////

////%Sfcutparadata start//// //220119major change
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
//help:Sfcutparadata("1","2*x+3*y+z=1","sfbd3d",1(fd),nohiddenoptions,hiddenoptions);
  regional(funnm,cutfunL,fd,options,optionsh,name2,name3,name2h,name3h,
     eqL,reL,strL,fname,tmp,tmp1,tmp2,tmp3,tmp4,flg,ii,jj);
  // global CurFunList
  fd=fdorg; //220126from 
  if(islist(fd),
    tmp=select(1..(length(SurfList)),SurfList_#==Fullformfunc(fd));
    if(length(tmp)>0,
      funnm=tmp_1;
    ,
      SurfList=append(SurfList,fd);
      tmp=ConvertFdtoC(fd);
      FuncListC=append(FuncListC,tmp);
      funnm=length(SurfList);
    );
  ,
    funnm=fd;
    if(funnm>length(SurfList),
      printlln("   num set to the last");
      funnm=length(SurfList);
    );
  ); //220126to
  cutfunL=cutfunLorg;
  if(!islist(cutfunL),cutfunL=[cutfunL]);
  forall(1..(length(cutfunL)),
    tmp1=Strsplit(cutfunL_#,"=");
    if(length(tmp1)>1,
      tmp2=tmp1_1+"-("+tmp1_2+")"; //180516
      cutfunL_#=Cform(tmp2);
    );
  );
  CutFunList=concat(CutFunList,cutfunL); //211227
  name3="sfcut"+nm+"3d";
  name2=replace(name3,"3d","2d");
  name3h=replace(name3,"3d","h3d");
  name2h=replace(name3h,"3d","2d");
  fname=Fhead+ExecName+".txt"; //220203
  tmp=Divoptions(options);
  eqL=tmp_5;
  reL=tmp_6;
  strL=tmp_7;
  options=remove(options,reL);
  forall(strL,
    tmp=Toupper(substring(#,0,1));
    if(tmp=="M",
      WriteFlag=1;
      options=remove(options,[#]);
    );
    if(tmp=="R",
      options=remove(options,[#]);
    );
    if(tmp=="C", //180531
      options=remove(options,[#]);
    );
  );
  options=select(optionorg,length(#)>0); //190123
  optionsh=select(optionshorg,length(#)>0);
  tmp1=select(options, //220209from
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
  options=remove(options,eqL);
  forall(1..(length(cutfunL)),
    StyleListC=concat(StyleListC,[name3+#,options,name3h+#,optionsh]);
  );  //220209to
  if(!isexists(Dirwork,fname),
    WriteFlag=1;
  ,
    tmp1=parse(sfbd);
    Readoutdata(fname,["Msg=n"]);
    tmp2=parse(sfbd);
    tmp1=Textformat(tmp1,3);
    tmp2=Textformat(tmp2,3);
    if(tmp1!=tmp2,WriteFlag=1);
  );
  forall(1..(length(cutfunL)),
    CommandListC=concat(CommandListC,[
      "  rangeUV("+funnm+");",
      "  boundary("+funnm+");",
      "  readoutdata3(dirfname,"+Dqq(sfbd)+",sfbd);", 
      "  sfcutparadata("+funnm+","+#+",out);",
      "  connectseg3(out,Eps1,data);",
      "  output3h("+Dqq("a")+","+Dqq(name3+#)+","+Dqq(name3h+#)+",dirfname,data);",
      "  /* sfcutparadataend */"
    ]);
    flg=0;
    tmp1=Readoutdata(fname,["Msg=n"]);
    if((contains(tmp1,name3+#))&(contains(tmp1,name3h+#)),flg=1);
    if(flg==0,
      println("  ExeccmdC will generate "+ name3+","+name3h);
    ,
      println("  "+name3+#+","+name3h+#+" are found in "+fname);
    );
  );
);
////%Sfcutparadata end////

////%WritetoW start////  //191229
WritetoW(fname,cmdL):=(
// help:WritetoM("outdata",cmdL);
  regional(tmp,tmp1,tmp2,filename,jj);
  if(indexof(fname,".")==0,
    filename=fname+".wl";
  ,
    filename=fname;
  );
  wfilename=replace(filename,".wl",".txt");
  SCEOUTPUT = openfile(filename);
  outflg=0;
  forall(1..(length(cmdL)),jj,
    tmp1=cmdL_jj;
    if(#<length(cmdL),
      tmp=tmp1;
    ,
      tmp1=Strsplit(tmp1,"::");
      tmp="Print[";
      forall(tmp1,
        tmp=tmp+#+",";
      );
      tmp=substring(tmp,0,length(tmp)-1)+"]";
    );
    println(SCEOUTPUT,tmp1+"(*##*)");
  );
  closefile(SCEOUTPUT);
);
////%WritetoW end////

////%kcW start////
kcW(fname):=kcW(fname,[]);
kcW(fname,optionorg):=(
//help:kcW("boxdata");
//help:kcW(options=["r/m"]);
  regional(options,tmp,tmp1,tmp2,eqL,strL,filename,wfile,rfile,flg);
  if((!isstring(PathW))%(PathW==""),PathW="wolframscript"); //200105
  if(indexof(fname,".")==0,
    filename=fname+".wl";
  ,
    filename=fname;
  );
  wfile=replace(filename,".wl",".txt");
  rfile=replace(filename,".wl",".res"); //200105
  options=optionorg;
  tmp=Divoptions(options);
  eqL=tmp_5;
  strL=tmp_7;
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
    tmp2=replace(filename,".wl",".txt");
    tmp1=Readlines(tmp2); //200515
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
    SCEOUTPUT=openfile(wfile);
    println(SCEOUTPUT,"");
    closefile(SCEOUTPUT);
    SCEOUTPUT=openfile(rfile);
    println(SCEOUTPUT,"");
    closefile(SCEOUTPUT);
    if(iswindows(),
      SCEOUTPUT = openfile("kc.bat");
      println(SCEOUTPUT,"cd "+Dqq(Dirwork));
      if(PathW=="wolframscript", //200105from
        tmp=Dqq("wolframscript")+" -file "+Dqq(filename)+" > "+Dqq(rfile);
      ,
        tmp=Dqq(PathW)+" < "+Dqq(filename)+" > "+Dqq(rfile);
      );  //200105to
      println(SCEOUTPUT,tmp); 
      println(SCEOUTPUT,"echo 99999 >>"+Dqq(rfile)); 
      println(SCEOUTPUT,"exit");
      closefile(SCEOUTPUT);
      println(kc(Dirwork+Batparent,Mackc+Dirlib,wfile));
    ,
      if(ismacosx(),
        SCEOUTPUT = openfile("kc.command");
      ,
        SCEOUTPUT = openfile("kc.sh");
      );
      println(SCEOUTPUT,"#!/bin/sh");
      println(SCEOUTPUT,"cd "+Dqq(Dirwork));
      if(PathW=="wolframscript", //200105from
        tmp=Dqq("wolframscript")+" -file "+Dqq(filename)+" > "+Dqq(rfile);
      ,
        if(indexof(PathW,"MathematicaScript")>0, //200718from
          tmp=Dqq(PathW)+" -script "+Dqq(filename);
        ,
          tmp=Dqq(PathW)+" < "+Dqq(filename)+" > "+Dqq(rfile);
        ); //200718to
      );  //200105to
      println(SCEOUTPUT,tmp); 
      println(SCEOUTPUT,"echo 99999 >>"+Dqq(rfile)); 
      println(SCEOUTPUT,"exit 0");
      closefile(SCEOUTPUT);
      println(kc(Dirwork+Shellparent,Mackc+Dirlib,wfile));
    );
    setdirectory(Dirwork);
  );
);
////%kcW end////

////%CalcbyW start////
CalcbyW(name,cmd):=CalcbyW(name,cmd,[]);
CalcbyW(name,cmd,optionorg):=(
//help:CalcbyW("a",cmdL);
//help:CalcbyW(options1= ["m/r","Wait=5","Dig=6"]);
  regional(options,time,tmp,tmp1,tmp2,tmp3,tmp4,strL,eqL,tm,
      dig,flg,wflg,nc,arg,add,cmdW,cmdlist,file,wfile,rfile,waiting);
  options=optionorg;
  tmp=divoptions(options);
  eqL=tmp_5;
  strL=tmp_7;
  waiting=5;
  dig=6;
  forall(eqL,
    tmp=Strsplit(#,"=");
    tmp1=Toupper(substring(tmp_1,0,1));
    tmp2=tmp_2;
    if(tmp1=="W",
      waiting=parse(tmp2);
      options=remove(options,[#]);
    );
    if(tmp1=="D",
      dig=parse(tmp2);
      options=remove(options,[#]);
    );
  );
  file=Fhead+name;
  wfile=file+".txt";
  rfile=file+".res";  //200105
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
  cmdW=cmd;
  cmdlist=[
  ];
  forall(1..floor(length(cmdW)/2),nc, //17.5.18
    tmp1=replace(cmdW_(2*nc-1),"`","'");//2016.02.23
    tmp1=replace(tmp1,LFmark,""); // 16.06.12
    if(nc==length(cmdW)/2,
      tmp1=replace(tmp1,"(*##*)","");
      tmp=tokenize(tmp1,"::");
      tmp2="Export["+Dqq(wfile)+",{"+Dqq("{{")+","; //200105from
      forall(1..(length(tmp)-1),
        tmp2=tmp2+tmp_#+","+Dqq("},{")+",";
      );
      tmp2=tmp2+tmp_(length(tmp))+","+Dqq("}}")+",99999}]"; //200105to
      cmdlist=append(cmdlist,tmp2);
    ,
      tmp2=cmdW_(2*nc);  // list of argments
      tmp3="";
      tmp4="";
      add="";
      forall(tmp2,arg,
        if(isstring(arg),
          if(substring(arg,0,1)!=",",
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
            tmp3=tmp3+"{";
            tmp4="}";
            forall(arg,
              if(isstring(#),
                tmp=replace(#,"'",Dq);
                tmp3=tmp3+tmp+",";
              ,
                if(!islist(#),  
                  tmp3=tmp3+textformat(#,dig)+",";
                ,
                  tmp=textformat(#,dig);
                  tmp=replace(tmp,"},{","};{");
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
        tmp1=tmp1+"["+tmp3+"]"+add;
      );
      cmdlist=append(cmdlist,tmp1);
    );
  );
  cmdlist=append(cmdlist,"Quit[]");
  if(wflg==0,
    tmp1=Readlines(file+".wl"); //200515
    if(length(tmp1)==0,
      wflg=1;
    ,
      if(indexof(tmp1_1,"(*##*)")==0,  // 15.11.26
        wflg=1;
      ,
        tmp1=apply(tmp1,replace(#,"(*##*)",""));
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
    WritetoW(file+".wl",cmdlist); // 2016.02.23
    kcW(file,concat(options,["m"]));
  );
  flg=0;
  time=floor(waiting*1000/WaitUnit);
  repeat(time,nc,
    if(flg==0,
      if(isexists(Dirwork,rfile), //201015from
        tmp3=Readlines(rfile); //200515
      ,
        tmp3=[];
      ); //201015to
      tmp3=select(tmp3,length(tmp3)>0);
      if(length(tmp3)>0,
        if(tmp3_(length(tmp3))=="99999",
          tmp3=tmp3_(1..(length(tmp3)-1));
          tm=nc*WaitUnit/1000;
          flg=2; 
        );
      );
    );
    if(flg==0,
      if(wflg==-1,
        flg=1;
      ,
        wait(WaitUnit);
      );
    );
  );
  if(flg==2, //200110from
    wait(WaitUnit);
    tmp2=Readlines(wfile); //200515
    tmp2=select(tmp2,length(tmp2)>0);
    if(length(tmp2)>0,
      if(tmp2_(length(tmp2))=="99999",
        tmp2=tmp2_(1..(length(tmp2)-1));
        flg=1;
      );
    ,
      tmp3=Readlines(Dirwork,rfile); 
      tmp3=select(tmp3,length(#)>0);
      println(name+" : Installing may not be completed");
      apply(tmp3,println("        "+#));
      flg=0;
    );
  );
  if(flg==1,
    tmp1="";
    forall(tmp2,
      tmp1=tmp1+#;
    );
    tmp=Bracket(tmp1,"{}");
    tmp2=select(tmp,#_2==2);
    tmp3=select(tmp,#_2==-2);
    tmp="";
    forall(1..(length(tmp2)),
      tmp=tmp+Dqq(substring(tmp1,tmp2_#_1,tmp3_#_1-1))+",";
    );
    tmp=substring(tmp,0,length(tmp)-1);
    if(length(tmp1)/2>1,
      tmp="["+tmp+"];";
    );
    tmp=replace(tmp," ","");
    parse(name+"="+tmp);
  ); //200110to
  if(flg==0,
    tmp="("+text(waiting)+" s )";
    tmp2=Readlines(wfile); //200515
    if(length(tmp2)>0,
      println(wfile+" incomplete"+tmp1);
    ,
      println(wfile+" not generated "+tmp);
    );
  ,
    tmp3=Readlines(Dirwork,rfile); //200105from
    tmp3=select(tmp3,length(#)>0);
    if(PathW!="wolframscript",
      tmp3=select(tmp3,indexof(#,"::")>0);
    );
    if(length(tmp3)>0,
      if(tmp3_(length(tmp3))=="99999",
        tmp3=tmp3_(1..(length(tmp3)-1));
      );
    );
    if(length(tmp3)>0,
      println(name+" : Errors may have occurred");
      apply(tmp3,println(#));
      flg=0;
    ); //200105to
    if(flg==1,
      println("      CalcbyW succeeded "+name+" ("+text(tm)+" sec)");
    );
  );
  flg; //210827
);
////%CalcbyW end////

////%Wlfun start////
Wlfun(nm,fun,argL):=Wlfun(nm,fun,argL,[]);
Wlfun(nm,fun,argL,optionorg):=(
//help:Wlfun("ca1","diff",["sin(x)^3","x"],[""]);
//help:Wlfun(options=["Pre=6","Msg=y"]);
  regional(name,options,eqL,precise,msg,set,cmdL,tmp,tmp1,tmp2);
  name="wl"+nm;
  options=optionorg;
  tmp=divoptions(options);
  precise=6;
  msg="Y";
  eqL=tmp_5;
  forall(eqL,
    tmp=Strsplit(#,"=");
    tmp1=Toupper(substring(tmp_1,0,1)); //190424
    tmp2=tmp_2;
    if(tmp1=="P",
      precise=parse(tmp2);
      options=remove(options,[#]);
    );
    if(tmp1=="M" ,  //190327(to 1 char)
      msg=Toupper(substring(tmp2,0,1));
      options=remove(options,[#]);
    );
  );
  cmdL=[];
  cmdL=concat(cmdL,[
    "ans"+"="+fun,argL,
    "ans",[]
  ]);
  CalcbyW(name,cmdL,options);
  tmp1=parse(name);
  if(islist(tmp1),tmp1=tmp1_1);
  tmp=name+"="+Dqq(tmp1)+";";
  parse(tmp);
  if(msg=="Y", // 15.11.24
    println(name+" is : ");
    println(tmp1);
  );
  tmp1;
);
////%Wlfun end////

////%Wltex start////
Wltex(nm,ex):=Wltex(nm,ex,[]);
Wltex(nm,ex,optionorg):=(
//help:Wltex("1","sin(x)/x");
//help:Wltex(options=["Msg=y"]);
  regional(name,cmdL,eqL,options,tx,msg,
     tmp,tmp1,tmp2); // 16.01.25
  name="tx"+nm;
  options=optionorg;
  tmp=divoptions(options);
  eqL=tmp_5;
  msg="Y";
  set=[];
  forall(eqL,
    tmp=indexof(#,"=");
    tmp1=Toupper(substring(#,0,1));
    tmp2=substring(#,tmp,length(#));
	if(tmp1=="D" ,
      msg=Toupper(substring(tmp2,0,1));
      options=remove(options,[#]);
    );
  );
  cmdL=[
  ];
  cmdL=concat(cmdL,[
    "tx=TeXForm",[ex],
    "ans=ToString[tx]",[],
    "ans",[]
  ]);
  CalcbyW(name,cmdL,options);
  tx=parse(name);
  if(islist(tx),tx=tx_1);
  if(msg=="Y",  //  16.01.10
    println(name+" is:");
    println(tx);
  );
  tmp=name+"="+Dqq(tx)+";";
  parse(tmp);
  tx;
);
////%Wltex end////

////%TocindyW end////
TocindyW(str):=(
//help:TocindyW(ans);
  regional(out,nn,kk,tmp,tmp1,tmp2,tmp3);
  if(substring(str,0,1)=="{",
    tmp3=[];
    tmp1=Bracket(str,"{}");
    tmp2=Indexall(str,",");
    forall(1..(length(tmp2)),nn,
      tmp=select(tmp1,#_1<tmp2_nn);
      tmp=tmp_(-1);
      if(tmp_2>0,kk=tmp_2,kk=abs(tmp_2+1));
      if(kk==1,tmp3=append(tmp3,tmp2_nn));
    );
    tmp3=append(tmp3,length(str));
    out=[];
    kk=1; //200115
    forall(1..(length(tmp3)),
      tmp=substring(str,kk,tmp3_#-1);
      tmp=Removespace(tmp);
      tmp=replace(tmp,[["{","["],["}","]"]]);
      out=append(out,tmp);
      kk=tmp3_#;
    );
  ,
    out=replace(out,[["{","["],["}","]"]]);      
  );
  out;
);
////%TocindyW end////

////%TocindyM end////
TocindyM(str):=(
//help:TocindyM(ans);
  regional(out,nn,kk,tmp,tmp1,tmp2,tmp3);
  if(substring(str,0,1)=="[",
    tmp3=[];
    tmp1=Bracket(str,"[]");
    tmp2=Indexall(str,",");
    forall(1..(length(tmp2)),nn,
      tmp=select(tmp1,#_1<tmp2_nn);
      tmp=tmp_(-1);
      if(tmp_2>0,kk=tmp_2,kk=abs(tmp_2+1));
      if(kk==1,tmp3=append(tmp3,tmp2_nn));
    );
    tmp3=append(tmp3,length(str));
    out=[];
    kk=1; //200115
    forall(1..(length(tmp3)),
      tmp=substring(str,kk,tmp3_#-1);
      tmp=Removespace(tmp);
//      tmp=replace(tmp,[["{","["],["}","]"]]);
      out=append(out,tmp);
      kk=tmp3_#;
    );
  ,
//    out=replace(out,[["{","["],["}","]"]]);      
  );
  out;
);
////%TocindyM end////

//help:end();

