cd('/Users/takatoosetsuo/ketcindy/ketsample/samples/s07slides/fig');//
Ketlib=lib("/Users/takatoosetsuo/ketcindy/ketlib/ketpicscifiles6");//
Ketinit();//
Setwindow([(-3),(8)],[(-1.5),(1.5)]);
pi=%pi;////
fL=["sinecurve/p001.sce","sinecurve/p002.sce","sinecurve/p003.sce","sinecurve/p004.sce","sinecurve/p005.sce","sinecurve/p006.sce","sinecurve/p007.sce","sinecurve/p008.sce","sinecurve/p009.sce","sinecurve/p010.sce","sinecurve/p011.sce","sinecurve/p012.sce","sinecurve/p013.sce","sinecurve/p014.sce","sinecurve/p015.sce","sinecurve/p016.sce","sinecurve/p017.sce","sinecurve/p018.sce","sinecurve/p019.sce","sinecurve/p020.sce","sinecurve/p021.sce","sinecurve/p022.sce","sinecurve/p023.sce","sinecurve/p024.sce","sinecurve/p025.sce","sinecurve/p026.sce","sinecurve/p027.sce","sinecurve/p028.sce","sinecurve/p029.sce","sinecurve/p030.sce","sinecurve/p031.sce"]//
Dt=mgetl(fL(1));//
Dt=Dt(1:(size(Dt,1)-1),:)//
for I=2:size(fL,2),Tmp=mgetl(fL(I));N=size(Tmp,1)-1;Tmp1=Tmp(13:N,:);Dt=[Dt;Tmp1],end//
mputl(Dt,'sinecurve/all.sce')//
exec('sinecurve/all.sce',-1)//
mputl('||||','resultS.txt')//
quit()//
