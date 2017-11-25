KETCindyのインストール（Windows）　　　修正日：2017.11.17

 注）既にインストールが済んでいて，KeTCindyだけを更新するとき
　　　・通常は，以下３) だけを実行すればよい．
　　　・従来の作業ディレクトリ(ketcindy)は名前を変えておく．
　　　　　　更新後必要なファイルを移動（コピー）する．
　　　・これまでのcdyファイルを使うときは，立ち上げた後
　　　　　　CindyScript/ketlib
　　　　の中身を作業ディレクトリ(work)にあるScriptInitializationで置き換えてギヤを押す．

０）準備

　（１）以下の１)，２)，３)(1)(2)では管理者としてログインしておく必要がある．
　（２）以下の圧縮ファイルをデスクトップにコピーして解凍しておく．
　　　　　　Winstart.exe
　　　　　　ketcindyfolder.exe
　　　　　　kettexnormal.ext（kettexを用いる場合）
　　　注１）デスクトップに３つのフォルダがあることを確認する．
　　　注２）解凍時「WindowsによってPCが保護」が現れたら「詳細情報」を選択

１）TeXのインストール

　（１）kettexを用いる場合
　　　・TeXLiveをKeTCindy用にアレンジしたもので，標準のTeXLiveより軽い．
　　　・環境変数を使わないので，既にインストールされているTeXと干渉しない．
　　　・KeTCindyに必要なファイルが既に入っている．
　　　　　i) texmf-dist/scripts/ketcindy　ketlib, setketcindy, ketoutsetなど
　　　　　ii) texmf-dist/tex/latex/ketcindy　ketcindy関連のstyleファイル
　　　　　iii) texmf-dist/doc/support/ketcindy　各種マニュアルとソースファイル
　　　・kettexnormal.exeをデスクトップで解凍し，copykettex.batを右クリック
　　　　　「管理者として実行」を選ぶ．
　　　　　注）多少の時間がかかる．

　（２）既にインストールしている他のTeXを用いる場合
　　　・３)(１)を実行すれば，必要なファイルがコピーされる．
　　　・TeXLive以外では，TeXのパスとtexbinのパスを入力する．
　　　・「ketpic stylesをコピーする」を選ぶ．

２） Cinderella, R, Sumatra, Maximaのインストール（コピー）

　（１）Winstartを開く．
　（２）cindyinstall.exeを実行してインストールする．
　（３）R, Maxima, SumatraPDFもインストールする．
　　　　　注）Scilabを使うときは，ScilabInstallのScilabをインストール
　（４）TeXworksもインストールする．

３）KeTCindyのインストール

　（１）ketcindyfolder を開く．
　（２）copyscripts.batを右クリック,「管理者として実行」を選ぶ．
　　　　　　（管理者としてログインしてもこれを選択する）
　　　　・TeXのパス　kettexの場合は１を選択する．
　　　　・scriptsの内容がTeXの中にコピーされる
　　　　・Do you copy ketcindy styles?でyを選択すると
　　　　　　ketcindyのstyleファイルがTeXにコピーされmktexlsrが実行される．
　　　　　　　注）kettexの場合は通常はnでよい．
　（２）copyplugin.batを右クリック,「管理者として実行」を選ぶ．
　　　　・ユーザホームのヘッド　ユーザー名の前のパス
　　　　　　注）C:\Users の場合は単に d でもよい．
　　　　・Rのバージョン　3.4.2の場合は単に d でもよい．
　　　　・Maximaのバージョン　5.37.3の場合は単に d でもよい．
　　　　・CinderellaのPluginsにKetcindyPlugin.jarとdirhead.txtがコピーされる．
　（３）copywork.batをクリックする．
　　　　・作業ディレクトリ名　ketcindyの場合は単に d でもよい．
　　　　・作業ディレクトリのパス　ユーザホーム，C:\，デスクトップから選択
　　　　　　注）ユーザ名に全角または半角スペースがある場合は C:\ を選ぶ．
　　　　・workの内容が指定した作業ディレクトリにコピーされる．
　　　　・また、ユーザホームにketcindyhead.txtが作られる．

４）KeTCindyのテストラン

　（１）作業ディレクトリの中のtemplate.cdyをダブルクリックする．
　　　　　画面に白い枠が出れば，ライブラリは読み込まれている．
　　　　　そうでないとき
　　　　　　・トップメニューから，次を選択
　　　　　　　　　スクリプト > プラグインを開く
　　　　　　・KetCindyPlugin.jarが入っているか．
　　　　　　　　ない場合
　　　　　　　　　ketcindy>ketjavaにある同名ファイルをPluginsにコピーする．
　　　　　　・dirhead.txtに書かれているketcindyのパスが合っているか．

　（２）スクリーンの上部にあるFigureボタンを押してPDFが表示されれば成功
　　　　　表示されないとき
　　　　　　　ユーザホームのketcindyhead.txtを開いて，パスを確認する．
　　　　　　　　PathT="TeXのパス";
　　　　　　　　Pathpdf="pdfビューアのパス";

５）TeXエディタの設定（kettexの場合）

　（１）texworksをuplatexまたはplatexのエディタとして使うときは，次のようにする．
　　　　　・texworksを立ち上げる
　　　　　・次を選択
　　　　　　　　編集 > 設定 > タイプセット
　　　　　・上の欄（パス）に以下を追加
                         C:\kettex\texlive\bin\win32
                         C:\kettex/texlive\tlpkg\texworks
                         C:\kettex/texlive\tlpkg\tlperl/bin
                         C:\kettex/texlive\tlpkg\tlgs/bin
　　　　　　　　注）上の１行目を上の欄の先頭になるように移動する．
 　　　　　・下の欄の横にある + をクリック
　　　　　　　　名前：uplatex(ptex2pdf)またはplatex(ptex2pdf)
　　　　　　　　プログラム : ptex2pdf
　　　　　　　　引数：
                                -u　　（uplatexの場合）
                                -l
                                -ot
                                $synctexoption
                                $fullname
　　　　　　OKボタンを押し，デフォルトを変更してOKボタンを押す．

６）その他のインストール

　・他のソフトのインストーラはRelatedsoftwares.exeにある．
　・曲面描画を高速化するには，gccが必要である．
　　　minGWのホームページhttp://www.mingw.orgから
　　　　　download -> Install -> mingw-get-setup.exe
　　をダウンロードして実行
　　　注）パッケージは，mingw32-base, mingw32-gcc-g++だけでよい．

７）カスタマイズ

　（１）ketcindyフォルダを移動したとき
　　　　　ユーザホームのketcindyhead.txtを開き、Dirfileを修正する．
　（２）管理者以外の場合
　　　　・各ソフトウェアのインストールは管理者が行う．
　　　　・copyworkfolder.exeを解凍して，３）(3)と同様に行う．

８）トラブルシューティング

・一般的な手順
　（１）ketworkにあるkc.batをエディタで開く
　（２）コマンドプロンプトも開いて，１行ずつコピーして実行，結果を見る．
