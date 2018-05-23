# date time=2018/4/8 18:34:58

source('/Applications/KeTTeX.app/texlive/texmf-dist/scripts/ketcindy/ketlib/ketpiccurrent.r')
Ketinit()
cat(ThisVersion,'\n')
Fnametex='envelope/p003.tex'
FnameR='envelope/p003.r'
Fnameout='s0603envelope.txt'
arccos=acos; arcsin=asin; arctan=atan

Setwindow(c(-5,5), c(-5,5))
A=c(-5,-6);Assignadd('A',A)
B=c(5,-6);Assignadd('B',B)
C=c(-3.42395,-6);Assignadd('C',C)
sgAB=Listplot(c(A,B))
Setax("","","sw","","sw")
gr0=Plotdata('-(-5)*x+(-5)^2','x','Num=2')
gr1=Plotdata('-(-4.833333)*x+(-4.833333)^2','x','Num=2')
PtL=list()
GrL=list()

# Windisp(GrL)

if(1==1){

Openfile('/Users/takatoosetsuo/ketcindy/ketsample/samples/s06animation/fig/envelope/p003.tex','1cm','Cdy=s0603envelope.cdy')
Drwline(gr0)
Drwline(gr1)
Closefile('1')

}

quit()
