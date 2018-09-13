KETCindyの通常インストール（Mac）　　　修正日：2018.09.13

 注）既にインストールが済んでいて，KeTCindyだけを更新するとき
　　　・通常は，以下３) だけを実行すればよい．
　　　・従来の作業ディレクトリ(ketcindy)は名前を変えておく．
　　　　　　更新後必要なファイルを移動（コピー）する．
　　　・2017以前のcdyファイルを使うときは，立ち上げた後
　　　　　　CindyScript/ketlib
　　　　の中身を作業ディレクトリ(work)にあるScriptketlib.txtで置き換えてギヤを押す．
 
０）準備

　（１）以後の操作では，「Macintosh HD」を表示しておいた方がやりやすい．
　　　　Finderで次のようにする．
　　　　　Finder => 環境設定 => 一般 => ハードディスクにチェック
　（２）以下の１)，２)，３)(１)では管理者としてログインしておく必要がある．
　（３）以下の圧縮ファイルをデスクトップにコピーして，ダブルクリック
　　　　　　Macstart.dmg
　　　　　　ketcindyfolder.dmg
　　　　　　kettexnormal.dmg（kettexを用いる場合）
　　　　それぞれの仮想ディスクができる．
　（４）ketcindyfolderのcopyfilessetcindy.shを選択，「情報を見る」を開いて，
　　　　　「このアプリケーションで開く」を「ターミナル」に変更
　　　　　　　その他＞すべてのアプリケーション＞ユーティリティ＞ターミナル＞追加
　　　　　「すべてを変更する」をクリック
　　注１）ターミナルは以下の場所にある．
　　　　　　Macintosh HD>アプリケーション>ユーティリティ>ターミナル
　　注２）Sierra以降の場合
　　　　　　ターミナルで
　         　        sudo spctl --master-disable
　　　　　を実行（一度実行すればすべての場合に有効である）
　　　　　実行後すべてを閉じる

１）TeXのインストール

　（１）kettexを用いる場合
　　　・TeXLiveをKeTCindy用にアレンジしたもので，標準のTeXLiveより軽い．
　　　・環境変数を使わないので，既にインストールされているTeXと干渉しない．
　　　・KeTCindyに必要なファイルが既に入っている．
　　　　　i) texmf-dist/scripts/ketcindy　ketlib, setketcindy, ketoutsetなど
　　　　　ii) texmf-dist/tex/latex/ketcindy　ketcindy関連のstyleファイル
　　　　　iii) texmf-dist/doc/support/ketcindy　各種マニュアルとソースファイル
　　　・仮想ディスクkettexnormalを開き，kettexをApplicationsに入れる．
　　　注１）多少の時間がかかる．
　　　注２）終わったら仮想ディスクkettexnormalをゴミ箱に入れる．

　（２）既にインストールしているTeXLiveを用いる場合
　　　・３)(１)を実行すれば，必要なファイルがコピーされる．
　　　・「ketpic stylesをコピーする」を選ぶ．
　（３）既にインストールしている他のTeXを用いる場合
　　　・３)(３)にしたがって，手動で必要なファイルをコピーする．

２） Cinderella, R, Maximaのインストール

　（１）仮想ディスクMacstartを開く．
　（２）Cinderella2をフォルダ内のApplicationsに入れる．
　（３）TeXWorks（インストールされていない場合）も同様にする．
　（４）R-3.3.3.pkgをダブルクリックしてインストール．
　　　　　注）Scilabを使う場合，SciliabInstall.dmgを開いて同様にする．
　（５）Maxima.dmgをダブルクリックして仮想ディスクを作る．
　　　　　maximaをアプリケーションに入れる．

　注１）既にインストールしてあれば，インストールは不要
　注２）終わったら仮想ディスクMacstart,Maximaをゴミ箱に入れる．

３）KeTCindyのインストール

　（ 1）copyfilessetcindy.shをダブルクリック（管理者権限必要）
　　　　・TeXのパス
　　　　　　　kettexは１，kettex.appは２，通常のTeXLiveは３を選択する．
　　　　・scriptsの内容が選択したTeXの中にコピーされる
　　　　・ketcindyのstyleファイルがTeXにコピーされmktexlsrが実行される．
　　　　・ユーザホームのヘッド　ユーザー名の前のパス
　　　　　　注）通常の/Users の場合は単に d でよい．
　　　　・CinderellaのPluginsに，KetcindyPlugin.jarがコピーされketcindy.iniが作成される．

　（２）copywork.shをダブルクリック（管理者権限不要）
　　　　・作業ディレクトリketcindyがユーザホームに作成される．
　　　　・タイプセットの方法（TeXの種類）
　　　　　　　通常は，platex (p)またはuplatex(u)を選ぶ．
　　　　・ターミナルの実行方法
　　　　　　　sh (過程を表示しない），open（過程を表示する）
　　　　　　注）テストランで，openが正常に動かないときはshを選択する．
　　　　・ketcindyフォルダにworkフォルダの中身がコピーされる．
　　　　・ketcindyhange.txtがユーザホームに作成される．
　　　　　　注）TeXを切り替えるときなどはこのファイルを修正する．

　（３）手動でインストールする場合
　　　　・/ketcindyを作成して，ketcindyfolder/scriptの
　　　　　　ketcindyjs, ketlib, ketlibC
　　　　　をその中にコピーする．
　　　　・ketcindyfolder/styleをTeXの中の適当な場所にコピーする．
　　　　　　styleをketcindyに名称変更する．
　　　　　　mktexlsrを実行する．
　　　　・ketcindy.iniをテキストエディタで修正する．
　　　　　　　PathThead=(TeXのbin のパス);
　　　　　　　Homehead="/Users";
　　　　　　　Dirhead="/ketcindy";
　　　　・Cinderellaを立ち上げ，スクリプト/Pluiginを選択
　　　　　　　ketcindy.iniとketcindyfolder/ketjavaの中身をコピーする．
　　　　　（Cinderellaを終了）

４）KeTCindyのテストラン

　（１）作業ディレクトリの中のtemplate1basic.cdyを選び，「情報を見る」を開く．
　　　　　・アプリケーションが所定のCinderella2になっていることを確かめる．
　　　　　・「情報」を閉じて，template1basic.cdyをダブルクリックする．
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

　　注）PDFの表示後，ターミナル画面を閉じるようにするには：
　　　　　・アプリケーション／ユーティリティ／ターミナルを開く
　　　　　・トップメニューから
　　　　　　　　ターミナル＞環境設定＞（プロファイル）>シェル
　　　　　　　　　「シェルが正常に終了した場合閉じる」を選択

５）TeXエディタの設定（kettexnormalの場合）

　（１）TeXworksをuplatexまたはplatexのエディタとして使うときは，次のようにする．
　　　　　・TeXworksを立ち上げる
　　　　　・次を選択
　　　　　　　　TeXworks > 環境設定 > タイプセット
　　　　　・上の欄（パス）に以下を追加
                            /Applications/kettex/texlive/bin/x86_64-darwin
　　　　　　　注）上の行を上の欄の先頭になるように移動する．
 　　　　　・下の欄の横にある + をクリック
　　　　　　　　名前：uplatex(ptex2pdf)またはplatex(ptex2pdf)
　　　　　　　　プログラム : ptex2pdf
　　　　　　　　引数：
                                 -u　　（uplatexの場合のみ）
                                 -l
                                 -ot
                                 $synctexoption
                                 $fullname
　　　　　　OKボタンを押し，デフォルトを変更してOKボタンを押す．

　（２）TeXshopをエディタとして使うときは，次のようにする．
　　　　　・TeXshopの最新版をダウンロードする．
　　　　　・TeXshopの環境設定を開く．
　　　　　・内部設定／TeXのパスを設定する．
　　　　　　　　kettexの場合　/Applications/kettex/texlive/bin/x86_64-darwin
　　　　　・書類／設定プロファイル
　　　　　　　　platexの場合　ptex(ptex2pdf)
　　　　　　　　uplatexの場合　uptex(ptex2pdf)
　　　　　・OKを押してTeXshopを一旦終了する．

６）その他のインストール

・Meshlab など，他のソフトのインストーラはRelatedsoftwares.zipにある．
・曲面描画を高速化するには，gccが必要である．
　　Xcodeがインストールされていなければ，インストールする．
　　注）ターミナルで次を実行すれば，gccだけがインストールされる．
　　　　　sudo xcode-select --install

８）トラブルシューティング

・一般的な手順
　（１）ketworkにできているkc.shをエディタで開く．
　（２）ターミナルも開いて，kc.shの１行ずつをコピーして実行，結果を見る．
　　　注）１行目の「#!/bin/sh」は実行不要

・El Capitan以降でAsirを使うとき
　（１）Cinderellaからは，そのまま使える．
　（２）cfepを使うときは，XQuartzを更新して以下からダウンロードする．
                http://www.math.kobe-u.ac.jp/Asir/asir-ja.html
            さらに，asirをコピーする．

