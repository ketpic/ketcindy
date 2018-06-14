Ketinit();
//for 3d, remove the above and add:
//Start3d([]); // []:list of exclusion points. e.g. [A,B]

//Changework(Dircdy);

Ch=["3d"];

if(contains(Ch,"slide"),
 
Slidework(Dircdy);
 //Addpackage(["pict2e"]);
 //Addpackage(["[dvipdfmx]{media9}","[dvipdfmx]{animate}","ketmedia"]);
Setslidebody("black",0.1);
Setslidehyper(["Size=1"]);
Texcom("\Large\bf\boldmath");

Settitle([
 "s{60}{20}{Title}",
 "s{60}{50}{Name}",
 "s{60}{60}{Affliation}",
 "s{60}{70}{Date}"
],["Color=[1,1,0,0]"]);

);//end of slide

if(contains(Ch,"3d"),

Putaxes3d(5);
Xyzax3data("","x=[-5,5]","y=[-5,5]","z=[-5,5]");
//objdt=Concatobj([[X,Y,Z]]);// [X3d,Y3d,Z3d] is OK.
//VertexEdgeFace("1",objdt);
Ch=[];
if(contains(Ch,0),
  Nohiddenbyfaces("1","phf3d1",["dr"],["do"]);
);
if(contains(Ch,1),
 Skeletondatacindy("1",[1.5]);
);

);//end of 3d

if(contains(Ch,"animation"),

Slider("A-C-B",[XMIN,YMIN-1],[XMAX,YMIN-1]);

mf(s):=(
  regional(fun,rng);
);
Setpara("foldername","mf(s)","s=[0,10]",["m","Div=25"],
 ["Frate=10","Scale=1","OpA=","Title=Name"]);
mf(C.x-A.x);

);//end of animation

Windispg();

