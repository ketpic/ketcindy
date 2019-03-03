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

println("ketcindylib3d[20190301] loaded");

//help:start();

////%Ketinit3d start////
Ketinit3d():=Ketinit3d(1);
Ketinit3d(sf):=(
  regional(tmp);
  tmp=round(4*SW.y)/4;
//  Ketinit3d(sf,[round(SW.x)+1,tmp-0.5,tmp-1]);
  Ketinit3d(sf,[-5,tmp-0.5,tmp-1]);
);
Ketinit3d(subflg,position):=(
//help:Ketinit3d();
//help:Ketinit3d(0);
  regional(ctr,tmp,tmp1,tmp2,tmp3,tmp4,xPos,yTh,yPh);
  BezierNumber3=1;   //15.02.28
  if(!islist(BZLIST3),
    BZLIST3=[]; //15.02.28
  ,
    tmp=apply(allpoints(),text(#));
	tmp1=select(tmp,substring(#,length(#)-1,length(#))=="p");
    tmp2=[];
    forall(tmp1,ctr,
      tmp=substring(ctr,0,length(ctr)-1);
      tmp=select(BZLIST3,#_1==tmp);
      if(length(tmp)>0,
        tmp2=append(tmp2,tmp_1);
      );
    );
    BZLIST3=tmp2;
  );
  SUBSCR=subflg;
  Setwindow("Msg=no");
  if(length(position)>2,
    xPos=position_1;
    yTh=position_2; 
    yPh=position_3;
  ,
    xPos=0;
    yTh=position_1; 
    yPh=position_2;
  );
//  THETA=60*pi/180;
//  PHI=30*pi/180;
  FocusPoint=[0,0,0];
  EyePoint=[5,5,5];
  Listplot("th",[[xPos,yTh],[xPos+9,yTh]],["notex","linecolor->[0,1,0]","Msg=no"]);
  Listplot("ph",[[xPos,yPh],[xPos+9,yPh]],["notex","linecolor->[0,1,0]","Msg=no"]);
     //16.02.10
  PutonCurve("TH",sgth,[xPos,xPos+9,"Msg=no"]);
  PutonCurve("FI",sgph,[xPos,xPos+9,"Msg=no"]);
  THETA=(TH.x-xPos)*20*pi/180;
  PHI=(FI.x-xPos)*40*pi/180;
//  Defvar("THETA",THETA); // 16.06.20
//  Defvar("PHI",PHI); // 16.06.20
  drawtext([xPos-0.8,yTh-0.1],Sprintf((TH.x-xPos)*20,2),align->"right"); //17.05.02
  drawtext([xPos-0.8,yPh-0.1],Sprintf((FI.x-xPos)*40,2),align->"right"); //17.05.02
  tmp="Setangle("+text((TH.x-xPos)*20)+","+text((FI.x-xPos)*40)+")";
  GLIST=append(GLIST,tmp);
  Addax(0);
  TSIZE=10;
  TSIZEZ=10;
  ErrFlg=0;
);
////%Ketinit3d end////

////%Start3d start////
Start3d():=Start3d([]); 
Start3d(ptexception):=(
//help:Start3d();
//help:Start3d(["A","B"](exceptionptlist));
  regional(xmn,xMx,ymn,yMx,pt,pt3,pt2,
    xPos,yTh,yPh,Eps,tmp,tmp1,tmp2,tmp3,tmp4);
  PTEXCEPTION=[];
  Setfiles(Namecdy); //180608
  ConstantListC=[[50,50],[5000,1500,500,200],[0.00001,0.01,0.1]];
  FuncListC=[];
  CommandListC=[]; //180531
  CutFunList=[];//180601
  EraseList=[];//180601
  ADDPACK=[]; //180606
  GCLIST=[];
  GLIST=[];
  FUNLIST=[];
  COM0thlist=[];
  COM1stlist=[];
  COM2ndlist=[];
  SEG3dlist=[];
  OutFileList=[];
  FigPdfList=[];  // 16.04.08
  ErrFlag=0;
  OBJCMD=[]; // 16.11.29from
  OCNAME=Fhead;
  OCOPTION=["m","v"];// 16.11.29until
  ArrowlineNumber=1;  // 16.01.31
  ArrowheadNumber=1;
  BezierNumber=1; //16.01.31
  BezierNumber3=1; //16.08.19
  Fnametex=Fhead+".tex";  // 15.04.06
  FnameR=Fhead+".r";
  FnameRbody=Fhead+"body.r";
  Fnameout=Fhead+".txt";
  Setwindow("Msg=no"); // 16.06.20from
  tmp=round(4*SW.y)/4;
  xPos=-5; yTh=tmp-0.5; yPh=tmp-1;
  Slider("TH",[xPos,yTh],[xPos+9,yTh],["Color=green"]); //190209
  Slider("FI",[xPos,yPh],[xPos+9,yPh],["Color=green"]); //190209
  drawtext([xPos-0.8,yTh-0.1],Sprintf((TH.x-xPos)*20,2),align->"right"); //17.05.02
  drawtext([xPos-0.8,yPh-0.1],Sprintf((FI.x-xPos)*40,2),align->"right"); //17.05.02
  tmp="Setangle("  //no ketjs on
    +format((TH.x-xPos)*20,5)+","
    +format((FI.x-xPos)*40,5)+")";
  GLIST=append(GLIST,tmp); //no ketjs off
  THETA=(TH.x-xPos)*20*pi/180;
  PHI=(FI.x-xPos)*40*pi/180; // 16.06.20until
  if(isselected(TH) % isselected(FI), // 17.05.18from
    if(length(Ch)>0,
      ChNum=Ch_(length(Ch));
      if(ChNum==0, ChNum=1);
    ,
      ChNum=1;
    );
    Ch=[0];
  );// 17.05.18to
  if(SUBSCR==1,
    xmn=SW.x+NE.x-SW.x;
    xMx=NE.x+NE.x-SW.x;
    ymn=SW.y;
    yMx=NE.y;
    drawpoly([[xMx,yMx],[xmn,yMx],
      [xmn,ymn],[xMx,ymn]],color->[1,1,1]);
    connect([[NE.x-SW.x,yMx],[NE.x-SW.x,ymn]],
      color->[0.5,0.5,0.5]);
  );
 // for Presentation //17.07.01from //no ketjs on
  letterc=[0.98,0.13,0,0.43]; boxc=[0,0.32,0.52,0];
  shadowc=[0,0,0,0.5]; mboxc="yellow"; //17.03.02 regional debugged
  SlideColorList=[letterc,boxc,boxc,boxc,shadowc,shadowc,6,1.3,
                letterc,mboxc,mboxc,mboxc,62,2,letterc];
  ThinDense=0.1; //17.07.01to //no ketjs off
  tmp=ptexception; //181106
  if(!islist(tmp),tmp=[tmp]);  //190209
  PTEXCEPTION=concat(PTEXCEPTION,tmp); //190209
//  if(!islist(tmp),PTEXCEPTION=[tmp],PTEXCEPTION=tmp);
  Ptseg3data(PTEXCEPTION);  //16.08.23
//  PTEXCEPTION=ptexception; //180916 //190209[del]
);
////%Start3d end////

////%Setangle start////
Setangle(angL):=Setangle(ang_1,ang_2);//180614
Setangle(theta,phi):=( //16.12.24
//help:Setangle(60,30);
  regional(xmn,xMx,ymn,yMx,pt,pt3,pt2,
    xPos,yTh,yPh,Eps,tmp,tmp1,tmp2,tmp3,tmp4);
  tmp=round(4*SW.y)/4;
  xPos=-5;yTh=tmp-0.5;yPh=tmp-1;
  if(theta=="",theta=THETA*180/pi); // 17.01.19
  if(phi=="",phi=PHI*180/pi);
  THETA=theta*pi/180;
  TH.x=theta/20+xPos;
  PHI=phi*pi/180;
  FI.x=phi/40+xPos;
//  drawtext([xPos-0.8,yTh-0.1],text(theta)); //17.05.05
//  drawtext([xPos-0.8,yPh-0.1],text(phi));
  tmp="Setangle("
    +format(theta,5)+","+format(phi,5)+")";
  GLIST=append(GLIST,tmp);
  if(length(VLIST)==0, // 16.06.20
    tmp=remove(allpoints(),[NE,SW,TH,FI]);
    tmp4=remove(tmp,PTEXCEPTION); //180916
    forall(tmp4,pt,
      tmp1=text(pt);
      tmp=substring(tmp1,length(tmp1)-1,length(tmp1));
      if(tmp!="z",
        tmp=parse(tmp1+"z.xy"); //181028[2lines];
        pt3=Xyzcoord(pt.xy,tmp);
        Defvar(tmp1+"3d",pt3);
        pt2=Parapt(pt3);  // 16.05.28from
        Defvar(tmp1+"2d",pt2);  // 16.05.28to
      );
    );
  ,
    if(isselected(NE) % isselected(SW), 
      tmp=remove(allpoints(),[NE,SW,TH,FI]);
      tmp4=remove(tmp,PTEXCEPTION); //180916
      forall(tmp4,pt,
        tmp1=text(pt);
        tmp=substring(tmp1,length(tmp1)-1,length(tmp1));
        if(tmp!="z",
          tmp=select(VLIST,#_1==tmp1+"3d");
          pt3=tmp_1_2;
          tmp=tmp1+".xy=Parapt("+pt3+")_[1,2];";
          parse(tmp);
        );
      );
    ,
      tmp=remove(allpoints(),[NE,SW,TH,FI]);
      tmp4=remove(tmp,PTEXCEPTION); //180916
      forall(tmp4,pt,
        tmp1=text(pt);
        tmp=substring(tmp1,length(tmp1)-1,length(tmp1));
        if(tmp!="z",
          tmp2=parse(tmp1+"z");
          if(isselected(pt) % isselected(tmp2),
            Defvar(tmp1+"2d",pt.xy);
            tmp=parse(tmp1+"z.xy"); //181028[2lines]
            tmp=Xyzcoord(pt.xy,tmp);
            Defvar(tmp1+"3d",tmp);
          );
        );
      );
    );
  );
  forall(Datalist3d(),#,
    tmp1=replace(#,"3d","2d");
    tmp2=Projpara(#,["nodata"]);
    tmp=tmp1+"="+textformat(tmp2,5);
    parse(tmp);
  );
  Ptseg3data(PTEXCEPTION); //180916
);
////%Setangle end////

////%Getangle start////
Getangle():=getangle(["Disp=y"]); //180613from
Getangle(option):=(
  regional(tmp,tmp1,dispflg,eqL);
  tmp=divoptions(option);
  dispflg="Y";
  eqL=tmp_5; //181111
  forall(eqL,
    tmp=Strsplit(#,"="); //181111(4lines)
    tmp1=Toupper(substring(tmp_1,0,1));
    if(tmp1=="D",
      dispflg=Toupper(substring(tmp_2,0,1));
    );
  );
  tmp=[THETA*180/pi, PHI*180/pi];
  if(dispflg=="Y",
    println(textformat(tmp,6));
  );
  tmp; //180607
); //180613to
////%Getangle end////

////%Angleselected start////
Angleselected():=IsAngle(); //180713
//isAngle():=Isangle(); //180517
////%Angleselected end////

////%Isangle start////
Isangle():=isselected(TH)%isselected(FI); //180517
////%Isangle end////

////%Changestyle3d start////
Changestyle3d(nameL,style):=(
//help:Changestyle3d(["geoseg3d","ax3d"],["notex"]);
  regional(nmL,name,tmp,tmp1,tmp2);
  if(islist(nameL),nmL=nameL,nmL=[nameL]);
  tmp1=[];
  forall(nmL,name,
    tmp=parse(name);
    if(islist(tmp),
      if(isstring(tmp_1),
        tmp1=concat(tmp1,tmp);
      ,
        tmp1=append(tmp1,name);
      );
      tmp=apply(tmp1,replace(#,"3d","2d"));
      Changestyle(tmp,style);
      tmp=apply(tmp,"sub"+#); // 15.05.24
      Changestyle(tmp,style);
    );
  );
);
////%Changestyle3d end////

////%Dist3d start////
Dist3d(pt1):=Dist3d(pt1,[0,0,0]);
Dist3d(pt1,pt2):=(
//help:Dist3d(A3d,B3d);
//help:Dist3d(A,B);
//help:Dist3d("A","B");
  regional(p1,p2);
  if(islist(pt1),
    p1=pt1;
  ,
    if(ispoint(pt1),p1=text(pt1),p1=pt1);
    p1=parse(p1+"3d");
  );
  if(islist(pt2),
    p2=pt2;
  ,
    if(ispoint(pt2),p2=text(pt2),p2=pt2);
    p2=parse(p2+"3d");
  );
  sqrt((p2-p1)*(p2-p1));
);
////%Dist3d end////

////%Findangle start////
Findangle(vec):=(
//help:Findangle([2,1,4]);
//help:Findangle([0,0,1,0]);
  regional(vec3,vec2,Eps,th,ph,tmp);
  Eps=10^(-4);
  vec3=vec_(1..3);
  vec2=vec_(1..2);
  th=arccos(vec_3/|vec3|);
  if(|vec2|>Eps,
    ph=arccos(vec_1/|vec2|);
    if(vec_2<0,
      ph=2*pi-ph; // 15.03.28
    );
  ,
    if(length(vec)>3,ph=vec_4*pi/180,ph=PHI);
  );
  [th,ph];
);
////%Findangle end////

////%Cancoordpara start////
Cancoordpara(pc):=(
//help:Cancoordpara([1,2,0]);
  regional(Xz,Yz,Zz,tmp1,tmp2,tmp3);
  Xz=pc_1; Yz=pc_2; Zz=pc_3;
  tmp1=-Xz*sin(PHI)-Yz*cos(PHI)*cos(THETA)+Zz*cos(PHI)*sin(THETA);
  tmp2=Xz*cos(PHI)-Yz*sin(PHI)*cos(THETA)+Zz*sin(PHI)*sin(THETA);
  tmp3=Yz*sin(THETA)+Zz*cos(THETA);
  [tmp1,tmp2,tmp3];
);
////%Cancoordpara end////

////%Zparapt start////
Zparapt(cc):=(
  regional(x,y,z);
  x=cc_1; y=cc_2; z=cc_3;
  x*cos(PHI)*sin(THETA)+y*sin(PHI)*sin(THETA)+z*cos(THETA);
);
////%Zparapt end////

////%Projcoordpara start////
Projcoordpara(cc):=(
//help:Projcoordpara([3,1,2]);
  regional(tmp);
  tmp=Parapt(cc);
  [tmp_1,tmp_2,Zparapt(cc)];
);
////%Projcoordpara end////

////%Parapt start////
Parapt(pt):=(
//help:Parapt([2,1,5]);
  regional(Xz,Yz);
  Xz=-pt_1*sin(PHI)+pt_2*cos(PHI);
  Yz=-pt_1*cos(PHI)*cos(THETA)-pt_2*sin(PHI)*cos(THETA)+pt_3*sin(THETA);
  [Xz,Yz];
);
////%Parapt end////

////%Parasubpt start////
Parasubpt(pt):=( //181027
  regional(mv,dp,xs);
  mv=NE.x-SW.x;
  dp=pi/24;
  xs=-pt_1*sin(PHI+dp)+pt_2*cos(PHI+dp);
  [xs+mv,pt_3];
);
////%Parasubpt end////

////%Parasubptlog start////
Parasubptlog(pt):=( //181027
  regional(dp,xs);
  dp=pi/24;
  xs=-pt_1*sin(PHI+dp)+pt_2*cos(PHI+dp);
  [xs,pt_3];
);
////%Parasubptlog end////

////%Mainsubpt3d start////
Mainsubpt3d(pm,psv):=( //181027
  regional(Eps,mv,dp,v,x,y,z);
  // when Th neq 90, psv=ps_2, else  psv=ps_1
  Eps=10^(-4);
  mv=NE.x-SW.x;
  dp=pi/24;
  if(abs(cos(THETA))>Eps,
    if(length(psv)>1,v=psv_2, v=psv);
    x=(v*cos(PHI)*sin(THETA)-pm_1*sin(PHI)*cos(THETA)-pm_2*cos(PHI))/cos(THETA);
    y=(v*sin(PHI)*sin(THETA)+pm_1*cos(PHI)*cos(THETA)-pm_2*sin(PHI))/cos(THETA);
    z=v;
  ,
    if(length(psv)>1,v=psv_1, v=psv);
    x=(pm_1*cos(PHI+dp)-(v-mv)*cos(PHI))/sin(dp);
	y=(pm_1*sin(PHI+dp)-(v-mv)*sin(PHI))/sin(dp);
    z=pm_2;
  );
  [x,y,z];
);
////%Mainsubpt3d end////

////%ProjCurve start////
ProjCurve(crv):=(
//help:Projcurve("sl3d1");
  regional(CurveL,Curve,Eps,AnsL,Out,sp,cp,st,,ct,ii,pt,
       Xz,Yz,tmp,tmp1,tmp2);
  Eps=10^(-6);
  sp=sin(PHI); cp=cos(PHI);
  st=sin(THETA); ct=cos(THETA);
  if(isstring(crv),CurveL=parse(crv),CurveL=crv);
  if(Measuredepth(CurveL)==1,CurveL=[CurveL]);
  Out=[];
  forall(CurveL,Curve,
    AnsL=[];
    forall(1..length(Curve),ii,
      pt=Curve_ii;
      if(pt_1!="inf",
        Xz=-pt_1*sp+pt_2*cp;
        Yz=-pt_1*cp*ct-pt_2*sp*ct+pt_3*st;
        tmp=[Xz,Yz];
        if(ii==1,
           AnsL=[tmp];
        ,
          tmp1=AnsL_(length(AnsL));
          if(tmp1_1=="inf" % |tmp-tmp1|>Eps,
            AnsL=append(AnsL,tmp);
          );
        );
      ,
        AnsL=append(AnsL,["inf"]);
      );
    );
    tmp1=[];
    tmp2=select(1..length(AnsL),AnsL_#==["inf"]);
    tmp=1;
    forall(tmp2,
      if(#>tmp,
        tmp1=concat(tmp1,[AnsL_(tmp..(#-1))])
      );
      tmp=#+1;
    );
    if(tmp<length(AnsL),
      tmp1=concat(tmp1,[AnsL_(tmp..length(AnsL))]);
    );
    AnsL=tmp1;
    if(length(AnsL)==1,AnsL=AnsL_1);
    Out=append(Out,AnsL);
  );
  if(length(Out)==1,
    Out=Out_1;
  );
  Out;
);
////%ProjCurve end////

////%Projpara start////
Projpara(ptdata):=Projpara(ptdata,[]);
Projpara(ptdata,optionsorg):=(
//help:Projpara("sf3d1");
//help:Projpara(options=["Msg=no"]);
  regional(options,name2,name3,Ltype,Noflg,eqL,opcindy,
     dtL,ptL,tmp,tmp1,Out,color,msgflg);
  options=optionsorg;
  tmp=Divoptions(options);
  Ltype=tmp_1;
  Noflg=tmp_2;
  eqL=tmp_5;
  color=tmp_(length(tmp)-2);
  opcindy=tmp_(length(tmp));
  msgflg=0; //180602from
  forall(eqL,
    tmp=Strsplit(#,"=");
    tmp1=Toupper(substring(tmp_1,0,1)); //181111
    if(tmp=="M",
      tmp=substring(tmp_2,0,1);
      if(Toupper(tmp)=="Y", msgflg=1);
      options=remove(options,[#]);
    );
  );//180602to
  Out=[];
  if(islist(ptdata),dtL=ptdata,dtL=[ptdata]);
  forall(dtL,name3,
    if(indexof(name3,"3d")>0, //17.05.24
      name2=replace(name3,"3d","2d");
    ,
      name2="para"+name3;
    );
    ptL=Projcurve(name3);
    ptL=select(ptL,length(#)>1);//17.06.02
    if(length(ptL)==1,
      ptL=ptL_1;
    );
    Out=append(Out,ptL);
    if(Noflg<3,
      if(msgflg==1,//180602from
        println("generate projparadata  "+name2);
      );//180602to
      tmp=name2+"="+textformat(ptL,5);
      parse(tmp);
      tmp=name2+"=Projpara("+name3+")";
      GLIST=append(GLIST,tmp);
    );
    if(Noflg<2,
      if(isstring(Ltype),
        if(color!=KCOLOR, //180904
          Texcom("{");Com2nd("Setcolor("+color+")");//180722
        );
		Ltype=GetLinestyle(text(Noflg)+Ltype,name2);
        if(color!=KCOLOR, //180904
          Texcom("}");//180722
        );
	  ,
        if(Noflg==1,Ltype=0);
      );
    GCLIST=append(GCLIST,[name2,Ltype,opcindy]);
    );
  );
  if(length(Out)==1,Out=Out_1);
  if(length(Out)==1,Out=Out_1); // 15.02.24
  tmp=[];
  forall(Out,
    if(length(#)>0,tmp=append(tmp,#));
  );
  Out=tmp;
  Out;
);
////%Projpara end////

////%InvparaptPp start////
InvparaptPp(pt,pd):=(
  regional(Eps,fk,nfk,ph,fh,ah,bh,ak,bk,v1,v2,
    nn,s0,t2,out,tmp,tmp1,tmp2,flg);
  Eps=10^(-4);
  if(isstring(pd),
    fk=pd;
  ,
    fk=textformat(pd,5);
  );
  nfk=Numptcrv(parse(fk));
  flg=0;
  tmp=pt;
  if(length(tmp)==1,
    ph=tmp;
    fh=pd;
  ,
    fh=Projpara(fk,["nodata"]);
    if(nfk>2,
      tmp1=Nearestpt(tmp,fh);
      ph=tmp1_2;
    ,
      ah=Ptcrv(1,fh); bh=Ptcrv(2,fh);
      v1=tmp-ah; v2=bh-ah;
      tmp1=Crossprod(v1,v2);
      if(abs(tmp1)>Eps,
        println("  Not on the line");
        out=[];
        flg=1;
      ,
        ph=Dotprod(v1,v2)/|v2|^2+1;
      );
    );
  );
  if(flg==0,
    if(nfk>2,
      nn=floor(ph);
      s0=ph-nn;
      if(ph>Numptcrv(fh)-Eps,
        out=[Ptend(fk),Numptcrv(fh)];
        flg=1;
      );
    ,
      nn=1;
      s0=ph-1;
    );
  );
  if(flg==0,
    ak=Ptcrv(nn,fk); bk=Ptcrv(nn+1,fk);
    ah=Ptcrv(nn,fh); bh=Ptcrv(nn+1,fh);
    ph=(1-s0)*ah+a0*bh;
    t2=s0;
    pk=(1-t2)*ak+t2*bk;
    out=[pk,nn+t2];
  );
  out;
);
////%InvparaptPp end////

////%Invparapt start////
Invparapt(pt,pd):=(
  regional(tmp);
  tmp=InvparaptPp(pt,pd);
  tmp_1;
);
////%Invparapt end////

////%Subgraph start////
Subgraph(name3,opcindy):=( //181029
  regional(name,crvL,sub2d,color,tmp,tmp1,tmp2);
  name=replace("sub"+name3,"3d","2d");
  crvL=parse(name3);
  if(Measuredepth(crvL)==1,crvL=[crvL]);
  sub2d=[];
  forall(crvL,tmp1,
    tmp2=[];
    forall(tmp1,
      tmp2=append(tmp2,Parasubpt(#));
    );
  sub2d=append(sub2d,tmp2);
  );
  tmp=name+"="+Textformat(sub2d,5);
  parse(tmp);
  GCLIST=append(GCLIST,[name,[0,1],opcindy]); //190127
  sub2d;
);
////%Subgraph end////

////%Spaceline start////
Spaceline(ptlist):=Spaceline(ptlist,[]); // 16.02.22 from
Spaceline(Arg1,Arg2):=(
  regional(name,tmp,tmp1,tmp2);
  if(isstring(Arg1),
    Spaceline(Arg1,Arg2,[]);
  ,
    tmp=text(Arg1);
    tmp=substring(tmp,1,length(tmp)-1);
    name="-"+replace(tmp,",","");
    Spaceline(name,Arg1,Arg2);
  );
); // 16.02.22 to
Spaceline(nm,ptlistorg,optionorg):=(
//help:Spaceline("1",[[2,5,1],[4,2,3]]);
//help:Spaceline([A,B]);
//help:Spaceline(options=["Msg=y(n)"]);
  regional(name2,name3,options,Out,tmp,tmp1,tmp2,
        opstr,opcindy,Ltype,Noflg,eqL,ptlist, Msg,color);
  ptlist=apply(ptlistorg,if(ispoint(#),parse(text(#)+"3d"),#)); // 16.02.10
  if(substring(nm,0,2)=="bz",
    name2=replace(nm,"bz","bz2d");
    name3=replace(nm,"bz","bz3d");
  ,
    if(substring(nm,0,1)=="-",
      tmp=substring(nm,1,length(nm));
      if(indexof(tmp,"3d")>0,name3=tmp,name3=tmp+"3d");
      name2=replace(name3,"3d","2d");
    ,
      name2="sl2d"+nm;
      name3="sl3d"+nm;
    );
  );
  options=select(optionorg,length(#)>0);  // 160415
  tmp=Divoptions(options);
  Ltype=tmp_1;
  Noflg=tmp_2;
  eqL=tmp_5;
  color=tmp_(length(tmp)-2);
  opcindy=tmp_(length(tmp));
  Msg=1;
  forall(eqL,
    tmp=substring(#,0,1);
    if(Toupper(tmp)=="M",
      tmp=indexof(#,"=");
      tmp1=substring(#,tmp,tmp+1);
      if(Toupper(tmp1)=="N",
        Msg=0;
      );
    );
  );
  if(Noflg<3,
    if(Msg==1,
      println("generate Spaceline "+name3);
    );
    tmp=name3+"="+ptlist;
    parse(tmp);
    tmp1=Projpara(name3,["nodata"]);
    tmp=name2+"="+textformat(tmp1,5);
    parse(tmp);
    tmp="[";
    forall(ptlist, //17.07.13from
      if(isstring(#),
        tmp=tmp+#+",";
      ,
        tmp=tmp+textformat(#,5)+",";
      );
    );
    tmp=substring(tmp,0,length(tmp)-1)+"]";
    tmp=name3+"=Spaceline("+tmp+")"; //17.07.13until
//    tmp=name3+"=Spaceline("+textformat(ptlist,5)+")"; //17.05.24
    GLIST=append(GLIST,tmp);
    tmp=name2+"=Projpara("+name3+")";
    GLIST=append(GLIST,tmp);
  );
  if(Noflg<2,
    if(isstring(Ltype),
      if(color!=KCOLOR, //180904
        Texcom("{");Com2nd("Setcolor("+color+")");//180722
      );
	  Ltype=GetLinestyle(text(Noflg)+Ltype,name2);
      if(color!=KCOLOR, //180904
        Texcom("}");//180722
      );
	,
      if(Noflg==1,Ltype=0);
    );
    GCLIST=append(GCLIST,[name2,Ltype,opcindy]);
    if(SUBSCR==1, //  15.02.11
      Subgraph(name3,opcindy);
    );
  );
  ptlist;
);
////%Spaceline end////

////%Spacecurve start////
Spacecurve(nm,funstr,variable):=Spacecurve(nm,funstr,variable,[]);
Spacecurve(nm,funstr,variable,optionorg):=(
//help:Spacecurve("1","[cos(t),sin(t),0.5*t]","t=[0,4*pi]",["Num=200"]);
  regional(name2,name3,options,Out,tmp,tmp1,tmp2,vname,tmpfn,str,Rng,Num,Msg,
     Ec,Exfun,Dc,opstr,opcindy,Fntmp,Vatmp,Ltype,Noflg,eqL,t1,t2,dt,tt,pa,ke,color);
  if(substring(nm,0,2)=="bz",
    name2=replace(nm,"bz","bz2d");
    name3=replace(nm,"bz","bz3d");
  ,
    name2="sc2d"+nm;
    name3="sc3d"+nm;
  );
  Eps=10^(-4);
  Num=50;
  Ec=[];
  Exfun="";
  Dc=1000;
  options=select(optionorg,length(#)>0);  // 160415
  tmp=Divoptions(options);
  Ltype=tmp_1;
  Noflg=tmp_2;
  eqL=tmp_5;
  color=tmp_(length(tmp)-2);
  opstr=tmp_(length(tmp)-1);
  opcindy=tmp_(length(tmp));
  Msg=1;
  forall(eqL,
    tmp=substring(#,0,1);
    if(Toupper(tmp)=="M",
      tmp=indexof(#,"=");
      tmp1=substring(#,tmp,tmp+1);
      if(Toupper(tmp1)=="N",
        Msg=0;
      );
    );
    tmp=indexof(#,"N=");
    if(tmp>0,
      tmp1=substring(#,tmp+1,length(#));
      Num=parse(tmp1);
      opstr=opstr+",'"+#+"'";
    );
    tmp=indexof(#,"Num=");
    if(tmp>0,
      tmp1=substring(#,tmp+3,length(#));
      Num=parse(tmp1);
      opstr=opstr+",'"+#+"'";
    );
    tmp=indexof(#,"E=");
    if(tmp>0,
      tmp1=substring(#,tmp+1,length(#));
      if(substring(tmp1,0,1)=="[",
        Ec=parse(tmp1);
      ,
        Exfun=tmp1;
      );
      opstr=opstr+",'"+#+"'";
    );
    tmp=indexof(#,"Exc=");
    if(tmp>0,
      tmp1=substring(#,tmp+3,length(#));
      if(substring(tmp1,0,1)=="[",
        Ec=parse(tmp1);
      ,
        Exfun=tmp1;
      );
    );
  );
  tmp=indexof(variable,"=");
  vname=substring(variable,0,tmp-1);
  str=substring(variable,tmp,length(variable));
  Rng=parse(str);
  t1=Rng_1; t2=Rng_2;
  dt=(t2-t1)/Num;  // differ from Scilab
  tmp="tmpfn("+vname+"):="+funstr+";";
  parse(tmp);
  Out=[];
  Ec=append(sort(Ec),10000);
  ke=1;
  forall(0..Num, 
    pt=[];
    tt=Rng_1+#*dt;
    if(tt-Ec_ke<-Eps,
      pa=tmpfn(tt);
    );
    if(abs(tt-Ec_ke)<=Eps,
      if(length(Out)>0,
        if(Out_(length(Out))_1!="inf",
          pa=["inf"];
        );
      );
    );
    if(tt-Ec_ke>Eps,
      pa=tmpfn(tt);
      ke=ke+1;
    );
    if(length(pa)>0,
      if(pa_1=="inf",
        Out=append(Out,pa);
      ,
        if(length(Out)==0,
          Out=[pa];
        ,
          tmp=Out_(length(Out));
          if(tmp_1=="inf",
            Out=append(Out,pa);
          ,
            if(|tmp-pa|<Dc,
              Out=append(Out,pa);
            ,
              Out=concat(Out,[["inf"],pa]);
            );
          );
        );
      );
    );
  );
  tmp1=[];
  tmp2=select(1..length(Out),Out_#==["inf"]);
  tmp=1;
  forall(tmp2,
    if(#>tmp,
      tmp1=concat(tmp1,[Out_(tmp..(#-1))])
    );
    tmp=#+1;
  );
  if(tmp<length(Out),
    tmp1=concat(tmp1,[Out_(tmp..length(Out))]);
  );
  if(length(Out)==1,
    Out=Out_1;
  );
  if(Noflg<3,
    if(Msg==1,
      println("generate Spacecurve "+name3);
    );
    tmp=name3+"="+textformat(Out,5);
    parse(tmp);
    tmp1=Projpara(name3,["nodata"]);
    tmp=name2+"="+textformat(tmp1,5);
    parse(tmp);
    tmp=name3+"=Spacecurve(Assign('"+funstr+"'),'"+variable+"'"+opstr+")";
    GLIST=append(GLIST,tmp);
    tmp=name2+"=Projpara("+name3+")";
    GLIST=append(GLIST,tmp);
  );
  if(Noflg<2,
    if(isstring(Ltype),
      if(color!=KCOLOR, //180904
        Texcom("{");Com2nd("Setcolor("+color+")");//180722
      );
	  Ltype=GetLinestyle(text(Noflg)+Ltype,name2);
      if(color!=KCOLOR, //180904
        Texcom("}");//180722
      );
	,
      if(Noflg==1,Ltype=0);
    );
    GCLIST=append(GCLIST,[name2,Ltype,opcindy]);
    if(SUBSCR==1, //  15.02.11
      tmp=parse(name2);  // 15.08.17
      if(length(tmp)>0,
        Subgraph(name3,opcindy);
      );   // 15.08.17
    );
  );
  Out;
);
////%Spacecurve end////

////%Partcrv3d start////
Partcrv3d(nm,pA,pB,PkLstr):=Partcrv3d(nm,pA,pB,PkLstr,[]);
Partcrv3d(nm,pA,pB,PkLstr,options):=(
//help:Partcrv3d("1",A,B,"sl3d1");
//help:Partcrv3d("1",1.3,2.5,"sl3d1");
  regional(p1,p2,q1,q2,dt1,dts,dt3,tmp,tmp1,tmp2);
  if(isreal(pA),
    p1=pA; q1=pA;
  ,
    if(islist(pA),
      tmp=pA;
    ,
      if(ispoint(pA),tmp=text(pA),tmp=pA);
      tmp=parse(tmp+"3d");
    );
    p1=parapt(tmp);
    q1=[p1_1,tmp_3]+[NE.x-SW.x,0];
  );
  if(isreal(pB),
    p2=pB; q2=pB;
  ,
    if(islist(pB),
      tmp=pB;
    ,
      if(ispoint(pB),tmp=text(pB),tmp=pB);
      tmp=parse(tmp+"3d");
    );
    p2=parapt(tmp);
    q2=[p2_1,tmp_3]+[NE.x-SW.x,0];
  );
  tmp=replace(PkLstr,"3d","2d");
  dt1=partcrv("",p1,p2,tmp,["nodata"]);
  dts=partcrv("",q1,q2,"sub"+tmp,["nodata"]);
  dt=apply(1..length(dt1),
    Xyzcoord(dt1_#,dts_#); //181028
  );
  Spaceline("-part3d"+nm,dt,options);
);
////%Partcrv3d end////

////%Joincrvs3d( start////
Joincrvs3d(nm,plotstrL):=Joincrvs3d(nm,plotstrL,[]);//16.10.06
Joincrvs3d(nm,plotstrL,options):=(
//help:Joincrvs3d("1",["bz3da1","bz3da1"]);
  regional(PtL,Eps,QdL,Flg,Ni,Qd,pP,pS,pQ,pR,rMN,
        opcindy,tmp,tmp1,tmp2,str,name2,name3,Ltype,Noflg,color);
  name2="join2d"+nm;
  name3="join3d"+nm;
  QdL=[];
  forall(plotstrL,str,
    if(isstring(str),
      tmp=parse(str);
    ,
      tmp=str;
    );
    QdL=append(QdL,tmp);
  );
  Eps=10^(-4);
  tmp=Divoptions(options);
  Ltype=tmp_1;
  Noflg=tmp_2;
  color=tmp_(length(tmp)-2);
  opcindy=tmp_(length(tmp));
  tmp1=tmp_6;
  if(length(tmp1)>0,Eps=tmp1_1);
  Flg=0;
  if(length(QdL)==0,
    PtL=[];
    Flg=1;
  );
  if(Flg==0,
    PtL=QdL_1;
    forall(2..length(QdL),Ni,
      Qd=QdL_Ni;
      if(length(Qd)>1,
        pP=PtL_1;
        pS=PtL_(length(PtL));
        pQ=Qd_1;
        pR=Qd_(length(Qd));
        rMN=min([Norm(pP-pQ),Norm(pP-pR),
              Norm(pS-pQ),Norm(pS-pR)]);
        if(rMN==Norm(pP-pR),
          Qd=reverse(Qd);
        ,
          if(rMN==Norm(pS-pQ),
            PtL=reverse(PtL);
          ,
            if(rMN==Norm(pS-pR),
              PtL=reverse(PtL);
              Qd=reverse(Qd);
            );
          );
        );
      );
      if(rMN>Eps,
        PtL=concat(PtL,Qd);
      ,
        PtL=concat(PtL,Qd_(2..length(Qd)));
      );
    );
  );
  if(Noflg<3,
    println("generate Joincurves3d "+name3);
    tmp=name3+"="+textformat(PtL,5);
    parse(tmp);
    tmp1=Projpara(name3,["nodata"]);
    tmp=name2+"="+textformat(tmp1,5);
    parse(tmp);
    tmp=text(plotstrL);
    tmp=substring(tmp,1,length(tmp)-1);
    tmp=name3+"=Joincrvs("+tmp+")";
    GLIST=append(GLIST,tmp);
    tmp=name2+"=Projpara("+name3+")";
    GLIST=append(GLIST,tmp);
  );
  if(Noflg<2,
    if(isstring(Ltype),
      if(color!=KCOLOR, //180904
        Texcom("{");Com2nd("Setcolor("+color+")");//180722
      );
	  Ltype=GetLinestyle(text(Noflg)+Ltype,name2);
      if(color!=KCOLOR, //180904
        Texcom("}");//180722
      );
	,
      if(Noflg==1,Ltype=0);
    );
    GCLIST=append(GCLIST,[name2,Ltype,opcindy]);
    if(SUBSCR==1, //  15.02.11
      tmp=parse(name2);  // 15.08.17
      if(length(tmp)>0,
        Subgraph(name3,opcindy);
      );   // 15.08.17
    );
  );
  PtL;
);
////%Joincrvs3d end////

////%Xyzax3data start////
Xyzax3data(nm,Xrange,Yrange,Zrange):=
          Xyzax3data(nm,Xrange,Yrange,Zrange,[]);
Xyzax3data(nm,Xrange,Yrange,Zrange,options):=(
//help:Xyzax3data("","x=[-5,5]","y=[-5,5]","z=[-5,5]");
//help:Xyzax3data(Options2=["a1","Osw"]);
  regional(name2,name3,Out,tmp,tmp1,tmp2,eqL,reL,strL,
    opstr,opcindy,Ltype,Noflg,Axname,Arrow,Origin,color);
  name2="ax2d"+nm;
  name3="ax3d"+nm;
  tmp=Divoptions(options);
  Ltype=tmp_1;
  Noflg=tmp_2;
  eqL=tmp_5;
  reL=tmp_6;
  strL=tmp_7;
  color=tmp_(length(tmp)-2);
  opcindy=tmp_(length(tmp));
  Axname=1;
  Arrow=0;  // 16.08.14
  Origin=""; // 16.08.14
  if(length(reL)>0,
    Axname=reL_1;
  );
  forall(strL,  // 16.08.14from
    tmp1=Toupper(substring(#,0,1));
    if(tmp1=="A",
      tmp=substring(#,1,length(#));
      if(length(tmp)>0,
        Arrow=parse(tmp);
      ,
        Arrow=1;
      );
    );
    if(tmp1=="O",
      tmp=indexof(#,",");
      if(tmp>0,
        Origin=substring(#,tmp,length(#));
      ,
        tmp=substring(#,1,length(#));
        if(length(tmp)>0,
          Origin=tmp;
        ,
          Origin="sw";
        );
      );
    );
  ); // 16.08.14until
  tmp1=indexof(Xrange,"=");
  tmp=parse(substring(Xrange,tmp1,length(Xrange)));
  Px=[tmp_1,0,0]; Qx=[tmp_2,0,0];
  tmp1=indexof(Yrange,"=");
  tmp=parse(substring(Yrange,tmp1,length(Yrange)));
  Py=[0,tmp_1,0]; Qy=[0,tmp_2,0];
  tmp1=indexof(Zrange,"=");
  tmp=parse(substring(Zrange,tmp1,length(Zrange)));
  Pz=[0,0,tmp_1]; Qz=[0,0,tmp_2];
  Out=[[Px,Qx],[Py,Qy],[Pz,Qz]];
  if(Axname>0,
    Xyzaxparaname(Xrange,Yrange,Zrange,[Axname]);
  );
  if(Noflg<3,
    println("generate axes "+name3);
    tmp=name3+"="+textformat(Out,5);
    parse(tmp);
    tmp1=Projpara([name3],["nodata"]);
    tmp=name2+"="+textformat(tmp1,5);
    parse(tmp);
    tmp=name3+"=Xyzax3data("+
	  Dq+Xrange+Dq+","+Dq+Yrange+Dq+","+Dq+Zrange+Dq+")";
    GLIST=append(GLIST,tmp);
    tmp=name2+"=Projpara("+name3+")";
    GLIST=append(GLIST,tmp);
  );
  if(Noflg<2,
    if(isstring(Ltype),
      if(color!=KCOLOR, //180904
        Texcom("{");Com2nd("Setcolor("+color+")");//180722
      );
	  Ltype=GetLinestyle(text(Noflg)+Ltype,name2);
      if(color!=KCOLOR, //180904
        Texcom("}");//180722
      );
	,
      if(Noflg==1,Ltype=0);
    );
    GCLIST=append(GCLIST,[name2,Ltype,opcindy]);
    if(Noflg<1,  // 16.08.14from
      if(Arrow>0,
        tmp1=Parapt(Px); tmp2=Parapt(Qx);
        Arrowhead(tmp2,tmp2-tmp1,[Arrow]);
        tmp1=Parapt(Py); tmp2=Parapt(Qy);
        Arrowhead(tmp2,tmp2-tmp1,[Arrow]);
        tmp1=Parapt(Pz); tmp2=Parapt(Qz);
        Arrowhead(tmp2,tmp2-tmp1,[Arrow]);
      );
      if(length(Origin)>0,
        Letter([Parapt([0,0,0]),Origin,"O"]);
      );
    );  // 16.08.14until
    if(SUBSCR==1, //  15.02.11
      Subgraph(name3,opcindy); //181029
    );
  );
  Out;
);
////%Xyzax3data end////

////%Xyzax3paraname start////
Xyzaxparaname(Xrange,Yrange,Zrange):=
   Xyzaxparaname(Xrange,Yrange,Zrange,[]);
Xyzaxparaname(Xrange,Yrange,Zrange,options):=(
//help:Xyzaxparaname("x=[-5,5]","y=[-5,5]","z=[-5,5]");
 regional(tmp,tmp1,tmp2,Eps,Dr,Noflg,Xname,Yname,Zname,
     px,qx,py,qy,pz,qz,ph,qh,rr,ch);
  Eps=10.0^(-6);
  Dr=0.19*1000/2.54/MilliIn;
  Noflg=0;
  forall(options,
    if(isreal(#),Dr=Dr*#);
  );
  tmp1=Strsplit(Xrange,"=");
  Xname=tmp1_1;
  tmp=parse(tmp1_2);
  px=[tmp_1,0,0]; qx=[tmp_2,0,0];
  tmp1=Strsplit(Yrange,"=");
  Yname=tmp1_1;
  tmp=parse(tmp1_2);
  py=[0,tmp_1,0]; qy=[0,tmp_2,0];
  tmp1=Strsplit(Zrange,"=");
  Zname=tmp1_1;
  tmp=parse(tmp1_2);
  pz=[0,0,tmp_1]; qz=[0,0,tmp_2];
  COM2ndlist=select(COM2ndlist,indexof(#,Dqq("$"+Xname+"$"))==0);//180608[3lines]
  COM2ndlist=select(COM2ndlist,indexof(#,Dqq("$"+Yname+"$"))==0);
  COM2ndlist=select(COM2ndlist,indexof(#,Dqq("$"+Zname+"$"))==0);
  ph=Parapt(px); qh=Parapt(qx); rr=|ph-qh|;
  if(rr>Eps,
    ch=qh+Dr/rr*(qh-ph);
    Expr(ch,"c",Xname);
  );
  ph=Parapt(py); qh=Parapt(qy); rr=|ph-qh|;
  if(rr>Eps,
    ch=qh+Dr/rr*(qh-ph);
    Expr(ch,"c",Yname);
  );
  ph=Parapt(pz); qh=Parapt(qz); rr=|ph-qh|;
  if(rr>Eps,
    ch=qh+Dr/rr*(qh-ph);
    Expr(ch,"c",Zname);
  );
);
////%Xyzax3paraname end////

////%Datalist3d start////
Datalist3d():=(
//help:Datalist3d();
  regional(out,tmp,tmp2,tmp3);
  tmp=apply(GCLIST,#_1);
  tmp=select(tmp,indexof(#,"2d")>0);
  tmp2=select(tmp,indexof(#,"sub")==0);
  tmp3=apply(tmp2,replace(#,"2d","3d"));
  out=tmp3;
);
////%Datalist3d end////

////%Datalist2d start////
Datalist2d():=(
//help:Datalist2d();
  regional(out,tmp,tmp2,tmp3);
  tmp=apply(GCLIST,#_1);
  tmp=select(tmp,indexof(#,"2d")>0);
  tmp2=select(tmp,indexof(#,"sub")==0);
//  tmp3=apply(tmp2,replace(#,"2d","3d"));
  out=tmp2;
);
////%Datalist2d end////

////%Embed start////
Embed(nm,Pd2str,funstr,varstr):=
    Embed(nm,Pd2str,funstr,varstr,[]);
Embed(nm,Pd2str,funstr,varstr,options):=(
//help:Embed("1",["gr1"],"A3d+x*(B3d-A3d)+y*(C3d-A3d)","[x,y]");
  regional(name2,name3,Pd2L,Pd2,tmp,tmp1,xstr,ystr,
     Ltype,Noflg,opstr,opcindy,Out,color);
  name2="em2d"+nm;
  name3="em3d"+nm;
  if(!islist(Pd2str),Pd2L=[Pd2str],Pd2L=Pd2str); // 15.03.06
  tmp1=[];   // 15.10.31
  forall(Pd2L,
    if(isstring(#),tmp=parse(#),tmp=#);
    if(Measuredepth(tmp)==2,
      tmp1=concat(tmp1,tmp);
    );
    if(Measuredepth(tmp)==1,
      tmp1=append(tmp1,tmp);
    );
  );
  Pd2L=tmp1;
  tmp=substring(varstr,0,1);
  if(tmp=="[" % tmp=="(",
    tmp1=substring(varstr,1,length(varstr)-1);
  ,
    tmp1=varstr;
  );
  tmp=indexof(tmp1,",");
  xstr=substring(tmp1,0,tmp-1);
  ystr=substring(tmp1,tmp,length(tmp1));
  tmp=Divoptions(options);
  Ltype=tmp_1;
  Noflg=tmp_2;
  color=tmp_(length(tmp)-2);
  opcindy=tmp_(length(tmp));
  Out=[];
  forall(Pd2L,Pd2,
    tmp1=[];
    forall(Pd2,
      tmp=Assign(funstr,xstr,"("+textformat(#_1,5)+")");
      tmp=Assign(tmp,ystr,"("+textformat(#_2,5)+")");
      tmp=parse(tmp);
      tmp1=append(tmp1,tmp);
    );
    Out=append(Out,tmp1);
  );
  if(length(Out)==1,
    Out=Out_1;
  );  
  if(Noflg<3,
    println("generate Embed "+name3);
    if(length(Out)>0,
      tmp=name3+"="+textformat(Out,5);
      parse(tmp);
      tmp1=Projpara(name3,["nodata"]);
      tmp=name2+"="+textformat(tmp1,5);
      parse(tmp);
    );
    if(!islist(Pd2str),
       tmp=Pd2str;
    ,
       tmp=text(Pd2str);
       tmp="list("+substring(tmp,1,length(tmp)-1)+")";
    );
    tmp=name3+"=Embed("+tmp+",'"+funstr+"','"+varstr+"'"+")";
    GLIST=append(GLIST,tmp);
    tmp=name2+"=Projpara("+name3+")";
    GLIST=append(GLIST,tmp);
  );
  if(Noflg<2,
    if(isstring(Ltype),
      if(color!=KCOLOR, //180904
        Texcom("{");Com2nd("Setcolor("+color+")");//180722
      );
	  Ltype=GetLinestyle(text(Noflg)+Ltype,name2);
      if(color!=KCOLOR, //180904
        Texcom("}");//180722
      );
	,
      if(Noflg==1,Ltype=0);
    );
    if(length(Out)>0,
      GCLIST=append(GCLIST,[name2,Ltype,opcindy]);
      if(SUBSCR==1, //  15.02.11
        Subgraph(name3,opcindy);
      );
    );
  );
  Out;
);
////%Embed end////

////%Rotatepoint3d start////
Rotate3pt(point,w1,w2):=Rotatepoint3d(point,w1,w2,[0,0,0]);
Rotate3pt(point,w1,w2,center):=Rotatepoint3d(point,w1,w2,center);
Rotatepoint3d(point,w1,w2):=Rotatepoint3d(point,w1,w2,[0,0,0]);//180809
Rotatepoint3d(point,w1,w2,center):=(
//help:Rotatepoint3d(pt3d,[0,0,1],pi/2);
//help:Rotatepoint3d(pt3d,[0,0,1],pi/2,[1,1,1]);
  regional(Eps,ct,st,v3,v1,v2,Ans,ns,PtL,num,
    pt,tmp,tmp1,tmp2,Retflg,x,y,z,xx,yy,zz,flg);
  Eps=10^(-4);
  Retflg=0;
  if(length(w2)==1,
    ct=cos(w2);
    st=sin(w2);
    v3=1/|w1|*w1;
    if(v3_1==0,
      tmp=[1,0,0];
    ,
      tmp=[0,1,0];
    );
    w1=[tmp_2*v3_3-tmp_3*v3_2,
         tmp_3*v3_1-tmp_1*v3_3,
         tmp_1*v3_2-tmp_2*v3_1];
    v1=1/|w1|*w1;
    v2=[v3_2*v1_3-v3_3*v1_2,
         v3_3*v1_1-v3_1*v1_3,
         v3_1*v1_2-v3_2*v1_1];
  ,
    tmp=[w1_2*w2_3-w1_3*w2_2,
          w1_3*w2_1-w1_1*w2_3,
          w1_1*w2_2-w1_2*w2_1];
    if(|tmp|<Eps,
      Ans=point;
      Retflg=1;
    );
    if(Retflg==0,
      v1=1/|w1|*w1;
      ns=v1_1*w2_1+v1_2*w2_2+v1_3*w2_3;
      tmp=w2-ns*v1;
      v2=1/|tmp|*tmp;
      tmp=[v1_2*v2_3-v1_3*v2_2,
                 v1_3*v2_1-v1_1*v2_3,
                 v1_1*v2_2-v1_2*v2_1];
      v3=1/|tmp|*tmp;
      ct=ns/|w2|;
      st=sqrt(1-ct^2);
    );
  );
  if(Retflg==0,
    if(|tmp|<Eps,
      Ans=point;
      Retflg=1;
    );
  );
  if(Retflg==0,
    if(Measuredepth(point)>0,
      PtL=point;
    ,
      PtL=[point];
    );
    Ans=[];
    flg=0;
    forall(1..length(PtL),num,
      pt=PtL_num;
      if(pt_1=="inf",
        Ans=append(Ans,["inf"]);
        flg=1;
      );
      if(flg==0,
        x=pt_1-center_1; y=pt_2-center_2; z=pt_3-center_3;
        xx=((v1_1*ct+v2_1*st)*v1_1+ (-v1_1*st+v2_1*ct)*v2_1+v3_1^2)*x
            +((v1_1*ct+v2_1*st)*v1_2+(-v1_1*st+v2_1*ct)*v2_2+v3_1*v3_2)*y
            +((v1_1*ct+v2_1*st)*v1_3+(-v1_1*st+v2_1*ct)*v2_3+v3_1*v3_3)*z; 
        yy=((v1_2*ct+v2_2*st)*v1_1+(-v1_2*st+v2_2*ct)*v2_1+v3_1*v3_2)*x
            +((v1_2*ct+v2_2*st)*v1_2+(-v1_2*st+v2_2*ct)*v2_2+v3_2^2)*y
            +((v1_2*ct+v2_2*st)*v1_3+(-v1_2*st+v2_2*ct)*v2_3+v3_2*v3_3)*z;
        zz=((v1_3*ct+v2_3*st)*v1_1+(-v1_3*st+v2_3*ct)*v2_1+v3_1*v3_3)*x
            +((v1_3*ct+v2_3*st)*v1_2+(-v1_3*st+v2_3*ct)*v2_2+v3_2*v3_3)*y
            +((v1_3*ct+v2_3*st)*v1_3+(-v1_3*st+v2_3*ct)*v2_3+v3_3^2)*z;
        Ans=append(Ans,center+[xx,yy,zz]);
      );
    );
    if(length(Ans)==1,
      Ans=Ans_1;
    );
  );
  Ans;
);
////%Rotatepoint3d end////

////%Rotatedata3d start////
Rotatedata3d(nm,P3data,w1,w2):=Rotatedata3d(nm,P3data,w1,w2,[]);
Rotatedata3d(nm,P3data,w1,w2,options):=(
//help:Rotatedata3d("1",["sl3d1","sc3d2"],[0,0,1],pi/3);
//help:Rotatedata3d(options=[center,...]);
  regional(name3,name2,center,pdata,Pd3,Pd,Out,tmp,tmp1,
       Ltype,Noflg,opcindy,opstr,color);
  name3="rot3d"+nm;
  name2="rot2d"+nm;
  center=[0,0,0];
  tmp=Divoptions(options);
  Ltype=tmp_1;
  Noflg=tmp_2;
  color=tmp_(length(tmp)-2);
  opstr=tmp_(length(tmp)-1);
  opcindy=tmp_(length(tmp));
  tmp1=tmp_6;
  if(length(tmp1)>0,
    center=tmp1_1;
  );
  if(islist(P3data) & isstring(P3data_1),Pd3=P3data,Pd3=[P3data]);
  Out=[];
  forall(Pd3,Pd,
    if(isstring(Pd),Pd=parse(Pd));
//    if(Measuredepth(Pd)==1,Pd=[Pd]);
    Ans=[];
    forall(Pd,
      tmp=Rotatepoint3d(#,w1,w2,center); //180729
      Ans=append(Ans,tmp);
    );
    Out=append(Out,Ans);
  );
  Out=Flattenlist(Out);
  if(length(Out)==1,Out=Out_1);
  if(Noflg<3,
    println("generate Rotatedata3d "+name3);
    tmp=name3+"="+textformat(Out,5);
    parse(tmp);
    tmp1=Projpara(name3,["nodata"]);
    tmp=name2+"="+textformat(tmp1,5);
    parse(tmp);
    tmp=Textformat(P3data,5); // 17.12.23
    tmp=RSform(tmp,1); //180602
    tmp=replace(tmp,Dq,"");//180808
//    tmp=replace(tmp,"[","list(");
//    tmp=replace(tmp,"]",")");
    tmp=name3+"=Rotate3data("+tmp+",";
    tmp=tmp+Textformat(w1,6)+","+Textformat(w2,6);
    tmp=tmp+","+Textformat(center,6)+")";//180808
    GLIST=append(GLIST,tmp);
    tmp=name2+"=Projpara("+name3+")";
    GLIST=append(GLIST,tmp);
  );
  if(Noflg<2,
    if(isstring(Ltype),
      if(color!=KCOLOR, //180904
        Texcom("{");Com2nd("Setcolor("+color+")");//180722
      );
      Ltype=GetLinestyle(text(Noflg)+Ltype,name2);
      if(color!=KCOLOR, //180904
        Texcom("}");//180722
      );
    ,
      if(Noflg==1,Ltype=0);
    );
    GCLIST=append(GCLIST,[name2,Ltype,opcindy]);
    if(SUBSCR==1, //  15.02.11
      Subgraph(name3,opcindy);
    );
  );
  Out;
);
////%Rotatedata3d end////

////%Translatepoint3d start////
Translate3pt(point,w1):=Translatepoint3d(point,w1);
Translatepoint3d(point,w1):=(
//help:Translatepoint3d(pt3d,[1,2,3]);
  regional(Eps,Ans,PtL,pt,num,xx,yy,zz,flg);
  Eps=10^(-4);
  if(Measuredepth(point)>0,
    PtL=point;
  ,
    PtL=[point];
  );
  Ans=[];
  flg=0;
  forall(1..length(PtL),num,
    pt=PtL_num;
    if(pt_1=="inf",
      Ans=append(Ans,["inf"]);
      flg=1;
    );
    if(flg==0,
      xx=pt_1+w1_1; yy=pt_2+w1_2; zz=pt_3+w1_3;
      Ans=append(Ans,[xx,yy,zz]);
    );
  );
  if(length(Ans)==1,
    Ans=Ans_1;
  );
  Ans;
);
////%Translatepoint3d end////

////%Translatedata3d start////
Translatedata3d(nm,P3data,w1):=Translatedata3d(nm,P3data,w1,[]);
Translatedata3d(nm,P3data,w1,options):=(
//help:Translatedata3d("1",["sl3d1"],[1,2,3]);
  regional(name3,name2,pdata,Pd3,Pd,Out,tmp,tmp1,
      Ltype,Noflg,opcindy,color);
  name3="tra3d"+nm;
  name2="tra2d"+nm;
  tmp=Divoptions(options);
  Ltype=tmp_1;
  Noflg=tmp_2;
  color=tmp_(length(tmp)-2);
  opcindy=tmp_(length(tmp));
  if(islist(P3data) & isstring(P3data_1),Pd3=P3data,Pd3=[P3data]);
  Out=[];
  forall(Pd3,Pd,
    if(isstring(Pd),Pd=parse(Pd));
    if(Measuredepth(Pd)==1,Pd=[Pd]);
    Ans=[];
    forall(Pd,
      tmp=Translatepoint3d(#,w1);
      Ans=append(Ans,tmp);
    );
    Out=append(Out,Ans);
  );
  Out=Flattenlist(Out);
  if(length(Out)==1,Out=Out_1);
  if(Noflg<3,
    println("generate Translatedata3d "+name3);
    tmp=name3+"="+textformat(Out,5);
    parse(tmp);
    tmp1=Projpara(name3,["nodata"]);
    tmp=name2+"="+textformat(tmp1,5);
    parse(tmp);
    tmp=textformat(P3data,5); // 17.12.23
    tmp=RSform(tmp,1); // 180602
    tmp=replace(tmp,Dq,""); //180808
//    tmp=text(P3data);
//    tmp=replace(tmp,"[","list(");
//    tmp=replace(tmp,"]",")");
    tmp=name3+"=Translate3data("+tmp+","+textformat(w1,5)+")";
    GLIST=append(GLIST,tmp);
    tmp=name2+"=Projpara("+name3+")";
    GLIST=append(GLIST,tmp);
  );
  if(Noflg<2,
    if(isstring(Ltype),
      if(color!=KCOLOR, //180904
        Texcom("{");Com2nd("Setcolor("+color+")");//180722
      );
	  Ltype=GetLinestyle(text(Noflg)+Ltype,name2);
      if(color!=KCOLOR, //180904
        Texcom("}");//180722
      );
	,
      if(Noflg==1,Ltype=0);
    );
    GCLIST=append(GCLIST,[name2,Ltype,opcindy]);
    if(SUBSCR==1, //  15.02.11
      Subgraph(name3,opcindy);
    );
  );
  Out;
);
////%Translatedata3d end////

////%Reflectpoint3d start////
Reflect3pt(point,vecL):=Reflectpoint3d(point,vecL);
Reflectpoint3d(point,vecL):=(
//help:Reflectpoint3d(pt3d,[v1,v2,v3]);
  regional(ans,v1,v2,v3,tmp,tmp1);
  if(length(vecL)==1,
    v1=vecL_1;
    ans=2*v1-point;
  );
  if(length(vecL)==2,
    v1=vecL_1;
    v2=vecL_2;
    v3=(v2-v1)/|v2-v1|;
    tmp=v1+Dotprod(point-v1,v3)*v3;
    ans=2*tmp-point;
  );
  if(length(vecL)==3,
    v1=vecL_1;
    v2=vecL_2;
    v3=vecL_3;
    tmp=Crossprod(v2-v1,v3-v1);
    tmp1=point-Dotprod(tmp,point-v1)/|tmp|^2*tmp;
    ans=2*tmp1-point;
  );
  ans;
);
////%Reflectpoint3d end////

////%Reflectdata3d start////
Reflectdata3d(nm,P3data,vecL):=Reflectdata3d(nm,P3data,vecL,[]);
Reflectdata3d(nm,P3data,vecL,options):=(
//help:Reflectdata3d("1",["sl3d1"],[v1,v2,v3]);
//help:Reflectdata3d("1",["sl3d1"],[v1,v2]);
//help:Reflectdata3d("1",["sl3d1"],[v1]);
  regional(name3,name2,pdata,Pd3,Pd,Out,tmp,tmp1,
      Ltype,Noflg,opcindy,color);
  name3="ref3d"+nm;
  name2="ref2d"+nm;
  tmp=Divoptions(options);
  Ltype=tmp_1;
  Noflg=tmp_2;
  color=tmp_(length(tmp)-2);
  opcindy=tmp_(length(tmp));
  if(islist(P3data) & isstring(P3data_1),Pd3=P3data,Pd3=[P3data]);
  Out=[];
  forall(Pd3,Pd,
    if(isstring(Pd),Pd=parse(Pd));
//    if(Measuredepth(Pd)==1,Pd=[Pd]);
    Ans=[];
    forall(Pd,
      tmp=Reflectpoint3d(#,vecL);
      Ans=append(Ans,tmp);
    );
    Out=append(Out,Ans);
  );
  Out=Flattenlist(Out);
  if(length(Out)==1,Out=Out_1);
  if(Noflg<3,
    println("generate Reflectdata3d "+name3);
    tmp=name3+"="+textformat(Out,5);
    parse(tmp);
    tmp1=Projpara(name3,["nodata"]);
    tmp=name2+"="+Textformat(tmp1,5);
    parse(tmp);
    tmp=Textformat(P3data,5); // 17.12.23
    tmp=RSform(tmp,1); // 180602
    tmp=replace(tmp,Dq,""); //180807
//    tmp=text(P3data);
//    tmp=replace(tmp,"[","list(");
//    tmp=replace(tmp,"]",")");
    tmp=name3+"=Reflect3data("+tmp;
    tmp=tmp+","+RSform(Textformat(vecL,5),2)+")";
    GLIST=append(GLIST,tmp);
    tmp=name2+"=Projpara("+name3+")";
    GLIST=append(GLIST,tmp);
  );
  if(Noflg<2,
    if(isstring(Ltype),
      if(color!=KCOLOR, //180904
        Texcom("{");Com2nd("Setcolor("+color+")");//180722
      );
      Ltype=GetLinestyle(text(Noflg)+Ltype,name2);
      if(color!=KCOLOR, //180904
        Texcom("}");//180722
      );
    ,
      if(Noflg==1,Ltype=0);
    );
    GCLIST=append(GCLIST,[name2,Ltype,opcindy]);
    if(SUBSCR==1, //  15.02.11
      Subgraph(name3,opcindy);
    );
  );
  Out;
);
////%Reflectdata3d end////

// 180806
////%Scalepoint3d start////
Scale3pt(point,ratio,center):=Scalepoint3d(point,ratio,center);
Scalepoint3d(point,ratio):=Scalepoint3d(point,ratio,[0,0,0]);//180809
Scalepoint3d(point,ratio,center):=(
//help:Scalepoint3d(A,[3,2,4]);
//help:Scalepoint3d(A,[3,2,4],[1,2,3]);
  regional(ra1,ra2,ra3,X1,Y1,Z1,X2,Y2,Z2,Cx,Cy,Cz);
  X1=point_1; Y1=point_2;  Z1=point_3;
  if(length(ratio)==1, //1808from
    ra1=ratio; ra2=ratio; ra3=ratio;
  ,
    ra1=ratio_1; ra2=ratio_2; ra3=ratio_3;
  );//1808to
  Cx=center_1; Cy=center_2; Cz=center_3;
  X2=Cx+ra1*(X1-Cx);
  Y2=Cy+ra2*(Y1-Cy);
  Z2=Cz+ra3*(Z1-Cz);
  [X2,Y2,Z2];
);
////%Scalepoint3d end////

// 180808
////%Scaledata3d start////
Scaledata3d(nm,P3data,ratio):=Scaledata3d(nm,P3data,ratio,[]);
Scaledata3d(nm,P3data,ratio,options):=(
//help:Scaledata3d("1",["sl3d1"],[v1,v2,v3]);
  regional(name3,name2,pdata,Pd3,Pd,Out,tmp,tmp1,
      reL,Ltype,Noflg,opcindy,color,center);
  name3="ref3d"+nm;
  name2="ref2d"+nm;
  tmp=Divoptions(options);
  Ltype=tmp_1;
  Noflg=tmp_2;
  reL=tmp_6;
  color=tmp_(length(tmp)-2);
  opcindy=tmp_(length(tmp));
  center=[0,0,0];
  if(length(reL)>0,
    center=reL_1;
  );
  if(islist(P3data) & isstring(P3data_1),Pd3=P3data,Pd3=[P3data]);
  Out=[];
  forall(Pd3,Pd,
    if(isstring(Pd),Pd=parse(Pd));
//    if(Measuredepth(Pd)==1,Pd=[Pd]);
    Ans=[];
    forall(Pd,
      tmp=Scalepoint3d(#,ratio,center);
      Ans=append(Ans,tmp);
    );
    Out=append(Out,Ans);
  );
  Out=Flattenlist(Out);
  if(length(Out)==1,Out=Out_1);
  if(Noflg<3,
    println("generate Scaledata3d "+name3);
    tmp=name3+"="+textformat(Out,5);
    parse(tmp);
    tmp1=Projpara(name3,["nodata"]);
    tmp=name2+"="+Textformat(tmp1,5);
    parse(tmp);
    tmp=Textformat(P3data,5); // 17.12.23
    tmp=RSform(tmp,1); // 180602
    tmp=replace(tmp,Dq,""); //180807
//    tmp=text(P3data);
//    tmp=replace(tmp,"[","list(");
//    tmp=replace(tmp,"]",")");
    tmp=name3+"=Scale3data("+tmp;
    tmp=tmp+","+Textformat(ratio,5);
    tmp=tmp+","+Textformat(center,5)+")";
    GLIST=append(GLIST,tmp);
    tmp=name2+"=Projpara("+name3+")";
    GLIST=append(GLIST,tmp);
  );
  if(Noflg<2,
    if(isstring(Ltype),
      if(color!=KCOLOR, //180904
        Texcom("{");Com2nd("Setcolor("+color+")");//180722
      );
      Ltype=GetLinestyle(text(Noflg)+Ltype,name2);
      if(color!=KCOLOR, //180904
        Texcom("}");//180722
      );
    ,
      if(Noflg==1,Ltype=0);
    );
    GCLIST=append(GCLIST,[name2,Ltype,opcindy]);
    if(SUBSCR==1, //  15.02.11
      Subgraph(name3,opcindy);
    );
  );
  Out;
);
////%Scaledata3d end////

////%Xyzcoord start////
Xyzcoord(pm,ps):=Xyzcoord(pm_1,pm_2,ps); //181028from
Xyzcoord(X,Y,ps):=(
//help:Xyzcoord(A.x,A.y,Az.y);
  regional(pt3d);
  pt3d=Mainsubpt3d([X,Y],ps);
  pt3d;//181028to
);
////%Xyzcoord end////

////%PutonCurve3d start////
PutonCurve3d(name,pdstr):=(
//help:PutonCurve3d("T","sc3d1");
  regional(pt,pd2str,tmp,tmp1,tmp2);
  pd2str=replace(pdstr,"3d","2d");
  PutonCurve(name,pd2str);
  pt=parse(name+".xy");
  tmp=Nearestpt(pt,pd2str);  // 15.03.13
  tmp1=Paramoncurve(tmp_1,tmp_2,pd2str);
  tmp="sub"+pd2str;
  tmp2=PointonCurve(tmp1,tmp);
//  pt=append(pt,tmp2_2); //181028[2lines]
  pt=Xyzcoord(pt,tmp2); // 15.03.13
  tmp=name+"z.xy="+textformat(tmp2,5);
  parse(tmp);
 // VLIST=select(VLIST,#_1!=name+"3d");
  Defvar(name+"3d",pt);
);
////%PutonCurve3d end////

////%Mkpointlist start////
Mkpointlist():=Mkpointlist([]); //16.11.12
Mkpointlist(options):=( //181030
  regional(Eps,dp,mv,pos,worklist,plist,pt,ptstr,pt3,ptz,par,
     tmp,tmp1,tmp2,tmp3,tmp4,p1,p2,flg);
  dp=pi/24;
  mv=NE.x-SW.x;
  Eps=10^(-4);
  pos=[NE.x+1,NE.y];
  worklist=Workprocess(); //181030
  plist=select(worklist,length(#_3)!=2);
  plist=apply(plist,#_1);
  plist=remove(plist,PTEXCEPTION);
  tmp=apply(VLIST,#_1);//181029from
  tmp=select(tmp,indexof(#,"3d")>0);
  tmp2=apply(tmp,replace(#,"3d",""));
  forall(tmp2,ptstr,
    if(!contains(plist,ptstr),
      tmp=select(VLIST,
            (#_1==pt+"3d")%(#_1==pt+"2d")%(#_1==pt+"fix"));
      VLIST=remove(VLIST,tmp);
    );
  ); //181029to
  if(SUBSCR==0,plist=[]);
  forall(plist,ptstr,
    pt=parse(ptstr);
    inspect(pt,"ptsize",3);
    inspect(pt,"color",2);
    inspect(pt,"textsize",TSIZE);
    ptz=text(pt)+"z";
    tmp=Finddef(pt);
    tmp=select(VLIST,#_1==text(pt)+"3d");
    if(length(tmp)==0,
      tmp=parse(ptz); //181108from
      if(ispoint(tmp),
        pt3=Mainsubpt3d(pt.xy,tmp.xy); //181108to
      ,
        if(abs(cos(THETA))>Eps,//181028from
          tmp1=Mainsubpt3d(pt.xy,0); 
          tmp=Parasubpt(tmp1);
          Putpoint(ptz,tmp,[tmp_1,parse(ptz+".y")]);
          pt3=Mainsubpt3d(pt.xy,parse(ptz+".xy"));
        ,
          if(abs(sin(PHI))>abs(cos(PHI)), //181029from
            tmp=Parasubpt([-pt.x/sin(PHI),0,pt.y]);
          ,
            tmp=Parasubpt([0,pt.x/cos(PHI),pt.y]);
          );
          Putpoint(ptz,tmp,[parse(ptz+".x"),pt.y]);//181029t
          pt3=Mainsubpt3d(pt.xy,parse(ptz+".xy"));
        );
      ); //181028to
      Defvar(text(pt)+"3d",pt3);
      Defvar(text(pt)+"fix",0);
    );
    flg=0;
    if(isstring(ptz),ptz=parse(ptz));//181029from
    inspect(ptz,"ptsize",3);
    inspect(ptz,"color",3);
    inspect(ptz,"textsize",TSIZEZ);//181029to
    if(isselected(pt),
      if(parse(text(pt)+"fix")!=1,
        tmp=select(VLIST,#_1==text(pt)+"3d");
        tmp1=tmp_1_2;
        pt3=Mainsubpt3d(pt.xy,ptz.xy); //181029
        Putpoint(text(ptz),Parasubpt(pt3));
        if(Norm(tmp1-pt3)>Eps,
           Defvar(text(pt)+"3d",pt3);
        );
        flg=1;
      );
    );
    if(isselected(ptz),//181108from
      tmp=select(VLIST,#_1==text(pt)+"3d"); 
      tmp1=tmp_1_2;
      tmp=Parasubpt(tmp1); //181108from
      if(abs(cos(THETA))>Eps,
        tmp=text(ptz)+".x="+format(tmp_1,6);
        parse(tmp);
        tmp=Parapt([tmp1_1,tmp1_2,ptz.y]);
        Putpoint(text(pt),tmp);
     ,
        tmp=text(ptz)+".y="+format(tmp_2,6);
        parse(tmp);
        if(abs(sin(PHI+dp))>abs(cos(PHI+dp)), //181108
          tmp=-(ptz.x-mv-tmp1_2*cos(PHI+dp))/sin(PHI+dp);
          tmp=Parapt([tmp,tmp1_2,tmp1_3]);
        ,
          tmp=(ptz.x-mv+tmp1_1*sin(PHI+dp))/cos(PHI+dp); //181109pm
          tmp=Parapt([tmp1_1,tmp,tmp1_3]);
        );
        Putpoint(text(pt),tmp);
      );
      pt3=Mainsubpt3d(pt.xy,ptz.xy); 
      Defvar(text(pt)+"3d",pt3);//181108to
      flg=2;
    );
    if(isselected(TH) % isselected(FI), //181029
      tmp=select(VLIST,#_1==text(pt)+"3d");
      if(length(tmp)>0, //17.10.07
        tmp1=Parapt(tmp_1_2);
        Putpoint(text(pt),tmp1); //181029
        tmp2=Parasubpt(tmp_1_2);//181027[2lines]
        Putpoint(text(ptz),tmp2); //181029
        flg=3;
      ); //17.10.07
    );
    if(flg==0, //181030from
      pt3=Mainsubpt3d(pt.xy,ptz.xy);
      Defvar(text(pt)+"3d",pt3);
    ); //181030to
    if(isselected(pt) % isselected(ptz),
      drawtext(pos,text(pt3));
    );
    if(!contains(["p","q"],text(pt)),
      ptL=append(ptL,pt);
    );
  );
);
////%Mkpointlist end////

////%Mkseg3d start////
Mkseg3d():=Mkseg3d([]);
Mkseg3d(options):=(
  regional(seg,nmseg,def,ptA,ptB,segL,opstr,opcindy,
       name,strg,Ltype,Noflg,tht,tmp,tmp1,tmp2,tmp3);
  name="geoseg3d";
  strg=name+"=list(";
  tmp=Divoptions(options);
  Ltype=tmp_1;
  Noflg=tmp_2;
  opcindy=tmp_(length(tmp));
  segL=[];
  forall(allsegments(),seg,
	inspect(seg,"labeled",false);
    tmp=Finddef(seg);
    def=tmp_1;
    ptA=tmp_2;
    ptB=tmp_3;
    if(ispoint(parse(ptA)) & ispoint(parse(ptB)),
      tmp1=select(VLIST,indexof(#_1,ptA+"3d")>0);
      tmp2=select(VLIST,indexof(#_1,ptB+"3d")>0);
      if(length(tmp1)>0 & length(tmp2)>0,
        tmp1="["+ptA+"3d,"+ptB+"3d]";
        nmseg=ptA+ptB;
//        Spaceline(nmseg,parse(tmp1),append(options,"Msg=nodisp")); //15.06.15
        Spaceline("-"+nmseg+"3d",[ptA+"3d",ptB+"3d"], // 16.04.07
		      append(options,"Msg=nodisp")); //15.06.15
        segL=append(segL,nmseg+"3d");// 16.04.07
        strg=strg+nmseg+"3d,";// 16.04.07
      );
    );
  );
  println("generate totally "+name);
  if(length(segL)>0,  // 15.03.06
    strg=substring(strg,0,length(strg)-1)+")";
    if(Noflg<3,
      GLIST=append(GLIST,strg);
    );
    tmp1=apply(segL,Dq+#+Dq);  //15.03.02
    tmp=name+"="+text(tmp1);
    parse(tmp);
  );
  segL;
);
////%Mkseg3d end////

////%Ptseg3data start////
Ptseg3data():=Ptseg3data([]);
//help:Ptseg3data();
//help:Ptseg3data([A,B]);
Ptseg3data(options):=(
  regional(pt,pt3,plist,tmp,tmp1,tmp2);
  if(isselected(TH) % isselected(FI),
    tmp=remove(allpoints(),[NE,SW,TH,FI]);
    tmp=remove(tmp,options); //16.11.12
    tmp=apply(tmp,text(#));
    plist=select(tmp,substring(#,length(#)-1,length(#))!="z");
    forall(plist,pt,
      tmp1=text(pt);
      tmp=select(VLIST,#_1==tmp1+"3d"); //17.10.07
      if(length(tmp)>0,
        pt3=tmp_1_2;
        tmp=tmp1+".xy="+Textformat(Parapt(pt3),6);//181107
        parse(tmp);
        if(SUBSCR==1,
          tmp=tmp1+"z"+".xy="+Textformat(Parasubpt(pt3),6);//181107
          parse(tmp);
        );
      ,
        tmp=Mainsubpt3d(parse(pt+".xy"),parse(tmp1+"z.xy")); //181107[2lines]
        Defvar(tmp1+"3d",tmp);
      );
    );
  ,
    Mkpointlist(options); // 16.12.18
  );
  forall(alllines(),
    #.color=[0.5,0.5,1];
  );
  SEG3dlist=Mkseg3d(options);
  SEG3dlist;
);
////%Ptseg3data end////

////%Putonseg3d start////
Putonseg3d(name,ptL):=Putonseg3d(name,ptL_1,ptL_2,[]);
Putonseg3d(name,Arg1,Arg2):=(
  if(islist(Arg1),
    Putonseg3d(name,Arg1_1,Arg1_2,Arg2);
  ,
    Putonseg3d(name,Arg1,Arg2,[]);
  );
);
Putonseg3d(name,pt1,pt2,options):=(
//help:Putonseg3d("C",[A,B]);
//help:Putonseg3d("C",A,B);
  regional(par,pn1,pn2,tmp,tmp1,tmp2,tmp3);
  par=0.5;
  tmp=divoptions(options);
  if(length(tmp_6)>0,
    par=tmp_6_1;
  );
  if(ispoint(pt1), //181030from
    Putonseg(name,pt1,pt2,[par]);
  ,
    Putonseg(name,Parapt(pt1),Parapt(pt2),[par]);
  ); //181030from
  inspect(parse(name),"ptsize",3);
  inspect(parse(name),"color",2);
  inspect(parse(name),"textsize",TSIZEZ);
  Putpoint(name+"z",[parse(name+".x"),0]);
  inspect(parse(name+"z"),"ptsize",3);
  inspect(parse(name+"z"),"color",3);
  inspect(parse(name+"z"),"textsize",TSIZEZ);
  if(ispoint(pt1),
    pn1=text(pt1);
    pn2=text(pt2);
    tmp1=replace("PCz.xy=PAz.xy+|PC-PA|/|PB-PA|*(PBz.xy-PAz.xy)","PC",name);
    tmp1=replace(tmp1,"PA",pn1);
    tmp1=replace(tmp1,"PB",pn2);
    parse(tmp1);  
  ,
    pn1=Textformat(Parapt(pt1),5); //181030from
    pn2=Textformat(Parapt(pt2),5);
    tmp1=replace("PCz.xy=PAs+Norm(PC-PAm)/Norm(PBm-PAm)*(PBs-PAs)","PC",name);
    tmp1=replace(tmp1,"PAm",pn1);
    tmp1=replace(tmp1,"PBm",pn2);
    pn1=Textformat(Parasubpt(pt1),5); //181030from
    pn2=Textformat(Parasubpt(pt2),5);
    tmp1=replace(tmp1,"PAs",pn1);
    tmp1=replace(tmp1,"PBs",pn2);
    parse(tmp1);
  );
  tmp1=parse(name+".xy"); //181028[3lines]
  tmp2=parse(name+"z.xy"); 
  tmp=Xyzcoord(tmp1,tmp2);
  Defvar(name+"3d",tmp);
);
////%Putonseg3d end////

////%Putpoint3d start////
Putpoint3d(ptslist):=Putpoint3d(ptslist,"",0);
Putpoint3d(Arg1,Arg2):=( // 16.03.02 from
  if(islist(Arg1),
    Putpoint3d(Arg1,Arg2,0);
  ,
    Putpoint3d(Arg1,Arg2,"fix");
  );
);
Putpoint3d(Arg1,Arg2,Arg3):=(
//help:Putpoint3d(["A",[2,1,3]]);
//help:Putpoint3d(["A",[2,1,3]],"fix");
//help:Putpoint3d("A",[2,1,3]);
//help:Putpoint3d(["A",[2,1,3]],["fix"]);
  regional(nn,kk,pt,pt3,ptslist,fixstr,tmp,tmp1,tmp2,tmp3); //16.08.19
  if(isstring(Arg1),
    ptslist=[Arg1,Arg2];
    fixstr=Arg3;
  ,
    ptslist=Arg1;
    fixstr=Arg2;
  ); 
  if(islist(fixstr),fixstr=fixstr_1);// 16.03.02 until
  nn=length(ptslist)/2;
  forall(1..nn,kk, // 16.08.19from
    tmp1=ptslist_(2*kk-1);
    pt3=ptslist_(2*kk); // 16.08.19until
    VLIST=select(VLIST,#_1!=tmp1+"3d");
    tmp2=parse(tmp1);
    if(ispoint(tmp2), // 16.05.26from
      if(islist(fixstr),tmp=fixstr_1,tmp=fixstr);
      tmp=Toupper(tmp);
      if(tmp!="FIX", 
        tmp=Xyzcoord(tmp2.xy,parse(tmp1+"z.xy")); //181028
      ,
        tmp=pt3;
      ); 
      Defvar(tmp1+"3d",tmp);
    ,
      Defvar(tmp1+"3d",pt3);
    );   // 16.05.26until
    Defvar(tmp1+"fix",0);
    pt=Parapt(pt3);
    Putpoint(tmp1,pt,parse(tmp1+".xy"));
    inspect(parse(tmp1),"ptsize",3);
    inspect(parse(tmp1),"color",2);
    inspect(parse(tmp1),"textsize",TSIZE);
    if(SUBSCR==1,
      tmp2=tmp1+"z";
      Putpoint(tmp2,Parasubpt(pt3));
      inspect(parse(tmp2),"ptsize",3);
      inspect(parse(tmp2),"color",3);
      inspect(parse(tmp2),"textsize",TSIZEZ);
    );
  );
  if(islist(fixstr),tmp=fixstr_1,tmp=fixstr);
  if(tmp=="fix" % tmp=="Fix",
    Fixpoint3d(ptslist);
  );
);
////%Putpoint3d end////

////%Fixpoint3d start////
Fixpoint3d(ptlist):=(
//    help:Fixpoint3d(["O",[0,0,0],"X",[1,0,0]]);
  regional(name,pt3,pt2,tmp,tmp1,tmp2);
  forall(1..(length(ptlist)/2),
    name=ptlist_(2*#-1);
    Defvar(name+"fix",1);
    pt3=ptlist_(2*#);
    pt2=Parapt(pt3);
    tmp1=textformat(pt2_1,5);
    tmp2=textformat(pt2_2,5);
    tmp=name+".xy=["+tmp1+","+tmp2+"]";
    parse(tmp);
    tmp1=name+".x+NE.x-SW.x";
    tmp2=textformat(pt3_3,5);
    tmp=name+"z.xy=["+tmp1+","+tmp2+"];";
    parse(tmp);
  );
);
////%Fixpoint3d end////

////%Letter3d start////
Letter3d(dtlist):=Letter3d(dtlist,[]); //181218from
Letter3d(pt3d,dir,name):=Letter3d([pt3d,dir,name],[]); 
Letter3d(pt3d,dir,name,options):=Letter3d([pt3d,dir,name],options);
Letter3d(dtlist,options):=(
//help:Letter3d(point3d,,direction,name);
//help:Letter3d([point3d,,direction,name],options]);
  regional(dt,nall,jj);
  dt=dtlist;
  if(mod(length(dt),3)!=0,
    println("   Improper data");
  ,
    nall=length(dt)/3;
    forall(1..nall,
      jj=#*3-2;
      tmp=dt_jj;
      if(ispoint(tmp),tmp=parse(text(tmp)+"3d"));
      dt_jj=Parapt(tmp);
    );
    Letter(dt,options);
  );
); //181218to
////%Letter3d end////

////%Expr3d start////
Expr3d(dtlist):=Expr3d(dtlist,[]); //181218from
Expr3d(pt3d,dir,name):=Expr3d([pt3d,dir,name],[]); //181218from
Expr3d(pt3d,dir,name,options):=Expr3d([pt3d,dir,name],options);
Expr3d(dtlist,options):=(
//help:Expr3d(point3d,,direction,name);
//help:Expr3d([point3d,,direction,name],options]);
  regional(dt,nall,jj);
  dt=dtlist;
  if(mod(length(dt),3)!=0,
    println("   Improper data");
  ,
    nall=length(dt)/3;
    forall(1..nall,
      jj=#*3-2;
      tmp=dt_jj;
      if(ispoint(tmp),tmp=parse(text(tmp)+"3d"));
      dt_jj=Parapt(tmp);
    );
    Expr(dt,options);
  );
); //181218to
////%Expr3d end////

////%Perppt start////
Perppt(name,ptstr,pLstr):=Putperp(name,ptstr,pLstr,"draw");
Perppt(name,ptstr,pLstr,option):=Putperp(name,ptstr,pLstr,option);
Putperp(name,ptstr,pLstr):=Putperp(name,ptstr,pLstr,"put");
Putperp(name,ptstr,pLstr,option):=(
//help:Perppt("N","O","A-B-C");
//help:Perppt("N","O","A-B-C","put");
//help:Perppt("N","O","A-B","none");
  regional(out,Eps,N3d,sgstr,pP,pA,pB,pC,tmp,tmp1,flgpL);
  Eps=10^(-4);
  pP=parse(ptstr+"3d");
  tmp=indexof(pLstr,"-");
  pA=parse(substring(pLstr,0,tmp-1)+"3d");
  tmp1=substring(pLstr,tmp,length(pLstr));
  tmp=indexof(tmp1,"-");
  if(tmp>0,
    pB=parse(substring(tmp1,0,tmp-1)+"3d");
    pC=parse(substring(tmp1,tmp,length(tmp1))+"3d");
    flgpL=1;
  ,
    pB=parse(tmp1+"3d");
    flgpL=0;
  );
  if(flgpL==1,
    tmp=Crossprod(pB-pA,pC-pA);
    if(abs(tmp)<Eps,
      err("not a plane");
    ,
      tmp=tmp/|tmp|;
      N3d=pP+tmp;
      Defvar("tmp3d",N3d); // temporary
      sgstr=ptstr+"-tmp";
      tmp=IntersectsgpL(name,sgstr,pLstr,["Screen=n"]); //181031
      VLIST=select(VLIST,#_1!="tmp3d");
      out=tmp_1;
      Defvar(name+"3d",tmp_1);
    );
  ,
    if(|pB-pA|<Eps,
      err("on the line");
    ,
      tmp1=(pB-pA)/|pB-pA|;
      tmp=Dotprod(pP-pA,tmp1);
      out=pA+tmp*tmp1;
      Defvar(name+"3d",out);
    );
  );
  if(islist(option),tmp=option_1,tmp=option);
  tmp=substring(tmp,0,1);
  if(tmp=="P" % tmp=="p",
    Putpoint3d([name,out]);
    Fixpoint3d([name,out]);
  );
  if(tmp=="D" % tmp=="d",
    Drawpoint3d(out);
  );
  out;
);  
////%Perppt end////

////%Perpplane start////
Perpplane(name,ptstr,nvec):=
    Perpplane(name,ptstr,nvec,"draw");
Perpplane(name,ptstr,nstr,option):=(
//help:Perpplane("A-B","P",[1,3,2]);
//help:Perpplane("A-B","P",[1,3,2]);
//help:Perpplane(option=["Put/Draw"]);
  regional(Eps,nvec,sgstr,pP,v1,v2,v3,
    th,ph,pA,pB,tmp,tmp1,tmp2);
  Eps=10^(-4);
  if(isstring(nstr),nvec=parse(nstr+"3d"),nvec=nstr);
  if(indexof(ptstr,"3d")==0, //181107from
    pP=parse(ptstr+"3d");
  ,
    pP=parse(ptstr);
  ); //181107to
  v3=nvec/|nvec|;
  th=THETA; ph=PHI;
  tmp=findangle(v3);
  THETA=tmp_1; PHI=tmp_2;
  v1=Cancoordpara([1,0,0]);
  v2=Cancoordpara([0,1,0]);
  THETA=th; PHI=ph;
  tmp=indexof(name,"-");
  tmp1=substring(name,0,tmp-1);
  tmp2=substring(name,tmp,length(name));
  tmp=indexof(pLstr,"-");
  pA=pP+v1;
  pB=pP+v2;
  if(islist(option),tmp=option_1,tmp=option);
  tmp=Toupper(substring(tmp,0,1)); // 16.06.19
  if(tmp=="P",
    Putpoint3d([tmp1,pA,tmp2,pB],["fix"]);
  ,
    Defvar(tmp1+"3d",pA); //181107[2lines]
    Defvar(tmp2+"3d",pB);
  );
  if(tmp=="D",
    Drawpoint3d(pA);
    Drawpoint3d(pB);
  );
  [pA,pB];
);
////%Perpplane end////

////%Drawpoint3d start////
Drawpoint3d(pt3):=Drawpoint3d(pt3,["Color=green"]);
Drawpoint3d(pt3,options):=(
//help:Drawpoint3d(pt3d);
//help:Drawpoint3d(options=["Color=(green)"]);
  regional(ptL,tmp,tmp1,tmp2);
  tmp=Divoptions(options);
  opcindy=tmp_(length(tmp));
  if(Measuredepth(pt3)==0,ptL=[pt3],ptL=pt3);
  forall(ptL,
    tmp="draw("+Textformat(Parapt(#),6)+opcindy+")";
    parse(tmp);
    if(SUBSCR==1,
      tmp="draw("+Textformat(Parasubpt(#),6)+opcindy+")";
       parse(tmp);
    );
  );
);
////%Drawpoint3d end////

////%Pointdata3d start////
Pointdata3d(nm,pt3):=Pointdata3d(nm,pt3,[]);//181017from
Pointdata3d(nm,pt3,options):=( //181017from
//help:Pointdata3d("1",pt3dlist,options);
  regional(pt3L,pt2L,tmp);
  if(Measuredepth(pt3)==0,pt3L=[pt3],pt3L=pt3);
  pt2L=apply(pt3L,Parapt(#));
  Pointdata("2d"+nm,pt2L,append(options,"Disp=n"));
  tmp="pt3d"+nm+"="+format(pt3L,6);
  parse(tmp);
); //181017to
////%Pointdata3d end////

////%Putaxes3d start////
Putaxes3d(size):=(
//help:Putaxes3d(5);
//help:Putaxes3d([1,2,3]);
  regional(sL);
  if(islist(size),sL=size,sL=[size,size,size]);
  Putpoint3d(["O",[0,0,0]],"fix"); //17.06.02from
  Putpoint3d(["X",[sL_1,0,0]],"fix");
  Putpoint3d(["Y",[0,sL_2,0]],"fix");
  Putpoint3d(["Z",[0,0,sL_3]],"fix"); 
//  Fixpoint3d(["O",[0,0,0]]);
//  Fixpoint3d(["X",[sL_1,0,0],"Y",[0,sL_2,0],"Z",[0,0,sL_3]]);//17.06.02funtil
);
////%Putaxes3d end////

////%IntersectsgpL start////
IntersectsgpL(name,sgstr,pLstr):=
   IntersectsgpL(name,sgstr,pLstr,["ie"]);
IntersectsgpL(name,sgstr,pLstr,optionsorg):=(
//help:IntersectsgpL("R","P-Q","A-B-C");
//help:IntersectsgpL("",[p1,p2],[p3,p4,p5]);
//help:IntersectsgpL(options=["draw(put)","ie","Screen=n"+pointoptions]);
  regional(options,eqL, strL,ptflg,out,pP,pQ,pA,pB,pC,pH,pK,pR,tseg,tt,ss,Eps,
    flg,scrflg,nvec,tmp,tmp1,tmp2,tmp3,tmp4);
  options=optionsorg; //181026from
  tmp1="";
  if(isstring(options),
    tmp1=options;
    options=[];
  );
  options=remove(options,["draw","Draw"]);
  tmp=Divoptions(options);
  eqL=tmp_5;
  strL=tmp_7;
  if(length(tmp1)>0,
    strL=append(strL,tmp1);
  );
  ptflg=["D","ie"];
  forall(strL,
    tmp=Toupper(substring(#,0,1));
    if(tmp=="P",
      ptflg_1="P";
    );
    if((tmp=="I")%(tmp=="E"),
      if(length(#)==1,
        ptflg_2=#+"e";
      ,
        ptflg_2=#;
      );
     );
  );
  options=remove(options,strL);
  scrflg="Y"; //181031from
  forall(eqL,
    tmp=Strsplit(#,"=");
    tmp1=Toupper(substring(tmp_1,0,1)); //181111
    if(tmp1=="S",
      scrflg=Toupper(substring(tmp_2,0,1));
      options=remove(options,[#]);
    );
  ); //181031to
  tmp=select(options,substring(#,0,1)=="C");
  if(length(tmp)==0,options=append(options,"Color=green"));//181026to
  Eps=10^(-4);
  flg=0;
  if(!isstring(sgstr),  // 15.05.29
    pP=sgstr_1;
    pQ=sgstr_2;
  ,
    tmp=indexof(sgstr,"-");
    if(tmp>0,  // 15.05.28
      pP=parse(substring(sgstr,0,tmp-1)+"3d");
      pQ=parse(substring(sgstr,tmp,length(sgstr))+"3d");
    ,
      tmp1=parse(sgstr);
      pP=tmp1_1;
      pQ=tmp1_2;
    );
  );
  if(!isstring(pLstr),  // 16.02.02
    pA=pLstr_1;
    pB=pLstr_2;
    pC=pLstr_3;
  ,
    tmp=indexof(pLstr,"-");
    pA=parse(substring(pLstr,0,tmp-1)+"3d");
    tmp1=substring(pLstr,tmp,length(pLstr));
    tmp=indexof(tmp1,"-");
    pB=parse(substring(tmp1,0,tmp-1)+"3d");
    pC=parse(substring(tmp1,tmp,length(tmp1))+"3d");
  );
  nvec=Crossprod(pB-pA,pC-pA);
  if(abs(Dotprod(nvec,pQ-pP))>Eps,
    pH=(Reflectpoint3d(pP,[pA,pB,pC])+pP)/2; //180811[2lines]
    pK=(Reflectpoint3d(pQ,[pA,pB,pC])+pQ)/2;
    tmp1=pP-pH;
    tmp2=tmp1+pK-pQ;
    tmp=select(tmp2,abs(#)==max(apply(tmp2,abs(#))));
    tmp=select(1..3,tmp2_#==tmp_1);
    tmp=tmp_1;
    tseg=tmp1_tmp/tmp2_tmp;
    pR=(1-tseg)*pH+tseg*pK;
    tmp=Dotprod(pB-pA,pC-pA);
    tmp1=Dotprod(pB-pA,pB-pA);
    tmp2=Dotprod(pC-pA,pC-pA);
    tmp3=Dotprod(pR-pA,pB-pA);
    tmp4=Dotprod(pR-pA,pC-pA);
    ss=-(tmp*tmp4-tmp3*tmp2)/(tmp1*tmp2-tmp^2);
    tt=(tmp1*tmp4-tmp*tmp3)/(tmp1*tmp2-tmp^2);
    tmp1=(tseg>-Eps)&(tseg<1+Eps); //181027from
    tmp2=(ss>-Eps)&(ss<1+Eps)&(tt>-Eps)&(tt<1+Eps)&(ss+tt<1+Eps);//181029
    out=[pR,tmp1,tmp2,tseg,ss,tt]; //181027to
    tmp=ptflg_2;
    tmp1=(tmp1)%(substring(tmp,0,1)=="i"); //190114
    tmp2=(tmp2)%(substring(tmp,1,2)=="e");
    if(tmp1&tmp2&(scrflg=="Y"), //181031
      if(ptflg_1=="P", //181025
        Putpoint3d([name,pR],"fix");
//        Fixpoint3d([name,pR]); //190114
      ,
        Drawpoint3d(pR,options);
      ); 
    );
  ,
    println("   "+sgstr+" and "+pLstr+" may be parallel");//181025to
    out=[[],false,false]; //181029
  );
  out;
);
////%IntersectsgpL end////

////%Bezier3d start////
Bezier3d(nm,ptctrlist):=Bezier3(nm,ptctrlist);
Bezier3d(nm,Ag1,Ag2):=Bezier3(nm,Ag1,Ag2);
Bezier3d(nm,ptlistorg,ctrlistorg,options):=
    Bezier3(nm,ptlistorg,ctrlistorg,options);
//help:Bezier3d("1",["A","B","C"],["D","E","F","G"]);
Bezier3(nm,ptctrlist):=Bezier3(nm,ptctrlist_1,ptctrlist_2,[]);
Bezier3(nm,Ag1,Ag2):=(
  if(Measuredepth(Ag1)==0,
    Bezier3(nm,Ag1,Ag2,[]);
  ,
    if(Measuredepth(Ag1)>1,
      Bezier3(nm,Ag1_1,Ag1_2,Ag2);
    ,
      if(isstring(Ag_1_1),
        Bezier3(nm,Ag1,Ag2,[]);
      ,
        Bezier3(nm,Ag1_1,Ag1_2,Ag2);
      );
    );
  );
);
Bezier3(nm,ptlistorg,ctrlistorg,options):=( //17.10.08 greatly changed
  regional(name,name3,name2,tmp,tmp1,tmp2,
      Ltype,Noflg,opstr,eqL,Num,ii,knt,ctr,out,color);
  name="bz"+nm;
  name3="bz3d"+nm;
  name2="bz2d"+nm;
  tmp=Divoptions(options);
  Ltype=tmp_1;
  Noflg=tmp_2;
  eqL=tmp_5;
  color=tmp_(length(tmp)-2);
  opcindy=tmp_(length(tmp));
  Num=20;
  forall(eqL,
    tmp=indexof(#,"=");
    tmp1=Toupper(substring(#,0,1));
    tmp2=substring(#,tmp,length(#));
    if(tmp1=="N",
      Num=parse(tmp2);
    );
  );
  ptlist=ptlistorg;
  if(isstring(ptlistorg_1),ptlist=apply(ptlistorg,parse(#+"3d")));
  ctrlist=ctrlistorg;
  if(isstring(ctrlistorg_1),ctrlist=apply(ctrlistorg,parse(#+"3d")));
  out=[];
  forall(1..(length(ptlist)-1),ii,
    knt=[ptlist_ii,ptlist_(ii+1)];
    ctr=[ctrlist_(2*ii-1),ctrlist_(2*ii)];
    tmp="Bezierpt(T,ptlist,ctrlist)";//17.01.04
    tmp=Assign(tmp,"ptlist",knt);
    tmp=Assign(tmp,"ctrlist",ctr);
    Spacecurve(name+text(ii),tmp,"T=[0,1]",append(eqL,"nodisp"));
    GLIST=GLIST_(1..(length(GLIST)-2));
    out=append(out,name3+text(ii));
  );
  tmp1=[];
  forall(1..length(out),
    tmp=parse(out_#);
    if(#==1,tmp1=tmp,tmp1=concat(tmp1,tmp_(2..length(tmp))));
  );
  if(Noflg<3,
    println("generate Beziercurve "+name3);
    tmp=name3+"="+tmp1;
    parse(tmp);
    tmp1=Projpara(name3,["nodata"]);
    tmp=name2+"="+textformat(tmp1,5);
    parse(tmp);	
    ptlist=apply(ptlistorg,#+"3d");
    ptlist=RSform(text(ptlist),1);
    ctrlist=[];
    forall(1..(length(ctrlistorg)/2),
      tmp=[ctrlistorg_(2*#-1),ctrlistorg_(2*#)];
      tmp=apply(tmp,#+"3d");
      ctrlist=append(ctrlist,tmp);
    );
    ctrlist=RSform(text(ctrlist),0);
    tmp=name3+"=Bezier("+ptlist+","+ctrlist+","+Dq+"Num="+text(Num)+Dq+")";
    GLIST=append(GLIST,tmp);
    tmp=name2+"=Projpara("+name3+")";
    GLIST=append(GLIST,tmp);
  );
  if(Noflg<2,
    if(isstring(Ltype),
      if(!contains([[0,0,0],[0,0,0,1]],color),Com2nd("Setcolor("+color+")"));
      Ltype=GetLinestyle(text(Noflg)+Ltype,name2);
      if(!contains([[0,0,0],[0,0,0,1]],color),Com2nd("Setcolor("+text(KCOLOR)+")"));
    ,
      if(Noflg==1,Ltype=0);
    );
    GCLIST=append(GCLIST,[name2,Ltype,opcindy]);
    if(SUBSCR==1, //  15.02.11
      Subgraph(name3,opcindy);
    );
  );
  out;
);
////%Bezier3d end////

////%Putbezier3data start////
Putbezier3data(name,pt3Lorg):=Putbezier3data(name,pt3Lorg,[]);
Putbezier3data(name,pt3Lorg,options):=( // 17.10.08 greatly changed
  regional(pt3L,psize,Deg,nn,numstr,
     tmp,tmp1,tmp2,tmp3,pts,ctrpts);
  tmp=Divoptions(options);
  Deg=3;
  tmp1=tmp_5;
  forall(tmp1,
    if(substring(#,0,1)=="D",
      tmp=indexof(#,"=");
      Deg=parse(substring(#,tmp,length(#)));
    );
  );
  pt3L=pt3Lorg;
  if(isstring(pt3L_1),pt3L=apply(pt3L,parse(#+"3d")));
  ctrpts=[];
  forall(2..length(pt3L),nn,  // 16.08.19from
    numstr=text(nn-1);  // 16.08.19
    if(Deg==3,
      tmp1=name+numstr+"p";
      tmp2=(2*pt3L_(nn-1)+pt3L_(nn))/3;
	  VLIST=select(VLIST,#_1!=tmp1+"3d"); // 16.08.19from
      Putpoint3d([tmp1,tmp2]);
      ctrpts=append(ctrpts,tmp1);
      tmp1=name+numstr+"q";
      tmp3=(pt3L_(nn-1)+2*pt3L_nn)/3;
	  VLIST=select(VLIST,#_1!=tmp1+"3d");
      Putpoint3d([tmp1,tmp3]);
      ctrpts=append(ctrpts,tmp1);
    ,
      tmp1=name+numstr+"p";
      tmp2=(pt3L_(nn-1)+pt3L_nn)/2;
	  VLIST=select(VLIST,#_1!=tmp1+"3d"); // 16.08.19until
      Putpoint3d([tmp1,tmp2]); 
      ctrpts=append(ctrpts,tmp1);
    );
  );
  ctrpts;
);
////%Putbezier3data end////

////%Mkbezierptcrv3d start////
Mkbezierptcrv3d(ptdata):=Mkbezierptcrv3(ptdata);
Mkbezierptcrv3d(ptdata,options):=Mkbezierptcrv3(ptdata,options);
//help:Mkbezierptcrv3d(["A","B","C","D"]);
Mkbezierptcrv3(ptdata):=Mkbezierptcrv3(ptdata,[]);
Mkbezierptcrv3(ptdata,options):=(  //17.10.08 greatly changed
  regional(Eps,name,bz,pt,p1,p2,p13d,p23d,pt3,
    Out,tt,pos,tmp,tmp1,tmp2);
  Eps=10^(-4);
  pos=[NE.x+1,NE.y];
  Out=[];
  tmp=floor((BezierNumber3-1)/26);// 15.02.23 from
  if(tmp==0,tmp="",tmp=text(tmp));
  tmp2=mod(BezierNumber3,26);
  if(tmp2==0,tmp2=26);
  name=unicode(text(96+tmp2),base->10)+tmp;
  tmp2=Putbezier3data(name,ptdata,options);
  Bezier3(name,ptdata,tmp2,options);
  Out=append(Out,tmp2);
  BezierNumber3=BezierNumber3+1;
  Out;
);
////%Mkbezierptcrv3d end////

//////////old version ///////////////////////////////

Readobj(filename):=Readobj(filename,[]);
Readobj(filename,options):=(
//help:Readobj("file.obj",["size=-3"]);
  regional(eqL,size,vL,fnL,tmp,tmp1,tmp2);
  size=1;
  tmp=Divoptions(options);
  eqL=tmp_5;
  forall(eqL,
    if(Toupper(substring(#,0,1))=="S",
      tmp=indexof(#,"=");
      size=parse(substring(#,tmp,length(#)));
    );
  );
  tmp=load(filename);
  tmp=tokenize(tmp,"v");
  tmp1=tmp_(2..(length(tmp)-1));
  tmp2=tmp_(length(tmp));
  tmp2=tokenize(tmp2,"f");
  tmp1=append(tmp1,tmp2_1);
  tmp1=apply(tmp1,Removespace(#));
  tmp1=apply(tmp1,replace(#,"  "," "));
  tmp1=apply(tmp1,"["+replace(#," ",",")+"]");
  vL=apply(tmp1,size*parse(#));
  tmp2=tmp2_(2..(length(tmp2)));
  tmp2=apply(tmp2,Removespace(#));
  tmp2=apply(tmp2,replace(#,"  "," "));
  tmp2=apply(tmp2,"["+replace(#," ",",")+"]");
  fnL=apply(tmp2,parse(#));
  [vL,fnL];
);

//////////new version ///////////////////////////////
////%Readobj start////
Readobj(filename,options):=(
//help:Readobj("file.obj",["size=-3"]);
  regional(eqL,size,vL,fnL,dtL,numer,flg,flg2,
     tmp,tmp1,tmp2,tmp3,tmp4,tmp5);
  size=1;
  tmp=Divoptions(options);
  eqL=tmp_5;
  forall(eqL,
    if(Toupper(substring(#,0,1))=="S",
      tmp=indexof(#,"=");
      size=parse(substring(#,tmp,length(#)));
    );
  );
  numer="-0123456789";
  tmp=load(filename);
  dtL=tokenize(tmp,"v ");
  vL=[];
  fnL=[];
  flg=0;
  flg2=0;
  forall(dtL,dt,
    tmp1=Removespace(dt);
    if(indexof(numer,substring(tmp1,0,1))>0,
      tmp2="";
      tmp=indexof(tmp1,"f");
      if(tmp>0,
        tmp2=substring(tmp1,tmp-1,length(tmp1));
        tmp1=substring(tmp1,0,tmp-1);
        if(substring(tmp1,length(tmp1)-1,length(tmp1))=="#",
          tmp2="#"+tmp2;
          tmp1=substring(tmp1,0,length(tmp1)-1);
        );
//        tmp=indexof(tmp2,"#");
//        if(tmp>0,
//          tmp2=substring(tmp2,0,tmp-1);
//        );
      );
      if(flg==1,
        tmp1="";
        flg=0;
      );
      if(length(tmp1)>0,
        tmp=indexof(tmp1,"#");
        if(tmp>0,
          tmp1=substring(tmp1,0,tmp-1);
          flg=1;
        );
        tmp=indexof(tmp1,"vt");
        if(tmp>0,
          tmp1=substring(tmp1,0,tmp-1);
        );
        tmp1=replace(tmp1,"  ",",");
        tmp1=replace(tmp1," ",",");
        tmp1="["+tmp1+"]";
        tmp1=size*parse(tmp1);
        vL=append(vL,tmp1);
      );
      if(length(tmp2)>0,
        tmp2=tokenize(tmp2,"f");
        if(length(tmp2_1)==0,
          tmp2=tmp2_(2..length(tmp2));
 //       ,
 //         if(tmp2_1=="#",
//            tmp2=tmp2_(2..length(tmp2));
//            tmp2_1="#"+tmp2_1;
//          );
        );
        forall(1..length(tmp2),tmp3,
          tmp=tmp2_tmp3;
          if(substring(tmp,length(tmp)-1,length(tmp))=="#",
            tmp2_(tmp3+1)="#"+Removespace(tmp2_(tmp3+1));
            tmp2_tmp3=substring(tmp,0,length(tmp)-1);
          );
          tmp5="";
          if(length(tmp2_tmp3)>0,
            tmp4=tokenize(tmp2_tmp3," ");
            forall(tmp4,
              if(length(text(#))>0,
                if(indexof(text(#),"/")==0,
                  tmp=text(#);
                ,
                  tmp=tokenize(text(#),"/");
                  tmp=tmp_1;
                );
                if(length(tmp)>0,
                  tmp5=tmp5+tmp+",";
                );
              );
            );
            tmp5=substring(tmp5,0,length(tmp5)-1);
            if(length(tmp5)>0,
              if(substring(tmp5,0,1)!="#",
                tmp5="["+tmp5+"]";
                fnL=append(fnL,parse(tmp5));
              );
            );
          );
        );
      );
    );
  );
  [vL,fnL];
);
////%Readobj end////

////%Concatobj start////
Concatobj(objL):=Concatobj(objL,[]);
Concatobj(objL,options):=(
//help:Concatobj([polyhed,triangle]);
//help:Concatobj([polyhed,triangle],["Rmf=no"]);
//help:Concatobj([[A,B,C],[A,C,D]]);
  regional(obj,vL,fL,vadd,vtx,faces,fnew,face,jj,kk,vctr,eps,
    tmp,tmp1,tmp2,tmp3,eqL,rmf);
  tmp=divoptions(options);
  eqL=tmp_5;
  rmf="y"; // 16.08.19
  forall(eqL,
    tmp=indexof(#,"=");
    tmp1=Toupper(substring(#,0,1));
    tmp2=Toupper(substring(#,tmp,tmp+1));
    if(tmp1=="R",
      if(tmp2=="Y",rmf="y"); // 16.08.14
    );
  );
  eps=10^(-4);
  vL=[];
  fL=[];
  vctr=0;
  forall(objL,obj,
    if(isstring(obj),
      tmp1=parse(obj);
    ,
      tmp1=obj;
    );
    if(length(tmp1)>2,  // 16.02.28
      tmp=1..length(tmp1);
      tmp1=[tmp1,[tmp]];
    );
    vtx=tmp1_1;  // 16.02.11 from
    faces=tmp1_2;
    fnew=faces;
    vctr=0;
    vadd=[];
    forall(1..length(vtx),jj,
      tmp1=vtx_jj;
      tmp=select(1..length(vL),dist3d(vL_#,tmp1)<eps);
      if(length(tmp)==0,
        vadd=append(vadd,tmp1);
        vctr=vctr+1;
        tmp2=length(vL)+vctr;
      ,
        tmp2=tmp_1;
      );
      forall(1..length(faces),kk,
        face=faces_kk;
        tmp=select(1..length(face),face_#==jj);
        if(length(tmp)>0,
          tmp1=tmp_1;
          fnew_kk_tmp1=tmp2;
        );
      );
    );
    vL=concat(vL,vadd);
    fL=concat(fL,fnew);   // 16.02.11 until
  );
  tmp2=apply(1..length(fL),1);
  if(rmf=="y",
    forall(1..length(fL),jj,
      tmp=fL_jj;
      tmp1=select((jj+1)..length(fL),fL_#==tmp);
      forall(tmp1,tmp2_#=0);
    );
    tmp=select(1..length(tmp2),tmp2_#==1);
    fL=fL_tmp;
  );
  [vL,fL];
);
////%Concatobj end////

if(1==0,

Mkobjfile(fname,objL):=Mkobjfile(Dirwork,fname,objL);
Mkobjfile(path,fnameorg,objL):=(
//help:Mkobj(filename,objlist);
  regional(fname,obj,vtx,face,tmp,tmp1,tmp2);
  fname=fnameorg;
  if(indexof(fname,".")==0,fname=fname+".obj");
  vtx=objL_1;
  face=objL_2;
  setdirectory(path);
  SCEOUTPUT = openfile(fname);
  forall(vtx,tmp1,
    tmp2=tmp1;
    if(ispoint(tmp1),
      tmp2=parse(text(tmp1)+"3d");
    );
    tmp="v "+format(tmp2_1,5)+" "+format(tmp2_2,5)+" "+format(tmp2_3,5);
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

); //end of skip

////%VertexEdgeFace start////
VertexEdgeFace(nm,vfnL):=VertexEdgeFace(nm,vfnL,[]);  // 16.02.10
VertexEdgeFace(nm,vfnLorg,optionorg):=(
//help:VertexEdgeFace("1",[vL,fnL]);
//help:VertexEdgeFace("1",["A","B","C"]);
//help:VertexEdgeFace(options=["Pt=fix","Vtx=n(y)","Edg=n(y)"]);
  regional(name3,namev,namee,namef,vfnL,options,Noflg,eqL,strL,
      vL,eL,enL,face,edge,vtx,vname,fixflg,vtxflg, edgflg,dispflg,tmp,tmp1,tmp2);
  name3="phvef"+nm;
  namev="phv3d"+nm;
  namee="phe3d"+nm;
  namef="phf3d"+nm;
  options=optionorg;
  vfnL=vfnLorg;  // 16.06.19from
  if(length(vfnL)>2,
    vfnL=[vfnL,[1..length(vfnL)]];
  );
  if(length(vfnL)==1,
    vfnL=[vfnL_1,[1..length(vfnL_1)]];
  );  // 16.06.19until
  tmp=Divoptions(options);
  Noflg=tmp_2;
  eqL=tmp_5;
  strL=tmp_7;
  fixflg=1;
  vtxflg=0; //180905
  edgflg=0;
  dispflg=1; //181106
  forall(eqL,
    tmp=Strsplit(#,"=");
    tmp1=Toupper(substring(tmp_1,0,1));
    tmp2=Toupper(substring(tmp_2,0,1));
    if(tmp1=="P",
      if(tmp2=="F", fixflg=0);
      options=remove(options,[#]);
    );
    if(tmp1=="V", //180905from
      if((tmp2=="Y")%(tmp2==G), //181107
        vtxflg=1;
      );
      options=remove(options,[#]);
    ); //180905to
    if(tmp1=="E",
      if((tmp2=="Y")%(tmp2=="G"),//181107[2lines]
        if(vtxflg==1,edgflg=1);
      );
      options=remove(options,[#]);
    );
    if(tmp1=="D", //181106from
      if(substring(tmp2,0,1)=="N",
        dispflg=0; vtxflg=0; edgflg=0;
      );
      options=remove(options,[#]);
    ); //181106to
  );
  forall(strL,
    if(Toupper(#)=="FREE",
      fixflg=0;
      options=remove(options,[#]);
    );
  );
  vL=[];
  forall(1..length(vfnL_1),
    vtx=vfnL_1_#;  // 16.02.10 from
    if(isstring(vtx),vtx=parse(vtx)); // 16.06.19
    if(ispoint(vtx),
      tmp=parse(text(vtx)+"3d");
      vname=text(vtx);
    ,
      vname="V"+nm+text(#); //181212
      if(vtxflg==1, //180905
        if(fixflg==1,
          Putpoint3d([vname,vtx],"fix");
        ,
          Putpoint3d([vname,vtx]);
        );
      , //180905from
        tmp=vname+"3d="+format(vtx,6);
        parse(tmp);
        Defvar(vname+"3d",parse(vname+"3d"));
        tmp=vname+"2d=Parapt("+vname+"3d)";
        parse(tmp);
        Defvar(vname+"2d",parse(vname+"2d"));
        if(dispflg==1, //181106
          drawtext(parse(vname+"2d"),vname,size->8); //190128
          draw(parse(vname+"2d"),pointsize->3,color->[0,1,0]); //190128
        );
      ); //180905to
    );
    vL=append(vL,vname); // 16.02.10 until
  );
  eL=[];
  forall(vfnL_2,face,
    forall(1..length(face),
      tmp1=face_#;
      if(#<length(face),
        tmp2=face_(#+1);
      ,
        tmp2=face_1;
      );
      if(tmp2<tmp1,
        tmp=tmp2; tmp2=tmp1; tmp1=tmp;
      );
      tmp1=vL_tmp1+"3d";
      tmp2=vL_tmp2+"3d";
      tmp=select(eL,#==[tmp1,tmp2] % #==[tmp2,tmp1]);
      if(length(tmp)==0,
        eL=append(eL,[tmp1,tmp2]);
      );
    );
  );
  if(Noflg<3,
    enL=[];
    forall(eL,edge,
      if(edgflg==0,
        if(Noflg<2,
          tmp1=edge_1;//parse(edge_1);
          tmp2=edge_2;//parse(edge_2);
          tmp="sl3d"+edge_1+edge_2;
          if(islist(parse(tmp)),
            Changestyle3d([tmp],["nodisp"]);
          );
          tmp="sl3d"+edge_2+edge_1;
          if(islist(parse(tmp)),
            Changestyle3d([tmp],["nodisp"]);
          );
          tmp=replace(edge_1+edge_2,"3d","");
          options=append(options,"Msg=no");
          Spaceline("-"+tmp,[tmp1,tmp2],options); //16.02.28
        );
        enL=append(enL,tmp+"3d"); //16.02.29
      ,
        tmp1=replace(edge_1,"3d","");
        tmp2=replace(edge_2,"3d","");
        tmp=tmp1+tmp2;
        tmp=replace(tmp,"V","v");
        create([tmp],"Segment",[parse(tmp1),parse(tmp2)]);
        enL=append(enL,tmp+"3d");//16.02.29
      );
    );
    if(Noflg<2,
      println("generate "+name3);
      println("   generate totally "+namee);
      println("   generate vertexes "+namev);
      println("   generate faces  "+namef);
    );
    tmp1="";
    forall(enL,
      tmp1=tmp1+Dq+#+Dq+",";
    );
    tmp1=substring(tmp1,0,length(tmp1)-1);
    tmp=namee+"=["+tmp1+"]";
    parse(tmp);
    tmp=namee+"=list("+tmp1+")";
    tmp=replace(tmp,Dq,"");
    GLIST=append(GLIST,tmp);
    tmp1=apply(vL,Dq+#+"3d"+Dq);
    tmp1=text(tmp1);
    tmp1=substring(tmp1,1,length(tmp1)-1);
    tmp=namev+"=["+tmp1+"]";
    parse(tmp);
    tmp1=replace(tmp1,Dq,"");
    tmp=namev+"=list("+tmp1+")";
    GLIST=append(GLIST,tmp);
    tmp1=text(vfnL_2);
    tmp1=substring(tmp1,1,length(tmp1)-1);
    tmp=namef+"=["+tmp1+"]";
    parse(tmp);
    tmp=namef+"=list("+tmp1+")";
    GLIST=append(GLIST,tmp);
  );
  [namev,namee,namef];
);
////%VertexEdgeFace end////

////%Phparadata start////
Phparadata(nm,nmvf):=(
  regional(tmp1,tmp2);
  tmp1=parse("phv3d"+nmvf);
  tmp2=parse("phf3d"+nmvf);
  Phparadata(nm,nmvf,[tmp1,tmp2]);
);
Phparadata(nm,nmvf,Arg1):=(
  regional(vfL,options,tmp1,tmp2);
  if(islist(Arg1) & !islist(Arg1_1),
    tmp1=parse("phv3d"+nmvf);
    tmp2=parse("phf3d"+nmvf);
    vfL=[tmp1,tmp2];
    options=Arg1;
  ,
    vfL=Arg1;
    options=[];
  );
  Phparadata(nm,nmvf,vfL,options);
);
Phparadata(nm,nmvf,vfL,options):=(
//help:Phparadata("1","1",["do"]);
  regional(name2,name3,nameh2,nameh3,Ltype,Noflg,eqL,Hidden,
      opstr,opcindy,Outflg,Inflg,pdata1,tmp,tmp1,tmp2,color);
  name2="php2d"+nm;
  name3="php3d"+nm;
  nameh2="phh2d"+nm;
  nameh3="phh3d"+nm;
  tmp=Divoptions(options);
  Ltype=tmp_1;
  Noflg=tmp_2;
  Inflg=tmp_3;
  Outflg=tmp_4;
  if(Inflg==0 & Outflg==0, Inflg=1;Outflg=1); // 15.05.15
  eqL=tmp_5;
  color=tmp_(length(tmp)-2);
  opstr=tmp_(length(tmp)-1);
  opcindy=tmp_(length(tmp));
  Hidden="";
  forall(eqL,
    tmp=indexof(#,"=");
    tmp1=Toupper(substring(#,0,1));
    tmp2=substring(#,tmp,length(#));
    if(tmp1=="H",
      Hidden=tmp2;
    );
  );
  if(Noflg<3,
    if(Outflg>=1,
      println("Output Phparadata "+name3);
      if(isstring(vfL_1),  // 2015.05.27 from
        tmp1=vfL_1;
      ,
        tmp1="list(";
        forall(vfL_1,
          tmp1=tmp1+#+",";
        );
        tmp1=substring(tmp1,0,length(tmp1)-1)+")";
      );
      if(isstring(vfL_2),
        tmp2=vfL_2;
      ,
        tmp2="list(";
        forall(vfL_2,
          tmp2=tmp2+text(#)+",";
        );
        tmp2=substring(tmp2,0,length(tmp2)-1)+")";
      );   // 2015.05.27 until
      tmp=name3+"=Phparadata("+tmp1+","+tmp2+opstr+")";
      GLIST=append(GLIST,tmp);
      tmp=name2+"=Projpara("+name3+")";
      GLIST=append(GLIST,tmp);
      tmp=nameh3+"=PhHiddenData()";
      GLIST=append(GLIST,tmp);
      tmp=nameh2+"=Projpara("+nameh3+")";
      GLIST=append(GLIST,tmp);
    );
  );
  if(Noflg<2,
    if(isstring(Ltype),
      if(!contains([[0,0,0],[0,0,0,1]],color),Com2nd("Setcolor("+color+")"));
      Ltype=GetLinestyle(text(Noflg)+Ltype,name2);
      if(!contains([[0,0,0],[0,0,0,1]],color),Com2nd("Setcolor("+text(KCOLOR)+")"));
    ,
      if(Noflg==1,Ltype=0);
    );
    if(Inflg==1,
//      tmp=apply(pltdata1,replace(#,"3d","2d"));  // 15.05.18 from
      Changestyle3d("phe3d"+nmvf,["nodisp"]);
      GCLIST=append(GCLIST,[name2,Ltype,opcindy]);
    );
  );
  if(Hidden!="",
    Drawlinetype(nameh2,Hidden);
    if(Inflg==1,
      tmp1=Toupper(substring(Hidden,0,2));
      if(tmp1=="DR",Ltype=0);
      if(tmp1=="DA",Ltype=1);
      if(tmp1=="DO",Ltype=3);
      if(tmp1=="ID",Ltype=1);
      GCLIST=append(GCLIST,[nameh2,Ltype,opcindy]);
   );
  );
);
////%Phparadata end////

////%Nohiddenseg start////
Nohiddenseg(seg,rng,triang,Eps):=(
// help:Nohiddenseg("1",seg1,[0,1],["v1","v2","v3"]);
  regional(pA3,pB3,pC3,pA,pB,pC,sg1,sg2,ss1,ss2,parL,flgL,flg1,flg2,
     veB,veC,sgnoh,sghid,added,tmp,tmp1,tmp2,tmp3,tmp4,tmp5);
//  Eps=10^(-2);//180815
  sgnoh=[0,1];
  pA3=triang_1; //180815from
  if(isstring(pA3),
    if(indexof(pA3,"3d")==0,pA3=pA3+"3d");
    pA3=parse(pA3);
  );
  pB3=triang_2;
  if(isstring(pB3),
    if(indexof(pB3,"3d")==0,pB3=pB3+"3d");
    pB3=parse(pB3);
  );
  pC3=triang_3;
  if(isstring(pC3),
    if(indexof(pC3,"3d")==0,pC3=pC3+"3d");
    pC3=parse(pC3);
  ); //180815to
  pA=Parapt(pA3);
  pB=Parapt(pB3);
  pC=Parapt(pC3);
  sg1=seg_1+rng_1*(seg_2-seg_1);
  sg2=seg_1+rng_2*(seg_2-seg_1);
  ss1=Parapt(sg1);
  ss2=Parapt(sg2);
  if(|ss2-ss1|>Eps & abs(Crossprod(pB-pA,pC-pA))>Eps,
    tmp=IntersectcrvsPp([ss1,ss2],[pA,pB,pC,pA]);
    parL=apply(tmp,#_2-1);
    parL=sort(parL);
    if(length(parL)==0,
      parL=[0,1];
    ,
      if(parL_1>Eps,parL=prepend(0,parL));
      if(parL_(length(parL))<1-Eps,parL=append(parL,1));
    );
    tmp1=Crossprod(pB3-pA3,pC3-pA3);
    if(abs(Dotprod(tmp1,sg2-sg1))>Eps,
      tmp=IntersectsgpL("",[sg1,sg2],[pA3,pB3,pC3],["Screen=n"]);//181031from
      if(tmp_2&tmp_3,
        tmp1=select(parL,abs(tmp_4-#)<Eps);
        if(length(tmp1)==0,
          parL=sort(append(parL,tmp_4));
        );
      );//181031to
    );
    flgL=[];
    forall(parL,
      tmp1=sg1+#*(sg2-sg1);
      tmp=Projcoordpara(tmp1);
      tmp_3=tmp_3+1;
      tmp2=Cancoordpara(tmp);
      tmp=IntersectsgpL("",[tmp1,tmp2],[pA3,pB3,pC3],["Screen=n"]);//181031
      tmp1=Projcoordpara(tmp1);
      tmp2=Projcoordpara(tmp_1);
      flg1=0;
      if(tmp1_3<tmp2_3-Eps,flg1=-1);
      if(tmp1_3>tmp2_3+Eps,flg1=1);
      flgL=append(flgL,flg1);
    );
    sgnoh=[];
    forall(2..length(flgL),
      added=[];
      flg1=flgL_(#-1);
      flg2=flgL_#;
      if(max([flg1,flg2])==1 % flg1+flg2==0,
        added=[parL_(#-1),parL_#];
      ,
		sghid=[parL_(#-1),parL_#];
        tmp1=ss1+sghid_1*(ss2-ss1);
        tmp2=ss1+sghid_2*(ss2-ss1);
        tmp=IntersectcrvsPp([tmp1,tmp2],[pA,pB,pC,pA]);
        if(length(tmp)<2,
          veB=pB-pA;
          veC=pC-pA;
          tmp3=tmp1-pA;
          tmp4=tmp2-pA;
          tmp5=Crossprod(veB,veC);
          tmp1=(tmp3_1*veC_2-tmp3_2*veC_1)/tmp5;
          tmp2=(-tmp3_1*veB_2+tmp3_2*veB_1)/tmp5;
          if(tmp1>-Eps & tmp2>-Eps & tmp1+tmp2<1+Eps,flg1=1,flg1=0);
          tmp1=(tmp4_1*veC_2-tmp4_2*veC_1)/tmp5;
          tmp2=(-tmp4_1*veB_2+tmp4_2*veB_1)/tmp5;
          if(tmp1>-Eps & tmp2>-Eps & tmp1+tmp2<1+Eps,flg2=1,flg2=0);
          if(flg1==1 & flg2==0,
            if(length(tmp)>0,
              tmp1=tmp_1_2-1;
              tmp1=sghid_1+(sghid_2-sghid_1)*tmp1;
            ,
              tmp1=sghid_1;
            );
            added=[tmp1,sghid_2];
//        added=[tmp1+Eps,sghid_2];  // <--- USUI  2016.02.27
          );
          if(flg1==0 & flg2==1,
            if(length(tmp)>0,
              tmp1=tmp_1_2-1;
              tmp1=sghid_1+(sghid_2-sghid_1)*tmp1;
            ,
              tmp1=sghid_2;
            );
            added=[sghid_1,tmp1];
          );
          if(flg1+flg2==0,
            added=sghid;
          );
        );
        if(length(tmp)==2,
          if(min([flg1,flg2])>=0,added=sghid,added=[]);
        );
      );
      if(length(added)>0,
        if(length(sgnoh)==0,
          sgnoh=added;
        ,
          if(sgnoh_(length(sgnoh))<added_1-Eps,
             sgnoh=concat(sgnoh,added);
          ,
             sgnoh=sgnoh_(1..(length(sgnoh)-1));
             sgnoh=concat(sgnoh,added_(2..length(added)));
          );
        );
      );
    );
  );
  sgnoh=apply(sgnoh,rng_1+#*(rng_2-rng_1));
  sgnoh;
);
////%Nohiddenseg end////

////%Nohiddensegs start////
Nohiddensegs(seg,range,faceno,vtxL,Eps):=(
  regional(rng,face,vtx,out,ra,rb,tmp,tmp1,tmp2);
//  Eps=10^(-2);
  face=apply(faceno,vtxL_#); // 16.02.10
  rng=range;
  out=rng;
  forall(2..(length(face)-1),vtx,
    tmp1=[face_1,face_vtx,face_(vtx+1)];
    forall(1..(length(rng)/2),
      tmp=[rng_(2*#-1),rng_(2*#)];
      out=remove(out,tmp);
      tmp2=Nohiddenseg(seg,tmp,tmp1,Eps);
      if(length(tmp2)>0,
        out=remove(out,tmp);
        out=concat(out,tmp2);
      );
    );
    tmp=sort(out);
    out=[];
    forall(1..(length(tmp)/2),
      ra=tmp_(2*#-1);
      rb=tmp_(2*#);
      if(ra<rb-Eps,
        if(length(out)==0,
          out=[ra,rb];
        ,
          if(out_(length(out))<ra-Eps,
            out=concat(out,[ra,rb]);
          ,
            out_(length(out))=rb;
          );
        );
      );
    );
    rng=out;
  );
  rng;
);
////%Nohiddensegs end////

////%Nohiddenbyfaces start////
Nohiddenbyfaces(nm,facestr):=
    Nohiddenbyfaces(nm,Datalist3d(),facestr,[],["do"]);
Nohiddenbyfaces(nm,Arg1,Arg2):=(
  regional(segstr,facestr,options);
  if(islist(Arg2),
    segstr=Datalist3d();
    facestr=Arg1;
    options=Arg2;
  ,
    segstr=Arg1;
    facestr=Arg2;
    options=[];
  );
  Nohiddenbyfaces(nm,segstr,facestr,options,["do"]);
);
Nohiddenbyfaces(nm,Arg1,Arg2,Arg3):=(
  regional(segstr,facestr,options,optionsh);
  if(islist(Arg2),
    segstr=Datalist3d();
    facestr=Arg1;
    options=Arg2;
    optionsh=Arg3;
 ,
    segstr=Arg1;
    facestr=Arg2;
    options=Arg3;
    optionsh=["do"];
  );
  Nohiddenbyfaces(nm,segstr,facestr,options,optionsh); // 16.02.21
);
Nohiddenbyfaces(nm,segstr,Arg1,Arg2,Arg3):=( //180815from
  regional(facestr,faceL,vtxL,options,optionsh);
  if(isstring(Arg1),
    facestr=Arg1;
    options=Arg2;
    optionsh=Arg3;
    if(substring(facestr,0,3)=="phf",
      faceL=parse(facestr);
      tmp=replace(facestr,"phf","phv"); 
      tmp=parse(tmp);
      vtxL=apply(tmp,replace(#,"3d",""));
      
    ,
      faceL=parse(facestr);
    );
  ,
    faceL=Arg1;
    vtxL=Arg2;
    options=Arg3;
    optionsh=[];
  );
  Nohiddenbyfaces(nm,segstr,faceL,vtxL,options,optionsh);
);
Nohiddenbyfaces(nm,segstr,faceL,vtxL,optionorg,optionsh):=(
//help:Nohiddenbyfaces("1","phf3d1");
//help:Nohiddenbyfaces("1","ax3d","phf3d1");
//help:Nohiddenbyfaces("1","ax3d",phf3d1,phv3d1);
//help:Nohiddenbyfaces(options1=["dr","Eps=10^(-2)"]);
//help:Nohiddenbyfaces(options2=["do"]);
  regional(Eps,namen,nameh,options,segL,rng,seg,face,
     ctr,tmp,tmp1,tmp2,Ltype,Noflg,eqL,color,opstr,opcindy,frnL,frhL);
  Eps=10^(-2);
  namen="frn"+nm;
  nameh="frh"+nm;
  if(isstring(segstr),
    tmp=parse(segstr);//180714from
    if(islist(tmp),
      if(isstring(tmp_1),
        segL=tmp;
      ,
        segL=[segstr];
      );
    );//180714to
  ,
    segL=segstr;
  );
  tmp2=[];  // 16.02.29 from
  forall(segL,seg,
    tmp=replace(seg,"3d","2d");
    tmp1=select(GCLIST,#_1==tmp);
    tmp1=tmp1_1;
    if(tmp1_2_1==0, //190127
      tmp2=append(tmp2,seg);
    );
  );
  segL=tmp2;
  Changestyle3d(segL,["nodisp"]); // 16.02.29 until
  if(islist(segL),
    if(isstring(segL_1),
      segL=apply(segL,parse(#));
    );
  );
  tmp1=Flattenlist(segL); //180816from
  segL=[];
  forall(tmp1,tmp2,
    forall(1..(length(tmp2)-1),
      segL=append(segL,[tmp2_#,tmp2_(#+1)]);
    );
  ); //180816from
  options=optionorg;
  tmp=Divoptions(options);
  Ltype=tmp_1;
  Noflg=tmp_2;
  eqL=tmp_5;
  color=tmp_(length(tmp)-2);
  opstr=tmp_(length(tmp)-1);
  opcindy=tmp_(length(tmp));
  forall(eqL, //180815from
    tmp=Strsplit(#,"=");
    tmp1=Toupper(substring(tmp_1,0,1)); //181111
    if(substring(tmp1,0,3)=="E",
      Eps=parse(tmp_2);
      options=remove(options,[#]);
    );
  );//180815to
  ctr=1;
  frnL=[];
  frhL=[];
  forall(segL,seg,
    rng=[0,1];
    forall(faceL,face,
	  rng=Nohiddensegs(seg,rng,face,vtxL,Eps);
    );
    forall(1..length(rng)/2,
      tmp=rng_(2*#-1);
      tmp1=seg_1+tmp*(seg_2-seg_1);
      tmp=rng_(2*#);
      tmp2=seg_1+tmp*(seg_2-seg_1);
      tmp=append(options,"Msg=nodisp");  // 15.06.22
      Spaceline("-"+namen+"n"+text(ctr),[tmp1,tmp2],tmp);
      frnL=append(frnL,namen+"n"+text(ctr)+"3d");
      ctr=ctr+1;
    );
    if(length(rng)==0,
      rng=[0,1];
    ,
      if(rng_1>0+Eps,
        rng=prepend(0,rng);
      ,
        rng=rng_(2..length(rng));
      );
      if(rng_(length(rng))<1-Eps,
        rng=append(rng,1);
      ,
        rng=rng_(1..(length(rng)-1));
      );
    );
    forall(1..length(rng)/2,
      tmp=rng_(2*#-1);
      tmp1=seg_1+tmp*(seg_2-seg_1);
      tmp=rng_(2*#);
      tmp2=seg_1+tmp*(seg_2-seg_1);
      tmp=select(optionsh,indexof(#,"=")>0); //180815from
	  tmp=remove(optionsh,tmp);
      if(length(tmp)==0,tmp=append(optionsh,"do")); //180815to
      tmp=append(tmp,"Msg=nodisp");  // 15.06.22
      Spaceline("-"+nameh+"n"+text(ctr),[tmp1,tmp2],tmp);
      frhL=append(frhL,nameh+"n"+text(ctr)+"3d");
      ctr=ctr+1;
    );
  );
  tmp1=apply(frnL,Dq+#+Dq);
  tmp="frn3d"+nm+"="+text(tmp1);
  parse(tmp);
  println("   generate totally "+"frn3d"+nm);
  tmp1=apply(frhL,Dq+#+Dq);
  tmp="frh3d"+nm+"="+text(tmp1);
  parse(tmp);
  println("   generate totally "+"frh3d"+nm);
  [frnL,frhL]; //181106
);
////%Nohiddenbyfaces end////

////%Faceremovaldata start////
Faceremovaldata(nm,vfdata,crvdata):=Faceremovaldata(nm,vfdata,crvdata,[]);
Faceremovaldata(nm,vfdata,crvdata,options):=(
  regional(name2,name3,nameh2,nameh3,Ltype,Noflg,eqL,Hidden,
      opstr,opcindy,Outflg,Inflg,tmp,tmp1,tmp2,color);
  name2="frc2d"+nm;
  name3="frc3d"+nm;
  nameh2="frch2d"+nm;
  nameh3="frch3d"+nm;
  tmp=Divoptions(options);
  Ltype=tmp_1;
  Noflg=tmp_2;
  Inflg=tmp_3;
  Outflg=tmp_4;
  if(Inflg==0 & Outflg==0, Inflg=1;Outflg=1); // 15.05.15
  eqL=tmp_5;
  color=tmp_(length(tmp)-2);
  opstr=tmp_(length(tmp)-1);
  opcindy=tmp_(length(tmp));
  Hidden="";
  forall(eqL,
    tmp=indexof(#,"=");
    tmp1=Toupper(substring(#,0,1));
    tmp2=substring(#,tmp,length(#));
    if(tmp1=="H",
      Hidden=tmp2;
    );
  );
  if(Noflg<3,
    if(Outflg>=1,
      println("Output Faceremovaldata "+name3);
      if(Measuredepth(vfdata)==1,
        tmp1=text(apply(vfdata,#_[1,3]));
     ,
        tmp1=text([vfdata_[1,3]]);
     );
      tmp1=replace(tmp1,"[","list(");
      tmp1=replace(tmp1,"]",")");
      tmp2=text(crvdata);
      tmp2=replace(tmp2,"[","list(");
      tmp2=replace(tmp2,"]",")");
//      tmp2="Flattenlist("+tmp2+")";
      tmp=name3+"=Faceremovaldata("+tmp1+","+tmp2+opstr+","+Dq+"para"+Dq+")";
      GLIST=append(GLIST,tmp);
      tmp=name2+"=Projpara("+name3+")";
      GLIST=append(GLIST,tmp);
      tmp=nameh3+"=PhHiddenData()";
      GLIST=append(GLIST,tmp);
      tmp=nameh2+"=Projpara("+nameh3+")";
      GLIST=append(GLIST,tmp);
    );
  );
  if(Noflg<2,
    if(isstring(Ltype),
      if(!contains([[0,0,0],[0,0,0,1]],color),Com2nd("Setcolor("+color+")"));
      Ltype=GetLinestyle(text(Noflg)+Ltype,name2);
      if(!contains([[0,0,0],[0,0,0,1]],color),Com2nd("Setcolor("+text(KCOLOR)+")"));
    ,
      if(Noflg==1,Ltype=0);
    );
    if(Inflg==1,
      if(Measuredepth(vfdata)==1,
        tmp1=apply(vfdata,parse(#_2));
      ,
        tmp1=[parse(vfdata_2)];
      );
      forall(tmp1,
         Changestyle3d(#,["nodisp"]);
       );
      Changestyle3d(crvdata,["nodisp"]);
      GCLIST=append(GCLIST,[name2,Ltype,opcindy]);
    );
  );
  if(Hidden!="",
    Drawlinetype(nameh2,Hidden);
    if(Inflg==1,
      tmp1=Toupper(substring(Hidden,0,2));
      if(tmp1=="DR",Ltype=0);
      if(tmp1=="DA",Ltype=1);
      if(tmp1=="DO",Ltype=3);
      if(tmp1=="ID",Ltype=1);
      GCLIST=append(GCLIST,[nameh2,Ltype,opcindy]);
    );
  );
);
////%Faceremovaldata end////

////%Fullformfunc start////
Fullformfunc(FdL):=(
  regional(Out,nn,ii,Jrg,flg,Urg,Vrg,kk,Uname,
     Zf,Xname,Xf,Yname,Yf,tmp,tmp1,tmp2);
  Out=[FdL_1];
  nn=length(FdL);
  flg=0;
  forall(1..nn,
    if(flg==0,
      tmp=FdL_#;
      if(substring(tmp,length(tmp)-1,length(tmp))=="]",
        Jrg=#;
        Urg=FdL_Jrg;
        flg=1;
      );
    );
  );
  kk=indexof(Urg,"=");
  Uname=Removespace(substring(Urg,0,kk-1));
  tmp=substring(Urg,kk,length(Urg));
  Urg=Uname+"="+tmp;
//  tmp1=parse(tmp);
//  Urg=Uname+"="+textformat(tmp1,5);
  Vrg=FdL_(Jrg+1);
  kk=indexof(Vrg,"=");
  Vname=Removespace(substring(Vrg,0,kk-1));
  tmp=substring(Vrg,kk,length(Vrg));
  Vrg=Vname+"="+tmp;
//  tmp1=parse(tmp);
//  Vrg=Vname+"="+textformat(tmp1,5);
  if(Jrg==2,
    tmp=FdL_1;
    kk=indexof(tmp,"=");
    Zf=substring(tmp,kk,length(tmp));
    tmp=[Uname,Vname,Zf,Urg,Vrg];
    Out=concat(Out,tmp);
  ,
    if(Jrg==4,
      tmp=FdL_1;
      kk=indexof(tmp,"=");
      Zf=substring(tmp,kk,length(tmp));
      tmp=FdL_2;
      kk=indexof(tmp,"=");
      Xname=Removespace(substring(tmp,0,kk-1));
      Xf=substring(tmp,kk,length(tmp));
      tmp=FdL_3;
      kk=indexof(tmp,"=");
      Yname=Removespace(substring(tmp,0,kk-1));
      Yf=substring(tmp,kk,length(tmp));
      tmp=replace(Zf,Xname,"("+Xf+")");
      Zf=replace(tmp,Yname,"("+Yf+")");
      Tmp=[Xf,Yf,Zf,Urg,Vrg];
      Out=concat(Out,Tmp);
    ,
      tmp=FdL_2;
      kk=indexof(tmp,"=");
      Xf=substring(tmp,kk,length(tmp));
      tmp=FdL_3;
      kk=indexof(tmp,"=");
      Yf=substring(tmp,kk,length(tmp));
      tmp=FdL_4;
      kk=indexof(tmp,"=");
      Zf=substring(tmp,kk,length(tmp));
      tmp=[Xf,Yf,Zf,Urg,Vrg];
      Out=concat(Out,tmp);
    );
  );
  DrwS="enws";
  BdyL=[];
  forall((Jrg+2)..length(FdL),ii,
    tmp=FdL_ii;
    if(isstring(tmp),
      if(length(tmp)==0,
        tmp=" ";
      );
      DrwS=tmp;
    );
    if(islist(tmp) & length(tmp_1)>1,
      BdyL=tmp;
    );
  );
  tmp=[DrwS,BdyL];
  Out=concat(Out,tmp);
);
////%Fullformfunc end////

////%Surffun start////
Surffun(nm,Fd):=(
  regional(name,coord,var1,var2,rng1,rng2,bdy,tmp,tmp1,tmp2);
  tmp=Fullformfunc(Fd);
  rng1=tmp_5;
  rng2=tmp_6;
  bdy=tmp_7;
  coord="["+tmp_2+","+tmp_3+","+tmp_4+"]";
  tmp=indexof(rng1,"=");
  var1=substring(rng1,0,tmp-1);
  rng1=substring(rng1,tmp,length(rng1));
  tmp=indexof(rng2,"=");
  var2=substring(rng2,0,tmp-1);
  rng2=substring(rng2,tmp,length(rng2));
  name="Sfn"+nm+"("+var1+","+var2+")";
  Deffun(name,["regional(tmp)","tmp="+coord,"tmp"]);
  [name,var1,rng1,var2,rng2,bdy];
);
////%Surffun end////

////%Sf3data start////
Sf3data(nm,fdata):=Sf3data(nm,fdata,[]);
Sf3data(nm,fdata,optionorg):=(
  regional(tmp,tmp1,tmp2);
  tmp=Surffun(nm,fdata);
  tmp1=tmp_2+"="+tmp_3;
  tmp2=tmp_4+"="+tmp_5;
  Sf3data(nm,tmp_1,tmp1,tmp2,optionorg);
);
Sf3data(nm,funstr,var1,var2):=Sf3data(nm,funstr,var1,var2,[]);
Sf3data(nm,funstr,var1org,var2org,optionorg):=(
//help:Sf3data("1",Fd);
//help:Sf3data(options=["Num=[25,25]","Wire=[20,20]"]);
  regional(name2,name3,var1,var2,Ltype,Noflg,opstr,opcindy,eqL,Num,
    Wire,varu,varv,rngu,rngv,sfdtuL,sfdtvL,options,
    tmp,tmp1,tmp2,tmp3);
  var1=replace(var1org,"%pi","pi");
  var2=replace(var2org,"%pi","pi");
  tmp=Divoptions(optionorg);
  Ltype=tmp_1;
  Noflg=tmp_2;
  eqL=tmp_5;
  opstr=tmp_(length(tmp)-1);
  opcindy=tmp_(length(tmp));
  options=optionorg;
  Num=[25,25];
  Wire=[20,20];
  forall(eqL,
    tmp=indexof(#,"=");
    tmp1=substring(#,0,tmp-1);
    tmp2=substring(#,tmp,length(#)); // 16.05.25
    tmp=Toupper(substring(tmp1,0,1));
    if(tmp=="N",
      tmp2=parse(tmp2);
      if(!islist(tmp2),tmp2=[tmp2,tmp2]);
      Num=tmp2;
      options=remove(options,[#]);
    );
    if(tmp=="W",
      tmp2=parse(tmp2);
      if(!islist(tmp2),tmp2=[tmp2,tmp2]);
      Wire=tmp2;
      options=remove(options,[#]);
    );
  );
  tmp=indexof(var1,"=");
  varu=substring(var1,0,tmp-1);
  rngu=parse(substring(var1,tmp,length(var1)));
  tmp=indexof(var2,"=");
  varv=substring(var2,0,tmp-1);
  rngv=parse(substring(var2,tmp,length(var2)));
  sfdtuL=[];
  forall(0..Wire_2,
    tmp=rngv_1+#/Wire_2*(rngv_2-rngv_1);
    tmp1=replace(funstr,varv,textformat(tmp,5));
    tmp="Num="+text(Num_2);
    tmp2=concat(options,["Msg=no",tmp]);
    Spacecurve(nm+"u"+#,tmp1,var1,tmp2);
    sfdtuL=append(sfdtuL,"sc3d"+nm+"u"+#);
  );
  sfdtvL=[];
  forall(0..Wire_1,
    tmp=rngu_1+#/Wire_1*(rngu_2-rngu_1);
    tmp1=replace(funstr,varu,textformat(tmp,5));
    tmp="Num="+text(Num_1);
    tmp2=concat(options,["Msg=no",tmp]);
    Spacecurve(nm+"v"+#,tmp1,var2,tmp2);
    sfdtvL=append(sfdtvL,"sc3d"+nm+"v"+#);
  );
  if(Noflg<3,
    println(" generate totally "+"sf3d"+nm);
    tmp1="";
    forall(sfdtuL,
      tmp1=tmp1+Dq+#+Dq+",";
    );
    tmp1=substring(tmp1,0,length(tmp1)-1);
    tmp2="";
    forall(sfdtvL,
      tmp2=tmp2+Dq+#+Dq+",";
    );
    tmp2=substring(tmp2,0,length(tmp2)-1);
    tmp="sf3d"+nm+"=[["+tmp1+"],["+tmp2+"]]";
    parse(tmp);
  );
  [sfdtuL,sfdtvL];
);
////%Sf3data end////

////%SfbdparadataR start////
SfbdparadataR(nm,fd):=
   SfbdparadataR(nm,fd,[],["nodisp"]);
SfbdparadataR(nm,fd,options):=
   SfbdparadataR(nm,fd,options,["nodisp"]);
SfbdparadataR(nm,fdorg,optionorg,optionsh):=(
// help:SfbdparadataR("1",Fd);
// help:SfbdparadataR(options2=["Wait=60",division(c(50,50)),Eps1(0.01), Eps2(0.05)]);
  regional(fd,options,name3,name3h,waiting,
     eqL,reL,strL,fname,tmp,tmp1,tmp2,flg,wflg);
  tmp=ConvertFdtoC(fdorg);//180430[2lines]
  FuncListC=append(FuncListC,tmp);
  name3="sfbd3d"+nm;
  name3h="sfbdh3d"+nm;
  fname=Fhead+"sfbd"+nm+".txt";
  tmp=apply(fdorg,if(isstring(#),"'"+#+"'",#));
  tmp=text(tmp);
  fd=RSform(tmp,2);
  options=optionorg;
  tmp=Divoptions(options);
  eqL=tmp_5;
  reL=tmp_6;
  strL=tmp_7;
  waiting=120;
  forall(eqL,
    tmp=indexof(#,"=");
    tmp1=Toupper(substring(#,0,1));
    tmp2=substring(#,tmp,length(#));
    if(tmp1=="W",
      waiting=parse(tmp2);
      options=remove(options,[#]);
    );
  );
  options=remove(options,reL);
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
  cmdL=[]; //180509from
  tmp=Select(GLIST,indexof(#,"Proj")==0);
  cmdL=MkprecommandR(tmp);//180509to
  tmp=["fd"+nm];
  if(length(reL)>0,
    reL=textformat(reL,4);
    reL=substring(reL,1,length(reL)-1);
    reL=RSform(reL);
    tmp=append(tmp,reL);
  );
  tmp1=[Dqq(fname),Dqq(name3),name3,Dqq(name3h),name3h];//180509
  tmp2=replace(fname,".txt",".Rdata"); //18.02.18
  cmdL=concat(cmdL,[
    "print",[Dqq("fd"+nm)], //18.02.22
    "fd"+nm+"="+fd,[],
    name3+"=Sfbdparadata",tmp,
    name3h+"=HIDDENDATA",[],
    "WriteOutData",tmp1,
    "save",["CUSPPT","OTHERPARTITION","file='"+tmp2+"'"]
  ]);
  tmp=replace(fname,".txt","end.txt");
  options=concat(options,["Out=no","Wait="+text(waiting),"Res="+tmp]);
  if(wflg==1,options=append(options,"m"));
  if(wflg==-1,options=append(options,"r"));
  options=append(options,"Pre=!G"); //180509
  if(ErrFlag==0,
    CalcbyR("sfbd"+nm,cmdL,options);
  );
  if(ErrFlag==1,
    err("Sfbdparadata not completed");
  ,
    ReadOutData(fname);
    if(islist(parse(name3)), //180508[2lines]
      Extractdata(name3,["nodisp"]);
      Projpara(name3,options); 
      if(length(optionsh)>0,tmp=optionsh,tmp=["nodisp"]);
      Projpara(name3h,tmp); //180508
    ,
      ErrFlag=1;
    );
  );
);
////%SfbdparadataR end////

////%Addpoints start////
Addpoints():=(//18.02.20
  if(isstring(ADDPOINT),
    ADDPOINT;
  ,
    "list()";
  );
);
Addpoints(ptlist):=(
//help:Addpoints(list of 3d points);
  if(length(ptlist)==0,
    ADDPOINT="list()";
  ,
    ADDPOINT=RSform(textformat(ptlist,6),2);
  );
  ADDPOINT;
);
////%Addpoints end////

////%CrvsfparadataR start////
CrvsfparadataR(nm,crv,sf,fd):=
  CrvsfparadataR(nm,crv,sf,fd,[],["nodisp"]);
CrvsfparadataR(nm,crv,sf,fd,options):=
   CrvsfparadataR(nm,crv,sf,fd,options,["nodisp"]);
CrvsfparadataR(nm,crvstr,sfstr,fdorg,optionorg,optionsh):=(
// help:CrvsfparadataR("1","ax3d","sfbd3d1",fd);
// help:CrvsfparadataR(options2=[division(c(50,50)),Eps1(0.01), Eps2(0.05)]);    
  regional(gd,out,fd,options,name3,name3h,
     eqL,reL,strL,fname,rfname,waiting,tmp,tmp1,tmp2,tmp3,flg,wflg);
  tmp=replace(crvstr,"3d","2d");
  Changestyle(tmp,["nodisp"]);
  name3="crvsf3d"+nm;
  name3h="crvsfh3d"+nm;
  fname=Fhead+"crvsf"+nm+".txt";
  rfname=Fhead+sfstr+".txt";
  rfname=replace(rfname,"3d","");
  tmp=apply(fdorg,if(isstring(#),"'"+#+"'",#));
  tmp=text(tmp);
  fd=RSform(tmp,2);
  options=optionorg;
  tmp=Divoptions(options);
  eqL=tmp_5;
  reL=tmp_6;
  strL=tmp_7;
  waiting=120;
  forall(eqL,
    tmp=indexof(#,"=");
    tmp1=Toupper(substring(#,0,1));
    tmp2=substring(#,tmp,length(#));
    if(tmp1=="W",
      waiting=parse(tmp2);
      options=remove(options,[#]);
    );
  );
  options=remove(options,reL);
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
  reL=RSform(text(reL),2);
  reL=substring(reL,5,length(reL)-1);
  cmdL=[]; //180509from
  tmp=Select(GLIST,indexof(#,"Proj")==0);
  cmdL=MkprecommandR(tmp);//180509to
  tmp2=replace(rfname,".txt",".Rdata");
  cmdL=concat(cmdL,[
    "print",[Dqq("crv"+nm)], //18.02.22
    "fd"+nm+"="+fd,[],
    "ReadOutData",[Dqq(rfname)],
    "load",[Dqq(tmp2)],
    "Addpoints",[Addpoints()]
  ]);
  tmp3=select(GLIST,indexof(#,crvstr+"=")>0); //18.02.22from
  if(length(tmp3)==0,
    tmp3=Fhead+crvstr+".txt";
    tmp3=replace(tmp3,"3d","");
    cmdL=concat(cmdL,[
      "ReadOutData",[Dqq(tmp3)]
    ]);
  ); //18.02.22to
  tmp=[crvstr,sfstr,"fd"+nm];
  if(length(reL)>0,
    reL=textformat(reL,4);
    reL=substring(reL,1,length(reL)-1);
    reL=Rsform(reL);
    tmp=append(tmp,reL);
  );
  tmp1=[Dqq(fname),Dqq(name3),name3,Dqq(name3h),name3h];
  cmdL=concat(cmdL,[
    name3+"=Crvsfparadata",tmp,
    name3h+"=CRVSFHIDDENDATA",[],
    "WriteOutData",tmp1
  ]);
  tmp=replace(fname,".txt","end.txt");
  options=concat(options,["Out=no","Wait="+text(waiting),"Res="+tmp]);
  if(wflg==1,options=append(options,"m"));
  if(wflg==-1,options=append(options,"r"));
  options=append(options,"Pre=!G");//180509
  if(ErrFlag==0,
    CalcbyR("crvsf"+nm,cmdL,options);
  );
  if(ErrFlag==1,
    err("Crvsfparadata not completed");
  ,
    ReadOutData(fname);
    if(islist(parse(name3)), //180507[2lines]
      Extractdata(name3,["nodisp"]);
      Projpara(name3,options);
      if(length(optionsh)>0,tmp=optionsh,tmp=["nodisp"]);
      Projpara(name3h,tmp);//180507
    ,
      ErrFlag=1;
    );
  );
);
////%CrvsfparadataR end////

////%Crv3onsfparadataR start////
Crv3onsfparadataR(nm,crv3d,sf,fd):=
  Crvs3onfparadataR(nm,crv3d,sf,fd,[],["nodisp"]);
Crv3onsfparadataR(nm,crv3d,sf,fd,options):=
   Crv3onsfparadataR(nm,crv3d,sf,fd,options,["nodisp"]);
Crv3onsfparadataR(nm,crv3dstr,sfstr,fdorg,optionorg,optionsh):=(
// help:Crv3onsfparadataR("1","sc1","sfbd3d1",fd);
// help:Crv3onsfparadataR(options2=[division(c(50,50)),Eps1(0.01), Eps2(0.05)]);    
  regional(gd,out,fd,options,name3,name3h,
     eqL,reL,strL,fname,rfname,waiting,tmp,tmp1,tmp2,tmp3,flg,wflg);
  tmp1=replace(crv3dstr,"3d","2d");
  tmp=apply(GCLIST,#_1);
  if(contains(tmp,tmp1),
    Changestyle3d(tmp1,["nodisp"]);//180428
  );
  Changestyle(tmp,["nodisp"]);
  name3="crv3onsf3d"+nm;
  name3h="crv3onsfh3d"+nm;
  fname=Fhead+"crv3onsf"+nm+".txt";
  rfname=Fhead+sfstr+".txt";
  rfname=replace(rfname,"3d","");
  tmp=apply(fdorg,if(isstring(#),Dqq(#),#));
  tmp=text(tmp);
  fd=RSform(tmp,2);
  options=optionorg;
  tmp=Divoptions(options);
  eqL=tmp_5;
  reL=tmp_6;
  strL=tmp_7;
  waiting=120;
  forall(eqL,
    tmp=indexof(#,"=");
    tmp1=Toupper(substring(#,0,1));
    tmp2=substring(#,tmp,length(#));
    if(tmp1=="W",
      waiting=parse(tmp2);
      options=remove(options,[#]);
    );
  );
  options=remove(options,reL);
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
  reL=RSform(text(reL),2);
  reL=substring(reL,5,length(reL)-1);
  cmdL=[]; //180509from
  tmp=Select(GLIST,indexof(#,"Proj")==0);
  cmdL=MkprecommandR(tmp);//180509to
  tmp=["crv",sfstr,"fd"+nm];
  if(length(reL)>0,
    reL=textformat(reL,4);
    reL=substring(reL,1,length(reL)-1);
    reL=Rsform(reL);
    tmp=append(tmp,reL);
  );
  tmp1=[Dqq(fname),Dqq(name3),name3,Dqq(name3h),name3h];
  tmp2=replace(rfname,".txt",".Rdata");
  cmdL=concat(cmdL,[
    "print",[Dqq("crv3onsf"+nm)], //180222
    "fd"+nm+"="+fd,[],
    "ReadOutData",[Dqq(rfname)],
    "load",[Dqq(tmp2)]
  ]);
  cmdL=concat(cmdL,[  
    "Addpoints",[Addpoints()],
    "crv="+crv3dstr,[],
    name3+"=Crv3onsfparadata",tmp,
    name3h+"=HIDDENDATA",[],
    "WriteOutData",tmp1
  ]);
  tmp=replace(fname,".txt","end.txt");
  options=concat(options,["Out=no","Wait="+text(waiting),"Res="+tmp]);
  if(wflg==1,options=append(options,"m"));
  if(wflg==-1,options=append(options,"r"));
  options=append(options,"Pre=!G"); //180508
  if(ErrFlag==0,
    CalcbyR("crv3onsf"+nm,cmdL,options);
  );
  if(ErrFlag==1,
    err("Crv3onsfparadata not completed");
  ,
    ReadOutData(fname);
    if(islist(parse(name3)),
      Extractdata(name3,["nodisp"]);
      Projpara(name3,options); //180507
      if(length(optionsh)>0,tmp=optionsh,tmp=["nodisp"]);
      Extractdata(name3h,["nodisp"]);
      Projpara(name3h,tmp);
    ,
      ErrFlag=1;
    );
  );
);
////%Crv3onsfparadataR end////

////%Crv2onsfparadataR start////
Crv2onsfparadataR(nm,crv2d,sf,fd):=
  Crvs2onfparadataR(nm,crv2d,sf,fd,[],["nodisp"]);
Crv2onsfparadataR(nm,crv2d,sf,fd,options):=
   Crv2onsfparadataR(nm,crv2d,sf,fd,options,["nodisp"]);
Crv2onsfparadataR(nm,crv2dstr,sfstr,fdorg,optionorg,optionsh):=(
//help :Crv2onsfparadataR("1","pa1","sfbd3d1",fd);
//help :Crv2onsfparadataR(options2=[division(c(50,50)),Eps1(0.01), Eps2(0.05)]);    
  regional(gd,out,fd,options,name3,name3h,
     eqL,reL,strL,fname,rfname,waiting,tmp,tmp1,tmp2,tmp3,flg,wflg);
  Changestyle(crv2dstr,["nodisp"]);
  name3="crv2onsf3d"+nm;
  name3h="crv2onsfh3d"+nm;
  fname=Fhead+"crv2onsf"+nm+".txt";
  rfname=Fhead+sfstr+".txt";
  rfname=replace(rfname,"3d","");
  tmp=apply(fdorg,if(isstring(#),Dqq(#),#));
  tmp=text(tmp);
  fd=RSform(tmp,2);
  options=optionorg;
  tmp=Divoptions(options);
  eqL=tmp_5;
  reL=tmp_6;
  strL=tmp_7;
  waiting=120;
  forall(eqL,
    tmp=indexof(#,"=");
    tmp1=Toupper(substring(#,0,1));
    tmp2=substring(#,tmp,length(#));
    if(tmp1=="W",
      waiting=parse(tmp2);
      options=remove(options,[#]);
    );
  );
  options=remove(options,reL);
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
  if(isstring(crv2dstr),
    crv=Rsform(crv2dstr);
  ,
    crv=apply(crv2dstr,Dqq(#));
    crv=Rsform(text(crv));
    crv="Paramplot"+substring(crv,1,length(crv));
  );
  reL=RSform(text(reL),2);
  reL=substring(reL,5,length(reL)-1);
  cmdL=[]; //180509from
  tmp=Select(GLIST,indexof(#,"Proj")==0);
  cmdL=MkprecommandR(tmp);//180509to
  tmp=["crv",sfstr,"fd"+nm];
  if(length(reL)>0,
    reL=textformat(reL,4);
    reL=substring(reL,1,length(reL)-1);
    reL=Rsform(reL);
    tmp=append(tmp,reL);
  );
  tmp1=[Dqq(fname),Dqq(name3),name3,Dqq(name3h),name3h];
  tmp2=replace(rfname,".txt",".Rdata");
  cmdL=concat(cmdL,[
    "print",[Dqq("crv2onsf"+nm)], //18.02.22
    "fd"+nm+"="+fd,[],
    "ReadOutData",[Dqq(rfname)],
    "load",[Dqq(tmp2)]
  ]);
  cmdL=concat(cmdL,[  
    "Addpoints",[Addpoints()],
    "crv="+crv2dstr,[],
    name3+"=Crv2onsfparadata",tmp,
    name3h+"=HIDDENDATA",[],
    "WriteOutData",tmp1
  ]);
  tmp=replace(fname,".txt","end.txt");
  options=concat(options,["Out=no","Wait="+text(waiting),"Res="+tmp]);
  if(wflg==1,options=append(options,"m"));
  if(wflg==-1,options=append(options,"r"));
  options=append(options,"Pre=!G"); //180508
  if(ErrFlag==0,
    CalcbyR("crv2onsf"+nm,cmdL,options);
  );
  if(ErrFlag==1,
    err("Crv2onsfparadata not completed");
  ,
    ReadOutData(fname);
    if(islist(parse(name3)),
      Extractdata(name3,["nodisp"]);
      Projpara(name3,options); //180507
      if(length(optionsh)>0,tmp=optionsh,tmp=["nodisp"]);
      Projpara(name3h,tmp);
    ,
      ErrFlag=1;
    );
  );
);
////%Crv2onsfparadataR end////

////%WireparadataR start////
WireparadataR(nm,sf,wr1,wr2,fd):=
  WireparadataR(nm,sf,fd,wr1,wr2,[],["nodisp"]);
WireparadataR(nm,sf,fd,wr1,wr2,options):=
   WireparadataR(nm,sf,fd,wr1,wr2,options,["nodisp"]);
WireparadataR(nm,sfstr,fdorg,wr1,wr2,optionorg,optionsh):=(
// help:WireparadataR("1","sfbd3d1",fd,5,5);
// help:WireparadataR(options2=[division(c(50,50)),Eps1(0.01), Eps2(0.05)]); 
  regional(fd,options,name3,name3h,outreg,
     eqL,reL,strL,fname,rfname,waiting,tmp,tmp1,tmp2,flg,wflg);
  name3="wire3d"+nm;
  name3h="wireh3d"+nm;
  fname=Fhead+"wire"+nm+".txt";
  rfname=Fhead+sfstr+".txt";
  rfname=replace(rfname,"3d","");
  tmp=apply(fdorg,if(isstring(#),"'"+#+"'",#));
  tmp=text(tmp);
  fd=RSform(tmp,2);
  options=optionorg;
  tmp=Divoptions(options);
  eqL=tmp_5;
  reL=tmp_6;
  strL=tmp_7;
  waiting=600;
  forall(eqL,
    tmp=indexof(#,"=");
    tmp1=Toupper(substring(#,0,1));
    tmp2=substring(#,tmp,length(#));
    if(tmp1=="W",
      waiting=parse(tmp2);
      options=remove(options,[#]);
    );
  );
  options=remove(options,reL);
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
  tmp1=textformat(wr1,6);
  tmp1=Rsform(tmp1,1);
  tmp2=textformat(wr2,6);
  tmp2=Rsform(tmp2,1);
  tmp=[sfstr,"fd"+nm,tmp1,tmp2];
  reL=RSform(text(reL),2);
  reL=substring(reL,5,length(reL)-1);
  cmdL=[]; //180509from
  tmp=Select(GLIST,indexof(#,"Proj")==0);
  cmdL=MkprecommandR(tmp);//180509to
  tmp1=textformat(wr1,6);
  tmp1=Rsform(tmp1,1);
  tmp2=textformat(wr2,6);
  tmp2=Rsform(tmp2,1);
  tmp=[sfstr,"fd"+nm,tmp1,tmp2];
  reL=RSform(text(reL),2);
  reL=substring(reL,5,length(reL)-1);
  if(length(reL)>0,
    reL=textformat(reL,4);
    reL=substring(reL,1,length(reL)-1);
    reL=Rsform(reL);
    tmp=append(tmp,reL);
  );
  tmp1=[Dqq(fname),Dqq(name3),name3,Dqq(name3h),name3h];
  tmp2=replace(rfname,".txt",".Rdata");
  cmdL=concat(cmdL,[
    "print",[Dqq("wire"+nm)], //18.02.22
    "fd"+nm+"="+fd,[],
    "ReadOutData",[Dqq(rfname)],
    "load",[Dqq(tmp2)],
    "Addpoints",[Addpoints()],
    name3+"=Wireparadata",tmp,
    name3h+"=WIREHIDDENDATA",[],
    "WriteOutData",tmp1
  ]);
  tmp=replace(fname,".txt","end.txt");
  options=concat(options,["Out=no","Wait="+text(waiting),"Res="+tmp]);
  if(wflg==1,options=concat(options,["m"]));
  if(wflg==-1,options=concat(options,["r"]));
  options=append(options,"Pre=!G"); //180508
  if(ErrFlag==0,
    CalcbyR("wire"+nm,cmdL,options);
  );
  if(ErrFlag==1,
    err("Wireparadata not completed");
  ,
    ReadOutData(fname);
    if(islist(parse(name3)),
      Extractdata(name3,["nodisp"]);
      Projpara(name3,options);
      if(length(optionsh)>0,tmp=optionsh,tmp=["nodisp"]);
      Projpara(name3h,tmp);
    ,
      ErrFlag=1;
    );
  );
);
////%WireparadataR end////

////%IntersectcrvsfR start////
IntersectcrvsfR(nm,crv,fd):=Intersectcrvsf(nm,crv,fd,"",[]);
IntersectcrvsfR(nm,crv,fd,Arg):=(
  if(isstring(Arg),
    IntersectcrvsfR(nm,crv,fd,Arg,[]);
  ,
    IntersectcrvsfR(nm,crv,fd,"",Arg);
  );
);
IntersectcrvsfR(nm,crvstr,fdorg,bdyeq,optionorg):=(
// help:IntersectcrvsfR("1",curve,fd);
// help:IntersectcrvsfR("1",curve,fd,curveequation);
// help:IntersectcrvsfR(options=[Np([50,50]),Eps(0.01)]);
  regional(name,crv,fd,options,reL,fname,crvfname,argR,
     waiting,tmp,tmp1,tmp2,flg,wflg,pts);  name="crvsf"+nm;
  name="crvsf"+nm;
  fname=Fhead+name+".txt";
  crvfname=Fhead+"crv"+nm+".txt";
//  crv=parse(crvstr);
//  crv=textformat(crv,6);
//  crv=Rsform(crv,2);
  fd=apply(fdorg,if(isstring(#),Dqq(#),#));
  options=optionorg;
  tmp=Divoptions(options);
  eqL=tmp_5;
  reL=tmp_6;
  strL=tmp_7;
  waiting=120;
  forall(eqL,
    tmp=indexof(#,"=");
    tmp1=Toupper(substring(#,0,1));
    tmp2=substring(#,tmp,length(#));
    if(tmp1=="W",
      waiting=parse(tmp2);
      options=remove(options,[#]);
    );
  );
  options=remove(options,reL);
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
  tmp=apply(fdorg,if(isstring(#),"'"+#+"'",#));
  tmp=text(tmp);
  fd=RSform(tmp,2);
  tmp=textformat(reL,4);
  tmp=substring(tmp,1,length(tmp)-1);
  tmp=Rsform(tmp);
  if(length(bdyeq)>0,
    argR=","+Dqq(bdyeq);
  ,
    argR="";
  );
  if(length(tmp)>0,
    argR=argR+","+tmp;
  );
  tmp1=[Dqq(fname),Dqq(name),"tmp"];
  cmdL=[
    "print",[Dqq("crvsf"+nm)], //18.02.22
    "crv="+crvstr,[],
    "fd="+fd,[],
    "tmp1=Intersectcrvsf(crv,fd"+argR+")",[],
    "tmp=c()",[],
    "for(j in Looprange(1,length(tmp1))){",[],
    "  tmp=Appendrow(tmp,tmp1[[j]])",[],
    "}",[],
    "WriteOutData",tmp1,
    "tmp",[]
  ];
  tmp=replace(fname,".txt","end.txt");
  options=concat(options,["Out=no","Wait="+text(waiting),"Res="+tmp]);
  if(wflg==1,options=append(options,"m"));
  if(wflg==-1,options=append(options,"r"));
  if(ErrFlag==1,
	err("Crvsfparadata not completed");
  ,
	CalcbyR("ans",cmdL,options);
    ReadOutData(fname);
  );
  println("generate "+name);
  parse(name);
);
////%IntersectcrvsfR end////

////%SfcutparadataR start////
SfcutparadataR(nm,eqstr,sf,fd):=
  SfcutparadataR(nm,eqstr,sf,fd,[]);
SfcutparadataR(nm,eqstr,sf,fd,options):=
  SfcutparadataR(nm,eqstr,sf,fd,options,["nodisp"]);
SfcutparadataR(nm,eqstrorg,sf,fdorg,optionorg,optionsh):=(
// help:SfcutparadataR("1","x+y+z=1","sfbd3d1",fd);
// help:SfcutparadataR(options2=[Division(c(50,50)),Eps1(0.01), Eps2(0.05)]);    
  regional(gd,out,fd,options,name3,name3h,eqstr,
     eqL,reL,strL,fname,rfname,waiting,tmp,tmp1,tmp2,tmp3,flg,wflg);
  tmp=Strsplit(eqstrorg,"=");
  if(length(tmp)==1,
    eqstr=tmp_1;
  ,
    eqstr=tmp_1+"-("+tmp_2+")";
  );
  tmp=replace(sfcut,"3d","2d");
  Changestyle(tmp,["nodisp"]);
  name3="sfcut3d"+nm;
  name3h="sfcuth3d"+nm;
  fname=Fhead+"sfcut"+nm+".txt";
  rfname=Fhead+sf+".txt";
  rfname=replace(rfname,"3d","");
  tmp=apply(fdorg,if(isstring(#),"'"+#+"'",#));
  tmp=text(tmp);
  fd=RSform(tmp,2);
  options=optionorg;
  tmp=Divoptions(options);
  eqL=tmp_5;
  reL=tmp_6;
  strL=tmp_7;
  waiting=120;
  forall(eqL,
    tmp=indexof(#,"=");
    tmp1=Toupper(substring(#,0,1));
    tmp2=substring(#,tmp,length(#));
    if(tmp1=="W",
      waiting=parse(tmp2);
      options=remove(options,[#]);
    );
  );
  options=remove(options,reL);
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
  reL=RSform(text(reL),2);
  reL=substring(reL,5,length(reL)-1);
  cmdL=[]; //180509from
  tmp=Select(GLIST,indexof(#,"Proj")==0);
  cmdL=MkprecommandR(tmp);//180509to
  tmp=[Dqq(eqstr),sf,"fd"+nm];
  if(length(reL)>0,
    reL=textformat(reL,4);
    reL=substring(reL,1,length(reL)-1);
    reL=Rsform(reL);
    tmp=append(tmp,reL);
  );
  tmp1=[Dqq(fname),Dqq(name3),name3,Dqq(name3h),name3h];
  tmp2=replace(rfname,".txt",".Rdata");
  cmdL=concat(cmdL,[
    "print",[Dqq("sfcut"+nm)], //18.02.22
    "fd"+nm+"="+fd,[],
    "ReadOutData",[Dqq(rfname)],
    "load",[Dqq(tmp2)],
    name3+"=Sfcutparadata",tmp,
    name3h+"=CRVONSFHIDDENDATA",[],
    "WriteOutData",tmp1
  ]);
  tmp=replace(fname,".txt","end.txt");
  options=concat(options,["Out=no","Wait="+text(waiting),"Res="+tmp]);
  if(wflg==1,options=append(options,"m"));
  if(wflg==-1,options=append(options,"r"));
  options=append(options,"Pre=!G"); //180508
  if(ErrFlag==0,
    CalcbyR("sfcut"+nm,cmdL,options);
  );
  if(ErrFlag==1,
    err("Sfcutparadata not completed");
  ,
    ReadOutData(fname);
    if(islist(parse(name3)),
      Extractdata(name3,["nodisp"]);
      Projpara(name3,options);
      if(length(optionsh)>0,tmp=optionsh,tmp=["nodisp"]);
      Projpara(name3h,tmp);
    ,
      ErrFlag=1;
    );
  );
);
////%SfcutparadataR end////

////%Skeletonparadata start////
Skeletonparadata(nm):=Skeletondatacindy(nm,[]);
Skeletonparadata(nm,options):=Skeletondatacindy(nm,options);
Skeletonparadata(nm,pltdata1,pltdata2):=Skeletondatacindy(nm,pltdata1,pltdata2);
Skeletonparadata(nm,pltdata1org,pltdata2org,options):=
    Skeletondatacindy(nm,pltdata1org,pltdata2org,options);
////%Skeletonparadata end////

////////////// new skeleton  2018.01.04 not completed and slow////////////////

Skeletondatacindy(nm):=Skeletondatacindy(nm,[]);
Skeletondatacindy(nm,options):=(
  regional(tmp); 
  tmp=Datalist3d();
  Skeletondatacindy(nm,tmp,tmp,options);
);
Skeletondatacindy(nm,pltdata1,pltdata2):=
     Skeletondatacindy(nm,pltdata1,pltdata2,[]);
Skeletondatacindy(nm,pltdata1org,pltdata2org,options):=(
//help:Skeletonparadata("1");
//help:Skeletonparadata("1",[pdata1,pdata2],[pdata3]);
//help:Skeletondata(options2=[1(width)]);
  regional(Eps,Eps2,name2,name3,Ltype,Noflg,reL,opcindy,color,
     Data,Out,ObjL,Plt3L,Rr,pltdata1,pltdata2,Plt2L,ObjL,ii,Data,
     Obj3,jj,Gd,PtD,size,tmp,tmp1,tmp2);
  name2="sk2d"+nm;
  name3="sk3d"+nm;
  pltdata1=[];// 16.01.31
  forall(pltdata1org,tmp1,
    tmp=parse(tmp1);
    pltdata1=append(pltdata1,tmp);
  );
  pltdata2=[];// 16.01.31
  forall(pltdata2org,tmp1,
    tmp=parse(tmp1);
    pltdata2=append(pltdata2,tmp);
  );
  tmp=Divoptions(options);
  Ltype=tmp_1;
  Noflg=tmp_2;
  reL=tmp_6; //16.02.28 
  color=tmp_(length(tmp)-2);
  opcindy=tmp_(length(tmp));
  Rr=0.15*1000/2.54/MilliIn;
  size=1;
  Eps2=0.05;
  if(length(reL)>0, //16.02.28 
    size=reL_1;
    Rr=size*Rr;
    if(length(reL)>1,Eps2=reL_2);
  );
  Eps=10^(-4);
  ObjL=Flattenlist(pltdata1);
  PltL=Flattenlist(pltdata2);
  Data=Makeskeletondata(ObjL,PltL,Rr);
  Out=select(Data,length(Projcurve(#))>0);
  Out=Flattenlist(Out);
  tmp1=apply(Out,textformat(#,5));
  tmp=name3+"="+tmp1;
  parse(tmp);
  tmp=name2+"=Projcurve("+name3+");";
  parse(tmp);
  Changestyle3d(pltdata1org,["nodisp"]);
  if(Noflg<3,
    println("generate skeleton :"+name3);
    tmp1=text(pltdata1org);
    tmp1="list("+substring(tmp1,1,length(tmp1)-1)+")";
    tmp2=text(pltdata2org);
    tmp2="list("+substring(tmp2,1,length(tmp2)-1)+")";
    tmp=name3+"=Skeletonpara3data("+tmp1+","+tmp2+",";
    tmp=tmp+text(size)+")";
    GLIST=append(GLIST,tmp);  
    tmp=name2+"=Projpara("+name3+")";
    GLIST=append(GLIST,tmp);
  );
  if(Noflg<2,
    if(isstring(Ltype),
      if(color!=KCOLOR, //180904
        Texcom("{");Com2nd("Setcolor("+color+")");//180722
      );
      Ltype=GetLinestyle(text(Noflg)+Ltype,name2);
      if(color!=KCOLOR, //180904
        Texcom("}");//180722
      );
    ,
      if(Noflg==1,Ltype=0);
    );
    GCLIST=append(GCLIST,[name2,Ltype,opcindy]);
    if(SUBSCR==1,
      Subgraph(name3,opcindy);
    );
  );
  Out;
);

Makeskeletondata(ObjL,PltL,R0):=(
  regional(Allres,res,Eps1,obj,plt,obj2,remov,flg,koc,z1,z2,Rr,str,
         mm,nn,kk,ptk,pL,pt,ptL,tmp,tmp1,tmp2,tmp3,tmp3d);
  Eps1=10.0^(-2);
  Allres=[];
  forall(1..(length(ObjL)),mm,
	obj=ObjL_mm;
    remov=[];
    obj2=Projcurve(obj);
    forall(1..(length(PltL)),nn,
	  plt=PltL_nn;
      tmp=Projcurve(plt);
      koc=IntersectcurvesPp(obj2,tmp);
      forall(1..(length(koc)),kk,
        ptk=koc_kk;
        tmp=PointonCurve(ptk_2,obj);
        z1=Zparapt(tmp);
        tmp=PointonCurve(ptk_3,plt);
        z2=Zparapt(tmp);
        if(z1<z2-Eps1,
          tmp=max([sqrt(1-(ptk_5)^2),0.75]);
          Rr=R0/tmp;
          tmp2=[];
          flg=0;
          tmp=reverse(1..(floor(ptk_2)));
          forall(tmp,
            if(flg==0,
              if(|obj2_#-ptk_1|>Rr,
                tmp2=[#];
                flg=1;
              );
            );
          );
          if(length(tmp2)==0,tmp2=[1]);
          flg=0;
          tmp=(ceil(ptk_2))..(length(obj2));
          forall(tmp,
            if(flg==0,
              if(|obj2_#-ptk_1|>Rr,
                tmp2=append(tmp2,#);
                flg=1;
              );
            );
          );
          if(length(tmp2)==1,tmp2=append(tmp2,length(obj2)));
          tmp=obj2_((tmp2_1)..(tmp2_2));
          tmp1=Circledata("",[ptk_1,ptk_1+[Rr,0]],["Num=8","nodata"]);
          tmp1=Intersectcurves(tmp,tmp1);
          if(length(tmp1)==2,
            tmp=sort([tmp1_1_2,tmp1_2_2]);
            tmp=[[tmp2_1-1+tmp_1,1],[tmp2_1-1+tmp_2,-1]];
            remov=concat(remov,tmp);
          );
          if(length(tmp1)==1,
            if(tmp2_1==1,
              tmp=[[1,1],[tmp2_1-1+tmp1_1_2,-1]];
            ,
              tmp=[[tmp2_1-1+tmp1_1_2,1],[length(obj2),-1]];
            );
            remov=concat(remov,tmp);
          );
        );
      );
    );
    if(length(remov)==0,
      res=obj; 
    ,
      res=[];
      remov=sort(remov,[#_1,#_2]);
      tmp=select(remov,#_1<1-Eps1);
      if(length(tmp)==0,
        flg=0;
        res=[1];
      ,
        flg=length(tmp);
        res=[];
      );
      forall(remov,
        tmp=flg;
        if(#_2==-1,
          flg=flg-1;
          if(flg==0,res=append(res,#_1));
        );
        if(#_2==1,
          flg=flg+1;
          if(tmp==0,res=append(res,#_1));
        );
      );
      if((flg==0)&(res_(length(res))<length(obj)),
        res=append(res,length(obj));
      );
      tmp=res;
      res=[];
      forall(1..(length(tmp)/2),nn,
        tmp1=tmp_(2*nn-1);
        tmp2=tmp_(2*nn);
        pL=(ceil(tmp1))..(floor(tmp2));
        if(tmp1<ceil(tmp1)-Eps1,pL=prepend(tmp1,pL));
        if(tmp2>floor(tmp2)+Eps1,pL=append(pL,tmp2));
        ptL=[];
        forall(pL,
          pt=PointonCurve(#,obj);
          ptL=append(ptL,pt);
        );
        res=append(res,ptL);
      );
    );
	Allres=append(Allres,res);
  );
  Allres;
);

////////////// current skeleton  2018.01.04 ////////////////

////%Skeletonparadata start////
Skeletondatacindy(nm):=Skeletondatacindy(nm,[]);
Skeletondatacindy(nm,options):=(
  regional(tmp); 
  tmp=Datalist3d();
  Skeletondatacindy(nm,tmp,tmp,options);
);
Skeletondatacindy(nm,pltdata1,pltdata2):=
     Skeletondatacindy(nm,pltdata1,pltdata2,[]);
Skeletondatacindy(nm,pltdata1org,pltdata2org,optionsorg):=(
//help:Skeletondatacindy("1");
//help:Skeletondatacindy("1",[pdata1,pdata2],[pdata3]);
//help:Skeletondatacindy(options=[1(width),"File=y(/m/n)","Not=ptlist","Check=ptlist"]);
  regional(Eps,Eps2,name2,name3,options,Ltype,Noflg,reL,eqL,opcindy,
     Out,ObjL,Plt3L,Rr,pltdata1,pltdata2,Plt2L,ObjL,ii,Data,
     Obj3,jj,Gd,PtD,size,tmp,tmp1,tmp2,color,
     fileflg,wflg,mkflg,fname,varL,nn,chkL); //181101
  name2="sk2d"+nm;
  name3="sk3d"+nm;
  fname=Fhead+"sk"+nm+".txt"; //181102
  pltdata1=[];// 16.01.31
  forall(pltdata1org,tmp1,
    tmp=parse(tmp1);
    pltdata1=append(pltdata1,tmp);
  );
  pltdata2=[];// 16.01.31
  forall(pltdata2org,tmp1,
    tmp=parse(tmp1);
    pltdata2=append(pltdata2,tmp);
  );
  options=optionsorg;
  tmp=Divoptions(options);
  Ltype=tmp_1;
  Noflg=tmp_2;
  eqL=tmp_5;
  reL=tmp_6; //16.02.28 
  color=tmp_(length(tmp)-2);
  opcindy=tmp_(length(tmp));
  Rr=0.075*1000/2.54/MilliIn;
  size=1;
  Eps2=0.05;
  fileflg="N";
  mkflg=1;
  if(length(reL)>0, //16.02.28 
    size=reL_1;
    Rr=size*Rr;
    if(length(reL)>1,Eps2=reL_2);
  );
  forall(eqL, //181101from
    tmp=Strsplit(#,"=");
    tmp1=Toupper(substring(tmp_1,0,1));
    if(tmp1=="FI",
      fileflg=Toupper(substring(tmp_2,0,1));
      options=remove(options,[#]);
    );
    if(tmp1=="N",
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
  );
  Eps=10^(-4);
  ObjL=Flattenlist(pltdata1);
  Plt3L=Flattenlist(pltdata2);
  tmp=apply(Plt3L,ProjcoordCurve(#));
  Plt2L=Flattenlist(tmp);
  if((fileflg=="Y")%(fileflg=="M")&(mkflg>-1),  //181101from, 181103
    wflg=1;
    tmp=flatten(pltdata1org);
    varL=tmp;
    tmp1=flatten(pltdata2org);
    forall(tmp1,
      if(!contains(varL,#),
        varL=append(varL,#);
      );
    );
    varL=sort(varL);
    forall(1..(length(varL)),nn,
      tmp1=varL_nn;
      tmp=select(GLIST,substring(#,0,length(tmp1))==tmp1);
      varL_nn=tmp_1;
    );
    tmp=["THETA="+format(THETA,5),"PHI="+format(PHI,5)];
    varL=concat(tmp,varL);
    forall(chkL,
      tmp=#+"="+Textformat(parse(#+".xy"),5);
      varL=append(varL,tmp);
    );
    if(fileflg=="M",
      fileflg="Y";
    ,
      tmp1="skeleton"+nm+".txt";
      if(isexists(Dirwork,tmp1),
        tmp2=load(tmp1);
        tmp2=tokenize(tmp2,"//");
        tmp2=tmp2_(1..(length(tmp2)-1));
        if(tmp2==varL,
          wflg=0;
          if(isexists(Dirwork,fname),
            mkflg=0;
            ReadOutData(fname);
            tmp=name3+"="+Textformat(parse(name3),5);
            parse(tmp);
            tmp=name2+"="+Textformat(parse(name2),5);
            parse(tmp);
          );
        );
      );
    );
  );
  if(mkflg==1, //181102
/////////////  tmp=apply(pltdata1,replace(#,"3d","2d"));
    Out=[];
    forall(1..(length(ObjL)),ii,
      Obj3=ObjL_ii;
      tmp=ProjcoordCurve(Obj3);
      Data=Makeskeletondata([tmp],Plt2L,Rr,Eps2);
      forall(1..(length(Data)),jj,
        Gd=Data_jj;
        if((length(Gd)>1) 
         & (Norm(Ptcrv(1,Gd)-Ptcrv(2,Gd))>Eps),
          PtD=[];
          forall(1..(length(Gd)),
            tmp=Gd_#;
            tmp1=Invparapt(tmp,Obj3);
            PtD=append(PtD,tmp1);
          );
          Out=append(Out,PtD);
        );
      );
    );
    Out=select(Out,length(Projcurve(#))>0); // 16.12.19
    tmp1=apply(Out,textformat(#,5));
    tmp=name3+"="+tmp1;
    parse(tmp);
    tmp=name2+"=Projcurve("+tmp1+");";
    parse(tmp);
  ); 
  if(mkflg>-1,
    Changestyle3d(pltdata1org,["nodisp"]);
  );
  if((Noflg<3)&(mkflg>-1), //181103
    if(fileflg!="Y", //181102
      println("generate skeleton :"+name3);
      tmp1=text(pltdata1org);
      tmp1="list("+substring(tmp1,1,length(tmp1)-1)+")";
      tmp2=text(pltdata2org);
      tmp2="list("+substring(tmp2,1,length(tmp2)-1)+")";
      tmp=name3+"=Skeletonpara3data("+tmp1+","+tmp2+",";
      tmp=tmp+text(size)+")";
      GLIST=append(GLIST,tmp);  
      tmp=name2+"=Projpara("+name3+")";
      GLIST=append(GLIST,tmp);
    ,
      GLIST=append(GLIST,"ReadOutData("+Dq+fname+Dq+")");//181102
    );
  );
  if((Noflg<2)&(mkflg>-1), //181103
    if(isstring(Ltype),
      if(!contains([[0,0,0],[0,0,0,1]],color),Com2nd("Setcolor("+color+")"));
      Ltype=GetLinestyle(text(Noflg)+Ltype,name2);
      if(!contains([[0,0,0],[0,0,0,1]],color),Com2nd("Setcolor("+text(KCOLOR)+")"));
    ,
      if(Noflg==1,Ltype=0);
    );
    GCLIST=append(GCLIST,[name2,Ltype,opcindy]);
    if(SUBSCR==1,
      Subgraph(name3,opcindy);
    );
  );
  if(mkflg>-1,
    if((fileflg=="Y")&(wflg==1), //181102from
      tmp1="skeleton"+nm+".txt";
      SCEOUTPUT = openfile(tmp1);
      forall(varL,
        println(SCEOUTPUT,#+"//");
      );
      closefile(SCEOUTPUT);
      WriteOutData(fname,[name3,parse(name3),name2,parse(name2)]);
    );  //181102to
    Out;
  );
);
////%Skeletonparadata end////

////%Makeskeletondata start////
Makeskeletondata(Obj2L,Plt2L,R0,Eps2):=(
  regional(Allres,Eps,Dmat,Dind,ii,Dt,nn1,nn2,Nind,Nobj,
      Plt2,PhL,ClipL,ns,pt1,pt2,pt,pta,ptb,za,zb,z1,z2,t1,t2,te,
	  koc,KukanL,nn,tt,Rr,Flg,ii,jj,ptq,hh,Ku,Res,contflg,breakflg);
  Eps=10.0^(-4);
  Dmat=[];
  Dind=[];
  forall(1..(length(Plt2L)),ii,
    Dt=Plt2L_ii;
    nn1=length(Dmat)+1;
    Dmat=concat(Dmat,Dt);
    nn2=length(Dmat);
    Dind=append(Dind,[nn1,nn2]);
  );
  Nind=length(Dind);
  Allres=[];
  forall(1..(length(Obj2L)),Nobj,
    Plt2=Obj2L_Nobj;
    PhL=Columnlist(Plt2,1..2);
	ClipL=[];
    forall(1..(length(PhL)-1),ns,
      pt1=PhL_(ns..(ns+1));
      forall(1..(length(Dind)),ii,
        tmp=Dind_ii;
        tmp=Dmat_(Dind_ii_1..Dind_ii_2);
        pt2=Columnlist(tmp,1..2);
        koc=IntersectcrvsPp(pt1,pt2,[Eps]);
        if(length(koc)>0,
          breakflg=0;
          forall(1..(length(koc)),jj,
            contflg=0;
            if(breakflg==0,
              pt=Op(1,Op(jj,koc));
              tmp=Op(2,Op(jj,koc));
              if((tmp<1+Eps) & (ns==1), 
                contflg=1;
              );    
              if(contflg==0,
                if((tmp>length(pt1)-Eps) 
                 & (ns==length(PhL)-1),
                  contflg=1;
                );
              );
              if(contflg==0,
                nn1=ns;
                nn2=Op(3,Op(jj,koc));
                tmp=Plt2_nn1;
                pta=tmp_(1..2);
                za=tmp_3;
                tmp=Plt2_(nn1+1);
                ptb=tmp_(1..2);
                zb=tmp_3;
                if(Norm(pta-ptb)<Eps,
                  contflg=1;
                );
              );
              if(contflg==0,
                t1=Norm(pta-pt)/Norm(pta-ptb);
                z1=(1-t1)*za+t1*zb;
                tmp=Dmat_(Dind_ii_1..Dind_ii_2);
                tmp1=tmp_nn2;
                pta=tmp1_(1..2);
                za=tmp1_3;
                tmp2=tmp_(nn2+1);
                ptb=tmp2_(1..2);
                zb=tmp2_3;
                if(Norm(pta-ptb)<Eps,
                  contflg=1;
                );
              );
              if(contflg==0,
                t2=Norm(pta-pt)/Norm(pta-ptb);
                z2=(1-t2)*za+t2*zb;
                if(z1<z2-Eps2,
                   if(length(ClipL)==0, 
                    tmp=1;
                  ,
                    tmp1=column(ClipL,1);
                    tmp1=apply(tmp1,#-pt_1);
                    tmp2=column(ClipL,2);
                    tmp2=apply(tmp2,#-pt_2);
                    tmp3=apply(tmp1,#^2)+apply(tmp2,#^2);
                    tmp=min(tmp3);         
                  );
                  if(tmp>Eps^2,
                    tmp1=pt1_2-pt1_1;
                    tmp2=ptb-pta;
                    tmp3=Dotprod(tmp1,tmp2);
                    tmp3=tmp3/Norm(tmp1)/Norm(tmp2);
                    tmp=1-0.5*tmp3^2;
                    tmp1=concat(pt,[nn1,t1,R0/tmp]);
                    ClipL=append(ClipL,tmp1);
                  );
                );
              );
            );
          );
        );
      );
    );
    te=length(Plt2);
    KukanL=[[1.0,te]];
    pt1=PhL;
    if(length(ClipL)>0,
      forall(1..(length(ClipL)),ii,
        tmp=ClipL_ii;
        pt=tmp_(1..2);
        nn=tmp_3;
        tt=nn+tmp_4;
        Rr=tmp_5;
        Flg=0;
        breakflg=0;
        forall(reverse(1..nn),jj,
          contflg=0;
          if(breakflg==0,
            ptq=PointonCurve(jj,pt1);
            if(Norm(pt-ptq)<Rr,
              contflg=1;
            );
            if(contflg==0,
              Flg=jj;
              breakflg=1;
              contflg=1;
            );
          );
        );
        if(Flg==0,
          t1=1;
        ,
          t1=Flg; t2=tt;
          hh=t2-t1;
          forall(1..10,
            hh=hh*0.5;
            ptq=PointonCurve(t1+hh,pt1);
            if(Norm(pt-ptq)<Rr,
              t2=t2-hh;
            ,
              t1=t1+hh;
            );
          );
        );
        Ku=[t1];
        Flg=0;
        breakflg=0;
        forall((nn+1)..te,jj,
          contflg=0;
          if(breakflg==0,
            ptq=PointonCurve(jj,pt1);
            if(Norm(pt-ptq)<Rr,
              contflg=1;
            );
            if(contflg==0,
              Flg=jj;
              breakflg=1;
              contflg=1;
            );
          );
        );
        if(Flg==0,
          t2=te;
        ,
          t1=tt; t2=Flg;
          hh=t2-t1;
          forall(1..10,
            hh=hh*0.5;
            ptq=PointonCurve(t1+hh,pt1);
            if(Norm(pt-ptq)<Rr,
              t1=t1+hh;
            ,
              t2=t2-hh;
            );
          );
        );
        Ku=append(Ku,t2);
        KukanL=Kukannozoku(Ku,KukanL);
	  );
    );
    Res=[];
    forall(1..(length(KukanL)),ii,
      tmp=KukanL_ii;
      t1=tmp_1; nn1=floor(t1);
      t2=tmp_2; nn2=floor(t2);
      PtL=[];
      if(t1-nn1<1-Eps,
        tmp=PointonCurve(t1,pt1);
        PtL=[tmp];
      );
      forall((nn1+1)..nn2,jj,
        tmp=PointonCurve(jj,pt1);
        PtL=append(PtL,tmp);
      );
      if(t2-nn2>Eps,
        tmp=PointonCurve(t2,pt1);
        PtL=append(PtL,tmp);
      );
      tmp=Listplot("",PtL,["nodata"]);
      Res=append(Res,tmp);
    );
    Allres=concat(Allres,Res);
  );
  Allres;
);
////%Makeskeletondata end////

////%Kukannozoku start////
Kukannozoku(Jokyo,KukanL):=(
  regional(Res,Eps,nn,ii,t1,t2,Ku,Flg,contflg,tmp,tmp1);
  Eps=10^(-6);
  nn=length(KukanL);
  t1=Jokyo_1; t2=Jokyo_2;
  tmp=KukanL_1;
  t1=max(t1,tmp_1);
  tmp=KukanL_nn;
  t2=min(t2,tmp_2);
  Res=[];
  Flg=0;
  contflg=0;
  forall(1..nn,ii,
    if(contflg==0,
      Ku=KukanL_ii;
      if(Flg==0,
        if(Ku_2<t1,
          Res=append(Res,Ku);
        ,
          Flg=1;
          if(Ku_1<t1-Eps, 
            tmp=[Ku_1,t1];
            Res=append(Res,tmp);
          );
          if(Ku_2>t2+Eps,
            tmp=[t2,Ku_2];
            Res=append(Res,tmp);
          );
        );
      ,
        if(Flg==1,
          if(Ku_2<t2,
            contflg=1;
          ,
            if(contflg==0,
              Flg=2;
              if(Ku_1<t2-Eps,
                Ku=[t2,Ku_2];
              );
              Res=append(Res,Ku);
            );
          );
        ,
          if(contflg==0,
            Res=append(Res,Ku);
          );
        );
      );
    );
  );
  Res;
);
////%Kukannozoku end////

////////////////// end of current skeleton//////////////

////%ProjcoordCurve start////
ProjcoordCurve(Curve):=(
  regional(SP,CP,ST,CT,Out,jj,pt,x,y,z,xz,yz,zz);
  SP=sin(PHI); CP=cos(PHI);
  ST=sin(THETA); CT=cos(THETA);
  Out=[];
  forall(1..(length(Curve)),jj,
    pt=Curve_jj;
    x=pt_1; y=pt_2; z=pt_3;
    xz=-x*SP+y*CP;
    yz=-x*CP*CT-y*SP*CT+z*ST;
    zz=x*CP*ST+y*SP*ST+z*CT;
    Out=append(Out,[xz,yz,zz]);
  );
  Out;
);
////%ProjcoordCurve end////

////%Divnohidhid start////
Divnohidhid(nm,dt3dorg,nvec):=Divnohidhid(nm,dt3dorg,nvec,[],["do"]);
Divnohidhid(nm,dt3dorg,nvec,optionorg,options2):=(
//help:Divnohidhid("1","sc3d1",nvec,["Num=100"],["Num=100","do"]);
  regional(name,dt3d,options,pvec,disp,nohid,hid,flg,tmp,tmp1,eqL);
  name="nh"+nm;
  options=optionorg;
  tmp=Divoptions(options);
  eqL=tmp_5;
  disp="Y";
  forall(eqL,
    tmp=Toupper(substring(#,0,1));
    if(tmp=="D",
      tmp=indexof(#,"=");
      disp=Toupper(substring(#,tmp,tmp+1));
      options=remove(options,[#]);
    );
  );
  if(isstring(dt3dorg),dt3d=parse(dt3dorg),dt3d=dt3dorg);
  pvec=[sin(THETA)*cos(PHI),sin(THETA)*sin(PHI),cos(THETA)];
  nohid=[];
  hid=[];
  flg=0;
  forall(1..(length(dt3d)-1),
    p1=dt3d_#;
    p2=dt3d_(#+1);
    tmp=assign(nvec,["x",p1_1,"y",p1_2,"z",p1_3]);
    tmp=parse(tmp);
    if(Dotprod(tmp,pvec)>0,
      if(flg==0 % flg==-1,
        nohid=append(nohid,[p1,p2]);
        flg=1;
      );
      if(flg==1,
        nohid_(length(nohid))=append(nohid_(length(nohid)),p2);
      );
    ,
      if(flg==0 % flg==1,
        hid=append(hid,[p1,p2]);
        flg=-1;
      );
      if(flg==-1,
        hid_(length(hid))=append(hid_(length(hid)),p2);
      );
    );      
  );
   if(disp=="Y",
    Changestyle3d([dt3dorg],["nodisp"]);
    forall(1..length(nohid),
      Spaceline(name+"nh"+text(#),nohid_#,options);
    );
    forall(1..length(hid),
      Spaceline(name+"h"+text(#),hid_#,options2);
    );
  );
  tmp1="[";
  forall(nohid,tmp1=tmp1+textformat(#,5)+",");
  tmp1=substring(tmp1,0,length(tmp1)-1)+"]";
  parse(name+"nh="+tmp1);
  tmp1="[";
  forall(hid,tmp1=tmp1+textformat(#,5)+",");
  tmp1=substring(tmp1,0,length(tmp1)-1)+"]";
  parse(name+"h="+tmp1);
  [nohid,hid];
);
////%Divnohidhid end////

////%Beziersurf start////
Beziersurf(nm,m,n,pL):=(
//help:Beziersurf("pt",2,2,pL);
  regional(p3dL,ptlistx,ptlilsty,ptlistz);
  factorial(n):=(
    regional(out);
    out=1;
    forall(1..n,
      out=out*#;
    );
    out;
  );
  Deffun("Comb(n,r)",[
  "regional(y)",
  "y=factorial(n)/(factorial(r)*factorial(n-r))",
  "y"
  ]);
  Deffun("Bterm(u,v,m,n,i,j)",[
  "regional(y)",
  "y=Comb(m,i)*u^i*(1-u)^(m-i)",
  "y=y*Comb(n,j)*v^j*(1-v)^(n-j)",
  "y"
  ]);
  Deffun("Ball(u,v,m,n,pL)",[
  "regional(y,ii,jj,tmp,tmp1)",
  "y=0",
  "forall(0..m,ii,
    forall(0..n,jj,
      tmp=(n+1)*ii+jj+1;
      tmp1=Op(tmp,pL);
      tmp1=tmp1*Bterm(u,v,m,n,ii,jj);
      y=y+tmp1;
    )
  )",
  "y"
  ]);
  if(ispoint(pL_1),
    p3dL=apply(pL,parse(text(#)+"3d"));
  ,
    p3dL=apply(pL,parse(#+"3d"));
  );
  ptlistx=apply(p3dL,#_1);
  ptlisty=apply(p3dL,#_2);
  ptlistz=apply(p3dL,#_3);
  Defvar(nm+"x",ptlistx);
  Defvar(nm+"y",ptlisty);
  Defvar(nm+"z",ptlistz);
  tmp=[
  "p",
  "x=Ball(U,V,2,2,"+nm+"x)",
  "y=Ball(U,V,2,2,"+nm+"y)",
  "z=Ball(U,V,2,2,"+nm+"z)",
  "U=[0,1]",
  "V=[0,1]"
  ];
  tmp;
);
////%Beziersurf end////

//help:end();
