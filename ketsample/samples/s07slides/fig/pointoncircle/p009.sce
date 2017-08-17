//date time=2017/6/25 09:43:29

cd('/Users/takatoosetsuo/ketcindy/ketsample/samples/s07slides/fig');
Ketlib=lib('/Users/takatoosetsuo/ketcindy/ketlib/ketpicsciL5');
Ketinit();
disp('KETpic '+ThisVersion())
Fnametex='pointoncircle/p009.tex';
Fnamesci='pointoncircle/p009.sce';
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

quit();
