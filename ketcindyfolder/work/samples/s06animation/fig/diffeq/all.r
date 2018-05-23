# date time=2018/4/8 16:44:37

source('/Applications/KeTTeX.app/texlive/texmf-dist/scripts/ketcindy/ketlib/ketpiccurrent.r')
Ketinit()
cat(ThisVersion,'\n')
Fnametex='diffeq/p001.tex'
FnameR='diffeq/p001.r'
Fnameout='s0602diffeq.txt'
arccos=acos; arcsin=asin; arctan=atan

Setwindow(c(-4,10), c(-2,5))
A=c(-4,-3);Assignadd('A',A)
B=c(10,-3);Assignadd('B',B)
C=c(-2.48112,-3);Assignadd('C',C)
D=c(0,5);Assignadd('D',D)
E=c(0,-2);Assignadd('E',E)
F=c(0,2.208198);Assignadd('F',F)
sgAB=Listplot(c(A,B))
Setax("","","sw","","sw")
pt1=Pointdata(list(0,2.208198))
PtL=list()
GrL=list()

# Windisp(GrL)

if(1==1){

Openfile('/Users/takatoosetsuo/ketcindy/ketsample/samples/s06animation/fig/diffeq/p001.tex','1cm','Cdy=s0602diffeq.cdy')
Setpen(0.12)
Drwpt(list(pt1))
Setpen(1)
Closefile('1')

}

print( 1 )
print( 0.018 )
Ketinit()
FnameR='diffeq/p002.r'
Fnameout='s0602diffeq.txt'
arccos=acos; arcsin=asin; arctan=atan

Setwindow(c(-4,10), c(-2,5))
A=c(-4,-3);Assignadd('A',A)
B=c(10,-3);Assignadd('B',B)
C=c(-2.48112,-3);Assignadd('C',C)
D=c(0,5);Assignadd('D',D)
E=c(0,-2);Assignadd('E',E)
F=c(0,2.208198);Assignadd('F',F)
sgAB=Listplot(c(A,B))
Setax("","","sw","","sw")
de1=Deqplot('c(xN1,xN2)`=c(xN2,-0.5*xN2-xN1)','t=c(0,(0.4))',0,c(2.208198,0),c(1,2),'Num=50')
PtL=list()
GrL=list()

# Windisp(GrL)

if(1==1){

Openfile('/Users/takatoosetsuo/ketcindy/ketsample/samples/s06animation/fig/diffeq/p002.tex','1cm','Cdy=s0602diffeq.cdy')
Drwline(de1)
Closefile('1')

}

print( 2 )
print( 0.033 )
Ketinit()
FnameR='diffeq/p003.r'
Fnameout='s0602diffeq.txt'
arccos=acos; arcsin=asin; arctan=atan

Setwindow(c(-4,10), c(-2,5))
A=c(-4,-3);Assignadd('A',A)
B=c(10,-3);Assignadd('B',B)
C=c(-2.48112,-3);Assignadd('C',C)
D=c(0,5);Assignadd('D',D)
E=c(0,-2);Assignadd('E',E)
F=c(0,2.208198);Assignadd('F',F)
sgAB=Listplot(c(A,B))
Setax("","","sw","","sw")
de1=Deqplot('c(xN1,xN2)`=c(xN2,-0.5*xN2-xN1)','t=c(0,(0.8))',0,c(2.208198,0),c(1,2),'Num=50')
PtL=list()
GrL=list()

# Windisp(GrL)

if(1==1){

Openfile('/Users/takatoosetsuo/ketcindy/ketsample/samples/s06animation/fig/diffeq/p003.tex','1cm','Cdy=s0602diffeq.cdy')
Drwline(de1)
Closefile('1')

}

print( 3 )
print( 0.049 )
Ketinit()
FnameR='diffeq/p004.r'
Fnameout='s0602diffeq.txt'
arccos=acos; arcsin=asin; arctan=atan

Setwindow(c(-4,10), c(-2,5))
A=c(-4,-3);Assignadd('A',A)
B=c(10,-3);Assignadd('B',B)
C=c(-2.48112,-3);Assignadd('C',C)
D=c(0,5);Assignadd('D',D)
E=c(0,-2);Assignadd('E',E)
F=c(0,2.208198);Assignadd('F',F)
sgAB=Listplot(c(A,B))
Setax("","","sw","","sw")
de1=Deqplot('c(xN1,xN2)`=c(xN2,-0.5*xN2-xN1)','t=c(0,(1.2))',0,c(2.208198,0),c(1,2),'Num=50')
PtL=list()
GrL=list()

# Windisp(GrL)

if(1==1){

Openfile('/Users/takatoosetsuo/ketcindy/ketsample/samples/s06animation/fig/diffeq/p004.tex','1cm','Cdy=s0602diffeq.cdy')
Drwline(de1)
Closefile('1')

}

print( 4 )
print( 0.056 )
Ketinit()
FnameR='diffeq/p005.r'
Fnameout='s0602diffeq.txt'
arccos=acos; arcsin=asin; arctan=atan

Setwindow(c(-4,10), c(-2,5))
A=c(-4,-3);Assignadd('A',A)
B=c(10,-3);Assignadd('B',B)
C=c(-2.48112,-3);Assignadd('C',C)
D=c(0,5);Assignadd('D',D)
E=c(0,-2);Assignadd('E',E)
F=c(0,2.208198);Assignadd('F',F)
sgAB=Listplot(c(A,B))
Setax("","","sw","","sw")
de1=Deqplot('c(xN1,xN2)`=c(xN2,-0.5*xN2-xN1)','t=c(0,(1.6))',0,c(2.208198,0),c(1,2),'Num=50')
PtL=list()
GrL=list()

# Windisp(GrL)

if(1==1){

Openfile('/Users/takatoosetsuo/ketcindy/ketsample/samples/s06animation/fig/diffeq/p005.tex','1cm','Cdy=s0602diffeq.cdy')
Drwline(de1)
Closefile('1')

}

print( 5 )
print( 0.069 )
Ketinit()
FnameR='diffeq/p006.r'
Fnameout='s0602diffeq.txt'
arccos=acos; arcsin=asin; arctan=atan

Setwindow(c(-4,10), c(-2,5))
A=c(-4,-3);Assignadd('A',A)
B=c(10,-3);Assignadd('B',B)
C=c(-2.48112,-3);Assignadd('C',C)
D=c(0,5);Assignadd('D',D)
E=c(0,-2);Assignadd('E',E)
F=c(0,2.208198);Assignadd('F',F)
sgAB=Listplot(c(A,B))
Setax("","","sw","","sw")
de1=Deqplot('c(xN1,xN2)`=c(xN2,-0.5*xN2-xN1)','t=c(0,(2))',0,c(2.208198,0),c(1,2),'Num=50')
PtL=list()
GrL=list()

# Windisp(GrL)

if(1==1){

Openfile('/Users/takatoosetsuo/ketcindy/ketsample/samples/s06animation/fig/diffeq/p006.tex','1cm','Cdy=s0602diffeq.cdy')
Drwline(de1)
Closefile('1')

}

print( 6 )
print( 0.076 )
Ketinit()
FnameR='diffeq/p007.r'
Fnameout='s0602diffeq.txt'
arccos=acos; arcsin=asin; arctan=atan

Setwindow(c(-4,10), c(-2,5))
A=c(-4,-3);Assignadd('A',A)
B=c(10,-3);Assignadd('B',B)
C=c(-2.48112,-3);Assignadd('C',C)
D=c(0,5);Assignadd('D',D)
E=c(0,-2);Assignadd('E',E)
F=c(0,2.208198);Assignadd('F',F)
sgAB=Listplot(c(A,B))
Setax("","","sw","","sw")
de1=Deqplot('c(xN1,xN2)`=c(xN2,-0.5*xN2-xN1)','t=c(0,(2.4))',0,c(2.208198,0),c(1,2),'Num=50')
PtL=list()
GrL=list()

# Windisp(GrL)

if(1==1){

Openfile('/Users/takatoosetsuo/ketcindy/ketsample/samples/s06animation/fig/diffeq/p007.tex','1cm','Cdy=s0602diffeq.cdy')
Drwline(de1)
Closefile('1')

}

print( 7 )
print( 0.092 )
Ketinit()
FnameR='diffeq/p008.r'
Fnameout='s0602diffeq.txt'
arccos=acos; arcsin=asin; arctan=atan

Setwindow(c(-4,10), c(-2,5))
A=c(-4,-3);Assignadd('A',A)
B=c(10,-3);Assignadd('B',B)
C=c(-2.48112,-3);Assignadd('C',C)
D=c(0,5);Assignadd('D',D)
E=c(0,-2);Assignadd('E',E)
F=c(0,2.208198);Assignadd('F',F)
sgAB=Listplot(c(A,B))
Setax("","","sw","","sw")
de1=Deqplot('c(xN1,xN2)`=c(xN2,-0.5*xN2-xN1)','t=c(0,(2.8))',0,c(2.208198,0),c(1,2),'Num=50')
PtL=list()
GrL=list()

# Windisp(GrL)

if(1==1){

Openfile('/Users/takatoosetsuo/ketcindy/ketsample/samples/s06animation/fig/diffeq/p008.tex','1cm','Cdy=s0602diffeq.cdy')
Drwline(de1)
Closefile('1')

}

print( 8 )
print( 0.113 )
Ketinit()
FnameR='diffeq/p009.r'
Fnameout='s0602diffeq.txt'
arccos=acos; arcsin=asin; arctan=atan

Setwindow(c(-4,10), c(-2,5))
A=c(-4,-3);Assignadd('A',A)
B=c(10,-3);Assignadd('B',B)
C=c(-2.48112,-3);Assignadd('C',C)
D=c(0,5);Assignadd('D',D)
E=c(0,-2);Assignadd('E',E)
F=c(0,2.208198);Assignadd('F',F)
sgAB=Listplot(c(A,B))
Setax("","","sw","","sw")
de1=Deqplot('c(xN1,xN2)`=c(xN2,-0.5*xN2-xN1)','t=c(0,(3.2))',0,c(2.208198,0),c(1,2),'Num=50')
PtL=list()
GrL=list()

# Windisp(GrL)

if(1==1){

Openfile('/Users/takatoosetsuo/ketcindy/ketsample/samples/s06animation/fig/diffeq/p009.tex','1cm','Cdy=s0602diffeq.cdy')
Drwline(de1)
Closefile('1')

}

print( 9 )
print( 0.125 )
Ketinit()
FnameR='diffeq/p010.r'
Fnameout='s0602diffeq.txt'
arccos=acos; arcsin=asin; arctan=atan

Setwindow(c(-4,10), c(-2,5))
A=c(-4,-3);Assignadd('A',A)
B=c(10,-3);Assignadd('B',B)
C=c(-2.48112,-3);Assignadd('C',C)
D=c(0,5);Assignadd('D',D)
E=c(0,-2);Assignadd('E',E)
F=c(0,2.208198);Assignadd('F',F)
sgAB=Listplot(c(A,B))
Setax("","","sw","","sw")
de1=Deqplot('c(xN1,xN2)`=c(xN2,-0.5*xN2-xN1)','t=c(0,(3.6))',0,c(2.208198,0),c(1,2),'Num=50')
PtL=list()
GrL=list()

# Windisp(GrL)

if(1==1){

Openfile('/Users/takatoosetsuo/ketcindy/ketsample/samples/s06animation/fig/diffeq/p010.tex','1cm','Cdy=s0602diffeq.cdy')
Drwline(de1)
Closefile('1')

}

print( 10 )
print( 0.13 )
Ketinit()
FnameR='diffeq/p011.r'
Fnameout='s0602diffeq.txt'
arccos=acos; arcsin=asin; arctan=atan

Setwindow(c(-4,10), c(-2,5))
A=c(-4,-3);Assignadd('A',A)
B=c(10,-3);Assignadd('B',B)
C=c(-2.48112,-3);Assignadd('C',C)
D=c(0,5);Assignadd('D',D)
E=c(0,-2);Assignadd('E',E)
F=c(0,2.208198);Assignadd('F',F)
sgAB=Listplot(c(A,B))
Setax("","","sw","","sw")
de1=Deqplot('c(xN1,xN2)`=c(xN2,-0.5*xN2-xN1)','t=c(0,(4))',0,c(2.208198,0),c(1,2),'Num=50')
PtL=list()
GrL=list()

# Windisp(GrL)

if(1==1){

Openfile('/Users/takatoosetsuo/ketcindy/ketsample/samples/s06animation/fig/diffeq/p011.tex','1cm','Cdy=s0602diffeq.cdy')
Drwline(de1)
Closefile('1')

}

print( 11 )
print( 0.143 )
Ketinit()
FnameR='diffeq/p012.r'
Fnameout='s0602diffeq.txt'
arccos=acos; arcsin=asin; arctan=atan

Setwindow(c(-4,10), c(-2,5))
A=c(-4,-3);Assignadd('A',A)
B=c(10,-3);Assignadd('B',B)
C=c(-2.48112,-3);Assignadd('C',C)
D=c(0,5);Assignadd('D',D)
E=c(0,-2);Assignadd('E',E)
F=c(0,2.208198);Assignadd('F',F)
sgAB=Listplot(c(A,B))
Setax("","","sw","","sw")
de1=Deqplot('c(xN1,xN2)`=c(xN2,-0.5*xN2-xN1)','t=c(0,(4.4))',0,c(2.208198,0),c(1,2),'Num=50')
PtL=list()
GrL=list()

# Windisp(GrL)

if(1==1){

Openfile('/Users/takatoosetsuo/ketcindy/ketsample/samples/s06animation/fig/diffeq/p012.tex','1cm','Cdy=s0602diffeq.cdy')
Drwline(de1)
Closefile('1')

}

print( 12 )
print( 0.166 )
Ketinit()
FnameR='diffeq/p013.r'
Fnameout='s0602diffeq.txt'
arccos=acos; arcsin=asin; arctan=atan

Setwindow(c(-4,10), c(-2,5))
A=c(-4,-3);Assignadd('A',A)
B=c(10,-3);Assignadd('B',B)
C=c(-2.48112,-3);Assignadd('C',C)
D=c(0,5);Assignadd('D',D)
E=c(0,-2);Assignadd('E',E)
F=c(0,2.208198);Assignadd('F',F)
sgAB=Listplot(c(A,B))
Setax("","","sw","","sw")
de1=Deqplot('c(xN1,xN2)`=c(xN2,-0.5*xN2-xN1)','t=c(0,(4.8))',0,c(2.208198,0),c(1,2),'Num=50')
PtL=list()
GrL=list()

# Windisp(GrL)

if(1==1){

Openfile('/Users/takatoosetsuo/ketcindy/ketsample/samples/s06animation/fig/diffeq/p013.tex','1cm','Cdy=s0602diffeq.cdy')
Drwline(de1)
Closefile('1')

}

print( 13 )
print( 0.198 )
Ketinit()
FnameR='diffeq/p014.r'
Fnameout='s0602diffeq.txt'
arccos=acos; arcsin=asin; arctan=atan

Setwindow(c(-4,10), c(-2,5))
A=c(-4,-3);Assignadd('A',A)
B=c(10,-3);Assignadd('B',B)
C=c(-2.48112,-3);Assignadd('C',C)
D=c(0,5);Assignadd('D',D)
E=c(0,-2);Assignadd('E',E)
F=c(0,2.208198);Assignadd('F',F)
sgAB=Listplot(c(A,B))
Setax("","","sw","","sw")
de1=Deqplot('c(xN1,xN2)`=c(xN2,-0.5*xN2-xN1)','t=c(0,(5.2))',0,c(2.208198,0),c(1,2),'Num=50')
PtL=list()
GrL=list()

# Windisp(GrL)

if(1==1){

Openfile('/Users/takatoosetsuo/ketcindy/ketsample/samples/s06animation/fig/diffeq/p014.tex','1cm','Cdy=s0602diffeq.cdy')
Drwline(de1)
Closefile('1')

}

print( 14 )
print( 0.216 )
Ketinit()
FnameR='diffeq/p015.r'
Fnameout='s0602diffeq.txt'
arccos=acos; arcsin=asin; arctan=atan

Setwindow(c(-4,10), c(-2,5))
A=c(-4,-3);Assignadd('A',A)
B=c(10,-3);Assignadd('B',B)
C=c(-2.48112,-3);Assignadd('C',C)
D=c(0,5);Assignadd('D',D)
E=c(0,-2);Assignadd('E',E)
F=c(0,2.208198);Assignadd('F',F)
sgAB=Listplot(c(A,B))
Setax("","","sw","","sw")
de1=Deqplot('c(xN1,xN2)`=c(xN2,-0.5*xN2-xN1)','t=c(0,(5.6))',0,c(2.208198,0),c(1,2),'Num=50')
PtL=list()
GrL=list()

# Windisp(GrL)

if(1==1){

Openfile('/Users/takatoosetsuo/ketcindy/ketsample/samples/s06animation/fig/diffeq/p015.tex','1cm','Cdy=s0602diffeq.cdy')
Drwline(de1)
Closefile('1')

}

print( 15 )
print( 0.222 )
Ketinit()
FnameR='diffeq/p016.r'
Fnameout='s0602diffeq.txt'
arccos=acos; arcsin=asin; arctan=atan

Setwindow(c(-4,10), c(-2,5))
A=c(-4,-3);Assignadd('A',A)
B=c(10,-3);Assignadd('B',B)
C=c(-2.48112,-3);Assignadd('C',C)
D=c(0,5);Assignadd('D',D)
E=c(0,-2);Assignadd('E',E)
F=c(0,2.208198);Assignadd('F',F)
sgAB=Listplot(c(A,B))
Setax("","","sw","","sw")
de1=Deqplot('c(xN1,xN2)`=c(xN2,-0.5*xN2-xN1)','t=c(0,(6))',0,c(2.208198,0),c(1,2),'Num=50')
PtL=list()
GrL=list()

# Windisp(GrL)

if(1==1){

Openfile('/Users/takatoosetsuo/ketcindy/ketsample/samples/s06animation/fig/diffeq/p016.tex','1cm','Cdy=s0602diffeq.cdy')
Drwline(de1)
Closefile('1')

}

print( 16 )
print( 0.235 )
Ketinit()
FnameR='diffeq/p017.r'
Fnameout='s0602diffeq.txt'
arccos=acos; arcsin=asin; arctan=atan

Setwindow(c(-4,10), c(-2,5))
A=c(-4,-3);Assignadd('A',A)
B=c(10,-3);Assignadd('B',B)
C=c(-2.48112,-3);Assignadd('C',C)
D=c(0,5);Assignadd('D',D)
E=c(0,-2);Assignadd('E',E)
F=c(0,2.208198);Assignadd('F',F)
sgAB=Listplot(c(A,B))
Setax("","","sw","","sw")
de1=Deqplot('c(xN1,xN2)`=c(xN2,-0.5*xN2-xN1)','t=c(0,(6.4))',0,c(2.208198,0),c(1,2),'Num=50')
PtL=list()
GrL=list()

# Windisp(GrL)

if(1==1){

Openfile('/Users/takatoosetsuo/ketcindy/ketsample/samples/s06animation/fig/diffeq/p017.tex','1cm','Cdy=s0602diffeq.cdy')
Drwline(de1)
Closefile('1')

}

print( 17 )
print( 0.246 )
Ketinit()
FnameR='diffeq/p018.r'
Fnameout='s0602diffeq.txt'
arccos=acos; arcsin=asin; arctan=atan

Setwindow(c(-4,10), c(-2,5))
A=c(-4,-3);Assignadd('A',A)
B=c(10,-3);Assignadd('B',B)
C=c(-2.48112,-3);Assignadd('C',C)
D=c(0,5);Assignadd('D',D)
E=c(0,-2);Assignadd('E',E)
F=c(0,2.208198);Assignadd('F',F)
sgAB=Listplot(c(A,B))
Setax("","","sw","","sw")
de1=Deqplot('c(xN1,xN2)`=c(xN2,-0.5*xN2-xN1)','t=c(0,(6.8))',0,c(2.208198,0),c(1,2),'Num=50')
PtL=list()
GrL=list()

# Windisp(GrL)

if(1==1){

Openfile('/Users/takatoosetsuo/ketcindy/ketsample/samples/s06animation/fig/diffeq/p018.tex','1cm','Cdy=s0602diffeq.cdy')
Drwline(de1)
Closefile('1')

}

print( 18 )
print( 0.26 )
Ketinit()
FnameR='diffeq/p019.r'
Fnameout='s0602diffeq.txt'
arccos=acos; arcsin=asin; arctan=atan

Setwindow(c(-4,10), c(-2,5))
A=c(-4,-3);Assignadd('A',A)
B=c(10,-3);Assignadd('B',B)
C=c(-2.48112,-3);Assignadd('C',C)
D=c(0,5);Assignadd('D',D)
E=c(0,-2);Assignadd('E',E)
F=c(0,2.208198);Assignadd('F',F)
sgAB=Listplot(c(A,B))
Setax("","","sw","","sw")
de1=Deqplot('c(xN1,xN2)`=c(xN2,-0.5*xN2-xN1)','t=c(0,(7.2))',0,c(2.208198,0),c(1,2),'Num=50')
PtL=list()
GrL=list()

# Windisp(GrL)

if(1==1){

Openfile('/Users/takatoosetsuo/ketcindy/ketsample/samples/s06animation/fig/diffeq/p019.tex','1cm','Cdy=s0602diffeq.cdy')
Drwline(de1)
Closefile('1')

}

print( 19 )
print( 0.277 )
Ketinit()
FnameR='diffeq/p020.r'
Fnameout='s0602diffeq.txt'
arccos=acos; arcsin=asin; arctan=atan

Setwindow(c(-4,10), c(-2,5))
A=c(-4,-3);Assignadd('A',A)
B=c(10,-3);Assignadd('B',B)
C=c(-2.48112,-3);Assignadd('C',C)
D=c(0,5);Assignadd('D',D)
E=c(0,-2);Assignadd('E',E)
F=c(0,2.208198);Assignadd('F',F)
sgAB=Listplot(c(A,B))
Setax("","","sw","","sw")
de1=Deqplot('c(xN1,xN2)`=c(xN2,-0.5*xN2-xN1)','t=c(0,(7.6))',0,c(2.208198,0),c(1,2),'Num=50')
PtL=list()
GrL=list()

# Windisp(GrL)

if(1==1){

Openfile('/Users/takatoosetsuo/ketcindy/ketsample/samples/s06animation/fig/diffeq/p020.tex','1cm','Cdy=s0602diffeq.cdy')
Drwline(de1)
Closefile('1')

}

print( 20 )
print( 0.295 )
Ketinit()
FnameR='diffeq/p021.r'
Fnameout='s0602diffeq.txt'
arccos=acos; arcsin=asin; arctan=atan

Setwindow(c(-4,10), c(-2,5))
A=c(-4,-3);Assignadd('A',A)
B=c(10,-3);Assignadd('B',B)
C=c(-2.48112,-3);Assignadd('C',C)
D=c(0,5);Assignadd('D',D)
E=c(0,-2);Assignadd('E',E)
F=c(0,2.208198);Assignadd('F',F)
sgAB=Listplot(c(A,B))
Setax("","","sw","","sw")
de1=Deqplot('c(xN1,xN2)`=c(xN2,-0.5*xN2-xN1)','t=c(0,(8))',0,c(2.208198,0),c(1,2),'Num=50')
PtL=list()
GrL=list()

# Windisp(GrL)

if(1==1){

Openfile('/Users/takatoosetsuo/ketcindy/ketsample/samples/s06animation/fig/diffeq/p021.tex','1cm','Cdy=s0602diffeq.cdy')
Drwline(de1)
Closefile('1')

}

print( 21 )
print( 0.309 )
Ketinit()
FnameR='diffeq/p022.r'
Fnameout='s0602diffeq.txt'
arccos=acos; arcsin=asin; arctan=atan

Setwindow(c(-4,10), c(-2,5))
A=c(-4,-3);Assignadd('A',A)
B=c(10,-3);Assignadd('B',B)
C=c(-2.48112,-3);Assignadd('C',C)
D=c(0,5);Assignadd('D',D)
E=c(0,-2);Assignadd('E',E)
F=c(0,2.208198);Assignadd('F',F)
sgAB=Listplot(c(A,B))
Setax("","","sw","","sw")
de1=Deqplot('c(xN1,xN2)`=c(xN2,-0.5*xN2-xN1)','t=c(0,(8.4))',0,c(2.208198,0),c(1,2),'Num=50')
PtL=list()
GrL=list()

# Windisp(GrL)

if(1==1){

Openfile('/Users/takatoosetsuo/ketcindy/ketsample/samples/s06animation/fig/diffeq/p022.tex','1cm','Cdy=s0602diffeq.cdy')
Drwline(de1)
Closefile('1')

}

print( 22 )
print( 0.315 )
Ketinit()
FnameR='diffeq/p023.r'
Fnameout='s0602diffeq.txt'
arccos=acos; arcsin=asin; arctan=atan

Setwindow(c(-4,10), c(-2,5))
A=c(-4,-3);Assignadd('A',A)
B=c(10,-3);Assignadd('B',B)
C=c(-2.48112,-3);Assignadd('C',C)
D=c(0,5);Assignadd('D',D)
E=c(0,-2);Assignadd('E',E)
F=c(0,2.208198);Assignadd('F',F)
sgAB=Listplot(c(A,B))
Setax("","","sw","","sw")
de1=Deqplot('c(xN1,xN2)`=c(xN2,-0.5*xN2-xN1)','t=c(0,(8.8))',0,c(2.208198,0),c(1,2),'Num=50')
PtL=list()
GrL=list()

# Windisp(GrL)

if(1==1){

Openfile('/Users/takatoosetsuo/ketcindy/ketsample/samples/s06animation/fig/diffeq/p023.tex','1cm','Cdy=s0602diffeq.cdy')
Drwline(de1)
Closefile('1')

}

print( 23 )
print( 0.325 )
Ketinit()
FnameR='diffeq/p024.r'
Fnameout='s0602diffeq.txt'
arccos=acos; arcsin=asin; arctan=atan

Setwindow(c(-4,10), c(-2,5))
A=c(-4,-3);Assignadd('A',A)
B=c(10,-3);Assignadd('B',B)
C=c(-2.48112,-3);Assignadd('C',C)
D=c(0,5);Assignadd('D',D)
E=c(0,-2);Assignadd('E',E)
F=c(0,2.208198);Assignadd('F',F)
sgAB=Listplot(c(A,B))
Setax("","","sw","","sw")
de1=Deqplot('c(xN1,xN2)`=c(xN2,-0.5*xN2-xN1)','t=c(0,(9.2))',0,c(2.208198,0),c(1,2),'Num=50')
PtL=list()
GrL=list()

# Windisp(GrL)

if(1==1){

Openfile('/Users/takatoosetsuo/ketcindy/ketsample/samples/s06animation/fig/diffeq/p024.tex','1cm','Cdy=s0602diffeq.cdy')
Drwline(de1)
Closefile('1')

}

print( 24 )
print( 0.332 )
Ketinit()
FnameR='diffeq/p025.r'
Fnameout='s0602diffeq.txt'
arccos=acos; arcsin=asin; arctan=atan

Setwindow(c(-4,10), c(-2,5))
A=c(-4,-3);Assignadd('A',A)
B=c(10,-3);Assignadd('B',B)
C=c(-2.48112,-3);Assignadd('C',C)
D=c(0,5);Assignadd('D',D)
E=c(0,-2);Assignadd('E',E)
F=c(0,2.208198);Assignadd('F',F)
sgAB=Listplot(c(A,B))
Setax("","","sw","","sw")
de1=Deqplot('c(xN1,xN2)`=c(xN2,-0.5*xN2-xN1)','t=c(0,(9.6))',0,c(2.208198,0),c(1,2),'Num=50')
PtL=list()
GrL=list()

# Windisp(GrL)

if(1==1){

Openfile('/Users/takatoosetsuo/ketcindy/ketsample/samples/s06animation/fig/diffeq/p025.tex','1cm','Cdy=s0602diffeq.cdy')
Drwline(de1)
Closefile('1')

}

print( 25 )
print( 0.342 )
Ketinit()
FnameR='diffeq/p026.r'
Fnameout='s0602diffeq.txt'
arccos=acos; arcsin=asin; arctan=atan

Setwindow(c(-4,10), c(-2,5))
A=c(-4,-3);Assignadd('A',A)
B=c(10,-3);Assignadd('B',B)
C=c(-2.48112,-3);Assignadd('C',C)
D=c(0,5);Assignadd('D',D)
E=c(0,-2);Assignadd('E',E)
F=c(0,2.208198);Assignadd('F',F)
sgAB=Listplot(c(A,B))
Setax("","","sw","","sw")
de1=Deqplot('c(xN1,xN2)`=c(xN2,-0.5*xN2-xN1)','t=c(0,(10))',0,c(2.208198,0),c(1,2),'Num=50')
PtL=list()
GrL=list()

# Windisp(GrL)

if(1==1){

Openfile('/Users/takatoosetsuo/ketcindy/ketsample/samples/s06animation/fig/diffeq/p026.tex','1cm','Cdy=s0602diffeq.cdy')
Drwline(de1)
Closefile('1')

}

print( 26 )
print( 0.348 )
