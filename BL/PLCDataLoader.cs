using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using S7;
using S7.Net;

namespace RecipeLoader
{
    public class PLCDataLoader : INotifiable
    {
        public Action<string> Notify { get; set; }
        PlcSettings settings;

        CpuType MyCpuType = S7.Net.CpuType.S71500;
        String MyCpuIp = "10.10.11.98";
        short MyCpuRack = 0;
        short MyCpuSlot = 1;
        Plc plc;
        ErrorCode connectionResult;

        public PLCDataLoader(PlcSettings settings)
        {
            this.settings = settings;
        }

        public void LoadRecipe(RecipeData recipe)
        {
            Notify?.Invoke("Загрузка рецепта в ПЛК...");
            int i = 0;
            if (recipe.Components.Count > settings.MaxNumberOfComponents) throw new Exception($"Количество строк в рецепте - {recipe.Components.Count} больше, " +
                                                                                $"чем количество строк в массиве ПЛК - {settings.MaxNumberOfComponents}");
            using (plc = new Plc(MyCpuType, MyCpuIp, MyCpuRack, MyCpuSlot))
            {
                connectionResult = plc.Open();

                if (!plc.IsConnected)
                {
                    throw new Exception($"Не удалось подключиться к ПЛК: {connectionResult}");
                }
                else
                {
                    foreach (var line in recipe.Components)
                    {
                        int j = 0;
                        foreach (var item in line.Tools)
                        {
                            //Notify?.Invoke($"Загружаем инструмент {recipe.Lines[i].Items[j].Tool} : {recipe.Lines[i].Items[j].Value}");
                            j++;
                            if (j > settings.MaxToolsInComponent) throw new Exception($"Количество инструментов в строке № {i + 1} - {j} больше, " +
                                                                            $"чем количество элементов в массиве ПЛК - {settings.MaxToolsInComponent}");
                        }
                        Notify($"Загружаем строку {i + 1}. Загружено инструментов: {j}");
                        i++;
                    }
                    Notify($"Загружено строк: {i}");
                    Notify?.Invoke("Рецепт загружен в ПЛК");

                    plc.Close();
                }
            }
        } 
    }
}
//public partial class Form1 : Form
//{
//    CpuType MyCpuType = S7.Net.CpuType.S71500;
//    String MyCpuIp = "10.10.10.98";
//    short MyCpuRack = 0;
//    short MyCpuSlot = 1;
//    Plc plc;
//    ErrorCode connectionResult;

//    public Form1()
//    {
//        InitializeComponent();
//        plc = new Plc(MyCpuType, MyCpuIp, MyCpuRack, MyCpuSlot);
//    }

//    private void button1_Click(object sender, EventArgs e)
//    {
//        connectionResult = plc.Open();
//        if (plc.IsConnected)
//        {
//            bool myBool = (bool)plc.Read("DB1000.DBX0.0");

//            MessageBox.Show("Считано значение DB1000.DBX0.0 " + myBool.ToString() + "\n"
//                + "Запишем значение " + (!myBool).ToString()
//                );
//            if (myBool)
//                plc.Write("DB1000.DBX0.0", 0);
//            else
//                plc.Write("DB1000.DBX0.0", 1);
//        }
//        else
//            MessageBox.Show(connectionResult.ToString() + "Подключение к ПЛК не удалось");
//        plc.Close();

//    }
//}