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

println("ketcindylibbasic2[20190414] loaded");

//help:start();

////%Setarrow start////
Setarrow():=Setarrow([]);
Setarrow(arglist):=(
//help:Setarrow([-1,-1,-1,1,0.3]);
//help:Setarrow([size(1),angle(18),position(1),cut(0),segstyle("dr,1")]);
  regional(tmp);
  tmp=select(arglist,isreal(#));
  if(length(tmp)==0,
    println([YaSize,YaAngle,YaPosition,YaCut,YasenStyle]);
  );
  if(length(tmp)>=1,
    if((tmp_1>0),YaSize=tmp_1);
  );
  if(length(tmp)>=2,
    if((tmp_2>0)&(tmp_2<90),YaAngle=tmp_2);
   );
  if(length(tmp)>=3,
     if((tmp_3>=0)&(tmp_3<=1),YaPosition=tmp_3);
  );
  if(length(tmp)>=4,
    if((tmp_4>=0)&(tmp_4<1),YaCut=tmp_4);
  );
  tmp=select(arglist,isstring(#));
  if(length(tmp)>0,
    YasenStyle=tmp_1;
  );
  [YaSize,YaAngle,YaPosition,YaCut,YasenStyle];
);
////%Setarrow end////

////%Arrowheaddata start////
Arrowheaddata(point,direction):=Arrowheaddata(point,direction,[]);
Arrowheaddata(point,direction,options):=(
// help:Arrowheaddata(A,B);
// help:Arrowheaddata(options=[size(1),angle(18), "Coord=phy"]);
  regional(list,ookisa,hiraki,Houkou,Str,Flg,Ev,Nv,pA,pB,
       reL,eqL,coord,pP,rF,gG,Flg,Nj,Eps,scx,scy,tmp,tmp1,tmp2);
  Eps=10^(-3);
  coord="P";
  ookisa=0.2*YaSize;
  hiraki=YaAngle;
  iti=1;
  kiri=0;
  Futosa=0;
  Str=YaStyle;
  tmp=Divoptions(options);
  eqL=tmp_5; //181018from
  reL=tmp_6;
  forall(eqL,
     tmp=Strsplit(#,"=");
     tmp1=substring(tmp_1,0,1);
     tmp2=substring(tmp_2,0,1);
     if(Toupper(tmp1)=="C",
       coord=Touppera(tmp2);
     );
  ); //181018to
  forall(1..(length(reL)), //181110from
    tmp=reL_#;
    if(#==1,ookisa=ookisa*tmp);
    if(#==2,
      if(tmp<5, 
        hiraki=hiraki*tmp;
      ,
        hiraki=tmp;
      );
    );
  ); //181110to
  Flg=0;
  hiraki=hiraki*pi/180;
  if(ispoint(direction),Houkou=direction.xy); //181018
  if(isstring(direction),Houkou=parse(direction),Houkou=direction);
  if(Measuredepth(Houkou)==2,Houkou=Houkou_1);
  if(coord=="P",//181018from
    if(ispoint(point),pP=point.xy,pP=point);
  ,
    pP=Pcrd(point);
    if(!islist(Houkou_1),
      Houkou=Pcrd(Houkou);
    ,
      Houkou=apply(Houkou,Pcrd(#)); 
    );
  );//181018to
  if(islist(Houkou_1),
    tmp=Nearestpt(pP,Houkou);
    pP=tmp_1;
    rF=floor(tmp_2);
    if(rF==1,
      if(|Ptend(Houkou)-Ptstart(Houkou)|<Eps,
        rF=Numptcrv(Houkou);
      );
    );
    gG=apply(0..10,pP+ookisa*cos(hiraki)*[cos(2*pi/10*#),sin(2*pi/10*#)]);
    Flg=0; 
    forall(1..rF,Nj,
      if(Flg==0,
        pB=Ptcrv(rF+1-Nj,Houkou);
        tmp1=apply([pP,pB],LLcrd(#));
        tmp2=apply(gG,LLcrd(#));
        tmp=IntersectcrvsPp([pP,pB],gG);
        if(length(tmp)>0,
          Houkou=pP-Pcrd(tmp_1_1);
          Flg=1;
        );
      );
    );
    if(Flg==0,
      println("Arrowhead may be too large (no intersect)");
      Flg=2;
    );
  );
  if(Flg<2,
    Ev=-1/|Houkou|*Houkou;
    Nv=[-Ev_2, Ev_1];
    if(indexof(Str,"c")>0,
      pP=pP-0.5*ookisa*cos(hiraki)*Ev;
    );
    if(indexof(Str,"b")>0,
      pP=pP-ookisa*cos(hiraki)*Ev;
    );
    pA=pP+ookisa*cos(hiraki)*Ev+ookisa*sin(hiraki)*Nv;
    pB=pP+ookisa*cos(hiraki)*Ev-ookisa*sin(hiraki)*Nv;
    list=[pA,pP,pB];
    list;
  );
);
////%Arrowheaddata end////

////%Arrowhead start////
Arrowhead(point,Houkou):=Arrowhead(point,Houkou,[]); //181018from
Arrowhead(Arg1,Arg2,Arg3):=(
  if(isstring(Arg1),
    Arrowhead(Arg1,Arg2,Arg3,[]);
  ,
    Arrowhead(text(ArrowheadNumber),Arg1,Arg2,Arg3);
  );
);
Arrowhead(nm,point,direction,optionsorg):=(//181018from
//help:Arrowhead("1",B,B-A);
//help:Arrowhead(options=[size(1),angle(18),position(1),cut(0),"Coord=P(L)"]);
//help:Arrowhead(the default is -1 for numeric option);
//help:Arrowhead(A,"gr1");
   regional(name,Ltype,Noflg,reL,opstr,opcindy,color,eqL,coord,
         options,cut,pP,Houkou,ptstr,hostr,tmp,tmp1,tmp2,list);
  name="arh"+nm; //181018
  ArrowheadNumber=ArrowheadNumber+1;
  options=optionsorg;
  tmp=Divoptions(options);
  Ltype=tmp_1;
  Noflg=tmp_2;
  reL=tmp_6;
  color=tmp_(length(tmp)-2);
  eqL=tmp_5;
  coord="P";
  forall(eqL,
     tmp=Strsplit(#,"=");
     tmp1=substring(tmp_1,0,1);
     tmp2=substring(tmp_2,0,1);
     if(Toupper(tmp1)=="C",
       coord=Toupper(tmp2);
       options=remove(options,[#]);
     );
  ); //181018to
  tmp1=[YaSize,YaAngle,YaPosition,YaCut]; //181214from
  forall(1..(length(reL)),
    if(reL_#<0, reL_#=tmp1_#);
  );  
  forall((length(reL)+1)..4,
    reL=append(reL,tmp1_#);
  );
  cut=reL_4;
  tmp=reL_(1..3);
  options=select(options,!isreal(#));
  options=concat(options,tmp); //181214to
  if(ispoint(direction),Houkou=direction.xy); //181018
  if(isstring(direction),Houkou=parse(direction),Houkou=direction);
  if(Measuredepth(Houkou)==2,Houkou=Houkou_1);
  if(coord=="P",//181018from
    if(ispoint(point),pP=point.xy,pP=point);
  ,
    pP=Pcrd(point);
    if(!islist(Houkou_1),
      Houkou=Pcrd(Houkou);
    ,
      Houkou=apply(Houkou,Pcrd(#)); 
    );
  );//181018to
  list=Arrowheaddata(pP,Houkou,options);
  if(!Inwindow(LLcrd(pP)),Noflg=2);//181018
  if(Noflg<3,
    tmp1=apply(list,LLcrd(#));
    tmp=name+"="+Textformat(tmp1,5);
    parse(tmp);
  );
  if(Noflg<2,
    if(isstring(Ltype),
      Listplot("-arh"+nm,apply(list,LLcrd(#)),concat(options,["notex","Msg=n"]));
    );
  );
  if(Noflg==0,
    tmp=Divoptions(options);
    opstr=tmp_(length(tmp)-1);
    opstr=opstr+","+Dqq("Cut="+format(cut,5));
    ptstr=Textformat(LLcrd(pP),5);
    if(isstring(direction),  //181019
      hostr=direction;
    ,
      if(!islist(Houkou_1),
        hostr=format(LLcrd(Houkou),5);
      ,
        hostr=format(apply(Houkou,LLcrd(#)),5);
      );
    );
    if((Noflg==0)&(color!=KCOLOR), //180904 //no ketjs on
      Texcom("{");Com2nd("Setcolor("+color+")");//180722
    ); //no ketjs off
    Com2nd("Arrowhead("+ptstr+","+hostr+opstr+")");
    if((Noflg==0)&(color!=KCOLOR), //180904 //no ketjs on
      Texcom("}");//180722
    ); //no ketjs off
  );
);
////%Arrowhead end////

////%Arrowdata start////
Arrowdata(ptlist):=Arrowdata(ptlist,[]); //181110from
Arrowdata(Arg1,Arg2):=(
  regional(name);
  if(isstring(Arg1),
    Arrowdata(Arg1,Arg2,[]);
  ,
    name="";
    forall(Arg1,
      if(ispoint(#),
        name=name+text(#);
      );
    );
    Arrowdata(name,Arg1,Arg2);
  );
);  //181110from
Arrowdata(nm,ptlistorg,optionsorg):=(
//help:Arrowdata("1",[A,B]);
//help:Arrowdata("1",[pt1,pt2]);
//help:Arrowdata(options=[size(1),angle(18),pos(1),cut(0),"Cutend=0,0","Coord=p/l"]);
//help:Arrowdata(optionsadded=["line"]);
  regional(options,Ltype,Noflg,name,opstr,opcindy,eqL,reL,strL,color,size,coord,
      flg,lineflg,cutend,tmp,tmp1,tmp2,pA,pB,angle,segpos,cut,scaley,ptlist);
  name="ar"+nm;
  scaley=SCALEY; //190412
  ptlist=apply(ptlistorg,[#_1,scaley*#_2]); //190412
  Setscaling(1);
  options=optionsorg;
  tmp=select(options,isstring(#)); //181214from
  tmp1=select(tmp,contains(["dr","da","do","id"],substring(#,0,2)));
  if(length(tmp1)==0,options=append(options,YasenStyle)); //181214to
  tmp=Divoptions(options);
  Ltype=tmp_1;
  Noflg=tmp_2;
  eqL=tmp_5;
  reL=tmp_6;
  strL=tmp_7;
  color=tmp_(length(tmp)-2);
  opstr=tmp_(length(tmp)-1);
  opcindy=tmp_(length(tmp));
  tmp1=[YaSize,YaAngle,YaPosition,YaCut]; //181214from
  forall(1..(length(reL)),
    if(reL_#<0, reL_#=tmp1_#);
  ); 
  forall((length(reL)+1)..4,
    reL=append(reL,tmp1_#);
  );
  size=reL_1;
  angle=reL_2;
  segpos=reL_3;
  cut=reL_4;
  lineflg=0;
  if(contains(strL,"l")%contains(strL,"L"),
    lineflg=1;
  );//181018from
  options=remove(options,strL);
  cutend=[0,0];//180719
  coord="P";//181018
  forall(eqL,
    tmp=Strsplit(#,"=");
    tmp1=Toupper(substring(tmp_1,0,2));
    tmp2=tmp_2;
    if(tmp1=="CU",//180719from
      tmp2=replace(tmp2,"[","");
      tmp2=replace(tmp2,"]","");
      cutend=tokenize(tmp2,",");
      if(length(cutend)==1,cutend=[cutend_1,cutend_1]);
      options=remove(options,[#]);
    );
    if(tmp1=="CO",//181018from
      coord=Toupper(substring(tmp2,0,1));
      options=remove(options,[#]);
    );
  );
  if(|cutend|>0,//181110from
    tmp=ptlist_2-ptlist_1;
    tmp=tmp/|tmp|;
    ptlist_1=ptlist_1+tmp*cutend_1;
    ptlist_2=ptlist_2-tmp*cutend_2;
  );//181110to
  if(coord=="P",
    pA=ptlist_1; pB=ptlist_2;
    if(ispoint(pA),pA=pA.xy);
    if(ispoint(pB),pB=pB.xy);
  ,
    pA=Pcrd(ptlist_1); pB=Pcrd(ptlist_2);
  );//181018to
  if(Noflg<3,
    println("generate Arrowdata "+name);
    tmp=name+"="+Textformat([pA,pB],5);
    parse(tmp);
    if(lineflg==0, // 16.04.09 from
      tmp=pA-0.2*size/2*(pB-pA)/|pB-pA|;   // 15.06.11
    ,
      tmp=pB;
    );  // 16.04.09 until
    tmp=format([LLcrd(pA),LLcrd(tmp)],6);
  );
  if(Noflg<2,
    if(isstring(Ltype),
      Listplot("-ar"+nm,[LLcrd(pA),LLcrd(pB)],append(options,"Msg=n"));
      Arrowhead(nm,pA+segpos*(pB-pA),pB-pA,options); //181110
    ,
      if(Noflg==1,Ltype=0);
    );
  );
  Setscaling(scaley); //190412
  [Lcrd(pA),Lcrd(pB)];
);
////%Arrowdata end////

////%Anglemark start////
Anglemark(plist):=Anglemark(plist,[]);
Anglemark(Arg1,Arg2):=( // 2015.04.28 from
  regional(nm,plist,options,tmp);
  if(isstring(Arg1),
    nm=Arg1;
    plist=Arg2;
    Anglemark(nm,plist,[]);
  ,
    plist=Arg1;
    options=Arg2;
    tmp=Textformat(plist,5);
    tmp=replace(tmp,",","");
    nm=substring(tmp,1,length(tmp)-1);
    Anglemark(nm,plist,options);
  );
);                    // to
Anglemark(nm,plist,options):=(
//help([A,B,C],["E=\theta",2]);
//help:Anglemark("1",[A,B,C],["E=1.2,\theta",2]);
// help:Anglemark("1",[A,B,2*pi]);
//help:Anglemark(options=[size,"E/L=(sep,)letter"]);
  regional(name,Out,pB,pA,pC,Ctr,ra,sab,sac,ratio,opstr,Bname,Bpos,color,
       Brat,tmp,tmp1,tmp2,Num,opcindy,Ltype,eqL,realL,Rg,Th,Noflg,Msg);
  name="ag"+nm;
  Bpos="md"+name;
  ra=0.5;
  tmp=Divoptions(options);
  Ltype=tmp_1;
  Noflg=tmp_2;
  color=tmp_(length(tmp)-2);
  opcindy=tmp_(length(tmp));
  eqL=tmp_5;
  realL=tmp_6;
  Bname="";
  Brat=1.2; //180530
  Num=20;
  Msg="Y";
  opstr="";
  if(length(realL)>0,
    ra=realL_1*ra;
    opstr=","+text(realL_1);//180530
  );
  forall(eqL,
    tmp=Strsplit(#,"=");
    tmp1=Toupper(substring(tmp_1,0,1));
    if((tmp1=="L")%(tmp1=="E"),
      if(tmp1=="L",Bname="Letter(");
      if(tmp1=="E",Bname="Expr(");
      Bname=Bname+Bpos+","+Dq+"c"+Dq+","+Dq;//16.10.29
      tmp1=indexof(tmp_2,",");
      Bname=Bname+substring(tmp_2,tmp1,length(tmp_2))+Dq+")"; //190219
      if(tmp1>0,
        Brat=parse(substring(tmp_2,0,tmp1-1));
      );
    );
    if(tmp1=="M", //190206from
      Msg=Toupper(substring(tmp_2,0,1));
    ); //190206to
  );
  pB=Lcrd(plist_1); pA=Lcrd(plist_2); sab=pB-pA;
  Ctr=pA;
  if((length(plist_3)>1)%(ispoint(plist_3)), //180506from
    pC=Lcrd(plist_3);
    sac=pC-pA;
    Rg=[arctan2(sab)+0,arctan2(sac)+0];
  ,
    sac=pB-pA;
    Rg=[arctan2(sab)+0,arctan2(sab)+plist_3];   
  ); //180506to
  if(Rg_2<Rg_1,Rg_2=Rg_2+2*pi);
  Out=[];
  if(ra>min(|sab|,|sac|),  // 16.12.29
    println("  segments too short");
  ,
    forall(0..Num,
      Th=Rg_1+#*(Rg_2-Rg_1)/Num;
      Out=append(Out,Ctr+ra*[cos(Th),sin(Th)]);
    );
    Th=(Rg_1+Rg_2)/2; //16.10.31from[moved]
    tmp1=Ctr+Brat*ra*[cos(Th),sin(Th)];
    tmp="Defvar("+Dq+Bpos+"=";
    tmp=tmp+Textformat(tmp1,5)+Dq+");";
    parse(tmp);//16.10.31to[moved]
    if(length(Bname)>0,
      parse(Bname);
    );
    if(Noflg<3,
      if(Msg=="Y", //190206
        println("generate anglemark "+name+" and "+Bpos);
      );
      tmp1=apply(Out,Pcrd(#));
      tmp=name+"="+Textformat(tmp1,5);
      parse(tmp);
      tmp=Textformat(plist,5); //no ketjs on
      tmp1=substring(tmp,1,length(tmp)-1);
      tmp=name+"=Anglemark("+tmp1+opstr+")";
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
  );
  Out;
);
////%Anglemark end////

////%Paramark start////
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
    tmp=Textformat(plist,5);
    tmp=replace(tmp,",","");
    nm=substring(tmp,1,length(tmp)-1);
    Paramark(nm,plist,options);
  );
);// to
Paramark(nm,plist,options):=(
//help:Paramark([A,B,C],["E=\theta"]);
//help:Paramark("1",[p1,p2,p3],["E=\theta"]);
  regional(name,Out,pB,pA,pC,ra,sab,sac,ratio,opstr,Bname,Bpos,
         Brat,tmp,tmp1,tmp2,Ltype,Noflg,eqL,realL,opcindy,color);
  name="pm"+nm;
  tmp=Divoptions(options);
  Ltype=tmp_1;
  Noflg=tmp_2;
  color=tmp_(length(tmp)-2);
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
    Bname=Bname+Bpos+","+Dq+"c"+Dq+","+Dq; //180705
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
    tmp="Defvar("+Dq+Bpos+"="+Textformat(tmp1,5)+Dq+");";
    parse(tmp);
    parse(Bname);
  );
  if(Noflg<3,
    println("generate paramark "+name);
    tmp1=apply(Out,Pcrd(#));
    tmp=name+"="+Textformat(tmp1,5);
    parse(tmp);
    tmp1=substring(Textformat(plist,5),1,length(Textformat(plist,5))-1); //no ketjs on
    tmp=name+"=Paramark("+tmp1+opstr+")";
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
  Out;
);
////%Paramark end////

////%MakeBowdata start////
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
////%MakeBowdata end////

////%Bowdata start////
Bowdata(plist):=Bowdata(plist,[]);
Bowdata(plist,options):=(
  regional(nm,tmp);
  if(islist(plist), // 16.12.04from
    tmp=Textformat(plist,5);
    tmp=replace(tmp,",","");
    nm=substring(tmp,1,length(tmp)-1);
    Bowdata(nm,plist,options);
  ,
    nm=plist;
    tmp=options;
    Bowdata(nm,tmp,[]);
  ); // 16.12.04until
);
Bowdata(nm,plist,options):=(
//help:Bowdata([C,A],[2,1.2,"Expr=10","da"]);
//help:Bowdata([A,B],["Expr=t0n3,a"]);
//help:Bowdata([A,B],["Exprrot=t0n2r,a"]);
  regional(name,Out,pB,pA,pC,ra,tmp,tmp1,tmp2,Ltype,eqL,realL,
    Bname,Bpos,Th,Cut,Num,Hgt,opstr,opcindy,Ydata,pC,Msg,
    Th1,Th2,Noflg,Bops,Bmov,Tmov,Nmov,rev,color);
  name="bw"+nm;
  tmp=Divoptions(options);
  Ltype=tmp_1;
  Noflg=tmp_2;
  color=tmp_(length(tmp)-2);
  opstr=tmp_(length(tmp)-1);
  opcindy=tmp_(length(tmp));
  eqL=tmp_5;
  realL=tmp_6;
  pA=Lcrd(plist_1); pB=Lcrd(plist_2);
  Hgt=1/2*|pB-pA|*0.2;
  Cut=0;
  Num=24;
  Bname="";
  Msg="Y";  //190206
  Tmov=0;//16.11.01from
  Nmov=0;
  Bmov="";
  rev=0;//16.11.01until
  if(length(realL)>0,
    Hgt=realL_1*Hgt; // 15.04.12
    if(length(realL)>1,Cut=realL_2);
  );
  forall(eqL,
    tmp=Strsplit(#,"=");
    tmp1=Toupper(substring(tmp_1,0,1));
    if(tmp1=="L",
      if(indexof(#,"rot")>0,
        Bname="Letterrot(";
      ,
        Bname="Letter(";
      );
      Bops=tmp_2;
    );
    if(tmp1=="E",
      if(indexof(#,"rot")>0,
        Bname="Exprrot(";
      ,
        Bname="Expr(";
      );
      Bops=tmp_2;
    );
    if(tmp1=="M", //190206from
      Msg=Toupper(substring(tmp_2,0,1));
    ); //190206to
  );
  Ydata=MakeBowdata(pA,pB,Hgt); 
  pC=Ydata_1;
  ra=Ydata_2;
  Th=(Ydata_3+Ydata_4)*0.5;
  BOWMIDDLE=[pC_1+ra*cos(Th),pC_2+ra*sin(Th)];
  Bpos="md"+name; // 16.10.31from[moved]
  tmp="Defvar("+Dq+Bpos+"="+Textformat(BOWMIDDLE,5)+Dq+");";
  parse(tmp);// 16.10.31to[moved]
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
      tmp1=1/Norm(tmp)*tmp;
      tmp2=[-tmp1_2,tmp1_1];
      tmp=MARKLEN*(Tmov*tmp1+Nmov*tmp2);
      tmp=LLcrd(tmp);
      Bname=Bname+"+"+text(tmp);
    );
    Bname=Bname+",";
    if(indexof(Bname,"rot")>0,
      if(rev==1,tmp=pB-pA,tmp=pA-pB);
      Bname=Bname+Textformat(tmp,5)+",";
    ,
      Bname=Bname+Dq+"c"+Dq+",";
    );
    Bname=Bname+Dq+Bops+Dq+")";
    parse(Bname);
  );//16.11.01until
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
    if(Msg=="Y", //190206
      println("generate bowdata "+name+" and "+Bpos);//16.10.31
    );
    if(Measuredepth(Out)==1,Out=[Out]);
    tmp1=[];
    forall(Out,tmp2,
      tmp=apply(tmp2,Pcrd(#));
      tmp1=append(tmp1,tmp);
    );
    tmp=name+"="+Textformat(tmp1,5);
    parse(tmp);
    tmp1=substring(Textformat(plist,5),1,length(Textformat(plist,5))-1); //no ketjs on
    tmp=name+"=Bowdata("+tmp1+opstr+")";
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
);
////%Bowdata end////

////%Bowname start////
Bowname(str):=Bowname("c",str);
Bowname(dir,str):=(
  Expr([BOWMIDDLE,dir,str]);
);
////%Bowname end////

////%Bownamerot start////
Bownamerot(bwdata,str):=Bownamerot(bwdata,0,0,str,1);
Bownamerot(bwdata,str,updown):=Bownamerot(bwdata,0,0,str,updown);
Bownamerot(bwdata,tmov,nmov,str):=Bownamerot(bwdata,tmov,nmov,str,1);
Bownamerot(bwdata,tmov,nmov,str,updown):=(
  regional(bdata,tmp);
  tmp=Measuredepth(bwdata);
  if(tmp==1,bdata=[bwdata],bdata=bwdata);
  if(length(bdata)>1,
    tmp=Ptend(bdata_2)-Ptstart(bdata_1);
  ,
    tmp=Ptend(bdata_1)-Ptstart(bdata_1);
  );
  if(updown<0,tmp=-tmp);
  Exprrot(BOWMIDDLE,tmp,tmov,nmov,str);
);
////%Bownamerot end////

////%Deqdata start////
Deqdata(deq,rng,initt,initf,Num):=( //17.10.04
//help:Deqdata("[x1,...xn]`=[f1,...fn]","t=[0,20]",0,[...],50);
  regional(Eps,Inf,tname,Xname,func,t1,t2,dt,tt,X0,flg,
                 kl1,kl2,kl3,kl4,pdL,tmp,tmp1,tmp2);
  Eps=10^(-3);
  Inf=10^3;
  tmp=tokenize(deq,"=");
  tmp1=replace(tmp_1,"`",""); tmp1=replace(tmp1,"'","");//190410
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
////%Deqdata end////

////%Deqplot start////
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
//help:Deqplot("2","y'=y*(1-y)","x",0, 0.5,["Num=100"]);
//help:Deqplot("1","y''=-y","x",0, [1,0]);
//help:Deqplot("3","[x,y]'=[x*(1-y),0.3*y*(x-1)]","t=[0,20]",0,[1,0.5]);
  regional(deq,rng,Ltype,Noflg,eqL,opcindy,Num,name,nn,pdL,phase,
                  sel,tmp,tmp1,tmp2,tmp3,color);
  name="de"+nm;
  tmp=Divoptions(options);
  Ltype=tmp_1;
  Noflg=tmp_2;
  eqL=tmp_5;
  color=tmp_(length(tmp)-2);
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
    rng=rng+"="+Textformat([XMIN,XMAX],6);
  );
  deq=replace(deqorg,"‘","`"); //190206
  deq=replace(deq,"'","`"); //180527
  tmp3=indexof(deq,"=");
  tmp1=substring(deq,0,tmp3-1);
  tmp2=substring(deq,tmp3,length(deq));
  if(indexof(tmp1,"[")==0,
    phase=0;
    sel=[1,2];
  ,
    phase=1;
    sel=[2,3];
  );
  nn=length(Indexall(tmp1,"`"));
  if(nn==0, //190211from
    println("    Lhs of equation has no single/back quotation "+tmp1);
  );
  if(nn>0,
    tmp=Indexall(tmp1,"`");
    if(tmp_(length(tmp))!=tmp3-1,
      nn=0;
    ,
      forall(reverse(2..(length(tmp))),
        if((nn>0)&(!contains(tmp,tmp_#-1)),
          nn=0;
        );
      );
    ); 
    if(nn==0,
      println("    Lhs of equation is not correct");
    );
  ); //190211to
  if(nn==1,
    if(indexof(tmp1,"[")==0,
      tmp1="["+replace(tmp1,"`","]`");
      deq=tmp1+"="+tmp2;
    );
  );
  if(nn>1,
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
  if((nn>0)&(Noflg<3), //190211
    pdL=Deqdata(deq,rng,initt,initf,Num);
    if(phase==1,
      pdL=apply(pdL,#_(2..3));
    );
    tmp1=apply(pdL,Pcrd(#));
    tmp=name+"="+Textformat(tmp1,5);
    parse(tmp);
  );
  if((nn>0)&(Noflg<1), //190211 //no ketjs on
    tmp=Assign(deq);
    tmp=replace(deq,"'","`");
    tmp=name+"=Deqplot('"+tmp+"','"+rng+"',";
    tmp=tmp+format(initt,6)+","+Textformat(initf,6);
    tmp=tmp+","+text(sel)+",'Num="+text(Num)+"')";
    tmp=RSform(tmp);
    GLIST=append(GLIST,tmp);
  ); //no ketjs off
  if((nn>0)&(Noflg<2), //190211
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
);
////%Deqplot end////

////////// old enclosing ///////////////

Enclosing(nm,plist):=EnclosingS(nm,plist);
Enclosing(nm,plist,options):=EnclosingS(nm,plist,options);
EnclosingS(nm,plist):=EnclosingS(nm,plist,[]);
EnclosingS(nm,plist,options):=(
// help:Enclosing("1",["sc2","crAB","sc2","Invert(sc1)"],[pt,"dr"]);
  regional(name,AnsL,Start,Eps,EEps,S,Flg,Fdata,Gdata,KL,pt,qt,color
      t1,t2,t3,ii,nn,tmp,tmp1,tmp2,Ltype,Noflg,realL,eqL,opstr,opcindy);
  name="en"+nm;
  tmp=Divoptions(options);
  Ltype=tmp_1;
  Noflg=tmp_2;
  eqL=tmp_5;
  realL=tmp_6;
  color=tmp_(length(tmp)-2);
  opstr=tmp_(length(tmp)-1);
  opcindy=tmp_(length(tmp));
  Eps=10^(-5); // 16.12.05
  EEps=0.05;
  Start=[];
  Flg=0;
  forall(realL,
    if(islist(#) % ispoint(#),
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
      tmp=Norm(pt-Start);
      forall(2..(length(KL)),ii, // 15.04.20
        tmp1=KL_ii_1;
        tmp2=Norm(tmp1-Start); // 15.04.20
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
          tmp2=Paramoncurve(tmp1,tmp,Fdata);
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
    tmp=name+"="+Textformat(AnsL,5);
    parse(tmp);
    tmp=name+"=Enclosing(";//16.11.07from //no ketjs on
    tmp1="list"+PaO();
    forall(plist,
      tmp1=tmp1+#+",";
    );
    tmp=tmp+substring(tmp1,0,length(tmp1)-1)+")"+opstr+")";
    GLIST=append(GLIST,tmp);//16.11.07to //no ketjs off
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
  tmp=apply(AnsL,LLcrd(#));//16.10.20
  tmp;
);

/////////// new enclosing ///////////

////%Enclosing start////
Enclosing(nm,plist):=Enclosing2(nm,plist,[]);//180706[2lines]
Enclosing(nm,plistorg,options):=Enclosing2(nm,plistorg,options);
Enclosing2(nm,plist):=Enclosing2(nm,plist,[]);
Enclosing2(nm,plistorg,options):=(
//help:Enclosing("1",["sg2","gr1","Invert(sg2)"]);
//help:Enclosing(options=[startpoint,epspara(1)]);
  regional(name,plist,AnsL,Start,Eps,Eps1,Eps2,flg,Fdata,Gdata,KL,
      t1,t2,tst,ss,ii,nn,nxtno,Ltype,Noflg,realL,eqL,opstr,opcindy,
      tmp,tmp1,tmp2,color,epspara,p1,p2);
  name="en"+nm;
  plist=plistorg;
  tmp=Divoptions(options);
  Ltype=tmp_1;
  Noflg=tmp_2;
  eqL=tmp_5;
  realL=tmp_6;
  color=tmp_(length(tmp)-2);
  opstr=tmp_(length(tmp)-1);
  opcindy=tmp_(length(tmp));
  Eps=10^(-5); // 16.12.05
  epspara=1; //180707
  Eps1=0.01;
  Eps2=0.1;
  Start=[];
  flg=0;
  forall(realL,
    if(isList(#) % ispoint(#),
      Start=Lcrd(#); // 18.02.02
    ,
      if(flg==0,epspara=#);//180707
      if(flg==1,Eps1=#);
      if(flg==2,Eps2=#);
      flg=flg+1;
    );
  );
  flg=0;
  AnsL=[];
  if(length(plist)==1,
    Fdata=parse(plist_1);
    tmp1=Fdata_1;
    tmp2=Fdata_(length(Fdata));
    if(|tmp1-tmp2|<Eps,
      AnsL=Fdata;
    ,
      AnsL=append(Fdata,tmp1);
    );
    flg=1;
  );
  if(flg==0,
    Fdata=plist_1;
    Gdata=plist_(length(plist));
    KL=IntersectcurvesPp(Fdata,Gdata);
    if(length(KL)==0,
      tmp=parse(Gdata);
      tmp1=LLcrd(Op(length(tmp),tmp)); //18.02.02from
      tmp=parse(Fdata);
      tmp2=LLcrd(Op(1,tmp));
      tmp=Listplot(name,[tmp1,tmp2],["nodisp"]);
      plist=append(plist,"sg"+name);
      Start=tmp2;
      tst=1; //18.02.02to
      p1=Start;
    ,
      if(length(KL)==1,
        tst=KL_1_2;
        Start=Pointoncurve(tst,Fdata);
      );
      if(length(KL)>1,
        KL=sort(KL,[#_2]);
        if(Start==[],
          tst=KL_1_2;
          Start=Pointoncurve(tst,Fdata);
        ,
          tmp=apply(KL,|#_1-Start|);
          tmp=min(tmp);
          tmp1=select(KL,|#_1-Start|<tmp+Eps1);//180718
          tst=tmp1_1_2;
          Start=Pointoncurve(tst,Fdata);
        );
      );
    );
  );
  if(flg==0,
    t1=tst;
    p1=Pointoncurve(t1,Fdata); //180713
    println("Start point of enclosing is "+text(Start));
    forall(1..(length(plist)),nn,
      Fdata=plist_nn;
      if(nn==length(plist),nxtno=1,nxtno=nn+1);
      Gdata=plist_nxtno;
      KL=IntersectcurvesPp(Fdata,Gdata);
      if(length(KL)==0,
        tmp1=parse(Fdata); //18.02.02from
        tmp2=parse(Gdata); 
        tmp2=Prepend(Op(length(tmp1),tmp),tmp2);
        Gdata=replace(Gdata,"(","");
        Gdata=replace(Gdata,")","");
        tmp=Gdata+"="+Textformat(tmp2,6);
        parse(tmp);
        plist_nxtno=Gdata;
        t2=Length(tmp1);
        p2=Pointoncurve(t2,Fdata); //180713
        ss=1; //18.02.02to
      ,
        KL=sort(KL,[#_2]);//180706
        tmp=parse(Fdata);
        tmp1=t1+epspara/50*length(tmp);
//        KL=select(KL,#_2>t1+epspara/50*length(tmp)); //180707
        KL=select(KL,(#_2>tmp1)%((#_2>t1)&(|#_1-p1|>Eps1))); //180713,16
        t2=KL_1_2;
        ss=KL_1_3;
        if(abs(t2-t1)<Eps,//180707
          if(length(KL)>1,
            t2=KL_2_2;
            ss=KL_2_3;
          ,
            println(text(nn)+" and "+text(nxtno)+" not intersect");
            flg=1;
          );
        );
      );
      if(flg==0,
        tmp=Partcrv("",t1,t2,Fdata,["nodata"]);
        if(nn==1,
          AnsL=tmp;
        ,
          AnsL=concat(AnsL,tmp_(2..(length(tmp))));
        );
      );
      t1=ss;//180706
      p1=Pointoncurve(t1,Gdata); //180713
    );
  );
  if(flg==0,
    AnsL=apply(AnsL,Pcrd(#));
  );
  if(Noflg<3,
    println("generate Enclosing "+name);
    tmp=name+"="+Textformat(AnsL,5);
    parse(tmp);
    tmp=name+"=Enclosing2(";//16.11.07from
    tmp1="list"+PaO();
    forall(plistorg, //18.02.02
      tmp1=tmp1+#+",";
    );
    tmp=tmp+substring(tmp1,0,length(tmp1)-1)+")";//18.0706from //no ketjs on
    if(length(Start)>0,tmp=tmp+","+Textformat(Start,6));
    tmp=tmp+","+text(epspara)+")";//18.0706to,180707
    GLIST=append(GLIST,tmp);//16.11.07to //no ketjs off
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
  tmp=apply(AnsL,LLcrd(#));//16.10.20
  tmp;
);
////%Enclosing end////

/////////// end of new enclosing ///////////

/////////// new Hatchdata(cindy) ///////////

////%Makehatch start////
Makehatch(iolistorg,pt,vec,bdylist):=(
  regional(Eps,iolist,sg,bdy,out,nb,tenL,ns,ne,ioL,
         ii,jj,kk,nvec,nbdy,sgn1,sgn2,flg,rmL,p0,p1,p2,pL,
         Scalebkup,tmp,tmp1,tmp2);
  Eps=10^(-5);
  nvec=[-vec_2,vec_1];
  nvec=nvec/|nvec|;
  if(!islist(iolistorg),iolist=[iolistorg],iolist=iolistorg);
  forall(1..(length(iolist)),
    tmp=replace(iolist_#,"i","1,");
    tmp=replace(tmp,"o","0,");
    tmp="["+substring(tmp,0,length(tmp)-1)+"]";
    iolist_#=parse(tmp);
  );
  Scalebkup=[SCALEX,SCALEY];//181020[2lines]
  SCALEX=1;
  SCALEY=1;
  sg=Lineplot("",[pt,pt+vec],["nodata"]);
  nb=length(bdylist);
  if(nb>0,
    tenL=[];
    forall(1..nb,ii,
      rmL=[];
      bdy=bdylist_ii;
      nbdy=length(bdy)-1;
      pL=[];
      forall(1..nbdy,jj,
        p1=bdy_jj;
        p2=bdy_(mod(jj+1-1,nbdy)+1);
        tmp=Intersectseg(sg,[p1,p2],Eps);
        if(abs(tmp_1)<Eps, //18.02.01
          p0=tmp_2; t=tmp_3; s=tmp_4;
          flg=0; //181003from
          forall(pL,
            if(flg==0,
              if(Norm(#_1-p0)<Eps,
                flg=1;
              );
            );
          );
          if(flg==0,
            pL=append(pL,[p0,t,s,ii]);
          ); //181003to
        );
      );
      if(length(pL)>0,
        pL=sort(pL,[#_2]);
        pL=apply(1..(length(pL)),append(pL_#,mod(#,2)));
        tenL=concat(tenL,pL);
      );
    );
    tenL=sort(tenL,[#_2]);
    if(length(tenL)>0, //180619from
      tmp1=tenL; tenL=[tmp1_1];
      forall(2..(length(tmp1)),ii, //180717from
        tmp=tmp1_ii;
        flg=0;
        forall(tenL,
          if((Norm(tmp_1-#_1)<Eps1)&(tmp_4==#_4),
            flg=1;
          );
        );
        if(flg==0,
          tenL=append(tenL,tmp);
        );
      );//180717to
    ); //180619to
    ioL=apply(1..nb,0);
    ns=1;
    ne=length(tenL);
    if(ne>0,tmp=tenL_1_1,tmp=sg_2);
    if(|sg_1-tmp|>Eps,
      tmp=[sg_1,-1,1,ioL];
      tenL=prepend(tmp,tenL);
      ns=ns+1;
      ne=ne+1;
    );
    if(|sg_2-tenL_(length(tenL))_1|>Eps,
      tmp=[sg_2,-1,2,ioL];
      tenL=append(tenL,tmp);
    );
    forall(ns..(ne-1),ii, //180619  ne=>ne-1
      tmp=tenL_ii;
      tmp1=tmp_4;
      tmp2=tmp_5;
      ioL_tmp1=tmp2;
      tmp=[tmp_1,tmp_2,tmp_4,ioL];
      tenL_ii=tmp;
    );
    out=[];
    forall(1..(length(tenL)-1),ii,
      tmp1=tenL_ii;
      if(contains(iolist,tmp1_4),
        tmp2=tenL_(ii+1);
        tmp=Listplot("",[tmp1_1,tmp2_1],["nodata"]);
        out=append(out,tmp);  
      );
    );
  );
  SCALEX=Scalebkup_1; //181020
  SCALEY=Scalebkup_2;
  out;
);
////%Makehatch end////

////%Anyselected start////
Anyselected(ptL):=(
  regional(tmp,out);
  out=false;
  forall(ptL,
    if(isstring(#),tmp=parse(#),tmp=#);
    out=(out)%(isselected(tmp));
  );
  out;
);
////%Anyselected end////

////%Hatchdata start////
Hatchdata(nm,iostr,bdylist):=Hatchdatacindy(nm,iostr,bdylist,[]);//180619
Hatchdata(nm,iostr,bdylist,optionsorg):=( //181003from
  regional(options,tmp,tmp1,tmp2,eqL,strL,chkL,outflg);
  options=optionsorg;
  tmp=Divoptions(options);
  eqL=tmp_5;
  strL=tmp_7;
  outflg=0;
  forall(eqL,
    tmp=Strsplit(#,"=");
    tmp1=Toupper(tmp_1);
    if(substring(tmp1,0,1)=="O",
      tmp2=tmp_2;
      if(tmp2!="n",
        outflg=1;
        option=remove(options,[#]);
        if((tmp2=="m")%(tmp2=="r"),
          options=append(options,tmp2);;
        );
      );
    );
  );
  if(outflg==0,
    options=remove(options,strL);
    Hatchdatacindy(nm,iostr,bdylist,options);
  ,
    HatchdataR(nm,iostr,bdylist,options); 
  );
); //181003to
Hatchdatacindy(nm,iostr,bdylist):=Hatchdata(nm,iostr,bdylist,[]);
Hatchdatacindy(nm,iostr,bdylistorg,optionsorg):=(
 //help:Hatchdata("1",["ii"],[["ln1","Invert(gr1)"],["gr2","n"]]);
//help:Hatchdata(options=["Not=pointlist","File=y(/m/n)","Max=50","Check=",angle,width]);
  regional(name,bdylist,bdynameL,bname,Ltype,Noflg,opstr,opcindy,reL,
    options,eqL,maxnum,startP,angle,interval,vec,nvec,ctr,pt,kk,delta,sha,AnsL,
    color,tmp,tmp1,tmp2,tmp3,namep,x1,y1,x2,y2,p1,p2, //180717
    fname,fileflg,mkflg,vaL,pL,nL,nn,str,is,ie); //181102
  name="ha"+nm;
  fname=Fhead+name+".txt";
  bdylist=[]; 
  bdynameL=[];
  forall(1..(length(bdylistorg)),kk,
    tmp1=bdylistorg_kk;
    if(length(tmp1)==1,
      bname=tmp1_1;
    ,
      tmp=tmp1_(length(tmp1));
      if(contains(["n","s","e","w"],tmp),
        namep=tmp1_1;//180717from
        tmp2=parse(namep);
        if(substring(namep,0,2)=="ln", //180717from
          if(contains(["n","s"],tmp),
             x1=tmp2_1_1; y1=tmp2_1_2; x2=tmp2_2_1; y2=tmp2_2_2;
             p1=[NE.x,(y2-y1)/(x2-x1)*(NE.x-x1)+y1];
             p2=[SW.x,(y2-y1)/(x2-x1)*(SW.x-x1)+y1];
             Listplot(name+text(kk),[p1,p2],["nodisp"]);
             namep="sg"+name+text(kk);
             tmp2=parse(namep);
          );
          if(contains(["e","w"],tmp),
             x1=tmp2_1_1; y1=tmp2_1_2; x2=tmp2_2_1; y2=tmp2_2_2;
             p1=[(x2-x1)/(y2-y1)*(NE.y-y1)+x1,NE.y];
             p2=[(x2-x1)/(y2-y1)*(SW.y-y1)+x1,SW.y];
             Listplot(name+text(kk),[p1,p2],["nodisp"]);
             namep="sg"+name+text(kk);
             tmp2=parse(namep);
          );
        );//180717to
        if(tmp=="s",
          Listplot(name,[LLcrd(tmp2_1),[tmp2_1_1,2*YMIN-YMAX], //180717[2lines]
                 [tmp2_(length(tmp2))_1,2*YMIN-YMAX],LLcrd(tmp2_(length(tmp2)))],
                 ["nodisp"]);
          Joincrvs(text(kk)+name,[namep,"sg"+name],["nodisp"]);//180717
          bname="join"+text(kk)+name;
        );
        if(tmp=="n",
          Listplot(name,[LLcrd(tmp2_1),[tmp2_1_1,2*YMAX-YMIN], //180717[2lines]
              [tmp2_(length(tmp2))_1,2*YMAX-YMIN],LLcrd(tmp2_(length(tmp2)))],
              ["nodisp"]);
          Joincrvs(text(kk)+name,[namep,"sg"+name],["nodisp"]);
          bname="join"+text(kk)+name;
        );
        if(tmp=="e",
          Listplot(name,apply([tmp2_1,[XMAX,tmp2_1_2],
                      [XMAX,tmp2_(length(tmp2))_2],tmp2_(length(tmp2))],LLcrd(#)),["nodisp"]);
          Joincrvs(text(kk)+name,[namep,"sg"+name],["nodisp"]);//180717
          bname="join"+text(kk)+name;
        );
        if(tmp=="w",
          Listplot(name,apply( [tmp2_1,[XMIN,tmp2_1_2],
                      [XMIN,tmp2_(length(tmp2))_2],tmp2_(length(tmp2))],LLcrd(#)),["nodisp"]);
          Joincrvs(text(kk)+name,[namep,"sg"+name],["nodisp"]);//180717
          bname="join"+text(kk)+name;
        );
      ,
        Enclosing2(text(kk)+name,tmp,["nodisp"]);//180619[2lines]
        bname="en"+text(kk)+name;
      );
    );
    bdylist=append(bdylist,parse(bname));
    bdynameL=append(bdynameL,bname);
  );
  options=optionsorg;
  tmp=Divoptions(options);
  Ltype=tmp_1;
  Noflg=tmp_2;
  eqL=tmp_5;
  reL=tmp_6;
  color=tmp_(length(tmp)-2);
  opstr=tmp_(length(tmp)-1);
  opcindy=tmp_(length(tmp));
  angle=45;
//  interval=0.125*1000/2.54/MilliIn;
  interval=0.25*1000/2.54/MilliIn; //180706
  startP=[(XMIN+XMAX)/2, (YMIN+YMAX)/2];
  maxnum=[50,0]; //181109changed [first,second]
  fileflg="N";//181102from
  mkflg=1;
  chkL=[]; //181109
  forall(eqL,
    tmp=Strsplit(#,"=");
    tmp1=Toupper(substring(tmp_1,0,1));
    if(tmp1=="M",
      maxnum=parse(tmp_2);
      if(!islist(maxnum),
        maxnum=[maxnum,0];
      );
      options=remove(options,[#]);
    );
    if(tmp1=="F", //181102from
      fileflg=Toupper(substring(tmp_2,0,1));
      options=remove(options,[#]);
    ); //181102to
    if(tmp1=="N", //181103from
      tmp=parse(tmp_2);
      if(Anyselected(tmp),
        mkflg=-1;
      );
      options=remove(options,[#]);
    );
    if(tmp1=="C",
      chkL=parse(tmp_2);
      options=remove(options,[#]);
    );
  );//181102,03to
  tmp1=1;
  forall(reL,
    if(islist(#),
      startP=#;
    ,
      if(tmp1==1,
        angle=#;
        tmp1=tmp1+1;
      ,
        interval= interval*#;
      );
    );
  );
  if((fileflg=="Y")%(fileflg=="M")&(mkflg>-1), //181102from
    wflg=1;
    varL=flatten(bdylistorg);
    varL=select(varL,length(#)>1);
    varL=sort(varL);
    pL=[];
    forall(1..(length(varL)),nn,
      tmp1=varL_nn;
      tmp=select(GLIST,substring(#,0,length(tmp1))==tmp1);
      str=tmp_1;
      varL_nn=str;
      tmp1=Bracket(str,"()");
      tmp2=max(apply(tmp1,#_2));
      nL=select(1..(length(tmp1)),tmp1_#_2==tmp2);
      forall(nL,nn,
        is=tmp1_nn_1; ie=tmp1_(nn+1)_1;
        tmp=substring(str,is,ie-1);
        tmp=replace(tmp,"'",Dq);
        tmp=parse("["+tmp+"]");
        tmp2=flatten(tmp);
        tmp2=flatten(tmp2);
        tmp2=flatten(tmp2);
        forall(tmp2,
          if(ispoint(#),
            if(!contains(pL,text(#)),
              pL=append(pL,text(#));
            );
          );
        );
      );
    );
    forall(chkL,
      if(!contains(pL,#),pL=append(pL,#));
    );
    forall(pL,
      tmp=#+"="+Textformat(parse(#+".xy"),5);
      varL=append(varL,tmp);
    );
    tmp="reL="+Textformat(reL,5);
    varL=append(varL,tmp);
    if(fileflg=="M",
      fileflg="Y";
    ,
      tmp1="hatch"+nm+".txt";
      if(isexists(Dirwork,tmp1),
        tmp2=load(tmp1);
        tmp2=tokenize(tmp2,"//");
        tmp2=tmp2_(1..(length(tmp2)-1));
        if(tmp2==varL,
          wflg=0;
          if(isexists(Dirwork,fname),
            mkflg=0;
            ReadOutData(fname);
            tmp=name+"="+Textformat(parse(name),5);
            parse(tmp);
          );
        );
      );
    );
  );
  if(mkflg==1, //181102to
    angle=angle*pi/180;
    vec=[cos(angle),sin(angle)];
    nvec=[-sin(angle),cos(angle)];
    AnsL=[]; 
    ctr=0;//181005[2lines]
    forall(0..(maxnum_1), kk,
      pt=startP+kk*interval*nvec;
      sha=Makehatch(iostr,pt,vec,bdylist);
      if((sha!=-1)&(length(sha)>0),
        AnsL=concat(AnsL,sha);
        ctr=ctr+1; //181005
      );
    );
    maxnum_2=maxnum_2+(maxnum_1-ctr); //181005
    forall(1..(maxnum_2),kk, //181005
      pt=startP-kk*interval*nvec;
      sha=Makehatch(iostr,pt,vec,bdylist);
      if((sha!=-1)&(length(sha)>0),
        AnsL=concat(AnsL,sha);
      );
    );
    tmp1=apply(AnsL,Textformat(#,5));
    tmp=name+"="+tmp1;
    parse(tmp);
  );
  if((Noflg<3)&(mkflg>-1),
    if(fileflg!="Y", //181102
      println("generate Hatchdata "+name);
      tmp=name+"="+Textformat(AnsL,5);
      parse(tmp);
      if(!islist(iostr),tmp1=[iostr],tmp1=iostr); //no ketjs on
      tmp="c"+PaO();
      forall(tmp1,
        tmp=tmp+Dq+#+Dq+",";
      );
      tmp=substring(tmp,0,length(tmp)-1)+")";
      tmp2=name+"=Hatchdata("+tmp;
      forall(bdynameL,
        tmp2=tmp2+",list"+PaO()+#+")";
      );
      tmp2=tmp2+opstr+")";
      GLIST=append(GLIST,tmp2); //no ketjs off
    ,
      GLIST=append(GLIST,"ReadOutData("+Dq+fname+Dq+")");//181102 //no ketjs
    );
  );
  if((Noflg<2)&(mkflg>-1),
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
  if(mkflg>-1,
    if((fileflg=="Y")&(wflg==1), //181102from
      tmp1="hatch"+nm+".txt";
      SCEOUTPUT = openfile(tmp1);
      forall(varL,
        println(SCEOUTPUT,#+"//");
      );
      closefile(SCEOUTPUT);
      WriteOutData(fname,[name,parse(name)]);
    );  //181102to
    tmp2=[];
    forall(AnsL,tmp1,
      tmp=apply(tmp1,LLcrd(#));
      tmp2=append(tmp2,tmp);
    );
    tmp2;
  );
);
////%Hatchdata end////

////%Shadein start////
Shadein(pstrorg):=( //190220
  regional(pstr,ptL,pL,crv,nn,
      tmp,tmp1,tmp2,pm1,pm2,p1,p2,flg);
  if(islist(pstrorg),pstr=pstrorg_1,pstr=pstrorg);
  crv=[];
  Framedata(["nodisp"]);
  ptL=IntersectcurvesPp(pstr,frwin);
  if(length(ptL)>0,
    pL=apply(ptL,#_2);
    forall(1..(length(pL)),nn,
      if(nn<length(pL),
       tmp1=pL_nn;
       tmp2=pL_(nn+1);
       tmp=Pointoncrv((tmp1+tmp2)/2,pstr);
      ,
        tmp1=pL_nn;
        tmp2=pL_1;
        tmp=parse(pstr);
        if(pL_nn==length(tmp),
          tmp=tmp_1;
        ,
          tmp=tmp_(length(tmp));
        );
      );
      if(Inwindow(tmp),
        tmp=Partcrv("",tmp1,tmp2,pstr,["nodata"]);
      ,
        tmp1=Pointoncrv(tmp1,pstr);
        tmp2=Pointoncrv(tmp2,pstr);
        pm1=Paramoncrv(tmp1,frwin);
        pm2=Paramoncrv(tmp2,frwin);
        if(floor(pm1)==floor(pm2),
          tmp=Listplot("",[tmp1,tmp2],["nodata"]);
        ,
          tmp=floor(pm1);
          p1=Pointoncrv(tmp,"frwin");
          p2=Pointoncrv(mod(tmp,4)+1,"frwin");
          tmp=p1-10*(p2-p1);
          Listplot("frwin",[p1,tmp],["nodisp","Msg=n"]);
          tmp=IntersectcurvesPp("sgfrwin",pstr);
          if(mod(length(tmp),2)==0, //190223from
            if(pm2<pm1,pm2=pm2+4); 
            tmp=[tmp1];
            pm1=floor(pm1)+1;
            flg=0;
            forall(1..3,
              if(flg==0,
                if(pm1<pm2,
                  p1=Pointoncrv(mod(pm1-1,4)+1,"frwin");
                  tmp=append(tmp,p1);
                  pm1=pm1+1;
                ,
                  flg=1;
                );
              );
            );
            if(pm1-1<pm2,tmp=append(tmp,tmp2));
          ,
            if(pm2>pm1,pm2=pm2-4);
            tmp=[tmp1];
            pm1=floor(pm1);
            flg=0;
            forall(1..3,
              if(flg==0,
                if(pm1>pm2,
                  p1=Pointoncrv(mod(pm1-1,4)+1,"frwin");
                  tmp=append(tmp,p1);
                  pm1=pm1-1;
                ,
                  flg=1;
                );
              );
            );
            if(pm1+1>pm2,tmp=append(tmp,tmp2));
          ); //190223to
        );
      );
      if(length(crv)==0,
        crv=tmp;
      ,
        crv=Joincrvs("",[crv,tmp],["nodata"]);
      );
    );
  ,
    if(Inwindow(parse(pstr+"_1")),crv=pstr,crv=frwin);
  );
  crv;
);
////%Shadein end////

////%Shade start////
Shade(plist):=Shade(plist,[]); 
Shade(Arg1,Arg2):=(
  if(!isstring(Arg1),
    Shade(text(SHADECTR),Arg1,Arg2); //190222
  ,
    Shade(Arg1,Arg2,[]);
  );
);
Shade(nm,plistorg,options):=(
//help:Shade(["gr1"],[0.5]);
//help:Shade(["gr1"],["Color=red"]);
//help:Shade(["gr1"],["Trim=y(n)"]); //190224
// help:Shade(["gr1","sg1"],["Color=[1,0,0]"]);
// help:Shade([[A,B,C,A]]);
//help:Shade(["gr2","Invert(sg1)"],["Enc=y",(Startpoint)]);
  regional(name,plist,jj,nn,trim,tmp,tmp1,tmp2,
     opstr,opcindy,eqL,reL,Str,G2,flg,encflg,startpt,color,ctr);
  name="shade"+nm;
  plist=plistorg;
  if(isstring(plist_1), // 16.01.24
    println("output Shade of "+plist);
  ,
    println("output Shade of lists");
  );
  tmp=Divoptions(options);
  eqL=tmp_5; 
  reL=tmp_6;
  color=tmp_(length(tmp)-2);
  opstr=tmp_(length(tmp)-1);
  opcindy=tmp_(length(tmp));
  tmp=select(plist,indexof(#,"Invert")>0); //180929from
  if(length(tmp)>0,encflg=1,encflg=0);
  trim="N";
  forall(eqL,
    tmp=Strsplit(#,"=");
    tmp1=Toupper(tmp_1);
    tmp2=Toupper(tmp_2);
    if(substring(tmp1,0,1)=="E",
      if(substring(tmp2,0,1)=="Y",
        encflg=1;
      );
      if(substring(tmp2,0,1)=="N",
        encflg=0;
      );
    );
    if(substring(tmp1,0,1)=="T",
      trim=substring(tmp2,0,1);
    );
  );
  startpt=[];
  forall(reL,
    if(islist(#),
      startpt=#;
    );
  ); //180929to
  if(length(color)==4, //180602from
    tmp=Colorcmyk2rgb(color);
  );
  flg=0; ctr=1;
  if(encflg==1, //180929from
    if(length(startpt)==2,
      Enclosing(nm,plist,[startpt,"nodisp"]);
    ,
      Enclosing(nm,plist,["nodisp"]);
    );
    plist=["en"+nm];
  ); //180929to
  if((length(plist)==1)&(trim=="Y"), //190220from,109224
    plist=[Shadein(plist)];
  ); //190220to
  forall(1..(length(plist)),jj, //180613from
    if(flg==0,
      tmp1=plist_jj;
      if(isstring(tmp1),tmp=parse(tmp1),tmp=tmp1);
      if(!islist(tmp),
         flg=1;
      ,
        if(!isstring(tmp1),
          tmp2=[];
          forall(tmp1,if(ispoint(#),tmp=#.xy,tmp=#);
            tmp2=append(tmp2,tmp);
          );
          tmp1=Dqq("-"+name+text(ctr));
          tmp2=Textformat(tmp2,6)+",["+Dqq("nodisp")+"]";
          tmp=name+text(ctr)+"=Listplot("+tmp1+","+tmp2+")";
          parse(tmp);
          plist_jj=name+text(ctr);
          ctr=ctr+1;
        );
      ); 
    );
  );//180613to
  if(flg==1,
    println("    some data not defined properly");
 ,
    G2=Joincrvs("1",plist,["nodata"]);
    G2=apply(G2,Pcrd(#));
    tmp1="fillpoly("+Textformat(G2,5)+opcindy+");";
    parse(tmp1);
  );
  Str="Shade("; //no ketjs on
  tmp1="list"+PaO();
  forall(plist,
    if(isstring(#),  // from 16.01.24
      if(length(#)>1,
        tmp1=tmp1+#+",";
      ,
        tmp1=tmp1+Dq+#+Dq+",";
      );
    ,
       tmp1=tmp1+"Listplot("+Textformat(#,5)+"),";
    ); //16.01.24to
  );
  Str=Str+substring(tmp1,0,length(tmp1)-1)+")"+")"; //180929 
  nn=length(COM2ndlist); //190311from
  jj=nn;
  forall(plist,tmp1,
    tmp=select(1..nn,indexof(COM2ndlist_#,tmp1)>0);
    jj=min(append(tmp,jj));
  );
  tmp1=["Texcom("+Dqq("{")+")","Setcolor("+color+")",Str,"Texcom("+Dqq("}")+")"];
  tmp2=COM2ndlist_(1..(jj-1));
  tmp=COM2ndlist_(jj..(length(COM2ndlist)));
  if(!islist(tmp),tmp=[tmp]);
  COM2ndlist=concat(tmp2,tmp1);
  COM2ndlist=concat(COM2ndlist,tmp); //190311to
  //no ketjs off
  SHADECTR=SHADECTR+1;
);
////%Shade end////

/////////// end of new Hatchdata(cindy) ///////////

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
    tmp1=concat(options,[colorax,"Msg=n"]);//181216,190325
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
Expr(Pt,Dr,St,options):=Expr([Pt,Dr,St],options); //190409
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
    PTEXCEPTION=concat(PTEXCEPTION,[pC]); //190329
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
    ketfiles=concat(["+basic1","+basic2","+basic3","+out"],tmp); //190414
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

//help:end();

