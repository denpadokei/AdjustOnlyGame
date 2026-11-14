# AdjustOnlyGame

[![Build and Release](https://github.com/denpadokei/AdjustOnlyGame/actions/workflows/build-and-release.yml/badge.svg)](https://github.com/denpadokei/AdjustOnlyGame/actions/workflows/build-and-release.yml)

SaberTailor のコントローラ位置調整パッチを、ゲームプレイ中だけに限定する MOD です。メニューなどゲーム以外のシーンでは SaberTailor の調整処理を動かしません。

## 機能

- SaberTailor の `DevicelessVRHelperAdjustControllerTransform` / `OculusVRHelperAdjustControllerTransform` / `OpenVRHelperAdjustControllerTransform` の `Prefix` を Harmony の対象にする
- 現在のシーンが `GameCore` のときだけ SaberTailor の調整パッチを実行し、それ以外のシーンでは実行しない
- `SceneManager.activeSceneChanged` を購読してシーンごとの状態を切り替える
- プラグインの無効化時に Harmony パッチをすべて解除する

## 動作環境

| 項目 | 内容 |
| --- | --- |
| Beat Saber | 1.18.3 |
| 依存 MOD | BSIPA ^4.2.0 |
| 前提 MOD | SaberTailor (CI は 3.4.1 を導入。`SaberTailor.dll` のパッチメソッドを対象にするため必須) |

## インストール

1. Beat Saber を 1.18.3 に合わせる (BSManager などのバージョン管理ツールを推奨)
2. BSIPA と上記の依存 MOD をインストールする
3. [Releases](https://github.com/denpadokei/AdjustOnlyGame/releases) から `AdjustOnlyGame-0.0.2-bs1.18.3.zip` をダウンロードし、`Plugins` フォルダをゲームフォルダへ上書きコピーする

## 使い方

ゲーム内に UI や設定はありません。インストールすると、SaberTailor のコントローラ位置調整がゲームプレイ中 (`GameCore` シーン) でのみ行われるようになります。

## ビルド

```powershell
git clone https://github.com/denpadokei/AdjustOnlyGame.git
cd AdjustOnlyGame
dotnet build .\AdjustOnlyGame\AdjustOnlyGame.csproj -c Release
```

`BeatSaberDir` (または `GameDirectory`) に Beat Saber のインストール先を設定すると、ゲームの参照アセンブリを解決できます。SaberTailor をインストールしたゲームを指定してください (`$(BeatSaberDir)\Plugins\SaberTailor.dll` を参照します)。

GitHub Actions の `build-and-release.yml` が push ごとにビルドし、`X.X.X` 形式のタグを push するとリリースを作成します。

## ライセンス

ライセンスファイルはありません。
