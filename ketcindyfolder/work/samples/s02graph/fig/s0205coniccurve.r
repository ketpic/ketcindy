# date time=2018/4/8 09:24:33

source('/Applications/KeTTeX.app/texlive/texmf-dist/scripts/ketcindy/ketlib/ketpiccurrent.r')
Ketinit()
cat(ThisVersion,'\n')
Fnametex='s0205coniccurve.tex'
FnameR='s0205coniccurve.r'
Fnameout='s0205coniccurve.txt'
arccos=acos; arcsin=asin; arctan=atan

Setwindow(c(-5,5), c(-5,5))
A=c(-2,0);Assignadd('A',A)
B=c(2,0);Assignadd('B',B)
C=c(1.796855,1.547291);Assignadd('C',C)
gp1hyp1=Paramplot('c(0+1.26973*(exp(t)+exp(-t))/2,0+1.54525*(exp(t)-exp(-t))/2)','t=c(-5/2,5/2)')
gp1hyp2=Paramplot('c(0-1.26973*(exp(t)+exp(-t))/2,0+1.54525*(exp(t)-exp(-t))/2)','t=c(-5/2,5/2)')
rt1hyp1=Rotatedata(gp1hyp1,0,c(-2,0))
rt1hyp2=Rotatedata(gp1hyp2,0,c(-2,0))
ln1asy1=Lineplot(c(c(1.26973,1.54525),c(-1.26973,-1.54525)))
ln1asy2=Lineplot(c(c(-1.26973,1.54525),c(1.26973,-1.54525)))
rt1asy1=Rotatedata(ln1asy1,0,c(-2,0))
rt1asy2=Rotatedata(ln1asy2,0,c(-2,0))
PtL=list()
GrL=list()

# Windisp(GrL)

if(1==1){

Openfile('/Users/takatoosetsuo/ketcindy/ketsample/samples/s02graph/fig/s0205coniccurve.tex','1cm','Cdy=s0205coniccurve.cdy')
Drwline(rt1hyp1)
Drwline(rt1hyp2)
Dashline(rt1asy1)
Dashline(rt1asy2)
Closefile('1')

}

quit()
