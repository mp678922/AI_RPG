# 學園之影 #
>這是以AI Grok運行的18+RPG腳本。

腳本撰寫者是[YunHikari](https://www.plurk.com/MP678922)

希望在網路上留下這個專案，分享與AI語言模型溝通，撰寫腳本的經驗。

-------------------------------------------------------

## 給玩家 ##

如何遊玩這個腳本?

下載[規則書](https://github.com/mp678922/AI_RPG/releases/tag/%E8%A6%8F%E5%89%87%E6%9B%B8) 

至[Grok](https://grok.com/?referrer=website)一次連續上傳所有規則書文件，直接開始遊戲。

-------------------------------------------------------

## 給腳本創作者 ##

這是一個讓Grok運行腳本的範例專案。

以Json形式為基礎而撰寫的RPG腳本。

筆者是以VSCode管理多個規則文件來統合整個腳本。並由自行撰寫的C#程式碼將多份規則文件統一成最終規則書。

所有腳本文件之原始檔案均放在「Json」資料夾下，由於發現Grok不太擅長閱讀過於複雜的階層結構，故不分資料夾管理。

選擇Json結構只是想測試AI對腳本的理解能力是否能進一步提升，但實測後縱使AI能理解，可是筆者認為只要規則可以寫到人類能讀得懂，AI大多都可按指示進行。

使用Json結構並非強制事項。

### 本專案分類的規則文件區分為： ###

- 以命名 [規則-] 開頭之文件
  可在各種流程重複被使用的文件。
- 以命名 [流程-] 開頭之文件
  為主流程中的其一結構，在主流程文件中有交代AI詳細的運行順序與規則。
- 以命名 [設定-] 開頭之文件
  我將角色設定、地點設定放在這區類。
- 其他命名之文件
  我將指令選單、給Grok指示、文本敘事風格、遊戲參數、主流程文件放置於此。

