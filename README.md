# Lilja Repository

[![license](https://img.shields.io/badge/LICENSE-MIT-green.svg)](LICENSE)
![unity-version](https://img.shields.io/badge/unity-6000.0+-blue.svg)

Type-safe persistence repository pattern for Unity with Roslyn Source Generator.

---

## 📦 インストール方法

### Package Manager (Git URL)

Unity Editorの **Package Manager > [+] > Add package from git URL...** に以下を入力します：

```text
https://github.com/kamahir0-lilja/Repository.git?path=/Packages/com.kamahir0.repository
```

特定のバージョンを指定する場合は、末尾にタグを付加してください（例: `#vcom.kamahir0.repository`）。

### manifest.json による導入

プロジェクトの `Packages/manifest.json` の `dependencies` に直接追加することも可能です：

```json
{
  "dependencies": {
    "com.kamahir0.repository": "https://github.com/kamahir0-lilja/Repository.git?path=/Packages/com.kamahir0.repository"
  }
}
```

---

## 外部依存関係とセットアップ

本パッケージは以下の外部ライブラリと連携します：
- **UniTask** (`com.cysharp.unitask`) [必須]

プロジェクトに外部依存が未導入の場合、Unity Editorのメニューバーからワンクリックで自動導入できます：
- `Lilja > Dependencies > Repository > Install UniTask`


## 📖 基本的な使い方

```csharp
using Lilja.Repository;
```

---

## 🛠️ 開発・検証方法

本リポジトリ自体が独立したUnityプロジェクトになっています。Unity Hubから本リポジトリのルートフォルダを開くことで、開発および動作確認が可能です。

- 配布対象パッケージ本体: `Packages/com.kamahir0.repository/` (Embedded Package)
- 開発・動作検証用コード: `Assets/Development/`

---

## 📄 ライセンス

[MIT License](LICENSE)
