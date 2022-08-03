using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Text.RegularExpressions;

namespace RecipeLoader
{
    public class AppSettings : ICloneable
    {
        Regex repIP = new Regex(@"(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)");
        string _plcIP = "192.168.0.2";
        public string PLCIp 
        { 
            get { return _plcIP; } 
            set 
            {
                if (repIP.IsMatch(value))
                    _plcIP = value;
                else
                    throw new Exception("Неверный формат IP!");
            } 
        }
        string _dbNum = "1";
        public string DBNum
        {
            get { return _dbNum; }
            set
            {
                int dbnum;
                try
                {
                    dbnum = short.Parse(value);
                    if (dbnum < 1 || dbnum > 99999)
                        throw new Exception("Неверный формат блока данных! Введите число от 1 до 99999");
                    else
                        _dbNum = value;
                }
                catch
                {
                    throw new Exception("Неверный формат блока данных! Введите число от 1 до 99999");
                }                
            }
        }            
        public string ArrayOffset = "0";
        int _arrayDim1 = 10;
        public int ArrayDim1
        {
            get { return _arrayDim1; }
            set
            {
                if (value < 1 || value > 1000)
                    throw new Exception("Неверный формат размера массива! Введите число от 1 до 1000");
                else
                    _arrayDim1 = value;
            }
        }
        int _arrayDim2 = 10;
        public int ArrayDim2
        {
            get { return _arrayDim2; }
            set
            {
                if (value < 1 || value > 1000)
                    throw new Exception("Неверный формат размера массива! Введите число от 1 до 1000");
                else
                    _arrayDim2 = value;
            }
        }

        public int FormHeight = 400;
        public int FormWidth = 400; 
        public System.Drawing.Point FormLocation = new System.Drawing.Point(0,0);

        public string RecipeSearchFilter = "xls files (*.xls)|*.xls|csv files (*.csv)|*.csv";
        public object Clone()
        {
            return MemberwiseClone();
        }

    }

    public class AppSettingsLoader : INotifiable
    {
        AppSettings settings;
        public AppSettings Settings 
        {
            get
            {
                return (AppSettings)settings.Clone();
            }
            private set
            {
                settings = value;
            }
        }
        string XMLFileName = "settings.xml";
        XmlSerializer ser = new XmlSerializer(typeof(AppSettings));

        public void Load()
        {
            Notify?.Invoke("Загрузка настроек...");
            if (File.Exists(XMLFileName))
            {                
                TextReader Reader = new StreamReader(XMLFileName);
                Settings = ser.Deserialize(Reader) as AppSettings;
                Reader.Close();
                Notify?.Invoke("Настройки загружены");
            }
            else
            {                
                Settings = new AppSettings();
                writeXML(this.settings);
                Notify?.Invoke($"Файл {XMLFileName} не найден. Создан новый файл с настройками по умолчанию!");
            }
            SettingsChanged?.Invoke(Settings);
        }

        public Action<string> Notify { get; set; }
        public Action<AppSettings> SettingsChanged { get; set; }

        public void SaveFormDim(int Height, int Width, System.Drawing.Point Location)
        {
            settings.FormHeight = Height;
            settings.FormWidth = Width;
            settings.FormLocation = Location;
            writeXML(settings);
            SettingsChanged?.Invoke(Settings);
        }
        public void Save(AppSettings settings)
        {

            Settings = settings;
            writeXML(this.settings);
            Notify?.Invoke("НАСТРОЙКИ УСПЕШНО СОХРАНЕНЫ!");
        }

        void writeXML(AppSettings settings)
        {
            TextWriter Writer = new StreamWriter(XMLFileName);
            ser.Serialize(Writer, settings);
            Writer.Close();
        }
    }
}
