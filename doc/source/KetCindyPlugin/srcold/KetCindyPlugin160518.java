import de.cinderella.api.cs.CindyScript;
import de.cinderella.api.cs.CindyScriptPlugin;
import org.apache.commons.math.linear.MatrixUtils;
import org.apache.commons.math.linear.RealMatrix;

import java.awt.*;
import java.util.ArrayList;
import java.util.Arrays;
import java.io.*;


public class KetCindyPlugin extends CindyScriptPlugin {

    public String getName() {
        return "KetCindy Plugin";
    }

    public String getAuthor() {
        return "The KetCindy Project Team";
    }

    @CindyScript("systemproperty")
    public String getUserID(String s) {
        return System.getProperty(s);
    }

    @CindyScript("square")
    public double quadrieren(double x) {
        return x * x;
    }

    @CindyScript("grayvalue")
    public double getGray(Color c) {
        return (c.getBlue() + c.getRed() + c.getGreen()) / 3.;
    }

    @CindyScript("testarray")
    public String writeArray(ArrayList<Double> al) {
        return Arrays.toString(al.toArray());
    }
    
    @CindyScript("getdir")
    public String getdir() {
        return System.getProperty("user.dir");
    }

    @CindyScript("gethome")
    public String gethome() {
        return System.getProperty("user.home");
    }
	
    @CindyScript("iswindows")
    static public boolean iswindows(){
        String os=System.getProperty("os.name").toLowerCase();
        if(os!=null && os.startsWith("windows")){
            return true;
        }
        else{
            return false;
        }
    }
    @CindyScript("ismacosx")
    public static boolean ismacosx(){
        String os=System.getProperty("os.name").toLowerCase();
        if(os!=null && os.startsWith("mac")){
            return true;
        }
        else{
            return false;
        }
    }
    @CindyScript("islinux")
    public static boolean islinux(){
        String os=System.getProperty("os.name").toLowerCase();
        if(os!=null && os.startsWith("linux")){
            return true;
        }
        else{
            return false;
        }
    }

    @CindyScript("iswin")
    public static boolean iswin() {
        String OS_NAME = System.getProperty("os.name").toLowerCase();
        return OS_NAME.startsWith("windows");
    }

	@CindyScript("kc")
    public static void kc(String args) throws IOException {
	ProcessBuilder pb = new ProcessBuilder();
	if(iswindows()){
		pb.command("cmd.exe","/c","start",args);
    }
	else{
      if(ismacosx()){
		pb.command("open",args);
      }
      else{
		pb.command("sh",args);
      }
	};
	Process process = pb.start();
	return;
    }

    @CindyScript("ispaulvisiting")
    public static boolean ispaulvisiting() {
        return true;
    }

    @CindyScript("texv")
    public static void texv( String s,  String d, String sf, String tf) throws Exception{
        ProcessBuilder pb = new ProcessBuilder();
        String[] cmd = {s,d,sf,tf};
        pb.command(cmd);
        Process process = pb.start();
        return ;
    }

    @CindyScript("givemeamatrix2")
    public static Object givemeamatrix2() {
        try {
            return "the Matrix: " + theGiveMeAMatrix().toString();
        } catch (Throwable e) {
            e.printStackTrace();
            return "no Matrix: " + e.toString();
        }
    }

    public static Object theGiveMeAMatrix() {
        double[][] matrixData = { {1d,2d,3d}, {2d,5d,3d}};
        RealMatrix m = MatrixUtils.createRealMatrix(matrixData);
        return m;
    }
    
    @CindyScript("getdirhead")
    public static String getdirhead(){
        if(iswindows()){
            return "C:\\ketcindy";
        }
        else if(ismacosx()){
            return "/Applications/ketcindy";
        }
        else if(islinux()){
            return "/usr/share/ketcindy";
        }
        else{
            return "/Applications/ketcindy";
        }
    }


}
