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

println("ketcindybasic2[20190301] loaded");

//help:start();

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

////%Rotatepoint start////
Rotatepoint(point,Theta,ctr):=(
//help:Rotatepoint(A,2*pi/3,B);
  regional(X1,X2,Y1,Y2,Cx,Cy,tmp);
  tmp=Lcrd(point);
  X1=tmp_1; Y1=tmp_2;
  tmp=Lcrd(ctr);
  Cx=tmp_1; Cy=tmp_2;
  X2=Cx+(X1-Cx)*cos(Theta)-(Y1-Cy)*sin(Theta);
  Y2=Cy+(X1-Cx)*sin(Theta)+(Y1-Cy)*cos(Theta); 
  [X2,Y2];
);
////%Rotatepoint end////

////%Translatepoint start////
Translatepoint(point,mov):=(
//help:Translatepoint(A,[2,3]);
  regional(X1,X2,Y1,Y2,Cx,Cy,tmp);
  tmp=Lcrd(point);
  X1=tmp_1; Y1=tmp_2;
  tmp=Lcrd(mov);
  Cx=tmp_1; Cy=tmp_2;
  X2=X1+Cx;
  Y2=Y1+Cy; 
  [X2,Y2];
);
////%Translatepoint end////

////%Scalepoint start////
Scalepoint(point,ratio,center):=(
//help:Scalepoint(A,[3,2],[0,0]);
  regional(X1,X2,Y1,Y2,Cx,Cy,tmp);
  tmp=Lcrd(point);
  X1=tmp_1; Y1=tmp_2;
  tmp=Lcrd(center);
  Cx=tmp_1; Cy=tmp_2;
  X2=Cx+ratio_1*(X1-Cx);
  Y2=Cy+ratio_2*(Y1-Cy);
  [X2,Y2];
);
////%Scalepoint end////

////%Reflectpoint start////
Reflectpoint(point,symL):=(
//help:Reflectpoint(A,B);
//help:Reflectpoint(A,[[2,3]]);
//help:Reflectpoint(A,[C,E]);
  regional(X1,X2,Y1,Y2,Us,Vs,Pt1,Pt2,Cx,Cy,tmp);
  tmp=Lcrd(point);
  X1=tmp_1; Y1=tmp_2;
  Pt1=Lcrd(symL_1);
  if(length(symL)==1,
    Pt2=Pt1;
  ,
    Pt2=Lcrd(symL_2);
  );
  Us=Pt2_1-Pt1_1;
  Vs=Pt2_2-Pt1_2;
  if(Pt1==Pt2,
    X2=2*Pt1_1-X1;
    Y2=2*Pt1_2-Y1;
  ,
    X2=(Us^2-Vs^2)/(Us^2+Vs^2)*X1+2*Us*Vs/(Us^2+Vs^2)*Y1
              -2*Vs*(Us*Pt1_2-Vs*Pt1_1)/(Us^2+Vs^2);
    Y2=2*Us*Vs/(Us^2+Vs^2)*X1-(Us^2-Vs^2)/(Us^2+Vs^2)*Y1
              +2*Us*(Us*Pt1_2-Vs*Pt1_1)/(Us^2+Vs^2);
  );
  [X2,Y2];
);
////%Reflectpoint end////

////%Rotatedata start////
Rotatedata(nm,plist,Theta):=Rotatedata(nm,plist,Theta,[]);
Rotatedata(nm,plist,angle,options):=(
//help:Rotatedata("1",["crAB","pt1"],pi/3,[[1,5],"dr,2"]);
//help:Rotatedata("1",[[A.xy],[B.xy]],pi/3,[[1,5],"dr,2"]);
  regional(tmp,tmp1,tmp2,pdata,Theta,Pt,Cx,Cy,PdLL,PdL,
    opcindy,Nj,Njj,Kj,Mj,X1,Y1,X2,Y2,Ltype,Noflg,name,color);
  name="rt"+nm;
  Pt=[0,0];
  tmp=Divoptions(options);
  Ltype=tmp_1;
  Noflg=tmp_2;
  color=tmp_(length(tmp)-2);
  opcindy=tmp_(length(tmp));
  tmp1=tmp_6;
  if(length(tmp1)>0,Pt=Lcrd(tmp1_1));
  pdata=plist;
  if(isstring(pdata),pdata=[pdata]);
  if(!isstring(pdata_1) & Measuredepth(pdata)==1,
      pdata=[pdata];
  );
  if(isstring(angle),Theta=parse(angle),Theta=angle);
  Cx=Pt_1; Cy=Pt_2;
  PdL=[];
  forall(pdata,Njj,
    if(isstring(Njj),Kj=parse(Njj),Kj=Njj);
    if(Measuredepth(Kj)==0,Kj=[Kj]); //17.11.24
    if(Measuredepth(Kj)==1,Kj=[Kj]);
    tmp2=[];
    forall(Kj,Nj,
      tmp1=[];
      forall(Nj,
        tmp=LLcrd(#);
        X1=tmp_1;         
        Y1=tmp_2;    
        X2=Cx+(X1-Cx)*cos(Theta)-(Y1-Cy)*sin(Theta);
        Y2=Cy+(X1-Cx)*sin(Theta)+(Y1-Cy)*cos(Theta); 
        tmp1=concat(tmp1,[[X2,Y2]]);
      );
      tmp2=concat(tmp2,[tmp1]);
    );
    PdL=concat(PdL,tmp2);
  );
  if(Noflg<3,
    println("generate Rotatedata "+name);
    tmp1=[];
    forall(PdL,tmp2,
      tmp=apply(tmp2,Pcrd(#));
      tmp1=append(tmp1,tmp);
    );
    if(length(tmp1)==1,tmp1=tmp1_1);
    tmp=name+"="+Textformat(tmp1,5);
    parse(tmp);
    tmp1=text(plist); //no ketjs on
    tmp1=RSform(tmp1,1);// 180602
    tmp=name+"=Rotatedata("+tmp1+","
    +Textformat(angle,5)+","+RSform(Textformat(Pt,5))+")"; //17.12.23
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
  PdL;
);
////%Rotatedata end////

////%Translatedata start////
Translatedata(nm,plist,mov):=Translatedata(nm,plist,mov,[]);
Translatedata(nm,plist,mov,options):=(
//help:Translatedata("1",["gr1","pt1"],[1,2]);
  regional(tmp,tmp1,tmp2,pdata,Cx,Cy,PdL,Nj,Njj,Kj,
           opcindy,X2,Y2,Ltype,Noflg,name,color,leveL);
  name="tr"+nm;
  tmp=Divoptions(options);
  Ltype=tmp_1;
  Noflg=tmp_2;
  color=tmp_(length(tmp)-2);
  opcindy=tmp_(length(tmp));
  pdata=plist;
  if(isstring(pdata),pdata=[pdata]);
  if(!isstring(pdata_1) & Measuredepth(pdata)==1,
      pdata=[pdata];
  );
  tmp=Lcrd(mov);
  Cx=tmp_1; Cy=tmp_2;
  PdL=[];
  forall(pdata,Njj,
    if(isstring(Njj),Kj=parse(Njj),Kj=Njj);
    if(Measuredepth(Kj)==1,Kj=[Kj]);
    tmp2=[];
    forall(Kj,Nj,
      tmp1=[];
      forall(Nj,
        tmp=LLcrd(#);
        X2=tmp_1+Cx;         
        Y2=tmp_2+Cy;    
        tmp1=concat(tmp1,[[X2,Y2]]);
      );
      tmp2=concat(tmp2,[tmp1]);
    );
    PdL=concat(PdL,tmp2);
  );
  if(Noflg<3,
    println("generate Translatedata "+name);
    tmp1=[];
    forall(PdL,tmp2,
      tmp=apply(tmp2,Pcrd(#));
      tmp1=append(tmp1,tmp);
    );
    if(length(tmp1)==1,tmp1=tmp1_1);
    tmp=name+"="+Textformat(tmp1,5);
    parse(tmp);
    tmp1=text(plist); //no ketjs on
    tmp1=RSform(tmp1,1);// 180602
    tmp=name+"=Translatedata("+tmp1+","+RSform(Textformat(mov,5))+")";
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
  PdL;
);
////%Translatedata end////

////%Scaledata start////
Scaledata(nm,plist,ratioV):=(
  regional(tmp);
  tmp=ratioV; //180603from
  if(!islist(tmp),tmp=[tmp,tmp]);
  tmp=Lcrd(tmp);//180603to
  Scaledata(nm,plist,tmp_1,tmp_2,[]);
);
Scaledata(nm,plist,Arg1,Arg2):=(
//help:Scaledata("1",["crAB","pt1"],3,2,[[0,0]]);
//help:Scaledata("1",["crAB","pt1"],2,[[0,0]]);
  regional(tmp,options);
  if(islist(Arg2),
    tmp=Arg1;//180603[2lines]
    if(!islist(tmp),tmp=[tmp,tmp]);
    tmp=Lcrd(tmp);
    options=Arg2;
    Scaledata(nm,plist,tmp_1,tmp_2,options);
  ,
    Scaledata(nm,plist,Arg1,Arg2,[]);
  );
);
Scaledata(nm,plist,rx,ry,options):=(
  regional(tmp,tmp1,tmp2,pdata,Theta,Pt,Cx,Cy,PdL,
      opcindy,Nj,Njj,Kj,X2,Y2,Ltype,Noflg,name,color);
  name="sc"+nm;
  Pt=[0,0];
  tmp=Divoptions(options);
  Ltype=tmp_1;
  Noflg=tmp_2;
  color=tmp_(length(tmp)-2);
  opcindy=tmp_(length(tmp));
  tmp1=tmp_6;
  if(length(tmp1)>0,
    Pt=Lcrd(tmp1_1);
  );
  pdata=plist;
  if(isstring(pdata),pdata=[pdata]);
  if(!isstring(pdata_1) & Measuredepth(pdata)==1,
      pdata=[pdata];
  );
  Cx=Pt_1; Cy=Pt_2;
  PdL=[];
  forall(pdata,Njj,
    if(isstring(Njj),Kj=parse(Njj),Kj=Njj);
    if(Measuredepth(Kj)==1,Kj=[Kj]);
    tmp2=[];
    forall(Kj,Nj,
      tmp1=[];
      forall(Nj,
        tmp=LLcrd(#);
        X2=Cx+rx*(tmp_1-Cx);
        Y2=Cy+ry*(tmp_2-Cy);
        tmp1=concat(tmp1,[[X2,Y2]]);
      );
      tmp2=concat(tmp2,[tmp1]);
    );
    PdL=concat(PdL,tmp2);
  );
  if(Noflg<3,
    println("generate Scaledata "+name);
    tmp1=[];
    forall(PdL,tmp2,
      tmp=apply(tmp2,Pcrd(#));
      tmp1=append(tmp1,tmp);
    );
    if(length(tmp1)==1,tmp1=tmp1_1);
    tmp=name+"="+Textformat(tmp1,5);
    parse(tmp);
    tmp1=text(plist); //no ketjs on
    tmp1=RSform(tmp1,1); // 180602
    tmp=name+"=Scaledata("+tmp1+","
      +Textformat(rx,5)+","+Textformat(ry,5)+","+RSform(Textformat(Pt,5))+")";
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
  PdL;
);
////%Scaledata end////

////%Reflectdata start////
Reflectdata(nm,plist,symL):=Reflectdata(nm,plist,symL,[]);
Reflectdata(nm,plist,symL,options):=(
//help:Reflectdata("1",["crAB"],[C]);
  regional(tmp,tmp1,tmp2,pdata,Us,Vs,Pt1,Pt2,Cx,Cy,PdL,
      opcindy,Nj,Njj,Kj,X1,Y1,X2,Y2,Ltype,Noflg,name,color);
  name="re"+nm;
  Pt=[0,0];
  tmp=Divoptions(options);
  Ltype=tmp_1;
  Noflg=tmp_2;
  color=tmp_(length(tmp)-2);
  opcindy=tmp_(length(tmp));
  pdata=plist;
  if(isstring(pdata),pdata=[pdata]);
  if(!isstring(pdata_1) & Measuredepth(pdata)==1,
      pdata=[pdata];
  );
  Pt1=Lcrd(symL_1);
  if(length(symL)==1,
    Pt2=Pt1;
  ,
    Pt2=Lcrd(symL_2);
  );
  Us=Pt2_1-Pt1_1;
  Vs=Pt2_2-Pt1_2;
  PdL=[];
  forall(pdata,Njj,
    if(isstring(Njj),Kj=parse(Njj),Kj=Njj);
    if(Measuredepth(Kj)==1,Kj=[Kj]);
    tmp2=[];
    forall(Kj,Nj,
      tmp1=[];
      forall(Nj,
      tmp=LLcrd(#);
        X1=tmp_1;         
        Y1=tmp_2;    
        if(Pt1==Pt2,
          X2=2*Pt1_1-X1;
          Y2=2*Pt1_2-Y1;
        ,
          X2=(Us^2-Vs^2)/(Us^2+Vs^2)*X1+2*Us*Vs/(Us^2+Vs^2)*Y1
                -2*Vs*(Us*Pt1_2-Vs*Pt1_1)/(Us^2+Vs^2);
          Y2=2*Us*Vs/(Us^2+Vs^2)*X1-(Us^2-Vs^2)/(Us^2+Vs^2)*Y1
                +2*Us*(Us*Pt1_2-Vs*Pt1_1)/(Us^2+Vs^2);
        );
        tmp1=concat(tmp1,[[X2,Y2]]);
      );
      tmp2=concat(tmp2,[tmp1]);
    );
    PdL=concat(PdL,tmp2);
  );
  if(Noflg<3,
    println("generate Reflectdata "+name);
    tmp1=[];
    forall(PdL,tmp2,
      tmp=apply(tmp2,Pcrd(#));
      tmp1=append(tmp1,tmp);
    );
    if(length(tmp1)==1,tmp1=tmp1_1);
    tmp=name+"="+Textformat(tmp1,5);
    parse(tmp);
    tmp1=text(plist); //no ketjs on
    tmp1=RSform(tmp1,1);// 180602
    tmp=name+"=Reflectdata("+tmp1+","+RSform(Textformat(symL,5))+")";//17.12.23
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
  PdL;
);
////%Reflectdata end////

// 180800 revised
////%Mksegments start////
Mksegments():=Mksegments([]);
Mksegments(options):=(
//help:Mksegments();
  regional(ctr,segstr,p,q,r,tmp1,tmp2,tmp3);
  ctr=1;//180809
  forall(allsegments(),seg,
    str=text(inspect(seg,"definition"));
    tmp1=indexof(str,"(");
    tmp2=indexof(str,";");
    tmp3=indexof(str,")");
    p=substring(str,tmp1,tmp2-1);
    q=substring(str,tmp2,tmp3-1);
    Listplot("all"+text(ctr),[parse(p),parse(q)]);//180800
    ctr=ctr+1;
  );
);
////%Mksegments end////

// 180809 revised
////%Mkcircles start////
Mkcircles():=Mkcircles([]);
Mkcircles(options):=(
//help:Mkcircles():
  regional(str,ctr,tmp,tmp1,tmp2);
  ctr=1;
  forall(allcircles(),cir,
    str=text(inspect(cir,"definition"));
    tmp1=indexof(str,"(");
    tmp2=indexof(str,")");
    str=substring(str,tmp1,tmp2-1);
    tmp=Strsplit(str,";");
    tmp1=parse(tmp_1); tmp2=parse(tmp_2);
    if(ispoint(tmp2),
      Circledata("all"+text(ctr),[tmp1,tmp2],options);
    ,
      tmp=cir.radius;
      Circledata("all"+text(ctr),[tmp1,tmp1+[tmp2,0]],options);
    );
    ctr=ctr+1;
  );
);
////%Mkcircles end////

////%MakeRarg start////
MakeRarg(arglist):=(
  regional(str,tmpstr);
  str="";
  forall(arglist,
    if(isstring(#),
      tmpstr=Dq+RSslash(#)+Dq;
    ,
      tmpstr=Textformat(#,6);
    );
    str=str+tmpstr+",";
  );
  str=substring(str,0,length(str)-1);
  str;
);
////%MakeRarg end////

////%Htickmark start////
Htickmark(arglist):=Htickmark(arglist,[]); //190203
Htickmark(arglist,options):=( //190203
//help:Htickmark([1,"1",2,"sw","2"]);
  regional(nn,tmp,tmp1,tmp2,mark);
  mark=MARKLEN/SCALEY;
  tmp1=select(1..(length(arglist)),!isstring(arglist_#)); //180710from
  forall(tmp1,nn,
    Listplot("ht"+text(nn),
        [[arglist_nn,mark],[arglist_nn,-mark]],["Msg=n"]);//181017
    if(nn+2<=length(arglist),
      tmp=arglist_(nn+2);
      if(!isstring(tmp),
        Expr([[arglist_nn,0],"s1",arglist_(nn+1)],options); //190203
      ,
        Expr([[arglist_nn,0],arglist_(nn+1),arglist_(nn+2)],options); //190203
      );
    ,
      Expr([[arglist_nn,0],"s1",arglist_(nn+1)],options); //190203
    );
  );//180710to
//  tmp="";
//  tmp=MakeRarg(arglist);
//  Com2nd("Htickmark("+tmp+")");
);
////%Htickmark end////

////%Vtickmark start////
Vtickmark(arglist):=Vtickmark(arglist,[]); //190203
Vtickmark(arglist,options):=( //190203
//help:Vtickmark([1,"1",2,"sw","2"]);
  regional(nn,tmp,tmp1,tmp2,mark);
  mark=MARKLEN/SCALEX;
  tmp1=select(1..(length(arglist)),!isstring(arglist_#)); //180710from
  forall(tmp1,nn,
    Listplot("vt"+text(nn),
         [[mark,arglist_nn],[-mark,arglist_nn]],["Msg=n"]); //181021
    if(nn+2<=length(arglist),
      tmp=arglist_(nn+2);
      if(!isstring(tmp),
        Expr([[0,arglist_nn],"w1",arglist_(nn+1)],options); //190203
      ,
        Expr([[0,arglist_nn],arglist_(nn+1),arglist_(nn+2)],options); //190203
      );
    ,
      Expr([[0,arglist_nn],"w1",arglist_(nn+1)],options); //190203
    );
  );//180710to//  tmp=MakeRarg(arglist);
//  Com2nd("Vtickmark("+tmp+")");
);
////%Vtickmark end////

////%Vtick start////
Vtick(py):=Vtick(py,MARKLEN,[]);
Vtick(py,len):=Vtick(py,len,[]);
Vtick(py,len,options):=(
//help:Vtick(1,0.1,options);
  regional(tmp,tmp1,tmp2);
  tmp="v"+text(round(py*100));
  tmp=replace(tmp,"-","m");
  tmp1=[0-len/2,py];
  tmp2=[0+len/2,py];
  Listplot(tmp,[tmp1,tmp2],options);
);
////%Vtick end////

////%Htick start////
Htick(px):=Htick(px,MARKLEN,[]);
Htick(px,len):=Htick(px,len,[]);
Htick(px,lenorg,options):=(
//help:Htick(-1,0.1,options);
  regional(len,tmp,tmp1,tmp2);
  tmp=LLcrd([0,lenorg]);
  len=tmp_2;
  tmp="h"+text(round(px*100));
  tmp=replace(tmp,"-","m");
  tmp1=[px,0-len/2];
  tmp2=[px,0+len/2];
  Listplot(tmp,[tmp1,tmp2],options);
);
////%Htick end////

////%Setax start////
Setax(arglist):=(
//help:Setax(["l","x","e","y","n","O","sw"]);
//help:Setax([7,"nw"]);
//help:Setax([8,linestyle,colorax,colorlabel]);
  regional(st,nn,tmp); //181215from
  st=1; nn=1;
  if(isreal(arglist_1),
    st=2;
    nn=arglist_1;
  );
  forall(st..(length(arglist)),
    tmp=arglist_#;
    if(length(tmp)>0,AXSTYLE_nn=tmp);
    nn=nn+1;
  ); //181215from
//  tmp=MakeRarg(arglist);
//  Com1st("Setax("+tmp+")");
);
////%Setax end////

////%Drwxy start////
Drwxy():=Drwxy(0,[]); //190103from
Drwxy(Arg):=(
  if(islist(Arg),Drwxy(0,Arg); Drwxy(Arg,[]));
);
Drwxy(add):=Drwxy(add,[]);
Drwxy(add,optionsorg):=( //190103to
//help:Drwxy();
//help:Drwxy(1[the last axis will be drawn],oprions);
//help:Drwxy(options);
//help:Drwxy(options=["Xrng=","Yrng=","Ax=l,x,e,..."]);
  regional(options,color,eqL,strL,org,xrng,yrng,ax,st,nn,size,
  linesty,colorax,colorla,tmp,tmp1,tmp2);
  options=optionsorg;
  tmp=Divoptions(options);
  color=tmp_(length(tmp)-2);
  eqL=tmp_5;
  org=GENTEN; 
  //tmp1=max([org_1+XMIN,XMIN]);
  //tmp2=min([org_1+XMAX,XMAX]);
  xrng=[XMIN,XMAX];  //190103
  //tmp1=max([org_2+YMIN,YMIN]);
  //tmp2=min([org_2+YMAX,YMAX]);
  yrng=[YMIN,YMAX];  //190103
  ax=AXSTYLE;
  linesty=ax_8;
  if(isstring(ax_9),colorax=ax_9,colorax=text(ax_9));
  if(length(colorax)>0,
    colorax="Color="+colorax;
  );
  if(isstring(ax_10),colorla=ax_10,colorla=text(ax_10));
  if(length(colorla)>0, //181217from
    colorla="Color="+colorla;
  ,
    if(length(colorax)>0,
      colorla=colorax;
    );
  ); //181217to
  forall(eqL,
    tmp=Strsplit(#,"=");
    tmp1=Toupper(substring(tmp_1,0,1));
    if(tmp1=="O", //190103from
      org=parse(tmp_2);
      options=remove(options,[#]);
    );  //190103to
    if(tmp1=="X",
      xrng=parse(tmp_2);
      options=remove(options,[#]);
    );
    if(tmp1=="Y",
      yrng=parse(tmp_2);
      options=remove(options,[#]);
    );
    if(tmp1=="A",
      tmp2=tokenize(tmp_2,",");
      st=1; nn=1;
      if(isreal(tmp2_1),
        st=2;
        nn=tmp2_1;
      );
      forall(st..(length(tmp2)),
        tmp=tmp2_#;
        if(length(tmp)>0,ax_nn=tmp);
        nn=nn+1;
      );
      options=remove(options,[#]);
    );
  );
  options=append(options,linesty); //181216
  if(substring(ax_1,0,1)=="a",
    strL=select(options,isstring(#)); //181216
    tmp=select(strL,contains(["dr","da","do","id"],substring(#,0,2)));
    if(length(tmp)==0,options=append(options,YasenStyle));
    tmp=substring(ax_1,1,length(ax_1)); //181216[2lines]
    if(length(tmp)>0,size=parse(tmp),size=YaSize);
    tmp1=concat(options,[size,YaAngle,YaPosition,YaCut,colorax]);//181216
    tmp=[[xrng_1,org_2],[xrng_2,org_2]];
    Arrowdata("axx"+text(AXCOUNT),tmp,tmp1);
    tmp=[[org_1,yrng_1],[org_1,yrng_2]];
    Arrowdata("axy"+text(AXCOUNT),tmp,tmp1);
  ,
    tmp=[[xrng_1,org_2],[xrng_2,org_2]];
    tmp1=append(options,colorax);//181216
    Listplot("axx"+text(AXCOUNT),tmp,tmp1); 
    tmp=[[org_1,yrng_1],[org_1,yrng_2]];
    Listplot("axy"+text(AXCOUNT),tmp,tmp1); 
  );
  AXCOUNT=AXCOUNT+1;
  Expr([[xrng_2,org_2],ax_3,ax_2],[colorla]);//181216[3lines]
  Expr([[org_1,yrng_2],ax_5,ax_4],[colorla]);
  Letter([org,ax_7,ax_6],[colorla]);
  if(add==0, //190103
    Addax(0);
  );
);
////%Drwxy end////

////%Drwpt start////
Drwpt(pstr):=Drwpt(pstr,1); //181231
Drwpt(ptlist,nn):=(  // 16.03.05 from
//help:Drwpt(A);
//help:Drwpt([1,2],0);
  if(!isreal(DrwPtCtr), //181231from
    DrwPtCtr=1;
  );
  Pointdata(text(DrwPtCtr),ptlist,["Inside="+text(nn)]);
  DrwPtCtr=DrwPtCtr+1; //181231to
);
////%Drwpt end////
////%Drawpoint start////
Drawpoint(pstr):=(
  if(isstring(pstr),
    println("Drwpt : "+pstr);
    Com2nd("Drwpt("+pstr+")");
  ,
    Drawpoint(pstr,1);
  );
);
Drawpoint(ptlistorg,nn):=(
  regional(ptlist,thick,tmp,tmp1);
  println("Drwpt : "+text(ptlistorg));
  if(islist(ptlistorg),
    if(Measuredepth(ptlistorg)==1,
      ptlist=ptlistorg
    ,
      ptlist=[ptlistorg]
    );
  ,
    ptlist=[ptlistorg]
  );
  thick=PenThick/PenThickInit;// 16.04.09 from
  tmp1=max(TenSize/TenSizeInit,1)/8; 
  Setpen(tmp1); // 16.04.09 until
  forall(ptlist,
    tmp=Textformat(#,5)+","+text(nn);
    Com2nd("Drwpt("+tmp+")"); // 16.04.09
  );
  Setpen(thick); // 16.04.09
);// 16.03.05 until
////%Drawpoint end////

////%Addax start////
Addax(param):=(
//help:Addax(0);
  ADDAXES=text(param);
);
////%Addax end////

////%Expr start////
Expr(Pt,Dr,St):=Expr([Pt,Dr,St]);
Expr(list):=Expr(list,[]);
Expr(listorg,options):=( //16.10.09
//help:Expr([A,"e","f(x)=x^2"]);
//help:Expr([A,"e","f(x)=x^2"],["size->24"]);
  regional(list,str,tmp,tmp1,tmp2);
  list=listorg;
  forall(1..round(length(list)/3),
    str=list_(3*#);
    if(!isstring(str),str=format(str,5));
    str="$"+str+"$";
    list_(3*#)=str;
  );
  Letter(list,options);
);
////%Expr end////

////%Letter start////
Letter(Pt,Dr,St):=Letter([Pt,Dr,St]);
Letter(list):=Letter(list,[]);
Letter(Pt,Dr,St,options):=Letter([Pt,Dr,St],options);//181218
Letter(list,options):=(
//help:Letter([C,"c","Graph of $f(x)$"]);
//help:Letter([C,"c","xy"],["size->30"]);
  regional(Nj,Pos,Dir,Str,Off,Dmv,Xmv,Ymv,Noflg,opcindy,
      opL,aln,sz,clr,bld,ita,tmp,tmp1,tmp2,color,eqL);
  tmp=Divoptions(options);
  eqL=tmp_5; //190209
  Noflg=tmp_2;
  color=tmp_(length(tmp)-2);
  opL=select(options,indexof(#,"->")>0); //16.10.09from
  tmp=select(opL,indexof(#,"color"));
  sz=12;
  bld=false;
  ita=false;
  aln="left";
  forall(opL,
    tmp=indexof(#,"->");
    tmp1=Removespace(substring(#,0,tmp-1));
    tmp2=substring(#,tmp+1,length(#));
    if(tmp1=="size",sz=parse(tmp2));
    if(tmp1=="color",clr=parse(tmp2));
    if(tmp1=="bold",bld=parse(tmp2));
    if(tmp1=="ita",ita=parse(tmp2));
  );//16.10.09to
  forall(eqL, //190209from
    tmp=Strsplit(#,"=");
    tmp1=Toupper(substring(tmp_1,0,1));
    if(tmp1=="S",
      sz=round(parse(tmp_2)*12);
    );
  ); //190209to
  Off=-4;
  Dmv=8;
  Nj=1;
  while(Nj+2<=length(list),
    Pos=list_Nj;
    Dir=list_(Nj+1);
    tmp=indexof(Dir,"s")+indexof(Dir,"n");//16.10.19from
    if(tmp>0, 
      tmp=indexof(Dir,"w")+indexof(Dir,"e");
      if(tmp==0,
        Dir="c"+Dir;//16.10.08
      );
    );//16.10.19until
    Str=list_(Nj+2);
    if(!isstring(Str),Str=format(Str,5)); // 16.09.30,10.09
    tmp=replace(Str,".xy","");
    tmp=replace(tmp,".x","(1)");
    Str=replace(tmp,".y","(2)");
    Str=RSslash(Str); // 17.09.24
    Str=replace(Str,"`","'");//180303
    tmp=Dq+","+Dq+Str+Dq+")";
    if(Noflg==0, //no ketjs on
      if((Noflg==0)&(color!=KCOLOR), //180904
        Texcom("{");Com2nd("Setcolor("+color+")");//180722
      );
      Com2nd("Letter("+Lcrd(Pos)+","+Dq+Dir+tmp);//16.10.10
      if((Noflg==0)&(color!=KCOLOR), //180904 
        Texcom("}");//180722
      );
    ); //no ketjs off
    if(Noflg<2,
      Xmv=0;//16.10.13
      Ymv=-4;
      if(indexof(Dir,"n")>0,
        Ymv=Dmv/2;
      );
      if(indexof(Dir,"s")>0,
        Ymv=-Dmv*3/2;//16.10.13
      );
      if(indexof(Dir,"e")>0,
        Xmv=Dmv/2;
        Off=0;
        aln="left"; 
      );
      if(indexof(Dir,"w")>0, 
        Xmv=-Dmv/2;
        Off=0; // 16.09.30from
        aln="right"; 
      );
      if(indexof(Dir,"c")>0,
        Xmv=0;//16.10.13
        Off=0;
        if(Ymv==0,Ymv=-4);//16.10.08
        aln="mid"; // 16.09.30until
      );
      Str=list_(Nj+2);  //17.10.17
      drawtext(Pcrd(Pos),Str,offset->[Off+Xmv,Off+Ymv],
         size->sz,color->color,align->aln,bold->bld,italics->ita);//16.10.09
    );
    Nj=Nj+3;
  );
);
////%Letter end////

////%Letterrot start////
Letterrot(pt,dir,str):=Letterrot(pt,dir,0,0,str,[]);
Letterrot(pt,dir,Arg1,Arg2):=(
  if(islist(Arg2),
    Letterrot(pt,dir,"t0n0",Arg1,Arg2);
  ,
    Letterrot(pt,dir,Arg1,Arg2,[]);
  );
);
Letterrot(pt,dir,movstr,str,options):=(
// help:Letterrot(C,B-A,"AB");
// help:Letterrot(C,B-A,0,5,"AB");
//help:Letterrot(C,B-A,AB",["Size=20"]);
//help:Letterrot(C,B-A,"t0n5","AB");
  regional(tmov,nmov,tmp,tmp1,tmp2,color);
  tmp1=indexof(movstr,"t");
  tmp2=indexof(movstr,"n");
  if(tmp1>0,
    if(tmp2>0,tmp=tmp2-1,tmp=length(movstr));
    tmov=parse(substring(movstr,tmp1,tmp));
  ,
    tmov=0;
  );
  if(tmp2>0,
    nmov=parse(substring(movstr,tmp2,length(movstr)));
  ,
    nmov=0;
  );
  Letterrot(pt,dir,tmov,nmov,str,options);
);
Letterrot(pt,dir,tmov,nmov,str,options):=(
  regional(tmp,color);
  tmp=Divoptions(options);
  color=tmp_(length(tmp)-2);
  Letter([pt,"c",str],append(options,"notex"));
  tmp=replace(str,"\","\\"); //17.10.18
  if(color!=KCOLOR, //180904
    Texcom("{");Com2nd("Setcolor("+color+")");//180722
  );
  Com2nd("Letterrot("+pt+","+dir+","+tmov+","+nmov+","+Dqq(tmp)+")");//180805
  if(color!=KCOLOR, //180904
    Texcom("}");//180722
  );
);
////%Letterrot end////

////%Exprrot start////
Exprrot(pt,dir,str):=Exprrot(pt,dir,0,0,str,[]);
Expr(pt,dir,str,options):=Expr([pt,dir,str],options);//181218
Exprrot(pt,dir,Arg1,Arg2):=(
  if(islist(Arg2),
    Exprrot(pt,dir,"t0n0",Arg1,Arg2);
  ,
    Exprrot(pt,dir,Arg1,Arg2,[]);
  );
);
Exprrot(pt,dir,movstr,str,options):=(
// help:Exprrot(C,B-A,"d");
// help:Exprrot(C,B-A,0,5,"d");
//help:Exprrot(C,B-A,"d",["Color=red"]);
//help:Exprrot(C,B-A,"t0n5","d");
  regional(tmov,nmov,tmp,tmp1,tmp2,color);
  tmp1=indexof(movstr,"t");
  tmp2=indexof(movstr,"n");
  if(tmp1>0,
    if(tmp2>0,tmp=tmp2-1,tmp=length(movstr));
    tmov=parse(substring(movstr,tmp1,tmp));
  ,
    tmov=0;
  );
  if(tmp2>0,
    nmov=parse(substring(movstr,tmp2,length(movstr)));
  ,
    nmov=0;
  );
  Exprrot(pt,dir,tmov,nmov,str,options);
);
Exprrot(pt,dir,tmov,nmov,str,options):=(
  regional(tmp,color);
  tmp=Divoptions(options);
  color=tmp_(length(tmp)-2);
  Expr([pt,"c",str],append(options,"notex"));
  tmp=replace(str,"\","\\"); //17.10.18
  if(color!=KCOLOR, //180904
    Texcom("{");Com2nd("Setcolor("+color+")");//180722
  );
  Com2nd("Exprrot("+pt+","+dir+","+tmov+","+nmov+","+Dqq(tmp)+")");//180802
  if(color!=KCOLOR, //180904
    Texcom("}");//180722
  );
);
////%Exprrot end////

////%Slider start////
Slider(ptstr,p1,p2):=Slider(ptstr,p1,p2,[]);
Slider(ptstr,p1,p2,options):=(//190120
//help:Slider("A-C-B",[-3,0],[3,0]);
//help:Slider("C",[-3,0],[3,0]);
//help:Slider(options=["Color=0.6*[0,0,1]","Size=2"]);
  regional(pA,pB,pC,seg,sname,Alpha,color,size,tmp,tmp1);
  color="Color=0.6*[0,0,1]"; //190120from
  size="size->2";
  forall(options,
    tmp=Toupper(substring(#,0,1));
    if(tmp=="C",
      color=#;
    );
    if(tmp=="S",
      tmp=Strsplit(#,"=");
      size="size->"+tmp_2;
    );
  ); //190120to
  tmp=Indexall(ptstr,"-");
  if(length(tmp)>0, //190209from
    pA=substring(ptstr,0,tmp_1-1);
    pC=substring(ptstr,tmp_1,tmp_2-1);
    pB=substring(ptstr,tmp_2,length(ptstr));
    seg=pA+pB;
    Alpha="ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    sname="";
    forall(1..(length(seg)),
      tmp=substring(seg,#-1,#);
      tmp1=indexof(Alpha,tmp);
      if(tmp1>0,
        sname=sname+unicode(text(tmp1+96),base->10);
      ,
        sname=sname+tmp;
      );
    ); 
    Putpoint(pA,p1);
    Putpoint(pB,p2);
    Listplot([parse(pA),parse(pB)],["Msg=n","notex",color,size]);
    Putonseg(pC,parse("sg"+pA+pB));
    PTEXCEPTION=concat(TEXCEPTION,[pA,pC,pB]);
  ,
    pA=""; pB=""; pC=ptstr;
    tmp=pC+"l"+pC+pC+"r";
    Listplot(tmp,[p1,p2],["Msg=n","notex",color,size]);
    Putonseg(pC,parse("sg"+tmp));
    PTEXCEPTION=concat(TEXCEPTION,[pC]);
  ); //190209to
);
////%Slider end////

////%Putpoint start////
Putpoint(name,Pt):=Putpoint(name,Pt,Pt);
Putpoint(name,Ptinit,Pt):=(
//help:Putpoint("A",[1,2],[1,A.y]);
  regional(ptstr);
  ptstr=apply(allpoints(),#.name);//16.10.06
  if(!contains(ptstr,name),
    createpoint(name,Pcrd([Ptinit_1,Ptinit_2]));
    ,
    ptstr=name+".xy="+Textformat(Pcrd(Pt),5);
    parse(ptstr);
  );
);
////%Putpoint end////

////%Putpoint start////
Putpoint(name,Pt):=Putpoint(name,Pt,Pt);
Putpoint(name,Ptinit,Pt):=(
//help:Putpoint("A",[1,2],[1,A.y]);
  regional(ptstr);
  ptstr=apply(allpoints(),#.name);//16.10.06
  if(!contains(ptstr,name),
    createpoint(name,Pcrd([Ptinit_1,Ptinit_2]));
    ,
    ptstr=name+".xy="+Textformat(Pcrd(Pt),5);
    parse(ptstr);
  );
);
////%Putpoint end////

////%Bezierpt start////
Bezierpt(t,ptlist,ctrlist):=(
  regional(flg3,p0,p1,p2,p3,p4,p5,p6,p7,p8,p9);
  p0=ptlist_1;
  p3=ptlist_2;
  p1=ctrlist_1;
  if(length(ctrlist)==1,
    p2=p3;
    flg3=0;
  ,
    p2=ctrlist_2;
    flg3=1;
  );
  if(length(p0)<3,  // 15.02.08
    p0=Lcrd(p0);
    p3=Lcrd(p3);
    p1=Lcrd(p1);
    p2=Lcrd(p2);
  );
  p4=(1-t)*p0+t*p1;
  p5=(1-t)*p1+t*p2;
  p6=(1-t)*p2+t*p3;
  p7=(1-t)*p4+t*p5;
  p8=(1-t)*p5+t*p6;
  p9=(1-t)*p7+t*p8;
  if(flg3==0,p7,p9);
);
////%Bezierpt end////

////%Bezier start////
Bezier(ptctrlist):=BezierCurve(ptctrlist_3,ptctrlist_1,ptctrlist_2,[]);
Bezier(Arg1,Arg2):=( //190202from
  regional(nm,ptctrlist,options);
  if(islist(Arg1),
    ptctrlist=Arg1; options=Arg2;
    BezierCurve(ptctrlist_3,ptctrlist_1,ptctrlist_2,options);
  ,
    nm=Arg1; ptctrlist=Arg2;
    BezierCurve(nm,ptctrlist_1,ptctrlist_2,[]);
  );
); //190202to
Bezier(nm,ptlist,ctrlist):=BezierCurve(nm,ptlist,ctrlist,[]);
Bezier(nm,ptlist,ctrlist,options):=BezierCurve(nm,ptlist,ctrlist,options);
////%Bezier end////
////%BezierCurve start////
BezierCurve(nm,ptlist,ctrlist):=BezierCurve(nm,ptlist,ctrlist,[]);
BezierCurve(nm,ptlistorg,ctrlistorg,options):=(
//help:Bezier("1",[A,D],[B,C]);
//help:Bezier(options=["Num=10"]);
  regional(name,Ltype,Noflg,opstr,opcindy,Num,
    ptlist,ctrlist,tmp,tmp1,tmp2,ii,st,out,list,color);
  name="bz"+nm;
  tmp=Divoptions(options);
  Ltype=tmp_1;
  Noflg=tmp_2;
  color=tmp_(length(tmp)-2);
  opstr=tmp_(length(tmp)-1);
  opcindy=tmp_(length(tmp));
  Num=10;
  tmp1=tmp_5;
  forall(tmp1,     // 14.12.31
    if(substring(#,0,1)=="N",
      tmp2=indexof(#,"=");
      Num=parse(substring(#,tmp2,length(#)));
      opstr=opstr+","+Dq+#+Dq;
    );
  );
  ptlist=apply(ptlistorg,Lcrd(#)); // 16.08.16
  ctrlist=[];  // 14.12.31
  if(length(ctrlistorg)==length(ptlist)-1,
    forall(1..(length(ctrlistorg)),ii, //190202
      tmp1=apply(ctrlistorg_ii,Lcrd(#));  //190202
      if(Measuredepth(tmp1)==0,tmp=[tmp1],tmp=tmp1);
      ctrlist=append(ctrlist,tmp);
    );
  ,
    forall(1..(length(ptlist)-1),ii,
      tmp=ctrlistorg_((2*ii-1)..(2*ii));
      tmp=apply(tmp,Lcrd(#)); // 16.08.16
      ctrlist=append(ctrlist,tmp);
    );
  );
  if(!islist(Num),
    Num=apply(ctrlist,Num);
  );
  list=[];
  forall(1..(length(ptlist)-1),ii,
    tmp1=ptlist_(ii..(ii+1));
    tmp2=ctrlist_ii;
    if(ii==1,st=0,st=1);
    forall(st..Num_ii,
      tmp=Bezierpt(#/Num_ii,tmp1,tmp2);
      list=append(list,tmp);
    );
  );
  if(Noflg<3,
    println("generate Bezier "+name);
    out=apply(list,Pcrd(#));
    tmp=name+"="+Textformat(out,5);
    parse(tmp);
    tmp1=Textformat(ptlist,5); //no ketjs on
    tmp1=RSform(tmp1,2); //17.12.23
    tmp2=Textformat(ctrlist,5);
    tmp2=RSform(tmp2,3); //17.12.23
    GLIST=append(GLIST,name+"=Bezier("+tmp1+","+tmp2+opstr+")"); //no ketjs off
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
  BezierCtrL=ctrlist; //181001
  list;
);
////%BezierCurve end////

////%Readcsvsla start////
Readcsvsla(fname):=Readplotdigdata(fname,[]);
Readcsvsla(fname,options):=Readplotdigdata(fname,options);
Readplotdigdata(fname):=Readplotdigdata(fname,[]);
Readplotdigdata(fname,options):=(
  regional(fsc,mv,cmdall,dataL,nd,npt,ptdata,ii,tmp,tmp1,tmp2,tmp3);
  tmp=Divoptions(options);
  tmp1=tmp_6;
  sc=1;//10;
  mv=[0,0];//[5,5];
  forall(tmp1,
    if(!islist(#),sc=#,mv=#);
  );
  if(indexof(fname,".")>0,
    tmp=load(fname);
  ,
    tmp=load(fname+".txt");
  );
  cmdall=tokenize(tmp,"//");
  dataL=[];
  forall(2..length(cmdall),ii,
    tmp1=parse("["+cmdall_ii+"]");
    dataL=append(dataL,tmp1);
  );
  if(length(dataL_(length(dataL)))<2,
    dataL=dataL_(1..(length(dataL)-1));
  );
  nd=length(dataL_1)/2;
  npt=length(dataL);
  ptdata=[];
  forall(1..nd,ii,
    tmp3=[];
    forall(1..npt,
      tmp1=dataL_#_(2*ii-1);
      tmp2=dataL_#_(2*ii);
      if(isreal(tmp1),
        tmp3=append(tmp3,[tmp1,tmp2]);
      );
    );
    ptdata=append(ptdata,tmp3);
  );
  tmp1=[];
  forall(ptdata,
    tmp=#/sc;
    tmp=Translatedata("1",[tmp],-mv,["nodata"]);
    tmp1=append(tmp1,tmp);
  );
  ptdata=tmp1;
  ptdata;
);
////%Readcsvsla end////

////%Putbezierdata start////
Putbezierdata(name,ptL):=Putbezierdata(name,ptL,[]);
Putbezierdata(name,ptL,options):=(
  regional(psize,Deg,tmp,tmp1,tmp2,p1,p2,pts,ctrs);
  tmp=Divoptions(options);
  psize=3;
  Deg=3;
  tmp1=tmp_5;
  forall(tmp1,
    if(substring(#,0,1)=="D",
      tmp=indexof(#,"=");
      Deg=parse(substring(#,tmp,length(#)));
    );
    if(substring(#,0,1)=="S",
      tmp=indexof(#,"=");
      psize=parse(substring(#,tmp,length(#)));
    );
  );
  pts=[];
  ctrs=[];
  forall(1..length(ptL),
    p2=ptL_#; // 16.08.16
    if(ispoint(p2),
      tmp1=text(p2);
    ,
      tmp1=name+text(#);
      Putpoint(tmp1,p2,Lcrd(parse(tmp1))); // 16.08.16
    );
    inspect(parse(tmp1),"ptsize",psize);
    pts=append(pts,parse(tmp1));
    inspect(parse(tmp1),"color",4);
    if(#>1,
      p1=Lcrd(ptL_(#-1)); // 16.08.16
      p2=Lcrd(ptL_#); // 16.08.16
      if(Deg==3,
        tmp=(2*p1+p2)/3;
        tmp1=name+"p"+text(#-1);
        Putpoint(tmp1,tmp,Lcrd(parse(tmp1))); // 16.08.16
        inspect(parse(tmp1),"labeled",false);  //15.01.22
        Letter([parse(tmp1),"ne",tmp1],["notex"]);  //15.01.22
        inspect(parse(tmp1),"ptsize",psize);
        inspect(parse(tmp1),"color",3);
        tmp=(p1+2*p2)/3;
        tmp2=name+"q"+text(#-1);
        Putpoint(tmp2,tmp,Lcrd(parse(tmp2))); // 16.08.16
        inspect(parse(tmp2),"labeled",false);  //15.01.22
        Letter([parse(tmp2),"ne",tmp2],["notex"]);  //15.01.22
        inspect(parse(tmp2),"ptsize",psize);
        inspect(parse(tmp2),"color",3);
        ctrs=append(ctrs,[parse(tmp1),parse(tmp2)]);
      ,
        tmp=(p1+p2)/2;
        tmp1=name+"p"+text(#-1);
        Putpoint(tmp1,tmp,Lcrd(parse(tmp1))); // 16.08.16
        inspect(parse(tmp1),"labeled",false);  //15.01.22
        Letter([parse(tmp1),"ne",tmp1],["notex"]);  //15.01.22
        inspect(parse(tmp1),"ptsize",psize);
        inspect(parse(tmp1),"color",3);
        ctrs=append(ctrs,[parse(tmp1)]);
      );
    );
  );
  [pts,ctrs,name];
);
////%Putbezierdata end////

////%Bezierstart start////
Bezierstart(n):=( // 2016.02.26
  BezierNumber=n;
);
////%Bezierstart end////

////%Mkbezierptcrv start////
Mkbezierptcrv(ptdata):=Mkbezierptcrv(ptdata,[]);
Mkbezierptcrv(ptdata,options):=(
 //help:Mkbezierptcrv([A,B,C,D]);
 //help:Mkbezierptcrv([[A,B],[C,D]]);
 //help:Mkbezierptcrv(options=["Num=10"]);
 //  global BezierNumber
  regional(ptlist,Out,tmp,tmp1,tmp2);
  if(isstring(ptdata),
    ptlist=Readcsvsla(ptdata,options);
  ,
    ptlist=ptdata;
  );
  if(Measuredepth(ptlist)==1,ptlist=[ptlist]);
  Out=[];
  forall(1..length(ptlist),
    tmp=floor((BezierNumber-1)/26);// 15.02.23
    if(tmp==0,tmp="",tmp=text(tmp));
    tmp2=mod(BezierNumber,26);
    if(tmp2==0,tmp2=26);
    tmp1=unicode(text(96+tmp2),base->10)+tmp;// 15.03.11
    tmp2=Putbezierdata(tmp1,ptlist_#,options);
    Bezier(tmp2,options);
    BezierNumber=BezierNumber+1;
    Out=append(Out,tmp2_(1..2));
  );
  Out;
);
////%Mkbezierptcrv end////

////%Mkbeziercrv start////
Mkbeziercrv(nm,ptctrL):=Mkbeziercrv(nm,ptctrL,[]);
Mkbeziercrv(nm,ptctrL,options):=(
 //help:Mkbeziercrv("1",[[A,B,C,D],[[P,Q],[R,S],T]]);
  regional(ptctrLL,name,ptlist,ctrlist,tmp,tmp1,tmp2);
  if(Measuredepth(ptctrL)==2,ptctrLL=[ptctrL],ptctrLL=ptctrL);
  forall(1..length(ptctrLL),
    name=nm+text(#);
    ptlist=ptctrLL_#_1;
    ctrlist=ptctrLL_#_2;
    Bezier(nm,ptlist,ctrlist,options); // 17.01.06
  );  
);
////%Mkbeziercrv end////

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
    tmp1=replace(tmp1,name,head+text(#));
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
Readbezier(file,optionorg):=(
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
  ReadOutData(file);
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

////%Ospline start////
Ospline(nm,ptlist):=Ospline(nm,ptlist,[]);
Ospline(nm,ptlist,options):=(
//help:Ospline("1",ptlist,[options]);
//help:Ospline(options=["Num=10"]);
  regional(tmp,tmp1,tmp2,list,ptL,ctrL,name,closed,flg,
      p0,p1,p2,p3,pQ,pR,cc,p01,p02,p11,p12,p21,p22,p31,p32);
  name="o"+nm;
  if(isstring(ptlist),list=parse(ptlist),list=ptlist);
  if(|list_1-list_(length(list))|<10^(-6),closed=1,closed=0);
//  list=apply(list,LLcrd(#));
  ctrL=[];
  forall(1..(length(list)-1),
    flg=0;
    p1=Lcrd(list_#);  // 16.08.16
    p2=Lcrd(list_(#+1));  // 16.08.16
    if(#==1 % #==length(list)-1,
      flg=1;
      if(closed==0,
        pQ=(p1+2*p2)/3; // 15.09.21  // 16.08.16
        pR=(2*p1+p2)/3;  // 16.08.16
        ctrL=append(ctrL,[pQ,pR]);
        flg=2;
      ,
        if(#==1,
          p0=Lcrd(list_(length(list)-1));  // 16.08.16
          p3=Lcrd(list_(#+2));  // 16.08.16
       ,
          p0=Lcrd(list_(#-1));  // 16.08.16
          p3=Lcrd(list_2);  // 16.08.16
        );
      );
    );
    if(flg<=1,
      if(flg==0,
        p0=Lcrd(list_(#-1));  // 16.08.16
        p3=Lcrd(list_(#+2));  // 16.08.16
      );
      tmp=1+sqrt((1+Dotprod(p2-p0,p3-p1)/|p2-p0|/|p3-p1|)/2);
      cc=4*|p2-p1|/3/(|p2-p0|+|p3-p1|)/tmp;
      pQ=p1+cc*(p2-p0); // 15.09.21  // 16.08.16
      pR=p2+cc*(p1-p3);  // 16.08.16
      ctrL=append(ctrL,[pQ,pR]);
    );
  );
//  list=apply(list,LLcrd(#));  // 16.08.16
//  ctrL=apply(ctrL,LLcrd(#));
  if(closed==0,  // 15.09.21
    p1=ctrL_2_1;
    p2=Lcrd(list_2);  // 16.08.16
    pQ=p2+(p2-p1);
    ctrL_1=[pQ];
    tmp=length(ctrL);
    tmp1=ctrL_(tmp-1);
    p1=ctrL_(tmp-1)_2;
    p2=Lcrd(list_(tmp));  // 16.08.16
    pQ=p2+(p2-p1);
    ctrL_tmp=[pQ];
  );
  Bezier("o"+nm,list,ctrL,options); 
);
////%Ospline end////

////%CRspline start////
CRspline(nm,ptL):=CRspline(nm,ptL,[]);
CRspline(nm,ptL,options):=( //180822
  // Catmull-Rom spline
//help:CRspline("1",[A,B,C,A]);
//help:CRspline(options=["Num=10"]);
  regional(name,Eps,ptlist,cc,nv,pm,p0,p1,p2,p3,
     ctrlist,cflg,qq,rr,tmp);
  name="CR"+nm;
  ptlist=apply(ptL,Lcrd(#));
  Eps=10^(-5);
  cflg=0;
  if(dist(ptlist_1,ptlist_(length(ptlist)))<Eps,
    cflg=1;
  );
  cc=1/6;
  ctrlist=[];
  forall(1..(length(ptlist)-1),
    p1=ptlist_#;
    p2=ptlist_(#+1);
    tmp=p2-p1;
    nv=[-tmp_2,tmp_1];
    pm=(p1+p2)/2;
    if(#==1,
     p3=ptlist_(#+2);
     if(cflg==0,
        p0=Reflectpoint(p3,[pm,pm+nv]);
      ,
        p0=ptlist_(length(ptlist)-1);
      );
    ,
      p0=ptlist_(#-1);
      if(#==length(ptlist)-1,
        if(cflg==0,
          p3=Reflectpoint(p0,[pm,pm+nv]);
        ,
          p3=ptlist_2;
        );
      ,
        p3=ptlist_(#+2);
      );
    );
    qq=p1+cc*(p2-p0);
    rr=p2+cc*(p1-p3);
    ctrlist=append(ctrlist,[qq,rr]);
  );
  Bezier(name,ptlist,ctrlist,options);
);
////%CRspline end////

////%Beziersmooth start////
Beziersmooth(nm,ptL):=Bzspline(nm,ptL,[]);
//help:Beziersmooth("1",[A,B,C,A]);
Beziersmooth(nm,ptL,options):=Bzspline(nm,ptL,options);
Bzspline(nm,ptL):=Bzspline(nm,ptL,[]);
Bzspline(nm,ptLorg,options):=(
  // smooth bezier
  regional(name,Eps,ptL,pt,pt1,pt2,pt3,npt,lstr,
    tmp,tmp1,tmp2,cflg,ctrlist);
  name="bzsp"+nm;
  Eps=10^(-3);
  ptL=apply(ptLorg,Lcrd(#)); // 16.08.16
  if(|ptL_1-ptL_(length(ptL))|<Eps,cflg=1,cflg=0);
  forall(2..length(ptL),
    pt=ptL_#;
    pt1=ptL_(#-1);
    tmp1="C"+text(#-1)+"q";// 16.10.07
    Putpoint(tmp1,(pt1+4*pt)/5,Lcrd(parse(tmp1))); // 16.08.16
  );
  forall(2..(length(ptL)-1),
    if(#<length(ptL) % cflg==1,
      lstr="c"+text(#);
      pt=ptLorg_#; // 16.08.16
      pt1=parse("C"+text(#-1)+"q");
      create([lstr],"Join",[pt1,pt]);
      tmp2="C"+text(#)+"p";
      tmp=append((2*pt.xy-pt1.xy),1);
      create([tmp2],"PointOnLine",[parse(lstr),tmp]);
    );
  );
  if(cflg==0,
    pt=ptL_1;
    pt1=ptL_2;
    tmp1="C1p";
    Putpoint(tmp1,(4*pt+pt1)/5,Lcrd(parse(tmp1))); // 16.08.16
  );
  if(cflg==1,
    lstr="c1";
    pt=ptLorg_1; // 16.08.16
    pt1=parse("C"+text(length(ptL)-1)+"q");
    create([lstr],"Join",[pt1,pt]);
    tmp1="C1p";
    tmp=append((2*pt.xy-pt1.xy),1);
    create([tmp1],"PointOnLine",[parse(lstr),tmp]);
  );
  ctrlist=[];
  forall(1..(length(ptL)-1),
    if(#>1 % cflg==1,
      tmp1="c"+text(#);
      inspect(parse(tmp1),"alpha",0.3);
    );
    tmp1="C"+text(#)+"p";
    tmp2="C"+text(#)+"q";
    inspect(parse(tmp1),"ptsize",3);
    inspect(parse(tmp1),"color",3);
    inspect(parse(tmp2),"ptsize",3);
    inspect(parse(tmp2),"color",3);
    tmp=[parse(tmp1),parse(tmp2)];
    ctrlist=append(ctrlist,tmp);
  );
  Bezier(nm,ptL,ctrlist,options);
  [ptL,ctrlist];
);
////%Beziersmooth end////

////%Beziersym start////
Beziersym(nm,ptL):=Bzsspline(nm,ptL,[]);
Beziersym(nm,ptL,options):=Bzsspline(nm,ptL,options);
Bzsspline(nm,ptL):=Bzsspline(nm,ptL,[]);
Bzsspline(nm,ptLorg,options):=(
  // smooth bezier with symmetric control points
  regional(name,Eps,ptL,pt,pt1,pt2,pt3,npt,lstr,
    tmp,tmp1,tmp2,cflg,ctrlist);
  name="bzssp"+nm;
  Eps=10^(-3);
  ptL=apply(ptLorg,Lcrd(#)); // 16.08.16
  if(|ptL_1-ptL_(length(ptL))|<Eps,cflg=1,cflg=0);
  forall(2..length(ptL),
    pt=ptL_#;
    pt1=ptL_(#-1);
    tmp1="C"+text(#-1)+"q";
    Putpoint(tmp1,(pt1+4*pt)/5,Lcrd(parse(tmp1)));
  );
  forall(2..(length(ptL)-1),
    if(#<length(ptL) % cflg==1,
      pt=ptL_#;
      pt1=parse("C"+text(#-1)+"q");
      tmp2="C"+text(#)+"p=2*pt-pt1";
      parse(tmp2);
    );
  );
  if(cflg==0,
    pt=ptL_1;
    pt1=ptL_2;
    Putpoint("C1p",(4*pt+pt1)/5,Lcrd(C1p)); // 16.08.16
    inspect(C1p,"ptsize",3);
    inspect(C1p,"color",3);
  );
  if(cflg==1,
    pt=ptL_1;
    pt1=Lcrd(parse("C"+text(length(ptL)-1)+"q")); // 16.08.16   
    tmp1="Putpoint("+Dq+"C1p"+Dq+",2*pt-pt1)"; // 16.08.16
    parse(tmp1);
  );
  ctrlist=[];
  forall(1..(length(ptL)-1),
    tmp1="C"+text(#)+"p";
    tmp2="C"+text(#)+"q";
    inspect(parse(tmp2),"ptsize",3);
    inspect(parse(tmp2),"color",3);
    tmp=[parse(tmp1),parse(tmp2)];
    ctrlist=append(ctrlist,tmp);
  );
  Bezier(nm,ptL,ctrlist,options);
  [ptL,ctrlist];
);
////%Beziersym end////

////%Listbspline2bz start////
Listbspline2bz(listorg):=(
  regional(Eps,list,pcl,ptl,ctrl,k);
  Eps=10^(-3);
  list=apply(listorg,Lcrd(#)); // 16.08.16
  k=length(list);
  if(|list_1-list_k|>Eps,
    pcl=list;
    pcl_1=2*list_1-list_2;
    pcl_k=2*list_k-list_(k-1);
  ,
    pcl=concat(list,[list_2]);
  );
  ctrl=apply(2..(length(pcl)-1),[pcl_#]);
  ptl=apply(1..(length(pcl)-1),(pcl_#+pcl_(#+1))/2);
  [ptl,ctrl];
);
////%Listbspline2bz end////

////%Bspline start////
Bspline(nm,ctrL):=Bspline(nm,ctrL,[]);
Bspline(nm,ctrL,options):=(
//help:Bspline("",[A,B,C]);
//help:Bspline(options=["Num=10"]);
  regional(list,tmp);
  list=Listbspline2bz(ctrL);
  tmp=BezierCurve("b"+nm,list_1,list_2,options);
  tmp;
);
////%Bspline end////

////%MeetCurve start////
MeetCurve(Crv,Xorg,Yorg):=(
  regional(Cv,tmp,tmp1,tmp2,X0,Y0,x1,x2,y1,y2,Ylist,Ban,Tate);
  if(isstring(Crv),Cv=parse(Crv),Cv=Crv);
  if(Measuredepth(Cv)==2,Cv=Cv_1);
  Cv=apply(Cv,LLcrd(#));  // 14.12.18
  while(length(Cv)==1,
    Cv=Cv_1;
  );
  Cv=apply(Cv,Lcrd(#));
  tmp1=min(apply(Cv,#_1));
  tmp2=max(apply(Cv,#_1));
  if(isstring(Xorg),X0=parse(Xorg),X0=Xorg);
  if(isstring(Yorg),Y0=parse(Yorg),Y0=Yorg);
  if(X0<tmp1,
    X0=tmp1;
  ,
    if(X0>tmp2,
      X0=tmp2;
    );
  );
  tmp1=select(
    1..(length(Cv)-1),Cv_#_1<=X0 & X0<=Cv_(#+1)_1);
  tmp2=select(
    1..(length(Cv)-1),Cv_#_1>=X0 & X0>=Cv_(#+1)_1);
  tmp2=remove(tmp2,common(tmp2,tmp1));
  Ban=concat(tmp1,tmp2);
  Tate=select(Ban,
    abs(Cv_#_1-Cv_(#+1)_1)<=
       10^(-2)*abs(Cv_#_2-Cv_(#+1)_2)
  );
  Ban=remove(Ban,Tate);
  Ylist=[];
  forall(Ban,
    tmp=Cv_#;
    x1=tmp_1; y1=tmp_2;
    tmp=Cv_(#+1);
    x2=tmp_1; y2=tmp_2;
    tmp=((x2-X0)*y1+(X0-x1)*y2)/(x2-x1);
    Ylist=append(Ylist,tmp);
  );
  forall(Tate,
    tmp=Cv_#;
    x1=tmp_1; y1=tmp_2;
    tmp=Cv_(#+1);
    x2=tmp_1; y2=tmp_2;
    tmp1=min([y1,y2]);
    tmp2=max([y1,y2]);
    if(Y0<tmp1,
      tmp=tmp1;
    ,
      if(Y0>tmp2,
        tmp=tmp2;
      ,
        tmp=Y0;
      );
    );
    Ylist=append(Ylist,tmp);
  );
  tmp=sort(Ylist,abs(#_1-Y0));
  [X0,tmp_1];
);
////%MeetCurve end////

////%Putonline start////
Putonline(name,linestr):=Putonline(name,linestr,[]); //190216from
Putonline(name,Arg1,Arg2):=(
  regional(line,options);
  if(isstring(Arg1),
    line=parse(Arg1); options=Arg2;
    Putonseg(name,LLcrd(line_1),LLcrd(line_2),options);
  ,
    Putonline(name,LLcrd(Arg1),LLcrd(Arg2),[]);
  );
);
Putonline(name,p1,p2,options):=(
//help:Putonline("C","lnAB");
//help:Putonline("C",pA,pB);
  regional(line);
  line=Lineplot("",[p1,p2],["nodata"]);
//  tmp1=name+"1";
//  tmp2=name+"2";
//  Putpoint(tmp1,line_1); // 190216 
//  Putpoint(tmp22,line_2); // 190216
  Putonseg(name,line_1,line_2,options);
); //190216to
////%Putonline end////

////%Putonseg start////
Putonseg(name,sgstr):=(
  regional(seg,p1,p2);
  if(isstring(sgstr),seg=parse(sgstr),seg=sgstr);
  Putonseg(name,LLcrd(seg_1),LLcrd(seg_2));
);
Putonseg(name,p1,p2):=Putonseg(name,p1,p2,[]);
Putonseg(name,p1org,p2org,options):=(
//help:Putonseg("C","sgAB");
//help:Putonseg("C",pA,pB);
  regional(Eps,par,p1,p2,dx,dy,p,tmp,tmp1,tmp2);
  Eps=10^(-5);
  par=0.5;
  tmp=Divoptions(options);
  if(length(tmp_6)>0,
    par=tmp_6_1;
  );
  p1=Lcrd(p1org);//16.10.11from
  p2=Lcrd(p2org);
  Putpoint(name,(p1+p2)/2,parse(name+".xy")); //190216 //no ketjs
  p1=Pcrd(p1); p2=Pcrd(p2); //190120
  dx=p2_1-p1_1;
  dy=p2_2-p1_2;
  p=parse(name+".xy");
  if(abs(dx)>abs(dy), //190120from
    if(p1_1>p2_1,tmp=p1;p1=p2;p2=tmp);
    if(p_1<p1_1,parse(name+".xy="+Textformat(p1,5));p=p1);
    if(p_1>p2_1,parse(name+".xy="+Textformat(p2,5));p=p2);
    tmp=(p2_2-p1_2)/(p2_1-p1_1)*(p_1-p1_1)+p1_2;
    parse(name+".y="+tmp);
  ,
    if(p1_2>p2_2,tmp=p1;p1=p2;p2=tmp);
    if(p_2<p1_2,parse(name+".xy="+Textformat(p1,5));p=p1);
    if(p_2>p2_2,parse(name+".xy="+Textformat(p2,5));p=p2);
    tmp=(p2_1-p1_1)/(p2_2-p1_2)*(p_2-p1_2)+p1_1;
    parse(name+".x="+tmp);
  ); //190120to
);
////%Putonseg end////

////%Putoncurve start////
Putoncurve(pn,crv):=putoncurve(pn,crv,[]);
Putoncurve(pn,crvorg,options):=(
//help:Putoncurve("A","gr1");
  regional(eps,crv,close,nn,p1,p2,tmp,tmp1);
  eps=10^(-3);
  crv=crvorg;
  if(isstring(crv),crv=parse(crv));
  close=false;
  if(|crv_1-crv_(length(crv))|<eps,
    close=true;
  );
  tmp=parse(pn); //no ketjs on
  if(!ispoint(tmp),
    Putpoint(pn,[0,0],parse(pn+".xy"));
  ); //no ketjs off
  tmp=Paramoncurve(parse(pn),crvorg);
  nn=floor(tmp);
  p1=crv_nn;
  if(nn<length(crv),
    p2=crv_(nn+1);
    Putonseg(pn,p1,p2);
  ,
    if(close,
      p2=crv_1;
      Putonseg(pn,p1,p2);
    ,
      parse(pn+".xy="+Textformat(Ptend(crv),5));
    );
  );
);
////%Putoncurve end////

////%CrossPoint start////
CrossPoint(name,Crv1,Crv2,range):=(
  regional(Mx1,Mx2,Mx3,tmp,Crs1,Crs2,Crs3,Crs4,df1,df2);
  Mx1=range_1; Mx2=range_2;
  repeat(15,
    Mx3=(Mx1+Mx2)/2;
    Crs1=MeetCurve(Crv1,Mx1,0);
    Crs2=MeetCurve(Crv2,Mx1,0);
    Crs3=MeetCurve(Crv1,Mx3,0);
    Crs4=MeetCurve(Crv2,Mx3,0);
    df1=Crs1_2-Crs2_2;
    df2=Crs3_2-Crs4_2;
    if((df1>0 & df2>0) % (df1<0 & df2<0),
      Mx1=Mx3;
    ,
      Mx2=Mx3;
    );
  );
  Putpoint(name,Crs1);
);
////%CrossPoint end////

////%Periodfun start////
Periodfun(defL,rep):=Periodfun(defL,rep,[]);
Periodfun(defL,reporg,optionorg):=(  // 16.11.24
//help:Periodfun(["0",[-1,0],1(Num=),"1",[0,1],1(Num)],2(repeat count),options);
//help:Periodfun(repeat count=n or [repeatL,repeatR]);
//help:Periodfun(options=["Con(nect)=da,Color=red"]);//180725
//help:Periodfun(defL=[function string, range, devision number,...]);
  regional(nn,fun,range,num,options,nr,maxfun,rep,np,
    tmp,tmp1,tmp2,eqL,connect,minx,maxx,pdata,Eps,prept);
  rep=reporg;
  if(length(rep)==1,rep=[rep,rep]);//180724
  options=optionorg;
//  tmp=Divoptions(options);
  eqL=options;
  connect=["da"];//180725
  forall(eqL,
    tmp=indexof(#,"=");//180725from
    tmp=[substring(#,0,tmp-1),substring(#,tmp,length(#))];
    if(Toupper(substring(tmp_1,0,3))=="CON",
      tmp1=Toupper(Op(1,tmp_2));
      if(tmp1=="N",
        connect=[];
      ,
        if(tmp1!="Y",
          connect=tokenize(tmp_2,",");
        );
      );//180725to
      options=remove(options,[#]);
    );
  );
  minx=10000;
  maxx=-10000;
  mxfun="";
  pdata=[];
  forall(1..(length(defL)/3),nn,
    fun=defL_(3*nn-2);
    range=defL_(3*nn-1);
    tmp1=if(isstring(range_1),parse(range_1),range_1); //17.06.11[2lines]
    tmp2=if(isstring(range_2),parse(range_2),range_2);
    minx=min(minx,tmp1);
    maxx=max(maxx,tmp2);
    num=defL_(3*nn);
    options=append(options,"Num="+text(num));
    Plotdata("pe"+text(nn),fun,
      "x="+Textformat([tmp1,tmp2],5),options);
    pdata=append(pdata,"grpe"+text(nn));
    tmp1=range_1; //17.06.11[4lines]
    if(isstring(tmp1),tmp1=replace(tmp1,"pi","%pi"),tmp1=format(tmp1,5));
    tmp2=range_2;
    if(isstring(tmp2),tmp2=replace(tmp2,"pi","%pi"),tmp2=format(tmp2,5));
    mxfun=mxfun+"elseif ("+tmp1+
      "<=x and x<"+tmp2+") then "+fun+" ";
  );
  per=maxx-minx;
  tmp1=[];
  forall(1..(rep_1),nr, //180724from
    forall(reverse(1..(length(pdata))),np,
      Translatedata("m"+np+text(nr),pdata_np,[-per*nr,0],options);
      tmp1=concat(["trm"+np+text(nr)],tmp1);
    );
  );
  tmp2=[];
  forall(1..(rep_2),nr,
    forall(1..(length(pdata)),np,
      Translatedata("p"+np+text(nr),pdata_np,[per*nr,0],options);
      tmp2=concat(tmp2,["trp"+np+text(nr)]);
    );
  );//180724to
  pdata=concat(tmp1,pdata);
  pdata=concat(pdata,tmp2);
  if(length(connect)>0, //180725
    connect=append(connect,"Msg=n"); //180725
    Eps=10^(-5);
    pdata=sort(pdata,[parse(#)_1_1]);
    prept=parse(pdata_1)_1;
    forall(1..(length(pdata)),
      tmp=parse(pdata_#);
      tmp1=tmp_1;
      tmp2=tmp_(length(tmp));
      if(|prept-tmp1|>Eps,
        Listplot("con"+text(#),[prept,tmp1],concat([],connect));//180725
      );
      prept=tmp_(length(tmp));
    );
  );
  mxfun=substring(mxfun,4,length(mxfun)-1);
  [mxfun,per];
);
////%Periodfun end////

////%Fourierseries start////
Fourierseries(nm,coeff,per,nterm):=
   Fourierseries(nm,coeff,per,nterm,[]);  // 16.11.24
Fourierseries(nm,coeff,per,nterm,options):=(
//help:Fourierseries("1",[c0,cn,sn],period,numterm,options);
  regional(c0,cn,sn,fs,tmp,tmp1,tmp2);
  c0=coeff_1;
  if(!isstring(c0),c0=format(c0,5));
  c0=replace(c0,"%pi","pi");
  cn=coeff_2;
  if(!isstring(cn),cn=format(cn,5));
  cn=replace(cn,"%pi","pi");
  sn=coeff_3;
  if(!isstring(sn),sn=format(sn,5));
  sn=replace(sn,"%pi","pi");
  fs=c0;
  forall(1..nterm,
    tmp=parse(Assign(cn,["n",#]));
    tmp1=Assign("("+format(tmp,5)+")*cos(n*2*pi/per*x)",
      ["n",#,"per",per]);
    tmp=parse(Assign(sn,["n",#]));
    tmp2=Assign("("+format(tmp,5)+")*sin(n*2*pi/per*x)",
      ["n",#,"per",per]);
    fs=fs+"+"+tmp1+"+"+tmp2;
  );
  Plotdata("four"+nm,fs,"x",options);
);
////%Fourierseries end////

////%Tabledatalight start////
Tabledatalight(nm,xLst,yLst,rmvL):=Tabledatalight(nm,xLst,yLst,rmvL,[]);
Tabledatalight(nm,xLst,yLst,rmvL,optionorg):=(
//help:Tabledatalight("",xLst,yLst,rmvL,[2,"Rng=y"]);
  regional(options,rng,name,upleft,ul,flg,tick,eqL,reL,n,m,xsize,ysize,
    rlist,clist,Tb,tmp,tmp1,tmp2,tmp3,Eps);
//  name="tb"+nm;
  name="tb";
  options=optionorg;
  tmp=Divoptions(options);
  eqL=tmp_5; //16.12.16from
  reL=tmp_6;
  rng="Y";
  forall(eqL,
    tmp=indexof(#,"=");
    tmp1=Toupper(substring(#,0,1)); //181111
    tmp2=Toupper(substring(#,tmp,tmp+1));
    if(tmp1=="R",
      rng=tmp2;
      options=remove(options,[#]);
    );
  );//16.12.16until
  tick=1;
  flg=0;
  forall(reL,
    if(flg==0,
      tick=#;
      flg=flg+1;
    ,
      upleft=tmp_6_1;
    );
  );
  tmp=sum(yLst);
  upleft=[0,tmp];
  TableOptions=options; // 16.11.28
  println("Tabledatalight "+name+" generated");
  ul=upleft/10;
  m=length(xLst);
  n=length(yLst);
  xsize=sum(xLst);
  ysize=sum(yLst);
  clist=[ul];
  rlist=[ul];
  forall(1..m,
    tmp1=clist_(#)_1+xLst_#/10;
    clist=append(clist,[tmp1,clist_1_2]);
  );
  forall(1..n,
    tmp1=rlist_(#)_2-yLst_#/10;
    rlist=append(rlist,[0,tmp1]);
  );
  Tb=[clist,rlist];
  tmp=name+"="+Tb;
  parse(tmp);
  forall(0..m,
    tmp1="c"+text(#)+"r0";
    tmp2="c"+text(#)+"r"+text(n);
    Tlistplot("c"+text(#)+"r0r"+text(n),[tmp1,tmp2],options);
    if(mod(#,tick)==0 % #==m,
      tmp=clist_(#+1);
      drawtext(clist_(#+1)-[0.04,-0.1],"c"+text(#));
    );
  );
  forall(0..n,
    tmp1="c0r"+text(#);
    tmp2="c"+text(m)+"r"+text(#);
    Tlistplot("r"+text(#)+"c0c"+text(m),[tmp1,tmp2],options);
    if(mod(#,tick)==0 % #==n,
      tmp=rlist_(#+1);
      drawtext(rlist_(#+1)-[0.4,0.1],"r"+text(#));
    );
  );
  Tsegrmv(rmvL,options);
  Addax(0);
  Eps=10^(-3);
  tmp1=clist_(length(clist));
  tmp2=rlist_1;
  tmp3=rlist_(length(rlist));
  if(rng=="Y", // 16.12.16
    Setwindow([0-Eps,tmp1_1+Eps],[tmp3_2-Eps,tmp2_2+Eps]);
  );
  Tb;
);
////%Tabledatalight end////

////%Tabledata start////
Tabledata(nm,n,m,xsize,ysize,rmvL):=
    Tabledata(nm,n,m,xsize,ysize,rmvL,[]);
Tabledata(nm,n,m,xsize,ysize,rmvL,options):=(
  regional(Tb,name,tmp,xLst,yLst);
  name="tb"+nm;
  xLst=apply(1..n,xsize/n);
  yLst=apply(1..m,ysize/m);
  Tabledata(nm,xLst,yLst,rmvL,options)
);
Tabledata(nm,xLst,yLst,rmvL):=Tabledata(nm,xLst,yLst,rmvL,[]);
Tabledata(nm,xLst,yLst,rmvL,optionorg):=(
//help:Tabledata("",xLst,yLst,rmvL,[2,"Rng=y"]);
  regional(name,options,eqL,reL,rng,upleft,ul,flg,tick,n,m,xsize,ysize,
    rlist,clist,Tb,tmp,tmp1,tmp2,tmp3,Eps);
//  name="tb"+nm;
  name="tb";
  tmp=sum(yLst);
  upleft=[0,tmp];
  options=optionorg;
  tmp=Divoptions(options);
  eqL=tmp_5; //16.12.16from
  reL=tmp_6;
  rng="Y";
  forall(eqL,
    tmp=indexof(#,"=");
    tmp1=Toupper(substring(#,0,1)); //181111
    tmp2=Toupper(substring(#,tmp,tmp+1));
    if(tmp1=="R",
      rng=tmp2;
      options=remove(options,[#]);
    );
  );//16.12.16until
  tick=1;
  flg=0;
  forall(reL,
    if(flg==0,
      tick=#;
      flg=flg+1;
    ,
      upleft=tmp_6_1;
    );
  );
  TableOptions=options; // 16.11.28
  println("Tabledata "+name+" generated");
  ul=upleft/10;
  m=length(xLst);
  n=length(yLst);
  xsize=sum(xLst);
  ysize=sum(yLst);
  clist=[ul];
  rlist=[ul];
  forall(1..m,
    tmp1=clist_(#)_1+xLst_#/10;
    clist=append(clist,[tmp1,clist_1_2]);
  );
  forall(1..n,
    tmp1=rlist_(#)_2-yLst_#/10;
    rlist=append(rlist,[0,tmp1]);
  );
  Tb=[clist,rlist];
  tmp=name+"="+Tb;
  parse(tmp);
  forall(0..m,
    tmp="C"+text(#);
    tmp1="c"+text(#)+"r0";
    if(#==0,
      Putpoint(tmp,Tgrid(tmp1));
    ,
      Putpoint(tmp,Tgrid(tmp1),[parse(tmp+".x"),C0.y]);
      clist_(#+1)=parse(tmp+".xy");
    );
    inspect(parse(tmp),"ptsize",3);
    inspect(parse(tmp),"labeled",false);
    if(mod(#,tick)==0 % #==m,
      tmp=clist_(#+1);
      drawtext(clist_(#+1)-[0.04,-0.1],"c"+text(#));
    );
  );
  forall(0..n,
    tmp="R"+text(#);
    tmp1="c0r"+text(#);
    if(#==0,
      Putpoint(tmp,Tgrid(tmp1));
    ,
      Putpoint(tmp,Tgrid(tmp1),[R0.x,parse(tmp+".y")]);
      rlist_(#+1)=parse(tmp+".xy"); //no ketjs
    );
    Putpoint(tmp,Tgrid(tmp1),[R0.x,parse(tmp+".y")]); 
    inspect(parse(tmp),"ptsize",3);
    inspect(parse(tmp),"labeled",false);
    if(mod(#,tick)==0 % #==n,
      tmp=rlist_(#+1);
      drawtext(rlist_(#+1)-[0.4,0.1],"r"+text(#));
    );
  );
  Tb=[clist,rlist];
  tmp=name+"="+Tb;
  parse(tmp);
  forall(0..m,
    tmp1="c"+text(#)+"r0";
    tmp2="c"+text(#)+"r"+text(n);
    Tlistplot("c"+text(#)+"r0r"+text(n),[tmp1,tmp2],options);
    if(#<m,
      tmp1=parse("C"+text(#));
      tmp2=parse("C"+text(#+1));
      tmp=(tmp1.xy+tmp2.xy)/2;
      drawtext(tmp+[-0.2,0.5],text((tmp2.x-tmp1.x)*10));
    );
  );
  forall(0..n,
    tmp1="c0r"+text(#);
    tmp2="c"+text(m)+"r"+text(#);
    Tlistplot("r"+text(#)+"c0c"+text(m),[tmp1,tmp2],options);
    if(#<n,
      tmp1=parse("R"+text(#));
      tmp2=parse("R"+text(#+1));
      tmp=(tmp1.xy+tmp2.xy)/2;
      drawtext(tmp-[1.2,0.1],text(abs(tmp1.y-tmp2.y)*10));
    );
  );
  Tsegrmv(rmvL,options);
  Addax(0);
  Eps=10^(-3);
  tmp1=clist_(length(clist));
  tmp2=rlist_1;
  tmp3=rlist_(length(rlist));  // 15.06.11
  if(rng=="Y", // 16.12.16
    Setwindow([0-Eps,tmp1_1+Eps],[tmp3_2-Eps,tmp2_2+Eps]);
  );
  Tb;
);
////%Tabledata end////

////%Tseginfo start////
Tseginfo(seg):=(
  regional(cr,tp,tpc,n1,n2,n3,tmp,tmp1,tmp2);
  if(substring(seg,0,2)=="sg",
    cr=substring(seg,2,length(seg));
  ,
    cr=seg;
  );
  tp=substring(cr,0,1);
  if(tp=="c",
    tpc="r";
  ,
    tpc="c";
  );
  tmp1=indexof(cr,tpc);
  tmp=substring(cr,tmp1,length(cr));
  tmp2=tmp1+indexof(tmp,tpc);
  n1=substring(cr,1,tmp1-1);
  n2=substring(cr,tmp1,tmp2-1);
  n3=substring(cr,tmp2,length(cr));
  [tp+n1,tpc,parse(n2),parse(n3)];
);
////%Tseginfo end////

////%Tsegrmv start////
Tsegrmv(rmvL):=Tsegrmv(rmvL,[]);
Tsegrmv(rmvL,options):=(
  regional(cr,gcL,flg,gc,hd,tail,tpc,m1,m2,n1,n2,tmp,tmp1,tmp2);
  forall(rmvL,cr,
    tmp1=Tseginfo(cr);
    hd=tmp1_1;
    tpc=tmp1_2;
    m1=tmp1_3;
    m2=tmp1_4;
    gcL=select(GCLIST,Tseginfo(#_1)_1==tmp1_1);
    flg=0;
    forall(gcL,
      if(flg==0,
        tmp=Tseginfo(#_1);
        n1=tmp_3;
        n2=tmp_4;
        if(m1>=n1 & m2<=n2,
          gc=#;
          flg=1;
        );
      );
    );
    if(flg==1,
      Changestyle([gc_1],["nodisp"]);
      tail="";
      if(indexof(hd,"r")>0,
        tail=hd; hd="";
      );
      if(n1<m1,
        tmp1=tpc+text(n1);
        tmp2=tpc+text(m1);
        tmp=hd+tail+tmp1+tmp2;
        Tlistplot(tmp,[hd+tmp1+tail,hd+tmp2+tail],options);
      );
      if(m2<n2,
        tmp1=tpc+text(m2);
        tmp2=tpc+text(n2);
        tmp=hd+tail+tmp1+tmp2;
        Tlistplot(tmp,[hd+tmp1+tail,hd+tmp2+tail],options);
      );
    );
  );
);
////%Tsegrmv end////

////%Tgrid start////
Tgrid(ptstr):=(
//help:Tgrid("c2r5");
  regional(tmp,tmp1,tmp2);
  tmp=parse(ptstr);
  if(islist(tmp),
    tmp;
  ,
    tmp=indexof(ptstr,"r");
    tmp1=substring(ptstr,1,tmp-1);
    tmp1=parse(tmp1);
    tmp2=substring(ptstr,tmp,length(ptstr));
    tmp2=parse(tmp2);
    [tb_1_(tmp1+1)_1,tb_2_(tmp2+1)_2];
  );
);
////%Tgrid end////

////%Tlistplot start////
Tlistplot(ptL):=Tlistplot(ptL,[]);
Tlistplot(Ag1,Ag2):=(
  regional(nm,ptL,options);
  if(isstring(Ag1),
    nm=Ag1;
    ptL=Ag2;
    options=[];
  ,
    ptL=Ag1;
    options=Ag2;
    nm=ptL_1+ptL_2;
  );
  Tlistplot(nm,ptL,options);
);
Tlistplot(nm,ptL,options):=(
//help:Tlistplot(["c0r0","c0r4"]);
//help:Tlistplot("1",["c0r0","c0r4"]);
//help:Tlistplot([options2="Msg=y"]);
  regional(tmp,tmp1);
  tmp1=divoptions(options);//180404from
  tmp1=tmp1_5;
  tmp1=apply(tmp1,Toupper(substring(#,0,1)));
  if(contains(tmp1,"M"),
    tmp1=options;
  ,
    tmp1=append(options,"Msg=n");
  );//180404to
  tmp=apply(ptL,Tgrid(#)); // 15.06.03
  Listplot(nm,tmp,tmp1);
);
////%Tlistplot end////

////%ChangeTablestyle start////
ChangeTablestyle(nameL,style):=(
////help:ChangeTablestyle(["r0c0c3"],["da"]);
  regional(nmL,grid,head,sb,tmp,tmp1,tmp2,
    tsg,segall,sg,str);
  if(islist(nameL),nmL=nameL,nmL=[nameL]);
  forall(nmL,grid,
    if(substring(grid,0,1)=="r",sb="c",sb="r");
    tmp=Indexall(grid,sb);
    head=substring(grid,0,tmp_1-1);
    tmp1=substring(grid,tmp_1,tmp_2-1);
    tmp2=substring(grid,tmp_2,length(grid));
    tsg=apply([tmp1,tmp2],parse(#));
    tmp1=apply(GCLIST,#_1); // 16.12.06from
    segall=[];
    forall(tmp1,
      tmp2=substring(#,2,length(#));
      tmp=indexof(tmp2,sb);
      tmp2=substring(tmp2,0,tmp-1);
      if(head==tmp2,segall=append(segall,#));
    );// 16.12.06until
    sg=[];
    forall(segall,
      tmp=Indexall(#,sb);
      tmp1=substring(#,tmp_1,tmp_2-1);
      tmp2=substring(#,tmp_2,length(#));
      tmp=apply([tmp1,tmp2],parse(#));
      if((tsg_1>=tmp_1) & (tsg_2<=tmp_2),
        sg=tmp;
        Changestyle(#,["nodisp"]);
      );
    );
    if(length(sg)==0,
      println("No segment includes "+grid);
    ,
      if(sb=="c",str=sb+"no"+head,str=head+sb+"no");
      if(sg_1<tsg_1,
        tmp1=replace(str,"no",text(sg_1));
        tmp2=replace(str,"no",text(tsg_1));
        tmp=head+sb+text(sg_1)+"c"+text(tsg_1);
        Tlistplot(tmp,[tmp1,tmp2],TableOptions);
      );
      tmp1=replace(str,"no",text(tsg_1));
      tmp2=replace(str,"no",text(tsg_2));
      tmp=head+"c"+text(tsg_1)+"c"+text(tsg_2);
      Tlistplot(tmp,[tmp1,tmp2],style);
      if(tsg_2<sg_2,
        tmp1=replace(str,"no",text(tsg_2));
        tmp2=replace(str,"no",text(sg_2));
        tmp=head+"c"+text(tsg_2)+"c"+text(sg_2);
        Tlistplot(tmp,[tmp1,tmp2],TableOptions);
      );
    );
  );
);
////%ChangeTablestyle end////

////%Findcell start////
Findcell(pos1,pos2):=Findcell("",pos1,pos2);
Findcell(Tbdata,pos1,pos2):=(
//help:Findcell("c0r0","c2r1");
  regional(tmp1,tmp2,posnw,posse,ctr,dx,dy);
  if(isstring(pos1),
    posnw=Tgrid(pos1); // 15.05.20
    posse=Tgrid(pos2);
    //posnw=parse(pos1);
    //posse=parse(pos2);
  ,
    if(islist(pos1),
      posnw=pos1;
      posse=pos2;
    ,
      tmp1="c"+text(pos1-1)+"r"+text(pos2-1);
      tmp2="c"+text(pos1)+"r"+text(pos2);
      posnw=Tgrid(tmp1);
      posse=Tgrid(tmp2);
//      posnw=parse(tmp1);
//      posse=parse(tmp2);
    );
  );
  ctr=(posnw+posse)/2;
  dx=abs(posse_1-ctr_1);
  dy=abs(posnw_2-ctr_2);
  [ctr,dx,dy];
);
////%Findcell end////

////%Putcell start////
Putcell(pos1,pos2,dir,lttr):=Putcell("",pos1,pos2,dir,lttr,[]); //190228from
Putcell(Arg1,Arg2,Arg3,Arg4,Arg5):=(
  if(islist(Arg5),
    Putcell("",Arg1,Arg2,Arg3,Arg4,Arg5);
  ,
    Putcell(Arg1,Arg2,Arg3,Arg4,Arg5,[]);
  );
);
Putcell(Tbdata,pos1,pos2,dir,lttr,options):=(
//help:Putcell("c0r0","c2r1","lt","abc");
//help:Putcell(2,3,"c","xyz");
//help:Putcell(options=["Color="]);
  regional(tmp,tmp1,tmp2,posnw,posse,
     posdir,posstr,ctr,dx,dy);
  tmp=Findcell(Tbdata,pos1,pos2);
  ctr=tmp_1; dx=tmp_2; dy=tmp_3;
  posdir=ctr;
  posstr=dir;
  if(indexof(dir,"b")>0,
    posdir_2=posdir_2-dy;
    posstr=replace(posstr,"b","n");
  );
  if(indexof(dir,"t")>0,
    posdir_2=posdir_2+dy;
    posstr=replace(posstr,"t","s");
  );
  if(indexof(dir,"l")>0,
    posdir_1=posdir_1-dx;
    posstr=replace(posstr,"l","e");
  );
  if(indexof(dir,"r")>0,
    posdir_1=posdir_1+dx;
    posstr=replace(posstr,"r","w");
  );
  Letter([posdir,posstr,text(lttr)],options);
); //190228to
////%Putcell end////

////%Putcellexpr start////
Putcellexpr(pos1,pos2,dir,ex):=Putcellexpr("",pos1,pos2,dir,ex,[]); //190228from
Putcellexpr(Arg1,Arg2,Arg3,Arg4,Arg5):=(
  if(islist(Arg5),
    Putcellexpr("",Arg1,Arg2,Arg3,Arg4,Arg5);
  ,
    Putcellexpr(Arg1,Arg2,Arg3,Arg4,Arg5,[]);
  );
);
Putcellexpr(Tbdata,pos1,pos2,dir,ex,options):=(
//help:Putcellexpr("c0r0","c2r1","lt","abc");
//help:Putcellexpr(2,3,"c","\sin x");
  Putcell(Tbdata,pos1,pos2,dir,"$"+text(ex)+"$",options);
); //190228to
////%Putcellexpr end////

////%Putrow start////
Putrow(nrow,dir,lttrL):=Putrow("",nrow,dir,lttrL,[]); //190228from
Putrow(Arg1,Arg2,Arg3,Arg4):=(
  if(islist(Arg4),
    Putrow("",Arg1,Arg2,Arg3,Arg4);
  ,
    Putcellrow(Arg1,Arg2,Arg3,Arg4,[]);
  );
);
Putrow(Tbdata,nrow,dir,lttrL,options):=(
//help:Putrow(1,"c",["x","y","z"]);
  regional(tmp,tmp1,mcol);
  mcol=length(lttrL);
  forall(1..mcol,
    Putcell(Tbdata,#,nrow,dir,lttrL_#,options);
  );
); //190228to
////%Putrow end////

////%Putrowexpr start////
Putrowexpr(nrow,dir,exL):=Putrowexpr("",nrow,dir,exL,[]); //190228from
Putrowexpr(Arg1,Arg2,Arg3,Arg4):=(
  if(islist(Arg4),
    Putrowexpr("",Arg1,Arg2,Arg3,Arg4);
  ,
    Putrowexpr(Arg1,Arg2,Arg3,Arg4,[]);
  );
);
Putrowexpr(Tbdata,nrow,dir,exL,options):=(
//help:Putrowexpr(2,"r",["x","y","z"]);
  regional(lttrL);
  lttrL=apply(exL,"$"+#+"$");
  Putrow(Tbdata,nrow,dir,lttrL,options);
); //190228to
////%Putrowexpr end////

////%PutcoL start////
PutcoL(mcol,dir,lttrL):=PutcoL("",mcol,dir,lttrL,[]); //190228from
Putcellexpr(Arg1,Arg2,Arg3,Arg4):=(
  if(islist(Arg4),
    Putcellexpr("",Arg1,Arg2,Arg3,Arg4);
  ,
    Putcellexpr(Arg1,Arg2,Arg3,Arg4,[]);
  );
);
PutcoL(Tbdata,mcol,dir,lttrL,options):=(
//help:PutcoL(1,"c",["x","y","z"]);
  regional(tmp,tmp1,nrow);
  nrow=length(lttrL);
  forall(1..nrow,
    Putcell(Tbdata,mcol,#,dir,lttrL_#,options);
  );
); //190228to
////%PutcoL end////

////%PutcoLexpr start////
PutcoLexpr(mcol,dir,exL):=PutcoLexpr("",mcol,dir,exL,[]); //190228from
Putcellexpr(Arg1,Arg2,Arg3,Arg4):=(
  if(islist(Arg4),
    Putcellexpr("",Arg1,Arg2,Arg3,Arg4);
  ,
    Putcellexpr(Arg1,Arg2,Arg3,Arg4,[]);
  );
);
PutcoLexpr(Tbdata,mcol,dir,exL,options):=(
//help:PutcoLexpr(2,"r",["x","y","z"]);
  regional(lttrL);
  lttrL=apply(exL,"$"+#+"$");
  PutcoL(Tbdata,mcol,dir,lttrL,options);
); //190228to
////%PutcoLexpr end////

////%Setrange start////
Setrange():=(
//help:Setrange();
  SW.xy=Pcrd([XMIN,YMIN]);
  NE.xy=Pcrd([XMAX,YMAX]);
  drawpoly([Pcrd([XMIN,YMIN]), Pcrd([XMAX,YMIN]),
        Pcrd([XMAX,YMAX]),Pcrd([XMIN,YMAX])],color->[1,1,1]);
);
////%Setrange end////

////%RSform start////
RSform(str):=RSform(str,3);
RSform(str,listfrom):=(
//help:RSform(string,listfrom);
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
    parse(varstr);
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
        tmp1=tmp1+format(#,5)+",";
      );
    );
    tmp1=substring(tmp1,0,length(tmp1)-1)+"]";
  ,
    tmp1=format(value,5);
  );
  tmp=name+"="+tmp1; // 15.02.06
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
  regional(funstr,str,Pos,nbody,bdy,ppL,bpL,excma,tmp,tmp1,tmp2);
  funstr=name+":=(";
  forall(bodylist,
    funstr=funstr+#+";";
  );
  funstr=funstr+");";
  parse(funstr);
  tmp=indexof(name,"("); 
  str=substring(name,0,tmp-1)+"<-function"+PaO();
  str=str+substring(name,tmp,length(name))+"{";
  forall(1..(length(bodylist)-1),nbody,
    bdy=bodylist_nbody;
    Pos=indexof(bdy,"regional")+indexof(bdy,"local");
    if(Pos==0,
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
  str=str+"return"+PaO()+bodylist_(length(bodylist))+")}";
  FUNLIST=append(FUNLIST,str);
);
////%Deffun end////

////%Inwindow start////
Inwindow(point):=Inwindow(point,[XMIN,XMAX],[YMIN,YMAX]);
Inwindow(point,xrng,yrng):=(
//help:Inwindow(point);
//help:Inwindow(point,xrange,yrange);
  regional(Eps,pt,x,y,xmin,xmax,ymin,ymax,tmp);
  Eps=10.0^(-6);
  if(ispoint(point),pt=point.xy,pt=point);
  x=pt_1; y=pt_2;
  xmin=xrng_1; xmax=xrng_2;
  ymin=yrng_1; ymax=yrng_2;
  tmp=(x>xmin-Eps)&(x<xmax+Eps)&(y>ymin-Eps)&(y<ymax+Eps);
  if(tmp,true,false);
);
////%Inwindow end////

////%Dashlinedata start////
Dashlinedata(dataorg,sen,gap,ptn):=(
  regional(data,eps,dtall,len,lenlist,ii,lenall,kari,
      naga,tobi,nsen,seglist,segunit,hajime,owari,jj,
      flg,tt,ptL,out,tmp,tmp1,tmp2);
  eps=10.0^(-6);
  if(isstring(dataorg),data=parse(dataorg),data=dataorg);
  dtall=length(data);
  out=[];
  len=0; lenlist=[0];
  forall(2..dtall,ii,
    len=len+|data_ii-data_(ii-1)|;
    lenlist=append(lenlist,len);
  );
  lenall=lenlist_dtall;
  if(lenall>0,
    kari=(sen+gap)*0.1;naga=sen*0.1;tobi=gap*0.1;
    if(|data_1-data_dtall|<eps,
      nsen=max([re(ceil(lenall/kari)),3]);
      segunit=lenall/nsen;
      naga=segunit*sen/(sen+gap);
      tobi=segunit*gap/(sen+gap);
      seglist=apply(0..(nsen-1),#*segunit);
    ,
      if(ptn==0,
        nsen=max([re(ceil((lenall+tobi)/kari)),3]);
        segunit=lenall*(sen+gap)/(nsen*sen+(nsen-1)*gap);
        naga=segunit*sen/(sen+gap);
        tobi=segunit*gap/(sen+gap);
        seglist=apply(0..(nsen-1),#*segunit);
      ,
        nsen=max([re(ceil((lenall+naga)/kari)),3]);
        segunit=lenall*(sen+gap)/((nsen-1)*sen+nsen*gap);
        naga=segunit*sen/(sen+gap);
        tobi=segunit*gap/(sen+gap);
        seglist=apply(0..(nsen-2),tobi+#*segunit);
      );
    );
    hajime=1;owari=1;
    forall(1..(length(seglist)),ii,
      len=seglist_ii;
      flg=0;
      forall(owari..dtall,jj,
        if(flg==0,
          if(len<lenlist_jj-eps,
            flg=jj;
          );
        );
      );
      if(flg>0,hajime=flg-1);
      flg=0;
      forall(hajime..dtall,jj,
        if(flg==0,
          if(len+naga<lenlist_jj-eps,
            flg=jj;
          );
        );
      );
      if(flg>0,owari=flg-1);
      tt=len-lenlist_hajime;
      tt=tt/(lenlist_(hajime+1)-lenlist_hajime);
      tmp=data_hajime+tt*(data_(hajime+1)-data_hajime);
      ptL=[tmp];
      forall((hajime+1)..owari,jj,
        ptL=append(ptL,data_jj);
      );
      tt=(len+naga-lenlist_owari);
      tt=tt/(lenlist_(owari+1)-lenlist_owari);
      tmp=data_owari+tt*(data_(owari+1)-data_owari);
      ptL=append(ptL,tmp);
      out=append(out,ptL);
    );
  );
  out;
);
////%Dashlinedata end////

////%Windispg start////
Windispg():=(
  if(ADDAXES=="1", //181215from
    Drwxy();
    ADDAXES="0";
  ); //181215to
  Windispg(GCLIST); //190125
);
Windispg(gcLorg):=( //190125
  regional(gcL,Nj,Nk,Dt,Vj,tmp,tmp1,tmp2,tmp3,tmp4,opcindy);
  gcL=gcLorg; //190125from
  if(length(gcL)>0,
    if(!islist(gcL_1),gcL=[gcL]);
  ); //190125to
  gsave();
  layer(KETPIClayer);
  forall(gcL,Nj,
    if(isstring(Nj_1),Dt=parse(Nj_1),Dt=Nj_1);  // 11.17
    if(islist(Dt) & length(Dt)>0,  // 12.19,12.22
      tmp=Measuredepth(Dt);
      if(tmp==1,Dt=[Dt]);
      opcindy=Nj_3;
      tmp=Nj_2; //190119from
      if(!islist(tmp),tmp=[tmp,""]); //190123
      if(tmp_1<0,tmp1=0,tmp1=tmp_1); //190119from
      if(tmp1<10,
        forall(Dt,Nk,
          if(length(Nk)>1,
            tmp3="";
            if(indexof(opcindy,"color")==0, //190122from
              tmp3=tmp3+",linecolor->"+KCOLOR;
            );
            tmp3=tmp3+opcindy; 
            if(tmp1==0,  //190126from
              if((length(tmp_2)>0)&(indexof(opcindy,"size")==0), 
                tmp3=tmp3+",size->"+tmp_2;
              ); //190124to
              tmp="connect("+Textformat(Nk,5)+tmp3+");";//190125
              parse(tmp);
            ,
              if(tmp1==1,
                tmp4=Dashlinedata(Nk,2.5,2.5,0);
                forall(tmp4,
                  tmp="connect("+Textformat(#,5)+tmp3+");";
                  parse(tmp);
                );
              ,
                tmp3=",dashtype->"+text(tmp1)+tmp3;
                forall(1..(length(Nk)-1),
                  tmp="draw("+Textformat([Nk_#,Nk_(#+1)],5)+tmp3+");";
                  parse(tmp);
                );
              );
            );
           ,
            tmp="draw("+text(Nk_1)+opcindy+");"; // 14.12.31
             parse(tmp);
           ); //190126to
        );
      );
    );
  );
  grestore(); 
  layer(0);
);
////%Windispg end////

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
      tmp1=format(re(tmp_1),6);// 15.02.05
      tmp2=format(re(tmp_2),6);
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
  if((indexof(PathT,"pdflatex")>0)%(indexof(PathT,"lualatex")>0),
    if(GPACK=="tpic",GPACK="pict2e");
  );
  if(GPACK=="pict2e", //  180817
    tmp=replace(tmp+"_rep2e","\","/");
    println(SCEOUTPUT,"source('"+tmp+".r')");
  ); 
  if(GPACK=="tikz", //181213from
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
          tmp2=tmp2+Textformat(#,6)+",";
        );
        tmp1=substring(tmp2,0,length(tmp2)-1)+"]";
      ,
        tmp1=format(tmp1,6);
      );
    );
    tmp1=RSform(tmp1);
    print(SCEOUTPUT,tmp+"="+tmp1+";"); //17.09.22
//    tmp=substring(tmp,0,length(tmp)-1);
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

////%Extractdata start////
Extractdata(name):=Extractdata(1,name,[]);
Extractdata(Arg1,Arg2):=(
  if(isstring(Arg1),
    Extractdata(1,Arg1,Arg2);
  ,
    Extractdata(Arg1,Arg2,[]);
  );
);
Extractdata(number,name,options):=(
//help:ExtractData("ha1");
// help:ExtractData(1,"ha1");
  regional(dlist,tmp,tmp1,tmp2,tmp3,File,Ltype,Noflg,opstr,opcindy,color);
  tmp=Divoptions(options);
  Ltype=tmp_1;
  Noflg=tmp_2;
  color=tmp_(length(tmp)-2);
  opstr=tmp_(length(tmp)-1);
  opcindy=tmp_(length(tmp));
  tmp1=[];
  forall(1..length(GOUTLIST),
    if(contains(GOUTLIST_#_2,name),
      tmp1=append(tmp1,#);
    );
  );
  if(length(tmp1)==0,
    println(name+" not found");
  ,
    tmp1=tmp1_number;
    tmp2=GOUTLIST_tmp1;
    tmp=remove(tmp2_2,[name]);
    GOUTLIST_tmp1=[tmp2_1,tmp];
    File=tmp2_1;
  );
  if(Noflg<3,
    println("extract outdata  "+name);
    tmp1=parse(name);
    tmp3=[ //17.09.18 //no ketjs on
      "Tmpout=ReadOutData("+Dq+File+Dq+")"
    ];
    GLIST=concat(GLIST,tmp3); //no ketjs off
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
  tmp2;
);
////%Extractdata end////

////%RemoveOut start////
RemoveOut(pltlist):=(
  regional(name,tmp,tmp1,tmp2);
  forall(pltlist,name,
    tmp1=[];
    forall(GOUTLIST,
      tmp=remove(#_2,[name]);
      tmp1=append(tmp1,[#_1,tmp]);
    );
    GOUTLIST=tmp1;
  );  
);
////%RemoveOut end////

////%ReadOutData start////
ReadOutData():=ReadOutData(Fnameout);
ReadOutData(filename):=ReadOutData("",filename);  //16.03.07
ReadOutData(Arg1,Arg2):=( //181030from
  if(islist(Arg2),
    ReadOutData("",Arg1,Arg2);
  ,
    ReadOutData(Arg1,Arg2,[]);
  );
); //181030to
ReadOutData(pathorg,filenameorg,optionsorg):=(
//help:ReadOutData();
//help:ReadOutData("file.txt");
//help:ReadOutData("/datafolder","file.txt");
//help:ReadOutdata(options=["Disp=n(/y)]");
  regional(options,path,filename,varname,varL,ptL,pts,tmp,tmp1,tmp2,tmp3,tmp4,
     nmbr,cmdall,cmd,cmdorg,outdt,goutdt,eqL,dispflg);
  options=optionsorg;
  dispflg=1;
  tmp=Divoptions(options); //181024from
  eqL=tmp_5;
  forall(eqL,
    tmp=Strsplit(#,"=");
    tmp1=substring(tmp_1,0,1); tmp1=Toupper(tmp1);
    tmp2=substring(tmp_2,0,1); tmp2=Toupper(tmp2);
    if(tmp1=="D",
      if(tmp2=="N",dispflg=0);
      options=remove(options,[#]); //181030
    );
  ); //181024to
  path=pathorg;   //16.03.07 from
  if(length(path)>0,
    setdirectory(path);
    if(indexof(path,"\")>0,tmp1="\",tmp1="/");
    tmp=substring(path,length(path)-1,length(path));
    if(tmp!=tmp1,path=path+tmp1);
  );   //16.03.07to
   filename=filenameorg;  // 16.04.17
  if(indexof(filename,".")==0,filename=filename+".txt");
  tmp=load(filename);
  cmdall=tokenize(tmp,"//");
  varname=cmdall_1; 
  cmdall=cmdall_(2..length(cmdall)); 
  outdt=[];
  varL=[varname];
  ptL=[];
  forall(cmdall,cmdorg,
    cmd=replace(cmdorg,LFmark,"");
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
            tmp=apply(ptL,Textformat(#,6));
          ,
            tmp="[";
            forall(ptL,tmp1,
              tmp=tmp+apply(tmp1,Textformat(#,6))+",";
            );
            tmp=substring(tmp,0,length(tmp)-1)+"]";
          );
        ,
          tmp="[]";
        );
        parse(varname+"="+tmp);
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
      tmp=apply(ptL,Textformat(#,6));
    ,
      tmp="[";
      forall(ptL,tmp1,
        tmp=tmp+apply(tmp1,Textformat(#,6))+",";
      );
      tmp=substring(tmp,0,length(tmp)-1)+"]";
    );
  ,
    tmp="[]";
  );
  parse(varname+"="+tmp);
  outdt=append(outdt,ptL);
  if(path=="",tmp=filename,tmp=path+filename); //16.03.07
  GOUTLIST=append(GOUTLIST,[tmp,varL]);
  if(length(path)>0, // 16.03.09
    setdirectory(Dirwork); // 16.03.07
  );
  print("readoutdata from "+tmp+" : ");
  if(dispflg==1, //181024from
    println(varL);
  ,
    println("");
  ); //181024to
  varL;
);
////%ReadOutData end////

////%WriteOutData start////
WriteOutData(filename,ptlist):=(
//help:WriteOutData("file.txt",["g1",gr1,"sg",sgAB]);
//help:Writeoutdata("file.txt",["g1",gr1,"sg",sgAB]);
  regional(nn,Gname,Gdata,Str,Gstr,Gj,Pt,Flg,tmp,tmp1,loopend);
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
        Str=Str+"["+format(Pt_1,5)+",";
        Str=Str+format(Pt_2,5);
        if(length(Pt)<3,
          Str=Str+"]";
        ,
          Str=Str+","+format(Pt_3,5)+"]";
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
  println("writeoutdata "+filename+":"+Gstr);
);
////%WriteOutData end////

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
  println(SCEOUTPUT,"cd "+Dq+Dirwork+Dq); // 15.07.16
  tmp1=" "+Dq+Fhead+Dq+" "+Dq+texmainfile+Dq; // 15.12.11
  flg=0;
  forall(reverse(1..length(PathT)),
    if(flg==0,
      if(substring(PathT,#-1,#)=="/",
        tex=substring(PathT,#,length(PathT));
        path=substring(PathT,0,#-1);
        flg=1;
      );
    );
  );
  if(flg==0,  // 17.10.13[Norbert]
    tex=PathT;
    path="";
  );
  if(indexof(flow,"r")>0,
    tmp=Dq+PathR+Dq+" --vanilla --slave < "+Fhead+".r";
     // 17.09.14
    println(SCEOUTPUT,tmp);
  );
  if(tex=="latex" % tex=="platex" % tex=="uplatex", //17.08.13 
    tmp=Dq+PathT+Dq+" "+texmainfile+".tex";
    println(SCEOUTPUT,tmp); 
    if(indexof(flow,"tt")>0,println(SCEOUTPUT,tmp)); //17.10.14
    tmp=replace(Dq+PathT+Dq,tex,"dvipdfmx")+" "+texmainfile+".dvi";
    println(SCEOUTPUT,tmp); 
    tmp="rm "+texmainfile+".dvi";
    println(SCEOUTPUT,tmp);
  );
  if(tex=="xelatex", 
    tmp="export PATH="+path+":${PATH}";
    println(SCEOUTPUT,tmp); 
    tmp="xelatex"+" "+texmainfile+".tex";
    println(SCEOUTPUT,tmp); 
    if(indexof(flow,"tt")>0,println(SCEOUTPUT,tmp)); //17.10.14
    tmp="rm "+texmainfile+".dvi";
    println(SCEOUTPUT,tmp);
  );
  if(tex=="pdflatex" % tex=="pdftex",//16.11.22from 
    tmp=Dq+PathT+Dq+" "+texmainfile+".tex";
    println(SCEOUTPUT,tmp); 
    if(indexof(flow,"tt")>0,println(SCEOUTPUT,tmp)); //17.10.14
  );//16.11.22until
  if(tex=="lualatex",//16.12.16
    tmp=Dq+PathT+Dq+" "+texmainfile+".tex";
    println(SCEOUTPUT,tmp); 
    if(indexof(flow,"tt")>0,println(SCEOUTPUT,tmp)); //17.10.14
  );//16.12.16
  if(!isstring(Pathpdf),
    tmp="preview";
  ,
    tmp=Pathpdf;
  );
  if(tmp=="preview" % tmp=="skim", // 16.09.09from,16.10.20
   tmp="open -a "+Dq+tmp+Dq+" "+texmainfile+".pdf";
  ,
    tmp=Dq+tmp+Dq+" "+texmainfile+".pdf";
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
  if(iswindows(),
    if((isincludefull(Dirwork))&(isexists(Dirwork,"sjis.txt")),
      import("sjis.txt");
    );
  );
//  tmp=replace(tmp,"\","/"); //180408
//  println(SCEOUTPUT,"cd "+Dq+tmp+Dq); //180408
  tmp1=indexof(fname,"Users");//180409from
  tmp2=indexof(fname,Homehead);
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
  println(SCEOUTPUT,"cd "+Dq+fname+Dq);//180409to
  flg=0;
  tmp=replace(PathT,"\","/");
  forall(reverse(1..length(PathT)),
    if(flg==0,
      if(substring(tmp,#-1,#)=="/",
        tex=substring(PathT,#,length(PathT));
        path=substring(PathT,0,#-1);
        flg=1;
      );
    );
  );
  if(flg==0,  // 17.10.13[Norbert]
    tex=PathT;
    path="";
  );
  if(indexof(flow,"r")>0,
    if(indexof(Dirwork,"Users")>0, //180917from
      tmp=Dq+PathR+"\R"+Dq+" --vanilla --slave < execsrc.r";//180514
    ,
      tmp=Dq+PathR+"\R"+Dq+" --vanilla --slave < "+Fhead+".r"; 
    );  //180917to
    println(SCEOUTPUT,tmp);
  );
  if(tex=="latex" % tex=="platex" % tex=="uplatex", //17.08.13 
    tmp=Dq+PathT+Dq+" "+texmainfile+".tex";
    println(SCEOUTPUT,tmp); 
    if(indexof(flow,"tt")>0,println(SCEOUTPUT,tmp)); //17.10.14
    tmp=replace(Dq+PathT+Dq,tex,"dvipdfmx")+" "+texmainfile+".dvi";
    println(SCEOUTPUT,tmp); 
    tmp="del "+texmainfile+".dvi";
    println(SCEOUTPUT,tmp);
  );
  if(tex=="xelatex", 
    tmp="set Path = %Path%;"+Dq+path+Dq;
    println(SCEOUTPUT,tmp); 
    if(indexof(flow,"tt")>0,println(SCEOUTPUT,tmp)); //17.10.14
    tmp="xelatex"+" "+texmainfile+".tex";
    println(SCEOUTPUT,tmp); 
    tmp="del "+texmainfile+".dvi";
    println(SCEOUTPUT,tmp);
  );
  if(tex=="pdflatex" % tex=="pdftex",//16.11.22from 
    tmp=Dq+PathT+Dq+" "+texmainfile+".tex";
    println(SCEOUTPUT,tmp); 
    if(indexof(flow,"tt")>0,println(SCEOUTPUT,tmp)); //17.10.14
  );//16.11.22until
  if(tex=="lualatex",//16.12.16
    tmp=Dq+PathT+Dq+" "+texmainfile+".tex";
    println(SCEOUTPUT,tmp); 
    if(indexof(flow,"tt")>0,println(SCEOUTPUT,tmp)); //17.10.14
  );//16.12.16
  if(!isstring(Pathpdf),
    tmp=indexof(PathS,"\scilab");// 15.12.12
    tmp=substring(PathS,0,tmp-1)+"\SumatraPDF\SumatraPDF.exe";
  ,
    tmp=Pathpdf;
  );
  tmp=Dq+tmp+Dq+" "+texmainfile+".pdf";
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
  ADDPACK=concat(ADDPACK,packL); //17.06.25to
);
////%Addpackage end////

////%Usegraphics start////
Usegraphics(gpack):=( //180817
//help:Usegraphics("pict2e");
  if(!contains(ADDPACK,gpack),
    if(gpack =="tikz", //181213from
      Addpackage(["pgf","tikz"]); //190101
    ,
      Addpackage([gpack]);
    ); //181213to
  );
  GPACK=gpack;
);
////%Usegraphics end////

////%Viewtex start////
Viewtex():=(
  regional(texfile,tmp,tmp1,sep);
  texfile=Fhead+"main";
//  if(iswindows(),sep="\",sep="/"); // 17.04.07
//  sep="/";
  SCEOUTPUT=openfile(texfile+".tex");
  tmp="\documentclass{article}"; // 16.06.09from
  if(indexof(PathT,"platex")>0,
    if(GPACK=="tikz",
      tmp="\documentclass[dvipdfmx]{article}"; // 190101
    ,
      tmp=replace(tmp,"article","jarticle");
      if(indexof(PathT,"uplatex")>0, //17.08.13from
        tmp=replace(tmp,"jarticle","ujarticle");
      );//17.08.13to
    );
  ); // 16.06.09to
  println(SCEOUTPUT,tmp);
  if((indexof(PathT,"pdflatex")>0)%(indexof(PathT,"lualatex")>0), //181213from
    if(GPACK=="tpic", GPACK="pict2e");
  );
  if(GPACK=="tpic", 
    tmp=replace(Dirhead,"\","/");
    println(SCEOUTPUT,"\usepackage{ketpic,ketlayer}");
  );
  if(GPACK=="pict2e", 
    println(SCEOUTPUT,"\usepackage{pict2e}");
    println(SCEOUTPUT,"\usepackage{ketpic2e,ketlayer2e}");
    if(indexof(PathT,"lualatex")>0,
      println(SCEOUTPUT,"\usepackage{luatexja}");
    );
  );
  if(GPACK=="tikz", 
//    println(SCEOUTPUT,"\usepackage{pgf,tikz}");//190101
    println(SCEOUTPUT,"\usepackage{ketpic,ketlayer}");
    if(indexof(PathT,"lualatex")>0, 
      println(SCEOUTPUT,"\usepackage{luatexja}");
    );
  );//181213to
  println(SCEOUTPUT,"\usepackage{amsmath,amssymb}");
  println(SCEOUTPUT,"\usepackage{graphicx}");
  println(SCEOUTPUT,"\usepackage{color}");
  forall(ADDPACK, // 16.05.16from
    println(SCEOUTPUT,"\usepackage"+#); //17.05.25
  );// 16.05.16until
  println(SCEOUTPUT,"");
//  println(SCEOUTPUT,"\def\ketcindy{{K\kern-.20em%"); // deleted 16.11.27,recovered11.29 redeleted17.04.07
//  println(SCEOUTPUT,"\lower.5ex\hbox{E}\kern-.125em{TCindy}}}");
//  println(SCEOUTPUT,"");
  println(SCEOUTPUT,"\setmargin{20}{20}{20}{20}");
  println(SCEOUTPUT,"");
  println(SCEOUTPUT,"\begin{document}");
  println(SCEOUTPUT,"");
  println(SCEOUTPUT,"\verb|"+Fhead+"| by \ketcindy");// 16.01.12, 18, 16.04.08
//  println(SCEOUTPUT,"\verb|"+Fhead+"| by KeTCindy");// 16.11.29 temporarily
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

////%Makecmdlist start////
Makecmdlist(libname):=(
//help:Makecmdlist("ketcindylib");
  regional(cmdall,cmd,flg,tmp,tmp1,tmp2,out);
  setdirectory(Dirlib);
  tmp=load(libname+".cs");
  cmdall=tokenize(tmp,":=");
  out=[];
  forall(cmdall,cmd,
    tmp=max([0,length(cmd)-50]);
    tmp1=";"+substring(cmd,tmp,length(cmd));
    flg=0;
    forall(reverse(1..length(tmp1)),
      if(flg==0,
        if(substring(tmp1,#-1,#)==";",
          tmp=substring(tmp1,#,length(tmp1));
          tmp2=substring(tmp,0,1);
          if(length(tmp)>0,
            if(!contains([" ","/"],tmp2),
              out=append(out,tmp);
              flg=1;
            );
          );
        );
      );
    );
  );
  setdirectory(Dirwork);
  tmp=length(out)-1;
  out=out_(2..tmp);
  out=sort(out);
);
////%Makecmdlist end////

////%Savecmdlist start////
Savecmdlist(cmdlist,cmdfile):=(
  SCEOUTPUT=openfile(cmdfile+".cs");
  forall(cmdlist,
    println(SCEOUTPUT,#);
  );
  closefile(SCEOUTPUT);
);
////%Savecmdlist end////

////%Quicksort start////
Quicksort(seq):=(
  regional(pivot,left,right,out);
  if(length(seq)<2,
    out=seq;
  ,
    pivot = max(seq_1,seq_2);
    left = [];
    right = [];
    forall(seq,
      if(#< pivot,
        left=append(left,#);
      ,
        right=append(right,#);
      );
    );
    left = Quicksort(left);
    right = Quicksort(right);
    out=concat(left,right);
  );
  out;
);
////%Quicksort end////

////%Lessstr start////
Lessstr(st1,st2):=(
  regional(tmp,tmp1,tmp2,out);
  tmp=min(length(st1),length(st2));
  flg=0;
  forall(1..tmp,
    if(flg==0,
      tmp1=substring(st1,#-1,#);
      tmp2=substring(st2,#-1,#);
      if(tmp1<tmp2,
        out=(1<2);
        flg=1;
      ,
        if(tmp1>tmp2,
          out=(1>2);
          flg=1;
        );
      );
    );
  );
  if(flg==0,
    if(length(st1)<length(str2),
      out=(1<2);
    ,
      out=(1>2);
    );
  );
  out;
);
////%Lessstr end////

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
//  mar=[5,5,5,5];
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
  tmp="\documentclass{article}"; // 16.06.09from
  if(indexof(PathT,"platex")>0,
    tmp=replace(tmp,"article","jarticle");
    if(indexof(PathT,"uplatex")>0, //17.08.13from
      tmp=replace(tmp,"jarticle","ujarticle");
    );//17.08.13until
  );
  FigPdfList=append(FigPdfList,tmp); // 16.06.09until
  tmp1="\special{papersize=W mm,H mm}";
  tmp=(XMAX-XMIN)*sc+(mar_1+mar_2);
  tmp1=replace(tmp1,"W",text(tmp));
  tmp=(YMAX-YMIN)*sc+(mar_3+mar_4);
  tmp1=replace(tmp1,"H",text(tmp));
//  if(iswindows(),sep="\",sep="/");//17.04.08
//  sep="/";
  FigPdfList=append(FigPdfList,tmp1);
  if(indexof(PathT,"pdflatex")+indexof(PathT,"lualatex")>0, //17.11.05from
    FigPdfList=append(FigPdfList,
      "\usepackage{pict2e}");
    tmp=replace(Dirhead,"\","/");
    tmp=replace(tmp,"scripts","tex/latex");
    if(isexists(tmp,""),
      FigPdfList=append(FigPdfList,
         "\usepackage{ketpic2e,ketlayer2e}");
    ,
      tmp=replace(Dirhead+"/ketpicstyle","\","/");
      FigPdfList=concat(FigPdfList, 
        ["\usepackage{"+tmp+"/ketpic2e}",
         "\usepackage{"+tmp+"/ketlayer2e}"]);
    );
  ,
    tmp=replace(Dirhead,"\","/");
    tmp=replace(tmp,"scripts","tex/latex");
    if(isexists(tmp,""),
      FigPdfList=append(FigPdfList,
         "\usepackage{ketpic,ketlayer}");
    ,
      tmp=replace(Dirhead+"/ketpicstyle","\","/");
      FigPdfList=concat(FigPdfList,
        ["\usepackage{"+tmp+"/ketpic}",
         "\usepackage{"+tmp+"/ketlayer}"]);
    );
  );//17.11.05until
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

////%Makehelplist start////
Makehelplist(libname):=(
  regional(cmdall,cmd,flg,lev,tmp,tmp1,out);
  tmp=load(libname);
  cmdall=tokenize(tmp,"//help:");
  cmdall=select(cmdall,substring(#,1,3)!=");");
  flg=0;
  forall(1..3,
    if(flg==0,
      if(substring(cmdall_#,0,7)=="start"+PPa(""),
        cmdall=cmdall_((#+1)..length(cmdall));
        flg=1;
      );
    );
  );
  flg=0;
  tmp=length(cmdall);
  forall(0..2,
    if(flg==0,
      if(substring(cmdall_(tmp-#),0,5)=="end"+PPa(""),
        cmdall=cmdall_(1..(tmp-#-1));
        flg=1;
      );
    );
  );
  out=[];
  forall(cmdall,cmd,
    tmp1=indexof(cmd,"(");
    lev=1;
    flg=0;
    forall((tmp1+1)..length(cmd),
      if(flg==0,
        tmp=substring(cmd,#-1,#);
        if(tmp=="(",lev=lev+1);
        if(tmp==")",
          lev=lev-1;
          if(lev==0,
            flg=1;
            out=append(out,substring(cmd,0,#)+";");
          );
        );
      );
    );    
  );
  sort(out);
);
////%Makehelplist end////

////%Helplist start////
Helplist():=Helplist(Dirlib,["+","+3d"],"helpJ");
// 15.05.22
Helplist(Arg):=(
  if(islist(Arg), 
    Helplist(Dirlib,Arg,"helpJ"); // 15.06.20
  ,
    if(indexof(Arg,"help")>0,
      Helplist(Dirlib,["+","+3d"],Arg);
    ,
      Helplist(Arg,["+","+3d"],"helpJ");
    );
  );
);
Helplist(Arg1,Arg2):=(
  if(islist(Arg1),
    Helplist(Dirlib,Arg1,Arg2);
  ,
    if(indexof(Arg2,"help")>0,
      Helplist(Dirlib,Arg1,Arg2);
    ,
      Helplist(Arg,["+","+3d"],Arg2);
    );
  );
);
Helplist(dir,files,help):=(
//help:Helplist();
//help:Helplist("helpE");
  regional(ketfiles,tmp,tmp1,tmp2);
  setdirectory(dir);
  if(contains(files,"+"),
    tmp=remove(files,["+"]);
    ketfiles=concat(["+basic1","+basic2","+out"],tmp);
  ,
    ketfiles=files;
  );
  ketfiles=apply(ketfiles,replace(#,"+","ketcindylib"));
  ketfiles=apply(ketfiles,#+"r.cs");  // 15.11.05 from
  tmp=apply(files,replace(#,"+","ketcindylib"));
//  tmp=apply(files,replace(#,"r.cs",""));
//  tmp=remove(tmp,["ketcindylibout"]); 
//  tmp=apply(tmp,replace(#,"basic",""));
  tmp=apply(tmp,#+help+".txt"); 
  ketfiles=concat(ketfiles,tmp);// 15.11.05 until
  tmp1=[];
  forall(ketfiles,
    tmp=Makehelplist(#);
    tmp1=concat(tmp1,tmp);
  );
  if(!islist(HLIST), // 16.12.31from
    HLIST=sort(tmp1);
  ,
    HLIST=sort(concat(HLIST,tmp1));
  ); // 16.12.31until
  setdirectory(Dirwork);
);
////%Helplist end////

////%Help start////
Help():=(
  forall(HLIST,
    println(#);
  );
);
Help(strorg):=(
//help:Help("Plot");
//help:Help("*");
  regional(str,sel,tmp,tmp1,tmp2,flg,Endflg);
  if(length(HLIST)>0,flg=0,flg=-1);
  str=replace(strorg,"'",Dq);  // 15.11.25
  if(length(str)==0,
    forall(HLIST,
      if(indexof(#,"*")>0,
        println(#);
      );
      flg=1;
    );
  ,
    if(str=="*",
      sel=HLIST;
    ,
      sel=select(HLIST,substring(#,0,length(str))==str);
    );
    if(length(sel)>0,flg=1);
    forall(sel,
      tmp=indexof(#,"(");
      if(substring(#,tmp-2,tmp-1)!="*",
        println(#);
      ,
//        println(substring(#,0,tmp-1));
        tmp1=substring(#,tmp,length(#)-2);
        tmp2=indexof(tmp1,"//");
        Endflg=0;
        forall(1..4,
          if(Endflg==0,
            tmp2=indexof(tmp1,"//");
            if(tmp2==0,
              println("     "+tmp1);
              Endflg=1;
            ,
              println("     "+substring(tmp1,0,tmp2-1));
              tmp1=substring(tmp1,tmp2+1,length(tmp1));
            );
          );
        );
      );
    );
  );
  if(flg==-1,println("    Help not read in"));
  if(flg==0,println("    no example"));
);
////%Help end////

////%Helpkey start////
Helpkey(str):=(
  regional(tmp,tmp1,tmp2);
  tmp1=select(HLIST,indexof(#,str)>0);
  forall(tmp1,
    tmp=substring(#,0,indexof(#,"*")-1);
    Help(tmp);
  );
);
Helpkey(str1,str2):=(
//help:Helpkey(keyword);
//help:Helpkey(keyword1,keyword2);
  regional(tmp,tmp1,tmp2);
  tmp1=select(HLIST,indexof(#,str1)>0);
  tmp1=select(tmp1,indexof(#,str2)>0);
  forall(tmp1,
    tmp=substring(#,0,indexof(#,"*")-1);
    Help(tmp);
  );
);
////%Helpkey end////

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
Setslidebody(str,style,density):=( // 16.12.22,17.01.06,01.08
//help:Setslidebody(["black",,0]);
//help:Setslidebody(["blue","\Large\bf\boldmath",0.1]);
  regional(numlist,tmp,tmp1,letterc,boxc,shadowc,mboxc);
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
//  if(length(reL)>0,
//    LinkPosH=reL_1;
//    if(length(reL)>1,LinkPosV=reL_2);
//    if(length(reL)>2,LinkSize=max(reL_3,0.1));
//  );
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
//  tmp=Divoptions(options);
//  eqL=tmp_5;
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
//    if(indexof(#,"[")==0, 
//      println(SCEOUTPUT,"\usepackage{"+#+"}");
//    ,
      println(SCEOUTPUT,"\usepackage"+#); // 17.07.10
//    );
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
  regional(file,flgL,flg,verbflg,slideL,ns,slideorgL,wall,sld,slidecmd,tmp,tmp0,tmp1,
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
//  tmp=load(tmp1); //181125from
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
//  slideL=select(slideL,length(#)>0); // 16.07.11until
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
  forall(tmp,
    println(SCEOUTPUT,tmp3_#);
  );
  tmp=remove(1..(length(tmp3)),tmp);
  tmp3=tmp3_tmp;//17.06.18until
//  if(iswindows(),sep="\",sep="/"); // 17.04.08
//  sep="/";
  if((indexof(PathT,"pdflatex")>0)%(indexof(PathT,"lualatex")>0),
    if(indexof(PathT,"lualatex")>0,
      println(SCEOUTPUT,"\usepackage{luatexja}");
    );
    println(SCEOUTPUT,"\usepackage{pict2e}");
    println(SCEOUTPUT,"\usepackage{ketpic2e,ketlayer2e}");// 17.04.08from
  ,
    println(SCEOUTPUT,"\special{papersize=\the\paperwidth,\the\paperheight}");
  );// 17.04.08until
  tmp=replace(Dirhead,"\","/");//17.11.01from
  tmp=replace(tmp,"scripts","tex/latex");
  if(isexists(tmp,""),
    println(SCEOUTPUT,"\usepackage{ketpic,ketlayer}");
  ,
    tmp=replace(Dirhead+"/ketpicstyle","\","/");
    println(SCEOUTPUT,"\usepackage{"+tmp+"/ketpic}");
    println(SCEOUTPUT,"\usepackage{"+tmp+"/ketlayer}");
  );
  if(length(wall)==0,
    tmp=replace(Dirhead,"\","/");//17.11.01from
    tmp=replace(tmp,"scripts","tex/latex");
    if(isexists(tmp,""),
      println(SCEOUTPUT,"\usepackage{ketslide}");
    ,
      tmp=replace(Dirhead+"/ketpicstyle","\","/");
      println(SCEOUTPUT,"\usepackage{"+tmp+"/ketslide}");
    );
  ,
    tmp=replace(Dirhead,"\","/");
    tmp=replace(tmp,"scripts","tex/latex");
    if(isexists(tmp,""),
      println(SCEOUTPUT,"\usepackage{ketslide2}");
    ,
      tmp=replace(Dirhead+"/ketpicstyle","\","/");
      println(SCEOUTPUT,"\usepackage{"+tmp+"/ketslide2}");
    );
  );//17.04.08until
  println(SCEOUTPUT,"\usepackage{amsmath,amssymb}");
  println(SCEOUTPUT,"\usepackage{bm,enumerate}");
  if((indexof(PathT,"pdflatex")>0)%(indexof(PathT,"lualatex")>0),
    println(SCEOUTPUT,"\usepackage{graphicx}");
  ,
    println(SCEOUTPUT,"\usepackage[dvipdfmx]{graphicx}");
  );
  println(SCEOUTPUT,"\usepackage{color}");//190222
  letterc=[0.98,0.13,0,0.43]; boxc=[0,0.32,0.52,0];
  shadowc=[0,0,0,0.5]; mboxc="yellow";
  tmp4="abcdefghijklmno";
  forall(1..15,
    tmp=SlideColorList_#;
    if(islist(tmp),
      tmp=text(tmp);
      tmp=substring(tmp,1,length(tmp)-1);
      if(length(SlideColorList_#)==4,//17.01.07from
        println(SCEOUTPUT,"\definecolor{slidecolor"+tmp4_#+"}{cmyk}{"+tmp+"}");
      );
      if(length(SlideColorList_#)==3,
        println(SCEOUTPUT,"\definecolor{slidecolor"+tmp4_#+"}{rgb}{"+tmp+"}");
      );//17.01.07until
      SlideColorList_#="slidecolor"+tmp4_#;
    );
  );
  println(SCEOUTPUT,"\def\setthin#1{\def\thin{#1}}");//17.08.23
  println(SCEOUTPUT,"\setthin{"+text(ThinDense)+"}");//17.08.23
  println(SCEOUTPUT,"\newcommand{\slidepage}[1][s]{%");//180524from
  println(SCEOUTPUT,"\setcounter{ketpicctra}{18}%");
  println(SCEOUTPUT,"\if#1m \setcounter{ketpicctra}{1}\fi");
  println(SCEOUTPUT,"\hypersetup{linkcolor=black}%");
  println(SCEOUTPUT,"");//180908
  println(SCEOUTPUT,"\begin{layer}{118}{0}");
  println(SCEOUTPUT,"\putnotee{122}{-\theketpicctra.05}{\small\thepage/\pageref{pageend}}");
  println(SCEOUTPUT,"\end{layer}\hypersetup{linkcolor="+LinkColor+"}");
  println(SCEOUTPUT,"");//180908
  println(SCEOUTPUT,"}");//189524to
  forall(ADDPACK,// 16.06.09from
    println(SCEOUTPUT,"\usepackage"+#); 
  );// 16.06.09to
  tmp=select(ADDPACK,indexof(#,"{hyperref}")>0);//16.12.31from
  if(length(tmp)>0,
    hyperflg=1;
  ,
    hyperflg=0; //16.12.31until
  );
  forall(tmp3,
    println(SCEOUTPUT,#);
  );
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
//  if(!isstring(PageStyle),PageStyle="headings");//180524from
//  println(SCEOUTPUT,"\pagestyle{"+PageStyle+"}");
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
//  println(SCEOUTPUT,"\thispagestyle{empty}");//180524
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
//        if(substring(tmp2,0,1)=="[",
//          tmp=tmp+tmp2;
//          tmp2=tmp3;
//          tmp3=tmp4;
//        );
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
//    println(SCEOUTPUT,"");
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
  Fillstore(store);//181125
);
////%Mkslidesummary end////

////%Example start////
Example(exorg):=Example(exorg,"");
Example(exorg,suborg):=(
//help:Example("Mxfun","diff");
  regional(ex,tmp,tmp1,tmp2);
  ex=replace(exorg,"'",Dq);
  sub=replace(suborg,"'",Dq);
  setdirectory(Dirlib);
  tmp=load("examples.txt");
  setdirectory(Dirwork);
  tmp=tokenize(tmp,"//");
  tmp=tmp_(1..(length(tmp)-1));
  tmp1=select(tmp,substring(#,0,length(ex))==ex);
  tmp1=sort(tmp1);
  if(length(sub)>0,
    tmp1=select(tmp1,indexof(#,sub)>0);
  );
  forall(tmp1,
    if((indexof(#,"##")>0) % (indexof(#,"~#")>0),
      tmp=indexof(#,",");
      println(substring(#,tmp,length(#)));
    ,
      println(#);
    );
  );
);
////%Example end////

////%BBdata start////
BBdata():=BBdata(BBTarget,0);
BBdata(fname):=BBdata(fname,0); // 16.04.09
BBdata(fname,optionorg):=(
//help:BBdata(filename);
//help:BBdata(options=0(automatic),1(make),"w=","h=");
  regional(fout,flg,path,file,kcfile,options,eqL,reL,stL,
      waiting,addop,tmp,tmp1,tmp2);
  path="";
  file=fname;
  flg=0;
  waiting=2;
  forall(reverse(1..length(fname)),
    if(flg==0,
      tmp=substring(fname,#-1,#);
      if(tmp=="/" % tmp=="\",  // 14.01.15
        path=substring(fname,0,#-1);
        file=substring(fname,#,length(fname));
        flg=1;
      );
    );
  );
  if(path=="",path=Dirwork);//16.10.05
  if(indexof(file,".")==0,file=file+".pdf");
  if(islist(optionorg),options=optionorg,options=[optionorg]);
  tmp=Divoptions(options);
  eqL=tmp_5;
  reL=tmp_6;
  stL=tmp_7;
  flg=0;
  addop="";
  if(length(reL)>0,
    tmp=reL_1;
    if(tmp==1,flg=1);
  );
  forall(stL,
    tmp=Toupper(substring(#,0,1));
    if(tmp=="M",flg=1);
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
    tmp=load(fout); //
    if(length(tmp)==0,
      flg=1;
    ,
      tmp=tokenize(tmp,"%%");
      tmp=tmp_2;
      tmp1=indexof(tmp,":");
      tmp=substring(tmp,tmp1,length(tmp));
      tmp=Removespace(tmp);
      if(tmp!=file,flg=1);
    );
  );
  if(length(path)==0,
    path=Dirwork;
  );
  if(flg==1,
    setdirectory(path);
    tmp=load(file);
    setdirectory(Dirwork);
    if(length(tmp)==0,
      println("   => "+file+" not exists");
      flg=-1;
    );
  );
  if(flg==1,
    SCEOUTPUT = openfile(kcfile);
    if(!iswindows(),
      println(SCEOUTPUT,"#!/bin/sh");
    );
    println(SCEOUTPUT,"cd "+Dq+path+Dq);
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
        wait(10);
        tmp=load(fout);
        if(indexof(tmp,"CreationDate")>0,
          tmp1=1;
        );
      );
    );
    if(length(tmp)==0,
      println(fout+" not generated. Maybe "+kcfile+" not run.");
    ,
      tmp=tokenize(tmp,"%%");
      tmp=select(tmp,indexof(#,"Bounding")>0);
      tmp=tmp_2; //
      tmp1=indexof(tmp,":");
      tmp=substring(tmp,tmp1,length(tmp));
      tmp=Removespace(tmp);
      tmp=tokenize(tmp," ");
      tmp1="";
      forall(tmp,
        tmp1=tmp1+Sprintf(#,2)+" ";
      );
      tmp1=Removespace(tmp1)+addop;
      tmp2="\includegraphics[bb="+tmp1+"]{"+file+"}";
      println(tmp2);
    );
  );
//  setdirectory(Dirwork);
  tmp2; // 16.04.25
);
////%BBdata end////

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
  
//  rmv=concat(rmv,["d","list","c","funN","funP","function","for","return"]);  // in string (for R)
//  rmv=concat(rmv,["gsub","cat"]);  // in string (for R)
//  rmv=concat(rmv,["options"]); // written for Windows
//  rmv=concat(rmv,["isexists"]); // java functions
  
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
        out=append(out,tmp);
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
  regional(fL,jj,tmp,tmp1,tmp2,tmp3);
  fL=apply(Out,#_1);
  tmp1=select(DL,#_1==name);
  if(length(tmp1)>0,
    tmp1=tmp1_1;
    if(!contains(fL,tmp1),
      Out=append(Out,tmp1);
      fL=append(fL,tmp1_1);
      if(length(tmp1)>=5,
        forall(5..(length(tmp1)),jj,
          tmp=tmp1_jj;
          if(!contains(fL,tmp),
            Extractall(tmp);
          );
        );
      );
    );
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
    tmp1=Dqq("%xcp%")+" /Y /Q /S /E /R "+Dqq("ketcindyjs\");
    tmp2=" "+Dqq(Dircdy+"ketcindyjs\");
    println(SCEOUTPUT,tmp1+"Cindy.js.map"+tmp2);
    println(SCEOUTPUT,tmp1+"webfont.js"+tmp2);
    println(SCEOUTPUT,tmp1+"katex-plugin.js"+tmp2);
    println(SCEOUTPUT,tmp1+"Cindy.js"+tmp2);
    println(SCEOUTPUT,tmp1+"CindyJS.css"+tmp2);
    tmp1=Dqq("%xcp%")+" /Y /Q /S /E /R "+Dqq("ketcindyjs\katex\");
    tmp2=" "+Dqq(Dircdy+"ketcindyjs\katex\");
    println(SCEOUTPUT,tmp1+"katex.min.css"+tmp2);
    println(SCEOUTPUT,tmp1+"katex.min.js"+tmp2);
    tmp1=Dqq("%xcp%")+" /Y /Q /S /E /R "+Dqq("ketcindyjs\katex\fonts\");
    tmp2=" "+Dqq(Dircdy+"ketcindyjs\katex\fonts\");
    println(SCEOUTPUT,tmp1+"KaTeX_Main-Regular.ttf"+tmp2);
    println(SCEOUTPUT,tmp1+"KaTeX_Main-Regular.woff"+tmp2);
    println(SCEOUTPUT,tmp1+"KaTeX_Main-Regular.woff2"+tmp2);
    println(SCEOUTPUT,tmp1+"KaTeX_Math-Italic.ttf"+tmp2);
    println(SCEOUTPUT,tmp1+"KaTeX_Math-Italic.woff"+tmp2);
    println(SCEOUTPUT,tmp1+"KaTeX_Math-Italic.woff2"+tmp2);
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
    println(SCEOUTPUT,"cd "+Dqq(tmp1)); //190214from
    println(SCEOUTPUT,"mkdir ketcindyjs");
    println(SCEOUTPUT,"cd "+Dqq(Dirhead+"/ketcindyjs"));
    println(SCEOUTPUT,"cp -r -p katex "+tmp1+"/ketcindyjs");
    println(SCEOUTPUT,"cp -p Cindy.js "+tmp1+"/ketcindyjs");
    println(SCEOUTPUT,"cp -p Cindy.js.map "+tmp1+"/ketcindyjs");
    println(SCEOUTPUT,"cp -p CindyJS.css "+tmp1+"/ketcindyjs");
    println(SCEOUTPUT,"cp -p katex-plugin.js "+tmp1+"/ketcindyjs");
    println(SCEOUTPUT,"cp -p webfont.js "+tmp1+"/ketcindyjs"); //190214to
    println(SCEOUTPUT,"exit 0");
    closefile(SCEOUTPUT);
  );
  kc();
); 
////%Coptketcindyjs end//// 

////%Ketjsoption start//// 190201
Ketjsoption():=Setketcindyjs();
Ketjsoption(list):=Setketcindyjs(list);
////%Ketjsoption end////

////%Setketcindyjs start//// 190201
Setketcindyjs():=(
  KETJSOP;
);
Setketcindyjs(list):=(
//help:Setketcindyjs();
//help:Setketcindyjs(["Local=(n)","Scale=(1)","Nolabel=[]"]);
  regional(eqL,color,tmp);
  tmp=Divoptions(list);
  eqL=tmp_5;
  tmp=tmp_(length(tmp));
  tmp=substring(tmp,1,length(tmp));
  tmp=replace(tmp,"->","=");
  parse(tmp);
  tmp=round(255*color);
  if(color!=[0,0,0],eqL=append(eqL,"Color="+text(tmp)));
  KETJSOP=eqL;
  KETJSOP;
);
////%Setketcindyjs end////

////%Mkketcindyjs start//// 190115
Mkketcindyjs():=Mkketcindyjs(KETJSOP); //190129 
Mkketcindyjs(options):=( //17.11.18
//help:Mkketcindyjs();
//help:Mkketcindyjs(options=["Local=(y)","Scale=(1)","Nolabel=[]","Color=","Grid="]);
//help:Mkketcindyjs(optionsadd=["Web=(y)","Path=Dircdy"]);
  regional(webflg,localflg,htm,htmorg,from,upto,flg,fL,fun,jj,tmp,tmp1,tmp2,tmp3,
      libnameL,libL,lib,jc,nn,name,partL,toppart,lastpart,path,ketflg,flg,cmdL,scale,
      nolabel,color,grid,out,igL,DL,Out);
  libnameL=["basic1","basic2","3d"];
  webflg="Y";  //190128 texflg removed
  localflg="Y"; //190209,0215
  scale=1; //190129
  nolabel=["SW","NE"]; //190129
  color="";
  grid="";
  path=Dircdy;
  forall(options,
    tmp=Strsplit(#,"=");
    tmp1=Toupper(substring(tmp_1,0,1));
    tmp2=tmp_2;
    if(tmp1=="W",
      if(length(tmp2)>0, //190209
        webflg=Toupper(substring(tmp2,0,1));
      );
    );
    if(tmp1=="L",
      if(length(tmp2)>0, //190209
        localflg=Toupper(substring(tmp2,0,1));
      );
    );
    if(tmp1=="S",
      if(length(tmp2)>0, //190209
        scale=parse(tmp2);
      );
    );
    if(tmp1=="N",
      if(length(tmp2)>0, //190209
        tmp=tmp2;
        if(indexof(tmp2,"[")>0,
          tmp=substring(tmp2,1,length(tmp2)-1);
        );
        tmp=tokenize(tmp,",");
        nolabel=concat(nolabe,tmp);
      );
    );
    if(tmp1=="C", //190209
      if(length(tmp2)>0,
        color=tmp2;
        if(substring(color,0,1)=="[", //190130from
          color=substring(color,1,length(color)-1);
        ); //190130to
      );
    );
    if(tmp1=="G",
      if(length(tmp2)>0,
        grid=tmp2;
      );
    );
    if(tmp1=="P",
      if(!tmp2="Dircdy",
        path=tmp2;
      );
    );
  );
  if((webflg=="N")&(localflg=="Y"),
    if(!isexists(Dircdy,"ketcindyjs"),
      Copyketcindyjs();
      println("ketcindyjs has been copied");
    );
  );
  if(!isexists(Dircdy,Fhead+".html"),
    drawtext(mouse().xy-[0,1],"'Write/Rewrite to CindyJS' at first",size->24,color->[1,0,0]);
    wait(3000);
  ,
    htmorg=Readlines(Dircdy,Fhead+".html");
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
    forall(htmorg_(from..upto),
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
    forall(htmorg_(from..upto),
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
    Out=[];
    forall(fL,fun,
      Extractall(fun);
    );
    tmp=Readlines(Dirhead+pathsep()+"ketcindyjs","ignoredfun.txt");
    tmp=apply(tmp,Removespace(#)); //190131
    igL=select(tmp,(length(#)>0)&(substring(#,0,2)!="//")); //190131
    tmp1=select(Out,contains(igL,#_1));
    Out=remove(Out,tmp1); USEDFUN=apply(Out,#_1); //190130
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
      tmp1=Fhead+"json.html";
    ,
      tmp1=Fhead+"jsoff.html";
      if(localflg=="Y",tmp1=replace(tmp1,"off.","offL.")); //190209
    );
    setdirectory(path);
    SCEOUTPUT = openfile(tmp1);
    tmp1=htmorg_((toppart_1)..(toppart_2));
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
         "   <script type="+Dqq("text/javascript")+" src="+Dqq("ketcindyjs/Cindy.js")+"></script>"; //190203
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
    tmp=Readlines(Dirhead+pathsep()+"ketcindyjs","commonused.txt");
    forall(tmp,
     println(SCEOUTPUT,#);
    );
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
      forall(tmp1,
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
            );
          ); //190122to
        );
      );
    );
    tmp=select(partL,#_1=="csinit");
    if(length(tmp)>0,
      tmp=tmp_1;
      from=tmp_2+5; //190206
      upto=tmp_3;
      tmp1=htmorg_((from+1)..(upto-1)); //190119
      kettef="off"; //190206from
      forall(tmp1,
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
              if(tmp1>0,
                println(SCEOUTPUT,substring(tmp,2,tmp1-1));
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
    forall(tmp1,
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
            if(tmp1>0,
              println(SCEOUTPUT,substring(tmp,2,tmp1-1));
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
                 "KeTJS","KeTJSoff","Objview"];
      if(indexof(tmp1_jj,"type: "+Dqq("Button"))>0,
        nn=indexof(tmp1_jj,"text: ");
        tmp=substring(tmp1_jj,nn-1,length(tmp1_jj));
        nn=Indexall(tmp,Dq);
        tmp=substring(tmp,nn_1,nn_2-1);
        if(!contains(tmp2,tmp),
          out=append(out,tmp1_jj); //190129
        );
        flg=1;
      );
      if(flg==0,
        tmp=Indexof(tmp1_jj,"labeled: "); //190225
        if(tmp>0,
          tmp2=tmp1_jj;
          tmp=Indexall(tmp2,Dq); //190129from
          tmp=substring(tmp2,tmp_1,tmp_2-1);
          if(contains(nolabel,tmp),
            if(indexof(tmp2,"labeled: true")>0,
              tmp2=replace(tmp2,"labeled: true","labeled: false");
            );
          );
          if(indexof(tmp2,"size:")==0,
            tmp2=replace(tmp2,"}",", size: 3.0}");
            out=append(out,tmp2); //190129
          ,
            out=append(out,tmp2); //190129
          );  //190129to
          flg=1;
        );
      );
      if(flg==0,
        out=append(out,tmp1_jj); //190129
      ); //190126to
    );
    tmp=select(1..(length(out)),indexof(out_#," ],")>0); //190129from
    tmp=tmp_1;
    tmp1=out_(tmp-1);
    if(substring(tmp1,length(tmp1)-1,length(tmp1))==",", //190201from
      out_(tmp-1)=substring(tmp1,0,length(tmp1)-1);
    ); //190201to
    tmp=select(1..(length(out)),indexof(out_#,"width:")>0);
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
    tmp=round(scale*parse(tmp2));
    out_jj="    width: "+text(tmp)+",";
    tmp=select(1..(length(out)),indexof(out_#,"height:")>0);
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
    tmp=round(scale*parse(tmp2));
    out_jj="    height: "+text(tmp)+",";
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
    forall(out,
      println(SCEOUTPUT,#);
    ); //190129to
    closefile(SCEOUTPUT);
    setdirectory(Dirwork);
    if(webflg=="Y",tmp="json",tmp="jsoff");
    drawtext(mouse().xy-[0,1],tmp+"in "+path,size->20,color->[1,0,0]);
    wait(1000);
  );
);
////%Mkketcindyjs end////

//help:end();

