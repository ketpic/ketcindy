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

println("ketcindymv(20190317) loaded");

//help:start();

////%Setpara start////
Setpara(path,fstr,sL):=Setpara(path,fstr,sL,[],[]); 
Setpara(pathorg,fstr,sL,options):= 
    Setpara(pathorg,fstr,sL,options,[]);
Setpara(pathorg,fstr,sL,options,optionsanim):=(
//help:Setpara("folder name","funstr","range",options,optionsanim);
//help:Setpara(folder,funstr,range,options);
//help:Setpara(options=["Div=25"]);
//help:Setpara(options2anim1=["Frate=10","Scale=1"]);
//help:Setpara(options2anim2=["OpA=[loop,controls,buttonsize=3mm]"]);
//help:Setpara(options2anim3=["OpA=+step"]);
//help :Setpara(options2anim4=["Mag=1600","Title=folder"]);
//help:Setpara(options2anim4=["Title=folder"]);
  regional(path,tmp,tmp1,tmp2,tmp3,eqL,ndiv,gtmp,ctmp,nn,flg);
  if(length(pathorg)==0, path=Slidename,path=pathorg);//17.04.10
  ParaPath=path;
  ParaFstr=fstr;
  ParaSL=sL;
  if(isstring(sL),
    ndiv=25;
    tmp=Divoptions(options);
    eqL=tmp_5;
    forall(eqL,
      tmp=Strsplit(#,"=");
      tmp1=Toupper(tmp_1);      
      if(substring(tmp1,0,1)=="D",
        ndiv=parse(tmp_2);
      );
    );
    tmp=Strsplit(sL,"=");
    tmp1=parse(tmp_2);
    ParaSL=apply(0..ndiv,tmp1_1+#*(tmp1_2-tmp1_1)/ndiv);
  );
  ParaOp=options;
  if((!contains(Paraop,"r"))&(!contains(ParaOp,"m")),
    ParaOp=append(ParaOp,"m");//180604
  );
  ParaOpAnim=optionsanim;
 if(ADDAXES=="1", //181224rom
    Drwxy();
//    ADDAXES="0";
  ); //181224to
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
  Dirworkbkup=Dirwork; //0611from
  Dirworksubbkup=Dirwork+pathsep()+ParaPath;
  Fheadbkup=Fhead; //0611to
  gtmp=GLISTback;
  tmp1=select(1..(length(gtmp)),indexof(gtmp_#,"ReadOutData")>0); //180614from
  tmp2=[];tmp3=[];
  if(length(tmp1)>0, //180615
    nn=tmp1_(length(tmp1));
	tmp2=append(tmp2,nn);
    flg=0;
    tmp=min([nn+40,length(gtmp)]);
    forall((nn+1)..tmp,
      if(flg==0,
        if(indexof(gtmp_#,"Projpara")>0,
          tmp2=append(tmp2,#);
          tmp=indexof(gtmp_#,"=");
          tmp=substring(gtmp_#,0,tmp-1);
          tmp3=append(tmp3,tmp);
        ,
          flg=1;
        );
      );
    );
  );
  tmp1=remove(1..(length(gtmp)),tmp2);
  GLISTback=apply(tmp1,GLIST_#); //180614to
  ctmp=COM2ndlistback; //180614
  forall(tmp3,tmp2,
    tmp=select(ctmp,indexof(#,tmp2)>0);
    ctmp=remove(ctmp,tmp);
  );
  COM2ndlistback=ctmp;
);
////%Setpara end////

////%Parafolder start////
Parafolder():=Parafolder(ParaFstr,ParaSL,ParaOp);
Parafolder(fstr,sL):=Parafolder(fstr,sL,[]);
Parafolder(fstr,sL,optionorg):=(
//help:Parafolder(foldername,1..4);
//help:Parafolder(foldername,"s=[0,1]");
//help:Parafolder("mf(s)",foldername,"s=[0,1]");
//help:Parafolder(options=["m/r","Div=25","Wait=20"]);
//help:Parafolder(optionsadd=[""Outfile=n",Pause=10(ms)"]); 
//help:Paraslide(para=folder:layery:pos:input,scale); 
//help:Paraslide(para=folder:layery:pos:include:[width=100]); 
  regional(store,nn,tmp,tmp1,tmp2,strL,eqL,waiting,outflg,pause,
        mkr,mktex,options,sfL,dirbkup,pfile,ctr,flg,varL,waitingR,timeC,timeR);
  store=Fillblack(); //181125
  tmp=indexof(fstr,"(");
  tmp1=substring(fstr,tmp,length(fstr));
  tmp=indexof(tmp1,")");
  tmp1=substring(tmp1,0,tmp-1);
  parse("Movieframe("+tmp1+"):="+fstr);
  options=optionorg;
  tmp=Divoptions(options);
  eqL=tmp_5;
  strL=tmp_7;
  if(length(strL)==0,options=append(options,"m"));
  mkr="A";
  mktex="A";
  waiting=30;
  outflg=0;
  pause=10;
  forall(eqL,
    tmp=Strsplit(#,"=");
    tmp1=Toupper(substring(tmp_1,0,1));
    if(tmp1=="W",
      waiting=parse(tmp_2);
      options=remove(options,[#]);
    );
    if((tmp1=="O")%(tmp1=="R"), //180606from
      tmp=Toupper(substring(tmp_2,0,1));
      if(tmp=="Y", outflg=1);
      options=remove(options,[#]);
    );
    if(tmp1=="P", //180610from
      pause=parse(tmp_2);
      options=remove(options,[#]);
    ); // //180610to
  );
  forall(strL,
    tmp1=Toupper(substring(#,0,1));
    if(tmp1=="M",
      mkr="Y"; mktex="Y";
    );
  );
  waitingR=min([length(sL)*waiting,120]);//180617
  Changework(Dirworksubbkup);
  SCEOUTPUT = openfile("all.r");
  println(SCEOUTPUT,"");
  closefile(SCEOUTPUT);//180608to
  resetclock();//180617
  if(outflg==1, //180606from
    CommonMake=1;//180609
    ctr=1;
    forall(sL,
      tmp="000000"+text(ctr);
      pfile="p"+substring(tmp,length(tmp)-3,length(tmp));
      Setfiles(pfile);
      Movieframe(#);
      ctr=ctr+1;
    );
    CommonMake=-1;//180609
    Setfiles(Fheadbkup);//180617
    timeC=seconds();//180617
  ); //180606to
  wait(pause); //180610
  sfL=[];
  ctr=1;
  forall(1..(length(sL)),nn,
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
    tmp="000000"+text(nn);
    pfile="p"+substring(tmp,length(tmp)-3,length(tmp));
    Changework(Dirworksubbkup);
    Setfiles(pfile);
    sfL=append(sfL,FnameR);
    if(outflg==1,
      wait(pause);
      Movieframe(sL_nn);
      Changework(Dirworksubbkup);//180606
      ctr=ctr+1;
    ,
      Movieframe(sL_nn);
      timeC=seconds();//180617
    );
    CommonMake=0;//180609
    Setfiles(pfile); //180608
    if(!isexists(Dirworksubbkup,FnameR) % mkr=="Y",
      if(ErrFlag!=-1,
        WritetoRS(2); 
      );
    );
  );
  wait(pause); //180610
  Setfiles(Fheadbkup);
  GLIST=select(GLIST,indexof(#,"Projpara")==0);
  tmp1=replace(Dirworksubbkup,"\\","/"); //180611
  tmp1=replace(tmp1,"\","/");
  cmdL=[
      "setwd("+Dqq(tmp1)+")",[],
      "size="+text(length(sL)),[],
      "cat('',file='all.r',sep='',append=FALSE)",[],  //180614
      "for(n in Looprange(1,size)){",[],
      "  tmp=as.character(n)",[],
      "  tmp=paste('0000',tmp,sep='')",[],
      "  tmp=substring(tmp,nchar(tmp)-2,nchar(tmp))",[],
      "  fname=paste('p',tmp,'.r',sep='')",[],
      "  lines=readLines(fname)",[],
      "  if(n>1){",[], //180614from
      "    for(j in 1:length(lines)){",[],
      "      tmp=grep('source',lines[j],fixed=TRUE)",[],
      "      if(length(tmp)>0){",[],
      "        lines[j]=paste('#',lines[j],sep='')",[],
      "        lines[j+2]=paste('#',lines[j+2],sep='')",[],
      "        break",[],
      "      }",[],
      "    }",[],
      "  }",[],
      "  lines=lines[1:(length(lines)-1)]",[], //180614to
      "  tmp=paste('print(',as.character(n),')',sep='')",[],
      "  lines=c(tmp,lines)",[],
      "  for(j in Looprange(1,length(lines))){",[],
      "    cat(lines[j],file='all.r',sep='\n',append=TRUE)",[],
      "  }",[],
      "}",[],
      "source('all.r')",[]
  ];
  if(ErrFlag!=-1,
    waiting=min([waiting,8])*length(ParaSL); //180610
    if(!isexists(Dirworksubbkup,Fnametex) % mktex=="Y",
      CalcbyR("",cmdL,["Cat=n","m","Wait="+text(waitingR)]);
    ,
      println("Parafolder finished");
    );
    if(length(after)>0,
      parse(after);
    );
  );
  if(ErrFlag!=-1,//180617from
    timeR=seconds()-timeC;
    println("C and R finished");
    println("    C : "+Sprintf(timeC,2)+" sec");
    println("    R : "+Sprintf(timeR,2)+" sec");
  ); //180617to
  Changework(Dirworkbkup);
  Setfiles(Fheadbkup);
  Fillrestore(store); //181125
);
////%Parafolder end////

////%Animatefile start////
Animatefile():=Animatefile(Dirwork,ParaPath);
Animatefile(path,folder):=(
//help:Animatefile();
//help:Animatefile(Dirwork,ParaPath);
  regional(FRate, Scale, OpA, pa,fname,eqL,tmp,tmp1,tmp2,texfiles);
  tmp=divoptions(ParaOpAnim); //17.11.24
  eqL=tmp_5;
  FRate="20"; //190317
  Scale="1";
  OpA="loop,controls,buttonsize=3mm";
  remflg=0;
  forall(eqL,
    tmp1=Toupper(substring(#,0,1)); //181111
    tmp=indexof(#,"=");
    tmp2=substring(#,tmp,length(#));
    if(tmp1=="F",
      FRate=tmp2;
    );
    if(tmp1=="S",
      Scale=tmp2;
    );
    if(tmp1=="O",  // 17.12.07from
      if(length(tmp2)>0,
	    tmp2=replace(tmp2,"[","");
        tmp2=replace(tmp2,"]","");
        if(substring(tmp2,0,1)=="+",
          OpA=OpA+","+substring(tmp2,1,length(tmp2));
        ,
          OpA=tmp2;
        );
      );
    );
  );
  if(length(OpA)>0,OpA="["+OpA+"]");
  pa=replace(path,"\","/");
  fname="anim"+folder+".tex";
  tmp=Dirwork+"/"+folder;
  path=replace(tmp,"\","/");
  if(iswindows(),tmp=replace(tmp,"/","\"));
  tmp1=fileslist(tmp);
  tmp1=tokenize(tmp1,",");
  tmp1=select(tmp1,indexof(#,".tex")>0);
  tmp1=sort(tmp1); //180617
  texfiles=[];//180609from
  forall(tmp1,
    tmp=indexof(#,".");
    tmp=parse(substring(#,1,tmp-1));
    if(tmp<=length(ParaSL),
      texfiles=append(texfiles,#);
    );
  );//180609to  
  SCEOUTPUT= openfile(fname);
  println(SCEOUTPUT,"\def\parapath{"+pa+"}%"); //17.06.22
  println(SCEOUTPUT,"\def\figsize{"+Scale+"}%"); //17.12.07
  println(SCEOUTPUT,"\begin{animateinline}"+OpA+"{"+FRate+"}%");
  forall(1..(length(texfiles)), //180609
    if(Scale==1, // 17.08.30from
      tmp="\input{\parapath/";
      tmp=tmp+folder+"/"+tmp1_#+"}%"; 
    ,
      tmp="\scalebox{\figsize}{\input{\parapath/";//17.12.07
      tmp=tmp+folder+"/"+tmp1_#+"}}%"; 
    ); // 17.08.30until
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
////%Animatefile end////

////%Mkanimation start////
Mkanimation():=(
  regional(remflg,tmp,eqL,tmp1,tmp2);
  if(!isexists(Dirwork,ParaPath), //17.10.14from
    Parafolder();
  );
  Animatefile(); //17.10.14until
  Mkanimation(Dirwork,ParaPath);
);
Mkanimation(folder):=Mkanimation(Dirwork,folder);
Mkanimation(path,folder):=(
//help:Mkanimation();
//help:Mkanimation(path,folder);
  regional(store,Fheadbkup,Pathpdfbkup,tex,article,parent,
     eqL,mag,title,tmp,tmp1,tmp2,tmp3,flg);
  store=Fillblack(); //181125
  tmp=Divoptions(ParaOpAnim); //17.11.25from
  eqL=tmp_5;
  mag="1600";
  title=folder;
  forall(eqL,
    tmp=Indexof(#,"=");
    tmp1=Toupper(substring(#,0,1));
    tmp2=substring(#,tmp,length(#));
    if(tmp1=="M",
      mag=tmp2;
    );
    if(tmp1=="T",
      title=tmp2;
    );
  ); //17.11.25until
  Fheadbkup=Fhead;
  Fhead="animate"+folder; 
  Pathpdfbkup=Pathpdf;
  Pathpdf=PathAd;
  tmp1=replace(PathT,pathsep(),"/");
  tmp=indexall(tmp1,"/");//17.10.14from
  if(length(tmp)>0,
    tex=substring(tmp1,tmp_(length(tmp)),length(tmp1));
  ,
    tex=tmp1;
  );//17.10.14until
  if((tex=="platex")%(tex=="uplatex"),
    if(tex=="platex",article="jarticle",article="ujarticle");
  ,
    article="article";
  );
  SCEOUTPUT=openfile(Fhead+".tex");
  println(SCEOUTPUT,"\documentclass[landscape]{"+article+"}");
  if((tex=="platex")%(tex=="uplatex")%(tex=="latex"),
    tmp="\special{papersize=\the\paperwidth,\the\paperheight}";
    println(SCEOUTPUT,tmp);
    println(SCEOUTPUT,"\mag="+mag);//17.11.25
  );
  if((tex=="pdflatex")%(tex=="lualatex")%(tex=="xelatex"),
    if((tex=="pdflatex")%(tex=="xelatex"),
      println(SCEOUTPUT,"\usepackage[pdftex]{pict2e}");
    ,
      println(SCEOUTPUT,"\usepackage{pict2e}");
      println(SCEOUTPUT,"\usepackage{luatexja}");
    );
    tmp=replace(Dirhead,"\","/"); //17.10.30from
    tmp=replace(tmp,"scripts","tex/latex");
    if(isexists(tmp,""),
      println(SCEOUTPUT,"\usepackage{ketpic2e,ketlayer2e}");
    ,
      tmp=replace(Dirhead+"/ketpicstyle","\","/");
      println(SCEOUTPUT,"\usepackage{"+tmp+"/ketpic2e}");
      println(SCEOUTPUT,"\usepackage{"+tmp+"/ketlayer2e}");
    );
  ,
    tmp=replace(Dirhead,"\","/"); //17.10.30from
    tmp=replace(tmp,"scripts","tex/latex");
    if(isexists(tmp,""),
      println(SCEOUTPUT,"\usepackage{ketpic,ketlayer}");
    ,
      tmp=replace(Dirhead+"/ketpicstyle","\","/");
      println(SCEOUTPUT,"\usepackage{"+tmp+"/ketpic}");
      println(SCEOUTPUT,"\usepackage{"+tmp+"/ketlayer}");
    );
  );
  println(SCEOUTPUT,"\usepackage{amsmath,amssymb}");
  println(SCEOUTPUT,"\usepackage{bm,enumerate}");
  if((tex=="platex")%(tex=="uplatex")%(tex=="latex"),
    println(SCEOUTPUT,"\usepackage[dvipdfmx]{graphicx}");
    println(SCEOUTPUT,"\usepackage[dvipdfmx]{animate}");
  ,
    println(SCEOUTPUT,"\usepackage{graphicx}");
    println(SCEOUTPUT,"\usepackage{animate}");
  );
  println(SCEOUTPUT,"\usepackage{xcolor}");
  forall(ADDPACK, tmp1,
    tmp=indexof(tmp1,"{animate}")+indexof(tmp1,"{hyperref}");
    if(tmp==0,
      println(SCEOUTPUT,"\usepackage"+tmp1);
    );
  );
  println(SCEOUTPUT,"\pagestyle{empty}");
  println(SCEOUTPUT,"\setmargin{0}{0}{0}{0}");
  println(SCEOUTPUT,"");
  println(SCEOUTPUT,"\begin{document}");
  println(SCEOUTPUT,"\large");
  println(SCEOUTPUT,"");
  println(SCEOUTPUT,"\vspace*{25mm}");
  println(SCEOUTPUT,"");
  tmp=floor(parse("290*1000/"+mag));
  print(SCEOUTPUT,"\Ctab{"+text(tmp)+"mm}{");
  print(SCEOUTPUT,"\fbox{\Large\bf "+title+"}");
  println(SCEOUTPUT,"}");
  tmp=parse("6*1000/"+mag);
  println(SCEOUTPUT,"\vspace{"+text(tmp)+"mm}");
  println(SCEOUTPUT,"");
  tmp=indexof(ULEN,"cm");
  if(tmp>0,
    tmp1=substring(ULEN,0,tmp-1);
    tmp1=parse(replace(tmp1," ",""))*10;
  );
  tmp=indexof(ULEN,"mm");
  if(tmp>0,
    tmp1=substring(ULEN,0,tmp-1);
    tmp1=parse(replace(tmp1," ",""));
  );
  tmp=parse("300*1000/"+mag);
  tmp1=(tmp-(XMAX-XMIN)*tmp1)/2;
  tmp1=tmp1+parse("("+mag+"-1000)/100*1.3");
  print(SCEOUTPUT,"\hspace*{"+text(tmp1)+"mm}");
  tmp=replace(path,"\","/"); //17.12.09(2lines)
  println(SCEOUTPUT,"\input{"+tmp+"/anim"+folder+".tex}");
  println(SCEOUTPUT,"\end{document}");
  closefile(SCEOUTPUT);
  if(iswindows(),
    parent=Dirwork+Batparent;
    Makebat(Fhead,"ttv"); 
    kc():=(
      println("kc : "+kc(parent,Dirlib,Fnametex))
    ); 
    kc();
  ,
    parent=Dirwork+Shellparent;
    Makeshell(Fhead,"ttv"); 
    kc():=(
      println("kc : "+kc(parent,Mackc+Dirlib,Fnametex));
    );
    kc();
  );
  Fhead=Fheadbkup;
  Pathpdf= Pathpdfbkup;
  Fillrestore(store); //181125
);
////%Mkanimation end////

////%Mkflipanime start////
Mkflipanime():=(
  regional(remflg,tmp,eqL,tmp1,tmp2);
  if(!isexists(Dirwork,ParaPath), //17.10.14from
    Parafolder();
  );
  Mkflipanime(Dirwork,ParaPath);
);
Mkflipanime(folder):=Mkflipanime(Dirwork,folder);
Mkflipanime(path,folder):=(
//help:Mkfilpanime();
//help:Mkflipanime(path,folder);
  regional(store,Fheadbkup,tex,article,parent,eqL,mag,title,
     tmp,tmp1,tmp2,tmp3,texfiles,flg);
  store=Fillblack(); //181125
  tmp=Divoptions(ParaOpAnim); //17.11.25from
  eqL=tmp_5;
  mag="1600";
  title=folder;
  forall(eqL,
    tmp=Indexof(#,"=");
    tmp1=Toupper(substring(#,0,1));
    tmp2=substring(#,tmp,length(#));
    if(tmp1=="M",
      mag=tmp2;
    );
    if(tmp1=="T",
      title=tmp2;
    );
  ); //17.11.25until
  Fheadbkup=Fhead;
  Fhead="flipanime"+folder; 
  tmp1=replace(PathT,pathsep(),"/");
  tmp=indexall(tmp1,"/");//17.10.14from
  if(length(tmp)>0,
    tex=substring(tmp1,tmp_(length(tmp)),length(tmp1));
  ,
    tex=tmp1;
  );//17.10.14until
  if((tex=="platex")%(tex=="uplatex"),
    if(tex=="platex",article="jarticle",article="ujarticle");
  ,
    article="article";
  );
  SCEOUTPUT=openfile(Fhead+".tex");
  println(SCEOUTPUT,"\documentclass[landscape]{"+article+"}");
  if((tex=="platex")%(tex=="uplatex")%(tex=="latex"),
    tmp="\special{papersize=\the\paperwidth,\the\paperheight}";
    println(SCEOUTPUT,tmp);
    println(SCEOUTPUT,"\mag="+mag);//17.11.25
  );
  if((tex=="pdflatex")%(tex=="lualatex")%(tex=="xelatex"),
    if((tex=="pdflatex")%(tex=="xelatex"),
      println(SCEOUTPUT,"\usepackage[pdftex]{pict2e}");
    ,
      println(SCEOUTPUT,"\usepackage{pict2e}");
      println(SCEOUTPUT,"\usepackage{luatexja}");
    );
    tmp=replace(Dirhead,"\","/"); //17.10.30from
    tmp=replace(tmp,"scripts","tex/latex");
    if(isexists(tmp,""),
      println(SCEOUTPUT,"\usepackage{ketpic2e,ketlayer2e}");
    ,
      tmp=replace(Dirhead+"/ketpicstyle","\","/");
      println(SCEOUTPUT,"\usepackage{"+tmp+"/ketpic2e}");
      println(SCEOUTPUT,"\usepackage{"+tmp+"/ketlayer2e}");
    );
  ,
    tmp=replace(Dirhead,"\","/"); //17.10.30from
    tmp=replace(tmp,"scripts","tex/latex");
    if(isexists(tmp,""),
      println(SCEOUTPUT,"\usepackage{ketpic,ketlayer}");
    ,
      tmp=replace(Dirhead+"/ketpicstyle","\","/");
      println(SCEOUTPUT,"\usepackage{"+tmp+"/ketpic}");
      println(SCEOUTPUT,"\usepackage{"+tmp+"/ketlayer}");
    );
  );
  println(SCEOUTPUT,"\usepackage{amsmath,amssymb}");
  println(SCEOUTPUT,"\usepackage{bm,enumerate}");
  if((tex=="platex")%(tex=="uplatex")%(tex=="latex"),
    println(SCEOUTPUT,"\usepackage[dvipdfmx]{graphicx}");
  ,
    println(SCEOUTPUT,"\usepackage{graphicx}");
  );
  println(SCEOUTPUT,"\usepackage{xcolor}");
  forall(ADDPACK, tmp1,
    if(tmp==0,
      println(SCEOUTPUT,"\usepackage"+tmp1);
    );
  );
  println(SCEOUTPUT,"\pagestyle{empty}");
  println(SCEOUTPUT,"\setmargin{0}{0}{0}{0}");
  println(SCEOUTPUT,"");
  println(SCEOUTPUT,"\begin{document}");
  println(SCEOUTPUT,"\large");
  println(SCEOUTPUT,"");
  tmp=fileslist(Dirwork+pathsep()+folder);
  tmp=tokenize(tmp,",");
  tmp1=select(tmp,indexof(#,".tex")>0); //180609from
  tmp1=sort(tmp1);//180617
  texfiles=[];
  forall(tmp1,
    tmp=indexof(#,".");
    tmp=parse(substring(#,1,tmp-1));
    if(tmp<=length(ParaSL),
      texfiles=append(texfiles,#);
    );
  );//180609to
  forall(texfiles,
    println(SCEOUTPUT,"\vspace*{25mm}");
    println(SCEOUTPUT,"");
    tmp=floor(parse("290*1000/"+mag));
    print(SCEOUTPUT,"\Ctab{"+text(tmp)+"mm}{");
    print(SCEOUTPUT,"\fbox{\Large\bf "+title+"}");
    println(SCEOUTPUT,"}");
    tmp=parse("6*1000/"+mag);
    println(SCEOUTPUT,"\vspace{"+text(tmp)+"mm}");
    println(SCEOUTPUT,"");
    tmp=indexof(ULEN,"cm");
    if(tmp>0,
      tmp1=substring(ULEN,0,tmp-1);
      tmp1=parse(replace(tmp1," ",""))*10;
    );
    tmp=indexof(ULEN,"mm");
    if(tmp>0,
      tmp1=substring(ULEN,0,tmp-1);
      tmp1=parse(replace(tmp1," ",""));
    );
    tmp=parse("300*1000/"+mag);
    tmp1=(tmp-(XMAX-XMIN)*tmp1)/2;
    tmp1=tmp1+parse("("+mag+"-1000)/100*1.3");
    print(SCEOUTPUT,"\hspace*{"+text(tmp1)+"mm}");
    println(SCEOUTPUT,"\input{"+folder+"/"+#+"}");
    println(SCEOUTPUT,"");
    println(SCEOUTPUT,"\newpage");
  );
  println(SCEOUTPUT,"\end{document}");  
  closefile(SCEOUTPUT);
  if(iswindows(),
    parent=Dirwork+Batparent;
    Makebat(Fhead,"tv"); 
    kc():=(
      println("kc : "+kc(parent,Dirlib,Fnametex))
    ); 
    kc();
  ,
    parent=Dirwork+Shellparent;
    Makeshell(Fhead,"tv"); 
    kc():=(
      println("kc : "+kc(parent,Mackc+Dirlib,Fnametex));
    );
    kc();
  );
  Fhead=Fheadbkup;
  Fillrestore(store); //181125
);
////%Mkflipanime end////

//help:end();

