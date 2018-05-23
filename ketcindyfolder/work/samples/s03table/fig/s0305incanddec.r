# date time=2018/4/8 09:35:45

source('/Applications/KeTTeX.app/texlive/texmf-dist/scripts/ketcindy/ketlib/ketpiccurrent.r')
Ketinit()
cat(ThisVersion,'\n')
Fnametex='s0305incanddec.tex'
FnameR='s0305incanddec.r'
Fnameout='s0305incanddec.txt'
arccos=acos; arcsin=asin; arctan=atan

Setwindow(c(-0,10.5), c(-0,12))
sgc0r0r5=Listplot(c(c(0,12),c(0,0)))
sgc1r0r5=Listplot(c(c(1.5,12),c(1.5,0)))
sgc2r0r5=Listplot(c(c(3,12),c(3,0)))
sgc3r0r5=Listplot(c(c(4.5,12),c(4.5,0)))
sgc4r0r5=Listplot(c(c(6,12),c(6,0)))
sgc5r0r5=Listplot(c(c(7.5,12),c(7.5,0)))
sgc6r0r5=Listplot(c(c(9,12),c(9,0)))
sgc7r0r5=Listplot(c(c(10.5,12),c(10.5,0)))
sgr0c0c7=Listplot(c(c(0,12),c(10.5,12)))
sgr1c0c7=Listplot(c(c(0,11),c(10.5,11)))
sgr2c0c7=Listplot(c(c(0,10),c(10.5,10)))
sgr3c0c7=Listplot(c(c(0,9),c(10.5,9)))
sgr4c0c7=Listplot(c(c(0,8),c(10.5,8)))
sgr5c0c7=Listplot(c(c(0,0),c(10.5,0)))
sgc1r0r4=Listplot(c(c(1.5,12),c(1.5,8)))
sgc2r0r4=Listplot(c(c(3,12),c(3,8)))
sgc3r0r4=Listplot(c(c(4.5,12),c(4.5,8)))
sgc4r0r4=Listplot(c(c(6,12),c(6,8)))
sgc5r0r4=Listplot(c(c(7.5,12),c(7.5,8)))
sgc6r0r4=Listplot(c(c(9,12),c(9,8)))
sgc1r1c2r2=Listplot(c(c(1.5,11),c(3,10)))
sgc2r1c1r2=Listplot(c(c(3,11),c(1.5,10)))
sgc1r2c2r3=Listplot(c(c(1.5,10),c(3,9)))
sgc2r2c1r3=Listplot(c(c(3,10),c(1.5,9)))
sgc1r3c2r4=Listplot(c(c(1.5,9),c(3,8)))
sgc2r3c1r4=Listplot(c(c(3,9),c(1.5,8)))
PtL=list()
GrL=list()

# Windisp(GrL)

if(1==1){

Openfile('/Users/takatoosetsuo/ketcindy/ketsample/samples/s03table/fig/s0305incanddec.tex','1cm','Cdy=s0305incanddec.cdy')
Drwline(sgc0r0r5)
Drwline(sgc7r0r5)
Drwline(sgr0c0c7)
Drwline(sgr1c0c7)
Drwline(sgr2c0c7)
Drwline(sgr3c0c7)
Drwline(sgr4c0c7)
Drwline(sgr5c0c7)
Drwline(sgc1r0r4)
Drwline(sgc2r0r4)
Drwline(sgc3r0r4)
Drwline(sgc4r0r4)
Drwline(sgc5r0r4)
Drwline(sgc6r0r4)
Drwline(sgc1r1c2r2)
Drwline(sgc2r1c1r2)
Drwline(sgc1r2c2r3)
Drwline(sgc2r2c1r3)
Drwline(sgc1r3c2r4)
Drwline(sgc2r3c1r4)
Letter(c(0.75,11.5),"c","$x$")
Letter(c(2.25,11.5),"c","$0$")
Letter(c(3.75,11.5),"c","$\\cdots$")
Letter(c(5.25,11.5),"c","$e$")
Letter(c(6.75,11.5),"c","$\\cdots$")
Letter(c(8.25,11.5),"c","$e\\sqrt{e}$")
Letter(c(9.75,11.5),"c","$\\cdots$")
Letter(c(0.75,10.5),"c","$y'$")
Letter(c(2.25,10.5),"c","$$")
Letter(c(3.75,10.5),"c","$+$")
Letter(c(5.25,10.5),"c","$0$")
Letter(c(6.75,10.5),"c","$-$")
Letter(c(8.25,10.5),"c","$-$")
Letter(c(9.75,10.5),"c","$-$")
Letter(c(0.75,9.5),"c","$y''$")
Letter(c(2.25,9.5),"c","$$")
Letter(c(3.75,9.5),"c","$-$")
Letter(c(5.25,9.5),"c","$-$")
Letter(c(6.75,9.5),"c","$-$")
Letter(c(8.25,9.5),"c","$0$")
Letter(c(9.75,9.5),"c","$+$")
Letter(c(0.75,8.5),"c","$y$")
Letter(c(2.25,8.5),"c","$$")
Letter(c(3.75,8.5),"c","$$")
Letter(c(5.25,8.5),"c","$10/e$")
Letter(c(6.75,8.5),"c","$$")
Letter(c(8.25,8.5),"c","$15/e\\sqrt{e}$")
Letter(c(9.75,8.5),"c","$$")
Letter(c(0.75,8.5),"c","$y$")
Letter(c(2.25,8.5),"c","$$")
Letter(c(3.75,8.5),"c","$$\\nerarrow$$")
Letter(c(5.25,8.5),"c","$10/e$")
Letter(c(6.75,8.5),"c","$$\\serarrow$$")
Letter(c(8.25,8.5),"c","$15/e\\sqrt{e}$")
Letter(c(9.75,8.5),"c","$$\\selarrow$$")
Closefile('0')

}

quit()