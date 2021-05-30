//  Copyright (C)  2021  Setsuo Takato, KETCindy Japan project team
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

// Library for learning   20210526

// グローバル変数
// LogData　学習のログデータ
// QuesDataHead　各問題の番号+問題+正解（StartQuestionで作成）
// QuesData　QuesdataHead+学生の解答+スコア+時間+採点回数（Makequesdataで作成）
// QuestNo　問題番号（Startquestionで1ずつ増やされる）
// Msgnew, Msgques, Msgsc　頻用メッセージの初期化（開始，出題，採点）
// Posnew Newsessionのメッセージ位置
// StartTime は内部的なグローバル変数

// フロー制御のためのグローバル変数
// newflg　セッション開始時は 1，開始処理の終了以降は 0
// confirmflg newsessionの際，確認ボタンが押されたら1
// quesflg, scoreflg, recordflg　各ボタンが押されたら1（初期値は 0，処理が終わったら 0 に戻す）
// quesgiven　問題が作成されたら 1
// quesnew　問題が作成してもよい場合は 1，そうでない場合は 0
// scorectr　採点回数のカウンタ
// scorefin　採点が１度でも済んだら 1

// Newsession(editno,noinput,pos (,size,studentL));　最初に実行
// Confirmstudent(st,Students)　stがStudentsに登録されているかをチェック
// Startlearning(stname)　LogData=stname+学習開始の日時データ
// Startquestion(question,correctanswer)　QuesDataHead=各問題の番号+問題+正解, QuesNo=+1
// Makequesdata(stans,stscore,ctr)　QuesData=QuesdataHead+解答+スコア+解答時間+回数
// Updatelog()　QuesNoが同じ場合はLogDataを更新，そうでなければ追加
// Dispquesno(pos (,size, rgb))　番号表示のデータを作成
// Displetterlist(msglist), Dispexprlist([msg1,...])　各msgが空でなければ表示
//　　msgは関数の内部で作成（表示はしない），フローで表示するために用いる
//　　形式：リスト [message, position (. size(12), color([0,0,0])] の単体かこれらのリスト
// Log2csv(dt)　logdataをcsv形式のリストにして返す
// Csvtext(fname)　csv形式のデータをファイルに保存

// 以下は，内部関数と不使用関数
// Getcurtime() 現在の年月日と時刻データを返す
// Counttime() 現在の時刻データを返す
// Returntime(data) counttimeのdataから時刻の通常データを返す
// Returndatetime(data) dataから年月日と時刻の通常データのリストを返す
// Endquestion(studentans,studentscore) 

/////  template flow ///////////
//  Id=51; Rec=59;
//Coorodinates([0.4,-0.1],[0,0.3],[-0.1,-0.4],16);
//if(newflg==1,
//  st=Newsession(Id,"",[-4,5.3],24);
//  quesnew=1;
//  quesgiven=0;
//);
//if(quesflg==1,
//  if(quesnew==1,
//    out=Makeques();
//    Ex=out_1; Ca=out_2;
//    Startquestion(Ex,Ca);
//    Subsedit(Rec,"");
//  );
//  quesflg=0;
//);
//if(scoreflg==1,
//  out=Scoring([-11,-1],24);
//  stans=out_1; score=out_2;
//  Makequesdata(stans,score);
//  scoreflg=0;
//);
//if(recordflg==1,
//  Updatelog();
//  Subsedit(Rec,LogData);
//  recordflg=0;
//);
//Displetterlist([Msgnew,Msgsc]);

LogData="";
QuesDataHead="";
QuesData="";
QuesNo=0;
StartTime=0;

newflg=1;//開始処理が終われば0
confirmflg=0;//確認
quesflg=0;//出題
scoreflg=0;//採点
scorefin=0;//採点が１度でもすれば 1
Scorectr=0;//採点回数のカウンタ
recordflg=0;//記録
quesgiven=0;//出題されているか
quesnew=0;//出題していいか
Msgnew=[];
Msgques=[];
Msgsc=[];

Coorodinates(mx,my,mo,sz):=(
//help:Coorodinates([0.4,-0.1],[0,0.3],[-0.1,-0.4],16);
  regional(tmp,tmp1,tmp2);
  draw([XMIN,0],[XMAX,0],color->[0,0,0]);
  draw([0,YMIN],[0,XMAX],color->[0,0,0]);
  drawtext([XMAX,0]+mx,"$x$",size->sz,align->"right");
  drawtext([0,YMAX]+my,"$y$",size->sz,align->"mid");
  drawtext([0,0]+mo,"O",size->sz,align->"right");
  tmp1=ceil(XMIN); tmp2=floor(XMAX);
  tmp=apply(remove(tmp1..tmp2,[0]),[#,text(#)]);
  tmp=flatten(tmp);
  Htickmark(tmp);
  tmp1=ceil(YMIN); tmp2=floor(YMAX);
  tmp=apply(remove(tmp1..tmp2,[0]),[#,text(#)]);
  tmp=flatten(tmp);
  Vtickmark(tmp);
);

Confirmstudent(st,students):=(
  regional(numL,nsL,nn,kk,nstr,out,tmp,tmp1);
  numL=apply(0..9,text(#));
  out="";
  nsL=[];
  forall(1..(length(students)),nn,
    tmp1=students_nn;
    nstr="";
    kk=1;
    while(kk<=length(tmp1),
      tmp=tmp1_(kk);
      if(contains(numL,tmp),
        nstr=nstr+tmp;
        kk=kk+1;
      ,
        kk=length(tmp1)+1;
      );
    );
    nsL=append(nsL,parse(nstr));
  );
  nstr="";
  kk=1;
  while(kk<=length(st),
    tmp=st_(kk);
    if(contains(numL,tmp),
      nstr=nstr+tmp;
      kk=kk+1;
    ,
      kk=length(st)+1;
    );
  );
  nn=parse(nstr);
  if(contains(nsL,nn),
    tmp=select(1..(length(nsL)),nsL_#==nn);
    tmp=tmp_1;
    out=students_tmp;
  ,
    out="";
  );
  out;
);

Startlearning(editno):=(
  regional(stname);
  //global LogData
  stname=Textedit(editno,"noname");
  LogData=stname+";;"+Getcurtime();
  LogData;
);

Newsession(editno,pos):=Newsession(editno,"",pos,18,[]);
Newsession(editno,Arg1,Arg2):=(
  if(islist(Arg1),
    Newsession(editno,"",Arg1,Arg2,[]);
  ,
    Newsession(editno,Arg1,Arg2,18,[]);
  );  
);
Newsession(editno,Arg1,Arg2,Arg3):=(
  if(islist(Arg3),
    Newsession(editno,"",Arg1,Arg2,18,Arg3);
  ,
    Newsession(editno,Arg1,Arg2,Arg3,[]);
  );  
);
Newsession(editno,noinput,pos,size,studentL):=(
  regional(st,msg,confok);
  Posnew=pos;
  Sizenew=size;
  confok=0;
  st=Textedit(editno,noinput);
  if(length(st)==0,
    st="";
    msg=["ID",pos,size,[1,0,0]];
  ,
    if(length(studentL)>0,
      st=Confirmstudent(st,studentL);
      if(length(st)>0,
        confok=1;
      ,
        msg=["ID?",pos,size,[1,0,0]];
      );
    ,
      confok=1;
    );
  );
  if(confok==1,
    Subsedit(editno,"ID="+st);
    msg=["$\Longleftarrow$",pos,size,[1,0,0]];
    if(confirmflg==1,
      Startlearning(editno);
      msg=["$\Longrightarrow$",pos,size,[1,0,0]];
      quesnew=1;
      quesgiven=0;
      newflg=0;
    );
  );
  Msgnew=msg;
  st;
);

Dispquesno(pos):=Dispquesno(pos,18,[0,0,0]);
Dispquesno(pos,size):=Dispquesno(pos,size,[0,0,0]);
Dispquesno(pos,size,rgb):=(
  regional(msg);
  msg=[Assign("N",["N",QuesNo]),pos,size,rgb];
  msg;
);

Startquestion(question,correct):=(
  regional(no,ex,ca,msg);
  StartTime=Counttime();
  QuesNo=QuesNo+1; //210424
  Msgnew=Dispquesno(Posnew,Sizenew,[0,0,0]);
  Msgsc=[];
  no=text(QuesNo);
  Scorectr=1;
  ex=question;
  if(!isstring(ex),ex=text(ex));
  ca=correct;
  if(!isstring(ca),ca=text(ex));
  QuesDataHead=no+";;"+ex+";;"+ca;
  quesgiven=1;
  graphflg=0;
  quesnew=0;
  scorefin=0;
  QuesDataHead;
);

Makequesdata(stans,stscore):=(
  regional(ans,score,tm);
  ans=stans;
  if(!isstring(ans),ans=text(ans));
  score=stscore;
  if(!isstring(score),score=text(score));
  QuesData=QuesDataHead+";;"+ans+";;"+score;
  tm=Counttime()-StartTime;
  QuesData=QuesData+";;"+text(tm);
  if(Scorectr>0,
    QuesData=QuesData+";;"+text(Scorectr);
  );
  quesnew=1;
  scorefin=1;
  Scorectr=Scorectr+1;
  QuesData;
);

Endquestion(studentans,studentscore):=(
  regional(ans,score,tm);
  // global QuesData,StartTime, EndQues
  if(EndQues==0,
    ans=studentans;
    if(!isstring(ans),ans=text(ans));
    score=studentscore;
    if(!isstring(score),score=text(score));
    QuesData=QuesData+";;"+ans+";;"+score;
    tm=Counttime()-StartTime;
    QuesData=QuesData+";;"+text(tm);
    EndQues=1;
  );
);

Updatelog():=(
  regional(tmp,tmp1,tmp2);
  //global LogData,QuesData
  if(length(QuesData)>0,
    tmp=tokenize(LogData,"||");
    if(length(tmp)>1,
      tmp1=tmp_(-1);
      tmp2=tmp_(1..(length(tmp)-1));
      tmp=tokenize(tmp1,";;");
      tmp=tmp_1;
      if(tmp==QuesNo, //210425a
        LogData=tmp2_1;
        forall(2..(length(tmp2)),
          LogData=LogData+"||"+tmp2_#;
        );
      );
    );
    LogData=LogData+"||"+QuesData;
  );
  LogData;
);

Displetters(msgLorg):=(
  regional(msgL,pos,str,size,color);
  msgL=msgLorg;
  if(length(msgL)>0,
    if(isstring(msgL_1),msgL=[msgL]);
    forall(msgL,
      pos=#_2;
      str=#_1;
      if(length(#)>2,size=#_3,size=16);
      if(length(#)>3,color=#_4,color=[0,0,0]); 
      drawtext(pos,str,size->size,color->color);
    );
  );
);

Dispexprs(msgLorg):=(
  regional(msgL,pos,str,size,color);
  msgL=msgLorg;
  if(length(msgL)>0,
    if(isstring(msgL_1),msgL=[msgL]);
    forall(msgL,
      pos=#_2;
      str="$"+#_1+"$";
      if(length(#)>2,size=#_3,size=16);
      if(length(#)>3,color=#_4,color=[0,0,0]);    
      drawtext(pos,str,size->size,color->color);
    );
  );
);

Displetterlist(list):=(
  forall(list,
    Displetters(#);
  );
);

Dispexprlist(list):=(
  forall(list,
    Dispexprs(#);
  );
);

Getcurtime():=Getcurtime(date(),time());
Getcurtime(ymd,hms):=(
  regional(out,tmp,tmp1);
  out=text(ymd_1*10000+ymd_2*100+ymd_3);
  tmp=text(hms_1*3600+hms_2*60+hms_3);
  tmp1=substring("0000000",0,5-length(tmp));
  out=out+tmp1+tmp;
  out;
);

Counttime():=(
  regional(tmp,tmp1);
  tmp=time();
  tmp_1*3600+tmp_2*60+tmp_3;
);

Returndatetime(data):=(
  regional(dstr,dt,tm,tmp);
  dstr=text(data);
  dt=substring(dstr,0,8);
  tmp=substring(dstr,8,length(dstr));
  tm=Returntime(tmp);
  [dt,tm];
);

Returntime(timedata):=(
  regional(tmp,tmp1,out);
  tmp=timedata;
  if(isstring(tmp),tmp=parse(tmp));
  out=[floor(tmp/3600)];
  tmp=mod(tmp,3600);
  out=append(out,floor(tmp/60));
  tmp=mod(tmp,60);
  tmp1=append(out,tmp);
  out="";
  forall(tmp1,
    out=out+text(#)+":";
  );
  out=substring(out,0,length(out)-1);
  out;
);

Log2csv(dt):=(
  regional(cL,dL,out,nn,tmp,tmp1,tmp2);
  cL=[];
  dL=tokenize(dt,"||");
  tmp=dL_1;
  tmp1=tokenize(tmp,";;");
  tmp=Returndatetime(tmp1_2);
  out=tmp1_1+","+tmp_1+","+tmp_2;
  forall(2..(length(dL)),nn,
    tmp1=tokenize(dL_nn,";;");
    tmp2=text(tmp1_1)+",";
    forall(2..(length(tmp1)),
      tmp=tmp1_#;
      if(!isstring(tmp),tmp=text(tmp));
      if(indexof(tmp,",")>0,tmp=Dqq(tmp));
      tmp2=tmp2+tmp;
      if(#<length(tmp1),tmp2=tmp2+",");
    );
    out=out+","+tmp2;
  );
  out;
);

Csvtext():=Csvtext("alltext");
Csvtext(fname):=(
  regional(tmp,tmp1,tL,numL,tnL,fid);
  tmp=allelements();
  tmp1=allpoints();
  tL=remove(tmp,tmp1);
  numL=apply(tL,replace(#.name,"Text",""));
  numL=apply(numL,replace(#,"''",".2"));
  numL=apply(numL,replace(#,"'",".1"));
  numL=apply(numL,if(length(#)==0,"-1",#));
  numL=apply(numL,parse(#));
  tnL=apply(1..(length(numL)),
     [numL_#,inspect(tL_#,"name"),inspect(tL_#,"text.text")]);
  tnL=sort(tnL,[#_1]);
  fid=openfile(fname+".csv");
  forall(tnL,
   println(fid,#_1+","+#_2+","+#_3);
  );
  closefile(fid);
  println("generate "+fname+".csv");
);
