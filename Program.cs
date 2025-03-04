using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // 獲取當前目錄
            string currentDirectory = Directory.GetCurrentDirectory();
            // 指定 Json 子資料夾路徑
            string jsonFolder = Path.Combine(currentDirectory, "Json");

            // 檢查 Json 資料夾是否存在
            if (!Directory.Exists(jsonFolder))
            {
                Console.WriteLine("錯誤：Json 資料夾不存在。");
                return;
            }

            // 儲存最終合併結果
            var mergedJson = new Dictionary<string, object>();

            // 處理 Json 資料夾下的直接 JSON 檔案
            string[] directJsonFiles = Directory.GetFiles(jsonFolder, "*.json");
            foreach (string filePath in directJsonFiles)
            {
                string fileName = Path.GetFileNameWithoutExtension(filePath);
                string jsonContent = File.ReadAllText(filePath);
                object jsonObject = JsonSerializer.Deserialize<object>(jsonContent);
                mergedJson[fileName] = jsonObject;
            }

            // 處理 Json 資料夾下的子資料夾
            string[] subFolders = Directory.GetDirectories(jsonFolder);
            foreach (string subFolder in subFolders)
            {
                string folderName = Path.GetFileName(subFolder);
                var folderJson = new Dictionary<string, object>();

                string[] jsonFiles = Directory.GetFiles(subFolder, "*.json");
                foreach (string filePath in jsonFiles)
                {
                    string fileName = Path.GetFileNameWithoutExtension(filePath);
                    string jsonContent = File.ReadAllText(filePath);
                    object jsonObject = JsonSerializer.Deserialize<object>(jsonContent);
                    folderJson[fileName] = jsonObject;
                }

                if (folderJson.Count > 0)
                {
                    mergedJson[folderName] = folderJson;
                }
            }

            if (mergedJson.Count == 0)
            {
                Console.WriteLine("錯誤：Json 資料夾內沒有任何 JSON 檔案（直接檔案或子資料夾內）。");
                return;
            }

            // 配置序列化選項，保留中文字符
            var options = new JsonSerializerOptions
            {
                WriteIndented = false, // 格式化輸出
                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping // 不對中文進行逸出
            };

            // 將結果序列化為 JSON 字串
            string mergedJsonString = JsonSerializer.Serialize(mergedJson, options);

            // 寫入新檔案到當前目錄
            string outputFile = Path.Combine(currentDirectory, "規則書.txt");
            File.WriteAllText(outputFile, mergedJsonString, Encoding.UTF8);

            Console.WriteLine($"成功合併 Json 資料夾內的檔案，已輸出至：{outputFile}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"發生錯誤：{ex.Message}");
        }
    }
}