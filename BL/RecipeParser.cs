using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Globalization;

namespace RecipeLoader
{
    public class RecipeParser : INotifiable
    {
        public Action<string> Notify { get; set; }
        RecipeData data;
        ToolDictionary tools;
        public int HeaderLines { get; set; } = 3;
        public RecipeParser(ToolDictionary Tools)
        {            
            tools = Tools;
        }
        public RecipeData Parse(string filename)
        {
            if (!File.Exists(filename))
            {
                throw new Exception($"Файл рецепта '{filename}' не найден!");
            }
            else
            {
                Notify($"Открыт файл рецепта '{filename}'");
                Notify?.Invoke("Распознаем рецепт...");
                string[] lines = File.ReadAllLines(filename);
                data = new RecipeData();

                int j = 0;
                for (int i = HeaderLines; i < lines.Length; i++)
                {
                    try
                    {
                        data.Lines.Add(parseLine(lines[i]));                       
                    }
                    catch (Exception e)
                    {
                        Notify?.Invoke($"Ошибка в рецепте. Строка № {i + 1}: {e.Message}");
                        throw new Exception("Рецепт имеет неверный формат");
                    }
                }               
            }
            Notify?.Invoke("Рецепт распознан");
            return data;
        }
        RecipeLine parseLine(string rawLine)
        {
            //Notify($"Распознаем строку {rawLine}");
            string[] substr = rawLine.Split(',');
            //Notify($"Длина строки {substr.Length}");
            if (substr.Length % 2 != 1)
                throw new Exception("Некорректная длина строки");
            RecipeLine resultLine = new RecipeLine();    
                
            int tool;
            double value;

            int j = 0;
            for (int i = 5; i < substr.Length; i+=2)
            {                
                //Notify($"Распознаем инструмент {substr[i]}");
                try { tool = tools[substr[i]]; }
                catch { throw new Exception($"Инструмент на позиции {(i - 5)/2 + 1} не распознан"); }
                //Notify($"Распознаем значение {substr[i + 1]}");
                try { value = double.Parse(substr[i + 1], CultureInfo.InvariantCulture); }
                catch { throw new Exception($"Инструмент: '{substr[i]}' Неверный формат значения"); }

                resultLine.Items.Add(new RecipeItem(tool, value));
            }
            return resultLine;
        }
    }
}
