// s : 2014.08.25

function Out=Symb3data(Moji,Size,Kaiten,NV,Pos)
    if type(Moji)==10 then
        Tmp=Symbdata(Moji);
        GY1=Tmp(2)
    else
        GY1=Moji
    end
    GY1=Scaledata(GY1,Size,Size);
    GY1=Rotatedata(GY1,Kaiten*%pi/180);
    A=NV(1); B=NV(2); C=NV(3);
    if A^2+B^2==0 then
        E1=[1,0,0];
        E2=[0,1,0];
    else
        E1=[B,-A,0];
        E2=[-A*C,-B*C,A^2+B^2];
        D=det([E1;E2;NV]);
        if D<0 then
            E1=-E1
        end
        E1=E1/norm(E1);
        E2=E2/norm(E2);
    end
    deff("Out=Em(X,Y)","Out=[E1(1)*X+E2(1)*Y,E1(2)*X+E2(2)*Y,E1(3)*X+E2(3)*Y]");
    GY1=Embed(GY1,Em);
    GY1=Translate3data(GY1,Pos);
    Out=Flattenlist(GY1);
endfunction
