cd('/Users/takatoosetsuo/ketcindy/ketsample/samples/s07slides/fig');//
Ketlib=lib("/Users/takatoosetsuo/ketcindy/ketlib/ketpicsciL5");//
Ketinit();//
Setwindow([(-2.5),(2.5)],[(-2.5),(2.5)]);
pi=%pi;////
fL=["pointoncircle/p001.sce","pointoncircle/p002.sce","pointoncircle/p003.sce","pointoncircle/p004.sce","pointoncircle/p005.sce","pointoncircle/p006.sce","pointoncircle/p007.sce","pointoncircle/p008.sce","pointoncircle/p009.sce","pointoncircle/p010.sce","pointoncircle/p011.sce","pointoncircle/p012.sce","pointoncircle/p013.sce","pointoncircle/p014.sce","pointoncircle/p015.sce","pointoncircle/p016.sce","pointoncircle/p017.sce","pointoncircle/p018.sce","pointoncircle/p019.sce","pointoncircle/p020.sce","pointoncircle/p021.sce","pointoncircle/p022.sce","pointoncircle/p023.sce","pointoncircle/p024.sce","pointoncircle/p025.sce","pointoncircle/p026.sce"]//
Dt=mgetl(fL(1));//
Dt=Dt(1:(size(Dt,1)-1),:)//
for I=2:size(fL,2),Tmp=mgetl(fL(I));N=size(Tmp,1)-1;Tmp1=Tmp(13:N,:);Dt=[Dt;Tmp1],end//
mputl(Dt,'pointoncircle/all.sce')//
exec('pointoncircle/all.sce',-1)//
mputl('||||','resultS.txt')//
quit()//
