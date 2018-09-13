Install of KeTCindy(Mac)       Modified : Sep. 14th  2018

  Rem) If you have installed softwares, 
                * Execute only the following 4).
                * Rename the existing working folder if necessary before executing.
                * If you want to use old cdy files made before 2017,
                      replace contents of CindyScript/ketlib with that of Scriptketlib.txt.
  
0) Preparations
      (1) It is useful to display "Macintosh HD" on Desktop.
               Finder > Preference > General
             Check "Hard Disk".
      (2) Password of Administrator will be required in 1), 2) and 3)(1) in the following.
      (3) Download/Copy the followings and make their virtual disks.
                  Macstart.dmg
                  ketcindyfolder.dmg
                  kettexnormal.dmg (when you use kettex)
      (4) Select copyfilessetketcindy.sh in ketcindyfoler and "get info".
                 Change "Open with " to "Terminal".
             Rem) "Terminal" will be often used. It is in "/Applications/Utilities".
             Rem)  if OS is Sierra or higher, start up "Terminal", and execute:
                              sudo spctl --master-disable

1) Install of TeX

      (1) Using kettex
              * kettex is an arranged version of TeXLive for KeTCindy.
              * Files necessary for KeTCindy are already implemented.
                  i) texmf-dist/scripts/ketcindy   ketlib, setketcindy, ketoutset, etc.
                  ii) texmf-dist/tex/latex/ketcindy   Style files for ketcindy
                  iii) texmf-dist/doc/support/ketcindy  Manuals and source files
              * Open  kettexnormal and copy kettex to applications.
                    Rem) It will take time.
      (2) Using other TeXLive
                 Execute the following 3)(1).
      (3) Using other TeX
                 Install necessary files manually according to 3)(3).

2) Install Cinderella, R and Maxima using files in Macstart.
        Rem ) Also install Skim and Texworks if necessary.

3) Setting of KeTCdindy
                Open ketcindyfolder.
      (1) Double-click copyfilsesetcindy.sh.
               * Path of TeX(KeTTeX, TeXLive) : choose the number(1,2,3).
               * Contents of scripts will be copied into TeX.
               * ketcindystyle files will be copied and mktexlsr will be executed .
               * Head of userhome : choose usually "d".
               * In Cinderella/Plugins
                      KetcindyPluign.jar will be copied
                      ketcindy.ini will be generated .

	  (2) Double-click copywork.sh.
               * Work directory "ketcindy" will be generated in User's home.
               * TeX(typeset) will be usually latex,xelatex or pdflatex.
               * How to execute Terminal
                     sh (not be displayed the process) , open(displyed the process)
               * Contents of work will be copied into "ketcindy".
               * "ketcindychange.txt" will be also generated in User's home.
                       You can change the setting of PathT, Mackc, etc.

	  (3) Installing manually
               * Generate /ketcindy and copy
                     ketcindyjs, ketlib, ketlibC in ketcindyfolder/script.
                  into /ketcindy.
               * Copy /ketcindyfolder/style into somewhere of TeX folder.
                     Rename style to ketcindy
                     Execute mktexlsr.
               * Edit ketcindy.ini using a text editor.
                     PathThead : path of bin of TeX
                     Homehead   head of user home (/Users)
                     Dirhead   path of libraries of KeTCindy
               * Boot up Cinderella and select editscripting/plugin.
                    Copy ketcindy.ini and the contents of ketcindyfolder/ketjava.
               * Execute copywork.sh.

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
      (2) Push upper + and add
                /Applications/kettex/ketbin/texworkslatex.sh
                    ( or path of your TeX )
       (3) Select Xelatex or pdflatex.

6) Install other softwares
      (1) Use Relatedsoftwares.zip.
      (2) Install Xcode if you use gcc to speed up drawings of surface.
                   sudo xcode-select --install
