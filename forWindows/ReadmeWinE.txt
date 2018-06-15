Install of KeTCindy(Win)       Modified : Mar. 27th  2018

  Rem) If you have installed softwares, 
                * Execute only the following 4).
                * Rename the existing working folder if necessary before executing.
                * For exisiting cdy files, 
                      replace contents of  CindyScript/ketlib with that of scriptinitialization.txt

0) Preparations
      (1) Password of Administrator will be required in 1) 2) and 3)(1)(2).
      (2) Download/Copy the followings on Desktop and extract them.
                  Winstart.exe
                  ketcindyfolder.exe
                  kettexnormal.exe (when you use kettex)

1) Install of TeX

      (1) Using kettex
              * kettex is arranged version of TeXLive for KeTCindy.
              * Files necessary for KeTCindy are already implemented.
                  i) texmf-dist/scripts/ketcindy   ketlib, setketcindy, ketoutset, etc.
                  ii) texmf-dist/tex/latex/ketcindy   Style files for ketcindy
                  iii) texmf-dist/doc/support/ketcindy  Manuals and source files
              * Extract kettexnormal.exe and right-click. Select "Run as administrator".
                    Rem) It will take a little while.
      (2) Using other TeX
                 Execute the following 3)(1).
	
2) Install Cinderella, Sumatra, R and Maxima using files in Winstart.
        Rem ) Also install Texworks if necessary.

3) Setting of KeTCdindy
                Open ketcindyfolder.
      (1) Right-click copyfilessetcindy.bat and select "Run as administrator".
               * Path of TeX : choose 1 in the case of kettex.
               * Contents of scripts will be copied into TeX.
               * ketcindystyle files will be copied and be executed mktexlsr.
               * Head of userhome : choose usually "d".
               * Version of R : choose "d" in the case of 3.4.2.
               * Version of Maxima : choose "d" in the case of 5.37.3.
               *  KetcindyPluign.jar and ketcindy.ini will be copied into Cinderella/Plugins.
      (2) Double-click copywork.bat.
               * Name of work directory : choose 1 in the case of ketcindy.
               * Path of work directory
                      if User name contains "space", choose C:\ (c).
               * Contents of work are copied into ketcindy(work).
                  And ketcindyhead.txt is generated in User's home.

5) Test run of KeTCindy
      (1) Double-click "template1basic.cdy" in "ketcindy\ketfiles".
           A frame in white appear on the screen.
                if not, check as follows:
                    a) From top menu of Cinderella,
                             Scripting > Reveal Plugin Folder
                    b) Confirm KetCindyPlugin.jar is in the folder.
                    c)  Open the file ketcindy.ini in the folder and check the path of ketcindy. 
	  (2) Press "Figure" button at the top left. then the PDF is displayed. 
                if not, open ketcindyhead.txt in userhome and check the contents
                     PathT="path of TeX";
                     Pathpdf="path of PDF viewer";

5)  If you use texworks as an editor of TeX
           Rem) path of texworks is C:\kettex\w32texb\share\texworks\texworks.exe
      (1) Launch TeXworks,
                and choose Edit > Preference > Typeset
      (2) Set as follows
               Push +
                     name : kettexlatex
                     program : find;
                           C:\kettex\ketbin\texworkslatex.bat
                     Argument $fullname
				   
6) When a user doesn't have a manager authority
       (1) An administrato should Install softwares.
       (2) Make the work directory as 3)(3).

7) Install other softwares
      (1) Use Relatedsoftwares.exe.
      (2) Install minGW if you use gcc to speed up drawings of surface.
               *Go to http://www.mingw.org, and
                    download -> Install -> mingw-get-setup.exe
