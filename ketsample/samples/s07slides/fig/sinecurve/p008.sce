//date time=2017/8/24 14:44:24

cd('/Users/takatoosetsuo/ketcindy/ketsample/samples/s07slides/fig');
Ketlib=lib('/Users/takatoosetsuo/ketcindy/ketlib/ketpicscifiles6');
Ketinit();
disp('KETpic '+ThisVersion())
Fnametex='sinecurve/p008.tex';
Fnamesci='sinecurve/p008.sce';
Fnamescibody='figs0704parabody.sce';
Fnameout='figs0704para.txt';
pi=%pi; i=%i;
arccos=acos; arcsin=asin; arctan=atan;

Setwindow([-3,8], [-1.5,1.5]);
Assignadd('pi',%pi);
Assignadd('XMIN',Xmin());
Assignadd('XMAX',Xmax());
Assignadd('YMIN',Ymin());
Assignadd('YMAX',Ymax());
A=[-3,-3]; Assignrep('A',[-3,-3]);
B=[8,-3]; Assignrep('B',[8,-3]);
C=[-2.5,-3]; Assignrep('C',[-2.5,-3]);
sgAB=Listplot([A,B]);
gr1=Plotdata(Assign('sin(x-(-0.43333))'),Assign('x'));
PtL=list(A,B,C);
GrL=list();
//if length(fileinfo(Fnamescibody))>0
//  Gbdy=ReadfromCindy(Fnamescibody);
//  execstr(Gbdy)
//end;

//Windisp(GrL,'c');

if 1==1 then

Openfile('/Users/takatoosetsuo/ketcindy/ketsample/samples/s07slides/fig/sinecurve/p008.tex','1cm');
  Fontsize('s');
  Drwline(gr1);
Closefile('1');

end;

quit();
