using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace RecipeLoader
{
    public partial class SettingsControl : UserControl, INotifiable
    {
        

        AppSettings settings;
        public AppSettings Settings
        {
            get
            {
                return settings;
            }
            set
            {
                if (value != null)
                {
                    settings = value;
                    tbIP.Text = settings.PLCIp;
                    tbArrayDim1.Text = settings.ArrayDim1.ToString();
                    tbArrayDim2.Text = settings.ArrayDim2.ToString();
                }
            }
        }
        public SettingsControl()
        {
            InitializeComponent();
        }
        public Action<string> Notify { get; set; }
        public void Save()
        {
            try
            {
                settings.PLCIp = tbIP.Text;
                settings.ArrayDim1 = short.Parse(tbArrayDim1.Text);
                settings.ArrayDim2 = short.Parse(tbArrayDim2.Text);
            }
            catch (Exception ex)
            {
                Notify?.Invoke(ex.Message);
                throw new Exception("Не удалось сохранить настройки");
            }
        }  
    }
}
