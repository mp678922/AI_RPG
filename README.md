# 學園之影 #
>這是以AI Grok運行的18+RPG腳本。

腳本撰寫者是[YunHikari](https://www.plurk.com/MP678922)。

希望在網路上留下專案範例，分享與AI語言模型溝通，撰寫遊戲腳本的經驗。

想在未來看到以AI創作之互動遊戲腳本小說。

-------------------------------------------------------

## 警告 ##

本腳本為成人男性向R18+之回合遊戲腳本，視扭曲性癖為常態，人物設定與道德方面並沒有遵循常識撰寫。若有對此內容有不適之情節，請斟酌閱讀。

-------------------------------------------------------

## 給玩家 ##

如何遊玩這個腳本？

下載[規則書](https://github.com/mp678922/AI_RPG/releases/tag/%E8%A6%8F%E5%89%87%E6%9B%B8) 。

至[Grok](https://grok.com/?referrer=website)一次上傳所有規則書文件，直接開始遊戲。

-------------------------------------------------------

## 給腳本創作者 ##

這是一個讓Grok運行腳本的範例專案。

以Json形式為基礎而撰寫的RPG腳本。
筆者是以VSCode管理多個規則文件來統合整個腳本。並由自行撰寫的C#程式碼將多份規則文件統一成最終規則書。

所有腳本文件之原始檔案均放在「[Json](https://github.com/mp678922/AI_RPG/tree/main/Json)」資料夾下，由於發現Grok不太擅長閱讀過於複雜的階層結構，故不細分資階層管理。

選擇Json結構只是想測試AI對腳本的理解能力是否能進一步提升，但實測後縱使AI能理解，可是筆者認為只要規則可以寫到人類能讀得懂，AI大多都可按指示進行。

**使用Json結構並非強制事項。**

### 本專案分類的規則文件區分為： ###

- 以命名 [規則-] 開頭之文件：
  可在各種流程重複被使用的文件。
- 以命名 [流程-] 開頭之文件：
  為主流程中的其一結構，在主流程文件中有交代AI詳細的運行順序與規則。
- 以命名 [設定-] 開頭之文件：
  我將角色設定、地點設定放在這區類。
- 其他命名之文件：
  我將指令選單、給Grok指示、文本敘事風格、遊戲參數、主流程文件放置於此。

如果你是以Json並熟悉VSCode之腳本撰寫者。可複製本專案之結構撰寫你的腳本。

本腳本提供兩個exe檔將Json內資之資料整併為最終規則書。但需注意Json結構必須是完整的，否則程式無法完好運行。

如果你是熟悉C#程式設計之創作者，可參考本專案之Program.cs修改為您所需要，該程式文件為整併腳本的流程。

本腳本有諸多AI提示詞玄學，可參考但勿奉為圭臬。

-------------------------------------------------------

## 腳本創作問題集 ##

### 為合要將腳本分成多個檔案？ ###
  
- 因為文件字元數超過一定數量，Grok會擅自截斷文件內容，導致內容不完整。
由於筆者文件的字元數超標，故使用這方式確保AI不截斷文件。

### 要如何確認文件被截斷？ ###

- 將文件上傳給Grok問「這文件有沒有被截斷」即可。

### AI為什麼不按照我的規則跑？ ###

- AI會假裝自己懂，所以如果文件不夠清楚AI會擅自理解，務必好好確認自己的文件撰寫有沒有被AI誤會的空間。
- AI終究可能會失去記憶，它彌補失去記憶的方式是擅自推敲，假如回合數過長，將有可能發生。
- 如果發生文件資料截斷，不管怎麼改進AI都不會搞懂，所以一定要確認文件有沒有被截斷。

### AI竟然會失去記憶？ ###

- 記憶體並非無限配額，但至少可以運行一款小而精緻的遊戲。
- 筆者的規則算是異常龐大，所以很容易觸碰到AI記憶力的臨界點。
- AI的記憶可能根據資料處理量的龐雜度而失去先前記憶。
- AI的記憶也可能因為時間，例如伺服器太久沒有處理這任務而釋放這任務的實例化。
