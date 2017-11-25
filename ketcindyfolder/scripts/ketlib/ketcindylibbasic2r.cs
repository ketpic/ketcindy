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

println("ketcindybasic2(2017.11.24) loaded");

//help:start();

Dispchoice():=(
  if(islist(Ch),
    if(!isreal(ChNum),ChNum=1);
    drawtext(mouse().xy,"Ch="+text(Ch)+" N="+text(ChNum),size->24,color->[0,0,1]);
  );
);

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

Reflectpoint(point,symL):=(
//help:Reflectpoint(A,B);
//help:Reflectpoint(A,[[2,3]]);
//help:Reflectpoint(A,[C,E]);\\
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

Rotatedata(nm,plist,Theta):=Rotatedata(nm,plist,Theta,[]);
Rotatedata(nm,plist,angle,options):=(
//help:Rotatedata("1","crAB",pi/3,[[1,5],"dr,2"]);
  regional(tmp,tmp1,tmp2,pdata,Theta,Pt,Cx,Cy,PdLL,PdL,
    opcindy,Nj,Njj,Kj,Mj,X1,Y1,X2,Y2,Ltype,Noflg,name);
  name="rt"+nm;
  Pt=[0,0];
  tmp=Divoptions(options);
  Ltype=tmp_1;
  Noflg=tmp_2;
  opcindy=tmp_(length(tmp));
  tmp1=tmp_6;
  if(length(tmp1)>0,Pt=Lcrd(tmp1_1));
  pdata=plist;
  if(isstring(pdata),pdata=[pdata]);
  if(!isstring(pdata_1) & MeasureDepth(pdata)==1,
      pdata=[pdata];
  );
  if(isstring(angle),Theta=parse(angle),Theta=angle);
  Cx=Pt_1; Cy=Pt_2;
  PdL=[];
  forall(pdata,Njj,
    if(isstring(Njj),Kj=parse(Njj),Kj=Njj);
    if(MeasureDepth(Kj)==0,Kj=[Kj]); //17.11.24
    if(MeasureDepth(Kj)==1,Kj=[Kj]);
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
    tmp=name+"="+textformat(tmp1,5);
    parse(tmp);
//    tmp1=textformat(plist,5);
    tmp1=text(plist); // 15.10.15
    tmp1=replace(tmp1,"[","list(");
    tmp1=replace(tmp1,"]",")");
    tmp=name+"=Rotatedata("+tmp1+","
	  +textformat(angle,5)+","+textformat(Pt,5)+")";
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
);

Translatedata(nm,plist,mov):=Translatedata(nm,plist,mov,[]);
Translatedata(nm,plist,mov,options):=(
//help:Translatedata("1",["gr1"],[1,2]);
  regional(tmp,tmp1,tmp2,pdata,Cx,Cy,PdL,Nj,Njj,Kj,
           opcindy,X2,Y2,Ltype,Noflg,name);
  name="tr"+nm;
  tmp=Divoptions(options);
  Ltype=tmp_1;
  Noflg=tmp_2;
  opcindy=tmp_(length(tmp));
  pdata=plist;
  if(isstring(pdata),pdata=[pdata]);
  if(!isstring(pdata_1) & MeasureDepth(pdata)==1,
      pdata=[pdata];
  );
  tmp=Lcrd(mov);
  Cx=tmp_1; Cy=tmp_2;
  PdL=[];
  forall(pdata,Njj,
    if(isstring(Njj),Kj=parse(Njj),Kj=Njj);
    if(MeasureDepth(Kj)==1,Kj=[Kj]);
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
    tmp=name+"="+textformat(tmp1,5);
    parse(tmp);
//    tmp1=textformat(plist,5);
    tmp1=text(plist); // 15.10.15
    tmp1=replace(tmp1,"[","list(");
    tmp1=replace(tmp1,"]",")");
    tmp=name+"=Translatedata("+tmp1+","+textformat(mov,5)+")";
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
);

Scaledata(nm,plist,ratioV):=(
  regional(tmp);
  tmp=Lcrd(ratioV);
  Scaledata(nm,plist,tmp_1,tmp_2,[]);
);
Scaledata(nm,plist,Arg1,Arg2):=(
//help:Scaledata("1","crAB",3,2,[[0,0]]);
  regional(tmp,options);
  if(islist(Arg2),
    tmp=Lcrd(Arg1);
	options=Arg2;
    Scaledata(nm,plist,tmp_1,tmp_2,options);
  ,
    Scaledata(nm,plist,Arg1,Arg2,[]);
  );
);
Scaledata(nm,plist,rx,ry,options):=(
  regional(tmp,tmp1,tmp2,pdata,Theta,Pt,Cx,Cy,PdL,
      opcindy,Nj,Njj,Kj,X2,Y2,Ltype,Noflg,name);
  name="sc"+nm;
  Pt=[0,0];
  tmp=Divoptions(options);
  Ltype=tmp_1;
  Noflg=tmp_2;
  opcindy=tmp_(length(tmp));
  tmp1=tmp_6;
  if(length(tmp1)>0,
    Pt=Lcrd(tmp1_1);
  );
  pdata=plist;
  if(isstring(pdata),pdata=[pdata]);
  if(!isstring(pdata_1) & MeasureDepth(pdata)==1,
      pdata=[pdata];
  );
  Cx=Pt_1; Cy=Pt_2;
  PdL=[];
  forall(pdata,Njj,
    if(isstring(Njj),Kj=parse(Njj),Kj=Njj);
    if(MeasureDepth(Kj)==1,Kj=[Kj]);
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
    tmp=name+"="+textformat(tmp1,5);
    parse(tmp);
    tmp1=text(plist);  // 15.10.15
    tmp1=replace(tmp1,"[","list(");
    tmp1=replace(tmp1,"]",")");
    tmp=name+"=Scaledata("+tmp1+","
	  +textformat(rx,5)+","+textformat(ry,5)+","+textformat(Pt,5)+")";
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
);

Reflectdata(nm,plist,symL):=Reflectdata(nm,plist,symL,[]);
Reflectdata(nm,plist,symL,options):=(
//help:Reflectdata("1","crAB",[C]);
  regional(tmp,tmp1,tmp2,pdata,Us,Vs,Pt1,Pt2,Cx,Cy,PdL,
      opcindy,Nj,Njj,Kj,X1,Y1,X2,Y2,Ltype,Noflg,name);
  name="re"+nm;
  Pt=[0,0];
  tmp=Divoptions(options);
  Ltype=tmp_1;
  Noflg=tmp_2;
  opcindy=tmp_(length(tmp));
  pdata=plist;
  if(isstring(pdata),pdata=[pdata]);
  if(!isstring(pdata_1) & MeasureDepth(pdata)==1,
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
    if(MeasureDepth(Kj)==1,Kj=[Kj]);
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
	tmp=name+"="+textformat(tmp1,5);
    parse(tmp);
//    tmp1=textformat(plist,5);
    tmp1=text(plist); // 15.10.15
    tmp1=replace(tmp1,"[","list(");
    tmp1=replace(tmp1,"]",")");
    tmp=name+"=Reflectdata("+tmp1+","+textformat(symL,5)+")";
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
);

Mksegments():=Mksegments([]);
Mksegments(options):=(
//help:Mksegments();
  regional(segstr,p,q,r,tmp1,tmp2,tmp3);
  forall(allsegments(),seg,
    str=text(inspect(seg,"definition"));
    tmp1=indexof(str,"(");
    tmp2=indexof(str,";");
    tmp3=indexof(str,")");
    p=substring(str,tmp1,tmp2-1);
    q=substring(str,tmp2,tmp3-1);
    Listplot([parse(p),parse(q)]);
  );
);

Mkcircles():=Mkcircles([]);
Mkcircles(options):=(
//help:Mkcircles():
  regional(seg,cir,str,p,q,r,tmp1,tmp2,tmp3,tmp4);
  forall(allcircles(),cir,
    str=text(inspect(cir,"definition"));
    tmp1=indexof(str,"(");
    tmp2=indexof(str,";");
    tmp3=indexof(str,")");
    tmp4=indexof(str,";",tmp2+1);
    if(tmp4==0,
      p=substring(str,tmp1,tmp2-1);
      q=substring(str,tmp2,tmp3-1);
      Circledata([parse(p),parse(q)]);
    ,
      p=substring(str,tmp1,tmp2-1);
      q=substring(str,tmp2,tmp4-1);
      r=substring(str,tmp4,tmp3-1);
      Circledata([parse(p),parse(q),parse(r)]);
    );
  );
);

Makesciarg(arglist):=(
  regional(str,tmpstr);
  str="";
  forall(arglist,
    if(isstring(#),
      tmpstr=Dq+#+Dq;
    ,
      tmpstr=textformat(#,5);
    );
    str=str+tmpstr+",";
  );
  str=substring(str,0,length(str)-1);
  str;
);

Setax(arglist):=(
//help:Setax(["l","x","e","y","n","O","sw"]);
//help:Setax([7,"nw"]);
  regional(tmp);
  tmp=Makesciarg(arglist);
  Com1st("Setax("+tmp+")");
);

Htickmark(arglist):=(
//help:Htickmark([1,"1",2,"sw","2"]);
  regional(tmp);
  tmp="";
  tmp=Makesciarg(arglist);
  Com2nd("Htickmark("+tmp+")");
);

Vtickmark(arglist):=(
//help:Vtickmark([1,"1",2,"sw","2"]);
  regional(tmp);
  tmp=Makesciarg(arglist);
  Com2nd("Vtickmark("+tmp+")");
);

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

Drwxy():=(
//help:Drwxy();
  Com2nd("Drwxy()");
  Addax(0);  // 16.01.21
);

Drwpt(pstr):=Drawpoint(pstr);
Drwpt(ptlist,nn):=(  // 16.03.05 from
//help:Drwpt(A);
//help:Drwpt("[1,1],0");
//help:Drwpt(A,0);
//help:Drwpt([1,2],0);
  Drawpoint(ptlist,nn);
);
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
    if(MeasureDepth(ptlistorg)==1,
      ptlist=ptlistorg
    ,
      ptlist=[ptlistorg]
    );
  ,
    ptlist=[ptlistorg]
  );
  thick=PenThick/PenThickInit;// 16.04.09 from
  tmp1=max(TenSize/TenSizeInit,1)/8; 
  Setpen(tmp1); // 16.04.09 upto
  forall(ptlist,
    tmp=textformat(#,5)+","+text(nn);
    Com2nd("Drwpt("+tmp+")"); // 16.04.09
  );
  Setpen(thick); // 16.04.09
);// 16.03.05 upto

Addax(param):=(
//help:Addax(0);
  ADDAXES=textformat(param,5);
);

Expr(Pt,Dr,St):=Expr([Pt,Dr,St]);
Expr(list):=Expr(list,[]);
Expr(listorg,options):=( //16.10.09
//help:Expr([A,"e","f(x)=x^2"]);
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

Letter(Pt,Dr,St):=Letter([Pt,Dr,St]);
Letter(list):=Letter(list,[]);
Letter(list,options):=(
//help:Letter([C,"c","Graph of f(x)"]);
  regional(Nj,Pos,Dir,Str,Off,Dmv,Xmv,Ymv,Noflg,opcindy,
      opL,aln,sz,clr,bld,ita,tmp,tmp1,tmp2);
  tmp=Divoptions(options);
  Noflg=tmp_2;
  opL=select(options,indexof(#,"->")>0); //16.10.09from
  tmp=select(opL,indexof(#,"color"));
  size=12;
  clr=[0,0,0];
  bld=false;
  ita=false;
  aln="left";
  forall(opL,
    tmp=indexof(#,"->");
    tmp1=removespace(substring(#,0,tmp-1));
    tmp2=substring(#,tmp+1,length(#));
    if(tmp1=="size",sz=parse(tmp2));
    if(tmp1=="color",clr=parse(tmp2));
    if(tmp1=="bold",bld=parse(tmp2));
    if(tmp1=="ita",ita=parse(tmp2));
  );//16.10.09upto
  Off=-4;
  Dmv=8;
  Nj=1;
  while(Nj+2<=length(list),
//    Pos=textformat(list_Nj,5);
    Pos=list_Nj;
    Dir=list_(Nj+1);
    tmp=indexof(Dir,"s")+indexof(Dir,"n");//16.10.19from
    if(tmp>0, 
      tmp=indexof(Dir,"w")+indexof(Dir,"e");
      if(tmp==0,
        Dir="c"+Dir;//16.10.08
      );
    );//16.10.19upto
    Str=list_(Nj+2);
    if(!isstring(Str),Str=format(Str,5)); // 16.09.30,10.09
    tmp=replace(Str,".xy","");
    tmp=replace(tmp,".x","(1)");
    Str=replace(tmp,".y","(2)");
    Str=RSslash(Str); // 17.09.24
    if(indexof(Str,"`")>0,
//      tmp=Dq+",Assign('"+Str+"','`',Prime()))";
      tmp=Dq+",Assign('"+Str+"'))"; // 15.02.22
    ,
      tmp=Dq+","+Dq+Str+Dq+")";
    );
    if(Noflg==0,
      Com2nd("Letter("+Lcrd(Pos)+","+Dq+Dir+tmp);//16.10.10
    );
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
        aln="mid"; // 16.09.30upto
      );
      Str=list_(Nj+2);  //17.10.17
      drawtext(Pcrd(Pos),Str,offset->[Off+Xmv,Off+Ymv],
         size->sz,color->clr,align->aln,bold->bld,italics->ita);//16.10.09
    );
    Nj=Nj+3;
  );
);

Letterrot(pt,dir,str):=Letterrot(pt,dir,0,0,str);
Letterrot(pt,dir,movstr,str):=(
//help:Letterrot(C,B-A,"AB"):
//help:Letterrot(C,B-A,0,5,"AB"):
//help:Letterrot(C,B-A,"t0n5","AB"):
  regional(tmov,nmov,tmp,tmp1,tmp2);
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
  Letterrot(pt,dir,tmov,nmov,str);
);
Letterrot(pt,dir,tmov,nmov,str):=(
  regional(tmp);
  Letter([pt,"c",str],["notex"]);
  tmp=replace(str,"\","\\"); //17.10.18
  Com2nd("Letterrot("+pt+","+dir+","+tmov+","+nmov+",'"+tmp+"')");
);

Exprrot(pt,dir,str):=Exprrot(pt,dir,0,0,str);
Exprrot(pt,dir,movstr,str):=(
//help:Exprrot(C,B-A,"d"):
//help:Exprrot(C,B-A,0,5,"d"):
//help:Exprrot(C,B-A,"t0n5","d"):
  regional(tmov,nmov,tmp,tmp1,tmp2);
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
  Exprrot(pt,dir,tmov,nmov,str);
);
Exprrot(pt,dir,tmov,nmov,str):=(
  regional(tmp);
  Expr([pt,"c",str],["notex"]);
  tmp=replace(str,"\","\\"); //17.10.18
  Com2nd("Exprrot("+pt+","+dir+","+tmov+","+nmov+",'"+tmp+"')");
);

Putslider(ptstr,p1,p2):=Slider(ptstr,p1,p2);
Slider(ptstr,p1,p2):=( //17.04.11
//help:Slider("A-C-B",[-3,0],[3,0]);
  regional(pA,pB,pC,seg,sname,Alpha,tmp,tmp1);
  tmp=indexall(ptstr,"-");
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
  Listplot([parse(pA),parse(pB)],["notex","color->[0,0.4,0.4]","size->2"]);
//  create([sname],"Segment",[parse(pA),parse(pB)]);
//  tmp2=Listplot("",[p1,p2],["nodata"]);
  Putonseg(pC,parse("sg"+pA+pB));
//  create([pC],"PointOn",[parse(sname),0.5]);
);

Putpoint(name,Pt):=Putpoint(name,Pt,Pt);
Putpoint(name,Ptinit,Pt):=(
//help:Putpoint("A",[1,2],[1,A.y]);
  regional(ptstr);
  ptstr=apply(allpoints(),#.name);//16.10.06
  if(!contains(ptstr,name),
    createpoint(name,Pcrd([Ptinit_1,Ptinit_2]));
    ,
    ptstr=name+".xy="+textformat(Pcrd(Pt),5);
    parse(ptstr);
  );
);

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

Bezier(ptctrlist):=BezierCurve(ptctrlist_3,ptctrlist_1,ptctrlist_2,[]);
Bezier(ptctrlist,options):=BezierCurve(ptctrlist_3,ptctrlist_1,ptctrlist_2,options);
Bezier(nm,ptlist,ctrlist):=BezierCurve(nm,ptlist,ctrlist,[]);
Bezier(nm,ptlist,ctrlist,options):=BezierCurve(nm,ptlist,ctrlist,options);
BezierCurve(nm,ptlist,ctrlist):=BezierCurve(nm,ptlist,ctrlist,[]);
BezierCurve(nm,ptlistorg,ctrlistorg,options):=(
//help:Bezier("1",[A,D],[B,C]);
//help:Bezier(options=["Num=10"]);
  regional(name,Ltype,Noflg,opstr,opcindy,Num,
    ptlist,ctrlist,tmp,tmp1,tmp2,ii,st,out,list);
  name="bz"+nm;
  tmp=Divoptions(options);
  Ltype=tmp_1;
  Noflg=tmp_2;
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
    forall(ctrlistorg,tmp1,
      if(MeasureDepth(tmp1)==0,tmp=[tmp1],tmp=tmp1);
      tmp=apply(tmp,Lcrd(#)); // 16.08.16
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
    tmp=name+"="+textformat(out,5);
    parse(tmp);
    tmp1=textformat(ptlist,5);
    tmp1="list("+substring(tmp1,1,length(tmp1)-1)+")";
    tmp2=textformat(ctrlist,5);
    tmp2="list("+substring(tmp2,1,length(tmp2)-1)+")";
    GLIST=append(GLIST,name+"=Bezier("+tmp1+","+tmp2+opstr+")");
  );
  if(Noflg<2,
    if(isstring(Ltype),
      Ltype=GetLinestyle(text(Noflg)+Ltype,name);
    ,
      if(Noflg==1,Ltype=0);
    );
    GCLIST=append(GCLIST,[name,Ltype,opcindy]);
  );
  list;
);

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

Bezierstart(n):=( // 2016.02.26
  BezierNumber=n;
);

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
  if(MeasureDepth(ptlist)==1,ptlist=[ptlist]);
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

Mkbeziercrv(nm,ptctrL):=Mkbeziercrv(nm,ptctrL,[]);
Mkbeziercrv(nm,ptctrL,options):=(
 //help:Mkbeziercrv("1",[[A,B,C,D],[[P,Q],[R,S],T]]);
  regional(ptctrLL,name,ptlist,ctrlist,tmp,tmp1,tmp2);
  if(MeasureDepth(ptctrL)==2,ptctrLL=[ptctrL],ptctrLL=ptctrL);
  forall(1..length(ptctrLL),
    name=nm+text(#);
    ptlist=ptctrLL_#_1;
    ctrlist=ptctrLL_#_2;
    Bezier(nm,ptlist,ctrlist,options); // 17.01.06
  );  
);

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
    bz=tmp1;// 16.04.22upto
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
    tmp1=replace(tmp1,"list(","[");
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
    if(MeasureDepth(tmp2)==1,tmp2=[tmp2]); // 16.04.22from
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
    Bezier(file+text(nc),tmp1,tmp2,options);// 16.04.22upto
    out=append(out,"bz"+tmp);
  );
  out;
);

Ospline(nm,ptlist):=Ospline(nm,ptlist,[]);
Ospline(nm,ptlist,options):=(
//help:Ospline("1",ptlist,[options]);
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
  
CRspline(nm,ptL):=CRspline(nm,ptL,[]);
CRspline(nm,ptL,options):=(
  // Catmull-Rom spline
//help:CRspline("1",[A,B,C,A]);
  regional(name,ptlist,ctrpts,eqL,opcindy,c,v,tmp,tmp1,tmp2,ctrlist,cflg);
  name="crsp"+nm;
  if(MeasureDepth(ptL)==1,tmp=[ptL],tmp=ptL);
  ptlist=tmp_1;
  if(length(tmp)==1,
    cflg=1;
  ,
    cflg=0;
    ctrpts=tmp_2;
  );
  c=1/6;
  tmp=Divoptions(options);
  eqL=tmp_5;
  opcindy=tmp_(length(tmp)); // 15.03.05
  forall(eqL,
    if(substring(#,0,1)=="R",
      tmp2=indexof(#,"=");
      c=parse(substring(#,tmp2,length(#)));
    );
  );
  ptlist=apply(ptlist,Lcrd(#)); // 16.08.16
  ctrlist=[];
  forall(1..(length(ptlist)-1),
    if(#==1,
      if(cflg==0,
        tmp1=ctrpts_1;
      ,
        v=ptlist_2-ptlist_(length(ptlist)-1);
        tmp1=ptlist_#+c*v;
      );
    ,
      v=ptlist_(#+1)-ptlist_(#-1);
      tmp1=ptlist_#+c*v;
    );
    if(#==length(ptlist)-1,
      if(cflg==0,
        tmp2=ctrpts_2;
      ,
        v=ptlist_2-ptlist_#;
        tmp2=ptlist_(#+1)-c*v;
      );
    ,
      v=ptlist_(#+2)-ptlist_#;
      tmp2=ptlist_(#+1)-c*v;
    );
    tmp=select(options,indexof(text(#),"->")>0);
    tmp=append(tmp,"notex");  //15.03.05
	Pointdata(name+text(#),[tmp1,tmp2],tmp);
    ctrlist=append(ctrlist,[tmp1,tmp2]);
  );
  Bezier(nm,ptlist,ctrlist,options);
);

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
      tmp=Append((2*pt.xy-pt1.xy),1);
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
    tmp=Append((2*pt.xy-pt1.xy),1);
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

Bspline(nm,ctrL):=Bspline(nm,ctrL,[]);
Bspline(nm,ctrL,options):=(
//help:Bspline("",[A,B,C]);
  regional(list,tmp);
  list=Listbspline2bz(ctrL);
  tmp=BezierCurve("b"+nm,list_1,list_2,options);
  tmp;
);

MeetCurve(Crv,Xorg,Yorg):=(
  regional(Cv,tmp,tmp1,tmp2,X0,Y0,x1,x2,y1,y2,Ylist,Ban,Tate);
  if(isstring(Crv),Cv=parse(Crv),Cv=Crv);
  if(MeasureDepth(Cv)==2,Cv=Cv_1);
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

PutonLine(name,p1,p2):=PutonLine(name,p1,p2,[]);
PutonLine(name,p1org,p2org,options):=(
//help:PutonLine("C","sgAB");
//help:PutonLine("C",pA,pB);
  regional(par,p1,p2,dx,dy,tmp,tmp1,tmp2);
  par=0.5;
  tmp=Divoptions(options);
  if(length(tmp_6)>0,
    par=tmp_6_1;
  );
  p1=Lcrd(p1org);//16.10.11from
  p2=Lcrd(p2org);
  dx=p2_1-p1_1;
  dy=p2_2-p1_2;
  tmp1=(1-par)*p1+par*p2;
  if(abs(dx)>abs(dy),    
    tmp=name+".x";
    tmp2="["+tmp+",dy/dx*("+tmp+"-p1_1)+p1_2]";//16.10.11upto
    Putpoint(name,tmp1,parse(tmp2));
  ,
    if(abs(dy)>0,
      tmp=name+".y";
      tmp2="[dx/dy*("+tmp+"-p1.y)+p1_1,"+tmp+"]";
      Putpoint(name,tmp1,parse(tmp2));
    ,
      tmp2=p1;//16.10.11
      Putpoint(name,tmp1,tmp2);
    );
  );
);

PutonSeg(name,sgstr):=(
  regional(seg,p1,p2);
  if(isstring(sgstr),seg=parse(sgstr),seg=sgstr);
  PutonSeg(name,LLcrd(seg_1),LLcrd(seg_2));
);
PutonSeg(name,p1,p2):=PutonSeg(name,p1,p2,[]);
PutonSeg(name,p1org,p2org,options):=(
//help:PutonSeg("C","sgAB");
//help:PutonSeg("C",pA,pB);
  regional(par,dx,dy,p,tmp,tmp1,tmp2);
  par=0.5;
  tmp=Divoptions(options);
  if(length(tmp_6)>0,
    par=tmp_6_1;
  );
  p1=Lcrd(p1org);//16.10.11from
  p2=Lcrd(p2org);
  PutonLine(name,p1,p2,[par]);
  dx=p2_1-p1_1;
  dy=p2_2-p1_2;
  p=parse(name+".xy");
  p=LLcrd(p);
  if(abs(dx)>abs(dy) & (p_1-p1_1)*(p_1-p2_1)>0,
    if(|p-p1|<|p-p2|,
      parse(name+".xy=Pcrd(p1)");
    ,
      parse(name+".xy=Pcrd(p2)");
    );
  );
  if(abs(dx)<abs(dy) & (p_2-p1_2)*(p_2-p2_2)>0,
    if(|p-p1|<|p-p2|,
      parse(name+".xy=Pcrd(p1)");
    ,
      parse(name+".xy=Pcrd(p2)");//16.10.11upto
    );
  );
);

PutonCurve(pn,crv):=PutonCurve(pn,crv,[]);
PutonCurve(pn,crv,options):=(
//help:PutonCurve("A","gr1");
  regional(Pmt,pstr,optionL,leftlim,rightlim,tmp,tmp1,Flg,Msg);
  if(!islist(options),optionL=[options],optionL=options);
  leftlim=XMIN;
  rightlim=XMAX;
  Flg=0;
  Msg="y";
  forall(optionL,
    if(isstring(#),  // 16.02.10 from
      tmp=indexof(#,"=");
      tmp1=Toupper(substring(#,tmp,tmp+1));
      if(tmp1=="N", Msg="n"); // 16.02.10 upto
    ,
      if(Flg==0,
        leftlim=#;
        Flg=Flg+1;
      ,
        rightlim=#;
      );
    );
  );
  Pmt=MeetCurve(crv,leftlim,0);
  pstr=apply(allpoints(),textformat(#,5)); // 15.04.07
  if(!contains(pstr,pn),
    createpoint(pn,Pcrd(Pmt));
  ,
    tmp1=parse(pn+".x");
    if(tmp1< leftlim % tmp1>rightlim,
      if(tmp1< leftlim,tmp= leftlim, tmp=rightlim);
      Pmt=MeetCurve(crv,textformat(tmp,5),pn+".y");
    ,
      Pmt=MeetCurve(crv,pn+".x",pn+".y");
    );
    ptstr=pn+".xy="+textformat(Pcrd(Pmt),5)+";";
    parse(ptstr);
  );
  if(Msg=="y",
    println("Put "+pn+" on Curve "+text(crv));
  );
);

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

Setscaling(sc):=(
//help:Setscaling(3);
  SCALEX=1;
  SCALEY=sc;
  Com0th("Setscaling("+sc+")");
  Setwindow("Msg=no");
);

Periodfun(defL,rep):=Periodfun(defL,rep,[]);
Periodfun(defL,rep,optionorg):=(  // 16.11.24
//help:Periodfun(["0",[-1,0],"1",1,[0,1],1],2(num of repetition),options);
//help:Periodfun(options=["Con=y"]);
//help:Periodfun(defL=[function string, range, devision number,...]);
  regional(nn,fun,range,num,options,nr,maxfun,
    tmp,tmp1,tmp2,eqL,connect,minx,maxx,pdata,Eps,prept);
  options=optionorg;
  tmp=Divoptions(options);
  eqL=tmp_5;
  connect="Y";
  forall(eqL,
    tmp=indexof(#,"=");
    tmp2=substring(#,tmp,tmp+1);
    tmp=substring(#,0,3);
    if(Toupper(tmp)=="CON",
      connect=Toupper(tmp2);
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
    tmp1=if(isstring(range_1),parse(range_1),range_1); //17.06.11(2lines)
    tmp2=if(isstring(range_2),parse(range_2),range_2);
    minx=min(minx,tmp1);
    maxx=max(maxx,tmp2);
    num=defL_(3*nn);
    options=append(options,"Num="+text(num));
    Plotdata("pe"+text(nn),fun,
      "x="+textformat([tmp1,tmp2],5),options);
    pdata=append(pdata,"grpe"+text(nn));
    tmp1=range_1; //17.06.11(4lines)
    if(isstring(tmp1),tmp1=replace(tmp1,"pi","%pi"),tmp1=format(tmp1,5));
    tmp2=range_2;
    if(isstring(tmp2),tmp2=replace(tmp2,"pi","%pi"),tmp2=format(tmp2,5));
    mxfun=mxfun+"elseif ("+tmp1+
      "<=x and x<"+tmp2+") then "+fun+" ";
  );
  per=maxx-minx;
  forall(1..rep,nr,
    tmp1=[];
    forall(pdata,
      Translatedata("p"+#+text(nr),#,[per*nr,0],options);
      Translatedata("m"+#+text(nr),#,[-per*nr,0],options);
      tmp1=concat(tmp1,["trp"+#+text(nr),"trm"+#+text(nr)]);
    );
  );
  pdata=concat(pdata,tmp1);
  if(connect=="Y",
    Eps=10^(-5);
    pdata=sort(pdata,[parse(#)_1_1]);
    prept=parse(pdata_1)_1;
    forall(1..(length(pdata)),
      tmp=parse(pdata_#);
      tmp1=tmp_1;
      tmp2=tmp_(length(tmp));
      if(|prept-tmp1|>Eps,
        Listplot("con"+text(#),[prept,tmp1],append(options,"da"));
      );
      prept=tmp_(length(tmp));
    );
  );
  mxfun=substring(mxfun,4,length(mxfun)-1);
  [mxfun,per];
);

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
    tmp1=Toupper(substring(#,0,2));
    tmp2=Toupper(substring(#,tmp,tmp+1));
    if(tmp1=="RN",
      rng=tmp2;
      options=remove(options,[#]);
    );
  );//16.12.16upto
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

Tabledata(nm,n,m,xsize,ysize,rmvL):=
    Tabledata(nm,n,m,xsize,ysize,rmvL,[]);
Tabledata(nm,n,m,xsize,ysize,rmvL,options):=(
//help:Tabledata("",xLst,yLst,rmvL,[2,"Rng=y"]);
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
    tmp1=Toupper(substring(#,0,2));
    tmp2=Toupper(substring(#,tmp,tmp+1));
    if(tmp1=="RN",
      rng=tmp2;
      options=remove(options,[#]);
    );
  );//16.12.16upto
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
      rlist_(#+1)=parse(tmp+".xy");
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
  regional(tmp);
  tmp=apply(ptL,Tgrid(#)); // 15.06.03
  Listplot(nm,tmp,append(options,"Msg=no"));
);

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
    );// 16.12.06upto
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

Putcell(pos1,pos2,dir,lttr):=Putcell("",pos1,pos2,dir,lttr);
Putcell(Tbdata,pos1,pos2,dir,lttr):=(
//help:Putcell("c0r0","c2r1","lt","abc");
//help:Putcell(2,3,"c","xyz");
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
  Letter(posdir,posstr,text(lttr));
);

Putcellexpr(pos1,pos2,dir,ex):=Putcellexpr("",pos1,pos2,dir,ex);
Putcellexpr(Tbdata,pos1,pos2,dir,ex):=(
//help:Putcellexpr("c0r0","c2r1","lt","abc");
//help:Putcellexpr(2,3,"c","\sin x");
  Putcell(Tbdata,pos1,pos2,dir,"$"+text(ex)+"$");
);

Putrow(nrow,dir,lttrL):=Putrow("",nrow,dir,lttrL);
Putrow(Tbdata,nrow,dir,lttrL):=(
//help:Putrow(1,"c",["x","y","z"]);
  regional(tmp,tmp1,mcol);
  mcol=length(lttrL);
  forall(1..mcol,
    Putcell(Tbdata,#,nrow,dir,lttrL_#);
  );
);

Putrowexpr(nrow,dir,exL):=Putrowexpr("",nrow,dir,exL);
Putrowexpr(Tbdata,nrow,dir,exL):=(
//help:Putrowexpr(2,"r",["x","y","z"]);
  regional(lttrL);
  lttrL=apply(exL,"$"+#+"$");
  Putrow(Tbdata,nrow,dir,lttrL);
);

PutcoL(mcol,dir,lttrL):=PutcoL("",mcol,dir,lttrL);
PutcoL(Tbdata,mcol,dir,lttrL):=(
//help:PutcoL(1,"c",["x","y","z"]);
  regional(tmp,tmp1,nrow);
  nrow=length(lttrL);
  forall(1..nrow,
    Putcell(Tbdata,mcol,#,dir,lttrL_#);
  );
);
PutcoLexpr(mcol,dir,exL):=PutcoLexpr("",mcol,dir,exL);
PutcoLexpr(Tbdata,mcol,dir,exL):=(
//help:PutcoLexpr(2,"r",["x","y","z"]);
  regional(lttrL);
  lttrL=apply(exL,"$"+#+"$");
  PutcoL(Tbdata,mcol,dir,lttrL);
);

Setrange():=(
//help:Setrange();
  SW.xy=Pcrd([XMIN,YMIN]);
  NE.xy=Pcrd([XMAX,YMAX]);
  drawpoly([Pcrd([XMIN,YMIN]), Pcrd([XMAX,YMIN]),
        Pcrd([XMAX,YMAX]),Pcrd([XMIN,YMAX])],color->[1,1,1]);
);

Sciform(list):=(
  regional(plotlist,comp,pos,out,out2,nn,strL,flg,
    tmp,tmp1,tmp2,tmp3,Nj);
  plotlist=Flatten([list]);
  out=replace(plotlist_1,".xy","");
  out=replace(out,".x","(1)");
  out=replace(out,".y","(2)");
  if(length(plotlist)==1,
    comp=[];
    forall(1..length(out),
       comp=append(comp,substring(out,#-1,#));
    );
    out="";
    pos=0;
    forall(comp,
      if(#!="'",
        out=out+#;
      ,
        if(pos==0,
          tmp=indexof(out,"Assign(");
          if(substring(out,length(out)-7,length(out))=="Assign(",
            out=out+"'";
            pos=1;
          ,
            out=out+"Assign('";
            pos=2;
          );
        ,
          if(pos==2,
            out=out+"')";
          , 
            out=out+"'";
          );
          pos=0;
        );
      );
    );    
  ,
    forall(2..length(plotlist),
      comp=plotlist_#;
      if(isstring(comp),
        pos=indexof(comp,"Assign(");
        if(pos>0,
          comp=substring(comp,6,length(comp));
        );
        out=out+"Assign(";
        comp=replace(comp,".xy","");
        comp=replace(comp,".x","(1)");
        comp=replace(comp,".y","(2)");
        out=out+"'"+comp+"'";
        out=out+"),";
      );
      if(islist(comp),
        forall(comp,
          out=out+"'"+#+"',";
        );
      );
    );
    if(length(plotlist)>1,
      out=substring(out,0,length(out)-1);
      out=out+");";
    );
  );
  pos=[];
  forall(1..length(out),
    tmp=indexof(substring(out,#-1,length(out)),"Assign");
    if(tmp>0,
      tmp1=#-1+tmp;
      if(length(pos)==0,
        pos=[tmp1];
      ,
        if(pos_(length(pos))<tmp1,
          pos=append(pos,tmp1);
        );
      );
    );
  );
  if(length(pos)>0,
    strL=[];
    Nj=0;
    forall(pos,
      tmp=substring(out,Nj,#-1);
      strL=append(strL,tmp);
      Nj=#-1;
    );
    strL=append(strL,substring(out,Nj,length(out)));
    out="";
    forall(strL,
      if(indexof(#,"Assign")==0,
        out=out+#;
      ,
        tmp=indexof(#,"('");
        tmp1=indexof(#,"')");
        tmp2=substring(#,tmp+1,tmp1-2);
        tmp3=substring(#,tmp1-2,length(#));
        if(indexof(tmp2,"=")==0,
          out=out+#;
        ,
          tmp=substring(tmp2,0,indexof(tmp2,"="));
          out=out+"'"+tmp+"'+"+"Assign('";
          tmp=substring(tmp2,indexof(tmp2,"="),length(tmp2));
          out=out+tmp+tmp3;
        );
      );
    );
  );
  out2="";   // patched 16.01.21 from
  nn=length(out);
  flg=0;
  forall(1..nn,
    if(flg==0,
      tmp=indexof(out,"='+Assign('");
      if(tmp==0,
        out2=out2+out;
        flg=1;
      ,
        out2=out2+substring(out,0,tmp);
        out=substring(out,tmp+10,length(out));
        tmp=indexof(out,"'"); // 16.04.19 from
        tmp1=substring(out,0,tmp-1);
        tmp2="1234567890";
        tmp=apply(1..length(tmp1),
            indexof(tmp2,substring(tmp1,#-1,#)));
        tmp=min(tmp);
        if(tmp==0,  // 16.04.19 upto
          out2=out2+"'+Assign('";
        ,
          tmp=indexof(out,"'");
          out=substring(out,0,tmp)+substring(out,tmp+1,length(out)); 
          // 16.04.18 upto
        );
      );
    );
  );
  out2=replace(out2,"Dist=","D=");
  out2=replace(out2,"Dis=","D=");
  out2;
);

RSform(str):=RSform(str,3);
RSform(str,listfrom):=(
  regional(posL,mxlv,rep1,rep2,rep3,prev,out,
    tmp,tmp1,tmp2);
  rep1="c("; rep2="c("; rep3="list(";
  if(listfrom<3,rep2="list(");
  if(listfrom==1,rep1="list(");
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
  out=replace(out,"c(1)","[1]");//17.10.06(2lines)
  out=replace(out,"c(2)","[2]");
  out;
);

RSslash(str):=(  //17.09.24
  regional(tmp);
  tmp=replace(str,"\","\\");
//  tmp=replace(tmp,"\\\\","\\");
  tmp;
);

Rform(list):=(
  regional(plotlist,comp,pos,out,strL,tmp,tmp1,tmp2,tmp3,Nj);
  out=list;
  out=replace(out,"[[[","list([[");
  out=replace(out,"[","c(");
  out=replace(out,"]",")");
  out=replace(out,".xy","");
  out=replace(out,".x","[1]");
  out=replace(out,".y","[2]");
  out;
);

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
    ); // 16.11.16upto
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

IftoR(strorg):=( // 17.09.16
  regional(str,ifL,ppL,cpL,kk,Lv,no,out,prev,
      tmp,tmp1,tmp2);
  str=replace(strorg,LFmark,"");
  ifL=Indexall(str,"if(");
  ifL=apply(ifL,#+2);
  if(length(ifL)>0,
    ppL=Bracket(str,"()");
    tmp2=[];
    forall(ifL,kk,
      tmp=select(ppL,#_1==kk);
      tmp1=select(ppL,#_2==-tmp_1_2);
      tmp2=append(tmp2,[kk,tmp1_1_1,tmp_1_2]);
    );
    ifL=tmp2;
    cpL=[];
    forall(1..(length(str)),kk,
      if(substring(str,kk-1,kk)==",",
        tmp1=select(ifL,#_1<kk & kk<#_2);
        Lv=max(apply(tmp1,#_3));
        tmp=select(cpL,#_2==Lv);
        no=length(tmp)+1;
        cpL=append(cpL,[kk,Lv,no]);
      );
      if(contains(ifL,kk),
        tmp1=select(ifL,#_1<kk & kk<#_2);
        Lv=max(apply(tmp1,#_3));
        tmp=select(cpL,#_2==Lv);
        no=length(tmp)+1;
        cpL=append(cpL,[kk,Lv,no]);
      );
    );
    forall(ifL,
      str_(#_2)="}";
    );
    out="";
    prev=0;
    forall(cpL,
      out=out+substring(str,prev,#_1-1);
      prev=#_1;
      if(#_3==1,out=out+"){");
      if(#_3==2,out=out+"}else{");
    );
    out=out+substring(str,prev,length(str));
  );
);

FortoR(strorg):=( // 17.09.16
  regional(str,frL,ppL,cpL,kk,Lv,no,out,prev,
      tmp,tmp1,tmp2);
  str=replace(strorg,LFmark,"");
  frL=Indexall(str,"forall(");
  frL=apply(frL,#+6);
  if(length(frL)>0,
    ppL=Bracket(str,"()");
    tmp2=[];
    forall(frL,kk,
      tmp=select(ppL,#_1==kk);
      tmp1=select(ppL,#_2==-tmp_1_2);
      tmp2=append(tmp2,[kk,tmp1_1_1,tmp_1_2]);
    );
    frL=tmp2;
    cpL=[];
    forall(1..(length(str)),kk,
      if(substring(str,kk-1,kk)==",",
        tmp1=select(frL,#_1<kk & kk<#_2);
        Lv=max(apply(tmp1,#_3));
        tmp=select(cpL,#_2==Lv);
        no=length(tmp)+1;
        cpL=append(cpL,[kk,Lv,no]);
      );
      if(contains(frL,kk),
        tmp1=select(frL,#_1<kk & kk<#_2);
        Lv=max(apply(tmp1,#_3));
        tmp=select(cpL,#_2==Lv);
        no=length(tmp)+1;
        cpL=append(cpL,[kk,Lv,no]);
      );
    );
    forall(frL,
      str_(#_2)="}";
    );
    out="";
    prev=0;
    forall(cpL,
      if(#_3==1,
        tmp1=substring(str,prev,#_1-1);
        tmp=indexof(tmp1,"(");
        tmp1=substring(tmp1,tmp,length(tmp1));
        tmp1=replace(tmp1,"..",":");
      );
      if(#_3==2,
        tmp2=substring(str,prev,#_1-1);
        out=out+"for("+tmp2+" in "+tmp1+"){";
      );
      prev=#_1;
    );
    out=out+substring(str,prev,length(str));
  );
);

Deffun(name,bodylist):=(
//help:Deffun("f(x)",["regional(y)","y=x^2*(x-3)","y"]);
  regional(funstr,tmp,tmp1,str,Pos);
  funstr=name+":=(";
  forall(bodylist,
    funstr=funstr+#+";";
  );
  funstr=funstr+");";
  parse(funstr);
  tmp=indexof(name,"("); // 17.09.15from
  str=substring(name,0,tmp-1)+"<-function(";
  str=str+substring(name,tmp,length(name))+"{";
  forall(1..(length(bodylist)-1),
    tmp1=bodylist_#;
    tmp1=replace(tmp1,LFmark,"");
    tmp1=replace(tmp1," ","");
    Pos=indexof(tmp1,"regional")+indexof(tmp1,"local");
    if(Pos==0,
      tmp=RSform(tmp1);
      if(indexof(tmp,"if(")>0,
        tmp=iftoR(tmp);
      );
      if(indexof(tmp,"forall(")>0, 
        tmp=FortoR(tmp);
      ); 
      str=str+tmp+";";
    );
  );
  str=str+"return("+bodylist_(length(bodylist))+")}";
  //17.09.15upto
  FUNLIST=append(FUNLIST,str);
);

Windispg():=(
  regional(Nj,Nk,Dt,Vj,tmp,tmp1,tmp2,opcindy);
  gsave();
  layer(KETPIClayer);
  forall(GCLIST,Nj,
    if(isstring(Nj_1),Dt=parse(Nj_1),Dt=Nj_1);  // 11.17
    if(islist(Dt) & length(Dt)>0,  // 12.19,12.22
      tmp=MeasureDepth(Dt);
      if(tmp==1,Dt=[Dt]);
      opcindy=Nj_3;
      if(Nj_2<0,tmp1=0,tmp1=Nj_2);
      if(tmp1<10,
        forall(Dt,Nk,
//        tmp2=apply(Nk,if(ispoint(#),Lcrd(#),#));
//        tmp2=apply(tmp2,Pcrd(#));
          tmp2=Nk;    // 14.12.04
          if(length(Nk)>1,
            tmp="connect("+textformat(tmp2,5)+
             ",dashtype->"+text(tmp1)+",linecolor->"+KCOLOR+opcindy+")";
            parse(tmp);
          ,
            if(length(Nk)==1,
              tmp="draw("+text(tmp2_1)+opcindy+")"; // 14.12.31
              parse(tmp);
            );
          );
        );
      );
    );
  );
//  if(ADDAXES=="1", // 16.10.08from
//    draw([XMIN,0],[XMAX,0],color->[0,0.2,0]);
//    draw([0,YMIIN],[0,YMAX],color->[0,0.2,0]);
//    Letter([[XMAX,0],"e","x",[0,YMAX],"n","y"]);
//    Letter([[0,0],"sw","O"]);
//  ); // 16.10.08upto
  grestore(); 
  layer(0);
);

Windispg(pltdata):=(
  regional(pdata,Nj,Nk,Dt,tmp,tmp1,tmp2,opcindy);
  gsave();
  layer(KETPIClayer);
  if(!islist(pltdata),tmp=[pltdata],tmp=pltdata);
  pdata=select(GCLIST,contains(tmp,#_1));
  forall(pdata,Nj,
    if(isstring(Nj_1),Dt=parse(Nj_1),Dt=Nj_1);  // 11.17
    if(islist(Dt) & length(Dt)>0,  // 12.19,12.22
      tmp=MeasureDepth(Dt);
      if(tmp==1,Dt=[Dt]);
      opcindy=Nj_3;
      if(Nj_2<0,tmp1=0,tmp1=Nj_2);
      if(tmp1<10,
        forall(Dt,Nk,
          tmp2=Nk;    // 14.12.04
          if(length(Nk)>1,
            tmp="connect("+textformat(tmp2,5)+ // 15.05.11
             ",dashtype->"+text(tmp1)+
             ",linecolor->"+KCOLOR+opcindy+")";
            parse(tmp);
          ,
            if(length(Nk)==1,
              tmp="draw("+text(tmp2_1)+opcindy+")"; // 14.12.31
              parse(tmp);
            );
          );
        );
      );
    );
  );
  grestore(); 
  layer(0);
);

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
  regional(Plist,Pos,GrL,str,tmp,tmp1,tmp2,cmd);
  println("Write to R "+filename);
  Plist=[];
  Pnamelist=[];
  forall(remove(allpoints(),[SW,NE]),
    tmp=Lcrd(#);
    tmp1=format(re(tmp_1),6);// 15.02.05
    tmp2=format(re(tmp_2),6);
    tmp=#.name+"="+"c("+tmp1+","+tmp2+");";
	tmp=tmp+"Assignadd('"+#.name+"',"+#.name+")";
    Plist=append(Plist,tmp);
  );
  SCEOUTPUT = openfile(filename);
  tmp=Datetime();
  println(SCEOUTPUT,"# date time="+tmp_1+" "+tmp_2);
  if(isstring(CindyPathName), // 16.12.25from
    if(length(CindyPathName)>0,
      println(SCEOUTPUT,
           "# path file="+CindyPathName+" "+CindyFileName+".cdy");
    ,
      println(SCEOUTPUT,"");
    );
  ,
    println(SCEOUTPUT,"");
  );
  tmp=replace(Dirwork,"\","/"); //17.09.24
  println(SCEOUTPUT,"setwd('"+tmp+"')"); //17.09.24
//  if((indexof(PathT,"pdflatex")>0)%(indexof(PathT,"lualatex")>0),
//    Libname=Libname+"2e";
//  ); //  17.10.07removed
  tmp=replace(Libname,"\","/"); //17.09.24from
//  println(SCEOUTPUT,"load('"+tmp+".Rdata')"); //17.10.11
  println(SCEOUTPUT,"source('"+tmp+".r')");//temporary
  if((indexof(PathT,"pdflatex")>0)%(indexof(PathT,"lualatex")>0),
       //  17.10.07added
    tmp=replace(tmp+"_rep2e","\","/");
    println(SCEOUTPUT,"source('"+tmp+".r')");
  ); 
  println(SCEOUTPUT,"Ketinit()");
  println(SCEOUTPUT,"cat(ThisVersion,'\n')"); 
  println(SCEOUTPUT,"Fnametex='"+Fnametex+"'");
  println(SCEOUTPUT,"FnameR='"+FnameR+"'");
  println(SCEOUTPUT,"Fnameout='"+Fnameout+"'");
  println(SCEOUTPUT,"arccos=acos; arcsin=asin; arctan=atan");
  println(SCEOUTPUT,"");
  forall(COM0thlist,
    if(indexof(#,"Texcom")==0, //17.09.22
      println(SCEOUTPUT,RSform(#));
    ,
      println(SCEOUTPUT,#);
    );
  );
  println(SCEOUTPUT,
     "Setwindow(c("+XMIN+","+XMAX+"), c("+YMIN+","+YMAX+"))");
  forall(Plist,
    println(SCEOUTPUT,#);
  );
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
    print(SCEOUTPUT,tmp+"="+tmp1+";"); //17.09.22
//    tmp=substring(tmp,0,length(tmp)-1);
    println(SCEOUTPUT,"Assignadd('"+tmp+"',"+tmp+")");
  );
  forall(FUNLIST,
    println(SCEOUTPUT,#);
  );
  forall(GLIST,
    println(SCEOUTPUT,RSform(#));
  );
  tmp=text(Pnamelist);
  tmp=replace(tmp,"[","list(");
  Pnamelist=replace(tmp,"]",")");
  println(SCEOUTPUT,"PtL="+Pnamelist+";");
  tmp=select(GCLIST,#_2==-1);
  GrL=apply(tmp,#_1);
  tmp=text(GrL);
  tmp=replace(tmp,"[","list(");
  tmp=replace(tmp,"]",")");
  println(SCEOUTPUT,"GrL="+tmp);
  tmp1="";
  if(length(tmp1)>0,
    tmp1="WriteOutData(Fnameout"+tmp1+");";
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
  println(SCEOUTPUT,"# Windisp(GrL)");
  println(SCEOUTPUT,"");
  println(SCEOUTPUT,"if(1==1){");
  println(SCEOUTPUT,"");
  tmp=replace(Dirwork,"\","/"); //17.10.28(3lines)
  tmp="Openfile('"+tmp+pathsep()+Fnametex+"','"+ULEN+"'";
  tmp=tmp+",'Cdy="+loaddirectory+text(curkernel());
  tmp=replace(tmp,"\","\\");
  println(SCEOUTPUT,tmp+"')");
  forall(COM2ndlist,
    if(indexof(#,"Texcom")==0, //17.09.22
      println(SCEOUTPUT,RSform(#));
    ,
      println(SCEOUTPUT,#);
    );
  );
  if(length(GrL)>0,
    println(SCEOUTPUT,"  Drwline(GrL)");
  );
  println(SCEOUTPUT,"Closefile('"+ADDAXES+"')");
  println(SCEOUTPUT,"");
  println(SCEOUTPUT,"}");
  if(shchoice=="sh",
    println(SCEOUTPUT,"");
    println(SCEOUTPUT,"quit()");
  ,
    println(SCEOUTPUT,"");
    println(SCEOUTPUT,"#quit()");
  );
  closefile(SCEOUTPUT);
); //17.09.17upto

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
//help:ExtractData(1,"ha1");
  regional(dlist,tmp,tmp1,tmp2,tmp3,File,Ltype,Noflg,opstr,opcindy);
  tmp=Divoptions(options);
  Ltype=tmp_1;
  Noflg=tmp_2;
  opstr=tmp_(length(tmp)-1);
  opcindy=tmp_(length(tmp));
  tmp1=[];
  forall(1..length(GOUTLIST),
    if(contains(GOUTLIST_#_2,name),
      tmp1=append(tmp1,#);
    );
  );
  if(length(tmp1)==0,
    println(varname+" not found");
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
    tmp3=[ //17.09.18
	  "Tmpout=ReadOutData("+Dq+File+Dq+")"
    ];
    GLIST=concat(GLIST,tmp3);
  );
  if(Noflg<2,
    if(isstring(Ltype),
      Ltype=GetLinestyle(text(Noflg)+Ltype,name);
    ,
      if(Noflg==1,Ltype=0);
    );
    GCLIST=append(GCLIST,[name,Ltype,opcindy]);
  );
  tmp2;
);

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

ReadOutData():=ReadOutData(Fnameout);
ReadOutData(filename):=ReadOutData("",filename);  //16.03.07
ReadOutData(pathorg,filenameorg):=(
//help:ReadOutData();
//help:Readoutdata();
//help:ReadOutData("file.txt");
//help:Readoutdata("file.txt");
//help:ReadOutData("/datafolder","file.txt");
//help:Readoutdata("/datafolder","file.txt");
  regional(path,filename,varname,varL,ptL,pts,tmp,tmp1,tmp2,tmp3,tmp4,
     nmbr,cmdall,cmd,cmdorg,outdt,goutdt);
  path=pathorg;   //16.03.07 from
  if(length(path)>0,
    setdirectory(path);
    if(indexof(path,"\")>0,tmp1="\",tmp1="/");
    tmp=substring(path,length(path)-1,length(path));
    if(tmp!=tmp1,path=path+tmp1);
  );   //16.03.07 upto
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
            tmp=apply(ptL,textformat(#,6));
          ,
            tmp="[";
            forall(ptL,tmp1,
              tmp=tmp+apply(tmp1,textformat(#,6))+",";
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
      tmp=apply(ptL,textformat(#,6));
    ,
      tmp="[";
      forall(ptL,tmp1,
        tmp=tmp+apply(tmp1,textformat(#,6))+",";
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
  println(varL);
  varL;
);

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
    if(MeasureDepth(Gdata)==1,Gdata=[Gdata]);
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
  if(flg==0,  // 17.10.13(Norbert)
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
  );//16.11.22upto
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
  );// 16.09.09upto
  println(SCEOUTPUT,tmp); // 16.07.21upto
  println(SCEOUTPUT,"exit 0");
  closefile(SCEOUTPUT);
  setdirectory(Dirwork);
);

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
  fname=Dirwork;
  tmp=indexof(fname,":");
  if(tmp>0,
    drive=substring(Dirwork,0,tmp);
    fname=substring(Dirwork,tmp,length(Dirwork));
    println(SCEOUTPUT,drive);
  );
  println(SCEOUTPUT,"cd "+Dq+fname+Dq);// 15.07.16
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
  if(flg==0,  // 17.10.13(Norbert)
    tex=PathT;
    path="";
  );
  if(indexof(flow,"r")>0,
    tmp=Dq+PathR+"\R"+Dq+" --vanilla --slave < "+Fhead+".r";
      // 17.09.14
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
  );//16.11.22upto
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
  ADDPACK=concat(ADDPACK,packL); //17.06.25upto
);

Viewtex():=(
  regional(texfile,tmp,tmp1,sep);
  texfile=Fhead+"main";
//  if(iswindows(),sep="\",sep="/"); // 17.04.07
//  sep="/";
  SCEOUTPUT=openfile(texfile+".tex");
  tmp="\documentclass{article}"; // 16.06.09from
  if(indexof(PathT,"platex")>0,
    tmp=replace(tmp,"article","jarticle");
    if(indexof(PathT,"uplatex")>0, //17.08.13from
      tmp=replace(tmp,"jarticle","ujarticle");
    );//17.08.13upto
  ); // 16.06.09upto
  println(SCEOUTPUT,tmp);
  if((indexof(PathT,"pdflatex")>0)%(indexof(PathT,"lualatex")>0) ,
          //16.11.23,12.16
    if(indexof(PathT,"pdflatex")>0,
      println(SCEOUTPUT,"\usepackage[pdftex]{pict2e}");//16.11.24
    ,
      println(SCEOUTPUT,"\usepackage{pict2e}");//16.12.16
      println(SCEOUTPUT,"\usepackage{luatexja}");//16.12.18
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
    tmp=replace(Dirhead,"\","/");
    tmp=replace(tmp,"scripts","tex/latex");
    if(isexists(tmp,""),
      println(SCEOUTPUT,"\usepackage{ketpic,ketlayer}");
    ,
      tmp=replace(Dirhead+"/ketpicstyle","\","/");
      println(SCEOUTPUT,"\usepackage{"+tmp+"/ketpic}");
      println(SCEOUTPUT,"\usepackage{"+tmp+"/ketlayer}");
    );
  );//17.10.30upto
  println(SCEOUTPUT,"\usepackage{amsmath,amssymb}");
  println(SCEOUTPUT,"\usepackage{graphicx}");
  println(SCEOUTPUT,"\usepackage{color}");
  forall(ADDPACK, // 16.05.16from
    println(SCEOUTPUT,"\usepackage"+#); //17.05.25
  );// 16.05.16upto
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

Savecmdlist(cmdlist,cmdfile):=(
  SCEOUTPUT=openfile(cmdfile+".cs");
  forall(cmdlist,
    println(SCEOUTPUT,#);
  );
  closefile(SCEOUTPUT);
);

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
  mar=apply(mar,if(length(#)==0,5,#));//16.11.08upto
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
    );//17.08.13upto
  );
  FigPdfList=append(FigPdfList,tmp); // 16.06.09upto
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
  );//17.11.05upto
  FigPdfList=append(FigPdfList,
    "\usepackage{amsmath,amssymb}");
  FigPdfList=append(FigPdfList,
    "\usepackage{graphicx,color}");
  forall(ADDPACK, // 16.05.16from
    tmp1="\usepackage"+#; //17.07.10
    FigPdfList=append(FigPdfList,tmp1);  // 16.09.05upto
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

Makehelplist(libname):=(
  regional(cmdall,cmd,flg,lev,tmp,tmp1,out);
  tmp=load(libname);
  cmdall=tokenize(tmp,"//help:");
  cmdall=select(cmdall,substring(#,1,3)!=");");
  flg=0;
  forall(1..3,
    if(flg==0,
      if(substring(cmdall_#,0,7)=="start()",
        cmdall=cmdall_((#+1)..length(cmdall));
        flg=1;
      );
    );
  );
  flg=0;
  tmp=length(cmdall);
  forall(0..2,
    if(flg==0,
      if(substring(cmdall_(tmp-#),0,5)=="end()",
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
  ketfiles=concat(ketfiles,tmp);// 15.11.05 upto
  tmp1=[];
  forall(ketfiles,
    tmp=Makehelplist(#);
    tmp1=concat(tmp1,tmp);
  );
  if(!islist(HLIST), // 16.12.31from
    HLIST=sort(tmp1);
  ,
    HLIST=sort(concat(HLIST,tmp1));
  ); // 16.12.31upto
  setdirectory(Dirwork);
);


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
  );//17.11.20upto
  if(isexists(dir,""), // 16.12.20
    Changework(dir);
    println(makedir(dir,"fig"));//17.11.23
    tmp=dir+pathsep()+"fig";  //17.04.16from
    Changework(tmp);// 17.02.19upto
  ,
    println(dir+ " not exists");
  );
);

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

Setslidehyper():=Setslidehyper(["cl=true,lc=blue,fc=blue",125,70,1]);
// 16.12.31from
Setslidehyper(Arg):=(
  if(isstring(Arg),
    if(length(Arg)==0, //17.01.29from
      Setslidehyper();
    ,
      Setslidehyper(Arg,[]);
    );//17.01.29upto
  ,  
    Setslidehyper("dvipdfmx",Arg);
  );
);
Setslidehyper(driver,options):=(
//help:Setslidehyper();
//help:Setslidehyper("dvipdfmx",["cl=true,lc=blue,fc=blue",125,70,1]);
  regional(reL,stL,tmp,tmp1,tmp2,str,reL);
  str="";
  reL=[];
  forall(options,
    if(isstring(#),
      str=#
    ,
      reL=append(reL,#);
    );
  );
  if(length(str)>0,str=","+str);
  tmp1="";
  if(length(driver+str)>0,
    tmp1="["+driver+str+"]";
  );
  tmp1=replace(tmp1,"cl=","colorlinks=");
  tmp1=replace(tmp1,"lc=","linkcolor=");
  tmp1=replace(tmp1,"fc=","filecolor=");
  tmp1=replace(tmp1,"uc=","urlcolor=");
  Addpackage(tmp1+"{hyperref}");
  LinkPosH=125;
  LinkPosV=70;
  LinkSize=1;
  if(length(reL)>0,LinkPosH=reL_1);
  if(length(reL)>1,LinkPosV=reL_2);
  if(length(reL)>2,LinkSize=max(reL_3,0.1)); // 17.07.31
);

Settitle(cmdL):=Settitle("slide0",cmdL,[]);
Settitle(Arg1,Arg2):=(
  if(isstring(Arg1),
    Settitle(Arg1,Arg2,[]);
  ,
    Settitle("slide0",Arg1,Arg2);
  );
);
Settitle(name,cmdL,options):=(
//help:Settitle(cmdL);
//help:Settitle(name,cmdL);
//help:Settitle(options=["Layery=0","Color=blue"]);
  regional(tmp,tmp1,tmp2,eqL,layery,color,size,font);
  TitleName=name;
  layery="0";
  color="blue";
  size="\Large";
  font="\bf";
  tmp=Divoptions(options);
  eqL=tmp_5;
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

Maketitle():=(
  if(!isstring(TitleName), //17.04.13from
    drawtext(mouse().xy,"Settitle not defined",
      size->24,color->[1,0,0]);
  , //17.04.13upto
    Maketitle(TitleName);
  );
);
Maketitle(name):=(
//help:Maketitle();
  regional(texfile,texmain,tmp,tmp1,sep);
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
    );//17.08.13upto
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
  );//17.11.01upto
  println(SCEOUTPUT,"\usepackage{amsmath,amssymb}");
  println(SCEOUTPUT,"\usepackage{bm,enumerate}");
  if((indexof(PathT,"pdflatex")>0)%(indexof(PathT,"lualatex")>0),
    println(SCEOUTPUT,"\usepackage{graphicx}");
  ,
    println(SCEOUTPUT,"\usepackage[dvipdfmx]{graphicx}");
  );
  println(SCEOUTPUT,"\usepackage[usenames]{xcolor}");
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
);

Repeatsameslide(repeatflg,sestr,addedL):=(
  regional(seL,flg1,ss,nn,nrep,tmp,tmp1,tmp2,tmp3,str,j,k);
  // global RepeatList, SCEOUTPUT
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
        repeat(10,
          tmp1=Indexall(str,"{\color");
          if(length(tmp1)>0,
            tmp2=Indexall(str,"}");
            tmp=select(tmp2,tmp1_1<#);
            tmp=substring(str,tmp1_1,tmp_1);
            str=replace(str,tmp+" ","");
            str=replace(str,tmp,"");
          );
        );//17.05.28upto
        if(contains(seL,1),
          if(substring(str,0,1)!="%", 
            if(NonThinFlg==0,
              if(!contains(["\begi","\end{"],substring(str,0,5)),//17.01.15
                println(SCEOUTPUT,"{\color[cmyk]{\thin,\thin,\thin,\thin}");//17.08.23
                println(SCEOUTPUT,str);
                println(SCEOUTPUT,"}%");
              ,
                println(SCEOUTPUT,str);
              );
            );
            if(NonThinFlg==1,
              if(!contains(["\begi","\end{"],substring(str,0,5)),//17.01.15
                println(SCEOUTPUT,"{\color[cmyk]{\thin,\thin,\thin,\thin}");//17.08.23
              );
              println(SCEOUTPUT,str);
            );
            if(NonThinFlg==2,
              println(SCEOUTPUT,str);
              if(!contains(["\begi","\end{"],substring(str,0,5)),//17.01.15
                println(SCEOUTPUT,"}%");
              );
            );
            seL=remove(seL,[1]);
          );
        );
        if(substring(ss,0,1)!="%", //16.01.04
          forall(1..(length(seL)),nn,
            tmp=seL_nn;
            if(NonThinFlg==0,
              tmp1="{\color[cmyk]{\thin,\thin,\thin,\thin}";//17.08.23
              tmp1=[tmp1,str,"}%"];
            );
            if(NonThinFlg==1,
              tmp1="{\color[cmyk]{\thin,\thin,\thin,\thin}";//17.08.23
              tmp1=[tmp1,str];//17.01.08upto
            );
            if(NonThinFlg==2,
              tmp1=[str,"}%"];
            );
            RepeatList_tmp=concat( RepeatList_tmp,tmp1);
          );
        );
      );//16.01.05upto
    );
  );//16.12.05upto
);

Presentation(texfile):=Presentation(texfile,texfile);
Presentation(texfile,txtfile):=(
//help:Presentation(texfile,txtfile);
  regional(file,flgL,flg,verbflg,slideL,ns,slideorgL,wall,sld,slidecmd,tmp,tmp0,tmp1,
     tmp2,tmp3,tmp4,tmp5,newoption,top,repeatflg,nrep,nrepprev,,repstr,
     sestr,npara,paradt,parafiles,hyperflg,paractr,
     letterc,boxc,shadowc,mboxc,sep);
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
  tmp=load(tmp1);
  tmp=replace(tmp,"////","||||");// 16.05.11, 06.24(reactivated)
  slideL=tokenize(tmp,"//");
  slideorgL=slideL; // 16.07.11
  slideL=apply(slideL,Removespace(#));
  tmp=select(1..length(slideL),length(slideL_#)>0); // 16.07.11from
  slideL=apply(tmp,slideL_#);
  slideorgL=apply(tmp,slideorgL_#);
//  slideL=select(slideL,length(#)>0); // 16.07.11upto
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
  ); // 16.06.09upto
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
    if(substring(tmp3_1,0,1)!="\" & indexof(tmp3_1,"=")==0, 
      wall=tmp3_1;
      tmp3=tmp3_(2..length(tmp3));
    );
  );//16.06.25upto
  tmp="%%% "+tmp1+" "+txtfile;// 16.06.09from
  println(SCEOUTPUT,tmp);
  tmp="\documentclass[landscape,10pt]{article}"; 
  if(indexof(PathT,"platex")>0,
    tmp=replace(tmp,"article","jarticle");
    if(indexof(PathT,"uplatex")>0, //17.08.13from
      tmp=replace(tmp,"jarticle","ujarticle");
    );//17.08.13upto
  );
  println(SCEOUTPUT,tmp);// 16.06.09from
  tmp=select(1..(length(tmp3)),indexof(tmp3_#,"\usepackage")>0);//17.06.18from
  forall(tmp,
    println(SCEOUTPUT,tmp3_#);
  );
  tmp=remove(1..(length(tmp3)),tmp);
  tmp3=tmp3_tmp;//17.06.18upto
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
  );// 17.04.08upto
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
  );//17.04.08upto
  println(SCEOUTPUT,"\usepackage{amsmath,amssymb}");
  println(SCEOUTPUT,"\usepackage{bm,enumerate}");
  if((indexof(PathT,"pdflatex")>0)%(indexof(PathT,"lualatex")>0),
    println(SCEOUTPUT,"\usepackage{graphicx}");
  ,
    println(SCEOUTPUT,"\usepackage[dvipdfmx]{graphicx}");
  );
//  println(SCEOUTPUT,"\usepackage[usenames]{color}");
//  println(SCEOUTPUT,"\usepackage{color}");//17.06.14
  println(SCEOUTPUT,"\usepackage{xcolor}");//17.07.31
  letterc=[0.98,0.13,0,0.43]; boxc=[0,0.32,0.52,0];
  shadowc=[0,0,0,0.5]; mboxc="yellow";
//  if(!islist(SlideColorList), //17.03.02from
//    SlideColorList=[letterc,boxc,boxc,boxc,shadowc,shadowc,6,1.3,
//                  letterc,mboxc,mboxc,mboxc,62,2,letterc];
//  , //17.03.02upto
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
      );//17.01.07upto
      SlideColorList_#="slidecolor"+tmp4_#;
    );
  );
//  ); //17.03.02
  println(SCEOUTPUT,"\def\setthin#1{\def\thin{#1}}");//17.08.23
  println(SCEOUTPUT,"\setthin{"+text(ThinDense)+"}");//17.08.23
  forall(ADDPACK,// 16.06.09from
//    if(indexof(#,"[")==0,  // 16.09.05from
//      println(SCEOUTPUT,"\usepackage{"+#+"}");
//    ,
      println(SCEOUTPUT,"\usepackage"+#);  //17.07.10
//    );
  );// 16.06.09upto
  tmp=select(ADDPACK,indexof(#,"{hyperref}")>0);//16.12.31from
  if(length(tmp)>0,
    hyperflg=1;
  ,
    hyperflg=0; //16.12.31upto
  );
  forall(tmp3,
    println(SCEOUTPUT,#);
  );
  if(indexof(PathT,"platex")>0,tmp="\ketmarginJ",tmp="\ketmarginE"); // 16.06.09
  println(SCEOUTPUT,tmp);
  println(SCEOUTPUT,"\ketslideinit");
  println(SCEOUTPUT,"");
  forall(tmp, // 15.07.21
    if(substring(#,0,1)=="\", println(SCEOUTPUT,#));
  );
  if(!isstring(PageStyle),PageStyle="headings");//17.04.09
  println(SCEOUTPUT,"\pagestyle{"+PageStyle+"}");//17.04.09
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
    ); // 16.11.11upto
  );
  println(SCEOUTPUT,"\def\mainslidetitley{22}");
  forall(1..14, //16.12.22from
    tmp=SlideColorList_#;
    if(!isstring(tmp),tmp=text(tmp));
    if(length(tmp)>0,
      tmp="\def"+slidecmd_#+"{"+tmp+"}";
      println(SCEOUTPUT,tmp);
    );
  );//16.12.22upto
  println(SCEOUTPUT,"");
  println(SCEOUTPUT,"\color{"+SlideColorList_(15)+"}");
  println(SCEOUTPUT,BodyStyle);//17.01.07
  println(SCEOUTPUT,"\thispagestyle{empty}");//17.01.29
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
    sld=removespace(slideL_ns); // 16.06.28
    sestr="";
    if((substring(sld,0,1)=="%") & (substring(sld,0,2)!="%%"), // 17.06.23
      Repeatsameslide(repeatflg,"",[slideL_ns]);
      if(repeatflg>0,
        tmp=indexof(sld,"]::");
        if(tmp>0,
          if(substring(sld,1,2)!="%",//17.05.31
            if(substring(sld,1,5)=="thin", ThinFlg=1); // 17.05.28
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
        );//17.01.03upto
        repeatflg=1;
        if(length(tmp5)>0,
          nrep=parse(tmp5);
          tmp=[];
          if(length(wall)>0,
            tmp=["","\input{fig/"+wall+".tex}"];
          );
          tmp=concat(tmp,["","\sameslide"+NewSlideOption,"","\vspace*{18mm}",""]);
          RepeatList=apply(1..nrep,if(#==1,[],tmp));
        );
        if(sestr=="",flg=1);
        tmp=indexof(sld,",");//17.01.03from
        if(tmp>0,
          sld="%"+substring(sld,tmp,length(sld));
          if(indexof(sld,"=")==0,sld=sld+"=");
        );//17.01.03upto
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
              );//17.01.29upto
              parafiles=select(parafiles,indexof(#,".tex")>0);
              if(indexof(paradt_4,"\input")==0,paradt_4="\"+paradt_4);//16.12.17
            );
            if(indexof(paradt_4,"include")>0,
              parafiles=select(parafiles,indexof(#,".pdf")>0);
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
            tmp=concat(tmp,["","\sameslide"+NewSlideOption,"","\vspace*{18mm}",""]);
            RepeatList=apply(1..nrep,if(#==1,[],tmp));
          );
        );
        forall(1..nrep, //16.12.28
          tmp4=[]; //16.12.31from
          if(hyperflg>0,
            tmp4=["\hypertarget{para"+text(paractr)+"pg"+text(#)+"}{}"];
          );//16.12.31upto
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
            if(#>1,tmp=tmp1+text(1),tmp=tmp2);
            tmp3=[text(LinkPosH-29*LinkSize)+"}"+tmp+"}{\fbox{\Ctab{"
                  +text(2.5*LinkSize)+"mm}{\scalebox{"+text(LinkSize)
                  +"}{\scriptsize $\mathstrut|\!\lhd$}}}}}"];
            if(#>1,tmp=tmp1+text(max(#-3,1)),tmp=tmp2);
            tmp3=append(tmp3,
                text(LinkPosH-24*LinkSize)+"}"+tmp+"}{\fbox{\Ctab{"
                  +text(2.5*LinkSize)+"mm}{\scalebox{"+text(LinkSize)
                  +"}{\scriptsize $\mathstrut\!\! \lhd\!\!\lhd\!$}}}}}");
            if(#>1,tmp=tmp1+text(#-1),tmp=tmp2);
            tmp3=append(tmp3,
               text(LinkPosH-17*LinkSize)+"}"+tmp+"}{\fbox{\Ctab{"
                  +text(4.5*LinkSize)+"mm}{\scalebox{"+text(LinkSize)
                  +"}{\scriptsize $\mathstrut\!\!\lhd\!\!$}}}}}");
            tmp="{"+text(LinkPosV)+"}{\hyperlink{para";
            tmp2=tmp+text(paractr+1)+"pg"+text(1);
            if(#<nrep,tmp=tmp1+text(#+1),tmp=tmp2);
            tmp3=append(tmp3,
               text(LinkPosH-10*LinkSize)+"}"+tmp+"}{\fbox{\Ctab{"
                  +text(4.5*LinkSize)+"mm}{\scalebox{"+text(LinkSize)
                  +"}{\scriptsize $\mathstrut\!\rhd\!$}}}}}");
            if(#<nrep,tmp=tmp1+text(min(#+3,nrep)),tmp=tmp2);
            tmp3=append(tmp3,
               text(LinkPosH-5*LinkSize)+"}"+tmp+"}{\fbox{\Ctab{"
                  +text(2.5*LinkSize)+"mm}{\scalebox{"+text(LinkSize)
                  +"}{\scriptsize $\mathstrut\!\!\rhd\!\!\rhd\!$}}}}}");
            if(#<nrep,tmp=tmp1+text(nrep),tmp=tmp2);
            tmp3=append(tmp3,
               text(LinkPosH)+"}"+tmp+"}{\fbox{\Ctab{" // 17.01.19
                  +text(2.5*LinkSize)+"mm}{\scalebox{"+text(LinkSize)
                  +"}{\scriptsize $\mathstrut \!\rhd\!\!|$}}}}}"); 
            tmp3=apply(tmp3,tmp,"\putnotew{"+tmp);
            tmp4=concat(tmp4,tmp3);// 17.01.12uptor
            tmp="\putnotew{"+text(LinkPosH)+"}{"+text(LinkPosV+6)+"}";//17.10.21from
            tmp=tmp+"{\scriptsize\color{black} "+text(#)+"/"+text(nrep)+"}";
            tmp4=append(tmp4,tmp);//17.10.21upto
          );
          tmp4=concat(tmp4,["\end{layer}",""]);//16.12.31upto
          Repeatsameslide(repeatflg,text([#]),tmp4);
        );
      );
    );
    if(substring(sld,0,2)=="%%", //17.06.23from
      println(SCEOUTPUT,sld);
      flg=1;
    ); //17.06.23upto
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
      ); // 16.06.28upto
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
          );// 16.11.09upto
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
        Repeatsameslide(repeatflg,sestr,[tmp,"","\vspace*{18mm}",""]);
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
        println(SCEOUTPUT,"");
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
      ); //16.06.28upto
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
      if(flg==0&tmp1=="end",
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
        ); // 16.06.28upto
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
      ); // 16.06.28upto
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
    println(SCEOUTPUT,"");
  );
  println(SCEOUTPUT,"");
  println(SCEOUTPUT,"\end{document}");
  closefile(SCEOUTPUT);
);

Mkslides():=(
  regional(sep,parent,texparentorg,tmp,tmp1,tmp2,tmp3,tmp4,flg);
  tmp4=Fhead;
  Fhead=""; 
  if(!iswindows(), //17.10.13
    Dirwork=replace(Dirwork,"\",pathsep());
    parent=replace(Dirwork+Shellparent,"\",pathsep());
  ,
    Dirwork=replace(Dirwork,"/",pathsep());
    parent=replace(Dirwork+Batparent,"/",pathsep());// 16.05.29
  );
  Dirwork=replace(Dirwork,pathsep()+"fig","");
  Setdirectory(Dirwork);
  if(length(Texmain)>0,  // 15.08.14 from
    Texparent=Texmain;
  );
  texparentorg=Texparent; //17.04.10from
  if(isstring(Slidename),  // 15.08.14 from
    Texparent=Slidename;
  );//17.04.10upto
  if(!isexists(Dirwork,Texparent+".txt"), // 17.04.12from
    drawtext(mouse().xy,Texparent+".txt not exist in "+Dirwork,
      size->24,color->[1,0,0]);
  ,  // 17.04.12upto
    Presentation(Texparent);  // 15.08.14 upto
    if(iswindows(),
      tmp2=Batparent;
      parent=replace(Dirwork+Batparent,sep+"fig","");// 16.05.29
      Makebat(Texparent,"tv"); // 16.07.21
      kc():=(
        println("kc : "+kc(parent,Dirlib,Fnametex)); // 16.06.10, 17.02.19
      );
      kc();
      Batparent=tmp2;
    ,
      tmp2=Shellparent;
      parent=replace(Dirwork+Shellparent,sep+"fig","");// 16.05.29
      Shellparent=replace(Shellparent,sep+"fig","");
      Makeshell(Texparent,"tv"); // 16.07.21
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
);

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
  regional(fin,fout,out,figflg,dirworkorg,dirtop,tmp);
  dirworkorg=Dirwork;//17.04.10from
  dirtop=replace(Dirwork,pathsep()+"fig","");
  Changework(dirtop);//17.04.10uptp
  fin=inputfile;
  if(indexof(fin,".")==0,fin=fin+".tex");
  fout=outputfile;
  if(indexof(fout,".")==0,fout=fout+".tex");
  cmdL=[
   "Dt=readLines('"+fin+"')",[],
   "num=grep('\\hypertarget',Dt,fixed=TRUE)",[],
   "Dt=Dt[setdiff(1:length(Dt),num)]",[],
   "Smain=c();Snew=c();Ssame=c()",[],
   "for(J in 1:length(Dt)){",[],
   "  Tmp=length(grep('\\mainslide',Dt[J],fixed=TRUE))",[],
   "  if(Tmp>0){Smain=c(Smain,1)}else{Smain=c(Smain,0)}",[],
   "  Tmp=length(grep('\\newslide',Dt[J],fixed=TRUE))",[],
   "  if(Tmp>0){Snew=c(Snew,1)}else{Snew=c(Snew,0)}",[],
   "  Tmp=length(grep('\\sameslide',Dt[J],fixed=TRUE))",[],
   "  if(Tmp>0){Ssame=c(Ssame,1)}else{Ssame=c(Ssame,0)}",[],
   "}",[],
   "Nnew=c();Nsame=c()",[],
   "for(J in 1:length(Dt)){",[],
   "  if((Snew[J]==1)|(Smain[J]==1)){Nnew=c(Nnew,J)}",[],
   "  if(Ssame[J]==1){Nsame=c(Nsame,J)}",[],
   "}",[],
   "Out=Dt[1:Nnew[1]]",[],
   "for(J in 2:length(Nnew)){",[],
    "  Tmp=max(Nsame[Nsame<Nnew[J]])",[],
    "  Tmp=max(c(Nsame[Tmp],Nnew[J-1]))+1",[],
    "  Out=c(Out,Dt[Tmp:Nnew[J]])",[],
   "}",[],
   "Tmp=max(c(Nsame[-1],Nnew[-1]))+1",[],
   "Out=c(Out,Dt[Tmp:length(Dt)])",[],
   "writeLines(Out,'"+fout+"',sep='\n')",[],
   "cat('////',file='resultR.txt',sep='')",[],
   "quit()",[]
  ];
  CalcbyR("out",cmdL,append(options,"Cat=n"));
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
);

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

BBdata():=Bbdata(BBTarget,0);
BBdata(fname):=Bbdata(fname,0); // 16.04.09
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
  tmp=divoptions(options);
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
    tmp1=Toupper(substring(#,0,2));
    tmp2=substring(#,tmp,length(#));
    if(tmp1=="W=",
      addop=addop+",width="+tmp2;
      options=remove(options,[#]);
    );
    if(tmp1=="H=",
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
    kcfile="kc.sh";
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
      tmp=removespace(tmp);
      tmp=tokenize(tmp," ");
      tmp1="";
      forall(tmp,
        tmp1=tmp1+Sprintf(#,2)+" ";
      );
      tmp1=removespace(tmp1)+addop;
      tmp2="\includegraphics[bb="+tmp1+"]{"+file+"}";
      println(tmp2);
    );
  );
//  setdirectory(Dirwork);
  tmp2; // 16.04.25
);

//help:end();

