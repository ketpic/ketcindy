// 08.07.08  PHI,THETA,FocusPoint,EyePoint;
// 08.08.08
// 08.08.31
// 08.09.18
// 09.10.09  ASSIGNLIST
// 09.12.25  SCALING
// 10.04.16  TEXFOR
// 13.05.19 funcprot(0)
// 13.03.05  MARKLEN instead of MEMORI

function Ketinit()
   global THISVERSION
   global TenSize TenSizeInit Wfile XMIN XMAX YMIN YMAX
   global  XNAME XPOS YNAME YPOS ONAME OPOS ARROWSIZE
   global  ULEN MilliIn PenThick PenThickInit ZIKU
   global  MEMORI MEMORIInit MEMORINow GENTEN
   global  MARKLEN MARKLENInit MARKLENNow
   global  YaSize YaAngle YaPosition YaThick YaStyle
   global  PHI THETA FocusPoint EyePoint ASSIGNLIST
   global  SCALEX SCALEY LOGX LOGY TEXFORLEVEL TEXFORLAST
   funcprot(0); // 2013.05.19
   Setversion();
   XMIN=-5 ;XMAX=5;
   YMIN=-5 ; YMAX=5;
   ZIKU='line'; ARROWSIZE=1;
   XNAME='$x$' ; XPOS='e';
   YNAME='$y$' ; YPOS='n';
   ONAME='O' ; OPOS='sw';
   ULEN='1cm';
   MilliIn=1/2.54*1000;
   PenThick=round(MilliIn*0.02);
   PenThickInit=PenThick;
   TenSizeInit=0.02;
   TenSize=TenSizeInit;
   Wfile='default';
   MEMORI=0.05;
   MEMORIInit=MEMORI;
   MEMORINow=MEMORI;
   MARKLEN=0.05;
   MARKLENInit=MARKLEN;
   MARKLENNow=MARKLEN;
   GENTEN=[0,0];
   YaSize=1; YaAngle=18; YaPosition=1;
   YaThick=1; YaStyle='tf';
   PHI=30*%pi/180;
   THETA=60*%pi/180;
   FocusPoint=[0,0,0];
   EyePoint=[5,5,5];
   ASSIGNLIST=list('`',char(39));
   SCALEX=1;
   SCALEY=1;
   LOGX=0;
   LOGY=0;
   TEXFORLEVEL=0;
   TEXFORLAST=list();
 endfunction;
 