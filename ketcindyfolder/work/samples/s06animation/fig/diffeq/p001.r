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

quit()
