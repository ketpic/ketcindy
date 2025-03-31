Create a text file 'ketcindy.ini' with the following contents and place it in your 'user home'.

////Cotents of 'ketcindy.ini'

Dirhead="(path to ketcindy)/ketcindy(+version)/scripts";
PathM="(path to maxima)/usr/local/bin/maxima";
Dircdy=replace(Dircdy,"/C:","C:");
Dirlib=Dirhead+pathsep()+"ketlib";
setdirectory(Dirlib);
import("ketcindylibbasic1r.cs");
import("ketcindylibbasic2r.cs");
import("ketcindylibbasic3r.cs");
import("ketcindyliboutr.cs");
