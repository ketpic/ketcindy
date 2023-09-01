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

println("ketcindylibbasic2[20230831] loaded");

//help:start();

////%Drwfigs start//// 190530
Drwfigs(nm,figlist):=Drawfigures(nm,figlist,[]);
Drwfigs(nm,figlist,optionlist):=Drawfigures(nm,figlist,optionlist,[]);
Drwfigs(nm,figlist,optionlist,commonops):=Drawfigures(nm,figlist,optionlist,commonops);
////%Drwfigs end//// 

////%Drawfigures start//// 190426
Drawfigures(nm,figlist):=Drawfigures(nm,figlist,[]);
Drawfigures(nm,figlist,optionlist):=Drawfigures(nm,figlist,optionlist,[]);
Drawfigures(nm,figlistorg,optionlistorg,commonops):=(
//help:Drawfigures("1",["pt1","cr1"], [["Size=3"],[]],["Msg=n"]);
//help:Drawfigures("","re1",[["Size=3"],[]],["Msg=n"]);
  regional(figlist,name,figL,optionlist,nn,kk,fig,eqL,msg,tmp,tmp1,tmp2);
  tmp=Divoptions(commonops);
  eqL=tmp_5;
  msg="N";
  forall(eqL,
    tmp=Strsplit(#,"=");
    tmp1=Toupper(substring(tmp_1,0,1));
    if(tmp1=="M",
      msg=Toupper(substring(tmp_2,0,1));
    );
  );
  figlist=figlistorg;
  if(isstring(figlist), //190818from
    name=figlist+nm;
    figlist=parse(figlist);
  ,
    name="figs"+nm;
  ); //190818to
  nn=length(figlist);
  optionlist=optionlistorg;
  if(length(optionlist)==0, //190531from
    optionlist=apply(1..nn,[]);
  );
  if(!islist(optionlist_1),
    optionlist=apply(1..nn,optionlist);
  );
  if(length(optionlist)<nn,
    tmp=optionlist_(length(optionlist));
    tmp2=length(optionlist);
    tmp1=apply(tmp2..nn,tmp);
    optionlist=concat(optionlist,tmp1);
  ); //190531to
  figL=[];
  forall(1..nn,kk,
    fig=figlist_kk;
    if(isstring(fig),fig=parse(fig));
    if(length(fig)>0,
      if(isstring(figlistorg),
        tmp1=Measuredepth(fig);
        tmp2=append(optionlist_kk,"Msg=n");
        tmp=fig;
        if(tmp1==2,tmp=tmp_1);
        if(length(tmp)>1,
          Listplot("-"+name+"n"+text(kk),fig,tmp2);
        ,
          if(tmp1==2,fig=apply(fig,#_1));
          Pointdata("-"+name+"n"+text(kk),fig,tmp2);
        );
        figL=append(figL,name+"n"+text(kk));
     ,
        if(Measuredepth(fig)==0,fig=[fig]); //190531from
        if(Measuredepth(fig)==1,fig=[fig]);
        forall(1..(length(fig)),
          tmp1=fig_#;
          tmp2=name+"n"+text(kk)+"p"+text(#);
          if(length(tmp1)==1,
            Pointdata(tmp2,tmp1,append(optionlist_kk,"Msg=n")); //200701
            figL=append(figL,"pt"+tmp2);
          ,
            Listplot("-"+tmp2,tmp1,append(optionlist_kk,"Msg=n")); //200701
            figL=append(figL,tmp2); //190427
          );
        ); //190531to
        tmp=apply(figL,Dqq(#));
        tmp=name+"="+text(tmp)+";";
        parse(tmp);
      );
    );
    if(msg=="Y",
      println("generate "+name+"="+text(figL));
    );
  );
  figL;
);
////%Drawfigures end////

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
    if(tmp_2<2.5,YaAngle=tmp_2*YaAngle,Yaangle=tmp_2); //191123
   );
  if(length(tmp)>=3,
     YaPosition=tmp_3; //191114
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

////%Arrowheaddata start////  230818dbg
Arrowheaddata(point,direction):=
   Arrowheaddata(point,direction,[YaSize,YaAngle,YaPosition,YaCut]);
Arrowheaddata(pointorg,directionorg,options):=( //191127remade
// help:Arrowheaddata(A,B);
// help:Arrowheaddata("1",A,"gr1");
// help:Arrowheaddata("1",A,gr1);
// help:Arrowheaddata(options=[size(1),angle(18),pos(1),cut(0)]);
  regional(point,direction,scaley,Eps,size,angle,segpos,cut, 
            Houkou,hflg,Str,Ev,Nv,reL,pP,vec,
            pA,pB,pC,par,out,tmp,tmp1,tmp2);
  point=Pcrd(pointorg); //230830from
  tmp=directionorg;
  if(isstring(tmp),
    tmp=parse(tmp);
    direction=apply(tmp,Pcrd(#)); //230830to 
  ,
    direction=Pcrd(tmp);
  );
  Eps=10^(-4);
  tmp=Divoptions(options);
  reL=tmp_6;
  size=0.2*YaSize*1/2.54*1000/MilliIn; 
  angle=YaAngle*pi/180;
  segpos=YaPosition;
  cut=YaCut;
  if(length(reL)>=1,
    size=0.2*reL_1*1/2.54*1000/MilliIn; 
  );
  if(length(reL)>=2,
    if(reL_2<2.5,angle=reL_2*YaAngle,angle=reL_2);
    angle=angle*pi/180;
  );
  if(length(reL)>=3,
    segpos=reL_3;
  );
  if(length(reL)>=4,
    cut=reL_4;
  );
  if(ispoint(point),pP=Lcrd(point),pP=point);
  hflg=0; 
  out=[];
  if(ispoint(direction),
    Houkou=direction.xy;
    hflg=2;
  );
  if(hflg==0, //191203from
    if(!isstring(direction), //191207
      if(Measuredepth(direction)==0,
        Houkou=direction;
        hflg=2;
      );
    );  //191207to
  ); //191203to
  scaley=SCALEY;
  SCALEY=1; //200114
  if(hflg==0,
    if(isstring(direction),Houkou=parse(direction),Houkou=direction);
    if(!islist(pP),
      par=1+(length(Houkou)-1)*pP; //191207
      pP=Ptcrv(par,Houkou);
      tmp=floor(tmp); //191203from
    ,
      tmp=Nearestpt(pP,Houkou);
      pP=tmp_1;
      par=tmp_2;
      tmp=floor(par); //191203to
    );
    if(tmp<length(Houkou),
      tmp1=Houkou_tmp;
      tmp2=Houkou_(tmp+1);
    ,
      tmp1=Houkou_(tmp-1);
      tmp2=Houkou_tmp;
    );
    vec=(tmp2-tmp1)/|tmp2-tmp1|;
    gG=Circledata("",[pP,size*cos(angle)],["Num=10","nodata"]);
    tmp1=Intersectcrvspp(Houkou,gG);
    if(length(tmp1)==0,
      println("Arrowhead may be too large (no intersect)");
    ,
      tmp=select(tmp1,#_2<par); //191208from
      if(length(tmp)>0,
        tmp=sort(tmp,[-#_2]);
        pC=tmp_1_1;
      ,
        if(Norm(Ptend(direction)-Ptstart(direction))>Eps,
          tmp=sort(tmp1,[#_2]);
          pC=2*pP-tmp_1_1;
        ,
          tmp=sort(tmp1,[-#_2]);
          pC=tmp_1_1;
        );
      ); //191208to
      Houkou=pP-pC;
      hflg=1;
    );
  );
  if(hflg>=1,
    Ev=-Houkou/|Houkou|;
    Nv=[-Ev_2, Ev_1];    
    pA=pP+size*cos(angle)*Ev+size*sin(angle)*Nv;
    pB=pP+size*cos(angle)*Ev-size*sin(angle)*Nv;
    if(hflg==2,
      pC=(pA+pB)/2;
    );
    pC=pC+cut*(pP-pC);
    tmp=(pP-(pA+pB)/2);
    tmp=(1-segpos)*tmp;
    pP=Translatepoint(pP,tmp);
    pA=Translatepoint(pA,tmp);
    pB=Translatepoint(pB,tmp);
    pC=Translatepoint(pC,tmp);
    SCALEY=scaley;
    out=apply([pA,pP,pB,pC,pA],LLcrd(#));
  );
  out;
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
Arrowhead(nm,pointorg,directionorg,optionsorg):=(//191129remade
//help:Arrowhead("1",B,B-A);
//help:Arrowhead("2",[1,2],"gr1");
//help:Arrowhead("3",Ptend("gr1"),"gr1");
//help:Arrowhead(options=[size(1),angle(18),position(1),cut(0),"Line=n(y)"]);
   regional(Eps,name,Ltype,Noflg,opstr,opcindy,color,eqL,line,direction,
         point,options,pP,Houkou,ptstr,hostr,tmp,tmp1,tmp2,list);
  Eps=10^(-4);
  name="arh"+nm; //181018
  ArrowheadNumber=ArrowheadNumber+1;
  point=Lcrd(pointorg); //210216
  direction=directionorg; //211217from
  if(isstring(direction),
    if(indexof(direction,"Invert")>0,
      tmp=parse(direction);
      direction=replace(direction,[["(",""],[")",""]]);
      Listplot("-"+direction,tmp,["nodisp"]);
    );
  ); //211217to
  options=optionsorg;
  tmp=Divoptions(options);
  Ltype=tmp_1;
  Noflg=tmp_2;
  color=tmp_(length(tmp)-2);
  eqL=tmp_5;
  line="N";
  forall(eqL,
     tmp=Strsplit(#,"=");
     tmp1=substring(tmp_1,0,1);
     tmp2=substring(tmp_2,0,1);
     if(Toupper(tmp1)=="L",
       line=Toupper(tmp2);
       options=remove(options,[#]);
     );
  );
   list=Arrowheaddata(point,direction,options);
  if(length(point)>1, //210724from
    if(!Inwindow(point),Noflg=2);
    if(isstring(direction),
      if(|Ptend(direction)-point|<Eps,point=1);
    );
  ); //210724to
  if(Noflg<3,
    tmp=name+"="+Textformat(list,10)+";"; //210311
    parse(tmp);
    if(isstring(Ltype),
      if(line=="N",
        fillpoly(apply(list,Pcrd(#)),color->color);
        if(Noflg==0,
          if(isstring(direction), //210215,210724
            if(ispoint(point) % islist(point), //201214from
              if(|point-Ptend(direction)|<Eps,point=1);
            );  //201214to
            if(point==1, //191202from
              if(Norm(Ptend(direction)-Ptstart(direction))>Eps,
                tmp=select(GCLIST,#_1==direction); //201106from
                tmp1=tmp_1;
                tmp2=Nearestpt(list_4,direction);
                tmp2=tmp2_1; //201214[2lines]
                Partcrv("-"+direction,Ptstart(direction),tmp2,direction,["nodisp","Msg=n"]);
              ); //201106
            );
          );  //210215
          Listplot("-arh"+nm,list,["dr,0.1","Color="+text(color),"Msg=n"]);//191202
          Shade(["arh"+nm],["Color="+text(color)]);
        );
      ,
        Listplot("-arh"+nm,list_(1..3),concat(options,["Msg=n"]));
      );
   );
  );
  list; //191202
);
////%Arrowhead end////

////%Arrowdata start//// 191119 (Arrowdataseg,Arrowdatacrv)
Arrowdata(ptlist):=Arrowdataseg(ptlist);
Arrowdata(Arg1,Arg2):=Arrowdataseg(Arg1,Arg2);
Arrowdata(nm,ptlistorg,optionsorg):=(
//help:Arrowdata("1",[A,B]);
//help:Arrowdata("2",[p1,p2]);
//help:Arrowdata(options=[size(1),angle(18),pos(1),cut(0),"Cutend=0,0","Coord=p/l"]);
//help:Arrowdata(optionsadded=["line"]);
  Arrowdataseg(nm,ptlistorg,optionsorg);
);
////%Arrowdata end////
////%Arrowdata start//// 191119 (Arrowdataseg,Arrowdatacrv)
Arrowdata(ptlist):=Arrowdataseg(ptlist);
Arrowdata(Arg1,Arg2):=Arrowdataseg(Arg1,Arg2);
Arrowdata(nm,ptlistorg,optionsorg):=(
//help:Arrowdata("1",[A,B]);
//help:Arrowdata("2",[p1,p2]);
//help:Arrowdata(options=[size(1),angle(18),pos(1),cut(0),"Cutend=0,0","Coord=p/l"]);
//help:Arrowdata(optionsadded=["line"]);
  Arrowdataseg(nm,ptlistorg,optionsorg);
);
////%Arrowdata end////

////%Oldarrowdata start////
Oldrrowdata(ptlist):=Oldarrowdata(ptlist,[]);  //181110from
Oldrrowdata(Arg1,Arg2):=(
  regional(name);
  if(isstring(Arg1),
    Oldarrowdata(Arg1,Arg2,[]);
  ,
    name="";
    forall(Arg1,
      if(ispoint(#),
        name=name+#.name; //190505
      );
    );
    Oldarrowdata(name,Arg1,Arg2);
  );
);  //181110to
Oldarrowdata(nm,ptlistorg,optionsorg):=(
// help:Arrowdata("1",[A,B]);
// help:Arrowdata("1",[pt1,pt2]);
// help:Arrowdatacrv(options=[size(1),angle(18),pos(1),cut(0),"Cutend=0,0","Coord=p/l"]);
// help:Arrowdatacrv(optionsadded=["line"]);
  regional(options,Ltype,Noflg,name,opstr,opcindy,eqL,reL,strL,color,size,coord,
      flg,lineflg,cutend,tmp,tmp1,tmp2,pA,pB,angle,segpos,cut,scaley,ptlist);
  name="ar"+nm;
  scaley=SCALEY; //190412
  SCALEY=1; //100114
  ptlist=[];
  forall(ptlistorg,
    if(ispoint(#),tmp=[#.x, scaley*#.y], tmp=[#_1,scaley*#_2]);
    ptlist=append(ptlist,tmp);
  );
//  ptlist=apply(ptlistorg,[#_1,scaley*#_2]); //190412
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
    SCALEY=scaley;
    pA=Pcrd(ptlist_1); pB=Pcrd(ptlist_2);
    SCALEY=1;
  );//181018to
  if(Noflg<3,
    println("generate Arrowdata "+name);
    tmp=name+"="+Textformat([pA,pB],5)+";";
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
      Listplot("-ar"+nm,[LLcrd(pA),LLcrd(pB)],concat(options,["Msg=n"]));
      Arrowhead(nm,pA+segpos*(pB-pA),pB-pA,options); //181110
    ,
      if(Noflg==1,Ltype=0);
    );
  );
  SCALEY=scaley; //200114
  [Lcrd(pA),Lcrd(pB)];
);
////%Oldarrowdata end////

////%Arrowdataseg start////
Arrowdataseg(ptlist):=Arrowdataseg(ptlist,[]); //181110from
Arrowdataseg(Arg1,Arg2):=(
  regional(name);
  if(isstring(Arg1),
    Arrowdataseg(Arg1,Arg2,[]);
  ,
    name="";
    forall(Arg1,
      if(ispoint(#),
        name=name+#.name; //190505
      );
    );
    Arrowdataseg(name,Arg1,Arg2);
  );
);  //181110from
Arrowdataseg(nm,ptlistorg,optionsorg):=(
//  help:Arrowdataseg("1",[pt1,pt2]);
//  help:Arrowdataseg(options=[size(1),angle(18),pos(1),cut(0),"Cutend=0,0","Line=n(y)"]);
  regional(options,Ltype,Noflg,opstr,opcindy,eqL,reL,strL,color,size,lineflg,
      flg,cutend,tmp,tmp1,tmp2,pA,pB,pC,angle,segpos,cut,scaley,Ev,Nv,pP,ptlist);
  scaley=SCALEY; //190412
  SCALEY=1; //200114
  ptlist=[];
  forall(ptlistorg,
    if(ispoint(#),tmp=[#.x, #.y], tmp=[#_1,scaley*#_2]);
    ptlist=append(ptlist,tmp);
  );
  pA=ptlist_1; pB=ptlist_2;
  options=optionsorg;
  tmp=Divoptions(options);
  Ltype=tmp_1;
  Noflg=tmp_2;
  eqL=tmp_5;
  reL=tmp_6;
  strL=tmp_7;
  color=tmp_(length(tmp)-2);
  opstr=tmp_(length(tmp)-1);
  opcindy=tmp_(length(tmp));
  size=0.2*YaSize*1/2.54*1000/MilliIn; 
  angle=YaAngle*pi/180;
  segpos=YaPosition;
  cut=YaCut;
  if(length(reL)>=1,
    size=0.2*reL_1*1/2.54*1000/MilliIn; 
  );
  if(length(reL)>=2,
    if(reL_2<2.5,angle=reL_2*YaAngle,angle=reL_2);
    angle=angle*pi/180;
  );
  if(length(reL)>=3,
    segpos=reL_3;
  );
  if(length(reL)>=4,
    cut=reL_4;
  );
  options=remove(options,reL); //191202
  cutend=[0,0];//180719
  lineflg=0;
  forall(eqL,
    tmp=Strsplit(#,"=");
    tmp1=Toupper(substring(tmp_1,0,2));
    tmp2=tmp_2;
    if(tmp1=="CU",//180719from
      tmp2=replace(tmp2,"[","");
      tmp2=replace(tmp2,"]","");
      cutend=tokenize(tmp2,",");
      if(length(cutend)==1,cutend=[cutend_1,cutend_1]);
    );
    if(tmp1=="LI",//190504from
      tmp2=Toupper(substring(tmp2,0,1));
      if(tmp2=="Y",lineflg=1);
    );//190504to
  );
  tmp=pB-pA;
  tmp=tmp/|tmp|;
  pA=ptlist_1+tmp*cutend_1;
  pB=ptlist_2-tmp*cutend_2;
  pP=pA+segpos*(pB-pA);
  Ev=-1/|pB-pA|*(pB-pA); Nv=[-Ev_2, Ev_1];
  tmp1=pP+size*cos(angle)*Ev+size*sin(angle)*Nv;
  tmp2=pP+size*cos(angle)*Ev-size*sin(angle)*Nv;
  pC=pP+(1-cut)*((tmp1+tmp2)/2-pP);
  ArrowheadNumber=ArrowheadNumber+1;
  if(Noflg<2,
    if(lineflg==1,
      Listplot("-ar"+nm+"h",[tmp1,pP,tmp2],append(options,"Msg=n")); //210522
    ,
      Listplot("-ar"+nm+"h",[tmp1,pP,tmp2,pC,tmp1],["dr,0.1","Color="+color,"Msg=n"]); //210522
      Shade(["ar"+nm+"h"],[Ltype,"Color="+color]); // no ketjs
   //tmp=Colorcmyk2rgb(color); // only ketjs 220819[2lines]
   //fillpoly(parse("ar"+nm+"h"),color->tmp); // only ketjs //210522, dbg
    );
    if(lineflg==0,
      if(segpos==1,pB=pC); //191202
    );
    Listplot("-ar"+nm,[pA,pB],[Ltype,"Color="+color,"Msg=n"]); 
  );
  SCALEY=scaley; //200114
  [LLcrd(pA),LLcrd(pB)];
);
////%Arrowdataseg end////

////%Anglemark start//// 221120
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
    tmp=Textformat(plist,10);
    tmp=replace(tmp,",","");
    nm=substring(tmp,1,length(tmp)-1);
    Anglemark(nm,plist,options);
  );
);// to
Anglemark(nm,plistorg,optionsorg):=( //221120
//help([A,B,C],["E=\theta",2]);
//help:Anglemark("1",[A,B,C],["E=1.2,\theta",2]);
// help:Anglemark("1",[A,B,2*pi]);
//help:Anglemark(options=[size,"E/L=(sep,)letter"]);
  regional(name,options,Out,pB,pA,pC,Ctr,ra,
           sab,sac,ratio,opstr,Bname,Bpos,Bstr,
           color,color4,Brat,tmp,tmp1,tmp2,
           Num,opcindy,Ltype,eqL,realL,Rg,Th,
           Noflg,Msg,scaley,plist);
  name="ag"+nm;
  options=optionsorg; //200619
  ra=0.5;
  tmp=Divoptions(options);
  Ltype=tmp_1;
  Noflg=tmp_2;
  color=tmp_(length(tmp)-2);color4=Colorrgb2cmyk(color); //200629
  opcindy=tmp_(length(tmp));
  eqL=tmp_5;
  realL=tmp_6;
  Bname="";
  Brat=1.2; //180530
  Num=20;
  Msg="Y";
  // Msg="N"; //only ketjs
  opstr="";
  if(length(realL)>0,
    ra=realL_1*ra;
    opstr=","+text(realL_1);//180530
  );
  forall(eqL,
    tmp=indexof(#,"="); //200617[2lines]
    tmp=[substring(#,0,tmp-1),substring(#,tmp,length(#))];
    tmp1=Toupper(substring(tmp_1,0,1));
    if((tmp1=="L")%(tmp1=="E"),
      if(tmp1=="L",Bname="L");
      if(tmp1=="E",Bname="E");
      tmp2=tmp_2;
      tmp=indexof(tmp2,",");
      if((tmp==0)%(substring(tmp2,tmp-2,tmp-1)=="\"), //200710
        Bstr=tmp2;
      ,
        Bstr=substring(tmp2,tmp,length(tmp2)); //200201
        tmp1=parse(substring(tmp2,0,tmp-1));
        Brat=tmp1*Brat;
      );
      options=remove(options,[#]); //200619
    );
    if(tmp1=="M", //190206from
      Msg=Toupper(substring(tmp_2,0,1));
    ); //190206to
  );
  plist=apply(plistorg,Pcrd(#)); //221120[2lines]
  pB=plist_1; pA=plist_2; pC=plist_3;
  scaley=SCALEY; //191231[2lines]
  SCALEY=1;
  sab=pB-pA;
  Ctr=pA;
  sac=pC-pA;
  Rg=[arctan2(sab)+0,arctan2(sac)+0]; //22112to 
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
    if(Noflg<3,
      if(Msg=="Y", //190206
        println("generate anglemark "+name+" and m"+name); //200610
      );
      tmp1=apply(Out,Pcrd(#));
      tmp=name+"="+Textformat(tmp1,10)+";";
      parse(tmp);
      tmp=Textformat(plist,10); //no ketjs on
      tmp1=substring(tmp,1,length(tmp)-1);
      tmp=name+"=Anglemark("+tmp1+opstr+")";
      GLIST=append(GLIST,tmp); //no ketjs off
    );
    if(Noflg<3, //190818
      if(isstring(Ltype),
        if((Noflg==0)&(color4!=KCOLOR), //180904 //no ketjs on
          Texcom("{");Com2nd("Setcolor("+color4+")");//180722
        ); //no ketjs off
        Ltype=Getlinestyle(text(Noflg)+Ltype,name);
        if((Noflg==0)&(color4!=KCOLOR), //180904 //no ketjs on
          Texcom("}");//180722
        ); //no ketjs off
      ,
        if(Noflg==1,Ltype=0);
      );
      GCLIST=append(GCLIST,[name,Ltype,opcindy]);
    );
  );
  SCALEY=scaley;  //191231
  tmp1=Ctr+Brat*ra*[cos(Th),sin(Th)];
  Bpos=LLcrd(tmp1);
  options=remove(options,realL); //200619[3lines]
  if(Bname=="L",Letter(Bpos,"c",Bstr,options)); 
  if(Bname=="E",Expr(Bpos,"c",Bstr,options));
  parse("m"+name+"="+Textformat(Bpos,10)+";"); //200610
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
    tmp=Textformat(plist,10);
    tmp=replace(tmp,",","");
    nm=substring(tmp,1,length(tmp)-1);
    Paramark(nm,plist,options);
  );
);// to
Paramark(nm,plist,optionsrog):=(
//help:Paramark("1",[p1,p2,p3],["E=\theta"]);
  regional(name,options,Out,pB,pA,pC,ra,sab,sac,ratio,opstr,Bname,Bpos,Bstr,
         Brat,tmp,tmp1,tmp2,Ltype,Noflg,eqL,realL,opcindy,color,color4,sc,Msg,scaley);
  name="pm"+nm;
  options=optionsrog; //200619
  tmp=Divoptions(options);
  Ltype=tmp_1;
  Noflg=tmp_2;
  color=tmp_(length(tmp)-2);color4=Colorrgb2cmyk(color); //200629
  opcindy=tmp_(length(tmp));
  opstr=tmp_(length(tmp)-1); //200629
  eqL=tmp_5;
  realL=tmp_6;
  ra=0.5;
  Msg="Y";
  // Msg="N"; //only ketjs
  Brat=1.2;
  if(length(realL)>0,
    tmp=realL_1;
    ra=tmp*ra;
  );
  forall(eqL,
    tmp=Strsplit(#,"=");
    tmp1=Toupper(substring(tmp_1,0,1));
    if((tmp1=="L")%(tmp1=="E"),
      if(tmp1=="L",Bname="L");
      if(tmp1=="E",Bname="E");
      tmp2=tmp_2;
      tmp=indexof(tmp2,",");
      if((tmp==0)%(substring(tmp2,tmp-2,tmp-1)=="\"), //200710
        Bstr=tmp2;
      ,
        Bstr=substring(tmp2,tmp,lenght(tmp2));
        tmp1=parse(substring(tmp2,0,tmp-1));
        Brat=tmp1*Brat;
      );
      options=remove(options,[#]); //200619
    );
    if(tmp1=="M", //190206from
      Msg=Toupper(substring(tmp_2,0,1));
    ); //190206to
  );
  pB=Pcrd(plist_1); pA=Pcrd(plist_2); pC=Pcrd(plist_3);
  scaley=SCALEY; //191231[2lines]
  SCALEY=1;
  sab=pB-pA;
  Ctr=pA;
  Out=[];
  Out=append(Out,pA+ra*(pB-pA)/|pB-pA|);
  Out=append(Out,pA+ra*(pB-pA)/|pB-pA|+ra*(pC-pA)/|pC-pA|);
  Out=append(Out,pA+ra*(pC-pA)/|pC-pA|);
  Bpos=pA+Brat*ra*(pB-pA)/|pB-pA|+Brat*ra*(pC-pA)/|pC-pA|;
  if(Noflg<3,
    if(Msg=="Y", //190206
      println("generate paramark "+name+" and "+"m"+name);
    );
    tmp1=apply(Out,Pcrd(#));
    tmp=name+"="+Textformat(tmp1,10)+";"; //190415
    parse(tmp);
    tmp=Textformat(plist,10);
    tmp1=substring(tmp,1,length(tmp)-1);//210315 //no ketjs on
    tmp=name+"=Paramark("+tmp1+opstr+")";
    GLIST=append(GLIST,tmp); //no ketjs off
  );
  if(Noflg<3, //190818
    if(isstring(Ltype),
      if((Noflg==0)&(color4!=KCOLOR), //180904 //no ketjs on
        Texcom("{");Com2nd("Setcolor("+color4+")");//180722
      ); //no ketjs off
      Ltype=Getlinestyle(text(Noflg)+Ltype,name);
      if((Noflg==0)&(color4!=KCOLOR), //180904 //no ketjs on
        Texcom("}");//180722
      ); //no ketjs off
    ,
      if(Noflg==1,Ltype=0);
    );
    GCLIST=append(GCLIST,[name,Ltype,opcindy]);
  );
  SCALEY=scaley;  //191231
  tmp1=Out_2; //200629
  Bpos=LLcrd(tmp1);
  options=remove(options,realL); //200619[3lines]
  if(Bname=="L",Letter(Bpos,"c",Bstr,options));
  if(Bname=="E",Expr(Bpos,"c",Bstr,options));
  parse("m"+name+"="+Textformat(Bpos,10)+";"); //200629
  Out;
);
////%Paramark end////

////%Makebowdata start////
Makebowdata(pA,pB,Hgt):=(
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
////%Makebowdata end////

////%Bowdata start////
Bowdata(plist):=Bowdata(plist,[]);
Bowdata(plist,options):=(
  regional(nm,tmp);
  if(islist(plist), // 16.12.04from
    tmp=Textformat(plist,10);
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
//help:Bowdata("1",[C,A],[2,1.2,"Expr=10","da"]);
//help:Bowdata("2",[A,B],["Expr=t0n3,a"]);
//help:Bowdata("3",[A,B],["Exprrot=t0n2r,a"]);
//help:Bowdata(options1=["Num=(24)"]);
//help:Bowdata(options2=["Size=","Textcolor="]);
  regional(name,Out,pB,pA,pC,ra,tmp,tmp1,tmp2,Ltype,eqL,realL,
    Bname,Bpos,Th,Cut,Num,Hgt,opstr,opcindy,Ydata,Msg,tcolor,
    Th1,Th2,Noflg,Bops,color,Bstr,flg,tv,mv,rev);
  name="bw"+nm;
  tmp=Divoptions(options);
  Ltype=tmp_1;
  Noflg=tmp_2;
  color=tmp_(length(tmp)-2);color4=Colorrgb2cmyk(color); //200629
  opstr=tmp_(length(tmp)-1);
  opcindy=tmp_(length(tmp));
  eqL=tmp_5;
  realL=tmp_6;
  pA=Pcrd(plist_1); pB=Pcrd(plist_2);
  scaley=SCALEY; //191231[2lines]
  SCALEY=1;
  Hgt=1/2*|pB-pA|*0.2;
  Cut=0;
  Num=24;
  tcolor="";
  Bname="";
  Msg="Y";  //190206
  // Msg="N"; //only ketjs
  if(length(realL)>0,
    Hgt=realL_1*Hgt; // 15.04.12
    if(length(realL)>1,Cut=realL_2);
  );
  forall(eqL,
    tmp=indexof(#,"="); //200617[2lines]
    tmp=[substring(#,0,tmp-1),substring(#,tmp,length(#))];
    tmp1=Toupper(substring(tmp_1,0,1));
    if((tmp1=="L")%(tmp1=="E"),
      if(tmp1=="L",
        if(indexof(#,"rot")>0,
          Bname="Lr";
        ,
          Bname="L";
        );
      );
      if(tmp1=="E",
        if(indexof(#,"rot")>0,
          Bname="Er";
        ,
          Bname="E";
        );
      );
      tmp2=tmp_2;
      tmp=indexof(tmp2,",");
      if((tmp==0)%(substring(tmp2,tmp-2,tmp-1)=="\"), //200710
        Bops="";
        Bstr=tmp2;
      ,
        Bops=substring(tmp2,0,tmp-1);
        Bstr=substring(tmp2,tmp,length(tmp2));
      );
      eqL=remove(eqL,[#]);
    );
    if(tmp1=="N", //190206from
      Num=parse(tmp_2);
      eqL=remove(eqL,[#]);
    );
    if(tmp1=="T", //190206from
      tcolor="Color="+tmp_2;
      eqL=remove(eqL,[#]);
    );
    if(tmp1=="M", //190206from
      Msg=Toupper(substring(tmp_2,0,1));
      eqL=remove(eqL,[#]);
    ); //190206to
  );
  if(length(tcolor)>0,eqL=append(eqL,tcolor));
  Ydata=Makebowdata(pA,pB,Hgt); 
  pC=Ydata_1; ra=Ydata_2;
  Th=(Ydata_3+Ydata_4)*0.5;
  BOWMIDDLE=[pC_1+ra*cos(Th),pC_2+ra*sin(Th)]; 
  BOWMIDDLE=re(BOWMIDDLE); //191231from
  Bpos=BOWMIDDLE;
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
    forall(0..(floor(Num/2)),
      tmp=Th1+#*(Th2-Th1)/(Num/2);
      tmp1=append(tmp1,pC+ra*[cos(tmp),sin(tmp)]);
    );
    Th1=Th+Cut/(2*ra);
    Th2=Ydata_4;
    tmp2=[];
    forall(0..(floor(Num/2)),
      tmp=Th1+#*(Th2-Th1)/(Num/2);
      tmp2=append(tmp2,pC+ra*[cos(tmp),sin(tmp)]);
    );
    Out=[tmp1,tmp2];
  );
  if(Noflg<3,
    if(Msg=="Y", //190206
      print("generate bowdata "+name); 
      println(" BOWMIDDLE="+BOWMIDDLE);//161031,190704
    );
    if(Measuredepth(Out)==1,Out=[Out]);
    tmp1=[];
    forall(Out,tmp2,
      tmp=apply(tmp2,Pcrd(#));
      tmp1=append(tmp1,tmp);
    );
    if(length(tmp1)==1,tmp1=tmp1_1); //200421
    tmp=name+"="+Textformat(tmp1,10)+";";
    parse(tmp);
    tmp=Textformat(plist,10);
    tmp1=substring(tmp,1,length(tmp)-1); //no ketjs on
    tmp=name+"=Bowdata("+tmp1+opstr+")";
    GLIST=append(GLIST,tmp); //no ketjs off
  );
  if(Noflg<3, //190818
    if(isstring(Ltype),
      if((Noflg==0)&(color4!=KCOLOR), //180904 //no ketjs on
        Texcom("{");Com2nd("Setcolor("+color4+")");//180722
      ); //no ketjs off
      Ltype=Getlinestyle(text(Noflg)+Ltype,name);
      if((Noflg==0)&(color4!=KCOLOR), //180904 //no ketjs on
        Texcom("}");//180722 
      ); //no ketjs off
    ,
      if(Noflg==1,Ltype=0);
    );
    GCLIST=append(GCLIST,[name,Ltype,opcindy]);
  );
  SCALEY=scaley;
  if(pB_1<pA_1,
    tmp=pA;pA=pB;pB=tmp
  ,
    if(|pB_1-pA_1|<10^(-5),
      if(pB_2<pA_2,
        tmp=pA;pA=pB;pB=tmp
      );
    );
  );
  flg=""; //200419from
  tmp1=""; tmp2=""; rev=1;
  forall(1..(length(Bops)),
    tmp=substring(Bops,#-1,#);
    if(contains(["t","n","r"],tmp),
      if(tmp=="r",
        rev=-1;
      ,
        flg=tmp;
      );
    ,
      if(flg=="t",tmp1=tmp1+tmp);
      if(flg=="n",tmp2=tmp2+tmp);
    );
  );
  tv=MEMORI*(pB-pA)/|pB-pA|;
  tmp=BOWMIDDLE-(pA+pB)/2;
  nv=MEMORI*tmp/|tmp|;
  if(length(tmp1)>0,tmp1=parse(tmp1),tmp1=0);
  if(length(tmp2)>0,tmp2=parse(tmp2),tmp2=0);
  Bpos=Bpos+tmp1*tv+tmp2*nv;
  Bpos=LLcrd(Bpos);
  flg=0;
  if(Bname=="L",Letter(Bpos,"c",Bstr,eqL);flg=1);
  if(Bname=="E",Expr(Bpos,"c",Bstr,eqL);flg=1);
  if(flg==0,
    if(rev==1,tmp="t0n0",tmp="t0n0r"); // no ketjs on
    if(Bname=="Lr",Letterrot(Bpos,pB-pA,tmp,Bstr,eqL));
    if(Bname=="Er",Exprrot(Bpos,pB-pA,tmp,Bstr,eqL)); // no ketjs off
  ); //200419to
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
  forall(1..(round((t2-initt)/dt)), //190523
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
  forall(1..(round((initt-t1)/dt)), //190523
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
                  sel,tmp,tmp1,tmp2,tmp3,color,color4);
  name="de"+nm;
  tmp=Divoptions(options);
  Ltype=tmp_1;
  Noflg=tmp_2;
  eqL=tmp_5;
  color=tmp_(length(tmp)-2);color4=Colorrgb2cmyk(color); //200629
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
    rng=rng+"="+Textformat([XMIN,XMAX],10);
  );
  deq=replace(deqorg,unicode("2018"),"`"); //190296//0416
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
    tmp=name+"="+Textformat(tmp1,10)+";"; //190415
    parse(tmp);
  );
  if((nn>0)&(Noflg<1), //190211 //no ketjs on
    tmp=Assign(deq);
    tmp=replace(deq,"'","`");
    tmp=name+"=Deqplot('"+tmp+"','"+rng+"',";
    tmp=tmp+format(initt,10)+","+Textformat(initf,10);
    tmp=tmp+","+text(sel)+",'Num="+text(Num)+"')";
    tmp=RSform(tmp);
    GLIST=append(GLIST,tmp);
  ); //no ketjs off
  if((nn>0)&(Noflg<3), //190211
    if(isstring(Ltype),
      if((Noflg==0)&(color4!=KCOLOR), //180904 //no ketjs on
        Texcom("{");Com2nd("Setcolor("+color4+")");//180722
      ); //no ketjs off
      Ltype=Getlinestyle(text(Noflg)+Ltype,name);
      if((Noflg==0)&(color4!=KCOLOR), //180904 //no ketjs on
        Texcom("}");//180722
      ); //no ketjs off
    ,
      if(Noflg==1,Ltype=0);
    );
    GCLIST=append(GCLIST,[name,Ltype,opcindy]);
  );
);
////%Deqplot end////

////%Enclosing start////
Enclosing(nm,plist):=Enclosing2(nm,plist,[]);//180706[2lines]
Enclosing(nm,plistorg,options):=Enclosing2(nm,plistorg,options);
Enclosing2(nm,plist):=Enclosing2(nm,plist,[]);
Enclosing2(nm,plistorg,options):=(
//help:Enclosing("1",["sg2","gr1","Invert(sg2)"]);
//help:Enclosing(options=[startpoint,epspara(1)]);
  regional(name,plist,AnsL,Start,Eps,Eps1,Eps2,flg,Fdata,Gdata,KL,
      t1,t2,tst,ss,ii,nn,nxtno,Ltype,Noflg,realL,eqL,opstr,opcindy,
      tmp,tmp1,tmp2,tmp3,tmp4,color,color4,p1,p2);
  if(substring(nm,0,1)=="-",  //201110from
    name=substrin(nm,1,length(nm));
  ,
    name="en"+nm;
  );  //201110to
  plist=plistorg;
  tmp=Divoptions(options);
  Ltype=tmp_1;
  Noflg=tmp_2;
  eqL=tmp_5;
  realL=tmp_6;
  color=tmp_(length(tmp)-2);color4=Colorrgb2cmyk(color); //200629
  opstr=tmp_(length(tmp)-1);
  opcindy=tmp_(length(tmp));
  Eps=10^(-5); // 16.12.05
  Eps1=0.01;
  Eps2=0.1;
  Start=[];
  flg=0;
  forall(realL,
    if(isList(#) % ispoint(#),
      Start=Lcrd(#); // 18.02.02
    ,
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
    KL=Intersectcurvespp(Fdata,Gdata);
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
      tmp1=parse(Fdata); //200803from
      tmp2=parse(Gdata);
      if(|tmp2_1-tmp1_(-1)|<Eps,
        if(nn<length(plist), //211217from
          AnsL=concat(AnsL,tmp1);
        ,
          tmp3=Partcrv("",AnsL_(-1),tmp2_1,tmp1,["nodata"]);
          AnsL=concat(AnsL,tmp3);
        );  //211217fto
      ,  //200803to
        KL=Intersectcurvespp(Fdata,Gdata);
        if(length(KL)==0, 
          tmp2=Prepend(Op(length(tmp1),tmp),tmp2);
          Gdata=replace(Gdata,"(","");
          Gdata=replace(Gdata,")","");
          tmp=Gdata+"="+Textformat(tmp2,10)+";"; //190415
          parse(tmp);
          plist_nxtno=Gdata;
          t2=Length(tmp1);
          p2=Pointoncurve(t2,Fdata); //180713
          ss=1; //18.02.02to
        ,
          KL=sort(KL,[#_2]);//180706
          tmp=parse(Fdata);
          tmp1=t1+Eps;
          tmp=select(KL,(#_2>tmp1)%((#_2>t1)&(|#_1-p1|>Eps1))); //210411from
          if(length(tmp)>0,
            KL=tmp;
          ,
            KL=KL;  //211002,1014
          ); //210411to
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
      AnsL=apply(1..(length(AnsL)),Pcrd(AnsL_#));
    );
  );
  AnsL=Unscaling(AnsL); //201110
  if(Noflg<3,
    println("generate Enclosing "+name);
    tmp=name+"="+Textformat(AnsL,10)+";"; //190415
    parse(tmp);
    tmp=parse(name); //210530[2lines]
    tmp=apply(tmp,LLcrd(#));
    Listplot("-"+name,tmp,["nodisp"]); //210421
  );
  if(Noflg<3, //190818
    if(isstring(Ltype),
      if((Noflg==0)&(color4!=KCOLOR), //180904 //no ketjs on
        Texcom("{");Com2nd("Setcolor("+color4+")");//180722
      ); //no ketjs off
      Ltype=Getlinestyle(text(Noflg)+Ltype,name);
      if((Noflg==0)&(color4!=KCOLOR), //180904 //no ketjs on
        Texcom("}");//180722
      ); //no ketjs off
    ,
      if(Noflg==1,Ltype=0);
    );
    GCLIST=append(GCLIST,[name,Ltype,opcindy]);
  );
  AnsL; //201110
);
////%Enclosing end////

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
          options=append(options,tmp2);
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
    color,color4,tmp,tmp1,tmp2,tmp3,namep,x1,y1,x2,y2,p1,p2, //180717
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
  color=tmp_(length(tmp)-2);color4=Colorrgb2cmyk(color); //200629
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
            if(!contains(pL,#.name), //190505
              pL=append(pL,#.name); //190505
            );
          );
        );
      );
    );
    forall(chkL,
      if(!contains(pL,#),pL=append(pL,#));
    );
    forall(pL,
      tmp=#+"="+Textformat(parse(#+".xy"),10);
      varL=append(varL,tmp);
    );
    tmp="reL="+Textformat(reL,10);
    varL=append(varL,tmp);
    if(fileflg=="M",
      fileflg="Y";
    ,
      tmp1="hatch"+nm+".txt";
      if(isexists(Dirwork,tmp1),
        tmp2=load(tmp1);
        if(length(tmp2)>0, //200509from
          tmp2=replace(tmp2,CRmark,"");
          tmp2=replace(tmp2,LFmark,"");
        ); //200509from
        tmp2=tokenize(tmp2,"//");
        tmp2=tmp2_(1..(length(tmp2)-1));
        if(tmp2==varL,
          wflg=0;
          if(isexists(Dirwork,fname),
            mkflg=0;
            ReadOutData(fname);
            tmp=name+"="+Textformat(parse(name),10)+";"; //190415
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
    tmp1=apply(AnsL,Textformat(#,10));
    tmp=name+"="+tmp1+";"; //190415
    parse(tmp);
  );
  if((Noflg<3)&(mkflg>-1),
    if(fileflg!="Y", //181102
      println("generate Hatchdata "+name);
      tmp=name+"="+Textformat(AnsL,10)+";"; //190415
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
  if((Noflg<3)&(mkflg>-1), //190818
    if(isstring(Ltype),
      if((Noflg==0)&(color4!=KCOLOR), //180904 //no ketjs on
        Texcom("{");Com2nd("Setcolor("+color4+")");//180722
      ); //no ketjs off
      Ltype=Getlinestyle(text(Noflg)+Ltype,name);
      if((Noflg==0)&(color4!=KCOLOR), //180904 //no ketjs on
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
  ptL=Intersectcurvespp(pstr,frwin);
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
          tmp=Intersectcurvespp("sgfrwin",pstr);
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
//help:Shade(["gr1"]);
// help:Shade(options=["Trim=(n)","Enc=(n)",First=(n)","Color=",Startpoint]);
//help:Shade(["gr2","Invert(sg1)"],["Enc=n","First=n","Ptshade=N"]); //201230
  regional(name,plist,jj,nn,trim,first,tmp,tmp1,tmp2,Noflg,
     opstr,opcindy,eqL,reL,Str,G2,flg,encflg,startpt,color,color4,ctr,ptshade);
  if(substring(nm,0,1)=="-", //200513from
    name=substring(nm,1,length(nm));
  ,
    name="shade"+nm;
  ); //200513to
  plist=plistorg;
  tmp=Divoptions(options);
  Noflg=tmp_2; //200512
  eqL=tmp_5; 
  reL=tmp_6;
  color=tmp_(length(tmp)-2); color4=Colorrgb2cmyk(color); //200618
  opstr=tmp_(length(tmp)-1);
  opcindy=tmp_(length(tmp));
  encflg=0; //201029
  tmp=select(plist,indexof(#,"Invert")>0); //180929from
  trim="N";
  first="N"; //191007
  ptshade="N"; //200513
  forall(eqL,
    tmp=Strsplit(#,"=");
    tmp1=Toupper(tmp_1);
    tmp2=Toupper(tmp_2);
    if(substring(tmp1,0,1)=="E",
      if(substring(tmp2,0,1)=="Y",
        encflg=1;
      );
    );
    if(substring(tmp1,0,1)=="T",
      trim=substring(tmp2,0,1);
    );
    if(substring(tmp1,0,1)=="F",
      first=substring(tmp2,0,1);
    );
    if(substring(tmp1,0,1)=="P", //200513[3lines]
      ptshade=Toupper(substring(tmp2,0,1));
    );
  );
  startpt=[];
  forall(reL,
    if(islist(#),
      startpt=#;
    );
  ); //180929to
//  if(length(color)==4, //180602from
//    tmp=Colorcmyk2rgb(color);
//  );
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
          Listplot("-"+name+text(ctr),tmp2,["nodisp"]); //190520
          plist_jj=name+text(ctr);
          ctr=ctr+1;
        );
      ); 
    );
  );//180613to
  if(flg==1,
    println("    Shade : some data not defined properly");
 ,
    if(Noflg<2, //200512
      G2=Joincrvs("1",plist,["nodata"]);
      G2=apply(G2,Pcrd(#));
      tmp1="fillpoly("+Textformat(G2,10)+opcindy+");";
      if(ptshade=="N", //200513from
        tmp=select(1..(length(GCLIST)),contains(plist,GCLIST_#_1)); //200715from
        if(length(tmp)>0,
          nn=min(tmp);
        ,
          nn=length(GCLIST)+1;
        );
        tmp2=GCLIST_(1..(nn-1));
        tmp2=append(tmp2,[tmp1,[5,0]]);
        GCLIST=concat(tmp2,GCLIST_(nn..(length(GCLIST))));
//        parse(tmp1);  //200715to
      ,
        PTSHADElist=append(PTSHADElist,[name,tmp1]);
      ); //200513to
    );
  );
  if(Noflg==0, //no ketjs on
    Str="Shade(";
    tmp1="list"+PaO();
    forall(plist,
      if(isstring(#),  // from 16.01.24
        if(length(#)>1,
          tmp1=tmp1+#+",";
        ,
          tmp1=tmp1+Dq+#+Dq+",";
        );
      ,
         tmp1=tmp1+"Listplot("+Textformat(#,10)+"),";
      ); //16.01.24to
    );
    Str=Str+substring(tmp1,0,length(tmp1)-1)+")"+")"; //180929 
    nn=length(COM2ndlist); //190311from
    if(first=="Y", //191007from
      jj=1;
    ,
      jj=nn;
      forall(plist,tmp1,
        tmp=select(1..nn,indexof(COM2ndlist_#,tmp1)>0);
        if(length(tmp)>0, //200715from
          jj=min(append(tmp,jj));
        ,
          jj=nn+1;
        ); //200715to
      );
      if(jj==0, jj=1); //191008
    ); //191007to
    if(color4!=KCOLOR, //200710from
      tmp1=["Texcom("+Dqq("{")+")","Setcolor("+color4+")",Str,"Texcom("+Dqq("}")+")"];
    ,
      tmp1=[Str];
    ); //200710to
    tmp2=COM2ndlist_(1..(jj-1));
    tmp=COM2ndlist_(jj..(length(COM2ndlist)));
    if(!islist(tmp),tmp=[tmp]);
    COM2ndlist=concat(tmp2,tmp1);
    COM2ndlist=concat(COM2ndlist,tmp); //190311to
  );//no ketjs off  
  SHADECTR=SHADECTR+1;
);
////%Shade end////

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
//help:Reflectpoint(A,B or [B]);
//help:Reflectpoint(A,[[2,3]]);
//help:Reflectpoint(A,[C,E]);
  regional(X1,X2,Y1,Y2,Us,Vs,Pt1,Pt2,Cx,Cy,flg,tmp);
  tmp=Lcrd(point);
  X1=tmp_1; Y1=tmp_2;
  if(!islist(symL), //210104from
    Pt1=Lcrd(symL);
    Pt2=Pt1;
  ,
    if(length(symL)==1,
      Pt1=Lcrd(symL_1);
      Pt2=Pt1;
    ,
      if(isreal(symL_1),
        Pt1=Lcrd(symL);
        Pt2=Pt1;
      ,
        Pt1=Lcrd(symL_1);
        Pt2=Lcrd(symL_2);
      );
    );
  ); //210104to
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
Rotatedata(nm,plist,angle,optionorg):=(
//help:Rotatedata("1",["crAB","pt1"],pi/3,[[1,5],"dr,2"]);
//help:Rotatedata("1",[[A.xy],[B.xy]],pi/3,[[1,5],"dr,2"]);
  regional(tmp,tmp1,tmp2,pdata,Theta,Pt,Cx,Cy,PdLL,PdL,options,
    opcindy,eqL,msgflg,ptL,Nj,Njj,Kj,Mj,X1,Y1,X2,Y2,
    Ltype,Noflg,name,color,color4);
  if(substring(nm,0,1)=="-", //210423from
    name=substring(nm,1,length(nm));
  ,
    name="rt"+nm;
  ); //210423to
  options=optionorg;
  Pt=[0,0];
  tmp=Divoptions(options);
  Ltype=tmp_1;
  Noflg=tmp_2;
  eqL=tmp_5;
  color=tmp_(length(tmp)-2);color4=Colorrgb2cmyk(color); //200626
  opcindy=tmp_(length(tmp));
  tmp1=tmp_6;
  if(length(tmp1)>0,Pt=Lcrd(tmp1_1));
  msgflg="Y"; //190425from
  forall(eqL,
    tmp=Strsplit(#,"=");
    tmp1=Toupper(substring(tmp_1,0,1));
    if(tmp1=="M",
      msgflg=Toupper(substring(tmp_2,0,1));
      options=remove(options,[#]);
    );
    if(tmp1=="S", //210423from
      options=remove(options,[#]);
    ); //210423to
  ); //190425to
  pdata=plist;
  if(isstring(pdata),pdata=[pdata]);
  if(!isstring(pdata_1) & Measuredepth(pdata)==1,
      pdata=[pdata];
  );
  if(isstring(angle),Theta=parse(angle),Theta=angle);
  Cx=Pt_1; Cy=Pt_2;
  PdL=[];
  ptL=[];
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
      if(length(tmp1)==1, //210423from
        Pointdata("-"+name,tmp1,optionorg);
      ,
        tmp2=concat(tmp2,[tmp1]);
        PdL=concat(PdL,tmp2);
      );  //210423to
    );
  );
  if(length(PdL)>0,
    if(Noflg<3,
      if(msgflg=="Y",
        println("generate Rotatedata "+name);
      );
      tmp1=[];
      forall(PdL,tmp2,
        tmp=apply(tmp2,Pcrd(#));
        tmp1=append(tmp1,tmp);
      );
      if(length(tmp1)==1,tmp1=tmp1_1);
      tmp=name+"="+Textformat(tmp1,10)+";"; //190415
      parse(tmp);
      tmp1=text(plist); //no ketjs on
      tmp1=RSform(tmp1,1);// 180602
      tmp=name+"=Rotatedata("+tmp1+","
        +Textformat(angle,10)+","+RSform(Textformat(Pt,10))+")"; //17.12.23
      GLIST=append(GLIST,tmp); //no ketjs off
    );
    if(Noflg<3, //190818
      if(isstring(Ltype),
        if((Noflg==0)&(color4!=KCOLOR), //180904 //no ketjs on
          Texcom("{");Com2nd("Setcolor("+color4+")");//180722
        ); //no ketjs off
        Ltype=Getlinestyle(text(Noflg)+Ltype,name);
        if((Noflg==0)&(color4!=KCOLOR), //180904 //no ketjs on
          Texcom("}");//180722
        ); //no ketjs off
      ,
        if(Noflg==1,Ltype=0);
      );
      GCLIST=append(GCLIST,[name,Ltype,opcindy]);
    );
  );
  pdL;
);
////%Rotatedata end////

////%Rotatedataadd start//// //210423
Rotatedataadd(nm,addstr,angle):=Rotatedataadd(nm,addstr,angle,[],[]);
Rotatedataadd(nm,addstr,angle,common):=Rotatedataadd(nm,addstr,angle,common,[]);
Rotatedataadd(nm,addstr,angle,common,optionsLorg):=(
//help:Rotatedataadd("1","ad1",pi/3);
//help:Rotatedataadd("1","ad1",pi/3,[[1,5],"dr,2"]);
  regional(name,optionsL,pdata,pltdataL,nn,tmp,tmp1,tmp2);
  name="ad"+nm;
  println("generate rotatedataadd "+name);
  optionsL=optionsLorg;
  if(length(optionsL)==0,
    tmp1=select(AddGraphData,#_1==addstr);
    tmp1=tmp1_1;
    optionsL=tmp1_(-1);
  ,
    tmp1=length(pltdataL);
    tmp2=length(optionsL);
    forall((tmp2+1)..(tmp1),optionsL=append(optionsL,[]));
  );
  pdata=parse(addstr);
  pltdataL=[];
  forall(1..(length(pdata)),nn,
    tmp=name+"n"+nn;
    tmp1=concat(optionsL_nn,["Msg=n"]);
    tmp1=concat(common,tmp1);
    Rotatedata("-"+tmp,pdata_nn,angle,tmp1);
    pltdataL=append(pltdataL,tmp);
  );
  tmp=apply(pltdataL,Dqq(#));
  tmp=name+"="+text(tmp)+";";
  parse(tmp);
  AddGraphData=append(AddGraphData,[name,addstr,pltdataL,common,optionsL]);
);
////%Rotatedataadd end////

////%Translatedata start////
Translatedata(nm,plist,mov):=Translatedata(nm,plist,mov,[]);
Translatedata(nm,plist,mov,optionorg):=(
//help:Translatedata("1",["gr1","pt1"],[1,2]);
  regional(options,tmp,tmp1,tmp2,pdata,Cx,Cy,PdL,Nj,Njj,Kj,eqL,
           opcindy,X2,Y2,Ltype,Noflg,name,color,color4,leveL,msgflg);
  if(substring(nm,0,1)=="-", //210423from
    name=substring(nm,1,length(nm));
  ,
    name="tr"+nm;
  ); //210423to
  options=optionorg; //190425
  tmp=Divoptions(options);
  Ltype=tmp_1;
  Noflg=tmp_2;
  eqL=tmp_5; //190424
  color=tmp_(length(tmp)-2); color4=Colorrgb2cmyk(color); //200618
  opcindy=tmp_(length(tmp));
  msgflg="Y"; //190425from
  forall(eqL,
    tmp=Strsplit(#,"=");
    tmp1=Toupper(substring(tmp_1,0,1));
    if(tmp1=="M",
      msgflg=Toupper(substring(tmp_2,0,1));
      options=remove(options,[#]);
    );
    if(tmp1=="S", //210423from
      options=remove(options,[#]);
    ); //210423to
  ); //190425to
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
      if(length(tmp1)==1, //210423from
        Pointdata("-"+name,tmp1,optionorg);
      ,
        tmp2=concat(tmp2,[tmp1]);
        PdL=concat(PdL,tmp2);
      );  //210423to
    );
  );
  if(length(PdL)>0,
    if(Noflg<3,
      if(msgflg=="Y", //190425
        println("generate Translatedata "+name);
      );
      tmp1=[];
      forall(PdL,tmp2,
        tmp=apply(tmp2,Pcrd(#));
        tmp1=append(tmp1,tmp);
      );
      if(length(tmp1)==1,tmp1=tmp1_1);
      tmp=name+"="+Textformat(tmp1,10)+";"; //190415
      parse(tmp);
      tmp1=text(plist); //no ketjs on
      tmp1=RSform(tmp1,1);// 180602
      tmp=name+"=Translatedata("+tmp1+","+RSform(Textformat(mov,10))+")";
      GLIST=append(GLIST,tmp); //no ketjs off
    );
    if(Noflg<3, //190818
      if(isstring(Ltype),
        if((Noflg==0)&(color4!=KCOLOR), //180904 //no ketjs on
          Texcom("{");Com2nd("Setcolor("+color4+")");//180722
        ); //no ketjs off
        Ltype=Getlinestyle(text(Noflg)+Ltype,name);
        if((Noflg==0)&(color4!=KCOLOR), //180904 //no ketjs on
          Texcom("}");//180722
        ); //no ketjs off
      ,
        if(Noflg==1,Ltype=0);
      );
      GCLIST=append(GCLIST,[name,Ltype,opcindy]);
    );
  );
  PdL;
);
////%Translatedata end////

////%Translatedataadd start//// //210423
Translatedataadd(nm,addstr,mov):=Translatedataadd(nm,addstr,mov,[],[]);
Translatedataadd(nm,addstr,mov,common):=Translatedataadd(nm,addstr,mov,common,[]);
Translatedataadd(nm,addstr,mov,common,optionsLorg):=(
//help:Translatedataadd("1","ad1",pi/3);
//help:Translatedataadd("1","ad1",pi/3,[[1,5],"dr,2"]);
  regional(name,optionsL,pdata,pltdataL,nn,tmp,tmp1,tmp2);
  name="ad"+nm;
  println("generate translateadd "+name);
  optionsL=optionsLorg;
  if(length(optionsL)==0,
    tmp1=select(AddGraphData,#_1==addstr);
    tmp1=tmp1_1;
    optionsL=tmp1_(-1);
  ,
    tmp1=length(pltdataL);
    tmp2=length(optionsL);
    forall((tmp2+1)..(tmp1),optionsL=append(optionsL,[]));
  );
  pdata=parse(addstr);
  pltdataL=[];
  forall(1..(length(pdata)),nn,
    tmp=name+"n"+nn;
    tmp1=concat(optionsL_nn,["Msg=y"]);
    tmp1=concat(common,tmp1);
    Translatedata("-"+tmp,pdata_nn,mov,tmp1);
    pltdataL=append(pltdataL,tmp);
  );
  tmp=apply(pltdataL,Dqq(#));
  tmp=name+"="+text(tmp)+";";
  parse(tmp);
  AddGraphData=append(AddGraphData,[name,addstr,pltdataL,common,optionsL]);
);
////%Translatedataadd end////

////%Scaledata start////
Scaledata(nm,plist,ratioV):=(
  regional(tmp);
  tmp=ratioV; //180603from
  if(!islist(tmp),tmp=[tmp,tmp]);
  tmp=Lcrd(tmp);//180603to
  Scaledata(nm,plist,tmp_1,tmp_2,[]);
);
Scaledata(nm,plist,Arg1,Arg2):=(
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
Scaledata(nm,plist,rx,ry,optionorg):=(
//help:Scaledata("1",["crAB","pt1"],3,2,[[0,0]]);
//help:Scaledata("1",["crAB","pt1"],2,[[0,0]]);
  regional(tmp,tmp1,tmp2,pdata,Theta,Pt,Cx,Cy,PdL,options,eqL,
      opcindy,Nj,Njj,Kj,X2,Y2,Ltype,Noflg,name,color,color4,msgflg);
  if(substring(nm,0,1)=="-", //210423from
    name=substring(nm,1,length(nm));
  ,
    name="sc"+nm;
  ); //210423to
  options=optionorg;
  Pt=[0,0];
  tmp=Divoptions(options);
  Ltype=tmp_1;
  Noflg=tmp_2;
  eqL=tmp_5;
  color=tmp_(length(tmp)-2);
  color4=Colorrgb2cmyk(color); //200618
  opcindy=tmp_(length(tmp));
  tmp1=tmp_6;
  if(length(tmp1)>0,
    Pt=Lcrd(tmp1_1);
  );
  msgflg="Y"; //190425from
  forall(eqL,
    tmp=Strsplit(#,"=");
    tmp1=Toupper(substring(tmp_1,0,1));
    if(tmp1=="M",
      msgflg=Toupper(substring(tmp_2,0,1));
      options=remove(options,[#]);
    );
    if(tmp1=="S", //210423from
      options=remove(options,[#]);
    ); //210423to
  ); //190425to
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
      if(length(tmp1)==1, //210423from
        Pointdata("-"+name,tmp1,optionorg);
      ,
        tmp2=concat(tmp2,[tmp1]);
        PdL=concat(PdL,tmp2);
      );  //210423to
    );
  );
  if(length(PdL)>0,
    if(Noflg<3,
      if(msgflg=="Y",
        println("generate Scaledata "+name);
      );
      tmp1=[];
      forall(PdL,tmp2,
        tmp=apply(tmp2,Pcrd(#));
        tmp1=append(tmp1,tmp);
      );
      if(length(tmp1)==1,tmp1=tmp1_1);
      tmp=name+"="+Textformat(tmp1,10)+";"; //190415
      parse(tmp);
      tmp1=text(plist); //no ketjs on
      tmp1=RSform(tmp1,1);// 180602
      tmp=name+"=Scaledata("+tmp1+","
        +Textformat(rx,10)+","+Textformat(ry,10)+","+RSform(Textformat(Pt,10))+")"; //17.12.23
      GLIST=append(GLIST,tmp); //no ketjs off
    );
    if(Noflg<3, //190818
      if(isstring(Ltype),
        if((Noflg==0)&(color4!=KCOLOR), //180904 //no ketjs on
          Texcom("{");Com2nd("Setcolor("+color4+")");//180722
        ); //no ketjs off
        Ltype=Getlinestyle(text(Noflg)+Ltype,name);
        if((Noflg==0)&(color4!=KCOLOR), //180904 //no ketjs on
          Texcom("}");//180722
        ); //no ketjs off
      ,
        if(Noflg==1,Ltype=0);
      );
      GCLIST=append(GCLIST,[name,Ltype,opcindy]);
    );
  );
  PdL;
);
////%Scaledata end////

////%Scaledataadd start//// //210423
Scaledataadd(nm,addstr,rx,ry):=Scaledataadd(nm,addstr,rx,ry,[],[]);
Scaledataadd(nm,addstr,rx,ry,common):=Scaledataadd(nm,addstr,rx,ry,common,[]);
Scaledataadd(nm,addstr,rx,ry,common,optionsLorg):=(
//help:Scaledataadd("1","ad1",0.5);
//help:Scaledataadd("1","ad1",[0.5,1],[[1,5],"dr,2"]);
  regional(name,optionsL,pdata,pltdataL,nn,tmp,tmp1,tmp2);
  name="ad"+nm;
  println("generate scaledataadd "+name);
  optionsL=optionsLorg;
  if(length(optionsL)==0,
    tmp1=select(AddGraphData,#_1==addstr);
    tmp1=tmp1_1;
    optionsL=tmp1_(-1);
  ,
    tmp1=length(pltdataL);
    tmp2=length(optionsL);
    forall((tmp2+1)..(tmp1),optionsL=append(optionsL,[]));
  );
  pdata=parse(addstr);
  pltdataL=[];
  forall(1..(length(pdata)),nn,
    tmp=name+"n"+nn;
    tmp1=concat(optionsL_nn,["Msg=n"]);
    tmp1=concat(common,tmp1);
    Scaledata("-"+tmp,pdata_nn,angle,tmp1);
    pltdataL=append(pltdataL,tmp);
  );
  tmp=apply(pltdataL,Dqq(#));
  tmp=name+"="+text(tmp)+";";
  parse(tmp);
  AddGraphData=append(AddGraphData,[name,addstr,pltdataL,common,optionsL]);
);
////%Scaledataadd end////

////%Reflectdata start////
Reflectdata(nm,plist,symL):=Reflectdata(nm,plist,symL,[]);
Reflectdata(nm,plist,symL,optionorg):=(
//help:Reflectdata("1",["crAB"],[C]);
//help:Reflectdata("1",["crAB"],[pt1,pt2]);
  regional(tmp,tmp1,tmp2,pdata,Us,Vs,Pt1,Pt2,Cx,Cy,PdL,options,eqL,
      opcindy,Nj,Njj,Kj,X1,Y1,X2,Y2,Ltype,Noflg,name,color,color4);
  if(substring(nm,0,1)=="-", //210423from
    name=substring(nm,1,length(nm));
  ,
    name="rt"+nm;
  ); //210423to
  options=optionorg;
  Pt=[0,0];
  tmp=Divoptions(options);
  Ltype=tmp_1;
  Noflg=tmp_2;
  eqL=tmp_5;
  color=tmp_(length(tmp)-2);color4=Colorrgb2cmyk(color); //200618
  opcindy=tmp_(length(tmp));
  msgflg="Y"; //190425from
  forall(eqL,
    tmp=Strsplit(#,"=");
    tmp1=Toupper(substring(tmp_1,0,1));
    if(tmp1=="M",
      msgflg=Toupper(substring(tmp_2,0,1));
      options=remove(options,[#]);
    );
  ); //190425to
  pdata=plist;
  if(isstring(pdata),pdata=[pdata]);
  if(!isstring(pdata_1) & Measuredepth(pdata)==1,
      pdata=[pdata];
  );
  PdL=[];
  forall(pdata,Njj,
    if(isstring(Njj),Kj=parse(Njj),Kj=Njj);
    if(Measuredepth(Kj)==1,Kj=[Kj]);
    tmp2=[];
    forall(Kj,Nj,
      tmp1=[];
      forall(Nj,
        tmp=Reflectpoint(#,symL);
        tmp1=append(tmp1,tmp);
      );
      if(length(tmp1)==1, //210423from
        Pointdata("-"+name,tmp1,optionorg);
      ,
        tmp2=concat(tmp2,[tmp1]);
        PdL=concat(PdL,tmp2);
      );  //210423to
    );
  );
  if(Noflg<3,
    if(msgflg=="Y",
      println("generate reflectdata "+name);
    );
    tmp1=[];
    forall(PdL,tmp2,
      tmp=apply(tmp2,Pcrd(#));
      tmp1=append(tmp1,tmp);
    );
    if(length(tmp1)==1,tmp1=tmp1_1);
    tmp=name+"="+Textformat(tmp1,10)+";"; //190415
    parse(tmp);
    tmp1=text(plist); //no ketjs on
    tmp1=RSform(tmp1,1);// 180602
    tmp=name+"=Reflectdata("+tmp1+","+RSform(Textformat(symL,10))+")";
     //171223
    GLIST=append(GLIST,tmp); //no ketjs off
  );
  if(Noflg<3, //190818
    if(isstring(Ltype),
      if((Noflg==0)&(color4!=KCOLOR), //180904 //no ketjs on
        Texcom("{");Com2nd("Setcolor("+color4+")");//180722
      ); //no ketjs off
      Ltype=Getlinestyle(text(Noflg)+Ltype,name);
      if((Noflg==0)&(color4!=KCOLOR), //180904 //no ketjs on
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

////%Reflectdataadd start//// //210423
Reflectdataadd(nm,addstr,symL):=Reflectdataadd(nm,addstr,symL,[],[]);
Reflectdataadd(nm,addstr,symL,common):=Reflectdataadd(nm,addstr,symL,common,[]);
Reflectdataadd(nm,addstr,symL,common,optionsLorg):=(
//help:Reflectdataadd("1","ad1",pi/3);
//help:Reflectdataadd("1","ad1",pi/3,[[1,5],"dr,2"]);
  regional(name,optionsL,pdata,pltdataL,nn,tmp,tmp1,tmp2);
  name="ad"+nm;
  println("generate reflectdataadd "+name);
  optionsL=optionsLorg;
  if(length(optionsL)==0,
    tmp1=select(AddGraphData,#_1==addstr);
    tmp1=tmp1_1;
    optionsL=tmp1_(-1);
  ,
    tmp1=length(pltdataL);
    tmp2=length(optionsL);
    forall((tmp2+1)..(tmp1),optionsL=append(optionsL,[]));
  );
  pdata=parse(addstr);
  pltdataL=[];
  forall(1..(length(pdata)),nn,
    tmp=name+"n"+nn;
    tmp1=concat(optionsL_nn,["Msg=n"]);
    tmp1=concat(common,tmp1);
    Reflectdata("-"+tmp,pdata_nn,symL,tmp1);
    pltdataL=append(pltdataL,tmp);
  );
  tmp=apply(pltdataL,Dqq(#));
  tmp=name+"="+text(tmp)+";";
  parse(tmp);
  AddGraphData=append(AddGraphData,[name,addstr,pltdataL,common,optionsL]);
);
////%Reflectdataadd end////

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
//help:Mkcircles();
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
      tmpstr=Textformat(#,10);
    );
    str=str+tmpstr+",";
  );
  str=substring(str,0,length(str)-1);
  str;
);
////%MakeRarg end////

////%Htickmark start//// 221201 major change
Htickmark(arglist):=Htickmark("",arglist,[]);
Htickmark(Arg1,Arg2):=(
  if(isstring(Arg1),
    Htickmark(Arg1,Arg2,[]);
  ,
    Htickmark("",Arg1,Arg2);
  );
);
Htickmark(nm,arglist,options):=(
//help:Htickmark([1,"1",2,"sw","2"]);
//help:Htickmark("1",[1,"1",3,"3"],["Color=red"]);
  regional(nn,tmp,tmp1,tmp2,tmp3,tmp4,
           tickL,orgL,mark);
  mark=MARKLEN/SCALEY;
  tickL=[];
  orgL=arglist;
  while(length(orgL)>0,
    if(length(orgL)==1,
      orgL=[];
    );
    if(length(orgL)==2,
      tmp1=orgL_1; tmp2="s1"; tmp3=orgL_2;
      tickL=concat(tickL,[tmp1,tmp2,tmp3]);
      orgL=[];
    );
    if(length(orgL)>=3,
      tmp1=orgL_1; tmp2=orgL_2; tmp3=orgL_3;
      if(length(orgL)>3,tmp4=orgL_4,tmp4=10000);
      orgL=orgL_(4..(length(orgL)));
      if((isstring(tmp2))&(isstring(tmp3)),
        tickL=concat(tickL,[tmp1,tmp2,tmp3]);        
      );
      if((isstring(tmp2))&(!isstring(tmp3)),
        if(isstring(tmp4),
          tickL=concat(tickL,[tmp1,"s1",tmp2]);
          orgL=prepend(tmp3,orgL);
        ,
          tickL=concat(tickL,[tmp1,tmp2,tmp3]);
        );       
      );
      if((!isstring(tmp2))&(isstring(tmp3)),
        tickL=concat(tickL,[tmp1,tmp2,tmp3]);        
      );
      if(!(isstring(tmp2))&(!isstring(tmp3)),
        tickL=concat(tickL,[tmp1,"s1",tmp2]);        
        orgL=prepend(tmp3,orgL);
      );
    );
  );
  forall(1..(length(tickL)/3),nn,
    tmp1=tickL_(3*nn-2);
    tmp2=tickL_(3*nn-1);
    tmp3=tickL_(3*nn);
    tmp=[[tmp1,-mark],[tmp1,mark]]; 
    tmp=apply(tmp,GENTEN+#);
    Listplot("ht"+nm+text(nn),tmp,append(options,"Msg=n"));
    Expr([GENTEN+[tmp1,0],tmp2,tmp3],options); 
  );
);
////%Htickmark end////

////%Vtickmark start//// 221201 major change
Vtickmark(arglist):=Vtickmark("",arglist,[]);
Vtickmark(Arg1,Arg2):=(
  if(isstring(Arg1),
    Vtickmark(Arg1,Arg2,[]);
  ,
    Vtickmark("",Arg1,Arg2);
  );
);
Vtickmark(nm,arglist,options):=(
//help:Vtickmark([1,"1",2,"sw","2"]);
//help:Vtickmark("1",[1,"1",3,"3"],["Color=red"]);
  regional(nn,tmp,tmp1,tmp2,tmp3,tmp4,
           tickL,orgL,mark);
  mark=MARKLEN/SCALEX;
  tickL=[];
  orgL=arglist;
  while(length(orgL)>0,
    if(length(orgL)==1,
      orgL=[];
    );
    if(length(orgL)==2,
      tmp1=orgL_1; tmp2="w1"; tmp3=orgL_2;
      tickL=concat(tickL,[tmp1,tmp2,tmp3]);
      orgL=[];
    );
    if(length(orgL)>=3,
      tmp1=orgL_1; tmp2=orgL_2; tmp3=orgL_3;
      if(length(orgL)>3,tmp4=orgL_4,tmp4=10000);
      orgL=orgL_(4..(length(orgL)));
      if((isstring(tmp2))&(isstring(tmp3)),
        tickL=concat(tickL,[tmp1,tmp2,tmp3]);        
      );
      if((isstring(tmp2))&(!isstring(tmp3)),
        if(isstring(tmp4),
          tickL=concat(tickL,[tmp1,"w1",tmp2]);
          orgL=prepend(tmp3,orgL);
        ,
          tickL=concat(tickL,[tmp1,tmp2,tmp3]);
        );       
      );
      if((!isstring(tmp2))&(isstring(tmp3)),
        tickL=concat(tickL,[tmp1,tmp2,tmp3]);        
      );
      if(!(isstring(tmp2))&(!isstring(tmp3)),
        tickL=concat(tickL,[tmp1,"w1",tmp2]);        
        orgL=prepend(tmp3,orgL);
      );
    );
  );
  forall(1..(length(tickL)/3),nn,
    tmp1=tickL_(3*nn-2);
    tmp2=tickL_(3*nn-1);
    tmp3=tickL_(3*nn);
    tmp=[[-mark,tmp1],[mark,tmp1]]; 
    tmp=apply(tmp,GENTEN+#);
    Listplot("vt"+nm+text(nn),tmp,append(options,"Msg=n"));
    Expr([GENTEN+[0,tmp1],tmp2,tmp3],options); 
  );
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
Setax(arg1):=Setax(arg1,[],[]);
Setax(arg1,arg2):=Setax(arg1,arg2,[]);
Setax(arg1,arg2,arg3):=(
//help:Setax(["l","x","e","y","n","O","sw"],["dr,2"],["Size=1.5"]);
//help:Setax([7,"nw"]);
  regional(arg,st,nn,tmp,tmp1,tmp2); 
  arglist=AXSTYLE_1;
  if(length(arg1)>0,
    if(isreal(arg1_1),
      nn=arg1_1;
      forall(2..(length(arg1)),
        tmp=arg1_(#);
        if(length(tmp)>0,arglist_(nn+#-2)=tmp);
      );
    ,
      forall(1..(length(arg1)),
        tmp=arg1_(#);
        if(length(tmp)>0,arglist_(#)=tmp);
      );
    );
  );
  AXSTYLE_1=arglist;
  AXSTYLE_2=arg2;
  AXSTYLE_3=arg3;
  AXSTYLE;
);
////%Setax end////

////%Drwxy start////230704
Drwxy():=(
//help:Drwxy();
  regional(org,tmp,tmp1,tmp2);
  org=GENTEN; 
  Listplot("-axx",[[XMIN,org_2],[XMAX,org_2]],AXSTYLE_2);
  Listplot("-axy",[[org_1,YMIN],[org_1,YMAX]],AXSTYLE_2);
  tmp=AXSTYLE_1;
  if(tmp_1=="a",
    Arrowhead([XMAX,org_2],[1,0],AXSTYLE_2);
    Arrowhead([org_1,YMAX],[0,1],AXSTYLE_2);
  );
  Expr([XMAX,org_2],tmp_3,tmp_2,AXSTYLE_3); 
  Expr([org_1,YMAX],tmp_5,tmp_4,AXSTYLE_3); 
  Letter(org,tmp_7,tmp_6,AXSTYLE_3);
);
////%Drwxy end////

////%Drwpt start////
Drwpt(pstr):=Drawpoint(pstr); //201031
////%Drwpt end////
////%Drawpoint start////
Drawpoint(pstr):=(
//help:Drawpoint(pstr);
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
    tmp=Textformat(#,10)+","+text(nn);
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

////%Drwexpr start////
Drwexpr(pos,str):=Drwexpr(pos,str,[]);
Drwexpr(pos,str,Arg):=(
  regional(sz,clr);
  if(!islist(Arg),sz=Arg;clr=[0,0,0],sz=12;clr=Arg);
  Drwexpr(pos,str,sz,clr);
);
Drwexpr(pos,str,sz,clr):=(
//help:Drwexpr([1,2],"x^2" [,12,[0,0,0]]);
  regional(tmp);
  if(!isstring(str),tmp=text(str),tmp=str);
  drawtext(pos,"$"+tmp+"$",size->sz,color->clr);
);
////%Drwexpr end////

////%Drwletter start////
Drwletter(pos,str):=Drwletter(pos,str,[]);
Drwletter(pos,str,Arg):=(
  regional(sz,clr);
  if(!islist(Arg),sz=Arg;clr=[0,0,0],sz=12;clr=Arg);
  Drwletter(pos,str,sz,clr);
);
Drwletter(pos,str,sz,clr):=(
//help:Drwletter([1,2],"abc" [,12,[0,0,0]]);
  regional(tmp);
  if(!isstring(str),tmp=text(str),tmp=str);
  drawtext(pos,tmp,size->sz,color->clr);
);
////%Drwletter end////

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
    if(isstring(str), //200526from
      if(!iswindows(),
        str=replace(str,"¥","\");
      ); 
    ,
      str=format(str,10)
    ); //200526to
    str="$"+str+"$"; //200526
    list_(3*#)=str;
  );
  Letter(list,options);
);
////%Expr end////

////%Lettermove start//// //210530
Lettermove(dir,str):=(
  regional(Suu,tmp,tmp1,out,nn);
  Suu="+-.0123456789";
  tmp=indexof(str,dir);
  tmp1=substring(str,tmp,length(str));
  out="";
  nn=1;
  while(nn<=length(tmp1),
    tmp=substring(tmp1,nn-1,nn);
    if(indexof(Suu,tmp)>0,
      out=out+tmp;
    ,
      nn=length(str);
    );
    nn=nn+1;
  );
  if(length(out)==0,out=0,out=parse(out));
  out;
);
////%Lettermove end////

////%Letter start////
Letter(Pt,Dr,St):=Letter([Pt,Dr,St]);
Letter(list):=Letter(list,[]);
Letter(Pt,Dr,St,options):=Letter([Pt,Dr,St],options);//181218
Letter(list,options):=(
//help:Letter([C,"c","Graph of $f(x)$"]);
//help:Letter([C,"c","xy"],["size->30"]);
  regional(Nj,Pos,Dir,Str,Off,Xmv,Ymv,Noflg,opcindy,
      opL,aln,sz,clr,bld,ita,tmp,tmp1,tmp2,color,color4,eqL);
  tmp=Divoptions(options);
  eqL=tmp_5; //190209
  Noflg=tmp_2;
  color=tmp_(length(tmp)-2); color4=Colorrgb2cmyk(color); //200618
  opL=select(options,indexof(#,"->")>0); //16.10.09from
  tmp=select(opL,indexof(#,"color"));
  sz=16; //210516
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
      sz=round(parse(tmp_2)*16); //210516
    );
  ); //190209to
  Nj=1;
//  if(Ketcindyjsfigure>0,sz=round(sz*Ketcindyjsscale) ); // only ketjs
  while(Nj+2<=length(list),
    Pos=Lcrd(list_Nj);  //220814
    Dir=list_(Nj+1);
    Str=list_(Nj+2);
    if(!isstring(Str),Str=format(Str,10)); // 16.09.30,10.09
    tmp=replace(Str,".xy","");
    tmp=replace(tmp,".x","(1)");
    Str=replace(tmp,".y","(2)");
    Str=RSslash(Str); // 17.09.24
    Str=replace(Str,"`","'");//180303
    tmp=Dq+","+Dq+Str+Dq+")";
    if(Noflg==0, //no ketjs on
      if((Noflg==0)&(color4!=KCOLOR), //180904
        Texcom("{");Com2nd("Setcolor("+color4+")");//180722
      );
      Com2nd("Letter("+Lcrd(Pos)+","+Dq+Dir+tmp);//16.10.10
      if((Noflg==0)&(color4!=KCOLOR), //180904 
        Texcom("}");//180722
      );
    ); //no ketjs off
    if(Noflg<2,
      Off=[0,0];
      Xmv=0; Ymv=0;
      aln="mid"; //200530from
      if(indexof(Dir,"c")>0, Off_2=-0.3*sz);
      if(indexof(Dir,"n")>0,Off_2=0;Ymv=Lettermove("n",Dir)); //210601
      if(indexof(Dir,"s")>0, Off_2=-0.85*sz;Ymv=-Lettermove("s",Dir));
      if(indexof(Dir,"e")>0,
        aln="left";
        if(indexof(Dir,"n")+indexof(Dir,"s")==0,Off=[0,-0.3*sz]);
        Xmv=Lettermove("e",Dir);
      );
      if(indexof(Dir,"w")>0,
        aln="right";
        if(indexof(Dir,"n")+indexof(Dir,"s")==0,Off=[0,-0.4*sz]);
        Xmv=-Lettermove("w",Dir);
      );
      Str=list_(Nj+2);  //17.10.17
      Pos=Pos+[Xmv,Ymv]*MARKLEN;//210530to
      if(length(color)==4,color=Colorcmyk2rgb(color)); //200523
      tmp="drawtext("+format(Pcrd(Pos),10)+",offset->"+text(Off)+","+Dqq(Str)+","; 
      tmp1="size->sz,color->colornow,align->"+Dqq(aln)+",bold->"+bld+",italics->"+ita; //210601
      tmp1=Assign(tmp1,["sz",text(sz),"colornow",text(color),"aln",Dqq(aln),"bld",text(bld),"ita",text(ita)]);
      tmp=tmp+tmp1+");";
      GCLIST=append(GCLIST,[tmp,[6,0]]); //201004to
    );
    Nj=Nj+3;
  );
);
////%Letter end////

////%Letterrot start////
Letterrot(pt,dir,str):=Letterrot(pt,dir,0,0,1,str,[]);
Letterrot(pt,dir,Arg1,Arg2):=(
  if(islist(Arg2),
    Letterrot(pt,dir,"t0n0",Arg1,Arg2);
  ,
    Letterrot(pt,dir,Arg1,Arg2,[]);
  );
);
Letterrot(pt,dir,movstrorg,str,options):=( //200101renewal
//help:Letterrot(C,B-A,AB",["Size=2.0"]);
//help:Letterrot(C,B-A,"t0n5","AB");
//help:Letterrot(optiions=["Color=","Size=1.0(10)"]);
  regional(mstr,tmov,nmov,rev,tmp,tmp1,tmp2,flg,color);
  mstr=movstrorg;
  flg="";  //200420from
  tmp1=""; tmp2=""; rev=1;
  forall(1..(length(mstr)), 
    tmp=substring(mstr,#-1,#);
    if(contains(["t","n","r"],tmp),
      if(tmp=="r",
        rev=-1;
      ,
        flg=tmp;
      );
    ,
      if(flg=="t",tmp1=tmp1+tmp);
      if(flg=="n",tmp2=tmp2+tmp);
    );
  );
  if(length(tmp1)>0,tmov=parse(tmp1),tmov=0);
  if(length(tmp2)>0,nmov=parse(tmp2),nmov=0); //200420to
  Letterrot(pt,dir,tmov,nmov,rev,str,options);
);
Letterrot(pt,dirorg,tmov,nmov,rev,str,options):=(
  regional(dir,tmp,color,color4);
  tmp=Divoptions(options);
  color=tmp_(length(tmp)-2); color4=Colorrgb2cmyk(color); //200618
  dir=dirorg; //200526[2lines]
  if(isreal(dir),dir=[cos(dir),sin(dir)]);
  Letter(LLcrd(pt),"c",str,append(options,"notex"));
  tmp=replace(str,"\","\\"); // no ketjs on
  if(color4!=KCOLOR, //
    Texcom("{");Com2nd("Setcolor("+color4+")");
  );
  Com2nd("Letterrot("+Textformat(pt,10)+","+dir+","+tmov+","+nmov+","+rev+","+Dqq(tmp)+")");
  if(color4!=KCOLOR, 
    Texcom("}");
  ); // no ketjs off
);
////%Letterrot end////

////%Exprrot start////
Exprrot(pt,dir,str):=Exprrot(pt,dir,"",str,[]);
Exprrot(pt,dir,Arg1,Arg2):=(
  if(islist(Arg2),
    Exprrot(pt,dir,"t0n0",Arg1,Arg2);
  ,
    Exprrot(pt,dir,Arg1,Arg2,[]);
  );
);
Exprrot(pt,dir,movstrorg,str,options):=( //200101renewal
//help:Exprrot(C,B-A,"d");
//help:Exprrot(C,B-A,"t0n2r","d");
//help:Exprrot(options=["Color=","Size="]);
  regional(mstr,tmov,nmov,rev,tmp,tmp1,tmp2,flg,color,color4);
  mstr=movstrorg;
  flg="";  //200420from
  tmp1=""; tmp2=""; rev=1;
  forall(1..(length(mstr)), 
    tmp=substring(mstr,#-1,#);
    if(contains(["t","n","r"],tmp),
      if(tmp=="r",
        rev=-1;
      ,
        flg=tmp;
      );
    ,
      if(flg=="t",tmp1=tmp1+tmp);
      if(flg=="n",tmp2=tmp2+tmp);
    );
  );
  if(length(tmp1)>0,tmov=parse(tmp1),tmov=0);
  if(length(tmp2)>0,nmov=parse(tmp2),nmov=0); //200420to
  Exprrot(pt,dir,tmov,nmov,rev,str,options);
);
Exprrot(pt,dirorg,tmov,nmov,rev,strorg,options):=(
  regional(dir,str,tmp,color);
  tmp=Divoptions(options);
  color=tmp_(length(tmp)-2); color4=Colorrgb2cmyk(color); //200618
  dir=dirorg; //200526[2lines]
  if(isreal(dir),dir=[cos(dir),sin(dir)]);
  str=strorg; //200526from
  if(!iswindows(),
    str=replace(str,"¥","\");
  ); //200526to
  Expr(LLcrd(pt),"c",str,append(options,"notex"));
  tmp=replace(str,"\","\\"); // no ketjs on
  if(color4!=KCOLOR, //180904
    Texcom("{");Com2nd("Setcolor("+color4+")");
  );
  Com2nd("Exprrot("+Textformat(pt,10)+","+dir+","+tmov+","+nmov+","+rev+","+Dqq(tmp)+")");
  if(color4!=KCOLOR, 
    Texcom("}");
  ); // no ketjs off
);
////%Exprrot end////

////%Ptpos start//// 190906
Ptpos(pt):=Ptpos(pt,[]);
Ptpos(ptorg,pos):=(
//help:Ptpos(A);
//help:Ptpos(A, [3,2]);
  regional(pt,out,tmp);
  if(ispoint(ptorg),pt=ptorg,pt=parse(ptorg));
  if(length(pos)==0,
    tmp=pt.name+"position";
    out=parse(tmp);
    if(!islist(out),
      tmp=tmp+"="+Textformat(pt.xy,12)+";";  //200108 6->12
      parse(tmp);
    );
  ,
    pt.xy=pos;
    tmp=pt.name+"position="+Textformat(pt.xy,12)+";"; //200108 6->12
    parse(tmp);
    out=pt.xy;
  );
  out;
);
////%Ptpos end////

////%Strictmove start////
Strictmove(pC):=Strictmove(pC,StrictSep); //190831
Strictmove(pCorg,sep):=(
  regional(pC,tmp,tmp1,tmp2);
  pC=pCorg;
  if(ispoint(pC),pC=pC.name);
  tmp1=pC+"position";
  if(!islist(parse(tmp1)),
    tmp=tmp1+"="+Textformat(parse(pC).xy,12)+";"; //200112
    parse(tmp);
  ,
   tmp=parse(pC).xy;
    tmp2=mouse().xy;
    if(|tmp-tmp2|>sep,
      tmp=pC+".xy="+pC+"position";
      parse(pC).xy=parse(pC+"position");
    ,
      tmp=tmp1+"="+Textformat(parse(pC).xy,12)+";"; //200112
      parse(tmp);
    );
  );
);
////%Strictmove end////

////%Slider start////
Slider(ptstr,p1,p2):=Slider(ptstr,p1,p2,[]);
Slider(ptstr,p1,p2,optionsorg):=(//220903
//help:Slider("A-C-B",[-3,0],[3,0]);
//help:Slider("C",[-3,0],[3,0]);
//help:Slider(options=["Color=[0,0,0.6]","Thick=2"]);
//help:Slider(options2=["Sep=0.3"]); //190824
  regional(pA,pB,pC,options,color,thick,sep,
        tmp,tmp1,tmp2);
  options=optionsorg;
  color="Color=0.6*[0,0,1]"; //190120from
  thick="size->2";
  sep=0.3; //190824
  forall(options,
    tmp=Toupper(substring(#,0,1));
    if(tmp=="C",
      color=#;
      options=remove(options,[tmp]);//220903
    );
    if(tmp=="T",
      tmp=Strsplit(#,"=");
      thick="size->"+tmp_2;
      options=remove(options,[tmp]);//220903
    );
    if(tmp=="S",//190824from
      tmp=Strsplit(#,"=");
      sep=parse(tmp_2);
      options=remove(options,[tmp]);//220903
    ); //190824to
  );
  tmp=Indexall(ptstr,"-");
  if(length(tmp)>0,
    pA=substring(ptstr,0,tmp_1-1); //190824from
    pC=substring(ptstr,tmp_1,tmp_2-1);
    pB=substring(ptstr,tmp_2,length(ptstr));
    parse(pA).xy=p1;
    parse(pB).xy=p2; //190824to
    tmp1=pC+"position"; //190827from
    if(!islist(parse(tmp1)),
      tmp2=parse(pC).xy;
      if(|tmp2-p1|<0.1,tmp2=p1+0.1*(p2-p1)/|p2-p1|);
      if(|tmp2-p2|<0.1,tmp2=p2+0.1*(p1-p2)/|p1-p2|);
      tmp=tmp1+"="+textformat(tmp2,10)+";";
      parse(tmp);
      parse(pC).xy=tmp2;
    ); //190827to
    PTEXCEPTION=concat(TEXCEPTION,[pA,pC,pB]);
  ,
    pC=ptstr; pA=pC+"l"; pB=pC+"r"; 
    PTEXCEPTION=concat(PTEXCEPTION,[pC]);
  );
  options=concat(options,["Msg=n",color,thick]); //220903[2lines]
  if(!contains(options,"nodisp"),options=append(options,"notex"));
  Listplot(pA+pB,[p1,p2],options);
  Putonseg(pC,parse("sg"+pA+pB));
);
////%Slider end////

////%Putpoint start////
Putpoint(name,Pt):=Putpoint(name,Pt,Pt);
Putpoint(name,Ptinit,Pt):=(
//help:Putpoint("A",[1,2],[1,A.y]);
  regional(ptstr); 
  ptstr=apply(allpoints(),#.name); //no ketjs on //191030
  if(!contains(ptstr,name),
    createpoint(name,Pcrd([Ptinit_1,Ptinit_2]));
    Ptpos(name,Pcrd([Ptinit_1,Ptinit_2])); //191005
  ,  //no ketjs off  //191030
    ptstr=name+".xy="+Textformat(Pcrd(Pt),10)+";";
    parse(ptstr);
    Ptpos(name,Pcrd([Pt_1,Pt_2])); //200529
  ); //no ketjs  //191030
);
////%Putpoint end////

////%Bezierfun start//// 210318
Bezierfun(pt0,pt1,pt2,pt3):=Bezierfun(p0,pt1,pt2,pt3,"t");
Bezierfun(pt0,pt1,pt2,pt3,var):=(
//help:Bezierfun(A,B,C,D,"t");
  regional(fun,xx,yy,p0,p1,p2,p3);
  p0=Lcrd(pt0); p1=Lcrd(pt1); p2=Lcrd(pt2); p3=Lcrd(pt3);
  fun="P0*(1-t)^3+3*P1*(1-t)^2*t+3*P2*(1-t)*t^2+P3*t^3";
  xx=Assign(fun,["P0",p0_1,"P1",p1_1,"P2",p2_1,"P3",p3_1,"t",var]);
  yy=Assign(fun,["P0",p0_2,"P1",p1_2,"P2",p2_2,"P3",p3_2,"t",var]);
  [xx,yy];
);
////%Bezierfun end////

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
Bezier(ptctrlist):=Beziercurve(ptctrlist_3,ptctrlist_1,ptctrlist_2,[]);
Bezier(Arg1,Arg2):=( //190202from
  regional(nm,ptctrlist,options);
  if(islist(Arg1),
    ptctrlist=Arg1; options=Arg2;
    Beziercurve(ptctrlist_3,ptctrlist_1,ptctrlist_2,options);
  ,
    nm=Arg1; ptctrlist=Arg2;
    Beziercurve(nm,ptctrlist_1,ptctrlist_2,[]);
  );
); //190202to
Bezier(nm,ptlist,ctrlist):=Beziercurve(nm,ptlist,ctrlist,[]);
Bezier(nm,ptlist,ctrlist,options):=Beziercurve(nm,ptlist,ctrlist,options);
////%Bezier end////

////%Beziercurve start////
Beziercurve(nm,ptlist,ctrlist):=Beziercurve(nm,ptlist,ctrlist,[]);
Beziercurve(nm,ptlistorg,ctrlistorg,options):=(
//help:Bezier("1",[A,D],[B,C]);
//help:Bezier(options=["Num=10"]);
  regional(name,Ltype,Noflg,opstr,opcindy,Num,msgflg,
    ptlist,ctrlist,tmp,tmp1,tmp2,ii,st,out,list,color,color4);
  name="bz"+nm;
  tmp=Divoptions(options);
  Ltype=tmp_1;
  Noflg=tmp_2;
  color=tmp_(length(tmp)-2); color4=Colorrgb2cmyk(color); //200618
  opstr=tmp_(length(tmp)-1);
  opcindy=tmp_(length(tmp));
  Num=10;
  msgflg="Y";
  tmp1=tmp_5;
  forall(tmp1,     // 14.12.31
    if(substring(#,0,1)=="N",
      tmp2=indexof(#,"=");
      Num=parse(substring(#,tmp2,length(#)));
      opstr=opstr+","+Dq+#+Dq;
    );
    if(substring(#,0,1)=="M",
      tmp2=indexof(#,"=");
      msgflg=Toupper(substring(#,tmp2,tmp2+1));
    );  );
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
    if(msgflg=="Y",println("generate Bezier "+name));
    out=apply(list,Pcrd(#));
    tmp=name+"="+Textformat(out,10)+";"; //190415
    parse(tmp);
    tmp1=Textformat(ptlist,10); //no ketjs on
    tmp1=RSform(tmp1,2); //17.12.23
    tmp2=Textformat(ctrlist,10);
    tmp2=RSform(tmp2,3); //17.12.23
    GLIST=append(GLIST,name+"=Bezier("+tmp1+","+tmp2+opstr+")"); //no ketjs off
  );
  if(Noflg<3, //190818
    if(isstring(Ltype),
      if((Noflg==0)&(color4!=KCOLOR), //180904 //no ketjs on
        Texcom("{");Com2nd("Setcolor("+color4+")");//180722
      ); //no ketjs off
      Ltype=Getlinestyle(text(Noflg)+Ltype,name);
      if((Noflg==0)&(color4!=KCOLOR), //180904 //no ketjs on
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
////%Beziercurve end////

////%Putbezierdata start////
Putbezierdata(name,ptL):=Putbezierdata(name,ptL,[]);
Putbezierdata(name,ptL,options):=(
  regional(psize,Deg,tmp,tmp1,tmp2,p1,p2,pts,ctrs);
  tmp=Divoptions(options);
  psize=3; //no ketjs
  Deg=3;
  tmp1=tmp_5;
  forall(tmp1,
    if(substring(#,0,1)=="D", //no ketjs on
      tmp=indexof(#,"=");
      Deg=parse(substring(#,tmp,length(#)));
    );
    if(substring(#,0,1)=="S",
      tmp=indexof(#,"=");
      psize=parse(substring(#,tmp,length(#)));
    ); //no ketjs off
  );
  pts=[];
  ctrs=[];
  forall(1..length(ptL),
    p2=ptL_#; // 16.08.16
    if(ispoint(p2),
      tmp1=p2.name; //190505
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
  if(isstring(ptdata), //no ketjs on
    ptlist=Readcsvsla(ptdata,options);
  ,  //no ketjs off
    ptlist=ptdata;
  );  //no ketjs
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
      tmp2="C"+text(#)+"p=2*pt-pt1;"; //190415
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
    tmp1="Putpoint("+Dq+"C1p"+Dq+",2*pt-pt1);"; // 16.08.16//190415
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

////%Meetcurve start////
Meetcurve(Crv,Xorg,Yorg):=(
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
////%Meetcurve end////

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
    if(p_1<p1_1,parse(name+".xy="+Textformat(p1,10));p=p1);
    if(p_1>p2_1,parse(name+".xy="+Textformat(p2,10));p=p2);
    tmp=(p2_2-p1_2)/(p2_1-p1_1)*(p_1-p1_1)+p1_2;
    parse(name+".y="+tmp+";"); //190415
  ,
    if(p1_2>p2_2,tmp=p1;p1=p2;p2=tmp);
    if(p_2<p1_2,parse(name+".xy="+Textformat(p1,10));p=p1);
    if(p_2>p2_2,parse(name+".xy="+Textformat(p2,10));p=p2);
    tmp=(p2_1-p1_1)/(p2_2-p1_2)*(p_2-p1_2)+p1_1;
    parse(name+".x="+tmp+";"); //190415
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
      parse(pn+".xy="+Textformat(Ptend(crv),10)+";"); //190415
    );
  );
);
////%Putoncurve end////

////%Crosspoint start////
Crosspoint(name,Crv1,Crv2,range):=(
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
////%Crosspoint end////

////%Periodfun start////
Periodfun(defL,rng):=Periodfun(defL,rng,[]);
Periodfun(Arg1,Arg2,Arg3):=( //190419from
  regional(nm,defL,,rng,options);
  if(isstring(Arg1),
    nm=Arg1; defL=Arg2; rng=Arg3;
    Periodfun(nm,defL,rng,[]);
  ,
    defL=Arg1; rng=Arg2; options=Arg3;
    Periodfun("",defL,rng,options); //190421
  );
);
Periodfun(nm,defL,rng,optionorg):=( //190420[new]
//help:Periodfun("1",defL,"x=range",options);
//help:Periodfun(defL=[function string,range(with equal option),devision number,...]);
//help:Periodfun(equal option "l","r","b","n");
//help:Periodfun(options=["Connect)=da,Color=red"]);//180725
  regional(name,range,nr,nn,eqL,options,connect,Eps,fun,scaley,interval,
           mxfun,var,left,right,period,cL,crL,sL,sdL,flg,equal,tmp,tmp1,tmp2);
  Eps=10^(-2);
  name="pe"+nm;
  var="x";
  nr=3*floor(length(defL)/3);
  left=defL_2_1;
  if(isstring(left),left=parse(left)); //190505
  right=defL_(nr-1)_2;
  if(isstring(right),right=parse(right)); ///190505
  period=right-left;
  if(isstring(rng),
    tmp=Strsplit(rng,"=");
    var=tmp_1;
    if(length(tmp)>1,
      range=parse(tmp_2);
    ,
      range=[XMIN,XMAX];
    );
  ,
    range=[left-rng*period,right+rng*period]; //190421
  );
  options=optionorg;
  tmp=Divoptions(options);
  eqL=tmp_5;
  connect="da";
  forall(eqL,
    tmp=Strsplit(#,"=");
    tmp1=Toupper(substring(tmp_1,0,3));
    tmp2=tmp_2;
    if(tmp1=="CON",
      tmp1=Toupper(substring(tmp2,0,1));
      if(tmp1=="N",
        connect="";
      ,
        if(tmp1!="Y",
          connect=tmp2;
        );
      );
      options=remove(options,[#]);
    );
  );
  scaley=SCALEY;
  SCALEY=1;
  mxfun="";
  cL=[];
  forall(1..(nr/3),nn,
    nst=text(nn);
    fun=defL_(3*nn-2);
    interval=defL_(3*nn-1); //190505from
    equal="l";
    if(length(interval)>2,
      equal=substring(interval_3,0,1);
      interval=interval_(1..2);
    );
    tmp=apply(interval,if(isstring(#),parse(#),#));
    tmp1=var+"="+Textformat(tmp,10);
    tmp2="Num="+text(defL_(3*nn));
    tmp=Plotdata("",fun,tmp1,[tmp2,"nodata","Msg=n"]);
    cL=append(cL,tmp);
    if(equal=="l",equal=["<=","<"]);
    if(equal=="r",equal=["<","<="]);
    if(equal=="b",equal=["<=","<="]);
    if(equal=="n",equal=["<","<"]);
    mxfun=mxfun+"elseif ("+interval_1+
       equal_1+var+" and "+var+equal_2+interval_2+") then "+fun+" ";
   );
  crL=cL;
  flg=0;
  forall(1..10,nn,
    if(flg==0,
      if(crL_1_1_1<=range_1,
        flg=1;
      ,
        tmp=Translatedata("",cL,[-nn*period,0],["nodata","Msg=n"]);
        crL=concat(tmp,crL);
      );
    );
  );
  flg=0;
  forall(1..10,nn,
    if(flg==0,
      tmp1=crL_(length(crL));
      tmp2=tmp1_(length(tmp1));
      if(range_2<=tmp2_1,
        flg=1;
      ,
        tmp=Translatedata("",cL,[nn*period,0],["nodata","Msg=n"]);
        crL=concat(crL,tmp);
      );
    );
  );
  SCALEY=scaley;
  sL=[];
  sdL=[];
  forall(1..(length(crL)),nn,
    tmp=concat(options,["Msg=n"]);
    Listplot("-"+name+text(nn),crL_nn,tmp);
    sL=append(sL,name+text(nn));
    if(nn<length(crL),
      tmp1=crL_nn_(length(crL_nn));
      tmp2=crL_(nn+1)_1;
      if(Norm(tmp2-tmp1)>Eps,
        tmp=concat(options,[connect,"Msg=n"]);
        Listplot("-"+name+"dc"+text(nn),[tmp1,tmp2],tmp);
        sdL=append(sdL,name+"dc"+text(nn));
      );
    );
  );
  tmp=name+"="+Textformat(sL,10)+";";
  parse(tmp);
  tmp=name+"dc="+Textformat(sdL,10)+";";
  parse(tmp);
  println("   generate "+name+","+name+"dc");
  mxfun=substring(mxfun,4,length(mxfun)-1);
  println("   return [mxfun,period]");
  [mxfun,period];
);
////%Periodfun end////

////%Mkcstable start////
Mkcstable(nterm,num):=( //190523
//help:Mkcstable(number of terms, division number);
  regional(cosL,sinL,dL,jj,x,tmp);
  cosL=[];
  sinL=[];
  forall(0..num,jj,
    x=-pi+2*pi/num*jj;
    dL=apply(1..nterm,cos(#*x));
    cosL=append(cosL,dL);
    dL=apply(1..nterm,sin(#*x));
    sinL=append(sinL,dL);
  );
  tmp="Costable="+Textformat(cosL,10);
  parse(tmp);
  tmp="Sintable="+Textformat(sinL,10);
  parse(tmp);
);
////%Mkcstable end////

////%Fourierseries start////
Fourierseries(nm,coeff,per,nterm):=
   Fourierseries(nm,coeff,per,nterm,[]);  // 16.11.24
Fourierseries(nm,coeff,per,nterm,Arg1):=( //190420from
  if(isstring(Arg1),
    Fourierseries(nm,coeff,per,nterm,Arg1,[]);
  ,
    Fourierseries(nm,coeff,per,nterm,"x=[XMIN,XMAX]",Arg1);
  );
);  
Fourierseries(nm,coefforg,per,nterm,range,optionorg):=(
//help:Fourierseries("1",[c0,cn,sn],period,numterm,"x=range",options);
//help:Fourierseries("1","[c0,cn,sn]",period,numterm,"x=range",options);
//help:Fourierseries(options2=["Table=n/y"]);
  regional(options,eqL,num,coeff,c0,cn,sn,fs,tbflg,jj,dL,
        tmp,tmp1,tmp2);
  options=optionorg; //190523from
  tmp=Divoptions(options);
  eqL=tmp_5;
  tbflg="N";
  num=100;
  forall(eqL,
    tmp=Strsplit(#,"=");
    tmp1=Toupper(substring(tmp_1,0,1));
    if(tmp1=="T",
      tbflg=Toupper(substring(tmp_2,0,1));
      options=remove(options,[#]);
    );
    if(tmp1=="N",
      num=parse(tmp_2);
      options=remove(options,[#]);
    );
  ); //190523to
  coeff=coefforg;
  if(isstring(coeff),
    tmp=substring(coeff,1,length(coeff)-1);
    coeff=tokenize(tmp,",");
  );
  coeff=apply(coeff,
    if(isstring(#),replace(#,"%pi","pi"),format(#,10))
  );
  c0=coeff_1;
  cn=coeff_2;
  sn=coeff_3;
  fs=c0;
  fn="(cn)*cos(n*2*pi/per*x)+(sn)*sin(n*2*pi/per*x)";
  fn=Assign(fn,["cn",cn,"sn",sn,"per",per]);
  if(tbflg=="N", //190523
    forall(1..nterm,
        fs=fs+"+"+Assign(fn,["n",#]);
    );
    Deffun("four(x)",[fs]);
    Plotdata("-four"+nm,"four(x)",range,append(options,"Num="+num));
  ,
    c0=parse(c0); //190523from
    cn=apply(1..nterm,parse(Assign(cn,["n",#])));
    sn=apply(1..nterm,parse(Assign(sn,["n",#])));
    dL=[]; //1900523from
    forall(0..num,jj,
      x=-per/2+per/num*jj;
      fs=c0;
      forall(1..nterm,
        fs=fs+cn_#*Costable_(jj+1)_#+sn_#*Sintable_(jj+1)_#;
      );
      dL=append(dL,[x,fs]);
    );
    Listplot("-four"+nm,dL,options);
  ); //190523to
);
////%Fourierseries end////

////%Tabledata start//// //190428from
Tabledata(xLst,yLst,rmvL):=Tabledata("",xLst,yLst,rmvL); 
Tabledata(Arg1,Arg2,Arg3,Arg4):=(
  if(isstring(Arg1),
    Tabledata(Arg1,Arg2,Arg3,Arg4,[]);
  ,
    Tabledata("",Arg1,Arg2,Arg3,Arg4);
  );
); //190428to
Tabledata(nm,xL,yL,rmvL,optionorg):=(
//help:Tabledata(xL,yL,rmvL,["Geo=y(n)"]);
//help:Tabledata(options=[2(tick,0 for no tick),"Setwin=y","Move=[0,0]"]); //190428
  regional(options,rmL,Noflg,geo,tmp,tmp1,tmp2);
  options=optionorg;
  tmp=Divoptions(options);
  Noflg=tmp_2;
  if(Noflg>=1,rmL=[],rmL=rmvL); //200607
  eqL=tmp_5;
  geo="N"; //191008from
  forall(eqL,
    tmp=Strsplit(#,"="); //191023
    tmp1=Toupper(substring(tmp_1,0,1));
    if(tmp1=="G",
      geo=Toupper(substring(tmp_2,0,1));
      options=remove(options,#);
    );
  );
  if(geo=="Y", //191008to
    Tabledatageo(nm,xL,yL,rmL,options);
  ,
    Tabledatalight(nm,xL,yL,rmL,options);
  );
);
////% Tabledata end////

////%Tabledatalight start////
Tabledatalight(xLst,yLst,rmvL):=Tabledatalight("",xLst,yLst,rmvL); //190428from
Tabledatalight(Arg1,Arg2,Arg3,Arg4):=(
  if(isstring(Arg1),
    Tabledatalight(Arg1,Arg2,Arg3,Arg4,[]);
  ,
    Tabledatalight("",Arg1,Arg2,Arg3,Arg4);
  );
); //190428to
Tabledatalight(nm,xLst,yLst,rmvL,optionorg):=(
//help:Tabledatalight(xLst,yLst,rmvL,[0(notick)]);
//help:Tabledatalight(xLst,yLst,rmvL,[2,"Setwindow=y","Move=[0,0]"]); //190428
  regional(options,rng,name,upleft,ul,flg,tick,eqL,reL,n,m,xsize,ysize,
    rlist,clist,Tb,jj,kk,tmp,tmp1,tmp2,tmp3,Eps,tbstr,msg);
  // TableMove is global for Table
  TABLECOUNT=TABLECOUNT+1; //190428from
  TableMove=GENTEN; //190428to
  name="tb"+text(TABLECOUNT); //190428to
  options=optionorg;
  tmp=Divoptions(options);
  eqL=tmp_5; //16.12.16from
  reL=tmp_6;
  rng="Y";
  msg="Y";
  forall(eqL,
    tmp=Strsplit(#,"="); //190428from
    tmp1=Toupper(substring(tmp_1,0,2));
    if(tmp1=="RN",
      rng=Toupper(substring(tmp_2,0,1));
      options=remove(options,[#]);
    );
    if(tmp1=="MS", //210208from
      msg=Toupper(tmp_2);
      options=remove(options,[#]);
    ); //210208to
    if(tmp1=="MO",
      TableMove=parse(tmp_2);
      rng="N"; //190429
      options=remove(options,[#]);
    );
    if(tmp1=="SE",
      rng=Toupper(substring(tmp_2,0,1));
      options=remove(options,[#]);
    );
  ); //190428to
  tick=1; 
  flg=0; //190424
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
  if(msg=="Y", //210208
    println("generate Tabledatalight "+name);  //190428
  ); //210208
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
  Tb=[clist,rlist]; //190427
  tmp=name+"="+Tb+";"; //190415
  parse(tmp);
  tbstr="["; //191008
  forall(0..m,jj,  //190507from
    tmp3="c"+text(jj);
    if(length(rmvL)>=0,
      tmp1="r"+text(0);
      tmp2="r"+text(n);
      Tlistplot("-"+name+tmp3+tmp1+tmp2,[tmp3+tmp1,tmp3+tmp2],append(options,"Msg=n")); //200523
      tbstr=tbstr+Dqq(name+tmp3+tmp1+tmp2)+"," //191008
    ,
      forall(0..(n-1),
        tmp1="r"+text(#);
        tmp2="r"+text(#+1);
        Tlistplot("-"+name+tmp3+tmp1+tmp2,[tmp3+tmp1,tmp3+tmp2],append(options,"Msg=n")); //200523
        tbstr=tbstr+Dqq(name+tmp3+tmp1+tmp2)+"," //191008
      );
    );  //190507to
    if(tick!=0, //190421
      if(mod(jj,tick)==0 % #==m,
        Letter(clist_(jj+1)+TableMove,"n1","c"+text(jj),["notex"]); //190428,210530
      );
    );
  ); //190507
  forall(0..n,jj,
    tmp3="r"+text(jj);
    if(length(rmvL)>=0,
      tmp1="c"+text(0);
      tmp2="c"+text(m);
      Tlistplot("-"+name+tmp3+tmp1+tmp2,[tmp1+tmp3,tmp2+tmp3],append(options,"Msg=n"));
      tbstr=tbstr+Dqq(name+tmp3+tmp1+tmp2)+"," //191008
    ,
      forall(0..(m-1),
        tmp1="c"+text(#);
        tmp2="c"+text(#+1);
        Tlistplot("-"+name+tmp3+tmp1+tmp2,[tmp1+tmp3,tmp2+tmp3],append(options,"Msg=n"));
        tbstr=tbstr+Dqq(name+tmp3+tmp1+tmp2)+"," //191008
      );
    );
    if(tick!=0, //190421
      if(mod(jj,tick)==0 % #==n,
       Letter(rlist_(jj+1)+TableMove,"w1","r"+text(jj),["nottex"]); //190428,210530
      );,
    );
  );
  tbstr=substring(tbstr,0,length(tbstr)-1)+"]"; //101008from
  tmp1=parse(tbstr);
  tmp=name+"str="+tbstr+";";
  parse(tmp); //101008to
  Changetablestyle(rmvL,["nodisp","Msg=n"]); //200523
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

////%Tabledatageo start//// //190428(renamed)
Tabledatageo(nm,xLstorg,yLstorg,rmvL,options):=(
  regional(eqL,ul,n,m,Tb,xLst,yLst,
    rlist,clist,rflg,cflg,tm,tmp,tmp1,tmp2);
  tmp=Divoptions(options);
  eqL=tmp_5;
  TableMove=[0,0];
  forall(eqL,
    tmp=Strsplit(#,"=");;
    tmp1=Toupper(substring(tmp_1,0,2));
    tmp2=Toupper(substring(tmp_2,0,1));
    if(tmp1=="MO",
      TableMove=parse(tmp_2);
    );
  );
  tm=TableMove;
  xLst=xLstorg;
  yLst=yLstorg;
  m=length(xLst);
  n=length(yLst);
  rlist=apply(1..n,1/10*sum(yLst_(1..#))+tm_2);
  rlist=reverse(rlist);
  clist=apply(1..m,1/10*sum(xLst_(1..#))+tm_1);
  forall(1..n,
    tmp="R"+text(#-1);
    tmp1=[tm_1,rlist_#];
    Putpoint(tmp,tmp1,[tm_1,parse(tmp+".y")]);
    inspect(parse(tmp),"ptsize",3);
    inspect(parse(tmp),"labeled","false");
  );
  forall(1..n,
    if(#<n,
      yLst_#=10*(parse("R"+text(#-1)+".y")-parse("R"+text(#)+".y"));
    ,
      yLst_#=10*(parse("R"+text(#-1)+".y")-tm_2);
    );
  );
  forall(1..m,
    tmp="C"+text(#);
    tmp1=[clist_#,R0.y];
    Putpoint(tmp,tmp1,[parse(tmp+".x"),R0.y]);
    inspect(parse(tmp),"ptsize",3);
    inspect(parse(tmp),"labeled","false");
  );
  forall(1..m,
    if(#>1,
      xLst_#=10*(parse("C"+text(#)+".x")-parse("C"+text(#-1)+".x"));
    ,
      xLst_#=10*(parse("C"+text(#)+".x")-tm_1);
    );
  );
  Tb=Tabledatalight(nm,xLst,yLst,rmvL,options);
  Tb;
);
////%Tabledatageo end////

////%Tgrid start////
Tgrid(ptstr):=(
//help:Tgrid("c2r5");
  regional(tb,tmp,tmp1,tmp2);
  tmp=parse(ptstr);
  if(islist(tmp),
    tmp;
  ,
    tmp=indexof(ptstr,"r");
    tmp1=substring(ptstr,1,tmp-1);
    tmp1=parse(tmp1);
    tmp2=substring(ptstr,tmp,length(ptstr));
    tmp2=parse(tmp2);
    tb=parse("tb"+text(TABLECOUNT)); //190428
    [tb_1_(tmp1+1)_1,tb_2_(tmp2+1)_2]+TableMove; //190428
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
//help:Tlistplot([options : same as Listplot]);
  regional(tmp,tmp1);
  tmp=apply(ptL,Tgrid(#)); // 15.06.03
  Listplot(nm,tmp,options); //200523
);
////%Tlistplot end////

////%Changetablestyle start//// //220316(major change)
Changetablestyle(nameL,style):=(
//help:Changetablestyle(["r0c0c3"],["da"]);
  regional(nametb,tname,nmL,grid,gcL,hd,fr,to,pd,sty,side1,side2,
     tmp,tmp1,tmp2,tmp3);
//  regional(nmL,nametb, name,grid,head,sb,tmp,tmp1,tmp2,tmp3,
//      tsg,pts,p1,p2,names,name,name1,nn,mm,gname,flg);
  nametb="tb"+text(TABLECOUNT); //190428
  if(islist(nameL),nmL=nameL,nmL=[nameL]);
  forall(nmL,grid,  
    hd=substring(grid,0,1);
    if(hd=="r",tmp2=Indexall(grid,"c"),tmp2=Indexall(grid,"r"));
    hd=substring(grid,0,tmp2_1);
    fr=parse(substring(grid,tmp2_1,tmp2_2-1));
    to=parse(substring(grid,tmp2_2,length(grid)));
    pd=[hd,fr,to];
    tmp=select(GCLIST,indexof(#_1,nametb+pd_1)>0);
    tmp=select(tmp,#_2_1>=0);
    gcL=apply(tmp,[replace(#_1,nametb,""),#_2,#_3]);
    forall(1..(length(gcL)),
      tmp1=gcL_#_1;
      hd=substring(tmp1,0,1);
      if(hd=="r",tmp2=Indexall(tmp1,"c"),tmp2=Indexall(tmp1,"r"));
      hd=substring(tmp1,0,tmp2_1);
      fr=parse(substring(tmp1,tmp2_1,tmp2_2-1));
      to=parse(substring(tmp1,tmp2_2,length(tmp1)));
      gcL_#=[[hd,fr,to],gcL_#_2,gcL_#_3];
    );
    tmp2=select(gcL,(#_1_2<=pd_2)&(pd_3<=#_1_3));
    if(length(tmp2)>0,
      tmp=tmp2_1;
      side1=tmp_1_2;
      side2=tmp_1_3;
      tmp1=tmp_1;
      tname=nametb+tmp1_1+tmp1_2+hd_(-1)+tmp1_3;
      tmp2=tmp_2;
      tmp3=tmp_3;
      tmp=text(tmp2);
      if(tmp_2=="0",tmp2="dr"+substring(tmp,2,length(tmp)-1));
      if(tmp_2=="1",tmp2="da"+substring(tmp,2,length(tmp)-1));
      if(tmp_2=="2",tmp2="id"+substring(tmp,2,length(tmp)-1));
      if(tmp_2=="3",tmp2="do"+substring(tmp,2,length(tmp)-1));
      tmp3=replace(tmp3,",color->","Color=");
      sty=[tmp2,tmp3];
      Changestyle([tname],["nodisp"]);
      hd=substring(hd,0,length(hd)-1);
      if(substring(hd,0,1)=="r",tmp1="c",tmp1="r");
      if(side1<pd_2,
        if(substring(hd,0,1)=="r",
          tmp=[tmp1+side1+hd,tmp1+pd_2+hd];
        ,
          tmp=[hd+tmp1+side1,hd+tmp1+pd_2];
        );
        Tlistplot("-"+nametb+hd+tmp1+side1+tmp1+pd_2,tmp,sty)
      );
      if(pd_3<side2,
        if(substring(hd,0,1)=="r",
          tmp=[tmp1+pd_3+hd,tmp1+side2+hd];
        ,
          tmp=[hd+tmp1+pd_3,hd+tmp1+side2];
        );
        Tlistplot("-"+nametb+hd+tmp1+pd_3+tmp1+side2,tmp,sty)
      );
      if(substring(hd,0,1)=="r",
        tmp=[tmp1+pd_2+hd,tmp1+pd_3+hd];
      ,
        tmp=[hd+tmp1+pd_2,hd+tmp1+pd_3];
      );      
      Tlistplot("-"+nametb+hd+tmp1+pd_2+tmp1+pd_3,tmp,style);
    ,
    );
  );
);
////%Changetablestyle end////

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

////%Putcol start////
Putcol(mcol,dir,lttrL):=Putcol("",mcol,dir,lttrL,[]); //190228from
Putcol(Arg1,Arg2,Arg3,Arg4):=(
  if(islist(Arg4),
    Putcol("",Arg1,Arg2,Arg3,Arg4);
  ,
    Putcol(Arg1,Arg2,Arg3,Arg4,[]);
  );
);
Putcol(Tbdata,mcol,dir,lttrL,options):=(
//help:PutcoL(1,"c",["x","y","z"]);
  regional(tmp,tmp1,nrow);
  nrow=length(lttrL);
  forall(1..nrow,
    Putcell(Tbdata,mcol,#,dir,lttrL_#,options);
  );
); //190228to
////%Putcol end////

////%Putcolexpr start////
Putcolexpr(mcol,dir,exL):=Putcolexpr("",mcol,dir,exL,[]); //190228from
Putcolexpr(Arg1,Arg2,Arg3,Arg4):=(
  if(islist(Arg4),
    Putcolexpr("",Arg1,Arg2,Arg3,Arg4);
  ,
    Putcolexpr(Arg1,Arg2,Arg3,Arg4,[]);
  );
);
Putcolexpr(Tbdata,mcol,dir,exL,options):=(
//help:Putcolexpr(2,"r",["x","y","z"]);
  regional(lttrL);
  lttrL=apply(exL,"$"+#+"$");
  Putcol(Tbdata,mcol,dir,lttrL,options);
); //190228to
////%Putcolexpr end////

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
  regional(gcL,Nj,Nk,Dt,Vj,tmp,tmp1,tmp2,tmp3,tmp4,typeL,opcindy,flg);
  gcL=gcLorg; //190125from
  if(length(gcL)>0,
    if(!islist(gcL_1),gcL=[gcL]);
  ); //190125to
  gcL=select(gcL,#_2_1>=0); //190818
  gsave();
  layer(KETPIClAYER); // 210602[spell]
  forall(gcL,Nj,
    flg=0;
    if(isstring(Nj_1),
      if(Nj_2_1>4, //200716from
        parse(Nj_1);
        flg=1; 
      ,
        Dt=parse(Nj_1);
      );  //200716to
    ,
      Dt=Nj_1
    );  // 11.17
    if((flg==0)&(islist(Dt))&(length(Dt)>0),  // 12.19,12.22,200716
      tmp=Measuredepth(Dt);
      if(tmp==1,Dt=[Dt]);
      opcindy=Nj_3;
      typeL=Nj_2; //200620from
      if(isstring(typeL_2),tmp=tokenize(typeL_2,","),tmp=[typeL_2]); //200623
      typeL=prepend(typeL_1,tmp); //200620from
      if(typeL_1<0,typeL_1=0);
      tmp1=typeL_1;
      if(tmp1<10,
        forall(Dt,Nk,
          if(length(Nk)>1,
            tmp3="";
            if(indexof(opcindy,"color")==0, //190122from
              tmp=Colorcmyk2rgb(KCOLOR); //200513[2lines]
              tmp3=tmp3+",linecolor->"+text(tmp);
            );
            tmp3=tmp3+opcindy;
            if(tmp1==0,  //190126from
              if(indexof(opcindy,"size")==0, 
                tmp3=tmp3+",size->"+text(typeL_2);
              ); //190124to
              tmp="connect("+Textformat(Nk,10)+tmp3+");";//190125
              parse(tmp);
            );
            if((tmp1==1)%(tmp1==2),
              tmp4=Dashlinedata(Nk,typeL_2,typeL_3,0); //no ketjs on
              forall(tmp4,
                tmp="connect("+Textformat(#,10)+tmp3+");";
                parse(tmp);
              ); //no ketjs off
//              if(length(typeL)<4,typeL=append(typeL,1)); //only ketjs on
//              if(typeL_(-1)!=1,
//                tmp="linesize("+text(typeL_4)+")";
//                parse(tmp);
//              );
//              tmp3=",dashtype->1"+tmp3;
//              forall(1..(length(Nk)-1),
//                tmp="draw("+Textformat([Nk_#,Nk_(#+1)],10)+tmp3+");";
//                parse(tmp);
//              );
//              if(typeL_(-1)!=1,
//                tmp="linesize(1)";
//                parse(tmp);
//              );  //only ketjs off
            );
            if(tmp1==3,
              if(typeL_3!=1,
                tmp="linesize("+text(typeL_3)+")";
                parse(tmp);
              );
              tmp3=",dashtype->3"+tmp3;
              forall(1..(length(Nk)-1),
                tmp="draw("+Textformat([Nk_#,Nk_(#+1)],10)+tmp3+");";
                parse(tmp);
              );
              if(typeL_3!=1,
                tmp="linesize(1)";
                parse(tmp);
              );
            );
          ,
            if(indexof(opcindy,"size")==0,  //190425from
              opcindy=opcindy+",size->"+text(TenSize/TenSizeInit);
            ); //190425to
            tmp="draw("+text(Nk_1)+opcindy+");"; 
            parse(tmp);
           ); //190126to
        );
      );
    );
  );
  forall(PTSHADElist, //200519from
    parse(#_2);
  ); //200519to

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
//help:Extractdata("ha1");
// help:Extractdata(1,"ha1");
  regional(dlist,tmp,tmp1,tmp2,tmp3,File,Ltype,Noflg,opstr,opcindy,color,color4);
  tmp=Divoptions(options);
  Ltype=tmp_1;
  Noflg=tmp_2;
  color=tmp_(length(tmp)-2);color4=Colorrgb2cmyk(color); //200629
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
  if(Noflg<3, //190818
    if(isstring(Ltype),
      if((Noflg==0)&(color4!=KCOLOR), //180904 //no ketjs on
        Texcom("{");Com2nd("Setcolor("+color4+")");//180722
      ); //no ketjs off
      Ltype=Getlinestyle(text(Noflg)+Ltype,name);
      if((Noflg==0)&(color4!=KCOLOR), //180904 //no ketjs on
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

////%Removeout start////
Removeout(pltlist):=(
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
////%Removeout end////

////%Makecmdlist start////
Makecmdlist(libname):=(
//help:Makecmdlist("ketcindylib");
  regional(cmdall,cmd,flg,tmp,tmp1,tmp2,out);
  setdirectory(Dirlib);
  tmp=load(libname+".cs");
  if(length(tmp)>0, //200509from
    tmp=replace(tmp,CRmark,"");
    tmp=replace(tmp,LFmark,"");
  ); //200509from
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

////%Makehelplist start//// //200509
Makehelplist(dir,libname):=(
  regional(cmdall,tmp,tmp1);
  tmp=Readlines(dir,libname); 
  tmp=select(tmp,indexof(#,"//help:")>0);
  cmdall=tmp_(2..(length(tmp)-1));
  forall(1..(length(cmdall)),
    tmp=cmdall_#;
    tmp1=indexof(tmp,":");
    tmp2=indexof(tmp,");");
    cmdall_#=substring(tmp,tmp1,tmp2+1);
  );
  cmdall;
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
  regional(ketfiles,fileL,tmp,tmp1,tmp2);
  fileL=["","3d","mv","out"]; //200531[3lines]
  fileL=apply(fileL,"ketcindylib"+#);
  if(indexof(dir,"read")==0,
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
    tmp=apply(tmp,#+help+".txt"); 
    ketfiles=concat(ketfiles,tmp);// 15.11.05 until
    tmp1=[];
    forall(ketfiles,
      tmp=Makehelplist(dir,#); //200509
      tmp1=concat(tmp1,tmp);
    );
  ,
    tmp=Dirhead+"/ketlib"; 
    tmp1=Readlines(tmp,"ketcindyhelp.txt");
    tmp2="ketcindylib"+help+".txt";  //201010from
    tmp2=Readlines(tmp,tmp2);
    forall(1..(length(tmp2)),
      tmp=indexof(tmp2_#,":");
      tmp2_#=substring(tmp2_#,tmp,length(tmp2_#));
    );
    tmp1=concat(tmp1,tmp2);  //201010to
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
  if(length(tmp)>0, //200509from
    tmp=replace(tmp,CRmark,"");
    tmp=replace(tmp,LFmark,"");
  ); //200509from
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

////%Tikzptseq start////
Tikzptseq(ptlist):=(
//help:Tikzptseq([A,B,[3,1]]);
  regional(outp,tmp);
  outp="";
  forall(1..(length(ptlist)),
    tmp=ptlist_#;
    if(!isstring(tmp),
      tmp=Sprintf(Pcrd(tmp),5);
      tmp="("+tmp_1+","+tmp_2+")";
    );
    outp=outp+tmp;
    if(#<length(ptlist),
      outp=outp+"--";
    );
  );
  outp;
);
////%Tikzptseq end////

////%Tikzline start////
Tikzline(ptlist,options):=(
//help:Tikzline([A,B,C,"cycle"],["Join=round"]);
//help:Tikzline(options=["Join=(round,bevel)","Width=(1)","Color="]);
  regional(out,outp,tmp,tmp1,tmp2,color,eqL,wflg);
  tmp=Divoptions(options);
  color=tmp_8;
  eqL=tmp_5;
  out="";
  wflg=0;
  forall(eqL,
    tmp1=substring(#,0,1);
    if((tmp1>="a")&(tmp1<="z"),
      out=out+","+#;
      if(tmp1=="l",wflg=1);
    ,
      tmp=Strsplit(#,"=");
      if(tmp1=="W",
        tmp2=parse(tmp_2)*0.6;
        out=out+",line width="+text(tmp2);
        wflg=1;
      );
      if(tmp1=="J",
        out=out+",join="+tmp_2;
      );
    );
  );
  if(wflg==0,
    out=",line width=0.6";
  );
  out="\draw ["+substring(out,1,length(out))+"]";
  out=out+Tikzptseq(ptlist)+";";
  tmp=Textformat(color,3);
  tmp=replace(tmp,[["[","{"],["]","}"]]);
  Texcom("{\color[rgb]"+tmp);
  Texcom(out);
  Texcom("}");
);
////%Tikzline end////

//help:end();

