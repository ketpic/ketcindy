function Drwxy(varargin)
   global XMIN XMAX YMIN YMAX GENTEN ARROWSIZE ...
          ZIKU XNAME XPOS YNAME YPOS ONAME OPOS ULEN;
   Nargs=length(varargin)
   Tmp=mtlb_findstr(ZIKU,'arrow');
   if Tmp~=[] 
        Arrowline([XMIN,GENTEN(2)],[XMAX,GENTEN(2)],ARROWSIZE);
        Arrowline([GENTEN(1),YMIN],[GENTEN(1),YMAX],ARROWSIZE);
     else
       Drwline(Listplot([XMIN,GENTEN(2)],[XMAX,GENTEN(2)]));
       Drwline(Listplot([GENTEN(1),YMIN],[GENTEN(1),YMAX]));
   end;
   Letter([XMAX,GENTEN(2)],XPOS,XNAME);
   Letter([GENTEN(1),YMAX],YPOS,YNAME);
   Letter(GENTEN,OPOS,ONAME);
endfunction
