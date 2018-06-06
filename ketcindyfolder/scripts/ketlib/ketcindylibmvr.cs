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

println("ketcindymv(20180606) loaded");

//help:start();

Setpara(path,fstr,sL):=Setpara(path,fstr,sL,[],[]); // 16.12.27added
Setpara(pathorg,fstr,sL,options):=  //17.11.25(3lines)
    Setpara(pathorg,fstr,sL,options,[]);
Setpara(pathorg,fstr,sL,options,optionsanim):=(
//help:Setpara("folder name","funstr","range",options,optionsanim);
//help:Setpara(folder,funstr,range,options);
//help:Setpara(options=["m/r","Div=25"]);
//help:Setpara(options2anim1=["Frate=10","Scale=1"]);
//help:Setpara(options2anim2=["OpA=[loop,controls,buttonsize=3mm]"]);
//help:Setpara(options2anim3=["OpA=+step"]);
//help:Setpara(options2anim4=["Mag=1600","Title=folder"]);
  regional(path,tmp,tmp1,eqL,ndiv);
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
  if((!contains(Paraop,"r"))&(!contains(ParaOp,"m")), //180515(3lines)
    ParaOp=append(ParaOp,"m");//180604
  );
  ParaOpAnim=optionsanim;  //17.11.25
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
Parafolder(path,fstr,sL,optionorg):=(
//help:Parafolder(foldername,1..4);
//help:Parafolder(foldername,"s=[0,1]");
//help:Parafolder("mf(s)",foldername,"s=[0,1]");
//help:Parafolder(options=["m/r","Div=25","Wait=20","Out=n"]); 
//help:Paraslide(para=folder:layery:pos:input,scale); 
//help:Paraslide(para=folder:layery:pos:include:[width=100]); 
  regional(nn,tmp,tmp1,tmp2,strL,eqL,waiting,outflg,
        mkr,mktex,options,sfL,dirbkup,fbkup,ctr,fnameRbkup);
  dirbkup=Dirwork;
  Changework(dirbkup+pathsep()+path);
  if(!isstring(ParaPath),
    println("Setpara should be defined");
  ,
    tmp=indexof(fstr,"(");
    tmp1=substring(fstr,tmp,length(fstr));
    tmp=indexof(tmp1,")");
    tmp1=substring(tmp1,0,tmp-1);
    parse("Movieframe("+tmp1+"):="+fstr);
    options=optionorg;
    tmp=Divoptions(options);
    eqL=tmp_5;
    strL=tmp_7;
    if(length(strL)==0,options=append(options,"m"));//16.12.18
    mkr="A";
    mktex="A";
    waiting=20;
    outflg=0;
    forall(eqL,
      tmp=Strsplit(#,"=");
      tmp1=Toupper(substring(tmp_1,0,1));
      if(tmp1=="W",
        waiting=parse(tmp_2);
        options=remove(options,[#]);
      );
      if(tmp1=="O", //180606from
        tmp=Toupper(substring(tmp_2,0,1));
        if(tmp=="Y", outflg=1);
        options=remove(options,[#]);
      ); //180606to
    );
    forall(strL,
      tmp1=Toupper(substring(#,0,1));
      if(tmp1=="M",
        mkr="Y"; mktex="Y";
      );
    );
    if(mkr=="Y",
      tmp1=fileslist(Dirwork);
      tmp1=tokenize(tmp1,",");
      if(length(tmp1)>1,
        tmp1=dirbkup+pathsep()+path;
        tmp1=replace(tmp1,"\","/");//17.10.13
        cmdL=[
          "setwd",[Dq+tmp1+Dq],
          "fL=as.matrix(list.files())",[],
          "apply",["fL",2,"file.remove"]
        ];
        CalcbyR("rvf",cmdL,["Cat=n","m"]);
        tmp=dirbkup+pathsep()+path;
        repeat(1..30,
          if(length(fileslist(tmp))>0,wait(10));
         );
      );
      Changework(dirbkup+pathsep()+path);
    );
    if(outflg==1, //180606from
      fbkup=Fhead;
      ctr=1;
      forall(sL,
        tmp="000000"+text(ctr);
        tmp="p"+substring(tmp,length(tmp)-3,length(tmp));
        Setfiles(tmp);
        Changework(dirbkup+pathsep()+path);
        Movieframe(#);
        ctr=ctr+1;
      );
      Setfiles(fbkup);
    ); //180606to
    Changework(dirbkup);
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
      tmp1=Sprintf(nn/1000,3);
      tmp=indexof(tmp1,".");
      tmp1=substring(tmp1,tmp,length(tmp1));
      FnameR="/p"+tmp1+".r";
      fnameRbkup=FnameR;
      sfL=append(sfL,FnameR);
      Fnametex=replace(FnameR,".r",".tex");
      Changework(dirbkup+pathsep()+path);
      if(outflg==0,
        Movieframe(sL_nn); //17.10.13
      ,
        Changework(dirbkup+pathsep()+path);
        fbkup=Fhead;
        tmp="000000"+text(ctr);
        tmp="p"+substring(tmp,length(tmp)-3,length(tmp));
        Setfiles(tmp);
        Changework(dirbkup+pathsep()+path);//180606
        Movieframe(sL_nn);
        Changework(dirbkup+pathsep()+path);//180606
        FnameR=fnameRbkup;//180606
        ctr=ctr+1;
      );
      if(!isexists(dirbkup+pathsep()+path,FnameR) % mkr=="Y",
        if(ErrFlag!=-1,
          WritetoRS(2); //17.12.09
        );
      );
    ); 
    Changework(dirbkup+pathsep()+path);
    GLIST=select(GLIST,indexof(#,"Projpara")==0);
    FnameR="all.r";
    tmp1=replace(dirbkup+pathsep()+path,"\","/"); //17.10.13
    cmdL=[
      "setwd("+Dqq(tmp1)+")",[],
      "size="+text(length(sL)),[],
      "for(n in Looprange(1,size)){",[],
      "  tmp=as.character(n)",[],
      "  tmp=paste('0000',tmp,sep='')",[],
      "  tmp=substring(tmp,nchar(tmp)-2,nchar(tmp))",[],
      "  fname=paste('p',tmp,'.r',sep='')",[],
      "  lines=readLines(fname)",[],
      "  lines=lines[1:(length(lines)-1)]",[],
      "  tmp=paste('print(',as.character(n),')',sep='')",[],
      "  lines=c(tmp,lines)",[],
      "  for(j in Looprange(1,length(lines))){",[],
      "    cat(lines[j],file='all.r',sep='\n',append=TRUE)",[],
      "  }",[],
      "}",[],
      "source('all.r')",[]
    ];
    if(ErrFlag!=-1,
      if(!isexists(dirbkup+pathsep()+path,Fnametex) % mktex=="Y",
        CalcbyR("",cmdL,["Cat=n","m","Wait="+text(waiting)]);
      ,
        println("Parafolder "+path+" finished");//16.12.20
      );
      if(length(after)>0, // 16.12.27
        parse(after);
      );
      FnameR=Fhead+".r";
      Fnametex=Fhead+".tex";
    );
  );
  Changework(dirbkup);
);

Animatefile():=Animatefile(Dirwork,ParaPath);
Animatefile(path,folder):=(
//help:Animatefile();
//help:Animatefile(Dirwork,ParaPath);
  regional(FRate, Scale, OpA, pa,fname,eqL,tmp,tmp1,tmp2);
  tmp=divoptions(ParaOpAnim); //17.11.24
  eqL=tmp_5;
  FRate="10";
  Scale="1";
  OpA="loop,controls,buttonsize=3mm";
  remflg=0;
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
    if(tmp1=="OP",  // 17.12.07from
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
  SCEOUTPUT= openfile(fname);
  println(SCEOUTPUT,"\def\parapath{"+pa+"}%"); //17.06.22
  println(SCEOUTPUT,"\def\figsize{"+Scale+"}%"); //17.12.07
  println(SCEOUTPUT,"\begin{animateinline}"+OpA+"{"+FRate+"}%");
  forall(1..(length(tmp1)),
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
  regional(Fheadbkup,Pathpdfbkup,tex,article,parent,
     eqL,mag,title,tmp,tmp1,tmp2,tmp3,flg);
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
);

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
  regional(Fheadbkup,tex,article,parent,eqL,mag,title,
     tmp,tmp1,tmp2,tmp3,texfiles,flg);
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
  texfiles=select(tmp,indexof(#,".tex")>0);
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
);

//help:end();

