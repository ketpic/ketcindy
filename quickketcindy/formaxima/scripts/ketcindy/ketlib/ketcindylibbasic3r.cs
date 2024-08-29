//  Copyright (C)  2014  Setsuo Takato, KETCindy Japan project team
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

println("ketcindylibbasic3[202408-26] loaded");

//help:start();

////%Tenkeybrd start////
Tenkeybrd(pLB):=Tenkeybrd(pLB,[]);
Tenkeybrd(pLB,options):=(
//help:Tenkeybrd([2,1],"Size=1.5");
//help:Tenkeybrd(Buttons shoud be given);
  regional(axes,xL,yL,size,shade,color,tmp,tmp1);
  size="Size=1.5";
  shade="Y";
  color="Color=[0,0,0.2,0]";
  forall(options,
    tmp=Strsplit(#,"=");
    tmp1=Toupper(substring(tmp_1,0,2));
    if(tmp1=="SI",
      size=#;
    );
    if(tmp1=="SH",
      shade=Toupper(substring(tmp_2,0,1));
    );
    if(tmp1=="CO",
      color=#;
    );
  );
  axes=ADDAXES;
  cell=8;
  if(shade=="Y",
    Framedata2("tenkey",[pLB,pLB+cell/10*[3,5]]);
    Shade(["frtenkey"],[color]);
  );
  xL=apply(1..3,cell);
  yL=apply(1..5,cell);
  Tabledata(xL,yL,[],[0,"Setw=n","Move="+text(pLB)]);
  Addax(axes);
  [tmp1,tmp2];
);
////%Tenkeybrd end////

////%Keyaction start////
Keyaction(key):=(
  regional(kL,kstr,endflg,sign);
//help:Keyaction(key);
//help:Getkey(Tenkeys should be given in advance);
  endflg=0;
  sign=1;
  if(indexof(Tenkeys,"-")>0,
    sign=-1;
    Tenkeys=replace(Tenkeys,"-","");
  );
  kstr=Tenkeys;
  if((key=="C")%(key=="A")%(key=="=")%(indexof(key,"-")>0),
    if(key=="C",kstr=substring(kstr,0,length(kstr)-1));
    if(key=="A",sign=1;kstr="");
    if(key=="=",endflg=1);
    if(indexof(key,"-")>0,sign=-sign);
  ,
    kstr=kstr+key;
  );
  if(substring(kstr,0,1)==".",kstr="0"+kstr);
  if(sign==-1,
    kstr="-"+kstr;
  );
  Tenkeys=kstr;
  endflg;
);
////%Keyaction end////

////%Dispchoice start////
Dispchoice():=(
  if(islist(Ch),
    if(!isreal(ChNum),ChNum=1);
    drawtext(mouse().xy,"Ch="+text(Ch)+" N="+text(ChNum),size->24,color->[0,0,1]);
  );
);
////%Dispchoice end////

////%Datetime start////
Datetime():=(
//help:Datetime();
  regional(names,dt,tmp);
  tmp=getdatetime();
  dt=tokenize(tmp," ");
  dt=apply(dt,if(!isstring(#),text(#),#));
  names=["Jan","Feb","Mar","Apr","May","Jun",
     "Jul","Aug","Sep","Oct","Nov","Dec"];
  tmp=select(1..12,names_#==dt_2);
  tmp=text(tmp_1);
  tmp=[dt_6+"/"+tmp+"/"+dt_3,dt_4];
);
////%Datetime end////

////%Writebezier start////
Writebezier():=Writebezier(Fhead,"all");
Writebezier(head):=Writebezier(head,"all");
Writebezier(head,seL):=(
//help:Writebezier(file);
//help:Writebezier(file,"acd");
  regional(bz,dt,name,tmp,tmp1,tmp2);
  bz=select(GLIST,indexof(#,"=Bezier")>0);
  tmp1=[]; // 16.04.22from
  if(seL!="all",
    forall(1..length(seL),
      tmp=substring(seL,#-1,#);
      tmp=select(bz,indexof(#,"bz"+tmp)>0);
      tmp1=concat(tmp1,tmp);
    );
    bz=tmp1;// 16.04.22until
  );
  dt=[head+"n",[[length(bz),0]]];
  forall(1..length(bz),
    tmp=indexof(bz_#,"=");
    name=substring(bz_#,0,tmp-1);
    tmp=indexof(bz_#,","+Dq);
    if(tmp>0,
      tmp1=substring(bz_#,0,tmp-1)+")";
    ,
      tmp1=bz_#;
    );
    tmp1=replace(tmp1,"Bezier(","[");
    tmp1=replace(tmp1,"list"+PaO(),"[");
    tmp1=replace(tmp1,")","]");
    tmp1=replace(tmp1,",",".xy,");
    tmp1=replace(tmp1,"]",".xy]");
    tmp1=replace(tmp1,".xy,[",",[");
    tmp1=replace(tmp1,"].xy","]");
    tmp1=replace(tmp1,name,head+text(#))+";"; //190415
    parse(tmp1);
    tmp=parse(head+text(#)+"_1");
    dt=concat(dt,[head+text(#)+"k",tmp]);    
    tmp=parse(head+text(#)+"_2");
    dt=concat(dt,[head+text(#)+"c",tmp]);    
  );
  WriteOutData(head+".txt",dt);
  dt;
);
////%Writebezier end////

////%Readbezier start////
Readbezier(file):=Readbezier(file,[]);
Readbezier(file,options):=Readbezier("",file,options);
Readbezier(path,file,optionorg):=(
//help:Readbezier("xsr");
//help:Readbezier(options=["Num=10","nogeo"]);
  regional(nn,options,stL,geo,nc,alpha,out,tmp,tmp1,tmp2,tmp3);
  options=optionorg;
  tmp=Divoptions(options);
  stL=tmp_7;
  geo=0;
  forall(stL,
    tmp=Toupper(substring(#,0,1));
    if(tmp=="G",geo=1);
    options=remove(options,[#]);
  );
  if(length(path)>0,
    Readoutdata(path,file);
  ,
    Readoutdata(file);
  );
  tmp=file+"n_1_1";
  nn=parse(tmp);
  out=[];
  forall(1..nn,nc,
    tmp=file+text(nc);
    tmp1=parse(tmp+"k");
    tmp2=parse(tmp+"c");
    if(Measuredepth(tmp2)==1,tmp2=[tmp2]); // 16.04.22from
    if(geo==1,
      alpha="abcdefghijklmnopqrstuvwxyz";
      forall(1..length(tmp1),
        tmp="k"+BezierNumber+"n"+text(nc)+substring(alpha,#-1,#);
        Putpoint(tmp,tmp1_#,parse(tmp+".xy"));
        inspect(parse(tmp),"labeled",false);
        inspect(parse(tmp),"ptsize",3);
        tmp1_#=parse(tmp+".xy");
      );
      forall(1..length(tmp2),
        tmp="c"+BezierNumber+"n"+text(nc)+substring(alpha,#-1,#)+"1";
        Putpoint(tmp,tmp2_#_1,parse(tmp+".xy"));
        inspect(parse(tmp),"labeled",false);
        inspect(parse(tmp),"color",4);
        inspect(parse(tmp),"ptsize",3);
        tmp2_#_1=parse(tmp+".xy");
        tmp="c"+BezierNumber+"no"+text(nc)+substring(alpha,#-1,#)+"2";
        Putpoint(tmp,tmp2_#_2,parse(tmp+".xy"));
        inspect(parse(tmp),"labeled",false);
        inspect(parse(tmp),"color",4);
        inspect(parse(tmp),"ptsize",3);
        tmp2_#_2=parse(tmp+".xy");
      );
      BezierNumber=BezierNumber+1;
    );
    Bezier(file+text(nc),tmp1,tmp2,options);// 16.04.22until
    out=append(out,"bz"+tmp);
  );
  out;
);
////%Readbezier end////

////%RSform start////
RSform(str):=RSform(str,3);
RSform(str,listfrom):=(
//help:RSform(string,listfrom(3));
  regional(posL,mxlv,rep1,rep2,rep3,prev,out,
    tmp,tmp1,tmp2);
  rep1="c"+PaO(); rep2="c"+PaO(); rep3="list"+PaO();
  if(listfrom<3,rep2="list"+PaO());
  if(listfrom==1,rep1="list"+PaO());
  posL=Bracket(str,"[]");
  tmp=apply(posL,#_2);
  mxlv=max(tmp);
  out="";
  prev=0;
  forall(posL,
    out=out+substring(str,prev,#_1-1);
    prev=#_1;
    if(#_2>0,
      tmp1=select(posL,tmp,(tmp_2<0)&(tmp_1>#_1));
      tmp1=tmp1_1_1;
      tmp=substring(str,#_1,tmp1);
      if(#_2==mxlv,out=out+rep1);
      if(#_2==mxlv-1,out=out+rep2);
      if(#_2<=mxlv-2,out=out+rep3);
    ,
      out=out+")";
    );
  );
  out=out+substring(str,prev,length(str));
  out=replace(out,".xy","");
  out=replace(out,".x","[1]");
  out=replace(out,".y","[2]");
  out=replace(out,"c"+PPa("1"),"[1]");//17.10.06[2lines]
  out=replace(out,"c"+PPa("2"),"[2]");
  out;
);
////%RSform end////

////%RSslash start////
RSslash(str):=(  //17.09.24
  regional(tmp);
  tmp=replace(str,"\","\\");
//  tmp=replace(tmp,"\\\\","\\");
  tmp;
);
////%RSslash end////

////%Rform start////
Rform(list):=(
  regional(plotlist,comp,pos,out,strL,tmp,tmp1,tmp2,tmp3,Nj);
  out=list;
  out=replace(out,"[[[","list"+PaO()+"[[");
  out=replace(out,"[","c"+PaO());
  out=replace(out,"]",")");
  out=replace(out,".xy","");
  out=replace(out,".x","[1]");
  out=replace(out,".y","[2]");
  out;
);
////%Rform end////

////%Defvar start////
Defvar(varstr):=(
  regional(name,value,tmp,tmp1);
  if(isstring(varstr),
    parse(varstr+";");
    tmp=indexof(varstr,"=");
    name=substring(varstr,0,tmp-1);
    value=substring(varstr,tmp,length(varstr));
    value=parse(value);
    tmp1=select(1..length(VLIST),VLIST_#_1==name);
    if(length(tmp1)>0,
      tmp=tmp1_1;
      VLIST_tmp=[name,value];
    ,
      VLIST=prepend([name,value],VLIST);
    );
  ,
    forall(1..(length(varstr)/2), // 16.11.16from
      name=varstr_(2*#-1);
      value=varstr_(2*#);
      Defvar(name,value);
    ); // 16.11.16until
  );
);
Defvar(name,value):=(
//help:Defvar("a",0.3);
//help:Defvar(["a",0.3,"b",2]);
  regional(tmp,tmp1);
  if(islist(value),
    tmp1="[";
    forall(value,
      if(isstring(#), // 16.11.14
        tmp1=tmp1+Dq+#+Dq+","; // 16.11.14
      ,
        tmp1=tmp1+format(#,16)+","; //190918
      );
    );
    tmp1=substring(tmp1,0,length(tmp1)-1)+"]";
  ,
    tmp1=format(value,10);
  );
  tmp=name+"="+tmp1+";"; // 15.02.06//190415
  parse(tmp);
  VLIST=select(VLIST,#_1!=name); // 15.02.08
  VLIST=prepend([name,value],VLIST);
);
////%Defvar end////

////%IftoR start////
IftoR(strorg):=( //180802
  regional(str,ifL,ppL,cpL,kk,sL,out,
    tmp,tmp1,tmp2,tmp3,tmp4);
  str=replace(strorg,LFmark,"");
  ifL=Indexall(str,"if"+PaO());
  ppL=Bracket(str,"()");
  cpL=Indexall(str,",");
  tmp1=Bracket(str,"[]");
  forall(1..(length(tmp1)/2),kk,
    cpL=select(cpL,#<tmp1_(2*kk-1)_1%#_1>tmp1_(2*kk)_1);
  );
  forall(1..length(ifL),kk,
    tmp=select(ppL,#_1>ifL_kk);
    tmp1=tmp_1;
    tmp2=select(tmp,#_2==-tmp1_2);
    tmp2=tmp2_1;
    tmp3=select(cpL,#>tmp1_1 & #<tmp2_1);
    ifL_kk=[tmp1_1,tmp2_1,tmp1_2,tmp3];
  );
  forall(1..length(cpL),kk,
    tmp=select(1..length(ifL),contains(ifL_#_4,cpL_kk));
    tmp1=tmp_(length(tmp));
    cpL_kk=[cpL_kk,tmp1];
  );
  sL=apply(1..length(str),substring(str,#-1,#));
  forall(1..length(ifL),kk,
    tmp1=ifL_kk_1;
    tmp2=ifL_kk_2;
    tmp=select(cpL,#_2==kk);
    tmp3=apply(tmp,#_1);
    sL_tmp1="(";
    sL_tmp2="}";
    sL_(tmp3_1)="){";
    if(length(tmp3)>1,
      sL_(tmp3_2)="}else{";
    );
  );
  out=sum(sL);
  out;
);
////%IftoR end////

////%FortoR start////
FortoR(strorg):=(
  regional(str,pre,post,sub,ppL,forstr,out,tmp,tmp1,tmp2);
  str=strorg;
  forstr=indexof(str,"forall(");
  if(forstr==0,
    out=str;
  ,
    pre=substring(str,0,forstr-1)+"for"+PaO();
    ppL=Bracket(str,"()");
    tmp1=forstr+6;
    tmp=select(ppL,#_1==tmp1);
    tmp=select(ppL,#_2==-tmp_1_2);
    tmp2=tmp_1_1;
    sub=substring(str,tmp1,tmp2-1);
    post="}"+substring(str,tmp2,length(str));
    tmp=indexof(sub,",");
    tmp1=substring(sub,0,tmp-1);
    tmp2=substring(sub,tmp,length(sub));
    sub=tmp1+"){"+tmp2;
    tmp1=indexof(sub,"{");
    tmp2=indexof(sub,",");
    tmp=substring(sub,tmp1,tmp2-1);
    pre=pre+tmp+" in "+substring(sub,0,tmp1-1)+"{";
    sub=substring(sub,tmp2,length(sub));
    tmp=FortoR(sub);
    out=pre+tmp+"}";
  );
  out=replace(out,"..",":");
  out;
);
////%FortoR end////

////%Deffun start////
Deffun(name,bodylist):=(
//help:Deffun("f(x)",["regional(y)","y=x^2*(x-3)","y"]);
  regional(funstr,str,pos,nbody,bdy,ppL,bpL,excma,tmp,tmp1,tmp2);
  funstr=name+":=(";
  forall(bodylist,
    tmp1=Removespace(#); //190816from
    tmp1=tmp1+";";
    funstr=funstr+tmp1; //190816to
  );
  funstr=funstr+");";
  parse(funstr);
  tmp=indexof(name,"("); // no ketjs on //190814
  str=substring(name,0,tmp-1)+"<-function"+PaO();
  str=str+substring(name,tmp,length(name))+"{";
  forall(1..(length(bodylist)-1),nbody,
    bdy=bodylist_nbody;
    pos=indexof(bdy,"regional")+indexof(bdy,"local");
    if(pos==0,
      bdy=replace(bdy,LFmark,"");
      bdy=replace(bdy," ","");
      ppL=Bracket(bdy,"()");
      bpL=Bracket(bdy,"[]");
      tmp1=select(bpL,#_2==1);
      tmp2=select(bpL,#_2==-1);
      excma=[];
      forall(1..(length(tmp1)),
        excma=append(excma,[tmp1_#_1,tmp2_#_1]);
      );
      tmp1=Indexall(bdy,",");
      forall(tmp1,cma,
        tmp=select(excma,(#_1<cma)&(cma<#_2));
        if(length(tmp)>0,
          bdy=substring(bdy,0,cma-1)+"'"+substring(bdy,cma,length(bdy));
        );
      );
      tmp=indexof(bdy,"forall");
      if(tmp>0,
        bdy=FortoR(bdy);
      );
      tmp=indexof(bdy,"if(");
      if(tmp>0,
        bdy=IftoR(bdy);
      );
      bdy=RSform(replace(bdy,"'",","));
      str=str+bdy+";";
    );
  );
  tmp1=bodylist_(length(bodylist)); //190816from
  tmp1=RSform(tmp1,2);
  str=str+"return"+PaO()+tmp1+")}"; //190816to
  FUNLIST=append(FUNLIST,str); // no ketjs off
);
////%Deffun end////

////%WritetoRS start////
WritetoSci():=WritetoRS(); //17.12.19
WritetoSci(Arg):=WritetoRS(Arg);//180619
WritetoRS():=WritetoRS(FnameR);// 17.09.17from
WritetoRS(Arg):=(
  regional(string,filename,shch,tmp1,tmp2);
  if(isstring(Arg),
    string=Arg;
    if(indexof(string,".r")>0,
      filename=string;
      shch="";
    ,
      filename=FnameR;
      shch=string;
    );
    WritetoRS(filename,shch);
  ,
    if(Arg<=1,WritetoRS(FnameR,"all"));
    if(Arg==2,WritetoRS(FnameR,"sh"));
  );
);
WritetoRS(filename,shchoice):=(
  regional(Plist,Pos,GrL,str,tmp,tmp1,tmp2,cmd,ns,spos,epos);
//help:WritetoRS(2);
  println("Write to R "+filename);
  Plist=[];
  Pnamelist=[];
  forall(remove(allpoints(),[SW,NE]),
    if(indexof(#.name,"[")==0, //181106
      tmp=Lcrd(#);
      tmp1=format(re(tmp_1),10);// 15.02.05
      tmp2=format(re(tmp_2),10);
      tmp=#.name+"="+"c("+tmp1+","+tmp2+");";
      tmp=tmp+"Assignadd('"+#.name+"',"+#.name+")";
      Plist=append(Plist,tmp);
    ,
      println("Remove the abnormal poiint "+#.name); //181106
    );
  );
  SCEOUTPUT = openfile(filename);
  tmp=Datetime();
  println(SCEOUTPUT,"# date time="+tmp_1+" "+tmp_2);
  if(isstring(CindyName), // 16.12.25from
    if(length(CindyPathName)>0,
      println(SCEOUTPUT,
           "# path file="+CindyPathName+" "+CindyFileName+".cdy");
    ,
      println(SCEOUTPUT,"");
    );
  ,
    println(SCEOUTPUT,"");
  );
  if(iswindows(),
    println(SCEOUTPUT,"options"+PaO()+"encoding='UTF-8')");  //190111
  );
  tmp1=replace(Dirwork,"\","/");
  if((iswindows())&(indexof(tmp1,"Users")>0),
    tmp=Indexall(tmp1,"/");
    tmp2=substring(tmp1,tmp_3-1,length(tmp1));
    tmp1=substring(tmp1,0,tmp_3-1);
    println(SCEOUTPUT,"Drv=shell"+PaO()+"'echo %HOMEDRIVE%',intern=TRUE)"); //190111
    println(SCEOUTPUT,"Drv=Drv[length"+PaO()+"Drv)]");
    println(SCEOUTPUT,"Hpath=shell"+PaO()+"'echo %HOMEPATH%',intern=TRUE)");
    println(SCEOUTPUT,"Hpath=Hpath[length"+PaO()+"Hpath)]");
    println(SCEOUTPUT,"Rest="+Dqq(tmp2));
    println(SCEOUTPUT,"Path=paste"+PaO()+"Drv,Hpath,Rest,sep='')");
    println(SCEOUTPUT,"Path=gsub"+PaO()+"'\\','/',Path,fixed=TRUE)"); //180610
    println(SCEOUTPUT,"setwd"+PaO()+"Path)"); 
  ,
    println(SCEOUTPUT,"setwd"+PaO()+"'"+tmp1+"')"); 
  );//180409to
  tmp=replace(Libname,"\","/"); //17.09.24from
  println(SCEOUTPUT,"source"+PaO()+"'"+tmp+".r')"); //181213
  if(indexof(GPACKL_1,"pict2e")>0, //  190615
    tmp=replace(tmp+"_rep2e","\","/");
    println(SCEOUTPUT,"source('"+tmp+".r')");
  ); 
  if(indexof(GPACKL_1,"tikz")>0, //181213from //190615
    tmp=replace(tmp+"_reptikz","\","/");
    println(SCEOUTPUT,"source"+PaO()+"'"+tmp+".r')");
  ); //181213to
  println(SCEOUTPUT,"Ketinit"+PPa(""));
  println(SCEOUTPUT,"cat"+PaO()+"ThisVersion,'\n')"); 
  println(SCEOUTPUT,"Fnametex='"+Fnametex+"'");
  println(SCEOUTPUT,"FnameR='"+FnameR+"'");
  println(SCEOUTPUT,"Fnameout='"+Fnameout+"'");
  println(SCEOUTPUT,"arccos=acos; arcsin=asin; arctan=atan");
  println(SCEOUTPUT,"Acos<- function"+PPa("x")+"{acos"+PaO()+"max"+PaO()+"-1,min"+PaO()+"1,x)))}");
  println(SCEOUTPUT,"Asin<- function"+PPa("x")+"{asin"+PaO()+"max"+PaO()+"-1,min"+PaO()+"1,x)))}");
  println(SCEOUTPUT,"Atan=atan");
  println(SCEOUTPUT,"Sqr<- function"+PPa("x")+"{if"+PaO()+"x>=0){sqrt"+PaO()+"x)}else{0}}");
  println(SCEOUTPUT,"Factorial=factorial");
  println(SCEOUTPUT,"Norm<- function"+PPa("x")+"{norm"+PaO()+"matrix"+PaO()+"x,nrow=1),"+Dqq("2")+")}");
  println(SCEOUTPUT,"");
  forall(COM0thlist,
    if(indexof(#,"Texcom")==0, //17.09.22
      println(SCEOUTPUT,RSform(#));
    ,
      println(SCEOUTPUT,#);
    );
  );
  println(SCEOUTPUT,
     "Setwindow(c"+PaO()+XMIN+","+XMAX+"), c"+PaO()+YMIN+","+YMAX+"))");
  forall(Plist,
    println(SCEOUTPUT,#);
  );
  VLIST=select(VLIST,substring(#_1,0,1)!="["); //181107
  forall(VLIST, 
    tmp=#_1;
    tmp1=#_2;
    if(!isstring(tmp1), 
      if(islist(tmp1),
        tmp2="[";
        forall(tmp1,
          tmp2=tmp2+Textformat(#,10)+",";
        );
        tmp1=substring(tmp2,0,length(tmp2)-1)+"]";
      ,
        tmp1=format(tmp1,10);
      );
    );
    tmp1=RSform(tmp1);
    print(SCEOUTPUT,tmp+"="+tmp1+";"); //17.09.22
    println(SCEOUTPUT,"Assignadd"+PaO()+"'"+tmp+"',"+tmp+")");
  );
 forall(FUNLIST,
    println(SCEOUTPUT,#);
  );
  forall(GLIST, //no ketjs on
    println(SCEOUTPUT,RSform(#));
  ); //no ketjs off
  tmp=text(Pnamelist);
  tmp=replace(tmp,"[","list"+PaO());
  Pnamelist=replace(tmp,"]",")");
  println(SCEOUTPUT,"PtL="+Pnamelist);
  tmp=select(GCLIST,#_2==-1);
  GrL=apply(tmp,#_1);
  tmp=text(GrL);
  tmp=replace(tmp,"[","list"+PaO());
  tmp=replace(tmp,"]",")");
  println(SCEOUTPUT,"GrL="+tmp);
  tmp1="";
  if(length(tmp1)>0,
    tmp1="WriteOutData"+PaO()+"Fnameout"+tmp1+");";
    println(SCEOUTPUT,tmp1);
  );
  forall(COM1stlist,
    if(indexof(#,"Texcom")==0, //17.09.22
      println(SCEOUTPUT,RSform(#));
    ,
      println(SCEOUTPUT,#);
    );
  );
  println(SCEOUTPUT,"");
  println(SCEOUTPUT,"# Windisp"+PPa("GrL"));
  println(SCEOUTPUT,"");
  println(SCEOUTPUT,"if"+PaO()+"1==1){");
  println(SCEOUTPUT,"");
  tmp1=replace(Dirwork,"\","/"); //180408to
  if((iswindows())&(indexof(tmp1,"Users")>0),
    println(SCEOUTPUT,"Path=paste"+PaO()+"Path,"+Dqq("/"+Fnametex)+",sep='')");
    tmp="Openfile(Path,'"+ULEN+"'";
  ,
    tmp="Openfile('"+tmp1+"/"+Fnametex+"','"+ULEN+"'";
  );
  tmp=tmp+",'Cdy="+Cindyname()+".cdy"; //180404
  tmp=replace(tmp,"\","\\");
  println(SCEOUTPUT,tmp+"')");
  forall(COM2ndlistb, //180613from
    if(indexof(#,"Texcom")==0, 
      println(SCEOUTPUT,RSform(#));
    ,
      println(SCEOUTPUT,#);
    );
  );//180613to
  forall(COM2ndlist,cmd,
    tmp=substring(cmd,0,4);
    if(contains(["Lett","Expr"],tmp), //180721from
      tmp1=Indexall(cmd,Dq);
      tmp2=length(tmp1)/4;
      str=""; ns=0;
      forall(tmp2,
        spos=tmp1_(4*#-1); epos=tmp1_(4*#);
        str=str+RSform(substring(cmd,ns,spos-1));
        str=str+substring(cmd,spos-1,epos);
        ns=epos;
      );
      str=str+substring(cmd,ns,length(cmd));
      println(SCEOUTPUT,str);
    ,
      if(indexof(cmd,"Texcom")==0, 
        println(SCEOUTPUT,RSform(cmd));
      ,
        println(SCEOUTPUT,cmd);
      );
    ); //180721to
  );
  if(length(GrL)>0,
    println(SCEOUTPUT,"  Drwline"+PPa("GrL"));
  );
 // println(SCEOUTPUT,"Closefile"+PaO()+"'"+ADDAXES+"')"); //181224(2line)
  println(SCEOUTPUT,"Closefile"+PaO()+""+Dqq("0")+")");
  println(SCEOUTPUT,"");
  println(SCEOUTPUT,"}");
  if(shchoice=="sh",
    println(SCEOUTPUT,"");
    println(SCEOUTPUT,"quit"+PPa(""));
  ,
    println(SCEOUTPUT,"");
    println(SCEOUTPUT,"#quit"+PPa(""));
  );
  closefile(SCEOUTPUT);
  if(iswindows(), //180513from
    SCEOUTPUT = openfile("execsrc.r");//180514
    tmp1=replace(Dirwork,"\","/");
    if(indexof(tmp1,"Users")>0,
      tmp=Indexall(tmp1,"/");
      tmp2=substring(tmp1,tmp_3-1,length(tmp1));
      tmp1=substring(tmp1,0,tmp_3-1);
      println(SCEOUTPUT,"Drv=shell"+PaO()+"'echo %HOMEDRIVE%',intern=TRUE)");
      println(SCEOUTPUT,"Drv=Drv[length"+PaO()+"Drv)]");
      println(SCEOUTPUT,"Hpath=shell"+PaO()+"'echo %HOMEPATH%',intern=TRUE)");
      println(SCEOUTPUT,"Hpath=Hpath[length"+PaO()+"Hpath)]");
      println(SCEOUTPUT,"Rest="+Dqq(tmp2));
      println(SCEOUTPUT,"Path=paste"+PaO()+"Drv,Hpath,Rest,sep='')");
      println(SCEOUTPUT,"setwd"+PaO()+"Path)"); 
      println(SCEOUTPUT,"source"+PaO()+"'"+filename+"',encoding='UTF-8')");
    );
    closefile(SCEOUTPUT);
  ); //180513to
);
////%WritetoRS end////

////%Readoutdata start////
Readoutdata():=Readoutdata(Fnameout);
Readoutdata(filename):=Readoutdata("",filename);  //16.03.07
Readoutdata(Arg1,Arg2):=( //181030from
  if(islist(Arg2),
    Readoutdata("",Arg1,Arg2);
  ,
    Readoutdata(Arg1,Arg2,[]);
  );
); //181030to
Readoutdata(pathorg,filenameorg,optionsorg):=(
//help:Readoutdata();
//help:Readoutdata("file.txt");
//help:Readoutdata("/datafolder","file.txt");
//help:Readoutdata(options=["Msg=y(n)","R=n(y)"]);
  regional(options,path,filename,varname,varL,ptL,pts,tmp,tmp1,tmp2,tmp3,tmp4,
     nmbr,cmdall,cmd,outdt,goutdt,eqL,msg,Rflg);
  options=optionsorg;
  tmp=Divoptions(options); //181024from
  msg="Y";
  Rflg="N"; //211228
  //msg="N"; //only ketjs
  eqL=tmp_5;
  forall(eqL,
    tmp=Strsplit(#,"=");
    tmp1=substring(tmp_1,0,1); tmp1=Toupper(tmp1);
    tmp2=substring(tmp_2,0,1); tmp2=Toupper(tmp2);
    if(tmp1=="M",
      msg=tmp2;;
      options=remove(options,[#]); //181030
    );
    if(tmp1=="R",
      Rflg=tmp2; //211228
      options=remove(options,[#]); //181030
    );
  ); //181024to
  filename=filenameorg;
  if(indexof(filename,".")==0,filename=filename+".txt");
  path=pathorg;   //16.03.07 from
  if(length(path)>0,
    if(indexof(path,"\")>0,tmp1="\",tmp1="/");
    tmp=substring(path,length(path)-1,length(path));
    if(tmp!=tmp1,path=path+tmp1);
    tmp=Readlines(path,filename); //200514
  ,
    tmp=Readlines(filename); //200514
  );
  cmdall=apply(tmp,replace(#,"//",""));
  varname=cmdall_1; 
  cmdall=cmdall_(2..length(cmdall)); 
  outdt=[];
  varL=[varname];
  ptL=[];
  forall(cmdall,cmd, //200514
    if(length(cmd)>0,
      if(cmd=="start" % cmd=="end" % substring(cmd,0,1)=="[",
        if(cmd=="start", 
          pts=[];
        );
        if(cmd=="end",
          ptL=append(ptL,pts);
        );
        if(substring(cmd,0,1)=="[",
          tmp1=parse(cmd);
          if(length(tmp1_1)==2,
            tmp1=apply(tmp1,Pcrd(#));
          );
          pts=concat(pts,tmp1);
        );
      ,
        if(length(ptL)>0,
          if(length(ptL)==1,
            ptL=ptL_1;
            tmp=apply(ptL,Textformat(#,10));
          ,
            tmp="[";
            forall(ptL,tmp1,
              tmp=tmp+apply(tmp1,Textformat(#,10))+",";
            );
            tmp=substring(tmp,0,length(tmp)-1)+"]";
          );
        ,
          tmp="[]";
        );
        parse(varname+"="+tmp+";"); //190415
        outdt=append(outdt,ptL);
        ptL=[];
        varname=cmd;
        varL=append(varL,varname);
      );
    );
  );
  if(length(ptL)>0,
    if(length(ptL)==1,
      ptL=ptL_1;
      tmp=apply(ptL,Textformat(#,10));
    ,
      tmp="[";
      forall(ptL,tmp1,
        tmp=tmp+apply(tmp1,Textformat(#,10))+",";
      );
      tmp=substring(tmp,0,length(tmp)-1)+"]";
    );
  ,
    tmp="[]";
  );
  parse(varname+"="+tmp+";"); //190415
  outdt=append(outdt,ptL);
  if(path=="",tmp=filename,tmp=path+filename); //16.03.07
  GOUTLIST=append(GOUTLIST,[tmp,varL]); // 200914recoverd
  if(length(path)>0, // 16.03.09
    setdirectory(Dirwork); // 16.03.07
  );
  if(msg=="Y", //200624from
    print("readoutdata from "+tmp+" : ");
    println(varL);
  );  //200624to
  if(Rflg=="Y", //200514from, //211228
    GLIST=append(GLIST,"Tmpout=ReadOutData("+Dqq(filename)+")");
  ); //200514to
  varL;
);
////%Readoutdata end////

////%Writeoutdata start////
Writeoutdata(filename,ptlist):=Writeoutdata(filename,ptlist,[]); //211226
Writeoutdata(filename,ptlist,options):=(//211226
//help:Writeoutdata("file.txt",["g1",gr1,"sg",sgAB]);
//help:Writeoutdata("file.txt",["g1",gr1,"sg",sgAB],["Msg=n"]);
  regional(nn,Gname,Gdata,Str,Gstr,Gj,Pt,Flg,
      msg,tmp,tmp1,tmp2,loopend);
  msg="Y"; //211226from
  forall(options, 
    tmp=Strsplit(#,"=");
    tmp1=substring(tmp_1,0,1); tmp1=Toupper(tmp1);
    tmp2=substring(tmp_2,0,1); tmp2=Toupper(tmp2);
    if(tmp1=="M",
      msg=tmp2;;
      options=remove(options,[#]); //181030
    );
  ); //211226to
  Flg=0;
  if(isstring(ptlist_(length(ptlist))),
    Flg=1;
  );
  SCEOUTPUT = openfile(filename);
  if(Flg==0,
    loopend=length(ptlist)/2;
  ,
    loopend=length(ptlist);
  );
  Gstr="[";
  forall(1..loopend,nn,
    if(Flg==0,
      Gname=ptlist_(2*nn-1);
    ,
      Gname=ptlist_nn;
    );
    Gstr=Gstr+Gname+",";
    println(SCEOUTPUT,Gname+"//");
    if(Flg==0,
      Gdata=ptlist_(2*nn);
    ,
      Gdata=parse(Gname);
    );
    Gdata=Flattenlist(Gdata);
    if(Measuredepth(Gdata)==1,Gdata=[Gdata]);
    forall(Gdata,Gj,
      println(SCEOUTPUT,"start//");
      Str="";
      forall(Gj,Pt,
        if(length(Str)>0,
          Str=Str+","
        );
        Str=Str+"["+format(Pt_1,10)+",";
        Str=Str+format(Pt_2,10);
        if(length(Pt)<3,
          Str=Str+"]";
        ,
          Str=Str+","+format(Pt_3,10)+"]";
        );
        if(length(Str)>80,
          println(SCEOUTPUT,"["+Str+"]//");
          Str="";
        );
      );
      if(length(Str)>0,
        println(SCEOUTPUT,"["+Str+"]//");
      );
      if((nn==loopend) & (Gj==Gdata_(length(Gdata))),  
        println(SCEOUTPUT,"end////");
      ,
        println(SCEOUTPUT,"end//");
      );
    );
  );
  closefile(SCEOUTPUT);
  Gstr=substring(Gstr,0,length(Gstr)-1)+"]";
  if(Msg=="Y",
    println("writeoutdata "+filename+":"+Gstr);
  );
);
////%Writeoutdata end////

////%Makeshell start////
Makeshell():=(
  if(length(Texmain)>0,
    Texparent=Texmain;
  );
  if(length(Texparent)>0,
    Makeshell(Texparent);
    if(length(FigPdfList)>0,
      SCEOUTPUT=openfile(Texparent+".tex");
      forall(FigPdfList,println(SCEOUTPUT,#));
      closefile(SCEOUTPUT);
    );
  ,
    Makeshell(Fhead+"main");
  );
);
Makeshell(texmainfile):=Makeshell(texmainfile,"rtv");
Makeshell(texmainfile,flow):=(
  regional(parent,tmp,tmp1,tmp2,tmp3,flg,tex,path,shnm);
  parent=Dirwork+Shellparent; // 16.05.29
  kc():=(
    println("kc : "+kc(Dirwork+Shellparent,Mackc+Dirlib,Fnametex)); // 16.06.04,06.07
  );
  tmp1="";
//  tmp2=parent;
  flg=0;
  forall(reverse(1..length(parent)),
    if(flg==0,
      tmp=substring(parent,#-1,#);
      if(tmp=="/" % tmp=="\",  // 14.01.15
        tmp1=substring(parent,0,#-1);
        tmp2=substring(parent,#,length(parent));
        flg=1;
      );
    );
  );
  if(length(tmp1)>0,
    setdirectory(tmp1);
  );
  SCEOUTPUT = openfile(tmp2);
  println(SCEOUTPUT,"#!/bin/sh");
  println(SCEOUTPUT,"cd "+Dqq(Dirwork)); // 15.07.16
  tmp1=" "+Dqq(Fhead)+" "+Dqq(texmainfile); // 15.12.11 //190415from
  tmp=Indexall(PathT,"/"); 
  flg=length(tmp);
  if(flg>0,
    tmp=tmp_(length(tmp));
    tex=substring(PathT,tmp,length(PathT));
    path=substring(PathT,0,tmp-1);
  ); //190415to
  if(flg==0,  // 17.10.13[Norbert]
    tex=PathT;
    path="";
  ); 
  if(indexof(flow,"r")>0,
    tmp=Dqq(PathR)+" --vanilla --slave < "+Dqq(Fhead+".r"); //190414
     // 17.09.14
    println(SCEOUTPUT,tmp);
  );
  if(tex=="latex" % tex=="platex" % tex=="uplatex", //17.08.13 
    tmp=Dqq(PathT)+" "+Dqq(texmainfile+".tex"); //190415
    println(SCEOUTPUT,tmp); 
    if(indexof(flow,"tt")>0,println(SCEOUTPUT,tmp)); //17.10.14
    tmp=replace(Dqq(PathT),tex,"dvipdfmx")+" "+Dqq(texmainfile+".dvi"); //190415
    println(SCEOUTPUT,tmp); 
    tmp="rm "+Dqq(texmainfile+".dvi"); //190414
    println(SCEOUTPUT,tmp);
  );
  if(tex=="xelatex", 
    tmp="export PATH="+path+":${PATH}";
    println(SCEOUTPUT,tmp); 
    tmp="xelatex"+" "+Dqq(texmainfile+".tex"); //190414
    println(SCEOUTPUT,tmp); 
    if(indexof(flow,"tt")>0,println(SCEOUTPUT,tmp)); //17.10.14
    tmp="rm "+Dqq(texmainfile+".dvi"); //190414
    println(SCEOUTPUT,tmp);
  );
  if(tex=="pdflatex" % tex=="pdftex",//16.11.22from 
    tmp=Dqq(PathT)+" "+Dqq(texmainfile+".tex"); //190414
    println(SCEOUTPUT,tmp); 
    if(indexof(flow,"tt")>0,println(SCEOUTPUT,tmp)); //17.10.14
  );//16.11.22until
  if(tex=="lualatex",//16.12.16
    tmp=Dqq(PathT)+" "+Dqq(texmainfile+".tex"); //190414
    println(SCEOUTPUT,tmp); 
    if(indexof(flow,"tt")>0,println(SCEOUTPUT,tmp)); //17.10.14
  );//16.12.16
  if(!isstring(Pathpdf),
    tmp="preview";
  ,
    tmp=Pathpdf;
  );
  if(tmp=="preview" % tmp=="skim", // 16.09.09from,16.10.20
   tmp="open -a "+Dqq(tmp)+" "+Dqq(texmainfile+".pdf"); //190414
  ,
    tmp=Dqq(tmp)+" "+Dqq(texmainfile+".pdf"); //190414
  );// 16.09.09until
  println(SCEOUTPUT,tmp); // 16.07.21until
  println(SCEOUTPUT,"exit 0");
  closefile(SCEOUTPUT);
  setdirectory(Dirwork);
);
////%Makeshell end////

////%Convsjiswin start////
Convsjiswin(dir,fname,ext):=( //180401
  regional(ctr,flg,mx,tmp);
  mx=200;
  ctr=0;flg=0;
  nkfwin(dir,fname,ext);
  while((!isexists(dir,fname+".out"))&(ctr<mx),
    wait(100);ctr=ctr+1;
  );
  if(ctr==mx,flg=1);
  if(flg==0,
    wait(100);ctr=0;
    nkfcpdel(dir,fname,ext);
    while((isexists(dir,fname+".out"))&(ctr<mx),
      wait(100);ctr=ctr+1;
    );
    if(ctr==mx,flg=2);
  );
  tmp=dir+pathsep()+fname+"."+ext;
  if(flg==0,
    tmp=
    println(tmp+" converted");
  ,
    println(tmp+" not converted "+text(flg));
  );
);
////%Convsjiswin end////

////%Makebat start////
Makebat():=(
  if(length(Texmain)>0,
    Texparent=Texmain;
  );
  if(length(Texparent)>0,
    Makebat(Texparent);
    if(length(FigPdfList)>0,
      SCEOUTPUT=openfile(Texparent+".tex");
      forall(FigPdfList,println(SCEOUTPUT,#));
      closefile(SCEOUTPUT);
    );
  ,
    Makebat(Fhead+"main");
  );
);
Makebat(texmainfile):=Makebat(texmainfile,"rtv");
Makebat(texmainfile,flow):=(
  regional(drive,fname,tmp,tmp1,tmp2,tmp3,flg,tex,path,batnm);
  drive="C:";
  fname=Dirwork+Batparent;
  kc():=(
    println("kc : "+kc(Dirwork+Batparent,Dirlib,Fnametex)); // 16.06.04
  );
  tmp=indexof(fname,":");
  if(tmp>0,
    drive=substring(fname,0,tmp);
    fname=substring(fname,tmp,length(fname));
  );
  tmp1="";
  tmp2=fname;
  flg=0;
  forall(reverse(1..length(fname)),
    if(flg==0,
      tmp=substring(fname,#-1,#);
      if(tmp=="/" % tmp=="\" % tmp=="\",  // 14.01.15
        tmp1=substring(fname,0,#-1);
        tmp2=substring(fname,#,length(fname));
        flg=1;
      );
    );
  );
  if(length(tmp1)>0,
    setdirectory(drive+tmp1);
  );
  SCEOUTPUT = openfile(tmp2);
  fname=replace(Dirwork,"/","\");
  tmp=indexof(fname,":");
  if(tmp>0,
    drive=substring(Dirwork,0,tmp);
    fname=substring(Dirwork,tmp,length(Dirwork));
    println(SCEOUTPUT,drive);
  );
  tmp=Dirwork;//180408form
  tmp1=indexof(fname,"Users");//180409from
  tmp2=""; //210312from
  if(length(Homehead)>0,
    tmp2=indexof(fname,Homehead);
  ); //210312to
  if((tmp1>0)%(tmp2>0),
    if(tmp1>0,
      fname=substring(fname,tmp1+length("Users")-1,length(fname));
    ,
      fname=substring(fname,tmp2+length(Homehead)-1,length(fname));
    );
    tmp=Indexall(fname,"\");//180403from
    fname=substring(fname,tmp_2,length(fname));
    fname="%HOMEPATH%\"+fname;
  );//180403to
  println(SCEOUTPUT,"cd "+Dqq(fname));//180409to //190414
  tmp1=Indexall(PathT,"/");  //190415from
  tmp2=Indexall(PathT,"\");
  tmp=concat(tmp1,tmp2);
  flg=length(tmp);
  if(flg>0,
    tmp=tmp_(length(tmp));
    tex=substring(PathT,tmp,length(PathT));
    path=substring(PathT,0,tmp-1);
  ); //190415to
  if(flg==0,  // 17.10.13[Norbert]
    tex=PathT;
    path="";
  );
  if(indexof(flow,"r")>0,
    if(indexof(Dirwork,"Users")>0, //180917from
      tmp=Dqq(PathR+"\R")+" --vanilla --slave < execsrc.r";//180514
    ,
      tmp=Dqq(PathR+"\R")+" --vanilla --slave < "+Dqq(Fhead+".r");  //190414
    );  //180917to
    println(SCEOUTPUT,tmp);
  );
  if(tex=="latex" % tex=="platex" % tex=="uplatex", //17.08.13 
    tmp=Dqq(PathT)+" "+Dqq(texmainfile+".tex"); //190414
    println(SCEOUTPUT,tmp); 
    if(indexof(flow,"tt")>0,println(SCEOUTPUT,tmp)); //17.10.14
    tmp=replace(Dqq(PathT),tex,"dvipdfmx")+" "+Dqq(texmainfile+".dvi"); //190414
    println(SCEOUTPUT,tmp); 
    tmp="del "+Dqq(texmainfile+".dvi"); //190414
    println(SCEOUTPUT,tmp);
  );
  if(tex=="xelatex", 
    tmp="set Path = %Path%;"+Dqq(path); //190414
    println(SCEOUTPUT,tmp); 
    if(indexof(flow,"tt")>0,println(SCEOUTPUT,tmp)); //17.10.14
    tmp="xelatex"+" "+texmainfile+".tex";
    println(SCEOUTPUT,tmp); 
    tmp="del "+Dqq(texmainfile+".dvi");
    println(SCEOUTPUT,tmp);
  );
  if(tex=="pdflatex" % tex=="pdftex",//16.11.22from 
    tmp=Dqq(PathT)+" "+Dqq(texmainfile+".tex");
    println(SCEOUTPUT,tmp); 
    if(indexof(flow,"tt")>0,println(SCEOUTPUT,tmp)); //17.10.14
  );//16.11.22until
  if(tex=="lualatex",//16.12.16
    tmp=Dqq(PathT)+" "+Dqq(texmainfile+".tex"); //190414
    println(SCEOUTPUT,tmp); 
    if(indexof(flow,"tt")>0,println(SCEOUTPUT,tmp)); //17.10.14
  );//16.12.16
  if(!isstring(Pathpdf),
    tmp=indexof(PathS,"\scilab");// 15.12.12
    tmp=substring(PathS,0,tmp-1)+"\SumatraPDF\SumatraPDF.exe";
  ,
    tmp=Pathpdf;
  );
  tmp=Dqq(tmp)+" "+Dqq(texmainfile+".pdf"); //190414
  println(SCEOUTPUT,tmp);
  println(SCEOUTPUT,"exit 0");
  closefile(SCEOUTPUT);
  if(indexof(Dirwork,":")==0,  // 14.01.15
    drive="C:";
  ,
    drive="";
  );
  setdirectory(drive+Dirwork);
);
////%Makebat end////

////%Addpackage start////
Addpackage(packorg):=(
//help:Addpackage("bm");
//help:Addpackage(["bm","enumerate"]);
//help:Addpackage(["bm","[c]{somepackage}"]);
  regional(packL,tmp);
  packL=packorg; //17.06.25from
  if(!islist(packL),packL=[packL]);
  packL=apply(packL,replace(#,"\","/"));
  forall(1..(length(packL)),
    tmp=packL_#;
    if(substring(tmp,0,11)=="ketpicstyle",
      tmp=replace(Dirhead+"/"+tmp,"\","/");
    );
    if(indexof(tmp,"[")==0,
      packL_#="{"+tmp+"}";
    );
  );
  forall(packL, //20070717from
    if(!contains(ADDPACK,#),
      ADDPACK=append(ADDPACK,#); 
    );
  ); //200717to
);
////%Addpackage end////

////%Usegraphics start//// //220229 major change
Usegraphics(gpack):=(
//help:Usegraphics("tpic/pict2e/tikz");
  regional(tmp);
  GPACK=gpack;
  tmp=gpack; 
  if((indexof(PathT,"pdflatex")>0)%(indexof(PathT,"lualatex")>0),
    if(tmp=="tpic",tmp="pict2e");
  );
  GPACKL=["{"+tmp+"}"];
  tmp=Toupper(GPACKL_1);
  if(tmp=="{TPIC}",
    GPACKL=["{ketpic}","{ketlayer}"];
  );
  if(tmp=="{PICT2E}",
    if((indexof(PathT,"pdflatex")==0)&(indexof(PathT,"lualatex")==0),
      GPACKL_1="[dvipdfmx]{pict2e}";
    );
    GPACKL=concat(GPACKL,["{ketpic2e}","{ketlayer2e}"]);
  );
  if(tmp=="{TIKZ}",
    GPACKL=concat(GPACKL,["{pgf}","{tikz}"]);
    if((indexof(PathT,"pdflatex")==0)&(indexof(PathT,"lualatex")==0),
      GPACKL=append(GPACKL,"[dvipdfmx]{pict2e}");
    ,
      GPACKL=append(GPACKL,"{pict2e}");
    ); 
    GPACKL=concat(GPACKL,["{ketpic2e}","{ketlayer2e}"]);
  );
);
////%Usegraphics end////

////%Viewtex start////
Viewtex():=(
  regional(texfile,tmp,tmp1,sep);
  texfile=Fhead+"main";
  SCEOUTPUT=openfile(texfile+".tex");
  tmp="\documentclass{article}";
  if(indexof(GPACKL_1,"tikz")>0, //190324from //190615
    if(indexof(PathT,"pdflatex")+indexof(PathT,"lualatex")==0,
      tmp="\documentclass[dvipdfmx]{article}";
    ); //190324to
  );
  if(indexof(PathT,"platex")>0,
    tmp=replace(tmp,"article","jarticle");
    if(indexof(PathT,"uplatex")>0, //17.08.13from
      tmp=replace(tmp,"jarticle","ujarticle");
    );//17.08.13to
  ); 
  println(SCEOUTPUT,tmp);
  forall(GPACKL,
    println(SCEOUTPUT,"\usepackage"+#);
  );
  println(SCEOUTPUT,"\usepackage{amsmath,amssymb}");
  println(SCEOUTPUT,"\usepackage{graphicx}");
  println(SCEOUTPUT,"\usepackage{color}");
  forall(ADDPACK, // 16.05.16from
    println(SCEOUTPUT,"\usepackage"+#); //17.05.25
  );// 16.05.16until
  println(SCEOUTPUT,"");
  println(SCEOUTPUT,"\setmargin{20}{20}{20}{20}");
  println(SCEOUTPUT,"");
  println(SCEOUTPUT,"\begin{document}");
  println(SCEOUTPUT,"");
  println(SCEOUTPUT,"\verb|"+Fhead+"| by \ketcindy");// 16.01.12, 18, 16.04.08
  println(SCEOUTPUT,"\vspace{5mm}");
  println(SCEOUTPUT,"");
  println(SCEOUTPUT,"\input{"+Fhead+".tex}");
  println(SCEOUTPUT,"");
  println(SCEOUTPUT,"\end{document}");
  closefile(SCEOUTPUT);
  if(iswindows(),
     kc():=(
       println("kc : "+kc(Dirwork+Batparent,Dirlib,Fnametex)); // 16.06.04
    );
    Makebat(texfile);
  ,
    kc():=(
       println("kc : "+kc(Dirwork+Shellparent,Mackc+Dirlib,Fnametex)); // 16.06.04
    );
    Makeshell(texfile);
  );
  WritetoRS(2); //17.09.19
);
////%Viewtex end////

////%Viewparent start////
Viewparent():=( //17.04.13
  if(!isexists(Dirwork,Texparent+".tex"),
    if(isstring(Texparent),
      drawtext(mouse().xy,Texparent+".tex not exist",
        size->24,color->[1,0,0]);
    ,
      drawtext(mouse().xy,"Texparent not defined",
        size->24,color->[1,0,0]);
    );
  ,
    if(iswindows(),
      Makebat();
    ,
      Makeshell();
    );
    WritetoRS(2); //17.09.29
    kc();
  );
);
////%Viewparent end////

////%Figpdf start////
Figpdf():=Figpdf(Texparent,[]);
Figpdf(Arg1):=(
  if(isstring(Arg1),
    Figpdf(Arg1,[]);
  ,
    Figpdf(Texparent,Arg1);
  );
);
Figpdf(fnameorg,optionorg):=(
//help:Figpdf();
//help:Figpdf([10,,10,,[0,2] ]);(margin(4),move)
//help:Figpdf([[0,0]]);(move)
//help:Figpdf(options=[5,5,5,5,[0,0]]]);
  regional(options,fname,mar,pos,dp,sc,tmp,tmp1,tmp2,sep);
  fname=fnameorg;
  if(indexof(fnameorg,".")==0,
    fname=fnameorg+".tex";
  );
  tmp=apply(optionorg,if(isstring(#),parse("["+#+"]"),#)); // 16.04.07
  tmp=select(tmp,#!=[]);
  options=optionorg;//16.11.08from
  dp=[0,-3];
  tmp=select(options,islist(#));
  if(length(tmp)>0,
    dp=tmp_1;
    options=remove(options,tmp);
  );
  tmp=4-length(options);
  tmp1=apply(1..tmp,5);
  mar=concat(options,tmp1);
  mar=apply(mar,if(length(#)==0,5,#));//16.11.08until
  pos=[mar_1+dp_1,mar_3+dp_2];
  sc=10;
  tmp=indexof(ULEN,"cm");
  if(tmp>0,
    tmp1=Removespace(substring(ULEN,0,tmp-1));
    sc=parse(tmp1)*10;
  );
  tmp=indexof(ULEN,"mm");
  if(tmp>0,
    tmp1=Removespace(substring(ULEN,0,tmp-1));
    sc=parse(tmp1);
  );
  tmp="\documentclass{article}";
  if(indexof(GPACKL_1,"tikz")>0, //190324from //190615
    if(indexof(PathT,"pdflatex")+indexof(PathT,"lualatex")==0,
      tmp="\documentclass[dvipdfmx]{article}";
    ); //190324to
  );
  if(indexof(PathT,"platex")>0,
    tmp=replace(tmp,"article","jarticle");
    if(indexof(PathT,"uplatex")>0, //170813from
      tmp=replace(tmp,"jarticle","ujarticle");
    );//170813to
  ); 
  FigPdfList=append(FigPdfList,tmp); // 16.06.09until
  tmp1="\special{papersize=W mm,H mm}";
  tmp=(XMAX-XMIN)*sc+(mar_1+mar_2);
  tmp1=replace(tmp1,"W",text(tmp));
  tmp=SCALEY*(YMAX-YMIN)*sc+(mar_3+mar_4); //190412
  tmp1=replace(tmp1,"H",text(tmp));
  FigPdfList=append(FigPdfList,tmp1);
  forall(GPACKL, //220227from
    tmp1="\usepackage"+#; //17.07.10
    FigPdfList=append(FigPdfList,tmp1); 
  ); //220227to
  FigPdfList=append(FigPdfList,
    "\usepackage{amsmath,amssymb}");
  FigPdfList=append(FigPdfList,
    "\usepackage{graphicx,color}");
  forall(ADDPACK, // 16.05.16from
    tmp1="\usepackage"+#; //17.07.10
    FigPdfList=append(FigPdfList,tmp1);  // 16.09.05until
  );
  FigPdfList=append(FigPdfList,"");
  FigPdfList=append(FigPdfList,
    "\setmargin{0}{0}{0}{0}");
  FigPdfList=append(FigPdfList,"");
  FigPdfList=append(FigPdfList,"\begin{document}");
  FigPdfList=append(FigPdfList,"");
  FigPdfList=append(FigPdfList,
    "\begin{layer}{50}{0}");
  tmp1="\putnotese{X}{Y}{\input{";
  tmp1=replace(tmp1,"X",text(pos_1));
  tmp1=replace(tmp1,"Y",text(pos_2));
  FigPdfList=append(FigPdfList,tmp1+Fhead+".tex}}");
  FigPdfList=append(FigPdfList,"");
  FigPdfList=append(FigPdfList,"\end{layer}");
  FigPdfList=append(FigPdfList,"");
  FigPdfList=append(FigPdfList,"\end{document}");
  if(fnameorg!=Texparent,
    SCEOUTPUT=openfile(fname);
    forall(FigPdfList,println(SCEOUTPUT,#));
    closefile(SCEOUTPUT);
  );
  FigPdfList;
);
////%Figpdf end////

////%Slidework start////
Slidework():=Slidework(Dirwork); // 16.06.10
Slidework(dirorg):=(
//help:Slidework(directory);
  regional(dir,tmp);  // 16.06.25
  dir=replace(dirorg,unicode("000a"),""); // 16.06.25
  dir=replace(dir,"/",pathsep());//17.11.20from
  dir=replace(dir,"\",pathsep());
  tmp=length(dir);
  if(substring(dir,tmp-1,tmp)==pathsep(),
    dir=substring(dir,0,tmp-1);
  );//17.11.20until
  if(isexists(dir,""), // 16.12.20
    Changework(dir);
    println(makedir(dir,"fig"));//17.11.23
    tmp=dir+pathsep()+"fig";  //17.04.16from
    Changework(tmp);// 17.02.19until
  ,
    println(dir+ " not exists");
  );
);
////%Slidework end////

////%Setslidemargin start////
Setslidemargin(marginlist):=( // 180908
//help:Setslidemargin([+5,-10]);
  SlideMargin=marginlist;
);
////%Setslidemargin end////

////%Setslidepage start////
Setslidepage():=( // 17.03.05
  regional(tmp1,tmp2,tmp3);
  tmp1=["letterc","boxc","framec","shadowc","xpos","size"];
  tmp2=apply([1,2,4,5,7,8],SlideColorList_#);
  tmp3=apply(1..(length(tmp1)),tmp1_#+"="+tmp2_#);
  println(tmp3);
);
Setslidepage(list):=( // 16.12.22
//help:Setslidepage([letterc,boxc,framec,shadowc,xpos,size]);
  regional(numlist,tmp,tmp1,letterc,boxc,shadowc,mboxc);
  letterc=[0.98,0.13,0,0.43]; boxc=[0,0.32,0.52,0];
  shadowc=[0,0,0,0.5]; mboxc="yellow";
  if(!islist(SlideColorList),
    SlideColorList=[letterc,boxc,boxc,boxc,shadowc,shadowc,6,1.3,
                  letterc,mboxc,mboxc,mboxc,62,2,letterc];
  );
  numlist=[1,2,4,5,7,8];
  forall(1..(length(list)),
    if(length(list_#)>0,
      tmp=numlist_#;
      SlideColorList_tmp=list_#;
    );
  );
  SlideColorList_3=SlideColorList_2;
  SlideColorList_6=SlideColorList_5;
);
////%Setslidepage end////

////%Setslidemain start////
Setslidemain():=( // 17.03.05
  regional(tmp1,tmp2,tmp3);
  tmp1=["letterc","boxc","framec","xpos","size"];
  tmp2=apply([9,10,12,13,14],SlideColorList_#);
  tmp3=apply(1..(length(tmp1)),tmp1_#+"="+tmp2_#);
  println(tmp3);
);
Setslidemain(list):=( // 16.12.22
//help:Setslidemain([letterc,boxc,framec,xpos,size]);
  regional(numlist,tmp,tmp1,letterc,boxc,shadowc,mboxc);
  letterc=[0.98,0.13,0,0.43]; boxc=[0,0.32,0.52,0];
  shadowc=[0,0,0,0.5]; mboxc="yellow";
  if(!islist(SlideColorList),
    SlideColorList=[letterc,boxc,boxc,boxc,shadowc,shadowc,6,1.3,
                  letterc,mboxc,mboxc,mboxc,62,2,letterc];
  );
  numlist=[9,10,12,13,14];
  forall(1..(length(list)),
    if(length(list_#)>0, //17.01.04
      tmp=numlist_#;
      SlideColorList_tmp=list_#;
    );
  );
  SlideColorList_11=SlideColorList_10;
);
////%Setslidemain end////

////%Setslidebody start////
Setslidebody():=( // 17.03.05
  regional(tmp1,tmp2,tmp3);
  tmp1=["letterc","style","thindense"];
  tmp2=[SlideColorList_(15),BodyStyle,ThinDense];
  tmp3=apply(1..(length(tmp1)),tmp1_#+"="+tmp2_#);
  println(tmp3);
);
Setslidebody(str):=(
  regional(clr,style,thin);
  if(isstring(str),
    Setslidebody(str,"\Large\bf\boldmath",0.1);
  ,
    if(length(str)==1,Setslidebody(str_1));
    if(length(str)==2,Setslidebody(str_1,str_2));
    if(length(str)==3,Setslidebody(str_1,str_2,str_3));
  );
);
Setslidebody(str,Arg):=( //17.01.08
  if(isstring(Arg),
    Setslidebody(str,Arg,0.1);
  ,
    Setslidebody(str,"\Large\bf\boldmath",Arg);
  );
);
Setslidebody(str1,str2,density):=( // 16.12.22,17.01.06,01.08
//help:Setslidebody(["black",,0]);
//help:Setslidebody(["blue","\Large\bf\boldmath",0.1]);
  regional(str,style,numlist,tmp,tmp1,letterc,boxc,shadowc,mboxc);
  if(indexof(str1,"\")==0, //210910from
    str=str1; style=str2;
  ,
    str=str2; style=str1;
  ); //210910from
  letterc=[0.98,0.13,0,0.43]; boxc=[0,0.32,0.52,0];
  shadowc=[0,0,0,0.5]; mboxc="yellow";
  if(!islist(SlideColorList),
    SlideColorList=[letterc,boxc,boxc,boxc,shadowc,shadowc,6,1.3,
                  letterc,mboxc,mboxc,mboxc,62,2,letterc];
  );
  if(length(str)>0,SlideColorList_(15)=str);
  if(length(style)>0,BodyStyle=style);
  ThinDense=density;//17.01.08
);
////%Setslidebody end////

////%Setslidehyper start////
Setslidehyper():=( 17.12.16from
  Setslidehyper(["cl=true,lc=blue,fc=blue",125,70,1]);
);
Setslidehyper(Arg):=(
  if(isstring(Arg),
    Setslidehyper(Arg,["cl=true,lc=blue,fc=blue",125,70,1]);
  ,
    Setslidehyper("",Arg);
  );
);
Setslidehyper(driverorg,options):=(
//help:Setslidehyper();
//help:Setslidehyper("dvipdfmx",["cl=true,lc=blue,fc=blue","Pos=[125,73]","Size=1"]);
  regional(driver,eqL,reL,stL,,str,tmp,tmp1,tmp2);
  driver=driverorg;
  if(length(driver)==0,
    if(indexof(PathT,"pdflatex")+indexof(PathT,"lualatex")==0,
      driver="dvipdfmx";
    );
  );
  tmp=Divoptions(options);
  eqL=tmp_5;
  reL=tmp_6;
  stL=tmp_7;
  tmp1=select(eqL,length(Indexall(#,"="))>1); //180813from
  eqL=remove(eqL,tmp1);
  stL=concat(stL,tmp1); //180813to
  if(length(stL)>0,
    str=stL_1;
  ,
    str="";
  );
  if(length(str)==0,
    str="cl=true,lc=blue,fc=blue";
  );
  if(length(driver)==0,
    tmp1="["+str+"]";
  ,
    tmp1="["+driver+","+str+"]";
  );
  tmp1=replace(tmp1,"cl=","colorlinks=");
  tmp1=replace(tmp1,"lc=","linkcolor=");
  tmp1=replace(tmp1,"fc=","filecolor=");
  tmp1=replace(tmp1,"uc=","urlcolor=");
  ADDPACK=select(ADDPACK,indexof(#,"hyperref")==0);
  Addpackage(tmp1+"{hyperref}");
  tmp=indexof(tmp1,"linkcolor=");//180813from
  tmp1=substring(tmp1,tmp-1,length(tmp1));
  tmp=indexof(tmp1,"=");
  tmp1=substring(tmp1,tmp,length(tmp1));
  tmp=indexof(tmp1,",");
  if(length(tmp)>0,
    tmp1=substring(tmp1,0,tmp-1);
  );//180813to
  LinkColor=tmp1; 
  LinkPosH=125;
  LinkPosV=73;//180524
  LinkSize=1;
  forall(eqL,
    tmp=Indexall(#,"=");//180524from
    if(length(tmp)==1,
      tmp1=Toupper(substring(#,0,1));
      tmp2=substring(#,tmp_1,length(#));
      tmp2=parse(tmp2);
      if(tmp1=="P",
        LinkPosH=tmp2_1;
        LinkPosV=tmp2_2;
      );
      if(tmp1=="S",
        LinkSize=max(tmp2,0.1);
      );
    );//180524to
  );
); //17.12.16to
////%Setslidehyper end////

////%Settitle start////
Settitle(cmdL):=Settitle("",cmdL,[]); // 180608from
Settitle(Arg1,Arg2):=(
  if(isstring(Arg1),
    Settitle(Arg1,Arg2,[]);
  ,
    Settitle("",Arg1,Arg2);
  );
); // 180608to
Settitle(titleold,cmdL,options):=(
//help:Settitle(cmdL);
//help:Settitle(name,cmdL);
//help:Settitle(options=["Title=slide0","Layery=0","Color=blue"]);
  regional(tmp,tmp1,tmp2,eqL,layery,color,size,font);
  TitleName="slide0"; //180330
  if(length(titleold)>0,TitleName=titleold);//180608
  layery="0";
  color="blue";
  size="\Large";
  font="\bf";
  eqL=options; //180602
  forall(eqL,
    tmp1=Toupper(substring(#,0,1));
    tmp=indexof(#,"=");
    tmp2=substring(#,tmp,length(#));
    if(tmp1=="L",
      layery=tmp2;
    );      
    if(tmp1=="C",
      color=tmp2;
    );      
    if(tmp1=="S",
      size=tmp2;
      if(substring(size,0,1)!="\",size="\"+size);
    );      
    if(tmp1=="F",
      font=tmp2;
      if(substring(font,0,1)!="\",font="\"+font);
   );
    if(tmp1=="T", //180330
      TitleName=tmp2;
   ); 
  );
  TitleCmdL=["{"+size+font];
  if(indexof(color,"[")>0,
    tmp=replace(color,"[","{");
    tmp=replace(tmp,"]","}");
    tmp1=Indexall(tmp,",");
    if(length(tmp1)>=3,
      tmp="\color[cmyk]"+tmp;
    ,
      tmp="\color[rgb]"+tmp;
    );
  ,
    tmp="\color{"+color+"}";
  );
  TitleCmdL=append(TitleCmdL,tmp);
  TitleCmdL=concat(TitleCmdL,["","\begin{layer}{120}{"+layery+"}"]);
  forall(1..(length(cmdL)),
    tmp=cmdL_#;
    if(length(tmp)>0,
      if(#==1,
        tmp="{\Huge \putnote"+tmp+"}"
      ,
        tmp="\putnote"+tmp;
      );
      TitleCmdL=append(TitleCmdL,tmp);
    );
  );
  TitleCmdL=concat(TitleCmdL,["\end{layer}","","}"]);
);
////%Settitle end////

////%Maketitle start////
Maketitle():=(
  if(!isstring(TitleName), //17.04.13from
    drawtext(mouse().xy,"Settitle not defined",
      size->24,color->[1,0,0]);
  , //17.04.13until
    Maketitle(TitleName);
  );
);
Maketitle(name):=(
//help:Maketitle();
  regional(texfile,texmain,tmp,tmp1,sep,txtfile);
  texfile=name;
  texmain=name+"main";
  SCEOUTPUT=openfile(texfile+".tex");
  forall(TitleCmdL,
    println(SCEOUTPUT,#);
  );
  closefile(SCEOUTPUT);  
  SCEOUTPUT=openfile(texmain+".tex");
  tmp="\documentclass[landscape,10pt]{article}";
  if(indexof(PathT,"platex")>0,
    tmp=replace(tmp,"article","jarticle");
    if(indexof(PathT,"uplatex")>0, //17.08.13from
      tmp=replace(tmp,"jarticle","ujarticle");
    );//17.08.13until
  ); 
  println(SCEOUTPUT,tmp);
  tmp="\special{papersize=\the\paperwidth,\the\paperheight}";
  println(SCEOUTPUT,tmp);
  tmp=replace(Dirhead,"\","/");//17.11.01from
  tmp=replace(tmp,"scripts","tex/latex");
  if(isexists(tmp,""),
    println(SCEOUTPUT,"\usepackage{ketpic,ketlayer,ketslide}");
  ,
    tmp=replace(Dirhead+"/ketpicstyle","\","/");
    println(SCEOUTPUT,"\usepackage{"+tmp+"/ketpic}");
    println(SCEOUTPUT,"\usepackage{"+tmp+"/ketlayer}");
    println(SCEOUTPUT,"\usepackage{"+tmp+"/ketslide}");
  );//17.11.01until
  println(SCEOUTPUT,"\usepackage{amsmath,amssymb}");
  println(SCEOUTPUT,"\usepackage{bm,enumerate}");
  if((indexof(PathT,"pdflatex")>0)%(indexof(PathT,"lualatex")>0),
    println(SCEOUTPUT,"\usepackage{graphicx}");
  ,
    println(SCEOUTPUT,"\usepackage[dvipdfmx]{graphicx}");
  );
  println(SCEOUTPUT,"\usepackage[usenames]{color}"); //190222
  forall(ADDPACK, 
      println(SCEOUTPUT,"\usepackage"+#); // 17.07.10
  );
  if(indexof(PathT,"platex")>0,tmp="\ketmarginJ",tmp="\ketmarginE"); 
  println(SCEOUTPUT,tmp);
  println(SCEOUTPUT,"\ketslideinit");
  println(SCEOUTPUT,"");
  println(SCEOUTPUT,"\begin{document}");
  println(SCEOUTPUT,"");
  println(SCEOUTPUT,"\input{"+texfile+".tex}");
  println(SCEOUTPUT,"");
  println(SCEOUTPUT,"\end{document}");
  closefile(SCEOUTPUT); 
  if(iswindows(),
    Makebat(texmain,"tv");
  ,
    Makeshell(texmain,"tv");
  );
  kc();
  txtfile=Cindyname()+".txt"; //180815from
  if(!isexists(Dircdy,txtfile),
    setdirectory(Dircdy);
    SCEOUTPUT=openfile(txtfile);
    println(SCEOUTPUT,"title::"+name+"//");
    println(SCEOUTPUT,"");
    println(SCEOUTPUT,"%%%%%%%%%%%%%%%%//");
    println(SCEOUTPUT,"main::"+PaO()+"title)//");
    println(SCEOUTPUT,"\slidepage[m]//");
    println(SCEOUTPUT,"");
    println(SCEOUTPUT,"%%%%%%%%%%%%%%%%//");
    println(SCEOUTPUT,"new::"+PaO()+"title)//");
    println(SCEOUTPUT,"%repeat=1,para//");
    println(SCEOUTPUT,"\slidepage//");
    println(SCEOUTPUT,"");
    println(SCEOUTPUT,"layer::{120}{0}//");
    println(SCEOUTPUT,"%%putnote::s{65}{5}:://");
    println(SCEOUTPUT,"end//");
    println(SCEOUTPUT,"");
    println(SCEOUTPUT,"itemize//");
    println(SCEOUTPUT,"item//");
    println(SCEOUTPUT,"end//");
    closefile(SCEOUTPUT);
    setdirectory(Dirwork);  //180815to
  );
);
////%Maketitle end////

////%Repeatsameslide start////
Repeatsameslide(repeatflg,sestr,addedL):=(
  regional(seL,flg1,ss,nn,nrep,tmp,tmp1,tmp2,tmp3,str,j,k);
  // global RepeatList, SCEOUTPUT, NonThinFlg
  nrep=length(RepeatList);
  flg1=0;
  forall(addedL,ss,
   if(repeatflg==0,
      if(substring(ss,0,1)!="%", //16.01.04
        println(SCEOUTPUT,ss);
      );//16.01.04
    ,
      forall(1..nrep,nn,
        if(sestr=="",
          RepeatList_nn=append(RepeatList_nn,ss);
        );
      );
      if(sestr=="",
        seL=[1];
      ,
        tmp1=substring(sestr,1,length(sestr)-1);
        tmp1=replace(tmp1,",-",".."+text(nrep));
        tmp1=replace(tmp1,"-,","1..");
        tmp1="["+tmp1+"]"; //17.01.03
        seL=flatten(parse(tmp1)); //17.01.03
      );
      if(contains(seL,1),
        if(substring(ss,0,1)!="%", //16.01.04
          println(SCEOUTPUT,ss);
        );
        seL=remove(seL,[1]);
        flg1=1;
      );
      forall(1..(length(seL)),nn,
        tmp=seL_nn;
        if(tmp<=length(RepeatList), //17.01.12from
          RepeatList_tmp=append( RepeatList_tmp,ss);
        ,
          println("   "+sestr+" : "+text(tmp)+" > "+text(length(RepeatList)));
        );
      );
      if(ThinFlg==1,//16.01.05from
        if(flg1==1,seL=append(seL,1));
        seL=remove(1..nrep,seL);
        str=ss; // 17.05.28from
        if(substring(str,0,16)=="\begin{minipage}",MiniFlg=1);//180526
        repeat(10,
          tmp1=Indexall(str,"{\color");
          if(length(tmp1)>0,
            tmp2=Indexall(str,"}");
            tmp=select(tmp2,tmp1_1<#);
            tmp=substring(str,tmp1_1,tmp_1);
            str=replace(str,tmp+" ","");
            str=replace(str,tmp,"");
          );
        );//17.05.28to
        if(contains(seL,1),
          if(substring(str,0,1)!="%", 
            if(NonThinFlg==0,
              if(!contains(["\begi","\end{"],substring(str,0,5)),//17.01.15
                if(MiniFlg==0, //180526from
                  println(SCEOUTPUT,"{\color[cmyk]{\thin,\thin,\thin,\thin}%");//180701
                  println(SCEOUTPUT,str);
                  println(SCEOUTPUT,"}%");
                ,
                  println(SCEOUTPUT,str);
                  if(indexof(str,"\end{minipage}")>0, //180526from
                    println(SCEOUTPUT,"}%");
                  ); 
                ); //180526to
              ,
                println(SCEOUTPUT,str);
                if(indexof(str,"\end{minipage}")>0, //180526from
                  println(SCEOUTPUT,"}%");
                  MiniFlg=0;
                ); 
              );
            );
            if(NonThinFlg==1,
              if(!contains(["\begi","\end{"],substring(str,0,5)),//17.01.15
                println(SCEOUTPUT,"{\color[cmyk]{\thin,\thin,\thin,\thin}%");//180701
                println(SCEOUTPUT,str);
              ,
                println(SCEOUTPUT,str);
                if(indexof(str,"\end{minipage}")>0, //180526from
                  println(SCEOUTPUT,"}%");
                  MiniFlg=0;
                ); 
              );
            );
            if(NonThinFlg==2,
              println(SCEOUTPUT,str);
              if(!contains(["\begi","\end{"],substring(str,0,5)),//17.01.15
                println(SCEOUTPUT,"}%");
              ,  //180526from
                if(indexof(str,"\end{minipage}")>0, 
                  println(SCEOUTPUT,"}%");
                  MiniFlg=0;
                ); //180526from
              );
            );
            seL=remove(seL,[1]);
          );
        );
        if(substring(ss,0,1)!="%", //16.01.04
          forall(1..(length(seL)),nn,
            if(substring(str,0,16)=="\begin{minipage}",MiniFlg=1);//180526
            tmp=seL_nn;
            if(NonThinFlg==0,
              if(!contains(["\begi","\end{"],substring(str,0,5)),//180526from
                if(MiniFlg==0, 
                  tmp1="{\color[cmyk]{\thin,\thin,\thin,\thin}%";//180701
                  tmp1=[tmp1,str,"}%"];
                ,
                  tmp1=[str];
                  if(indexof(str,"\end{minipage}")>0, //180526from
                    tmp1=append(tmp1,"}%");
                  );
                );
              ,
                tmp1=[str];
                if(indexof(str,"\end{minipage}")>0,
                  tmp1=append(tmp1,"}%");
                  MiniFlg=0;
                ); 
              );
            );
            if(NonThinFlg==1,
              if(!contains(["\begi","\end{"],substring(str,0,5)),//17.01.15
                tmp1="{\color[cmyk]{\thin,\thin,\thin,\thin}%";//180701
                tmp1=[tmp1,str];
              ,
                tmp1=[str];
                if(indexof(str,"\end{minipage}")>0,
                  tmp1=append(tmp1,"}%");
                  MiniFlg=0;
                ); 
              );
            );
            if(NonThinFlg==2,
              tmp1=[str];
              if(!contains(["\begi","\end{"],substring(str,0,5)),
                tmp1=append(tmp1,"}%");
              ,
                if(indexof(str,"\end{minipage}")>0, 
                  tmp1=append(tmp1,"}%");
                  MiniFlg=0;
                );
              );
            );
            RepeatList_tmp=concat( RepeatList_tmp,tmp1);
          );
        );
      );//16.01.05to
    );
  );//16.12.05to
);
////%Repeatsameslide end////

////%Presentation start////
Presentation(texfile):=Presentation(texfile,texfile);
Presentation(texfile,txtfile):=(
//help:Presentation(texfile,txtfile);
  regional(packL,file,flgL,flg,verbflg,slideL,ns,slideorgL,
     wall,sld,slidecmd,tmp,tmp0,tmp1,
     tmp2,tmp3,tmp4,tmp5,newoption,top,repeatflg,nrep,nrepprev,,repstr,
     sestr,npara,paradt,parafiles,hyperflg,paractr,
     letterc,boxc,shadowc,mboxc,sep);
  MiniFlg=0;//180526
  slidecmd=["\ketcletter","\ketcbox","\ketdbox","\ketcframe",
         "\ketcshadow","\ketdshadow","\slidetitlex","\slidetitlesize",
         "\mketcletter","\mketcbox","\mketdbox","\mketcframe",
         "\mslidetitlex","\mslidetitlesize"];
  if(!isstring(BodyStyle),//17.01.06
    BodyStyle="\Large\bf\boldmath";
  );
  repeatflg=0;
  RepeatList=[];
  paractr=0; //16.12.31
  if(indexof(texfile,".")==0,file=texfile+".tex",file=texfile);
  if(indexof(txtfile,".")==0,tmp1=txtfile+".txt",tmp1=txtfile);
  tmp=readfile2str(Dirwork,tmp1);
  tmp=replace(tmp,"////","||||");
  tmp=replace(tmp,"/L"+"F/::","::");
  tmp=replace(tmp,"///L"+"F/","/L"+"F/");
  slideL=tokenize(tmp,"/L"+"F/"); //181125to
  slideorgL=slideL; // 16.07.11
  slideL=apply(slideL,Removespace(#));
  tmp=select(1..length(slideL),length(slideL_#)>0); // 16.07.11from
  slideL=apply(tmp,slideL_#);
  slideorgL=apply(tmp,slideorgL_#);
  flg=0; // 16.06.09from
  forall(1..10,
    if(flg==0,
      if(substring(slideL_1,0,1)!="%",
        flg=1;
     ,
        slideL=slideL_(2..length(slideL));
        slideorgL=slideorgL_(2..length(slideorgL));
      );
    );
  ); // 16.06.09until
  flgL=[];
  SCEOUTPUT = openfile(file);
  tmp=tokenize(slideL_1,"::");
  tmp1=tmp_1;
  if(length(tmp)>1,
    tmp2=tmp_2;
    tmp3=tmp_(3..length(tmp));//16.06.25
  ,
    tmp2="";
    tmp3=tmp_(2..length(tmp));//16.06.25
  );
  wall=""; // 16.06.10
  if(length(tmp3)>0,//16.06.25from
    tmp=substring(tmp3_1,0,1);//180330
    if((tmp!="\")&(tmp!="%")&(indexof(tmp3_1,"=")==0), //180330
      wall=tmp3_1;
      tmp3=tmp3_(2..length(tmp3));
    );
  );//16.06.25until
  tmp="%%% "+tmp1+" "+txtfile;// 16.06.09from
  println(SCEOUTPUT,tmp);
  tmp="\documentclass[landscape,10pt]{article}"; 
  if(indexof(PathT,"platex")>0,
    tmp=replace(tmp,"article","jarticle");
    if(indexof(PathT,"uplatex")>0, //17.08.13from
      tmp=replace(tmp,"jarticle","ujarticle");
    );//17.08.13until
  );
  println(SCEOUTPUT,tmp);// 16.06.09from
  tmp=select(1..(length(tmp3)),indexof(tmp3_#,"\usepackage")>0);//17.06.18from
  packL=[]; //240412from
  forall(tmp,
	packL=append(packL,tmp3_#);
  );
  tmp3=remove(tmp3,packL);//240412to
  if(GPACK=="tpic", //240412from
    println(SCEOUTPUT,"\usepackage{ketpic,ketlayer}");
  ,
    if(GPACK=="pict2e",
      println(SCEOUTPUT,"\usepackage{pict2e}");
    ,
      println(SCEOUTPUT,"\usepackage{tikz}");
    );
    println(SCEOUTPUT,"\usepackage{ketpic2e,ketlayer2e}");
  );
  if((indexof(PathT,"pdflatex")>0)%(indexof(PathT,"lualatex")>0),
    println(SCEOUTPUT,"\setlength{\pdfpageheight}{210mm}");//240412[2lines]
    println(SCEOUTPUT,"\setlength{\pdfpagewidth}{297mm}");
	if(indexof(PathT,"lualatex")>0,
      println(SCEOUTPUT,"\usepackage{luatexja}");
    );
    println(SCEOUTPUT,"\usepackage{ketpic2e,ketlayer2e}");
  ,
    println(SCEOUTPUT,"\special{papersize=\the\paperwidth,\the\paperheight}");
  ); //240412to
  if(length(wall)==0, //240412from
    println(SCEOUTPUT,"\usepackage{ketslide}");
  ,
    println(SCEOUTPUT,"\usepackage{ketslide2}");
  );
  println(SCEOUTPUT,"\usepackage{amsmath,amssymb}");
  println(SCEOUTPUT,"\usepackage{bm,enumerate}");
  if((indexof(PathT,"pdflatex")>0)%(indexof(PathT,"lualatex")>0),
    tmp="\usepackage{graphicx}";
  ,
    tmp="\usepackage[dvipdfmx]{graphicx}";
  );
  println(SCEOUTPUT,tmp);
  println(SCEOUTPUT,"\usepackage{color}");//190222
  hyperflg=0;
//  tmp=select(packL,indexof(#,"emath")>0);//240412from
//  if(tmp==0,
    tmp="colorlinks=true,linkcolor=blue,filecolor=blue]{hyperref}";
    if((indexof(PathT,"pdflatex")>0)%(indexof(PathT,"lualatex")>0),
      println(SCEOUTPUT,"\usepackage["+tmp);
    ,
      println(SCEOUTPUT,"\usepackage[dvipdfmx,"+tmp);
    );
//  );
  hyperflg=1;
  forall(packL,
    println(SCEOUTPUT,#); 
  );
   println(SCEOUTPUT,"");
//  tmp=remove(1..(length(tmp3)),tmp);
//  tmp3=tmp3_tmp;
  forall(tmp3,
    println(SCEOUTPUT,#);
  );//240412to
  println(SCEOUTPUT,"");
  letterc=[0.98,0.13,0,0.43]; boxc=[0,0.32,0.52,0];
  shadowc=[0,0,0,0.5]; mboxc="yellow";
  tmp4="abcdefghijklmno";
  forall(1..15,
    tmp=SlideColorList_#;
    if(islist(tmp),
      tmp=text(tmp);
      tmp=substring(tmp,1,length(tmp)-1);
      if(length(SlideColorList_#)==4,//17.01.07from
        println(SCEOUTPUT,
           "\definecolor{slidecolor"+tmp4_#+"}{cmyk}{"+tmp+"}");
      );
      if(length(SlideColorList_#)==3,
        println(SCEOUTPUT,"\definecolor{slidecolor"+tmp4_#+"}{rgb}{"+tmp+"}");
      );//17.01.07until
      SlideColorList_#="slidecolor"+tmp4_#;
    );
  );
  println(SCEOUTPUT,"\def\setthin#1{\def\thin{#1}}");//17.08.23
  println(SCEOUTPUT,"\setthin{"+text(ThinDense)+"}");//17.08.23
  println(SCEOUTPUT,"\newcounter{pagectr}");
  println(SCEOUTPUT,"\setcounter{pagectr}{1}");
  println(SCEOUTPUT,"\newcommand{\slidepage}[1][\monthday-]{%");//180524from
  println(SCEOUTPUT,"\setcounter{ketpicctra}{18}%");
  println(SCEOUTPUT,"");//180908
  println(SCEOUTPUT,"\begin{layer}{118}{0}");
  println(SCEOUTPUT,"\putnotew{130}{-\theketpicctra.05}{\small#1\thepage/\pageref{pageend}}");
  println(SCEOUTPUT,"\end{layer}");
  println(SCEOUTPUT,"");//180908
  println(SCEOUTPUT,"}");//189524to
  if(indexof(PathT,"platex")>0, //180903,180908from
    tmp="\setmargin{"+text(25+SlideMargin_1)+"}{";
    tmp=tmp+text(145-SlideMargin_1)+"}{";
    tmp=tmp+text(15+SlideMargin_2)+"}{";
    tmp=tmp+text(100-SlideMargin_2)+"}";
  ,
    tmp="\setmargin{"+text(20+SlideMargin_1)+"}{";
    tmp=tmp+text(135-SlideMargin_1)+"}{";
    tmp=tmp+text(15+SlideMargin_2)+"}{";
    tmp=tmp+text(100-SlideMargin_2)+"}";
  ); // 180903,180908to
  println(SCEOUTPUT,"");
  println(SCEOUTPUT,tmp);
  println(SCEOUTPUT,"");
  println(SCEOUTPUT,"\ketslideinit");
  println(SCEOUTPUT,"");
  forall(tmp, // 15.07.21
    if(substring(#,0,1)=="\", println(SCEOUTPUT,#));
  );
   println(SCEOUTPUT,"\pagestyle{empty}");//180524to
  println(SCEOUTPUT,"");
  println(SCEOUTPUT,"\begin{document}");
  println(SCEOUTPUT,"");
  if(length(wall)>0,
    println(SCEOUTPUT,"\input{fig/"+wall+".tex}");
    println(SCEOUTPUT,"");
  );
  if(length(tmp2)>0,
    if(indexof(tmp2," no")==0, // 16.11.11from
      println(SCEOUTPUT,"\begin{layer}{120}{0}");
      if(substring(tmp2,0,1)!="\",
        tmp2="\putnotese{0}{0}{\input{fig/"+tmp2+".tex}}";//16.12.27
      );
      println(SCEOUTPUT,tmp2);
      println(SCEOUTPUT,"\end{layer}");
      println(SCEOUTPUT,"");
    ,
      tmp=indexof(tmp2,"=");
      if(tmp==0,
        top="10mm";
      ,
        top=substring(tmp2,tmp,length(tmp2));
      );
      println(SCEOUTPUT,"");
      println(SCEOUTPUT,"\vspace*{"+top+"}");
      println(SCEOUTPUT,"");
    ); // 16.11.11until
  );
  println(SCEOUTPUT,"\def\mainslidetitley{22}");
  forall(1..14, //16.12.22from
    tmp=SlideColorList_#;
    if(!isstring(tmp),tmp=text(tmp));
    if(length(tmp)>0,
      tmp="\def"+slidecmd_#+"{"+tmp+"}";
      println(SCEOUTPUT,tmp);
    );
  );//16.12.22until
  println(SCEOUTPUT,"");
  println(SCEOUTPUT,"\color{"+SlideColorList_(15)+"}");
  println(SCEOUTPUT,BodyStyle);//17.01.07
  println(SCEOUTPUT,"\addtocounter{page}{-1}");//17.01.29
  println(SCEOUTPUT,"");
  verbflg=0; //16.06.28
  repeatflg=0;//16.12.02
  nrep=0;//16.12.27
  nrepprev=0;//17.01.03
  npara=0;//16.12.27
  forall(2..length(slideL),ns,
    ThinFlg=0;
    NonThinFlg=0;
    flg=0;
    tmp1="";
    tmp2="";
    tmp3="";
    sld=Removespace(slideL_ns); // 16.06.28
    sestr="";
    if((substring(sld,0,1)=="%") & (substring(sld,0,2)!="%%"), // 17.06.23
      Repeatsameslide(repeatflg,"",[slideL_ns]);
      if(repeatflg>0,
        tmp=indexof(sld,"]::");
        if(tmp>0,
          if(substring(sld,1,2)!="%",//17.05.31
            if(substring(sld,1,5)=="thin",
              ThinFlg=1;
            ); 
            sestr=substring(sld,1,tmp);
            sld=substring(sld,tmp+2,length(sld));
            tmp=indexof(sestr,"[");
            sestr=substring(sestr,tmp-1,length(sestr));//17.01.05
         );
        );
      );
      if(substring(sld,1,7)=="repeat", // 16.12.09from
        tmp=indexof(sld,"=");
        tmp5=substring(sld,tmp,length(sld));
        tmp=indexof(tmp5,",");
        if(tmp>0,//17.01.03from
          tmp5=substring(tmp5,0,tmp-1);
        );//17.01.03until
        repeatflg=1;
        if(length(tmp5)>0,
          nrep=parse(tmp5);
          tmp=[];
          if(length(wall)>0,
            tmp=["","\input{fig/"+wall+".tex}"];
          );
          tmp=concat(tmp,
             ["","\sameslide"+NewSlideOption,"","\vspace*{18mm}",""]);//180524
          RepeatList=apply(1..nrep,if(#==1,[],tmp));
        );
        if(sestr=="",flg=1);
        tmp=indexof(sld,",");//17.01.03from
        if(tmp>0,
          sld="%"+substring(sld,tmp,length(sld));
          if(indexof(sld,"=")==0,sld=sld+"=");
        );//17.01.03until
      );
      if(substring(sld,1,5)=="para",
        paractr=paractr+1;
        repeatflg=1;
        tmp=indexof(sld,"=");
        tmp=substring(sld,tmp,length(sld));
        if(length(tmp)==0, //17.01.03
          npara=0;
        ,
          paradt=tokenize(tmp,":");
          tmp=fileslist(Dirwork+"/fig/"+paradt_1);
          if(length(tmp)>0,
            parafiles=tokenize(tmp,",");
            if(indexof(paradt_4,"input")>0,
              tmp0=indexof(paradt_4,",");//17.01.29from
              if(tmp0>0,
                paradt=append(paradt,substring(paradt_4,tmp0,length(paradt_4)));
                paradt_4=substring(paradt_4,0,tmp0-1);
              );//17.01.29until
              parafiles=select(parafiles,indexof(#,".tex")>0);
              parafiles=sort(parafiles); //180627
              if(indexof(paradt_4,"\input")==0,paradt_4="\"+paradt_4);//16.12.17
            );
            if(indexof(paradt_4,"include")>0,
              parafiles=select(parafiles,indexof(#,".pdf")>0);
              parafiles=sort(parafiles); //180627
            );
            npara=length(parafiles);
          ,
            println(Dirwork+"/fig/"+paradt_1+" not found");
            parafiles=[];
            npara=0;
          );
          if(nrep==0,
            nrep=npara;
            if(length(wall)>0,
              tmp=["","\input{fig/"+wall+".tex}"];
            );
            tmp=concat(tmp,
                ["","\sameslide"+NewSlideOption,"","\vspace*{18mm}",""]);//180524
            RepeatList=apply(1..nrep,if(#==1,[],tmp));
          );
        );
        forall(1..nrep, //16.12.28
          tmp4=[]; //16.12.31from
          if(hyperflg>0,
            tmp4=["\hypertarget{para"+text(paractr)+"pg"+text(#)+"}{}"];
          );//16.12.31to
          if(npara>0, //17.01.03
            tmp4=concat(tmp4,["","\begin{layer}{120}"+paradt_2]);
            if(#<=npara, //16.12.28from
              tmp=parafiles_#;
            ,
              tmp=parafiles_npara;
            );
            tmp="{"+paradt_4+"{fig/"+paradt_1+"/"+tmp+"}}";
            if(length(paradt)>=5,
              tmp="{\scalebox{"+text(paradt_5)+"}"+tmp+"}";
            );
            if(substring(paradt_3,0,1)=="\",
              tmp=paradt_3+tmp;
            ,
              tmp="\putnote"+paradt_3+tmp;
            );
            tmp4=concat(tmp4,[tmp]);//16.12.31
          ,
            tmp4=concat(tmp4,["","\begin{layer}{120}{0}"]);
          );
          if((hyperflg>0) & (LinkSize>0.15), 
            tmp="{"+text(LinkPosV)+"}{\hyperlink{para"; // 17.01.12from
            tmp1=tmp+text(paractr)+"pg";
            tmp2=tmp+text(paractr-1)+"pg"+text(nrepprev);
            tmp=tmp2; //180526from
            tmp3=[text(LinkPosH-29*LinkSize)+"}"+tmp+"}{\fbox{\Ctab{"
                  +text(2.5*LinkSize)+"mm}{\scalebox{"+text(LinkSize)
                  +"}{\scriptsize $\mathstrut||\!\lhd$}}}}}"];
            if(nrep>1,//180526
              tmp="{"+text(LinkPosV)+"}{\hyperlink{para"; // 17.01.12from
              tmp1=tmp+text(paractr)+"pg";
              tmp2=tmp+text(paractr-1)+"pg"+text(nrepprev);
              tmp=tmp1+text(1);
              tmp3=append(tmp3,
                 text(LinkPosH-24*LinkSize)+"}"+tmp+"}{\fbox{\Ctab{"
                    +text(2.5*LinkSize)+"mm}{\scalebox{"+text(LinkSize)
                    +"}{\scriptsize $\mathstrut|\!\lhd$}}}}}"); //180526to
              if(#>1,tmp=tmp1+text(#-1),tmp=tmp2);
              tmp3=append(tmp3,
                 text(LinkPosH-17*LinkSize)+"}"+tmp+"}{\fbox{\Ctab{"
                    +text(4.5*LinkSize)+"mm}{\scalebox{"+text(LinkSize)
                    +"}{\scriptsize $\mathstrut\!\!\lhd\!\!$}}}}}");
              if(#<nrep,tmp=tmp1+text(#+1),tmp=tmp1+text(nrep));
              tmp3=append(tmp3,
                 text(LinkPosH-10*LinkSize)+"}"+tmp+"}{\fbox{\Ctab{"
                    +text(4.5*LinkSize)+"mm}{\scalebox{"+text(LinkSize)
                    +"}{\scriptsize $\mathstrut\!\rhd\!$}}}}}");
              tmp=tmp1+text(nrep); //180526from
              tmp3=append(tmp3,
              text(LinkPosH-5*LinkSize)+"}"+tmp+"}{\fbox{\Ctab{" // 17.01.19
                  +text(2.5*LinkSize)+"mm}{\scalebox{"+text(LinkSize)
                  +"}{\scriptsize $\mathstrut \!\rhd\!\!|$}}}}}"); 
            );
            tmp="{"+text(LinkPosV)+"}{\hyperlink{para";  //180529[2lines]
            tmp=tmp+text(paractr+1)+"pg"+text(1);
            tmp3=append(tmp3,
               text(LinkPosH)+"}"+tmp+"}{\fbox{\Ctab{" // 17.01.19
                  +text(2.5*LinkSize)+"mm}{\scalebox{"+text(LinkSize)
                  +"}{\scriptsize $\mathstrut \!\rhd\!\!||$}}}}}");  //180526to
          );
          tmp3=apply(tmp3,tmp,"\putnotew{"+tmp);
          tmp4=concat(tmp4,tmp3);// 17.01.12to
          tmp="\putnotee{"+text(LinkPosH+1)+"}{"+text(LinkPosV)+"}";//180524
          tmp=tmp+"{\scriptsize\color{blue} "+text(#)+"/"+text(nrep)+"}"; //180524[blue]
          tmp4=append(tmp4,tmp);
          tmp4=concat(tmp4,["\end{layer}",""]);//16.12.31until
          Repeatsameslide(repeatflg,text([#]),tmp4);
        );
      );
    );
    if(substring(sld,0,2)=="%%", //17.06.23from
      println(SCEOUTPUT,sld);
      flg=1;
    ); //17.06.23to
    if(flg==0,  
      if(indexof(sld,"\begin{verbatim}")==1, // 16.06.28from
        Repeatsameslide(repeatflg,sestr,[slideL_ns]);
        verbflg=1;
        flg=1;
      ); // 16.06.28
      if(indexof(sld,"\end{verbatim}")==1,
        Repeatsameslide(repeatflg,sestr,[slideL_ns]);
        verbflg=0;
        flg=1;
      ); // 16.06.28until
      if(flg==0,
        tmp=replace(sld,"||||","//"); // 16.05.11
        tmp=tokenize(tmp,"::"); // 16.05.11
        tmp1=tmp_1;
        if(length(tmp)>1,tmp2=tmp_2,tmp2="");
        if(length(tmp)>2,tmp3=tmp_3,tmp3="");
        if(length(tmp)>3,tmp4=tmp_4,tmp4="");
        if(length(tmp)>4,tmp5=tmp_5,tmp5="");
        if(contains(["main","new","same"],tmp1),
          if(tmp1=="new", // 16.11.09from
            newoption="";
            if(substring(tmp2,0,1)=="[",newoption=tmp2);
          );
          if(tmp1=="same",
             if(length(tmp2)==0,tmp2=newoption); 
          );// 16.11.09until
          println(SCEOUTPUT,"");
          println(SCEOUTPUT,"%%%%%%%%%%%%%%%%%%%%");
          println(SCEOUTPUT,"");
        );
      );
      if(flg==0&tmp1=="main",
        if(repeatflg==1,
          forall(2..(length(RepeatList)),nrep,
            tmp=RepeatList_nrep;
            forall(tmp,
              if(substring(#,0,1)!="%", //16.01.04
                println(SCEOUTPUT,#);
              );
            );
          );
          println(SCEOUTPUT,"");
          repeatflg=0;RepeatList=[];
          nrepprev=nrep;//17.01.03
          nrep=0;//16.12.27
          npara=0;//16.12.27
        );
        if(length(wall)>0,
          println(SCEOUTPUT,"\input{fig/"+wall+".tex}");
        );
        println(SCEOUTPUT,"\mainslide{"+tmp2+"}");
        println(SCEOUTPUT,"");
        println(SCEOUTPUT,"");
        tmp2="";
        flg=1;
      );
      if(flg==0&tmp1=="new",
        if(repeatflg==1,
          forall(2..(length(RepeatList)),nrep,
            tmp=RepeatList_nrep;
            forall(tmp,
              if(substring(#,0,1)!="%", //16.01.04
                println(SCEOUTPUT,#);
              );
            );
          );
          println(SCEOUTPUT,"");
          repeatflg=0;RepeatList=[];
          nrepprev=nrep;//17.01.03
          nrep=0;
          npara=0;
        );
        if(length(wall)>0,
          Repeatsameslide(repeatflg,sestr,["\input{fig/"+wall+".tex}"]);
        );
        tmp="\newslide";
        NewSlideOption=""; //17.01.04
        if(substring(tmp2,0,1)=="[",
          NewSlideOption=tmp2; //17.01.04
          tmp=tmp+tmp2;
          tmp2=tmp3;
          tmp3=tmp4;
          tmp4=tmp5;
        );
        tmp=tmp+"{"+tmp2+"}";
        Repeatsameslide(repeatflg,sestr,[tmp,"","\vspace*{18mm}",""]);//180524
        tmp2="";
        flg=1;
      );
      if(flg==0&tmp1=="same",
        if(repeatflg==1,
          forall(2..(length(RepeatList)),nrep,
            tmp=RepeatList_nrep;
            forall(tmp,
              if(substring(#,0,1)!="%", //16.01.04
                println(SCEOUTPUT,#);
              );
            );
          );
          println(SCEOUTPUT,"");
          repeatflg=0;RepeatList=[];
          nrepprev=nrep;//17.01.03
          nrep=0;
          npara=0;
       );
        if(length(wall)>0,
          println(SCEOUTPUT,"\input{fig/"+wall+".tex}");
        );
        tmp="\sameslide"+NewSlideOption; //17.01.04;
        println(SCEOUTPUT,tmp);
        println(SCEOUTPUT,""); //180524
        println(SCEOUTPUT,"\vspace*{18mm}");
        println(SCEOUTPUT,"");
        tmp4=tmp3;
        tmp3=tmp2;
        tmp2="";
        flg=1;
      );
      if(flg==0&tmp1=="itemize",
        Repeatsameslide(repeatflg,sestr,["\begin{itemize}"]);
        flgL=append(flgL,"i");
        tmp2="";
        tmp3="";
        flg=1;
      );
      if(flg==0&tmp1=="enumerate",
        Repeatsameslide(repeatflg,sestr,["\begin{enumerate}"+tmp2]);
        flgL=append(flgL,"e");
        tmp2="";
        tmp3="";
        flg=1;
      );
      if(flg==0&tmp1=="verbatim", //16.06.28from
        Repeatsameslide(repeatflg,sestr,["\begin{verbatim}"]);
        flgL=append(flgL,"v");
        tmp1="";
        tmp2="";
        tmp3="";
        verbflg=1;
        flg=1;
      ); //16.06.28until
      if(flg==0&tmp1=="layer",
        Repeatsameslide(repeatflg,sestr,[""]);
        tmp="\begin{layer}";
        if(length(tmp2)>0,
          tmp=tmp+tmp2;
        ,
          tmp=tmp+"{120}{0}";
        );
        Repeatsameslide(repeatflg,sestr,[tmp]);
        flgL=append(flgL,"l");
        tmp2="";
        tmp3="";
        flg=1;
      );
      if(flg==0&tmp1=="putnote",
        tmp="\putnote"+tmp2+"{";
        if(indexof(tmp3,"include")==0,
          tmp1=indexof(tmp3,",");
          if(tmp1==0,
            tmp=tmp+"\input{fig/"+tmp3+".tex}}";
          ,
            tmp2=substring(tmp3,tmp1,length(tmp3));
            tmp3=substring(tmp3,0,tmp1-1);
            tmp=tmp+"\scalebox{"+tmp2+"}{\input{fig/"+tmp3+".tex}}}";
          );
        ,
          tmp2=indexof(tmp3,"[");
          tmp3=substring(tmp3,tmp2-1,length(tmp3));
          tmp=tmp+"\includegraphics"+tmp3+"{fig/"+tmp4+"}}";
        );
        Repeatsameslide(repeatflg,sestr,[tmp]);
        tmp2="";
        tmp3="";
        flg=1;
      );
      if(flg==0&tmp1=="item",
        NonThinFlg=1;
        Repeatsameslide(repeatflg,sestr,["\item"]);
        tmp3="";
        flg=1;
      );
      if(flg==0&tmp1=="end"&(length(flgL)>0), //180526 
        tmp=flgL_(length(flgL));
        if(tmp=="i",
          Repeatsameslide(repeatflg,sestr,["\end{itemize}"]);
        );
        if(tmp=="e",
          Repeatsameslide(repeatflg,sestr,["\end{enumerate}"]);
        );
        if(tmp=="l",
          Repeatsameslide(repeatflg,sestr,["\end{layer}",""]);
        );
        if(tmp=="v",  // 16.06.28from
          Repeatsameslide(repeatflg,sestr,["\end{verbatim}",""]);
          verbflg=0;
        ); // 16.06.28until
        flgL=flgL_(1..(length(flgL)-1));
        tmp2="";
        tmp3="";
        flg=1;
      );
      if(flg==0, // 16.06.28from
        if(verbflg==0,
          tmp2=tmp1;
        ,
          tmp2=slideorgL_ns; // 16.07.11
          tmp2=replace(tmp2,"||","//"); // 16.07.10
          tmp3="";
        );
      ); // 16.06.28until
      if(length(tmp2)>0,
        if(tmp2=="...", tmp2="");
          if(NonThinFlg==1,NonThinFlg=2);
          Repeatsameslide(repeatflg,sestr,[tmp2]);
      );
      if(length(tmp3)>0,
        Repeatsameslide(repeatflg,sestr,["\begin{layer}{120}{0}"]);        
        if(substring(tmp3,0,1)=="{",
          tmp=tmp3;
          tmp3=tmp4;
        ,
          tmp="{60}{0}";
        );
        tmp1=indexof(tmp3,",");
        if(tmp1==0,
          tmp3="\putnotes"+tmp+"{\input{fig/"+tmp3+".tex}}";
        ,
          tmp2=substring(tmp3,tmp1,length(tmp3));
          tmp3=substring(tmp3,0,tmp1-1);
          tmp3="\putnotes"+tmp+"{\scalebox{"+tmp2+"}  
              {\input{fig/"+tmp3+".tex}}}";
        );
        Repeatsameslide(repeatflg,sestr,[tmp3,"\end{layer}",""]);        
      );
    );
  );
  if(repeatflg==1,
    forall(2..(length(RepeatList)),nrep,
       tmp=RepeatList_nrep;
       forall(tmp,
         if(substring(#,0,1)!="%", //16.01.04
           println(SCEOUTPUT,#);
         );
       );
    );
  );
  println(SCEOUTPUT,"\label{pageend}\mbox{}"); //180529
  println(SCEOUTPUT,"");
  println(SCEOUTPUT,"\end{document}");
  closefile(SCEOUTPUT);
);
////%Presentation end////

////%Mkslides start////
Mkslides():=(
  regional(store,sep,parent,texparentorg,tmp,tmp1,tmp2,tmp3,tmp4,flg);
  store=Fillblack();//181125
  tmp4=Fhead;
  Fhead=""; 
  if(!iswindows(), //17.10.13
    Dirwork=replace(Dirwork,"\",pathsep());
    parent=replace(Dirwork+Shellparent,"\",pathsep());
  ,
    Dirwork=replace(Dirwork,"/",pathsep());
    parent=replace(Dirwork+Batparent,"/",pathsep());// 16.05.29
  );
  tmp=replace(Dirwork,pathsep()+"fig","");//180604[2lines]
  Changework(tmp);
  Setdirectory(Dirwork);
  if(!iswindows(), //180604from
    println(setexec(Dirwork,Shellparent));
  ); //180604to
  if(length(Texmain)>0,  // 15.08.14 from
    Texparent=Texmain;
  );
  texparentorg=Texparent; //17.04.10from
  if(isstring(Slidename),  // 15.08.14 from
    Texparent=Slidename;
  );//17.04.10until
  if(!isexists(Dirwork,Texparent+".txt"), // 17.04.12from
    drawtext(mouse().xy,Texparent+".txt not exist in "+Dirwork,
      size->24,color->[1,0,0]);
  ,  // 17.04.12until
    Presentation(Texparent);  // 15.08.14to
    if(iswindows(),
      tmp2=Batparent;
      parent=replace(Dirwork+Batparent,sep+"fig","");// 16.05.29
      if(indexof(Pathpdf,"Adobe")>0, //17.12.09from
        Makebat(Texparent,"ttv");
      ,
        Makebat(Texparent,"tv");
      ); //17.12.09until
      kc():=(
        println("kc : "+kc(parent,Dirlib,Fnametex)); // 16.06.10, 17.02.19
      );
      kc();
      Batparent=tmp2;
    ,
      tmp2=Shellparent;
      parent=replace(Dirwork+Shellparent,sep+"fig","");// 16.05.29
      Shellparent=replace(Shellparent,sep+"fig","");
      if(indexof(Pathpdf,"Adobe")>0, //17.12.09from
        Makeshell(Texparent,"ttv");
      ,
        Makeshell(Texparent,"tv");
      ); //17.12.09until
      kc():=(
        println("kc : "+kc(parent,Mackc+Dirlib,Fnametex)); // 16.06.10
      );
      kc();
      Shellparent=tmp2;
    );
  );
  Dirwork=Dirwork+pathsep()+"fig"; //17.10.16
  setdirectory(Dirwork);
  Fhead=tmp4;
  Texparent=texparentorg;//17.04.10
  Fillrestore(store);//181125
);
////%Mkslides end////

////%Mkslidesummary start////
Mkslidesummary():=( // 17.10.26 for R
  regional(texparentorg);
  texparentorg=Texparent;
  if(isstring(Slidename),
    Texparent=Slidename;
  );
  Mkslidesummary(Texparent,Texparent+"digest",["m","Wait=3"]);
  Texparent=texparentorg;
);
Mkslidesummary(fin,fout):= 
   Mkslidesummary(fin,fout,["m","Wait=3"]);
Mkslidesummary(inputfile,outputfile,options):=(
//help:Mkslidesummary(fin,fout,options);
  regional(store,fin,fout,out,figflg,dirworkorg,dirtop,tmp);
  store=Fillblack();//181125
  dirworkorg=Dirwork;//17.04.10from
  dirtop=replace(Dirwork,pathsep()+"fig","");
  Changework(dirtop);//17.04.10uptp
  if(ismacosx(), //180604from
    println(setexec(Dirwork,Shellparent));
  ); //180604to
  fin=inputfile;
  if(indexof(fin,".")==0,fin=fin+".tex");
  fout=outputfile;
  if(indexof(fout,".")==0,fout=fout+".tex");
  cmdL=[
   "Dt=readLines"+PaO()+"'"+fin+"',encoding='UTF-8')",[],
   "num=grep"+PaO()+"'hypertarget',Dt,fixed=TRUE)",[], //180412
   "Dt=Dt[setdiff"+PaO()+"1:length"+PaO()+"Dt),num)]",[],
   "Smain=c"+PPa("")+";Snew=c"+PPa("")+";Ssame=c"+PPa(""),[],
   "for"+PaO()+"J in 1:length"+PaO()+"Dt)){",[],
   "  Tmp=length"+PaO()+"grep"+PaO()+"'mainslide{',Dt[J],fixed=TRUE))",[], //180412
   "  if"+PaO()+"Tmp>0){Smain=c"+PaO()+"Smain,1)}else{Smain=c"+PaO()+"Smain,0)}",[],
   "  Tmp=length"+PaO()+"grep"+PaO()+"'newslide{',Dt[J],fixed=TRUE))",[], //180412
   "  if"+PaO()+"Tmp>0){Snew=c"+PaO()+"Snew,1)}else{Snew=c"+PaO()+"Snew,0)}",[],
   "  Tmp=length"+PaO()+"grep"+PaO()+"'sameslide',Dt[J],fixed=TRUE))",[], //180412
   "  if"+PaO()+"Tmp>0){Ssame=c"+PaO()+"Ssame,1)}else{Ssame=c"+PaO()+"Ssame,0)}",[],
   "}",[],
  "Nnew=c"+PPa("")+";Nsame=c"+PPa(""),[],
   "for"+PaO()+"J in 1:length"+PaO()+"Dt)){",[],
   "  if"+PaO(2)+"Snew[J]==1)|"+PaO()+"Smain[J]==1)){Nnew=c"+PaO()+"Nnew,J)}",[],
   "  if"+PaO()+"Ssame[J]==1){Nsame=c"+PaO()+"Nsame,J)}",[],
   "}",[],
   "Out=Dt[1:Nnew[1]]",[],
   "for"+PaO()+"J in Looprange"+PaO()+"2,length"+PaO()+"Nnew))){",[],
    "  Tmp=max"+PaO()+"c"+PaO()+"1,Nsame[Nsame<Nnew[J]]))",[],
    "  Tmp=max"+PaO()+"c"+PaO()+"Tmp,Nnew[J-1]))+1",[],
    "  Out=c"+PaO()+"Out,Dt[Tmp:Nnew[J]])",[],
   "}",[],
   "Tmp=max"+PaO()+"c"+PaO()+"Nsame[-1],Nnew[-1]))+1",[],
   "Out=c"+PaO()+"Out,Dt[Tmp:length"+PaO()+"Dt)])",[],
   "writeLines"+PaO()+"Out,'"+fout+"',sep='\n')",[] //180412[2lines removed] 
  ];
  CalcbyR("",cmdL,append(options,"Cat=n"));//180412
  wait(1000);
  Changework(dirtop);//17.04.10
  tmp=replace(fout,".tex","");
  if(iswindows(),
    Makebat(tmp,"tv");
  ,
    Makeshell(tmp,"tv");
  );
  kc();
  Changework(dirworkorg);//17.04.10
  Fillrestore(store);//181125
);
////%Mkslidesummary end////

////%BBdata start////
BBdata(fname):=BBdata(fname,[]); //200704from
BBdata(Arg1,Arg2):=(
  if(islist(Arg2),
    BBdata(Dirwork,Arg1,Arg2);
  ,
    BBdata(Arg1,Arg2,[]);
  );
);
BBdata(path,fname,optionorg):=(
//help:BBdata(filename);
//help:BBdata(path,filename);
//help:BBdata(options="r","w=","h=");
  regional(fout,flg,file,kcfile,options,eqL,stL,
      waiting,addop,tmp,tmp1,tmp2);
  file=fname;
  flg=0;
  waiting=2;
  if(indexof(file,".")==0,file=file+".pdf");
  options=optionorg;
  tmp=Divoptions(options);
  eqL=tmp_5;
  stL=tmp_7;
  flg=1;
  addop="";
  forall(stL,
    tmp=Toupper(substring(#,0,1));
    if(tmp=="M",flg=1);
    if(tmp=="R",flg=0); 
  );
  forall(eqL,
    tmp=indexof(#,"=");
    tmp1=Toupper(substring(#,0,1)); //181111
    tmp2=substring(#,tmp,length(#));
    if(tmp1=="W",
      addop=addop+",width="+tmp2;
      options=remove(options,[#]);
    );
    if(tmp1=="H",
      addop=addop+",height="+tmp2;
      options=remove(options,[#]);
    );
  );
  tmp=indexof(file,".");
  tmp1=substring(file,0,tmp-1);
  fout=tmp1+".txt";
  if(iswindows(),
    kcfile="kc.bat";
  ,
    if(ismacosx(), //181219
      kcfile="kc.command";
    ,
      kcfile="kc.sh";
    );
  );
  if(flg==0,
    tmp=Readlines(Dirwork,fout); //201013
    if(length(tmp)==0,
      flg=1;
    ,
      tmp=tmp_1;
      tmp1=indexof(tmp,":");
      tmp=substring(tmp,tmp1,length(tmp));
      tmp=Removespace(tmp);
      if(tmp!=file,flg=1);
    );
  );
  if(flg==1,
    if(!isexists(path,file),
      println("   => "+file+" not exists in "+path);
      flg=-1;
    );
  );
  if(flg==1,
    SCEOUTPUT = openfile(kcfile);
    if(!iswindows(),
      println(SCEOUTPUT,"#!/bin/sh");
    );
    println(SCEOUTPUT,"cd "+Dqq(path)); //190414
    tmp=replace(PathT,"pdflatex","extractbb"); //16.11.22
    tmp=replace(tmp,"pdftex","extractbb");  //16.11.22
    tmp=replace(tmp,"xelatex","extractbb"); 
    tmp=replace(tmp,"uplatex","extractbb"); //17.09.20
    tmp=replace(tmp,"platex","extractbb");
    tmp=replace(tmp,"latex","extractbb");
    tmp=tmp+" -O "+file;
    if(iswindows(),
      tmp=tmp+" > "+Dirwork+"\"+fout;
    ,
      tmp=tmp+" > "+Dirwork+"/"+fout;
    );
    println(SCEOUTPUT,tmp); 
    println(SCEOUTPUT,"exit 0");
    closefile(SCEOUTPUT);
    kc(Dirwork+"/"+kcfile,Mackc+Dirlib,Fnametex);  // 16.06.07
  );
  if(flg>=0,
    tmp1=0;
    repeat(floor(waiting*1000/WaitUnit),
      if(tmp1==0,
        wait(100);
        if(isexists(Dirwork,fout), //201013[2lines]
          tmp=Readlines(Dirwork,fout); 
          tmp2=select(tmp,indexof(#,"CreationDate")>0);
          if(length(tmp2)>0,
            tmp1=1;
          );
        );
      );
    );
    if(length(tmp)==0,
      println(fout+" not generated. Maybe "+kcfile+" not run.");
    ,
      tmp=select(tmp,indexof(#,"Bounding")>0);
      tmp=tmp_2;
      tmp1=indexof(tmp,":");
      tmp=substring(tmp,tmp1,length(tmp));
      tmp=Removespace(tmp);
      tmp=Strsplit(tmp," ");
      tmp1="";
      forall(tmp,
        tmp1=tmp1+Sprintf(#,2)+" ";
      );
      tmp1=substring(tmp1,0,length(tmp1)-1);
      if(length(addop)>0,
        tmp1=tmp1+addop;
      );
      tmp2="\includegraphics[bb="+tmp1+"]{"+file+"}";
      println(tmp2);
    );
  );
  tmp2; // 16.04.25
); //200704to
////%BBdata end////

////%Gcd start//// //190623
Euclidalg(x,y):=(
 regional(u,v,r);
 if(x>y,
  u=x; v=y;
 ,
  u=y; v=x;
 );
 r=v;
 while(r!=0,
  r=mod(u,v);
  if(r!=0,
    u=v; v=r;
  );
 );
 v;
);
Gcd(x1,x2):=Gcd([x1,x2]);
Gcd(xL):=(
//help:Gcd([12,18,24]);
  regional(sL,tmp);
  sL=xL;
  while(length(sL)>1,
    sL=sort(sL,[-#]);
    tmp=Euclidalg(sL_1,sL_2);
    sL=sL_(3..(length(sL)));
    sL=prepend(tmp,sL);
  );
  sL_1;
);
////%Gcd end////

////%Fracform start//// //190623,29
Fracform(x):=Fracform(x,1..100,5);
Fracform(x,Arg):=( //200329
  if(islist(Arg),
    Fracform(x,Arg,5);
  ,
    if(Arg<0,Fracform(x,1..100,-Arg),Fracform(x,1..Arg,5));
  );
);
Fracform(x,denorg,deg):=(
//help:Fracform(1.33);
//help:Fracform(1.33,1..100 (,err(-5)));
//help:Fracform(1.33,200 (,err(-5)));
  regional(Eps,denL,fL,flg,tmp,nn,mm,err);
  Eps=10^(-abs(deg));
  denL=denorg;
  if(!islist(denL),denL=1..denL);
  fL=[];
  flg=0;
  forall(denL,
    if(flg==0,
      tmp=round(x*#);
      tmp=[tmp,#,abs(tmp/#-x)];
      if(tmp_3<Eps,
        flg=1;
      ,
        fL=append(fL,tmp);
      );
    );
  );
  if(flg==0,
    fL=sort(fL,#_3);
    tmp=fL_1;
  );
  mm=tmp_1; nn=tmp_2; err=abs(x-mm/nn);
  if(nn>1,
    out="fr("+text(mm)+","+text(nn)+")";
  ,
    out=text(mm);
  );
  [out,"err="+format(err,10),mm,nn]; //190914
);
////%Fracform end////

////%Sla2fra start//// 202010017
Sla2fra(str):=(
//help::Sla2fra("x/y+(a/b)/c+(pi/2)/(3/4)");
  regional(out,subL,nn,sub,numer,ctr,sla,par,nstr,dstr,
       tmp,tmp1,tmp2,tmp3,tmp4);
  numer=".0123456789";
  numer=apply(1..(length(numer)),numer_#);
  subL=Strsplit(str,"//");
  forall(2..(length(subL)),
    tmp=subL_#;
    if(substring(tmp,0,1)=="/",
      subL_#=substring(tmp,1,length(tmp))
    );
  ); 
  forall(1..(length(subL)),nn,
    sub="("+subL_nn+")";
    sla=Getlevel(sub,"/");
    sla=sort(sla,[-#_2,#_1]);
    if(length(sla)>0,sla=sla_1_1,sla=0);
    ctr=0;
    while((sla>0)&(ctr<20),
      par1=Bracket(sub,"()");
      par2=Bracket(sub,"{}");
      tmp1=sla-1;
      tmp=sub_(tmp1);
      if((tmp==")")%(tmp=="}"),
        if(tmp==")",par=par1,par=par2);
        tmp=select(par,#_1==tmp1);
        tmp=tmp_1_2;
        tmp2=select(par,(#_1<tmp1)&(#_2==-tmp));
        tmp2=tmp2_(-1)_1;
        nstr=substring(sub,tmp2,tmp1-1);
        tmp2=tmp2-1;
      ,
        if(contains(numer,sub_(tmp1)),
          tmp2=select(1..(tmp1),!contains(numer,sub_#));
          if(length(tmp2)>0,tmp2=tmp2_(-1),tmp2=0);
          nstr=substring(sub,tmp2,tmp1);
        ,
          if(substring(sub,tmp1-2,tmp1)=="pi",
            nstr="pi";
            tmp2=tmp1-2;
          ,
            nstr=sub_(tmp1);
            tmp2=tmp1-1;
          );
        );
      );
      tmp3=sla+1;
      tmp=sub_(tmp3);
      if((tmp=="(")%(tmp=="{"),
        if(tmp=="(",par=par1,par=par2);
        tmp=select(par,#_1==tmp3);
        tmp=tmp_1_2;
        tmp4=select(par,(#_1>tmp3)&(#_2==-tmp));
        tmp4=tmp4_1_1;
        dstr=substring(sub,tmp3,tmp4-1);
      ,
        if(contains(numer,sub_(tmp3)),
          tmp4=select((tmp3)..(length(sub)),
            !contains(numer,sub_#));
          if(length(tmp4)>0,tmp4=tmp4_1-1,tmp4=length(sub));
          dstr=substring(sub,tmp3-1,tmp4);
        ,
          if(substring(sub,tmp3-1,tmp3+1)=="pi",
            dstr="pi";
            tmp4=tmp3+1;
          ,
            tmp4=tmp3;
            dstr=sub_(tmp4);
          );
        );
      );
      sub=substring(sub,0,tmp2)+"fr("+nstr+","+dstr+")"+substring(sub,tmp4,length(sub));
      sla=Getlevel(sub,"/");
      sla=sort(sla,[-#_2,#_1]);
      if(length(sla)>0,sla=sla_1_1,sla=0);
      ctr=ctr+1;
    );
    subL_nn=substring(sub,1,length(sub)-1);
  );
  out="";
  forall(subL,
    out=out+#+"//";
  );
  out=substring(out,0,length(out)-2);
  out;
);
////%Sla2fra end////

////%Tonormalform start//// //200605
Tonormalform(fun0org):=(
  regional(fun0,num,alp,ope,par,sgn,tmp,tmp1,tmp2,
    nn,str,flg,pre,Pre,fun);
  pre=["fr","po","sq","log","sin","cos","tan","pi"];
  Pre=["FR","PO","SQ","LO","Si","CO","TA","PI"]; //200922[2lines]
  Pre=apply(Pre,substring(#,0,1)+"*"+substring(#,1,2));
  fun0=replace(fun0org," ","*");
  forall(1..(length(pre)),
    fun0=replace(fun0,pre_#,Pre_#);
  );
  num=apply(0..9,text(#));
  num=append(num,".");
  tmp1=apply(1..26,unicode(text(#+96),base->10));
  tmp2=apply(1..26,unicode(text(#+64),base->10));
  alp=concat(tmp1,tmp2);
  ope=["-","+","*","/","^"];
  par=["(",")"];
  sgn=["-","+"];
  tmp=substring(fun0,0,1);
  if(contains(sgn,tmp),
    fun=tmp; nn=2;
  ,
    fun=""; nn=1;
  );
  str=substring(fun0,nn-1,nn);
  nn=nn+1;
  if(contains(num,str),flg="n");
  if(contains(alp,str),flg="a");
  if(contains(ope,str),flg="o");
  if(contains(par,str),flg="p");
  while(nn<=length(fun0),
    tmp1=substring(fun0,nn-1,nn);
    if(contains(num,tmp1),tmp2="n");
    if(contains(alp,tmp1),tmp2="a");
    if(contains(ope,tmp1),tmp2="o");
    if(contains(par,tmp1),tmp2="p");
    if(flg==tmp2,
      str=str+tmp1;
    ,
      if(flg=="n",
        if((tmp2=="a"),
          fun=fun+str+"*";
        );
        if((tmp2=="o")%(tmp2=="p"),
          fun=fun+str;
        );
        if(tmp1=="(",
          fun=fun+"*";
        );
      );
      if(flg=="a",
        tmp="";
        forall(1..(length(str)),
          tmp=tmp+str_#+"*";
        );
        if((tmp2=="n"),
          fun=fun+tmp;
        );
        if((tmp2=="o")%(tmp2=="p"),
          fun=fun+substring(tmp,0,length(tmp)-1);
        );
      );
      if((flg=="o"),
        fun=fun+str;
      );
      if(flg=="p",
        if((str=="("),
          if((tmp2=="n")%(tmp2=="a"),
            fun=fun+str;
          );
          if((tmp2=="o")%(tmp2=="p"),
            fun=fun+str;
          );
        );
        if((str==")"),
          if((tmp2=="n")%(tmp2=="a"),
            fun=fun+str+"*";
          );
          if((tmp2=="o")%(tmp2=="p"),
            fun=fun+str;
          );
        );
      );
      str=tmp1;
    );
    flg=tmp2;
    nn=nn+1;
  );
  fun=fun+str;
  forall(1..(length(Pre)),
    fun=replace(fun,Pre_#,pre_#);
  );
  fun=replace(fun,")(",")*(");
  forall(1..(length(Pre)), //200622from
    fun=replace(fun,Pre_#,pre_#);
  );
  fun=replace(fun,"*,*",","); //200622to
  fun;
);
////%Tonormalform end//// //200605

////%Addpar start//// //210909,211029
Addpar(str):=(
  regional(num,out,add,tmp);
  out=str;
  if(length(str)>0,
    if(substring(str,0,1)=="!",
      if(substring(str,1,2)!="!",
        out=substring(str,1,length(str));
      ,
        out="("+substring(str,2,length(str))+")";
      );
    ,
      add=(length(str)>=3)&(str!="{\pi}"); //211118
      num=apply(0..9,text(#));
      tmp=apply(1..(length(str)),str_#);
      tmp=sort(tmp);
      add=add&(common(num,tmp)!=tmp);
      tmp=Indexall(str,"^");
      add=add&(length(tmp)!=1);
      add=add&(str_1!="(");
      forall(["+","-","/"], //210923from
        add=add%(indexof(str,#)>0);
      ); //210923to
      if(add,out="("+out+")");
    );
  );
  out;
);
////%Addpar end////

////%Convtrigpow start
Convtrigpow(strorg):=(
  //help:Convtrigpow("sin(x)^(2)");
  regional(tmp,tmp1,tmp2,tmp3,ctr,str,
         trigL,trig,uptrig,str1,str2);
  trigL=["sin","cos","tan"];
  str=strorg;
  forall(trigL,trig,
    uptrig=Toupper(trig);
    tmp=indexof(str,trig+"(");
    ctr=1;
    while((tmp>0)&(ctr<10),
      str1=substring(str,0,tmp-1);
      str1=str1+uptrig;
      str2=substring(str,tmp+2,length(str));
      tmp=Bracket(str2);
      tmp1=select(tmp,#_2==1);
      tmp2=select(tmp,#_2==-1);
      if(length(tmp2)>0,
        tmp=substring(str2,tmp2_1_1,tmp2_1_1+2);
        if((tmp=="^(")&(length(tmp2)>1),
          tmp3=substring(str2,tmp1_2_1,tmp2_2_1-1);
          tmp=substring(str2,1,tmp2_1_1);
          str1=str1+"("+tmp3+","+tmp;
          str2=substring(str2,tmp2_2_1,length(str2));
        );
      );
      str=str1+str2;
      tmp=indexof(str,trig);
      ctr=ctr+1;
    );
    str=replace(str,uptrig,trig);
  );
  str;
);
////%Convtrigpow end

////%Totexform start////
Totexform(str):=( //231215
//help:Totexform("fr(2,3)");
  regional(plv,funL,repL,parL,out,head,flg,rep,fun,pre,
    post,ctr,clv,nn,tmp,tmp1,tmp2,tmp3,tmp4);
  tmp1="\displaystyle\int"; //210831from
  tmp2="\displaystyle\lim";
  tmp3="\displaystyle\sum"; //210831to
  repL=[ //190515from
    ["^(",["^{xx}"]], //210805
    ["_(",["_{xx}"]], //210831
    ["tx(",["\text{xx}"]], //210907
    ["tfr(",["","\frac{xx}{yy}"]], //210831,220523
    ["fr(",["","\displaystyle\frac{xx}{yy}"]], //210228from 231224
    ["log(",["\log xx ","\log_{xx} yy"]], //210405
    ["ln(",["\ln xx "]], //210903
    ["sq(",["\sqrt{xx}","\sqrt[xx]{yy}"]],
    ["po(",["","{xx}^{yy}"]],
    ["sin(",["\sin xx ","\sin^{xx}\! yy "]], //200823[3lines]  //210405
    ["cos(",["\cos xx ","\cos^{xx}\! yy "]], //210405
    ["tan(",["\tan xx ","\tan^{xx}\! yy "]],  //210228to  //210405
    ["lim(", ["",tmp2+"_{xx \to yy} ",tmp2+"_{xx \to yy} zz"]], //210831from
    ["int(", [tmp1+" ",tmp1+" xx yy ",tmp1+" yy zz ",tmp1+"_{xx}^{yy} zz ww "]],  //211027
    ["sum(", ["",tmp3+"_{xx}^{yy} ", tmp3+"_{xx}^{yy} zz"]], //210831to
    ["diff(", ["d ","\frac{dxx}{dyy}"]], //210913
    ["par(", ["\partial ","\frac{\partial xx}{\partial yy}"]] ,//210913
    ["br(", ["","","\Bigl[xx\Bigr]_{yy}^{zz}"]] //210923,1019
  ];
  parL=["log(","sin(","cos(","tan(","lim(","int(","sum("]; //210901
  out=replace(str,"pi","{\pi}"); //210805
  out=replace(out,"frac(","fr(");//231227
  out=replace(out,"sqrt(","sq(");//231215 from
  tmp=indexof(out,")/(");
  ctr=1;
  while((tmp>0)&(ctr<20),
    tmp1=substring(out,0,tmp);
    tmp2=substring(out,tmp+1,length(out));
    tmp=Bracket(tmp1);
    tmp3=tmp_(-1)_2;
    tmp=select(tmp,#_2==-tmp3);
    tmp=tmp_(-1)_1;
    tmp1=substring(tmp1,0,tmp-1)+"fr("+
           substring(tmp1,tmp,length(tmp1)-1)+",";
    tmp=Bracket(tmp2);
    tmp=select(tmp,#_2==-1);
    tmp=tmp_1_1;
    tmp2=substring(tmp2,1,length(tmp2));
    out=tmp1+tmp2;
    tmp=indexof(out,")/(");
    ctr=ctr+1;
  );//231215 to
  head="";
  flg=0;
  plv=Bracket(out,"()");
  if(length(plv)>0,
    if(plv_1_2==0,
      head=substring(out,0,plv_1_1);
      out=substring(out,plv_1_1,length(out));
      if(substring(out,0,1)=="*",out=substring(out,1,length(out)));
      plv=Bracket(out,"()");
    );
    if(length(plv)>0, //210806
      tmp=plv_(-1);
      if(tmp_2!=-1,
        out=str;
        flg=1;
      );
    );  //210806
  );
  if(flg==0,
    forall(repL,rep,
      fun=rep_1;
      ctr=1;
      tmp=indexof(out,fun);
      while((tmp>0)&(ctr<40),
        pre=substring(out,0,tmp-1);
        out=substring(out,tmp-1,length(out));
        plv=Bracket(out,"()");
        tmp=select(plv,#_2==-1);
        tmp=tmp_1;
        post=substring(out,tmp_1,length(out));
        out=substring(out,0,tmp_1);
        clv=Getlevel(out);
        clv=select(clv,#_2==1);
        nn=length(clv)+1;
        if(nn==1,
          tmp1=substring(out,plv_1_1,length(out)-1);
          if(contains(parL,fun), //210901from
            tmp1=Addpar(tmp1); //211029
          ); //210901to
          out=replace(rep_2_1,"xx",tmp1);
        );
       if(nn==2,
          tmp1=substring(out,plv_1_1,clv_1_1-1);
          tmp2=substring(out,clv_1_1,length(out)-1);
		  if(indexof(out,"int(")>0, //231227from
		    if((length(tmp2)>0)&(substring(tmp2,0,1)!="d"),
			  tmp2="d"+tmp2;
            );
          ); //231227to
          if(contains(parL,fun), //210901from
            tmp2=Addpar(tmp2); //211029
          ); //210901to
          tmp=replace(rep_2_2,"xx",tmp1);
          out=replace(tmp,"yy",tmp2);
        );
        if(nn==3, //210831from
          tmp1=substring(out,plv_1_1,clv_1_1-1);
          tmp2=substring(out,clv_1_1,clv_2_1-1);
          tmp3=substring(out,clv_2_1,length(out)-1);
          if(contains(parL,fun), //210901from
            tmp3=Addpar(tmp3); //211029
          ); //210901to
          tmp=replace(rep_2_3,"xx",tmp1);
          tmp=replace(tmp,"yy",tmp2);
          out=replace(tmp,"zz",tmp3);
        );
        if(nn==4,
          tmp1=substring(out,plv_1_1,clv_1_1-1);
          tmp2=substring(out,clv_1_1,clv_2_1-1);
          tmp3=substring(out,clv_2_1,clv_3_1-1);
          if(contains(parL,fun), //210901from
            tmp3=Addpar(tmp3); //211029
          ); //210901to
          tmp4=substring(out,clv_3_1,length(out)-1);
		  if(indexof(out,"int(")>0, //231227from
		    if((length(tmp4)>0)&(substring(tmp4,0,1)!="d"),
			  tmp4="d"+tmp4;
            );
          );//231227to
          tmp=replace(rep_2_4,"xx",tmp1);
          tmp=replace(tmp,"yy",tmp2);
          tmp=replace(tmp,"zz",tmp3);
          out=replace(tmp,"ww",tmp4);
        );  //210831to
        out=pre+out+post;
        tmp=indexof(out,fun);
        ctr=ctr+1;
      );
    );
  );
  out=head+out;
  out=replace(out,"*"," ");
  out;
);
////%Totexform end////

////%Addasterisk start////
Addasterisk(strorg):=(
//help:Addasterisk("ax^2+bx+c");
  regional(str,out,sgnL,numL,alphaL,numalpha,ctr,
      pre,now,tmp,tmp1,tmp2);
  str=Removespace(strorg);
  str=replace(str,"  ","*");
  sgnL=["+","-","*","/","^"];
  numL=append(apply(0..9,text(#)),"."); //210226
  tmp1=32..126;
  tmp=(65..90)++(97..122);
  tmp1=remove(tmp1,tmp);
  alphaL=apply(tmp,unicode(text(#),base->10));
  numalpha=numL++alphaL;
  out=""; pre="@";
  while(length(str)>0,
    now=str_1;
    str=substring(str,1,length(str));
    if(now=="#",
      if(contains(numalpha++[")"],pre),out=out+"*");
      tmp=indexof(str,"#");
      out=out+"#"+substring(str,0,tmp-1);
      str=substring(str,tmp,length(str));
    );    
    if(contains(numL,now),
      if(contains(alphaL++[")"],pre),out=out+"*");
    );
    if(contains(alphaL++["("],now),
      if(contains(numalpha++[")"],pre),out=out+"*");
    );
    out=out+now;
    pre=now;
  );
  out;
);
////%Addasterisk end////

////%Tomaxform start//// 210821debugged
Tomaxform(str):=(
//help:Tomaxform("[comment]2cos(pi)");
  regional(plv,funL,repL,out,sub,head,flg,rep,fun,pre,post,ctr,clv,nn,
      sharpL,tmp,tmp1,tmp2,tmp3,tmp4);
  repL=[ //190515from
    ["fr(",["","((xx)/(yy))"]], //220505
    ["log(",["{log}(xx)","{log}(yy)/{log}(xx)"]], //240226
    ["sq(",["{sqrt}(xx)","(yy)^(1/(xx))"]], //240226
    ["po",["","(xx)^(yy)"]],
    ["sin(",["{sin}(xx)","{sin}(yy)^(xx)"]], //240226
    ["cos(",["{cos}(xx)","{cos}(yy)^(xx)"]], //240226
    ["tan(",["{tan}(xx)","{tan}(yy)^(xx)"]], //240226
    ["|(",["{abs}(xx)"]], //210902
    ["pi(",["{%pi}()"]]
  ];
  if(isstring(str),out=replace(str,"!",""), out=format(str,6)); //211118
  out=replace(out," ",""); //220617
  out=replace(out,"tfr(","fr(");//230505
  out=replace(out,"tfr(","fr(");//230505
  out=replace(out,"(cross)","*"); //220615
  out=replace(out,"dot()","*");//230505
  tmp=Bracket(out,"[]"); //210908from
  while(length(tmp)>0,
    tmp1=tmp_1_1;
    tmp2=tmp_2_1;
    out=substring(out,0,tmp1-1)+substring(out,tmp2,length(out));
    tmp=Bracket(out,"[]");
  ); //210908to
  out=replace(out,"pi","pi()"); //210805
  tmp=Indexall(out,"|"); //210902from
  forall(1..(length(tmp)/2),
    tmp2=tmp_(2*#);
    tmp1=substring(out,0,tmp2-1)+")";
    out=tmp1+substring(out,tmp2,length(out));
  );
  out=replace(out,"|","|(");//210902to
  out=Removespace(out);
  head="";
  flg=0;
  plv=Bracket(out,"()");
  if(length(plv)>0,
    if(plv_1_2==0,
      head=substring(out,0,plv_1_1);
      out=substring(out,plv_1_1,length(out));
      if(substring(out,0,1)=="*",out=substring(out,1,length(out)));
      plv=Bracket(out,"()");
    );
  );
  sharpL=[];
  ctr=1;
  if(flg==0,
    forall(repL,rep,
      fun=rep_1;
      tmp=indexof(out,fun);
      while((tmp>0)&(ctr<100),
        pre=substring(out,0,tmp-1);
        out=substring(out,tmp-1,length(out));
        plv=Bracket(out,"()");
        tmp=select(plv,#_2==-1);
        tmp=tmp_1;
        post=substring(out,tmp_1,length(out));
        out=substring(out,0,tmp_1);
        clv=Getlevel(out);
        clv=select(clv,#_2==1);
        nn=length(clv)+1;
        if(nn==1,
          tmp1=substring(out,plv_1_1,length(out)-1);

          out=replace(rep_2_1,"xx",tmp1);
        );
        if(nn==2,
          tmp1=substring(out,plv_1_1,clv_1_1-1);
          tmp2=substring(out,clv_1_1,length(out)-1);
          tmp=replace(rep_2_2,"xx",tmp1);
          out=replace(tmp,"yy",tmp2);
        );
        out=pre+out+post;
        tmp1=indexof(out,"{");
        tmp2=indexof(out,"}");
        sub=substring(out,tmp1,tmp2-1);
        tmp="#"+text(ctr)+"#";
        out=substring(out,0,tmp1-1)+tmp+substring(out,tmp2,length(out));
        sharpL=append(sharpL,[tmp,sub]);
        tmp=indexof(out,fun);
        ctr=ctr+1;
      );
    );
  );
  out=Addasterisk(out);
  out=replace(out,"()","");
  forall(reverse(sharpL),
    out=replace(out,#_1,#_2);
  );
  out=replace(head+out,"{",""); //230520
  out=replace(out,"e^","(exp(1))^"); //220610
  out;
);
////%Tomaxform end////

////%Tocindyform start////
Tocindyform(str):=(
//help:Tocindyform("fr(2,3)");
  regional(plv,funL,repL,out,sub,head,flg,rep,fun,pre,post,ctr,clv,nn,
      sharpL,tmp,tmp1,tmp2,tmp3,tmp4);
  repL=[ //190515from
    ["fr(",["","(xx)/(yy)"]],
    ["log(",["{log}(xx)","{log}(yy)/{log}(xx)"]], //220520
    ["sq(",["{sqrt}(xx)","(yy)^(1/(xx))"]], //190522
    ["po(",["","(xx)^(yy)"]],
    ["sin(",["{sin}(xx)","{sin}(yy)^(xx)"]], //190522from
    ["cos(",["{cos}(xx)","{cos}(yy)^(xx)"]],
    ["tan(",["{tan}(xx)","{tan}(yy)^(xx)"]],
    ["pi(",["{pi}()"]] //190522to
  ];
  out=replace(str,"(!","("); //210816,211118
  out=replace(out,"pi","pi()"); //210805
  out=replace(out,"tfr(","fr("); //220523
  out=replace(out," ",""); //220617
  out=replace(out,"(cross)","*"); //220615
  tmp1=""; //210817from
  flg=0;
  forall(1..(length(out)),
    tmp=out_#;
    if(contains(["[","]"],tmp),
      if(tmp=="[",flg=1);
      if(tmp=="]",flg=0);
    ,
      if(flg==0,tmp1=tmp1+tmp);
    );
  );
  out=tmp1; //210817to
  out=Removespace(out);
  head="";
  flg=0;
  plv=Bracket(out,"()");
  if(length(plv)>0,
    if(plv_1_2==0,
      head=substring(out,0,plv_1_1);
      out=substring(out,plv_1_1,length(out));
      if(substring(out,0,1)=="*",out=substring(out,1,length(out)));
      plv=Bracket(out,"()");
    );
    tmp=plv_(-1);
    if(tmp_2!=-1,
      out=str;
      flg=1;
    );
  );
  sharpL=[];
  ctr=1;
  if(flg==0,
    forall(repL,rep,
      fun=rep_1;
      tmp=indexof(out,fun);
      while((tmp>0)&(ctr<100),
        pre=substring(out,0,tmp-1);
        out=substring(out,tmp-1,length(out));
        plv=Bracket(out,"()");
        tmp=select(plv,#_2==-1);
        tmp=tmp_1;
        post=substring(out,tmp_1,length(out));
        out=substring(out,0,tmp_1);
        clv=Getlevel(out);
        clv=select(clv,#_2==1);
        nn=length(clv)+1;
        if(nn==1,
          tmp1=substring(out,plv_1_1,length(out)-1);
          out=replace(rep_2_1,"xx",tmp1);
        );
        if(nn==2,
          tmp1=substring(out,plv_1_1,clv_1_1-1);
          tmp2=substring(out,clv_1_1,length(out)-1);
          tmp=replace(rep_2_2,"xx",tmp1);
          out=replace(tmp,"yy",tmp2);
        );
        out=pre+out+post;        
        tmp1=indexof(out,"{"); //220520from
        tmp2=indexof(out,"}");
        sub=substring(out,tmp1,tmp2-1);
        tmp="#"+text(ctr)+"#";
        out=replace(out,"{"+sub+"}",tmp); //220520to
        sharpL=append(sharpL,[tmp,sub]);
        tmp=indexof(out,fun); //220513
        ctr=ctr+1;
      );
    );
  );
  out=Addasterisk(out);
  out=replace(out,"()","");
  forall(reverse(sharpL),
    out=replace(out,#_1,#_2);
  );
  out=head+out;
  out=replace(out,"e^","(exp(1))^"); //220610
  out;
);
////%Tocindyform end////

////%Getcindystr start////
Getcindystr(str):=Getcindystr(str,"");
Getcindystr(str,num):=(
//help:Getcindystr("val=sq(3)");
//help:Getcindystr("val=sq(3)",5);
//help:Getcindystr("a=sq(3);b=fr(1,2)",[3,2]);
  regional(numlist,out,semi,tmp,tmp1);
  if(islist(num),numlist=num,numlist=[num]); //200111
  out=[];
  semi=Strsplit(str,";");
  forall(1..(length(semi)),
    tmp1="";
    if(length(semi_#)>0,
      tmp=Strsplit(semi_#,"=");
      if(length(tmp)>1,tmp1=tmp_2,tmp1=tmp_1);
    );
    tmp1=Tocindyform(tmp1);
    if(length(tmp1)>0,
      if(isreal(numlist_#),tmp1=parse(tmp1));
    );
    out=append(out,tmp1);
  );
  if(length(out)==1,out=out_1);
  out;
);
////%Getcindystr end////

////%Animepar start//// //190524
Animepar(start,ratio,stop):=Animationparam(start,ratio,stop);
////%Animepar end////

////%Animationparam start////
Animationparam(start,ratio,stop):=( //190524
//help:Animationparam(S.x,5,30);
//help:Animationparam(0,5,[-100,100]);
//  Animeflg,sstart,Dirflg,Current,sorg are used in animation buttons
  regional(rng);
  if(islist(stop),rng=stop,rng=[start,stop]);
  if(isreal(Animeflg),
    if(Animeflg==1,
      sstart=Dirflg*ratio*seconds()+sorg;
    );
  ,
    Current=start;
    sstart=start;
  );
  if((sstart<=rng_1)%(sstart>=rng_2), //190528
    if(sstart<=rng_1,sstart=rng_1, sstart=rng_2); //190528
    stopanimation();
  );
  sstart;
);
////%Animationparam end////

////%Copyketcindyjs start//// 190128
Copyketcindyjs():=(
  regional(tmp,tmp1,tmp2,drive,fname);
  if(iswindows(),
    drive="C:";
    fname=Dirhead;
    tmp=indexof(fname,":");
    if(tmp>0,
      drive=substring(Dirwork,0,tmp);
      fname=substring(fname,tmp,length(fname));
    );
    kc():=(
      println("kc : "+kc(Dirwork+Batparent,Dirlib,Fnametex)); // 16.06.04
    );
    SCEOUTPUT = openfile(Batparent);
    println(SCEOUTPUT,drive);
    println(SCEOUTPUT,"cd "+Dqq(fname));
    println(SCEOUTPUT,"set xcp="+Dqq("\Windows\System32\xcopy"));
    println(SCEOUTPUT,"cd ketcindyjs");
    tmp1="%xcp%"+" /Y /Q /S /E /R ";
    tmp2=" "+Dqq(Dircdy+"ketcindyjs\");
    println(SCEOUTPUT,tmp1+"Cindy.js"+tmp2);
//    println(SCEOUTPUT,tmp1+"Cindy.js.map"+tmp2); //211215
    println(SCEOUTPUT,tmp1+"CindyJS.css"+tmp2);
    println(SCEOUTPUT,tmp1+"katex-plugin.js"+tmp2);
    println(SCEOUTPUT,tmp1+"webfont.js"+tmp2);
    println(SCEOUTPUT,tmp1+"jquery.min.js"+tmp2); //3.6.0 since 210724
    println(SCEOUTPUT,tmp1+"auto-render.min.js"+tmp2);
    println(SCEOUTPUT,tmp1+"auto-render11.min.js"+tmp2); //200517(trial)
    println(SCEOUTPUT,"cd katex");
    tmp1="%xcp%"+" /Y /Q /S /E /R ";
    tmp2=" "+Dqq(Dircdy+"ketcindyjs\katex\");
    println(SCEOUTPUT,tmp1+"katex.min.css"+tmp2);
    println(SCEOUTPUT,tmp1+"katex.min.js"+tmp2);
    println(SCEOUTPUT,tmp1+"katex11.min.css"+tmp2); //200517(trial)
    println(SCEOUTPUT,tmp1+"katex11.min.js"+tmp2); //200517(trial)
    tmp1="%xcp%"+" /Y /Q /S /E /R fonts";
    tmp2=" "+Dqq(Dircdy+"ketcindyjs\katex\fonts\");
    println(SCEOUTPUT,tmp1+tmp2);
    println(SCEOUTPUT,"exit 0");
    closefile(SCEOUTPUT);
  ,
    kc():=(
      println("kc : "+kc(Dirwork+Shellparent,Mackc+Dirlib,Fnametex));
    );
    tmp1=Dircdy; //190214from
    if(substring(tmp1,length(tmp1)-1,length(tmp1))=="/",
      tmp1=substring(tmp1,0,length(tmp1)-1);
    ); //190214to
    SCEOUTPUT = openfile(Shellparent);
    println(SCEOUTPUT,"#!/bin/sh");
    println(SCEOUTPUT,"cd "+Dqq(tmp1+"/")); //190214from
    println(SCEOUTPUT,"mkdir ketcindyjs");
    tmp2=Dqq(tmp1+"/ketcindyjs");
    println(SCEOUTPUT,"cd "+Dqq(Dirhead+"/ketcindyjs"));
    println(SCEOUTPUT,"cp -r -p katex "+tmp2); //210503from
    println(SCEOUTPUT,"cp -p Cindy.js "+tmp2);
//    println(SCEOUTPUT,"cp -p Cindy.js.map "+tmp2); //211215
    println(SCEOUTPUT,"cp -p CindyJS.css "+tmp2);
    println(SCEOUTPUT,"cp -p katex-plugin.js "+tmp2);
    println(SCEOUTPUT,"cp -p webfont.js "+tmp2); //190214to
    println(SCEOUTPUT,"cp -p jquery.min.js "+tmp2); //3.6.0 since 210724
    println(SCEOUTPUT,"cp -p auto-render.min.js "+tmp2);
    println(SCEOUTPUT,"cp -p auto-render11.min.js "+tmp2); //210503to
    println(SCEOUTPUT,"exit 0");
    closefile(SCEOUTPUT);
  );
  kc();
); 
////%Copyketcindyjs end//// 

////%Ketjsoption start//// 190201
Ketjsoption():=Setketcindyjs();
Ketjsoption(list):=Setketcindyjs(list);
////%Ketjsoption end////

////%Setketcindyjs start//// 190201
Setketcindyjs():=(
  KETJSOP;
);
Setketcindyjs(list):=(  // no ketjs on
//help:Setketcindyjs();
//help:Setketcindyjs(["Scale=(1)","Nolabel=[](or all)","Color=","Grid="]);
//help:Setketcindyjs(["Removept=[]"]);
  KETJSOP=list;
  KETJSOP;
);  // no ketjs off
////%Setketcindyjs end////

////%Ketcindyjsmain start//// 200119
Ketcindyjsmain(prelist):=Ketcindyjsmain(prelist,[]); // no ketjs on
Ketcindyjsmain(prelist,postlist):=( 
//help:Ketcindyjsmain(["<pf10/fp>_;Sample"]); // no ketjs on
//help:Ketcindyjsmain(["<pf10/fbr>_;Sample"],["<f5/fpbr>end"]);
//help:Ketcindyjsmain([<pf10red/fp>=<p><font size="10" color="red">...</font><p>]);
  JSMAIN=[[],[]];
  if(islist(prelist),JSMAIN_1=prelist,JSMAIN_1=[prelist]);
  if(islist(postlist),JSMAIN_2=postlist,JSMAIN_2=[postlist]);
  JSMAIN; // no ketjs off
); 
////%Ketcindyjsmain end////

////%Ketcindyjsdata start////  //201101
Ketcindyjsdata(datalistorg):=(
//help:Ketcindyjsdata(["ans1",ans1,"ans2",ans2]);
  regional(nn,tmp,tmp1,tmp2,tmp3,tmp4);
  if(!islist(KetcindyjsDataList),KetcindyjsDataList=[]); //190801
  datalist=datalistorg;
  forall(1..(length(datalist)/2), nn, //190423from
    tmp1=datalist_(2*nn-1);
    tmp2=datalist_(2*nn);
    if(islist(tmp2),
      tmp3=[];
      forall(tmp2,
        if(isstring(#),
          tmp=Dqq(#)
        ,
          tmp4=#;
          tmp=#_1;
          while(islist(tmp),
            tmp4=tmp;
            tmp=tmp_1;
          );
//          if(length(tmp4)==2,
//            tmp=format(Unscaling(#),12);
//          ,
            tmp=format(#,12)
//          );
        );
        tmp3=append(tmp3,tmp);
       );
    ,
      if(isstring(tmp2),tmp3=Dqq(tmp2),tmp3=format(tmp2,12));
    );
    tmp=tmp1+"="+text(tmp3);
    KetcindyjsDataList=append(KetcindyjsDataList,tmp);
    KetcindyjsDataList=set(KetcindyjsDataList); //190802
  );
);
Ketcindyjsdata(name,vaL):=(
  Ketcindyjsdata([name,vaL]);
);
////%Ketcindyjsdata end////

////%Findfun start////
Findfun(name,lineorg):=(
  regional(line,sep,pL,jj,kk,flg,rmv,out,tmp,tmp1,tmp2);
  line=Removespace(lineorg);
  rmv=[name,"regional","forall","if","text","curkernel","append","concat"];
  rmv=concat(rmv,["append","apply","allelements","indexof"]);
  rmv=concat(rmv,["substring","select","isstring","length"]);
  rmv=concat(rmv,["round","unicode","openfile","closefile","println","replace"]);
  rmv=concat(rmv,["setdirectory","parse","tokenize","import","load","ispoint"]);
  rmv=concat(rmv,["isreal","layer","autoclearlayer","drawpoly","allcircles"]);
  rmv=concat(rmv,["floor","flatten","prepend","islist","print","mod","abs","sum"]);
  rmv=concat(rmv,["cos","sin","tan","arccos","arcsin","arctan","sqrt","reverse","re"]);
  rmv=concat(rmv,["sort","contains","max","min","allpoints","isselected","common"]);
  rmv=concat(rmv,["inspect","iscircle","alllines","repeat","remove","format"]);
  rmv=concat(rmv,["ceil","while","dist","det","exp","err","arctan2","fillpoly"]);
  rmv=concat(rmv,["drawtext","mouse","allsegments","createpoint","create"]);
  rmv=concat(rmv,["gsave","connect","draw","grestore","wait"]);
  sep=[""," ",",","=","(","+","-","*","/","^","_","[",".","!","&","%",Dq,";",">","<",unicode("0009")];
  out=[];
  if(substring(line,0,2)!="//",
    pL=Indexall(line,"(");
    forall(pL,jj,
      flg=0;
      if(contains(pL,jj-1), flg=1);
      forall(reverse(1..(jj-1)),
        if(flg==0,
          if(#==1,
            tmp=substring(line,0,1);
            if(contains(sep,tmp),
             tmp=substring(line,1,jj-1);
            ,
             tmp=substring(line,0,jj-1);
            );
            flg=1;
          );
        );
        if(flg==0,
          tmp=substring(line,#-1,#);
          if(contains(sep,tmp),
            tmp=substring(line,#,jj-1);
            if(indexof(substring(line,0,#-1),"//")==0,
              flg=1;
            );
          );
        );
      );
      if((flg==1)&(length(tmp)>0),
        tmp1=Indexall(line,Dq); //190419from
        tmp1=select(tmp1,#<jj);
        if(mod(length(tmp1),2)==0,
          out=append(out,tmp);
        ); //190419
      );
    );
  );
  out=remove(out,rmv);
  tmp=out;
  out=[];
  forall(tmp,
    if(!contains(out,#),out=append(out,#));
  );
  out;
);
////%Findfun end////

////%Extractfun start////
Extractfun(strL):=(
  regional(nL,str,str2,start,sep,out,tmp,tmp1,tmp2);
  out=[];
  forall(strL,str,
    nL=Indexall(str,Dq);
    str2="";
    start=0;
    forall(1..(length(nL)/2),
      tmp1=nL_(2*#-1);
      str2=str2+substring(str,start,tmp1-1);
      start=nL_(2*#);
    );
    str2=str2+substring(str,start,length(str));
    fL=Findfun("csdraw",str2);
    out=remove(out,fL);
    out=concat(out,fL);
  );
);
////%Extractfun end////

//DL1=Readcsv(Dirhead+pathsep()+"ketcindyjs","basic1list.txt");
//DL2=Readcsv(Dirhead+pathsep()+"ketcindyjs","basic2list.txt");
//DL=concat(DL1,DL2);
//Out=[];

////%Extractall start////
Extractall(name):=(
  regional(fL,jj,tmp,tmp1,tmp2,tmp3,flg);
  fL=apply(Out,#_1);
  tmp1=select(DL,#_1==name);
  if(length(tmp1)>0,
    tmp1=tmp1_1;
    flg=0; //190417from
    forall(IgnoreList,#,
      if(flg==0,
        tmp2=#; tmp3=length(tmp2);
        tmp=indexof(tmp2,"*");
        if(tmp>0,
          tmp2=substring(#,0,tmp-1); tmp3=tmp-1;
        );
        if(substring(name,0,tmp3)==tmp2,
          flg=1;
        );
      );
    );
    if(flg==0, //190417to
      if(!contains(fL,tmp1),
        Out=append(Out,tmp1);
        fL=append(fL,tmp1_1);
        if(length(tmp1)>=5,
          forall(5..(length(tmp1)),jj,
            tmp=tmp1_jj;
            if(!contains(fL,tmp),
              tmp2=Out;
              Extractall(tmp);
              tmp2=remove(Out,tmp2);
            );
          );
        );
      );
    );  //190416
  );
  tmp1=Out;
  Out=[];
  forall(1..(length(tmp1)),
    if(!contains(Out,tmp1_#),
      Out=append(Out,tmp1_#);
    );
  );
  Out;
);
////%Extractall end////

////%Seteditable start////
Seteditable(no):=Seteditable(no,[]); //200524
Seteditable(no,optionorg):=(
//help:Seteditable(50,["y=","Size=18","Width=100"]);  //no ketjs on
  regional(options,size,width,str,eqL,tmp,tmp1); 
  options=optionorg;
  str="=";
  size="18";
  width="100";
  tmp=Divoptions(options);
  eqL=tmp_5;
  forall(eqL,
    tmp=Strsplit(#,"=");
    tmp1=Toupper(tmp_1); //201205
    if(tmp1=="SIZE",  //201205
      size=tmp_2;
      options=remove(options,[#]);
    );
    if(tmp1=="WIDTH",  //201205
      width=tmp_2;
      options=remove(options,[#]);
    );
  );
  forall(options,
    if(isstring(#),str=#);
  );
 tmp="inspect(Text"+text(no)+",";
  tmp=tmp+Dqq("colorfill")+",0);";
  parse(tmp);
  tmp="inspect(Text"+text(no)+",";
  tmp=tmp+Dqq("fillalpha")+",1);";
  parse(tmp);
  tmp="inspect(Text"+text(no)+",";
  tmp=tmp+Dqq("text.text")+","+Dqq(str)+");";
  parse(tmp);
  tmp="inspect(Text"+text(no)+",";
  tmp=tmp+Dqq("textsize")+","+size+");";
  parse(tmp);
  tmp="Text"+text(no)+".minwidth=";
  tmp=tmp+width+";";
  parse(tmp);   //no ketjs off
);
////%Seteditable end////

////%Textedit start//// 190430
Textedit(no):=(
//help:Textedit(50[,str[,"="]]);
//help:Textedit(50,str,"");
  regional(tmp,tmp1,tmp2);
  tmp="Text"+text(no)+".currenttext";
  tmp1=parse(tmp);
  tmp1;
);
Textedit(n0,str):=Textedit(n0,str,"="); //210406from
Textedit(n0,str,sep):=( //210208from
  regional(tmp,tmp1,tmp2,out);
  tmp1=str;
  //tmp1=Textedit(n0); //only ketjs
  tmp2=tmp1;
  if(length(sep)>0,
    tmp=Strsplit(sep+tmp1,sep);
    tmp2=tmp_(-1);
  ); //210406to
  if(length(tmp2)==0,out=str,out=tmp2);
  out;
); //210208to
////%Textedit end////

////%Subsedit start////
Subsedit(no,str):=(
//help:Subsedit(50,str);
 regional(tmp,tmp1);
 if(isstring(str),
   tmp1=str;
 ,
   tmp1=text(str);
 );
 tmp="Text"+text(no); //210211[2lines]
 parse(tmp).currenttext=tmp1;
);
////%Subsedit end////

////%Textedit2value start//// 190521
Textedit2value(no):=Textedit2value(no,[]);
Textedit2value(no,options):=(
//help:Textedit2value(50);
//help:Textedit2value(51,["Parse=y/n","Form=c/t/m"]);
  regional(str,tmp,tmp1,parseflg,formflg);
  parseflg="Y";
  formflg="C"; //190522
  forall(options,
    tmp=Strsplit(#,"=");
    tmp1=Toupper(substring(tmp_1,0,1));
    if(tmp1=="P",
      parseflg=Toupper(substring(tmp_2,0,1));
    );
    if(tmp1=="F",
      formflg=Toupper(substring(tmp_2,0,1));
    );
  );
  str=Textedit(no);
  str=Removespace(str);
  if(formflg=="C",
    str=Tocindyform(str);
    if(indexof(str,"?")>0,parseflg="N"); //190522
  );
  if(formflg=="T", //190522from
    str=Totexform(str);
    parseflg="N";
  );
  if(formflg=="M",
    str=Tomaxform(str);
    parseflg="N";
  ); //190522to
  if(length(str)>0,
    tmp=Strsplit(str,"=");
    if(length(tmp)>1,str=tmp_2);
  );
  if(length(str)==0, //190522from
    parseflg="N";
  ); //190522from
  if(parseflg=="Y",
    str=parse(str); //190522
  );
  str;
);
////%Textedit2value end////

////%Parsejson start////
Parsejson(json):=(
//help:Parsejson("{a:[1,2,[3,4],5],b:{1,2,3}}");
  regional(outL,symbolleftL,symbolrightL,symbolstack,stacksize,leftpos,rightpos,breakflg,strflg,flg);
  outL=[];
  symbolleftL =["[","{"];
  symbolrightL=["]","}"];
  leftpos=1;
  while(leftpos<=length(json),
    while( ( json_leftpos==" " % json_leftpos=="{" ) & leftpos<=length(json), leftpos=leftpos+1);
    rightpos=leftpos;
    symbolstack=" ";
    stacksize=0;
    breakflg=0;
    strflg=0;
    while(breakflg==0 & rightpos<=length(json),
      flg=0;
      if(strflg==0 & json_rightpos==unicode("0022"), // unicode("0022")='"'
         strflg=1;
         flg=1;
      );
      if(flg==0 & strflg==1 & json_rightpos==unicode("0022"),
         strflg=0;
         flg=1;
      );
      if(strflg==0,
        repeat(length(symbolleftL),
          if(flg==0 & stacksize>0,
            if(symbolstack_stacksize==symbolleftL_# & json_rightpos==symbolrightL_#,
              stacksize=stacksize-1;
              flg=1;
            );
          );
          if(flg==0 & json_rightpos==symbolleftL_#,
            stacksize=stacksize+1;
            symbolstack_stacksize=symbolleftL_#+" ";
            flg=1;
          );
        );
        if(flg==0 & json_rightpos==",",
          if(stacksize==0, breakflg=1);
          flg=1;
        );
        if(flg==0 & json_rightpos=="}",
          if(stacksize==0, breakflg=1);
          flg=1;
        );
      );
      if(breakflg==0,rightpos=rightpos+1);
    );
    if(leftpos<rightpos,outL=append(outL,substring(json,leftpos-1,rightpos-1)));
    leftpos=rightpos+1;
  );
  outL;
);
////%Parsejson end////

////%Resizetextsize start////
Resizetextsize(json,defaultsize,scale):=(
//help:Resizetextsize("{textsize: 10}",12,4);
//help:Resizetextsize("{aaa: bbb}",12,4);
  regional(out,propertiesL,textsize,existflg,breakflg);
  out=json;
  propertiesL=Parsejson(out);
  existflg=indexof(out,"textsize");
  if(existflg==0,
    if(length(propertiesL)>0,
      textsize="textsize: "+round(scale*defaultsize);
      out=replace(out,propertiesL_length(propertiesL),propertiesL_length(propertiesL)+", "+textsize);
    );
  );
  if(existflg>0,
    breakflg=0;
    forall(propertiesL,
      if(breakflg==0 & indexof(#,"textsize")>0,
        textsize="textsize: "+round(scale*parse(substring(#,indexof(#,":"),length(#))));
        out=replace(out,#,textsize);
        breakflg=1;
      );
    );
  );
  out;
);
////%Resizetextsize end////

////%Movetojs start////
Movetojs(geoorg,pos):=Movetojs(geoorg,pos,0); //210403
Movetojs(geoorg,pos,textsize):=(
//help:Movetojs(Text51,[1,2],12);
  regional(geo); //190729from
  geo=geoorg;
  if(isreal(geo),geo=parse("Text"+text(geo))); //190729to
  if(textsize>0, //210404from
    inspect(geo,"textsize",textsize);
  );  //210404to
  if(!islist(MOVETOJSLIST), MOVETOJSLIST=[]); //190802
  MOVETOJSLIST=append(MOVETOJSLIST,[geo.name,[pos_1,pos_2]]);
);
////%Movetojs end////

////%Movetojsexe start////
Movetojsexe(json):=(
  regional(out,geo,propertiesL,breakflg);
  out=json;
  geo=select(MOVETOJSLIST,indexof(json,"name: "+Dqq(#_1))>0);
  if(length(geo)>0,
    geo=geo_1;
    propertiesL=Parsejson(out);
    forall(propertiesL,
      breakflg=0;
      if(breakflg==0 & ( indexof(#,"pos:")>0 % indexof(#,"dock:")>0 ),
        out=replace(out,#,"pos: ["+geo_2_1+","+geo_2_2+",1]");
        breakflg=1;
      );
    );
  );
  out;
);
////%Movetojsexe end////

////%Setplaybuttons start////
Setplaybuttons(pt,font):=Setplaybuttons(pt_1,pt_2,font,[]);
Setplaybuttons(Arg1,Arg2,Arg3):=(
  if(islist(Arg1),
    Setplaybuttons(Arg1_1,Arg1_2,Arg2,Arg3);
  ,
    Setplaybuttons(Arg1,Arg2,Arg3,[]);
  );
);
Setplaybuttons(x,y,font,sporg):=(
//help:Setplaybuttons(-2,-6,14);
//help:Setplaybuttons([-2,-6],14,[1,1,1]);
  regional(x1,sp,tmp,tmp1);
  sp=sporg;
  tmp=length(sp);
  if(tmp==0,tmp1=0,tmp1=sp_tmp);
  tmp=apply(1..(3-tmp),tmp1);
  sp=concat(sp,tmp);
  x1=x;
  Movetojs(71,[x1,y],font);
  x1=x1+(0.84*font+sp_1)/10;
  Movetojs(72,[x1,y],font);
  x1=x1+(1.06*font+sp_2)/10;
  Movetojs(73,[x1,y],font);
  x1=x1+(0.76*font+sp_3)/10;
  Movetojs(74,[x1,y],font);
);
////%Setplaybuttons end////

////%Tohtmltagpf start//// 200506
Tohtmltagpf(sentence):=(
  regional(sent,tag,tmp,tmp1,tmp2,tmp3,tmp4);
  sent=replace(sentence,"_;","&emsp;");
  sent=Removespace(sent);
  tag="";
  if(substring(sent,0,1)=="<", //210122
    tmp=indexof(sent,">");
    tag=substring(sent,1,tmp-1);
    sent=substring(sent,tmp,length(sent));
  );
  if(indexof(tag,"/")>0, //200719
    tag=Strsplit(tag,"/");
  ,
    tag=[""];
  );
  tmp3=tag_1;
  tmp4=""; 
  while(length(tmp3)>0,
    tmp=substring(tmp3,0,1);
    tmp3=substring(tmp3,1,length(tmp3));
    if(tmp=="p",
      tmp4=tmp4+"<p>";
    );
    if(tmp=="f",
      tmp4=tmp4+"<font ";
      tmp=substring(tmp3,0,1);
      tmp3=substring(tmp3,1,length(tmp3));
      if(indexof("0123456789",tmp)>0,
        tmp4=tmp4+"size="+Dq;
        while((length(tmp)>0)&(indexof("0123456789",tmp)>0),
          tmp4=tmp4+tmp;
          tmp=substring(tmp3,0,1);
          tmp3=substring(tmp3,1,length(tmp3));
        );
        tmp4=tmp4+Dq;
      );
      if(length(tmp)>0,
        tmp3=Removespace(tmp3);
        tmp4=tmp4+" color="+Dqq(tmp+tmp3);
      );
    );
  );
  if(length(tmp4)>0,tmp4=tmp4+">"+sent,tmp4=sent); //200719
  if(length(tag)>1,
    tmp3=tag_2;
    forall(1..(length(tmp3)),
      tmp=tmp3_#;
      if(tmp=="f",tmp4=tmp4+"</font>");
      if(tmp=="p",tmp4=tmp4+"</p>");
      if(tmp=="b",tmp4=tmp4+"<br>");
    );
  );
  tmp4;
);
////%Tohtmltagpf end///

////%Ketcindyjsbody start//// 190909,200505(remove help)
Ketcindyjsbody(list1,list2):=Ketcindyjsbody([],list1,list2); //220719
Ketcindyjsbody(listtop,list1org,list2org):=( //220719
//help:Ketcindyjsbody([listtop,] listfront,listrear);
//help :Ketcindyjsbody(["<p,f10>_;_;Sample"],[]); //191004
//help :Ketcindyjsbody(Licecse(),Healine("title"),Copyright()); //191004
  regional(list1,list2); //220826from
  list1=list1org; list2=list2org;
  if(!islist(list1),list1=[list1]);
  if(!islist(list2),list2=[list2]); //220826to
  JSBODY=[listtop,list1,list2]; //220719
  JSBODY;
);
////%Ketcindyjsbody end////

////%License start//// 211217
License():=(
//help:License();
  regional(dtL);
  dtL=[
    "<!-- Copyright (C)  2014  Setsuo Takato, KETCindy Japan project team",
    "* This program is free software: you can redistribute it and/or modify",
    " it under the terms of the GNU General Public License as published by",
    " the Free Software Foundation; either version 3 of the License, or",
    " (at your option) any later version. ",
    "* This program is distributed in the hope that it will be useful,",
    " but WITHOUT ANY WARRANTY; without even the implied warranty of",
    " MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the",
    " GNU General Public License for more details.",
    "* You should have received a copy of the GNU General Public License",
    " along with this program.  If not, see <http://www.gnu.org/licenses/>",
    " -->"
  ];
  dtL
);
////%License end//// 

////%Headline start//// 220719,0826[3lines]
Headline(titleorg):=Headline("center",titleorg);
Headline(pos,titleorg):=(
//help:Headline(title);
//help:Headline("left",title);
  regional(title,tmp);
  title=titleorg;
  if(!islist(title),title=[title]);
  tmp="<header><p"; //220826[3lines]
  if(pos!="center",tmp=tmp+" align="+Dqq(pos));
  tmp=tmp+"><font size="+Dqq("6")+">";
  title=prepend(tmp,title);
  title=append(title,"</font></p></header>");
  title;
);
////%Headline end////

////%Copyright start//// 220719
Copyright():=(
//help:Copyright();
  regional(cpr);
  cpr="<footer><p align="+Dqq("center")+">";
  cpr=cpr+"<font size="+Dqq("4")+">";
  cpr=cpr+"&copy; 2021 Setsuo Takato</font></p></footer>";
  cpr;
);
////%Copyright end////

////%Mkketcindyjs start//// 190115
Mkketcindyjs():=Mkketcindyjs(KETJSOP); //190129 
Mkketcindyjs(options):=( //17.11.18
//help:Mkketcindyjs();
//help:Mkketcindyjs(options=["Scale=(1)","Lablel=[]","Nolabel=[]","Color=(offwhite)","Grid="]);
//help:Mkketcindyjs(optionsadd=["Web=(y)","Path=Dircdy","Ignore=","Remove=(list)"]);
//help:Mkketcindyjs(optionsadd2=["Equal=","Axes=","Figure=(n)","Lic=(y/n)"]);
  regional(webflg,localflg,htm,htmorg,from,upto,flg,fL,fun,jj,tmp,tmp1,tmp2,tmp3,tmp4,
      libnameL,libL,lib,jc,nn,name,partL,toppart,lastpart,path,ketflg,flg,cmdL,scale,license,
      nolabel,color,grid,axes,out,Out,igno,onlyflg,rmptL,colorrgb,ptname,eqflg,eqrep,
      figure,dpi,margin,defaultbuttonsize,defaulteditsize,fname,jssizeW,jssizeH,label);
  libnameL=["basic1","basic2","basic3","3d"]; //190416,190428
  webflg="Y";  //190128 texflg removed
  localflg="Y"; //190209,0215
  scale=1; //190129
  nolabel=["SW","NE"]; //190129
  label=[]; //210105
  color="offwhite"; //200611
  eqflg=0; //190603
  figure=0;
  dpi=86.4; // 12px/10pt = 12px/(10/72)in = 86.4dpi
  margin=5; // mm
  defaultbuttonsize=12; // px
  defaulteditsize=12; // px
  grid="";
  axes="";
  path=Dircdy;
  igno=[];
  license="N"; //211217
  rmptL=REMOVEPTJS;
  flg=0; //210105
  forall(options,
    tmp=Strsplit(#,"=");
    tmp1=Toupper(substring(tmp_1,0,2)); //211217
    tmp2=tmp_2;
    if(tmp1=="WE",
      if(length(tmp2)>0, //190209
        webflg=Toupper(substring(tmp2,0,1));
      );
    );
    if((tmp1=="SC")%(tmp1=="SI"), //211217
      if(length(tmp2)>0, //190209
        scale=parse(tmp2);
      );
    );
    if(tmp1=="NO", //211217
      if(length(tmp2)>0, //190209
        if(Toupper(tmp2)=="ALL", //190405from
          tmp2=remove(allpoints(),[SW,NE]);
          tmp2=text(tmp2);
        ); //190405to
        tmp=tmp2;
        if(indexof(tmp2,"[")>0,
          tmp=substring(tmp2,1,length(tmp2)-1);
        );
        tmp=tokenize(tmp,",");
        nolabel=concat(nolabel,tmp);
      );
      flg=1; //210105
    );
    if(tmp1=="LA", //211217
      tmp=tmp2; //210105from
      if(indexof(tmp2,"[")>0,
        tmp=substring(tmp2,1,length(tmp2)-1);
      );
      tmp=tokenize(tmp,",");
      label=concat(label,tmp);  //210105to
    );
    if(tmp1=="LI", //211217from
      license=Toupper(substring(tmp2,0,1));
    );  //211217to
    if(tmp1=="CO", //190209,//211217
      if(length(tmp2)>0,
        color=tmp2;
      );
    );
    if(tmp1=="GR", //211217
      if(length(tmp2)>0,
        grid=tmp2;
      );
    );
    if(tmp1=="AX", //211217
      if(length(tmp2)>0,
        tmp2=Toupper(substring(tmp2,0,1)); //190729[2lines]
        if(contains(["N","F"],tmp2),axes="false");
      );
    );
    if(tmp1=="EQ", //190603from//211217
      eqflg=1;
      if(length(tmp2)>0,
        eqrep=tmp2;
      ,
        eqrep="";
      );
    );  //190603to
    if(tmp1=="PA", //211217
      if(!tmp2="Dircdy",
        path=tmp2;
      );
    );
    if(tmp1=="IG",  //190417from//211217
      if(substring(tmp2,0,1)=="[",
        tmp2=substring(tmp2,1,length(tmp2)-1);
        igno=tokenize(tmp2,",");
      );
    );  //190417to
    if(tmp1=="RM",  //190503from //211217
      if(substring(tmp2,0,1)=="[",
        tmp2=substring(tmp2,1,length(tmp2)-1);
        tmp2=tokenize(tmp2,",");
        rmptL=concat(rmptL,tmp2);
      );  //190503to
    );  //190503to
    if(tmp1=="FI", //211217
      if(length(tmp2)>0,
        if(Toupper(substring(tmp2,0,1))=="Y",figure=1,figure=0);
      );
    );
  );
  if(flg==0, //210105from
    tmp=apply(allpoints(),text(#));
    nolabel=remove(tmp,label);
  ); //210105to
  if(indexof(color,"[")>0,  //200505
    tmp=parse(color);
    if(length(tmp)==4,
      colorrgb=Colorcmyk2rgb(tmp); //190504
    ,
      colorrgb=color; //190506
    );
  ,
    tmp=Colorname2cmyk(color); //200505[2lines]
    colorrgb=Colorcmyk2rgb(tmp);
  ); //190503to
  tmp=apply(colorrgb,round(#*255)); //190504
  tmp=text(tmp);
  color=substring(tmp,1,length(tmp)-1);
  if((webflg=="N")&(localflg=="Y"),
    if(!isexists(Dircdy,"ketcindyjs"),
      Copyketcindyjs();
      println("ketcindyjs has been copied");
    );
  );
  if(!isexists(Dircdy,Fhead+".html"),
    drawtext(mouse().xy-[0,1],Cdyname()+".html not found",size->24,color->[0,0,1]);
    wait(3000);
  ,
    tmp3=Readlines(Dircdy,Fhead+".html"); //210428from
    tmp2=select(1..(length(tmp3)),indexof(tmp3_#,"import")>0);
    partL=select(tmp2,indexof(tmp3_#,".ini")==0);
    tmp4=tmp3;
    forall(1..(length(partL)),nn,
      tmp1=partL_nn;
      if(nn==1,
        tmp4=tmp3_(1..(tmp1-1));
      ,
        tmp=partL_(nn-1)+1;
        tmp4=concat(tmp4,tmp3_(tmp..(tmp1-1)));
      );
      tmp=tmp3_tmp1;
      tmp2=Removespace(tmp3_tmp1);
      if(substring(tmp2,0,2)!="//",
        tmp2=replace(tmp2,"Cdyname()",Dqq(Cdyname())); //210513from
        tmp2=replace(tmp2,"cdyname()",Dqq(Cdyname()));
        tmp=Bracket(tmp2,"()");
        tmp1=substring(tmp2,tmp_1_1,tmp_2_1-1);
        tmp1=parse(tmp1); //210513to
        If(isexists(Dircdy,tmp1),
          tmp=Readlines(Dircdy,tmp1);
          tmp4=concat(tmp4,tmp);
        );
      );
      if(nn==length(partL),
        tmp1=partL_nn;
        tmp4=concat(tmp4,tmp3_((tmp1+1)..(length(tmp3))));
      );
    );
    tmp3=tmp4; //210428to
    htmorg=[];
    from=1;
    upto=length(tmp3);
    htmorg=concat(htmorg,tmp3_(from..upto));
    tmp=select(1..(length(htmorg)),indexof(htmorg_#,"id="+Dqq("csinit"))>0); //190206from
    from=tmp_1+5;
    flg=0;
    forall(from..(length(htmorg)),
      if(flg==0,
        if(indexof(htmorg_#,"</script>")>0,
         upto=#-1;
         flg=1;
        );
      );
    );
    tmp2=[];
    ketflg="off"; 
    onlyflg="off"; //190502
    forall(htmorg_(from..upto),
      if(indexof(#,"only ketjs on")>0,onlyflg="on"); //190502
      if(indexof(#,"only ketjs off")>0,onlyflg="off"); //190502
      if(indexof(#,"no ketjs")>0,
        if(indexof(#,"no ketjs on")>0,
          ketflg="on";
        );
        if(indexof(#,"no ketjs off")>0,
          ketflg="off";
        );
      ,
        if(ketflg=="off",
          tmp=Removespace(#);
          if(substring(tmp,0,2)!="//",
            tmp2=append(tmp2,#);
          ,
            tmp1=indexof(tmp,"only ketjs"); //190430from
            if((tmp1>0)%(onlyflg=="on"), //190502
              if(tmp1>0,tmp=substring(#,0,tmp1-1)); //190502
              tmp2=append(tmp2,substring(tmp,2,length(tmp)));
            ); //190430to
          );
        );
      );
    );
    tmp=select(1..(length(htmorg)),indexof(htmorg_#,"id="+Dqq("csdraw"))>0);
    from=tmp_1+1;
    flg=0;
    forall(from..(length(htmorg)),
      if(flg==0,
        if(indexof(htmorg_#,"</script>")>0,
         upto=#-1;
         flg=1;
        );
      );
    );
    ketflg="off"; 
    onlyflg="off"; //190502
    forall(htmorg_(from..upto),
      if(indexof(#,"only ketjs on")>0,onlyflg="on"); //190502
      if(indexof(#,"only ketjs off")>0,onlyflg="off"); //190502
      if(indexof(#,"no ketjs")>0,
        if(indexof(#,"no ketjs on")>0,
          ketflg="on";
        );
        if(indexof(#,"no ketjs off")>0,
          ketflg="off";
        );
      ,
        if(ketflg=="off",
          tmp=Removespace(#);
          if(substring(tmp,0,2)!="//",
            tmp2=append(tmp2,#);
          ,
            tmp1=indexof(tmp,"only ketjs"); //190430from
            if((tmp1>0)%(onlyflg=="on"), //190502
              if(tmp1>0,tmp=substring(#,0,tmp1-1)); //190502
              tmp2=append(tmp2,substring(tmp,2,length(tmp)));
            ); //190430to
          );
        );
      );
    );
    fL=Extractfun(tmp2); //190206to
    DL=[];
    forall(libnameL,name, //190209from
      tmp2=Readlines(Dirhead+pathsep()+"ketcindyjs",name+"list.txt");
      tmp1=[];
      forall(1..(length(tmp2)),nn,
        tmp=Indexall(tmp2_nn,",");
        from=0;
        tmp3=[];
        forall(tmp,
          tmp3=append(tmp3,substring(tmp2_nn,from,#-1));
          from=#;
        );
        tmp3=append(tmp3,substring(tmp2_nn,from,length(tmp2_nn)));
        tmp1=append(tmp1,tmp3);
      );      
      DL=concat(DL,tmp1); //DL and Out are necessary for Extractall
    ); //190209to
    tmp=Readlines(Dirhead+pathsep()+"ketcindyjs","ignoredfun.txt"); //190416from
    tmp=apply(tmp,Removespace(#)); //190131
    IgnoreList=select(tmp,(length(#)>0)&(substring(#,0,2)!="//")); //190131//190416to
    IgnoreList=concat(IgnoreList,igno); //190417
    Out=[]; // necessary for Extractall
    forall(fL,fun,
      Extractall(fun);
    );
//    tmp1=select(Out,contains(igL,#_1)); //190416
//    Out=remove(Out,tmp1); USEDFUN=apply(Out,#_1); //190130 //190416
    tmp1=select(1..(length(htmorg)),indexof(htmorg_#,"script id=")>0);
    partL=[];
    forall(tmp1,nn,
      from=nn;
      tmp2=htmorg_from;
      tmp=Indexall(tmp2,Dq);
      name=substring(tmp2,tmp_1,tmp_2-1);
      tmp=select((from+1)..(length(htmorg)),indexof(htmorg_#,"</script>")>0);
      upto=tmp_1;
      partL=append(partL,[name,from,upto]);
    );
    tmp=apply(partL,#_2);
    tmp=min(tmp)-1;
    toppart=[1,tmp];
    tmp=apply(partL,#_3);
    tmp=max(tmp)+1;
    lastpart=[tmp,length(htmorg)];
    if(webflg=="Y",
      fname=Fhead+"json.html";
    ,
      fname=Fhead+"jsoff.html"; //200116[2lines]
      if(localflg=="Y",fname=replace(fname,"off.","offL."));
    );
    setdirectory(path);
    SCEOUTPUT = openfile(fname);
    forall(JSBODY_1,println(SCEOUTPUT,#)); //220719
    if(license=="Y", //211217from
      tmp1=Licensedata();
    ,
      tmp1=[];
    );
    tmp1=concat(tmp1,htmorg_((toppart_1)..(toppart_2)));  //211217to
    tmp1=apply(tmp1,replace(#,"v0.8/","v0.8.8/"));
    if(webflg=="N",
      if(localflg=="N", //190128
        tmp3=replace(Dirhead+"/ketcindyjs/",pathsep(),"/");
        tmp= "    <link rel="+Dqq("stylesheet")+" href=";
        tmp=tmp+Dq+"file:///"+tmp3+"CindyJS.css"+Dq+">";
        tmp1_(length(tmp1)-2)=tmp;
        tmp= "    <script type="+Dqq("text/javascript")+" src=";
        tmp=tmp+Dq+"file:///"+tmp3+"Cindy.js"+Dq+"></script>";
        tmp1_(length(tmp1)-1)=tmp;
        tmp="    <script type="+Dqq("text/javascript")+" src="; //190117from
        tmp1_(length(tmp1))="";  //190120
      ,
        tmp1_(length(tmp1)-2)=    //190128from
         "    <link rel="+Dqq("stylesheet")+" href="+Dqq("ketcindyjs/CindyJS.css")+">"; //190203
        tmp1_(length(tmp1)-1)=
         "   <script type="+Dqq("text/javascript")+" src="+Dqq("ketcindyjs/Cindy.js")+"></script>"; 
             //190203
        tmp1_(length(tmp1))=""; //190128to
      );
    ,      
      tmp1_(length(tmp1))=""; //190117to
    );
    forall(tmp1,
      println(SCEOUTPUT,#);
    );
    tmp="<script id="+Dqq("csinit")+" type=";
    tmp=tmp+Dqq("text/x-cindyscript")+">";
    println(SCEOUTPUT,tmp);
    println(SCEOUTPUT,"Invert(x):=reverse(x);"); //201111
//    tmp=Readlines(Dirhead+pathsep()+"ketcindyjs","commonused.txt");
//    forall(tmp,
//     println(SCEOUTPUT,#);
//    );
    libL=[]; //190209from
    forall(libnameL,
      tmp=Readlines(Dirhead+"/ketlib","ketcindylib"+#+"r.cs");
      libL=append(libL,tmp);
    ); //190209to
    forall(Out,fun,
      libf=fun_2;from=parse(fun_3);upto=parse(fun_4);
      tmp=select(1..(length(libnameL)),indexof(libf,libnameL_#)>0); //190209from
      tmp=tmp_1;
      lib=libL_tmp;
      tmp1=lib_(from..upto); //190209from
      ketflg="off"; //190122from
      onlyflg="off"; //190502
      forall(tmp1,
        if(indexof(#,"only ketjs on")>0,onlyflg="on"); //190502
        if(indexof(#,"only ketjs off")>0,onlyflg="off"); //190502
        if(indexof(#,"no ketjs")>0,
          if(indexof(#,"no ketjs on")>0,
            ketflg="on";
          );
          if(indexof(#,"no ketjs off")>0,
            ketflg="off";
          );
        ,
          if(ketflg=="off",
            tmp=Removespace(#);
            if(substring(tmp,0,2)!="//",
              println(SCEOUTPUT,#);
            ,
              tmp4=indexof(tmp,"only ketjs"); //190430from, //200619[tmp4]
              if((tmp4>0)%(onlyflg=="on"), //190502
                if(tmp4>0,tmp=substring(tmp,0,tmp4-1)); //190502,200619debugged
                println(SCEOUTPUT,substring(tmp,2,length(tmp)));
              ); //190430to
            );
          ); //190122to
        );
      );
    );
    Ketcindyjsdata(["Ketcindyjsfigure",figure,"Ketcindyjsscale",scale]);//190801from[moved]
    forall(KetcindyjsDataList, 
      println(SCEOUTPUT,#+";");
    ); //190801to[moved]
    tmp=select(partL,#_1=="csinit");
    if(length(tmp)>0,
      tmp=tmp_1;
      from=tmp_2; //190905from
      flg=0;
      forall(1..6,
        if(flg==0,
          if(indexof(htmorg_from,"ketcindy.ini")>0,
            flg=1;
          );
          from=from+1;
        );
      );//190905to
      upto=tmp_3;
      tmp1=htmorg_((from)..(upto-1)); //190905
      ketflg="off"; //190206from
      onlyflg="off";  //190502
      forall(tmp1,tmp3,
        if(indexof(tmp3,"only ketjs on")>0,onlyflg="on"); //190502
        if(indexof(tmp3,"only ketjs off")>0,onlyflg="off"); //190502
        if(indexof(tmp3,"no ketjs")>0,
          if(indexof(tmp3,"no ketjs on")>0,
            ketflg="on";
          );
          if(indexof(tmp3,"no ketjs off")>0,
            ketflg="off";
          );
        ,
          if(ketflg=="off",
            tmp=Removespace(tmp3);
            if(substring(tmp,0,2)!="//",
              println(SCEOUTPUT,tmp3);
            ,
              tmp1=indexof(tmp,"only ketjs"); //19020l6from
              if((tmp1>0)%(onlyflg=="on"), //190502
                if(tmp1>0,tmp=substring(tmp3,0,tmp1-1)); //190502
                println(SCEOUTPUT,substring(tmp,2,length(tmp)));
              ); //190206to
            );
          );
        );
      ); 
    );
    println(SCEOUTPUT,"</script>");
    tmp=select(partL,#_1=="csdraw");
    tmp=tmp_1;
    from=tmp_2;
    upto=tmp_3;
    tmp1=htmorg_(from..upto);
    ketflg="off"; //190202from
    onlyflg="off"; //190502
    forall(tmp1,
      if(indexof(#,"only ketjs on")>0,onlyflg="on"); //190502
      if(indexof(#,"only ketjs off")>0,onlyflg="off"); //190502
      if(indexof(#,"no ketjs")>0,
        if(indexof(#,"no ketjs on")>0,
          ketflg="on";
        );
        if(indexof(#,"no ketjs off")>0,
          ketflg="off";
        );
      ,
        if(ketflg=="off",
          tmp=Removespace(#);
          if(substring(tmp,0,2)!="//",
            println(SCEOUTPUT,#);
          ,
            tmp1=indexof(tmp,"only ketjs"); //19020l6from
            if((tmp1>0)%(onlyflg=="on"), //190502
               if(tmp1>0,tmp=substring(tmp,0,tmp1-1)); //190502
               println(SCEOUTPUT,substring(tmp,2,length(tmp))); //190502
            ); //190206to
          );
        );
      );
    ); //190206to 
    tmp1=htmorg_((lastpart_1)..(lastpart_2));
    tmp=select(1..(length(tmp1)),indexof(tmp1_#,Dqq("cs*"))>0);
    tmp=tmp_1;
    forall(1..tmp, //190117from
      println(SCEOUTPUT,tmp1_#);
    );
    from=tmp+1; //190117to
    tmp="  use: ["+Dqq("katex")+"],";
    println(SCEOUTPUT,tmp);
    out=[];  //190129
    forall(from..(length(tmp1)),jj,
      flg=0; //190126from
      tmp2=["Figure","Parent","ParaF","Anime","Flip","Title","Slide","Digest",
                 "KeTJS","KeTjsoff","Ketjson","KeTJSoff","Ketjsoff","Objview"]; //210122
      if(indexof(tmp1_jj,"type: "+Dqq("Button"))>0,
        nn=indexof(tmp1_jj,"text: ");
        tmp=substring(tmp1_jj,nn-1,length(tmp1_jj));
        nn=Indexall(tmp,Dq);
        tmp=substring(tmp,nn_1,nn_2-1);
        if(!contains(tmp2,tmp),
          tmp1_jj=Movetojsexe(tmp1_jj);
          if(figure>0,tmp1_jj=Resizetextsize(tmp1_jj,defaultbuttonsize,scale));
          out=append(out,tmp1_jj); //190129
        );
        flg=1;
      );
      if(flg==0, //200520from
        if(indexof(tmp1_jj,"Editable")>0,
          tmp=tmp1_jj;
          if(eqflg==1,tmp=replace(tmp,"=",eqrep)); //190604
          tmp=Movetojsexe(tmp);
          if(figure>0,tmp=Resizetextsize(tmp,defaulteditsize,scale));
          out=append(out,tmp);
          flg=1;
        );
      ); //200520to
      if(flg==0,
        if(indexof(tmp1_jj,"Evaluate")>0,
          tmp=replace(tmp1_jj,Dqq("Evaluate"),Dqq("EditableText"));
          if(eqflg==1,tmp=replace(tmp,"=",eqrep)); //190604
          tmp=Movetojsexe(tmp);
          if(figure>0,tmp=Resizetextsize(tmp,defaulteditsize,scale));
          out=append(out,tmp);
          flg=1;
        );
      );
      if(flg==0,
        if(indexof(tmp1_jj,"Calculation")>0,
          tmp=replace(tmp1_jj,Dqq("Calculation"),Dqq("EditableText"));
          tmp=Movetojsexe(tmp);
          if(eqflg==1,tmp=replace(tmp,"=",eqrep)); //190604
          if(figure>0,tmp=Resizetextsize(tmp,defaulteditsize,scale));
          out=append(out,tmp);
          flg=1;
        );
      );
      tmp=indexall(tmp1_jj,Dq); //190504from
      if(length(tmp)>0,
        ptname=substring(tmp1_jj,tmp_1,tmp_2-1);
      ,
        ptname="";
      );
      if(flg==0,
        if(contains(rmptL,ptname), flg=1);
      ); 
      tmp2=tmp1_jj;
      if(length(ptname)>0,
        if(indexof(tmp2,"size:")==0,
          tmp2=replace(tmp2,"}",", size: 3.0}");
        );
        if(indexof(tmp2,"border:")==0,
          tmp2=replace(tmp2,"}",", border: true }");
        );
      );
      if(flg==0,
        tmp=Indexof(tmp2,"labeled: ");
        if((ptname=="")%(tmp==0),
          out=append(out,tmp2);
          flg=1;
        );
      );
      if(flg==0,
        if(contains(["TH","FI"],ptname),
          if(SLIDEFLG=="Y",
            out=append(out,tmp2);
            flg=1;
          );
        );
      );
      if(flg==0,
        if(contains(nolabel,ptname),
          tmp2=replace(tmp2,"labeled: true","labeled: false");
        );
        if((indexof(ptname,"z")>0)%(contains(["NE","SW","TH","FI"],ptname)),
          if(indexof(ptname,"z")>0,
            tmp2=replace(tmp2,"labeled: true","labeled: false");
          );
          tmp=indexof(tmp2,"color:");
          tmp3=Indexall(tmp2,"],");
          tmp3=select(tmp3,#>tmp);
          if(length(tmp3)>0,
            tmp3=tmp3_1;
          ,
            tmp3=indexof(tmp2,"]}");
          );
          tmp=substring(tmp2,tmp-1,tmp3);
          tmp2=replace(tmp2,tmp,"color: [1.0,1.0,1.0]");
//          tmp2=replace(tmp2,"color: tmp,"color: "+text(colorrgb));
          tmp2=replace(tmp2,"border: true","border:false");
          tmp=indexof(tmp2," size:");
          tmp3=Indexall(tmp2,",");
          tmp3=select(tmp3,#>tmp);
          if(length(tmp3)>0,
            tmp3=tmp3_1;
          ,
            tmp3=indexof(tmp2,"}");
          );
          tmp=substring(tmp2,tmp-1,tmp3-1);
          tmp2=replace(tmp2,tmp," size: 2.0");
        );
        out=append(out,tmp2);
        flg=1;
      ); //190504to
      if(flg==0,
        if(length(tmp1_jj)>0, //190504from
          out=append(out,tmp1_jj);
        ); //190504to
      ); //190126to
    );
    tmp=select(1..(length(out)),indexof(out_#," ],")>0); //190129from
    tmp=tmp_1;
    tmp1=out_(tmp-1);
    if(substring(tmp1,length(tmp1)-1,length(tmp1))==",", //190201from
      out_(tmp-1)=substring(tmp1,0,length(tmp1)-1);
    ); //190201to
    if(figure==0,
      tmp=select(1..(length(out)),indexof(out_#," width:")>0);
      jj=tmp_1;
      tmp1=out_jj;
      flg=0;
      forall(1..(length(tmp1)-1),
        if(flg==0,
          tmp=substring(tmp1,#-1,#);
          if(tmp==":",
            tmp2=substring(tmp1,#+1,length(tmp1)-1);
            flg=1;
          );
        );
      );
      jssizeW=round(scale*parse(tmp2));
      out_jj="    width: "+text(jssizeW)+",";
      tmp=select(1..(length(out)),indexof(out_#," height:")>0);
      jj=tmp_1;
      tmp1=out_jj;
      flg=0;
      forall(1..(length(tmp1)-1),
        if(flg==0,
          tmp=substring(tmp1,#-1,#);
          if(tmp==":",
            tmp2=substring(tmp1,#+1,length(tmp1)-1);
            flg=1;
          );
        );
      );
      jssizeH=round(scale*parse(tmp2));
      out_jj="    height: "+text(jssizeH)+",";
    );
    if(figure>0,
      tmp=select(1..(length(out)),indexof(out_#,"width:")>0);
      jj=tmp_1;
      jssizeW=round(dpi*scale*(XMAX-XMIN+margin/10*2)*10/25.4);
      out_jj="    width: "+text(jssizeW)+",";
      tmp=select(1..(length(out)),indexof(out_#,"height:")>0);
      jj=tmp_1;
      jssizeH=round(dpi*scale*(YMAX-YMIN+margin/10*2)*10/25.4);
      out_jj="    height: "+text(jssizeH)+",";
      tmp=select(1..(length(out)),indexof(out_#,"transform:")>0);
      jj=tmp_1;
      tmp="    transform: [{visibleRect: ["+text(XMIN-margin/10)+","+text(YMAX+margin/10);
      out_jj=tmp+","+text(XMAX+margin/10)+","+text(YMIN-margin/10)+"]}],";
    );
    if(length(color)>0,
      tmp=select(1..(length(out)),indexof(out_#,"background: ")>0);
      jj=tmp_1;
      tmp=indexof(out_jj,")"); //190130from
      tmp=substring(out_jj,tmp-1,length(out_jj));
      out_jj="    background: "+Dq+"rgb("+color+tmp; //190130to
    );
    if(length(grid)>0,
      tmp=select(1..(length(out)),indexof(out_#,"grid:")>0);
      jj=tmp_1;
      tmp1="    grid: "+grid;
      if(indexof(out_jj,",")>0,
        tmp1=tmp1+",";
      );
      out_jj=tmp1;
    );
    if(length(axes)>0,
      tmp=select(1..(length(out)),indexof(out_#,"axes:")>0);
      if(length(tmp)>0,
        jj=tmp_1;
        tmp1="    axes: "+axes;
        if(indexof(out_jj,",")>0,
          tmp1=tmp1+",";
        );
        out_jj=tmp1;
      );
    );
    forall(out,tmp1, //190910from
      if(indexof(tmp1,"</body>")==0,
        println(SCEOUTPUT,tmp1);
        if(indexof(tmp1,"<body>")>0,
          forall(JSBODY_2, //220719
            tmp2=replace(#,"_;","&emsp;");
            tmp2=Removespace(tmp2); //200911(next block removed)
            println(SCEOUTPUT,tmp2);
          );
        );
      ,
        forall(JSBODY_3, //220719
          tmp2=replace(#,"_;","&emsp;");
          tmp2=Removespace(tmp2);  //200911(next block removed)
          println(SCEOUTPUT,tmp2);
        );
        println(SCEOUTPUT,tmp1); //200911
      ); 
    ); //190910to
    closefile(SCEOUTPUT);
    if(length(JSMAIN)>0, //200119from
      if(webflg=="Y",tmp="mainon.html",tmp="mainoff.html"); //200506[2lines]
      SCEOUTPUT = openfile(Fhead+tmp); 
      forall(JSBODY_1,println(SCEOUTPUT,#)); //220719
      println(SCEOUTPUT,"<!DOCTYPE html>");
      println(SCEOUTPUT,"<html>");
      println(SCEOUTPUT,"<head>");
      println(SCEOUTPUT,"<meta charset="+Dqq("utf-8")+">");
      println(SCEOUTPUT,"<title>Page of "+Fhead+"</title>");
//      // for Mathjax
//      println(SCEOUTPUT,"<script src="+Dqq("https://polyfill.io/v3/polyfill.min.js?features=es6")+"></script>");
//      tmp=Dqq("MathJax-script")+" async src=";
//      tmp=tmp+Dqq("https://cdn.jsdelivr.net/npm/mathjax@3/es5/tex-mml-chtml.js");
//      println(SCEOUTPUT,"<script id="+tmp+"></script>");
      if(webflg=="Y", 
        println(SCEOUTPUT,"<script src="+
            Dqq("https://ajax.googleapis.com/ajax/libs/jquery/3.6.0/jquery.min.js")+"></script>");//210724
        println(SCEOUTPUT,"<link rel="+Dqq("stylesheet")+" href="+
            Dqq("https://cdnjs.cloudflare.com/ajax/libs/KaTeX/0.11.1/katex.min.css")+" />"); //200517(trial)
        println(SCEOUTPUT,"<script src="+
            Dqq("https://cdnjs.cloudflare.com/ajax/libs/KaTeX/0.11.1/katex.min.js")+"></script>"); //200517(trial)
        println(SCEOUTPUT,"<script src="+
            Dqq("https://cdnjs.cloudflare.com/ajax/libs/KaTeX/0.11.1/contrib/auto-render.min.js")+"></script>"); //200517(trial)
      , 
        println(SCEOUTPUT,"<script src="+Dqq("ketcindyjs/jquery.min.js")+"></script>"); //200122
        println(SCEOUTPUT,"<link rel="+Dqq("stylesheet")+" href="+Dqq("ketcindyjs/katex/katex11.min.css")+" />"); //200517(trial)
        println(SCEOUTPUT,"<script src="+Dqq("ketcindyjs/katex/katex11.min.js")+"></script>"); //200517(trial)
        println(SCEOUTPUT,"<script src="+Dqq("ketcindyjs/auto-render11.min.js")+"></script>"); //200517(trial)
      ); 
      tmp="<script>$(document).ready(function(){renderMathInElement(document.body,{delimiters: ";
      tmp=tmp+"[{left: "+Dqq("[[")+", right: "+Dqq("]]")+", display: true},";
      tmp=tmp+"{left: "+Dqq("$")+", right: "+Dqq("$")+", display: false}]})});</script>";
      println(SCEOUTPUT,tmp); //200122to
      if(isexists(Dircdy,Cdyname()+".css"), //200727from
        tmp="<link rel="+Dqq("stylesheet")+" type="+Dqq("text/css")+" href="+Dqq(Cdyname()+".css")+"/>";
        println(SCEOUTPUT,tmp);
      );  //200727to
      println(SCEOUTPUT,"</head>");
      println(SCEOUTPUT,"<body");    
      println(SCEOUTPUT,"<p></p>"); 
      forall(JSMAIN_1,tmp1,
        tmp2=Tohtmltagpf(tmp1);
        println(SCEOUTPUT,tmp2);
      );
      println(SCEOUTPUT,"<p></p>");
      tmp="<p align="+Dqq("center")+"><iframe src="+Dqq(fname)+" width="+Dqq(jssizeW); //200802[2lines]
      tmp=tmp+" height="+Dqq(jssizeH)+"></iframe></p>";
      println(SCEOUTPUT,tmp);    
      forall(JSMAIN_2,tmp1,
        tmp2=Tohtmltagpf(tmp1);
        println(SCEOUTPUT,tmp2);
      );
      println(SCEOUTPUT,"<p></p>");
      println(SCEOUTPUT,"</body>");    
      println(SCEOUTPUT,"</html>");
      closefile(SCEOUTPUT);
    ); //200119to
    setdirectory(Dirwork);
//    if(webflg=="Y",tmp="json",tmp="jsoff");
    drawtext(mouse().xy-[0,1],"Generate : "+fname,size->20,color->[0,0,0]);
    wait(1000);
  );
);
////%Mkketcindyjs end////

////%Settextkey start////
Settextkey(num,pos,name,script):=
    Settextkey(num,pos,name,script,18,0,0.2);
Settextkey(num,pos,name,script,size):= // 230206added
    Settextkey(num,pos,name,script,size,0,0.2);
Settextkey(num,pos,name,script,size,fill,alpha):=(
//help:Settextkey(10,[2,4],"Test","flg=1;");
//help:Settextkey(10,[2,4],"Test","");
//help:Settextkey(no,pos,name,script,18);
//help:Settextkey(no,pos,name,script,size,fillcolor,fillalpha));
  regional(id,pid,tmp,tmp1,tmp2);
  id="Text"+num;
  tmp=Allelements();
  tmp=apply(tmp,#.name);
  tmp=select(tmp,indexof(#,"Text")>0);
  if(!contains(tmp,id),
    create([id],"Text",[1,1,1]);
  );
  pid=parse(id);
  tmp=id+".xy="+pos+";";
  parse(tmp);
  inspect(pid,"text.text",name);
  inspect(pid,"textsize",size);
  inspect(pid,"colorfill",fill);
  inspect(pid,"fillalpha",alpha);
  if(length(script)>0,
    inspect(pid,"textbutton",true);
    inspect(pid,"texttoggle",true);
    inspect(pid,"button.script",script);
  );
);
////%Settextkey end////

////%Animationkey start////
Animationkey():=Animationkey([71,72,73,74],[-4,-2,0,2],-6);
Animationkey(kL,pxL,py):=(
//help:Animationkey([71,72,73,74],[-4,-2,0,2],-6);
  regional(sL,fillcolor,fillalpha);
//  println([5046,pxL]);
  sL=[
    "resetclock();playanimation();Animeflg=1;Dirflg=1;
        sorg=Current;",
    "Animeflg=1-Animeflg;if(Animeflg==0,pauseanimation();
        sorg=sstart;,resetclock();playanimation(););",
    "sorg=sstart;Dirflg=-Dirflg;Animeflg=1;resetclock();
        playanimation();",
    "stopanimation();Animeflg="";sstart=Current;"
  ];
  fillcolor=-1;
  fillalpha=0.467;
  Settextkey(kL_1,[pxL_1,py],"Play",sL_1,18,fillcolor,fillalpha);
  Settextkey(kL_2,[pxL_2,py],"Pause",sL_2,18,fillcolor,fillalpha);
  Settextkey(kL_3,[pxL_3,py],"Rev",sL_3,18,fillcolor,fillalpha);
  Settextkey(kL_4,[pxL_4,py],"Stop",sL_4,18,fillcolor,fillalpha);
);
////%Animationkey end////

////% Ketlms start////
//help:Ketlms(Mvpt,Rmvpt,Pt2sc,Sc2pt,Mvdraw);
//help:Ketlms(global Center,Scale);
////% Ketlms end////
////%Mvpt start////
Mvpt(pt):=(
  Scale*pt+Center;  //Scale,Center grobal
);
Mvpt(x,y):=Mvpt([x,y]);
////%Mvpt end////
////%MvptL start////240826
MvptL(ptL):=(
  apply(ptL,Mvpt(#));
);
////%MvptL end////
////%Rmpt start////
Rmpt(mpt):=(
  (mpt-Center)/Scale;
);
Rmpt(mx,my):=Rmpt([mx,my]);
////%Rmpt end
////%Pt2sc start
Pt2sc(pt):=(
  regional(sx);
  if(ispoint(pt),sx=pt.x,sx=pt_1);
  2^(1/5*(sx-35));
);
////%Pt2sc end////
////%Sc2pt start////
Sc2pt(sc):=(
  regional(sx);
  sx=5*log(sc)/log(2)+35;
  [sx,4];
);
////%Sc2pt end////
////%Mvdraw start////
Mvdraw(num):=Mvdraw(num,[]);
Mvdraw(num,opt):=(
  regional(pltL,out,tmp,tmp1);
  pltL=parse(num);
  if(length(pltL)==1,
    Pointdata("-m"+num,ptL,opt);
  ,
    out=apply(pltL,Mvpt(#));
    Listplot("-m"+num,out,append(opt,"Msg=y"));
  );
  out;
);
////%Mvdraw end////

////%Mvlist start//// 240222changed
Mvlist(pdatastr):=Mvlist(pdatastr,pdatastr,[]);
Mvlist(Arg1,Arg2):=(
 regional(tmp);
 if(islist(Arg2),
   tmp=select(Arg2,isstring(#));
   if(length(tmp)==0,
     Mvlist(Arg1,Arg2,[]);
   ,
     Mvlist(Arg1,Arg1,Arg2);
   );
 ,
   Mvlist(Arg1,Arg2,[]);
 );
);
Mvlist(num,pdataorg,opt):=(
//help:Mvlist(num,"cr1");
  regional(name,pdata,tmp);
  pdata=pdataorg;
  if(isstring(pdataorg),
    name="m"+pdata;
    pdata=parse(pdata);
  ,
    name="m"+num;
  );
  tmp=apply(pdata,Mvpt(#));
  Listplot("-"+name,tmp,opt);
);
////%Mvlist end////

////%Mvplotdata start////
Mvplotdata(num,fun,rng):=Mvplotdata(num,fun,rng,[]);
Mvplotdata(num,fun,rng,op):=(
  //help:Mvplotdata("1","sin(x)","x",["Num=200","dr,2"]);
  regional(op1,op2,tmp1,tmp2,tmp3);
  tmp1=select(op,substring(#,0,1)=="N");
  tmp2=select(op,substring(#,0,1)=="E");
  tmp3=select(op,substring(#,0,1)=="M");
  op1=concat(tmp1,tmp2);
  op1=concat(op1,tmp3);
  op2=remove(op,op1);
  Plotdata(num,fun,rng,concat(op2,["nodisp"]));
  Mvlist("gr"+num,"gr"+num,op2);
);
////%Mvplotdata end////

////%Mvcircledata start//// 240222
Mvcircledata(num,cirdata):=Mvcircledata(num,cirdata,[]);
Mvcircledata(num,cirdata,op):=(
  //help:Mvcircledata("1",[C,r],[]);
  regional(tmp1,tmp2,op1,op2);
  tmp1=select(op,substring(#,0,1)=="N");
  tmp2=select(op,substring(#,0,1)=="R");
  op1=concat(tmp1,tmp2);
  op2=remove(op,op1);
  Circledata(num,cirdata,["nodisp"]);
  Mvlist("cr"+num,"cr"+num,op2);
);
////%Mvcircledata end////

////%Mvdrwxy start////
Mvdrwxy():=(
//help:Mvdrwxy();
  regional(org,tmp);
  org=GENTEN; 
  Mvlist("axx",[[XMIN,org_2],[XMAX,org_2]],AXSTYLE_2);
  Mvlist("axy",[[org_1,YMIN],[org_1,YMAX]],AXSTYLE_2);
  tmp=AXSTYLE_1;
  if(tmp_1=="a",
    Arrowhead(Mvpt(XMAX,org_2),[1,0],AXSTYLE_2);
    Arrowhead(Mvpt(org_1,YMAX),[0,1],AXSTYLE_2);
  );
  Expr(Mvpt(XMAX,org_2),tmp_3,tmp_2,AXSTYLE_3); 
  Expr(Mvpt(org_1,YMAX),tmp_5,tmp_4,AXSTYLE_3); 
  Letter(Mvpt(org),tmp_7,tmp_6,AXSTYLE_3);
);
////%Mvdrwxy end////

//help:end();

