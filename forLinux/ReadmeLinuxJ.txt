KETCindyの通常インストール（Linux）　　　修正日：2017.11.25

０）準備
　　　・ketcindyfolder.zipをダウンロードして解凍する．

１）TeXのインストール

　（１）kettexを用いる場合
　　　・TeXLiveをKeTCindy用にアレンジしたもので，標準のTeXLiveより軽い．
　　　・環境変数を使わないので，既にインストールされているTeXと干渉しない．
　　　・KeTCindyに必要なファイルが既に入っている．
　　　　　i) texmf-dist/scripts/ketcindy　ketlib, setketcindy, ketoutsetなど
　　　　　ii) texmf-dist/tex/latex/ketcindy　ketcindy関連のstyleファイル
　　　　　iii) texmf-dist/doc/support/ketcindy　各種マニュアルとソースファイル

　（２）既にインストールしている他のTeXを用いる場合
　　　・ketcindyfolderにあるフォルダを以下のフォルダにコピーする．
　　　　　i) scripts/ketcindy  => texmf-dist/scripts/ketcindy
　　　　　ii) misc/ketpicstyle/ketcindy  =>  texmf-dist/tex/latex/ketcindy
　　　　　iii) misc/ketcindy  =>  texmf-dist/doc/support/ketcindy
　　　・mktexlsrを実行する．

２）Cinderella, R, Maximaのインストール
　　　・それぞれの環境に合わせて，インストーラをダウンロードしてインストールする．
　　　・tex-dist/scripts/ketcindyにあるketoutset.txtを開いてパスを修正する．
　　　　　　PathT　使用するTeXのパス
　　　　　　Pathpdf　PDFビューアのパス
　　　　　　PathR　Rのパス
　　　　　　PathM　Maximaのパス
　　　・tex-dist/scripts/ketcindyにあるketcindy.iniを開いて修正する．
　　　　　　PathThead="texbinのパス";
　　　　　　Dirhead="TeX/scripts/ketcindyのパス";
　　　　　　Dirfile="作業ディレクトリのパス";

３）KeTCindyのインストール

　（１）適当な場所に作業ディレクトリを作り，ketcindyfolder/workの中身をコピーする．
　（２）Cinderella2を立ち上げ「スクリプト > プラグインを開く」を選ぶ．
　　　　・tex-dist/scripts/ketcindyの次の２つのファイルをPluginsにコピーする．
　　　　　　ketcindy.ini, ketjava/KetCindyPlugin.java
　　　　・Pluginsを閉じ，Cinderellaをいったん終了する．

４）KeTCindyのテストラン

　（１）作業ディレクトリの中のtemplate.cdyを選ぶ．
　　　　・実行アプリケーションがCinderella2になっていることを確かめる．
　　　　・template.cdyダブルクリックする．
　　　　・画面に白い枠が出れば，ライブラリは読み込まれている．
　　　　・そうでないとき
　　　　　　・トップメニューから，次を選択
　　　　　　　　　スクリプト >「 プラグインを開く」
　　　　　　・次を確認する
　　　　　　　　i) KetCindyPlugin.jarが入っているか．
　　　　　　　　ii) ketcindy.iniに書かれているパスが合っているか．
　（２）スクリーンの上部にあるFigureボタンを押してPDFが表示されれば成功である．
　　　　　 ・表示されないとき
　　　　　　　　ユーザホームのketcindyhead.txtを確認する．

