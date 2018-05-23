# date time=2018/4/8 16:44:37

source('/Applications/KeTTeX.app/texlive/texmf-dist/scripts/ketcindy/ketlib/ketpiccurrent.r')
Ketinit()
cat(ThisVersion,'\n')
Fnametex='diffeq/p024.tex'
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

quit()
