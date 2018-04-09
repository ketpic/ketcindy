// 17.06.16 crvsfparadata changed ( num of devision )

int output3(const char *var, const char *fname, int level, double out[][3]){
  int nall=floor(out[0][0]+0.5), ndin, din[DsizeM][2],i,j,ctr;
  double tmpd[3];
  FILE *fp;
  fp=fopen(fname,"w");
  if (fp == NULL) { 
    printf("cannot open\n");  
    return -1;
//    exit(1); 
  }
  ndin=dataindexd3(level, out,din);
  fprintf(fp,"%s//\n",var); //17.05.29
//  fprintf(fp,"%s3d//\n",var2);
  for(i=1; i<=ndin; i++){
    fprintf(fp,"start//\n");
    fprintf(fp,"[");
    ctr=0;
    for(j=din[i][0]; j<=din[i][1]; j++){
      pull3(j,out,tmpd);
      fprintf(fp,"[ %7.5f, %7.5f, %7.5f]",tmpd[0],tmpd[1],tmpd[2]);
      ctr++;
      if(ctr==5){
        fprintf(fp,"]//\n[");
        ctr=0;
      }else{
        if(j<din[i][1]){
          fprintf(fp,",");
        }
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

int output3h(const char *var, const char *varh, const char *fname, double out[][3]){
  // 17.06.09
  double out1[DsizeLL][3], tmpd[3];
  int din1[DsizeM][2],din2[DsizeM][2], i, j,ctr;
  FILE *fp;
  fp=fopen(fname,"w");
  if (fp == NULL) { 
    printf("cannot open\n");  
    return -1;
  }
  dataindexd3(3,out,din1);
  out1[0][0]=0;
  appendd3(0, din1[1][0],din1[1][1],out,out1);
  dataindexd3(2, out1,din2);
  fprintf(fp,"%s//\n",var); 
  for(i=1; i<=length2i(din2); i++){
    fprintf(fp,"start//\n");
    fprintf(fp,"[");
    ctr=0;
    for(j=din2[i][0]; j<=din2[i][1]; j++){
      pull3(j,out1,tmpd);
      fprintf(fp,"[ %7.5f, %7.5f, %7.5f]",tmpd[0],tmpd[1],tmpd[2]);
      ctr++;
      if(ctr==5){
        if(j<din2[i][1]){
          fprintf(fp,"]//\n[");
          ctr=0;
        }
      }else{
        if(j<din2[i][1]){
          fprintf(fp,",");
        }
      }
    }
    fprintf(fp,"]//\n");
    fprintf(fp,"end//\n");
  }
  out1[0][0]=0;
  fprintf(fp,"%s//\n",varh); //17.06.16from
  appendd3(0, din1[2][0],din1[2][1],out,out1);
  dataindexd3(2, out1,din2);
  for(i=1; i<=length2i(din2); i++){
    fprintf(fp,"start//\n");
    fprintf(fp,"[");
    for(j=din2[i][0]; j<=din2[i][1]; j++){
      pull3(j,out1,tmpd);
      fprintf(fp,"[ %7.5f, %7.5f, %7.5f]",tmpd[0],tmpd[1],tmpd[2]);
      ctr++;
      if(ctr==5){
        if(j<din2[i][1]){
          fprintf(fp,"]//\n[");
          ctr=0;
        }
      }else{
        if(j<din2[i][1]){
          fprintf(fp,",");
        }
      }
    }
    fprintf(fp,"]//\n");
//    if(i<ndin2){
      fprintf(fp,"end//\n");
//    }
//    else{
//      fprintf(fp,"end////\n");
//    }
  }
  fprintf(fp,"//\n");
  fclose(fp);
  return 0;
}

int writedataC(const char *fname, double out[][3]){
  int i, nall;
  FILE *fp;
  nall=length3(out);
  fp=fopen(fname,"w");
  for(i=1; i<=nall; i++){
    fprintf(fp,"%7.5f %7.5f %7.5f\n",out[i][0],out[i][1],out[i][2]);
  }
  fprintf(fp,"%7.5f %7.5f %7.5f\n",Inf,Inf,Inf);
  fclose(fp);
  return nall;
}

int readdataC(const char *fname, double data[][3]){
  int i, j, ndata=0;
  FILE *fp;
  fp=fopen(fname,"r");
  if(fp==NULL){
    printf("file not found\n");
    return 1;
  }
  while( ! feof(fp) && ndata<DsizeL){
    ndata++;
    for(j=0;j<=2;j++){
      fscanf(fp,"%lf",&data[ndata][j]);
    }
    if(data[ndata][1]==Inf){
      ndata--;
      break;
    }
  }
  fclose(fp);
   data[0][0]=ndata;
  return ndata;
}

void parapt(double pt3[3],double pt2[2]){
  if(fabs(pt3[0])>Inf-1){
    pt2[0]=pt3[0]; pt2[1]=pt3[1];
  }
  else{
    pt2[0]=-pt3[0]*sin(PHI)+pt3[1]*cos(PHI);
    pt2[1]=-pt3[0]*cos(PHI)*cos(THETA)-pt3[1]*sin(PHI)*cos(THETA)+pt3[2]*sin(THETA);
  }
}

int projpara(double p3[][3], double p2[][2]){
  double pt3[3], pt2[2];
  int i, nall, nall2;
  nall=length3(p3);
  p2[0][0]=0;
  for(i=1; i<=nall; i++){
    pull3(i,p3,pt3);
    parapt(pt3,pt2);
    nall2=addptd2(p2,pt2);
  }
  return nall2;
}

double invparapt(double ph, double fh[][2], double fk[][3],double out[3]){
  int n, nfk=length3(fk), nph=length2(fh);
  double s0=ph-n, ak[3], bk[3], ah[2], bh[2], pk[3];
  if(nfk>2){
    n=trunc(ph);
    s0=ph-n;
    if(ph>nph-Eps){
      out[0]=fk[nfk][0]; out[1]=fk[nfk][1]; out[2]=fk[nfk][2];
      return nph;
    }
  }
  else{
    n=1;
    s0=ph-1;
  }
  ak[0]=fk[n][0]; ak[1]=fk[n][1]; ak[2]=fk[n][2]; 
  bk[0]=fk[n+1][0]; bk[1]=fk[n+1][1]; bk[2]=fk[n+1][2]; 
  ah[0]=fh[n][0]; ah[1]=fh[n][1]; 
  bh[0]=fh[n+1][0]; bh[1]=fh[n+1][1];
  out[0]=(1-s0)*ak[0]+s0*bk[0];
  out[1]=(1-s0)*ak[1]+s0*bk[1];
  out[2]=(1-s0)*ak[2]+s0*bk[2];
  return n+s0;
}

int surfcurve(short ch,int level, double crv[][2], double pdata[][3]){
  double p2[2], pt[3];
  int i, n, nall;
  n=length2(crv);
  pdata[0][0]=0;
  for(i=1; i<=n; i++){
    pull2(i,crv,p2);
    surffun(ch,p2[0],p2[1],pt);
    nall=addptd3(pdata,pt);
  }
  return nall;
}

int xyzax3data(double x0, double x1, double y0, double y1, double z0, double z1, 
                           double out[][3]){
  int nall;
  double pd3[10][3];
  out[0][0]=0; nall=0;
  pd3[0][0]=2;
  pd3[1][0]=x0; pd3[1][1]=0; pd3[1][2]=0;
  pd3[2][0]=x1; pd3[2][1]=0; pd3[2][2]=0;
  nall=appendd3(2,1,2,pd3,out);
  pd3[1][0]=0; pd3[1][1]=y0; pd3[1][2]=0;
  pd3[2][0]=0; pd3[2][1]=y1; pd3[2][2]=0;
  nall=appendd3(2,1,2,pd3,out);
  pd3[1][0]=0; pd3[1][1]=0; pd3[1][2]=z0;
  pd3[2][0]=0; pd3[2][1]=0; pd3[2][2]=z1;
  nall=appendd3(2,1,2,pd3,out);
  return nall;
}

void evlptablepara(short ch){
  int i, j;
  double u,v,u1,u2,v1,v2,pt1[3],pt2[3],pt2d1[2],pt2d2[2],dxu,dyu,dxv,dyv;
  double du=(Urng[1]-Urng[0])/Mdv, dv=(Vrng[1]-Vrng[0])/Ndv;
  double eps=0.00001;
  for (j= 0; j < Ndv+1; j++) {
    v=Vrng[0]+j*dv;
    v1=v-eps/2; v2=v+eps/2;
    for (i = 0; i < Mdv+1; i++) {
      u=Urng[0]+i*du;
      u1=u-eps/2; u2=u+eps/2;
      surffun(ch,u1,v,pt1); parapt(pt1,pt2d1);
	  surffun(ch,u2,v,pt2); parapt(pt2,pt2d2);	  
      dxu=(pt2d2[0]-pt2d1[0])/eps;
      dyu=(pt2d2[1]-pt2d1[1])/eps;
      surffun(ch,u,v1,pt1); parapt(pt1,pt2d1);
      surffun(ch,u,v2,pt2); parapt(pt2,pt2d2);
      dxv=(pt2d2[0]-pt2d1[0])/eps;
      dyv=(pt2d2[1]-pt2d1[1])/eps;
      Zval[j][i]=dxu*dyv-dxv*dyu;     
    }
  }
  for (i = 0; i < Mdv+1; i++) {
    Xval[i]=Urng[0]+i*du;
  }
  for (j= 0; j < Ndv+1; j++) {
    Yval[j]=Vrng[0]+j*dv;
  }
};

double evlpfun(short ch, double u, double v){
  double u1,u2,v1,v2,pt1[3],pt2[3],pt2d1[2],pt2d2[2],dxu,dyu,dxv,dyv;
  double du=(Urng[1]-Urng[0])/Mdv, dv=(Vrng[1]-Vrng[0])/Ndv;
  double eps=0.00001;
  u1=u-eps/2; u2=u+eps/2;
  if(u1<Urng[0]){u1=Urng[0];}
  if(u2>Urng[1]){u2=Urng[1];}
  surffun(ch,u1,v,pt1); parapt(pt1,pt2d1);
  surffun(ch,u2,v,pt2); parapt(pt2,pt2d2);	  
  dxu=(pt2d2[0]-pt2d1[0])/(u2-u1);
  dyu=(pt2d2[1]-pt2d1[1])/(u2-u1);
  v1=v-eps/2; v2=v+eps/2;
  if(v1<Vrng[0]){v1=Vrng[0];}
  if(v2>Vrng[1]){v2=Vrng[1];}
  surffun(ch,u,v1,pt1); parapt(pt1,pt2d1);
  surffun(ch,u,v2,pt2); parapt(pt2,pt2d2);
  dxv=(pt2d2[0]-pt2d1[0])/(v2-v1);
  dyv=(pt2d2[1]-pt2d1[1])/(v2-v1);
  return dxu*dyv-dxv*dyu;     
};

int envelopedata(short ch, double out[][2]){
  int i, j, k, ctrq=0,ctr, nall;
  double uval1,uval2,vval1,vval2,eval11,eval12,eval21,eval22;
  double pl[5][2], vl[5], ql[11][2], out2[DsizeM][2];
  double du=(Urng[1]-Urng[0])/Mdv;
  double dv=(Vrng[1]-Vrng[0])/Mdv;
  ctr=0;
  for (j = 0; j < Ndv; j++) {
    vval1=Vrng[0]+j*dv;
    vval2=Vrng[0]+(j+1)*dv;
    uval1=Urng[0];
    eval11=evlpfun(ch,uval1,vval1);
    eval12=evlpfun(ch,uval1,vval2);
    for (i = 0; i < Mdv; i++) {
      uval2=Urng[0]+(i+1)*du;
      eval21=evlpfun(ch,uval2,vval1);
      eval22=evlpfun(ch,uval2,vval2);
	  pl[0][0]=uval1; pl[0][1]=vval1; vl[0]=eval11;
      pl[1][0]=uval2; pl[1][1]=vval1; vl[1]=eval21;
      pl[2][0]=uval2; pl[2][1]=vval2; vl[2]=eval22;
      pl[3][0]=uval1; pl[3][1]=vval2; vl[3]=eval12;
	  pl[4][0]=uval1; pl[4][1]=vval1; vl[4]=eval11;
      ctrq=0;
      for (k = 0; k < 4; k++) {
        if(fabs(vl[k])<=Eps){
          ql[ctrq][0]=pl[k][0];
          ql[ctrq][1]=pl[k][1];
          ctrq++;
        }
        else if(vl[k]>Eps){
          if(vl[k+1]< -Eps){
            ql[ctrq][0]=1/(vl[k]-vl[k+1])*(-vl[k+1]*pl[k][0]+vl[k]*pl[k+1][0]);
            ql[ctrq][1]=1/(vl[k]-vl[k+1])*(-vl[k+1]*pl[k][1]+vl[k]*pl[k+1][1]);
            ctrq++;
          }
        }
        else{
          if(vl[k+1]>Eps){
            ql[ctrq][0]=1/(-vl[k]+vl[k+1])*(vl[k+1]*pl[k][0]-vl[k]*pl[k+1][0]);
            ql[ctrq][1]=1/(-vl[k]+vl[k+1])*(vl[k+1]*pl[k][1]-vl[k]*pl[k+1][1]);
            ctrq++;
          }
        }
      }
      uval1=uval2;
      eval11=eval21;
      eval12=eval22;
      if(ctrq==2){
        if(ctr>0){
          ctr++;
          out[ctr][0]=Inf;
          out[ctr][1]=2;  // 2 <- 0 ?
        }
        ctr++;
        out[ctr][0]=ql[0][0];
        out[ctr][1]=ql[0][1];
        ctr++;
        out[ctr][0]=ql[1][0];
        out[ctr][1]=ql[1][1];
      }
    }
  }
  out[0][0]=ctr;
  if(ctr>0){
    nall=connectseg(out, Eps, out2);
    out[0][0]=0;
    nall=appendd2(2,1,nall,out2,out);
  }
  return nall;
}

/*

int implicitplot(double out[][2]){
  int i, j, k, ctrq=0,ctr, nall;
  double pl[5][2], vl[5], ql[11][2], out2[DsizeM][2];
  ctr=0;
  for (j = 0; j < Ndv; j++) {
    for (i = 0; i < Mdv; i++) {
	  pl[0][0]=Xval[i]; pl[0][1]=Yval[j]; vl[0]=Zval[j][i];
      pl[1][0]=Xval[i+1]; pl[1][1]=Yval[j]; vl[1]=Zval[j][i+1];
      pl[2][0]=Xval[i+1]; pl[2][1]=Yval[j+1]; vl[2]=Zval[j+1][i+1];
      pl[3][0]=Xval[i]; pl[3][1]=Yval[j+1]; vl[3]=Zval[j+1][i];
	  pl[4][0]=Xval[i]; pl[4][1]=Yval[j]; vl[4]=Zval[j][i];
      ctrq=0;
      for (k = 0; k < 4; k++) {
        if(fabs(vl[k])<=Eps){
          ql[ctrq][0]=pl[k][0];
          ql[ctrq][1]=pl[k][1];
          ctrq++;
        }
        else if(vl[k]>Eps){
          if(vl[k+1]< -Eps){
            ql[ctrq][0]=1/(vl[k]-vl[k+1])*(-vl[k+1]*pl[k][0]+vl[k]*pl[k+1][0]);
            ql[ctrq][1]=1/(vl[k]-vl[k+1])*(-vl[k+1]*pl[k][1]+vl[k]*pl[k+1][1]);
            ctrq++;
          }
        }
        else{
          if(vl[k+1]>Eps){
            ql[ctrq][0]=1/(-vl[k]+vl[k+1])*(vl[k+1]*pl[k][0]-vl[k]*pl[k+1][0]);
            ql[ctrq][1]=1/(-vl[k]+vl[k+1])*(vl[k+1]*pl[k][1]-vl[k]*pl[k+1][1]);
            ctrq++;
          }
        }
      }
      if(ctrq==2){
        if(ctr>0){
          ctr++;
          out[ctr][0]=Inf;
          out[ctr][1]=2;  // 2 <- 0 ?
        }
        ctr++;
        out[ctr][0]=ql[0][0];
        out[ctr][1]=ql[0][1];
        ctr++;
        out[ctr][0]=ql[1][0];
        out[ctr][1]=ql[1][1];
      }
    }
  }
  out[0][0]=ctr;
  if(ctr>0){
    nall=connectseg(out, Eps, out2);
    out[0][0]=0;
    nall=appendd2(2,1,nall,out2,out);
  }
  return nall;
}

*/

int cuspsplitpara(short ch,double pdata[][2], double outkL[][3]){
  int i, j, ng, n, nd, ndd, ndrop, is, ncusp=0, ncusppt,st, en, npk,nph, cflg;
  int cusp[DsizeM], cuspflg;
  int ntmp,ntmp1,ntmp2, ntmpnum, noutkL=0, noutk=0, nout=0;
  int din[DsizeM][2], dind[DsizeM][2], drop[DsizeL], tmpnum[DsizeM];
  double eps=pow(10.0,-6.0);
  double vtmp, vtmp1,kaku,cva, ps[2], pe[2],v1[2],v2[2];
  double tmp[2],tmp1[2],tmp2[2],pt3d[3],pt2d[2],q3d[3],q2d[2];
  double ptk[DsizeM][3],pth[DsizeM][2], outk[DsizeM][3];
  double ptxy[DsizeM][2],tmp3d[DsizeM][3];
  double tmp3d1[DsizeM][3],tmp3d2[DsizeM][3],tmp2d[DsizeM][2];
  outkL[0][0]=0;
  cusp[0]=0;
  Cuspsplitpt[0][0]=0;
  nd=dataindexd2(0,pdata,din);
  for(ng=1; ng<=nd; ng++){
    ptk[0][0]=0; pth[0][0]=0;
    st=din[ng][0]; en=din[ng][1];
    ptxy[0][0]=0;
    n=appendd2(0,st,en,pdata,ptxy);
    npk=0; nph=0;
    for(i=1; i<=en-st+1; i++){
      pull2(st+i-1,pdata,tmp);
      surffun(ch,tmp[0],tmp[1],pt3d);
      parapt(pt3d,pt2d);
      if(i==1){
        npk=addptd3(ptk,pt3d);
        nph=addptd2(pth,pt2d);
      }
      else{
        pull2(nph,pth,tmp1);
        if(dist(2,tmp1,pt2d)>eps){
          npk=addptd3(ptk,pt3d);
          nph=addptd2(pth,pt2d);
        }
      }
    }
    if(nph==0){
      npk=0;
      return 0;
    };
    pull2(1,pth,ps);
    pull2(nph,pth,pe);
    cflg=0; 
    if(dist(2,ps,pe)<Eps1){cflg=1;}
    ncusp=0; cusp[0]=0;
    cva=cos(10*M_PI/180);
    for(i=1; i<=nph-1; i++){
      if(nph==2){break;}
      pull2(i,pth,tmp);
      tmp[0]=pth[i][0]; tmp[1]=pth[i][1];
      if(i==1){
        if(cflg==0){continue;}
        pull2(nph-1,pth,tmp1);
      }
      else{
        pull2(i-1,pth,tmp1);
      }
      pull2(i+1,pth,tmp2);
      v1[0]=tmp[0]-tmp1[0]; v1[1]=tmp[1]-tmp1[1];
      v2[0]=tmp2[0]-tmp[0]; v2[1]=tmp2[1]-tmp[1];
      vtmp=v1[0]*v2[0]+v1[1]*v2[1];
      tmp[0]=0; tmp[1]=0;
      vtmp=vtmp/(dist(2,v1,tmp)*dist(2,v2,tmp));
      cuspflg=0;
      if(vtmp<cva){
        pt2d[0]=pth[i][0]; pt2d[1]=pth[i][1]; 
        kaku=acos(vtmp)*180/M_PI;
        if(v1[0]*v2[1]-v1[1]*v2[0]<0){
          kaku=-kaku;
        }
        cuspflg=0;
        for(j=i+1; j<=nph-1; j++){
          if(fabs(kaku)>90){
            cuspflg=1;
            break;
          }
          pull2(j,pth,q2d);
          if(dist(2,pt2d,q2d)>Eps1){
            break;
          }
          v1[0]=q2d[0]-pth[j-1][0]; v1[1]=q2d[1]-pth[j-1][1];
          v2[0]=pth[j+1][0]-q2d[0]; v2[1]=pth[j+1][1]-q2d[1];
          vtmp=v1[0]*v2[0]+v1[1]*v2[1];
          tmp[0]=0; tmp[1]=0;
          vtmp=vtmp/(dist(2,v1,tmp)*dist(2,v2,tmp));
          vtmp=acos(vtmp)*180/M_PI;
          if(v1[0]*v2[1]-v1[1]*v2[0]<0){
            vtmp=-vtmp;
          }
          kaku=kaku+vtmp;
        }
        if(cuspflg==1){
          ntmp=trunc((i+j)*0.5);
          i=j;
          if(cusp[0]==0){
            ncusp=appendi1(cusp,ntmp);
          }
          else{
            ncusp=appendi1(cusp,ntmp);
          }
        }
      }
    }
    if(cflg==0){
      ncusp=prependi1(1,cusp);
      ncusp=appendi1(cusp,nph);
    }
    else if(ncusp==0){
       ncusp=prependi1(1,cusp);
       ncusp=appendi1(cusp,nph);
    }
    else if(cusp[1]==1){
      ncusp=appendi1(cusp,nph);
    }
    else{
      ntmp=cusp[1];
      ntmp1=nph;
      tmp2d[0][0]=0;
      n=appendd2(0,ntmp,ntmp1,pth,tmp2d);
      n=appendd2(0,2,ntmp,pth,tmp2d);
      pth[0][0]=0;
      nph=appendd2(0,1,n,tmp2d,pth);
      tmp3d[0][0]=0;
      n=appendd3(0,ntmp,ntmp1,ptk,tmp3d);
      n=appendd3(0,2,ntmp,ptk,tmp3d);
      ptk[0][0]=0;
      npk=appendd3(0,1,n,tmp3d,ptk);
      for(i=1; i<=cusp[0]; i++){
        cusp[i]=cusp[i]-ntmp+1;
      }
      ncusp=appendi1(cusp,nph);
    }
    if(ncusp==2){
      pull2(nph,pth,tmp);
      if(npk>=2){
        ncusppt=addptd2(Cuspsplitpt,tmp);
        noutkL=appendd3(2,1,npk,ptk,outkL);
      }
      continue;
    }
    outk[0][0]=0;
    is=1;
    for(i=1; i<=ncusp-1; i++){
      ntmp1=cusp[is]; ntmp2=cusp[i+1];
      pull2(ntmp1,pth,tmp1);
      pull2(ntmp2,pth,tmp2);
      if(dist(2,tmp1,tmp2)>Eps1){
        tmp3d[0][0]=0;
        n=appendd3(0,ntmp1,ntmp2,ptk,tmp3d);
        noutk=appendd3(2,1,n,tmp3d,outk);
        ncusppt=addptd2(Cuspsplitpt,tmp2);
        is=i+1;
      }
    }
    noutkL=appendd3(2,1,noutk,outk,outkL);
  }
  n=projpara(outkL,tmp2d);
  ndrop=dropnumlistcrv(tmp2d,Eps1*0.5,drop);
  nd=dataindexd3(2,outkL,din);
  ndd=dataindexi1(drop,dind);
  tmp3d2[0][0]=0; ntmp2=0;
  for(i=1; i<=nd; i++){
    tmp3d[0][0]=0; ntmp=0;
    ntmp=appendd3(0,din[i][0],din[i][1],outkL,tmp3d);
	tmpnum[0]=0; ntmpnum=0;
	for(j=dind[i][0]; j<=dind[i][1]; j++){
      ntmpnum=appendi1(tmpnum,drop[j]);
    }
    tmp3d1[0][0]=0; ntmp1=0;
    for(j=1; j<=ntmpnum; j++){
      pt3d[0]=tmp3d[tmpnum[j]][0];
      pt3d[1]=tmp3d[tmpnum[j]][1];
      pt3d[2]=tmp3d[tmpnum[j]][2];
      ntmp1=addptd3(tmp3d1,pt3d);
    }
    if(ntmp1>0){
      ntmp2=appendd3(2,1,ntmp1,tmp3d1,tmp3d2);
    }
  }
  outkL[0][0]=0; noutkL=0;
  noutkL=appendd3(0,1,ntmp2,tmp3d2,outkL);
  return noutkL;
}

int makexybdy(short ch,double ehL[][2]){
  int i, nehL, ntmpd2;
  double ptd3[3],ptd2[2],tmpd2[DsizeM][2],du,dv;
  ehL[0][0]=0; nehL=0;
  du=(Urng[1]-Urng[0])/Mdv;
  dv=(Vrng[1]-Vrng[0])/Ndv;
  if(DrawE==1){
    tmpd2[0][0]=0; ntmpd2=0;
    for(i=0; i<=Ndv; i++){
      surffun(ch,Urng[1],Vrng[0]+i*dv,ptd3);
      ntmpd2=push2(ptd3[0],ptd3[1],tmpd2);
    }
    nehL=appendd2(2,1,ntmpd2,tmpd2,ehL);
  }
  if(DrawN==1){
    tmpd2[0][0]=0; ntmpd2=0;
    for(i=0; i<=Mdv; i++){
      surffun(ch,Urng[0]+i*du,Vrng[1],ptd3);
      ntmpd2=push2(ptd3[0],ptd3[1],tmpd2);
    }
    nehL=appendd2(2,1,ntmpd2,tmpd2,ehL);
  }
  if(DrawW==1){
    tmpd2[0][0]=0; ntmpd2=0;
    for(i=0; i<=Ndv; i++){
      surffun(ch,Urng[0],Vrng[0]+i*dv,ptd3);
      ntmpd2=push2(ptd3[0],ptd3[1],tmpd2);
    }
    nehL=appendd2(2,1,ntmpd2,tmpd2,ehL);
  }
  if(DrawS==1){
    tmpd2[0][0]=0; ntmpd2=0;
    for(i=0; i<=Mdv; i++){
      surffun(ch,Urng[0]+i*du,Vrng[0],ptd3);
      ntmpd2=push2(ptd3[0],ptd3[1],tmpd2);
    }
    nehL=appendd2(2,1,ntmpd2,tmpd2,ehL);
  }
  return nehL;
}

void partitionseg(double fig[][2],double gL[][2], int ns, double parL[]){
  int ii,jj,kk,n,din[DsizeM][2],din2[DsizeM][2];
  double eps0=pow(10,-5.0),tmpd4[4], tmpd6[6],tmp,tmp2;
  double p[2], q[2], pd3[3], ans[4], tmp1d1[DsizeM], tmp2d1[DsizeM];
  double other[DsizeM], g[DsizeM][2], kouL[DsizeS][4],kouL6[DsizeS][6];
  if(ns>1){
    dataindexd1(Otherpartition,din);
    other[0]=0;
    for(ii=din[ns][0]; ii<=din[ns][1]; ii++){
      appendd1(other,Otherpartition[ii]);
    }
  }else{
    other[0]=0;
  }
  parL[0]=0;
  appendd1(parL,1);
  appendd1(parL,length2(fig));
  if(length1(other)>0){
    for(ii=1; ii<=length1(other); ii++){
      appendd1(parL,other[ii]);
    }
  }
  dataindexd2(2,gL,din);
  for(n=ns; n<=din[0][0]; n++){
    g[0][0]=0; 
    appendd2(2,din[n][0],din[n][1],gL,g);
    intersectcurvesPp(fig,g,20,kouL6);
    kouL[0][0]=0;
    for(ii=1;ii<=length6(kouL6);ii++){
      pull6(ii,kouL6,tmpd6);
      push4(tmpd6[0],tmpd6[1],tmpd6[2],tmpd6[3],kouL);
    }
    tmp1d1[0]=0;tmp2d1[0]=0;
    for(jj=1;jj<=length4(kouL);jj++){
      pull4(jj,kouL,tmpd4);
      tmp=tmpd4[2];
      if((tmp>1+Eps)&&(tmp<length2(fig)-Eps)){
        appendd1(tmp1d1,tmp);
      }
      tmp=tmpd4[3];
      if((tmp>1+Eps)&&(tmp<length2(g)-Eps)){
        appendd1(tmp2d1,tmp);
      }
    }
    for(jj=1;jj<=length1(tmp1d1);jj++){
      appendd1(parL,tmp1d1[jj]);
    }
    if((ns>0)&&(n>ns)&&(length1(tmp2d1)>0)){
      dataindexd1(Otherpartition,din);
      tmp1d1[0]=0;
      for(ii=1;ii<=length2i(din);ii++){
        if(ii==n){
          for(kk=1;kk<=length1(tmp2d1);kk++){
            appendd1(tmp1d1,tmp2d1[kk]);
          }
        }
        for(jj=din[ii][0]; jj<=din[ii][1];jj++){
           appendd1(tmp1d1,Otherpartition[jj]);
        }
        if(ii<length2i(din)){
          appendd1(tmp1d1,Inf);
        }
      }
    }
    dataindexd1(tmp1d1,din);
    Otherpartition[0]=0;
    for(ii=1;ii<=length2i(din);ii++){
      for(jj=din[ii][0];jj<=din[ii][1];jj++){
        appendd1(Otherpartition,tmp1d1[jj]);
      }
    }
  }
  simplesort(parL);
  tmp1d1[0]=0;
  for(ii=1;ii<=length1(parL);ii++){
    appendd1(tmp1d1,parL[ii]);
  }
  parL[0]=0;
  tmp2=-1;
  for(jj=1;jj<=length1(tmp1d1);jj++){
    tmp=tmp1d1[jj];
    if(fabs(tmp-tmp2)>Eps1){
      appendd1(parL,tmp);
      tmp2=tmp;
    }
  }
}

double funpthiddenQ(short ch,double u, double v, double pa[3]){
  double Vec[3]={sin(THETA)*cos(PHI),sin(THETA)*sin(PHI),cos(THETA)};
  double eps0=pow(10,-4.0)*(XMAX-XMIN)/10, pt[3], out;
  surffun(ch,u, v, pt);
  if((fabs(Vec[1])>eps0)||(fabs(Vec[0])>eps0)){
    out=(Vec[1]*(pt[0]-pa[0])-Vec[0]*(pt[1]-pa[1]));
  }
  else{
    out=pt[0]-pa[0];
  }
  return out;
}

void makevaltable(double pta[3]){
  double eps0=pow(10,-6.0), u, v, du, dv, p[3];
  int i, j, nx=0, ny=0; ;
  du=(Urng[1]-Urng[0])/Mdv;
  dv=(Vrng[1]-Vrng[0])/Ndv;
  for(j=0; j<=Ndv; j++){
    v=Vrng[0]+j*dv;
    for(i=0; i<=Mdv; i++){
      u=Urng[0]+i*du;
      Zval[j][i]=funpthiddenQ(Ch,u, v, pta);
    }
  }
  for(i=0; i<=Mdv; i++){
    Xval[i]=Urng[0]+i*du;
  }
  for(j=0; j<=Ndv; j++){
    Yval[j]=Vrng[0]+j*dv;
  }
}

int pthiddenQ(short ch,double pta[3], int uveq, double eps[2]){
  int i, j, k, out, nqL, nsL, nptL, flg, nxt;
  double Vec[3]={sin(THETA)*cos(PHI),sin(THETA)*sin(PHI),cos(THETA)};
  double eps0, epspt, vec1[3], po[3]={0,0,0}, tmpd1, tmp1d1, tmp2d1, m1, m2;
  double tmp3d1, tmp4d1, tmp5d1, tmp6d1, tmpd3[3], v1, v2, v3;
  double tmpd2[2], p1[2], p2[2], ptuv[2], puv1[2], puv2[2];
  double  p1d3[3], p2d3[3], ptd3[3];
  double ptL[DsizeM][6], sL[DsizeM][7], qL[DsizeM][2], pL[5][2], vL[5];
//     Out=1 : hidden
//     SL : List of segments near PtA+Vec
  eps0=pow(10,-4.0)*(XMAX-XMIN)/10.0;
  epspt=eps[0]*(XMAX-XMIN)/10.0;
  out=0;
  po[0]=0; po[1]=0; po[2]=0;
  tmpd1=1/dist(3,Vec,po);
  vec1[0]=tmpd1*Vec[0]; 
  vec1[1]=tmpd1*Vec[1]; 
  vec1[2]=tmpd1*Vec[2]; 
  nptL=0;
  makevaltable(pta);
  nsL=0;
  for(j=0; j<=Ndv-1; j++){
    for(i=0; i<=Mdv-1; i++){
      pL[0][0]=Xval[i]; pL[0][1]=Yval[j]; vL[0]=Zval[j][i];
      pL[1][0]=Xval[i+1]; pL[1][1]=Yval[j]; vL[1]=Zval[j][i+1];
      pL[2][0]=Xval[i+1]; pL[2][1]=Yval[j+1]; vL[2]=Zval[j+1][i+1];
      pL[3][0]=Xval[i]; pL[3][1]=Yval[j+1]; vL[3]=Zval[j+1][i];
      pL[4][0]=Xval[i]; pL[4][1]=Yval[j]; vL[4]=Zval[j][i];
      qL[0][0]=0; nqL=0;
      for(k=0; k<=3; k++){
        p1[0]=pL[k][0]; p1[1]=pL[k][1]; 
        p2[0]=pL[k+1][0]; p2[1]=pL[k+1][1]; 
        m1=vL[k]; m2=vL[k+1];
        if((m1>=eps0)&&(m2>=eps0)){
          continue;
        }
        if((m1<=-eps0)&&(m2<=-eps0)){
          continue;
        }
        if(fabs(m1)<eps0){
          tmpd2[0]=p1[0]; tmpd2[1]=p1[1];
        }
        else if(fabs(m2)<eps0){
          continue;
        }
        else{
          tmpd2[0]=1/(m1-m2)*(-m2*p1[0]+m1*p2[0]);
          tmpd2[1]=1/(m1-m2)*(-m2*p1[1]+m1*p2[1]);
        }
        nqL++;
        qL[nqL][0]=tmpd2[0]; qL[nqL][1]=tmpd2[1];
      }
      if(nqL==2){
        puv1[0]=qL[1][0]; puv1[1]=qL[1][1]; 
        puv2[0]=qL[2][0]; puv2[1]=qL[2][1];  
        surffun(ch,puv1[0],puv1[1],p1d3);
        surffun(ch,puv2[0],puv2[1],p2d3);
        if(dist(2,p1d3,p2d3)<eps0){
          continue;
        }
        tmp1d1=dist(3,p1d3,pta);
        tmpd3[0]=p1d3[0]-pta[0];
        tmpd3[1]=p1d3[1]-pta[1];
        tmpd3[2]=p1d3[2]-pta[2]; 
        tmp2d1=dotprod(3,tmpd3,vec1);
        tmp3d1=sqrt(fabs(pow(tmp1d1,2.0)-pow(tmp2d1,2.0)));
        tmp4d1=dist(3,p2d3, pta);
        tmpd3[0]=p2d3[0]-pta[0];
        tmpd3[1]=p2d3[1]-pta[1];
        tmpd3[2]=p2d3[2]-pta[2]; 
        tmp5d1=dotprod(3,tmpd3,vec1);
        tmp6d1=sqrt(fabs(pow(tmp4d1,2.0)-pow(tmp5d1,2.0)));
        if(tmp2d1<tmp5d1){
          tmpd3[0]=p1d3[0]; tmpd3[1]=p1d3[1]; tmpd3[2]=p1d3[2];
          p1d3[0]=p2d3[0]; p1d3[1]=p2d3[1]; p1d3[2]=p2d3[2];
          p2d3[0]=tmpd3[0]; p2d3[1]=tmpd3[1]; p2d3[2]=tmpd3[2];
          tmpd1=tmp2d1; tmp2d1=tmp5d1; tmp5d1=tmpd1;
          tmpd1=tmp3d1; tmp3d1=tmp6d1; tmp6d1=tmpd1;
        }
        if((tmp3d1<eps[1]*epspt)&&(tmp6d1<eps[1]*epspt)){
          if(tmp2d1>-eps0){
            if(tmp5d1<-eps0){
              nsL++;
              sL[nsL][0]=p1d3[0]; sL[nsL][1]=p1d3[1]; sL[nsL][2]=p1d3[2];
              sL[nsL][3]=p2d3[0]; sL[nsL][4]=p2d3[1]; sL[nsL][5]=p2d3[2];
              sL[nsL][6]=-1;
            }
            else{
              nsL++;
              sL[nsL][0]=p1d3[0]; sL[nsL][1]=p1d3[1]; sL[nsL][2]=p1d3[2];
              sL[nsL][3]=p2d3[0]; sL[nsL][4]=p2d3[1]; sL[nsL][5]=p2d3[2];
              sL[nsL][6]=1;
            }
          }
        }
        v1=vec1[0]; v2=vec1[1]; v3=vec1[2];
        if(fabs(v1)>eps0){
          m1=pta[2]+v3/v1*(p1d3[0]-pta[0])-p1d3[2];
          m2=pta[2]+v3/v1*(p2d3[0]-pta[0])-p2d3[2];
        }
        else if(fabs(v2)>eps0){
          m1=pta[2]+v3/v2*(p1d3[1]-pta[1])-p1d3[2];
          m2=pta[2]+v3/v2*(p2d3[1]-pta[1])-p2d3[2];
        }
        else{
          m1=pta[1]-p1d3[1];
          m2=pta[1]-p2d3[1];
        }
        if(m1*m2>=0){
          if(((m1>eps0)&&(m2>eps0))||((m1<-eps0)&&(m2<-eps0))){
            continue;
          }
          if(fabs(m1)<=eps0){
            ptd3[0]=p1d3[0];  ptd3[1]=p1d3[1];  ptd3[2]=p1d3[2]; 
            ptuv[0]=puv1[0]; ptuv[1]=puv1[1];
          }
          else{
            ptd3[0]=p2d3[0];  ptd3[1]=p2d3[1];  ptd3[2]=p2d3[2]; 
            ptuv[0]=puv2[0]; ptuv[1]=puv2[1];
          }
        }
        else{
          ptd3[0]=1/(m1-m2)*(-m2*p1d3[0]+m1*p2d3[0]);
          ptd3[1]=1/(m1-m2)*(-m2*p1d3[1]+m1*p2d3[1]);
          ptd3[2]=1/(m1-m2)*(-m2*p1d3[2]+m1*p2d3[2]);
          ptuv[0]=1/(m1-m2)*(-m2*puv1[0]+m1*puv2[1]);
        }
        tmpd3[0]=ptd3[0]-pta[0];
        tmpd3[1]=ptd3[1]-pta[1]; 
        tmpd3[2]=ptd3[2]-pta[2]; 
        tmp1d1=dotprod(3,tmpd3,vec1);
        tmp2d1=fabs(tmp1d1);
        tmpd3[0]=p1d3[0]-p2d3[0];
        tmpd3[1]=p1d3[1]-p2d3[1]; 
        tmpd3[2]=p1d3[2]-p2d3[2]; 
        tmp3d1=dotprod(3,tmpd3,vec1);
        tmp4d1=dist(3,p1d3,p2d3);
        tmp6d1=tmp3d1/tmp4d1;
        if(tmp1d1>eps0){
          if(fabs(tmp6d1)>0.75){
            nptL++;
            ptL[nptL][0]=ptd3[0]; ptL[nptL][1]=ptd3[1]; ptL[nptL][2]=ptd3[2];
            ptL[nptL][3]=p2d3[0]; ptL[nptL][4]=p2d3[1]; ptL[nptL][5]=p2d3[2];
            continue;
          }
          if(tmp2d1>epspt){
            return 1;
          }
          if(tmp2d1<2*epspt){
            continue;
          }
        }
      }
    }
  }
  if(nptL==0){
    return 0;
  }
  for(i=1; i<=nsL; i++){
    p2d3[0]=sL[i][3]; p2d3[1]=sL[i][4]; p2d3[2]=sL[i][5]; 
    flg=0;
    for(j=1; j<=nsL; j++){
      p1d3[0]=sL[j][0]; p1d3[1]=sL[j][1]; p1d3[2]=sL[j][2]; 
      if(dist(3,p1d3,p2d3)<eps0){
        sL[i][6]=j;
        flg=1;
        break;
      }
    }
    if((flg==0)&&(sL[i][6]>0)){
      sL[i][6]=-2;
    }
  }
  for(i=1; i<=nptL; i++){
    p2d3[0]=ptL[i][3]; p2d3[1]=ptL[i][4]; p2d3[2]=ptL[i][5]; 
    flg=0;
    for(j=1; j<=nsL; j++){
      p1d3[0]=sL[j][0]; p1d3[1]=sL[j][1]; p1d3[2]=sL[j][2];
      if(dist(3,p1d3,p2d3)<eps0){
        flg=1;
        break;
      }
    }
    if(flg==0){
      ptd3[0]=ptL[i][0]; ptd3[1]=ptL[i][1]; ptd3[2]=ptL[i][2];
      tmpd1=dist(3,p2d3,ptd3);
      tmpd3[0]=p2d3[0]-ptd3[0]; 
      tmpd3[1]=p2d3[1]-ptd3[1];
      tmpd3[2]=p2d3[2]-ptd3[2]; 
      tmp1d1=fabs(dotprod(3,tmpd3,vec1));
      tmp2d1=sqrt(fabs(pow(tmpd1,2.0)-pow(tmp1d1,2.0)));
      tmp3d1=tmp2d1*dist(3,ptd3,pta)/tmpd1;
      if(tmp3d1>epspt/5){
        return 1;
      }
      else{
        continue;
      }
    }
    nxt=sL[j][6];
    while(nxt>0){
      ptd3[0]=sL[nxt][3]; ptd3[1]=sL[nxt][4]; ptd3[2]=sL[nxt][5];
      nxt=sL[nxt][6];
    }
    if(nxt==-2){
      return 1;
    }
    else{
      out=0;
    }
  }
  return out;
}

int nohiddenpara2(double paL[], double fk[][3], int uveq, double figkL[][3]){
  double eps0=pow(10,-5.0), s, p1[2], p2[2], q[2],tmpd1, tmpd2[2], epstmp[2];
  double fh[DsizeM][2], pta[3], ptap[2], vec[3];
  double figL[DsizeM][2], tmpmd2[DsizeM][2], tmpmd3[DsizeM][3];
  double tmp1d2[2], tmp2d2[2], tmp3d2[2], tmpd3[3],tmpd4[4];
  double pd2[2], qd2[2], pd3[3], qd3[3], sp, sq, tp, tq, dtmp, dtmp1, dtmp2;
  int ncusp=floor(Cusppt[0][0]+0.5), seL[DsizeM], npaL=floor(paL[0]+0.5);
  int i, n, nfh, nfk, nfigL, nfigkL, nhidden, cspflg, nseL=0, ntmp, flg, tmpi1[DsizeM];
  nfk=length3(fk);
  nfh=projpara(fk, fh);
  pull2(1,fh,p1);
  pull2(nfh,fh,p2);
  cspflg=1;
  for(i=1; i<=ncusp; i++){
    pull2(i, Cusppt, tmpd2);
    if(dist(2,tmpd2,p1)<eps0){
      if(cspflg==1){
        cspflg=2;
     }
     else if(cspflg==3){
        cspflg=6;
     }
     continue;
    }
    if(dist(2,tmpd2,p2)<eps0){
      if(cspflg==1){
        cspflg=3;
     }
     else if(cspflg==2){
        cspflg=6;
     }
     continue;
    }
  }
  seL[0]=0; nseL=0;
  for(n=1; n<=npaL-1; n++){
    s=(paL[n]+paL[n+1])/2.0;
    ntmp=invparapt(s,fh,fk, pta);
    parapt(pta,ptap);
    epstmp[0]=Eps1; epstmp[1]=1;
    if((n==1)&&(cspflg % 2==0)){
      pull2(1,fh,p1);
      dtmp=fmin(Eps1*dist(2,ptap, p1),Eps1); 
	  epstmp[0]=dtmp; epstmp[1]=1; 
    }
    if((n==npaL-1)&&(cspflg % 3==0)){
      pull2(nfh,fh,p1);
      dtmp=fmin(Eps1*dist(2, ptap, p1), Eps1); 
	  epstmp[0]=dtmp; epstmp[1]=1; 
    }
    flg=pthiddenQ(Ch,pta, uveq, epstmp);
    if(flg==0){
      nseL=appendi1(seL,n);
    }
  }
  figL[0][0]=0; nfigL=0;
  figkL[0][0]=0; nfigkL=0;
  for(i=1; i<=nseL; i++){
    pointoncurve(paL[seL[i]], fh, Eps, tmp1d2);
    pointoncurve(paL[seL[i]+1], fh, Eps, tmp2d2);
    if(i==1){
      copyd(0,1,tmp1d2,pd2);
      sp=paL[seL[i]];
      copyd(0,1,tmp2d2,qd2);
      sq=paL[seL[i]+1];
    }
    else{
      if(memberi(seL[i]-1,seL)==1){
        copyd(0,1,tmp2d2,qd2);
        sq=paL[seL[i]+1];
      }
      else{
        ntmp=partcrv(sp,sq,fh,tmpmd2);
        nfigL=appendd2(2,1,ntmp,tmpmd2,figL);
        tp=invparapt(sp,fh,fk, tmpd3);
        tq=invparapt(sq,fh,fk,tmpd3);
        ntmp=partcrv3(tp,tq,fk,tmpmd3);
        nfigkL=appendd3(2,1,ntmp,tmpmd3,figkL);
         copyd(0,1,tmp1d2,pd2);
        sp=paL[seL[i]];
        copyd(0,1,tmp2d2,qd2);
        sq=paL[seL[i]+1];
      }
    }
  }
  if(nseL>0){
    if(dist(2,pd2,qd2)>Eps1){
      nearestptpt(pd2,fh,tmpd4);
      dtmp1=tmpd4[2];
      nearestptpt(qd2,fh,tmpd4);
      dtmp2=tmpd4[2];
      ntmp=partcrv(dtmp1,dtmp2,fh,tmpmd2);
      nfigL=appendd2(2,1,ntmp,tmpmd2,figL);
      tp=invparapt(sp,fh,fk,tmpd3);
      tq=invparapt(sq,fh,fk,tmpd3);
      ntmp=partcrv3(tp,tq,fk,tmpmd3);
      nfigkL=appendd3(2,1,ntmp, tmpmd3, figkL);
    }
    else{
      nfigL=appendd2(2,1,nfh, fh, figL);
      nfigkL=appendd3(2,1,nfk,fk,figkL);
    }
  }
  tmpi1[0]=0; ntmp=0;
  for(i=1; i<=npaL-1; i++){
    if(memberi(i,seL)==0){
      ntmp=appendi1(tmpi1,i);
    }
  }
  copyi(0,ntmp,tmpi1,seL);
  seL[0]=ntmp; nseL=ntmp;
  Hiddendata[0][0]=0; nhidden=0;
  for(i=1; i<=nseL; i++){
    dtmp=paL[seL[i]];
    pointoncurve(dtmp,fh,Eps,tmp1d2);
    dtmp=paL[seL[i]+1];
    pointoncurve(dtmp,fh,Eps, tmp2d2);
    if(i==1){
      copyd(0,1,tmp1d2,pd2);
      sp=paL[seL[i]];
      copyd(0,1,tmp2d2,qd2);
      sq=paL[seL[i]+1];
    }
    else{
      if(memberi(seL[i]-1,seL)==1){
        copyd(0,1,tmp2d2,qd2);
        sq=paL[seL[i]+1];
      }
      else{
        tp=invparapt(sp,fh,fk,tmpd3);
        tq=invparapt(sq,fh,fk,tmpd3);
        ntmp=partcrv3(tp,tq,fk,tmpmd3);
        nhidden=appendd3(2,1,ntmp,tmpmd3,Hiddendata);
        copyd(0,1,tmp1d2,pd2);
        sp=paL[seL[i]];
        copyd(0,1,tmp2d2,qd2);
        sq=paL[seL[i]+1];
      }
    }
  }
  if(nseL>0){
    if(dist(2,pd2,qd2)>Eps1){
      tp=invparapt(sp,fh,fk,tmpd3);
      tq=invparapt(sq,fh,fk,tmpd3);
      ntmp=partcrv3(tp,tq,fk,tmpmd3);
      nhidden=appendd3(2,1,ntmp,tmpmd3,Hiddendata);
    }
    else{
      nhidden=appendd3(2,1,nfk,fk,Hiddendata);
    }
  }
  return nfigkL;
}

int borderparadata(short ch,double fkL[][3], double fsL[][3]){
  double ekL[DsizeL][3], fall[DsizeL][2], fbdxy[DsizeL][2];
  double tmpd3[DsizeM][3],  tmpd2[DsizeM][2], p[2], p3[3];
  double figkL[DsizeM][3], du, dv;
  int i, j, nall, nekL, nfsL, nfkL=length3(fkL), nfall, nfbdxy;
  int ndin, din[DsizeS][2], ndin2,din2[DsizeM][2];
  int ntmp, ntmpd3,ntmpd2, npar=0, nfigkL;
  double par[DsizeM];
  du=(Urng[1]-Urng[0])/Mdv;
  dv=(Vrng[1]-Vrng[0])/Ndv;
  fsL[0][0]=0;
  ekL[0][0]=0; nekL=0;
  if(DrawE==1){
    tmpd2[0][0]=0; nall=0;
    for(j=0; j<=Ndv; j++){
      nall=add2(tmpd2, Urng[1], Vrng[0]+j*dv);
    }
    nall=surfcurve(ch,2, tmpd2,tmpd3);
    nekL=appendd3(2,1,nall,tmpd3,ekL);
  }
  if(DrawN==1){
    tmpd2[0][0]=0; nall=0;
    for(j=0; j<=Mdv; j++){
      nall=add2(tmpd2, Urng[0]+j*du, Vrng[1]);
    }
    nall=surfcurve(ch,2, tmpd2,tmpd3);
    nekL=appendd3(2,1,nall,tmpd3,ekL);
  }
  if(DrawW==1){
    tmpd2[0][0]=0; nall=0;
    for(j=0; j<=Ndv; j++){
      nall=add2(tmpd2, Urng[0], Vrng[0]+j*dv);
    }
    nall=surfcurve(ch,2, tmpd2,tmpd3);
    nekL=appendd3(2,1,nall,tmpd3,ekL);
  }
  if(DrawS==1){
    tmpd2[0][0]=0; nall=0;
    for(j=0; j<=Mdv; j++){
      nall=add2(tmpd2, Urng[0]+j*du, Vrng[0]);
    }
    nall=surfcurve(ch,2, tmpd2,tmpd3);
    nekL=appendd3(2,1,nall,tmpd3,ekL);
  }
  if(nekL>0){
    nfkL=appendd3(2,1,nekL,ekL,fkL);
  }
  nfall=projpara(fkL,fall);
  nfbdxy=makexybdy(ch,fbdxy);
  ndin=dataindexd2(2,fall,din);
  Borderpt[0][0]=0;
  Otherpartition[0]=0;
  for(i=1; i<=ndin-1; i++){
    Otherpartition[i]=Inf; Otherpartition[0]++;
  }
  Borderhiddendata[0][0]=0;  
  ndin2=dataindexd3(2,fkL,din2);
  for(i=1; i<= ndin2; i++){
	tmpd3[0][0]=0;
    ntmpd3=appendd3(0,din2[i][0],din2[i][1],fkL,tmpd3);
    ntmpd2=projpara(tmpd3,tmpd2);
    partitionseg(tmpd2,fall, 1,par);
	if(length1(par)>2){
      ntmp=npar-1;
      tmpd2[0][0]=0; ntmpd2=0;
      for(j=2; j<=ntmp; j++){
        pull2(j,Partitionpt,p);
        ntmpd2=addptd2(tmpd2, p);
      }
      ntmp=appendd2(0, 1,ntmpd2,tmpd2,Borderpt);
    }
    tmpd3[0][0]=0;
    for(j=din2[i][0]; j<=din2[i][1]; j++){
      pull3(j,fkL,p3);
      ntmpd3=addptd3(tmpd3,p3);
    }
	nfigkL=nohiddenpara2(par,tmpd3,1, figkL);
	if(nfigkL>0){
      nfsL=appendd3(2,1,nfigkL,figkL, fsL);
    }
    ntmp=length3(Hiddendata);
    if(ntmp>0){
      appendd3(2,1,ntmp,Hiddendata,Borderhiddendata);
    }
  }
  return nfsL;
}

int dropnumlistcrv3(double qd[][3], double eps1, int out[]){
  int i,j,k,nout,nall=length3(qd), nd, se, en, npd, nptL;
  int din[DsizeM][2],ptL[DsizeL];
  double eps=pow(10.0,-6.0), pd[DsizeL][3], p[3], tmp2d[3];
  out[0]=0; nout=0;
  nd=dataindexd3(2,qd,din);
  for(j=1; j<=nd; j++){
    se=din[j][0]; en=din[j][1];
    pd[0][0]=0; npd=0;
    npd=appendd3(0,se,en,qd,pd);
    ptL[0]=0; nptL=0;
    nptL=appendi1(ptL,1);
    pull3(1,pd,p);
    for(k=2; k<=npd-1; k++){
      pull3(k,pd,tmp2d);
      if(dist(3,p,tmp2d)>eps1){
        nptL=appendi1(ptL,k);
        pull3(k,pd,p);
      }
    }
    pull3(npd-1,pd,p);
    pull3(npd,pd,tmp2d);
    if(dist(3,p,tmp2d)>eps){  // eps -> eps1 ? 
      nptL=appendi1(ptL,npd);
    }
//    if(nptL==1){ptL[0]=0; nptL=0;}//180318db
    if(nout>0){
      nout=appendi1(out,Infint);
    }
    for(i=1; i<=nptL; i++){
      nout=appendi1(out,ptL[i]);
    }
  }
  out[0]=nout;
  return nout;
}

int sfbdparadata(short ch,double outd3[][3]){
  double pdatad3[DsizeL][3];
  double pts[DsizeL][2],out3md[DsizeL][2],eps;
  double tmpmd[DsizeL][2],tmp1md[DsizeL][2],tmp2md[DsizeL][2],tmp3md[DsizeL][2];
  double tmpd[2],tmp1d[2],tmpd3[3],tmp1d3[3],tmp2d3[3],tmp2md3[DsizeL][3];
  int din[DsizeS][2],nlist[DsizeL];
  int ii,jj,kk,n,nall,flg;
  envelopedata(ch, tmp3md);
  out3md[0][0]=0;
  pts[0][0]=0;
  dataindexd2(2,tmp3md,din);
  for(jj=1;jj<=length2i(din);jj++){
	tmp1md[0][0]=0;
    tmp2md3[0][0]=0;
    for(kk=din[jj][0];kk<=din[jj][1];kk++){
      pull2(kk,tmp3md,tmpd);
      addptd2(tmp1md,tmpd);
      surffun(ch,tmpd[0],tmpd[1],tmpd3);
      addptd3(tmp2md3,tmpd3);
    }
    dropnumlistcrv3(tmp2md3,Eps1,nlist);
    if(nlist[0]==1){
      pull2(nlist[1],tmp1md,tmpd);
      addptd2(pts,tmpd);
    }else{
      tmpmd[0][0]=0;
      for(kk=1;kk<=nlist[0];kk++){
        pull2(nlist[kk],tmp1md,tmpd);
        addptd2(tmpmd,tmpd);
      }
      if(length2(tmpmd)>0){
        appendd2(2,1,length2(tmpmd),tmpmd,out3md);
      }
    }      
  }
  tmp3md[0][0]=0;
  appendd2(2,1,length2(pts),pts,tmp3md);
  pts[0][0]=0;
  for(ii=1;ii<=length2(tmp3md);ii++){
    pull2(ii,tmp3md,tmpd);
    surffun(ch,tmpd[0],tmpd[1],tmp1d3);
    flg=0;
    for(jj=1;jj<=length2(pts);jj++){
      pull2(jj,pts,tmpd);
      surffun(ch,tmpd[0],tmpd[1],tmp2d3);
      if(dist(3,tmp1d3,tmp2d3)<Eps1){
        flg=1; break;
      }
    }
    if(flg==0){
      pull2(ii,tmp3md,tmpd);
      addptd2(pts,tmpd);
    }
  }
  for(ii=1;ii<=length2(pts);ii++){
    tmp3md[0][0]=0;
    appendd2(2,1,length2(out3md),out3md,tmp3md);
    out3md[0][0]=0;
    pull2(ii,pts,tmpd);
    surffun(ch,tmpd[0],tmpd[1],tmp1d3);
    dataindexd2(2,tmp3md,din);
    for(jj=1;jj<=length2i(din);jj++){
      tmp2md[0][0]=0;
      appendd2(2,din[jj][0],din[jj][1],tmp3md,tmp2md);
      pull2(jj,tmp3md,tmpd);
      surffun(ch,tmpd[0],tmpd[1],tmp2d3);
      eps=1;
      for(kk=1;kk<=length2(tmp2md)-1;kk++){
        pull2(kk,tmp2md,tmpd);
        surffun(ch,tmpd[0],tmpd[1],tmp1d3);
        pull2(kk+1,tmp2md,tmpd);
        surffun(ch,tmpd[0],tmpd[1],tmpd3);
        if(eps>dist(3,tmp1d3,tmpd3)){
          eps=dist(3,tmp1d3,tmpd3);
        }
      }
      pull2(1,tmp2md,tmpd);
      surffun(ch,tmpd[0],tmpd[1],tmpd3);
      if(dist(3,tmp1d3,tmpd3)<eps+Eps){
        appendd2(2,ii,ii,pts,out3md);
        for(kk=1;kk<=length2(tmp2md);kk++){
          pull2(kk,tmp2md,tmpd);
          addptd2(out3md,tmpd);
        }
        continue;
      }
      pull2(length2(tmp2md),tmp2md,tmpd);
      surffun(ch,tmpd[0],tmpd[1],tmpd3);
      if(dist(3,tmp1d3,tmpd3)<eps+Eps){
        appendd2(2,1,length2(tmp2md),tmp2md,out3md);
        pull2(ii,pts,tmpd);
        addptd2(out3md,tmpd);
        continue;
      }
    }
    appendd2(2,1,length2(tmp2md),tmp2md,out3md);
  }
  nall=cuspsplitpara(ch,out3md, pdatad3);
  n=length2(Cuspsplitpt);
  Cusppt[0][0]=0;
  nall=appendd2(0, 1,n,Cuspsplitpt,Cusppt);
  nall= borderparadata(ch,pdatad3, outd3);
  push3(Inf,3,0,outd3);
  nall=appendd3(0,1,length3(Borderhiddendata),Borderhiddendata,outd3);
  push3(Inf,3,0,outd3);
  return nall;
}

void makevaltablemeet(short ch,double pa[3], double vec[3], double eps0){
  double u, v, du, dv, pt[3];
  int i, j;
  du=(Urng[1]-Urng[0])/Mdv;
  dv=(Vrng[1]-Vrng[0])/Ndv;
  for(j=0; j<=Ndv; j++){
    v=Vrng[0]+j*dv;
    for(i=0; i<=Mdv; i++){
      u=Urng[0]+i*du;
      surffun(ch,u, v, pt);
      if((fabs(vec[1])>eps0)||(fabs(vec[0])>eps0)){
        Zval[j][i]=(vec[1]*(pt[0]-pa[0])-vec[0]*(pt[1]-pa[1]));
      }
      else{
        Zval[j][i]=pt[0]-pa[0];
      }
    }
  }
  for(i=0; i<=Mdv; i++){
    Xval[i]=Urng[0]+i*du;
  }
  for(j=0; j<=Ndv; j++){
    Yval[j]=Vrng[0]+j*dv;
  }
}

int meetpoints(short ch,double pta[3], double ptb[3], double eps, double ptL[][3]){
  double eps0=pow(10,-4.0), vec[3], out[DsizeM], pL[5][2], vL[5];
  double qL[DsizeM][2], p1d2[2], p2d2[2], tmpd2[2], puv1d2[2], puv2d2[2];
  double m1,m2, p1d3[3], p2d3[3], v1, v2, v3, ptd3[3], ptuvd2[2], tmp1d1;
  double po[3]={0,0,0}, tmpmd1[DsizeM], tmp1d3[3];
  int nout, nptL, ntmp, nqL, i, j, k;
  vec[0]=ptb[0]-pta[0];  vec[1]=ptb[1]-pta[1];  vec[2]=ptb[2]-pta[2]; 
  out[0]=0; nout=0;
  ptL[0][0]=0; nptL=0;
  makevaltablemeet(Ch,pta,vec,eps0);
  for(j=0; j<=Ndv-2; j++){
    for(i=0; i<=Mdv-2; i++){
      pL[0][0]=Xval[i]; pL[0][1]=Yval[j]; vL[0]=Zval[j][i];
      pL[1][0]=Xval[i+1]; pL[1][1]=Yval[j]; vL[1]=Zval[j][i+1];
      pL[2][0]=Xval[i+1]; pL[2][1]=Yval[j+1]; vL[2]=Zval[j+1][i+1];
      pL[3][0]=Xval[i]; pL[3][1]=Yval[j+1]; vL[3]=Zval[j+1][i];
      pL[4][0]=Xval[i]; pL[4][1]=Yval[j]; vL[4]=Zval[j][i];
	  qL[0][0]=0; nqL=0;
      for(k=0; k<=3; k++){
        pull2(k,pL,p1d2);
        pull2(k+1,pL,p2d2);
        m1=vL[k]; m2=vL[k+1];
		if((m1>=eps0)&&(m2>=eps0)){
          continue;
        }
        if((m1<=-eps0)&&(m2<=-eps0)){
          continue;
        }
        if(fabs(m1)<eps0){
          copyd(0,1,p1d2,tmpd2);
        }
        else if(fabs(m2)<eps0){
          continue;
        }
        else{
          tmpd2[0]=1/(m1-m2)*(-m2*p1d2[0]+m1*p2d2[0]);
          tmpd2[1]=1/(m1-m2)*(-m2*p1d2[1]+m1*p2d2[1]);
        }
        nqL=addptd2(qL,tmpd2);
      }
      if(nqL==2){
        pull2(1, qL, puv1d2);
        pull2(2, qL, puv2d2);
        surffun(ch,puv1d2[0], puv1d2[1], p1d3);
        surffun(ch,puv2d2[0], puv2d2[1], p2d3);
        v1=vec[0]; v2=vec[1]; v3=vec[2];
        if(fabs(v1)>eps0){
          m1=pta[2]+v3/v1*(p1d3[0]-pta[0])-p1d3[2];
          m2=pta[2]+v3/v1*(p2d3[0]-pta[0])-p2d3[2];
        }
        else if(fabs(v2)>eps0){
          m1=pta[2]+v3/v2*(p1d3[1]-pta[1])-p1d3[2];
          m2=pta[2]+v3/v2*(p2d3[1]-pta[1])-p2d3[2];
        }
        else{
          m1=pta[1]-p1d3[1];
          m2=pta[1]-p2d3[1];
        }
        if(m1*m2>=-eps0){
          if(((m1>eps0)&&(m2>eps0)) || ((m1<-eps0)&&(m2<-eps0))){
            continue;
          }
          if(fabs(m1)<=eps0){
            copyd(0,2,p1d3,ptd3);
            copyd(0,1,puv1d2,ptuvd2);
          }
          else{
            copyd(0,2,p2d3,ptd3);
            copyd(0,1,puv2d2,ptuvd2);
          }
        }
        else{  
          ptd3[0]=1/(m1-m2)*(-m2*p1d3[0]+m1*p2d3[0]);
          ptd3[1]=1/(m1-m2)*(-m2*p1d3[1]+m1*p2d3[1]);
          ptd3[2]=1/(m1-m2)*(-m2*p1d3[2]+m1*p2d3[2]);
        }
        tmp1d3[0]=ptd3[0]-pta[0]; tmp1d3[1]=ptd3[1]-pta[1];
        tmp1d3[2]=ptd3[2]-pta[2];
        tmp1d1=dotprod(3,tmp1d3,vec);
        tmp1d1=tmp1d1/pow(dist(3,vec,po),2.0);
        if((tmp1d1>-eps0)&&(tmp1d1<1+eps0)){
          nout=appendd1(out,tmp1d1);
        }
      }
    }
  }
  if(nout>>0){
    simplesort(out);
    tmpmd1[1]=out[1]; ntmp=1;
    for(i=2; i<=nout; i++){
      tmp1d3[0]=(out[i]-tmpmd1[ntmp])*vec[0];
      tmp1d3[1]=(out[i]-tmpmd1[ntmp])*vec[1];
      tmp1d3[2]=(out[i]-tmpmd1[ntmp])*vec[2];
      tmp1d1=dist(3,tmp1d3,po);
      if(tmp1d1>eps){
        ntmp=appendd1(tmpmd1,out[i]);
      }
    }
    nout=ntmp;
    copyd(0,ntmp,tmpmd1,out);
    for(i=1; i<=nout; i++){
      tmp1d3[0]=pta[0]+out[i]*vec[0];
      tmp1d3[1]=pta[1]+out[i]*vec[1];
      tmp1d3[2]=pta[2]+out[i]*vec[2];
      nptL=addptd3(ptL,tmp1d3);
    }
  }
  return nptL;
}

int crvsfparadata(double fkL[][3], double fbdkL[][3], int sepflg, double out[][3]){
  double fbdy[DsizeL][2], fk[DsizeM][3],fkp[DsizeM][3], outh[DsizeL][3];
  double fh[DsizeM][2], parL[DsizeM], tmpmd3[DsizeM][3];
  double ptL[DsizeM][3], tmpd2[2], tmpd3[3], tmp1d1, tmp2d1, dt;
  double po[2]={0,0}, epsd2[2]={Eps1,1}, pa[3], pb[3];
  int nbor=length3(Borderhiddendata), nfkL,nfbdkL, nfbdy, nfk, nall;
  int ncshidden, npar, ndin, din[DsizeM][2], ndin2,din2[DsizeS][2];
  int nn, i, j, k, n, nptL, nout;
  nfkL=length3(fkL);
  nfbdy=projpara(fbdkL,fbdy);
  out[0][0]=0;
  outh[0][0]=0;
  ndin=dataindexd3(2,fkL,din);
  for(nn=1; nn<=ndin; nn++){
    fkp[0][0]=0;
    nfk=appendd3(0,din[nn][0],din[nn][1],fkL,fkp);
    n=fmax(1,floor((fmax(Mdv,Ndv)+1)/(nfk-1)+0.5)); //17.06.16
    dt=1.0/n;
	fk[0][0]=0;
    for(i=1; i<nfk; i++){
      for(j=0; j<n; j++){
        tmpd3[0]=fkp[i][0]+(fkp[i+1][0]-fkp[i][0])*j*dt;
        tmpd3[1]=fkp[i][1]+(fkp[i+1][1]-fkp[i][1])*j*dt;
        tmpd3[2]=fkp[i][2]+(fkp[i+1][2]-fkp[i][2])*j*dt;
        addptd3(fk,tmpd3);
      }
    }
    nfk=appendd3(0,nfk,nfk,fkp,fk);
    nall=projpara(fk,fh);
    partitionseg(fh, fbdy,1, parL);
    if(sepflg>=0){
      for(i=1; i<=nfk-1; i++){
        pull3(i,fk,pa);
        pull3(i+1,fk,pb);
        nptL=meetpoints(Ch,pa,pb, Eps2,ptL);
        for(j=1; j<=nptL; j++){
          pull3(j,ptL,tmpd3);
          parapt(tmpd3,tmpd2);
          tmp1d1=paramoncurve(tmpd2,i,fh);
          tmp2d1=Inf;
          for(k=1; k<=npar; k++){
             tmp2d1=fmin(tmp2d1,fabs(parL[k]-tmp1d1));
          }
          tmpd3[0]=pb[0]-pa[0]; tmpd3[1]=pb[1]-pa[1]; 
          tmpd3[2]=pb[2]-pa[2]; 
          if(tmp2d1*dist(3,tmpd3,po)>Eps1){
            npar=appendd1(parL,tmp1d1);
          }
        }
        simplesort(parL);
      }
    }
    nohiddenpara2(parL,fk,1, tmpmd3);
    appendd3(2,1,length3(tmpmd3),tmpmd3,out);
    appendd3(2,1, length3(Hiddendata),Hiddendata,outh);
  }
  push3(Inf,3,0,out); //17.06.17
  nout=appendd3(0,1,length3(outh),outh,out);
  push3(Inf,3,0,out); //17.06.17
  return nout;
}

int wireparadata(double bdyk[][3], double udv[], double vdv[],  int num, 
             double fsL[][3]){
  double fbdy[DsizeL][2], udiv[DsizeM], vdiv[DsizeM], fbdxy[DsizeM][2];
  double fs[DsizeL][3], u, v, d, pdata[DsizeM][3], fkL[DsizeM][3];
  double fsLh[DsizeLL][3];
  double tmpmd2[DsizeM][2], fk[DsizeM][3], par[DsizeM], p[2];
  int nfbdy, nd, i, j, k, n, nu, nv, nfbdxy, nfsL, npdata, nfkL, nfk, npar,ntmp;
  int nwire, ndin, din[DsizeM][2], nfs, ndin2, din2[DsizeM][2];
  nfbdy=projpara(bdyk, fbdy);
  Wirept[0][0]=0;
  udiv[0]=0; nu=0;
  vdiv[0]=0; nv=0;
  n=floor(udv[0]+0.5);
  if(n==-1){
    nd=floor(udv[1]+0.5);
    d=(Urng[1]-Urng[0])/(nd+1);
    for(i=1; i<=nd; i++){
      u=Urng[0]+i*d;
      nu=appendd1(udiv,u);
    }
  }
  else{
    for(i=1; i<=n; i++){
      nu=appendd1(udiv,udv[i]);
    }
  }
  n=floor(vdv[0]+0.5);
  if(n==-1){
    nd=floor(vdv[1]+0.5);
    d=(Vrng[1]-Vrng[0])/(nd+1);
    for(i=1; i<=nd; i++){
      v=Vrng[0]+i*d;
      nv=appendd1(vdiv,v);
    }
  }
  else{
    for(i=1; i<=n; i++){
      nv=appendd1(vdiv,vdv[i]);
    }
  }
  nfbdxy=makexybdy(Ch,fbdxy);
  Wirept[0][0]=0;
  fsL[0][0]=0; nfsL=0;
  fsLh[0][0]=0;
  for(i=1; i<=nu; i++){
    u=udiv[i];
    d=(Vrng[1]-Vrng[0])/(num*Ndv);
    tmpmd2[0][0]=0; ntmp=0;
    for(j=1;j<=(num*Ndv)+1; j++){
      v=Vrng[0]+(j-1)*d;
      p[0]=u; p[1]=v;
      ntmp=addptd2(tmpmd2,p);
    }
    nfkL=cuspsplitpara(Ch,tmpmd2, fkL); 
    ndin=dataindexd3(2,fkL,din);
    for(j=1; j<=ndin; j++){
      fk[0][0]=0;
      nfk=appendd3(0, din[j][0], din[j][1], fkL,fk);
      ntmp=projpara(fk,tmpmd2);
	  partitionseg(tmpmd2, fbdy, 1, par);
	  ntmp=length2(Partitionpt);
      if(ntmp>2){
        for(k=2; k<=ntmp; k++){
           pull2(k, Partitionpt, p);
           nwire=addptd3(Wirept,p);
        }
      }
      nfs=nohiddenpara2(par,fk,1, fs);
      n=length3(Hiddendata);
      ntmp=appendd3(2,1,n, Hiddendata,fsLh);
      nfsL=appendd3(2,1,nfs,fs,fsL);
    }
  }
  for(i=1; i<= nv; i++){
    v=vdiv[i];
    d=(Urng[1]-Urng[0])/(num*Mdv);
    tmpmd2[0][0]=0; ntmp=0;
    for(j=1;j<=(num*Mdv)+1; j++){
      u=Urng[0]+(j-1)*d;
      p[0]=u; p[1]=v;
      ntmp=addptd2(tmpmd2,p);
    }
    nfkL=cuspsplitpara(Ch,tmpmd2, fkL); 
    ndin=dataindexd3(2,fkL,din);
    for(j=1; j<=ndin; j++){
      fk[0][0]=0;
      nfk=appendd3(0, din[j][0], din[j][1], fkL,fk);
      ntmp=projpara(fk,tmpmd2);
      partitionseg(tmpmd2, fbdy, 1, par);
	  ntmp=length2(Partitionpt);
      if(ntmp>2){
        for(k=2; k<=ntmp; k++){
           pull2(k, Partitionpt, p);
           nwire=addptd3(Wirept,p);
        }
      }
      nohiddenpara2(par,fk,1, fs);
      appendd3(2,1,length3(Hiddendata), Hiddendata,fsLh);
      appendd3(2,1,length3(fs),fs,fsL);
    }
  }
  push3(Inf,3,0,fsL);
  nfsL=appendd3(0,1,length3(fsLh),fsLh,fsL);
  push3(Inf,3,0,fsL);
  return nfsL;
}

/*
double cutfun(int ch, double u, double v){
  double p[3],val ;
  surffun(ch,u,v,p);
  val=p[0]+p[1]-0.5;
  return val;
}
*/

void makevaltablecut(int chcut){
  double eps0=pow(10,-6.0), u, v, du, dv;
  int i, j, nx=0, ny=0; ;
  du=(Urng[1]-Urng[0])/Mdv;
  dv=(Vrng[1]-Vrng[0])/Ndv;
  for(j=0; j<=Ndv; j++){
    v=Vrng[0]+j*dv;
    for(i=0; i<=Mdv; i++){
      u=Urng[0]+i*du;
      Zval[j][i]=cutfun(Ch,chcut, u,v);
    }
  }
  for(i=0; i<=Mdv; i++){
    Xval[i]=Urng[0]+i*du;
  }
  for(j=0; j<=Ndv; j++){
    Yval[j]=Vrng[0]+j*dv;
  }
}

int sfcutdata(int ch, double ekL[][3]){
  double cutuvL[DsizeL][2], out1[DsizeM][2], out2[DsizeM][3], pt[3];
  int i, j, nall, ndin, din[DsizeM][2], nekL,nout1,nout2;
//  makevaltablecut(ch); //180320
//  nall=implicitplot(cutuvL); //180320
  ekL[0][0]=0; nekL=0;
  ndin=dataindexd2(2,cutuvL,din);
  for(i=1; i<=ndin; i++){
    out1[0][0]=0;
    nout1=appendd2(2,din[i][0],din[i][1],cutuvL,out1);
    out2[0][0]=0;
    for(j=1; j<=nout1; j++){
      surffun(ch,out1[j][0], out1[j][1], pt);
      nout2=addptd3(out2,pt);
    }
    nekL=appendd3(2,1,nout2,out2,ekL);
  }
  return nekL;
}

int crv3onsfparadata(double fk[][3], double fbdyd3[][3], double out[][3]){
  double fbdy[DsizeL][2], fh[DsizeL][2], tmpmd2[DsizeL][2], par[DsizeM];
  int n, nall, nfbdy, nfbdxy, npar, nout;
  out[0][0]=0;
  nfbdy=projpara(fbdyd3,fbdy);
//  nall=ospline3(2,fk,2,fk1);
  projpara(fk,fh);
  partitionseg(fh,fbdy, 1, par);
  nohiddenpara2(par,fk, 1,out);
  push3(Inf,3,0,out);
  nall=appendd3(0,1,length3(Hiddendata),Hiddendata,out);
  push3(Inf,3,0,out); //17.06.16
  return nall;
}

int projcoordcurve(double curve[][3], double out[][3]){
  double   SP=sin(PHI), CP=cos(PHI), ST=sin(THETA), CT=cos(THETA);
  double pt[3], xz, yz, zz;
  int i, n, nall;
  out[0][0]=0;
  n=length3(curve);
  for(i=1; i<=n; i++){
    pull3(i, curve, pt);
    if(pt[0]>Inf-1){
      xz=pt[0]; yz=pt[1]; zz=pt[2];
    }
    else{
      xz=-pt[0]*SP+pt[1]*CP;
      yz=-pt[0]*CP*CT-pt[1]*SP*CT+pt[2]*ST;
      zz=pt[0]*CP*ST+pt[1]*SP*ST+pt[2]*CT;
    }
    nall=push3(xz,yz,zz,out);
  }
  return nall;
}

int kukannozoku(double jokyo[2], double kukanL[][2], double res[][2]){
  double t1, t2, tmpd2[2], ku[2];
  int i, j, ii, nn, flg, nres;
  nn=length2(kukanL);
  t1=jokyo[0]; 
  t2=jokyo[1];
  pull2(1,kukanL,tmpd2);
  t1=fmax(t1,tmpd2[0]);
  pull2(nn,kukanL,tmpd2);
  t2=fmin(t2,tmpd2[1]);
  res[0][0]=0; nres=0;
  flg=0;
  for(ii=1; ii<=nn; ii++){
    pull2(ii,kukanL,ku);
    if(flg==0){
      if(ku[1]<t1){
        nres=addptd2(res,ku);
      }
      else{
        flg=1;
        if(ku[0]<t1-Eps){ 
          tmpd2[0]=ku[0]; tmpd2[1]=t1;
          nres=addptd2(res,tmpd2);
        }
        if(ku[1]>t2+Eps){
          tmpd2[0]=t2; tmpd2[1]=ku[1];
          nres=addptd2(res,tmpd2);
        }
      }
    }
    else if(flg==1){
      if(ku[1]<t2){
        continue;
      }
      else{
        flg=2;
        if(ku[0]<t2-Eps){
          ku[0]=t2;
        }
        nres=addptd2(res,ku);                        
      }
    }
    else{
      nres=addptd2(res,ku);
    }
  }  
  return nres;
}

int skeletondata3(double data[][3], double r00, 
         double eps1, double eps2, double allres[][3]){
  double objL[DsizeLL][3], pltL[DsizeLL][3];
  double clipL[DsizeL][5],koc2d6[DsizeM][6],tmpd6[6];
  double pts1[DsizeL][2],koc[DsizeM][4], koc2[DsizeM][4], kukanL[DsizeL][2];
  double r0, t1, t2, z1, z2, tt, rr, origin[2], te, hh, ku[2], za, zb, ds[DsizeM],dmin;
  double pt[2], pta[2], ptb[2], ptq[2];
  double ptL[DsizeL][3], ptL2[DsizeL][2], res2[DsizeL][2], allres2[DsizeL][2];
  double obj[DsizeL][3], plt[DsizeL][3];
  double objp[DsizeL][3], pltp[DsizeL][3];
  double obj2d[DsizeL][2],  plt2d[DsizeL][2];
  double tmpd1, tmp2d1, tmp3d1, tmp1d2[2], tmp2d2[2],tmpd3[3]; 
  double tmpmd2[DsizeL][2], tmpmd3[DsizeL][3], tmpd4[4], tmp1d4[4];
  int j, ii, jj, nobj, nplt, nall, din1[DsizeM][2], din2[DsizeM][2];
  int nkoc, nkoc2, nn,nn1,nn2, nclipL, flg, ntmp;
  char str1[100], str2[100];
  objL[0][0]=0; pltL[0][0]=0;
  dataindexd3(3,data,din1);
  appendd3(0, din1[1][0],din1[1][1],data,objL);
  appendd3(0, din1[2][0],din1[2][1],data,pltL);
  allres[0][0]=0;
  allres2[0][0]=0;
  dataindexd3(2,objL,din1);
  dataindexd3(2,pltL,din2);
  for(nobj=1; nobj<=length2i(din1); nobj++){
    tmpmd3[0][0]=0;
    ntmp=appendd3(2,din1[nobj][0],din1[nobj][1],objL,tmpmd3);
    nn=ceil((fmax(Mdv,Ndv)*2-1)/(ntmp-1));
    increasept3(tmpmd3,nn,obj);
    appendd3(0,ntmp,ntmp,tmpmd3,obj);
    projcoordcurve(obj,objp);
	obj2d[0][0]=0;
    for(j=1; j<=length3(objp); j++){
      push2(objp[j][0],objp[j][1],obj2d);
    }
	clipL[0][0]=0; nclipL=0;
    for(nplt=1; nplt<=length2i(din2); nplt++){
      tmpmd3[0][0]=0;
      ntmp=appendd3(2,din2[nplt][0],din2[nplt][1],pltL,tmpmd3);
      nn=ceil((fmax(Mdv,Ndv)*2-1)/(ntmp-1));
      increasept3(tmpmd3,nn,plt);
      appendd3(0,ntmp,ntmp,tmpmd3,plt);
      projcoordcurve(plt,pltp);
      plt2d[0][0]=0;
      for(j=1; j<=length3(pltp); j++){
        push2(pltp[j][0],pltp[j][1],plt2d);
      }
      intersectcurvesPp(obj2d,plt2d,20,koc2d6); //180324from
      nkoc2=length6(koc2d6);
      koc2[0][0]=0;
      for(ii=1;ii<=nkoc2;ii++){
        pull6(ii,koc2d6,tmpd6);
        push4(tmpd6[0],tmpd6[1],tmpd6[2],tmpd6[3],koc2);
      }//180324to
      if(nkoc2>0){
        koc[0][0]=0; nkoc=0;
        pull2(1,plt2d,pta);
        pull2(length2(plt2d),plt2d,ptb);
		for(j=1; j<=nkoc2; j++){
          pt[0]=koc2[j][0]; pt[1]=koc2[j][1];
          nearestptpt(pt, plt2d, tmpd4);
          koc2[j][3]=tmpd4[2];
          pt[0]=tmpd4[0]; pt[1]=tmpd4[1];
          nearestptpt(pt, obj2d, tmpd4);
          koc2[j][0]=tmpd4[0]; koc2[j][1]=tmpd4[1]; 
          koc2[j][2]=tmpd4[2];
          ds[j]=tmpd4[3];
        }
        pull4(1,koc2,tmp1d4);
        dmin=ds[1];
	    for(j=2; j<=nkoc2; j++){
          if(fabs(koc2[j][2]-tmp1d4[2])<4){
            if(ds[j]<dmin){
			  pull4(j,koc2,tmp1d4);              
              dmin=ds[j];
            }
          }
          else{
            addptd4(koc,tmp1d4);
            pull4(j,koc2,tmp1d4); 
            dmin=ds[j];              
		  }
        }
        nkoc=addptd4(koc,tmp1d4);
/*
          if(tmpd4[3]<2*eps1){
             if((dist(2,pta,pt)<eps2)&&(tmpd4[2]<0.1*length2(plt2d))){
               continue;
             }
             if((dist(2,ptb,pt)<eps2)&&(tmpd4[2]>0.9*length2(plt2d))){
               continue;
             }
             pull4(j,koc2,tmpd4);
             nkoc=addptd4(koc,tmpd4);
		  }
		}
*/
		for(jj=1; jj<=nkoc; jj++){
          pt[0]=koc[jj][0]; pt[1]=koc[jj][1];
          pta[0]=plt2d[1][0]; pta[1]=plt2d[1][1];
          ptb[0]=plt2d[length2(plt2d)][0]; ptb[1]=plt2d[length2(plt2d)][1];
          if((dist(2,pt,pta)<eps2)&&(koc[jj][3]<0.3*length2(plt2d))){
            continue;
          }
          if((dist(2,pt,ptb)<eps2)&&(koc[jj][3]>0.7*length2(plt2d))){
            continue;
          }
          nn1=floor(koc[jj][2]);
          nn2=koc[jj][3];
          pta[0]=objp[nn1][0]; pta[1]=objp[nn1][1];
          za=objp[nn1][2];
          ptb[0]=objp[nn1+1][0]; ptb[1]=objp[nn1+1][1];
          zb=objp[nn1+1][2];
          if(dist(2,pta,ptb)<eps1){
            continue;
          }
          t1=dist(2,pta,pt)/dist(2,pta,ptb);
          z1=(1-t1)*za+t1*zb;
          pta[0]=pltp[nn2][0]; pta[1]=pltp[nn2][1];
          za=tmpmd3[nn2][2];
          ptb[0]=pltp[nn2+1][0]; ptb[1]=pltp[nn2+1][1]; 
          zb=tmpmd3[nn2+1][2]; 
          if(dist(2,pta,ptb)<Eps){
            continue;
          }
          t2=dist(2,pta,pt)/dist(2,pta,ptb);
          z2=(1-t2)*za+t2*zb;
          if(z1<z2-eps1){
            if(nclipL==0){ 
              tmpd1=1;
            }
          }
          else{
            tmpd1=Inf;
            for(j=1; j<=nclipL; j++){                                
              tmp2d1=pow(clipL[j][0]-pt[0],2.0);
              tmp2d1=tmp2d1+pow(clipL[j][1]-pt[1],2.0);
              tmpd1=fmin(tmpd1,tmp2d1);
            }
          }
          if(tmpd1>pow(Eps,2.0)){
            pts1[0][0]=0;
            pointoncurve(nn1,obj2d,Eps,tmp1d2);
            addptd2(pts1,tmp1d2);
            pointoncurve(nn1+1,obj2d,Eps,tmp1d2);
            addptd2(pts1,tmp1d2);
            tmp1d2[0]=pts1[2][0]-pts1[1][0];
            tmp1d2[1]=pts1[2][1]-pts1[1][1];
            tmp2d2[0]=ptb[0]-pta[0];
            tmp2d2[1]=ptb[1]-pta[1];
            tmp3d1=dotprod(2,tmp1d2,tmp2d2);
            origin[0]=0; origin[1]=0;
            tmp3d1=tmp3d1/dist(2,tmp1d2,origin)/dist(2,tmp2d2,origin);
            tmpd1=1-0.5*pow(tmp3d1,2.0);
            r0=0.075*r00;
            nclipL=push5(pt[0],pt[1], nn1,t1,r0/tmpd1, clipL); 
          }         
        }
      }
    }
    kukanL[0][0]=0;
    te=length3(obj);
    push2(1.0,te, kukanL);
    for(ii=1; ii<=nclipL; ii++){
      pt[0]=clipL[ii][0]; pt[1]=clipL[ii][1]; 
      nn=clipL[ii][2];
      tt=nn+clipL[ii][3];
      rr=clipL[ii][4];
      flg=0;
      for(jj=nn; jj>=1; jj--){
        pointoncurve(jj,obj2d,Eps,ptq);
        if(dist(2,pt,ptq)<rr){
          continue;
        }
        flg=jj;
        break;
      }
      if(flg==0){
        t1=1;
      }
      else{
        t1=flg; t2=tt;
        hh=t2-t1;
        for(j=1; j<=10; j++){
          hh=hh*0.5;
          pointoncurve(t1+hh,obj2d,Eps,ptq);
          if(dist(2,pt,ptq)<rr){
            t2=t2-hh;
          }
          else{
            t1=t1+hh;
          }
        }
      }
      ku[0]=t1;
      flg=0;
      for(jj=nn+1; jj<=te; jj++){
        pointoncurve(jj,obj2d,Eps,ptq);
        if(dist(2,pt,ptq)<rr){
          continue;
        }
        flg=jj;
        break;
      }
      if(flg==0){
        t2=te;
      }
      else{          
        t1=tt; t2=flg;
        hh=t2-t1;
        for(j=1; j<=10; j++){
          hh=hh*0.5;
          pointoncurve(t1+hh,obj2d,Eps,ptq);
          if(dist(2,pt,ptq)<rr){
            t1=t1+hh;
          }
          else{              
            t2=t2-hh;
          }
        }
      }        
      ku[1]=t2;
      ntmp=kukannozoku(ku,kukanL,tmpmd2);
      kukanL[0][0]=0;
      appendd2(0,1,ntmp,tmpmd2,kukanL);
    }
    for(jj=1; jj<=length2(kukanL); jj++){
      tmp1d2[0]=kukanL[jj][0]; tmp1d2[1]=kukanL[jj][1]; 
      t1=kukanL[jj][0]; nn1=floor(t1);
      t2=kukanL[jj][1]; nn2=floor(t2); 
      ptL2[0][0]=0;
      ptL[0][0]=0;
      if(t1-nn1<1-Eps){
        pointoncurve(t1,obj2d,Eps,tmp1d2);
        addptd2(ptL2,tmp1d2);
        invparapt(t1, obj2d, obj, tmpd3);
        addptd3(ptL,tmpd3);
      }          
      for(j=nn1+1; j<=nn2; j++){
        pointoncurve(j,obj2d,Eps,tmp1d2);
        addptd2(ptL2,tmp1d2);
        invparapt(j, obj2d, obj, tmpd3);
        addptd3(ptL,tmpd3);
      }
      if(t2-nn2>Eps){
        pointoncurve(t2,obj2d,Eps,tmp1d2);
        addptd2(ptL2,tmp1d2);
        invparapt(t2, obj2d, obj, tmpd3);
        addptd3(ptL,tmpd3);
      }
      if(length2(ptL2)>1){
        appendd2(2,1,length2(ptL2),ptL2,allres2);
        appendd3(2,1,length3(ptL),ptL,allres);
      }
    }
  }
  return length3(allres);
}

/*
void writesfbd(const char *var, const char *fname, const char *fnameh,double sf[][3]){
  sfbdparadata(sf);
  output3(var, "", fname,2,sf);
  output3(var, "h", fnameh,2,Borderhiddendata);
}

void writecrv(const char *var, const char *fname, const char *fnameh, 
                double crv[][3],double sf[][3]){
  crvsfparadata(crv, sf, 1,Crvdata);
  output3(var, "", fname,2,Crvdata);
  output3(var, "h", fnameh,2,Crvsfhiddendata);
}

void writewire(const char *var, const char *fname, const char *fnameh,
              double sf[][3], int num, double udv[], double vdv[]){
  wireparadata(sf, num, udv,vdv, Wiredata);
  output3(var, "", fname,2,Wiredata);
  output3(var, "h", fnameh,2,Hiddenwiredata);
}

void writesfcut(const char *var, const char *fname, const char *fnameh,
              double crv[][3], double sf[][3]){
  sfcutdata(crv);
  crv3onsfparadata(crv, sf, Crvonsfdata);
  output3(var, "", fname,2,Crvonsfdata);
  output3(var, "h", fnameh,2,Crv3onsfhiddendata);
}

void writecrvonsf(const char *var, const char *fname, const char *fnameh, 
                double crv[][3],double sf[][3]){
  crv3onsfparadata(crv, sf, Crvonsfdata);
  output3(var, "", fname,2,Crvonsfdata);
  output3(var, "h", fnameh,2,Crv3onsfhiddendata);
}
*/


