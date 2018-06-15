if(key()=="?" % keydownlist()==[32],
  if(!isreal(NumTyped),NumTyped=0);
  if(NumTyped==0,
    DispStr="1:Figure 2:Parent 3:Parapara 4:Movie";
  );
  if(NumTyped==1,
    DispStr="(Shift+) T:Title P:ParaF S:Slide D:Digest";
  );
  if(NumTyped==2,
    DispStr="(Shift+) M:Meshlab";
  );
  if(NumTyped==3,
    DispStr="Ch 0:init 9:disp +:inc -:dec <:append >:remove";
  );
  drawtext(mouse().xy,DispStr,size->24);
  NumTyped=mod(NumTyped+1,4);
,
  NumTyped=0;  
);
if(key()=="1",//Mkfigure
  Viewtex();
  kc();
);
if(key()=="2",//Mkparent
  Viewparent();
);
if(key()=="3",//Flipbook(Parapara)
  Flipbook();
);
if(key()=="4",//Texmovie
  Texmovie();
  kc();
);
if(key()=="T",//Title
  Maketitle();
);
if(key()=="P",//ParaF
  Parafolder();
);
if(key()=="S",//Slide 
  Mkslides();
);
if(key()=="D",//Digest(Summary)
  Mkslidesummary();
);
if(key()=="M",//Meshlab
  Mkviewobj(OCNAME,OBJCMD,OCOPTION);
);

Dispchoice():=(
  if(islist(Ch),
    drawtext(mouse().xy,"Ch="+text(Ch)+" N="+text(ChNum),size->24,color->[0,0,1]);
  );
);
if(key()=="0",
  Ch=[];
  ChNum=1;
  Dispchoice();
);
if(key()=="9",
  Dispchoice();
);
if(key()=="+",
  ChNum=ChNum+1;
  Dispchoice();
);
if(key()=="-",
  ChNum=ChNum-1;
  Dispchoice();
);
if(key()=="<",
  if(length(select(Ch,#==ChNum))==0,
    Ch=append(Ch,ChNum);
    Ch=sort(Ch);
    ChNum=ChNum+1;
  );
  Dispchoice();
);
if(key()==">",
  if(length(Ch)>0,
    ChNum=Ch_(length(Ch));
    Ch=Remove(Ch,[ChNum]);
  );
  Dispchoice();
);