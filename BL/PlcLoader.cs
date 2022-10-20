using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using S7;
using S7.Net;

namespace RecipeLoader
{
    public class PlcLoader
    {
        public event Action<string> Notify;
        PlcSettings settings;
        Plc plc;
        ErrorCode connectionResult;

        int component_Offset = 2; //Офсет структуры компонента
        int componentLen_Offset = 0; //От начала структуры компонента
        int componentNumber_Offset = 4;
        int componentFrameSet_Offset = 6;
        int componentInvDirection_Offset = 33;                
        int toolsTotal_Offset = 34;        
        
        int tools_Offset = 36; //Относительно начала структуры компонетна
        int toolNum_Offset = 0; //Относительно начала структуры инструмента 
        int toolNum_Size = 2;
        int toolPosn_Offset = 2;
        int toolPosn_Size = 4;
        int tool_Size = 6;

        string componentLoaded_Offset = "DBX0.1";
        string LoadQuery_Offset = "DBX0.0";

        public PlcLoader(PlcSettings settings)
        {
            this.settings = settings;            
        }        
        public void LoadComponent(Component component)
        {            
            using (plc = new Plc(settings.CpuType, settings.Ip, settings.CpuRack, settings.CpuSlot))
            {
                connectionResult = plc.Open();

                if (!plc.IsConnected)
                {
                    throw new Exception($"Не удалось подключиться к ПЛК по адресу {settings.Ip}: {connectionResult}");
                }
                else
                {
                    //Проверим, можно ли загружать компонент
                    if (settings.EnableLogSystemMsg) Notify($"Считываем бит LoadQuery: {getLoadQueryAddress()}");

                    if (!(bool)plc.Read(getLoadQueryAddress()))
                    {
                        if (settings.EnableLogSystemMsg) Notify("Загрузка не разрешена");
                        return; 
                    }


                    if (component.Tools.Count > settings.MaxToolsInComponent) 
                        throw new Exception($"Количество инструментов {component.Tools.Count} больше, " +
                                            $"чем количество элементов в массиве ПЛК - {settings.MaxToolsInComponent}");
                    int i = 0;
                    //Запишем список инструментов
                    for(; i < component.Tools.Count ; i++)
                    {                                                                        
                        if (settings.EnableLogSystemMsg) Notify($"Write tool num: {getToolNumAddress(i)} " +
                                                                $"Value: {getToolNumValue(component, i)}, " +
                                                                $"Write tool posn: {getToolPosnAddress(i)} " +
                                                                $"Value: {getToolPosnValue(component, i)}");

                        plc.Write(getToolNumAddress(i), getToolNumValue(component, i));
                        plc.WriteDouble(int.Parse(settings.DBNum), getToolPosnOffset(i), getToolPosnValue(component, i));
                        
                    }
                    //Обнулям незаполненные инструменты
                    for (; i < settings.MaxToolsInComponent; i++)
                    {
                        if (settings.EnableLogSystemMsg) Notify($"Reset toolNum: {getToolNumAddress(i)}, " +
                                                                $"toolPosn: {getToolPosnAddress(i)} " +
                                                                $"to 0");
                        plc.Write(getToolNumAddress(i), 0);
                        plc.Write(getToolPosnAddress(i), 0);
                    }

                    //Запишем остальные данные компонента
                    if (settings.EnableLogSystemMsg) Notify($"Write Component len: {getComponentLenAddress()} " +
                                                            $"Value: {component.Len} //" +
                                                            $"Write Component Number " +
                                                            $"Value: {component.Number} //" +
                                                            $"Write InvDirection: {getInvDirectionAddress()} " +
                                                            $"Write FrameSet + Number: {getFrameSetAddress()} " +
                                                            $"Value: {component.FrameSet} {component.Number} //" +
                                                            $"Value: {component.Inverted} //" + 
                                                            $"Write tools total: {getToolTotalAddress()} " +
                                                            $"Value: {component.Tools.Count} //" +
                                                            $"Write CompnentLoaded: {getComponentLoadedAddress()} " +
                                                            $"Value: True //"
                                                            );
                    
                    plc.WriteDouble(int.Parse(settings.DBNum), getComponentLenOffset(), component.Len);
                    plc.Write(getComponentNumberAddress(), component.Number);
                    
                    string frameSet = $"{component.FrameSet} {component.Number}";                                        
                    plc.WriteString(int.Parse(settings.DBNum), getFrameSetOffset(), settings.FrameSetLen, frameSet);

                    plc.Write(getInvDirectionAddress(), component.Inverted);
                    plc.Write(getComponentNumberAddress(), component.Number);                    
                    plc.Write(getToolTotalAddress(), component.Tools.Count);

                    plc.Write(getComponentLoadedAddress(), true);

                    Notify?.Invoke($"Компонент {frameSet} загружен в ПЛК");
                }
            }
        }

        string getToolNumAddress(int toolNum)
           => $"DB{ settings.DBNum}.DBW{ component_Offset + tools_Offset + toolNum * tool_Size + toolNum_Offset}";

        int getToolNumValue(Component component, int toolNum)
            => component.Tools.ElementAt(toolNum).Tool;
        string getToolPosnAddress(int toolNum)
            => $"DB{settings.DBNum}.DBD{getToolPosnOffset(toolNum)}";
        int getToolPosnOffset(int toolNum)
            => component_Offset + tools_Offset + toolNum * tool_Size + toolPosn_Offset;
        double getToolPosnValue(Component component, int toolNum)
            => component.Tools.ElementAt(toolNum).Value;

        string getComponentLenAddress()
            => $"DB{settings.DBNum}.DBD{getComponentLenOffset()}";
        int getComponentLenOffset()
            => component_Offset + componentLen_Offset;

        string getComponentNumberAddress()
            => $"DB{settings.DBNum}.DBW{component_Offset + componentNumber_Offset}";

        string getFrameSetAddress()
            =>$"DB{settings.DBNum}.DBB{getFrameSetOffset()}";

        int getFrameSetOffset()
            => component_Offset + componentFrameSet_Offset;

        string getInvDirectionAddress()
            => $"DB{settings.DBNum}.DBX{component_Offset + componentInvDirection_Offset}.0";

        string getToolTotalAddress()
            => $"DB{settings.DBNum}.DBW{component_Offset + toolsTotal_Offset}";

        string getComponentLoadedAddress()
            => $"DB{settings.DBNum}.{componentLoaded_Offset}";
        string getLoadQueryAddress()
            => $"DB{settings.DBNum}.{LoadQuery_Offset}";
    }
}
