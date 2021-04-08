1. emath??.sty とは
    中学・高校で数学のプリントを作る際に必要な記号，
  環境を集めたマクロ集です．
  このパッケージは，emath シリーズの統合版です．
    (2005/11/03 現在の最新バージョンを集めています．)

2. 前提となる LaTeX のバージョン
  LaTeX2e を前提とします．

3. インストール
 (1) emathfyymmdd.lzh (yymmdd は年月日を示す数値列）
   を解凍して得られる sty.lzh を解凍します。
   解凍先は，TeX をインストールしたフォルダの下に texmf フォルダが
   あるはずですが，さらにその下に
      ...\texmf\tex\platex\misc\emath
   というフォルダを作成して，その中に sty.lzh を解凍します。
 (2) 説明書が doc.lzh にありますから，
       ...\texmf\doc\emath
   というフォルダを作成し，そこを解凍先に指定してください。
   その結果，さらに下に
      b4yoko3
      emath
      ....
   などのサブフォルダが作成されて，その中に
   使用説明書 sample?.tex などが格納されます．
 (3) pdf.lzh には，説明書の一部を PDF 形式にしたものが含まれています。
   doc.lzh と同じく
       ...\texmf\doc\emath
   を解凍先に指定して解凍してください。

なお，解凍ソフトの設定によっては上記のようにならないこともあります．
その場合は，上記のようなフォルダを作成してファイルを格納してください．

   (注１) Unix 系のOS (Mac OS X を含む）でご利用の方は
              http://emath.s40.xrea.com/x/unix.htm
         をご覧ください。

  （注２）ls-R ファイルを使用されている場合は，更新をお忘れなく。

4. まずは．．．
    このパッケージの中心は emath.sty です．
  まずは，doc\emath\emath にある sample.tex をタイプセットしてみてください．
  図形・グラフ描画機能は emathP.sty が担っています．
        doc\emath\emathP にある sampleP.tex をご覧ください．
  グラフ描画は perl と連携して行う emathPp.sty が便利ですが，
  それについては
        doc\emath\emathPp\samplepp.pdf
  をご覧ください。
  
5. 必要なスタイルファイルとその在処
   必要なスタイルファイルについて述べます．
   基本的なパッケージとして、
      amsmath, tools, graphics
   パッケージは必須です。

     このうち，amsmath は v 2.** を前提とするコマンドがいくつかあります。
   v 1.** の方は amsmath パッケージをバージョンアップしてください。

   その他に、
      epic.sty, eepic.sty
      eclarith.sty
   が必要です．これらの在処は，例えば次の通りです．

  (1) epic.sty, eepic.sty
        CTAN:macro/latex/contrib/other/
  (2) eclarith.sty
        http://mechanics.civil.tohoku.ac.jp/~bear/bear-collections/index-j.html

  (3) Perl と連携してグラフを描画する機能をご利用の場合は，
        ...\texmf\doc\emath\emathPp\samplepp.pdf
      をご覧ください。

6. emath シリーズの概要
    各スタイルファイルのおもな使用目的を記述します．
      emath.sty       全般
      emathP.sty      図形・グラフ描画
      　　このスタイルファイルはつぎの５つに分割されています。
      　　　　平面座標を扱う              emathPh.sty
      　　　　x,y座標の単位長を異にする   emathPxy.sty
      　　　　空間座標を扱う              emathPk.sty
      　　　　Perl との連携処理をする     emathPp.sty
      　　　　作表環境 hyou, Hyou を扱う  emathT.sty
      emathPs.sty     PostScript で描画する
      emathAe.sty     解答を巻末に集める
      emathB.sty      分数計算
      emathBk.sty     複数ページにわたる囲み枠を作る breakbox環境の
                      バリエーションをいくつか集めてあります。
                      解答部を二段組にして，右側に注釈をつけるスタイルを
                      狙っています。
      emathBt.sty     本文と傍注の間に縦罫線を入れます
      emathC.sty      計算をするサブマクロ
      emathE.sty      enumerate 環境の拡張
      emathFx.sty     txfonts などで用意されているフォントのつまみ食い
      emathHe.sty     平方根の計算
      emathK.sty      カナによる番号付け
      emathN.sty      流れ図描画
      emathPa.sty     斜交座標系
      emathR.sty      複数の LaTeX 文書ファイルを統合
      emathT.sty      列幅を指定した表を作成する環境 hyou, Hyou
                      （増減表を念頭においています）
      emathW.sty      縦書きの除法
      emathZ.sty      樹形図描画
      b4yoko3.sty     考査用 B4横３段組
      (b4yoko4)
      hako.sty        センター試験の解答枠（番号付けと相互参照)
      (arhako.sty         網掛け）
      itembbox.sty    上下見出しつき罫線ボックス
      itembkbx.sty    複数ページにわたる見出しつき罫線ボックス
      showexample.sty TeXソースとタイプセットした結果の対比（対訳 TeX）
           ファイル名を showex.sty としたものもあります。内容は同一です。
      showProg.sty    対訳TeX で，ソース部に乙部氏の program.sty を使う。

7. emath の使用例
    emath??.sty を使用した文書の例は
      http://emath.s40.xrea.com/
  で公開しています．
  目次の
      使用例
  からたどれます．
    大学入試センター試験の問題    
    大学入試問題集（大学別・分野別)
    高等学校入試問題
    中学校入試問題
    授業用プリント
    定期考査の問題・解答
    emath のコマンドを使用する講座
  などがあります．

8. サポートなど
    このパッケージのサポートは 
      http://emath.s40.xrea.com/ の掲示板
    で行っています．
    バグ報告，質問，提案などはそちらにお願いします．

    また，細かいバージョンアップは
      http://emath.s40.xrea.com/
    の「修正パック」ページで公開していきます．

  このパッケージに含まれるファイルの著作権などについては
      http://emath.s40.xrea.com/
  のサポートページをご覧ください。
  
                                                大熊　一弘
                                                       tDB
                                           emath@nifty.com
