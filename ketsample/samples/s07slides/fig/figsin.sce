//date time=2017/6/25 09:09:01

cd('/Users/takatoosetsuo/ketcindy/ketsample/samples/s07slides/fig');
Ketlib=lib('/Users/takatoosetsuo/ketcindy/ketlib/ketpicsciL5');
Ketinit();
disp('KETpic '+ThisVersion())
Fnametex='figsin.tex';
Fnamesci='figsin.sce';
Fnamescibody='figsinbody.sce';
Fnameout='figsin.txt';
pi=%pi; i=%i;
arccos=acos; arcsin=asin; arctan=atan;

Setwindow([-6,6], [-2,2]);
Assignadd('pi',%pi);
Assignadd('XMIN',Xmin());
Assignadd('XMAX',Xmax());
Assignadd('YMIN',Ymin());
Assignadd('YMAX',Ymax());
gr1=Plotdata(Assign('sin(x)'),Assign('x'));
sg1=Listplot([[-6,1],[6,1]]);
sg2=Listplot([[-6,-1],[6,-1]]);
PtL=list();
GrL=list();
//if length(fileinfo(Fnamescibody))>0
//  Gbdy=ReadfromCindy(Fnamescibody);
//  execstr(Gbdy)
//end;

//Windisp(GrL,'c');

if 1==1 then

Openfile('/Users/takatoosetsuo/ketcindy/ketsample/samples/s07slides/fig/figsin.tex','1cm');
  Drwline(gr1);
  Dashline(sg1);
  Dashline(sg2);
Closefile('1');

end;

quit();
