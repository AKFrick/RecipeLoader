using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace RecipeLoader
{
    public class ToolDictionary : Dictionary<string, int> { }
    public class ToolDictionaryLoader : INotifiable
    {
        string filename = "Res/ToolDictionary.csv";
        public ToolDictionary Tools { get; private set; }
        public Action<string> Notify { get; set; }

        public void Load()
        {
            if (!File.Exists(filename))
                throw new Exception($"Файл инструментов '{filename}' не найден!");
            else
            {
                Notify?.Invoke("Загрузка списка инструментов...");
                Tools = new ToolDictionary();
                string[] lines = File.ReadAllLines(filename);
 
                foreach (string line in lines)
                {                    
                    try
                    {
                        string[] substr = line.Split(',');
                        Tools.Add(substr[0], short.Parse(substr[1]));                     
                    }
                    catch (Exception ex)
                    {
                        Notify?.Invoke($"Ошибка в строке файла инструмента: {line} - {ex.Message}");
                        throw new Exception($"Неверный формат файла инструментов {filename}");                        
                    }
                }
                Notify?.Invoke("Список инструментов загружен");
            }
                
        }
    }
}
