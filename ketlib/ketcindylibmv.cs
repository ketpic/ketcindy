//  Copyright (C)  2014  Masataka Kaneko, Setsuo Takato, KETCindyJapan project team
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

println("ketcindymv(2017.08.19) loaded");

//help:start();

Ketinitmv():=(
  regional(tmp,tmp1,tmp2,tmp3);
  Ketinit();//17.04.10
  Texmov=Fhead+"movie";
  Texpara=Fhead+"para";
  ParaTitle=Texpara;//16.12.10
  tmp1=round(4*SW.y)/4-0.5;
  tmp2=SW.x+1;
  tmp3=NE.x-1;
  Listplot("sl",[[tmp2,tmp1],[tmp3,tmp1]],["notex","linecolor->[0,1,0]"]);
  PutonCurve("MF",sgsl,[tmp2,tmp3]);
  Paraamble();  // 16.08.10
  Shellfile="mv"; // 17.04.09
);

Moviedata(func,var):=Moviedata(func,var,[]);
Moviedata(func,var,options):=(
//help:Moviedata("mf(t)","t=[0,4]");
//help:Moviedata(Options=["Cut=20","Div=80"]);
  regional(tmp,tmp1,tmp2,eqL);
  tmp=Divoptions(options);
  eqL=tmp_5;
  CUT=20;
  DVALL=0;
  Ec=[];
  forall(eqL,
    tmp=indexof(#,"=");
    tmp1=Toupper(substring(#,0,1));
    tmp2=Toupper(substring(#,tmp,length(#)));
    if(tmp1=="D",
      DVALL=parse(tmp2);
    );
    if(tmp1=="C",
      CUT=parse(tmp2);
    );
  );
  if(DVALL==0,
    DVALL=4*CUT;
  );
  tmp=indexof(var,"=");
  tmp1=substring(var,0,tmp-1);
  tmp2=substring(var,tmp,length(var));
  tmp2=parse(tmp2);
  if(indexof(func,"Moiveframe")==0,
    tmp="Movieframe("+tmp1+"):="+func+";";
    parse(tmp);
  );
  tmp="Movierange="+tmp2+";";
  parse(tmp);
//  tmp="Movieoptions=["+Dq+"Div="+text(DVALL)+Dq+","+Dq+"Cut="+text(CUT)+Dq+"]";
//  parse(tmp);
);

Paraamble():=Paraamble("");
Paraamble(str):=(
//help:Paraamble();
//help:Paraamble(amblelist);
//help:Paraamble(filename);
  regional(cmdall,sep,tmp,tmp1,tmp2);
  if(isstring(str),
    if(str=="",
      Parafirsthead=[
        "\def\ketcbox{white}", // 17.02.26
        "\newslide[0]{"+ParaTitle+"}", //16.12.10
        "",
        "\hypertarget{FIRST}{}",
        "Commonhead"
      ];
      Parafirsttail=[
        "Commontail"
      ];
      Parahead=[
        "\sameslide[0]",
        "Commonhead"
      ];
      Paratail=[
        "Commontail"
      ];
      Paralasthead=[
        "\sameslide[0]",
        "",
        "\hypertarget{LAST}{}",
        "Commonhead"
      ];
      Paralasttail=[
        "Commontail"
      ];
      Commonhead=[
        "",
        "\definecolor{thinblue}{cmyk}{0.3,0.3,0,0}", //17.02.19
        "\begin{layer}{130}{0}",
        "\hyperlink{FIRST}{\colorframe[8]{0}{80}{thinblue}{yellow}{blue}{FIRST}}", //17.02.19
        "\hyperlink{LAST}{\colorframe[8]{110}{80}{thinblue}{yellow}{blue}{LAST}}", //17.02.19
        "\putnotec{60}{40}{"  // 16.07.06
      ];
      Commontail=[
        "",
        "}",
        "\end{layer}",
        ""
     ];
    ,
      if(indexof(str,".")>0,tmp1=str,tmp1=str+".txt");
      tmp=load(tmp1);
      cmdall=tokenize(tmp,"...");
      cmdall=apply(cmdall,Removespace(#));
      sep=select(1..length(cmdall),substring(cmdall_#,0,5)=="%Para");
      Parafirsthead=cmdall_(2..(sep_2-1));
      Parafirsttail=cmdall_((sep_2+1)..(sep_3-1));
      Parahead=cmdall_((sep_3+1)..(sep_4-1));
      Paratail=cmdall_((sep_4+1)..(sep_5-1));
      Paralasthead=cmdall_((sep_5+1)..(sep_6-1));
      tmp1=cmdall_((sep_6+1)..length(cmdall));
      sep=select(1..length(tmp1),substring(tmp1_#,0,7)=="%Common");
      Paralasttail=tmp1_(1..sep_1-1);
      Commonhead=tmp1_((sep_1+1)..(sep_2-1));
      Commontail=tmp1_((sep_2+1)..length(tmp1));
    );
  );
  if(islist(str),
    Parafirsthead=str_1;
    Parafirsttail=str_2;
    Parahead=str_3;
    Paratail=str_4;
    Paralasthead=str_5;
    Paralasttail=str_6;
    Commonhead=str_7;
    Commontail=str_8;
  );
  tmp1=apply(Parafirsthead,Dq+#+Dq);
  tmp2=apply(Parafirsttail,Dq+#+Dq);
  tmp=[tmp1,tmp2];
  tmp1=apply(Parahead,Dq+#+Dq);
  tmp2=apply(Paratail,Dq+#+Dq);
  tmp=concat(tmp,[tmp1,tmp2]);
  tmp1=apply(Paralasthead,Dq+#+Dq);
  tmp2=apply(Paralasttail,Dq+#+Dq);
  tmp=concat(tmp,[tmp1,tmp2]);
  tmp1=apply(Commonhead,Dq+#+Dq);
  tmp2=apply(Commontail,Dq+#+Dq);
  tmp=concat(tmp,[tmp1,tmp2]);
  tmp;
);

Writeparaamble(filename):=(
  //regional(tmp,tmp1,tmp2);
  SCEOUTPUT=openfile(filename);
  println(SCEOUTPUT,"%Parafirsthead"+"...");
  forall(Parafirsthead,
    println(SCEOUTPUT,#+"...");
  );
  println(SCEOUTPUT,"");
  println(SCEOUTPUT,"%Parafirsttail"+"...");
  forall(Parafirsttail,
    println(SCEOUTPUT,#+"...");
  );
  println(SCEOUTPUT,"");
  println(SCEOUTPUT,"%Parahead"+"...");
  forall(Parahead,
    println(SCEOUTPUT,#+"...");
  );
  println(SCEOUTPUT,"");
  println(SCEOUTPUT,"%Paratail"+"...");
  forall(Paratail,
    println(SCEOUTPUT,#+"...");
  );
  println(SCEOUTPUT,"");
  println(SCEOUTPUT,"%Paralasthead"+"...");
  forall(Paralasthead,
    println(SCEOUTPUT,#+"...");
  );
  println(SCEOUTPUT,"");
  println(SCEOUTPUT,"%Paralasttail"+"...");
  forall(Paralasttail,
    println(SCEOUTPUT,#+"...");
  );
  println(SCEOUTPUT,"");
  println(SCEOUTPUT,"%Commonhead"+"...");
  forall(Commonhead,
    println(SCEOUTPUT,#+"...");
  );
  println(SCEOUTPUT,"");
  println(SCEOUTPUT,"%Commontail"+"...");
  forall(Commontail,
    println(SCEOUTPUT,#+"...");
  );
  closefile(SCEOUTPUT);
);

Mvdispg():=(
  regional(tmp,tmp1,tmp2,tmp3,num,s,i);
  CLIST=COM2ndlist;
  FIXGLIST=[];
  forall(2..length(GLIST),
    FIXGLIST=append(FIXGLIST,GLIST_#);
  );
  STPTlist=remove(allpoints(),[SW,NE,MF]);
  STPlist=[];
  STPnamelist=[];
  STPvaluelist=[];
  forall(STPTlist,
    tmp=Lcrd(#);
    tmp1=format(re(tmp_1),5);
    tmp2=format(re(tmp_2),5);
    tmp="["+tmp1+","+tmp2+"]";
    STPlist=append(STPlist,#.name+"="+tmp+";");
    STPnamelist=append(STPnamelist,#.name);
    STPvaluelist=append(STPvaluelist,tmp);
  );
  tmp1=round(4*SW.y)/4-0.5;
  tmp2=SW.x+1;
  tmp3=NE.x-1;
  if(length(Movierange)==2,
    s=Movierange_1+(MF.x-tmp2)/(tmp3-tmp2)*(Movierange_2-Movierange_1);
    Movieframe(s);
    ,
    num=length(Movierange);
    tmp=Movierange_1+(MF.x-tmp2)/(tmp3-tmp2)*(Movierange_num-Movierange_1);
    i=1;
    while(Movierange_(i+1)<=tmp,
      i=i+1;
    );
    s=Movierange_i;
    Movieframe(s);
  );
  Windispg();
  Defvar("s",s);
  GOUTLIST=[];
);

Mkmovie():=Mkmovie(Movierange);
Mkmovie(rng):=(
  regional(x1,x2,PLIST,GL,num0,num1,num2,num3,num4,num5,num6,num,
      l,s,k,tmp,tmp1,tmp2,tmp3,Plist,Pnamelist,Pvaluelist,
      ALLPlist,MVPlist);
  if(length(rng)==2,
    x1=rng_1;
    x2=rng_2;
    PLIST=[x1];
    forall(1..DVALL,k,
      s=x1+k*(x2-x1)/DVALL;
      PLIST=append(PLIST,s);
    );
    ,
    PLIST=rng;
    DVALL=length(rng)-1;
  );
  if(VERNUM==0,
    SCEOUTPUT=openfile(Texmov+".sce");
  ,
    SCEOUTPUT=openfile(Texpara+".sce");
  );
  println(SCEOUTPUT,"cd('"+Dirwork+"');");
  println(SCEOUTPUT,"Ketlib=lib('"+Libname+"');");
  println(SCEOUTPUT,"Ketinit();");
  println(SCEOUTPUT,"pi=%pi;");
  tmp="Setwindow(["+text(XMIN)+","+text(XMAX)+
      "],["+text(YMIN)+","+text(YMAX)+"]);";// 16.05.19
  println(SCEOUTPUT,tmp);
  //println(SCEOUTPUT,"Setax('l','x','e','y','n','O','sw');");
  num1=length(COM1stlist);
  forall(1..num1,l,
    println(SCEOUTPUT,COM1stlist_l+";");
  );
  forall(1..length(STPlist),
    print(SCEOUTPUT,STPlist_#);
    println(SCEOUTPUT," Assignrep('"+STPnamelist_#+"',"+STPvaluelist_#+");");
  );
  num2=length(CLIST);
  num3=length(FIXGLIST);
  num=0;
  repeat(num3,
    num=num+1;
    tmp1=FIXGLIST_num;
    num4=indexof(tmp1,"=");
    if(num4>0,
      tmp2=substring(tmp1,num4,length(tmp1));
      tmp=substring(tmp1,0,num4-1);
      println(SCEOUTPUT,tmp+"="+text(tmp2)+";");
    );
  );
  if(VERNUM==0,
    println(SCEOUTPUT,"Openfile('"+Texmov+"figs.tex');");
    println(SCEOUTPUT,"Texcom('\begin{animateinline}{"+text(CUT)+"}');");
  ,
    println(SCEOUTPUT,"Openfile('"+Texpara+"figs.tex');");
  );
  println(SCEOUTPUT,"");
  forall(0..DVALL,k,
    s=PLIST_(k+1);
    println(SCEOUTPUT,"s="+format(s,5)+";");
    GLIST=[];
    COM2ndlist=[];
    GCLIST=FIXGCLIST;
    Movieframe(s);
    clrscr();  // 15.06.17
    Plist=[];
    Pnamelist=[];
    Pvaluelist=[];
    ALLPlist=remove(allpoints(),[SW,NE,MF]);
    RMPlist=[];
    forall(1..length(ALLPlist),
      tmp=indexof(STPvaluelist_#,",");
      tmp1=substring(STPvaluelist_#,1,tmp-1);
      tmp2=substring(STPvaluelist_#,tmp,length(STPvaluelist_#)-1);
      if(parse(format(Lcrd(ALLPlist_#)_1,5))==parse(tmp1),
        if(parse(format(Lcrd(ALLPlist_#)_2,5))==parse(tmp2),
          RMPlist=append(RMPlist,ALLPlist_#);
        );
      );
    );
    MVPlist=remove(ALLPlist,RMPlist);
    forall(MVPlist,
      tmp=Lcrd(#);
      tmp1=format(re(tmp_1),5);
      tmp2=format(re(tmp_2),5);
      tmp="["+tmp1+","+tmp2+"]"; 
      Plist=append(Plist,#.name+"="+tmp+";");
      Pnamelist=append(Pnamelist,#.name);
      Pvaluelist=append(Pvaluelist,tmp);
    );
    forall(1..length(Plist),
      print(SCEOUTPUT,Plist_#);
      println(SCEOUTPUT," Assignrep('"+Pnamelist_#+"',"+Pvaluelist_#+");");
    );
    num3=length(GLIST);
    num=0;
    GL=[];
    forall(GCLIST,
      GL=append(GL,#_1);
    );
    repeat(num3,
      num=num+1;
      tmp1=GLIST_num;
      num4=indexof(tmp1,"=");
      tmp2=substring(tmp1,num4,length(tmp1));
      tmp=substring(tmp1,0,num4-1);
    //if(indexof(tmp2,"=")>0,
      if(substring(tmp2,0,5)=="Param",
        num5=indexof(tmp2,"=");
        tmp3=substring(tmp2,num5,length(tmp2)-2);
        tmp3=parse(tmp3);
        if(tmp3_1==tmp3_2,
          tmp2="Pointdata([0,0])";
        );
      );
      println(SCEOUTPUT,tmp+"="+text(tmp2)+";");
    );
    forall(GOUTLIST,
      tmp=#_1;
      println(SCEOUTPUT,"Tmpout=ReadOutData('"+tmp+"');");
      println(SCEOUTPUT,"execstr(Tmpout);");
    );
    if(VERNUM==1,
      if(k==0,
        tmp1=apply(Parafirsthead,Removespace(#));
      ,
        if(k<DVALL,
          tmp1=apply(Parahead,Removespace(#));
        ,
          tmp1=apply(Paralasthead,Removespace(#));
        );
      );
      tmp1=apply(tmp1,if(length(#)==0,"newline",#));
      tmp=select(1..length(tmp1),indexof(tmp1_#,"Common")>0);
      tmp2=apply(Commonhead,Removespace(#));
      tmp2=apply(tmp2,if(length(#)==0,"newline",#));
      tmp1_(tmp_1)=tmp2;
      tmp1=flatten(tmp1);
      forall(tmp1,
        println(SCEOUTPUT,"Texcom('"+#+"');");
      );
    );
    tmp=indexof(ULEN,"cm"); // 16.05.19from
    if(tmp>0,
      tmp1=Removespace(substring(ULEN,0,tmp-1));
      tmp2=0.5/parse(tmp1)
    ); // 16.05.19upto
    tmp=indexof(ULEN,"mm");
    if(tmp>0,
      tmp1=Removespace(substring(ULEN,0,tmp-1));
      tmp2=5/parse(tmp1);
    ); 
    tmp="Setwindow(["+text(XMIN)+","+text(XMAX+tmp2)+
       "],["+text(YMIN)+","+text(YMAX+tmp2)+"]);";// 16.05.19
    println(SCEOUTPUT,tmp);// 16.05.19
    println(SCEOUTPUT,"Beginpicture('"+ULEN+"');");
    tmp="Setwindow(["+text(XMIN)+","+text(XMAX)+
       "],["+text(YMIN)+","+text(YMAX)+"]);";// 16.05.19
    println(SCEOUTPUT,tmp);// 16.05.19
    forall(1..num2,l,
      println(SCEOUTPUT,CLIST_l+";");
    );
    forall(1..length(COM2ndlist),l,
      println(SCEOUTPUT,COM2ndlist_l+";");
    );
    println(SCEOUTPUT,"Endpicture("+ADDAXES+");");
    if(VERNUM==0,
      println(SCEOUTPUT,"");
      println(SCEOUTPUT,"Texcom('');");
      if(k<DVALL,
        println(SCEOUTPUT,"Texcom('\newframe');");
        println(SCEOUTPUT,"");
      ,
        println(SCEOUTPUT,"Texcom('\end{animateinline}')");
        println(SCEOUTPUT,"Closefile();");
        println(SCEOUTPUT,"quit();");
        closefile(SCEOUTPUT);
      );
    ,
      if(k==0,
        tmp1=apply(Parafirsttail,Removespace(#));
      ,
        if(k<DVALL,
          tmp1=apply(Paratail,Removespace(#));
        ,
          tmp1=apply(Paralasttail,Removespace(#));
        );
      );
      tmp1=apply(tmp1,if(length(#)==0,"newline",#));
      tmp=select(1..length(tmp1),indexof(tmp1_#,"Common")>0);
      tmp2=apply(Commontail,Removespace(#));
      tmp2=apply(tmp2,if(length(#)==0,"newline",#));
      tmp1_(tmp_1)=tmp2;
      tmp1=flatten(tmp1);
      forall(tmp1,
        println(SCEOUTPUT,"Texcom('"+#+"');");
      );
      if(k==DVALL,
        println(SCEOUTPUT,"");
        println(SCEOUTPUT,"Closefile();");
        println(SCEOUTPUT,"quit();");
        closefile(SCEOUTPUT);
      );
    );
    Windispg(GL);
    time=1000/CUT;
    wait(time);
    GLIST=[];
    GCLIST=[];
    COM2ndlist=[];
    GOUTLIST=[];
  );
);

Mkmovietexmain():=(
  TEXOUTPUT=openfile(Texmov+"main"+".tex"); // 15.03.28
    println(TEXOUTPUT,"");
    println(TEXOUTPUT,"\documentclass{article}");
    println(TEXOUTPUT,"\usepackage{amsmath,amssymb}"); // 16.07.06
    println(TEXOUTPUT,"\usepackage{graphicx}");
    println(TEXOUTPUT,"\usepackage[dvipdfmx]{animate}");
    println(TEXOUTPUT,"\usepackage{color}");
    println(TEXOUTPUT,"\usepackage{ketpic,ketlayer}");
    println(TEXOUTPUT,"\setmargin{20}{20}{20}{20}");
    println(TEXOUTPUT,"\begin{document}");
    println(TEXOUTPUT,"\input{"+Texmov+"figs.tex}%");
    println(TEXOUTPUT,"\end{document}");
  closefile(TEXOUTPUT);
);

Mkmoviesh():=(
  regional(parentorg,tmp);
  parentorg=Texparent;//17.04.10
  Texparent="";//17.04.10
  tmp=Fhead;// 15.03.28
  Fhead=Texmov; 
  if(length(Shellparent)>0,
    Makeshell()
  ,
    Makebat();
  );
  Fhead=tmp;
  Texparent=parentorg;//17.04.10
);

Texmovie():=(
  VERNUM=0;
  Mkmovie();
  Mkmovietexmain();
  Mkmoviesh();
);

Mkparatexmain():=(
  TEXOUTPUT=openfile(Texpara+"main"+".tex");
    println(TEXOUTPUT,"");
    println(TEXOUTPUT,"\documentclass[landscape,10pt]{article}");
    println(TEXOUTPUT,"\usepackage{amsmath,amssymb}"); // 16.07.06
    println(TEXOUTPUT,"\usepackage{graphicx}");
    println(TEXOUTPUT,"\usepackage[dvipdfmx,colorlinks=true,linkcolor=black]{hyperref}");
    println(TEXOUTPUT,"\AtBeginDvi{\special{pdf:tounicode 90ms-RKSJ-UCS2}}");
    println(TEXOUTPUT,"\usepackage{color}");
    println(TEXOUTPUT,"\usepackage{ketpic,ketlayer,ketslide}");
    println(TEXOUTPUT,"\ketmarginE");
    println(TEXOUTPUT,"\ketslideinit");
    println(TEXOUTPUT,"\begin{document}");
    println(TEXOUTPUT,"\input{"+Texpara+"figs.tex}%");
    println(TEXOUTPUT,"\end{document}");
  closefile(TEXOUTPUT);
);

Mkparash():=(
  regional(tmp);
  tmp=Fhead;
  Fhead=Texpara; 
  if(length(Shellparent)>0,
    Makeshell()
  ,
    Makebat();
  );
  Fhead=tmp;
);

Texpara():=(
  VERNUM=1;
  Mkmovie();
  Mkparatexmain();
  Mkparash();
);

Setpara(path,fstr,sL):=Setpara(path,fstr,sL,[]); // 16.12.27added
Setpara(pathorg,fstr,sL,options):=(
//help:Setpara("folder name","funstr","range",options);
//help:Setpara(folder,funstr,range,options);
//help:Setpara(options=["m/r","Div=25"]);
//help:Setpara(options=["Frate=10","Scale=1","OpA=[loop]"] for animation);
  regional(path);//17.04.10
  if(length(pathorg)==0, path=Slidename,path=pathorg);//17.04.10
  ParaPath=path;
  ParaFstr=fstr;
  ParaSL=sL;
  ParaOp=options;
  GLISTback=GLIST; 
  GCLISTback=GCLIST;
  GOUTLISTback=GOUTLIST;
  POUTLISTback=POUTLIST;
  VLISTback=VLIST;
  FUNLISTback=FUNLIST;
  LETTERlistback=LETTERlist;
  COM0thlistback=COM0thlist;
  COM1stlistback=COM1stlist;
  COM2ndlistback=COM2ndlist;
);

Parafolder():=Parafolder(ParaPath,ParaFstr,ParaSL,ParaOp);
Parafolder(path,fstr,sL):=Parafolder(path,fstr,sL,[]);
Parafolder(path,fstr,sLorg,optionorg):=(
//help:Parafolder(foldername,1..4);
//help:Parafolder(foldername,"s=[0,1]");
//help:Parafolder("mf(s)",foldername,"s=[0,1]");
//help:Parafolder(options=["m/r","Div=25"]); 
//help:Paraslide(para=folder:layery:pos:input,scale); 
//help:Paraslide(para=folder:layery:pos:include:[width=100]); 
  regional(nn,sL,tmp,tmp1,tmp2,strL,eqL,
        mksce,mktex,ndiv,options,sciall,sfL);
  if(!isstring(ParaPath),
    println("Setpara not executed");
  ,
    sL=sLorg;//16.12.24from
    if(!isstring(sL),
      tmp=indexof(fstr,"(");
      tmp1=substring(fstr,tmp,length(fstr));
      tmp=indexof(tmp1,")");
      tmp1=substring(tmp1,0,tmp-1);
    ,
      tmp=indexof(sL,"=");//16.12.21from
      if(length(tmp)>0,
        tmp1=substring(sL,0,tmp-1);
      );
    );//16.12.21,24upto
    parse("Movieframe("+tmp1+"):="+fstr);
    options=optionorg;
    tmp=Divoptions(options);
    eqL=tmp_5;
    strL=tmp_7;
    if(length(strL)==0,options=append(options,"m"));//16.12.18
    mksce="A";
    mktex="A";
    ndiv=25;
    forall(eqL,
      tmp=Indexof(#,"=");
      tmp1=Toupper(substring(#,0,1));
      tmp2=substring(#,tmp,length(#));
      if(tmp1=="D",
        ndiv=parse(tmp2);
        options=remove(options,[#]);
      );
    );
    forall(strL,
      tmp1=Toupper(substring(#,0,1));
      if(tmp1=="M",
        mksce="Y"; mktex="Y";
      );
    );
    sL=sLorg;
    if(isstring(sL),
      tmp=indexof(sL,"=");
      tmp1=parse(substring(sL,tmp,length(sL)));
      sL=apply(0..ndiv,tmp1_1+#*(tmp1_2-tmp1_1)/ndiv);
    );
    if(!isexists(Dirwork,path),
      if(ErrFlag!=-1,
        cmdL=["createdir",[Dq+path+Dq]];//16.12.20
        CalcbyS("crdr",cmdL,["m"]);
        wait(200);//17.02.20from
        repeat(1..30,
          if(!isexists(Dirwork,path),wait(100));
        );//17.02.20upto
      ,
        println("   ==> Changework may not work properly");
        sL=[];
      );
    ,
      if(mksce=="Y",
        cmdL=[
          "rmdir",[Dq+path+Dq,Dq+"s"+Dq],
          "createdir",[Dq+path+Dq]
        ];//16.12.20
        CalcbyS("crdr",cmdL,["m"]);
        wait(200);//17.02.20from
        tmp=Dirwork+"/"+path;
        if(iswindows(),tmp=replace(tmp,"/","\"));
        repeat(1..30,
          if(!isexists(Dirwork,path),
            wait(100);
          ,
             if(length(fileslist(tmp))>0,wait(100));
          );
        );
      );//17.02.20upto
    );
    sciall=path+"/all.sce";
    if(iswindows(),sciall=replace(sciall,"/","\"));//17.02.20
    sfL=[];
    forall(1..(length(sL)),nn,
      clrscr();  // 16.12.28
      GLIST=GLISTback;
      GCLIST=GCLISTback;
      GOUTLIST=GOUTLISTback;
      POUTLIST=POUTLISTback;
      VLIST=VLISTback;
      FUNLIST=FUNLISTback;
      LETTERlist=LETTERlistback;
      COM0thlist=COM0thlistback;
      COM1stlist=COM1stlistback;
      COM2ndlist=COM2ndlistback;
      tmp1=Sprintf(nn/1000,3);
      tmp=indexof(tmp1,".");
      tmp1=substring(tmp1,tmp,length(tmp1));
      Fnamesci=path+"/p"+tmp1+".sce";
      sfL=append(sfL,Fnamesci);
      Fnametex=replace(Fnamesci,".sce",".tex");
      Movieframe(sL_nn);
//      windispg();//16.12.28
      if(!isexists(Dirwork,Fnamesci) % mksce=="Y",
        if(ErrFlag!=-1,
          Viewtex();
        );
      );
    ); // 16.12.27upto
    cmdL=[
      "fL="+text(apply(sfL,Dq+#+Dq)),[],
      "Dt=mgetl(fL(1));",[],
      "Dt=Dt(1:(size(Dt,1)-1),:)",[],
      "for I=2:size(fL,2),Tmp=mgetl(fL(I));N=size(Tmp,1)-1;Tmp1=Tmp(13:N,:);Dt=[Dt;Tmp1],end",[],
      "mputl(Dt,'"+sciall+"')",[],
       "exec('"+sciall+"',-1)",[]
    ];
    if(ErrFlag!=-1,
      if(!isexists(Dirwork,Fnametex) % mktex=="Y",
        CalcbyS("all",cmdL,options);
      ,
        println("Parafolder "+path+" finished");//16.12.20
      );
      if(length(after)>0, // 16.12.27
        parse(after);
      );
      Fnamesci=Fhead+".sce";
      Fnametex=Fhead+".tex";
    );
  );
);

Flipbook():=( //17.04.09
  regional(parentorg,Dirworkorg,figfolder,sep,x0,y0,sc,title,tmp,tmp1,tmp2);
  Dirworkorg=Dirwork;
  Slidework(Dirwork);
  figfolder=Dirwork;
  parentorg=Texparent;
  PageStyle="empty";
  title=Texparent;
  tmp=Divoptions(ParaOp);
  tmp1=tmp_5;
  forall(tmp1,
    tmp2=substring(Toupper(#),0,1);
    if(tmp2=="T",
      tmp=indexof(#,"=");
      title=substring(#,tmp,length(#));
      ParaOp=remove(ParaOp,[#]);
    );
  );
  x0="60"; y0="5"; sc="1";
  tmp=select(ParaOp,islist(#));
  if(length(tmp)>0,
    x0=text(tmp_1_1); 
    y0=text(tmp_1_2);
    ParaOp=remove(ParaOp,[tmp_1]);
  );
  tmp=select(ParaOp,!islist(#) & isreal(#));
  if(length(tmp)>0,
    sc=text(tmp_1);
    ParaOp=remove(ParaOp,[tmp_1]);
  );
  Parafolder();
  Changework(Dirworkorg);
  if(isstring(Slidename),
    Texparent=Slidename;
  ,
    Texparent=parentorg+"flip";
  );
  SCEOUTPUT = openfile(Texparent+".txt"); 
  println(SCEOUTPUT,"%title//");
  println(SCEOUTPUT,"\pagestyle{empty};//");
  println(SCEOUTPUT,"new::"+title+"//");
  println(SCEOUTPUT,
    "%repeat=,para="+ParaPath+":{0}:s{"+x0+"}{"+y0+"}:input:"+sc+"//");
  closefile(SCEOUTPUT);
  Changework(figfolder);
  Setslidebody("black");
  Setslidehyper("");
  Mkslides();
  Changework(Dirworkorg);
  Texparent=parentorg;
);

Animatefile():=Animatefile(Dirwork,ParaPath);
Animatefile(path,folder):=(
//help:Animatefile();
//help:Animatefile(Dirwork,ParaPath);
  regional(FRate, Scale, OpA, pa,fname,eqL,tmp,tmp1,tmp2);
  tmp=divoptions(ParaOp);
  eqL=tmp_5;
  FRate="10";
  Scale="1";
  OpA="";
  forall(eqL,
    tmp1=Toupper(substring(#,0,2));
    tmp=indexof(#,"=");
    tmp2=substring(#,tmp,length(#));
    if(tmp1=="FR",
      FRate=tmp2;
    );
    if(tmp1=="SC",
      Scale=tmp2;
    );
    if(tmp1=="OP",
      if(substring(tmp2,0,1)!="[",tmp2="["+tmp2+"]");
      OpA=tmp2;
    );
  );
  pa=replace(path,"\","/");
  fname="anim"+folder+".tex";
  tmp=Dirwork+"/"+folder;
  path=replace(tmp,"\","/");
  if(iswindows(),tmp=replace(tmp,"/","\"));
  tmp1=fileslist(tmp);
  tmp1=tokenize(tmp1,",");
  tmp1=select(tmp1,indexof(#,".tex")>0);
  SCEOUTPUT= openfile(fname);
  println(SCEOUTPUT,"\def\parapath{"+pa+"}%"); //17.06.22
  println(SCEOUTPUT,"\begin{animateinline}"+OpA+"{"+FRate+"}%");
  forall(1..(length(tmp1)),
    if(Scale==1, // 17.08.30from
      tmp="\input{\parapath/";
      tmp=tmp+folder+"/"+tmp1_#+"}%"; 
    ,
      tmp="\scalebox{"+Scale+"}{\input{\parapath/";//17.06.22(3lines)
      tmp=tmp+folder+"/"+tmp1_#+"}}%"; 
    ); // 17.08.30upto
    println(SCEOUTPUT,tmp);
//    println(SCEOUTPUT,""); //17.06.25
    if(#<length(tmp1),
      println(SCEOUTPUT,"\newframe%");
    );
  );
  println(SCEOUTPUT,"\end{animateinline}%");
  closefile(SCEOUTPUT);
  println(fname+" has been generated");
);

//help:end();

