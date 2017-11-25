Install of KeTCindy(Linux)       Modified : Nov. 25th  2017
  
0) Preparations
        Download/Copy  ketcindyfolder.zip and extract.

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
              * Copy as follows:
                       ketcindyfolder/scripts/ketcindy  => texmf-dist/scripts/ketcindy
                       ketcindyfolder/ketpicstyle/ketcindy  => texmf-dist/tex/latex/ketcindy
                       ketcindyfolder/misc/ketcindy  => texmf-dist/doc/support/ketcindy
              * Execute mktexlsr.

2) Install Cinderella, Sumatra, R and Maxima.
      (1) Modify tex-dist/scripts/ketcindy/ketoutset.txt.
      (2) Modify tex-dist/scripts/ketcindy/dirhead.txt.
			  
3) Setting of KeTCdindy
      (1) Make your work directory and copy contents of ketcindyfolder/work.
      (2) Boot up Cinderella2 and select "Scripting/reveal plugins".
               * Copy
			         tex-dist/scripts/ketcindy/dirhead.txt
                     tex-dist/scripts/ketcindy/ketjava/KetcindyPlugin.jar.
               * Close Plugins and Cinderella2.
      (3) Double-click copywork.sh.
 
4) Test run of KeTCindy
      (1) Double-click "template.cdy" in your work folder.
            Then a frame in white appear on the screen.
                if not, check as follows:
                    a) From top menu of Cinderella,
                             Scripting > Reveal Plugin Folder
                    b) Confirm KetCindyPlugin.jar is in the folder.
                    c) Open dirhead.txt and check the contents.
	  (2) Press "Figure" button at the top left. then the final PDF output is displayed. 
                if not, open ketcindyhead.txt in userhome and check the contents.
                     Dirfile="path of work directory";
                     PathT="path of TeX";
                     Mackc=(change "sh" and rerun);
                            if Mackc="open", process of terminal will appear.
        Rem) To close the window of Terminal when the process exits,
                         Preferences > Shell > "Colse if the shell exited clearly"
						 