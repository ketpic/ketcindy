//20181024 memberi debugged (for null list )
//20180308 norm added

int length1(double gdata[]){
  return floor(gdata[0]+0.5);
}

int length2(double gdata[][2]){
  return floor(gdata[0][0]+0.5);
}

int length3(double gdata[][3]){
  return floor(gdata[0][0]+0.5);
}

int length4(double gdata[][4]){
  return floor(gdata[0][0]+0.5);
}

int length5(double gdata[][5]){
  return floor(gdata[0][0]+0.5);
}

int length6(double gdata[][6]){
  return floor(gdata[0][0]+0.5);
}

int length2i(int gdata[][2]){
  return gdata[0][0];
}

void copyd(int from, int upto, double q[], double p[]){
  int i;
  for(i=from; i<=upto; i++){
    p[i]=q[i];
  }
}

void copyi(int from, int upto, int q[], int p[]){
  int i;
  for(i=from; i<=upto; i++){
    p[i]=q[i];
  }
}

int push2(double x, double y, double ptL[][2]){
  int nall=length2(ptL);
  nall++;
  ptL[nall][0]=x; ptL[nall][1]=y;
  ptL[0][0]=nall;
  return nall;
}

int push3(double x, double y, double z, double ptL[][3]){
  int nall=length3(ptL);
  nall++;
  ptL[nall][0]=x; ptL[nall][1]=y; ptL[nall][2]=z;
  ptL[0][0]=nall;
  return nall;
}

int push4(double x, double y, double z, double w, double ptL[][4]){
  int nall=length4(ptL);
  nall++;
  ptL[nall][0]=x; ptL[nall][1]=y;
  ptL[nall][2]=z; ptL[nall][3]=w;
  ptL[0][0]=nall;
  return nall;
}

int push5(double x, double y, double z, double w, double u, double ptL[][5]){
  int nall=length5(ptL);
  nall++;
  ptL[nall][0]=x; ptL[nall][1]=y;
  ptL[nall][2]=z; ptL[nall][3]=w; ptL[nall][4]=u;
  ptL[0][0]=nall;
  return nall;
}

int push6(double x, double y, double z, double w, double u, double v,double ptL[][6]){
  int nall=ptL[0][0];
  nall++;
  ptL[nall][0]=x; ptL[nall][1]=y;ptL[nall][2]=z;
  ptL[nall][3]=w; ptL[nall][4]=u; ptL[nall][5]=v; 
  ptL[0][0]=nall;
  return nall;
}

void pull3(int num, double ptL[][3],double pt[3]){
  pt[0]=ptL[num][0]; pt[1]=ptL[num][1]; pt[2]=ptL[num][2]; 
}

void pull2(int num, double ptL[][2],double pt[2]){
  pt[0]=ptL[num][0]; pt[1]=ptL[num][1];
}

void pull4(int num, double ptL[][4],double pt[4]){
  pt[0]=ptL[num][0]; pt[1]=ptL[num][1];
  pt[2]=ptL[num][2]; pt[3]=ptL[num][3];
}

void pull5(int num, double ptL[][5],double pt[5]){
  pt[0]=ptL[num][0]; pt[1]=ptL[num][1];
  pt[2]=ptL[num][2]; pt[3]=ptL[num][3]; pt[4]=ptL[num][4];
}

void pull6(int num, double ptL[][6],double pt[6]){
  pt[0]=ptL[num][0]; pt[1]=ptL[num][1]; pt[2]=ptL[num][2]; 
  pt[3]=ptL[num][3]; pt[4]=ptL[num][4]; pt[5]=ptL[num][5]; 
}

int add1(double gdata[], double x){
  int nall;
  nall=length1(gdata);
  nall++;
  gdata[nall]=x;
  gdata[0]=nall;
  return nall;
}

int add2(double gdata[][2], double x, double y){
  int nall;
  nall=push2(x, y, gdata);
  return nall;
}

int add3(double gdata[][3], double x, double y, double z){
  int nall;
  nall=push3(x, y, z,gdata);
  return nall;
}

int addptd3(double gdata[][3], double pt[3]){
  int nall;
  nall=push3(pt[0],pt[1],pt[2],gdata);
  return nall;
}

int addptd2(double gdata[][2], double pt[2]){
  int nall;
  nall=push2(pt[0],pt[1],gdata);
  return nall;
}

int addptd4(double gdata[][4], double pt[4]){
  int nall;
  nall=push4(pt[0],pt[1],pt[2],pt[3],gdata);
  return nall;
}

int addptd5(double gdata[][5], double pt[5]){
  int nall;
  nall=push5(pt[0],pt[1],pt[2],pt[3],pt[4],gdata);
  return nall;
}

int addptd6(double gdata[][6], double pt[6]){
  int nall;
  nall=push6(pt[0],pt[1],pt[2],pt[3],pt[4],pt[5],gdata);
  return nall;
}

int appendd2(int level, int from,int upto, double gdata[][2],double mat[][2]){
  int j, np, nall=length2(mat);
  np=upto-from+1;
  if(np<0){np=0;}
  if(np>0){
    if(level>0){
      if(nall>0){
        nall=add2(mat,Inf, level);
      }
    }
    for(j=1; j<=np; j++){
      mat[nall+j][0]=gdata[from+j-1][0];
      mat[nall+j][1]=gdata[from+j-1][1];
    }
  }
  mat[0][0]=nall+np;
  return nall+np;
}

int appendd3(int level, int from,int upto, double gdata[][3],double mat[][3]){
  int j, np, nall=length3(mat);
  np=upto-from+1;
  if(np<0){np=0;}
  if(np>0){
    if(level>0){
      if(nall>0){
        nall=add3(mat,Inf, level, 0);
      }
    }
    for(j=1; j<=np; j++){
      mat[nall+j][0]=gdata[from+j-1][0];
      mat[nall+j][1]=gdata[from+j-1][1];
      mat[nall+j][2]=gdata[from+j-1][2];
    }
  }
  mat[0][0]=nall+np;
  return nall+np;
}

int appendd6(int level, int from,int upto, double gdata[][6],double mat[][6]){
  int j, np, nall=length6(mat);
  np=upto-from+1;
  if(np<0){np=0;}
  if(np>0){
    if(level>0){
      if(nall>0){
        nall=push6(Inf,level,0,0,0,0,mat);
      }
    }
    for(j=1; j<=np; j++){
      mat[nall+j][0]=gdata[from+j-1][0];
      mat[nall+j][1]=gdata[from+j-1][1];
      mat[nall+j][2]=gdata[from+j-1][2];
      mat[nall+j][3]=gdata[from+j-1][3];
      mat[nall+j][4]=gdata[from+j-1][4];
      mat[nall+j][5]=gdata[from+j-1][5];    }
  }
  mat[0][0]=nall+np;
  return nall+np;
}

int prependd2(int from,int upto, double gdata[][2],double mat[][2]){
  int j,np, nall=length2(mat);
  if(from<=upto){
    np=upto-from+1;
    for(j=nall; j>=1; j--){
      mat[np+j][0]=mat[j][0];
      mat[np+j][1]=mat[j][1];
    }
    for(j=1; j<=np; j++){
      mat[j][0]=gdata[from+j-1][0];
      mat[j][1]=gdata[from+j-1][1];
    }
  }else{
    np=from-upto+1;
    for(j=nall; j>=1; j--){
      mat[np+j][0]=mat[j][0];
      mat[np+j][1]=mat[j][1];
    }
    for(j=1; j<=np; j++){
      mat[nall+j][0]=gdata[from-j+1][0];
      mat[nall+j][1]=gdata[from-j+1][1];
    }
  }
  mat[0][0]=nall+np;
  return nall+np;
}

int prependd3(int from,int upto, double gdata[][3],double mat[][3]){
  int j,np, nall=length3(mat);
  if(from<=upto){
    np=upto-from+1;
    for(j=nall; j>=1; j--){
      mat[np+j][0]=mat[j][0];
      mat[np+j][1]=mat[j][1];
      mat[np+j][2]=mat[j][2];
    }
    for(j=1; j<=np; j++){
      mat[j][0]=gdata[from+j-1][0];
      mat[j][1]=gdata[from+j-1][1];
      mat[j][2]=gdata[from+j-1][2];
    }
  }else{
    np=from-upto+1;
    for(j=nall; j>=1; j--){
      mat[np+j][0]=mat[j][0];
      mat[np+j][1]=mat[j][1];
      mat[np+j][2]=mat[j][2];
    }
    for(j=1; j<=np; j++){
      mat[nall+j][0]=gdata[from-j+1][0];
      mat[nall+j][1]=gdata[from-j+1][1];
      mat[nall+j][2]=gdata[from-j+1][2];
    }
  }
  mat[0][0]=nall+np;
  return nall+np;
}

int appendd1(double num,double numvec[]){
  int n;
  n=floor(numvec[0]+0.5);
  numvec[n+1]=num;
  numvec[0]=n+1;
  return n+1;
}

int appendi1(int num,int numvec[]){
  int n;
  n=numvec[0];
  numvec[n+1]=num;
  numvec[0]=n+1;
  return n+1;
}

int prependd1(double num, double numvec[]){
  int i,n;
  n=numvec[0];
  for(i=n; i>=1; i--){
    numvec[i+1]=numvec[i];
  }
  numvec[1]=num;
  numvec[0]=n+1;
  return n+1;
}

int prependi1(int num, int numvec[]){
  int i,n;
  n=numvec[0];
  for(i=n; i>=1; i--){
    numvec[i+1]=numvec[i];
  }
  numvec[1]=num;
  numvec[0]=n+1;
  return n+1;
}

int removei2(int nrmv,int mat[][2]){
  int j,nall=mat[0][0];
  if(nall>0){
    for(j=nrmv; j<=nall-1; j++){
      mat[j][0]=mat[j+1][0];
      mat[j][1]=mat[j+1][1];
    }
    mat[0][0]=nall-1;
    return nall-1;
  }
  else{
    mat[0][0]=0;
    return 0;
  }
}

void removed3(int nrmv,double mat[][3]){
  int j,nall=length3(mat);
  if(nall>0){
    for(j=nrmv; j<=nall-1; j++){
      mat[j][0]=mat[j+1][0];
      mat[j][1]=mat[j+1][1];
      mat[j][2]=mat[j+1][2];
    }
    mat[0][0]=nall-1;
    return;
  }
}

int dataindexd1(double out[],int din[][2]){
  int n1=1, j, ctr=0, nall=floor(out[0]+0.5);
  if(nall==0){
    din[0][0]=0;
    return 0;
  }
  for(j=1; j<=nall; j++){
    if(out[j]>Inf-1){
        ctr++;
        din[ctr][0]=n1;
        din[ctr][1]=j-1;
        n1=j+1;
    }
  }
  ctr++;
  din[ctr][0]=n1;
  din[ctr][1]=nall;
  din[0][0]=ctr;
  return ctr;
}

int dataindexd2(int level,double out[][2],int din[][2]){
  int n1=1, j, ctr=0, nall=length2(out);
  if(nall==0){
    din[0][0]=0;
    return 0;
  }
  for(j=1; j<=nall; j++){
    if(out[j][0]>Inf-1){
      if((level==0) || (out[j][1]==level)){
        ctr++;
        din[ctr][0]=n1;
        din[ctr][1]=j-1;
        n1=j+1;
      }
    }
  }
  ctr++;
  din[ctr][0]=n1;
  din[ctr][1]=nall;
  din[0][0]=ctr;
  return ctr;
}

int dataindexd3(int level, double out[][3],int din[][2]){
  int n1=1, j, ctr=0, nall=length3(out);
  if(nall==0){
    din[0][0]=0;
    return 0;
  }
  for(j=1; j<=nall; j++){
    if(out[j][0]>Inf-1){
      if((level==0) || (out[j][1]==level)){
        ctr++;
        din[ctr][0]=n1;
        din[ctr][1]=j-1;
        n1=j+1;
      }
    }
  }
  ctr++;
  din[ctr][0]=n1;
  din[ctr][1]=nall;
  din[0][0]=ctr;
  return ctr;
}

int dataindexd4(int level, double out[][4],int din[][2]){
  int n1=1, j, ctr=0, nall=length4(out);
  if(nall==0){
    din[0][0]=0;
    return 0;
  }
  for(j=1; j<=nall; j++){
    if(out[j][0]>Inf-1){
      if((level==0) || (out[j][1]==level)){
        ctr++;
        din[ctr][0]=n1;
        din[ctr][1]=j-1;
        n1=j+1;
      }
    }
  }
  ctr++;
  din[ctr][0]=n1;
  din[ctr][1]=nall;
  din[0][0]=ctr;
  return ctr;
}

int dataindexd6(int level, double out[][6],int din[][2]){
  int n1=1, j, ctr=0, nall=length6(out);
  if(nall==0){
    din[0][0]=0;
    return 0;
  }
  for(j=1; j<=nall; j++){
    if(out[j][0]>Inf-1){
      if((level==0) || (out[j][1]==level)){
        ctr++;
        din[ctr][0]=n1;
        din[ctr][1]=j-1;
        n1=j+1;
      }
    }
  }
  ctr++;
  din[ctr][0]=n1;
  din[ctr][1]=nall;
  din[0][0]=ctr;
  return ctr;
}

int dataindexi1(int out[],int din[][2]){
  int n1=1, j, ctr=0, nall=out[0], ninfp=0;
  if(nall==0){
    din[0][0]=0; din[0][1]=-1;
    return 0;
  }
  for(j=1; j<=nall; j++){
    if(out[j]==Infint){
      ctr++;
      if(j==ninfp+1){
        din[ctr][0]=0; din[ctr][1]=-1;
      }
      else{
        din[ctr][0]=n1; din[ctr][1]=j-1;
      }
      ninfp=j;
      n1=j+1;
    }
  }
  ctr++;
  if(out[nall]==Infint){
    din[ctr][0]=0; din[ctr][1]=0;
  }
  else{
    din[ctr][0]=n1; din[ctr][1]=nall;
  }
  din[0][0]=ctr;
  return ctr;
}

void replacelistd1(int ii,double out[],double rep[]){
  int din[DsizeS][2],k,j,js,je, nall=length1(out),nr=length1(rep);
  double tmpd1[DsizeL];
  dataindexd1(out,din);
  tmpd1[0]=0;
  for(k=1;k<=din[0][0];k++){
    if(k!=1){
      appendd1(Inf,tmpd1);
    }
    if(k!=ii){
      js=din[k][0]; je=din[k][1];
      for(j=js;j<=je;j++){
        appendd1(out[j],tmpd1);
      }
    }else{
      for(j=1;j<=nr;j++){
        appendd1(rep[j],tmpd1);
      }
    }
  }
  nall=length1(tmpd1);
  out[0]=0;
  for(j=1;j<=nall;j++){
    appendd1(tmpd1[j],out);
  }
}

void replacelistd2(int level,int ii,double out[][2],double rep[][2]){//180419
  int din[DsizeS][2],k,js,je, nall=length2(out),nr=length2(rep);
  double tmpmd2[DsizeL][2];
  dataindexd2(level,out,din);
  tmpmd2[0][0]=0;
  for(k=1;k<=din[0][0];k++){
    if(k!=ii){
      js=din[k][0]; je=din[k][1];
      appendd2(level,js,je,out,tmpmd2);
    }else{
      appendd2(level,1,nr,rep,tmpmd2);
    }
  }
  nall=length2(tmpmd2);
  out[0][0]=0;
  appendd2(level,1,nall,tmpmd2,out);
}

void replacelistd3(int level,int ii,double out[][3],double rep[][3]){//180428
  int din[DsizeS][2],k,js,je, nall=length3(out),nr=length3(rep);
  double tmpmd3[DsizeL][3];
  dataindexd3(level,out,din);
  tmpmd3[0][0]=0;
  for(k=1;k<=din[0][0];k++){
    if(k!=ii){
      js=din[k][0]; je=din[k][1];
      appendd3(level,js,je,out,tmpmd3);
    }else{
      appendd3(level,1,nr,rep,tmpmd3);
    }
  }
  nall=length3(tmpmd3);
  out[0][0]=0;
  appendd3(level,1,nall,tmpmd3,out);
}

void replacelistd6(int level,int ii,double out[][6],double rep[][6]){//180421
  int din[DsizeS][2],k,js,je, nall=length6(out),nr=length6(rep);
  double tmpmd6[DsizeL][6];
  dataindexd6(level,out,din);
  js=din[ii][0]; je=din[ii][1];
  tmpmd6[0][0]=0;
  for(k=1;k<=din[0][0];k++){
    if(k!=ii){
      js=din[k][0]; je=din[k][1];
      appendd6(level,js,je,out,tmpmd6);
    }else{
      appendd6(level,1,nr,rep,tmpmd6);
    }
  }
  nall=length6(tmpmd6);
  out[0][0]=0;
  appendd6(level,1,nall,tmpmd6,out);
}

void removelistd2(int level,int ii,double out[][2]){//180503
  int din[DsizeS][2],k,js,je,nall=length2(out);
  double tmpmd[DsizeL][2];
  dataindexd2(level,out,din);
  js=din[ii][0]; je=din[ii][1];
  tmpmd[0][0]=0;
  appendd2(0,je+1,nall,out,tmpmd);
  out[0][0]=0;
  if(js>1){
    out[0][0]=js-2;
  }
  appendd2(0,1,length2(tmpmd),tmpmd,out);
}

void dispvec(int n,double dt[]){
 int i;
 for(i=0; i<n; i++){
   printf("%f ",dt[i]);
 }
 printf("\n");
}

void dispveci(int n,int dt[]){
 int i;
 for(i=0; i<n; i++){
   printf("%d ",dt[i]);
 }
 printf("\n");
}

void dispmatd2(int from, int upto, double mat[][2]){
  int i;
  for(i=from; i<upto+1; i++){
    printf("%3d %7.5f %7.5f\n",i,mat[i][0],mat[i][1]);
  }
}

void dispmatd3(int from, int upto, double mat[][3]){
  int i;
  for(i=from; i<upto+1; i++){
    printf("%3d %7.5f %7.5f %7.5f\n",i,mat[i][0],mat[i][1],mat[i][2]);
  }
}

void dispmatd4(int from, int upto, double mat[][4]){
  int i;
  for(i=from; i<upto+1; i++){
    printf("%3d %7.5f %7.5f ",i,mat[i][0],mat[i][1]);
    printf("%7.5f %7.5f\n",mat[i][2],mat[i][3]);
  }
}

void dispmatd5(int from, int upto, double mat[][5]){
  int i;
  for(i=from; i<upto+1; i++){
    printf("%3d %7.5f %7.5f ",i,mat[i][0],mat[i][1]);
    printf("%7.5f %7.5f %7.5f\n",mat[i][2],mat[i][3],mat[i][4]);
  }
}

void dispmatd6(int from, int upto, double mat[][6]){
  int i;
  for(i=from; i<upto+1; i++){
    printf("%3d %7.5f %7.5f %7.5f ",i,mat[i][0],mat[i][1],mat[i][2]);
    printf("%7.5f %7.5f %7.5f\n",mat[i][3],mat[i][4],mat[i][5]);
  }
}

void dispmatd1all(double dt[]){
 int i,n;
 n=length1(dt);
 for(i=1; i<=n; i++){
   printf("%f ",dt[i]);
 }
 printf("\n");
}

void dispmatd2all(double mat[][2]){
  int i;
  if(mat[0][0]==0){printf("%s\n","no data");return;}
  for(i=1; i<mat[0][0]+1; i++){
    printf("%3d %7.5f %7.5f\n",i,mat[i][0],mat[i][1]);
  }
}

void dispmatd3all(double mat[][3]){
  int i;
  if(mat[0][0]==0){printf("%s\n","no data");return;}
  for(i=1; i<mat[0][0]+1; i++){
    printf("%3d %7.5f %7.5f %7.5f\n",i,mat[i][0],mat[i][1],mat[i][2]);
  }
}

void dispmatd4all(double mat[][4]){
  int i;
  if(mat[0][0]==0){printf("%s\n","no data");return;}
  for(i=1; i<mat[0][0]+1; i++){
    printf("%3d %7.5f %7.5f ",i,mat[i][0],mat[i][1]);
    printf("%7.5f %7.5f\n",mat[i][2],mat[i][3]);
  }
}

void dispmatd5all(double mat[][5]){
  int i;
  if(mat[0][0]==0){printf("%s\n","no data");return;}
  for(i=1; i<mat[0][0]+1; i++){
    printf("%3d %7.5f %7.5f ",i,mat[i][0],mat[i][1]);
    printf("%7.5f %7.5f %7.5f\n",mat[i][2],mat[i][3],mat[i][4]);
  }
}

void dispmatd6all(double mat[][6]){
  int i;
  if(mat[0][0]==0){printf("%s\n","no data");return;}
  for(i=1; i<mat[0][0]+1; i++){
    printf("%3d %7.5f %7.5f %7.5f ",i,mat[i][0],mat[i][1],mat[i][2]);
    printf("%7.5f %7.5f %7.5f\n",mat[i][3],mat[i][4],mat[i][5]);
  }
}

void dispmati2(int from, int upto, int mat[][2]){
  int i;
  for(i=from; i<upto+1; i++){
    printf("%3d %d %d\n",i,mat[i][0],mat[i][1]);
  }
}

void dispmati1(int from, int upto, int mat[]){
  int i;
  for(i=from; i<upto+1; i++){
    printf("%3d %d\n",i,mat[i]);
  }
}

void writedata3(const char *fname, double out[][3]){
  int i, nall;
  FILE *fp;
  nall=length3(out);
  fp=fopen(fname,"w");
  for(i=1; i<=nall; i++){
    fprintf(fp,"%7.5f %7.5f %7.5f",out[i][0],out[i][1],out[i][2]);
    if(i<nall){fprintf(fp,"\n");}
  }
  fclose(fp);
}

void readdata3(const char *fname, double out[][3]){
  int n,j;
  FILE *fp;
  fp=fopen(fname,"r");
  if(fp==NULL){
    printf("file not found\n");
    return;
  }
  n=1;
  while( ! feof(fp) && n<DsizeL){
    for(j=0;j<3;j++){
      fscanf(fp,"%lf",&out[n][j]);
    }
    n++;
  }
  n--;
  fclose(fp);
  out[0][0]=n;
}

void writedata2(const char *fname, double out[][2]){
  int i, nall;
  FILE *fp;
  nall=length2(out);
  fp=fopen(fname,"w");
  for(i=1; i<=nall; i++){
    fprintf(fp,"%7.5f %7.5f",out[i][0],out[i][1]);
    if(i<nall){fprintf(fp,"\n");}
  }
  fclose(fp);
}

void readdata2(const char *fname, double out[][2]){
  int n,j;
  FILE *fp;
  fp=fopen(fname,"r");
  if(fp==NULL){
    printf("file not found\n");
    return;
  }
  n=1;
  while( ! feof(fp) && n<DsizeL){
    for(j=0;j<2;j++){
      fscanf(fp,"%lf",&out[n][j]);
    }
    n++;
  }
  n--;
  fclose(fp);
  out[0][0]=n;
}

int output2(const char *var, const char *fname, int level, double out[][2]){
  int nall=length2(out), ndin, din[DsizeM][2],i,j;
  double tmpd[2];
  FILE *fp;
  fp=fopen(fname,"w");
  if (fp == NULL) { 
    printf("cannot open\n");  
    return -1;
  }
  ndin=dataindexd2(level, out,din);
  fprintf(fp,"%s//\n",var);
  for(i=1; i<=ndin; i++){
    fprintf(fp,"start//\n");
    fprintf(fp,"[");
    for(j=din[i][0]; j<=din[i][1]; j++){
      pull2(j,out,tmpd);
      fprintf(fp,"[ %7.5f, %7.5f]",tmpd[0],tmpd[1]);
      if(j<din[i][1]){
        fprintf(fp,",");
      }
    }
    fprintf(fp,"]//\n");
    if(i<ndin){
      fprintf(fp,"end//\n");
    }
    else{
      fprintf(fp,"end////\n");
    }
  }
  fclose(fp);
  return 0;
}

void simplesort(double number[]){
  int i,j, total=number[0];
  double tmp;
  for (i=1; i<=total; i++) {
    for (j=i+1; j<=total; j++) {
      if (number[i] > number[j]) {
        tmp =  number[i];
        number[i] = number[j];
        number[j] = tmp;
      }
    }
  }
}

int memberi(int a, int list[]){
  int i, n=list[0];
  if(n==0){return 0;} //181024
  for(i=1; i<=n; i++){
    if(a==list[i]){
      return 1;
    }
  }
  return 0;
}

double dotprod(int dim, double p[], double q[]){
  double ans;
  ans=p[0]*q[0]+p[1]*q[1];
  if(dim>2){
    ans=ans+p[2]*q[2];
  }
  return ans;
}

double norm(int dim, double p[]){
  double ans;
  ans=dotprod(dim,p,p);
  return sqrt(ans);
}

double dist(int dim, double p[], double q[]){
  double tmp;
  tmp=pow(q[0]-p[0],2)+pow(q[1]-p[1],2);
  if(dim>2){
    tmp=tmp+pow(q[2]-p[2],2);
  }
  return sqrt(tmp);
}

void crossprod(int dim,double a[3],double b[3], double out[3]){
  if(dim==3){
    out[0]=a[1]*b[2]-a[2]*b[1];
    out[1]=a[2]*b[0]-a[0]*b[2];
    out[2]=a[0]*b[1]-a[1]*b[0];
  }else{
    out[0]=a[0]*b[1]-a[1]*b[0];
    out[1]=Inf;
  }
}

void reflectpoint(double p1[2],double regard[][2],double p2[2]){
  double pa[2],pb[2],u,v,a,b,u2,v2;
  pull2(1,regard,pa);
  if(length2(regard)==1){
    p2[0]=2*pa[0]-p1[0]; p2[1]=2*pa[1]-p1[1];
  }else{
    pull2(2,regard,pb);
    u=pb[0]-pa[0]; u2=pow(u,2.0);
    v=pb[1]-pa[1]; v2=pow(v,2.0);
    a=pa[0]; b=pa[1];
    p2[0]=(u2-v2)/(u2+v2)*p1[0]+2*u*v/(u2+v2)*p1[1];
    p2[0]=p2[0]-2*v*(u*b-v*a)/(u2+v2);
    p2[1]=2*u*v/(u2+v2)*p1[0]-(u2-v2)/(u2+v2)*p1[1];
    p2[1]=p2[1]+2*u*(u*b-v*a)/(u2+v2);
  }
}

void pointoncurve(double t, double gdata[][2], double eps, double pt[]){
  double pa[2],pb[2], s;
  int n, nall;
  n=floor(t+eps);
  s=fmax(t-n,0);
  nall=length2(gdata);
  if(n>=nall){
    pull2(nall,gdata,pt);
//    pt[0]=gdata[nall][0]; pt[1]=gdata[nall][1];
  }
  else{
    pull2(n,gdata,pa);
    pull2(n+1,gdata,pb);
    pt[0]=(1-s)*pa[0]+s*pb[0];
    pt[1]=(1-s)*pa[1]+s*pb[1];
  }
}

int partcrv(double a,double b,double pkL[][2], double pL[][2]){
  int i, is, ie, nall;
  double eps=pow(10,-3.2);
  is=ceil(a);
  ie=floor(b);
  nall=0;
  if(a<is-eps){
    nall++;
    pL[nall][0]=(is-a)*pkL[is-1][0]+(1-is+a)*pkL[is][0];
    pL[nall][1]=(is-a)*pkL[is-1][1]+(1-is+a)*pkL[is][1];
  }
  for(i=is; i<=ie; i++){
    nall++;
    pL[nall][0]=pkL[i][0];
    pL[nall][1]=pkL[i][1];
  }
  if(b>ie+eps){
    nall++;
    pL[nall][0]=(1-b+ie)*pkL[ie][0]+(b-ie)*pkL[ie+1][0];
    pL[nall][1]=(1-b+ie)*pkL[ie][1]+(b-ie)*pkL[ie+1][1];
  }
  pL[0][0]=nall;  
  return nall;
}

int partcrv3(double a,double b,double pkL[][3], double pL[][3]){
  int i, is, ie, nall;
  double eps=pow(10,-3.2);
  is=ceil(a);
  ie=floor(b);
  nall=0;
  if(a<is-eps){
    nall++;
    pL[nall][0]=(is-a)*pkL[is-1][0]+(1-is+a)*pkL[is][0];
    pL[nall][1]=(is-a)*pkL[is-1][1]+(1-is+a)*pkL[is][1];
    pL[nall][2]=(is-a)*pkL[is-1][2]+(1-is+a)*pkL[is][2];
  }
  for(i=is; i<=ie; i++){
    nall++;
    pL[nall][0]=pkL[i][0];
    pL[nall][1]=pkL[i][1];
    pL[nall][2]=pkL[i][2];
  }
  if(b>ie+eps){
    nall++;
    pL[nall][0]=(1-b+ie)*pkL[ie][0]+(b-ie)*pkL[ie+1][0];
    pL[nall][1]=(1-b+ie)*pkL[ie][1]+(b-ie)*pkL[ie+1][1];
    pL[nall][2]=(1-b+ie)*pkL[ie][2]+(b-ie)*pkL[ie+1][2];
  }
  pL[0][0]=nall;  
  return nall;
}

int connectseg(double pdata[][2], double eps, double out[][2]){
  int din[DsizeM][2], nd, nq, i, j, flg, st, en, ntmp;
  int nall=length2(pdata), nout=0;
  double qd[DsizeM][2], ah[2], ao[2], p[2], q[2], tmp[2];
  out[0][0]=0;
  if(length2(pdata)==0){return 0;} //180613
  nd=dataindexd2(0,pdata,din);
  qd[0][0]=0;
  nq=appendd2(0,din[1][0],din[1][1],pdata,qd);
  nd=removei2(1,din);
  while(nd>0){
    pull2(1,qd,ah);
    pull2(nq,qd,ao);
	flg=0;
    for(j=1; j<=nd; j++){
	  st=din[j][0];
      en=din[j][1];
      pull2(st,pdata,p);
      pull2(en,pdata,q);
      if(dist(2,p,ao)<eps){
        nq=appendd2(0,st+1,en,pdata,qd);
        nd=removei2(j,din);
        flg=1;
        break;
      }
      if(dist(2,q,ao)<eps){
        nq=appendd2(0,en-1,st,pdata,qd);
        nd=removei2(j,din);
        flg=1;
        break;
      }
      if(dist(2,p,ah)<eps){
        nq=prependd2(en,st+1,pdata,qd);
        nd=removei2(j,din);
        flg=1;
        break;
      }
      if(dist(2,q,ah)<eps){
        nq=prependd2(st,en-1,pdata,qd);
        nd=removei2(j,din);
        flg=1;
        break;
      }
    }
    if(flg==0){
	  nout=appendd2(2,1,nq,qd,out);
	  qd[0][0]=0;
      nq=appendd2(0,din[1][0],din[1][1],pdata,qd);
      nd=removei2(1,din);
	}
  }
  if(nq>0){
    nout=appendd2(2,1,nq,qd,out);
  }
  return nout;
}

int connectseg3(double pdata[][3], double eps, double out[][3]){
  int din[DsizeM][2],i,j,nd,nq,flg, st, en, ntmp;
  int nall=length3(pdata), nout=0;
  double qd[DsizeM][3], ah[3], ao[3], p[3], q[3], tmp[3];
  out[0][0]=0;
  if(length3(pdata)==0){return 0;} //180613
  nd=dataindexd3(0,pdata,din);
  qd[0][0]=0;
  nq=appendd3(0,din[1][0],din[1][1],pdata,qd);
  removei2(1,din);
  while(nd>0){
    pull3(1,qd,ah);
    pull3(nq,qd,ao);
	flg=0;
    for(j=1; j<=nd; j++){
	  st=din[j][0];
      en=din[j][1];
      pull3(st,pdata,p);
      pull3(en,pdata,q);
      if(dist(3,p,ao)<eps){
        nq=appendd3(0,st+1,en,pdata,qd);
        nd=removei2(j,din);
        flg=1;
        break;
      }
      if(dist(3,q,ao)<eps){
        nq=appendd3(0,en-1,st,pdata,qd);
        nd=removei2(j,din);
        flg=1;
        break;
      }
      if(dist(3,p,ah)<eps){
        nq=prependd3(en,st+1,pdata,qd);
        nd=removei2(j,din);
        flg=1;
        break;
      }
      if(dist(3,q,ah)<eps){
        nq=prependd3(st,en-1,pdata,qd);
        nd=removei2(j,din);
        flg=1;
        break;
      }
    }
    if(flg==0){
	  nout=appendd3(2,1,nq,qd,out);
	  qd[0][0]=0;
      nq=appendd3(0,din[1][0],din[1][1],pdata,qd);
      nd=removei2(1,din);
	}
  }
  if(nq>0){
    nout=appendd3(2,1,nq,qd,out);
  }
  return nout;
}

void koutenseg(double a[2], double b[2], double c[2], double d[2],
          double eps, double eps2, double out[4]){
  double v[2], epss,eps0=Eps, sv2, p1, p2, q1,q2,m1, m2, M1, M2, t;
  double tmp1d2[2], tmp2d1, p[2], q[2];
  v[0]=b[0]-a[0]; v[1]=b[1]-a[1];
  sv2=pow(v[0],2.0)+pow(v[1],2.0);
  if(sv2<pow(10,-6.0)){
     out[0]=Inf;
     return;
  }
  p[0]=c[0]-a[0]; p[1]=c[1]-a[1]; 
  q[0]=d[0]-a[0]; q[1]=d[1]-a[1]; 
  epss=fmin(eps2, eps/sqrt(sv2));
  p1=(p[0]*v[0]+p[1]*v[1])/sv2;
  p2=(-p[0]*v[1]+p[1]*v[0])/sv2;
  q1=(q[0]*v[0]+q[1]*v[1])/sv2;
  q2=(-q[0]*v[1]+q[1]*v[0])/sv2;
  m1=-epss; M1=1+epss;
  m2=-epss; M2=epss;
  if((fmax(p1,q1)<m1) || (fmin(p1,q1)>M1)){
    out[0]=Inf;
    return;
  }
  if((fmax(p2,q2)<m2) || (fmin(p2,q2)>M2)){
    out[0]=Inf;
    return;
  }
  if(p2*q2<0){
    t=p1-(q1-p1)/(q2-p2)*p2;
    if((t>m1)&& (t<M1)){
      if((t>-eps0) && (t<1+eps0)){
        tmp1d2[0]=a[0]+t*v[0];  tmp1d2[1]=a[1]+t*v[1];
        tmp2d1=fmin(fmax(t,0),1);
        out[0]=tmp1d2[0]; out[1]=tmp1d2[1];
        out[2]=tmp2d1; out[3]=0;
      }
      else{
        tmp1d2[0]=a[0]+t*v[0]; tmp1d2[1]=a[1]+t*v[1];
        tmp2d1=fmin(fmax(t,0),1);
        out[0]=tmp1d2[0]; out[1]=tmp1d2[1];
        out[2]=tmp2d1; out[3]=1;
      }
      return;
    }
    if((p1<m1)||(p1>M1)||(p2<m2)||(p2>M2)){
      if((q1<m1)||(q1>M1)||(q2<m2)||(q2>M2)){
         out[0]=Inf;
         return;
      }
      t=fmin(fmax(q1,0),1);
      tmp1d2[0]=a[0]+t*v[0];  tmp1d2[1]=a[1]+t*v[1];
      out[0]=tmp1d2[0]; out[1]=tmp1d2[1]; 
      out[2]=t; out[3]=1;
      return;
    }
    t=fmin(fmax(p1,0),1);
    tmp1d2[0]=a[0]+t*v[0]; tmp1d2[1]=a[1]+t*v[1];
    out[0]=tmp1d2[0]; out[1]=tmp1d2[1]; 
    out[2]=t; out[3]=1;
    return;
  }
  if((p1>-eps0)&&(p1<1+eps0)&&(p2>-eps0)&&(p2<eps0)){
    t= p1;
    tmp1d2[0]=a[0]+t*v[0]; tmp1d2[1]=a[1]+t*v[1];
    out[0]=tmp1d2[0]; out[1]=tmp1d2[1]; 
    out[2]=t; out[3]=0;
    return;
  }
  if((q1>-eps0)&&(q1<1+eps0)&&(q2>-eps0)&&(q2<eps0)){
    t= q1;
    tmp1d2[0]=a[0]+t*v[0]; tmp1d2[1]=a[1]+t*v[1];
    out[0]=tmp1d2[0]; out[1]=tmp1d2[1]; 
    out[2]=t; out[3]=0;
    return;
  }
  if((p1<m1)||(p1>M1)||(p2<m2)||(p2>M2)){
    if((q1<m1)||(q1>M1)||(q2<m2)||(q2>M2)){
      out[0]=Inf;      
      return;
    }
    t=fmin(fmax(q1,0),1);
    tmp1d2[0]=a[0]+t*v[0]; tmp1d2[1]=a[1]+t*v[1];
    out[0]=tmp1d2[0]; out[1]=tmp1d2[1]; 
    out[2]=t; out[3]=1;
    return;
  }
  if((q1<m1)||(q1>M1)||(q2<m2)||(q2>M2)){
    t=fmin(fmax(p1,0),1);
    tmp1d2[0]=a[0]+t*v[0]; tmp1d2[1]=a[1]+t*v[1];
    out[0]=tmp1d2[0]; out[1]=tmp1d2[1]; 
    out[2]=t; out[3]=1;
    return;
  }
  if(fabs(p2)<fabs(q2)){
    t=fmin(fmax(p1,0),1);
  }
  else{
    t=fmin(fmax(q1,0),1);
  }
  tmp1d2[0]=a[0]+t*v[0]; tmp1d2[1]=a[1]+t*v[1];
  out[0]=tmp1d2[0]; out[1]=tmp1d2[1]; 
  out[2]=t; out[3]=1;
  return;
}

double paramoncurve(double p[2], int n, double ptL[][2]){
  double pa[2], pb[2], v[2], w[2], o[2], d2, s;
  int nptL=length2(ptL);
  if(n==nptL){
    return nptL;
  }
  else{
    pull2(n,ptL,pa);
    pull2(n+1,ptL,pb);
    v[0]=pb[0]-pa[0];  v[1]=pb[1]-pa[1];
    w[0]=p[0]-pa[0];  w[1]=p[1]-pa[1];
    o[0]=0; o[1]=0;
    d2=pow(dist(2,v,o),2.0);
    s=dotprod(2,v,w)/d2;
    s=fmin(fmax(s,0),1);
    return n+s;
  }
}

void nearestptpt(double pa[2], double pL[][2], double pt[4]){
  double eps0=pow(10,-6.0), p[2], pm[2], im, sm, s;
  double ans[7], a1,a2, b1,b2, v1, v2, x1, x2, t, tmpd1;
  int i, n, npL=length2(pL);
  ans[0]=pa[0]; ans[1]=pa[1];
  ans[2]=1;
  p[0]=pL[1][0]; p[1]=pL[1][1];
  ans[3]=p[0]; ans[4]=p[1];
  ans[5]=1; ans[6]=dist(2,pa,p);
  pm[0]=pL[1][0]; pm[1]=pL[1][1];
  im=1;
  sm=dist(2,pm,pa);
  for(i=1; i<=npL-1; i++){
    a1=pL[i][0]; a2=pL[i][1];
    b1=pL[i+1][0]; b2=pL[i+1][1];
    v1=b1-a1; v2=b2-a2;
    x1=pa[0]; x2=pa[1];
    tmpd1=pow(v2,2.0)+pow(v1,2.0);
    if(fabs(tmpd1)<eps0){
      continue;
    }
    t=(-a2*v2-v1*a1+v1*x1+x2*v2)/tmpd1;
    if(t<-eps0){
      p[0]=a1; p[1]=a2;
    }
    else if(t>1+eps0){
      p[0]=b1; p[1]=b2;
    }
    else{
      p[0]=a1+t*v1; p[1]=a2+t*v2;
    }
    s=dist(2,p,pa);
    if(s<sm-eps0){
      tmpd1=paramoncurve(p,i,pL);
      pm[0]=p[0]; pm[1]=p[1];
      im=tmpd1; sm=s;
    }
  }
  if(sm<ans[6]){
    ans[0]=pa[0]; ans[1]=pa[1];
    ans[2]=n;
    ans[3]=pm[0]; ans[4]=pm[1];
    ans[5]=im; ans[6]=sm;
  }
  pt[0]=ans[3]; pt[1]=ans[4];
  pt[2]=ans[5]; pt[3]=ans[6];
}

int intersectselfPp(double data1[][2],double eps,double eps1s,double kL[][4]){
  double a[2], b[2], tmpd2[2], tmpd4[4], tmpd5[5], p[2], q[2], t, s;
  double eps0=pow(10,-5.0);
  double tmpd1, tmp1d1, tmp2d1;
  int i, j, k, n, is, ndata1,nkL, ntmp, ntmp1,flg, closed=0;
  ndata1=length2(data1);
  p[0]=data1[1][0]; p[1]=data1[1][1];
  q[0]=data1[ndata1][0]; q[1]=data1[ndata1][1];
  if(dist(2,p,q)<Eps){closed=1;}
  kL[0][0]=0; nkL=0;  
  for(i=1; i<=ndata1; i++){
    ntmp=0; tmpd1=Inf;
    pull2(i,data1,a);
    nearestptpt(a, data1, tmpd4);
    n=floor(tmpd4[2]+0.5);
    if(n==i){continue;}
    if(closed==1){
      if((i==1)&&(n==ndata1)){continue;}
      if((i==ndata1)&&(n==1)){continue;}
    }	
    ntmp1=floor(tmpd4[2]+Eps);
	if((tmpd4[3]<eps1s)&&(ntmp1!=i)){
	  if(ntmp<ntmp1){
        ntmp=ntmp1; 
        tmpd1=tmpd4[3];
        nkL=addptd4(kL,tmpd4);
      }  
      else if(tmpd4[3]<tmpd1){
        tmpd1=tmpd4[3];
        kL[0][0]--;
        nkL=addptd4(kL,tmpd4);            
      }
    }
  }
  return nkL;
}

/*
int intersectcrvsPptest(double data1[][2], double data2[][2],
            double eps1,double eps2, double kL[][4]){
  double t, s, a[2], b[2], p[2], q[2];
  double sqeps=pow(10,-10.0), eps0=pow(10,-2.0);
  double tmp1d2[2],tmp2d2[2],tmpd4[4],tmp1d4[4],tmpd5[5];
  double tmpd1,tmp1d1,tmp2d1, kL0[DsizeL][5], ds;
  int i, j, k, n, is, nkL, nall, ndata1,ndata2,ntmp, ntmp1, flg;
  ndata1=length2(data1);
  ndata2=length2(data2);
  if(ndata1==ndata2){
    tmp1d1=0; tmp2d1=0;
    for(i=1; i<=ndata1; i++){
      tmp1d1=tmp1d1+pow(data1[i][0]-data2[i][0],2.0);
      tmp1d1=tmp1d1+pow(data1[i][1]-data2[i][1],2.0);
      tmp2d1=tmp2d1+pow(data1[i][0]-data2[ndata2-i+1][0],2.0);
      tmp2d1=tmp2d1+pow(data1[i][1]-data2[ndata2-i+1][1],2.0);
    }
    tmp1d1=sqrt(tmp1d1); tmp2d1=sqrt(tmp2d1);
    if((tmp1d1<Eps)||(tmp2d1<Eps)){
      kL[0][0]=0; nkL=0;
      return nkL;
    }
  }
  kL0[0][0]=0; nkL=0;
  for(i=1; i<=ndata1; i++){
    ntmp=0; tmpd1=Inf;
    pull2(i,data1,a);
    nearestptpt(a, data2, tmpd4); 
    tmp1d1=floor(tmpd4[2]+Eps); //17.06.03
    a[0]=tmpd4[0]; a[1]=tmpd4[1];
    nearestptpt(a, data1, tmpd4);
    tmpd5[0]=tmpd4[0]; tmpd5[1]=tmpd4[1];
    tmpd5[2]=tmpd4[2]; tmpd5[3]=tmp1d1;
    tmpd5[4]=tmpd4[3];
    nkL=addptd5(kL0,tmpd5);
  }
  kL[0][0]=0; nall=0;
  p[0]=Inf; p[1]=0;
  for(i=1; i<=nkL; i++){
    if(kL0[i][4]<eps2){
      q[0]=kL0[i][0]; q[1]=kL0[i][1];
      if(dist(2,p,q)>eps2){
        nall=push4(kL0[i][0],kL0[i][1],kL0[i][2],kL0[i][3],kL);
        p[0]=kL0[i][0]; p[1]=kL0[i][1];
        ds=kL0[i][4];
        continue;
      }
      if(kL0[i][4]<ds){
        kL[0][0]--;
        nall=push4(kL0[i][0],kL0[i][1],kL0[i][2],kL0[i][3],kL);
        p[0]=kL0[i][0]; p[1]=kL0[i][1];
        ds=kL0[i][4];
      }
    }
  }
  return nall;
}
*/

int intersectcrvsPp(double data1[][2], double data2[][2],
            double eps,double eps1s, double kL[][4]){
  double t, s, a[2], b[2], p[2], q[2];
  double sqeps=pow(10,-10.0), eps0=pow(10,-2.0);
  double tmp1d2[2],tmp2d2[2],tmpd4[4],tmp1d4[4],tmpd5[5];
  double tmpd1,tmp1d1,tmp2d1;
  int i, j, k, n, is, ndata1, ndata2, nkL,nkL1,nkL2,ntmp, ntmp1, flg;
  ndata1=length2(data1);
  ndata2=length2(data2);
  if(ndata1==ndata2){
    tmp1d1=0; tmp2d1=0;
    for(i=1; i<=ndata1; i++){
      tmp1d1=tmp1d1+pow(data1[i][0]-data2[i][0],2.0);
      tmp1d1=tmp1d1+pow(data1[i][1]-data2[i][1],2.0);
      tmp2d1=tmp2d1+pow(data1[i][0]-data2[ndata2-i+1][0],2.0);
      tmp2d1=tmp2d1+pow(data1[i][1]-data2[ndata2-i+1][1],2.0);
    }
    tmp1d1=sqrt(tmp1d1); tmp2d1=sqrt(tmp2d1);
    if((tmp1d1<Eps)||(tmp2d1<Eps)){
      kL[0][0]=0; nkL=0;
      return nkL;
    }
  }
  kL[0][0]=0; nkL=0;  
  for(i=1; i<=ndata1;i++){
    ntmp=0; tmpd1=Inf;
    pull2(i,data1,a);
    nearestptpt(a, data2, tmpd4); 
    tmp1d1=floor(tmpd4[2]+Eps); //17.06.03
    a[0]=tmpd4[0]; a[1]=tmpd4[1];
    nearestptpt(a, data1, tmpd4); 
	if(tmpd4[3]<eps1s){
      flg=0;
      p[0]=tmpd4[0]; p[1]=tmpd4[1]; 
      for(j=1; j<=nkL; j++){
        q[0]=kL[j][0]; q[1]=kL[j][1]; 
        if(dist(2,p,q)<eps0){
          flg=1;
          break;
        }
      }
      if(flg==1){continue;}
      ntmp1=floor(tmpd4[2]+Eps);
      if(ntmp<ntmp1){
        ntmp=ntmp1; 
        tmpd1=tmpd4[3];
        tmp1d4[0]=tmpd4[0]; tmp1d4[1]=tmpd4[1];
        tmp1d4[2]=tmpd4[2]; tmp1d4[3]=tmp1d1;
        nkL=addptd4(kL,tmp1d4);
      }  
      else if(tmpd4[3]<tmpd1){
        tmpd1=tmpd4[3];
        kL[0][0]--;
        tmp1d4[0]=tmpd4[0]; tmp1d4[1]=tmpd4[1];
        tmp1d4[2]=tmpd4[2]; tmp1d4[3]=tmp1d1;
        nkL=addptd4(kL,tmp1d4);            
      }
    }
  }
  return nkL;
}

int intersectcrvsPpold(double data1[][2], double data2[][2],
            double eps,double eps1s, double kL[][4]){
// 17.05.22
  double kL1[DsizeL][5], kL2[DsizeL][5];
  double t, s, a[2], b[2], p[2], q[2];
  double sqeps=pow(10,-10.0), eps0=pow(10,-6.0);
  double tmp1d2[2],tmp2d2[2],tmpd4[4],tmpd5[5];
  double tmpd1,tmp1d1,tmp2d1;
  int i, j, k, n, is, ndata1, ndata2, nkL,nkL1,nkL2,ntmp,flg;
  ndata1=length2(data1);
  ndata2=length2(data2);
  if(ndata1==ndata2){
    tmp1d1=0; tmp2d1=0;
    for(i=1; i<=ndata1; i++){
      tmp1d1=tmp1d1+pow(data1[i][0]-data2[i][0],2.0);
      tmp1d1=tmp1d1+pow(data1[i][1]-data2[i][1],2.0);
      tmp2d1=tmp2d1+pow(data1[i][0]-data2[ndata2-i+1][0],2.0);
      tmp2d1=tmp2d1+pow(data1[i][1]-data2[ndata2-i+1][1],2.0);
    }
    tmp1d1=sqrt(tmp1d1); tmp2d1=sqrt(tmp2d1);
    if((tmp1d1<eps0)||(tmp2d1<eps0)){
      kL[0][0]=0; nkL=0;
      return nkL;
    }
  }
  kL1[0][0]=0; nkL1=0;
  kL2[0][0]=0; nkL2=0;
  for(i=1; i<=ndata1-1; i++){
    pull2(i,data1,a);
    pull2(i+1,data1,b);
    for(j=1; j<=ndata2-1; j++){
      pull2(j, data2, p);
      pull2(j+1, data2, q);
      koutenseg(a,b,p,q,eps,eps1s,tmpd4);
      if(tmpd4[0]<Inf-1){
        ntmp=floor(tmpd4[3]+Eps);
        if(ntmp==0){
          tmpd5[0]=tmpd4[0]; tmpd5[1]=tmpd4[1];
          tmpd5[2]=tmpd4[2]; tmpd5[3]=i; tmpd5[4]=j;
          nkL1=addptd5(kL1,tmpd5);
        }
        else{
          tmpd5[0]=tmpd4[0]; tmpd5[1]=tmpd4[1];
          tmpd5[2]=tmpd4[2]; tmpd5[3]=i; tmpd5[4]=j;
          nkL2=addptd5(kL2,tmpd5);
        }
      }
    }
  }
  kL[0][0]=0; nkL=0;
  if(nkL1>0){
    pull5(1,kL1,tmpd5);
    p[0]=tmpd5[0]; p[1]=tmpd5[1];
    t=tmpd5[2];
    i=floor(tmpd5[3]+Eps);
    j=floor(tmpd5[4]+Eps);
    tmpd4[0]=p[0]; tmpd4[1]=p[1];
    tmpd4[2]=i+t; tmpd4[3]=j;
    nkL=addptd4(kL,tmpd4);
  }
  for(n=2; n<=nkL1; n++){ 
    pull5(n,kL1,tmpd5);
    p[0]=tmpd5[0]; p[1]=tmpd5[1];
    flg=0;
    for(k=1; k<=nkL; k++){
      pull4(k,kL,tmpd4);
      tmp1d2[0]=tmpd4[0]; tmp1d2[1]=tmpd4[1];
      if(pow(dist(2,p,tmp1d2),2.0)<sqeps){
        flg=1;
        break;
      }
    }
    if(flg==0){
      tmpd4[0]=p[0]; tmpd4[1]=p[1];
      t=tmpd5[2];
      i=floor(tmpd5[3]+Eps);
      j=floor(tmpd5[4]+Eps);
      tmpd4[2]=t+i; tmpd4[3]=j;
      nkL=addptd4(kL,tmpd4);
    }
  }
  for(n=1; n<=nkL2; n++){
    pull5(n,kL2,tmpd5);
    p[0]=tmpd5[0]; p[1]=tmpd5[1];
    flg=0;
    for(k=1; k<=nkL; k++){
      pull4(k,kL,tmpd4);
      tmp1d2[0]=tmpd4[0]; tmp1d2[1]=tmpd4[1];
      if(pow(dist(2,p,tmp1d2),2.0)<sqeps){
        flg=1;
        break;
      }
    }
    if(flg==0){
      tmpd4[0]=p[0]; tmpd4[1]=p[1];
      t=tmpd5[2];
      i=floor(tmpd5[3]+Eps);
      j=floor(tmpd5[4]+Eps);
      tmpd4[2]=i+t; tmpd4[3]=j;
      nkL=addptd4(kL,tmpd4);
    }
  }
  return nkL;
}

int dropnumlistcrv(double qd[][2], double eps1, int out[]){
  int i,j,k, nout,nall=length2(qd), nd, se, en, npd, nptL;
  int din[DsizeM][2],ptL[DsizeL];
  double eps=pow(10.0,-6.0), pd[DsizeL][2], p[2], tmp2d[2];
  out[0]=0; nout=0;
  nd=dataindexd2(2,qd,din);
  for(j=1; j<=nd; j++){
    se=din[j][0]; en=din[j][1];
    pd[0][0]=0; npd=0;
    npd=appendd2(0,se,en,qd,pd);
    ptL[0]=0; nptL=0;
    nptL=appendi1(1,ptL);
    pull2(1,pd,p);
    for(k=2; k<=npd-1; k++){
      pull2(k,pd,tmp2d);
      if(dist(2,p,tmp2d)>eps1){
        nptL=appendi1(k,ptL);
        pull2(k,pd,p);
      }
    }
    pull2(npd-1,pd,p);
    pull2(npd,pd,tmp2d);
    if(dist(2,p,tmp2d)>eps){  // eps -> eps1 ? 
      nptL=appendi1(npd,ptL);
    }
    if(nptL==1){ptL[0]=0; nptL=0;}
    if(nout>0){
      nout=appendi1(Infint,out);
    }
    for(i=1; i<=nptL; i++){
      nout=appendi1(ptL[i],out);
    }
  }
  out[0]=nout;
  return nout;
}

int increasept2(double ptL[][2], int nn, double out[][2]){
  int ii, jj, npt, nall;
  double tmpd2[2];
  npt=length2(ptL);
  out[0][0]=0;
  for(ii=1; ii<=npt-1; ii++){
    for(jj=0; jj<nn; jj++){
      tmpd2[0]=ptL[ii][0]+1.0*jj/nn*(ptL[ii+1][0]-ptL[ii][0]);
      tmpd2[1]=ptL[ii][1]+1.0*jj/nn*(ptL[ii+1][1]-ptL[ii][1]);
      addptd2(out,tmpd2);
    }
  }
  nall=appendd2(0,npt,npt,ptL,out); 
  return nall;
}

int increasept3(double ptL[][3], int nn, double out[][3]){
  int ii, jj, npt, nall;
  double tmpd3[3];
  npt=length3(ptL);
  out[0][0]=0;
  for(ii=1; ii<=npt-1; ii++){
    for(jj=0; jj<nn; jj++){
      tmpd3[0]=ptL[ii][0]+1.0*jj/nn*(ptL[ii+1][0]-ptL[ii][0]);
      tmpd3[1]=ptL[ii][1]+1.0*jj/nn*(ptL[ii+1][1]-ptL[ii][1]);
      tmpd3[2]=ptL[ii][2]+1.0*jj/nn*(ptL[ii+1][2]-ptL[ii][2]);
      addptd3(out,tmpd3);
    }
  }
  nall=appendd3(0,npt,npt,ptL,out); 
  return nall;
}

void bezierpt(double t, double p0[], double p3[], double p1[], double p2[], 
           double pout[]){
  double p4[2], p5[2], p6[2], p7[2], p8[2];
  int i, flg3=1;
  if(p2[0]>Inf-1){
    for(i=0; i<2; i++){
      p2[i]=p3[i];
    }
    flg3=0;
  }
  for(i=0; i<2; i++){
    p4[i]=(1-t)*p0[i]+t*p1[i];
  }
  for(i=0; i<2; i++){
    p5[i]=(1-t)*p1[i]+t*p2[i];
  }
  for(i=0; i<2; i++){
    p6[i]=(1-t)*p2[i]+t*p3[i];
  }
  for(i=0; i<2; i++){
    p7[i]=(1-t)*p4[i]+t*p5[i];
  }
  if(flg3==0){
    for(i=0; i<2; i++){
      pout[i]=p7[i];
    }
  }
  else{
    for(i=0; i<2; i++){
      p8[i]=(1-t)*p5[i]+t*p6[i];
    }
    for(i=0; i<2; i++){
      pout[i]=(1-t)*p7[i]+t*p8[i];
    }
  }
}

int bezier(double ptL[][2], double ctrL[][4], int num, double out[][2]){
  double p0[2], p3[2], p1[2], p2[2], pt[2], dt=1.0/num;
  int i, j, n, nall;
  out[0][0]=0; nall=0;
  nall=appendd2(0,1,1,ptL,out);
  n=length2(ptL);
  for(i=1; i<=n-1; i++){
    pull2(i,ptL, p0);
    pull2(i+1,ptL, p3);
    p1[0]=ctrL[i][0];  p1[1]=ctrL[i][1];
    p2[0]=ctrL[i][2];  p2[1]=ctrL[i][3];
    for(j=1; j<=num; j++){
      bezierpt(j*dt,p0,p3,p1,p2,pt);
      nall=push2(pt[0],pt[1], out);
    }
  }
  return nall;
}

int ospline(int level, double ptL[][2], int num, double out[][2]){
  double ctrlist[DsizeM][4], eps0=pow(10,-6.0), tmp, cc;
  double p[2], q[2], p0[2], p3[2], p1[2], p2[2], pQ[2], pR[2];
  double ptlist[DsizeM][2], tmpmd2[DsizeM][2];
  int nd, i, j, npt, nall, nctr, flg, ndin, closed, din[DsizeM][2], ntmp;
  out[0][0]=0;
  if(num==1){
    npt=length2(ptL);
    for(i=0; i<=npt; i++){
      out[i][0]=ptL[i][0]; out[i][1]=ptL[i][1];
    }
    nall=length2(out);
    return nall;
  }
  ndin=dataindexd2(level,ptL,din);
  for(nd=1; nd<=ndin; nd++){
    ptlist[0][0]=0;
    npt=appendd2(0,din[nd][0],din[nd][1],ptL,ptlist);
    if(npt==2){
      appendd2(2, 1,npt,ptlist,out);
      continue;
    }
    closed=0;
    pull2(1,ptlist,p);
    pull2(npt,ptlist,q);
    if(dist(2,p,q)<eps0){
      closed=1;
    }
	ctrlist[0][0]=0; nctr=0;
    for(i=1; i<=npt-1; i++){
      flg=0;
      pull2(i, ptlist,p1);
      pull2(i+1, ptlist,p2);
      if((i==1)||(i==npt-1)){
        flg=1;
        if(closed==0){
          pQ[0]=(p1[0]+2*p2[0])/3.0; 
          pQ[1]=(p1[1]+2*p2[1])/3.0; 
          pR[0]=(2*p1[0]+p2[0])/3.0;
          pR[1]=(2*p1[1]+p2[1])/3.0;
          nctr++;
          ctrlist[nctr][0]=pQ[0]; ctrlist[nctr][1]=pQ[1]; 
          ctrlist[nctr][2]=pR[0]; ctrlist[nctr][3]=pR[1]; 
          flg=2;
        }
        else{
          if(i==1){
            pull2(npt-1, ptlist,p0);
            pull2(i+2, ptlist,p3);
          }
          else{
            pull2(i-1, ptlist, p0);
            pull2(2, ptlist, p3);
          }
        }
      }
      if(flg<=1){
        if(flg==0){
          pull2(i-1, ptlist, p0);
          pull2(i+2, ptlist, p3);
        }
        p[0]=p2[0]-p0[0]; p[1]=p2[1]-p0[1]; 
        q[0]=p3[0]-p1[0]; q[1]=p3[1]-p1[1]; 
        tmp=1+sqrt((1+dotprod(2,p,q)/dist(2,p0,p2)/dist(2,p1,p3))/2);
        cc=4*dist(2,p1,p2)/3/(dist(2,p0,p2)+dist(2,p1,p3))/tmp;
        pQ[0]=p1[0]+cc*(p2[0]-p0[0]); pQ[1]=p1[1]+cc*(p2[1]-p0[1]);
        pR[0]=p2[0]+cc*(p1[0]-p3[0]); pR[1]=p2[1]+cc*(p1[1]-p3[1]); 
        nctr++;
        ctrlist[nctr][0]=pQ[0]; ctrlist[nctr][1]=pQ[1]; 
        ctrlist[nctr][2]=pR[0]; ctrlist[nctr][3]=pR[1]; 
      }
    }
    if(closed==0){
      p1[0]=ctrlist[2][0]; p1[1]=ctrlist[2][1]; 
      pull2(2, ptlist, p2);
      pQ[0]=p2[0]+(p2[0]-p1[0]); pQ[1]=p2[1]+(p2[1]-p1[1]);
      ctrlist[1][0]=pQ[0]; ctrlist[1][1]=pQ[1]; 
      ctrlist[1][2]=Inf; ctrlist[1][3]=0;
      p1[0]=ctrlist[nctr-1][2]; p1[1]=ctrlist[nctr-1][3];
      pull2(nctr,ptlist,p2);
      pQ[0]=p2[0]+(p2[0]-p1[0]); pQ[1]=p2[1]+(p2[1]-p1[1]);
      ctrlist[nctr][0]=pQ[0]; ctrlist[nctr][1]=pQ[1];
      ctrlist[nctr][2]=Inf; ctrlist[1][3]=0;
    }
    ctrlist[0][0]=nctr;
    if(length2(ptlist)>2){
      ntmp=bezier(ptlist,ctrlist,num, tmpmd2);
      nall=appendd2(2,1,ntmp,tmpmd2,out);
    }
  }
  return nall;
}

void bezierpt3(double t, double p0[], double p3[], double p1[], double p2[], 
           double pout[]){
  double p4[3], p5[3], p6[3], p7[3], p8[3];
  int i, flg3=1;
  if(p2[0]>Inf-1){
    for(i=0; i<3; i++){
      p2[i]=p3[i];
    }
    flg3=0;
  }
  for(i=0; i<3; i++){
    p4[i]=(1-t)*p0[i]+t*p1[i];
  }
  for(i=0; i<3; i++){
    p5[i]=(1-t)*p1[i]+t*p2[i];
  }
  for(i=0; i<3; i++){
    p6[i]=(1-t)*p2[i]+t*p3[i];
  }
  for(i=0; i<3; i++){
    p7[i]=(1-t)*p4[i]+t*p5[i];
  }
  if(flg3==0){
    for(i=0; i<3; i++){
      pout[i]=p7[i];
    }
  }
  else{
    for(i=0; i<3; i++){
      p8[i]=(1-t)*p5[i]+t*p6[i];
    }
    for(i=0; i<3; i++){
      pout[i]=(1-t)*p7[i]+t*p8[i];
    }
  }
}

int bezier3(double ptL[][3], double ctrL[][6], int num, double out[][3]){
  double p0[3], p3[3], p1[3], p2[3], pt[3], dt=1.0/num;
  int i, j, n, nall;
  out[0][0]=0; nall=0;
  nall=appendd3(0,1,1,ptL,out);
  n=length3(ptL);
  for(i=1; i<=n-1; i++){
    pull3(i,ptL, p0);
    pull3(i+1,ptL, p3);
    p1[0]=ctrL[i][0];  p1[1]=ctrL[i][1]; p1[2]=ctrL[i][2];
    p2[0]=ctrL[i][3];  p2[1]=ctrL[i][4]; p2[2]=ctrL[i][5];
    for(j=1; j<=num; j++){
      bezierpt3(j*dt,p0,p3,p1,p2,pt);
      nall=push3(pt[0],pt[1],pt[2], out);
    }
  }
  return nall;
}

int ospline3(int level, double ptL[][3], int num, double out[][3]){
  double ctrlist[DsizeM][6], eps0=pow(10,-6.0), tmp, cc;
  double p[3], q[3], p0[3], p3[3], p1[3], p2[3], pQ[3], pR[3];
  double ptlist[DsizeM][3], tmpmd2[DsizeM][3];
  int nd, i, j, n, npt, nall, nctr, closed, flg, ndin, din[DsizeM][2], ntmp;
  out[0][0]=0; nall=0;
  if(num==1){
    npt=length3(ptL);
    for(i=0; i<=npt; i++){
      out[i][0]=ptL[i][0]; out[i][1]=ptL[i][1]; out[i][2]=ptL[i][2];
    }
    nall=length3(out);
    return nall;
  }
  ndin=dataindexd3(2,ptL,din);
  for(nd=1; nd<=ndin; nd++){
    ptlist[0][0]=0;
    npt=din[nd][1]-din[nd][0];
    if(npt<=3){
      n=appendd3(0, din[nd][0], din[nd][0], ptL, ptlist);
      for(i=1; i<=npt-1; i++){
        pull3(din[nd][0]+i,ptL,p);
        pull3(din[nd][0]+i+1,ptL,q);
        for(j=1; j<=num; j++){
          p1[0]=p[0]+1.0*j/num*(q[0]-p[0]);
          p1[1]=p[1]+1.0*j/num*(q[1]-p[1]);
          p1[2]=p[2]+1.0*j/num*(q[2]-p[2]);
          n=addptd3(ptlist,p1);
        }
      }
      nall=appendd3(2, 1,n,ptlist,out);
      continue;
    }
    appendd3(0,din[nd][0],din[nd][1],ptL,ptlist);
    closed=0;
    pull3(1,ptlist,p);
    pull3(npt,ptlist,q);
    if(dist(3,p,q)<eps0){closed=1;}
    ctrlist[0][0]=0; nctr=0;
    for(i=1; i<=npt-1; i++){
      flg=0;
      pull3(i, ptlist,p1);
      pull3(i+1, ptlist,p2);
      if((i==1)||(i==npt-1)){
        flg=1;
        if(closed==0){
          pQ[0]=(p1[0]+2*p2[0])/3.0; 
          pQ[1]=(p1[1]+2*p2[1])/3.0; 
          pQ[2]=(p1[2]+2*p2[2])/3.0; 
          pR[0]=(2*p1[0]+p2[0])/3.0;
          pR[1]=(2*p1[1]+p2[1])/3.0;
          pR[2]=(2*p1[2]+p2[2])/3.0;
          nctr++;
          ctrlist[nctr][0]=pQ[0]; ctrlist[nctr][1]=pQ[1]; ctrlist[nctr][2]=pQ[2]; 
          ctrlist[nctr][3]=pR[0]; ctrlist[nctr][4]=pR[1]; ctrlist[nctr][5]=pR[2]; 
          flg=2;
        }
        else{
          if(i==1){
            pull3(npt-1, ptlist,p0);
            pull3(i+2, ptlist,p3);
          }
          else{
            pull3(i-1, ptlist, p0);
            pull3(2, ptlist, p3);
          }
        }
      }
      if(flg<=1){
        if(flg==0){
          pull3(i-1, ptlist, p0);
          pull3(i+2, ptlist, p3);
        }
        p[0]=p2[0]-p0[0]; p[1]=p2[1]-p0[1]; p[2]=p2[2]-p0[2]; 
        q[0]=p3[0]-p1[0]; q[1]=p3[1]-p1[1]; q[2]=p3[2]-p1[2]; 
        tmp=1+sqrt((1+dotprod(3,p,q)/dist(3,p0,p2)/dist(3,p1,p3))/2);
        cc=4*dist(3,p1,p2)/3/(dist(3,p0,p2)+dist(3,p1,p3))/tmp;
        pQ[0]=p1[0]+cc*(p2[0]-p0[0]); pQ[1]=p1[1]+cc*(p2[1]-p0[1]);
        pQ[2]=p1[2]+cc*(p2[2]-p0[2]);
        pR[0]=p2[0]+cc*(p1[0]-p3[0]); pR[1]=p2[1]+cc*(p1[1]-p3[1]); 
        pR[2]=p2[2]+cc*(p1[2]-p3[2]); 
        nctr++;
        ctrlist[nctr][0]=pQ[0]; ctrlist[nctr][1]=pQ[1]; ctrlist[nctr][2]=pQ[2]; 
        ctrlist[nctr][3]=pR[0]; ctrlist[nctr][4]=pR[1]; ctrlist[nctr][5]=pR[2]; 
      }
    }
    if(closed==0){
      p1[0]=ctrlist[2][0]; p1[1]=ctrlist[2][1]; p1[2]=ctrlist[2][2]; 
      pull3(2, ptlist, p2);
      pQ[0]=p2[0]+(p2[0]-p1[0]); pQ[1]=p2[1]+(p2[1]-p1[1]);
      pQ[2]=p2[2]+(p2[2]-p1[2]); 
      ctrlist[1][0]=pQ[0]; ctrlist[1][1]=pQ[1]; ctrlist[1][2]=pQ[2]; 
      ctrlist[1][3]=Inf; ctrlist[1][4]=0;  ctrlist[1][5]=0;
      p1[0]=ctrlist[nctr-1][3]; p1[1]=ctrlist[nctr-1][4]; p1[2]=ctrlist[nctr-1][5];
      pull3(nctr,ptlist,p2);
      pQ[0]=p2[0]+(p2[0]-p1[0]); pQ[1]=p2[1]+(p2[1]-p1[1]);
      pQ[2]=p2[2]+(p2[2]-p1[2]);
      ctrlist[nctr][0]=pQ[0]; ctrlist[nctr][1]=pQ[1]; ctrlist[nctr][2]=pQ[2];
      ctrlist[nctr][3]=Inf; ctrlist[1][4]=0; ctrlist[1][5]=0;
    }
    ctrlist[0][0]=nctr;
    if(length3(ptlist)>2){
      ntmp=bezier3(ptlist,ctrlist,num, tmpmd2);
      nall=appendd3(2,1,ntmp,tmpmd2,out);
    }
  }
  return nall;
}

void segplot(double x1,double y1,double x2,double y2,double seg[][2]){
  seg[0][0]=0;
  push2(x1,y1,seg);
  push2(x2,y2,seg);
}

void addsegplot(double x1,double y1,double seg[][2]){
  push2(x1,y1,seg);
}

void circledata(double cx,double cy,double r, int num,double out[][2]){
  double t,dt,pt[2];
  int i;
  dt=2*M_PI/num;
  out[0][0]=0;
  for(i=0; i<=num; i++){
    push2(cx+r*cos(i*dt),cy+r*sin(i*dt),out);
  }
}

void intersectline(double p1[2],double v1[2], double p2[2],double v2[2],double out[4]){
  double tmp,d,dt,ds,t,s,tmp1[2],tmp2[2],tmp3[2],pt[2];
  tmp=dotprod(2,v1,v2);
  tmp1[0]=tmp; tmp1[1]=pow(norm(2,v1),2.0);
  tmp2[0]=-pow(norm(2,v2),2.0);tmp2[1]=-tmp;
  pt[0]=p2[0]-p1[0];pt[1]=p2[1]-p1[1];
  tmp3[0]=dotprod(2,pt,v2);tmp3[1]=dotprod(2,pt,v1);
  crossprod(2,tmp1,tmp2,pt); d=pt[0];
  crossprod(2,v1,v2,pt); tmp=fabs(pt[0]);
  if(tmp>Eps){
    crossprod(2,tmp3,tmp2,pt); dt=pt[0];
    crossprod(2,tmp1,tmp3,pt); ds=pt[0];
    t=dt/d;
    s=ds/d;
    pt[0]=p1[0]+v1[0]*t; pt[1]=p1[1]+v1[1]*t;
    out[0]=pt[0];out[1]=pt[1];out[2]=t; out[3]=s;
  }else{
    pt[0]=p2[0]-p1[0];pt[1]=p2[1]-p1[1];
    crossprod(2,pt,v1,tmp1);
    tmp=tmp1[0]/norm(2,v1); 
    out[0]=fabs(tmp); out[1]=Inf;
  }
}

void intersectseg(double seg1[][2],double seg2[][2], double out[5]){
  double p1[2],q1[2],p2[2],q2[2],pt[2],pt1[2],nv[2],pts[DsizeS][4];
  double q1p1[2],q2p2[2],p1q2[2],q1p2[2],p1p2[2],q1q2[2];
  double tmp[2],tmp1[2],tmp2[2],tmp3[2],tmp4[2];
  double tmpd1,x,y,t,s,t1,s1,distance,tmpd[4],tmp3d[7];
  int ctr=0, i;
  pull2(1,seg1,p1); pull2(2,seg1,q1);
  pull2(1,seg2,p2); pull2(2,seg2,q2);
  q1p1[0]=q1[0]-p1[0];q1p1[1]=q1[1]-p1[1];
  q2p2[0]=q2[0]-p2[0];q2p2[1]=q2[1]-p2[1];
  p1q2[0]=p1[0]-q2[0];p1q2[1]=p1[1]-q2[1];
  q1p2[0]=q1[0]-p2[0];q1p2[1]=q1[1]-p2[1];
  p1p2[0]=p1[0]-p2[0];p1p2[1]=p1[1]-p2[1];
  p1q2[0]=p1[0]-q2[0];p1q2[1]=p1[1]-q2[1];
  q1q2[0]=q1[0]-q2[0];q1q2[1]=q1[1]-q2[1];
  if((norm(2,q1p1)<Eps)||(norm(2,q2p2)<Eps)){
    out[0]=-1; out[1]=Inf;
  }else{
    intersectline(p1,q1p1,p2,q2p2,tmpd);
    if(tmpd[1]<Inf-Eps){
      pt[0]=tmpd[0];pt[1]=tmpd[1];t=tmpd[2];s=tmpd[3];
      if((t*(t-1)<Eps)&&(s*(s-1)<Eps)){
        out[0]=0;out[1]=pt[0];out[2]=pt[1];out[3]=t;out[4]=s;
      }else{
        if(t<0){t=0;}; if(t>1){t=1;};
        if(s<0){s=0;}; if(s>1){s=1;};
        tmp3d[ctr]=norm(2,p1p2);ctr++;
        tmp3d[ctr]=norm(2,p1q2);ctr++;
        tmp3d[ctr]=norm(2,q1p2);ctr++;
        tmp3d[ctr]=norm(2,q1q2);ctr++;
        tmp1[0]=q2p2[1];tmp1[1]=-q2p2[0];
        intersectline(p1,tmp1,p2,q2p2,tmpd);
        if(tmpd[1]!=Inf){
          pt1[0]=tmpd[0];pt1[1]=tmpd[1];s1=tmpd[3];
          if(s1*(s1-1)<Eps){
            tmp3d[ctr]=dist(2,pt1,p1);ctr++;
          }
        }
        intersectline(q1,tmp1,p2,q2p2,tmpd);
        if(tmpd[1]!=Inf){
          pt1[0]=tmpd[0];pt1[1]=tmpd[1];s1=tmpd[3];
          if(s1*(s1-1)<Eps){
            tmp3d[ctr]=dist(2,pt1,q1);ctr++;
          }
        }
        tmp1[0]=q1p1[1];tmp1[1]=-q1p1[0];
        intersectline(p2,tmp1,p1,q1p1,tmpd);
		if(tmpd[1]!=Inf){
          pt1[0]=tmpd[0];pt1[1]=tmpd[1];s1=tmpd[3];
          if(s1*(s1-1)<Eps){
            tmp3d[ctr]=dist(2,pt1,p2);ctr++;
          }
        }
        intersectline(q2,tmp1,p1,q1p1,tmpd);
        if(tmpd[1]!=Inf){
          pt1[0]=tmpd[0];pt1[1]=tmpd[1];s1=tmpd[3];
          if(s1*(s1-1)<Eps){
            tmp3d[ctr]=dist(2,pt1,q2);ctr++;
          }
        }
        tmpd1=tmp3d[0];
        for(i=1;i<ctr;i++){
          if(tmp3d[i]<tmpd1){tmpd1=tmp3d[i];};
        }
        out[0]=tmpd1;out[1]=pt[0];out[2]=pt[1];
        out[3]=t;out[4]=s;
      }
    }else{
      distance=tmpd[0];
      nv[0]=q1p1[1]/norm(2,q1p1);nv[1]=-q1p1[0]/norm(2,q1p1);
      pts[0][0]=0;
      intersectline(p1,nv,p2,q2p2,tmpd);
      s1=tmpd[3];
      if((tmpd[1]!=Inf)&&(s1*(s1-1)<Eps)){
        x=(1-s1)*p2[0]+s1*q2[0];y=(1-s1)*p2[1]+s1*q2[1];
        push4(x,y,0,s1,pts);
      }
      intersectline(q1,nv,p2,q2p2,tmpd);
      s1=tmpd[3];
      if((tmpd[1]!=Inf)&&(s1*(s1-1)<Eps)){
        x=(1-s1)*p2[0]+s1*q2[0];y=(1-s1)*p2[1]+s1*q2[1];
        push4(x,y,1,s1,pts);
      }
      intersectline(p2,nv,p1,q1p1,tmpd);
      s1=tmpd[3];
      if((tmpd[1]!=Inf)&&(s1*(s1-1)<Eps)){
        x=(1-s1)*p1[0]+s1*q1[0];y=(1-s1)*p1[1]+s1*q1[1];
        push4(x,y,s1,0,pts);
      }
      intersectline(q2,nv,p1,q1p1,tmpd);
      if((tmpd[1]!=Inf)&&(s1*(s1-1)<Eps)){
        x=(1-s1)*p1[0]+s1*q1[0];y=(1-s1)*p1[1]+s1*q1[1];
        push4(x,y,s1,2,pts);
      }
      if(length4(pts)==0){
        tmpd1=norm(2,p1p2);
        if(norm(2,p1q2)<tmpd1){tmpd1=norm(2,p1q2);}
        if(norm(2,q1p2)<tmpd1){tmpd1=norm(2,q1p2);}
        if(norm(2,q1q2)<tmpd1){tmpd1=norm(2,q1q2);}
        out[0]=tmpd1;out[1]=Inf;
      }else{
        if(distance>Eps1){
          out[0]=distance;out[1]=Inf;
        }else{
          x=0; y=0;
          for(i=1; i<=length4(pts); i++){
            x=x+pts[i][0];
            y=y+pts[i][1];
          }
          tmp3[0]=x/length4(pts); tmp3[1]=y/length4(pts);
          nearestptpt(tmp3,seg1,tmpd);
          t=tmpd[2];
          nearestptpt(tmp3,seg2,tmpd);
          s=tmpd[2];
          out[0]=distance; out[1]=tmp3[0]; out[2]=tmp3[1];
          out[3]=t;out[4]=s;
        }
      }
    }
  }
}

int osplineseg(double ptlist[5][2],int num,double out[][2]){
  double p0[2],p1[2],p2[2],p3[2],p2p0[2],p3p1[2],p2p1[2];
  double tmp,cc,pq[2],pr[2],knots[3][2],ctrlist[2][4];
  pull2(1,ptlist,p0); pull2(2,ptlist,p1);
  pull2(3,ptlist,p2); pull2(4,ptlist,p3);
  p2p0[0]=p2[0]-p0[0];p2p0[1]=p2[1]-p0[1];
  p3p1[0]=p3[0]-p1[0];p3p1[1]=p3[1]-p1[1];
  p2p1[0]=p2[0]-p1[0];p2p1[1]=p2[1]-p1[1];
  tmp=norm(2,p2p0)*norm(2,p3p1);
  tmp=1+sqrt((1+dotprod(2,p2p0,p3p1)/tmp)/2);
  cc=4*norm(2,p2p1)/3/(norm(2,p2p0)+norm(2,p3p1))/tmp;
  pq[0]=p1[0]+cc*p2p0[0]; pq[1]=p1[1]+cc*p2p0[1];
  pr[0]=p2[0]-cc*p3p1[0];pr[1]=p2[1]-cc*p3p1[1];
  ctrlist[0][0]=0;
  push4(pq[0],pq[1],pr[0],pr[1],ctrlist);
  knots[0][0]=0;
  addptd2(knots,p1);addptd2(knots,p2);
  bezier(knots,ctrlist,num,out);
  return length2(out);
}

void intersectpartseg(double crv1[][2],double crv2[][2],int ii, int jj,int num,double out[6]){
  double distance=10*Eps2,seg1[3][2],seg2[3][2],tmpd[2],tmp1d[2],tmp2d[2];
  double tmp,snang,dst,tmpd5[5],os1[DsizeS][2],os2[DsizeS][2];
  double p0[2],p1[2],p2[2],p3[2],ptlist[5][2],regard[3][2];
  double tmp1md[20][2],tmpd3[3],tmp3md3[20][3],tmp2md3[20][3];
  double tmpd4[4],Eps00=pow(10,-8.0);
  double sx,sy;
  int kk,ll,nn;
  out[0]=Inf;
  for(kk=1;kk<6;kk++){out[kk]=0;}
  seg1[0][0]=0;seg2[0][0]=0;
  appendd2(1,ii,ii+1,crv1,seg1);
  appendd2(1,jj,jj+1,crv2,seg2);
  pull2(2,seg1,tmp1d);
  pull2(1,seg1,tmpd);
  tmp1d[0]=tmp1d[0]-tmpd[0]; tmp1d[1]=tmp1d[1]-tmpd[1];
  pull2(2,seg2,tmp2d);
  pull2(1,seg2,tmpd);
  tmp2d[0]=tmp2d[0]-tmpd[0]; tmp2d[1]=tmp2d[1]-tmpd[1];
  crossprod(2,tmp1d,tmp2d,tmpd);
  snang=fabs(tmpd[0])/(norm(2,tmp1d)*norm(2,tmp2d));
  intersectseg(seg1,seg2,tmpd5);
  dst=tmpd5[0];
  if(dst<Eps){
    if(dst>-Eps){
      out[0]=tmpd5[1];out[1]=tmpd5[2];out[2]=ii+tmpd5[3];
      out[3]=jj+tmpd5[4];out[4]=dst;out[5]=snang;
    }
  }else{
    if(dst<Eps2){
      os1[0][0]=0;os2[0][0]=0;
      pull2(1,seg1,tmp1d);
      pull2(2,seg1,tmp2d);
      tmpd[0]=tmp2d[0]-tmp1d[0];tmpd[1]=tmp2d[1]-tmp1d[1];
      if((length2(crv1)==2)||(norm(2,tmpd)>distance-Eps)){
        appendd2(1,1,2,seg1,os1);
      }else{
        pull2(1,seg1,p1);pull2(2,seg1,p2);
        if(ii==1){
          pull2(3,crv1,p3);
          tmpd[0]=p2[0]-p1[0];tmpd[1]=p2[1]-p1[1];
          tmp1d[0]=(p1[0]+p2[0])/2;
          tmp1d[1]=(p1[1]+p2[1])/2;
          tmp2d[0]=tmp1d[0]+tmpd[1];
          tmp2d[1]=tmp1d[1]-tmpd[0];
          regard[0][0]=0;
          addptd2(regard,tmp1d); addptd2(regard,tmp2d);
	      reflectpoint(p3,regard,p0);
        }else{
          if(ii==length2(crv1)-1){
            pull2(ii-1,crv1,p0);
            tmpd[0]=p2[0]-p1[0]; tmpd[1]=p2[1]-p1[1];
            tmp1d[0]=(p1[0]+p2[0])/2;
            tmp1d[1]=(p1[1]+p2[1])/2;
            tmp2d[0]=tmp1d[0]+tmpd[1];
            tmp2d[1]=tmp1d[1]-tmpd[0];
            regard[0][0]=0;
            addptd2(regard,tmp1d); addptd2(regard,tmp2d);
	        reflectpoint(p0,regard,p3);
          }else{
            pull2(ii-1,crv1,p0);pull2(ii+2,crv1,p3);
          }
        }
        ptlist[0][0]=0;
        addptd2(ptlist,p0);addptd2(ptlist,p1);
        addptd2(ptlist,p2);addptd2(ptlist,p3);
        osplineseg(ptlist,num,os1);
      }
      pull2(1,seg2,tmp1d);
      pull2(2,seg2,tmp2d);
      if((length2(crv2)==2)||(dist(2,tmp2d,tmp1d)>distance-Eps)){
        appendd2(1,1,2,seg2,os2);
      }else{
        pull2(1,seg2,p1);pull2(2,seg2,p2);
        if(jj==1){
          pull2(3,crv2,p3);
          tmpd[0]=p2[0]-p1[0];tmpd[1]=p2[1]-p1[1];
          tmp1d[0]=(p1[0]+p2[0])/2;
          tmp1d[1]=(p1[1]+p2[1])/2;
          tmp2d[0]=tmp1d[0]+tmpd[1];
          tmp2d[1]=tmp1d[1]-tmpd[0];
          regard[0][0]=0;
          addptd2(regard,tmp1d); addptd2(regard,tmp2d);
	      reflectpoint(p3,regard,p0);
        }else{
          if(jj==length2(crv2)-1){
            pull2(jj-1,crv2,p0);
            tmpd[0]=p2[0]-p1[0]; tmpd[1]=p2[1]-p1[1];
            tmp1d[0]=(p1[0]+p2[0])/2;
            tmp1d[1]=(p1[1]+p2[1])/2;
            tmp2d[0]=tmp1d[0]+tmpd[1];
            tmp2d[1]=tmp1d[1]-tmpd[0];
            regard[0][0]=0;
            addptd2(regard,tmp1d); addptd2(regard,tmp2d);
	        reflectpoint(p0,regard,p3);
          }else{
            pull2(jj-1,crv2,p0);pull2(jj+2,crv2,p3);
          }
        }
        ptlist[0][0]=0;
        addptd2(ptlist,p0);addptd2(ptlist,p1);
        addptd2(ptlist,p2);addptd2(ptlist,p3);
        osplineseg(ptlist,num,os2);
      }
      tmp2md3[0][0]=0;
      for(kk=1;kk<length2(os1);kk++){
        for(ll=1;ll<length2(os2);ll++){
          seg1[0][0]=0; seg2[0][0]=0;
          pull2(kk,os1,tmpd);addptd2(seg1,tmpd);
          pull2(kk+1,os1,tmpd);addptd2(seg1,tmpd);
          pull2(ll,os2,tmpd);addptd2(seg2,tmpd);
          pull2(ll+1,os2,tmpd);addptd2(seg2,tmpd);
          intersectseg(seg1,seg2,tmpd5);
          if((tmpd5[0]<Eps1)&&(tmpd5[1]<Inf-Eps)){
            if(tmpd5[0]<dst+Eps00){
              dst=tmpd5[0];
              tmp3md3[0][0]=0;
              for(nn=1;nn<=length3(tmp2md3);nn++){
                pull3(nn,tmp2md3,tmpd3);
                if(tmpd3[0]<dst+Eps00){
                  addptd3(tmp3md3,tmpd3);
                }
              }
              tmp2md3[0][0]=0;
              for(nn=1;nn<=length3(tmp3md3);nn++){
                pull3(nn,tmp3md3,tmpd3);
                addptd3(tmp2md3,tmpd3);
              }
              push3(dst,tmpd5[1],tmpd5[2],tmp2md3);
            }
          }
        }
      }
      if(length3(tmp2md3)>0){
        tmp1md[0][0]=0;
        sx=0; sy=0;
        for(nn=1;nn<=length3(tmp2md3);nn++){
          pull3(nn,tmp2md3,tmpd3);
          push2(tmpd3[1],tmpd3[2],tmp1md);
          sx=sx+tmpd3[1];
          sy=sy+tmpd3[2];
        }
        sx=sx/length3(tmp2md3);
        sy=sy/length3(tmp2md3);
        p0[0]=sx; p0[1]=sy;
        pull2(ii,crv1,p1); pull2(ii+1,crv1,p2);
        tmp1d[0]=p2[0]-p1[0];tmp1d[1]=p2[1]-p1[1];
        tmpd[0]=tmp1d[1];tmpd[1]=-tmp1d[0]; 
        intersectline(p0,tmpd,p1,tmp1d,tmpd4);
        tmp=tmpd4[3];
        if(tmp<0){tmp=0;}
        if(tmp>1){tmp=1;}
        out[0]=sx;out[1]=sy;out[2]=ii+tmp;
        pull2(jj,crv2,p1); pull2(jj+1,crv2,p2);
        tmp1d[0]=p2[0]-p1[0];tmp1d[1]=p2[1]-p1[1];
        tmpd[0]=tmp1d[1];tmpd[1]=-tmp1d[0]; 
        intersectline(p0,tmpd,p1,tmp1d,tmpd4);
        tmp=tmpd4[3];
        if(tmp<0){tmp=0;}
        if(tmp>1){tmp=1;}
        out[3]=jj+tmp;out[4]=dst;out[5]=snang;
      }
    }
  }
}

void collectsameseg(double ptdL[][6],double rL[][6]){
  double Eps00=pow(10,-8.0),tmp1d[2],tmp2d[2],tmp1d6[6],tmp2d6[6];
  int ii,jj,kk,istr,nr,numL[40],diffL[40];
  double s1,e1,s2,e2,dst,tmp1,tmp2,tmp1md6[40][6];
  rL[0][0]=0;
  if(length6(ptdL)==0){
    return;
  }
  for(ii=2;ii<=length6(ptdL);ii++){
    pull6(ii,ptdL,tmp1d6);addptd6(rL,tmp1d6);
  }
  tmp1md6[0][0]=0;
  pull6(1,ptdL,tmp1d6);
  addptd6(tmp1md6,tmp1d6);
  kk=tmp1d6[2];
  if(tmp1d6[2]<kk+Eps00){
    s1=kk-1-Eps00;e1=s1+2+2*Eps00;
  }else{
    s1=kk-Eps00; e1=s1+1+2*Eps00;
  }
  kk=tmp1d6[3];
  if(tmp1d6[3]<kk+Eps00){
    s2=kk-1-Eps00;e2=s2+2+2*Eps00;
  }else{
    s2=kk-Eps00; e2=s2+1+2*Eps00;
  }
  numL[0]=0;
  for(ii=1;ii<=length6(rL);ii++){
    pull6(ii,rL,tmp1d6);
    tmp1=tmp1d6[2]; tmp2=tmp1d6[3];
    if((tmp1>s1)&&(tmp1<e1)&&(tmp2>s2)&&(tmp2<e2)){
      addptd6(tmp1md6,tmp1d6);
      appendi1(ii,numL);
    }
  }
  dst=100;
  for(ii=1;ii<=length6(tmp1md6);ii++){
    pull6(ii,tmp1md6,tmp1d6);
    if(tmp1d6[4]<dst){
      dst=tmp1d6[4];
    }
  }
  ptdL[0][0]=0;
  for(ii=1;ii<=length6(tmp1md6);ii++){
    pull6(ii,tmp1md6,tmp1d6);
    if(tmp1d6[4]<dst+Eps00){
      addptd6(ptdL,tmp1d6);
    }
  }
  for(ii=0;ii<=length6(rL);ii++){
    diffL[ii]=0;
  }
  for(ii=1;ii<=numL[0];ii++){
    kk=numL[ii];
    diffL[kk]=1;
  }
  nr=length6(rL);
  rL[0][0]=0;
  for(ii=1;ii<=nr;ii++){
    if(diffL[ii]==0){
      pull6(ii,rL,tmp1d6);addptd6(rL,tmp1d6);
    }
  }
}

void intersectcurvesPp(double crv1s[][2],double crv2s[][2],int nbez,double out[][6]){
  double Eps00=pow(10,-8.0),Dist=10*Eps2, crv1[DsizeL][2],crv2[DsizeL][2];
  double tmp1md6[DsizeS][6],tmp2md6[DsizeS][6],tmpmd1[DsizeS];
  double tmpd[2],tmp1d[2],tmp2d[2],tmpd6[6],tmp1d6[6];
  double sx,sy,dst,ans1[4],ans2[4];
  int ii,jj,kk,nall,self,js,je,din[DsizeS][2];
  crv1[0][0]=0;
  pull2(1,crv1s,tmpd);addptd2(crv1,tmpd);
  for(ii=2;ii<=length2(crv1s);ii++){
    pull2(length2(crv1),crv1,tmp1d);
    pull2(ii,crv1s,tmp2d);
    if(dist(2,tmp1d,tmp2d)>Eps){
      addptd2(crv1,tmp2d);
    }
  }
  crv2[0][0]=0;
  pull2(1,crv2s,tmpd);
  addptd2(crv2,tmpd);
  for(ii=2;ii<=length2(crv2s);ii++){
    pull2(length2(crv2),crv2,tmp1d);
    pull2(ii,crv2s,tmp2d);
    if(dist(2,tmp1d,tmp2d)>Eps){
      addptd2(crv2,tmp2d);
    }
  }
  if(length2(crv1)!=length2(crv2)){
    self=0;
  }else{
    self=1;
    for(ii=1;ii<=length2(crv1);ii++){
      pull2(ii,crv1,tmp1d);pull2(ii,crv2,tmp2d);
      if(dist(2,tmp1d,tmp2d)>0){
        self=0;
        break;
      }
    }
  }
  tmp1md6[0][0]=0;
  for(ii=1;ii<=length2(crv1)-1;ii++){ 
	if(self==0){
      js=1; je=length2(crv2)-1;
    }else{
      js=ii+2; je=length2(crv2)-1;
    }
    for(jj=js;jj<=je;jj++){
      intersectpartseg(crv1,crv2,ii,jj,nbez,tmpd6);
      if(tmpd6[0]<Inf-Eps){
		tmpd[0]=tmpd6[0];tmpd[1]=tmpd6[1];
        if(length6(tmp1md6)==0){
          addptd6(tmp1md6,tmpd6);
        }else{
          pull6(length6(tmp1md6),tmp1md6,tmp1d6);
          tmp1d[0]=tmp1d6[0];tmp1d[1]=tmp1d6[1];
          if(dist(2,tmp1d,tmpd)>Eps1){
            addptd6(tmp1md6,tmpd6);
          }
        }
        if(self==1){
		  push6(tmpd6[0],tmpd6[1],tmpd6[3],tmpd6[2],tmpd6[4],tmpd6[5],tmp1md6);
        }
      }
    }
  }
  out[0][0]=0;
  tmp2md6[0][0]=0;
  while(length6(tmp1md6)>0){
	collectsameseg(tmp1md6,tmp2md6);
    appendd6(2,1,length6(tmp1md6),tmp1md6,out);
	tmp1md6[0][0]=0;
    for(ii=1;ii<=length6(tmp2md6);ii++){
      pull6(ii,tmp2md6,tmpd6);addptd6(tmp1md6,tmpd6);
    }
  }
  dataindexd6(2,out,din);
  for(ii=1;ii<=length2i(din);ii++){
    tmp1md6[0][0]=0;
    appendd6(2,din[ii][0],din[ii][1],out,tmp1md6);
    if(length6(tmp1md6)==1){
      replacelistd6(2,ii,out,tmp1md6);
    }else{
      dst=100;
      for(jj=1;jj<=length6(tmp1md6);jj++){
        pull6(jj,tmp1md6,tmpd6);
        if(tmpd6[4]<dst){
          dst=tmpd6[4];
        }
      }
	  sx=0; sy=0;nall=0;
      for(jj=1;jj<=length6(tmp1md6);jj++){
        pull6(jj,tmp1md6,tmpd6);
        if(tmpd6[4]<dst+Eps00){
          nall++;
          sx=sx+tmpd6[0]; sy=sy+tmpd6[1];
        }
      }
      tmp1d[0]=sx/nall; tmp1d[1]=sy/nall;
      nearestptpt(tmp1d,crv1,ans1);
      nearestptpt(tmp1d,crv2,ans2);
      tmp2md6[0][0]=0;
      push6(sx/nall,sy/nall,ans1[2],ans2[2],dst,tmp1md6[1][5],tmp2md6);
      replacelistd6(2,ii,out,tmp2md6);
    }
  }
}

void intersectcurves(double crv1[][2],double crv2[][2],int nbez,double out[][2]){
  double out6[DsizeS][6],tmpd[2],tmpd6[6];
  int jj;
  intersectcurvesPp(crv1,crv2,nbez,out6);
  out[0][0]=0;
  for(jj=1;jj<=length6(out6);jj++){
    pull6(jj,out6,tmpd6);push2(tmpd6[0],tmpd6[1],out);
  }
}
