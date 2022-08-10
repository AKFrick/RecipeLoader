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
        public event Action<string> Notify;
        PlcSettings settings;
        Plc plc;
        ErrorCode connectionResult;


        int componentsTotal_Offset = 0;
        int componentsTotal_Size = 2;

        int components_Offset = 2;
        int componentLen_Offset = 0; //Относительно начала структуры компонента
        int componentLen_Size = 4;
        int toolsTotal_Offset = 4; //Относительно начала структуры компонента
        int toolsTotal_Size = 2;

        int tools_Offset = 6;
        int toolNum_Offset = 0; //Относительн начала структуры инструмента
        int toolNum_Size = 2;
        int toolPosn_Offset = 2;
        int toolPosn_Size = 4;
        int tool_Size = 6; //Размер структуры инструмента

        int component_Size; //Размер структуры компонента

        public PLCDataLoader(PlcSettings settings)
        {
            this.settings = settings;
            component_Size = componentLen_Size + toolsTotal_Size + tool_Size * (settings.MaxToolsInComponent);
        }
        public void LoadAsStruct(RecipeData recipe)
        {            
        }

        public void LoadRecipe(RecipeData recipe)
        {
            Notify?.Invoke("Загрузка рецепта в ПЛК...");
            int i = 0;
            if (recipe.Components.Count > settings.MaxNumberOfComponents) throw new Exception($"Количество строк в рецепте - {recipe.Components.Count} больше, " +
                                                                                $"чем количество строк в массиве ПЛК - {settings.MaxNumberOfComponents}");

            using (plc = new Plc(settings.CpuType, settings.Ip, settings.CpuRack, settings.CpuSlot))
            {
                connectionResult = plc.Open();

                if (!plc.IsConnected)
                {
                    throw new Exception($"Не удалось подключиться к ПЛК по адресу {settings.Ip}: {connectionResult}");
                }
                else
                {
                    foreach (var line in recipe.Components)
                    {
                        int j = 0;
                        foreach (var item in line.Tools)
                        {
                            //Notify?.Invoke($"Загружаем инструмент {recipe.Lines[i].Items[j].Tool} : {recipe.Lines[i].Items[j].Value}");
                            if (j > settings.MaxToolsInComponent) throw new Exception($"Количество инструментов в строке № {i + 1} - {j} больше, " +
                                                                            $"чем количество элементов в массиве ПЛК - {settings.MaxToolsInComponent}");
                            else
                            {
                                if (settings.EnableLogSystemMsg) Notify($"Write tool num: {getToolNumAddress(i, j)} " +
                                                                        $"Value: {getToolNumValue(recipe, i, j)}, " +
                                                                        $"Write tool posn: {getToolPosnAddress(i, j)} " +
                                                                        $"Value: {getToolPosnValue(recipe, i, j)}");

                                plc.Write(getToolNumAddress(i, j), getToolNumValue(recipe, i, j));                                
                                plc.WriteDouble(int.Parse(settings.DBNum), getToolPosnOffset(i,j), getToolPosnValue(recipe, i, j));
                                j++;
                            }
                        }
                        if (settings.EnableLogSystemMsg) Notify($"Write Component len: {getComponentLenAddress(i)} " +
                                                                $"Value: {getComponentLenValue(recipe, i)} " +
                                                                $"Write tools total: {getToolTotalAddress(i)} " +
                                                                $"Value: {j} ");

                        plc.WriteDouble(int.Parse(settings.DBNum), getComponentLenOffset(i), getComponentLenValue(recipe, i));
                        plc.Write(getToolTotalAddress(i), j);

                        //Обнулям незаполненные элементы
                        for (; j < settings.MaxToolsInComponent; j++)
                        {
                            if (settings.EnableLogSystemMsg) Notify($"Reset toolNum: {getToolNumAddress(i, j)}, " +
                                                                    $"toolPosn: {getToolPosnAddress(i, j)} " +
                                                                    $"to 0");
                            plc.Write(getToolNumAddress(i, j), 0);
                            plc.Write(getToolPosnAddress(i, j), 0);
                        }

                        i++;
                    }

                    if (settings.EnableLogSystemMsg) Notify($"Write components total: {getComponentsTotalAddress()} Value: {i}");
                    plc.Write(getComponentsTotalAddress(), i);

                    Notify?.Invoke($"Загружено строк: {i}");
                    Notify?.Invoke($"Обнуляем неиспользуемые строки...:");

                    //Обнуляем незаполненные строки
                    for (; i < settings.MaxNumberOfComponents; i++)
                    {
                        if (settings.EnableLogSystemMsg) Notify($"Reset Component len: {getComponentLenAddress(i)} " +
                                                                $"tools total: {getToolTotalAddress(i)} " +
                                                                $"to 0 ");
                        plc.Write(getComponentLenAddress(i), 0);
                        plc.Write(getToolTotalAddress(i), 0);
                        for (int j = 0; j < settings.MaxToolsInComponent; j++)
                        {
                            if (settings.EnableLogSystemMsg) Notify($"Reset toolNum: {getToolNumAddress(i, j)}, " +
                                                                    $"toolPosn: {getToolPosnAddress(i, j)} " +
                                                                    $"to 0");
                            plc.Write(getToolNumAddress(i, j), 0);
                            plc.Write(getToolPosnAddress(i, j), 0);
                        }
                    }
                    Notify?.Invoke("Рецепт загружен в ПЛК");
                    plc.Close();

                }
            }
        }
        string getToolNumAddress(int componentNum, int toolNum)
            => $"DB{ settings.DBNum}.DBW{ components_Offset + componentNum * component_Size + tools_Offset + toolNum * tool_Size + toolNum_Offset}";

        int getToolNumValue(RecipeData recipe, int componentNum, int toolNum)
            => recipe.Components.ElementAt(componentNum).Tools.ElementAt(toolNum).Tool;

        string getToolPosnAddress(int componentNum, int toolNum)
            => $"DB{settings.DBNum}.DBD{getToolPosnOffset(componentNum, toolNum)}";
        int getToolPosnOffset(int componentNum, int toolNum)
            => components_Offset + componentNum * component_Size + tools_Offset + toolNum * tool_Size + toolPosn_Offset;

        double getToolPosnValue(RecipeData recipe, int componentNum, int toolNum)
            => recipe.Components.ElementAt(componentNum).Tools.ElementAt(toolNum).Value;        

        string getComponentLenAddress(int componentNum)
            => $"DB{settings.DBNum}.DBD{getComponentLenOffset(componentNum)}";
        int getComponentLenOffset(int componentNum)
            => components_Offset + component_Size * componentNum + componentLen_Offset;
        double getComponentLenValue(RecipeData recipe, int componentNum)
                => recipe.Components.ElementAt(componentNum).Len;
        string getToolTotalAddress(int componentNum)
            => $"DB{settings.DBNum}.DBW{components_Offset + component_Size * componentNum + toolsTotal_Offset}";

        string getComponentsTotalAddress()
            => $"DB{settings.DBNum}.DBW{componentsTotal_Offset}";       
            
    }
    static class PlcExt
    {
        public static void WriteDouble(this Plc plc, int db, int offset, double value)
        {
            plc.WriteBytes(DataType.DataBlock, db, offset, S7.Net.Types.Double.ToByteArray(value));
        }

    }
}