KETCindyのインストール（Windows）　　　修正日：2018.11.16

 注）既にインストールが済んでいて，KeTCindyだけを更新するとき
　　　・通常は，以下３) だけを実行すればよい．
　　　・従来の作業ディレクトリ(ketcindy)は名前を変えておく．
　　　　　　更新後必要なファイルを移動（コピー）する．
　　　・2017以前のcdyファイルを使うときは，立ち上げた後
　　　　　　CindyScript/ketlib
　　　　の中身を作業ディレクトリ(work)にあるScriptketlibで置き換えてギヤを押す．

０）準備

　（１）以下の１)，２)，３)(1)(2)では管理者としてログインしておく必要がある．
　（２）以下の圧縮ファイルをデスクトップにコピーして解凍しておく．
　　　　　　Winstart.exe
　　　　　　ketcindyfolder.exe
　　　　　　kettex.exe（kettexを用いる場合）
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
　　　・kettex.exeをデスクトップで解凍し，kettexをCの直下に入れる．
　　　　　注）多少の時間がかかる．

　（２）既にインストールしている他のTeXLiveを用いる場合
　　　・３)(１)（２）を実行すれば，必要なファイルがコピーされる．

　（３）既にインストールしている他のTeXLを用いる場合
　　　・３)(３)に従って，手動で必要なファイルをコピーする．

２） Cinderella, R, Sumatra, Maximaのインストール（コピー）

　（１）Winstartを開く．
　（２）cindyinstall.exeを実行してインストールする．
　（３）R, Maxima, SumatraPDFもインストールする．
　　　　　注）Scilabを使うときは，ScilabInstallのScilabをインストール
　（４）TeXworksもインストールする．

３）KeTCindyのインストール

　（１）ketcindyfolderのcopyfilessetcindy.batを右クリック,「管理者として実行」を選ぶ．
　　　　　　（管理者としてログインしてもこれを選択する）
　　　　・TeXのパス　kettexの場合は１を選択する．
　　　　・scripts,style,docの内容がTeXの中にコピーされる
　　　　・CinderellaのPluginsにKetcindyPlugin.jarとketcindy.iniがコピーされる．

　（２）copywork.batをクリックする．
　　　　・Rのバージョン　3.4.2の場合は単に d でよい．
　　　　・Maximaのバージョン　5.37.3の場合は単に d でよい．
　　　　・workの内容が指定した作業ディレクトリにコピーされる．
　　　　・ユーザホームに.ketcindy.confが作られる．
　　　　・また，作業ディレクトリに ketcindy.confの雛形がコピーされる．
　　　　・KeTCindyを立ち上げたとき，設定ファイルは次の順に読み込まれる．
　　　　　　1) ketoutset.txt
　　　　　　２）　ユーザホームの .ketcindy.conf
　　　　　　3)　作業ディレクトリの ketcindy.conf

　（３）手動でインストールする場合
　　　　・ketcindyfolderをDesktopにおき，　copywork.batをその中に入れる．
　　　　・TeXの中の適当な場所にketcindyを作成する．
　　　　　　　　　KeTTeXの場合は，C:\kettex\texlive\texmf-dist\scripts\ketcindy　　　　　　
　　　　・ketcindyfolder\scriptのketcindyjs, ketlib, ketlibCketcindyをその中にコピーする．
　　　　・ketcindyfolder\styleをTeXの中の適当な場所にコピーして，　styleをketcindyに名称変更する．
  　　　　　　　KeTTeXの場合は，C:\kettex\texlive\texmf-dist\tex\latex　　　　　　　　　　　　
　　　　・mktexlsrを実行する．
　　　　・ketcindy.iniをテキストエディタで修正する．
　　　　　　　PathThead="(TeXのbin のパス)";
　　　　　　　　　KeTTeXの場合は，="C:\kettex\texlive\bin\x86_64-darwin\";
　　　　　　　Dirhead="(ketcindyのパス）";
　　　　　　　　　KeTTeXの場合は，="C:\kettex\texlive\texmf-dist\scripts\ketcindy";　　　　　
　　　　　　　Homehead="/Users";
　　　　　　　setdirectory(Dirhead);
　　　　　　　import("setketcindy.txt");
　　　　　　　import("ketoutset.txt");
　　　　・Cinderellaを立ち上げ，スクリプト/Pluiginを選択
　　　　　　　ketcindy.iniとketcindyfolder\ketjavaの中身をコピーする．
　　　　　（Cinderellaを終了）
　　　　・copywork.batを実行する．

４）KeTCindyのテストラン

　（１）作業ディレクトリの中のtemplate1basic.cdyをダブルクリックする．
　　　　　画面に白い枠が出れば，ライブラリは読み込まれている．
　　　　　そうでないとき
　　　　　　・トップメニューから，次を選択
　　　　　　　　　スクリプト > プラグインを開く
　　　　　　・KetCindyPlugin.jarが入っているか．
　　　　　　　　ない場合
　　　　　　　　　ketcindy>ketjavaにある同名ファイルをPluginsにコピーする．
　　　　　　・ketcindy.iniに書かれているketcindyのパスが合っているか．

　（２）スクリーンの上部にあるFigureボタンを押してPDFが表示されれば成功
　　　　　表示されないとき
　　　　　　　ユーザホーム/ketcindyのchangesetting.txtを開いて，パスを確認する．
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

　（２）EasyTeXをuplatexまたはplatexのエディタとして使うこともできる．
　　　　　・EasyTeX（最新版）をダウンロードする．
　　　　　・オプションのTeX環境設定を設定する．
　　　　　・PDFはAdobeを選択する（インストールしていなければインストールする）．
　　　　　
６）その他のインストール

　・他のソフトのインストーラはRelatedsoftwares.exeにある．
　・曲面描画を高速化するには，gccが必要である．
　　　minGWのホームページhttp://www.mingw.orgから
　　　　　download -> Install -> mingw-get-setup.exe
　　をダウンロードして実行
　　　注）パッケージは，mingw32-base, mingw32-gcc-g++だけでよい．

７）トラブルシューティング

・一般的な手順
　（１）ketworkにあるkc.batをエディタで開く
　（２）コマンドプロンプトも開いて，１行ずつコピーして実行，結果を見る．
