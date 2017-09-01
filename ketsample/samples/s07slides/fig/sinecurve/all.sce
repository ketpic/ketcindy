//date time=2017/8/24 14:44:24

cd('/Users/takatoosetsuo/ketcindy/ketsample/samples/s07slides/fig');
Ketlib=lib('/Users/takatoosetsuo/ketcindy/ketlib/ketpicscifiles6');
Ketinit();
disp('KETpic '+ThisVersion())
Fnametex='sinecurve/p001.tex';
Fnamesci='sinecurve/p001.sce';
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
gr1=Plotdata(Assign('sin(x-(-3))'),Assign('x'));
PtL=list(A,B,C);
GrL=list();
//if length(fileinfo(Fnamescibody))>0
//  Gbdy=ReadfromCindy(Fnamescibody);
//  execstr(Gbdy)
//end;

//Windisp(GrL,'c');

if 1==1 then

Openfile('/Users/takatoosetsuo/ketcindy/ketsample/samples/s07slides/fig/sinecurve/p001.tex','1cm');
  Fontsize('s');
  Drwline(gr1);
Closefile('1');

end;


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
gr1=Plotdata(Assign('sin(x-(-2.63333))'),Assign('x'));
PtL=list(A,B,C);
GrL=list();
//if length(fileinfo(Fnamescibody))>0
//  Gbdy=ReadfromCindy(Fnamescibody);
//  execstr(Gbdy)
//end;

//Windisp(GrL,'c');

if 1==1 then

Openfile('/Users/takatoosetsuo/ketcindy/ketsample/samples/s07slides/fig/sinecurve/p002.tex','1cm');
  Fontsize('s');
  Drwline(gr1);
Closefile('1');

end;


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
gr1=Plotdata(Assign('sin(x-(-2.26667))'),Assign('x'));
PtL=list(A,B,C);
GrL=list();
//if length(fileinfo(Fnamescibody))>0
//  Gbdy=ReadfromCindy(Fnamescibody);
//  execstr(Gbdy)
//end;

//Windisp(GrL,'c');

if 1==1 then

Openfile('/Users/takatoosetsuo/ketcindy/ketsample/samples/s07slides/fig/sinecurve/p003.tex','1cm');
  Fontsize('s');
  Drwline(gr1);
Closefile('1');

end;


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
gr1=Plotdata(Assign('sin(x-(-1.9))'),Assign('x'));
PtL=list(A,B,C);
GrL=list();
//if length(fileinfo(Fnamescibody))>0
//  Gbdy=ReadfromCindy(Fnamescibody);
//  execstr(Gbdy)
//end;

//Windisp(GrL,'c');

if 1==1 then

Openfile('/Users/takatoosetsuo/ketcindy/ketsample/samples/s07slides/fig/sinecurve/p004.tex','1cm');
  Fontsize('s');
  Drwline(gr1);
Closefile('1');

end;


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
gr1=Plotdata(Assign('sin(x-(-1.53333))'),Assign('x'));
PtL=list(A,B,C);
GrL=list();
//if length(fileinfo(Fnamescibody))>0
//  Gbdy=ReadfromCindy(Fnamescibody);
//  execstr(Gbdy)
//end;

//Windisp(GrL,'c');

if 1==1 then

Openfile('/Users/takatoosetsuo/ketcindy/ketsample/samples/s07slides/fig/sinecurve/p005.tex','1cm');
  Fontsize('s');
  Drwline(gr1);
Closefile('1');

end;


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
gr1=Plotdata(Assign('sin(x-(-1.16667))'),Assign('x'));
PtL=list(A,B,C);
GrL=list();
//if length(fileinfo(Fnamescibody))>0
//  Gbdy=ReadfromCindy(Fnamescibody);
//  execstr(Gbdy)
//end;

//Windisp(GrL,'c');

if 1==1 then

Openfile('/Users/takatoosetsuo/ketcindy/ketsample/samples/s07slides/fig/sinecurve/p006.tex','1cm');
  Fontsize('s');
  Drwline(gr1);
Closefile('1');

end;


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
gr1=Plotdata(Assign('sin(x-(-0.8))'),Assign('x'));
PtL=list(A,B,C);
GrL=list();
//if length(fileinfo(Fnamescibody))>0
//  Gbdy=ReadfromCindy(Fnamescibody);
//  execstr(Gbdy)
//end;

//Windisp(GrL,'c');

if 1==1 then

Openfile('/Users/takatoosetsuo/ketcindy/ketsample/samples/s07slides/fig/sinecurve/p007.tex','1cm');
  Fontsize('s');
  Drwline(gr1);
Closefile('1');

end;


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
gr1=Plotdata(Assign('sin(x-(-0.06667))'),Assign('x'));
PtL=list(A,B,C);
GrL=list();
//if length(fileinfo(Fnamescibody))>0
//  Gbdy=ReadfromCindy(Fnamescibody);
//  execstr(Gbdy)
//end;

//Windisp(GrL,'c');

if 1==1 then

Openfile('/Users/takatoosetsuo/ketcindy/ketsample/samples/s07slides/fig/sinecurve/p009.tex','1cm');
  Fontsize('s');
  Drwline(gr1);
Closefile('1');

end;


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
gr1=Plotdata(Assign('sin(x-(0.3))'),Assign('x'));
PtL=list(A,B,C);
GrL=list();
//if length(fileinfo(Fnamescibody))>0
//  Gbdy=ReadfromCindy(Fnamescibody);
//  execstr(Gbdy)
//end;

//Windisp(GrL,'c');

if 1==1 then

Openfile('/Users/takatoosetsuo/ketcindy/ketsample/samples/s07slides/fig/sinecurve/p010.tex','1cm');
  Fontsize('s');
  Drwline(gr1);
Closefile('1');

end;


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
gr1=Plotdata(Assign('sin(x-(0.66667))'),Assign('x'));
PtL=list(A,B,C);
GrL=list();
//if length(fileinfo(Fnamescibody))>0
//  Gbdy=ReadfromCindy(Fnamescibody);
//  execstr(Gbdy)
//end;

//Windisp(GrL,'c');

if 1==1 then

Openfile('/Users/takatoosetsuo/ketcindy/ketsample/samples/s07slides/fig/sinecurve/p011.tex','1cm');
  Fontsize('s');
  Drwline(gr1);
Closefile('1');

end;


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
gr1=Plotdata(Assign('sin(x-(1.03333))'),Assign('x'));
PtL=list(A,B,C);
GrL=list();
//if length(fileinfo(Fnamescibody))>0
//  Gbdy=ReadfromCindy(Fnamescibody);
//  execstr(Gbdy)
//end;

//Windisp(GrL,'c');

if 1==1 then

Openfile('/Users/takatoosetsuo/ketcindy/ketsample/samples/s07slides/fig/sinecurve/p012.tex','1cm');
  Fontsize('s');
  Drwline(gr1);
Closefile('1');

end;


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
gr1=Plotdata(Assign('sin(x-(1.4))'),Assign('x'));
PtL=list(A,B,C);
GrL=list();
//if length(fileinfo(Fnamescibody))>0
//  Gbdy=ReadfromCindy(Fnamescibody);
//  execstr(Gbdy)
//end;

//Windisp(GrL,'c');

if 1==1 then

Openfile('/Users/takatoosetsuo/ketcindy/ketsample/samples/s07slides/fig/sinecurve/p013.tex','1cm');
  Fontsize('s');
  Drwline(gr1);
Closefile('1');

end;


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
gr1=Plotdata(Assign('sin(x-(1.76667))'),Assign('x'));
PtL=list(A,B,C);
GrL=list();
//if length(fileinfo(Fnamescibody))>0
//  Gbdy=ReadfromCindy(Fnamescibody);
//  execstr(Gbdy)
//end;

//Windisp(GrL,'c');

if 1==1 then

Openfile('/Users/takatoosetsuo/ketcindy/ketsample/samples/s07slides/fig/sinecurve/p014.tex','1cm');
  Fontsize('s');
  Drwline(gr1);
Closefile('1');

end;


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
gr1=Plotdata(Assign('sin(x-(2.13333))'),Assign('x'));
PtL=list(A,B,C);
GrL=list();
//if length(fileinfo(Fnamescibody))>0
//  Gbdy=ReadfromCindy(Fnamescibody);
//  execstr(Gbdy)
//end;

//Windisp(GrL,'c');

if 1==1 then

Openfile('/Users/takatoosetsuo/ketcindy/ketsample/samples/s07slides/fig/sinecurve/p015.tex','1cm');
  Fontsize('s');
  Drwline(gr1);
Closefile('1');

end;


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
gr1=Plotdata(Assign('sin(x-(2.5))'),Assign('x'));
PtL=list(A,B,C);
GrL=list();
//if length(fileinfo(Fnamescibody))>0
//  Gbdy=ReadfromCindy(Fnamescibody);
//  execstr(Gbdy)
//end;

//Windisp(GrL,'c');

if 1==1 then

Openfile('/Users/takatoosetsuo/ketcindy/ketsample/samples/s07slides/fig/sinecurve/p016.tex','1cm');
  Fontsize('s');
  Drwline(gr1);
Closefile('1');

end;


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
gr1=Plotdata(Assign('sin(x-(2.86667))'),Assign('x'));
PtL=list(A,B,C);
GrL=list();
//if length(fileinfo(Fnamescibody))>0
//  Gbdy=ReadfromCindy(Fnamescibody);
//  execstr(Gbdy)
//end;

//Windisp(GrL,'c');

if 1==1 then

Openfile('/Users/takatoosetsuo/ketcindy/ketsample/samples/s07slides/fig/sinecurve/p017.tex','1cm');
  Fontsize('s');
  Drwline(gr1);
Closefile('1');

end;


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
gr1=Plotdata(Assign('sin(x-(3.23333))'),Assign('x'));
PtL=list(A,B,C);
GrL=list();
//if length(fileinfo(Fnamescibody))>0
//  Gbdy=ReadfromCindy(Fnamescibody);
//  execstr(Gbdy)
//end;

//Windisp(GrL,'c');

if 1==1 then

Openfile('/Users/takatoosetsuo/ketcindy/ketsample/samples/s07slides/fig/sinecurve/p018.tex','1cm');
  Fontsize('s');
  Drwline(gr1);
Closefile('1');

end;


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
gr1=Plotdata(Assign('sin(x-(3.6))'),Assign('x'));
PtL=list(A,B,C);
GrL=list();
//if length(fileinfo(Fnamescibody))>0
//  Gbdy=ReadfromCindy(Fnamescibody);
//  execstr(Gbdy)
//end;

//Windisp(GrL,'c');

if 1==1 then

Openfile('/Users/takatoosetsuo/ketcindy/ketsample/samples/s07slides/fig/sinecurve/p019.tex','1cm');
  Fontsize('s');
  Drwline(gr1);
Closefile('1');

end;


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
gr1=Plotdata(Assign('sin(x-(3.96667))'),Assign('x'));
PtL=list(A,B,C);
GrL=list();
//if length(fileinfo(Fnamescibody))>0
//  Gbdy=ReadfromCindy(Fnamescibody);
//  execstr(Gbdy)
//end;

//Windisp(GrL,'c');

if 1==1 then

Openfile('/Users/takatoosetsuo/ketcindy/ketsample/samples/s07slides/fig/sinecurve/p020.tex','1cm');
  Fontsize('s');
  Drwline(gr1);
Closefile('1');

end;


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
gr1=Plotdata(Assign('sin(x-(4.33333))'),Assign('x'));
PtL=list(A,B,C);
GrL=list();
//if length(fileinfo(Fnamescibody))>0
//  Gbdy=ReadfromCindy(Fnamescibody);
//  execstr(Gbdy)
//end;

//Windisp(GrL,'c');

if 1==1 then

Openfile('/Users/takatoosetsuo/ketcindy/ketsample/samples/s07slides/fig/sinecurve/p021.tex','1cm');
  Fontsize('s');
  Drwline(gr1);
Closefile('1');

end;


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
gr1=Plotdata(Assign('sin(x-(4.7))'),Assign('x'));
PtL=list(A,B,C);
GrL=list();
//if length(fileinfo(Fnamescibody))>0
//  Gbdy=ReadfromCindy(Fnamescibody);
//  execstr(Gbdy)
//end;

//Windisp(GrL,'c');

if 1==1 then

Openfile('/Users/takatoosetsuo/ketcindy/ketsample/samples/s07slides/fig/sinecurve/p022.tex','1cm');
  Fontsize('s');
  Drwline(gr1);
Closefile('1');

end;


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
gr1=Plotdata(Assign('sin(x-(5.06667))'),Assign('x'));
PtL=list(A,B,C);
GrL=list();
//if length(fileinfo(Fnamescibody))>0
//  Gbdy=ReadfromCindy(Fnamescibody);
//  execstr(Gbdy)
//end;

//Windisp(GrL,'c');

if 1==1 then

Openfile('/Users/takatoosetsuo/ketcindy/ketsample/samples/s07slides/fig/sinecurve/p023.tex','1cm');
  Fontsize('s');
  Drwline(gr1);
Closefile('1');

end;


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
gr1=Plotdata(Assign('sin(x-(5.43333))'),Assign('x'));
PtL=list(A,B,C);
GrL=list();
//if length(fileinfo(Fnamescibody))>0
//  Gbdy=ReadfromCindy(Fnamescibody);
//  execstr(Gbdy)
//end;

//Windisp(GrL,'c');

if 1==1 then

Openfile('/Users/takatoosetsuo/ketcindy/ketsample/samples/s07slides/fig/sinecurve/p024.tex','1cm');
  Fontsize('s');
  Drwline(gr1);
Closefile('1');

end;


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
gr1=Plotdata(Assign('sin(x-(5.8))'),Assign('x'));
PtL=list(A,B,C);
GrL=list();
//if length(fileinfo(Fnamescibody))>0
//  Gbdy=ReadfromCindy(Fnamescibody);
//  execstr(Gbdy)
//end;

//Windisp(GrL,'c');

if 1==1 then

Openfile('/Users/takatoosetsuo/ketcindy/ketsample/samples/s07slides/fig/sinecurve/p025.tex','1cm');
  Fontsize('s');
  Drwline(gr1);
Closefile('1');

end;


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
gr1=Plotdata(Assign('sin(x-(6.16667))'),Assign('x'));
PtL=list(A,B,C);
GrL=list();
//if length(fileinfo(Fnamescibody))>0
//  Gbdy=ReadfromCindy(Fnamescibody);
//  execstr(Gbdy)
//end;

//Windisp(GrL,'c');

if 1==1 then

Openfile('/Users/takatoosetsuo/ketcindy/ketsample/samples/s07slides/fig/sinecurve/p026.tex','1cm');
  Fontsize('s');
  Drwline(gr1);
Closefile('1');

end;


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
gr1=Plotdata(Assign('sin(x-(6.53333))'),Assign('x'));
PtL=list(A,B,C);
GrL=list();
//if length(fileinfo(Fnamescibody))>0
//  Gbdy=ReadfromCindy(Fnamescibody);
//  execstr(Gbdy)
//end;

//Windisp(GrL,'c');

if 1==1 then

Openfile('/Users/takatoosetsuo/ketcindy/ketsample/samples/s07slides/fig/sinecurve/p027.tex','1cm');
  Fontsize('s');
  Drwline(gr1);
Closefile('1');

end;


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
gr1=Plotdata(Assign('sin(x-(6.9))'),Assign('x'));
PtL=list(A,B,C);
GrL=list();
//if length(fileinfo(Fnamescibody))>0
//  Gbdy=ReadfromCindy(Fnamescibody);
//  execstr(Gbdy)
//end;

//Windisp(GrL,'c');

if 1==1 then

Openfile('/Users/takatoosetsuo/ketcindy/ketsample/samples/s07slides/fig/sinecurve/p028.tex','1cm');
  Fontsize('s');
  Drwline(gr1);
Closefile('1');

end;


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
gr1=Plotdata(Assign('sin(x-(7.26667))'),Assign('x'));
PtL=list(A,B,C);
GrL=list();
//if length(fileinfo(Fnamescibody))>0
//  Gbdy=ReadfromCindy(Fnamescibody);
//  execstr(Gbdy)
//end;

//Windisp(GrL,'c');

if 1==1 then

Openfile('/Users/takatoosetsuo/ketcindy/ketsample/samples/s07slides/fig/sinecurve/p029.tex','1cm');
  Fontsize('s');
  Drwline(gr1);
Closefile('1');

end;


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
gr1=Plotdata(Assign('sin(x-(7.63333))'),Assign('x'));
PtL=list(A,B,C);
GrL=list();
//if length(fileinfo(Fnamescibody))>0
//  Gbdy=ReadfromCindy(Fnamescibody);
//  execstr(Gbdy)
//end;

//Windisp(GrL,'c');

if 1==1 then

Openfile('/Users/takatoosetsuo/ketcindy/ketsample/samples/s07slides/fig/sinecurve/p030.tex','1cm');
  Fontsize('s');
  Drwline(gr1);
Closefile('1');

end;


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
gr1=Plotdata(Assign('sin(x-(8))'),Assign('x'));
PtL=list(A,B,C);
GrL=list();
//if length(fileinfo(Fnamescibody))>0
//  Gbdy=ReadfromCindy(Fnamescibody);
//  execstr(Gbdy)
//end;

//Windisp(GrL,'c');

if 1==1 then

Openfile('/Users/takatoosetsuo/ketcindy/ketsample/samples/s07slides/fig/sinecurve/p031.tex','1cm');
  Fontsize('s');
  Drwline(gr1);
Closefile('1');

end;

