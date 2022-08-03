using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RecipeLoader
{
    public class PLCDataLoader : INotifiable
    {
        public Action<string> Notify { get; set; }
        public int ArrayDim1 { get; private set; }
        public int ArrayDim2 { get; private set; }
        public PLCDataLoader(int arrayDim1, int arrayDim2)
        {
            ArrayDim1 = arrayDim1;
            ArrayDim2 = arrayDim2;
        }
        public void LoadRecipe(RecipeData recipe)
        {                      
            Notify?.Invoke("Загрузка рецепта в ПЛК...");
            int i = 0;
            if (recipe.Lines.Count > ArrayDim1) throw new Exception($"Количество строк в рецепте - {recipe.Lines.Count} больше, чем количество строк в массиве ПЛК - {ArrayDim1}");
            foreach(var line in recipe.Lines)
            {
                int j = 0;
                foreach(var item in line.Items)
                {
                    //Notify?.Invoke($"Загружаем инструмент {recipe.Lines[i].Items[j].Tool} : {recipe.Lines[i].Items[j].Value}");
                    j++;
                    if (j > ArrayDim2) throw new Exception($"Количество инструментов в строке № {i + 1} - {j} больше, чем количество элементов в массиве ПЛК - {ArrayDim2}");
                }
                Notify($"Загружаем строку {i + 1}. Загружено инструментов: {j}");                
                i++;            
            }
            Notify($"Загружено строк: {i}");
            Notify?.Invoke("Рецепт загружен в ПЛК");
        }
    }
}
