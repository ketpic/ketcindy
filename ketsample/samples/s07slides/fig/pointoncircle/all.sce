//date time=2017/8/19 10:55:49

cd('/Users/takatoosetsuo/ketcindy/ketsample/samples/s07slides/fig');
Ketlib=lib('/Users/takatoosetsuo/ketcindy/ketlib/ketpicscifiles6');
Ketinit();
disp('KETpic '+ThisVersion())
Fnametex='pointoncircle/p001.tex';
Fnamesci='pointoncircle/p001.sce';
Fnamescibody='figs0706animatebody.sce';
Fnameout='figs0706animate.txt';
pi=%pi; i=%i;
arccos=acos; arcsin=asin; arctan=atan;

Setwindow([-2.5,2.5], [-2.5,2.5]);
Assignadd('pi',%pi);
Assignadd('XMIN',Xmin());
Assignadd('XMAX',Xmax());
Assignadd('YMIN',Ymin());
Assignadd('YMAX',Ymax());
A=[0,-4]; Assignrep('A',[0,-4]);
B=[6.28319,-3.96979]; Assignrep('B',[6.28319,-3.96979]);
C=[0.83543,-3.99598]; Assignrep('C',[0.83543,-3.99598]);
mdbw1=evstr('[1,-0.2]');  Assignrep('mdbw1',[1,-0.2]);
cr1=Circledata([[0,0],[2,0]]);
sg1=Listplot([[0,0],[2,0]]);
pt1=Pointdata([2,0]);
bw1=Bowdata([0,0],[2,0],1,0.3);
PtL=list(A,B,C);
GrL=list();
//if length(fileinfo(Fnamescibody))>0
//  Gbdy=ReadfromCindy(Fnamescibody);
//  execstr(Gbdy)
//end;

//Windisp(GrL,'c');

if 1==1 then

Openfile('/Users/takatoosetsuo/ketcindy/ketsample/samples/s07slides/fig/pointoncircle/p001.tex','1cm');
  Fontsize('s');
  Drwline(cr1);
  Letter([2,0],"se","$2$");
  Setcolor("red");
  Drwline(sg1);
  Setcolor("black");
  Setpen(0.12);
  Drwpt(list(pt1));
  Setpen(1);
  Letter([1,-0.2],"c","$2$");
  Drwline(bw1);
  Letter([2.2,0],"c","$\mathrm{P}$");
Closefile('1');

end;


Setwindow([-2.5,2.5], [-2.5,2.5]);
Assignadd('pi',%pi);
Assignadd('XMIN',Xmin());
Assignadd('XMAX',Xmax());
Assignadd('YMIN',Ymin());
Assignadd('YMAX',Ymax());
A=[0,-4]; Assignrep('A',[0,-4]);
B=[6.28319,-3.96979]; Assignrep('B',[6.28319,-3.96979]);
C=[0.83543,-3.99598]; Assignrep('C',[0.83543,-3.99598]);
mdbw1=evstr('[1.01832,0.05497]');  Assignrep('mdbw1',[1.01832,0.05497]);
cr1=Circledata([[0,0],[2,0]]);
sg1=Listplot([[0,0],[1.93717,0.49738]]);
pt1=Pointdata([1.93717,0.49738]);
bw1=Bowdata([0,0],[1.93717,0.49738],1,0.3);
PtL=list(A,B,C);
GrL=list();
//if length(fileinfo(Fnamescibody))>0
//  Gbdy=ReadfromCindy(Fnamescibody);
//  execstr(Gbdy)
//end;

//Windisp(GrL,'c');

if 1==1 then

Openfile('/Users/takatoosetsuo/ketcindy/ketsample/samples/s07slides/fig/pointoncircle/p002.tex','1cm');
  Fontsize('s');
  Drwline(cr1);
  Letter([2,0],"se","$2$");
  Setcolor("red");
  Drwline(sg1);
  Setcolor("black");
  Setpen(0.12);
  Drwpt(list(pt1));
  Setpen(1);
  Letter([1.02,0.05],"c","$2$");
  Drwline(bw1);
  Letter([2.13,0.55],"c","$\mathrm{P}$");
Closefile('1');

end;


Setwindow([-2.5,2.5], [-2.5,2.5]);
Assignadd('pi',%pi);
Assignadd('XMIN',Xmin());
Assignadd('XMAX',Xmax());
Assignadd('YMIN',Ymin());
Assignadd('YMAX',Ymax());
A=[0,-4]; Assignrep('A',[0,-4]);
B=[6.28319,-3.96979]; Assignrep('B',[6.28319,-3.96979]);
C=[0.83543,-3.99598]; Assignrep('C',[0.83543,-3.99598]);
mdbw1=evstr('[0.97266,0.30649]');  Assignrep('mdbw1',[0.97266,0.30649]);
cr1=Circledata([[0,0],[2,0]]);
sg1=Listplot([[0,0],[1.75261,0.96351]]);
pt1=Pointdata([1.75261,0.96351]);
bw1=Bowdata([0,0],[1.75261,0.96351],1,0.3);
PtL=list(A,B,C);
GrL=list();
//if length(fileinfo(Fnamescibody))>0
//  Gbdy=ReadfromCindy(Fnamescibody);
//  execstr(Gbdy)
//end;

//Windisp(GrL,'c');

if 1==1 then

Openfile('/Users/takatoosetsuo/ketcindy/ketsample/samples/s07slides/fig/pointoncircle/p003.tex','1cm');
  Fontsize('s');
  Drwline(cr1);
  Letter([2,0],"se","$2$");
  Setcolor("red");
  Drwline(sg1);
  Setcolor("black");
  Setpen(0.12);
  Drwpt(list(pt1));
  Setpen(1);
  Letter([0.97,0.31],"c","$2$");
  Drwline(bw1);
  Letter([1.93,1.06],"c","$\mathrm{P}$");
Closefile('1');

end;


Setwindow([-2.5,2.5], [-2.5,2.5]);
Assignadd('pi',%pi);
Assignadd('XMIN',Xmin());
Assignadd('XMAX',Xmax());
Assignadd('YMIN',Ymin());
Assignadd('YMAX',Ymax());
A=[0,-4]; Assignrep('A',[0,-4]);
B=[6.28319,-3.96979]; Assignrep('B',[6.28319,-3.96979]);
C=[0.83543,-3.99598]; Assignrep('C',[0.83543,-3.99598]);
mdbw1=evstr('[0.86588,0.53875]');  Assignrep('mdbw1',[0.86588,0.53875]);
cr1=Circledata([[0,0],[2,0]]);
sg1=Listplot([[0,0],[1.45794,1.36909]]);
pt1=Pointdata([1.45794,1.36909]);
bw1=Bowdata([0,0],[1.45794,1.36909],1,0.3);
PtL=list(A,B,C);
GrL=list();
//if length(fileinfo(Fnamescibody))>0
//  Gbdy=ReadfromCindy(Fnamescibody);
//  execstr(Gbdy)
//end;

//Windisp(GrL,'c');

if 1==1 then

Openfile('/Users/takatoosetsuo/ketcindy/ketsample/samples/s07slides/fig/pointoncircle/p004.tex','1cm');
  Fontsize('s');
  Drwline(cr1);
  Letter([2,0],"se","$2$");
  Setcolor("red");
  Drwline(sg1);
  Setcolor("black");
  Setpen(0.12);
  Drwpt(list(pt1));
  Setpen(1);
  Letter([0.87,0.54],"c","$2$");
  Drwline(bw1);
  Letter([1.6,1.51],"c","$\mathrm{P}$");
Closefile('1');

end;


Setwindow([-2.5,2.5], [-2.5,2.5]);
Assignadd('pi',%pi);
Assignadd('XMIN',Xmin());
Assignadd('XMAX',Xmax());
Assignadd('YMIN',Ymin());
Assignadd('YMAX',Ymax());
A=[0,-4]; Assignrep('A',[0,-4]);
B=[6.28319,-3.96979]; Assignrep('B',[6.28319,-3.96979]);
C=[0.83543,-3.99598]; Assignrep('C',[0.83543,-3.99598]);
mdbw1=evstr('[0.70469,0.73716]');  Assignrep('mdbw1',[0.70469,0.73716]);
cr1=Circledata([[0,0],[2,0]]);
sg1=Listplot([[0,0],[1.07165,1.68866]]);
pt1=Pointdata([1.07165,1.68866]);
bw1=Bowdata([0,0],[1.07165,1.68866],1,0.3);
PtL=list(A,B,C);
GrL=list();
//if length(fileinfo(Fnamescibody))>0
//  Gbdy=ReadfromCindy(Fnamescibody);
//  execstr(Gbdy)
//end;

//Windisp(GrL,'c');

if 1==1 then

Openfile('/Users/takatoosetsuo/ketcindy/ketsample/samples/s07slides/fig/pointoncircle/p005.tex','1cm');
  Fontsize('s');
  Drwline(cr1);
  Letter([2,0],"se","$2$");
  Setcolor("red");
  Drwline(sg1);
  Setcolor("black");
  Setpen(0.12);
  Drwpt(list(pt1));
  Setpen(1);
  Letter([0.7,0.74],"c","$2$");
  Drwline(bw1);
  Letter([1.18,1.86],"c","$\mathrm{P}$");
Closefile('1');

end;


Setwindow([-2.5,2.5], [-2.5,2.5]);
Assignadd('pi',%pi);
Assignadd('XMIN',Xmin());
Assignadd('XMAX',Xmax());
Assignadd('YMIN',Ymin());
Assignadd('YMAX',Ymax());
A=[0,-4]; Assignrep('A',[0,-4]);
B=[6.28319,-3.96979]; Assignrep('B',[6.28319,-3.96979]);
C=[0.83543,-3.99598]; Assignrep('C',[0.83543,-3.99598]);
mdbw1=evstr('[0.49923,0.88925]');  Assignrep('mdbw1',[0.49923,0.88925]);
cr1=Circledata([[0,0],[2,0]]);
sg1=Listplot([[0,0],[0.61803,1.90211]]);
pt1=Pointdata([0.61803,1.90211]);
bw1=Bowdata([0,0],[0.61803,1.90211],1,0.3);
PtL=list(A,B,C);
GrL=list();
//if length(fileinfo(Fnamescibody))>0
//  Gbdy=ReadfromCindy(Fnamescibody);
//  execstr(Gbdy)
//end;

//Windisp(GrL,'c');

if 1==1 then

Openfile('/Users/takatoosetsuo/ketcindy/ketsample/samples/s07slides/fig/pointoncircle/p006.tex','1cm');
  Fontsize('s');
  Drwline(cr1);
  Letter([2,0],"se","$2$");
  Setcolor("red");
  Drwline(sg1);
  Setcolor("black");
  Setpen(0.12);
  Drwpt(list(pt1));
  Setpen(1);
  Letter([0.5,0.89],"c","$2$");
  Drwline(bw1);
  Letter([0.68,2.09],"c","$\mathrm{P}$");
Closefile('1');

end;


Setwindow([-2.5,2.5], [-2.5,2.5]);
Assignadd('pi',%pi);
Assignadd('XMIN',Xmin());
Assignadd('XMAX',Xmax());
Assignadd('YMIN',Ymin());
Assignadd('YMAX',Ymax());
A=[0,-4]; Assignrep('A',[0,-4]);
B=[6.28319,-3.96979]; Assignrep('B',[6.28319,-3.96979]);
C=[0.83543,-3.99598]; Assignrep('C',[0.83543,-3.99598]);
mdbw1=evstr('[0.2624,0.98547]');  Assignrep('mdbw1',[0.2624,0.98547]);
cr1=Circledata([[0,0],[2,0]]);
sg1=Listplot([[0,0],[0.12558,1.99605]]);
pt1=Pointdata([0.12558,1.99605]);
bw1=Bowdata([0,0],[0.12558,1.99605],1,0.3);
PtL=list(A,B,C);
GrL=list();
//if length(fileinfo(Fnamescibody))>0
//  Gbdy=ReadfromCindy(Fnamescibody);
//  execstr(Gbdy)
//end;

//Windisp(GrL,'c');

if 1==1 then

Openfile('/Users/takatoosetsuo/ketcindy/ketsample/samples/s07slides/fig/pointoncircle/p007.tex','1cm');
  Fontsize('s');
  Drwline(cr1);
  Letter([2,0],"se","$2$");
  Setcolor("red");
  Drwline(sg1);
  Setcolor("black");
  Setpen(0.12);
  Drwpt(list(pt1));
  Setpen(1);
  Letter([0.26,0.99],"c","$2$");
  Drwline(bw1);
  Letter([0.14,2.2],"c","$\mathrm{P}$");
Closefile('1');

end;


Setwindow([-2.5,2.5], [-2.5,2.5]);
Assignadd('pi',%pi);
Assignadd('XMIN',Xmin());
Assignadd('XMAX',Xmax());
Assignadd('YMIN',Ymin());
Assignadd('YMAX',Ymax());
A=[0,-4]; Assignrep('A',[0,-4]);
B=[6.28319,-3.96979]; Assignrep('B',[6.28319,-3.96979]);
C=[0.83543,-3.99598]; Assignrep('C',[0.83543,-3.99598]);
mdbw1=evstr('[0.00908,1.01976]');  Assignrep('mdbw1',[0.00908,1.01976]);
cr1=Circledata([[0,0],[2,0]]);
sg1=Listplot([[0,0],[-0.37476,1.96457]]);
pt1=Pointdata([-0.37476,1.96457]);
bw1=Bowdata([0,0],[-0.37476,1.96457],1,0.3);
PtL=list(A,B,C);
GrL=list();
//if length(fileinfo(Fnamescibody))>0
//  Gbdy=ReadfromCindy(Fnamescibody);
//  execstr(Gbdy)
//end;

//Windisp(GrL,'c');

if 1==1 then

Openfile('/Users/takatoosetsuo/ketcindy/ketsample/samples/s07slides/fig/pointoncircle/p008.tex','1cm');
  Fontsize('s');
  Drwline(cr1);
  Letter([2,0],"se","$2$");
  Setcolor("red");
  Drwline(sg1);
  Setcolor("black");
  Setpen(0.12);
  Drwpt(list(pt1));
  Setpen(1);
  Letter([0.01,1.02],"c","$2$");
  Drwline(bw1);
  Letter([-0.41,2.16],"c","$\mathrm{P}$");
Closefile('1');

end;


Setwindow([-2.5,2.5], [-2.5,2.5]);
Assignadd('pi',%pi);
Assignadd('XMIN',Xmin());
Assignadd('XMAX',Xmax());
Assignadd('YMIN',Ymin());
Assignadd('YMAX',Ymax());
A=[0,-4]; Assignrep('A',[0,-4]);
B=[6.28319,-3.96979]; Assignrep('B',[6.28319,-3.96979]);
C=[0.83543,-3.99598]; Assignrep('C',[0.83543,-3.99598]);
mdbw1=evstr('[-0.24481,0.98998]');  Assignrep('mdbw1',[-0.24481,0.98998]);
cr1=Circledata([[0,0],[2,0]]);
sg1=Listplot([[0,0],[-0.85156,1.80965]]);
pt1=Pointdata([-0.85156,1.80965]);
bw1=Bowdata([0,0],[-0.85156,1.80965],1,0.3);
PtL=list(A,B,C);
GrL=list();
//if length(fileinfo(Fnamescibody))>0
//  Gbdy=ReadfromCindy(Fnamescibody);
//  execstr(Gbdy)
//end;

//Windisp(GrL,'c');

if 1==1 then

Openfile('/Users/takatoosetsuo/ketcindy/ketsample/samples/s07slides/fig/pointoncircle/p009.tex','1cm');
  Fontsize('s');
  Drwline(cr1);
  Letter([2,0],"se","$2$");
  Setcolor("red");
  Drwline(sg1);
  Setcolor("black");
  Setpen(0.12);
  Drwpt(list(pt1));
  Setpen(1);
  Letter([-0.24,0.99],"c","$2$");
  Drwline(bw1);
  Letter([-0.94,1.99],"c","$\mathrm{P}$");
Closefile('1');

end;


Setwindow([-2.5,2.5], [-2.5,2.5]);
Assignadd('pi',%pi);
Assignadd('XMIN',Xmin());
Assignadd('XMAX',Xmax());
Assignadd('YMIN',Ymin());
Assignadd('YMAX',Ymax());
A=[0,-4]; Assignrep('A',[0,-4]);
B=[6.28319,-3.96979]; Assignrep('B',[6.28319,-3.96979]);
C=[0.83543,-3.99598]; Assignrep('C',[0.83543,-3.99598]);
mdbw1=evstr('[-0.48332,0.898]');  Assignrep('mdbw1',[-0.48332,0.898]);
cr1=Circledata([[0,0],[2,0]]);
sg1=Listplot([[0,0],[-1.27485,1.54103]]);
pt1=Pointdata([-1.27485,1.54103]);
bw1=Bowdata([0,0],[-1.27485,1.54103],1,0.3);
PtL=list(A,B,C);
GrL=list();
//if length(fileinfo(Fnamescibody))>0
//  Gbdy=ReadfromCindy(Fnamescibody);
//  execstr(Gbdy)
//end;

//Windisp(GrL,'c');

if 1==1 then

Openfile('/Users/takatoosetsuo/ketcindy/ketsample/samples/s07slides/fig/pointoncircle/p010.tex','1cm');
  Fontsize('s');
  Drwline(cr1);
  Letter([2,0],"se","$2$");
  Setcolor("red");
  Drwline(sg1);
  Setcolor("black");
  Setpen(0.12);
  Drwpt(list(pt1));
  Setpen(1);
  Letter([-0.48,0.9],"c","$2$");
  Drwline(bw1);
  Letter([-1.4,1.7],"c","$\mathrm{P}$");
Closefile('1');

end;


Setwindow([-2.5,2.5], [-2.5,2.5]);
Assignadd('pi',%pi);
Assignadd('XMIN',Xmin());
Assignadd('XMAX',Xmax());
Assignadd('YMIN',Ymin());
Assignadd('YMAX',Ymax());
A=[0,-4]; Assignrep('A',[0,-4]);
B=[6.28319,-3.96979]; Assignrep('B',[6.28319,-3.96979]);
C=[0.83543,-3.99598]; Assignrep('C',[0.83543,-3.99598]);
mdbw1=evstr('[-0.69146,0.74959]');  Assignrep('mdbw1',[-0.69146,0.74959]);
cr1=Circledata([[0,0],[2,0]]);
sg1=Listplot([[0,0],[-1.61803,1.17557]]);
pt1=Pointdata([-1.61803,1.17557]);
bw1=Bowdata([0,0],[-1.61803,1.17557],1,0.3);
PtL=list(A,B,C);
GrL=list();
//if length(fileinfo(Fnamescibody))>0
//  Gbdy=ReadfromCindy(Fnamescibody);
//  execstr(Gbdy)
//end;

//Windisp(GrL,'c');

if 1==1 then

Openfile('/Users/takatoosetsuo/ketcindy/ketsample/samples/s07slides/fig/pointoncircle/p011.tex','1cm');
  Fontsize('s');
  Drwline(cr1);
  Letter([2,0],"se","$2$");
  Setcolor("red");
  Drwline(sg1);
  Setcolor("black");
  Setpen(0.12);
  Drwpt(list(pt1));
  Setpen(1);
  Letter([-0.69,0.75],"c","$2$");
  Drwline(bw1);
  Letter([-1.78,1.29],"c","$\mathrm{P}$");
Closefile('1');

end;


Setwindow([-2.5,2.5], [-2.5,2.5]);
Assignadd('pi',%pi);
Assignadd('XMIN',Xmin());
Assignadd('XMAX',Xmax());
Assignadd('YMIN',Ymin());
Assignadd('YMAX',Ymax());
A=[0,-4]; Assignrep('A',[0,-4]);
B=[6.28319,-3.96979]; Assignrep('B',[6.28319,-3.96979]);
C=[0.83543,-3.99598]; Assignrep('C',[0.83543,-3.99598]);
mdbw1=evstr('[-0.85615,0.55408]');  Assignrep('mdbw1',[-0.85615,0.55408]);
cr1=Circledata([[0,0],[2,0]]);
sg1=Listplot([[0,0],[-1.85955,0.73625]]);
pt1=Pointdata([-1.85955,0.73625]);
bw1=Bowdata([0,0],[-1.85955,0.73625],1,0.3);
PtL=list(A,B,C);
GrL=list();
//if length(fileinfo(Fnamescibody))>0
//  Gbdy=ReadfromCindy(Fnamescibody);
//  execstr(Gbdy)
//end;

//Windisp(GrL,'c');

if 1==1 then

Openfile('/Users/takatoosetsuo/ketcindy/ketsample/samples/s07slides/fig/pointoncircle/p012.tex','1cm');
  Fontsize('s');
  Drwline(cr1);
  Letter([2,0],"se","$2$");
  Setcolor("red");
  Drwline(sg1);
  Setcolor("black");
  Setpen(0.12);
  Drwpt(list(pt1));
  Setpen(1);
  Letter([-0.86,0.55],"c","$2$");
  Drwline(bw1);
  Letter([-2.05,0.81],"c","$\mathrm{P}$");
Closefile('1');

end;


Setwindow([-2.5,2.5], [-2.5,2.5]);
Assignadd('pi',%pi);
Assignadd('XMIN',Xmin());
Assignadd('XMAX',Xmax());
Assignadd('YMIN',Ymin());
Assignadd('YMAX',Ymax());
A=[0,-4]; Assignrep('A',[0,-4]);
B=[6.28319,-3.96979]; Assignrep('B',[6.28319,-3.96979]);
C=[0.83543,-3.99598]; Assignrep('C',[0.83543,-3.99598]);
mdbw1=evstr('[-0.96705,0.32376]');  Assignrep('mdbw1',[-0.96705,0.32376]);
cr1=Circledata([[0,0],[2,0]]);
sg1=Listplot([[0,0],[-1.98423,0.25067]]);
pt1=Pointdata([-1.98423,0.25067]);
bw1=Bowdata([0,0],[-1.98423,0.25067],1,0.3);
PtL=list(A,B,C);
GrL=list();
//if length(fileinfo(Fnamescibody))>0
//  Gbdy=ReadfromCindy(Fnamescibody);
//  execstr(Gbdy)
//end;

//Windisp(GrL,'c');

if 1==1 then

Openfile('/Users/takatoosetsuo/ketcindy/ketsample/samples/s07slides/fig/pointoncircle/p013.tex','1cm');
  Fontsize('s');
  Drwline(cr1);
  Letter([2,0],"se","$2$");
  Setcolor("red");
  Drwline(sg1);
  Setcolor("black");
  Setpen(0.12);
  Drwpt(list(pt1));
  Setpen(1);
  Letter([-0.97,0.32],"c","$2$");
  Drwline(bw1);
  Letter([-2.18,0.28],"c","$\mathrm{P}$");
Closefile('1');

end;


Setwindow([-2.5,2.5], [-2.5,2.5]);
Assignadd('pi',%pi);
Assignadd('XMIN',Xmin());
Assignadd('XMAX',Xmax());
Assignadd('YMIN',Ymin());
Assignadd('YMAX',Ymax());
A=[0,-4]; Assignrep('A',[0,-4]);
B=[6.28319,-3.96979]; Assignrep('B',[6.28319,-3.96979]);
C=[0.83543,-3.99598]; Assignrep('C',[0.83543,-3.99598]);
mdbw1=evstr('[-1.01718,0.07309]');  Assignrep('mdbw1',[-1.01718,0.07309]);
cr1=Circledata([[0,0],[2,0]]);
sg1=Listplot([[0,0],[-1.98423,-0.25067]]);
pt1=Pointdata([-1.98423,-0.25067]);
bw1=Bowdata([0,0],[-1.98423,-0.25067],1,0.3);
PtL=list(A,B,C);
GrL=list();
//if length(fileinfo(Fnamescibody))>0
//  Gbdy=ReadfromCindy(Fnamescibody);
//  execstr(Gbdy)
//end;

//Windisp(GrL,'c');

if 1==1 then

Openfile('/Users/takatoosetsuo/ketcindy/ketsample/samples/s07slides/fig/pointoncircle/p014.tex','1cm');
  Fontsize('s');
  Drwline(cr1);
  Letter([2,0],"se","$2$");
  Setcolor("red");
  Drwline(sg1);
  Setcolor("black");
  Setpen(0.12);
  Drwpt(list(pt1));
  Setpen(1);
  Letter([-1.02,0.07],"c","$2$");
  Drwline(bw1);
  Letter([-2.18,-0.28],"c","$\mathrm{P}$");
Closefile('1');

end;


Setwindow([-2.5,2.5], [-2.5,2.5]);
Assignadd('pi',%pi);
Assignadd('XMIN',Xmin());
Assignadd('XMAX',Xmax());
Assignadd('YMIN',Ymin());
Assignadd('YMAX',Ymax());
A=[0,-4]; Assignrep('A',[0,-4]);
B=[6.28319,-3.96979]; Assignrep('B',[6.28319,-3.96979]);
C=[0.83543,-3.99598]; Assignrep('C',[0.83543,-3.99598]);
mdbw1=evstr('[-1.0034,-0.18217]');  Assignrep('mdbw1',[-1.0034,-0.18217]);
cr1=Circledata([[0,0],[2,0]]);
sg1=Listplot([[0,0],[-1.85955,-0.73625]]);
pt1=Pointdata([-1.85955,-0.73625]);
bw1=Bowdata([0,0],[-1.85955,-0.73625],1,0.3);
PtL=list(A,B,C);
GrL=list();
//if length(fileinfo(Fnamescibody))>0
//  Gbdy=ReadfromCindy(Fnamescibody);
//  execstr(Gbdy)
//end;

//Windisp(GrL,'c');

if 1==1 then

Openfile('/Users/takatoosetsuo/ketcindy/ketsample/samples/s07slides/fig/pointoncircle/p015.tex','1cm');
  Fontsize('s');
  Drwline(cr1);
  Letter([2,0],"se","$2$");
  Setcolor("red");
  Drwline(sg1);
  Setcolor("black");
  Setpen(0.12);
  Drwpt(list(pt1));
  Setpen(1);
  Letter([-1,-0.18],"c","$2$");
  Drwline(bw1);
  Letter([-2.05,-0.81],"c","$\mathrm{P}$");
Closefile('1');

end;


Setwindow([-2.5,2.5], [-2.5,2.5]);
Assignadd('pi',%pi);
Assignadd('XMIN',Xmin());
Assignadd('XMAX',Xmax());
Assignadd('YMIN',Ymin());
Assignadd('YMAX',Ymax());
A=[0,-4]; Assignrep('A',[0,-4]);
B=[6.28319,-3.96979]; Assignrep('B',[6.28319,-3.96979]);
C=[0.83543,-3.99598]; Assignrep('C',[0.83543,-3.99598]);
mdbw1=evstr('[-0.92657,-0.42598]');  Assignrep('mdbw1',[-0.92657,-0.42598]);
cr1=Circledata([[0,0],[2,0]]);
sg1=Listplot([[0,0],[-1.61803,-1.17557]]);
pt1=Pointdata([-1.61803,-1.17557]);
bw1=Bowdata([0,0],[-1.61803,-1.17557],1,0.3);
PtL=list(A,B,C);
GrL=list();
//if length(fileinfo(Fnamescibody))>0
//  Gbdy=ReadfromCindy(Fnamescibody);
//  execstr(Gbdy)
//end;

//Windisp(GrL,'c');

if 1==1 then

Openfile('/Users/takatoosetsuo/ketcindy/ketsample/samples/s07slides/fig/pointoncircle/p016.tex','1cm');
  Fontsize('s');
  Drwline(cr1);
  Letter([2,0],"se","$2$");
  Setcolor("red");
  Drwline(sg1);
  Setcolor("black");
  Setpen(0.12);
  Drwpt(list(pt1));
  Setpen(1);
  Letter([-0.93,-0.43],"c","$2$");
  Drwline(bw1);
  Letter([-1.78,-1.29],"c","$\mathrm{P}$");
Closefile('1');

end;


Setwindow([-2.5,2.5], [-2.5,2.5]);
Assignadd('pi',%pi);
Assignadd('XMIN',Xmin());
Assignadd('XMAX',Xmax());
Assignadd('YMIN',Ymin());
Assignadd('YMAX',Ymax());
A=[0,-4]; Assignrep('A',[0,-4]);
B=[6.28319,-3.96979]; Assignrep('B',[6.28319,-3.96979]);
C=[0.83543,-3.99598]; Assignrep('C',[0.83543,-3.99598]);
mdbw1=evstr('[-0.79153,-0.64303]');  Assignrep('mdbw1',[-0.79153,-0.64303]);
cr1=Circledata([[0,0],[2,0]]);
sg1=Listplot([[0,0],[-1.27485,-1.54103]]);
pt1=Pointdata([-1.27485,-1.54103]);
bw1=Bowdata([0,0],[-1.27485,-1.54103],1,0.3);
PtL=list(A,B,C);
GrL=list();
//if length(fileinfo(Fnamescibody))>0
//  Gbdy=ReadfromCindy(Fnamescibody);
//  execstr(Gbdy)
//end;

//Windisp(GrL,'c');

if 1==1 then

Openfile('/Users/takatoosetsuo/ketcindy/ketsample/samples/s07slides/fig/pointoncircle/p017.tex','1cm');
  Fontsize('s');
  Drwline(cr1);
  Letter([2,0],"se","$2$");
  Setcolor("red");
  Drwline(sg1);
  Setcolor("black");
  Setpen(0.12);
  Drwpt(list(pt1));
  Setpen(1);
  Letter([-0.79,-0.64],"c","$2$");
  Drwline(bw1);
  Letter([-1.4,-1.7],"c","$\mathrm{P}$");
Closefile('1');

end;


Setwindow([-2.5,2.5], [-2.5,2.5]);
Assignadd('pi',%pi);
Assignadd('XMIN',Xmin());
Assignadd('XMAX',Xmax());
Assignadd('YMIN',Ymin());
Assignadd('YMAX',Ymax());
A=[0,-4]; Assignrep('A',[0,-4]);
B=[6.28319,-3.96979]; Assignrep('B',[6.28319,-3.96979]);
C=[0.83543,-3.99598]; Assignrep('C',[0.83543,-3.99598]);
mdbw1=evstr('[-0.60674,-0.81967]');  Assignrep('mdbw1',[-0.60674,-0.81967]);
cr1=Circledata([[0,0],[2,0]]);
sg1=Listplot([[0,0],[-0.85156,-1.80965]]);
pt1=Pointdata([-0.85156,-1.80965]);
bw1=Bowdata([0,0],[-0.85156,-1.80965],1,0.3);
PtL=list(A,B,C);
GrL=list();
//if length(fileinfo(Fnamescibody))>0
//  Gbdy=ReadfromCindy(Fnamescibody);
//  execstr(Gbdy)
//end;

//Windisp(GrL,'c');

if 1==1 then

Openfile('/Users/takatoosetsuo/ketcindy/ketsample/samples/s07slides/fig/pointoncircle/p018.tex','1cm');
  Fontsize('s');
  Drwline(cr1);
  Letter([2,0],"se","$2$");
  Setcolor("red");
  Drwline(sg1);
  Setcolor("black");
  Setpen(0.12);
  Drwpt(list(pt1));
  Setpen(1);
  Letter([-0.61,-0.82],"c","$2$");
  Drwline(bw1);
  Letter([-0.94,-1.99],"c","$\mathrm{P}$");
Closefile('1');

end;


Setwindow([-2.5,2.5], [-2.5,2.5]);
Assignadd('pi',%pi);
Assignadd('XMIN',Xmin());
Assignadd('XMAX',Xmax());
Assignadd('YMIN',Ymin());
Assignadd('YMAX',Ymax());
A=[0,-4]; Assignrep('A',[0,-4]);
B=[6.28319,-3.96979]; Assignrep('B',[6.28319,-3.96979]);
C=[0.83543,-3.99598]; Assignrep('C',[0.83543,-3.99598]);
mdbw1=evstr('[-0.38384,-0.94481]');  Assignrep('mdbw1',[-0.38384,-0.94481]);
cr1=Circledata([[0,0],[2,0]]);
sg1=Listplot([[0,0],[-0.37476,-1.96457]]);
pt1=Pointdata([-0.37476,-1.96457]);
bw1=Bowdata([0,0],[-0.37476,-1.96457],1,0.3);
PtL=list(A,B,C);
GrL=list();
//if length(fileinfo(Fnamescibody))>0
//  Gbdy=ReadfromCindy(Fnamescibody);
//  execstr(Gbdy)
//end;

//Windisp(GrL,'c');

if 1==1 then

Openfile('/Users/takatoosetsuo/ketcindy/ketsample/samples/s07slides/fig/pointoncircle/p019.tex','1cm');
  Fontsize('s');
  Drwline(cr1);
  Letter([2,0],"se","$2$");
  Setcolor("red");
  Drwline(sg1);
  Setcolor("black");
  Setpen(0.12);
  Drwpt(list(pt1));
  Setpen(1);
  Letter([-0.38,-0.94],"c","$2$");
  Drwline(bw1);
  Letter([-0.41,-2.16],"c","$\mathrm{P}$");
Closefile('1');

end;


Setwindow([-2.5,2.5], [-2.5,2.5]);
Assignadd('pi',%pi);
Assignadd('XMIN',Xmin());
Assignadd('XMAX',Xmax());
Assignadd('YMIN',Ymin());
Assignadd('YMAX',Ymax());
A=[0,-4]; Assignrep('A',[0,-4]);
B=[6.28319,-3.96979]; Assignrep('B',[6.28319,-3.96979]);
C=[0.83543,-3.99598]; Assignrep('C',[0.83543,-3.99598]);
mdbw1=evstr('[-0.13681,-1.01058]');  Assignrep('mdbw1',[-0.13681,-1.01058]);
cr1=Circledata([[0,0],[2,0]]);
sg1=Listplot([[0,0],[0.12558,-1.99605]]);
pt1=Pointdata([0.12558,-1.99605]);
bw1=Bowdata([0,0],[0.12558,-1.99605],1,0.3);
PtL=list(A,B,C);
GrL=list();
//if length(fileinfo(Fnamescibody))>0
//  Gbdy=ReadfromCindy(Fnamescibody);
//  execstr(Gbdy)
//end;

//Windisp(GrL,'c');

if 1==1 then

Openfile('/Users/takatoosetsuo/ketcindy/ketsample/samples/s07slides/fig/pointoncircle/p020.tex','1cm');
  Fontsize('s');
  Drwline(cr1);
  Letter([2,0],"se","$2$");
  Setcolor("red");
  Drwline(sg1);
  Setcolor("black");
  Setpen(0.12);
  Drwpt(list(pt1));
  Setpen(1);
  Letter([-0.14,-1.01],"c","$2$");
  Drwline(bw1);
  Letter([0.14,-2.2],"c","$\mathrm{P}$");
Closefile('1');

end;


Setwindow([-2.5,2.5], [-2.5,2.5]);
Assignadd('pi',%pi);
Assignadd('XMIN',Xmin());
Assignadd('XMAX',Xmax());
Assignadd('YMIN',Ymin());
Assignadd('YMAX',Ymax());
A=[0,-4]; Assignrep('A',[0,-4]);
B=[6.28319,-3.96979]; Assignrep('B',[6.28319,-3.96979]);
C=[0.83543,-3.99598]; Assignrep('C',[0.83543,-3.99598]);
mdbw1=evstr('[0.11881,-1.01286]');  Assignrep('mdbw1',[0.11881,-1.01286]);
cr1=Circledata([[0,0],[2,0]]);
sg1=Listplot([[0,0],[0.61803,-1.90211]]);
pt1=Pointdata([0.61803,-1.90211]);
bw1=Bowdata([0,0],[0.61803,-1.90211],1,0.3);
PtL=list(A,B,C);
GrL=list();
//if length(fileinfo(Fnamescibody))>0
//  Gbdy=ReadfromCindy(Fnamescibody);
//  execstr(Gbdy)
//end;

//Windisp(GrL,'c');

if 1==1 then

Openfile('/Users/takatoosetsuo/ketcindy/ketsample/samples/s07slides/fig/pointoncircle/p021.tex','1cm');
  Fontsize('s');
  Drwline(cr1);
  Letter([2,0],"se","$2$");
  Setcolor("red");
  Drwline(sg1);
  Setcolor("black");
  Setpen(0.12);
  Drwpt(list(pt1));
  Setpen(1);
  Letter([0.12,-1.01],"c","$2$");
  Drwline(bw1);
  Letter([0.68,-2.09],"c","$\mathrm{P}$");
Closefile('1');

end;


Setwindow([-2.5,2.5], [-2.5,2.5]);
Assignadd('pi',%pi);
Assignadd('XMIN',Xmin());
Assignadd('XMAX',Xmax());
Assignadd('YMIN',Ymin());
Assignadd('YMAX',Ymax());
A=[0,-4]; Assignrep('A',[0,-4]);
B=[6.28319,-3.96979]; Assignrep('B',[6.28319,-3.96979]);
C=[0.83543,-3.99598]; Assignrep('C',[0.83543,-3.99598]);
mdbw1=evstr('[0.36696,-0.95149]');  Assignrep('mdbw1',[0.36696,-0.95149]);
cr1=Circledata([[0,0],[2,0]]);
sg1=Listplot([[0,0],[1.07165,-1.68866]]);
pt1=Pointdata([1.07165,-1.68866]);
bw1=Bowdata([0,0],[1.07165,-1.68866],1,0.3);
PtL=list(A,B,C);
GrL=list();
//if length(fileinfo(Fnamescibody))>0
//  Gbdy=ReadfromCindy(Fnamescibody);
//  execstr(Gbdy)
//end;

//Windisp(GrL,'c');

if 1==1 then

Openfile('/Users/takatoosetsuo/ketcindy/ketsample/samples/s07slides/fig/pointoncircle/p022.tex','1cm');
  Fontsize('s');
  Drwline(cr1);
  Letter([2,0],"se","$2$");
  Setcolor("red");
  Drwline(sg1);
  Setcolor("black");
  Setpen(0.12);
  Drwpt(list(pt1));
  Setpen(1);
  Letter([0.37,-0.95],"c","$2$");
  Drwline(bw1);
  Letter([1.18,-1.86],"c","$\mathrm{P}$");
Closefile('1');

end;


Setwindow([-2.5,2.5], [-2.5,2.5]);
Assignadd('pi',%pi);
Assignadd('XMIN',Xmin());
Assignadd('XMAX',Xmax());
Assignadd('YMIN',Ymin());
Assignadd('YMAX',Ymax());
A=[0,-4]; Assignrep('A',[0,-4]);
B=[6.28319,-3.96979]; Assignrep('B',[6.28319,-3.96979]);
C=[0.83543,-3.99598]; Assignrep('C',[0.83543,-3.99598]);
mdbw1=evstr('[0.59206,-0.83034]');  Assignrep('mdbw1',[0.59206,-0.83034]);
cr1=Circledata([[0,0],[2,0]]);
sg1=Listplot([[0,0],[1.45794,-1.36909]]);
pt1=Pointdata([1.45794,-1.36909]);
bw1=Bowdata([0,0],[1.45794,-1.36909],1,0.3);
PtL=list(A,B,C);
GrL=list();
//if length(fileinfo(Fnamescibody))>0
//  Gbdy=ReadfromCindy(Fnamescibody);
//  execstr(Gbdy)
//end;

//Windisp(GrL,'c');

if 1==1 then

Openfile('/Users/takatoosetsuo/ketcindy/ketsample/samples/s07slides/fig/pointoncircle/p023.tex','1cm');
  Fontsize('s');
  Drwline(cr1);
  Letter([2,0],"se","$2$");
  Setcolor("red");
  Drwline(sg1);
  Setcolor("black");
  Setpen(0.12);
  Drwpt(list(pt1));
  Setpen(1);
  Letter([0.59,-0.83],"c","$2$");
  Drwline(bw1);
  Letter([1.6,-1.51],"c","$\mathrm{P}$");
Closefile('1');

end;


Setwindow([-2.5,2.5], [-2.5,2.5]);
Assignadd('pi',%pi);
Assignadd('XMIN',Xmin());
Assignadd('XMAX',Xmax());
Assignadd('YMIN',Ymin());
Assignadd('YMAX',Ymax());
A=[0,-4]; Assignrep('A',[0,-4]);
B=[6.28319,-3.96979]; Assignrep('B',[6.28319,-3.96979]);
C=[0.83543,-3.99598]; Assignrep('C',[0.83543,-3.99598]);
mdbw1=evstr('[0.77996,-0.65702]');  Assignrep('mdbw1',[0.77996,-0.65702]);
cr1=Circledata([[0,0],[2,0]]);
sg1=Listplot([[0,0],[1.75261,-0.96351]]);
pt1=Pointdata([1.75261,-0.96351]);
bw1=Bowdata([0,0],[1.75261,-0.96351],1,0.3);
PtL=list(A,B,C);
GrL=list();
//if length(fileinfo(Fnamescibody))>0
//  Gbdy=ReadfromCindy(Fnamescibody);
//  execstr(Gbdy)
//end;

//Windisp(GrL,'c');

if 1==1 then

Openfile('/Users/takatoosetsuo/ketcindy/ketsample/samples/s07slides/fig/pointoncircle/p024.tex','1cm');
  Fontsize('s');
  Drwline(cr1);
  Letter([2,0],"se","$2$");
  Setcolor("red");
  Drwline(sg1);
  Setcolor("black");
  Setpen(0.12);
  Drwpt(list(pt1));
  Setpen(1);
  Letter([0.78,-0.66],"c","$2$");
  Drwline(bw1);
  Letter([1.93,-1.06],"c","$\mathrm{P}$");
Closefile('1');

end;


Setwindow([-2.5,2.5], [-2.5,2.5]);
Assignadd('pi',%pi);
Assignadd('XMIN',Xmin());
Assignadd('XMAX',Xmax());
Assignadd('YMIN',Ymin());
Assignadd('YMAX',Ymax());
A=[0,-4]; Assignrep('A',[0,-4]);
B=[6.28319,-3.96979]; Assignrep('B',[6.28319,-3.96979]);
C=[0.83543,-3.99598]; Assignrep('C',[0.83543,-3.99598]);
mdbw1=evstr('[0.91885,-0.44241]');  Assignrep('mdbw1',[0.91885,-0.44241]);
cr1=Circledata([[0,0],[2,0]]);
sg1=Listplot([[0,0],[1.93717,-0.49738]]);
pt1=Pointdata([1.93717,-0.49738]);
bw1=Bowdata([0,0],[1.93717,-0.49738],1,0.3);
PtL=list(A,B,C);
GrL=list();
//if length(fileinfo(Fnamescibody))>0
//  Gbdy=ReadfromCindy(Fnamescibody);
//  execstr(Gbdy)
//end;

//Windisp(GrL,'c');

if 1==1 then

Openfile('/Users/takatoosetsuo/ketcindy/ketsample/samples/s07slides/fig/pointoncircle/p025.tex','1cm');
  Fontsize('s');
  Drwline(cr1);
  Letter([2,0],"se","$2$");
  Setcolor("red");
  Drwline(sg1);
  Setcolor("black");
  Setpen(0.12);
  Drwpt(list(pt1));
  Setpen(1);
  Letter([0.92,-0.44],"c","$2$");
  Drwline(bw1);
  Letter([2.13,-0.55],"c","$\mathrm{P}$");
Closefile('1');

end;


Setwindow([-2.5,2.5], [-2.5,2.5]);
Assignadd('pi',%pi);
Assignadd('XMIN',Xmin());
Assignadd('XMAX',Xmax());
Assignadd('YMIN',Ymin());
Assignadd('YMAX',Ymax());
A=[0,-4]; Assignrep('A',[0,-4]);
B=[6.28319,-3.96979]; Assignrep('B',[6.28319,-3.96979]);
C=[0.83543,-3.99598]; Assignrep('C',[0.83543,-3.99598]);
mdbw1=evstr('[1,-0.2]');  Assignrep('mdbw1',[1,-0.2]);
cr1=Circledata([[0,0],[2,0]]);
sg1=Listplot([[0,0],[2,0]]);
pt1=Pointdata([2,0]);
bw1=Bowdata([0,0],[2,0],1,0.3);
PtL=list(A,B,C);
GrL=list();
//if length(fileinfo(Fnamescibody))>0
//  Gbdy=ReadfromCindy(Fnamescibody);
//  execstr(Gbdy)
//end;

//Windisp(GrL,'c');

if 1==1 then

Openfile('/Users/takatoosetsuo/ketcindy/ketsample/samples/s07slides/fig/pointoncircle/p026.tex','1cm');
  Fontsize('s');
  Drwline(cr1);
  Letter([2,0],"se","$2$");
  Setcolor("red");
  Drwline(sg1);
  Setcolor("black");
  Setpen(0.12);
  Drwpt(list(pt1));
  Setpen(1);
  Letter([1,-0.2],"c","$2$");
  Drwline(bw1);
  Letter([2.2,0],"c","$\mathrm{P}$");
Closefile('1');

end;

