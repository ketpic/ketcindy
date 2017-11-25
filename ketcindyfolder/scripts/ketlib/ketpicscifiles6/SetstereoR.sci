// 08.08.12

function SetstereoR(R,T,P,H)
  X=R*sin(T*%pi/180)*cos(P*%pi/180);
  Y=R*sin(T*%pi/180)*sin(P*%pi/180);
  Z=R*cos(T*%pi/180);
  Eye=[X-H/2*Y/(X^2+Y^2),Y+H/2*X/(X^2+Y^2),Z];
  Setpers([0,0,0],Eye);
endfunction

