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
                    tbIP.Text = settings.Plc.Ip;
                    tbArrayDim1.Text = settings.Plc.MaxNumberOfComponents.ToString();
                    tbArrayDim2.Text = settings.Plc.MaxToolsInComponent.ToString();

                    cbEnableSystemMsg.Checked = settings.Plc.EnableLogSystemMsg;
                }
            }
        }
        public SettingsControl()
        {
            InitializeComponent();
        }
        public event Action<string> Notify;
        public void Save()
        {
            try
            {
                settings.Plc.Ip = tbIP.Text;
                settings.Plc.MaxNumberOfComponents = short.Parse(tbArrayDim1.Text);
                settings.Plc.MaxToolsInComponent = short.Parse(tbArrayDim2.Text);

                settings.Plc.EnableLogSystemMsg = cbEnableSystemMsg.Checked;
            }
            catch (Exception ex)
            {
                Notify?.Invoke(ex.Message);
                throw new Exception("Не удалось сохранить настройки");
            }
        }  
    }
}
