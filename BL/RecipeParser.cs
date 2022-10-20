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
        public event Action<string> Notify;
        ToolDictionary tools;
        public int HeaderLines { get; set; } = 3;
        public RecipeParser(ToolDictionary Tools)
        {            
            tools = Tools;
        }
        public List<Component> ParseFiles(string[] files)
        {
            bool isErrorExists = false;
            bool isSuccessExists = false;
            List<Component> result = new List<Component>();
            foreach (string file in files)
            {
                try
                {
                    result.AddRange(Parse(file));
                    isSuccessExists = true;
                }
                catch (Exception ex)
                {
                    isErrorExists = true;
                }
            }
            if (!isErrorExists)
                Notify?.Invoke($"Рецепты распознаны");
            else
            {
                if (isSuccessExists)
                    Notify?.Invoke($"Рецепты распознаны. Есть ошибки");
                else 
                    Notify?.Invoke($"Не удалось распознать рецепты");
            }
            return result;            
        }

        public List<Component> Parse(string filename)
        {
            List<Component> data;
            string frameSet;
            if (!File.Exists(filename))
            {
                throw new Exception($"Файл рецепта '{filename}' не найден!");
            }
            else
            {
                Notify?.Invoke($"Читаем рецепт {filename}");
                string[] lines = File.ReadAllLines(filename);
                if(lines.Length < 3)
                {
                    Notify?.Invoke($"Ошибка в рецепте. Недостаточно строк");
                    throw new Exception("Рецепт имеет неверный формат");
                }
                else
                {
                    try
                    {
                        string[] str = lines[2].Split(',').Skip(1).ToArray();
                        frameSet = string.Join("/", str);                        
                    }
                    catch (Exception ex)
                    {
                        Notify?.Invoke($"Ошибка в рецепте. Неверный формат FrameSet");
                        throw new Exception("Рецепт имеет неверный формат");
                    }

                }
                data = new List<Component>();

                int j = 0;
                for (int i = HeaderLines; i < lines.Length; i++)
                {
                    try
                    {
                        Component component = parseLine(lines[i]);
                        component.FileName = Path.GetFileName(filename);                        
                        component.FrameSet = frameSet;    
                        component.IsOnLoadQueue = true;
                        data.Add(component);                       
                    }
                    catch (Exception e)
                    {
                        Notify?.Invoke($"Ошибка в рецепте. Строка № {i + 1}: {e.Message}");
                        throw new Exception("Рецепт имеет неверный формат");
                    }
                }               
            }            
            return data;
        }
        Component parseLine(string rawLine)
        {
            //Notify($"Распознаем строку {rawLine}");
            if(rawLine.Trim().Length == 0)
                throw new Exception("Пустая стркоа");
            string[] substr = rawLine.Split(',');
            //Notify($"Длина строки {substr.Length}");            
            if (substr.Length % 2 != 1)
                throw new Exception("Некорректная длина строки");
            Component resultLine = new Component();    
                
            int tool;
            double value;

            int j = 0;

            try { resultLine.Number = int.Parse(substr[1]); }
            catch { throw new Exception($"Ошибка в номере компонента"); }

            try { resultLine.Len = double.Parse(substr[4], CultureInfo.InvariantCulture); }
            catch { throw new Exception($"Ошибка в длине детали"); }

            try { resultLine.Inverted = parseStateInverted(substr[2]); }
            catch { throw new Exception($"Ошибка параметре направления"); }
            resultLine.Direction = stringDirection(resultLine.Inverted);

            for (int i = 5; i < substr.Length; i+=2)
            {                
                //Notify($"Распознаем инструмент {substr[i]}");
                try { tool = tools[substr[i]]; }
                catch { throw new Exception($"Инструмент на позиции {(i - 5)/2 + 1} не распознан"); }
                //Notify($"Распознаем значение {substr[i + 1]}");
                try { value = double.Parse(substr[i + 1], CultureInfo.InvariantCulture); }
                catch { throw new Exception($"Инструмент: '{substr[i]}' Неверный формат значения"); }

                resultLine.Tools.Add(new ToolPosn(tool, value));
            }
            return resultLine;
        }

        bool parseStateInverted(string str)
        {
            if(str == "LABEL_INV")
                return true;
            else
                return false;            
        }
        string stringDirection(bool inverted)
        {
            if (inverted)
                return "Обратное";
            else
                return "Прямое";
        }
    }
}
