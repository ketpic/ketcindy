kL=keydownlist();
if(length(kL)>0,
  if(kL==[17,70], //Ctr+f (Figures)
    Viewtex();
    kc();
  );
  if(kL==[16,17,80], //Ctr+Shift+p (Parent)
    if(length(Shellparent)>0,
      Makeshell(),Makebat();
    );
    WritetoSci(2);
    kc();
  );
  if(kL==[17,74], //Ctr+j (Ketjsoff)
    Mkketcindyjs(append(KETJSOP,"Web=n"));
  );
  if(kL==[16,17,74], //Ctr+Shift+j (Ketjson)
    Mkketcindyjs(append(KETJSOP,"Web=yj"));
  );
);