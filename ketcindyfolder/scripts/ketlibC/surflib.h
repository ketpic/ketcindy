// 180430 
//    crv2sfparadata,wireparadata added
//    output3h,output3 chanded       
// 180426 readdataC,writedataC changed
// 180420 newly rewrited
// 170616 crvsfparadata changed ( num of devision )

int output3(short head, const char *wa,const char *var, const char *fname,double out[][3]){
  int din[DsizeS][2],i,j,ctr;
  double tmpd[3];
  FILE *fp;
  fp=fopen(fname,wa);
  if (fp == NULL) { 
    printf("cannot open\n");  
    return -1;
  }
  dataindexd3(2, out,din);
  if(head==1){
    fprintf(fp,"%s//\n",var);
  }
  for(i=1; i<=length2i(din); i++){
    fprintf(fp,"start//\n");
    fprintf(fp,"[");
    ctr=0;
    for(j=din[i][0]; j<=din[i][1]; j++){
      pull3(j,out,tmpd);
      fprintf(fp,"[ %7.5f, %7.5f, %7.5f]",tmpd[0],tmpd[1],tmpd[2]);
      ctr++;
      if(ctr==5){
        fprintf(fp,"]//\n");
        ctr=0;
        if(j<din[i][1]){
          fprintf(fp,"[");
        }
      }else{
        if(j<din[i][1]){
          fprintf(fp,",");
        }else{
          fprintf(fp,"]//\n");
        }
      }
    }
    fprintf(fp,"end//\n");
  }
  fclose(fp);
  return 0;
}

int output3h(const char *wa,const char *var, const char *varh, const char *fname, double out[][3]){
  // 17.06.09
  double out1[DsizeLL][3], tmpd[3];
  int din1[DsizeM][2],din2[DsizeM][2], i, j,ctr;
  FILE *fp;
  fp=fopen(fname,wa);
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
  if(din1[0][0]>1){ //180613from
    appendd3(0, din1[2][0],din1[2][1],out,out1);
  }//180613to
  dataindexd3(2, out1,din2);
  for(i=1; i<=length2i(din2); i++){
    fprintf(fp,"start//\n");
    fprintf(fp,"[");
    ctr=0; //181105
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
//  fprintf(fp,"//\n"); //180531
  fclose(fp);
  return 0;
}

void outputend(const char *fname){
  FILE *fp;
  fp=fopen(fname,"a");
  fprintf(fp,"//\n");
  fclose(fp);
}

int writedataC(const char *fname, double out[][3]){
  int i, nall;
  FILE *fp;
  nall=length3(out);
  fp=fopen(fname,"w");
  for(i=1; i<=nall; i++){
    fprintf(fp,"%7.5f %7.5f %7.5f %6s",out[i][0],out[i][1],out[i][2],"-99999");
    if(i<nall){
      fprintf(fp,"\n");
    };
  }
  fclose(fp);
  return nall;
}

int readdataC(const char *fname, double data[][3]){
  int i, j, ndata=0;
  double tmpd4[4];
  FILE *fp;
  fp=fopen(fname,"r");
  if(fp==NULL){
    printf("file not found\n");
    return 1;
  }
  data[0][0]=0;
  while( ! feof(fp) && ndata<DsizeL){
    for(j=0;j<=3;j++){
      fscanf(fp,"%lf",&tmpd4[j]);
    }
    push3(tmpd4[0],tmpd4[1],tmpd4[2],data);
  }
  fclose(fp);
  return length3(data);
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

double zparapt(double p[3]){
  double x=p[0], y=p[1], z=p[2], out;
  out=x*cos(PHI)*sin(THETA)+y*sin(PHI)*sin(THETA)+z*cos(THETA);
  return out;
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

void surfcurve(short ch,double crv[][2], double pdata[][3]){
  double pd2[2], pt[3];
  int i;
  pdata[0][0]=0;
  for(i=1; i<=length2(crv); i++){
    pull2(i,crv,pd2);
    surffun(ch,pd2[0],pd2[1],pt);
    addptd3(pdata,pt);
  }
}

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
  double dv=(Vrng[1]-Vrng[0])/Ndv; //180427
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
            ncusp=appendi1(ntmp,cusp);
          }
          else{
            ncusp=appendi1(ntmp,cusp);
          }
        }
      }
    }
    if(cflg==0){
      ncusp=prependi1(1,cusp);
      ncusp=appendi1(nph,cusp);
    }
    else if(ncusp==0){
       ncusp=prependi1(1,cusp);
       ncusp=appendi1(nph,cusp);
    }
    else if(cusp[1]==1){
      ncusp=appendi1(nph,cusp);
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
      ncusp=appendi1(nph,cusp);
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
      ntmpnum=appendi1(drop[j],tmpnum);
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
  int ii,jj,kk,n,din[DsizeM][2];
  double eps0=pow(10,-5.0),tmpd4[4], tmpd6[6],tmp,tmp2;
  double p[2], q[2], pd3[3], ans[4], tmp1d1[DsizeM], tmp2d1[DsizeM];
  double other[DsizeM], g[DsizeM][2], kouL[DsizeS][4],kouL6[DsizeS][6];
  if(ns>0){
    dataindexd1(Otherpartition,din);
    other[0]=0;
    for(ii=din[ns][0]; ii<=din[ns][1]; ii++){
      appendd1(Otherpartition[ii],other);
    }
  }else{
    other[0]=0;
  }
  parL[0]=0;
  appendd1(1,parL);
  appendd1(length2(fig),parL);
  if(length1(other)>0){
    for(ii=1; ii<=length1(other); ii++){
      appendd1(other[ii],parL);
    }
  }
  dataindexd2(2,gL,din);
  for(n=fmax(ns,1); n<=din[0][0]; n++){
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
        appendd1(tmp,tmp1d1);
      }
      tmp=tmpd4[3];
      if((tmp>1+Eps)&&(tmp<length2(g)-Eps)){
        appendd1(tmp,tmp2d1);
      }
    }
    for(jj=1;jj<=length1(tmp1d1);jj++){
      appendd1(tmp1d1[jj],parL);
    }
    if((ns>0)&&(n>ns)&&(length1(tmp2d1)>0)){
      dataindexd1(Otherpartition,din);
      tmp1d1[0]=0;
      for(jj=din[n][0];jj<=din[n][1];jj++){
        appendd1(Otherpartition[jj],tmp1d1);
      }
      replacelistd1(n,Otherpartition,tmp2d1);
    }
  }
  simplesort(parL);
  tmp1d1[0]=0;
  for(ii=1;ii<=length1(parL);ii++){
    appendd1(parL[ii],tmp1d1);
  }
  parL[0]=0;
  tmp2=-1;
  for(jj=1;jj<=length1(tmp1d1);jj++){
    tmp=tmp1d1[jj];
    if(fabs(tmp-tmp2)>Eps1){
      appendd1(tmp,parL);
      tmp2=tmp;
    }
  }
}

double funpthiddenQ(short ch,double u, double v,double pa[3]){
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

int pthiddenQ(short ch,double pta[3], int uveq,double out[4]){
  int i, j, k;
  double Vec[3]={sin(THETA)*cos(PHI),sin(THETA)*sin(PHI),cos(THETA)};
  double v1,v2,v3;
  double du=(Urng[1]-Urng[0])/Mdv, dv=(Vrng[1]-Vrng[0])/Ndv;
  double uval1,uval2,vval1,vval2,eval11,eval12,eval21,eval22;
  double pl[5][2], vl[5], ql[11][2],p1[2],p2[2],m1,m2;
  double ptuv[2], puv1[2], puv2[2],p1d3[3], p2d3[3], ptd3[3];
  double tmpd1, tmpd2[2],tmpd3[3],tmp1d3[3];
//     Out=1 : hidden
//     SL : List of segments near PtA+Vec
  out[3]=-Inf;
  for(j=0; j<=Ndv-1; j++){
    vval1=Vrng[0]+j*dv;
    vval2=Vrng[0]+(j+1)*dv;
    uval1=Urng[0];
    eval11=funpthiddenQ(ch,uval1,vval1,pta);
    eval12=funpthiddenQ(ch,uval1,vval2,pta);
    for(i=0; i<=Mdv-1; i++){
      uval2=Urng[0]+(i+1)*du;
      eval21=funpthiddenQ(ch,uval2,vval1,pta);
      eval22=funpthiddenQ(ch,uval2,vval2,pta);
	  pl[0][0]=uval1; pl[0][1]=vval1; vl[0]=eval11;
      pl[1][0]=uval2; pl[1][1]=vval1; vl[1]=eval21;
      pl[2][0]=uval2; pl[2][1]=vval2; vl[2]=eval22;
      pl[3][0]=uval1; pl[3][1]=vval2; vl[3]=eval12;
	  pl[4][0]=uval1; pl[4][1]=vval1; vl[4]=eval11;
      ql[0][0]=0;
      for(k=0; k<=3; k++){
        pull2(k,pl,p1);
        pull2(k+1,pl,p2);
        m1=vl[k]; m2=vl[k+1];
        if(fabs(m1)<Eps){
          addptd2(ql, p1);
          continue;
        }
        if(fabs(m2)<Eps){
          continue;
        }
        if((m1>0)&&(m2>0)){
          continue;
        }
        if((m1< 0)&&(m2< 0)){
          continue;
        }
        tmpd2[0]=1/(m1-m2)*(-m2*p1[0]+m1*p2[0]);
        tmpd2[1]=1/(m1-m2)*(-m2*p1[1]+m1*p2[1]);
        addptd2(ql, tmpd2);
      }
      uval1=uval2;
      eval11=eval21;
      eval12=eval22;
      if(length2(ql)==2){
        puv1[0]=ql[1][0]; puv1[1]=ql[1][1]; 
        puv2[0]=ql[2][0]; puv2[1]=ql[2][1];  
        surffun(ch,puv1[0],puv1[1],p1d3);
        surffun(ch,puv2[0],puv2[1],p2d3);
        v1=Vec[0]; v2=Vec[1]; v3=Vec[2];
        if(fabs(v1)>Eps){
          m1=pta[2]+v3/v1*(p1d3[0]-pta[0])-p1d3[2];
          m2=pta[2]+v3/v1*(p2d3[0]-pta[0])-p2d3[2];
        }else if(fabs(v2)>Eps){
          m1=pta[2]+v3/v2*(p1d3[1]-pta[1])-p1d3[2];
          m2=pta[2]+v3/v2*(p2d3[1]-pta[1])-p2d3[2];
        }else{
          m1=pta[1]-p1d3[1];
          m2=pta[1]-p2d3[2];
        }
        if(m1*m2>= 0){
          if(((m1>0) && (m2>0)) || ((m1< 0) && (m2< 0))){
            continue;
          }
          if(m1==0){
            ptd3[0]=p1d3[0]; ptd3[1]=p1d3[1]; ptd3[2]=p1d3[2];
            ptuv[0]=puv1[0]; ptuv[1]=puv1[1];
          }else{
            ptd3[0]=p2d3[0]; ptd3[1]=p2d3[1]; ptd3[2]=p2d3[2];
            ptuv[0]=puv2[0]; ptuv[1]=puv2[1];
          }
        }else{  
          ptd3[0]=1/(m1-m2)*(-m2*p1d3[0]+m1*p2d3[0]);
          ptd3[1]=1/(m1-m2)*(-m2*p1d3[1]+m1*p2d3[1]);
          ptd3[2]=1/(m1-m2)*(-m2*p1d3[2]+m1*p2d3[2]);
          ptuv[0]=1/(m1-m2)*(-m2*puv1[0]+m1*puv2[0]);
          ptuv[1]=1/(m1-m2)*(-m2*puv1[1]+m1*puv2[1]);
        }
        tmpd3[0]=ptd3[0]-pta[0];
        tmpd3[1]=ptd3[1]-pta[1];
        tmpd3[2]=ptd3[2]-pta[2]; 
        crossprod(3,tmpd3,Vec, tmp1d3);
        if(norm(3,tmp1d3)<Eps1){
		  tmpd1=zparapt(ptd3)-zparapt(pta)-Eps2;
          if(tmpd1>0){
	        copyd(0,2,ptd3,out); out[3]=tmpd1;
            return 1;
          }else{
            if(tmpd1>out[3]){
	          copyd(0,2,ptd3,out); out[3]=tmpd1;
            }
          }
        }
      }
    }
  }
  return 0;
}

int nohiddenpara2(short ch,double par[], double fk[][3], int uveq, double figkL[][3]){
  double eps0=pow(10,-4.0), s, p1[2], p2[2], q[2],tmpd1, tmpd2[2],tmp1,tmp2;
  double paL[DsizeM], fh[DsizeM][2], pta[3], ptap[2], vec[3];
  double figL[DsizeM][2], tmpmd2[DsizeM][2], tmpmd3[DsizeM][3];
  double tmp1d2[2], tmp2d2[2], tmp3d2[2], tmpd3[3],tmpd4[4];
  double pd2[2], qd2[2], pd3[3], qd3[3], sp, sq, tp, tq, dtmp, dtmp1, dtmp2;
  int flg;
  int ncusp=floor(Cusppt[0][0]+0.5), seL[DsizeM];
  int i,j,n, nfh, nfk, cspflg,tmpi1[DsizeM];
  vec[0]=sin(THETA)*cos(PHI);
  vec[1]=sin(THETA)*sin(PHI);
  vec[2]=cos(THETA);
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
  paL[0]=0;
  tmp2=-1;
  for(j=1;j<=length1(par)-1;j++){
    tmp1=par[j];
    if(fabs(tmp1-tmp2)>Eps){
      add1(paL,tmp1);
      tmp2=tmp1;
    }
  }
  tmp1=paL[length1(paL)];
  tmp2=par[length1(par)];
  if(fabs(tmp1-tmp2)<Eps){
    paL[length1(paL)]=tmp2;
  }else{
    add1(paL,tmp2);
  }
  seL[0]=0;
  for(n=1; n<=length1(paL)-1; n++){
	s=(paL[n]+paL[n+1])/2.0;
    invparapt(s,fh,fk, pta);
    parapt(pta,ptap);
    flg=pthiddenQ(ch,pta, uveq, tmpd4);
    if(flg==0){ //180518
      appendi1(n,seL);
    }
  }
  figL[0][0]=0;figkL[0][0]=0;
  for(i=1; i<=seL[0]; i++){
    sp=paL[seL[i]]; //180616from
    sq=paL[seL[i]+1];
    pointoncurve(sp, fh, Eps, pd2);
    pointoncurve(sq, fh, Eps, qd2);
    if(dist(2,pd2,qd2)>Eps1){
      nearestptpt(pd2,fh,tmpd4);
      dtmp1=tmpd4[2];
      nearestptpt(qd2,fh,tmpd4);
      dtmp2=tmpd4[2];
      partcrv(dtmp1,dtmp2,fh,tmpmd2);
      appendd2(2,1,length2(tmpmd2),tmpmd2,figL);
      tp=invparapt(sp,fh,fk,tmpd3);
      tq=invparapt(sq,fh,fk,tmpd3);
      partcrv3(tp,tq,fk,tmpmd3);
      appendd3(2,1,length3(tmpmd3), tmpmd3, figkL);
    }//180616to
    else{//180705from
      if(fabs(sp-sq)>1){
        appendd2(2,1,length2(fh),fh,figL);
        appendd3(2,1,length3(fk),fk,figkL);
      }
    }//180705to
  }
  tmpi1[0]=0;
  for(i=1; i<=length1(paL)-1; i++){
    if(memberi(i,seL)==0){
      appendi1(i,tmpi1);
    }
  }
  copyi(0,tmpi1[0],tmpi1,seL);
  seL[0]=tmpi1[0];
  Hiddendata[0][0]=0;
  for(i=1; i<=seL[0]; i++){
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
        partcrv3(tp,tq,fk,tmpmd3);
        appendd3(2,1,length3(tmpmd3),tmpmd3,Hiddendata);
        copyd(0,1,tmp1d2,pd2);
        sp=paL[seL[i]];
        copyd(0,1,tmp2d2,qd2);
        sq=paL[seL[i]+1];
      }
    }
  }
  if(seL[0]>0){
    if(dist(2,pd2,qd2)>Eps1){
      tp=invparapt(sp,fh,fk,tmpd3);
      tq=invparapt(sq,fh,fk,tmpd3);
      partcrv3(tp,tq,fk,tmpmd3);
      appendd3(2,1,length3(tmpmd3),tmpmd3,Hiddendata);
    }
    else{
      appendd3(2,1,length3(fk),fk,Hiddendata);
    }
  }
  return length3(figkL);
}

void borderparadata(short ch,double fkL[][3], double fsL[][3]){
  double ekL[DsizeL][3], fall[DsizeL][2], fbdxy[DsizeL][2];
  double tmpd3[DsizeM][3],  tmpd2[DsizeM][2], p[2], p3[3];
  double figkL[DsizeM][3], du, dv;
  int i, j;
  int din[DsizeS][2],din2[DsizeM][2];
  int ntmp, ntmpd3,ntmpd2;
  double par[DsizeM];
  du=(Urng[1]-Urng[0])/Mdv;
  dv=(Vrng[1]-Vrng[0])/Ndv;
  fsL[0][0]=0;
  ekL[0][0]=0;;
  if(DrawE==1){
    tmpd2[0][0]=0;;
    for(j=0; j<=Ndv; j++){
      add2(tmpd2, Urng[1], Vrng[0]+j*dv);
    }
    surfcurve(ch,tmpd2,tmpd3);
    appendd3(2,1,length3(tmpd3),tmpd3,ekL);
  }
  if(DrawN==1){
    tmpd2[0][0]=0;
    for(j=0; j<=Mdv; j++){
      add2(tmpd2, Urng[0]+j*du, Vrng[1]);
    }
    surfcurve(ch,tmpd2,tmpd3);
    appendd3(2,1,length3(tmpd3),tmpd3,ekL);
  }
  if(DrawW==1){
    tmpd2[0][0]=0;
    for(j=0; j<=Ndv; j++){
      add2(tmpd2, Urng[0], Vrng[0]+j*dv);
    }
    surfcurve(ch,tmpd2,tmpd3);
    appendd3(2,1,length3(tmpd3),tmpd3,ekL);
  }
  if(DrawS==1){
    tmpd2[0][0]=0;
    for(j=0; j<=Mdv; j++){
      add2(tmpd2, Urng[0]+j*du, Vrng[0]);
    }
    surfcurve(ch,tmpd2,tmpd3);
    appendd3(2,1,length3(tmpd3),tmpd3,ekL);
  }
  if(length3(ekL)>0){
    appendd3(2,1,length3(ekL),ekL,fkL);
  }
  projpara(fkL,fall);
  makexybdy(ch,fbdxy);
  dataindexd2(2,fall,din);
  Borderpt[0][0]=0;
  Otherpartition[0]=0;
  for(i=1; i<=length2i(din)-1; i++){
    Otherpartition[i]=Inf; Otherpartition[0]++;
  }
  Borderhiddendata[0][0]=0;  
  dataindexd3(2,fkL,din2);
  for(i=1; i<= length2i(din2); i++){
	tmpd3[0][0]=0;
    appendd3(0,din2[i][0],din2[i][1],fkL,tmpd3);
    projpara(tmpd3,tmpd2);
	partitionseg(tmpd2,fall,0,par);
/*
	if(length1(par)>2){
      ntmp=length1(par)-1;
      tmpd2[0][0]=0;
      for(j=2; j<=ntmp; j++){
        pull2(j,Partitionpt,p);
        addptd2(tmpd2, p);
      }
      appendd2(0, 1,length2(tmpd2),tmpd2,Borderpt);
    }
*/
	tmpd3[0][0]=0;
    appendd3(0,din2[i][0],din2[i][1],fkL,tmpd3);
//    for(j=din2[i][0]; j<=din2[i][1]; j++){
//      pull3(j,fkL,p3);
//      addptd3(tmpd3,p3);
//    }
	nohiddenpara2(ch,par,tmpd3,1, figkL);
	if(length3(figkL)>0){
      appendd3(2,1,length3(figkL),figkL, fsL);
    }
	ntmp=length3(Hiddendata);
    if(ntmp>0){
      appendd3(2,1,ntmp,Hiddendata,Borderhiddendata);
    }
  }
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
    nptL=appendi1(1,ptL);
    pull3(1,pd,p);
    for(k=2; k<=npd-1; k++){
      pull3(k,pd,tmp2d);
      if(dist(3,p,tmp2d)>eps1){
        nptL=appendi1(k,ptL);
        pull3(k,pd,p);
      }
    }
    pull3(npd-1,pd,p);
    pull3(npd,pd,tmp2d);
    if(dist(3,p,tmp2d)>eps){  // eps -> eps1 ? 
      nptL=appendi1(npd,ptL);
    }
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

void sfbdparadata(short ch,double outd3[][3]){
  double pdatad3[DsizeL][3];
  double pts[DsizeL][2],out3md[DsizeL][2],eps;
  double tmpmd[DsizeL][2],tmp1md[DsizeL][2],tmp2md[DsizeL][2],tmp3md[DsizeL][2];
  double tmpd[2],tmp1d[2],tmpd3[3],tmp1d3[3],tmp2d3[3],tmp2md3[DsizeL][3];
  int din[DsizeS][2],nlist[DsizeL];
  int ii,jj,kk,n,nall,flg;
  envelopedata(ch, out3md); //180517from
  tmp3md[0][0]=0;
  pts[0][0]=0;
  dataindexd2(2,out3md,din);
  for(jj=1;jj<=length2i(din);jj++){
	tmp1md[0][0]=0;
    tmp2md3[0][0]=0;
    for(kk=din[jj][0];kk<=din[jj][1];kk++){
      pull2(kk,out3md,tmpd);
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
        appendd2(2,1,length2(tmpmd),tmpmd,tmp3md);
      }
    }
  }
  out3md[0][0]=0;
  appendd2(0,1,length2(tmp3md),tmp3md,out3md);
  tmp3md[0][0]=0;
  appendd2(0,1,length2(pts),pts,tmp3md);
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
    pull2(ii,pts,tmpd);
    surffun(ch,tmpd[0],tmpd[1],tmp1d3);
    dataindexd2(2,out3md,din);
    for(jj=1;jj<=length2i(din);jj++){
      tmp2md[0][0]=0;
      appendd2(0,din[jj][0],din[jj][1],out3md,tmp2md);
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
        prependd2(ii,ii,pts,tmp2md);
        replacelistd2(2,jj,out3md,tmp2md);
        dataindexd2(2,out3md,din);//180517
        continue;
      }
      pull2(length2(tmp2md),tmp2md,tmpd);
      surffun(ch,tmpd[0],tmpd[1],tmpd3);
      if(dist(3,tmp1d3,tmpd3)<eps+Eps){
        appendd2(0,ii,ii,pts,tmp2md);
        replacelistd2(2,jj,out3md,tmp2md);
        dataindexd2(2,out3md,din);//180517
        continue;
      }
    }
  }
  nall=cuspsplitpara(ch,out3md, pdatad3);
  n=length2(Cuspsplitpt);
  Cusppt[0][0]=0;
  nall=appendd2(0, 1,n,Cuspsplitpt,Cusppt);
  borderparadata(ch,pdatad3, outd3);
  push3(Inf,3,0,outd3);
  nall=appendd3(0,1,length3(Borderhiddendata),Borderhiddendata,outd3);
  push3(Inf,3,0,outd3);
}

void groupnearpt3(double qlist[][3],double plist[][3]){
// 180428
  int ii,jj,flg,din[DsizeS][2];
  double p1[3],p2[3],gl[DsizeS][3];
  while(length3(qlist)>0){
    gl[0][0]=0;
    appendd3(2,1,1,qlist,gl);
    removed3(1,qlist);
    for(ii=1;ii<=length3(qlist);ii++){
      flg=0;
      pull3(ii,qlist,p1);
      for(jj=1;jj<=length3(gl);jj++){
        pull3(jj,gl,p2);
        if(dist(3,p1,p2)<Eps1){
          flg=1;
          break;
        }
      }
      if(flg==1){
        addptd3(gl,p1);
        removed3(ii,qlist);
      }
    }
    appendd3(2,1,length3(gl),gl,plist);
  }
}

double funmeet(short ch,double u, double v,double pa[3], double vec[3]){
  double pt[3], out;
  surffun(ch,u, v, pt);
  if((fabs(vec[1])>Eps)||(fabs(vec[0])>Eps)){
    out=(vec[1]*(pt[0]-pa[0])-vec[0]*(pt[1]-pa[1]));
  }else{
    out=pt[0];
  }
  return out;
}

void meetpoints(short ch,double pta[3], double ptb[3], int uveq,double out[][3]){
  int i, j, k,flg,din[DsizeS][2];
  double vec[3],v1,v2,v3;
  double du=(Urng[1]-Urng[0])/Mdv, dv=(Vrng[1]-Vrng[0])/Ndv;
  double uval1,uval2,vval1,vval2,eval11,eval12,eval21,eval22;
  double pl[5][2], vl[5], ql[11][2],p1[2],p2[2],m1,m2;
  double ptuv[2], puv1[2], puv2[2],p1d3[3], p2d3[3], ptd3[3];
  double tmpd1, tmpd2[2],tmpd3[3],tmp1d3[3],tmp1md3[DsizeS][3];
  vec[0]=ptb[0]-pta[0];  vec[1]=ptb[1]-pta[1];  vec[2]=ptb[2]-pta[2];
  out[0][0]=0;
  if(norm(3,vec)<Eps){
    return;
  }
  for(j=0; j<=Ndv-1; j++){
    vval1=Vrng[0]+j*dv;
    vval2=Vrng[0]+(j+1)*dv;
    uval1=Urng[0];
    eval11=funmeet(ch,uval1,vval1,pta,vec);
    eval12=funmeet(ch,uval1,vval2,pta,vec);
    for(i=0; i<=Mdv-1; i++){
      uval2=Urng[0]+(i+1)*du;
      eval21=funmeet(ch,uval2,vval1,pta,vec);
      eval22=funmeet(ch,uval2,vval2,pta,vec);
	  pl[0][0]=uval1; pl[0][1]=vval1; vl[0]=eval11;
      pl[1][0]=uval2; pl[1][1]=vval1; vl[1]=eval21;
      pl[2][0]=uval2; pl[2][1]=vval2; vl[2]=eval22;
      pl[3][0]=uval1; pl[3][1]=vval2; vl[3]=eval12;
	  pl[4][0]=uval1; pl[4][1]=vval1; vl[4]=eval11;
      ql[0][0]=0;
      for(k=0; k<=3; k++){
        pull2(k,pl,p1);
        pull2(k+1,pl,p2);
        m1=vl[k]; m2=vl[k+1];
        if(fabs(m1)<Eps){
          addptd2(ql, p1);
          continue;
        }
        if(fabs(m2)<Eps){
          continue;
        }
        if((m1>0)&&(m2>0)){
          continue;
        }
        if((m1< 0)&&(m2< 0)){
          continue;
        }
        tmpd2[0]=1/(m1-m2)*(-m2*p1[0]+m1*p2[0]);
        tmpd2[1]=1/(m1-m2)*(-m2*p1[1]+m1*p2[1]);
        addptd2(ql, tmpd2);
      }
      uval1=uval2;
      eval11=eval21;
      eval12=eval22;
      if(length2(ql)==2){
        puv1[0]=ql[1][0]; puv1[1]=ql[1][1]; 
        puv2[0]=ql[2][0]; puv2[1]=ql[2][1];  
        surffun(ch,puv1[0],puv1[1],p1d3);
        surffun(ch,puv2[0],puv2[1],p2d3);
        v1=vec[0]; v2=vec[1]; v3=vec[2];
        if(fabs(v1)>Eps){
          m1=pta[2]+v3/v1*(p1d3[0]-pta[0])-p1d3[2];
          m2=pta[2]+v3/v1*(p2d3[0]-pta[0])-p2d3[2];
        }else if(fabs(v2)>Eps){
          m1=pta[2]+v3/v2*(p1d3[1]-pta[1])-p1d3[2];
          m2=pta[2]+v3/v2*(p2d3[1]-pta[1])-p2d3[2];
        }else{
          m1=pta[1]-p1d3[1];
          m2=pta[1]-p2d3[2];
        }
        if(m1*m2>= 0){
          if(((m1>0) && (m2>0)) || ((m1< 0) && (m2< 0))){
            continue;
          }
          if(m1==0){
            ptd3[0]=p1d3[0]; ptd3[1]=p1d3[1]; ptd3[2]=p1d3[2];
            ptuv[0]=puv1[0]; ptuv[1]=puv1[1];
          }else{
            ptd3[0]=p2d3[0]; ptd3[1]=p2d3[1]; ptd3[2]=p2d3[2];
            ptuv[0]=puv2[0]; ptuv[1]=puv2[1];
          }
        }else{  
          ptd3[0]=1/(m1-m2)*(-m2*p1d3[0]+m1*p2d3[0]);
          ptd3[1]=1/(m1-m2)*(-m2*p1d3[1]+m1*p2d3[1]);
          ptd3[2]=1/(m1-m2)*(-m2*p1d3[2]+m1*p2d3[2]);
          ptuv[0]=1/(m1-m2)*(-m2*puv1[0]+m1*puv2[0]);
          ptuv[1]=1/(m1-m2)*(-m2*puv1[1]+m1*puv2[1]);
        }
        tmpd3[0]=ptd3[0]-pta[0];
        tmpd3[1]=ptd3[1]-pta[1];
        tmpd3[2]=ptd3[2]-pta[2]; 
        crossprod(3,tmpd3,vec, tmp1d3);
        if(norm(3,tmp1d3)<Eps1){
          tmpd1=dotprod(3,tmpd3,vec);
          if((tmpd1>-Eps)&&(norm(3,tmpd3)<norm(3,vec)+Eps)){
            if(length3(out)==0){
              addptd3(out,ptd3);
            }else{
              pull3(length3(out),out,p1d3);
              if(dist(3,p1d3,ptd3)>Eps){
                addptd3(out,ptd3);
              }
            }
          }
        }
      }
    }
  }
  tmp1md3[0][0]=0;
  groupnearpt3(out,tmp1md3);
  dataindexd3(2,tmp1md3,din);
  out[0][0]=0;
  for(i=1;i<=din[0][0];i++){
    p1d3[0]=0; p1d3[1]=0; p1d3[2]=0;
    tmpd1=din[i][1]-din[i][0]+1;
    for(j=din[i][0];j<=din[i][1];j++){
      p1d3[0]=p1d3[0]+tmp1md3[j][0]/tmpd1;
      p1d3[1]=p1d3[1]+tmp1md3[j][1]/tmpd1;
      p1d3[2]=p1d3[2]+tmp1md3[j][2]/tmpd1;
    }
    addptd3(out,p1d3);
  }
}

void crvsfparadata(short ch, double fkL[][3], double fbdkL[][3], int sepflg, double out[][3]){
  double fbdy[DsizeL][2], fk[DsizeM][3],outh[DsizeL][3];
//  double fkp[DsizeM][3], dt;
  double fh[DsizeM][2], parL[DsizeM], tmpmd3[DsizeM][3];
  double ptL[DsizeM][3], tmpd2[2], tmpd3[3], tmp1d1, tmp2d1;
  double po[2]={0,0}, epsd2[2]={Eps1,1}, pa[3], pb[3];
  int nbor=length3(Borderhiddendata);
  int ncshidden,din[DsizeM][2],din2[DsizeS][2];
  int nn, i, j, k, n;
  projpara(fbdkL,fbdy);
  out[0][0]=0;
  outh[0][0]=0;
  dataindexd3(2,fkL,din);
  for(nn=1; nn<=length2i(din); nn++){
    fk[0][0]=0;
    appendd3(0,din[nn][0],din[nn][1],fkL,fk);
    projpara(fk,fh);
    partitionseg(fh,fbdy,0,parL);
    if(sepflg==0){ //180522
      for(i=1; i<=length3(fk)-1; i++){
        pull3(i,fk,pa);
        pull3(i+1,fk,pb);
        meetpoints(ch,pa,pb,1,ptL);
        for(j=1; j<=length3(ptL); j++){
	      pull3(j,ptL,tmpd3);
          parapt(tmpd3,tmpd2);
          tmp1d1=paramoncurve(tmpd2,i,fh);
          tmp2d1=Inf;
          for(k=1; k<=length1(parL); k++){
             tmp2d1=fmin(tmp2d1,fabs(parL[k]-tmp1d1));
          }
          tmpd3[0]=pb[0]-pa[0]; tmpd3[1]=pb[1]-pa[1]; 
          tmpd3[2]=pb[2]-pa[2]; 
          if(tmp2d1*dist(3,tmpd3,po)>Eps1){
            appendd1(tmp1d1,parL);
          }
        }
        simplesort(parL);
      }
    }
    nohiddenpara2(ch,parL,fk,1, tmpmd3);
    appendd3(2,1,length3(tmpmd3),tmpmd3,out);
    appendd3(2,1, length3(Hiddendata),Hiddendata,outh);
  }
  push3(Inf,3,0,out); //17.06.17
  appendd3(0,1,length3(outh),outh,out);
}

void crv3onsfparadata(short ch,double fk[][3], double fbdyd3[][3], double out[][3]){
  // 180609 debugged(renewed)
  double fbdy[DsizeL][2],fh[DsizeL][2],fks[DsizeL][3],fhs[DsizeL][2],par[DsizeM];
  double tmpmd3[DsizeL][3],outh[DsizeL][3];
  int i,j,din[DsizeS][2];
  projpara(fbdyd3,fbdy);
  projpara(fk,fh);
  out[0][0]=0;
  outh[0][0]=0;
  dataindexd2(2,fh,din);
  for(i=1;i<=din[0][0];i++){
    fhs[0][0]=0; fks[0][0]=0;
	appendd2(0,din[i][0],din[i][1],fh,fhs);
    appendd3(0,din[i][0],din[i][1],fk,fks);
    tmpmd3[0][0]=0;
    if(length2(fhs)>1){
      partitionseg(fhs,fbdy,0, par);
      nohiddenpara2(ch,par,fks,1,tmpmd3);
      appendd3(2,1,length3(tmpmd3),tmpmd3,out);
      appendd3(2,1,length3(Hiddendata),Hiddendata,outh);
    }else{
      appendd3(2,1,1,fks,out);
    }
  }
  connectseg3(out, Eps1,tmpmd3);
  out[0][0]=0;
  appendd3(0,1,length3(tmpmd3),tmpmd3,out);
  push3(Inf,3,0,out);  //181025
  connectseg3(outh, Eps1,tmpmd3);
  appendd3(0,1,length3(tmpmd3),tmpmd3,out);//181025
}

void crv2onsfparadata(short ch,double fh[][2], double fbdyd3[][3], double out[][3]){
  double fk[DsizeL][3];
  surfcurve(ch,fh,fk);
  crv3onsfparadata(ch,fk,fbdyd3,out);
}

void wireparadata(short ch,double bdyk[][3], double udata[], double vdata[],const char *fname,const char *fnameh){
  double crv2d[DsizeL][2],out[DsizeL][3],out1[DsizeL][3],out2[DsizeL][3];
  double du=(Urng[1]-Urng[0])/Mdv;
  double dv=(Vrng[1]-Vrng[0])/Ndv;
  int i,j,din[DsizeS][2];
  short allflg=1;
  if(strlen(fnameh)>0){
    allflg=0;
  }
  char var0[]="wire3d";
  char varh0[]="wireh3d";
  char var[20];
  char varh[20];
  char varnow[40];
  char varhnow[40];
  varnow[0]='\0';
  varhnow[0]='\0';
  sprintf(var,"%s%d",var0,ch);
  sprintf(varh,"%s%d",varh0,ch);
  char dirfname[256];
  char dirfnameh[256];
  char varname[256];
  char varnameh[256];
  dirfname[0]='\0';
  dirfnameh[0]='\0';
  varname[0]='\0';
  varnameh[0]='\0';
  sprintf(varname,"%s%d",var,ch);
  sprintf(varnameh,"%s%d",varh,ch);
  sprintf(dirfname,"%s%s",Dirname,fname);
  sprintf(dirfnameh,"%s%s",Dirname,fnameh);
  if((length1(udata)==0)&&(allflg==0)){
    out[0][0]=0;
    output3(1,"w",varname,dirfname,out);
    output3(1,"w",varnameh,dirfnameh,out);
  }
  for(i=1;i<=length1(udata);i++){
    crv2d[0][0]=0;
    for(j=0; j<=Ndv; j++){
      add2(crv2d, udata[i],Vrng[0]+j*dv);
    }
    if(allflg==1){out[0][0]=0;}
	crv2onsfparadata(ch,crv2d,bdyk,out);
    if(allflg==0){
      dataindexd3(3,out,din);
      out1[0][0]=0; out2[0][0]=0;
      appendd3(0,din[1][0],din[1][1],out,out1);
      appendd3(0,din[2][0],din[2][1],out,out2);
      if(i==1){
        output3(1,"w",varname,dirfname,out1);
        output3(1,"w",varnameh,dirfnameh,out2);
      }else{
        output3(0,"a",varname,dirfname,out1);
        output3(0,"a",varnameh,dirfnameh,out2);
      }
    }else{
      sprintf(varnow,"%s%s%d",var,"u",i);
      sprintf(varhnow,"%s%s%d",varh,"u",i);
      output3h("a",varnow, varhnow,fname,out);
    }
  }
  for(j=1;j<=length1(vdata);j++){
    crv2d[0][0]=0;
    for(i=0; i<=Mdv; i++){
      add2(crv2d, Urng[0]+i*du,vdata[j]);
    }
    if(allflg==1){out[0][0]=0;}
    crv2onsfparadata(ch,crv2d,bdyk,out);
    if(allflg==0){
      dataindexd3(3,out,din);
      out1[0][0]=0; out2[0][0]=0;
      appendd3(0,din[1][0],din[1][1],out,out1);
      appendd3(0,din[2][0],din[2][1],out,out2);
      if(i<length1(vdata)){
        output3(0,"a",varname,dirfname,out1);
        output3(0,"a",varnameh,dirfnameh,out2);
      }else{
        output3(0,"a",varname,dirfname,out1);
        outputend(dirfname);
        output3(0,"a",varnameh,dirfnameh,out2);
        outputend(dirfnameh);
      }
    }else{
      sprintf(varnow,"%s%s%d",var,"v",j);
      sprintf(varhnow,"%s%s%d",varh,"v",j);
	  output3h("a",varnow, varhnow,fname,out);
    }
  }
  if(allflg==0){
    outputend(dirfname);
    outputend(dirfnameh);
  }
}

void intersectcrvsf(const char *wa, short chfd,double crv[][3],const char *fname){
  double pa[3],pb[3],out[DsizeM][3],ptL[DsizeM][3];
  int i;
  short chcut;
  char chc[10];
  sprintf(chc,"%d",chfd);
  char var[]="intercrvsf";
  char dirfname[256];
  dirfname[0] = '\0';
  sprintf(dirfname,"%s%s",Dirname,fname);
  char varname[256];
  varname[0] = '\0';
  sprintf(varname,"%s%s",var,chc);
  ptL[0][0]=0;
  for(i=1;i<length3(crv);i++){
    pull3(i,crv,pa);
    pull3(i+1,crv,pb);
    meetpoints(chfd,pa,pb,1,out);
    appendd3(0,1,length3(out),out,ptL);
  }
  output3(1,wa,varname,dirfname,ptL);
}

void sfcutparadata(short chfd, short ncut, double fbdy3[][3],const char *fname,const char *fnameh){
  double Vec[3]={sin(THETA)*cos(PHI),sin(THETA)*sin(PHI),cos(THETA)};
  double v1=Vec[0],v2=Vec[1],v3=Vec[2];
  double out[DsizeM][2],out2[DsizeM][2],outd3[DsizeL][3];
  double ekL[DsizeL][3],out1d3[DsizeL][3],out2d3[DsizeL][3];
  double uval1,uval2,vval1,vval2,eval11,eval12,eval21,eval22;
  double pl[5][2], vl[5], ql[11][2],diff1,diff2;
  double tmp1md[DsizeM][2],tmp2md[DsizeM][2],tmpd[2],tmp1d[2],tmp2d[2];
  double tmp2md3[DsizeM][3],tmpd3[3],tmp1d3[3];
  double du=(Urng[1]-Urng[0])/Mdv;
  double dv=(Vrng[1]-Vrng[0])/Ndv;
  double p1[2],p2[2],m1,m2,q11,q12,q21,q22,a1,a3,b1,b3;
  int i,j,k,din[DsizeS][2],ns,ne,rmv[DsizeS];
  short chcut, allflg=0;
  if(strlen(fnameh)==0){
    allflg=1;
  }
  char var0[]="sfcut3d";
  char varh0[]="sfcuth3d";
  char var[20];
  char varh[20];
  sprintf(var,"%s%d",var0,chfd);
  sprintf(varh,"%s%d",varh0,chfd);
  char varnow[40];
  char varhnow[40];
  char dirfname[256];
  char dirfnameh[256];
  char varname[256];
  char varnameh[256];
  varnow[0]='\0';
  varhnow[0]='\0';
  dirfname[0]='\0';
  dirfnameh[0]='\0';
  varname[0]='\0';
  varnameh[0]='\0';
  sprintf(varname,"%s%d",var,chfd);
  sprintf(varnameh,"%s%d",varh,chfd);
  sprintf(dirfname,"%s%s",Dirname,fname);
  sprintf(dirfnameh,"%s%s",Dirname,fnameh);
  for(chcut=1;chcut<=ncut;chcut++){
    out[0][0]=0; out2[0][0]=0;
    for(j=0; j<=Ndv-1; j++){
      vval1=Vrng[0]+j*dv;
      vval2=Vrng[0]+(j+1)*dv;
      uval1=Urng[0];
      eval11=cutfun(chfd, chcut,uval1, vval1);
      eval12=cutfun(chfd, chcut,uval1, vval2);
      for(i=0; i<=Mdv-1; i++){
        uval2=Urng[0]+(i+1)*du;
        eval21=cutfun(chfd, chcut,uval2, vval1);
        eval22=cutfun(chfd, chcut,uval2, vval2);
	    pl[0][0]=uval1; pl[0][1]=vval1; vl[0]=eval11;
        pl[1][0]=uval2; pl[1][1]=vval1; vl[1]=eval21;
        pl[2][0]=uval2; pl[2][1]=vval2; vl[2]=eval22;
        pl[3][0]=uval1; pl[3][1]=vval2; vl[3]=eval12;
	    pl[4][0]=uval1; pl[4][1]=vval1; vl[4]=eval11;
        ql[0][0]=0;
        for(k=0; k<=3; k++){
          pull2(k,pl,p1);
          pull2(k+1,pl,p2);
          m1=vl[k]; m2=vl[k+1];
          if(fabs(m1)<Eps){
            addptd2(ql, p1);
            continue;
          }
          if(fabs(m2)<Eps){
            continue;
          }
          if((m1>0)&&(m2>0)){
            continue;
          }
          if((m1< 0)&&(m2< 0)){
            continue;
          }
          tmpd[0]=1/(m1-m2)*(-m2*p1[0]+m1*p2[0]);
          tmpd[1]=1/(m1-m2)*(-m2*p1[1]+m1*p2[1]);
          addptd2(ql, tmpd);
        }
        uval1=uval2;
        eval11=eval21;
        eval12=eval22;
        if(length2(ql)==2){
          q11=ql[1][0];q12=ql[1][1];q21=ql[2][0];q22=ql[2][1];
          a1=uval1;a3=uval2;b1=vval1;b3=vval2;
          if(((q11==a1)&&(q21==a1))||((q11==a3)&&(q21==a3))){
            if(((q21==b1)&&(q22==b1))||((q21==b3)&&(q22==b3))){
              appendd2(2,1,2,ql,out2);
            }else{
              appendd2(2,1,2,ql,out);
            }
            continue;
          }
          if(((q12==b1)&&(q22==b1))||((q12==b3)&&(q22==b3))){
            if(((q11==a1)&&(q21==a1))||((q11==a3)&&(q21==a3))){
              appendd2(2,1,2,ql,out2);
            }else{
              appendd2(2,1,2,ql,out);
            }
            continue;
          }
          appendd2(2,1,2,ql,out);
        }
      }
    }
    dataindexd2(2,out2,din);
    while(length2i(din)>0){
      ns=din[1][0];ne=din[1][1];
      tmp1md[0][0]=0;
      appendd2(0,ns,ne,out2,tmp1md);
      appendd2(2,ns,ne,out2,out);
      removelistd2(2,1,out2);
      dataindexd2(2,out2,din);
      rmv[0]=0;
      for(j=1;j<=length2i(din);j++){
        ns=din[j][0];ne=din[j][1];
        tmp2md[0][0]=0;
        appendd2(0,ns,ne,out2,tmp2md);
        pull2(1,tmp2md,tmp2d);pull2(1,tmp1md,tmp1d);
        diff1=dist(2,tmp1d,tmp2d);
        pull2(2,tmp2md,tmp2d);pull2(2,tmp1md,tmp1d);
        diff1=diff1+dist(2,tmp1d,tmp2d);
        pull2(1,tmp2md,tmp2d);pull2(2,tmp1md,tmp1d);
        diff2=dist(2,tmp1d,tmp2d);
        pull2(2,tmp2md,tmp2d);pull2(1,tmp1md,tmp1d);
        diff2=diff2+dist(2,tmp1d,tmp2d);
        if((diff1<Eps)||(diff2<Eps)){
          appendi1(j,rmv);
          continue;
        }
      }
      for(j=1;j<=rmv[0];j++){
        removelistd2(2,rmv[j],out2);
      }
      dataindexd2(2,out2,din);
    }
    connectseg(out, Eps1, out2);
    dataindexd2(2,out2,din);
    outd3[0][0]=0;
    for(i=1;i<=length2i(din);i++){
      ns=din[i][0];ne=din[i][1];
      tmp1md[0][0]=0;
      appendd2(0,ns,ne,out2,tmp1md);
      tmp2md3[0][0]=0;
      for(j=1;j<=length2(tmp1md);j++){
        pull2(j,tmp1md,tmpd);
        surffun(chfd,tmpd[0],tmpd[1],tmpd3);
        if(length3(tmp2md3)>0){
          pull3(length3(tmp2md3),tmp2md3,tmp1d3);
          if(dist(3,tmpd3,tmp1d3)<Eps1){
            continue;
          }
        }
        addptd3(tmp2md3,tmpd3);
      }
      appendd3(2,1,length3(tmp2md3),tmp2md3,outd3);
	}
    crv3onsfparadata(chfd,outd3,fbdy3,ekL);
    if(allflg==0){
      dataindexd3(3,ekL,din);
      out1d3[0][0]=0; out2d3[0][0]=0;
      appendd3(0,din[1][0],din[1][1],ekL,out1d3);
      appendd3(0,din[2][0],din[2][1],ekL,out2d3);
      if(chcut==1){
        output3(1,"w",varname,dirfname,out1d3);
        output3(1,"w",varnameh,dirfnameh,out2d3);
      }else{
        output3(0,"a",varname,dirfname,out1d3);
        output3(0,"a",varnameh,dirfnameh,out2d3);
      }
    }else{
      sprintf(varnow,"%s%d",var,chcut);
      sprintf(varhnow,"%s%d",varh,chcut);
      output3h("a",varnow, varhnow,fname,ekL);
    }
  }
  if(allflg==0){
    outputend(dirfname);
    outputend(dirfnameh);
  }
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

void readoutdata3(const char *fname, const char *var, double data[][3]){
  double x,y,z;
  float xx;
  char dstrorg[256];
  dstrorg[0]='\0';
  char dstr[256];
  dstr[0]='\0';
  char str[10];
  str[0]='\0';
  char strtmp[30];
  char tmp[10];
  tmp[0]='\0';
  int linectr=0, start=0,ii,jj,nn,nctr;
  FILE *fp;
  fp=fopen(fname,"r");
  if(fp==NULL){
    printf("file not found\n");
    return;
  }
  data[0][0]=0;
  nn=strlen(var);
  while( !feof(fp)){
    fgets(dstr,250,fp);
    linectr++;
    jj=strlen(dstr);
    if(jj>1){
      dstr[jj-3]='\0';
    }else{
      dstr[0]='\0';
    }
    if(strncmp(dstr,var,nn)==0){
      start=linectr;
    }else{
      if(start==0){
        continue;
      }
    }
    if(linectr==start){
      continue;
    }
    if(strncmp(dstr,"sta",3)==0){
      if(linectr>start+1){
        add3(data,Inf,2,0);
      }
      continue;
    }
    if(strncmp(dstr,"end",3)==0){
      continue;
    }
    if(strncmp(dstr,"[",1)!=0){
      break;
    }
    str[0]='\0';
    nctr=0;
    for(jj=2;jj<250;jj++){
      tmp[0]='\0'; sprintf(tmp,"%c",dstr[jj]);
      if(strncmp(tmp,"/",1)==0){
        break;
      }
      if(strncmp(tmp," ",1)==0){
        continue;
      }
      if(strncmp(tmp,",",1)==0){
        nctr++;
        if(nctr==1){
          x=atof(str); str[0]='\0';
          continue;
        }
        if(nctr==2){
          y=atof(str);str[0]='\0';
          continue;
        }
      }
      if(strncmp(tmp,"]",1)==0){
        z=atof(str);str[0]='\0';
        add3(data,x,y,z);
        nctr=0;
        jj++;
        tmp[0]='\0'; sprintf(tmp,"%c",dstr[jj]);
        if(strncmp(tmp,",",1)==0){
          jj++;
        }
        continue;
      }
      strtmp[0]='\0';
      sprintf(strtmp,"%s%s",str,tmp);
      str[0]='\0';
      for(ii=0;ii<20;ii++){
        str[ii]=strtmp[ii];
        if(strtmp[ii]=='\0'){
          break;
        }
      }
    }
  }
  fclose(fp);
}

