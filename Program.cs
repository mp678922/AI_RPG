using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;

//dotnet run
class Program {
    static void Main(string[] args) {
        try {
            // 新增 combine 變數
            bool combine = false; // 可根據需求設為 true 或 false

            // 獲取當前目錄
            string currentDirectory = Directory.GetCurrentDirectory();
            // 指定 Json 子資料夾路徑
            string jsonFolder = Path.Combine(currentDirectory, "Json");

            // 檢查 Json 資料夾是否存在
            if (!Directory.Exists(jsonFolder)) {
                Console.WriteLine("錯誤：Json 資料夾不存在。");
                return;
            }

            if (combine) {
                // 原有邏輯：合併所有檔案至單一檔案
                var mergedJson = new Dictionary<string, object>();

                // 處理 Json 資料夾下的直接 JSON 檔案
                string[] directJsonFiles = Directory.GetFiles(jsonFolder, "*.json");
                foreach (string filePath in directJsonFiles) {
                    string fileName = Path.GetFileNameWithoutExtension(filePath);
                    string jsonContent = File.ReadAllText(filePath);
                    object jsonObject = JsonSerializer.Deserialize<object>(jsonContent);
                    mergedJson[fileName] = jsonObject;
                }

                // 處理 Json 資料夾下的子資料夾
                string[] subFolders = Directory.GetDirectories(jsonFolder);
                foreach (string subFolder in subFolders) {
                    string folderName = Path.GetFileName(subFolder);
                    var folderJson = new Dictionary<string, object>();

                    string[] jsonFiles = Directory.GetFiles(subFolder, "*.json");
                    foreach (string filePath in jsonFiles) {
                        string fileName = Path.GetFileNameWithoutExtension(filePath);
                        string jsonContent = File.ReadAllText(filePath);
                        object jsonObject = JsonSerializer.Deserialize<object>(jsonContent);
                        folderJson[fileName] = jsonObject;
                    }

                    if (folderJson.Count > 0) {
                        mergedJson[folderName] = folderJson;
                    }
                }

                if (mergedJson.Count == 0) {
                    Console.WriteLine("錯誤：Json 資料夾內沒有任何 JSON 檔案（直接檔案或子資料夾內）。");
                    return;
                }

                var options = new JsonSerializerOptions {
                    WriteIndented = false,
                    Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
                };

                string mergedJsonString = JsonSerializer.Serialize(mergedJson, options);
                string outputFile = Path.Combine(currentDirectory, "規則書.txt");
                File.WriteAllText(outputFile, mergedJsonString, Encoding.UTF8);

                Console.WriteLine($"成功合併 Json 資料夾內的檔案，已輸出至：{outputFile}");
            } else {
                // 新邏輯：根據檔名分類輸出到「規則書」資料夾
                string outputFolder = Path.Combine(currentDirectory, "規則書");
                Directory.CreateDirectory(outputFolder); // 確保資料夾存在

                var rulesJson = new Dictionary<string, object>();    // 規則-
                var settingsJson = new Dictionary<string, object>(); // 設定-
                var refsJson = new Dictionary<string, object>();    // 參考-
                var othersJson = new Dictionary<string, object>();  // 其他

                // 處理所有 JSON 檔案（包括子資料夾）
                string[] allJsonFiles = Directory.GetFiles(jsonFolder, "*.json", SearchOption.AllDirectories);
                foreach (string filePath in allJsonFiles) {
                    string fileName = Path.GetFileNameWithoutExtension(filePath);
                    string jsonContent = File.ReadAllText(filePath);
                    object jsonObject = JsonSerializer.Deserialize<object>(jsonContent);

                    if (fileName.Contains("規則-")) {
                        rulesJson[fileName] = jsonObject;
                    } else if (fileName.Contains("設定-")) {
                        settingsJson[fileName] = jsonObject;
                    } else if (fileName.Contains("參考-")) {
                        refsJson[fileName] = jsonObject;
                    } else {
                        othersJson[fileName] = jsonObject;
                    }
                }

                // 序列化選項：不格式化，節省字元
                var options = new JsonSerializerOptions {
                    WriteIndented = false,
                    Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
                };

                // 輸出檔案
                if (rulesJson.Count > 0) {
                    string rulesFile = Path.Combine(outputFolder, "規則");
                    File.WriteAllText(rulesFile, JsonSerializer.Serialize(rulesJson, options), Encoding.UTF8);
                    Console.WriteLine($"已輸出規則檔案至：{rulesFile}");
                }
                if (settingsJson.Count > 0) {
                    string settingsFile = Path.Combine(outputFolder, "設定");
                    File.WriteAllText(settingsFile, JsonSerializer.Serialize(settingsJson, options), Encoding.UTF8);
                    Console.WriteLine($"已輸出設定檔案至：{settingsFile}");
                }
                if (refsJson.Count > 0) {
                    string refsFile = Path.Combine(outputFolder, "參考");
                    File.WriteAllText(refsFile, JsonSerializer.Serialize(refsJson, options), Encoding.UTF8);
                    Console.WriteLine($"已輸出參考檔案至：{refsFile}");
                }
                if (othersJson.Count > 0) {
                    string othersFile = Path.Combine(outputFolder, "指示");
                    File.WriteAllText(othersFile, JsonSerializer.Serialize(othersJson, options), Encoding.UTF8);
                    Console.WriteLine($"已輸出指示檔案至：{othersFile}");
                }

                if (rulesJson.Count == 0 && settingsJson.Count == 0 && refsJson.Count == 0 && othersJson.Count == 0) {
                    Console.WriteLine("錯誤：Json 資料夾內沒有任何 JSON 檔案。");
                }
            }
        } catch (Exception ex) {
            Console.WriteLine($"發生錯誤：{ex.Message}");
        }
    }
}