double Xval[DsizeS], Yval[DsizeS], Zval[DsizeS][DsizeS];

double Implicitdata[DsizeL][2];
double Cuspsplitpt[DsizeL][2];
double Cusppt[DsizeM][2];
double Otherpartition [DsizeM];
double Partitionpt[DsizeM][2];
double Cuspdata[DsizeM];
double Wirept[DsizeM][3];
double Hiddendata[DsizeL][3];
double Borderpt[DsizeM][2];
double Borderhiddendata[DsizeL][3];
double Surf[DsizeL][3];
double Crvdata[DsizeL][3];
double Wiredata[DsizeLL][3];

int output3(const char *var, const char *fname, int level, double out[][3]);
int output3h(const char *var, const char *varh, const char *fname, double out[][3]);
int writedataC(const char *fname, double out[][3]);
int readdataC(const char *fname, double data[][3]);
void parapt(double pt3[3],double pt2[2]);
int projpara(double p3[][3], double p2[][2]);
double invparapt(double ph, double fh[][2], double fk[][3],double out[3]);
int surfcurve(int level, double crv[][2], double pdata[][3]);
int xyzax3data(double x0, double x1, double y0, double y1, double z0, double z1, 
                           double out[][3]);
void evlptablepara(void);
int implicitplot(double out[][2]);
int cuspsplitpara(double pdata[][2], double outkL[][3]);
int makexybdy(double ehL[][2]);
int partitionseg(double fig[][2],double gL[][2], int ns, double out[]);
void makevaltablepth(double pta[3]);
int pthiddenQ(double pta[3], int uveq, double eps[2]);
int nohiddenpara2(double paL[], double fk[][3], int uveq, double figkL[][3]);
int borderparadata(double fkL[][3], double fsL[][3]);
int sfbdparadata(double outd3[][3]);
void makevaltablemeet(double pa[3], double vec[3], double eps0);
int meetpoints(double pta[3], double ptb[3], double eps, double ptL[][3]);
int crvsfparadata(double fkL[][3], double fbdkL[][3], int sepflg, double out[][3]);
int sfcutdata(int ch, double ekL[][3]);
int crv3onsfparadata(double fk[][3], double fbdyd3[][3], double out[][3]);
int wireparadata(double bdyk[][3],  double udv[], double vdv[], int num, 
          double fsL[][3]);
int projcoordcurve(double curve[][3], double out[][3]);
int kukannozoku(double jokyo[2], double kukanL[][2], double res[][2]);
int skeletondata3(double data[][3], double r00, double eps1, double eps2,
          double allres[][3]);

double cutfun(int ch,double u, double v);
