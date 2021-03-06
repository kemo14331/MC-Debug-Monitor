﻿MC Debug Monitor

*本ツールはα版です。バグなどを発見した場合、本ツールの[ヘルプ(H) -> バグ報告]から報告していただけると嬉しいです。

[概要]
Minecraftのコマンドで得られる情報を表示するツールです。
Rconを使用しており、サーバーを利用した共同開発などにもお使いいただけます。

[初期設定]
本ツールはRconを通してサーバーへコマンドを送信して情報を得ています。
したがって初めにRconの設定が必要です。

(ローカルのサーバーを使用する場合)
1. 使用するサーバーのserver.propertiesの内容を以下のように編集し、保存します。
  enable-rcon=true
  rcon.port=25575
  rcon.password=(任意の文字列)

2. 本ツールのサーバータブのRconの設定で[インポート]ボタンを押します。
3. 編集したserver.propertiesを選択します。
4. IPアドレスにlocalhostと入力し、値が127.0.0.1になったことを確認します。
5. サーバー操作の接続を押し、ツール下部に[サーバーに接続しました]と表示されれば設定は完了です。

(リモートサーバーを使用する場合)
1. 本ツールのサーバータブのRconの設定から接続するサーバーのRconのIPアドレス、ポート、パスワードを入力します。
2. サーバー操作の接続を押し、ツール下部に[サーバーに接続しました]と表示されれば設定は完了です。


[基本操作]
メニューバーの[タブの追加]から各種機能を持ったタブを追加できます。
[タブの編集] -> [タブを閉じる]で選択したタブを閉じることができます。

[各タブの説明]

スコアボード
　ワールド内のスコアボードを一括で表示するタブです。
  [フィルタ]
    スコアボードリストを絞り込むことができます。
  [自動更新]
	指定した間隔(ミリ秒)でスコアボードを更新します。
　[更新]
	スコアボードを更新します。

テスト
  設定したコマンドを一括で実行し、その戻り値を表にして表示します。
  dataコマンドなどでMotionなどの値を一括で見たい時や、デバッグ環境を一括で操作したい場合に便利です。
  テストリストはmcFunctionから読み込むこともできます。
  [テストの編集]
   タイトル: 設定したコマンドに見出しをつけます。
   コマンド: 実行するコマンドです。
   削除: 選択したテストを削除します。
   編集の適用: 現在選択されているテストの内容を上書きします。
   追加: テストを追加します。
  [ホットキーの設定]
   設定したホットキーが押された時、テストを実行することができます。
  [ファイル]
   インポート: mcFunctionやJSONファイルからテストを復元できます。
   エクスポート: テストを外部ファイルに出力します。mcfunction形式では結果は保存されません。

データ
  data getコマンドの情報を整形して表示できます。
  [実行]
	コマンドを実行し、Resultへ結果を表示します。
  [ホットキーの設定]
     設定したホットキーが押された時、テストを実行することができます。
  [Font](Resultビューの右上)
     Resultのフォントやサイズを変更します。
　[コピー]
     Resultをコピーします。