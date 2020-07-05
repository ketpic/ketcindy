double Xval[DsizeS], Yval[DsizeS], Zval[DsizeS][DsizeS];

//////////////////////
short Ch=1;
/////////////////////

//double Implicitdata[DsizeL][2]; //180320
double Cuspsplitpt[DsizeL][2];
double Cusppt[DsizeM][2];
double Otherpartition [DsizeM];
//double Partitionpt[DsizeM][2];
double Cuspdata[DsizeM];
double Wirept[DsizeM][3];
double Hiddendata[DsizeL][3];
double Borderpt[DsizeM][2];
double Borderhiddendata[DsizeL][3];
double Surf[DsizeL][3];
double Crvdata[DsizeL][3];
//double Wiredata[DsizeLL][3];

int output3(short head,const char *wa,const char *var, const char *fname,double out[][3]);
int output3h(const char *wa,const char *var, const char *varh, const char *fname, double out[][3]);
void outputend(const char *fname);
int writedataC(const char *fname, double out[][3]);
int readdataC(const char *fname, double data[][3]);
void readoutdata3(const char *fname, const char *var, double data[][3]);
void parapt(double pt3[3],double pt2[2]);
double zparapt(double p[3]);
int projpara(double p3[][3], double p2[][2]);
double invparapt(double ph, double fh[][2], double fk[][3],double out[3]);
void surfcurve(short ch,double crv[][2], double pdata[][3]);
double evlpfun(short ch, double u, double v);
int envelopedata(short ch, double out[][2]);
int cuspsplitpara(short ch,double pdata[][2], double outkL[][3]);
int makexybdy(short ch,double ehL[][2]);
void partitionseg(double fig[][2],double gL[][2], int ns, double parL[]);
double funpthiddenQ(short ch,double u, double v,double pa[3]);
int pthiddenQ(short ch,double pta[3], int uveq,double out[4]);
int nohiddenpara2(short ch,double paL[], double fk[][3], int uveq, double figkL[][3]);
void borderparadata(short ch,double fkL[][3], double fsL[][3]);
int dropnumlistcrv3(double qd[][3], double eps1, int out[]);
void sfbdparadata(short ch,double outd3[][3]);
double funmeet(short ch,double u, double v,double pa[3], double vec[3]);
void meetpoints(short ch,double pta[3], double ptb[3], int uveq,double out[][3]);
void crvsfparadata(short ch,double fkL[][3], double fbdkL[][3], int sepflg, double out[][3]);
void crv3onsfparadata(short ch,double fk[][3], double fbdyd3[][3], double out[][3]);
void crv2onsfparadata(short ch,double fh[][2], double fbdyd3[][3], double out[][3]);
void intersectcrvsf(const char *wa, short chfd,double crv[][3],const char *fname);
void wireparadata(short ch,double bdyk[][3], double udata[], double vdata[],const char *fname,const char *fnameh);
void sfcutparadata(short chfd, short ncut, double fbdy3[][3],const char *fname,const char *fnameh);
int projcoordcurve(double curve[][3], double out[][3]);
int kukannozoku(double jokyo[2], double kukanL[][2], double res[][2]);
int skeletondata3(double data[][3], double r00, double eps1, double eps2,
          double allres[][3]);

double cutfun(short chfd,short chcut,double u, double v);
