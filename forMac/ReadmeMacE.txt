Install of KeTCindy(Mac)       Modified : Mar. 27th  2018

  Rem) If you have installed softwares, 
                * Execute only the following 4).
                * Rename the existing working folder if necessary before executing.
                * For exisiting cdy files, 
                      replace contents of  CindyScript/ketlib with that of scriptinitialization.txt
  
0) Preparations
      (1) It is efficient to display "Macintosh HD" on Desktop.
               Finder > Preference > General
             Check "Hard Disk".
      (2) Password of Administrator will be required in 1), 2) and 3)(1).
      (3) Download/Copy the followings and make their virtual disks.
                  Macstart.dmg
                  ketcindyfolder.dmg
                  kettexnormal.dmg (when you use kettex)
      (4) Select copyfilessetketcindy.sh in ketcindyfoler and "get info".
                 Change "Open with " to "Terminal".
             Rem) "Terminal" will be sometimes used. It is in "/Applications/Utilities".
             Rem)  if OS is Sierra, start up "Terminal", and execute:
                              sudo spctl --master-disable

1) Install of TeX

      (1) Using kettex
              * kettex is an arranged version of TeXLive for KeTCindy.
              * Files necessary for KeTCindy are already implemented.
                  i) texmf-dist/scripts/ketcindy   ketlib, setketcindy, ketoutset, etc.
                  ii) texmf-dist/tex/latex/ketcindy   Style files for ketcindy
                  iii) texmf-dist/doc/support/ketcindy  Manuals and source files
              * Open  kettexnormal and copy kettex to applications.
                    Rem) It will take a little while.
      (2) Using other TeX
                 Execute the following 3)(1).

2) Install Cinderella, Sumatra, R and Maxima using files in Winstart.
        Rem ) Also install Texworks if necessary.

3) Setting of KeTCdindy
                Open ketcindyfolder.
      (1) Double-click copyfilsesetcindy.sh.
               * Path of TeX : choose 1 in the case of kettex.
               * Contents of scripts will be copied into TeX.
               * ketcindystyle files will be copied and be executed mktexlsr.
               * Head of userhome : choose usually "d".
               * KetcindyPluign.jar and ketcindy.ini will be copied into Cinderella/Plugins.
               * Contents of ketcindy.ini
                     PathThead   root path of TeX
                     Homehead   head of user home
                     Dirhead   path of libraries of KeTCindy
      (2) Double-click copywork.sh.
               * Name of working directory : input "d"  in the case of ketcindy.
               * Path of working directory
                      userhome(u), desktop(d), other(o)
               * TeX of typeset
               * How to execute Terminal
                     sh (not be displayed the process) , open(displyed the process)
               * Contents of work are copied into ketcindy(work).
                  And ketcindyhead.txt is generated in User's home.
                      Dirfile  full path of working directory
                      PathT  full path of TeX
                      Mkkc    "sh" or "open"

4) Test run of KeTCindy
      (1) Double-click "template1basic.cdy" in "ketcindy/ketfiles".
            Then a frame in white appear on the screen.
                if not, check as follows:
                    a) From top menu of Cinderella,
                             Scripting > Reveal Plugin Folder
                    b) Confirm KetCindyPlugin.jar is in the folder.
                    c) Open ketcindy.ini and check the contents.
	  (2) Press "Figure" button at the top left. then the final PDF output is displayed. 
                if not, open ketcindyhead.txt in userhome and check the contents.
                     Dirfile="path of work directory";
                     PathT="path of TeX";
                     Mackc=(change "sh" and rerun);
                            if Mackc="open", process of terminal will appear.
        Rem) To close the window of Terminal when the process exits,
                         Preferences > Shell > "Colse if the shell exited clearly"

5)  If you use texworks as an editor of TeX,
      (1) Launch TeXworks,
                and choose Edit > Preference > Typeset
      (2) Set as follows
　　　　　Push +
                     name : kettex
                     program : find;
                           /Applications/kettex/ketbin/texworkslatex.sh
                   Argument $fullname

6) When a user doesn't have a manager authority
       (1) An administrator should install softwares.
       (2) Make the work directory as 3)(3).

7) Install other softwares
      (1) Use Relatedsoftwares.zip.
      (2) Install Xcode if you use gcc to speed up drawings of surface.
