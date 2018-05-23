# date time=2018/4/8 15:48:00

source('/Applications/KeTTeX.app/texlive/texmf-dist/scripts/ketcindy/ketlib/ketpiccurrent.r')
Ketinit()
cat(ThisVersion,'\n')
Fnametex='cycloid/p001.tex'
FnameR='cycloid/p001.r'
Fnameout='s0601cycloid.txt'
arccos=acos; arcsin=asin; arctan=atan

Setwindow(c(-3.72,10.12), c(-3.28,3.52))
A=c(-3.72168,-4.27508);Assignadd('A',A)
B=c(10.12297,-4.27508);Assignadd('B',B)
C=c(1.41424,-4.27508);Assignadd('C',C)
sgAB=Listplot(c(A,B))
cr1=Circledata(c(c(0,1),c(1,1)))
Setax("","","sw","","sw")
cr2=Circledata(c(c(0,1),c(1,1)))
pt2=Pointdata(list(0,0))
PtL=list()
GrL=list()

# Windisp(GrL)

if(1==1){

Openfile('/Users/takatoosetsuo/ketcindy/ketsample/samples/s06animation/fig/cycloid/p001.tex','1cm','Cdy=s0601cycloid.cdy')
Setcolor("red")
Drwline(cr1)
Setcolor("black")
Drwline(cr2)
Setpt(4)
Setpen(0.5)
Drwpt(list(pt2))
Setpen(1)
Setpt(1)
Closefile('1')

}

quit()
