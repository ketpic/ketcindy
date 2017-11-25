// 09.11.26
// 09.12.06

function Setmark();
  Xminnow=Xmin(); Xmaxnow=Xmax();
  Yminnow=Ymin(); Ymaxnow=Ymax();
  Setwindow([-1.5,1.5],[-2.3,2.3]);
  F1=Framedata();
  F2=Paramplot('[1.5*cos(t),2.3*sin(t)]','t=[0,2*%pi]','N=25');
  Texcom('\def\recmark{');
  Texcom('\begin{minipage}[c]{3mm}');
  Beginpicture('1mm');
  Shade(F1);
  Drwline(F1);
  Endpicture(0);
  Texcom('');
  Texcom('\end{minipage}');
  Texcom('}');
  
  Texcom('\def\cirmark{');
  Texcom('\begin{minipage}[c]{3mm}');
  Beginpicture('1mm');
  Shade(F2);
  Drwline(F2);
  Endpicture(0);
  Texcom('');
  Texcom('\end{minipage}');
  Texcom('}');

  Texcom('\def\dashmark#1{');
  Texcom('\begin{minipage}[c]{3mm}');
  Beginpicture('1mm');
  Setpen(0.5);
  Dashline(F2,0.5,0.5);
  Fontsize('ss');
  Letter([0,0],'c','#1');
  Endpicture(0);
  Texcom('');
  Texcom('\end{minipage}');
  Texcom('}');
  Setwindow([Xminnow,Xmaxnow],[Yminnow,Ymaxnow]);
endfunction;

